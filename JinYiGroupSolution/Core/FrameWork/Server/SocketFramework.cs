using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace Neusoft.FrameWork.Server
{

    /// <summary> 
    /// 网络通讯事件模型委托 
    /// </summary> 
    public delegate void NetEvent(object sender, NetEventArgs e);

    /// <summary>
    /// 提供TCP连接服务的服务器类
    /// </summary>
    public class TcpSvr
    {
        #region 定义字段

        /// <summary> 
        /// 默认的服务器最大连接客户端端数据 
        /// </summary> 
        public const int DefaultMaxClient = 10000;

        /// <summary> 
        /// 接收数据缓冲区大小64K 
        /// </summary> 
        public const int DefaultBufferSize = 64 * 1024;

        /// <summary> 
        /// 最大数据报文大小 
        /// </summary> 
        public const int MaxDatagramSize = 640 * 1024;

        /// <summary> 
        /// 报文解析器 
        /// </summary> 
        private DatagramResolver _resolver;

        /// <summary> 
        /// 通讯格式编码解码器 
        /// </summary> 
        private Coder _coder;

        /// <summary> 
        /// 服务器程序使用的端口 
        /// </summary> 
        private ushort _port;

        /// <summary> 
        /// 服务器程序允许的最大客户端连接数 
        /// </summary> 
        private ushort _maxClient;

        /// <summary> 
        /// 服务器的运行状态 
        /// </summary> 
        private bool _isRun;

        /// <summary> 
        /// 接收数据缓冲区 
        /// </summary> 
        private byte[] _recvDataBuffer;

        /// <summary> 
        /// 服务器使用的异步Socket类 
        /// </summary> 
        private Socket _svrSock;

        /// <summary> 
        /// 保存所有客户端会话的哈希表 
        /// </summary> 
        private Hashtable _sessionTable;

        /// <summary> 
        /// 当前的连接的客户端数 
        /// </summary> 
        private ushort _clientCount;

        private System.Threading.TimerCallback timerCB;
        Timer timer;
        private static readonly object _tableLockObj = new object();


        #endregion

        #region 属性

        /// <summary> 
        /// 服务器的Socket对象 
        /// </summary> 
        public Socket ServerSocket
        {
            get
            {
                return _svrSock;
            }
        }

        /// <summary> 
        /// 数据报文分析器 
        /// </summary> 
        public DatagramResolver Resovlver
        {
            get
            {
                return _resolver;
            }
            set
            {
                _resolver = value;
            }
        }

        /// <summary> 
        /// 客户端会话数组,保存所有的客户端,不允许对该数组的内容进行修改 
        /// </summary> 
        public Hashtable SessionTable
        {
            get
            {
                return _sessionTable;
            }
        }

        /// <summary> 
        /// 服务器可以容纳客户端的最大能力 
        /// </summary> 
        public int Capacity
        {
            get
            {
                return _maxClient;
            }
        }

        /// <summary> 
        /// 当前的客户端连接数 
        /// </summary> 
        public int SessionCount
        {
            get
            {
                return _clientCount;
            }
        }

        /// <summary> 
        /// 服务器运行状态 
        /// </summary> 
        public bool IsRun
        {
            get
            {
                return _isRun;
            }
        }

        #endregion

        #region 事件定义

        /// <summary> 
        /// 客户端建立连接事件 
        /// </summary> 
        public event NetEvent ClientConn;

        /// <summary> 
        /// 客户端关闭事件 
        /// </summary> 
        public event NetEvent ClientClose;

        /// <summary> 
        /// 服务器已经满事件 
        /// </summary> 
        public event NetEvent ServerFull;

        /// <summary> 
        /// 服务器接收到数据事件 
        /// </summary> 
        public event NetEvent RecvData;

        #endregion

        #region 构造函数

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="port">服务器端监听的端口号</param> 
        /// <param name="maxClient">服务器能容纳客户端的最大能力</param> 
        /// <param name="encodingMothord">通讯的编码方式</param> 
        public TcpSvr(ushort port, ushort maxClient, Coder coder)
        {
            _port = port;
            _maxClient = maxClient;
            _coder = coder;
        }

        /// <summary> 
        /// 构造函数(默认使用Default编码方式) 
        /// </summary> 
        /// <param name="port">服务器端监听的端口号</param> 
        /// <param name="maxClient">服务器能容纳客户端的最大能力</param> 
        public TcpSvr(ushort port, ushort maxClient)
        {
            _port = port;
            _maxClient = maxClient;
            _coder = new Coder(Coder.EncodingMothord.Default);
        }

        /// <summary> 
        /// 构造函数(默认使用Default编码方式和DefaultMaxClient(100)个客户端的容量) 
        /// </summary> 
        /// <param name="port">服务器端监听的端口号</param> 
        public TcpSvr(ushort port)
            : this(port, DefaultMaxClient)
        {
        }

        #endregion

        #region 公有方法

        /// <summary> 
        /// 启动服务器程序,开始监听客户端请求 
        /// </summary> 
        public virtual void Start()
        {
            if (_isRun)
            {
                throw (new ApplicationException("TcpSvr已经在运行."));
            }

            _sessionTable = new Hashtable(_maxClient);

            _recvDataBuffer = new byte[DefaultBufferSize];

            //初始化socket 
            _svrSock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            //绑定端口 
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, _port);
            _svrSock.Bind(iep);

            //开始监听 
            _svrSock.Listen(5);

            //设置异步方法接受客户端连接 
            _svrSock.BeginAccept(new AsyncCallback(AcceptConn), _svrSock);

            _isRun = true;

            timerCB = new System.Threading.TimerCallback(CheckClient);
            timer = new Timer(timerCB, null, 10000, 1000);

        }

        protected virtual void CheckClient(Object state)
        {
            try
            {
                if (_sessionTable != null && _sessionTable.Values.Count > 0)
                {
                    Session[] tables = new Session[_sessionTable.Values.Count];
                    _sessionTable.Values.CopyTo(tables, 0);
                    foreach (Session Client in tables)
                    {
                        if (!Object.Equals(null, this.Resovlver) && !String.IsNullOrEmpty(this.Resovlver.EndTag))
                        {
                            Send(Client, this.Resovlver.EndTag);
                        }
                        else
                        {
                            Send(Client, String.Empty);
                        }
                    }
                }
            }
            //{1085D671-3AB9-4a64-BDAD-A36F24D77384}
            //catch (IndexOutOfRangeException)
            //{ }
            //catch (Exception)
            //{ }
            catch//暂时对异常先不做处理，我在考虑一下看怎么处理
            { }

        }

        /// <summary> 
        /// 停止服务器程序,所有与客户端的连接将关闭 
        /// </summary> 
        public virtual void Stop()
        {
            if (!_isRun)
            {
                throw (new ApplicationException("TcpSvr已经停止"));
            }

            //这个条件语句，一定要在关闭所有客户端以前调用 
            //否则在EndConn会出现错误 
            _isRun = false;

            //关闭数据连接,负责客户端会认为是强制关闭连接 
            if (_svrSock.Connected)
            {
                _svrSock.Shutdown(SocketShutdown.Both);
            }

            CloseAllClient();

            //清理资源 
            _svrSock.Close();

            _sessionTable = null;            
        }

        /// <summary> 
        /// 关闭所有的客户端会话,与所有的客户端连接会断开 
        /// </summary> 
        public virtual void CloseAllClient()
        {
            foreach (Session client in _sessionTable.Values)
            {
                client.Close();
            }

            _sessionTable.Clear();

            _clientCount = 0;
        }

        /// <summary> 
        /// 关闭一个与客户端之间的会话 
        /// </summary> 
        /// <param name="closeClient">需要关闭的客户端会话对象</param> 
        public virtual void CloseSession(Session closeClient)
        {
            Debug.Assert(closeClient != null);

            if (closeClient != null)
            {
                closeClient.Datagram = null;

                _sessionTable.Remove(closeClient.ID);

                _clientCount--;

                //客户端强制关闭链接 
                if (ClientClose != null)
                {
                    ClientClose(this, new NetEventArgs(closeClient));
                }

                closeClient.Close();
            }
        }

        /// <summary> 
        /// 发送数据 
        /// </summary> 
        /// <param name="recvDataClient">接收数据的客户端会话</param> 
        /// <param name="datagram">数据报文</param> 
        public virtual void Send(Session recvDataClient, string datagram)
        {
            if (String.IsNullOrEmpty(datagram))
            {
                return;
            }
            //获得数据编码 
            byte[] data = _coder.GetEncodingBytes(datagram);

            try
            {
                recvDataClient.ClientSocket.BeginSend(data, 0, data.Length, SocketFlags.None,
                new AsyncCallback(SendDataEnd), recvDataClient.ClientSocket);
            }
            catch (SocketException)
            {
                if (recvDataClient != null)
                {
                    recvDataClient.Datagram = null;

                    _sessionTable.Remove(recvDataClient.ID);

                    _clientCount--;

                    //客户端强制关闭链接 
                    if (ClientClose != null)
                    {
                        ClientClose(this, new NetEventArgs(recvDataClient));
                    }

                    recvDataClient.Close();
                }
            }
            //{1085D671-3AB9-4a64-BDAD-A36F24D77384}
            catch (ObjectDisposedException ex)//先把异常截获了，暂时对异常先不做处理，我在考虑一下看怎么处理
            {
            }
        }

        #endregion

        #region 受保护方法

        /// <summary> 
        /// 关闭一个客户端Socket,首先需要关闭Session 
        /// </summary> 
        /// <param name="client">目标Socket对象</param> 
        /// <param name="exitType">客户端退出的类型</param> 
        protected virtual void CloseClient(string id, Session.ExitType exitType)
        {
            Debug.Assert(id != null);

            //查找该客户端是否存在,如果不存在,抛出异常 
            Session closeClient = FindSession(id);

            if (closeClient != null)
            {
                closeClient.TypeOfExit = exitType;
                CloseSession(closeClient);
            }
        }

        /// <summary> 
        /// 客户端连接处理函数 
        /// </summary> 
        /// <param name="iar">欲建立服务器连接的Socket对象</param> 
        protected virtual void AcceptConn(IAsyncResult iar)
        {
            //如果服务器停止了服务,就不能再接收新的客户端 
            if (!_isRun)
            {
                return;
            }

            //接受一个客户端的连接请求 
            Socket oldserver = (Socket)iar.AsyncState;

            Socket client = (Socket)oldserver.EndAccept(iar);

            //检查是否达到最大的允许的客户端数目 
            if (_clientCount == _maxClient)
            {
                //服务器已满,发出通知 
                if (ServerFull != null)
                {
                    ServerFull(this, new NetEventArgs(new Session(client)));
                }
            }
            else
            {
                //开始接受来自该客户端的连接信息ID                 
                client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                new AsyncCallback(ReceiveConnData), client);
            }

            //继续接受客户端 
            _svrSock.BeginAccept(new AsyncCallback(AcceptConn), _svrSock);
        }

        /// <summary> 
        /// 通过Socket对象查找Session对象 
        /// </summary> 
        /// <param name="client"></param> 
        /// <returns>找到的Session对象,如果为null,说明并不存在该回话</returns> 
        private Session FindSession(string id)
        {
            return (Session)_sessionTable[id];
        }

        /// <summary> 
        /// 建立SESSION连接的数据接受处理函数，异步的特性就体现在这个函数中， 
        /// 收到数据后，会自动解析为字符串报文 
        /// </summary> 
        /// <param name="iar">目标客户端Socket</param> 
        protected virtual void ReceiveConnData(IAsyncResult iar)
        {
            lock (_tableLockObj)
            {
                Socket client = (Socket)iar.AsyncState;
                try
                {
                    //如果两次开始了异步的接收,所以当客户端退出的时候 
                    //会两次执行EndReceive 
                    int recv = client.EndReceive(iar);

                    if (recv == 0)
                    {
                        //正常的关闭                    
                        client.Close();
                        return;
                    }

                    string receivedData = _coder.GetEncodingString(_recvDataBuffer, recv);
                    //发布收到数据的事件 
                    if (RecvData != null)
                    {
                        //如果定义了报文的尾标记,需要处理报文的多种情况 
                        if (_resolver != null)
                        {
                            string[] recvDatagrams = _resolver.Resolve(ref receivedData);
                            if (recvDatagrams.Length > 0)
                            {
                                if (!_sessionTable.ContainsKey(recvDatagrams[0]))
                                {
                                    Session newSession = new Session(client, recvDatagrams[0]);

                                    _sessionTable.Add(newSession.ID, newSession);

                                    //客户端引用计数+1 
                                    _clientCount++;

                                    //回发确认信息
                                    this.Send(newSession, recvDatagrams[0] + _resolver.EndTag);

                                    //新的客户段连接,发出通知 
                                    if (ClientConn != null)
                                    {
                                        ClientConn(this, new NetEventArgs(newSession));
                                    }
                                    //继续接收来自来客户端的数据 
                                    client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                                    new AsyncCallback(ReceiveData), newSession);
                                    return;
                                }
                            }
                        }
                        //没有定义报文的尾标记,直接交给消息订阅者使用 
                        else
                        {
                            if (!String.IsNullOrEmpty(receivedData))
                            {
                                if (!_sessionTable.ContainsKey(receivedData))
                                {
                                    Session newSession = new Session(client, receivedData);

                                    _sessionTable.Add(newSession.ID, newSession);

                                    //客户端引用计数+1 
                                    _clientCount++;

                                    //回发确认信息
                                    this.Send(newSession, receivedData + _resolver.EndTag);

                                    //新的客户段连接,发出通知 
                                    if (ClientConn != null)
                                    {
                                        ClientConn(this, new NetEventArgs(newSession));
                                    }

                                    //继续接收来自来客户端的数据 
                                    client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                                    new AsyncCallback(ReceiveData), newSession);
                                    return;
                                }
                            }
                        }
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }//end of if(RecvData!=null)
                }
                catch (SocketException ex)
                {
                    //客户端退出 
                    if (10054 == ex.ErrorCode)
                    {
                        //正常的关闭                     
                        if (!Object.Equals(null, client))
                        {
                            //关闭数据的接受和发送 
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                    }

                }
                catch (ObjectDisposedException ex)
                {
                    if (ex != null)
                    {
                        ex = null;
                        //DoNothing; 
                    }
                }
                catch (Exception ex)
                {
                    if (ex != null)
                    {
                        ex = null;
                    }
                }

            }
        }

        /// <summary> 
        /// 接受数据完成处理函数，异步的特性就体现在这个函数中， 
        /// 收到数据后，会自动解析为字符串报文 
        /// </summary> 
        /// <param name="iar">目标客户端Socket</param> 
        protected virtual void ReceiveData(IAsyncResult iar)
        {
            Session session = (Session)iar.AsyncState;
            Socket client = session.ClientSocket;

            try
            {
                //如果两次开始了异步的接收,所以当客户端退出的时候 
                //会两次执行EndReceive 

                int recv = client.EndReceive(iar);

                if (recv == 0)
                {
                    //正常的关闭 
                    CloseClient(session.ID, Session.ExitType.NormalExit);
                    return;
                }

                string receivedData = _coder.GetEncodingString(_recvDataBuffer, recv);

                //发布收到数据的事件 
                if (RecvData != null)
                {
                    Session sendDataSession = FindSession(session.ID);

                    Debug.Assert(sendDataSession != null);

                    //如果定义了报文的尾标记,需要处理报文的多种情况 
                    if (_resolver != null)
                    {
                        if (sendDataSession.Datagram != null &&
                        sendDataSession.Datagram.Length != 0)
                        {
                            //加上最后一次通讯剩余的报文片断 
                            receivedData = sendDataSession.Datagram + receivedData;
                        }

                        string[] recvDatagrams = _resolver.Resolve(ref receivedData);


                        foreach (string newDatagram in recvDatagrams)
                        {
                            //深拷贝,为了保持Datagram的对立性 
                            ICloneable copySession = (ICloneable)sendDataSession;

                            Session clientSession = (Session)copySession.Clone();

                            clientSession.Datagram = newDatagram;
                            //发布一个报文消息 
                            RecvData(this, new NetEventArgs(clientSession));
                        }

                        //剩余的代码片断,下次接收的时候使用 
                        sendDataSession.Datagram = receivedData;

                        if (sendDataSession.Datagram.Length > MaxDatagramSize)
                        {
                            sendDataSession.Datagram = null;
                        }

                    }
                    //没有定义报文的尾标记,直接交给消息订阅者使用 
                    else
                    {
                        ICloneable copySession = (ICloneable)sendDataSession;

                        Session clientSession = (Session)copySession.Clone();

                        clientSession.Datagram = receivedData;

                        RecvData(this, new NetEventArgs(clientSession));
                    }

                }//end of if(RecvData!=null) 

                //继续接收来自来客户端的数据 
                client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                new AsyncCallback(ReceiveData), session);

            }
            catch (SocketException ex)
            {
                //客户端退出 
                if (10054 == ex.ErrorCode)
                {
                    //客户端强制关闭 
                    CloseClient(session.ID, Session.ExitType.ExceptionExit);
                }

            }
            catch (ObjectDisposedException ex)
            {                
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }
        }

        /// <summary> 
        /// 发送数据完成处理函数 
        /// </summary> 
        /// <param name="iar">目标客户端Socket</param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            try
            {
                Socket client = (Socket)iar.AsyncState;
                int sent = client.EndSend(iar);
            }
            catch (ObjectDisposedException ex)
            {
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }
        }

        #endregion

    }

    /// <summary> 
    /// 提供Tcp网络连接服务的客户端类 
    /// </summary> 
    public class TcpCli
    {
        #region 字段

        /// <summary>
        /// 客户端连接状态
        /// </summary>
        public enum ConnectState
        {
            NotConnect = 0,
            Connecting,
            Connected,
        }

        /// <summary>
        /// 客户端连接服务器的Socket
        /// </summary>
        private Socket _cliSocket;

        /// <summary> 
        /// 客户端与服务器之间的会话类 
        /// </summary> 
        private Session _session;

        /// <summary> 
        /// 客户端是否已经连接服务器 
        /// </summary>         
        private ConnectState _connectState = ConnectState.NotConnect;

        /// <summary> 
        /// 接收数据缓冲区大小64K 
        /// </summary> 
        public const int DefaultBufferSize = 64 * 1024;

        /// <summary> 
        /// 报文解析器 
        /// </summary> 
        private DatagramResolver _resolver;

        /// <summary> 
        /// 通讯格式编码解码器 
        /// </summary> 
        private Coder _coder;

        /// <summary> 
        /// 接收数据缓冲区 
        /// </summary> 
        private byte[] _recvDataBuffer = new byte[DefaultBufferSize];

        #endregion

        #region 属性

        /// <summary> 
        /// 返回客户端与服务器之间的会话对象 
        /// </summary> 
        public Session ClientSession
        {
            get
            {
                return _session;
            }
        }

        /// <summary> 
        /// 返回客户端与服务器之间的连接状态 
        /// </summary> 
        public ConnectState IsConnected
        {
            get
            {
                return _connectState;
            }
        }

        /// <summary> 
        /// 数据报文分析器 
        /// </summary> 
        public DatagramResolver Resovlver
        {
            get
            {
                return _resolver;
            }
            set
            {
                _resolver = value;
            }
        }

        /// <summary> 
        /// 编码解码器 
        /// </summary> 
        public Coder ServerCoder
        {
            get
            {
                return _coder;
            }
        }

        #endregion

        #region 事件定义

        //需要订阅事件才能收到事件的通知，如果订阅者退出，必须取消订阅

        /// <summary> 
        /// 正在连接服务器事件 
        /// </summary> 
        public event NetEvent ConnectingServer;

        /// <summary> 
        /// 已经连接服务器事件 
        /// </summary> 
        public event NetEvent ConnectedServer;

        /// <summary> 
        /// 接收到数据报文事件 
        /// </summary> 
        public event NetEvent ReceivedDatagram;

        /// <summary> 
        /// 连接断开事件 
        /// </summary> 
        public event NetEvent DisConnectedServer;

        /// <summary>
        /// 连接不到远程服务器
        /// </summary>
        public event NetEvent CannotConnectedServer;

        #endregion

        #region 公有方法

        /// <summary> 
        /// 默认构造函数,使用默认的编码格式 
        /// </summary> 
        public TcpCli()
        {
            _coder = new Coder(Coder.EncodingMothord.Default);
        }

        /// <summary> 
        /// 构造函数,使用一个特定的编码器来初始化 
        /// </summary> 
        /// <param name="_coder">报文编码器</param> 
        public TcpCli(Coder coder)
        {
            _coder = coder;
        }

        /// <summary> 
        /// 连接服务器 
        /// </summary> 
        /// <param name="ip">服务器IP地址</param> 
        /// <param name="port">服务器端口</param> 
        public virtual void Connect(string ip, int port)
        {
            if (_connectState == ConnectState.Connected)
            {
                //重新连接 
                Debug.Assert(_session != null);

                Close();
            }

            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 20000);

            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            //newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //newsock.Bind(localEP);

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);
            newsock.BeginConnect(iep, new AsyncCallback(Connecting), newsock);
        }

        /// <summary> 
        /// 发送数据报文 
        /// </summary> 
        /// <param name="datagram"></param> 
        public virtual void Send(string datagram)
        {
            if (String.IsNullOrEmpty(datagram))
            {
                return;
            }

            //获得报文的编码字节 
            byte[] data = _coder.GetEncodingBytes(datagram);

            switch (_connectState)
            {
                case ConnectState.NotConnect:
                    throw (new ApplicationException("没有连接服务器，不能发送数据"));
                case ConnectState.Connecting:
                    _cliSocket.BeginSend(data, 0, data.Length, SocketFlags.None,
                    new AsyncCallback(SendDataEnd), _cliSocket);
                    break;
                case ConnectState.Connected:
                    if (_session.ClientSocket.Connected)
                        _session.ClientSocket.BeginSend(data, 0, data.Length, SocketFlags.None,
                                new AsyncCallback(SendDataEnd), _session.ClientSocket);
                    else
                    {
                        _connectState = ConnectState.NotConnect;
                    }
                    break;
            }
        }

        /// <summary> 
        /// 关闭连接 
        /// </summary> 
        public virtual void Close()
        {
            if (_connectState == ConnectState.NotConnect)
            {
                return;
            }

            _session.Close();

            _session = null;

            _connectState = ConnectState.NotConnect;
        }

        #endregion

        #region 受保护方法

        /// <summary> 
        /// 数据发送完成处理函数 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            try
            {
                Socket remote = (Socket)iar.AsyncState;
                int sent = remote.EndSend(iar);
                Debug.Assert(sent != 0);
            }
            catch (ObjectDisposedException ex)
            {
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }            
        }

        /// <summary> 
        /// 建立Tcp连接处理过程 
        /// </summary> 
        /// <param name="iar">异步Socket</param> 
        protected virtual void Connecting(IAsyncResult iar)
        {
            Socket socket = (Socket)iar.AsyncState;
            try
            {
                socket.EndConnect(iar);

                _cliSocket = socket;
                _connectState = ConnectState.Connecting;

                //触发开始连接建立事件 
                if (ConnectingServer != null)
                {
                    ConnectingServer(this, null);
                }

                //建立连接后应该立即接收数据 
                socket.BeginReceive(_recvDataBuffer, 0,
                DefaultBufferSize, SocketFlags.None,
                new AsyncCallback(RecvConnData), socket);
            }
            catch (SocketException ex)
            {
                //客户端退出 
                if (10054 == ex.ErrorCode)
                {
                    //服务器强制的关闭连接，强制退出 
                    _session.TypeOfExit = Session.ExitType.ExceptionExit;

                    if (DisConnectedServer != null)
                    {
                        DisConnectedServer(this, new NetEventArgs(_session));
                    }
                    Close();
                }
                else
                {
                    //服务器强制的关闭连接，强制退出 
                    if (CannotConnectedServer != null)
                    {
                        CannotConnectedServer(this, new NetEventArgs());
                    }
                    Close();
                }
            }
            catch (ObjectDisposedException ex)
            {
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }
        }

        /// <summary> 
        /// 建立SESSION连接的数据接受函数 
        /// </summary> 
        /// <param name="iar">异步Socket</param> 
        protected virtual void RecvConnData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;

            try
            {
                int recv = remote.EndReceive(iar);

                //正常的退出 
                if (recv == 0)
                {
                    return;
                }

                string receivedData = _coder.GetEncodingString(_recvDataBuffer, recv);

                //通过事件发布收到的报文 
                if (ReceivedDatagram != null)
                {
                    //通过报文解析器分析出报文 
                    //如果定义了报文的尾标记,需要处理报文的多种情况 
                    if (_resolver != null)
                    {
                        string[] recvDatagrams = _resolver.Resolve(ref receivedData);

                        if (recvDatagrams.Length > 0)
                        {
                            //创建新的会话
                            _session = new Session(remote, recvDatagrams[0]);
                            _connectState = ConnectState.Connected;

                            //触发连接建立事件 
                            if (ConnectedServer != null)
                            {
                                ConnectedServer(this, new NetEventArgs(_session));
                            }
                        }
                    }
                    //没有定义报文的尾标记,直接交给消息订阅者使用 
                    else
                    {
                        if (!String.IsNullOrEmpty(receivedData))
                        {

                            //创建新的会话
                            _session = new Session(remote, receivedData);
                            _connectState = ConnectState.Connected;

                            //触发连接建立事件 
                            if (ConnectedServer != null)
                            {
                                ConnectedServer(this, new NetEventArgs(_session));
                            }
                        }
                    }
                }//end of if(ReceivedDatagram != null)

                if (Object.Equals(null, _session))
                {
                    //if (CannotConnectedServer != null)
                    //{
                    //    CannotConnectedServer(this, new NetEventArgs());
                    //}
                    return;
                }
                //接收数据 
                _session.ClientSocket.BeginReceive(_recvDataBuffer, 0, DefaultBufferSize, SocketFlags.None,
                new AsyncCallback(RecvData), _session.ClientSocket);
            }
            catch (SocketException ex)
            {
                //客户端退出 
                //if (10054 == ex.ErrorCode)
                //{
                if (CannotConnectedServer != null)
                {
                    CannotConnectedServer(this, new NetEventArgs());
                }
                Close();
                return;
                //}
                //else
                //{
                //    throw (ex);
                //}
            }
            catch (ObjectDisposedException ex)
            {                
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }
        }

        /// <summary> 
        /// 数据接收处理函数 
        /// </summary> 
        /// <param name="iar">异步Socket</param> 
        protected virtual void RecvData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;

            try
            {
                int recv = remote.EndReceive(iar);

                //正常的退出 
                if (recv == 0)
                {
                    _session.TypeOfExit = Session.ExitType.NormalExit;

                    if (DisConnectedServer != null)
                    {
                        DisConnectedServer(this, new NetEventArgs(_session));
                    }
                    Close();

                    return;
                }

                string receivedData = _coder.GetEncodingString(_recvDataBuffer, recv);

                //通过事件发布收到的报文 
                if (ReceivedDatagram != null)
                {
                    //通过报文解析器分析出报文 
                    //如果定义了报文的尾标记,需要处理报文的多种情况 
                    if (_resolver != null)
                    {
                        if (_session.Datagram != null &&
                        _session.Datagram.Length != 0)
                        {
                            //加上最后一次通讯剩余的报文片断 
                            receivedData = _session.Datagram + receivedData;
                        }

                        string[] recvDatagrams = _resolver.Resolve(ref receivedData);


                        foreach (string newDatagram in recvDatagrams)
                        {
                            //Need Deep Copy.因为需要保证多个不同报文独立存在 
                            ICloneable copySession = (ICloneable)_session;

                            Session clientSession = (Session)copySession.Clone();

                            clientSession.Datagram = newDatagram;

                            //发布一个报文消息 
                            ReceivedDatagram(this, new NetEventArgs(clientSession));
                        }

                        //剩余的代码片断,下次接收的时候使用 
                        _session.Datagram = receivedData;
                    }
                    //没有定义报文的尾标记,直接交给消息订阅者使用 
                    else
                    {
                        ICloneable copySession = (ICloneable)_session;

                        Session clientSession = (Session)copySession.Clone();

                        clientSession.Datagram = receivedData;

                        ReceivedDatagram(this, new NetEventArgs(clientSession));

                    }
                }//end of if(ReceivedDatagram != null) 

                //继续接收数据 
                _session.ClientSocket.BeginReceive(_recvDataBuffer, 0, DefaultBufferSize, SocketFlags.None,
                new AsyncCallback(RecvData), _session.ClientSocket);
            }
            catch (SocketException ex)
            {
                //客户端退出 
                if (10054 == ex.ErrorCode)
                {
                    //服务器强制的关闭连接，强制退出 
                    _session.TypeOfExit = Session.ExitType.ExceptionExit;

                    if (DisConnectedServer != null)
                    {
                        DisConnectedServer(this, new NetEventArgs(_session));
                    }
                    Close();
                }
                else
                {
                    //服务器强制的关闭连接，强制退出 
                    if (CannotConnectedServer != null)
                    {
                        CannotConnectedServer(this, new NetEventArgs());
                    }
                    Close();
                }
            }
            catch (ObjectDisposedException ex)
            {                
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }

        }

        #endregion

    }

    /// <summary> 
    /// 通讯编码格式提供者,为通讯服务提供编码和解码服务 
    /// 你可以在继承类中定制自己的编码方式如:数据加密传输等 
    /// </summary> 
    public class Coder
    {
        /// <summary> 
        /// 编码方式 
        /// </summary> 
        private EncodingMothord _encodingMothord;

        protected Coder()
        {

        }

        public Coder(EncodingMothord encodingMothord)
        {
            _encodingMothord = encodingMothord;
        }

        public enum EncodingMothord
        {
            Default = 0,
            Unicode,
            UTF8,
            ASCII,
        }

        /// <summary> 
        /// 通讯数据解码 
        /// </summary> 
        /// <param name="dataBytes">需要解码的数据</param> 
        /// <returns>编码后的数据</returns> 
        public virtual string GetEncodingString(byte[] dataBytes, int size)
        {
            switch (_encodingMothord)
            {
                case EncodingMothord.Default:
                    {
                        return Encoding.Default.GetString(dataBytes, 0, size);
                    }
                case EncodingMothord.Unicode:
                    {
                        return Encoding.Unicode.GetString(dataBytes, 0, size);
                    }
                case EncodingMothord.UTF8:
                    {
                        return Encoding.UTF8.GetString(dataBytes, 0, size);
                    }
                case EncodingMothord.ASCII:
                    {
                        return Encoding.ASCII.GetString(dataBytes, 0, size);
                    }
                default:
                    {
                        throw (new Exception("未定义的编码格式"));
                    }
            }

        }

        /// <summary> 
        /// 数据编码 
        /// </summary> 
        /// <param name="datagram">需要编码的报文</param> 
        /// <returns>编码后的数据</returns> 
        public virtual byte[] GetEncodingBytes(string datagram)
        {
            switch (_encodingMothord)
            {
                case EncodingMothord.Default:
                    {
                        return Encoding.Default.GetBytes(datagram);
                    }
                case EncodingMothord.Unicode:
                    {
                        return Encoding.Unicode.GetBytes(datagram);
                    }
                case EncodingMothord.UTF8:
                    {
                        return Encoding.UTF8.GetBytes(datagram);
                    }
                case EncodingMothord.ASCII:
                    {
                        return Encoding.ASCII.GetBytes(datagram);
                    }
                default:
                    {
                        throw (new Exception("未定义的编码格式"));
                    }
            }
        }

    }

    /// <summary> 
    /// 数据报文分析器,通过分析接收到的原始数据,得到完整的数据报文. 
    /// 继承该类可以实现自己的报文解析方法. 
    /// 通常的报文识别方法包括:固定长度,长度标记,标记符等方法 
    /// 本类的现实的是标记符的方法,你可以在继承类中实现其他的方法 
    /// </summary> 
    public class DatagramResolver
    {
        /// <summary> 
        /// 报文结束标记 
        /// </summary> 
        private string _endTag;

        /// <summary> 
        /// 返回结束标记 
        /// </summary> 
        public string EndTag
        {
            get
            {
                return _endTag;
            }
        }

        /// <summary> 
        /// 受保护的默认构造函数,提供给继承类使用 
        /// </summary> 
        protected DatagramResolver()
        {

        }

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="endTag">报文结束标记</param> 
        public DatagramResolver(string endTag)
        {
            if (endTag == null)
            {
                throw (new ArgumentNullException("结束标记不能为null"));
            }

            if (endTag == "")
            {
                throw (new ArgumentException("结束标记符号不能为空字符串"));
            }

            this._endTag = endTag;
        }

        /// <summary> 
        /// 解析报文 
        /// </summary> 
        /// <param name="rawDatagram">原始数据,返回未使用的报文片断, 
        /// 该片断会保存在Session的Datagram对象中</param> 
        /// <returns>报文数组,原始数据可能包含多个报文</returns> 
        public virtual string[] Resolve(ref string rawDatagram)
        {
            ArrayList datagrams = new ArrayList();

            //末尾标记位置索引 
            int tagIndex = -1;

            while (true)
            {
                tagIndex = rawDatagram.IndexOf(_endTag, tagIndex + 1);

                if (tagIndex == -1)
                {
                    break;
                }
                else
                {
                    //按照末尾标记把字符串分为左右两个部分                     
                    string newDatagram = rawDatagram.Substring(
                    0, tagIndex);

                    datagrams.Add(newDatagram);

                    if (tagIndex + _endTag.Length >= rawDatagram.Length)
                    {
                        rawDatagram = "";

                        break;
                    }

                    rawDatagram = rawDatagram.Substring(tagIndex + _endTag.Length,
                    rawDatagram.Length - newDatagram.Length - _endTag.Length);

                    //从开始位置开始查找 
                    tagIndex = 0;
                }
            }

            string[] results = new string[datagrams.Count];

            datagrams.CopyTo(results);

            return results;
        }
    }

    /// <summary> 
    /// 客户端与服务器之间的会话类 
    /// 会话类包含远程通讯端的状态,这些状态包括Socket,报文内容, 
    /// 客户端退出的类型(正常关闭,强制退出两种类型) 
    /// </summary> 
    public class Session : ICloneable
    {
        #region 字段

        /// <summary> 
        /// 会话ID 
        /// </summary> 
        private string _id;

        /// <summary> 
        /// 客户端发送到服务器的报文 
        /// 注意:在有些情况下报文可能只是报文的片断而不完整 
        /// </summary> 
        private string _datagram;

        /// <summary> 
        /// 客户端的Socket 
        /// </summary> 
        private Socket _cliSock;

        /// <summary> 
        /// 客户端的退出类型 
        /// </summary> 
        private ExitType _exitType;

        /// <summary> 
        /// 退出类型枚举 
        /// </summary> 
        public enum ExitType
        {
            NormalExit,
            ExceptionExit
        };

        #endregion

        #region 属性

        /// <summary> 
        /// 返回会话的ID 
        /// </summary> 
        public string ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary> 
        /// 存取会话的报文 
        /// </summary> 
        public string Datagram
        {
            get
            {
                return _datagram;
            }
            set
            {
                _datagram = value;
            }
        }

        /// <summary> 
        /// 获得与客户端会话关联的Socket对象 
        /// </summary> 
        public Socket ClientSocket
        {
            get
            {
                return _cliSock;
            }
        }

        /// <summary> 
        /// 存取客户端的退出方式 
        /// </summary> 
        public ExitType TypeOfExit
        {
            get
            {
                return _exitType;
            }

            set
            {
                _exitType = value;
            }
        }

        #endregion

        #region 方法

        /// <summary> 
        /// 使用Socket对象的Handle值作为HashCode,它具有良好的线性特征. 
        /// </summary> 
        /// <returns></returns> 
        public override int GetHashCode()
        {
            return (int)_cliSock.Handle;
        }

        /// <summary> 
        /// 返回两个Session是否代表同一个客户端 
        /// </summary> 
        /// <param name="obj"></param> 
        /// <returns></returns> 
        public override bool Equals(object obj)
        {
            Session rightObj = (Session)obj;

            return (int)_cliSock.Handle == (int)rightObj.ClientSocket.Handle;

        }

        /// <summary> 
        /// 重载ToString()方法,返回Session对象的特征 
        /// </summary> 
        /// <returns></returns> 
        public override string ToString()
        {
            string result = string.Format("Session:{0},IP:{1}",
            _id, _cliSock.RemoteEndPoint.ToString());

            //result.C 
            return result;
        }

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="cliSock">会话使用的Socket连接</param> 
        public Session(Socket cliSock)
        {
            Debug.Assert(cliSock != null);

            _cliSock = cliSock;

            _id = cliSock.Handle.ToString();
        }

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="cliSock">会话使用的Socket连接</param> 
        public Session(Socket cliSock, string id)
        {
            Debug.Assert(cliSock != null);

            _cliSock = cliSock;

            _id = id;
        }

        /// <summary> 
        /// 关闭会话 
        /// </summary> 
        public void Close()
        {
            Debug.Assert(_cliSock != null);
            try
            {
                //关闭数据的接受和发送 
                _cliSock.Shutdown(SocketShutdown.Both);

                //清理资源 
                _cliSock.Close();
            }
            catch (ObjectDisposedException ex)
            {                
                if (ex != null)
                {
                    ex = null;
                    //DoNothing; 
                }
            }

        }

        #endregion

        #region ICloneable 成员

        object System.ICloneable.Clone()
        {
            Session newSession = new Session(_cliSock);
            newSession.Datagram = _datagram;
            newSession.TypeOfExit = _exitType;

            return newSession;
        }

        #endregion
    }

    /// <summary> 
    /// 服务器程序的事件参数,包含了激发该事件的会话对象 
    /// </summary> 
    public class NetEventArgs : EventArgs
    {

        #region 字段

        /// <summary> 
        /// 客户端与服务器之间的会话 
        /// </summary> 
        private Session _client;

        #endregion

        #region 构造函数
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="client">客户端会话</param> 
        public NetEventArgs(Session client)
        {
            if (null == client)
            {
                throw (new ArgumentNullException());
            }

            _client = client;
        }


        public NetEventArgs()
        { }
        #endregion

        #region 属性

        /// <summary> 
        /// 获得激发该事件的会话对象 
        /// </summary> 
        public Session Client
        {
            get
            {
                return _client;
            }

        }

        #endregion

    }
}