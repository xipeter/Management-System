using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    public partial class ucFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFee()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucFee_Load);
        }

        void ucFee_Load(object sender, EventArgs e)
        {
            if (!Environment.DesignMode)
                this.RefreshGroupList();
            //this.ucRegistrationTree1.ShowCanceled = false;
            //{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
            this.ucRegistrationTree1.ListType = this.ListType;
            this.ucFeeForm1.ListType = this.ListType;
            this.ucRegistrationTree1.Init();
            this.ucRegistrationTree1.ShowCanceled = false;

        }

        #region 字段
        Neusoft.HISFC.BizProcess.Integrate.Manager groupManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion
        #region  属性

        #region {52AD1997-8BC0-4f22-97CA-2CF10B10C5F3} 设置参数能够调整左侧列宽 by guanyx
        private int leftWidth = 80;

        [Category("控件设置"), Description("调整左侧宽度 ")]
        public int LeftWidth
        {
            get
            {
                return this.ucFeeForm1.LeftWidth;
            }
            set
            {
                this.ucFeeForm1.LeftWidth = value;
            }
        }

        #endregion

        [Category("控件设置"), Description("设置该控件加载的项目类别 药品:drug 非药品 undrug 所有: all")]
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType 加载项目类别
        {
            get
            {
                return ucFeeForm1.加载项目类别;
            }
            set
            {
                ucFeeForm1.加载项目类别 = value;
            }
        }
        /// <summary>
        /// 控件功能
        /// </summary>
        [Category("控件设置"), Description("获得或者设置该控件的主要功能"), DefaultValue(1)]
        public Neusoft.HISFC.Components.Common.Controls.ucInpatientCharge.FeeTypes 控件功能
        {
            get
            {
                return this.ucFeeForm1.控件功能;
            }
            set
            {
                this.ucFeeForm1.控件功能 = value;
            }
        }

        /// <summary>
        /// 是否可以收费或者划价0单价的项目
        /// </summary>
        [Category("控件设置"), Description("获得或者设置是否可以收费或者划价"), DefaultValue(false)]
        public bool IsChargeZero
        {
            get
            {
                return this.ucFeeForm1.IsChargeZero;
            }
            set
            {
                this.ucFeeForm1.IsChargeZero = value;
            }
        }

        [Category("控件设置"), Description("是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            get
            {
                return this.ucFeeForm1.MessageType;
            }
            set
            {
                this.ucFeeForm1.MessageType = value;
            }
        }
        [Category("控件设置"), Description("数量为零是否提示和允许保存")]
        public bool IsJudgeQty
        {
            get
            {
                return this.ucFeeForm1.IsJudgeQty;
            }
            set
            {
                this.ucFeeForm1.IsJudgeQty = value;
            }
        }
        [Category("控件设置"), Description("执行科室是否默认为登陆科室")]
        public bool DefaultExeDeptIsDeptIn
        {
            get
            {
                return this.ucFeeForm1.DefaultExeDeptIsDeptIn;
            }
            set
            {
                this.ucFeeForm1.DefaultExeDeptIsDeptIn = value;
            }
        }

        /// <summary>
        /// 是否显示比例项{2C7FCD3D-D9B4-44f5-A2EE-A7E8C6D85576}
        /// </summary>
        [Category("控件设置"), Description("是否显示比例项"), DefaultValue(false)]
        public bool IsShowFeeRate
        {
            get { return this.ucFeeForm1.IsShowFeeRate; }
            set
            {

                this.ucFeeForm1.IsShowFeeRate = value;
            }
        }
        //{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
        [Category("控件设置"), Description("控件类型：麻醉还是收费")]
        public ucRegistrationTree.EnumListType ListType
        {
            get
            {
                return this.ucRegistrationTree1.ListType;
            }
            set
            {
                this.ucRegistrationTree1.ListType = value;
            }
        }
        #region donggq--20101118--{E64BCA09-C312-4488-BED3-1B0149E8B3E9}

        [Category("控件设置"), Description("树形控件加载统计大类类别，格式如下：'04','05'")]
        public string ArrFeeGate
        {
            get { return this.ucFeeForm1.ArrFeeGate; }
            set { this.ucFeeForm1.ArrFeeGate = value; }
        }

        [Category("控件设置"), Description("是否加载费别树形控件")]
        public bool IsShowItemTree
        {
            get { return this.ucFeeForm1.IsShowItemTree; }
            set { this.ucFeeForm1.IsShowItemTree = value; }
        }

        
        #endregion
        #endregion

        #region 方法
        /// <summary>
        /// 生成科室收费组套列表
        /// </summary>
        /// <returns></returns>
        private int RefreshGroupList()
        {
            this.tvGroup.Nodes.Clear();

            TreeNode root = new TreeNode();
            root.Text = "模板";
            root.ImageIndex = 22;
            root.SelectedImageIndex = 22;
            tvGroup.Nodes.Add(root);

            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            //ArrayList groups = this.groupManager.GetValidGroupList(Environment.OperatorDeptID);
            ArrayList groups = this.groupManager.GetValidGroupListByRoot(Environment.OperatorDeptID);
            if (groups != null)
            {
                foreach (Neusoft.HISFC.Models.Fee.ComGroup group in groups)
                {
                    TreeNode Node = new TreeNode();
                    Node.Text = group.Name;//模板名称
                    Node.Tag = group.ID;//模板编码
                    Node.ImageIndex = 11;
                    Node.SelectedImageIndex = 11;
                    root.Nodes.Add(Node);
                    this.AddGroupsRecursion(Node, group);
                }
            }
            root.Expand();

            return 0;
        }

        //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        private int AddGroupsRecursion(TreeNode parent, Neusoft.HISFC.Models.Fee.ComGroup group)
        {

            ArrayList al = this.groupManager.GetGroupsByDeptParent("1", group.deptCode, group.ID);
            if (al.Count == 0)
            {
                //TreeNode newNode = new TreeNode();
                //newNode.Tag = group;
                //newNode.Text = group.Name;// +"[" + group.ID + "]";
                //parent.Nodes.Add(newNode);

                //return -1;
            }
            else
            {

                foreach (Neusoft.HISFC.Models.Fee.ComGroup item in al)
                {
                    //if (item.ID == "aaa")
                    //{
                    //    MessageBox.Show("aaa");
                    //}
                    TreeNode newNode = new TreeNode();
                    //newNode.Tag = group;
                    //newNode.Text = group.Name;// +"[" + group.ID + "]";
                    //parent.Nodes.Add(newNode);
                    newNode.Tag = item;
                    newNode.Text = item.Name;
                    parent.Nodes.Add(newNode);
                    this.AddGroupsRecursion(newNode, item);
                }
            }


            return 1;
        }

        #endregion
        #region 事件

        private void ucFeeForm1_Load(object sender, EventArgs e)
        {
           
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("清屏", "清屏", 1, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除", 5, true, false, null);
            return this.toolBarService;
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            DateTime BeginTime = Convert.ToDateTime(this.neuDateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00");
            DateTime EndTime = Convert.ToDateTime(this.neuDateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59");
            //路志鹏　2007-4-13 取最小开始时间和最大结束时间
            this.ucRegistrationTree1.RefreshList(BeginTime, EndTime);
            //this.ucRegistrationTree1.RefreshList(this.neuDateTimePicker1.Value, this.neuDateTimePicker2.Value);
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.ucFeeForm1.Save();

            return base.OnSave(sender, neuObject);
        }


        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucFeeForm1.Print();
            return base.OnPrint(sender, neuObject);
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "清屏")
            {
                this.ucFeeForm1.Clear();
            }
            else if (e.ClickedItem.Text == "删除")
            {
                this.ucFeeForm1.DelRow();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }


        private void ucRegistrationTree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(OperationAppllication))
            {
                PatientInfo patient = (e.Node.Tag as OperationAppllication).PatientInfo;
                this.ucQueryInpatientNo1.Text = patient.PID.PatientNO;
                this.ucFeeForm1.OperationAppllication = e.Node.Tag as OperationAppllication;

            }
            else if (e.Node.Tag.GetType() == typeof(OperationRecord))
            {
                OperationAppllication application = (e.Node.Tag as OperationRecord).OperationAppllication;
                this.ucQueryInpatientNo1.Text = application.PatientInfo.PID.PatientNO;
                this.ucFeeForm1.OperationAppllication = application;
            }
            else if (e.Node.Tag.GetType() == typeof(AnaeRecord))
            {
                //OperationAppllication application = (e.Node.Tag as AnaeRecord).OperationAppllication;
                OperationAppllication application = (e.Node.Tag as AnaeRecord).OperationApplication;
                this.ucQueryInpatientNo1.Text = application.PatientInfo.PID.PatientNO;
                this.ucFeeForm1.OperationAppllication = application;
            }
        }

        private void tvGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Neusoft.HISFC.Models.Fee.ComGroup comGroup = new Neusoft.HISFC.Models.Fee.ComGroup();

            try
            {
                comGroup = e.Node.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
                if (comGroup == null)
                {
                    return;
                }
            }
            catch (Exception)
            {

                return;
            }

            this.ucFeeForm1.InsertGroup(comGroup.ID);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            if (ucQueryInpatientNo1.InpatientNo == "")
            {
                MessageBox.Show("没有该患者信息!", "提示");
                ucQueryInpatientNo1.Focus();
                return;
            }
            try
            {
                //手术申请实体类
                Neusoft.HISFC.Models.Operation.OperationAppllication apply = new Neusoft.HISFC.Models.Operation.OperationAppllication();
                //获取该患者手术信息


                frmSelectOps sel = new frmSelectOps(ucQueryInpatientNo1.InpatientNo);
                if (sel.ShowDialog() == DialogResult.OK)
                {
                    //if (sel.IsReg) //处理已经等过记的患者---费用补录
                    //{
                    //    if (!string.IsNullOrEmpty(sel.OpNo))
                    //    {
                    //        string operationNo = sel.OpNo; //Environment.OperationManager.GetMaxByPatient(ucQueryInpatientNo1.InpatientNo);
                    //        if (operationNo == null || operationNo == "")
                    //        {
                    //            MessageBox.Show("该患者没有进行手术!", "提示");
                    //            ucQueryInpatientNo1.Focus();
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            //根据手术序号获得手术实体
                    //            apply = Environment.OperationManager.GetOpsApp(operationNo);
                    //            //this.lblOpName.Text = string.Format("手术：{0}",apply.o
                    //        }
                    //        if (apply == null) return;
                    //        //读取手术项目信息
                    //        ucFeeForm1.OperationAppllication = apply;
                    //    }
                    //}
                    //else   //处理没有登记的
                    //{

                        
                    //}

                    if (!string.IsNullOrEmpty(sel.OpNo))
                    {
                        string operationNo = sel.OpNo; //Environment.OperationManager.GetMaxByPatient(ucQueryInpatientNo1.InpatientNo);
                        if (operationNo == null || operationNo == "")
                        {
                            MessageBox.Show("该患者没有进行手术排班,请先进行手术排班!", "提示");
                            ucQueryInpatientNo1.Focus();
                            return;
                        }
                        else
                        {
                            //根据手术序号获得手术实体
                            apply = Environment.OperationManager.GetOpsApp(operationNo);
                            //this.lblOpName.Text = string.Format("手术：{0}",apply.o
                        }
                        if (apply == null) return;
                        //读取手术项目信息
                        ucFeeForm1.IsReg = sel.IsReg;
                        ucFeeForm1.OperationAppllication = apply;
                    }
                }
                else { }
                //neusoft.HISFC.Management.Operator.Operator opMgr = new neusoft.HISFC.Management.Operator.Operator();

            }
            catch (Exception e)
            {
                MessageBox.Show("获取患者手术信息时出错!" + e.Message, "提示");
                ucQueryInpatientNo1.Focus();
                return;
            }
        }

        #endregion
    }
}
