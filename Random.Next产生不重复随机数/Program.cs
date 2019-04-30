using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Next产生不重复随机数
{
    class Program
    {
        static void Main(string[] args)
        {
            //相同的种子会产生相同的随机数序列
            Random rd1 = new Random(1);
            Random rd2 = new Random(1);
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(rd1.Next() + " " + rd2.Next());
            }

            Console.ReadKey();


            //使用guid作为随机数种子，适用于高频次调用一个生成方法或过程
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(GetRandom());
            }
        }

        public static int GetRandom()
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next();
        }
    }
}
