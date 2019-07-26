using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI绘制移动图形
{
    public partial class Form1 : Form
    {
        private Rectangle rect = new Rectangle(0, 0, 100, 100);
        private Point[] ps = new Point[3];
        private float rotate = 0;
        public Form1()
        {
            InitializeComponent();
            SetRect(0, 0);
        }
        

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawTriangle(e.Graphics);
            //e.Graphics.DrawRectangle(Pens.Blue, this.rect);            
        }

        private void DrawTriangle(Graphics g)
        {
            g.TranslateTransform(rect.X, 0);
            //g.RotateTransform(rotate);
            g.FillPolygon(new SolidBrush(Color.Red), ps);
        }
        private void SetRect(int x, int y)
        {
            rect.X = rect.X + x;
            rect.Y = rect.Y + y;
            rect.Width = 100;
            rect.Height = 100;
            ps[0].X = rect.X;
            ps[0].Y = rect.Bottom;
            ps[1].X = rect.X + rect.Width / 2;
            ps[1].Y = rect.Top;
            ps[2].X = rect.Right;
            ps[2].Y = rect.Bottom;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rotate += 5f;
            SetRect(10, 10);
            this.Invalidate();
        }
    }
}
