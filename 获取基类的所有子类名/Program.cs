using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 获取基类的所有子类名
{
    //博客原文:https://www.cnblogs.com/TianFang/archive/2009/10/24/1588949.html
    class Program
    {
        static void Main(string[] args)
        {
            var subTypeQuery = from t in Assembly.GetExecutingAssembly().GetTypes()
                               where IsSubClassOf(t, typeof(Base))
                               select t;

            foreach (var type in subTypeQuery)
            {
                Console.WriteLine(type);
            }

            Console.ReadKey();
        }

        static bool IsSubClassOf(Type type, Type baseType)
        {
            var b = type.BaseType;
            while (b != null)
            {
                if (b.Equals(baseType))
                {
                    return true;
                }
                b = b.BaseType;
            }
            return false;
        }
    }


    public class Base { }
    public class Sub1 : Base { }
    public class Sub2 : Base { }
    public class Sub3 : Sub1 { }
}
