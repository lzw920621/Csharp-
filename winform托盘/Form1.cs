using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform托盘
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //恢复窗体显示
            if (this.WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                this.WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                //notifyIcon1.Visible = false;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //恢复窗体显示
            if (this.WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                this.WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                //notifyIcon1.Visible = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "我的托盘程序";//鼠标放在托盘时显示的文字
            
            notifyIcon1.BalloonTipText = "双击可打开";//气泡显示的文字
            notifyIcon1.BalloonTipTitle = "提示";
            //notifyIcon1.ShowBalloonTip(1000);//托盘气泡的显现时间
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
                
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //任务栏区显示图标
                this.ShowInTaskbar = false;
                notifyIcon1.ShowBalloonTip(2000);//托盘气泡的显现时间
            }
        }
    }
}
