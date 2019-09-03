using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqStudy
{
    class Program
    {
        //只有实现了IEnumerable或泛型IEnumerable<T> 接口的对象才能使用linq查询
        //linq是延迟查询，只有在遍历查询结果的时候才会执行

        static void Main(string[] args)
        {
            #region 构造查询数据
            List<string> lists = new List<string> { "Jacky", "Pet", "Hant", "Li", "Kkk" };

            #endregion

            //注意：不需要使用";"来分隔linq查询的每一行；
            var query = from r in lists           
                        where r.StartsWith("J")
                        where r.Length>4
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
            lists.Add("Jak");
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
            //var newlist = lists.Where((a) => a.StartsWith("J")).ToList();



            //Join子句  使用联结来结合两个或多个集合总的数据
            List<int> listA = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> listB = new List<int> { 3, 4, 5, 6, 7, 8, 9 };
            
            var newlist = from a in listA
                          join b in listB
                          on a equals b   //判断相等 不能用==  要用equals
                          select a;
            var isTrue=newlist.All(a => a > 2);//判断是否都大于2
            var isTrue2 = newlist.Any(a => a == 6);//判断是否有等于6的数
            var count = newlist.Count(a => a % 2 == 1);//奇数的个数

            //from...let...where
            var groupA = new[] { 3, 4, 5, 6 };
            var groupB = new[] { 6, 7, 8, 9 };

            //var someInts = from a in groupA
            //               from b in groupB
            //               let sum = a + b
            //               where sum == 12
            //               select new { a, b, sum };
            var someInts = from a in groupA
                           from b in groupB
                           let sum = a + b
                           where sum == 12 && a==4                           
                           select new { a, b, sum };
            foreach (var item in someInts)
            {
                Console.WriteLine(item);
            }


            //orderby
            var numArray = new[] { 1, 4, 3, 2, 7, 6, 5 };
            var numlist = from num in numArray
                          orderby num       //默认升序
                          where num > 3
                          select num;
            foreach (var num in numlist)
            {
                Console.WriteLine(num);
            }
        }
    }
}
