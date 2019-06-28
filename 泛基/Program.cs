using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 泛基
{
    public abstract class MyBase<TDerived> where TDerived : MyBase<TDerived>
    {
        public static List<string> GetMembersOfClassT()//获取子类成员信息
        {
            Type type = typeof(TDerived);
            MemberInfo[] members = type.GetMembers();
            List<string> membersList = new List<string>();
            foreach (var item in members)
            {
                membersList.Add(item.Name);
            }
            return membersList;
        }
        public static List<string> GetFieldsOfClassT()//获取子类字段信息
        {
            Type type = typeof(TDerived);
            FieldInfo[] fields = type.GetFields();
            List<string> fieldList = new List<string>();
            foreach (var item in fields)
            {
                fieldList.Add(item.Name);
            }
            return fieldList;
        }
        public static List<string> GetMethodsOfClassT()//获取子类方法信息
        {
            Type type = typeof(TDerived);
            MethodInfo[] methods = type.GetMethods();
            List<string> methodList = new List<string>();
            foreach (var item in methods)
            {
                methodList.Add(item.Name);
            }
            return methodList;
        }
        public static TDerived InstanceOfT { get; protected set; }

    }
    class NewClass:MyBase<NewClass>
    {
        public int field1;
        public int field2;
        public void Method1()
        {

        }
        public void Method2()
        {

        }
        static NewClass()
        {
            InstanceOfT = new NewClass();
        }        
    }



    class Program
    {
        static void Main(string[] args)
        {
            //可以通过父类来获取子类信息
            MyBase<NewClass>.GetMembersOfClassT().ForEach((str) => Console.WriteLine(str));
            Console.WriteLine("-----------------------------------------------");
            MyBase<NewClass>.GetFieldsOfClassT().ForEach((str) => Console.WriteLine(str));
            Console.WriteLine("-----------------------------------------------");
            MyBase<NewClass>.GetMethodsOfClassT().ForEach((str) => Console.WriteLine(str));

            //var myclass1 = MyBase<NewClass>.InstanceOfT;   //获取到的结果是null NewClass的静态构造函数未调用
            //var myclass2 = MyBase<NewClass>.InstanceOfT;
            //bool equal = myclass1.Equals(myclass2);
            Console.ReadKey();
        }
    }
}
