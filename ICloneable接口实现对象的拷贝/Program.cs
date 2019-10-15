using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ICloneable接口实现对象的拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "test0001", Age = 20, Job = new Job() { JobName = "Coder", ID = 100022 } };

            string Str = "";

            Str = string.Format("修改前：p.Name={0},p.Age={1},p.Job.JobName={2}", p.Name, p.Age, p.Job.JobName);


            Person p1 = p.ShallowClone();
            Person p2 = p.DeepClone();

            bool isSame1 = p1.Job.Equals(p.Job);//true
            bool isSame2 = p2.Job.Equals(p.Job);//false
        }
    }

    [Serializable]
    public class Job
    {
        public int id;
        public string JobName { get; set; }
        public override string ToString()
        {
            return this.JobName;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }

    [Serializable]
    public class Person : ICloneable
    {
        public int Age { get; set; }  //值类型字段  
        public string Name { get; set; }  //字符串  
        public Job Job { get; set; }  //引用类型字段  

        //深拷贝  
        public Person DeepClone()
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as Person;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();  //浅拷贝
        }

        //浅拷贝  
        public Person ShallowClone()
        {
            return this.Clone() as Person;
        }
    }
}
