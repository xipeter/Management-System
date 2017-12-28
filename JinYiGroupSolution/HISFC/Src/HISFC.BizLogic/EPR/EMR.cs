using System;
using System.Collections;
using System.Data;
namespace Neusoft.HISFC.BizLogic.EPR
{
    /// <summary>
    /// EMR 的摘要说明。
    /// 电子病历管理类
    /// </summary>
    public class EMR : Neusoft.FrameWork.Management.Database
    {
        public EMR()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        protected Neusoft.HISFC.BizLogic.File.DataFile manager = new Neusoft.HISFC.BizLogic.File.DataFile();

        #region "电子病历"
        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <returns>截至时间字符串，若为Error,则系统参数未设置</returns>
        public string GetControlArgument(string ctlID)
        {
            string strSql = string.Empty;
            string ctlValue = string.Empty;

            if (this.Sql.GetSql("QueryControlerInfo.2", ref strSql) == -1) return string.Empty;
            if (strSql == null) return string.Empty;
            try
            {
                strSql = string.Format(strSql, ctlID);
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    ctlValue = this.Reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                if (Reader.IsClosed == false) Reader.Close();
                return "Error";
            }
            this.Reader.Close();

            if (ctlValue == string.Empty)
            {
                this.Err = "系统未维护参数设置，参数代码:" + ctlID + "请联系系统管理员！";
                this.ErrCode = "系统未维护参数设置，参数代码:" + ctlID + "请联系系统管理员！";
                this.WriteErr();
                return "Error";
            }
            return ctlValue;
        }

        /// <summary>
        /// 获得文件列表
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public ArrayList GetEmrList(string inpatientNo)
        {
            if (manager.GetFiles(inpatientNo) > 0)//获得文件列表
            {
                return manager.alFiles;
            }
            return null;
        }


        /// <summary>
        /// 查询电子病历日志操作
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet QueryLogo(string strWhere)
        {
            string sql = "";
            if (this.Sql.GetSql("Emr_Logo_Query", ref sql) == -1) return null;
            DataSet ds = new DataSet();
            if (this.ExecQuery(sql + " " + strWhere, ref ds) == -1) return null;
            return ds;
        }
        #endregion

        #region 节点操作
        /// <summary>
        /// 获得节点内容
        /// </summary>
        /// <param name="table"></param>
        /// <param name="inpatientNo"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetNodeValue(string table, string inpatientNo, string nodeName)
        {
            return manager.GetNodeValueFormDataStore(table, inpatientNo, nodeName);
        }

        /// <summary>
        /// 获得节点列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public ArrayList GetNodePathList(string table)
        {
            string strSql = "EPR.EMR.GetNodePathList";
            if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;
            if (this.ExecQuery(strSql, table) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = obj.ID;
                obj.Memo = "STRING";
                obj.User01 = obj.ID;
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 查询病历
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataSet QueryEMRByNode(string strWhere)
        {
            string strSql = "EPR.EMR.QueryEMRByNode";
            if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, strWhere);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            if (strSql.TrimEnd().Substring(strSql.TrimEnd().Length - 5).ToUpper() == "WHERE")
                strSql = strSql.TrimEnd().Substring(0, strSql.TrimEnd().Length - 5);

            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        #endregion

        #region 时间节点操作
        /// <summary>
        /// 获得节点内容
        /// </summary>
        /// <param name="table"></param>
        /// <param name="inpatientNo"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetDateNodeValueByIndex(string table, string inpatientNo, string Name, string NodeName, DateTime date, string index)
        {
            return manager.GetDateNodeValueFormDataStoreByIndex(table, inpatientNo, Name, NodeName, date, index);
        }

        /// <summary>
        /// 获得节点内容
        /// </summary>
        /// <param name="table"></param>
        /// <param name="inpatientNo"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetDateNodeValueByTime(string table, string inpatientNo, string Name, string NodeName, DateTime date)
        {
            return manager.GetDateNodeValueFormDataStoreByTime(table, inpatientNo, Name, NodeName, date);
        }

        public int SaveNodeToDateDataStoreByTime(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string NodeValue, string Unit)
        {
            return manager.SaveNodeToDateDataStoreByTime(Table, dt, Name, nodeName, date, NodeValue, Unit);
        }

        public int SaveNodeToDateDataStoreByIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string Index, string NodeValue, string Unit)
        {
            return manager.SaveNodeToDateDataStoreByIndex(Table, dt, Name, nodeName, date, Index, NodeValue, Unit);
        }
       
        public int SaveNodeToDateDataStoreByInsertIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string Index, string NodeValue, string Unit)
        {
            return manager.SaveNodeToDateDataStoreByInsertIndex(Table, dt, Name, nodeName, date, Index, NodeValue, Unit);
        }
        public int DelDataStoreVitalSignByIndex(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt)
        {
            return manager.DelDataStoreVitalSignByIndex(Table, dt);
        }
        public int DelDataStoreVitalSignByIndex1OneTime(string Table, Neusoft.HISFC.Models.File.DataFileInfo dt, DateTime recordtime)
        {
            return manager.DelDataStoreVitalSignByIndex1OneTime(Table, dt, recordtime);
        }

        public Hashtable QueryDataStoreVitalSignByIndex1(string Table, string datatype, string inpatientNo)
        {
            return manager.QueryDataStoreVitalSignByIndex1(Table, datatype, inpatientNo);
        }


        public ArrayList QueryDataStoreVitalSignByIndex1OneTime(string Table, string datatype, string inpatientNo, DateTime recorddate)
        {
            return manager.QueryDataStoreVitalSignByIndex1OneTime(Table, datatype, inpatientNo, recorddate);
        }
        public ArrayList QueryDataStoreVitalSignByRecordDate(string Table, string datatype, string nodename, string patientids)
        {
            return manager.QueryDataStoreVitalSignByRecordDate(Table, datatype, nodename, patientids);
        }

        public Hashtable QueryDataStoreVitalSignByAllIndex1Data(string Table, string datatype, string nodename, string patientids, string recorddate)
        {
            return manager.QueryDataStoreVitalSignByAllIndex1Data(Table, datatype, nodename, patientids, recorddate);
        }

        /// <summary>
        /// 获得节点列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns>ArrayList:NeuObject(id, nodename,record_date,record_index,nodevalue,unit)</returns>
        public ArrayList GetDateNodePathList(string table, string inpatientNo, string Name)
        {
            string strSql = "EPR.EMR.GetDateNodePathList.1";
            //id, nodename,record_date,record_index,nodevalue,unit 
            if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;
            if (this.ExecQuery(strSql, table, inpatientNo, Name) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
                obj.Memo = this.Reader[2].ToString();
                obj.User01 = this.Reader[3].ToString();
                obj.User02 = this.Reader[4].ToString();
                obj.User03 = this.Reader[5].ToString();
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得节点列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns>ArrayList:NeuObject(id, nodename,record_date,record_index,nodevalue,unit)</returns>
        public ArrayList GetDateNodePathList(string table, string inpatientNo, string Name, string NodeName)
        {
            string strSql = "EPR.EMR.GetDateNodePathList.2";
            //id, nodename,record_date,record_index,nodevalue,unit 
            if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;
            if (this.ExecQuery(strSql, table, inpatientNo, Name, NodeName) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
                obj.Memo = this.Reader[2].ToString();
                obj.User01 = this.Reader[3].ToString();
                obj.User02 = this.Reader[4].ToString();
                obj.User03 = this.Reader[5].ToString();
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 查询病历
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        //public System.Data.DataSet QueryEMRByNode(string strWhere)
        //{
        //    string strSql = "EPR.EMR.QueryEMRByNode";
        //    if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;
        //    try
        //    {
        //        strSql = string.Format(strSql, strWhere);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Err = ex.Message;
        //        this.WriteErr();
        //        return null;
        //    }
        //    if (strSql.TrimEnd().Substring(strSql.TrimEnd().Length - 5).ToUpper() == "WHERE")
        //        strSql = strSql.TrimEnd().Substring(0, strSql.TrimEnd().Length - 5);

        //    System.Data.DataSet ds = new System.Data.DataSet();
        //    if (this.ExecQuery(strSql, ref ds) == -1) return null;
        //    return ds;
        //}
        #endregion 时间节点操作

        #region 宏操作
        /// <summary>
        ///  插入一条宏
        /// </summary>
        /// <param name="obj"> id = fileid ;name fileName,memo,fileMemo ,User01,宏名称【索引】</param>
        /// <returns></returns>
        public int InsertMacro(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.Macro.InsertMacro", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, obj.ID, obj.Name, obj.Memo, obj.User01);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


































        /// <summary>
        /// 删除一条宏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteMacro(string id, string user01)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.Macro.DeleteMacro", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql, id, user01);
        }


























        /// <summary>
        /// 更新一条宏
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateMacro(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.Macro.UpdateMacro", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, obj.ID, obj.Name, obj.Memo, obj.User01);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 获得宏
        /// </summary>
        /// <returns></returns>
        public ArrayList GetMacroList(string user01)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.Macro.GetMacroList", ref strSql) == -1) return null;
            if (this.ExecQuery(strSql, user01) == -1) return null;
            ArrayList al = new ArrayList();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.Memo = this.Reader[2].ToString();
                    obj.User01 = this.Reader[3].ToString();
                    al.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Reader.Close();
                this.Err = ex.Message;
                return null;
            }
            this.Reader.Close();
            return al;
        }

        #endregion

        #region 并发


        /// <summary>
        /// 查询锁着的患者
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet QueryEMRLocked()
        {
            string strSql = "EPR.EMR.QueryEMRLocked";
            if (this.Sql.GetSql(strSql, ref strSql) == -1) return null;

            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }

        #region [Obsolete]
        /// <summary>
        /// 设置
        /// </summary>
        /// <returns></returns>
        [ObsoleteAttribute("该方法已过时，更改为int SetEMRLocked(string fileID, Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject obj, bool isLocked)")]
        public int SetEMRLocked(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject oper, bool locked)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.DeleteEMRLocked", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, patient.ID);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }

            if (this.ExecNoQuery(strSql) == -1) return -1;

            if (this.Sql.GetSql("EPR.EMR.InsertEMRLocked", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, patient.ID, patient.Name,
                    patient.PVisit.PatientLocation.Dept.ID, patient.PVisit.PatientLocation.Dept.Name, patient.Memo, Neusoft.FrameWork.Function.NConvert.ToInt32(locked),
                    oper.ID, oper.Name);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        //<summary>
        //判断是否锁
        //</summary>
        //<param name="inpatient_no"></param>
        //<returns></returns>
        [ObsoleteAttribute("该方法已过时，更改为bool IsEMRLocked(string fileID, ref Neusoft.FrameWork.Models.NeuObject obj)")]
        public bool IsEMRLocked(string inpatient_no, ref Neusoft.FrameWork.Models.NeuObject oper)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.IsEMRLocked", ref strSql) == -1) return false;
            strSql = string.Format(strSql, inpatient_no);
















            if (this.ExecQuery(strSql) == -1) return false;

            bool bLocked = false;
            if (this.Reader.Read())
            {
                bLocked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[0]);
                oper = new Neusoft.FrameWork.Models.NeuObject();
                oper.ID = this.Reader[1].ToString();
                oper.Name = this.Reader[2].ToString();
                oper.Memo = this.Reader[3].ToString();
            }
            this.Reader.Close();
            return bLocked;
        }
        #endregion

        #region 根据病例号控制并发操作，modified by pantiejun date:2007-10-17
        /// <summary>
        ///  查询是否锁
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEMRLocked(string patientid, string fileID, ref Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.IsEMRLocked", ref strSql) == -1) return false;
            strSql = string.Format(strSql, patientid, fileID);

            if (this.ExecQuery(strSql) == -1) return false;

            bool bLocked = false;
            if (this.Reader.Read())
            {
                bLocked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[0]);
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[1].ToString();
                obj.Name = this.Reader[2].ToString();
                obj.Memo = this.Reader[3].ToString();
            }
            this.Reader.Close();
            return bLocked;
        }
        /// <summary>
        /// 设置锁还是不锁
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="patient"></param>
        /// <param name="obj"></param>
        /// <param name="isLocked"></param>
        /// <returns></returns>
        public int SetEMRLocked(Neusoft.HISFC.Models.File.DataFileInfo dfi, Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject obj, bool isLocked)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.DeleteEMRLocked", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, patient.ID, dfi.ID);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }

            if (this.ExecNoQuery(strSql) == -1) return -1;

            if (this.Sql.GetSql("EPR.EMR.InsertEMRLocked", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, patient.ID, patient.Name,
                    patient.PVisit.PatientLocation.Dept.ID, patient.PVisit.PatientLocation.Dept.Name, patient.Memo, Neusoft.FrameWork.Function.NConvert.ToInt32(isLocked),
                    obj.ID, obj.Name, dfi.ID, dfi.Name);
            }
            catch (Exception ex)
            {
                this.Err = "错误的参数！\n" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion

        #endregion
        #region MCA体温单
        /// <summary>
        /// 体温
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public DataSet QueryTemperature(string inpatientNo, DateTime queryTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("QueryTemperature", ref strSql) == -1) return null;
            strSql = String.Format(strSql, inpatientNo, queryTime);
            DataSet ds = new DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        /// <summary>
        /// 脉搏
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public DataSet QueryThrob(string inpatientNo, DateTime queryTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("QueryThrob", ref strSql) == -1) return null;
            strSql = String.Format(strSql, inpatientNo, queryTime);
            DataSet ds = new DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        /// <summary>
        /// 呼吸
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public DataSet QueryBreath(string inpatientNo, DateTime queryTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("QueryBreath", ref strSql) == -1) return null;
            strSql = String.Format(strSql, inpatientNo, queryTime);
            DataSet ds = new DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        /// <summary>
        /// 血压
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public DataSet QueryPressure(string inpatientNo, DateTime queryTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("QueryPressure", ref strSql) == -1) return null;
            strSql = String.Format(strSql, inpatientNo, queryTime);
            DataSet ds = new DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        /// <summary>
        /// 入 出液
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public DataSet QueryInject(string inpatientNo, DateTime queryTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("QueryInject", ref strSql) == -1) return null;
            strSql = String.Format(strSql, inpatientNo, queryTime);
            DataSet ds = new DataSet();
            if (this.ExecQuery(strSql, ref ds) == -1) return null;
            return ds;
        }
        #endregion MCA体温单


    }
}