using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    public class ShenyangSI:Integrate.FeeInterface.IMedcare
    {
        #region IMedcare 成员

        public System.Data.IDbTransaction Trans
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public void SetTrans(System.Data.IDbTransaction t)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string ErrCode
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string ErrMsg
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Description
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int QueryBlackLists(ref System.Collections.ArrayList blackLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryUndrugLists(ref System.Collections.ArrayList undrugLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryDrugLists(ref System.Collections.ArrayList drugLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailsAllOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CancelBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CancelBalanceOutpatientHalf(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            System.Data.IDbCommand cmd = null;
            cmd.Connection = ConnectTT;
            cmd.ExecuteNonQuery();
            return 1;
        }

        public int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UploadFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailsAllInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CancelBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IMedcareTranscation 成员

        private static System.Data.IDbConnection connect = null;
        protected static System.Data.IDbConnection ConnectTT
        {
            get
            {
                if (connect.State != System.Data.ConnectionState.Open)
                {
                    connect.Open();
                }
                return connect;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Connect()
        {
            if (connect.State != System.Data.ConnectionState.Open)
            {
                connect.Open();
            }
            return 0;
        }

        public long Disconnect()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public long Commit()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public long Rollback()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void BeginTranscation()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IMedcare 成员


        public int CancelRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            return 1;
        }

        #endregion

        #region IMedcare 成员


        public int CancelRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    

        #region IMedcare 成员


        public bool IsUploadAllFeeDetailsOutpatient
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
