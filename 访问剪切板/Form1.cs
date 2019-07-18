using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 访问剪切板
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

        public void SetClipboardText(string str)
        {
            //方法1  (很可能有问题)
            Clipboard.SetText(str);
            //方法2  (很可能有问题)
            Clipboard.SetData(DataFormats.Text, str);
            //方法3  (大多数时候没问题)
            Clipboard.SetDataObject(str);
        }

        public string GetClipboardText()
        {
            string str;

            //方法1 (很可能有问题)
            str = (string)Clipboard.GetData(DataFormats.Text);

            //方法2 (大多数时候没问题)
            str = Clipboard.GetText();

            return str;
        }
    }
}
