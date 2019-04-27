using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 语法糖
{
    class Program
    {
        static string a;

        delegate void Printer(string s);

        static void Main(string[] args)
        {            
            //
            string b = a ?? "";
            string c = a + "";
            Console.WriteLine((a + "").Length);
            Console.ReadKey();

            //隐式类型 （只能用来声明局部变量 且必须初始化）
            var array = new int[] { 1, 2, 3, 4, 5 };


            //匿名类和匿名方法
            var aPeople = new { pName = "张三", pAge = 26, pSex = "男" };


            Printer p = delegate(string s)
            {
                 Console.WriteLine(s);
            };
            //lambda表达式
            Printer p1 = s => Console.WriteLine(s);
        }
    }
}
