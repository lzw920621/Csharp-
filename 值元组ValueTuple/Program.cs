using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 值元组ValueTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTuple<string, int, bool> valueTuple = Xyz();
        }

        //返回多个参数
        static ValueTuple<string, int, bool> ThreeResult()
        {
            return new ValueTuple<string, int, bool>("一二三", 123, true);
        }

        //另一种写法 

        static (string x,int y,bool z) Xyz()
        {
            return ("一二三", 123, true);
        }
    }
}
