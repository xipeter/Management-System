using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱执行档查询]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class fpOrderExecBrowser :System.Windows.Forms.UserControl
    {
        public fpOrderExecBrowser()
        {
            InitializeComponent();
            
        }

        
        public int ColumnIndexSelection = 0;
        public int ColumnIndexCombo = 0;
        public int ColumnIndexUsage = 0;
        public int ColumnIndexFrequency = 0;
        #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
        public int ColumnIndexOrderType = 0; 
        #endregion

        /// <summary>
        /// 医嘱管理类
        /// </summary>
        private HISFC.BizLogic.Order.Order myOrderMgr = new Neusoft.HISFC.BizLogic.Order.Order();

        #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
        /// <summary>
        /// 科室业务类
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 科室列表
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

        #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
        public Neusoft.FrameWork.Public.ObjectHelper orderTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(); 
        #endregion

        #region 属性

        /// <summary>
        /// 获得当前行号
        /// </summary>
        public int GetCurrentRowIndex
        {
            get
            {
                return this.fpSpread.Sheets[0].ActiveRowIndex;
            }
        }
        /// <summary>
        /// 当前医嘱
        /// </summary>
        public Neusoft.HISFC.Models.Order.ExecOrder CurrentExecOrder
        {
            get
            {
                try
                {
                    if (this.fpSpread.Sheets[0].ActiveRowIndex >= 0)
                    {
                        if (this.fpSpread.Sheets[0].ActiveRow.Tag != null)
                        {
                            return this.fpSpread.Sheets[0].ActiveRow.Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                        }
                    }
                }
                catch { }
                return null;
            }
        }

       
        protected bool bIsShowBed = true;
        /// <summary>
        /// 是否显示病床
        /// </summary>
        public bool IsShowBed
        {
            get
            {
                return this.bIsShowBed;
            }
            set
            {
                this.bIsShowBed = value;
            }
        }

        /// <summary>
        /// 是否显示RowHeader
        /// </summary>
        public bool IsShowRowHeader
        {
            set
            {
                this.fpSpread.Sheets[0].RowHeaderVisible = value;
            }
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化控件
        /// </summary>
        public void Init()
        {

            this.fpSpread.Sheets[0].GrayAreaBackColor = Color.White;
            this.fpSpread.Sheets[0].ColumnHeader.DefaultStyle.BackColor = Color.White;

            this.fpSpread.Sheets[0].RowHeader.DefaultStyle.BackColor = Color.Yellow;
            this.fpSpread.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            #region 设置列
            int i = 0;
            this.fpSpread.Sheets[0].Columns[i].Width = 80;
            this.fpSpread.Sheets[0].Columns[i].Label = "姓名";
            this.fpSpread.Sheets[0].Columns[i].Locked = false;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 40;
            this.fpSpread.Sheets[0].Columns[i].Label = "选择";
            this.fpSpread.Sheets[0].Columns[i].Locked = false;
            this.fpSpread.Sheets[0].Columns[i].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            ColumnIndexSelection = i;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 150;
            this.fpSpread.Sheets[0].Columns[i].Label = "项目名称";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].Visible = true;
            ColumnIndexCombo = i;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 40;
            this.fpSpread.Sheets[0].Columns[i].Label = "组合号";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread.Sheets[0].Columns[i].Visible = false;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 40;
            this.fpSpread.Sheets[0].Columns[i].Label = "组合";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 40;
            this.fpSpread.Sheets[0].Columns[i].Label = "数量";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 40;
            this.fpSpread.Sheets[0].Columns[i].Label = "单位";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 80;
            this.fpSpread.Sheets[0].Columns[i].Label = "用法";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            ColumnIndexUsage = i;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 80;
            this.fpSpread.Sheets[0].Columns[i].Label = "频次";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            ColumnIndexFrequency = i;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 150;
            this.fpSpread.Sheets[0].Columns[i].Label = "使用时间";
            //this.fpSpread1.Sheets[0].Columns[i].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 20;
            this.fpSpread.Sheets[0].Columns[i].Label = "序号";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].Visible = false;


            #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
            i++;
            //增加取药科室 
            this.fpSpread.Sheets[0].Columns[i].Width = 100;
            this.fpSpread.Sheets[0].Columns[i].Label = "取药科室";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].Visible = true;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.deptHelper.ArrayObject = this.deptManager.GetDeptmentAllValid();
            }
            #endregion

            #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            i++;
            this.fpSpread.Sheets[0].Columns[i].Width = 60;
            this.fpSpread.Sheets[0].Columns[i].Label = "医嘱类型";
            this.fpSpread.Sheets[0].Columns[i].Locked = true;
            this.fpSpread.Sheets[0].Columns[i].Visible = true;
            ColumnIndexOrderType = i;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.orderTypeHelper.ArrayObject = Neusoft.HISFC.Components.Order.Classes.OrderType.LongOrderTypes;
                this.orderTypeHelper.ArrayObject.AddRange(Neusoft.HISFC.Components.Order.Classes.OrderType.ShortOrderTypes);
            }
            #endregion

            #endregion
            this.fpSpread.Sheets[0].RowCount = 0;
            this.fpSpread.Sheets[0].ColumnCount = i + 1;
            this.fpSpread.Sheets[0].SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Restricted);



        }

        public void BeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread)).BeginInit();
            for(int i=0;i<this.fpSpread.Sheets.Count;i++)
                ((System.ComponentModel.ISupportInitialize)(this.fpSpread.Sheets[i])).BeginInit();
        }
        public void EndInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread)).EndInit();
            for (int i = 0; i < this.fpSpread.Sheets.Count; i++)
                ((System.ComponentModel.ISupportInitialize)(this.fpSpread.Sheets[i])).EndInit();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public int AddRow(object sender, int i)
        {
            if (sender.GetType() != typeof(Neusoft.HISFC.Models.Order.ExecOrder)) return -1;

            Neusoft.HISFC.Models.Order.ExecOrder order = sender as Neusoft.HISFC.Models.Order.ExecOrder;
            this.fpSpread.Sheets[0].Rows.Add(i, 1);

            //暂时根据开立时间判断（以后需要增加字段来保存首日量，然后根据开始时间判断） {AB3F34F0-37AF-4e97-9B5A-05A4AD8CE801}
            //if (order.DateUse <= new DateTime(order.Order.BeginTime.Year, order.Order.BeginTime.Month, order.Order.BeginTime.Day, 12, 0, 0))
            if(order.DateUse<=order.Order.MOTime)
            {
                this.fpSpread.Sheets[0].Rows[i].ForeColor = Color.Blue;
            }

            if (this.bIsShowBed)
            {
                this.fpSpread.Sheets[0].SetValue(i, 0, order.Order.Patient.Name + "[" + Classes.Function.BedDisplay(order.Order.Patient.PVisit.PatientLocation.Bed.ID) + "]", false);
            }
            else
            {
                this.fpSpread.Sheets[0].SetValue(i, 0, order.Order.Patient.Name, false);
            }
            if (order.Order.Combo.ID == "0" || order.Order.Combo.ID == "")
            {
            }
            else
            {
    
                this.fpSpread.Sheets[0].SetValue(i, 3, order.Order.Combo.ID + order.DateUse.ToString(), false);
             
            }

            if (order.Order.Item.Specs == null || order.Order.Item.Specs == "")//规格
            {
                this.fpSpread.Sheets[0].SetValue(i, 2, order.Order.Item.Name, false);
            }
            else
            {
                this.fpSpread.Sheets[0].SetValue(i, 2, order.Order.Item.Name + "[" + order.Order.Item.Specs + "]", false);
            }
            //药品
            //药品项目
            if (order.Order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = (Neusoft.HISFC.Models.Pharmacy.Item)order.Order.Item;
                if (order.Order.OrderType.IsDecompose)//长期医嘱
                {
                    if (item.BaseDose != 0 && order.Order.DoseOnce != 0) //草药没有一次剂量，显示付数
                    {

                        decimal d = 0;
                        if (order.Order.Qty == 0)//总量为零,可拆分的药
                        {
                            d = order.Order.DoseOnce / item.BaseDose; //长期
                        }
                        else//不可拆分
                        {
                            d = order.Order.Qty;
                        }
                        this.fpSpread.Sheets[0].SetValue(i, 5, d, false);
                        this.fpSpread.Sheets[0].SetValue(i, 6, item.MinUnit, false);
                    }
                    else//草药，中成药，一次剂量为零
                    {

                        if (order.Order.HerbalQty == 0)
                        {
                            order.Order.HerbalQty = 1;
                        }
                        this.fpSpread.Sheets[0].SetValue(i, 5, order.Order.Qty * order.Order.HerbalQty, false);//显示总量
                        if (order.Order.Qty == 0)//一次剂量为零&&总量为零的 为错误数据
                        {
                            this.fpSpread.Sheets[0].SetValue(i, 6, "基本剂量为零！", false);
                            this.fpSpread.Sheets[0].Cells[i, 6].BackColor = Color.CadetBlue;
                        }
                        else//显示总量及单位
                        {
                            this.fpSpread.Sheets[0].SetValue(i, 6, order.Order.Unit, false);
                        }
                    }

                }
                else//临时医嘱
                {
                    this.fpSpread.Sheets[0].SetValue(i, 5, order.Order.Qty, false);
                    this.fpSpread.Sheets[0].SetValue(i, 6, item.MinUnit, false);
                }
                #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
                //增加取药科室
                this.fpSpread.Sheets[0].Columns[11].Visible = true;
                this.fpSpread.Sheets[0].SetValue(i, 11, this.deptHelper.GetName(order.Order.StockDept.ID), false);//取药科室
                #endregion
            }
            else//非药品
            {
            
                this.fpSpread.Sheets[0].SetValue(i, 5, order.Order.Qty, false);
        
                this.fpSpread.Sheets[0].SetValue(i, 6, order.Order.Unit, false);
                #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
                this.fpSpread.Sheets[0].Columns[11].Visible = false;
                #endregion
            }
            this.fpSpread.Sheets[0].SetValue(i, 7, order.Order.Usage.Name, false);
            this.fpSpread.Sheets[0].SetValue(i, 8, order.Order.Frequency.ID, false);
            this.fpSpread.Sheets[0].SetValue(i, 9, order.DateUse.ToString(), false);
            this.fpSpread.Sheets[0].SetValue(i, 10, order.Order.SortID, false);
            #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            this.fpSpread.Sheets[0].SetValue(i, this.ColumnIndexOrderType, this.orderTypeHelper.GetName(order.Order.OrderType.ID), false);
            #endregion
            this.fpSpread.Sheets[0].Rows[i].Tag = order;
            return 0;
        }
        /// <summary>
        /// 默认添加到最后一行
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public int AddRow(object sender)
        {
            return this.AddRow(sender, this.fpSpread.Sheets[0].Rows.Count);
        }
      
        public void RefreshComboNo()
        {
            Classes.Function.DrawCombo(this.fpSpread.Sheets[0], 3, 4);
        }
        /// <summary>
        /// 获得当前多少行
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int GetFpRowCount(int i)
        {
            return this.fpSpread.Sheets[i].RowCount;
        }

        /// <summary>
        /// 根据传入的天数，显示天数的医嘱信息
        /// {E08AD6B3-4987-44b0-A5A9-B660D24FBC4D}
        /// </summary>
        /// <param name="days"></param>
        public void DeleteRow(int days)
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
            //string date = controlManager.GetControlParam<string>("200011", true);
            string date = this.myOrderMgr.GetDecomposeTime().ToString() + ":01";

            DateTime dt = this.myOrderMgr.GetDateTimeFromSysDateTime();
            try
            {
                dt = Neusoft.FrameWork.Function.NConvert.ToDateTime(dt.ToString("yyyy-MM-dd") +" "+ date).AddDays(days);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return;
            }
            for (int i = this.fpSpread.Sheets[0].RowCount - 1; i >= 0; i--)
            {
                DateTime dtOrder = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread_Sheet1.Cells[i, 9].Value.ToString());
                if(dtOrder > dt)
                {
                    this.fpSpread.Sheets[0].RemoveRows(i, 1);
                }
            }
        }

        /// <summary>
        /// clear row
        /// </summary>
        public void Clear()
        {
            for(int i=0;i<this.fpSpread.Sheets.Count;i++)
                this.fpSpread.Sheets[i].RowCount = 0;
        }
        #endregion
    }
}
