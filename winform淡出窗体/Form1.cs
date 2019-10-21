using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform淡出窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if(this.Opacity<0.2)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled==false)
            {
                timer1.Start();
            }                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
        }
    }
}
