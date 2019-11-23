using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程安全集合
{
    class Program
    {
        static void Main(string[] args)
        {
            ListWithParallel();
            ConcurrentBagWithPallel();

            Console.ReadKey();
        }

        public static void ListWithParallel()//线程不安全
        {
            List<int> list = new List<int>();
            Parallel.For(0, 100000, item =>
            {
                list.Add(item);
            });
            Console.WriteLine("List's count is {0}", list.Count());
        }

        public static void ConcurrentBagWithPallel()//线程安全
        {
            ConcurrentBag<int> list = new ConcurrentBag<int>();
            Parallel.For(0, 100000, item =>
            {
                list.Add(item);
            });
            Console.WriteLine("ConcurrentBag's count is {0}", list.Count());
        }
    }
}
