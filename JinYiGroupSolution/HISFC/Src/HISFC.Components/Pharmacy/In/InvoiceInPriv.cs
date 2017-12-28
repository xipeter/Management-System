using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /*
     *  待完善  发票批量输入 发票默认上一张
     * 
     * 
    ***/
    public class InvoiceInPriv : IPhaInManager 
    {
        public InvoiceInPriv(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
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
                this.phaInManager.IsShowItemSelectpanel = true;
                //设置目标科室信息
                this.phaInManager.SetTargetDept(true, false, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                //设置需过滤数据
                if (this.phaInManager.TargetDept.ID != "")
                {
                    this.ShowSelectData();
                }
                //显示信息设置清空  
                this.phaInManager.ShowInfo = "";
                //设置工具栏按钮显示
                this.phaInManager.SetToolBarButton(false, true, false, false, true);
                this.phaInManager.SetToolBarButtonVisible(false, true, false, false, true, true, false);
                //设置Fp可替代
                this.phaInManager.Fp.EditModeReplace = true;
                this.phaInManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);
                this.phaInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

                this.phaInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);
                this.phaInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

                this.phaInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);           
            }
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
                input.RetailCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;

                this.dt.Rows.Add(new object[] { 
                                                input.Item.Name,                            //商品名称
                                                input.Item.Specs,                           //规格
                                                input.Item.PriceCollection.RetailPrice,     //零售价
                                                input.BatchNO,                              //批号
                                                input.Item.PackUnit,                        //包装单位
                                                input.Quantity / input.Item.PackQty,        //入库数量
                                                input.RetailCost,                           //入库金额                                                
                                                input.InvoiceNO,                            //发票号
                                                input.InvoiceType,                          //发票类别
                                                input.Item.PriceCollection.PurchasePrice,   //购入价
                                                input.PurchaseCost,                         //购入金额
                                                input.Item.Product.Producer.Name,           //生产厂家
                                                input.Operation.ApplyOper.ID,               //申请人
                                                input.Operation.ApplyOper.OperTime,         //申请日期
                                                input.Memo,                                 //备注
                                                input.Item.ID,                              //药品编码
                                                input.Item.NameCollection.SpellCode,        //拼音码
                                                input.Item.NameCollection.WBCode,           //五笔码
                                                input.Item.NameCollection.UserCode,         //自定义码
                                                input.GroupNO.ToString()                            
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
        /// 设置显示数据
        /// </summary>
        /// <returns></returns>
        private int ShowSelectData()
        {
            string[] filterStr = new string[2] { "SPELL_CODE", "WB_CODE" };
            string[] label = new string[] { "药品编码", "药品商品名", "规格", "入库数量", "供货单位", "入库流水号", "拼音码", "五笔码", "通用名拼音码", "通用名五笔码" };
            int[] width = new int[] { 60, 120, 80, 60, 120, 60, 60, 60, 60, 60 };
            bool[] visible = new bool[] { false, true, true, true, true, false, false, false, false, false };
            string targetNO = this.phaInManager.TargetDept.ID;
            if (targetNO == "")
                targetNO = "AAAA";

            this.phaInManager.SetSelectData("3", false,new string[] { "Pharmacy.Item.GetPharmacyListForInput" }, filterStr, this.phaInManager.DeptInfo.ID,"0", targetNO);

            this.phaInManager.SetSelectFormat(label, width, visible);

            return 1;
        }

        /// <summary>
        /// 添加入库数据
        /// </summary>
        /// <param name="listNO">入库单号</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        protected virtual int AddInData(string listNO,string state)
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
                this.AddDataToTable(input);

                this.hsInData.Add(this.GetKey(input), input);
            }

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

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
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchaseCost].Visible = false;     //购入金额
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyOper].Visible = false;        //申请人
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyDate].Visible = false;        //申请日期
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Visible = false;      //发票分类
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColProduceName].Visible = false;      //生产厂家
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColGroupNO].Visible = false;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Locked = false;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMem].Locked = false;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMem].Width = 150F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].BackColor = System.Drawing.Color.SeaShell;
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

            this.phaInManager.TotCostInfo = string.Format("零售总金额:{0} 购入总金额:{1}", retailCost.ToString("N"), purchaseCost.ToString("N"));
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            return input.Item.ID + input.BatchNO + input.GroupNO.ToString();
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private string[] GetKey(FarPoint.Win.Spread.SheetView sv,int rowIndex)
        {
            string[] keys = new string[]{
                                                sv.Cells[rowIndex, (int)ColumnSet.ColDrugNO].Text,
                                                sv.Cells[rowIndex, (int)ColumnSet.ColBatchNO].Text,
                                                sv.Cells[rowIndex,(int)ColumnSet.ColGroupNO].Text
                                            };
            return keys;
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["药品编码"].ToString() + dr["批号"].ToString() + dr["批次"].ToString();
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
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("入库数量",  dtDec),
                                                                    new DataColumn("入库金额",  dtDec),
                                                                    new DataColumn("发票号",    dtStr),                                                                
                                                                    new DataColumn("发票分类",  dtStr),
                                                                    new DataColumn("购入价",    dtDec),
                                                                    new DataColumn("购入金额",  dtDec),
                                                                    new DataColumn("生产厂家",  dtStr),
                                                                    new DataColumn("申请人",    dtStr),
                                                                    new DataColumn("申请日期",  dtDate),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr),
                                                                    new DataColumn("批次",      dtStr)
                                                                   }
                                  );

            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;
         
            DataColumn[] keys = new DataColumn[3];

            keys[0] = this.dt.Columns["药品编码"];
            keys[1] = this.dt.Columns["批号"];
            keys[2] = this.dt.Columns["批次"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string inNO = sv.Cells[activeRow, 5].Text;

            Neusoft.HISFC.Models.Pharmacy.Input input = this.itemManager.GetInputInfoByID(inNO);
            if (input == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return -1;
            }
            if (this.hsInData.ContainsKey(this.GetKey(input)))
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return -1;
            }

            if (this.AddDataToTable(input) == 1)
            {
                this.hsInData.Add(this.GetKey(input), input);
            }

            this.SetFormat();

            this.SetFocusSelect();
     
            return 1;
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
                this.ucListSelect.State = "0";                  //需检索状态
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
            for (int i = 0; i < this.phaInManager.FpSheetView.Rows.Count; i++)
            {
                if (this.phaInManager.FpSheetView.Cells[i, (int)ColumnSet.ColInvoiceNO].Text == "")
                {									
                    MessageBox.Show(Language.Msg("请输入 " + this.phaInManager.FpSheetView.Cells[i,(int)ColumnSet.ColTradeName].Text + " 发票号"));
                    return false;
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

                    DataRow dr = this.dt.Rows.Find(this.GetKey(sv,delRowIndex));
                    if (dr != null)
                    {
                        this.hsInData.Remove(this.GetKey(dr));

                        this.dt.Rows.Remove(dr);                        
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
                    this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
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

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = this.GetKey(dr);

                Neusoft.HISFC.Models.Pharmacy.Input input = this.hsInData[key] as Neusoft.HISFC.Models.Pharmacy.Input;

                input.Operation.ExamOper.ID = this.phaInManager.OperInfo.ID;                //审批人
                input.Operation.ExamOper.OperTime = sysTime;                                //审批时间
                input.InvoiceNO = dr["发票号"].ToString().Trim();
                input.InvoiceType = dr["发票分类"].ToString().Trim();
                input.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(dr["购入价"]);
                input.PurchaseCost = NConvert.ToDecimal(dr["购入金额"]);

                int parm = this.itemManager.ExamInput(input);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(this.itemManager.Err));
                    return;
                }
                if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("数据可能已被审核，请刷新重试"));
                    return;
                }                
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("审批确认成功"));

            //清屏显示
            this.Clear();
            this.ShowSelectData();
        }

        public int Print()
        {
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
            this.phaInManager.TargetDept = targetDept;

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
            if (this.phaInManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceNO)
                    {
                        if (this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Visible && !this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Locked)
                        {
                            this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceType;
                        }
                        else
                        {
                            this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColPurchasePrice;
                        }
                        return;
                    }
                    if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceType)
                    {
                        this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColPurchasePrice;
                        return;
                    }
                    if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
                    {
                        if (this.phaInManager.FpSheetView.ActiveRowIndex == this.phaInManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaInManager.SetFocus();
                        }
                        else
                        {
                            this.phaInManager.FpSheetView.ActiveRowIndex++;
                            this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                        }
                        return;
                    }
                }
            }
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
            {
                DataRow dr = this.dt.Rows.Find(this.GetKey(this.phaInManager.FpSheetView,this.phaInManager.FpSheetView.ActiveRowIndex));
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
            if (this.phaInManager.FpSheetView.ActiveRowIndex == (int)ColumnSet.ColPurchasePrice)
            {
                DataRow dr = this.dt.Rows.Find(this.GetKey(this.phaInManager.FpSheetView,this.phaInManager.FpSheetView.ActiveRowIndex));
                if (dr != null)
                {
                    dr["购入金额"] = NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    this.CompuateSum();
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
			/// 发票号		7
			/// </summary>
			ColInvoiceNO,
			/// <summary>
			/// 内部号		8
			/// </summary>
			ColInvoiceType,
			/// <summary>
			/// 购入价		9
			/// </summary>
			ColPurchasePrice,
            /// <summary>
            /// 购入金额    10
            /// </summary>
            ColPurchaseCost,
			/// <summary>
			/// 生产厂家	11
			/// </summary>
			ColProduceName,
			/// <summary>
			/// 申请人		12
			/// </summary>
			ColApplyOper,
			/// <summary>
			/// 申请日期	13
			/// </summary>
			ColApplyDate,
			/// <summary>
			/// 备注	    14
			/// </summary>
			ColMem,
            /// <summary>
            /// 药品编码    15 
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
            ColUserCode,
            /// <summary>
            /// 批次
            /// </summary>
            ColGroupNO
        }
    }
}
