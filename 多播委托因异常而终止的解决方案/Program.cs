using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多播委托因异常而终止的解决方案
{
    /*
    首先，问题是这样的：“C#中有多播委托，那么在使用多播委托时，假设方法列表中有多个方法，但委托执行到某个方法时抛出异常，
    那么整个委托的迭代是否会终止呢？如果终止的话，可以使用什么方法容错，使整个委托链中的方法继续执行呢？
    如果把多播委托换成事件，那么又会有怎么样的效果呢？”。

　　答案：

　　1.C#多播委托执行到某个方法抛出异常的时候，整个委托的迭代将在抛出异常的地方退出终止，后面的方法就不会再去执行了；

　　2.可以通过自己设计迭代方法来容错，起到即使抛出异常，委托链也不会中止执行的效果；

　　3.事件与多播委托的效果一样；

    */
    class Program
    {
        static void Main(string[] args)
        {
            Action multiDelegate;
            //创建多播委托
            multiDelegate = MultiDelegate.Func1;
            multiDelegate += MultiDelegate.Func2;

            //调用委托，观察结果
            try
            {
                multiDelegate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //在调用Func1方法以后抛出了异常，整个委托的迭代在此处终止，后面的Func2也不再执行了。
            //为了避免这种情况的发生，使得我们的程序具有一定的容错机制。即使在委托抛出异常的时候，
            //后面的方法依旧可以执行，我们需要自定义一个委托方法列表的迭代方法。众所周知，委托本质上也是一个类，
            //而Delegate类定义了GetInvocationList()方法，它返回Delegate的委托链中的对象数组。
            //我们可以通过这个方法拿到委托链中的对象，然后建立自己的迭代方法，从而解决多播委托在抛出异常后终止的问题，
            //具体的代码如下：


            //手动迭代委托方法列表，可以处理抛出异常后委托链终止执行的问题
            //定义方法列表数组，使用GetInvocationList()  
            //注意使用的是Delegate类，不是delegate关键字  
            Delegate[] myDelegates = multiDelegate.GetInvocationList();//获取委托的方法列表
            foreach (var @delegate in myDelegates)
            {
                var delegateItem = (Action)@delegate;
                //分别调用委托
                try
                {
                    delegateItem();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }

    class MultiDelegate
    {
        /// <summary>
        /// 会抛出异常的方法1
        /// </summary>
        public static void Func1()
        {
            Console.WriteLine("方法1，会抛出异常！");
            throw new Exception("抛出异常！");
        }

        /// <summary>
        /// 正常方法2
        /// </summary>
        public static void Func2()
        {
            Console.WriteLine("方法2");
        }

    }
}
