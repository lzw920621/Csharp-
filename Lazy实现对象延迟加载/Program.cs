using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lazy实现对象延迟加载
{
    //Lazy<T>要实现的就是按“需”创建，而不是按时创建
    //我们往往有这样的情景，一个关联对象的创建需要较大的开销，为了避免在每次运行时创建这种家伙，有一种聪明的办法叫做实现“懒对象”，或者延迟加载。

    public class Big
    {
        public int ID { get; set; }

        public string CreatedByThread { get; protected set; }

        public Big()
        {
            CreatedByThread = Thread.CurrentThread.Name;
        }
       
        // Other resources
    }
    public class Big1
    {
        public int ID { get; set; }

        public Big1(int id)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Big> lazyBig = new Lazy<Big>();//构造函数无参数 的对象

            //Big bigObj = lazyBig.Value;//第一次调用value属性时创建Big对象

            Lazy<Big1> lazyBig1 = new Lazy<Big1>(() => new Big1(10));//构造函数有参数 的对象

            Thread th1 = new Thread(() => Console.WriteLine(lazyBig.Value.CreatedByThread));
            th1.Name = "线程1";

            Thread th2 = new Thread(() => Console.WriteLine(lazyBig.Value.CreatedByThread));
            th2.Name = "线程2";

            Thread th3 = new Thread(() => Console.WriteLine(lazyBig.Value.CreatedByThread));
            th3.Name = "线程3";

            th3.Start();
            Thread.Sleep(10);
            th2.Start();
            Thread.Sleep(10);
            th1.Start();

            th1.Join();
            th2.Join();
            th3.Join();

            Console.ReadKey();

        }

        
    }
}
