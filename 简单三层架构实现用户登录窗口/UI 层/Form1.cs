using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单三层架构实现用户登录窗口
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btn_Login.Enabled = false;
            string userName = tb_UserName.Text.Trim();  
            string password = tb_Password.Text;

            BLL_层.LoginManager mgr = new BLL_层.LoginManager();//业务层

            bool isLoginSuccess = await Task.Run(() => { return mgr.UserLogin(userName, password); });

            
            if (isLoginSuccess==true)   //
            {
                MessageBox.Show("登陆成功");
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
            btn_Login.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
