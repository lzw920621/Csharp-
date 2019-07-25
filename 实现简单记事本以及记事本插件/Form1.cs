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
using System.Reflection;
using MyNotepadInterface;

namespace 实现简单记事本以及记事本插件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件(*.txt) | *.txt | 所有文件(*.*) | *.*";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                File.WriteAllText(path, textBox1.Text.Trim());
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt) | *.txt | 所有文件(*.*) | *.*";
            if (this.openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                textBox1.Text = File.ReadAllText(path).Trim();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载插件的dll (addons文件下的)
            //1.获取路径
            string path= Application.StartupPath+@"\addons";
            //2.搜索addons下的所有dll文件
            string[] dllsPath = Directory.GetFiles(path, "*.dll");
            //3.循环加载每个dll文件
            foreach (var dll in dllsPath)
            {
                Assembly assembly= Assembly.LoadFile(dll);
                //获取dll中所有的public类型
                Type[] types = assembly.GetExportedTypes();
                Type typeIEditor = typeof(IEditor);
                //循环判断types中的所有类型,只要实现了IEditor接口的类型
                for (int i = 0; i < types.Length; i++)
                {
                    if(typeIEditor.IsAssignableFrom(types[i]) && !types[i].IsAbstract)//验证当前类型实现了IEditor接口并且可被实例化
                    {
                        //创建该类型的对象
                        IEditor editor = (IEditor)Activator.CreateInstance(types[i]);
                        string editorAddonName = editor.Name;//获取editor插件名称
                        //向菜单栏中 编辑 选项中动态添加editorAddonName
                        ToolStripItem toolStripMenuItem = 编辑ToolStripMenuItem.DropDownItems.Add(editorAddonName);
                        toolStripMenuItem.Click += new EventHandler(toolItem_Click);
                        toolStripMenuItem.Tag = editor;
                    }
                }
            }
        }

        private void toolItem_Click(object sender, EventArgs e)
        {
            //在这里运行插件
            ToolStripItem tsp = sender as ToolStripItem;
            IEditor ieditor = (IEditor)tsp.Tag;
            if (ieditor != null)
            {
                ieditor.Run(this.textBox1);
            }
        }
    }
}
