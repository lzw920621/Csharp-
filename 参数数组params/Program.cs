using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 参数数组params
{
    /*
    使用 params 关键字可以指定采用数目可变的参数的 方法参数。
    可以发送参数声明中所指定类型的逗号分隔的参数列表或指定类型的参数数组。还可以不发送参数。如果未发送任何参数，则 params列表的长度为零。
    在方法声明中的params关键字之后不允许任何其他参数，并且在方法声明中只允许一个params关键字。
    */
    class Program
    {
        static void Main(string[] args)
        {
            UseParams(1, 2, 3, 4);
            UseParams2(1, 'a', "test");

            Console.ReadKey();
        }

        public static void UseParams(params int[] list)//注意:被params修饰的参数只能作为方法的最后一个参数
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
