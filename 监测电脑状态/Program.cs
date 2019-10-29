using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 监测电脑状态
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("是否已联网:" + DeviceMonitor.GetInternetAvilable());
            Console.WriteLine("系统运行时间:" + DeviceMonitor.GetSystemUpTime());
            Console.WriteLine("物理内存大小:" + DeviceMonitor.GetPhysicalMemory());
            Console.WriteLine("可用内存大小:" + DeviceMonitor.getAvailableRAM());
            Console.WriteLine("CPU占用率:" + DeviceMonitor.getCurrentCpuUsage());

            Console.ReadKey();
        }
    }
}
