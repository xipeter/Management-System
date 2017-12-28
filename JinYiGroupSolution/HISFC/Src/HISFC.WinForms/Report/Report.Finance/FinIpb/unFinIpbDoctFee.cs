using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class unFinIpbDoctFee : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public unFinIpbDoctFee()
        {
            InitializeComponent();
        }
        #region 变量 
        private DeptZone deptZone1 = DeptZone.ALL;
        /// <summary>
        /// 用于存储统计类型
        /// </summary>
        private string reportCode = string.Empty;
        /// <summary>
        /// 用于存储统计大类list
        /// </summary>
        private List<string> feeStatList = new List<string>();
        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant conManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
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
        protected override int OnRetrieve(params object[] objects)
        {


            if (cmbDeptZone.SelectedIndex == -1)
            {
                MessageBox.Show("请输入查询依据！");
                return -1;
            }


            if (this.cmbDeptZone.Items[cmbDeptZone.SelectedIndex].ToString() == "按医生所在科室统计")
            {
                this.MainDWDataObject = "d_fin_ipb_doctfee_recipe";
                dwMain.DataWindowObject = "d_fin_ipb_doctfee_recipe";
            }
            else if (this.cmbDeptZone.Items[cmbDeptZone.SelectedIndex].ToString() == "按患者所在科室统计")
            {
                this.MainDWDataObject = "d_fin_ipb_doctfee_reg";
                dwMain.DataWindowObject = "d_fin_ipb_doctfee_reg";
            }
         

            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbd";
            dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbd";


            string strFeelan = "全院";

            if (!string.IsNullOrEmpty(cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString()))
            {
                strFeelan = cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString();
            }

            string[] feeStatStr = this.feeStatList.ToArray();
            if (string.IsNullOrEmpty(reportCode) || this.feeStatList.Count == 0)
            {
                MessageBox.Show("请选择统计大类！");
                return -1;
            }

           

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.reportCode, feeStatStr, strFeelan);
           
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
            this.cmbDeptZone.Items.Add("按医生所在科室统计");
            
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
        /// <summary>
        /// 统计大类按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeeStat_Click(object sender, EventArgs e)
        {
            //ucPatientInfoFY patientInfoFY = new ucPatientInfoFY();

            Neusoft.WinForms.Report.Finance.FinIpb.ucFeeStatSelect feeStatSelect = new Neusoft.WinForms.Report.Finance.FinIpb.ucFeeStatSelect();
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "项目选择";
            DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(feeStatSelect);
            if (r == DialogResult.Cancel)
            {
                return;
            }
            this.reportCode = string.Empty;
            this.feeStatList = new List<string>();
            if (!string.IsNullOrEmpty(feeStatSelect.ReportCodeStr))
            {
                this.reportCode = feeStatSelect.ReportCodeStr;
                this.lblMemo.Text = "您当前选择是统计类型是:[" + conManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.FEECODESTAT, feeStatSelect.ReportCodeStr.ToString()) + "]";
            }
            else
            {
                this.reportCode = string.Empty;
            }
            if (feeStatSelect.FeeStatList != null)
            {
                this.feeStatList = feeStatSelect.FeeStatList;
            }        

        }
    }
}
