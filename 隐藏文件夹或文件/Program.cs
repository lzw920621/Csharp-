using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 隐藏文件夹或文件
{
    class Program
    {
        static void Main(string[] args)
        {
            string desDir = @"C:\Users\lzw92\Desktop\新建文件夹 (6)";
            DirectoryInfo dirInfo = new DirectoryInfo(desDir);
            dirInfo.Attributes = FileAttributes.Hidden;//隐藏文件夹
            //dirInfo.Attributes = FileAttributes.Directory;//还原
            

            //FileInfo dirInfo = new FileInfo(desDir);
            //dirInfo.Attributes = FileAttributes.Hidden;//隐藏文件
        }
    }
}
