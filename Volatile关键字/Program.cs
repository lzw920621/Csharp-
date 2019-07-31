using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volatile关键字
{
    /*
    编译器在优化代码时，可能会把经常用到的代码存在Cache里面，然后下一次调用就直接读取Cache而不是内存，这样就大大提高了效率。
    但是问题也随之而来了。在多线程程序中，如果把一个变量放入Cache后，又有其他线程改变了变量的值，那么本线程是无法知道这个变化的。
    它可能会直接读Cache里的数据。但是很不幸，Cache里的数据已经过期了，读出来的是不合时宜的脏数据。这时就会出现bug。
    用Volatile声明变量可以解决这个问题。用Volatile声明的变量就相当于告诉编译器，我不要把这个变量写Cache，因为这个变量是可能发生改变的。

    Volatile可以保证在多线程中每个线程取到字段值(被voatile修饰的字段)是最新的

    注意:volatile不能保证线程安全(能保证读操作的原子性,但不能保证写操作的原子性)
    */
    class Program
    {
        //以下例子显示volatile不能保证线程安全
        
        private static volatile int a;
        private static int b;
        private const int test = 1000000;
        static void Main(string[] args)
        {
            Parallel.For(0, test, i =>
            {
                a++;//这里的不安全是由多个线程赋值造成的 ,这里存在给a重新赋值的操作,比方说有两个线程同时读到a=1000,其中一个给它重新赋值1001,后一个线程也给它赋值1001
            });
            for (int i = 0; i < test; i++)
            {
                b++;
            }

            Console.WriteLine("a:" + a);
            Console.WriteLine("b:" + b);
            Console.ReadKey();
        }
    }
}
