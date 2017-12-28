using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 出库申请业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public class ApplyOutPriv : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        public ApplyOutPriv(Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut phaOutManager = null;

        private DataTable dt = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.TextCellType tReadOnly = new FarPoint.Win.Spread.CellType.TextCellType();

        /// <summary>
        /// 存储申请实体信息
        /// </summary>
        private System.Collections.Hashtable hsApplyData = new Hashtable();

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 数量显示时是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = false;

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
                //设置工具栏按钮显示
                this.phaOutManager.SetToolBarButton(true, false, false, false, true);
                this.phaOutManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //设置显示的待选择数据
                this.phaOutManager.SetSelectData("2", false, null, null, null);
                //设置提示信息
                this.phaOutManager.ShowInfo = "";

                this.phaOutManager.Fp.EditModeReplace = true;
                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaOutManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);
                this.phaOutManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);

                this.phaOutManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);
                this.phaOutManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);

                this.phaOutManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaOutManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.phaOutManager.SetItemListWidth(2);
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
                    if (dr.RowState != DataRowState.Deleted)
                        retailCost += NConvert.ToDecimal(dr["申请数量"]) * NConvert.ToDecimal(dr["零售价"]);
                }
                this.phaOutManager.TotCostInfo = string.Format("申请金额:{0}", retailCost.ToString("N"));
            }
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="sv"></param>
        protected virtual void SetFormat()
        {
            this.tReadOnly.ReadOnly = true;

            this.phaOutManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].Width = 70F;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            if (this.isUseMinUnit)
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Locked = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].BackColor = System.Drawing.Color.SeaShell;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
        }

        /// <summary>
        /// 向Datatable内增加数据
        /// </summary>
        /// <param name="applyOut"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal applyCost = applyOut.Operation.ApplyQty * applyOut.Item.PriceCollection.RetailPrice / applyOut.Item.PackQty;

                if (this.isUseMinUnit)
                {
                    this.dt.Rows.Add(new object[] { 
                                                applyOut.Item.Name,                            //商品名称
                                                applyOut.Item.Specs,                           //规格
                                                applyOut.BatchNO,                              //批号
                                                applyOut.Item.PriceCollection.RetailPrice,     //零售价
                                                applyOut.Item.PackUnit,                        //包装单位
                                                applyOut.Item.MinUnit,                         //最小单位
                                                applyOut.Operation.ApplyQty,                   //申请数量
                                                applyCost,                                     //申请金额
                                                applyOut.Memo,                                 //备注
                                                applyOut.Item.ID,                              //药品编码
                                                applyOut.Item.NameCollection.SpellCode,        //拼音码
                                                applyOut.Item.NameCollection.WBCode,           //五笔码
                                                applyOut.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                );
                }
                else
                {
                    this.dt.Rows.Add(new object[] { 
                                                applyOut.Item.Name,                            //商品名称
                                                applyOut.Item.Specs,                           //规格
                                                applyOut.BatchNO,                              //批号
                                                applyOut.Item.PriceCollection.RetailPrice,     //零售价
                                                applyOut.Item.PackUnit,                        //包装单位
                                                applyOut.Item.MinUnit,                         //最小单位
                                                applyOut.Operation.ApplyQty / applyOut.Item.PackQty,//申请数量
                                                applyCost,                                      //申请金额
                                                applyOut.Memo,                                 //备注
                                                applyOut.Item.ID,                              //药品编码
                                                applyOut.Item.NameCollection.SpellCode,        //拼音码
                                                applyOut.Item.NameCollection.WBCode,           //五笔码
                                                applyOut.Item.NameCollection.UserCode          //自定义码
                            
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
        /// 增加申请信息
        /// </summary>
        /// <param name="listNO"></param>
        private void AddApplyData(string listNO)
        {
            this.Clear();

            ArrayList alDetail = this.itemManager.QueryApplyOutInfoByListCode(this.phaOutManager.TargetDept.ID,listNO, "0");
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alDetail)
            {
                if (this.AddDataToTable(applyOut) == 1)
                {                   
                    this.hsApplyData.Add(applyOut.Item.ID + applyOut.BatchNO, applyOut);
                }
            }

            this.dt.AcceptChanges();

            ((System.ComponentModel.ISupportInitialize)(this.phaOutManager.Fp)).EndInit();

            this.SetFormat();

            this.SetFocusSelect();

            //计算汇总出库金额
            this.CompuateSum();
        }

        /// <summary>
        /// 根据药品信息添加申请信息
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

            if (this.hsApplyData.ContainsKey(drugNO + batchNO))
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

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();

            applyOut.Item = item;                                             //药品信息
            applyOut.BatchNO = batchNO;                                       //批号
            applyOut.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型

            applyOut.StockDept = this.phaOutManager.DeptInfo;                //当前科室
            applyOut.ApplyDept = this.phaOutManager.TargetDept;              //目标科室

            //applyOut.StockDept = this.phaOutManager.TargetDept;                //目标科室
            //applyOut.ApplyDept = this.phaOutManager.DeptInfo;                  //当前科室

            if (this.AddDataToTable(applyOut) == 1)
            {
                this.hsApplyData.Add(drugNO + batchNO, applyOut);
            }

            return 1;
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
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("申请金额",  dtDec),
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
            ArrayList alAllList = this.itemManager.QueryApplyOutListByTargetDept(this.phaOutManager.DeptInfo.ID, "24", "0");
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
                        continue;
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

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                targeDept.ID = selectObj.Memo;              //申请科室编码
                targeDept.Name = selectObj.Name;            //申请科室名称
                targeDept.Memo = "0";                       //目标单位性质 内部科室       

                if (this.phaOutManager.TargetDept.ID != targeDept.ID)
                    this.phaOutManager.TargetDept = targeDept;

                this.AddApplyData(selectObj.ID);

                this.SetFocusSelect();

                if (this.phaOutManager.FpSheetView != null)
                    this.phaOutManager.FpSheetView.ActiveRowIndex = 0;
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
            foreach (DataRow dr in this.dt.Rows)
            {
                if (NConvert.ToDecimal(dr["申请数量"]) <= 0)
                {
                    MessageBox.Show(Language.Msg(dr["商品名称"].ToString() + "申请出库数量不能为空"));
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

                    string[] keys = new string[]{
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColDrugNO].Text,
                                                sv.Cells[delRowIndex, (int)ColumnSet.ColBatchNO].Text
                                            };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[dr["药品编码"].ToString() + dr["批号"].ToString()] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                        //{58A3A4C6-6850-4eb7-AD66-7C1688FB1E43}  需判断是否存在ApplyOut.ID
                        if (string.IsNullOrEmpty(applyOut.ID) == false)
                        {
                            int parm = this.itemManager.DeleteApplyOut(applyOut.ID);
                            if (parm == -1)
                            {
                                Function.ShowMsg(this.itemManager.Err);
                                return -1;
                            }
                            if (parm == 0)
                            {
                                Function.ShowMsg("申请可能已被出库，请重试");
                                return -1;
                            }
                        }

                        this.phaOutManager.Fp.StopCellEditing();

                        this.hsApplyData.Remove(dr["药品编码"].ToString() + dr["批号"].ToString());

                        this.dt.Rows.Remove(dr);

                        this.phaOutManager.Fp.StartCellEditing(null,false);

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

        public int Clear()
        {
            try
            {
                this.dt.Rows.Clear();

                this.dt.AcceptChanges();

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
                    this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
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

            DialogResult rs = MessageBox.Show(Language.Msg("确认向" + this.phaOutManager.TargetDept.Name + "进行申请出库操作吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存申请信息 请稍候...");
            Application.DoEvents();

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //phaIntegrate.SetTrans(t.Trans);

            #endregion

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            string applyListNO = "";

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();

                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[key] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                if (applyOut.ID != "")
                {
                    applyListNO = applyOut.BillNO;          //申请单号

                    #region 对原始申请信息进行修改 只需更新申请数量

                    if (this.isUseMinUnit)
                        applyOut.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"]);       //申请数量
                    else
                        applyOut.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"]) * applyOut.Item.PackQty;       //申请数量

                    applyOut.Memo = dr["备注"].ToString();                                  //备注

                    int parm = this.itemManager.UpdateApplyOutNum(applyOut.ID, applyOut.Operation.ApplyQty);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(this.itemManager.Err);
                        return;
                    }
                    else if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("该申请单已被审核！无法进行修改!请刷新重试");
                        return;
                    }

                    #endregion
                }
                else
                {
                    #region 新增加申请信息

                    if (applyListNO == "")
                    {
                        // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                        applyListNO = phaIntegrate.GetInOutListNO(this.phaOutManager.DeptInfo.ID, false);
                        if (applyListNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("获取申请单信息发生错误" + phaIntegrate.Err);
                            return;
                        }
                    }

                    applyOut.BillNO = applyListNO;                                          //申请单据号
                    applyOut.Operation.ApplyOper.ID = this.phaOutManager.OperInfo.ID;       //申请人信息
                    applyOut.Operation.ApplyOper.OperTime = sysTime;
                    applyOut.State = "0";                                                   //申请单状态

                    applyOut.Operation.Oper = applyOut.Operation.ApplyOper;

                    if (this.isUseMinUnit)
                        applyOut.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"]);       //申请数量
                    else
                        applyOut.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"]) * applyOut.Item.PackQty;       //申请数量

                    applyOut.Memo = dr["备注"].ToString();                                  //备注

                    if (this.itemManager.InsertApplyOut(applyOut) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(this.itemManager.Err);
                        return;
                    }

                    #endregion
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //for (int i = 0; i < this.dt.DefaultView.Count; i++)
            //{
            //    this.dt.DefaultView[i].BeginEdit();
            //}

            Function.ShowMsg("保存成功");

            this.Clear();	
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

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColApplyQty)
            {
                string[] keys = new string[] { this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text, this.phaOutManager.FpSheetView.Cells[this.phaOutManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text };
                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["申请金额"] = NConvert.ToDecimal(dr["申请数量"]) * NConvert.ToDecimal(dr["零售价"]);

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
                    if (this.phaOutManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColApplyQty)
                    {
                        if (this.phaOutManager.FpSheetView.ActiveRowIndex == this.phaOutManager.FpSheetView.Rows.Count - 1)
                        {
                            this.phaOutManager.SetFocus();
                        }
                        else
                        {
                            this.phaOutManager.FpSheetView.ActiveRowIndex++;
                            this.phaOutManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
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
            /// 申请数量	
            /// </summary>
            ColApplyQty,
            /// <summary>
            /// 申请金额	
            /// </summary>
            ColApplyCost,
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
