using KEUtils.About;
using KEUtils.ScrolledHTML;
using KEUtils.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static MapLines.MapCalibration;

namespace MapLines {
    public partial class MainForm : Form {
        public static readonly String NL = Environment.NewLine;
        public static readonly float MOUSE_WHEEL_ZOOM_FACTOR = 0.001F;
        public static readonly float KEY_ZOOM_FACTOR = 1.1F;
        public static readonly Color SELECT_COLOR = Color.FromArgb(62, 140, 236);
        public static readonly float LINE_WIDTH = 2;
        public static readonly float HIT_TOLERANCE = 10;
        public static readonly Point INVALID_POINT =
            new Point(Int32.MinValue, Int32.MinValue);

        public enum Mode { NORMAL, PAN, EDIT }
        public Mode ActiveMode { get; set; } = Mode.NORMAL;

        private static ScrolledHTMLDialog overviewDlg;

        public Line HitLine { get; set; }
        public HitPoint HitPoint { get; set; }

        /// <summary>
        /// The loaded image.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// A Bitmap the same size as the main Image that holds the lines.
        /// </summary>
        public Image LinesImage { get; set; }

        /// <summary>
        /// A Bitmap the same size as the main Image that holds the overlay.
        /// </summary>
        public Image OverlayImage { get; set; }

        /// <summary>
        /// Flag to indicate panning with the key down is happening.
        /// </summary>
        public bool KeyPanning { get; set; }

        /// <summary>
        /// Location where mouse panning starts.
        /// </summary>
        public Point PanStart { get; set; }

        /// <summary>
        /// Indicates how much the Image is zoomed. Larger values correspond
        /// to zoomed in.
        /// </summary>
        float ZoomFactor { get; set; }

        /// <summary>
        ///  The RectangleF that denotes what part of the image is currently seen.
        /// </summary>
        public RectangleF ViewRectangle { get; set; }

        /// <summary>
        /// Holds the currentl lines.
        /// </summary>
        public Lines Lines { get; set; } = new Lines();

        /// <summary>
        /// Holds the current line while drawing. Whether it is null or not
        /// is a flag for when drawing is happening.
        /// </summary>
        public Line CurLine { get; set; }

        /// <summary>
        /// Used for numbering lines.
        /// </summary>
        public int NextLineNumber { get; set; }

        /// <summary>
        /// Holds the current calibration information. Is null if there is no
        /// calibration file loaded.
        /// </summary>
        public MapCalibration MapCalibration { get; set; }

        public MainForm() {
            InitializeComponent();

            ZoomFactor = 1.0F;
            pictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
            this.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
        }

        #region Image Manipulation

        /// <summary>
        /// Sets the ViewRectangle and calls Invalidate on the PictureBox.
        /// </summary>
        private void zoomImage() {
            Size clientSize = pictureBox.ClientSize;
            float newWidth = clientSize.Width * ZoomFactor;
            float newHeight = clientSize.Height * ZoomFactor;
            // Make it appear as if the zoom were at the center
            float newX = ViewRectangle.X - .5F * (newWidth - ViewRectangle.Width);
            float newY = ViewRectangle.Y - .5F * (newHeight - ViewRectangle.Height);
            ViewRectangle = new RectangleF(newX, newY, newWidth, newHeight);
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Sets the ViewRectangle to fit the Image in the PictureBox.
        /// </summary>
        private void resetViewToFit() {
            if (Image == null || Image.Width <= 0 || Image.Height <= 0) {
                return;
            }
            Size clientSize = pictureBox.ClientSize;
            float aspect = (float)Image.Height / Image.Width;
            float clientAspect = (float)clientSize.Height / clientSize.Width;
            if (aspect < clientAspect) {
                ZoomFactor = (float)Image.Width / clientSize.Width;
            } else {
                ZoomFactor = (float)Image.Height / clientSize.Height;
            }
            float newWidth = clientSize.Width * ZoomFactor;
            float newHeight = clientSize.Height * ZoomFactor;
            // Center it
            float newX = .5F * (Image.Width - newWidth);
            float newY = .5F * (Image.Height - newHeight);
            ViewRectangle = new RectangleF(newX, newY, newWidth, newHeight);
            pictureBox.Invalidate();
        }

        private void resetImage() {
            resetImage(null, false);
        }

        /// <summary>
        /// Sets the initial, unzoomed, origin at top left ViewRectangle. Uses
        /// the Current Image or loads a new one depending on replace.
        /// </summary>
        /// <param name="fileName">Name of an image file.</param>
        /// <param name="replace">Whether to laod a new Image ffrom the fileName.</param>
        private void resetImage(string fileName, bool replace) {
            if (replace) {
                if (Image != null) Image.Dispose();
                Image = new Bitmap(fileName);
                if (LinesImage != null) LinesImage.Dispose();
                LinesImage = new Bitmap(Image.Width, Image.Height);
            }
            ZoomFactor = 1.0F;
            Size clientSize = pictureBox.ClientSize;
            ViewRectangle = new RectangleF(0, 0, clientSize.Width, clientSize.Height);
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Converts a PictureBox point to an Image Point.
        /// </summary>
        /// <param name="pictureBoxPoint"></param>
        /// <returns>The Image Point.</returns>
        private Point imagePoint(Point pictureBoxPoint) {
            Debug.WriteLine("imagePoint: in=" + pictureBoxPoint
                + " ZoomFactor=" + ZoomFactor + NL
                + "    ViewRectangle=" + ViewRectangle);
            int x = (int)Math.Round(ViewRectangle.X
                + (float)pictureBoxPoint.X * ZoomFactor);
            int y = (int)Math.Round(ViewRectangle.Y
                + (float)pictureBoxPoint.Y * ZoomFactor);
            return new Point(x, y);
        }

        /// <summary>
        /// Determines if the given Point is near any of the lines in 
        /// Lines.LinesList. Sets HitLine to the first found or null if 
        /// none found.
        /// </summary>
        /// <param name="point">The input point in PictureBox coordinates.</param>
        /// <returns>If found.</returns>
        public bool hitTestLine(Point point) {
            if (ActiveMode != Mode.EDIT) return false;
            Point imgPoint = imagePoint(point);
            bool res;
            HitLine = null;
            HitPoint = null;
            Debug.WriteLine("hitTestLine: ActiveMode=" + ActiveMode
                + " ZoomFactor=" + ZoomFactor + NL
                + "    point=" + point + " imgPoint=" + imgPoint + NL
                + "    LINE_WIDTH=" + LINE_WIDTH + " HIT_TOLERANCE=" + HIT_TOLERANCE);
            foreach (Line line in Lines.LinesList) {
                // First check the points
                Region region;
                foreach (Point point1 in line.Points) {
                    region = new Region(centeredSquare(point1, HIT_TOLERANCE));
                    res = region.IsVisible(imgPoint);
                    if (res) {
                        HitPoint = new HitPoint(line, line.Points.IndexOf(point1));
                        HitLine = line;
                        return true;
                    }
                }
                // Then check the lines.
                // Tolerance does not extend past the ends as it does transverse.
                using (var path = new GraphicsPath())
                using (var pen = new Pen(Color.Black, HIT_TOLERANCE)) {
                    for (int i = 1; i < line.NPoints; i++) {
                        path.AddLine(line.Points[i - 1], line.Points[i]);
                    }
                    res = path.IsOutlineVisible(imgPoint, pen);
                    if (res) {
                        HitLine = line;
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Lines
        /// <summary>
        /// Starts a new line.
        /// </summary>
        public void startLine() {
            if (Lines == null || LinesImage == null) {
                return;
            }
            Line line = new Line();
            CurLine = line;
            line.Desc = "Line " + NextLineNumber++;
            Lines.addLine(line);
        }

        /// <summary>
        /// Clears the Lines.
        /// </summary>
        public void clearLines() {
            endLine();
            Lines.clear();
            redrawLines();
        }

        /// <summary>
        /// Makes Lines corresponding to the calibration points.
        /// </summary>
        public void calibrationLines() {
            if (Lines == null || LinesImage == null) {
                return;
            }
            if (MapCalibration == null) {
                Utils.errMsg("Calibration is not available");
                return;
            }
            if (MapCalibration.Transform == null) {
                Utils.errMsg("Calibration is not valid");
                return;
            }
            // End any currently started line
            endLine();
            Line line = new Line();
            Lines.addLine(line);
            foreach (MapData data in MapCalibration.DataList) {
                line.addPoint(new Point(data.X, data.Y));
            }
            // Connect to the beginning
            if (MapCalibration.DataList.Count > 1) {
                MapData data = MapCalibration.DataList[0];
                line.addPoint(new Point(data.X, data.Y));
            }
            line.Desc = "Calibration Lines";
            redrawLines();
        }

        /// <summary>
        /// Deletes the current line.
        /// </summary>
        public void deleteLastPoint() {
            if (LinesImage == null) {
                return;
            }
            if (CurLine == null) {
                Utils.errMsg("There is no current line active");
                return;
            }
            CurLine.deleteLastPoint();
            redrawLines();
        }

        /// <summary>
        /// Ends a line.
        /// </summary>
        public void endLine() {
            if (LinesImage == null) {
                return;
            }
            CurLine = null;
            // // DEBUG
            // System.out.println("endLine");
            // System.out.println("curLine=" + viewer.getCurLine());
            // System.out.println(Lines.info());
        }

        /// <summary>
        /// Redraws the lines on the Bitmap and calls Invalidate on the PictureBox.
        /// </summary>
        public void redrawLines() {
            if (Lines == null) return;
            if (LinesImage == null) return;
            using (Graphics g = Graphics.FromImage(LinesImage)) {
                g.Clear(Color.Transparent);
                Point[] points;
                foreach (Line line in Lines.LinesList) {
                    using (Pen pen = new Pen(line.Color, LINE_WIDTH)) {
                        if (line.Points == null || line.Points.Count < 2) continue;
                        points = line.Points.ToArray();
                        g.DrawLines(pen, points);
                    }
                }
            }
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Redraws the OverlayImage and calls Invalidate on the PictureBox.
        /// </summary>
        public void redrawOverlay() {
            Debug.WriteLine("redrawOverlay: EDIT:" + " HitLine="
               + ((HitLine == null) ? "null" : "\"" + HitLine.Desc + "\"")
               + " HitPoint="
               + ((HitPoint == null) ? "null" : "X=" + HitPoint.Point.X));
            if (ActiveMode != Mode.EDIT) {
                if (OverlayImage != null) {
                    OverlayImage.Dispose();
                    OverlayImage = null;
                }
                pictureBox.Invalidate();
                return;
            }
            if (HitLine == null && HitPoint == null) {
                if (OverlayImage != null) {
                    OverlayImage.Dispose();
                    OverlayImage = null;
                }
                pictureBox.Invalidate();
                return;
            }
            OverlayImage = new Bitmap(Image.Width, Image.Height);
            float size = HIT_TOLERANCE;
            float size2 = HIT_TOLERANCE * 1.5f;
            using (var brush = new SolidBrush(SELECT_COLOR))
            using (var littlePen = new Pen(SELECT_COLOR, LINE_WIDTH))
            using (var littlePenBlack = new Pen(Color.Black, 2))
            using (Graphics g = Graphics.FromImage(OverlayImage)) {
                g.Clear(Color.Transparent);

                if (HitLine != null) {
                    // Draw new color over the lines
                    Point[] points = HitLine.Points.ToArray();
                    g.DrawLines(littlePen, points);
                    foreach (Point point in HitLine.Points) {
                        RectangleF rect = centeredSquare(point, size);
                        g.FillEllipse(brush, rect);
                    }
                }
                if (HitPoint != null) {
                    RectangleF rect = centeredSquare(HitPoint.Point, size2);
                    g.DrawEllipse(littlePenBlack, rect);
                }
            }
            pictureBox.Invalidate();
        }

        private RectangleF centeredSquare(PointF center, float width) {
            return centeredRectangle(center, width, width);
        }

        private RectangleF centeredRectangle(PointF center, float width, float height) {
            return new RectangleF(center.X - width / 2,
                center.Y - height / 2, width, height);
        }
        #endregion

        #region Event Handlers
        private void OnFormLoad(object sender, EventArgs e) {

        }

        private void OnFormShown(object sender, EventArgs e) {
            // This needs to be none in Shown not Load as the sizes aren't
            // right then.
            string imageFileName = Properties.Settings.Default.LastImageFile;
            string calibFileName = Properties.Settings.Default.LastCalibFile;
            try {
                // Load last image
                if (File.Exists(imageFileName)) {
                    resetImage(imageFileName, true);
                }
            } catch (Exception ex) {
                Utils.excMsg("Error opening last image file:" + NL
                    + imageFileName, ex);
                return;
            }
            try {
                // Load last calibration
                if (File.Exists(calibFileName)) {
                    MapCalibration = new MapCalibration();
                    MapCalibration.read(calibFileName);
                }
            } catch (Exception ex) {
                Utils.excMsg("Error opening last calib file:" + NL
                    + calibFileName, ex);
                return;
            }
        }

        private void OnFormResize(object sender, EventArgs e) {
            Size clientSize = pictureBox.ClientSize;
            float newWidth = clientSize.Width * ZoomFactor;
            float newHeight = clientSize.Height * ZoomFactor;
            ViewRectangle = new RectangleF(ViewRectangle.X, ViewRectangle.Y,
                newWidth, newHeight);
            pictureBox.Invalidate();
        }

        private void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                KeyPanning = true;
                pictureBox.Cursor = Cursors.Hand;
            } else if (e.KeyCode == Keys.Oemplus) {
                ZoomFactor /= KEY_ZOOM_FACTOR;
                zoomImage();
            } else if (e.KeyCode == Keys.OemMinus) {
                ZoomFactor *= KEY_ZOOM_FACTOR;
                zoomImage();
            } else if (e.KeyCode == Keys.D0) {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                    resetViewToFit();
                }
            } else if (e.KeyCode == Keys.D1) {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                    resetImage();
                }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e) {
            if (KeyPanning && ActiveMode != Mode.PAN) {
                pictureBox.Cursor = Cursors.Default;
            }
            KeyPanning = false;
        }

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e) {
            // Avoid context menu clicks
            if (e.Button != MouseButtons.Left) return;
            // Needed for KeyPanning as well as PAN
            PanStart = e.Location;
            if (ActiveMode == Mode.PAN) {
                // Do nothing for now
            } else if (ActiveMode == Mode.EDIT) {
                if (!KeyPanning) {
                    bool resLine = hitTestLine(e.Location);
                    Debug.WriteLine("OnPictureBoxMouseDown: EDIT: resLine="
                        + resLine);
                    redrawOverlay();
                }
            } else if (ActiveMode == Mode.NORMAL) {
                if (CurLine != null && e.Button == MouseButtons.Left) {
                    CurLine.addPoint(imagePoint(e.Location));
                    redrawLines();
                }
            }
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e) {
            if (KeyPanning) {
                if (e.Button == MouseButtons.Left) {
                    float deltaX = (PanStart.X - e.X) * ZoomFactor;
                    float deltaY = (PanStart.Y - e.Y) * ZoomFactor;
                    // Reset PanStart
                    PanStart = e.Location;
                    ViewRectangle = new RectangleF(ViewRectangle.X + deltaX,
                        ViewRectangle.Y + deltaY,
                        ViewRectangle.Width, ViewRectangle.Height);
                    pictureBox.Invalidate();
                }
            } else if (ActiveMode == Mode.PAN) {
                // Same as for KeyPanning
                if (e.Button == MouseButtons.Left) {
                    float deltaX = (PanStart.X - e.X) * ZoomFactor;
                    float deltaY = (PanStart.Y - e.Y) * ZoomFactor;
                    // Reset PanStart
                    PanStart = e.Location;
                    ViewRectangle = new RectangleF(ViewRectangle.X + deltaX,
                        ViewRectangle.Y + deltaY,
                        ViewRectangle.Width, ViewRectangle.Height);
                    pictureBox.Invalidate();
                }
            } else if (ActiveMode == Mode.EDIT) {
                if (e.Button == MouseButtons.Left && HitPoint != null) {
                    Point imgPoint = imagePoint(e.Location);
                    HitPoint.Point = imgPoint;
                    redrawLines();
                    redrawOverlay();
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e) {
            //Debug.WriteLine("OnPictureBoxMouseWheel: ZoomFactor=" + ZoomFactor);
            ZoomFactor *= 1 + e.Delta * MOUSE_WHEEL_ZOOM_FACTOR;
            zoomImage();
        }

        private void OnPictureBoxPaint(object sender, PaintEventArgs e) {
            Debug.WriteLine("OnPictureBoxPaint: Image="
                + ((Image == null) ? "null" : Image.GetType().Name)
                + " LinesImage="
                + ((LinesImage == null) ? "null" : LinesImage.GetType().Name)
                + " OverlayImage="
                + ((OverlayImage == null) ? "null" : OverlayImage.GetType().Name));
            if (Image == null) return;
            Graphics g = e.Graphics;
            g.Clear(pictureBox.BackColor);
            g.DrawImage(Image, pictureBox.ClientRectangle, ViewRectangle,
                GraphicsUnit.Pixel);
            if (LinesImage != null) {
                g.DrawImage(LinesImage, pictureBox.ClientRectangle, ViewRectangle,
                    GraphicsUnit.Pixel);
            }
            // Handle EDIT mode
            if (ActiveMode == Mode.EDIT && OverlayImage != null) {
                g.DrawImage(OverlayImage, pictureBox.ClientRectangle, ViewRectangle,
                    GraphicsUnit.Pixel);
            }
        }

        private void OnOpenImageClick(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.tif;*.tiff;*.gif"
                + "|JPEG|*.jpg;*.jpeg;*.jpe"
                + "|PNG|*.png"
                + "|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = openFileDialog.FileName;
                try {
                    resetImage(fileName, true);
                    Properties.Settings.Default.LastImageFile = fileName;
                    Properties.Settings.Default.Save();
                } catch (Exception ex) {
                    Utils.excMsg("Error opening file:" + NL + fileName, ex);
                    return;
                }
                // Check if there is a calibration file with the same name
                string calibFileName = Path.ChangeExtension(fileName, ".calib");
                if (File.Exists(calibFileName)) {
                    DialogResult res = Utils.confirmMsg(
                        "There is a calibration file with the same name." + NL
                        + "Would you like to open it also?");
                    if (res == DialogResult.Yes) {
                        try {
                            MapCalibration = new MapCalibration();
                            MapCalibration.read(calibFileName);
                            redrawLines();
                            Properties.Settings.Default.LastCalibFile = calibFileName;
                            Properties.Settings.Default.Save();
                        } catch (Exception ex) {
                            Utils.excMsg("Error opening calib file:" + NL
                                + calibFileName, ex);
                            return;
                        }
                    }
                }
            }
        }

        private void OnCalibrationClick(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Calibration Files|*.calib"
                + "|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string calibFileName = openFileDialog.FileName;
                try {
                    MapCalibration = new MapCalibration();
                    MapCalibration.read(calibFileName);
                    redrawLines();
                    Properties.Settings.Default.LastCalibFile = calibFileName;
                    Properties.Settings.Default.Save();
                } catch (Exception ex) {
                    Utils.excMsg("Error opening file:" + NL + calibFileName, ex);
                    return;
                }
            }
        }

        private void OnOpenLinesClick(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Line Files|*.lines"
                + "|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = openFileDialog.FileName;
                try {
                    Lines.readLines(fileName);
                    redrawLines();
                } catch (Exception ex) {
                    Utils.excMsg("Error opening file:" + NL + fileName, ex);
                    return;
                }
            }
        }

        private void OnLinesFromGpxClick(object sender, EventArgs e) {
            if (MapCalibration == null) {
                Utils.errMsg("Calibration for converting lines is not available");
                return;
            }
            if (MapCalibration.Transform == null) {
                Utils.errMsg("Calibration for converting lines is not valid");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GPX Files|*.gpx"
                + "|All files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string[] fileNames = openFileDialog.FileNames;
                string curFileName = "<unknown>";
                int nTrkPoints = 0;
                try {
                    foreach (string fileName in fileNames) {
                        curFileName = fileName;
                        nTrkPoints += Lines.readGpxLines(fileName, MapCalibration);
                    }
                    redrawLines();
                    if (nTrkPoints == 0) {
                        Utils.warnMsg("No trackpoints were found");
                    }
                } catch (Exception ex) {
                    Utils.excMsg("Error opening file:" + NL + curFileName, ex);
                    return;
                }
            }
        }

        private void OnSaveLinesClick(object sender, EventArgs e) {
            if (Lines == null) return;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Lines|*.lines";
            dlg.Title = "Select lines file to write";
            dlg.CheckFileExists = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Lines.saveLines(dlg.FileName);
            }
        }

        private void OnSaveCsvClick(object sender, EventArgs e) {
            if (Lines == null) return;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV|*.csv";
            dlg.Title = "Select CSV file to write";
            dlg.CheckFileExists = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Lines.saveLinesCsv(dlg.FileName);
            }
        }

        private void OnSaveLinesPngClick(object sender, EventArgs e) {
            if (LinesImage == null) {
                Utils.errMsg("There is no lines image");
                return;
            }
            if (Lines == null) {
                Utils.warnMsg("There are no lines. Image will be blank.");
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG|*.png";
            dlg.Title = "Select the image file to write";
            dlg.CheckFileExists = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                try {
                    Bitmap bitmap = new Bitmap(Image.Width, Image.Height);
                    using (Graphics g = Graphics.FromImage(bitmap)) {
                        g.Clear(Color.Transparent);
                        // Can't use DrawImage(image, 0, 0) as it uses physical units
                        g.DrawImage(LinesImage,
                            new Rectangle(0, 0, Image.Width, Image.Height));
                    }
                    bitmap.Save(dlg.FileName, ImageFormat.Png);
                } catch (Exception ex) {
                    Utils.excMsg("Error saving lines image", ex);
                }
            }
        }

        private void OnSaveLinesPngImageClick(object sender, EventArgs e) {
            if (Image == null) {
                Utils.errMsg("There is no image");
                return;
            }
            if (Lines == null) {
                Utils.warnMsg("There are no lines.");
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG|*.png";
            dlg.Title = "Select the image file to write";
            dlg.CheckFileExists = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                try {
                    Bitmap bitmap = new Bitmap(Image.Width, Image.Height);
                    using (Graphics g = Graphics.FromImage(bitmap)) {
                        g.Clear(Color.Transparent);
                        g.DrawImage(Image,
                            new Rectangle(0, 0, Image.Width, Image.Height));
                        if (LinesImage != null) {
                            g.DrawImage(LinesImage,
                                new Rectangle(0, 0, Image.Width, Image.Height));
                        }
                    }
                    bitmap.Save(dlg.FileName, ImageFormat.Png);
                } catch (Exception ex) {
                    Utils.excMsg("Error saving lines image", ex);
                }
            }
        }

        private void OnSaveGpxClick(object sender, EventArgs e) {
            if (MapCalibration == null) {
                Utils.errMsg("Calibration for converting lines is not available");
                return;
            }
            if (MapCalibration.Transform == null) {
                Utils.errMsg("Calibration for converting lines is not valid");
                return;
            }
            if (Lines == null) {
                Utils.warnMsg("There are no lines.");
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "GPX|*.gpx";
            dlg.Title = "Select the GPX file to write";
            dlg.CheckFileExists = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                try {
                    Lines.writeGpxFile(dlg.FileName, MapCalibration);
                } catch (Exception ex) {
                    Utils.excMsg("Error saving lines image", ex);
                }
            }
        }

        private void OnExitClick(object sender, EventArgs e) {
            Close();
        }

        private void OnZoomClick(object sender, EventArgs e) {
            if (sender == toolStripMenuItem200) ZoomFactor = 0.5F;
            else if (sender == toolStripMenuItem100) ZoomFactor = 1.0F;
            else if (sender == toolStripMenuItem50) ZoomFactor = 2.0F;
            else if (sender == toolStripMenuItem25) ZoomFactor = 4.0F;
            zoomImage();
        }

        private void OnContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e) {
            panToolStripMenuItem.CheckState =
                 (ActiveMode == Mode.PAN) ? CheckState.Checked : CheckState.Unchecked;
            editToolStripMenuItem.CheckState =
                (ActiveMode == Mode.EDIT) ? CheckState.Checked : CheckState.Unchecked;
        }

        private void OnEditClick(object sender, EventArgs e) {
            if (ActiveMode != Mode.EDIT) {
                ActiveMode = Mode.EDIT;
            } else {
                ActiveMode = Mode.NORMAL;
                HitLine = null;
                HitPoint = null;
            }
            pictureBox.Invalidate();
            pictureBox.Cursor = Cursors.Default;
        }

        private void OnPanClick(object sender, EventArgs e) {
            if (ActiveMode != Mode.PAN) {
                ActiveMode = Mode.PAN;
                HitLine = null;
                HitPoint = null;
                pictureBox.Cursor = Cursors.Hand;
            } else {
                ActiveMode = Mode.NORMAL;
                pictureBox.Cursor = Cursors.Default;
            }
            pictureBox.Invalidate();
        }

        private void OnResetClick(object sender, EventArgs e) {
            resetImage();
        }


        private void OnHelpOverviewClick(object sender, EventArgs e) {
            // Create, show, or set visible the overview dialog as appropriate
            if (overviewDlg == null) {
                MainForm app = (MainForm)FindForm().FindForm();
                overviewDlg = new ScrolledHTMLDialog(
                    Utils.getDpiAdjustedSize(app, new Size(800, 600)),
                    "Overview", @"Help\Overview.html");
                overviewDlg.Show();
            } else {
                overviewDlg.Visible = true;
            }
        }

        private void OnHelpAboutClick(object sender, EventArgs e) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Image image = null;
            //try {
            //    image = Image.FromFile(@".\Help\GPXViewer256.png");
            //} catch (Exception ex) {
            //    Utils.excMsg("Failed to get AboutBox image", ex);
            //}
            AboutBox dlg = new AboutBox(image, assembly);
            dlg.ShowDialog();
        }

        private void OnStartLineClick(object sender, EventArgs e) {
            startLine();
        }

        private void OnEndLineClick(object sender, EventArgs e) {
            endLine();
        }

        private void OnDeleteLastPointClick(object sender, EventArgs e) {
            deleteLastPoint();
        }

        private void OnClearLinesClick(object sender, EventArgs e) {
            clearLines();
        }

        private void OnCalibrationLinesClick(object sender, EventArgs e) {
            calibrationLines();
        }
        #endregion

        private void OnEditLinesClick(object sender, EventArgs e) {
            if (Lines == null) {
                Utils.errMsg("There are no lines defined.");
                return;
            }
            EditLinesDialog dlg = new EditLinesDialog(this, Lines.LinesList);
            dlg.Show();
            Lines.LinesList = dlg.LinesList;
        }
    }

    public class HitPoint {
        public Point Point {
            get {
                Point point;
                try {
                    point = Line.Points[Index];
                    return point;
                } catch (Exception ex) {
                    Utils.excMsg("HitPoint Error getting Point", ex);
                    return MainForm.INVALID_POINT;
                }
            }
            set {
                try {
                    Line.Points[Index] = value;
                } catch (Exception ex) {
                    Utils.excMsg("HitPoint Setting getting Point", ex);
                }
            }
        }
        public Line Line { get; set; }
        public int Index { get; set; }

        public HitPoint(Line line, int index) {
            Line = line;
            Index = index;
        }
    }
}
