using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现Zip文件解压
{
    class ProcessHelper
    {
        //方式1
        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="zipExe">7-Zip工具的运行程序的路径</param>
        /// <param name="zipFileName">待解压文件路径</param>
        /// <param name="unZipPath">解压后文件存放目录</param>
        /// <param name="pwd">解压密码</param>
        public static void Unzip(string zipExe, string zipFileName, string unZipPath, string pwd)
        {
            Process process = new Process();
            process.StartInfo.FileName = zipExe;   //7-Zip工具的运行程序
            process.StartInfo.Arguments = String.Format("e \"{0}\" -p{1} -o\"{2}\"", zipFileName, pwd, unZipPath);
            process.Start();
        }

        //方式2
        public static string[] ExecCommand(string commands)
        {
            //msg[0]执行结果;msg[1]错误结果
            string[] msg = new string[2];
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();

                proc.StandardInput.WriteLine(commands);
                proc.StandardInput.WriteLine("exit");

                //执行结果
                msg[0] = proc.StandardOutput.ReadToEnd();
                proc.StandardOutput.Close();

                //出错结果
                msg[1] = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();

                //超时等待
                int maxWaitCount = 10;
                while (proc.HasExited == false && maxWaitCount > 0)
                {
                    proc.WaitForExit(1000);
                    maxWaitCount--;
                }
                if (maxWaitCount == 0)
                {
                    msg[1] = "操作执行超时";
                    proc.Kill();
                }
                return msg;
            }
            catch (Exception ex)
            {
                msg[1] = "进程创建失败:";
                msg[1] += ex.Message.ToString();
                msg[1] += ex.StackTrace.ToString();
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return msg;
        }

    }
}
