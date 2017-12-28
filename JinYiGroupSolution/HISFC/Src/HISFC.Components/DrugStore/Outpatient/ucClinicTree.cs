using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 门诊配发药列表显示控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <需注意问题
    ///     1、检索方式提供发票号/处方号/病例卡号多种方式 但病例卡号的方式可能一张卡存在多个不同状态的单 此种方式下的处理
    ///         尤其是其他终端配/发的情况
    ///		
    ///  />
    /// <修改记录>
    ///     <修改原因>广州肿瘤HIS需求</修改原因>
    ///     <修改内容>
    ///             1、门诊配药时，对于手动打印情况下，患者列表仍自动刷新但不打印
    ///             2、可选择终端打印的单据类型：标签或配药清单。但自动打印的情况下，只能打印标签，手工打印的情况下可进行选择。
    ///             3、标签打印时，选择配药单打印后没有对发药窗口号进行赋值
    ///     </修改内容>
    ///     <修改人>梁俊泽</修改人>
    ///     1 兼容物理卡号检索门诊待配发药处方 by Sunjh 2010-11-23 {60523334-715A-419c-925B-34E7E13E2606}
    /// </修改记录>
    /// </summary>
    public partial class ucClinicTree : DrugStore.Outpatient.ucClinicBase
    {
        public ucClinicTree()
        {
            InitializeComponent();
        }

        public delegate void ProcessMessageHandler(object sender, string msg);

        public delegate void MyTreeSelectHandler(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe);

        public delegate void MyOperChangedHandler(Neusoft.FrameWork.Models.NeuObject oper);

        /// <summary>
        /// 对打印过的结点改变结点位置
        /// </summary>
        private delegate void ChangePrintNodeHandler(TreeNode node,bool targetNextNodeType);

        /// <summary>
        /// 程序运行过程中发送的消息
        /// </summary>
        public event ProcessMessageHandler ProcessMessageEvent;

        /// <summary>
        /// 树列表选择事件
        /// </summary>
        public event MyTreeSelectHandler MyTreeSelectEvent;

        /// <summary>
        /// 配/发药操作员发生变化
        /// </summary>
        public event MyOperChangedHandler OperChangedEvent;

        /// <summary>
        /// 保存
        /// </summary>
        public event System.EventHandler SaveRecipeEvent;

        #region 消息发送接口

        /// <summary>
        /// LED大屏幕显示接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientLEDShow LEDShowInterface = null;

        #endregion

        #region 帮助类

        /// <summary>
        /// 人员帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 终端帮助类  {23E209BB-B4EB-4676-851A-DA053F0D51FD}
        /// </summary>
        protected System.Collections.Hashtable hsTerminalDictionary = new Hashtable();

        #endregion

        #region 树操作变量

        /// <summary>
        /// 数据添加树
        /// </summary>
        private DrugStore.Outpatient.tvClinicTree AddTree = null;

        /// <summary>
        /// 数据操作树
        /// </summary>
        private DrugStore.Outpatient.tvClinicTree OperTree = null;

        /// <summary>
        /// 数据后继树
        /// </summary>
        private DrugStore.Outpatient.tvClinicTree NextTree = null;

        /// <summary>
        /// 功能类别 0 发药 1 配药 2 还药
        /// </summary>
        private string funType = "0";

        /// <summary>
        /// 查询时检索的时间下限
        /// </summary>
        private DateTime minQueryDate = System.DateTime.MinValue;

        #endregion

        #region 域变量

        /// <summary>
        /// 药房操作管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 当前最大配药时间
        /// </summary>
        DateTime maxDrugedDateTime = System.DateTime.MinValue;

        /// <summary>
        /// 打开窗口时系统日期
        /// </summary>
        DateTime sysDate = System.DateTime.MinValue;

        /// <summary>
        /// 默认单据检索方式
        /// </summary>
        private DrugStore.OutpatientBillType defaultBillType = OutpatientBillType.处方号;

        /// <summary>
        /// 当前单据检索方式
        /// </summary>
        private DrugStore.OutpatientBillType nowBillType = OutpatientBillType.病例卡号;

        /// <summary>
        /// 前一次操作工号
        /// </summary>
        private string privOperID = "";

        /// <summary>
        /// 人员工号检索时补位个数 -1 不需补位
        /// </summary>
        private int PIDFillNum = -1;

        /// <summary>
        /// 是否对配/发药人员进行权限判断
        /// </summary>
        private bool isJudgePriv = false;

        /// <summary>
        /// 标签打印数据传输方式 True 一次全部传输  False  分组合传输
        /// </summary>
        private bool isAllSend = false;

        /// <summary>
        /// 当前操作的门诊调剂信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugRecipe nowDrugRecipe = null;

        /// <summary>
        /// 是否是草药方式打印 配药打印时是否打印草药摆药单而不打印标签
        /// </summary>
        private bool isHerbalPrint = false;

        /// <summary>
        /// 对存在作废记录的处方是否打印
        /// </summary>
        private bool isPrintCancelRecipe = false;

        /// <summary>
        /// 打印后节点位置转换委托
        /// </summary>
        private ChangePrintNodeHandler changeNode = null;

        /// <summary>
        /// 当前是否正在进行保存操作
        /// </summary>
        private bool isBusySave = false;

        /// <summary>
        /// 通过单据检索未存在处方号时 是否对未打印标签进行添加
        /// </summary>
        private bool isFindToAdd = false;

        /// <summary>
        /// 是否自动打印
        /// </summary>
        private bool isAutoPrint = false;

        /// <summary>
        /// 是否显示隔天发药信息
        /// </summary>
        private bool isShowOldInfo = false;

        /// <summary>
        /// 是否再配药确认时更新处方调剂信息
        /// </summary>
        private bool isAdjustInDrug = true;

        /// <summary>
        /// 是否自动发药
        /// </summary>
        private bool isAutoSend = false;

        /// <summary>
        /// 是否自动配药
        /// </summary>
        private bool isAutoDruged = false;

        /// <summary>
        /// 是否按病历卡号检索使用物理卡号 by Sunjh 2010-11-23 {60523334-715A-419c-925B-34E7E13E2606}
        /// </summary>
        private bool isSearchByMarkNo = true;

        #endregion

        #region 属性

        /// <summary>
        /// 默认单据检索方式
        /// </summary>
        [Category("设置"),DefaultValue(DrugStore.OutpatientBillType.处方号)]
        public DrugStore.OutpatientBillType DefaultBillType
        {
            get
            {
                return this.defaultBillType;
            }
            set
            {
                this.defaultBillType = value;
            }
        }

        /// <summary>
        /// 进行保存操作时 进行互斥赋值
        /// </summary>
        [Category("设置"), DefaultValue(false)]
        public bool IsBusySave
        {
            get
            {
                return this.isBusySave;
            }
            set
            {
                this.isBusySave = value;
            }
        }

        /// <summary>
        /// 是否显示最新一条配药记录的收费时间
        /// </summary>
        [Description("是否显示最新一条配药记录的收费时间"),Category("设置"), DefaultValue(false)]
        public bool IsShowFeeData
        {
            get
            {
                return this.lbFeeDate.Visible;
            }
            set
            {
                this.lbFeeDate.Visible = value;
            }
        }

        /// <summary>
        /// 通过单据检索未存在处方号时 是否对未打印标签进行添加
        /// </summary>
        public bool IsFindToAdd
        {
            get
            {
                return this.isFindToAdd;
            }
            set
            {
                this.isFindToAdd = value;
            }
        }

        /// <summary>
        /// 是否自动打印
        /// </summary>
        public bool IsAutoPrint
        {
            get
            {
                return this.isAutoPrint;
            }
            set
            {
                this.isAutoPrint = value;
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            this.sysDate = this.drugStoreManager.GetDateTimeFromSysDateTime();

            this.minQueryDate = this.sysDate.Date;

            #region 控制参数获取

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //工号补足位数 －1 不补位
            this.PIDFillNum = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_OperCode_Length,true, -1);
            //是否对配/发药保存人员进行权限判断
            this.isJudgePriv = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Need_Priv, true, true);

            //标签打印接口数据传送方式  默认值 False 采用分组传送方式
            this.isAllSend = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_PrintData_SentType, true, false);
           
            //是否对存在作废记录的处方进行打印
            this.isPrintCancelRecipe = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Print_BackRecipe, true, true);

            //是否显示隔天待发药信息
            this.isShowOldInfo = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Show_OldSended, true, false);            
            if (this.isShowOldInfo)
            {
                this.minQueryDate = new DateTime(2000, 1, 1, 10, 0, 0);
            }

            //是否自动发药 {DBB3C382-BB23-463b-8847-2F73C55F2586}
            this.isAutoSend = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Auto_Send, false, false);

            //是否自动发药 {DBB3C382-BB23-463b-8847-2F73C55F2586}
            this.isAutoDruged = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Auto_Druged, false, false);

            #region 读取打印时是否打印清单而不打印标签
            //string strErr = "";
            //ArrayList alParm = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ClinicDrug", "PrintList", out strErr);
            //if (alParm == null || alParm.Count == 0)
            //{
            //    if (this.funModle == OutpatientFun.Drug)
            //    {
            //        MessageBox.Show(Language.Msg("未设置本地配置参数 本配药台打印时将按照标签格式打印 \n") + strErr);
            //    }
            //    this.isHerbalPrint = false;
            //}
            //else
            //{
            //    if ((alParm[0] as string) == "1")
            //        this.isHerbalPrint = true;
            //    else
            //        this.isHerbalPrint = false;
            //}

            this.isHerbalPrint = true;
            if (this.terminal.TerimalPrintType == Neusoft.HISFC.Models.Pharmacy.EnumClinicPrintType.标签)
            {
                this.isHerbalPrint = false;
            }
            #endregion				

            #endregion

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList al = manager.QueryEmployeeAll();
            if (al == null)
            {
                MessageBox.Show(Language.Msg("检索人员列表失败") + manager.Err);
                return;
            }
            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(al);

            this.lbnBillType.Text = this.nowBillType.ToString();

            #region {F8D76CE8-6A0C-469b-AC43-4F69B2FCBAD8} 获取控制参数信息 用于控制调剂参数更新方式

            Neusoft.FrameWork.Management.ExtendParam extManager = new Neusoft.FrameWork.Management.ExtendParam();
            try
            {
                Neusoft.HISFC.Models.Base.ExtendInfo deptExt = extManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, "AdjustGist", this.OperDept.ID);
                if (deptExt == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取科室扩展属性内配药调剂参数失败！"));
                }

                if (deptExt.StringProperty == "1")		//发药
                    this.isAdjustInDrug = false;
                else
                    this.isAdjustInDrug = true;			//配药
            }
            catch { }

            #endregion

            //{23E209BB-B4EB-4676-851A-DA053F0D51FD}  初始化终端帮助类
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManagement = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();
            ArrayList alSendTerminalList = drugStoreManagement.QueryDrugTerminalByDeptCode(this.OperDept.ID, "0");
            if (alSendTerminalList != null)
            {
                this.hsTerminalDictionary.Clear();

                foreach (Neusoft.FrameWork.Models.NeuObject info in alSendTerminalList)
                {
                    this.hsTerminalDictionary.Add(info.ID, info.Name);
                }
            }
        }

        /// <summary>
        /// 初始化树管理类
        /// </summary>
        private void InitTreeManager(DrugStore.OutpatientFun winFumModle)
        {
            switch (winFumModle)
            {
                case OutpatientFun.Drug:            //配药

                    #region 配药  参数界面设置

                    this.AddTree = this.tvPrinting;     //数据添加
                    this.AddTree.State = "0";
                    this.AddTree.ParentTab = this.tpPrinting;

                    this.OperTree = this.tvPrinted;     //数据操作
                    this.OperTree.State = "1";
                    this.OperTree.ParentTab = this.tpPrinted;

                    this.NextTree = this.OperTree;       //数据后继

                    if (this.neuTabControl1.TabPages.Contains(this.tpDruged))           //已配药未发药
                        this.neuTabControl1.TabPages.Remove(this.tpDruged);		       
                    if (this.neuTabControl1.TabPages.Contains(this.tpSend))             //已发药
                        this.neuTabControl1.TabPages.Remove(this.tpSend);		        
                    if (!this.neuTabControl1.TabPages.Contains(this.tpPrinted))         //已打印Tab页
                        this.neuTabControl1.TabPages.Add(this.tpPrinted);
                    if (!this.neuTabControl1.TabPages.Contains(this.tpPrinting))        //未打印Tab页
                        this.neuTabControl1.TabPages.Add(this.tpPrinting);

                    #endregion

                    break;
                case OutpatientFun.Send:            //发药

                    #region 发药  参数及界面设置

                    this.AddTree = this.tvDruged;       //数据添加
                    this.AddTree.State = "2";
                    this.AddTree.ParentTab = this.tpDruged;

                    this.OperTree = this.AddTree;      //数据操作

                    this.NextTree = this.tvSend;        //数据后继
                    this.NextTree.State = "3";
                    this.NextTree.ParentTab = this.tpSend;

                    if (this.neuTabControl1.TabPages.Contains(this.tpPrinted))
                        this.neuTabControl1.TabPages.Remove(this.tpPrinted);		    // 已打印
                    if (this.neuTabControl1.TabPages.Contains(this.tpPrinting))
                        this.neuTabControl1.TabPages.Remove(this.tpPrinting);		    // 未打印
                    if (!this.neuTabControl1.TabPages.Contains(this.tpDruged))          //已打印未发药Tab页
                        this.neuTabControl1.TabPages.Add(this.tpDruged);
                    if (!this.neuTabControl1.TabPages.Contains(this.tpSend))            //已发药Tab页
                        this.neuTabControl1.TabPages.Add(this.tpSend);

                    #endregion

                    break;
                case OutpatientFun.DirectSend:      //直接发药

                    #region 直接发药 参数及界面设置

                    this.AddTree = this.tvPrinting;     //数据添加
                    this.AddTree.State = "0";
                    this.AddTree.ParentTab = this.tpPrinting;

                    this.OperTree = this.tvDruged;      //数据操作
                    this.OperTree.State = "1";
                    this.OperTree.ParentTab = this.tpDruged;

                    this.NextTree = this.tvSend;        //数据后继
                    this.NextTree.State = "3";
                    this.NextTree.ParentTab = this.tpSend;

                    if (this.neuTabControl1.TabPages.Contains(this.tpPrinted))
                        this.neuTabControl1.TabPages.Remove(this.tpPrinted);		    // 已打印
                    //不显示未打印Tab页 只要已发药及未发药
                    if (this.neuTabControl1.TabPages.Contains(this.tpPrinting))        //未打印Tab页
                        this.neuTabControl1.TabPages.Remove(this.tpPrinting);

                    if (!this.neuTabControl1.TabPages.Contains(this.tpDruged))          //已打印未发药Tab页
                        this.neuTabControl1.TabPages.Add(this.tpDruged);

                    if (!this.neuTabControl1.TabPages.Contains(this.tpSend))            //已发药Tab页
                        this.neuTabControl1.TabPages.Add(this.tpSend);

                    #endregion

                    break;
                case OutpatientFun.Back:            //还药

                    #region 还药 参数及界面设置

                    this.AddTree = this.tvDruged;       //数据添加 / 操作
                    this.AddTree.State = "2";
                    this.AddTree.Parent = this.tpDruged;

                    this.OperTree = this.AddTree;

                    this.neuTabControl1.TabPages.Remove(this.tpPrinted);		//已打印
                    this.neuTabControl1.TabPages.Remove(this.tpPrinting);		//未打印
                    this.neuTabControl1.TabPages.Remove(this.tpSend);			//已核准

                    #endregion

                    break;
            }
        }

        #endregion

        #region 重写基类

        /// <summary>
        /// 设置树功能
        /// </summary>
        /// <param name="funMode"></param>
        public override void SetFunMode(OutpatientFun winFunMode)
        {
            this.funModle = winFunMode;
            //根据不同窗口功能设置参数
            switch (winFunMode)
            {
                case OutpatientFun.Drug:            //配药
                    this.funType = "1";
                    break;
                case OutpatientFun.Send:            //发药
                    this.funType = "0";
                    break;
                case OutpatientFun.DirectSend:      //直接发药
                    this.funType = "3";
                    break;
                case OutpatientFun.Back:            //还药
                    this.funType = "2";
                    break;
            }

            this.InitTreeManager(winFunMode);
        }

        /// <summary>
        /// 设置门诊终端
        /// </summary>
        /// <param name="winTerminal">传入门诊终端实体信息</param>
        public override void SetTerminal(Neusoft.HISFC.Models.Pharmacy.DrugTerminal winTerminal)
        {
            base.SetTerminal(winTerminal);

            this.processRefreshInterval = (int)winTerminal.RefreshInterval1;
            this.ledRefreshInterval = (int)winTerminal.RefreshInterval2;

            this.IsAutoPrint = winTerminal.IsAutoPrint;

            if (this.terminal.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口)
            {
                if (this.funModle == OutpatientFun.DirectSend)
                    this.IsShowFeeData = false;
                else
                    this.IsShowFeeData = true;
            }
            else
            {
                this.IsShowFeeData = false;
            }
        }

        /// <summary>
        /// 当前操作人员信息
        /// </summary>
        public override Neusoft.FrameWork.Models.NeuObject OperInfo
        {
            get
            {
                return base.OperInfo;
            }
            set
            {
                base.OperInfo = value;

                if (value != null)
                {
                    this.txtPID.Text = value.ID;
                    this.operName.Text = value.Name;

                    this.privOperID = value.ID;
                }
                else
                {
                    this.operName.Text = "无权限人员";
                }
            }
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public void SetFocus()
        {
            this.txtPID.Select();
            this.txtPID.Focus();
            this.txtPID.SelectAll();
        }
        #endregion

        #region 树操作

        /// <summary>
        /// 显示列表人数汇总
        /// </summary>
        public void SumPatientNum()
        {
            this.tpPrinted.Text = "已 打 印" + "[" + this.tvPrinted.Nodes.Count.ToString() + "]";
            this.tpPrinting.Text = "未 打 印" + "[" + this.tvPrinting.Nodes.Count.ToString() + "]";
            this.tpDruged.Text = "未 发 药" + "[" + this.tvDruged.Nodes.Count.ToString() + "]";
            this.tpSend.Text = "已 发 药" + "[" + this.tvSend.Nodes.Count.ToString() + "]";
        }

        /// <summary>
        /// 改变节点位置
        /// </summary>
        public virtual void ChangeNodeLocation()
        {
            if (this.funModle == OutpatientFun.Drug)
                this.DelNode();
            else
                this.TransferNode();
        }

        /// <summary>
        /// 改变节点位置
        /// </summary>
        protected virtual void TransferNode()
        {
            if (this.AddTree == null)
                return;

            TreeNode tempNode = null;
            if (this.funModle == OutpatientFun.DirectSend)      //直接发药的情况下 新增节点位于OperTree内 
                tempNode = this.OperTree.SelectedNode;
            else
                tempNode = this.AddTree.SelectedNode;

            if (tempNode != null)
            {
                this.TransferNode(tempNode,true);
            }
        }

        /// <summary>
        /// 改变节点位置
        /// </summary>
        /// <param name="node">需转移节点</param>
        /// <param name="targetToNextTree">是否转移至NextTree变量内 True 转移至NextTree False 转移至OperTree变量</param>
        protected virtual void TransferNode(TreeNode node,bool targetToNextTree)
        {
            //移除原节点
            this.AddTree.Nodes.Remove(node);

            // {F8D76CE8-6A0C-469b-AC43-4F69B2FCBAD8}  增加自动配药功能
            if (this.funModle == OutpatientFun.Drug)        //配药窗口 
            {
                if (isAutoDruged)                           //采用自动配药模式
                {
                    #region 自动配药模式 自动完成配药保存

                    Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                    Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                    ArrayList al = itemManager.QueryApplyOutListForClinic(this.OperDept.ID, "M1", "0", info.RecipeNO);
                    if (al == null)
                    {
                        if (this.ProcessMessageEvent != null)
                        {
                            this.ProcessMessageEvent(null, "根据调剂信息获取申请明细信息发生错误" + itemManager.Err);
                        }
                        return;
                    }

                    List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> applyData = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();

                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut tempApply in al)
                    {
                        applyData.Add(tempApply);
                    }

                    if (Function.OutpatientDrug(applyData, this.terminal, this.ApproveDept, this.OperInfo, this.isAdjustInDrug) == -1)
                    {
                        if (this.ProcessMessageEvent != null)
                        {
                            this.ProcessMessageEvent(null, string.Format("对{0}({1})的处方进行自动配药发生错误", info.PatientName, info.RecipeNO));
                        }
                    }

                    if (this.ProcessMessageEvent != null)
                    {
                        this.ProcessMessageEvent(null, string.Format("对{0}({1})的处方已完成自动配药", info.PatientName, info.RecipeNO));
                    }

                    return;

                    #endregion
                }
            }

            if (targetToNextTree)
            {
                #region  将节点转移到NextTree

                if (this.NextTree != null)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugRecipe tempRecipe = node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                    if (tempRecipe != null)
                    {
                        tempRecipe.RecipeState = this.NextTree.State;
                    }

                    
                    //{DF70D8FF-A1DD-421b-8E4A-4637745F1927}
                    //添加节点时判断是否已经存在改患者的节点，如果没有，则新加，如果有，则重新选择一下
                    //this.NextTree.Nodes.Add(node);
                    if (this.NextTree.Nodes.ContainsKey(node.Name) == false)
                    {
                        this.NextTree.Nodes.Add(node);
                    }
                    else
                    {
                        //this.OperTree.Nodes.Remove(this.OperTree.Nodes[node.Name]);
                        //this.OperTree.Nodes.Add(node);
                        this.NextTree.SelectedNode = null;
                        this.NextTree.SelectedNode = this.NextTree.Nodes[node.Name];
                    }
                }

                #endregion
            }
            else
            {
                #region 将节点转移至OperTree

                if (this.OperTree != null)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugRecipe tempRecipe = node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                    if (tempRecipe != null)
                    {
                        tempRecipe.RecipeState = this.OperTree.State;
                    }

                    //{DF70D8FF-A1DD-421b-8E4A-4637745F1927}
                    //添加节点时判断是否已经存在改患者的节点，如果没有，则新加，如果有，则重新选择一下
                    //this.OperTree.Nodes.Add(node);
                    if (this.OperTree.Nodes.ContainsKey(node.Name) == false)
                    {
                        this.OperTree.Nodes.Add(node);
                    }
                    else
                    {
                        //this.OperTree.Nodes.Remove(this.OperTree.Nodes[node.Name]);
                        //this.OperTree.Nodes.Add(node);
                        this.OperTree.SelectedNode = null;
                        this.OperTree.SelectedNode = this.OperTree.Nodes[node.Name];
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        protected virtual void DelNode()
        {
            if (this.OperTree == null)
                return;

            TreeNode tempNode = this.OperTree.SelectedNode;
            if (tempNode != null)
            {
                this.OperTree.Nodes.Remove(tempNode);
            }
        }


        /// <summary>
        /// 查找满足条件的节点
        /// </summary>
        public virtual int FindNode()
        {
            switch (this.nowBillType)
            {
                case OutpatientBillType.发票号:
                    this.txtBillNO.Text = this.txtBillNO.Text.PadLeft(12, '0');
                    break;
                case OutpatientBillType.病例卡号:
                    this.txtBillNO.Text = this.txtBillNO.Text.PadLeft(10, '0');
                    break;
                default:
                    this.txtBillNO.Text = this.txtBillNO.Text;
                    break;
            }
            string strQueryData = this.txtBillNO.Text;

            //兼容物理卡号检索门诊待配发药处方 by Sunjh 2010-11-23 {60523334-715A-419c-925B-34E7E13E2606}
            if (this.nowBillType == OutpatientBillType.病例卡号 && this.isSearchByMarkNo)
            {
                Neusoft.HISFC.Models.Account.AccountCard acObj = new Neusoft.HISFC.Models.Account.AccountCard();
                if (this.feeIntegrate.ValidMarkNO(strQueryData, ref acObj) != -1)
                {
                    if (acObj != null)
                    {
                        strQueryData = acObj.Patient.PID.CardNO;
                    }
                    else
                    {
                        strQueryData = "";
                    }
                }
            }

            if (this.nowBillType == OutpatientBillType.发票号)
            {
                strQueryData = this.GetInvoiceList(strQueryData);
                if (strQueryData == null)
                {
                    return -1;
                }
                if (strQueryData == "")
                {
                    strQueryData = this.txtBillNO.Text;
                }
            }

            return this.FindNode(strQueryData);
        }

        /// <summary>
        /// 查找满足条件的节点
        /// </summary>
        /// <param name="queryStr">待检索字符串</param>
        /// <returns>1 成功找到 0 未找到 －1 发生错误</returns>
        public virtual int FindNode(string queryStr)
        {
            bool nodeInTree = false;
            if (this.OperTree != null)
            {
                nodeInTree = this.FindNodeInTree(queryStr, this.OperTree);
            }
            if (!nodeInTree && this.NextTree != null && this.OperTree != this.NextTree)
            {
                nodeInTree = this.FindNodeInTree(queryStr, this.NextTree);
            }
            if (!nodeInTree && this.AddTree != null && this.AddTree != this.OperTree && this.AddTree != this.NextTree)
            {
                nodeInTree = this.FindNodeInTree(queryStr, this.AddTree);
            }
            if (!nodeInTree)        // 未找到节点
            {
                #region 未找到节点

                #region 根据单据号重新检索数据

                ArrayList al = this.drugStoreManager.QueryDrugRecipe(this.OperDept.ID, "M1", "A", (int)this.nowBillType, queryStr);
                if (al == null)
                {
                    MessageBox.Show(Language.Msg("根据当前单据检索方式未找到满足条件的调剂信息") + this.drugStoreManager.Err);
                    return -1;
                }
                if (al.Count == 0)
                {
                    MessageBox.Show(Language.Msg("该单据号不存在或不需核准 请查证后重新输入"));
                    this.txtPID.Focus();
                    return -1;
                }

                #endregion

                Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipeTemp = al[0] as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                string strMsg = "";
                switch (drugRecipeTemp.RecipeState)
                {
                    case "0":
                        strMsg = "该单据尚未打印标签";
                        break;
                    case "1":
                        strMsg = "该单据已打印标签 尚未做配药确认";
                        break;
                    case "2":
                        strMsg = "该单据已配药确认 尚未做发药确认";
                        break;
                    case "3":
                        strMsg = "该单据已进行过发药";
                        break;
                }

                MessageBox.Show(strMsg);

                #region 根据检索出的数据状态进行拆分 加入不同状态数组 中(根据病例号检索才存在此问题)

                ArrayList alAdd = new ArrayList();
                ArrayList alOper = new ArrayList();
                ArrayList alNext = new ArrayList();

                foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe tempInfo in al)
                {
                    if (this.AddTree != null && this.AddTree.State == tempInfo.RecipeState)
                    {
                        alAdd.Add(tempInfo);
                        continue;
                    }
                    if (this.OperTree != null && this.OperTree.State == tempInfo.RecipeState)
                    {
                        alOper.Add(tempInfo);
                        continue;
                    }
                    if (this.NextTree != null && this.NextTree.State == tempInfo.RecipeState)
                    {
                        alNext.Add(tempInfo);
                        continue;
                    }
                }

                #endregion

                bool isOperActive = true;

                if (this.NextTree != null && alNext.Count > 0)
                {
                    this.NextTree.ShowList(alNext, true);
                    //this.neuTabControl1.SelectedTab = this.NextTree.ParentTab;
                    isOperActive = false;
                }

                //是否在AddTree内添加数据 对未打印标签进行打印处理并添加节点
                if (this.isFindToAdd) 
                {
                    if (this.AddTree != null && alAdd.Count > 0)
                    {
                        if (this.AddTree.State == "0")          //未打印标签 更新打印标记
                        {
                            foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe in alAdd)
                            {
                                int parm = this.drugStoreManager.UpdateDrugRecipeState(this.OperDept.ID, drugRecipe.RecipeNO, "M1", "0", "1");
                                if (parm == -1)
                                {
                                    MessageBox.Show(Language.Msg("更新摆药单明细 未打印状态为已打印状态失败!") + this.drugStoreManager.Err);
                                    return -1;
                                }
                            }
                        }
                        //对于此种情况下下添加时 由于已直接更新了状态 不能添加到AddTree内
                        this.OperTree.ShowList(alAdd, true);

                        //this.neuTabControl1.SelectedTab = this.OperTree.ParentTab;  
                        isOperActive = true;
                    }
                }                        

                if (this.OperTree != null && alOper.Count > 0)
                {
                    this.OperTree.ShowList(alOper, true);
                    //this.neuTabControl1.SelectedTab = this.OperTree.ParentTab;
                    isOperActive = true;
                }
                //已添加了数据  设置焦点TabPage
                if (alAdd.Count > 0 || alOper.Count > 0 || alNext.Count > 0)
                {
                    if (isOperActive)
                    {
                        this.neuTabControl1.SelectedTab = this.OperTree.ParentTab;
                    }
                    else
                    {
                        this.neuTabControl1.SelectedTab = this.NextTree.ParentTab;
                    }
                }

                return 0;

                #endregion
            }

            return 1;
        }

        /// <summary>
        /// 由树内获取节点
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        private bool FindNodeInTree(string queryStr, DrugStore.Outpatient.tvClinicTree findTree)
        {
            if (findTree.Nodes.Count > 0)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe temp;
                foreach (TreeNode node in findTree.Nodes)
                {
                    temp = node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                    if (this.GetBillFromDrugeRecipe(temp) == queryStr)
                    {
                        findTree.SelectedNode = node;

                        if (findTree.Parent != null)
                        {
                            if ((findTree.Parent as System.Windows.Forms.TabPage) != null)
                            {
                                this.neuTabControl1.SelectedTab = findTree.Parent as System.Windows.Forms.TabPage;
                            }
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 选择下一个节点
        /// </summary>
        private void SelectNext(bool isDown)
        {
            if (this.OperTree != null && this.OperTree.ParentTab == this.neuTabControl1.SelectedTab)
                this.OperTree.SelectNext(isDown);
            else if (this.NextTree != null && this.NextTree.ParentTab == this.neuTabControl1.SelectedTab)
                this.NextTree.SelectNext(isDown);
            else if (this.AddTree != null && this.AddTree.ParentTab == this.neuTabControl1.SelectedTab)
                this.AddTree.SelectNext(isDown);

            this.txtPID.SelectAll();
        }

        #endregion

        /// <summary>
        /// 设置单据检索模式
        /// </summary>
        /// <param name="billType"></param>
        public virtual void SetQueryBillType(OutpatientBillType billType)
        {
            this.nowBillType = billType;

            this.lbnBillType.Text = this.nowBillType.ToString();
        }

        /// <summary>
        /// 检索列表显示 多线程自动刷新时调用
        /// </summary>
        public virtual void ShowList()
        {
            ArrayList al = new ArrayList();
            al = this.drugStoreManager.QueryList(this.OperDept.ID, this.terminal.ID, this.funType, this.AddTree.State, this.minQueryDate);
            string strMsg = "";
            if (al == null)
                strMsg = "此次刷新发生错误...." + this.drugStoreManager.Err;
            else
                strMsg = "获取" + al.Count + "条数据，等待下次刷新....";
            if (this.ProcessMessageEvent != null)
                this.ProcessMessageEvent("ShowList", strMsg);

            if (al.Count == 0)
            {
                return;
            }

            if (this.AddTree.State == "0")
            {
                this.AddTree.ShowList(al, false);
            }
            else
            {   //{DBB3C382-BB23-463b-8847-2F73C55F2586} 增加自动发药           
                if (this.funModle == OutpatientFun.Send && isAutoSend)      //采用自动发药模式
                {
                    this.AutoSave(al);                  //实现自动保存

                    this.tvSend.ShowList(al, true);     //节点直接更新到已发药树上面
                }
                else
                {
                    this.AddTree.ShowList(al, true);    //正常处理
                }
                //{DBB3C382-BB23-463b-8847-2F73C55F2586}
            }

            //设置下次查询时间
            this.GetMinDrugedDate(al);

            if (this.funModle == OutpatientFun.Drug || this.funModle == OutpatientFun.DirectSend)
            {
                this.AutoPrint();
            }

            this.SetFocus();
        }

        /// <summary>
        /// 自动保存
        /// 
        /// {DBB3C382-BB23-463b-8847-2F73C55F2586}
        /// </summary>
        /// <returns></returns>
        protected int AutoSave(ArrayList alRecipe)
        {
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe info in alRecipe)
            {
                #region 完成发药处理

                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                ArrayList al = itemManager.QueryApplyOutListForClinic(this.OperDept.ID, "M1", "1", info.RecipeNO);
                if (al == null)
                {
                    if (this.ProcessMessageEvent != null)
                    {
                        this.ProcessMessageEvent(null, "根据调剂信息获取申请明细信息发生错误" + itemManager.Err);
                    }
                    return -1;
                }

                if (al.Count == 0)
                {
                    if (this.ProcessMessageEvent != null)
                    {
                        this.ProcessMessageEvent(null, "根据调剂信息未获取到明细申请信息");
                    }
                    return 0;
                }
                List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> applyData = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();

                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut tempApply in al)
                {
                    applyData.Add(tempApply);
                }

                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in applyData)
                {
                    applyOut.Operation.ApproveOper.Dept = this.ApproveDept;
                }

                if (Function.OutpatientSend(applyData, this.terminal, this.ApproveDept, this.OperInfo, false, !this.isAdjustInDrug) == -1)
                {
                    if (this.ProcessMessageEvent != null)
                    {
                        this.ProcessMessageEvent(null, string.Format("对{0}({1})的处方进行自动发药发生错误", info.PatientName, info.RecipeNO));
                    }
                }

                if (this.ProcessMessageEvent != null)
                {
                    this.ProcessMessageEvent(null, string.Format("对{0}({1})的处方已完成自动发药", info.PatientName, info.RecipeNO));
                }

                #endregion

                #region 更新处方调剂数据状态

                info.RecipeState = "3";
                info.SendOper.ID = this.OperInfo.ID;
                info.SendOper.Name = this.OperInfo.Name;

                #endregion
            }

            return 1;

        }

        /// <summary>
        /// 列表初始化/刷新显示
        /// </summary>
        /// <param name="isInitRefreshDate">是否将检索时间重新初始化(设置为当天日期零点)</param>
        public virtual void RefreshOperList(bool isInitRefreshDate)
        {
            if (isInitRefreshDate)
            {
                this.minQueryDate = this.sysDate.Date;

                if (this.isShowOldInfo)
                {
                    this.minQueryDate = new DateTime(2000, 1, 1, 10, 0, 0);
                }

            }

            //根据收费时间检索
            ArrayList al = new ArrayList();
            al = this.drugStoreManager.QueryList(this.OperDept.ID, this.terminal.ID, this.funType, this.OperTree.State, this.minQueryDate);
            if (al != null)
            {
                this.OperTree.ShowList(al, false);
            }

            //设置下次查询时间
            this.GetMinDrugedDate(al);

            if (this.funModle == OutpatientFun.Send || this.funModle == OutpatientFun.DirectSend)
            {
                al = this.drugStoreManager.QueryList(this.OperDept.ID, this.terminal.ID, this.funType, this.NextTree.State, this.sysDate.Date);
                if (al != null)
                {
                    this.NextTree.ShowList(al, false);
                }
            }
        }

        /// <summary>
        /// 获取传入的处方调剂数组内最大配药时间
        /// </summary>
        /// <param name="drugRecipeAl">处方调剂数组</param>
        private void GetMinDrugedDate(ArrayList drugRecipeAl)
        {
            if (this.funModle == OutpatientFun.Drug || this.funModle == OutpatientFun.Back || this.funModle == OutpatientFun.DirectSend)
                return;

            if (drugRecipeAl.Count > 0)
            {
                this.minQueryDate = System.DateTime.MinValue;
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe info in drugRecipeAl)
                {
                    if (info.DrugedOper.OperTime > this.minQueryDate)
                    {
                        this.minQueryDate = info.DrugedOper.OperTime;
                    }
                }
            }

            //设置界面最新配药时间显示
            this.lbFeeDate.Text = this.minQueryDate.ToString("HH:mm");

            //在最后时间上增加一秒 Sql语句内使用的大于等于
            this.minQueryDate = this.minQueryDate.AddSeconds(1);
        }

        /// <summary>
        /// 根据其中一个发票号获取所有兄弟发票号
        /// </summary>
        /// <param name="invoiceNo">发票号</param>
        /// <returns>成功返回所有兄弟发票号连接串 以,分割</returns>
        private string GetInvoiceList(string invoiceNo)
        {
            string strInvoiceList = "";
            //Neusoft.HISFC.BizLogic.Fee.Outpatient feeOutPatient = new Neusoft.HISFC.BizLogic.Fee.OutPatient();
            //ArrayList alInvoice = feeOutPatient.GetBrotherInvo(invoiceNo);
            //if (alInvoice == null)
            //{
            //    MessageBox.Show(Language.Msg("根据主发票号查找所有兄弟发票出错") + feeOutPatient.Err);
            //    return null;
            //}
            //foreach (Neusoft.HISFC.Models.Fee.OutPatient.Invoice info in alInvoice)
            //{
            //    strInvoiceList = strInvoiceList + info.ID + "','";
            //}
            //if (strInvoiceList.Length > 3)
            //    strInvoiceList = strInvoiceList.Substring(0, strInvoiceList.Length - 3);
            return strInvoiceList;
        }

        /// <summary>
        /// 根据所选择的单据类型 返回实体内的对应信息
        /// </summary>
        /// <param name="info">处方调剂实体</param>
        /// <returns>成功返回对应的处方实体内信息</returns>
        private string GetBillFromDrugeRecipe(Neusoft.HISFC.Models.Pharmacy.DrugRecipe info)
        {
            switch (this.nowBillType)
            {
                case OutpatientBillType.处方号:						//处方号
                    return info.RecipeNO;
                case OutpatientBillType.发票号:						//发票号
                    return info.InvoiceNO;
                default:					                        //病历卡号
                    return info.CardNO;
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            if (this.AddTree != null)
                this.AddTree.Nodes.Clear();
            if (this.NextTree != null)
                this.NextTree.Nodes.Clear();
            if (this.OperTree != null)
                this.OperTree.Nodes.Clear();
        }

        /// <summary>
        /// 根据操作员编码判断该操作员是否有本终端操作权限
        /// 不允许其他药房的人给本药房发药
        /// </summary>
        /// <param name="person">需判断人员信息</param>
        /// <returns>存在权限返回True 否则返回False</returns>
        public bool JudgePriv(Neusoft.HISFC.Models.Base.Employee person)
        {
            if (!this.isJudgePriv)
                return true;
            if (person.EmployeeType.ID.ToString() == Neusoft.HISFC.Models.Base.EnumEmployeeType.P.ToString())
                return true;
            return false;
        }

        /// <summary>
        /// 是否存在剩余未操作节点
        /// </summary>
        /// <returns></returns>
        public bool SpareNode()
        {
            if (this.AddTree == null || this.NextTree == null)
                return false;

            if (this.AddTree.Nodes.Count > 0 || this.NextTree.Nodes.Count > 0)
                return true;
            else
                return false;
        }

        #region 标签打印 / 自动打印 

        /// <summary>
        /// 标签打印 打印当前选中节点标签
        /// </summary>
        public virtual void Print()
        {
            if (Function.IDrugPrint == null)
            {
                return;
            }

            if (this.OperTree != null && this.neuTabControl1.SelectedTab == this.OperTree.ParentTab)            
            {
                if (this.OperTree.SelectedNode != null)
                {
                    this.Print(this.OperTree,this.OperTree.SelectedNode);

                    return;
                }
            }
            if (this.NextTree != null && this.neuTabControl1.SelectedTab == this.NextTree.ParentTab)
            {
                if (this.NextTree.SelectedNode != null)
                {
                    this.Print(this.NextTree, this.NextTree.SelectedNode);

                    return;
                }
            }
            if (this.AddTree != null && this.neuTabControl1.SelectedTab == this.AddTree.ParentTab)
            {
                if (this.AddTree.SelectedNode != null)                
                {
                    this.Print(this.AddTree, this.AddTree.SelectedNode);

                    return;
                }
            }
        }

        /// <summary>
        /// 是否正在打印 用于对于多线程判断
        /// </summary>
        private static bool isBusyPrint = false;

        /// <summary>
        /// 是否正在保存  用于对多线程判断
        /// </summary>
        private bool isBusy = false;

        /// <summary>
        /// 自动打印时调用
        /// </summary>
        protected virtual int AutoPrint()
        {
            if (isBusyPrint)
            {
                return 1;
            }

            isBusyPrint = true;

            if (this.tvPrinting.Nodes.Count <= 0)
            {
                isBusyPrint = false;
                return -1;
            }

            if (this.changeNode == null)
            {
                changeNode = new ChangePrintNodeHandler(this.TransferNode);
            }

            try
            {
                for (int i = this.tvPrinting.Nodes.Count - 1; i >= 0; i--)
                {
                    if (this.isBusySave)
                    {
                        return 1;
                    }

                    if (this.IsAutoPrint)
                    {
                        if (this.Print(this.tvPrinting, this.tvPrinting.Nodes[i]) != 1)
                            return -1;
                    }
                    else
                    {
                        Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = this.tvPrinting.Nodes[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                        int parm = this.drugStoreManager.UpdateDrugRecipeState(this.OperDept.ID, info.RecipeNO, "M1", "0", "1");
                        if (parm == -1)
                        {
                            MessageBox.Show(Language.Msg("更新摆药单明细 未打印状态为已打印状态失败!") + this.drugStoreManager.Err);
                            return -1;
                        }
                    }

                    //改变结点位置
                    if (this.ParentForm != null)
                    {
                        if (this.funModle == OutpatientFun.DirectSend)
                            this.ParentForm.Invoke(changeNode, new object[] { this.tvPrinting.Nodes[i],false });
                        else
                            this.ParentForm.Invoke(changeNode, new object[] { this.tvPrinting.Nodes[i], true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isBusyPrint = false;
            }

            return 1;
        }

        /// <summary>
        /// 打印当前指定节点数据
        /// </summary>
        /// <param name="printNode">需打印节点</param>
        private int Print(Neusoft.HISFC.Components.DrugStore.Outpatient.tvClinicTree parentTree,TreeNode printNode)
        {
            ArrayList alValidate = new ArrayList();
            //由于节点转移时 没有对节点Tag内实体状态进行修改 所以此处不能使用Info.state 代替 状态参数
            Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = printNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
            string detailState = "0";
            if (parentTree.State == "0" || parentTree.State == "1")
            {
                detailState = "0";
            }
            else if (parentTree.State == "2")
            {
                detailState = "1";
            }
            else
            {
                detailState = "2";
            }

            ArrayList alInfo = this.itemManager.QueryApplyOutListForClinic(this.OperDept.ID, "M1",detailState, info.RecipeNO);
            if (alInfo == null)
            {
                MessageBox.Show(Language.Msg("打印摆药单 获取待摆药明细出错!") + itemManager.Err);
                return -1;
            }
            //只取有效记录
            bool isAllValid = true;
            alValidate = new ArrayList();
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp in alInfo)
            {
                if (applyOutTemp.ValidState != Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                    alValidate.Add(applyOutTemp);
                else
                    isAllValid = false;
            }

            //如果退改药标记 则不进行打印
            isAllValid = !info.IsModify;

            //如打印作废记录 或 所有记录全部有效 则执行打印
            if (this.isPrintCancelRecipe || isAllValid)
            {
                if (this.Print(info,alValidate) == -1)
                {
                    return -1;
                }
            }

            //更新打印标记  //对状态为0的数据更新打印标记
            if (info.RecipeState == "0")
            {
                int parm = this.drugStoreManager.UpdateDrugRecipeState(this.OperDept.ID, info.RecipeNO, "M1", "0", "1");
                if (parm == -1)
                {
                    MessageBox.Show(Language.Msg("更新摆药单明细 未打印状态为已打印状态失败!") + this.drugStoreManager.Err);
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 执行打印
        /// </summary>
        /// <param name="al">打印数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal int Print(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe, ArrayList al)
        {
            //一次只打印一个处方号的
            //传入的时候按照组合号、院注标记分组 便于打印
            //applyOut.User01 发药窗口号 applyOut.User02 院注次数

            if (al.Count <= 0)
            {
                return 1;
            }

            if (Function.IDrugPrint == null)
            {
                return 0;
            }

            //{23E209BB-B4EB-4676-851A-DA053F0D51FD}  终端窗口赋值
            if (string.IsNullOrEmpty(this.terminal.SendWindow.Name) == true)
            {
                if (this.hsTerminalDictionary.ContainsKey(this.terminal.SendWindow.ID))
                {
                    this.terminal.SendWindow.Name = this.hsTerminalDictionary[this.terminal.SendWindow.ID].ToString();
                }
            }

            Neusoft.HISFC.Models.Registration.Register patientInfo = null;		//患者信息

            #region 患者信息获取

            //获取患者信息
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            patientInfo = regManager.GetByClinic(drugRecipe.ClinicNO);

            patientInfo.InvoiceNO = drugRecipe.InvoiceNO;

            #endregion

            #region 中药房草药、成药打印
            if (this.isHerbalPrint)
            {
                patientInfo.User01 = drugRecipe.FeeOper.OperTime.ToString();

                patientInfo.DoctorInfo.Templet.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);
                //{EC943D35-7C5C-4e98-97F9-10AD1B70D0E2}  增加对发药窗口号的赋值               
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut temp in al)
                {
                    temp.SendWindow = this.terminal.SendWindow.Name;
                }

                Function.IDrugPrint.OutpatientInfo = patientInfo;

                Function.IDrugPrint.AddAllData(al);
                Function.IDrugPrint.Print();

                return 1;
            }
            #endregion

            #region 获取标签总页数
            string privCombo = "";												//上次医嘱组合号
            int iRecipeTotNum = 0;												//本次需打印标签总页数
            string recipeNo = "";		//处方号
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut temp in al)
            {
                temp.SendWindow = this.terminal.SendWindow.Name;
                if (privCombo == temp.CombNO && temp.CombNO != "")
                {
                    continue;
                }
                else
                {
                    iRecipeTotNum = iRecipeTotNum + 1;
                    privCombo = temp.CombNO;
                }

                recipeNo = temp.RecipeNO;
            }
            #endregion

            Function.IDrugPrint.LabelTotNum = iRecipeTotNum;
            Function.IDrugPrint.DrugTotNum = al.Count;
            if (patientInfo != null)
            {
                patientInfo.User02 = al.Count.ToString();
                patientInfo.User01 = drugRecipe.FeeOper.OperTime.ToString();

                patientInfo.DoctorInfo.Templet.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);

                patientInfo.User03 = drugRecipe.RecipeNO;
                
                Function.IDrugPrint.OutpatientInfo = patientInfo;
            }

            privCombo = "-1";
            ArrayList alCombo = new ArrayList();

            if (!this.isAllSend)
            {
                #region 标签打印
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
                {
                    info.SendWindow = this.terminal.SendWindow.Name;
                    if (privCombo == "-1" || (privCombo == info.CombNO && info.CombNO != ""))
                    {
                        alCombo.Add(info);
                        privCombo = info.CombNO;
                        continue;
                    }
                    else			//不同处方号
                    {
                        if (alCombo.Count == 1)
                            Function.IDrugPrint.AddSingle(alCombo[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                        else
                            Function.IDrugPrint.AddCombo(alCombo);
                        Function.IDrugPrint.Print();

                        privCombo = info.CombNO;
                        alCombo = new ArrayList();

                        alCombo.Add(info);
                    }
                }
                if (alCombo.Count == 0)
                {
                    return 1;
                }
                if (alCombo.Count > 1)
                {
                    Function.IDrugPrint.AddCombo(alCombo);
                }
                else
                {
                    Function.IDrugPrint.AddSingle(alCombo[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                }

                Function.IDrugPrint.Print();

                #endregion
            }
            else
            {
                Function.IDrugPrint.AddAllData(al);
                Function.IDrugPrint.Print();
            }           

            return 1;
        }

        #endregion

        #region 多线程刷新 以后考虑更改为消息方式处理

        private System.Threading.Timer processRefreshTimer = null;
        private System.Threading.TimerCallback processRefreshCallBack = null;
        private delegate void ShowListDelegate();

        /// <summary>
        /// 大屏幕显示刷新
        /// </summary>
        private System.Timers.Timer ledRefreshTimer = null;
    
        /// <summary>
        /// 程序刷新间隔
        /// </summary>
        private int processRefreshInterval = 3;

        /// <summary>
        /// LED大屏幕显示刷新间隔
        /// </summary>
        private int ledRefreshInterval = 55;

        private ShowListDelegate refreshFun = null;

        /// <summary>
        /// 多线程刷新
        /// </summary>
        /// <param name="parm"></param>
        private void AutoRefresh(object parm)
        {
            if (this.isBusy)
            {
                if (this.ProcessMessageEvent != null)
                    this.ProcessMessageEvent(this, "正在进行保存操作..不进行刷新");
                return;
            }
            if (this.refreshFun == null)
                this.refreshFun = new ShowListDelegate(this.ShowList);
            this.isBusy = true;

            if (this.ParentForm != null)
                this.ParentForm.Invoke(this.refreshFun);

            this.isBusy = false;
        }

        /// <summary>
        /// 开始刷新 程序刷新
        /// </summary>
        public virtual void BeginProcessRefresh(int dueTime)
        {
            if (this.processRefreshCallBack == null)
                this.processRefreshCallBack = new System.Threading.TimerCallback(this.AutoRefresh);
            this.processRefreshTimer = new System.Threading.Timer(this.processRefreshCallBack, null, dueTime, this.processRefreshInterval * 1000);
        }

        /// <summary>
        /// 开始刷新(程序刷新)
        /// </summary>
        /// <param name="dueTime"></param>
        public virtual new void BeginRefresh(int dueTime)
        {
            this.BeginProcessRefresh(dueTime);
        }

        /// <summary>
        /// 停止刷新 程序刷新
        /// </summary>
        public virtual void EndProcessRefresh()
        {
            if (this.processRefreshTimer != null)
                this.processRefreshTimer.Dispose();
        }

        /// <summary>
        /// 停止刷新(程序刷新)
        /// </summary>
        public virtual new void EndRefresh()
        {
            this.EndProcessRefresh();
        }

        #region 处理LED屏幕显示

        /// <summary>
        /// 大屏幕信息显示
        /// </summary>
        public void WriteSendMessage()
        {
            if (this.isBusy)
            {
                if (this.ProcessMessageEvent != null)
                    this.ProcessMessageEvent(this, "正在进行保存操作..不进行刷新");
                return;
            }

            this.isBusy = true;

            List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe> alDrugRecipe = new List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe>();
            DateTime maxFeeDate = System.DateTime.MinValue;
            Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = new Neusoft.HISFC.Models.Pharmacy.DrugRecipe();
            for (int i = this.tvDruged.Nodes.Count - 1; i >= 0; i--)
            {
                info = this.tvDruged.Nodes[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                if (i == this.tvDruged.Nodes.Count)         //取最后一个节点的收费时间 此时就是最新的配药
                    maxFeeDate = info.FeeOper.OperTime;

                alDrugRecipe.Add(info);
            }

            //this.lbFeeDate.Text = maxFeeDate.ToString("HH:mm");

            if (this.LEDShowInterface != null)
            {               
                this.LEDShowInterface.SetShowData(alDrugRecipe);
                this.LEDShowInterface.Show();
            }

            this.isBusy = false;
        }

        #endregion

        /// <summary>
        /// 开始刷新 LED大屏幕显示刷新
        /// </summary>
        /// <param name="isExeAtOnce">是否立即执行</param>
        public virtual void BeginLEDRefresh(bool isExeAtOnce)
        {            
            if (isExeAtOnce)
            {
                this.WriteSendMessage();
            }

            this.ledRefreshTimer = new System.Timers.Timer(this.ledRefreshInterval * 1000);
            this.ledRefreshTimer.Elapsed -= new System.Timers.ElapsedEventHandler(ledRefreshTimer_Elapsed);
            this.ledRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(ledRefreshTimer_Elapsed);
            this.ledRefreshTimer.Start();
        }

        private void ledRefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.WriteSendMessage();
        }

        /// <summary>
        /// 停止刷新 LED大屏幕停止刷新
        /// </summary>
        public virtual void EndLEDRefresh()
        {
            if (this.ledRefreshTimer != null)
                this.ledRefreshTimer.Dispose();
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //初始化改为由外部窗口调用
                //if (!this.DesignMode)
                //{
                //    this.Init();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            base.OnLoad(e);
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                this.nowDrugRecipe = e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                if (this.nowDrugRecipe == null)
                    return;

                //兼容物理卡号检索门诊待配发药处方by Sunjh 2010-11-23 {60523334-715A-419c-925B-34E7E13E2606}
                if (this.nowBillType == OutpatientBillType.病例卡号 && this.isSearchByMarkNo)
                {
                    this.txtBillNO.Text = "";
                }
                else
                {
                    this.txtBillNO.Text = this.GetBillFromDrugeRecipe(this.nowDrugRecipe);
                }
                //this.txtBillNO.Text = this.GetBillFromDrugeRecipe(this.nowDrugRecipe);

                if (this.MyTreeSelectEvent != null)
                    this.MyTreeSelectEvent(this.nowDrugRecipe);
            }
        }

        private void txtPID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                this.SelectNext(true);
                e.Handled = true;
            }
            if (e.KeyData == Keys.Up)
            {
                this.SelectNext(false);
                e.Handled = true;
            }
        }


        private void txtPID_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.txtPID.Text.Length >= 7)
                {
                    #region 当前输入的为处方号

                    this.txtBillNO.Text = this.txtPID.Text;

                    if (this.FindNode() != 1)
                    {
                        if (this.privOperID != "")
                        {
                            this.txtPID.Text = this.privOperID;
                        }

                        return;
                    }

                    if (this.privOperID != "")
                    {
                        this.txtPID.Text = this.privOperID;
                    }
                    this.txtPID.SelectAll();
                    this.txtPID.Focus();
                    return;

                    #endregion
                }
                else
                {
                    #region 员工号检索确认

                    if (this.PIDFillNum != -1)
                    {
                        this.txtPID.Text = this.txtPID.Text.PadLeft(this.PIDFillNum, '0');
                    }
                    Neusoft.FrameWork.Models.NeuObject person = this.personHelper.GetObjectFromID(this.txtPID.Text);
                    if (person == null || person.ID == "")
                    {
                        MessageBox.Show(Language.Msg("错误的员工代码 请重新输入"));

                        this.txtPID.SelectAll();
                        this.txtPID.Focus();
                        return;
                    }
                    else
                    {
                        if (this.JudgePriv(person as Neusoft.HISFC.Models.Base.Employee))
                        {
                            this.operName.Text = person.Name;

                            this.isBusy = true;

                            if (this.OperChangedEvent != null)
                            {
                                this.OperChangedEvent(person);
                            }

                            if (this.SaveRecipeEvent != null)
                            {
                                this.SaveRecipeEvent(person, System.EventArgs.Empty);
                            }

                            this.isBusy = false;

                            this.privOperID = person.ID;

                            this.txtPID.SelectAll();
                            this.txtPID.Focus();
                        }
                        else
                        {
                            this.OperInfo = null;
                            MessageBox.Show(Language.Msg("该操作员无操作权限 请与管理员联系设置终端"));

                            if (this.OperChangedEvent != null)
                            {
                                this.OperChangedEvent(this.OperInfo);
                            }

                            this.txtPID.Focus();
                            return;
                        }
                    }

                    #endregion
                }        
            }
        }

        private void lbnBillType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int iBillIndex = 0;
            System.Math.DivRem(this.nowBillType.GetHashCode() + 1, 3, out iBillIndex);
            this.nowBillType = (OutpatientBillType)iBillIndex;

            this.lbnBillType.Text = this.nowBillType.ToString();
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Controls.NeuTreeView selectTv = null;
            if (this.neuTabControl1.SelectedTab == null || this.neuTabControl1.SelectedTab.Controls.Count <= 0)
            {
                return;
            }
            selectTv = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Controls.NeuTreeView;
            if (selectTv != null)
            {
                if (selectTv.Nodes.Count <= 0)
                {
                    return;
                }
                else
                {
                    selectTv.SelectedNode = selectTv.Nodes[selectTv.Nodes.Count - 1];
                }

                this.nowDrugRecipe = selectTv.SelectedNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                if (this.nowDrugRecipe == null)
                {
                    return;
                }

                this.txtBillNO.Text = this.GetBillFromDrugeRecipe(this.nowDrugRecipe);

                if (this.MyTreeSelectEvent != null)
                {
                    this.MyTreeSelectEvent(this.nowDrugRecipe);
                }
            }
        }

        private void txtBillNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.FindNode() != 1)
                {
                    return;
                }
            }
        }

        #region {5A6BABAB-F7E1-4c49-9123-E4B838CC766F} 药房读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.txtBillNO.Text = cardno;
                    this.FindNodeReadCard();
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }

        /// <summary>
        /// 查找满足条件的节点
        /// 读卡用
        /// </summary>
        public virtual int FindNodeReadCard()
        {
            this.txtBillNO.Text = this.txtBillNO.Text.PadLeft(10, '0');
            //switch (this.nowBillType)
            //{
            //    case OutpatientBillType.发票号:
            //        this.txtBillNO.Text = this.txtBillNO.Text.PadLeft(12, '0');
            //        break;
            //    case OutpatientBillType.病例卡号:
            //        this.txtBillNO.Text = this.txtBillNO.Text.PadLeft(10, '0');
            //        break;
            //    default:
            //        this.txtBillNO.Text = this.txtBillNO.Text;
            //        break;
            //}
            string strQueryData = this.txtBillNO.Text;

            if (this.nowBillType == OutpatientBillType.病例卡号 && this.isSearchByMarkNo)
            {
                Neusoft.HISFC.Models.Account.AccountCard acObj = new Neusoft.HISFC.Models.Account.AccountCard();
                if (this.feeIntegrate.ValidMarkNO(strQueryData, ref acObj) != -1)
                {
                    if (acObj != null)
                    {
                        strQueryData = acObj.MarkNO;
                    }
                    else
                    {
                        strQueryData = "";
                    }
                }
            }

            if (this.nowBillType == OutpatientBillType.发票号)
            {
                strQueryData = this.GetInvoiceList(strQueryData);
                if (strQueryData == null)
                {
                    return -1;
                }
                if (strQueryData == "")
                {
                    strQueryData = this.txtBillNO.Text;
                }
            }

            return this.FindNode(strQueryData);
        }
        #endregion

    }
}
