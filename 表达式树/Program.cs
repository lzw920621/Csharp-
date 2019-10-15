using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树
{
    class Program
    {
        static void Main(string[] args)
        {
            //利用Lambda表达式创建表达式树
            Expression<Func<int, int, int, int>> expr = (x, y, z) => (x + y) / z;
            //编译表达式树,该方法将表达式树表示的代码编译成一个可执行委托
            var com = expr.Compile();//编译表达式树 生成委托
            int res = com(1, 2, 3);
            Console.WriteLine("利用Lambda表达式创建表达式树 : " + res);

            
            //动态构建表达式树
            ParameterExpression pe1 = Expression.Parameter(typeof(int), "x");
            ParameterExpression pe2 = Expression.Parameter(typeof(int), "y");
            ParameterExpression pe3 = Expression.Parameter(typeof(int), "z");
            var body = Expression.Divide(Expression.Add(pe1, pe2), pe3);
            var w = Expression.Lambda<Func<int, int, int, int>>(body, new ParameterExpression[]
                {
                    pe1,pe2,pe3
                });
            Console.WriteLine("动态构建表达式树 ; " + w.Compile()(1, 2, 3));


            Console.WriteLine("-------------------------------");
            Expression<Func<int, int, int>> expression = (a, b) => a + b;
            BinaryExpression body_ = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)body_.Left;
            ParameterExpression right = (ParameterExpression)body_.Right;

            Console.WriteLine(expression.Body);

            Console.WriteLine(" 表达式左边部分: " + "{0}{4} 节点类型: {1}{4} 表达式右边部分: {2}{4} 类型: {3}{4}", left.Name, body_.NodeType, right.Name, body_.Type, Environment.NewLine);
            Console.ReadKey();
        }
    }
}
