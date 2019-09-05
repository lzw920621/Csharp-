using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform如何让TextBox只接受数字输入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NumberOnlyTextBox numberOnlyTextBox = new NumberOnlyTextBox();
            numberOnlyTextBox.Location = new System.Drawing.Point(298, 95);
            numberOnlyTextBox.Name = "textBox1";
            numberOnlyTextBox.Size = new System.Drawing.Size(187, 25);
            numberOnlyTextBox.TabIndex = 0;
            numberOnlyTextBox.Update();
            numberOnlyTextBox.Text = "123";
            this.Controls.Add(numberOnlyTextBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
