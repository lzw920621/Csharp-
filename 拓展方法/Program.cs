using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace 拓展方法
{
    //类必须为static的
    public static class StringHelper
    {
        //扩展方法必须为静态的
        //扩展方法的第一个参数必须由this来修饰（第一个参数是被扩展的对象）
        public static bool isEmail(this string _string)
        {
            return Regex.IsMatch(_string,
                @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
        }

        public static bool isNumber(this string _string)
        {
            return Regex.IsMatch(_string, @"^[+-]?\d*[.]?\d*$");
        }

        public static string SelfProduct(this string _string,int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += _string;
            }
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = "czx@123.com";
            Console.WriteLine(str.isEmail());
            string str1 = "-002123.5";
            Console.WriteLine(str1.isNumber());

            Console.WriteLine(str1.SelfProduct(3));
            Console.ReadKey();
            
        }

        
    }

    
}
