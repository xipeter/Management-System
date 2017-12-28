using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace CacheServer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isDBConnect = true;

            #region 数据库连接 

            string strErr = "";
            if (Neusoft.FrameWork.Management.Connection.GetSetting(out strErr) == -1)
            {
                System.Console.WriteLine(strErr);

                isDBConnect = false;
            }

            System.Console.WriteLine("数据库连接成功！");

            System.Console.WriteLine("\n");

            
            #endregion

            #region Sql语句读取  

            if (Neusoft.FrameWork.Management.Connection.Sql == null)
            {
                try
                {

                    System.Collections.ArrayList al = Neusoft.FrameWork.Server.Function.Manager.GetSQL();
                    if (al == null)
                    {
                        System.Console.WriteLine(Neusoft.FrameWork.Server.Function.Manager.Err);
                        isDBConnect = false; ;
                    }
                    Neusoft.FrameWork.Management.Connection.Sql = new Neusoft.FrameWork.Management.Sql();
                    try
                    {
                        Neusoft.FrameWork.Management.Connection.Sql.alSql = al[0] as System.Collections.ArrayList;
                        Neusoft.FrameWork.Management.Connection.Sql.table_name = al[1] as System.Collections.ArrayList;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("FrameWork版本不对！无法获得正确的SQL语句。");
                    }
                }
                catch { isDBConnect = false; }
            }

            System.Console.WriteLine("Sql语句读取成功");

            System.Console.WriteLine("\n");
            
            #endregion

            if (isDBConnect)
            {
                string err = "";
                if (Neusoft.FrameWork.Management.Connection.GetSetting(out err) == -1)
                {
                    System.Console.WriteLine(err);
                }
                try
                {
                    RemotingConfiguration.Configure("CacheServer.config", false);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
          
            System.Console.WriteLine("不要关闭该程序.....");

            System.Windows.Forms.Application.Run();
        }
    }
}
