using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;


namespace ORM框架之Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert(new Person { ID = 2, Name = "李四", Age = 20 });
            //Insert(new Person { ID = 3, Name = "王五", Age = 21 });
            //Insert(new Person { ID = 4, Name = "赵六", Age = 22 });

            //Delete(new Person { ID = 2, Name = "李四", Age = 20 });

            List<Person> list = Query();
            Console.ReadKey();
        }

        #region 插入
        //插入一条数据
        public static int Insert(Person person)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("insert into persons(ID,Name,Age) values(@ID,@Name,@Age)", person);
            }
        }
        //批量插入
        public static int Insert(List<Person> persons)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("insert into persons(ID,Name,Age) values(@ID,@Name,@Age)", persons);
            }
        }
        #endregion

        #region 删除
        //删除一条数据
        public static int Delete(Person person)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("delete from persons where id=@ID", person);
            }
        }
        //批量删除
        public static int Delete(List<Person> persons)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("delete from persons where id=@ID", persons);
            }
        }
        #endregion

        //更新一条数据
        public static int Update(Person person)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("update persons set name=@Name,age=@Age where id=@ID", person);
            }
        }
        //批量更新
        public static int Update(List<Person> persons)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Execute("update persons set name=@Name,age=@Age where id=@ID", persons);
            }
        }


        public static List<Person> Query()
        {
            string connectStr = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectStr))
            {
                return connection.Query<Person>("select * from persons").ToList();
            }
        }
    }
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
