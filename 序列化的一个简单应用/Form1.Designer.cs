namespace 序列化的一个简单应用
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
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Context = new System.Windows.Forms.TextBox();
            this.listBox_TitleList = new System.Windows.Forms.ListBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(84, 12);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(279, 25);
            this.tb_Title.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "标题 :";
            // 
            // tb_Context
            // 
            this.tb_Context.Location = new System.Drawing.Point(17, 55);
            this.tb_Context.Multiline = true;
            this.tb_Context.Name = "tb_Context";
            this.tb_Context.Size = new System.Drawing.Size(346, 326);
            this.tb_Context.TabIndex = 2;
            // 
            // listBox_TitleList
            // 
            this.listBox_TitleList.FormattingEnabled = true;
            this.listBox_TitleList.ItemHeight = 15;
            this.listBox_TitleList.Location = new System.Drawing.Point(397, 59);
            this.listBox_TitleList.Name = "listBox_TitleList";
            this.listBox_TitleList.Size = new System.Drawing.Size(255, 394);
            this.listBox_TitleList.TabIndex = 3;
            this.listBox_TitleList.SelectedIndexChanged += new System.EventHandler(this.listBox_TitleList_SelectedIndexChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(17, 404);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(346, 49);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "日记标题列表 :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 496);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.listBox_TitleList);
            this.Controls.Add(this.tb_Context);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Context;
        private System.Windows.Forms.ListBox listBox_TitleList;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label2;
    }
}

