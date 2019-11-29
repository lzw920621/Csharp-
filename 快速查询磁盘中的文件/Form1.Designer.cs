namespace 快速查询磁盘中的文件
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
            this.listBox_File_List = new System.Windows.Forms.ListBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_Dir = new System.Windows.Forms.TextBox();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox_File_List
            // 
            this.listBox_File_List.FormattingEnabled = true;
            this.listBox_File_List.ItemHeight = 15;
            this.listBox_File_List.Location = new System.Drawing.Point(54, 75);
            this.listBox_File_List.Name = "listBox_File_List";
            this.listBox_File_List.Size = new System.Drawing.Size(588, 334);
            this.listBox_File_List.TabIndex = 0;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(661, 35);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(109, 64);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = "查询";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_Dir
            // 
            this.textBox_Dir.Location = new System.Drawing.Point(54, 35);
            this.textBox_Dir.Name = "textBox_Dir";
            this.textBox_Dir.Size = new System.Drawing.Size(588, 25);
            this.textBox_Dir.TabIndex = 2;
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(54, 416);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(100, 25);
            this.textBox_Count.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 467);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.textBox_Dir);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.listBox_File_List);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_File_List;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_Dir;
        private System.Windows.Forms.TextBox textBox_Count;
    }
}

