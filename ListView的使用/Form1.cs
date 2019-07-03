using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView的使用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitListView();
            
        }


        void InitListView()
        {
            listView1.GridLines = true;  //显示网格线
            listView1.FullRowSelect = true;  //显示全行
            listView1.MultiSelect = false;  //设置只能单选
            listView1.View = View.Details;  //设置显示模式为详细

            listView1.Columns.Add("姓名", 100);
            listView1.Columns.Add("性别", 100);
            listView1.Columns.Add("年龄", 100);
            listView1.Columns.Add("电话", 100);
        }

   
    }
}
