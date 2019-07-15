using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI绘图
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics myGraphics = e.Graphics;
            Pen myPen = new Pen(Color.Blue, 2);
            //绘制直线
            myGraphics.DrawLine(myPen, 0, 0, 100, 100);

            //绘制矩形
            myGraphics.DrawRectangle(myPen, new Rectangle(10, 10, 50, 70));

            //绘制折线或曲线
            myGraphics.DrawCurve(myPen, new Point[] { new Point(10, 15), new Point(17, 25), new Point(24, 30),new Point(50,60) });

            //绘制椭圆形
            myGraphics.DrawEllipse(myPen, new Rectangle(150, 150, 50, 80));

            //笔刷
            Brush myBrush = new SolidBrush(Color.Purple);
            //绘制带填充色的矩形
            myGraphics.FillRectangle(myBrush, new Rectangle(100, 100, 50, 70));
            

        }
    }
}
