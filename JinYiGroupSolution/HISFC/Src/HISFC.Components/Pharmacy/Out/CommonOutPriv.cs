using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 一般出库业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <说明>
    ///     1、Output.User01 存储数据来源 0 手工选择药品 1 申请单  Output.User02 存储申请单流水号
    ///     2、数据处理流程变动，详见保存函数内说明
    /// </说明>
    /// <修改记录>
    ///     <修改时间>2007-08-17</修改时间>
    ///     <修改内容>
    ///             修改一般出库时，对于目标科室管理库存时的处理方式。当目标科室管理库存时，将同时扣减
    ///             自身库存，增加对方库存，同时形成入库记录。
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public class CommonOutPriv : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSpeOut">是否特殊出库</param>
        /// <param name="ucPhaManager"></param>
        public CommonOutPriv(bool isSpeOut, Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            this.isSpecialOut = isSpeOut;

            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        /// <summary>
        /// 是否特殊出库
        /// </summary>
        private bool isSpecialOut = false;

        private Neusoft.HISFC.Components.Pharmacy.Out.ucPhaOut phaOutManager = null;

        private DataTable dt = null;

        /// <summary>
        /// 只读Fp单元格类型
        /// </summary>
        private Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();

        /// <summary>
        /// 存储出库实体信息
        /// </summary>
        private System.Collections.Hashtable hsOutData = new Hashtable();

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

        /// <summary>
        /// 包装数量
        /// </summary>
        private decimal packQty = 1;

        /// <summary>
        /// 限制药品类别
        /// </summary>
        private System.Collections.Hashtable hsRestrainedQualityHelper = new Hashtable();

        /// <summary>
        /// 三级关联权限
        /// </summary>
        private Neusoft.HISFC.Models.Admin.PowerLevelClass3 privJoinClass3 = null;

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
                this.phaOutManager.SetToolBarButton(true, false, false, false, true);
                this.phaOutManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //设置显示的待选择数据
                this.phaOutManager.SetSelectData("2",Function.IsOutByBatchNO, null, null, null);
                //提示信息设置
                this.phaOutManager.ShowInfo = "";

                if (this.isSpecialOut)
                {
                    this.phaOutManager.TargetDept = this.phaOutManager.DeptInfo;
                }

                this.phaOutManager.Fp.EditModeReplace = true;
                this.phaOutManager.FpSheetView.DataAutoSizeColumns = false;

                this.phaOutManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);
                this.phaOutManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(phaOutManager_EndTargetChanged);

                this.phaOutManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);
                this.phaOutManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(phaOutManager_FpKeyEvent);

                this.phaOutManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.phaOutManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.phaOutManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);
                this.phaOutManager.Fp.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick);

                this.phaOutManager.FpSheetView.DataAutoCellTypes = false;
                this.SetFormat();

                this.Init();

                if (Function.IsOutByBatchNO)
                {
                    this.phaOutManager.SetItemListWidth(3);
                }
                else                
                {
                    this.phaOutManager.SetItemListWidth(2);
                }
            }
        }

        private void Fp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //双击弹出窗口

            string drugCode = string.Empty;

            if (this.phaOutManager.DeptInfo.Memo == "PI")
            {
                if (this.isSpecialOut)          ///特殊出库不做判断
                {

                }
                else
                {
                    drugCode = this.phaOutManager.FpSheetView.Cells[e.Row, (int)ColumnSet.ColDrugNO].Text;
                    using (frmEveryStore frm = new frmEveryStore())
                    {
                        frm.DrugCode = drugCode;
                        frm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //限制药品类别
            ArrayList al = consManager.GetList("RestrainedType");
            if (al == null)
            {
                al = new ArrayList();
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                this.hsRestrainedQualityHelper.Add(info.ID, null);
            }

            Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerLevelManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();

            Neusoft.HISFC.Models.Admin.PowerLevelClass3 privClass3 = powerLevelManager.LoadLevel3ByPrimaryKey(this.phaOutManager.Class2Priv.ID, this.phaOutManager.PrivType.ID);
            if (privClass3 != null)
            {
               privJoinClass3 = powerLevelManager.LoadLevel3ByPrimaryKey("0310", privClass3.Class3JoinCode);
            }

            return 1;
        }

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="input">入库信息 Input.User01存储数据来源</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            if (!Function.JudgePriceConsinstency(this.phaOutManager.DeptInfo.ID,output.Item))
            {
                MessageBox.Show(Language.Msg("该药品已经经过科室调价！不能直接进行出库。如需出库请先进行全院调价"),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return -1;
            }

            if (this.dt == null)
            {
                this.InitDataTable();
            }

            

            try
            {
                output.RetailCost = output.Quantity / output.Item.PackQty * output.Item.PriceCollection.RetailPrice;

                this.packQty = output.Item.PackQty;

                if (this.isUseMinUnit)
                {
                    this.dt.Rows.Add(new object[] { 
                                                output.Item.Name,                            //商品名称
                                                output.Item.Specs,                           //规格
                                                output.BatchNO,                              //批号
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                output.StoreQty,                             //库存数量
                                                output.Quantity,                             //出库数量
                                                output.RetailCost,                           //出库金额
                                                output.Memo,                                 //备注
                                                output.Item.ID,                              //药品编码
                                                output.User01,                               //数据来源
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
                                                output.Item.PriceCollection.RetailPrice,     //零售价
                                                output.Item.PackUnit,                        //包装单位
                                                output.Item.MinUnit,                         //最小单位
                                                Math.Round(output.StoreQty / output.Item.PackQty,2),//库存数量
                                                output.Quantity / output.Item.PackQty,       //出库数量
                                                output.RetailCost,                           //出库金额
                                                output.Memo,                                 //备注
                                                output.Item.ID,                              //药品编码
                                                output.User01,                               //数据来源
                                                output.Item.NameCollection.SpellCode,        //拼音码
                                                output.Item.NameCollection.WBCode,           //五笔码
                                                output.Item.NameCollection.UserCode          //自定义码
                            
                                           }
                                    );
                }
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
        /// <param name="sv"></param>
        protected virtual void SetFormat()
        {
            this.phaOutManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 70F;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 70F;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = Function.IsOutByBatchNO;          //批号 
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            if (this.isUseMinUnit)
            {
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = true;
            }
            else
            {
                this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;
            }

            this.numCellType.DecimalPlaces = 2;
            this.numCellType.MinimumValue = 0;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Locked = false;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].BackColor = System.Drawing.Color.SeaShell;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].CellType = this.numCellType;

            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.phaOutManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
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
                Neusoft.HISFC.Models.Pharmacy.Output output = new Neusoft.HISFC.Models.Pharmacy.Output();
                //药品实体信息
                output.Item = this.itemManager.GetItem(applyOut.Item.ID);
                if (output.Item == null)
                {
                    MessageBox.Show(Language.Msg("加载申请时 根据药品编码减少药品字典信息失败" + applyOut.Item.ID));
                    return -1;
                }
                output.Quantity = applyOut.Operation.ApplyQty;   //申请量
                output.Memo = applyOut.Memo;                     //备注信息

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

                output.User01 = "1";                            //数据来源 申请
                output.User02 = applyOut.ID;                    //申请单流水号

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(output.Item.ID + output.BatchNO, output);

                    this.hsApplyData.Add(applyOut.ID, applyOut);
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

            if (this.hsRestrainedQualityHelper != null)
            {
                if (this.hsRestrainedQualityHelper.ContainsKey(item.Quality.ID))
                {
                    MessageBox.Show(Language.Msg("该性质药品不允许直接出库,必须通过申请进行"));
                    return 0;
                }
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
                this.hsOutData.Add(drugNO + batchNO,output);
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
                    if (isUseMinUnit)
                    {
                        retailCost += Math.Round(NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]) / packQty, 2);
                    }
                    else
                    {
                        retailCost += NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);
                    }
                }
                this.phaOutManager.TotCostInfo = string.Format("出库金额:{0}", retailCost.ToString("N"));
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
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("库存数量",  dtDec),
                                                                    new DataColumn("出库数量",  dtDec),
                                                                    new DataColumn("出库金额",  dtDec),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
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
            decimal storeQty = 0;

            //{A34573AE-7AF4-4409-8A2B-86AA3211DAB2} 当根据批号出库时，库存数量列显示不正确
            if (string.IsNullOrEmpty( batchNO ) == true || batchNO == "ALL")
            {
                this.itemManager.GetStorageNum( this.phaOutManager.DeptInfo.ID, drugNO, out storeQty );
            }
            else
            {
                this.itemManager.GetStorageNum( this.phaOutManager.DeptInfo.ID, drugNO, batchNO, out storeQty );
            } 

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

                this.AddApplyData(selectObj.ID,"0");

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
                for (int i = this.dt.Rows.Count - 1; i >= 0; i--)
                {
                    this.dt.Rows.RemoveAt(i);
                }
                
                this.dt.AcceptChanges();
                

                this.phaOutManager.FpSheetView.RowCount = 0;

                this.hsOutData.Clear();
                //清除申请信息
                this.hsApplyData.Clear();
                this.phaOutManager.TotCostInfo = "总金额";//{A11C91F0-D4F6-4c30-862D-A2301B62DB1E}

                //this.phaOutManager.FpSheetView.Reset();
                //this.phaOutManager.ClearFp();
                //this.phaOutManager.Init();
                //this.phaOutManager.InitFp();
                //this.phaOutManager.Fp.StartCellEditing(null, false);
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
            this.phaOutManager.Fp.StopCellEditing();

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

            this.phaOutManager.Fp.StopCellEditing();

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
            string outListNO = "";
            string inListNO = "";
            //判断领用科室是否管理库存
            bool isManagerStore = phaCons.IsManageStore(this.phaOutManager.TargetDept.ID);
            //如管理库存 则提示是否确认保存出库
            if (isManagerStore)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                DialogResult rsResult = MessageBox.Show(Language.Msg(this.phaOutManager.TargetDept.Name + "管理库存。确认进行出库操作吗?\n出库时将直接更新对方库存"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rsResult == DialogResult.No)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
                System.Windows.Forms.Application.DoEvents();
            }

            //一般出库对应的入库记录
            Neusoft.HISFC.Models.Pharmacy.Input input = null;

            //-------原程序处理方式
            //    //如领用科室管理库存 则只处理出库记录、更新本科室库存 不处理入库记录和领药科室库存 待领药科室入库核准后才处理库存
            //    //如领药科室不管理库存 则处理出库记录、更新本科室库存，试用期间处理入库记录、更新领药科室库存 
            //    //						正式使用后不处理入库记录和领药科室库存
            //    //只需对isManagerStore赋值改变 对下边入库记录处理的判断做下修改即可 
            //    //更新领药科室库存的操作封装于入库函数内 和入库记录一同处理 可通过传入参数判断是否处理库存
            //-------新程序处理方式
            //      一般出库时，不管目标科室是不是管理库存，都直接设置出库记录状态为已核准。
            //                  目标科室管理库存时，对目标科室产生入库记录，状态为已核准
            //                  目标科室不管理库存时，对目标科室不产生入库记录

            this.alPrintData = new ArrayList();

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["药品编码"].ToString() + dr["批号"].ToString();
                Neusoft.HISFC.Models.Pharmacy.Output output = this.hsOutData[key] as Neusoft.HISFC.Models.Pharmacy.Output;

                output.Operation.ExamOper.ID = this.phaOutManager.OperInfo.ID;  //审核人
                output.Operation.ExamOper.OperTime = sysTime;                   //审核日期
                output.Operation.Oper = output.Operation.ExamOper;              //操作信息

                #region 对数据来源为申请的数据进行处理

                if (dr["数据来源"].ToString() == "1")
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[output.User02] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                    applyOut.State = "1";                       //状态 审批
                    applyOut.Operation = output.Operation;      //操作信息

                    if (this.itemManager.UpdateApplyOut(applyOut) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("更新" + output.Item.Name + "出库申请信息时出错");
                        return;
                    }

                    if (outListNO == "")
                    {
                        outListNO = applyOut.BillNO;
                    }
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

                //----原数据处理方式
                //if (isManagerStore)             //目标(领用)科室管理库存
                //    output.State = "1";         //审核
                //else
                //    output.State = "2";         //核准
                //----现处理方式 对于一般出库 直接设置出库状态为2
                output.State = "2";

                if (this.isSpecialOut)          //特殊出库 直接更新状态为核准 
                {
                    output.SpecialFlag = "1";
                    output.State = "2";
                }

                if (output.State == "2")
                {
                    output.Operation.ApproveOper = output.Operation.Oper;
                }

                #endregion

                #region 以下信息在每次添加新数据时自动生成

                output.PrivType = this.phaOutManager.PrivType.ID;               //出库类型
                output.SystemType = this.phaOutManager.PrivType.Memo;           //系统类型
                output.StockDept = this.phaOutManager.DeptInfo;                 //当前科室
                output.TargetDept = this.phaOutManager.TargetDept;              //目标科室

                #endregion

                #region 形成目标科室的入库记录

                #region 根据领药科室是否管理库存   在不管理库存的情况下才处理入库记录
                if (!this.isSpecialOut)
                {
                    input = new Neusoft.HISFC.Models.Pharmacy.Input();
                    //设置入库单号
                    if (inListNO == "")
                    {
                        // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                        inListNO = phaIntegrate.GetInOutListNO(this.phaOutManager.TargetDept.ID, false);
                        if (inListNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("对目标库存科室插入入库记录时获取入库单号出错") + this.itemManager.Err);
                            return;
                        }
                    }

                    //获取关联权限类型 关联权限类型不存在时 设置为默认值
                    if (this.privJoinClass3 != null)
                    {
                        input.PrivType = this.privJoinClass3.Class3Code;
                        input.SystemType = this.privJoinClass3.Class3MeaningCode;
                    }
                    else
                    {
                        input.PrivType = "01";											//一般入库对应的用户类型
                        input.SystemType = "11";										//一般入库
                    }

                    input.State = "2";												//已审批
                    input.StockDept = this.phaOutManager.TargetDept;				//库存部门

                    input.TargetDept = this.phaOutManager.DeptInfo;					//目标科室 供货单位

                    input.InListNO = inListNO;									    //入库单据号
                    input.OutListNO = outListNO;								    //出库单据号
                    input.Operation.ExamOper.ID = this.phaOutManager.OperInfo.ID;	//审批人
                    input.Operation.ExamOper.OperTime = sysTime;					//审批日期

                    input.Operation.ApproveOper = input.Operation.ExamOper;
                    input.Operation.ApplyOper = input.Operation.ExamOper;

                    decimal storeQty = 0;
                    if (this.itemManager.GetStorageNum(this.phaOutManager.TargetDept.ID, output.Item.ID, out storeQty) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("获取" + output.Item.Name + "库存数量时发生错误" + this.itemManager.Err));
                        return;
                    }
                    input.StoreQty = storeQty + output.Quantity;

                    //设置出库记录中对应的入库单据号
                    output.InListNO = inListNO;
                }
                else
                {
                    input = null;
                }
                #endregion

                #endregion


                //原处理方式 第三个参数始终传入False
                if (this.itemManager.Output(output, input, isManagerStore) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("出库保存发生错误" + this.itemManager.Err);
                    return;
                }

                this.alPrintData.Add(output);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //for (int i = 0; i < this.dt.DefaultView.Count; i++)
            //{
            //    this.dt.DefaultView[i].BeginEdit();
            //}

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
#region {E756AD85-3A88-4b42-8615-CD27A00C70EA}
            this.phaOutManager.Fp.CellDoubleClick -= new FarPoint.Win.Spread.CellClickEventHandler(Fp_CellDoubleClick); 
            #endregion
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
                    if (isUseMinUnit)
                    {
                        dr["出库金额"] = Math.Round(NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"])/packQty,2);
                    }
                    else
                    {
                        dr["出库金额"] = NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);
                    }

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
            /// 数据源
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
