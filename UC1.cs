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

            if(dlg ==null)
                dlg = new SelectDlg("供应商", data, "cVenCode", "cVenCode", "cVenName");
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.tb1.Text = dlg.getSelectName();
                
            }
        }

        public string getSelectID()
        {
            if(dlg!=null)
            return dlg.getSelectID();
            return null;
        }
    }
}
