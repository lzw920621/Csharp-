using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 利用反射实现浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person personClone = MyClone(person) as Person;
        }

        public static object MyClone(object obj)
        {
            Type type = obj.GetType();
            object instanceClone = Activator.CreateInstance(type);//创建该类型的一个对象(使用的是默认的无参构造函数)
            foreach (var property in type.GetProperties())
            {
                if(property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(obj);//获取要拷贝对象obj的该属性的值
                    property.SetValue(instanceClone, value);//将该值赋值给新的实例instanceClone对应的属性
                } //这里只对属性值进行了拷贝,如果有其他成员 比如 字段 也可以用类似的方法进行拷贝               
            }
            return instanceClone;//返回新的对象
        }
    }

    public enum Gender
    {
        男,
        女
    }
    class Person
    {
        public int Age { get; set; } = 15;
        public string Name { get; set; } = "tom";
        public Gender Sex { get; set; } = Gender.男;


    }
}
