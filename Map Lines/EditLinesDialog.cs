using KEUtils.InputDialog;
using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapLines {

    public partial class EditLinesDialog : Form {
        public List<Line> LinesList;
        public List<Line> SelectedList { get; set; }
        public MainForm MainForm { get; }
        public SelectionMode SelectionMode {
            get {
                return listBox.SelectionMode;
            }
            set {
                listBox.SelectionMode = value;
            }
        }
        public int SelectedIndex {
            get {
                return listBox.SelectedIndex;
            }
            set {
                listBox.SelectedIndex = value;
            }
        }
        public string Prompt {
            get {
                return labelMsg.Text;
            }
            set {
                labelMsg.Text = value;
            }
        }

        public EditLinesDialog(MainForm mainForm, List<Line> newList) {
            MainForm = mainForm;
            LinesList = new List<Line>();
            foreach (Line item in newList) {
                if (item != null) this.LinesList.Add(item);
            }
            LinesList = newList;

            InitializeComponent();
            populateList();
        }

        private void populateList() {
            listBox.DataSource = null;
            List<Line> items = new List<Line>();
            foreach (Line name in LinesList) {
                items.Add(name);
            }
            listBox.DataSource = items;
        }

        private void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.A) {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                    for (int i = 0; i < listBox.Items.Count; i++) {
                        listBox.SetSelected(i, true);
                    }
                }
            } else if (e.KeyCode == Keys.D) {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                    for (int i = 0; i < listBox.Items.Count; i++) {
                        listBox.SetSelected(i, false);
                    }
                }
            }
        }

        private void onOkClick(object sender, System.EventArgs e) {
            SelectedList = new List<Line>();
            foreach (Line item in listBox.SelectedItems) {
                SelectedList.Add(item);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void onCancelClick(object sender, System.EventArgs e) {
            SelectedList = null;
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void onDeleteClick(object sender, System.EventArgs e) {
            try {
                foreach (Line item in listBox.SelectedItems) {
                    LinesList.Remove(item);
                }
                populateList();
                MainForm.redrawLines();
            } catch (Exception ex) {
                Utils.excMsg("Problem removing items", ex);
            }
        }

        private void onRenameClick(object sender, System.EventArgs e) {
            try {
                foreach (Line line in listBox.SelectedItems) {
                    InputDialog dlg = new InputDialog("Rename",
                    "Enter a new name for " + line.Desc, line.Desc);
                    DialogResult res = dlg.ShowDialog();
                    if (res == DialogResult.OK) {
                        string val = dlg.Value;
                        if (val != null) {
                            line.Desc = val;
                        }
                    }
                }
                populateList();
                MainForm.redrawLines();
            } catch (Exception ex) {
                Utils.excMsg("Problem renaming", ex);
            }
        }

        private void onColorClick(object sender, System.EventArgs e) {
            try {
                foreach (Line line in listBox.SelectedItems) {
                    ColorDialog dlg = new ColorDialog();
                    DialogResult res = dlg.ShowDialog();
                    if (res == DialogResult.OK) {
                        line.Color = dlg.Color;
                    }
                }
                populateList();
                MainForm.redrawLines();
            } catch (Exception ex) {
                Utils.excMsg("Problem renaming", ex);
            }
        }

        private void onUpClick(object sender, System.EventArgs e) {
            if (listBox.SelectedItems.Count == 0) {
                Utils.errMsg("No items selected");
                return;
            }
            List<int> selectedIndices = new List<int>();
            Line line;
            for (int i = 0; i < listBox.SelectedItems.Count; i++) {
                line = (Line)listBox.SelectedItems[i];
                selectedIndices.Add(LinesList.IndexOf(line));
            }
            selectedIndices.Sort();
            int nSelected = selectedIndices.Count;
            int minIndex = selectedIndices[0];
            if (minIndex == 0) {
                Utils.errMsg("Already at the top");
                return;
            }
            List<Line> movedLines = new List<Line>();
            // Remove them in reverse order to preserve the correct indices
            int idx;
            for (int i = 0; i < nSelected; i++) {
                idx = selectedIndices[nSelected - 1 - i];
                movedLines.Insert(0, LinesList[idx]);
                LinesList.RemoveAt(idx);
            }
            LinesList.InsertRange(minIndex - 1, movedLines);
            populateList();
            // Reselect the moved ones (Are in minIndex - 1  to minIndex + nSelected - 2)
            for (int i = 0; i < listBox.Items.Count; i++) {
                if (i >= (minIndex - 1) && i < minIndex + nSelected - 1) {
                    listBox.SetSelected(i, true);
                } else {
                    listBox.SetSelected(i, false);
                }
            }
        }

        private void onDownClick(object sender, System.EventArgs e) {
            if (listBox.SelectedItems.Count == 0) {
                Utils.errMsg("No items selected");
                return;
            }
            List<int> selectedIndices = new List<int>();
            Line line;
            for (int i = 0; i < listBox.SelectedItems.Count; i++) {
                line = (Line)listBox.SelectedItems[i];
                selectedIndices.Add(LinesList.IndexOf(line));
            }
            selectedIndices.Sort();
            int nSelected = selectedIndices.Count;
            int minIndex = selectedIndices[0];
            int maxIndex = selectedIndices[nSelected - 1];
            if (maxIndex == LinesList.Count - 1) {
                Utils.errMsg("Already at the bottom");
                return;
            }
            List<Line> movedLines = new List<Line>();
            // Remove them in reverse order to preserve the correct indices
            int idx;
            for (int i = 0; i < selectedIndices.Count; i++) {
                idx = selectedIndices[nSelected - 1 - i];
                movedLines.Insert(0, LinesList[idx]);
                LinesList.RemoveAt(idx);
            }
            LinesList.InsertRange(minIndex + 1, movedLines);
            populateList();
            // Reselect the moved ones (Are in minIndex + 1  to minIndex + nSelected - 2)
            for (int i = 0; i < listBox.Items.Count; i++) {
                if (i >= (minIndex + 1) && i <= minIndex + nSelected) {
                    listBox.SetSelected(i, true);
                } else {
                    listBox.SetSelected(i, false);
                }
            }
        }

        private void onRenumberClick(object sender, System.EventArgs e) {
            if (listBox.SelectedItems.Count == 0) {
                Utils.errMsg("No items selected for renumbering");
                return;
            }
            int n = 0;
            try {
                foreach (Line line in listBox.SelectedItems) {
                    line.Desc = "Line " + n++;
                }
                populateList();
                MainForm.redrawLines();
            } catch (Exception ex) {
                Utils.excMsg("Problem renaming", ex);
            }
        }

        private void onRefreshClick(object sender, System.EventArgs e) {
            if (MainForm == null || MainForm.Lines == null ||
                MainForm.Lines.LinesList == null) {
                Utils.errMsg("Unable to access lines in the application");
                return;
            }
            LinesList = new List<Line>();
            foreach (Line item in MainForm.Lines.LinesList) {
                if (item != null) this.LinesList.Add(item);
            }
            populateList();
        }
    }
}
