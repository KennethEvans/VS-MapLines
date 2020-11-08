using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map_Lines {
    public partial class MainForm : Form {
        public static readonly String NL = Environment.NewLine;
        public static readonly double MOUSE_WHEEL_ZOOM_FACTOR = .001;
        public static readonly double ZOOM_MIN = .1;

        public Image OriginalImage { get; set; }
        public bool Panning { get; set; }
        public Point PanStart { get; set; }
        double ZoomFactor { get; set; }

        public MainForm() {
            InitializeComponent();

            ZoomFactor = 1.0;
            pictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
        }

        private void zoomImage() {
            Debug.WriteLine("zoomImage: ZoomFactor=" + ZoomFactor);
            if (OriginalImage == null) return;
            if (pictureBox.Image != null) pictureBox.Image.Dispose();
            Size newSize = new Size((int)(OriginalImage.Width * ZoomFactor),
                (int)(OriginalImage.Height * ZoomFactor));
            Debug.WriteLine("    newSize=" + newSize);
            Bitmap zoomImage = new Bitmap(OriginalImage, newSize);
            // This causes memory problems
            //Graphics g = Graphics.FromImage(zoomImage);
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pictureBox.Image = zoomImage;
        }

        private void OnFormLoad(object sender, EventArgs e) {
            this.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
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
                    if (OriginalImage != null) OriginalImage.Dispose();
                    if (pictureBox.Image != null) pictureBox.Image.Dispose();
                    OriginalImage = new Bitmap(fileName);
                    pictureBox.Image = (Image)OriginalImage.Clone();
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
            if (sender == toolStripMenuItem200) ZoomFactor = 2.0;
            else if (sender == toolStripMenuItem100) ZoomFactor = 1.0;
            else if (sender == toolStripMenuItem50) ZoomFactor = .5;
            else if (sender == toolStripMenuItem25) ZoomFactor = .25;
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

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e) {
            if (Panning) PanStart = new Point(e.X, e.Y);
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e) {
            if (Panning) {
                if (e.Button == MouseButtons.Left) {
                    int deltaX = PanStart.X - e.X;
                    int deltaY = PanStart.Y - e.Y;
                    panelImage.AutoScrollPosition = new Point(
                        deltaX - panelImage.AutoScrollPosition.X,
                        deltaY - panelImage.AutoScrollPosition.Y);
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e) {
            Debug.WriteLine("OnPictureBoxMouseWheel: ZoomFactor=" + ZoomFactor);
            if (!Panning) {
                ZoomFactor += e.Delta * MOUSE_WHEEL_ZOOM_FACTOR;
                if (ZoomFactor < ZOOM_MIN) ZoomFactor = ZOOM_MIN;
                zoomImage();
            }
        }
    }
}
