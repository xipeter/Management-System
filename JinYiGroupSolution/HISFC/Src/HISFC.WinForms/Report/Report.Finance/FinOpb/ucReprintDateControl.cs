using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucReprintDateControl : UserControl
    {
        public ucReprintDateControl()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime dtNowDateTime = DateTime.MinValue;

        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Neusoft.Report.Finance.FinOpb.Function.ClinicDayBalance();
        #endregion

        #region 返回用户设置的日结查询时间(1：成功获取/-1：输入非法)
        /// <summary>
        /// 返回用户设置的日结查询时间(1：成功获取/-1：输入非法)
        /// </summary>
        /// <param name="dtFrom">用户输入的起始时间</param>
        /// <param name="dtTo">用户输入的截止时间</param>
        /// <returns>1：成功获取/-1：输入非法</returns>
        public int GetInputDateTime(ref DateTime dtFrom, ref DateTime dtTo)
        {
            //
            // 获取用户输入时间和系统当前时间
            //
            // 获取当前时间
            this.dtNowDateTime = this.clinicDayBalance.GetDateTimeFromSysDateTime();
            // 用户录入的起始时间
            dtFrom = this.dtpDateFrom.Value;
            // 用户录入的截止时间
            dtTo = this.dtpDateTo.Value;

            //
            // 判断用户输入的合法性
            //
            if (this.dtNowDateTime < dtTo)
            {
                MessageBox.Show("截止日期不能大于当前日期");
                this.dtpDateTo.Value = this.dtNowDateTime;
                this.dtpDateTo.Focus();
                return -1;
            }
            if (dtFrom > dtTo)
            {
                MessageBox.Show("起始时间不能大于开始时间");
                this.dtpDateFrom.Focus();
                return -1;
            }

            return 1;
        }
        #endregion

        #region 本UC加载事件
        /// <summary>
        /// 本UC加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucReprintDateControl_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            // 设置截止时间为当前服务器时间
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            this.dtpDateFrom.Value = dept.GetDateTimeFromSysDateTime();
            this.dtpDateTo.Value = dept.GetDateTimeFromSysDateTime();
        }
        #endregion
    }
}
