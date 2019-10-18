using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 键盘钩子
{
    public partial class Form1 : Form
    {
        private globalKeyboardHook gkh = new globalKeyboardHook();

        private string keyString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(this.gkh_KeyDown);
        }

        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            keyString = keyString + e.KeyCode.ToString();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = keyString;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gkh.unhook();
        }
    }
}
