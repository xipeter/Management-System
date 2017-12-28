using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace ShenYangCitySI
{
    public class Process : Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IMedcare
    {
        /// <summary>
        /// [功能描述: 医保接口类]<br></br>
        /// [创 建 者: 王宇]<br></br>
        /// [创建时间: 2006-10-12]<br></br>
        /// 修改记录
        /// 修改人='牛鑫元'
        ///	修改时间=''
        ///	修改目的='丰富医保信息'
        ///	修改描述=''
        ///  >
        /// </summary>
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
        /// 日期格式
        /// </summary>
        protected const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
        /// <summary>
        /// 医疗机构编码
        /// </summary>
        private static string hospitalNO = "";
        /// <summary>
        /// 医院等级
        /// </summary>
        private static string hosGrade = "";
        /// <summary>
        /// 医保业务层
        /// </summary>
        private LocalManager localManager = new LocalManager();
        private Neusoft.HISFC.BizLogic.Fee.Interface interfaceManager = new Neusoft.HISFC.BizLogic.Fee.Interface();
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrage = new Neusoft.HISFC.BizProcess.Integrate.Fee();
       

        #endregion

        public Process()
        {
            //设置配置文件
          // ReadSISetting();   
        }

        #region IMedcare 成员

        /// <summary>
        /// 住院患者出院结算
        /// </summary>
        /// <param name="p">住院患者基本信息实体</param>
        /// <param name="feeDetails">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo p, ref System.Collections.ArrayList feeDetails)
        {
            StringBuilder dataBuffer = new StringBuilder(1024);

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
                #region 判断卡号与数据库中的卡号是否一致 by耿晓雷
                string[] oldData = this.SplitStringToChar(myPatient.SIMainInfo.Memo);
                if (oldData[10].ToString() != p.SIMainInfo.ICCardCode.ToString())
                {
                    this.errText = "该患者医保卡号与医保数据库中卡号不符!";
                    return -1;
                }
                #endregion

                p.SIMainInfo.MedicalType.ID = myPatient.SIMainInfo.MedicalType.ID;
                //p.SIMainInfo.Memo = myPatient.SIMainInfo.Memo;
                p.SIMainInfo.ClinicDiagNose = myPatient.ClinicDiagnose;
                p.SIMainInfo.InDiagnose.ID = myPatient.SIMainInfo.InDiagnose.ID;
                p.SIMainInfo.InDiagnose.Name = myPatient.SIMainInfo.InDiagnose.Name;
                p.SIMainInfo.OutDiagnose.ID = myPatient.SIMainInfo.OutDiagnose.ID;
                p.SIMainInfo.OutDiagnose.Name = myPatient.SIMainInfo.OutDiagnose.Name;

                //调用接口预结算方法
                int returnValue = Functions.ExpenseCalc(1, "1", p.SIMainInfo.MedicalType.ID, p.ID, p.SIMainInfo.InvoiceNo, p.SIMainInfo.Memo, p.SIMainInfo.OperInfo.ID, DateTime.Now.ToString(DATE_TIME_FORMAT), p.SIMainInfo.OutDiagnose.ID,
                    p.SIMainInfo.OutDiagnose.Name, 1, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                string[] temp = this.SplitStringToChar(dataBuffer.ToString());

                if (temp == null || temp.Length == 0)
                {
                    this.errText = "拆分字符串错误!";

                    return -1;
                }


                p.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
                p.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
                p.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

                // decimal returnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);//返还患者金额
                //生育保险处理
                decimal lifeCost = 0;
       //         if (p.SIMainInfo.MedicalType.ID == "42" || p.SIMainInfo.MedicalType.ID == "43" || p.SIMainInfo.MedicalType.ID == "44" || p.SIMainInfo.MedicalType.ID == "45")
                if (p.SIMainInfo.MedicalType.ID == "42" || p.SIMainInfo.MedicalType.ID == "44" || p.SIMainInfo.MedicalType.ID == "45")
                {
                    p.SIMainInfo.OwnCost = p.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);//现金总额 
                }

                p.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

                p.SIMainInfo.PubCost = p.SIMainInfo.TotCost - p.SIMainInfo.PayCost - p.SIMainInfo.OwnCost - p.SIMainInfo.OverCost - p.SIMainInfo.OfficalCost;
                //插入本地数据库



                if (this.trans == null)
                {
                    this.errText = "事务不能为空";
                }
                else
                {
                    this.localManager.SetTrans(this.trans);
                    p.SIMainInfo.IsBalanced = true;
                    p.SIMainInfo.IsValid = true;
                    returnValue = this.localManager.UpdateSiMainInfo(p);
                    if (returnValue <= 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }
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

        /// <summary>
        /// 门诊患者收费结算
        /// </summary>
        /// <param name="r">挂号基本信息实体</param>
        /// <param name="feeDetails">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {   //判断疾病码
                

                Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
                this.localManager.SetTrans(this.trans);
                DateTime currentDate = localManager.GetDateTimeFromSysDateTime();
                myRegister = this.localManager.GetSIPersonInfoOutPatient(r.ID);
                if (myRegister == null || myRegister.ID == "" || myRegister.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到挂号信息";
                    return -1;
                }

                r.SIMainInfo.MedicalType.ID = myRegister.SIMainInfo.MedicalType.ID;
                #region 处理生育保险 

                #region 处理 特殊病等需要结算录诊断的医保类型
                #endregion
                if (r.SIMainInfo.MedicalType.ID == "12" || r.SIMainInfo.MedicalType.ID == "43" || r.SIMainInfo.MedicalType.ID == "41")
                {
                    if (string.IsNullOrEmpty(r.SIMainInfo.OutDiagnose.ID))
                    {

                        //弹出录入诊断界面
                        Control.frmSiPob frmSiPob = new ShenYangCitySI.Control.frmSiPob();
                        frmSiPob.Patient = r;
                        frmSiPob.Text = "市保—门诊结算";
                        frmSiPob.isInDiagnose = false;
                        frmSiPob.ShowDialog();
                        DialogResult resultNew = frmSiPob.DialogResult;
                        if (resultNew == DialogResult.OK)
                        {

                        }
                        else
                        {
                            return -1;
                        }

                    }
                }
                #endregion
                //调用接口结算方法
                int returnValue = Functions.ExpenseCalc(1, "1", r.SIMainInfo.MedicalType.ID, r.ID, r.SIMainInfo.InvoiceNo, r.SIMainInfo.Memo, r.InputOper.ID, currentDate.ToString("yyyyMMddHHmmss"), r.SIMainInfo.OutDiagnose.ID,
                    r.SIMainInfo.OutDiagnose.Name, Neusoft.FrameWork.Function.NConvert.ToInt32(r.SIMainInfo.ProceateLastFlag), dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                string[] temp = this.SplitStringToChar(dataBuffer.ToString());

                if (temp == null || temp.Length == 0)
                {
                    this.errText = "拆分字符串错误!";

                    return -1;
                }

                r.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
                r.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
                r.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

                if (r.SIMainInfo.MedicalType.ID == "42" || r.SIMainInfo.MedicalType.ID == "43" || r.SIMainInfo.MedicalType.ID == "44" || r.SIMainInfo.MedicalType.ID == "45")
                {
                    r.SIMainInfo.OwnCost = r.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);//现金总额 
                }


                r.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

                r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.PayCost - r.SIMainInfo.OwnCost - r.SIMainInfo.OverCost;
                //插入本地表
                string balanceNO = this.localManager.GetBalNo(r.ID);
                if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                {
                    balanceNO = "0";
                }
                r.SIMainInfo.BalNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                r.SIMainInfo.IsValid = true;
                returnValue = this.localManager.InsertSIMainInfo(r);
                if (returnValue < 0)
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
                dataBuffer = null;
            }

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
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {
                this.localManager.SetTrans(this.trans);
                string medicaltype = this.localManager.GetMedicalType(p.ID, p.SIMainInfo.InvoiceNo, "2");
                if (medicaltype == null || medicaltype == "")
                {
                    this.errText = "医保类别不能为空" + this.localManager.Err;
                }
                p.SIMainInfo.MedicalType.ID = medicaltype;
     
                //调用接口预结算方法
                //调用接口预结算方法
                int returnValue = Functions.ExpenseCalc(-1, "1", p.SIMainInfo.MedicalType.ID, p.ID, p.SIMainInfo.InvoiceNo, p.SIMainInfo.Memo, p.SIMainInfo.OperInfo.ID, DateTime.Now.ToString(DATE_TIME_FORMAT), p.SIMainInfo.Disease.ID,
                    p.SIMainInfo.Disease.Name, 1, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                Neusoft.HISFC.Models.RADT.PatientInfo patient = localManager.GetSIPersonInfoByInvoiceNo(p.ID, p.SIMainInfo.InvoiceNo);
                //插负记录
                returnValue = this.localManager.InsertBackBalanceInpatient(p.ID, p.SIMainInfo.InvoiceNo, p.SIMainInfo.BalNo, p.SIMainInfo.OperDate.ToString("yyyy-MM-dd HH:MM:ss"), p.SIMainInfo.OperInfo.ID);
                if (returnValue != 1)
                {
                    this.errText = this.localManager.Err;

                    return -1;
                }
                returnValue = this.localManager.updateTransType("2", p.ID, p.SIMainInfo.BalNo);
                if (returnValue < 0)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }
                //更新原来记录为作废


                returnValue = this.localManager.setValidFalseOldInvoice(p.ID, p.SIMainInfo.InvoiceNo, "2");
                if (returnValue != 1)
                {
                    this.errText = this.localManager.Err;

                    return -1;
                }
            //    Neusoft.HISFC.Models.RADT.PatientInfo patient = p.Clone();

                if (patient != null)
                {

                    string balanceNO = this.localManager.GetBalNo(p.ID);
                    if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                    {
                        balanceNO = "0";
                    }
                    //localManager.SetTrans(this.trans);
                    balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                    patient.SIMainInfo.BalNo = balanceNO;
                    patient.SIMainInfo.IsValid = true;
                    patient.SIMainInfo.InvoiceNo = "";
                    patient.SIMainInfo.TotCost = 0;
                    patient.SIMainInfo.OwnCost = 0;
                    patient.SIMainInfo.PayCost = 0;
                    patient.SIMainInfo.PubCost = 0;
                    patient.SIMainInfo.OverCost = 0;
                    patient.SIMainInfo.OfficalCost = 0;
                    patient.SIMainInfo.IsBalanced = false;
                    //patient.SIMainInfo.InDiagnose.ID = p.SIMainInfo.InDiagnose.ID;
                    //patient.SIMainInfo.InDiagnose.Name = p.SIMainInfo.InDiagnose.Name;
                    //patient.SIMainInfo.OutDiagnose.ID = p.SIMainInfo.OutDiagnose.ID;
                    //patient.SIMainInfo.OutDiagnose.Name = p.SIMainInfo.OutDiagnose.Name;
                    returnValue = this.localManager.InsertSIMainInfo(patient);
                    if (returnValue < 0)
                    {
                        this.errText = this.interfaceManager.Err;
                        return -1;
                    }
                    returnValue = this.localManager.updateTransType("1", patient.ID, patient.SIMainInfo.BalNo);
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }

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

        /// <summary>
        /// 门诊退费
        /// </summary>
        /// <param name="r">门诊挂号基本信息实体</param>
        /// <param name="feeDetails">门诊费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int CancelBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            StringBuilder dataBuffer = new StringBuilder(1024);
            int appCode = 0;

            //取得收费信息

            Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
            //查找原来的挂号信息


            this.localManager.SetTrans(this.trans);
            myRegister = localManager.GetSIPersonInfoOutPatient(r.ID);
            if (myRegister == null || myRegister.ID == null || myRegister.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有找到医保挂号信息"));
                return -1;
            }
            else
            {
                r.SIMainInfo.MedicalType.ID = myRegister.SIMainInfo.MedicalType.ID;
                r.SIMainInfo.OutDiagnose = myRegister.SIMainInfo.OutDiagnose;
            }

            try
            {
                //调用接口结算方法
                int returnValue = Functions.ExpenseCalc(-1, "1", r.SIMainInfo.MedicalType.ID, r.ID, r.SIMainInfo.InvoiceNo, r.SIMainInfo.Memo, r.InputOper.ID, DateTime.Now.ToString(DATE_TIME_FORMAT), r.SIMainInfo.OutDiagnose.ID,
                    r.SIMainInfo.OutDiagnose.Name, 1, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }
                string[] temp = this.SplitStringToChar(dataBuffer.ToString());

                if (temp == null || temp.Length == 0)
                {
                    this.errText = "拆分字符串错误!";

                    return -1;
                }
                r.SIMainInfo.TotCost = - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
                r.SIMainInfo.PayCost = -Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
                r.SIMainInfo.OwnCost = -Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

                if (r.SIMainInfo.MedicalType.ID == "42" || r.SIMainInfo.MedicalType.ID == "43" || r.SIMainInfo.MedicalType.ID == "44" || r.SIMainInfo.MedicalType.ID == "45")
                {
                    r.SIMainInfo.OwnCost = - (r.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]));//现金总额 
                }


                r.SIMainInfo.OverCost =- Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

                r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.PayCost - r.SIMainInfo.OwnCost - r.SIMainInfo.OverCost;

                string balanceNO = this.localManager.GetBalNo(r.ID);
                if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                {
                    balanceNO = "0";
                }
                r.SIMainInfo.BalNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                r.SIMainInfo.IsValid = true;
                r.SIMainInfo.IsBalanced = true;
                returnValue = this.localManager.InsertSIMainInfo(r);
                if (returnValue < 0)
                {
                    this.errText = this.localManager.Err;
                    return -1;
                }
                returnValue = this.localManager.updateTransType("2", r.ID, r.SIMainInfo.BalNo);
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
                dataBuffer = null;
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public int DeleteUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return this.UploadFeeItemListInpatient(patient, f, "-1");
            
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

            return this.processInpatientReg(patient, 0, -1) ;
        }
        /// <summary>
        /// 出院召回
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return this.processInpatientReg(patient, 1, -1);
        }
        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {

            return  this.processInpatientReg(patient, 1, 1);
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get 
            {
                return "沈阳市医保接口";
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
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {
                //调用第一种读卡方式,读取患者基本信息
                int returnValue = Functions.ReadCard((int)ReadCardTypes.参保人员基本信息, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                this.SetInpatientRegInfo(patient, ReadCardTypes.参保人员基本信息, dataBuffer.ToString());

                //调用第七种读卡方式,读取患者账户基本信息
                returnValue = Functions.ReadCard((int)ReadCardTypes.个人及帐户信息, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                this.SetInpatientRegInfo(patient, ReadCardTypes.个人及帐户信息, dataBuffer.ToString());

                return 1;
            }
            catch (Exception ex)
            {
                this.errText = ex.Message;

                return -1;
            }
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
            string[] temp;

            temp = this.SplitStringToChar(dataBuffer);

            if (temp == null)
            {
                return -1;
            }

            switch (readCardType)
            {
                case ReadCardTypes.参保人员基本信息:

                    p.SIMainInfo.CardOrgID = temp[1];//发卡机构编码
                    p.SIMainInfo.ICCardCode = temp[2];//IC卡号
                    p.Card.ICCard.ID = p.SIMainInfo.ICCardCode;//IC卡号
                    p.Name = temp[3];//姓名
                    p.SIMainInfo.Name = p.Name;//姓名;
                    p.Sex.ID = this.ConvertSex(temp[4]);//性别;
                    p.IDCard = temp[5];//身份证号
                    p.SIMainInfo.Corporation.ID = temp[6];//参保单位编码
                    p.SIMainInfo.RegNo = temp[7];//个人编号
                    p.SIMainInfo.PersonType.ID = temp[8];//人员类别
                    temp[9] = this.ConvertDateFormat(temp[9]);
                    p.SIMainInfo.CardValidTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(temp[9]);//有效期
                    p.SIMainInfo.ShiftTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(temp[10]);//变更日期
                    temp[11] = this.ConvertDateFormat(temp[11]);
                    p.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime((temp[11]));//生日
                    p.Nationality.ID = temp[12];
                    p.SIMainInfo.IsCardLocked = Neusoft.FrameWork.Function.NConvert.ToBoolean(temp[13]);//卡是否锁定
                    p.Pact.ID = "2";//沈阳市医保
                    if( temp.Length < 21 )
                    {
                    }
                    else
                    {
                        p.User01 = temp[21];//上次出院日期
                        p.User02 = temp[22];//上次出院疾病编码
                    }

                       
                    
                   
                    break;

                case ReadCardTypes.个人及帐户信息:

                    p.SSN = temp[1];//个人编号
                    p.SIMainInfo.Corporation.ID = temp[2];//单位编码
                    p.SIMainInfo.PersonType.ID = temp[3];//参保人员类别
                    p.SIMainInfo.YearPubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[4]);//本年统筹支出累计
                    p.SIMainInfo.YearHelpCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[5]);//本年救助金支出累计
                    p.SIMainInfo.IndividualBalance = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[6]);//帐户余额
                    p.SIMainInfo.TurnOutHosStandardCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[7]);//转出医院起伏标准
                    p.SIMainInfo.TurnOutHosOnwCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[8]);//转出医院起伏标准自付
                    p.SIMainInfo.InHosTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(temp[9]);//住院次数
                    p.SIMainInfo.ICCardCode = temp[10];//卡号
                    p.SIMainInfo.PayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[11]);//帐户支付累计
                    p.SIMainInfo.PayYear = temp[12];//帐户支付年度
                    p.SIMainInfo.OwnCashAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[13]);//现金支付金额累计
                    p.SIMainInfo.OwnAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[14]);//个人自负(乙类项目)金额累计
                    p.SIMainInfo.GwyPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[15]);//公务员支付金额累计
                    p.SIMainInfo.SpOutpatientPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//特殊门诊支付累计
                    p.SIMainInfo.SlowOutpatientPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[17]);//门诊慢性病支付累计
                    //p.User01 = temp[18];
                    //p.User02 = temp[19];
                    //p.User03 = temp[20];

                    p.SIMainInfo.Memo = dataBuffer;
                    p.Pact.ID = "2";//沈阳市医保
                    break;
            }

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
            string[] temp;

            temp = this.SplitStringToChar(dataBuffer);

            if (temp == null)
            {
                return -1;
            }

            switch (readCardType) 
            {
                case ReadCardTypes.参保人员基本信息:

                    r.SIMainInfo.CardOrgID = temp[1];//发卡机构编码
                    r.SIMainInfo.ICCardCode = temp[2];//IC卡号
                    r.Card.ICCard.ID = r.SIMainInfo.ICCardCode;//IC卡号
                    r.Name = temp[3];//姓名
                    r.SIMainInfo.Name = r.Name;//姓名;
                    r.Sex.ID = this.ConvertSex(temp[4]);//性别;
                    r.IDCard = temp[5];//身份证号
                    r.SIMainInfo.Corporation.ID = temp[6];//参保单位编码
                    r.SIMainInfo.RegNo = temp[7];//个人编号
                    r.SIMainInfo.PersonType.ID = temp[8];//人员类别
                    r.SIMainInfo.CardValidTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(temp[9]);//有效期
                    r.SIMainInfo.ShiftTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(temp[10]);//变更日期
                    temp[11] = this.ConvertDateFormat(temp[11]);
                    r.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime((temp[11]));//生日
                    r.Nationality.ID = temp[12];
                    r.SIMainInfo.IsCardLocked = Neusoft.FrameWork.Function.NConvert.ToBoolean(temp[13]);//卡是否锁定
                    r.Pact.ID = "2";//沈阳市医保
                    break;

                case ReadCardTypes.个人及帐户信息:

                    r.SSN = temp[1];//个人编号
                    r.SIMainInfo.Corporation.ID = temp[2];//单位编码
                    r.SIMainInfo.PersonType.ID = temp[3];//参保人员类别
                    r.SIMainInfo.YearPubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[4]);//本年统筹支出累计
                    r.SIMainInfo.YearHelpCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[5]);//本年救助金支出累计
                    r.SIMainInfo.IndividualBalance = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[6]);//帐户余额
                    r.SIMainInfo.TurnOutHosStandardCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[7]);//转出医院起伏标准
                    r.SIMainInfo.TurnOutHosOnwCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[8]);//转出医院起伏标准自付
                    r.SIMainInfo.InHosTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(temp[9]);//住院次数
                    r.SIMainInfo.ICCardCode = temp[10];//卡号
                    r.SIMainInfo.PayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[11]);//帐户支付累计
                    r.SIMainInfo.PayYear = temp[12];//帐户支付年度
                    r.SIMainInfo.OwnCashAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[13]);//现金支付金额累计
                    r.SIMainInfo.OwnAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[14]);//个人自负(乙类项目)金额累计
                    r.SIMainInfo.GwyPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[15]);//公务员支付金额累计
                    r.SIMainInfo.SpOutpatientPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//特殊门诊支付累计
                    r.SIMainInfo.SlowOutpatientPayAddCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[17]);//门诊慢性病支付累计
                    r.User01 = temp[18];
                    r.User02 = temp[19];
                    r.User03 = temp[20];

                    r.SIMainInfo.Memo = dataBuffer;
                    r.Pact.ID = "2";//沈阳市医保
                    break;
            }

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
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {
                //调用第一种读卡方式,读取患者基本信息
                int returnValue = Functions.ReadCard((int)ReadCardTypes.参保人员基本信息, dataBuffer);

                if (returnValue != 0) 
                {
                    this.errText = dataBuffer.ToString() ;

                    return -1;
                }

                this.SetOutpatientRegInfo(r, ReadCardTypes.参保人员基本信息, dataBuffer.ToString());

                
                returnValue = Functions.ReadCard((int)ReadCardTypes.个人及帐户信息, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                this.SetOutpatientRegInfo(r, ReadCardTypes.个人及帐户信息, dataBuffer.ToString());
                
                return 1;
            }
            catch (Exception ex)
            {
                this.errText = ex.Message;

                return -1;
            }
               
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
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
            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            { //查找登记信息
                Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
                this.localManager.SetTrans(this.trans);
                myPatient = this.localManager.GetSIPersonInfo(patient.ID, "0");
                if (myPatient == null || myPatient.ID == "" || myPatient.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到住院登记信息";
                    return -1;
                }
                patient.SIMainInfo.MedicalType.ID = myPatient.SIMainInfo.MedicalType.ID;
                patient.SIMainInfo.Memo = myPatient.SIMainInfo.Memo;
                //patient.SIMainInfo.OutDiagnose.ID = myPatient.SIMainInfo.OutDiagnose.ID;
                //patient.SIMainInfo.OutDiagnose.Name = myPatient.SIMainInfo.OutDiagnose.Name;
                if (myPatient.SIMainInfo.OutDiagnose.ID == null || myPatient.SIMainInfo.OutDiagnose.ID == "") //为出院登记时，没有出院诊断
                {
                    patient.SIMainInfo.OutDiagnose.ID = myPatient.SIMainInfo.InDiagnose.ID;
                    patient.SIMainInfo.OutDiagnose.Name = myPatient.SIMainInfo.InDiagnose.Name;
                }
                else
                {
                    patient.SIMainInfo.OutDiagnose.ID = myPatient.SIMainInfo.OutDiagnose.ID;
                    patient.SIMainInfo.OutDiagnose.Name = myPatient.SIMainInfo.OutDiagnose.Name;
                }
                //调用接口预结算方法
                
                int sreimflag = 0;//生育保险结算标志
                if (patient.SIMainInfo.MedicalType.ID == "42" || patient.SIMainInfo.MedicalType.ID == "43" || patient.SIMainInfo.MedicalType.ID == "44" || patient.SIMainInfo.MedicalType.ID == "45")
                {
                    sreimflag = 1;
                }

                int returnValue = Functions.PreExpenseCalc("1", patient.SIMainInfo.MedicalType.ID, patient.ID, patient.SIMainInfo.Memo, DateTime.Now.ToString(DATE_TIME_FORMAT), patient.SIMainInfo.OutDiagnose.ID,
                    patient.SIMainInfo.OutDiagnose.Name, sreimflag, dataBuffer);

                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                string[] temp = this.SplitStringToChar(dataBuffer.ToString());

                if (temp == null || temp.Length == 0)
                {
                    this.errText = "拆分字符串错误!";

                    return -1;
                }
                if (temp.Length < 37)//实际正确返回长度是39，当长度小于37时程序出错
                {
                    if (temp.Length == 1 && temp[0] == " ")//最后一条记录退费时返回一个长度的空格：" "
                    {
                        patient.SIMainInfo.TotCost = 0;
                        patient.SIMainInfo.PayCost = 0;
                        patient.SIMainInfo.OwnCost = 0;
                        patient.SIMainInfo.OverCost = 0;
                        patient.SIMainInfo.PubCost = 0;
                    }
                    else
                    {
                        this.errText = "字符串拆分长度错误！";
                        return -1;
                    }
                }
                else
                {
                    patient.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
                    patient.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
                    patient.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

                    // decimal returnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[38]);//返还患者金额
                    //生育保险处理
                    decimal lifeCost = 0;
                    if (patient.SIMainInfo.MedicalType.ID == "42" || patient.SIMainInfo.MedicalType.ID == "43" || patient.SIMainInfo.MedicalType.ID == "44" || patient.SIMainInfo.MedicalType.ID == "45")
                    {
                        patient.SIMainInfo.OwnCost = patient.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);//现金总额 
                    }

                    patient.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

                    patient.SIMainInfo.PubCost = patient.SIMainInfo.TotCost - patient.SIMainInfo.PayCost - patient.SIMainInfo.OwnCost - patient.SIMainInfo.OverCost - patient.SIMainInfo.OfficalCost;//统筹
                }
                myPatient.SIMainInfo.TotCost = patient.SIMainInfo.TotCost;
                myPatient.SIMainInfo.PayCost = patient.SIMainInfo.PayCost;
                myPatient.SIMainInfo.OwnCost = patient.SIMainInfo.OwnCost;
                myPatient.SIMainInfo.OverCost = patient.SIMainInfo.OverCost;
                myPatient.SIMainInfo.PubCost = patient.SIMainInfo.PubCost;
                myPatient.SIMainInfo.OfficalCost = patient.SIMainInfo.OfficalCost;
                this.localManager.UpdateSiMainInfo(myPatient);
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

            return 1; ;
        }

        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
              /*      |医疗费总额|个人自费金额|乙类药品自理|
              特检自理|特治自理|起付自负金额|
              起付标准帐户支付金额|起付标准现金支付金额|分段自理|
              分段自付帐户支付金额|分段自付现金支付金额|统筹支付金额|
              超过封顶线个人自付金额|超过封顶线自付帐户支出|超过封顶线自付现金支付|
              超过封顶线补助金支出金额|超过大额补助自费金额|帐户支出金额|
              个人现金支付金额|起付标准|交易流水号|
              本年统筹支出累计|本年救助金支出累计|个人住院次数|
              个人帐户支付累计|个人现金自付累计|乙类项目自费累计|
              门诊大病(特殊病种)累计|公务员支出累计|门诊慢性病支出累计|
              其它一|其它二|其它三|
              在院状态|起付标准支付|返还患者金额| */

            StringBuilder dataBuffer = new StringBuilder(1024);

            try
            {

                Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();

                localManager.SetTrans(this.trans);
                myRegister = this.localManager.GetSIPersonInfoOutPatient(r.ID);
                if (myRegister == null || myRegister.ID == "" || myRegister.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到挂号信息";
                    return -1;
                }

                
                r.SIMainInfo.MedicalType.ID = myRegister.SIMainInfo.MedicalType.ID;
                r.SIMainInfo.OutDiagnose = myRegister.SIMainInfo.OutDiagnose;
                r.SIMainInfo.Memo = myRegister.SIMainInfo.Memo;
               
                 int isLife = 0; //节育门诊结算标志0:本次结算  1 最后一次结算
                 if (r.SIMainInfo.MedicalType.ID == "43")
                 {
                     if (r.SIMainInfo.ProceateLastFlag)
                     {
                         isLife = 1;
                     } 
                 } 
                //调用接口预结算方法
                int returnValue = Functions.PreExpenseCalc("1", r.SIMainInfo.MedicalType.ID, r.ID, r.SIMainInfo.Memo, DateTime.Now.ToString("yyyyMMddHHmmss"), r.SIMainInfo.OutDiagnose.ID,
                    r.SIMainInfo.OutDiagnose.Name, isLife, dataBuffer);

                if (returnValue != 0) 
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }
                //拆串
                string[] temp = this.SplitStringToChar(dataBuffer.ToString());

                if (temp == null || temp.Length == 0) 
                {
                    this.errText = "拆分字符串错误!";
                    
                    return -1;
                }
                
                r.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[1]);//医疗费总额
                r.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[18]);//帐户支出金额
                r.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[19]);//现金总额

                if (r.SIMainInfo.MedicalType.ID == "42" || r.SIMainInfo.MedicalType.ID == "43" || r.SIMainInfo.MedicalType.ID == "44" || r.SIMainInfo.MedicalType.ID == "45")
                {
                    r.SIMainInfo.OwnCost = r.SIMainInfo.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[36]);//现金总额 
                }


                r.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp[16]);//大额现金

                r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.PayCost - r.SIMainInfo.OwnCost - r.SIMainInfo.OverCost;
                //预结算回滚上传明细，结算时统一上传
                //this.Rollback();
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
            this.trans =t;
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
            return 1 ;
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
            return this.UploadFeeItemList(r, f,"1");
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
            if (this.feeIntegrage.SetRecipeNOOutpatient(feeDetails, ref errText) == false)
            {
                this.errText = this.feeIntegrage.Err;
                return -1;
            }
            int returnValue = 0;

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeDetails)
            {
                returnValue = this.UploadFeeItemList(r, f,"1");

                if (returnValue != 1)
                {
                    return -1;
                }
            }
            //给实体的医疗类别赋值
            string medicaltype = this.localManager.GetMedicalType(r.ID, r.SIMainInfo.InvoiceNo, "1");
            if (medicaltype == null || medicaltype == "")
            {
                this.errText = "医保类别不能为空" + this.localManager.Err;
            }
            r.SIMainInfo.MedicalType.ID = medicaltype;
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

            StringBuilder dataBuffer = new StringBuilder(1024);
            Control.frmSiPob frmpob = new  ShenYangCitySI.Control.frmSiPob();
            frmpob.Patient = r;
            frmpob.Text = "市保—门诊挂号";
            frmpob.isInDiagnose = true;
            frmpob.ShowDialog();

            DialogResult result = frmpob.DialogResult;

            if (result == DialogResult.OK)
            {
            }
            else
            {
                return -1;
            }
            //}
            //
            diseaseCode = r.SIMainInfo.InDiagnose.ID;
            diseaseName = r.SIMainInfo.InDiagnose.Name;


            try
            {
                //调用接口门诊挂号登记方法,其中注意r.SIMainInfo.Memo为读取账户信息的字符串,在这里一定要原样传入.在读卡的时候已经保存在
                //r.SIMainInfo.Memo中
                int returnValue = Functions.Registration(r.SIMainInfo.Memo, 1, r.SIMainInfo.MedicalType.ID, r.RecipeNO, r.ID, r.InputOper.OperTime.ToString("yyyyMMdd"),
                    r.InputOper.ID, diseaseCode, diseaseName, dataBuffer);


                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                r.SIMainInfo.TotCost = r.OwnCost;//医疗费总额
                r.SIMainInfo.PayCost = 0;//帐户支出金额
                r.SIMainInfo.OwnCost = r.OwnCost;//现金总额
                r.SIMainInfo.PubCost = 0;//统筹支出
                //插入医保表
                this.localManager.SetTrans(this.trans);
                returnValue = this.localManager.InsertSIMainInfo(r);
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
                dataBuffer = null;
            }

            return 1;
        }

        #endregion

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
            return Functions.CommitTrans();
        }

        /// <summary>
        /// 接口连接,初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Connect()
        {
            if (!isInit) 
            {
                try
                {
                    hospitalNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("HOS", "HOSPITALNO", @".\dllinit.ini");
                    hosGrade = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("HOS", "HOSGRADE", @".\dllinit.ini");
                    int returnValue = Functions.InitDLL();
                    if (returnValue != 0)
                    {
                        this.errText = "初始化接口失败!";

                        return -1;
                    }
                }
                catch (Exception ex) 
                {
                    this.errText = ex.Message;

                    isInit = false;

                    return -1;
                }

                isInit = true;//初始化后,不必再初始化

                return 1;
            }

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
            return Functions.RollbackTrans();
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
            string diseaseCode = string.Empty;//疾病编码
            string diseaseName = string.Empty;//疾病名称

            StringBuilder dataBuffer = new StringBuilder(1024);
           


            try
            {
                //调用接口门诊挂号登记方法,其中注意r.SIMainInfo.Memo为读取账户信息的字符串,在这里一定要原样传入.在读卡的时候已经保存在
                //r.SIMainInfo.Memo中
                Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
                this.localManager.SetTrans(this.trans);
                myRegister = this.localManager.GetSIPersonInfoOutPatient(r.ID);
                if (myRegister == null || myRegister.ID == "" || myRegister.ID == string.Empty)
                {
                    this.errText = "待遇接口没有找到挂号信息";
                    return -1;
                }

                //r.SIMainInfo.Memo = myRegister.SIMainInfo.Memo;
                r.SIMainInfo.MedicalType.ID = myRegister.SIMainInfo.MedicalType.ID;
                int returnValue = Functions.Registration(r.SIMainInfo.Memo, -1, r.SIMainInfo.MedicalType.ID, r.RecipeNO, r.ID, r.InputOper.OperTime.ToString("yyyyMMdd"),
                    r.InputOper.ID, diseaseCode, diseaseName, dataBuffer);


                if (returnValue != 0)
                {
                    this.errText = dataBuffer.ToString();

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
                dataBuffer = null;
            }

            return 1; ;
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

            StringBuilder dataBuffer = new StringBuilder(1024);
            int appCode = 0;

            try
            {

                //住院登记时插入fin_ipr_siinmaininfo
                if (regType == 0 && transType == 1)
                {
                    #region 处理住院登记
                    //住院登记传诊断，确定住院类别等

                    Control.frmSiPobInpatientInfo frmpob = new ShenYangCitySI.Control.frmSiPobInpatientInfo();
                    frmpob.Patient = patient;
                    frmpob.Text = "市保—住院登记";
                    frmpob.isInDiagnose = true;
                    frmpob.ShowDialog();

                    DialogResult result = frmpob.DialogResult;

                    if (result == DialogResult.OK)
                    {
                    }
                    else
                    {
                        return -1;
                    }
                    //
                    patient.SIMainInfo.OutDiagnose.ID = string.Empty;
                    patient.SIMainInfo.OutDiagnose.Name = string.Empty;
                    int returnValue = Functions.TreatInfoEntry(regType, transType, patient.ID, patient.SIMainInfo.MedicalType.ID, patient.PVisit.InTime.ToString(DATE_TIME_FORMAT),
                    patient.PVisit.OutTime.ToString(DATE_TIME_FORMAT), patient.SIMainInfo.InDiagnose.Name, patient.SIMainInfo.InDiagnose.ID, patient.SIMainInfo.OutDiagnose.Name, patient.SIMainInfo.OutDiagnose.ID,
                    patient.SIMainInfo.OperInfo.ID, patient.PVisit.InTime.ToString(DATE_TIME_FORMAT), string.Empty, dataBuffer);



                    if (returnValue != 0)
                    {
                        this.errText = dataBuffer.ToString();

                        return -1;
                    }
                    //取序号
                    localManager.SetTrans(this.trans);
                    string balanceNO = this.localManager.GetBalNo(patient.ID);
                    if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                    {
                        balanceNO = "0";
                    }
                  
                    balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                    patient.SIMainInfo.BalNo = balanceNO;
                    patient.SIMainInfo.IsValid = true;
                    returnValue = this.localManager.InsertSIMainInfo(patient);
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
                    patient = this.localManager.GetSIPersonInfo(patient.ID, "0");
                    if (patient == null)
                    {
                        this.errText = "没有找到对应的医保住院信息" + this.localManager.Err;
                        return -1;

                    }

                    //如果无费退院更新结算标志

                    if (transType == 1 && regType == 1) //出院登记
                    {
                        //Control.frmSiPobInpatientInfo frmpobOut = new ShenYangCitySI.Control.frmSiPobInpatientInfo();
                        //frmpobOut.Patient = patient;
                        //frmpobOut.Text = "市保—出院登记";
                        //frmpobOut.isInDiagnose = false;
                        //frmpobOut.ShowDialog();

                        //DialogResult result1 = frmpobOut.DialogResult;

                        //if (result1 == DialogResult.OK)
                        //{

                        //}
                        //else
                        //{
                        //    return -1;
                        //}
                        #region 向实体写入出院主诊断
                        Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC diagMgr = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC();
                        diagMgr.SetTrans(this.trans);
                        ArrayList mainOutdiagNoseList = diagMgr.GetOutMainDiagnose(patient.ID);
                        Neusoft.HISFC.Models.HealthRecord.Diagnose tempDiagNose = null;
                        if (mainOutdiagNoseList.Count > 0)
                        {
                            tempDiagNose = (Neusoft.HISFC.Models.HealthRecord.Diagnose)mainOutdiagNoseList[0];
                            patient.SIMainInfo.OutDiagnose.ID = tempDiagNose.DiagInfo.ICD10.ID;
                            patient.SIMainInfo.OutDiagnose.Name = tempDiagNose.DiagInfo.ICD10.Name;
                        }
                        else
                        {
                            this.errText = "该患者没有出院主诊断！";
                            return -1;
                        }
                        #endregion

                        #region 询问是否更改患者医疗类别
                        if (MessageBox.Show("是否更改该患者医疗类别？","提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Control.frmSiPobInpatientInfoOut frmpobOut = new ShenYangCitySI.Control.frmSiPobInpatientInfoOut();
                            frmpobOut.Patient = patient;
                            frmpobOut.Text = "医疗类别";
                            frmpobOut.ShowDialog();

                            DialogResult result1 = frmpobOut.DialogResult;

                            if (result1 == DialogResult.OK)
                            {

                            }
                            else
                            {
                                return -1;
                            }
                        }
                        #endregion

                        //更新出院诊断
                        int  returnValue1 = this.localManager.UpdateSiMainInfo(patient);
                        if (returnValue1 < 0)
                        {
                            this.errText = "更新fin_ipr_sinmaininfo结算标志出错" + this.localManager.Err;
                            return -1;
                        }
                    }

                    #region 处理出院登记，出院召回，无费出院
                    int returnValue = Functions.TreatInfoEntry(regType, transType, patient.ID, patient.SIMainInfo.MedicalType.ID, patient.PVisit.InTime.ToString(DATE_TIME_FORMAT),
                    patient.PVisit.OutTime.ToString(DATE_TIME_FORMAT), patient.SIMainInfo.InDiagnose.Name, patient.SIMainInfo.InDiagnose.ID, patient.SIMainInfo.OutDiagnose.Name, patient.SIMainInfo.OutDiagnose.ID,
                    patient.SIMainInfo.OperInfo.ID, patient.PVisit.InTime.ToString(DATE_TIME_FORMAT), string.Empty, dataBuffer);


                    if (returnValue != 0)
                    {
                        this.errText = dataBuffer.ToString();

                        return -1;
                    }

                    

                    if (transType == -1&& regType == 0)  //无费退院
                    {
                        //更新fin_ipr_sinmaininfo
                        patient.SIMainInfo.IsBalanced = true;
                        returnValue = this.localManager.UpdateSiMainInfo(patient);
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
            StringBuilder dataBuffer = new StringBuilder(1024);
            int appCode = 0;
            int selfflag = 0;
            try
            {
                //查找对照信息（费用类别，医疗保险的项目代码）
                interfaceManager.SetTrans(this.trans);
                Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();
                this.interfaceManager.GetCompareSingleItem(p.Pact.ID, f.Item.ID, ref myCompare);
                //对照表里没有的项目
                f.Compare = myCompare;
                if (f.Compare.CenterItem.ID == "" || f.Compare.CenterItem.ID == string.Empty)
                {
                    f.Compare.CenterItem.ID = f.Item.ID;
                    if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                     {
                        //药品
                        f.Compare.CenterItem.SysClass = "1";
                    }
                    else
                    {
                        //诊疗
                        f.Compare.CenterItem.SysClass = "2";
                    }
                   
                    f.Compare.CenterItem.ItemType = f.Item.MinFee.ID;

                }

                //设置
                switch (f.Compare.CenterItem.SysClass)
                {
                    case "L"://诊疗
                        {
                            f.Compare.CenterItem.SysClass = "2";
                            break;
                        }
                    case "X"://西药
                        {
                            f.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "C": //草药
                        {
                            f.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "Z": //中药
                        {
                            f.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "F"://服务设施
                        {
                            f.Compare.CenterItem.SysClass = "3";
                            break;
                        }
                    default:
                        break;
                }

                //医保上传处方处理：处方号+处方内部流水号+加上交易类型（1上传2退费）
                string recipeNO = string.Empty;
                //if (f.RecipeNO.Substring(0, 1) == "y" || f.RecipeNO.Substring(0, 1) == "f")//特殊处理老系统输入的费用明细
                //{
                //    if (transType == "1")
                //    {
                //        recipeNO = f.RecipeNO;

                //    }
                //    else
                //    {
                //        recipeNO = "|" + f.RecipeNO + "|" + f.CancelRecipeNO + "|";
                //    }
                //}
                //else
                //{
                if (transType == "1")
                {
                    recipeNO = f.RecipeNO + f.SequenceNO + "1";

                }
                else
                {
                    recipeNO = "|" + f.RecipeNO + f.SequenceNO + "2" + "|" + f.CancelRecipeNO + f.CancelSequenceNO + "1" + "|";
                }
                //}

                LocalManager lm = new LocalManager();
                if (this.trans != null)
                {
                    lm.SetTrans(this.trans);
                }

                //取得医保费用类别
                Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
                this.localManager.SetTrans(this.trans);
                myPatient = this.localManager.GetSIPersonInfo(p.ID, "0");
                if (myPatient.SIMainInfo.MedicalType.ID == "42" || myPatient.SIMainInfo.MedicalType.ID == "43" || myPatient.SIMainInfo.MedicalType.ID == "44" || myPatient.SIMainInfo.MedicalType.ID == "45")
                {
                    f.Compare.CenterItem.ItemType = lm.GetCenterStat("ZY03", f.Item.MinFee.ID);
                }
                else
                {
                    f.Compare.CenterItem.ItemType = lm.GetCenterStat("ZY02", f.Item.MinFee.ID);
                }

                if (f.Compare.CenterItem.ItemType == "-1" || f.Compare.CenterItem.ItemType == string.Empty)
                {
                    this.errText = "最小费用" + f.Item.MinFee.Name + "没有相应的医保对照信息";
                    return -1;
                }
                #region 判断适用症
                //Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam myCtrlParm = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                //myCtrlParm.SetTrans(this.trans);

                //if (myCtrlParm.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_PRACTICABLE_SYMPTOM, true, false) && !f.Item.Ispracticablesymptom)
                //{
                //    f.Compare.CenterItem.ID = f.Item.ID;
                //}
                #endregion
                //调用接口上传明细方法
                int IsOwnExpenses = 0;
                int returnValue = Functions.FormularyEntry(p.ID, p.ID, f.Item.ID, recipeNO, f.FeeOper.OperTime.ToString(DATE_TIME_FORMAT),
                    f.Compare.CenterItem.ID, f.Item.Name, (double)f.Item.Price, Neusoft.FrameWork.Function.NConvert.ToInt32(f.Item.Qty),
                    (double)f.FT.TotCost, string.Empty, string.Empty, string.Empty, string.Empty, f.FeeOper.Dept.ID, 1, f.Compare.CenterItem.ItemType,
                   ref IsOwnExpenses, dataBuffer);



                if (returnValue == -1)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }
                if (returnValue == 1)
                {
                    this.errText = "患者:" + p.Name + "的项目:[" + f.Item.Name + "] 需要审批而没有审批!";

                    return -1;
                }
                //更新住院上传明细标志
                this.localManager.SetTrans(this.trans);
                returnValue = this.localManager.updateUploadFlagInpatient(f, transType);
                if (returnValue < 0)
                {
                    this.errText = "更新上传标志出错" + this.localManager.Err;
                    return -1;
                }
                //给实体医疗类别赋值
                string medicaltype = this.localManager.GetMedicalType(p.ID, p.SIMainInfo.InvoiceNo, "2");
                if (medicaltype == null || medicaltype == "")
                {
                    this.errText = "医保类别不能为空" + this.localManager.Err;
                }
                p.SIMainInfo.MedicalType.ID = medicaltype;

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

        #region 门诊上传明细方法
        /// <summary>
        /// 上传明细方法
        /// </summary>
        /// <param name="p">患者基本信息抽象类</param>
        /// <param name="itemList">明细基本信息抽象类</param>
        /// <returns>成功 1 失败 -1</returns>
        private int UploadFeeItemList(Neusoft.HISFC.Models.Registration.Register p, Neusoft.HISFC.Models.Fee.FeeItemBase itemList, string transType)
        {
            StringBuilder dataBuffer = new StringBuilder(1024);
            int appCode = 0;
            int selfflag = 0;
            try
            {

                //查找对照信息（费用类别，医疗保险的项目代码）
                Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();
                this.interfaceManager.SetTrans(this.trans);
                this.interfaceManager.GetCompareSingleItem(p.Pact.ID, itemList.Item.ID, ref myCompare);
                itemList.Compare = myCompare;
                //对照表里没有记录
                if (itemList.Compare.CenterItem.ID == "" || itemList.Compare.CenterItem.ID == string.Empty)
                {
                    itemList.Compare.CenterItem.ID = itemList.Item.ID;
                    if (itemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                     {
                        //药品
                        itemList.Compare.CenterItem.SysClass = "1";
                    }
                    else
                    {
                        //诊疗
                        itemList.Compare.CenterItem.SysClass = "2";
                    }
                   
                    itemList.Compare.CenterItem.ItemType = itemList.Item.MinFee.ID;

                }


                switch (itemList.Compare.CenterItem.SysClass)
                {
                    case "L"://诊疗
                        {
                            itemList.Compare.CenterItem.SysClass = "2";
                            break;
                        }
                    case "X"://西药
                        {
                            itemList.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "Z": //成药
                        {
                            itemList.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "C": //中药
                        {
                            itemList.Compare.CenterItem.SysClass = "1";
                            break;
                        }
                    case "F"://服务设施
                        {
                            itemList.Compare.CenterItem.SysClass = "3";
                            break;
                        }
                    default:
                        break;
                }

                //医保上传处方处理：处方号+处方内部流水号+加上交易类型（1上传2退费）
                string recipeNO = string.Empty;
                if (transType == "1")
                {
                    recipeNO = itemList.RecipeNO + itemList.SequenceNO + "1";

                }
                else
                {
                    recipeNO = "/" + itemList.RecipeNO + itemList.SequenceNO + "2" + "/" + itemList.RecipeNO + itemList.SequenceNO + "1" + "/";
                }

                LocalManager lm = new LocalManager();

                //取得医保费用类别
                if (this.trans != null)
                {
                    lm.SetTrans(this.trans);
                }
                //取得医保费用类别
                Neusoft.HISFC.Models.Registration.Register myPatient = new Neusoft.HISFC.Models.Registration.Register();
                this.localManager.SetTrans(this.trans);
                myPatient = this.localManager.GetSIPersonInfoOutPatient(p.ID);

                if (myPatient.SIMainInfo.MedicalType.ID == "42" || myPatient.SIMainInfo.MedicalType.ID == "43" || myPatient.SIMainInfo.MedicalType.ID == "44" || myPatient.SIMainInfo.MedicalType.ID == "45")
                {
                    itemList.Compare.CenterItem.ItemType = lm.GetCenterStat("MZ02", itemList.Item.MinFee.ID);
                }
                else
                {
                    itemList.Compare.CenterItem.ItemType = lm.GetCenterStat("MZ01", itemList.Item.MinFee.ID);
                }

                if (itemList.Compare.CenterItem.ItemType == "-1" || itemList.Compare.CenterItem.ItemType == string.Empty)
                {
                    this.errText = "最小费用" + itemList.Item.MinFee.ID + "没有相应的医保对照信息";
                    return -1;
                }

                int IsOwnExpenses = 0;

                #region 判断适用症
                
                //Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam myCtrlParm = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                //myCtrlParm.SetTrans(this.trans);
                
                //if (myCtrlParm.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_PRACTICABLE_SYMPTOM, true, false) && !itemList.Item.Ispracticablesymptom)
                //{
                //    itemList.Compare.CenterItem.ID = itemList.Item.ID;
                //}
                #endregion
                //调用接口上传明细方法
                int returnValue = Functions.FormularyEntry(p.ID, p.ID, itemList.Item.ID, recipeNO, itemList.FeeOper.OperTime.ToString(DATE_TIME_FORMAT),
                    itemList.Compare.CenterItem.ID, itemList.Item.Name, (double)itemList.Item.Price, Neusoft.FrameWork.Function.NConvert.ToInt32(itemList.Item.Qty),
                    (double)itemList.FT.TotCost, string.Empty, string.Empty, string.Empty, string.Empty, itemList.FeeOper.Dept.ID, 1, itemList.Compare.CenterItem.ItemType,
                    ref IsOwnExpenses, dataBuffer);

                if (returnValue == -1)
                {
                    this.errText = dataBuffer.ToString();

                    return -1;
                }

                if (returnValue == 1)
                {
                    this.errText = "患者:" + p.Name + "的项目:[" + itemList.Item.Name + "] 需要审批而没有审批!";

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
                dataBuffer = null;
            }

            return 1;
        }
        #endregion
        #region 医保配置文件处理
        public static int CreateSISetting()
        {
            try
            {
                XmlDocument docXml = new XmlDocument();
                //if (System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/SiSetting.xml"))
                //{
                //    System.IO.File.Delete(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/SiSetting.xml");
                //}
                //else
                //{
                //    System.IO.Directory.CreateDirectory(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath);
                //}
                //docXml.LoadXml("<setting>  </setting>");
                XmlNode root = docXml.DocumentElement;

                XmlElement elem1 = docXml.CreateElement("医疗机构编码");
                System.Xml.XmlComment xmlcomment;
                xmlcomment = docXml.CreateComment("医疗机构编码");
                elem1.SetAttribute("hospitalNO", "2011");
                root.AppendChild(xmlcomment);
                root.AppendChild(elem1);

                XmlElement elem2 = docXml.CreateElement("医疗机构等级");
                System.Xml.XmlComment xmlcomment2;
                xmlcomment2 = docXml.CreateComment("医疗机构等级");
                elem2.SetAttribute("hosGrade", "02");
                root.AppendChild(xmlcomment2);
                root.AppendChild(elem2);

                docXml.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/SiSetting.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入医疗机构信息出错!" + ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 读取医疗机构及医院等级
        /// </summary>
        private void ReadSISetting()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                if (CreateSISetting() == -1)
                {
                    return;
                }

            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/SiSetting.xml");
                XmlNode node = doc.SelectSingleNode("//医疗机构编码");

                hospitalNO = node.Attributes["hospitalNO"].Value.ToString();

                if (string.IsNullOrEmpty(hospitalNO.Trim()))
                {
                    MessageBox.Show("请在配置文件中维护医疗机构编码");
                    return;
                }

                XmlNode node1 = doc.SelectSingleNode("//医疗机构等级");

                hosGrade = node1.Attributes["hosGrade"].Value.ToString();

                if (string.IsNullOrEmpty(hosGrade.Trim()))
                {
                    MessageBox.Show("请在配置文件中维护医疗机构等级");
                    return;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("获取医疗机构信息出错!" + e.Message);
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
            get { return false ; }
        }

        #endregion
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
