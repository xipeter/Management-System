using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.DrugStore
{
    public partial class ucPhaMetDrugInput : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaMetDrugInput()
        {
            InitializeComponent();
        }
        #region 变量
      
        /// <summary>
        /// 部门管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 用于存储药库科室列表
        /// </summary>
        private ArrayList deptList = new ArrayList();
       
        

        #endregion

    

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string deptNameStr = "ALL";
            string deptName = string.Empty;

            if (this.cmbDept.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDept.SelectedItem.ID))
                {
                    deptNameStr = this.cmbDept.SelectedItem.ID;
                    deptName = this.cmbDept.SelectedItem.Name;
                }
            }

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptNameStr, this.employee.Name, deptName);            
           
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            this.cmbDept.Items.Clear();
           
            deptList = new ArrayList();            
            deptList = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);//药库                    
            this.cmbDept.AddItems(deptList);  

            this.isAcross = true;
            this.isSort = false;
        }

        

        
    }
}
