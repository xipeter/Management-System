using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucFeeStat : UserControl, Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        /// <summary>
        /// 
        /// </summary>
        public ucFeeStat()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 窗口
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm maintenanceForm;

        /// <summary>
        /// 统计大类业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeStatManager = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

        /// <summary>
        /// 更新UC
        /// </summary>
        private ucFeeCodeStatModify ucModify = new ucFeeCodeStatModify();

        /// <summary>
        /// [2007/02/07] 新增加的代码,判断是否修改过
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// 医保类别集合{CFCDEC81-53A3-4de2-9871-99B7990A4F0C}
        /// </summary>
        ArrayList aLCenterType = new ArrayList();
        #endregion

        #region 私有方法

        /// <summary>
        /// 获得所有最小费用
        /// </summary>
        /// <returns>最小费用列表</returns>
        protected ArrayList QueryValidAllMinFee() 
        {
            return this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);
        }

        /// <summary>
        /// 获得未维护得最小费用列表
        /// </summary>
        /// <returns>未维护得最小费用列表</returns>
        protected ArrayList QueryValidMinFee()
        {
            ArrayList minFeeList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);

            if (minFeeList == null)
            {
                return null;

            }
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return minFeeList;
            }
            for (int i = 0; i < minFeeList.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Const objCon = new Neusoft.HISFC.Models.Base.Const();
                objCon = (Neusoft.HISFC.Models.Base.Const)minFeeList[i];
                for (int j = 0; j < this.fpSpread1_Sheet1.RowCount; j++)
                {
                    if (objCon.ID == this.fpSpread1_Sheet1.Cells[j, (int)EnumColumns.MinFeeName].Tag.ToString() && this.fpSpread1_Sheet1.Cells[j, (int)EnumColumns.ValidState].Tag.ToString() == "0")
                    {
                        minFeeList.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
            return minFeeList;
        }

        /// <summary>
        /// 初始化医保中心类别{CFCDEC81-53A3-4de2-9871-99B7990A4F0C}
        /// </summary>
        /// <returns></returns>
        private int QueryCenterType()
        {
            this.aLCenterType = this.managerIntegrate.GetConstantList("CENTERFEECODE");
            if (this.aLCenterType == null)
            {
                MessageBox.Show("查询医保类别出错");
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 根据医保中心类别编码转换名称{CFCDEC81-53A3-4de2-9871-99B7990A4F0C}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetCenterTypeName(string id)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject var in this.aLCenterType)
            {
                if (var.ID == id)
                {
                    return var.Name;
                }
            }
            return "";
        }


        /// <summary>
        /// 初始化treeview
        /// </summary>
        protected virtual int InitTree()
        {
            this.tvFeeType.Nodes.Clear();

            this.tvFeeType.Nodes.AddRange(
                new TreeNode[] {
						  new TreeNode("发票"),
						  new TreeNode("统计"),
						  new TreeNode("病案"),
						  new TreeNode("知情权")
                                });
            
            foreach (TreeNode node in this.tvFeeType.Nodes) 
            {
                if (node.Text == "发票") 
                {
                    node.Tag = "FP";
                }
                if (node.Text == "统计") 
                {
                    node.Tag = "TJ";
                }
                if (node.Text == "病案") 
                {
                    node.Tag = "BA";
                }
                if (node.Text == "知情权") 
                {
                    node.Tag = "ZQ";
                }
            }

            //报表类别
            //统计规类列表
            try
            {
                ArrayList reportTypes = new ArrayList();
                reportTypes = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.FEECODESTAT);

                for (int j = 0; j < reportTypes.Count; j++)
                {
                    Neusoft.HISFC.Models.Base.Const obj = new Neusoft.HISFC.Models.Base.Const();
                    obj = (Neusoft.HISFC.Models.Base.Const)reportTypes[j];
                    TreeNode tnReportName = new TreeNode();
                    tnReportName = new TreeNode(obj.Name);
                    tnReportName.Tag = obj.ID;
                    tnReportName.Text = obj.Name;
                    if (obj.Memo == "发票")
                    {
                        tvFeeType.Nodes[0].Nodes.Add(tnReportName);
                    }
                    if (obj.Memo == "统计")
                    {
                        tvFeeType.Nodes[1].Nodes.Add(tnReportName);
                    }
                    if (obj.Memo == "病案")
                    {
                        tvFeeType.Nodes[2].Nodes.Add(tnReportName);
                    }
                    if (obj.Memo == "知情权")
                    {
                        tvFeeType.Nodes[3].Nodes.Add(tnReportName);
                    }
                }

                // [2007/02/07] 新增加的代码,选择树控件
                this.tvFeeType.Select();
                // 新增加的代码结束
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return -1;
            }

            return 1;
        }

        private void SetValue(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat, int row) 
        {

            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.ReportCode, feeCodeStat.ID);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.ReportName, feeCodeStat.Name);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.MinFeeName, feeCodeStat.MinFee.Name);
            this.fpSpread1_Sheet1.Cells[row, (int)EnumColumns.MinFeeName].Tag = feeCodeStat.MinFee.ID;
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.StatCateCode, feeCodeStat.StatCate.ID);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.StatCateName, feeCodeStat.StatCate.Name);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.PrintOrder, feeCodeStat.SortID);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.ExtendCode, feeCodeStat.FeeStat.ID);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.ExecDept, feeCodeStat.ExecDept.Name);
            //{CFCDEC81-53A3-4de2-9871-99B7990A4F0C}
            //this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.CenterType, feeCodeStat.CenterStat);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.CenterType, this.GetCenterTypeName(feeCodeStat.CenterStat));
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.ValidState, ((int)feeCodeStat.ValidState).ToString());
            this.fpSpread1_Sheet1.Cells[row, (int)EnumColumns.ValidState].Tag = ((int)feeCodeStat.ValidState).ToString();
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.Oper, feeCodeStat.Oper.ID);
            this.fpSpread1_Sheet1.SetValue(row, (int)EnumColumns.OperTime, feeCodeStat.Oper.OperTime);

            this.fpSpread1_Sheet1.Rows[row].Tag = feeCodeStat;
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 显示列名称
        /// </summary>
        public enum EnumColumns 
        {
            /// <summary>
            /// 报表代码
            /// </summary>
            ReportCode = 0,

            /// <summary>
            /// 报表代码
            /// </summary>
            ReportName,

            /// <summary>
            /// 费用代码
            /// </summary>
            MinFeeName,

            /// <summary>
            /// 统计编码
            /// </summary>
            StatCateCode,

            /// <summary>
            /// 统计名称
            /// </summary>
            StatCateName,

            /// <summary>
            /// 打印顺序
            /// </summary>
            PrintOrder,

            /// <summary>
            /// 扩展代码
            /// </summary>
            ExtendCode,

            /// <summary>
            /// 执行科室
            /// </summary>
            ExecDept,

            /// <summary>
            /// 医保类别
            /// </summary>
            CenterType,

            /// <summary>
            /// 医保类别
            /// </summary>
            ValidState,

            /// <summary>
            /// 操作员
            /// </summary>
            Oper,

            /// <summary>
            /// 操作时间
            /// </summary>
            OperTime
        }

        #endregion


        #region IMaintenanceControlable 成员

        /// <summary>
        /// 增加新统计类别
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            // [2007/02/07] 新增加的代码,检查是否选择有效节点
            if ( this.tvFeeType.SelectedNode == null || this.tvFeeType.SelectedNode.Parent == null )
            {
                MessageBox.Show("请选择一个有效节点", "提示", MessageBoxButtons.OK);
                return 1;
            }
            // 新增加的代码结束

            int activeRow = this.fpSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat = new Neusoft.HISFC.Models.Fee.FeeCodeStat();

            feeCodeStat.ID = tvFeeType.SelectedNode.Tag.ToString();
            feeCodeStat.Name = tvFeeType.SelectedNode.Text.ToString();
            feeCodeStat.ReportType.Name = tvFeeType.SelectedNode.Parent.Text.ToString();
            feeCodeStat.ReportType.ID = tvFeeType.SelectedNode.Parent.Tag;//.ToString();

            ucModify.MinFeeList = this.QueryValidMinFee();
            ucModify.SaveType = ucFeeCodeStatModify.EnumSaveTypes.Add;
            ucModify.FeeCodeStat = feeCodeStat;

            // [2007/02/07] 新增加的代码
            //this.isDirty = true;
            //新增加的代码结束

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucModify);

            return 1;
        }

        public int Copy()
        {
            return 1;
        }

        public int Cut()
        {
            return 1;
        }

        public int Delete()
        {
            return 1;
        }

        public int Export()
        {
            return 1;
        }

        public int Import()
        {
            return 1;
        }

        public int Init()
        {
            return this.InitTree();
        }

        public bool IsDirty
        {
            get
            {
                return this.isDirty;
                //return true;
            }
            set
            {
               
            }
        }

        public int Modify()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) 
            {
                return -1;
            }

            int activeRow = this.fpSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat = this.fpSpread1_Sheet1.Rows[activeRow].Tag as Neusoft.HISFC.Models.Fee.FeeCodeStat;

            ucModify.MinFeeList = this.QueryValidAllMinFee();
            ucModify.SaveType = ucFeeCodeStatModify.EnumSaveTypes.Modify;
            ucModify.FeeCodeStat = feeCodeStat;

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucModify);
            
            return 1;
        }

        public int NextRow()
        {
            return 1;
        }

        public int Paste()
        {
            return 1;
        }

        public int PreRow()
        {
            return 1;
        }

        public int Print()
        {
            return 1;
        }

        public int PrintConfig()
        {
            return 1;
        }

        public int PrintPreview()
        {
            return 1;
        }
      

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public int Query()
        {
            
            TreeNode treeNode = this.tvFeeType.SelectedNode;
          
           
            if (treeNode == null) 
            {
                return -1;
            }
         
            if (treeNode.Parent == null)
            {
                return -1 ;
            }
            if (treeNode.Tag == null)
            {
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载项目信息,请等待...");
            ArrayList feeCodeStats = this.feeCodeStatManager.QueryFeeCodeStatByReportCode(treeNode.Tag.ToString());

            if(feeCodeStats == null)
            {
                MessageBox.Show(Language.Msg("获得统计大类明细出错!") + this.feeCodeStatManager.Err);

                return -1;
            }

            this.fpSpread1_Sheet1.RowCount = feeCodeStats.Count;

            for (int i = 0; i < feeCodeStats.Count; i++) 
            {
                Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat = feeCodeStats[i] as Neusoft.HISFC.Models.Fee.FeeCodeStat;

                SetValue(feeCodeStat, i);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return this.maintenanceForm;
            }
            set
            {
                this.maintenanceForm = value;
            }
        }

        public int Save()
        {
            return 1;
        }

        #endregion

        private void tvFeeType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Query();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.Modify();
        }

        private void ucFeeStat_Load(object sender, EventArgs e)
        {
            this.ucModify.Save += new ucFeeCodeStatModify.ClickSave(ucModify_Save);

            // [2007/02/07] 新增加的代码
            this.maintenanceForm.ShowDeleteButton = false;
            this.maintenanceForm.ShowCopyButton = false;
            this.maintenanceForm.ShowCutButton = false;
            this.maintenanceForm.ShowExportButton = false;
            this.maintenanceForm.ShowImportButton = false;
            this.maintenanceForm.ShowNextRowButton = false;
            this.maintenanceForm.ShowPasteButton = false;
            this.maintenanceForm.ShowPreRowButton = false;
            this.maintenanceForm.ShowPrintButton = false;
            this.maintenanceForm.ShowPrintConfigButton = false;
            this.maintenanceForm.ShowPrintPreviewButton = false;
            this.maintenanceForm.ShowSaveButton = false;
            //this.maintenanceForm.s
            // 新增加的代码结束
            //{CFCDEC81-53A3-4de2-9871-99B7990A4F0C}
            this.QueryCenterType();
        }

        void ucModify_Save(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
        {
            if (this.ucModify.SaveType == ucFeeCodeStatModify.EnumSaveTypes.Add)
            {

                int row = this.fpSpread1_Sheet1.RowCount;

                this.fpSpread1_Sheet1.Rows.Add(row, 1);

                row = this.fpSpread1_Sheet1.Rows.Count - 1;

                this.SetValue(feeCodeStat, row);
            }
            if (this.ucModify.SaveType == ucFeeCodeStatModify.EnumSaveTypes.Modify) 
            {
                for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++) 
                {
                    Neusoft.HISFC.Models.Fee.FeeCodeStat temp = this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.FeeCodeStat;

                    if (temp.MinFee.ID == feeCodeStat.MinFee.ID && temp.ID == feeCodeStat.ID) 
                    {
                        this.SetValue(feeCodeStat, i);
                        break;
                    }
                }
            }
        }
    }
}
