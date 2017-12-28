using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using System.Collections;
using Neusoft.HISFC.Components.Common.Controls;
using System.ComponentModel;

namespace Neusoft.HISFC.Components.Material.In
{
    /// <summary>
    /// [功能描述: 一般入库业务类]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     1、 采用计价单位入库还是大包装单位入库 可通过IsUsePackIn属性进行控制 默认值为False
    /// 
    /// </说明>
    /// <待解决>
    ///     1、购入价、零售价问题待解决 GetPrice 税前、税后问题需明确
    ///         包装购入价未正确赋值
    /// </待解决>
    /// </summary>
    public class CommonInPriv : IMatManager
    {
        public CommonInPriv(bool isSpecial, In.ucMatIn ucMatInManager)
        {
            this.isSpecial = isSpecial;

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.SetMatManagerProperty(ucMatInManager);
            }
        }


        #region 域变量

        /// <summary>
        /// 物资库存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资项目管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 采购计划管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Plan inputPlanManager = new Neusoft.HISFC.BizLogic.Material.Plan();

        /// <summary>
        /// 供货公司、生产厂家业务类 {5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany companyManager = new Neusoft.HISFC.BizLogic.Material.ComCompany();

        /// <summary>
        /// 参数控制业务类 {5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private Neusoft.HISFC.BizLogic.Material.Baseset bsManager = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// s生产厂家临时类型
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject companyTemp = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否特殊入库
        /// </summary>
        private bool isSpecial = false;

        /// <summary>
        /// 入库界面 物资列表中显示的列数 {7019A2A6-ADCA-4984-944B-C4F1A312449A}
        /// </summary>
        private int visibleColumns = 3;

        /// <summary>
        /// 参数  是否入库后更新目录表中的单价和生产厂家
        /// </summary>
        private bool isUpdateUnitPrice = true;

        /// <summary>
        /// 生产厂家
        /// </summary>
        private ArrayList alCompany = null;

        /// <summary>
        ///  入库组件类
        /// </summary>
        private In.ucMatIn ucInManager = null;

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucMatListSelect ucListSelect = null;

        /// <summary>
        /// 打开窗口时日期
        /// </summary>
        private DateTime sysDate = System.DateTime.MaxValue;

        private DataTable dt = null;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private List<Neusoft.HISFC.Models.Material.Input> alInput = null;

        /// <summary>
        /// 入库数据
        /// </summary>
        private System.Collections.Hashtable hsInputData = new System.Collections.Hashtable();

        /// <summary>
        /// 采购数据
        /// </summary>
        private System.Collections.Hashtable hsStockData = new System.Collections.Hashtable();

        //-------//liuxq 屏蔽掉（因编译时警告）
        //		/// <summary>
        //		/// 前修改数据键值
        //		/// </summary>
        //		private string privKey = "";
        //
        //		/// <summary>
        //		/// 是否判断当前选择的供货公司与基本信息内的供货公司的异同
        //		/// </summary>
        //		private bool isJudgeDefaultCompany = false;
        //
        //		/// <summary>
        //		/// EditMode前项目实体
        //		/// </summary>
        //		private Neusoft.HISFC.Models.Material.Input privInput = null;
        //-------//liuxq 屏蔽掉（因编译时警告）

        /// <summary>
        /// 有效期自动增加年数
        /// </summary>
        private int autoValidYear = 5;
        /// <summary>
        /// 是否按大包装方式入库
        /// </summary>
        private bool isUsePackIn = false;

        /// <summary>
        /// 申请单是否以大包装单位申请
        /// </summary>
        private bool isPackApply = false;

        /// <summary>
        /// 库存序号是否重复
        /// </summary>
        private bool isRepeatedStockNO = false;

        #endregion

        #region 属性       
        /// <summary>
        /// 有效期自动增加年数
        /// </summary>
        public int AutoValidYear
        {
            get
            {
                return this.autoValidYear;
            }
            set
            {
                this.autoValidYear = value;
            }
        }


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

        /// <summary>
        /// 申请单是否以大包装单位申请
        /// </summary>
        public bool IsPackApply
        {
            get
            {
                return this.isPackApply;
            }
            set
            {
                this.isPackApply = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            this.sysDate = storeManager.GetDateTimeFromSysDateTime().Date;
            //可见列数{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            this.visibleColumns = controlIntegrate.GetControlParam<int>("MT0002", true);
            //保存时是否更新单价和厂家{5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
            this.isUpdateUnitPrice = controlIntegrate.GetControlParam<bool>("MT0003", true);

            return 1;
        }


        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <returns></returns>
        private int SetMatManagerProperty(In.ucMatIn ucMatInManager)
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
                //{EA342FD4-AAE1-403f-9A48-C19368DC56AB} 一般入库不需要看到申请单
                //this.ucInManager.SetToolBarButtonVisible(true, false, false, true, true, true, false);
                this.ucInManager.SetToolBarButtonVisible(false, false, false, true, true, true, false);
                //设置显示的待选择数据
                //by yuyun 08-8-11{5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
                this.ucInManager.DeptCode = this.ucInManager.DeptInfo.ID;
                //----------------------
                this.ucInManager.SetSelectData("0", false, null, null, null);
                //设置列宽度{7019A2A6-ADCA-4984-944B-C4F1A312449A}
                this.ucInManager.SetItemListWidth(visibleColumns);
                //信息说明设置
                this.ucInManager.ShowInfo = "F5 键转入项目选择框";
                //设置Fp属性
                this.ucInManager.Fp.EditModePermanent = false;
                this.ucInManager.Fp.EditModeReplace = true;

                this.ucInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(ucInManager_FpKeyEvent);

                this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(ucInManager_EndTargetChanged);
                this.ucInManager.EndTargetChanged += new In.ucMatIn.DataChangedHandler(ucInManager_EndTargetChanged);

                this.ucInManager.Fp.EditModeOn += new EventHandler(Fp_EditModeOn);
                this.ucInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.ucInManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);
                this.ucInManager.Fp.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

                this.ucInManager.Fp.KeyDown -= new KeyEventHandler(Fp_KeyDown);
                this.ucInManager.Fp.KeyDown += new KeyEventHandler(Fp_KeyDown);
            }

            return 1;
        }
    

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息 Input.User01存储数据来源</param>
        /// <returns>成功返回1 失败返回-1</returns>
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
                string inUnit = "";				//入库单位 (根据参数以包装单位或最小单位显示)

                if (this.isUsePackIn)			//按包装单位入库
                {
                    inQty = input.StoreBase.Quantity;                                   //包装数量入库
                    inPrice = input.StoreBase.Item.PackPrice;							//包装单位价格
                    inUnit = input.StoreBase.Item.PackUnit;								//包装单位
                }
                else
                {
                    inQty = input.StoreBase.Quantity * input.StoreBase.Item.PackQty;	//最小数量入库
                    inPrice = input.StoreBase.PriceCollection.PurchasePrice;			//最小单位价格
                    inUnit = input.StoreBase.Item.MinUnit;								//最小单位
                }

                input.StoreBase.RetailCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.RetailPrice;
                input.InCost = inQty * inPrice;
                input.StoreBase.PurchaseCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.PurchasePrice;
                //不允许空值
                if (input.StoreBase.BatchNO == null)
                {
                    input.StoreBase.BatchNO = "";
                }
                this.dt.Rows.Add(new object[] {     
												  true,
												  input.StoreBase.Item.Name,                            //商品名称
												  input.StoreBase.Item.Specs,                           //规格
												  inQty,			    								//入库数量												  
												  inUnit,						                        //包装单位
												  input.StoreBase.Item.PackQty,                         //包装数量
												  inPrice,												//购入价
												  input.InCost,									        //购入金额 (购入价金额)
												  input.StoreBase.BatchNO,                              //批号
												  input.StoreBase.ValidTime,                            //有效期
                                                  //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前   {5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}                 
												  input.StoreBase.Producer.Name,						//生产厂家
												  input.InvoiceNO,										//发票号
												  input.InvoiceTime,									//发票日期
												  input.StoreBase.PriceCollection.RetailPrice,			//零售价 最小单位零售价
												  input.StoreBase.RetailCost,							//零售金额
                                                  //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前
												  input.StoreBase.Item.ID,                              //项目编码
												  input.ID,												//流水号
												  input.User01,											//数据来源
												  input.StoreBase.Item.SpellCode,						//拼音码
												  input.StoreBase.Item.WbCode,							//五笔码
												  input.StoreBase.Item.UserCode,						//自定义码	
												  input.User03,
                                                  //{461BD435-B028-4ba8-8D83-34BA69BA1758}
                                                  input.StoreBase.Producer.ID
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
        /// 根据Dr内数据对实体进行赋值
        /// </summary>
        /// <param name="dr">数据表</param>
        /// <param name="sysTime">当前时间</param>
        /// <param name="input">ref 入库实体信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int GetInputFormDataRow(DataRow dr, DateTime sysTime, ref Neusoft.HISFC.Models.Material.Input input)
        {
            input.StoreBase.ValidTime = NConvert.ToDateTime(dr["有效期"]);
            //默认有效期根据设置可能为0006-01-01 或 0001-01-01 所以根据当前时间前推五年判断是否已输入有效期
            if (input.StoreBase.ValidTime < this.sysDate.AddYears(-5))
            {
                input.StoreBase.ValidTime = this.sysDate.AddYears(this.autoValidYear);
            }

            if (this.isUsePackIn)				//包装单位入库 价格计算为包装单位价格
            {
                input.PackInQty = NConvert.ToDecimal(dr["入库数量"]);
                input.StoreBase.Quantity = NConvert.ToDecimal(dr["入库数量"]) * input.StoreBase.Item.PackQty;
                input.StoreBase.PriceCollection.PurchasePrice = NConvert.ToDecimal(dr["购入价"]) / input.StoreBase.Item.PackQty;
            }
            else								//最小单位入库 
            {
                input.PackInQty = NConvert.ToDecimal(dr["入库数量"]) / input.StoreBase.Item.PackQty;
                input.StoreBase.Quantity = NConvert.ToDecimal(dr["入库数量"]);
                input.StoreBase.PriceCollection.PurchasePrice = this.GetPrice(NConvert.ToDecimal(dr["购入价"]));
            }
            input.InCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.PurchasePrice;

            //如零售价为零 则赋值零售价为购入价
            if (input.StoreBase.PriceCollection.RetailPrice == 0)
            {
                input.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.PurchasePrice;
            }                      

            //部门类型 （默认仓库） 是否病区 默认Flase  不做处理			
            input.StoreBase.BatchNO = dr["批号"].ToString();
            input.InvoiceNO = dr["发票号"].ToString();
            input.InvoiceTime = NConvert.ToDateTime(dr["发票日期"]);

            //{0637D5E9-BE00-4df7-B09D-23236A4259CF}
            input.StoreBase.Producer.ID = dr["生产厂家ID"].ToString();     //生产厂家ID
            input.StoreBase.Producer.Name = dr["生产厂家"].ToString();  //生产厂家名称
            //------------------------------------------------

            #region 以下信息在每次添加数据生成入库信息实体时赋值

            input.StoreBase.StockDept = this.ucInManager.DeptInfo;                       //库存科室
            input.StoreBase.PrivType = this.ucInManager.PrivType.ID;                     //用户类型
            input.StoreBase.SystemType = this.ucInManager.PrivType.Memo;                 //系统类型
            input.StoreBase.Company = this.ucInManager.TargetDept;                       //供货单位 
            input.StoreBase.TargetDept = this.ucInManager.TargetDept;                    //目标单位 = 供货单位

            #endregion

            input.StoreBase.Operation.Oper.ID = this.ucInManager.OperInfo.ID;
            input.StoreBase.Operation.Oper.OperTime = sysTime;
            return 1;
        }


        /// <summary>
        /// 格式化
        /// </summary>
        public virtual void SetFormat()
        {
            if (this.ucInManager.FpSheetView == null)
            {
                return;
            }

            this.ucInManager.FpSheetView.DefaultStyle.Locked = true;
            this.ucInManager.FpSheetView.DataAutoSizeColumns = false;

            this.ucInManager.FpSheetView.DefaultStyle.CellType = Function.GetReadOnlyCellType();

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Width = 38F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColUnit].Width = 60F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPackQty].Width = 60F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Width = 80F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Width = 80F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProducerName].Width = 120F;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPackQty].Visible = false;			//包装单位
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColItemID].Visible = false;				//物品编码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInBillNO].Visible = false;			//流水号
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;			//数据来源
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;			//拼音码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;				//五笔码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;			//自定义码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;                //主键
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Visible = false;             //零售价
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailCost].Visible = false;              //零售金额

            //{0637D5E9-BE00-4df7-B09D-23236A4259CF}
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProducerID].Visible = false;              //生产厂家ID

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Locked = false;			//核准
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInQty].Locked = false;				//入库量
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Locked = false;		//购入价
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProducerName].Locked = false;    //生产厂家
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Locked = false;				//批号
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColValidTime].Locked = false;			//有效期
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;			//发票号
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].Locked = false;			//发票日期

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProducerName].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceTime].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColValidTime].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInQty].BackColor = System.Drawing.Color.SeaShell;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].BackColor = System.Drawing.Color.SeaShell;
        }


        /// <summary>
        /// 增加申请数据
        /// </summary>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 </失败返回-1returns>
        protected virtual int AddApplyData(string listCode, string state)
        {
            ArrayList al = this.storeManager.QueryApplyDetailByListNO(this.ucInManager.DeptInfo.ID, listCode, "0");
            if (al == null)
            {
                System.Windows.Forms.MessageBox.Show("未正确获取外部入库申请信息" + this.storeManager.Err);
                return -1;
            }

            this.Clear();

            Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

            foreach (Neusoft.HISFC.Models.Material.Apply apply in al)
            {
                Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();
                Neusoft.HISFC.Models.Material.MaterialItem tempItem = new Neusoft.HISFC.Models.Material.MaterialItem();

                input.StoreBase.Item = itemManager.GetMetItemByMetID(apply.Item.ID);//物资字典实体	
                input.PlanListNO = apply.ID;										//库存流水号				
                input.StoreBase.StockDept = apply.StockDept;						//库存部门
                input.StoreBase.PrivType = this.ucInManager.PrivType.ID;			//系统权限
                input.StoreBase.SystemType = this.ucInManager.PrivType.Memo;		//用户定义权限
                input.StoreBase.TargetDept = this.ucInManager.TargetDept;			//目标部门					

                //入库数量计算
                if (this.IsPackApply)//申请是否一大包装单位申请
                {
                    input.StoreBase.Quantity = apply.Operation.ApplyQty;
                }
                else
                {
                    input.StoreBase.Quantity = apply.Operation.ApplyQty / input.StoreBase.Item.PackQty;
                }

                input.StoreBase.PriceCollection.PurchasePrice = input.StoreBase.Item.UnitPrice;


                input.User01 = "2";													//数据来源 1 采购单 2 申请单 0 手工选择
                input.User03 = this.GetKey();										//获取主键值

                if (this.AddDataToTable(input) == 1)
                {
                    //向Input集合内加入信息
                    this.hsInputData.Add(this.GetKey(input), input);

                    this.SetFocusSelect();
                }
            }

            this.CompuateSum();

            return 1;
        }


        /// <summary>
        /// 增加采购数据
        /// </summary>
        /// <param name="listCode">采购计划单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int AddStockData(string listCode, string state)
        {
            Neusoft.HISFC.BizLogic.Material.Plan planManager = new Neusoft.HISFC.BizLogic.Material.Plan();
            ArrayList alStock = planManager.QueryInPlanDetailCom(this.ucInManager.DeptInfo.ID, listCode, this.ucInManager.TargetDept.ID);
            if (alStock == null)
            {
                System.Windows.Forms.MessageBox.Show("获取采购明细信息发生错误" + itemManager.Err);
                return -1;
            }

            this.Clear();

            foreach (Neusoft.HISFC.Models.Material.InputPlan info in alStock)
            {
                if (info.State == "6")              //明细内状态为'6'的 说明已进行过入库处理 不再次显示
                    continue;

                Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

                input.StoreBase.Item = this.itemManager.GetMetItemByMetID(info.StoreBase.Item.ID);	//物资字典实体	
                input.PlanListNO = info.PlanListCode;												//库存流水号				
                input.StoreBase.StockDept.ID = this.ucInManager.DeptInfo.ID;//info.StorageCode;		//库存部门
                input.StoreBase.PrivType = this.ucInManager.PrivType.ID;							//系统权限
                input.StoreBase.SystemType = this.ucInManager.PrivType.Memo;						//用户定义权限
                input.StoreBase.TargetDept = this.ucInManager.TargetDept;							//目标部门	
                input.StoreBase.Company = this.ucInManager.TargetDept;
                input.InvoiceNO = info.InvoiceNo;
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                input.StoreBase.Producer = info.Producer;
                //入库数量计算
                if (this.IsPackApply)//申请是否一大包装单位申请
                {
                    //input.StoreBase.Quantity = info.StockNum;
                    input.StoreBase.Quantity = info.PlanNum;
                }
                else
                {
                    //input.StoreBase.Quantity = info.StockNum / input.StoreBase.Item.PackQty;
                    input.StoreBase.Quantity = info.PlanNum;

                }

                input.StoreBase.PriceCollection.PurchasePrice = input.StoreBase.Item.UnitPrice;


                input.User01 = "1";													//数据来源 1 采购单 2 申请单 0 手工选择
                input.User03 = this.GetKey();										//获取主键值

                if (this.AddDataToTable(input) == 1)
                {
                    //向Input集合内加入信息
                    this.hsInputData.Add(this.GetKey(input), input);

                    this.hsStockData.Add(this.GetKey(input), info);

                    this.SetFocusSelect();
                }
            }

            this.SetFormat();

            this.CompuateSum();

            return 1;
        }

        /// <summary>
        /// 返回本张单据差额
        /// </summary>
        /// <param name="checkAll">是否对所有记录进行统计 True 统计所有记录 False 只统计Check选中记录</param>
        /// <param name="retailCost">零售金额</param>
        /// <param name="purchaseCost">购入金额</param>
        /// <param name="balanceCost">差价</param>
        public virtual void CompuateSum()
        {
            decimal purchaseCost = 0;

            if (this.dt != null)
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    purchaseCost += NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);
                }

                this.ucInManager.TotCostInfo = string.Format("购入金额:{0}", purchaseCost.ToString("C4"));
            }
        }


        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns></returns>
        private string GetKey()
        {
            return System.Guid.NewGuid().ToString();
        }


        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["主键"].ToString();
        }


        /// <summary>
        /// 根据项目实体获取主键
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Material.Input input)
        {
            return input.User03;
        }


        /// <summary>
        /// 由Fp内获取主键
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        private string GetKey(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            return sv.Cells[activeRow, (int)ColumnSet.ColKey].Text;
        }


        /// <summary>
        /// 获取主键数组
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        private string[] GetFindKey(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            return new string[] { sv.Cells[activeRow, (int)ColumnSet.ColKey].Text };
        }

        /// <summary>
        /// 获取生产厂家
        /// </summary>
        /// <param name="columnIndex"></param>
        private void GetCompany(int columnIndex)
        {
            //记录当前位置
            int i = this.ucInManager.FpSheetView.ActiveRowIndex;
            int j = this.ucInManager.FpSheetView.ActiveColumnIndex;
            if (this.ucInManager.FpSheetView.RowCount == 0)
            {
                return;
            }

            if (i < 0)
            {
                return;
            }

            Neusoft.HISFC.Models.Material.Input inputTemp = new Neusoft.HISFC.Models.Material.Input();
            inputTemp = this.ucInManager.FpSheetView.Rows[i].Tag as Neusoft.HISFC.Models.Material.Input;

            if (columnIndex == (int)ColumnSet.ColProducerName)
            {
                if (this.alCompany == null)
                {
                    Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();

                    this.alCompany = company.QueryCompany("0", "A");

                    if (this.alCompany == null)
                    {
                        MessageBox.Show("获取生产厂家出错");
                        return;
                    }
                }

                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref this.companyTemp) == 0)
                {
                    return;
                }
                else
                {
                    this.ucInManager.FpSheetView.Cells[i, (int)ColumnSet.ColProducerName].Value = companyTemp.Name;

                    //{0637D5E9-BE00-4df7-B09D-23236A4259CF} 处理生产厂家ID
                    this.ucInManager.FpSheetView.Cells[i, (int)ColumnSet.ColProducerID].Value = companyTemp.ID;

                    this.ucInManager.FpSheetView.Cells[i, (int)ColumnSet.ColProducerName].Tag = this.companyTemp;
                }
            }
        }

        /// <summary>
        /// 物资加价处理 by yuyun 08-8-4{2F0031DE-9957-48f3-A3B3-F207D0696D56}
        /// </summary>
        /// <param name="input"></param>
        private void SetRetailPrice(ref Neusoft.HISFC.Models.Material.Input input)
        {
            ArrayList al = bsManager.QueryAddRateByRateKind(input.StoreBase.Item.AddRule);
            Neusoft.HISFC.Models.Material.MaterialAddRate addRate = new Neusoft.HISFC.Models.Material.MaterialAddRate();
            switch (input.StoreBase.Item.AddRule)
            {
                //如果是按价格加价 则需通过购入价查找对应的加价率
                case "P":
                    foreach (object obj in al)
                    {
                        Neusoft.HISFC.Models.Material.MaterialAddRate tempAddRate = obj as Neusoft.HISFC.Models.Material.MaterialAddRate;
                        if (input.StoreBase.PriceCollection.PurchasePrice >= tempAddRate.PriceLow && input.StoreBase.PriceCollection.PurchasePrice < tempAddRate.PriceHigh)
                        {
                            addRate = tempAddRate;

                            break;
                        }
                    }
                    break;
                //如果是按规格加价 则需通过规格查找对应的加价率
                case "S":
                    foreach (object obj in al)
                    {
                        Neusoft.HISFC.Models.Material.MaterialAddRate tempAddRate = obj as Neusoft.HISFC.Models.Material.MaterialAddRate;
                        if (input.StoreBase.Item.Specs == tempAddRate.Specs)
                        {
                            addRate = tempAddRate;

                            break;
                        }
                    }
                    break;
                //如果是固定加价率 则只取第一条加价率数据
                case "R":
                    addRate = al[0] as Neusoft.HISFC.Models.Material.MaterialAddRate;
                    break;
                default:
                    break;
            }
            //如果查找的加价率为空，则零售价等于购入价；否则零售价  等于  购入价*（1+加价比率）+ 附加费
            if (addRate == null || string.IsNullOrEmpty(addRate.ID))
            {
                input.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.PurchasePrice;
            }
            else
            {
                input.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.PurchasePrice * (1 + addRate.AddRate) + addRate.AppendFee;
            }
            input.StoreBase.Extend = input.StoreBase.PriceCollection.RetailPrice.ToString();
        }

        #endregion

        #region IMatInManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 数据表初始化
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
												 new DataColumn("核准",		 dtBol),
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),																							
												 new DataColumn("入库数量",  dtDec),
												 new DataColumn("单位",      dtStr),
												 new DataColumn("包装数量",	 dtDec),
												 new DataColumn("购入价",    dtDec),	
												 new DataColumn("入库金额",  dtDec),
												 new DataColumn("批号",      dtStr),
												 new DataColumn("有效期",	 dtDate),
                                                 //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前{5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
                                                 new DataColumn("生产厂家",  dtStr),
												 new DataColumn("发票号",    dtStr),
												 new DataColumn("发票日期",  dtDate),
												 new DataColumn("零售价",	 dtDec),
												 new DataColumn("零售金额",  dtDec),
												 //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前
												 new DataColumn("项目编码",  dtStr),
												 new DataColumn("流水号",	 dtStr),
												 new DataColumn("数据来源",  dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr),
												 new DataColumn("主键",		 dtStr),
                                                 //{461BD435-B028-4ba8-8D83-34BA69BA1758} 增加一个生产厂家ID列
                                                 new DataColumn("生产厂家ID", dtStr)
											 }
                );

            DataColumn[] keys = new DataColumn[1];

            keys[0] = this.dt.Columns["主键"];

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
            //-----by yuyun 08-7-25 第一列变成自定义码  原自定义码列成物资编码{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            //string itemNO = sv.Cells[activeRow, 0].Text;
            string itemNO = sv.Cells[activeRow, 10].Text;

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(itemNO);
            if (item == null)
            {
                MessageBox.Show("根据项目编码获取项目信息失败 编码: " + itemNO);
                return -1;
            }

            foreach (DataRow dr in this.dt.Rows)
            {
                if (dr["项目编码"].ToString() == item.ID)
                {
                    DialogResult rs = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(item.Name + " 该项目已经添加过，是否确认增加新批号的吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.No)
                    {
                        isRepeatedStockNO = false;
                        return -1;
                    }
                    else
                    {
                        isRepeatedStockNO = true;
                    }
                }
            }

            this.ucInManager.AddNote((int)ColumnSet.ColItemID, (int)ColumnSet.ColTradeName);

            Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

            input.StoreBase.Item = item;				//项目信息
            input.StoreBase.PriceCollection.PurchasePrice = input.StoreBase.Item.UnitPrice;
            input.User01 = "0";							//数据来源
            input.User03 = this.GetKey();				//获取主键值
            //-----双击选择物资项目时  将物资目录中的生成厂家赋值到界面上作为默认生成厂家 by yuyun 08-7-25{5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
            input.StoreBase.Producer.ID = item.Factory.ID;
            Neusoft.HISFC.Models.Material.MaterialCompany company = new Neusoft.HISFC.Models.Material.MaterialCompany();
            company = companyManager.QueryCompanyByCompanyID(item.Factory.ID, "1", "0");

            if (company!= null && !string.IsNullOrEmpty(company.ID))
            {
                input.StoreBase.Producer.Name = company.Name; 
            }
            //-------------------
            //-----默认有效日期是当前日期加一年 by yuyun 08-7-25
            input.StoreBase.ValidTime = DateTime.Now.AddYears(1);
            //-------------------
            if (this.AddDataToTable(input) == 1)
            {
                //向Input集合内加入信息
                this.hsInputData.Add(this.GetKey(input), input);

                this.SetFocusSelect();

                return 1;
            }

            return 1; ;
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
            ArrayList alTemp = new ArrayList();
            //获取申请信息{CAC9F782-773F-4507-AD2D-C0F73513FF42}
            string currentDeptID = string.Empty;
            currentDeptID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            //获取申请信息
            alTemp = this.storeManager.QueryApplySimple(this.ucInManager.DeptInfo.ID, currentDeptID, "0510", "0", "12");

            if (alTemp == null)
            {
                System.Windows.Forms.MessageBox.Show("获取申请信息失败" + this.storeManager.Err);
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject selectObject = new Neusoft.FrameWork.Models.NeuObject();

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alTemp, ref selectObject) == 1)
            {
                this.Clear();

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                this.AddApplyData(selectObject.ID, "0");
                this.SetFocusSelect();

                if (this.ucInManager.FpSheetView != null)
                    this.ucInManager.FpSheetView.ActiveRowIndex = 0;
            }

            return 1;
        }

        public int ShowInList()
        {
            // TODO:  添加 CommonInPriv.ShowInList 实现
            return 0;
        }

        public int ShowOutList()
        {
            // TODO:  添加 CommonInPriv.ShowOutList 实现
            return 0;
        }

        public int ShowStockList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucMatListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.ucInManager.DeptInfo;
                this.ucListSelect.Class2Priv = "0512";          //采购
                this.ucListSelect.State = "2";                  //需检索状态
                this.ucListSelect.IsSelectState = false;

                this.ucListSelect.SelecctListEvent -= new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_StockSelecctListEvent);
                this.ucListSelect.SelecctListEvent += new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_StockSelecctListEvent);

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
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            if (this.ucInManager.TargetDept.ID == "")
            {
                System.Windows.Forms.MessageBox.Show("请选择供货单位！");
                return false;
            }
            try
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["入库数量"]) <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show(dr["物品名称"].ToString() + "入库数量不能小于等于零！");
                        return false;
                    }
                    if (NConvert.ToDecimal(dr["购入价"]) <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show(dr["物品名称"].ToString() + "购入价不能小于等于零！");
                        return false;
                    }
                    if(NConvert.ToDateTime(dr["有效期"]) <= itemManager.GetDateTimeFromSysDateTime())
                    {
                        System.Windows.Forms.MessageBox.Show("有效期应大于当前时间！");
                        return false;
                    }
                    if(dr["生产厂家"].ToString() == string.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("请选择生产厂家！");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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
                    DataRow dr = this.dt.Rows.Find(this.GetFindKey(sv, delRowIndex));
                    if (dr != null)
                    {
                        this.hsInputData.Remove(this.GetKey(sv, delRowIndex));

                        this.dt.Rows.Remove(dr);
                        //合计计算
                        this.CompuateSum();
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
            this.hsInputData.Clear();

            this.dt.Rows.Clear();

            this.dt.AcceptChanges();

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
                    this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInQty;
                }
                else
                {
                    this.ucInManager.SetFocus();
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

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            //当天操作日期
            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();
            //入库单据号
            string inListNO = null;
            this.alInput = new List<Neusoft.HISFC.Models.Material.Input>();

            try
            {
                Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();
                Neusoft.HISFC.Models.Material.InputPlan inputPlan = new Neusoft.HISFC.Models.Material.InputPlan();
                int serialNO = 0;
                string stockNO = null;

                foreach (DataRow dr in dtAddMofity.Rows)
                {
                    string key = this.GetKey(dr);

                    input = this.hsInputData[key] as Neusoft.HISFC.Models.Material.Input;


                    inputPlan = this.hsStockData[key] as Neusoft.HISFC.Models.Material.InputPlan;
                    //由数据表内获取部分入库信息实体
                    this.GetInputFormDataRow(dr, sysTime, ref input);

                    serialNO++;											//单内顺序号
                    input.StoreBase.SerialNO = serialNO;

                    #region 新库存序号(批次)信息 每一条入库记录生成一个新库存序号（批次号）

                    if ((stockNO == null) || (isRepeatedStockNO == true))
                    {
                        input.StoreBase.StockNO = this.storeManager.GetNewStockNO();
                        if (input.StoreBase.StockNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("未正确获取新批次流水号" + storeManager.Err);
                            return;
                        }
                        stockNO = input.StoreBase.StockNO;
                    }
                    else
                    {
                        input.StoreBase.StockNO = stockNO;
                    }

                    #endregion

                    #region 如果不存在入库单据号 则获取新入库单据号

                    //入库单号
                    if (inListNO == null)
                    {
                        inListNO = input.InListNO;
                    }

                    if (inListNO == "" || inListNO == null)
                    {
                        inListNO = this.storeManager.GetInListNO(this.ucInManager.DeptInfo.ID);
                        if (inListNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("获取最新入库单号出错" + this.storeManager.Err);
                            return;
                        }
                    }

                    input.InListNO = inListNO;

                    #endregion

                    #region 入库前库存数量

                    decimal storeQty = 0;
                    if (this.storeManager.GetStoreQty(input.StoreBase.StockDept.ID, input.StoreBase.Item.ID, out storeQty) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("获取库存数量时出错" + storeManager.Err);
                        return;
                    }
                    input.StoreBase.StoreQty = storeQty;               //入库前库存数量
                    input.StoreBase.StoreCost = Math.Round(input.StoreBase.StoreQty / input.StoreBase.Item.PackQty * input.StoreBase.PriceCollection.PurchasePrice, 3);

                    #endregion

                    #region 根据不同输入情况 设置入库信息状态

                    if (input.StoreBase.Operation.ApplyOper.ID == "")
                    {
                        input.StoreBase.Operation.ApplyQty = input.StoreBase.Quantity;                          //入库申请量
                        input.StoreBase.Operation.ApplyOper = input.StoreBase.Operation.Oper;
                    }

                    input.StoreBase.State = "0";
                    if (input.InvoiceNO != "")                //已输入发票号 直接设置状态为发票入库
                    {
                        input.StoreBase.Operation.ExamQty = input.StoreBase.Quantity;
                        input.StoreBase.Operation.ExamOper = input.StoreBase.Operation.Oper;
                        input.StoreBase.State = "1";
                    }

                    //本次入库为特殊入库
                    if (this.isSpecial)
                    {
                        input.StoreBase.State = "2";
                        input.StoreBase.Operation.ExamQty = input.StoreBase.Quantity;
                        input.StoreBase.Operation.ExamOper = input.StoreBase.Operation.Oper;
                        input.StoreBase.Operation.ApplyOper = input.StoreBase.Operation.Oper;
                    }

                    #endregion

                    //物资加价处理 by yuyun 08-8-4{2F0031DE-9957-48f3-A3B3-F207D0696D56}
                    //input.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.PurchasePrice;
                    this.SetRetailPrice(ref input);

                    input.StoreBase.RetailCost = input.StoreBase.StoreQty;
                    input.InFormalTime = input.StoreBase.Operation.Oper.OperTime;		//正式入库日期 一般入库时就是当前操作时间
                    input.StoreBase.Returns = 0.0000M;

                    //{0637D5E9-BE00-4df7-B09D-23236A4259CF}
                    //input.StoreBase.Producer.ID = this.companyTemp.ID;

                    if (this.storeManager.Input(input.Clone(), "1", input.StoreBase.State == "2" ? "1" : "0") == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("入库 保存失败" + this.storeManager.Err);

                        return;
                    }

                    #region 更新物资目录中的入库价和生产厂家 by yuyun 08-7-28{5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
                    if (isUpdateUnitPrice == true)
                    {
                        if (this.storeManager.UpdateUnitPriceAndFactory(input.StoreBase.Item.ID, input.StoreBase.PriceCollection.PurchasePrice, input.StoreBase.Producer.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("更新目录中入库价和生产厂家失败" + this.storeManager.Err);

                            return;
                        } 
                    }
                    #endregion

                    #region 根据不同数据来源对数据进行更新

                    switch (dr["数据来源"].ToString())
                    {
                        case "0":           //手工选择
                            break;
                        case "2":           //申请

                            if (this.storeManager.UpdateApplyApproveState(input.PlanListNO, "1", input.StoreBase.Operation.Oper) == -1)//input.StoreBase.StockDept.ID
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                Function.ShowMsg("申请核准失败" + itemManager.Err);

                                return;
                            }

                            break;
                        case "1":           //采购

                            if (this.storeManager.UpdatePlanInputState(inputPlan.StorageCode, inputPlan.PlanListCode, inputPlan.PlanNo, "3", input.StoreBase.Operation.Oper.ID, input.StoreBase.Operation.Oper.OperTime) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                Function.ShowMsg("申请核准失败" + itemManager.Err);

                                return;
                            }
                            break;
                    }

                    #endregion

                    alInput.Add(input);

                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg(ex.Message);

                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (this.isSpecial)
            {
                Function.ShowMsg("特殊入库保存成功");
            }
            else
            {
                Function.ShowMsg("一般入库保存成功");
            }

            if (alInput.Count > 0)
            {
                if (MessageBox.Show("是否打印?", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Print();
                }

            }
            this.Clear();

            FarPoint.Win.Spread.CellType.NumberCellType noCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            noCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = noCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = noCellType;
        }

        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        public int Print()
        {
            if(this.ucInManager.IInPrint != null)
            {
                this.ucInManager.IInPrint.SetData(this.alInput);
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
            this.ucInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(ucInManager_FpKeyEvent);

            this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(ucInManager_EndTargetChanged);

            this.ucInManager.Fp.EditModeOn -= new EventHandler(Fp_EditModeOn);
            this.ucInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);

            this.ucInManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

            this.ucInManager.Fp.KeyDown -= new KeyEventHandler(Fp_KeyDown);
        }

        #endregion

        #region 事件处理方法

        private void Fp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColProducerName)
                {
                    this.GetCompany((int)ColumnSet.ColProducerName);
                }
            }
        }

        private void ucInManager_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            return;
        }

        private void ucInManager_FpKeyEvent(Keys key)
        {
            if (key == Keys.Enter)
            {
                #region 回车跳转
                #region 系统切换的时候特殊处理
                if (this.ucInManager.PrivType.Memo == "1C")
                {
                    if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInQty)
                    {
                        if (this.ucInManager.FpSheetView.ActiveRowIndex == this.ucInManager.FpSheetView.Rows.Count - 1)
                        {
                            this.ucInManager.SetFocus();
                        }
                        else
                        {
                            this.ucInManager.FpSheetView.ActiveRowIndex++;
                            this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInQty;
                        }
                    }
                    return;
                }
                #endregion

                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColProducerName)
                {
                    if (this.ucInManager.FpSheetView.ActiveRowIndex == this.ucInManager.FpSheetView.Rows.Count - 1)
                    {
                        this.ucInManager.SetFocus();
                    }
                    else
                    {
                        this.ucInManager.FpSheetView.ActiveRowIndex++;
                        this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInQty;
                    }

                    return;
                }
                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInQty)
                {
                    this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColPurchasePrice;

                    return;
                }
                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
                {
                    this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColBatchNO;

                    return;
                }

                this.ucInManager.FpSheetView.ActiveColumnIndex++;

                while (!this.ucInManager.FpSheetView.Columns[this.ucInManager.FpSheetView.ActiveColumnIndex].Visible)
                {
                    if (this.ucInManager.FpSheetView.Columns.Count > this.ucInManager.FpSheetView.ActiveColumnIndex)
                        this.ucInManager.FpSheetView.ActiveColumnIndex++;
                }

                #endregion
            }

            if (key == Keys.F5)
            {
                this.ucInManager.SetFocus();
            }
        }

        private void Fp_EditModeOn(object sender, EventArgs e)
        {


            /*  屏蔽EditModeOn处理

            if (this.hsInputData.Contains(this.GetKey(this.ucInManager.FpSheetView,this.ucInManager.FpSheetView.ActiveRowIndex)))
            {
                this.privInput = this.hsInputData[this.GetKey(this.ucInManager.FpSheetView,this.ucInManager.FpSheetView.ActiveRowIndex)] as Neusoft.HISFC.Models.Material.Input;

                this.privKey = this.GetKey(this.ucInManager.FpSheetView,this.ucInManager.FpSheetView.ActiveRowIndex);
            }
            else
            {
                this.privInput = null;
            }

            */
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {

            if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInQty || this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
            {
                DataRow dr = this.dt.Rows.Find(this.GetFindKey(this.ucInManager.FpSheetView, this.ucInManager.FpSheetView.ActiveRowIndex));
                if (dr != null)
                {
                    dr["入库金额"] = NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }

            /*  屏蔽以下处理 EditModeOff 处理金额显示

            if (this.privInput != null)
            {
                int iRow = this.ucInManager.FpSheetView.ActiveRowIndex;
                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColBatchNO)
                {
                    if (this.hsInputData.ContainsKey(this.privKey))
                    {
                        this.privInput.StoreBase.BatchNO = this.ucInManager.FpSheetView.Cells[iRow,(int)ColumnSet.ColBatchNO].Text;

                        this.hsInputData.Remove(this.privKey);

                        this.hsInputData.Add(this.GetKey(this.ucInManager.FpSheetView,this.ucInManager.FpSheetView.ActiveRowIndex),this.privInput);
                    }
                }

                if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
                {
                    if (this.hsInputData.ContainsKey(this.privKey))
                    {
                        this.privInput.StoreBase.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.ucInManager.FpSheetView.Cells[iRow,(int)ColumnSet.ColBatchNO].Text);

                        this.hsInputData.Remove(this.privKey);

                        this.hsInputData.Add(this.GetKey(this.ucInManager.FpSheetView,this.ucInManager.FpSheetView.ActiveRowIndex),this.privInput);
                    }
                }
            }
			
            */
        }

        private void Fp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                return;
            }
            this.GetCompany(e.Column);
        }

        private void ucListSelect_StockSelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            //供货单位
            this.ucInManager.TargetDept = targetDept;
            //增加采购数据
            this.AddStockData(listCode, state);
        }       

        /// <summary>
        /// 计算税前，税后价格
        /// </summary>
        /// <param name="decPrice"></param>
        /// <returns></returns>
        private decimal GetPrice(decimal decPrice)
        {
            //if (this.ucInManager.rbnPRe.Checked)
            //{
            return decPrice;
            //}
            //else
            //{
            //    return Math.Round(decPrice * (decimal)1.17, 2);   //1.17是税率
            //}
        }
        #endregion

        #region 列枚举
       /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 核准
            /// </summary>
            ColIsApprove,
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 入库数量（包装单位数量）
            /// </summary>
            ColInQty,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
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
            //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前    {5C88E1AE-FCB7-4d88-B23B-7F67291CBB04}
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProducerName,
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
            //-----by yuyun 08-7-25 为了让生产厂家在一个界面中显示  将生成厂家提前            
            /// <summary>
            /// 项目编码
            /// </summary>
            ColItemID,
            /// <summary>
            /// 流水号
            /// </summary>
            ColInBillNO,
            /// <summary>
            /// 数据来源
            /// </summary>
            ColDataSource,
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
            /// 主键
            /// </summary>
            ColKey,
            /// <summary>
            /// 生产厂家ID {0637D5E9-BE00-4df7-B09D-23236A4259CF}
            /// </summary>
            ColProducerID
        }
       #endregion
    }
}
