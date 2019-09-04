using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 枚举类型的遍历
{
    enum MyEnum
    {
        flag1,
        flag2,
        flag3,
        flag4,
        flag5,
        flag6
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var flag in Enum.GetValues(typeof(MyEnum)))
            {
                Console.WriteLine(flag.ToString());
            }

            Console.ReadKey();
        }
    }
}
