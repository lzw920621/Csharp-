using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文件锁的实现
{
    //大致功能是，启动 文件锁 程序后，将想要上锁的文件或文件夹拖入到加密区，实现对 文件或文件夹 的加密，或者点击浏览文件夹 选择自己想要加密的文件或文件夹。
    
    //对文件或文件夹上锁的原理：
    //其实是利用了windows自身的安全类标识符，对一个文件夹添加后缀  .{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}后，
    //会发现该文件夹被windows识别为安全类标识文件夹，然后便自动变成了一把锁，用鼠标点怎么也点不开，鼠标重命名也不行。
    //但是这种方法只能对文件夹上锁，对文件上锁却没有用，所以要做到对文件上锁，先新建一个文件夹，再把文件移动到该文件夹内，然后对该文件夹上锁

    public partial class Form1 : Form
    {
        IEncrypter encrypter;
        IDecrypter decrypter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            encrypter = new MyEncrypter();
            decrypter = new MyDecrypter();
        }

        private void Panel1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();       //获得路径
            encrypter.SingleEncrypt(path);
        }

        private void Panel1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                encrypter.SingleEncrypt(path);
            }
        }

        private void Button2_Click(object sender, EventArgs e)//全局加密
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                encrypter.MultiEncrypt(path);
            }
        }

        private void Button3_Click(object sender, EventArgs e)//全局解密
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                decrypter.MultiDecrypt(path);
            }
        }
    }
}
