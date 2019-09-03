using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用goto跳出多层循环
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if(j==10)
                    {
                        goto QuitLoop;
                    }
                }
            }
            QuitLoop:
            Console.ReadKey();
            
        }
    }
}
