using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 获取当前函数名代码行以及源代码文件
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();

            StackTrace st = new StackTrace(new StackFrame(true));
            Console.WriteLine(" Stack trace for current level: {0}", st.ToString());
            StackFrame sf = st.GetFrame(0);
            Console.WriteLine(" File: {0}", sf.GetFileName());
            Console.WriteLine(" Method: {0}", sf.GetMethod().Name);
            Console.WriteLine(" Line Number: {0}", sf.GetFileLineNumber());
            Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());

            Console.ReadKey();
        }

        static void Test()
        {
            Console.WriteLine(Environment.StackTrace);
        }
    }
}
