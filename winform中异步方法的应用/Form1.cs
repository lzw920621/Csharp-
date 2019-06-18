using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace winform中异步方法的应用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_Change_Txtbox_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "异步方法内部,await之前  当前线程id : " + Thread.CurrentThread.ManagedThreadId + "当前时间 : " + DateTime.Now;
            await Task.Run(() =>
            {
                //richTextBox1.Text += "进入 await 内部  当前线程id : " + Thread.CurrentThread.ManagedThreadId + "当前时间 : " + DateTime.Now;
                Thread.Sleep(3000);
               
                //richTextBox1.Text += "进入 await 内部  当前线程id : " + Thread.CurrentThread.ManagedThreadId + "当前时间 : " + DateTime.Now;
            });
            richTextBox1.Text += "\r\nawait 之后  当前线程id : " + Thread.CurrentThread.ManagedThreadId + "当前时间 : " + DateTime.Now;
        }
    }
}
