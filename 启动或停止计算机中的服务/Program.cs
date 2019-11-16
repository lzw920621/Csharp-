using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace 启动或停止计算机中的服务
{
    //第一、要添加一个引用System.ServiceProcess
    //第二、要在程序中使用命名空间ServiceProcess
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        void StartService(string serviceName)//启动服务
        {
            ServiceController serviceController1 = new ServiceController();
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = ".";
            if (serviceController1.Status != ServiceControllerStatus.Running)
            {
                serviceController1.Start();
            }              
        }

        void StopService(string serviceName)//停止服务
        {
            ServiceController serviceController1 = new ServiceController();
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = ".";
            if (serviceController1.Status != ServiceControllerStatus.Stopped)
            {
                serviceController1.Stop();
            }
        }
    }
}
