using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.Out
{
    public class BackOutPriv : IMatManager
    {
        public BackOutPriv(Out.ucMatOut ucMatOutManager)
        {
            this.SetMatManagerProperty(ucMatOutManager);
        }

        #region 域变量

        private Material.Out.ucMatOut outManager = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.TextCellType tReadOnly = new FarPoint.Win.Spread.CellType.TextCellType();

        Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

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
        /// 存储已添加的项目信息 防止重复添加
        /// </summary>
        private System.Collections.Hashtable hsItemData = new Hashtable();

        /// <summary>
        /// 是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = true;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private List<Neusoft.HISFC.Models.Material.Output> alOutPut = null;

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        private Neusoft.HISFC.BizLogic.Material.Baseset matConstant = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucMatListSelect ucListSelect = null;
        private Neusoft.HISFC.Models.Material.Apply currApply = new Neusoft.HISFC.Models.Material.Apply();
        #endregion

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns></returns>
        private string GetKey()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        private string GetKey(Neusoft.HISFC.Models.Material.Output output)
        {
            return output.User03;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        private string GetKey(FarPoint.Win.Spread.SheetView sv, int iRowIndex)
        {
            return sv.Cells[iRowIndex, (int)ColumnSet.ColKey].Text;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        private string[] GetFindKey(FarPoint.Win.Spread.SheetView sv, int iRowIndex)
        {
            return new string[] { sv.Cells[iRowIndex, (int)ColumnSet.ColKey].Text };
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        private string GetKey(DataRow dr)
        {
            return dr["主键"].ToString();
        }

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        private void SetMatManagerProperty(Out.ucMatOut ucOutManager)
        {
            this.outManager = ucOutManager;

            if (this.outManager != null)
            {
                //设置界面显示
                this.outManager.IsShowInputPanel = false;
                this.outManager.IsShowItemSelectpanel = false;
                //设置目标科室信息 目标人员信息
                this.outManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                this.outManager.SetTargetPerson(true, Neusoft.HISFC.Models.Base.EnumEmployeeType.P);
                //设置工具栏按钮显示
                this.outManager.SetToolBarButton(true, false, true, false, true);
                this.outManager.SetToolBarButtonVisible(true, false, true, false, false, true, false);
                //设置显示的待选择数据
                this.outManager.SetSelectData("2", false, null, null, null);
                //设置显示信息
                this.outManager.ShowInfo = "";

                this.outManager.Fp.EditModeReplace = true;
                this.outManager.FpSheetView.DataAutoSizeColumns = false;

                this.outManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);
                this.outManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);

                this.outManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.outManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.SetFormat();

                this.outManager.SetItemListWidth(3);
            }
        }

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Material.Output output, decimal backQty)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal outQty = 0;             //申请数量
                decimal storeQty = 0;           //库存量
                decimal backCost = 0;

                output.StoreBase.Quantity = output.StoreBase.Quantity - output.StoreBase.Returns;

                if (this.isUseMinUnit)
                {
                    outQty = output.StoreBase.Quantity;
                    storeQty = output.StoreBase.StoreQty;
                    output.StoreBase.StoreCost = storeQty * output.StoreBase.PriceCollection.RetailPrice;
                    if (backQty == 0)
                    {
                        backQty = outQty;
                    }
                    backCost = backQty * output.StoreBase.PriceCollection.RetailPrice;
                    output.StoreBase.RetailCost = outQty * output.StoreBase.PriceCollection.RetailPrice;
                }
                else
                {
                    outQty = output.StoreBase.Quantity / output.StoreBase.Item.PackQty;
                    storeQty = output.StoreBase.StoreQty / output.StoreBase.Item.PackQty;
                    output.StoreBase.StoreCost = output.StoreBase.StoreQty * output.StoreBase.PriceCollection.RetailPrice;
                    if (backQty == 0)
                    {
                        backQty = outQty / output.StoreBase.Item.PackQty;
                    }
                    else
                    {
                        backQty = backQty / output.StoreBase.Item.PackQty;
                    }
                    backCost = backQty * output.StoreBase.Item.PackQty * output.StoreBase.PriceCollection.PurchasePrice;
                    output.StoreBase.RetailCost = outQty * output.StoreBase.Item.PackQty * output.StoreBase.PriceCollection.RetailPrice;
                }

                this.dt.Rows.Add(new object[] { 
												  true,
												  output.StoreBase.Item.Name,                            //物品名称
												  output.StoreBase.Item.Specs,                           //规格
												  output.StoreBase.BatchNO,                              //批号												 
												  output.StoreBase.PriceCollection.RetailPrice,			 //零售价
												  output.StoreBase.Item.PackUnit,                        //包装单位
												  output.StoreBase.Item.MinUnit,                         //最小单位
												  storeQty,												            //库存数量
												  outQty,												             //出库数量
												  backCost,
												  backQty,												             //退库数量
												  backCost,												             //退库金额
												  output.Memo,											            //备注
                                                  output.StoreBase.State,                                     //库存状态
												  output.StoreBase.Item.ID,                                 //物品编码
												  output.ID,										               //单据流水号
												  output.User01,										            //数据来源 0 手工 1 申请 2 出库
												  output.StoreBase.Item.SpellCode,						 //拼音码
												  output.StoreBase.Item.WBCode,						 //五笔码
												  output.StoreBase.Item.UserCode,						 //自定义码 
                                                  output.User03,                                                   //主键
                                                  output.StoreBase.StockNO                                 //库存序号       
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
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Material.Output output)
        {
            return AddDataToTable(output, 0);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public virtual void SetFormat()
        {
            this.tReadOnly.ReadOnly = true;

            this.outManager.FpSheetView.DefaultStyle.Locked = true;
            this.outManager.FpSheetView.DataAutoSizeColumns = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Width = 40F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnCost].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 40F;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnCost].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Visible = true;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //物品编码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColBillNO].Visible = false;              //物品编码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;      //数据来源
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;                  //主键
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColStockNO].Visible = false;            //库存序号
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColState].Visible = false;                      //状态

            if (this.isUseMinUnit)
            {
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            }
            else
            {
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;
            }

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].Locked = false;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].Locked = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnQty].BackColor = System.Drawing.Color.SeaShell;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].BackColor = System.Drawing.Color.SeaShell;
        }

        /// <summary>
        /// 返回本张单据差额
        /// </summary>
        public virtual void CompuateSum()
        {
            decimal retailCost = 0;

            if (this.dt != null)
            {
                for (int i = 0; i < this.outManager.FpSheetView.Rows.Count; i++)
                {
                    retailCost = NConvert.ToDecimal(this.outManager.FpSheetView.Cells[i, (int)ColumnSet.ColReturnCost].Text);
                }
                this.outManager.TotCostInfo = string.Format("退库金额:{0}", retailCost.ToString("C4"));
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
            #region 加载出库申请数据
            ArrayList al = this.storeManager.QueryApplyDetailByListNO(this.targeDept.ID, listCode, "0");
            if (al == null)
            {
                System.Windows.Forms.MessageBox.Show("未正确获取外部入库申请信息" + this.storeManager.Err);
                return -1;
            }

            this.Clear();

            Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

            foreach (Neusoft.HISFC.Models.Material.Apply apply in al)
            {
                Neusoft.HISFC.Models.Material.Output output = this.storeManager.GetOutputDetailByID(apply.OutNo, apply.StockNO);
                Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();

                item = this.itemManager.GetMetItemByMetID(apply.Item.ID);

                if (output.StoreBase.Item == null)
                {
                    MessageBox.Show("加载申请时 根据物资编码检索物资项目字典信息失败" + apply.Item.ID);
                    return -1;
                }

                output.StoreBase.Item = item;

                output.StoreBase.Quantity = apply.Operation.ApplyQty;			 //申请量
                output.Memo = apply.Memo;										 //备注信息

                decimal storeQty = 0;
                if (this.storeManager.GetStoreQty(this.outManager.DeptInfo.ID, apply.Item.ID, out storeQty) == -1)
                {
                    MessageBox.Show("获取" + apply.Item.Name + "库存数量时发生错误" + this.itemManager.Err);
                    return -1;
                }

                output.StoreBase.StoreQty = storeQty;							 //库存量

                output.StoreBase.PrivType = this.outManager.PrivType.ID;		 //出库类型
                output.StoreBase.SystemType = this.outManager.PrivType.Memo;     //系统类型
                output.StoreBase.StockDept = this.outManager.DeptInfo;			 //当前科室
                output.StoreBase.TargetDept = this.outManager.TargetDept;		 //目标科室
                output.StoreBase.PriceCollection.PurchasePrice = item.UnitPrice;
                output.StoreBase.PriceCollection.RetailPrice = item.UnitPrice;
                //				output.StoreBase.Quantity = apply.OutQty;

                output.User01 = "1";											//数据来源 申请
                output.User02 = apply.ID;										//申请单流水号

                output.User03 = this.GetKey();									//设置主键

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(output.User03, output);

                    this.hsApplyData.Add(apply.ID, apply);

                    this.hsItemData.Add(output.StoreBase.Item.ID, null);			//设置已添加项目
                }
            }

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).EndInit();

            //计算汇总出库金额
            this.CompuateSum();
            return 1;
            #endregion
        }

        #region 根据申请退库的物品编码自动分配 屏蔽
        /// <summary>
        /// 增加申请数据--根据申请退库的物品编码自动分配
        /// </summary>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回1 </失败返回-1returns>
        //protected virtual int AddApplyData(string listCode, string state)
        //{
        //    #region 加载出库申请数据
        //    ArrayList al = this.storeManager.QueryApplyDetailByListNO(this.targeDept.ID, listCode, "0");
        //    if (al == null)
        //    {
        //        System.Windows.Forms.MessageBox.Show("未正确获取外部入库申请信息" + this.storeManager.Err);
        //        return -1;
        //    }

        //    this.Clear();

        //    Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        //    foreach (Neusoft.HISFC.Models.Material.Apply apply in al)
        //    {
        //        //出库科室，入库科室，物品编码 获取出库记录
        //        List<Neusoft.HISFC.Models.Material.Output> outputList = this.storeManager.QueryOutputByDeptAndItem(apply.TargetDept.ID, apply.StockDept.ID, apply.Item.ID);
        //        if (outputList == null)
        //        {
        //            MessageBox.Show("获取出库信息失败" + this.storeManager.Err);
        //            return -1;
        //        }
        //        //该物品可退的出库记录
        //        List<Neusoft.HISFC.Models.Material.Output> outputListForBack = new List<Neusoft.HISFC.Models.Material.Output>();
        //        //取可退的出库记录
        //        foreach (Neusoft.HISFC.Models.Material.Output tmpOutput in outputList)
        //        {
        //            //出库数量大于已退数量
        //            if (tmpOutput.StoreBase.Quantity > tmpOutput.StoreBase.Returns)
        //            {
        //                //正记录
        //                if (tmpOutput.StoreBase.Quantity > 0)
        //                {
        //                    outputListForBack.Add(tmpOutput);
        //                }
        //            }
        //        }
        //        decimal applyQty = apply.Operation.ApplyQty;
        //        foreach (Neusoft.HISFC.Models.Material.Output tmpOutput in outputListForBack)
        //        {
        //            #region 入库实体赋值等操作
        //            //对出库数量为零的数据不显示
        //            if (tmpOutput.StoreBase.Quantity == 0)
        //            {
        //                continue;
        //            }

        //            decimal storeQty = 0;
        //            if (this.storeManager.GetStoreQty(this.outManager.DeptInfo.ID, tmpOutput.StoreBase.Item.ID, tmpOutput.StoreBase.StockNO, out storeQty) == -1)
        //            {
        //                MessageBox.Show("获取库存数量时出错!" + this.storeManager.Err);
        //                return -1;
        //            }
        //            tmpOutput.StoreBase.StoreQty = storeQty;

        //            Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();
        //            item = this.itemManager.GetMetItemByMetID(tmpOutput.StoreBase.Item.ID);
        //            tmpOutput.StoreBase.Item = item;

        //            tmpOutput.StoreBase.PrivType = this.outManager.PrivType.ID;           //出库类型
        //            tmpOutput.StoreBase.SystemType = this.outManager.PrivType.Memo;       //系统类型
        //            tmpOutput.StoreBase.StockDept = this.outManager.DeptInfo;             //当前科室
        //            tmpOutput.StoreBase.TargetDept = this.outManager.TargetDept;          //目标科室 

        //            tmpOutput.User01 = "2";											   //数据来源 出库单

        //            tmpOutput.User03 = this.GetKey();
        //            #endregion

        //            if ((tmpOutput.StoreBase.Quantity - tmpOutput.StoreBase.Returns) > applyQty)
        //            {
        //                if (this.AddDataToTable(tmpOutput, applyQty) == 1)
        //                {
        //                    this.hsOutData.Add(this.GetKey(tmpOutput), tmpOutput);
        //                    applyQty = 0;
        //                    break;
        //                }
        //                else
        //                {
        //                    return -1;
        //                }
        //            }
        //            else
        //            {
        //                if (this.AddDataToTable(tmpOutput, tmpOutput.StoreBase.Quantity - tmpOutput.StoreBase.Returns) == 1)
        //                {
        //                    this.hsOutData.Add(this.GetKey(tmpOutput), tmpOutput);
        //                    applyQty = applyQty - (tmpOutput.StoreBase.Quantity - tmpOutput.StoreBase.Returns);
        //                }
        //                else
        //                {
        //                    return -1;
        //                }
        //            }
        //        }
        //        if (applyQty > 0)
        //        {
        //            MessageBox.Show("申请退库数量大于可退数量!");
        //            this.Clear();
        //            return -1;
        //        }
        //    }

        //    ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).EndInit();

        //    //计算汇总出库金额
        //    this.CompuateSum();
        //    return 1;
        //    #endregion
        //}
        #endregion

        /// <summary>
        /// 增加出库数据
        /// </summary>
        /// <param name="listCode"></param>
        /// <param name="state"></param>
        private void AddOutData(string listCode, string state)
        {
            this.Clear();

            List<Neusoft.HISFC.Models.Material.Output> alDetail = this.storeManager.QueryOutputByListNO(this.outManager.DeptInfo.ID, listCode, state);
            if (alDetail == null)
            {
                MessageBox.Show(this.storeManager.Err);
                return;
            }
            //对已审批但未核准入库的单据可以部分退库 by yuyun {8764C351-D36D-4331-B21B-8E7D4847D260}
            //if (state == "1" && alDetail.Count > 0)
            //{
            //    MessageBox.Show(Language.Msg("审批状态的单据已扣减自身库存 未增加对方科室库存 \n\n此时退库 必须按原出库数据全额退库"), "出库退库操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //}

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据单号加载出库数据 请稍候...");
            Application.DoEvents();

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Material.Output output in alDetail)
            {
                //对出库数量为零的数据不显示
                if (output.StoreBase.Quantity == 0)
                {
                    continue;
                }

                decimal storeQty = 0;
                if (this.storeManager.GetStoreQty(this.outManager.DeptInfo.ID, output.StoreBase.Item.ID, output.StoreBase.StockNO, out storeQty) == -1)
                {
                    MessageBox.Show("获取库存数量时出错!" + this.storeManager.Err);
                    return;
                }
                output.StoreBase.StoreQty = storeQty;

                Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();
                item = this.itemManager.GetMetItemByMetID(output.StoreBase.Item.ID);
                output.StoreBase.Item = item;

                output.StoreBase.PrivType = this.outManager.PrivType.ID;           //出库类型
                output.StoreBase.SystemType = this.outManager.PrivType.Memo;       //系统类型
                output.StoreBase.StockDept = this.outManager.DeptInfo;             //当前科室
                output.StoreBase.TargetDept = this.outManager.TargetDept;          //目标科室 

                output.User01 = "2";											   //数据来源 出库单

                output.User03 = this.GetKey();

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(this.GetKey(output), output);
                }
            }
            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //计算汇总出库金额
            this.CompuateSum();
        }

        #region IMatManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                // TODO:  添加 BackOutPriv.InputModualUC getter 实现
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
												 new DataColumn("审批",      dtBol),
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),
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
												 new DataColumn("物品编码",  dtStr),
												 new DataColumn("流水号",    dtStr),
												 new DataColumn("数据来源",  dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr),
                                                 new DataColumn("主键",          dtStr),
                                                 new DataColumn("库存序号",  dtStr)
											 }
                );

            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["主键"];
            //keys[0] = this.dt.Columns["流水号"];
            //keys[1] = this.dt.Columns["批号"];


            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            // TODO:  添加 BackOutPriv.AddItem 实现
            return 1;
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
            #region 获取出库申请列表

            /*获取出库退库信息*/
            ArrayList alAllList = this.storeManager.QueryApplyInListByTargetDept(this.outManager.DeptInfo.ID, "18", "0");
            if (alAllList == null)
            {
                MessageBox.Show("获取出库申请列表发生错误" + this.storeManager.Err);
                return -1;
            }

            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();

            foreach (Neusoft.HISFC.Models.Material.Apply app in alAllList)
            {
                try
                {
                    app.StockDept.Name = deptMgr.GetDeptmentById(app.StockDept.ID).Name;
                    app.Name = deptMgr.GetDeptmentById(app.StockDept.ID).Name;
                    app.ID = app.ApplyListNO;
                }
                catch
                { }
            }

            /*弹出窗口选择单据*/
            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] fpLabel = { "申请单号", "申请科室" };
            float[] fpWidth = { 120F, 120F };
            bool[] fpVisible = { true, true, false, false, false, false };

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alAllList, ref selectObj) == 1)
            {
                this.Clear();

                this.currApply = (selectObj as Neusoft.HISFC.Models.Material.Apply);
                targeDept.ID = (selectObj as Neusoft.HISFC.Models.Material.Apply).StockDept.ID;              //申请科室编码
                targeDept.Name = selectObj.Name;            //申请科室名称
                targeDept.Memo = "0";                       //目标单位性质 内部科室               

                this.AddApplyData(selectObj.ID, "0");

                this.SetFocusSelect();

                if (this.outManager.FpSheetView != null)
                    this.outManager.FpSheetView.ActiveRowIndex = 0;
            }

            return 1;

            #endregion
        }

        public int ShowInList()
        {
            // TODO:  添加 BackOutPriv.ShowInList 实现
            return 1;
        }

        public int ShowOutList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucMatListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.outManager.DeptInfo;
                this.ucListSelect.State = "2";                  //需检索状态
                this.ucListSelect.Class2Priv = "0520";          //出库

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

        public int ShowStockList()
        {
            throw new Exception("The method or operation is not implemented.");
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

                if (NConvert.ToDecimal(dr["退库数量"]) < 0)
                {
                    MessageBox.Show(dr["物品名称"].ToString() + " 退库数量不能为小于零");
                    return false;
                }

                if (NConvert.ToDecimal(dr["出库数量"]) < NConvert.ToDecimal(dr["退库数量"]))
                {
                    MessageBox.Show(dr["物品名称"].ToString() + " 退库数量不能大于出库数量");
                    return false;
                }
                //对已审批但未核准入库的单据可以部分退库 by yuyun {8764C351-D36D-4331-B21B-8E7D4847D260}
                //if (dr["状态"].ToString() == "1")       //审批状态的单
                //{
                //    if (NConvert.ToDecimal(dr["出库数量"]) != NConvert.ToDecimal(dr["退库数量"]))
                //    {
                //        MessageBox.Show(Language.Msg("本单未经对方核准 退库时 " + dr["物品名称"].ToString() + " 的退库数量只能为出库数量"), "出库退库操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        dr["退库数量"] = dr["出库数量"];
                //        return false;
                //    }
                //}
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
													sv.Cells[delRowIndex, (int)ColumnSet.ColBillNO].Text//,
													//sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
												};
                    DataRow dr = this.dt.Rows.Find(this.GetFindKey(sv, delRowIndex));
                    if (dr != null)
                    {
                        this.outManager.Fp.StopCellEditing();

                        if (dr["数据来源"].ToString() == "1")
                        {
                            //Neusoft.HISFC.Models.Material.Output delOutput = this.hsOutData[dr["物品编码"].ToString() + dr["批号"].ToString()] as Neusoft.HISFC.Models.Material.Output;
                            Neusoft.HISFC.Models.Material.Output delOutput = this.hsOutData[this.GetKey(dr)] as Neusoft.HISFC.Models.Material.Output;
                            if (this.hsApplyData.ContainsKey(delOutput.User02))
                            {
                                this.hsApplyData.Remove(delOutput.User02);//.User02);
                            }
                        }

                        //this.hsOutData.Remove(dr["物品编码"].ToString() + dr["批号"].ToString());
                        this.hsOutData.Remove(this.GetKey(dr));

                        this.dt.Rows.Remove(dr);

                        this.outManager.Fp.StartCellEditing(null, false);
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

                this.hsOutData.Clear();
                //清除申请信息
                this.hsApplyData.Clear();

                this.hsItemData.Clear();

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
            if (this.outManager.FpSheetView != null)
            {
                if (this.outManager.FpSheetView.Rows.Count > 0)
                {
                    this.outManager.SetFpFocus();

                    this.outManager.FpSheetView.ActiveRowIndex = this.outManager.FpSheetView.Rows.Count - 1;
                    this.outManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColReturnQty;
                }
                else
                {
                    this.outManager.SetFocus();
                }
            }
        }

        public void Save()
        {
            if (this.outManager.TargetDept.ID == "")
            {
                MessageBox.Show("请设置退库目标科室");
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnCost].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            #endregion

            DialogResult rs = MessageBox.Show("确认向" + this.outManager.TargetDept.Name + "进行退库操作吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义
            Neusoft.HISFC.BizLogic.Material.Store phaCons = new Neusoft.HISFC.BizLogic.Material.Store();
            //Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //phaIntegrate.SetTrans(t.Trans);
            //phaCons.SetTrans(t.Trans);

            #endregion

            //是否进行了保存操作
            bool isSaved = false;
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            #region 获取出库单据号
            string outListNO = this.storeManager.GetOutListNO(this.outManager.DeptInfo.ID);
            if (outListNO == "")
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                System.Windows.Forms.MessageBox.Show("获取最新出库单据号出错" + this.storeManager.Err);
                return;
            }
            #endregion

            #region 获取出库流水号
            string outputID = this.storeManager.GetNewOutputID();
            if (outputID == "")
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                System.Windows.Forms.MessageBox.Show("获取最新出库单流水号出错" + this.storeManager.Err);
                return;
            }
            #endregion

            int serialNO = 0;
            this.alOutPut = new List<Neusoft.HISFC.Models.Material.Output>();

            Neusoft.HISFC.Models.Material.MaterialStorage matStorage = matConstant.QueryStorageInfo(this.outManager.TargetDept.ID);
            if (matStorage == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                System.Windows.Forms.MessageBox.Show("获取" + this.outManager.TargetDept.Name + "(" + this.outManager.TargetDept.ID + ")" + "仓库科室信息失败：" + this.matConstant.Err);
                return;
            }

            bool isManagerStore;

            //目标科室不是仓库科室的话不管理库存
            if (string.IsNullOrEmpty(matStorage.Name))
            {
                isManagerStore = false;
            }
            else
            {
                //判断领用科室是否管理库存
                isManagerStore = matStorage.IsStoreManage;
            }

            //是否处理领用科室(退库科室)入库记录
            bool isManagerInput = true;


            foreach (DataRow dr in dtAddMofity.Rows)
            {
                //对退库数量为零的不进行退库处理
                if (NConvert.ToDecimal(dr["退库数量"]) == 0)
                    continue;

                //string key = dr["流水号"].ToString();

                Neusoft.HISFC.Models.Material.Output output = (this.hsOutData[this.GetKey(dr)] as Neusoft.HISFC.Models.Material.Output).Clone();

                if (output.StoreBase.Quantity == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(Language.Msg("该条出库数据已全部进行了退库 请选择其他信息进行退库"));
                    return;
                }

                isSaved = true;

                if (this.isUseMinUnit)       //最小单位
                {
                    output.StoreBase.Quantity = -NConvert.ToDecimal(dr["退库数量"]);
                }
                else
                {
                    output.StoreBase.Quantity = -NConvert.ToDecimal(dr["退库数量"]) * output.StoreBase.Item.PackQty;
                }

                //是否处理领药科室入库记录 
                if (output.StoreBase.State == "2")    //对核准记录的出库退库
                {
                    isManagerInput = isManagerStore;        //是否处理退库 根据是否管理库存判断
                }
                else                       //对审批记录的出库退库
                {
                    isManagerInput = false;                 //此时还没有领药科室的入库记录 直接退自身
                }

                //对管理库存的科室且出库记录状态为"2" 的才进行库存判断
                if (isManagerStore && output.StoreBase.State == "2")         //对管理库存的目标科室判断是否存在库存
                {
                    #region 获取目标科室本批次当前库存 判断是否允许退库

                    decimal storeQty = 0;
                    this.storeManager.GetStoreQty(this.outManager.TargetDept.ID, output.StoreBase.Item.ID, output.StoreBase.StockNO, out storeQty);
                    if (storeQty < System.Math.Abs(output.StoreBase.Quantity))
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(Language.Msg(string.Format("{0} 在 {1}中库存数量不足 不能退库", output.StoreBase.Item.Name, this.outManager.TargetDept.Name)));
                        return;
                    }

                    #endregion
                }

                //审批信息
                output.OutCost = output.StoreBase.Quantity * output.StoreBase.PriceCollection.PurchasePrice;
                output.StoreBase.Operation.ExamQty = output.StoreBase.Quantity;
                output.StoreBase.Operation.ExamOper.ID = this.outManager.OperInfo.ID;
                output.StoreBase.Operation.ExamOper.OperTime = sysTime;

                //{258A905F-5EB4-4aa7-B2E7-8E803B76820A}
                output.StoreBase.Operation.Oper.OperTime = sysTime;
                output.StoreBase.Operation.Oper.ID = this.outManager.OperInfo.ID;

                if (isManagerStore)
                {
                    output.StoreBase.State = "1";     //状态变更为审批
                }
                else
                {
                    output.StoreBase.State = "2";     //状态变更为核准
                    //{258A905F-5EB4-4aa7-B2E7-8E803B76820A}
                    output.StoreBase.Operation.ApproveOper.ID = this.outManager.OperInfo.ID;
                    output.StoreBase.Operation.ApproveOper.OperTime = sysTime;
                }

                //根据不同数据来源对数据进行不同处理
                switch (dr["数据来源"].ToString())
                {
                    case "0":               //手工选择
                        break;
                    case "1":               //内部入库退库申请

                        #region 申请单
                        Neusoft.HISFC.Models.Material.Apply applyOut = this.hsApplyData[output.User02] as Neusoft.HISFC.Models.Material.Apply;

                        if (outListNO == "")
                            outListNO = applyOut.ApplyListNO;

                        applyOut.State = "2";
                        applyOut.Operation.ExamOper = output.StoreBase.Operation.ExamOper;
                        if (this.storeManager.UpdateApply(applyOut) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("更新" + output.StoreBase.Item.Name + "入库退库申请信息出错");
                            return;
                        }

                        break;
                        #endregion

                    case "2":               //出库单

                        #region 出库单

                        //if (outListNO == "")
                        //{
                        //    try
                        //    {
                        //        outListNO = this.storeManager.GetOutListNO(this.outManager.DeptInfo.ID);
                        //        if (outListNO == "")
                        //        {
                        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //            System.Windows.Forms.MessageBox.Show("获取最新出库单据号出错" + this.storeManager.Err);
                        //            return;
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //        return;
                        //    }

                        //}
                        break;

                        #endregion
                }
                string origOutputId = output.ID;
                output.ID = outputID;
                output.OutListNO = outListNO;       //出库单据号
                serialNO++;
                output.StoreBase.SerialNO = serialNO;

                if (this.storeManager.OutputBack(output.Clone(), origOutputId, isManagerInput) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    System.Windows.Forms.MessageBox.Show("保存退库信息时发生错误" + this.storeManager.Err);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                if (this.storeManager.UpdateApplyCheck(this.targeDept.ID, currApply.ApplyListNO, currApply.SerialNO, "P", this.storeManager.Operator.ID, this.storeManager.GetDateTimeFromSysDateTime()) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    System.Windows.Forms.MessageBox.Show("更新申请信息时发生错误" + this.storeManager.Err);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }

                alOutPut.Add(output);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isSaved)
            {
                System.Windows.Forms.MessageBox.Show("保存成功");

                DialogResult rsPrint = MessageBox.Show(Language.Msg("是否打印退库单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsPrint == DialogResult.Yes)
                {
                    this.Print();
                }
                this.Clear();

                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColReturnCost].CellType = numberCellType;
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;

            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        public int Print()
        {
            if (this.outManager.IOutPrint != null)
            {
                this.outManager.IOutPrint.SetData(this.alOutPut);
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
            this.outManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaManager_FpKeyEvent);

            this.outManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
        }

        #endregion

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            this.outManager.TargetDept = targetDept;

            this.Clear();

            this.AddOutData(listCode, state);
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.outManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColReturnQty)
            {
                string[] keys = new string[] { this.outManager.FpSheetView.Cells[this.outManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBillNO].Text//, 
												 //this.outManager.FpSheetView.Cells[this.outManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text
												 };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["退库金额"] = NConvert.ToDecimal(dr["退库数量"]) * NConvert.ToDecimal(dr["零售价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void phaManager_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.outManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.outManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColReturnQty)
                    {
                        if (this.outManager.FpSheetView.ActiveRowIndex == this.outManager.FpSheetView.Rows.Count - 1)
                        {
                            this.outManager.SetFocus();
                        }
                        else
                        {
                            this.outManager.FpSheetView.ActiveRowIndex++;
                            this.outManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColReturnQty;
                        }
                    }
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
            /// 物品名称	
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
            /// 物品编码
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
            ColKey,
            /// <summary>
            /// 库存序号
            /// </summary>
            ColStockNO
        }
    }
}
