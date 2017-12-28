using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Components.Common.Controls;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 入库申请类型]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// <修改记录>
    ///   1、修改双击修改药品时重新选择药品后保存不上而直接覆盖的问题 by Sunjh 2010-8-23 {9EEBBBFA-AB66-41aa-A9DB-0E48FF995EFB}
    ///   2、增加直接删除外部入库申请功能 by Sunjh 2010-8-23 {EB33BF6F-D122-4330-8D89-BB8695DD5A48}
    /// </修改记录>
    /// </summary>
    public class OuterApplyPriv : IPhaInManager
    {
        public OuterApplyPriv(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.SetPhaManagerProperty(ucPhaManager);
            }
        }

        #region 域变量

        private ucPhaIn phaInManager = null;

        private FarPoint.Win.Spread.SheetView svTemp = null;

        private DataTable dt = null;

        ucCommonInDetail ucDetail = null;

        /// <summary>
        /// 入库数据
        /// </summary>
        private System.Collections.Hashtable hsInputData = new System.Collections.Hashtable();

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

                    this.phaInManager.TargetDept = new Neusoft.FrameWork.Models.NeuObject();

                    //设置工具栏按钮显示
                    this.phaInManager.SetToolBarButtonVisible(true, false, false, true, true, true, true);
                }
                else
                {
                    this.phaInManager.SetTargetDept(false, true, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

                    this.phaInManager.TargetDept = new Neusoft.FrameWork.Models.NeuObject();

                    //设置工具栏按钮显示
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

            //打开窗口日期
            this.sysTime = ctrlManager.GetDateTimeFromSysDateTime().Date;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="item"></param>
        /// <param name="dataSource">数据来源 1 采购单 2 申请单 0 手工选择</param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Pharmacy.Input ConvertToInput(Neusoft.HISFC.Models.Pharmacy.Item item, string dataSource)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

            input.Item = item;

            #region 实体赋值

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

                #region {D071715E-B5DB-4e7e-A060-069B08F62508}
                //this.dt.Rows.Add(new object[] { 
               //                                 true,
               //                                 input.DeliveryNO,                           //送货单号
               //                                 input.Item.Name,                            //商品名称
               //                                 input.Item.Specs,                           //规格
               //                                 input.Item.PriceCollection.RetailPrice,     //零售价
               //                                 input.Item.PackUnit,                        //包装单位
               //                                 input.Item.PackQty,                         //包装数量
               //                                 input.Quantity / input.Item.PackQty,        //入库数量
               //                                 input.RetailCost,                           //入库金额
               //                                 input.BatchNO,                              //批号
               //                                 input.ValidTime,                            //有效期
               //                                 input.InvoiceNO,                            //发票号
               //                                 input.InvoiceType,                          //发票类别
               //                                 input.Item.PriceCollection.PurchasePrice,   //购入价
               //                                 input.PurchaseCost,                         //购入金额
               //                                 input.Item.Product.Producer.Name,           //生产厂家
               //                                 input.Item.ID,                              //药品编码
               //                                 input.ID,                                   //流水号
               //                                 input.Item.NameCollection.SpellCode,        //拼音码
               //                                 input.Item.NameCollection.WBCode,           //五笔码
               //                                 input.Item.NameCollection.UserCode          //自定义码
                            
               //                            }
               //                 );

                DataRow row = this.dt.NewRow();
                row[0]=true;
                row[1]=input.DeliveryNO;                           //送货单号
                row[2]=input.Item.Name;                            //商品名称
                row[3]=input.Item.Specs;                           //规格
                row[4]=input.Item.PriceCollection.RetailPrice;     //零售价
                row[5]=input.Item.PackUnit;                        //包装单位
                row[6]=input.Item.PackQty;                         //包装数量
                row[7]=input.Quantity / input.Item.PackQty;        //入库数量
                row[8]=input.RetailCost;                           //入库金额
                row[9]=input.BatchNO;                              //批号
                row[10]=input.ValidTime;                            //有效期
                row[11]=input.InvoiceNO;                            //发票号
                row[12]=input.InvoiceType;                          //发票类别
                row[13]=input.Item.PriceCollection.PurchasePrice;   //购入价
                row[14]=input.PurchaseCost;                         //购入金额
                row[15]=input.Item.Product.Producer.Name;           //生产厂家
                row[16]=input.Item.ID;                              //药品编码
                row[17]=input.ID;                                   //流水号
                row[18]=input.Item.NameCollection.SpellCode;        //拼音码
                row[19]=input.Item.NameCollection.WBCode;           //五笔码
                row[20]=input.Item.NameCollection.UserCode;          //自定义码
                this.dt.Rows.InsertAt(row, 0);

                #endregion

                
                
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

            this.svTemp.Columns[(int)ColumnSet.ColValidTime].Visible = false;        //有效期
            this.svTemp.Columns[(int)ColumnSet.ColInvoiceType].Visible = false;      //发票分类
            this.svTemp.Columns[(int)ColumnSet.ColProducerName].Visible = false;     //生产厂家
            this.svTemp.Columns[(int)ColumnSet.ColDrugID].Visible = false;           //药品编码
            this.svTemp.Columns[(int)ColumnSet.ColInBillNO].Visible = false;         //流水号
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
        protected virtual int AddApplyData(string listCode, string state)
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

                input.Item = tempItem;                               //药品实体信息
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

            this.SetFormat();

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
            return 1;
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <returns></returns>
        public int ImportData()
        {           
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

                        //增加直接删除外部入库申请功能 by Sunjh 2010-8-23 {EB33BF6F-D122-4330-8D89-BB8695DD5A48}
                        if (MessageBox.Show("是否删除当前申请信息，是则直接提交保存", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                            if (itemManager.DeleteApplyIn(input.ID) == -1)
                            {
                                MessageBox.Show("删除失败!");
                            }
                        }
                        else
                        {
                            return -1;
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

            this.dt.DefaultView.RowFilter = filter;

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

            //当天操作日期
            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();
            //入库单据号
            string inListNO = null;

            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();
            foreach (DataRow dr in this.dt.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();

                input = this.hsInputData[key] as Neusoft.HISFC.Models.Pharmacy.Input;

                if (inListNO == null)
                    inListNO = input.InListNO;

                #region 如果不存在入库单据号 则获取新入库单据号

                if (inListNO == "" || inListNO == null)
                {
                    // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
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

                input.StockDept = this.phaInManager.DeptInfo;                       //库存科室
                input.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
                input.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
                input.Company = this.phaInManager.TargetDept;                       //供货单位 
                input.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位

                #endregion

                if (input.Operation.ApplyOper.ID == "")
                {
                    input.Operation.ApplyQty = input.Quantity;                          //入库申请量
                    input.Operation.ApplyOper.ID = this.phaInManager.OperInfo.ID;
                    input.Operation.ApplyOper.OperTime = sysTime;
                }

                input.Operation.Oper.ID = this.phaInManager.OperInfo.ID;
                input.Operation.Oper.OperTime = sysTime;
                input.Operation.ApplyQty = input.Quantity;                          //入库申请量

                input.State = "0";

                if (itemManager.SetApplyIn(input) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.ShowMsg("入库 保存失败" + itemManager.Err);
                    return;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.ShowMsg("外部入库申请保存成功");

            this.Clear();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            return 1;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
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
                        DialogResult rs = MessageBox.Show(Language.Msg("当前选择的供货单位与药品维护的默认供货单位不同 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (rs == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                #endregion

                string key = tempInput.Item.ID + tempInput.BatchNO;

                #region 判断该药品信息是否存在 如果存在则删除原信息 重新赋值

                if (this.privKey != "" && this.privKey.Substring(0, 12) != key.Substring(0, 12))
                {
                    this.privKey = "";                    
                }

                if (!this.hsInputData.ContainsKey(this.privKey))
                {
                    tempInput.ID = "";//修改双击修改药品时重新选择药品后保存不上而直接覆盖的问题 by Sunjh 2010-8-23 {9EEBBBFA-AB66-41aa-A9DB-0E48FF995EFB}
                }

                //无批号 删除原信息 重新添加 避免重复添加两次
                if (this.privKey.Length == 12)
                {
                    if (this.hsInputData.ContainsKey(this.privKey))
                    {
                        this.hsInputData.Remove(this.privKey);
                        string[] keys = new string[] { this.privKey.Substring(0, 12), "" };
                        DataRow drFind = this.dt.Rows.Find(keys);
                        if (drFind != null)
                        {
                            this.dt.Rows.Remove(drFind);
                        }
                    }
                }
                //对相同药品/批号 删除原数据 
                if (this.hsInputData.ContainsKey(key))
                {
                    this.hsInputData.Remove(key);
                    string[] keys = new string[] { tempInput.Item.ID, tempInput.BatchNO };
                    DataRow drFind = this.dt.Rows.Find(keys);
                    if (drFind != null)
                    {
                        this.dt.Rows.Remove(drFind);
                    }
                }

                #endregion

                #region 实体赋值

                tempInput.StockDept = this.phaInManager.DeptInfo;                       //库存科室
                tempInput.PrivType = this.phaInManager.PrivType.ID;                     //用户类型
                tempInput.SystemType = this.phaInManager.PrivType.Memo;                 //系统类型
                tempInput.Company = this.phaInManager.TargetDept;                       //供货单位 
                tempInput.TargetDept = this.phaInManager.TargetDept;                    //目标单位 = 供货单位

                #endregion

                if (this.AddDataToTable(tempInput) == 1)
                {
                    this.hsInputData.Add(key, tempInput);

                    this.SetFormat();

                    if (this.svTemp != null)
                    {
                        #region {D071715E-B5DB-4e7e-A060-069B08F62508}

                        this.svTemp.ActiveRowIndex = 0; 

                        #endregion
                    }
                }

                this.CompuateSum();
            }
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
