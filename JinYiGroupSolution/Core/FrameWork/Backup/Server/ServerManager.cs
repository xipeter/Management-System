using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    /// <summary>
    /// 服务器端
    /// wolf 2009-3
    /// </summary>
    public class ServerManager :MarshalByRefObject
    {
       
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationid"></param>
        public void SetID(string applicationid)
        {
            this.applicationID = applicationid;
        }

        #region 事务

        public  void BeginTransaction()
        {
            //数据库重新开启连接
            OpenDB();
            //事务判断
            if (TransactionPool.GetTransaction(this.applicationID) == null)
            {
                TransactionPool.SetTransaction(this.applicationID, ConnectionPool.GetConnection(this.applicationID).BeginTransaction(System.Data.IsolationLevel.ReadCommitted));
                //必须在事务开始之后加上 
                //{0A5C1FD6-C6DF-46b1-9EA6-AAD4CA6D12F4}Neusoft.FrameWork.Server.ServerManager  里 把下面方法更新一下，解决DB2事务不能开启的问题
                //ConnectionPool.GetConnection(this.applicationID).GetType().GetProperty("TransactionState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(ConnectionPool.GetConnection(this.applicationID), 1, null);

                if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE)
                {
                    ConnectionPool.GetConnection(this.applicationID).GetType().GetProperty("TransactionState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(ConnectionPool.GetConnection(this.applicationID), 1, null);
                }
                else if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
                {
                    ConnectionPool.GetConnection(this.applicationID).GetType().GetProperty("TransactionState");
                }
            }

        }

        public System.Data.IDbTransaction GetTrans()
        {
            return TransactionPool.GetTransaction(this.applicationID);
        }

        public  void Commit()
        {
            try
            {
                TransactionPool.GetTransaction(this.applicationID).Commit();
            }
            catch (Exception ex)
            {
                Management.PublicTrans.log.WriteLog("Commit出错!" + ex.Message);
            }
            try
            {
                TransactionPool.GetTransaction(this.applicationID).Dispose();
                TransactionPool.RemoveTransaction(this.applicationID);
            }
            catch { }
            //数据库关闭连接处理
            CloseDB();
        }

        public  void Rollback()
        {
            try
            {
                TransactionPool.GetTransaction(this.applicationID).Rollback();

            }
            catch (Exception ex)
            {
                Management.PublicTrans.log.WriteLog("Rollback出错!" + ex.Message);
            }
            try
            {
                TransactionPool.GetTransaction(this.applicationID).Dispose();
                TransactionPool.RemoveTransaction(this.applicationID);
            }
            catch { }
            //数据库关闭连接处理
            CloseDB();

        }

        private  void OpenDB()
        {
            if (Pooling.OpenDB(this.applicationID) == -1)
                this.err = Pooling.Err;
        }

        private  void CloseDB()
        {
            Pooling.CloseDB(this.applicationID);
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.ArrayList GetSQL()
        {
            System.Collections.ArrayList alAll = new System.Collections.ArrayList();
            if (Neusoft.FrameWork.Management.Connection.Sql == null)
            {
                Neusoft.FrameWork.Management.Connection.Sql = new Neusoft.FrameWork.Management.Sql(ConnectionPool.GetConnection(this.applicationID));
            }
            if (Neusoft.FrameWork.Management.Connection.Sql.alSql == null)
            {
                return null;
            }
            alAll.Add(Neusoft.FrameWork.Management.Connection.Sql.alSql);
            alAll.Add(Neusoft.FrameWork.Management.Connection.Sql.table_name);
            return alAll;
        }

        
        public void SetOperation(Neusoft.FrameWork.Models.NeuObject obj)
        {
            OperationPool.SetOperation(this.applicationID, obj);
        }
        #endregion

        #region 错误
        string err;
        public string Err
        {
            get
            {
                getErr();
                return err;
            }
            set
            {
                this.err = value;
            }
        }
        string errCode;
        public string ErrCode
        {
            get
            {
                getErr();
                return errCode;
            }
            set
            {
                errCode = value;
            }
        }
        int dbErrCode = 0;
        public int DBErrCode
        {
            get
            {
                getErr();
                return dbErrCode;
            }
            set
            {
                dbErrCode = value;
            }
        }

        private void getErr()
        {
            try
            {
                if (db == null) return;
                this.err = db.Err;
                this.errCode = db.ErrCode;
                this.dbErrCode = db.DBErrCode;
            }
            catch { }
        }
        private void setDB(IDBServer db)
        {
            this.db = db;
            this.db.SetConnection(ConnectionPool.GetConnection(this.applicationID),TransactionPool.GetTransaction(this.applicationID));
            
        }
        IDBServer db = null;
        #endregion

        #region IDataBase 成员


        public Neusoft.FrameWork.Management.Sql Sql
        {
            get
            {
                return Neusoft.FrameWork.Management.Connection.Sql;
            }
            set
            {
                Neusoft.FrameWork.Management.Connection.Sql = value;
            }
        }

       
       
        public int ExecNoQuery(string strSql)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            Pooling.OpenDB(this.applicationID);
            int i = manager.ExecNoQuery(strSql);
            Pooling.CloseDB(this.applicationID);
            return i;
        }

        public System.Data.DataTable ExecQuery(string strSql)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            
            Pooling.OpenDB(this.applicationID);
            System.Data.DataTable i = manager.ExecQuery(strSql);
            Pooling.CloseDB(this.applicationID);
            return i;
        }


        public int InputBlob(string strSql, byte[] ImageData)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            Pooling.OpenDB(this.applicationID);
            int i = manager.InputBlob(strSql,ImageData);
            Pooling.CloseDB(this.applicationID);
            return i;
        }

        public byte[] OutputBlob(string strSql)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            Pooling.OpenDB(this.applicationID);
            byte[] i = manager.OutputBlob(strSql);
            Pooling.CloseDB(this.applicationID);
            return i;

        }

        public int InputLong(string strSql, string data)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            
            Pooling.OpenDB(this.applicationID);
            int i = manager.InputLong(strSql, data);
            Pooling.CloseDB(this.applicationID);
            return i;
        }

        public int ExecEvent(string strSql, ref string Return)
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            Pooling.OpenDB(this.applicationID);
            int i = manager.ExecEvent(strSql, ref Return);
            Pooling.CloseDB(this.applicationID);
            return i;
        }
       
        public DateTime GetDateTimeFromSysDateTime()
        {
            IDBServer manager = this.getDBManager();
            this.setDB(manager as IDBServer);
            Pooling.OpenDB(this.applicationID);
            DateTime i = manager.GetDateTimeFromSysDateTime();
            Pooling.CloseDB(this.applicationID);
            return i;
        }

        #endregion

        #region 私有
        string applicationID = "";
        private IDBServer getDBManager()
        {
            IDBServer manager = null;
            switch (Neusoft.FrameWork.Management.Connection.DBType)
            {
                case Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE:
                    manager = new DBOracle();
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.DB2:
                    manager = new DB2Access();
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.SQLSERVER:
                    manager = new DBSqlServer();
                    break;
                case Neusoft.FrameWork.Management.Connection.EnumDBType.OTHER:
                    manager = new DBOle();
                    break;
                default :
                    manager = new DBOracle();
                    break;
            }

            return manager;

        }
        #endregion



    }
}
