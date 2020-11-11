using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MapLines {

    public partial class EditLinesDialog : Form {
        public List<Line> LinesList;
        public List<Line> SelectedList { get; set; }
        public MainForm MainForm { get;  }
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
        }

        private void onColorClick(object sender, System.EventArgs e) {
        }

        private void onUpClick(object sender, System.EventArgs e) {
        }

        private void onDownClick(object sender, System.EventArgs e) {
        }

        private void onRenumberClick(object sender, System.EventArgs e) {
        }

        private void onRefreshClick(object sender, System.EventArgs e) {
        }

        private void onDeselectAllClick(object sender, System.EventArgs e) {
        }
    }
}
