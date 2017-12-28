using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 药品入库组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPhaIn : Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                        Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucPhaIn()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucPhaIn_Load);

            this.ucDrugList1.ChooseDataEvent += new Neusoft.HISFC.Components.Common.Controls.ucDrugList.ChooseDataHandler(ucDrugList1_ChooseDataEvent);
        }

        #region 域变量

        private IPhaInManager IManager = null;

        private System.Collections.Hashtable hsIManager = new Hashtable();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 库存科室（操作科室）是否药柜
        /// </summary>
        private bool isStockArk = false;       

        /// <summary>
        /// 目标科室是否药柜
        /// </summary>
        private bool isTargetArk = false;

        /// <summary>
        /// 工厂实例
        /// </summary>
        private IFactory phaInFactory = null;

        /// <summary>
        /// 入库单打印接口变量
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint iInPrint = null;
        #endregion

        #region 属性

        /// <summary>
        /// FpSheet
        /// </summary>
        [Browsable(false)]
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
        [Browsable(false)]
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
        /// 入库单打印接口变量
        /// </summary>
        public Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint IInPrint
        {
            get
            {
                if (this.iInPrint == null)
                {
                    this.InitPrintInterface();
                }

                return this.iInPrint;
            }
        }

        /// <summary>
        /// 设置上部Panel高度    {1DED4697-A590-47b3-B727-92A4AA05D2ED
        /// </summary>
        public int TopPanelHeight
        {
            set
            {
                this.panelItemManager.Height = value;
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
            if (this.iInPrint == null)
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
            {
                this.IManager.Delete(this.neuSpread1_Sheet1, this.neuSpread1_Sheet1.ActiveRowIndex);
            }
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
            this.iInPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;

            if (this.iInPrint == null)
            {
                //object[] o = new object[] { };

                //try
                //{
                //    //入库报表
                //    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

                //    string billValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Pha_Input_Bill, true, "Report.Pharmacy.ucPhaInputBill");

                //    System.Runtime.Remoting.ObjectHandle objHande = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

                //    object oLabel = objHande.Unwrap();

                //    this.iInPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
                //}
                //catch (System.TypeLoadException ex)
                //{
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));
                //    return;
                //}

                MessageBox.Show("未配置入库单打印的实现，将无法进行入库单据打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 设置待选择数据
        /// </summary>
        /// <param name="dataType">数据类别 0 药品列表 1 目标单位科室库存列表 2 本科室库存列表 3 自定义列表</param>
        /// <param name="sqlIndex">Sql索引 类别为3时该参数才有意义</param>
        /// <param name="filterField">过滤字段 类别为3时该参数才有意义</param>
        /// <param name="formatStr">Sql参数 类别为3时该参数才有意义</param>
        /// <returns></returns>
        public int SetSelectData(string dataType,bool isBatch,string[] sqlIndex,string[] filterField,params string[] formatStr)
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
                    this.ucDrugList1.ShowDeptStorage(this.TargetDept.ID, isBatch, 1);
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
        protected void GetColumnWidth(int iColumn, ref int iWidth)
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
        private void Init()
        {
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            Neusoft.FrameWork.Models.NeuObject class2Priv = new Neusoft.FrameWork.Models.NeuObject();
            class2Priv.ID = "0310";
            class2Priv.Name = "入库";
            this.Class2Priv = class2Priv;       //入库
            
            //由权限科室获取
            //this.DeptInfo = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;
            this.OperInfo = dataManager.Operator;

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Department dept = managerIntegrate.GetDepartment(this.DeptInfo.ID);
            if (dept != null)
                this.DeptInfo.Memo = dept.DeptType.ID.ToString();

            if (this.FilePath == "")
            {
                this.FilePath = @"\Setting\PhaInSetting.xml";
            }

            if (this.SetPrivType(true) == -1)
            {
                return;
            }

            this.GetInterface(); 
        }

        protected override void FilterPriv(ref List<Neusoft.FrameWork.Models.NeuObject> privList)
        {        
            for (int i = privList.Count - 1; i >= 0; i--)
            {
                Neusoft.FrameWork.Models.NeuObject priv = privList[i] as Neusoft.FrameWork.Models.NeuObject;
             
                //药房 屏蔽一般入库、特殊入库、发票入库
                if (this.DeptInfo.Memo == "P")
                {
                    //if (priv.Memo == "11" || priv.Memo == "1C" || priv.Memo == "1A")
                    //{
                    //    privList.Remove(priv);
                    //}
                    if (priv.Memo == "11" || priv.Memo == "1A")
                    {
                        privList.Remove(priv);
                    }
                }
                //药库 屏蔽内部入库申请、内部入库退库申请
                if (this.DeptInfo.Memo == "PI")
                {
                    if (priv.Memo == "13" || priv.Memo == "18")
                    {
                        privList.Remove(priv);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化Fp信息
        /// </summary>
        private void InitFp()
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

        /// <summary>
        /// 设置接口实例
        /// </summary>
        private void GetInterface()
        {        
            this.Clear();

            //通过反射方式读取Factory文件 这样 可以将 Factory与其他相关的类型文件全部挪出UFC 实现自定义            
            if (this.phaInFactory == null)
            {
                this.phaInFactory = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject( this.GetType(), typeof( Neusoft.HISFC.Components.Pharmacy.IFactory ) ) as Neusoft.HISFC.Components.Pharmacy.IFactory;
            }

            if (this.phaInFactory == null)
            {
                this.phaInFactory = new PhaFactory() as IFactory;
            }

            //{9E282C1A-071F-4833-8AE3-EC64CA71FD8F} 增加对资源释放函数的调用
            if (this.IManager != null)
            {
                this.IManager.Dispose();
            }

            this.IManager = this.phaInFactory.GetInInstance(this.PrivType, this);

            if (this.IManager == null)
            {
                System.Windows.Forms.MessageBox.Show("根据入库类别获取对应接口实例失败");
                return;
            }

            this.neuSpread1_Sheet1.DataSource = null;
            //为了实现过滤 赋值DefaultView
            DataTable dtTemp = this.IManager.InitDataTable();
            if (dtTemp != null)
                this.neuSpread1_Sheet1.DataSource = dtTemp.DefaultView;
            else
                this.neuSpread1_Sheet1.DataSource = dtTemp;

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


        private void ucPhaIn_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0310", ref testPrivDept);

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

                //需要在此处设置 操作科室                

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

        protected override void OnEndPrivChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.PrivType.Memo == Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.BorrowApply) ||
               this.PrivType.Memo == Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.BorrowBack) ||
               this.PrivType.Memo == Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.ProduceInput))
            {
                MessageBox.Show(this.PrivType.Name + " 为预留功能 目前不提供具体业务实现", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.PrivType = null;
                this.IManager = null;
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据入库类别加载界面 请稍候..");
            Application.DoEvents();

            this.GetInterface();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            base.OnEndPrivChanged(changeData, param);
        }

        protected override void OnEndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.IManager != null)
            {
                this.IManager.SetFocusSelect();
            }

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
                    typeof(Neusoft.HISFC.Components.Pharmacy.IFactory),
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
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0310", ref testPrivDept);

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
