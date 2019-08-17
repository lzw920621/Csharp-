using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _字符串内插
{
    /*
    $ 特殊字符将字符串文本标识为内插字符串 。 内插字符串是可能包含内插表达式的字符串文本 。 
    将内插字符串解析为结果字符串时，带有内插表达式的项会替换为表达式结果的字符串表示形式。 
    此功能在 C# 6 及该语言的更高版本中可用。

    与使用字符串复合格式设置功能创建格式化字符串相比，字符串内插提供的语法更具可读性，且更加方便。 
    下面的示例使用了这两种功能生成同样的输出结果：
    */
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            // Both calls produce the same output that is similar to:
            // Hello, Mark! Today is Wednesday, it's 19:40 now.

        }
    }
}
