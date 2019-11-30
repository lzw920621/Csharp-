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
            int num2 = Factorial2(10);
        }
        //尾递归求斐波那契数列
        static int Fibonacci(int n,int num1,int num2)
        {
            if (n == 0) return num1;
            return Fibonacci(n - 1, num2, num1 + num2);
        }
        
        //尾递归求阶乘
        static int Factorial(int n, int s=1,int num=2)
        {
            if (n == 1) return s;
            return Factorial(n - 1, s * num, num + 1);
        }
        //最简单的尾递归求阶乘
        static int Factorial2(int n, int s = 1)
        {
            if (n == 1) return s;
            return Factorial2(n - 1, s * n);
        }
    }
}
