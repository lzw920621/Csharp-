using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform的PropertyGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Person personA = new Person();
            
            propertyGrid1.SelectedObject = personA;//这个控件可以将对象的属性列出来
        }
    }

    public enum Gender
    {
        男,
        女
    }
    class Person
    {
        [ReadOnly(true)]//在编辑器中只读,代码中赋值不受影响
        [DisplayName("年龄")]//属性的显示名
        public int Age { get; set; } = 15;

        [ReadOnly(true)]
        [DisplayName("姓名")]
        public string Name { get; set; } = "tom";

        [Browsable(false)]//是否可见
        public Gender Sex { get; set; } = Gender.男;

        
    }
}
