using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Management;
using System.Collections;
using Neusoft.NFC.Function;

namespace Neusoft.UFC.Material.Apply
{
    /// <summary>
    /// [功能描述:物资入库申请组件]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-4]<br></br>
    /// </summary>
    public partial class ucApply :UFC.Material.ucIMAInOutBase
    {
        public ucApply()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucMatApply_Load);
            this.ucMaterialItemList1.ChooseDataEvent += new Material.Base.ucMaterialItemList.ChooseDataHandler(ucMaterialItemList1_ChooseDataEvent);

        }

        #region 域变量

        /// <summary>
        ///  入出库类型 1入库 0出库
        /// </summary>
        private string iotype;

        public IMatManager IManager = null;

        private System.Collections.Hashtable hsIManager = new Hashtable();

        //private Material.Base.ucMaterialItemList ucMaterialItemList1;

        Neusoft.HISFC.Management.Material.Store myStore = new Neusoft.HISFC.Management.Material.Store();

        /// <summary>
        /// 入出库类型
        /// </summary>
        public string IOType
        {
            get
            {
                return this.iotype;
            }
            set
            {
                this.iotype = value;
            }
        }


        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.NFC.Object.NeuObject privDept = new Neusoft.NFC.Object.NeuObject();

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox txtInvoiceNo;

        /// <summary>
        /// 是否需要申请科室审核
        /// </summary>
        private bool isCheck = false;

        /// <summary>
        /// 是否库房领导审核
        /// </summary>
        private bool isHeaderCheck = false;

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
        public Neusoft.NFC.Interface.Controls.NeuSpread Fp
        {
            get
            {
                return this.neuSpread1;
            }
        }


        /// <summary>
        /// 科室申请是否需要审核
        /// </summary>
        public bool IsCheck
        {
            get
            {
                return this.isCheck;
            }
            set
            {
                this.isCheck = value;
            }
        }

        /// <summary>
        /// 是否库房领导审核
        /// </summary>
        public bool IsHeaderCheck
        {
            get
            {
                return this.isHeaderCheck;
            }
            set
            {
                this.isHeaderCheck = value;
            }
        }

        #endregion

        /// <summary>
        /// 设置待选择数据
        /// </summary>
        /// <param name="dataType">数据类别 0 物品列表 1 目标单位科室库存列表 2 本科室库存列表 3 自定义列表</param>
        /// <param name="sqlIndex">Sql索引 类别为3时该参数才有意义</param>
        /// <param name="filterField">过滤字段 类别为3时该参数才有意义</param>
        /// <param name="formatStr">Sql参数 类别为3时该参数才有意义</param>
        /// <returns></returns>
        public int SetSelectData(string dataType, bool isBatch, string[] sqlIndex, string[] filterField, params string[] formatStr)
        {
            this.ucMaterialItemList1.ShowFpRowHeader = false;

            switch (dataType)
            {
                case "0":
                    this.ucMaterialItemList1.ShowMaterialList();
                    break;
                case "1":
                    if (this.TargetDept.ID == "")
                    {
                        MessageBox.Show("请选择供货单位");
                        return -1;
                    }
                    //this.ucMaterialItemList1.ShowDeptStorage(this.TargetDept.ID, isBatch);
                    this.ucMaterialItemList1.ShowApplyAllList(this.TargetDept.ID, isBatch);
                    break;
                case "2":
                    this.ucMaterialItemList1.ShowDeptStorage(this.DeptInfo.ID, isBatch);
                    break;
                case "3":
                    this.ucMaterialItemList1.ShowInfoList(sqlIndex, filterField, formatStr);
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
            this.ucMaterialItemList1.SetFormat(label, width, visible);
        }


        /// <summary>
        /// 获取显示数据的第一列到指定列宽度
        /// </summary>
        /// <param name="columnNum">需计算的列数量</param>
        /// <param name="width">返回的宽度</param>
        protected void GetColumnWidth(int iColumn, ref int iWidth)
        {
            this.ucMaterialItemList1.GetColumnWidth(iColumn, ref iWidth);
        }


        /// <summary>
        /// 设置列表数据宽度 显示指定列
        /// </summary>
        /// <param name="showColumnCount">显示指定列个数 不计算隐藏列</param>
        public void SetItemListWidth(int showColumnCount)
        {
            int iWidth = this.panelItemSelect.Width;

            this.ucMaterialItemList1.GetColumnWidth(showColumnCount, ref iWidth);

            this.panelItemSelect.Width = iWidth + 5;
        }


        /// <summary>
        /// 过滤 
        /// </summary>
        /// <param name="filterData"></param>
        protected override void Filter(string filterData)
        {
            if (this.IManager != null)
            {
                this.IManager.Filter(filterData);
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.NFC.Management.DataBaseManger dataManager = new DataBaseManger();
            Neusoft.NFC.Object.NeuObject class2Priv = new Neusoft.NFC.Object.NeuObject();

            if (this.IOType == "1")
            {
                class2Priv.ID = "0510";
                class2Priv.Name = "入库申请";
            }
            else
            {
                class2Priv.ID = "0520";
                class2Priv.Name = "出库申请";
            }

            this.Class2Priv = class2Priv;
            this.OperInfo = dataManager.Operator;
            this.OperInfo.Memo = "apply";
            Neusoft.HISFC.Management.Manager.Department managerIntegrate = new Neusoft.HISFC.Management.Manager.Department();
            Neusoft.HISFC.Object.Base.Department dept = managerIntegrate.GetDeptmentById(this.DeptInfo.ID);

            if (dept != null)
            {
                this.DeptInfo.Memo = dept.DeptType.ID.ToString();               
            }
            if (this.FilePath == "")
            {
                this.FilePath = @"\Setting\MatApplySetting.xml";
            }

            if (this.SetPrivType(true) == -1)
            {
                return;
            }

            this.GetInterface();
        }


        protected override void FilterPriv(ref List<Neusoft.NFC.Object.NeuObject> privList)
        {

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
                this.ucMaterialItemList1.SetFocusSelect();
            }
            else
            {
                this.IManager.SetFocusSelect();
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

            this.ucMaterialItemList1.Clear();

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

            MatFactory factory = new MatFactory();
            this.IManager = factory.GetApplyInstance(this.PrivType, this);

            if (this.IManager == null)
            {
                System.Windows.Forms.MessageBox.Show("根据申请类别获取对应接口实例失败");
                return;
            }

            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;

            this.neuSpread1_Sheet1.DataSource = null;
            //为了实现过滤 赋值DefaultView
            DataTable dtTemp = this.IManager.InitDataTable();
            if (dtTemp != null)
                this.neuSpread1_Sheet1.DataSource = dtTemp.DefaultView;
            else
                this.neuSpread1_Sheet1.DataSource = dtTemp;

            this.IManager.SetFormat();				//格式化

            this.IManager.SetFocusSelect();			//焦点设置

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


        #region 工具栏

        /*
        protected override int OnSave()
        {
            if (this.IManager != null)
            {
                if (this.IsCheck == false)
                {
                    this.IManager.Save();
                }
                else
                {
                    this.IManager.SaveCheck(this.isHeaderCheck);
                }

            }

            return base.OnSave();
        }

        protected override int OnCancel()
        {
            if (this.IManager != null)
            {
                this.IManager.Cancel();

            }

            return base.OnSave();
        }

        protected override int OnShowApplyList()
        {
            if (this.IManager != null)
            {
                this.IManager.ShowApplyList(this.isHeaderCheck);
            }

            this.lbInfo.Text = (this.IManager as InApplyPriv).showInfo;

            return base.OnShowApplyList();
        }

        protected override int OnShowInList()
        {
            if (this.IManager != null)
            {
                this.IManager.ShowInList();
            }

            return base.OnShowInList();
        }

        protected override int OnShowOutList()
        {
            if (this.IManager != null)
            {
                this.IManager.ShowOutList();
            }

            return base.OnShowOutList();
        }

        protected override int OnDel()
        {
            if (this.IManager != null)
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    this.IManager.Delete(this.neuSpread1_Sheet1, this.neuSpread1_Sheet1.ActiveRowIndex);
                }
            }

            return base.OnDel();
        }

        protected override int OnShow()
        {
            this.panelItemSelect.Visible = !this.panelItemSelect.Visible;
            return base.OnShow();
        }

        */

        protected override int OnSave(object sender, object neuObject)
        {
            this.neuSpread1.StopCellEditing();

            this.IManager.Save();

            this.neuSpread1.StartCellEditing(null, false);

            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.IManager.Print();
            return 1;
        }

        internal override void OnApplyList()
        {
            this.IManager.ShowApplyList();
        }

        internal override void OnInList()
        {
            this.IManager.ShowInList();
        }

        internal override void OnStockList()
        {
            this.IManager.ShowStockList();
        }

        internal override void OnOutList()
        {
            this.IManager.ShowOutList();
        }

        internal override void OnDelete()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.IManager.Delete(this.neuSpread1_Sheet1, this.neuSpread1_Sheet1.ActiveRowIndex);
            }
        }

        internal override void OnImport()
        {
            if (this.IManager != null)
            {
                this.IManager.ImportData();
            }
        }

        #endregion

        private void ucMatApply_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                Neusoft.NFC.Object.NeuObject testPrivDept = new Neusoft.NFC.Object.NeuObject();

                int parma = Neusoft.UFC.Common.Classes.Function.ChoosePivDept("0510", ref testPrivDept);

                if (parma == -1)            //无权限
                {
                    MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                    return;
                }
                else if (parma == 0)       //用户选择取消
                {
                    return;
                }

                this.DeptInfo = testPrivDept;

                base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

                //需要在此处设置 操作科室                

                Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在进行数据初始化...请稍候");
                Application.DoEvents();

                this.Init();

                this.InitFp();

                if (this.IManager != null)
                {
                    this.IManager.SetFocusSelect();
                }

                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            }

            this.ucMaterialItemList1.SetKind();
            return;
        }


        protected override void OnEndPrivChanged(Neusoft.NFC.Object.NeuObject changeData, object param)
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在根据申请类别加载界面 请稍候..");
            Application.DoEvents();

            this.GetInterface();

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();

            base.OnEndPrivChanged(changeData, param);
        }


        protected override void OnEndTargetChanged(Neusoft.NFC.Object.NeuObject changeData, object param)
        {
            if (this.IManager != null)
            {
                this.IManager.SetFocusSelect();
            }

            base.OnEndTargetChanged(changeData, param);
        }


        private void ucMaterialItemList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (sv != null && activeRow >= 0)
            {
                if (this.IManager != null)
                {
                    if (this.IManager.AddItem(sv, activeRow) == -1)
                    {
                        this.ucMaterialItemList1.SetFocusSelect();
                    }
                }
            }
        }


        private void txtInvoiceNo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (this.txtInvoiceNo.Text.Trim() == "")
            {
                return;
            }

            Neusoft.HISFC.Object.Base.Employee p = this.myStore.Operator as Neusoft.HISFC.Object.Base.Employee;

            ArrayList alAll = new ArrayList();

            ArrayList al0 = this.myStore.QueryInputDetailByInvoice(p.Dept.ID, this.txtInvoiceNo.Text.Trim(), "0");

            ArrayList al1 = this.myStore.QueryInputDetailByInvoice(p.Dept.ID, this.txtInvoiceNo.Text.Trim(), "1");

            ArrayList al2 = this.myStore.QueryInputDetailByInvoice(p.Dept.ID, this.txtInvoiceNo.Text.Trim(), "2");

            if (al0 != null && al0.Count > 0)
            {
                alAll.AddRange(al0);
            }

            if (al1 != null && al1.Count > 0)
            {
                alAll.AddRange(al1);
            }

            if (al2 != null && al2.Count > 0)
            {
                alAll.AddRange(al2);
            }

            Hashtable hsInvoice = new Hashtable();

            ArrayList alTemp = new ArrayList();

            for (int i = 0; i < alAll.Count; i++)
            {
                Neusoft.HISFC.Object.Material.Input input = alAll[i] as Neusoft.HISFC.Object.Material.Input;

                if (!hsInvoice.ContainsKey(input.StoreBase.Company.Name))
                {
                    Neusoft.NFC.Object.NeuObject obj = new Neusoft.NFC.Object.NeuObject();

                    obj.ID = this.txtInvoiceNo.Text.Trim();
                    obj.Name = input.StoreBase.Company.Name;

                    alTemp.Add(obj);
                }
            }

            string companyName = "";

            if (alTemp.Count > 1)
            {
                //弹出选择窗口
                Neusoft.NFC.Object.NeuObject info = new Neusoft.NFC.Object.NeuObject();

                if (Neusoft.NFC.Interface.Classes.Function.ChooseItem(alTemp, ref info) == 0)
                {
                    return;
                }

                companyName = info.Name;
            }

            if (alAll != null)
            {
                DataSet dsTemp = this.neuSpread1_Sheet1.DataSource as DataSet;

                if (dsTemp == null)
                {
                    DataView dvTemp = this.neuSpread1_Sheet1.DataSource as DataView;

                    for (int i = 0; i < alAll.Count; i++)
                    {
                        Neusoft.HISFC.Object.Material.Input input = alAll[i] as Neusoft.HISFC.Object.Material.Input;

                        if (alTemp.Count > 1)
                        {
                            if (input.StoreBase.Company.Name == companyName)
                            {
                                this.IManager.AddItem(null, input);
                            }
                        }
                        else
                        {
                            this.IManager.AddItem(null, input);
                        }
                    }
                }
            }
        }


        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                /*
                UFC.Material.Report.ucApplyHistory uc = new Material.Report.ucApplyHistory();
                //				if(this.Class2Priv.ID == "0510")//入库申请
                //				{
                Neusoft.NFC.Object.NeuObject obj = new Neusoft.NFC.Object.NeuObject();
                obj.ID = this.neuSpread1_Sheet1.Cells[e.Row, 9].Text;
                obj.Name = this.neuSpread1_Sheet1.Cells[e.Row, 0].Text;
                uc.Init("", this.DeptInfo, obj, true);
                //				}

                Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
                */
            }
            catch { }

        }

        internal void SetToolButton(bool p, bool p_2, bool p_3, bool p_4, bool p_5)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
