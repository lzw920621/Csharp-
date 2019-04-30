using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 动态加载程序集
{
    //动态加载Dll有3个函数：
    //public static Assembly Load(string assemblyString);
    //public static Assembly LoadFile(string path);
    //public static Assembly LoadFrom(string assemblyFile);

    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory+@"\MyClassLibrary.dll";
            Assembly assembly = Assembly.LoadFile(path);

            Type[] types = assembly.GetTypes();//获取程序集中所有的类型

            Type type = assembly.GetType("MyClassLibrary.ClassGreenerycn");//根据类型名称获取相应的类型;
            var instance = Activator.CreateInstance(type);//创建改类型的实例
            type.GetProperty("Name").SetValue(instance, "http://greenerycn.cnblogs.com", null);
            type.GetProperty("IsTest").SetValue(instance, true, null);

            var method = type.GetMethod("Hello");
            method.Invoke(instance, null);
        }
    }
}
