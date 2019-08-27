using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform控件焦点的变换
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string name = textBox.Name;
            if(e.KeyCode==Keys.Enter)
            {
                switch(name)
                {
                    case "textBox1":textBox2.Select();break;
                    case "textBox2":textBox3.Select();break;
                    case "textBox3":textBox4.Select();break;
                    case "textBox4":textBox5.Select();break;
                    default:textBox1.Select();break;
                }
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.Beige;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = SystemColors.Window;
        }
    }
}
