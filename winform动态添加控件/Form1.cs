using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform动态添加控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Button button1 = new Button();
            button1.Location = new System.Drawing.Point(373, 88);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            this.Controls.Add(button1);//这一步很重要,要不然控件不会显示在窗体上

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(373, 200);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            this.Controls.Add(label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
