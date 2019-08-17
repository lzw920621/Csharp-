using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform实现简单的窗体侧边栏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool show = true;
        private void btn_HideAndShow_Click(object sender, EventArgs e)
        {
            show =!show;
            if(show)
            {
                btn_HideAndShow.Text = "<";
                panel1.Show();
            }
            else
            {
                btn_HideAndShow.Text = ">";
                panel1.Hide();
            }            
        }
    }
}
