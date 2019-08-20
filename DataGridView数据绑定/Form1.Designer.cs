namespace DataGridView数据绑定
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Add_Customer = new System.Windows.Forms.Button();
            this.btn_Delete_Customer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(511, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_Add_Customer
            // 
            this.btn_Add_Customer.Location = new System.Drawing.Point(658, 47);
            this.btn_Add_Customer.Name = "btn_Add_Customer";
            this.btn_Add_Customer.Size = new System.Drawing.Size(91, 49);
            this.btn_Add_Customer.TabIndex = 1;
            this.btn_Add_Customer.Text = "添加顾客";
            this.btn_Add_Customer.UseVisualStyleBackColor = true;
            this.btn_Add_Customer.Click += new System.EventHandler(this.btn_Add_Customer_Click);
            // 
            // btn_Delete_Customer
            // 
            this.btn_Delete_Customer.Location = new System.Drawing.Point(658, 123);
            this.btn_Delete_Customer.Name = "btn_Delete_Customer";
            this.btn_Delete_Customer.Size = new System.Drawing.Size(91, 49);
            this.btn_Delete_Customer.TabIndex = 2;
            this.btn_Delete_Customer.Text = "删除顾客";
            this.btn_Delete_Customer.UseVisualStyleBackColor = true;
            this.btn_Delete_Customer.Click += new System.EventHandler(this.btn_Delete_Customer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Delete_Customer);
            this.Controls.Add(this.btn_Add_Customer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Add_Customer;
        private System.Windows.Forms.Button btn_Delete_Customer;
    }
}

