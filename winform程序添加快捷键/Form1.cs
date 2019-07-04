using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform程序添加快捷键
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //首先在form_load的时候写上this.KeyPreview = true;表示窗体接受按键事件
            this.KeyPreview = true;//当前窗体接受按键事件,如果没有这一项,那么当焦点在某个控件上时就无法响应按键了
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers==Keys.Control&&e.KeyCode==Keys.S)//按下ctrl+S
            {
                MessageBox.Show("你按下了ctrl+S");
            }
        }
    }
}
