using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造函数的初始化语句
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    class MyBaseClass
    {
        public MyBaseClass(int a,int b)
        {

        }
    }

    class MyDerivedClass:MyBaseClass
    {
        public MyDerivedClass(int c):base(c,c)
        {

        }
        public MyDerivedClass(int a,int b,int c):base(a,b)
        {

        }
    }
}
