using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.WinForms.DrugStore
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 药房摆药主窗口]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public partial class frmInpatientDrug : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public frmInpatientDrug()
        {
            InitializeComponent();

            this.ProgressRun(true);

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {                
                this.InitControlParm();

                this.tvDrugMessage1.Init();
            }
        }

        #region 域变量

        /// <summary>
        /// 摆药操作接口
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.Pharmacy.IInpatientDrug IDrugManager;
	
        /// <summary>
		/// 本次操作的摆药台
		/// </summary>
		protected Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl = new Neusoft.HISFC.Models.Pharmacy.DrugControl();
		
        /// <summary>
		/// 当前摆药通知
		/// </summary>
		protected Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
		
        /// <summary>
		/// 药房管理类
		/// </summary>
		protected Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        
        /// <summary>
		/// 当前科室的全部摆药台
		/// </summary>
		private ArrayList drugControlGather = null;

        /// <summary>
        /// 自动打印是否采用多线程Timer方式
        /// </summary>
        private bool isAutoByThreadTimer = true;

        /// <summary>
        /// 核准操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject ApproveOperDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否药柜管理
        /// </summary>
        private bool isArkDept = false;

        /// <summary>
        /// 打印接口实现类
        /// </summary>
        private object printInterfaceInstance = null;

        #endregion

        #region 属性

		/// <summary>
		/// 当前科室的全部摆药台
		/// </summary>
		public ArrayList DrugControlGather
		{
			set
			{
				this.drugControlGather = value;
				this.InitMenu();
			}
		}

        /// <summary>
        /// 是否显示明细
        /// </summary>
        public bool IsShowDetail
        {
            get
            {
                return this.ucDrugDetail1.Visible;
            }
            set
            {
                this.SuspendLayout();

                this.ucDrugDetail1.Visible = value;
                this.ucDrugMessage1.Visible = !value;

                this.ResumeLayout();

                //根据显示的控件，设置接口的实现
                if (value)
                    this.IDrugManager = this.ucDrugDetail1 as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IInpatientDrug;
                else
                    this.IDrugManager = this.ucDrugMessage1 as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IInpatientDrug;
            }
        }

        /// <summary>
        /// 是否打印标签
        /// </summary>
        private bool IsOuterPrintLabel
        {
            set
            {
                this.ucDrugDetail1.IsPrintLabel = value;
                this.ucDrugMessage1.IsPrintLabel = value;
                this.tvDrugMessage1.IsPrintLabel = value;
            }
        }

        /// <summary>
        /// 是否自动打印
        /// </summary>
        private bool IsAutoPrint
        {
            set
            {
                this.tvDrugMessage1.IsAutoPrint = value;
                this.ucDrugMessage1.IsAutoPrint = value;
                this.ucDrugDetail1.IsAutoPrint = value;
            }
        }

        #endregion

        /// <summary>
        /// 获取控制参数
        /// </summary>
        private void InitControlParm()
        {
            Neusoft.FrameWork.Management.ControlParam ctrlManager = new ControlParam();
            string ctrlAutoByMessage = ctrlManager.QueryControlerInfo("51007"); //是否列表自动刷新时采用消息驱动方式
            if (ctrlAutoByMessage == "1")
            {
                this.isAutoByThreadTimer = false;
            }
            else
            {
                this.isAutoByThreadTimer = true;
            }

            this.ApproveOperDept = ((Neusoft.HISFC.Models.Base.Employee)ctrlManager.Operator).Dept.Clone();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载摆药单控件..."));
            Application.DoEvents();

            #region 反射读取标签格式

            if (this.printInterfaceInstance == null)
            {
                this.printInterfaceInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;

            }

            if (this.printInterfaceInstance != null)
            {
                this.ucDrugDetail1.AddDrugBill(this.printInterfaceInstance, false);
            }
            else
            {
                MessageBox.Show("未设置住院摆药单据实现,无法进行摆药单打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            Neusoft.HISFC.Components.DrugStore.Function.IsApproveInitPrintInterface = false;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #region 摆药台设置方法

        #region {50CAFFB7-1E18-4b0d-95D6-CEC019D4C35D} 权限控制摆药台 add by guanyx
        /// <summary>
        /// 根据登陆人的权限，过滤摆药台
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        private ArrayList FliterControl(ArrayList al)
        {

            //人员权限分配明细管理
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

            string operCode = privManager.Operator.ID;
            string deptCode = ((Neusoft.HISFC.Models.Base.Employee)privManager.Operator).Dept.ID;

            //定义药房管理类
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

            //取操作员的药房权限
            ArrayList alPriv = privManager.LoadByUserCode(operCode, "03", deptCode);
            string priv = "";
            for (int i = 0; i < alPriv.Count; i++)
            {
                Neusoft.HISFC.Models.Admin.UserPowerDetail no = alPriv[i] as Neusoft.HISFC.Models.Admin.UserPowerDetail;
                if (no.PowerLevelClass.Class3Code == "Z1")
                {
                    priv += "B";
                }
                if (no.PowerLevelClass.Class3Code == "Z2")
                {
                    priv += "T";
                }
            }
            if (al == null)
            {
                MessageBox.Show(drugStoreManager.Err);
                return al;
            }
            if (al.Count == 0)
            {
                MessageBox.Show(Language.Msg("您所在的科室没有设置摆药台，请先设置本科室的摆药台。"));
                return al;
            }
            Neusoft.HISFC.Models.Pharmacy.DrugControl control;
            Neusoft.HISFC.Models.Pharmacy.DrugControl QuitDrugControl = new Neusoft.HISFC.Models.Pharmacy.DrugControl();
            for (int i = 0; i < al.Count; i++)
            {
                control = al[i] as Neusoft.HISFC.Models.Pharmacy.DrugControl;
                if (control.Name == "退药台")
                {
                    QuitDrugControl = control;
                }
            }
            if (priv.Length == 1)
            {
                if (priv == "B")
                {
                    al.Remove(QuitDrugControl);
                }
                else
                {
                    al.Clear();
                    al.Add(QuitDrugControl);
                }
                return al;
            }
            else if (priv.Length == 0)
            {
                al.Clear();
                return al;
            }
            return al;
        }

        #endregion

        /// <summary>
        /// 获取已知摆药台所属药房的配药台集合
        /// </summary>
        /// <param name="drugControl">已知摆药台</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int GetDrugControlGather(Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl)
        {
            //取本科室全部摆药台列表
            ArrayList al = this.drugStoreManager.QueryDrugControlList(drugControl.Dept.ID);

            //{50CAFFB7-1E18-4b0d-95D6-CEC019D4C35D} 权限控制摆药台 add by guanyx
            al = this.FliterControl(al);

            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取全部配药台列表发生错误!") + drugStoreManager.Err);
                return -1;
            }
            this.DrugControlGather = al;

            return 1;
        }

        /// <summary>
		/// 根据摆药属性取本科室的摆药台
		/// </summary>
		/// <returns>成功返回1失败返回-1</returns>
        public virtual int SetDrugControl()
        {         
            if (this.Tag != null && this.Tag.ToString() != "")
            {
                if (this.drugControl.ID != "")
                    return 1;

                this.drugControl.Dept = this.ApproveOperDept;

                Neusoft.FrameWork.Models.NeuObject tempDept = drugControl.Dept.Clone();

                this.SetArkDept(ref tempDept);

                drugControl.Dept = tempDept;

                #region 根据窗口参数 设置配药台

                this.drugControl.DrugAttribute.ID = this.Tag.ToString();
               
                //判断是否存在有效的摆药台。
                this.drugControl = this.drugStoreManager.GetDrugControl(this.drugControl.Dept.ID, (Neusoft.HISFC.Models.Pharmacy.DrugAttribute.enuDrugAttribute)this.drugControl.DrugAttribute.ID);
                if (this.drugControl == null)
                {
                    MessageBox.Show(Language.Msg("取摆药台时出错！") + this.drugStoreManager.Err);
                    return -1;
                }
                if (this.drugControl.ID == "")
                {
                    MessageBox.Show(Language.Msg("请设置本科室中【" + this.drugControl.DrugAttribute.Name + "】的摆药台！"));
                    return -1;
                }

                this.SetDrugControl(this.drugControl);

                #endregion

                if (this.GetDrugControlGather(this.drugControl) == -1)
                    return -1;
            }         

            return 1;
        }

		/// <summary>
		/// 根据传入的摆药台设置本科室的摆药台
		/// </summary>
		/// <param name="drugControl">摆药台</param>
		/// <returns></returns>
        public virtual int SetDrugControl(Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl)
        {
            Neusoft.FrameWork.Models.NeuObject tempDept = drugControl.Dept;

            this.SetArkDept(ref tempDept);

            drugControl.Dept = tempDept;

            if (this.drugControl.Dept.ID != drugControl.Dept.ID)
            {
                this.GetDrugControlGather(drugControl);
            }

            this.drugControl = drugControl;
            try
            {
                this.SetPropertyByDrugControl();
                if (this.IDrugManager != null)
                    this.IDrugManager.Clear();

                this.ShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("根据传入摆药台设置本科室的摆药台失败!") + ex.Message);
            }
            return 1;
        }

		/// <summary>
		/// 设置配药台属性显示
		/// </summary>
        protected void SetPropertyByDrugControl()
        {
            //可根据需要进行设置
            this.ucDrugDetail1.IsShowBillPreview = false;           //是否显示摆药单预览Tab

            //{22E638FE-2821-4bdf-A8A9-5BD25D51742E}  通过控制参数进行设置
            //this.ucDrugDetail1.IsShowPatientTot = false;            //是否显示患者药品汇总
            //this.ucDrugDetail1.IsShowDeptTot = true;                //是否现时候科室药品汇总

            #region 根据不同摆药台设置控件属性

            if (this.drugControl.DrugAttribute.ID.ToString() == "S" || this.drugControl.DrugAttribute.ID.ToString() == "T")		//只有特殊配药台显示
                this.ucDrugDetail1.IsAutoCheck = true;
            else
                this.ucDrugDetail1.IsAutoCheck = false;

            if (this.drugControl.DrugAttribute.ID.ToString() == "R")		//退药台
                this.ucDrugDetail1.IsFilterBillCode = true;
            else
                this.ucDrugDetail1.IsFilterBillCode = false;

            //{ECF8E92A-9116-4a4e-9487-2BFC73F8DBE1}
            //以下三个参数设置信息取消  --- 具体可通过接口实现进行灵活配置 没必要通过此处进行设置
            this.IsOuterPrintLabel = false;
            this.ucDrugDetail1.IsNeedPreview = false;
            this.ucDrugMessage1.IsNeedPreview = false;
            this.IsAutoPrint = false;

            //if (this.drugControl.DrugAttribute.ID.ToString() == "O")      //出院带药
            //    this.IsOuterPrintLabel = this.drugControl.IsPrintLabel;
            //else
            //    this.IsOuterPrintLabel = this.drugControl.IsPrintLabel;

            ////是否需要摆药单预览 根据需要进行设置
            //this.ucDrugDetail1.IsNeedPreview = this.drugControl.IsBillPreview;
            //this.ucDrugMessage1.IsNeedPreview = this.drugControl.IsBillPreview;

            ////是否自动打印
            //this.IsAutoPrint = this.drugControl.IsAutoPrint;

            //{ECF8E92A-9116-4a4e-9487-2BFC73F8DBE1}

            //列表显示时是否按照科室优先方式显示 根据需要进行设置
            //{22E638FE-2821-4bdf-A8A9-5BD25D51742E}  通过控制参数进行设置
            //this.ucDrugDetail1.IsDeptFirst = true;
            //this.ucDrugMessage1.IsDeptFirst = true;
            //this.tvDrugMessage1.IsDeptFirst = true;
            
            #endregion
           
            //显示窗口名
            this.Text = "住院摆药 - " + this.drugControl.Name;
            this.tsLabel.Text = "当前摆药台:" + this.drugControl.Name;

            //设置摆药明细显示属性
            if (this.drugControl.ShowLevel == 0)
            {
                this.IsShowDetail = false;
            }
            else
            {
                this.IsShowDetail = true;
            }

            this.tvDrugMessage1.OperDrugControl = this.drugControl;

            this.SetToolBarVisible();

            this.SetDefaultValue();

            this.SetStatusBarText();

            this.RefreshInit();
        }

        #endregion

        #region 弹出下拉菜单 工具栏按钮显示 设置

        /// <summary>
        /// 初始化菜单显示
        /// </summary>
        protected void InitMenu()
        {
            #region 设置配药台列表显示

            if (this.drugControlGather == null)
                return;

            this.tsbControlList.DropDownItems.Clear();

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugControl info in this.drugControlGather)
            {
                System.Windows.Forms.ToolStripMenuItem menuItem = new ToolStripMenuItem(info.Name);

                if (this.drugControl != null && info.ID == this.drugControl.ID)
                    this.SetCheckMenuItem(menuItem, true);
                else
                    this.SetCheckMenuItem(menuItem, false);

                menuItem.Tag = info;
                menuItem.Click += new EventHandler(menuItem_Click);

                this.tsbControlList.DropDownItems.Add(menuItem);
            }

            #endregion

            #region 刷新/打印方式设置

            System.Windows.Forms.ToolStripMenuItem autoRefreshMenuItem = new ToolStripMenuItem("自动刷新");
            autoRefreshMenuItem.Tag = "Auto";
            autoRefreshMenuItem.Click += new EventHandler(RefreshMenuItem_Click);
            this.tsbRefreshWay.DropDownItems.Add(autoRefreshMenuItem);

            System.Windows.Forms.ToolStripMenuItem handworkRefreshMenuItem = new ToolStripMenuItem("手工刷新");
            handworkRefreshMenuItem.Tag = "Handwork";
            handworkRefreshMenuItem.Click += new EventHandler(RefreshMenuItem_Click);
            this.tsbRefreshWay.DropDownItems.Add(handworkRefreshMenuItem);

            System.Windows.Forms.ToolStripMenuItem autoPrintMenuItem = new ToolStripMenuItem("自动打印");
            autoPrintMenuItem.Tag = "Auto";
            autoPrintMenuItem.Click += new EventHandler(PrintMenuItem_Click);
            this.tsbAutoPrint.DropDownItems.Add(autoPrintMenuItem);

            System.Windows.Forms.ToolStripMenuItem handworkPrintMenuItem = new ToolStripMenuItem("手工打印");
            handworkPrintMenuItem.Tag = "Handwork";
            handworkPrintMenuItem.Click += new EventHandler(PrintMenuItem_Click);
            this.tsbAutoPrint.DropDownItems.Add(handworkPrintMenuItem);            

            #endregion

            #region 打印控制

            System.Windows.Forms.ToolStripMenuItem pausePrintMenuItem = new ToolStripMenuItem("暂停打印");
            pausePrintMenuItem.Tag = "Pause";
            pausePrintMenuItem.Click += new EventHandler(PrinterSetMenuItem_Click);
            this.tsbPrinterSetList.DropDownItems.Add(pausePrintMenuItem);

            System.Windows.Forms.ToolStripMenuItem continueMenuItem = new ToolStripMenuItem("继续打印");
            continueMenuItem.Tag = "Continue";
            continueMenuItem.Click += new EventHandler(PrinterSetMenuItem_Click);
            this.tsbPrinterSetList.DropDownItems.Add(continueMenuItem);

            #endregion
        }

        /// <summary>
        /// 设置下拉菜单字体显示
        /// </summary>
        /// <param name="menuItem">需更改菜单项</param>
        /// <param name="isCheck">是否选中</param>
        private void SetCheckMenuItem(ToolStripMenuItem menuItem, bool isCheck)
        {
            if (isCheck)
                menuItem.BackColor = System.Drawing.Color.Moccasin;
            else
                menuItem.BackColor = Color.FromName(System.Drawing.KnownColor.Control.ToString());
        }

        /// <summary>
        /// 获取当前选中的菜单项
        /// </summary>
        /// <param name="splitButton">需判断的下拉按钮</param>
        /// <returns>返回当前选中的菜单项 无选中返回null</returns>
        private ToolStripMenuItem GetCheckMenuItem(ToolStripSplitButton splitButton)
        {
            foreach(ToolStripMenuItem checkMenu in splitButton.DropDownItems)
            {
                if (checkMenu.BackColor == System.Drawing.Color.Moccasin)
                    return checkMenu;
            }
            return null;
        }

        /// <summary>
        /// 设置工具栏按钮显示
        /// </summary>
        private void SetToolBarVisible()
        {
            this.tsbRefreshWay.Visible = this.drugControl.IsAutoPrint;
            this.tsbAutoPrint.Visible = this.drugControl.IsAutoPrint;
            this.tsbPrint.Visible = this.drugControl.IsAutoPrint;
            this.tsbPrinterSetList.Visible = this.drugControl.IsAutoPrint;
        }

        #endregion

        #region 药柜处理

        /// <summary>
        /// 药柜处理
        /// </summary>
        private void SetArkDept(ref Neusoft.FrameWork.Models.NeuObject operDept)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptCons = phaConsManager.QueryDeptConstant(operDept.ID);
            if (deptCons == null)
            {
                MessageBox.Show(Language.Msg("根据科室编码获取科室常数信息发生错误") + phaConsManager.Err);
                return;
            }

            operDept.Memo = Neusoft.FrameWork.Function.NConvert.ToInt32(deptCons.IsArk).ToString();
            if (this.tvDrugMessage1.StockMarkDept == null || (this.tvDrugMessage1.StockMarkDept.ID != operDept.ID))
            {
                this.tvDrugMessage1.StockMarkDept = operDept.Clone();
            }

            if (deptCons.IsArk)         //对药柜管理科室进行以下处理
            {
                #region 药柜处理

                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList al = managerIntegrate.LoadPhaParentByChildren(operDept.ID);
                if (al == null || al.Count == 0)
                {
                    MessageBox.Show(Language.Msg("获取科室结构信息发生错误") + managerIntegrate.Err);
                    return;
                }

                Neusoft.HISFC.Models.Base.DepartmentStat deptStat = al[0] as Neusoft.HISFC.Models.Base.DepartmentStat;
                if (deptStat.PardepCode.Substring(0, 1) == "S")     //上级节点为分类编码 不进行处理
                {
                    return;
                }
                else
                {
                    this.ucDrugDetail1.ArkDept = operDept.Clone();
                    this.ucDrugMessage1.ArkDept = operDept.Clone();                    

                    //核准扣库科室为药柜所属药房
                    this.ucDrugDetail1.ApproveDept = new Neusoft.FrameWork.Models.NeuObject();
                    this.ucDrugDetail1.ApproveDept.ID = deptStat.PardepCode;
                    this.ucDrugDetail1.ApproveDept.Name = deptStat.PardepName;

                    this.ucDrugMessage1.ApproveDept = new Neusoft.FrameWork.Models.NeuObject();
                    this.ucDrugMessage1.ApproveDept.ID = deptStat.PardepCode;
                    this.ucDrugMessage1.ApproveDept.Name = deptStat.PardepName;

                    operDept.ID = deptStat.PardepCode;
                    operDept.Name = deptStat.PardepName;                   
                }

                #endregion

                this.isArkDept = true;
            }                
        }

        #endregion

        /// <summary>
		/// 提取摆药通知数据，并显示摆药通知科室列表。
		/// </summary>
        public virtual void ShowList()
        {
            //清空出库申请数据显示
            this.IDrugManager.Clear();         

            this.tvDrugMessage1.ShowList(this.drugControl);

            this.tvDrugMessage1.SetExpand(0, false);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在保存" + this.drugMessage.StockDept.Name + "摆药单"));
            Application.DoEvents();
            if (this.IDrugManager.Save(this.drugMessage) > 0)
            {
                this.ShowList();             //刷新摆药通知列表
            }
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            if (this.IDrugManager != null)
                this.IDrugManager.Print();
        }

        /// <summary>
        /// 修改状态栏显示信息
        /// </summary>
        private void SetStatusBarText()
        {
            if (this.drugControl.IsAutoPrint)
            {
                ToolStripMenuItem refreshWayItem = this.GetCheckMenuItem(this.tsbRefreshWay);
                ToolStripMenuItem autoPrintItem = this.GetCheckMenuItem(this.tsbAutoPrint);
                if (refreshWayItem == null)
                    refreshWayItem = new ToolStripMenuItem("自动刷新");
                if (autoPrintItem == null)
                    autoPrintItem = new ToolStripMenuItem("自动打印");

                this.statusBar1.Panels[3].Text = string.Format("科室: {0}  摆药台:{1}  刷新方式: {2}  打印方式: {3}", this.ApproveOperDept.Name, this.drugControl.Name,refreshWayItem.Text,autoPrintItem.Text);
            }
            else
            {
                this.statusBar1.Panels[3].Text = string.Format( "科室: {0}  摆药台:{1} ", this.ApproveOperDept.Name, this.drugControl.Name );
            }
        }

        #region 自动刷新处理

        #region 处理刷新的域变量

        private System.Threading.Timer refreshTimer;
        private System.Threading.TimerCallback refreshTimerCallBack;
        private delegate void ShowListDelegate();

        /// <summary>
        /// 是否正在处理刷新
        /// </summary>
        private bool isBusy = false;
        /// <summary>
        /// 刷新间隔
        /// </summary>
        private int refreshInterval = 180;
        /// <summary>
        /// 开始刷新线程执行延迟
        /// </summary>
        private int startDelay = 10;

        #endregion

        /// <summary>
        /// 刷新初始化
        /// </summary>
        private void RefreshInit()
        {
            if (!this.drugControl.IsAutoPrint)
                this.RefreshSwitch(true);
            else
                this.RefreshSwitch(false);
        }

        /// <summary>
        /// 自动刷新切换
        /// </summary>
        /// <param name="isStop">是否停止自动刷新</param>
        private void RefreshSwitch(bool isStop)
        {
            this.IsAutoPrint = !isStop;

            if (this.isAutoByThreadTimer)
            {
                if (isStop)
                {
                    if (this.refreshTimer != null)
                        this.refreshTimer.Dispose();
                }
                else
                {
                    this.refreshTimerCallBack = new System.Threading.TimerCallback(this.AutoRefresh);
                    this.refreshTimer = new System.Threading.Timer(this.refreshTimerCallBack, null, this.startDelay * 1000, this.refreshInterval * 1000);
                }
            }
        }

        /// <summary>
        /// 刷新执行
        /// </summary>
        /// <param name="param">参数</param>
        private void AutoRefresh(object param)
        {
            if (this.isBusy)
                return;

            this.isBusy = true;

            ShowListDelegate showList = new ShowListDelegate(this.ShowList);

            try
            {
                this.Invoke(showList, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.isBusy = false;
        }

        #endregion

        /// <summary>
        /// 设置窗口默认值显示
        /// </summary>
        private void SetDefaultValue()
        {
            foreach (ToolStripMenuItem controlItem in this.tsbControlList.DropDownItems)
            {
                if ((controlItem.Tag as Neusoft.HISFC.Models.Pharmacy.DrugControl).ID == this.drugControl.ID)
                    this.SetCheckMenuItem(controlItem, true);
                else
                    this.SetCheckMenuItem(controlItem, false);
            }
            if (this.drugControl.IsAutoPrint)
            {
                foreach (ToolStripMenuItem printItem in this.tsbAutoPrint.DropDownItems)
                {
                    if (printItem.Text == "自动打印")
                        this.SetCheckMenuItem(printItem, true);
                    else
                        this.SetCheckMenuItem(printItem, false);
                }

                foreach (ToolStripMenuItem refreshItem in this.tsbRefreshWay.DropDownItems)
                {
                    if (refreshItem.Text == "自动刷新")
                        this.SetCheckMenuItem(refreshItem, true);
                    else
                        this.SetCheckMenuItem(refreshItem, false);
                }
            }            
        }

        /// <summary>
        /// 摆药核准窗口显示
        /// </summary>
        private void ShowApprove()
        {
            frmDrugBillApprove frmApprove = new frmDrugBillApprove();
            frmApprove.ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            

            this.WindowState = FormWindowState.Maximized;

            try
            {                
                this.SetDrugControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F12:
                    //F4键执行摆药单补打
                    break;
                case Keys.F5:
                    //刷新
                    this.ShowList();
                    break;
                case Keys.F8:
                    //保存
                    if (this.IDrugManager.Save(this.drugMessage) > 0)
                    {
                        //刷新摆药通知列表
                        this.ShowList();
                    }
                    break;
                case Keys.F10:
                    //F10键退出
                    this.Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            this.drugControl = menuItem.Tag as Neusoft.HISFC.Models.Pharmacy.DrugControl;

            System.Windows.Forms.ToolStripMenuItem tempMenu = this.GetCheckMenuItem(this.tsbControlList);
            if (tempMenu != null)
            {
                if ((tempMenu.Tag as Neusoft.HISFC.Models.Pharmacy.DrugControl).ID == this.drugControl.ID)
                {
                    return;
                }
            }

            //取消所有选中标记
            foreach (ToolStripMenuItem info in this.tsbControlList.DropDownItems)
            {
                this.SetCheckMenuItem(info, false);
            }
            //设置选中标记
            this.SetCheckMenuItem(menuItem, true);
            //重新设置摆药台并显示
            this.SetDrugControl(this.drugControl);
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem printMenu = sender as ToolStripMenuItem;
            ToolStripMenuItem tempMenu = this.GetCheckMenuItem(this.tsbAutoPrint);
            if (tempMenu != null && tempMenu.Tag.ToString() == printMenu.Tag.ToString())
                return;

            if (printMenu.Tag.ToString() == "Auto")
            {
                this.IsAutoPrint = true;
            }
            else
            {
                this.IsAutoPrint = false;
            }

            foreach (ToolStripMenuItem tempItem in this.tsbAutoPrint.DropDownItems)
            {
                this.SetCheckMenuItem(tempItem, false);
            }

            this.SetCheckMenuItem(printMenu, true);

            this.SetStatusBarText();

        }

        private void PrinterSetMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem printerSetMenu = sender as ToolStripMenuItem;
            if (printerSetMenu.Tag.ToString() == "Pause")
            {
                Neusoft.FrameWork.WinForms.Classes.Print.PausePrintJob(0);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Print.ResumePrintJob(0);
            }

            foreach (ToolStripMenuItem tempItem in this.tsbPrinterSetList.DropDownItems)
            {
                this.SetCheckMenuItem(tempItem, false);
            }

            this.SetCheckMenuItem(printerSetMenu, true);
        }

        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem refreshMenu = sender as ToolStripMenuItem;
            ToolStripMenuItem tempMenuItem = this.GetCheckMenuItem(this.tsbRefreshWay);
            if (tempMenuItem != null && refreshMenu.Tag.ToString() == tempMenuItem.Tag.ToString())
                return;

            if (refreshMenu.Tag.ToString() == "Auto")
                this.RefreshSwitch(false);
            else
                this.RefreshSwitch(true);

            foreach (ToolStripMenuItem tempItem in this.tsbRefreshWay.DropDownItems)
            {
                this.SetCheckMenuItem(tempItem, false);
            }

            this.SetCheckMenuItem(refreshMenu, true);

            this.SetStatusBarText();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.tsbCheckAll)      //全选
            {
                this.IDrugManager.CheckAll();
                return;
            }
            if (e.ClickedItem == this.tsbCheckNone)     //取消权限
            {
                this.IDrugManager.CheckNone();
                return;
            }
            if (e.ClickedItem == this.tsbRefresh)       //刷新
            {
                this.ShowList();
                return;
            }
            if (e.ClickedItem == this.tsbSave)          //保存
            {
                //该部分防止打开摆药核准界面后，再进行打印时无法正确打印了
                if (Neusoft.HISFC.Components.DrugStore.Function.IsApproveInitPrintInterface)
                {
                    this.InitControlParm();
                }

                this.Save();
                return;
            }
            if (e.ClickedItem == this.tsbDrugBill)      //摆药单补打 摆药核准
            {
                this.ShowApprove();
                return;
            }
            if (e.ClickedItem == this.tsbPrint)         //打印
            {
                //该部分防止打开摆药核准界面后，再进行打印时无法正确打印了
                if (Neusoft.HISFC.Components.DrugStore.Function.IsApproveInitPrintInterface)
                {
                    this.InitControlParm();
                }

                this.Print();
                return;
            }
            if (e.ClickedItem == this.tsbExit)          //退出
            {
                this.Close();
                return;
            }
        }

        private void tvDrugMessage1_SelectDataEvent(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage,ArrayList alData, bool isShowDetail)
        {
            if (this.IDrugManager != null)
            {
                this.drugMessage = drugMessage;

                this.IsShowDetail = isShowDetail;       //设置接口 控件显示

                this.IDrugManager.ShowData(alData);
            }
        }

        private void ucQueryInpatientNo1_myEvent()
        {
            if (this.ucQueryInpatientNo1.InpatientNo != null)
            {
                this.tvDrugMessage1.FindPatient(this.ucQueryInpatientNo1.InpatientNo);
            }
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                printType[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint);

                return printType;
            }
        }

        #endregion
      }
}