using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace delegate实现多线程
{
    public delegate void DoSomething();
    public delegate int DoSomethingReturn();
    public delegate void DoMore(int age, string name);
    public delegate int DoMoreReturn(int age, string name);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("这是主线程 ID:" + Thread.CurrentThread.ManagedThreadId);
            //无参无返回值
            DoSomething doSomething = Method1;
            doSomething.BeginInvoke(null, null);

            //无参有返回值
            DoSomethingReturn doSomethingReturn = Method2;
            IAsyncResult iasyncResult = doSomethingReturn.BeginInvoke(null, null);
            int result = doSomethingReturn.EndInvoke(iasyncResult);//要获取委托的返回值，必须等待子线程执行结束

            //有参无返回值
            DoMore doMore = Method3;
            doMore.BeginInvoke(16, "guo", null, null);

            //有参有返回值
            DoMoreReturn doMoreReturn = Method4;
            IAsyncResult iasyncResult2 = doMoreReturn.BeginInvoke(16, "guo", null, null);
            int result2 = doMoreReturn.EndInvoke(iasyncResult2);//要获取委托的返回值，必须等待子线程执行结束

            //异步回调
            DoMoreReturn doMoreReturn2 = Method4;
            doMoreReturn2.BeginInvoke(16, "guo", Callback, "wulala");
            Console.ReadKey();
        }

        static void Method1()
        {
            Console.WriteLine("Method1 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static int Method2()
        {
            Console.WriteLine("Method2 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
            return 1;
        }

        static void Method3(int num,string str)
        {
            Console.WriteLine("Method3 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static int Method4(int num,string str)
        {
            Console.WriteLine("Method4 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
            return 2;
        }

        static void Callback(IAsyncResult iasyncResult)
        {
            Console.WriteLine("回调方法 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
            AsyncResult asyncResult = (AsyncResult)iasyncResult;
            //获取回调方法的参数
            string parameter = asyncResult.AsyncState.ToString();
            //获取委托的返回值
            DoMoreReturn doMore = (DoMoreReturn)asyncResult.AsyncDelegate;
            int result = doMore.EndInvoke(asyncResult);
            Thread.Sleep(3000);
            Console.WriteLine("result={0},parameter={1}", result, parameter);
            Console.WriteLine("Callback-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

    }
}
