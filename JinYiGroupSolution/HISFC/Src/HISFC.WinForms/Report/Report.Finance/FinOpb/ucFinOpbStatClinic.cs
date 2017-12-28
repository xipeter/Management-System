using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Finance.FinOpb
{
    public partial class ucFinOpbStatClinic : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinOpbStatClinic()
        {
            InitializeComponent();
        }
        int currentNo = 0;

        protected override void OnLoad(EventArgs e)
        {
            ArrayList list = new ArrayList();
            Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
            list = con.GetAllList("PACTUNIT");
            this.neuPact.AddItems(list);
            base.OnLoad(e);
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.neuTabControl1.SelectedTab.Text == "未取药处方")
            {
                return this.dwNoDrug.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            if (this.neuTabControl1.SelectedTab.Text == "未取药退费处方")
            {
                return this.dwNoFeeNoDrug.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            if (this.neuTabControl1.SelectedTab.Text == "已取药处方")
            {
                return this.dwFeeDrug.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            if (this.neuTabControl1.SelectedTab.Text == "未核对检查单")
            {
                return dwDetail.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            if (this.neuTabControl1.SelectedTab.Text == "退费检查单")
            {
                return dwOutFee.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            if (this.neuTabControl1.SelectedTab.Text == "红方退费")
            {
                return dwRedOutFee.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            }
            return 1;
        }

        private void dwNoDrug_DoubleClick(object sender, EventArgs e)
        {
            string no = this.dwNoDrug.GetItemString(currentNo, "收费单号");
            string Inpatient = this.dwNoDrug.GetItemString(currentNo, "患者姓名");
            string dept = this.dwNoDrug.GetItemString(currentNo, "开单科室");
            string doct = this.dwNoDrug.GetItemString(currentNo, "开方医师");
            string date = this.dwNoDrug.GetItemString(currentNo, "收费时间");
            string operfee = this.dwNoDrug.GetItemString(currentNo, "收费人员");
            string ys = this.dwNoDrug.GetItemString(currentNo, "应收金额");
            string ss = this.dwNoDrug.GetItemString(currentNo, "实收金额");            

            ucFinOpbStatClinicDetail detail = new ucFinOpbStatClinicDetail();
            detail.Init(no, Inpatient, dept, doct, operfee, date, ys, ss,"门诊未取药处方明细");
            detail.ShowDialog();
        }

        private void dwNoFeeNoDrug_DoubleClick(object sender, EventArgs e)
        {
            string no = this.dwNoFeeNoDrug.GetItemString(currentNo, "收费单号");
            string Inpatient = this.dwNoFeeNoDrug.GetItemString(currentNo, "患者姓名");
            string dept = this.dwNoFeeNoDrug.GetItemString(currentNo, "开单科室");
            string doct = this.dwNoFeeNoDrug.GetItemString(currentNo, "开方医师");
            string date = this.dwNoFeeNoDrug.GetItemString(currentNo, "收费时间");
            string operfee = this.dwNoFeeNoDrug.GetItemString(currentNo, "退费人员");
            string ys = this.dwNoFeeNoDrug.GetItemString(currentNo, "应退金额");
            string ss = this.dwNoFeeNoDrug.GetItemString(currentNo, "实退金额");

            ucFinOpbStatClinicDetail detail = new ucFinOpbStatClinicDetail();
            detail.Init(no, Inpatient, dept, doct, operfee, date, ys, ss, "门诊未取药退费处方统计");
            detail.ShowDialog();
        }
        private void dwRedOutFee_DoubleClick(object sender, EventArgs e)
        {
            string no = this.dwRedOutFee.GetItemString(currentNo, "收费单号");
            string Inpatient = this.dwRedOutFee.GetItemString(currentNo, "患者姓名");
            string dept = this.dwRedOutFee.GetItemString(currentNo, "开单科室");
            string doct = this.dwRedOutFee.GetItemString(currentNo, "开方医师");
            string date = this.dwRedOutFee.GetItemString(currentNo, "收费时间");
            string operfee = this.dwRedOutFee.GetItemString(currentNo, "退费人员");
            string fee = this.dwRedOutFee.GetItemString(currentNo, "实退金额");
            string ss = "";

            ucFinOpbStatClinicDetail detail = new ucFinOpbStatClinicDetail();
            detail.Init(no, Inpatient, dept, doct, operfee, date, fee, ss, "门诊处方发药处方明细");
            detail.ShowDialog();
        }

        private void dwNoDrug_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            currentNo = e.RowNumber;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.neuTabControl1.SelectedTab.Text == "未取药处方")
            {
                dwNoDrug.Print();
            }
            if (this.neuTabControl1.SelectedTab.Text == "未取药退费处方")
            {
                dwNoFeeNoDrug.Print();
            }
            if (this.neuTabControl1.SelectedTab.Text == "已取药处方")
            {
                dwFeeDrug.Print();
            }
            if (this.neuTabControl1.SelectedTab.Text == "未核对检查单")
            {
                dwDetail.Print();
            }
            if (this.neuTabControl1.SelectedTab.Text == "退费检查单")
            {
                dwOutFee.Print();
            }
            if (this.neuTabControl1.SelectedTab.Text == "红方退费")
            {
                dwRedOutFee.Print();
            }
            return 1;
        }

        string a = "(患者拼音码 like '%{0}%') or (发票流水号 like '%{1}%') or (科室拼音码 like '%{2}%') or (医师拼音码 like '%{3}%') or (收费员拼音码 like '%{4}%') or(合同单位  like '%{5}%')";
        string b = "(患者拼音码 like '%{0}%') or (发票流水号 like '%{1}%') or (科室拼音码 like '%{2}%') or (医师拼音码 like '%{3}%') or (收费员拼音码 like '%{4}%') or(项目拼音码 like '%{5}%') or (合同单位 like '%{6}%')";

        private void neuInpatient_TextChanged(object sender, EventArgs e)
        {
             string patient = this.neuInpatient.Text.Trim().ToUpper().Replace(@"\", "");
             string invoic = this.neuInvoic.Text.Trim().ToUpper().Replace(@"\", "");
             string dept = this.neuDept.Text.Trim().ToUpper().Replace(@"\", "");
             string doct = this.neuDoct.Text.Trim().ToUpper().Replace(@"\", "");
             string operfee = this.neuFeeOper.Text.Trim().ToUpper().Replace(@"\", "");
            string item=this.neuItem.Text.Trim().ToUpper().Replace(@"\", "");
            string pact = this.neuPact.Tag.ToString();

            if (this.neuTabControl1.SelectedTab.Text == "未取药处方")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && pact.Equals(""))
                {

                    this.dwNoDrug.SetFilter("");
                    this.dwNoDrug.Filter();
                    return;
                }

                string str = string.Format(a, patient, invoic, dept, doct, operfee, pact);
                this.dwNoDrug.SetFilter(str);
                this.dwNoDrug.Filter();       
            }
            if (this.neuTabControl1.SelectedTab.Text == "未取药退费处方")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && pact.Equals(""))
                {

                    this.dwNoFeeNoDrug.SetFilter("");
                    this.dwNoFeeNoDrug.Filter();
                    return;
                }

                string str = string.Format(a, patient, invoic, dept, doct, operfee, pact);
                this.dwNoFeeNoDrug.SetFilter(str);
                this.dwNoFeeNoDrug.Filter();  
            }
            if (this.neuTabControl1.SelectedTab.Text == "已取药处方")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && pact.Equals(""))
                {

                    this.dwFeeDrug.SetFilter("");
                    this.dwFeeDrug.Filter();
                    return;
                }

                string str = string.Format(a, patient, invoic, dept, doct, operfee, pact);
                this.dwFeeDrug.SetFilter(str);
                this.dwFeeDrug.Filter();  
            }
            if (this.neuTabControl1.SelectedTab.Text == "未核对检查单")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && item.Equals("")&&pact.Equals(""))
                {

                    this.dwDetail.SetFilter("");
                    this.dwDetail.Filter();
                    return;
                }

                string str = string.Format(b, patient, invoic, dept, doct, operfee, item, pact);
                this.dwDetail.SetFilter(str);
                this.dwDetail.Filter();        
            }
            if (this.neuTabControl1.SelectedTab.Text == "退费检查单")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && item.Equals("") && pact.Equals(""))
                {

                    this.dwOutFee.SetFilter("");
                    this.dwOutFee.Filter();
                    return;
                }

                string str = string.Format(b, patient, invoic, dept, doct, operfee, item, pact);
                this.dwOutFee.SetFilter(str);
                this.dwOutFee.Filter();       
            }
            if (this.neuTabControl1.SelectedTab.Text == "红方退费")
            {
                if (patient.Equals("") && invoic.Equals("") && dept.Equals("") && doct.Equals("") && operfee.Equals("") && pact.Equals(""))
                {

                    this.dwRedOutFee.SetFilter("");
                    this.dwRedOutFee.Filter();
                    return;
                }

                string str = string.Format(a, patient, invoic, dept, doct, operfee, pact);
                this.dwRedOutFee.SetFilter(str);
                this.dwRedOutFee.Filter();
            }
        }
    }
}
