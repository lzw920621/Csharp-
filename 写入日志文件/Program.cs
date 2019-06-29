using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 写入日志文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method();

            //Parallel.For(0, 100, x =>
            //{
            //    Logger2.Write(x.ToString());
            //    Console.WriteLine(x);
            //});


            //Parallel.For(0, 1000, x =>
            //{
            //    Logger3.WriteLog("异常", "", x + "", "");
            //});

            for (int i = 0; i < 10; i++)
            {
                Logger3.WriteLog("异常", "", i + "", "");
                Thread.Sleep(100);
            }

        }

        static void Method()
        {
            try
            {
                Method1();
            }
            catch(Exception exp)
            {
                //Logger.WriteLog(exp.Message);
                Logger.WriteLog("异常", exp.Source, exp.Message, exp.StackTrace);
            }

            Thread.Sleep(100);

            try
            {
                Method2();
            }
            catch (Exception exp)
            {
                //Logger.WriteLog(exp.Message);
                Logger.WriteLog("异常", exp.Source, exp.Message, exp.StackTrace);
            }

            Thread.Sleep(100);

            try
            {
                Method3();
            }
            catch (Exception exp)
            {
                //Logger.WriteLog(exp.Message);
                Logger.WriteLog("异常", exp.Source, exp.Message, exp.StackTrace);
            }
        }


        static void Method1()
        {
            throw new Exception("出现异常情况1");
        }

        static void Method2()
        {
            throw new Exception("出现异常情况2");
        }

        static void Method3()
        {
            throw new Exception("出现异常情况3");
        }
    }
}
