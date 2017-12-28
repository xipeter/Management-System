using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /*  
     * 对于添加采购信息时 同时生成入库信息 存入hsInputData内 存储数据来源为采购 存储采购流水号
     *                                      采购信息加入hsStockData内 同时获取新药品信息
     *                    保存时 根据采购流水号获取采购信息进行确认
     * 对于外部申请信息时 同时生成入库信息 存入hsInputData内 存储数据来源为申请 同时获取新药品信息 
     *                     保存时 根据入库流水号进行申请信息确认
     * 对于直接增加的药品 同时生成入库信息 存入hsInputData内 存储数据来源为手工选择
     *                    保存时 直接确认
     * 
     * 
     *  修改基类内的frmEasyChoose窗口 增加FpLabel FpWidth FpVisible 设置Fp的外观显示 
     * 
     * 
     * 需要解决对于修改的情况下 当批号发生变化时 如何保证对hsData内的数据进行处理
     * pS 如果不处理好像问题也不大,只是对dataset内怎么办呢?
     * 对此问题的处理一直不是很方便 待调整
     * 
     * 药品编码12位
     * 
     *  待完善  发票批量输入 发票默认上一张
     *
     * 增加发票时间，招标标记，一般入库时的购入价
     * 
     */



    /// <summary>
    /// [功能描述: 一般入库类型实例]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// 
    /// <说明>
    ///     1、采购入库导入文件格式要求 编码 名称 规格 批号 购入价 数量 有效期
    /// </说明>
    /// <修改记录>
    ///     <时间>2007-07</时间>
    ///     <修改人>Liangjz</修改人>
    ///     <修改说明>1、增加药房特殊入库功能</修改说明>
    ///     <修改说明>
    ///        1.修改一般入库判断是否录入发票号没有验证null的Bug by Sunjh 2010-8-25 {003645CF-57A3-4e52-B227-90D33A79B78F}
    ///     </修改说明>
    /// </修改记录>
    /// </summary>
    public class CommonInPriv : IPhaInManager
    {
        public CommonInPriv(bool isSpecial, Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.isSpecialIn = isSpecial;

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.SetPhaManagerProperty(ucPhaManager);
            }
        }

        #region 域变量

        private bool isSpecialIn = false;
        //{73CBD808-5BA4-4adc-8F58-AEF257F82FC9}  由Private 更改为 Protected
        protected ucPhaIn phaInManager = null;

        private FarPoint.Win.Spread.SheetView svTemp = null;
        //{73CBD808-5BA4-4adc-8F58-AEF257F82FC9} 由Private 更改为 Protected
        protected DataTable dt = null;

        ucCommonInDetail ucDetail = null;

        /// <summary>
        /// 一般入库是否需要核准
        /// </summary>
        private bool IsNeedApprove = true;

        /// <summary>
        /// 入库数据
        /// </summary>
        private System.Collections.Hashtable hsInputData = new System.Collections.Hashtable();

        /// <summary>
        /// 采购数据
        /// </summary>
        private System.Collections.Hashtable hsStockData = new System.Collections.Hashtable();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucPhaListSelect ucListSelect = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.TextCellType tReadOnly = new FarPoint.Win.Spread.CellType.TextCellType();

        /// <summary>
        /// CheckBox单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.CheckBoxCellType chkCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

        /// <summary>
        /// 前修改数据键值
        /// </summary>
        private string privKey = "";

        /// <summary>
        /// 当前日期
        /// </summary>
        private DateTime sysTime = System.DateTime.MinValue;

        /// <summary>
        /// 是否判断当前选择的供货公司与基本信息内的供货公司的异同
        /// </summary>
        private bool isJudgeDefaultCompany = false;

        /// <summary>
        /// 数据导入控件
        /// </summary>
        private Neusoft.HISFC.Components.Common.Controls.ucImportData ucImport = null;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private ArrayList alPrintData = null;

        #endregion

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetPhaManagerProperty(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.phaInManager = ucPhaManager;

            if (this.phaInManager != null)
            {
                //设置界面显示
                this.phaInManager.IsShowItemSelectpanel = false;
                this.phaInManager.IsShowInputPanel = true;
                //设置目标科室信息  对于药库/药房进行不同设置
                if (this.phaInManager.DeptInfo.Memo == "PI")
                {
                    this.phaInManager.SetTargetDept(true, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                    //{EDD03CD1-6E6D-4e2c-8FCD-D8C73E21A34A}
                    //this.phaInManager.TargetDept = new Neusoft.FrameWork.Models.NeuObject();

                    //设置工具栏按钮显示
                    this.phaInManager.SetToolBarButton(true, false, false, true, true, true);
                    this.phaInManager.SetToolBarButtonVisible(true, false, false, true, true, true, true);
                }
                else
                {
                    //{EDD03CD1-6E6D-4e2c-8FCD-D8C73E21A34A}
                    this.phaInManager.SetTargetDept(false, true,true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

                    //this.phaInManager.TargetDept = new Neusoft.FrameWork.Models.NeuObject();

                    //设置工具栏按钮显示
                    //this.phaInManager.SetToolBarButton(true, false, false, true, true, true);
                    this.phaInManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                }

                //信息说明设置
                this.phaInManager.ShowInfo = "对下部所列数据双击可进行修改";
                //设置Fp属性
                this.phaInManager.Fp.EditModePermanent = false;
                this.phaInManager.Fp.EditModeReplace = false;
                
                this.phaInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(phaInManager_EndTargetChanged);
                this.phaInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(phaInManager_EndTargetChanged);

                this.phaInManager.Fp.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

                this.svTemp = this.phaInManager.FpSheetView;
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="errStr">提示信息</param>
        private void ShowMsg(string strMsg)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            System.Windows.Forms.MessageBox.Show(Language.Msg(strMsg));
        }

        /// <summary>
        /// /初始化
        /// </summary>
        protected virtual void Init()
        {
            //获取控制参数判断是否需要核准
            Neusoft.FrameWork.Management.ControlParam ctrlManager = new Neusoft.FrameWork.Management.ControlParam();

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsNeedApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.In_Need_Approve, true, true);

            //打开窗口日期
            this.sysTime = ctrlManager.GetDateTimeFromSysDateTime().Date;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="item"></param>
        /// <param name="dataSource">数据来源 1 采购单 2 申请单 0 手工选择</param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Pharmacy.Input ConvertToInput(Neusoft.HISFC.Models.Pharmacy.Item item,string dataSource)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

            input.Item = item;

            #region 实体赋值

            input.SpecialFlag = NConvert.ToInt32(this.isSpecialIn).ToString();  //是否特殊入库 0 否 1 是
            input.StockDept = this.phaInManager.DeptInfo;                       //库存科室
            input.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
            input.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
            input.Company = this.phaInManager.TargetDept;                       //供货单位 
            input.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位

            input.User01 = dataSource;                                          //数据来源 1 采购单 2 申请单 0 手工选择
          
            #endregion

            return input;
        }

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息 Input.User01存储数据来源</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            //中草药自动设置批号为"1"
            if (input.Item.Type.ID == "C" && (input.BatchNO == "" || input.BatchNO == null))
            {
                input.BatchNO = "1";
            }

            try
            {
                input.RetailCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;
                input.PurchaseCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice;

                this.dt.Rows.Add(new object[] { 
                                                true,
                                                input.DeliveryNO,                           //送货单号
                                                input.Item.Name,                            //商品名称
                                                input.Item.Specs,                           //规格
                                                input.Item.PriceCollection.RetailPrice,     //零售价
                                                input.Item.PackUnit,                        //包装单位
                                                input.Item.PackQty,                         //包装数量
                                                input.Quantity / input.Item.PackQty,        //入库数量
                                                input.RetailCost,                           //入库金额
                                                input.BatchNO,                              //批号
                                                input.ValidTime,                            //有效期
                                                input.InvoiceNO,                            //发票号
                                                input.InvoiceType,                          //发票类别
                                                input.Item.PriceCollection.PurchasePrice,   //购入价
                                                input.PurchaseCost,                         //购入金额
                                                input.Item.Product.Producer.Name,           //生产厂家
                                                input.Item.ID,                              //药品编码
                                                input.ID,                                   //流水号
                                                input.User01,                               //数据来源
                                                input.Item.NameCollection.SpellCode,        //拼音码
                                                input.Item.NameCollection.WBCode,           //五笔码
                                                input.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                                );
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
        protected virtual void SetFormat( )
        {
            if (this.svTemp == null)
                return;

            this.tReadOnly.ReadOnly = true;

            this.svTemp.DefaultStyle.Locked = true;

            this.svTemp.Columns[(int)ColumnSet.ColIsApprove].Width = 38F;
            this.svTemp.Columns[(int)ColumnSet.ColDeliveryNO].Width = 60F;
            this.svTemp.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.svTemp.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.svTemp.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.svTemp.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.svTemp.Columns[(int)ColumnSet.ColPackQty].Width = 60F;
            this.svTemp.Columns[(int)ColumnSet.ColBatchNO].Width = 90F;
            this.svTemp.Columns[(int)ColumnSet.ColInvoiceNO].Width = 80F;

            this.svTemp.Columns[(int)ColumnSet.ColValidTime].Visible = true;        //有效期
            this.svTemp.Columns[(int)ColumnSet.ColInvoiceType].Visible = false;      //发票分类
            this.svTemp.Columns[(int)ColumnSet.ColProducerName].Visible = false;     //生产厂家
            this.svTemp.Columns[(int)ColumnSet.ColDrugID].Visible = false;           //药品编码
            this.svTemp.Columns[(int)ColumnSet.ColInBillNO].Visible = false;         //流水号
            this.svTemp.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.svTemp.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.svTemp.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.svTemp.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            this.svTemp.Columns[(int)ColumnSet.ColIsApprove].Locked = false;
        }

        /// <summary>
        /// 增加申请数据
        /// </summary>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 </失败返回-1returns>
        protected virtual int AddApplyData(string listCode,string state)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList al = itemManager.QueryApplyIn(this.phaInManager.DeptInfo.ID, listCode, "0");
            if (al == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("未正确获取外部入库申请信息" + itemManager.Err));
                return -1;
            }

            this.Clear();

            Neusoft.FrameWork.Models.NeuObject applyCompany = new Neusoft.FrameWork.Models.NeuObject();

            foreach (Neusoft.HISFC.Models.Pharmacy.Input input in al)
            {
                Neusoft.HISFC.Models.Pharmacy.Item tempItem = itemManager.GetItem(input.Item.ID);

                if (Function.SetPrice(this.phaInManager.DeptInfo.ID, tempItem.ID, ref tempItem) == -1)
                {
                    return -1;
                }

                input.Item = tempItem;                               //药品实体信息

                input.User01 = "2";                                 //数据来源 1 采购单 2 申请单 0 手工选择
                input.Quantity = input.Operation.ApplyQty;

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInputData.Add(input.Item.ID + input.BatchNO, input);
                }

                applyCompany = input.Company;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.Company compay = consManager.QueryCompanyByCompanyID(applyCompany.ID);
            applyCompany.Name = compay.Name;
            applyCompany.Memo = "1";

            this.phaInManager.TargetDept = applyCompany;

            this.CompuateSum();

            return 1;
        }

        /// <summary>
        /// 增加采购数据
        /// </summary>
        /// <param name="listCode">采购计划单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int AddStockData(string listCode,string state)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList alStock = itemManager.QueryStockPlanByCompany(this.phaInManager.DeptInfo.ID, listCode, this.phaInManager.TargetDept.ID);
            if (alStock == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("获取采购明细信息发生错误" + itemManager.Err));
                return -1;
            }

            this.Clear();

            foreach (Neusoft.HISFC.Models.Pharmacy.StockPlan info in alStock)
            {
                if (info.State == "3")              //明细内状态为'3'的 说明已进行过入库处理 不再次显示
                    continue;

                Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

                //对于草药默认批号为"1"
                Neusoft.HISFC.Models.Pharmacy.Item tempItem = itemManager.GetItem(info.Item.ID);
                if (tempItem != null && tempItem.Type.ID.ToString() == "C")
                    input.BatchNO = "1";

                input.Item = tempItem;                                              //药品实体信息
                //{C03DD304-AE71-4b6a-BC63-F385DB162EB7}
                input.Item.Product.Producer = info.Item.Product.Producer;

                input.SpecialFlag = NConvert.ToInt32(this.isSpecialIn).ToString();  //是否特殊入库 0 否 1 是
                input.StockDept = this.phaInManager.DeptInfo;                       //库存科室
                input.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
                input.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
                input.Company = this.phaInManager.TargetDept;                       //供货单位 
                input.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位

                input.Quantity = info.StockApproveQty - info.InQty;                      //数量

                input.DeliveryNO = listCode;                                        //送货单号 设置为采购单号
                input.StockNO = info.ID;

                input.User01 = "1";                                                 //数据来源 1采购单 2申请单 0手工选择

                if (input.ValidTime == System.DateTime.MinValue)
                {
                    input.ValidTime = this.sysTime.AddYears(5);
                }

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInputData.Add(input.Item.ID + input.BatchNO, input);

                    this.hsStockData.Add(info.ID, info);
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
            decimal retailCost = 0;
            decimal purchaseCost = 0;
            decimal balanceCost = 0;

            if (this.dt != null)
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    retailCost += NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["零售价"]);
                    purchaseCost += NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);                    
                }

                balanceCost = (retailCost - purchaseCost);

                this.phaInManager.TotCostInfo = string.Format("零售金额:{0} 购入金额:{1} 差价:{2}", retailCost.ToString("N"), purchaseCost.ToString("N"), balanceCost.ToString("N"));
            }
        }

        #region IPhaInManager 成员

        /// <summary>
        /// 详细信息录入控件
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                ucDetail = new ucCommonInDetail();

                ucDetail.Init();

                ucDetail.PrivDept = this.phaInManager.DeptInfo;

                ucDetail.IsManagerPurchasePrice = true;

                ucDetail.InInstanceCompleteEvent -= new ucCommonInDetail.InstanceCompleteHandler(ucDetail_InInstanceCompleteEvent);
                ucDetail.InInstanceCompleteEvent += new ucCommonInDetail.InstanceCompleteHandler(ucDetail_InInstanceCompleteEvent);

                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //添加清空键值事件
                ucDetail.ClearPriKey -= new ucCommonInDetail.InstanceCompleteHandler(ucDetail_ClearPriKey);
                ucDetail.ClearPriKey += new ucCommonInDetail.InstanceCompleteHandler(ucDetail_ClearPriKey);

                return ucDetail;
            }
        }

        /// <summary>
        /// 返回过滤DataSet
        /// </summary>
        /// <param name="sv">需设置的Fp</param>
        /// <returns></returns>
        public virtual System.Data.DataTable InitDataTable()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            this.dt = new DataTable();

            this.dt.Columns.AddRange(
                                    new System.Data.DataColumn[] {
                                                                    new DataColumn("核准",      dtBol),
                                                                    new DataColumn("送货单号",  dtStr),
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("包装数量",  dtDec),
                                                                    new DataColumn("入库数量",  dtDec),
                                                                    new DataColumn("入库金额",  dtDec),
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("有效期",    dtDate),
                                                                    new DataColumn("发票号",    dtStr),
                                                                    new DataColumn("发票分类",  dtStr),
                                                                    new DataColumn("购入价",    dtDec),
                                                                    new DataColumn("购入金额",  dtDec),
                                                                    new DataColumn("生产厂家",  dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("流水号",    dtStr),
                                                                    new DataColumn("数据来源",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr)
                                                                   }
                                  );

            DataColumn[] keys = new DataColumn[2];

            keys[0] = this.dt.Columns["药品编码"];
            keys[1] = this.dt.Columns["批号"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }

        /// <summary>
        /// 增加药品项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parms"></param>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            return 1;
        }

        /// <summary>
        /// 显示申请列表
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowApplyList()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            string offerID = "";
            if (this.phaInManager.TargetDept == null || this.phaInManager.TargetDept.ID == "")
                offerID = "AAAA";
            else
                offerID = this.phaInManager.TargetDept.ID;

            //外部入库申请
            ArrayList al = itemManager.QueryApplyInList(this.phaInManager.DeptInfo.ID, offerID, "0");
            if (al == null)
            {
                this.ShowMsg("获取申请列表失败" + itemManager.Err);
                return -1;
            }

            #region 根据供货单位进行过滤

            ArrayList alList = new ArrayList();
            if (this.phaInManager.TargetDept.ID != "")
            {
                foreach (Neusoft.FrameWork.Models.NeuObject info in al)
                {
                    if (info.Memo != this.phaInManager.TargetDept.ID)
                        continue;
                    alList.Add(info);
                }
            }
            else
            {
                alList = al;
            }

            #endregion

            #region 弹出选择窗口 进行单据选择

            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] fpLabel = { "申请单号", "供货单位" };
            float[] fpWidth = { 120F, 120F };
            bool[] fpVisible = { true, true, false, false, false, false };

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, ref selectObj) == 1)
            {
                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                targeDept.ID = selectObj.Memo;              //供货公司编码
                targeDept.Name = selectObj.Name;            //供货公司姓名
                targeDept.Memo = "1";                       //目标单位性质 外部供货公司

                this.AddApplyData(selectObj.ID, "");
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 显示入库单
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowInList()
        {
            return 1;
        }

        /// <summary>
        /// 显示出库单
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowOutList()
        {
            return 1;
        }

        /// <summary>
        /// 显示采购单列表
        /// </summary>
        /// <returns></returns>
        public int ShowStockList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucPhaListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.phaInManager.DeptInfo;
                this.ucListSelect.Class2Priv = "0312";          //采购
                this.ucListSelect.State = "2";                  //需检索状态
                this.ucListSelect.IsSelectState = false;                

                this.ucListSelect.SelecctListEvent -= new ucIMAListSelecct.SelectListHandler(ucListSelect_StockSelecctListEvent);
                this.ucListSelect.SelecctListEvent += new ucIMAListSelecct.SelectListHandler(ucListSelect_StockSelecctListEvent);

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucListSelect);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg(ex.Message));
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <returns></returns>
        public int ImportData()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("导入数据将清除当前未保存数据 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
            {
                return 1;
            }

            this.Clear();

            if (this.ucImport == null)
            {
                this.ucImport = new Neusoft.HISFC.Components.Common.Controls.ucImportData();
            }

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucImport);

            if (this.ucImport.Result == DialogResult.OK && this.ucImport.ImportData != null)
            {
                if (this.ucImport.ImportData.Tables[0].Columns.Count != 8)
                {
                    MessageBox.Show(Language.Msg("导入文件格式不正确 请检查导入文件信息"));
                    return -1;
                }
                int iCount = 0;
                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                foreach (DataRow dr in this.ucImport.ImportData.Tables[0].Rows)
                {
                    string drugCode = dr[0].ToString();                 //编码
                    if (drugCode == null || drugCode == "")
                    {
                        continue;
                    }

                    string batchNO = dr[3].ToString();                  //批号
                    decimal purchasePrice = NConvert.ToDecimal(dr[4]);  //购入价
                    decimal qty = NConvert.ToDecimal(dr[5]);            //数量
                    string invoiceNO = dr[6].ToString();
                    DateTime validTime = NConvert.ToDateTime(dr[7]);    //有效期

                    Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(drugCode);

                    Neusoft.HISFC.Models.Pharmacy.Input input = this.ConvertToInput(item,"0");

                    input.BatchNO = batchNO;                                        //批号
                    input.Item.PriceCollection.PurchasePrice = purchasePrice;       //购入价
                    input.Quantity = qty * item.PackQty;                            //入库数量
                    input.InvoiceNO = invoiceNO;                                    //发票号
                    input.ValidTime = validTime;                                    //有效期

                    input.RetailCost = qty * item.PriceCollection.RetailPrice;      //零售金额
                    input.PurchaseCost = qty * input.Item.PriceCollection.PurchasePrice;

                    if (this.AddDataToTable(input) == 1)
                    {
                        this.hsInputData.Add(input.Item.ID + input.BatchNO, input);
                        iCount++;
                    }
                }

                this.SetFormat();

                if (this.svTemp != null)
                {
                    this.svTemp.ActiveRowIndex = this.svTemp.Rows.Count - 1;
                }

                MessageBox.Show(Language.Msg("本次成功导入" + iCount.ToString() + "条记录"));

                this.CompuateSum();
            }           

            return 1;
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>填写有效 返回True 否则返回 False</returns>
        public virtual bool Valid()
        {
            if (this.phaInManager.TargetDept.ID == "")
            {
                MessageBox.Show(Language.Msg("请选择供货公司"));
                return false;
            }

            if (this.dt.Rows.Count == 0)
            {
                MessageBox.Show(Language.Msg("请确认选择需入库的药品"));
                return false;
            }

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            DateTime sysTime = dataManager.GetDateTimeFromSysDateTime();

            foreach (DataRow dr in this.dt.Rows)
            {
                if (NConvert.ToDecimal(dr["入库数量"]) <= 0)
                {
                    MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + "  请输入入库数量 入库数量不能小于等于0"));
                    return false;
                }
                if (dr["批号"].ToString() == "")
                {
                    MessageBox.Show(Language.Msg("请输入批号"));
                    return false;
                }
                if (NConvert.ToDateTime(dr["有效期"]) < sysTime)
                {
                    MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + "  有效期应大于当前日期"));
                    return false;
                }
                if (dr["发票号"].ToString().Length > 10)
                {
                    MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + "  发票号过长，最长支持10位"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sv">需执行删除的Fp</param>
        /// <param name="delRowIndex">需删除的行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public virtual int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            try
            {
                if (sv != null && delRowIndex >= 0)
                {
                    string[] keys = new string[]{
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColDrugID].Text,
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
                                            };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {                        
                        Neusoft.HISFC.Models.Pharmacy.Input input = this.hsInputData[dr["药品编码"].ToString() + dr["批号"].ToString()] as Neusoft.HISFC.Models.Pharmacy.Input;
                        if (input.StockNO != null && this.hsStockData.ContainsKey(input.StockNO))
                        {
                            this.hsStockData.Remove(input.StockNO);
                        }

                        this.hsInputData.Remove(dr["药品编码"].ToString() + dr["批号"].ToString());

                        this.dt.Rows.Remove(dr);
                        //合计计算
                        this.CompuateSum();
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

        /// <summary>
        /// 清空数据显示
        /// </summary>
        /// <returns></returns>
        public virtual int Clear()
        {
            try
            {
                this.dt.Rows.Clear();

                this.dt.AcceptChanges();

                this.ucDetail.Clear(true);

                this.hsInputData.Clear();

                this.hsStockData.Clear();

                this.privKey = "";

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行清空操作发生错误" + ex.Message));
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        public virtual void Filter(string filterStr)
        {
            if (this.dt == null)
                return;

            //获得过滤条件
            string queryCode = "%" + filterStr + "%";

            string filter = Function.GetFilterStr(this.dt.DefaultView, queryCode);

            //this.dt.DefaultView.RowFilter = "拼音码 like '*" + filterStr + "*'";

            this.dt.DefaultView.RowFilter = filter;

            //string filter = string.Format("(拼音码 LIKE '{0}') OR (五笔码 LIKE '{0}') OR (自定义码 LIKE '{0}') OR (商品名称 LIKE '{0}')", queryCode);

            //try
            //{
            //    this.dt.DefaultView.RowFilter = filter;
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("过滤发生异常 " + ex.Message));
            //}
            this.SetFormat();
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        public virtual void SetFocusSelect()
        {
            this.ucDetail.Select();
            this.ucDetail.Focus();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual void Save()
        {
            if (!this.Valid())
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //itemManager.SetTrans(t.Trans);
            //phaIntegrate.SetTrans(t.Trans);

            #endregion

            #region 获取新批次信息

            string strNewGroupNO = itemManager.GetNewGroupNO();
            if (strNewGroupNO == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                System.Windows.Forms.MessageBox.Show(Language.Msg("未正确获取新批次流水号" + itemManager.Err));
                return;
            }
            int newGroupNO = NConvert.ToInt32(strNewGroupNO);

            #endregion

            #region 保存本次保存的药品编码 对于同一编码药品多次入库生成不同的批次号 否则退库等操作无法唯一标志一次入库

            System.Collections.Hashtable hsItem = new Hashtable();

            #endregion

            //当天操作日期
            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();
            //入库单据号
            string inListNO = null;

            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();
            this.alPrintData = new ArrayList();

            foreach (DataRow dr in this.dt.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();

                input = this.hsInputData[key] as Neusoft.HISFC.Models.Pharmacy.Input;

                #region 入库数据赋值处理

                if (inListNO == null)
                {
                    inListNO = input.InListNO;
                }

                input.GroupNO = newGroupNO;                                         //批次号

                if (hsItem.ContainsKey(input.Item.ID))
                {
                    input.GroupNO = NConvert.ToInt32(itemManager.GetNewGroupNO());
                }
                else
                {
                    hsItem.Add(input.Item.ID, null);
                }

                #region 如果不存在入库单据号 则获取新入库单据号

                if (inListNO == "" || inListNO == null)
                {
                    //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                    inListNO = phaIntegrate.GetInOutListNO(this.phaInManager.DeptInfo.ID, true);
                    if (inListNO == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.ShowMsg("获取最新入库单号出错" + itemManager.Err);
                        return;
                    }
                }

                #endregion

                input.InListNO = inListNO;                                          //入库单据号

                #region 以下信息在每次添加数据生成入库信息实体时赋值

                input.SpecialFlag = NConvert.ToInt32(this.isSpecialIn).ToString();  //是否特殊入库 0 否 1 是
                input.StockDept = this.phaInManager.DeptInfo;                       //库存科室
                input.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
                input.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
                input.Company = this.phaInManager.TargetDept;                       //供货单位 
                input.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位
                // {D28CC3CF-C502-4987-BC01-1AEBF2F9D17F} sel 增加下面两个属性的赋值
                input.CommonPurchasePrice=input.PriceCollection.PurchasePrice;       //一般入库时的购入价
                //input.InvoiceDate=;                                               //发票上的发票日期
                #endregion

                #region 入库后库存数量 一般入库肯定新批次 一般入库后该批次库存就是本次入库量

                input.StoreQty = input.Quantity;               //入库后库存数量
                input.StoreCost = Math.Round(input.StoreQty / input.Item.PackQty * input.Item.PriceCollection.RetailPrice, 3);

                #endregion

                if (input.Operation.ApplyOper.ID == "")
                {
                    input.Operation.ApplyQty = input.Quantity;                          //入库申请量
                    input.Operation.ApplyOper.ID = this.phaInManager.OperInfo.ID;
                    input.Operation.ApplyOper.OperTime = sysTime;
                }

                input.Operation.Oper.ID = this.phaInManager.OperInfo.ID;
                input.Operation.Oper.OperTime = sysTime;

                #region 根据不同输入情况 设置入库信息状态

                input.State = "0";
                //修改一般入库判断是否录入发票号没有验证null的Bug by Sunjh 2010-8-25 {003645CF-57A3-4e52-B227-90D33A79B78F}
                if (input.InvoiceNO != null && input.InvoiceNO != "")                //已输入发票号 直接设置状态为发票入库
                {
                    input.Operation.ExamQty = input.Quantity;
                    input.Operation.ExamOper.OperTime = input.Operation.Oper.OperTime;
                    input.Operation.ExamOper.ID = input.Operation.Oper.ID;
                    input.State = "1";
                }

                //控制参数设定一般入库不需要核准 或 本次入库为特殊入库
                if (!this.IsNeedApprove || this.isSpecialIn)
                {
                    input.State = "2";
                    input.Operation.ExamQty = input.Quantity;
                    input.Operation.ExamOper.OperTime = input.Operation.Oper.OperTime;
                    input.Operation.ExamOper.ID = input.Operation.Oper.ID;
                    input.Operation.ApplyOper.OperTime = input.Operation.Oper.OperTime;
                    input.Operation.ApproveOper.ID = input.Operation.Oper.ID;
                    //{BC502D46-48CE-4ced-A6AA-20E1B0132D40}  对核准时间进行赋值
                    input.Operation.ApproveOper = input.Operation.ExamOper;

                    //{476ED544-49A6-4070-9ACB-C581F403347D} 对字典记录进行入库信息更新
                    if (itemManager.UpdateBaseItemWithInputInfo(input) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.ShowMsg("入库 保存失败" + itemManager.Err);
                        return;
                    }
                }

                #endregion

                //供货单位类型 1 院内科室 2 供货公司 3 扩展
                //{24E12384-34F7-40c1-8E2A-3967CECAF615} 数据赋值
                if (this.phaInManager.DeptInfo.Memo == "PI")                //当前登录科室为药库
                {
                    input.SourceCompanyType = "2";
                }
                else
                {
                    input.SourceCompanyType = "1";
                }

                if (itemManager.Input(input.Clone(), "1", input.State == "2" ? "1" : "0") == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.ShowMsg("入库 保存失败" + itemManager.Err);
                    return;
                }

                #endregion

                #region 根据不同数据来源对原始数据进行更新

                switch (dr["数据来源"].ToString())
                {
                    case "0":           //手工选择
                        break;
                    case "2":           //申请

                        if (itemManager.ApproveApplyIn(input) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.ShowMsg("申请核准失败" + itemManager.Err);
                            return;
                        }

                        break;
                    case "1":           //采购

                        #region 更新采购记录

                        Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan;
                        if (this.hsStockData.ContainsKey(input.StockNO))
                            stockPlan = this.hsStockData[input.StockNO] as Neusoft.HISFC.Models.Pharmacy.StockPlan;
                        else
                            continue;

                        if (NConvert.ToBoolean(dr["核准"]))
                        {
                            stockPlan.State = "3";
                        }
                        else
                        {
                            //输入数量小于核准数量 说明未核准完成  否则认为全部核准
                            if ((stockPlan.StockApproveQty - stockPlan.InQty) > input.Quantity)
                                stockPlan.State = "2";
                            else
                                stockPlan.State = "3";
                        }
                        //此处不对采购信息中生产厂家进行处理
                        stockPlan.InQty += input.Quantity;                          //实际入库量
                        stockPlan.InOper.ID = input.Operation.Oper.ID;              //入库人
                        stockPlan.InOper.OperTime = input.Operation.Oper.OperTime;  //入库日期
                        stockPlan.InListNO = inListNO;                              //入库单据号

                        if (itemManager.UpdateStockPlanForIn(stockPlan.ID,stockPlan.InQty,stockPlan.InListNO,stockPlan.InOper,stockPlan.State) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.ShowMsg("根据入库信息更新采购信息发生错误" + itemManager.Err);
                            return;
                        }

                        #endregion
                        break;
                }

                #endregion

                this.alPrintData.Add(input);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.ShowMsg("入库保存成功");

            DialogResult rs = MessageBox.Show(Language.Msg("是否打印入库单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Print();
            }

            this.Clear();

            string strErr = "";
            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("PHA", "InvoiceType", out strErr, input.InvoiceType);

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            if (this.phaInManager.IInPrint != null)
            {
                this.phaInManager.IInPrint.SetData(this.alPrintData, this.phaInManager.PrivType.Memo);
                this.phaInManager.IInPrint.Print();
            }

            return 1;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            //{9E282C1A-071F-4833-8AE3-EC64CA71FD8F} 增加对资源释放函数的调用
            this.phaInManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);
            return 1;
        }

        #endregion

        private void ucDetail_InInstanceCompleteEvent(ref Neusoft.FrameWork.Models.NeuObject msg)
        {
            Neusoft.HISFC.Models.Pharmacy.Input tempInput = this.ucDetail.InInstance.Clone();

            if (tempInput != null)
            {
                if (tempInput.Item.ID == "")
                {
                    return;
                }

                #region 判断是否存在供货公司

                if (this.phaInManager.TargetDept.ID == "")
                {
                    MessageBox.Show(Language.Msg("请选择供货单位"));

                    //通知ucDetail内 不处理焦点
                    if (msg == null)
                    {
                        msg = new Neusoft.FrameWork.Models.NeuObject();
                    }
                    msg.User01 = "-1";      //标志是否处理焦点

                    this.phaInManager.SetDeptFocus();
                    
                    return;
                }

                #endregion

                #region 是否判断此时选择的供货公司与药品基本信息维护的供货公司

                if (this.isJudgeDefaultCompany)
                {
                    if (tempInput.Item.Product.Company.ID != "" && this.phaInManager.TargetDept.ID != tempInput.Item.Product.Company.ID)
                    {
                        DialogResult rs = MessageBox.Show(Language.Msg("当前选择的供货单位与药品维护的默认供货单位不同 是否继续?"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                        if (rs == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                #endregion

                string key = tempInput.Item.ID + tempInput.BatchNO;

                #region 判断该药品信息是否存在 如果存在则删除原信息 重新赋值

                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                //有问题
                //if (this.privKey != "" && this.privKey.Substring(0, 12) != key.Substring(0, 12))
                //{
                //    this.privKey = "";
                //}
                ////无批号 删除原信息 重新添加 避免重复添加两次
                //if (this.privKey.Length == 12)          
                //{
                //    if (this.hsInputData.ContainsKey(this.privKey))
                //    {
                //        this.hsInputData.Remove(this.privKey);
                //        string[] keys = new string[] { this.privKey.Substring(0,12), "" };
                //        DataRow drFind = this.dt.Rows.Find(keys);
                //        if (drFind != null)
                //        {
                //            this.dt.Rows.Remove(drFind);
                //        }
                //    }
                //}
                //无批号 删除原信息 重新添加 避免重复添加两次
                if (this.privKey != "" && this.privKey != key)
                {
                    if (this.hsInputData.ContainsKey(this.privKey))
                    {
                        this.hsInputData.Remove(this.privKey);
                        string[] keys = new string[] { tempInput.Item.ID, this.privKey.Substring(12, this.privKey.Length - 12) };
                        DataRow drFind = this.dt.Rows.Find(keys);
                        if (drFind != null)
                        {
                            this.dt.Rows.Remove(drFind);
                        }
                    }
                }
                this.privKey = key;

                //对相同药品/批号 删除原数据 
                if (this.hsInputData.ContainsKey(key))
                {
                    this.hsInputData.Remove(key);
                    string[] keys = new string[]{tempInput.Item.ID,tempInput.BatchNO};
                    DataRow drFind = this.dt.Rows.Find(keys);
                    if (drFind != null)
                    {
                        this.dt.Rows.Remove(drFind);
                    }
                }

                #endregion

                #region 实体赋值

                tempInput.SpecialFlag = NConvert.ToInt32(this.isSpecialIn).ToString();  //是否特殊入库 0 否 1 是
                tempInput.StockDept = this.phaInManager.DeptInfo;                       //库存科室
                tempInput.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
                tempInput.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
                tempInput.Company = this.phaInManager.TargetDept;                       //供货单位 
                tempInput.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位

                if (msg.User02 == "1")
                {
                    tempInput.User01 = "0";                                             //数据来源 1 采购单 2 申请单 0 手工选择
                }
                #endregion

                if (this.AddDataToTable(tempInput) == 1)
                {
                    this.hsInputData.Add(key, tempInput);

                    this.SetFormat();

                    if (this.svTemp != null)
                    {
                        this.svTemp.ActiveRowIndex = this.svTemp.Rows.Count - 1;
                    }
                }

                this.CompuateSum();
            }
        }

        private void ucListSelect_StockSelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            //供货单位
            this.phaInManager.TargetDept = targetDept;
            //增加采购数据
            this.AddStockData(listCode, state);
        }

        private void phaInManager_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            return;
        }

        private void Fp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string[] keys = new string[]{
                                                this.svTemp.Cells[e.Row, (int)ColumnSet.ColDrugID].Text,
                                                this.svTemp.Cells[e.Row, (int)ColumnSet.ColBatchNO].Text
                                            };
            DataRow dr = this.dt.Rows.Find(keys);
            if (dr != null)
            {
                this.privKey = dr["药品编码"].ToString() + dr["批号"].ToString();

                Neusoft.HISFC.Models.Pharmacy.Input input = this.hsInputData[dr["药品编码"].ToString() + dr["批号"].ToString()] as Neusoft.HISFC.Models.Pharmacy.Input;

                this.ucDetail.InInstance = input.Clone();
            }
        }

        //清空主键
        //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
        public void ucDetail_ClearPriKey(ref Neusoft.FrameWork.Models.NeuObject sender)
        {
            this.privKey = "";
        }

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
            /// 送货单号
            /// </summary>
            ColDeliveryNO,
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 包装单位
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
            /// <summary>
            /// 入库数量
            /// </summary>
            ColInQty,
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
            /// 发票分类
            /// </summary>
            ColInvoiceType,
            /// <summary>
            /// 购入价
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 购入金额
            /// </summary>
            ColPurchaseCost,
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProducerName,
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugID,
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
            ColUserCode
        }
    }
}
