using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标志枚举和普通枚举的区别
{
    class Program
    {
        static void Main(string[] args)
        {
            //普通枚举是互斥的
            //StateA stateA = StateA.state1 | StateA.state2;//这样是没有意义的

            //标志枚举
            StateB stateB = StateB.state1 | StateB.state2 | StateB.state3;
            Console.WriteLine(stateB);
            Console.ReadKey();
        }
    }

    public enum StateA//普通枚举
    {
        state1,
        state2,
        state3,
        state4
    }

    [Flags]//必须添加这个特性
    public enum StateB//标志枚举 每个枚举对象都对应一个二进制位 可以定义一个多状态并存的枚举对象
    {
        state1=1,
        state2=2,
        state3=4,
        state4=8
    }
}
