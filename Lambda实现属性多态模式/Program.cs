using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda实现属性多态模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyBaseClass
    {
        public Action SomeAction { get; protected set; }

        public MyBaseClass()
        {
            SomeAction = () =>
            {
                //Do something!
            };
        }
    }
    class MyInheritedClass : MyBaseClass
    {
        public MyInheritedClass()
        {
            base.SomeAction = () =>
            {
                //Do something different!
            };
        }
    }
}
