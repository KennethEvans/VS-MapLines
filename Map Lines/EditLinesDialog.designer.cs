namespace MapLines {
    partial class EditLinesDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLinesDialog));
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.labelMsg = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRenumber = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelTop.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSize = true;
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 1;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Controls.Add(this.labelMsg, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.listBox, 0, 1);
            this.tableLayoutPanelTop.Controls.Add(this.flowLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1293, 717);
            this.tableLayoutPanelTop.TabIndex = 1;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMsg.Location = new System.Drawing.Point(3, 0);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Padding = new System.Windows.Forms.Padding(25);
            this.labelMsg.Size = new System.Drawing.Size(1287, 82);
            this.labelMsg.TabIndex = 1;
            this.labelMsg.Text = "Edit the lines";
            this.toolTip.SetToolTip(this.labelMsg, resources.GetString("labelMsg.ToolTip"));
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 31;
            this.listBox.Location = new System.Drawing.Point(3, 85);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox.Size = new System.Drawing.Size(1287, 575);
            this.listBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.listBox, resources.GetString("listBox.ToolTip"));
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonDelete);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonRename);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonColor);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonUp);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonDown);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonRenumber);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonRefresh);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonOk);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(203, 666);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(886, 48);
            this.flowLayoutPanelButtons.TabIndex = 0;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDelete.Location = new System.Drawing.Point(3, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(108, 42);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.toolTip.SetToolTip(this.buttonDelete, "Deleted the selected lines.\r\n");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.onDeleteClick);
            // 
            // buttonRename
            // 
            this.buttonRename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRename.AutoSize = true;
            this.buttonRename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRename.Location = new System.Drawing.Point(117, 3);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(132, 42);
            this.buttonRename.TabIndex = 2;
            this.buttonRename.Text = "Rename";
            this.toolTip.SetToolTip(this.buttonRename, "Rename the selected lines.");
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.onRenameClick);
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonColor.AutoSize = true;
            this.buttonColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColor.Location = new System.Drawing.Point(255, 3);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(93, 42);
            this.buttonColor.TabIndex = 3;
            this.buttonColor.Text = "Color";
            this.toolTip.SetToolTip(this.buttonColor, "Selet the color for the selected lines.");
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.onColorClick);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUp.AutoSize = true;
            this.buttonUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonUp.Location = new System.Drawing.Point(354, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(61, 42);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "Up";
            this.toolTip.SetToolTip(this.buttonUp, "Move the selected lines up as a group.");
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.onUpClick);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDown.AutoSize = true;
            this.buttonDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDown.Location = new System.Drawing.Point(421, 3);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(97, 42);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "Down";
            this.toolTip.SetToolTip(this.buttonDown, "Move the selected lines down as a group.");
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.onDownClick);
            // 
            // buttonRenumber
            // 
            this.buttonRenumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRenumber.AutoSize = true;
            this.buttonRenumber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRenumber.Location = new System.Drawing.Point(524, 3);
            this.buttonRenumber.Name = "buttonRenumber";
            this.buttonRenumber.Size = new System.Drawing.Size(157, 42);
            this.buttonRenumber.TabIndex = 6;
            this.buttonRenumber.Text = "Renumber";
            this.toolTip.SetToolTip(this.buttonRenumber, "Renumber and rename the selected lines using\r\n the name \"Line n\" starting at n=1." +
        "");
            this.buttonRenumber.UseVisualStyleBackColor = true;
            this.buttonRenumber.Click += new System.EventHandler(this.onRenumberClick);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefresh.AutoSize = true;
            this.buttonRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefresh.Location = new System.Drawing.Point(687, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(124, 42);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.toolTip.SetToolTip(this.buttonRefresh, "Refresh the dialog with the current lines in the image\r\n.");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.onRefreshClick);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.Location = new System.Drawing.Point(817, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(66, 42);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.toolTip.SetToolTip(this.buttonOk, "Close the dialog.");
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.onOkClick);
            // 
            // EditLinesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 717);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Name = "EditLinesDialog";
            this.ShowIcon = false;
            this.Text = "Edit Lines";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonRenumber;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolTip toolTip;
    }
}