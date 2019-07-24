using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace 序列化保存配置文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //保存配置文件
            //MyConfig config = new MyConfig() { ConnectionString = "12344556", Path1 = "wedsa", Path2 = "qwcinf", Path3 = "secnej" };
            //using (FileStream fs = new FileStream(@"配置文件.xml", FileMode.OpenOrCreate))
            //{
            //    XmlSerializer xs = new XmlSerializer(typeof(MyConfig));
            //    xs.Serialize(fs, config);
            //}

            //读取配置文件
            using (FileStream fs = new FileStream(@"配置文件.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(MyConfig));
                MyConfig mc = xs.Deserialize(fs) as MyConfig;
            }
            
        }
    }

    [Serializable]
    public class MyConfig
    {
        public string ConnectionString { get; set; }
        public string Path1 { get; set; }
        public string Path2 { get; set; }
        public string Path3 { get; set; }
    }
}
