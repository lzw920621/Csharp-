using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 子类调用父类静态成员
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Base.num;
            num = Derived.num;
        }
    }

    class Base
    {
        public static int num = 10;
    }

    class Derived:Base
    {

    }
}
