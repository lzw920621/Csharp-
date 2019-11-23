using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用拓展方法来拓展接口
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.MyExMethod();
        }
    }

    interface IMyInterface
    {

    }

    public class MyClass:IMyInterface
    {

    }

    static class MyExtensionMethods
    {
        public static void MyExMethod(this IMyInterface myInterface)
        {
            
        }

    } 


}
