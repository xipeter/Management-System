using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.File
{
    /// <summary>
    /// GetFile 的摘要说明。
    /// 获得文件
    /// </summary>
    public class DataFile : Neusoft.FrameWork.Management.Database
    {
        public DataFile(string type)
            : base()
        {
            try
            {
                dtParam = this.ParamManager.Get(type) as Neusoft.HISFC.Models.File.DataFileParam;
                if (dtParam == null) return;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return;
            }
        }
        public DataFile()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Neusoft.HISFC.BizLogic.File.DataFileParam ParamManager = new Neusoft.HISFC.BizLogic.File.DataFileParam();
        public Neusoft.HISFC.BizLogic.File.DataFileInfo FileManager = new Neusoft.HISFC.BizLogic.File.DataFileInfo();
        private Neusoft.HISFC.Models.File.DataFileParam dtParam = null;
        private Neusoft.HISFC.Models.File.DataFileInfo dtFile = null;

        #region 属性
        /// <summary>
        /// 当前文件列表
        /// </summary>
        public ArrayList alFiles;
        /// <summary>
        /// 当前模板列表
        /// </summary>
        public ArrayList alModuals;

        /// <summary>
        /// 先设置显示类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int SetType(string type)
        {
            try
            {
                dtParam = this.ParamManager.Get(type) as Neusoft.HISFC.Models.File.DataFileParam;
                if (dtParam == null) return -1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 获得摸板
        /// </summary>
        /// <returns></returns>
        public int GetModuals(bool isAll)
        {
            try
            {

                alModuals = FileManager.GetList(dtParam, 1, isAll);
                return alModuals.Count;
            }
            catch { return -1; }
        }
        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetFiles(params string[] param)
        {
            try
            {
                this.dtFile = new Neusoft.HISFC.Models.File.DataFileInfo();
                this.dtFile.Param = (Neusoft.HISFC.Models.File.DataFileParam)this.dtParam.Clone();
                this.dtFile.Param.ID = string.Format(this.dtParam.ID, param);
                this.dtFile.Param.Type = this.dtParam.Type;
                alFiles = FileManager.GetList(this.dtFile.Param);
                return alFiles.Count;
            }
            catch { return -1; }
        }
        /// <summary>
        /// 获得参数
        /// </summary>
        public Neusoft.HISFC.Models.File.DataFileParam DataFileParam
        {
            get
            {
                if (this.dtParam == null) this.dtParam = new Neusoft.HISFC.Models.File.DataFileParam();
                return this.dtParam;
            }
            set
            {
                this.dtParam = value;
            }
        }
        /// <summary>
        /// 获得文件信息
        /// </summary>
        public Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo
        {
            get
            {
                if (this.dtFile == null) this.dtFile = new Neusoft.HISFC.Models.File.DataFileInfo();
                return this.dtFile;
            }
            set
            {
                this.dtFile = value;
            }
        }


        #endregion

        #region 节点操作
        /// <summary>
        /// 保存结点到数据库
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="dt"></param>
        /// <param name="ParentText"></param>
        /// <param name="NodeText"></param>
        /// <param name="NodeValue"></param>
        /// <returns></returns>
        public int SaveNodeToDataStore(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string ParentText, string NodeText, string NodeValue)
        {
            string strSql = "";
            string sql = "";

            if (this.Sql.GetSql("Management.DataFile.Select", ref strSql) == -1) return -1;
            try
            {
                Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, dt.Name, dt.Index1, dt.Index2, ParentText, NodeText, NodeValue, this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = "Management.DataFile.Select付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            if (this.ExecQuery(sql) == -1) return -1;
            if (this.Reader.Read())//有记录－执行更新
            {
                if (NodeValue == this.Reader[0].ToString())//相同不变
                {
                    this.Reader.Close();
                    return 0;
                }
                else
                {
                    if (this.Sql.GetSql("Management.DataFile.UpdateToDataStore", ref strSql) == -1) return -1;
                }
            }
            else//无记录－执行插入
            {
                if (this.Sql.GetSql("Management.DataFile.InsertToDataStore", ref strSql) == -1) return -1;
            }
            try
            {
                Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, dt.Name, dt.Index1, dt.Index2, ParentText, NodeText, NodeValue, this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 删除结点　
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int DeleteAllNodeFromDataStore(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt)
        {
            string strSql = "", sql = "";
            if (this.Sql.GetSql("Management.DataFile.DeleteAllNodeFromDataStore", ref strSql) == -1) return -1;
            try
            {
                sql = string.Format(strSql, Table, dt.ID);
            }
            catch (Exception ex)
            {
                this.Err = "DeleteNode付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 获得节点内容
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="inpatientNo"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetNodeValueFormDataStore(string Table, string inpatientNo, string nodeName)
        {
            string strSql = "", sql = "";
            if (this.Sql.GetSql("Management.DataFile.GetNodeValueFormDataStore", ref strSql) == -1) return "-1";
            try
            {
                sql = string.Format(strSql, Table, inpatientNo, nodeName);
            }
            catch (Exception ex)
            {
                this.Err = "GetNodeValueFormDataStore付值时候出错！" + ex.Message;
                this.WriteErr();
                return "-1";
            }
            return this.ExecSqlReturnOne(sql);
        }
        #endregion
        #region 日期节点
        public string GetDateNodeValueFormDataStoreByIndex(string Table, string inpatientNo, string Name, string NodeName, DateTime date, string index)
        {
            string strSql = "", sql = "";
            if (this.Sql.GetSql("Management.DataFile.GetDateNodeValueFormDataStoreByIndex", ref strSql) == -1) return "-1";
            try
            {
                sql = string.Format(strSql, Table, inpatientNo, Name, NodeName, date.ToString("yyyy-MM-dd"), index);
            }
            catch (Exception ex)
            {
                this.Err = "GetDateNodeValueFormDataStoreByIndex付值时候出错！" + ex.Message;
                this.WriteErr();
                return "-1";
            }
            return this.ExecSqlReturnOne(sql);
        }
        /// <summary>
        /// 获得节点内容
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="inpatientNo"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetDateNodeValueFormDataStoreByTime(string Table, string inpatientNo, string Name, string NodeName, DateTime date)
        {
            string strSql = "", sql = "";
            if (this.Sql.GetSql("Management.DataFile.GetDateNodeValueFormDataStoreByTime", ref strSql) == -1) return "-1";
            try
            {
                sql = string.Format(strSql, Table, inpatientNo, Name, NodeName, date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                this.Err = "GetDateNodeValueFormDataStoreByTime付值时候出错！" + ex.Message;
                this.WriteErr();
                return "-1";
            }
            return this.ExecSqlReturnOne(sql);
        }

      /// <summary>
      /// 删除此病人这个时间点的护理记录相关的所有数据
      /// </summary>
      /// <param name="Table"></param>
      /// <param name="dt"></param>
      /// <param name="recordtime"></param>
      /// <returns></returns>
        public int DelDataStoreVitalSignByIndex1OneTime(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, DateTime recordtime)
        {
            string strSql = "";
            string sql = "";
            if (this.Sql.GetSql("Management.DataFile.DelDataStoreVitalSignByIndex1OneTime", ref strSql) == -1) return -1;
            try
            {
                Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, dt.DataType, dt.Index1, this.Operator.ID, recordtime);
            }
            catch (Exception ex)
            {
                this.Err = "DelNodeToDataStore删除时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }
       /// <summary>
        /// 删除此病人的体温单相关的所有数据
       /// </summary>
       /// <param name="Table"></param>
       /// <param name="dt"></param>
       /// <returns></returns>
        public int DelDataStoreVitalSignByIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt)
        {
            string strSql = "";
            string sql = "";
            if (this.Sql.GetSql("Management.DataFile.DelDateDataStoreByIndex", ref strSql) == -1) return -1;
            try
            {
                Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, dt.DataType, dt.Index1, this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = "DelNodeToDataStore删除时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 保存结点到数据库
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="dt"></param>
        /// <param name="Name">病历名称</param>
        /// <param name="nodeName">节点</param>
        /// <param name="date">日期</param>
        /// <param name="index">节点索引</param>
        /// <param name="NodeValue"></param>
        /// <returns></returns>
        public int SaveNodeToDateDataStoreByInsertIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string index, string NodeValue, string Unit)
        {
            string strSql = "";
            string sql = "";
                if (this.Sql.GetSql("Management.DataFile.InsertToDateDataStore", ref strSql) == -1) return -1;
                try
                {
                    Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, Name, dt.Index1, dt.Index2, nodeName, nodeName, date.ToString("yyyy-MM-dd HH:mm:ss"), index, NodeValue, this.Operator.ID, Unit);
                }
                catch (Exception ex)
                {
                    this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                    this.WriteErr();
                    return -1;
                }
            
            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }


       /// <summary>
        /// 取出此病人的所有体温单数据
       /// </summary>
       /// <param name="Table"></param>
       /// <param name="datatype"></param>
       /// <param name="inpatientNo"></param>
       /// <returns></returns>
        public Hashtable QueryDataStoreVitalSignByIndex1(string Table, string datatype, string inpatientNo)
        {
            Hashtable DataStoreVitalSignHashTable = new Hashtable();
            string strSql = "";
            if (this.Sql.GetSql("Management.DataFile.QueryDataStoreVitalSignByIndex1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, Table, datatype, inpatientNo);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return null;
            }

            if (this.ExecQuery(strSql) == -1) return null;
            Neusoft.HISFC.Models.Nurse.DataStoreVitalSign DataStoreVitalSign = null;
            ArrayList recordDateList = new ArrayList();
            ArrayList AllDateList = new ArrayList();
            while (this.Reader.Read())
            {
                DataStoreVitalSign = new Neusoft.HISFC.Models.Nurse.DataStoreVitalSign();

                DataStoreVitalSign.NodeName = this.Reader[0].ToString();
                DataStoreVitalSign.NodeValue=this.Reader[1].ToString();
                DataStoreVitalSign.RecordDate = (DateTime) this.Reader[2];
                if (DataStoreVitalSign.NodeName == "检查时间")
                {
                    recordDateList.Add(DataStoreVitalSign.RecordDate);
                }
                AllDateList.Add(DataStoreVitalSign);
              
            }

            this.Reader.Close();
            DataStoreVitalSignHashTable.Add("AllDateList", AllDateList);
            DataStoreVitalSignHashTable.Add("recordDateList", recordDateList);
            return DataStoreVitalSignHashTable;
        }
        /// <summary>
        /// 数据库中取出此病人的一条护理记录
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="datatype"></param>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public ArrayList QueryDataStoreVitalSignByIndex1OneTime(string Table, string datatype, string inpatientNo, DateTime recorddate)
        {
            ArrayList DataStoreVitalSignArrayList = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Management.DataFile.QueryDataStoreVitalSignByIndex1OneTime", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, Table, datatype, inpatientNo, recorddate);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return null;
            }

            if (this.ExecQuery(strSql) == -1) return null;
            Neusoft.HISFC.Models.Nurse.DataStoreVitalSign DataStoreVitalSign = null;
            while (this.Reader.Read())
            {
                DataStoreVitalSign = new Neusoft.HISFC.Models.Nurse.DataStoreVitalSign();

                DataStoreVitalSign.NodeName = this.Reader[0].ToString();
                DataStoreVitalSign.NodeValue = this.Reader[1].ToString();
                DataStoreVitalSign.RecordDate = (DateTime)this.Reader[2];

                DataStoreVitalSignArrayList.Add(DataStoreVitalSign);

            }

            this.Reader.Close();
            return DataStoreVitalSignArrayList;
        }
      /// <summary>
      /// 数据库中取出病人集合的所有记录时间记录
      /// </summary>
      /// <param name="Table"></param>
      /// <param name="datatype"></param>
      /// <param name="nodename"></param>
      /// <param name="patientids"></param>
      /// <returns></returns>
        public ArrayList QueryDataStoreVitalSignByRecordDate(string Table, string datatype, string nodename, string patientids)
        {
            ArrayList DataStoreVitalSignArrayList = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Management.DataFile.QueryDataStoreVitalSignByRecordDate", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, Table, datatype, nodename, patientids);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return null;
            }

            if (this.ExecQuery(strSql) == -1) return null;
            Neusoft.HISFC.Models.Nurse.DataStoreVitalSign DataStoreVitalSign = null;
            while (this.Reader.Read())
            {
                DataStoreVitalSign = new Neusoft.HISFC.Models.Nurse.DataStoreVitalSign();

                DataStoreVitalSign.NodeName = this.Reader[0].ToString();
                DataStoreVitalSign.NodeValue = this.Reader[1].ToString();
                DataStoreVitalSign.RecordDate = (DateTime)this.Reader[2];

                DataStoreVitalSignArrayList.Add(DataStoreVitalSign);

            }

            this.Reader.Close();
            return DataStoreVitalSignArrayList;
        }
        /// <summary>
        /// 取出一个时间点下相关病人集合的所有体温单相关节点记录
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="datatype"></param>
        /// <param name="nodename"></param>
        /// <param name="patientids"></param>
        /// <returns></returns>
        public Hashtable QueryDataStoreVitalSignByAllIndex1Data(string Table, string datatype, string nodename, string patientids, string recorddate)
        {
            Hashtable DataStoreVitalSignHashtable = new Hashtable();
            string strSql = "";
            if (this.Sql.GetSql("Management.DataFile.QueryDataStoreVitalSignByAllIndex1Data", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, Table, datatype, nodename, patientids,recorddate);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return null;
            }

            if (this.ExecQuery(strSql) == -1) return null;
            Neusoft.HISFC.Models.Nurse.DataStoreVitalSign DataStoreVitalSign = null;
            while (this.Reader.Read())
            {
                DataStoreVitalSign = new Neusoft.HISFC.Models.Nurse.DataStoreVitalSign();

                DataStoreVitalSign.NodeName = this.Reader[0].ToString();
                DataStoreVitalSign.NodeValue = this.Reader[1].ToString();
                DataStoreVitalSign.RecordDate = (DateTime)this.Reader[2];
                DataStoreVitalSign.Index1 = this.Reader[3].ToString();

                //将得到的列表进行数据整理
                if (DataStoreVitalSignHashtable.ContainsKey(DataStoreVitalSign.Index1))
                {
                    ArrayList DataStoreVitalSignArrayList = (ArrayList)DataStoreVitalSignHashtable[DataStoreVitalSign.Index1];
                    DataStoreVitalSignArrayList.Add(DataStoreVitalSign);
                    DataStoreVitalSignHashtable[DataStoreVitalSign.Index1] = DataStoreVitalSignArrayList;
                }
                else
                {
                    ArrayList DataStoreVitalSignArrayListnew = new ArrayList();
                    DataStoreVitalSignArrayListnew.Add(DataStoreVitalSign);
                    DataStoreVitalSignHashtable[DataStoreVitalSign.Index1] = DataStoreVitalSignArrayListnew;
                }
            }

            this.Reader.Close();



            return DataStoreVitalSignHashtable;
        }
        /// <summary>
        /// 保存结点到数据库
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="dt"></param>
        /// <param name="Name">病历名称</param>
        /// <param name="nodeName">节点</param>
        /// <param name="date">日期</param>
        /// <param name="index">节点索引</param>
        /// <param name="NodeValue"></param>
        /// <returns></returns>
        public int SaveNodeToDateDataStoreByIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string index, string NodeValue, string Unit)
        {
            string strSql = "";
            string sql = "";
            string strReturn = this.GetDateNodeValueFormDataStoreByIndex(Table, dt.Index1, Name, nodeName, date, index);
            if (strReturn != "-1")
            {
                if (NodeValue == strReturn)//相同不变
                {
                    return 0;
                }
                else
                {
                    if (this.Sql.GetSql("Management.DataFile.UpdateToDateDataStoreByIndex", ref strSql) == -1) return -1;
                    try
                    {
                        Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, Name, dt.Index1, dt.Index2, "", nodeName, date.ToString("yyyy-MM-dd"), index, NodeValue, this.Operator.ID);
                    }
                    catch (Exception ex)
                    {
                        this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                        this.WriteErr();
                        return -1;
                    }
                }
            }
            else//无记录－执行插入
            {
                if (this.Sql.GetSql("Management.DataFile.InsertToDateDataStore", ref strSql) == -1) return -1;
                try
                {
                    Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, Name, dt.Index1, dt.Index2, nodeName, nodeName, date.ToString("yyyy-MM-dd HH:mm:ss"), index, NodeValue, this.Operator.ID, Unit);
                }
                catch (Exception ex)
                {
                    this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                    this.WriteErr();
                    return -1;
                }
            }
            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 保存结点到数据库
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="dt"></param>
        /// <param name="Name">病历名称</param>
        /// <param name="nodeName">节点</param>
        /// <param name="date">日期</param>
        /// <param name="index">节点索引</param>
        /// <param name="NodeValue"></param>
        /// <returns></returns>
        public int SaveNodeToDateDataStoreByTime(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string NodeValue, string Unit)
        {
            string strSql = "";
            string sql = "";
            string strReturn = this.GetDateNodeValueFormDataStoreByTime(Table, dt.Index1, Name, nodeName, date);
            if (strReturn != "-1")
            {
                if (NodeValue == strReturn)//相同不变
                {
                    return 0;
                }
                else
                {
                    if (this.Sql.GetSql("Management.DataFile.UpdateToDateDataStoreByTime", ref strSql) == -1) return -1;
                    try
                    {
                        Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, Name, dt.Index1, dt.Index2, "", nodeName, date.ToString("yyyy-MM-dd HH:mm:ss"), NodeValue, Unit, this.Operator.ID);
                    }
                    catch (Exception ex)
                    {
                        this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                        this.WriteErr();
                        return -1;
                    }
                }
            }
            else//无记录－执行插入
            {
                if (this.Sql.GetSql("Management.DataFile.InsertToDateDataStore", ref strSql) == -1) return -1;
                try
                {
                    Neusoft.FrameWork.Public.String.FormatString(strSql, out sql, Table, dt.ID, dt.Type, dt.DataType, Name, dt.Index1, dt.Index2, "", nodeName, date.ToString("yyyy-MM-dd HH:mm:ss"), "", NodeValue, Unit, this.Operator.ID,Unit);
                }
                catch (Exception ex)
                {
                    this.Err = "SaveNodeToDataStore付值时候出错！" + ex.Message;
                    this.WriteErr();
                    return -1;
                }
            }
            try
            {
                this.Reader.Close();
            }
            catch { }
            return this.ExecNoQuery(sql);
        }
        #endregion 日期节点操作

        #region 大字段操作

        /// <summary>
        /// 将文件导入到数据库中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileData">输入的文件数据</param>
        /// <returns></returns>
        public int ImportToDatabase(Neusoft.HISFC.Models.File.DataFileInfo dt, byte[] fileData)
        {
            string strSql = "", sql = "";
            if (dt.ID == null || dt.ID == "") return -1;
            if (dt.Type.Trim() == "0")//数据
            {
                if (this.Sql.GetSql("Management.DataFile.ImportToDatabase.byte", ref strSql) == -1) return -1;
            }
            else if (dt.Type.Trim() == "1") //模板
            {
                if (this.Sql.GetSql("Management.DataFile.ImportToDatabase.Modual.byte", ref strSql) == -1) return -1;
            }
            else
            {
                this.Err = "未知文件类型";
                return -1;
            }

            try
            {
                sql = string.Format(strSql, dt.ID);
            }
            catch (Exception ex)
            {
                this.Err = "ImportToDatabase付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.InputBlob(sql, fileData);
        }

        /// <summary>
        /// 输出文件 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public int ExportFromDatabase(Neusoft.HISFC.Models.File.DataFileInfo dt, ref byte[] fileData)
        {
            string strSql = "", sql = "";
            if (dt.ID == null || dt.ID == "") return -1;

            if (dt.Type.Trim() == "0")//数据
            {
                if (this.Sql.GetSql("Management.DataFile.ExportFromDatabase.byte", ref strSql) == -1) return -1;
            }
            else if (dt.Type.Trim() == "1") //模板
            {
                if (this.Sql.GetSql("Management.DataFile.ExportFromDatabase.Modual.byte", ref strSql) == -1) return -1;
            }
            else
            {
                this.Err = "未知文件类型";
                return -1;
            }

            try
            {
                sql = string.Format(strSql, dt.ID);
            }
            catch (Exception ex)
            {
                this.Err = "ExportFromDatabase付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            fileData = this.OutputBlob(sql);
            return 0;
        }


        /// <summary>
        /// 将文件导入到数据库中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileData">输入的文件数据</param>
        /// <returns></returns>
        public int ImportToDatabase(Neusoft.HISFC.Models.File.DataFileInfo dt, string fileData)
        {

            string strSql = "", sql = "";
            if (dt.ID == null || dt.ID == "") return -1;

            if (dt.Type.Trim() == "0")//数据
            {
                if (this.Sql.GetSql("Management.DataFile.ImportToDatabase", ref strSql) == -1) return -1;
            }
            else if (dt.Type.Trim() == "1") //模板
            {
                if (this.Sql.GetSql("Management.DataFile.ImportToDatabase.Modual", ref strSql) == -1) return -1;
            }
            else
            {
                this.Err = "未知文件类型";
                return -1;
            }

            try
            {
                sql = string.Format(strSql, dt.ID);
            }
            catch (Exception ex)
            {
                this.Err = "ImportToDatabase付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.InputLong(sql, fileData);

        }

        /// <summary>
        /// 输出文件 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public int ExportFromDatabase(Neusoft.HISFC.Models.File.DataFileInfo dt, ref string fileData)
        {
            string strSql = "", sql = "";
            if (dt.ID == null || dt.ID == "") return -1;
            if (dt.Type.Trim() == "0")//数据
            {
                if (this.Sql.GetSql("Management.DataFile.ExportFromDatabase", ref strSql) == -1) return -1;
            }
            else if (dt.Type.Trim() == "1") //模板
            {
                if (this.Sql.GetSql("Management.DataFile.ExportFromDatabase.Modual", ref strSql) == -1) return -1;
            }
            else
            {
                this.Err = "未知文件类型";
                return -1;
            }

            try
            {
                sql = string.Format(strSql, dt.ID);
            }
            catch (Exception ex)
            {
                this.Err = "ExportFromDatabase付值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            fileData = this.ExecSqlReturnOne(sql);
            if (fileData == "-1") return -1;
            return 0;
        }

        #endregion
    }
}
