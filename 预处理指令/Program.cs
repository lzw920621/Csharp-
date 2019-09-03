#define A
#define B
#undef  A
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 预处理指令
{
    class Program
    {
        static void Main(string[] args)
        {
#if A
            Console.WriteLine("A is defined");
#elif B
            Console.WriteLine("B is defined");
#else
            Console.WriteLine("Neither A or B is defined");
#endif

            //使用 #warning 和 #error 来标记代码中潜藏的BUG和可以改进的地方

#warning 这里的代码存在BUG,需要改进

#warning 这里的逻辑不完善

#warning 这里还没写完,别忘了

#error 这里有错误

            // #pragama关闭或还原警告
#pragma warning disable 1030  //关闭编号为1030的警告

#pragma warning restore 1030  //启用编号为1030的警告

        }
    }
}
