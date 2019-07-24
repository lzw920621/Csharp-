using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文件加密和解密
{
    public partial class Form1 : Form
    {
        SimpleEncrypt simpleEncrypt ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simpleEncrypt = new SimpleEncrypt();
            simpleEncrypt.SendMessage += MessageCallback;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();//获得路径
            simpleEncrypt.EncryptOrDecryptFile(path);
        }

        void MessageCallback(string msg)
        {
            MessageBox.Show(msg);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))//表示接收到的数据是文件类型
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
