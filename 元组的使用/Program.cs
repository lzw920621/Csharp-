using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 元组的使用
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Tuple<int, char, string, bool> myTuple = new Tuple<int, char, string, bool>(1, 'a', "abc", true);
            Console.WriteLine(myTuple.Item1);
            Console.WriteLine(myTuple.Item2);
            Console.WriteLine(myTuple.Item3);
            Console.WriteLine(myTuple.Item4);
            Console.ReadKey();
        }


        //用元组来作为方法的返回值,可以返回多个不同类型的值 这样比使用输出参数更加方便
        static Tuple<S,K,T> MyMethod<S,K,T>(S s,K k,T t)
        {
            return new Tuple<S, K, T>(s,k,t); 
        }
    }
}
