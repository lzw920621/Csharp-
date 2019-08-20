using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textbox数据绑定
{
    public partial class Form1 : Form
    {
        MyData _myData;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _myData = new MyData();
            //数据源发生变化会影响客户端,客户端发生变化也会影响数据源 (双向绑定)
            textBox1.DataBindings.Add("Text", _myData, "TheValue", false, DataSourceUpdateMode.OnPropertyChanged);//双向绑定:_myData改变会影响textbox1.text, textbox1.text改变也会影响_myData
            //数据源发生变化会影响客户端,客户端发生变化不会影响数据源 (单向绑定)
            textBox2.DataBindings.Add("Text", _myData, "TheValue", false, DataSourceUpdateMode.Never);//单向绑定:_myData改变会影响textbox1.text, textbox1.text改变不会影响_myData

        }
    }
}
