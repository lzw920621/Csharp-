using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串转枚举类型
{
    enum MyEnum
    {
        type1,
        type2,
        type3,
        type4
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "type2";
            MyEnum myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), str);
        }
    }
}
