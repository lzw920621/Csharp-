using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {            
            ThreadPool.QueueUserWorkItem(Method1);
            ThreadPool.QueueUserWorkItem(Method2);
            ThreadPool.QueueUserWorkItem(Method3);
            ThreadPool.QueueUserWorkItem(Method4);
            ThreadPool.QueueUserWorkItem(Method5);
            Console.ReadKey();
        }

        static void Method1(object obj)
        {
            Console.WriteLine("我是方法1 ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static void Method2(object obj)
        {
            Console.WriteLine("我是方法2 ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static void Method3(object obj)
        {
            Console.WriteLine("我是方法3 ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static void Method4(object obj)
        {
            Console.WriteLine("我是方法4 ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static void Method5(object obj)
        {
            Console.WriteLine("我是方法5 ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
