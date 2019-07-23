using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 弱引用
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            WeakReference wr = new WeakReference(mc);//创建弱引用 被弱引用的对象是可以被GC正常回收的
            mc = null;//这个时候mc没有被引用了 随时可能被垃圾回收器回收
            //do something
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");

            object obj = wr.Target;//先创建一个正常的引用
            if(obj!=null)//如果对象不为空说明还未被回收
            {
                MyClass mc1 = (MyClass)obj;
            }

            //错误用法
            if(wr.Target!=null)//这里弱引用的对象 在这一刻没有被回收 但在下一刻可能已经被回收(尤其是在多线程情况下) 所以应该先创建一个正常引用 再判断是否为空
            {
                MyClass mc2 = wr.Target as MyClass;
            }
        }
    }

    class MyClass
    {

    }
}
