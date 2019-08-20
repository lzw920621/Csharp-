using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView数据绑定
{
    public partial class Form1 : Form
    {
        private BindingList<Customer> customers = new BindingList<Customer>();

        public Form1()
        {
            InitializeComponent();
            
        }
        Dictionary<string, string> dic = new Dictionary<string, string>();
        private void Form1_Load(object sender, EventArgs e)
        {           
            customers.Add(new Customer() { CustomerName = "张三", PhoneNumber = "010-5263" });
            customers.Add(new Customer() { CustomerName = "李四", PhoneNumber = "010-8823" });
            dataGridView1.DataSource = customers;


            //绑定字典
            //dic.Add("张三", "1234");
            //dic.Add("李四", "1456");

            //dataGridView1.DataSource = dic.ToArray();

            
        }

        private void btn_Add_Customer_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer() { CustomerName = "新顾客", PhoneNumber = "1234567" });

            //dic.Add("王五", "1789");
        }

        private void btn_Delete_Customer_Click(object sender, EventArgs e)
        {
            if(customers.Count>0)
            {
                customers.Remove(customers.Last());//移除最后一位顾客
            }
            
        }
    }
}
