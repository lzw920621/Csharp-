using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace in作为方法参数修饰符的作用
{
    //in 修饰方法的参数时,该参数的值只能读取,不能修改


    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            
        }


        static void Method(in int a)
        {
            //a = 4;//错误 不能修改被in修饰的参数值
        }
    }
}
