using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace InterfaceInstanceDefault.Pharmacy.IBillPrint
{
    /// <summary>
    /// [功能描述: 药品出库单默认实现]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2010-01]<br></br>
    /// </summary>
    public partial class ucOutputBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint
    {
        public ucOutputBill()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最大行数（修改时请注意实际单据长度）
        /// </summary>
        private int maxrowno;

        /// <summary>
        /// 是否补打
        /// </summary>
        public bool IsReprint = false;

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 科室管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 本单合计批发金额
        /// </summary>
        private decimal billWholeCost;

        /// <summary>
        /// 本单合计零售金额
        /// </summary>
        private decimal billRetailCost;

        /// <summary>
        /// 最大行数（修改时请注意实际单据长度）
        /// </summary>
        public int MaxRowNo
        {
            get
            {
                return this.maxrowno;
            }
            set
            {
                this.maxrowno = value;
            }
        }

        /// <summary>
        /// 设置单据列标题显示
        /// </summary>
        private void SetTitle(Neusoft.HISFC.Models.Pharmacy.Output info)
        {
            if (info.SystemType == "26")            //特殊出库
            {
                if (info.PrivType == "05")          //报损
                {
                    this.lbTitle.Text = "药 品 报 废 单";
                    this.lbPerson1.Text = "审批人：";
                    this.lbPerson2.Text = "会计：";
                    this.lbDataDisplay.Text = "报废日期：";
                    this.fpSpread1_Sheet1.Columns[10].Label = "作废原因";
                    this.lbTargetDisplay.Visible = false;
                    this.lbTargetDept.Visible = false;
                }
            }
            else if (info.SystemType == "22")       //退库
            {
                this.lbTitle.Text = "药 品 退 库 冲 帐 单";
                this.lbPerson1.Text = "发货人：";
                this.lbPerson2.Text = "领取人：";
                this.lbDataDisplay.Text = "调拨日期：";
                this.fpSpread1_Sheet1.Columns[10].Label = "生产批号";
                this.lbTargetDisplay.Visible = true;
                this.lbTargetDept.Visible = true;
            }
            else
            {
                this.lbTitle.Text = "药 品 调 拨 单";
                this.lbPerson1.Text = "发货人：";
                this.lbPerson2.Text = "领取人：";
                this.lbDataDisplay.Text = "调拨日期：";
                this.fpSpread1_Sheet1.Columns[10].Label = "生产批号";
                this.lbTargetDisplay.Visible = true;
                this.lbTargetDept.Visible = true;
            }
        }

        #region IBillPrint 成员

        public int Prieview()
        {
            return 1;
        }

        public int Print()
        {
            return 1;
        }

        public int SetData(ArrayList alPrintData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType billType)
        {
            return 1;
        }

        public int SetData(ArrayList alPrintData, string privType)
        {
            this.maxrowno = 14;

            this.billRetailCost = 0;
            this.billWholeCost = 0;

            return this.PrintGroupData( alPrintData );
        }

        private int PrintGroupData(ArrayList alPrintData)
        {
            ArrayList alPrint = new ArrayList();
            int icount = Neusoft.FrameWork.Function.NConvert.ToInt32( Math.Ceiling( Convert.ToDouble( alPrintData.Count ) / MaxRowNo ) );

            for (int i = 1; i <= icount; i++)
            {
                if (i != icount)
                {
                    alPrint = alPrintData.GetRange( MaxRowNo * (i - 1), MaxRowNo );

                    this.Print( alPrint, i, icount,false);
                }
                else
                {
                    int num = alPrintData.Count % MaxRowNo;
                    if (alPrintData.Count % MaxRowNo == 0)
                    {
                        num = MaxRowNo;
                    }
                    alPrint = alPrintData.GetRange( MaxRowNo * (i - 1), num );

                    this.Print( alPrint, i, icount,true);
                }
            }
            return 1;
        }

        public int SetData(string billNO)
        {
            return 1;
        }

        #endregion

        /// <summary>
        /// 打印函数
        /// </summary>
        /// <param name="al">打印数组</param>
        /// <param name="i">第几页</param>
        /// <param name="count">总页数</param>
        private void Print(ArrayList al, int inow, int icount,bool isLastPage)
        {
            if (al.Count <= 0)
            {
                MessageBox.Show( "没有打印的数据!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information );
                return;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Constant constant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.Output info = (Neusoft.HISFC.Models.Pharmacy.Output)al[0];

            #region Label赋值

            this.SetTitle( info );

            if (this.IsReprint)
            {
                this.lbTitle.Text = this.lbTitle.Text + "  (补打)";
            }

            string strCompany = "";
            try
            {
                strCompany = this.managerIntegrate.GetDepartment(info.TargetDept.ID ).Name;
            }
            catch
            {
            }

            this.lbTargetDept.Text = strCompany;

            Neusoft.HISFC.Models.Base.Department stockDept = this.managerIntegrate.GetDepartment( info.StockDept.ID );
            if (stockDept != null)
            {
                this.lbSourceDept.Text = stockDept.Name;
            }

            this.lbBillNO.Text = info.OutListNO;
            this.lbOper.Text = this.itemManager.Operator.Name;
            this.lbDate.Text = info.Operation.ExamOper.OperTime.ToString( "yyyy年MM月dd日" );
            this.lbPageNO.Text = "第" + inow.ToString() + "页/共" + icount.ToString() + "页";

            #endregion

            #region Farpoint赋值

            decimal totWholeCost = 0;
            decimal totRetailCost = 0;
            this.fpSpread1_Sheet1.RowCount = 0;

            for (int i = 0; i < al.Count; i++)
            {
                this.fpSpread1_Sheet1.AddRows( i, 1 );
                Neusoft.HISFC.Models.Pharmacy.Output output = al[i] as Neusoft.HISFC.Models.Pharmacy.Output;

                Neusoft.HISFC.Models.Pharmacy.Item tempItem = this.itemManager.GetItem( output.Item.ID );
                if (tempItem != null)
                {
                    this.fpSpread1_Sheet1.Cells[i, 0].Text = tempItem.NameCollection.UserCode;      //药品自定义码
                }
                this.fpSpread1_Sheet1.Cells[i, 1].Text = output.Item.Name;                                                    //药品名称
                this.fpSpread1_Sheet1.Cells[i, 2].Text = output.Item.Specs;                                                   //规格
                this.fpSpread1_Sheet1.Cells[i, 3].Text = output.Item.PackUnit;                                                //单位

                if (output.Item.PackQty == 0)
                {
                    output.Item.PackQty = 1;
                }
                decimal count = 0;
                count = Math.Round( output.Operation.ExamQty / output.Item.PackQty, 2 );
                this.fpSpread1_Sheet1.Cells[i, 4].Text = count.ToString();                                                  //实发数量   

                this.fpSpread1_Sheet1.Cells[i, 5].Text = output.Item.PriceCollection.WholeSalePrice.ToString();             //批发价
                this.fpSpread1_Sheet1.Cells[i, 6].Text = output.Item.PriceCollection.RetailPrice.ToString();                //零售价

                decimal wholeCost = Math.Round( output.Operation.ExamQty / output.Item.PackQty * output.Item.PriceCollection.WholeSalePrice, 2 );
                decimal retailCost = Math.Round( output.Operation.ExamQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice, 2 );

                this.fpSpread1_Sheet1.Cells[i, 7].Text = wholeCost.ToString();
                this.fpSpread1_Sheet1.Cells[i, 8].Text = retailCost.ToString();

                this.fpSpread1_Sheet1.Cells[i, 9].Text = (retailCost - wholeCost).ToString();
                //有效期暂时不显示 但应该要
                //this.fpSpread1_Sheet1.Cells[i, 11].Text = output.ValidTime.ToString( "yyyy-MM-dd" ) + "  ";

                if (this.fpSpread1_Sheet1.Columns[10].Label == "生产批号")
                {
                    this.fpSpread1_Sheet1.Cells[i, 10].Text = output.BatchNO;
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[i, 10].Text = output.Memo;
                }

                totWholeCost = totWholeCost + wholeCost;
                totRetailCost = totRetailCost + retailCost;
            }

            this.fpSpread1_Sheet1.RowCount = al.Count + 1;

            this.fpSpread1_Sheet1.Cells[al.Count, 1].Text = "合计";

            this.fpSpread1_Sheet1.Cells[al.Count, 7].Text = totWholeCost.ToString();
            this.fpSpread1_Sheet1.Cells[al.Count, 8].Text = totRetailCost.ToString();
            this.fpSpread1_Sheet1.Cells[al.Count, 9].Text = (totRetailCost - totWholeCost).ToString();

            billWholeCost = billWholeCost + totWholeCost;
            billRetailCost = billRetailCost + totRetailCost;
            if (isLastPage == true)         //最后一张单
            {
                int index = this.fpSpread1_Sheet1.Rows.Count;
                this.fpSpread1_Sheet1.Rows.Add( index, 1 );

                this.fpSpread1_Sheet1.Cells[index, 1].Text = "总计";

                this.fpSpread1_Sheet1.Cells[index, 7].Text = billWholeCost.ToString();
                this.fpSpread1_Sheet1.Cells[index, 8].Text = billRetailCost.ToString();
                this.fpSpread1_Sheet1.Cells[index, 9].Text = (billRetailCost - billWholeCost).ToString();
            }

            //宽度
            this.fpSpread1.Width = this.Width - 10;
            this.fpSpread1.Height = (int)this.fpSpread1_Sheet1.RowHeader.Rows[0].Height + (int)(this.fpSpread1_Sheet1.Rows[0].Height * (al.Count + 1)) + 10;
            
            #endregion

            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

            //Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize( "PhaOutput", ref p );

            p.PrintPage( 5, 10, this );
        }
    }
}
