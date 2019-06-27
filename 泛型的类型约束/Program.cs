using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型的类型约束
{
    
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        //引用类型约束
        static void MyMethod1<T>(T t) where T:class  //约束:T必须是引用类型
        {

        }
        //值类型约束
        static void MyMethod2<T>(T t) where T:struct //约束:T必须是值类型
        {

        }
        //构造函数类型约束
        public T CreateInstance<T>() where T:new()//T必须有一个可以创建类型实例的无参构造函数
        {
            return new T();
        }
    }
}
