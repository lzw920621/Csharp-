using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FieldOffset特性实现共用体
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DWORDIPAddress
    {
        [FieldOffset(0)]
        public uint Address;
        [FieldOffset(3)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(1)]
        public byte Byte3;
        [FieldOffset(0)]
        public byte Byte4;
    }
    class Program
    {
        static void Main(string[] args)
        {
            uint nIPAddress = 2291298690;
            DWORDIPAddress address = new DWORDIPAddress
            {
                Address = nIPAddress
            };
            Console.WriteLine("{0}", address.Address);//10001000 10010010 01110001 10000010-->2291298690
            Console.WriteLine("{0}", address.Byte1);//10001000-->136
            Console.WriteLine("{0}", address.Byte2);//10010010-->146
            Console.WriteLine("{0}", address.Byte3);//01110001-->113
            Console.WriteLine("{0}", address.Byte4);//10000010-->130
            Console.ReadLine();
        }
    }
}
