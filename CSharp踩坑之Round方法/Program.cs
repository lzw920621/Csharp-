using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp踩坑之Round方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //Round会将 中点值 转化为最接近的偶数值
            var rounded1 = Math.Round(1.5);//2;
            var rounded2 = Math.Round(2.5);//2
            var rounded3 = Math.Round(3.5);//4
            var rounded4 = Math.Round(4.5);//4
        }
    }
}
