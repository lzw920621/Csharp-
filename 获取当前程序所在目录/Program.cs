using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取当前程序所在目录
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.获取模块的完整路径。
            string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            //2.获取和设置当前目录(该进程从中启动的目录)的完全限定目录
            string path2 = System.Environment.CurrentDirectory;

            //3.获取应用程序的当前工作目录
            string path3 = System.IO.Directory.GetCurrentDirectory();

            //4.获取程序的基目录
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory;

            //5.获取和设置包括该应用程序的目录的名称
            string path5 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            //6.获取启动了应用程序的可执行文件的路径
            //string path6 = System.Windows.Forms.Application.StartupPath;//winform应用中可以使用该方式

            //7.获取启动了应用程序的可执行文件的路径及文件名
            //string path7 = System.Windows.Forms.Application.ExecutablePath;//winform应用中可以使用该方式
        }
    }
}
