using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// [控件名称: 住院领药单查询,无锡移植]
    /// [创 建 者: 张林]
    /// [创建时间: 2010-8-10]
    /// </summary>
    public partial class ucQueryDrugList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucQueryDrugList()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 树控件显示的节点类型
        /// </summary>
        private NodeType treeNodeType = NodeType.NurseCell;

        /// <summary>
        /// 摆药查询范围
        /// </summary>
        private QueryRange queryDrugRange = QueryRange.AllDrug;        

        /// <summary>
        /// 是否允许按药品过滤
        /// </summary>
        private bool isFiterByDrug = false;

        /// <summary>
        /// 是否格式化列宽
        /// </summary>
        private bool isFormatColumn = true;

        /// <summary>
        /// 报表标题
        /// </summary>
        private string reportTitle = "住院领药单";

        /// <summary>
        /// 科室列表
        /// </summary>
        private string argDept = "";

        /// <summary>
        /// 查询结果集
        /// </summary>
        System.Data.DataTable dsDrugList = new DataTable();

        /// <summary>
        /// 是否查询时树节点自动展开
        /// </summary>
        private bool isTreeExpandAll = true;

        /// <summary>
        /// 是否显示无效的数据
        /// </summary>
        private bool isShowInvalidData = false;

        /// <summary>
        /// 是否对查询信息颜色提示
        /// </summary>
        private bool isHintColor = false;

        /// <summary>
        /// 基本信息管理业务类
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 药房管理业务类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugstoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        Neusoft.HISFC.BizLogic.Pharmacy.Item drugItem = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 药品常数业务类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Constant conManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint printInterface = null;
        Neusoft.HISFC.Models.Pharmacy.DrugBillClass billClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
        #endregion

        #region 属性

        /// <summary>
        /// 树控件显示的节点类型
        /// </summary>
        [Description("树控件显示的节点类型"),Category("树设置"),DefaultValue(ucQueryDrugList.NodeType.NurseCell)]
        public NodeType TreeNodeType
        {
            get 
            { 
                return treeNodeType; 
            }
            set 
            { 
                treeNodeType = value;
            }
        }

        /// <summary>
        /// 摆药查询范围
        /// </summary>
        [Description("摆药查询范围"), Category("设置"), DefaultValue(ucQueryDrugList.QueryRange.NoneDrug)]
        public QueryRange QueryDrugRange
        {
            get 
            {
                return queryDrugRange; 
            }
            set 
            { 
                queryDrugRange = value; 
            }
        }

        /// <summary>
        /// 是否允许按药品过滤
        /// </summary>
        [Description("是否允许按药品过滤"), Category("设置"), DefaultValue(false)]
        public bool IsFiterByDrug
        {
            get 
            { 
                return isFiterByDrug; 
            }
            set 
            { 
                isFiterByDrug = value; 
            }
        }

        /// <summary>
        /// 是否格式化列宽
        /// </summary>
        [Description("是否格式化列宽"), Category("列表设置"), DefaultValue(true)]
        public bool IsFormatColumn
        {
            get 
            { 
                return isFormatColumn; 
            }
            set 
            { 
                isFormatColumn = value; 
            }
        }

        /// <summary>
        /// 是否查询时树节点自动展开
        /// </summary>
        [Description("是否初始化树时节点自动展开"), Category("树设置"), DefaultValue(true)]
        public bool IsTreeExpandAll
        {
            get 
            { 
                return isTreeExpandAll; 
            }
            set 
            { 
                isTreeExpandAll = value; 
            }
        }

        /// <summary>
        /// 报表标题
        /// </summary>
        [Description("报表标题"), Category("列表设置"), DefaultValue("无锡二院住院领药单")]
        public string ReportTitle
        {
            get 
            { 
                return reportTitle; 
            }
            set 
            { 
                reportTitle = value;
                this.lbTitle.Text = reportTitle;
            }
        }

        /// <summary>
        /// 是否显示无效的数据
        /// </summary>
        [Description("是否显示无效的数据"), Category("设置"), DefaultValue(false)]
        public bool IsShowInvalidData
        {
            get 
            {
                return isShowInvalidData;
            }
            set 
            { 
                isShowInvalidData = value; 
            }
        }

        /// <summary>
        /// 是否对查询信息颜色提示
        /// </summary>
        [Description("是否对查询信息颜色提示"), Category("列表设置"), DefaultValue(false)]
        public bool IsHintColor
        {
            get 
            { 
                return isHintColor;
            }
            set 
            { 
                isHintColor = value; 
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void IniControls()
        {
            if (this.IsFiterByDrug)
            {
                this.neuPanel5.Visible = true;
            }
            else
            {
                this.neuPanel5.Visible = false;
            }

            if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
            {
                this.neuPanel6.Visible = false;
            }
            else
            {
                this.neuPanel6.Visible = true;
            }

            this.cbbPharmacy.Items.Clear();
            ArrayList al = new ArrayList();
            //al = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PHARMACYTYPE);            
            this.cbbPharmacy.AddItems(al);
            this.cbbPharmacy.Items.Insert(0, "");
            this.neuLabel8.Visible = false;
            this.cbbPharmacy.Visible = false;
            this.IniTreeView();
            this.cmbState.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        private void IniTreeView()
        {
            if (this.treeNodeType == NodeType.NurseCell)
            {
                //获取当前登陆科室所在的病区
                Neusoft.FrameWork.Models.NeuObject nurseObj = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Nurse;
                this.tvSelectType.Nodes.Add("病区（" + nurseObj.Name + "）");
                this.tvSelectType.Nodes[0].Tag = nurseObj.ID;
                ////查询本病区下包含的科室列表
                //ArrayList alDept = managerIntegrate.QueryNurseStationByDept(nurseObj);
                //for (int i = 0; i < alDept.Count; i++)
                //{
                //    Neusoft.FrameWork.Models.NeuObject tempObj = alDept[i] as Neusoft.FrameWork.Models.NeuObject;
                //    if (argDept == "")
                //    {
                //        argDept = tempObj.ID;
                //    }
                //    else
                //    {
                //        argDept = argDept + "','" + tempObj.ID;
                //    }
                //}
                ArrayList alBills = new ArrayList();
                if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                {
                    alBills = this.drugstoreManager.QueryBillListByDept(nurseObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "0", "0");
                }
                else if (this.QueryDrugRange == ucQueryDrugList.QueryRange.Druged)
                {
                    alBills = this.drugstoreManager.QueryBillListByDept(nurseObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "1", "1");
                }
                else
                {
                    alBills = this.drugstoreManager.QueryBillListByDept(nurseObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "0", "2");
                }
                for (int j = 0; j < alBills.Count; j++)
                {
                    Neusoft.FrameWork.Models.NeuObject billObj = alBills[j] as Neusoft.FrameWork.Models.NeuObject;
                    TreeNode tempTN = new TreeNode();
                    tempTN.Text = billObj.Name;
                    tempTN.Tag = billObj.ID;
                    tempTN.ToolTipText = "摆药单";
                    this.tvSelectType.Nodes[0].Nodes.Add(tempTN);
                }
            }
            else if (this.treeNodeType == NodeType.NurseDept)
            {
                //获取当前登陆科室所在的病区
                Neusoft.FrameWork.Models.NeuObject nurseObj = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Nurse;
                //Neusoft.FrameWork.Models
                this.tvSelectType.Nodes.Add("病区（" + nurseObj.Name + "）");
                //查询本病区下包含的科室列表
                ArrayList alDept = managerIntegrate.QueryDepartment(nurseObj.ID);
                for (int i = 0; i < alDept.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject deptObj = alDept[i] as Neusoft.FrameWork.Models.NeuObject;
                    TreeNode tempDeptNode = new TreeNode();
                    tempDeptNode.Text = deptObj.Name;
                    tempDeptNode.Tag = deptObj.ID;
                    tempDeptNode.ToolTipText = "科室";

                    this.tvSelectType.Nodes[0].Nodes.Add(tempDeptNode);
                    if (argDept == "")
                    {
                        argDept = deptObj.ID;
                    }
                    else
                    {
                        argDept = argDept + "','" + deptObj.ID;
                    }

                    ArrayList alBills = new ArrayList();
                    if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                    {
                        alBills = this.drugstoreManager.QueryBillListByDept(deptObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "0", "0");
                    }
                    else if (this.QueryDrugRange == ucQueryDrugList.QueryRange.Druged)
                    {
                        alBills = this.drugstoreManager.QueryBillListByDept(deptObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "1", "1");
                    }
                    else
                    {
                        alBills = this.drugstoreManager.QueryBillListByDept(deptObj.ID, this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.ToString(), "0", "2");
                    }
                    for (int j = 0; j < alBills.Count; j++)
                    {
                        Neusoft.FrameWork.Models.NeuObject billObj = alBills[j] as Neusoft.FrameWork.Models.NeuObject;
                        TreeNode tempTN = new TreeNode();
                        tempTN.Text = billObj.Name;
                        tempTN.Tag = billObj.ID;
                        tempTN.ToolTipText = "摆药单";
                        this.tvSelectType.Nodes[0].Nodes[i].Nodes.Add(tempTN);
                    }
                    //ArrayList alBills = this.drugstoreManager.QueryBillListByDept(deptObj.ID,);
                }                
            }
            else if (this.treeNodeType == NodeType.Dept)
            {
                //获取所有住院科室
                ArrayList alInDept = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                for (int i = 0; i < alInDept.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject deptObj = alInDept[i] as Neusoft.FrameWork.Models.NeuObject;
                    this.tvSelectType.Nodes.Add(deptObj.Name);
                } 
            }
            else if (this.treeNodeType == NodeType.Pharmacy)
            {
                //获取当前登陆科室所在的病区
                Neusoft.FrameWork.Models.NeuObject nurseObj = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept;                
                this.tvSelectType.Nodes.Add("科室（" + nurseObj.Name + "）");
                ArrayList alPharmacy = this.conManager.QueryReciveDrugDept(nurseObj.ID);
                for (int i = 0; i < alPharmacy.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject deptObj = alPharmacy[i] as Neusoft.FrameWork.Models.NeuObject;
                    this.tvSelectType.Nodes[0].Nodes.Add(deptObj.Name);
                }
            }
            else
            {
                //获取当前登陆科室所在的病区
                Neusoft.FrameWork.Models.NeuObject nurseObj = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept;
                this.tvSelectType.Nodes.Add("科室（" + nurseObj.Name + "）");
            }

            //判断属性是否自动展开树节点
            if (this.IsTreeExpandAll)
            {
                this.tvSelectType.ExpandAll();
            }
        }

        /// <summary>
        /// 查询领药单信息
        /// </summary>
        private void QueryDrugList()
        {
            this.ClearData();
            if (this.tvSelectType.SelectedNode != null)
            {
                if (this.tvSelectType.SelectedNode.ToolTipText == "摆药单")
                {
                    //{B5A791DF-585A-4763-96CE-8A9F11037D8B}feng.ch
                    if (this.rbTotal.Checked)
                    {
                        if (this.cmbState.Text == "已摆")
                        {
                            //{B8C09481-AE37-4b0f-A24A-96B9038003F0} 席宗飞 modifid in 2010-9-21
                            //this.dsDrugList = this.drugstoreManager.QueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //  this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "2");
                            //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                            this.dsDrugList = this.drugstoreManager.LocalQueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                              this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "2");
                        }
                        else
                        {
                            if (this.cmbState.Text == "未摆")
                            {
                                //this.dsDrugList = this.drugstoreManager.QueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                //  this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0,1");
                                //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                                this.dsDrugList = this.drugstoreManager.LocalQueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                  this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "0,1");
                            }
                            //if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                            //{
                            //    this.dsDrugList = this.drugstoreManager.QueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //        this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0", "0,1");
                            //}
                            //else if (this.QueryDrugRange == ucQueryDrugList.QueryRange.Druged)
                            //{
                            //    //this.dsDrugList = new DataTable();
                            //    this.dsDrugList = this.drugstoreManager.QueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //        this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "1", "2");
                            //}
                            else
                            {
                                //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                                //this.dsDrugList = this.drugstoreManager.QueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                //    this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0,1,2");
                                this.dsDrugList = this.drugstoreManager.LocalQueryDrugTotalByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                    this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "0,1,2");
                            }
                        }
                        this.lbTitle.Text = ReportTitle + "（汇总）";
                    }
                    else
                    {
                        //{B5A791DF-585A-4763-96CE-8A9F11037D8B}feng.ch
                        if (this.cmbState.Text == "未摆")
                        {
                            //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                            //this.dsDrugList = this.drugstoreManager.QueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0,1");
                            this.dsDrugList = this.drugstoreManager.LocalQueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "0,1");
                        }
                        else
                        {
                            if (this.cmbState.Text == "已摆")
                            {
                                //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                                //this.dsDrugList = this.drugstoreManager.QueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                //this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "2");
                                this.dsDrugList = this.drugstoreManager.LocalQueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "2");
                            }
                            //if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                            //{
                            //    this.dsDrugList = this.drugstoreManager.QueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //        this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0", "0,1");
                            //}
                            //else if (this.QueryDrugRange == ucQueryDrugList.QueryRange.Druged)
                            //{
                            //    this.dsDrugList = this.drugstoreManager.QueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                            //        this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "1", "2");
                            //}
                            else
                            {
                                //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
                                //this.dsDrugList = this.drugstoreManager.QueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                //    this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "0,1,2");
                                this.dsDrugList = this.drugstoreManager.LocalQueryDrugDetailByDept(this.tvSelectType.SelectedNode.Tag.ToString(),
                                    this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.ToString(), this.dtpEndDate.Value.ToString(), "0,1,2");
                            }
                        }
                        this.lbTitle.Text = ReportTitle + "（明细）";
                    }
                    this.lbDept.Text = this.tvSelectType.SelectedNode.Parent.Text;
                    this.lbBillType.Text = this.tvSelectType.SelectedNode.Text;

                    DataView dvDrugList = new DataView(dsDrugList);
                    this.fpDrugList.DataSource = dvDrugList;
                    if (!this.rbTotal.Checked)
                    {
                        this.Filter();
                    }
                    this.FormatColumnSet(false);
                    if (this.rbTotal.Checked)
                    {
                        this.FormatColumnVisible(true);
                    }
                    else
                    {
                        this.FormatColumnVisible(false);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择摆药单节点进行查询!", "提示", MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 药品名称过滤
        /// </summary>
        private void Filter()
        {
            string strFilter = " (拼音码 like '%" + this.txtFilter.Text.Trim() + "%' or 五笔码 like '%" + this.txtFilter.Text.Trim() + "%') ";//{56EC4715-22E9-48b7-AD66-63D1F87130D6}
            //string strFilter = "";
            //string strFilter = "(拼音码 like '%" + this.txtFilter.Text.Trim() + "%')";//{56EC4715-22E9-48b7-AD66-63D1F87130D6}
            strFilter = strFilter + " and 取药药房 like '%" + this.cbbPharmacy.Text.Trim() + "%'";
            if (this.rbRetail.Checked)
            {
                strFilter = strFilter + " and 床号 like '%" + this.txtCaseNO.Text.Trim() + "%'";                
            }
            //if (this.rbRetail.Checked)
            //{
            //    strFilter = strFilter + " and 住院号 like '%" + this.txtCaseNO.Text.Trim() + "%'";
            //}
            strFilter = strFilter + this.SetInvalidData();
            DataView dv = this.fpDrugList.DataSource as DataView;
            if (dv != null)
            {
                dv.RowFilter = strFilter;
            }

            if (this.IsHintColor)
            {
                this.SetColorHint();
            }

            if (IsFormatColumn)
            {
                if (this.rbTotal.Checked)
                {
                    this.FormatColumnWidth(true);
                }
                else
                {
                    this.FormatColumnWidth(false);
                }
            }
        }

        /// <summary>
        /// 设置查询数据的有效性显示
        /// </summary>
        /// <returns></returns>
        private string SetInvalidData()
        {
            if (this.IsShowInvalidData)
            {
                return "";
            }
            else
            {
                return " and 有效性 like '%有效%'";
            }
        }

        /// <summary>
        /// 格式化列宽
        /// </summary>
        /// <param name="isTotal"></param>
        private void FormatColumnWidth(bool isTotal)
        {
            if (this.fpDrugList.ColumnCount == 0)
            { return; }
            if (isTotal)
            {
                this.fpDrugList.Columns[0].Width = 160;
                this.fpDrugList.Columns[1].Width = 60;
                this.fpDrugList.Columns[2].Width = 60;
                this.fpDrugList.Columns[3].Width = 35;
                this.fpDrugList.Columns[4].Width = 100;
                this.fpDrugList.Columns[5].Width = 130;
                this.fpDrugList.Columns[6].Width = 80;
                this.fpDrugList.Columns[7].Width = 60;
                this.fpDrugList.Columns[8].Width = 20;
                this.fpDrugList.Columns[9].Width = 20;
                //this.fpDrugList.Columns[10].Width = 35;
                //this.fpDrugList.Columns[11].Width = 35;--无锡不要
            }
            else
            {
                this.fpDrugList.Columns[0].Width = 40;//住院号
                this.fpDrugList.Columns[1].Width = 50;//床号
                this.fpDrugList.Columns[2].Width = 80;//姓名
                this.fpDrugList.Columns[3].Width = 160;//药品名称
                this.fpDrugList.Columns[4].Width = 50;//规格
                this.fpDrugList.Columns[5].Width = 50;//每次用量
                this.fpDrugList.Columns[6].Width = 35;//单位
                this.fpDrugList.Columns[7].Width = 50;//频次
                this.fpDrugList.Columns[8].Width = 45;//用法
                this.fpDrugList.Columns[9].Width = 60;//总量
                this.fpDrugList.Columns[10].Width = 35;//单位
                this.fpDrugList.Columns[11].Width = 100;//申请科室
                this.fpDrugList.Columns[12].Width = 130;//取药药房
                this.fpDrugList.Columns[13].Width = 80;//摆药单
                this.fpDrugList.Columns[14].Width = 35;//有效性
                this.fpDrugList.Columns[15].Width = 35;//拼音码
                this.fpDrugList.Columns[16].Width = 35;//五笔码
                this.fpDrugList.Columns[17].Width = 70;//状态
                this.fpDrugList.Columns[18].Width = 100;//发药时间
                //FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();  
                //FarPoint.Win.Spread.CellType.DesignTimeCellTypeConverter dtCellType = new FarPoint.Win.Spread.CellType.DesignTimeCellTypeConverter();
                //this.fpDrugList.Columns[19].CellType = dateTimeCellType1;
                //this.fpDrugList.Columns.Get(19).CellType = dateTimeCellType1;                
                //this.fpDrugList.Columns[19].Width = 70;//摆药单号//{56F10C75-A5C0-405d-BF56-69C33B45CB19}
            }
        }

        /// <summary>
        /// 格式化列表设置
        /// </summary>
        /// <param name="isTotal"></param>
        private void FormatColumnSet(bool isTotal)
        {
            for (int i = 0; i < this.fpDrugList.ColumnCount; i++)
            {
                this.fpDrugList.Columns[i].Locked = true;
                this.fpDrugList.Columns[i].AllowAutoSort = true;
            }
        }

        /// <summary>
        /// 格式化列显示
        /// </summary>
        /// <param name="isTotal"></param>
        private void FormatColumnVisible(bool isTotal)
        {
            if (isTotal)
            {
                this.fpDrugList.Columns[6].Visible = false;
                this.fpDrugList.Columns[8].Visible = false;
                this.fpDrugList.Columns[9].Visible = false;
                //this.fpDrugList.Columns[10].Visible = false;
            }
            else
            {
                this.fpDrugList.Columns[5].Visible = false;
                this.fpDrugList.Columns[6].Visible = false;
                this.fpDrugList.Columns[7].Visible = false;
                this.fpDrugList.Columns[8].Visible = false;
                this.fpDrugList.Columns[11].Visible = false;
                this.fpDrugList.Columns[13].Visible = false;
                this.fpDrugList.Columns[14].Visible = false;
                this.fpDrugList.Columns[15].Visible = false;
                this.fpDrugList.Columns[16].Visible = false;
                this.fpDrugList.Columns[17].Visible = false;
                if (this.rbtUndo.Checked)
                {
                    this.fpDrugList.Columns[18].Visible = false;
                }
                else
                {
                    this.fpDrugList.Columns[18].Visible = true;
                }
            }
        }

        /// <summary>
        /// 清空数据显示
        /// </summary>
        private void ClearData()
        {
            this.dsDrugList = null;
            this.fpDrugList.RowCount = 0;
            this.fpDrugList.ColumnCount = 0;
        }

        /// <summary>
        /// 设置颜色提示
        /// </summary>
        private void SetColorHint()
        {
            int columnIndex = 0;
            for (int i = 0; i < this.fpDrugList.ColumnCount; i++)
            {
                if (this.fpDrugList.Columns[i].Label == "有效性")
                {
                    columnIndex = i;
                }
            }

            for (int i = 0; i < this.fpDrugList.RowCount; i++)
            {
                if (this.fpDrugList.Cells[i, columnIndex].Text == "无效")
                {
                    this.fpDrugList.Rows[i].ForeColor = Color.Red;
                }                
            }
        }

        private void InitPrintInterface()
        {
            if (printInterface == null)
            {
                 this.printInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;
            }

        }

        #endregion

        #region 事件

        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.dtpStartDate.Value = DateTime.Today.Date;
            //修正按申请时间查询未摆药信息 {C99D84DC-8DCD-42a0-8AC4-BF80C1B7FB54} wbo 2010-10-02
            //this.dtpEndDate.Value = DateTime.Today.Date;
            this.dtpEndDate.Value = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
            this.IniControls();
            base.OnLoad(e);
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryDrugList();
            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// 树选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSelectType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ToolTipText == "摆药单")
            {
                this.billClass = this.drugstoreManager.GetDrugBillClass(e.Node.Tag.ToString());
                this.QueryDrugList();
            }
            else
            {
                this.ClearData();
            }
        }

        /// <summary>
        /// 汇总按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTotal_CheckedChanged(object sender, EventArgs e)
        {
            this.neuLabel7.Visible = false;
            this.txtCaseNO.TextChanged -= new EventHandler(txtCaseNO_TextChanged);
            this.txtCaseNO.Text = "";
            this.txtCaseNO.TextChanged += new EventHandler(txtCaseNO_TextChanged);
            this.txtCaseNO.Visible = false;
            this.QueryDrugList();
        }

        /// <summary>
        /// 明细按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRetail_CheckedChanged(object sender, EventArgs e)
        {
            this.neuLabel7.Visible = true;
            this.txtCaseNO.Visible = true;
            this.QueryDrugList();
        }

        /// <summary>
        /// 药品过滤框变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            //this.neuPanel7.Dock = DockStyle.Top;
            //int iHeight = 200;
            //DialogResult dr = MessageBox.Show("是否只打印选择的数据，选“否”则打印全部!", "打印提示", MessageBoxButtons.YesNoCancel);
            //if (dr == DialogResult.Yes)
            //{
            //    for (int i = 0; i < this.fpDrugList.RowCount; i++)
            //    {
            //        if (this.fpDrugList.IsSelected(i, 0) == false)
            //        {
            //            this.fpDrugList.Rows[i].Visible = false;
            //        }
            //        iHeight = iHeight + 20;
            //    }
            //}
            //else if (dr == DialogResult.No)
            //{
            //    for (int i = 0; i < this.fpDrugList.RowCount; i++)
            //    {
            //        iHeight = iHeight + 20;
            //    }
            //}
            //else
            //{
            //    return 1;
            //}
                        
            //this.neuPanel7.Height = iHeight;
            //Neusoft.FrameWork.WinForms.Classes.Print printObj = new Neusoft.FrameWork.WinForms.Classes.Print();
            //Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize("", this.neuPanel7.Width, iHeight);
            //printObj.SetPageSize(ps);
            //printObj.IsDataAutoExtend = false;
            //printObj.PrintPreview(10, 10, this.neuPanel7);
            //this.neuPanel7.Dock = DockStyle.Fill;
            //return base.OnPrint(sender, neuObject);
            //if (this.lbTitle.Text == "明细")
            //{

            #region donggq--20101123--{CA546AEB-3968-48ea-9CAE-D03832216326}

            if (string.IsNullOrEmpty(this.txtCaseNO.Text) && string.IsNullOrEmpty(this.txtFilter.Text))
            {
                if (this.printInterface == null)
                {
                    InitPrintInterface();
                }
                ArrayList drugList = null;
                this.billClass.User01 = "NurseType";//{31607136-EF3D-46af-A2F9-EE96F6F9209C}
                if (this.rbRetail.Checked)//{CC985758-A2AE-41da-9394-34AFCEB0E30E}
                {
                    drugList = this.drugItem.QueryApplyOutListDetailByBillClassCode(this.tvSelectType.SelectedNode.Tag.ToString(),
                                this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "2");
                    this.billClass.PrintType.ID = "D";
                }
                else if (this.rbTotal.Checked)
                {
                    drugList = this.drugItem.QueryApplyOutListTotByBillClassCode(this.tvSelectType.SelectedNode.Tag.ToString(),
                                this.tvSelectType.SelectedNode.Parent.Tag.ToString(), this.dtpStartDate.Value.Date.ToString(), this.dtpEndDate.Value.Date.AddDays(1).ToString(), "2");
                    this.billClass.PrintType.ID = "T";
                }

                if (drugList != null)
                {
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut outObj in drugList)
                    {
                        Neusoft.HISFC.Models.Pharmacy.Storage storage = drugItem.GetStockInfoByDrugCode(outObj.StockDept.Name, outObj.Item.ID);
                        Neusoft.HISFC.Models.Pharmacy.Item itemObj = drugItem.GetItem(outObj.Item.ID);
                        outObj.PlaceNO = storage.PlaceNO;
                        outObj.Item.UserCode = itemObj.UserCode;
                    }
                    if (this.printInterface != null)
                    {
                        this.printInterface.AddAllData(drugList, this.billClass);
                        this.printInterface.Preview();
                    }
                }
            }
            else
            {


                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

                p.PrintPage(0, 30, this.neuPanel7);
            } 

            #endregion
            //}
            return 1;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            this.neuSpread1.Export();
            return base.Export(sender, neuObject);
        }

        private void rbtUndo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtUndo.Checked)
            {
                this.queryDrugRange = QueryRange.NoneDrug;
                if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                {
                    this.neuPanel6.Visible = false;
                }
                else
                {
                    this.neuPanel6.Visible = true;
                }
                if (this.tvSelectType.SelectedNode.ToolTipText == "摆药单")
                {
                    this.QueryDrugList();
                }
                else
                {
                    this.ClearData();
                }
            }
        }

        private void rbtDone_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtDone.Checked)
            {
                this.queryDrugRange = QueryRange.Druged;
                if (this.QueryDrugRange == ucQueryDrugList.QueryRange.NoneDrug)
                {
                    this.neuPanel6.Visible = false;
                }
                else
                {
                    this.neuPanel6.Visible = true;
                }
                if (this.tvSelectType.SelectedNode.ToolTipText == "摆药单")
                {
                    this.QueryDrugList();
                }
                else
                {
                    this.ClearData();
                }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 显示节点类型
        /// </summary>
        public enum NodeType
        {        
            /// <summary>
            /// 护理单元(病区)
            /// </summary>
            NurseCell,
            /// <summary>
            /// 按科室显示
            /// </summary>
            Dept,
            /// <summary>
            /// 护理站下显示科室
            /// </summary>
            NurseDept,
            /// <summary>
            /// 按药房显示
            /// </summary>
            Pharmacy,
            /// <summary>
            /// 按当前登陆科室摆药单显示
            /// </summary>
            DrugBill
        }

        /// <summary>
        /// 摆药查询范围
        /// </summary>
        public enum QueryRange
        {
            /// <summary>
            /// 未摆药
            /// </summary>
            NoneDrug,
            /// <summary>
            /// 已摆药
            /// </summary>
            Druged,
            /// <summary>
            /// 全部药品
            /// </summary>
            AllDrug
        }

        #endregion

        private void txtCaseNO_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void cbbPharmacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
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
