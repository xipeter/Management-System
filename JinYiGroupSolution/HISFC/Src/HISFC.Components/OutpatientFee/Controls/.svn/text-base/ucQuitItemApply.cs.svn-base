using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucQuitItemApply : ucQuitFee
    {
        public ucQuitItemApply()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 操作项目类别 默认为全部
        /// </summary>
        protected ItemTypes itemType = ItemTypes.All;

        /// <summary>
        /// 入出转综合业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 是否确认窗口
        /// </summary>
        private bool isConfirmWindow = false;
        #endregion

        #region 属性

        /// <summary>
        /// 操作项目类别 默认为全部
        /// </summary>
        public ItemTypes ItemType 
        {
            get 
            {
                return this.itemType;
            }
            set 
            {
                this.itemType = value;

                this.SetItemType();
            }
        }
        /// <summary>
        /// 是否确认窗口
        /// </summary>
        public bool IsConfirmWindow {
            set { this.isConfirmWindow = value; }
            get { return this.isConfirmWindow; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 操作项目类别
        /// </summary>
        public enum ItemTypes 
        {
            /// <summary>
            /// 非药品
            /// </summary>
            Undrug = 0,

            /// <summary>
            /// 药品
            /// </summary>
            Pharmarcy,

            /// <summary>
            /// 所有
            /// </summary>
            All
        }

        /// <summary>
        /// 申请还是审核状态
        /// </summary>
        public enum ApplyTypes 
        {
            /// <summary>
            /// 申请
            /// </summary>
            Apply = 0,

            /// <summary>
            /// 审核
            /// </summary>
            Confirm
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 根据项目类别,设置可见页
        /// </summary>
        protected virtual void SetItemType()
        {
            switch (this.itemType) 
            {
                case ItemTypes.All://所有
                    this.fpSpread1_Sheet1.Visible = true;
                    this.fpSpread1_Sheet2.Visible = true;
                    this.fpSpread2_Sheet1.Visible = true;
                    this.fpSpread2_Sheet2.Visible = true;
                    break;
                case ItemTypes.Pharmarcy://药品
                    this.fpSpread1_Sheet1.Visible = true;
                    this.fpSpread1_Sheet2.Visible = false;
                    this.fpSpread2_Sheet1.Visible = true;
                    this.fpSpread2_Sheet2.Visible = false;
                    break;
                case ItemTypes.Undrug://药品
                    this.fpSpread1_Sheet1.Visible = false;
                    this.fpSpread1_Sheet2.Visible = true;
                    this.fpSpread2_Sheet1.Visible = false;
                    this.fpSpread2_Sheet2.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int GetItemList()
        {
            if (this.quitInvoices == null || this.quitInvoices.Count == 0) 
            {
                return -1;
            }
            
            //获得本次退费所有发票的第一张作为临时发票信息
            Balance tempBalance = quitInvoices[0] as Balance;

            //药品列表
            ArrayList drugItemLists = new ArrayList();

            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Pharmarcy)
            {
                //通过发票序列号,获得所有应参与退费的药品信息
                drugItemLists = this.outpatientManager.QueryDrugFeeItemListByInvoiceSequence(tempBalance.CombNO);
                if (drugItemLists == null)
                {
                    MessageBox.Show("获得药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            //非药品信息
            ArrayList undrugItemLists = new ArrayList();

            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Undrug)
            {
                //通过发票序列号,获得所有应参与退费的非药品信息
                undrugItemLists = outpatientManager.QueryUndrugFeeItemListByInvoiceSequence(tempBalance.CombNO);
                if (undrugItemLists == null)
                {
                    MessageBox.Show("获得非药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            if (drugItemLists.Count + undrugItemLists.Count == 0)
            {
                MessageBox.Show("没有费用信息!");

                return -1;
            }

            this.invoiceFeeItemLists = outpatientManager.QueryFeeItemListsByInvoiceNO(tempBalance.Invoice.ID);

            ArrayList drugApplyedList = new ArrayList();//已经申请过的药品列表
            ArrayList undrugApplyedList = new ArrayList();//已经申请过的药品列表
           
            foreach (Balance balance in this.quitInvoices)
            {
                if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Pharmarcy)
                {
                    drugApplyedList = base.returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "1");
                    if (drugApplyedList == null)
                    {
                        MessageBox.Show("获得申请药品项目列表出错!" + returnApplyManager.Err);

                        return -1;
                    }
                }
                if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Undrug)
                {
                    undrugApplyedList = base.returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "0");
                    if (undrugApplyedList == null)
                    {
                        MessageBox.Show("获得申请非药品项目列表出错!" + returnApplyManager.Err);

                        return -1;
                    }
                }
            }

            this.fpSpread1_Sheet1.RowCount = drugItemLists.Count;
            FeeItemList drugItemApply = null;

            for (int i = 0; i < drugItemLists.Count; i++)
            {
                drugItemApply = drugItemLists[i] as FeeItemList;

                this.fpSpread1_Sheet1.Rows[i].Tag = drugItemApply;
                //因为可能存在同一发票有不同看诊科室的情况,而且挂号信息中的看诊信息不一定与实际收费的看诊
                //科室相同,所以这里把挂号实体的看诊可是赋值为收费明细时的看诊科室信息.
                this.patient.DoctorInfo.Templet.Dept = drugItemApply.RecipeOper.Dept;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.ItemName].Text = drugItemApply.Item.Name;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.CombNo].Text = drugItemApply.Order.Combo.ID;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Specs].Text = drugItemApply.Item.Specs;
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text = drugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.Item.Qty / drugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.PriceUnit].Text = drugItemApply.Item.PriceUnit;
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.NoBackQty].Text = drugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.ConfirmedQty / drugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.ConfirmedQty, 2).ToString();

                if (drugItemApply.Item.SysClass.ID.ToString() == "PCC")
                {
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItemApply.Order.DoseOnce.ToString() + drugItemApply.Order.DoseUnit + " " + "付数:" + drugItemApply.Days.ToString();
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItemApply.Order.DoseOnce.ToString() + drugItemApply.Order.DoseUnit;
                }

                Class.Function.DrawCombo(this.fpSpread1_Sheet1, (int)DrugList.CombNo, (int)DrugList.Comb, 0);
            }

            //显示非药品信息
            this.fpSpread1_Sheet2.RowCount = undrugItemLists.Count;

            FeeItemList undrugItemApply = null;
            for (int i = 0; i < undrugItemLists.Count; i++)
            {
                undrugItemApply = undrugItemLists[i] as FeeItemList;
               
                this.fpSpread1_Sheet2.Rows[i].Tag = undrugItemApply;
                this.patient.DoctorInfo.Templet.Dept = undrugItemApply.RecipeOper.Dept;

                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.ItemName].Text = undrugItemApply.Item.Name;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.CombNo].Text = undrugItemApply.Order.Combo.ID;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text = undrugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.Item.Qty / undrugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PriceUnit].Text = undrugItemApply.Item.PriceUnit;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.NoBackQty].Text = undrugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.ConfirmedQty / undrugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.ConfirmedQty, 2).ToString();
            
                if (undrugItemApply.UndrugComb.ID != null && undrugItemApply.UndrugComb.ID.Length > 0)
                {
                    this.undrugComb = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.UndrugComb.ID);
                    if (this.undrugComb == null)
                    {
                        MessageBox.Show("获得组套信息出错，无法显示组套自定义码，但是不影响退费操作！");
                    }
                    else
                    {
                        undrugItemApply.UndrugComb.UserCode = this.undrugComb.UserCode;
                    }

                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.ID);

                    if (item == null)
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItemApply.UndrugComb.UserCode + ")" + undrugItemApply.UndrugComb.Name;
                    }
                    else
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItemApply.UndrugComb.UserCode + ")" + undrugItemApply.UndrugComb.Name + "[" + item.UserCode + "]";
                    }

                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.ID);

                    if (item != null)
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = item.UserCode;
                    }
                }

                Class.Function.DrawCombo(this.fpSpread1_Sheet2, (int)UndrugList.CombNo, (int)UndrugList.Comb, 0);
            }

            //显示确认退药信息
            this.fpSpread2_Sheet1.RowCount = 0;

            #region //判断是否审核，如已经审核，则过滤掉 {CBDB919E-D2A3-4a39-8B66-9642AC706658}
            int index = 0;
            while (index <drugApplyedList.Count)
            {
                Neusoft.HISFC.Models.Fee.ReturnApply item = drugApplyedList[index] as Neusoft.HISFC.Models.Fee.ReturnApply;
                if (isConfirmWindow)
                {
                    //判断是否发药 
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList = this.outpatientManager.GetFeeItemListBalanced(item.RecipeNO, item.SequenceNO);
                    if (feeItemList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(item.Item.Name + "获得项目失败!" + this.outpatientManager.Err);

                        return -1;
                    }
                    ///已经审核过的，确认数量为0
                    if (feeItemList.ConfirmedQty == 0)
                    {
                        drugApplyedList.Remove(item);
                    }
                }
                index++;
            }
            #endregion

            this.fpSpread2_Sheet1.RowCount = drugItemLists.Count + drugApplyedList.Count;
            Neusoft.HISFC.Models.Fee.ReturnApply drugReturnApply = null;
            for (int i = 0; i < drugApplyedList.Count; i++)
            {
                drugReturnApply = drugApplyedList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                this.fpSpread2_Sheet1.Rows[i].Tag = drugReturnApply;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.ItemName].Text = drugReturnApply.Item.Name;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Amount].Text = drugReturnApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugReturnApply.Item.Qty / drugReturnApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugReturnApply.Item.Qty, 2).ToString();
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.PriceUnit].Text = drugReturnApply.Item.PriceUnit;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Specs].Text = drugReturnApply.Item.Specs;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Flag].Text = "申请";

                int findRow = FindItem(drugReturnApply.RecipeNO, drugReturnApply.SequenceNO, this.fpSpread1_Sheet1);
                if (findRow == -1)
                {
                    MessageBox.Show("查找未退药项目出错!");

                    return -1;
                }
                FeeItemList modifyDrug = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;

                modifyDrug.ConfirmedQty = modifyDrug.ConfirmedQty - drugReturnApply.Item.Qty;
               
                this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = modifyDrug.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.ConfirmedQty / modifyDrug.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.ConfirmedQty, 2).ToString();
            }

            this.fpSpread2_Sheet2.RowCount = 0;
            this.fpSpread2_Sheet2.RowCount = undrugItemLists.Count + undrugApplyedList.Count;
            Neusoft.HISFC.Models.Fee.ReturnApply undrugReturnApply = null;
            for (int i = 0; i < undrugApplyedList.Count; i++)
            {
                undrugReturnApply = undrugApplyedList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                this.fpSpread2_Sheet2.Rows[i].Tag = undrugReturnApply;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.ItemName].Text = undrugReturnApply.Item.Name;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Amount].Text = undrugReturnApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugReturnApply.Item.Qty / undrugReturnApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugReturnApply.Item.Qty, 2).ToString();
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.PriceUnit].Text = undrugReturnApply.Item.PriceUnit;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Flag].Text = "申请";

                int findRow = FindItem(undrugReturnApply.RecipeNO, undrugReturnApply.SequenceNO, this.fpSpread1_Sheet2);
                if (findRow == -1)
                {
                    MessageBox.Show("查找未退非药项目出错!");

                    return -1;
                }
                FeeItemList modifyUndrug = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;

                modifyUndrug.ConfirmedQty = modifyUndrug.ConfirmedQty - undrugReturnApply.Item.Qty;

                this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = modifyUndrug.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.ConfirmedQty / modifyUndrug.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.ConfirmedQty, 2).ToString();

            }
       
            return 1;
        }

        /// <summary>
        /// 退费申请操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int QuitOperation()
        {
            #region 药品

            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)//退药品
            {
                int currRow = this.fpSpread1_Sheet1.ActiveRowIndex;

                if (this.fpSpread1_Sheet1.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList;

                    if (this.ckbAllQuit.Checked)
                    {
                        if (!this.isNeedAllQuit || f.Item.SysClass.ID.ToString() != "PCC")
                        {
                            if (f.ConfirmedQty <= 0)
                            {
                                MessageBox.Show(f.Item.Name + "已经没有可退数量，不能再退费申请!");

                                return -1;
                            }

                            int findRow = FindReturnApplyItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                            //没有找到，那么新增一条;
                            if (findRow == -1)
                            {
                                findRow = FindNullRow(this.fpSpread2_Sheet1);

                                ReturnApply returnApply = new ReturnApply();

                                returnApply.Item = f.Item.Clone();
                                returnApply.RecipeNO = f.RecipeNO;
                                returnApply.SequenceNO = f.SequenceNO;
                                returnApply.FeePack = f.FeePack;
                                returnApply.Item.Qty = f.ConfirmedQty;
                                returnApply.Patient = f.Patient.Clone();
                                returnApply.Days = f.Days;
                                returnApply.ExecOper = f.ExecOper.Clone();
                                returnApply.UndrugComb = f.UndrugComb.Clone();
                                returnApply.ConfirmBillNO = f.Invoice.ID;

                                this.fpSpread2_Sheet1.Rows[findRow].Tag = returnApply;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = f.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = f.Item.Specs;

                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = f.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty, 2).ToString();
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = f.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = f.Item.Price.ToString();

                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty * f.Item.Price, 2).ToString();

                            }
                            else //找到了累加数量
                            {

                                ReturnApply fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as ReturnApply;
                                fFind.Item.Qty = fFind.Item.Qty + f.ConfirmedQty;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fFind.Item.Specs;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = fFind.Item.Price.ToString();

                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / f.Item.PackQty * f.Item.Price, 2).ToString();

                            }

                            f.ConfirmedQty = 0;

                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = "0";
                        }
                        else 
                        {
                            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                                    if (fTemp.Item.SysClass.ID.ToString() == "PCC" && fTemp.Order.Combo.ID == f.Order.Combo.ID)
                                    {
                                        this.QuitDrugOperation(i);
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (f.Item.SysClass.ID.ToString() == "PCC" && f.Order.Combo.ID.Length > 0 && this.isNeedAllQuit)
                        {
                            ArrayList alFeeItem = new ArrayList();

                            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                                    if (fTemp.Item.SysClass.ID.ToString() == "PCC" && fTemp.Order.Combo.ID == f.Order.Combo.ID)
                                    {
                                        alFeeItem.Add(fTemp);
                                    }
                                }
                            }

                            txtReturnItemName.Text = "中药组合";
                            txtReturnNum.Tag = alFeeItem;
                            txtRetSpecs.Text = string.Empty;
                            this.backType = "PCC";
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                        else
                        {
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                            txtReturnItemName.Text = f.Item.Name;
                            txtReturnNum.Tag = f;
                            txtRetSpecs.Text = f.Item.Specs;
                        }
                    }
                }
            }

            #endregion

            #region 非药品

            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)//退药品
            {
                int currRow = this.fpSpread1_Sheet2.ActiveRowIndex;

                if (this.fpSpread1_Sheet2.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread1_Sheet2.Rows[currRow].Tag as FeeItemList;

                    if (this.ckbAllQuit.Checked)
                    {
                        if (f.ConfirmedQty <= 0)
                        {
                            MessageBox.Show(f.Item.Name + "已经没有可退数量，不能再退费申请!");

                            return -2;
                        }
                        int findRow = FindReturnApplyItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                        //没有找到，那么新增一条;
                        if (findRow == -1)
                        {
                            findRow = FindNullRow(this.fpSpread2_Sheet2);

                            ReturnApply returnApply = new ReturnApply();

                            returnApply.Item = f.Item.Clone();
                            returnApply.RecipeNO = f.RecipeNO;
                            returnApply.SequenceNO = f.SequenceNO;
                            returnApply.FeePack = f.FeePack;
                            returnApply.Item.Qty = f.ConfirmedQty;
                            returnApply.Patient = f.Patient.Clone();
                            returnApply.Days = f.Days;
                            returnApply.ExecOper = f.ExecOper.Clone();
                            returnApply.UndrugComb = f.UndrugComb.Clone();
                            returnApply.ConfirmBillNO = f.Invoice.ID;

                            this.fpSpread2_Sheet2.Rows[findRow].Tag = returnApply;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = returnApply.Item.Name;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = returnApply.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty, 2).ToString();
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = f.Item.PriceUnit;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        }
                        else //找到了累加数量
                        {
                            ReturnApply fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as ReturnApply;
                            fFind.Item.Qty = fFind.Item.Qty + f.ConfirmedQty;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        }
                        f.ConfirmedQty = 0;
                                            
                        this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = "0";
                    }
                    else
                    {
                        //复合项目
                        if (f.UndrugComb.ID != null && f.UndrugComb.ID.Length > 0 && this.isNeedAllQuit)
                        {
                            ArrayList alFeeItem = new ArrayList();

                            this.currentUndrugComb = this.undrugManager.GetValidItemByUndrugCode(f.UndrugComb.ID);
                            if (this.currentUndrugComb == null)
                            {
                                MessageBox.Show("获得复合项目出错！" + this.undrugManager.Err);

                                return -1;
                            }

                            this.currentUndrugCombs = this.undrugPackAgeManager.QueryUndrugPackagesBypackageCode(this.currentUndrugComb.ID);

                            if (currentUndrugCombs == null)
                            {
                                MessageBox.Show("获得复合项目明细出错！" + this.undrugPackAgeManager.Err);

                                return -1;
                            }

                            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;
                                    if (fTemp.UndrugComb.ID == f.UndrugComb.ID && fTemp.Order.ID == f.Order.ID)
                                    {
                                        alFeeItem.Add(fTemp);
                                    }
                                }
                            }

                            txtReturnItemName.Text = f.UndrugComb.Name;
                            txtReturnNum.Tag = alFeeItem;
                            txtRetSpecs.Text = string.Empty;
                            this.backType = "PACKAGE";
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                        else
                        {
                            txtReturnItemName.Text = f.Item.Name;
                            txtReturnNum.Tag = f;
                            txtRetSpecs.Text = f.Item.Specs;
                            this.backType = string.Empty;
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                    }
                }
            }

            #endregion

            return 1;
        }

        protected override int QuitDrugOperation(int currRow)
        {
            //if (this.fpSpread1_Sheet1.Rows[currRow].Tag is FeeItemList)
            //{
            //    FeeItemList f = this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList;

            //    if (this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text.Trim() == "0" || this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text.Trim() == "0.00") 
            //    {
            //        return -1;
            //    }

            //    //if (f.NoBackQty <= 0)
            //    //{
            //    //    return -2;
            //    //}
            //    int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
            //    //没有找到，那么新增一条;
            //    if (findRow == -1)
            //    {
            //        findRow = FindNullRow(this.fpSpread2_Sheet1);
            //        FeeItemList fClone = f.Clone();
            //        this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
            //            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
            //            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
            //    }
            //    else //找到了累加数量
            //    {

            //        FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
            //        fFind.Item.Qty = fFind.Item.Qty + f.Item.Qty;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
            //            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
            //            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
            //        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
            //    }
            //    f.Item.Qty = f.Item.Qty - f.NoBackQty;
            //    f.NoBackQty = 0;
            //    f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
            //    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
            //        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
            //        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
            //    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
            //    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = "0";
            //}

            if (this.fpSpread1_Sheet1.Rows[currRow].Tag is FeeItemList)
            {
                FeeItemList f = this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList;

                if (this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text.Trim() == "0" || this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text.Trim() == "0.00")
                {
                    return -1;
                }
                int findRow = FindReturnApplyItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                //没有找到，那么新增一条;
                if (findRow == -1)
                {
                    findRow = FindNullRow(this.fpSpread2_Sheet1);

                    ReturnApply returnApply = new ReturnApply();

                    returnApply.Item = f.Item.Clone();
                    returnApply.RecipeNO = f.RecipeNO;
                    returnApply.SequenceNO = f.SequenceNO;
                    returnApply.FeePack = f.FeePack;
                    returnApply.Item.Qty = f.ConfirmedQty;
                    returnApply.Patient = f.Patient.Clone();
                    returnApply.Days = f.Days;
                    returnApply.ExecOper = f.ExecOper.Clone();
                    returnApply.UndrugComb = f.UndrugComb.Clone();
                    returnApply.ConfirmBillNO = f.Invoice.ID;

                    this.fpSpread2_Sheet1.Rows[findRow].Tag = returnApply;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = f.Item.Name;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = f.Item.Specs;

                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = f.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = f.Item.Price.ToString();

                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty * f.Item.Price, 2).ToString();

                }
                else //找到了累加数量
                {

                    ReturnApply fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as ReturnApply;
                    fFind.Item.Qty = fFind.Item.Qty + f.ConfirmedQty;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fFind.Item.Specs;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = fFind.Item.Price.ToString();

                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / f.Item.PackQty * f.Item.Price, 2).ToString();

                }

                f.ConfirmedQty = 0;

                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = "0";
            }
            ComputCost();

            return 1;
        }

        /// <summary>
        /// 综合处理退费申请
        /// </summary>
        protected override void DealCancelQuitOperation() 
        {
            if (this.fpSpread2.ActiveSheet.RowCount == 0)
            {
                return;
            }

            int currRow = this.fpSpread2.ActiveSheet.ActiveRowIndex;

            if (this.fpSpread2.ActiveSheet.Rows[currRow].Tag is ReturnApply)
            {
               CancelQuitOperation();
            }
        }

        /// <summary>
        /// 取消退费申请
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int CancelQuitOperation()
        {
            string recipeNO = "";
			int seqNO = 0;

			if(this.fpSpread2.ActiveSheet.RowCount <= 0)
            {
   				return -1;
            }
	
			int currRow = this.fpSpread2.ActiveSheet.ActiveRowIndex;

            if (this.fpSpread2.ActiveSheet.Rows[currRow].Tag is ReturnApply)
            {
                DialogResult result = MessageBox.Show("已做退药申请,是否取消该退药申请","提示",System.Windows.Forms.MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return -1;
                }

                ReturnApply returnApply = this.fpSpread2.ActiveSheet.Rows[currRow].Tag as ReturnApply;
                
                //取消退药申请
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                if (returnApplyManager.CancelReturnApply(returnApply.ID ,this.returnApplyManager.Operator.ID) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                this.GetItemList();
                this.txtReturnNum.Tag = null;
                this.txtReturnItemName.Text = string.Empty;
                this.txtRetSpecs.Text = string.Empty;
                this.txtUnit.Text = string.Empty;
                this.txtReturnNum.Text = string.Empty;
            }

            return 1;
        }

        /// <summary>
        /// 保存退费申请
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int Save()
        {
            int quitCounts = 0;

            foreach (FarPoint.Win.Spread.SheetView sv in this.fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.RowCount; i++)
                {
                    if (sv.Rows[i].Tag is ReturnApply)
                    {
                        quitCounts++;
                    }
                }
            }

            if (quitCounts == 0) 
            {                
                MessageBox.Show("没有申请项目可退!");

                return -1;
            }

            DateTime operDate = this.outpatientManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.pharmacyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int returnValue = 0;

            foreach (FarPoint.Win.Spread.SheetView sv in this.fpSpread2.Sheets) 
            {
                for (int i = 0; i < sv.RowCount; i++) 
                {
                    if (sv.Rows[i].Tag is ReturnApply) 
                    {
                        ReturnApply tempInsert = sv.Rows[i].Tag as ReturnApply;

                        ReturnApply tempExist = this.returnApplyManager.GetReturnApplyByApplySequence(tempInsert.Patient.ID, tempInsert.ID);
                        //找到已经存在数据库的退费申请信息
                        if (tempExist != null) 
                        {
                            //if (tempExist.CancelType != Neusoft.HISFC.Models.Base.CancelTypes.Valid) 
                            //{
                            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            //    MessageBox.Show(tempExist.Item.Name + "已经被确认或者作废,请刷新");

                            //    return -1;
                            //}
                            if (tempExist.IsConfirmed) 
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(tempExist.Item.Name + "已经被确认或者作废,请刷新");

                                return -1;
                            }
                        }

                        returnValue = this.returnApplyManager.DeleteReturnApply(tempInsert.ID);
                        if (returnValue == -1) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempExist.Item.Name + "删除失败!" + this.returnApplyManager.Err);

                            return -1;
                        }

                        tempInsert.ID = this.returnApplyManager.GetReturnApplySequence();
                        tempInsert.IsConfirmed = false;
                        tempInsert.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;

                        returnValue = this.returnApplyManager.InsertReturnApply(tempInsert);

                        if (returnValue == -1) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempInsert.Item.Name + "申请失败!" + this.returnApplyManager.Err);

                            return -1;
                        }
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("申请成功!");

            this.Clear();

            return 1;
        }

        /// <summary>
        /// 查找项目,查找Tag为ReturnApply
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequence">处方流水号</param>
        /// <param name="sv">当前fp</param>
        /// <returns>成功 row 失败 0</returns>
        protected virtual int FindReturnApplyItem(string recipeNO, int sequence, FarPoint.Win.Spread.SheetView sv)
        {
            for (int i = 0; i < sv.RowCount; i++)
            {
                if (sv.Rows[i].Tag is ReturnApply)
                {
                    ReturnApply f = sv.Rows[i].Tag as ReturnApply;
                    if (f.RecipeNO == recipeNO && f.SequenceNO == sequence)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 半退
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int QuitItemByNum()
        {
            if (this.txtReturnNum.Tag == null)
            {
                MessageBox.Show("请选择项目!");

                return -1;
            }
            decimal quitQty = 0;
            try
            {
                quitQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtReturnNum.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数量输入不合法!" + ex.Message);
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }
            if (quitQty == 0)
            {
                MessageBox.Show("数量不能为零");
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }
            if (quitQty < 0)
            {
                MessageBox.Show("数量不能为小于零");
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }

            object objQuit = this.txtReturnNum.Tag;

            #region Tag为单个项目时

            if (objQuit is FeeItemList)
            {
                FeeItemList f = objQuit as FeeItemList;
                if (f.FeePack == "1")//包装单位
                {
                    if (quitQty > f.ConfirmedQty / f.Item.PackQty)
                    {
                        MessageBox.Show("输入的数量大于可退数量!");
                        this.txtReturnNum.SelectAll();
                        this.txtReturnNum.Focus();

                        return -1;
                    }
                }
                else
                {
                    if (quitQty > f.ConfirmedQty)
                    {
                        MessageBox.Show("输入的数量大于可退数量!");
                        this.txtReturnNum.SelectAll();
                        this.txtReturnNum.Focus();

                        return -1;
                    }
                }
                int currRow = 0;
                //if (f.Item.IsPharmacy)
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);
                    if (currRow == -1)
                    {
                        MessageBox.Show("查找药品失败！");

                        return -1;
                    }
                    if (f.Item.SysClass.ID.ToString() == "PCC")
                    {
                        decimal doseOnce = (f.ConfirmedQty - quitQty) / f.Days;

                        (this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList).Order.DoseOnce = doseOnce;

                        this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.DoseAndDays].Text = "每次量:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(doseOnce, 3) + f.Order.DoseUnit + " " + "付数:" + f.Days.ToString();
                    }
                }
                else
                {
                    currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);
                    if (currRow == -1)
                    {
                        MessageBox.Show("查找非药品失败！");

                        return -1;
                    }
                }

                f.ConfirmedQty = f.ConfirmedQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty);

                //if (f.Item.IsPharmacy)//药品
                if (f.Item.ItemType == EnumItemType.Drug)//药品
                {
                    int findRow = FindReturnApplyItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                    //没有找到，那么新增一条;
                    if (findRow == -1)
                    {
                        findRow = FindNullRow(this.fpSpread2_Sheet1);

                        ReturnApply returnApply = new ReturnApply();

                        returnApply.Item = f.Item.Clone();
                        returnApply.RecipeNO = f.RecipeNO;
                        returnApply.SequenceNO = f.SequenceNO;
                        returnApply.FeePack = f.FeePack;
                        returnApply.Item.Qty = f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty;
                        returnApply.Patient = f.Patient.Clone();
                        returnApply.Days = f.Days;
                        returnApply.ExecOper = f.ExecOper.Clone();
                        returnApply.UndrugComb = f.UndrugComb.Clone();
                        returnApply.ConfirmBillNO = f.Invoice.ID;

                        this.fpSpread2_Sheet1.Rows[findRow].Tag = returnApply;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = returnApply.Item.Name;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = returnApply.Item.Specs;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = f.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(returnApply.Item.Qty / f.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(returnApply.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = f.Item.PriceUnit;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = f.Item.Price.ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(returnApply.Item.Qty / f.Item.PackQty * f.Item.Price,2).ToString();
                    }
                    else //找到了累加数量
                    {
                        ReturnApply fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as ReturnApply;
                        fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty : quitQty);
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fFind.Item.Specs;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";

                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Price].Text = f.Item.Price.ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Cost].Text = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / f.Item.PackQty * f.Item.Price, 2).ToString();
                    }

                    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty, 2).ToString();
                }
                else //非药品
                {
                    int findRow = FindReturnApplyItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                    //没有找到，那么新增一条;
                    if (findRow == -1)
                    {
                        findRow = FindNullRow(this.fpSpread2_Sheet2);

                        ReturnApply returnApply = new ReturnApply();

                        returnApply.Item = f.Item.Clone();
                        returnApply.RecipeNO = f.RecipeNO;
                        returnApply.SequenceNO = f.SequenceNO;
                        returnApply.FeePack = f.FeePack;
                        returnApply.Item.Qty = f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty;
                        returnApply.Patient = f.Patient.Clone();
                        returnApply.Days = f.Days;
                        returnApply.ExecOper = f.ExecOper.Clone();
                        returnApply.UndrugComb = f.UndrugComb.Clone();
                        returnApply.ConfirmBillNO = f.Invoice.ID;

                        this.fpSpread2_Sheet2.Rows[findRow].Tag = returnApply;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = f.Item.Name;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = f.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(returnApply.Item.Qty / f.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(returnApply.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = f.Item.PriceUnit;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                    }
                    else //找到了累加数量
                    {
                        ReturnApply fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as ReturnApply;
                        fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty : quitQty);
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                    }

                    this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.ConfirmedQty, 2).ToString();
                }

            }

            #endregion

            #region 组合项目临时屏蔽

            //else if (objQuit is ArrayList)
            //{
            //    ArrayList alTemp = objQuit as ArrayList;

            //    if (this.backType == "PACKAGE")
            //    {
            //        foreach (FeeItemList item in alTemp)
            //        {
            //            Neusoft.HISFC.Models.Fee.Item.UndrugComb info = null;

            //            foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb in this.currentUndrugCombs)
            //            {
            //                if (undrugComb.ID == item.ID)
            //                {
            //                    info = undrugComb;

            //                    break;
            //                }
            //            }

            //            if (info == null)
            //            {
            //                MessageBox.Show("新维护的组套中没有" + item.Item.Name + "请执行全退");

            //                return -1;
            //            }

            //            #region 处理明细

            //            FeeItemList f = item;
            //            if (f.FeePack == "1")//包装单位
            //            {
            //                if (quitQty * info.Qty > f.NoBackQty / f.Item.PackQty)
            //                {
            //                    MessageBox.Show("输入的数量大于可退数量!");
            //                    this.txtReturnNum.SelectAll();
            //                    this.txtReturnNum.Focus();

            //                    return -1;
            //                }
            //            }
            //            else
            //            {
            //                if (quitQty * info.Qty > f.NoBackQty)
            //                {
            //                    MessageBox.Show("输入的数量大于可退数量!");
            //                    this.txtReturnNum.SelectAll();
            //                    this.txtReturnNum.Focus();

            //                    return -1;
            //                }
            //            }
            //            int currRow = 0;
            //            if (!f.Item.IsPharmacy)
            //            {
            //                currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);
            //                if (currRow == -1)
            //                {
            //                    MessageBox.Show("查找非药品失败！");

            //                    return -1;
            //                }
            //            }

            //            f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * info.Qty : quitQty * info.Qty);
            //            f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * info.Qty : quitQty * info.Qty);
            //            f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);

            //            if (!f.Item.IsPharmacy) //非药品
            //            {
            //                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
            //                //没有找到，那么新增一条;
            //                if (findRow == -1)
            //                {
            //                    findRow = FindNullRow(this.fpSpread2_Sheet2);

            //                    FeeItemList fClone = f.Clone();
            //                    fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty * info.Qty : quitQty * info.Qty;

            //                    this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
            //                }
            //                else //找到了累加数量
            //                {
            //                    FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
            //                    fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty * info.Qty : quitQty * info.Qty);
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
            //                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
            //                }

            //                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
            //                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
            //                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = f.FeePack == "1" ?
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
            //            }

            //            #endregion
            //        }
            //    }
            //    if (this.backType == "PCC")
            //    {
            //        foreach (FeeItemList item in alTemp)
            //        {
            //            #region 处理明细

            //            FeeItemList f = item;
            //            if (f.FeePack == "1")//包装单位
            //            {
            //                if (quitQty * f.Order.DoseOnce > f.NoBackQty / f.Item.PackQty)
            //                {
            //                    MessageBox.Show("输入的数量大于可退数量!");
            //                    this.txtReturnNum.SelectAll();
            //                    this.txtReturnNum.Focus();

            //                    return -1;
            //                }
            //            }
            //            else
            //            {
            //                if (quitQty * f.Order.DoseOnce > f.NoBackQty)
            //                {
            //                    MessageBox.Show("输入的数量大于可退数量!");
            //                    this.txtReturnNum.SelectAll();
            //                    this.txtReturnNum.Focus();

            //                    return -1;
            //                }
            //            }
            //            int currRow = 0;
            //            if (f.Item.IsPharmacy)
            //            {
            //                currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);
            //                if (currRow == -1)
            //                {
            //                    MessageBox.Show("查找药品失败！");

            //                    return -1;
            //                }
            //            }

            //            f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce);
            //            f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce);
            //            f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);

            //            if (f.Item.IsPharmacy) //非药品
            //            {
            //                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
            //                //没有找到，那么新增一条;
            //                if (findRow == -1)
            //                {
            //                    findRow = FindNullRow(this.fpSpread2_Sheet1);

            //                    FeeItemList fClone = f.Clone();
            //                    fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce;

            //                    this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
            //                }
            //                else //找到了累加数量
            //                {
            //                    FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
            //                    fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty * fFind.Order.DoseOnce : quitQty * fFind.Order.DoseOnce);
            //                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
            //                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
            //                }

            //                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
            //                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
            //                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = f.FeePack == "1" ?
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
            //                    Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
            //            }

            //            #endregion
            //        }
            //    }
            //}

            #endregion

            this.fpSpread1.Select();
            this.fpSpread1.Focus();
            if (this.fpSpread1.ActiveSheet.RowCount > 0)
            {
                this.fpSpread1.ActiveSheet.ActiveRowIndex = 0;
            }

            return 1;
        }

        #endregion

        #endregion

        #region 事件

        #region {34AF8368-3186-4ce3-B89A-6035B66FCF88} 门诊退费申请读卡操作 by guanyx
        /// <summary>
        /// 读卡事件
        /// </summary>
        private event System.EventHandler ReadCardEvent;
        #endregion

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            base.tbQuitCost.Visible = false;
            base.tbReturnCost.Visible = false;
            base.tbQuitCash.Visible = false;
            base.lbLeftCost.Visible = false;
            base.lbQuitCash.Visible = false;
            base.lbReturnCost.Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)DrugList.Cost].Visible = false;
            this.fpSpread1_Sheet2.Columns[(int)UndrugList.Cost].Visible = false;
            
            this.FindForm().Text = "退费申请";
            
            toolBarService.AddToolButton("保存申请", "保存申请信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            #region {34AF8368-3186-4ce3-B89A-6035B66FCF88} 门诊退费申请读卡操作 by guanyx
            ReadCardEvent += new EventHandler(ucQuitItemApply_ReadCardEvent);
            toolBarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            #endregion
            this.neuTabControl1.TabPages.Remove(tpFee);

            return toolBarService;
        }
        #region {34AF8368-3186-4ce3-B89A-6035B66FCF88} 门诊退费申请读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucQuitItemApply_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.tbCardNo.Text = cardno;
                    this.tbCardNo_KeyDown(this.tbCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "保存申请":
                    this.Save();
                    break;
                case "清屏":
                    this.Clear();
                    break;
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override void tbCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string markNO = this.tbCardNo.Text.Trim();
            if (string.IsNullOrEmpty(markNO))
            {
                MessageBox.Show("请输入就诊卡号！");
                this.tbCardNo.Focus();
                return;
            }
            Neusoft.HISFC.Models.RADT.PatientInfo p = null;
            Neusoft.HISFC.Models.Account.AccountCard accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
            if (feeIntegrate.ValidMarkNO(markNO, ref accountCard) <= 0)
            {
                markNO = markNO.PadLeft(10, '0');
                p = radtIntegrate.QueryComPatientInfo(markNO);
            }
            else
            {
                p = accountCard.Patient;
            }
            if (p != null && !string.IsNullOrEmpty(p.PID.CardNO))
            {
                GetFeeList(p);
            }
            else
            {
                MessageBox.Show("查询患者信息失败！");
            }
        }
        #endregion

        #region 直接收费
        //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
        protected override int GetFeeList(Neusoft.HISFC.Models.RADT.PatientInfo p)
        {
            DateTime beginTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;
            int returnValues = Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref beginTime, ref endTime);
            if (returnValues < 0)
            {
                return -1;
            }

            this.patient.PID = p.PID;
            this.patient.Name = p.Name;
            this.patient.Pact = p.Pact;
            this.patient.Birthday = p.Birthday;
            this.patient.Sex = p.Sex;

            FT ft = new FT();
            if (GetList(p.PID.CardNO, beginTime, endTime, ref ft) < 0)
            {
                return -1;
            }
            this.tbName.Text = p.Name;
            this.tbPactName.Text = p.Pact.Name;
            this.tbPayCost.Text = ft.PayCost.ToString();
            this.tbOwnCost.Text = ft.OwnCost.ToString();
            this.tbPubCost.Text = ft.PubCost.ToString();
            this.tbTotCost.Text = ft.TotCost.ToString();
            return 1;
            
        }

        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int GetList(string cardNO, DateTime beginDate, DateTime endDate, ref FT ft)
        {

            //药品列表
            ArrayList drugItemLists = new ArrayList();

            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Pharmarcy)
            {
                //通过发票序列号,获得所有应参与退费的药品信息
                drugItemLists = outpatientManager.GetDrugFeeByCardNODate(cardNO, beginDate, endDate, true);
                if (drugItemLists == null)
                {
                    MessageBox.Show("获得药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            //非药品信息
            ArrayList undrugItemLists = new ArrayList();

            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Undrug)
            {
                //通过发票序列号,获得所有应参与退费的非药品信息
                //undrugItemLists = outpatientManager.QueryUndrugFeeItemListByInvoiceSequence(tempBalance.CombNO);
                undrugItemLists = outpatientManager.GetDrugFeeByCardNODate(cardNO, beginDate, endDate, false);
                if (undrugItemLists == null)
                {
                    MessageBox.Show("获得非药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            if (drugItemLists.Count + undrugItemLists.Count == 0)
            {
                MessageBox.Show("没有费用信息!");

                return -1;
            }

            //this.invoiceFeeItemLists = outpatientManager.QueryFeeItemListsByInvoiceNO(tempBalance.Invoice.ID);

            ArrayList drugApplyedList = new ArrayList();//已经申请过的药品列表
            ArrayList undrugApplyedList = new ArrayList();//已经申请过的药品列表

            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Pharmarcy)
            {
                //drugApplyedList = base.returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "1");
                drugApplyedList = returnApplyManager.GetApplyReturn(cardNO, false, false, true);
                if (drugApplyedList == null)
                {
                    MessageBox.Show("获得申请药品项目列表出错!" + returnApplyManager.Err);

                    return -1;
                }
            }
            if (this.itemType == ItemTypes.All || this.itemType == ItemTypes.Undrug)
            {
                //undrugApplyedList = base.returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "0");
                undrugApplyedList = returnApplyManager.GetApplyReturn(cardNO, false, false, false);
                if (undrugApplyedList == null)
                {
                    MessageBox.Show("获得申请非药品项目列表出错!" + returnApplyManager.Err);

                    return -1;
                }
            }

            this.fpSpread1_Sheet1.RowCount = drugItemLists.Count;
            FeeItemList drugItemApply = null;

            for (int i = 0; i < drugItemLists.Count; i++)
            {
                drugItemApply = drugItemLists[i] as FeeItemList;

                this.fpSpread1_Sheet1.Rows[i].Tag = drugItemApply;
                //因为可能存在同一发票有不同看诊科室的情况,而且挂号信息中的看诊信息不一定与实际收费的看诊
                //科室相同,所以这里把挂号实体的看诊可是赋值为收费明细时的看诊科室信息.
                this.patient.DoctorInfo.Templet.Dept = drugItemApply.RecipeOper.Dept;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.ItemName].Text = drugItemApply.Item.Name;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.CombNo].Text = drugItemApply.Order.Combo.ID;

                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Specs].Text = drugItemApply.Item.Specs;
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text = drugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.Item.Qty / drugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.PriceUnit].Text = drugItemApply.Item.PriceUnit;
                this.fpSpread1_Sheet1.Cells[i, (int)DrugList.NoBackQty].Text = drugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.ConfirmedQty / drugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItemApply.ConfirmedQty, 2).ToString();

                if (drugItemApply.Item.SysClass.ID.ToString() == "PCC")
                {
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItemApply.Order.DoseOnce.ToString() + drugItemApply.Order.DoseUnit + " " + "付数:" + drugItemApply.Days.ToString();
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItemApply.Order.DoseOnce.ToString() + drugItemApply.Order.DoseUnit;
                }

                ft.TotCost += drugItemApply.FT.OwnCost + drugItemApply.FT.PubCost + drugItemApply.FT.PayCost;
                ft.OwnCost += drugItemApply.FT.OwnCost;
                ft.PubCost += drugItemApply.FT.PubCost;
                ft.PayCost += drugItemApply.FT.PayCost;

                Class.Function.DrawCombo(this.fpSpread1_Sheet1, (int)DrugList.CombNo, (int)DrugList.Comb, 0);
            }

            //显示非药品信息
            this.fpSpread1_Sheet2.RowCount = undrugItemLists.Count;

            FeeItemList undrugItemApply = null;
            for (int i = 0; i < undrugItemLists.Count; i++)
            {
                undrugItemApply = undrugItemLists[i] as FeeItemList;

                this.fpSpread1_Sheet2.Rows[i].Tag = undrugItemApply;
                this.patient.DoctorInfo.Templet.Dept = undrugItemApply.RecipeOper.Dept;

                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.ItemName].Text = undrugItemApply.Item.Name;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.CombNo].Text = undrugItemApply.Order.Combo.ID;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text = undrugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.Item.Qty / undrugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PriceUnit].Text = undrugItemApply.Item.PriceUnit;
                this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.NoBackQty].Text = undrugItemApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.ConfirmedQty / undrugItemApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItemApply.ConfirmedQty, 2).ToString();

                if (undrugItemApply.UndrugComb.ID != null && undrugItemApply.UndrugComb.ID.Length > 0)
                {
                    this.undrugComb = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.UndrugComb.ID);
                    if (this.undrugComb == null)
                    {
                        MessageBox.Show("获得组套信息出错，无法显示组套自定义码，但是不影响退费操作！");
                    }
                    else
                    {
                        undrugItemApply.UndrugComb.UserCode = this.undrugComb.UserCode;
                    }

                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.ID);

                    if (item == null)
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItemApply.UndrugComb.UserCode + ")" + undrugItemApply.UndrugComb.Name;
                    }
                    else
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItemApply.UndrugComb.UserCode + ")" + undrugItemApply.UndrugComb.Name + "[" + item.UserCode + "]";
                    }

                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItemApply.ID);

                    if (item != null)
                    {
                        this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = item.UserCode;
                    }
                }
                ft.TotCost += undrugItemApply.FT.OwnCost + undrugItemApply.FT.PubCost + undrugItemApply.FT.PayCost;
                ft.OwnCost += undrugItemApply.FT.OwnCost;
                ft.PubCost += undrugItemApply.FT.PubCost;
                ft.PayCost += undrugItemApply.FT.PayCost;
                Class.Function.DrawCombo(this.fpSpread1_Sheet2, (int)UndrugList.CombNo, (int)UndrugList.Comb, 0);
            }

            //显示确认退药信息
            this.fpSpread2_Sheet1.RowCount = 0;
            this.fpSpread2_Sheet1.RowCount = drugItemLists.Count + drugApplyedList.Count;
            Neusoft.HISFC.Models.Fee.ReturnApply drugReturnApply = null;
            for (int i = 0; i < drugApplyedList.Count; i++)
            {
                drugReturnApply = drugApplyedList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                #region 如果是审核界面，将已经审核过的药品过滤{CBDB919E-D2A3-4a39-8B66-9642AC706658}
                if (isConfirmWindow)
                {
                    //判断是否发药 
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList = this.outpatientManager.GetFeeItemListBalanced(drugReturnApply.RecipeNO, drugReturnApply.SequenceNO);
                    if (feeItemList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(drugReturnApply.Item.Name + "获得项目失败!" + this.outpatientManager.Err);

                        return -1;
                    }
                    ///已经审核过的，确认数量为0
                    if (feeItemList.ConfirmedQty == 0)
                    {
                        continue;
                    }
                }
                #endregion

                int findRow = FindItem(drugReturnApply.RecipeNO, drugReturnApply.SequenceNO, this.fpSpread1_Sheet1);
                if (findRow == -1)
                {
                    //MessageBox.Show("查找未退药项目出错!");

                    //return -1;
                    continue;
                }

                this.fpSpread2_Sheet1.Rows[i].Tag = drugReturnApply;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.ItemName].Text = drugReturnApply.Item.Name;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Amount].Text = drugReturnApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugReturnApply.Item.Qty / drugReturnApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugReturnApply.Item.Qty, 2).ToString();
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.PriceUnit].Text = drugReturnApply.Item.PriceUnit;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Specs].Text = drugReturnApply.Item.Specs;
                this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Flag].Text = "申请";

                
                FeeItemList modifyDrug = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;

                modifyDrug.ConfirmedQty = modifyDrug.ConfirmedQty - drugReturnApply.Item.Qty;

                this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = modifyDrug.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.ConfirmedQty / modifyDrug.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.ConfirmedQty, 2).ToString();
            }

            this.fpSpread2_Sheet2.RowCount = 0;
            this.fpSpread2_Sheet2.RowCount = undrugItemLists.Count + undrugApplyedList.Count;
            Neusoft.HISFC.Models.Fee.ReturnApply undrugReturnApply = null;
            for (int i = 0; i < undrugApplyedList.Count; i++)
            {
                undrugReturnApply = undrugApplyedList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;

                int findRow = FindItem(undrugReturnApply.RecipeNO, undrugReturnApply.SequenceNO, this.fpSpread1_Sheet2);
                if (findRow == -1)
                {
                    //MessageBox.Show("查找未退非药项目出错!");

                    continue;
                }

                this.fpSpread2_Sheet2.Rows[i].Tag = undrugReturnApply;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.ItemName].Text = undrugReturnApply.Item.Name;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Amount].Text = undrugReturnApply.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugReturnApply.Item.Qty / undrugReturnApply.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugReturnApply.Item.Qty, 2).ToString();
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.PriceUnit].Text = undrugReturnApply.Item.PriceUnit;
                this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Flag].Text = "申请";

                
                FeeItemList modifyUndrug = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;

                modifyUndrug.ConfirmedQty = modifyUndrug.ConfirmedQty - undrugReturnApply.Item.Qty;

                this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = modifyUndrug.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.ConfirmedQty / modifyUndrug.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.ConfirmedQty, 2).ToString();

            }

            return 1;
        }
        #endregion
    }
}
