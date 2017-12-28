using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// [控件描述: 批量查询过期发药申请以及取消未摆药单据/屏蔽隐藏待摆药的患者或药品 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}]
    /// [创 建 人: 孙久海]
    /// [创建时间: 2010-11-18]
    /// </summary>
    public partial class ucHidePatient : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucHidePatient()
        {
            InitializeComponent();
        }

        #region 变量

        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        private Neusoft.HISFC.BizProcess.Integrate.Order orderManager = new Neusoft.HISFC.BizProcess.Integrate.Order();

        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        private Hashtable hsApplydept = new Hashtable();

        //{78DC5E1C-423D-4307-B7AE-403C636E9574}护士站也可自己取消自己科室的发药申请
        private bool isDrugStore = false;//true;
        /// <summary>
        /// 是否是挂在药房
        /// </summary>
        [Category("控制参数"),Description("是否是药房 true：是  false：不是")]
        public bool IsDrugStore
        {
            get
            {
                return isDrugStore;
            }
            set
            {
                isDrugStore = value;
            }
        }

        #endregion

        #region 方法

        public void InitDept()
        {            
            ArrayList alDept = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);            
            Neusoft.HISFC.Models.Base.Department deptAll = new Neusoft.HISFC.Models.Base.Department();
            deptAll.ID = "ALL";
            deptAll.Name = "全部科室";
            deptAll.SpellCode = "QBKS";
            alDept.Insert(0, deptAll);
            this.cbbStockDept.Items.Clear();
            this.cbbStockDept.AddItems(alDept);
            this.cbbStockDept.SelectedIndex = 0;

           // {78DC5E1C-423D-4307-B7AE-403C636E9574}护士站也可自己取消自己科室的发药申请
            if (this.isDrugStore == true)
            {
                this.cbbApplyDept.Items.Clear();
                ArrayList alTemp = new ArrayList();
                alTemp = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                alTemp.AddRange(this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.OP));
                alTemp.AddRange(this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.U));
                alTemp.AddRange(this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.T));
                Neusoft.FrameWork.Models.NeuObject tempObj = new Neusoft.FrameWork.Models.NeuObject();
                tempObj.ID = "ALL";
                tempObj.Name = "全部科室";
                alTemp.Insert(0, tempObj);
                this.cbbApplyDept.AddItems(alTemp);
                this.cbbApplyDept.Tag = "ALL";
            }
            else
            {
                this.lblApplyDept.Visible = false;
                this.cbbApplyDept.Enabled = false;
                this.cbbApplyDept.Visible = false;
            }
        }

        public void QueryData()
        {
            this.fpApplyList.RowCount = 0;
            ArrayList alTemp = new ArrayList();

            // {78DC5E1C-423D-4307-B7AE-403C636E9574}护士站也可自己取消自己科室的发药申请
            if (this.isDrugStore == true)
            {
                alTemp = this.itemManager.QueryApplyOutByApplyDate(this.cbbStockDept.SelectedItem.ID, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(), this.cbbApplyDept.SelectedItem.ID, this.tbDrugBill.Text);
            }
            else
            {
                string applyDeptCode = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                alTemp = this.itemManager.QueryApplyOutByApplyDate(this.cbbStockDept.SelectedItem.ID, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(), applyDeptCode, this.tbDrugBill.Text);
            }
            if (alTemp == null || alTemp.Count == 0)
            {
                MessageBox.Show("没有查询到满足条件的数据");
                return;
            }

            for (int i = 0; i < alTemp.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut aoTemp = alTemp[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                this.fpApplyList.RowCount = i + 1;
                this.fpApplyList.Cells[i, 0].Text = "False";
                Neusoft.HISFC.Models.Base.Department deptObj = this.deptManager.GetDeptmentById(aoTemp.ApplyDept.ID);
                if (deptObj != null)
                {
                    this.fpApplyList.Cells[i, 1].Text = deptObj.Name;
                }
                else
                {
                    this.fpApplyList.Cells[i, 1].Text = "";
                }
                this.fpApplyList.Cells[i, 2].Text = aoTemp.DrugNO;
                this.fpApplyList.Cells[i, 3].Text = aoTemp.Item.Name;
                this.fpApplyList.Cells[i, 4].Text = aoTemp.Operation.ApplyQty.ToString();
                this.fpApplyList.Cells[i, 5].Text = aoTemp.Item.MinUnit;
                this.fpApplyList.Cells[i, 6].Text = aoTemp.Operation.ApplyOper.OperTime.ToString();
                this.fpApplyList.Cells[i, 7].Text = aoTemp.PatientNO;
                if (aoTemp.State == "0")
                {
                    this.fpApplyList.Cells[i, 8].Text = "未发送";
                }
                else if (aoTemp.State == "6")
                {
                    this.fpApplyList.Cells[i, 8].Text = "已发送";
                }
                else if (aoTemp.State == "5")
                {
                    this.fpApplyList.Cells[i, 8].Text = "已打印";
                }
                else
                {
                    this.fpApplyList.Cells[i, 8].Text = "";
                }

                this.fpApplyList.Rows[i].Tag = aoTemp;
            }
        }

        /// <summary>
        /// 作废用药申请
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CancelApply()
        {
            if (this.fpApplyList.RowCount <= 0)
            {
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            for (int i = 0; i < this.fpApplyList.RowCount; i++)
            {
                if (this.fpApplyList.Cells[i, 0].Text == "False")
                {
                    continue;
                }
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.fpApplyList.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                Neusoft.HISFC.Models.RADT.PatientInfo patientObj = radtIntegrate.QueryPatientInfoByInpatientNO(applyOut.PatientNO);
                bool isInState = true;
                if (patientObj.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                {
                    isInState = false;
                }

                //还原发送申请                
                if (itemManager.CancelApplyDrug(applyOut.ID, isInState) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("取消发药申请失败");
                    return -1;
                }

                //对已经无效的数据 不重复保存
                //if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                //{
                //    continue;
                //}

                ////作废摆药申请
                //if (itemManager.CancelApplyOutByID(applyOut.ID, false) == -1)
                //{
                //    Neusoft.NFC.Management.PublicTrans.RollBack();
                //    MessageBox.Show("作废摆药申请失败");
                //    return -1;
                //}

                ////作废医嘱执行档                           
                //Neusoft.HISFC.Models.Base.Employee empl = Neusoft.NFC.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                //Neusoft.NFC.Object.NeuObject operObj = Neusoft.NFC.Management.Connection.Operator;
                //if (orderManager.DcExecImmediateUnNormal(applyOut.ExecNO, true, operObj) == -1)
                //{
                //    Neusoft.NFC.Management.PublicTrans.RollBack();
                //    MessageBox.Show("作废医嘱执行档失败");
                //    return -1;
                //}
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("取消发药申请成功");
            this.QueryData();

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            this.dtpBegin.Value = DateTime.Now.Date.AddDays(-7);
            this.dtpEnd.Value = DateTime.Now.Date.AddDays(1);
            this.InitDept();
            base.OnLoad(e);
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {            
            this.QueryData();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();
            return base.OnQuery(sender, neuObject);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelectAll.Checked)
            {
                for (int i = 0; i < this.fpApplyList.RowCount; i++)
                {
                    this.fpApplyList.Cells[i, 0].Text = "True";
                }
            }
            else
            {
                for (int i = 0; i < this.fpApplyList.RowCount; i++)
                {
                    this.fpApplyList.Cells[i, 0].Text = "False";
                }
            }
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.CancelApply();
        }

    }
}
