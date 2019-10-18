using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现Zip文件解压
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipExe = @"C:\Program Files\7-Zip\7z.exe";   //7-Zip工具的运行程序
            string zipFileName = @"E:\MyZip\Report.zip";        //需要被解压的Zip文件
            string unZipPath = @"E:\MyZip\";                    //解压后文件存放目录
            string pwd = "123";                                 //解压密码

            //执行解压命令
            string cmd = String.Format("\"{0}\" e \"{1}\" -p{2} -o\"{3}\"", zipExe, zipFileName, pwd, unZipPath);
            ProcessHelper.ExecCommand(cmd);
        }
        
    }
}
