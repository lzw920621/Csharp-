using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取字符串所占的字节数
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "123一二三";
            int length = str.Length;//字符个数
            int length2 = System.Text.Encoding.Default.GetByteCount(str);//字节个数 中文字符占两个字节            
        }        
    }
}
