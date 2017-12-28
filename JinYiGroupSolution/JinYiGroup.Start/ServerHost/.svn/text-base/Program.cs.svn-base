using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string err = "";
            if (Neusoft.FrameWork.Management.Connection.GetSetting(out err) == -1)
            {
                System.Console.WriteLine(err);
            }
            try
            {
                RemotingConfiguration.Configure("ServerHost.config", false);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine("不要关闭该程序.....");
            System.Windows.Forms.Application.Run();
        }
    }
}
