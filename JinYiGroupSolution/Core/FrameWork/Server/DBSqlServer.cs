using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public class DBSqlServer : IDBServer
    {
        #region IDBServer 成员

        public void SetConnection(System.Data.IDbConnection dbConnection, System.Data.IDbTransaction dbTrans)
        {
            throw new NotImplementedException();
        }

        public int ExecNoQuery(string strSql)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable ExecQuery(string strSql)
        {
            throw new NotImplementedException();
        }

        public int InputBlob(string strSql, byte[] ImageData)
        {
            throw new NotImplementedException();
        }

        public byte[] OutputBlob(string strSql)
        {
            throw new NotImplementedException();
        }

        public int InputLong(string strSql, string data)
        {
            throw new NotImplementedException();
        }

        public int ExecEvent(string strSql, ref string Return)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTimeFromSysDateTime()
        {
            throw new NotImplementedException();
        }

        public string Err
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ErrCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int DBErrCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IDBServer 成员

       
        #endregion
    }
}
