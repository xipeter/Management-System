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

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 药品模版]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1.设置药品模板自动排序功能 by Sunjh 2010-8-25 {510B1973-959C-4ebf-9CEB-F850393B1819}
    /// </修改记录>
    /// </summary>
    public partial class ucDrugStencil : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugStencil()
        {
            InitializeComponent();

            this.neuSpread1.AutoSortedColumn += new FarPoint.Win.Spread.AutoSortedColumnEventHandler(neuSpread1_AutoSortedColumn);
        }

        void neuSpread1_AutoSortedColumn(object sender, FarPoint.Win.Spread.AutoSortedColumnEventArgs e)
        {
            if (this.neuSpread1_Sheet1.Models.Data is FarPoint.Win.Spread.Model.IDataSourceSupport)
            {
                int activeRow = this.neuSpread1_Sheet1.ActiveRowIndex;
                int modelRow = this.neuSpread1_Sheet1.GetModelRowFromViewRow(activeRow);
                int dataRow = ((FarPoint.Win.Spread.Model.IDataSourceSupport)this.neuSpread1_Sheet1.Models.Data).GetDataRowFromModelRow(modelRow);

                if (dataRow != -1)
                {
                    this.neuSpread1.BindingContext[this.dt.DefaultView].Position = dataRow;
                }
            }
  
        }
       
        #region 域变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 本次操作的模版信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject stencil = new Neusoft.FrameWork.Models.NeuObject();
      
        /// <summary>
        /// 当前操作的模版类型
        /// </summary>
        private string stencilTypeID = "";

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
      
        /// <summary>
        /// 药品业务关联类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示树列表
        /// </summary>
        protected bool IsShowList
        {
            get
            {
                return this.ucChooseList1.IsShowTree;
            }
            set
            {
                this.ucChooseList1.IsShowTree = value;

                this.SetTooButton(value);
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            #region {9768C6B1-5F8C-484c-AFBC-0B2D8CC55400}
            toolBarService.AddToolButton("模  版", "模  版", Neusoft.FrameWork.WinForms.Classes.EnumImageList.M模版, true, false, null); 
            #endregion
            toolBarService.AddToolButton("新  建", "新建模版", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);            
            toolBarService.AddToolButton("删除明细", "删除当前选择的模版内药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("删除模版", "删除当前选择的模版", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);
            toolBarService.AddToolButton( "自动排序", "按照商品名称或剂型自动生成序列号", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null );

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "模  版")
            {
                this.IsShowList = true;
            }
            if (e.ClickedItem.Text == "新  建")
            {
                this.New();
            }
            if (e.ClickedItem.Text == "删除明细")
            {
                this.DelDetail();
            }
            if (e.ClickedItem.Text == "删除模版")
            {
                this.DelStencil();
            }
            if (e.ClickedItem.Text == "自动排序")
            {
                //设置药品模板自动排序功能 by Sunjh 2010-8-25 {510B1973-959C-4ebf-9CEB-F850393B1819}
                this.neuSpread1_Sheet1.AutoSortColumn(2,true,false);
                this.neuSpread1_Sheet1.SetColumnAllowAutoSort(2, false);
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {           
            this.Save();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                if (this.neuSpread1.Export() == 1)
                {
                    MessageBox.Show(Language.Msg("导出成功"));
                }
            }

            return 1;
        }

        /// <summary>
        /// 设置工具栏按钮显示
        /// </summary>
        /// <param name="isShowList"></param>
        protected void SetTooButton(bool isShowList)
        {
            this.toolBarService.SetToolButtonEnabled("模  版", !isShowList);
            this.toolBarService.SetToolButtonEnabled("新  建", isShowList);
        }

        #endregion

        #region 初始化及Fp设置

        /// <summary>
        /// DataSet初始化
        /// </summary>
        private void InitDataSet()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtInt = System.Type.GetType("System.Int32");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {
                                                                    new DataColumn("商品名称",      dtStr),
                                                                    new DataColumn("规格",			dtStr),
                                                                    new DataColumn("顺序号",		dtInt),
                                                                    new DataColumn("操作员",		dtStr),
                                                                    new DataColumn("操作时间",      dtStr),
                                                                    new DataColumn("药品编码",		dtStr),                                                                    
                                                                    new DataColumn("拼音码",		dtStr),
                                                                    new DataColumn("五笔码",		dtStr),
                                                                    new DataColumn("自定义码",      dtStr),
                                                                    new DataColumn("通用名拼音码",	dtStr),
                                                                    new DataColumn("通用名五笔码",	dtStr)
            });
            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["药品编码"];
            this.dt.PrimaryKey = keys;
            //数据绑定
            this.neuSpread1_Sheet1.DataSource = this.dt;

            this.SetFormat();
        }

        /// <summary>
        /// Fp格式化设置
        /// </summary>
        private void SetFormat()
        {
            //屏蔽F5键 F5键用于跳转
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F5, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);


            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDrugNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRegularSpell].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRegularWBCode].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSortNO].Locked = false;

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCell = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            markNumCell.DecimalPlaces = 0;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSortNO].CellType = markNumCell;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InitData()
        {
            this.ucChooseList1.TvList.ImageList = this.ucChooseList1.TvList.deptImageList;

            ArrayList al = Neusoft.HISFC.Models.Pharmacy.DrugStencilEnumService.List();
            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                TreeNode node = new TreeNode(info.Name);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = info.ID;

                this.ucChooseList1.TvList.Nodes.Add(node);
            }

            this.ucChooseList1.ShowPharmacyList();

            this.ucChooseList1.ListTitle = "模版列表";
        }

        /// <summary>
        /// 事件初始化
        /// </summary>
        protected void InitEvent()
        { 
            this.ucChooseList1.TvList.AfterLabelEdit += new NodeLabelEditEventHandler(TvList_AfterLabelEdit);
            this.ucChooseList1.TvList.AfterSelect += new TreeViewEventHandler(TvList_AfterSelect);
            this.ucChooseList1.TvList.DoubleClick += new EventHandler(TvList_DoubleClick);

            this.ucChooseList1.ChooseDataEvent += new ucChooseList.ChooseDataHandler(ucChooseList1_ChooseDataEvent);            
        }
     
        #endregion

        #region 方法

        /// <summary>
        /// 根据药品信息 生成DataRow
        /// </summary>
        /// <param name="drugStencil">药品信息</param>
        /// <returns>成功返回一行DataRow信息</returns>
        private System.Data.DataRow GetDataRow(Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(drugStencil.Item.ID);
            DataRow dr = this.dt.NewRow();
            if (item != null)
            {
                dr["药品编码"] = item.ID;
                dr["商品名称"] = item.Name;
                dr["规格"] = item.Specs;
                dr["顺序号"] = drugStencil.SortNO;
                dr["操作员"] = drugStencil.Oper.ID;
                dr["操作时间"] = drugStencil.Oper.OperTime.ToString();
                dr["拼音码"] = item.NameCollection.SpellCode;
                dr["五笔码"] = item.NameCollection.WBCode;
                dr["自定义码"] = item.NameCollection.UserCode;
                dr["通用名拼音码"] = item.NameCollection.RegularSpell.SpellCode;
                dr["通用名五笔码"] = item.NameCollection.RegularSpell.WBCode;
            }
            else
            {
                MessageBox.Show("药品列表中找不到模板中的" + drugStencil.Item.ID + drugStencil.Item.Name + "数据，请手工删除！");
                dr["药品编码"] = drugStencil.Item.ID;
                dr["商品名称"] = drugStencil.Item.Name;
                dr["规格"] = drugStencil.Item.Specs;
                dr["顺序号"] = drugStencil.SortNO;
                dr["操作员"] = drugStencil.Oper.ID;
                dr["操作时间"] = drugStencil.Oper.OperTime.ToString();
                dr["拼音码"] = drugStencil.Item.NameCollection.SpellCode;
                dr["五笔码"] = drugStencil.Item.NameCollection.WBCode;
                dr["自定义码"] = drugStencil.Item.NameCollection.UserCode;
                dr["通用名拼音码"] = drugStencil.Item.NameCollection.RegularSpell.SpellCode;
                dr["通用名五笔码"] = drugStencil.Item.NameCollection.RegularSpell.WBCode;
            }
            return dr;
        }

        /// <summary>
        /// 根据数据集信息获取模版实体信息
        /// </summary>
        /// <param name="dr">数据表信息</param>
        /// <returns>成功返回模版实体信息</returns>
        private Neusoft.HISFC.Models.Pharmacy.DrugStencil GetDrugStencil(DataRow dr)
        {
            Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil = new Neusoft.HISFC.Models.Pharmacy.DrugStencil();
            drugStencil.Dept = this.privDept;
            drugStencil.OpenType.ID = this.stencilTypeID;
            drugStencil.Stencil = this.stencil;
            drugStencil.Item.ID = dr["药品编码"].ToString();
            drugStencil.Item.Name = dr["商品名称"].ToString();
            drugStencil.Item.Specs = dr["规格"].ToString();
            drugStencil.SortNO = Neusoft.FrameWork.Function.NConvert.ToInt32(dr["顺序号"]);

            return drugStencil;
        }

        /// <summary>
        /// 检索列表显示
        /// </summary>
        public int ShowList()
        {
            try
            {
                ArrayList alList = this.consManager.QueryDrugStencilList(this.privDept.ID);
                if (alList == null)
                {
                    MessageBox.Show(Language.Msg("获取本科室模版列表发生错误" + this.consManager.Err));
                    return -1;
                }

                foreach (TreeNode rootNode in this.ucChooseList1.TvList.Nodes)
                {
                    rootNode.Nodes.Clear();
                }
                TreeNode parentNode = new TreeNode();
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in alList)
                {
                    parentNode = this.GetParentNode(info.OpenType);
                    TreeNode node = new TreeNode(info.Stencil.Name + "[" + info.Stencil.ID + "]");
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                    node.Tag = info;
                    parentNode.Nodes.Add(node);
                }

                this.ucChooseList1.TvList.ExpandAll();

                this.IsShowList = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据指定模版类型获取父级节点
        /// </summary>
        /// <param name="drugOpenEnumService">模版类型</param>
        /// <returns>成功返回该类型的节点</returns>
        private TreeNode GetParentNode(Neusoft.HISFC.Models.Pharmacy.DrugStencilEnumService drugStencilEnumService)
        {
            foreach (TreeNode tempNode in this.ucChooseList1.TvList.Nodes)
            {
                if (tempNode.Tag != null && tempNode.Tag.ToString() == drugStencilEnumService.ID)
                    return tempNode;
            }
            TreeNode node = new TreeNode(drugStencilEnumService.Name);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Tag = drugStencilEnumService.ID;
            this.ucChooseList1.TvList.Nodes.Add(node);
            return node;
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        /// <param name="isFpFocus">是否设置Fp焦点</param>
        protected void SetFocus(bool isFpFocus)
        {
            if (isFpFocus)
            {
                this.neuSpread1.Select();
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColSortNO;
            }
            else
            {
                if (this.IsShowList)
                {
                    this.txtFilter.Focus();
                    this.txtFilter.SelectAll();
                }
                else
                {
                    this.ucChooseList1.Select();
                    this.ucChooseList1.SetFoucs();
                }
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="drugCode">需添加的药品编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddData(string drugNO)
        {
            Neusoft.HISFC.Models.Pharmacy.Item itemTemp = this.itemManager.GetItem(drugNO);
            if (itemTemp == null)
                return -1;

            return this.AddData(itemTemp);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item">需添加的药品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddData(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            try
            {
                string[] keys = new string[] { item.ID };
                if (this.dt.Rows.Find(keys) != null)
                {
                    MessageBox.Show(Language.Msg(item.Name + "已添加到模版内"));
                    this.SetFocus(false);
                    return -1;
                }
                Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil = new Neusoft.HISFC.Models.Pharmacy.DrugStencil();
                drugStencil.Dept = this.privDept;
                drugStencil.OpenType.ID = this.stencilTypeID;
                drugStencil.Item = item;

                this.dt.Rows.Add(this.GetDataRow(drugStencil));

                this.SetFocus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Fp数据清空
        /// </summary>
        public void Clear()
        {
            if (this.dt != null)
                this.dt.Rows.Clear();
        }

        /// <summary>
        /// 过滤
        /// </summary>
        public void Filter()
        {
            try
            {
                string str = "%" + this.txtFilter.Text + "%";
               this.dt.DefaultView.RowFilter = Function.GetFilterStr(this.dt.DefaultView,str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }      

        /// <summary>
        /// 新增模版
        /// </summary>
        public void New()
        {
            if (this.ucChooseList1.TvList.SelectedNode != null && this.ucChooseList1.TvList.SelectedNode.Parent == null)
            {
                TreeNode node = new TreeNode();

                Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil = new Neusoft.HISFC.Models.Pharmacy.DrugStencil();
                drugStencil.Dept = this.privDept;
                drugStencil.OpenType.ID = this.stencilTypeID;

                this.stencil = new Neusoft.FrameWork.Models.NeuObject();
                this.stencil.Name = "新建模版";
                drugStencil.Stencil = this.stencil;

                node.Text = "新建模板";
                node.Tag = drugStencil;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                this.ucChooseList1.TvList.SelectedNode.Nodes.Add(node);
                this.ucChooseList1.TvList.SelectedNode = node;

                this.ucChooseList1.TvList.LabelEdit = true;
                node.BeginEdit();
            }
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="stencilCode">模版编码</param>
        public void ShowData(string stencilNO)
        {
            if (stencilNO == null || stencilNO == "")
                return;

            ArrayList al = this.consManager.QueryDrugStencil(stencilNO);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("根据模版编码获取模版明细信息发生错误\n" + this.consManager.Err));
                return;
            }
            this.dt.Rows.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示模版明细 请稍候...");
            Application.DoEvents();

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in al)
            {
                this.stencil = info.Stencil;

                this.dt.Rows.Add(this.GetDataRow(info));
            }

            this.dt.AcceptChanges();

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;
        }

        /// <summary>
        /// 删除模版明细
        /// </summary>
        public void DelDetail()
        {
            if (this.dt.Rows.Count <= 0)
                return;

            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            DialogResult rs = MessageBox.Show(Language.Msg("确认删除该条记录吗?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            string durgNO = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text;
            int parma = this.consManager.DelDrugStencil(this.stencil.ID, durgNO);
            if (parma == -1)
            {
                MessageBox.Show(Language.Msg("删除失败"));
                return;
            }
            DataRow drFind = this.dt.Rows.Find(new string[] { durgNO });
            if (drFind != null)
            {
                this.dt.Rows.Remove(drFind);
            }

            MessageBox.Show("删除成功");

            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                this.ShowList();
            }
        }

        /// <summary>
        /// 删除模版
        /// </summary>
        public void DelStencil()
        {
            if (this.dt.Rows.Count <= 0)
                return;

            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            DialogResult rs = MessageBox.Show(Language.Msg("确认删除该模版吗?\n 注意 此操作不可恢复"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            if (this.consManager.DelDrugStencil(this.stencil.ID) == -1)
            {
                MessageBox.Show(Language.Msg("删除失败"));
                return;
            }
            TreeNode tempNode = this.ucChooseList1.TvList.SelectedNode;

            this.ucChooseList1.TvList.Nodes.Remove(tempNode);

            MessageBox.Show("删除成功");
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (this.dt.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.neuSpread1.StopCellEditing();

            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.consManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.stencil == null || this.stencil.ID == "")
            {
                this.stencil.ID = this.consManager.GetNewStencilNO();
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存模版 请稍候...");
            Application.DoEvents();

            DataTable dtChange = this.dt.GetChanges(System.Data.DataRowState.Modified | System.Data.DataRowState.Added);
            if (dtChange != null && dtChange.Rows.Count > 0)
            {
                foreach (DataRow dr in dtChange.Rows)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugStencil temp = this.GetDrugStencil(dr);
                    if (temp == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg("由DataSet内获取变化后信息发生错误"));
                        return;
                    }
                    if (temp.Stencil.Name.Length > 20)//{CFEA5C18-AA93-4687-97FB-96BB7D51A620}
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg("长度大于20，请重新录入"));
                        return;
                    }
                    if (this.consManager.SetDrugStencil(temp) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg("更新模版信息失败" + this.consManager.Err));
                        return;
                    }
                }
            }

            this.dt.AcceptChanges();

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            MessageBox.Show(Language.Msg("保存成功"));

            this.IsShowList = true;

            this.Clear();

            this.ShowList();

            if (this.ucChooseList1.TvList.SelectedNode != null)
            {
                if (this.ucChooseList1.TvList.SelectedNode.Parent != null)
                {
                    this.ucChooseList1.TvList.SelectedNode = this.ucChooseList1.TvList.SelectedNode.Parent;
                }
            }
        }

        #endregion

        private void ucDrugStencil_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() == "DEVENV")
            {
                return;
            }
            else
            {

                this.InitDataSet();

                this.InitData();

                this.InitEvent();

                this.privDept = ((Neusoft.HISFC.Models.Base.Employee)(this.itemManager.Operator)).Dept;

                try
                {
                    this.ShowList();
                }
                catch { }
            }
        }      

        private void ucChooseList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRowIndex)
        {
            string drugNO = sv.Cells[activeRowIndex, 0].Text;

            this.AddData(drugNO);
        }

        private void TvList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show(Language.Msg("存在无效字符!请重新命名"));
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show(Language.Msg("模板名称不能为空"));
                    e.Node.BeginEdit();
                }

                this.stencil.Name = e.Label;
                if (this.stencil.ID != "")
                {
                    if (this.consManager.UpdateDrugStencilName(this.stencil.ID, e.Label.ToString()) == -1)
                    {
                        MessageBox.Show(Language.Msg("模版名称修改失败" + this.consManager.Err));
                        return;
                    }
                }
                else
                {
                    this.stencil.Name = e.Label.ToString();
                }
            }
        }

        private void TvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node.Parent != null)
            {
                this.stencilTypeID = e.Node.Parent.Tag.ToString();
                if (e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugStencil != null)
                {
                    this.stencil = (e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.DrugStencil).Stencil;
                    this.ShowData(this.stencil.ID);
                }
            }
            else
            {
                this.stencilTypeID = e.Node.Tag.ToString();
            }
        }

        private void TvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.ucChooseList1.TvList.SelectedNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugStencil != null)
            {
                this.IsShowList = false;
                this.txtFilter.Text = "";
            }
        }        

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuSpread1.Select();
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColSortNO;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex == 0)
                    this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                else
                    this.neuSpread1_Sheet1.ActiveRowIndex--;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.Rows.Count - 1)
                    this.neuSpread1_Sheet1.ActiveRowIndex = 0;
                else
                    this.neuSpread1_Sheet1.ActiveRowIndex++;

                e.Handled = true;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.Rows.Count - 1)
                    {
                        this.SetFocus(false);
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.ActiveRowIndex++;
                    }
                }
            }

            if (keyData == Keys.F5)
            {
                this.SetFocus(false);
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 顺序号
            /// </summary>
            ColSortNO,
            /// <summary>
            /// 操作员
            /// </summary>
            ColOperNO,
            /// <summary>
            /// 操作时间
            /// </summary>
            ColOperTime,
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugNO,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode,
            /// <summary>
            /// 通用名拼音码
            /// </summary>
            ColRegularSpell,
            /// <summary>
            /// 通用码五笔码
            /// </summary>
            ColRegularWBCode
        }                               

    }
}
