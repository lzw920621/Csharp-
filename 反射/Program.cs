using System;
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
    }


    class Program
    {
        static void Main(string[] args)
        {
            person p = new person();
            //Type type = typeof(person);

            Type type1 = p.GetType();
            MethodInfo[] methods = type1.GetMethods();
            PropertyInfo[] properties = type1.GetProperties();
            FieldInfo[] fieldInfos = type1.GetFields();
            MemberInfo[] memberinfos = type1.GetMembers();

            MethodInfo method = type1.GetMethod("SelfIntroduce");
            method.Invoke(p, null);
            
        }
    }
}
