using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.Registration
{
    public partial class ucRegDayBalanceReport : UserControl
    {
        public ucRegDayBalanceReport()
        {
            InitializeComponent();
            this.InitUC();
        }
        #region
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitUC()
        {
            //设置医院名称 
           // Neusoft.HISFC.Integrate.
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                this.neuSpread1_Sheet1.RemoveRows(0, this.neuSpread1_Sheet1.RowCount);
            }
        }
        #endregion
        /// <summary>
        /// 将信息填充到farpoint上
        /// </summary>
        /// <param name="dayreport">挂号日结实体</param>
        /// <returns></returns>
        public int setFP(Neusoft.HISFC.Object.Registration.DayReport dayreport)
        {
            int BackCount = 0;//退费张数
            int Disvalid = 0;//作废张数
            this.lblDayDate.Text = dayreport.BeginDate.ToString() + "----" + dayreport.EndDate.ToString();
            if (dayreport.Details.Count <= 0) return -1;
            for (int i = 0; i < dayreport.Details.Count; i++) 
            {
                this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
       
                this.neuSpread1_Sheet1.Cells[i,0].Text = dayreport.Details[i].BeginRecipeNo+"--"+dayreport.Details[i].EndRecipeNo;
                this.neuSpread1_Sheet1.Cells[i,1].Text = dayreport.Details[i].Count.ToString();
                if (dayreport.Details[i].Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Back)
                {
                    this.neuSpread1_Sheet1.Cells[i, 2].Text = (-dayreport.Details[i].OwnCost).ToString();
                    this.neuSpread1_Sheet1.Cells[i, 3].Text = (-dayreport.Details[i].RegFee).ToString();
                    this.neuSpread1_Sheet1.Cells[i, 4].Text = (-dayreport.Details[i].DigFee - dayreport.Details[i].ChkFee).ToString();
                    this.neuSpread1_Sheet1.Cells[i, 5].Text = (-dayreport.Details[i].OthFee).ToString();
                    BackCount += dayreport.Details[i].Count;
                 
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[i, 2].Text = dayreport.Details[i].OwnCost.ToString();
                    this.neuSpread1_Sheet1.Cells[i, 3].Text = dayreport.Details[i].RegFee.ToString();
                    this.neuSpread1_Sheet1.Cells[i, 4].Text = (dayreport.Details[i].DigFee + dayreport.Details[i].ChkFee).ToString();
                    this.neuSpread1_Sheet1.Cells[i, 5].Text = dayreport.Details[i].OthFee.ToString();
                }
                this.neuSpread1_Sheet1.Cells[i, 6].Text = getStatus(dayreport.Details[i].Status);
                if (dayreport.Details[i].Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Cancel)
                {
                    Disvalid+=dayreport.Details[i].Count;
                }
            }
            //合计
            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount , 1);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = "合计";
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 1].Text = dayreport.SumCount.ToString();
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 2].Text = dayreport.SumOwnCost.ToString();
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 3].Text = dayreport.SumRegFee.ToString();
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 4].Text = (dayreport.SumDigFee+dayreport.SumChkFee).ToString();
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 5].Text = dayreport.SumOthFee.ToString();
            //大写金额
            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 0, 1, 7);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = "实收金额(大写): " + Neusoft.NFC.Function.NConvert.ToCapital(dayreport.SumOwnCost);
    
            
            // 操作员信息
            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount,1);
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 0, 1, 2);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = "缴款人: " + dayreport.Oper.Name ;
        
            
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 2, 1, 2);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 2].Text = "收款员: " + dayreport.Oper.ID;
         
            
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 4, 1, 3);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 4].Text = "作废张数: "+ Disvalid.ToString();
        
            
            //
            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 0, 1, 2);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = "填表人: " ;
       
            
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 2, 1, 2);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 2].Text = "出纳员: ";
        
            
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 4, 1, 3);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 4].Text = "退费张数:" + BackCount.ToString();
         
            
            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
            this.neuSpread1_Sheet1.Models.Span.Add(this.neuSpread1_Sheet1.RowCount - 1, 0, 1, 7);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = "统计时间: " + dayreport.BeginDate.ToString() + "---" + dayreport.EndDate.ToString();
                return 1;
        }
        /// <summary>
        /// 将挂号是否有效转换成汉字
        /// </summary>
        /// <param name="status">挂号状态</param>
        /// <returns></returns>
        private string getStatus(Neusoft.HISFC.Object.Base.EnumRegisterStatus status)
        {
            if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Valid)
            { return "正常"; }
            else if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Back)
            { return "退号"; }
            else if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Cancel)
            { return "作废"; }
            else
            { return "错误"; }
        }
        private void FPClear()
        {
            if(this.neuSpread1_Sheet1.RowCount > 0 )
            {
                this.neuSpread1_Sheet1.RemoveRows(0, this.neuSpread1_Sheet1.RowCount);
            }
        }

    }
}
