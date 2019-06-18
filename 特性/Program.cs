#define A
#define B
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace 特性
{
    class MyClass
    {
        [Obsolete("该方法已过期,请使用新方法NewMethod")]
        public void OldMethod()
        {

        }
        public void NewMethod()
        {

        }

        //条件特性
        [Conditional("A")]
        public void Method_A()
        {
            Console.WriteLine("我是方法A");
        }
        [Conditional("B")]
        public void Method_B()
        {
            Console.WriteLine("我是方法B");
        }

        //调用者信息特性
        public void MyTrace(string message, 
            [CallerFilePath] string filename = "", 
            [CallerLineNumber] int lineNum = 0,
            [CallerMemberName] string callingMember="")
        {
            Console.WriteLine("消息:" + message);
            Console.WriteLine("调用者名称:" + callingMember);
            Console.WriteLine("调用行:" + lineNum);
            Console.WriteLine("调用文件路径" + filename);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.OldMethod(); 

            mc.Method_A();

            mc.MyTrace("你好");
            Console.ReadKey();
        }
    }
}
