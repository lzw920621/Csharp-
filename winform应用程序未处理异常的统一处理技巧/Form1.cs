using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace winform应用程序未处理异常的统一处理技巧
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int n = 0;
            int num = 10 / n;

            Thread th = new Thread(Method);
            th.Start();
        }

        void Method()
        {
            throw new Exception("非UI线程 执行任务异常");
        }
    }
}
