using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 控制显示器的开启和关闭
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorControler.Off();
            Thread.Sleep(2000);
            MonitorControler.On();

            Console.ReadKey();

        }
    }

    public static class MonitorControler
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;

        enum MonitorMode : int
        {
            ON = -1,
            STANBY = 1,
            OFF = 2,
        }

        static void ChangeMonitorState(MonitorMode mode)
        {
            SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, (int)mode);
        }

        public static void Off()
        {
            ChangeMonitorState(MonitorMode.OFF);
        }

        public static void On()
        {
            ChangeMonitorState(MonitorMode.ON);
        }

        public static void StandBy()
        {
            ChangeMonitorState(MonitorMode.STANBY);
        }
    }
}
