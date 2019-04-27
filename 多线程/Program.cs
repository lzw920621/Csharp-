using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 多线程
{
    public struct MyStruct
    {
        public int a;
        public int b;
        public string c;
        public MyStruct(int num1,int num2,string str)
        {
            this.a = num1;
            this.b = num2;
            this.c = str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(ThreadMethod);     //执行的必须是无返回值的方法
            thread.Name = "子线程";
            //thread.Start("王建");                       //在此方法内传递参数，类型为object，发送和接收涉及到拆装箱操作
            thread.Start();

            Thread thread2 = new Thread(ThreadMethod2);     //执行的必须是无返回值的方法
            thread2.Name = "子线程2";
            MyStruct ms = new MyStruct(1, 2, "qwe");
            thread2.Start(ms);
            Console.ReadKey();

        }

        public static void ThreadMethod(object parameter) //方法内可以有参数，也可以没有参数
        {
            Console.WriteLine("{0}开始执行。", Thread.CurrentThread.Name);
        }

        //多线程 传递多个参数使用结构体封装
        public static void ThreadMethod2(object parameter)
        {
            MyStruct ms = (MyStruct)parameter;
            Console.WriteLine("{0}开始执行。", Thread.CurrentThread.Name);
            Console.WriteLine("a:{0} b:{1} c:{2}", ms.a, ms.b, ms.c);
        }
    }
}
