using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBM.Data.DB2;

namespace Neusoft.FrameWork.Server
{
    public class DB2Access : IDBServer
    {
        #region IDBServer 成员

        public DB2Access()
        {
            if (System.IO.File.Exists("debugSql.log"))
            {
                debugLogo = new Neusoft.FrameWork.Models.NeuLog("debugSql.log");
                bDebug = true;
            }
            else
            {
                bDebug = false;
            }
        }

        Neusoft.FrameWork.Models.NeuLog Logo = new Neusoft.FrameWork.Models.NeuLog("err.log");
        Neusoft.FrameWork.Models.NeuLog debugLogo = null;
        System.Data.IDbConnection dbConnection = null;
        System.Data.IDbTransaction dbTrans = null;
        private bool bDebug = false;

        public void SetConnection(System.Data.IDbConnection dbConnection, System.Data.IDbTransaction dbTrans)
        {
            this.dbConnection = dbConnection;
            this.dbTrans = dbTrans;
        }

        public int ExecNoQuery(string strSql)
        {
            System.Data.IDbCommand command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();

            command.CommandText = strSql + "";
            int i = 0;
            try
            {
                i = command.ExecuteNonQuery();
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                //if (ex.Code == 12571 || ex.Code == 3113 || ex.Code == 3114)
                //{
                //    while (this.Connect(this.con.ConnectionString) == -1)
                //    {
                //    }
                //    goto a;
                //}
                return -1;
            }
            if (i == 0)
            {
                this.Err = "没找到相应的行数！";
                this.ErrCode = strSql;
                this.WriteErr();
            }
            WriteDebug("执行无返回sql语句！" + strSql);
            return i;
        }

        public System.Data.DataTable ExecQuery(string strSql)
        {
            System.Data.IDbCommand command = null;
            System.Data.DataTable dt = new System.Data.DataTable();
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = strSql + "";
            try
            {

                DB2DataAdapter adapter = new DB2DataAdapter(command as DB2Command);
                adapter.Fill(dt);
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                ////if(ex.Code == 3113) 
                //if (ex.Code == 12571 || ex.Code == 3113 || ex.Code == 3114)
                //{
                //    while (this.Connect(this.con.ConnectionString) == -1)
                //    {
                //    }
                //    goto a;
                //}
                return null;
            }
            catch (Exception ex)
            {
                this.Err = "执行语句产生错误!" + ex.Message;

                this.ErrCode = strSql;
                this.WriteErr();
                return null;
            }

            WriteDebug("执行查询sql语句！" + strSql);
            return dt;
        }

        public int InputBlob(string strSql, byte[] ImageData)
        {
            DB2Command command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans as DB2Transaction;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = strSql + "";

            string strParam = "";
            int i = strSql.IndexOf(":", 0);
            if (i <= 0)
            {
                this.Err = "未指定参数！" + strSql;
                this.WriteErr();
                return -1;
            }
            //strParam = strSql.Substring(i + 1, 1);
            //{F94ACBC1-D0D1-4f70-AED8-8045E4062EF3}
            strParam = strSql.Substring(i, 2);
            DB2Parameter param = command.Parameters.Add(strParam, DB2Type.Blob);
            param.Direction = System.Data.ParameterDirection.Input;

            // Assign Byte Array to Oracle Parameter
            param.Value = ImageData;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                return -1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }

            return 0;
        }

        public byte[] OutputBlob(string strSql)
        {
            System.Data.IDbCommand command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = strSql + "";
            System.Data.IDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                return null;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            byte[] byteData = new byte[0];
            if (reader.Read())
            {
                // Create a byte array

                // fetch the value of Oracle parameter into the byte array
                //byteData = (byte[])(cmd.Parameters[0].Value);
                try
                {
                    byteData = (byte[])(reader[0]);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    reader.Close();
                    return null;
                }
            }
            else
            {
                reader.Close();
                return null;
            }
            return byteData;
        }

        public int InputLong(string strSql, string data)
        {
            DB2Command command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans as DB2Transaction;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = strSql + "";
            string strParam = "";
            int i = strSql.IndexOf(":", 0);
            if (i <= 0)
            {
                this.Err = "未指定参数！" + strSql;
                this.WriteErr();
                return -1;
            }
            strParam = strSql.Substring(i + 1, 1);

            DB2Parameter param = command.Parameters.Add(strParam, DB2Type.LongVarChar);
            param.Direction = System.Data.ParameterDirection.Input;

            // Assign Byte Array to Oracle Parameter
            param.Value = data;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                return -1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }

            return 0;
        }

        public int ExecEvent(string strSql, ref string Return)
        {
            DB2Command command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans as DB2Transaction;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.CommandText = "";

            string prcName = "";
            string[] prcParams = strSql.Split(',');
            try
            {
                prcName = prcParams[0];
                command.CommandText = prcName;
                //'22 varchar 30 double 33 int 6 DATETIME 
                for (int i = 1; i < prcParams.GetUpperBound(0); i = i + 4)
                {
                    DB2Parameter param = new DB2Parameter();
                    param.ParameterName = prcParams[i].Trim();
                    param.DB2Type = (DB2Type)int.Parse(prcParams[i + 1]);
                    param.Direction = (System.Data.ParameterDirection)int.Parse(prcParams[i + 2]);
                    if (param.Direction == System.Data.ParameterDirection.Input)
                    {
                        param.Value = prcParams[i + 3].Trim();
                        param.Size = 150;
                    }
                    else if (param.DB2Type == DB2Type.VarChar)
                    {
                        param.Size = 500;
                    }
                    command.Parameters.Add(param);
                }
                command.ExecuteNonQuery();
            }
            catch (DB2Exception ex)
            {
                this.Err = "执行产生错误!" + ex.Message;
                this.ErrCode = strSql;
                this.DBErrCode = ex.ErrorCode;
                this.WriteErr();
                return -1;
            }
            catch (Exception ex)
            {
                this.Err = "执行存储过程出错！" + strSql + ex.Message;
                this.WriteErr();
                return -1;
            }

            try
            {
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    if (command.Parameters[i].Direction == System.Data.ParameterDirection.Output)
                    {
                        Return = Return + "," + command.Parameters[i].Value;
                    }
                }
                Return = Return.Substring(1);
            }
            catch (Exception ex)
            {
                this.Err = "执行存储过程出错！" + strSql + ex.Message;
                this.WriteErr();
                return -1;
            }

            return 0;
        }

        public DateTime GetDateTimeFromSysDateTime()
        {
            System.Data.IDbCommand command = null;
            command = new DB2Command();
            command.Connection = this.dbConnection as DB2Connection;
            command.Transaction = dbTrans;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = "SELECT CURRENT TIMESTAMP FROM DUAL";
            DateTime dt = System.DateTime.Now;
            try
            {
                using (System.Data.IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dt = Neusoft.FrameWork.Function.NConvert.ToDateTime(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "执行语句产生错误!" + ex.Message;

                this.ErrCode = "SELECT CURRENT TIMESTAMP FROM DUAL";
                this.WriteErr();
                return dt;
            }

            WriteDebug("执行查询sql语句！" + "SELECT CURRENT TIMESTAMP FROM DUAL");

            return dt;
        }
        private string err;
        private string errCode;
        private int dbErrCode;
        public string Err
        {
            get
            {
                return err;
            }
            set
            {
                err = value;
            }
        }

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

        #endregion

        #region IDBServer 成员

        /// <summary>
        /// 写错误日志
        /// </summary>
        public virtual void WriteErr()
        {
            this.Logo.WriteLog(this.GetType().ToString() + ":" + this.Err + ":" + this.ErrCode);

            if (bDebug)
            {
                this.debugLogo.WriteLog("Error:" + this.GetType().ToString() + ":" + this.Err + this.ErrCode);

            }
        }
        /// <summary>
        /// 写调试日志
        /// </summary>
        /// <param name="strDebugInfo"></param>
        public virtual void WriteDebug(string strDebugInfo)
        {
            if (bDebug)
            {
                this.debugLogo.WriteLog("Debug:" + this.GetType().ToString() + ":" + strDebugInfo);

            }

        }


        #endregion
    }
}
