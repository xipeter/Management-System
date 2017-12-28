using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucPopDayReportQueryNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPopDayReportQueryNew(OperType operType)
        {
            InitializeComponent();
            operationType = operType;
        }

        #region 变量
        Functions.DayReport feeDayReport = new Report.InpatientFee.Functions.DayReport();
        private Class.DayReport dayReport = null;
        DateTime BeginDate, EndDate;
        private List<Class.DayReport> collectEnvironment=new List<Report.InpatientFee.Class.DayReport>();
        /// <summary>
        /// 操作类别
        /// </summary>
        private OperType operationType;
        #endregion

        #region 属性
        /// <summary>
        /// 日结实体
        /// </summary>
        public Class.DayReport DayReprot
        {
            get
            {
                return dayReport;
            }
        }
        /// <summary>
        /// 汇总数据操作员、时间段集合用与查找明细
        /// </summary>
        public List<Class.DayReport> CollectEnvironment
        {
            get
            {
                return collectEnvironment;
            }
        }
        #endregion

        #region 事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpBeginDate.Value.Date.ToString("yyyy-MM-dd")+" 00:00:00");
            this.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpEndDate.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59");
            if (this.EndDate < this.BeginDate)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("起始时间不能大于截至时间"));
                return;
            }          
                GetReportDet();          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (operationType == OperType.DayReport)
                GetQueryResult();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (operationType == OperType.DayReport)
                GetQueryResult();
            else
                GetCollectResult();

        }

        private void ucPopDayReportQueryNew_Load(object sender, EventArgs e)
        {
            if (operationType == OperType.DayReport)
            {
                SetQueryFarpoint(neuSpread1_Sheet1);
            }
            else
            {
                SetCollectFarpoint(neuSpread1_Sheet1);
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 查找当前操作员已结算列表
        /// </summary>
        protected virtual void GetReportDet()
        {
            List<Class.DayReport> list=null;
            //查找
            if(this.operationType==OperType.DayReport)
                list = this.feeDayReport.SelectDayReprotInfo(BeginDate, EndDate, this.feeDayReport.Operator.ID);
            //汇总
            else
                #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
                if (this.ckRePrint.Checked == true)
                {
                    list = this.feeDayReport.CollectCheckedDayReprotInfo(BeginDate, EndDate);
                }
                else
                {
                    list = this.feeDayReport.CollectDayReprotInfo(BeginDate, EndDate);
                } 
                #endregion
            if (list == null) return;
            this.neuSpread1_Sheet1.Rows.Count = list.Count;
            for (int i = 0; i < list.Count;i++ )
            {
                if (operationType == OperType.DayReport)
                {
                    this.neuSpread1_Sheet1.Cells[i, 0].Value = list[i].StatNO;
                    this.neuSpread1_Sheet1.Cells[i, 1].Value = list[i].BeginDate;
                    this.neuSpread1_Sheet1.Cells[i, 2].Value = list[i].EndDate;
                    this.neuSpread1_Sheet1.Cells[i, 3].Value = list[i].Oper.OperTime;
                    this.neuSpread1_Sheet1.Rows[i].Tag = list[i];
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[i, 1].Value = list[i].Oper.Name;
                    this.neuSpread1_Sheet1.Cells[i, 2].Value = list[i].BeginDate;
                    this.neuSpread1_Sheet1.Cells[i, 3].Value = list[i].EndDate;
                    this.neuSpread1_Sheet1.Cells[i, 4].Value = list[i].BalanceInvZone;
                    #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
                    this.neuSpread1_Sheet1.Cells[i, 5].Value = list[i].Memo; 
                    #endregion
                    this.neuSpread1_Sheet1.Rows[i].Tag = list[i];
                }

            }

        }

        private void GetQueryResult()
        {
            if (this.neuSpread1_Sheet1.ActiveRow.Tag == null) return;
            Class.DayReport obj = this.neuSpread1_Sheet1.ActiveRow.Tag as Class.DayReport;
            dayReport = feeDayReport.SelectDayReport(obj.StatNO,0);
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void GetCollectResult()
        {
            dayReport = new Report.InpatientFee.Class.DayReport();
            Class.DayReport obj = null;
            string statCodes = string.Empty;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "True")
                {
                    if (this.neuSpread1_Sheet1.Rows[i].Tag == null) continue;
                    obj = this.neuSpread1_Sheet1.Rows[i].Tag as Class.DayReport;
                    collectEnvironment.Add(obj);
                    statCodes += obj.StatNO + ",";   
                }
            }
            if (statCodes == string.Empty)
            {
                MessageBox.Show("请选择所要统计的数据！");
                return;
            }
            statCodes = statCodes.Substring(0,statCodes.LastIndexOf(","));
            dayReport = feeDayReport.SelectDayReport(statCodes, 1);
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }
        #endregion

        #region 设置FarpPoint
        /// <summary>
        /// 设置查询时的Farpoint
        /// </summary>
        /// <param name="sheet"></param>
        private void SetQueryFarpoint(FarPoint.Win.Spread.SheetView sheet)
        {
            sheet.Columns.Count = 4;
            FarPoint.Win.Spread.CellType.TextCellType c = new FarPoint.Win.Spread.CellType.TextCellType();
            sheet.Columns[0].Label = "序号";
            sheet.Columns[0].Width = 100;
            sheet.Columns[0].CellType = c;
            sheet.Columns[0].Locked = true;

            sheet.Columns[1].Label = "开始时间";
            sheet.Columns[1].Width = 150;
            sheet.Columns[1].CellType = c;
            sheet.Columns[1].Locked = true;

            sheet.Columns[2].Label = "结束时间";
            sheet.Columns[2].Width = 150;
            sheet.Columns[2].CellType = c;
            sheet.Columns[2].Locked = true;

            sheet.Columns[3].Label = "操作时间";
            sheet.Columns[3].Width = 150;
            sheet.Columns[3].CellType = c;
            sheet.Columns[3].Locked = true;
        }

        /// <summary>
        /// 设置汇总时的Farpoint
        /// </summary>
        /// <param name="sheet"></param>
        private void SetCollectFarpoint(FarPoint.Win.Spread.SheetView sheet)
        {
            #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
            sheet.Columns.Count = 6; 
            #endregion
            sheet.Columns[0].Label = "选择";
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            sheet.Columns[0].CellType = checkType;
            sheet.Columns[0].Width = 44;
            sheet.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            sheet.Columns[0].Locked = false;

            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            sheet.Columns[1].Label = "操作员";
            sheet.Columns[1].CellType = textType;
            sheet.Columns[1].Width = 100;
            sheet.Columns[1].Locked = true;

            sheet.Columns[2].Label = "开始时间";
            sheet.Columns[2].CellType = textType;
            sheet.Columns[2].Width = 130;
            sheet.Columns[2].Locked = true;

            sheet.Columns[3].Label = "结束时间";
            sheet.Columns[3].CellType = textType;
            sheet.Columns[3].Width = 130;
            sheet.Columns[3].Locked = true;

            sheet.Columns[4].Label = "结算票据号范围";
            sheet.Columns[4].CellType = textType;
            sheet.Columns[4].Width = 200;
            sheet.Columns[4].Locked = true;
            #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打

            sheet.Columns[5].Label = "审核时间";
            sheet.Columns[5].CellType = textType;
            sheet.Columns[5].Width = 130;
            sheet.Columns[5].Locked = true;


            if (this.ckRePrint.Checked)
            {
                this.neuSpread1_Sheet1.Columns[0].Locked = true;
            }
            else
            {

            }
            #endregion
        }
        #endregion

        #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.ckRePrint.Checked == true)
            {
                if (this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text == "False")
                {
                    this.neuSpread1.Sheets[0].Cells[0, 0, this.neuSpread1.Sheets[0].RowCount - 1, 0].Text = "False";
                    Class.DayReport dr;
                    dr = this.neuSpread1_Sheet1.Rows[e.Row].Tag as Class.DayReport;
                    for (int i = 0; i < this.neuSpread1.Sheets[0].RowCount; i++)
                    {
                        Class.DayReport drCurrent;
                        drCurrent = this.neuSpread1_Sheet1.Rows[i].Tag as Class.DayReport;
                        if (dr.Memo == drCurrent .Memo)
                        {
                            this.neuSpread1_Sheet1.Cells[i, 0].Text = "True";
                        }
                    }
                }
                else
                {
                    this.neuSpread1.Sheets[0].Cells[0, 0, this.neuSpread1.Sheets[0].RowCount - 1, 0].Text = "False";
                }
                e.Cancel = true;
            }
        }

        #endregion

        //protected override void OnLoad(EventArgs e)
        //{
        //    if (this.ckRePrint.Checked)
        //    {
        //        this.neuSpread1_Sheet1.Columns[0].Locked = true;
        //    }
        //    else
        //    {
 
        //    }
        //    base.OnLoad(e);
        //}
        
    }
}
