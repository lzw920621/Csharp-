using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 子窗体控制父窗体显示和隐藏
{
    /*
    实现这样一个功能：当父窗体打开一个子窗体时隐藏父窗体的Panel，而当子窗体关闭时让Panel显示。
    实现的主要思路是创建一个子窗体的父类并在类中声明一个委托，当父窗体调用子窗体时绑定显示Panel的方法
    */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void btn_Open_Child_Panel_Click(object sender, EventArgs e)
        {
            CreatChildForm(new ChildForm());
        }

        private void CreatChildForm(ChildForm childform)
        {
            childform.MdiParent = this;
            childform.MyHandler += this.ShowMainForm;
            this.panel1.Visible = false;
            childform.Show();
        }

        void ShowMainForm()
        {
            this.panel1.Visible = true;

        }
    }
}
