using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判断委托是实例方法还是静态方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();


            Action action1 = test.ShowHelloWorld1;//实例方法
            bool isEqual = (action1.Target as Test).Equals(test);//Target指向的对象是这个方法对应的实例

            Action action2 = Test.ShowHelloWorld2;//静态方法
            bool isNull = action2.Target is null;//Target指向的对象为空

            Action action3 = test.ShowHelloWorld1;
            object obj = action3.Target;
            action3 += Test.ShowHelloWorld2;
            obj = action3.Target;//对于多播委托,target指向最近添加的方法所对应的实例
        }
    }

    public class Test
    {
        /// <summary>
        /// 实例方法
        /// </summary>
        public void ShowHelloWorld1()
        {
            Console.WriteLine("Hello World! -- 1");
        }

        /// <summary>
        /// 静态方法
        /// </summary>
        public static void ShowHelloWorld2()
        {
            Console.WriteLine("Hello World! -- 2");
        }
    }
}
