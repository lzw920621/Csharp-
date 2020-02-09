using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI动态绘制直线和曲线
{
    public partial class Form1 : Form
    {
        Point point1;
        Point point2;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            point1 = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            point2 = new Point(e.X, e.Y);
            if (radioButton1.Checked == true)
            {
                Pen p = new Pen(Color.Red, 4);
                Graphics g= this.panel1.CreateGraphics();
                g.DrawLine(p, point1,point2);  //绘制直线
            }           
        }

        bool startFlag = true;
        Point prePoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {         
            if (radioButton2.Checked == true)
            {
                if (startFlag == true)
                {
                    prePoint = new Point(e.X, e.Y);
                    startFlag = false;
                }
                Pen p = new Pen(Color.Red, 4);
                Graphics g = this.panel1.CreateGraphics();

                Point curPoint = new Point(e.X, e.Y);
                g.DrawLine(p, prePoint, curPoint);
                prePoint = curPoint;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            startFlag = true;
        }
    }
}
