using KEUtils.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Map_Lines {
    public partial class MainForm : Form {
        public static readonly String NL = Environment.NewLine;
        public static readonly float MOUSE_WHEEL_ZOOM_FACTOR = 0.001F;
        public static readonly float KEY_ZOOM_FACTOR = 1.1F;
        public static readonly float ZOOM_MIN = 0.1F;

        public Image Image { get; set; }
        public bool Panning { get; set; }
        public bool KeyPanning { get; set; }
        public Point PanStart { get; set; }
        float ZoomFactor { get; set; }
        public RectangleF ViewRectangle { get; set; }

        public MainForm() {
            InitializeComponent();

            ZoomFactor = 1.0F;
            pictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
            this.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
        }

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
            }
            ZoomFactor = 1.0F;
            Size clientSize = pictureBox.ClientSize;
            ViewRectangle = new RectangleF(0, 0, clientSize.Width, clientSize.Height);
            //ViewImage = new Bitmap(clientSize.Width, clientSize.Height);
            //pictureBox.Image = ViewImage;
            pictureBox.Invalidate();
        }

        private void OnFormLoad(object sender, EventArgs e) {

        }

        private void OnFormShown(object sender, EventArgs e) {
            // Load initial image
            string fileName = @"C:\Users\evans\Documents\Map Lines\Proud Lake\Proud Lake Hiking-Biking-Bridle Trails Map.png";
            resetImage(fileName, true);
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

            //openFileDialog.InitialDirectory = "c:\\GIF";
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
                //refresh();
            }
        }

        private void OnCalibrationClick(object sender, EventArgs e) {

        }

        private void OnLinesClick(object sender, EventArgs e) {

        }

        private void OnLinesFromGpxClick(object sender, EventArgs e) {

        }

        private void OnSaveLinesClick(object sender, EventArgs e) {

        }

        private void OnLaveLinesPngClick(object sender, EventArgs e) {

        }

        private void OnLaveLinesPngImageClick(object sender, EventArgs e) {

        }

        private void OnSaveGpxClick(object sender, EventArgs e) {

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
        }
    }
}
