using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checked和unchecked关键字
{
    //VS中可以在项目的属性页面选择 生成 标签,  高级设置,勾选溢出检查,这样会对程序中所用的计算进行溢出检查


    //checked 关键字用于对整型算术运算和转换显式启用溢出检查。

    //unchecked 关键字用于取消整型算术运算和转换的溢出检查。

    class Program
    {
        static void Main(string[] args)
        {
            //默认情况下，如果表达式仅包含常数值，且产生的值在目标类型范围之外，则它会导致编译器错误。 
            //如果表达式包含一个或多个非常数值，则编译器不检测溢出。 在下面的示例中，计算赋给 i2 的表达式不会导致编译器错误。
            int ten = 10;
            int i2 = 2147483647 + ten;//溢出但是没有报异常
            Console.WriteLine(i2);

            checked//显示的启用溢出检查
            {
                int i3 = 2147483647 + ten;//会报 溢出 异常
                Console.WriteLine(i3);
            }

            int i4 = checked(2147483647 + ten);//会报 溢出 异常


            //在未检查的上下文中，如果表达式产生的值在目标类型范围之外，并不会标记溢出。 
            //例如，下例中的计算在 unchecked 块或表达式中执行，因此将忽略结果对于整数而言过大这一事实，并会对 int1 赋予值 -2,147,483,639。

            unchecked
            {
                int i5 = 2147483647 + 10;
            }
            int i6 = unchecked(2147483647 + 10);

        }
    }
}
