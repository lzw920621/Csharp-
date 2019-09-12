using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace 下载文件
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isSuccess = DownloadFile("https://static.leiphone.com/uploads/new/images/20190619/5d09a4b3a5077.png?imageView2/2/w/740", @"I:\test\");
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <returns>文件名称</returns>
        public static bool DownloadFile(string url,string pathToSave)
        {
            try
            {
                string fileName = GetFileName(url);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                WebClient client = new WebClient();
                client.DownloadFile(url, pathToSave + fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件名称
        /// </summary>
        public static string GetFileName(string url)
        {
            string fileName = "";
            string fileExt = url.Substring(url.LastIndexOf(".")).Trim().ToLower();
            Random rnd = new Random();
            fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString() + fileExt;
            return fileName;
        }

    }
}
