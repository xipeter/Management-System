using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucClinicDayBalanceDateControl : UserControl
    {
        public ucClinicDayBalanceDateControl()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime dtNow = DateTime.MinValue;

        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Neusoft.Report.Finance.FinOpb.Function.ClinicDayBalance();

        /// <summary>
        /// 上次日结时间
        /// </summary>
        public DateTime dtLastBalance = DateTime.MinValue;

        #endregion

        #region 获取日结截止时间(1：成功/-1：非法)
        /// <summary>
        /// 获取日结截止时间(1：成功/-1：非法)
        /// </summary>
        /// <param name="balanceDate">返回的日结截止时间</param>
        /// <returns>1：成功/-1：非法</returns>
        public int GetBalanceDate(ref string balanceDate)
        {
            //
            // 变量定义
            //
            // 用户录入的日结截止时间
            DateTime dtInput = DateTime.MinValue;

            // 获取当前时间
            this.dtNow = this.clinicDayBalance.GetDateTimeFromSysDateTime();

            // 获取用户输入的日结截止时间
            dtInput = this.dtpBalanceDate.Value;

            // 判断用户输入的合法性
            if (dtInput > this.dtNow)
            {
                MessageBox.Show("日结时间不能大于当前时间");
                this.dtpBalanceDate.Value = this.dtNow;
                this.dtpBalanceDate.Focus();
                return -1;
            }
            else if (dtInput < this.dtLastBalance)
            {
                MessageBox.Show("日结时间不能小于上次日结时间");
                this.dtpBalanceDate.Value = this.dtNow;
                return -1;
            }

            // 设置返回值
            balanceDate = dtInput.ToString();

            return 1;
        }
        #endregion
    }
}
