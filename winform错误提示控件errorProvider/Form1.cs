using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform错误提示控件errorProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "123")
            {
                this.errorProvider1.SetError(this.textBox1, "输入有误");
                DialogResult ReturnDlg = MessageBox.Show(this, "输入有误，是否重新输入", "信息提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                switch (ReturnDlg)
                {
                    case DialogResult.Retry:
                        this.textBox1.Text = "";
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                this.errorProvider1.SetError(this.textBox1,null);//用null或string.Empty来消除错误
                //this.errorProvider1.Clear();
            }
        }
    }
}
