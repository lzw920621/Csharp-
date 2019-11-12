using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp踩坑之类型强转
{
    class Program
    {
        static void Main(string[] args)
        {
            //Convert.ToInt32(double value) 如果 value 为两个整数中间的数字，则返回二者中的偶数
            int n1 = Convert.ToInt32(4.5);  //4
            int n2= Convert.ToInt32(5.5);   //6
        }
    }
}
