using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Reflection;
using System.Data;

namespace 利用反射实现ORM
{
    class SbORM
    {        
        //插入
        public static bool Insert<T>(T t)
        {
            Type type = typeof(T);
            string tableName = type.Name;//类型名称(同时也是其对应的表的名称)
            PropertyInfo[] propertyInfos = type.GetProperties();//获取该类所有的属性
            string[] propertyNames = new string[propertyInfos.Length];//属性名称的数组(同时也是表中相应的字段名称)
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                propertyNames[i] = propertyInfos[i].Name;//获取属性名称
            }

            StringBuilder sqlStr = new StringBuilder();//sql语句
            sqlStr.Append("insert into " + tableName + "(");
            for (int i = 0; i < propertyNames.Length; i++)
            {
                object value = propertyInfos[i].GetValue(t, null);

                if (value != null)//如果属性的值为null 则不对该字段进行插入操作
                {
                    if (i != propertyNames.Length - 1)
                    {
                        sqlStr.Append(" " + propertyNames[i] + ",");
                    }
                    else
                    {
                        sqlStr.Append(" " + propertyNames[i] + "");
                    }
                }                    
            }
            sqlStr.Append(") values(");

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                object value = propertyInfos[i].GetValue(t, null);

                if (value != null)
                {
                    if (i != propertyInfos.Length - 1)
                    {
                        if (propertyInfos[i].PropertyType == typeof(string) || propertyInfos[i].PropertyType == typeof(DateTime))
                        {
                            sqlStr.Append("'" + value + "',");
                        }
                        else
                        {
                            sqlStr.Append("" + value + ",");
                        }
                    }
                    else
                    {
                        if (propertyInfos[i].PropertyType == typeof(string) || propertyInfos[i].PropertyType == typeof(DateTime))
                        {
                            sqlStr.Append("'" + value + "')");
                        }
                        else
                        {
                            sqlStr.Append("" + value + ")");
                        }
                    }
                }
            }

            MySqlHelper sqlHelper = new MySqlHelper();
            string sql = sqlStr.ToString();
            int count=sqlHelper.ExecuteNonQueryCommand(sql);//受影响的行数
            return count == 1 ? true : false;
        }

        //查找
        public static object Search<T>(int id) where T : new()
        {
            Type type = typeof(T);
            string tableName = type.Name;

            string sql = "select * from " + tableName + " where id=" + id;
            MySqlHelper sqlHelper = new MySqlHelper();
            DataTable dt = sqlHelper.ExecuteReaderCommand(sql);
            if(dt.Rows.Count<1)
            {
                return null;
            }
            else
            {                
                PropertyInfo[] propertyInfos = type.GetProperties();//获取该类所有的属性
                string[] propertyNames = new string[propertyInfos.Length];//属性名称的数组(同时也是表中相应的字段名称)
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    propertyNames[i] = propertyInfos[i].Name;//获取属性名称
                }
                T obj = new T();
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    //获取对应属性的值
                    object value = dt.Rows[0][propertyNames[i]];
                    propertyInfos[i].SetValue(obj, value);
                }

                return obj;
            }            
        }

        //更新
        public static bool Update<T>(T t)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();//获取该类所有的属性
            string tableName = type.Name;//类型名称(同时也是其对应的表的名称)
            string sql = "update " + tableName + " set ";
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                string name = propertyInfos[i].Name;
                
            }
            
            MySqlHelper sqlHelper = new MySqlHelper();
            int count = sqlHelper.ExecuteNonQueryCommand(sql);
            return count == 1 ? true : false;
        }

        //删除
        public static bool Delete<T>(int id)
        {
            Type type = typeof(T);
            string tableName = type.Name;//类型名称(同时也是其对应的表的名称)
            string sql = "delete from " + tableName + " where id=" + id;
            MySqlHelper sqlHelper = new MySqlHelper();
            int count = sqlHelper.ExecuteNonQueryCommand(sql);
            return count == 1 ? true : false;
        }
    }
}
