using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串驻留池
{
    //字符串被创建后会被放入驻留池中,下次创建相同的字符串时直接将引用指向它
    class Program
    {
        static void Main(string[] args)
        {
            string a = "abc";
            string b = "abc";//不会再创建新的"abc"对象 
            string c=string.IsInterned("abc");
        }
    }
}
