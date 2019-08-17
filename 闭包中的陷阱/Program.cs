using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 闭包中的陷阱
{   
    class Program
    {
        static void Main(string[] args)
        {        
            //情形1
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Thread.Sleep(1000);                    
                    Console.WriteLine(i);
                });
            }

            Console.ReadKey();
            Console.WriteLine("----------------------");
            //情形2
            int[] array = new int[] { 0, 1, 2, 3, 4, 5 };
            foreach (var i in array)
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i);
                });
            }
            Console.ReadKey();
        }
    }
}
