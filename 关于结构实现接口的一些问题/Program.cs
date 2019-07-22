using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 关于结构实现接口的一些问题
{

    //在结构使用时，结构可以实现接口。这时就有一个问题“结构体实现接口后是值类型还是引用类型？”

    struct StructClass : IClass
    {
        public int Count;//人数   
        public void AddStudent()
        {
            Count++;
        }

        public void ShowCount()
        {
            Console.WriteLine(Count);
        }

    }
    //接口   
    interface IClass
    {
        void AddStudent();//添加学生   
        void ShowCount();//显示学生人数   
    }   

    class Program
    {
        static void Main(string[] args)
        {
            StructClass s1 = new StructClass();
            StructClass s2 = s1;
            s1.AddStudent();
            s1.ShowCount(); //输出1   
            s2.ShowCount(); //输出0   
            //说明s2和s1不指向同一个对象，s2=s1是创建了一个s1的副本   
            //这是值类型很显著的标志   

            IClass ic1 = new StructClass();
            IClass ic2 = ic1;
            ic1.AddStudent();
            ic1.ShowCount();//输出1   
            ic2.ShowCount();//输出1   
            //说明s2和s1指向同一个对象，s2=s1是将s1的引用赋给s2   
            //这是引用类型很显著的标志   

            Type type = typeof(StructClass);
            Type type2 = typeof(IClass);
            MethodInfo[] methodInfos = type.GetMethods();
            FieldInfo[] fieldInfos = type.GetFields();
            /*
            最后得出结论：
            当我们声明对象(s1、s2)是结构体类型时，对象是值类型，对象在栈中创建
            当我们声明对象(ic1、ic2)是接口类型时，对象是引用类型，对象在堆中创建
            */
        }
    }
}
