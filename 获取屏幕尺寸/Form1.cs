using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 获取屏幕尺寸
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_GetScreenInfo_Click(object sender, EventArgs e)
        {
            //主显示器完整尺寸
            this.textBox_width1.Text = Screen.PrimaryScreen.Bounds.Width+"";
            this.textBox_height1.Text = Screen.PrimaryScreen.Bounds.Height + "";
            //主显示器工作尺寸（排除任务栏、工具栏）
            this.textBox_width2.Text = Screen.PrimaryScreen.WorkingArea.Width + "";
            this.textBox_height2.Text = Screen.PrimaryScreen.WorkingArea.Height + "";
            //当前显示器完整尺寸
            this.textBox_width3.Text = Screen.GetBounds(this).Width + "";
            this.textBox_height3.Text = Screen.GetBounds(this).Height + "";
            //当前显示器工作尺寸（排除任务栏、工具栏）
            this.textBox_width4.Text = Screen.GetWorkingArea(this).Width + "";
            this.textBox_height4.Text = Screen.GetWorkingArea(this).Height + "";
        }
    }
}
