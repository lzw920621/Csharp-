using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI绘制验证码
{
    public partial class Form1 : Form
    {
        string str = null;

        public Form1()
        {
            InitializeComponent();
        }

        //加载：
        private void Form1_Load(object sender, EventArgs e)
        {

            button1.Click += button1_Click;
            pic.Click += pic_Click;

            pic_Click(null, null);
        }

        
        private void pic_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            //产生5个随机字符串
            //List<string> list = new List<string>(new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" });
            str = null;
            for (int i = 0; i < 5; i++)
            {
                int j = random.Next(64, 90);
                //str = str + list[random.Next(0, list.Count)];
                str = str + (char)j;
            }
            //创建图片
            Bitmap bmp = new Bitmap(120, 30);
            //创建GDI对象
            Graphics g = Graphics.FromImage(bmp);
            //循环画字符串
            for (int i = 0; i < str.Length; i++)
            {
                Point p = new Point(i * 20, 0);
                //随机字体
                string[] fonts = { "宋体", "黑体", "微软雅黑", "隶属", "仿宋", };
                //随机颜色
                Color[] colors = { Color.Red, Color.Aquamarine, Color.Blue, Color.Yellow, Color.YellowGreen };
                //画字符串
                g.DrawString(str[i].ToString(), new Font(fonts[random.Next(0, fonts.Length)], 20, FontStyle.Bold), new SolidBrush(colors[random.Next(0, colors.Length)]), p);
            }

            //画线
            for (int i = 0; i < 20; i++)
            {
                Point p1 = new Point(random.Next(0, bmp.Width), random.Next(0, bmp.Height));
                Point p2 = new Point(random.Next(0, bmp.Width), random.Next(0, bmp.Height));
                g.DrawLine(new Pen(Color.Green), p1, p2);
            }
            //画像素点
            for (int i = 0; i < 300; i++)
            {
                Point p = new Point(random.Next(0, bmp.Width), random.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }

            //将图片镶嵌到PictureBox
            this.pic.Image = bmp;
            
        }
        

        //登陆
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().ToUpper().Equals(str.ToUpper()))
            {
                MessageBox.Show("登陆成功！");
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }
        }
    }
}
