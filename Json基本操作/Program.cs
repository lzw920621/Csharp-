using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace Json基本操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = File.ReadAllText(@"C:\Users\lzw92\Documents\WeChat Files\lzw920621\FileStorage\File\2019-10\38803MB9EU000FSE.20190522183554.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> dic = (Dictionary<string, object>)serializer.DeserializeObject(jsonData);
            
        }
    }
}
