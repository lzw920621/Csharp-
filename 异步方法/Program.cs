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
            Console.WriteLine(DateTime.Now + " : " + "主线程 调用异步方法前 线程ID:" + Thread.CurrentThread.ManagedThreadId );

            DoSomething();

            Console.WriteLine(DateTime.Now + " : " + "主线程 调用异步方法后 线程ID:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        static async void DoSomething()
        {
            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 await前 线程ID:" + Thread.CurrentThread.ManagedThreadId);

            await Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 await内部 开始执行耗时操作 线程ID:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 await内部 耗时操作执行完毕 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            }
            );
            
            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 await后 线程ID:" + Thread.CurrentThread.ManagedThreadId);

        }

        

        static void DoSomething2(string str)
        {
            Console.WriteLine("同步方法中调用异步方法前 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);

            DoSomething();

            Console.WriteLine("同步方法中调用异步方法后 线程ID:" + Thread.CurrentThread.ManagedThreadId + " 时间：" + DateTime.Now);
        }
    }
}
