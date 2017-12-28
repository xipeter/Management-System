using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 出库退库业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <说明>
    ///     1、Output.User01 存储数据来源 0 手工选择 1 申请单  2 出库单 
    ///     2、Output.User02 存储申请单流水号/出库单流水号
    ///     3、Output.User03 存储主键值 
    ///     4、Operation.ApplyQty 存储申请量 Output.Quantity 存储实发量
    ///     5、对于数量为0的出库记录不显示
    ///     6、对于药房/药库申请流程 药房做入库申请 药库出库审批 此时只有药库出库记录 扣药库库存
    ///         药房核准入库 此时产生药房入库记录 加药房库存 同时更新药库出库记录信息
    /// 
    ///           再药房核准前 做出库退库 生成退库记录 原出库记录已退库数量更新 不产生药房入库记录
    ///           药房核准后 做出库退库 生成退库记录 原出库记录已退库数量更新 产生药房入库负记录 更新原入库记录已退库数量
    ///     7、药房待核准数据检索时 检索出库记录－已退库数量 > 0 的数据 其差额做为本次入库量(差额处理部分待实现)
    ///     8、调用申请进行退库 根据出库流水号检索出库退库记录时 应只取一条出库记录赋值显示 出库退库业务层函数内会取出
    ///        所有数据进行处理
    ///        如此处理 存在问题，即出库退库调出数据时的出库数量显示不正确(仅显示了第一条的出库数量)
    ///        是否允许退库 判断有问题
    ///        目前实现方式时针对每批次出库记录进行退库
    /// </说明>
    /// <待实现>
    ///     1、如果退库数量小于出库数量 则 对原出库记录全部退库 重新生成一条新数量的出库审批记录供核准入库使用
    ///     2、药房核准检索列表时 检索出库记录－已退库数量 > 0 的数据 其差额做为本次入库量(差额处理部分待实现)
    /// </待实现>
    /// </summary>
    public class BackOutPriv : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        public BackOutPriv(Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut phaOutManager = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.TextCellType tReadOnly = new FarPoint.Win.Spread.CellType.TextCellType();

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 出库审批数据
        /// </summary>
        private System.Collections.Hashtable hsOutData = new System.Collections.Hashtable();

        /// <summary>
        /// 申请信息
        /// </summary>
        private System.Collections.Hashtable hsApplyData = new Hashtable();

        /// <summary>
        /// 是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = false;

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucPhaListSelect ucListSelect = null;

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
                this.phaOutManager.IsShowInputPanel = false;
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 显示项目选择
                //this.phaOutManager.IsShowItemSelectpanel = false;
                //设置目标科室 目标人员信息
                this.phaOutManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                this.phaOutManager.SetTargetPerson(true, Neusoft.HISFC.Models.Base.EnumEmployeeType.P);
                //设置工具栏按钮显示
                this.phaOutManager.SetToolBarButton(true, false, true, false, true);
                this.phaOutManager.SetToolBarButtonVisible(true, false, true, false, true, true, false);
                //设置显示的待选择数据
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 设置待选择项目数据
                this.phaOutManager.SetSelectData("1", false, null, null, null);
                //设置显示信息
                this.phaOutManager.ShowInfo = "";

                this.phaOutManager.Fp.EditModeReplace = true;
                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaOutManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);
                this.phaOutManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);

                this.phaOutManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaOutManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);
               
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 添加事件处理
                this.phaOutManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);
                this.phaOutManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);

                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;
                this.SetFormat();

                this.phaOutManager.SetItemListWidth(2);
            }
        }

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Output output, decimal backQty)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal outQty = 0;             //申请数量
                decimal storeQty = 0;           //库存量
                decimal backCost = backQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                //允许出库数量
                output.Quantity = output.Quantity - output.Operation.ReturnQty;

                if (this.isUseMinUnit)
                {
                    outQty = output.Quantity;
                    storeQty = output.StoreQty;

                    output.RetailCost = outQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                    output.StoreCost = storeQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                }
                else
                {
                    outQty = output.Quantity / output.Item.PackQty;
                    storeQty = output.StoreQty / output.Item.PackQty;
                    backQty = backQty / output.Item.PackQty;

                    output.RetailCost = outQty * output.Item.PriceCollection.RetailPrice;
                    output.StoreCost = storeQty * output.Item.PriceCollection.RetailPrice;
                }

                this.dt.Rows.Add(new object[] { 
                                                true,
                                                output.Item.Name,                            //商品名称
                                                output.Item.Specs,                           //规格
                                                output.GroupNO,                              //批次
                                                output.BatchNO,                              //批号
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                storeQty,                                    //库存数量
                                                outQty,                                      //出库数量
                                                output.RetailCost,                           //出库金额
                                                backQty,                                     //退库数量
                                                backCost,                                    //退库金额                                                
                                                output.Memo,                                 //备注
                                                output.State,                                //状态
                                                output.Item.ID,                              //药品编码
                                                output.User02,                               //单据流水号
                                                output.User01,                               //数据来源 0 手工 1 申请 2 出库
                                                output.Item.NameCollection.SpellCode,        //拼音码
                                                output.Item.NameCollection.WBCode,           //五笔码
                                                output.Item.NameCollection.UserCode,         //自定义码
                                                output.User03                                //主键                            
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
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            return AddDataToTable(output, 0);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private void SetFormat()
        {
            this.tReadOnly.ReadOnly = true;

            this.phaOutManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Width = 40F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColReturnCost].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 100F;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Visible = false;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColGroupNO].Visible = false;          //批次
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColState].Visible = false;            //状态
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBillNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;              //主键

            if (this.isUseMinUnit)
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Locked = false;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].Locked = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].BackColor = System.Drawing.Color.SeaShell;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].BackColor = System.Drawing.Color.SeaShell;
        }

        /// <summary>
        /// 返回本张单据差额
        /// </summary>
        public virtual void CompuateSum()
        {
            decimal retailCost = 0;

            if (this.dt != null)
            {
                for (int i = 0; i < this.phaOutManager.FpSheetView.Rows.Count; i++)
                {
                    retailCost += NConvert.ToDecimal(this.phaOutManager.FpSheetView.Cells[i, (int)ColumnSet.ColReturnCost].Text);
                }

                this.phaOutManager.TotCostInfo = string.Format("退库金额:{0}", retailCost.ToString("N"));
            }
        }

        /// <summary>
        /// 增加申请数据
        /// </summary>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 </失败返回-1returns>
        protected virtual int AddApplyData(string listCode, string state)
        {
            this.Clear();

            ArrayList alDetail = this.itemManager.QueryApplyOutInfoByListCode(this.phaOutManager.TargetDept.ID, listCode, state);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alDetail)
            {
                //Neusoft.HISFC.Models.Pharmacy.Item tempItem = this.itemManager.GetItem(applyOut.Item.ID);
                //if (tempItem == null)
                //{
                //    ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();
                //    MessageBox.Show(Language.Msg("加载申请时 根据药品编码检索药品字典信息失败" + applyOut.Item.ID));
                //    return -1;
                //}

                this.phaOutManager.ShowInfo = string.Format("申请人:{0} 申请日期:{1}", applyOut.Operation.ApplyOper.ID, applyOut.Operation.ApplyOper.OperTime.ToString());

                ArrayList alOutput = this.itemManager.QueryOutputList(applyOut.OutBillNO);
                if (alOutput == null || alOutput.Count == 0)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();
                    MessageBox.Show(Language.Msg("根据出库流水号 " + applyOut.OutBillNO + " 无法找到出库记录"));
                    return -1;
                }
                //药品当前库存量
                decimal storeQty = 0;
                if (this.itemManager.GetStorageNum(this.phaOutManager.DeptInfo.ID, applyOut.Item.ID, out storeQty) == -1)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();
                    MessageBox.Show(Language.Msg("获取" + applyOut.Item.Name + "库存数量时发生错误" + this.itemManager.Err));
                    return -1;
                }
                //申请数据集合
                this.hsApplyData.Add(applyOut.ID, applyOut);

                decimal applyQty = applyOut.Operation.ApplyQty;
                decimal leftQty = applyOut.Operation.ApplyQty;
                //此处考虑只取一条出库记录进行赋值 出库退库函数内会对所有的出库记录进行退库处理
                //根据先进先出原则 
                //如此处理 存在问题，即出库退库调出数据时的出库数量显示不正确(仅显示了第一条的出库数量)
                //是否允许退库 判断有问题
                //Neusoft.HISFC.Models.Pharmacy.Output outputTemp = alOutput[0] as Neusoft.HISFC.Models.Pharmacy.Output;

                //outputTemp.StoreQty = storeQty;
                //outputTemp.User01 = "1";                                    //数据来源 申请
                //outputTemp.User02 = applyOut.ID;                            //申请单流水号
                //outputTemp.User03 = outputTemp.Item.ID + outputTemp.ID + outputTemp.SerialNO;                 //主键

                //if (this.AddDataToTable(outputTemp,applyQty) == 1)
                //{
                //    this.hsOutData.Add(this.GetKey(outputTemp), outputTemp);
                //}

                foreach (Neusoft.HISFC.Models.Pharmacy.Output output in alOutput)
                {
                    //出库数量为0的记录不进行处理 为0记录为原数据 不进行处理
                    if (output.Quantity == 0)
                    {
                        continue;
                    }
                    //出库记录已满足本次出库
                    if (leftQty == 0)
                    {
                        break;
                    }
                    if (output.Quantity >= leftQty)
                    {
                        applyQty = leftQty;
                        leftQty = 0;
                    }
                    else
                    {
                        applyQty = output.Quantity;
                        leftQty = leftQty - applyQty;
                    }

                    output.StoreQty = storeQty;                                 //库存量            

                    output.User01 = "1";                                        //数据来源 申请
                    output.User02 = applyOut.ID;                                //申请单流水号

                    output.User03 = output.Item.ID + output.ID + output.SerialNO;                 //主键

                    if (this.AddDataToTable(output, applyQty) == 1)
                    {
                        this.hsOutData.Add(this.GetKey(output), output);
                    }
                }
            }

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();

            //计算汇总出库金额
            this.CompuateSum();

            return 1;
        }

        /// <summary>
        /// 增加出库数据
        /// </summary>
        /// <param name="listCode"></param>
        /// <param name="state"></param>
        private void AddOutData(string listCode, string state)
        {
            this.Clear();

            ArrayList alDetail = this.itemManager.QueryOutputInfo(this.phaOutManager.DeptInfo.ID, listCode, state);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }

            if (state == "1" && alDetail.Count > 0)
            {
                MessageBox.Show(Language.Msg("审批状态的单据已扣减自身库存 未增加对方科室库存 \n\n此时退库 必须按原出库数据全额退库"), "出库退库操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在根据单号加载出库数据 请稍候..."));
            Application.DoEvents();

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Output output in alDetail)
            {
                //对出库数量为零的数据不显示
                if (output.Quantity == 0)
                {
                    continue;
                }

                decimal storeQty = 0;
                if (this.itemManager.GetStorageNum(this.phaOutManager.DeptInfo.ID, output.Item.ID, out storeQty) == -1)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();
                    Function.ShowMsg("获取库存数量时出错!" + this.itemManager.Err);
                    return;
                }
                output.StoreQty = storeQty;
                output.DrugedBillNO = "1";

                output.PrivType = this.phaOutManager.PrivType.ID;           //出库类型
                output.SystemType = this.phaOutManager.PrivType.Memo;       //系统类型
                output.StockDept = this.phaOutManager.DeptInfo;             //当前科室
                output.TargetDept = this.phaOutManager.TargetDept;          //目标科室 

                output.User01 = "2";                                        //数据来源 出库单

                output.User03 = output.Item.ID + output.ID + output.SerialNO;                 //主键

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(this.GetKey(output), output);
                }
            }

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //计算汇总出库金额
            this.CompuateSum();
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            return output.User03;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["主键"].ToString();
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="iRowIndex"></param>
        /// <returns></returns>
        private string GetKey(FarPoint.Win.Spread.SheetView sv, int iRowIndex)
        {
            return sv.Cells[iRowIndex, (int)ColumnSet.ColKey].Text;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="iRowIndex"></param>
        /// <returns></returns>
        private string[] GetFindKey(FarPoint.Win.Spread.SheetView sv, int iRowIndex)
        {
            return new string[] { sv.Cells[iRowIndex, (int)ColumnSet.ColKey].Text };
        }

        #region IPhaInManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                return null;
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
                                                                    new DataColumn("审批",      dtBol),
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("批次",      dtStr),
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("库存数量",  dtDec),
                                                                    new DataColumn("出库数量",  dtDec),
                                                                    new DataColumn("出库金额",  dtDec),
                                                                    new DataColumn("退库数量",  dtDec),
                                                                    new DataColumn("退库金额",  dtDec),
                                                                    new DataColumn("备注",      dtStr),    
                                                                    new DataColumn("状态",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("流水号",    dtStr),
                                                                    new DataColumn("数据来源",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr),
                                                                    new DataColumn("主键",      dtStr)
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
        /// 增加数据处理
        /// {1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F}
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugNO = sv.Cells[activeRow, 0].Text;
            string batchNO = sv.Cells[activeRow, 3].Text;
            decimal storeQty = NConvert.ToDecimal(sv.Cells[activeRow, 5].Text);

            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(drugNO);
            if (item == null)
            {
                MessageBox.Show(Language.Msg("根据药品编码获取药品信息实体发生错误 ") + this.itemManager.Err);
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Output output = new Neusoft.HISFC.Models.Pharmacy.Output();
            output.Item = item;
            output.State = "2";
            output.User01 = "0";    //数据来源 0 手工 1 申请 2 出库
            output.User03 = output.Item.ID + output.ID + output.SerialNO;                 //主键

            output.DrugedBillNO = "1";

            output.PrivType = this.phaOutManager.PrivType.ID;           //出库类型
            output.SystemType = this.phaOutManager.PrivType.Memo;       //系统类型
            output.StockDept = this.phaOutManager.DeptInfo;             //当前科室
            output.TargetDept = this.phaOutManager.TargetDept;          //目标科室


            output.StoreQty = storeQty * item.PackQty;
            #region {CAD2CB10-14FE-472c-A7D7-9BAA5061730C}
            if (this.hsOutData.Contains(this.GetKey(output)))
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return 0;
            }          
            #endregion  
            if (this.AddDataToTable(output) == 1)
            {
                this.hsOutData.Add(this.GetKey(output), output);
            }

            return 1;
        }

        public int ShowApplyList()
        {
            //获取出库退库信息
            ArrayList alAllList = this.itemManager.QueryApplyOutListByTargetDept(this.phaOutManager.DeptInfo.ID, "18", "0");
            if (alAllList == null)
            {
                MessageBox.Show(Language.Msg("获取出库申请列表发生错误" + this.itemManager.Err));
                return -1;
            }

            #region 根据目标单位过滤

            ArrayList alList = new ArrayList();
            if (this.phaOutManager.TargetDept.ID != "")
            {
                foreach (Neusoft.FrameWork.Models.NeuObject info in alAllList)
                {
                    if (info.Memo != this.phaOutManager.TargetDept.ID)
                    {
                        continue;
                    }
                    alList.Add(info);
                }
            }
            else
            {
                alList = alAllList;
            }

            #endregion

            //弹出窗口选择单据
            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] fpLabel = { "申请单号", "申请科室" };
            int[] fpWidth = { 120, 120 };
            bool[] fpVisible = { true, true, false, false, false, false };

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, fpLabel, fpVisible, fpWidth, ref selectObj) == 1)
            {
                this.Clear();

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                targeDept.ID = selectObj.Memo;              //申请科室编码
                targeDept.Name = selectObj.Name;            //申请科室名称
                targeDept.Memo = "0";                       //目标单位性质 内部科室               

                this.AddApplyData(selectObj.ID, "0");

                this.SetFocusSelect();
            }

            return 1;
        }

        public int ShowInList()
        {
            return 1;
        }

        public int ShowOutList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucPhaListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.phaOutManager.DeptInfo;

                System.Collections.Hashtable hsInOutState = new Hashtable();
                hsInOutState.Add("1", "审批");
                hsInOutState.Add("2", "核准");
                this.ucListSelect.InOutStateCollection = hsInOutState;
                System.Collections.Hashtable hsMarkPriv = new Hashtable();
                hsMarkPriv.Add(this.phaOutManager.PrivType.ID, null);
                this.ucListSelect.MarkPrivType = hsMarkPriv;

                this.ucListSelect.State = "2";                  //需检索状态
                this.ucListSelect.Class2Priv = "0320";          //出库

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

        public int ShowStockList()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ImportData()
        {
            return 1;
        }

        public bool Valid()
        {
            foreach (DataRow dr in this.dt.Rows)
            {
                //对退库数量为0的不进行判断
                if (NConvert.ToDecimal(dr["退库数量"]) == 0)
                {
                    continue;
                }
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 对手工添加数据不进行判断
                if (dr["数据来源"].ToString() == "0")
                {
                    continue;
                }

                if (NConvert.ToDecimal(dr["出库数量"]) < NConvert.ToDecimal(dr["退库数量"]))
                {
                    MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + " 退库数量不能大于出库数量"));
                    return false;
                }
                if (dr["状态"].ToString() == "1")       //审批状态的单
                {
                    if (NConvert.ToDecimal(dr["出库数量"]) != NConvert.ToDecimal(dr["退库数量"]))
                    {
                        MessageBox.Show(Language.Msg("本单未经对方核准 退库时 " + dr["商品名称"].ToString() + " 的退库数量只能为出库数量"), "出库退库操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dr["退库数量"] = dr["出库数量"];
                        return false;
                    }
                }
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

                    DataRow dr = this.dt.Rows.Find(this.GetFindKey(sv, delRowIndex));
                    if (dr != null)
                    {
                        this.phaOutManager.Fp.StopCellEditing();

                        if (dr["数据来源"].ToString() == "1")
                        {
                            Neusoft.HISFC.Models.Pharmacy.Output delOutput = this.hsOutData[this.GetKey(dr)] as Neusoft.HISFC.Models.Pharmacy.Output;
                            if (this.hsApplyData.ContainsKey(delOutput.User02))
                            {
                                this.hsApplyData.Remove(delOutput.User02);
                            }
                        }

                        this.hsOutData.Remove(this.GetKey(dr));

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
                //清除申请信息
                this.hsApplyData.Clear();

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
                    this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColReturnQty;
                }
                else
                {
                    this.phaOutManager.SetFocus();
                }
            }
        }

        public void Save()
        {
            if (this.phaOutManager.TargetDept.ID == "")
            {
                MessageBox.Show(Language.Msg("请设置退库目标科室"));
                return;
            }

            #region 有效性判断

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

            #endregion

            DialogResult rs = MessageBox.Show(Language.Msg("确认向" + this.phaOutManager.TargetDept.Name + "进行出库退库操作吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
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

            //是否进行了保存操作
            bool isSaved = false;
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();
            //判断领用科室是否管理库存
            string outListNO = "";
            bool isManagerStore = phaCons.IsManageStore(this.phaOutManager.TargetDept.ID);

            //是否处理领用科室(退库科室)入库记录
            bool isManagerInput = true;

            this.alPrintData = new ArrayList();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                //对退库数量为零的不进行退库处理
                if (NConvert.ToDecimal(dr["退库数量"]) == 0)
                {
                    continue;
                }

                //{DCE152D1-295C-4cc6-9EAA-39321A234569}  对于HashTable内的数据进行Clone处理。避免以下函数更改了原始数据
                Neusoft.HISFC.Models.Pharmacy.Output output = (this.hsOutData[this.GetKey(dr)] as Neusoft.HISFC.Models.Pharmacy.Output).Clone();
                //Neusoft.HISFC.Models.Pharmacy.Output output = this.hsOutData[this.GetKey(dr)] as Neusoft.HISFC.Models.Pharmacy.Output;
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 对手工添加数据不进行判断
                if (dr["数据来源"].ToString() != "0" && output.Quantity == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(Language.Msg("该条出库数据已全部进行了退库 请选择其他信息进行退库"));
                    return;
                }

                isSaved = true;

                if (this.isUseMinUnit)       //最小单位
                    output.Quantity = -NConvert.ToDecimal(dr["退库数量"]);
                else
                    output.Quantity = -NConvert.ToDecimal(dr["退库数量"]) * output.Item.PackQty;

                //是否处理领药科室入库记录 
                if (output.State == "2")    //对核准记录的出库退库
                {
                    isManagerInput = isManagerStore;        //是否处理退库 根据是否管理库存判断
                }
                else                       //对审批记录的出库退库
                {
                    isManagerInput = false;                 //此时还没有领药科室的入库记录 直接退自身
                }
                //对管理库存的科室且出库记录状态为"2" 的才进行库存判断
                if (isManagerStore && output.State == "2")         //对管理库存的目标科室判断是否存在库存
                {
                    #region 获取目标科室本批次当前库存 判断是否允许退库

                    decimal storeQty = 0;
                    this.itemManager.GetStorageNum(this.phaOutManager.TargetDept.ID, output.Item.ID, output.GroupNO, out storeQty);
                    if (storeQty < System.Math.Abs(output.Quantity))
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(Language.Msg(string.Format("{0} 在 {1}中库存数量不足 不能退库", output.Item.Name, this.phaOutManager.TargetDept.Name)));
                        return;
                    }

                    #endregion
                }

                //审批信息
                output.Operation.ExamQty = output.Quantity;
                output.Operation.ExamOper.ID = this.phaOutManager.OperInfo.ID;
                output.Operation.ExamOper.OperTime = sysTime;

                //权限信息 出库退库类型
                output.PrivType = this.phaOutManager.PrivType.ID;
                output.SystemType = this.phaOutManager.PrivType.Memo;

                if (isManagerStore)
                    output.State = "1";     //状态变更为审批
                else
                    output.State = "2";     //状态变更为核准

                //根据不同数据来源对数据进行不同处理
                switch (dr["数据来源"].ToString())
                {
                    case "1":               //内部入库退库申请

                        #region 申请单

                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[output.User02] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                        if (outListNO == "")
                            outListNO = applyOut.BillNO;

                        applyOut.State = "2";
                        applyOut.Operation.ExamOper = output.Operation.ExamOper;
                        if (this.itemManager.UpdateApplyOut(applyOut) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("更新" + output.Item.Name + "入库退库申请信息出错");
                            return;
                        }

                        break;
                        #endregion

                    case "2":               //出库单
                    case "0":               //手工选择 //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 与出库申请进行相同类型处理

                        #region 出库单

                        if (outListNO == "")
                        {
                            // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                            outListNO = phaIntegrate.GetInOutListNO(this.phaOutManager.DeptInfo.ID, false);
                            if (outListNO == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                Function.ShowMsg("获取最新出库单据号出错" + this.itemManager.Err);
                                return;
                            }
                        }
                        break;

                        #endregion
                }

                output.OutListNO = outListNO;       //出库单据号
                //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F} 对于手工选择的数据进行单独处理
                if (dr["数据来源"].ToString() == "0")
                {
                    if (this.itemManager.OutputReturnForSingleDrug(output.Clone(), -output.Quantity, this.phaOutManager.TargetDept, this.phaOutManager.IsTargetArk, this.phaOutManager.DeptInfo, this.phaOutManager.IsStockArk) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("保存" + output.Item.Name + "出库退库信息时发生错误" + this.itemManager.Err);
                        return;
                    }
                }
                else
                {
                    //非药柜科室向药柜出库 进行特殊处理
                    if (!this.phaOutManager.IsStockArk && this.phaOutManager.IsTargetArk)
                    {
                        if (this.itemManager.ArkOutputReturn(output.Clone(), output.ID, isManagerInput) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("保存" + output.Item.Name + "出库退库信息时发生错误" + this.itemManager.Err);
                            return;
                        }
                    }
                    else
                    {
                        if (this.itemManager.OutputReturn(output.Clone(), output.ID, output.SerialNO, isManagerInput) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("保存" + output.Item.Name + "出库退库信息时发生错误" + this.itemManager.Err);
                            return;
                        }
                    }
                }

                this.alPrintData.Add(output);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isSaved)
            {
                Function.ShowMsg("保存成功");

                DialogResult rsPrint = MessageBox.Show(Language.Msg("是否打印退库单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsPrint == DialogResult.Yes)
                {
                    this.Print();
                }

                this.Clear();
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
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

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            this.phaOutManager.TargetDept = targetDept;

            this.Clear();

            this.AddOutData(listCode, state);
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            //if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColReturnQty)
            //{
            //    DataRow dr = this.dt.Rows.Find(this.GetFindKey(this.phaOutManager.FpSheetView,this.phaOutManager.FpSheetView.ActiveRowIndex));
            //    if (dr != null)
            //    {
            //        dr["退库金额"] = NConvert.ToDecimal(dr["退库数量"]) * NConvert.ToDecimal(dr["零售价"]);

            //        dr.EndEdit();

            //        this.CompuateSum();
            //    }
            //}
        }

        private void phaManager_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.phaOutManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColReturnQty)
                    {
                        decimal returnQty = NConvert.ToDecimal(this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColReturnQty].Text);
                        decimal price = NConvert.ToDecimal(this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColRetailPrice].Text);
                        decimal returnCost = returnQty * price;

                        this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColReturnCost].Value = returnCost;

                        this.CompuateSum();
                    }

                    if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColReturnQty)
                    {
                        if (this.phaOutManager.FpSheetView.ActiveRowIndex == this.phaOutManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaOutManager.SetFocus();
                        }
                        else
                        {
                            this.phaOutManager.FpSheetView.ActiveRowIndex++;
                            this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColReturnQty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 目标单位变化时 项目选择列表进行相应处理
        /// //{1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F}
        /// </summary>
        /// <param name="changeData"></param>
        /// <param name="param"></param>
        private void phaOutManager_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.phaOutManager.SetSelectData("1", false, null, null, null);
        }

        private enum ColumnSet
        {
            /// <summary>
            /// 审批
            /// </summary>
            ColIsExam,
            /// <summary>
            /// 商品名称	
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格		
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 批次
            /// </summary>
            ColGroupNO,
            /// <summary>
            /// 批号
            /// </summary>
            ColBatchNO,
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
            /// 退库数量	
            /// </summary>
            ColReturnQty,
            /// <summary>
            /// 退库金额	
            /// </summary>
            ColReturnCost,
            /// 备注		
            /// </summary>
            ColMemo,
            /// <summary>
            /// 状态
            /// </summary>
            ColState,
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugNO,
            /// <summary>
            /// 单据流水号
            /// </summary>
            ColBillNO,
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
            ColKey
        }
    }
}
