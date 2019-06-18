using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义类型转换
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
                if(value>100)
                {
                    theValue = 100;
                }
                else if(value<0)
                {
                    theValue = 0;
                }
                else
                {
                    theValue = value;
                }
            }
        }

        //隐式转换的方法必须是 static 
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

        //public static explicit operator int(LimitedInt li)//LimitedInt类型 显式转换为 int类型
        //{
        //    return li.TheValue;
        //}
        //public static explicit operator LimitedInt(int i)//int类型 显式转换为 LimitedInt
        //{
        //    LimitedInt li = new LimitedInt();
        //    li.TheValue = i;
        //    return li;
        //}
    }


    class Program
    {
        static void Main(string[] args)
        {
            LimitedInt li = 500;//整形隐式转换为limitedint
            int value = li;//limitedint隐式转换为int
        }
    }
}
