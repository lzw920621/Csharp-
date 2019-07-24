﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    public enum Gender
    {
        男,
        女
    }
    class person
    {
        public int age = 15;
        public string name = "tom";
        public Gender gender = Gender.男;

        private string hobby = "看电视";

        public void SelfIntroduce()
        {
            Console.WriteLine("我叫" + this.name + "今年" + age + "岁" + "我喜欢" + this.hobby);
        }

        public void MethodA(string str,int n)
        {

        }
        public void MethodA()
        {

        }

        public person()
        {

        }
         
        public person(int age,string name )
        {
            this.age = age;
            this.name = name;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            person p = new person();
            //Type type = typeof(person);
            //Type type1 = typeof(person);
            Type type1 = p.GetType();
            person p1 = Activator.CreateInstance(type1) as person;//创建改类型的实例(用无参构造函数创建实例)

            ConstructorInfo constructor = type1.GetConstructor(new Type[] { typeof(int), typeof(string) });//获取参数为(int,string)的构造函数
            person obj=constructor.Invoke(new object[] { 15, "张三" }) as person;//调用构造函数创建实例

            MethodInfo[] methods = type1.GetMethods();

            MethodInfo methodA = type1.GetMethod("MethodA", new Type[2] { typeof(string), typeof(int) });//获取名称为MethodA,参数为string,int的方法;
            MethodInfo methodA2= type1.GetMethod("MethodA", new Type[0]);//获取名称为MethodA,无参的方法
            PropertyInfo[] properties = type1.GetProperties();
            FieldInfo[] fieldInfos = type1.GetFields();
            MemberInfo[] memberinfos = type1.GetMembers();

            MethodInfo method = type1.GetMethod("SelfIntroduce");
            method.Invoke(p, null);

            Type type2 = 1.GetType();
            string name = type2.Name;
            string nameSpace = type2.Namespace;            
        }
    }
}
