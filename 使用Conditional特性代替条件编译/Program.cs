using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用Conditional特性代替条件编译
{
    /*
    #if/#endif 语句常用来基于同一份源代码生成不同的编译结果,最常见的就是debug和release版.这在实际代码中很容易被滥用,不便于维护和调试.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Check();
            Check2();
            Console.ReadKey();
        }

        static void Check()
        {
#if DEBUG
            //string methodName = new StackTrace().GetFrame(1).GetMethod().Name;
            Console.WriteLine("do something");
#endif
        }

        [Conditional("DEBUG")]
        static void Check2()
        {
            Console.WriteLine("do something");
        }
    }

    
}
