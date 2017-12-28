using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucDayReportDetail : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dtbegin">开始时间</param>
        /// <param name="dtend">终止时间</param>
        ///<param name="operType">操作类型</param>
        public ucDayReportDetail(DateTime dtbegin,DateTime dtend,OperType operType)
        {
            InitializeComponent();
            dtBegin = dtbegin;
            dtEnd = dtend;
            operationType = operType;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
       ///<param name="list">汇总日结时间段和操作员</param>
        ///<param name="operType">操作类型</param>
        public ucDayReportDetail(List<Class.DayReport> arrylist, OperType operType)
        {
            InitializeComponent();
            list = arrylist;
            operationType = operType;
            this.panelDayReport.Visible = false;
        }

        #region 变量
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime dtBegin = DateTime.MinValue;
        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime dtEnd = DateTime.MinValue;
        /// <summary>
        /// 窗体标题
        /// </summary>
        private string frmTitle = string.Empty;
        private List<Class.DayReport> list = null; 
        /// <summary>
        /// 明细类别
        /// </summary>
        private int amod=0;
        /// <summary>
        /// 操作类型
        /// </summary>
        private OperType operationType;
        /// <summary>
        /// 日结业务层
        /// </summary>
        Functions.DayReport feeDayReport = new Report.InpatientFee.Functions.DayReport();
        #endregion

        #region 属性
        /// <summary>
        /// 窗体标题
        /// </summary>
        public string FrmTitle
        {
            set
            {
                this.frmTitle = value;
            }
        }
        /// <summary>
        /// 查询类别
        /// </summary>
        public int aMod
        {
            set
            {
                amod = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 查找明细数据
        /// </summary>
        private void GetLenderPrePayDetail()
        {
            DataSet ds = null;
            string sumCol = string.Empty;
            if (operationType == OperType.DayReport)
            {
                //0：借方医疗预收款明细 1：贷方医疗预收款明细 2：贷方医疗应收款
                switch (amod)
                {
                    case 0:
                        {
                            ds = feeDayReport.GetLenderPrePayDetail(this.dtBegin, this.dtEnd, feeDayReport.Operator.ID, 0);
                            sumCol = "预交金额";
                            break;
                        }
                    case 1:
                        {
                            ds = feeDayReport.GetLenderPrePayDetail(this.dtBegin, this.dtEnd, feeDayReport.Operator.ID, 1);
                            sumCol = "金额";
                            break;
                        }
                    case 2:
                        {
                            ds = feeDayReport.GetLenderPayDetail(this.dtBegin, this.dtEnd, feeDayReport.Operator.ID);
                            sumCol = "费用金额";
                            break;
                        }
                }
                if (ds == null)
                {
                    MessageBox.Show(feeDayReport.Err);
                    return;
                }
            }
            else
            {
                //0：借方医疗预收款明细 1：贷方医疗预收款明细 2：贷方医疗应收款
                switch (amod)
                {
                    case 0:
                        {

                            ds = feeDayReport.GetLenderPrePayDetail(list, 0);
                            sumCol = "预交金额";
                            break;
                        }
                    case 1:
                        {
                            ds = feeDayReport.GetLenderPrePayDetail(list, 1);
                            sumCol = "金额";
                            break;
                        }
                    case 2:
                        {
                            ds = feeDayReport.GetLenderPayDetail(list);
                            sumCol = "费用金额";
                            break;
                        }
                }
                if (ds == null)
                {
                    MessageBox.Show(feeDayReport.Err);
                    return;
                }
            }
            this.neuSpread1.DataSource = ds;

            GetSummer(ds,sumCol);
        }

        private void GetSummer(DataSet ds,string sumCol)
        {
            decimal summer = 0m;
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                summer += Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[sumCol]);
            }
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
            this.neuSpread1_Sheet1.Cells[rowCount, 0].Text = "合计：";
            this.neuSpread1_Sheet1.Models.Span.Add(rowCount, 1, 1, this.neuSpread1_Sheet1.Columns.Count - 1);
            this.neuSpread1_Sheet1.Cells[rowCount, 1].Text = summer.ToString();
        }
        #endregion

        #region 事件
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void ucDayReportDetail_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请等待^^");
            Application.DoEvents();
            this.FindForm().Text = frmTitle;
            this.lblTitle.Text = frmTitle;
            this.lblBeginDate.Text = this.dtBegin.ToString();
            this.lblEndDate.Text = this.dtEnd.ToString();
            this.lblOperater.Text = feeDayReport.Operator.Name;
            GetLenderPrePayDetail();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this.panelPrint);
        }
        #endregion
    }
}
