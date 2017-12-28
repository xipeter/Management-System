using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucStoSendDrug : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoSendDrug()
        {
            InitializeComponent();
        }

        DeptZone deptZone1 = DeptZone.ALL;

        #region 枚举DeptZone
        public enum DeptZone
        {
            //门诊
            MZ = 0,
            //住院
            ZY = 1,
            //全院
            ALL = 2,
        }
        #endregion

        #region 属性
        [Category("控制设置"), Description("查询范围：MZ:门诊、ZY:住院、ALL:全院")]
        public DeptZone DeptZone1
        {
            get
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }
        #endregion

        #region 初始化

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);

            cmbFeelan.ClearItems();
            if (deptZone1 == DeptZone.ALL)
            {
                cmbFeelan.Items.Add("全院");
                cmbFeelan.Items.Add("门诊");
                cmbFeelan.Items.Add("住院");
                cmbFeelan.SelectedIndex = 0;
            }
            if (deptZone1 == DeptZone.MZ)
            {
                cmbFeelan.Items.Add("门诊");
                cmbFeelan.SelectedIndex = 0;
                cmbFeelan.Visible = false;
            }
            if (deptZone1 == DeptZone.ZY)
            {
                cmbFeelan.Items.Add("住院");
                cmbFeelan.SelectedIndex = 0;
                cmbFeelan.Visible = false;
            }
        }

      

  
        #endregion

        #region 查询

        protected override int OnRetrieve(params object[] objects)
        {
            if (GetQueryTime() == -1)
            {
                return -1;
            }
            Neusoft.HISFC.Models.Base.Employee employee = null;
            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
            string  strFeelan = "全院";
            if (!string.IsNullOrEmpty(strFeelan = cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString()))
            {
                strFeelan = cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString();
            }
            
            return base.OnRetrieve(this.beginTime,this.endTime,employee.Dept.ID.ToString(),strFeelan);
        }

        #endregion
    }
}