using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Material.In
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveInPriv : IMatManager
    {
        #region 构造方法

        public ApproveInPriv(Material.In.ucMatIn ucMatInManager)
        {
            this.SetMatManagerProperty(ucMatInManager);
        }

        #endregion

        #region 域变量

        /// <summary>
        /// 入库控件
        /// </summary>
        private ucMatIn ucInManager = null;

        private System.Data.DataTable dt = null;

        /// <summary>
        /// 操作科室属性是否为仓库
        /// </summary>
        private bool isPIDept = true;

        /// <summary>
        /// 是否按大包装方式入库
        /// </summary>
        private bool isUsePackIn = false;

        /// <summary>
        /// 库存管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资字典管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();
        /// <summary>
        /// 参数控制业务类{7019A2A6-ADCA-4984-944B-C4F1A312449A}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 物资列表中显示的列数{7019A2A6-ADCA-4984-944B-C4F1A312449A}
        /// </summary>
        private int visibleColumns = 3;
        /// <summary>
        /// 存储本次数据
        /// </summary>
        private System.Collections.Hashtable hsInData = new Hashtable();

        /// <summary>
        /// 核准时是否允许修改发票号/购入价
        /// </summary>
        private bool isApproveEdit = true;

        /// <summary>
        /// 单据信息 仓库核准存储单据号 二级科室核准存储物品编码+单据号 提示对两张单据是否同时核准
        /// </summary>
        private System.Collections.Hashtable hsListNO = new Hashtable();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucMatListSelect ucListSelect = null;

        /// <summary>
        /// 是否使用大包装方式入库
        /// </summary>
        public bool IsUsePackIn
        {
            get
            {
                return this.isUsePackIn;
            }
            set
            {
                this.isUsePackIn = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置主控件属性
        /// </summary>
        private void SetMatManagerProperty(Material.In.ucMatIn ucMatInManager)
        {
            this.ucInManager = ucMatInManager;
            //通过参数控制物资列表中显示列数 {7019A2A6-ADCA-4984-944B-C4F1A312449A}
            visibleColumns = controlIntegrate.GetControlParam<int>("MT0002", true);
            //设置界面显示{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            this.ucInManager.IsShowInputPanel = false;
            this.ucInManager.IsShowItemSelectpanel = true;
            //设置目标单位选项 设置工具栏按钮状态
            if (this.ucInManager.DeptInfo.Memo == "L")
            {
                this.isPIDept = true;
                this.ucInManager.SetTargetDept(true, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                this.ucInManager.SetToolBarButtonVisible(false, false, false, false, true, true, false);
            }
            else
            {
                this.isPIDept = false;
                this.ucInManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Material, Neusoft.HISFC.Models.Base.EnumDepartmentType.L);
                this.ucInManager.SetToolBarButtonVisible(false, false, true, false, true, true, false);
            }
            //显示选择信息
            if (this.ucInManager.TargetDept.ID != "")
            {
                this.ShowSelectData();
            }
            //设置项目列表宽度{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            this.ucInManager.SetItemListWidth(visibleColumns);

            this.ucInManager.Fp.EditModeReplace = true;
            this.ucInManager.FpSheetView.DataAutoSizeColumns = false;

            this.ucInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);
            this.ucInManager.EndTargetChanged += new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);

            this.ucInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

            //增加“选择”按钮
            System.EventHandler eHan = new EventHandler(this.ChangeCheck);
            this.ucInManager.AddToolBarButton("选择", "对当前数据反向选择", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, 0, true, eHan);
        }

        /// <summary>
        /// 变更选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ChangeCheck(object sender, System.EventArgs args)
        {
            foreach (DataRow dr in this.dt.Rows)
            {
                dr["核准"] = !NConvert.ToBoolean(dr["核准"]);
            }
        }

        /// <summary>
        /// 设置Fp显示
        /// </summary>
        public virtual void SetFormat()
        {
            this.ucInManager.FpSheetView.DefaultStyle.Locked = true;
            this.ucInManager.FpSheetView.DataAutoSizeColumns = false;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Width = 38F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 60F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Width = 70F;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColProduceName].Visible = false;      //生产厂家
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //物品编码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColStockNO].Visible = false;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInBillNO].Visible = false;


            //根据当前科室是否为仓库库设置发票号、购入价的显示
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Visible = this.isPIDept;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Visible = this.isPIDept;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchaseCost].Visible = this.isPIDept;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;

            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = this.isPIDept ? 100F : 250F;

            if (this.isApproveEdit)
            {
                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Locked = false;
                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Locked = false;

                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].BackColor = System.Drawing.Color.SeaShell;
                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
                this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].BackColor = System.Drawing.Color.SeaShell;
            }
            //{99EE1131-D261-4772-A51C-3AB108A2F822}核准入库不允许修改购入价
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Locked = true;
        }

        /// <summary>
        /// 向DataTable内增加入库数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Material.Input input)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal inQty = 0;				//入库数量 (根据参数以包装单位或最小单位显示)
                decimal inPrice = 0;			//入库购入价 根据参数决定包装价格或最小单位价格
                string inUnit = "";			//入库单位 (根据参数以包装单位或最小单位显示)

                if (this.isUsePackIn)			//按包装单位入库
                {
                    inQty = input.PackInQty;	//包装数量入库
                    inPrice = input.StoreBase.Item.PackPrice;							//包装单位价格
                    inUnit = input.StoreBase.Item.PackUnit;								//包装单位
                }
                else
                {
                    inQty = input.StoreBase.Quantity;									//最小数量入库
                    inPrice = input.StoreBase.PriceCollection.PurchasePrice;			//最小单位价格
                    inUnit = input.StoreBase.Item.MinUnit;								//最小单位
                }
                input.StoreBase.RetailCost = input.StoreBase.Quantity * input.StoreBase.PriceCollection.RetailPrice;
                input.StoreBase.PurchaseCost = inQty * inPrice;

                bool isApprove = false;

                if (this.isPIDept)
                    isApprove = false;
                else
                    isApprove = true;

                if (input.InvoiceNO == null)
                {
                    input.InvoiceNO = "";
                }

                this.dt.Rows.Add(new object[] { 
												  isApprove,												//核准
												  input.StoreBase.Item.Name,								//物品名称
												  input.StoreBase.Item.Specs,								//规格
												  input.StoreBase.BatchNO,									//批号
												  input.StoreBase.PriceCollection.RetailPrice,				//零售价                                                
												  input.StoreBase.Item.PackUnit,							//包装单位
												  inQty,//input.StoreBase.Quantity / input.StoreBase.Item.PackQty,  //入库数量
												  inPrice,//input.StoreBase.PriceCollection.PurchasePrice,			//购入价
												  input.StoreBase.PurchaseCost,								//购入金额												  
												  input.StoreBase.PurchaseCost,              //入库金额                                                
												  input.InvoiceNO,											//发票号												  
												  input.StoreBase.Producer.Name,							//生产厂家
												  input.Memo,												//备注
												  input.StoreBase.Item.ID,									//物品编码
												  input.ID,													//流水号
												  input.StoreBase.StockNO,
												  input.StoreBase.Item.SpellCode,							//拼音码
												  input.StoreBase.Item.WBCode,								//五笔码
												  input.StoreBase.Item.UserCode							//自定义码											                          
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
        /// 加载选择数据
        /// </summary>
        private void ShowSelectData()
        {
            string targetNO = this.ucInManager.TargetDept.ID;
            if (targetNO == "" || targetNO == null)
                targetNO = "AAAA";

            if (this.isPIDept)                              //仓库
            {
                string[] filterStr = new string[1] { "INVOICE_NO" };
                string[] label = new string[] { "发票号", "供货单位编码", "供货单位名称", "入库单" };
                int[] width = new int[] { 60, 60, 120, 60 };
                bool[] visible = new bool[] { true, false, true, true };

                this.ucInManager.SetSelectData("3", false, new string[] { "Material.Store.GetInputInvoiceList" }, filterStr, this.ucInManager.DeptInfo.ID, "1", targetNO);

                this.ucInManager.SetSelectFormat(label, width, visible);
            }
            else
            {
                string[] filterStr = new string[3] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" };
                string[] label = new string[] { "出库流水号", "出库单据号", "物品编码", "物品名称", "规格", "数量", "包装单位", "最小单位", "拼音码", "五笔码" };
                int[] width = new int[] { 60, 60, 60, 120, 80, 60, 60, 60, 60, 60 };
                bool[] visible = new bool[] { false, false, false, true, true, true, false, true, false, false };

                this.ucInManager.SetSelectData("3", false, new string[] { "Material.Store.QueryOutputListForApproveInput" }, filterStr, this.ucInManager.DeptInfo.ID, "A", "1", targetNO);

                this.ucInManager.SetSelectFormat(label, width, visible);
            }
        }

        /// <summary>
        /// 目标单位信息填充
        /// </summary>
        /// <param name="targetNO">目标单位编码</param>
        private int FillTargetInfo(string targetNO)
        {
            if (this.isPIDept)          //仓库
            {
                Neusoft.HISFC.BizLogic.Material.ComCompany comManager = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                Neusoft.HISFC.Models.Material.MaterialCompany company = new Neusoft.HISFC.Models.Material.MaterialCompany();

                if (company == null)
                {
                    MessageBox.Show("无法获取该条供货单位信息");
                    return -1;
                }

                this.ucInManager.TargetDept = company;
                this.ucInManager.TargetDept.Memo = "1";
            }
            else
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(targetNO);
                if (dept == null)
                {
                    MessageBox.Show("无法获取该条记录申请科室信息！");
                    return -1;
                }

                this.ucInManager.TargetDept = dept;
                this.ucInManager.TargetDept.Memo = "0";
            }

            return 1;
        }

        /// <summary>
        /// 设置单据号显示
        /// </summary>
        /// <param name="listNO"></param>
        private void AddListNO(string listNO)
        {
            if (this.hsListNO.ContainsKey(listNO))
            {
                return;
            }

            this.hsListNO.Add(listNO, 1);

            if (this.ucInManager.ShowInfo == "显示信息:")
            {
                this.ucInManager.ShowInfo = "入库单据: " + listNO;
            }
            else
            {
                this.ucInManager.ShowInfo = this.ucInManager.ShowInfo + " － " + listNO;
            }
        }

        /// <summary>
        /// 移出单据号
        /// </summary>
        /// <param name="listNO"></param>
        private void RemoveListNO(string listNO)
        {
            if (this.hsListNO.ContainsKey(listNO))
            {
                int iCount = (int)this.hsListNO[listNO];
                if (iCount == 1)
                {
                    this.hsListNO.Remove(listNO);
                    this.ucInManager.ShowInfo = "";
                    foreach (string strListNO in this.hsListNO.Keys)
                    {
                        if (this.ucInManager.ShowInfo == "")
                        {
                            this.ucInManager.ShowInfo = "入库单据: " + strListNO;
                        }
                        else
                        {
                            this.ucInManager.ShowInfo = this.ucInManager.ShowInfo + " － " + strListNO;
                        }
                    }
                }
                else
                {
                    this.hsListNO[listNO] = iCount - 1;
                }
            }
        }

        #region 仓库核准加载函数

        /// <summary>
        /// 根据发票号添加待核准数据
        /// </summary>
        /// <param name="invoiceNO"></param>
        private int AddInDataByInvoiceNO(string invoiceNO)
        {
            //提取待核准入库数据
            ArrayList alDetail = this.storeManager.QueryInputDetailByInvoice(this.ucInManager.DeptInfo.ID, invoiceNO, "1");
            if (alDetail == null)
            {
                MessageBox.Show(this.storeManager.Err);
                return -1;
            }

            //this.ucInManager.ShowInfo = "入库单据号";

            foreach (Neusoft.HISFC.Models.Material.Input input in alDetail)
            {
                //主键设置
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                input.User03 = input.ID + input.StoreBase.StockNO;
               // input.User03 = input.ID;

                //判断是否重复加入
                if (this.hsInData.ContainsKey(this.GetKey(input)))
                {
                    MessageBox.Show("该发票已加入选择!");
                    return 0;
                }

                if (!hsListNO.ContainsKey(input.InListNO))
                {
                    this.AddListNO(input.InListNO);
                }
                //补充目标单位信息
                if (this.ucInManager.TargetDept.ID == "")
                {
                    this.FillTargetInfo(input.StoreBase.TargetDept.ID);
                }

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInData.Add(this.GetKey(input), input);
                }
            }

            this.SetFormat();

            return 1;
        }


        #endregion

        #region 二级科室核准数据加载函数

        /// <summary>
        /// 根据出库流水号获取待核准数据
        /// </summary>
        /// <param name="outNO">出库流水号</param>
        /// <returns></returns>
        private int AddOutDataByOutNO(string outNO)
        {
            #region 暂时凭掉2007-4-3
            /*
			ArrayList alDetail = this.storeManager.QueryOutputList(outNO);
			if (alDetail == null || alDetail.Count <= 0)
			{
				MessageBox.Show("根据出库流水号获取出库数据发生错误");
				return -1;
			}

			foreach (Neusoft.HISFC.Models.Material.Output output in alDetail)
			{
				Neusoft.HISFC.Models.Material.Input input = this.InputConvert(output);

				if (this.hsInData.ContainsKey(this.GetKey(input)))
				{
					MessageBox.Show("该数据已加入选择!");
					return 0;
				}

				//是否已包含该单据
				if (!this.hsListNO.ContainsKey(input.OutListNO))
				{
					if (this.hsListNO.Count > 0)
					{
						string msg = MessageBox.Show(string.Format("该物品入库单据号与当前入库单据号不同 该物品入库单据{0} 确认加入吗?", input.OutListNO));
						DialogResult rs = MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
						if (rs == DialogResult.No)
						{
							return 0;
						}
					}
				}

				if (this.AddDataToTable(input) == 1)
				{
					this.hsInData.Add(this.GetKey(input), input);
					//保存单据号
					if (this.hsListNO.ContainsKey(input.OutNO))
					{
						this.hsListNO[input.OutNO] = ((int)this.hsListNO[input.OutNO]) + 1;
					}
					else
					{                      
						this.AddListNO(input.OutNO);
					}
				}
			}

			this.SetFormat();
			*/
            #endregion
            return 1;
        }

        /// <summary>
        /// 添加待核准的出库数据
        /// </summary>
        /// <param name="outListNO">出库单据号</param>
        private void AddOutDataByListNO(string outListNO)
        {
            List<Neusoft.HISFC.Models.Material.Output> alDetail = this.storeManager.QueryOutputByListNO(this.ucInManager.TargetDept.ID, outListNO, "1", this.ucInManager.DeptInfo.ID);

            if (alDetail == null)
            {
                MessageBox.Show("获取入库待核准数据发生错误" + this.storeManager.Err);
                return;
            }
            if (alDetail.Count == 0)
            {
                MessageBox.Show("该单据可能已被核准");
                return;
            }

            //先设置Fp进行初始化 提高加载速度
            ((System.ComponentModel.ISupportInitialize)(this.ucInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Material.Output output in alDetail)
            {
                //对为零的记录不进行处理{8764C351-D36D-4331-B21B-8E7D4847D260}
                if (output.StoreBase.Quantity - output.StoreBase.Returns <= 0)
                {
                    continue;
                }

                Neusoft.HISFC.Models.Material.Input input = this.InputConvert(output);

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInData.Add(this.GetKey(input), input);
                }
                else
                {
                    MessageBox.Show("加载出库实体信息时发生错误");
                    return;
                }
            }
            //保存当前单据信息
            this.hsListNO.Add(outListNO, alDetail.Count);

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.ucInManager.Fp)).EndInit();

            return;
        }

        /// <summary>
        /// 入库实体赋值
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Material.Input InputConvert(Neusoft.HISFC.Models.Material.Output output)
        {
            Neusoft.HISFC.Models.Material.Input input = new Neusoft.HISFC.Models.Material.Input();

            #region Input 信息填充

            //补充目标单位信息
            //if (this.ucInManager.TargetDept.ID == "")
            //{
            //	this.FillTargetInfo(input.StoreBase.TargetDept.ID);
            //}
            input.StoreBase.Item = this.itemManager.GetMetItemByMetID(output.StoreBase.Item.ID);
            input.StoreBase.StockDept = this.ucInManager.DeptInfo;                  //申请科室
            input.StoreBase.PrivType = this.ucInManager.PrivType.ID;                //入库分类
            input.StoreBase.SystemType = this.ucInManager.PrivType.Memo;            //系统类型
            input.StoreBase.State = "2";                                            //状态 核准
            input.StoreBase.Company = this.ucInManager.TargetDept;
            //目标科室暂时屏掉，实体中无此字段
            //input.TargetDept = this.ucInManager.TargetDept;						//目标单位
            //
            input.ID = output.ID;													//出库流水号
            input.OutNO = output.ID;

            input.PlanListNO = output.OutListNO;									//出库单据号

            input.StoreBase.SerialNO = output.StoreBase.SerialNO;                   //序号
            input.StoreBase.BatchNO = output.StoreBase.BatchNO;                     //批号
            input.StoreBase.ValidTime = output.StoreBase.ValidTime;                 //有效期
            input.StoreBase.Quantity = output.StoreBase.Quantity - output.StoreBase.Returns;  //数量{8764C351-D36D-4331-B21B-8E7D4847D260}
                //output.StoreBase.Quantity;                   //数量
            input.InCost = input.StoreBase.Quantity * output.StoreBase.PriceCollection.PurchasePrice;

            input.StoreBase.PlaceNO = output.StoreBase.PlaceNO;                     //货位号
            input.StoreBase.StockNO = output.StoreBase.StockNO;                     //批次
            input.StoreBase.Operation = output.StoreBase.Operation;                 //操作信息
            input.StoreBase.PriceCollection.PurchasePrice = output.StoreBase.PriceCollection.PurchasePrice;
            input.StoreBase.PriceCollection.RetailPrice = output.StoreBase.PriceCollection.RetailPrice;
            input.StoreBase.RetailCost = output.StoreBase.RetailCost;
            input.StoreBase.PriceCollection.PriceRate = output.StoreBase.PriceCollection.PriceRate;

            #endregion

            //存储主键信息
            //出库审批数据 多批次出库时 同一物品不同批次 流水号相同 单据内序号不同
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            input.User03 = output.ID + output.StoreBase.StockNO;
           //input.User03 = output.ID + output.StoreBase.SerialNO;

            return input;
        }


        #endregion

        /// <summary>
        /// 汇总金额计算
        /// </summary>
        public void CompuateSum()
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

            if (this.isPIDept)
            {
                this.ucInManager.TotCostInfo = string.Format("零售总金额:{0} 购入总金额:{1}", retailCost.ToString("N"), purchaseCost.ToString("N"));
            }
            else
            {
                this.ucInManager.TotCostInfo = string.Format("零售总金额:{0}", retailCost.ToString("N"));
            }
        }

        #region 键值获取

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Material.Input input)
        {
            return input.User03;
        }


        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //return dr["流水号"].ToString();
            return dr["流水号"].ToString() + dr["库存序号"].ToString();
        }


        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns></returns>
        private string[] GetKey()
        {
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //string[] keys = new string[]{
            //                                this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColInBillNO].Text                                              
            //                            };
            string[] keys = new string[]{
											this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColInBillNO].Text,this.ucInManager.FpSheetView.Cells[this.ucInManager.FpSheetView.ActiveRowIndex,(int)ColumnSet.ColStockNO].Text                                              
										};

            return keys;
        }

        #endregion

        #endregion

        #region IMatManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get
            {
                // TODO:  添加 ApproveInPriv.InputModualUC getter 实现
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
												 new DataColumn("核准",      dtBol),
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),
												 new DataColumn("批号",      dtStr),
												 new DataColumn("零售价",    dtDec),
												 new DataColumn("单位",  dtStr),												 
												 new DataColumn("入库数量",  dtDec),
												 new DataColumn("购入价",    dtDec),
												 new DataColumn("购入金额",  dtDec),
												 new DataColumn("入库金额",  dtDec),                                                                    
												 new DataColumn("发票号",    dtStr),												 
												 new DataColumn("生产厂家",  dtStr),
												 new DataColumn("备注",      dtStr),
												 new DataColumn("物品编码",  dtStr),
												 new DataColumn("流水号",	 dtStr),
												 new DataColumn("库存序号",dtStr),
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr)
											 }
                );
            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            DataColumn[] keys = new DataColumn[2];
            keys[0] = this.dt.Columns["流水号"];
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            keys[1] = this.dt.Columns["库存序号"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }


        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string dataNO = sv.Cells[activeRow, 0].Text;

            //********************根据仓库和二级科室的不同，分别处理，此处待修改

            if (this.isPIDept)              //仓库
            {
                if (this.AddInDataByInvoiceNO(dataNO) == 1)
                {
                    this.SetFocusSelect();
                }
                return 1;
            }
            else                            //二级科室
            {
                if (this.AddOutDataByOutNO(dataNO) == 1)
                {
                    this.SetFocusSelect();
                }
                return 1;
            }
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
            // TODO:  添加 ApproveInPriv.ShowApplyList 实现
            return 1;
        }


        public int ShowInList()
        {
            // TODO:  添加 ApproveInPriv.ShowInList 实现
            return 1;
        }


        public int ShowOutList()
        {
            #region 原来的方法暂时凭掉
            /*
			string targetNO = "AAAA";
			if (this.ucInManager.TargetDept.ID != "" && this.ucInManager.TargetDept.ID != null)//仓库
			{
				targetNO = this.ucInManager.TargetDept.ID;
			}

			ArrayList alList = this.storeManager.QueryOutputListForApproveInput(targetNO, this.ucInManager.DeptInfo.ID, "A");
			if (alList == null)
			{
				MessageBox.Show("获取出库单据数据出错" + this.storeManager.Err);
				return -1;
			}

			//弹出窗口选择单据
			Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
			string[] fpLabel = { "入库单号", "供货单位" };
			float[] fpWidth = { 120F, 120F };
			bool[] fpVisible = { true, true, false, false, false, false };

			if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, ref selectObj) == 1)
			{
				this.Clear();

				Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

				targeDept.ID = selectObj.Memo;              //出库科室编码
				targeDept.Name = selectObj.Name;            //出库科室名称
				targeDept.Memo = "0";                       //目标单位性质 内部科室

				if (this.ucInManager.TargetDept.ID != targeDept.ID)
				{
					this.ucInManager.TargetDept = targeDept;
					this.ShowSelectData();
				}

//				this.AddOutDataByListNO(selectObj.ID);

				this.SetFocusSelect();

				if (this.ucInManager.FpSheetView != null)
				{
					this.ucInManager.FpSheetView.ActiveRowIndex = 0;
				}
			}
			*/
            #endregion

            #region 新方法
            try
            {
                if (this.ucListSelect == null)
                    this.ucListSelect = new ucMatListSelect();

                this.ucListSelect.Init();
                this.ucListSelect.DeptInfo = this.ucInManager.TargetDept;
                //{23CC782D-27F9-42ca-B8C2-2A4F079CECBF}核准入库时，看到的出库单应该是目标科室为操作权限科室的
                this.ucListSelect.DeptCode = this.ucInManager.DeptInfo.ID;
                this.ucListSelect.State = "2";                  //需检索状态
                this.ucListSelect.Class2Priv = "0520";          //出库

                //this.ucListSelect.SelecctListEvent -= new ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);
                this.ucListSelect.SelecctListEvent -= new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);
                this.ucListSelect.SelecctListEvent += new Neusoft.HISFC.Components.Common.Controls.ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucListSelect);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }
            #endregion
            return 1;
        }


        public int ShowStockList()
        {
            // TODO:  添加 ApproveInPriv.ShowStockList 实现
            return 1;
        }


        public bool Valid()
        {
            // TODO:  添加 ApproveInPriv.Valid 实现
            return true;
        }


        public int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            try
            {
                if (sv != null && delRowIndex >= 0)
                {
                    string[] keys = this.GetKey();

                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        this.ucInManager.Fp.StopCellEditing();

                        //移出单据号
                        Neusoft.HISFC.Models.Material.Input tempInput = this.hsInData[this.GetKey(dr)] as Neusoft.HISFC.Models.Material.Input;
                        this.RemoveListNO(tempInput.InListNO);
                        //由入库实体集合内移出
                        this.hsInData.Remove(this.GetKey(dr));
                        this.dt.Rows.Remove(dr);

                        this.ucInManager.Fp.StartCellEditing(null, false);
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

                this.hsInData.Clear();

                this.hsListNO.Clear();
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
            if (this.ucInManager.FpSheetView != null)
            {
                if (this.ucInManager.FpSheetView.Rows.Count > 0)
                {
                    this.ucInManager.SetFpFocus();

                    this.ucInManager.FpSheetView.ActiveRowIndex = this.ucInManager.FpSheetView.Rows.Count - 1;
                    if (this.isPIDept)              //仓库
                    {
                        this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                    }
                    else
                    {
                        this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColIsApprove;
                    }
                }
                else
                {
                    this.ucInManager.SetFocus();
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
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numberCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numberCellType;

            #region 判断是否选择了核准数据

            bool isHaveCheck = false;
            bool isHaveUnCheck = false;
            foreach (DataRow dr in this.dt.Rows)
            {
                if (NConvert.ToBoolean(dr["核准"]))
                    isHaveCheck = true;
                else
                    isHaveUnCheck = true;
            }

            if (!isHaveCheck)
            {
                MessageBox.Show("请选择需核准数据");
                return;
            }
            if (isHaveUnCheck)
            {
                DialogResult rs = MessageBox.Show("存在未选择数据 确认对这些物品不进行核准吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return;
            }

            #endregion

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.HISFC.BizLogic.Material.Store store = new Neusoft.HISFC.BizLogic.Material.Store();
            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //store.SetTrans(t.Trans);

            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            int serialNO = 0;
            string inListNO = "";

            foreach (DataRow dr in this.dt.Rows)
            {
                if (!NConvert.ToBoolean(dr["核准"]))
                    continue;

                string key = this.GetKey(dr);

                Neusoft.HISFC.Models.Material.Input input = this.hsInData[key] as Neusoft.HISFC.Models.Material.Input;

                input.StoreBase.Operation.ApproveOper.OperTime = sysTime;                 //核准日期
                input.StoreBase.Operation.ApproveOper.ID = this.ucInManager.OperInfo.ID;  //核准人
                input.StoreBase.Operation.Oper = input.StoreBase.Operation.ApproveOper;
                input.StoreBase.PriceCollection.PurchasePrice = NConvert.ToDecimal(dr["购入价"].ToString());
                //{23D6A9A2-F151-4deb-8A07-9F0480B48D90}
                //input.StoreBase.PriceCollection.RetailPrice = input.StoreBase.PriceCollection.PurchasePrice;
                input.StoreBase.PriceCollection.RetailPrice = NConvert.ToDecimal(dr["零售价"].ToString());
                input.InvoiceNO = dr["发票号"].ToString();
                input.ID = dr["流水号"].ToString();
                input.StoreBase.StockNO = dr["库存序号"].ToString();
                input.StoreBase.Item.PackPrice = input.StoreBase.PriceCollection.PurchasePrice * input.StoreBase.Item.PackQty;
                //input.OutNO = "";
                //input.PlanListNO = "";

                input.StoreBase.StockDept.Memo = this.ucInManager.DeptInfo.Memo;         //保存科室类别 PI仓库 P二级科室

                //更新标记,此处可能需要修改
                if (this.isPIDept)
                {
                    if (this.storeManager.ApproveInputUpdate(input) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存 " + dr["物品名称"].ToString() + " 时发生错误");
                        return;
                    }
                }
                else
                {
                    input.StoreBase.State = "2";
                    serialNO++;											//单内顺序号
                    input.StoreBase.SerialNO = serialNO;

                    #region 如果不存在入库单据号 则获取新入库单据号

                    //入库单号
                    if (inListNO == null)
                    {
                        inListNO = input.InListNO;
                    }

                    if (inListNO == "" || inListNO == null)
                    {
                        inListNO = this.storeManager.GetInListNO(this.ucInManager.DeptInfo.ID);
                        if (inListNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("获取最新入库单号出错" + this.storeManager.Err);
                            return;
                        }
                    }

                    input.InListNO = inListNO;
                    input.StoreBase.Operation.Oper.Dept.ID = this.ucInManager.DeptInfo.ID;

                    #endregion

                    if (this.storeManager.ApproveInputDept(input, true) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存 " + dr["物品名称"].ToString() + " 时发生错误");
                        return;
                    }
                }

            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功");

            this.Clear();

            this.ShowSelectData();

            FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numCellType.DecimalPlaces = 4;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].CellType = numCellType;
            this.ucInManager.FpSheetView.Columns[(int)ColumnSet.ColInCost].CellType = numCellType;
        }


        public void SaveCheck(bool IsHeaderCheck)
        {

        }

        public int Print()
        {
            // TODO:  添加 ApproveInPriv.Print 实现
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
            this.ucInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.ucInManager.EndTargetChanged -= new In.ucMatIn.DataChangedHandler(value_EndTargetChanged);

            this.ucInManager.Fp.EditModeOff -= new EventHandler(Fp_EditModeOff);
        }

        #endregion

        #region 属性

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
            {
                string[] keys = this.GetKey();

                DataRow dr = this.dt.Rows.Find(keys);
                if (dr != null)
                {
                    dr["购入金额"] = NConvert.ToDecimal(dr["入库数量"]) * NConvert.ToDecimal(dr["购入价"]);

                    dr.EndEdit();

                    this.CompuateSum();
                }
            }
        }

        private void value_FpKeyEvent(System.Windows.Forms.Keys key)
        {
            if (this.ucInManager.FpSheetView != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.ucInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColInvoiceNO)
                    {
                        if (this.ucInManager.FpSheetView.ActiveRowIndex == this.ucInManager.FpSheetView.Rows.Count - 1)
                        {
                            this.ucInManager.SetFocus();
                        }
                        else
                        {
                            this.ucInManager.FpSheetView.ActiveRowIndex++;
                            this.ucInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                        }
                        return;
                    }
                }
            }
        }

        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.ShowSelectData();
        }

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            //			this.ucInManager.TargetDept = targetDept;

            this.Clear();

            this.AddOutDataByListNO(listCode);
        }

        #endregion

        #region 列枚举

        private enum ColumnSet
        {
            /// <summary>
            /// 核准        0
            /// </summary>
            ColIsApprove,
            /// <summary>
            /// 物品名称	0
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格		1
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 批号		3
            /// </summary>
            ColBatchNO,
            /// <summary>
            /// 零售价		2
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 包装单位	4
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 入库数量	5
            /// </summary>
            ColInNum,
            /// <summary>
            /// 购入价		9
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 购入金额    10
            /// </summary>
            ColPurchaseCost,
            /// <summary>
            /// 入库金额	6
            /// </summary>
            ColInCost,
            /// <summary>
            /// 发票号		7
            /// </summary>
            ColInvoiceNO,
            /// <summary>
            /// 生产厂家	11
            /// </summary>
            ColProduceName,
            /// <summary>
            /// 备注	    14
            /// </summary>
            ColMemo,
            /// <summary>
            /// 物品编码    15 
            /// </summary>
            ColDrugNO,
            /// <summary>
            /// 流水号
            /// </summary>
            ColInBillNO,
            /// <summary>
            /// 库存序号
            /// </summary>
            ColStockNO,
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
