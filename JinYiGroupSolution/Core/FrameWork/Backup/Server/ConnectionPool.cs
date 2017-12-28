using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public static class ConnectionPool
    {
        private static Dictionary<string, System.Data.IDbConnection> connections = new Dictionary<string, System.Data.IDbConnection>();

        private static string error;

        static ConnectionPool()
        {

           
        }

        /// <summary>
        /// 获得连接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static System.Data.IDbConnection GetConnection(string id)
        {
            if (id == null || id.Length == 0)
            {
                error = "Id为空";
                return null;
            }

            System.Data.IDbConnection con = null;

            if (connections.ContainsKey(id))
            {
                return connections[id];
            }
            else
            {
                if( Neusoft.FrameWork.Management.Connection.MaxConnection == 0)//无连接限制
                {
                    con  = GetNewConnection();
                    connections.Add(id, con);
                }else
                {

                    if (connections.Count >= Neusoft.FrameWork.Management.Connection.MaxConnection) //大于连接数
                    {
                        foreach (string oldKey in connections.Keys)
                        {
                            if (connections[oldKey].State == System.Data.ConnectionState.Closed)
                            {
                                System.Data.IDbConnection oldConn = connections[oldKey];
                                connections.Remove(oldKey);
                                connections.Add(id, oldConn);
                                return oldConn;
                            }
                        }
                        con = GetNewTempConnection();
                        connections.Add(id, con);
                    }
                    else
                    {
                        con = GetNewConnection();
                        connections.Add(id, con);
                    }
                
                }
            }

            return con;


        }

        /// <summary>
        /// 移除连接
        /// </summary>
        /// <param name="id">移除连接数</param>
        public static int RemoveConnection(string id)
        {
            if (connections.ContainsKey(id))
            {
                
                System.Data.IDbConnection connection = connections[id];
                try
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
                catch { }
                connections.Remove(id);
                //GC.Collect();
            }

            return 0;
        }

        /// <summary>
        /// 清空连接
        /// </summary>
        public static void ClearConnections()
        {
            foreach (System.Data.IDbConnection cn in connections.Values)
            {
                cn.Dispose();
            }

            connections.Clear();
        }

       

        /// <summary>
        /// 错误
        /// </summary>
        public static string Error
        {
            get
            {
                return error;
            }
        }

       

        /// <summary>
        /// 获得连接
        /// </summary>
        /// <returns></returns>
        static System.Data.IDbConnection GetNewConnection()
        {

            System.Data.IDbConnection conn = null;
            switch (Neusoft.FrameWork.Management.Connection.DBType)
            {
                case Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE:
                    conn = new System.Data.OracleClient.OracleConnection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.DB2:
                    conn = new IBM.Data.DB2.DB2Connection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.SQLSERVER:
                    conn = new System.Data.SqlClient.SqlConnection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
                default:
                    conn = new System.Data.OleDb.OleDbConnection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
            }

            return conn;
        }
        static System.Data.IDbConnection GetNewTempConnection()
        {
            string connectString = Neusoft.FrameWork.Management.Connection.DataSouceString;
            if (connectString.ToLower().Trim().IndexOf("pooling=true") > 0)
            {
                connectString = connectString.Replace("True", "False");
                connectString = connectString.Replace("true", "False");
            }
            System.Data.IDbConnection conn = null;
            switch (Neusoft.FrameWork.Management.Connection.DBType)
            {
                case Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE:
                    conn = new System.Data.OracleClient.OracleConnection(connectString);
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.DB2:
                    conn = new IBM.Data.DB2.DB2Connection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.SQLSERVER:
                    conn = new System.Data.SqlClient.SqlConnection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
                default:
                    conn = new System.Data.OleDb.OleDbConnection(Neusoft.FrameWork.Management.Connection.DataSouceString);
                    break;
            }

            return conn;
        }
    }
}
