using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 截屏操作
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


        /// <summary>
        /// 截全屏并保存成图片
        /// </summary>
        void getScreen()
        {
            Image myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);//截取整个屏幕
            //Image myImage = new Bitmap(Screen.PrimaryScreen.WorkingArea.Right, Screen.PrimaryScreen.WorkingArea.Bottom);//截取整个工作区

            Graphics g = Graphics.FromImage(myImage);

            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            g.ReleaseHdc(g.GetHdc());

            myImage.Save(@"C:\Users\lzw92\Desktop\新建文件夹 (6)\b.jpg");
        }

        private void button_ScreenShoot_Click(object sender, EventArgs e)
        {
            getScreen();
        }
       
    }

    
}
