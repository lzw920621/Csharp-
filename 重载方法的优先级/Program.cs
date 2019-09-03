using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 重载方法的优先级
{
    class Program
    {
        static void Main(string[] args)
        {
            Method(10);

            Console.ReadKey();
        }

        static void Method(int num)
        {
            Console.WriteLine("调用的Method(int num)");
        }
        static void Method(double num)
        {
            Console.WriteLine("调用的Method(double num)");
        }
        static void Method(object num)
        {
            Console.WriteLine("调用的Method(object num)");
        }
    }
}
