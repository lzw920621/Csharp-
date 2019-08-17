using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 结构体使用属性时遇到的坑
{
    class Program
    {
        public struct StructA
        {
            public int fieldA;
            public int propertyB { get; set; }
        }

        public struct StructB
        {
            public int fieldA;
            public int propertyB { get { return 0; } set { } }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(StructA)} size is: {Marshal.SizeOf(typeof(StructA))}");//长度为8
            Console.WriteLine($"{nameof(StructB)} size is: {Marshal.SizeOf(typeof(StructB))}");//长度为4
            
            Console.ReadLine();
        }
    }
}
