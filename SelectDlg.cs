using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Print
{
    public partial class SelectDlg : Form
    {
        private string idfield;
        private string codefield;
        private string showfield;

        public SelectDlg(string caption,object data,string idfield,string codefield,string showfield)
        {
            InitializeComponent();
            this.Text = caption;
            this.grid.DataSource = data;
            this.idfield = idfield;
            this.codefield = codefield;
            this.showfield = showfield;

        }

        private void SelectDlg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public string getSelectID()
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
                return null;
            if (grid.SelectedRows[0].Cells[idfield].Value == null)
                return null;
            return grid.SelectedRows[0].Cells[idfield].Value.ToString();
        }

        public string getSelectCode()
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
                return null;
            if (grid.SelectedRows[0].Cells[codefield].Value == null)
                return null;
            return grid.SelectedRows[0].Cells[codefield].Value.ToString();
        }

        public string getSelectName()
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
                return null;
            if (grid.SelectedRows[0].Cells[showfield].Value == null)
                return null;
            return grid.SelectedRows[0].Cells[showfield].Value.ToString();
        }


    }
}
