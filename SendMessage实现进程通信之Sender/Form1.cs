using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SendMessage实现进程通信之Sender
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcesses();
            foreach (Process p in procs)
            {
                if (p.ProcessName.Equals("SendMessage实现进程通信之Receiver"))
                {
                    IntPtr hWnd = p.MainWindowHandle;
                    int data = Convert.ToInt32(txtMsg.Text);//未做数据校验
                    SendMessage(hWnd, WM_KEYDOWN, (IntPtr)data, (IntPtr)0);
                    Thread.Sleep(1000);
                    SendMessage(hWnd, WM_KEYUP, (IntPtr)0, (IntPtr)0);
                }
            }
        }
    }
}
