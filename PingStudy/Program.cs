using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PingStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "www.baidu.com";
            Ping p1 = new Ping();
            PingReply reply = p1.Send(host); //发送主机名或Ip地址
            StringBuilder sbuilder;
            if (reply.Status == IPStatus.Success)
            {
                sbuilder = new StringBuilder();
                sbuilder.AppendLine(string.Format("Address: {0} ", reply.Address.ToString()));
                sbuilder.AppendLine(string.Format("RoundTrip time: {0} ", reply.RoundtripTime));
                sbuilder.AppendLine(string.Format("Time to live: {0} ", reply.Options.Ttl));
                sbuilder.AppendLine(string.Format("Don't fragment: {0} ", reply.Options.DontFragment));
                sbuilder.AppendLine(string.Format("Buffer size: {0} ", reply.Buffer.Length));
                Console.WriteLine(sbuilder.ToString());
            }
            else if (reply.Status == IPStatus.TimedOut)
            {
                Console.WriteLine("超时");
            }
            else
            {
                Console.WriteLine("失败");
            }

            Console.ReadKey();

        }
    }
}
