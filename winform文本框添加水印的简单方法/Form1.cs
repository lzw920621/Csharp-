using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform文本框添加水印的简单方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        private void TextChanged(object sender,EventArgs e)
        {
            if(sender.Equals(textBox_UserName))
            {
                label_UserName_Water.Visible = textBox_UserName.Text.Length < 1;
            }
            else if(sender.Equals(textBox_Password))
            {
                label_Password_Water.Visible = textBox_Password.Text.Length < 1;
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (sender.Equals(label_UserName_Water))
            {
                textBox_UserName.Select();
            }
            else if (sender.Equals(label_Password_Water))
            {
                textBox_Password.Select();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
