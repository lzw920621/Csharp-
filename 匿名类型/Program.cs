using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 匿名类型
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new { name = "张三", age = 15, gender = "男", birthday = 2004 };
            //student.name = "李四";//错误 匿名类型的属性是只读的,不能修改


            //匿名类型的对象初始化语句有三种形式
            int age = 16;
            var person = new
            {
                Other.Name,
                age,
                gender = "男"
            };
            Other.Name = "李宁";//这里的修改不会影响到匿名类型里面的属性值
            age = 20;//这里的修改不会影响到匿名类心里面的属性值
            Console.WriteLine("{0} {1} {2}", person.Name, person.age, person.gender);
            Console.ReadKey();
        }
    }
    class Other
    {
        public static string Name = "张伟";
    }
}
