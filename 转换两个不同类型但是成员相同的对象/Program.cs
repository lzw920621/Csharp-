using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 转换两个不同类型但是成员相同的对象
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = CopySameFieldsObject<B>(a);
        }

        /// <summary>
        /// 转换两个不同类型但是成员相同的对象
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns></returns>
        public static T CopySameFieldsObject<T>(Object source)
        {
            Type srcT = source.GetType();
            Type destT = typeof(T);

            // 构造一个要转换对象实例
            Object instance = destT.InvokeMember("", BindingFlags.CreateInstance, null, null, null);

            // 这里指定搜索所有公开和非公开的字段
            FieldInfo[] srcFields = srcT.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // 将源头对象的每个字段的值分别赋值到转换对象里，因为假定字段都一样，这里就不做容错处理了
            foreach (FieldInfo field in srcFields)
            {
                destT.GetField(field.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
                    SetValue(instance, field.GetValue(source));
            }

            return (T)instance;
        }
    }

    public class A
    {
        public int field1 = 1;
        public int field2 = 2;
        public int field3 = 3;
        public bool field4 = true;
    }

    public class B
    {
        public int field1 = 1;
        public int field2 = 2;
        public int field3 = 3;
        public bool field4 = true;
    }
}
