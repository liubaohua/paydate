using System;
namespace Print
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TestReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPayTerm2 = new System.Windows.Forms.ComboBox();
            this.cbPayTerm1 = new System.Windows.Forms.ComboBox();
            this.btQry = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVendor2 = new System.Windows.Forms.TextBox();
            this.tbPocode2 = new System.Windows.Forms.TextBox();
            this.tbPoCode1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dvResult = new System.Windows.Forms.DataGridView();
            this.dpt6 = new Print.FlatDateTimePicker();
            this.dpt4 = new Print.FlatDateTimePicker();
            this.dpt5 = new Print.FlatDateTimePicker();
            this.dpt3 = new Print.FlatDateTimePicker();
            this.dtp2 = new Print.FlatDateTimePicker();
            this.dtp1 = new Print.FlatDateTimePicker();
            this.testReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TestReportBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testReportBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestReportBindingSource
            // 
            this.TestReportBindingSource.DataMember = "TestReport";
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPayTerm2);
            this.panel1.Controls.Add(this.cbPayTerm1);
            this.panel1.Controls.Add(this.btQry);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbVendor2);
            this.panel1.Controls.Add(this.tbPocode2);
            this.panel1.Controls.Add(this.tbPoCode1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dpt6);
            this.panel1.Controls.Add(this.tbVendor);
            this.panel1.Controls.Add(this.dpt4);
            this.panel1.Controls.Add(this.dpt5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dpt3);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 70);
            this.panel1.TabIndex = 2;
            // 
            // cbPayTerm2
            // 
            this.cbPayTerm2.FormattingEnabled = true;
            this.cbPayTerm2.Items.AddRange(new object[] {
            "预付款",
            "见票付款",
            "月结30天",
            "月结60天"});
            this.cbPayTerm2.Location = new System.Drawing.Point(832, 12);
            this.cbPayTerm2.Name = "cbPayTerm2";
            this.cbPayTerm2.Size = new System.Drawing.Size(128, 20);
            this.cbPayTerm2.TabIndex = 22;
            // 
            // cbPayTerm1
            // 
            this.cbPayTerm1.FormattingEnabled = true;
            this.cbPayTerm1.Items.AddRange(new object[] {
            "预付款",
            "见票付款",
            "月结30天",
            "月结60天"});
            this.cbPayTerm1.Location = new System.Drawing.Point(674, 13);
            this.cbPayTerm1.Name = "cbPayTerm1";
            this.cbPayTerm1.Size = new System.Drawing.Size(129, 20);
            this.cbPayTerm1.TabIndex = 22;
            // 
            // btQry
            // 
            this.btQry.Location = new System.Drawing.Point(983, 19);
            this.btQry.Name = "btQry";
            this.btQry.Size = new System.Drawing.Size(86, 34);
            this.btQry.TabIndex = 5;
            this.btQry.Text = "查询";
            this.btQry.UseVisualStyleBackColor = true;
            this.btQry.Click += new System.EventHandler(this.btQry_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(809, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "至";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(809, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "至";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(470, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "至";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(470, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "采购单号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "付款条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "供应商";
            // 
            // tbVendor2
            // 
            this.tbVendor2.Location = new System.Drawing.Point(181, 42);
            this.tbVendor2.Name = "tbVendor2";
            this.tbVendor2.Size = new System.Drawing.Size(101, 21);
            this.tbVendor2.TabIndex = 9;
            // 
            // tbPocode2
            // 
            this.tbPocode2.Location = new System.Drawing.Point(832, 41);
            this.tbPocode2.Name = "tbPocode2";
            this.tbPocode2.Size = new System.Drawing.Size(130, 21);
            this.tbPocode2.TabIndex = 10;
            // 
            // tbPoCode1
            // 
            this.tbPoCode1.Location = new System.Drawing.Point(674, 41);
            this.tbPoCode1.Name = "tbPoCode1";
            this.tbPoCode1.Size = new System.Drawing.Size(127, 21);
            this.tbPoCode1.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "开票日期";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "订单日期";
            // 
            // tbVendor
            // 
            this.tbVendor.Location = new System.Drawing.Point(71, 42);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.Size = new System.Drawing.Size(81, 21);
            this.tbVendor.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "付款期间";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dvResult);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 499);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 3;
            // 
            // dvResult
            // 
            this.dvResult.AllowUserToAddRows = false;
            this.dvResult.AllowUserToDeleteRows = false;
            this.dvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvResult.Location = new System.Drawing.Point(0, 0);
            this.dvResult.Name = "dvResult";
            this.dvResult.ReadOnly = true;
            this.dvResult.RowTemplate.Height = 23;
            this.dvResult.Size = new System.Drawing.Size(1092, 430);
            this.dvResult.TabIndex = 0;
            this.dvResult.Paint += new System.Windows.Forms.PaintEventHandler(this.dvResult_Paint);
            // 
            // dpt6
            // 
            this.dpt6.CustomFormat = "yyyy-MM-dd";
            this.dpt6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt6.Location = new System.Drawing.Point(496, 42);
            this.dpt6.Name = "dpt6";
            this.dpt6.Size = new System.Drawing.Size(105, 21);
            this.dpt6.TabIndex = 6;
            // 
            // dpt4
            // 
            this.dpt4.CustomFormat = "yyyy-MM-dd";
            this.dpt4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt4.Location = new System.Drawing.Point(496, 12);
            this.dpt4.Name = "dpt4";
            this.dpt4.Size = new System.Drawing.Size(105, 21);
            this.dpt4.TabIndex = 6;
            // 
            // dpt5
            // 
            this.dpt5.CustomFormat = "yyyy-MM-dd";
            this.dpt5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt5.Location = new System.Drawing.Point(358, 41);
            this.dpt5.Name = "dpt5";
            this.dpt5.Size = new System.Drawing.Size(105, 21);
            this.dpt5.TabIndex = 7;
            // 
            // dpt3
            // 
            this.dpt3.CustomFormat = "yyyy-MM-dd";
            this.dpt3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpt3.Location = new System.Drawing.Point(358, 11);
            this.dpt3.Name = "dpt3";
            this.dpt3.Size = new System.Drawing.Size(105, 21);
            this.dpt3.TabIndex = 7;
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(181, 12);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(101, 21);
            this.dtp2.TabIndex = 6;
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(71, 13);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(81, 21);
            this.dtp1.TabIndex = 7;
            // 
            // testReportBindingSource1
            // 
            this.testReportBindingSource1.DataSource = typeof(Print.TestReport);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 499);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "付款日期查询";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TestReportBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testReportBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btQry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVendor2;
        private System.Windows.Forms.TextBox tbPocode2;
        private System.Windows.Forms.TextBox tbPoCode1;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.Label label1;
        private FlatDateTimePicker dtp2;
        private FlatDateTimePicker dtp1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FlatDateTimePicker dpt4;
        private FlatDateTimePicker dpt3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private FlatDateTimePicker dpt6;
        private FlatDateTimePicker dpt5;
        private System.Windows.Forms.BindingSource TestReportBindingSource;
        private System.Windows.Forms.BindingSource testReportBindingSource1;
        private System.Windows.Forms.ComboBox cbPayTerm1;
        private System.Windows.Forms.ComboBox cbPayTerm2;
        private System.Windows.Forms.DataGridView dvResult;

    }
}

