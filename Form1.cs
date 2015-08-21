using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;  
using Excel=Microsoft.Office.Interop.Excel;
using SourceGrid;
using SourceGrid.Cells.Controllers;


namespace Print
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                dtp1.Text = String.Format("{0:yyyy-MM-dd}", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
                dpt3.CustomFormat = " ";
                dpt4.CustomFormat = " ";
                dpt5.CustomFormat = " ";
                dpt6.CustomFormat = " ";

                InitDatabaseSetting();
                cbVenType.SelectedIndex = 0;
                cbOper.SelectedIndex = 0;
                InitCombox();
                //ucVen1.setDbInfo("供应商", "select cvencode as 编码,cvenname as 名称 from vendor order by cvencode", "编码", "编码", "名称");
                //ucVen2.setDbInfo("供应商", "select cvencode as 编码,cvenname as 名称 from vendor order by cvencode", "编码", "编码", "名称");
                //ucVen1.setParentForm(this);
                //ucVen2.setParentForm(this);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace, "");
            }

        }

        private void InitCombox()
        {
            getItems();
            //for (int i = 1; i < columnitems.Length; i++)
            //    cbSortField.Items.Add(columnitems[i]);

        }



        public System.Data.DataTable getSqlData(string sql)
        {
            SqlCommand cmdSelect = new SqlCommand(sql, this.sqlConnection1);
            this.sqlConnection1.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            this.sqlConnection1.Close();
            return dt;
        }

        private System.Data.SqlClient.SqlConnection sqlConnection1;

        String XMLFILENAME = "UserData.xml";

        private void InitDatabaseSetting()
        {
            if (!File.Exists(XMLFILENAME))
                WriteXml();
            string ConnString = "data source=.;user id=sa;password=ufida123456;initial catalog=UFDATA_009_2015;Connect Timeout=10;Persist Security Info=True ;Current Language=Simplified Chinese;";
            string Server = ReadXmlData("SqlServer", "Server");
            string User = ReadXmlData("SqlServer", "User");
            string Password = ReadXmlData("SqlServer", "Password");
            string DataBase = ReadXmlData("SqlServer", "DataBase");
            ConnString = "data source=" + RC4.Decrypt("1", Server) + ";";
            ConnString += "user id=" + RC4.Decrypt("1", User) + ";";
            ConnString += "password=" + RC4.Decrypt("1", Password) + ";";
            ConnString += "initial catalog=" + RC4.Decrypt("1", DataBase) + ";";
            ConnString += "Connect Timeout=10;Persist Security Info=True ;Current Language=Simplified Chinese;";
            this.sqlConnection1.ConnectionString = ConnString;
        }

        String ReadXmlData(String ElementName, String ElementName2)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFILENAME);
            XmlNode root = doc.DocumentElement[ElementName];
            if (root != null && root.SelectSingleNode(ElementName2) != null)
                return root.SelectSingleNode(ElementName2).InnerText;
            return "";
        }

        String ReadXmlData(String ElementName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFILENAME);
            XmlNode root = doc.DocumentElement[ElementName];
            if (root != null)
                return root.InnerText;
            return "";
        }

        void ModifyXml(UserData ud)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFILENAME);
            XmlNode root = doc.DocumentElement[ud.ElementName];
            List<NameValuePair> udList = ud.ValueList;
            if (udList != null)
            {
                for (int i = 0; i <= udList.Count - 1; i++)
                    root.SelectSingleNode(udList[i].Name).InnerText = udList[i].Value;
            }
            doc.Save(XMLFILENAME);
        }

        void ModifyXml(String Name, String Value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFILENAME);
            XmlNode root = doc.DocumentElement[Name];
            if (root != null)
            {
                root.InnerText = Value;
                doc.Save(XMLFILENAME);
            }
        }


        void WriteXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(XMLFILENAME, settings);
            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteStartElement("Information");
            writer.WriteStartElement("SqlServer");
            writer.WriteElementString("Server", "");
            writer.WriteElementString("User", "");
            writer.WriteElementString("Password", "");
            writer.WriteElementString("DataBase", "");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();

        }
        string isLog = "";

        private object missing = Missing.Value;
        //        private System.Data.SqlClient.SqlCommand sqlCommand1;

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(("y".Equals(isLog) ? ex.StackTrace : ex.Message), "打印时错误");
            }
        }

        private DateTime FormatTime(string p)
        {
            return DateTime.Parse(p);
        }

        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public void GcCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ReadScale_Click(object sender, EventArgs e)
        {

        }

        private void DbSetting_Click(object sender, EventArgs e)
        {
            DbSettingForm form = new DbSettingForm();
            DialogResult dr = form.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                UserData ud = new UserData();
                ud.ElementName = "SqlServer";
                List<NameValuePair> list = new List<NameValuePair>();
                NameValuePair np = new NameValuePair();
                np.Name = "Server";
                np.Value = RC4.Encrypt("1", form.getIP());
                list.Add(np);

                np = new NameValuePair();
                np.Name = "User";
                np.Value = RC4.Encrypt("1", form.getUser());
                list.Add(np);

                np = new NameValuePair();
                np.Name = "Password";
                np.Value = RC4.Encrypt("1", form.getPassword());
                list.Add(np);

                np = new NameValuePair();
                np.Name = "DataBase";
                np.Value = RC4.Encrypt("1", form.getDatabasename());
                list.Add(np);


                ud.ValueList = list;
                ModifyXml(ud);
                InitDatabaseSetting();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.S)//CTRL + S
                DbSetting_Click(null, null);

        }

        private void TestDb()
        {
            try
            {
                SqlCommand cmdSelect = new SqlCommand("select 1 as mydata", this.sqlConnection1);
                //cmdSelect.Parameters.Add("@ID", SqlDbType.Int, 4);
                //cmdSelect.Parameters["@ID"].Value = InvCode
                this.sqlConnection1.Open();
                MessageBox.Show("数据库连接成功", "提示");
            }
            catch
                (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
            }
            finally
            {
                this.sqlConnection1.Close();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private SourceGrid.Grid grid1;

        private void initGrid(System.Data.DataTable dt)
        {
            //grid1 = new Grid();
            //this.SuspendLayout();
            //// 
            //// grid1
            //// 
            //this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //                                                           | System.Windows.Forms.AnchorStyles.Left)
            //                                                          | System.Windows.Forms.AnchorStyles.Right)));
            //this.grid1.Location = new System.Drawing.Point(8, 8);
            //this.grid1.Name = "grid1";
            //this.grid1.Size = new System.Drawing.Size(612, 423);
            //this.grid1.SpecialKeys = SourceGrid.GridSpecialKeys.Default;
            //this.grid1.TabIndex = 0;
            // 
            // frmSample21
            // 
            // this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            // this.ClientSize = new System.Drawing.Size(628, 438);
            // this.Controls.Add(this.grid1);
            // this.Name = "frmSample21";
            // this.Text = "ColumnSpan and RowSpan";
            //// this.Load += new System.EventHandler(this.frmSample14_Load);
            // this.ResumeLayout(false);
            // this.Controls.Add(grid1);


        }
        private ComboxItem[] columnitems = null;
        private ComboxItem[] getItems()
        {
            if (columnitems == null)
            {
                List<ComboxItem> list = new List<ComboxItem>();
                ComboxItem item = new ComboxItem("序号", "序号");
                list.Add(item);
                item = new ComboxItem("cbMemo", "备注");
                list.Add(item);
                item = new ComboxItem("cPBVCode", "发票号");
                list.Add(item);
                item = new ComboxItem("dPBVDate", "发票日期");
                list.Add(item);
                item = new ComboxItem("PayDate", "付款日期");
                list.Add(item);
                item = new ComboxItem("cVenName", "供应商");
                list.Add(item);
                item = new ComboxItem("cexch_name", "币种");
                list.Add(item);
                item = new ComboxItem("nflat", "汇率");
                list.Add(item);
                item = new ComboxItem("cInvCode", "存货编码");
                list.Add(item);
                item = new ComboxItem("cInvName", "存货名称");
                list.Add(item);
                item = new ComboxItem("cInvStd", "规格型号");
                list.Add(item);
                item = new ComboxItem("cInvAddCode", "存货代码");
                list.Add(item);
                item = new ComboxItem("cComUnitName", "单位");
                list.Add(item);
                item = new ComboxItem("iQuantity", "数量");
                list.Add(item);
                //item = new ComboxItem("iMoney", "原币无税金额");
                //list.Add(item);
                //item = new ComboxItem("iSum", "原币含税金额");
                //list.Add(item);
                //item = new ComboxItem("iNatMoney", "本币无税金额");
                //list.Add(item);
                //item = new ComboxItem("iNatSum", "本币含税金额");
                //list.Add(item);
                //item = new ComboxItem("iMoney_Total", "原币无税金额合计");
                //list.Add(item);
                //item = new ComboxItem("iSum_Total", "原币含税金额合计");
                //list.Add(item);
                //item = new ComboxItem("iNatMoney_Total", "本币无税金额合计");
                //list.Add(item);
                //item = new ComboxItem("iNatSum_Total", "本币含税金额合计");
                //list.Add(item);
                item = new ComboxItem("iOriSum", "原币发票金额");
                list.Add(item);
                item = new ComboxItem("iSum", "本币发票金额");
                list.Add(item);
                item = new ComboxItem("iOriSum_Total", "原币发票金额合计");
                list.Add(item);
                item = new ComboxItem("iSum_Total", "本币发票金额合计");
                list.Add(item);
                item = new ComboxItem("iOriTotal", "原币付款");
                list.Add(item);
                item = new ComboxItem("iTotal", "本币付款");
                list.Add(item);
                item = new ComboxItem("iOriTotal_Total", "原币付款合计");
                list.Add(item);
                item = new ComboxItem("iTotal_Total", "本币付款合计");
                list.Add(item);
                item = new ComboxItem("iOriPayBalance", "原币余额");
                list.Add(item);
                item = new ComboxItem("iPayBalance", "本币余额");
                list.Add(item);
                item = new ComboxItem("PayTerm", "付款条件");
                list.Add(item);
                item = new ComboxItem("ivouchrowno", "订单行号");
                list.Add(item);
                item = new ComboxItem("cPOID", "订单号");
                list.Add(item);
                item = new ComboxItem("cmaketime", "订单日期");
                list.Add(item);
                item = new ComboxItem("cmaker", "制单人");
                list.Add(item);
                item = new ComboxItem("pbid", "pbid");
                list.Add(item); 
                item = new ComboxItem("id", "id");
                list.Add(item);
                columnitems = list.ToArray();
            }
            return columnitems;
        }

        private int GetIndexByName(string name)
        {
            ComboxItem[] ary = getItems();
            for(int i=0;i<ary.Length;i++)
                if(ary[i].Value.ToString().ToLower().Equals(name.ToLower()))
                    return i;
            throw new Exception("列名错误");
        }


        private void DoFull1(System.Data.DataTable dt)
        {
            ComboxItem[] items = getItems();

            if (dt.Rows.Count > 0)
            {
                grid1.Redim(1, items.Length);
                grid1.Redim(dt.Rows.Count + 1 + 1, items.Length);
            }
            else
            {
                grid1.Redim(1, items.Length);
            }
            grid1.FixedRows = 1;
            grid1.FixedColumns = 1;
            grid1.Selection.EnableMultiSelection = true;

            for (int i = 0; i < items.Length; i++)
                grid1[0, i] = new MyHeader(items[i].Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int cnt = int.Parse(dt.Rows[i]["cnt"].ToString());
                int cnt_sub = int.Parse(dt.Rows[i]["cnt_sub"].ToString());

                grid1[i + 1, GetIndexByName("序号")] = new SourceGrid.Cells.Cell(dt.Rows[i]["序号"].ToString(), typeof(int));


                grid1[i + 1, GetIndexByName("iOriSum")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriSum"].ToString(), typeof(decimal));
                grid1[i + 1, GetIndexByName("iSum")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iSum"].ToString(), typeof(decimal));
                grid1[i + 1, GetIndexByName("iOriTotal")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriTotal"].ToString(), typeof(decimal));
                grid1[i + 1, GetIndexByName("iTotal")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iTotal"].ToString(), typeof(decimal));
                grid1[i + 1, GetIndexByName("cbMemo")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cbMemo"].ToString(), typeof(string));



                grid1[i + 1, GetIndexByName("pbid")] = new SourceGrid.Cells.Cell(dt.Rows[i]["pbid"].ToString(), typeof(int));
                grid1[i + 1, GetIndexByName("id")] = new SourceGrid.Cells.Cell(dt.Rows[i]["id"].ToString(), typeof(int));

                

                

                // grid1[i+1, ++col] = new SourceGrid.Cells.Cell(dt.Rows[i]["cPOID"].ToString(), typeof(string));
                if (i == 0 || (i > 0 && !dt.Rows[i]["cPBVCode"].ToString().Equals(dt.Rows[i - 1]["cPBVCode"].ToString())))
                {
                    grid1[i + 1, GetIndexByName("cPBVCode")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cPBVCode"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("dPBVDate")] = new SourceGrid.Cells.Cell(dt.Rows[i]["dPBVDate"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("PayDate")] = new SourceGrid.Cells.Cell(dt.Rows[i]["PayDate"].ToString(), typeof(string));
                    
                    grid1[i + 1, GetIndexByName("cPOID")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cPOID"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cmaketime")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cmaketime"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cVenName")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cVenName"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cexch_name")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cexch_name"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("nflat")] = new SourceGrid.Cells.Cell(dt.Rows[i]["nflat"].ToString(), typeof(decimal));

                    grid1[i + 1, GetIndexByName("iOriSum_Total")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriSum_Total"].ToString(), typeof(decimal));
                    grid1[i + 1, GetIndexByName("iSum_Total")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iSum_Total"].ToString(), typeof(decimal));
                    grid1[i + 1, GetIndexByName("iOriTotal_Total")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriTotal_Total"].ToString(), typeof(decimal));
                    grid1[i + 1, GetIndexByName("iTotal_Total")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iTotal_Total"].ToString(), typeof(decimal));
                    grid1[i + 1, GetIndexByName("iTotal_Total")].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
                    grid1[i + 1, GetIndexByName("PayTerm")] = new SourceGrid.Cells.Cell(dt.Rows[i]["PayTerm"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cmaker")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cmaker"].ToString(), typeof(string));

                    grid1[i + 1, GetIndexByName("iOriPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriPayBalance"].ToString(), typeof(decimal));
                    grid1[i + 1, GetIndexByName("iPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iPayBalance"].ToString(), typeof(decimal));
                    
                    

                    if (cnt > 1)
                    {
                        grid1[i + 1, GetIndexByName("cPBVCode")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("dPBVDate")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("PayDate")].RowSpan = cnt;

                        grid1[i + 1, GetIndexByName("cPOID")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("cmaketime")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("cVenName")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("cexch_name")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("nflat")].RowSpan = cnt;

                        grid1[i + 1, GetIndexByName("iOriSum_Total")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("iSum_Total")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("iOriTotal_Total")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("iTotal_Total")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("PayTerm")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("cmaker")].RowSpan = cnt;

                        grid1[i + 1, GetIndexByName("iOriPayBalance")].RowSpan = cnt;
                        grid1[i + 1, GetIndexByName("iPayBalance")].RowSpan = cnt;

                    }
                }

                if (i == 0 || (i > 0 && ((!dt.Rows[i]["cPBVCode"].ToString().Equals(dt.Rows[i - 1]["cPBVCode"].ToString())) || (dt.Rows[i]["cPBVCode"].ToString().Equals(dt.Rows[i - 1]["cPBVCode"].ToString()) && !dt.Rows[i]["ivouchrowno"].ToString().Equals(dt.Rows[i - 1]["ivouchrowno"].ToString())))))
                {
                    grid1[i + 1, GetIndexByName("cInvCode")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cInvCode"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cInvName")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cInvName"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cInvStd")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cInvStd"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cInvAddCode")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cInvAddCode"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("cComUnitName")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cComUnitName"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("iQuantity")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iQuantity"].ToString(), typeof(decimal));

                    //grid1[i + 1, GetIndexByName("iOriPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iOriPayBalance"].ToString(), typeof(decimal));
                    //grid1[i + 1, GetIndexByName("iPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[i]["iPayBalance"].ToString(), typeof(decimal));

                    

                    //grid1[i + 1, GetIndexByName("cbMemo")] = new SourceGrid.Cells.Cell(dt.Rows[i]["cbMemo"].ToString(), typeof(string));
                    grid1[i + 1, GetIndexByName("ivouchrowno")] = new SourceGrid.Cells.Cell(dt.Rows[i]["ivouchrowno"].ToString(), typeof(string));
                
                    if (cnt_sub > 1)
                    {
                        grid1[i + 1, GetIndexByName("cInvCode")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("cInvName")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("cInvStd")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("cInvAddCode")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("cComUnitName")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("iQuantity")].RowSpan = cnt_sub;

                        //grid1[i + 1, GetIndexByName("iOriPayBalance")].RowSpan = cnt_sub;
                        //grid1[i + 1, GetIndexByName("iPayBalance")].RowSpan = cnt_sub;
                        
                        //grid1[i + 1, GetIndexByName("cbMemo")].RowSpan = cnt_sub;
                        grid1[i + 1, GetIndexByName("ivouchrowno")].RowSpan = cnt_sub;
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < grid1.Columns.Count;i++ )
                    grid1[grid1.Rows.Count - 1, i] = new SourceGrid.Cells.Cell("", typeof(string));//最后合计行初始化
                grid1[grid1.Rows.Count - 1, GetIndexByName("序号")] = new SourceGrid.Cells.Cell("合计", typeof(string));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iOriSum")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iOriSum_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iSum")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iSum_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iOriSum_Total")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iOriSum_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iSum_Total")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iSum_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iOriTotal")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iOriTotal_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iTotal")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iTotal_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iOriTotal_Total")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iOriTotal_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iTotal_Total")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iTotal_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iOriPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iOriPayBalance_all"].ToString(), typeof(decimal));
                grid1[grid1.Rows.Count - 1, GetIndexByName("iPayBalance")] = new SourceGrid.Cells.Cell(dt.Rows[0]["iPayBalance_all"].ToString(), typeof(decimal));
            }
            grid1.Columns[GetIndexByName("pbid")].Visible = false;//采购订单子表ID不可见
            grid1.Columns[GetIndexByName("id")].Visible = false;
            grid1.Columns[GetIndexByName("ivouchrowno")].Visible = false;//采购订单行号

            //grid1.AutoStretchColumnsToFitWidth = true; 
            //grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;// doesnot work
            grid1.Columns.AutoSize(true);
            grid1.Columns.StretchToFit();

        }

        private class MyHeader : SourceGrid.Cells.ColumnHeader
        {
            public MyHeader(object value)
                : base(value)
            {
                //1 Header Row
                SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
                view.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                View = view;

                AutomaticSortEnabled = false;
            }
        }

        private string getVenType(int i)
        {
            if (i == 0)
                return "cvencode";
            return "cvenname";
        }

        private string getOperType(int i, string value)
        {
            if (i == 0)
                return " = '" + value + "'";
            return " like '%" + value + "%'";

        }

        private void btQry_Click(object sender, EventArgs e)
        {
            if (new DateTime().CompareTo(new DateTime(2015, 8, 30)) > 0)
            {
                MessageBox.Show("演示日期到期！");
                return;
            }
            try
            {
                StringBuilder ordercond= new StringBuilder();
                StringBuilder invoicecond = new StringBuilder();
                StringBuilder condition = new StringBuilder();

                //StringBuilder orderbystr = new StringBuilder("order by cPBVCode,ivouchrowno");
                //StringBuilder groupbystr = new StringBuilder("partition by cPOID");//cvencode

                if (dtp1.Text.Trim().Equals("") || dtp2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("请您选择付款日期", "提示");
                    return;
                }
                //if (cbSortField.SelectedIndex >= 0)
                //    orderbystr = new StringBuilder("order by " + (cbSortField.SelectedItem as ComboxItem).Value);
                if (cbVenType.SelectedIndex >= 0 && cbOper.SelectedIndex >= 0 && !tbVen.Text.Equals(""))//订单表
                    ordercond.Append(" and " + getVenType(cbVenType.SelectedIndex) + getOperType(cbOper.SelectedIndex, tbVen.Text));
                if (!dpt3.Text.Trim().Equals("") && !dpt4.Text.Trim().Equals(""))//订单表
                    ordercond.Append(" and cmaketime>='" + String.Format("{0:yyyy-MM-dd}", dpt3.Text) + "' and cmaketime<='" + String.Format("{0:yyyy-MM-dd}", dpt4.Text) + "' ");
                if (!cbPayTerm1.Text.Equals("") && !cbPayTerm2.Text.Equals(""))//订单表
                    ordercond.Append(" and PayTerm>='" + cbPayTerm1.Text + "' and PayTerm<='" + cbPayTerm2.Text + "' ");
                if (!tbPoCode1.Text.Equals("") && !tbPocode2.Text.Equals(""))//订单表
                    ordercond.Append(" and cPOID>='" + tbPoCode1.Text + "' and cPOID<='" + tbPocode2.Text + "' ");//订单表
                
                //开票日期
                if (!dpt5.Text.Trim().Equals("") && !dpt6.Text.Trim().Equals(""))//发票表
                    invoicecond.Append(" and dPBVDate>='" + String.Format("{0:yyyy-MM-dd}", dpt5.Text) + "' and dPBVDate<='" + String.Format("{0:yyyy-MM-dd}", dpt6.Text) + "' ");
                if (!tbInvoiceNO.Text.Equals(""))
                    invoicecond.Append(" and cPBVCode='" + tbInvoiceNO.Text + "'");//发票表

                //付款日期
                if (!dtp1.Text.Trim().Equals("") && !dtp2.Text.Trim().Equals(""))
                    invoicecond.Append(" and (case when v.cvendefine1='预付款' then CONVERT(nvarchar(30), ob.cAuditDate, 112)  when v.cvendefine1='见票付款' then CONVERT(nvarchar(30), pvh.dPBVDate, 112)  when v.cvendefine1='月结30天' then CONVERT(nvarchar(30), pvh.dPBVDate+30, 112)  when v.cvendefine1='月结60天' then CONVERT(nvarchar(30), pvh.dPBVDate+60, 112)  end )>='" + String.Format("{0:yyyy-MM-dd}", dtp1.Text) + "' and (case when v.cvendefine1='预付款' then CONVERT(nvarchar(30), ob.cAuditDate, 112)  when v.cvendefine1='见票付款' then CONVERT(nvarchar(30), pvh.dPBVDate, 112)  when v.cvendefine1='月结30天' then CONVERT(nvarchar(30), pvh.dPBVDate+30, 112)  when v.cvendefine1='月结60天' then CONVERT(nvarchar(30), pvh.dPBVDate+60, 112)  end )<='" + String.Format("{0:yyyy-MM-dd}", dtp2.Text) + "' ");
                

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select row_number() over (order by isnull(cPBVCode,'zzzzz'),ivouchrowno) as 序号,t.* from (");
                        sb.AppendLine("select pt.*,lt.*");
                        sb.AppendLine("from ( ");
                        sb.AppendLine("SELECT ph.cPOID, CONVERT(nvarchar(30), ph.dPODate, 112) AS cmaketime,");
                        sb.AppendLine("v.cVenCode, v.cVenName, ph.cexch_name, pb.cInvCode, i.cInvName, i.cInvStd, i.cInvAddCode,");
                        sb.AppendLine("cu.cComUnitName, CAST(pb.iQuantity AS decimal(18, 2)) AS iQuantity,");
                        sb.AppendLine("v.cVenDefine1 AS PayTerm,");
                        sb.AppendLine(" ph.cMaker, pb.id as pbid, ph.POID as phid,");
                        sb.AppendLine(" ph.cAuditDate,--pb.ivouchrowno,");
                        sb.AppendLine(" ph.nflat ");//,pb.cbMemo
                        sb.AppendLine("FROM dbo.PO_Pomain AS ph INNER JOIN ");
                        sb.AppendLine(" dbo.PO_Podetails AS pb ON ph.POID = pb.POID INNER JOIN ");
                        sb.AppendLine(" dbo.Inventory AS i ON pb.cInvCode = i.cInvCode INNER JOIN ");
                        sb.AppendLine(" dbo.ComputationUnit AS cu ON cu.cComunitCode = i.cComUnitCode INNER JOIN ");
                        sb.AppendLine(" dbo.Vendor AS v ON v.cVenCode = ph.cVenCode where 1=1 ").Append(ordercond);
                        sb.AppendLine(") lt ");
                        sb.AppendLine("LEFT JOIN ");
                        sb.AppendLine("(SELECT pvb.id, pvh.cPBVCode, pvb.iPOsID,pvb.ivouchrowno,");
                        sb.AppendLine("CONVERT(nvarchar(30), pvh.dPBVDate, 112) AS dPBVDate,");
                        sb.AppendLine("pvb.iOriSum as iOriSum,--原币价税合计 ");
                        sb.AppendLine("pvb.iSum as iSum,--本币价税合计 ");
                        sb.AppendLine("pvb.iOriTotal,--原币付款 ");
                        sb.AppendLine("pvb.iTotal,--本币付款 ");
                        sb.AppendLine("SUM(pvb.iOriSum) over (PARTITION by pvh.cPBVCode) iOriSum_total,");
                        sb.AppendLine("SUM(pvb.iSum) over (PARTITION by pvh.cPBVCode) iSum_total,");
                        sb.AppendLine("SUM(pvb.iOriTotal) over (PARTITION by pvh.cPBVCode) iOriTotal_total,");
                        sb.AppendLine("SUM(pvb.itotal) over (PARTITION by pvh.cPBVCode) itotal_total,");
                        //sb.AppendLine("cast(pvb.iOriSum-pvb.iOriTotal as decimal(18,2)) as iOriPayBalance,");
                        //sb.AppendLine("cast(pvb.iSum-pvb.iTotal as decimal(18,2)) as iPayBalance,");
                        sb.AppendLine("SUM(cast(pvb.iOriSum-pvb.iOriTotal as decimal(18,2))) over (PARTITION by pvh.cPBVCode) iOriPayBalance,");
                        sb.AppendLine("SUM(cast(pvb.iSum-pvb.iTotal as decimal(18,2))) over (PARTITION by pvh.cPBVCode) iPayBalance,");
                        sb.AppendLine("SUM(cast(pvb.iOriSum-pvb.iOriTotal as decimal(18,2))) over () iOriPayBalance_all,");
                        sb.AppendLine("SUM(cast(pvb.iSum-pvb.iTotal as decimal(18,2))) over () iPayBalance_all,");
                        sb.AppendLine("SUM(pvb.iOriSum) over () iOriSum_all,");
                        sb.AppendLine("SUM(pvb.iSum) over () iSum_all,");
                        sb.AppendLine("SUM(pvb.iOriTotal) over () iOriTotal_all,");
                        sb.AppendLine("SUM(pvb.iTotal) over () iTotal_all ,");
                        sb.AppendLine("count(1) over (partition by cPBVCode) as cnt,");
                        sb.AppendLine("count(1) over (partition by cPBVCode,ivouchrowno) as cnt_sub,");
                        sb.AppendLine("(case when v.cvendefine1='预付款' then CONVERT(nvarchar(30), ob.cAuditDate, 112)"); 
                        sb.AppendLine(" when v.cvendefine1='见票付款' then CONVERT(nvarchar(30), pvh.dPBVDate, 112) ");
                        sb.AppendLine(" when v.cvendefine1='月结30天' then CONVERT(nvarchar(30), pvh.dPBVDate+30, 112) ");
                        sb.AppendLine(" when v.cvendefine1='月结60天' then CONVERT(nvarchar(30), pvh.dPBVDate+60, 112) ");
                        sb.AppendLine(" end ) as PayDate,pvb.cbMemo ");
                        sb.AppendLine("FROM dbo.PurBillVouchs AS pvb INNER JOIN ");
                        sb.AppendLine("dbo.PurBillVouch AS pvh ON pvh.PBVID = pvb.PBVID inner join vendor v on v.cvencode=pvh.cvencode left join (select pb.id,ph.cAuditDate from PO_Podetails pb inner join PO_Pomain ph on ph.POID = pb.POID) ob on ob.id=pvb.iPOsID ");
                        sb.AppendLine("where iPOsID is not null ").Append(invoicecond);
                        sb.AppendLine(") AS pt ");
                        sb.AppendLine("ON pt.iPOsID = lt.pbid");
                sb.AppendLine(") t where isnull(iTotal,0)<isnull(iSum,0) ");
              //  sb.AppendLine("where 1=1 ");
                sb.AppendLine(condition.ToString());
                sb.AppendLine(" order by isnull(cPBVCode,'zzzzz'),ivouchrowno");
                SqlCommand cmdSelect = new SqlCommand(sb.ToString(), this.sqlConnection1);
                this.sqlConnection1.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                DoFull1(dt);





                //this.reportViewer1.Reset();
                //this.reportViewer1.LocalReport.DataSources.Clear();
                //this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Print.Report1.rdlc";
                //ReportDataSource rds = new ReportDataSource("ds", dt); //ReportDataSource数据源的第一个参数必须与你添加的dataset的名字相同
                //this.reportViewer1.LocalReport.DataSources.Add(rds);  //添加数据源
                //this.reportViewer1.ZoomMode = ZoomMode.Percent;
                //this.reportViewer1.RefreshReport();




                //this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                //this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Print.Report1.rdlc";
                //this.reportViewer1.LocalReport.EnableExternalImages = true;

                //List<ReportParameter> para = new List<ReportParameter>();
                ////这里是添加两个字段
                //para.Add(new ReportParameter("FishName", "fishkel"));
                //para.Add(new ReportParameter("FishId", "123"));
                ////这里是添加两个数据源，两个list
                //var list = new List<TestReport> { };
                //list.Add(new TestReport() { a = "20100201", b = 0.1, c = 0.2, d = 0.1 });
                //list.Add(new TestReport() { a = "20100202", b = 0.1, c = 0.2, d = 0.2 });
                //list.Add(new TestReport() { a = "20100203", b = 0.1, c = 0.4, d = 0.2 });
                //var test = new List<TestReport>() { new TestReport() { a = "20100201", b = 0.33, c = 0.33, d = 0.33 } };
                //ReportDataSource reportDataSource = new ReportDataSource();
                //reportDataSource.Name = "DataSet1";
                //reportDataSource.Value = test;


                //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ////this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TestList", list));
                //this.reportViewer1.LocalReport.SetParameters(para);
                //this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                this.sqlConnection1.Close();
            }
        }





        //private void MergeCells(int RowId1, int RowId2, int Column, bool isSelected, DataGridView dataGrid)
        //{
        //    Graphics g = dataGrid.CreateGraphics();
        //    Pen gridPen = new Pen(dataGrid.GridColor);


        //    //Cells Rectangles
        //    Rectangle CellRectangle1 = dataGrid.GetCellDisplayRectangle(Column, RowId1, true);
        //    Rectangle CellRectangle2 = dataGrid.GetCellDisplayRectangle(Column, RowId2, true);

        //    int rectHeight = 0;
        //    string MergedRows = String.Empty;

        //    for (int i = RowId1; i <= RowId2; i++)
        //    {
        //        rectHeight += dataGrid.GetCellDisplayRectangle(Column, i, false).Height;
        //    }

        //    Rectangle newCell = new Rectangle(CellRectangle1.X, CellRectangle1.Y, CellRectangle1.Width, rectHeight);

        //    g.FillRectangle(new SolidBrush(isSelected ? dataGrid.DefaultCellStyle.SelectionBackColor : dataGrid.DefaultCellStyle.BackColor), newCell);

        //    g.DrawRectangle(gridPen, newCell);

        //    g.DrawString(dataGrid.Rows[RowId1].Cells[Column].Value.ToString(), dataGrid.DefaultCellStyle.Font, new SolidBrush(isSelected ? dataGrid.DefaultCellStyle.SelectionForeColor : dataGrid.DefaultCellStyle.ForeColor), newCell.X + 0 * newCell.Width / 3, newCell.Y + newCell.Height / 3);
        //}

        private void dvResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dvResult_Sorted(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //  this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (grid1.Rows.Count <= 1) 
                    return;
                //PrintExcel();
                //return;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel文件(*.xls)|*.xls";//|Excel 2007(*.xlsx)|*.xlsx
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveExcel(sfd.FileName);
                        
                    //using (System.IO.StreamWriter writer = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.Default))
                    //{
                    //    SourceGrid.Exporter.CSV csv = new SourceGrid.Exporter.CSV();
                    //    csv.Export(grid1, writer);
                    //    writer.Close();
                    //}
                    //DevAge.Shell.Utilities.OpenFile(sfd.FileName);
                }
            }
            catch (Exception err)
            {
                DevAge.Windows.Forms.ErrorDialog.Show(this, err, "Excel文件导出错误");
            }
        }

        protected void SaveExcel(string excelfile)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //加载模板  
            Workbook workbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            try
            {
                //获取模板中第一个sheet页  
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
                int rowspan = 1;
                int realcolumn;
                Excel.Range range = null;
                int iColCPOID = GetIndexByName("cPOID");
                int iColPBVCode = GetIndexByName("cPBVCode");
                int iColInvCode = GetIndexByName("cinvcode");
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    //for (int j = 5; j < 6; j++)
                    realcolumn = 0;
                    for (int column = 0; column < grid1.Columns.Count; column++)
                    {
                       // realcolumn = column;
                        if (grid1.Columns[column].Visible == false)
                            continue;
                        rowspan = grid1[i, column].RowSpan;
                        //            rg1.MergeCells = true;
                        //rg1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //rg1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        if (rowspan > 1)
                        {
                            object s = ((Excel.Range)((Excel.Range)worksheet.Cells[i + 1, realcolumn + 1]).MergeArea[1, 1]).Value2;
                            if (s == null)
                            {
                                range = worksheet.get_Range(worksheet.Cells[i + 1, realcolumn + 1], worksheet.Cells[i + 1 + rowspan - 1, realcolumn + 1]);
                                range.MergeCells = true;
                                if (column == iColCPOID || column == iColPBVCode || column == iColInvCode)
                                    range.NumberFormatLocal = "@";
                                worksheet.Cells[i + 1, realcolumn + 1] = grid1[i, column].Value;
                            }
                        }
                        else
                        {
                            //SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
                            //view.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                            //view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                            range = worksheet.get_Range(worksheet.Cells[i + 1, realcolumn + 1], worksheet.Cells[i + 1, realcolumn + 1]);
                            if (grid1[i, column].GetType().Name.Equals("MyHeader"))
                            {
                                range.Font.Bold = true;
                            }
                            if (column == iColCPOID || column == iColPBVCode || column == iColInvCode)
                                range.NumberFormatLocal = "@";
                            //worksheet.get_Range("A1", "C3").Font.Name = "Times New Roman";//设置字体.  
                            //worksheet.get_Range("A1", "C3").Font.Size = 22;//设置字体大小  
                            //range.Font.Bold = true;//加粗  
                            //range.RowHeight = 22;//调行高
                            worksheet.Cells[i + 1, realcolumn + 1] = grid1[i, column].Value;
                        }
                        realcolumn++;
                    }
                }

                //利用公式计算满足某条街的总和，单独分出3是为了可以在程序中替换该值  
                //worksheet.Cells[2, 4] = "=COUNTIF(C2:C" + 3 + ",\"男\")";
                //worksheet.get_Range("A1", "A3").MergeCells = true; //合并单元格

                ////在结尾添加一特殊行，插入值  
                //Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 2]);
                ////合并单元格  
                //range.Merge(0);
                ////设置单元格文字对齐方式  
                //range.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //range.Cells[1, 1] = "Hello";
                //worksheet.Cells[4, 3] = "0";
                ////设置单元格背景色  
                //range = worksheet.Cells[4, 3] as Microsoft.Office.Interop.Excel.Range;
                //range.Interior.Color = System.Drawing.Color.LightSeaGreen;


                //画边框  
                //range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 3]);
                //range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

                //range = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[3, 2]);
                //range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;

                //保存  
                string Version = app.Version;//
                int FormatNum;//保存excel文件的格式
                if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                {
                    FormatNum = -4143;
                }
                else//you use excel 2007 or later
                {
                    FormatNum = 56;
                }
                workbook.SaveAs(excelfile, FormatNum);

                //workbook.SaveAs(excelfile,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                
            }catch(Exception e2)
            {
                MessageBox.Show(e2.Message,"错误");
            }
            finally
            {
                //资源清理
                workbook.Close();
                app.Workbooks.Close();
                app.Quit();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                MessageBox.Show("导出成功", "提示");
                DevAge.Shell.Utilities.OpenFile(excelfile);
            }
        }  

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rows = grid1.Selection.GetSelectionRegion().GetRowsIndex();
                if (rows==null || rows.Length == 0)
                    return;
                this.sqlConnection1.Open();
                for (int i = 0; i < rows.Length; i++)
                {
                    SqlCommand cmdSelect = new SqlCommand("update PurBillVouchs set cbMemo='" + grid1[rows[i], GetIndexByName("cbMemo")].Value + "' where id='" + grid1[rows[i], GetIndexByName("id")].Value + "'", this.sqlConnection1);
                    int iresult = cmdSelect.ExecuteNonQuery();
                }
                MessageBox.Show("成功保存"+rows.Length+"条记录");
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally
            {
                this.sqlConnection1.Close();
            }
        }
    }
}
