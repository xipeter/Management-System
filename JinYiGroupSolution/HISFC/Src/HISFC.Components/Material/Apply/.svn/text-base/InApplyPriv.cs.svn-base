using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Neusoft.NFC.Management;
using Neusoft.NFC.Function;
using System.Windows.Forms;

namespace Neusoft.UFC.Material.Apply
{
    /// <summary>
    /// [功能描述: 入库申请业务类]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public class InApplyPriv :IMatManager
    {
        /// <summary>
        /// 入库申请
        /// </summary>
        /// <param name="isBakcIn"></param>
        /// <param name="ucMatApplyManager">正常入库FALSE , 退库入库TRUE </param>
        public InApplyPriv(bool isBakcIn, Apply.ucApply ucMatApplyManager)
        {
            this.isBack = isBakcIn;

            this.listNO = "";

            this.SetMaterialProperty(ucMatApplyManager);

        }


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
        private Apply.ucApply MatApplyManager;

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
        private Neusoft.HISFC.Management.Material.Store storeManager = new Neusoft.HISFC.Management.Material.Store();

        /// <summary>
        /// 字典管理类
        /// </summary>
        private Neusoft.HISFC.Management.Material.MetItem itemManager = new Neusoft.HISFC.Management.Material.MetItem();

        /// <summary>
        /// 控制参数
        /// </summary>
        private Neusoft.HISFC.Management.Manager.Controler myControler = new Neusoft.HISFC.Management.Manager.Controler();

        private Neusoft.HISFC.Management.Manager.Department myDept = new Neusoft.HISFC.Management.Manager.Department();

        private Neusoft.HISFC.Management.Manager.Person myPerson = new Neusoft.HISFC.Management.Manager.Person();

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

        private void SetMaterialProperty(Apply.ucApply ucMatApplyManager)
        {
            this.MatApplyManager = ucMatApplyManager;

            if (this.MatApplyManager != null)
            {
                //设置界面显示
                this.MatApplyManager.IsShowItemSelectpanel = true;
                this.MatApplyManager.IsShowInputPanel = false;

                //根据入出库类型设置目标科室和项目选择列表
                if (this.MatApplyManager.IOType == "1")
                {
                    //根据内部申请还是外部申请设置目标科室和项目列表
                    if (this.MatApplyManager.DeptInfo.Memo == "L")
                    {
                        //设置外部申请目标科室信息
                        this.MatApplyManager.SetTargetDept(true, false, Neusoft.HISFC.Object.IMA.EnumModuelType.Material,Neusoft.HISFC.Object.Base.EnumDepartmentType.L);
                        //设置外部申请显示的待选择数据
                        this.MatApplyManager.SetSelectData("0", false, null, null, null);
                    }
                    else
                    {
                        //设置内部申请目标科室信息
                        this.MatApplyManager.SetTargetDept(false, true, Neusoft.HISFC.Object.IMA.EnumModuelType.Material, Neusoft.HISFC.Object.Base.EnumDepartmentType.L);
                        //设置内部申请显示的待选择数据
                        this.MatApplyManager.SetSelectData("1", false, null, null, null);
                    }

                }
                else
                {
                    //设置出库申请目标科室信息
                    this.MatApplyManager.SetTargetDept(false, true, Neusoft.HISFC.Object.IMA.EnumModuelType.Material, Neusoft.HISFC.Object.Base.EnumDepartmentType.L);
                    //设置出库申请显示的待选择数据
                    this.MatApplyManager.SetSelectData("2", false, null, null, null);
                }

                this.MatApplyManager.SetItemListWidth(2);
                //设置工具栏按钮显示
                this.MatApplyManager.SetToolButton(true, false, false, true, false);
                this.MatApplyManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //设置信息显示
                this.MatApplyManager.ShowInfo = "";
                //Fp 设置
                this.MatApplyManager.FpSheetView.DataAutoSizeColumns = true;
                this.MatApplyManager.Fp.EditModeReplace = true;

                this.MatApplyManager.EndTargetChanged -= new Apply.ucApply.DataChangedHandler(value_EndTargetChanged);
                this.MatApplyManager.EndTargetChanged += new Apply.ucApply.DataChangedHandler(value_EndTargetChanged);

                this.MatApplyManager.FpKeyEvent -= new Apply.ucApply.FpKeyHandler(value_FpKeyEvent);
                this.MatApplyManager.FpKeyEvent += new Apply.ucApply.FpKeyHandler(value_FpKeyEvent);

                this.MatApplyManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.MatApplyManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

            }
        }

        /// <summary>
        /// 向DataTable内增加数据
        /// </summary>
        /// <param name="apply">申请信息</param>
        /// <param name="dataSource">数据来源 0 原始数据 1 本次添加</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Object.Material.Apply apply, string dataSource)
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
												  apply.OutQty,
												  apply.OutCost,
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
        protected virtual int AddApplyToTable(Neusoft.HISFC.Object.Material.Apply apply, string dataSource)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                Neusoft.HISFC.Management.Material.MetItem managerItem = new Neusoft.HISFC.Management.Material.MetItem();
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
												  apply.OutQty,
												  apply.OutCost,
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

            foreach (Neusoft.HISFC.Object.Material.Apply info in alDetail)
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
        /// 根据申请单号增加申请数据
        /// </summary>
        /// <param name="listNO"></param>
        /// <returns></returns>
        private int AddApplyDataSelf(string listNO)
        {
            ArrayList alDetail = this.storeManager.QueryApplyDetailByListNOSelf(this.MatApplyManager.DeptInfo.ID, listNO, "MU");
            if (alDetail == null)
            {
                System.Windows.Forms.MessageBox.Show("未正确获取内部入库申请信息" + this.storeManager.Err);
                return -1;
            }

            this.Clear();

            ((System.ComponentModel.ISupportInitialize)(this.MatApplyManager.Fp)).BeginInit();

            int i = 0;

            foreach (Neusoft.HISFC.Object.Material.Apply info in alDetail)
            {
                if (this.AddApplyToTable(info, "0") == -1)
                    return -1;

                this.listNO = info.ApplyListNO;

                if (i < info.SerialNO)
                {
                    i = info.SerialNO;
                }

                if (info == alDetail[0])
                {
                    Neusoft.HISFC.Object.Base.Employee person = myPerson.GetPersonByID(info.Operation.ApproveOper.ID);

                    Neusoft.HISFC.Object.Base.Department dept = myDept.GetDeptmentById(info.StockDept.ID);

                    if (person != null && dept != null)
                    {
                        this.showInfo = "申请单:" + info.ApplyListNO + " 申请科室:" + dept.Name + " 科室审批:" + person.Name;
                    }
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
        private int AddDrugData(Neusoft.HISFC.Object.Material.Apply apply)
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

            Neusoft.HISFC.Object.Material.MaterialItem item = itemManager.GetMetItemByMetID(drugNO);

            if (item == null)
            {
                System.Windows.Forms.MessageBox.Show("检索物品基本信息失败");
                return -1;
            }

            Neusoft.HISFC.Object.Material.Apply apply = new Neusoft.HISFC.Object.Material.Apply();

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
                string[] label = new string[] { "出库序号", "出库单据号", "物品编码", "物品名称", "规格", "数量", "包装单位", "最小单位", "拼音码", "五笔码" };
                int[] width = new int[] { 60, 60, 60, 120, 80, 60, 60, 60, 60, 60 };
                bool[] visible = new bool[] { false, false, false, true, true, true, false, true, false, false };

                this.MatApplyManager.SetSelectData("3", false, new string[] { "Material.Store.GetOutputInfoForInput" }, filterStr, this.MatApplyManager.DeptInfo.ID, "A", "2", this.MatApplyManager.TargetDept.ID);

                this.MatApplyManager.SetSelectFormat(label, width, visible);
            }
            else
            {
                if (this.MatApplyManager.IOType == "1" && this.MatApplyManager.DeptInfo.Memo != "L")
                {
                    this.MatApplyManager.SetSelectData("1", false, null, null, null);
                }

            }

            this.MatApplyManager.SetItemListWidth(2);

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

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColItemName].Width = 150F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 100F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 80F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 80F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Width = 80F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].Width = 100F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 100F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 100F;

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColItemID].Visible = false;           //物品编码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColNO].Visible = false;               //序号
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 200F;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Locked = false;
            this.MatApplyManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Locked = false;
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
            //					using (UFC.Pharmacy.ucPhaAlter uc = new ucPhaAlter())
            //					{
            //						uc.DeptCode = deptCode;
            //						uc.SetData();
            //						uc.Focus();
            //						Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
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
            //				Neusoft.HISFC.Object.Pharmacy.Item item = new Neusoft.HISFC.Object.Pharmacy.Item();
            //				foreach (Neusoft.NFC.Object.NeuObject temp in alDetail)
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
                    retailCost += Neusoft.NFC.Function.NConvert.ToDecimal(dr["申请数量"]) * Neusoft.NFC.Function.NConvert.ToDecimal(dr["单价"]);
                }

                this.MatApplyManager.TotCostInfo = string.Format("申请总金额:{0} ", retailCost.ToString("N"));
            }
        }

        #endregion

        #region IMatManager 成员

        public Neusoft.NFC.Interface.Controls.ucBaseControl InputModualUC
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
												 new DataColumn("发放数量",dtDec),//-liuxq add
												 new DataColumn("发放金额",dtDec),//-liuxq add
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

            if (this.MatApplyManager.IOType == "0")
            {
                drugID = sv.Cells[activeRow, 0].Value.ToString();
                //取物品字典信息							
                Neusoft.HISFC.Object.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(drugID);
                //出库申请单实体
                Neusoft.HISFC.Object.Material.Apply apply = new Neusoft.HISFC.Object.Material.Apply();

                apply.Item = item;
                apply.ApplyPrice = NConvert.ToDecimal(sv.Cells[activeRow, 4].Value.ToString());

                return this.AddDrugData(apply);
            }
            else
            {
                if (isBack)
                {
                    drugID = sv.Cells[activeRow, 0].Value.ToString();

                    string outbillNO = sv.Cells[activeRow, 0].Value.ToString();
                    return this.AddDrugData(drugID, outbillNO);
                }
                else
                {
                    drugID = sv.Cells[activeRow, 0].Value.ToString();
                    return this.AddDrugData(drugID);
                }
            }
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, Neusoft.HISFC.Object.Material.Input input)
        {
            string drugID = "";

            if (this.MatApplyManager.IOType == "0")
            {
                drugID = input.StoreBase.Item.ID;
                //取物品字典信息							
                Neusoft.HISFC.Object.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(drugID);
                //出库申请单实体
                Neusoft.HISFC.Object.Material.Apply apply = new Neusoft.HISFC.Object.Material.Apply();

                apply.Item = item;
                apply.ApplyPrice = input.StoreBase.PriceCollection.PurchasePrice;

                return this.AddDrugData(apply);
            }

            return 1;
        }

        public int ShowApplyList()
        {
            string class2Type = "";

            if (this.MatApplyManager.IOType == "1")
            {
                class2Type = "0510";
            }
            else
            {
                class2Type = "0520";
            }

            //获取申请信息
            ArrayList alTemp = new ArrayList();

         
                if (this.MatApplyManager.DeptInfo.Memo == "L")
                {
                    alTemp = this.storeManager.QueryApplySimple(this.MatApplyManager.DeptInfo.ID, class2Type, "0", "12");
                }
                else
                {
                    alTemp = this.storeManager.QueryApplySimple(this.MatApplyManager.DeptInfo.ID, class2Type, "0", "13");
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
            //				foreach (Neusoft.NFC.Object.NeuObject info in alTemp)
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
            //			Neusoft.NFC.Object.NeuObject selectObj = new Neusoft.NFC.Object.NeuObject();
            //			string[] fpLabel = { "申请单号", "供货单位" };
            //			float[] fpWidth = { 120F, 120F };
            //			bool[] fpVisible = { true, true, false, false, false, false };

            Neusoft.NFC.Object.NeuObject selectObject = new Neusoft.NFC.Object.NeuObject();

            if (Neusoft.NFC.Interface.Classes.Function.ChooseItem(alTemp, ref selectObject) == 1)
            {
                this.Clear();

                Neusoft.NFC.Object.NeuObject targeDept = new Neusoft.NFC.Object.NeuObject();

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
                    if (Neusoft.NFC.Function.NConvert.ToDecimal(dr["申请数量"]) <= 0)
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

        //public void SetFormat()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

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

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            //定义事务			
            Neusoft.NFC.Management.Transaction t = new Transaction(Neusoft.NFC.Management.Connection.Instance);
            t.BeginTransaction();
            this.storeManager.SetTrans(t.Trans);

            //获取系统时间
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            if (this.listNO == "")
            {
                //获取新申请单号
                this.listNO = this.storeManager.GetApplyNO(this.MatApplyManager.DeptInfo.ID);
            }

            //			int serialNO = 0;

            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = dr["物品编码"].ToString();

                Neusoft.HISFC.Object.Material.Apply apply = this.hsApplyData[key] as Neusoft.HISFC.Object.Material.Apply;

                apply.Operation.ApplyOper.OperTime = sysTime;
                apply.Operation.Oper.OperTime = sysTime;
                apply.Operation.ApproveOper.OperTime = sysTime;
                apply.Operation.ApplyOper.ID = this.MatApplyManager.OperInfo.ID;
                apply.Operation.Oper.ID = this.MatApplyManager.OperInfo.ID;
                apply.TargetDept.ID = this.MatApplyManager.TargetDept.ID;

                apply.Operation.ApplyQty = NConvert.ToDecimal(dr["申请数量"].ToString());
                apply.ApplyPrice = NConvert.ToDecimal(dr["单价"].ToString());
                apply.ApplyCost = NConvert.ToDecimal(dr["申请金额"].ToString());


                if (this.MatApplyManager.IOType == "1")
                {
                    apply.Class2Type = "0510";

                    if (this.isBack)
                    {
                        apply.SystemType = "18";
                        apply.State = "M";
                    }
                    else
                    {
                        if (this.MatApplyManager.DeptInfo.Memo == "L")
                        {
                            apply.SystemType = "12";
                        }
                        else
                        {
                            apply.SystemType = "13";
                        }
                    }

                }
                else
                {
                    apply.Class2Type = "0520";
                    apply.SystemType = "24";
                }


                apply.Memo = dr["备注"].ToString();

                if (apply.ID == "")
                {
                    apply.ApplyListNO = this.listNO;              //申请单据号

                    serialNO++;

                    apply.SerialNO = serialNO;

                    if (this.storeManager.InsertApply(apply) == -1)
                    {
                        t.RollBack();
                        MessageBox.Show(this.storeManager.Err);
                        return;
                    }
                }
                else
                {
                    int parm = this.storeManager.UpdateApply(apply);
                    if (parm == -1)
                    {
                        t.RollBack();
                        System.Windows.Forms.MessageBox.Show("对申请数量进行更新失败" + this.storeManager.Err);
                        return;
                    }
                    if (parm == 0)
                    {
                        t.RollBack();
                        System.Windows.Forms.MessageBox.Show("该申请单已被审核！无法进行修改!请刷新重试");
                        return;
                    }
                }
            }

            t.Commit();

            System.Windows.Forms.MessageBox.Show("保存申请成功");

            this.Clear();
        }

        public void SaveCheck(bool IsHeaderCheck)
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

            //定义事务			
            Neusoft.NFC.Management.Transaction t = new Transaction(Neusoft.NFC.Management.Connection.Instance);
            t.BeginTransaction();
            this.storeManager.SetTrans(t.Trans);
            this.myControler.SetTrans(t.Trans);

            //物资科室请领是否需要库房审核
            Neusoft.HISFC.Object.Base.Controler controler = this.myControler.QueryControlInfoByCode("WZ0001");


            //获取系统时间
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            foreach (DataRow dr in dt.Rows)
            {
                string key = dr["物品编码"].ToString();

                Neusoft.HISFC.Object.Material.Apply apply = this.hsApplyData[key] as Neusoft.HISFC.Object.Material.Apply;

                apply.Operation.ApplyOper.OperTime = sysTime;
                apply.Operation.Oper.OperTime = sysTime;
                apply.Operation.ApproveOper.OperTime = sysTime;
                apply.Operation.ApplyOper.ID = this.MatApplyManager.OperInfo.ID;
                apply.Operation.Oper.ID = this.MatApplyManager.OperInfo.ID;
                apply.TargetDept.ID = this.MatApplyManager.TargetDept.ID;
                apply.OutQty = Neusoft.NFC.Function.NConvert.ToDecimal(dr["发放数量"].ToString());
                apply.OutCost = Neusoft.NFC.Function.NConvert.ToDecimal(dr["发放金额"].ToString());
                apply.Operation.ApplyQty = Neusoft.NFC.Function.NConvert.ToDecimal(dr["申请数量"].ToString());
                decimal applyCost = apply.Operation.ApplyQty * Neusoft.NFC.Function.NConvert.ToDecimal(dr["单价"].ToString());
                int parm = -1;

                if (IsHeaderCheck)
                {
                    parm = this.storeManager.UpdateApplyHeaderCheck(apply.StockDept.ID, apply.ApplyListNO, apply.SerialNO, "M", apply.Operation.Oper.ID, apply.Operation.Oper.OperTime, apply.OutQty, apply.OutCost);
                }
                else
                {
                    if (controler != null && controler.ControlerValue == "1")
                    {
                        parm = this.storeManager.UpdateApplyCheckAndNum(apply.StockDept.ID, apply.ApplyListNO, apply.SerialNO, "MU", apply.Operation.Oper.ID, apply.Operation.Oper.OperTime, apply.Operation.ApplyQty, applyCost);
                    }
                    else
                    {
                        parm = this.storeManager.UpdateApplyCheckAndNum(apply.StockDept.ID, apply.ApplyListNO, apply.SerialNO, "M", apply.Operation.Oper.ID, apply.Operation.Oper.OperTime, apply.Operation.ApplyQty, applyCost);
                    }
                }
                if (parm == -1)
                {
                    t.RollBack();
                    System.Windows.Forms.MessageBox.Show("对申请数量进行更新失败" + this.storeManager.Err);
                    return;
                }
                if (parm == 0)
                {
                    t.RollBack();
                    System.Windows.Forms.MessageBox.Show("该申请单已被审核！无法进行修改!请刷新重试");
                    return;
                }

            }

            t.Commit();

            System.Windows.Forms.MessageBox.Show("申请单审核成功");

            this.Clear();
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

                Neusoft.HISFC.Object.Material.Apply apply = this.hsApplyData[key] as Neusoft.HISFC.Object.Material.Apply;

                if (!hsHave.ContainsKey(listNO))
                {
                    //定义事务			
                    Neusoft.NFC.Management.Transaction t = new Transaction(Neusoft.NFC.Management.Connection.Instance);
                    t.BeginTransaction();
                    this.storeManager.SetTrans(t.Trans);
                    this.myControler.SetTrans(t.Trans);


                    //获取系统时间
                    DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

                    hsHave.Add(listNO, apply);

                    int parm = -1;

                    parm = this.storeManager.UpdateApplyCheck(apply.StockDept.ID, apply.ApplyListNO, apply.SerialNO, "U", apply.Operation.Oper.ID, apply.Operation.Oper.OperTime);

                    if (parm == -1)
                    {
                        t.RollBack();
                        System.Windows.Forms.MessageBox.Show("作废申请失败!" + this.storeManager.Err);
                        return -1;
                    }
                    if (parm == 0)
                    {
                        t.RollBack();
                        System.Windows.Forms.MessageBox.Show("该申请单状态已近发生改变!");
                        return -1;
                    }

                    t.Commit();

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

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.MatApplyManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColApplyQty)
            {
                string[] keys = new string[] { this.MatApplyManager.FpSheetView.Cells[this.MatApplyManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemID].Text };
                DataRow dr = this.dt.Rows.Find(keys);

                if (dr != null)
                {
                    dr["申请金额"] = Neusoft.NFC.Function.NConvert.ToDecimal(dr["申请数量"]) * Neusoft.NFC.Function.NConvert.ToDecimal(dr["单价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
            if (this.MatApplyManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
            {
                string[] keys = new string[] { this.MatApplyManager.FpSheetView.Cells[this.MatApplyManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColItemID].Text };
                DataRow dr = this.dt.Rows.Find(keys);

                if (dr != null)
                {
                    dr["发放金额"] = Neusoft.NFC.Function.NConvert.ToDecimal(dr["发放数量"]) * Neusoft.NFC.Function.NConvert.ToDecimal(dr["单价"]);

                    dr.EndEdit();
                }
            }
        }


        private void value_EndTargetChanged(Neusoft.NFC.Object.NeuObject changeData, object param)
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
                        if (this.MatApplyManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
                        {
                            this.MatApplyManager.SetFocus();
                        }
                    }
                }
            }
        }


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
            /// 发放数量
            /// </summary>
            ColOutQty,
            /// <summary>
            /// 发放金额
            /// </summary>
            ColOutCost,
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
    }
}
