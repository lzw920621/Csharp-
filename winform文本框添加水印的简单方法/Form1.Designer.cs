namespace winform文本框添加水印的简单方法
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_UserName_Water = new System.Windows.Forms.Label();
            this.label_Password_Water = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(176, 58);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(185, 25);
            this.textBox_UserName.TabIndex = 2;
            this.textBox_UserName.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(176, 118);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(185, 25);
            this.textBox_Password.TabIndex = 3;
            this.textBox_Password.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label_UserName_Water
            // 
            this.label_UserName_Water.AutoSize = true;
            this.label_UserName_Water.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_UserName_Water.Location = new System.Drawing.Point(228, 61);
            this.label_UserName_Water.Name = "label_UserName_Water";
            this.label_UserName_Water.Size = new System.Drawing.Size(82, 15);
            this.label_UserName_Water.TabIndex = 4;
            this.label_UserName_Water.Text = "输入用户名";
            this.label_UserName_Water.Click += new System.EventHandler(this.label_Click);
            // 
            // label_Password_Water
            // 
            this.label_Password_Water.AutoSize = true;
            this.label_Password_Water.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Password_Water.Location = new System.Drawing.Point(228, 121);
            this.label_Password_Water.Name = "label_Password_Water";
            this.label_Password_Water.Size = new System.Drawing.Size(67, 15);
            this.label_Password_Water.TabIndex = 5;
            this.label_Password_Water.Text = "输入密码";
            this.label_Password_Water.Click += new System.EventHandler(this.label_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 285);
            this.Controls.Add(this.label_Password_Water);
            this.Controls.Add(this.label_UserName_Water);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_UserName_Water;
        private System.Windows.Forms.Label label_Password_Water;
    }
}

