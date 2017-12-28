using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.Out
{
    /// <summary>
    /// [功能描述: 物资审批出库]
    /// [创 建 者: 喻赟]
    /// [创建时间: 2008-7-30]
    /// <说明>
    ///     1、关于是否管理库存 当前由程序内进行赋值
    /// </说明>
    /// </summary>
    class ExamOutPriv : Neusoft.HISFC.Components.Material.IMatManager
    {
        /// <summary>
        /// 实例构造
        /// </summary>
        /// <param name="isSpecialOut">是否特殊出库</param>
        /// <param name="ucMatOutManager">出库组件</param>
        public ExamOutPriv(Neusoft.HISFC.Components.Material.Out.ucMatOut ucMatOutManager)
        {
            this.SetMatManagerProperty(ucMatOutManager);
        }

        private event System.EventHandler OnExpand;

        #region 域变量

        /// <summary>
        /// 出库组件
        /// </summary>
        private Neusoft.HISFC.Components.Material.Out.ucMatOut outManager = null;

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

        private Neusoft.HISFC.BizLogic.Manager.Department myDept = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.BizLogic.Manager.Person myPerson = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 数量出库时是否使用最小单位
        /// </summary>
        private bool isUseMinUnit = true;

        public string showInfo = "";

        #endregion

        #region 属性

        #endregion

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetMatManagerProperty(Neusoft.HISFC.Components.Material.Out.ucMatOut ucOutManager)
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
                //设置工具栏按钮显示
                this.OnExpand += new EventHandler(ExamOutPriv_OnExpand);
                //this.outManager.SetToolButton(true, false, false, true, false);
                this.outManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //{8402BFFB-C9CD-4418-BE02-0B3F45850CD3}
                //设置显示的待选择数据//{8402BFFB-C9CD-4418-BE02-0B3F45850CD3}审批出库只能按申请单出库
                //this.outManager.SetSelectData("2", false, null, null, null);
                this.outManager.SetSelectData("4", false, null, null, null);
                //设置项目列表宽度
                this.outManager.SetItemListWidth(4);
                //提示信息设置
                this.outManager.ShowInfo = "请您根据申请单做出库审批";

                this.outManager.Fp.EditModePermanent = false;
                this.outManager.Fp.EditModeReplace = true;
                this.outManager.FpSheetView.DataAutoSizeColumns = false;

                this.outManager.Fp.EditModeReplace = true;

                this.outManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(outManager_EndTargetChanged);
                this.outManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(outManager_EndTargetChanged);

                this.outManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(outManager_FpKeyEvent);
                this.outManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(outManager_FpKeyEvent);

                this.outManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
                this.outManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);
                this.outManager.FpSheetView.DataAutoCellTypes = false;

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
													  true,
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
													  output.User03,										//主键                        
                                                      output.StoreBase.TargetDept.ID                      //目标科室
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

            output.StoreBase.Operation.Oper.ID = this.outManager.OperInfo.ID;
            output.StoreBase.Operation.Oper.OperTime = sysTime;

            output.StoreBase.Operation.ExamOper = output.StoreBase.Operation.Oper;		//审批人
            output.StoreBase.Operation.ExamQty = output.StoreBase.Quantity;

            output.Memo = dr["备注"].ToString();										//备注
            if (this.outManager.TargetPerson != null)									//领药人
            {
                output.GetPerson = this.outManager.TargetPerson;
            }

            output.StoreBase.PrivType = this.outManager.PrivType.ID;               //出库类型
            output.StoreBase.SystemType = this.outManager.PrivType.Memo;           //系统类型
            output.StoreBase.StockDept = this.outManager.DeptInfo;                 //当前科室
            output.StoreBase.TargetDept = myDept.GetDeptmentById(dr["目标科室"].ToString());
            //this.outManager.TargetDept;              //目标科室

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
        protected virtual int AddApplyData(string listCode, string deptCode, string state)
        {
            //this.Clear();

            ArrayList alDetail = new ArrayList();

            alDetail = this.storeManager.QueryApplyDetailByListNO(deptCode, listCode, state);

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
                    MessageBox.Show("加载申请时 根据物资编码减少物资项目字典信息失败" + apply.Item.ID);
                    return -1;
                }

                output.StoreBase.Item = item;
                output.StoreBase.Quantity = apply.Operation.ApplyQty - apply.OutQty; //by yuyun 改为申请量 - 已审批量 


                //liuxq改为审批量      //apply.Operation.ApplyQty;			 //申请量
                output.StoreBase.PriceCollection.RetailPrice = apply.ApplyPrice;    //wangw
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
                //if (this.outManager.TargetDept != null && !string.IsNullOrEmpty(this.outManager.TargetDept.ID))
                //{
                //    output.StoreBase.TargetDept = this.outManager.TargetDept;	//目标科室 
                //}
                //else
                //{
                output.StoreBase.TargetDept = myDept.GetDeptmentById(apply.StockDept.ID);//目标科室 
                //}
                output.StoreBase.PriceCollection.PurchasePrice = item.UnitPrice;
                output.ApplyListCode = apply.ApplyListNO;//申请单号liuxq add
                output.ApplySerialNO = apply.SerialNO;//申请单内序号liuxq add
                //将申请数量存入扩展字段 来处理部分审批出库 by yuyun 08-7-30
                output.StoreBase.Extend = output.StoreBase.Quantity.ToString();
                output.User01 = "1";											//数据来源 申请
                output.User02 = apply.ID;										//申请单流水号

                output.User03 = output.StoreBase.Item.ID.ToString() + output.StoreBase.PriceCollection.PurchasePrice.ToString() + apply.ApplyListNO;									//设置主键

                if (this.AddDataToTable(output) == 1)
                {
                    this.hsOutData.Add(output.User03, output);

                    this.hsApplyData.Add(apply.ID, apply);

                    this.hsItemData.Add(output.User03, null);			//设置已添加项目
                }
                if (apply == alDetail[0])
                {
                    Neusoft.HISFC.Models.Base.Employee person = myPerson.GetPersonByID(apply.Operation.ApproveOper.ID);

                    Neusoft.HISFC.Models.Base.Department dept = myDept.GetDeptmentById(apply.StockDept.ID);

                    if (person != null && dept != null)
                    {
                        this.showInfo = "申请单:" + apply.ApplyListNO + " 申请科室:" + dept.Name + " 科室审批:" + person.Name;
                    }
                }
            }

            ((System.ComponentModel.ISupportInitialize)(this.outManager.Fp)).EndInit();

            //计算汇总出库金额
            this.CompuateSum();

            return 1;
        }


        /// <summary>
        /// 根据物品信息添加出库记录
        /// </summary>
        /// <param name="itemNO">物资项目编码</param>
        /// <param name="storageQty">库存数量</param>
        /// <returns></returns>
        protected virtual int AddDrugData(string itemNO, decimal storageQty, decimal price)
        {
            if (this.outManager.TargetDept.ID == "" || this.outManager.TargetDept.ID == "A")
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
            output.StoreBase.PriceCollection.PurchasePrice = price;
            output.StoreBase.PriceCollection.RetailPrice = price;

            output.User01 = "0";														//数据来源
            output.User03 = output.StoreBase.Item.ID.ToString() + output.StoreBase.PriceCollection.RetailPrice.ToString();												//设置主键

            if (this.AddDataToTable(output) == 1)
            {
                this.hsOutData.Add(output.User03, output);

                this.hsItemData.Add(output.User03, null);						//存储已添加的项目 防止重复添加
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
                    retailCost += NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["购入价"]);
                }
                this.outManager.TotCostInfo = string.Format("出库金额:{0}", retailCost.ToString("N"));
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


        #region IMatManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                return null;
            }
        }

        void ExamOutPriv_OnExpand(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
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
												 new DataColumn("主键",		 dtStr),
                                                 new DataColumn("目标科室",  dtStr)
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
            //-----by yuyun 08-7-25 第一列变成自定义码  原自定义码列成物资编码
            //string itemNO = sv.Cells[activeRow, 0].Text;
            string itemNO = sv.Cells[activeRow, 11].Text;

            decimal storeQty = NConvert.ToDecimal(sv.Cells[activeRow, 4].Text);
            Decimal price = NConvert.ToDecimal(sv.Cells[activeRow, 3].Text);

            if (this.AddDrugData(itemNO, storeQty, price) == 1)
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
            this.Clear();
            ArrayList alTemp = new ArrayList();
            //如果下拉列表中选择空值，则默认查找所有申请记录 by yuyun 08-7-28
            if (string.IsNullOrEmpty(this.outManager.TargetDept.ID))
            {
                this.outManager.TargetDept.ID = "A";
            }
            //------------
            //需要判断申请单的目标科室是当前登陆科室 by yuyun 08-7-28 
            string currentDeptID = string.Empty;
            currentDeptID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            //--------------------------------------------------------targetdept-----------currentdept----priv-----extend1-----inclass-
            //extend1："0"申请状态 "1"入库计划 "9" 部分审批 "3" 全部审批
            alTemp = this.storeManager.QueryApplyListByDept(this.outManager.TargetDept.ID, this.outManager.DeptInfo.ID, "0510", "0','1','9", "13");
            //------------
            if (alTemp == null)
            {
                System.Windows.Forms.MessageBox.Show("获取申请信息失败" + this.storeManager.Err);
                return -1;
            }
            //重新写了申请单选择的控件 by yuyun 08-7-28 
            Neusoft.HISFC.Components.Material.Base.ucApplyLists ucLists = new Neusoft.HISFC.Components.Material.Base.ucApplyLists();

            ArrayList selectApply = new ArrayList();

            ucLists.Init(alTemp);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(ucLists);

            if (ucLists.ListApply.Count > 0)
            {
                this.Clear();

                foreach (ArrayList ar in ucLists.ListApply)
                {
                    this.AddApplyData(ar[1].ToString(), ar[3].ToString(), "0");
                }

                this.SetFocusSelect();

                if (this.outManager.FpSheetView != null)
                {
                    this.outManager.FpSheetView.ActiveRowIndex = 0;
                }
            }
            //---------
            //if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alTemp, ref selectObject) == 1)
            //{
            //    this.Clear();

            //    Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

            //    this.AddApplyData(selectObject.ID, "0");
            //    this.SetFocusSelect();

            //    if (this.outManager.FpSheetView != null)
            //        this.outManager.FpSheetView.ActiveRowIndex = 0;
            //}

            return 1;
        }


        public int ShowInList()
        {
            // TODO:  添加 CommonOutPriv.ShowInList 实现
            return 0;
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
                    {
                        return 0;
                    }
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
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;

            if (this.isUseMinUnit)
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Visible = false;
            else
                this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMinUnit].Visible = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Visible = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].Locked = false;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].Locked = false;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutQty].BackColor = System.Drawing.Color.SeaShell;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].BackColor = System.Drawing.Color.SeaShell;

            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = 150F;

            FarPoint.Win.Spread.CellType.CheckBoxCellType ckBoxCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColIsExam].CellType = ckBoxCellType;
        }


        public int Clear()
        {
            this.hsItemData.Clear();

            this.hsOutData.Clear();

            this.hsApplyData.Clear();

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
            //如果出库数量大于库存数量时 字体颜色变红 否则字体变黑
            foreach (FarPoint.Win.Spread.Row r in this.outManager.FpSheetView.Rows)
            {
                this.SetFpForeColor(r.Index);
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
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
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存操作..请稍候");
            System.Windows.Forms.Application.DoEvents();

            #region 事务定义
            //常熟维护
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.HISFC.BizLogic.Material.Baseset matConstant = new Neusoft.HISFC.BizLogic.Material.Baseset();
            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //matConstant.SetTrans(t.Trans);

            #endregion

            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            #region 判断领用科室是否关联库存

            bool isManagerStore = false;
            Neusoft.HISFC.Models.Material.MaterialStorage matStorage = matConstant.QueryStorageInfo(this.outManager.TargetDept.ID);
            if (matStorage != null && matStorage.IsStoreManage)
            {
                isManagerStore = true;
            }

            isManagerStore = true;

            if (!isManagerStore)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(this.outManager.TargetDept.Name + " 不管理库存，不能通过出库审批进行出库");
                return;
            }

            #endregion

            //出库单据号
            string outListNO = null;
            int serialNO = 0;
            Neusoft.HISFC.Models.Material.Output output;
            List<Neusoft.HISFC.Models.Material.Output> alOutput = new List<Neusoft.HISFC.Models.Material.Output>();
            foreach (DataRow dr in dtAddMofity.Rows)
            {
                string key = this.GetKey(dr);

                output = this.hsOutData[key] as Neusoft.HISFC.Models.Material.Output;

                if (this.GetOutputFormDataRow(dr, sysTime, ref output) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("获取出库明细信息失败");
                    return;
                }
                //判断是否选中该行
                if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(dr["审批"]))
                {
                    continue;
                }
                //判断出库数量是否为0
                if (output.StoreBase.Quantity == 0)
                {
                    continue;
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
                    outListNO = this.storeManager.GetOutListNO(this.outManager.DeptInfo.ID);
                    if (outListNO == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("获取出库单据号发生错误");
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
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("获取库存数量时出错" + storeManager.Err);
                    return;
                }
                output.StoreBase.StoreQty = storeQty;               //出库前库存数量
                output.StoreBase.StoreCost = Math.Round(output.StoreBase.StoreQty / output.StoreBase.Item.PackQty * output.StoreBase.PriceCollection.PurchasePrice, 3);

                #endregion

                #region 根据不同参数设置出库数据状态

                if (isManagerStore)             //目标(领用)科室管理库存
                    output.StoreBase.State = "1";         //审核
                else
                    output.StoreBase.State = "2";         //核准

                if (output.StoreBase.State == "2")
                {
                    output.StoreBase.Operation.ApproveOper = output.StoreBase.Operation.Oper;
                }

                #endregion
                if (this.storeManager.Output(output) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("出库保存发生错误" + this.storeManager.Err);
                    return;
                }
                if (output.StoreBase.PrivType == "04")
                {
                    //判断出库数量和申请数量 如果出库数量小于申请数量 则为部分审批  by yuyun 08-7-31
                    if (output.StoreBase.Quantity >= Neusoft.FrameWork.Function.NConvert.ToDecimal(output.StoreBase.Extend))
                    {
                        //全部审批
                        //将state更新成P  extend1更新成3  approve_num更新成approve_num+出库数量
                        if (this.storeManager.UpdateApplyState(output.StoreBase.TargetDept.ID, output.ApplyListCode, output.ApplySerialNO, "P", output.StoreBase.Operation.Oper.ID, output.StoreBase.Operation.Oper.OperTime, output.StoreBase.Quantity, "3", output.StoreBase.Memo) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("出库更新发生错误 " + this.storeManager.Err);
                            return;
                        }
                    }
                    else
                    {
                        //部分审批
                        //将state更新成0  extend1更新成9  approve_num更新成approve_num+出库数量
                        if (this.storeManager.UpdateApplyState(output.StoreBase.TargetDept.ID, output.ApplyListCode, output.ApplySerialNO, "0", output.StoreBase.Operation.Oper.ID, output.StoreBase.Operation.Oper.OperTime, output.StoreBase.Quantity, "9", output.StoreBase.Memo) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("出库更新发生错误 " + this.storeManager.Err);
                            return;
                        }
                    }
                }

                alOutput.Add(output);

            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功");
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            if (alOutput.Count > 0)
            {
                if (MessageBox.Show("是否打印?", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Print(alOutput);
                }
                /*
                if (MessageBox.Show("是否打印?", "提示:", System.Windows.Forms.MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    Local.GyHis.Material.ucMatOutput ucMat = new Local.GyHis.Material.ucMatOutput();
                    ucMat.Decimals = 2;
                    ucMat.MaxRowNo = 17;

                    ucMat.SetDataForInput(alOutput, 1, this.itemManager.Operator.ID, "1");
                }
              * */

            }

            this.Clear();
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColOutCost].CellType = numberCellType;
            this.outManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = numberCellType;
        }
        /// <summary>
        /// 打印出库单
        /// </summary>
        /// <param name="alOutput"></param>
        private void Print(List<Neusoft.HISFC.Models.Material.Output> alOutput)
        {
            if (this.outManager.IOutPrint != null)
            {
                this.outManager.IOutPrint.SetData(alOutput);
            }
        }


        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        public int Print()
        {

            return 0;
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

        private void SetFpForeColor(int rowIndex)
        {
            //如果出库数量大于库存数量时 字体颜色变红 否则字体变黑
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.outManager.FpSheetView.Cells[rowIndex, (int)ColumnSet.ColOutQty].Text) >
                    Neusoft.FrameWork.Function.NConvert.ToDecimal(this.outManager.FpSheetView.Cells[rowIndex, (int)ColumnSet.ColStoreQty].Text))
            {
                this.outManager.FpSheetView.Rows[rowIndex].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.outManager.FpSheetView.Rows[rowIndex].ForeColor = System.Drawing.Color.Black;
            }
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

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.outManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColOutQty)
            {
                DataRow dr = this.dt.Rows.Find(this.GetFindKey(this.outManager.FpSheetView, this.outManager.FpSheetView.ActiveRowIndex));
                if (dr != null)
                {
                    dr["出库金额"] = NConvert.ToDecimal(dr["出库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
            this.SetFpForeColor(this.outManager.FpSheetView.ActiveRowIndex);
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


        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            //<summary>
            //审批
            //</summary>
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
    }
}
