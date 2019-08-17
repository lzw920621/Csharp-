using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于闭包
{
    //闭包是指有权访问另一个函数作用域中的变量的函数。

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetClosureFunction()(30));//依次输出:20 40 60
           
        }

        static Func<int, int> GetClosureFunction()
        {
            int val = 10;
            Func<int, int> internalAdd = x => x + val;

            Console.WriteLine(internalAdd(10));

            val = 30;
            Console.WriteLine(internalAdd(10));

            return internalAdd;
        }
        
    }
}
