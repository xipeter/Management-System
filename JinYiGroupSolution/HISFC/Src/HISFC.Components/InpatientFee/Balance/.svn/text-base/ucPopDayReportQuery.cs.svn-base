using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.InpatientFee.Balance
{
    public partial class ucPopDayReportQuery : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucPopDayReportQuery()
        {
            InitializeComponent();
        }

        #region 变量

        Neusoft.HISFC.Management.Fee.InpatientDayReport FeeInaptientDayReport = new Neusoft.HISFC.Management.Fee.InpatientDayReport();
        Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();
        /// <summary>
        /// 设置一个delegate
        /// </summary>
        /// <param name="dayReport"></param>
        public delegate void mydelegateEndChoose(Neusoft.HISFC.Object.Fee.DayReport dayReport);
        public event mydelegateEndChoose OnEndChoose;

    
        #endregion

        #region 属性
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return this.dtpBeginDate.Value;
            }
            set
            {
                this.dtpBeginDate.Value = value;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.dtpEndDate.Value;
            }

            set
            {
                this.dtpEndDate.Value = value;
            }
        }        
     
        #endregion

        #region 方法
        /// <summary>
        /// 查找当前操作员已结算列表
        /// </summary>
        protected virtual void GetReportDet()
        {
            ArrayList alFeeDayReport = new ArrayList();

            alFeeDayReport = this.FeeInaptientDayReport.GetDayReportInfosForOper(this.FeeInaptientDayReport.Operator.ID, BeginDate,EndDate);

            Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();

            if (alFeeDayReport == null) return;

            for (int i = 0; i < alFeeDayReport.Count; i++)
            {
                dayReport = (Neusoft.HISFC.Object.Fee.DayReport)alFeeDayReport[i];
                this.fpQuery_Sheet1.Cells[i, 0].Value = dayReport.StatNO;
                this.fpQuery_Sheet1.Cells[i, 1].Value = dayReport.BeginDate;
                this.fpQuery_Sheet1.Cells[i, 2].Value = dayReport.EndDate;
                this.fpQuery_Sheet1.Cells[i,3].Value = dayReport.Oper.OperTime;

                this.fpQuery_Sheet1.Rows[i].Tag = dayReport;
                
            }
            
        }
        /// <summary>
        /// 组件初始化
        /// </summary>
        private void initControl()
        {            
            dtpBeginDate.Value = FeeInaptientDayReport.GetDateTimeFromSysDateTime().Date;
            dtpEndDate.Value = FeeInaptientDayReport.GetDateTimeFromSysDateTime();
        }
        
        #endregion

        #region 事件

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpQuery_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();

            if (fpQuery_Sheet1.RowCount == 0)
            {
                return;
            }

            dayReport = (Neusoft.HISFC.Object.Fee.DayReport)this.fpQuery_Sheet1.Rows[fpQuery_Sheet1.ActiveRowIndex].Tag;
            try
            {
                this.OnEndChoose(dayReport);
            }
            catch { }

            this.FindForm().Close();
                       
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPopDayReportQuery_Load(object sender, EventArgs e)
        {
            initControl();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.BeginDate = this.dtpBeginDate.Value;
            this.EndDate = this.dtpEndDate.Value;
            GetReportDet();
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.FindForm().Close();
            }
            catch { }
        }



       
    }
}
