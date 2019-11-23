using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 并行Linq查询
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = Enumerable.Range(1, 100000);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //顺序查询
            var normalQuery = source.Where(num => num % 2 == 0).ToList();
            stopwatch.Stop();
            long time1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            // 并行查询,,但是元素顺序会发生变化
            var parallelQuery = source.AsParallel().Where(num => num % 2 == 0).ToList();
            stopwatch.Stop();
            long time2 = stopwatch.ElapsedMilliseconds;
        }
    }
}
