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
        private Form1 frm;
        private string sql;

        public SelectDlg(string caption,Form1 frm,string sql,string idfield,string codefield,string showfield)
        {
            InitializeComponent();
            this.Text = caption;
            this.grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grid.DataSource = frm.getSqlData(sql);
            this.grid.AutoResizeColumns();
            this.frm = frm;
            this.sql = sql;
            this.idfield = idfield;
            this.codefield = codefield;
            this.showfield = showfield;
            this.ResumeLayout(false);

        }
        private string selectedid;
        private string selectedcode;
        private string selectedname;


        private void SelectDlg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择","提示");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (grid.SelectedRows[0].Cells[idfield].Value != null)
            {
                selectedid = grid.SelectedRows[0].Cells[idfield].Value.ToString();
                selectedcode = grid.SelectedRows[0].Cells[codefield].Value.ToString();
                selectedname = grid.SelectedRows[0].Cells[showfield].Value.ToString();
            }
        }

        public void setSelectID(string s)
        {
            selectedid = s;
        }

        public void setSelectCode(string s)
        {
            selectedcode = s;
        }

        public void setSelectName(string s)
        {
            selectedname = s;
        }

        public string getSelectID()
        {
            return selectedid;
        }

        public string getSelectCode()
        {
            return selectedcode;
        }

        public string getSelectName()
        {
            return selectedname;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.grid.DataSource = frm.getSqlData(sql);
            this.grid.AutoResizeColumns();
            this.ResumeLayout(false);
        }

    }
}
