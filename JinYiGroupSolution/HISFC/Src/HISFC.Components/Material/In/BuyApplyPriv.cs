using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.In
{
    /// <summary>
    /// [功能描述: 物资申购业务类]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     1、如需增加多级审核流程
    ///             1) 通过权限设置窗口增加多种权限
    ///             2) 重写工厂创建类 对不同的审核权限返回不同实例
    ///             3) 根据不同的审核权限对申请数据设置不同的状态
    ///             4) 再全部审核完成时 形成可出库审批的数据
    /// </说明>
    /// </summary>
    public class BuyApplyPriv : IMatManager
    {
        #region 构造方法

        /// <summary>
        /// 物资申购
        /// </summary>
        /// <param name="isBakcIn"></param>
        /// <param name="ucMatApplyManager">正常入库FALSE , 退库入库TRUE </param>
        public BuyApplyPriv(bool isBakcIn, In.ucMatIn ucMatApplyManager)
        {
            this.isBack = isBakcIn;

            this.listNO = "";

            this.SetMaterialProperty(ucMatApplyManager);

        }

        #endregion

        #region 域变量

        /// <summary>
        /// 是否退库申请
        /// </summary>
        private bool isBack = false;

        /// <summary>
        /// 是否最小单位
        /// </summary>
        private bool isMinUnit = true;

        /// <summary>
        /// 申请组件类
        /// </summary>
        private In.ucMatIn MatApplyManager;

        /// <summary>
        /// SheetView定义
        /// </summary>
        private FarPoint.Win.Spread.SheetView svTemp = null;

        /// <summary>
        /// DataTable定义
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// Hashtable定义 存储已添加的申请数据
        /// </summary>
        private System.Collections.Hashtable hsApplyData = new System.Collections.Hashtable();

        /// <summary>
        /// 本次单据申请号
        /// </summary>
        private string listNO = "";

        /// <summary>
        /// 单据内序号
        /// </summary>
        private int serialNO = 0;

        public string showInfo = "";

        /// <summary>
        /// 库存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 字典管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();
        /// <summary>
        /// 参数控制业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 物资列表中显示的列数
        /// </summary>
        private int visibleColumns = 3;

        /// <summary>
        /// 控制参数
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Controler myControler = new Neusoft.HISFC.BizLogic.Manager.Controler();

        private Neusoft.HISFC.BizLogic.Manager.Department myDept = new Neusoft.HISFC.BizLogic.Manager.Department();

        private Neusoft.HISFC.BizLogic.Manager.Person myPerson = new Neusoft.HISFC.BizLogic.Manager.Person();

        #endregion

        #region 属性

        /// <summary>
        /// 是否最小单位申请
        /// </summary>
        public bool IsMinUnit
        {
            get
            {
                return this.isMinUnit;
            }
            set
            {
                this.isMinUnit = value;
            }
        }

        #endregion

        #region 方法

        private void SetMaterialProperty(In.ucMatIn ucMatApplyManager)
        {
            this.MatApplyManager = ucMatApplyManager;
            visibleColumns = controlIntegrate.GetControlParam<int>("MT0002", true);
            if (this.MatApplyManager != null)
            {
                //设置界面显示
                this.MatApplyManager.IsShowItemSelectpanel = true;
                this.MatApplyManager.IsShowInputPanel = false;

                //设置内部申请目标科室信息
                this.MatApplyManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                //设置内部申请显示的待选择数据
                //this.MatApplyManager.SetSelectData("1", false, null, null, null);
                this.ShowSelectData();

                this.MatApplyManager.SetItemListWidth(visibleColumns);
                //设置工具栏按钮显示
                this.MatApplyManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //设置信息显示
                this.MatApplyManager.ShowInfo = "";
                //Fp 设置
                this.MatApplyManager.FpSheetView.DataAutoSizeColumns = false;
                this.MatApplyManager.Fp.EditModeReplace = true;

                this.MatApplyManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);
                this.MatApplyManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

                this.MatApplyManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);
                this.MatApplyManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

                this.MatApplyManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.MatApplyManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                this.MatApplyManager.FpSheetView.DataAutoSizeColumns = false;
                this.MatApplyManager.FpSheetView.DataAutoCellTypes = false;
                this.SetFormat();

            }
        }

        /// <summary>
        /// 向DataTable内增加数据
        /// </summary>
        /// <param name="apply">申请信息</param>
        /// <param name="dataSource">数据来源 0 原始数据 1 本次添加</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Material.Apply apply, string dataSource)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal price = 0;
                decimal qty = 0;
                decimal cost = 0;
                string unit = "";

                if (this.isMinUnit)
                {
                    qty = apply.Operation.ApplyQty;
                    cost = apply.Operation.ApplyQty * apply.Item.UnitPrice;
                    unit = apply.Item.MinUnit;
                    price = apply.Item.UnitPrice;
                }
                else
                {
                    qty = apply.Operation.ApplyQty / apply.Item.PackQty;
                    cost = apply.Operation.ApplyQty / apply.Item.PackQty * apply.Item.PackPrice;
                    unit = apply.Item.PackUnit;
                    price = apply.Item.PackPrice;
                }
                this.dt.Rows.Add(new object[] { 
												  apply.Item.Name,									//商品名称
												  apply.Item.Specs,									//规格
												  price,											//零售价
												  unit,												//包装单位
												  qty,												//申请数量
												  cost,												//申请金额
												  apply.Memo,										//备注
												  apply.Item.ID,									//物品编码
												  apply.SerialNO,									//序号
												  dataSource,
												  apply.Item.SpellCode,							//拼音码
												  apply.Item.WBCode,								//五笔码
												  apply.Item.UserCode								//自定义码                            
											  }
                    );

                this.dt.DefaultView.AllowDelete = true;
                this.dt.DefaultView.AllowEdit = true;
                this.dt.DefaultView.AllowNew = true;
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
        /// 根据申请单信息向DataTable内增加数据
        /// </summary>
        /// <param name="apply">申请信息</param>
        /// <param name="dataSource">数据来源 0 原始数据 1 本次添加</param>
        /// <returns></returns>
        protected virtual int AddApplyToTable(Neusoft.HISFC.Models.Material.Apply apply, string dataSource)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                Neusoft.HISFC.BizLogic.Material.MetItem managerItem = new Neusoft.HISFC.BizLogic.Material.MetItem();
                apply.Item = managerItem.GetMetItemByMetID(apply.Item.ID);

                decimal price = 0;
                decimal qty = 0;
                decimal cost = 0;
                string unit = "";

                if (this.isMinUnit)
                {
                    qty = apply.Operation.ApplyQty;
                    cost = apply.Operation.ApplyQty * apply.Item.UnitPrice;
                    unit = apply.Item.MinUnit;
                    price = apply.Item.UnitPrice;
                }
                else
                {
                    qty = apply.Operation.ApplyQty / apply.Item.PackQty;
                    cost = apply.Operation.ApplyQty / apply.Item.PackQty * apply.Item.PackPrice;
                    unit = apply.Item.PackUnit;
                    price = apply.Item.PackPrice;
                }
                this.dt.Rows.Add(new object[] { 
												  apply.Item.Name,                                //商品名称
												  apply.Item.Specs,                               //规格
												  price,					                      //零售价
												  unit,											  //包装单位
												  qty,											  //申请数量
												  cost,                                           //申请金额
												  apply.Memo,                                     //备注
												  apply.Item.ID,                                  //物品编码
												  apply.SerialNO,                                 //序号
												  dataSource,
												  apply.Item.SpellCode,                          //拼音码
												  apply.Item.WBCode,                             //五笔码
												  apply.Item.UserCode                            //自定义码                            
											  }
                    );

                this.dt.DefaultView.AllowDelete = true;
                this.dt.DefaultView.AllowEdit = true;
                this.dt.DefaultView.AllowNew = true;
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
        /// 根据申请单号增加申请数据
        /// </summary>
        /// <param name="listNO"></param>
        /// <returns></returns>
        private int AddApplyData(string listNO)
        {
            ArrayList alDetail = this.storeManager.QueryApplyDetailByListNO(this.MatApplyManager.DeptInfo.ID, listNO, "0");
            if (alDetail == null)
            {
                System.Windows.Forms.MessageBox.Show("未正确获取内部入库申请信息" + this.storeManager.Err);
                return -1;
            }

            this.Clear();

            ((System.ComponentModel.ISupportInitialize)(this.MatApplyManager.Fp)).BeginInit();

            int i = 0;

            foreach (Neusoft.HISFC.Models.Material.Apply info in alDetail)
            {
                if (this.AddApplyToTable(info, "0") == -1)
                    return -1;

                this.listNO = info.ApplyListNO;

                if (i < info.SerialNO)
                {
                    i = info.SerialNO;
                }

                this.hsApplyData.Add(info.Item.ID, info);
            }

            this.listNO = listNO;

            this.serialNO = i;

            this.dt.AcceptChanges();

            this.CompuateSum();

            ((System.ComponentModel.ISupportInitialize)(this.MatApplyManager.Fp)).EndInit();

            return 1;
        }

        /// <summary>
        /// 根据物品编码加入 出库申请数据
        /// </summary>
        /// <param name="apply">物品实体</param>
        /// <returns></returns>
        private int AddDrugData(Neusoft.HISFC.Models.Material.Apply apply)
        {
            if (this.hsApplyData.Contains(apply.Item.ID))
            {
                System.Windows.Forms.MessageBox.Show("该物品已添加");
                return 0;
            }

            apply.StockDept = this.MatApplyManager.DeptInfo;         //库存科室 (目标科室)
            apply.TargetDept = this.MatApplyManager.TargetDept;      //目标科室
            apply.State = "0";                                       //状态 申请
            apply.SystemType = this.MatApplyManager.PrivType.Memo;
            apply.PrivType = this.MatApplyManager.PrivType.ID;

            if (this.AddDataToTable(apply, "1") == 1)
            {
                this.hsApplyData.Add(apply.Item.ID, apply);
                this.SetFocusSelect();
            }

            return 1;
        }

        /// <summary>
        /// 根据物品编码加入 入库申请数据
        /// </summary>
        /// <param name="drugNO">物品编码</param>
        /// <param name="outBillNO">出库序号</param>
        /// <returns></returns>
        private int AddDrugData(string drugNO, string outBillNO)
        {

            Neusoft.HISFC.Models.Material.MaterialItem item = itemManager.GetMetItemByMetID(drugNO);

            if (item == null)
            {
                System.Windows.Forms.MessageBox.Show("检索物品基本信息失败");
                return -1;
            }

            Neusoft.HISFC.Models.Material.Apply apply = new Neusoft.HISFC.Models.Material.Apply();

            apply.Item = item;

            if (this.hsApplyData.Contains(apply.Item.ID))
            {
                System.Windows.Forms.MessageBox.Show("该物品已添加");
                return 0;
            }

            if (outBillNO != null)
            {
                apply.ApplyListNO = outBillNO;
            }

            apply.StockDept = this.MatApplyManager.DeptInfo;       //库存科室 (目标科室)
            apply.TargetDept = this.MatApplyManager.TargetDept;      //申请科室
            apply.State = "0";                                   //状态 申请
            apply.SystemType = this.MatApplyManager.PrivType.Memo;
            apply.PrivType = this.MatApplyManager.PrivType.ID;

            if (this.AddDataToTable(apply, "1") == 1)
            {
                this.hsApplyData.Add(apply.Item.ID, apply);

                //				this.SetFormat();

                this.SetFocusSelect();

            }

            return 1;
        }

        /// <summary>
        /// 根据物品编码加入 入库申请数据 --退库申请用
        /// </summary>
        /// <param name="itemCode">物品编码</param>
        /// <param name="outNo">出库流水号</param>
        /// <param name="storeNo">库存序号</param>
        /// <returns></returns>
        private int AddDrugData(string itemCode, string outNo, string storeNo)
        {

            Neusoft.HISFC.Models.Material.MaterialItem item = itemManager.GetMetItemByMetID(itemCode);

            if (item == null)
            {
                System.Windows.Forms.MessageBox.Show("检索物品基本信息失败");
                return -1;
            }

            Neusoft.HISFC.Models.Material.Apply apply = new Neusoft.HISFC.Models.Material.Apply();

            apply.Item = item;

            if (this.hsApplyData.Contains(apply.Item.ID))
            {
                System.Windows.Forms.MessageBox.Show("该物品已添加");
                return 0;
            }
            apply.OutNo = outNo;
            apply.StockNO = storeNo;

            apply.StockDept = this.MatApplyManager.DeptInfo;       //库存科室 (目标科室)
            apply.TargetDept = this.MatApplyManager.TargetDept;      //申请科室
            apply.State = "0";                                   //状态 申请
            apply.SystemType = this.MatApplyManager.PrivType.Memo;
            apply.PrivType = this.MatApplyManager.PrivType.ID;

            if (this.AddDataToTable(apply, "1") == 1)
            {
                this.hsApplyData.Add(apply.Item.ID, apply);

                //				this.SetFormat();

                this.SetFocusSelect();

            }

            return 1;
        }

        /// <summary>
        /// 根据物品编码加入退库数据
        /// </summary>
        /// <param name="drugNO">物品编码</param>
        /// <returns></returns>
        private int AddDrugData(string drugNO)
        {
            return this.AddDrugData(drugNO, null);
        }

        /// <summary>
        /// 加载显示数据
        /// </summary>
        /// <returns></returns>
        private int ShowSelectData()
        {
            if (this.isBack)
            {
                string[] filterStr = new string[3] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" };
                string[] label = new string[] { "出库序号", "出库单据号", "出库流水号", "库存序号", "物品编码", "物品名称", "规格", "数量", "包装单位", "最小单位", "拼音码", "五笔码" };
                int[] width = new int[] { 60, 60, 60, 60, 60, 120, 80, 60, 60, 60, 60, 60 };
                bool[] visible = new bool[] { false, false, false, false, false, true, true, true, true, true, true, true };

                this.MatApplyManager.SetSelectData("3", false, new string[] { "Material.Store.GetOutputInfoForInput" }, filterStr, this.MatApplyManager.DeptInfo.ID, "A", "2", this.MatApplyManager.TargetDept.ID);

                this.MatApplyManager.SetSelectFormat(label, width, visible);
            }
            else
            {
                //by yuyun 08-8-11
                this.MatApplyManager.DeptCode = this.MatApplyManager.TargetDept.ID;
                //----------------
                this.MatApplyManager.SetSelectData("0", false, null, null, null);//数据类别 0 物品列表 1 目标单位科室库存列表 2 本科室库存列表 3 自定义列表
            }

            this.MatApplyManager.SetItemListWidth(3);

            return 1;
        }

        /// <summary>
        /// 格式化Fp显示
        /// </summary>
        public virtual void SetFormat()
        {
            if (this.MatApplyManager.FpSheetView == null)
                return;

            this.MatApplyManager.FpSheetView.DefaultStyle.Locked = true;
            this.MatApplyManager.FpSheetView.DataAutoSizeColumns = false;

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColItemName].Width = 150F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 70F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Width = 80F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].Width = 100F;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].CellType = numberCellType;

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColItemID].Visible = false;           //物品编码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColNO].Visible = false;               //序号
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 200F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Locked = false;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].BackColor = System.Drawing.Color.SeaShell;
        }

        ///<summary>
        ///根据物品警戒线加入数据
        ///</summary>
        ///<param name="alterFlag">生成方式 0 警戒线 1 日消耗</param>
        ///<param name="deptCode">库房编码</param>
        ///<returns>成功返回0，失败返回－1</returns>
        public void FindByAlter(string alterFlag, string deptCode)
        {
            //			if (this.hsApplyData.Count > 0)
            //			{
            //				DialogResult result;
            //				result = MessageBox.Show("按警戒线生成将清除当前内容，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
            //					MessageBoxOptions.RightAlign);
            //				if (result == DialogResult.No)
            //					return;
            //			}
            //
            //			try
            //			{
            //				this.Clear();
            //
            //				ArrayList alDetail = new ArrayList();
            //				if (alterFlag == "1")
            //				{
            //					#region 弹出窗口 设置日消耗参数 计算需申请信息
            //					using (Pharmacy.ucPhaAlter uc = new ucPhaAlter())
            //					{
            //						uc.DeptCode = deptCode;
            //						uc.SetData();
            //						uc.Focus();
            //						Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            //
            //						if (uc.ApplyInfo != null)
            //						{
            //							alDetail = uc.ApplyInfo;
            //						}
            //					}
            //					#endregion
            //				}
            //				else
            //				{
            //					alDetail = this.storeManager.FindByAlter("0", deptCode, System.DateTime.MinValue, System.DateTime.MaxValue);
            //					if (alDetail == null)
            //					{
            //						MessageBox.Show(Language.Msg("按照数量警戒线执行信息计算未正确执行\n" + this.storeManager.Err));
            //						return;
            //					}
            //				}
            //
            //				Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
            //				foreach (Neusoft.FrameWork.Models.NeuObject temp in alDetail)
            //				{
            //					//this.AddDrugInfo(temp.ID, "", NConvert.ToDecimal(temp.User03));
            //					this.AddDrugData(temp.ID);
            //				}
            //
            //			}
            //			catch (Exception ex)
            //			{
            //				MessageBox.Show(Language.Msg(ex.Message));
            //			}
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
                    retailCost += Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["申请数量"]) * Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["单价"]);
                }

                this.MatApplyManager.TotCostInfo = string.Format("申请总金额:{0} ", retailCost.ToString("N"));
            }
        }

        #endregion

        #region IMatManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get { return null; }
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
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),
												 new DataColumn("单价",    dtDec),
												 new DataColumn("单位",  dtStr),
												 new DataColumn("申请数量",  dtDec),
												 new DataColumn("申请金额",  dtDec),
												 new DataColumn("备注",      dtStr),
												 new DataColumn("物品编码",  dtStr),
												 new DataColumn("序号",    dtStr),
												 new DataColumn("数据来源",  dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr)
												 
											 }
                );

            DataColumn[] keys = new DataColumn[1];

            keys[0] = this.dt.Columns["物品编码"];

            this.SetFormat();

            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugID = "";

            if (isBack)
            {
                drugID = sv.Cells[activeRow, 4].Value.ToString();

                string outbillNO = sv.Cells[activeRow, 1].Value.ToString();
                string outNo = sv.Cells[activeRow, 2].Value.ToString();
                string stockNo = sv.Cells[activeRow, 3].Value.ToString();
                if (this.isBack)
                {
                    return this.AddDrugData(drugID, outNo, stockNo);
                }
                else
                {
                    return this.AddDrugData(drugID, outbillNO);
                }
            }
            else
            {
                //自定义码和物资编码已对调 by yuyun 08-8-6
                //drugID = sv.Cells[activeRow, 0].Value.ToString();
                drugID = sv.Cells[activeRow, 10].Value.ToString();
                return this.AddDrugData(drugID);
            }
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, Neusoft.HISFC.Models.Material.Input input)
        {
            return 1;
        }

        public int ShowApplyList()
        {
            ArrayList alTemp = new ArrayList();
            //获取申请信息
            string currentDeptID = string.Empty;
            currentDeptID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;

            if (this.MatApplyManager.DeptInfo.Memo == "L")
            {
                alTemp = this.storeManager.QueryApplySimple(this.MatApplyManager.DeptInfo.ID, currentDeptID, this.MatApplyManager.Class2Priv.ID, "0", "12");
            }
            else
            {
                alTemp = this.storeManager.QueryApplySimple(this.MatApplyManager.DeptInfo.ID, currentDeptID, this.MatApplyManager.Class2Priv.ID, "0", "13");
            }

            if (alTemp == null)
            {
                System.Windows.Forms.MessageBox.Show("获取申请信息失败" + this.storeManager.Err);
                return -1;
            }
            //			ArrayList alList = new ArrayList();
            //根据当前选择的供货单位过滤
            //			if (this.MatApplyManager.TargetDept.ID != "")
            //			{
            //				foreach (Neusoft.FrameWork.Models.NeuObject info in alTemp)
            //				{
            //					if (info.Memo != this.MatApplyManager.TargetDept.ID)
            //						continue;
            //					alList.Add(info);
            //				}
            //			}
            //			else
            //			{
            //				alList = alTemp;
            //			}
            //			
            //			//弹出窗口选择单据			
            //			Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            //			string[] fpLabel = { "申请单号", "供货单位" };
            //			float[] fpWidth = { 120F, 120F };
            //			bool[] fpVisible = { true, true, false, false, false, false };

            Neusoft.FrameWork.Models.NeuObject selectObject = new Neusoft.FrameWork.Models.NeuObject();

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alTemp, ref selectObject) == 1)
            {
                this.Clear();

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                //				targeDept.ID = selectObj.Memo;              //供货公司编码
                //				targeDept.Name = selectObj.Name;            //供货公司姓名
                //				targeDept.Memo = "0";                       //目标单位性质 内部科室
                //
                //				if (this.MatApplyManager.TargetDept.ID != targeDept.ID)
                //				{
                //					this.MatApplyManager.TargetDept = targeDept;
                //					this.ShowSelectData();
                //				}

                this.AddApplyData(selectObject.ID);

                this.SetFocusSelect();

                if (this.svTemp != null)
                    this.svTemp.ActiveRowIndex = 0;
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

        public bool Valid()
        {
            if (this.MatApplyManager.TargetDept.ID == "")
            {
                System.Windows.Forms.MessageBox.Show("请选择供货科室！");
                return false;
            }
            try
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["申请数量"]) <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show(dr["物品名称"].ToString() + "申请数量不能小于等于零");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            try
            {
                if (sv != null && delRowIndex >= 0)
                {
                    System.Windows.Forms.DialogResult rs = MessageBox.Show("确认对所选择数据进行删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    string[] keys = new string[] { sv.Cells[delRowIndex, (int)ColumnSet.ColItemID].Text };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        #region 数据移出

                        if (dr["序号"].ToString() != "" && dr["序号"].ToString() != "0")
                        {
                            int parm = this.storeManager.DeleteApply(this.listNO, NConvert.ToInt32(dr["序号"].ToString()), this.MatApplyManager.DeptInfo.ID);
                            if (parm == -1)
                            {
                                System.Windows.Forms.MessageBox.Show(this.storeManager.Err);
                                return -1;
                            }
                            if (parm == 0)
                            {
                                System.Windows.Forms.MessageBox.Show("申请可能已被出库审批 请重试!");
                                return -1;
                            }
                            System.Windows.Forms.MessageBox.Show("删除成功");
                        }

                        #endregion

                        this.MatApplyManager.Fp.StopCellEditing();

                        this.hsApplyData.Remove(dr["物品编码"].ToString());

                        this.dt.Rows.Remove(dr);

                        this.MatApplyManager.Fp.StartCellEditing(null, false);

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

        public int Clear()
        {
            try
            {
                this.dt.Rows.Clear();

                this.dt.AcceptChanges();

                this.hsApplyData.Clear();

                this.MatApplyManager.TotCostInfo = "";

                this.listNO = "";

                this.serialNO = 0;
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
            if (this.svTemp != null)
            {
                if (this.svTemp.Rows.Count > 0)
                {
                    this.MatApplyManager.SetFpFocus();

                    this.svTemp.ActiveRowIndex = this.svTemp.Rows.Count - 1;
                    this.svTemp.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
                }
                else
                {
                    this.MatApplyManager.SetFocus();
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

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].CellType = numberCellType;

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            //定义事务			

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //获取系统时间
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            if (this.listNO == "")
            {
                //获取新申请单号
                this.listNO = this.storeManager.GetApplyNO(this.MatApplyManager.DeptInfo.ID);
            }

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["物品编码"].ToString();

                Neusoft.HISFC.Models.Material.Apply apply = this.hsApplyData[key] as Neusoft.HISFC.Models.Material.Apply;

                apply.Operation.ApplyOper.OperTime = sysTime;
                apply.Operation.Oper.OperTime = sysTime;
                apply.Operation.ApproveOper.OperTime = sysTime;
                apply.Operation.ApplyOper.ID = this.MatApplyManager.OperInfo.ID;
                apply.Operation.Oper.ID = this.MatApplyManager.OperInfo.ID;
                apply.TargetDept.ID = this.MatApplyManager.TargetDept.ID;

                apply.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"].ToString());
                apply.ApplyPrice = NConvert.ToDecimal(dr["单价"].ToString());
                apply.ApplyCost = NConvert.ToDecimal(dr["申请金额"].ToString());

                apply.Class2Type = this.MatApplyManager.Class2Priv.ID;
                apply.PrivType = this.MatApplyManager.PrivType.ID;
                apply.SystemType = this.MatApplyManager.PrivType.Memo;
                apply.Extend1 = "0";
                apply.Extend3 = "1";

                apply.Memo = dr["备注"].ToString();

                if (apply.ID == "")
                {
                    apply.ApplyListNO = this.listNO;              //申请单据号

                    serialNO++;

                    apply.SerialNO = serialNO;

                    if (this.storeManager.InsertApply(apply) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.storeManager.Err);
                        return;
                    }
                }
                else
                {
                    int parm = this.storeManager.UpdateApply(apply);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show("对申请数量进行更新失败" + this.storeManager.Err);
                        return;
                    }
                    if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show("该申请单已被审核！无法进行修改!请刷新重试");
                        return;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            System.Windows.Forms.MessageBox.Show("保存申请成功");

            this.Clear();
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].CellType = numberCellType;
        }

        public int Print()
        {
            return 1;
        }

        public int Cancel()
        {
            DialogResult r;

            r = MessageBox.Show("确定要作废该申请吗？操作不可撤销！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.No)
            {
                return 1;
            }

            this.dt.DefaultView.RowFilter = "1=1";
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            if (this.listNO == "")
            {
                MessageBox.Show("该申请单尚未生效！");
                return 0;
            }

            System.Collections.Hashtable hsHave = new Hashtable();

            foreach (DataRow dr in dt.Rows)
            {
                string key = dr["物品编码"].ToString();

                Neusoft.HISFC.Models.Material.Apply apply = this.hsApplyData[key] as Neusoft.HISFC.Models.Material.Apply;

                if (!hsHave.ContainsKey(listNO))
                {
                    //定义事务			

                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();

                    this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    this.myControler.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);


                    //获取系统时间
                    DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

                    hsHave.Add(listNO, apply);

                    int parm = -1;

                    parm = this.storeManager.UpdateApplyCheck(apply.StockDept.ID, apply.ApplyListNO, apply.SerialNO, "U", apply.Operation.Oper.ID, apply.Operation.Oper.OperTime);

                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show("作废申请失败!" + this.storeManager.Err);
                        return -1;
                    }
                    if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show("该申请单状态已近发生改变!");
                        return -1;
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    System.Windows.Forms.MessageBox.Show("申请单作废成功");
                }
                else
                {
                    continue;
                }

            }

            this.Clear();

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
            this.MatApplyManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

            this.MatApplyManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.MatApplyManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
        }

        #endregion

        #region 属性

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.MatApplyManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColApplyQty)
            {
                string[] keys = new string[] { this.MatApplyManager.FpSheetView.Cells[this.MatApplyManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemID].Text };
                DataRow dr = this.dt.Rows.Find(keys);

                if (dr != null)
                {
                    dr["申请金额"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["申请数量"]) * Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["单价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.Clear();

            this.ShowSelectData();
        }

        private void value_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.MatApplyManager.FpSheetView != null)
            {
                if (key == System.Windows.Forms.Keys.Enter)
                {
                    if (this.MatApplyManager.FpSheetView.ActiveRowIndex == this.MatApplyManager.FpSheetView.Rows.Count - 1)
                    {
                        this.MatApplyManager.SetFocus();
                    }
                    else
                    {
                        this.MatApplyManager.FpSheetView.ActiveRowIndex++;
                        this.MatApplyManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
                    }
                }
            }
        }

        #endregion

        #region 列枚举

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 物品名称
            /// </summary>
            ColItemName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 单价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 单位
            /// </summary>
            ColPackUnit,
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
            /// 项目编码
            /// </summary>
            ColItemID,
            /// <summary>
            /// 序号
            /// </summary>
            ColNO,
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

        #endregion
    }
}
