using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 给数组赋值连续整数
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用Enumerable.Range快速给一个数组赋值连续整数 
            int[] array = Enumerable.Range(0, 100).ToArray();


            //判断两个数组中的元素是否相等
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array2 = Enumerable.Range(1, 10).ToArray();
            bool isTrue=array1.SequenceEqual(array2);
        }
    }
}
