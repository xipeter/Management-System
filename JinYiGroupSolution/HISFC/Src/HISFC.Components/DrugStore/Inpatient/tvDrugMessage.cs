using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 摆药通知组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明>
    ///     1、药柜管理说明 
    ///         如果选择摆药台显示方式为科室汇总 那么就不能实现药柜只看到本药柜药品的功能
    ///         列表看到的为所有的摆药单，确认的时候 直接对所有药品进行了确认发送。
    ///         如果是药柜管理，那么显示方式只能为科室明细或患者明细
    ///     2、库存明细检索时
    ///         只检索非药柜管理的药品  则对于药柜来说 可以检索出全部库存药品
    ///                                 对于非药柜来说 可以检索出非药柜管理库存药品
    ///         保证不重复
    /// {41EEF22D-1ADE-446d-9C9F-37E591795607}   修改了单据列表显示方式
    /// </说明>
    /// <修改记录>
    ///    1.兼容住院集中发药相关 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
    /// </修改记录>
    /// </summary>
    public partial class tvDrugMessage : Common.Controls.baseTreeView
    {
        public tvDrugMessage()
        {
            InitializeComponent();

            //if (!this.DesignMode)
            //    this.Init();
        }

        public tvDrugMessage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //if (!this.DesignMode)
            //    this.Init();
        }

        public delegate void SelectDataHandler(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage, ArrayList alData,bool isShowDetail);

        public delegate void ReLoadDrugBillHandler(ArrayList alBill);

        public event ReLoadDrugBillHandler ReLoadDrugBillEvent;

        public event SelectDataHandler SelectDataEvent;

        #region 域变量

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        private bool isAutoPrint = false;

        /// <summary>
        /// 摆药单格式是否打印标签
        /// </summary>
        private bool isPrintLabel = false;

        /// <summary>
        /// 显示时是否按照科室优先显示
        /// </summary>
        private bool isDeptFirst = true;

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 控制参数管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 药房管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 科室帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 当前系统时间
        /// </summary>
        private DateTime sysDate = System.DateTime.MinValue;

        /// <summary>
        /// 已经打印过的患者数据
        /// </summary>
        private static System.Collections.Hashtable hsPrint = null;

        /// <summary>
        /// 当前操作的配药台实体
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl = new DrugControl();

        /// <summary>
        /// 库存信息
        /// </summary>
        private System.Collections.Hashtable hsStockData = null;

        /// <summary>
        /// 库存信息 只显示本科室有库存的申请信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject stockMark = null;

        /// <summary>
        /// 核准科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveDept = null;

        /// <summary>
        /// 是否打印单据的同时完成配药操作
        /// </summary>
        private bool isPrintAndOutput = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否打印标签
        /// </summary>
        [Description("打印时是否打印标签"), Category("设置"), DefaultValue(false)]
        public bool IsPrintLabel
        {
            get
            {
                return this.isPrintLabel;
            }
            set
            {
                this.isPrintLabel = value;
            }
        }

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        [Description("是否自动打印摆药单"), Category("设置"), DefaultValue(false)]
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

        /// <summary>
        /// 显示时是否按照科室优先显示
        /// </summary>
        [Description("摆药单列表显示时 是否按照科室优先显示 该参数影响摆药通知的显示"), Category("设置"), DefaultValue(true)]
        public bool IsDeptFirst
        {
            get
            {
                return this.isDeptFirst;
            }
            set
            {
                this.isDeptFirst = value;
            }
        }

        /// <summary>
        /// 已经打印过的患者数据
        /// </summary>
        public static System.Collections.Hashtable HsPrintData
        {
            get
            {
                return tvDrugMessage.hsPrint;
            }
            set
            {
                tvDrugMessage.hsPrint = value;
            }
        }

        /// <summary>
        /// 当前操作的配药台实体
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.DrugControl OperDrugControl
        {
            set
            {
                this.drugControl = value;
            }
        }

        /// <summary>
        /// 库存信息 只显示本科室有库存的申请信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject StockMarkDept
        {
            get
            {
                return this.stockMark;
            }
            set
            {
                this.stockMark = value;

                this.hsStockData = null;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            try
            {
                this.ImageList = this.deptImageList;

                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptmentAll();
                if (alDept == null)
                {
                    MessageBox.Show("加载科室列表发生错误" + deptManager.Err);
                }

                objHelper.ArrayObject = alDept;

                this.sysDate = deptManager.GetDateTimeFromSysDateTime().Date;

                this.InitControlParam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("树型通知列表初始化发生错误" + ex.Message);
            }
        }

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsDeptFirst = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Show_DeptFirst, true, true);

            //屏蔽作废参数设置信息
            //this.isPrintAndOutput = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_AutoPrint_Output, true, false);
        }

        /// <summary>
        /// 设置树节点展开状态
        /// </summary>
        /// <param name="expandLevel">展开节点层次 0 1</param>
        /// <param name="expandAllNode">是否对全部节点展开 否则 只展开第一个节点</param>
        public void SetExpand(int expandLevel,bool expandAllNode)
        {
            if (expandAllNode)
            {
                this.ExpandAll();
                return;
            }

            if (this.Nodes.Count <= 0)
                return;

            switch (expandLevel)
            {
                case 0:
                    this.Nodes[0].Expand();
                    break;
                case 1:
                    if (this.Nodes[0].Nodes.Count > 0)
                        this.Nodes[0].Nodes[0].Expand();
                    break;
            }            
        }

        /// <summary>
        /// 根据配药台实体 检索发送到本配药台的单据
        /// </summary>
        /// <param name="drugControl">摆药台</param>
        public virtual void ShowList(Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl)
        {
            ArrayList al = this.drugStoreManager.QueryDrugMessageList(drugControl);

            if (al == null)
            {
                MessageBox.Show(Language.Msg("根据配药台检索发送到本台的单据列表失败") + this.drugStoreManager.Err);
            }

            if (drugControl.ShowLevel == 3)
            {
                this.ShowListForInpatientFirst(al);
            }
            else
            {
                this.ShowList(al, drugControl.ShowLevel);
            }
        }

        /// <summary>
        /// 根据传入的摆药通知数组，显示在tvDrugMessage中
        /// 传入参数数组是按照科室、摆药单类型、发送时间（倒序）排序的
        /// </summary>
        /// <param name="alDrugMessage">摆药通知数组</param>
        /// <param name="showLevel">显示等级</param>
        protected virtual void ShowList(ArrayList alDrugMessage, int showLevel)
        {
            //if (!this.isListAddType)
            this.Nodes.Clear();

            string privBillCode = "";
            string privDeptCode = "";				//上一个科室
            Neusoft.HISFC.Models.Pharmacy.DrugMessage privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
            DrugMessageTreeNode nodePatient;
            DrugMessageTreeNode nodeDept = new DrugMessageTreeNode();
            DrugMessageTreeNode nodeBill = new DrugMessageTreeNode();

            foreach (DrugMessage info in alDrugMessage)
            {

                #region 每次将节点清空重新添加

                this.SuspendLayout();

                if (this.isDeptFirst)
                {
                    #region 只显示至科室节点
                    if (info.ApplyDept.ID != privDeptCode)		//添加新的科室节点
                    {
                        nodeDept = GetNodeDept(info, null);

                        privDeptCode = info.ApplyDept.ID;
                        privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                        privBillCode = "";
                    }
                    if (showLevel == 0) continue;			//如果只显示一级 则继续
                    #endregion

                    #region 只显示至摆药单节点
                    if (info.DrugBillClass.ID != privBillCode)	//添加新的摆药单节点
                    {
                        nodeBill = this.GetNodeBill(info, nodeDept);

                        privBillCode = info.DrugBillClass.ID;	//保存上一次的摆药单号
                    }
                    if (showLevel == 1) continue;			//如果不显示患者信息 则继续
                    #endregion

                    #region 显示患者信息 如果信息相同则继续
                    if (info.ApplyDept.ID == privInfo.ApplyDept.ID && info.StockDept.ID == privInfo.StockDept.ID
                        && info.DrugBillClass.ID == privInfo.DrugBillClass.ID && info.SendType == privInfo.SendType)
                        continue;
                    privInfo = info;

                    //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                    bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                    if (isNursePrint)
                    {
                        ArrayList alTemp = this.itemManager.QueryNursePrintBill(info.DrugBillClass.ID, privInfo.ApplyDept.ID, privInfo.StockDept.ID);
                        if (alTemp == null)
                        {
                            MessageBox.Show("添加摆药单号节点：" + this.itemManager.Err);
                            return;
                        }
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in alTemp)
                        {
                            nodePatient = this.GetNodePatient(obj, nodeBill);

                            this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                        }
                    }
                    else
                    {
                        List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                        if (neuObjectList == null)
                        {
                            MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                            return;
                        }
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                        {
                            nodePatient = this.GetNodePatient(obj, nodeBill);

                            this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                        }
                    }

                    //List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                    //if (neuObjectList == null)
                    //{
                    //    MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                    //    return;
                    //}
                    //foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                    //{
                    //    nodePatient = this.GetNodePatient(obj, nodeBill);

                    //    this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                    //}
                    #endregion
                }
                else
                {
                    #region 按照摆药单优先显示

                    //添加摆药单分类列表，如果本节点已经添加则不重复添加
                    if (info.DrugBillClass.ID != privBillCode)
                    {
                        nodeBill = this.GetNodeBill(info, null);

                        privDeptCode = "";  //清空科室编码变量，避免跟上一张摆药单中的科室重复

                        //{22E638FE-2821-4bdf-A8A9-5BD25D51742E} 摆药单优先时发生错误
                        privBillCode = info.DrugBillClass.ID;
                    }

                    //如果显示等级为0（显示科室汇总），则不进行下面的代码
                    if (showLevel == 0)
                    {
                        continue;
                    }

                    //添加科室列表，如果本节点已经添加则不重复添加
                    if (info.ApplyDept.ID != privDeptCode)
                    {
                        nodeDept = this.GetNodeDept(info, nodeBill);
                        privDeptCode = info.ApplyDept.ID;   //保存最新一次添加的科室节点

                        //如果显示等级为1（显示科室明细），则不进行下面的代码
                        if (showLevel == 1) continue;

                        //添加患者列表(患者信息：住院流水号ID，姓名Name，床号Memo)
                        List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                        if (neuObjectList == null)
                        {
                            MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                            return;
                        }
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                        {
                            nodePatient = this.GetNodePatient(obj, nodeDept);

                            this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                        }
                    }

                    #endregion
                }

                this.ResumeLayout();

                #endregion

                #region 屏蔽原来累加方式代码 保留备份

                //if (this.isListAddType)
                //{
                //    #region 每次累加方式

                //    if (this.isDeptFirst)
                //    {
                //        #region 每次累计方式 按科室优先添加

                //        nodeDept = this.FindNode(info, this.Nodes, "0");
                //        if (nodeDept == null)
                //            nodeDept = GetNodeDept(info, null);

                //        if (showLevel == 0) continue;			//如果只显示一级 则继续

                //        nodeBill = this.FindNode(info, nodeDept.Nodes, "1");
                //        if (nodeBill == null)
                //            nodeBill = this.GetNodeBill(info, nodeDept);

                //        if (showLevel == 1) continue;			//如果不显示患者信息 则继续

                //        List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                //        if (neuObjectList == null)
                //        {
                //            MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                //            return;
                //        }
                //        foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                //        {
                //            nodePatient = this.FindNode(obj, nodeBill.Nodes);
                //            if (nodePatient == null)
                //            {
                //                nodePatient = this.GetNodePatient(obj, nodeBill);
                //                this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                //            }
                //        }

                //        #endregion
                //    }
                //    else
                //    {
                //        #region 每次累计方式 按单据优先添加

                //        nodeBill = this.FindNode(info, this.Nodes, "1");
                //        if (nodeBill == null)
                //            nodeBill = this.GetNodeBill(info, null);

                //        if (showLevel == 0) continue;

                //        nodeDept = this.FindNode(info, nodeBill.Nodes, "1");
                //        if (nodeDept == null)
                //            nodeDept = this.GetNodeDept(info, null);

                //        if (showLevel == 1) continue;

                //        List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                //        if (neuObjectList == null)
                //        {
                //            MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                //            return;
                //        }
                //        foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                //        {
                //            nodePatient = this.FindNode(obj, nodeDept.Nodes);
                //            if (nodePatient == null)
                //            {
                //                nodePatient = this.GetNodePatient(obj, nodeDept);
                //                this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                //            }
                //        }

                //        #endregion
                //    }

                //    #endregion
                //}
                //else
                //{
                //    #region 每次将节点清空重新添加

                //    this.SuspendLayout();

                //    if (this.isDeptFirst)
                //    {
                //        #region 只显示至科室节点
                //        if (info.ApplyDept.ID != privDeptCode)		//添加新的科室节点
                //        {
                //            nodeDept = GetNodeDept(info, null);

                //            privDeptCode = info.ApplyDept.ID;
                //            privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                //            privBillCode = "";
                //        }
                //        if (showLevel == 0) continue;			//如果只显示一级 则继续
                //        #endregion

                //        #region 只显示至摆药单节点
                //        if (info.DrugBillClass.ID != privBillCode)	//添加新的摆药单节点
                //        {
                //            nodeBill = this.GetNodeBill(info, nodeDept);

                //            privBillCode = info.DrugBillClass.ID;	//保存上一次的摆药单号
                //        }
                //        if (showLevel == 1) continue;			//如果不显示患者信息 则继续
                //        #endregion

                //        #region 显示患者信息 如果信息相同则继续
                //        if (info.ApplyDept.ID == privInfo.ApplyDept.ID && info.StockDept.ID == privInfo.StockDept.ID
                //            && info.DrugBillClass.ID == privInfo.DrugBillClass.ID && info.SendType == privInfo.SendType)
                //            continue;
                //        privInfo = info;
                //        List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                //        if (neuObjectList == null)
                //        {
                //            MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                //            return;
                //        }
                //        foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                //        {
                //            nodePatient = this.GetNodePatient(obj, nodeBill);

                //            this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                //        }
                //        #endregion
                //    }
                //    else
                //    {
                //        #region 按照摆药单优先显示

                //        //添加摆药单分类列表，如果本节点已经添加则不重复添加
                //        if (info.DrugBillClass.ID != privBillCode)
                //        {
                //            nodeBill = this.GetNodeBill(info, null);

                //            privDeptCode = "";  //清空科室编码变量，避免跟上一张摆药单中的科室重复
                //        }

                //        //如果显示等级为0（显示科室汇总），则不进行下面的代码
                //        if (showLevel == 0) continue;

                //        //添加科室列表，如果本节点已经添加则不重复添加
                //        if (info.ApplyDept.ID != privDeptCode)
                //        {
                //            nodeDept = this.GetNodeDept(info, nodeBill);
                //            privDeptCode = info.ApplyDept.ID;   //保存最新一次添加的科室节点

                //            //如果显示等级为1（显示科室明细），则不进行下面的代码
                //            if (showLevel == 1) continue;

                //            //添加患者列表(患者信息：住院流水号ID，姓名Name，床号Memo)
                //            List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                //            if (neuObjectList == null)
                //            {
                //                MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                //                return;
                //            }
                //            foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                //            {
                //                nodePatient = this.GetNodePatient(obj, nodeDept);

                //                this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                //            }
                //        }

                //        #endregion
                //    }

                //    this.ResumeLayout();

                //    #endregion
                //}

                #endregion
            }
        }

        /// <summary>
        /// 查找患者
        /// </summary>
        /// <param name="inpatientNO">住院患者流水号</param>
        public virtual void FindPatient(string inpatientNO)
        {
            if (this.Nodes.Count > 0)
            {
                foreach (DrugMessageTreeNode node in this.Nodes)
                {
                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        foreach (DrugMessageTreeNode chileNode in node.Nodes)
                        {
                            if (chileNode.Nodes != null && chileNode.Nodes.Count > 0)
                            {
                                foreach (DrugMessageTreeNode patientNode in chileNode.Nodes)
                                {
                                    Neusoft.FrameWork.Models.NeuObject patient = patientNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                                    if (patient == null)
                                    {
                                        continue;
                                    }

                                    if (patient.ID == inpatientNO)
                                    {
                                        this.SelectedNode = patientNode;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public virtual int AutoSave(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage)
        {
            //检索科室摆药申请明细数据
            ArrayList al = this.itemManager.QueryApplyOutList(drugMessage);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("根据摆药通知信息获取摆药申请明细信息发生错误 ") + this.itemManager.Err);
                return -1;
            }
            if (drugMessage.DrugBillClass.ID == "R")
            {
                if (DrugStore.Function.DrugReturnConfirm(al, drugMessage, this.StockMarkDept, this.approveDept) != 1)
                    return -1;
            }
            else
            {
                if (DrugStore.Function.DrugConfirm(al, drugMessage, this.StockMarkDept, this.approveDept) != 1)
                    return -1;
            }

            return 1;
        }

        #region 树节点增加/查找方法

        /// <summary>
        /// 获取摆药单列表显示时患者节点
        /// </summary>
        /// <param name="nodeBill">父级节点</param>
        /// <param name="obj">患者信息</param>
        /// <returns>成功返回摆药单显示时的患者节点</returns>
        private DrugMessageTreeNode GetNodePatient(Neusoft.FrameWork.Models.NeuObject obj,DrugMessageTreeNode parentNode)
        {
            foreach (DrugMessageTreeNode childNode in parentNode.Nodes)
            {
                if (childNode.Text == "【" + obj.Memo + "】" + obj.Name)
                {
                    return childNode;
                }
            }

            DrugMessageTreeNode nodePatient;
            nodePatient = new DrugMessageTreeNode();
            nodePatient.Text = "【" + obj.Memo + "】" + obj.Name;  //【床号】姓名
            nodePatient.ImageIndex = 6;
            nodePatient.SelectedImageIndex = 6;
            nodePatient.Tag = obj;
            nodePatient.NodeType = DrugMessageNodeType.Patient;
            if (parentNode == null)
                this.Nodes.Add(nodePatient);
            else
                parentNode.Nodes.Add(nodePatient);
            return nodePatient;
        }

        /// <summary>
        /// 获取摆药单列表显示时科室节点
        /// </summary>
        /// <param name="info">摆药通知信息</param>
        /// <returns>成功返回摆药单列表显示时的科室节点</returns>
        private DrugMessageTreeNode GetNodeDept(Neusoft.HISFC.Models.Pharmacy.DrugMessage info,DrugMessageTreeNode parentNode)
        {
            DrugMessageTreeNode nodeDept = new DrugMessageTreeNode();
            if (info.ApplyDept.Name == "")
                info.ApplyDept.Name = objHelper.GetName(info.ApplyDept.ID);
            nodeDept.Text = info.ApplyDept.Name;
            nodeDept.ImageIndex = 0;
            nodeDept.Tag = info;
            nodeDept.NodeType = DrugMessageNodeType.ApplyDept;
            if (parentNode == null)
                this.Nodes.Add(nodeDept);
            else
                parentNode.Nodes.Add(nodeDept);
            return nodeDept;
        }

        /// <summary>
        /// 获取摆药单列表显示时的摆药单节点
        /// </summary>
        /// <param name="info">摆药通知信息</param>
        /// <param name="nodeDept">父级节点</param>
        /// <returns>成功返回摆药单列表显示时的摆药单节点</returns>
        private DrugMessageTreeNode GetNodeBill(Neusoft.HISFC.Models.Pharmacy.DrugMessage info, DrugMessageTreeNode parentNode)
        {
            //{22E638FE-2821-4bdf-A8A9-5BD25D51742E}  数据校验 避免parentNode为null
            if (parentNode != null)
            {
                foreach (DrugMessageTreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.Text == info.DrugBillClass.Name)
                    {
                        return childNode;
                    }
                }
            }

            DrugMessageTreeNode nodeBill = new DrugMessageTreeNode();
            nodeBill.Text = info.DrugBillClass.Name;
            nodeBill.ImageIndex = 4;
            nodeBill.SelectedImageIndex = 5;
            nodeBill.Tag = info;
            nodeBill.NodeType = DrugMessageNodeType.DrugBill;
            if (parentNode == null)
                this.Nodes.Add(nodeBill);
            else
                parentNode.Nodes.Add(nodeBill);		//添加到科室节点
            return nodeBill;
        }

        /// <summary>
        /// 在节点集合内查找是否已存在该类型节点 如果存在 则返回该节点
        /// </summary>
        /// <param name="info">摆药通知信息</param>
        /// <param name="nodeCollection">查找的节点集合</param>
        /// <param name="findType">查找类别 0 科室 1 单据</param>
        /// <returns>成功则返回该类型节点 不存在返回null</returns>
        private DrugMessageTreeNode FindNode(Neusoft.HISFC.Models.Pharmacy.DrugMessage info, TreeNodeCollection nodeCollection,string findType)
        {
            if (nodeCollection == null || nodeCollection.Count == 0)
                return null;
            foreach (DrugMessageTreeNode node in nodeCollection)
            {
                switch (findType)
                {
                    case "0":
                        if ((node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage).ApplyDept.ID == info.ApplyDept.ID)
                            return node;
                        break;
                    case "1":
                        if ((node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage).DrugBillClass.ID == info.DrugBillClass.ID)
                            return node;
                        break;
                }
            }
            return null;
        }

        /// <summary>
        /// 在节点集合内查找是否已存在该类型节点 如果存在 则返回该节点
        /// </summary>
        /// <param name="info">患者信息</param>
        /// <param name="nodeCollection">查找的节点集合</param>
        /// <returns>成功则返回该类型节点 不存在返回null</returns>
        private DrugMessageTreeNode FindNode(Neusoft.FrameWork.Models.NeuObject info, TreeNodeCollection nodeCollection)
        {
            if (nodeCollection == null || nodeCollection.Count == 0)
                return null;
            foreach (DrugMessageTreeNode node in nodeCollection)
            {
                if (node.Text == "【" + info.User03 + "】" + info.User02)
                    return node;
            }
            return null;
        }

        #endregion

        /// <summary>
        /// 判断是否需要打印 对未打印的患者获取数据进行打印
        /// </summary>
        /// <param name="judgeKey">判断的主键依据</param>
        /// <param name="judgeMessage">摆药通知信息</param>
        /// <param name="judgePatientNO">患者住院号</param>
        protected virtual void JudgePrint(string judgeKey, Neusoft.HISFC.Models.Pharmacy.DrugMessage judgeMessage, string judgePatientNO)
        {
            if (!this.isAutoPrint)
                return;

            //if (tvDrugMessage.hsPrint != null && tvDrugMessage.hsPrint.ContainsKey(judgeKey))

            if (tvDrugMessage.hsPrint == null)
            {
                tvDrugMessage.hsPrint = new Hashtable();
            }

            #region 待打印数据获取

            judgeMessage.User01 = judgePatientNO;		//需打印患者住院流水号
            //检索患者摆药申请明细数据
            ArrayList al = this.itemManager.QueryApplyOutListByPatient(judgeMessage);
            if (al == null)
            {
                MessageBox.Show("获取" + judgePatientNO + "的待打印数据时发生错误");
                return;
            }

            //屏蔽此处判断 同一张单据包括两天数据时 判断有问题
            //if (al.Count > 0)
            //{
            //    Neusoft.HISFC.Models.Pharmacy.ApplyOut info = al[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
            //    if (info != null)
            //    {
            //        //非当日数据不予打印
            //        if (info.Operation.ApplyOper.OperTime < this.sysDate)
            //        {
            //            tvDrugMessage.hsPrint.Add(judgeKey, null);
            //            return;
            //        }
            //    }
            //}

            //取出所有未打印数据
            ArrayList alPrintData = new ArrayList();
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut printInfo in al)
            {
                //对非当日数据不打印
                if (printInfo.Operation.ApplyOper.OperTime < this.sysDate)
                {
                    continue;
                }

                if (printInfo.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid && printInfo.PrintState != "1")
                {
                    alPrintData.Add(printInfo);
                }
            }

            #endregion

            //无待打印数据 直接返回
            if (alPrintData.Count == 0)
            {
                return;
            }

            if (this.isPrintLabel)
            {
                #region 标签打印

                if (Function.PrintLabelForOutpatient(alPrintData) != -1)
                {
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alPrintData)
                    {
                        info.PrintState = "1";			//该标记用于区分是否已对单据进行过打印
                        if (this.itemManager.UpdateApplyOut(info) == -1)
                        {
                            MessageBox.Show("更新打印标记发生错误");
                        }
                    }
                }

                #endregion
            }
            else
            {
                #region 摆药单打印

                Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass = this.drugStoreManager.GetDrugBillClass(judgeMessage.DrugBillClass.ID);
                drugBillClass.Memo = judgeMessage.DrugBillClass.Memo;//摆药单号

                if (Function.PrintBill(alPrintData, drugBillClass) != -1)
                {
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alPrintData)
                    {
                        info.PrintState = "1";			//该标记用于区分是否已对单据进行过打印
                        if (this.itemManager.UpdateApplyOutPrintState(info.ID, true) == -1)
                        {
                            MessageBox.Show("更新打印标记发生错误");
                        }
                    }
                }

                #endregion
            }

            tvDrugMessage.hsPrint.Add(judgeKey, null);

            //屏蔽打印自动保存功能
            //if (this.isPrintAndOutput)
            //{
            //    this.AutoSave(judgeMessage);
            //}
        }

        /// <summary>
        /// 获取选中的节点的摆药申请信息
        /// </summary>
        /// <param name="selectNode">当前选中节点</param>
        /// <param name="drugMessage">摆药通知信息</param>
        /// <param name="al">摆药明细信息</param>
        /// <param name="treeLevel">树节点层次</param>
        protected virtual void GetSelectData(DrugMessageTreeNode selectNode,ref Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage, ref ArrayList al,ref bool isDetail)
        {
            if (selectNode == null)
            {
                return;
            }

            #region 库存药品列表获取 用于药柜管理的判断 仅取一次

            if (stockMark != null && stockMark.ID != "")
            {
                //获取科室库存药品信息
                if (this.hsStockData == null)
                {
                    this.hsStockData = new Hashtable();

                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载科室库存信息 请稍候..."));
                    Application.DoEvents();

                    ArrayList alStorage = this.itemManager.QueryStockinfoList(stockMark.ID);

                    foreach (Neusoft.HISFC.Models.Pharmacy.Storage storage in alStorage)
                    {
                        if (storage.IsArkManager)
                        {
                            continue;
                        }
                        this.hsStockData.Add(storage.Item.ID,null);
                    }

                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                }
            }

            #endregion

            int treeLevel = selectNode.Level;
            drugMessage = selectNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage;

            ArrayList alTotal = new ArrayList();

            //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);

            switch (treeLevel)
            {
                case 0:             //第一级  NodeType 可能为 科室、单据
                    //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                    //bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                    if (isNursePrint)
                    {
                        break;
                    }
                    
                    if (this.isDeptFirst)
                    {
                        alTotal = this.drugStoreManager.QueryDrugBillList(this.drugControl.ID, drugMessage);
                        isDetail = false;
                    }
                    else
                    {
                        alTotal = this.drugStoreManager.QueryDrugMessageList(drugMessage);
                        isDetail = false;
                    }
                    break;
                case 1:            //第二级 NodeType 可能为 科室、单据、患者
                    //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                    //bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                    if (isNursePrint)
                    {
                        break;
                    }

                    if (selectNode.NodeType == DrugMessageNodeType.Patient)     //节点为患者 特殊处理 取所有子节点摆药单进行处理
                    {
                        Neusoft.FrameWork.Models.NeuObject patientTag = selectNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                        ArrayList alTempTotal = new ArrayList();
                        foreach (DrugMessageTreeNode childNode in selectNode.Nodes)
                        {
                            drugMessage = childNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage;
                            if (drugMessage != null)
                            {                               
                                drugMessage.User01 = patientTag.ID;
                                alTempTotal = this.itemManager.QueryApplyOutListByPatient(drugMessage);
                            }

                            alTotal.AddRange(alTempTotal);
                        }
                    }
                    else
                    {
                        alTotal = this.itemManager.QueryApplyOutList(drugMessage);
                    }

                    isDetail = true;

                    break;
                case 2:         //第三级 NodeType 可能为 单据、患者
                    if (selectNode.NodeType == DrugMessageNodeType.Patient)
                    {
                        drugMessage = selectNode.Parent.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage;
                        Neusoft.FrameWork.Models.NeuObject patientObj = selectNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                        drugMessage.User01 = patientObj.ID;

                        //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                        //bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                        if (isNursePrint)
                        {
                            alTotal = this.itemManager.QueryApplyOutListByNurseBill(patientObj.ID);
                            drugMessage.DrugBillClass.Memo = patientObj.ID;//事先保存摆药单号，用于后面的日志信息保存 by Sunjh 2010-8-5
                        }
                        else
                        {
                            alTotal = this.itemManager.QueryApplyOutListByPatient(drugMessage);
                        }  

                        //alTotal = this.itemManager.QueryApplyOutListByPatient(drugMessage);
                        isDetail = true;
                    }
                    else       //节点为单据时
                    {
                        drugMessage = selectNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugMessage;
                        Neusoft.FrameWork.Models.NeuObject patientObj = selectNode.Parent.Tag as Neusoft.FrameWork.Models.NeuObject;
                        drugMessage.User01 = patientObj.ID;
                        alTotal = this.itemManager.QueryApplyOutListByPatient(drugMessage);
                        isDetail = true;
                    }
                    break;
            }

            #region 药柜管理药品的处理

            if (this.hsStockData == null)
            {
                al = alTotal;
            }
            else
            {
                //屏蔽药柜管理的药品
                if (alTotal.Count > 0)
                {
                    if (alTotal[0] is Neusoft.HISFC.Models.Pharmacy.ApplyOut)
                    {
                        foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alTotal)
                        {
                            if (this.hsStockData.ContainsKey(info.Item.ID))
                            {
                                al.Add(info);
                            }
                        }
                    }
                    else
                    {
                        al = alTotal;
                    }
                }
            }

            #endregion
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage = new DrugMessage();
            ArrayList al = new ArrayList();
            bool isDetail = true;
            this.GetSelectData(e.Node as DrugMessageTreeNode,ref drugMessage,ref al,ref isDetail);

            if (al != null)
            {
                if (this.SelectDataEvent != null)
                    this.SelectDataEvent(drugMessage,al, isDetail);
            }

            base.OnAfterSelect(e);
        }

        /// <summary>
        /// 根据传入的摆药通知数组，显示在tvDrugMessage中
        /// 传入参数数组是按照科室、摆药单类型、发送时间（倒序）排序的
        /// </summary>
        /// <param name="alDrugMessage">摆药通知数组</param>
        /// <param name="showLevel">显示等级</param>
        public virtual void ShowListForDeptFirst(ArrayList alDrugMessage, int showLevel)
        {
            this.Nodes.Clear();

            string privBillCode = "";
            string privDeptCode = "";				//上一个科室
            Neusoft.HISFC.Models.Pharmacy.DrugMessage privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
            DrugMessageTreeNode nodePatient;
            DrugMessageTreeNode nodeDept = new DrugMessageTreeNode();
            DrugMessageTreeNode nodeBill = new DrugMessageTreeNode();

            foreach (DrugMessage info in alDrugMessage)
            {
                #region 每次将节点清空重新添加

                this.SuspendLayout();

                #region 只显示至科室节点

                if (info.ApplyDept.ID != privDeptCode)		//添加新的科室节点
                {
                    nodeDept = GetNodeDept(info, null);

                    privDeptCode = info.ApplyDept.ID;
                    privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                    privBillCode = "";
                }
                if (showLevel == 0)
                {
                    continue;			//如果只显示一级 则继续
                }

                #endregion

                if (showLevel != 3)         //按原显示方式正常处理
                {
                    #region 只显示至摆药单节点 此处不显示患者

                    if (info.DrugBillClass.ID != privBillCode)	//添加新的摆药单节点
                    {
                        nodeBill = this.GetNodeBill(info, nodeDept);

                        privBillCode = info.DrugBillClass.ID;	//保存上一次的摆药单号
                    }
                    if (showLevel == 1)
                    {
                        continue;			//如果不显示患者信息 则继续
                    }

                    #endregion

                    #region 显示患者信息 如果信息相同则继续

                    //避免重复添加
                    if (info.ApplyDept.ID == privInfo.ApplyDept.ID && info.StockDept.ID == privInfo.StockDept.ID
                        && info.DrugBillClass.ID == privInfo.DrugBillClass.ID && info.SendType == privInfo.SendType)
                    {
                        continue;
                    }
                    privInfo = info;
                    List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                    if (neuObjectList == null)
                    {
                        MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                        return;
                    }
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                    {
                        nodePatient = this.GetNodePatient(obj, nodeBill);

                        this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                    }

                    #endregion
                }
                else
                {
                    //显示患者明细 并按患者优先显示 即患者下面显示单据明细
                    DrugMessage tempMessage = info.Clone();
                    tempMessage.DrugBillClass.ID = "A";
                    List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(tempMessage);
                    if (neuObjectList == null)
                    {
                        MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                        return;
                    }

                    foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                    {
                        nodePatient = this.GetNodePatient(obj, nodeDept);

                        this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                    }
                }

                this.ResumeLayout();

                #endregion
            }
        }

        /// <summary>
        /// 根据传入的摆药通知数组，显示在tvDrugMessage中
        /// 传入参数数组是按照科室、摆药单类型、发送时间（倒序）排序的
        /// 
        /// 显示层次为 科室/患者/单据
        /// </summary>
        /// <param name="alDrugMessage">摆药通知数组</param>
        public virtual void ShowListForInpatientFirst(ArrayList alDrugMessage)
        {
            this.Nodes.Clear();

            string privPatientNO = "";
            string privDeptCode = "";				//上一个科室
            Neusoft.HISFC.Models.Pharmacy.DrugMessage privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
            DrugMessageTreeNode nodePatient;
            DrugMessageTreeNode nodeDept = new DrugMessageTreeNode();
            DrugMessageTreeNode nodeBill = new DrugMessageTreeNode();

            this.SuspendLayout();

            foreach (DrugMessage info in alDrugMessage)
            {
                if (info.ApplyDept.ID != privDeptCode)		//添加新的科室节点 一个科室节点仅需添加处理一次
                {
                    nodeDept = this.GetNodeDept(info, null);

                    privDeptCode = info.ApplyDept.ID;
                    privInfo = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                }

                //避免重复添加
                if (info.ApplyDept.ID == privInfo.ApplyDept.ID && info.StockDept.ID == privInfo.StockDept.ID
                    && info.DrugBillClass.ID == privInfo.DrugBillClass.ID && info.SendType == privInfo.SendType)
                {
                    continue;
                }

                //获取患者信息
                List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = this.itemManager.QueryApplyOutPatientList(info);
                if (neuObjectList == null)
                {
                    MessageBox.Show("添加患者节点：" + this.itemManager.Err);
                    return;
                }
                foreach (Neusoft.FrameWork.Models.NeuObject obj in neuObjectList)
                {
                    nodePatient = this.GetNodePatient(obj, nodeDept);

                    nodeBill = this.GetNodeBill(info, nodePatient);

                    this.JudgePrint(info.ApplyDept.ID + info.DrugBillClass.ID + obj.ID, info, obj.ID);
                }
            }

            this.ResumeLayout();
        }
    }
}
