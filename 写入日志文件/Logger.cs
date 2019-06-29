using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 写入日志文件
{
    class Logger
    {

        /// <summary>
        /// 将指定文本写入相应的日志文件
        /// </summary>
        /// <param name="text">要写入的内容</param>        
        public static void WriteLog(string text)
        {
            DateTime time = DateTime.Now;//发生的时间
            text = time.ToString("HH:mm:ss.ff") + " : " + text;//时间 : 日志信息

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path
            , "Logs\\");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string fileFullName = System.IO.Path.Combine(path
            , string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));//日子文件名

            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(text);
                output.WriteLine("**********************************************");
                output.Close();
            }
        }

        public static void WriteLog(string logtype, string source, string message, string stackTrace)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.ff");//时间

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path, "Logs\\");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string fileFullName = System.IO.Path.Combine(path
            , string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));//日子文件名

            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(time + " : " + logtype);
                output.WriteLine('\t' + source);
                output.WriteLine('\t' + message);
                output.WriteLine('\t' + stackTrace);
                output.WriteLine("**********************************************");
                output.Close();
            }
        }
    }
}
