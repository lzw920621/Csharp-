using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 多线程死锁
{    
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Thread t = new Thread(myClass.LockFunc);
            t.Start();//执行t线程-->objA被锁住

            lock (myClass.objB)
            {
                Console.WriteLine("我是主线程，已对objB加锁，马上加锁objA");
                /*
                 结果是：我是主线程，已对objB加锁，马上加锁objA
                        我是线程t，已对objA加锁，马上加锁objB
                 可见此时发送了死锁，这是一种情况，多试几次会出现顺利执行的结果。
                 */
                lock (myClass.objA)
                {
                    Console.WriteLine("我是主线程，已对objA、objB都加锁");
                }
            }
        }
    }

    class MyClass
    {
        public object objA = new object();
        public object objB = new object();

        public void LockFunc()
        {
            lock (objA)
            {
                Console.WriteLine("我是线程t，已对objA加锁，马上加锁objB");
                
                lock (objB)
                {
                    Console.WriteLine("我是线程t，已对objA、objB都加锁");
                }
            }
        }
    }
}
