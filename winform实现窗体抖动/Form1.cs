using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform实现窗体抖动
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

        private void ShakeWindow()
        {
            Random ran = new Random();
            System.Drawing.Point point = this.Location;
            for (int i = 0; i < 30; i++)
            {
                this.Location = new System.Drawing.Point(point.X + ran.Next(8), point.Y + ran.Next(8));
                System.Threading.Thread.Sleep(15);
                this.Location = point;
                System.Threading.Thread.Sleep(15);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShakeWindow();
        }
    }
}
