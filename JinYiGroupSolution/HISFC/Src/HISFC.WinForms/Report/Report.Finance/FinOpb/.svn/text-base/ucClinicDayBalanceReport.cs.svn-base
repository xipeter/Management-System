using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucClinicDayBalanceReport : UserControl
    {
        public ucClinicDayBalanceReport()
        {
            InitializeComponent();
        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitUC()
        {
            // 设置医院名称
            Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
            this.labelHospital.Text = constant.GetHospitalName() + "门诊收费员缴款日报表";
        }

        #endregion
    }
}
