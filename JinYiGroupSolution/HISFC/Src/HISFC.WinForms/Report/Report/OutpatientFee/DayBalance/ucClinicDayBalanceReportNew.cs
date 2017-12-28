using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.OutpatientFee.DayBalance
{
    public partial class ucClinicDayBalanceReportNew : UserControl
    {
        public ucClinicDayBalanceReportNew()
        {
            InitializeComponent();
        }

        private bool isCollectData = false;
        /// <summary>
        /// 是否汇总数据
        /// </summary>
        public bool IsCollectData
        {
            set
            {
                isCollectData = value;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitUC(string title)
        {
            // 设置医院名称
            Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
            this.lbltitle.Text = constant.GetHospitalName() + title;
        }

        #region 设置Farpoint格式
        /// <summary>
        /// 设置Farpoint发票格式
        /// </summary>
        /// <param name="sheet"></param>
        protected virtual void SetInvoiceFarpoint(FarPoint.Win.Spread.SheetView sheet)
        {
            int RowCount = sheet.Rows.Count;
            #region 发票格式
            if (!isCollectData)
            {
                //起止票据号
                sheet.Rows.Count += 1;
                RowCount++;
                sheet.Cells[RowCount - 1, 0].Text = "使用票据号：";//luoff
                sheet.Models.Span.Add(RowCount - 1, 1, 1, 5);//luoff
                sheet.Cells[RowCount - 1, 1].Tag = "A00101";
                                                                      //需修改
                //sheet.Cells[RowCount - 1, 3].Text = "终止票据号";//luoff
                //sheet.Models.Span.Add(RowCount - 1, 4, 1, 2);
                //sheet.Cells[RowCount - 1, 4].Tag = "A00102";
            }
            //票据总数
            sheet.Rows.Count += 1;
            RowCount++;
            sheet.Cells[RowCount - 1, 0].Text = "票据总数：";
            sheet.Models.Span.Add(RowCount - 1, 1, 1, 5);
            sheet.Cells[RowCount - 1, 1].Tag = "A002";

            //有效票据
            sheet.Rows.Count += 1;
            RowCount++;
            sheet.Cells[RowCount - 1, 1].Tag = "A003";
            sheet.Cells[RowCount - 1, 0].Text = "有效票据数：";

            //退费票据
            sheet.Cells[RowCount - 1, 2].Text = "退费票据数：";
            sheet.Cells[RowCount - 1, 3].Tag = "A00401";
            //退费票据号: 在做日结和查询时显示，在汇总时不显示
            if (!this.isCollectData)
            {
                //退费票据号
                sheet.Rows.Count += 1;
                sheet.Models.Span.Add(RowCount, 1, 1, 5);
                sheet.Cells[RowCount, 1].Tag = "A00402";
                sheet.Cells[RowCount, 0].Text = "退费票据号：";
                sheet.Rows[RowCount].Height = 50;
            }
            //作废票据
            if (!this.isCollectData)
            {
                sheet.Cells[RowCount - 1, 4].Text = "作废票据数：";
                sheet.Cells[RowCount - 1, 5].Tag = "A00501";

                //作废票据号
                sheet.Rows.Count += 1;
                sheet.Models.Span.Add(RowCount + 1, 1, 1, 5);
                sheet.Rows[RowCount + 1].Height = 50;
                sheet.Cells[RowCount + 1, 1].Tag = "A00502";
                sheet.Cells[RowCount + 1, 0].Text = "作废票据号：";
            }
            #endregion
        }

        /// <summary>
        /// 设置显示金额
        /// </summary>
        /// <param name="sheet">SheetView</param>
        protected virtual void SetMoneyFarpoint(FarPoint.Win.Spread.SheetView sheet)
        {
            int rowCount = sheet.Rows.Count;
            sheet.Rows.Count += 9;
            sheet.Cells[rowCount, 0].Text = "退费金额";
            sheet.Cells[rowCount, 1].Tag = "A006";
            sheet.Cells[rowCount, 2].Text = "作废金额";
            sheet.Cells[rowCount, 3].Tag = "A007";
            sheet.Cells[rowCount, 4].Text = "押金金额";
            sheet.Cells[rowCount, 5].Tag = "A008";
            sheet.Cells[rowCount + 1, 0].Text = "退押金额";
            sheet.Cells[rowCount + 1, 1].Tag = "A009";
            sheet.Cells[rowCount + 1, 2].Text = "减免金额";
            sheet.Cells[rowCount + 1, 3].Tag = "A010";
            sheet.Cells[rowCount + 1, 4].Text = "四舍五入";
            sheet.Cells[rowCount + 1, 5].Tag = "A011";

            sheet.Cells[rowCount + 2, 0].Text = "公费医疗";
            sheet.Cells[rowCount + 2, 1].Tag = "A012";
            sheet.Cells[rowCount + 2, 2].Text = "公费自付";
            sheet.Cells[rowCount + 2, 3].Tag = "A013";
            sheet.Cells[rowCount + 2, 4].Text = "公费账户";
            sheet.Cells[rowCount + 2, 5].Tag = "A026";

            sheet.Cells[rowCount + 3, 0].Text = "市保自付";
            sheet.Cells[rowCount + 3, 1].Tag = "A014";
            sheet.Cells[rowCount + 3, 2].Text = "市保账户";
            sheet.Cells[rowCount + 3, 3].Tag = "A015";
            sheet.Cells[rowCount + 3, 4].Text = "市保统筹";
            sheet.Cells[rowCount + 3, 5].Tag = "A016";
            sheet.Cells[rowCount + 4, 0].Text = "市保大额";
            sheet.Cells[rowCount + 4, 1].Tag = "A017";

            sheet.Cells[rowCount + 5, 0].Text = "省保自付";
            sheet.Cells[rowCount + 5, 1].Tag = "A018";
            sheet.Cells[rowCount + 5, 2].Text = "省保账户";
            sheet.Cells[rowCount + 5, 3].Tag = "A019";
            sheet.Cells[rowCount + 5, 4].Text = "省保统筹";
            sheet.Cells[rowCount + 5, 5].Tag = "A020";
            sheet.Cells[rowCount + 6, 0].Text = "省保大额";
            sheet.Cells[rowCount + 6, 1].Tag = "A021";
            sheet.Cells[rowCount + 6, 2].Text = "省公务员";
            sheet.Cells[rowCount + 6, 3].Tag = "A022";


            sheet.Cells[rowCount + 7, 0].Text = "上缴现金额";
            sheet.Cells[rowCount + 7, 1].Tag = "A023";
            sheet.Cells[rowCount + 7, 2].Text = "上缴支票额";
            sheet.Cells[rowCount + 7, 3].Tag = "A024";
            sheet.Cells[rowCount + 7, 4].Text = "上缴银联额";
            sheet.Cells[rowCount + 7, 5].Tag = "A025";

            sheet.Cells[rowCount + 8, 0].Text = "上缴现金额（大写）：";
            sheet.Models.Span.Add(rowCount + 8, 1, 1, 5);
            sheet.Cells[rowCount + 8, 1].Tag = "A1000";
        }

        /// <summary>
        /// 设置FarPoint格式
        /// </summary>
        /// <param name="sheet"></param>
        public virtual void SetFarPoint()
        {
            FarPoint.Win.Spread.SheetView sheet = this.neuSpread1_Sheet1;
            SetInvoiceFarpoint(sheet);
            SetMoneyFarpoint(sheet);

            sheet.Rows.Count += 1;
            int count = sheet.Rows.Count;
            sheet.Cells[count - 1, 0].Text = "制表人：";
            sheet.Models.Span.Add(count - 1, 1, 1, 2);
            sheet.Cells[count - 1, 3].Text = "收款员签名：";
            sheet.Models.Span.Add(count - 1, 4, 1, 2);
            sheet.Rows.Count += 1;
            count = sheet.Rows.Count;
            sheet.Cells[count - 1, 0].Text = "审核人：";
            sheet.Models.Span.Add(count - 1, 1, 1, 2);
            sheet.Models.Span.Add(count - 1, 4, 1, 2);
        }

        #endregion

    }
}
