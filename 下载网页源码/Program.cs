using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 下载网页源码
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = DownloadCode("https://www.cnblogs.com/yinmu/p/10994088.html");

        }

        /// <summary>
        /// 下载网页源代码
        /// </summary>
        /// <param name="Url">网页路径</param>
        /// <returns></returns>
        private static string DownloadCode(string Url)
        {
            string page = "";
            try
            {
                WebClient webClient = new WebClient();
                //webClient.Encoding = Encoding.UTF8;//否则很可能出现乱码
                //page = webClient.DownloadString(Url);
                byte[] pageData = webClient.DownloadData(Url);
                page= Encoding.GetEncoding("utf-8").GetString(pageData);
            }
            catch (Exception ec)
            {
                throw new Exception(ec.Message.ToString());
            }
            return page;
        }

    }
}
