using System;
using System.Xml;//使用Xml类进行xmlDataSet的输出
using System.Data;
namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// Database 数据库管理类 
    /// con 需要传入
    /// sql 需要传入
    /// operator 需要传入
    /// wolf 2004-6
    /// </summary>
    [System.Serializable]
    public abstract class Database : FrameWork.Models.NeuManageObject, IDataBase
    {
        /// <summary>
        /// 设置详细年龄信息显示的边界值 即小于此设置值岁数的年龄，显示信息包括月、天
        /// </summary>
        public static int DetailAgeBoundry = 1;

        protected Neusoft.FrameWork.Models.NeuLog Logo;
        protected Neusoft.FrameWork.Models.NeuLog debugLogo;
        protected string ErrorException = "";
        private bool bDebug;
        protected string DebugSqlIndex = "Manager.Logo.GetDebug";
        protected string ErrorSqlIndex = "Manager.Logo.GetError";
        protected string DebugSql = "";
        protected string ErrorSql = "";
        protected IDataBase db = null;
        //protected Neusoft.NFC.Object.NeuManageObject obj = null;
        public Database()
        {
            //if (Neusoft.NFC.Management.Connection.Instance == null)
            //{
            //    this.Operator = Neusoft.NFC.Management.Connection.Operator;
            //    newDatabase("./err.log");
            //    return;
            //}

            //if (Neusoft.NFC.Management.Connection.Instance.GetType() == typeof(System.Data.OracleClient.OracleConnection))
            //{
            //    DBOracle dboracle = new DBOracle();
            //    db = dboracle as IDataBase;
            //    obj = dboracle as NFC.Object.NeuManageObject;
            //}
            //else if (Neusoft.NFC.Management.Connection.Instance.GetType() == typeof(System.Data.OleDb.OleDbConnection))
            //{
            //    DBOle dbole = new DBOle();
            //    db = dbole as IDataBase;
            //    obj = dbole as NFC.Object.NeuManageObject;
            //}
            //else if (Neusoft.NFC.Management.Connection.Instance.GetType() == typeof(Oracle.DataAccess.Client.OracleConnection))
            //{
            //    DBOracleAccess dbole = new DBOracleAccess();
            //    db = dbole as IDataBase;
            //    obj = dbole as NFC.Object.NeuManageObject;
            //}
            ////新增DB2数据库支持// {EE483CDD-A76C-4058-B0D2-8E5C7C7EAE54}
            //else if (Neusoft.NFC.Management.Connection.Instance.GetType() == typeof(IBM.Data.DB2.DB2Connection))
            //{
            //    DB2Access db2Access = new DB2Access();
            //    db = db2Access as IDataBase;
            //    obj = db2Access as NFC.Object.NeuManageObject;
            //}

            //db.con = Neusoft.NFC.Management.Connection.Instance;
            //db.Sql = Neusoft.NFC.Management.Connection.Sql;
            //obj.Operator = Neusoft.NFC.Management.Connection.Operator;
            //this.Operator = Neusoft.NFC.Management.Connection.Operator;
            db = new Server.DBManager() as IDataBase;
            newDatabase("./err.log");

        }

        /// <summary>
        /// 当前操作员
        /// </summary>
        public new FrameWork.Models.NeuObject Operator
        {
            get
            {
                if (base.Operator == null || base.Operator.ID =="")
                    return Neusoft.FrameWork.Management.Connection.Operator;
                return base.Operator; ;
            }
            set
            {
                base.Operator = value;
            }
        }
        ////{7F75F400-8180-485f-B968-E95E472FF9AA}
        ///// <summary>
        ///// 医院信息
        ///// </summary>
        //public new FrameWork.Models.NeuObject Hospital
        //{
        //    get
        //    {
        //        if (base.Hospital == null || string.IsNullOrEmpty(base.Hospital.ID))
        //        {
        //            return Neusoft.FrameWork.Management.Connection.Hospital;
        //        }
        //        return base.Hospital;
        //    }
        //    set
        //    {
        //        base.Hospital = value;
        //    }
        //}


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errLogoFileName">日志文件名</param>
        public Database(string errLogoFileName)
        {
            newDatabase(errLogoFileName);
        }
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
        }


        /// <summary>
        /// 加载内存 判断是否debug 非公开
        /// </summary>
        /// <param name="errLogoFileName">errLogoFileName</param>
        private void newDatabase(string errLogoFileName)
        {

            Logo = new Neusoft.FrameWork.Models.NeuLog(errLogoFileName);
            string debugLogoFileName = "./debugSql.log";
            if (System.IO.File.Exists(debugLogoFileName))
            {
                debugLogo = new Neusoft.FrameWork.Models.NeuLog(debugLogoFileName);
                bDebug = true;
            }
            else
            {
                bDebug = false;
            }

        }

        /// <summary>
        /// 转换sql语句
        /// 通过引用全局的sql语句类进行访问
        /// </summary>
        public Sql Sql
        {
            get
            {
                return db.Sql;
            }
            set
            {
                db.Sql = value;
            }
        }
        /// <summary>
        /// 设置sql
        /// </summary>
        /// <param name="sql"></param>
        public void SetSql(Sql sql)
        {
            this.Sql = sql;
        }

      

        #region 写日志

        /// <summary>
        /// 写错误日志
        /// </summary>
        public virtual void WriteErr()
        {
            this.Logo.WriteLog(this.GetType().ToString() + ":" + this.Err + this.ErrCode);
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

        #region IDataBase 成员
        

        /// <summary>
        /// 当前数据库连接
        /// </summary>
        public IDbConnection con
        {
            get
            {

                // TODO:  添加 Database.con getter 实现
                if (db == null)
                {
                    return null;


                }
                return db.con;
            }
            set
            {
                // TODO:  添加 Database.con setter 实现
                if (db == null || db.con != value)
                {
                    //if (value.GetType() == typeof(System.Data.OracleClient.OracleConnection))
                    //{

                    //    DBOracle dboracle = new DBOracle();
                    //    db = dboracle as IDataBase;
                    //    obj = dboracle as NFC.Object.NeuManageObject;
                    //}
                    //else if (value.GetType() == typeof(System.Data.OleDb.OleDbConnection))
                    //{
                    //    DBOle dbole = new DBOle();
                    //    db = dbole as IDataBase;
                    //    obj = dbole as NFC.Object.NeuManageObject;
                    //}
                    //else if (value.GetType() == typeof(Oracle.DataAccess.Client.OracleConnection))
                    //{
                    //    DBOracleAccess dbole = new DBOracleAccess();
                    //    db = dbole as IDataBase;
                    //    obj = dbole as NFC.Object.NeuManageObject;
                    //}
                    ////新增DB2支持{C39315D8-8484-4aa2-93E9-5C50C725EA69}
                    //else if (value.GetType() == typeof(IBM.Data.DB2.DB2Connection))
                    //{
                    //    DB2Access db2Access = new DB2Access();
                    //    db = db2Access as IDataBase;
                    //    obj = db2Access as NFC.Object.NeuManageObject;
                    //}
                    //END
                    db = new Server.DBManager()  as IDataBase;
                }
                db.con = value;
            }
        }
        /// <summary>
        /// 当前reader
        /// 记得用完关闭Reader
        /// </summary>
        public IDataReader Reader
        {
            get
            {
    
                
                return db.Reader;
            }
        }
        /// <summary>
        /// 执行Sql用TempReader执行
        /// DB2不允许执行
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecQueryByTempReader(string strSql)
        {
            OpenDB();
            int i = db.ExecQueryByTempReader(strSql);
            return i;
        }
        /// <summary>
        /// 临时的Reader
        /// </summary>
        public IDataReader TempReader
        {
            get
            {
               
                return db.TempReader;
            }
        }
        /// <summary>
        /// 设置当前事务
        /// </summary>
        /// <param name="Trans"></param>
        public void SetTrans(IDbTransaction Trans)
        {

            db.SetTrans(Trans);
            this.myTrans = Trans;
        }

        /// <summary>
        /// 事务
        /// </summary>
        private System.Data.IDbTransaction myTrans;
        /// <summary>
        /// 当前事务
        /// </summary>
        protected System.Data.IDbTransaction Trans
        {
            get
            {
                return this.myTrans;
            }
        }

        private void getErr()
        {
            this.Err = db.Err;
            this.ErrCode = db.ErrCode;
            this.DBErrCode = db.DBErrCode;
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="strConnectString"></param>
        /// <returns></returns>
        public int Connect(string strConnectString)
        {
            // TODO:  添加 Database.Connect 实现
            int i = db.Connect(strConnectString);
            this.getErr();
            return i;
        }
        /// <summary>
        /// 执行非查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecNoQuery(string strSql)
        {
            // TODO:  添加 Database.ExecNoQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecNoQuery(strSql);
            CloseDB();
            this.getErr();
            return i;
        }

        /// <summary>
        ///  执行非查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecNoQuery(string strSql, params string[] parms)
        {
            // TODO:  添加 Database.ExecNoQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecNoQuery(strSql, parms);
            CloseDB();
            this.getErr();
            return i;
        }

        /// <summary>
        /// 执行非查询Sql通过Sql索引
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecNoQueryByIndex(string index, params string[] parms)
        {
            string strSql = "";
            if (this.Sql.GetSql(index, ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            OpenDB();
            int i = this.ExecNoQuery(strSql, parms);
            CloseDB();
            this.getErr();
            return i;
        }
        /// <summary>
        ///  执行非查询sql	
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecQuery(string strSql)
        {
            // TODO:  添加 Database.ExecQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecQuery(strSql);
            this.getErr();
            return i;
        }
        /// <summary>
        ///  执行非查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecQuery(string strSql, params string[] parms)
        {
            // TODO:  添加 Database.ExecQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecQuery(strSql, parms);
            this.getErr();
            return i;
        }
        /// <summary>
        ///  执行查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDataSet"></param>
        /// <returns></returns>
        public int ExecQuery(string strSql, ref string strDataSet)
        {
            // TODO:  添加 Database.ExecQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecQuery(strSql, ref strDataSet);
            this.getErr();
            return i;
        }
       
        /// <summary>
        ///  执行查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDataSet"></param>
        /// <param name="strXSLFileName"></param>
        /// <returns></returns>
        public int ExecQuery(string strSql, ref string strDataSet, string strXSLFileName)
        {
            // TODO:  添加 Database.ExecQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecQuery(strSql, ref  strDataSet, strXSLFileName);
            this.getErr();
            return i;
        }
        /// <summary>
        ///  执行查询sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="DataSet"></param>
        /// <returns></returns>
        public int ExecQuery(string strSql, ref DataSet DataSet)
        {
            // TODO:  添加 Database.ExecQuery 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecQuery(strSql, ref  DataSet);
            this.getErr();
            return i;
        }
        /// <summary>
        /// 执行查询sql
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="dataSet"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecQuery(string[] indexes, ref DataSet dataSet, params string[] parms)
        {
            // TODO:  添加 Database.ExecQuery 实现
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
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            int i = this.ExecQuery(strSql, ref  dataSet);
            this.getErr();
            return i;
        }
        /// <summary>
        /// 执行查询sql
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dataSet"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecQuery(string index, ref DataSet dataSet, params string[] parms)
        {
            // TODO:  添加 Database.ExecQuery 实现
            string[] indexes = { index };
            int i = this.ExecQuery(indexes, ref  dataSet, parms);
            this.getErr();
            return i;
        }

        /// <summary>
        ///  执行查询sql通过sqlIndex
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecQueryByIndex(string index, params string[] parms)
        {
            // TODO:  添加 Database.ExecQuery 实现
            string strSql = "";
            if (this.Sql.GetSql(index, ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            int i = this.ExecQuery(strSql, parms);
            this.getErr();
            return i;
        }

        /// <summary>
        /// 执行sql返回一条记录信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public string ExecSqlReturnOne(string strSql)
        {
            // TODO:  添加 Database.ExecSqlReturnOne 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            string i = db.ExecSqlReturnOne(strSql);
            CloseDB();
            return i;
        }

        /// <summary>
        /// 执行sql返回一条记录信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="defaultstring"></param>
        /// <returns></returns>
        public string ExecSqlReturnOne(string strSql, string defaultstring)
        {
            // TODO:  添加 Database.ExecSqlReturnOne 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            string s= db.ExecSqlReturnOne(strSql, defaultstring);
            CloseDB();
            return s;
        }

        /// <summary>
        /// 执行输入Blob字段sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="ImageData"></param>
        /// <returns></returns>
        public int InputBlob(string strSql, byte[] ImageData)
        {
            // TODO:  添加 Database.InputBlob 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.InputBlob(strSql, ImageData);
            CloseDB();
            this.getErr();
            return i;
        }

        /// <summary>
        /// 读取Blob字段sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public byte[] OutputBlob(string strSql)
        {
            // TODO:  添加 Database.OutputBlob 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();       
            byte[] bb = db.OutputBlob(strSql);
            CloseDB();
            return bb;
        }

        /// <summary>
        /// 执行输入Long字段sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int InputLong(string strSql, string data)
        {
            // TODO:  添加 Database.InputLong 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();   
            int i = db.InputLong(strSql, data);
            CloseDB();
            this.getErr();
            return i;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Return"></param>
        /// <returns></returns>
        public int ExecEvent(string strSql, ref string Return)
        {
            // TODO:  添加 Database.ExecEvent 实现
            Neusoft.FrameWork.Public.TableConvert.ConverTable(ref strSql);
            OpenDB();
            int i = db.ExecEvent(strSql, ref  Return);
            CloseDB();
            this.getErr();
            return i;
        }

        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public string GetSysDateTime()
        {
            // TODO:  添加 Database.GetSysDateTime 实现
            OpenDB();
            string s= db.GetSysDateTime();
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetSysDateTime(string format)
        {
            // TODO:  添加 Database.GetSysDateTime 实现
            OpenDB();
            string s= db.GetSysDateTime(format);
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTimeFromSysDateTime()
        {
            // TODO:  添加 Database.GetDateTimeFromSysDateTime 实现
            
            OpenDB();
            DateTime s = db.GetDateTimeFromSysDateTime();
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得系统日期
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            // TODO:  添加 Database.GetSysDate 实现
            OpenDB();
            string s = db.GetSysDate();
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得系统日期
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetSysDate(string format)
        {
            // TODO:  添加 Database.GetSysDate 实现
            OpenDB();
            string s = db.GetSysDate(format);
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得系统日期，20050505
        /// </summary>
        /// <returns></returns>
        public string GetSysDateNoBar()
        {
            // TODO:  添加 Database.GetSysDateNoBar 实现
            OpenDB();
            string s = db.GetSysDateNoBar();
            CloseDB();
            return s;
        }

        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="GetSqlIndex">序列号Sql</param>
        /// <returns></returns>
        public string GetSequence(string GetSqlIndex)
        {
            // TODO:  添加 Database.GetSequence 实现
            string strSQL = "";
            if (this.Sql.GetSql(GetSqlIndex, ref strSQL) == -1)
            {
                this.Err = "SQL索引:" + GetSqlIndex + " 不存在！";
                return null;
            }
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取序列号" + GetSqlIndex + "时出错！" + this.Err;
                return null;
            }

            this.getErr();

            return strReturn;
        }

        /// <summary>
        /// 根据出生日期获得年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public string GetAge(DateTime birthday)
        {
            //取系统时间
            DateTime sysDate = this.GetDateTimeFromSysDateTime();
            return this.GetAge( birthday, sysDate, false );
        }

        /// <summary>
        /// 根据出生日期获得年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public string GetAge(DateTime birthday,bool isDetailFormat)
        {
            //取系统时间
            DateTime sysDate = this.GetDateTimeFromSysDateTime();

            return this.GetAge( birthday, sysDate, isDetailFormat );
        }

        
        /// <summary>
        /// 获得年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <param name="sysDate"></param>
        /// <returns></returns>
        public string GetAge(DateTime birthday, DateTime sysDate)
        {
            return this.GetAge( birthday, sysDate, false );
        }

        /// <summary>
        /// 获得年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <param name="sysDate"></param>
        /// <returns></returns>
        public string GetAge(DateTime birthday, DateTime sysDate,bool detailFormat)
        {
            // TODO:  添加 Database.GetAge 实现
            try
            {
                //取时间间隔
                TimeSpan s = new TimeSpan(sysDate.Ticks - birthday.Ticks);
                int iYear = 0, iMonth = 0, iDay = 0;
                if(sysDate.Year > birthday.Year)
                {
                    //生日月大于当前时间月
                    if (birthday.Month > sysDate.Month)
                    {
                        iYear = sysDate.Year - birthday.Year - 1;
                        if (birthday.Day > sysDate.Day)
                        {
                            iMonth = 11 + sysDate.Month - birthday.Month;
                            iDay = Function.NConvert.ToDateTime(sysDate.Year.ToString() + "-" + sysDate.Month.ToString() + "-" + "01").AddDays(-1).Day + sysDate.Day - birthday.Day;

                        }
                        else
                        {
                            iMonth = 12 + sysDate.Month - birthday.Month;
                            iDay = sysDate.Day - birthday.Day;
                        }
                        //return iYear.ToString() + "岁" + iMonth.ToString() + "月"+iDay.ToString()+"天";
                    }

                    else if (birthday.Month == sysDate.Month)
                    {
                        if (birthday.Day > sysDate.Day)
                        {
                            iYear = sysDate.Year - birthday.Year - 1;
                            iMonth = sysDate.Month - birthday.Month + 11;
                            iDay = Function.NConvert.ToDateTime(sysDate.Year.ToString() + "-" + sysDate.Month.ToString() + "-" + "01").AddDays(-1).Day + sysDate.Day - birthday.Day;
                        }
                        else
                        {
                            iYear = sysDate.Year - birthday.Year;
                            iMonth = sysDate.Month - birthday.Month;
                            iDay = sysDate.Day - birthday.Day;
                        }
                    }
                    else
                    {
                        iYear = sysDate.Year - birthday.Year;
                        if (birthday.Day > sysDate.Day)
                        {
                            iMonth = sysDate.Month - birthday.Month - 1;

                            iDay = Function.NConvert.ToDateTime(sysDate.Year.ToString() + "-" + sysDate.Month.ToString() + "-" + "01").AddDays(-1).Day + sysDate.Day - birthday.Day;

                        }
                        else
                        {
                            iMonth = sysDate.Month - birthday.Month;
                            iDay = sysDate.Day - birthday.Day;
                        }

                    }
                }
                else
                {
                    //if (s.TotalDays >= 365)
                    //{
                    //    //大于等于365天,返回年
                    //    iYear = (int)(s.TotalDays / 365);
                    //    return iYear.ToString() + "岁";
                    //}
                    //else if (s.TotalDays >= 30)
                    //{
                    //    //小于365天且大于等于30天,返回月
                    //    iYear = (int)(s.TotalDays / 30);
                    //    return iYear.ToString() + "月";
                    //}
                    //else
                    //{
                    //    //小于30天,返回天
                    //    iYear = (int)s.TotalDays + 1;
                    //    return iYear.ToString() + "天";
                    //}
                    if (birthday.Day > sysDate.Day)
                    {
                        iMonth = sysDate.Month - birthday.Month - 1;
                        iDay = Function.NConvert.ToDateTime(sysDate.Year.ToString() + "-" + sysDate.Month.ToString() + "-" + "01").AddDays(-1).Day + sysDate.Day - birthday.Day;
                    }
                    else
                    {
                        iMonth = sysDate.Month - birthday.Month;
                        iDay = sysDate.Day - birthday.Day;
                    }
                    
                }

                //{FA29D458-B9A3-493f-AAE8-86D593BEF724}  控制年龄返回信息格式 通过DetailAgeBoundry变量的设置 可控制详细年龄显示格式 该参数暂保留 不提供设置

                if (detailFormat == true)       //直接显示详细信息
                {
                    return iYear.ToString().PadLeft( 3, ' ' ) + "岁" + iMonth.ToString().PadLeft( 2, ' ' ) + "月" + iDay.ToString().PadLeft( 2, ' ' ) + "天";
                }

                if (iYear >= DetailAgeBoundry)  //大于详细边界显示年龄
                {
                    return iYear.ToString().PadLeft( 3, ' ' ) + "岁";
                }

                if (iYear == 0)     //岁为0
                {
                    if (iMonth == 0)    //月为0
                    {
                        if (iDay == 0)  //天为0
                        {
                            iDay = 1;
                        }
                        return iDay.ToString().PadLeft( 2, ' ' ) + "天";
                    }
                    else
                    {
                        if (iDay == 0)  //天为0 只显示月
                        {
                            return iMonth.ToString().PadLeft( 2, ' ' ) + "月";
                        }
                    }

                    return iMonth.ToString().PadLeft( 2, ' ' ) + "月" + iDay.ToString().PadLeft( 2, ' ' ) + "天";
                }
                else
                {
                    if (iMonth == 0)
                    {
                        if (iDay == 0)
                        {
                            return iYear.ToString().PadLeft( 3, ' ' ) + "岁";
                        }
                        else
                        {
                            return iYear.ToString().PadLeft( 3, ' ' ) + "岁" + iDay.ToString().PadLeft( 2, ' ' ) + "天";
                        }
                    }
                    else
                    {
                        if (iDay == 0)
                        {
                            return iYear.ToString().PadLeft( 3, ' ' ) + "岁" + iMonth.ToString().PadLeft( 2, ' ' ) + "月"; 
                        }
                    }

                    return iYear.ToString().PadLeft( 3, ' ' ) + "岁" + iMonth.ToString().PadLeft( 2, ' ' ) + "月" + iDay.ToString().PadLeft( 2, ' ' ) + "天";
                }
            }
            catch
            {
                return "";
            }
        }

        

        #endregion
        
        #region 数据库连接 操作

        private void OpenDB()
        {
            //Server.Function manager = new Server.Function();
            //Server.Function.Manager.OpenDB();
        }

        private void CloseDB()
        {
            //Server.Function manager = new Neusoft.NFC.Server.Function();
            //Server.Function.Manager.CloseDB();
        }
        #endregion

        
    }


}
