using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;//xml序列化所需的命名空间
using System.Web.Script.Serialization;

namespace 序列化与反序列化
{
    //序列化只会序列化对象的字段属性等数据信息

    class Program
    {
        static void Main(string[] args)
        {
            //序列化：将对象转化为二进制
            //反序列化:将二进制转化为对象
            //作用：传输数据

            //将p这个对象传输给对方电脑
            //Person p = new Person();
            //p.Name = "张三";
            //p.Gender = '男';
            //p.Age = 19;
            //using (FileStream fswrite = new FileStream(@"二进制序列化后的文件.txt", FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fswrite, p);
            //    Console.WriteLine("序列化成功");
            //}

            //接受对方发送过来的二进制，反序列化成对象
            //Person p;
            //using (FileStream fsread = new FileStream(@"二进制序列化后的文件.txt", FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    p = (Person)bf.Deserialize(fsread);
            //}
            //Console.WriteLine(p.Name);
            //Console.WriteLine(p.Age);
            //Console.WriteLine(p.Gender);

            //xml序列化
            using (FileStream fs = new FileStream(@"xml序列化后的文件.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Person));
                xs.Serialize(fs,new Person() { Name = "张三", Gender = '男', Age = 12 });
            }

            //json序列化
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jssStr=jss.Serialize(new Person() { Name = "张三", Gender = '男', Age = 12 });



            Console.ReadKey();
        }
    }
    [Serializable]
    public class Person
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        char _gender;

        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
