using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform控件combobox绑定枚举类型
{
    enum 季节
    {
        春,
        夏,
        秋,
        冬
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = System.Enum.GetNames(typeof(季节));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 选择
            季节 season = 季节.春;
            comboBox1.SelectedIndex = comboBox1.FindString(season.ToString());

            // 获取
            季节 season2 = (季节)Enum.Parse(typeof(季节), comboBox1.SelectedItem.ToString(), false);
        }
    }
}
