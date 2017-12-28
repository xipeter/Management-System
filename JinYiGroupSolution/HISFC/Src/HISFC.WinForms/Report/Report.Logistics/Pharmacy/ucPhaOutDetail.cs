using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaOutDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.Manager inteManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Pharmacy.Item itemPhaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        #endregion

        public ucPhaOutDetail()
        {
            InitializeComponent();
        }

        private void ucPhaOutDetail_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("加载数据中，请稍候……");
            Application.DoEvents();

            this.InitDrugStores();
            cmbDrug.AddItems(new ArrayList(itemPhaManager.QueryItemList()));
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #region 方法

        private void InitDrugStores()
        {
            ArrayList al = new ArrayList();
            al = inteManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            this.cmbOutDept.AddItems(al);
        }

        protected override int OnRetrieve(params object[] objects)
        {
            string listCode = "000";
            string outDept = "111";
            string drugID = "222";

            if(this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间！");
                return -1;
            }
            if(this.ckListCode.Checked)
            {
                if(string.IsNullOrEmpty(this.txtListCode.Text.Trim()))
                {
                    MessageBox.Show("请输入退货单据号！");
                    return -1;
                }
                listCode = this.txtListCode.Text.Trim();
            }
            if(this.ckOutDept.Checked)
            {
                if (this.cmbOutDept.SelectedItem == null)
                {
                    MessageBox.Show("请选择退药科室！");
                    return -1;
                }
                outDept = this.cmbOutDept.SelectedItem.ID;
            }
            if(this.ckDrugID.Checked)
            {

                if (this.cmbDrug.SelectedItem == null)
                {
                    MessageBox.Show("请选择药品！");
                    return -1;
                }
                drugID = this.cmbDrug.SelectedItem.ID;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,listCode,outDept,drugID);
        }
        #endregion 

        #region 事件

        private void ckListCode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckListCode.Checked)
            {
                this.txtListCode.Enabled = true;
            }
            else
            {
                this.txtListCode.Text = "";
                this.txtListCode.Enabled = false;
            }
        }

        private void ckOutDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckOutDept.Checked)
            {
                this.cmbOutDept.Enabled = true;
            }
            else
            {
                this.cmbOutDept.Text = "";
                this.cmbOutDept.Tag = null;
                this.cmbOutDept.Enabled = false;
            }
        }

        private void ckDrugID_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckDrugID.Checked)
            {
                this.cmbDrug.Enabled = true;
            }
            else
            {
                this.cmbDrug.Text = "";
                this.cmbDrug.Tag = null;
                this.cmbDrug.Enabled = false;
            }
        }

        #endregion 
    }
}
