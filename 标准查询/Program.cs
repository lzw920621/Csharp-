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
            List<string> list = new List<string> { "Jack", "Pet", "Hant","Party", "Li", "Kkk" ,"Jerry","Hugo"};

            string str1 = list.First();
            string str2 = list.Last();

            //为每个元素执行某个操作
            list.ForEach(str => Console.WriteLine(str));

            //筛选
            var list1 = list.Where(str => str.StartsWith("J")).ToList<string>();

            //映射
            var list2 = list.Select(str => str + "后缀").ToList<string>();
            
            //计数
            int count = list.Count(str => str.StartsWith("J"));

            //排序
            var list3 = list.OrderBy(str => str[0]).ToList<string>();

            //排序后再排序
            var list4 = list.OrderBy(str => str[0]).ThenBy(str => str[1]).ToList<string>();

            
            //分组
            var list6 = list.GroupBy(str => str[0]);
            Console.WriteLine("*************");
            foreach (var group in list6)
            {
                foreach (var str in group)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("-------------");
            }
            Console.WriteLine("*************");

            
            List<string> listA = new List<string> { "Jack", "Pet", "Hant" };
            List<string> listB = new List<string> { "Pet", "Hant","Party", "Li", "Kkk" , "Kkk" };
            //并集 不包含重复项
            var list7 = listA.Union(listB).ToList();

            //合并 包含重复项
            var list8 = listA.Concat(listB).ToList();

            //交集 共有的项
            var list9 = listA.Intersect(listB).ToList();

            //差集 
            var list10 = listA.Except(listB).ToList();

            List<string> listC = new List<string> { "Jack", "Jack", "Pet", "Pet" };
            //去重
            var list11 = listC.Distinct().ToList();

            //判断两个集合的元素是否相同
            bool isEqual = listA.SequenceEqual(listB);

            //翻转
            list.Reverse();

            //确定序列中是否存在元素满足条件。
            bool isTrue = list.Any(str => str.StartsWith("O"));



            //联结
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };
            
            var query =
                people.Join(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, pet) =>
                                new { OwnerName = person.Name, Pet = pet.Name });

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.OwnerName,
                    obj.Pet);
            }

        }
    }

    class Person
    {
        public string Name { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }


}
