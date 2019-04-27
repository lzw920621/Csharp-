using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 构造查询数据
            List<string> lists = new List<string> { "Jack", "Pet", "Hant", "Li", "Kkk" };

            #endregion

            var query = from r in lists
                        where r.StartsWith("J")
                        select r;

            Console.WriteLine("第一次查询结果：");
            Console.WriteLine(query.Count());
            foreach (string st in query)
            {
                Console.WriteLine(st);
            }
            
            Console.WriteLine("第二次查询结果：");            
            lists.Add("Jone");
            lists.Add("Jimi");
            lists.Add("Johu");
            Console.WriteLine(query.Count());
            foreach (string st in query)
            {
                Console.WriteLine(st);
            }

            Console.ReadKey();
            /*
             输出结果：
             * 第一次：Jack
             * 第二次：Jack Jone Jimi Johu
             */

            //Action<string> BookAction = new Action<string>(s=> { Console.WriteLine("我是买书的是:{0}", s); });

            //BookAction("百年孤独");
            //Console.ReadKey();
        }
    }
}
