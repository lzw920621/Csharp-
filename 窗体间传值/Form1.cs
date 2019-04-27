using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体间传值
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateTextbox(textBox1.Text);
        }

        public event Action<string> updateTextbox;

        void UpdateTextBox(string str)
        {
            textBox1.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = Form2.SingletonForm;
            form2.updateTextbox += UpdateTextBox;

            this.updateTextbox += form2.UpdateTextBox;

            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> kvDictonary = new Dictionary<int, string>();
            kvDictonary.Add(0, "--请选择--");
            kvDictonary.Add(1, "一个月内");
            kvDictonary.Add(2, "两个月内");
            kvDictonary.Add(3, "三个月内");
            kvDictonary.Add(4, "四个月内");
            kvDictonary.Add(5, "五个月内");
            kvDictonary.Add(6, "六个月内");

            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;
            this.comboBox1.DataSource = bs;
            kvDictonary.Add(7, "七个月内");
            
            //this.comboBox1.DataSource = kvDictonary;//错误用法
        }
    }
}
