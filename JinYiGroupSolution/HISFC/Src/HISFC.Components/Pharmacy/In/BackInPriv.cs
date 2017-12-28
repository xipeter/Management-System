using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 入库退库业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// 
    /// 备注：
    /// 入库退库取库存内药品 不根据指定供货公司获取
    /// </summary>
    public class BackInPriv : IPhaInManager
    {
        public BackInPriv(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.SetPhaManagerProperty(ucPhaManager);
            }
        }

        #region 域变量

        private ucPhaIn phaInManager = null;

        private DataTable dt = null;

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 存储已添加的数据
        /// </summary>
        private System.Collections.Hashtable hsInData = new Hashtable();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucPhaListSelect ucListSelect = null;

        /// <summary>
        /// 入库是否需要核准
        /// </summary>
        private bool IsNeedApprove = false;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private ArrayList alPrintData = null;

        /// <summary>
        /// 药品待选择列表显示控件
        /// </summary>
        private Neusoft.HISFC.Components.Common.Controls.ucDrugList ucBackDrugSelectedList = null;

        #endregion

        /// <summary>
        /// /初始化
        /// </summary>
        protected virtual void Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsNeedApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.In_Need_Approve, true, true);
        }

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        protected void SetPhaManagerProperty(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.phaInManager = ucPhaManager;

            if (this.phaInManager != null)
            {
                //设置目标科室信息  显示供货单位列表
                this.phaInManager.SetTargetDept( true, false, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P );
                //设置需过滤数据  
                this.phaInManager.IsShowItemSelectpanel = false;

                //{1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码
                this.phaInManager.IsShowInputPanel = true;
                this.ShowSelectData();

                //设置工具栏按钮显示
                this.phaInManager.SetToolBarButton( false, true, false, false, true );
                this.phaInManager.SetToolBarButtonVisible( false, true, false, false, true, true, false );
                //设置项目列表宽度
                this.phaInManager.SetItemListWidth( 2 );
                //设置Fp
                this.phaInManager.Fp.EditModePermanent = false;
                this.phaInManager.Fp.EditModeReplace = true;
                this.phaInManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler( value_EndTargetChanged );
                this.phaInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler( value_EndTargetChanged );

                this.phaInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler( value_FpKeyEvent );
                this.phaInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler( value_FpKeyEvent );

                this.phaInManager.Fp.EditModeOff -= new EventHandler( Fp_EditModeOff );
                this.phaInManager.Fp.EditModeOff += new EventHandler( Fp_EditModeOff );
            }
        }

        /// <summary>
        /// 设置显示数据
        /// 
        /// {1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码 修改数据显示左右结构为上下结构
        /// </summary>
        /// <returns></returns>
        private int ShowSelectData()
        {
            string[] filterStr = new string[4] { "SPELL_CODE", "WB_CODE", "REGULAR_SPELL", "REGULAR_WB" };
            string[] label = new string[] { "药品编码", "批次", "商品名称", "规格", "批号","购入价", "库存量 [包装单位]", "拼音码", "五笔码", "通用名拼音码", "通用名五笔码" };
            int[] width = new int[] { 60, 100, 220, 80, 80, 120, 170, 60, 60, 60, 60 };
            bool[] visible = new bool[] { false, true, true, true, true, true, true, false, false, false, false };

            //入库退库取库存内药品 不根据指定供货公司获取
            //入库退库取库存内库存量大于0的药品

            //this.phaInManager.SetSelectData("3", false, new string[] { "Pharmacy.Item.GetStorageForBackIn" }, filterStr, this.phaInManager.DeptInfo.ID);

            //this.phaInManager.SetSelectFormat(label, width, visible);

            //初始化    {1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码 修改数据显示左右结构为上下结构
            this.InitBackDrugSelectedListUC();
          
            this.ucBackDrugSelectedList.ShowInfoList( "Pharmacy.Item.GetStorageForBackIn", filterStr, this.phaInManager.DeptInfo.ID );
            this.ucBackDrugSelectedList.SetFormat( label, width, visible );

            return 1;
        }

        /// <summary>
        /// 初始化退库药品列表选择控件
        /// 
        /// {1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码 修改数据显示左右结构为上下结构
        /// </summary>
        /// <returns></returns>
        private int InitBackDrugSelectedListUC()
        {
            if (this.ucBackDrugSelectedList == null)
            {
                this.ucBackDrugSelectedList = new ucDrugList();
                this.ucBackDrugSelectedList.Caption = "当前库存药品列表";
                this.ucBackDrugSelectedList.DataAutoCellType = false;
                this.ucBackDrugSelectedList.Height = 180;
                this.ucBackDrugSelectedList.ChooseDataEvent += new ucDrugList.ChooseDataHandler( ucBackDrugSelectedList_ChooseDataEvent );
            }

            return 1;
        }

        /// <summary>
        ///  药品列表数据选择事件处理
        ///  
        ///  {1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码 修改数据显示左右结构为上下结构
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        private void ucBackDrugSelectedList_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            this.AddItem( sv, activeRow );   
        }

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                input.RetailCost = (input.Quantity - input.Operation.ReturnQty) / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;

                this.dt.Rows.Add(new object[] { 
                                                input.Item.Name,                            //商品名称
                                                input.Item.Specs,                           //规格
                                                input.Item.PriceCollection.RetailPrice,     //零售价
                                                input.BatchNO,                              //批号
                                                input.Item.PackUnit,                        //包装单位
                                                (input.Quantity - input.Operation.ReturnQty) / input.Item.PackQty,        //入库数量
                                                input.RetailCost,                           //入库金额   
                                                0,                                          //退库数量
                                                0,                                          //退库金额
                                                input.InvoiceNO,                            //发票号
                                                input.InvoiceType,                          //发票类别
                                                input.Memo,                                 //备注
                                                input.Item.ID,                              //药品编码
                                                input.GroupNO,                              //批次
                                                input.Item.NameCollection.SpellCode,        //拼音码
                                                input.Item.NameCollection.WBCode,           //五笔码
                                                input.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                                );
            }
            #region {CAD2CB10-14FE-472c-A7D7-9BAA5061730C}
            catch (System.Data.ConstraintException cex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该药品已选择不能重复选择！"));

                return -1;
            }
            #endregion
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + e.Message));

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + ex.Message));

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

            ArrayList alDetail = this.itemManager.QueryInputInfoByListID(this.phaInManager.DeptInfo.ID, listNO, this.phaInManager.TargetDept.ID, state);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Input input in alDetail)
            {
                input.PrivType = this.phaInManager.PrivType.ID;             //入库类型
                input.SystemType = this.phaInManager.PrivType.Memo;         //系统类型

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInData.Add(this.GetKey(input), input);
                }
                else
                {
                    return -1;
                }
            }

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetFocusSelect();

            return 1;
        }

        /// <summary>
        /// 根据药品编码与批次号加入入库退库信息
        /// </summary>
        /// <param name="drugNO"></param>
        /// <param name="groupNO"></param>
        /// <returns></returns>
        protected virtual int AddInData(string drugNO, int groupNO)
        {
            if (this.hsInData.ContainsKey(drugNO + groupNO))
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return 0;
            }
            ArrayList alDetail = this.itemManager.QueryStorageList(this.phaInManager.DeptInfo.ID, drugNO, groupNO);
            if (alDetail == null || alDetail.Count == 0)
            {
                MessageBox.Show(Language.Msg("未获取有效的库存明细信息" + this.itemManager.Err));
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Storage storage = alDetail[0] as Neusoft.HISFC.Models.Pharmacy.Storage;

            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

            input.StockDept = storage.StockDept;                //库存科室
            input.TargetDept = this.phaInManager.TargetDept;    //目标科室
            input.Company = this.phaInManager.TargetDept;
            input.Item = storage.Item;
            input.GroupNO = storage.GroupNO;
            input.Quantity = storage.StoreQty;                  //入库量 = 库存量
            input.BatchNO = storage.BatchNO;
            input.ValidTime = storage.ValidTime;
            input.PlaceNO = storage.PlaceNO;
            input.InvoiceNO = storage.InvoiceNO;
            input.Producer = storage.Producer;
            input.Memo = storage.Memo;
            input.PrivType = this.phaInManager.PrivType.ID;             //入库类型
            input.SystemType = this.phaInManager.PrivType.Memo;         //系统类型

            if (this.AddDataToTable(input) == 1)
            {
                this.hsInData.Add(this.GetKey(input), input);
            }

            this.SetFormat();

            this.SetFocusSelect();

            return 1;
        }

        /// <summary>
        /// 设置Fp显示
        /// </summary>
        private void SetFormat()
        {
            if (this.phaInManager.FpSheetView == null)
                return;

            this.phaInManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].Visible = false;           //入库金额
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = true;           //批号
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Visible = false;      //发票分类
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColGroupNO].Visible = false;           //批次

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColBackQty].Locked = false;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColBackQty].BackColor = System.Drawing.Color.SeaShell;
        }

        #region IPhaInManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                //{1DED4697-A590-47b3-B727-92A4AA05D2ED} 调整入库退库代码 修改数据显示左右结构为上下结构
                if (this.ucBackDrugSelectedList == null)
                {
                    this.ucBackDrugSelectedList = new ucDrugList();
                }

                return this.ucBackDrugSelectedList;
            }
        }

        public System.Data.DataTable InitDataTable()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            this.dt = new DataTable();

            this.dt.Columns.AddRange(
                                    new System.Data.DataColumn[] {
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("入库数量",  dtDec),
                                                                    new DataColumn("入库金额",  dtDec),
                                                                    new DataColumn("退库数量",  dtDec),
                                                                    new DataColumn("退库金额",  dtDec),
                                                                    new DataColumn("发票号",    dtStr),
                                                                    new DataColumn("发票分类",  dtStr),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("批次",      dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr)
                                                                   }
                                  );

            DataColumn[] keys = new DataColumn[3];

            keys[0] = this.dt.Columns["药品编码"];
            keys[1] = this.dt.Columns["批次"];
            keys[2] = this.dt.Columns["批号"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugNO = sv.Cells[activeRow, 0].Text;
            int groupNO = NConvert.ToInt32(sv.Cells[activeRow, 1].Value);

            return this.AddInData(drugNO, groupNO);
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
                    this.ucListSelect = new ucPhaListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.phaInManager.DeptInfo;
                System.Collections.Hashtable hsState = new Hashtable();
                hsState.Add("0", "未录发票");
                hsState.Add("1", "已录发票未核准");
                hsState.Add("2", "已核准");
                this.ucListSelect.InOutStateCollection = hsState;

                this.ucListSelect.State = "2";                  //需检索状态
                System.Collections.Hashtable hs = new Hashtable();
                hs.Add(this.phaInManager.PrivType.ID, null);
                this.ucListSelect.MarkPrivType = hs;

                this.ucListSelect.Class2Priv = "0310";          //入库

                this.ucListSelect.SelecctListEvent -= new ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);
                this.ucListSelect.SelecctListEvent += new ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucListSelect);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg(ex.Message));
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

        public int ImportData()
        {
            return 1;
        }

        public bool Valid()
        {
            if (this.phaInManager.TargetDept.ID == "")
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("请选择退库科室！"));
                return false;
            }
            try
            {
                bool isHaveQty = false;
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["退库数量"]) > NConvert.ToDecimal(dr["入库数量"]))
                    {
                        System.Windows.Forms.MessageBox.Show(dr["商品名称"].ToString() + " 退库数量大于当前入库量 不能退库");
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
                    DialogResult rs = MessageBox.Show(Language.Msg("确认删除该条数据吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    string[] keys = this.GetKey(sv, delRowIndex);
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.phaInManager.Fp.StopCellEditing();

                        this.hsInData.Remove(dr["药品编码"].ToString() + dr["批次"].ToString());
                        this.dt.Rows.Remove(dr);

                        this.phaInManager.Fp.StartCellEditing(null, false);
                    }
                }
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("对数据表执行删除操作发生错误" + e.Message));
                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("对数据表执行删除操作发生错误" + ex.Message));
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
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行清空操作发生错误" + ex.Message));
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
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("过滤发生异常 " + ex.Message));
            }
            this.SetFormat();
        }

        public void SetFocusSelect()
        {
            if (this.phaInManager.FpSheetView != null)
            {
                if (this.phaInManager.FpSheetView.Rows.Count > 0)
                {
                    this.phaInManager.SetFpFocus();

                    this.phaInManager.FpSheetView.ActiveRowIndex = this.phaInManager.FpSheetView.Rows.Count - 1;
                    this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColBackQty;
                }
                else
                {
                    this.phaInManager.SetFocus();
                }
            }
        }

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

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            //获取退库单号
            // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
            string inListNO = phaIntegrate.GetInOutListNO(this.phaInManager.DeptInfo.ID, true);
            if (inListNO == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("获取最新入库单号出错" + itemManager.Err));
                return;
            }

            //标志是否存在保存操作
            bool isSaveOperation = false;
            this.alPrintData = new ArrayList();
            foreach (DataRow dr in dtAddMofity.Rows)
            {
                decimal backQty = NConvert.ToDecimal(dr["退库数量"]);
                if (backQty == 0)
                {
                    continue;
                }

                string key = this.GetKey(dr);
                //{DCE152D1-295C-4cc6-9EAA-39321A234569} 
                Neusoft.HISFC.Models.Pharmacy.Input input = (this.hsInData[key] as Neusoft.HISFC.Models.Pharmacy.Input).Clone();

                backQty = backQty * input.Item.PackQty;

                #region 获取本批次当前库存 判断是否允许退库

                decimal storeQty = 0;
                this.itemManager.GetStorageNum(this.phaInManager.DeptInfo.ID, input.Item.ID, input.GroupNO, out storeQty);
                if (storeQty < backQty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(input.Item.Name + " 库存数量不足 退库数量过大"),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                #endregion

                #region 退库信息赋值

                input.InListNO = inListNO;                                      //退库单号
                input.Quantity = - backQty;                                     //入库数量(负数)
                input.RetailCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;
                input.StoreQty = storeQty + input.Quantity;                     //入库后库存数量
                input.StoreCost = input.StoreQty / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;

                input.Operation.ApplyOper.ID = this.phaInManager.OperInfo.ID;
                input.Operation.ApplyOper.OperTime = sysTime;
                input.Operation.Oper = input.Operation.ApplyOper;
                //根据不同发票输入情况及控制参数设置状态
                input.State = "0";
                input.InvoiceNO = dr["发票号"].ToString();
                if (input.InvoiceNO != "")
                {
                    input.Operation.ExamQty = input.Quantity;
                    input.Operation.ExamOper = input.Operation.Oper;
                    input.State = "1";                                      //直接更新状态为 审核(发票入库)状态
                }
                if (!this.IsNeedApprove)                                    //不需核准 直接设置状态"2"
                {
                    input.State = "2";
                    input.Operation.ExamQty = input.Quantity;
                    input.Operation.ExamOper = input.Operation.Oper;
                    input.Operation.ApproveOper = input.Operation.Oper;
                }

                #endregion

                #region 退库保存

                int parm = this.itemManager.Input(input, "1", this.IsNeedApprove ? "0" : "1");
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存 [" + input.Item.Name + "] 发生错误 " + this.itemManager.Err));
                    return;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("数据可能已被审核，请刷新重试！"));
                    return;
                }

                #endregion

                isSaveOperation = true;

                this.alPrintData.Add(input);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isSaveOperation)
            {
                MessageBox.Show(Language.Msg("入库退库操作成功"));

                DialogResult rs = MessageBox.Show(Language.Msg("是否打印退库单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    this.Print();
                }

            }

            this.Clear();
        }

        public int Print()
        {
            if (this.phaInManager.IInPrint != null)
            {
                this.phaInManager.IInPrint.SetData(this.alPrintData, this.phaInManager.PrivType.Memo);
                this.phaInManager.IInPrint.Print();
            }

            return 1;
        }

        /// <summary>
        /// 主键
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            return input.Item.ID + input.GroupNO.ToString() + input.BatchNO;
        }

        /// <summary>
        /// 主键
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["药品编码"].ToString() + dr["批次"].ToString() + dr["批号"].ToString();
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
                                                sv.Cells[rowIndex, (int)ColumnSet.ColDrugNO].Text,
                                                sv.Cells[rowIndex, (int)ColumnSet.ColGroupNO].Text,
                                                sv.Cells[rowIndex,(int)ColumnSet.ColBatchNO].Text
                                            };

            return keys;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            return 1;
        }

        #endregion

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            this.phaInManager.TargetDept = targetDept;

            this.Clear();

            this.AddInData(listCode, state);
        }

        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            //入库退库项目列表已设置为 库存药品列表 此处就不需要再重复刷新
            //this.ShowSelectData();
        }

        private void value_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.phaInManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColBackQty)
                    {
                        this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                        return;
                    }
                    if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceNO)
                    {
                        if (this.phaInManager.FpSheetView.ActiveRowIndex == this.phaInManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaInManager.SetFocus();
                        }
                        if (this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Visible && !this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Locked)
                        {
                            this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceType;
                        }
                        else
                        {
                            this.phaInManager.FpSheetView.ActiveRowIndex++;
                            this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColBackQty;
                        }
                        return;
                    }
                }
            }
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColBackQty)
            {
                DataRow dr = this.dt.Rows.Find(this.GetKey(this.phaInManager.FpSheetView, this.phaInManager.FpSheetView.ActiveRowIndex));
                if (dr != null)
                {
                    dr["退库金额"] = NConvert.ToDecimal(dr["退库数量"]) * NConvert.ToDecimal(dr["零售价"]);

                    dr.EndEdit();
                }
            }
        }

        private enum ColumnSet
        {
            /// <summary>
            /// 商品名称	0
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格		1
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 零售价		2
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 批号		3
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 包装单位	4
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 入库数量	5
            /// </summary>
            ColInNum,
            /// <summary>
            /// 入库金额	6
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
            /// 发票号		7
            /// </summary>
            ColInvoiceNO,
            /// <summary>
            /// 发票分类		8
            /// </summary>
            ColInvoiceType,
            /// <summary>
            /// 备注	    14
            /// </summary>
            ColMemo,
            /// <summary>
            /// 药品编码    15 
            /// </summary>
            ColDrugNO,
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
    }
}
