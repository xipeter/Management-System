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
    public partial class ucPhaInDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.Manager inteManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizProcess.Integrate.Pharmacy intePharmacy = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        Neusoft.HISFC.BizLogic.Pharmacy.Item itemPhaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
       
        #endregion

        public ucPhaInDetail()
        {
            InitializeComponent();
        }

        private void ucPhaInDetail_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("加载数据中，请稍候……");
            Application.DoEvents();
            this.cmbQuality.AddItems(inteManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY));
            this.cmbInDept.AddItems(inteManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P));
            this.cmbOper.AddItems(inteManager.QueryEmployeeByDeptID(empl.Dept.ID));
            this.cmbDrug.AddItems(new ArrayList(itemPhaManager.QueryItemList()));
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #region 方法

        protected override int OnRetrieve(params object[] objects)
        {
            string oper = "000";
            string indept = "111";
            string listcode = "222";
            string qualityID = "333";
            string drugID = "444";

            if(this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间！");
                return -1;
            }
            if(ckInDept.Checked)
            {
                if(cmbInDept.SelectedItem == null)
                {
                    MessageBox.Show("请选择领药科室！");
                    return -1;
                }
                indept = cmbInDept.SelectedItem.ID;
            }
            if(ckListCode.Checked)
            {
                if(string.IsNullOrEmpty(txtListCode.Text.Trim()))
                {
                    MessageBox.Show("请输入领药单号！");
                    return -1;
                }
                listcode = txtListCode.Text.Trim();
            }
            if (ckQuality.Checked)
            {
                if (cmbQuality.SelectedItem == null)
                {
                    MessageBox.Show("请选择药品性质！");
                    return -1;
                }
                qualityID = cmbQuality.SelectedItem.ID;
            }
            if (ckOper.Checked)
            {
                if (cmbOper.SelectedItem == null)
                {
                    MessageBox.Show("请选择经办人！");
                    return -1;
                }
                oper = cmbOper.SelectedItem.ID;
            }
            if(ckDrug.Checked)
            {
                if (cmbDrug.SelectedItem == null)
                {
                    MessageBox.Show("请选择药品！");
                    return -1;
                }
                drugID = cmbDrug.SelectedItem.ID;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,oper,indept,listcode,qualityID,drugID);
        }
        #endregion

        #region 事件

        private void ckInDept_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInDept.Checked)
            {
                this.cmbInDept.Enabled = true;
            }
            else
            {
                cmbInDept.Tag = null;
                cmbInDept.Text = "";
                cmbInDept.Enabled = false;
            }
        }

        private void ckListCode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckListCode.Checked)
            {
                txtListCode.Enabled = true;
            }
            else 
            {
                txtListCode.Text = "";
                txtListCode.Enabled = false;
            }
        }

        private void ckQuality_CheckedChanged(object sender, EventArgs e)
        {
            if (ckQuality.Checked)
            {
                cmbQuality.Enabled = true;
            }
            else
            {
                cmbQuality.Tag = null;
                cmbQuality.Text = "";
                cmbQuality.Enabled = false;
            }
        }

        private void ckOper_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOper.Checked)
            {
                cmbOper.Enabled = true;
            }
            else
            {
                cmbOper.Tag = null;
                cmbOper.Text = "";
                cmbOper.Enabled = false;
            }
        }

        private void ckDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDrug.Checked)
            {
                cmbDrug.Enabled = true;
            }
            else
            {
                cmbDrug.Tag = null;
                cmbDrug.Text = "";
                cmbDrug.Enabled = false;
            }
        }
        #endregion 
    }
}
