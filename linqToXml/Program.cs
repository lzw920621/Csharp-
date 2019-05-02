using System;
using System.Xml.Linq;
using System.IO;

namespace linqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument employees1 = 
                new XDocument
                (
                    new XElement
                                ("Employees", 
                                    new XElement("Name", "Bob Smith"), 
                                    new XElement("Name", "Sally Jones")
                                )
                );

            string path= Environment.CurrentDirectory + @"\XmlFile";
            if(Directory.Exists(path)==false)
            {
                Directory.CreateDirectory(path);
            }
            employees1.Save(path + @"\EmployeesFile.xml");

            XDocument employees2 = XDocument.Load(path + @"\EmployeesFile.xml");

         

            Console.WriteLine(employees1);
            Console.WriteLine(employees2);
            Console.ReadKey();
        }
    }
}
