using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Print
{
    
    public partial class UC1 : UserControl
    {
        private SelectDlg dlg;
        private object data;
        public UC1()
        {
            InitializeComponent();
            tb1.GotFocus += new EventHandler(tb1_GotFocus);
            tb1.LostFocus += new EventHandler(tb1_LostFocus);
        }

        Form1 form;
        public void setParentForm(Form1 form)
        {
            this.form = form;
        }
        private string title;
        private string sql;
        private string idfield;
        private string codefield;
        private string namefield;

        public void setDbInfo(string s1,string s2,string s3,string s4,string s5)
        {
            title = s1;
            sql = s2;
            idfield = s3;
            codefield = s4;
            namefield = s5;
        }

        void tb1_LostFocus(object sender, EventArgs e)
        {
            if (dlg != null)
            this.tb1.Text = dlg.getSelectName();
        }

        void tb1_GotFocus(object sender, EventArgs e)
        {
            if(dlg!=null)
            this.tb1.Text = dlg.getSelectCode();
        }

        public void setData(object obj)
        {
            this.data = obj;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlg == null)
                {
                    dlg = new SelectDlg(title, form,sql, idfield, codefield, namefield);
                }
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.tb1.Text = dlg.getSelectName();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message+"\n请设置数据库信息.","错误");
            }

        }

        public string getSelectID()
        {
            if(dlg!=null)
            return dlg.getSelectID();
            return null;
        }

        private void tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                this.tb1.Text = null;
                dlg.setSelectID(null);
                dlg.setSelectCode(null);
                dlg.setSelectName(null);
            }
        }
    }
}
