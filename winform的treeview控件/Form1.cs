using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace winform的treeview控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();//清除所有节点
        }

        private void button6_Click(object sender, EventArgs e)//清除所有节点
        {
            treeView1.Nodes.Clear();//清除所有节点
        }

        private void button1_Click(object sender, EventArgs e)//添加根节点
        {
            string text = textBox1.Text;
            if(!string.IsNullOrEmpty(text))
            {
                treeView1.Nodes.Add(text);
            }
        }

        private void button2_Click(object sender, EventArgs e)//添加子节点
        {
            if(treeView1.SelectedNode!=null)
            {
                if(!string.IsNullOrEmpty(textBox1.Text))
                {
                    treeView1.SelectedNode.Nodes.Add(textBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//删除节点
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Remove();
            }
        }

        private void button4_Click(object sender, EventArgs e)//展开节点
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Expand();
            }
        }

        private void button5_Click(object sender, EventArgs e)//折叠子节点
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Collapse();
            }
        }


        //将目录与文件加载到TreeView上
        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.先根据路径获取所有的子文件和子文件夹
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            //2.把所有的子文件与子目录加到TreeView上。
            foreach (string item in files)
            {
                //把每一个子文件加到TreeView上
                treeNodeCollection.Add(Path.GetFileName(item));
            }
            //文件夹
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));

                //由于目录，可能下面还存在子目录，所以这时要对每个目录再次进行获取子目录与子文件的操作
                //这里进行了递归
                LoadFilesAndDirectoriesToTree(item, node.Nodes);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadFilesAndDirectoriesToTree(@"D:\Program Files (x86)", treeView1.Nodes);
        }
    }
}
