using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 利用反射调用私有方法
{
    //应用:单元测试测试类的私有方法时可以通过反射来调用

    class Program
    {
        
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            Type type = mc.GetType();
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var m = type.GetMethod("MyMethod", flags);
            m.Invoke(mc, null);
        }
    }

    class MyClass
    {
        void MyMethod()
        {
            Console.WriteLine("这是私有方法");
        }
    }
}
