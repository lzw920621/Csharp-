using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准Dispose模式
{
    class MyClass : IDisposable
    {
        bool disposed = false;//标志位 释放状态

        ~MyClass()//析构函数 也叫终结器  不能手动调用  垃圾回收器会自动调用它
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)//这里的disposing参数是为了区分 protected Dispose方法是被析构函数调用还是被public Dispose调用
        {
            if(disposed==false)
            {
                if(disposing==true)//被public Dispose调用 则同时释放托管资源和非托管资源
                {
                    //释放托管资源

                }
                //Disposing==false则代表是析构函数调用的 这种情况下只释放非托管资源
                //释放非托管资源    
                
            }
            disposed = true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
