using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 药品出库组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPhaOut :  Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                        Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucPhaOut() 
        {
            InitializeComponent();

            this.Load += new EventHandler(ucPhaOut_Load);

            this.ucDrugList1.ChooseDataEvent += new Neusoft.HISFC.Components.Common.Controls.ucDrugList.ChooseDataHandler(ucDrugList1_ChooseDataEvent);
        }

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager IManager = null;

        private System.Collections.Hashtable hsOutManager = new Hashtable();

        /// <summary>
        /// 库存科室（操作科室）是否药柜
        /// </summary>
        private bool isStockArk = false;

        /// <summary>
        /// 目标科室是否药柜
        /// </summary>
        private bool isTargetArk = false;

        /// <summary>
        /// 出库工厂接口
        /// </summary>
        private IFactory phaOutFactory = null;

        /// <summary>
        /// 出库单打印接口变量
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint iOutPrint = null;
        #endregion

        #region 属性

        /// <summary>
        /// FpSheet
        /// </summary>
        public FarPoint.Win.Spread.SheetView FpSheetView
        {
            get
            {
                return this.neuSpread1.Sheets[0];
            }
        }

        /// <summary>
        /// Fp
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread Fp
        {
            get
            {
                return this.neuSpread1;
            }
        }

        /// <summary>
        /// 库存科室（操作科室）是否药柜
        /// </summary>
        [Browsable(false)]
        public bool IsStockArk
        {
            get
            {
                return isStockArk;
            }
            set
            {
                isStockArk = value;
            }
        }

        /// <summary>
        /// 目标科室是否药柜
        /// </summary>
        [Browsable(false)]
        public bool IsTargetArk
        {
            get
            {
                return isTargetArk;
            }
            set
            {
                isTargetArk = value;
            }
        }

        /// <summary>
        /// 出库单打印接口变量
        /// </summary>
        public Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint IOutPrint
        {
            get
            {
                if (this.iOutPrint == null)
                {
                    this.InitPrintInterface();
                }

                return this.iOutPrint;
            }
        }

        #endregion

        #region 工具栏按钮

        protected override int OnSave(object sender, object neuObject)
        {
            this.neuSpread1.StopCellEditing();

            this.IManager.Save();

            this.neuSpread1.StartCellEditing(null, false);

            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.iOutPrint == null)
            {
                this.InitPrintInterface();
            }

            this.IManager.Print();
            return 1;
        }

        public override void OnApplyList()
        {
            this.IManager.ShowApplyList();
        }

        public override void OnInList()
        {
            this.IManager.ShowInList();
        }

        public override void OnStockList()
        {
            this.IManager.ShowStockList();
        }

        public override void OnOutList()
        {
            this.IManager.ShowOutList();
        }

        public override void OnDelete()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
                this.IManager.Delete(this.neuSpread1_Sheet1, this.neuSpread1_Sheet1.ActiveRowIndex);
        }

        public override void OnImport()
        {
            if (this.IManager != null)
            {
                this.IManager.ImportData();
            }
        }

        #endregion

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        internal virtual void InitPrintInterface()
        {
            this.iOutPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;

            if (this.iOutPrint == null)
            {
                //object[] o = new object[] { };

                //try
                //{
                //    //入库报表
                //    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

                //    string billValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Pha_Output_Bill, true, "Report.Pharmacy.ucPhaOutputBill");

                //    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

                //    object oLabel = objHandel.Unwrap();

                //    this.iOutPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
                //}
                //catch (System.TypeLoadException ex)
                //{
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));
                //    return;
                //}

                MessageBox.Show("未配置出库单打印的实现，将无法进行出库单据打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 设置待选择数据
        /// </summary>
        /// <param name="dataType">数据类别 0 药品列表 1 目标单位科室库存列表 2 本科室库存列表 3 自定义列表</param>
        /// <param name="isBatch">是否按批号检索 当类别为"1" 或 "2" 时才有意义</param>
        /// <param name="sqlIndex">Sql索引 类别为3时该参数才有意义</param>
        /// <param name="filterField">过滤字段 类别为3时该参数才有意义</param>
        /// <param name="formatStr">Sql参数 类别为3时该参数才有意义</param>
        /// <returns></returns>
        public int SetSelectData(string dataType, bool isBatch,string[] sqlIndex, string[] filterField, params string[] formatStr)
        {
            this.ucDrugList1.ShowFpRowHeader = false;

            switch (dataType)
            {
                case "0":
                    this.ucDrugList1.ShowPharmacyList();
                    break;
                case "1":
                    if (this.TargetDept.ID == "")
                    {
                        MessageBox.Show("请选择供货单位");
                        return -1;
                    }
                    this.ucDrugList1.ShowDeptStorageAndDict(this.TargetDept.ID, isBatch, true);
                    break;
                case "2":
                    this.ucDrugList1.ShowDeptStorageAndDict(this.DeptInfo.ID, isBatch, true);
                    break;
                case "3":
                    this.ucDrugList1.ShowInfoList(sqlIndex, filterField, formatStr);
                    break;
            }

            return 1;
        }

        /// <summary>
        /// 设置待选择数据显示
        /// </summary>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="visible"></param>
        /// <returns></returns>
        public void SetSelectFormat(string[] label, int[] width, bool[] visible)
        {
            this.ucDrugList1.SetFormat(label, width, visible);
        }

        /// <summary>
        /// 获取显示数据的第一列到指定列宽度
        /// </summary>
        /// <param name="columnNum">需计算的列数量</param>
        /// <param name="width">返回的宽度</param>
        protected void GetColumnWidth(int iColumn,ref int iWidth)
        {
            this.ucDrugList1.GetColumnWidth(iColumn, ref iWidth);
        }

        /// <summary>
        /// 设置列表数据宽度 显示指定列
        /// </summary>
        /// <param name="showColumnCount">显示指定列个数 不计算隐藏列</param>
        public void SetItemListWidth(int showColumnCount)
        {
            int iWidth = this.panelItemSelect.Width;

            this.ucDrugList1.GetColumnWidth(showColumnCount, ref iWidth);

            this.panelItemSelect.Width = iWidth + 30;
        }

        /// <summary>
        /// 过滤 
        /// </summary>
        /// <param name="filterData"></param>
        protected override void Filter(string filterData)
        {
            this.IManager.Filter(filterData);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            Neusoft.FrameWork.Models.NeuObject class2Priv = new Neusoft.FrameWork.Models.NeuObject();
            class2Priv.ID = "0320";
            class2Priv.Name = "出库";
            this.Class2Priv = class2Priv;       //出库

            //权限科室通过权限获取 
            //this.DeptInfo = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;
            this.OperInfo = dataManager.Operator;                     

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Department dept = managerIntegrate.GetDepartment(this.DeptInfo.ID);
            if (dept != null)
            {
                this.DeptInfo.Memo = dept.DeptType.ID.ToString();
            }

            this.isStockArk = this.ArkJudge(this.DeptInfo.ID);

            if (this.FilePath == "")
            {
                this.FilePath = @"\Setting\PhaOutSetting.xml";
            }

            if (this.SetPrivType(true) == -1)
                return;

            this.GetInterface();
        }

        protected override void FilterPriv(ref List<Neusoft.FrameWork.Models.NeuObject> privList)
        {
            for (int i = privList.Count - 1; i >= 0; i--)
            {
                Neusoft.FrameWork.Models.NeuObject priv = privList[i] as Neusoft.FrameWork.Models.NeuObject;

                //药房 屏蔽 住院摆、退药 门诊摆、退药
                if (this.DeptInfo.Memo == "P")
                {
                    if (priv.Memo == "M1" || priv.Memo == "M2" || priv.Memo == "Z1" || priv.Memo == "Z2")
                    {
                        privList.Remove(priv);
                    }
                }
                //药库 屏蔽 住院摆、退药 门诊摆、退药
                if (this.DeptInfo.Memo == "PI")
                {
                    if (priv.Memo == "M1" || priv.Memo == "M2" || priv.Memo == "Z1" || priv.Memo == "Z2")
                    {
                        privList.Remove(priv);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化Fp信息
        /// </summary>
        public void InitFp()
        {
            FarPoint.Win.Spread.InputMap im;

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 设置初始焦点
        /// </summary>
        public void SetFocus()
        {
            if (this.IsShowItemSelectpanel)
            {
                this.ucDrugList1.SetFocusSelect();
            }
            else
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    this.IManager.SetFocusSelect();
                }
            }
        }

        /// <summary>
        /// 激活Fp
        /// </summary>
        public void SetFpFocus()
        {
            this.neuSpread1.Select();
        }

        protected override void Clear()
        {
            base.Clear();

            this.ucDrugList1.Clear();

            this.FpSheetView.Reset();

            this.FpSheetView.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.FpSheetView.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);

            this.Fp.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.Fp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            this.InitFp();
        }

        public void ClearFp()
        {
            this.Clear();
        }

        /// <summary>
        /// 设置接口实例
        /// </summary>
        private void GetInterface()
        {
            this.Clear();

            if (this.phaOutFactory == null)
            {
                this.phaOutFactory = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject( this.GetType(), typeof( Neusoft.HISFC.Components.Pharmacy.IFactory ) ) as Neusoft.HISFC.Components.Pharmacy.IFactory;
            }

            if (this.phaOutFactory == null)
            {
                this.phaOutFactory = new PhaFactory() as IFactory;
            }

            //{9E282C1A-071F-4833-8AE3-EC64CA71FD8F} 增加对资源释放函数的调用
            if (this.IManager != null)
            {
                this.IManager.Dispose();
                this.IManager = null;
            }

            this.IManager = this.phaOutFactory.GetOutInstance(this.PrivType, this);

            if (this.IManager == null)
            {
                System.Windows.Forms.MessageBox.Show("根据出库类别获取对应接口实例失败");
                return;
            }

            this.neuSpread1_Sheet1.DataSource = null;

            DataTable dtTemp = this.IManager.InitDataTable();

            if (dtTemp != null)
            {
                this.neuSpread1_Sheet1.DataSource = dtTemp.DefaultView;
            }
            else
            {
                this.neuSpread1_Sheet1.DataSource = dtTemp;
            }

            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            this.panelItemSelect.SuspendLayout();
            this.SuspendLayout();

            this.AddItemInputUC(this.IManager.InputModualUC);

            this.neuPanel1.ResumeLayout();
            this.neuPanel3.ResumeLayout();
            this.neuPanel4.ResumeLayout();
            this.panelItemSelect.ResumeLayout();
            this.ResumeLayout();
        }

        /// <summary>
        /// 判断某科室是否为药柜
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回1 失败返回－1</returns>
        private bool ArkJudge(string deptCode)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptCons = phaConsManager.QueryDeptConstant(deptCode);
            if (deptCons == null)
            {
                MessageBox.Show(Language.Msg("根据科室编码获取科室常数信息失败") + phaConsManager.Err);
                return false;
            }

            return deptCons.IsArk;
        }

        protected override void OnEndPrivChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据出库类别加载界面 请稍候..");
            Application.DoEvents();

            this.GetInterface();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            base.OnEndPrivChanged(changeData, param);
        }

        protected override void OnEndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.IsTargetArk = this.ArkJudge(changeData.ID);

            base.OnEndTargetChanged(changeData, param);
        }


        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (sv != null && activeRow >= 0)
            {
                if (this.IManager != null)
                {
                    if (this.IManager.AddItem(sv, activeRow) == -1)
                        this.ucDrugList1.SetFocusSelect();
                }
            }
        }

        private void ucPhaOut_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0320", ref testPrivDept);

                //if (parma == -1)            //无权限
                //{
                //    MessageBox.Show(Language.Msg("您无此窗口操作权限"));                    
                //    return;
                //}
                //else if (parma == 0)       //用户选择取消
                //{
                //    return;
                //}

                //this.DeptInfo = testPrivDept;

                //base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行数据初始化...请稍候");
                Application.DoEvents();

                this.Init();

                this.InitFp();

                if (this.IManager != null)
                {
                    this.IManager.SetFocusSelect();
                }

                this.chkMinUnit.Visible = false;

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            return;
        }

        #region IExtendInterfaceContainer 成员

        public object[] InterfaceObjects
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { 
                    typeof(Neusoft.HISFC.Components.Pharmacy.IFactory) ,
                    typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)
                };
            }
        }

        #endregion

        #region IPreArrange 成员

        bool isPreArrange = false;

        public int PreArrange()
        {
            this.isPreArrange = true;

            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0320", ref testPrivDept);

            if (parma == -1)            //无权限
            {
                MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                return -1;
            }
            else if (parma == 0)       //用户选择取消
            {
                return -1;
            }

            this.DeptInfo = testPrivDept;
            
            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            return 1;
        }

        #endregion

    }
}
