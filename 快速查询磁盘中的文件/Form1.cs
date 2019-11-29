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

namespace 快速查询磁盘中的文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Search_Click(object sender, EventArgs e)
        {            
            bool IsAdministrator = MFTScanner.IsAdministrator();
            if(IsAdministrator==false)
            {
                MessageBox.Show("当前不是管理员身份!!!");
                return;
            }
            string dir = textBox_Dir.Text;
            if(!Directory.Exists(dir))
            {
                MessageBox.Show("请输入文件夹路径");
                return;
            }

            MFTScanner mFTScanner = new MFTScanner();
            //var files = mFTScanner.EnumerateFiles(@"I:\").ToArray();

            var files = mFTScanner.EnumerateFilesInForder(dir).ToArray();
            for (int i = 0; i < 100 && i<files.Length; i++)//只显示前100个文件名
            {
                listBox_File_List.Items.Add(files[i]);
            }
            textBox_Count.Text = files.Length+"";
        }
    }
}
