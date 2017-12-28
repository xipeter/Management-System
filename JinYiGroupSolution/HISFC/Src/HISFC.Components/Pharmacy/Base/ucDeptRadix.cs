using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 病区基数药管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public partial class ucDeptRadix : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDeptRadix()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 整合的业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 权限人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品信息
        /// </summary>
        private ArrayList alItem = new ArrayList();

        /// <summary>
        /// 科室信息
        /// </summary>
        private ArrayList alDept = new ArrayList();

        /// <summary>
        /// 根节点
        /// </summary>
        private TreeNode parentNode = null;

        /// <summary>
        /// 当前操作的基数科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject radixDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否修改过
        /// </summary>
        private bool isNew = false;

        /// <summary>
        /// 最大起始时间
        /// </summary>
        private DateTime maxBeginDate = System.DateTime.MinValue;

        #endregion

        #region 属性

        /// <summary>
        /// 起始时间
        /// </summary>
        internal DateTime BeginDate        
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        internal DateTime EndDate
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            List<Neusoft.HISFC.Models.Pharmacy.Item> alList  = itemManager.QueryItemList(true);
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取药品列表发生错误") + itemManager.Err);
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alList)
            {
                item.Memo = item.Specs;
            }
            this.alItem = new ArrayList(alList.ToArray());

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            this.alDept = deptManager.GetDeptmentAll();
            if (this.alDept == null)
            {
                MessageBox.Show(Language.Msg("获取科室列表发生错误") + deptManager.Err);
                return -1;
            }

            this.tvDeptList.ImageList = this.tvDeptList.groupImageList;

            this.parentNode = new TreeNode("基数药病区",0,0);

            this.tvDeptList.Nodes.Add(this.parentNode);

            #region 屏蔽Fp回车/换行键

            FarPoint.Win.Spread.InputMap im;

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Space, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            #endregion

            this.neuSpread1.EditModeReplace = true;

            return 1;
        }

        /// <summary>
        /// 获取基数药管理时间列表
        /// </summary>
        /// <returns></returns>
        protected int InitList()
        {
            List<Neusoft.FrameWork.Models.NeuObject> list = this.phaConsManager.QueryDeptRadixDateList(this.privDept.ID);
            if (list == null)
            {
                MessageBox.Show("获取区间列表发生错误 " + this.phaConsManager.Err);
                return -1;
            }

            if (list.Count > 0)
            {
                Neusoft.FrameWork.Models.NeuObject max = list[0] as Neusoft.FrameWork.Models.NeuObject;
                this.maxBeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(max.Name);
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in list)
            {
                info.Name = info.ID + "－" + info.Name;
            }

            this.cmbStatList.AddItems(new ArrayList(list.ToArray()));
         
            return 1;
        }

        #endregion

        #region 工具栏

        protected override int OnSave(object sender, object neuObject)
        {
           this.SaveDeptRadix();

           return 1;
        }

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("新增区间", "新增基数药管理时间区间", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("增加科室", "新增基数药科室", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("增加明细", "新增基数药信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除科室", "删除基数科室信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("删除明细", "删除基数药信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarService.AddToolButton("消耗统计", "统计时间段内的消耗量", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z暂存, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "新增区间")
            {
                this.NewStat();
            }
            if (e.ClickedItem.Text == "增加科室")
            {
                this.NewDept();
            }
            if (e.ClickedItem.Text == "增加明细")
            {
                this.NewDeptRadix();
            }
            if (e.ClickedItem.Text == "删除科室")
            {
                this.DelDeptRadixDept();
            }
            if (e.ClickedItem.Text == "删除明细")
            {
                this.DelDeptRadixDetail();
            }
            if (e.ClickedItem.Text == "消耗统计")
            {
                this.ExpandStat();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return base.Export(sender, neuObject);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="isClearTree">是否清空树</param>
        protected void Clear(bool isClearTree)
        {
            if (isClearTree)
            {
                this.parentNode.Nodes.Clear();
            }

            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 新建区间
        /// </summary>
        protected void NewStat()
        {
            DateTime sysTime = this.phaConsManager.GetDateTimeFromSysDateTime();

            if (this.maxBeginDate != System.DateTime.MinValue)
            {
                this.dtBegin.Value = this.maxBeginDate;
                this.dtEnd.Value = this.dtBegin.Value.AddMonths(1);
            }
            else
            {
                this.dtBegin.Value = sysTime.AddMonths(-1);
                this.dtEnd.Value = sysTime;
            }

            this.dtEnd.Enabled = true;

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                //基数量默认上次基数量
                //this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColRadixQty].Text = "0";
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSurplusQty].Text = "0";
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSurplusQty].Text = "0";
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColExpendQty].Text = "0";
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMemo].Text = "0";
            }
        }

        /// <summary>
        /// 病区基数药列表
        /// </summary>
        /// <returns></returns>
        protected int ShowRadixDept()
        {
            List<Neusoft.FrameWork.Models.NeuObject> alList = this.phaConsManager.QueryDeptRadixDeptList(this.privDept.ID,this.BeginDate);
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取基数药科室列表发生错误") + this.phaConsManager.Err);
                return -1;
            }

            this.Clear(true);

            foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
            {
                TreeNode node = new TreeNode(info.Name);

                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                node.Tag = info;

                this.parentNode.Nodes.Add(node);
            }

            this.parentNode.ExpandAll();

            return 1;
        }

        /// <summary>
        /// 加入基数药信息
        /// </summary>
        /// <param name="deptRadix">基数药信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDeptRadixToFp(Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix)
        {
            this.neuSpread1_Sheet1.Rows.Add(0, 1);

            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColItemName].Text = deptRadix.Item.Name;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColItemSpecs].Text = deptRadix.Item.Specs;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColUnit].Text = deptRadix.Item.PackUnit;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColRadixQty].Value = deptRadix.RadixQty;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColSurplusQty].Value = deptRadix.SurplusQty;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColSupllyQty].Value = deptRadix.SurplusQty;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColExpendQty].Value = deptRadix.ExpendQty;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColMemo].Text = deptRadix.Memo;
            this.neuSpread1_Sheet1.Cells[0, (int)ColumnSet.ColDrugID].Text = deptRadix.Item.ID;

            this.neuSpread1_Sheet1.Rows[0].Tag = deptRadix;

            return 1;
        }

        /// <summary>
        /// 根据科室编码获取基数药明细信息
        /// </summary>
        /// <param name="deptCode">科室/病区</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int ShowRadixDetail(string deptCode)
        {
            this.Clear(false);

            List<Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix> alDetail = this.phaConsManager.QueryDeptRadix(this.privDept.ID, deptCode,this.BeginDate);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg("获取基数药品明细信息发生错误") + this.phaConsManager.Err);
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix in alDetail)
            {
                this.AddDeptRadixToFp(deptRadix);
            }

            return 1;
        }

        /// <summary>
        /// 弹出药品选择
        /// </summary>
        /// <param name="iRowIndex"></param>
        protected void PopDrug(int iRowIndex)
        {
            string[] label = { "编码","商品名称", "规格" };
            float[] width = { 60F,140F, 100F };
            bool[] visible = { false,true, true };
            Neusoft.FrameWork.Models.NeuObject speObj = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alItem, ref speObj) == 1)
            {
                Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix = this.neuSpread1_Sheet1.Rows[iRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix;

                deptRadix.Item = speObj as Neusoft.HISFC.Models.Pharmacy.Item;

                this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColItemName].Text = speObj.Name;
                this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColItemSpecs].Text = speObj.Memo;
                this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColDrugID].Text = speObj.ID;
                this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColUnit].Text = deptRadix.Item.PackUnit;

                this.SetFocus();
            }
        }

        /// <summary>
        /// 删除基数科室
        /// </summary>
        protected void DelDeptRadixDept()
        {
            if (this.tvDeptList.SelectedNode == this.parentNode)
            {
                return;
            }
            if (this.parentNode.Nodes.Count == 0)
            {
                return;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("是否删除该科室所有基数药信息?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
            {
                return;
            }

            if (this.tvDeptList.SelectedNode.Parent != null)
            {
                if (this.phaConsManager.DelDeptRadix(this.privDept.ID, this.radixDept.ID,this.BeginDate) == -1)
                {
                    MessageBox.Show(Language.Msg("执行删除操作失败"));
                    return;
                }

                MessageBox.Show(Language.Msg("删除成功"));                

                this.parentNode.Nodes.Remove(this.tvDeptList.SelectedNode);

                if (this.parentNode.Nodes.Count == 0)
                {
                    this.InitList();
                }
            }
        }

        /// <summary>
        /// 删除科室明细
        /// </summary>
        protected void DelDeptRadixDetail()
        {
            if (this.parentNode.Nodes.Count == 0 || this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("是否删除该基数药信息?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
            {
                return;
            }

            int iRow = this.neuSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix = this.neuSpread1_Sheet1.Rows[iRow].Tag as Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix;

            if (this.phaConsManager.DelDeptRadix(this.privDept.ID, deptRadix.Dept.ID, deptRadix.Item.ID,this.BeginDate) == -1)
            {
                MessageBox.Show(Language.Msg("执行删除操作失败"));
                return;
            }

            MessageBox.Show(Language.Msg("删除成功"));

            this.neuSpread1_Sheet1.Rows.Remove(iRow, 1);

            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                this.parentNode.Nodes.Remove(this.tvDeptList.SelectedNode);
            }

        }

        /// <summary>
        /// 设置新增科室
        /// </summary>
        protected void NewDept()
        {
            string[] label = { "编码","科室"};
            float[] width = { 80F, 100F };
            bool[] visible = { true, true };
            Neusoft.FrameWork.Models.NeuObject deptObj = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDept, ref deptObj) == 1)
            {
                TreeNode node = new TreeNode(deptObj.Name);
                node.Tag = deptObj;

                this.parentNode.Nodes.Add(node);

                this.radixDept = deptObj;

                this.tvDeptList.SelectedNode = node;

                //this.isNew = true;

                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColItemName;
            }
        }

        /// <summary>
        /// 新增基数药品信息
        /// </summary>
        protected void NewDeptRadix()
        {
            if (this.tvDeptList.SelectedNode.Parent == null)
            {
                return;
            }

            int rowCount = this.neuSpread1_Sheet1.Rows.Count;

            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
           
            Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix = new Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix();
            deptRadix.StockDept = this.privDept;            

            deptRadix.Dept = this.radixDept;

            this.neuSpread1_Sheet1.Rows[rowCount].Tag = deptRadix;

            this.neuSpread1.Select();

            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColItemName;

            this.neuSpread1.StartCellEditing(null, false);

            this.isNew = true;
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show(Language.Msg("请添加基数药明细信息"));
                return false;
            }

            for(int i = 0;i < this.neuSpread1_Sheet1.Rows.Count;i++)
            {
                string memo = this.neuSpread1_Sheet1.Cells[i,(int)ColumnSet.ColMemo].Text;
               
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(memo,100))
                {
                    MessageBox.Show(Language.Msg("备注输入内容过长 请适当简略"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void SaveDeptRadix()
        {
            if (!this.IsValid())
            {
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.phaConsManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.phaConsManager.DelDeptRadix(this.privDept.ID, this.radixDept.ID,this.BeginDate) == -1)            
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("保存前 删除原科室基数药信息发生错误") + this.phaConsManager.Err);
                return;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix;

                if (deptRadix == null || deptRadix.Item.ID == "")
                {
                    continue;
                }
                deptRadix.BeginDate = this.BeginDate;
                deptRadix.EndDate = this.EndDate;

                deptRadix.RadixQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColRadixQty].Text);
                deptRadix.SurplusQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,(int)ColumnSet.ColSurplusQty].Text);
                deptRadix.SupplyQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,(int)ColumnSet.ColSurplusQty].Text);
                deptRadix.ExpendQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColExpendQty].Text);
                deptRadix.Memo = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMemo].Text;

                Neusoft.HISFC.Models.Base.Department dept = interManager.GetDepartment(this.privDept.ID);
                switch (dept.DeptType.ID.ToString())
                {
                    case "T":
                        {
                            deptRadix.DeptType = DrugType.Terminal.ToString();
                        }
                        break;
                    case "P":
                        {
                            deptRadix.DeptType = DrugType.State.ToString();
                        }
                        break;
                    case "N":
                        {
                            deptRadix.DeptType = DrugType.Nurse.ToString();
                        }
                        break;
                    default:
                        {
                            deptRadix.DeptType = DrugType.Nurse.ToString();
                            break;
                        }

                }

                if (this.phaConsManager.InsertDeptRadix(deptRadix) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (this.phaConsManager.DBErrCode == 1)
                    {
                        MessageBox.Show(Language.Msg(deptRadix.Item.Name + "基数信息维护重复 请删除一条"));
                    }
                    else
                    {
                        MessageBox.Show(Language.Msg("插入新基数药信息发生错误") + this.phaConsManager.Err);
                    }
                    return;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            this.isNew = false;

            this.InitList();

            this.ShowRadixDept();
        }

        /// <summary>
        /// 消耗量统计
        /// </summary>
        protected void ExpandStat()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return;
            }

            DateTime dtEnd = this.phaConsManager.GetDateTimeFromSysDateTime();
            DateTime dtBegin = dtEnd.AddDays(-29);
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref dtBegin, ref dtEnd) == 1)
            {
                string drugCollection = "";
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    drugCollection = drugCollection + "','" + this.neuSpread1_Sheet1.Cells[i,(int)ColumnSet.ColDrugID].Text;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在进行药品消耗量统计 请稍候..."));
                Application.DoEvents();

                DataSet ds = new DataSet();
                if (this.phaConsManager.ExecQuery("Pharmacy.DeptRadix.Expand", ref ds, this.privDept.ID, this.radixDept.ID, dtBegin.ToString(), dtEnd.ToString(), drugCollection) == -1)
                {
                    MessageBox.Show(Language.Msg("执行Sql查询消耗量信息失败"));
                    return;
                }

                if (ds != null && ds.Tables.Count > 0)
                {
                    System.Collections.Hashtable hsExpand = new Hashtable();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        hsExpand.Add(dr[0].ToString(), dr[1]);
                    }

                    for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                    {
                        if (hsExpand.ContainsKey(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDrugID].Text))
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColExpendQty].Value = hsExpand[this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDrugID].Text];
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColExpendQty].Value = 0;
                        }
                    }
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        protected void SetFocus()
        {
            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColRadixQty;

            this.neuSpread1.StartCellEditing(null, false);
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.privOper = this.phaConsManager.Operator;

                this.privDept = ((Neusoft.HISFC.Models.Base.Employee)this.phaConsManager.Operator).Dept;

                this.Init();

                this.InitList();
            }

            base.OnLoad(e);
        }

        private void tvDeptList_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            if (e.Node.Parent == null)
            {
                this.Clear(false);

                return;
            }
            else
            {
                this.radixDept = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.ShowRadixDetail(this.radixDept.ID);
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColItemName)
            {
                this.PopDrug(e.Row);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                if (this.neuSpread1.ContainsFocus && this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColItemName)
                {
                    this.PopDrug(this.neuSpread1_Sheet1.ActiveRowIndex);

                    return base.ProcessDialogKey(keyData);
                }
                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColRadixQty)
                {
                    this.neuSpread1_Sheet1.ActiveColumnIndex++;
                }
                else if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColSurplusQty)
                {
                    this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColSupllyQty;
                }
                else if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColSupllyQty)
                {
                    this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColMemo;
                }
                else if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColMemo)
                {
                    if (this.neuSpread1_Sheet1.Rows.Count - 1 == this.neuSpread1_Sheet1.ActiveRowIndex)
                    {
                        this.NewDeptRadix();
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.ActiveRowIndex++;
                    }
                }
            }
            if (keyData == Keys.F8)
            {
                this.NewDeptRadix();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void tvDeptList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isNew)
            {
                DialogResult rs = MessageBox.Show(Language.Msg("该科室基数药数据已发生变化 是否保存?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void neuSpread1_EditModeOff(object sender, EventArgs e)
        {
            decimal radixQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColRadixQty].Text);
            decimal surplusQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColSurplusQty].Text);
            decimal expendQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColExpendQty].Text);

            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColSupllyQty].Text = (radixQty + expendQty - surplusQty).ToString();

        }

        private void cmbStatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStatList.Tag != null)
            {
                DateTime dtBegin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.cmbStatList.Tag.ToString());
                this.dtBegin.Value = dtBegin;
                this.dtBegin.Enabled = false;

                string statStr = this.cmbStatList.Text;
                string endDateStr = statStr.Substring(statStr.IndexOf('－') + 1);
                this.dtEnd.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(endDateStr);
                this.dtEnd.Enabled = false;

                this.ShowRadixDept();
            }
        }      

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            ColItemName,
            ColItemSpecs,
            ColUnit,
            ColRadixQty,
            ColSurplusQty,
            ColExpendQty,
            ColSupllyQty,
            ColMemo,
            ColDrugID
        }

        /// <summary>
        /// 科室类型枚举
        /// </summary>
        private enum DrugType
        {
            Nurse,
            Terminal,
            State
        }

    }
}

