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
    public partial class Form2 : Form
    {
        private static Form2 form2;

        private static object lockObject = new object();

        public static Form2 SingletonForm
        {
            get
            {
                if(form2==null || form2.IsDisposed == true)
                {
                    lock(lockObject)
                    {
                        if (form2 == null || form2.IsDisposed == true)
                        {
                            return form2 = new Form2();
                        }
                    }                    
                }
                return form2;
            }
        }

        private Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateTextbox(textBox1.Text);
        }

        public event Action<string> updateTextbox;

        public void UpdateTextBox(string str)
        {
            textBox1.Text = str;
        }
    }
}
