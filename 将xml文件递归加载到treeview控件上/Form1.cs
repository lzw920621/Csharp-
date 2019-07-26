using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace 将xml文件递归加载到treeview控件上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Select_XML_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "xml文件(*.xml)|*.xml";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                XDocument document = XDocument.Load(openFileDialog1.FileName);//加载xml文件
                XElement root = document.Root;//获取根节点

                //treeView1.Nodes.Add(root.Name.ToString());

                LoadXmlFileToTreeView(root,treeView1.Nodes);
            }
        }

        void LoadXmlFileToTreeView(XElement root,TreeNodeCollection treeNodeCollection)
        {
            TreeNode treeNode;
            if (root.Elements().Count()==0)//判断该节点是否是叶子节点
            {
                treeNode = treeNodeCollection.Add(root.Name.ToString()+":"+root.Value);
            }
            else
            {
                treeNode = treeNodeCollection.Add(root.Name.ToString()+" "+root.FirstAttribute.Value);
            }
            
            foreach (var xElement in root.Elements())
            {
                LoadXmlFileToTreeView(xElement, treeNode.Nodes);
            } 
        }
    }
}
