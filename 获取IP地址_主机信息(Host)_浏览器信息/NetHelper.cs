using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace 获取IP地址_主机信息_Host__浏览器信息
{
    class NetHelper
    {
        #region Ip(获取Ip)
        /// <summary>
        /// 获取Ip
        /// </summary>
        public static string Ip
        {
            get
            {
                var result = string.Empty;
                if (HttpContext.Current != null)
                    result = GetWebClientIp();
                if (string.IsNullOrWhiteSpace(result))
                    result = GetLanIp();
                return result;
            }
        }
        /// <summary>
        /// 获取Web客户端的Ip
        /// </summary>
        /// <returns></returns>
        private static string GetWebClientIp()
        {
            var ip = GetWebRemoteIp();
            foreach (var hostAddress in Dns.GetHostAddresses(ip))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取Web远程Ip
        /// </summary>
        /// <returns></returns>
        private static string GetWebRemoteIp()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        /// <summary>
        /// 获取局域网IP
        /// </summary>
        /// <returns></returns>
        private static string GetLanIp()
        {
            string ip = string.Empty;
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    //return hostAddress.ToString();
                    ip = ip + ";" + hostAddress.ToString();
            }
            if (!string.IsNullOrEmpty(ip) && ip.Contains(";"))
            {
                ip = ip.Substring(1);
            }
            return ip;
        }
        #endregion


        #region Host(获取主机名)
        /// <summary>
        /// 获取主机名
        /// </summary>
        public static string Host
        {
            get
            {
                return HttpContext.Current == null ? Dns.GetHostName() : GetWebClientHostName();
            }
        }
        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        /// <returns></returns>
        private static string GetWebClientHostName()
        {
            if (!HttpContext.Current.Request.IsLocal)
                return string.Empty;
            var ip = GetWebRemoteIp();
            var result = Dns.GetHostEntry(IPAddress.Parse(ip)).HostName;
            if (result == "localhost.localdomain")
                result = Dns.GetHostName();
            return result;
        }


        #endregion


        #region Browser(获取浏览器信息)
        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        public static string Browser
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var browser = HttpContext.Current.Request.Browser;
                return string.Format("{0} {1}", browser.Browser, browser.Version);
            }
        }
        #endregion


    }
}
