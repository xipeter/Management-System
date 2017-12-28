using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术审请控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-28]<br></br>
    /// <修改记录
    ///		修改人='张俊义'
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的='完善手术申请'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucApplication : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucApplication()
        {
            InitializeComponent();
            this.Init();
            this.isSaveClose = false;
        }

        public ucApplication(PatientInfo patient, NeuObject item)
            : this()
        {
            this.ucQueryInpatientNo1.Text = patient.PID.PatientNO;
            this.ucApplicationForm1.PatientInfo = patient;
            this.ucApplicationForm1.MainOperation = item.Clone();

            this.isSaveClose = true;
        }

        #region 字段
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        private Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Dictionary<string, Department> depts = new Dictionary<string, Department>();

        private bool isSaveClose;   //是否保存后自动关闭

        private TreeNode currentNode;
        #endregion

        #region 属性
        [Category("控件设置"), Description("允许申请比当前时间早的手术")]
        public bool CheckApplyTime
        {
            get
            {
                return ucApplicationForm1.CheckApplyTime;
            }
            set
            {
                ucApplicationForm1.CheckApplyTime = value;
            }
        }
        [Category("控件设置"), Description("申请时间超过截止时间，是否需要改为急诊")]
        public bool CheckEmergency
        {
            get
            {
                return  ucApplicationForm1.CheckEmergency;
            }
            set
            {
                ucApplicationForm1.CheckEmergency = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.Operation.OperationAppllication OperationApplication
        {
            get
            {
                return this.ucApplicationForm1.OperationApplication;
            }

        }
        #endregion
        #region 方法
        /// <summary>
        /// 初使化
        /// </summary>
        private void Init()
        {
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员组));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印执行单));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.G顾客));
            this.BackColor = System.Drawing.Color.Azure;
            neuPanel1.BackColor = System.Drawing.Color.Azure;
            ucApplicationForm1.BackColor = System.Drawing.Color.Azure;
            //得到科室列表
            System.Collections.ArrayList alDepts = this.integrateManager.GetDepartment();
            foreach (Department dept in alDepts)
            {
                this.depts.Add(dept.ID, dept);
            }
        }

        /// <summary>
        /// 生成手术室申请单列表
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        private int RefreshApply(NeuObject dept)
        {
            tvApply.Nodes.Clear();
            TreeNode root = new TreeNode(dept.Name, 22, 22);
            root.Tag = "OPS";
            tvApply.Nodes.Add(root);

            DateTime begin = DateTime.MinValue, end = DateTime.MinValue;

            begin = this.neuDateTimePicker1.Value;
            end = this.neuDateTimePicker2.Value.AddDays(1);
            if (begin >= end)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示");
                return -1;
            }
            //检索手术室所有未登记的有效的申请单
            System.Collections.ArrayList al;
            al = Environment.OperationManager.GetOpsAppList(dept.ID, begin, end, "1");
            if (al != null)
            {
                foreach (Neusoft.HISFC.Models.Operation.OperationAppllication apply in al)
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Concat("[", this.depts[apply.PatientInfo.PVisit.PatientLocation.Dept.ID].Name, "]  ",
                        apply.PatientInfo.Name);
                    if (apply.OperateKind == "2")
                        node.Text = node.Text + "【急】";

                    if (apply.OperationInfos.Count > 0)
                        node.Text = node.Text + "——" + (apply.OperationInfos[0] as Neusoft.HISFC.Models.Operation.OperationInfo).OperationItem.Name;

                    if (apply.ExecStatus == "3")
                        node.Text = node.Text + "『已安排』";

                    node.Tag = apply;
                    node.ImageIndex = 20;
                    node.SelectedImageIndex = 21;
                    root.Nodes.Add(node);
                }
            }
            tvApply.ExpandAll();

            return 0;
        }

        /// <summary>
        /// 添加患者下的申请单列表
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        private int AddApply(NeuObject dept)
        {
            DateTime begin = DateTime.MinValue, end = DateTime.MinValue;
            if (this.GetDateTime(ref begin, ref end) == -1) return -1;
            //申请单列表
            ArrayList al = Environment.OperationManager.GetOpsAppList(dept, begin, end);
            foreach (TreeNode node in this.tvApply.Nodes[0].Nodes)
            {
                PatientInfo patient = node.Tag as PatientInfo;

                for (int i = al.Count - 1; i >= 0; i--)
                {
                    OperationAppllication apply = (OperationAppllication)al[i];
                    if (apply.PatientInfo.ID == patient.ID)
                    {
                        TreeNode child = new TreeNode();
                        if (apply.OperateKind == "2")
                        {
                            child.Text = "【急】";
                            child.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            child.ForeColor = System.Drawing.Color.Black;
                        }

                        if (apply.OperationInfos.Count > 0)
                            child.Text = child.Text + (apply.OperationInfos[0] as OperationInfo).OperationItem.Name;
                        if (apply.ExecStatus == "3") child.Text = child.Text + "『已安排』";
                        if (apply.ExecStatus == "4") child.Text = child.Text + "『已登记』";
                        if (apply.ExecStatus == "5") child.Text = child.Text + "『已取消登记』";
                        if (apply.IsValid == false) child.Text = child.Text + "『已取消申请』";
                        if (child.Text == "") child.Text = apply.PreDate.ToString();

                        child.Tag = apply;
                        child.ImageIndex = 2;
                        child.SelectedImageIndex = 2;
                        node.Nodes.Add(child);
                    }
                }
                node.Expand();
            }

            return 0;
        }

        /// <summary>
        /// 获取查询开始、结束时间
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int GetDateTime(ref DateTime begin, ref DateTime end)
        {
            DateTime d1, d2;
            d1 = this.neuDateTimePicker1.Value;
            d2 = this.neuDateTimePicker2.Value.AddDays(1);

            if (d1 > d2)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示");
                return -1;
            }
            begin = d1;
            end = d2;

            return 0;
        }

        #endregion

        #region 事件

        protected override void OnLoad(EventArgs e)
        {
            Department dept = this.integrateManager.GetDepartment(Environment.OperatorDeptID);

            if (dept.SpecialFlag == "1")    //手术科室，生成该手术室的全部申请单
            {
                this.RefreshApply(Environment.OperatorDept);
            }
            else                           //非手术科室，生成该科室下申请单
            {
                Neusoft.HISFC.BizProcess.Integrate.RADT manager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
                string deptID = dept.ID;
                ArrayList alPatients = manager.QueryPatient(deptID, Neusoft.HISFC.Models.Base.EnumInState.I);

                this.tvApply.Nodes.Clear();
                TreeNode root = new TreeNode();
                root.Text = "本科患者";
                this.tvApply.Nodes.Add(root);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in alPatients)
                {

                    TreeNode node = new TreeNode();
                    

                    string bedNO = "["+patient.PVisit.PatientLocation.Bed.ID.Substring(4,patient.PVisit.PatientLocation.Bed.ID.Length -4) + "]";
                    string patientNO = "[" + patient.PID.PatientNO + "]";

                    node.Text = bedNO + "-" + patientNO + patient.Name;

                    if (patient.Sex.ID.ToString() == "M")
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                    }
                    else
                    {
                        node.ImageIndex = 3;
                        node.SelectedImageIndex = 3;
                    }
                    node.Tag = patient;
                    root.Nodes.Add(node);
                }
                this.AddApply(Environment.OperatorDept);
                tvApply.ExpandAll();
            }

            base.OnLoad(e);
        }

        private void neuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tvPatientList1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            //if (e.Node.Tag.GetType() == typeof(PatientInfo))
            //{
            //    PatientInfo patient = e.Node.Tag as PatientInfo;
            //    this.ucQueryInpatientNo1.Text = patient.PID.PatientNO;
            //    this.ucApplicationForm1.PatientInfo = patient;
            //}
            //else if (e.Node.Tag.GetType() == typeof(OperationAppllication))
            //{
            //    OperationAppllication application = e.Node.Tag as OperationAppllication;
            //    this.ucQueryInpatientNo1.Text = application.PatientInfo.PID.PatientNO;
            //    this.ucApplicationForm1.OperationApplication = application;

            //    this.currentNode = e.Node;
            //}
            if (e.Node.Tag.GetType() == typeof(PatientInfo))
            {
                PatientInfo patient = e.Node.Tag as PatientInfo;
                if (patient.PVisit.InState.ID.ToString() != "N" && patient.PVisit.InState.ID.ToString() != "O")
                {
                    this.ucApplicationForm1.PatientInfo = patient;
                    this.ucQueryInpatientNo1.Text = patient.PID.PatientNO;
                }
                else
                {
                    MessageBox.Show("患者不是在院状态！");

                }
                //this.ucQueryInpatientNo1.Text = patient.PID.PatientNO;
                //this.ucApplicationForm1.PatientInfo = patient;
            }
            else if (e.Node.Tag.GetType() == typeof(OperationAppllication))
            {
                OperationAppllication application = e.Node.Tag as OperationAppllication;
                if (application.PatientInfo.PVisit.InState.ID.ToString() != "N" && application.PatientInfo.PVisit.InState.ID.ToString() != "O")
                {
                    this.ucQueryInpatientNo1.Text = application.PatientInfo.PID.PatientNO;
                    this.ucApplicationForm1.OperationApplication = application;
                    this.currentNode = e.Node;
                }
                else
                {
                    MessageBox.Show("患者不是在院状态！");
                }

            }//{757094AC-55CD-428c-8C81-BB1F3F76172D}
        }

        public override int Save(object sender, object neuObject)
        {
            if (this.ucApplicationForm1.Save() >= 0)
            {
                //this.ucApplicationForm1.OperationApplication = new OperationAppllication();
                this.Query(sender, neuObject);
            }

            if ((!this.ucApplicationForm1.IsNew) && this.currentNode != null)
            {
                //{924DB426-6487-4bde-9365-48E3C496DA19}
                //this.currentNode.Text = this.ucApplicationForm1.OperationApplication.MainOperationName;
                //this.currentNode = null;
            }

            if (this.isSaveClose)
            {
                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
            }


            return base.Save(sender, neuObject);
        }

        public override int Query(object sender, object neuObject)
        {
            this.OnLoad(null);
            return base.Query(sender, neuObject);
        }
        public override int Print(object sender, object neuObject)
        {
            return this.ucApplicationForm1.Print();
        }
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("作废", "作废", 1, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "作废")
            {
                if (this.ucApplicationForm1.Cancel() >= 0)
                {
                    this.OnLoad(null);
                }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }


        private void ucQueryInpatientNo1_myEvent()
        {
            if (ucQueryInpatientNo1.InpatientNo == "")
            {
                MessageBox.Show("没有该患者信息!", "提示");
                ucQueryInpatientNo1.Focus();
                return;
            }

            PatientInfo patient = Environment.RadtManager.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);
            //{757094AC-55CD-428c-8C81-BB1F3F76172D}
            //this.ucApplicationForm1.PatientInfo = patient;
            if (patient.PVisit.InState.ID.ToString() != "N" && patient.PVisit.InState.ID.ToString() != "O")
            {
                this.ucApplicationForm1.PatientInfo = patient;
            }
            else
            {
                MessageBox.Show("患者不是在院状态！");

            }
        }

        #endregion

        private void neuDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime begin = DateTime.MinValue, end = DateTime.MinValue;

            begin = this.neuDateTimePicker1.Value;
            end = this.neuDateTimePicker2.Value.AddDays(1);
            if (begin >= end)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示");

            }
        }
    }
}
