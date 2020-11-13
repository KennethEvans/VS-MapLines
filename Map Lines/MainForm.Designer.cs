namespace MapLines {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.openLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesFromGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesWithImageAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.startLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLastPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.calibrationLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinesAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1885, 1514);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1885, 52);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openCalibrationToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 48);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.openImageToolStripMenuItem.Text = "Open Image...";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.OnOpenImageClick);
            // 
            // openCalibrationToolStripMenuItem
            // 
            this.openCalibrationToolStripMenuItem.Name = "openCalibrationToolStripMenuItem";
            this.openCalibrationToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.openCalibrationToolStripMenuItem.Text = "Open Calibration...";
            this.openCalibrationToolStripMenuItem.Click += new System.EventHandler(this.OnCalibrationClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(427, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLinesToolStripMenuItem,
            this.toolStripSeparator7,
            this.openLinesToolStripMenuItem,
            this.linesFromGPXToolStripMenuItem,
            this.toolStripSeparator6,
            this.saveLinesToolStripMenuItem,
            this.saveLinesAsCSVToolStripMenuItem,
            this.saveGPXToolStripMenuItem,
            this.saveLinesAsPNGToolStripMenuItem,
            this.saveLinesWithImageAsPNGToolStripMenuItem});
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(109, 48);
            this.linesToolStripMenuItem.Text = "Lines";
            // 
            // editLinesToolStripMenuItem
            // 
            this.editLinesToolStripMenuItem.Name = "editLinesToolStripMenuItem";
            this.editLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.editLinesToolStripMenuItem.Text = "Edit Lines...";
            this.editLinesToolStripMenuItem.Click += new System.EventHandler(this.OnEditLinesClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(597, 6);
            // 
            // openLinesToolStripMenuItem
            // 
            this.openLinesToolStripMenuItem.Name = "openLinesToolStripMenuItem";
            this.openLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.openLinesToolStripMenuItem.Text = "Open Lines...";
            this.openLinesToolStripMenuItem.Click += new System.EventHandler(this.OnOpenLinesClick);
            // 
            // linesFromGPXToolStripMenuItem
            // 
            this.linesFromGPXToolStripMenuItem.Name = "linesFromGPXToolStripMenuItem";
            this.linesFromGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.linesFromGPXToolStripMenuItem.Text = "Lines from GPX...";
            this.linesFromGPXToolStripMenuItem.Click += new System.EventHandler(this.OnLinesFromGpxClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(597, 6);
            // 
            // saveLinesToolStripMenuItem
            // 
            this.saveLinesToolStripMenuItem.Name = "saveLinesToolStripMenuItem";
            this.saveLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesToolStripMenuItem.Text = "Save Lines...";
            this.saveLinesToolStripMenuItem.Click += new System.EventHandler(this.OnSaveLinesClick);
            // 
            // saveGPXToolStripMenuItem
            // 
            this.saveGPXToolStripMenuItem.Name = "saveGPXToolStripMenuItem";
            this.saveGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveGPXToolStripMenuItem.Text = "Save Lines as GPX...";
            this.saveGPXToolStripMenuItem.Click += new System.EventHandler(this.OnSaveGpxClick);
            // 
            // saveLinesAsPNGToolStripMenuItem
            // 
            this.saveLinesAsPNGToolStripMenuItem.Name = "saveLinesAsPNGToolStripMenuItem";
            this.saveLinesAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesAsPNGToolStripMenuItem.Text = "Save Lines as PNG...";
            this.saveLinesAsPNGToolStripMenuItem.Click += new System.EventHandler(this.OnSaveLinesPngClick);
            // 
            // saveLinesWithImageAsPNGToolStripMenuItem
            // 
            this.saveLinesWithImageAsPNGToolStripMenuItem.Name = "saveLinesWithImageAsPNGToolStripMenuItem";
            this.saveLinesWithImageAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesWithImageAsPNGToolStripMenuItem.Text = "Save Lines with Image as PNG...";
            this.saveLinesWithImageAsPNGToolStripMenuItem.Click += new System.EventHandler(this.OnSaveLinesPngImageClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overviewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(104, 48);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnHelpAboutClick);
            // 
            // panelImage
            // 
            this.panelImage.AutoScroll = true;
            this.panelImage.Controls.Add(this.pictureBox);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(3, 55);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(1879, 1456);
            this.panelImage.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1879, 1456);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPictureBoxPaint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.panToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator5,
            this.startLineToolStripMenuItem,
            this.endLineToolStripMenuItem,
            this.deleteLastPointToolStripMenuItem,
            this.clearLinesToolStripMenuItem,
            this.toolStripSeparator4,
            this.calibrationLinesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(319, 400);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem200,
            this.toolStripMenuItem100,
            this.toolStripMenuItem50,
            this.toolStripMenuItem25});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
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
            this.panToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.OnPanClick);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.OnResetClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(315, 6);
            // 
            // startLineToolStripMenuItem
            // 
            this.startLineToolStripMenuItem.Name = "startLineToolStripMenuItem";
            this.startLineToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.startLineToolStripMenuItem.Text = "Start Line";
            this.startLineToolStripMenuItem.Click += new System.EventHandler(this.OnStartLineClick);
            // 
            // endLineToolStripMenuItem
            // 
            this.endLineToolStripMenuItem.Name = "endLineToolStripMenuItem";
            this.endLineToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.endLineToolStripMenuItem.Text = "End Line";
            this.endLineToolStripMenuItem.Click += new System.EventHandler(this.OnEndLineClick);
            // 
            // deleteLastPointToolStripMenuItem
            // 
            this.deleteLastPointToolStripMenuItem.Name = "deleteLastPointToolStripMenuItem";
            this.deleteLastPointToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.deleteLastPointToolStripMenuItem.Text = "Delete Last Point";
            this.deleteLastPointToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteLastPointClick);
            // 
            // clearLinesToolStripMenuItem
            // 
            this.clearLinesToolStripMenuItem.Name = "clearLinesToolStripMenuItem";
            this.clearLinesToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.clearLinesToolStripMenuItem.Text = "Clear Lines";
            this.clearLinesToolStripMenuItem.Click += new System.EventHandler(this.OnClearLinesClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(315, 6);
            // 
            // calibrationLinesToolStripMenuItem
            // 
            this.calibrationLinesToolStripMenuItem.Name = "calibrationLinesToolStripMenuItem";
            this.calibrationLinesToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            this.calibrationLinesToolStripMenuItem.Text = "Calibration Lines";
            this.calibrationLinesToolStripMenuItem.Click += new System.EventHandler(this.OnCalibrationLinesClick);
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.overviewToolStripMenuItem.Text = "Overview";
            this.overviewToolStripMenuItem.Click += new System.EventHandler(this.OnHelpOverviewClick);
            // 
            // saveLinesAsCSVToolStripMenuItem
            // 
            this.saveLinesAsCSVToolStripMenuItem.Name = "saveLinesAsCSVToolStripMenuItem";
            this.saveLinesAsCSVToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            this.saveLinesAsCSVToolStripMenuItem.Text = "Save Lines as CSV";
            this.saveLinesAsCSVToolStripMenuItem.Click += new System.EventHandler(this.OnSaveCsvClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1885, 1514);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Map Lines";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.Resize += new System.EventHandler(this.OnFormResize);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelImage.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem startLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLastPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem calibrationLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem linesFromGPXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem saveLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesWithImageAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGPXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinesAsCSVToolStripMenuItem;
    }
}

