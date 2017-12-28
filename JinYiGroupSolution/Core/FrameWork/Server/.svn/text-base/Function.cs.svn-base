using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Lifetime;
using System.Collections;
using System.Configuration;

namespace Neusoft.FrameWork.Server
{
    /// <summary>
    /// 三层，两层管理函数
    /// </summary>
    public class Function
    {
        /// <summary>
        /// 
        /// </summary>
        static Function()
        {
            if (applicationId == "")
            {
                //applicationId = System.DateTime.Now.Ticks.ToString();
                //{793824BE-53B1-4484-BC1E-C277E2DEBE59}
                applicationId = new Guid().ToString() + new Random().ToString();
            }
            try
            {
                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "/Remote.config"))
                {
                    RemotingConfiguration.Configure("Remote.config", false);

                    //add start
                    if (Neusoft.FrameWork.Management.Connection.IsSocketUsed)
                    {
                        client = ClientManagerFactory.CreateInstance("Neusoft.FrameWork.Server.IOClientManager",
                            new object[] { applicationId });
                        if (!Object.Equals(null, client))
                            client.ConnServer();
                    }
                    //add end   
                }               
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private static BaseClientManager client;

        private static string applicationId = "";

        /// <summary>
        /// 
        /// </summary>
        private  static ServerManager manager = null;

        /// <summary>
        /// 缓存服务
        /// </summary>
        private static Neusoft.FrameWork.Server.CacheServerManager cacheServer;

        /// <summary>
        /// 
        /// </summary>
        private static string err = "";

        /// <summary>
        /// 错误代码
        /// </summary>
        private static string errCode;

        /// <summary>
        /// 提示信息
        /// </summary>
        public static string Err
        {
            get
            {
                return err;
            }
        }

        public static string ErrCode
        {
            get
            {
                return errCode;
            }
        }

        public static ServerManager Manager
        {
            get
            {
            manager:
                try
                {
                    if (manager == null)
                    {                       
                        manager = new ServerManager();                                
                    }                                            

                    manager.SetID(applicationId);                   

                }
                catch (Exception ex)
                {
                    err = "无法连接服务器!" + ex.Message;
                    //无法联机，采用脱机


                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("连接应用服务器出错！" + err + "\n是否重试连接服务器？\n [取消]停止程序  \n[重试]试验重新连接数据库 ", "错误", System.Windows.Forms.MessageBoxButtons.RetryCancel);

                    if (result == System.Windows.Forms.DialogResult.Retry)
                    {
                        manager = new ServerManager();

                        //add start
                        if (Neusoft.FrameWork.Management.Connection.IsSocketUsed)
                        {
                            if (client.ConnectState == TcpCli.ConnectState.NotConnect)
                            {                                
                                client = ClientManagerFactory.CreateInstance("Neusoft.FrameWork.Server.IOClientManager",
                                    new object[] { applicationId });
                                if (!Object.Equals(null, client))
                                    client.ConnServer();
                            }
                        }
                        //add end
                        goto manager;
                    }
                    else
                    {
                        
                        System.Windows.Forms.Application.Exit();
                    }
                }

                return manager;


            }
        }

        /// <summary>
        /// 缓存服务
        /// </summary>
        public static Neusoft.FrameWork.Server.CacheServerManager CacheServer
        {
            get
            {
            manager:
                try
                {
                    if (cacheServer == null)
                    {
                        cacheServer = new Neusoft.FrameWork.Server.CacheServerManager();
                    }

                    cacheServer.InitializeLifetimeService();

                    return cacheServer;

                }
                catch (Exception ex)
                {
                    err = "无法连接服务器!" + ex.Message;

                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("连接应用服务器出错！" + err + "\n是否重试连接服务器？\n [取消]停止程序  \n[重试]试验重新连接数据库 ", "错误", System.Windows.Forms.MessageBoxButtons.RetryCancel);

                    if (result == System.Windows.Forms.DialogResult.Retry)
                    {
                        cacheServer = new Neusoft.FrameWork.Server.CacheServerManager();
                        goto manager;
                    }
                    else
                    {
                        System.Environment.Exit(System.Environment.ExitCode);   
                        return null;
                    }
                }

                return cacheServer;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// 
        /// ErrCode=NoDataFound       未维护数据
        /// ErrCode=NoManagmentFound  未维护数据提取信息
        /// ErrCode=PauseCache        暂停了缓存处理
        /// ErrCode=MisMatch          需要的数据类型与缓存数据类别不匹配
        /// 
        /// </summary>
        /// <param name="dictionaryKey"></param>
        /// <returns></returns>
        public static ArrayList GetDictionary(Neusoft.FrameWork.Models.CacheDataType cacheKey, Type t)
        {
            return GetDictionary(cacheKey, null, t);
        }

        /// <summary>
        /// 获取缓存数据
        /// 
        /// ErrCode=NoDataFound       未维护数据
        /// ErrCode=NoManagmentFound  未维护数据提取信息
        /// ErrCode=PauseCache        暂停了缓存处理
        /// ErrCode=MisMatch          需要的数据类型与缓存数据类别不匹配
        /// 
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <param name="param">参数数组</param>
        /// <param name="t">数据类型</param>
        /// <returns></returns>
        public static ArrayList GetDictionary(Neusoft.FrameWork.Models.CacheDataType cacheKey, string[] param,Type t)
        {
            ArrayList alCacheData = CacheServer.GetDictionary(cacheKey, param, t);
            if (alCacheData == null)
            {
                err = CacheServer.Error;
                errCode = CacheServer.ErrCode;
            }

            return alCacheData;

            //序列化 效率不是很高 以下方法屏蔽
            //byte[] compressbyte = CacheServer.GetCacheData(cacheKey, null, t);
            //if (compressbyte == null)
            //{
            //    return null;
            //}

            //return (ArrayList)Neusoft.FrameWork.Function.Serialize.DeSerialization(compressbyte);
        }
    }
}
