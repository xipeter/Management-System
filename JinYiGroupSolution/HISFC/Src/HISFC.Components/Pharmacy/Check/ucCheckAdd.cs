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

namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    /// <summary>
    /// [功能描述: 药品盘点单附加控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1.屏蔽参数获取，修改从科室库存常数中获取是否管理批号 by Sunjh 2010-8-24 {41170BF0-5EFE-4f24-8D63-6CF2AE9FBAAA}
    /// </修改记录>
    /// </summary>
    public partial class ucCheckAdd : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCheckAdd()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 药品管理业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 盘点附加权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品常数管理业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 选中数据
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.Check> chooseData = new List<Neusoft.HISFC.Models.Pharmacy.Check>();

        /// <summary>
        /// 按钮点击结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;

        private bool isShowAddCheckBox = false;

        private bool isShowButton = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示盘点附加的CheckBox
        /// </summary>
        [Description("是否显示盘点附加Check列"), Category("设置"), DefaultValue(false)]
        public bool IsShowAddCheckBox
        {
            get
            {
                return this.isShowAddCheckBox;
            }
            set
            {
                this.isShowAddCheckBox = value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsAdd].Visible = value;
            }
        }

        /// <summary>
        /// 是否显示下部功能按钮
        /// </summary>
        [Description("是否显示下部功能按钮"), Category("设置"), DefaultValue(false)]
        public bool IsShowButton
        {
            get
            {
                return this.isShowButton;
            }
            set
            {
                this.isShowButton = value;
                this.gbButton.Visible = !value;
                this.splitContainer1.Panel1Collapsed = !value;
            }            
        }

        /// <summary>
        /// 当前选择数据
        /// </summary>
        public List<Neusoft.HISFC.Models.Pharmacy.Check> ChooseData
        {
            get
            {
                return this.chooseData;
            }
        }

        /// <summary>
        /// 按钮点击结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删除明细", "删除当前选择的药品", 8, true, false, null);
            toolBarService.AddToolButton("整单删除", "删除整张单据", 8, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除明细")
            {
                this.DeleteDetail();
            }
            if (e.ClickedItem.Text == "整单删除")
            {
                this.DelAll(this.privDept.ID);
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save(this.privDept.ID);

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return 1;
        }

        #endregion

        #region 初始化DataTable及Fp设置

        /// <summary>
        /// 初始化DataSet
        /// </summary>
        private void InitDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            this.dt.Columns.AddRange(new DataColumn[] {
                                                                    new DataColumn("加入盘点",    dtBol),
                                                                    new DataColumn("药品编码",	  dtStr),
                                                                    new DataColumn("自定义码",    dtStr),
                                                                    new DataColumn("药品名称",	  dtStr),
                                                                    new DataColumn("规格",		  dtStr),
                                                                    new DataColumn("库位号",	  dtStr),
                                                                    new DataColumn("批号",		  dtStr),
                                                                    new DataColumn("拼音码",      dtStr),
                                                                    new DataColumn("五笔码",      dtStr),
                                                                    new DataColumn("通用名拼音码",dtStr),
                                                                    new DataColumn("通用名五笔码",dtStr),
            });

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.SetFormat();
        }

        /// <summary>
        /// Fp格式化
        /// </summary>
        private void SetFormat()
        {
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradeName].Width = 200F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpecs].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBatchNO].Width = 60F;

            if (this.isShowAddCheckBox)
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsAdd].Visible = true;
            else
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsAdd].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDrugNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRegularSpell].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRegularWB].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlaceCode].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsAdd].Locked = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlaceCode].BackColor = System.Drawing.Color.SeaShell;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            //提示操作员选择操作科室并判断是否有操作权限
            //int privParm = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0305", ref this.privDept);
            //if (privParm == 0)
            //{
            //    return;
            //}

            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept;

            //修改为由控制参数获取是否按批号盘点
            Neusoft.HISFC.BizLogic.Manager.Controler ctrlMgr = new Neusoft.HISFC.BizLogic.Manager.Controler();
            //string ctrlStr = ctrlMgr.QueryControlerInfo("510001");            
            //if (ctrlStr == "1")
            //    this.ucDrugList1.ShowDeptStorage(this.privDept.ID, true, 0);
            //else
            //    this.ucDrugList1.ShowDeptStorage(this.privDept.ID, false, 0);

            //屏蔽参数获取，修改从科室库存常数中获取是否管理批号 by Sunjh 2010-8-24 {41170BF0-5EFE-4f24-8D63-6CF2AE9FBAAA}
            bool isBatch = this.consManager.IsManageBatch(this.privDept.ID);
            if (isBatch)
            {
                this.ucDrugList1.ShowDeptStorage(this.privDept.ID, true, 0);
            }
            else
            {
                this.ucDrugList1.ShowDeptStorage(this.privDept.ID, false, 0);
            }

            this.splitContainer1.SplitterDistance = 140;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="item">盘点附加实体</param>
        public int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Check check)
        {
            try
            {
                this.dt.Rows.Add(new object[]{
                                                          false,							                // 加入盘点
                                                          check.Item.ID,							        // 药品编码
                                                          check.Item.NameCollection.UserCode,               // 自定义码
                                                          check.Item.Name,						            // 药品名称
                                                          check.Item.Specs,						            // 规格
                                                          check.PlaceNO,						            // 库位号
                                                          check.BatchNO,						            // 批号
                                                          check.Item.NameCollection.SpellCode,	            // 拼音码
                                                          check.Item.NameCollection.WBCode,   	            // 五笔码
                                                          check.Item.NameCollection.RegularSpell.SpellCode,	// 通用名拼音码
                                                          check.Item.NameCollection.RegularSpell.WBCode	    // 通用名五笔码														
                                                      }
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 清除
        /// </summary>
        protected void Clear()
        {
            try
            {
                this.dt.Rows.Clear();

                this.neuSpread1_Sheet1.Rows.Count = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        /// <param name="isFpFocus"></param>
        protected void SetFocus(bool isFpFocus)
        {
            if (isFpFocus)
            {
                this.neuSpread1.Select();
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColPlaceCode;
            }
            else
            {
                this.ucDrugList1.Select();
                this.ucDrugList1.SetFocusSelect();
            }
        }

        /// <summary>
        /// 加载科室盘点药品附加信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        public void ShowCheckAdd(string deptNO)
        {
            this.Clear();

            //取盘点附加信息
            ArrayList alDetail = this.itemManager.QueryCheckAddByDept(deptNO);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg("加载科室盘点信息错误" + this.itemManager.Err));
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Check check in alDetail)
            {
                check.Item = this.itemManager.GetItem(check.Item.ID);
                if (check.Item == null)
                {
                    MessageBox.Show(Language.Msg("加载盘点附加信息时 获取药品信息出错" + this.itemManager.Err));
                    return;
                }

                if (this.AddDataToTable(check) == -1)
                {
                    MessageBox.Show(Language.Msg("向数据表加入盘点附加信息时出错"));
                    return;
                }
            }

            this.SetFocus(false);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteDetail()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            if (this.dt.Rows.Count == 1)
            {
                MessageBox.Show(Language.Msg("该单只剩一个药 请选择整单删除"));
                return;
            }
            
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
        }

        /// <summary>
        /// 删除所有盘点附加信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        public void DelAll(string deptNO)
        {
            if (this.dt.Rows.Count <= 0)
                return;

            DialogResult result;
            result = MessageBox.Show("确认删除当前所有记录吗? 此操作不可恢复", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return;
            }
           
            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.itemManager.DeleteCheckAdd(deptNO) == -1)            
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("删除成功"));

            this.Clear();
        }

        /// <summary>
        /// 盘点是否允许保存
        /// </summary>
        /// <returns>是否允许保存</returns>
        public bool IsValid()
        {
            if (this.dt.Rows.Count <= 0)
                return false;

            foreach (DataRow row in this.dt.Rows)
            {
                if (row["库位号"].ToString().Trim() == "")
                {
                    MessageBox.Show(Language.Msg("请维护" + row["药品名称"].ToString() + "   库位号"));
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 对盘点附加信息保存
        /// </summary>
        /// <param name="deptNO"></param>
        public void Save(string deptNO)
        {
            if (!this.IsValid())
                return;

            this.txtFilter.Text = "";
            this.dt.DefaultView.RowFilter = "1=1";
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存.请稍候...");
            Application.DoEvents();

            if (this.itemManager.DeleteCheckAdd(deptNO) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("保存前删除原附加信息发生错误" + this.itemManager.Err));
                return;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.Check info = new Neusoft.HISFC.Models.Pharmacy.Check();

                info.Item.ID = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDrugNO].Text;      //药品编码
                info.StockDept = this.privDept;                                                     //库房科室
                info.PlaceNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColPlaceCode].Text;   //货位号
                info.BatchNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBatchNO].Text;     //批号
                info.Operation.Oper.ID = this.itemManager.Operator.ID;
                info.Operation.Oper.OperTime = sysTime;                                             //操作信息

                if (this.itemManager.InsertCheckAdd(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (this.itemManager.DBErrCode == 1)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg("数据已存在,不能重复维护！\n" + "药品名称：" + this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColTradeName].Text + "   库位号：" + info.PlaceNO));
                        return;
                    }
                    else
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg(this.itemManager.Err));
                        return;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            MessageBox.Show(Language.Msg("保存成功"));
        }

        /// <summary>
        /// 对于选中的药品返回ArrayList加入盘点单
        /// </summary>
        /// <returns>成功选择返回1 否则返回－1</returns>
        public int SaveChoose()
        {
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            string filter = "加入盘点 = true";

            this.dt.DefaultView.RowFilter = filter;

            if (MessageBox.Show(Language.Msg("确定要增加您选中的“" + this.neuSpread1_Sheet1.Rows.Count.ToString() + "”条药品吗？"), "确认加入盘点", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                filter = "1=1";
                this.dt.DefaultView.RowFilter = filter;
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Check info;

            this.chooseData = new List<Neusoft.HISFC.Models.Pharmacy.Check>();

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                info = new Neusoft.HISFC.Models.Pharmacy.Check();

                info.PlaceNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColPlaceCode].Text;		//库位号
                info.Item.ID = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDrugNO].Text;			//药品编码
                info.BatchNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBatchNO].Text;			//批号
                info.IsAdd = true;												                        //是否附加 1 附加药品
                
                this.chooseData.Add(info);
            }

            return 1;
        }

        #endregion

        private void ucCheckAdd_Load(object sender, EventArgs e)
        {
            this.InitDataTable();

            this.SetFormat();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitData();

                this.ShowCheckAdd(this.privDept.ID);

                this.SetFocus(false);
            }
        }       

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (activeRow < 0)
                return;

            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(sv.Cells[activeRow, 0].Text);

            Neusoft.HISFC.Models.Pharmacy.Check check = new Neusoft.HISFC.Models.Pharmacy.Check();

            check.Item = item;
            check.PlaceNO = sv.Cells[activeRow, 4].Text;            //货位号
            check.BatchNO = sv.Cells[activeRow, 3].Text;            //批号

            if (this.AddDataToTable(check) == 1)
                this.SetFocus(true);
            else
                this.SetFocus(false);
        }  

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
                this.result = DialogResult.Cancel;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveChoose() == -1)
                return;

            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
                this.result = DialogResult.OK;
            }
        }       

        private void txtFilter1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtFilter.Text != "")
                    this.dt.DefaultView.RowFilter = Function.GetFilterStr(this.dt.DefaultView, "%" + this.txtFilter.Text + "%");
                else
                    this.dt.DefaultView.RowFilter = "1=1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;

                return;
            }

            if (e.KeyData == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;

                return;
            }
        }

        private void fpSpread1_Click(object sender, EventArgs e)
        {
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;
            int j = this.neuSpread1_Sheet1.ActiveColumnIndex;
            if (j == (int)ColumnSet.ColPlaceCode)
            {
                this.neuSpread1_Sheet1.SetActiveCell(i, (int)ColumnSet.ColPlaceCode, false);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColIsAdd].Value = true;
            }
            //foreach (DataRow dr in this.dt.Rows)
            //{
            //    dr["加入盘点"] = true;
            //}
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColIsAdd].Value = false;
            }

            //foreach (DataRow dr in this.dt.Rows)
            //{
            //    dr["加入盘点"] = false;
            //}
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && this.neuSpread1.ContainsFocus)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.Rows.Count - 1)
                {
                    this.SetFocus(false);
                }
                else
                {
                    if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColPlaceCode)
                        this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.ActiveRowIndex + 1;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private enum ColumnSet
        {
            /// <summary>
            /// 是否加入盘点
            /// </summary>
            ColIsAdd,
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugNO,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode,
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 货位号
            /// </summary>
            ColPlaceCode,
            /// <summary>
            /// 批号
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 通用名拼音码
            /// </summary>
            ColRegularSpell,
            /// <summary>
            /// 通用码五笔码
            /// </summary>
            ColRegularWB
        }           
    }
}
