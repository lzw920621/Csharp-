using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform取消方向键对控件焦点控制的实现方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//取消方向键对控件的焦点的控件，用自己自定义的函数处理各个方向键的处理函数
        {
            //使用return true 表示对按键的响应不继续处理，直接返回，这样就可以避免了方向键对控件焦点的控制
            switch (keyData)
            {
                case Keys.Up:
                    //UpKey();
                    return true;//不继续处理
                case Keys.Down:
                    //DownKey();
                    return true;
                case Keys.Left:
                    //LeftKey();
                    return true;
                case Keys.Right:
                    //RightKey();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
