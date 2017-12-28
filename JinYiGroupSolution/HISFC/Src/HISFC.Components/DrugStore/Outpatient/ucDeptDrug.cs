using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 门诊科室摆药]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    ///		
    ///  />
    /// </summary>
    public partial class ucDeptDrug : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucDeptDrug()
        {
            InitializeComponent();

        }

        #region 域变量

        /// <summary>
        /// 权限人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 门诊业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 药品管理业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 是否打印处方
        /// </summary>
        private bool isPrintRecipe = true;

        /// <summary>
        /// 打印标签使用
        /// </summary>
        private ucClinicTree uc = null;
        #endregion

        #region 属性

        /// <summary>
        /// 是否打印处方
        /// </summary>
        [Description("打印按钮是否打印处方 设置为False打印标签"),Category("设置"),DefaultValue(true)]
        public bool IsPrintRecipe
        {
            get
            {
                return this.isPrintRecipe;
            }
            set
            {
                this.isPrintRecipe = value;
            }
        }

        #endregion

        #region 工具栏信息

        ///// <summary>
        ///// 定义事件委托
        ///// </summary>
        //private event System.EventHandler ToolButtonClicked;
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
            //this.ToolButtonClicked += new EventHandler( ToolButton_clicked );
            //增加工具栏
            this.toolBarService.AddToolButton("全选", "选择全部患者", 0, true, false, null);
            this.toolBarService.AddToolButton("全不选", "取消所有选择", 1, true, false, null);
            return this.toolBarService;
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
                case "全选":
                    this.SetCheck(true);
                    break;
                case "全不选":
                    this.SetCheck(false);
                    break;
            }

        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.isPrintRecipe)
            {
                this.ucClinicDrug1.Print();
            }
            else
            {
                if (this.uc == null)
                {
                    this.uc = new ucClinicTree();
                    this.uc.Init();
                    this.uc.OperDept = this.privDept;
                    this.uc.OperInfo = this.privOper;
                }
                this.uc.terminal.ID = this.cmbSendTerminal.Tag.ToString();

                Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = this.tvClinicTree1.SelectedNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alList = this.ucClinicDrug1.GetData();

                this.uc.Print(drugRecipe, new ArrayList(alList.ToArray()));
            }

            return base.OnPrint(sender, neuObject);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = deptManager.GetClinicDepartment();
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取门诊科室列表发生错误") + deptManager.Err);
                return -1;
            }

            this.cmbRecipeDept.AddItems(al);

            ArrayList alTerminal = this.drugStoreManager.QueryDrugTerminalByDeptCode(this.privDept.ID, "0");
            if (alTerminal == null)
            {
                MessageBox.Show(Language.Msg("获取本库房发药终端列表发生错误"));
                return -1;
            }

            this.cmbSendTerminal.AddItems(alTerminal);

            this.cmbSendTerminal.SelectedIndex = 0;

            //if (Function.InitLabelPrintInterface() == -1)
            //{
            //    return -1;
            //}

            return 1;
        }

        private int InitPrintInstance()
        {
            object factoryInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;
            if (factoryInstance != null)
            {
                Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint = factoryInstance as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;

                if (Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint == null)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 选择设定
        /// </summary>
        /// <param name="isCheck">是否选中</param>
        protected void SetCheck(bool isCheck)
        {
            foreach (TreeNode node in this.tvClinicTree1.Nodes)
            {
                node.Checked = isCheck;
            }
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        protected void Clear()
        {
            this.ucClinicDrug1.Clear();
        }

        /// <summary>
        /// 获取当前选中患者
        /// </summary>
        /// <returns>成功返回当前选中患者信息 失败返回null</returns>
        protected List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe> GetCheckPatient()
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe> alCheckPatient = new List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe>();
            //{021613AF-A133-46eb-9680-ACDBDF058FAE}  科室摆药  从二级节点获取患者
            foreach (TreeNode node in this.tvClinicTree1.Nodes[0].Nodes)
            {
                if (node.Checked)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;

                    alCheckPatient.Add(drugRecipe);
                }
            }

            return alCheckPatient;
        }

        /// <summary>
        /// 根据处方科室获取患者列表
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int QueryPatientList()
        {
            if (this.cmbRecipeDept.Tag == null || this.cmbRecipeDept.Tag.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择处方科室"));
                return -1;
            }

            ArrayList alList = this.drugStoreManager.QueryUnSendList(this.cmbRecipeDept.Tag.ToString());
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取患者列表发生错误") + this.drugStoreManager.Err);
                return -1;
            }

            TreeNode rootNode = new TreeNode("取药患者列表", 0, 0);

            this.tvClinicTree1.ShowList(rootNode,alList, false,false);

            this.tvClinicTree1.ExpandAll();

            return 1;
        }

        /// <summary>
        /// 科室发药保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int SavePatient()
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe> alPatient = this.GetCheckPatient();
            if (alPatient == null || alPatient.Count == 0)
            {
                return 1;
            }

            Neusoft.FrameWork.Models.NeuObject sentTerminal = new Neusoft.FrameWork.Models.NeuObject();
            if (this.cmbSendTerminal.Tag == null || this.cmbSendTerminal.Tag.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择发药终端"));
                return -1;
            }
            sentTerminal.ID = this.cmbSendTerminal.Tag.ToString();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            string state = "1";

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe in alPatient)
            {
                if (drugRecipe.RecipeState == "0" || drugRecipe.RecipeState == "1")
                {
                    state = "0";
                }
                else
                {
                    state = "1";
                }

                #region 更新处方状态

                int parm = this.drugStoreManager.UpdateDrugRecipeState(this.privDept.ID, drugRecipe.RecipeNO, "M1", "0", "1");
                if (parm == -1)
                {
                    MessageBox.Show(Language.Msg("更新未打印状态为已打印状态失败!") + this.drugStoreManager.Err);

                    this.QueryPatientList();

                    return -1;
                }

                #endregion

                ArrayList al = itemManager.QueryApplyOutListForClinic(this.privDept.ID, "M1", state, drugRecipe.RecipeNO);
                if (al == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据调剂信息获取申请明细信息发生错误") + itemManager.Err);

                    this.QueryPatientList();

                    return -1;
                }

                if (Function.OutpatientSend(this.ConvertApplyOutToList(al), sentTerminal, this.privDept, this.privOper, true, true) == -1)
                {
                    MessageBox.Show(Language.Msg("对 " + drugRecipe.PatientName + " 进行发药处理时发生错误"));

                    this.QueryPatientList();

                    return -1;
                }

            }

            MessageBox.Show(Language.Msg("保存成功"));

            this.QueryPatientList();

            return 1;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> ConvertApplyOutToList(ArrayList al)
        {
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alList = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
            {
                alList.Add(info);
            }

            return alList;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            this.privOper = this.drugStoreManager.Operator;
            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)this.drugStoreManager.Operator).Dept;

            this.Init();

            this.ucClinicDrug1.funModle = OutpatientFun.DirectSend;
            this.ucClinicDrug1.OperDept = this.privDept;
            this.ucClinicDrug1.OperInfo = this.privOper;            

            this.ucClinicDrug1.Init();

            this.tvClinicTree1.AfterCheck += new TreeViewEventHandler(tvClinicTree1_AfterCheck);

            if (this.InitPrintInstance() == -1)
            {
                MessageBox.Show("初始化单据打印实现失败,将无法进行单据打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            base.OnLoad(e);
        }

        void tvClinicTree1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SavePatient();

            return base.OnSave(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryPatientList();

            return base.OnQuery(sender, neuObject);
        }

        private void tvClinicTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                ArrayList alDeptDrug = this.itemManager.QueryClinicUnSendList(this.cmbRecipeDept.Tag.ToString());
                if (alDeptDrug == null)
                {
                    MessageBox.Show(Language.Msg("获取药品申请信息失败"));
                    return;
                }

                this.ucClinicDrug1.ShowData(alDeptDrug);
            }
            if (e.Node != null && e.Node.Tag != null)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
                if (drugRecipe != null)
                {
                    this.ucClinicDrug1.ShowData(drugRecipe);
                }
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
