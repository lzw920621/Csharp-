using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 根据设备信息获取其对应的串口号
{
    class Program
    {
        static void Main(string[] args)
        {
            string com = SerialPortAPI.GetCOM_By_DeviceManagerName("USB Composite Device");
        }
    }
}
