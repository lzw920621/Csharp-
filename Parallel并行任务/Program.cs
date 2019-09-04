using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Parallel并行任务
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Parallel.Invoke 主要用于任务的并行
            //这个函数的功能和Task有些相似，就是并发执行一系列任务，然后等待所有完成。和Task比起来，省略了Task.WaitAll这一步，自然也缺少了Task的相关管理功能。它有两种形式:
            //Parallel.Invoke( params Action[] actions);
            //Parallel.Invoke(Action[] actions, TaskManager manager, TaskCreationOptions options);
            var actions = new Action[]
            {
                () => ActionTest("test 1"),
                () => ActionTest("test 2"),
                () => ActionTest("test 3"),
                () => ActionTest("test 4")
            };

            Console.WriteLine("Parallel.Invoke 1 Test");
            Parallel.Invoke(actions);


            //2. For方法，主要用于处理针对数组元素的并行操作(数据的并行) 
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码……ThreadId={2}", i, nums[i], Thread.CurrentThread.ManagedThreadId);
            });


            //3. Foreach方法，主要用于处理泛型集合元素的并行操作(数据的并行)
            List<int> nums1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Parallel.ForEach(nums1, (item) =>
            {
                Console.WriteLine("针对集合元素{0}的一些工作代码……ThreadId={1}", item, Thread.CurrentThread.ManagedThreadId);
            });

        }

        static void ActionTest(object value)
        {
            Console.WriteLine(">>> thread:{0}, value:{1}",
            Thread.CurrentThread.ManagedThreadId, value);
        }
    }
}
