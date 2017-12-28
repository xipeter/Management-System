using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.Report.InpatientFee.InpatientChargePrint
{
    class InpatientCharePrint : Neusoft.HISFC.Integrate.FeeInterface.IInpatientChargePrint
    {
        private System.Collections.ArrayList alDrug = new System.Collections.ArrayList();

        private System.Collections.ArrayList alUnDrug = new System.Collections.ArrayList();

        private ucPayListPrint ucUnDrug = null;

        private ucOrderExeQueryPrint ucDrug = null;

        /// <summary>
        /// 患者实体
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo myPatientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();

        #region IInpatientChargePrint 成员

        public Neusoft.HISFC.Object.RADT.PatientInfo Patient
        {
            get
            {
                return this.myPatientInfo;
            }
            set
            {
                this.myPatientInfo = value;
            }
        }

        public int Preview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            if (this.alUnDrug.Count > 0)
            {
                if (this.ucUnDrug == null)
                {
                    this.ucUnDrug = new ucPayListPrint();
                }

                foreach (Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList info in this.alUnDrug)
                {
                    
                    this.ucUnDrug.ControlValue(info);
                    this.ucUnDrug.Print();
                }

                
            }
            if (this.alDrug.Count > 0)
            {
                if (this.ucDrug == null)
                {
                    this.ucDrug = new ucOrderExeQueryPrint();
                }

                this.ucDrug.patientInfoObj = this.Patient;
                this.ucDrug.SetFeeValue(this.alDrug);
                this.ucDrug.Print();

                
            }

            return 1;
        }

        public int SetData(List<Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList> feeItemCollection)
        {
            if (feeItemCollection == null)
            {
                return -1;
            }

            this.alDrug = new System.Collections.ArrayList();
            this.alUnDrug = new System.Collections.ArrayList();

            foreach (Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList info in feeItemCollection)
            {
                //if (info.Item.IsPharmacy)
                if (info.Item.ItemType == Neusoft.HISFC.Object.Base.EnumItemType.Drug)
                {
                    this.alDrug.Add(info);
                }
                else
                {
                    this.alUnDrug.Add(info);
                }
            }

            return 1;

        }

        #endregion
    }
}
