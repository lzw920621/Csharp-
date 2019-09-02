using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取电脑连接的所有设备的信息
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = HardwareInfo.MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");
        }
    }
}
