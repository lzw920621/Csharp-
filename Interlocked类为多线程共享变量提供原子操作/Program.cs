using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Interlocked类为多线程共享变量提供原子操作
{
    class Program
    {
        static int num1 = 0;
        static int num2 = 0;
        static int num3 = 0;
        static readonly object lockObj = new object();
        static void Main(string[] args)
        {
            Parallel.For(0, 1000000, i =>
            {
                Interlocked.Increment(ref num1);
            });
            Parallel.For(0, 1000000, i =>
              {
                  num2++;//直接使用count++,  如果两个线程并行执行时, 两个线程中的一个的结果会被覆掉, 非线程安全.
              });
            Parallel.For(0, 1000000, i =>
            {
                lock(lockObj)
                {
                    num3++;
                }
            });
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.ReadKey();
        }
    }
}
