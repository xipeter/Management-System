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
    /// 住院摆药汇总单打印
    /// 
    /// <功能说明>
    ///     1、AlterApplyData 用于进行整、散拆分 目前已经屏蔽该功能 
    ///     2、GetStaticPlaceNO 用于获取散包装货位号 GetStaticDosage 用于获取药品剂型
    ///         该功能已屏蔽
    /// </功能说明>
    /// </summary>
    public partial class ucDrugTotal : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDrugTotal()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitFp();

                this.InitData();
            }
        }

        private static Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 静态科室类
        /// </summary>
        private static System.Collections.Hashtable hsDept = new Hashtable();

        /// <summary>
        /// 散包装货位号
        /// </summary>
        private static System.Collections.Hashtable hsStaticPlaceNO = new Hashtable();

        /// <summary>
        /// 剂型
        /// </summary>
        private static System.Collections.Hashtable hsDosage = new Hashtable();

        /// <summary>
        /// 包装单位
        /// </summary>
        private static System.Collections.Hashtable hsPackUnit = new Hashtable();

        /// <summary>
        /// 剂型帮助类
        /// </summary>
        private static Neusoft.FrameWork.Public.ObjectHelper dosageHelper = new Neusoft.FrameWork.Public.ObjectHelper();

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
        /// 获取散包装货位号
        /// </summary>
        private static string GetStaticPlaceNO(string deptCode,string drugCode)
        {
            return "";

            if (hsStaticPlaceNO.ContainsKey(deptCode + drugCode))
            {
                return hsStaticPlaceNO[deptCode + drugCode].ToString();
            }
            else            
            {
                Neusoft.HISFC.Models.Pharmacy.Storage storage = itemManager.GetStockInfoByDrugCode(deptCode, drugCode);
                if (storage == null)
                {
                    return "";
                }

                hsStaticPlaceNO.Add(deptCode + drugCode, storage.Memo);
                //hsDosage.Add(drugCode, dosageHelper.GetName(storage.Item.DosageForm.ID));

                return storage.Memo;
            }            
        }

        /// <summary>
        /// 获取剂型
        /// </summary>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        private static string GetStaticDosage(string drugCode)
        {
            return "";

            if (hsDosage.ContainsKey(drugCode))
            {
                return hsDosage[drugCode].ToString();
            }
            else
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(drugCode);
                hsDosage.Add(drugCode, dosageHelper.GetName(item.DosageForm.ID));
                hsPackUnit.Add(drugCode, item.PackUnit);
                return item.DosageForm.ID;
            }
        }

        /// <summary>
        /// 获取包装单位
        /// </summary>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        private static string GetStaticPackUnit(string drugCode)
        {
            if (hsPackUnit.ContainsKey(drugCode))
            {
                return hsPackUnit[drugCode].ToString();
            }
            else
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(drugCode);
                hsPackUnit.Add(drugCode, item.PackUnit);
                hsDosage.Add(drugCode, dosageHelper.GetName(item.DosageForm.ID));
                return item.PackUnit;
            }
        }

        /// <summary>
        /// Fp设置
        /// </summary>
        private void InitFp()
        {
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

              this.neuSpread1_Sheet1.ColumnHeader.Rows[0].Height = 30;
            this.neuSpread1_Sheet1.Rows.Default.Height = 30;
            //FarPoint.Win.Spread.CellType.TextCellType texttype = new FarPoint.Win.Spread.CellType.TextCellType();//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
            //texttype.WordWrap = true;
            //texttype.Multiline = true;
            //this.neuSpread1_Sheet1.Columns.Get(1).CellType = texttype;
        }

        /// <summary>
        /// 基础数据初始化
        /// </summary>
        private void InitData()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alList = consManager.GetAllList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM);
            if (alList != null)            
            {
                dosageHelper = new Neusoft.FrameWork.Public.ObjectHelper(alList);
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
        /// 药品整散拆分
        /// </summary>
        /// <param name="alOriginalData"></param>
        /// <param name="alData"></param>
        protected void AlterApplyData(ArrayList alOriginalData, ref ArrayList alData)
        {
            alData = alOriginalData;

            return;

            ArrayList alDetail = new ArrayList();

            Neusoft.HISFC.Models.Pharmacy.ApplyOut temp = null;
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alOriginalData)
            {
                if (info.Days == 0)
                {
                    info.Days = 1;
                }
                decimal allQty = info.Operation.ApplyQty * info.Days;                
                int min = 0;
                int pack = System.Math.DivRem((int)allQty, (int)info.Item.PackQty,out min);
                if (min == 0)       //可整除包装 按整包装处理
                {
                    temp = info.Clone();
                    temp.Operation.ApplyQty = pack;
                    if (temp.Item.PackUnit == "")
                    {
                        temp.Item.PackUnit = GetStaticPackUnit(temp.Item.ID);
                    }
                    temp.Item.MinUnit = temp.Item.PackUnit;
                    temp.Item.User01 = "1";
                    alData.Add(temp.Clone());
                }
                else               //单位不可整除 
                {
                    if (pack == 0)  //如果不满足一个包装单位 直接按照最小单位处理
                    {
                        temp = info.Clone();
                        //此处需设置 零散单位的货位号
                        temp.PlaceNO = GetStaticPlaceNO(temp.StockDept.Name, temp.Item.ID);
                        alDetail.Add(temp.Clone());
                    }
                    else           //将整包装数量移出 形成整/散两条记录
                    {
                        //整包装量
                        temp = info.Clone();
                        temp.Operation.ApplyQty = pack;
                        if (temp.Item.PackUnit == "")
                        {
                            temp.Item.PackUnit = GetStaticPackUnit(temp.Item.ID);
                        }
                        temp.Item.MinUnit = info.Item.PackUnit ;
                        temp.Item.User01 = "1";
                        alData.Add(temp.Clone());
                        //散包装量
                        temp = info.Clone();
                        temp.Operation.ApplyQty = min;
                        temp.Item.MinUnit = info.Item.MinUnit;
                        //此处需设置零散单位货物号
                        temp.PlaceNO = GetStaticPlaceNO(temp.StockDept.Name, temp.Item.ID);
                        alDetail.Add(temp.Clone());

                    }
                } 
            }

            alData.AddRange(alDetail);
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="alOriginalData"></param>
        /// <param name="drugBillClass"></param>
        public void ShowData(ArrayList alOriginalData, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            ArrayList alData = new ArrayList();
            this.AlterApplyData(alOriginalData, ref alData);

            CompareApplyOut compare = new CompareApplyOut();
            alData.Sort(compare);

            #region 静态科室帮助信息获取

            if (ucDrugTotal.hsDept.Count == 0)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptmentAll();
                foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
                {
                    ucDrugTotal.hsDept.Add(dept.ID, dept.Name);
                }
            }

            #endregion

            this.SuspendLayout();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            this.lbPrintTime.Text = "打印时间:" + dataManager.GetDateTimeFromSysDateTime().ToString();

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();

            int iRow = 0;
            int iCount = 0;
            decimal totCost = 0;//总金额{65581D3C-D84E-4d4d-AF93-B58077F10DD5}
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alData)
            {
                iCount++;
                if (iCount == 6)
                {
                    this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                    iRow++;
                    iCount = 0;
                }
                #region 数据赋值

                if (ucDrugTotal.hsDept.ContainsKey(info.ApplyDept.ID))
                    this.lbTitl.Text = "                       " + ucDrugTotal.hsDept[info.ApplyDept.ID] + drugBillClass.Name + "（汇总）" + "      "   + this.ifBPrint;
                else
                    this.lbTitl.Text = "                       " + info.ApplyDept.Name + drugBillClass.Name + "（汇总）" + "     " + this.ifBPrint;

                this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                info.Item.NameCollection.RegularName = itemManager.GetItem(info.Item.ID).NameCollection.RegularName;//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
                this.neuSpread1_Sheet1.Cells[iRow, 0].Text = info.PlaceNO;
                //屏蔽剂型的显示
                this.neuSpread1_Sheet1.Cells[iRow, 1].Text = info.Item.NameCollection.Name + "(" + info.Item.Name + ")" + "[ " + info.Item.Specs + " ]";
                char[] ca = this.neuSpread1_Sheet1.Cells[iRow, 1].Text.ToCharArray();//{8CA1AEE7-F038-4c32-BD3E-ECCC8DFE687B}
                int j = System.Text.Encoding.Default.GetByteCount(ca, 0, ca.Length);
                 if (j / 40 >= 1 && j % 40 == 0)//大于一行并且正好等于下一行
                {
                    this.neuSpread1_Sheet1.Rows[iRow].Height = (j / 40) * Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Rows.Default.Height);
                }
                else if (j / 40 >= 1 && j % 40 > 0)//大于一行，并且延伸到下一行
                {
                    this.neuSpread1_Sheet1.Rows[iRow].Height = ((j / 40) + 1) * Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Rows.Default.Height);
                }
                this.neuSpread1_Sheet1.Cells[iRow, 2].Text = info.Operation.ApplyQty.ToString();
                this.neuSpread1_Sheet1.Cells[iRow, 3].Text = info.Item.MinUnit;
                this.neuSpread1_Sheet1.Cells[iRow, 4].Text = info.Item.PriceCollection.RetailPrice.ToString();
                if (info.Item.User01 == "1")            //传入的数量为包装单位
                {
                    this.neuSpread1_Sheet1.Cells[iRow, 5].Value = (info.Operation.ApplyQty * info.Item.PriceCollection.RetailPrice);
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[iRow, 5].Value = (info.Operation.ApplyQty / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                }
                totCost += Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRow, 5].Value);
                iRow++;

                #endregion
            }

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();

            #region 汇总量计算

            try
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                    this.neuSpread1_Sheet1.Cells[iRow, 0].ColumnSpan = 6;
                    this.neuSpread1_Sheet1.Cells[iRow, 0].Text = "领药：         发药：         复准：         制表人：" + (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Name + "      累计：" +totCost.ToString();                     
                    //this.neuSpread1_Sheet1.Cells[iRow, 5].Formula = string.Format("SUM(E1:E{0})", iRow.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ResumeLayout(true);

            #endregion
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            //Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            ////print.PrintPage(40, 10, this);
            //foreach (Control c in this.neuPanel1.Controls)
            //{
            //    c.Visible = true;
            //}

            ////print.SetPageSize(new System.Drawing.Printing.PaperSize("Letter", 780, 640));
            //print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

            //print.PrintPreview(50, 10, this.neuPanel1);

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

            print.PrintPreview(40, 10, this.neuPanel1);
        }

        public class CompareApplyOut : IComparer
        {
            public int Compare(object x, object y)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o1 = (x as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o2 = (y as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();

                string oX = o1.PlaceNO.PadLeft(5, '0') + o1.Item.UserCode;          //货位号+自定义码{D9BE63EB-D955-48e2-A3A9-8FDB77BB3998}
                string oY = o2.PlaceNO.PadLeft(5,'0')+o1.Item.UserCode;          //货位号+自定义码
              
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
    }
}
