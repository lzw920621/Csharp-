using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace 利用反射实现ORM
{
    /*
    ExecuteReader——用于查询数据库。查询结果是返回MySqlDataReader对象，MySqlDataReader包含sql语句执行的结果，并提供一个方法从结果中阅读一行。
    这种方式有个很大的缺陷:返回的MySqlDataReader对象在读数据时必须保持数据库在连接状态

　　ExecuteNonQuery——用于插入、更新和删除数据。

　　ExecuteScalar——用于查询数据时，返回查询结果集中第一行第一列的值，即只返回一个值。
    */
    class MySqlHelper :IDisposable
    {
        string connectionString;
        MySqlConnection connection;

        #region 构造函数
        public MySqlHelper()//Server=localhost;Database=myormtestdatabase; User=root;Password=1234;
        {
            //从配置文件中获取连接字符串
            this.connectionString = ConfigurationManager.ConnectionStrings["mySqlCon"].ConnectionString;
            if(this.connectionString==null)
            {
                throw new Exception("AppSetting中没有配置连接字符串");
            }
            this.connection = new MySqlConnection(connectionString);//新建连接
        }
        public MySqlHelper(string connectString)
        {
            this.connectionString = connectString;
            this.connection = new MySqlConnection(connectionString);//新建连接
        }
        #endregion

        #region 数据库连接与关闭
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                if(connection!=null)
                {
                    connection.Close();
                }                
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand(插入 删除 更新)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters"></param>
        public int ExecuteNonQueryCommand(string sql, params MySqlParameter[] parameters)
        {
            try
            {
                OpenConnection();//打开连接
                MySqlCommand mysqlcom = new MySqlCommand(sql, connection);//sql命令
                mysqlcom.Parameters.AddRange(parameters);
                int count = mysqlcom.ExecuteNonQuery();
                return count;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();//关闭连接    
            }
            
            return 0;
        }

        /// <summary>
        /// 执行MySqlCommand(查找)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable ExecuteReaderCommand(string sql)
        {
            DataTable dataTable= new DataTable();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, connection);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(dataAdapter);
                
                dataAdapter.Fill(dataTable);//将查找到的结果填充到datatable中
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();//关闭连接
            }
            return dataTable;
        }
        #endregion



        public void Dispose()
        {
            CloseConnection();//关闭数据库连接
            connection.Dispose();
        }
    }
}
