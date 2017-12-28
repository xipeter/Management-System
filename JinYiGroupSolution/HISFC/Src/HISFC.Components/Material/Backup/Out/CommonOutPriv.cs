using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using System.Collections;
using Neusoft.HISFC.Components.Common.Controls;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material.Out
{
    public class CommonOutPriv : IMatManager
    {
        /// <summary>
        /// 实例构造
        /// </summary>
        /// <param name="isSpecialOut">是否特殊出库</param>
        /// <param name="ucMatOutManager">出库组件</param>
        public CommonOutPriv(bool isSpecialOut, Out.ucMatOut ucMatOutManager)
        {
            this.isSpecialOut = isSpecialOut;

            this.SetMatManagerProperty(ucMatOutManager);
        }

        #region 域变量

        /// <summary>
        /// 出库组件
        /// </summary>
        private Out.ucMatOut outManager = null;

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 存储出库实体信息
        /// </summary>
        private System.Collections.Hashtable hsOutData = new Hashtable();

        /// <summary>
        /// 存储已添加的项目信息 防止重复添加
        /// </summary>
        private System.Collections.Hashtable hsItemData = new Hashtable();

        /// <summary>
        /// 三级关联权限
        /// </summary>
        private Neusoft.HISFC.Models.Admin.PowerLevelClass3 privJoinClass3 = null;

        /// <summary>
        /// 存储申请实体信息
        /// </summary>
        private System.Collections.Hashtable hsApplyData = new Hashtable();

        /// <summary>
        /// 物资库存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资项目管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 单据选择控件
        /// {ACF15225-76EA-4760-A8C4-93D2A2CDFA3A}
        /// </summary>
        private Material.ucMatListSelect ucListSelect = null;
        /// <summary>
        /// 数量出库时是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = true;

        /// <summary>
        /// 是否特殊出库
        /// </summary>
        private bool isSpecialOut = false;

        /// <summary>
        /// 待打印数据
        /// </summary>
        private List<Neusoft.HISFC.Models.Material.Output> alOutPut = null;

        #endregion

        #region 方法

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetMatManagerProperty(Out.ucMatOut ucOutManager)
        {
            this.outManager = ucOutManager;

            if (this.outManager != null)
            {
                //设置界面显示
                this.outManager.IsShowItemSelectpanel = true;
                this.outManager.IsShowInputPanel = false;
                //设置目标科室信息 目标人员信息
                this.outManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                this.outManager.SetTargetPerson(true, Neusoft.HISFC.Models.Base.EnumEmployeeType.P);
                //设置工具栏按钮显示{ACF15225-76EA-4760-A8C4-93D2A2CDFA3A}
                //将第二个改成true 提供入库单查询用作即入即出 by yuyun 08-7-29
                //将第一个第四个改成false 一般出库的时候不查询申请单和采购单
                this.outManager.SetToolBarButtonVisible(false, true, false, false, true, true, false);
                //设置显示的待选择数据
                this.outManager.SetSelectData("2", false, null, null, null);
                //设置项目列表宽度
                this.outManager.SetItemListWidth(4);
                //提示信息设置
                this.outManager.ShowInfo = "";

                if (this.isSpecialOut)
                {
                    this.outManager.TargetDept = this.outManager.DeptInfo;
                }

                this.outManager.Fp.EditModeReplace = true;

                this.outManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(outManager_EndTargetChanged);
                this.outManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(outManager_EndTargetChanged);

                this.outManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(outManager_FpKeyEvent);
                this.outManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(outManager_FpKeyEvent);

                this.outManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.outManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

                Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerLevelManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();

                Neusoft.HISFC.Models.Admin.PowerLevelClass3 privClass3 = powerLevelManager.LoadLevel3ByPrimaryKey(this.outManager.Class2Priv.ID, this.outManager.PrivType.ID);

                if (privClass3 != null)
                {
                    privJoinClass3 = powerLevelManager.LoadLevel3ByPrimaryKey("0510", privClass3.Class3Code);
                }
            }
        }

        /// <summary>
        /// 将实体信息加入DataTable内
        /// </summary>
        /// <param name="output">出库信息 Output.User01存储数据来源</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Material.Output output)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal storeQty = output.StoreBase.StoreQty;
                decimal outQty = output.StoreBase.Quantity;
                decimal outCost = output.StoreBase.Quantity * output.StoreBase.PriceCollection.PurchasePrice;

                if (!this.isUseMinUnit)			//使用包装单位进行出库
                {
                    storeQty = output.StoreBase.StoreQty / output.StoreBase.Item.PackQty;
                    outQty = output.StoreBase.Quantity / output.StoreBase.Item.PackQty;
                }

                if (this.isUseMinUnit)
                {
                    this.dt.Rows.Add(new object[] { 
													  output.StoreBase.Item.Name,                           //物品名称
													  output.StoreBase.Item.Specs,                          //规格
													  output.StoreBase.BatchNO,                             //批号
													  output.StoreBase.PriceCollection.PurchasePrice,		//购入价
													  output.StoreBase.PriceCollection.RetailPrice,			//零售价
													  output.StoreBase.Item.PackUnit,						//包装单位
													  output.StoreBase.Item.MinUnit,						//最小单位
													  storeQty,												//库存数量
													  outQty,												//出库数量
													  outCost,												//出库金额
													  output.Memo,											//备注
													  output.StoreBase.Item.ID,								//项目编码
													  output.User01,										//数据来源
													  output.StoreBase.Item.SpellCode,						//拼音码
													  output.StoreBase.Item.WbCode,							//五笔码
													  output.StoreBase.Item.UserCode,						//自定义码
													  output.User03											//主键                        
												  }
                        );
                }
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
        /// 根据Dr内数据对实体进行赋值
        /// </summary>
        /// <param name="dr">数据表</param>
        /// <param name="sysTime">当前时间</param>
        /// <param name="output">ref 出库实体信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int GetOutputFormDataRow(DataRow dr, DateTime sysTime, ref Neusoft.HISFC.Models.Material.Output output)
        {
            //出库数量
            if (this.isUseMinUnit)			//使用最小单位
            {
                output.StoreBase.Quantity = NConvert.ToDecimal(dr["出库数量"]);
            }
            else
            {
                output.StoreBase.Quantity = NConvert.ToDecimal(dr["出库数量"]) * output.StoreBase.Item.PackQty;
            }

            //{7A107ECA-0534-486b-AA74-8CFC0A1E01F2} 写入出库金额
            output.OutCost = output.StoreBase.PriceCollection.PurchasePrice * output.StoreBase.Quantity;

            output.StoreBase.Operation.Oper.ID = this.outManager.OperInfo.ID;
            output.StoreBase.Operation.Oper.OperTime = sysTime;

            output.StoreBase.Operation.ExamOper = output.StoreBase.Operation.Oper;		//审批人
            output.StoreBase.Operation.ExamQty = output.StoreBase.Quantity;

            output.Memo = dr["备注"].ToString();										//备注
            if (this.outManager.TargetPerson != null)									//领药人
            {
                output.DrawOper = this.outManager.TargetPerson;
            }

            output.StoreBase.PrivType = this.outManager.PrivType.ID;               //出库类型
            output.StoreBase.SystemType = this.outManager.PrivType.Memo;           //系统类型
            output.StoreBase.StockDept = this.outManager.DeptInfo;                 //当前科室
            output.StoreBase.TargetDept = this.outManager.TargetDept;              //目标科室

            //借方科目 暂时赋值为空
            output.Debit = "";

            return 1;
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

            ArrayList alDetail = this.storeManager.QueryApplyDetailByListNO(this.outManager.DeptInfo.ID, listCode, "0");
            if (alDetail == null)
            {
                MessageBox.Show(this.storeManager.Err);
                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).BeginInit();



            foreach (Neusoft.HISFC.Models.Material.Apply apply in alDetail)
            {
                Neusoft.HISFC.Models.Material.Output output = new Neusoft.HISFC.Models.Material.Output();
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
                //				output.StoreBase.Quantity = apply.OutQty;

                output.User01 = "1";											//数据来源 申请
                output.User02 = apply.ID;										//申请单流水号

                //output.User03 = this.GetKey();												//设置主键
                output.User03 = output.StoreBase.Item.ID.ToString() + output.StoreBase.PriceCollection.RetailPrice.ToString();	//设置主键(入出库价格相同)

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
        }

        //		/// <summary>
        //		/// 根据物品信息添加出库记录
        //		/// </summary>
        //		/// <param name="itemNO">物资项目编码</param>
        //		/// <param name="storageQty">库存数量</param>
        //		/// <returns></returns>
        //		protected virtual int AddDrugData(string itemNO,decimal storageQty)
        //		{
        //			this.AddApplyData(itemNO,storageQty,0);
        //		}
        /// <summary>
        /// 根据物品信息添加出库记录
        /// </summary>
        /// <param name="itemNO">物资项目编码</param>
        /// <param name="storageQty">库存数量</param>
        /// <returns></returns>
        protected virtual int AddDrugData(string itemNO, decimal storageQty, decimal price)
        {
            if (this.outManager.TargetDept.ID == "")
            {
                MessageBox.Show("请选择领用单位!");
                return 0;
            }

            if (this.hsItemData.ContainsKey(itemNO + price.ToString()))
            {
                MessageBox.Show("该物品已添加");
                return 0;
            }

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(itemNO);
            if (item == null)
            {
                MessageBox.Show("根据编码获取物资字典信息时发生错误" + this.itemManager.Err);
                return -1;
            }

            Neusoft.HISFC.Models.Material.Output output = new Neusoft.HISFC.Models.Material.Output();

            output.StoreBase.Item = item;												//物品信息

            output.StoreBase.PrivType = this.outManager.PrivType.ID;					//出库类型
            output.StoreBase.SystemType = this.outManager.PrivType.Memo;				//系统类型
            output.StoreBase.StockDept = this.outManager.DeptInfo;						//当前科室
            output.StoreBase.TargetDept = this.outManager.TargetDept;					//目标科室
            output.StoreBase.StoreQty = storageQty;										//库存量
            if (price <= 0)
            {
                output.StoreBase.PriceCollection.PurchasePrice = item.UnitPrice;
            }
            else
            {
                output.StoreBase.PriceCollection.PurchasePrice = price;
                output.StoreBase.PriceCollection.RetailPrice = price;
            }

            output.User01 = "0";														//数据来源
            //output.User03 = this.GetKey();												//设置主键
            output.User03 = output.StoreBase.Item.ID.ToString() + output.StoreBase.PriceCollection.RetailPrice.ToString();

            if (this.AddDataToTable(output) == 1)
            {
                this.hsOutData.Add(output.User03, output);

                //this.hsItemData.Add(output.StoreBase.Item.ID, null);						//存储已添加的项目 防止重复添加
                this.hsItemData.Add(output.User03, null);
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
                    retailCost += NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);
                }
                this.outManager.TotCostInfo = string.Format("出库金额:{0}", retailCost.ToString("C4"));
            }
        }

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns></returns>
        private string GetKey()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["主键"].ToString();
        }

        /// <summary>
        /// 根据项目实体获取主键
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Material.Output output)
        {
            return output.User03;
        }

        /// <summary>
        /// 由Fp内获取主键
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        private string GetKey(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            return sv.Cells[activeRow, (int)ColumnSet.ColKey].Text;
        }

        /// <summary>
        /// 获取主键数组
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow"></param>
        /// <returns></returns>
        private string[] GetFindKey(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            return new string[] { sv.Cells[activeRow, (int)ColumnSet.ColKey].Text };
        }

        #endregion

        #region IMatManager 成员

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
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),
												 new DataColumn("批号",      dtStr),
												 new DataColumn("购入价",    dtDec),
												 new DataColumn("零售价",    dtDec),
												 new DataColumn("包装单位",  dtStr),
												 new DataColumn("最小单位",  dtStr),
												 new DataColumn("库存数量",  dtDec),
												 new DataColumn("出库数量",  dtDec),
												 new DataColumn("出库金额",  dtDec),
												 new DataColumn("备注",      dtStr),
												 new DataColumn("项目编码",  dtStr),
												 new DataColumn("数据来源",  dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr),
												 new DataColumn("主键",		 dtStr)
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
        /// 项目信息添加
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="activeRow">新增行</param>
        /// <returns></returns>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            //-----by yuyun 08-7-25 第一列变成自定义码  原自定义码列成物资编码{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            //string itemNO = sv.Cells[activeRow, 0].Text;
            string itemNO = sv.Cells[activeRow, 11].Text;

            decimal storeQty = NConvert.ToDecimal(sv.Cells[activeRow, 4].Text);
            decimal storePrice = NConvert.ToDecimal(sv.Cells[activeRow, 3].Text);

            if (this.AddDrugData(itemNO, storeQty, storePrice) == 1)
            {
                this.SetFocusSelect();
            }
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

        /// <summary>
        /// 申请列表显示 加载
        /// </summary>
        /// <returns></returns>

        public int ShowApplyList()
        {
            ArrayList alTemp = new ArrayList();
            //获取申请信息{CAC9F782-773F-4507-AD2D-C0F73513FF42}
            string currentDeptID = string.Empty;
            currentDeptID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;

            alTemp = this.storeManager.QueryApplySimple(this.outManager.TargetDept.ID, currentDeptID, "0510", "0", "13");

            if (alTemp == null)
            {
                System.Windows.Forms.MessageBox.Show("获取申请信息失败" + this.storeManager.Err);
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject selectObject = new Neusoft.FrameWork.Models.NeuObject();

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alTemp, ref selectObject) == 1)
            {
                this.Clear();

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                this.AddApplyData(selectObject.ID, "0");
                this.SetFocusSelect();

                if (this.outManager.FpSheetView != null)
                    this.outManager.FpSheetView.ActiveRowIndex = 0;
            }

            return 1;
        }

        /// <summary>
        /// 显示入库单{ACF15225-76EA-4760-A8C4-93D2A2CDFA3A}
        /// </summary>
        /// <returns></returns>
        public int ShowInList()
        {
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucMatListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.outManager.DeptInfo;
                System.Collections.Hashtable hsState = new Hashtable();
                hsState.Add("0", "未录发票");
                hsState.Add("1", "已录发票未核准");
                hsState.Add("2", "已核准");
                this.ucListSelect.InOutStateCollection = hsState;

                this.ucListSelect.State = "2";                  //需检索状态 
                System.Collections.Hashtable hs = new Hashtable();
                hs.Add("06", null);                             //过滤入库退库的单据
                this.ucListSelect.MarkPrivType = hs;

                this.ucListSelect.Class2Priv = "0510";          //入库

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

        public int ShowOutList()
        {
            // TODO:  添加 CommonOutPriv.ShowOutList 实现
            return 0;
        }

        public int ShowStockList()
        {
            // TODO:  添加 CommonOutPriv.ShowStockList 实现
            return 0;
        }

        public bool Valid()
        {
            // TODO:  添加 CommonOutPriv.Valid 实现
            for (int i = 0; i < this.outManager.FpSheetView.Rows.Count; i++)
            {
                if (((decimal)this.outManager.FpSheetView.Cells[i, (int)ColumnSet.ColStoreQty].Value) < ((decimal)this.outManager.FpSheetView.Cells[i, (int)ColumnSet.ColOutQty].Value))
                {
                    MessageBox.Show("出库数量大于库存数量，请重新输入!", "提示");
                    return false;
                }
            }
            //{30496509-D9AD-4049-A4AE-439BAFC0A704}
            if (this.outManager.TargetDept == null || string.IsNullOrEmpty(this.outManager.TargetDept.ID))
            {
                MessageBox.Show("请选择出库的目标科室！", "提示");

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
                    string keys = string.Format(sv.Cells[delRowIndex, (int)ColumnSet.ColItemNO].Text.ToString() + sv.Cells[delRowIndex, (int)ColumnSet.ColRetailPrice].Text.ToString());

                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.outManager.Fp.StopCellEditing();

                        this.hsOutData.Remove(dr["项目编码"].ToString() + dr["零售价"].ToString());
                        this.hsItemData.Remove(dr["项目编码"].ToString() + dr["零售价"].ToString());

                        this.dt.Rows.Remove(dr);

                        this.outManager.Fp.StartCellEditing(null, false);
                        //合计计算
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

        public virtual void SetFormat()
        {
            this.outManager.FpSheetView.DefaultStyle.Locked = true;
            this.outManager.FpSheetView.DataAutoSizeColumns = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 65F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Width = 60F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Width = 80F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Width = 70F;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].Width = 70F;

            //购入价和出库金额显示小数点后4位
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;          //批号 
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColItemNO].Visible = false;           //物品编码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;                  //主键

            if (this.isUseMinUnit)
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Visible = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Locked = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].BackColor = System.Drawing.Color.SeaShell;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;
        }

        public int Clear()
        {
            this.hsOutData.Clear();
            this.hsApplyData.Clear();
            this.hsItemData.Clear();
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();
            return 1;
        }

        public void Filter(string filterStr)
        {
            // TODO:  添加 CommonOutPriv.Filter 实现
        }

        public void SetFocusSelect()
        {
            if (this.outManager.FpSheetView != null)
            {
                if (this.outManager.FpSheetView.Rows.Count > 0)
                {
                    this.outManager.SetFpFocus();

                    this.outManager.FpSheetView.ActiveRowIndex = this.outManager.FpSheetView.Rows.Count - 1;
                    this.outManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColOutQty;
                }
                else
                {
                    this.outManager.SetFocus();
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            //检查合法性
            if (!this.Valid())
            {
                return;
            }

            DialogResult rs = MessageBox.Show("确认向" + this.outManager.TargetDept.Name + "进行出库操作吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            this.dt.DefaultView.RowFilter = "1=1";

            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
                return;

            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.HISFC.BizLogic.Material.Baseset matConstant = new Neusoft.HISFC.BizLogic.Material.Baseset();
            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //matConstant.SetTrans(t.Trans);
            matConstant.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion
            //取系统时间
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            #region 判断领用科室是否关联库存

            bool isManagerStore = false;
            Neusoft.HISFC.Models.Material.MaterialStorage matStorage = matConstant.QueryStorageInfo(this.outManager.TargetDept.ID);
            if (matStorage != null && matStorage.IsStoreManage)
            {
                isManagerStore = true;
                DialogResult reResult = MessageBox.Show(Language.Msg(this.outManager.TargetDept.Name + "管理库存。确认进行出库操作吗?\n出库时将直接更新对方库存"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (reResult == DialogResult.No)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
                System.Windows.Forms.Application.DoEvents();
            }

            #endregion

            //一般出库对应的入库记录
            Neusoft.HISFC.Models.Material.Input input = null;
            //出库单据号
            string outListNO = null;
            //单内序号
            int serialNO = 0;

            this.alOutPut = new List<Neusoft.HISFC.Models.Material.Output>();

            Neusoft.HISFC.Models.Material.Output output;
            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = this.GetKey(dr);

                output = this.hsOutData[key] as Neusoft.HISFC.Models.Material.Output;

                output.StoreBase.Operation.ExamOper.ID = this.outManager.OperInfo.ID;        //审核人
                output.StoreBase.Operation.ExamOper.OperTime = sysTime;                         //审核日期
                output.StoreBase.Operation.Oper = output.StoreBase.Operation.ExamOper;     //操作信息
                output.StoreBase.PriceCollection.RetailPrice = NConvert.ToDecimal(dr["零售价"].ToString());
                //output.StoreBase.RetailCost = 

                if(this.GetOutputFormDataRow(dr, sysTime, ref output) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("获取出库明细信息失败");
                    return;
                }

                serialNO++;
                output.StoreBase.SerialNO = serialNO;

                #region 获取出库单据号

                if (outListNO == null)
                {
                    outListNO = output.OutListNO;
                }
                if (outListNO == null || outListNO == "")
                {
                    //取新出库单号
                    outListNO = this.storeManager.GetOutListNO(this.outManager.DeptInfo.ID);
                    if (outListNO == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("获取出库单据号发生错误");
                        return;
                    }
                }

                output.OutListNO = outListNO;

                #endregion

                #region 获取库存量

                decimal storeQty = 0;
                if (this.storeManager.GetStoreQty(output.StoreBase.StockDept.ID, output.StoreBase.Item.ID, out storeQty) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("获取库存数量时出错" + storeManager.Err);
                    return;
                }
                output.StoreBase.StoreQty = storeQty;    //出库前库存数量
                output.StoreBase.StoreCost = Math.Round(output.StoreBase.StoreQty / output.StoreBase.Item.PackQty * output.StoreBase.PriceCollection.PurchasePrice, 3);

                #endregion

                #region 根据不同参数设置出库数据状态

                //if (isManagerStore)						//目标(领用)科室管理库存
                //    output.StoreBase.State = "1";       //审核
                //else
                //    output.StoreBase.State = "2";       //核准
                output.StoreBase.State = "2";

                if (this.isSpecialOut)					//特殊出库 直接更新状态为核准 
                {
                    output.StoreBase.SpecialFlag = "1";
                    output.StoreBase.State = "2";
                }

                if (output.StoreBase.State == "2")
                {
                    output.StoreBase.Operation.ApproveOper = output.StoreBase.Operation.Oper;
                }

                output.StoreBase.Returns = 0.0000M;
                #endregion
                if (!this.isSpecialOut)
                {
                    input = new Neusoft.HISFC.Models.Material.Input();

                    if (input.InListNO == "" || input.InListNO == null)
                    {
                        input.InListNO = this.storeManager.GetInListNO(this.outManager.TargetDept.ID);
                    }

                    if (isManagerStore && input.InListNO == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("对目标库存科室插入入库记录时获取入库单号出错");
                        return;
                    }

                    if (this.privJoinClass3 != null)
                    {
                        input.StoreBase.PrivType = this.privJoinClass3.Class3Code;
                        input.StoreBase.SystemType = this.privJoinClass3.Class3MeaningCode;
                    }
                    else
                    {
                        input.StoreBase.PrivType = "01";											     //一般入库对应的用户类型
                        input.StoreBase.SystemType = "11";										 //一般入库
                    }

                    input.StoreBase.State = "2";

                    input.StoreBase.StockDept = this.outManager.TargetDept;
                    input.StoreBase.TargetDept = this.outManager.DeptInfo;

                    input.StoreBase.Operation.ExamOper.ID = this.outManager.OperInfo.ID;
                    input.StoreBase.Operation.ExamOper.OperTime = sysTime;

                    input.StoreBase.Operation.ApplyOper = input.StoreBase.Operation.ExamOper;
                    input.StoreBase.Operation.ApproveOper = input.StoreBase.Operation.ExamOper;

                    decimal matStoreQty = 0;

                    if (this.storeManager.GetStoreQty(input.StoreBase.StockDept.ID, output.StoreBase.Item.ID, out matStoreQty) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("获取" + output.StoreBase.Item.Name + "库存数量时发生错误"));
                        return;
                    }
                    input.StoreBase.StoreQty = matStoreQty;
                }
                else
                {
                    input = null;
                }

                if (this.storeManager.Output(output, input, isManagerStore) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("出库保存发生错误" + this.storeManager.Err);
                    return;
                }
                alOutPut.Add(output);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");

            if (alOutPut.Count > 0)
            {
                if (MessageBox.Show("是否打印?", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {/*
                    Local.GyHis.Material.ucMatOutput ucMat = new Local.GyHis.Material.ucMatOutput();
                    ucMat.Decimals = 2;
                    ucMat.MaxRowNo = 17;

                    ucMat.SetDataForInput(alOutPut, 1, this.itemManager.Operator.ID, "1");
                  * */
                    this.Print();
                }

            }
            this.Clear();

            this.outManager.Init();

            FarPoint.Win.Spread.CellType.NumberCellType noCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            noCellType.DecimalPlaces = 4;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = noCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = noCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = noCellType;
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
            this.outManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(outManager_EndTargetChanged);


            this.outManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(outManager_FpKeyEvent);

            this.outManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);

        }

        #endregion

        #region 事件
        //选择入库单{ACF15225-76EA-4760-A8C4-93D2A2CDFA3A}
        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            //this.outManager.TargetDept = targetDept;

            this.Clear();

            this.AddInData(listCode, state);
        }
        /// <summary>
        /// 添加入库数据
        /// </summary>
        /// <param name="listNO">入库单号</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        protected virtual int AddInData(string listCode, string state)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据单据加载数据 请稍候...");
            Application.DoEvents();

            ArrayList alDetail = this.storeManager.QueryInputDetailByListNO(this.outManager.DeptInfo.ID, listCode, "AAAA", state);
            if (alDetail == null)
            {
                Function.ShowMsg(this.storeManager.Err);

                return -1;
            }

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Material.Input input in alDetail)
            {
                Neusoft.HISFC.Models.Material.Output output = new Neusoft.HISFC.Models.Material.Output();
                input.StoreBase.PrivType = this.outManager.PrivType.ID;             //入库类型
                input.StoreBase.SystemType = this.outManager.PrivType.Memo;         //系统类型
                //{30496509-D9AD-4049-A4AE-439BAFC0A704}
                if (this.ConvertInputToOutput(input, ref output) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    return -1;
                }

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(this.GetKey(output), output);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    return -1;
                }
            }

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).EndInit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetFocusSelect();

            return 1;
        }
        /// <summary>
        /// 将传入的input的数据转换成output输出
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        private int ConvertInputToOutput(Neusoft.HISFC.Models.Material.Input input, ref Neusoft.HISFC.Models.Material.Output output)
        {
            Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();

            item = this.itemManager.GetMetItemByMetID(input.StoreBase.Item.ID);
            if (item == null)
            {
                MessageBox.Show("加载申请时 根据物资编码减少物资项目字典信息失败" + input.StoreBase.Item.ID);
                return -1;
            }

            output.StoreBase.Item = item;
            //by yuyun 出库量=入库量-退库量{ACF15225-76EA-4760-A8C4-93D2A2CDFA3A}
            output.StoreBase.Quantity = input.StoreBase.Quantity - input.StoreBase.Returns;
            //出库价应该是对应库存明细的零售价{30496509-D9AD-4049-A4AE-439BAFC0A704}
            Neusoft.HISFC.Models.Material.StoreDetail storeDetail = storeManager.GetStoreDetail(this.outManager.DeptInfo.ID, item.ID, input.StoreBase.StockNO);
            if (storeDetail.StoreBase.PriceCollection.RetailPrice == 0)
            {
                MessageBox.Show("库存中没有找到对应批次的物资项目。");

                return -1;
            }

            output.StoreBase.PriceCollection.RetailPrice = storeDetail.StoreBase.PriceCollection.RetailPrice;
            //output.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.RetailPrice;
            //-----------------------------
            output.StoreBase.RetailCost = output.StoreBase.PriceCollection.RetailPrice * output.StoreBase.Quantity;
            output.Memo = input.Memo;

            decimal storeQty = 0;
            if (this.storeManager.GetStoreQty(this.outManager.DeptInfo.ID, input.StoreBase.Item.ID, out storeQty) == -1)
            {
                MessageBox.Show("获取" + input.StoreBase.Item.Name + "库存数量时发生错误" + this.itemManager.Err);
                return -1;
            }
            output.StoreBase.StoreQty = storeQty;							 //库存量

            output.StoreBase.PrivType = this.outManager.PrivType.ID;		 //出库类型
            output.StoreBase.SystemType = this.outManager.PrivType.Memo;     //系统类型
            output.StoreBase.StockDept = this.outManager.DeptInfo;			 //当前科室
            //if (this.outManager.TargetDept != null && !string.IsNullOrEmpty(this.outManager.TargetDept.ID))
            //{
            //    output.StoreBase.TargetDept = this.outManager.TargetDept;	//目标科室 
            //}
            //else
            //{
            output.StoreBase.TargetDept = this.outManager.TargetDept;//目标科室 
            //}
            output.StoreBase.PriceCollection.PurchasePrice = item.UnitPrice;
            output.OutCost = output.StoreBase.PriceCollection.PurchasePrice * output.StoreBase.Quantity;
            output.ApplyListCode = "";
            output.ApplySerialNO = 0;

            output.User01 = "2";											//数据来源
            output.User02 = "";										//申请单流水号

            output.User03 = output.StoreBase.Item.ID.ToString() + output.StoreBase.PriceCollection.PurchasePrice.ToString() + input.ID;

            return 1;
        }

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.outManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
            {
                DataRow dr = this.dt.Rows.Find(this.GetFindKey(this.outManager.FpSheetView, this.outManager.FpSheetView.ActiveRowIndex));
                if (dr != null)
                {
                    dr["出库金额"] = NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["零售价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void outManager_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {

        }

        private void outManager_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.outManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.outManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
                    {
                        if (this.outManager.FpSheetView.ActiveRowIndex == this.outManager.FpSheetView.Rows.Count - 1)
                        {
                            this.outManager.SetFocus();
                        }
                        else
                        {
                            this.outManager.FpSheetView.ActiveRowIndex++;
                            this.outManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColOutQty;
                        }
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
            /// 购入价
            /// </summary>
            ColPurchasePrice,
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
            /// 项目编码	
            /// </summary>
            ColItemNO,
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

        #endregion
    }
}
