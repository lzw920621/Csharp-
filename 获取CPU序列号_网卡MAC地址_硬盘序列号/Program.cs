using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace 获取CPU序列号_网卡MAC地址_硬盘序列号
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HostName:{0}", HardwareInfo.GethostName());
            Console.WriteLine("CPU:{0}", HardwareInfo.GetCPUSerialNumber());
            Console.WriteLine("Harddisk:{0}", HardwareInfo.GetDiskSerialNumber());
            Console.WriteLine("MAC:{0}", HardwareInfo.GetMacAddress());
            Console.ReadLine();
        }
    }

    class HardwareInfo
    {
        /// <summary>
        /// 取机器名
        /// </summary>
        /// <returns></returns>
        public static string GethostName()
        {
            return System.Net.Dns.GetHostName();
        }

        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCPUSerialNumber()
        {
            string cpuSerialNumber = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuSerialNumber = mo["ProcessorId"].ToString();
                break;
            }
            mc.Dispose();
            moc.Dispose();
            return cpuSerialNumber;
        }

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskSerialNumber()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher();
            mos.Query = new SelectQuery("Win32_DiskDrive", "", new string[] { "PNPDeviceID", "Signature" });
            ManagementObjectCollection myCollection = mos.Get();
            ManagementObjectCollection.ManagementObjectEnumerator em = myCollection.GetEnumerator();
            em.MoveNext();
            ManagementBaseObject moo = em.Current;
            string id = moo.Properties["signature"].Value.ToString().Trim();
            return id;
        }


        /// <summary>
        /// 获取网卡MAC地址 
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            string _MacAddress = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                    _MacAddress = mo["MacAddress"].ToString();
                mo.Dispose();
            }
            return _MacAddress.ToString();
        }
    }
}
