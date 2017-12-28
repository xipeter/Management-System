using System;
using System.Collections.Generic;
using System.Text;

namespace OwnFee
{
    class InterfaceAchieve : Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare
    {
        //错误信息
        private string errMsg = string.Empty;
        #region IMedcare 成员

        public int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            decimal totCost = 0;
            decimal payCost = 0;
            decimal pubcost = 0;
            decimal ownCost = 0;

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeDetails)
            {
                totCost += f.FT.TotCost;
                payCost += f.FT.PayCost;
                pubcost += f.FT.PubCost;
                ownCost += f.FT.OwnCost;

            }

            r.SIMainInfo.TotCost = totCost;
            r.SIMainInfo.PayCost = payCost;
            r.SIMainInfo.PubCost = pubcost;
            r.SIMainInfo.OwnCost = ownCost;

            //判断平衡(在确认r.SIMainInfo.TotCost 应该为r.SIMainInfo.PayCost+r.SIMainInfo.PubCost+r.SIMainInfo.OwnCost 的前提下)
            if (r.SIMainInfo.TotCost != r.SIMainInfo.PayCost + r.SIMainInfo.OwnCost + r.SIMainInfo.PubCost)
            {
                this.errMsg = "总金额与账户支付+公费支付+自费支付不等\n,请核对";
                return -1;
            }
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

        public int CancelBalanceOutpatientHalf(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
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
            get 
            {
                return "自费接口不作任何修改";
            }
        }

        public string ErrCode
        {
            get
            {
                return "";
            }
        }

        public string ErrMsg
        {
            get
            {
                return this.errMsg;
            }
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
            return false;
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return false;
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
            return 1;
        }

        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
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

        public int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
            feeItemList.FT.PayCost = 0m;
            feeItemList.FT.PubCost = 0m;
            return 1;
        }

        public void SetTrans(System.Data.IDbTransaction t)
        {
            return;
        }

        public System.Data.IDbTransaction Trans
        {
            set 
            { 
            }
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
            return;
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


        public int CancelRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        public int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }
        public int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        } 

        #endregion

        #region IMedcare 成员


        public int CancelRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
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



        #region IMedcare 成员


        public int QueryFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        public int QueryFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            return 1;
        }

        #endregion
    }
}
