using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform程序禁止多开
{
    static class Program
    {
        

        [STAThread]
        static void Main()
        {
            //方式1 启动的时候，检测是否存在同样的进程名，防止程序多开

            //string processName = Process.GetCurrentProcess().ProcessName;
            //Process[] processes = Process.GetProcessesByName(processName);
            ////如果该数组长度大于1，说明多次运行
            //if (processes.Length > 1)
            //{
            //    MessageBox.Show("程序已运行，不能再次打开！");
            //    Environment.Exit(1);
            //}
            //else
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new Form1());
            //}


            //方式2 利用Mutex互斥对象防止程序多开

            bool isAppRunning = false;
            Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isAppRunning);
            if (!isAppRunning)
            {
                MessageBox.Show("程序已运行，不能再次打开！");
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
