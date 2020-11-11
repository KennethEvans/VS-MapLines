#define USE_STARTUP_FILE

using KEUtils.About;
using KEUtils.InputDialog;
using KEUtils.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static MapLines.MapCalibration;

namespace MapLines {
    public partial class MainForm : Form {
        public static readonly String NL = Environment.NewLine;
        public static readonly float MOUSE_WHEEL_ZOOM_FACTOR = 0.001F;
        public static readonly float KEY_ZOOM_FACTOR = 1.1F;
        public static readonly float ZOOM_MIN = 0.1F;
        public static readonly float LINE_WIDTH = 4;

        public Image Image { get; set; }
        public Image LinesImage { get; set; }
        public bool Panning { get; set; }
        public bool KeyPanning { get; set; }
        public Point PanStart { get; set; }
        float ZoomFactor { get; set; }
        public RectangleF ViewRectangle { get; set; }

        public Lines Lines { get; set; } = new Lines();
        public Line CurLine { get; set; }
        public int NextLineNumber { get; set; }
        public MapCalibration MapCalibration { get; set; }

        public MainForm() {
            InitializeComponent();

            ZoomFactor = 1.0F;
            pictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
            this.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
        }

        #region Image Manipulation

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
        #endregion

        #region Lines
        /**
         * Starts a new line.
         */
        public void startLine() {
            if (Lines == null || LinesImage == null) {
                return;
            }
            Line line = new Line();
            CurLine = line;
            line.Desc = "Line " + NextLineNumber++;
            Lines.addLine(line);
            // // Prompt for the description
            // InputDialog dlg = new InputDialog(null, "Description",
            // "Enter a description:", "Line " + NextLineNumber, null);
            // dlg.setBlockOnOpen(true);
            // int res = dlg.open();
            // if(res == Dialog.OK) {
            // String val = dlg.getValue();
            // if(val != null) {
            // line.setDesc(val);
            // NextLineNumber++;
            // }
            // }

            // // DEBUG
            // System.out.println("startLine");
            // System.out.println("curLine=" + CurLine);
            // System.out.println(Lines.info());
        }

        /**
         * Clears the Lines.
         */
        public void clearLines() {
            endLine();
            Lines.clear();
            redrawLines();
            // // DEBUG
            // System.out.println("endLine");
            // System.out.println("curLine=" + CurLine);
            // System.out.println(Lines.info());
        }

        /**
         * Makes Lines corresponding to the calibration points.
         */
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
            Line line = new Line();
            Lines.addLine(line);
            CurLine = line;
            foreach (MapData data in MapCalibration.DataList) {
                line.addPoint(new Point(data.X, data.Y));
            }
            // Connect to the beginning
            if (MapCalibration.DataList.Count > 1) {
                MapData data = MapCalibration.DataList[0];
                line.addPoint(new Point(data.X, data.Y));
            }

#if false
// Prompt for the description
            InputDialog dlg = new InputDialog("Description", "Enter a description:");
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK) {
                string val = dlg.Value;
                if (val != null) {
                    line.Desc = val;
                    NextLineNumber++;
                }
            }
#else
            line.Desc = "Calibration Lines";
#endif
            redrawLines();
        }

        /**
         * Deletes the current line.
         */
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
            // // DEBUG
            // System.out.println("endLine");
            // System.out.println("curLine=" + viewer.getCurLine());
            // System.out.println(Lines.info());
        }

        /**
         * Ends a line line.
         */
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

        public void redrawLines() {
            if (Lines == null) return;
            if (LinesImage == null) return;
            Graphics g = Graphics.FromImage(LinesImage);
            g.Clear(Color.Transparent);
            Point[] points;
            foreach (Line line in Lines.LinesList) {
                using (Pen pen = new Pen(line.Color, LINE_WIDTH)) {
                    if (line.Points == null || line.Points.Count < 2) continue;
                    points = line.Points.ToArray();
                    g.DrawLines(pen, points);
                }
            }
            pictureBox.Invalidate();
        }

        #endregion

        #region Event Handlers
        private void OnFormLoad(object sender, EventArgs e) {

        }

        private void OnFormShown(object sender, EventArgs e) {
#if USE_STARTUP_FILE
            // Load initial image
            string fileName = @"C:\Users\evans\Documents\Map Lines\Proud Lake\Proud Lake Hiking-Biking-Bridle Trails Map.png";
            resetImage(fileName, true);
            // Load the calibration
            string calibFileName = Path.ChangeExtension(fileName, ".calib");
            try {
                MapCalibration = new MapCalibration();
                MapCalibration.read(calibFileName);
            } catch (Exception ex) {
                Utils.excMsg("Error opening calib file:" + NL
                    + calibFileName, ex);
                return;
            }
#endif
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
                if (!Panning) {
                    Panning = true;
                    pictureBox.Cursor = Cursors.Hand;
                }
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
            if (KeyPanning) {
                Panning = false;
                pictureBox.Cursor = Cursors.Default;
            }
            KeyPanning = false;
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
                string fileName = openFileDialog.FileName;
                try {
                    MapCalibration = new MapCalibration();
                    MapCalibration.read(fileName);
                    redrawLines();
                } catch (Exception ex) {
                    Utils.excMsg("Error opening file:" + NL + fileName, ex);
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

        private void OnPanClick(object sender, EventArgs e) {
            Panning = !Panning;
            if (Panning) {
                pictureBox.Cursor = Cursors.Hand;
            } else {
                pictureBox.Cursor = Cursors.Default;
            }
        }

        private void OnResetClick(object sender, EventArgs e) {
            resetImage();
        }

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e) {
            if (Panning) PanStart = e.Location;
            else if (CurLine != null && e.Button == MouseButtons.Left) {
                CurLine.addPoint(imagePoint(new Point(e.X, e.Y)));
                redrawLines();
            }
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e) {
            if (Panning) {
                if (e.Button == MouseButtons.Left) {
                    float deltaX = PanStart.X - e.X;
                    float deltaY = PanStart.Y - e.Y;
                    // Reset PanStart
                    PanStart = e.Location;
                    ViewRectangle = new RectangleF(ViewRectangle.X + deltaX,
                        ViewRectangle.Y + deltaY,
                        ViewRectangle.Width, ViewRectangle.Height);
                    Debug.WriteLine("OnPictureBoxMouseMove:"
                        + NL + " e=(" + e.X + "," + e.Y + ")"
                        + NL + " PanStart=(" + PanStart.X + "," + PanStart.Y + ")"
                        + NL + " delta=(" + deltaX + "," + deltaY + ")"
                        + NL + "    ViewRectangle=" + ViewRectangle);
                    pictureBox.Invalidate();
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e) {
            Debug.WriteLine("OnPictureBoxMouseWheel: ZoomFactor=" + ZoomFactor);
            ZoomFactor *= 1 + e.Delta * MOUSE_WHEEL_ZOOM_FACTOR;
            zoomImage();
        }

        private void OnPictureBoxPaint(object sender, PaintEventArgs e) {
            if (Image == null) return;
            Graphics g = e.Graphics;
            g.Clear(pictureBox.BackColor);
            g.DrawImage(Image, pictureBox.ClientRectangle, ViewRectangle,
                GraphicsUnit.Pixel);
            if (LinesImage != null) {
                g.DrawImage(LinesImage, pictureBox.ClientRectangle, ViewRectangle,
                    GraphicsUnit.Pixel);
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
}
