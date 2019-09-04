using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task实现多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("这是主线程 ID:" + Thread.CurrentThread.ManagedThreadId);

            //Task三种启动方式 Start()  StartNew()  Run()

            Task task1 = new Task(Method1);
            task1.Start();

            Task task2 = new TaskFactory().StartNew(Method1);

            Task task3 = Task.Run(new Action(Method1));

            Console.ReadKey();

            //带返回值
            Task<int> task = new Task<int>(()=>Method2(5));
            task.Start();
            int result = task.Result;

            Task<int> task4 = new Task<int>(a => { return (int)a + 1; }, 1);
            task4.Start();
            int result2 = task4.Result;

            //连续任务（有先后关系）
            Task task5 = new Task(Method1);
            Task task6 = task5.ContinueWith(Method3);
            task5.Start();

            Task.WaitAll();

            Console.ReadKey();
        }

        static void Method1()
        {
            Console.WriteLine("Method1 子线程 ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        static int Method2(int num)
        {
            return num;
        }

        static void Method3(Task t)
        {
            Console.WriteLine("task (0) finished", t.Id);
            Console.WriteLine("this task id (0)", Task.CurrentId);
            Console.WriteLine("do something to clean up");
            Thread.Sleep(3000);
        }
    }
}
