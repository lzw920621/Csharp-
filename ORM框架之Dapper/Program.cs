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
            using(var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                //string sql = "INSERT INTO persons(ID,Name) Values (1,'张三');";
                //int affectedRows = db.Execute(sql);

                string query = "select * from persons";
                List<Person> lstContact = db.Query<Person>(query).ToList<Person>();

                foreach (var item in lstContact)
                {
                    Console.WriteLine(item.ID + item.Name + " " + item.Age + "\n");
                }


            }
            
            
            Console.ReadKey();
        }
    }
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
