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
    /// [功能描述: 门诊代直接发药功能 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>功能待完善，添加自动刷新功能</说明>
    /// </summary>
    public partial class ucClinicInstead : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucClinicInstead()
        {
            InitializeComponent();
        }


        public delegate void ProcessMessageHandler(object sender, string msg);

        public delegate void MyTreeSelectHandler(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe);

        public delegate void MyOperChangedHandler(Neusoft.FrameWork.Models.NeuObject oper);

        /// <summary>
        /// 对打印过的结点改变结点位置
        /// </summary>
        private delegate void ChangePrintNodeHandler(TreeNode node, bool targetNextNodeType);

        /// <summary>
        /// 程序运行过程中发送的消息
        /// </summary>
        public event ProcessMessageHandler ProcessMessageEvent;

        ///// <summary>
        ///// 树列表选择事件
        ///// </summary>
        //public event MyTreeSelectHandler MyTreeSelectEvent;

        ///// <summary>
        ///// 配/发药操作员发生变化
        ///// </summary>
        //public event MyOperChangedHandler OperChangedEvent;

        ///// <summary>
        ///// 保存
        ///// </summary>
        //public event System.EventHandler SaveRecipeEvent;

        #region 域变量

        /// <summary>
        /// 药房操作管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 操作终端
        /// </summary>
        List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal> terinalList = new List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal>();

        /// <summary>
        /// 查询时检索的时间下限
        /// </summary>
        private DateTime minQueryDate = System.DateTime.MinValue;

        /// <summary>
        /// 核准科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作人员信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否是草药方式打印 配药打印时是否打印草药摆药单而不打印标签
        /// </summary>
        private bool isHerbalPrint = false;

        /// <summary>
        /// 打印工厂类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory printFactory = null;
        #endregion

        #region 帮助类

        /// <summary>
        /// 科室帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper terminalHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 属性

        /// <summary>
        /// 操作终端集合 
        /// </summary>
        protected List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal> TerminalList
        {
            set
            {
                this.terinalList = value;

                if (value != null)
                {
                    this.lbInfo.Text = "操作终端：";
                    foreach (Neusoft.HISFC.Models.Pharmacy.DrugTerminal info in value)
                    {
                        if (info.Dept.Name != "")
                        {
                            this.lbInfo.Text = this.lbInfo.Text + "  " + info.Dept.Name + "－" + info.Name;
                        }
                        else
                        {
                            this.lbInfo.Text = this.lbInfo.Text + "  " + info.Dept.Name + "－" + info.Name;
                        }
                    }

                    this.ShowList("1");
                }
            }
        }

        /// <summary>
        /// 当前终端
        /// </summary>
        protected Neusoft.HISFC.Models.Pharmacy.DrugTerminal OperTerminal
        {
            get
            {
                if (this.cmbTerminal.Text != "")
                {
                    return (Neusoft.HISFC.Models.Pharmacy.DrugTerminal)this.terminalHelper.GetObjectFromID(this.cmbTerminal.Tag.ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton("刷新", "刷新患者列表显示，检索未打印过的处方", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            this.toolBarService.AddToolButton("设置终端", "设置需同时摆药的药房及终端", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.ucClinicDrug1.terminal = this.OperTerminal;
            if (this.OperTerminal == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择当前终端"));
                return -1;
            }

            if (this.ucClinicDrug1.Save() == 1)
            {
                TreeNode selectNode = this.tvList.SelectedNode;

                this.tvList.Nodes.Remove(selectNode);
            }

            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "刷新":
                    this.ShowList("0");
                    break;
                case "设置终端":
                    this.Set();
                    break;
            }

        }

        protected override int OnPrint(object sender, object neuObject)
        {
            //{58947EA5-F81D-4bf0-A14A-D686CB78F1E3} 打印实现  
            if (string.IsNullOrEmpty(this.cmbTerminal.Text))
            {
                MessageBox.Show("请先选择发药终端以便确认单据打印格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            TreeNode selectNode = this.tvList.SelectedNode;

            this.PrintLabel(selectNode);

            return base.OnPrint(sender, neuObject);
        }

        #endregion

        #region 初始化设置

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected virtual void Init()
        {
            #region 帮助类初始化

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDept = managerIntegrate.GetDepartment();
            if (alDept == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载科室列表发生错误"));
                return;
            }

            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            ArrayList alTerminal = this.drugStoreManager.QueryDrugTerminalByTerminalType("0");
            if (alTerminal == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载发药终端列表发生错误") + drugStoreManager.Err);
                return;
            }

            this.terminalHelper = new Neusoft.FrameWork.Public.ObjectHelper(alTerminal);

            ArrayList alPerson = managerIntegrate.QueryEmployeeAll();
            if (alPerson == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载人员列表发生错误"));
                return;
            }

            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPerson);

            #endregion

            this.tvList.ImageList = this.tvList.groupImageList;

            this.approveDept = ((Neusoft.HISFC.Models.Base.Employee)this.drugStoreManager.Operator).Dept;
            this.operInfo = this.drugStoreManager.Operator;

            this.ucClinicDrug1.ApproveDept = this.approveDept;

            ArrayList sendTerminalList = this.drugStoreManager.QueryDrugTerminalByDeptCode(this.approveDept.ID, "0");
            if (sendTerminalList != null)
            {
                this.terinalList = new List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal>();
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugTerminal info in sendTerminalList)
                {
                    info.Dept.Name = this.approveDept.Name;
                    this.terinalList.Add(info);
                }
            }

            this.TerminalList = this.terinalList;
            this.cmbTerminal.AddItems(sendTerminalList);            

            this.ucClinicDrug1.OperInfo = this.operInfo;
            this.ucClinicDrug1.funModle = OutpatientFun.DirectSend;
            this.ucClinicDrug1.Init();            
        }

        /// <summary>
        /// 设置
        /// </summary>
        public virtual void Set()
        {
            ucTerminalSelect uc = new ucTerminalSelect();

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

            if (uc.Result == DialogResult.Cancel)
            {
                return;
            }

            List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal> tList = uc.GetTerminalList();

            if (tList != null && tList.Count > 0)
            {
                this.TerminalList = tList;
            }
            else
            {
                ArrayList sendTerminalList = this.drugStoreManager.QueryDrugTerminalByDeptCode(this.approveDept.ID, "0");
                if (sendTerminalList != null)
                {
                    this.terinalList = new List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal>();
                    foreach (Neusoft.HISFC.Models.Pharmacy.DrugTerminal info in sendTerminalList)
                    {
                        info.Dept.Name = this.approveDept.Name;
                        this.terinalList.Add(info);
                    }

                    this.TerminalList = this.terinalList;
                }
            }
        }

        /// <summary>
        /// 打印初始化
        /// </summary>
        protected virtual void PrintInit()
        {
            object factoryInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory;

            if (factoryInstance != null)
            {
                Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory factory = factoryInstance as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory;

                this.printFactory = factory;

                if (this.printFactory == null)
                {
                    MessageBox.Show("未配置单据打印的实现，将无法进行配药单据打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.OperTerminal == null || string.IsNullOrEmpty(this.OperTerminal.ID))
                {
                    return;
                }

                Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint = factory.GetInstance(this.OperTerminal);
            }

            if (Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint == null)
            {
                MessageBox.Show("未配置单据打印的实现，将无法进行配药单据打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            return;

            //#region 反射读取标签格式

            ////string dllName = "Report";
            //string className = "Report.DrugStore.ucRecipeLabel";

            ////门诊标签打印接口实现类
            //Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //string labelValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Clinic_Print_Label, true, "Report.DrugStore.ucRecipeLabel");
            ////门诊草药打印接口实现类
            //string billValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Clinic_Print_Bill, true, "Report.DrugStore.ucOutHerbalBill");

            ////默认标签打印
            //className = labelValue;
            ////读取本地控制参数 判断是否采用草药打印方式
            //string strErr = "";
            //ArrayList alParm = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ClinicDrug", "PrintList", out strErr);
            //if (alParm != null && alParm.Count > 0)
            //{
            //    if ((alParm[0] as string) == "1")
            //    {
            //        className = billValue;
            //        this.isHerbalPrint = true;
            //    }
            //}

            //object[] o = new object[] { };

            //try
            //{
            //    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", className, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
            //    object oLabel = objHandel.Unwrap();

            //    Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;

            //}
            //catch (System.TypeLoadException ex)
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //    MessageBox.Show(Language.Msg("标签命名空间无效\n" + ex.Message));
            //}

            //#endregion
        }

        #endregion

        #region 列表数据检索

        /// <summary>
        /// 检索列表显示 
        /// </summary>
        public virtual void ShowList(string state)
        {
            ArrayList alList = new ArrayList();

            DateTime queryTime = new DateTime(1, 1, 1, 0, 0, 0);

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugTerminal tempTerminal in this.terinalList)
            {
                ArrayList alTemp = new ArrayList();
                //功能类别 0 发药 1 配药
                alTemp = this.drugStoreManager.QueryList(tempTerminal.Dept.ID, tempTerminal.ID,"0",state, queryTime);
                string strMsg = "";
                if (alTemp == null)
                    strMsg = "此次刷新发生错误...." + this.drugStoreManager.Err;
                else
                    strMsg = "获取" + alTemp.Count + "条数据，等待下次刷新....";
                if (this.ProcessMessageEvent != null)
                {
                    this.ProcessMessageEvent("ShowList", strMsg);
                }

                if (alTemp.Count == 0)
                {
                    continue;
                }

                alList.Add(alTemp);               
            }

            this.AddListToTree(alList);
        }

        /// <summary>
        /// 在树型控件内加载数据显示
        /// </summary>
        /// <param name="alRecipeList"></param>
        protected virtual void AddListToTree(ArrayList alRecipeList)
        {
            foreach (ArrayList alList in alRecipeList)
            {
                TreeNode deptNode = null;
                TreeNode terminalNode = null;
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe info in alList)
                {
                    #region 科室节点加载

                    deptNode = this.FindDeptNode(info);
                    if (deptNode == null)
                    {
                        deptNode = this.AddDeptNode(info);
                    }
                    #endregion

                    #region 增加终端节点

                    terminalNode = this.FindTerminalNode(info, deptNode);
                    if (terminalNode == null)
                    {
                        terminalNode = this.AddTerminalNode(info);
                        deptNode.Nodes.Add(terminalNode);
                    }

                    #endregion

                    #region 增加患者节点

                    #endregion

                    TreeNode recipeNode = this.FindPatientNode(info,terminalNode);
                    if (recipeNode == null)
                    {
                        recipeNode = this.AddRecipeNode(info);
                        recipeNode.Tag = info;

                        terminalNode.Nodes.Add(recipeNode);
                    }                                        
                }

                //设置下次查询时间
                this.GetMinDrugedDate(alList);   
            }

            if (this.tvList.Nodes.Count > 0)
            {
                this.tvList.Nodes[0].Expand();
            }

            this.AutoPrint();
        }

        /// <summary>
        /// 获取传入的处方调剂数组内最大配药时间
        /// </summary>
        /// <param name="drugRecipeAl">处方调剂数组</param>
        private void GetMinDrugedDate(ArrayList drugRecipeAl)
        {
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

            //在最后时间上增加一秒 Sql语句内使用的大于等于
            this.minQueryDate = this.minQueryDate.AddSeconds(1);
        }

        /// <summary>
        /// 添加科室节点
        /// </summary>
        /// <param name="drugRecipe"></param>
        protected TreeNode AddDeptNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            TreeNode deptNode = new TreeNode(this.deptHelper.GetName(drugRecipe.StockDept.ID));
            deptNode.ImageIndex = 0;
            deptNode.Tag = drugRecipe.StockDept.ID;

            this.tvList.Nodes.Add(deptNode);

            return deptNode;
        }

        protected TreeNode FindDeptNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            foreach (TreeNode node in this.tvList.Nodes)
            {
                if (node.Tag.ToString() == drugRecipe.StockDept.ID)
                {
                    return node;
                }
            }

            return null;
        }

        protected TreeNode AddTerminalNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            TreeNode terminalNode = new TreeNode(this.terminalHelper.GetName(drugRecipe.SendTerminal.ID));
            terminalNode.Tag = drugRecipe.SendTerminal.ID;
            terminalNode.ImageIndex = 1;
            return terminalNode;
        }

        /// <summary>
        /// 查找终端节点
        /// </summary>
        /// <param name="drugRecipe"></param>
        /// <param name="deptNode"></param>
        /// <returns></returns>
        protected TreeNode FindTerminalNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe, TreeNode deptNode)
        {
            foreach (TreeNode terminalNode in deptNode.Nodes)
            {
                if (terminalNode.Tag.ToString() == drugRecipe.SendTerminal.ID)
                {
                    return terminalNode;
                }
            }

            return null;
        }

        protected TreeNode AddRecipeNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRcipe)
        {
            TreeNode recipeNode = new TreeNode(drugRcipe.PatientName);
            recipeNode.Tag = drugRcipe;
            recipeNode.ImageIndex = 2;
            return recipeNode;
        }

        /// <summary>
        /// 查找患者节点
        /// </summary>
        /// <param name="drugRecipe"></param>
        /// <param name="deptNode"></param>
        /// <returns></returns>
        protected TreeNode FindPatientNode(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe, TreeNode terminalNode)
        {
            foreach (TreeNode patientNode in terminalNode.Nodes)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe tempRecipe = patientNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                if (tempRecipe.RecipeNO == drugRecipe.RecipeNO)
                {
                    return patientNode;
                }
            }

            return null;
        }

        #endregion

        #region 单据打印

        public virtual int AutoPrint()
        {
            if (this.tvList.Nodes.Count <= 0)
            {
                return -1;
            }

            try
            {
                foreach (TreeNode deptNode in this.tvList.Nodes)
                {
                    foreach (TreeNode terminalNode in deptNode.Nodes)
                    {
                        foreach (TreeNode recipeNode in terminalNode.Nodes)
                        {
                            Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = recipeNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                            if (drugRecipe.RecipeState != "0")
                            {
                                continue;
                            }
                            this.PrintLabel( recipeNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 1;
        }

        /// <summary>
        /// 节点数据打印
        /// </summary>
        /// <param name="printNode"></param>
        protected virtual int PrintLabel(TreeNode printNode)
        {
            ArrayList alValidate = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = printNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
            if (info == null)       //点击药房或窗口时 该值为null
            {
                return -1;
            }
            string detailState = "0";
            if (info.RecipeState == "0" || info.RecipeState == "1")
            {
                detailState = "0";
            }
            else if (info.RecipeState == "2")
            {
                detailState = "1";
            }
            else
            {
                detailState = "2";
            }

            ArrayList alInfo = this.itemManager.QueryApplyOutListForClinic(info.StockDept.ID, "M1", detailState, info.RecipeNO);
            if (alInfo == null)
            {
                MessageBox.Show(Language.Msg("打印摆药单 获取待摆药明细出错!") + itemManager.Err);
                return -1;
            }
            //只取有效记录
            alValidate = new ArrayList();
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp in alInfo)
            {
                if (applyOutTemp.ValidState != Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                    alValidate.Add(applyOutTemp);
            }

            if (alValidate.Count > 0)
            {
                if (this.Print(info, alValidate) == -1)
                {
                    return -1;
                }
            }

            //更新打印标记  //对状态为0的数据更新打印标记
            if (info.RecipeState == "0")
            {
                int parm = this.drugStoreManager.UpdateDrugRecipeState(info.StockDept.ID, info.RecipeNO, "M1", "0", "1");
                if (parm == -1)
                {
                    MessageBox.Show(Language.Msg("更新摆药单明细 未打印状态为已打印状态失败!") + this.drugStoreManager.Err);
                    return -1;
                }
                info.RecipeState = "1";
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
            if (Function.IDrugPrint == null)
            {
                return -1;
            }

            //一次只打印一个处方号的
            //传入的时候按照组合号、院注标记分组 便于打印
            //applyOut.User01 发药窗口号 applyOut.User02 院注次数

            if (al.Count <= 0)
            {
                return 1;
            }

            Neusoft.HISFC.Models.Registration.Register patientInfo = null;		//患者信息

            #region 患者信息获取

            //获取患者信息
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            patientInfo = regManager.GetByClinic(drugRecipe.ClinicNO);

            #endregion

            #region 中药房草药、成药打印
            if (this.isHerbalPrint)
            {
                patientInfo.User01 = drugRecipe.FeeOper.OperTime.ToString();

                patientInfo.DoctorInfo.Templet.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);

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
                //temp.SendWindow = this.terminal.SendWindow.Name;
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

            #region 标签打印
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
            {
                //info.SendWindow = this.terminal.SendWindow.Name;
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

            return 1;
        }

        #endregion

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = this.tvList.SelectedNode;

            if (selectNode.Tag is Neusoft.HISFC.Models.Pharmacy.DrugRecipe)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = selectNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                this.ucClinicDrug1.OperDept = drugRecipe.StockDept;

                this.ucClinicDrug1.ShowData(drugRecipe);
            }
        }

        private void ucClinicInstead_Load(object sender, EventArgs e)
        {
            this.Init();

            this.PrintInit();            
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[2];
                printType[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientPrintFactory);
                printType[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint);

                return printType;
            }
        }

        #endregion

        private void cmbTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint = this.printFactory.GetInstance(this.OperTerminal);
        }
    }
}
