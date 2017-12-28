using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using HeNanProvinceSI.Object;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Base;

namespace HeNanProvinceSI
{
    /// <summary>
    /// [功能描述: 医保业务层]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2007-8-23]<br></br>
    /// 修改记录
    /// 修改人='许超'
    ///	修改时间='2009-2-13'
    ///	修改目的=''
    ///	修改描述='SQL语句放在类里面，而不存放在数据库里'
    /// 
    /// </summary>
    /// 
   
    public class LocalManager : Neusoft.FrameWork.Management.Database
    {
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
            //if (this.Sql.GetSql("Siinterface.localManager.1", ref  strSql)== -1)
            //{
            //    this.Err = "获得[Siinterface.localManager.1]对应sql语句出错";
            //    return "-1";
            //}

            try
            {
                strSql = string.Format(SQL.GetCenterStatSQL, reportCode, feeCode);
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

        //{D89CF5A6-DD6C-468e-ADF6-985A712D6787} 获取所有识别码
        /// <summary>
        /// 获取所有识别码
        /// </summary>
        /// <returns></returns>
        public ArrayList GetPDiagnose()
        {
            ArrayList a = new ArrayList();
            //string strSql = "";
            //if (this.Sql.GetSql("Siinterface.LocalManager.8", ref strSql) == -1)
            //{
            //    this.Err = "获取SQL语句失败,索引:Siinterface.LocalManager.8";
            //    return null;
            //}

            try
            {
                this.ExecQuery(SQL.GetPDiagnoseSQL);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            ICDMedicare medicare;

            while (this.Reader.Read())
            {
                medicare = new ICDMedicare();
                medicare.ID = this.Reader[0].ToString();
                medicare.Name = this.Reader[1].ToString();
                medicare.SpellCode = this.Reader[2].ToString();
                medicare.UseArea = this.Reader[3].ToString();

                if (this.Reader[3].ToString() == "1")
                {
                    medicare.Memo = "单病种";
                    medicare.WBCode = "DBZ";
                }

                if (this.Reader[3].ToString() == "5")
                {
                    medicare.Memo = "生育";
                    medicare.WBCode = "SY";
                }

                if (this.Reader[3].ToString() == "4")
                {
                    medicare.Memo = "特病";
                    medicare.WBCode = "TB";
                }

                if (this.Reader[3].ToString() == "6")
                {
                    medicare.Memo = "家病";
                    medicare.WBCode = "JB";
                }

                a.Add(medicare);
            }

            return a;
        }

        #region CUT
        ///// <summary>
        ///// 提取所有医保诊断编码

        ///// </summary>
        ///// <returns>医保诊断编码</returns>
        //public ArrayList GetDiagnoseby()
        //{
        //    string strSql = string.Empty;
        //    //int returnValue = this.Sql.GetSql("Siinterface.localManager.2", ref strSql);
        //    //{
        //    //    if (returnValue == -1)
        //    //    {
        //    //        this.Err = "获得[Siinterface.localManager.2]对应sql语句出错";
        //    //        return null;
        //    //    }
        //    //}
        //    //{EEBA7F49-665C-4217-AAB8-334ADDA9473C}//
        //    //增加where条件
        //    strSql = string.Format(this.GetDiagnosebyALLSQL + " where a.pack_code= '2'");

        //    ArrayList al = new ArrayList();
        //    Neusoft.HISFC.Models.Base.Const obj = null;
        //    try
        //    {
        //        if (ExecQuery(strSql) == -1) return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        this.Err = ex.Message; ;
        //        return null;
        //    }

        //    while (Reader.Read())
        //    {
        //        obj = new  Neusoft.HISFC.Models.Base.Const();
        //        obj.ID = this.Reader[1].ToString();
        //        obj.Name = this.Reader[2].ToString();
        //        obj.SpellCode = this.Reader[3].ToString();
        //        al.Add(obj);

        //    }
        //    return al;
        //}
        ///// <summary>
        ///// 根据合同单位，提取所有医保诊断编码

        ///// </summary>
        ///// <param name="patient">挂号实体</param>
        ///// <returns>医保诊断编码</returns>
        //public ArrayList GetDiagnoseby(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        //{
        //    string strSql = string.Empty;
        //    int returnValue = this.Sql.GetSql("Siinterface.localManager.3", ref strSql);
        //    {
        //        if (returnValue == -1)
        //        {
        //            this.Err = "获得[Siinterface.localManager.3]对应sql语句出错";
        //            return null;
        //        }
        //    }
        //    ArrayList al = new ArrayList();
        //    Neusoft.HISFC.Models.Base.Const obj = null;
        //    try
        //    {
        //        if (ExecQuery(strSql, patient.Pact.ID) == -1) return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        this.Err = ex.Message; ;
        //        return null;
        //    }

        //    while (Reader.Read())
        //    {
        //        obj = new Neusoft.HISFC.Models.Base.Const();
        //        obj.ID = this.Reader[1].ToString();
        //        obj.Name = this.Reader[2].ToString();
        //        obj.SpellCode = this.Reader[3].ToString();
        //        al.Add(obj);

        //    }
        //    return al;
        //}

        ///// <summary>
        ///// 根据合同单位，提取所有医保诊断编码

        ///// </summary>
        ///// <param name="patient">挂号实体</param>
        ///// <returns>医保诊断编码</returns>
        //public ArrayList GetDiagnoseby(Neusoft.HISFC.Models.Registration.Register register)
        //{
        //    string strSql = string.Empty;
        //    int returnValue = this.Sql.GetSql("Siinterface.localManager.3", ref strSql);
        //    {
        //        if (returnValue == -1)
        //        {
        //            this.Err = "获得[Siinterface.localManager.3]对应sql语句出错";
        //            return null;
        //        }
        //    }            
        //    ArrayList al = new ArrayList();
        //    Neusoft.HISFC.Models.Base.Const obj = null;
        //    try
        //    {
        //        if (ExecQuery(strSql, register.Pact.ID.Trim()) == -1) return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        this.Err = ex.Message; ;
        //        return null;
        //    }

        //    while (Reader.Read())
        //    {
        //        obj = new Neusoft.HISFC.Models.Base.Const();
        //        obj.ID = this.Reader[1].ToString();
        //        obj.Name = this.Reader[2].ToString();
        //        obj.SpellCode = this.Reader[3].ToString();
        //        al.Add(obj);

        //    }
        //    return al;
        //}
        #endregion


        //{916C4C7D-A74D-474c-814A-11FD60CA1884} 提取主诊断
        /// <summary>
        /// 提取主诊断
        /// </summary>
        /// <returns></returns>
        public ArrayList GetDiagnose()
        {
            ArrayList a = new ArrayList();
            //string strSql = "";

            //if (this.Sql.GetSql("Siinterface.LocalManager.9", ref strSql) == -1)
            //{
            //    this.Err = "获取SQL语句失败,索引:Siinterface.LocalManager.9";
            //    return null;
            //}


            #region {61027ED6-07A6-4750-A6B3-D3FCDC792013}
            if (this.ExecQuery(SQL.GetPDiagnoseSQL) == -1)
            {
                return null;
            } 
            #endregion


            try
            {
                ICDMedicare medicare;
                while (this.Reader.Read())
                {
                    medicare = new ICDMedicare();
                    medicare.ID = this.Reader[0].ToString();
                    medicare.Name = this.Reader[1].ToString();
                    medicare.DisKind = this.Reader[2].ToString();
                    medicare.SpellCode = this.Reader[3].ToString();
                    medicare.UseArea = this.Reader[4].ToString();
                    //medicare.ChangeDate = this.Reader[5].ToString();
                    medicare.DeptKInd = this.Reader[6].ToString();

                    if (this.Reader[4].ToString() == "0")
                    {
                        medicare.Memo = "非生育医疗|" + this.Reader[4].ToString();
                    }

                    if (this.Reader[4].ToString() == "1")
                    {
                        medicare.Memo = "医保范围外|" + this.Reader[4].ToString();
                    }
                    if (this.Reader[4].ToString() == "3")
                    {
                        medicare.Memo = "生育医疗|" + this.Reader[4].ToString();
                    }
                    if (this.Reader[4].ToString() == "4")
                    {
                        medicare.Memo = "生育或生育转基本医疗|"+this.Reader[4].ToString();
                    }

                    if (this.Reader[2].ToString() == "0")
                    {
                        medicare.WBCode = "0类";

                    }

                    if (this.Reader[2].ToString() == "1")
                    {
                        medicare.WBCode = "I类";

                    }

                    if (this.Reader[2].ToString() == "2")
                    {
                        medicare.WBCode = "II类";

                    }

                    if (this.Reader[2].ToString() == "3")
                    {
                        medicare.WBCode = "III类";

                    }

                    if (this.Reader[2].ToString() == "4")
                    {
                        medicare.WBCode = "IV类";

                    }

                    if (this.Reader[2].ToString() == "5")
                    {
                        medicare.WBCode = "V类";

                    }
                    a.Add(medicare);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取诊断数据时出错！\n" + ex.Message;
                return null;
            }
            return a;
        }
        #endregion

        #region 提取手术编码
        //{2C51EE6A-D626-4002-A9EE-D20EBFD8178B}
        /// <summary>
        /// 提取手术编码
        /// </summary>
        /// <returns></returns>
        public ArrayList GetOperate()
        {
            ArrayList a = new ArrayList();
            //string strSql = "";
            //if (this.Sql.GetSql("Siinterface.LocalManager.7", ref strSql) == -1)
            //{
            //    this.Err = "获取SQL语句失败,索引:Siinterface.LocalManager.7";
            //    return null;
            //}
            if (this.ExecQuery(SQL.GetOperationDiagnoseSQL) == -1)
            {
                return null;
            }
            try
            {
                ICDMedicare medicare;

                while (this.Reader.Read())
                {
                    medicare = new ICDMedicare();
                    medicare.ID = this.Reader[0].ToString();
                    medicare.Name = this.Reader[1].ToString();
                    medicare.SpellCode = this.Reader[2].ToString();

                    a.Add(medicare);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return a;
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
            //{977C917E-CB53-4d01-B0EE-4BFEF61FF87F}

            //if (this.Sql.GetSql("Fee.Interface.InsertSIMainInfo_AnShan.1", ref strSql) == -1)
            //if (this.Sql.GetSql("SI.HeNanProvinceSI.InsertSIMainInfo.Inpatient", ref strSql) == -1)
            //{
            //    this.Err = "获得[SI.InsertSIMainInfo.Inpatient]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                #region {E3A957B6-7F69-4274-AF32-24F21495CF27} 参数发生变化

                strSql = string.Format(SQL.InsertInpatientSIMainInfoSQL, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
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
                     Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.Memo, obj.SIMainInfo.OfficalCost, obj.SIMainInfo.PersonType.ID,
                     Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode,
                     Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1,
                     Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2,
                     Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3,
                     Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName);

                #endregion

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

            //if (this.Sql.GetSql("Fee.Interface.InsertSIMainInfo_Outpatient_AnShan.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.InsertSIMainInfo_Outpatient_AnShan.1]对应sql语句出错";
            //    return -1;
            //}

            try
            {
                #region {4DE36869-8BE7-4784-8905-E38B6DBA672D} 参数发生变化

                strSql = string.Format(SQL.InsertOutpatientSIMainInfoSQL, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
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
                    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.Memo, obj.SIMainInfo.OfficalCost, obj.SIMainInfo.PersonType.ID,
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode,
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1,
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2,
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3,
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName);

                #endregion
           

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
        /// 得到住院医保患者基本信息;l
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetSIPersonInfo(string inpatientNo, string balanceState)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
            string strSql = "";
            try
            {
                strSql = string.Format(SQL.GetInpatientInfoByBalanceStateSQL, inpatientNo, balanceState);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }
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
                    //{ED516117-F927-4a1b-85DA-F8E670AD3A90}
                    obj.SIMainInfo.PersonType.ID = Reader[53].ToString();

                    #region {9B82C774-81F5-431d-BD42-50FAD830B950} 取手术码和识别码

                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = Reader[54].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1 = Reader[55].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2 = Reader[56].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3 = Reader[57].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = Reader[58].ToString();

                    #endregion
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
            //if (this.Sql.GetSql("Fee.Interface.GetSIPersonInfo.inPatient.Select.2", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.GetSIPersonInfo.inPatient.Select.2]对应sql语句出错";
            //    return null;
            //}
            try
            {
                strSql = string.Format(SQL.GetInpatientInfoByInvoiceSQL, inpatientNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }
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
                    //{ED516117-F927-4a1b-85DA-F8E670AD3A90}
                    obj.SIMainInfo.PersonType.ID = Reader[52].ToString();

                    #region {0E8BC998-2BF3-481c-A1A0-D5D1D8E76552}

                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = Reader[53].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1 = Reader[54].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2 = Reader[55].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3 = Reader[56].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = Reader[57].ToString();
                    #endregion
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
            //string balNo = "0";
            string balNo = "1";
            try
            {
                strSql = string.Format(SQL.GetOutpatinetInfoByBalanceNOSQL, clinicNO, balNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }
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
                    //{ED516117-F927-4a1b-85DA-F8E670AD3A90}
                    obj.SIMainInfo.PersonType.ID = Reader[52].ToString();

                    #region  {58040FCF-C39B-473e-9D31-077EE31B795F}

                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = Reader[53].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1 = Reader[54].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2 = Reader[55].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3 = Reader[56].ToString();
                    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = Reader[57].ToString();

                    #endregion
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
            //if (this.Sql.GetSql("Fee.Interface.UpdateSiMainInfo.AnShan.Update.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.UpdateSiMainInfo.AnShan.Update.1]对应sql语句出错";
            //    return -1;
            //}
            try
            {


                #region {5A8CE0A2-000C-487e-819F-20325FA5EEC4}
                strSql = string.Format(SQL.UpdateInpatientInfoSQL, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
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
    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid), Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.OverCost, obj.SIMainInfo.OfficalCost,
    Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode, Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode1, Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode2, Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).OperatorCode3, Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, obj.SIMainInfo.ExtendProperty).PrimaryDiagnoseName);
            }

                #endregion {5A8CE0A2-000C-487e-819F-20325FA5EEC4}


            //    strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.SIMainInfo.MedicalType.ID, obj.PID.PatientNO,
            //        obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
            //        obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
            //        obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
            //        obj.SIMainInfo.InDiagnose.Name, obj.PVisit.PatientLocation.Dept.ID, obj.PVisit.PatientLocation.Dept.Name,
            //        obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, obj.PVisit.PatientLocation.Bed.ID,
            //        obj.PVisit.InTime.ToString(), obj.PVisit.InTime.ToString(), obj.SIMainInfo.InDiagnose.ID,
            //        obj.SIMainInfo.InDiagnose.Name, obj.PVisit.OutTime, obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name,
            //        obj.SIMainInfo.BalanceDate.ToString(), obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost,
            //        obj.SIMainInfo.ItemPayCost, obj.SIMainInfo.BaseCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.ItemYLCost,
            //        obj.SIMainInfo.OwnCost, obj.SIMainInfo.OverTakeOwnCost, "", this.Operator.ID,
            //        obj.SIMainInfo.RegNo, obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost,
            //        Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid), Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced), obj.SIMainInfo.OverCost, obj.SIMainInfo.OfficalCost,obj.SIMainInfo.PersonType.ID);
            //}
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
            //if (this.Sql.GetSql("Fee.Interface.inPatient.Back.insert.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.inPatient.Back.insert.1]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                strSql = string.Format(SQL.InsertInpatientInfoForRecallBalance, inpatientNo, invoiceNO, blaNO, operDate, operCode);
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
            //if (this.Sql.GetSql("Fee.Interface.GetBalNo.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.GetBalNo.1]对应sql语句出错";

            //    return "";
            //}
            try
            {
                strSql = string.Format(SQL.GetBalanceNOSQL, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return "";
            }
            if (this.ExecQuery(strSql) == -1)
            {
                return "";
            }
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
            //if (this.Sql.GetSql("Fee.Interface.inPatient.Back.update.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.inPatient.Back.update.1]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                strSql = string.Format(SQL.UpdateToUnValidSQL, patientID, invoiceNO, typeCode);
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
            //if (this.Sql.GetSql("Fee.Interface.inPatient.Back.medicaltype.select.1", ref strSql) == -1)
            //{
            //    this.Err = "没有找到相应的sql语句[Fee.Interface.inPatient.Back.medicaltype.select.1]";
            //    return null;
            //}
            try
            {
                strSql = string.Format(SQL.GetMedcareTypeSQL, patientID, invoiceNO, typeCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            string returnValue = this.ExecSqlReturnOne(strSql);

            if (returnValue == "-1")
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
        public int updateUploadFlagInpatient(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f, string transType)
        {
            string strSql = "";
            //if (this.Sql.GetSql("Fee.Interface.UpdateItemList.AnShan.Update.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.UpdateItemList.AnShan.Update.1]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                strSql = string.Format(SQL.UpdateUploadFlagSQL, f.RecipeNO, f.SequenceNO, transType);
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
            //if (this.Sql.GetSql("Fee.Interface.UpdateSIMainInfoTransType.1", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.UpdateSIMainInfoTransType.1]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                strSql = string.Format(SQL.UpdateTransTypeSQL, transType, inpatentNO, balanceNO);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        //{ED516117-F927-4a1b-85DA-F8E670AD3A90}
        /// <summary>
        /// 更新医保中间表卡串字段remark
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int updateRemark(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            string strSql = "";
            //if (this.Sql.GetSql("Fee.Interface.UpdateSIMainInfoRemark", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.UpdateSIMainInfoRemark]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                strSql = string.Format(SQL.UpdateRemarkInfoSQL, patient.SIMainInfo.Memo, patient.ID);
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




        /// <summary>
        /// 更新住院患者出院诊断信息
        /// </summary>
        /// <param name="extendProperty">扩展诊断</param>
        /// <param name="patientInfo">患者</param>
        /// <returns>返回值，更新行数</returns>
        public int UpdateInpatientOutDiagnoiseInnfo(ExtendProperty extendProperty, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            string strSql = "";
            //if (this.Sql.GetSql("Fee.Interface.UpdateSIMainInfoRemark", ref strSql) == -1)
            //{
            //    this.Err = "获得[Fee.Interface.UpdateSIMainInfoRemark]对应sql语句出错";
            //    return -1;
            //}
            try
            {
                #region {98485611-DADE-4b4f-8DA5-E1827DD4191D}
                //strSql = string.Format(sql.UpdateInpatientOutDiagnosInfo, extendProperty.MainDiagnoseCode,
                //                                           extendProperty.MainDiagnoseName,
                //                                           extendProperty.PrimaryDiagnoseCode,
                //                                           extendProperty.PrimaryDiagnoseName,
                //                                           extendProperty.OperatorCode1,
                //                                           extendProperty.OperatorCode2,
                //                                           extendProperty.OperatorCode3,
                //                                           patientInfo.ID
                //                                           );
                strSql = string.Format(SQL.UpdateInpatientOutDiagnosInfo, extendProperty.MainDiagnoseCode,
                                                         extendProperty.MainDiagnoseName,
                                                         extendProperty.PrimaryDiagnoseCode,
                                                         extendProperty.PrimaryDiagnoseName,
                                                         extendProperty.OperatorCode1,
                                                         extendProperty.OperatorCode2,
                                                         extendProperty.OperatorCode3,
                                                         patientInfo.ID,
                                                         this.Operator.ID 
                                                         ); 
                #endregion
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        #region 河南省医保修改 wbo 2010-07-30

        /// <summary>
        /// 获取医保流水号
        /// </summary>
        /// <param name="flag">0门诊1住院</param>
        /// <returns></returns>
        public string GetNewSINO(string flag)
        {
            string siNO = "";
            string strSql = "";
            if ("0" == flag)
            {
                strSql = SQL.GetOutPatientNOSI;
            }
            else
            {
                strSql = SQL.GetInPatientNOSI;
            }

            try
            {
                siNO = this.ExecSqlReturnOne(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return siNO.PadLeft(7, '0');
        }


        #region 非药品
        /// <summary>
        /// 获得患者的非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>成功:获得费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemLists(string inpatientNO, string pactCode, DateTime beginTime, DateTime endTime, string flag)
        {
            string upload = string.Empty;//是否上传标记

            if (flag.ToUpper() == "ALL")//所有
            {
                upload = "%";
            }
            else if (flag.ToUpper() == "YES")
            {
                upload = "1";
            }
            else
            {
                upload = "0";
            }

            return this.QueryFeeItemLists("Fee.GetMedItemsForInpatient.Where.Upload.1", inpatientNO, pactCode, beginTime.ToString(), endTime.ToString(), upload);
        }

        private ArrayList QueryFeeItemLists(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            //if (this.Sql.GetSql(whereIndex, ref where) == -1)
            //{
            //    this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

            //    return null;
            //}
            where = SQL.GetFeeItemsForInpatientWhere1;
            //sql = this.GetFeeItemsSelectSql();
            sql = SQL.SelectAllFromFeeItem1;
            return this.QueryFeeItemListsBySql(sql + " " + where, args);
        }

        /// <summary>
        /// 获取检索fin_com_itemlist的全部数据的sql
        /// </summary>
        /// <returns>成功:检索fin_com_itemlist的全部数据的sql 失败:null</returns>
        private string GetFeeItemsSelectSql()
        {
            string sql = string.Empty;//SQly语句

            if (this.Sql.GetSql("Fee.SelectAllFromFeeItem.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.SelectAllFromFeeItem.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得费用项目信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得费用项目信息 失败: null</returns>
        private ArrayList QueryFeeItemListsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList feeItemLists = new ArrayList();//费用明细信息集合
            FeeItemList itemList = null;//费用明细实体

            try
            {
                while (this.Reader.Read())
                {
                    itemList = new FeeItemList();

                    itemList.RecipeNO = this.Reader[0].ToString();//0 处方号
                    itemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());//1处方内项目流水号
                    itemList.TransType = (TransTypes)NConvert.ToInt32(Reader[2].ToString());//2交易类型,1正交易，2反交易
                    itemList.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Patient.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Pact.PayKind.ID = this.Reader[5].ToString();//5结算类别
                    itemList.Patient.Pact.ID = this.Reader[6].ToString();//6合同单位
                    itemList.UpdateSequence = NConvert.ToInt32(this.Reader[7].ToString());//7更新库存的流水号(物资)
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.Dept.ID = this.Reader[8].ToString();//8在院科室代码
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[9].ToString();//9护士站代码
                    itemList.RecipeOper.Dept.ID = this.Reader[10].ToString();//10开立科室代码
                    itemList.ExecOper.Dept.ID = this.Reader[11].ToString();//11执行科室代码
                    itemList.StockOper.Dept.ID = this.Reader[12].ToString();//12扣库科室代码
                    itemList.RecipeOper.ID = this.Reader[13].ToString();//13开立医师代码
                    itemList.Item.ID = this.Reader[14].ToString();//14项目代码
                    itemList.Item.MinFee.ID = this.Reader[15].ToString();//15最小费用代码
                    itemList.Compare.CenterItem.ID = this.Reader[16].ToString();//16中心代码
                    itemList.Item.Name = this.Reader[17].ToString();//17项目名称
                    itemList.Item.Price = NConvert.ToDecimal(this.Reader[18].ToString());//18单价
                    itemList.Item.Qty = NConvert.ToDecimal(this.Reader[19].ToString());//19数量
                    itemList.Item.PriceUnit = this.Reader[20].ToString();//20当前单位
                    itemList.UndrugComb.ID = this.Reader[21].ToString();//21组套代码
                    itemList.UndrugComb.Name = this.Reader[22].ToString();//22组套名称
                    itemList.FT.TotCost = NConvert.ToDecimal(this.Reader[23].ToString());//23费用金额
                    itemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[24].ToString());//24自费金额
                    itemList.FT.PayCost = NConvert.ToDecimal(this.Reader[25].ToString());//25自付金额
                    itemList.FT.PubCost = NConvert.ToDecimal(this.Reader[26].ToString());//26公费金额
                    itemList.FT.RebateCost = NConvert.ToDecimal(this.Reader[27].ToString());//27优惠金额
                    itemList.SendSequence = NConvert.ToInt32(this.Reader[28].ToString());//28出库单序列号
                    itemList.PayType = (PayTypes)NConvert.ToInt32(this.Reader[29].ToString());//29收费状态
                    itemList.IsBaby = NConvert.ToBoolean(this.Reader[30].ToString());//30是否婴儿用
                    (itemList.Order).OrderType.ID = this.Reader[32].ToString();
                    itemList.Invoice.ID = this.Reader[33].ToString();//33结算发票号
                    itemList.BalanceNO = NConvert.ToInt32(this.Reader[34].ToString());//34结算序号
                    itemList.ChargeOper.ID = this.Reader[36].ToString();//36划价人
                    itemList.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());//37划价日期
                    itemList.MachineNO = this.Reader[39].ToString();//39设备号
                    itemList.ExecOper.ID = this.Reader[40].ToString();//40执行人代码
                    itemList.ExecOper.OperTime = NConvert.ToDateTime(this.Reader[41].ToString());//41执行日期
                    itemList.FeeOper.ID = this.Reader[42].ToString();//42计费人
                    itemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[43].ToString());//43计费日期
                    itemList.AuditingNO = this.Reader[45].ToString();//45审核序号
                    itemList.Order.ID = this.Reader[46].ToString();//46医嘱流水号
                    itemList.ExecOrder.ID = this.Reader[47].ToString();//47医嘱执行单流水号
                    //itemList.Item.IsPharmacy = false;
                    //itemList.Item.ItemType = //HISFC.Object.Base.EnumItemType.UnDrug;
                    itemList.NoBackQty = NConvert.ToDecimal(this.Reader[48].ToString());//48可退数量
                    itemList.BalanceState = this.Reader[49].ToString();//49结算状态
                    itemList.FTRate.ItemRate = NConvert.ToDecimal(this.Reader[50].ToString());//50收费比例
                    itemList.FeeOper.Dept.ID = this.Reader[51].ToString();//51收费员科室
                    itemList.FTSource = this.Reader[54].ToString();
                    if (itemList.Item.PackQty == 0)
                    {
                        itemList.Item.PackQty = 1;
                    }
                    itemList.Item.ItemType = (Neusoft.HISFC.Models.Base.EnumItemType)(NConvert.ToInt32(this.Reader[58]));
                    itemList.CancelRecipeNO = this.Reader[59].ToString();//59原处方号
                    feeItemLists.Add(itemList);
                }

                this.Reader.Close();

                return feeItemLists;
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }
        #endregion

        #region 药品
        /// <summary>
        /// 获得患者的药品费用信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>成功:获得药品费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemLists(string inpatientNO, string pactCode, DateTime beginTime, DateTime endTime, string flag)
        {
            string upload = string.Empty;//上传标志

            if (flag.ToUpper() == "ALL")//所有
            {
                upload = "%";
            }
            else if (flag.ToUpper() == "YES")
            {
                upload = "1";
            }
            else
            {
                upload = "0";
            }

            return this.QueryMedItemLists("Fee.GetMedItemsForInpatient.Where.Upload.1", inpatientNO, pactCode, beginTime.ToString(), endTime.ToString(), upload);
        }

        /// <summary>
        /// 获得药品费用项目信息
        /// </summary>
        /// <param name="whereIndex">where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得药品费用项目信息 失败: null</returns>
        private ArrayList QueryMedItemLists(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            //if (this.Sql.GetSql(whereIndex, ref where) == -1)
            //{
            //    this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

            //    return null;
            //}
            where = SQL.GetMedItemsForInpatientWhere1;
            //sql = this.GetMedItemListSelectSql();
            sql = SQL.SelectAllFromMedItem1;

            return this.QueryMedItemListsBySql(sql + " " + where, args);
        }


        /// <summary>
        /// 获取检索fin_com_medicinelist的全部数据的sql
        /// </summary>
        /// <returns>成功: 获取检索fin_com_medicinelist的全部数据的sql 失败:null</returns>
        public string GetMedItemListSelectSql()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.SelectAllFromMedItem.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.SelectAllFromMedItem.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得药品费用项目信息
        /// </summary>
        /// <param name="sql">SQl语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得药品费用项目信息 失败: null</returns>
        public ArrayList QueryMedItemListsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList medItemLists = new ArrayList();//药品明细集合
            FeeItemList itemList = null;//药品明细实体

            try
            {
                while (this.Reader.Read())
                {
                    itemList = new FeeItemList();

                    Neusoft.HISFC.Models.Pharmacy.Item pharmacyItem = new Neusoft.HISFC.Models.Pharmacy.Item();
                    itemList.Item = pharmacyItem;

                    itemList.RecipeNO = this.Reader[0].ToString();//0 处方号
                    itemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());//1处方内项目流水号
                    itemList.TransType = (TransTypes)NConvert.ToInt32(this.Reader[2].ToString());//2交易类型,1正交易，2反交易
                    itemList.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Patient.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Pact.PayKind.ID = this.Reader[5].ToString();//5结算类别
                    itemList.Patient.Pact.ID = this.Reader[6].ToString();//6合同单位
                    itemList.UpdateSequence = NConvert.ToInt32(this.Reader[7].ToString());//7更新库存的流水号(物资)
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.Dept.ID = this.Reader[8].ToString();//8在院科室代码
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[9].ToString();//9护士站代码
                    itemList.RecipeOper.Dept.ID = this.Reader[10].ToString();//10开立科室代码
                    itemList.ExecOper.Dept.ID = this.Reader[11].ToString();//11执行科室代码
                    itemList.StockOper.Dept.ID = this.Reader[12].ToString();//12扣库科室代码
                    itemList.RecipeOper.ID = this.Reader[13].ToString();//13开立医师代码
                    itemList.Item.ID = this.Reader[14].ToString();//14项目代码
                    itemList.Item.MinFee.ID = this.Reader[15].ToString();//15最小费用代码
                    itemList.Compare.CenterItem.ID = this.Reader[14].ToString();//16中心代码
                    itemList.Item.Name = this.Reader[17].ToString();//17项目名称
                    itemList.Item.Price = NConvert.ToDecimal(this.Reader[18].ToString());//18单价1
                    itemList.Item.Qty = NConvert.ToDecimal(this.Reader[19].ToString());//9数量
                    itemList.Item.PriceUnit = this.Reader[20].ToString();//20当前单位
                    itemList.Item.PackQty = NConvert.ToDecimal(this.Reader[21].ToString());//21包装数量
                    itemList.Days = NConvert.ToDecimal(this.Reader[22].ToString());//22付数
                    itemList.FT.TotCost = NConvert.ToDecimal(this.Reader[23].ToString());//23费用金额
                    itemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[24].ToString());//24自费金额
                    itemList.FT.PayCost = NConvert.ToDecimal(this.Reader[25].ToString());//25自付金额
                    itemList.FT.PubCost = NConvert.ToDecimal(this.Reader[26].ToString());//26公费金额
                    itemList.FT.RebateCost = NConvert.ToDecimal(this.Reader[27].ToString());//27优惠金额
                    itemList.SendSequence = NConvert.ToInt32(this.Reader[28].ToString());//28出库单序列号
                    itemList.PayType = (PayTypes)NConvert.ToInt32(this.Reader[29].ToString());//29收费状态
                    itemList.IsBaby = NConvert.ToBoolean(this.Reader[30].ToString());//30是否婴儿用
                    (itemList.Order).OrderType.ID = this.Reader[32].ToString();//32出院带疗标记
                    itemList.Invoice.ID = this.Reader[33].ToString();//33结算发票号
                    itemList.BalanceNO = NConvert.ToInt32(this.Reader[34].ToString());//34结算序号
                    itemList.ChargeOper.ID = this.Reader[36].ToString();//36划价人
                    itemList.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());//37划价日期
                    pharmacyItem.Product.IsSelfMade = NConvert.ToBoolean(this.Reader[38].ToString());//38自制标识
                    pharmacyItem.Quality.ID = this.Reader[39].ToString();//39药品性质
                    itemList.ExecOper.ID = this.Reader[40].ToString();//40发药人代码
                    itemList.ExecOper.OperTime = NConvert.ToDateTime(this.Reader[41].ToString());//41发药日期
                    itemList.FeeOper.ID = this.Reader[42].ToString();//42计费人
                    itemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[43].ToString());//43计费日期
                    itemList.AuditingNO = this.Reader[45].ToString();//45审核序号
                    itemList.Order.ID = this.Reader[46].ToString();//46医嘱流水号
                    itemList.ExecOrder.ID = this.Reader[47].ToString();//47医嘱执行单流水号
                    pharmacyItem.Specs = this.Reader[48].ToString();//规格
                    pharmacyItem.Type.ID = this.Reader[49].ToString();//49药品类别
                    //pharmacyItem.IsPharmacy = true;
                    itemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                    itemList.NoBackQty = NConvert.ToDecimal(this.Reader[50].ToString());//50可退数量
                    itemList.BalanceState = this.Reader[51].ToString();//51结算状态
                    itemList.FTRate.ItemRate = NConvert.ToDecimal(this.Reader[52].ToString());//52收费比例
                    itemList.FTRate.OwnRate = itemList.FTRate.ItemRate;

                    itemList.FeeOper.Dept.ID = this.Reader[53].ToString();//53收费员科室
                    //itemList.Item.IsPharmacy = true;
                    itemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                    itemList.FTSource = this.Reader[56].ToString();

                    itemList.CancelRecipeNO = this.Reader[60].ToString();//原处方号

                    medItemLists.Add(itemList);
                }

                this.Reader.Close();

                return medItemLists;
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }
        #endregion

        #region 更新住院主表费用
        /// <summary>
        /// 更新住院主表费用
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int UpdateInMainInfoCost(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            string strSql = " UPDATE fin_ipr_inmaininfo" +
                               " SET TOT_COST = '{1}'," +
                               " OWN_COST = '{2}'," +
                               " PAY_COST = '{3}'," +
                               " PUB_COST = '{4}'," +
                               " FREE_COST = '{5}'" +
                             " WHERE inpatient_no = '{0}'" +
                               " AND in_state in ('I', 'B', 'R', 'C')";
            try
            {
                strSql = string.Format(strSql,
                                              patient.ID,
                                              patient.SIMainInfo.TotCost.ToString(),
                                              patient.SIMainInfo.OwnCost.ToString(),
                                              patient.SIMainInfo.PayCost.ToString(),
                                              patient.SIMainInfo.PubCost.ToString(),
                                              (patient.FT.PrepayCost - patient.SIMainInfo.OwnCost).ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion


        /// <summary>
        /// 提取所有医保诊断编码
        /// </summary>
        /// <param name="pactCode"></param>
        /// <returns>医保诊断编码</returns>
        public ArrayList GetDiagnoseByPactCode(string pactCode)
        {
            string strSql = @"select a.seq_id,
a.icd_code,
a.icd_name,
a.icd_spell 
from MET_COM_ICDMEDICARE a
where a.pack_code = '{0}'";
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Base.Const obj = null;
            try
            {
                strSql = string.Format(strSql, pactCode);
                if (ExecQuery(strSql) == -1) return null;
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
    }
}
