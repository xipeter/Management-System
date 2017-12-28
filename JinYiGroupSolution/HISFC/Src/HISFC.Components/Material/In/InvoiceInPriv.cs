using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.In
{
    public class InvoiceInPriv : IMatManager
    {
        #region 构造方法

        public InvoiceInPriv(Material.In.ucMatIn ucMatInManager)
        {
            this.SetMatManagerProperty(ucMatInManager);
        }

        #endregion

        #region 域变量

        /// <summary>
        /// 入库控件
        /// </summary>
        private ucMatIn ucInManager = null;

        /// <summary>
        /// DataTable
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucMatListSelect ucListSelect = null;

        /// <summary>
        /// 是否按大包装方式入库
        /// </summary>
        private bool isUsePackIn = false;

        /// <summary>
        /// 存储已添加的数据
        /// </summary>
        private System.Collections.Hashtable hsInData = new Hashtable();

        /// <summary>
        /// 库存管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.Store itemManager = new Neusoft.HISFC.BizLogic.Material.Store();

        #endregion

        #region 属性

        /// <summary>
        /// 是否使用大包装方式入库
        /// </summary>
        public bool IsUsePackIn
        {
            get
            {
                return this.isUsePackIn;
            }
            set
            {
                this.isUsePackIn = value;
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetMatManagerProperty(Material.In.ucMatIn ucMatInManager)
        {
            this.ucInManager = ucMatInManager;

            if (this.ucInManager != null)
            {
                //设置界面显示
                this.ucInManager.IsShowInputPanel = false;
                this.ucInManager.IsShowItemSelectpanel = true;
                //设置目标科室信息
                this.ucInManager.SetTargetDept(true, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                //设置工具栏按钮显示
                this.ucInManager.SetToolBarButtonVisible(false, true, false, false, true, false, false);
                //设置显示的待选择数据
                this.ShowSelectData();
                //设置列宽度
                this.ucInManager.SetItemListWidth(3);
                //信息说明设置
                this.ucInManager.ShowInfo = "F5 键转入项目选择框";
                //设置Fp属性
                this.ucInManager.Fp.EditModePermanent = false;
                this.ucInManager.Fp.EditModeReplace = true;

                this.ucInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

                this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);
                this.ucInManager.EndTargetChanged += new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);

                this.ucInManager.Fp.EditModeOn += new EventHandler(Fp_EditModeOn);
                this.ucInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);
            }
        }


        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Material.Input input)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal inQty = 0;				//入库数量 (根据参数以包装单位或最小单位显示)
                decimal inPrice = 0;			//入库购入价 根据参数决定包装价格或最小单位价格
                string inUnit = "";			//入库单位 (根据参数以包装单位或最小单位显示)

                if (this.isUsePackIn)			//按包装单位入库
                {
                    inQty = input.PackInQty;	//包装数量入库
                    inPrice = input.StoreBase.Item.PackPrice;							//包装单位价格
                    inUnit = input.StoreBase.Item.PackUnit;								//包装单位
                }
                else
                {
                    inQty = input.StoreBase.Quantity;									//最小数量入库
                    inPrice = input.StoreBase.PriceCollection.PurchasePrice;			//最小单位价格
                    inUnit = input.StoreBase.Item.MinUnit;								//最小单位
                }

                this.dt.Rows.Add(new object[] { 												 
												  input.StoreBase.Item.Name,                            //物品名称
												  input.StoreBase.Item.Specs,                           //规格												 												  
												  inUnit,												//包装单位
												  input.StoreBase.Item.PackQty,                         //包装数量
												  inQty, 												//入库数量
												  inPrice,												//购入价
												  input.InCost,                                         //购入金额 (购入价金额)
												  input.StoreBase.BatchNO,                              //批号
												  input.StoreBase.ValidTime,                            //有效期
												  input.InvoiceNO,										//发票号
												  input.InvoiceTime,									//发票日期
												  input.StoreBase.PriceCollection.RetailPrice,			//零售价 最小单位零售价
												  input.StoreBase.RetailCost,							//零售金额
												  input.StoreBase.Producer.Name,						//生产厂家
												  input.StoreBase.Item.ID,                              //项目编码
												  input.ID,												//流水号
												  input.StoreBase.StockNO,								//库存序号
												  input.StoreBase.Item.SpellCode,						//拼音码
												  input.StoreBase.Item.WbCode,							//五笔码
												  input.StoreBase.Item.UserCode,						//自定义码													  
											  }
                    );
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + e.Message);

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + ex.Message);

                return -1;
            }

            return 1;
        }


        /// <summary>
        /// 设置显示数据
        /// </summary>
        /// <returns></returns>
        private int ShowSelectData()
        {
            string[] filterStr = new string[2] { "SPELL_CODE", "WB_CODE" };
            string[] label = new string[] { "物品编码", "物品名称", "规格", "入库数量", "供货单位", "入库流水号", "拼音码", "五笔码" };
            int[] width = new int[] { 60, 120, 80, 60, 120, 60, 60, 60 };
            bool[] visible = new bool[] { false, true, true, true, true, false, false, false };
            string targetNO = this.ucInManager.TargetDept.ID;
            if (targetNO == "")
                targetNO = "AAAA";

            this.ucInManager.SetSelectData("3", false, new string[] { "Material.Store.GetStoreListForInput" }, filterStr, this.ucInManager.DeptInfo.ID, "0", targetNO);

            this.ucInManager.SetSelectFormat(label, width, visible);

            return 1;
        }


        /// <summary>
        /// 添加入库数据
        /// </summary>
        /// <param name="listNO">入库单号</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        protected virtual int AddInData(string listNO, string state)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据单据加载数据 请稍候...");
            Application.DoEvents();

            ArrayList alDetail = new ArrayList();
            alDetail = this.itemManager.QueryInputDetailByListNO(this.ucInManager.DeptInfo.ID, listNO, "AAAA", "A");
            if (alDetail == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.ucInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Material.Input input in alDetail)
            {
                this.AddDataToTable(input);
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //已经用流水号做主键了
                //this.hsInData.Add(input.StoreBase.Item.ID + input.ID, input);
                this.hsInData.Add(input.ID, input);
            }

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.ucInManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm(); ;

            this.SetFocusSelect();

            return 1;
        }


        /// <summary>
        /// 设置Fp显示
        /// </summary>
        public virtual void SetFormat()
        {
            if (this.ucInManager.FpSheetView == null)
                return;

            this.ucInManager.FpSheetView.DefaultStyle.Locked = true;
            this.ucInManager.FpSheetView.DataAutoSizeColumns = false;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Width = 65F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColUnit].Width = 60F;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].Visible = true;           //入库金额			
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColItemID].Visible = false;           //物品编码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号					
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProducerName].Visible = false;      //生产厂家
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailCost].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPackQty].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColValidTime].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPackQty].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInBillNO].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColStockNO].Visible = false;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].Locked = false;



            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].BackColor = System.Drawing.Color.SeaShell;
        }


        /// <summary>
        /// 总金额显示计算
        /// </summary>
        /// <param name="checkAll"></param>
        /// <param name="retailCost"></param>
        /// <param name="purchaseCost"></param>
        /// <param name="balanceCost"></param>
        protected void CompuateSum()
        {
            decimal retailCost = 0;
            decimal purchaseCost = 0;
            decimal balanceCost = 0;

            foreach (DataRow dr in this.dt.Rows)
            {
                retailCost += NConvert.ToDecimal(dr["入库金额"]);
                purchaseCost += NConvert.ToDecimal(dr["购入金额"]);
            }

            balanceCost = retailCost - purchaseCost;

            this.ucInManager.TotCostInfo = string.Format("零售总金额:{0} 购入总金额:{1}", retailCost.ToString("N"), purchaseCost.ToString("N"));
        }


        #endregion

        #region IMatManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                // TODO:  添加 InvoiceInPriv.InputModualUC getter 实现
                return null;
            }
        }

        /// <summary>
        /// 数据表初始化
        /// </summary>
        /// <returns></returns>
        public DataTable InitDataTable()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            this.dt = new DataTable();

            this.dt.Columns.AddRange(
                new System.Data.DataColumn[] {												
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),						 
												 new DataColumn("单位",  dtStr),
												 new DataColumn("包装数量",	 dtDec),
												 new DataColumn("入库数量",  dtDec),
												 new DataColumn("购入价",    dtDec),	
												 new DataColumn("购入金额",  dtDec),
												 new DataColumn("批号",      dtStr),
												 new DataColumn("有效期",	 dtDate),
												 new DataColumn("发票号",    dtStr),
												 new DataColumn("发票日期",  dtDate),
												 new DataColumn("零售价",	 dtDec),
												 new DataColumn("零售金额",  dtDec),
												 new DataColumn("生产厂家",  dtStr),
												 new DataColumn("项目编码",  dtStr),
												 new DataColumn("流水号",	 dtStr),
												 new DataColumn("库存序号",dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr)
												 
											 }
                );

            DataColumn[] keys = new DataColumn[1];

            keys[0] = this.dt.Columns["流水号"];
            //			keys[0] = this.dt.Columns["库存序号"];

            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            return this.dt;
        }

        /// <summary>
        /// 项目信息加入
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string inNO = sv.Cells[activeRow, 5].Text;
            //			string stockNO = sv.Cells[activeRow, 6].Text;

            ArrayList al = this.itemManager.QueryInputDetailByInNO(inNO, "0");

            Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

            foreach (Neusoft.HISFC.Models.Material.Input info in al)
            {
                input = info;
            }

            if (input == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return -1;
            }
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //已经用流水号做主键了
            if (this.hsInData.ContainsKey(input.ID))//input.StoreBase.Item.ID + input.ID
            {
                MessageBox.Show("该物品已添加");
                return -1;
            }

            if (this.AddDataToTable(input) == 1)
            {
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //已经用流水号做主键了
                this.hsInData.Add(input.ID, input);//input.StoreBase.Item.ID + input.ID
            }

            this.SetFormat();

            this.SetFocusSelect();

            return 1;
        }

        /// <summary>
        /// 增加物品项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parms"></param>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, Neusoft.HISFC.Models.Material.Input input)
        {
            return 0;
        }

        /// <summary>
        /// 申请单列表
        /// </summary>
        /// <returns></returns>
        public int ShowApplyList()
        {
            return 1;
        }

        /// <summary>
        /// 入库单列表
        /// </summary>
        /// <returns></returns>
        public int ShowInList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucMatListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.ucInManager.DeptInfo;
                this.ucListSelect.State = "0";                  //需检索状态
                this.ucListSelect.Class2Priv = "0510";          //入库

                this.ucListSelect.SelecctListEvent -= new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);
                this.ucListSelect.SelecctListEvent += new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucListSelect);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 出库单列表
        /// </summary>
        /// <returns></returns>
        public int ShowOutList()
        {
            // TODO:  添加 InvoiceInPriv.ShowOutList 实现
            return 1;
        }

        /// <summary>
        /// 显示库存项目列表
        /// </summary>
        /// <returns></returns>
        public int ShowStockList()
        {
            // TODO:  添加 InvoiceInPriv.ShowStockList 实现
            return 1;
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            bool isHave = false;
            for (int i = 0; i < this.ucInManager.FpSheetView.Rows.Count; i++)
            {
                if (this.ucInManager.FpSheetView.Cells[i, (int)ColumnSet.ColInvoiceNO].Text == "")
                {
                    isHave = true;
                    break;
                }
            }
            if (isHave)
            {
                //this.ucInManager.FpSheetView.Cells[i,(int)ColumnSet.ColTradeName].Text
                if (MessageBox.Show("部分数据没有输入发票号,是否继续？", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="delRowIndex"></param>
        /// <returns></returns>
        public int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            try
            {
                if (sv != null && delRowIndex >= 0)
                {
                    DialogResult rs = MessageBox.Show("确认删除该条数据吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                    //已经用流水号做主键了
                    //string[] keys = new string[]{
                    //                                sv.Cells[delRowIndex, (int)ColumnSet.ColItemID].Text,
                    //                                sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
                    //                            };
                    string[] keys = new string[]{
                                                    sv.Cells[delRowIndex, (int)ColumnSet.ColInBillNO].Text
                                                };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                        //已经用流水号做主键了
                        //this.hsInData.Remove(dr["物品编码"].ToString() + dr["批号"].ToString());
                        this.hsInData.Remove(dr["流水号"].ToString());
                        this.dt.Rows.Remove(dr);
                    }
                }
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show("对数据表执行删除操作发生错误" + e.Message);
                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("对数据表执行删除操作发生错误" + ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            try
            {
                this.dt.Rows.Clear();

                this.dt.AcceptChanges();

                this.hsInData.Clear();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("执行清空操作发生错误" + ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="filterStr"></param>
        public void Filter(string filterStr)
        {
            if (this.dt == null)
                return;

            //获得过滤条件
            string queryCode = "%" + filterStr + "%";

            string filter = Function.GetFilterStr(this.dt.DefaultView, queryCode);

            try
            {
                this.dt.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("过滤发生异常 " + ex.Message);
            }
            this.SetFormat();
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        public void SetFocusSelect()
        {
            if (this.ucInManager.FpSheetView != null)
            {
                if (this.ucInManager.FpSheetView.Rows.Count > 0)
                {
                    this.ucInManager.SetFpFocus();

                    this.ucInManager.FpSheetView.ActiveRowIndex = this.ucInManager.FpSheetView.Rows.Count - 1;
                    this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                }
                else
                {
                    this.ucInManager.SetFocus();
                }
            }
        }

        // <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (!this.Valid())
            {
                return;
            }

            this.dt.DefaultView.RowFilter = "1=1";
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            ArrayList alInput = new ArrayList();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["流水号"].ToString() + dr["库存序号"].ToString();

                //没有输入发票号的不保存
                if (dr["发票号"] == null || dr["发票号"].ToString().Trim() == "")
                {
                    continue;
                }

                //				Neusoft.HISFC.Models.Material.Input input = this.hsInData[key] as Neusoft.HISFC.Models.Material.Input;
                Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

                input.StoreBase.Operation.ExamOper.ID = this.ucInManager.OperInfo.ID.ToString();                //审批人
                input.StoreBase.Operation.ExamOper.OperTime = sysTime;                                //审批时间
                input.InvoiceNO = dr["发票号"].ToString().Trim();
                input.InvoiceTime = NConvert.ToDateTime(dr["发票日期"].ToString().Trim());
                input.ID = dr["流水号"].ToString();
                input.StoreBase.StockNO = dr["库存序号"].ToString();
                //				input.StoreBase.PriceCollection.PurchasePrice = NConvert.ToDecimal(dr["购入价"]);
                //				input.StoreBase.PurchaseCost = NConvert.ToDecimal(dr["购入金额"]);

                int parm = this.itemManager.ExamInput(input);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.itemManager.Err);
                    return;
                }
                if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("数据可能已被审核，请刷新重试");
                    return;
                }

                alInput.Add(input);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("补录发票成功");

            //			if(alInput.Count > 0)
            //			{
            //				Local.GyHis.Material.ucMatInput ucMat = new Local.GyHis.Material.ucMatInput();
            //				ucMat.Decimals = 2;
            //				ucMat.MaxRowNo = 17;
            //
            //				ucMat.SetDataForInput(alInput,1,this.itemManager.Operator.ID,"1");
            //
            //			}

            //清屏显示
            this.Clear();
            this.ShowSelectData();

            FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numCellType;
        }

        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // TODO:  添加 InvoiceInPriv.Print 实现
            return 1;
        }

        public int Cancel()
        {
            // TODO:  添加 InApplyPriv.Print 实现
            return 1;
        }

        public int ImportData()
        {
            return 1;
        }

        #endregion

        #region IMatManager 成员

        //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
        //先释放掉事件资源
        public void Dispose()
        {
            this.ucInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);

            this.ucInManager.Fp.EditModeOn -= new EventHandler(Fp_EditModeOn);
            this.ucInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
        }

        #endregion

        #region 事件

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            if (state == "2")
            {
                MessageBox.Show(Language.Msg("不能对已核准的数据再次进行发票入库"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.ucInManager.TargetDept = targetDept;

            this.Clear();

            this.AddInData(listCode, state);
        }


        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.Clear();

            this.ShowSelectData();
        }


        private void value_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.ucInManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceNO)
                    {
                        if (this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].Visible && !this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].Locked)
                        {
                            this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceTime;
                        }
                        return;
                    }
                    if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceTime)
                    {
                        if (this.ucInManager.FpSheetView.ActiveRowIndex == this.ucInManager.FpSheetView.Rows.Count - 1)
                        {
                            this.ucInManager.SetFocus();
                        }
                        else
                        {
                            this.ucInManager.FpSheetView.ActiveRowIndex++;
                            this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                        }
                        return;
                    }
                }
            }
        }


        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
            {
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //已经用流水号做主键了
                //string[] keys = new string[] { this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text, this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemID].Text };
                string[] keys = new string[] { this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColInBillNO].Text };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["购入金额"] = NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }


        private void Fp_EditModeOn(object sender, EventArgs e)
        {
            if (this.ucInManager.FpSheetView.ActiveRowIndex == (int)ColumnSet.ColPurchasePrice)
            {
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //已经用流水号做主键了
                //string[] keys = new string[] { this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text, this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemID].Text };
                string[] keys = new string[] { this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColInBillNO].Text };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["购入金额"] = NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    this.CompuateSum();
                }
            }
        }


        #endregion

        #region 列枚举

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
            /// 包装单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
            /// <summary>
            /// 入库数量（包装单位数量）
            /// </summary>
            ColInQty,
            /// <summary>
            /// 购入价
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 入库金额
            /// </summary>
            ColInCost,
            /// <summary>
            /// 批号
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 有效期
            /// </summary>
            ColValidTime,
            /// <summary>
            /// 发票号
            /// </summary>
            ColInvoiceNO,
            /// <summary>
            /// 发票日期
            /// </summary>
            ColInvoiceTime,
            /// <summary>
            /// 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 零售金额
            /// </summary>
            ColRetailCost,
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProducerName,
            /// <summary>
            /// 项目编码
            /// </summary>
            ColItemID,
            /// <summary>
            /// 流水号
            /// </summary>
            ColInBillNO,
            /// <summary>
            /// 库存序号
            /// </summary>
            ColStockNO,
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
            ColUserCode
        }

        #endregion
    }
}
