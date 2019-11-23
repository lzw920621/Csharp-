using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小技巧_给事件添加一个空方法以避免空检查
{
    class Program
    {
        //event Action DoSomething;

        event Action DoSomething = delegate { };//添加一个空方法,避免每次调用事件时要判断是否为空
        static void Main(string[] args)
        {
            Program program = new Program();
            ////常规调用
            //if(program!=null)
            //{
            //    program.DoSomething();
            //}

            //加了空方法后,直接调用 不用判断是否为空
            program.DoSomething();
        }
    }
}
