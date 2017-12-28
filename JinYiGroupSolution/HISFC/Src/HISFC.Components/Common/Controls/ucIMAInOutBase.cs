using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 进销存管理基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucIMAInOutBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucIMAInOutBase()
        {
            InitializeComponent();

            this.txtFilter.Width = 120;

            this.lbTotCost.Location = new Point(188, 15);

            this.lbInfo.Location = new Point(548, 15);            
        }

        public delegate void SetToolButtonVisibleHandler(bool isShowApply, bool isShowIn, bool isShowOut, bool isShowStock, bool isShowDel, bool isShowExport, bool isShowImport);

        public delegate void AddToolButtonHandler(string text, string toolstrip, System.Drawing.Image image,int location,bool isAddSeparator, System.EventHandler e);

        public delegate void DataChangedHandler(Neusoft.FrameWork.Models.NeuObject changeData, object param);

        public delegate void FpKeyHandler(Keys key);

        public event DataChangedHandler BeginTargetChanged;

        public event DataChangedHandler EndTargetChanged;

        public event DataChangedHandler BeginPersonChanged;

        public event DataChangedHandler EndPersonChanged;

        public event DataChangedHandler BeginPrivChanged;

        public event DataChangedHandler EndPrivChanged;

        public event FpKeyHandler FpKeyEvent;

        public event AddToolButtonHandler AddToolButtonEvent;

        public event SetToolButtonVisibleHandler SetToolButtonVisibleEvent;

        /// <summary>
        /// 权限管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerDetailManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

        #region 域变量

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        private string filePath = "";

        /// <summary>
        /// 二级权限
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject class2Priv = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前选择的操作类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作目标科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject targetDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作目标领送人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject targetPerson = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 本地配置文件内的目标单位信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject localTargetDept = null;

        /// <summary>
        /// 本地配置文件内的目标人员信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject localTargetPerson = null;

        /// <summary>
        /// 是否对FarPoint显示进行清空 
        /// </summary>
        private bool isClear = true;

        /// <summary>
        /// 权限集合(三级权限 用户定义类型)
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> privList = new List<Neusoft.FrameWork.Models.NeuObject>();

        /// <summary>
        /// 目标科室
        /// </summary>
        ArrayList alTargetDept = new ArrayList();

        /// <summary>
        /// 目标领送人
        /// </summary>
        ArrayList alTargetPerson = new ArrayList();

        /// <summary>
        /// 退出时是否保存权限类型
        /// </summary>
        private bool isSaveDefaultPriv = true;

        /// <summary>
        /// 供货单位数据为空时 是否自动设置为第一个值
        /// </summary>
        private bool isSetDefaultTargetDept = true;

        /// <summary>
        /// 领药人数据为空时 是否自动设置为第一个值
        /// </summary>
        private bool isSetDefaultTargetPerson = false;

        #endregion

        #region 外部公开属性 可自由设置

        /// <summary>
        /// 提示信息
        /// </summary>
        [Description("界面显示提示信息"),Category("设置")]
        public string ShowInfo
        {
            get
            {
                return this.lbInfo.Text;
            }
            set
            {
                this.lbInfo.Text = value;
            }
        }

        /// <summary>
        /// 是否允许对操作类别、目标单位进行选择响应
        /// </summary>
        [Description("是否可以选择操作类别或目标单位"), Category("设置")]
        public bool LabelValid
        {
            get
            {
                return this.lnbTarget.Enabled;
            }
            set
            {
                this.lnbTarget.Enabled = value;         //目标单位
                this.lnbTargetPerson.Enabled = value;         //领送人
            }
        }

        /// <summary>
        /// 配置文件路径属性
        /// </summary>
        [Description("配置文件保存路径 相对地址(程序运行目录内"), Category("设置")]
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;                
            }
        }

        /// <summary>
        /// 对目标单位的显示名称
        /// </summary>
        [Description("对目标单位的显示名称"), Category("设置")]
        public string LinkLabelTarget
        {
            get
            {
                return this.lnbTarget.Text;
            }
            set
            {
                this.lnbTarget.Text = value;
            }
        }

        /// <summary>
        /// 对领送人的显示名称
        /// </summary>
        [Description("对领送人的显示名称"), Category("设置")]
        public string LinkLabelPerson
        {
            get
            {
                return this.lnbTargetPerson.Text;
            }
            set
            {
                this.lnbTargetPerson.Text = value;
            }
        }

        /// <summary>
        /// 退出时是否保存权限类型
        /// </summary>
        [Description("退出时是否保存权限类型"), Category("设置"),DefaultValue(true)]
        public bool IsSaveDefaultPriv
        {
            get
            {
                return this.isSaveDefaultPriv;
            }
            set
            {
                this.isSaveDefaultPriv = value;
            }
        }

        /// <summary>
        /// 供货单位数据为空时 是否自动设置为第一个值
        /// </summary>
        [Description("供货单位数据为空时 是否自动设置为第一个值"), Category("设置"),DefaultValue(true)]
        public bool IsSetDefaultTargetDept
        {
            get
            {
                return isSetDefaultTargetDept;
            }
            set
            {
                isSetDefaultTargetDept = value;
            }
        }

        /// <summary>
        /// 领药人数据为空时 是否自动设置为第一个值
        /// </summary>
        [Description("领药人数据为空时 是否自动设置为第一个值"), Category("设置"), DefaultValue(false)]
        public bool IsSetDefaultTargetPerson
        {
            get
            {
                return isSetDefaultTargetPerson;
            }
            set
            {
                isSetDefaultTargetPerson = value;
            }
        }

        #endregion

        #region 内部使用属性 

        /// <summary>
        /// 是否显示上部资料输入Panel
        /// </summary>
        public bool IsShowInputPanel
        {
            get
            {
                return this.panelItemManager.Visible;
            }
            set
            {
                this.panelItemManager.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示项目选择Panel
        /// </summary>
        public bool IsShowItemSelectpanel
        {
            get
            {
                return this.panelItemSelect.Visible;
            }
            set
            {
                this.panelItemSelect.Visible = value;
            }
        }

        /// <summary>
        /// 二级权限
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Class2Priv
        {
            get
            {
                return this.class2Priv;
            }
            set
            {
                this.class2Priv = value;
            }
        }

        /// <summary>
        /// 入库分类  ID 编码 Name 名称 Memo 系统类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PrivType
        {
            get
            {
                return this.privType;
            }
            set
            {
                this.privType = value;
                if (value != null)
                {
                    this.txtPrivType.Text = value.Name;
                    this.cmbPrivType.SelectedIndexChanged -= new EventHandler(cmbPrivType_SelectedIndexChanged);
                    this.cmbPrivType.Text = value.Name;
                    this.cmbPrivType.SelectedIndexChanged += new EventHandler(cmbPrivType_SelectedIndexChanged);
                }
            }
        }

        /// <summary>
        /// 目标单位 ID 编码 Name 名称 Memo 0 目标单位为内部科室 1 目标单位为外部供货公司
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject TargetDept
        {
            get
            {
                return targetDept;
            }
            set
            {
                this.targetDept = value;
                if (value != null)
                {
                    this.cmbTargetDept.Text = value.Name;
                }
            }
        }

        /// <summary>
        /// 目标人 ID 编码 Name 名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject TargetPerson
        {
            get
            {
                return this.targetPerson;
            }
            set
            {
                this.targetPerson = value;
                if (value != null)
                {
                    this.cmbTargetPerson.Text = value.Name;
                }
            }
        }

        /// <summary>
        /// 当前操作员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperInfo
        {
            get
            {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }

        /// <summary>
        /// 当前登陆科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get
            {
                return this.deptInfo;
            }
            set
            {
                this.deptInfo = value;
            }
        }

        /// <summary>
        /// 是否对FarPoint显示进行清空 
        /// </summary>
        public bool IsClear
        {
            get
            {
                return this.isClear;
            }
            set
            {
                this.isClear = value;
            }
        }

        /// <summary>
        /// 总金额显示
        /// </summary>
        public string TotCostInfo
        {
            get
            {
                return this.lbTotCost.Text;
            }
            set
            {
                this.lbTotCost.Text = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删  除", "删除明细信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("申请单", "显示申请信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("入库单", "显示入库单据", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("出库单", "显示出库单据", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarService.AddToolButton("采购单", "显示采购单据", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z作废信息, true, false, null);
            toolBarService.AddToolButton("导  入", "导入入库信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            return toolBarService;
        }

        /// <summary>
        /// 增加按钮  原ToolBarService方式 该方式无法添加按钮 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toolTrip"></param>
        /// <param name="imngeInex"></param>
        /// <param name="isEnabled"></param>
        /// <param name="isChecked"></param>
        /// <param name="e"></param>
        public void AddToolBarButton(string text,string toolTrip,int imngeInex,bool isEnabled,bool isChecked,EventHandler e)
        {
            this.toolBarService.AddToolButton(text, toolTrip, imngeInex, isEnabled, isChecked, e);          
        }

        /// <summary>
        /// 增加按钮
        /// </summary>
        /// <param name="text">按钮文字</param>
        /// <param name="toolTrip">提示信息</param>
        /// <param name="imageEnum">按钮图标</param>
        /// <param name="location">位置索引</param>
        /// <param name="isAddSeparator">是否再按钮前部增加分割线</param>
        /// <param name="eFun">按钮点击处理委托</param>
        public void AddToolBarButton(string text, string toolTrip, Neusoft.FrameWork.WinForms.Classes.EnumImageList imageEnum,int location,bool isAddSeparator,System.EventHandler eFun)
        {
            if (this.AddToolButtonEvent != null)
            {
                System.Drawing.Image image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(imageEnum);
                this.AddToolButtonEvent(text, toolTrip, image, location, isAddSeparator, eFun);
            }
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "申请单")
            {
                this.OnApplyList();
            }
            if (e.ClickedItem.Text == "入库单")
            {
                this.OnInList();
            }
            if (e.ClickedItem.Text == "出库单")
            {
                this.OnOutList();
            }
            if (e.ClickedItem.Text == "采购单")
            {
                this.OnStockList();
            }
            if (e.ClickedItem.Text == "删  除")
            {
                this.OnDelete();
            }
            if (e.ClickedItem.Text == "导  入")
            {
                this.OnImport();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 设置工具栏按钮显示情况  原ToolBarService方式 该函数无法实现相应功能
        /// </summary>
        /// <param name="isShowApplyButton"></param>
        /// <param name="isShowInButton"></param>
        /// <param name="isShowOutButton"></param>
        /// <param name="isShowStockButton"></param>
        /// <param name="isShowDelButton"></param>
        /// <param name="isShowImportButton"></param>
        public virtual void SetToolBarButton(bool isShowApplyButton, bool isShowInButton, bool isShowOutButton, bool isShowStockButton, bool isShowDelButton,bool isShowImportButton)
        {
            this.toolBarService.SetToolButtonEnabled("申请单", isShowApplyButton);
            this.toolBarService.SetToolButtonEnabled("入库单", isShowInButton);
            this.toolBarService.SetToolButtonEnabled("出库单", isShowOutButton);
            this.toolBarService.SetToolButtonEnabled("采购单", isShowStockButton);
            this.toolBarService.SetToolButtonEnabled("删  除", isShowDelButton);
            this.toolBarService.SetToolButtonEnabled("导  入", isShowImportButton);
        }

        /// <summary>
        /// 设置工具栏按钮显示情况 原ToolBarService方式 该函数无法实现相应功能
        /// </summary>
        /// <param name="isShowApplyButton"></param>
        /// <param name="isShowInButton"></param>
        /// <param name="isShowOutButton"></param>
        /// <param name="isShowStockButton"></param>
        /// <param name="isShowDelButton"></param>
        public virtual void SetToolBarButton(bool isShowApplyButton, bool isShowInButton, bool isShowOutButton, bool isShowStockButton, bool isShowDelButton)
        {
            this.SetToolBarButton(isShowApplyButton, isShowInButton, isShowOutButton, isShowStockButton, isShowDelButton, false);
        }

        /// <summary>
        /// 设置工具栏按钮显示情况
        /// </summary>
        /// <param name="isShowApplyButton"></param>
        /// <param name="isShowInButton"></param>
        /// <param name="isShowOutButton"></param>
        /// <param name="isShowStockButton"></param>
        /// <param name="isShowDelButton"></param>
        /// <param name="isShowExport"></param>
        /// <param name="isShowImport"></param>
        public virtual void SetToolBarButtonVisible(bool isShowApplyButton, bool isShowInButton, bool isShowOutButton, bool isShowStockButton, bool isShowDelButton,bool isShowExport,bool isShowImport)
        {
            if (this.SetToolButtonVisibleEvent != null)
            {
                this.SetToolButtonVisibleEvent(isShowApplyButton, isShowInButton, isShowOutButton, isShowStockButton, isShowDelButton,isShowExport, isShowImport);
            }
        }


        /// <summary>
        /// 申请单据信息
        /// </summary>
        public virtual void OnApplyList()
        {
            
        }

        /// <summary>
        /// 入库单据信息
        /// </summary>
        public virtual void OnInList()
        {
 
        }

        /// <summary>
        /// 出库单据信息
        /// </summary>
        public virtual void OnOutList()
        {

        }

        /// <summary>
        /// 采购单据信息
        /// </summary>
        public virtual void OnStockList()
        {
 
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void OnDelete()
        {
 
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        public virtual void OnImport()
        {
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public virtual int OnExport()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("保存成功"));
            }

            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            this.OnExport();

            return base.Export(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 添加项目显示录入UC
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddItemInputUC(Neusoft.FrameWork.WinForms.Controls.ucBaseControl ucItemInput)
        {
            if (ucItemInput == null)
            {
                this.panelItemManager.Visible = false;
            }
            else
            {
                this.panelItemManager.Controls.Clear();

                this.panelItemManager.Controls.Add(ucItemInput);

                this.panelItemManager.Size = ucItemInput.Size;

                ucItemInput.Dock = DockStyle.Fill;
            }

            return 1;
        }

          /// <summary>
        /// 设置目标科室
        /// </summary>
        /// <param name="isCompany">目标单位是否为供货公司 True 供货公司 False 院内科室 设为True时剩余参数无意义</param>
        /// <param name="isPrivInOut">是否维护的入出库科室列表 设为True时 科室类型参数无意义</param>
        /// <param name="companyType">供货公司类型 物资/药品/设备</param>
        /// <param name="deptType">院内科室类型</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SetTargetDept(bool isCompany, bool isPrivInOut, Neusoft.HISFC.Models.IMA.EnumModuelType companyType, Neusoft.HISFC.Models.Base.EnumDepartmentType deptType)
        {
            return this.SetTargetDept(isCompany,isPrivInOut,false,companyType,deptType);
        }

        /// <summary>
        /// 设置目标科室
        /// </summary>
        /// <param name="isCompany">目标单位是否为供货公司 True 供货公司 False 院内科室 设为True时剩余参数无意义</param>
        /// <param name="isPrivInOut">是否维护的入出库科室列表 设为True时 科室类型参数无意义</param>
        /// <param name="isAddSelf">是否将当前登陆科室加入列表</param>
        /// <param name="companyType">供货公司类型 物资/药品/设备</param>
        /// <param name="deptType">院内科室类型</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SetTargetDept(bool isCompany,bool isPrivInOut,bool isAddSelf , Neusoft.HISFC.Models.IMA.EnumModuelType companyType, Neusoft.HISFC.Models.Base.EnumDepartmentType deptType)
        {
            this.alTargetDept.Clear();

            this.lnbTarget.Visible = true;
            this.cmbTargetDept.Visible = true;

            if (isCompany)
            {
                #region 加载供货公司

                switch (companyType)
                {                   
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:         //设备
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:          //物资
                        //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} 屏蔽物资部分
                        //Neusoft.HISFC.BizLogic.Material.ComCompany companyManager = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                        //this.alTargetDept = companyManager.QueryCompany("1","A");
                        //if (this.alTargetDept == null)
                        //{
                        //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载物资供货公司列表失败" + companyManager.Err));
                        //    return -1;
                        //}
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy:           //药品
                        Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstantManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                        this.alTargetDept = phaConstantManager.QueryCompany("1");
                        if (this.alTargetDept == null)
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载药品供货公司列表失败" + phaConstantManager.Err));
                            return -1;
                        }
                        break;
                }

                foreach (Neusoft.FrameWork.Models.NeuObject info in this.alTargetDept)
                {
                    info.Memo = "1";
                }

                #endregion
            }
            else
            {
                if (isPrivInOut)        //权限科室
                {
                    #region 取入出权限科室

                    ArrayList tempAl;
                    Neusoft.HISFC.BizLogic.Manager.PrivInOutDept privInOutManager = new Neusoft.HISFC.BizLogic.Manager.PrivInOutDept();
                    tempAl = privInOutManager.GetPrivInOutDeptList(this.deptInfo.ID, this.class2Priv.ID);
                    if (tempAl == null)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(privInOutManager.Err));
                        return -1;
                    }
                    //由privInOutDept转换为neuobject存储
                    Neusoft.HISFC.Models.Base.PrivInOutDept privInOutDept;

                    #region 获取有效科室列表 －－ 为了获取拼音码 郁闷

                    Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    ArrayList alTempDept = managerIntegrate.GetDeptmentAllValid();
                    System.Collections.Hashtable hsDeptCollect = new Hashtable();
                    foreach (Neusoft.HISFC.Models.Base.Department info in alTempDept)
                    {
                        hsDeptCollect.Add(info.ID, info);
                    }

                    #endregion

                    Neusoft.FrameWork.Models.NeuObject tempDept = new Neusoft.FrameWork.Models.NeuObject();
                    for (int i = 0; i < tempAl.Count; i++)
                    {
                        privInOutDept = tempAl[i] as Neusoft.HISFC.Models.Base.PrivInOutDept;
                        if (hsDeptCollect.ContainsKey(privInOutDept.Dept.ID))
                        {
                            tempDept = hsDeptCollect[privInOutDept.Dept.ID] as Neusoft.HISFC.Models.Base.Department;
                            tempDept.Memo = privInOutDept.Memo;
                        }
                        //offerInfo = new Neusoft.FrameWork.Models.NeuObject();
                        //offerInfo.ID = privInOutDept.Dept.ID;			    //供货单位编码
                        //offerInfo.Name = privInOutDept.Dept.Name;		    //供货单位名称
                        //offerInfo.Memo = privInOutDept.Memo;		    //备注

                        this.alTargetDept.Add(tempDept.Clone());
                    }					
                    #endregion
                }
                else
                {
                    #region 根据科室类别获取院内科室

                    Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    this.alTargetDept = managerIntegrate.GetDepartment(deptType);
                    if (this.alTargetDept == null)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据科室类别获取科室列表发生错误") + managerIntegrate.Err);
                        return -1;
                    }
                    foreach (Neusoft.FrameWork.Models.NeuObject info in this.alTargetDept)
                    {
                        info.Memo = "0";
                    }

                    #endregion
                }
            }

            if (this.isSetDefaultTargetDept)
            {
                if (this.targetDept.ID == "")
                {
                    if (this.alTargetDept.Count > 0)
                    {
                        if (this.localTargetDept != null && this.localTargetDept.ID != "")
                        {
                            this.TargetDept = this.localTargetDept;
                            this.localTargetDept = null;
                        }
                        else
                        {
                            this.TargetDept = this.alTargetDept[0] as Neusoft.FrameWork.Models.NeuObject;
                        }
                    }
                }             
            }

            if (isAddSelf)
            {
                Neusoft.FrameWork.Models.NeuObject selfDept = this.deptInfo.Clone();
                selfDept.Memo = "0";

                this.alTargetDept.Insert(0,selfDept);
            }

            this.cmbTargetDept.AddItems(this.alTargetDept);
            this.cmbTargetDept.SelectedIndexChanged -= new EventHandler(cmbTargetPerson_SelectedIndexChanged);
            this.cmbTargetDept.Text = this.targetDept.Name;
            this.cmbTargetDept.SelectedIndexChanged += new EventHandler(cmbTargetPerson_SelectedIndexChanged);

            return 1;
        }

        /// <summary>
        /// 设置领送人
        /// </summary>
        /// <param name="isAllEmployee">所有人员 设置为True时 employeeType参数无意义</param>
        /// <param name="employeeType">人员类别</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SetTargetPerson(bool isAllEmployee,Neusoft.HISFC.Models.Base.EnumEmployeeType employeeType)
        {
            this.alTargetPerson.Clear();

            this.lnbTargetPerson.Visible = true;
            this.cmbTargetPerson.Visible = true;

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            if (isAllEmployee)
                this.alTargetPerson = managerIntegrate.QueryEmployeeAll();
            else
                this.alTargetPerson = managerIntegrate.QueryEmployee(employeeType);

            if (this.alTargetPerson == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据人员类别获取人员列表发生错误") + managerIntegrate.Err);
                return -1;
            }

            if (this.isSetDefaultTargetPerson)
            {
                if (this.targetPerson.ID == "")
                {
                    if (this.alTargetPerson.Count > 0)
                    {
                        if (this.localTargetPerson != null && this.localTargetPerson.ID != "")
                        {
                            this.TargetPerson = this.localTargetPerson;
                            this.localTargetPerson = null;
                        }
                        else
                        {
                            this.TargetPerson = this.alTargetPerson[0] as Neusoft.FrameWork.Models.NeuObject;
                        }
                    }
                }
            }

            this.cmbTargetPerson.AddItems(this.alTargetPerson);           
            this.cmbTargetPerson.Text = this.TargetPerson.Name;

            return 1;
        }

        /// <summary>
        /// 设置权限类别
        /// </summary>
        /// <param name="isUseLocal">是否默认为上一次选择的权限</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SetPrivType(bool isUseLocal)
        {
            if (this.privList.Count == 0)
            {
                if (this.InitPrivType() == -1)
                {
                    return -1;
                }
            }

            this.FilterPriv(ref this.privList);

            if (this.privList.Count == 0)
            {
                MessageBox.Show(Language.Msg("您无任何操作权限 请于相关负责人联系获取授权"));
                return -1;
            }

            this.cmbPrivType.AddItems(new ArrayList(this.privList.ToArray()));

            if (isUseLocal)
            {
                #region 读取本地配置文件获取上一次选择的权限

                try
                {
                    if (System.IO.File.Exists(Application.StartupPath + this.filePath))
                    {
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        doc.Load(Application.StartupPath + this.filePath);
                        System.Xml.XmlNode operNode = doc.SelectSingleNode("/Setting/DeptInfo[@DeptID = '" + this.deptInfo.ID + "']/OperInfo[@OperID = '" + this.operInfo.ID + "']");
                        if (operNode != null)
                        {
                            #region 找到该操作员信息

                            string xmlPrivId = operNode.ChildNodes[0].Attributes["ID"].Value.ToString();
                            foreach (Neusoft.FrameWork.Models.NeuObject temp in this.privList)
                            {
                                if (temp.ID == xmlPrivId)
                                {
                                    //操作员仍具有上次的入库权限  设置操作类型显示
                                    this.PrivType = temp;

                                    //设置供货单位
                                    this.targetDept.ID = operNode.ChildNodes[1].Attributes["ID"].Value.ToString();
                                    this.targetDept.Name = operNode.ChildNodes[1].Attributes["Name"].Value.ToString();
                                    //保存本地配置文件内的供货单位信息
                                    this.localTargetDept = this.targetDept;

                                    this.targetPerson.ID = operNode.ChildNodes[2].Attributes["ID"].Value.ToString();
                                    this.targetPerson.Name = operNode.ChildNodes[2].Attributes["Name"].Value.ToString();
                                    //保存本地配置文件内的领用人信息 
                                    this.localTargetPerson = this.targetPerson;

                                    return 1;
                                }
                            }
                            #endregion

                            if (this.PrivType.ID == "")
                            {
                                Neusoft.FrameWork.Models.NeuObject info = this.privList[0];
                                this.PrivType = info;
                            }
                        }
                        else
                        {
                            Neusoft.FrameWork.Models.NeuObject info = this.privList[0];
                            this.PrivType = info;
                        }
                    }
                    else
                    {
                        Neusoft.FrameWork.Models.NeuObject info = this.privList[0];
                        this.PrivType = info;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg(ex.Message));
                    return -1;
                }

                #endregion
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject info = this.privList[0];
                this.PrivType = info;
            }

            return 1;
        }

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsSaveDefaultPriv = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.In_Save_Priv, true, true);
        }

        #region 权限初始化及设置

        /// <summary>
        /// 初始化权限类型
        /// </summary>
        /// <returns>成功进行权限选择返回1 否则返回-1</returns>
        protected int InitPrivType()
        {
            #region 有效性判断

            if (this.Class2Priv.ID == "")
            {
                MessageBox.Show(Language.Msg("未获取当前操作的二级权限编码"));
                return -1;
            }
            if (this.DeptInfo.ID == "")
            {
                MessageBox.Show(Language.Msg("未获取当前操作科室编码"));
                return -1;
            }
            if (this.OperInfo.ID == "")
            {
                MessageBox.Show(Language.Msg("未获取当前操作员编码"));
                return -1;
            }

            #endregion

            #region 获取当前操作员具有的权限集合

            this.privList = this.powerDetailManager.QueryUserPrivCollection(this.OperInfo.ID, this.Class2Priv.ID, this.DeptInfo.ID);
            if (this.privList == null)
            {
                MessageBox.Show(Language.Msg("读取操作员操作权限集合时出错！\n" + this.powerDetailManager.Err));
                return -1;
            }

            #endregion

            #region 获取三级权限涵义码

            Neusoft.HISFC.Models.Admin.PowerLevelClass3 privClass3;

            Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerLevelManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
            foreach (Neusoft.FrameWork.Models.NeuObject info in this.privList)
            {
                privClass3 = powerLevelManager.LoadLevel3ByPrimaryKey(this.Class2Priv.ID, info.ID);
                if (privClass3 == null)
                {
                    MessageBox.Show(Language.Msg("获取三级权限涵义码出错\n查找三级权限涵义码出错" + powerLevelManager.Err));
                    return -1;
                }
                info.Memo = privClass3.Class3MeaningCode;
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 权限过滤
        /// </summary>
        protected virtual void FilterPriv(ref List<Neusoft.FrameWork.Models.NeuObject> privList)
        {
        }

        /// <summary>
        /// 权限选择 
        /// </summary>
        /// <returns>1 成功选择新权限 0 未选择任何权限或权限未发生变化 -1 发生错误</returns>
        public int SelectPriv()
        {
            if (this.privList.Count == 0)
                this.InitPrivType();

            Neusoft.FrameWork.Models.NeuObject tempPriv = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(new ArrayList(this.privList.ToArray()), ref tempPriv) == 0)
            {
                return 0;
            }
            else
            {
                if (tempPriv.ID == this.privType.ID)
                {
                    return 0;
                }
                else
                {
                    this.privType = tempPriv;
                    return 1;
                }
            }
        }

        /// <summary>
        /// 保存操作员最后一次选择的操作类型、目标单位写入配置文件
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePriv()
        {
            try
            {
                if (this.filePath == "")
                {
                    return 1;
                }

                Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                System.Xml.XmlElement root;
                if (System.IO.File.Exists(Application.StartupPath + this.filePath))
                {		//文件已存在
                    doc.Load(Application.StartupPath + this.filePath);
                    root = (System.Xml.XmlElement)doc.SelectSingleNode("Setting");
                }
                else
                {											//文件不存在
                    //设置根结点
                    root = myXml.CreateRootElement(doc, "Setting", "1.0");
                }

                System.Xml.XmlNode deptNode = doc.SelectSingleNode("/Setting/DeptInfo[@DeptID = '" + this.deptInfo.ID + "']");
                if (deptNode != null)           //存在科室节点
                {
                    System.Xml.XmlNode operNode = doc.SelectSingleNode("/Setting/DeptInfo[@DeptID = '" + this.deptInfo.ID + "']/OperInfo[@OperID = '" + this.operInfo.ID + "']");
                    if (operNode != null)       //存在操作员节点
                    {
                        //保存入库类型
                        operNode.ChildNodes[0].Attributes["ID"].Value = this.PrivType.ID;
                        operNode.ChildNodes[0].Attributes["Name"].Value = this.privType.Name;
                        //保存目标科室
                        operNode.ChildNodes[1].Attributes["ID"].Value = this.targetDept.ID;
                        operNode.ChildNodes[1].Attributes["Name"].Value = this.targetDept.Name;
                        //保存领送人
                        operNode.ChildNodes[2].Attributes["ID"].Value = this.targetPerson.ID;
                        operNode.ChildNodes[2].Attributes["Name"].Value = this.targetPerson.Name;
                    }
                    else                       //不存在操作员节点
                    {
                        #region 添加操作员节点

                        //在该科室内未找到该操作员历史信息 添加该操作员信息
                        System.Xml.XmlElement xmlNewOper = doc.CreateElement("OperInfo");
                        xmlNewOper.SetAttribute("OperID", this.operInfo.ID);
                        //添加入库类型子节点 并赋值
                        System.Xml.XmlElement xmlPriv = doc.CreateElement("PrivType");
                        xmlPriv.SetAttribute("ID", this.privType.ID);
                        xmlPriv.SetAttribute("Name", this.privType.Name);
                        xmlNewOper.AppendChild(xmlPriv);
                        //添加供货单位子节点 并赋值
                        System.Xml.XmlElement xmlOffer = doc.CreateElement("TargetDept");
                        xmlOffer.SetAttribute("ID", this.targetDept.ID);
                        xmlOffer.SetAttribute("Name", this.targetDept.Name);
                        xmlNewOper.AppendChild(xmlOffer);
                        //添加领送人子节点 并赋值
                        System.Xml.XmlElement xmlPerson = doc.CreateElement("TargetPerson");
                        xmlPerson.SetAttribute("ID", this.targetPerson.ID);
                        xmlPerson.SetAttribute("Name", this.targetPerson.Name);
                        xmlNewOper.AppendChild(xmlPerson);

                        //设置关联
                        ((System.Xml.XmlElement)deptNode).AppendChild(xmlNewOper);

                        #endregion
                    }
                }
                else
                {
                    #region 添加科室节点

                    //该科室未找到 添加该科室、该操作员的配置信息 本次入库类型 供货单位
                    System.Xml.XmlElement xmlNewDept = doc.CreateElement("DeptInfo");
                    xmlNewDept.SetAttribute("DeptID", this.deptInfo.ID);

                    //添加该操作员信息
                    System.Xml.XmlElement xmlNewOper1 = doc.CreateElement("OperInfo");
                    xmlNewOper1.SetAttribute("OperID", this.operInfo.ID);
                    //添加入库类型子节点 并赋值
                    System.Xml.XmlElement xmlPriv1 = doc.CreateElement("PrivType");
                    xmlPriv1.SetAttribute("ID", this.privType.ID);
                    xmlPriv1.SetAttribute("Name", this.privType.Name);
                    //添加供货单位子节点 并赋值
                    System.Xml.XmlElement xmlOffer1 = doc.CreateElement("TargetDept");
                    xmlOffer1.SetAttribute("ID", this.targetDept.ID);
                    xmlOffer1.SetAttribute("Name", this.targetDept.Name);
                    //添加领送人子节点 并赋值
                    System.Xml.XmlElement xmlPerson = doc.CreateElement("TargetPerson");
                    xmlPerson.SetAttribute("ID", this.targetPerson.ID);
                    xmlPerson.SetAttribute("Name", this.targetPerson.Name);

                    xmlNewOper1.AppendChild(xmlPriv1);
                    xmlNewOper1.AppendChild(xmlOffer1);
                    xmlNewOper1.AppendChild(xmlPerson);

                    xmlNewDept.AppendChild(xmlNewOper1);

                    root.AppendChild(xmlNewDept);

                    #endregion
                }

                doc.Save(Application.StartupPath + this.filePath);

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="filterData"></param>
        protected virtual void Filter(string filterData)
        {
 
        }

        /// <summary>
        /// 清屏
        /// </summary>
        protected virtual void Clear()
        {
            this.TargetDept = new Neusoft.FrameWork.Models.NeuObject();

            this.TargetPerson = new Neusoft.FrameWork.Models.NeuObject();

            this.ShowInfo = "显示信息:";

            this.TotCostInfo = "总金额:";

            this.lnbTargetPerson.Visible = false;
            this.lnbTarget.Visible = false;
        }

        /// <summary>
        /// 设置TargetPerson焦点
        /// </summary>
        public void SetPersonFocus()
        {
            this.lnbTargetPerson.Select();
            this.lnbTargetPerson.Focus();
        }

        /// <summary>
        /// 设置TargetDept焦点
        /// </summary>
        public void SetDeptFocus()
        {
            this.lnbTarget.Select();
            this.lnbTarget.Focus();
        }

        /// <summary>
        /// 清除事件列表
        /// </summary>
        private void ClearEvent()
        {
            //清除FpKeyEvent的事件委托列表
            if (this.FpKeyEvent != null)
            {
                Delegate[] methodDelegate = this.FpKeyEvent.GetInvocationList();
                foreach (Delegate tempDelegate in methodDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.FpKeyHandler tempKeyHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.FpKeyHandler)tempDelegate;

                    this.FpKeyEvent -= tempKeyHandler;
                }
            }
            //清除BeginTarget事件委托
            if (this.BeginTargetChanged != null)
            {
                Delegate[] beginTargetdDelegate = this.BeginTargetChanged.GetInvocationList();
                foreach (Delegate tempDelegate in beginTargetdDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.BeginTargetChanged -= tempHandler;
                }
            }
            //清除EndTarget事件委托
            if (this.EndTargetChanged != null)
            {
                Delegate[] endTargetdDelegate = this.EndTargetChanged.GetInvocationList();
                foreach (Delegate tempDelegate in endTargetdDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.EndTargetChanged -= tempHandler;
                }
            }
            //清除BeginPerson事件委托
            if (this.BeginPersonChanged != null)
            {
                Delegate[] beginPersonDelegate = this.BeginPersonChanged.GetInvocationList();
                foreach (Delegate tempDelegate in beginPersonDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.BeginPersonChanged -= tempHandler;
                }
            }
            //清除EndPerson事件委托
            if (this.EndPersonChanged != null)
            {
                Delegate[] endPersondDelegate = this.EndPersonChanged.GetInvocationList();
                foreach (Delegate tempDelegate in endPersondDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.EndPersonChanged -= tempHandler;
                }
            }
            //清除BeginPriv事件委托
            if (this.BeginPrivChanged != null)
            {
                Delegate[] beginPrivDelegate = this.BeginPrivChanged.GetInvocationList();
                foreach (Delegate tempDelegate in beginPrivDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.BeginPrivChanged -= tempHandler;
                }
            }
            //清除EndPriv事件委托
            if (this.EndPrivChanged != null)
            {
                Delegate[] endPrivDelegate = this.EndPrivChanged.GetInvocationList();
                foreach (Delegate tempDelegate in endPrivDelegate)
                {
                    Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler tempHandler = (Neusoft.HISFC.Components.Common.Controls.ucIMAInOutBase.DataChangedHandler)tempDelegate;

                    this.EndPrivChanged -= tempHandler;
                }
            }
        }

        #endregion

        #region 触发事件

        /// <summary>
        /// 目标科室更改前触发事件
        /// </summary>
        /// <param name="changeData">更改的数据</param>
        /// <param name="param">扩展信息</param>
        protected virtual void OnBeginTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.BeginTargetChanged != null)
                this.BeginTargetChanged(changeData, param);
        }

        /// <summary>
        /// 目标科室更改后触发事件
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        protected virtual void OnEndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.EndTargetChanged != null)
                this.EndTargetChanged(changeData, param);
        }

        /// <summary>
        /// 目标人员更改前触发事件
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        protected virtual void OnBeginPersonChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.BeginPersonChanged != null)
                this.BeginPersonChanged(changeData, param);
        }

        /// <summary>
        /// 目标人员更改后触发事件
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        protected virtual void OnEndPersonChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.EndPersonChanged != null)
                this.EndPersonChanged(changeData, param);
        }

        /// <summary>
        /// 类别更改前触发事件
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        protected virtual void OnBeginPrivChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.BeginPrivChanged != null)
                this.BeginPrivChanged(changeData, param);
        }

        /// <summary>
        /// 类别更改后触发事件
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        protected virtual void OnEndPrivChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            if (this.EndPrivChanged != null)
                this.EndPrivChanged(changeData, param);
        }

        /// <summary>
        /// Fp内按键事件
        /// </summary>
        /// <param name="key"></param>
        protected virtual void OnFpKey(Keys key)
        {
            if (this.FpKeyEvent != null)
                this.FpKeyEvent(key);
        }

        #endregion

        private void lnbTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //弹出选择窗口
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alTargetDept, ref info) == 0)
            {
                return;
            }
            else
            {           
                if (info.ID == this.targetDept.ID)		//如果类型不发生变化则返回
                {
                    return;
                }
                else
                {
                    this.OnBeginTargetChanged(info, null);

                    this.TargetDept = info;

                    this.OnEndTargetChanged(info,null);
                }
            }
        }

        private void lnbPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.alTargetPerson == null)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.alTargetPerson = managerIntegrate.QueryEmployeeAll();
            }
            //弹出选择窗口
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alTargetPerson, ref info) == 0)
            {
                return;
            }
            else
            {              
                if (info.ID == this.targetPerson.ID)		//如果类型不发生变化则返回
                {
                    return;
                }
                else
                {
                    this.OnBeginPersonChanged(info, null);

                    this.TargetPerson = info;

                    this.OnEndPersonChanged(info, null);
                }
            }         
        }

        private void lnbPrivType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.privList.Count == 0)
            {
                this.InitPrivType();
            }
            //弹出选择窗口
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(new ArrayList(this.privList.ToArray()), ref info) == 0)
            {
                return;
            }
            else
            {              
                if (info.ID == this.privType.ID)		//如果类型不发生变化则返回
                {
                    return;
                }
                else
                {
                    this.OnBeginPrivChanged(info, null);

                    this.ClearEvent();

                    this.PrivType = info;

                    this.OnEndPrivChanged(info, null);
                }
            }           
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                this.OnFpKey(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter(this.txtFilter.Text);
        }

        private void cmbPrivType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject info in this.privList)
            {
                if (info.ID == this.cmbPrivType.Tag.ToString())
                {
                    this.OnBeginPrivChanged(info, null);

                    this.ClearEvent();

                    this.PrivType = info;

                    this.OnEndPrivChanged(info, null);

                    break;
                }
            }
        }

        private void cmbTargetDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject info in this.alTargetDept)
            {
                if (info.ID == this.cmbTargetDept.Tag.ToString())
                {
                    this.OnBeginTargetChanged(info, null);

                    this.TargetDept = info;

                    this.OnEndTargetChanged(info, null);
                }
            }
        }

        private void cmbTargetPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject info in this.alTargetPerson)
            {
                if (info.ID == this.cmbTargetPerson.Tag.ToString())
                {
                    this.OnBeginPersonChanged(info, null);

                    this.TargetPerson = info;

                    this.OnEndPersonChanged(info, null);

                    break;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //{EB28B40A-ECE6-41e1-A184-EB2B64E3D6FE}  下拉列表显示时不允许弹出窗口
            this.cmbPrivType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTargetDept.DropDownStyle = ComboBoxStyle.DropDownList;
            
            base.OnLoad(e);
        }

    }
}
