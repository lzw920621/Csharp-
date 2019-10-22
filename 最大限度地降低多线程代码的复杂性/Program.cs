using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大限度地降低多线程代码的复杂性
{
    interface IReadFromShared
    {
        string GetValue();
    }

    interface IWriteToShared
    {
        void SetValue(string value);
    }

    class MySharedClass : IReadFromShared, IWriteToShared
    {
        string _foo;

        public string GetValue()
        {
            return _foo;
        }

        public void SetValue(string value)
        {
            _foo = value;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }

        void Foo(Synchronizer<MySharedClass, IReadFromShared, IWriteToShared> sync)
        {
            sync.Write(x =>
            {
                x.SetValue("new value");
            });
            sync.Read(x =>
            {
                Console.WriteLine(x.GetValue());
            });
        }
    }
}
