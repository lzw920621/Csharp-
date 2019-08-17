using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用Process类打开文件或系统应用
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process.Start("notePad");//打开记事本
            //Process.Start("msPaint");//打开画图工具
            //Process.Start("calc");//打开计算器
            string path = @"C:\Users\lzw92\Desktop\耳机组件半成品数据格式.csv";
            Process.Start(path);
        }
    }
}
