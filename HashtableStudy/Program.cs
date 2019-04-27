using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashtableStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", "a");
            hashtable.Add("2", 2341);

            foreach (var item in hashtable.Keys)
            {
                Console.WriteLine(item.ToString() + ":" + hashtable[item].ToString());
                
            }

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "a");
            dic.Add(2, "b");
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key.ToString() + ":" + item.Value);
            }

            Console.ReadKey();
        }
    }
}
