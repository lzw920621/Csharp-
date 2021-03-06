﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 执行Dos命令和批处理
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExecuteCmd("ver", 10));//
            Console.Read();
        }

        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），  
        /// 如果设定为0，则无限等待</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public static string ExecuteCmd(string command, int seconds)
        {
            string output = ""; //输出字符串  
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动 
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束  
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);//捕获异常，输出异常信息
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }

        /// <summary>
        /// 执行Bat文件
        /// </summary>
        /// <param name="batFilePath">bat文件路径</param>
        /// <returns>返回DOS命令的输出</returns>
        public static string ExecuteBat(string batFilePath)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = batFilePath;//需要执行的Bat文件路径
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = false;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.Start();
            string result = pro.StandardOutput.ReadToEnd();
            if(pro!=null)
            {
                pro.Close();
            }
            return result;
        }
    }
}
