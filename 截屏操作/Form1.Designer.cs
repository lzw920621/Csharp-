namespace 截屏操作
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
            this.button_ScreenShoot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ScreenShoot
            // 
            this.button_ScreenShoot.Location = new System.Drawing.Point(281, 102);
            this.button_ScreenShoot.Name = "button_ScreenShoot";
            this.button_ScreenShoot.Size = new System.Drawing.Size(181, 63);
            this.button_ScreenShoot.TabIndex = 0;
            this.button_ScreenShoot.Text = "截屏";
            this.button_ScreenShoot.UseVisualStyleBackColor = true;
            this.button_ScreenShoot.Click += new System.EventHandler(this.button_ScreenShoot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.button_ScreenShoot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ScreenShoot;
    }
}

