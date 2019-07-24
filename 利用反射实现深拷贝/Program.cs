using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace 利用反射实现深拷贝
{
    class ClassA
    {
        public int num1;
    }
    class ClassB
    {
        public int field1;
        public int Property1 { get; set; }

        public ClassA a;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClassB classB = new ClassB() { field1 = 1, Property1 = 10, a = new ClassA() { num1 = 2 } };
            ClassB cloneB = DeepClone(classB) as ClassB;
        }

        public static T DeepClone<T>(T t) 
        {
            //如果是字符串或值类型则直接返回
            if (t == null || t is string || t.GetType().IsValueType) return t;

            Type type = t.GetType();//尽量不要用typeof(T) 因为有时候t传进来时是其父类形式,比如t是一个自定义类的实例 但是它传进来时是以object类型传递的 这时typeof(T)获取到的时object类型 而t.GetType()可以获得其真实类型信息
            PropertyInfo[] properties = type.GetProperties();//该类型所有的属性信息
            FieldInfo[] fields = type.GetFields();//该类型所有的字段信息
            object cloneObject = Activator.CreateInstance(type);
            foreach (var property in properties)
            {
                object value = property.GetValue(t);
                if (value.GetType().IsValueType)//如果该属性是值类型
                {                    
                    property.SetValue(cloneObject,value);//将t对应的属性值赋给新的拷贝对象
                }
                else//属性是引用类型
                {                    
                    object newValue=DeepClone(value);
                    property.SetValue(cloneObject, newValue);//将t对应的属性值赋给新的拷贝对象
                }
            }
            foreach (var field in fields)
            {
                object value = field.GetValue(t);
                if (value.GetType().IsValueType)//值类型 直接赋值
                {                   
                    field.SetValue(cloneObject, value);
                }
                else//引用类型 递归拷贝
                {                    
                    object newValue = DeepClone(value);
                    field.SetValue(cloneObject, newValue);                    
                }
            }
            return (T)cloneObject;
        }


        public static T DeepCopy<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj == null || obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                //try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                //catch { }
                field.SetValue(retval, DeepCopy(field.GetValue(obj)));
            }
            return (T)retval;
        }
    }
}
