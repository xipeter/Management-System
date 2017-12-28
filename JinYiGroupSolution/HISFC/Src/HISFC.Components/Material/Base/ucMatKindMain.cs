using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
using System.Collections;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>
    /// [功能描述: 物资科目维护]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMatKindMain : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucMatKindMain()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 数据过滤
        /// </summary>
        private DataView dv;

        /// <summary>
        /// 科目数据
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 配置文件
        /// </summary>
        private string filePath = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "\\MatKind.xml";

        /// <summary>
        /// 物资科目类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset basesetManager = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 当前选择的树节点{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
        /// </summary>
        string selectedNode;


        private string kindLevel;

        /// <summary>
        /// 上级科目编码
        /// </summary>
        private string kindPreID;

        /// <summary>
        /// 编辑状态
        /// </summary>
        private string state;

        #endregion

        #region 属性

        /// <summary>
        /// 科目级别
        /// </summary>
        public string KindLevel
        {
            get
            {
                return this.kindLevel;
            }
            set
            {
                this.kindLevel = value;
            }
        }

        /// <summary>
        /// 上级科目编码
        /// </summary>
        public string KindPreID
        {
            get
            {
                return this.kindPreID;
            }
            set
            {
                this.kindPreID = value;
            }
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }


        #endregion

        #region 初始化工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            toolBarService.AddToolButton("增加", "新增物品分类", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除当前物品信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return this.toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    if (this.ucMaterialKindTree1.neuTreeView1.SelectedNode == null)
                    {
                        return;
                    }
                    //增加                        
                    if (this.ucMaterialKindTree1.neuTreeView1.SelectedNode.Tag != null)
                    {
                        this.KindPreID = this.ucMaterialKindTree1.neuTreeView1.SelectedNode.Tag.ToString();
                    }
                    this.New();
                    break;
                case "删除":
                    this.DeleteData();
                    //this.ucMaterialKindTree1.InitTreeView();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object NeuObject)
        {
            //{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
            if (this.Save(false) == 1)
            {
                this.ucMaterialKindTree1.InitTreeView();
                //{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
                this.ucMaterialKindTree1.neuTreeView1.SelectedNode = getNodeByCode(this.selectedNode, this.ucMaterialKindTree1.neuTreeView1.Nodes[0]);                
                this.ucMaterialKindTree1.Focus();
                this.ucMaterialKindTree1.neuTreeView1.Focus();
            }

            return 1;
        }

        //{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
        /// <summary>
        /// 根据编码获取树节点
        /// </summary>
        /// <param name="matID"></param>
        /// <param name="tNode"></param>
        /// <returns></returns>
        private TreeNode getNodeByCode(string matID, TreeNode tNode)
        {
            foreach (TreeNode tmpNode in tNode.Nodes)
            {
                if (tmpNode.Tag.ToString() == matID)
                {
                    return tmpNode;
                }
                if (tmpNode.Nodes.Count > 0)
                {
                    TreeNode gotNode = this.getNodeByCode(matID, tmpNode);
                    if (gotNode != tmpNode)
                    {
                        return gotNode;
                    }
                }
            }
            return tNode;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将传入数组中的数据显示在neuSpread1_Sheet1中
        /// </summary>
        public void ShowData()
        {
            this.ClearData();

            //取科目信息
            ArrayList alObject = this.basesetManager.QueryKindAll();
            if (alObject == null)
            {
                MessageBox.Show(this.basesetManager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Material.MaterialKind metKind in alObject)
            {
                this.dt.Rows.Add(new Object[] {																																			
																		metKind.Kgrade, //科目级别
				
																		//科目编码
																		metKind.ID,

																		//上级编码
																		metKind.SuperKind,

																		//科目名称
																		metKind.Name,

																		//拼音码
																		metKind.SpellCode.ToString(),

																		//五笔码
																		metKind.WBCode,

																		//最末级标识
																		metKind.EndGrade,

																		//需要卡片
																		metKind.IsCardNeed,//.ToString(),

																		//批次管理
																		metKind.IsBatch,//.ToString(),

																		//有效期管理
																		metKind.IsValidcon,//.ToString(),

																		//财务科目编码
																		metKind.AccountCode.ToString(),

																		//财务科目名称
																		metKind.AccountName.ToString(),

																		//操作员
																		//metKind.Oper.ID,

																		//操作日期
																		//metKind.OperateDate.ToString(),

																		//预计残值率
																		metKind.LeftRate.ToString(),

																		//是否固定资产
																		metKind.IsFixedAssets,//.ToString(),

																		//排列序号
																		metKind.OrderNo.ToString(),																		

																		//对应成本核算项目类别
																		metKind.StatCode,

																		//是否加价卫材
																		metKind.IsAddFlag//.ToString()
																	});
            }

            //提交DataSet中的变化。
            this.dt.AcceptChanges();

        }

        /// <summary>
        ///  初始化DataSet,并与neuSpread1_Sheet1绑定
        /// </summary>
        private void InitDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {
																			new DataColumn("科目级别",   dtStr),
																			new DataColumn("科目编码",   dtStr),
																			new DataColumn("上级编码",   dtStr),
																			new DataColumn("科目名称",   dtStr),
																			new DataColumn("拼音码",   dtStr),
																			new DataColumn("五笔码",     dtStr),
																			new DataColumn("末级标识",   dtBool),
																			new DataColumn("需要卡片",   dtBool),
																			new DataColumn("批次管理",   dtBool),
																			new DataColumn("效期管理",   dtBool),
																			new DataColumn("财务科目编码",   dtStr),
																			new DataColumn("财务科目名称",   dtStr),																			
																			new DataColumn("预计残值率",    dtStr),
																			new DataColumn("固定资产",    dtBool),
																			new DataColumn("排列序号",    dtStr),																			
																			new DataColumn("核算类别",     dtStr),
																			new DataColumn("加价卫材",   dtBool)																			
														});

            this.dv = new DataView(this.dt);
            this.dv.AllowEdit = true;
            this.dv.AllowNew = true;
            this.neuSpread1.DataSource = this.dv;
            this.SetFormat();
        }

        /// <summary>
        /// 设置fp格式
        /// </summary>
        private void SetFormat()
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].Visible = false;
            this.neuSpread1_Sheet1.Columns[6].Visible = false;
            this.neuSpread1_Sheet1.Columns[7].Visible = false;
            this.neuSpread1_Sheet1.Columns[14].Visible = false;

            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            // 不让改编码内容
            this.neuSpread1_Sheet1.Columns[1].Locked = true;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearData()
        {
            this.dt.Rows.Clear();

            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        public void DeleteData()
        {
            string kindID = "";

            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //如果选择的是fp里面的东西，则可以删除明细信息
            if (this.neuSpread1_Sheet1.ActiveRow != null)
            {
                kindID = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Value.ToString();
            }
            else
            {
                kindID = this.ucMaterialKindTree1.NodeTag;

            }
            int kindRowCount = this.basesetManager.GetKindRowCount(kindID);

            ArrayList alKind = this.basesetManager.GetMetKindByPreID(kindID);

            if (kindRowCount > 0)
            {
                MessageBox.Show("此科目下存在物品字典信息，请先删除字典信息再执行此操作!", "删除提示");
                return;
            }

            if (kindRowCount < 0)
            {
                MessageBox.Show("获取该科目下项目字典总条数出错");
                return;
            }

            if (alKind.Count > 0)
            {
                MessageBox.Show("该科目下存在下级科目信息，请先删除下级科目信息再执行此操作!", "删除提示");
                return;
            }

            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //如果是新加的，则不提示，直接删除行
            ArrayList al = this.basesetManager.GetMetKindByMetID(kindID);
            if (al == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取物资信息出错！"));
                return;
            }
            if (al.Count== 0 && this.neuSpread1_Sheet1.ActiveRow != null)
            {
                this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
            }
            else
            {

                System.Windows.Forms.DialogResult dr;
                dr = MessageBox.Show("确定要删除科目“" + (this.neuSpread1_Sheet1.ActiveRow==null?this.ucMaterialKindTree1.NodeName:this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex,3].Text)+ "”吗?", "提示!", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                basesetManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.basesetManager.DeleteMetKind(kindID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.basesetManager.Err);
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                //this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
                this.ShowData();

                MessageBox.Show("删除成功！");
                this.ucMaterialKindTree1.InitTreeView();
            }
        }

        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        //public void ChangeItem(string treeFilter)
        //{
        //    if (this.dt.Rows.Count == 0) return;

        //    try
        //    {
        //        string queryCode = "";

        //        queryCode = "%" + this.txtInputCode.Text.Trim() + "%";

        //        string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
        //            "(五笔码 LIKE '" + queryCode + "') OR " +
        //            "(科目名称 LIKE '" + queryCode + "') ";

        //        //设置过滤条件
        //        if (treeFilter == "")
        //        {
        //            this.dv.RowFilter = filter;
        //        }
        //        else
        //        {
        //            //this.dv.RowFilter = "((上级编码 = '" + treeFilter + "')or" + "(科目编码='" + treeFilter + "'))and (" + filter + ")";
        //            this.dv.RowFilter = "(上级编码 = '" + treeFilter + "')and (" + filter + ")";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public void ChangeItem()
        {
            if (this.dt.Rows.Count == 0)
                return;

            try
            {
                string queryCode = "";

                queryCode = "%" + this.txtInputCode.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(科目名称 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dv.RowFilter = "(上级编码 = '" + this.ucMaterialKindTree1.NodeTag + "')and (" + filter + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存数据{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
        /// </summary>
        public int Save(bool isTempSave)
        {
            this.selectedNode = this.ucMaterialKindTree1.neuTreeView1.SelectedNode.Tag.ToString();

            this.neuSpread1.StopCellEditing();
            //有效性判断
            if (this.Valid())
            {
                return -1;
            };

            foreach (DataRow dr in this.dt.Rows)
            {
                dr.EndEdit();
            }
            this.SetLeafFlag();

            //定义数据库处理事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            basesetManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isUpdate = false; //判断是否更新或者删除过数据

            DateTime sysTime = this.basesetManager.GetDateTimeFromSysDateTime();

            //取修改和增加的数据
            DataTable dataChanges = this.dt.GetChanges(DataRowState.Modified | DataRowState.Added);
            if (dataChanges != null)
            {
                foreach (DataRow row in dataChanges.Rows)
                {
                    Neusoft.HISFC.Models.Material.MaterialKind metKind = new Neusoft.HISFC.Models.Material.MaterialKind();

                    #region 根据本次输入信息进行科目信息赋值

                    //科目级别
                    metKind.Kgrade = row["科目级别"].ToString();

                    //科目编码
                    metKind.ID = row["科目编码"].ToString();

                    //上级编码
                    metKind.SuperKind = row["上级编码"].ToString();

                    //科目名称
                    metKind.Name = row["科目名称"].ToString();

                    //拼音码
                    metKind.SpellCode = row["拼音码"].ToString();

                    //五笔码
                    metKind.WBCode = row["五笔码"].ToString();

                    //最末级标识
                    metKind.EndGrade = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["末级标识"].ToString());

                    //需要卡片
                    metKind.IsCardNeed = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["需要卡片"].ToString());

                    //批次管理
                    metKind.IsBatch = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["批次管理"].ToString());

                    //有效期管理
                    metKind.IsValidcon = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["效期管理"].ToString());

                    //财务科目编码
                    metKind.AccountCode.ID = row["财务科目编码"].ToString();

                    //财务科目名称
                    metKind.AccountName.Name = row["财务科目名称"].ToString();

                    //预计残值率
                    metKind.LeftRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["预计残值率"].ToString());

                    //是否固定资产
                    metKind.IsFixedAssets = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["固定资产"].ToString());

                    //排列序号
                    metKind.OrderNo = Neusoft.FrameWork.Function.NConvert.ToInt32(row["排列序号"].ToString());

                    //对应成本核算项目类别
                    metKind.StatCode = row["核算类别"].ToString();

                    //是否加价卫材
                    metKind.IsAddFlag = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["加价卫材"].ToString());

                    #endregion

                    metKind.Oper.ID = this.basesetManager.Operator.ID;
                    metKind.Oper.OperTime = sysTime;

                    //执行更新操作，先更新，如果没有成功则插入新数据
                    if (this.basesetManager.SetKind(metKind) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.basesetManager.Err);

                        return 0;
                    }
                }
                dataChanges.AcceptChanges();
                isUpdate = true;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //刷新数据
            if (!isTempSave)
            {
                this.ShowData();
                MessageBox.Show("保存成功！");  
            }

            return 1;
        }

        /// <summary>
        /// 设置叶子节点标志
        /// </summary>
        public void SetLeafFlag()
        {
            foreach (DataRow dr in this.dt.Rows)
            {
                DataRow[] drList = this.dt.Select("上级编码 = '" + dr["科目编码"].ToString() + "'");
                if (drList.Length > 0)
                {
                    dr["末级标识"] = false;
                }
                else
                {
                    dr["末级标识"] = true;
                }
            }
        }

        /// <summary>
        /// 新建
        /// </summary>
        public void New()
        {
            try
            {
                //{BAF240DB-D9B6-480b-978A-9BDC019A46E8}增加多行编码重复
                if (this.HasUnsavedChange() == -1)
                {
                    return;
                }

                string kindID = this.basesetManager.GetMaxKindID(this.KindPreID);

                ArrayList al = new ArrayList();

                if (this.KindPreID == "0")
                {
                    this.dt.Rows.Add(new Object[] { "1", kindID.ToString(), "0", "", "", "", 1, 1, 1, 1, "", "", "", 1, "", "", 1 });
                }
                else
                {
                    al = this.basesetManager.QueryKindAllByID(this.KindPreID);
                    if (al != null)
                    {
                        Neusoft.HISFC.Models.Material.MaterialKind metKind;
                        metKind = al[0] as Neusoft.HISFC.Models.Material.MaterialKind;
                        this.dt.Rows.Add(new Object[] { (Convert.ToInt32(metKind.Kgrade) + 1).ToString(), kindID.ToString(), metKind.ID.ToString(), "", "", "", 1, 1, 1, 1, "", "", "", 1, "", "", 1 });
                    }
                }

                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.RowCount - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// 判断是否存在未保存的数据{BAF240DB-D9B6-480b-978A-9BDC019A46E8}
        /// </summary>
        /// <returns></returns>
        private int HasUnsavedChange()
        {
            DataTable dataChanges = this.dt.GetChanges(DataRowState.Modified | DataRowState.Added);
            //如果没有修改的数据，则直接新增行；如果有修改的数据，先保存再新增行
            if (dataChanges == null || dataChanges.Rows.Count <= 0)
            {
                return 1;
            }

            return this.Save(true);  
        }

        /// <summary>
        ///  有效性判断 
        /// </summary>	
        private bool Valid()
        {
            //for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            //{

            //    if (this.neuSpread1_Sheet1.Cells[i, 3].Text == "" || this.neuSpread1_Sheet1.Cells[i, 3] == null)
            //    {
            //        MessageBox.Show("第" + i.ToString() + "行科目名称不能为空");
            //        return true;
            //    }

            //}
            foreach (DataRow row in this.dt.Rows)
            {
                if (string.IsNullOrEmpty(row["科目名称"].ToString()))
                {
                    MessageBox.Show("科目名称不能为空");

                    return true;
                }
            }
            return false;
        }

        private bool Check()
        {
            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0501", ref testPrivDept);

            //暂时不进行权限判断

            if (parma == -1)            //无权限
            {
                MessageBox.Show("您无此窗口操作权限");
                return false;
            }
            else if (parma == 0)       //用户选择取消
            {
                return false;
            }
            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.Models.Base.Department deptObj = deptManager.GetDeptmentById(testPrivDept.ID);
            if (deptObj == null || deptObj.ID == "")
            {
                testPrivDept.Memo = deptObj.DeptType.ID.ToString();
            }
            this.ucMaterialKindTree1.storagecode = testPrivDept.ID;
            this.ucMaterialKindTree1.InitTreeView();

            return true;
        }

        #endregion

        private void ucMatKindMain_Load(object sender, EventArgs e)
        {
            //if (this.Check() == false)
            //{
            //    return;
            //}
            this.txtInputCode.TextChanged += new EventHandler(txtInputCode_TextChanged);
            this.txtInputCode.KeyUp += new KeyEventHandler(txtInputCode_KeyUp);

            this.InitDataTable();

            this.ShowData();

            this.ChangeItem();

            InputMap im;

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

        }

        private void txtInputCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.filePath);
        }

        private void txtInputCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem();
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //if (e.Column == 3)
            //{
            //    if (neuSpread1_Sheet1.Cells[e.Row, 3].Text.ToString() == "")
            //        return;
            //    Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
            //    Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

            //    spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(neuSpread1_Sheet1.Cells[e.Row, 3].Text.ToString());

            //    if (spCode.SpellCode.Length > 10)
            //        spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
            //    if (spCode.WBCode.Length > 10)
            //        spCode.WBCode = spCode.WBCode.Substring(0, 10);

            //    this.neuSpread1_Sheet1.Cells[e.Row, 4].Value = spCode.SpellCode;
            //    this.neuSpread1_Sheet1.Cells[e.Row, 5].Value = spCode.WBCode;
            //}
        }

        private void neuSpread1_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (e.Column == 3)
            {
                if (neuSpread1_Sheet1.Cells[e.Row, 3].Text.ToString() == "")
                    return;
                Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
                Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

                spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(neuSpread1_Sheet1.Cells[e.Row, 3].Text.ToString());

                if (spCode.SpellCode.Length > 10)
                    spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                if (spCode.WBCode.Length > 10)
                    spCode.WBCode = spCode.WBCode.Substring(0, 10);

                this.neuSpread1_Sheet1.Cells[e.Row, 4].Value = spCode.SpellCode;
                this.neuSpread1_Sheet1.Cells[e.Row, 5].Value = spCode.WBCode;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.neuSpread1_Sheet1.ActiveColumnIndex == 3)
                    {
                        Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
                        Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

                        spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 3].Text.ToString());

                        if (spCode.SpellCode.Length > 10)
                            spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                        if (spCode.WBCode.Length > 10)
                            spCode.WBCode = spCode.WBCode.Substring(0, 10);

                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 4].Value = spCode.SpellCode;
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 5].Value = spCode.WBCode;
                    }

                    this.neuSpread1_Sheet1.ActiveColumnIndex++;
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        private void ucMaterialKindTree1_GetLak(object sender, TreeViewEventArgs e)
        {
            //this.ChangeItem(e.Node.Tag.ToString());
            this.ChangeItem();
        }

        #region IPreArrange 成员

        public int PreArrange()
        {
            if (this.Check() == false)
            {
                return -1;
            }

            return 1;
        }

        #endregion

    }
}
