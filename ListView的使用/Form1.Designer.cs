namespace ListView的使用
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_Delete_Item = new System.Windows.Forms.Button();
            this.btn_Add_Item = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(27, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(535, 349);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Delete_Item
            // 
            this.btn_Delete_Item.Location = new System.Drawing.Point(623, 27);
            this.btn_Delete_Item.Name = "btn_Delete_Item";
            this.btn_Delete_Item.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete_Item.TabIndex = 1;
            this.btn_Delete_Item.Text = "删除";
            this.btn_Delete_Item.UseVisualStyleBackColor = true;
            // 
            // btn_Add_Item
            // 
            this.btn_Add_Item.Location = new System.Drawing.Point(623, 76);
            this.btn_Add_Item.Name = "btn_Add_Item";
            this.btn_Add_Item.Size = new System.Drawing.Size(75, 23);
            this.btn_Add_Item.TabIndex = 2;
            this.btn_Add_Item.Text = "添加";
            this.btn_Add_Item.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(623, 121);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(623, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 407);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Add_Item);
            this.Controls.Add(this.btn_Delete_Item);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_Delete_Item;
        private System.Windows.Forms.Button btn_Add_Item;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button button4;
    }
}

