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
    /// [功能描述: 出库审批业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <说明>
    ///     1、Output.User01 存储数据来源 0 手工选择药品 1 申请单  Output.User02 存储申请单流水号
    ///     2、 Operation.ApplyQty 存储申请量 Output.Quantity 存储实发量
    ///     3、根据属性 判断数量是否使用最小单位
    /// </说明>
    /// </summary>
    public class ExamOutPriv : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        public ExamOutPriv(Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
        }

        private event System.EventHandler OnExpand;

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut phaOutManager = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();

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

        private bool isUseMinUnit = false;

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 日消耗 参考天数
        /// </summary>
        private int intervalDays = 7;

        /// <summary>
        /// 对于库存不足时是否显示警戒色
        /// </summary>
        private bool isWarnColor = false;

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
                this.phaOutManager.IsShowItemSelectpanel = true;
                //设置目标科室 目标人员信息
                this.phaOutManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                this.phaOutManager.SetTargetPerson(true, Neusoft.HISFC.Models.Base.EnumEmployeeType.P);
                //设置工具栏按钮显示
                this.OnExpand += new EventHandler(ExamOutPriv_OnExpand);
                this.phaOutManager.SetToolBarButton(true, false, false, false, true);
                this.phaOutManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);

                this.phaOutManager.AddToolBarButton("日消耗", "", 0, true, false, this.ExamOutPriv_OnExpand);

                System.EventHandler PrePrintHandler = new EventHandler(PrePrint);
                this.phaOutManager.AddToolBarButton("打印", "对出库单进行预打印", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, 11, true, PrePrintHandler);
                //设置显示的待选择数据
                this.phaOutManager.SetSelectData("2", Function.IsOutByBatchNO, null, null, null);
                //设置显示信息
                this.phaOutManager.ShowInfo = "";

                this.phaOutManager.Fp.EditModePermanent = false;
                this.phaOutManager.Fp.EditModeReplace = true;
                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaOutManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);
                this.phaOutManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);

                this.phaOutManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaOutManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.phaOutManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);
                this.phaOutManager.Fp.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

                this.phaOutManager.FpSheetView.DataAutoCellTypes = false;
                this.SetFormat();

                this.InitConfig();

                this.phaOutManager.SetItemListWidth(2);
            }
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        private void InitConfig()
        {
            HISFC.Components.Pharmacy.Function fun = new Function();
            System.Xml.XmlDocument doc = fun.GetConfig();

            if (doc != null)
            {
                System.Xml.XmlNode valueNode = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='ExamOut']");
                if (valueNode != null)
                {
                    this.isWarnColor = NConvert.ToBoolean(valueNode.Attributes["IsWarnColor"].Value);
                }
            }
        }

        void ExamOutPriv_OnExpand(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            if (!Function.JudgePriceConsinstency(this.phaOutManager.DeptInfo.ID, output.Item))
            {
                MessageBox.Show(Language.Msg("该药品已经经过科室调价！不能直接进行出库。如需出库请先进行全院调价"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal applyQty = 0;           //申请数量
                decimal examQty = 0;            //实发数量
                decimal storeQty = 0;           //库存量

                decimal examCost;
                if (this.isUseMinUnit)
                {
                    applyQty = output.Operation.ApplyQty;
                    examQty = output.Operation.ExamQty;
                    storeQty = output.StoreQty;

                    output.RetailCost = applyQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                    output.StoreCost = storeQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                    examCost = examQty / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;
                }
                else
                {
                    applyQty = System.Math.Round(output.Operation.ApplyQty / output.Item.PackQty,2);
                    examQty = System.Math.Round(output.Operation.ExamQty / output.Item.PackQty,2);
                    storeQty = System.Math.Round(output.StoreQty / output.Item.PackQty,2);

                    output.RetailCost = applyQty  * output.Item.PriceCollection.RetailPrice;
                    output.StoreCost = storeQty  * output.Item.PriceCollection.RetailPrice;
                    examCost = examQty  * output.Item.PriceCollection.RetailPrice;
                }

                this.dt.Rows.Add(new object[] { 
                                                true,
                                                output.Item.Name,                            //商品名称
                                                output.Item.Specs,                           //规格
                                                output.BatchNO,                              //批号
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                storeQty,                                    //库存数量
                                                applyQty,                                    //申请数量
                                                output.RetailCost,                           //申请金额
                                                examQty,                                     //实发数量
                                                examCost,                                    //实发金额
                                                output.Operation.ApplyOper.ID,               //申请人
                                                output.Operation.ApplyOper.OperTime,         //申请日期
                                                output.Memo,                                 //备注
                                                output.Item.ID,                              //药品编码
                                                output.User02,                               //单据流水号
                                                output.User01,                               //数据来源 0 手工 1 申请
                                                output.Item.NameCollection.SpellCode,        //拼音码
                                                output.Item.NameCollection.WBCode,           //五笔码
                                                output.Item.NameCollection.UserCode          //自定义码
                            
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
        /// 格式化
        /// </summary>
        private void SetFormat()
        {
            this.phaOutManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Width = 40F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColExamQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColExamCost].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 40F;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = Function.IsOutByBatchNO;          //批号
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyOper].Visible = false;        //申请人
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyDate].Visible = false;        //申请日期
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBillNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            if (this.isUseMinUnit)
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Locked = false;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColExamQty].Locked = false;

            this.numCellType.DecimalPlaces = 2;
            this.numCellType.MinimumValue = 0;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColExamQty].CellType = this.numCellType;

            FarPoint.Win.Spread.CellType.CheckBoxCellType ckCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].CellType = ckCellType;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColExamQty].BackColor = System.Drawing.Color.SeaShell;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].BackColor = System.Drawing.Color.SeaShell;

            this.SetFpFlag();
        }

        /// <summary>
        /// 设置警戒线颜色显示
        /// </summary>
        private void SetFpFlag()
        {
            if (this.isWarnColor)
            {
                decimal storeQty = 0;
                decimal applyQty = 0;
                for (int i = 0; i < this.phaOutManager.FpSheetView.Rows.Count; i++)
                {
                    storeQty = NConvert.ToDecimal(this.phaOutManager.FpSheetView.Cells[i, (int)ColumnSet.ColStoreQty].Text);
                    applyQty = NConvert.ToDecimal(this.phaOutManager.FpSheetView.Cells[i, (int)ColumnSet.ColApplyQty].Text);

                    if (storeQty < applyQty)
                    {
                        this.phaOutManager.FpSheetView.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.phaOutManager.FpSheetView.Rows[i].ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
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
                    retailCost += NConvert.ToDecimal(dr["实发数量"]) * NConvert.ToDecimal(dr["零售价"]);
                }
                this.phaOutManager.TotCostInfo = string.Format("实发金额:{0}", retailCost.ToString("N"));
            }
        }

        /// <summary>
        /// 增加申请数据
        /// </summary>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 失败返回-1</returns>
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

            int i = 0;

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alDetail)
            {
                Neusoft.HISFC.Models.Pharmacy.Output output = new Neusoft.HISFC.Models.Pharmacy.Output();
                //药品实体信息
                output.Item = this.itemManager.GetItem(applyOut.Item.ID);
                if (output.Item == null)
                {
                    MessageBox.Show(Language.Msg("加载申请时 根据药品编码检索药品字典信息失败" + applyOut.Item.ID));
                    return -1;
                }

                if (i == 0)
                {
                    Neusoft.HISFC.BizProcess.Integrate.Manager manageIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    Neusoft.HISFC.Models.Base.Employee person = manageIntegrate.GetEmployeeInfo( applyOut.Operation.ApplyOper.ID );
                    if (person != null)
                    {
                        this.phaOutManager.ShowInfo = string.Format( "申请人:{0} 申请日期:{1}", person.Name, applyOut.Operation.ApplyOper.OperTime.ToString() );
                    }

                    i++;
                }

                output.Operation.ApplyOper = applyOut.Operation.Oper;
                output.Operation.ApplyQty = applyOut.Operation.ApplyQty;   //申请量
                output.Memo = applyOut.Memo;                               //备注信息

                decimal storeQty = 0;
                if (this.itemManager.GetStorageNum(this.phaOutManager.DeptInfo.ID, applyOut.Item.ID, out storeQty) == -1)
                {
                    MessageBox.Show(Language.Msg("获取" + applyOut.Item.Name + "库存数量时发生错误" + this.itemManager.Err));
                    return -1;
                }
                output.StoreQty = storeQty;                     //库存量

                output.PrivType = this.phaOutManager.PrivType.ID;               //出库类型
                output.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型
                output.StockDept = this.phaOutManager.DeptInfo;                 //当前科室
                output.TargetDept = this.phaOutManager.TargetDept;              //目标科室     

                if (applyOut.Operation.ApproveQty == 0)
                {
                    output.Operation.ExamQty = output.Operation.ApplyQty;
                }
                else
                {
                    //output.Operation.ExamQty = applyOut.Operation.ApproveQty;
                    output.Operation.ExamQty = output.Operation.ApplyQty - applyOut.Operation.ApproveQty;
                    if (output.Operation.ExamQty <= 0)                    
                    {
                        output.Operation.ExamQty = 0;
                    }
                }

                output.User01 = "1";                            //数据来源 申请
                output.User02 = applyOut.ID;                    //申请单流水号

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(output.Item.ID + output.BatchNO, output);

                    this.hsApplyData.Add(applyOut.ID, applyOut.Clone());
                }
            }

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();

            //计算汇总出库金额
            this.CompuateSum();

            return 1;
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
                MessageBox.Show(Language.Msg("请选择领药单位!"),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

            if (this.itemManager.GetStorageNum(this.phaOutManager.DeptInfo.ID, item.ID, out storageQty) == -1)
            {
                MessageBox.Show(Language.Msg("根据药品编码获取药品库存信息时发生错误" + this.itemManager.Err));
                return -1;
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
        /// 日消耗
        /// </summary>
        private void Expand()
        {
            if (this.phaOutManager.FpSheetView.Rows.Count <= 0)
                return;

            int iRow = this.phaOutManager.FpSheetView.ActiveRowIndex;

            Neusoft.FrameWork.Models.NeuObject drug = new Neusoft.FrameWork.Models.NeuObject();

            drug.ID = this.phaOutManager.FpSheetView.Cells[iRow, (int)ColumnSet.ColDrugNO].Text;
            drug.Name = this.phaOutManager.FpSheetView.Cells[iRow, (int)ColumnSet.ColTradeName].Text;
            drug.Memo = this.phaOutManager.FpSheetView.Cells[iRow, (int)ColumnSet.ColSpecs].Text;
            drug.User01 = this.phaOutManager.FpSheetView.Cells[iRow, (int)ColumnSet.ColMinUnit].Text;

            using (HISFC.Components.Pharmacy.ucPhaExpand uc = new ucPhaExpand())
            {
                uc.SetData(this.phaOutManager.TargetDept, drug, this.intervalDays);
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            }
        }

        /// <summary>
        /// 预打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void PrePrint(object sender, System.EventArgs args)
        {
            this.alPrintData = new ArrayList();
            if (phaOutManager.FpSheetView.Rows.Count > 0)
            {
                this.phaOutManager.FpSheetView.SetActiveCell(0, 0, true);
            }
            foreach (DataRow dr in this.dt.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();
                Neusoft.HISFC.Models.Pharmacy.Output output = this.hsOutData[key] as Neusoft.HISFC.Models.Pharmacy.Output;

                if (this.isUseMinUnit)                  //使用最小单位
                    output.Quantity = NConvert.ToDecimal(dr["实发数量"]);                       //实发数量
                else                                    //使用包装单位
                    output.Quantity = NConvert.ToDecimal(dr["实发数量"]) * output.Item.PackQty; //实发数量

                output.Operation.ExamQty = NConvert.ToDecimal(dr["实发数量"]) * output.Item.PackQty; //实发数量
                output.StoreQty = output.StoreQty - output.Quantity;
                output.StoreCost = output.StoreQty * output.Item.PriceCollection.RetailPrice / output.Item.PackQty;
                output.Memo = dr["备注"].ToString();
                output.DrugedBillNO = "0";                                      //摆药单号 不能为空

                this.alPrintData.Add(output);
            }

            if (this.phaOutManager.IOutPrint != null)
            {
                if (alPrintData.Count > 0)
                {
                    this.phaOutManager.IOutPrint.SetData(alPrintData, this.phaOutManager.PrivType.Memo);
                    this.phaOutManager.IOutPrint.Print();
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
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("库存数量",  dtDec),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("申请金额",  dtDec),
                                                                    new DataColumn("实发数量",  dtDec),
                                                                    new DataColumn("实发金额",  dtDec),
                                                                    new DataColumn("申请人",    dtStr),
                                                                    new DataColumn("申请日期",  dtDate),
                                                                    new DataColumn("备注",      dtStr),                                            
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

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugNO = sv.Cells[activeRow, 0].Text;
            string batchNO = sv.Cells[activeRow, 3].Text;
            decimal storeQty = NConvert.ToDecimal(sv.Cells[activeRow, 5].Text);

            if (this.AddDrugData(drugNO, batchNO, storeQty) == 1)
            {
                this.SetFormat();

                this.SetFocusSelect();
            }
            return 1;
        }

        public int ShowApplyList()
        {
            if (string.IsNullOrEmpty( this.phaOutManager.TargetDept.ID ) == true)
            {
                MessageBox.Show( Language.Msg( "请选择领药单位" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return -1;
            }

            //获取内部入库申请信息
            ArrayList alAllList = this.itemManager.QueryApplyOutListByTargetDept(this.phaOutManager.DeptInfo.ID, "13", "0");
            if (alAllList == null)
            {
                MessageBox.Show(Language.Msg("获取出库申请列表发生错误" + this.itemManager.Err));
                return -1;
            }

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

            //弹出窗口选择单据
            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] fpLabel = { "申请单号", "申请科室" };
            float[] fpWidth = { 120F, 120F };
            bool[] fpVisible = { true, true, false, false, false, false };

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, ref selectObj) == 1)
            {
                this.Clear();

                if (string.IsNullOrEmpty( this.phaOutManager.TargetDept.ID ) == true)
                {
                    this.phaOutManager.TargetDept.ID = selectObj.Memo;
                    this.phaOutManager.TargetDept.Name = selectObj.Name;                    
                }

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                targeDept.ID = selectObj.Memo;              //申请科室编码
                targeDept.Name = selectObj.Name;            //申请科室名称
                targeDept.Memo = "0";                       //目标单位性质 内部科室               

                this.AddApplyData(selectObj.ID, "0");

                this.SetFocusSelect();

                if (this.phaOutManager.FpSheetView != null)
                {
                    this.phaOutManager.FpSheetView.ActiveRowIndex = 0;
                }
            }

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
            //有效性判断时 不需要一定选择审批记录

            bool isHaveCheck = true;
            foreach (DataRow dr in this.dt.Rows)
            {
                if (!NConvert.ToBoolean(dr["审批"]))
                {
                    isHaveCheck = false;
                    break;
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

                    string[] keys = new string[]{
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColDrugNO].Text,
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
                                            };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.phaOutManager.Fp.StopCellEditing();

                        if (dr["数据来源"].ToString() == "1")
                        {
                            Neusoft.HISFC.Models.Pharmacy.Output delOutput = this.hsOutData[dr["药品编码"].ToString() + dr["批号"].ToString()] as Neusoft.HISFC.Models.Pharmacy.Output;
                            if (this.hsApplyData.ContainsKey(delOutput.User02))
                            {
                                this.hsApplyData.Remove(delOutput.User02);
                            }
                        }

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
                    this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColExamQty;
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

            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            bool isManagerStore = phaConsManager.IsManageStore(this.phaOutManager.TargetDept.ID);

            if (!isManagerStore)
            { 
                MessageBox.Show(Language.Msg(this.phaOutManager.TargetDept.Name + " 不管理库存，不能通过出库审批进行出库"),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaCons = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            string outListNO = "";

            this.alPrintData = new ArrayList();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();
                Neusoft.HISFC.Models.Pharmacy.Output output = this.hsOutData[key] as Neusoft.HISFC.Models.Pharmacy.Output;

                if (this.isUseMinUnit)                  //使用最小单位
                    output.Quantity = NConvert.ToDecimal(dr["实发数量"]);                       //实发数量
                else                                    //使用包装单位
                    output.Quantity = NConvert.ToDecimal(dr["实发数量"]) * output.Item.PackQty; //实发数量

                output.StoreQty = output.StoreQty - output.Quantity;
                output.StoreCost = output.StoreQty * output.Item.PriceCollection.RetailPrice / output.Item.PackQty;                
                output.Memo = dr["备注"].ToString();
                output.DrugedBillNO = "0";                                      //摆药单号 不能为空

                output.Operation.ExamOper.ID = this.phaOutManager.OperInfo.ID;  //审核人
                output.Operation.ExamOper.OperTime = sysTime;                   //审核日期
                output.Operation.ExamQty = output.Quantity;                     //审核数量
                output.Operation.Oper = output.Operation.ExamOper;              //操作信息
                output.GetPerson = this.phaOutManager.TargetPerson.ID;          //领药人

                output.State = "1";                                             //状态 审批

                #region 对数据来源为申请的数据进行更新 对本次新添加的数据生成申请信息记录

                if (dr["数据来源"].ToString() == "1")
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[output.User02] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                    if (outListNO == "")
                    {
                        outListNO = applyOut.BillNO;
                    }

                    decimal tempApproveQty = applyOut.Operation.ApproveQty;
                    applyOut.Operation = output.Operation;              //操作信息
                    //未选择审批标记 只记录本次待发送的数量 不扣库存处理
                    if (!NConvert.ToBoolean(dr["审批"]))
                    {
                        //数量累计
                        applyOut.Operation.ApproveQty = tempApproveQty + output.Quantity;
                        applyOut.State = "0";
                    }
                    else
                    {
                        applyOut.Operation.ApproveOper = output.Operation.Oper;
                        applyOut.State = "2";
                    }

                    // {EE05DA01-8969-404d-9A6B-EE8AD0BC1CD0}处理出库审批并发的问题
                    int resultApplyOut = this.itemManager.UpdateApplyOut(applyOut, true);
                    if (resultApplyOut == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("更新" + output.Item.Name + "出库申请信息时出错");
                        return;
                    }
                    if (resultApplyOut == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("该" + output.Item.Name + "申请信息已改变，请重新获取申请信息");
                        return;
                    }
                }
                else
                {
                    #region 无申请记录 此时只需更改申请人 到底需不需要添加申请信息呢? 不需要

                    output.Operation.ApplyOper = output.Operation.Oper;     //申请人
                    output.Operation.ApplyQty = output.Quantity;            //申请数量

                    #endregion
                }

                #endregion

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

                #region 以下信息在每次添加新数据时自动生成

                output.PrivType = this.phaOutManager.PrivType.ID;               //出库类型
                output.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型
                output.StockDept = this.phaOutManager.DeptInfo;                 //当前科室
                output.TargetDept = this.phaOutManager.TargetDept;              //目标科室

                #endregion

                //非药柜科室向药柜出库 进行特殊处理
                if (!this.phaOutManager.IsStockArk && this.phaOutManager.IsTargetArk)
                {
                    if (this.itemManager.ArkOutput(output,this.phaOutManager.IsStockArk,this.phaOutManager.IsTargetArk, false,true) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("出库保存发生错误" + this.itemManager.Err);
                        return;
                    }
                }
                else
                {
                    if (this.itemManager.Output(output, null, false) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("出库保存发生错误" + this.itemManager.Err);
                        return;
                    }
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
                //{0A53FC11-85EA-4dc8-8A85-5DABDB6D8535}  对于多批号出库时，重新获取出库数据，保证能打印出所有批号信息
                ArrayList alPrint = new ArrayList();

                if (alPrintData.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.Output info = this.alPrintData[0] as Neusoft.HISFC.Models.Pharmacy.Output;

                    alPrint = this.itemManager.QueryOutputInfo( info.StockDept.ID, info.OutListNO, info.State );
                }

                if (alPrint.Count > 0)
                {
                    this.phaOutManager.IOutPrint.SetData( alPrint, this.phaOutManager.PrivType.Memo );
                    this.phaOutManager.IOutPrint.Print();
                }
            }

            return 1;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            this.phaOutManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

            return 1;
        }

        #endregion

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColExamQty)
            {
                string[] keys = new string[] { this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text, this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["实发金额"] = NConvert.ToDecimal(dr["实发数量"]) * NConvert.ToDecimal(dr["零售价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void phaManager_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.phaOutManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColExamQty)
                    {
                        if (this.phaOutManager.FpSheetView.ActiveRowIndex == this.phaOutManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaOutManager.SetFocus();
                        }
                        else
                        {
                            this.phaOutManager.FpSheetView.ActiveRowIndex++;
                            this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColExamQty;
                        }
                    }
                }
            }
        }

        private void Fp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //双击弹出窗口

            string drugCode = string.Empty;

            if (this.phaOutManager.DeptInfo.Memo == "PI")
            {
                drugCode = this.phaOutManager.FpSheetView.Cells[e.Row, (int)ColumnSet.ColDrugNO].Text;
                using (frmEveryStore frm = new frmEveryStore())
                {
                    frm.DrugCode = drugCode;
                    frm.ShowDialog();
                }
            }
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
            /// 申请数量	
            /// </summary>
            ColApplyQty,
            /// <summary>
            /// 申请金额	
            /// </summary>
            ColApplyCost,
            /// <summary>
            /// 实发数量	
            /// </summary>
            ColExamQty,
            /// <summary>
            /// 实发金额	
            /// </summary>
            ColExamCost,
            /// <summary>
            /// 申请人		
            /// </summary>
            ColApplyOper,
            /// <summary>
            /// 申请日期	
            /// </summary>
            ColApplyDate,
            /// <summary>
            /// 备注		
            /// </summary>
            ColMemo,
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
            ColUserCode
        }
    }
}
