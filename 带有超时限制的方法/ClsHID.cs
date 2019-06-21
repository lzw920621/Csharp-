using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;
using System.IO;
using Microsoft.Win32.SafeHandles;


namespace USB_HID
{
    public class ClsHID
    {
        //以下是调用windows的API的函数

        //获得GUID
        [DllImport("hid.dll")]
        public static extern void HidD_GetHidGuid(ref Guid HidGuid);
        Guid guidHID = Guid.Empty;
        //过滤设备，获取需要的设备
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, uint Enumerator, IntPtr HwndParent, DIGCF Flags);

        //获取设备，true获取到
        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        public struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid interfaceClassGuid;
            public int flags;
            public int reserved;
        }

        // 获取接口的详细信息 必须调用两次 第1次返回长度 第2次获取数据 
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr deviceInfoSet, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData,
             int deviceInterfaceDetailDataSize, ref int requiredSize, SP_DEVINFO_DATA deviceInfoData);
        [StructLayout(LayoutKind.Sequential)]
        public class SP_DEVINFO_DATA
        {
            public int cbSize = Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
            public Guid classGuid = Guid.Empty; // temp
            public int devInst = 0; // dumy
            public int reserved = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            internal int cbSize;
            internal short devicePath;
        }
        public enum DIGCF
        {
            DIGCF_DEFAULT = 0x1,
            DIGCF_PRESENT = 0x2,
            DIGCF_ALLCLASSES = 0x4,
            DIGCF_PROFILE = 0x8,
            DIGCF_DEVICEINTERFACE = 0x10
        }

        //获取设备文件
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
                string lpFileName,                            // file name
               uint dwDesiredAccess,                        // access mode
               uint dwShareMode,                            // share mode
               uint lpSecurityAttributes,                    // SD
               uint dwCreationDisposition,                    // how to create
               uint dwFlagsAndAttributes,                    // file attributes
               uint hTemplateFile                            // handle to template file
             );

        //读取设备文件
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool ReadFile
             (
                 IntPtr hFile,
                 byte[] lpBuffer,
                 uint nNumberOfBytesToRead,
                 ref uint lpNumberOfBytesRead,
                 IntPtr lpOverlapped
             );

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool WriteFile   //这个功能未经过测试 20180512
            (
        IntPtr hFile,
        byte[] lpBuffer,
        uint nNumberOfBytesToWrite,
        ref uint lpNumberOfBytesWritten,
        IntPtr lpOverlapped
        );


        [DllImport("hid.dll")]
        private static extern Boolean HidD_GetAttributes(IntPtr hidDevice, out HID_ATTRIBUTES attributes);

        //获取设备具体信息   
        //    [DllImport("hid.dll", SetLastError = true)]
        //   private unsafe static extern int HidP_GetCaps(int pPHIDP_PREPARSED_DATA, ref HIDP_CAPS myPHIDP_CAPS);      
        // IN PHIDP_PREPARSED_DATA  PreparsedData,   
        // OUT PHIDP_CAPS  Capabilities   

        //   [DllImport("hid.dll", SetLastError = true)]
        //   private unsafe static extern int HidD_GetPreparsedData( int hObject,  ref int pPHIDP_PREPARSED_DATA); // IN HANDLE  HidDeviceObject, 


        [DllImport("hid.dll")]
        private static extern Boolean HidD_GetPreparsedData(IntPtr hidDeviceObject, out IntPtr PreparsedData);

        [DllImport("hid.dll")]
        private static extern uint HidP_GetCaps(IntPtr PreparsedData, out HIDP_CAPS Capabilities);



        [DllImport("hid.dll")]
        private static extern Boolean HidD_FreePreparsedData(IntPtr PreparsedData);

        //释放设备
        [DllImport("hid.dll")]
        static public extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

        //关闭访问设备句柄，结束进程的时候把这个加上保险点
        [DllImport("kernel32.dll")]
        static public extern int CloseHandle(int hObject);
        public struct HID_ATTRIBUTES
        {
            public int Size;

            public ushort VendorID;

            public ushort ProductID;

            public ushort VersionNumber;

        }


        // HIDP_CAPS   
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct HIDP_CAPS
        {
            public System.UInt16 Usage;                    // USHORT   
            public System.UInt16 UsagePage;                // USHORT   
            public System.UInt16 InputReportByteLength;
            public System.UInt16 OutputReportByteLength;
            public System.UInt16 FeatureReportByteLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public System.UInt16[] Reserved;                // USHORT  Reserved[17];               
            public System.UInt16 NumberLinkCollectionNodes;
            public System.UInt16 NumberInputButtonCaps;
            public System.UInt16 NumberInputValueCaps;
            public System.UInt16 NumberInputDataIndices;
            public System.UInt16 NumberOutputButtonCaps;
            public System.UInt16 NumberOutputValueCaps;
            public System.UInt16 NumberOutputDataIndices;
            public System.UInt16 NumberFeatureButtonCaps;
            public System.UInt16 NumberFeatureValueCaps;
            public System.UInt16 NumberFeatureDataIndices;
        }

        //释放设备的访问
        // [DllImport("kernel32.dll")]
        //  internal static extern int CloseHandle(int hObject);
        //释放设备
        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern IntPtr SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
        //代码暂时没有整理，传入参数是设备序号,
        //有些USB设备其实有很多HID设备，就是一个接口上有几个设备，这个时候需要
        //用index++来逐个循环，直到获取设备返回false后，跳出去，把获取的设备
        //路径全记录下来就好了，我这里知道具体设备号，所以没有循环，浪费我时间

        //定于句柄序号和一些参数，具体可以去网上找这些API的参数说明，后文我看能不能把资料也写上去
        IntPtr hDevInfo;
        int HidHandle = -1;
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const int OPEN_EXISTING = 3;

        private int outputReportLength;
        private int inputReportLenght;
        private FileStream hidDevice;
        private const int MAX_USB_DEVICES = 64;

        /*
         *********************************
         * 以上内容为系统功能
         * 以下为应用扩展功能
         * 1、搜寻设备
         * 2、打开设备
         * 3、写入设备指令、文件
         * 4、读取设备文件指令 // 独占式的，小心用
         * 5、释放设备
         ******************************* *
         * 
         */
        public void UsBMethod(int index)
        {
            HidD_GetHidGuid(ref guidHID);
            hDevInfo = SetupDiGetClassDevs(ref guidHID, 0, IntPtr.Zero, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
            int bufferSize = 0;
            ArrayList HIDUSBAddress = new ArrayList();

            //while (true)
            //{
            //获取设备，true获取到
            SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new SP_DEVICE_INTERFACE_DATA();
            DeviceInterfaceData.cbSize = Marshal.SizeOf(DeviceInterfaceData);
            //for (int i = 0; i < 3; i++)
            //{
            bool result = SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref guidHID, (UInt32)index, ref DeviceInterfaceData);
            //}
            //第一次调用出错，但可以返回正确的Size 
            SP_DEVINFO_DATA strtInterfaceData = new SP_DEVINFO_DATA();
            result = SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, strtInterfaceData);
            //第二次调用传递返回值，调用即可成功
            IntPtr detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
            SP_DEVICE_INTERFACE_DETAIL_DATA detailData = new SP_DEVICE_INTERFACE_DETAIL_DATA();
            detailData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DETAIL_DATA));
            Marshal.StructureToPtr(detailData, detailDataBuffer, false);
            result = SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, strtInterfaceData);
            if (result == false)
            {
                //break;
            }
            //获取设备路径访
            IntPtr pdevicePathName = (IntPtr)((int)detailDataBuffer + 4);
            string devicePathName = Marshal.PtrToStringAuto(pdevicePathName);
            HIDUSBAddress.Add(devicePathName);
            //index++;
            //break;
            //}
            bool bb = USBDataRead(HidHandle);
            //连接设备文件   \\\\?\\hid#vid_0a12&pid_1111#7&24f3a59d&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}
            devicePathName = "\\\\?\\hid#vid_0a12&pid_1111#7&24f3a59d&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}";


        }

        /// <summary>
        /// 搜寻HID设备
        /// </summary>
        /// <returns>HID设备List</returns>
        public static ArrayList GetHIDInfo()
        {
            IntPtr hDevInfo;
            int index = 0;

            Guid guidHID = Guid.Empty;
            ClsHID.HidD_GetHidGuid(ref guidHID);
            hDevInfo = ClsHID.SetupDiGetClassDevs(ref guidHID, 0, IntPtr.Zero, ClsHID.DIGCF.DIGCF_PRESENT | ClsHID.DIGCF.DIGCF_DEVICEINTERFACE);
            int bufferSize = 0;
            ArrayList HIDUSBAddress = new ArrayList();
            while (true)
            {
                ClsHID.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new ClsHID.SP_DEVICE_INTERFACE_DATA();
                DeviceInterfaceData.cbSize = Marshal.SizeOf(DeviceInterfaceData);
                bool result = ClsHID.SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref guidHID, (UInt32)index, ref DeviceInterfaceData);

                //第一次调用出错，但可以返回正确的Size 
                ClsHID.SP_DEVINFO_DATA strtInterfaceData = new ClsHID.SP_DEVINFO_DATA();
                result = ClsHID.SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, strtInterfaceData);
                //第二次调用传递返回值，调用即可成功

                IntPtr detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
                ClsHID.SP_DEVICE_INTERFACE_DETAIL_DATA detailData = new ClsHID.SP_DEVICE_INTERFACE_DETAIL_DATA();
                detailData.cbSize = Marshal.SizeOf(typeof(ClsHID.SP_DEVICE_INTERFACE_DETAIL_DATA));

                Marshal.StructureToPtr(detailData, detailDataBuffer, false);
                result = ClsHID.SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, strtInterfaceData);
                if (result == false)
                {
                    break;
                }
                //获取设备路径访
                IntPtr pdevicePathName = (IntPtr)((int)detailDataBuffer + 4);
                string devicePathName = Marshal.PtrToStringAuto(pdevicePathName);
                HIDUSBAddress.Add(devicePathName);
                index++;
            }

            ClsHID.HidD_FreePreparsedData(hDevInfo);   //释放掉资源
                                                       // clsHID.CloseHandle((int)hDevInfo);

            return HIDUSBAddress;
        }

        /// <summary>
        /// 打开设备，只读方式（鼠标）
        /// </summary>
        /// <param name="DeviceName">HID设备名称</param>
        /// <returns></returns>
        public unsafe IntPtr CT_CreateFile(string DeviceName)
        {
            IntPtr hidHandle = CreateFile(
                  DeviceName,
                  GENERIC_READ,// | GENERIC_WRITE,//读写，或者一起
                 FILE_SHARE_READ,// | FILE_SHARE_WRITE,//共享读写，或者一起
                 0,
                  OPEN_EXISTING,
                  0,
                  0);
            //if (HidHandle == -1)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
            return hidHandle;
        }


        /// <summary>
        /// 打开设备，读写方式（自定义设备）
        /// </summary>
        /// <param name="DeviceName">HID设备名称</param>
        /// <returns></returns>
        public unsafe IntPtr CT_CreateFileReadWrite(string DeviceName)
        {
            IntPtr hidHandle = CreateFile(
                DeviceName,
                    GENERIC_READ | GENERIC_WRITE,//讀寫，或者一起
                   FILE_SHARE_READ | FILE_SHARE_WRITE,//共享讀寫，或者一起
                   0,
                    OPEN_EXISTING,
                    0,
                    0);
            //if (HidHandle == -1)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
            hDevInfo = hidHandle;
            return hidHandle;
        }



        /// <summary>
        /// 
        /// </summary>
        public bool USBDataWrite(byte[] data) //hDevInfo
        {

            try
            {
                // string  devicePathName = "\\\\?\\hid#vid_0a12&pid_1111#7&24f3a59d&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}"; 蓝牙设备
                //  hDevInfo = CT_CreateFile(devicePathName);
                //  hDevInfo = CT_CreateFileReadWrite(devicePathName);
                HID_ATTRIBUTES hid_ATTRIBUTES;
                HidD_GetAttributes(hDevInfo, out hid_ATTRIBUTES);
                IntPtr preparseData = new IntPtr();
                HIDP_CAPS caps = new HIDP_CAPS();
                HidD_GetPreparsedData(hDevInfo, out preparseData);
                try
                {
                    HidP_GetCaps(preparseData, out caps);
                }
                catch (AccessViolationException ex)
                {
                    string a = ex.Message;
                    return false;
                }



                outputReportLength = caps.OutputReportByteLength;
                inputReportLenght = caps.InputReportByteLength;
                hidDevice = new FileStream(new SafeFileHandle(hDevInfo, false), FileAccess.ReadWrite, inputReportLenght, false);

                Array.Resize(ref data, inputReportLenght);   //数据长度由设备决定的
                hidDevice.Write(data, 0, data.Length);
                // USBDataRead((int)hDevInfo);
                // HidD_FreePreparsedData(hDevInfo);
                //  SetupDiDestroyDeviceInfoList(hDevInfo);
                //  hidDevice.Dispose();
                return (inputReportLenght > 0);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }

        }

        public unsafe bool USBDataWrite(string sendValue)
        {
            try
            {
                byte[] data = System.Text.ASCIIEncoding.Default.GetBytes(sendValue);


                //byte[] array = new byte[] { 0x00, 0xce, 0x02, 0x31, 0x00, 0x00, 0x00, 0x00, 
                //        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                //        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                //        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,
                //        };
                HID_ATTRIBUTES hid_ATTRIBUTES;
                HidD_GetAttributes(hDevInfo, out hid_ATTRIBUTES);
                IntPtr preparseData = new IntPtr();
                HIDP_CAPS caps = new HIDP_CAPS();
                HidD_GetPreparsedData(hDevInfo, out preparseData);
                HidP_GetCaps(preparseData, out caps);
                outputReportLength = caps.OutputReportByteLength;
                inputReportLenght = caps.InputReportByteLength;

                hidDevice = new FileStream(new SafeFileHandle(hDevInfo, false), FileAccess.ReadWrite, inputReportLenght, false);

                Array.Resize(ref data, inputReportLenght);   //数据长度由设备决定的
                hidDevice.Write(data, 0, data.Length);
                // USBDataRead((int)hDevInfo);
                // HidD_FreePreparsedData(hDevInfo);
                //  SetupDiDestroyDeviceInfoList(hDevInfo);
                //  hidDevice.Dispose();
                if (inputReportLenght > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //根据CreateFile拿到的设备handle访问文件，并返回数据
        public unsafe bool USBDataRead(int handle)
        {
            int count = 0;
            while (true)
            {
                count++;

                uint read = 0;
                //注意字节的长度，我这里写的是8位，其实可以通过API获取具体的长度，这样安全点，
                //具体方法我知道，但是没有写，过几天整理完代码，一起给出来
                Byte[] m_rd_data = new Byte[33];
                bool isread = ReadFile((IntPtr)handle, m_rd_data, (uint)33, ref read, IntPtr.Zero);      //这是一个独占线程，真正要用的时候要另辟线程或者事件
                                                                                                         //这里已经是拿到的数据了
                Byte[] m_rd_dataout = new Byte[read];
                Array.Copy(m_rd_data, m_rd_dataout, read);
                if (count > 100 || isread)
                    break;
                Thread.Sleep(10);
            }
            return count <= 100;
        }

        public unsafe bool USBDataRead(out byte[] data)
        {

            int count = 0;
            while (true)
            {
                count++;
                uint read = 0;
                //注意字节的长度，我这里写的是8位，其实可以通过API获取具体的长度，这样安全点，
                //具体方法我知道，但是没有写，过几天整理完代码，一起给出来
                Byte[] m_rd_data = new Byte[33];
                bool isread = ReadFile((IntPtr)hDevInfo, m_rd_data, (uint)33, ref read, IntPtr.Zero);      //这是一个独占线程，真正要用的时候要另辟线程或者事件
                                                                                                           //这里已经是拿到的数据了
                Byte[] m_rd_dataout = new Byte[read];
                Array.Copy(m_rd_data, m_rd_dataout, read);
                data = m_rd_dataout;
                if (count > 100 || isread)
                    break;
                Thread.Sleep(10);
            }
            return count <= 100;
        }
        /// <summary>
        /// 读取设备返回的字节数组
        /// </summary>
        /// <param name="timeoutMilliseconds">超时时间</param>
        /// <returns></returns>
        public byte[] USBDateRead(int timeoutMilliseconds)//读取会阻塞当前线程,有时会导致程序卡死,所以加上超时限制
        {
            Thread threadToKill = null;
            Func<byte[]> func = () =>
            {
                threadToKill = Thread.CurrentThread;
                uint read = 0;
                //注意字节的长度，其实可以通过API获取具体的长度，这样安全点，
                Byte[] m_rd_data = new Byte[33];
                bool isread = ReadFile((IntPtr)hDevInfo, m_rd_data, (uint)33, ref read, IntPtr.Zero); //这是一个独占线程，真正要用的时候要另辟线程或者事件
                if (isread == false)
                {
                    return null;
                }
                Byte[] m_rd_dataout = new Byte[read];
                Array.Copy(m_rd_data, m_rd_dataout, read);
                return m_rd_dataout;
            };
            IAsyncResult result = func.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                //在限制时间内完成则返回结果
                return func.EndInvoke(result);
            }
            else
            {
                threadToKill.Abort();
                throw new TimeoutException("限制时间内未响应");
            }
        }

        public void Dispost()
        {
            //释放设备资源(hDevInfo是SetupDiGetClassDevs获取的)
            SetupDiDestroyDeviceInfoList(hDevInfo);
            //关闭连接(HidHandle是Create的时候获取的)
            CloseHandle(HidHandle);
        }



    }
}
