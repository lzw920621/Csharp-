using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 以不同的进制输出数字
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 16;
            //输出二进制形式
            Console.WriteLine("0b"+Convert.ToString(num, 2));
            //输出八进制形式
            Console.WriteLine("0" + Convert.ToString(num, 8));
            //输出十进制形式
            Console.WriteLine(Convert.ToString(num, 10));
            //输出十六进制形式
            Console.WriteLine("0x" + Convert.ToString(num, 16));

            Console.ReadKey();
        }
    }
}
