using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Neusoft.FrameWork.Server
{
    /// <summary>
    /// 
    /// </summary>
    public enum ServerVerb
    {
        STATE,
        COUNT,        
        LIST,
        KILL,
        CLEAR,
        STOP        
    }

    /// <summary>
    /// 
    /// </summary>
    interface ITcpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConnectingServer(object sender, NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConnectedServer(object sender, NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DisConnectedServer(object sender, NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RecvdServerData(object sender, NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CannotConnectedServer(object sender, NetEventArgs e);       
    }

    /// <summary>
    /// 
    /// </summary>
    interface ITcpServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ClientConn(object sender, Neusoft.FrameWork.Server.NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ServerFull(object sender, Neusoft.FrameWork.Server.NetEventArgs e);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ClientClose(object sender, Neusoft.FrameWork.Server.NetEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RecvClientData(object sender, Neusoft.FrameWork.Server.NetEventArgs e);        
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseServerManager : ITcpServer
    {
        #region 字段

        private const string DefaultEndTag = "##";
        private const string DefaultConfigFileName = "Serverhost.config";
        private TcpSvr tcpSvr;
        private string configFileName = DefaultConfigFileName;        
        private ushort port;
        private ushort maxClientCount;

        #endregion

        #region 属性

        public bool IsServerRun
        {
            get
            {
                return tcpSvr.IsRun;
            }
        }

        public int ClientCount
        {
            get
            {
                return tcpSvr.SessionCount;
            }
        }

        public Hashtable ClientTable
        {
            get
            {
                return tcpSvr.SessionTable;
            }
        }

        public int ServerCapacity
        {
            get
            {
                return tcpSvr.Capacity;
            }
        }

        public string EndTag
        {
            get
            {
                return tcpSvr.Resovlver.EndTag;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public BaseServerManager():this(DefaultConfigFileName){}       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFileName"></param>
        public BaseServerManager(string configFileName)
        {
            this.configFileName = configFileName;            

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName)))
            {
                throw (new FileNotFoundException("没有找的服务器端默认的配置文件！"));
            }

            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = this.configFileName;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                AppSettingsSection appSection = (AppSettingsSection)config.Sections["appSettings"];
                port = Convert.ToUInt16(appSection.Settings["port"].Value);
                maxClientCount = Convert.ToUInt16(appSection.Settings["maxclientcount"].Value);

                tcpSvr = new TcpSvr(port, maxClientCount);

                tcpSvr.Resovlver = new Neusoft.FrameWork.Server.DatagramResolver(DefaultEndTag);
                //服务器满 
                tcpSvr.ServerFull += new Neusoft.FrameWork.Server.NetEvent(ServerFull);

                //新客户端连接 
                tcpSvr.ClientConn += new Neusoft.FrameWork.Server.NetEvent(ClientConn);

                //客户端关闭 
                tcpSvr.ClientClose += new Neusoft.FrameWork.Server.NetEvent(ClientClose);

                //接收到数据 
                tcpSvr.RecvData += new Neusoft.FrameWork.Server.NetEvent(RecvClientData);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <param name="maxclientcount"></param>
        public BaseServerManager(ushort port, ushort maxclientcount)
        {
            try
            {
                this.port = port;
                this.maxClientCount = maxclientcount;                

                tcpSvr = new TcpSvr(this.port, this.maxClientCount);

                tcpSvr.Resovlver = new Neusoft.FrameWork.Server.DatagramResolver(DefaultEndTag);
                //服务器满 
                tcpSvr.ServerFull += new Neusoft.FrameWork.Server.NetEvent(ServerFull);

                //新客户端连接 
                tcpSvr.ClientConn += new Neusoft.FrameWork.Server.NetEvent(ClientConn);

                //客户端关闭 
                tcpSvr.ClientClose += new Neusoft.FrameWork.Server.NetEvent(ClientClose);

                //接收到数据 
                tcpSvr.RecvData += new Neusoft.FrameWork.Server.NetEvent(RecvClientData);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       
        
        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        public void StartServer()
        {
            tcpSvr.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopServer()
        {
            tcpSvr.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseAllClient()
        {
            tcpSvr.CloseAllClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="closeClient"></param>
        public void CloseSession(Session closeClient)
        {
            tcpSvr.CloseSession(closeClient);
        }

        #endregion

        #region ITcpServer 成员

        public virtual void ClientConn(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void ServerFull(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void ClientClose(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void RecvClientData(object sender, NetEventArgs e)
        {
            InnerMethod(e);
        }

        protected virtual void StateMethod(NetEventArgs e)
        {
            string state = IsServerRun ? "Server is running!" : "Server is not running!";
            tcpSvr.Send(e.Client, string.Format("{0}##", state));
        }

        protected virtual void CountMethod(NetEventArgs e)
        {
            tcpSvr.Send(e.Client, string.Format("Current count of Client is {0}/{1}.##",
                                ClientCount, ServerCapacity));
        }

        protected virtual void ListMethod(NetEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Session client in ClientTable.Values)
            {
                if (client != null)
                {
                    sb.Append(string.Format("Client:{0} connected server. SessionId is:{1}.",
                    client.ClientSocket.RemoteEndPoint.ToString(),
                    client.ID)).Append(Environment.NewLine);
                }
            }
            tcpSvr.Send(e.Client, string.Format("{0}##", sb.ToString().TrimEnd(Environment.NewLine.ToCharArray())));
        }

        protected virtual void ClearMethod()
        {
            CloseAllClient();
        }

        protected virtual void StopMethod()
        {
            StopServer();
        } 

        protected virtual void KillMethod(NetEventArgs e,string killId)
        {
            Session client = (Session)ClientTable[killId];

            if (client != null)
            {
                CloseSession(client);
                tcpSvr.Send(e.Client, "Client is killed!##");
            }
            else
            {
                tcpSvr.Send(e.Client, "Client is not exist!##");
            }
        }

        protected virtual void InnerMethod(NetEventArgs e)
        {
            //liuke add 20091224 start
            string info = e.Client.Datagram.TrimEnd(Environment.NewLine.ToCharArray());
            if (!string.IsNullOrEmpty(info))
            {
                string[] para = info.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (para.Length == 2)
                {
                    ServerVerb sv;
                    try
                    {
                        sv = (ServerVerb)Enum.Parse(typeof(ServerVerb), para[0].ToUpper());
                    }
                    catch
                    {
                        tcpSvr.Send(e.Client, "Error Command!##");
                        return;
                    }
                    switch (sv)
                    {
                        case ServerVerb.KILL:
                            KillMethod(e, para[1]);
                            break;
                    }
                }
                else if (para.Length == 1)
                {
                    ServerVerb sv;
                    try
                    {
                        sv = (ServerVerb)Enum.Parse(typeof(ServerVerb), para[0].ToUpper());
                    }
                    catch
                    {
                        tcpSvr.Send(e.Client, "Error Command!##");
                        return;
                    }
                    switch (sv)
                    {
                        case ServerVerb.STATE:
                            StateMethod(e);
                            break;
                        case ServerVerb.COUNT:
                            CountMethod(e);
                            break;
                        case ServerVerb.LIST:
                            ListMethod(e);
                            break;
                        case ServerVerb.CLEAR:
                            ClearMethod();
                            break;
                        case ServerVerb.STOP:
                            StopMethod();
                            break;                       
                    }
                }
                else
                {
                    tcpSvr.Send(e.Client, "Error Command!##");
                    return;
                }

            }
            //liuke add 20091224 end            
        }

        #endregion       
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseClientManager : ITcpClient
    {
        #region 字段

        private const string DefaultEndTag = "##";
        private const string DefaultConfigFileName = "Remote.config";
        private TcpCli tcpCli;
        private string configFileName = DefaultConfigFileName;
        private string ip;
        private int port;
        private string applicationId;
        private string lastRevMsg = string.Empty;

        #endregion

        #region 属性

        public TcpCli.ConnectState ConnectState
        {
            get
            {
                return tcpCli.IsConnected;
            }
        }

        public Session ClientSession
        {
            get
            {
                return tcpCli.ClientSession;
            }
        }

        public string EndTag
        {
            get
            {
                return tcpCli.Resovlver.EndTag;
            }
        }

        public string ApplicationId
        {
            get
            {
                return this.applicationId;
            }
            set
            {
                this.applicationId = value;
            }
        }

        protected string LastRevMsg
        {
            get
            {
                return this.lastRevMsg;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        public BaseClientManager(string applicationId) : this(applicationId, DefaultConfigFileName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="configFileName"></param>
        public BaseClientManager(string applicationId,string configFileName)
        {
            this.applicationId = applicationId;
            this.configFileName = configFileName;

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName)))
            {
                throw (new FileNotFoundException("没有找的客户端默认的配置文件！"));
            }

            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = this.configFileName;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                AppSettingsSection appSection = (AppSettingsSection)config.Sections["appSettings"];
                ip = appSection.Settings["ip"].Value;
                port = Convert.ToInt32(appSection.Settings["port"].Value);               

                tcpCli = new TcpCli();
                tcpCli.Resovlver = new Neusoft.FrameWork.Server.DatagramResolver(DefaultEndTag);
                tcpCli.DisConnectedServer += new NetEvent(DisConnectedServer);
                tcpCli.ConnectingServer += new NetEvent(ConnectingServer);
                tcpCli.ConnectedServer += new NetEvent(ConnectedServer);
                tcpCli.ReceivedDatagram += new NetEvent(RecvdServerData);
                tcpCli.CannotConnectedServer += new NetEvent(CannotConnectedServer);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public BaseClientManager(string applicationId,string ip, int port)
        {
            try
            {
                this.applicationId = applicationId;
                this.ip = ip;   
                this.port = port;

                tcpCli = new TcpCli();
                tcpCli.Resovlver = new Neusoft.FrameWork.Server.DatagramResolver(DefaultEndTag);
                tcpCli.DisConnectedServer += new NetEvent(DisConnectedServer);
                tcpCli.ConnectingServer += new NetEvent(ConnectingServer);
                tcpCli.ConnectedServer += new NetEvent(ConnectedServer);
                tcpCli.ReceivedDatagram += new NetEvent(RecvdServerData);
                tcpCli.CannotConnectedServer += new NetEvent(CannotConnectedServer);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       

        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        public void ConnServer()
        {
            tcpCli.Connect(this.ip, this.port);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void ConnServer(string ip, int port)
        {
            tcpCli.Connect(ip, port);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            tcpCli.Close();
        }

        #endregion

        #region ITcpClient 成员

        public virtual void ConnectingServer(object sender, NetEventArgs e)
        {
            tcpCli.Send(String.Format("{0}##", applicationId));
        }

        public virtual void ConnectedServer(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void DisConnectedServer(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void CannotConnectedServer(object sender, NetEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void RecvdServerData(object sender, NetEventArgs e)
        {
            //liuke add 20091224 start
            string info = e.Client.Datagram.Trim('#');
            if(!string.IsNullOrEmpty(info)) 
                lastRevMsg = info;
            //liuke add 20091224 end
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    interface IWriteLog
    {    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logcontext"></param>
        void WriteLog(string logcontext);
    }

    /// <summary>
    /// 
    /// </summary>
    public class IOServerManager : BaseServerManager,IWriteLog
    {
        #region 字段

        private readonly object lockObj = new object();
        private const string folderName = "ServerLogFolder";
        private const string logFileName = "ServerLogFile.log";

        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        public IOServerManager():base(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFileName"></param>
        public IOServerManager(string configFileName) : base(configFileName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <param name="maxclientcount"></param>
        public IOServerManager(ushort port, ushort maxclientcount) : base(port, maxclientcount) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ClientConn(object sender, NetEventArgs e)
        {
            string info = string.Format("客户端: {0} 连接到了服务器: {1}.",
            e.Client.ClientSocket.RemoteEndPoint.ToString(),
            e.Client.ID);
            WriteLog(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ServerFull(object sender, NetEventArgs e)
        {
            string info = string.Format("服务器连接数已满.客户端: {0} 连接请求被拒绝.",
            e.Client.ClientSocket.RemoteEndPoint.ToString());

            //服务器满了,必须关闭新来的客户端连接 
            e.Client.Close();
            Neusoft.FrameWork.Server.Pooling.CloseDB(e.Client.ID);
            WriteLog(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ClientClose(object sender, NetEventArgs e)
        {
            string info;

            if (e.Client.TypeOfExit == Neusoft.FrameWork.Server.Session.ExitType.ExceptionExit)
            {
                //socket异常关闭表示客户端是正常点击关闭按钮退出的
                info = string.Format("客户端:{0} 正常关闭了.",e.Client.ID);
            }
            else
            {
                //socket正常关闭表示客户端是被服务器强制关闭连接的
                info = string.Format("客户端:{0} 异常关闭了.",e.Client.ID);
            }
            Pooling.CloseDB(e.Client.ID);
            WriteLog(info);
        }


        #region IWriteLog 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logcontext"></param>
        public void WriteLog(string logcontext)
        {
            lock (lockObj)
            {
                DirectoryInfo di = null;
                FileStream fs = null;
                try
                {
                    string folderpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
                    if (!Directory.Exists(folderpath))
                    {
                        di = Directory.CreateDirectory(folderpath);                        
                        di = null;
                    }

                    string filepath = Path.Combine(folderpath, logFileName);
                    if (!File.Exists(filepath))
                    {
                        fs = File.Create(filepath);
                        fs.Dispose();
                        fs = null;
                    }

                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), logcontext);
                        sw.Close();                        
                    }
                }
                catch (IOException ex)
                {
                    throw (ex);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (!Object.Equals(null, di))
                    {
                        di = null;
                    }
                    if (!Object.Equals(null, fs))
                    {
                        fs.Dispose();
                        fs = null;
                    }
                }
            }
        }        

        #endregion

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class IOClientManager : BaseClientManager,IWriteLog
    {
        #region 字段

        private readonly object lockObj = new object();
        private const string folderName = "ClientLogFolder";
        private const string logFileName = "ClientLogFile.log";

        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        public IOClientManager(string applicationId) : base(applicationId) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="configFileName"></param>
        public IOClientManager(string applicationId, string configFileName) : base(applicationId, configFileName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public IOClientManager(string applicationId, string ip, int port) : base(applicationId, ip, port) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ConnectedServer(object sender, NetEventArgs e)
        {
            string info = string.Format("客户端: {0} 连接到了服务器: {1}.", e.Client.ID,
            e.Client.ClientSocket.RemoteEndPoint.ToString());

            WriteLog(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DisConnectedServer(object sender, NetEventArgs e)
        {
            string info;

            if (e.Client.TypeOfExit == Session.ExitType.ExceptionExit)
            {
                //socket异常关闭表示客户端是正常点击关闭按钮退出的
                info = string.Format("客户端:{0} 正常关闭了.",e.Client.ID);                
            }
            else
            {
                //socket正常关闭表示客户端是被服务器强制关闭连接的
                info = string.Format("客户端:{0} 异常关闭了.",e.Client.ID);
            }

            WriteLog(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void CannotConnectedServer(object sender, NetEventArgs e)
        {
            string info = "连接不到远程服务器！";

            WriteLog(info);
            //throw (new ApplicationException(info));
        }

        #region IWriteLog 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logcontext"></param>
        public void WriteLog(string logcontext)
        {
            lock (lockObj)
            {
                DirectoryInfo di = null;
                FileStream fs = null;
                try
                {
                    string folderpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
                    if (!Directory.Exists(folderpath))
                    {
                        di = Directory.CreateDirectory(folderpath);
                        di = null;
                    }

                    string filepath = Path.Combine(folderpath, logFileName);
                    if (!File.Exists(filepath))
                    {
                        fs = File.Create(filepath);
                        fs.Dispose();
                        fs = null;
                    }

                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), logcontext);
                        sw.Close();
                    }
                }
                catch (IOException ex)
                {
                    throw (ex);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (!Object.Equals(null, di))
                    {
                        di = null;
                    }
                    if (!Object.Equals(null, fs))
                    {
                        fs.Dispose();
                        fs = null;
                    }
                }
            }
        }        

        #endregion

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ServerManagerFactory 
    {
        static BaseServerManager ServerManagerInstance;
        static readonly object lockObj = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static BaseServerManager CreateInstance(string Name, object[] args)
        {
            lock (lockObj)
            {
                try
                {
                    if (Object.Equals(null, ServerManagerInstance))
                    {
                        Type type = Type.GetType(Name, true);
                        ServerManagerInstance = (BaseServerManager)Activator.CreateInstance(type, args);
                    }

                    return ServerManagerInstance;
                }
                catch (TypeLoadException ex)
                {
                    throw (ex);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ClientManagerFactory 
    {
        static BaseClientManager ServerClientInstance;
        static readonly object lockObj = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static BaseClientManager CreateInstance(string Name, object[] args)
        {
            lock (lockObj)
            {
                try
                {
                    if (Object.Equals(null, ServerClientInstance))
                    {
                        Type type = Type.GetType(Name, true);
                        ServerClientInstance = (BaseClientManager)Activator.CreateInstance(type, args);
                    }

                    return ServerClientInstance;
                }
                catch (TypeLoadException ex)
                {
                    throw (ex);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        } 
    }
}