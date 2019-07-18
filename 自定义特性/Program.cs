using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义特性
{

    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false,Inherited =false)]//特性的特性,限制特性的使用条件
    class DeveloperInfoAttribute:System.Attribute
    {
        public DeveloperInfoAttribute(string name,string gender,int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public int Age { get; private set; }
    }

    [DeveloperInfo("LZW","男",26)]
    class MyClass
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            var attributesOftype = type.GetCustomAttributes(typeof(DeveloperInfoAttribute),false);
            foreach (DeveloperInfoAttribute attr in attributesOftype)
            {
                Console.WriteLine(attr.Name+'\n'+attr.Gender+'\n'+attr.Age);                
            }
            Console.ReadKey();
        }
    }
}
