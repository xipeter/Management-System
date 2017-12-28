using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.InpatientFee.InpatientChargePrint
{
    public partial class ucPayListPrint : UserControl, Neusoft.UFC.Terminal.Confirm.TerminalInterface
    {
        public ucPayListPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 住院收费业务层

        /// </summary>
        protected Neusoft.HISFC.Management.Fee.InPatient inpatientManager = new Neusoft.HISFC.Management.Fee.InPatient();

        #region TerminalInterface 成员

        public int ControlValue(object obj)
        {
            if (obj == null)
            {
                return -1;
            }
            Neusoft.HISFC.Integrate.RADT radt = new Neusoft.HISFC.Integrate.RADT();
            Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList itemInfo = (Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList)obj;
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = radt.GetPatientInfoByPatientNO(itemInfo.Patient.ID);
            this.lbName1.Text = itemInfo.Patient.Name.ToString();
            this.lbPatientNo1.Text = itemInfo.Patient.PID.PatientNO.ToString();
            this.lbDept1.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            this.lbItemName1.Text = itemInfo.Item.Name;
            this.lbExeDept1.Text = itemInfo.ExecOper.Dept.Name;
            this.lbItemQty1.Text = itemInfo.Item.Qty.ToString();
            this.lbCost1.Text = String.Format("{0:N}",(itemInfo.Item.Price * itemInfo.Item.Qty));
            this.lbCostUp1.Text = Neusoft.NFC.Function.NConvert.ToCapital(itemInfo.Item.Price * itemInfo.Item.Qty).ToString();
            this.lbNo1.Text = itemInfo.Order.ID;//医嘱流水号
            this.lbOperCode1.Text = Neusoft.NFC.Management.Connection.Operator.ID;
            this.lbDate1.Text = this.inpatientManager.GetDateTimeFromSysDateTime().ToString();
            return 1;

            
        }

        public int Print()
        {
            Neusoft.NFC.Interface.Classes.Print p = new Neusoft.NFC.Interface.Classes.Print();
            Neusoft.HISFC.Object.Base.PageSize pz = new Neusoft.HISFC.Object.Base.PageSize("JZDDY",460,380);
            p.SetPageSize(pz);
            p.PrintPage(0, 0, this);
            return 0;
        }

        public int Reset()
        {
            this.lbName1.Text = "";
            this.lbPatientNo1.Text = "";
            this.lbDept1.Text = "";
            this.lbItemName1.Text = "";
            this.lbExeDept1.Text = "";
            this.lbItemQty1.Text = "";
            this.lbCost1.Text = "";
            this.lbCostUp1.Text = "";
            this.lbNo1.Text = "";
            this.lbOperCode1.Text = "";
            this.lbDate1.Text = "";
            return 1;
        }

        #endregion

    }
}
