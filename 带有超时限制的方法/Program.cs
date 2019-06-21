using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using USB_HID;

namespace 带有超时限制的方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    CallWithTimeout(() => Thread.Sleep(5000), 3000);
            //}
            //catch(TimeoutException exp)
            //{
            //    Console.WriteLine("已超时");
            //}
            //Console.ReadKey();

            bool isOpenDeviceSucess = USBDeviceReadAndWrite("#vid_0a12");
            string bluetoothAdress = "";
            if (isOpenDeviceSucess==true)//打开设备读写成功
            {
                Console.WriteLine("打开设备读写成功");
                try
                {
                    byte[] byteArray = clsHID.USBDateRead(4000);                 
                    if (byteArray[0] == 0 && byteArray[1] == 0xcf && byteArray[2] == 0x03 && byteArray[3] == 0x4b)
                    {
                        bluetoothAdress = byteArray[4].ToString("X2") + byteArray[5].ToString("X2") + byteArray[6].ToString("X2") + byteArray[7].ToString("X2") + byteArray[8].ToString("X2") + byteArray[9].ToString("X2");
                    }
                    Console.WriteLine("蓝牙地址是 :" + bluetoothAdress);
                }
                catch(TimeoutException exp)
                {
                    Console.WriteLine("读取超时");
                }                
            }
            else
            {
                Console.WriteLine("打开设备读写失败");
            }

            DisposeUSB();
            Console.ReadKey();
        }

        /// <summary>
        /// 带超时限制的方法
        /// </summary>
        /// <param name="action">要执行的方法</param>
        /// <param name="timeoutMilliseconds">超时时间</param>
        static void CallWithTimeout(Action action, int timeoutMilliseconds)
        {
            Thread threadToKill = null;
            Action wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                action();
            };

            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                threadToKill.Abort();
                throw new TimeoutException("限制时间内未响应");
            }
        }



        static ClsHID clsHID;
        /// <summary>
        /// 打开usb设备读写
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <returns>是否成功</returns>
        static bool USBDeviceReadAndWrite(string deviceInfo)//deviceinfo="#vid_0a12"
        {
            DisposeUSB();
            clsHID = new ClsHID();
            foreach (var item in ClsHID.GetHIDInfo())
            {
                if (item.ToString().Contains(deviceInfo))
                {
                    try
                    {
                        clsHID.CT_CreateFileReadWrite(item.ToString());//打开设备读写
                    }
                    catch
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        static void DisposeUSB()
        {
            if (clsHID != null)
            {
                clsHID.Dispost();
            }
        }
        /// <summary>
        /// 获取蓝牙地址
        /// </summary>
        /// <returns></returns>        
        public string GetBluetoothAdressByHID(string deviceInfo, byte[] hid)//byte[] {0X00,0xce, 0x02, 0x4b}
        {
            string bluetoothAdress = "";

            bool isSuccess = USBDeviceReadAndWrite(deviceInfo);//打开设备读写

            if (isSuccess)
            {
                for (int i = 0; i < 10; i++)
                {
                    clsHID.USBDataWrite(hid);
                    byte[] outData;
                    Thread.Sleep(100);
                    if (clsHID.USBDataRead(out outData))
                    {
                        if (outData[0] == 0 && outData[1] == 0xcf && outData[2] == 0x03 && outData[3] == 0x4b)
                        {
                            bluetoothAdress = outData[4].ToString("X2") + outData[5].ToString("X2") + outData[6].ToString("X2") + outData[7].ToString("X2") + outData[8].ToString("X2") + outData[9].ToString("X2");

                            break;
                        }
                    }
                }
            }
            else
            {
                clsHID.Dispost();//释放usb设备资源                
            }
            return bluetoothAdress;
        }

        
    }
}
