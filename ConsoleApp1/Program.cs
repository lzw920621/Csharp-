using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private void write()
        {

        }
        private void write1()
        {
            write();
        }
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int[] array = new int[] { a, b, c };
            array[1] = 5;
            foreach (var item in (from num in array where num>1 select num))
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(b);
            Console.ReadKey();
            //write();

            List<string> list = new List<string> { "a", "f", "b", "G", "d" };
            list.ForEach(x => Console.WriteLine(x));
            list.RemoveAt(1);
            list.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}
