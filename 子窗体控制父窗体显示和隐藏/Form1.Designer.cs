namespace 子窗体控制父窗体显示和隐藏
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Open_Child_Panel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Open_Child_Panel
            // 
            this.btn_Open_Child_Panel.Location = new System.Drawing.Point(350, 193);
            this.btn_Open_Child_Panel.Name = "btn_Open_Child_Panel";
            this.btn_Open_Child_Panel.Size = new System.Drawing.Size(106, 53);
            this.btn_Open_Child_Panel.TabIndex = 0;
            this.btn_Open_Child_Panel.Text = "打开子窗体";
            this.btn_Open_Child_Panel.UseVisualStyleBackColor = true;
            this.btn_Open_Child_Panel.Click += new System.EventHandler(this.btn_Open_Child_Panel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Open_Child_Panel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 466);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 468);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Open_Child_Panel;
        private System.Windows.Forms.Panel panel1;
    }
}

