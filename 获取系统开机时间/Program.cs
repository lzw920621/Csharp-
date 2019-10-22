using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取系统开机时间
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = GetComputerStartTime();
        }

        private static DateTime GetComputerStartTime()
        {
            int result = Environment.TickCount & Int32.MaxValue;      //获取系统启动后运行的毫秒数
            TimeSpan m_WorkTimeTemp = new TimeSpan(Convert.ToInt64(Convert.ToInt64(result) * 10000));

            DateTime startTime = System.DateTime.Now.AddDays(m_WorkTimeTemp.Days);
            startTime = startTime.AddHours(-m_WorkTimeTemp.Hours);
            startTime = startTime.AddMinutes(-m_WorkTimeTemp.Minutes);
            startTime = startTime.AddSeconds(-m_WorkTimeTemp.Seconds);
            //MessageBox.Show(startTime.ToString());
            return startTime;    //返回转换后的时间
        }
    }
}
