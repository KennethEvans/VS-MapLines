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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            openLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            linesFromGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            linesFromGPXFileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            saveLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveLinesAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveGPXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveLinesAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveLinesWithImageAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overviewOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelImage = new System.Windows.Forms.Panel();
            pictureBox = new System.Windows.Forms.PictureBox();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem200 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            startLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            endLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteLastPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            calibrationLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanelTop.SuspendLayout();
            menuStrip.SuspendLayout();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelTop.ColumnCount = 1;
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTop.Controls.Add(menuStrip, 0, 0);
            tableLayoutPanelTop.Controls.Add(panelImage, 0, 1);
            tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 2;
            tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanelTop.Size = new System.Drawing.Size(1968, 1412);
            tableLayoutPanelTop.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, linesToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            menuStrip.Size = new System.Drawing.Size(1968, 54);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openImageToolStripMenuItem, openCalibrationToolStripMenuItem, toolStripSeparator3, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(87, 48);
            fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            openImageToolStripMenuItem.Text = "Open Image...";
            openImageToolStripMenuItem.Click += OnOpenImageClick;
            // 
            // openCalibrationToolStripMenuItem
            // 
            openCalibrationToolStripMenuItem.Name = "openCalibrationToolStripMenuItem";
            openCalibrationToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            openCalibrationToolStripMenuItem.Text = "Open Calibration...";
            openCalibrationToolStripMenuItem.Click += OnCalibrationClick;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(427, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += OnExitClick;
            // 
            // linesToolStripMenuItem
            // 
            linesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { editLinesToolStripMenuItem, toolStripSeparator7, openLinesToolStripMenuItem, linesFromGPXToolStripMenuItem, linesFromGPXFileSetToolStripMenuItem, toolStripSeparator6, saveLinesToolStripMenuItem, saveLinesAsCSVToolStripMenuItem, saveGPXToolStripMenuItem, saveLinesAsPNGToolStripMenuItem, saveLinesWithImageAsPNGToolStripMenuItem });
            linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            linesToolStripMenuItem.Size = new System.Drawing.Size(109, 48);
            linesToolStripMenuItem.Text = "Lines";
            // 
            // editLinesToolStripMenuItem
            // 
            editLinesToolStripMenuItem.Name = "editLinesToolStripMenuItem";
            editLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            editLinesToolStripMenuItem.Text = "Edit Lines...";
            editLinesToolStripMenuItem.Click += OnEditLinesClick;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(597, 6);
            // 
            // openLinesToolStripMenuItem
            // 
            openLinesToolStripMenuItem.Name = "openLinesToolStripMenuItem";
            openLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            openLinesToolStripMenuItem.Text = "Open Lines...";
            openLinesToolStripMenuItem.Click += OnOpenLinesClick;
            // 
            // linesFromGPXToolStripMenuItem
            // 
            linesFromGPXToolStripMenuItem.Name = "linesFromGPXToolStripMenuItem";
            linesFromGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            linesFromGPXToolStripMenuItem.Text = "Lines from GPX...";
            linesFromGPXToolStripMenuItem.Click += OnLinesFromGpxClick;
            // 
            // linesFromGPXFileSetToolStripMenuItem
            // 
            linesFromGPXFileSetToolStripMenuItem.Name = "linesFromGPXFileSetToolStripMenuItem";
            linesFromGPXFileSetToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            linesFromGPXFileSetToolStripMenuItem.Text = "Lines from GPX File Set...";
            linesFromGPXFileSetToolStripMenuItem.Click += OnLinesFromGpxFileSetClick;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(597, 6);
            // 
            // saveLinesToolStripMenuItem
            // 
            saveLinesToolStripMenuItem.Name = "saveLinesToolStripMenuItem";
            saveLinesToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            saveLinesToolStripMenuItem.Text = "Save Lines...";
            saveLinesToolStripMenuItem.Click += OnSaveLinesClick;
            // 
            // saveLinesAsCSVToolStripMenuItem
            // 
            saveLinesAsCSVToolStripMenuItem.Name = "saveLinesAsCSVToolStripMenuItem";
            saveLinesAsCSVToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            saveLinesAsCSVToolStripMenuItem.Text = "Save Lines as CSV";
            saveLinesAsCSVToolStripMenuItem.Click += OnSaveCsvClick;
            // 
            // saveGPXToolStripMenuItem
            // 
            saveGPXToolStripMenuItem.Name = "saveGPXToolStripMenuItem";
            saveGPXToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            saveGPXToolStripMenuItem.Text = "Save Lines as GPX...";
            saveGPXToolStripMenuItem.Click += OnSaveGpxClick;
            // 
            // saveLinesAsPNGToolStripMenuItem
            // 
            saveLinesAsPNGToolStripMenuItem.Name = "saveLinesAsPNGToolStripMenuItem";
            saveLinesAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            saveLinesAsPNGToolStripMenuItem.Text = "Save Lines as PNG...";
            saveLinesAsPNGToolStripMenuItem.Click += OnSaveLinesPngClick;
            // 
            // saveLinesWithImageAsPNGToolStripMenuItem
            // 
            saveLinesWithImageAsPNGToolStripMenuItem.Name = "saveLinesWithImageAsPNGToolStripMenuItem";
            saveLinesWithImageAsPNGToolStripMenuItem.Size = new System.Drawing.Size(600, 54);
            saveLinesWithImageAsPNGToolStripMenuItem.Text = "Save Lines with Image as PNG...";
            saveLinesWithImageAsPNGToolStripMenuItem.Click += OnSaveLinesPngImageClick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { overviewToolStripMenuItem, overviewOnlineToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(104, 48);
            helpToolStripMenuItem.Text = "Help";
            // 
            // overviewToolStripMenuItem
            // 
            overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            overviewToolStripMenuItem.Size = new System.Drawing.Size(422, 54);
            overviewToolStripMenuItem.Text = "Overview";
            overviewToolStripMenuItem.Click += OnHelpOverviewClick;
            // 
            // overviewOnlineToolStripMenuItem
            // 
            overviewOnlineToolStripMenuItem.Name = "overviewOnlineToolStripMenuItem";
            overviewOnlineToolStripMenuItem.Size = new System.Drawing.Size(422, 54);
            overviewOnlineToolStripMenuItem.Text = "Overview Online...";
            overviewOnlineToolStripMenuItem.Click += OnHelpOverviewOnlineClick;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(422, 54);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += OnHelpAboutClick;
            // 
            // panelImage
            // 
            panelImage.AutoScroll = true;
            panelImage.Controls.Add(pictureBox);
            panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            panelImage.Location = new System.Drawing.Point(3, 58);
            panelImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelImage.Name = "panelImage";
            panelImage.Size = new System.Drawing.Size(1962, 1350);
            panelImage.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = System.Drawing.SystemColors.Control;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(1962, 1350);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += OnPictureBoxPaint;
            pictureBox.MouseDown += OnPictureBoxMouseDown;
            pictureBox.MouseMove += OnPictureBoxMouseMove;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { zoomToolStripMenuItem, editToolStripMenuItem, panToolStripMenuItem, resetToolStripMenuItem, toolStripSeparator5, startLineToolStripMenuItem, endLineToolStripMenuItem, deleteLastPointToolStripMenuItem, clearLinesToolStripMenuItem, toolStripSeparator4, calibrationLinesToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.ShowCheckMargin = true;
            contextMenuStrip.ShowImageMargin = false;
            contextMenuStrip.Size = new System.Drawing.Size(319, 448);
            contextMenuStrip.Opening += OnContextMenuOpening;
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem200, toolStripMenuItem100, toolStripMenuItem50, toolStripMenuItem25 });
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            zoomToolStripMenuItem.Text = "Zoom";
            // 
            // toolStripMenuItem200
            // 
            toolStripMenuItem200.Name = "toolStripMenuItem200";
            toolStripMenuItem200.Size = new System.Drawing.Size(257, 54);
            toolStripMenuItem200.Text = "200%";
            toolStripMenuItem200.Click += OnZoomClick;
            // 
            // toolStripMenuItem100
            // 
            toolStripMenuItem100.Name = "toolStripMenuItem100";
            toolStripMenuItem100.Size = new System.Drawing.Size(257, 54);
            toolStripMenuItem100.Text = "100%";
            toolStripMenuItem100.Click += OnZoomClick;
            // 
            // toolStripMenuItem50
            // 
            toolStripMenuItem50.Name = "toolStripMenuItem50";
            toolStripMenuItem50.Size = new System.Drawing.Size(257, 54);
            toolStripMenuItem50.Text = "50%";
            toolStripMenuItem50.Click += OnZoomClick;
            // 
            // toolStripMenuItem25
            // 
            toolStripMenuItem25.Name = "toolStripMenuItem25";
            toolStripMenuItem25.Size = new System.Drawing.Size(257, 54);
            toolStripMenuItem25.Text = "25%";
            toolStripMenuItem25.Click += OnZoomClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += OnEditClick;
            // 
            // panToolStripMenuItem
            // 
            panToolStripMenuItem.Name = "panToolStripMenuItem";
            panToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            panToolStripMenuItem.Text = "Pan";
            panToolStripMenuItem.Click += OnPanClick;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += OnResetClick;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(315, 6);
            // 
            // startLineToolStripMenuItem
            // 
            startLineToolStripMenuItem.Name = "startLineToolStripMenuItem";
            startLineToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            startLineToolStripMenuItem.Text = "Start Line";
            startLineToolStripMenuItem.Click += OnStartLineClick;
            // 
            // endLineToolStripMenuItem
            // 
            endLineToolStripMenuItem.Name = "endLineToolStripMenuItem";
            endLineToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            endLineToolStripMenuItem.Text = "End Line";
            endLineToolStripMenuItem.Click += OnEndLineClick;
            // 
            // deleteLastPointToolStripMenuItem
            // 
            deleteLastPointToolStripMenuItem.Name = "deleteLastPointToolStripMenuItem";
            deleteLastPointToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            deleteLastPointToolStripMenuItem.Text = "Delete Last Point";
            deleteLastPointToolStripMenuItem.Click += OnDeleteLastPointClick;
            // 
            // clearLinesToolStripMenuItem
            // 
            clearLinesToolStripMenuItem.Name = "clearLinesToolStripMenuItem";
            clearLinesToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            clearLinesToolStripMenuItem.Text = "Clear Lines";
            clearLinesToolStripMenuItem.Click += OnClearLinesClick;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(315, 6);
            // 
            // calibrationLinesToolStripMenuItem
            // 
            calibrationLinesToolStripMenuItem.Name = "calibrationLinesToolStripMenuItem";
            calibrationLinesToolStripMenuItem.Size = new System.Drawing.Size(318, 48);
            calibrationLinesToolStripMenuItem.Text = "Calibration Lines";
            calibrationLinesToolStripMenuItem.Click += OnCalibrationLinesClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1968, 1412);
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(tableLayoutPanelTop);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Map Lines";
            Load += OnFormLoad;
            Shown += OnFormShown;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            Resize += OnFormResize;
            tableLayoutPanelTop.ResumeLayout(false);
            tableLayoutPanelTop.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesFromGPXFileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewOnlineToolStripMenuItem;
    }
}

