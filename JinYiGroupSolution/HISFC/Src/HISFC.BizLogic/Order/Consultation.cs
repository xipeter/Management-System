using System;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Order
{
    /// <summary>
    /// 会诊管理类<br></br>
    /// <Font color='#FF1111'>[管理住院患者会诊信息]</Font><br></br>
    /// [创 建 者: ]<br>wolf</br>
    /// [创建时间: ]<br>2004-11</br>
    /// <修改记录 
    ///		修改人='张琦' 
    ///		修改时间='2007-8-24' 
    ///		修改目的='能够更新数据库的开立医嘱属性列'
    ///		修改描述='在插入和更新方法中添加了一个参数(能否开立医嘱)'
    ///		/>
    /// </summary>
    public class Consultation : Neusoft.FrameWork.Management.Database
    {
        public Consultation()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 作废
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        [Obsolete("用InsertConsultation代替了", true)]
        public int Insert(Neusoft.HISFC.Models.Order.Consultation consultation)
        {
            return this.InsertConsultation(consultation);
        }
        /// <summary>
        /// 更新审核标记
        /// </summary>
        /// <param name="consultationNO"></param>
        /// <returns></returns>
        [Obsolete("用UpdateConsultationAuditingFlag代替了", true)]
        public int Update(string consultationNO)
        {
            return this.UpdateConsultationAuditingFlag(consultationNO);
        }
        #endregion

        #region 增删改
        /// <summary>
        /// 插入会诊记录
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public int InsertConsultation(Neusoft.HISFC.Models.Order.Consultation consultation)
        {
            #region "接口"
            //			--住院流水号
            //            ,   --住院病历号
            //            ,   --住院科室代码
            //            ,   --护理站代码
            //            ,   --医嘱医师代号
            //            ,   --医嘱医师姓名
            //            ,   --填写申请日期
            //            ,   --预约会诊日期
            //            ,   --会诊类型，0科室/1医生,2医院
            //            ,   --加急会诊,1是/0否
            //            ,   --会诊科室
            //            ,   --会诊医师
            //            ,   --会诊说明
            //            ,   --处方起始日
            //            ,   --处方结束日
            //            ,   --实际会诊日
            //            ,   --会诊结果
            //            ,   --确认医生代码
            //            ,   --会诊状态,1申请/2确认
            //            ,   --用户代码
            //            ,   --医院名称
            //            ,   --紧急说明,1,2,3,备注，床位
            #endregion
            string strSql = "";

            if (this.Sql.GetSql("Order.Consultation.InsertItem.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            //try
            //{
            //    strSql = string.Format(strSql,consultation.InpatientNo ,consultation.PatientNo ,consultation.Dept.ID,
            //        consultation.NurseStation.ID,consultation.Doctor.ID,consultation.Doctor.Name,consultation.ApplyTime .ToString(),
            //        consultation.PreConsultationTime.ToString(),consultation.Type.GetHashCode().ToString(),
            //        consultation.IsEmergency.GetHashCode().ToString(),consultation.DeptConsultation.ID,
            //        consultation.DoctorConsultation.ID,consultation.Name,consultation.BeginTime.ToString(),
            //        consultation.EndTime.ToString(),consultation.ConsultationTime.ToString(),consultation.Result,
            //        consultation.DoctorConfirm.ID,consultation.State.ToString(),this.Operator.ID,
            //        consultation.HosConsultation.Name,//医院名称
            //        consultation.EmergencyMemo,//紧急说明
            //        consultation.User01,
            //        consultation.User02,
            //        consultation.User03,
            //        consultation.Memo,//患者备注
            //        consultation.BedNO);//患者床位
            //}
            //catch(Exception ex)
            //{
            //    this.Err=ex.Message;
            //    this.ErrCode=ex.Message;
            //    this.WriteErr();
            //    return -1;
            //}

            return this.ExecNoQuery(strSql,
                    consultation.InpatientNo,
                     consultation.PatientNo,
                    consultation.Dept.ID,
                    consultation.NurseStation.ID,
                    consultation.Doctor.ID,
                    consultation.Doctor.Name,
                    consultation.ApplyTime.ToString(),
                    consultation.PreConsultationTime.ToString(),
                    consultation.Type.GetHashCode().ToString(),
                    consultation.IsEmergency.GetHashCode().ToString(),
                    consultation.DeptConsultation.ID,
                    consultation.DoctorConsultation.ID,
                    consultation.Name,
                    consultation.BeginTime.ToString(),
                    consultation.EndTime.ToString(),
                    consultation.ConsultationTime.ToString(),
                    consultation.Result,
                    consultation.DoctorConfirm.ID,
                    consultation.State.ToString(),
                    this.Operator.ID,
                    consultation.HosConsultation.Name,//医院名称
                    consultation.EmergencyMemo,//紧急说明
                    consultation.User01,
                    consultation.User02,
                    consultation.User03,
                    consultation.Memo,//患者备注
                    consultation.BedNO,
                    consultation.IsCreateOrder.GetHashCode().ToString()//能否开立医嘱
                    );
        }
        /// <summary>
        /// 更新会诊记录
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public int UpdateConsultation(Neusoft.HISFC.Models.Order.Consultation consultation)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Consultation.UpdateItem.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            return this.ExecNoQuery(strSql, consultation.ID, consultation.InpatientNo, consultation.PatientNo, consultation.Dept.ID,
                    consultation.NurseStation.ID, consultation.Doctor.ID, consultation.Doctor.Name, consultation.ApplyTime.ToString(),
                    consultation.ConsultationTime.ToString(), consultation.Type.GetHashCode().ToString(),
                    consultation.IsEmergency.GetHashCode().ToString(), consultation.DeptConsultation.ID,
                    consultation.DoctorConsultation.ID, consultation.Name, consultation.BeginTime.ToString(),
                    consultation.EndTime.ToString(), consultation.ConsultationTime.ToString(), consultation.Result,
                    consultation.DoctorConfirm.ID, consultation.State.ToString(), this.Operator.ID,
                    consultation.HosConsultation.Name,//医院名称
                    consultation.EmergencyMemo,//紧急说明
                    consultation.User01,
                    consultation.User02,
                    consultation.User03,
                    consultation.Memo,//患者备注
                    consultation.BedNO,
                    consultation.IsCreateOrder.GetHashCode().ToString()//能否开立医嘱
                    );
        }

        /// <summary>
        /// 更新审核标记
        /// </summary>
        /// <returns></returns>
        public int UpdateConsultationAuditingFlag(string consultationNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Consultation.UpdateAuditFlag", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, consultationNO);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 更新会诊记录和会诊意见
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public int UpdateConsulationRecord(Neusoft.HISFC.Models.Order.Consultation consultation)
        {

            string strSql = "";

            if (this.Sql.GetSql("Order.Consultation.UpdateCnsl", ref strSql) == -1)
            {
                this.Err = "没有找到Order.Consultation.UpdateCnsl字段";
                return -1;
            }
            //try
            //{
            //    strSql = string.Format(strSql,consultation.ID,consultation.Record,consultation.Suggestion);
            //}
            //catch (Exception ex)
            //{
            //    this.Err = ex.Message;
            //    this.WriteErr();
            //    return -1;
            //}
            return this.ExecNoQuery(strSql, consultation.ID, consultation.Record, consultation.Suggestion);
        }
        /// <summary>
        /// 删除会诊记录
        /// </summary>
        /// <param name="ConsultationNo"></param>
        /// <returns></returns>
        public int DeleteConsulation(string ConsultationNo)
        {
            string strSql = "";
            #region "接口"
            //传入：0 病区编码 1用法编码 2 操作员 3 操作时间
            //传出：0
            #endregion

            if (this.Sql.GetSql("Order.Consultation.DeleteItem.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, ConsultationNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion

        #region 私有
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected ArrayList myGetList(string sql)
        {
            ArrayList al = new ArrayList();
            if (this.ExecQuery(sql) == -1) return null;
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Order.Consultation obj = new Neusoft.HISFC.Models.Order.Consultation();
                try
                {
                    obj.ID = this.Reader[0].ToString();
                    obj.InpatientNo = this.Reader[1].ToString();
                    obj.PatientNo = this.Reader[2].ToString();
                    obj.Dept.ID = this.Reader[3].ToString();
                    obj.NurseStation.ID = this.Reader[4].ToString();
                    obj.Doctor.ID = this.Reader[5].ToString();
                    obj.Doctor.Name = this.Reader[6].ToString();
                    obj.ApplyTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());
                    obj.PreConsultationTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());
                    obj.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());
                    obj.DeptConsultation.ID = this.Reader[10].ToString();
                    obj.DoctorConsultation.ID = this.Reader[11].ToString();
                    obj.Name = this.Reader[12].ToString();
                    obj.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[13].ToString());
                    obj.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[14].ToString());
                    obj.ConsultationTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[15].ToString());
                    obj.Result = this.Reader[16].ToString();
                    obj.DoctorConfirm.ID = this.Reader[17].ToString();
                    obj.State = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[18].ToString());
                    obj.Doctor.User01 = this.Reader[19].ToString();
                    obj.Doctor.User02 = this.Reader[20].ToString();
                    obj.HosConsultation.Name = this.Reader[21].ToString();//医院名称
                    obj.EmergencyMemo = this.Reader[22].ToString();//紧急说明
                    obj.User01 = this.Reader[23].ToString();
                    obj.User02 = this.Reader[24].ToString();
                    obj.User03 = this.Reader[25].ToString();
                    obj.Memo = this.Reader[26].ToString();//患者备注
                    obj.BedNO = this.Reader[27].ToString();//患者床位
                    obj.IsCreateOrder = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[28].ToString());//可否开立医嘱
                }
                catch { this.WriteErr(); return null; }
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 获得会诊列表
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public ArrayList QueryConsulation(string InpatientNo)
        {
            string strSql = "";
            //Order.Consultation.SelectItem.1
            //传入：0  InpatientNo
            //传出:会诊
            if (this.Sql.GetSql("Order.Consultation.Select.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            try
            {
                strSql = string.Format(strSql, InpatientNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return null;
            }

            return this.myGetList(strSql);
        }

        /// <summary>
        /// 根据会诊流水号查询会诊信息
        /// </summary>
        /// <param name="consulationNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.Consultation GetConsultation(string consulationNo)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.Consultation.GetSingleCnsl", ref strSql) == -1)
            {
                this.Err = "没有找到Order.Consultation.GetSingleCnsl字段！";
                return null;
            }
            strSql = string.Format(strSql, consulationNo);
            ArrayList al = this.myGetList(strSql);
            if (al.Count > 0) return al[0] as Neusoft.HISFC.Models.Order.Consultation;
            return null;
        }
        /// <summary>
        /// 获得院外会诊列表
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        public ArrayList QueryOutHosConsultaion(DateTime dt1, DateTime dt2, int iState)
        {
            ArrayList al = new ArrayList();
            string strSql = "";
            //Order.Consultation.SelectItem.1
            //传入：0  InpatientNo
            //传出:会诊
            if (this.Sql.GetSql("Order.Consultation.Select.2", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = string.Format(strSql, iState.ToString(), dt1.ToString(), dt2.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return null;
            }

            return this.myGetList(strSql);
        }
        /// <summary>
        /// 查询会诊单
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        public System.Data.DataSet QueryOuthosConsultation(DateTime dt1, DateTime dt2, int iState)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Consultation.Select.3", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                strSql = string.Format(strSql, iState.ToString(), dt1.ToString(), dt2.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return null;
            }
            if (this.ExecQuery(strSql, ref ds) == -1)
            {
                return null;
            }
            return ds;
        }
        #endregion
    }
}
