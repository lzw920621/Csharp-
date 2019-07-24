using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;//xml序列化所需的命名空间
using System.IO;

namespace 序列化的一个简单应用
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        List<string> titleList = new List<string>();//标题
        List<string> contextList = new List<string>();//正文

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string title = tb_Title.Text;
            if(titleList.Contains(title))
            {
                int index = titleList.IndexOf(title);
                contextList[index] = tb_Context.Text;
            }
            else
            {
                titleList.Add(tb_Title.Text);
                contextList.Add(tb_Context.Text);

                listBox_TitleList.Items.Add(tb_Title.Text);
            }
            using (FileStream fs = new FileStream(@"日记标题.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                xs.Serialize(fs,titleList);
            }

            using (FileStream fs = new FileStream(@"日记正文.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                xs.Serialize(fs, contextList);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            if(File.Exists(@"日记标题.xml") && File.Exists(@"日记正文.xml"))
            {
                using (FileStream fs = new FileStream(@"日记标题.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                    titleList = xs.Deserialize(fs) as List<string>;
                }
                using (FileStream fs = new FileStream(@"日记正文.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                    contextList = xs.Deserialize(fs) as List<string>;
                }
                foreach (var item in titleList)
                {
                    listBox_TitleList.Items.Add(item);
                }
            }
        }

        private void listBox_TitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = listBox_TitleList.SelectedItem as string;
            tb_Title.Text = item;
            int index = listBox_TitleList.SelectedIndex;
            tb_Context.Text = contextList[index];
        }
    }
}
