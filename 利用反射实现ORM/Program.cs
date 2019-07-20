using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 利用反射实现ORM
{
    class Program
    {
        static void Main(string[] args)
        {            
            //SbORM.Insert(new Person() { ID = 1, Name = "张三", Age = 23, Weight = 60 });
            //SbORM.Insert(new Person() { ID = 2, Name = "李四", Age = 20, Weight = 70 });
            //SbORM.Insert(new Person() { ID = 3, Name = "王五", Age = 25, Weight = 50 });
            //Person person2 = SbORM.Search<Person>(1) as Person;
            SbORM.Delete<Person>(1);
        }

        class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
        }
    }
}
