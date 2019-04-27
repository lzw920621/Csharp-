using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准查询
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lists = new List<string> { "Jack", "Pet", "Hant", "Li", "Kkk" };

            var list1 = lists.Where(str => str.StartsWith("J")).ToList<string>();
            list1.ForEach(str => Console.WriteLine(str));
            
            Console.ReadKey();
        }
    }
}
