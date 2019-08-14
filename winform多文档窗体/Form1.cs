using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform多文档窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void 加载子窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm1 child1 = ChildForm1.SingletonForm;
            ChildForm2 child2 = ChildForm2.SingletonForm;
            ChildForm3 child3 = ChildForm3.SingletonForm;
            child1.MdiParent = this;
            child2.MdiParent = this;
            child3.MdiParent = this;
            child1.Show();
            child2.Show();
            child3.Show();
        }



        private void 水平平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }



        private void 垂直平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }



        private void 层叠排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
    }
}
