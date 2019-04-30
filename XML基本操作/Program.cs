using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML基本操作
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //初始化一个xml实例
            XmlDocument xmlFile = new XmlDocument();

            string path = Environment.CurrentDirectory + @"\XmlFiles\BookStore.xml";
            //导入指定xml文件
            xmlFile.Load(path);//根据路径导入xml文件
            //获取xml文档声明
            var firstNode = xmlFile.FirstChild;
            
            string str= firstNode.OuterXml;
            //获取xml文件的根节点
            var rootNode = xmlFile.DocumentElement;
            //根节点名称
            string rootNodeName = rootNode.Name;
            //根节点属性
            var rootNodeAttribute = rootNode.Attributes;
            Dictionary<string, string> attributeDic = new Dictionary<string, string>();
            for (int i = 0; i < rootNodeAttribute.Count; i++)
            {
                attributeDic.Add(rootNodeAttribute[i].Name, rootNodeAttribute[i].Value);                
            }
            //获取某个节点的所有子节点
            var nodeList = rootNode.ChildNodes;
            List<string> nameList = new List<string>();
            for (int i = 0; i < nodeList.Count; i++)
            {
                nameList.Add(nodeList[i].Name);
            }



            //指定一个节点
            XmlNode node1 = xmlFile.SelectSingleNode("/bookstore/book");

                      
            //获取同名同级节点集合
            XmlNodeList nodelist = xmlFile.SelectNodes("/bookstore/book");

            //生成一个新节点
            XmlElement node = xmlFile.CreateElement("book");
            

            //将节点加到指定节点下，作为其子节点
            rootNode.AppendChild(node);            

            //为指定节点的新建属性并赋值
            node.SetAttribute("category", "文学");

            

            //获取指定节点的指定属性值
            string value = node.Attributes["category"].Value;

            //获取指定节点中的文本
            string content = node.InnerText;

            //保存XML文件
            xmlFile.Save(path);
          
            Console.ReadKey();
            */



            XmlDocument xmldoc = new XmlDocument();//声明xml文件         
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>            
            XmlDeclaration xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);
            //加入一个根元素
            XmlElement xmlelem = xmldoc.CreateElement("", "Employees", "");
            xmldoc.AppendChild(xmlelem);

            for (int i = 1; i < 3; i++)
            {

                XmlNode root = xmldoc.SelectSingleNode("Employees");//查找<Employees>
                XmlElement xe1 = xmldoc.CreateElement("Node");//创建一个<Node>节点
                xe1.SetAttribute("genre", "李赞红");//设置该节点genre属性
                xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性

                XmlElement xesub1 = xmldoc.CreateElement("title");
                xesub1.InnerText = "CS从入门到精通";//设置文本节点
                xe1.AppendChild(xesub1);//添加到<Node>节点中
                XmlElement xesub2 = xmldoc.CreateElement("author");
                xesub2.InnerText = "候捷";
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmldoc.CreateElement("price");
                xesub3.InnerText = "58.3";
                xe1.AppendChild(xesub3);

                root.AppendChild(xe1);//添加到<Employees>节点中
            }
            //保存创建好的XML文档
            xmldoc.Save(Environment.CurrentDirectory + @"\XmlFiles\xmlFile2");
        }
    }
}
