using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public interface IDBServer
    {
      
        void SetConnection(System.Data.IDbConnection dbConnection, System.Data.IDbTransaction dbTrans);
        
        int ExecNoQuery(string strSql);

        System.Data.DataTable ExecQuery(string strSql);


        int InputBlob(string strSql, byte[] ImageData);


        byte[] OutputBlob(string strSql);


        int InputLong(string strSql, string data);


        int ExecEvent(string strSql, ref string Return);


        DateTime GetDateTimeFromSysDateTime();

        string Err
        {
            get;
            set;

        }
        string ErrCode
        {
            get;
            set;

        }
        int DBErrCode
        {
            get;
            set;
        }
       
    }
}
