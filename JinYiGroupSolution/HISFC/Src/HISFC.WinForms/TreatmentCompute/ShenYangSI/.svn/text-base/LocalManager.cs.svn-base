using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ShenYangCitySI
{
    /// <summary>
    /// 医保接口业务层


    /// </summary>
    public class LocalManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// [功能描述: 医保业务层]<br></br>
        /// [创 建 者: 牛鑫元]<br></br>
        /// [创建时间: 2007-8-23]<br></br>
        /// 修改记录
        /// 修改人=''
        ///	修改时间=''
        ///	修改目的=''
        ///	修改描述=''
        /// 
        /// </summary>
        #region 查询医保统计编码
        /// <summary>
        /// 查询医保统计编码
        /// </summary>
        /// <param name="reportCode">发票类别(MZ01orZY01)</param>
        /// <param name="feeCode">最小费用编码</param>
        /// <returns>-1失败,成功时返回医保中心费用类别</returns>
        public string GetCenterStat(string reportCode, string feeCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Siinterface.localManager.1", ref  strSql)== -1)
            {
                this.Err = "获得[Siinterface.localManager.1]对应sql语句出错";
                return "-1";
            }

            try
            {
                strSql = string.Format(strSql, reportCode, feeCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;

            }
            return this.ExecSqlReturnOne(strSql);

        }
        #endregion

        #region 提取诊断编码

        /// <summary>
        /// 提取所有医保诊断编码
        /// </summary>
        /// <returns>医保诊断编码</returns>
        public ArrayList GetDiagnoseby()
        {
            string strSql = string.Empty;
            int returnValue = this.Sql.GetSql("Siinterface.localManager.2", ref strSql);
            {
                if (returnValue == -1)
                {
                    this.Err = "获得[Siinterface.localManager.2]对应sql语句出错";
                    return null;
                }
            }

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Base.Const obj = null;
            try
            {
                if (ExecQuery(strSql) == -1) return null;
            }
            catch (Exception ex)
            {

                this.Err = ex.Message; ;
                return null;
            }

            while (Reader.Read())
            {
                obj = new  Neusoft.HISFC.Models.Base.Const();
                obj.ID = this.Reader[1].ToString();
                obj.Name = this.Reader[2].ToString();
                obj.SpellCode = this.Reader[3].ToString();
                al.Add(obj);
                
            }
            return al;
        }
        /// <summary>
        /// 根据合同单位，提取所有医保诊断编码
        /// </summary>
        /// <param name="patient">挂号实体</param>
        /// <returns>医保诊断编码</returns>
        public ArrayList GetDiagnoseby(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            string strSql = string.Empty;
            int returnValue = this.Sql.GetSql("Siinterface.localManager.3", ref strSql);
            {
                if (returnValue == -1)
                {
                    this.Err = "获得[Siinterface.localManager.3]对应sql语句出错";
                    return null;
                }
            }
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Base.Const obj = null;
            try
            {
                if (ExecQuery(strSql, patient.Pact.ID) == -1) return null;
            }
            catch (Exception ex)
            {

                this.Err = ex.Message; ;
                return null;
            }

            while (Reader.Read())
            {
                obj = new Neusoft.HISFC.Models.Base.Const();
                obj.ID = this.Reader[1].ToString();
                obj.Name = this.Reader[2].ToString();
                obj.SpellCode = this.Reader[3].ToString();
                al.Add(obj);

            }
            return al;
        }

        /// <summary>
        /// 根据合同单位，提取所有医保诊断编码
        /// </summary>
        /// <param name="patient">挂号实体</param>
        /// <returns>医保诊断编码</returns>
        public ArrayList GetDiagnoseby(Neusoft.HISFC.Models.Registration.Register register)
        {
            string strSql = string.Empty;
            int returnValue = this.Sql.GetSql("Siinterface.localManager.3", ref strSql);
            {
                if (returnValue == -1)
                {
                    this.Err = "获得[Siinterface.localManager.3]对应sql语句出错";
                    return null;
                }
            }            
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Base.Const obj = null;
            try
            {
                if (ExecQuery(strSql, register.Pact.ID.Trim()) == -1) return null;
            }
            catch (Exception ex)
            {

                this.Err = ex.Message; ;
                return null;
            }

            while (Reader.Read())
            {
                obj = new Neusoft.HISFC.Models.Base.Const();
                obj.ID = this.Reader[1].ToString();
                obj.Name = this.Reader[2].ToString();
                obj.SpellCode = this.Reader[3].ToString();
                al.Add(obj);

            }
            return al;
        }
        #endregion

        #region 住院插入医保表
        /// <summary>
        /// 住院插入医保表
        /// </summary>
        /// <param name="obj">Neusoft.HISFC.Models.RADT.PatientInfo实体</param>
        /// <returns></returns>
        public int InsertSIMainInfo(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertSIMainInfo_AnShan.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.InsertSIMainInfo_AnShan.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
                     obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
                     obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
                     obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
                     obj.SIMainInfo.InDiagnose.Name, obj.PVisit.PatientLocation.Dept.ID, obj.PVisit.PatientLocation.Dept.Name,
                     obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, obj.PVisit.PatientLocation.Bed.ID,
                     obj.PVisit.InTime.ToString(), obj.PVisit.InTime.ToString(), obj.SIMainInfo.InDiagnose.ID,
                     obj.SIMainInfo.InDiagnose.Name, this.Operator.ID, obj.SIMainInfo.HosNo, obj.SIMainInfo.RegNo,
                     obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost, obj.PVisit.OutTime.ToString(),
                     obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name, obj.SIMainInfo.BalanceDate.ToString(),
                     obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost, obj.SIMainInfo.ItemPayCost,
                     obj.SIMainInfo.BaseCost, obj.SIMainInfo.ItemYLCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.OwnCost,
                     obj.SIMainInfo.OverCost, Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid),
                     Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.Memo,obj.SIMainInfo.OfficalCost,obj.SIMainInfo.PersonType.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        #endregion

        #region 门诊插入医保表
        /// <summary>
        /// 门诊插入医保表
        /// </summary>
        /// <param name="obj">Neusoft.HISFC.Models.Registration.Register实体</param>
        /// <returns></returns>
        public int InsertSIMainInfo(Neusoft.HISFC.Models.Registration.Register obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertSIMainInfo_Outpatient_AnShan.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.InsertSIMainInfo_Outpatient_AnShan.1]对应sql语句出错";
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
                    obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
                    obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
                    obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
                    obj.SIMainInfo.InDiagnose.Name, obj.DoctorInfo.Templet.Dept.ID, obj.DoctorInfo.Templet.Dept.Name,
                    obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, "",
                    obj.DoctorInfo.SeeDate, obj.DoctorInfo.SeeDate, obj.SIMainInfo.InDiagnose.ID,
                    obj.SIMainInfo.InDiagnose.Name, this.Operator.ID, obj.SIMainInfo.HosNo, obj.SIMainInfo.RegNo,
                    obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost, obj.DoctorInfo.SeeDate,
                    obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name, obj.SIMainInfo.BalanceDate.ToString(),
                    obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost, obj.SIMainInfo.ItemPayCost,
                    obj.SIMainInfo.BaseCost, obj.SIMainInfo.ItemYLCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.OwnCost,
                    obj.SIMainInfo.OverCost, Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid),
                    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.Memo,obj.SIMainInfo.OfficalCost,obj.SIMainInfo.PersonType.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        #endregion

        #region 得到住院医保患者基本信息
        /// <summary>
        /// 得到住院医保患者基本信息;
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetSIPersonInfo(string inpatientNo, string balanceState)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.GetSIPersonInfo.inPatient.Select.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.GetSIPersonInfo.inPatient.Select.1]对应sql语句出错";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, balanceState);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {

                    obj.SIMainInfo.HosNo = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SIMainInfo.BalNo = Reader[2].ToString();
                    obj.SIMainInfo.InvoiceNo = Reader[3].ToString();
                    obj.SIMainInfo.MedicalType.ID = Reader[4].ToString();
                    obj.PID.PatientNO = Reader[5].ToString();
                    obj.PID.CardNO = Reader[6].ToString();
                    obj.SSN = Reader[7].ToString();
                    obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[8].ToString());
                    obj.SIMainInfo.ProceatePcNo = Reader[9].ToString();
                    obj.SIMainInfo.SiBegionDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    obj.SIMainInfo.SiState = Reader[11].ToString();
                    obj.Name = Reader[12].ToString();
                    obj.Sex.ID = Reader[13].ToString();
                    obj.IDCard = Reader[14].ToString();
                    obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15].ToString());
                    obj.SIMainInfo.EmplType = Reader[16].ToString();
                    obj.CompanyName = Reader[17].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[18].ToString();
                    obj.PVisit.PatientLocation.Dept.ID = Reader[19].ToString();
                    obj.PVisit.PatientLocation.Dept.Name = Reader[20].ToString();
                    obj.Pact.PayKind.ID = Reader[21].ToString();
                    obj.Pact.ID = Reader[22].ToString();
                    obj.Pact.Name = Reader[23].ToString();
                    obj.PVisit.PatientLocation.Bed.ID = Reader[24].ToString();
                    obj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnoseDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnose.ID = Reader[26].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[27].ToString();
                    if (!Reader.IsDBNull(28))
                        obj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[28].ToString());
                    obj.SIMainInfo.OutDiagnose.ID = Reader[29].ToString();
                    obj.SIMainInfo.OutDiagnose.Name = Reader[30].ToString();
                    if (!Reader.IsDBNull(31))
                        obj.SIMainInfo.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString());

                    obj.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[32].ToString());
                    obj.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[33].ToString());
                    obj.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[34].ToString());
                    obj.SIMainInfo.ItemPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[35].ToString());
                    obj.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[36].ToString());
                    obj.SIMainInfo.PubOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[37].ToString());
                    obj.SIMainInfo.ItemYLCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[38].ToString());
                    obj.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[39].ToString());
                    obj.SIMainInfo.OverTakeOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[40].ToString());
                    obj.SIMainInfo.Memo = Reader[41].ToString();
                    obj.SIMainInfo.OperInfo.ID = Reader[42].ToString();
                    obj.SIMainInfo.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[43].ToString());
                    obj.SIMainInfo.RegNo = Reader[44].ToString();
                    obj.SIMainInfo.FeeTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[45].ToString());
                    obj.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[46].ToString());
                    obj.SIMainInfo.YearCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[47].ToString());
                    obj.SIMainInfo.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[48].ToString());
                    obj.SIMainInfo.IsBalanced = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[49].ToString());
                    obj.SIMainInfo.Memo = Reader[50].ToString();
                }
                Reader.Close();
                return obj;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                Reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 得到住院医保患者基本信息;
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetSIPersonInfoByInvoiceNo(string inpatientNo, string invoiceNo)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.GetSIPersonInfo.inPatient.Select.2", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.GetSIPersonInfo.inPatient.Select.2]对应sql语句出错";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {

                    obj.SIMainInfo.HosNo = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SIMainInfo.BalNo = Reader[2].ToString();
                    obj.SIMainInfo.InvoiceNo = Reader[3].ToString();
                    obj.SIMainInfo.MedicalType.ID = Reader[4].ToString();
                    obj.PID.PatientNO = Reader[5].ToString();
                    obj.PID.CardNO = Reader[6].ToString();
                    obj.SSN = Reader[7].ToString();
                    obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[8].ToString());
                    obj.SIMainInfo.ProceatePcNo = Reader[9].ToString();
                    obj.SIMainInfo.SiBegionDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    obj.SIMainInfo.SiState = Reader[11].ToString();
                    obj.Name = Reader[12].ToString();
                    obj.Sex.ID = Reader[13].ToString();
                    obj.IDCard = Reader[14].ToString();
                    obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15].ToString());
                    obj.SIMainInfo.EmplType = Reader[16].ToString();
                    obj.CompanyName = Reader[17].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[18].ToString();
                    obj.PVisit.PatientLocation.Dept.ID = Reader[19].ToString();
                    obj.PVisit.PatientLocation.Dept.Name = Reader[20].ToString();
                    obj.Pact.PayKind.ID = Reader[21].ToString();
                    obj.Pact.ID = Reader[22].ToString();
                    obj.Pact.Name = Reader[23].ToString();
                    obj.PVisit.PatientLocation.Bed.ID = Reader[24].ToString();
                    obj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnoseDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnose.ID = Reader[26].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[27].ToString();
                    if (!Reader.IsDBNull(28))
                        obj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[28].ToString());
                    obj.SIMainInfo.OutDiagnose.ID = Reader[29].ToString();
                    obj.SIMainInfo.OutDiagnose.Name = Reader[30].ToString();
                    if (!Reader.IsDBNull(31))
                        obj.SIMainInfo.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString());

                    obj.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[32].ToString());
                    obj.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[33].ToString());
                    obj.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[34].ToString());
                    obj.SIMainInfo.ItemPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[35].ToString());
                    obj.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[36].ToString());
                    obj.SIMainInfo.PubOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[37].ToString());
                    obj.SIMainInfo.ItemYLCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[38].ToString());
                    obj.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[39].ToString());
                    obj.SIMainInfo.OverTakeOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[40].ToString());
                    obj.SIMainInfo.Memo = Reader[41].ToString();
                    obj.SIMainInfo.OperInfo.ID = Reader[42].ToString();
                    obj.SIMainInfo.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[43].ToString());
                    obj.SIMainInfo.RegNo = Reader[44].ToString();
                    obj.SIMainInfo.FeeTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[45].ToString());
                    obj.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[46].ToString());
                    obj.SIMainInfo.YearCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[47].ToString());
                    obj.SIMainInfo.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[48].ToString());
                    obj.SIMainInfo.IsBalanced = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[49].ToString());
                    obj.SIMainInfo.Memo = Reader[50].ToString();
                }
                Reader.Close();
                return obj;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                Reader.Close();
                return null;
            }
        }
        #endregion

        #region 得到门诊医保患者基本信息
        /// <summary>
        /// 得到门诊医保患者基本信息;
        /// </summary>
        /// <param name="clinicNO">门诊流水号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Registration.Register GetSIPersonInfoOutPatient(string clinicNO)
        {
            Neusoft.HISFC.Models.Registration.Register obj = new Neusoft.HISFC.Models.Registration.Register();
            string strSql = "";
            string balNo = "0";

            if (this.Sql.GetSql("Fee.Interface.GetSIPersonInfo.outPatient.Select.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.GetSIPersonInfo.outPatient.Select.1]对应sql语句出错";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, clinicNO, balNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {

                    obj.SIMainInfo.HosNo = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SIMainInfo.BalNo = Reader[2].ToString();
                    obj.SIMainInfo.InvoiceNo = Reader[3].ToString();
                    obj.SIMainInfo.MedicalType.ID = Reader[4].ToString();
                    obj.PID.PatientNO = Reader[5].ToString();
                    obj.PID.CardNO = Reader[6].ToString();
                    obj.SSN = Reader[7].ToString();
                    obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[8].ToString());
                    obj.SIMainInfo.ProceatePcNo = Reader[9].ToString();
                    obj.SIMainInfo.SiBegionDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    obj.SIMainInfo.SiState = Reader[11].ToString();
                    obj.Name = Reader[12].ToString();
                    obj.Sex.ID = Reader[13].ToString();
                    obj.IDCard = Reader[14].ToString();
                    obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15].ToString());
                    obj.SIMainInfo.EmplType = Reader[16].ToString();
                    obj.CompanyName = Reader[17].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[18].ToString();
                    obj.DoctorInfo.Templet.Dept.ID = Reader[19].ToString();
                    obj.DoctorInfo.Templet.Dept.Name = Reader[20].ToString();
                    obj.Pact.PayKind.ID = Reader[21].ToString();
                    obj.Pact.ID = Reader[22].ToString();
                    obj.Pact.Name = Reader[23].ToString();
                    //obj.PVisit.PatientLocation.Bed.ID = Reader[24].ToString();
                    obj.DoctorInfo.SeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnoseDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnose.ID = Reader[26].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[27].ToString();
                    //if (!Reader.IsDBNull(28))
                    //    obj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[28].ToString());
                    obj.SIMainInfo.OutDiagnose.ID = Reader[29].ToString();
                    obj.SIMainInfo.OutDiagnose.Name = Reader[30].ToString();
                    if (!Reader.IsDBNull(31))
                        obj.SIMainInfo.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString());

                    obj.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[32].ToString());
                    obj.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[33].ToString());
                    obj.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[34].ToString());
                    obj.SIMainInfo.ItemPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[35].ToString());
                    obj.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[36].ToString());
                    obj.SIMainInfo.PubOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[37].ToString());
                    obj.SIMainInfo.ItemYLCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[38].ToString());
                    obj.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[39].ToString());
                    obj.SIMainInfo.OverTakeOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[40].ToString());
                    obj.SIMainInfo.Memo = Reader[41].ToString();
                    obj.SIMainInfo.OperInfo.ID = Reader[42].ToString();
                    obj.SIMainInfo.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[43].ToString());
                    obj.SIMainInfo.RegNo = Reader[44].ToString();
                    obj.SIMainInfo.FeeTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[45].ToString());
                    obj.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[46].ToString());
                    obj.SIMainInfo.YearCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[47].ToString());
                    obj.SIMainInfo.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[48].ToString());
                    obj.SIMainInfo.IsBalanced = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[49].ToString());
                    obj.SIMainInfo.Memo = Reader[50].ToString();
                }
                Reader.Close();
                return obj;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                Reader.Close();
                return null;
            }
        }
        #endregion

        #region 更新医保结算主表信息
        /// <summary>
        /// 更新医保结算主表信息
        /// </summary>
        /// <param name="obj">住院患者基本信息类</param>
        /// <returns></returns>
        public int UpdateSiMainInfo(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            string strSql = "";
            string balNo = this.GetBalNo(obj.ID);
            if (this.Sql.GetSql("Fee.Interface.UpdateSiMainInfo.AnShan.Update.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.UpdateSiMainInfo.AnShan.Update.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
                    obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
                    obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
                    obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
                    obj.SIMainInfo.InDiagnose.Name, obj.PVisit.PatientLocation.Dept.ID, obj.PVisit.PatientLocation.Dept.Name,
                    obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, obj.PVisit.PatientLocation.Bed.ID,
                    obj.PVisit.InTime.ToString(), obj.PVisit.InTime.ToString(), obj.SIMainInfo.InDiagnose.ID,
                    obj.SIMainInfo.InDiagnose.Name, obj.PVisit.OutTime, obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name,
                    obj.SIMainInfo.BalanceDate.ToString(), obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost,
                    obj.SIMainInfo.ItemPayCost, obj.SIMainInfo.BaseCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.ItemYLCost,
                    obj.SIMainInfo.OwnCost, obj.SIMainInfo.OverTakeOwnCost, "", this.Operator.ID,
                    obj.SIMainInfo.RegNo, obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost,
                    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid), Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.OverCost, obj.SIMainInfo.OfficalCost);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);

        }
        #endregion

        #region 住院结算召回处理
        /// <summary>
        /// 住院结算召回处理
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns></returns>
        public int InsertBackBalanceInpatient(string inpatientNo, string invoiceNO, string blaNO, string operDate, string operCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.inPatient.Back.insert.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.inPatient.Back.insert.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, invoiceNO, blaNO, operDate, operCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }

        #endregion 
      
        #region 得到结算序号
        /// <summary>
        /// 得到结算序号
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns></returns>
       
        public string GetBalNo(string inpatientNo)
        {
            string strSql = "";
            string balNo = "";
            if (this.Sql.GetSql("Fee.Interface.GetBalNo.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.GetBalNo.1]对应sql语句出错";

                return "";
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return "";
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {
                    balNo = Reader[0].ToString();
                }
                Reader.Close();
                return balNo;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return "";
            }
        } 
        #endregion

        #region 更新记录为作废记录
        /// <summary>
        /// 更新记录为作废记录
        /// </summary>
        /// <param name="patientID">住院号</param>
        /// <param name="invoiceNO">发票</param>
        /// <param name="typeCode">1门诊,2住院</param>
        /// <returns></returns>
        public int setValidFalseOldInvoice(string patientID, string invoiceNO, string typeCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.inPatient.Back.update.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.inPatient.Back.update.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, patientID, invoiceNO, typeCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        } 
        #endregion

        #region 查询医保类别
        /// <summary>
        /// 查询医保类别
        /// </summary>
        /// <param name="patientID">住院(门诊流水号)</param>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="typeCode">1门诊2住院</param>
        /// <returns></returns>
        public string GetMedicalType(string patientID, string invoiceNO, string typeCode)
        {

            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.inPatient.Back.medicaltype.select.1", ref strSql) == -1)
            {
                this.Err = "没有找到相应的sql语句[Fee.Interface.inPatient.Back.medicaltype.select.1]";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, patientID, invoiceNO, typeCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            string returnValue = this.ExecSqlReturnOne(strSql);

            if ( returnValue == "-1")
            {
                return null;
            }
            return returnValue;
        } 
        #endregion

        #region 住院更新上传标志
        /// <summary>
        /// 更新上传标志
        /// </summary>
        /// <param name="f">费用实体类</param>
        /// <returns></returns>
        public int updateUploadFlagInpatient(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f ,string transType)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.UpdateItemList.AnShan.Update.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.UpdateItemList.AnShan.Update.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql,f.RecipeNO,f.SequenceNO,transType);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);


        }
        /// <summary>
        /// 更新交易类型fin_ipr_siinmaininfo.trans_type
        /// </summary>
        /// <param name="transType">交易类型 正交易：1 反交易：2</param>
        /// <param name="inpatentNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns></returns>
        public int updateTransType(string transType, string inpatentNO, string balanceNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.UpdateSIMainInfoTransType.1", ref strSql) == -1)
            {
                this.Err = "获得[Fee.Interface.UpdateSIMainInfoTransType.1]对应sql语句出错";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, transType, inpatentNO, balanceNO);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
	    #endregion
    }
}
