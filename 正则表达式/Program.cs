using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    //字符串匹配
    class Program
    {
        static void Main(string[] args)
        {
            //"^\d+$"   匹配非负整数              
            bool isMatch = Regex.IsMatch("012345", @"^\d+$");
            Console.WriteLine(isMatch);
        }
    }
}
