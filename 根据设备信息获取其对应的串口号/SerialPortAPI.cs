using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;


namespace 根据设备信息获取其对应的串口号
{
    class SerialPortAPI
    {
        /// <summary>
        /// 通过pid vid 获取串口号
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="vid"></param>
        /// <returns></returns>
        public static string GetCOM_By_VID_PID(string pid,string vid)
        {
            string com = null;
            string deviceName = null;
            try
            {
                //搜索设备管理器中的所有条目
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null)
                        {
                            if (hardInfo.Properties["Name"].Value.ToString().Contains("COM") 
                                && hardInfo.Properties["DeviceID"].Value.ToString().Contains(vid)
                                && hardInfo.Properties["DeviceID"].Value.ToString().Contains(pid))
                            {
                                deviceName = hardInfo.Properties["Name"].Value.ToString();
                                break;
                            }
                        }
                    }
                    searcher.Dispose();
                }
            }
            catch
            {
                return null;
            }
            if(deviceName!=null)
            {
                com=deviceName.Substring(deviceName.IndexOf('(') + 1, deviceName.IndexOf(')') - deviceName.IndexOf('(') - 1);
            }
            return com;
        }

        /// <summary>
        /// 通过设备在设备管理器中的名称来获取其对应的串口号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCOM_By_DeviceManagerName(string name)
        {
            string com = null;
            List<string> coms = new List<string>();

            try
            {
                //搜索设备管理器中的所有条目
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null)
                        {
                            if (hardInfo.Properties["Name"].Value.ToString().Contains("COM"))
                            {
                                coms.Add(hardInfo.Properties["Name"].Value.ToString());
                            }
                        }
                    }
                    searcher.Dispose();
                }
            }
            catch
            {
                return null;
            }
           
            foreach (string portName in coms)
            {
                if (portName.Contains(name))
                {
                    com = portName.Substring(portName.IndexOf('(') + 1, portName.IndexOf(')') - portName.IndexOf('(') - 1);
                }
            }            
            return com;
        }
    }
}
