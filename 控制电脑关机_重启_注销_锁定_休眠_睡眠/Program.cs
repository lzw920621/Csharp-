using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace 控制电脑关机_重启_注销_锁定_休眠_睡眠
{
    class Program
    {
        ////注销
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        //锁定
        [DllImport("user32")]
        public static extern void LockWorkStation();


        //休眠和睡眠
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);


        static void Main(string[] args)
        {
            //关机
            // 参数 /s 的意思是要关闭计算机
            // 参数 /t 0 的意思是告诉计算机 0 秒之后执行命令
            Process.Start("shutdown", "/s /t 0");

            //重启
            // 参数 /r 的意思是要重新启动计算机
            Process.Start("shutdown", "/r /t 0");

            //注销
            ExitWindowsEx(0, 0);

            //锁定
            LockWorkStation();

            //休眠
            SetSuspendState(true, true, true);

            //睡眠
            SetSuspendState(false, true, true);

        }
    }
}
