using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用迭代器输出斐波那契数列
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Fibonacci(10))
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }

        private static IEnumerable<int> Fibonacci(int number)
        {
            int a = 0, b = 1, c = 0;
            for (int i = 0; i < number; i++)
            {
                yield return b;
                c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
