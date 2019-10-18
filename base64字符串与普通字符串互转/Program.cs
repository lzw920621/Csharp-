using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base64字符串与普通字符串互转
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "base64字符串与普通字符串互转";
            byte[] b = System.Text.Encoding.Default.GetBytes(a);

            //转成 Base64 形式的 System.String  
            a = Convert.ToBase64String(b);
            Console.WriteLine(a);

            //转回到原来的 System.String
            byte[] c = Convert.FromBase64String(a);
            a = System.Text.Encoding.Default.GetString(c);
            Console.WriteLine(a);
        }
    }
}
