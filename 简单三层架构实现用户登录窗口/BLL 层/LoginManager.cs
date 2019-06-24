using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单三层架构实现用户登录窗口.BLL_层
{
    class LoginManager
    {
        public bool UserLogin(string userName, string Password)
        {
            DAL_层.UserDAO uDAO = new DAL_层.UserDAO();  //数据访问层
            Model.UserInfo user = uDAO.SelectUser(userName, Password);  //通过ui中填写的内容 返回来相应的数据

            if (user != null)
            {                
                return true;
            }
            else       //如果数据库中没有该用户名，则登陆失败
            {
                return false;
            }
        }
    }
}
