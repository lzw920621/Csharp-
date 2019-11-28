using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 如何正确的保留异常的原始栈信息
{
    class Program
    {
        /*
        异常捕捉的原理:

        默认情况下在C#的一个函数中（注意这里说的是在一个函数中，不是跨多个函数），
        只会将最后一个异常抛出的位置记录到异常堆栈中，也就是说在一个函数中无论你用throw语句抛出了多少次异常，
        异常堆栈中始终记录的是函数最后一次throw异常的位置
        */
        static void ThrowExceptionFunction1()
        {
            try
            {
                try
                {
                    try
                    {
                        throw new Exception("模拟异常");
                    }
                    catch (Exception ex1)
                    {
                        throw;
                    }
                }
                catch (Exception ex2)
                {
                    throw;
                }
            }
            catch (Exception ex3)
            {
                throw;//异常堆栈中始终记录的是函数最后一次throw异常的位置
            }
        }


        /*
        上面我们说了C#只会将一个函数中最后一次抛出异常的位置记录到异常堆栈之中，
        那么有什么办法能将一个函数中抛出的所有异常都记录到异常堆栈中吗？
        答案是可以的，构造嵌套异常即可，如下代码所示：
        */
        static void ThrowExceptionFunction2()
        {
            try
            {
                try
                {
                    try
                    {
                        throw new Exception("模拟异常1");
                    }
                    catch (Exception ex1)
                    {
                        throw new Exception("模拟异常2", ex1);
                    }
                }
                catch (Exception ex2)
                {
                    throw new Exception("模拟异常3", ex2);
                }
            }
            catch (Exception ex3)
            {
                throw new Exception("模拟异常4", ex3);
            }

        }


        static void Main(string[] args)
        {
            //try
            //{
            //    ThrowExceptionFunction1();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.StackTrace);//因为C#会为每个函数的异常记录一次堆栈信息，而本例中有两个函数分别为ThrowExceptionFunction和Main，所以这里堆栈捕捉到了两个异常一个是在函数ThrowExceptionFunction中40行，另一个是Main函数中82行，
            //}

            try
            {
                ThrowExceptionFunction2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());//要想输出函数ThrowExceptionFunction2内抛出的所有异常，将ThrowExceptionFunction内部的异常都嵌套封装即可，然后在输出异常的时候使用ex.ToString()函数，就可以输出所有嵌套异常的堆栈信息
            }
            Console.ReadKey();
        }


    }
}
