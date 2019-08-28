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

            DoSomething2();
            Console.ReadKey();

            DoSomething3();
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

        

        static void DoSomething2()
        {
            Console.WriteLine(DateTime.Now + " : " + "同步方法中调用异步方法前 线程ID:" + Thread.CurrentThread.ManagedThreadId);

            DoSomething();

            Console.WriteLine(DateTime.Now + " : " + "同步方法中调用异步方法后 线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static async void DoSomething3()
        {
            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第一个await之前 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第一个await内部 开始执行 耗时操作 线程ID:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第一个await内部 耗时操作 执行完毕 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第一个await之后 线程ID:" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第二个await之前 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第二个await内部 开始执行 耗时操作 线程ID:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第二个await内部 耗时操作 执行完毕 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine(DateTime.Now + " : " + "异步方法内部 第二个await之后 线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
