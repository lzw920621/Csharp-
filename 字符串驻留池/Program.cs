using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串驻留池
{
    //字符串被创建后会被放入驻留池中,下次创建相同的字符串时直接将引用指向它


    /*
    1. 驻留池由CLR来维护，其中的所有字符串对象的值都不相同。

    2. 只有编译阶段的文本字符常量会被自动添加到驻留池。

    3.运行时期动态创建的字符串不会被加入到驻留池中。

    4.string.Intern()可以把动态创建的字符串加入到驻留池中。

    即使这个动态创建的字符串和驻留池中的某个字符串的值相等，引用也不会相等。

    即使是动态创建的两个字符串的值相等，他们的引用依然不相等。（charArray.ToString()特例）
    --------------------- 
    作者：changuncle 
    来源：CSDN 
    原文：https://blog.csdn.net/xiaouncle/article/details/87832198 
    版权声明：本文为博主原创文章，转载请附上博文链接！
    */
    class Program
    {
        static void Main(string[] args)
        {
            string a = "abc";
            string b = "abc";//不会再创建新的"abc"对象   会检查驻留池
            //string c=string.IsInterned("abc");

            StringBuilder sb = new StringBuilder("abc");            //运行时期动态创建的字符串不会被加入到驻留池中
            string d = sb.ToString();
            bool isEqual1= ReferenceEquals(a, d);//引用不相同
            bool isEqual2 = a.Equals(d);
        }
    }
}
