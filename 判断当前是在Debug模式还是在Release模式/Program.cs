using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判断当前是在Debug模式还是在Release模式
{
    class Program
    {
        static void Main(string[] args)
        {
#if (DEBUG)
            Console.Write("DEBUG下运行");
#else
            Console.Write("release下运行");
#endif
            Console.ReadKey();
        }
    }
}
