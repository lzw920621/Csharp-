using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform停止窗口关闭事件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("确定关闭当前窗体吗?","提示",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
