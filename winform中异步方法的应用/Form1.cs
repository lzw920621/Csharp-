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
            richTextBox1.Text = DateTime.Now + " : " + "异步方法内部,await之前  当前线程id : " + Thread.CurrentThread.ManagedThreadId;
            await Task.Run(() =>
            {
                int id= Thread.CurrentThread.ManagedThreadId;
                this.BeginInvoke(new Action(() => { richTextBox1.Text += "\r\n"+ DateTime.Now + " : " + "正在执行耗时操作 当前线程ID:" + id; }));
                Thread.Sleep(5000);
                id = Thread.CurrentThread.ManagedThreadId;
                this.BeginInvoke(new Action(() => { richTextBox1.Text += "\r\n" + DateTime.Now + " : " + "耗时操作结束 当前线程ID:" + id; }));

            });
            richTextBox1.Text += "\r\n" + DateTime.Now + " : " + "异步方法内部,await 之后  当前线程id : " + Thread.CurrentThread.ManagedThreadId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
