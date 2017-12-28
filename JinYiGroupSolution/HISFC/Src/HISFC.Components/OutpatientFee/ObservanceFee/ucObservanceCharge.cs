using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.ObservanceFee
{
    public partial class ucObservanceCharge : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 留观患者划价
        /// </summary>
        public ucObservanceCharge()
        {
            InitializeComponent();

        }

        #region 变量
        /// <summary>
        /// 挂号综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager groupManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 费用管理层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Outpatient outPatientFeeManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 患者挂号信息
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register rInfo = null;

        /// <summary>
        /// 操作员
        /// </summary>
        Neusoft.HISFC.Models.Base.Employee empl = null;

        Neusoft.FrameWork.WinForms.Forms.ToolBarService tooBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion

        #region 属性
        /// <summary>
        /// 加载类别
        /// </summary>
        public Neusoft.HISFC.Models.Base.ItemKind ItemKind
        {
            get
            {
                return this.ucFeeList1.ItemKind;
            }
            set
            {
                this.ucFeeList1.ItemKind = value;

            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 计算费用合计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucFeeList1_EventSumCost(object sender, EventArgs e)
        {
            this.lblCost.Text = sender.ToString();
        }
       
        /// <summary>
        /// 初始化树
        /// </summary>
        /// <returns></returns>
        protected int InitTree()
        {
            this.tvPatient.ImageList = this.tvPatient.deptImageList;
            this.tvGroup.ImageList = this.tvPatient.deptImageList;
            this.LoadPatient();
            this.LoadGroupList();
            return 1;
        }

        /// <summary>
        /// 获取留观患者信息
        /// </summary>
        /// <returns></returns>
        private int LoadPatient()
        {
            if (this.tvPatient.Nodes.Count > 0)
            {
                tvPatient.Nodes.Clear();
            }
            TreeNode root = new TreeNode("留观患者");
            root.ImageIndex = 0;
            Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            ArrayList al = registerIntegrate.PatientQueryByNurseCell(employee.Dept.ID, Neusoft.HISFC.Models.Base.EnumInState.I.ToString());
            if (al == null)
            {
                MessageBox.Show("查询留观患者信息失败！" + registerIntegrate.Err);
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Registration.Register r in al)
            {
                TreeNode node = new TreeNode(r.Name);
                node.ImageIndex = 6;
                node.SelectedImageIndex = 7;
                node.Tag = r;
                root.Nodes.Add(node);
            }
            this.tvPatient.Nodes.Add(root);
            this.tvPatient.ExpandAll();
            return 1;
            
        }

        /// <summary>
        /// 生成科室收费组套列表
        /// </summary>
        /// <returns></returns>
        private int LoadGroupList()
        {
            this.tvGroup.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "模板";
            root.ImageIndex = 0;
            tvGroup.Nodes.Add(root);
            ArrayList groups = this.groupManager.GetValidGroupList(empl.Dept.ID);
            if (groups == null)
            {
                MessageBox.Show("加载模板数据失败！" + groupManager.Err);
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Fee.ComGroup group in groups)
            {
                TreeNode Node = new TreeNode();
                Node.Text = group.Name;//模板名称
                Node.Tag = group.ID;//模板编码
                Node.ImageIndex = 2;
                Node.SelectedImageIndex = 3;
                root.Nodes.Add(Node);
            }
            root.Expand();

            return 1;
        }

        /// <summary>
        /// 查询患者划价信息
        /// </summary>
        private void QueryChargeInfo()
        {
            ArrayList alFeeList = outPatientFeeManager.QueryChargedFeeItemListsByClinicNODoctDept(rInfo.ID,empl.Dept.ID);
            if (alFeeList == null)
            {
                MessageBox.Show("查询患者划价信息失败！" + outPatientFeeManager.Err);
                return;
            }
            ucFeeList1.ChargeInfoList = alFeeList;
        }

        /// <summary>
        /// 划价保存
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            if (this.rInfo == null)
            {
                MessageBox.Show("请选择患者！");
                return -1;
            }
              if (!this.ucFeeList1.IsValid)
            {
                return -1;
            }
            this.ucFeeList1.StopEdit();
            ArrayList alFee = this.ucFeeList1.GetFeeItemList();
            if (alFee == null)
            {
                MessageBox.Show(this.ucFeeList1.ErrText);
                return -1;
            }
            if (alFee.Count == 0)
            {
                MessageBox.Show("没有费用信息！");
                this.ucFeeList1.SetFocus();
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFee)
            {
                f.Invoice.ID = "";
                f.FeeOper.OperTime = DateTime.MinValue;
                f.InvoiceCombNO = "";
                f.FeeOper.ID = "";
                f.RecipeOper.Dept.ID = (outPatientFeeManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                f.RecipeOper.ID = outPatientFeeManager.Operator.ID;
                f.FTSource = "2";
            }
            string errText = string.Empty;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            bool result = feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Save, rInfo, null, null, alFee, null, null, ref errText);
            if (!result)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("划价失败！" + errText);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("划价成功！");
            Clear();
            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.rInfo = null;
            this.ucFeeList1.PatientInfo = null;
            this.ucFeeList1.Clear();
            this.lblPInfo.Text = "患者信息";
            this.lblCost.Text = string.Empty;
        }

        #endregion

        #region 事件

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            tooBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            tooBarService.AddToolButton("划价", "划价", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H划价保存, true, false, null);
            tooBarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            return tooBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "划价":
                    {
                        Save();
                        break;
                    }
                case "删除":
                    {
                        this.ucFeeList1.DeleteRow();
                        break;
                    }
                case "清屏":
                    {
                        this.Clear();
                        break;
                    }
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void ucObservanceCharge_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请等待....");
            Application.DoEvents();
            empl = outPatientFeeManager.Operator as Neusoft.HISFC.Models.Base.Employee;
            this.ucFeeList1.Init();
            this.InitTree();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.ucFeeList1.EventSumCost += new EventHandler(ucFeeList1_EventSumCost);
        }

        private void tvGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (this.ucFeeList1.PatientInfo == null)
            {
                MessageBox.Show("请选择患者！");
                return;
            }
            this.ucFeeList1.SetGroup(e.Node.Tag.ToString());
        }

        private void tvPatient_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (e.Node.Tag == null)
            {
                return;
            }

            rInfo = e.Node.Tag as Neusoft.HISFC.Models.Registration.Register;

            if (rInfo == null)
            {
                return;
            }
            this.lblPInfo.Text = "病历号:" + rInfo.PID.CardNO + "   姓名:" + rInfo.Name + "   性别:" + rInfo.Sex.Name + "   生日:" + rInfo.Birthday.ToString("yyyy-MM-dd") +
                                 "   年龄:" + outPatientFeeManager.GetAge(rInfo.Birthday) + "   合同单位:" + rInfo.Pact.Name;
            this.ucFeeList1.Clear();
            this.ucFeeList1.PatientInfo = rInfo;
            this.ucFeeList1.Focus();
            this.ucFeeList1.SetFocus();
            QueryChargeInfo();

        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.LoadPatient();
            this.LoadGroupList();
            return base.OnQuery(sender, neuObject);
        }
        #endregion

    }
}
