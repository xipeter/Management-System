using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    /// <summary>
    /// 【功能说明：】
    /// 【创建人：】
    /// 【创建时间：】
    /// 【修改记录】
    ///   2009-8-24 xuc 增加可以选择多科室多患者查询功能 {EA2A7657-6A55-4582-8052-DC7F8A5A4795}
    /// 
    /// 
    /// </summary>
    public partial class ucFinIpbPatientDayFeeAndQfList : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbPatientDayFeeAndQfList()
        {
            InitializeComponent();
        }


        #region 变量
        /// <summary>
        /// 业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient managerIntegrate = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        //Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 是否显示全院患者
        /// </summary>
        bool isShowAllInDeptPatient = false;
        /// <summary>
        /// 是否显示全院患者
        /// </summary>
        public bool IsShowAllInDeptPatient
        {
            get
            {
                return isShowAllInDeptPatient;
            }
            set
            {
                isShowAllInDeptPatient = value;
            }
        }

        #endregion



        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbType.Text == "按指定标准")
            {
                this.labShow.Text = "指标：";
                this.labShow.Visible = true;
                this.txtAlert.Visible = true;
                this.labPercent.Visible = false;
                //this.lblInfo.Text = "(可用余额 < " + this.txtAlert.Text + ")";
            }
            else if (this.cmbType.Text == "按比例")
            {
                this.labShow.Text = "比例：";
                this.labShow.Visible = true;
                this.txtAlert.Visible = true;
                this.labPercent.Visible = true;
                //this.lblInfo.Text = "(余额 / 预交金 <= " + this.txtAlert.Text + "%)";
            }
            else if (this.cmbType.Text == "按最底下限")
            {
                this.labShow.Visible = false;
                this.txtAlert.Visible = false;
                this.labPercent.Visible = false;
                //this.lblInfo.Text = "(按最低下限统计)";
            }
        }

        private void txtAlert_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbType.Text == "按指定标准")
            {
                this.labShow.Text = "指标：";
                this.labShow.Visible = true;
                this.txtAlert.Visible = true;
                this.labPercent.Visible = false;
                //this.lblInfo.Text = "(可用余额 < " + this.txtAlert.Text + ")";
            }
            else if (this.cmbType.Text == "按比例")
            {
                this.labShow.Text = "比例：";
                this.labShow.Visible = true;
                this.txtAlert.Visible = true;
                this.labPercent.Visible = true;
                //this.lblInfo.Text = "(余额 / 预交金 <= " + this.txtAlert.Text + "%)";
            }
            else if (this.cmbType.Text == "按最底下限")
            {
                this.labShow.Visible = false;
                this.txtAlert.Visible = false;
                this.labPercent.Visible = false;
                //this.lblInfo.Text = "(按最低下限统计)";
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
                this.txtAlert.Text = "100000";
            else
                this.txtAlert.Text = "0";

            //this.RefreshList(NurseCode.ID);
        }


         /// <summary>
        /// 更新显示数据信息
        /// </summary>
        /// <param name="myNurse"></param>
        public void RefreshList(string myNurse)
        {
             ArrayList list = new ArrayList();
             try
             {
                 if (this.cmbType.Text == "按指定标准")
                 {
                     //this.dwMain.DataWindowObject.

                 }
                 else if (this.cmbType.Text == "按比例")
                 {

                 }
                 else if (this.cmbType.Text == "按最底下限")
                 {

                 }
             }
             catch (Exception e)
             {
                 MessageBox.Show(e.Message);
                 return;
             }

        }

        /// <summary>
        ///初始化树
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            base.OnDrawTree();

            this.tvLeft.Nodes.Clear();

            //左侧多选
            this.tvLeft.CheckBoxes = true;

            if (isShowAllInDeptPatient == false)
            {
                //在院患者
                Neusoft.HISFC.Models.RADT.InStateEnumService inState = new Neusoft.HISFC.Models.RADT.InStateEnumService();
                inState.ID = Neusoft.HISFC.Models.Base.EnumInState.I.ToString();

                ArrayList emplList = managerIntegrate.QueryPatientBasic(base.employee.Dept.ID, inState);

                TreeNode parentTreeNode = new TreeNode("本科患者");
                parentTreeNode.Checked = false;
                parentTreeNode.Tag = "ROOT";
                tvLeft.Nodes.Add(parentTreeNode);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo empl in emplList)
                {
                    TreeNode emplNode = new TreeNode();
                    emplNode.Tag = empl;
                    emplNode.Text = empl.Name;
                    parentTreeNode.Nodes.Add(emplNode);
                }

                parentTreeNode.ExpandAll();
                parentTreeNode.Checked = false;
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载全院患者列表，请稍等......");
                Application.DoEvents();


                //全院患者列表
                //在院患者
                ArrayList emplList = managerIntegrate.QueryPatient(Neusoft.HISFC.Models.Base.EnumInState.I);

                //构建树列表
                Dictionary<string, TreeNode> deptDic = new Dictionary<string, TreeNode>();

                TreeNode parentTreeNode = new TreeNode("全院患者");
                
                parentTreeNode.Tag = "ROOT";
                tvLeft.Nodes.Add(parentTreeNode);
                int index = 0;
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo empl in emplList)
                {
                    if (deptDic.ContainsKey(empl.PVisit.PatientLocation.Dept.ID))
                    {
                        TreeNode patient = new TreeNode();
                        patient.Tag = empl;
                        patient.Text = empl.Name + "【" + empl.PID.PatientNO.ToString() + "】";

                        patient.Checked = false;
                        deptDic[empl.PVisit.PatientLocation.Dept.ID].Nodes.Add(patient);
                    }
                    else
                    {
                        TreeNode dept = new TreeNode();
                        dept.ForeColor = Color.Blue;
                        dept.Tag = empl.PVisit.PatientLocation.Dept;
                        dept.Text = empl.PVisit.PatientLocation.Dept.Name + "【" + empl.PVisit.PatientLocation.Dept.ID.ToString() + "】";
                        
                        TreeNode patient = new TreeNode();
                        patient.Tag = empl;
                        patient.Text = empl.Name + "【" + empl.PID.PatientNO.ToString()+"】";
                        patient.Checked = false;
                        dept.Nodes.Add(patient);
                        deptDic.Add(empl.PVisit.PatientLocation.Dept.ID, dept);

                        dept.Checked = false;
                        parentTreeNode.Nodes.Add(dept);
                    }
                    index++;
                }
                parentTreeNode.ExpandAll();
                parentTreeNode.Checked = false;


                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            

            

            this.tvLeft.AfterSelect -= new TreeViewEventHandler(tvLeft_AfterSelect);
            this.tvLeft.AfterSelect += new TreeViewEventHandler(tvLeft_AfterSelect);
            this.tvLeft.AfterCheck -= new TreeViewEventHandler(tvLeft_AfterCheck);
            this.tvLeft.AfterCheck += new TreeViewEventHandler(tvLeft_AfterCheck);

            return 1;
        }
        /// <summary>
        /// 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tvLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                e.Node.Checked = !e.Node.Checked;
            }
        }
        /// <summary>
        /// 勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tvLeft_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                bool isCheck = e.Node.Checked;
                this.SelectPatient(e.Node, isCheck);
            }
        }



        /// <summary>
        /// 勾选患者
        /// </summary>
        /// <param name="treeNode"></param>
        private void SelectPatient(TreeNode treeNode, bool isCheck)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = isCheck;
                SelectPatient(node, isCheck);
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            List<string> inpatientLine = new List<string>();
            GetPatients(this.tvLeft.Nodes[0], inpatientLine);
            if (inpatientLine.Count <= 0)
            {
                MessageBox.Show("请选择患者");
                return -1;
            }
            string[] inpatient = inpatientLine.ToArray();
            
            return base.OnRetrieve(inpatient, this.beginTime, this.endTime, "ALL",this.employee.Name);
        }

        /// <summary>
        /// 递归获取选择的患者
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="inpatientLine"></param>
        void GetPatients(TreeNode nodes, List<string> inpatientLine)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                if (node.Checked && node.Tag is Neusoft.HISFC.Models.RADT.PatientInfo)
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patient = node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                    inpatientLine.Add(patient.ID);
                }
                GetPatients(node, inpatientLine);
            }
        }



        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.dwMain != null)
            {
                this.dwMain.Print(true, true);
            }

            return 1;
        }
    }
}

