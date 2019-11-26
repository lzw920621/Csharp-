using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 尾递归求斐波拉契数列
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Fibonacci(10, 0, 1);
        }

        static int Fibonacci(int n,int num1,int num2)
        {
            if (n == 0) return num1;
            return Fibonacci(n - 1, num2, num1 + num2);
        }
    }
}
