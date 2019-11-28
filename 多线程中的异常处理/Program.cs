using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程中的异常处理
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用Thread创建的子线程,需要在委托中捕捉,无法在上下文线程中捕捉
            try
            {
                Thread th = new Thread(DoWork);
                th.Start();
            }
            catch (Exception ex)
            {
                // Non-reachable code
                Console.WriteLine("Exception!");
            }

            Console.ReadKey();
        }

        static void DoWork()
        {
            //
            //try
            //{
            //    throw new Exception("子线程出现异常了");
            //}
            //catch (Exception ex)
            //{
            //    Trace.Assert(false, "Catch In Delegate");
            //}

            throw new Exception("子线程出现异常了");
        }
    }
}
