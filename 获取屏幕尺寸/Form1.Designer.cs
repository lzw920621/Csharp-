namespace 获取屏幕尺寸
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_width1 = new System.Windows.Forms.TextBox();
            this.textBox_height1 = new System.Windows.Forms.TextBox();
            this.textBox_height2 = new System.Windows.Forms.TextBox();
            this.textBox_width2 = new System.Windows.Forms.TextBox();
            this.textBox_height3 = new System.Windows.Forms.TextBox();
            this.textBox_width3 = new System.Windows.Forms.TextBox();
            this.textBox_height4 = new System.Windows.Forms.TextBox();
            this.textBox_width4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_GetScreenInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "主显示器完整尺寸 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "宽 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "高 :";
            // 
            // textBox_width1
            // 
            this.textBox_width1.Location = new System.Drawing.Point(329, 57);
            this.textBox_width1.Name = "textBox_width1";
            this.textBox_width1.Size = new System.Drawing.Size(137, 25);
            this.textBox_width1.TabIndex = 3;
            // 
            // textBox_height1
            // 
            this.textBox_height1.Location = new System.Drawing.Point(490, 57);
            this.textBox_height1.Name = "textBox_height1";
            this.textBox_height1.Size = new System.Drawing.Size(137, 25);
            this.textBox_height1.TabIndex = 4;
            // 
            // textBox_height2
            // 
            this.textBox_height2.Location = new System.Drawing.Point(490, 125);
            this.textBox_height2.Name = "textBox_height2";
            this.textBox_height2.Size = new System.Drawing.Size(137, 25);
            this.textBox_height2.TabIndex = 6;
            // 
            // textBox_width2
            // 
            this.textBox_width2.Location = new System.Drawing.Point(329, 125);
            this.textBox_width2.Name = "textBox_width2";
            this.textBox_width2.Size = new System.Drawing.Size(137, 25);
            this.textBox_width2.TabIndex = 5;
            // 
            // textBox_height3
            // 
            this.textBox_height3.Location = new System.Drawing.Point(490, 189);
            this.textBox_height3.Name = "textBox_height3";
            this.textBox_height3.Size = new System.Drawing.Size(137, 25);
            this.textBox_height3.TabIndex = 8;
            // 
            // textBox_width3
            // 
            this.textBox_width3.Location = new System.Drawing.Point(329, 189);
            this.textBox_width3.Name = "textBox_width3";
            this.textBox_width3.Size = new System.Drawing.Size(137, 25);
            this.textBox_width3.TabIndex = 7;
            // 
            // textBox_height4
            // 
            this.textBox_height4.Location = new System.Drawing.Point(490, 252);
            this.textBox_height4.Name = "textBox_height4";
            this.textBox_height4.Size = new System.Drawing.Size(137, 25);
            this.textBox_height4.TabIndex = 10;
            // 
            // textBox_width4
            // 
            this.textBox_width4.Location = new System.Drawing.Point(329, 252);
            this.textBox_width4.Name = "textBox_width4";
            this.textBox_width4.Size = new System.Drawing.Size(137, 25);
            this.textBox_width4.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "主显示器工作尺寸（排除任务栏、工具栏）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "当前显示器完整尺寸：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "当前显示器工作尺寸（排除任务栏、工具栏）：";
            // 
            // button_GetScreenInfo
            // 
            this.button_GetScreenInfo.Location = new System.Drawing.Point(747, 111);
            this.button_GetScreenInfo.Name = "button_GetScreenInfo";
            this.button_GetScreenInfo.Size = new System.Drawing.Size(75, 93);
            this.button_GetScreenInfo.TabIndex = 14;
            this.button_GetScreenInfo.Text = "获取";
            this.button_GetScreenInfo.UseVisualStyleBackColor = true;
            this.button_GetScreenInfo.Click += new System.EventHandler(this.button_GetScreenInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 340);
            this.Controls.Add(this.button_GetScreenInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_height4);
            this.Controls.Add(this.textBox_width4);
            this.Controls.Add(this.textBox_height3);
            this.Controls.Add(this.textBox_width3);
            this.Controls.Add(this.textBox_height2);
            this.Controls.Add(this.textBox_width2);
            this.Controls.Add(this.textBox_height1);
            this.Controls.Add(this.textBox_width1);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_width1;
        private System.Windows.Forms.TextBox textBox_height1;
        private System.Windows.Forms.TextBox textBox_height2;
        private System.Windows.Forms.TextBox textBox_width2;
        private System.Windows.Forms.TextBox textBox_height3;
        private System.Windows.Forms.TextBox textBox_width3;
        private System.Windows.Forms.TextBox textBox_height4;
        private System.Windows.Forms.TextBox textBox_width4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_GetScreenInfo;
    }
}

