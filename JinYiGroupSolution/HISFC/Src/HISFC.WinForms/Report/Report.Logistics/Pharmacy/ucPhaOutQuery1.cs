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
    public partial class ucPhaOutQuery1 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量
        /// <summary>
        /// 综合业务层实例
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private string oper = Neusoft.FrameWork.Management.Connection.Operator.Name;
        
        private string deptID;
        private string deptName;

        #endregion 

        public ucPhaOutQuery1()
        {
            InitializeComponent();
        }

        private void ucPhaOutQuery1_Load(object sender, EventArgs e)
        {
            this.isAcross = true;
            this.isSort = false;

            this.InitData();
        }

        #region 方法

        private void InitData()
        {
            ArrayList al = this.integrateManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
            this.cmbPharmacy.AddItems(al);
        }

        #endregion 

        #region 事件
        protected override int OnRetrieve(params object[] objects)
        {
            if(this.cmbPharmacy.Tag == null || string.IsNullOrEmpty(this.cmbPharmacy.Text.Trim()))
            {
                MessageBox.Show("请选择需要统计的药库！");
                return -1;
            }
            if(this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("查询开始时间不能大于查询结束时间！");
                return -1;
            }
            return base.OnRetrieve(this.deptID,this.oper,this.dtpBeginTime.Value,this.dtpEndTime.Value,this.deptName);
        }

        private void cmbPharmacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptID = this.cmbPharmacy.SelectedItem.ID;
            deptName = this.cmbPharmacy.SelectedItem.Name;
        }
        #endregion 
    }
}
