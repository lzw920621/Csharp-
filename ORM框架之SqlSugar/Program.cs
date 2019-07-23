using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using Newtonsoft.Json;
using Newtonsoft;

namespace ORM框架之SqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var db = GetInstance())
            {
                //根据实体类创建数据表
                //db.CodeFirst.SetStringDefaultLength(200/*设置varchar默认长度为200*/).InitTables(typeof(Student));//执行完数据库就有这个表了

                /*插入*/
                var data1 = new Student() { Name = "jack",SchoolId=1 };
                db.Insertable(data1).ExecuteCommand();

                /*插入*/
                var data2 = new Student() { Name = "Tony" ,SchoolId=1};
                db.Insertable(data2).ExecuteCommand();

                /*插入*/
                var data = new Student() { Name = "Tom" ,SchoolId=2};
                db.Insertable(data).ExecuteCommand();

                /*插入*/
                var data3 = new Student() { Name = "Merry" ,SchoolId=3};
                db.Insertable(data3).ExecuteCommand();

                var list = db.Queryable<Student>().ToList();//查询所有
                var getById = db.Queryable<Student>().InSingle(1);//根据主键查询
                var getByWhere = db.Queryable<Student>().Where(it => it.Id == 1).ToList();//根据条件查询

                
                /*更新*/
                var data4 = new Student() { Id = 1, Name = "jack" };
                db.Updateable(data4).ExecuteCommand();

                /*删除*/
                //db.Deleteable<Student>(1).ExecuteCommand();
            }

        }

        //public List<Student> GetStudentList()
        //{
        //    var db = GetInstance();
        //    var list = db.Queryable<Student>().ToList();//Search
        //    return list;
        //}

        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        private static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=.;uid=sa;pwd=1234;database=BasicOpt",//连接字符串
                DbType = DbType.SqlServer,//数据库类型
                IsAutoCloseConnection = true,//自动关闭数据库连接
                InitKeyType = InitKeyType.Attribute //InitKeyType.Attribute:根据特性来获取主键  InitKeyType.SystemTable:从数据库表中读取主键
            });
            //Print sql 输出sql语句
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }



    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//特性 设定主键 标识列
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        [SugarColumn(ColumnName = "StudentName")]//It's different from the name in the database.
        public string Name { get; set; }
    }
}
