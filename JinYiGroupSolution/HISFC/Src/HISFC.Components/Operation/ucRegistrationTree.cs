using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Neusoft.HISFC.Models.Operation;
using Neusoft.HISFC.BizLogic.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术登记单列表树形控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegistrationTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public ucRegistrationTree()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
                this.Init();
        }

        public ucRegistrationTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            if (!Environment.DesignMode)
                this.Init();
        }



        #region 字段
        private EnumListType listType = EnumListType.Operation;
        private bool showCanceled = true;

        //{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
        private Neusoft.HISFC.BizProcess.Integrate.Manager deptStatMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region 属性
        /// <summary>
        /// 列表类型
        /// </summary>
        public EnumListType ListType
        {
            get
            {
                return this.listType;
            }
            set
            {
                this.listType = value;
            }
        }

        /// <summary>
        /// 是否显示已经取消的手术
        /// </summary>
        public bool ShowCanceled
        {
            get
            {
                return this.showCanceled;
            }
            set
            {
                this.showCanceled = value;
                if (value == false)
                {
                    if (this.Nodes.Count > 2)
                    {
                        this.Nodes[2].Remove();
                    }
                }
            }
        }
        #endregion

        #region 方法
        //{8DA8B1D6-DDD6-4329-B661-F4BDAE45DB66}
        public void Init()
        {
            this.Nodes.Clear();
            //显示未登记手术、已登记、已取消手术
            ////{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
            string listName = "手术";
            if (listType == EnumListType.Anaesthesia)
            {
                listName = "麻醉";
            }
            ////{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
            //TreeNode root = new TreeNode("未登记手术");
            TreeNode root = new TreeNode("未登记" + listName);
            root.SelectedImageIndex = 22;
            root.ImageIndex = 22;
            root.Tag = "NO_Register";
            this.Nodes.Add(root);

            //root = new TreeNode("已登记手术");
            root = new TreeNode("已登记" + listName);
            root.SelectedImageIndex = 22;
            root.ImageIndex = 22;
            root.Tag = "Register";
            this.Nodes.Add(root);

            //{D31ECFF1-2BC5-4770-A1BF-1093B5B9B315}
            if (this.listType == EnumListType.Operation)
            {
                root = new TreeNode("已取消手术");
                root.SelectedImageIndex = 22;
                root.ImageIndex = 22;
                root.Tag = "Cancel";
                this.Nodes.Add(root);
            }
        }

        /// <summary>
        /// 刷新手术登记列表
        /// </summary>
        public void RefreshList(DateTime begin, DateTime end)
        {

            this.RefreshListNotReg(begin, end);

            this.RefreshListReged(begin, end);
            //{8DA8B1D6-DDD6-4329-B661-F4BDAE45DB66}
            //if(this.showCanceled)
            if (this.Nodes.Count > 2)
            {
                this.RefreshListCanceled(begin, end);
            }

        }

        /// <summary>
        /// 刷新未登记手术列表
        /// </summary>
        private void RefreshListNotReg(DateTime begin, DateTime end)
        {
            this.Nodes[0].Nodes.Clear();

            #region 未登记
            ArrayList al;

            if (this.listType == EnumListType.Operation)
                al = Environment.OperationManager.GetOpsAppList(Environment.OperatorDeptID, begin, end, true);
            else
            {

                //{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}

                ArrayList alTemp = Environment.OperationManager.GetOpsAppList(begin, end, "1");
                al = new ArrayList();

                foreach (OperationAppllication apply in alTemp)
                {

                    if (apply.ExecStatus != "3" && apply.ExecStatus == "4") //没有安排的手术和没有登记的不显示
                    {
                        continue;
                    }
                    // 载入手术室麻醉室关系，进行过滤；只能过滤出本科室上面对应的手术室的申请

                    ArrayList alAnesDepts = this.deptStatMgr.LoadChildren("10", apply.ExeDept.ID, 1);
                    if (alAnesDepts == null)
                    {
                        MessageBox.Show("查找科室对应关系时出错：" + this.deptStatMgr.Err);
                        return;
                    }
                    if (alAnesDepts.Count == 0)
                    {
                        //Neusoft.HISFC.BizProcess.Integrate.Manager depMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                        //apply.ExeDept.Name = depMgr.GetDepartment(apply.ExeDept.ID).Name;
                        //MessageBox.Show("手术科室：“" + apply.ExeDept.Name + "”找不到与麻醉室的对应关系，请在科室结构树中维护！");
                        //return ;
                        continue;
                    }
                    foreach (Neusoft.HISFC.Models.Base.DepartmentStat deptStat in alAnesDepts)
                    {
                        #region {2F58330D-0BEC-4a68-AE06-6C2868CFE545}
                        //{E4C275E8-6E12-4a42-A60A-0EB9A8CB52BD}
                        if (deptStat.DeptCode == (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                        {
                            al.Add(apply);
                        }
                        //if (deptStat.PardepCode == (this.deptStatMgr.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                        //{
                        //    this.ucAnaesthesiaSpread1.AddOperationApplication(apply);
                        //    break;
                        //}
                        #endregion
                    }
                }



            }

            if (al != null)
            {
                foreach (OperationAppllication apply in al)
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Concat("[", Environment.GetDept(apply.PatientInfo.PVisit.PatientLocation.Dept.ID),
                        "] ", apply.PatientInfo.Name);
                    if (apply.OperationInfos.Count > 0)
                        node.Text = node.Text + "   " + (apply.OperationInfos[0] as OperationInfo).OperationItem.Name;
                    node.Tag = apply;
                    node.SelectedImageIndex = 21;
                    node.ImageIndex = 20;
                    this.Nodes[0].Nodes.Add(node);
                }
            }
            #endregion

            this.Nodes[0].Expand();
        }


        /// <summary>
        /// 刷新已登记手术记录
        /// </summary>
        private void RefreshListReged(DateTime begin, DateTime end)
        {
            this.Nodes[1].Nodes.Clear();

            #region 已登记

            ArrayList al;
            if (this.listType == EnumListType.Operation)
            {
                al = Environment.RecordManager.GetOperatorRecords(Environment.OperatorDeptID, begin, end);
                if (al != null)
                {
                    foreach (OperationRecord record in al)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = "[" + Environment.GetDept(record.OperationAppllication.PatientInfo.PVisit.PatientLocation.Dept.ID) +
                            "] " + record.OperationAppllication.PatientInfo.Name;

                        if (record.OperationAppllication.OperationInfos.Count > 0)
                            node.Text = node.Text + "   " + record.OperationAppllication.OperationInfos[0].OperationItem.Name;
                        node.Tag = record;
                        node.SelectedImageIndex = 21;
                        node.ImageIndex = 20;
                        this.Nodes[1].Nodes.Add(node);
                    }
                }
            }
            else
            {
                al = Environment.AnaeManager.GetAnaeRecords(Environment.OperatorDeptID, begin, end);



                if (al != null)
                {



                    foreach (Neusoft.HISFC.Models.Operation.AnaeRecord record in al)
                    {

                        // //{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}载入手术室麻醉室关系，进行过滤；只能过滤出本科室上面对应的手术室的申请

                        ArrayList alAnesDepts = this.deptStatMgr.LoadChildren("10", record.OperationApplication.ExeDept.ID, 1);
                        if (alAnesDepts == null)
                        {
                            MessageBox.Show("查找科室对应关系时出错：" + this.deptStatMgr.Err);
                            return;
                        }
                        if (alAnesDepts.Count == 0)
                        {
                            continue;
                        }
                        foreach (Neusoft.HISFC.Models.Base.DepartmentStat deptStat in alAnesDepts)
                        {

                            //{E4C275E8-6E12-4a42-A60A-0EB9A8CB52BD}
                            if (deptStat.DeptCode == (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                            {

                                TreeNode node = new TreeNode();
                                node.Text = "[" + Environment.GetDept(record.OperationApplication.PatientInfo.PVisit.PatientLocation.Dept.ID) +
                                    "] " + record.OperationApplication.PatientInfo.Name;

                                if (record.OperationApplication.OperationInfos.Count > 0)
                                    node.Text = node.Text + "   " + record.OperationApplication.OperationInfos[0].OperationItem.Name;
                                node.Tag = record;
                                node.SelectedImageIndex = 21;
                                node.ImageIndex = 20;
                                this.Nodes[1].Nodes.Add(node);
                            }
                        }


                    }
                }
            }

            #endregion

            this.Nodes[1].Expand();
        }


        /// <summary>
        /// 刷新作废手术申请单
        /// </summary>
        private void RefreshListCanceled(DateTime begin, DateTime end)
        {
            this.Nodes[2].Nodes.Clear();

            ArrayList al;

            if (this.listType == EnumListType.Operation)
                //al = Environment.OperationManager.GetOpsAppList(Environment.OperatorDeptID, begin, end, "0");
                al = Environment.OperationManager.GetOpsCancelRecord(Environment.OperatorDeptID, begin, end);
            else
                al = Environment.OperationManager.GetOpsAppList(begin, end, "0");

            if (al != null)
            {
                foreach (OperationAppllication apply in al)
                {
                    TreeNode node = new TreeNode();
                    node.Text = "[" + Environment.GetDept(apply.PatientInfo.PVisit.PatientLocation.Dept.ID) +
                        "] " + apply.PatientInfo.Name;

                    if (apply.OperationInfos.Count > 0)
                        node.Text = node.Text + "   " + apply.OperationInfos[0].OperationItem.Name;

                    node.Tag = apply;
                    node.ForeColor = Color.Red;
                    node.SelectedImageIndex = 21;
                    node.ImageIndex = 20;
                    this.Nodes[2].Nodes.Add(node);
                }
            }
        }
        #endregion


        /// <summary>
        /// 列表类型
        /// </summary>
        public enum EnumListType
        {
            /// <summary>
            /// 手术
            /// </summary>
            Operation,
            /// <summary>
            /// 麻醉
            /// </summary>
            Anaesthesia
        }
    }
}
