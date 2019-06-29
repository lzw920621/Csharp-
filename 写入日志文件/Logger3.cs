using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace 写入日志文件
{
    /// <summary>  
    /// 日志消息类型的枚举  
    /// </summary>  
    enum MessageType
    {
        /// <summary>  
        /// 普通信息类型的日志记录  
        /// </summary>  
        Information,
        /// <summary>  
        /// 警告信息类型的日志记录  
        /// </summary>  
        Warning,
        /// <summary>  
        /// 错误信息类型的日志记录  
        /// </summary>  
        Error,
        /// <summary>  
        /// 成功信息类型的日志记录  
        /// </summary>  
        Success,
        /// <summary>  
        /// 致命类型的日志记录  
        /// </summary>  
        Fatal
    }

    struct Message
    {
        public string Type { get; private set; }
        public string Time { get; private set; }
        public string Source { get; private set; }
        public string MessageText { get; private set; }
        public string StackTrace { get; private set; }

        public Message(string type, string time, string source, string message, string stackTrace)
        {
            this.Type = type;
            this.Time = time;
            this.Source = source;
            this.MessageText = message;
            this.StackTrace = stackTrace;
        }
    }

    static class Logger3
    {        
        private static ConcurrentQueue<Message> messageQueue = new ConcurrentQueue<Message>();//消息队列  ConcurrentQueue是比较高效的线程安全队列
        private static BackgroundWorker bgWorker = new BackgroundWorker();

        public static void WriteLog(string type, string source, string message, string stackTrace)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.ff");
            Message msg = new Message(type, time, source, message, stackTrace);
            messageQueue.Enqueue(msg);//将消息放入消息队列

            //if(!bgWorker.IsBusy)
            //{
            //    bgWorker.RunWorkerAsync();
            //}
            Task.Run(() =>
            {
                while (messageQueue.Count > 0)
                {
                    Message _msg;
                    messageQueue.TryDequeue(out _msg);
                    WriteLog(msg);
                }
            });
        }
      
        static void DoWork(object sender,DoWorkEventArgs e)
        {
            while(messageQueue.Count>0)
            {
                Message msg;
                messageQueue.TryDequeue(out msg);
                WriteLog(msg);
            }
        }

        private static void WriteLog(Message msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "Logs\\");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileFullName = Path.Combine(path, string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));//日子文件名

            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(msg.Time + " : " + msg.Type);
                output.WriteLine('\t' + msg.MessageText);
                output.WriteLine('\t' + msg.Source);
                output.WriteLine('\t' + msg.StackTrace);
                output.WriteLine("**********************************************");
                output.Close();
            }
        }

        static Logger3()
        {            
            bgWorker.DoWork += DoWork;
            bgWorker.WorkerSupportsCancellation = true;
        }     
    }
}
