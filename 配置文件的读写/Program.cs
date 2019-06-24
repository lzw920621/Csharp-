using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace 配置文件的读写
{
    class Program
    {
        static void Main(string[] args)
        {
            #region App.config
            //读配置文件

            //string userName = ConfigurationSettings.AppSettings["name"] as string;
            //string password = ConfigurationSettings.AppSettings["password"] as string;
            string name = ConfigurationManager.AppSettings["name"] as string;
            string password = ConfigurationManager.AppSettings["password"] as string;

            //写配置文件

            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //增加元素
            config.AppSettings.Settings.Add("url", "http://www.myhack58.com");
            config.AppSettings.Settings.Add("name", "李四");
            config.AppSettings.Settings.Add("password", "1234");
            //写入元素值
            config.AppSettings.Settings["url"].Value = "http://www.myhack58.com";//写入元素
            config.AppSettings.Settings["name"].Value = "李四";
            config.AppSettings.Settings["password"].Value = "1234";

            ////根据Key读取元素的Value
            //string newName = config.AppSettings.Settings["name"].Value;

            ////删除元素
            //config.AppSettings.Settings.Remove("name");
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");
            #endregion

            #region Settings.settings //这种方式本质也是通过读写appconfig文件来实现的
            //读
            string name1 = Settings1.Default.name;
            string password1 = Settings1.Default.password;

            //写
            Settings1.Default.name = "李四";
            Settings1.Default.password = "98213";
            #endregion
        }
    }
}
