using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 同步方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Parallel.For(1, 5, (n) =>
            {
                program.Execute();
            });
            Console.ReadKey();
        }


        [MethodImpl(MethodImplOptions.Synchronized)]//将该方法标记为同步方法
        public void Execute()
        {
            Console.WriteLine("Thread Name:{1},Excute at {0}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
        }
    }
}
