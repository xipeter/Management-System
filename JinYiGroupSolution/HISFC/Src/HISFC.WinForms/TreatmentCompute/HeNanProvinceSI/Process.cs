using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace HeNanProvinceSI
{
    /// <summary>
    /// [功能描述: 医保接口类]<br></br>
    /// [创建者:   王宇]<br></br>
    /// [创建时间: 2006-10-12]<br></br>
    /// <说明>
    ///    医保接口类
    /// </说明>
    /// <修改记录>
    ///     <修改时间>2010-08-01</修改时间>
    ///     <修改内容>
    ///            河南省医保
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public class Process : Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare 
    {      
        #region 变量
        
        /// <summary>
        /// 是否已经初始化
        /// </summary>
        public static bool isInit = false;

        /// <summary>
        /// 错误信息
        /// </summary>
        protected string errText = string.Empty;

        /// <summary>
        /// 错误编码
        /// </summary>
        protected string errCode = string.Empty;
        /// <summary>
        /// 扩展属性KEY
        /// </summary>
        public const string EXTEND_PROPERTY_KEY = "HeNanProvinceSI";
        /// <summary>
        /// 日期格式
        /// </summary>
        protected const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
        /// <summary>
        /// 医疗机构编码
        /// </summary>
        private static  string HOSPITAL_NO = string.Empty ;
        /// <summary>
        /// 医院等级
        /// </summary>
        private static  string HOSPITAL_GRADE = string.Empty;
        /// <summary>
        /// 共享目录
        /// </summary>
        private static string FILE_PATH = string.Empty;
        /// <summary>
        /// 医保业务层
        /// </summary>
        private LocalManager localManager = new LocalManager();
        private Neusoft.HISFC.BizLogic.Fee.Interface interfaceManager = new Neusoft.HISFC.BizLogic.Fee.Interface();         
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrage = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        #endregion

        public Process()
        {
            //设置配置文件
            ReadSISetting();   
        }

        /// <summary>
        /// 住院患者出院结算
        /// </summary>
        /// <param name="p">住院患者基本信息实体</param>
        /// <param name="feeDetails">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo p, ref System.Collections.ArrayList feeDetails)
        {
            try
            {
                //查找登记信息
                Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
                this.localManager.SetTrans(this.trans);
                myPatient = this.localManager.GetSIPersonInfo(p.ID, "0");
                if (myPatient == null || myPatient.ID == "" || myPatient.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到住院登记信息";
                    return -1;
                }

                myPatient.SIMainInfo.InvoiceNo = p.SIMainInfo.InvoiceNo;
                myPatient.SIMainInfo.BalanceDate = this.localManager.GetDateTimeFromSysDateTime();
                myPatient.SIMainInfo.IsBalanced = true;
                myPatient.SIMainInfo.IsValid = true;

                if (this.localManager.UpdateSiMainInfo(myPatient) < 0)
                {
                    this.localManager.Err = "结算时更新中间表失败：" + this.localManager.Err;
                    return -1;
                }
            }
            catch (Exception e)
            {
                this.errText = e.Message;

                return -1;
            }
            finally
            {

            }
            return 1;
        }

        /// <summary>
        /// 门诊患者收费结算
        /// </summary>
        /// <param name="r">挂号基本信息实体</param>
        /// <param name="feeDetails">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            //StringBuilder dataBuffer = new StringBuilder(1024);
            //try
            //{   
            //    //判断疾病码
            //    Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
            //    this.localManager.SetTrans(this.trans);
            //    DateTime currentDate = localManager.GetDateTimeFromSysDateTime();
            //    myRegister = this.localManager.GetSIPersonInfoOutPatient(r.ID);
            //    if (myRegister == null || myRegister.ID == "" || myRegister.ID == string.Empty)
            //    {
            //        this.errText = "待遇接口没有找到挂号信息";
            //        return -1;
            //    }
            //    r.SIMainInfo.MedicalType.ID = myRegister.SIMainInfo.MedicalType.ID;
            //    #region 处理生育保险
            //    #region 处理 特殊病等需要结算录诊断的医保类型
            //    #endregion
            //    if (string.IsNullOrEmpty(r.SIMainInfo.OutDiagnose.ID))
            //    {
            //        Control.frmSiPobOutPatient frmSiPob = new HeNanProvinceSI.Control.frmSiPobOutPatient();
            //        frmSiPob.Patient = r;
            //        frmSiPob.Text = "市保—门诊结算";
            //        frmSiPob.isInDiagnose = false;
            //        frmSiPob.ShowDialog();
            //        DialogResult resultNew = frmSiPob.DialogResult;
            //        if (resultNew == DialogResult.OK)
            //        {
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    if (r.SIMainInfo.MedicalType.ID == "43")
            //    {
            //        if (MessageBox.Show("节育患者本次是否做定额结算？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            r.SIMainInfo.ProceateLastFlag = true;
            //        }
            //        else
            //        {
            //            r.SIMainInfo.ProceateLastFlag = false;
            //        }
            //    }
            //    #endregion
            //    //调用接口结算方法                
            //        int returnValue = Functions.ExpenseCalc(1
            //            , "1"
            //            , r.SIMainInfo.MedicalType.ID
            //            , r.ID
            //            , r.SIMainInfo.InvoiceNo
            //            , r.SIMainInfo.Memo
            //            , r.InputOper.ID
            //            , currentDate.ToString("yyyyMMddHHmmss")
            //            , Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, r.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode
            //            ,r.SIMainInfo.OutDiagnose.Name
            //            , Neusoft.FrameWork.Function.NConvert.ToInt32(r.SIMainInfo.ProceateLastFlag)
            //            , r.SIMainInfo.OutDiagnose.ID
            //            , Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, r.SIMainInfo.ExtendProperty).OperatorCode1
            //            , Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, r.SIMainInfo.ExtendProperty).OperatorCode2
            //            , Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, r.SIMainInfo.ExtendProperty).OperatorCode3
            //            , dataBuffer);             
            //    if (returnValue != 0)
            //    {
            //        this.errText = dataBuffer.ToString();
            //        return -1;
            //    }
            //    string[] temp = this.SplitStringToChar(dataBuffer.ToString());
            //    if (temp == null || temp.Length == 0)
            //    {
            //        this.errText = "拆分字符串错误!";
            //        return -1;
            //    }
            //    //医疗费总额
            //    r.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);
            //    //帐户支出金额
            //    r.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);
            //    //现金总额
            //    r.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);
            //    if (r.SIMainInfo.MedicalType.ID == "42" 
            //        || r.SIMainInfo.MedicalType.ID == "43" 
            //        || r.SIMainInfo.MedicalType.ID == "44" 
            //        || r.SIMainInfo.MedicalType.ID == "45")
            //    {
            //        //现金总额 
            //        r.SIMainInfo.OwnCost = r.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);
            //    }
            //    //大额现金
            //    r.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);
            //    /*
            //     * 暂时使用"公务员补助"OFFICIAL_COST与"医药机构分担金额"HosCost同时来存储"特困救助支付金额"
            //     * 前台已经把公务员补助加到统筹里了，那么这样的改话前台就不用动了
            //     * 如果以后市保增加公务员补助的话就只用OVERTAKE_OWNCOST来存储"特困救助支付金额"，那时再改前台
            //     */
            //    //特困救助支付金额
            //    r.SIMainInfo.OfficalCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);
            //    //特困救助支付金额
            //    r.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);
            //    r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.PayCost - r.SIMainInfo.OwnCost - r.SIMainInfo.OverCost - r.SIMainInfo.HosCost; 
            //    //插入本地表
            //    string balanceNO = this.localManager.GetBalNo(r.ID);
            //    if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
            //    {
            //        balanceNO = "0";
            //    }
            //    r.SIMainInfo.BalNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
            //    r.SIMainInfo.IsValid = true;
            //    returnValue = this.localManager.InsertSIMainInfo(r);
            //    if (returnValue < 0)
            //    {
            //        this.errText = this.localManager.Err;
            //        return -1;
            //    }
            //    returnValue = this.localManager.updateTransType("1", r.ID, r.SIMainInfo.BalNo);
            //    if (returnValue < 0)
            //    {
            //        this.errText = this.localManager.Err;
            //        return -1;
            //    }
            //    #region {261D97BD-935D-4bd4-AB42-97BCD8A4BB1F}
            //    r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.PayCost - r.SIMainInfo.OwnCost;               
            //    #endregion
            //}
            //catch (Exception e)
            //{
            //    this.errText = e.Message;
            //    return -1;
            //}
            //finally
            //{
            //    dataBuffer = null;
            //}
            return 1;
        }

        /// <summary>
        /// 门诊退费（半退）
        /// </summary>
        /// <param name="r"></param>
        /// <param name="feeDetails"></param>
        /// <returns></returns>
        public int CancelBalanceOutpatientHalf(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            this.errText = "医保患者必须全退";
            return -1;
        }

        /// <summary>
        /// 住院结算招回(最终结算)
        /// </summary>
        /// <param name="p">住院患者基本信息</param>
        /// <param name="feeDetails">费用明细信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int CancelBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo p, ref System.Collections.ArrayList feeDetails)
        {
            this.errText = "省保患者不允许召回！";
            return -1;
        }

        /// <summary>
        /// 门诊退费
        /// </summary>
        /// <param name="r">门诊挂号基本信息实体</param>
        /// <param name="feeDetails">门诊费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int CancelBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            this.errText = "省保患者不允许退费！";
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public int DeleteUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return 1;
        }

        public int DeleteUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            return 1;
        }

        public int DeleteUploadedFeeDetailsAllInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        public int DeleteUploadedFeeDetailsAllOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1;
        }

        public int DeleteUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int DeleteUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        /// <summary>
        /// 无费退院
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int CancelRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return this.processInpatientReg(patient, 0, -1);
        }

        /// <summary>
        /// 出院召回
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return "河南省医疗保险";
            }
        }

        /// <summary>
        /// 错误编码
        /// </summary>
        public string ErrCode
        {
            get
            {
                return this.errCode;
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg
        {
            get
            {
                return this.errText;
            }
        }

        /// <summary>
        /// 获得住院医保患者读卡信息 信息大部分存储再Patient.SiInmaininfo属性种
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int GetRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        private string[] SplitStringToChar(string dataBuffer)
        {
            if (dataBuffer == null)
            {
                return null;
            }
            dataBuffer = dataBuffer.Replace("\0", string.Empty);
            return dataBuffer.Split('|');
        }

        /// <summary>
        /// 读卡后,设置住院患者基本信息
        /// </summary>
        /// <param name="r">患者挂号信息实体</param>
        /// <param name="readCardType">当前读卡状态</param>
        /// <param name="dataBuffer">读卡返回的信息字符串</param>
        private int SetInpatientRegInfo(Neusoft.HISFC.Models.RADT.PatientInfo p, ReadCardTypes readCardType, string dataBuffer)
        {
            return 1;
        }

        /// <summary>
        /// 读卡后,设置门诊患者基本信息
        /// </summary>
        /// <param name="r">患者挂号信息实体</param>
        /// <param name="readCardType">当前读卡状态</param>
        /// <param name="dataBuffer">读卡返回的信息字符串</param>
        private int SetOutpatientRegInfo(Neusoft.HISFC.Models.Registration.Register r, ReadCardTypes readCardType, string dataBuffer)
        {
            return 1;
        }

        /// <summary>
        /// 获得医保门诊患者基本信息,通过读取IC卡形式实现,先读取患者基本信息,再读取患者
        /// 账户基本信息,读卡2次
        /// </summary>
        /// <param name="r">门诊挂号患者基本信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int GetRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1;
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        //{ED516117-F927-4a1b-85DA-F8E670AD3A90}2008-1-1元旦升级
        public int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
        //    StringBuilder dataBuffer = new StringBuilder(1024);

        //    try
        //    {
        //        //查找登记信息
        //        Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        //        this.localManager.SetTrans(this.trans);
        //        myPatient = this.localManager.GetSIPersonInfo(patient.ID, "0");
        //        if (myPatient == null || myPatient.ID == "" || myPatient.ID == string.Empty)
        //        {
        //            this.errText = "待遇接口没有找到住院登记信息";
        //            return -1;
        //        }
        //        //if is_medtype = '42' or is_medtype = '44' or is_medtype = '45' then
        //        //    gf_Msg("该医疗类别患者不能进行中途结帐!",211)
        //        //    return -1
        //        //end if
        //        #region 生育、节育类医疗类别患者不能进行中途结帐
        //        if (myPatient.SIMainInfo.MedicalType.ID == "42" || myPatient.SIMainInfo.MedicalType.ID == "44" || myPatient.SIMainInfo.MedicalType.ID == "45")
        //        {
        //            this.errText = "生育、节育类医疗类别患者不能进行中途结帐!";
        //            return -1;
        //        }
        //        #endregion
        //        #region 判断卡号与数据库中的卡号是否一致 by耿晓雷
        //        string[] oldData = this.SplitStringToChar(myPatient.SIMainInfo.Memo);
        //        if (oldData[10].ToString() != patient.SIMainInfo.ICCardCode.ToString())
        //        {
        //            this.errText = "该患者医保卡号与医保数据库中卡号不符!";
        //            return -1;
        //        }
        //        #endregion

        //        patient.SIMainInfo.MedicalType.ID = myPatient.SIMainInfo.MedicalType.ID;
        //        patient.SIMainInfo.Memo = myPatient.SIMainInfo.Memo;
        //        patient.SIMainInfo.ClinicDiagNose = myPatient.ClinicDiagnose;
        //        patient.SIMainInfo.InDiagnose.ID = myPatient.SIMainInfo.InDiagnose.ID;
        //        patient.SIMainInfo.InDiagnose.Name = myPatient.SIMainInfo.InDiagnose.Name;
        //        patient.SIMainInfo.OutDiagnose.ID = myPatient.SIMainInfo.OutDiagnose.ID;
        //        patient.SIMainInfo.OutDiagnose.Name = myPatient.SIMainInfo.OutDiagnose.Name;
                

        //        ////调用接口预结算方法
        //        //int returnValue = Functions.ExpenseCalc(1, "2", patient.SIMainInfo.MedicalType.ID, patient.ID, patient.SIMainInfo.InvoiceNo,
        //        //    patient.SIMainInfo.Memo, patient.SIMainInfo.OperInfo.ID, DateTime.Now.ToString(DATE_TIME_FORMAT), patient.SIMainInfo.OutDiagnose.ID,
        //        //    patient.SIMainInfo.OutDiagnose.Name, 1, dataBuffer);

        //         #region {01176641-8E37-4926-B1B5-6E323037893A} 从诊断表里出去识别码和手术码
        //        Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode;
        //        Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, patient.SIMainInfo.ExtendProperty).OperatorCode1 = Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode1;
        //        Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, patient.SIMainInfo.ExtendProperty).OperatorCode2 = Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode2;
        //        Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, patient.SIMainInfo.ExtendProperty).OperatorCode3 = Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode3;
        //        #endregion {01176641-8E37-4926-B1B5-6E323037893A}
        //         //调用接口预结算方法
        //        #region {9E56EA5F-7AE8-4959-B661-C85639CAD001} 结算方法改变

               
        //        int returnValue = Functions.ExpenseCalc(1, "2", patient.SIMainInfo.MedicalType.ID, patient.ID, patient.SIMainInfo.InvoiceNo,
        //            patient.SIMainInfo.Memo, patient.SIMainInfo.OperInfo.ID, DateTime.Now.ToString(DATE_TIME_FORMAT),
        //            Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode,
        //            patient.SIMainInfo.OutDiagnose.Name, 1, patient.SIMainInfo.OutDiagnose.ID,
        //            Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode1,
        //            Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode2,
        //            Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, myPatient.SIMainInfo.ExtendProperty).OperatorCode3, dataBuffer);

        //        #endregion {9E56EA5F-7AE8-4959-B661-C85639CAD001}


        //        if (returnValue != 0)
        //        {
        //            this.errText = dataBuffer.ToString();

        //            return -1;
        //        }

        //        string[] temp = this.SplitStringToChar(dataBuffer.ToString());

        //        if (temp == null || temp.Length == 0)
        //        {
        //            this.errText = "拆分字符串错误!";

        //            return -1;
        //        }


        //        patient.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
        //        patient.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
        //        patient.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

        //        // decimal returnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);//返还患者金额
        //        //生育保险处理
        //        decimal lifeCost = 0;
        //        //         if (p.SIMainInfo.MedicalType.ID == "42" || p.SIMainInfo.MedicalType.ID == "43" || p.SIMainInfo.MedicalType.ID == "44" || p.SIMainInfo.MedicalType.ID == "45")
        //        if (patient.SIMainInfo.MedicalType.ID == "42" || patient.SIMainInfo.MedicalType.ID == "44" || patient.SIMainInfo.MedicalType.ID == "45")
        //        {
        //            patient.SIMainInfo.OwnCost = patient.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);//现金总额 
        //        }

        //        patient.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

        //        #region 2007-12-26 元旦市保改造
        //        /*
        //             * 暂时使用"公务员补助"OFFICIAL_COST与"医药机构分担金额"HosCost同时来存储"特困救助支付金额"
        //             * 前台已经把公务员补助加到统筹里了，那么这样的改话前台就不用动了
        //             * 如果以后市保增加公务员补助的话就只用OVERTAKE_OWNCOST来存储"特困救助支付金额"，那时再改前台
        //             */
        //        patient.SIMainInfo.OfficalCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);
        //        patient.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);
        //        #endregion

        //        patient.SIMainInfo.PubCost = patient.SIMainInfo.TotCost - patient.SIMainInfo.PayCost - patient.SIMainInfo.OwnCost - patient.SIMainInfo.OverCost - patient.SIMainInfo.HosCost;


        //        //插入本地数据库



        //        if (this.trans == null)
        //        {
        //            this.errText = "事务不能为空";
        //        }
        //        else
        //        {
        //            this.localManager.SetTrans(this.trans);
        //            patient.SIMainInfo.IsBalanced = true;
        //            patient.SIMainInfo.IsValid = true;
        //            returnValue = this.localManager.UpdateSiMainInfo(patient);
        //            if (returnValue <= 0)
        //            {
        //                this.errText = this.localManager.Err;
        //                return -1;
        //            }
        //            Neusoft.HISFC.Models.RADT.PatientInfo newPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        //            newPatient = patient.Clone();

        //            string balanceNO = this.localManager.GetBalNo(newPatient.ID);
        //            if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
        //            {
        //                balanceNO = "0";
        //            }
        //            balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
        //            newPatient.SIMainInfo.BalNo = balanceNO;
        //            newPatient.SIMainInfo.IsValid = true;
        //            newPatient.SIMainInfo.IsBalanced = false;
        //            returnValue = this.localManager.InsertSIMainInfo(newPatient);
        //            if (returnValue < 0)
        //            {
        //                this.errText = this.localManager.Err;
        //                return -1;
        //            }
        //            returnValue = this.localManager.updateTransType("1", newPatient.ID, newPatient.SIMainInfo.BalNo);
        //            if (returnValue < 0)
        //            {
        //                this.errText = this.localManager.Err;
        //                return -1;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        this.errText = e.Message;

        //        return -1;
        //    }
        //    finally
        //    {
        //        dataBuffer = null;
        //    }
            return 1;
        }

        public int ModifyUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            if (patient.PVisit.InState.ToString() != "B")
            {
                return 1;
            }

            try
            {
                //查找登记信息
                Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
                this.localManager.SetTrans(this.trans);
                myPatient = this.localManager.GetSIPersonInfo(patient.ID, "0");
                if (myPatient == null || myPatient.ID == "" || myPatient.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到住院登记信息";
                    return -1;
                }
                //直接从医保返回的文件中读取
                int result = Functions.GetSiResult(FILE_PATH, myPatient.SIMainInfo.RegNo, ref myPatient, ref errText);
                if (result != 1)
                {
                    this.errText = "读取医保返回值失败，请确认是否已经在医保端进行结算！" + this.errText;
                    return -1;
                }

                patient.SIMainInfo.TotCost = myPatient.SIMainInfo.TotCost;
                patient.SIMainInfo.PayCost = myPatient.SIMainInfo.PayCost;
                patient.SIMainInfo.PubCost = myPatient.SIMainInfo.PubCost;
                patient.SIMainInfo.OwnCost = myPatient.SIMainInfo.OwnCost;
                patient.SIMainInfo.OverCost = myPatient.SIMainInfo.OverCost;
                patient.SIMainInfo.IndividualBalance = myPatient.SIMainInfo.IndividualBalance;
                patient.SIMainInfo.BaseCost = myPatient.SIMainInfo.BaseCost;

                if (this.localManager.UpdateSiMainInfo(myPatient) < 0)
                {
                    this.localManager.Err = "预结算更新中间表失败：" + this.ErrMsg;
                    return -1;
                }
                //更新住院主表
                if (this.localManager.UpdateInMainInfoCost(myPatient) < 0)
                {
                    this.localManager.Err = "费用上传成功，但更新住院主表失败：" + this.ErrMsg;
                    return -1;
                }
            }
            catch (Exception e)
            {
                this.errText = e.Message;

                return -1;
            }
            finally
            {

            }

            return 1; ;
        }

        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int QueryBlackLists(ref System.Collections.ArrayList blackLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryDrugLists(ref System.Collections.ArrayList drugLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryUndrugLists(ref System.Collections.ArrayList undrugLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            return 1;
        }

        public void SetTrans(System.Data.IDbTransaction t)
        {
            this.trans = t;
            myTrans = t;
        }
        public static System.Data.IDbTransaction myTrans = null;
        private System.Data.IDbTransaction trans = null;
        public System.Data.IDbTransaction Trans
        {
            set { this.Trans = value; }
        }

        #region 单条住院明细上传
        /// <summary>
        /// 单条住院明细上传
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public int UpdateFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return 1;
        }
        #endregion

        /// <summary>
        /// 住院上传明细
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <param name="f">住院患者费用明细信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return this.UploadFeeItemListInpatient(patient, f, "1");
        }

        /// <summary>
        /// 门诊上传明细(单条)
        /// </summary>
        /// <param name="r">门诊挂号基本信息实体</param>
        /// <param name="f">门诊费用基本信息实体</param>
        /// <returns>成功1  失败 -1</returns>
        public int UploadFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            return this.UploadFeeItemList(r, f, "1");
        }

        /// <summary>
        /// 批量上传住院患者费用
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <param name="feeDetails">住院患者费用信息实体集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            if (feeDetails == null || feeDetails.Count == 0)
            {
                this.errText = "没有费用明细可以上传!";

                return -1;
            }

            int returnValue = 0;

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in feeDetails)
            {
                returnValue = this.UploadFeeItemListInpatient(patient, f, "1");

                if (returnValue != 1)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 批量上传门诊患者费用
        /// </summary>
        /// <param name="r">挂号基本信息实体</param>
        /// <param name="feeDetails">门诊患者费用信息实体集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            if (feeDetails == null || feeDetails.Count == 0)
            {
                this.errText = "没有费用明细可以上传!";
                return -1;
            }
            //处方号
            if (this.trans != null)
            {
                this.feeIntegrage.SetTrans(this.trans);
            }
            if (this.feeIntegrage.SetRecipeNOOutpatient(r, feeDetails, ref errText) == false)
            {
                this.errText = this.feeIntegrage.Err;
                return -1;
            }
            
            try
            { 
                Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
                this.localManager.SetTrans(this.trans);
                DateTime currentDate = localManager.GetDateTimeFromSysDateTime();
                myRegister = this.localManager.GetSIPersonInfoOutPatient(r.ID);
                if (myRegister == null || myRegister.ID == "" || myRegister.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到挂号信息";
                    return -1;
                }

                //插入本地表
                this.localManager.SetTrans(this.trans);
                string balanceNO = this.localManager.GetBalNo(r.ID);
                if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                {
                    balanceNO = "0";
                }
                r.SIMainInfo.BalNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                r.SIMainInfo.IsValid = true;
                myRegister.SIMainInfo.BalNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                myRegister.SIMainInfo.IsValid = true;
                myRegister.SIMainInfo.IsBalanced = true;
                myRegister.DoctorInfo.Templet.Dept = r.DoctorInfo.Templet.Dept.Clone();
                myRegister.SIMainInfo.InvoiceNo = r.SIMainInfo.InvoiceNo;
                int returnValue = this.localManager.InsertSIMainInfo(myRegister);
                if (returnValue < 0)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }
                returnValue = this.localManager.updateTransType("1", myRegister.ID, myRegister.SIMainInfo.BalNo);
                if (returnValue < 0)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }

                returnValue = Functions.ExportOutpatientFeedetail(FILE_PATH, myRegister.SIMainInfo.RegNo, myRegister, feeDetails, ref this.errText);
                if (returnValue != 1)
                {
                    return -1;
                }
                returnValue = Functions.GetSiResult(FILE_PATH, myRegister.SIMainInfo.RegNo, ref myRegister, ref this.errText);
                while (returnValue != 1)
                {
                    returnValue = Functions.GetSiResult(FILE_PATH, myRegister.SIMainInfo.RegNo, ref myRegister, ref this.errText);
                    if (returnValue == -2)
                    {
                        //本次查询未查到结果数据
                    }
                    //超时机制
                }

                r.SIMainInfo.TotCost = myRegister.SIMainInfo.TotCost;
                r.SIMainInfo.PayCost = myRegister.SIMainInfo.PayCost;
                r.SIMainInfo.PubCost = myRegister.SIMainInfo.PubCost;
                r.SIMainInfo.OwnCost = myRegister.SIMainInfo.OwnCost;
                r.SIMainInfo.OverCost = myRegister.SIMainInfo.OverCost;
                r.SIMainInfo.IndividualBalance = myRegister.SIMainInfo.IndividualBalance;
                r.SIMainInfo.BaseCost = myRegister.SIMainInfo.BaseCost;
            }
            catch (Exception e)
            {
                this.errText = e.Message;
                return -1;
            }
            finally
            {

            }

            return 1;
        }

        /// <summary>
        /// 住院登记
        /// </summary>
        /// <param name="patient">住院患者基本信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return this.processInpatientReg(patient, 0, 1);
        }

        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="r">门诊挂号基本信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            string diseaseCode = string.Empty;//疾病编码
            string diseaseName = string.Empty;//疾病名称

            try
            {
                string balanceNO = this.localManager.GetBalNo(r.ID);
                if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                {
                    balanceNO = "0";
                }
                balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                r.SIMainInfo.BalNo = balanceNO;
                r.SIMainInfo.RegNo = this.localManager.GetNewSINO("0");//获取医保门诊号
                r.SIMainInfo.IsValid = true;
                r.SIMainInfo.TotCost = r.OwnCost;//医疗费总额
                r.SIMainInfo.PayCost = 0;//帐户支出金额
                r.SIMainInfo.OwnCost = r.OwnCost;//现金总额
                r.SIMainInfo.PubCost = 0;//统筹支出
                //插入医保表
                this.localManager.SetTrans(this.trans);
                int returnValue = this.localManager.InsertSIMainInfo(r);
                if (returnValue == -1)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }
                returnValue = this.localManager.updateTransType("1", r.ID, r.SIMainInfo.BalNo);
                if (returnValue < 0)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }
            }
            catch (Exception e)
            {
                this.errText = e.Message;

                return -1;
            }
            finally
            {

            }

            return 1;
        }



        #region IMedcareTranscation 成员

        /// <summary>
        /// 重新开始数据库事务
        /// </summary>
        public void BeginTranscation()
        {

        }

        /// <summary>
        /// 数据库回滚
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Commit()
        {
            return 1;
        }

        /// <summary>
        /// 接口连接,初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Connect()
        {
            return 1;
        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Disconnect()
        {
            return 1;
        }

        /// <summary>
        /// 数据库回滚,成功 1 失败 -1
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Rollback()
        {
            return 1;
        }

        #endregion

        #region IMedcare 成员

        /// <summary>
        /// 门诊退号
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int CancelRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1; 
        }

        #endregion

        #region 本地方法

        #region 根据参数处理登记信息相关
        /// <summary>
        /// 根据参数处理登记信息相关（）
        /// </summary>
        /// <param name="patient">登记类型:0 入院登记1 出院登记</param>
        /// <param name="regType">交易类型:1 正交易 -1  反交易</param>
        /// <param name="transType"></param>
        /// <returns></returns>
        private int processInpatientReg(Neusoft.HISFC.Models.RADT.PatientInfo patient, int regType, int transType)
        {
            string diseaseCode = string.Empty;//疾病编码
            string diseaseName = string.Empty;//疾病名称

            //{D7E56154-7376-4972-9A9E-C0FAA74D2E1F}
            DateTime sysDate = this.localManager.GetDateTimeFromSysDateTime();
            //出院日期
            string outDate = string.Empty;
            //操作日期
            string operDate = sysDate.ToString(DATE_TIME_FORMAT);
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {

                //住院登记时插入fin_ipr_siinmaininfo
                if (regType == 0 && transType == 1)
                {
                    #region 处理住院登记
                    //取序号
                    localManager.SetTrans(this.trans);
                    string balanceNO = this.localManager.GetBalNo(patient.ID);
                    if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                    {
                        balanceNO = "0";
                    }
                    balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                    patient.SIMainInfo.BalNo = balanceNO;
                    patient.SIMainInfo.RegNo = this.localManager.GetNewSINO("1");//获取医保住院号
                    patient.SIMainInfo.IsValid = true;
                    int returnValue = this.localManager.InsertSIMainInfo(patient);
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }
                    returnValue = this.localManager.updateTransType("1", patient.ID, patient.SIMainInfo.BalNo);
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }

                    #endregion
                }
                else //其他类别
                {
                    //取得登记信息
                    this.localManager.SetTrans(this.trans);
                    //取出院日期
                    if (patient.PVisit.PreOutTime != null && patient.PVisit.PreOutTime != DateTime.MinValue)
                    {
                        outDate = patient.PVisit.PreOutTime.ToString("yyyyMMdd");
                    }
                    else
                    {
                        outDate = sysDate.ToString("yyyyMMdd");
                    }
                    patient = this.localManager.GetSIPersonInfo(patient.ID, "0");
                    if (patient == null)
                    {
                        this.errText = "没有找到对应的医保住院信息" + this.localManager.Err;
                        return -1;
                    }

                    #region 处理出院登记，出院召回，无费出院
                    //无费退院
                    if (transType == -1 && regType == 0)
                    {
                        //更新fin_ipr_sinmaininfo
                        patient.SIMainInfo.IsBalanced = true;
                        int returnValue = this.localManager.UpdateSiMainInfo(patient);
                        if (returnValue < 0)
                        {
                            this.errText = "更新fin_ipr_sinmaininfo结算标志出错" + this.localManager.Err;
                            return -1;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                this.errText = e.Message;
                return -1;
            }
            finally
            {
                dataBuffer = null;
            }

            return 1;
        }
        #endregion
        #region 获得对照信息
        /// <summary>
        /// 获得对照信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="hisItemCode"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.SIInterface.Compare Getitem(string pactCode, string hisItemCode)
        {
            this.interfaceManager.SetTrans(this.trans);
            Neusoft.HISFC.Models.SIInterface.Compare compare = new Neusoft.HISFC.Models.SIInterface.Compare();
            this.interfaceManager.GetCompareSingleItem(pactCode, hisItemCode, ref compare);
            return compare;

        }

        #endregion

        #region 医保性别转换
        /// <summary>
        /// 医保性别转换
        /// </summary>
        /// <param name="SexCode"></param>
        /// <returns></returns>
        private string ConvertSex(string SexCode)
        {
            switch (SexCode)
            {
                case "1":
                    {
                        return "F";
                    }
                case "2":
                    {
                        return "M";
                    }
                case "3":
                    {
                        return "O";
                    }
                default:
                    return "O";
                    break;
            }
        }
        #endregion

        #region 住院明细上传方法
        /// <summary>
        /// 住院明细上传方法
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="f"></param>
        /// <param name="transType"></param>
        /// <returns></returns>
        public int UploadFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo p, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f, string transType)
        {
            return 1;
        }
        #endregion

        #region 门诊上传明细方法
        /// <summary>
        /// 上传明细方法
        /// </summary>
        /// <param name="p">患者基本信息抽象类</param>
        /// <param name="itemList">明细基本信息抽象类</param>
        /// <returns>成功 1 失败 -1</returns>
        private int UploadFeeItemList(Neusoft.HISFC.Models.Registration.Register p, Neusoft.HISFC.Models.Fee.FeeItemBase itemList, string transType)
        {
            return 1;
        }
        #endregion
        #region 医保配置文件处理
        public static int CreateSISetting()
        {
            try
            {
                XmlDocument docXml = new XmlDocument();
                XmlElement root = docXml.CreateElement("root");
                docXml.AppendChild(root);

                XmlElement elem1 = docXml.CreateElement("共享目录");
                elem1.SetAttribute("path", "");
                root.AppendChild(elem1);

                docXml.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/" + EXTEND_PROPERTY_KEY + "SiSetting.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入配置信息出错!" + ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void ReadSISetting()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/"+EXTEND_PROPERTY_KEY+ "SiSetting.xml"))
            {
                if (CreateSISetting() == -1)
                {
                    return;
                }
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/" + EXTEND_PROPERTY_KEY + "SiSetting.xml");
                XmlNode node = doc.SelectSingleNode("//共享目录");
                FILE_PATH = node.Attributes["path"].Value.ToString();
                if (string.IsNullOrEmpty(HOSPITAL_NO.Trim()))
                {
                    MessageBox.Show("请在配置文件中维护共享目录");
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取配置信息出错!" + e.Message);
                return;
            }
        }

        #endregion
        #region 转换成日期格式
        /// <summary>
        /// 转换成日期格式
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public string ConvertDateFormat(string inputStr)
        {
            string returnStr = string.Empty;
            if (inputStr.Length == 8)
            {
                returnStr = inputStr.Substring(0, 4) + "-" + inputStr.Substring(4, 2) + "-" + inputStr.Substring(6, 2);

            }
            else if (inputStr.Length == 14)
            {

            }
            else
            {
                returnStr = inputStr;
            }
            return returnStr;
        }
        #endregion
        #endregion

        #region IMedcare 成员


        public bool IsUploadAllFeeDetailsOutpatient
        {
            get { return false; }
        }

        #endregion
        /// <summary>
        /// 取扩展实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="epo">保存扩展属性的实体</param>
        /// <returns>扩展实体</returns>
        public static T ExtendProperty<T>(string key, System.Collections.Generic.Dictionary<string, Neusoft.FrameWork.Models.NeuObject> epo) where T : Neusoft.FrameWork.Models.NeuObject, new()
        {
            T obj = default(T);
            if (epo.ContainsKey(key) == true)
            {
                obj = epo[key] as T;
            }
            else
            {
                obj = new T();
                epo.Add(key, obj);
            }
            return obj;
        }
    }
    
    /// <summary>
    /// 读卡方式
    /// </summary>
    public enum ReadCardTypes
    {
        /// <summary>
        /// 患者基本信息
        /// </summary>
        参保人员基本信息 = 1,

        /// <summary>
        /// 账户基本信息
        /// </summary>
        帐户基本信息 = 2,

        帐户余额 = 3,

        住院人员信息 = 4,

        基本交易明细 = 5,

        非基本交易明细 = 6,

        /// <summary>
        /// 结算时将此字符串直接传入结算函数的PersonAccountInfo参数
        /// </summary>
        个人及帐户信息 = 7
    }
}
