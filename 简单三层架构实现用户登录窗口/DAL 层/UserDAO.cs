using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace 简单三层架构实现用户登录窗口.DAL_层
{
    class UserDAO
    {
        public Model.UserInfo SelectUser(string userName, string Password)   //根据 ui 选择返回一个user
        {
            using (SqlConnection conn = new SqlConnection(DatabaseUtility.ConnString))
            {
                //创建一个命令对象，并添加命令
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT ID,UserName,Password FROM USERS WHERE UserName=@UserName AND Password=@Password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", userName));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));

                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                Model.UserInfo user = null;    //用于保存读取的数据

                while (reader.Read())      //开始读取数据
                {
                    user = new Model.UserInfo();

                    user.ID = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Password = reader.GetString(2);                    
                }
                return user;
            }

        }
    }
}
