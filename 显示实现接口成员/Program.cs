using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 显示实现接口成员
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IMyInterface
    {
        void DoSomething();
        void DoSomethingElse();
    }

    public interface IMyInterface2
    {
        void DoSomething();
        void DoSomethingElse();
    }

    public class MyClass : IMyInterface, IMyInterface2   //继承了两个接口,且这两个接口有  同名的成员
    {
        //可以通过显式实现来进行区分
        //注意点:显式实现接口方法的时候不需要加public、private等关键词。

        void IMyInterface.DoSomething()
        {
            throw new NotImplementedException();
        }

        void IMyInterface.DoSomethingElse()
        {
            throw new NotImplementedException();
        }

        void IMyInterface2.DoSomething()
        {
            throw new NotImplementedException();
        }

        void IMyInterface2.DoSomethingElse()
        {
            throw new NotImplementedException();
        }
    }
}
