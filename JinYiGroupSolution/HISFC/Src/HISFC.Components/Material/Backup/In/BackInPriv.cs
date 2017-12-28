using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.In
{
    public class BackInPriv : IMatManager
    {
        #region 构造方法

        public BackInPriv(In.ucMatIn ucMatInManager)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.SetMatManagerProperty(ucMatInManager);
            }
        }

        #endregion

        #region 域变量

        private In.ucMatIn matInManager = null;

        private DataTable dt = null;

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 存储已添加的数据
        /// </summary>
        private System.Collections.Hashtable hsInData = new Hashtable();
        /// <summary>
        /// 参数控制业务类{7019A2A6-ADCA-4984-944B-C4F1A312449A}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        /// <summary>
        /// 单据选择控件
        /// </summary>
        private Material.ucMatListSelect ucListSelect = null;
        /// <summary>
        /// 物资列表中显示的列数{7019A2A6-ADCA-4984-944B-C4F1A312449A}
        /// </summary>
        private int visibleColumns = 3;
        /// <summary>
        /// 入库是否需要核准
        /// </summary>
        private bool IsNeedApprove = false;

        private List<Neusoft.HISFC.Models.Material.Input> alInput = null;

        #endregion

        #region 方法

        /// <summary>
        /// /初始化
        /// </summary>
        protected virtual void Init()
        {
            //获取控制参数判断是否需要核准
            Neusoft.HISFC.BizLogic.Manager.Controler ctrlManager = new Neusoft.HISFC.BizLogic.Manager.Controler();
            string ctlApprove = ctrlManager.QueryControlerInfo("500002");
            //{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            visibleColumns = controlIntegrate.GetControlParam<int>("MT0002", true);
            if (ctlApprove == "0")
                this.IsNeedApprove = false;
            else
                this.IsNeedApprove = true;
        }

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        protected void SetMatManagerProperty(In.ucMatIn ucPhaManager)
        {
            this.matInManager = ucPhaManager;

            if (this.matInManager != null)
            {
                //设置界面显示
                this.matInManager.IsShowItemSelectpanel = false;
                //设置目标科室信息
                this.matInManager.SetTargetDept(true, false, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                //设置需过滤数据
                if (this.matInManager.TargetDept.ID != "")
                {
                    this.ShowSelectData();
                }
                //设置工具栏按钮显示
                this.matInManager.SetToolBarButton(false, true, false, false, true);
                //{17B337D1-FE4C-4576-BB3C-7FFAD8C8D27C}入库退库时不应该显示采购单
                //this.matInManager.SetToolBarButtonVisible(false, true, false, true, true, true, false);
                this.matInManager.SetToolBarButtonVisible(false, true, false, false, true, true, false);
                //设置项目列表宽度{7019A2A6-ADCA-4984-944B-C4F1A312449A}
                this.matInManager.SetItemListWidth(visibleColumns);
                //设置Fp
                this.matInManager.Fp.EditModePermanent = false;
                this.matInManager.Fp.EditModeReplace = true;
                this.matInManager.FpSheetView.DataAutoSizeColumns = false;

                this.matInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);
                this.matInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

                this.matInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);
                this.matInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

                this.matInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.matInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);
            }
        }

        /// <summary>
        /// 设置显示数据
        /// </summary>
        /// <returns></returns>
        private int ShowSelectData()
        {
            string[] filterStr = new string[4] { "SPELL_CODE", "WB_CODE", "REGULAR_SPELL", "REGULAR_WB" };
            string[] label = new string[] { "物品编码", "批次", "物品名称", "规格", "购入价", "拼音码", "五笔码", "自定义码" };
            int[] width = new int[] { 60, 60, 120, 80, 60, 60, 60, 60, 60 };
            bool[] visible = new bool[] { false, false, true, true, true, true, false, false, false };
            //{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            this.matInManager.DeptCode = this.matInManager.DeptInfo.ID;
            this.matInManager.SetSelectData("0", false, new string[] { "Material.Store.GetStockForBackIn" }, filterStr, this.matInManager.DeptInfo.ID);

            this.matInManager.SetSelectFormat(label, width, visible);

            return 1;
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
                input.InCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.PurchasePrice;
                decimal storeQty = 0;
                this.storeManager.GetStoreQty(this.matInManager.DeptInfo.ID, input.StoreBase.Item.ID, input.StoreBase.StockNO, out storeQty);

                this.dt.Rows.Add(new object[] { 
												  input.StoreBase.Item.Name,                            //物品名称
												  input.StoreBase.Item.Specs,                           //规格
												  input.StoreBase.BatchNO,                              //批号
												  input.StoreBase.PriceCollection.PurchasePrice,		//购入价												  
												  input.StoreBase.Item.MinUnit,                         //最小单位（计量单位）
                                                  storeQty,						        //入库数量
												  input.InCost,											//入库金额   
												  0,													//退库数量
												  0,													//退库金额
												  input.InvoiceNO,										//发票号
                                                  input.InvoiceTime,
												  input.Memo,											//备注
												  input.StoreBase.Item.ID,								//物品
												  input.StoreBase.StockNO,                              //批次
												  input.StoreBase.Item.SpellCode,						//拼音码
												  input.StoreBase.Item.WBCode,							//五笔码
												  input.StoreBase.Item.UserCode							//自定义码                            					
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
        /// 添加入库数据
        /// </summary>
        /// <param name="listNO">入库单号</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        protected virtual int AddInData(string listNO, string state)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据单据加载数据 请稍候...");
            Application.DoEvents();

            ArrayList alDetail = this.storeManager.QueryInputDetailByListNO(this.matInManager.DeptInfo.ID, listNO, this.matInManager.TargetDept.ID, state);
            if (alDetail == null)
            {
                Function.ShowMsg(this.storeManager.Err);
                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.matInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Material.Input input in alDetail)
            {
                //{6039DDA1-44F2-42d3-B7F7-544E69F5FE26} 可退数量为0的物资项目不显示
                if (input.StoreBase.Quantity - input.StoreBase.Returns == 0)
                {
                    continue;
                }
                //---------------
                input.StoreBase.PrivType = this.matInManager.PrivType.ID;             //入库类型
                input.StoreBase.SystemType = this.matInManager.PrivType.Memo;         //系统类型

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInData.Add(this.GetKey(input), input);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }
            //{6039DDA1-44F2-42d3-B7F7-544E69F5FE26}可退数量为0的物资项目不显示
            if (this.matInManager.FpSheetView.RowCount == 0)
            {
                MessageBox.Show("这张单据已经做过全部退库。");
            }
            //---------------
            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.matInManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetFocusSelect();

            return 1;
        }

        /// <summary>
        /// 根据物品编码与批次号加入入库退库信息
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="stockNO"></param>
        /// <returns></returns>
        protected virtual int AddInData(string itemCode, int stockNO)
        {
            if (this.hsInData.ContainsKey(itemCode + stockNO.ToString()))
            {
                MessageBox.Show("该物品已添加");
                return 0;
            }
            List<Neusoft.HISFC.Models.Material.StoreDetail> alDetail = this.storeManager.QueryStoreList(this.matInManager.DeptInfo.ID, itemCode, stockNO.ToString(), true);
            if (alDetail == null || alDetail.Count == 0)
            {
                MessageBox.Show("未获取有效的库存明细信息" + this.storeManager.Err);
                return -1;
            }

            Neusoft.HISFC.Models.Material.StoreDetail storeDetail = alDetail[0];

            Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

            input.StoreBase = storeDetail.StoreBase;									//库存基本信息
            input.StoreBase.Quantity = storeDetail.StoreBase.StoreQty;                  //入库量 = 库存量

            input.Memo = storeDetail.Memo;

            if (this.AddDataToTable(input) == 1)
            {
                this.hsInData.Add(itemCode + stockNO.ToString(), input);
            }

            this.SetFormat();

            this.SetFocusSelect();

            return 1;
        }

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Material.Input input)
        {
            return input.StoreBase.Item.ID + input.StoreBase.StockNO.ToString();
        }

        /// <summary>
        /// /获取主键值 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["物品编码"].ToString() + dr["批次"].ToString();
        }

        /// <summary>
        /// 主键
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private string[] GetKey(FarPoint.Win.Spread.SheetView sv, int rowIndex)
        {
            string[] keys = new string[]{
                                                sv.Cells[rowIndex, (int)ColumnSet.ColItemCode].Text,
                                                sv.Cells[rowIndex, (int)ColumnSet.ColGroupNO].Text
                                            };

            return keys;
        }

        #endregion

        #region IPhaInManager 成员

        /// <summary>
        /// 详细输入控件
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                return null;
            }
        }


        /// <summary>
        /// 批次物品退库
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable InitDataTable()
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
												 new DataColumn("批号",      dtStr),
												 new DataColumn("购入价",	 dtStr),
												 new DataColumn("单位",		 dtStr),
												 new DataColumn("入库数量",  dtDec),
												 new DataColumn("入库金额",  dtDec),
												 new DataColumn("退库数量",  dtDec),
												 new DataColumn("退库金额",  dtDec),
												 new DataColumn("发票号",    dtStr),
                                                 new DataColumn("发票日期",  dtDate),
												 new DataColumn("备注",      dtStr),
												 new DataColumn("物品编码",  dtStr),
												 new DataColumn("批次",      dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr)
											 }
                );

            DataColumn[] keys = new DataColumn[2];

            keys[0] = this.dt.Columns["物品编码"];
            keys[1] = this.dt.Columns["批次"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }


        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugNO = sv.Cells[activeRow, 0].Text;
            int groupNO = NConvert.ToInt32(sv.Cells[activeRow, 1].Value);

            this.matInManager.AddNote((int)ColumnSet.ColItemCode, (int)ColumnSet.ColItemName);

            return this.AddInData(drugNO, groupNO);
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

        public int ShowApplyList()
        {
            return 1;
        }


        public int ShowInList()
        {
            try
            {
                if (this.ucListSelect == null)
                {
                    this.ucListSelect = new ucMatListSelect();
                }
                //{7019A2A6-ADCA-4984-944B-C4F1A312449A}
                this.ucListSelect.DeptInfo = this.matInManager.DeptInfo;
                this.ucListSelect.Init();
                System.Collections.Hashtable hsState = new Hashtable();
                hsState.Add("0", "未录发票");
                hsState.Add("1", "已录发票未核准");
                hsState.Add("2", "已核准");
                this.ucListSelect.InOutStateCollection = hsState;

                this.ucListSelect.State = "2";                  //需检索状态
                System.Collections.Hashtable hs = new Hashtable();
                hs.Add(this.matInManager.PrivType.ID, null);
                this.ucListSelect.MarkPrivType = hs;

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


        public int ShowOutList()
        {
            return 1;
        }


        public int ShowStockList()
        {
            return 1;
        }


        /// <summary>
        /// 设置Fp显示
        /// </summary>
        public virtual void SetFormat()
        {
            if (this.matInManager.FpSheetView == null)
                return;

            this.matInManager.FpSheetView.DefaultStyle.Locked = true;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColItemName].Width = 120F;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Width = 65F;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColBackCost].CellType = numberCellType;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColStatUnit].Width = 60F;

            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].Visible = false;           //入库金额
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColItemCode].Visible = false;           //物品编码
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColGroupNO].Visible = false;          //批次

            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColBackQty].Locked = false;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceDate].Locked = false;

            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColBackQty].BackColor = System.Drawing.Color.SeaShell;
            this.matInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceDate].BackColor = System.Drawing.Color.SeaShell;
        }

        public bool Valid()
        {
            if (this.matInManager.TargetDept.ID == "")
            {
                System.Windows.Forms.MessageBox.Show("请选择退库科室！");
                return false;
            }
            try
            {
                bool isHaveQty = false;
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["退库数量"]) > NConvert.ToDecimal(dr["入库数量"]))
                    {
                        System.Windows.Forms.MessageBox.Show(dr["物品名称"].ToString() + " 退库数量大于当前入库量 不能退库");
                        return false;
                    }
                    if (NConvert.ToDecimal(dr["退库数量"]) > 0)
                    {
                        isHaveQty = true;
                    }
                }

                if (!isHaveQty)
                {
                    System.Windows.Forms.MessageBox.Show("请输入退库数量");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            try
            {
                if (sv != null && delRowIndex >= 0)
                {
                    DialogResult rs = MessageBox.Show("确认删除该条数据吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    string[] keys = new string[]{
													sv.Cells[delRowIndex, (int)ColumnSet.ColItemCode].Text,
													sv.Cells[delRowIndex, (int)ColumnSet.ColGroupNO].Text
												};
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.matInManager.Fp.StopCellEditing();

                        this.hsInData.Remove(dr["物品编码"].ToString() + dr["批次"].ToString());
                        this.dt.Rows.Remove(dr);

                        this.matInManager.Fp.StartCellEditing(null, false);
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

        public void SetFocusSelect()
        {
            if (this.matInManager.FpSheetView != null)
            {
                if (this.matInManager.FpSheetView.Rows.Count > 0)
                {
                    this.matInManager.SetFpFocus();

                    this.matInManager.FpSheetView.ActiveRowIndex = this.matInManager.FpSheetView.Rows.Count - 1;
                    this.matInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColBackQty;
                }
                else
                {
                    this.matInManager.SetFocus();
                }
            }
        }

        /// <summary>
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

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            #region 获取退库单号

            string inListNO = this.storeManager.GetInListNO(this.matInManager.DeptInfo.ID);

            if (inListNO == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获取最新退库单号出错" + storeManager.Err);
                return;
            }

            #endregion

            //标志是否存在保存操作
            bool isSaveOperation = false;
            this.alInput = new List<Neusoft.HISFC.Models.Material.Input>();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                decimal backQty = NConvert.ToDecimal(dr["退库数量"]);
                if (backQty == 0)
                {
                    continue;
                }

                Neusoft.HISFC.Models.Material.Input input = this.hsInData[this.GetKey(dr)] as Neusoft.HISFC.Models.Material.Input;

                //－－－－－－－－－广一的
                //				input.InCost = this.GetPrice(input.InCost);
                //－－－－－－－－－

                #region 获取本批次当前库存 判断是否允许退库

                decimal storeQty = 0;
                this.storeManager.GetStoreQty(this.matInManager.DeptInfo.ID, input.StoreBase.Item.ID, input.StoreBase.StockNO, out storeQty);
                if (storeQty < backQty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(input.StoreBase.Item.Name + " 库存数量不足 退库数量过大");
                    return;
                }

                #endregion

                input.StoreBase.PrivType = this.matInManager.PrivType.ID;
                input.StoreBase.SystemType = this.matInManager.PrivType.Memo;
                input.StoreBase.Company.Name = this.matInManager.TargetDept.Name;

                #region 退库信息赋值

                input.InListNO = inListNO;													//退库单号
                input.StoreBase.Quantity = -backQty;										//入库数量(负数)
                input.PackInQty = input.StoreBase.Quantity * input.StoreBase.Item.PackQty;

                input.InCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.PurchasePrice;
                input.StoreBase.StoreQty = storeQty;										//入库前库存数量
                input.StoreBase.StoreCost = input.StoreBase.StoreQty * input.StoreBase.PriceCollection.PurchasePrice;

                input.StoreBase.Operation.ApplyOper.ID = this.matInManager.OperInfo.ID;
                input.StoreBase.Operation.ApplyOper.OperTime = sysTime;
                input.StoreBase.Operation.Oper = input.StoreBase.Operation.ApplyOper;
                //根据不同发票输入情况及控制参数设置状态
                input.StoreBase.State = "0";
                input.InvoiceNO = dr["发票号"].ToString();
                input.InvoiceTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(dr["发票日期"]);

                if (input.InvoiceNO != "")
                {
                    input.StoreBase.Operation.ExamQty = input.StoreBase.Quantity;
                    input.StoreBase.Operation.ExamOper = input.StoreBase.Operation.Oper;
                    input.StoreBase.State = "1";										//直接更新状态为 审核(发票入库)状态
                }
                if (!this.IsNeedApprove)												//不需核准 直接设置状态"2"
                {
                    input.StoreBase.State = "2";
                    input.StoreBase.Operation.ExamQty = input.StoreBase.Quantity;
                    input.StoreBase.Operation.ExamOper = input.StoreBase.Operation.Oper;
                    input.StoreBase.Operation.ApproveOper = input.StoreBase.Operation.Oper;
                }

                #endregion

                #region 退库保存

                int parm = this.storeManager.Input(input, "1", this.IsNeedApprove ? "0" : "1");
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存 [" + input.StoreBase.Item.Name + "] 发生错误 " + this.storeManager.Err);
                    return;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("数据可能已被审核，请刷新重试！");
                    return;
                }

                #endregion

                isSaveOperation = true;

                alInput.Add(input);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isSaveOperation)
            {
                MessageBox.Show("入库退库操作成功");
            }

            if (alInput.Count > 0)
            {
                if (MessageBox.Show("是否打印?", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    /*
                    Material.uc ucMat = new Material.ucMatInput();
                    ucMat.Decimals = 2;
                    ucMat.MaxRowNo = 17;

                    ucMat.SetDataForInput(alInput, 1, this.storeManager.Operator.ID, "1");
                     * */

                    //ucMat.SetDataForInput(alInput, 1, this.itemManager.Operator.ID, "1");
                    //{86B8ED47-06CF-4a8e-8768-2AE929E3E8E7}打印
                    this.Print();
                }
            }

            this.Clear();
        }

        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        public int Print()
        {
            if(matInManager.IInPrint !=null)
            {
                this.matInManager.IInPrint.SetData(this.alInput);
            }
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
            this.matInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

            this.matInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.matInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
        }

        #endregion

        #region 属性

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            this.matInManager.TargetDept = targetDept;

            this.Clear();

            this.AddInData(listCode, state);
        }


        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.ShowSelectData();
        }


        private void value_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.matInManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.matInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColBackQty)
                    {
                        this.matInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                        return;
                    }
                    if (this.matInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceNO)
                    {
                        this.matInManager.FpSheetView.ActiveRowIndex++;
                        this.matInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColBackQty;
                        return;
                    }
                }
            }
        }


        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.matInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColBackQty)
            {
                DataRow dr = this.dt.Rows.Find(this.GetKey(this.matInManager.FpSheetView, this.matInManager.FpSheetView.ActiveRowIndex));
                //string[] keys = new string[] { this.matInManager.FpSheetView.Cells[this.matInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemCode].Text, this.matInManager.FpSheetView.Cells[this.matInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColGroupNO].Text };
                //DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["退库金额"] = NConvert.ToDecimal(dr["退库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    dr.EndEdit();
                }
            }
        }

        #endregion

        #region 列枚举

        private enum ColumnSet
        {
            /// <summary>
            /// 物品名称	
            /// </summary>
            ColItemName,
            /// <summary>
            /// 规格		
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 批号		
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 购入价
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 计量单位	
            /// </summary>
            ColStatUnit,
            /// <summary>
            /// 入库数量	
            /// </summary>
            ColInNum,
            /// <summary>
            /// 入库金额	
            /// </summary>
            ColInCost,
            /// <summary>
            /// 退库数量
            /// </summary>
            ColBackQty,
            /// <summary>
            /// 退库金额
            /// </summary>
            ColBackCost,
            /// <summary>
            /// 发票号		
            /// </summary>
            ColInvoiceNO,
            /// <summary>
            /// 发票日期
            /// </summary>
            ColInvoiceDate,
            /// <summary>
            /// 备注	    
            /// </summary>
            ColMemo,
            /// <summary>
            /// 物品编码     
            /// </summary>
            ColItemCode,
            /// <summary>
            /// 批次
            /// </summary>
            ColGroupNO,
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
        /// <summary>
        /// 计算税前，税后价格
        /// </summary>
        /// <param name="decPrice"></param>
        /// <returns></returns>
        //		private decimal GetPrice(decimal decPrice)
        //		{
        //			if(!this.uc.rbnPRe.Checked)
        //			{
        //				return decPrice;
        //			}
        //			else
        //			{
        //				return Math.Round(decPrice*1.17,2);   //1.17是税率
        //			}
        //		}

        #endregion
    }
}
