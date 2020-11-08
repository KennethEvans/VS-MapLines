namespace Map_Lines {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.linesFromGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesWithImageAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelTop.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 1;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.panelImage, 0, 1);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1885, 1337);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1885, 49);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openCalibrationToolStripMenuItem,
            this.openLinesToolStripMenuItem,
            this.toolStripSeparator2,
            this.linesFromGPXToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveLinesToolStripMenuItem,
            this.saveLinesAsPNGToolStripMenuItem,
            this.saveLinesWithImageAsPNGToolStripMenuItem,
            this.saveGPXToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 45);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.openImageToolStripMenuItem.Text = "Open Image...";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.OnOpenImageClick);
            // 
            // openCalibrationToolStripMenuItem
            // 
            this.openCalibrationToolStripMenuItem.Name = "openCalibrationToolStripMenuItem";
            this.openCalibrationToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.openCalibrationToolStripMenuItem.Text = "Open Calibration...";
            this.openCalibrationToolStripMenuItem.Click += new System.EventHandler(this.OnCalibrationClick);
            // 
            // openLinesToolStripMenuItem
            // 
            this.openLinesToolStripMenuItem.Name = "openLinesToolStripMenuItem";
            this.openLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.openLinesToolStripMenuItem.Text = "Open Lines...";
            this.openLinesToolStripMenuItem.Click += new System.EventHandler(this.OnLinesClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(597, 6);
            // 
            // linesFromGPXToolStripMenuItem
            // 
            this.linesFromGPXToolStripMenuItem.Name = "linesFromGPXToolStripMenuItem";
            this.linesFromGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.linesFromGPXToolStripMenuItem.Text = "Lines from GPX...";
            this.linesFromGPXToolStripMenuItem.Click += new System.EventHandler(this.OnLinesFromGpxClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(597, 6);
            // 
            // saveLinesToolStripMenuItem
            // 
            this.saveLinesToolStripMenuItem.Name = "saveLinesToolStripMenuItem";
            this.saveLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesToolStripMenuItem.Text = "Save Lines...";
            this.saveLinesToolStripMenuItem.Click += new System.EventHandler(this.OnSaveLinesClick);
            // 
            // saveLinesAsPNGToolStripMenuItem
            // 
            this.saveLinesAsPNGToolStripMenuItem.Name = "saveLinesAsPNGToolStripMenuItem";
            this.saveLinesAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesAsPNGToolStripMenuItem.Text = "Save Lines as PNG...";
            this.saveLinesAsPNGToolStripMenuItem.Click += new System.EventHandler(this.OnLaveLinesPngClick);
            // 
            // saveLinesWithImageAsPNGToolStripMenuItem
            // 
            this.saveLinesWithImageAsPNGToolStripMenuItem.Name = "saveLinesWithImageAsPNGToolStripMenuItem";
            this.saveLinesWithImageAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesWithImageAsPNGToolStripMenuItem.Text = "Save Lines with Image as PNG...";
            this.saveLinesWithImageAsPNGToolStripMenuItem.Click += new System.EventHandler(this.OnLaveLinesPngImageClick);
            // 
            // saveGPXToolStripMenuItem
            // 
            this.saveGPXToolStripMenuItem.Name = "saveGPXToolStripMenuItem";
            this.saveGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveGPXToolStripMenuItem.Text = "Save GPX...";
            this.saveGPXToolStripMenuItem.Click += new System.EventHandler(this.OnSaveGpxClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(597, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // panelImage
            // 
            this.panelImage.AutoScroll = true;
            this.panelImage.Controls.Add(this.pictureBox);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(3, 52);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(1879, 1282);
            this.panelImage.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1879, 1282);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.panToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(176, 100);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem200,
            this.toolStripMenuItem100,
            this.toolStripMenuItem50,
            this.toolStripMenuItem25});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(175, 48);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // toolStripMenuItem200
            // 
            this.toolStripMenuItem200.Name = "toolStripMenuItem200";
            this.toolStripMenuItem200.Size = new System.Drawing.Size(257, 54);
            this.toolStripMenuItem200.Text = "200%";
            this.toolStripMenuItem200.Click += new System.EventHandler(this.OnZoomClick);
            // 
            // toolStripMenuItem100
            // 
            this.toolStripMenuItem100.Name = "toolStripMenuItem100";
            this.toolStripMenuItem100.Size = new System.Drawing.Size(257, 54);
            this.toolStripMenuItem100.Text = "100%";
            this.toolStripMenuItem100.Click += new System.EventHandler(this.OnZoomClick);
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(257, 54);
            this.toolStripMenuItem50.Text = "50%";
            this.toolStripMenuItem50.Click += new System.EventHandler(this.OnZoomClick);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(257, 54);
            this.toolStripMenuItem25.Text = "25%";
            this.toolStripMenuItem25.Click += new System.EventHandler(this.OnZoomClick);
            // 
            // panToolStripMenuItem
            // 
            this.panToolStripMenuItem.Name = "panToolStripMenuItem";
            this.panToolStripMenuItem.Size = new System.Drawing.Size(175, 48);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.OnPanClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1885, 1337);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanelTop);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Map Lines";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelImage.ResumeLayout(false);
            this.panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem linesFromGPXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesWithImageAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGPXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
    }
}

