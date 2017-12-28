using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinReg
{
    public partial class unFinIpbDeptDrug : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public unFinIpbDeptDrug()
        {
            InitializeComponent();
        }

        private DeptZone deptZone1 = DeptZone.ALL;

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

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("结束时间不能小于开始时间");
            }

            if (this.cmbDeptZone.Items[cmbDeptZone.SelectedIndex].ToString() == "按患者所在科室统计")
            {
                this.MainDWDataObject = "d_fin_ipb_deptfeebyfeelan_drug";
                dwMain.DataWindowObject = "d_fin_ipb_deptfeebyfeelan_drug";
            }
            else if (this.cmbDeptZone.Items[cmbDeptZone.SelectedIndex].ToString() == "按开立科室统计")
            {
                this.MainDWDataObject = "d_fin_ipb_deptfeefeelan_drugrepicpe";
                dwMain.DataWindowObject = "d_fin_ipb_deptfeefeelan_drugrepicpe";
            }
            else if (this.cmbDeptZone.Items[cmbDeptZone.SelectedIndex].ToString() == "按执行科室统计")
            {
                this.MainDWDataObject = "d_fin_ipb_deptfeebyfeelan_drugexec";
                dwMain.DataWindowObject = "d_fin_ipb_deptfeebyfeelan_drugexec";
            }


            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbd";
            dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbd";


            string strFeelan = "全院";

            if (!string.IsNullOrEmpty(cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString()))
            {
                strFeelan = cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString();
            }



            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, strFeelan);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            cmbFeelan.Items.Clear();
            if (this.deptZone1 == DeptZone.ALL)
            {
                this.cmbFeelan.Items.Add("门诊");
                this.cmbFeelan.Items.Add("住院");
                this.cmbFeelan.Items.Add("全院");

                this.cmbFeelan.SelectedIndex = 0;
            }
            if (this.deptZone1 == DeptZone.MZ)
            {
                this.cmbFeelan.Items.Add("门诊");

                this.cmbFeelan.SelectedIndex = 0;

            }
            if (this.deptZone1 == DeptZone.ZY)
            {
                this.cmbFeelan.Items.Add("住院");

                this.cmbFeelan.SelectedIndex = 0;
            }

            this.cmbDeptZone.Items.Clear();
            this.cmbDeptZone.Items.Add("按患者所在科室统计");
            this.cmbDeptZone.Items.Add("按开立科室统计");
            this.cmbDeptZone.Items.Add("按执行科室统计");

            this.cmbDeptZone.SelectedIndex = 0;

            this.isAcross = true;
            this.isSort = false;
        }

        /// <summary>
        /// 枚举
        /// </summary>
        public enum DeptZone
        {
            //门诊
            MZ = 0,
            //住院
            ZY = 1,
            //全院
            ALL = 2,
        }
    }
}
