using System;
using System.Collections.Generic;
using System.Text;

namespace GF
{
    public class Functions : Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare
    {

        #region IMedcare 成员

        #region 变量

        private string errCode = string.Empty;

        private string errMsg = string.Empty;

        private Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactInfoManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        private Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();

        private Neusoft.HISFC.BizLogic.Fee.InPatient inPatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        private Neusoft.HISFC.BizLogic.Fee.Interface interfaceManager = new Neusoft.HISFC.BizLogic.Fee.Interface();

        private const string comparePactCode = "02";
        #endregion

        public int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            if (inPatient.GetFeePreBalance(patient) == -1)
            {
                return -1;
            }
            return 1;
        }

        public int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            //if (feeDetails == null)
            //{
            //    this.errMsg = "费用明细为空!";

            //    return -1;
            //}

            //if (this.trans != null) 
            //{
            //    this.pactItemRate.SetTrans(this.trans);
            //    this.pactInfoManager.SetTrans(this.trans);
            //}

            //r.SIMainInfo.TotCost = 0;
            //r.SIMainInfo.OwnCost = 0;
            //r.SIMainInfo.PayCost = 0;
            //r.SIMainInfo.PubCost = 0;
            
            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeDetails) 
            //{
            //    Neusoft.HISFC.Models.Base.PactItemRate pRate = null; 
                
            //    pRate = this.pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);
            //    if (pRate == null) 
            //    {
            //        pRate = this.pactItemRate.GetOnePaceUnitItemRateByFeeCode(r.Pact.ID, f.Item.MinFee.ID);
            //        if (pRate == null)
            //        {
            //            Neusoft.HISFC.Models.Base.PactInfo p = this.pactInfoManager.GetPactUnitInfoByPactCode(r.Pact.ID);
            //            if (p == null) 
            //            {
            //                this.errMsg = this.pactInfoManager.Err;

            //                return -1;
            //            }

            //            pRate = new Neusoft.HISFC.Models.Base.PactItemRate();

            //            pRate.Rate = p.Rate;
            //        }
            //    }

            //    decimal pubCost = 0;


            //    f.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(f.FT.TotCost * pRate.Rate.OwnRate, 2);

            //    pubCost = f.FT.TotCost - f.FT.OwnCost;

            //    f.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost * pRate.Rate.PayRate, 2);
            //    f.FT.PubCost = pubCost - f.FT.PayCost;

            //    r.SIMainInfo.TotCost += f.FT.TotCost;
            //    r.SIMainInfo.OwnCost += f.FT.OwnCost;
            //    r.SIMainInfo.PayCost += f.FT.PayCost;
            //    r.SIMainInfo.PubCost += f.FT.PubCost;
            //}
            
            
            return 1;
        }

        public int CancelBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int CancelBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int CancelRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

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

        public string Description
        {
            get { return "市离休待遇计算接口"; }
        }

        public string ErrCode
        {
            get { return this.errCode; }
        }

        public string ErrMsg
        {
            get { return this.errMsg; }
        }

        public int GetRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        public int GetRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1;
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r)
        {
            return true;
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return true;
        }

        public int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        public int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int ModifyUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return 1;
        }

        public int ModifyUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            return 1;
        }

        public int ModifyUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int ModifyUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int PreBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            if (this.trans != null)
            {
                this.inPatient.SetTrans(trans);
            }
            else
            {
                return -1;
            }
            if (inPatient.GetFeePreBalance(patient) == -1)
            {
                return -1;
            }
            return 1;
        }

        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            //if (this.trans != null)
            //{
            //    this.pactItemRate.SetTrans(this.trans);
            //    this.pactInfoManager.SetTrans(this.trans);
            //}

            //r.SIMainInfo.TotCost = 0;
            //r.SIMainInfo.OwnCost = 0;
            //r.SIMainInfo.PayCost = 0;
            //r.SIMainInfo.PubCost = 0;

            //if (feeDetails == null) 
            //{
            //    return 1;
            //}

            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeDetails)
            //{
            //    Neusoft.HISFC.Models.Base.PactItemRate pRate = null;
            //    pRate = this.pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);
            //    if (pRate == null)
            //    {
            //        pRate = this.pactItemRate.GetOnePaceUnitItemRateByFeeCode(r.Pact.ID, f.Item.MinFee.ID);
            //        if (pRate == null)
            //        {
            //            Neusoft.HISFC.Models.Base.PactInfo p = this.pactInfoManager.GetPactUnitInfoByPactCode(r.Pact.ID);
            //            if (p == null)
            //            {
            //                this.errMsg = this.pactInfoManager.Err;

            //                return -1;
            //            }

            //            pRate = new Neusoft.HISFC.Models.Base.PactItemRate();

            //            pRate.Rate = p.Rate;
            //        }
            //    }

            //    decimal pubCost = 0;


            //    f.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(f.FT.TotCost * pRate.Rate.OwnRate, 2);

            //    pubCost = f.FT.TotCost - f.FT.OwnCost;

            //    f.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost * pRate.Rate.PayRate, 2);
            //    f.FT.PubCost = pubCost - f.FT.PayCost;

            //    r.SIMainInfo.TotCost += f.FT.TotCost;
            //    r.SIMainInfo.OwnCost += f.FT.OwnCost;
            //    r.SIMainInfo.PayCost += f.FT.PayCost;
            //    r.SIMainInfo.PubCost += f.FT.PubCost;
              
            //}


            return 1;
        }

        public int QueryBlackLists(ref System.Collections.ArrayList blackLists)
        {
            return 1;
        }

        public int QueryDrugLists(ref System.Collections.ArrayList drugLists)
        {
            return 1;
        }

        public int QueryUndrugLists(ref System.Collections.ArrayList undrugLists)
        {
            return 1;
        }

        public int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            //Neusoft.HISFC.Models.Base.PactItemRate pRate = null;

            //if (this.trans != null) 
            //{
            //    this.pactItemRate.SetTrans(this.trans);
            //    this.pactInfoManager.SetTrans(this.trans);
            //}

            //pRate = this.pactItemRate.GetOnepPactUnitItemRateByItem(patient.Pact.ID, f.Item.ID);
            //if (pRate == null)
            //{
            //    pRate = this.pactItemRate.GetOnePaceUnitItemRateByFeeCode(patient.Pact.ID, f.Item.MinFee.ID);
            //    if (pRate == null)
            //    {
            //        Neusoft.HISFC.Models.Base.PactInfo p = this.pactInfoManager.GetPactUnitInfoByPactCode(patient.Pact.ID);
            //        if (p == null)
            //        {
            //            this.errMsg = this.pactInfoManager.Err;

            //            return -1;
            //        }

            //        pRate = new Neusoft.HISFC.Models.Base.PactItemRate();

            //        pRate.Rate = p.Rate;
            //    }
            //}

            //decimal pubCost = 0;


            //f.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(f.FT.TotCost * pRate.Rate.OwnRate, 2);

            //pubCost = f.FT.TotCost - f.FT.OwnCost;

            //f.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost * pRate.Rate.PayRate, 2);

            //f.FT.PubCost = pubCost - f.FT.PayCost;

            Neusoft.HISFC.Models.SIInterface.Compare compareObj= new Neusoft.HISFC.Models.SIInterface.Compare();
            int resultValue = interfaceManager.GetCompareSingleItem(comparePactCode, f.Item.ID, ref compareObj);
            if (resultValue == -1)
            {
                this.errMsg = "查询对照项目信息失败！" + interfaceManager.Err;
                return -1;
            }
            if (resultValue == -2)
            {
                f.FT.OwnCost = f.FT.TotCost;
                f.FT.PubCost = 0;
                f.FT.PayCost = 0;
            }
            else
            {
                decimal payRate = compareObj.CenterItem.Rate;
                if (payRate == 1)
                {
                    f.FT.OwnCost = f.FT.TotCost;
                    f.FT.PubCost = 0;
                    f.FT.PayCost = 0;
                }
                else
                {
                    decimal pubPrice = f.Item.Price * (1 - compareObj.CenterItem.Rate);
                    if (pubPrice > compareObj.CenterItem.Price)
                    {
                        pubPrice = compareObj.CenterItem.Price;
                        
                    }
                    if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug )
                    {
                        f.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(pubPrice * f.Item.Qty / f.Item.PackQty, 2);
                    }
                    
                    f.FT.OwnCost = f.FT.TotCost - f.FT.PubCost;
                    f.FT.PayCost = 0m;
                }
            }


            return 1;
        }

        private System.Data.IDbTransaction trans = null;

        public void SetTrans(System.Data.IDbTransaction t)
        {
            this.trans = t;
        }

        public System.Data.IDbTransaction Trans
        {
            set { this.trans = value; }
        }

        public int UpdateFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return 1;
        }

        public int UploadFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            return 1;
        }

        public int UploadFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            return 1;
        }

        public int UploadFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int UploadFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int UploadRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        public int UploadRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            r.SIMainInfo.OwnCost = r.OwnCost;  //自费金额 
            r.SIMainInfo.PubCost = r.PubCost;  //统筹金额 
            r.SIMainInfo.PayCost = r.PayCost;  //帐户金额 
            return 1;
        }

        #endregion

        #region IMedcareTranscation 成员

        public void BeginTranscation()
        {
            
        }

        public long Commit()
        {
            return 1;
        }

        public long Connect()
        {
            return 1;
        }

        public long Disconnect()
        {
            return 1;
        }

        public long Rollback()
        {
            return 1;
        }

        #endregion

        #region IMedcare 成员


        public int CancelBalanceOutpatientHalf(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
           return 1;
        }

        public int CancelRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1;
        }

        public int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        #endregion

        #region IMedcare 成员


        public bool IsUploadAllFeeDetailsOutpatient
        {
            get { return true ; }
        }

        #endregion
    }
}
