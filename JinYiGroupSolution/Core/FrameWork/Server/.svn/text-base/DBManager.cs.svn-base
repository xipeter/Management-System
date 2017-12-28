using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public class DBManager:Management.IDataBase
    {
       
        #region IDataBase 成员

        #region Err handle
        string err;
        public string Err
        {
            get
            {
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
                return dbErrCode;
            }
            set
            {
                dbErrCode = value;
            }
        }

        public System.Data.IDbConnection con
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public Neusoft.FrameWork.Management.Sql Sql
        {
            get
            {
                return Neusoft.FrameWork.Management.Connection.Sql;
            }
            set
            {
                
            }
        }

        private void getErr(ServerManager manager)
        {
            this.Err = manager.Err;
            this.errCode = manager.ErrCode;
            this.dbErrCode = manager.DBErrCode;
        }
        #endregion
        private DBReader reader = null;
        private DBReader tempReader = null;
        public System.Data.IDataReader Reader
        {
            get { return reader; }
        }

        public System.Data.IDataReader TempReader
        {
            get { return tempReader; }
        }

        public void SetTrans(System.Data.IDbTransaction Trans)
        {
            return;
        }

        public int Connect(string strConnectString)
        {
            return 0;
        }

        public int ExecNoQuery(string strSql)
        {

            int i = 0;
            
            i = Function.Manager.ExecNoQuery(strSql);
            if (i <= 0)
            {
                getErr(Function.Manager);
            }
            return i;
        }

        public int ExecNoQuery(string strSql, params string[] parms)
        {
            string sReturn;
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out sReturn, parms) == -1)
            {
                this.Err = "参数不对./n " + strSql;
                return -1;
            }
            return this.ExecNoQuery(sReturn);
        }

        public int ExecQuery(string strSql)
        {
            System.Data.DataTable dt =  Function.Manager.ExecQuery(strSql);
            reader = new DBReader(dt);
            if (dt == null)
            {
                getErr(Function.Manager);
                return -1;
            }

            return dt.Rows.Count;
        }

        public int ExecQuery(string strSql, params string[] parms)
        {
            string sReturn;
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out sReturn, parms) == -1)
            {
                this.Err = "参数不对./n " + strSql;
                return -1;
            }
            return this.ExecQuery(sReturn);
        }

        public int ExecQuery(string strSql, ref string strDataSet)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.DataTable dt = Function.Manager.ExecQuery(strSql);
            reader = new DBReader(dt);
            if (dt == null)
            {
                getErr(Function.Manager);
                return -1;
            }
            ds.Tables.Add(dt);
            strDataSet = ds.GetXml();
            return dt.Rows.Count;
        }

        public int ExecQueryByTempReader(string strSql)
        {
            System.Data.DataTable dt = Function.Manager.ExecQuery(strSql);
            tempReader = new DBReader(dt);
            if (dt == null)
            {
                getErr(Function.Manager);
                return -1;
            }

            return dt.Rows.Count;
        }

        public int ExecQuery(string strSql, ref string strDataSet, string strXSLFileName)
        {
            return 0;
        }

        public int ExecQuery(string strSql, ref System.Data.DataSet DataSet)
        {
            DataSet = new System.Data.DataSet();
            System.Data.DataTable dt = Function.Manager.ExecQuery(strSql);
            reader = new DBReader(dt);
            if (dt == null)
            {
                getErr(Function.Manager);
                return -1;
            }
            DataSet.Tables.Add(dt);
            return dt.Rows.Count;
        }

        public int ExecQuery(string[] indexes, ref System.Data.DataSet dataSet, params string[] parms)
        {
            string strSql = "";  //获得SELECT语句

            if (indexes.Length == 0)
            {
                this.Err = "无效的参数：sql索引数组indexes不能为空";
                return -1;
            }

            //取SELECT语句
            foreach (string index in indexes)
            {
                string s = "";
                if (this.Sql.GetSql(index, ref s) == -1)
                {
                    this.Err = "没有找到" + index + "字段!";
                    return -1;
                }

                strSql = strSql + " " + s;
            }

            //根据参数parms格式化sql语句。
            try
            {
                strSql = string.Format(strSql, parms);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecQuery(strSql, ref  dataSet);
           
        }

        public int ExecQuery(string index, ref System.Data.DataSet dataSet, params string[] parms)
        {
            string[] indexes = { index };
            return this.ExecQuery(indexes, ref  dataSet, parms);
            
        }

        public string ExecSqlReturnOne(string strSql)
        {
            return this.ExecSqlReturnOne(strSql, "-1");
        }

        public string ExecSqlReturnOne(string strSql, string defaultstring)
        {
            System.Data.DataTable dt = Function.Manager.ExecQuery(strSql);
            if (dt == null)
            {
                getErr(Function.Manager);
                return defaultstring;
            }
            if (dt.Rows.Count <= 0) return defaultstring;

            return dt.Rows[0][0].ToString();
        }

        public int InputBlob(string strSql, byte[] ImageData)
        {
            return Function.Manager.InputBlob(strSql, ImageData);
        }

        public byte[] OutputBlob(string strSql)
        {
            return Function.Manager.OutputBlob(strSql);
        }

        public int InputLong(string strSql, string data)
        {
            return Function.Manager.InputLong(strSql, data);
        }

        public int ExecEvent(string strSql, ref string Return)
        {
            return Function.Manager.ExecEvent(strSql,ref Return);
        }

        public string GetSysDateTime()
        {
            return this.GetDateTimeFromSysDateTime().ToString();
        }

        public string GetSysDateTime(string format)
        {
            return this.GetDateTimeFromSysDateTime().ToString(format);
        }

        public DateTime GetDateTimeFromSysDateTime()
        {
            return Function.Manager.GetDateTimeFromSysDateTime();
        }

        public string GetSysDate()
        {
            return this.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd");
        }

        public string GetSysDate(string format)
        {
            return this.GetDateTimeFromSysDateTime().ToString(format);
        }

        public string GetSysDateNoBar()
        {
            return this.GetDateTimeFromSysDateTime().ToString("yyyyMMdd");
        }

        #endregion
    }
}
