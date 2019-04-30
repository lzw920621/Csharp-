using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 异步方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Beep(1000, 1000);
            Console.WriteLine("调用方法前 主线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

            DoSomething("第一次");

            DoSomething("第二次");

            DoSomething2("第三次");

            Console.WriteLine("调用方法后 主线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

            Console.ReadKey();
        }

        static async void DoSomething(string str)
        {
            Console.WriteLine(str + "Do方法内部await前 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

            await Task.Run(() => 
            {
                Console.WriteLine(str + "Do方法内部await内部 开始执行耗时操作 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine(str + "Do方法内部await内部 耗时操作执行完毕 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);
            }
            );

            Console.WriteLine(str + "Do方法内部await后 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

        }


        static void DoSomething2(string str)
        {
            Console.WriteLine("同步方法中调用异步方法前 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

            DoSomething(str);

            Console.WriteLine("同步方法中调用异步方法后 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);
        }
    }
}
