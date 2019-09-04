using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace winform应用程序未处理异常的统一处理技巧
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //处理未捕获的异常，始终将异常传送到 ThreadException 处理程序。忽略应用程序配置文件。
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //订阅ThreadException事件，处理UI线程异常，处理方法为 Application_ThreadException，关于事件的相关知识就不在这叙述了  
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            //订阅UnhandledException事件，处理非UI线程异常 ，处理方法为 CurrentDomain_UnhandledException  
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new Form1());
        }



        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "******************************************************************************************************" + "\r\n";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.ExceptionObject as Exception;
            if (error != null)
            {
                str += string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str += string.Format("应用程序线程错误:{0}", e) + "\r\n";
            }
            str += "******************************************************************************************************" + "\r\n";
            WriteLog(str);
            MessageBox.Show("发生致命错误，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
        /// <summary>
        ///这就是我们要在发生未处理异常时处理的方法，我这是写出错详细信息到文本，给大家做个参考
        ///做法很多，可以是把出错详细信息记录到文本、数据库，发送出错邮件到作者信箱或出错后重新初始化等等
        ///这就是仁者见仁智者见智，大家自己做了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = "********************************************************************" + "\r\n";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str += string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str += string.Format("应用程序线程错误:{0}", e) + "\r\n";
            }
            str += "********************************************************************" + "\r\n";
            WriteLog(str);
            MessageBox.Show("发生致命错误，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void WriteLog(string str)
        {
            string folder = Application.StartupPath + "\\ErrLog";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = folder + "\\errorLog.txt";
            
            File.AppendAllText(filePath, str);
        }
    }
}
