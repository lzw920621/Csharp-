using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 泛型单例
{
    //不支持非公共的无参构造函数的   不推荐 因为T有公共的无参构造函数,可以在外部实例化T
    public abstract class BaseInstance<T> where T : class, new()
    {
        private readonly static object lockObj = new object();
        private static T instance = null;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }

    //支持非公共的无参构造函数的   推荐使用这种 
    public abstract class Singleton<T> where T : class
    {
        private static T instance;
        private static object lockObject = new object();
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            CreateInstance();
                        }
                    }
                }
                return instance;
            }
        }       
        private static void CreateInstance()
        {
            Type t = typeof(T);
            ConstructorInfo[] ctors = t.GetConstructors();
            if (ctors.Length > 0)
            {
                throw new InvalidOperationException(String.Format("{0} has at least one accesible ctor making it impossibleto enforce DyhSingleton behaviour", t.Name));
            }
            instance = (T)Activator.CreateInstance(t, true);
        }
    }
                    

    public class ClassA
    {

    }

    public class ClassB
    {

    }

    public class ClassC:Singleton<ClassC>
    {
        private ClassC() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ClassA classASingleton1 = BaseInstance<ClassA>.Instance;
            //ClassA classASingleton2 = BaseInstance<ClassA>.Instance;

            //bool isEqual = classASingleton1.Equals(classASingleton2);

            ClassC classC1 = ClassC.Instance;
            ClassC classC2 = ClassC.Instance;
            bool isEqual = classC1.Equals(classC2);
        }
    }
}
