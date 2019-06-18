using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using 自定义类型转换;

namespace 运算符重载
{
    class LimitedInt
    {
        int theValue = 0;
        public int TheValue
        {
            get
            {
                if (theValue > 100)
                    return 100;
                else if (theValue < 0)
                    return 0;
                else return theValue;
            }
            set
            {
                if (value > 100)
                {
                    theValue = 100;
                }
                else if (value < 0)
                {
                    theValue = 0;
                }
                else
                {
                    theValue = value;
                }
            }
        }

        //隐式转换的方法必须是public static 
        //将implicit换成explict就是显示转换
        public static implicit operator int(LimitedInt li)//LimitedInt类型 隐式转换为 int类型
        {
            return li.TheValue;
        }
        public static implicit operator LimitedInt(int i)//int类型 隐式转换为 LimitedInt
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = i;
            return li;
        }


        public static LimitedInt operator -(LimitedInt x)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = 0;
            return li;
        }

        public static LimitedInt operator -(LimitedInt x,LimitedInt y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue - y.TheValue;
            return li;
        }

        public static LimitedInt operator +(LimitedInt x,LimitedInt y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue + y.TheValue;
            return li;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
