using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取当前的操作系统信息
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取系统信息
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            //获取操作系统ID
            System.PlatformID platformID = osInfo.Platform;
            //获取主版本号
            int versionMajor = osInfo.Version.Major;
            //获取副版本号
            int versionMinor = osInfo.Version.Minor;
        }
    }
}
