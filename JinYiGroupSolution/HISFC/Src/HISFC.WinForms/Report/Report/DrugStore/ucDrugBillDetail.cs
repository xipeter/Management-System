using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.DrugStore
{
    /// <summary>
    /// 明细打印摆药单
    /// 
    /// <功能说明>
    ///     1、调用Function中静态函数完成剂型的附加 该功能屏蔽
    /// </功能说明>
    /// </summary>
    public partial class ucDrugBillDetail : UserControl
    {
        /// <summary>
        /// 明细打印摆药单
        /// </summary>
        public ucDrugBillDetail()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitFp();
            }
        }

        private static System.Collections.Hashtable hsDept = new Hashtable();

        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        //是否补打
        private string ifBPrint;

        public string IfBPrint
        {
            get
            {
                return ifBPrint;
            }
            set
            {
                ifBPrint = value;
            }

        }

        /// <summary>
        /// 测试患者
        /// </summary>
        private System.Collections.Hashtable hsPatint = new Hashtable();

        /// <summary>
        /// Fp设置
        /// </summary>
        private void InitFp()
        {
            //this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
           // this.neuSpread1_Sheet1.Columns[4].Visible = false;

            this.neuSpread1_Sheet1.ColumnHeader.Rows[0].Height = 30;

            this.setColums();            
        }

        /// <summary>
        /// 设置列
        /// </summary>
        private void setColums()
        {
            try
            {
                FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.TextCellType texttype = new FarPoint.Win.Spread.CellType.TextCellType();//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
               texttype.WordWrap=true;
                texttype.Multiline=true;
                //列数量
                this.neuSpread1_Sheet1.ColumnCount = (int)ColumnsSet.ColEnd;

                //列名称,对齐方式
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColPatienName).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColTradeName).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColSpecs).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColUsage).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColFrequency).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColNum).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColUnit).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColExeTime).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.ColumnHeader.Columns.Get((int)ColumnsSet.ColPlace).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPatienName).Label = "[床号]姓名";

                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).Label = "商 品 名 称";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).CellType = texttype;//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColSpecs).Label = "规格";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColSpecs).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUsage).Label = "用法";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDoseOnce).Label = "每次量";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColBaseDose).Label = "剂量";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColFrequency).Label = "频次";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDays).Label = "付数";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColNum).Label = "用量";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUnit).Label = "单位";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColExeTime).Label = "用药时间";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColRetailPrice).Label = "单价";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColCost).Label = "金额";
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPlace).Label = "货位号";

                //列数据类型 宽度 字体
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPatienName).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPatienName).Width = 106F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColTradeName).Width = 220F;

                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColSpecs).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColSpecs).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColSpecs).Width = 100F;

                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUsage).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUsage).Width = 49F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDoseOnce).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDoseOnce).Width = 48F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColBaseDose).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColBaseDose).Width = 45F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColFrequency).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColFrequency).Width = 36F;
                numberCellType3.DecimalPlaces = 0;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDays).CellType = numberCellType3;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDays).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColDays).Width = 34F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColNum).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColNum).Width = 51F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColNum).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUnit).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUnit).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColUnit).Width = 46F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColExeTime).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColExeTime).Width = 100F;
                numberCellType4.DecimalPlaces = 4;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColRetailPrice).CellType = numberCellType4;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColRetailPrice).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColRetailPrice).Width = 59F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPlace).Width = 62F;
                this.neuSpread1_Sheet1.Columns.Get((int)ColumnsSet.ColPlace).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                //列可见性
                this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColBaseDose].Visible = false;//基本剂量
                this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColDays].Visible = false;//付数
                this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColDoseOnce].Visible = false;//每次用量
                //this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColNum].Visible = false;//总量
                this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColRetailPrice].Visible = false;//零售价
                this.neuSpread1_Sheet1.Columns[(int)ColumnsSet.ColCost].Visible = false;//金额

                //列头线条处理
                this.neuSpread1_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.White);
                this.neuSpread1_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.White);
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("单据列设置setColums()失败>>" + ex.Message);
            }
        }
        /// <summary>
        /// 清屏
        /// </summary>
        public void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="alData"></param>
        /// <param name="drugBillClass"></param>
        public void ShowData(ArrayList alData,Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            
            if (ucDrugBillDetail.hsDept.Count == 0)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptmentAll();
                foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
                {
                    ucDrugBillDetail.hsDept.Add(dept.ID, dept.Name);
                }
            }

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            this.lbPrintTime.Text = "打印时间:" + dataManager.GetDateTimeFromSysDateTime().ToString();

            //this.lbPrintTime.Text = "打印时间:" + drugBillClass.Oper.OperTime.ToString();

            #region 对同一医嘱按用药时间组合显示

            DateTime dt = dataManager.GetDateTimeFromSysDateTime();

            string orderId = "";//必须得按医嘱流水号排序 
            Neusoft.HISFC.Models.Pharmacy.ApplyOut objLast = null;
            //合并
            for (int i = alData.Count - 1; i >= 0; i--)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut obj = (alData[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut);                                
                    if (orderId == "")
                    {
                        orderId = obj.OrderNO;
                        objLast = obj;
                        objLast.User03 = this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(objLast.User03), dt);
                    }
                    else if (orderId == obj.OrderNO)//是一个药
                    {
                        objLast.User03 = objLast.User03 + " " + this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User03), dt);
                        //objLast.Operation.ApplyQty += obj.Operation.ApplyQty * obj.Days;//数量相加
                        alData.RemoveAt(i);
                    }
                    else
                    {
                        orderId = obj.OrderNO;
                        objLast = obj;
                        objLast.User03 = this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(objLast.User03), dt);
                    }
            }

            #endregion

            #region 按患者排序

            //CompareApplyOut com = new CompareApplyOut();
            //alData.Sort(com);
            #endregion

            #region 按患者床号和货位号排序{D9BE63EB-D955-48e2-A3A9-8FDB77BB3998}
            CompareBedPlaceNo comNew = new CompareBedPlaceNo();
            alData.Sort(comNew);
            #endregion

            this.SuspendLayout();          

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();

            string privPatient = "";

            int iRow = 0;

            //患者床号 姓名可以和药品同行，这个决定是否要新增一行显示药品
            bool isNeedAddRow = true;

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alData)
            {
                if (ucDrugBillDetail.hsDept.ContainsKey(info.ApplyDept.ID))
                    this.lbTitl.Text = "                       " + ucDrugBillDetail.hsDept[info.ApplyDept.ID] + drugBillClass.Name + "（明细）" + "      " + this.ifBPrint;
                else
                    this.lbTitl.Text = "                       " + info.ApplyDept.Name + drugBillClass.Name + "（明细）" + "      " + this.ifBPrint;
                info.Item.NameCollection.RegularName = itemManager.GetItem(info.Item.ID).NameCollection.RegularName;//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
                isNeedAddRow = true;
                //{D515D71A-75B4-4c02-B2F7-569779A2A5A8}
                //string bedNO = info.User02;
                string bedNO = info.User02;
                if (bedNO.Length > 4)
                {
                    bedNO = bedNO.Substring(4);
                }
                //{D515D71A-75B4-4c02-B2F7-569779A2A5A8}
                //if (privPatient != "[" + bedNO + "]" + info.User01)
                if (privPatient != "[" + bedNO + "]" + info.User01)
                {
                    //添加一行新的患者信息

                    #region 换一个患者应该加一行{827FF133-63BC-40e3-8704-6E732D5116B1}
                    if (iRow != 0)
                    {
                        iRow++;
                    }
                    #endregion

                    //{D515D71A-75B4-4c02-B2F7-569779A2A5A8}
                    //privPatient = "[" + bedNO + "]" + info.User01;
                    privPatient = "[" + bedNO + "]" + info.User01;
                    this.neuSpread1_Sheet1.Rows.Add(iRow, 1);

                    this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColPatienName].Text = privPatient;

                    //添加住院号
                    //if (drugBillClass.Name == "退药单")
                    //    this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColPatienName].Text = privPatient + (info.PatientNO.ToString()).Substring(7);
                   
                    isNeedAddRow = false;
                }

                if (isNeedAddRow)
                {
                    iRow++;
                    this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                    this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColPatienName].Text = "";
                }

                    // "[" + (info.User02).Substring(4) + "]" + info.User01;
                //this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColTradeName].Text = info.Item.Name + "－" + Function.DrugDosage.GetStaticDosage(info.Item.ID);
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColTradeName].Text = info.Item.NameCollection.RegularName + "(" + info.Item.Name + ")";
                char[] ca = this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColTradeName].Text.ToCharArray();//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}折行显示
                int j = System.Text.Encoding.Default.GetByteCount(ca, 0, ca.Length);
                if (j / 28 >= 1 && j % 28 == 0)//大于一行并且正好等于下一行
                {
                    this.neuSpread1_Sheet1.Rows[iRow].Height = (j / 28) * Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Rows.Default.Height);
                }
                else if (j / 28 >= 1 && j % 28 > 0)//大于一行，并且延伸到下一行
                {
                    this.neuSpread1_Sheet1.Rows[iRow].Height = ((j / 28) + 1) * Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Rows.Default.Height);
                }
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColSpecs].Text = info.Item.Specs;
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColUsage].Text = info.Usage.Name;
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColDoseOnce].Text = info.DoseOnce.ToString() + info.Item.DoseUnit.ToString();

                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColBaseDose].Text = info.Item.BaseDose.ToString();

                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColFrequency].Text = info.Frequency.ID;

                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColDays].Text = info.Days.ToString();
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColNum].Text = info.Operation.ApplyQty.ToString();
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColUnit].Text = info.Item.MinUnit;              
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColRetailPrice].Text = info.Item.PriceCollection.RetailPrice.ToString();
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColCost].Value = (info.Operation.ApplyQty / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColPlace].Text = info.PlaceNO;

                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(info.User03, 16))
                {
                    this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColExeTime].Text = info.User03;
                }
                else
                {
                    string useTime = info.User03;
                    while (!Neusoft.FrameWork.Public.String.ValidMaxLengh(useTime, 15))
                    {
                        this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColExeTime].Text = useTime.Substring(0,12);
                        useTime = useTime.Substring(12);
                        iRow++;
                        this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                        this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnsSet.ColExeTime].Text = useTime;
                    }
                }
            }

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();

            try
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    int index = this.neuSpread1_Sheet1.Rows.Count;
                    this.neuSpread1_Sheet1.Rows.Add(index, 1);
                    this.neuSpread1_Sheet1.Cells[index, 0].ColumnSpan = 9;
                    this.neuSpread1_Sheet1.Cells[index, 11].Formula = string.Format("SUM(M1:M{0})", index.ToString());
                    decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[index, 11].Text);
                    this.neuSpread1_Sheet1.Cells[index, 0].Text = "领药：         发药：          复核：           制表人：" + (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Name + "      合计：" + totCost.ToString("N");

                    this.neuSpread1_Sheet1.Cells[index, 11].Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ResumeLayout(true);
        }

        /// <summary>
        /// 按用药时间/当前时间 组合显示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sysdate"></param>
        /// <returns></returns>
        private string FormatDateTime(DateTime dt, DateTime sysdate)
        {
            try
            {
                if (sysdate.Date.AddDays(-1) == dt.Date)
                {
                    return "昨" + dt.Hour.ToString().PadLeft(2, '0');
                }
                else if (sysdate.Date == dt.Date)
                {
                    return dt.Hour.ToString().PadLeft(2, '0');
                }
                else if (sysdate.Date.AddDays(1) == dt.Date)
                {
                    return "明" + dt.Hour.ToString().PadLeft(2, '0');
                }
                else if (sysdate.Date.AddDays(2) == dt.Date)
                {
                    return "后" + dt.Hour.ToString().PadLeft(2, '0');
                }
                else
                {
                    return dt.Hour.ToString().PadLeft(2, '0');
                }
            }
            catch
            {
                return dt.Hour.ToString().PadLeft(2, '0');
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            //Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //print.SetPageSize(new System.Drawing.Printing.PaperSize("Letter", 780, 640));
            //print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            //print.PrintPreview(20, 10, this);

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize();
            paperSize.PaperName = "xxx" + (new Random()).Next(10000).ToString();//随便编个名字
            try
            {
                int width = 960;
                int curHeight = this.Height;
                int addHeight = (this.neuSpread1_Sheet1.RowCount - 1) * (int)this.neuSpread1_Sheet1.Rows[0].Height;

                int additionAddHeight = 3 * (int)this.neuSpread1_Sheet1.Rows[0].Height;

                paperSize.Width = width;
                paperSize.Height = (addHeight + curHeight + additionAddHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置汇总发药纸张出错>>" + ex.Message);
            }

            print.SetPageSize(paperSize);
            print.PrintPreview(15, 10, this);

        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPreview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.SetPageSize(new System.Drawing.Printing.PaperSize("Letter", 780, 640));
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPreview(20, 10, this);
        }

        public class CompareApplyOut : IComparer
        {
            public int Compare(object x, object y)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o1 = (x as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o2 = (y as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();

                string oX = o1.User01;          //患者姓名
                string oY = o2.User01;          //患者姓名

                if (o1.User02.Length > 4)
                {
                    oX = o1.User02.Substring(4);
                }
                else
                {
                    oX = o1.User02;
                }
                if (o2.User02.Length > 4)
                {
                    oY = o2.User02.Substring(4);
                }
                else
                {
                    oY = o2.User02;
                }
                oX = oX.PadLeft(5, '0') + o1.User01;
                oY = oY.PadLeft(5, '0') + o2.User01;

                int nComp;

                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
            }

        }

        public class CompareBedPlaceNo : IComparer
        {
            public int Compare(object x, object y)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o1 = (x as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o2 = (y as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();

                string oX = o1.User02 + o1.PlaceNO.PadLeft(5, '0')+o1.Item.UserCode;        //患者床号+货位号+自定义码
                string oY = o2.User02 + o2.PlaceNO.PadLeft(5,'0')+o1.Item.UserCode;      //患者床号+货位号+自定义码

                return string.Compare(oX, oY);
            }

        }

        enum ColumnsSet
        {
            ColPatienName,
            ColTradeName,
            ColSpecs,
            ColUsage,
            ColDoseOnce,
            ColBaseDose,
            ColFrequency,
            ColDays,
            ColNum,
            ColUnit,
            ColExeTime,
            ColRetailPrice,
            ColCost,
            ColPlace,
            ColEnd
        }
    }
}
