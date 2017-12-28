using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using FarPoint.Win.Spread;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;


namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 价让出库]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// <说明>
    ///     2、增加控制参数，设定价让出库默认加价率
    ///     3、价让目标医院做为院内科室添加
    ///     4、增加控制参数，设定价让价格是否默认批发价
    /// </说明>
    /// </summary>
    public class TransferOutput : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        /// <summary>
        /// 价让出库
        /// </summary>
        /// <param name="ucPhaManager"></param>
        public TransferOutput(Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut phaOutManager = null;

        private DataTable dt = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

        /// <summary>
        /// 存储出库实体信息
        /// </summary>
        private System.Collections.Hashtable hsOutData = new Hashtable();
    
        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 数量显示时是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = false;

        /// <summary>
        /// 限制药品类别
        /// </summary>
        private System.Collections.Hashtable hsRestrainedQualityHelper = new Hashtable();

        /// <summary>
        /// 默认加价率
        /// </summary>
        private decimal defaultPriceRate = 1.05M;

        /// <summary>
        /// 是否使用批发价
        /// </summary>
        private bool useWholePrice = false;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private ArrayList alPrintData = null;
        #endregion

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetPhaManagerProperty(Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.phaOutManager = ucPhaManager;

            if (this.phaOutManager != null)
            {
                //设置界面显示
                this.phaOutManager.IsShowItemSelectpanel = true;
                this.phaOutManager.IsShowInputPanel = false;
                //设置目标科室信息 目标人员信息
                this.phaOutManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                this.phaOutManager.SetTargetPerson(true, Neusoft.HISFC.Models.Base.EnumEmployeeType.P);
                //设置工具栏按钮显示
                this.phaOutManager.SetToolBarButtonVisible(false, false, false, false, true, true, false);
                //设置显示的待选择数据
                this.phaOutManager.SetSelectData("2", Function.IsOutByBatchNO, null, null, null);

                this.phaOutManager.Fp.EditModeReplace = true;
                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaOutManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);
                this.phaOutManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);

                this.phaOutManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);
                this.phaOutManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);

                this.phaOutManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaOutManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.phaOutManager.FpSheetView.DataAutoCellTypes = false;
                this.SetFormat();

                this.InitControlParam();

                //提示信息设置
                this.phaOutManager.ShowInfo = "当前价让加价率：" + this.defaultPriceRate.ToString("N");

                System.EventHandler eFun = new EventHandler(SetTransferRate);

                this.phaOutManager.AddToolBarButton("加价设置", "设置价让出库加价率", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, 2, true, eFun);

                this.phaOutManager.SetItemListWidth(2);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.defaultPriceRate = ctrlParamIntegrate.GetControlParam<decimal>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Out_Transfer_DefaultRate, true, 1.05M);
            this.useWholePrice = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Out_Transfer_UseWholePrice, true, false);

            return 1;
        }

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息 Input.User01存储数据来源</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                output.RetailCost = output.Quantity / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;

                if (this.isUseMinUnit)
                {
                    this.dt.Rows.Add(new object[] { 
                                                output.Item.Name,                            //商品名称
                                                output.Item.Specs,                           //规格
                                                output.BatchNO,                              //批号
                                                output.Item.PriceCollection.PurchasePrice,
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                output.StoreQty,                             //库存数量
                                                output.Quantity,                             //出库数量
                                                output.RetailCost,                           //出库金额
                                                output.Memo,                                 //备注
                                                output.Item.ID,                              //药品编码
                                                output.Item.NameCollection.SpellCode,        //拼音码
                                                output.Item.NameCollection.WBCode,           //五笔码
                                                output.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                );
                }
                else
                {
                    this.dt.Rows.Add(new object[] { 
                                                output.Item.Name,                            //商品名称
                                                output.Item.Specs,                           //规格
                                                output.BatchNO,                              //批号
                                                output.Item.PriceCollection.PurchasePrice,
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                Math.Round(output.StoreQty / output.Item.PackQty,2),//库存数量
                                                output.Quantity / output.Item.PackQty,       //出库数量
                                                output.RetailCost,                           //出库金额
                                                output.Memo,                                 //备注
                                                output.Item.ID,                              //药品编码
                                                output.Item.NameCollection.SpellCode,        //拼音码
                                                output.Item.NameCollection.WBCode,           //五笔码
                                                output.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                                    );
                }
            }
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
        /// 格式化
        /// </summary>
        /// <param name="sv"></param>
        protected virtual void SetFormat()
        {
            this.phaOutManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 70F;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = Function.IsOutByBatchNO;          //批号 
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            if (this.isUseMinUnit)
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.numCellType.DecimalPlaces = 2;
            this.numCellType.MinimumValue = 0;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Locked = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].BackColor = System.Drawing.Color.SeaShell;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].CellType = this.numCellType;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
        }     

        /// <summary>
        /// 根据药品信息添加出库记录
        /// </summary>
        /// <param name="drugNO"></param>
        /// <param name="batchNO"></param>
        /// <param name="storageQty"></param>
        /// <returns></returns>
        protected virtual int AddDrugData(string drugNO, string batchNO, decimal storageQty)
        {
            if (this.phaOutManager.TargetDept.ID == "")
            {
                MessageBox.Show(Language.Msg("请选择领药单位!"));
                return 0;
            }

            if (this.hsOutData.ContainsKey(drugNO + batchNO))
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return 0;
            }

            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(drugNO);
            if (item == null)
            {
                MessageBox.Show(Language.Msg("根据药品编码获取药品字典信息时发生错误" + this.itemManager.Err));
                return -1;
            }

            //设置价让出库价格 在当前购入价基础上乘以百分比
            if (this.useWholePrice)
            {
                item.PriceCollection.RetailPrice = item.PriceCollection.WholeSalePrice;
            }
            else
            {
                item.PriceCollection.RetailPrice = this.defaultPriceRate * item.PriceCollection.PurchasePrice;
                item.PriceCollection.WholeSalePrice = item.PriceCollection.RetailPrice;
            }

            Neusoft.HISFC.Models.Pharmacy.Output output = new Neusoft.HISFC.Models.Pharmacy.Output();

            output.Item = item;                                             //药品信息
            output.BatchNO = batchNO;                                       //批号
            output.PrivType = this.phaOutManager.PrivType.ID;               //出库类型
            output.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型
            output.StockDept = this.phaOutManager.DeptInfo;                 //当前科室
            output.TargetDept = this.phaOutManager.TargetDept;              //目标科室
            output.StoreQty = storageQty;                                   //库存量

            output.User01 = "0";                                            //数据来源

            if (this.AddDataToTable(output) == 1)
            {
                this.hsOutData.Add(drugNO + batchNO, output);
            }

            return 1;
        }

        /// <summary>
        /// 返回本张单据差额
        /// </summary>
        public virtual void CompuateSum()
        {
            decimal retailCost = 0;

            if (this.dt != null)
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    retailCost += NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);
                }
                this.phaOutManager.TotCostInfo = string.Format("出库金额:{0}", retailCost.ToString("N"));
            }
        }

        /// <summary>
        /// 加价率设置
        /// </summary>
        protected void SetTransferRate(object sender, System.EventArgs args)
        {
            frmEasyData frm = new frmEasyData();

            frm.EasyLabel = "加价率";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    if (NConvert.ToDecimal(frm.EasyData) <= 0)
                    {
                        MessageBox.Show(Language.Msg("请正确设置价让率"),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        this.SetTransferRate(null, System.EventArgs.Empty);
                    }
                    else
                    {
                        this.defaultPriceRate = NConvert.ToDecimal(frm.EasyData) + 1;

                        this.phaOutManager.ShowInfo = "当前价让加价率：" + this.defaultPriceRate.ToString("N");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(Language.Msg("请正确设置价让率"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.SetTransferRate(null, System.EventArgs.Empty);
                }
            }
        }

        #region IPhaInManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                return null;
            }
        }

        public DataTable InitDataTable()
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
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("购入价",    dtDec),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("库存数量",  dtDec),
                                                                    new DataColumn("出库数量",  dtDec),
                                                                    new DataColumn("出库金额",  dtDec),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr)
                                                                   }
                                  );

            DataColumn[] keys = new DataColumn[2];

            keys[0] = this.dt.Columns["药品编码"];
            keys[1] = this.dt.Columns["批号"];

            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugNO = sv.Cells[activeRow, 0].Text;
            string batchNO = sv.Cells[activeRow, 3].Text;
            decimal storeQty = 0;

            this.itemManager.GetStorageNum(this.phaOutManager.DeptInfo.ID, drugNO, out storeQty);

            if (this.AddDrugData(drugNO, batchNO, storeQty) == 1)
            {
                this.SetFormat();

                this.SetFocusSelect();
            }
            return 1;
        }

        public int ShowApplyList()
        {           
            return 1;
        }

        public int ShowInList()
        {
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
            try
            {

                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["出库数量"]) <= 0)
                    {
                        MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + " 出库数量不能小于等于零"));
                        return false;
                    }
                    if (NConvert.ToDecimal(dr["库存数量"]) < NConvert.ToDecimal(dr["出库数量"]))
                    {
                        MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + " 出库数量不能大于当前库存量"));
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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

                    string[] keys = new string[]{
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColDrugNO].Text,
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
                                            };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.phaOutManager.Fp.StopCellEditing();                       

                        this.hsOutData.Remove(dr["药品编码"].ToString() + dr["批号"].ToString());

                        this.dt.Rows.Remove(dr);

                        this.phaOutManager.Fp.StartCellEditing(null, false);
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

                this.hsOutData.Clear();
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
            if (this.phaOutManager.FpSheetView != null)
            {
                if (this.phaOutManager.FpSheetView.Rows.Count > 0)
                {
                    this.phaOutManager.SetFpFocus();

                    this.phaOutManager.FpSheetView.ActiveRowIndex = this.phaOutManager.FpSheetView.Rows.Count - 1;
                    this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColOutQty;
                }
                else
                {
                    this.phaOutManager.SetFocus();
                }
            }
        }

        public void Save()
        {
            if (!this.Valid())
            {
                return;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("确认向" + this.phaOutManager.TargetDept.Name + "进行出库操作吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            this.dt.DefaultView.RowFilter = "1=1";
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaCons = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //phaIntegrate.SetTrans(t.Trans);
            //phaCons.SetTrans(t.Trans);

            #endregion

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();
            //判断领用科室是否管理库存
            string outListNO = "";
            bool isManagerStore = phaCons.IsManageStore(this.phaOutManager.TargetDept.ID);

            this.alPrintData = new ArrayList();

            //均价出库 只扣减本科室库存 以购入价乘以百分比做为均价出库
            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();
                Neusoft.HISFC.Models.Pharmacy.Output output = this.hsOutData[key] as Neusoft.HISFC.Models.Pharmacy.Output;

                output.Operation.ExamOper.ID = this.phaOutManager.OperInfo.ID;  //审核人
                output.Operation.ExamOper.OperTime = sysTime;                   //审核日期
                output.Operation.Oper = output.Operation.ExamOper;              //操作信息                

                #region 获取单据号

                if (outListNO == "")
                {
                    // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                    outListNO = phaIntegrate.GetInOutListNO(this.phaOutManager.DeptInfo.ID, false);
                    if (outListNO == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("获取新出库单号出错" + phaIntegrate.Err);
                        return;
                    }
                }

                output.OutListNO = outListNO;

                #endregion

                #region Output实体必要信息赋值

                if (this.isUseMinUnit)                  //使用最小单位
                    output.Quantity = NConvert.ToDecimal(dr["出库数量"]);                       //出库数量
                else                                    //使用包装单位
                    output.Quantity = NConvert.ToDecimal(dr["出库数量"]) * output.Item.PackQty; //出库数量

                output.StoreQty = output.StoreQty - output.Quantity;
                output.StoreCost = output.StoreQty * output.Item.PriceCollection.RetailPrice / output.Item.PackQty;

                output.Operation.ExamQty = output.Quantity;                     //审核数量
                output.Memo = dr["备注"].ToString();
                output.DrugedBillNO = "0";                                      //摆药单号 不能为空

                output.GetPerson = this.phaOutManager.TargetPerson.ID;          //领药人

                //状态固定赋值为2
                output.State = "2";         //核准 
                output.Operation.ApproveOper = output.Operation.Oper;

                #endregion

                #region 以下信息在每次添加新数据时自动生成

                output.PrivType = this.phaOutManager.PrivType.ID;               //出库类型
                output.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型
                output.StockDept = this.phaOutManager.DeptInfo;                 //当前科室
                output.TargetDept = this.phaOutManager.TargetDept;              //目标科室

                #endregion

                if (this.itemManager.Output(output, null, false) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("出库保存发生错误" + this.itemManager.Err);
                    return;
                }

                this.alPrintData.Add(output);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");

            DialogResult rsPrint = MessageBox.Show(Language.Msg("是否打印出库单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsPrint == DialogResult.Yes)
            {
                this.Print();
            }

            this.Clear();
        }

        public int Print()
        {
            if (this.phaOutManager.IOutPrint != null)
            {
                this.phaOutManager.IOutPrint.SetData(this.alPrintData, this.phaOutManager.PrivType.Memo);
                this.phaOutManager.IOutPrint.Print();
            }

            return 1;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            return 1;
        }

        #endregion

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
            {
                string[] keys = new string[] { this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text, this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["出库金额"] = NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void phaOutManager_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            return;
        }

        private void phaOutManager_FpKeyEvent(Keys key)
        {
            if (this.phaOutManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
                    {
                        if (this.phaOutManager.FpSheetView.ActiveRowIndex == this.phaOutManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaOutManager.SetFocus();
                        }
                        else
                        {
                            this.phaOutManager.FpSheetView.ActiveRowIndex++;
                            this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColOutQty;
                        }
                    }
                }
            }
        }

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
            /// 批号
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 购入价
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 零售价		
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 包装单位	
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 最小单位
            /// </summary>
            ColMinUnit,
            /// <summary>	
            /// 库存数量	
            /// </summary>
            ColStoreQty,
            /// <summary>
            /// 出库数量	
            /// </summary>
            ColOutQty,
            /// <summary>
            /// 出库金额	
            /// </summary>
            ColOutCost,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
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
            ColUserCode
        }
    }
}
