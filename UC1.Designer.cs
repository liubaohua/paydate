namespace Print
{
    partial class UC1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC1));
            this.btn = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.Location = new System.Drawing.Point(1, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(21, 21);
            this.btn.TabIndex = 0;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(22, 2);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(113, 21);
            this.tb1.TabIndex = 1;
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb1_KeyPress);
            // 
            // UC1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.btn);
            this.Name = "UC1";
            this.Size = new System.Drawing.Size(135, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox tb1;
    }
}
