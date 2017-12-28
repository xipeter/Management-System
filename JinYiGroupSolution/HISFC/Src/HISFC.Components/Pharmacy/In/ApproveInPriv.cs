using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Data;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /*
     * 药库核准时不需要显示出库单列表 应显示入库单列表 通过入库单核准 
     * 药房核准时显示出库单列表 
     * 
     * 向DataTable内添加数据时核准默认False 
     * 
     * DataTable内主键存储入库流水号(药库核准)或出库流水号(药房核准)
     * Input.User03 存储流水号
     * 
     * 显示出库单列表时 对于用户选择添加两张出库单上的数据应提示.. 目前通过hsListNO处理
     * 
    **/
    /// <summary>
    /// [功能描述: 核准入库业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public class ApproveInPriv : IPhaInManager
    {
        public ApproveInPriv(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        private Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn phaInManager;

        private System.Data.DataTable dt = null;

        /// <summary>
        /// 操作科室属性是否为药库
        /// </summary>
        private bool isPIDept = true;

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 存储本次数据
        /// </summary>
        private System.Collections.Hashtable hsInData = new Hashtable();

        /// <summary>
        /// 核准时是否允许修改发票号/购入价
        /// </summary>
        private bool isApproveEdit = true;

        /// <summary>
        /// 单据信息 药库核准存储单据号 药房核准存储药品编码+单据号 提示对两张单据是否同时核准
        /// </summary>
        private System.Collections.Hashtable hsListNO = new Hashtable();

        /// <summary>
        /// 单据选择控件
        /// </summary>
        private ucPhaListSelect ucListSelect = null;

        #endregion

        /// <summary>
        /// 设置主控件属性
        /// </summary>
        private void SetPhaManagerProperty(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {       
            this.phaInManager = ucPhaManager;

            //设置界面显示
            this.phaInManager.IsShowInputPanel = false;
            this.phaInManager.IsShowItemSelectpanel = true;
            //设置目标单位选项 设置工具栏按钮状态
            if (this.phaInManager.DeptInfo.Memo == "PI")
            {
                this.isPIDept = true;
                this.phaInManager.SetTargetDept(true, false, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

                this.phaInManager.SetToolBarButton(false, false, false, false, true);

                this.phaInManager.SetToolBarButtonVisible(false, false, false, false, true, true, false);
            }
            else
            {
                this.isPIDept = false;
                this.phaInManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

                this.phaInManager.SetToolBarButton(false, false, true, false, true);

                this.phaInManager.SetToolBarButtonVisible(false, false, true, false, true,true,false);
            }
            //显示选择信息
            if (this.phaInManager.TargetDept.ID != "")
            {
                this.ShowSelectData();
            }
            this.phaInManager.ShowInfo = "入库单:";
            //设置项目列表宽度
            this.phaInManager.SetItemListWidth(2);

            this.phaInManager.Fp.EditModeReplace = true;
            this.phaInManager.FpSheetView.DataAutoSizeColumns = false;
           
            this.phaInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);
            this.phaInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

            this.phaInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);
            this.phaInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

            this.phaInManager.Fp.EditModeOff += new EventHandler(Fp_EditModeOff);

            System.EventHandler eFun = new EventHandler(this.ChangeCheck);
            this.phaInManager.AddToolBarButton("选择", "对未选中数据进行反向选择", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, 0, true, eFun);            
        }

        /// <summary>
        /// 变更选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ChangeCheck(object sender, System.EventArgs args)
        {
            this.phaInManager.Fp.StopCellEditing();//{B98F0F85-A2D6-420d-9668-06D7AE79E092}
            foreach (DataRow dr in this.dt.Rows)
            {
                dr.EndEdit();
                dr["核准"] = !NConvert.ToBoolean(dr["核准"]);
                dr.EndEdit();               
            }
        }

        /// <summary>
        /// 设置Fp显示
        /// </summary>
        private void SetFormat()
        {
            this.phaInManager.FpSheetView.DefaultStyle.Locked = true;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Width = 38F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColSpecs].Width = 70F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].Width = 60F;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;            
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Width = 70F;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColBatchNO].Visible = true;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceType].Visible = false;      //发票分类
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColProduceName].Visible = false;      //生产厂家
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColDrugNO].Visible = false;           //药品编码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColKey].Visible = false;               //主键
            
            //根据当前科室是否为药库设置发票号、购入价的显示
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Visible = this.isPIDept;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Visible = this.isPIDept;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchaseCost].Visible = this.isPIDept;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Locked = false;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColMemo].Width = this.isPIDept?100F:250F;

            if (this.isApproveEdit)
            {
                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].Locked = false;
                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].Locked = false;
                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].Locked = false;

                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColIsApprove].BackColor = System.Drawing.Color.SeaShell;
                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColInvoiceNO].BackColor = System.Drawing.Color.SeaShell;
                this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColPurchasePrice].BackColor = System.Drawing.Color.SeaShell;
            }
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyNum].Visible = true;

        }

        /// <summary>
        /// 向DataTable内增加入库数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                input.RetailCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;
                input.PurchaseCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice;

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
                                                isApprove,                                  //核准
                                                input.Item.Name,                            //商品名称
                                                input.Item.Specs,                           //规格
                                                input.BatchNO,                              //批号
                                                input.Item.PriceCollection.RetailPrice,     //零售价                                                
                                                input.Item.PackUnit,                        //包装单位
                                                input.Quantity / input.Item.PackQty,        //入库数量
                                                input.RetailCost,                           //入库金额                                                
                                                input.InvoiceNO,                            //发票号
                                                input.InvoiceType,                          //发票类别
                                                input.Item.PriceCollection.PurchasePrice,   //购入价
                                                input.PurchaseCost,                         //购入金额
                                                input.Item.Product.Producer.Name,           //生产厂家
                                                input.Operation.ApplyQty/input.Item.PackQty ,//申请数量
                                                input.Memo,                                 //备注
                                                input.Item.ID,                              //药品编码                    //申请数量
                                                input.Item.NameCollection.SpellCode,        //拼音码
                                                input.Item.NameCollection.WBCode,           //五笔码
                                                input.Item.NameCollection.UserCode,         //自定义码
                                                input.User03                            
                                           }
                                );
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
        /// 加载选择数据
        /// </summary>
        private void ShowSelectData()
        {
            string targetNO = this.phaInManager.TargetDept.ID;
            if (targetNO == "" || targetNO == null)
                targetNO = "AAAA";

            if (this.isPIDept)                              //药库
            {
                string[] filterStr = new string[1] { "INVOICE_NO" };
                string[] label = new string[] { "发票号", "供货单位编码", "供货单位名称" };
                int[] width = new int[] { 60, 60, 120 };
                bool[] visible = new bool[] { true, false, true };

                this.phaInManager.SetSelectData("3",false,new string[] { "Pharmacy.Item.GetInputInvoiceList" }, filterStr, this.phaInManager.DeptInfo.ID, "1", targetNO);

                this.phaInManager.SetSelectFormat(label, width, visible);
            }
            else
            {

                string[] filterStr = new string[3] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" };
                string[] label = new string[] { "出库流水号", "出库单据号", "药品编码", "商品名称", "规格", "数量", "包装单位", "最小单位", "拼音码", "五笔码" };
                int[] width = new int[] { 60, 60, 60, 120, 80, 60, 60, 60, 60, 60 };
                bool[] visible = new bool[] { false, false, false, true, true, true, false, true, false, false };

                this.phaInManager.SetSelectData("3", false,new string[] { "Pharmacy.Item.GetOutputInfoForInput" }, filterStr, this.phaInManager.DeptInfo.ID, "A", "1", targetNO);

                this.phaInManager.SetSelectFormat(label, width, visible);

                /* 获取的为 未退库数量 
                 * SELECT  T.OUT_BILL_CODE,
				        T.OUT_LIST_CODE,
				        T.DRUG_CODE,
				        T.TRADE_NAME,
				        T.SPECS,
				        T.OUT_NUM - T.RETURN_NUM,
				        T.PACK_UNIT,
				        T.MIN_UNIT,
				        S.SPELL_CODE,
				        S.WB_CODE
				FROM    PHA_COM_OUTPUT T,PHA_COM_BASEINFO S
				WHERE   T.PARENT_CODE =  fun_get_parentcode 
				AND     T.CURRENT_CODE =  fun_get_currentcode 
				AND     T.PARENT_CODE = S.PARENT_CODE
				AND     T.CURRENT_CODE = S.CURRENT_CODE
				AND     T.DRUG_CODE = S.DRUG_CODE
				AND     (T.CLASS3_MEANING_CODE = '{1}' OR '{1}' = 'A')
				AND     T.OUT_STATE = '{2}'
				AND     T.DRUG_STORAGE_CODE = '{0}'
				AND	    (T.DRUG_DEPT_CODE = '{3}' OR '{3}' = 'AAAA')
                AND     T.OUT_NUM - T.RETURN_NUM > 0
                */
            }
        }

        /// <summary>
        /// 目标单位信息填充
        /// </summary>
        /// <param name="targetNO">目标单位编码</param>
        private int FillTargetInfo(string targetNO)
        {
            if (this.isPIDept)          //药库
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                Neusoft.HISFC.Models.Pharmacy.Company company = phaConsManager.QueryCompanyByCompanyID(targetNO);
                if (company == null)
                {
                    MessageBox.Show(Language.Msg("无法获取该条供货单位信息"));
                    return -1;
                }

                this.phaInManager.TargetDept = company;
                this.phaInManager.TargetDept.Memo = "1";
            }
            else
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(targetNO);
                if (dept == null)
                {
                    MessageBox.Show(Language.Msg("无法获取该条记录申请科室信息！"));
                    return -1;
                }

                this.phaInManager.TargetDept = dept;
                this.phaInManager.TargetDept.Memo = "0";
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

            if (this.phaInManager.ShowInfo == "")
            {
                this.phaInManager.ShowInfo = "入库单据: " + listNO;
            }
            else
            {
                this.phaInManager.ShowInfo = this.phaInManager.ShowInfo + "－" + listNO;
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
                    this.phaInManager.ShowInfo = "";
                    foreach (string strListNO in this.hsListNO.Keys)
                    {
                        if (this.phaInManager.ShowInfo == "")
                        {
                            this.phaInManager.ShowInfo = "入库单据: " + strListNO;
                        }
                        else
                        {
                            this.phaInManager.ShowInfo = this.phaInManager.ShowInfo + " － " + strListNO;
                        }
                    }
                }
                else
                {
                    this.hsListNO[listNO] = iCount - 1;
                }
            }
        }

        #region 药库核准加载函数 

        /// <summary>
        /// 根据发票号添加待核准数据
        /// </summary>
        /// <param name="invoiceNO"></param>
        private int AddInDataByInvoiceNO(string invoiceNO)
        {
            ArrayList alDetail = this.itemManager.QueryInputInfoByInvoice(this.phaInManager.DeptInfo.ID, invoiceNO, "1");
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return -1;
            }
            
            //this.phaInManager.ShowInfo = "入库单据号";

            foreach (Neusoft.HISFC.Models.Pharmacy.Input input in alDetail)
            {
                //主键设置
                input.User03 = input.ID;

                //判断是否重复加入
                if (this.hsInData.ContainsKey(this.GetKey(input)))
                {
                    MessageBox.Show(Language.Msg("该发票已加入选择!"));
                    return 0;
                }

                if (!hsListNO.ContainsKey(input.InListNO))
                {
                    this.AddListNO(input.InListNO);
                }
                //补充目标单位信息
                if (this.phaInManager.TargetDept.ID == "")
                {
                    this.FillTargetInfo(input.TargetDept.ID);
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

        #region 药房核准数据加载函数

        /// <summary>
        /// 根据出库流水号获取待核准数据
        /// </summary>
        /// <param name="outNO">出库流水号</param>
        /// <returns></returns>
        private int AddOutDataByOutNO(string outNO)
        {
            ArrayList alDetail = this.itemManager.QueryOutputList(outNO);
            if (alDetail == null || alDetail.Count <= 0)
            {
                MessageBox.Show(Language.Msg("根据出库流水号获取出库数据发生错误"));
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Output output in alDetail)
            {
                Neusoft.HISFC.Models.Pharmacy.Input input = this.InputConvert(output);

                if (this.hsInData.ContainsKey(this.GetKey(input)))
                {
                    MessageBox.Show(Language.Msg("该数据已加入选择!"));
                    return 0;
                }

                //是否已包含该单据
                if (!this.hsListNO.ContainsKey(input.OutListNO))
                {
                    if (this.hsListNO.Count > 0)
                    {
                        string msg = Language.Msg(string.Format("该药品入库单据号与当前入库单据号不同 该药品入库单据{0} 确认加入吗?", input.OutListNO));
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
                    if (this.hsListNO.ContainsKey(input.OutListNO))
                    {
                        this.hsListNO[input.OutListNO] = ((int)this.hsListNO[input.OutListNO]) + 1;
                    }
                    else
                    {                      
                        this.AddListNO(input.OutListNO);
                    }
                }
            }

            this.SetFormat();

            return 1;
        }        

        /// <summary>
        /// 添加待核准的出库数据
        /// </summary>
        /// <param name="outListNO">出库单据号</param>
        private void AddOutDataByListNO(string outListNO)
        {
            ArrayList alDetail = this.itemManager.QueryOutputInfo(this.phaInManager.TargetDept.ID, outListNO, "1");
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg("获取入库待核准数据发生错误" + this.itemManager.Err));
                return;
            }
            if (alDetail.Count == 0)
            {
                MessageBox.Show(Language.Msg("该单据可能已被核准"));
                return;
            }

            //先设置Fp进行初始化 提高加载速度
            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Output output in alDetail)
            {
                //对为零的记录不进行处理
                if (output.Quantity == 0)
                {
                    continue;
                }
                //对退库数量等于出库数量的 不进行处理 该记录已全部出库
                if (output.Quantity == output.Operation.ReturnQty)
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.Input input = this.InputConvert(output);

                if (this.AddDataToTable(input) == 1)
                {
                    this.hsInData.Add(this.GetKey(input), input);
                }
                else
                {
                    ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();
                    MessageBox.Show(Language.Msg("加载出库实体信息时发生错误"));
                    return;
                }
            }

            if (this.phaInManager.FpSheetView.Rows.Count == 0)
            {
                ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();
                MessageBox.Show(Language.Msg("该单据内不存在有效的待核准记录 药品都已退库或核准完成"));
                return;
            }

            //保存当前单据信息
            this.hsListNO.Add(outListNO, alDetail.Count);

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();

            return;
        }

        /// <summary>
        /// 入库实体赋值
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Pharmacy.Input InputConvert(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

            #region Input 信息填充

            //补充目标单位信息
            if (this.phaInManager.TargetDept.ID == "")
            {
                this.FillTargetInfo(input.TargetDept.ID);
            }

            input.StockDept = this.phaInManager.DeptInfo;                   //申请科室
            input.PrivType = this.phaInManager.PrivType.ID;                 //入库分类
            input.SystemType = this.phaInManager.PrivType.Memo;             //系统类型
            input.State = "2";                                              //状态 核准
            input.Company = this.phaInManager.TargetDept;
            input.TargetDept = this.phaInManager.TargetDept;                //目标单
            input.Item = output.Item;                                       //药品实体信息
            input.OutBillNO = output.ID;                                    //出库流水号
            input.OutListNO = output.OutListNO;                             //出库单据号
            input.OutSerialNO = output.SerialNO;                            //序号
            input.SerialNO = output.SerialNO;
            input.BatchNO = output.BatchNO;                                 //批号
            input.ValidTime = output.ValidTime;                             //有效期
            input.Quantity = output.Quantity;                               //数量
            input.PlaceNO = output.PlaceNO;                                 //货位号
            input.GroupNO = output.GroupNO;                                 //批次
            input.Operation = output.Operation;                             //操作信息

            #endregion

            //存储主键信息
            //出库审批数据 多批次出库时 同一药品不同批次 流水号相同 单据内序号不同
            input.User03 = output.ID + output.SerialNO;

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
                this.phaInManager.TotCostInfo = string.Format("零售总金额:{0} 购入总金额:{1}", retailCost.ToString("N"), purchaseCost.ToString("N"));
            }
            else
            {
                this.phaInManager.TotCostInfo = string.Format("零售总金额:{0}", retailCost.ToString("N"));
            }
        }

        #region 键值获取

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            //return input.Item.ID + input.BatchNO + input.InvoiceNO;
            return input.User03;
        }

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            //return dr["药品编码"].ToString() + dr["批号"].ToString() + dr["发票号"].ToString();
            return dr["主键"].ToString();
        }

        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns></returns>
        private string[] GetKey()
        {
            //string[] keys = new string[]{
            //                                    this.phaInManager.FpSheetView.Cells[this.phaInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text,
            //                                    this.phaInManager.FpSheetView.Cells[this.phaInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColBatchNO].Text,
            //                                    this.phaInManager.FpSheetView.Cells[this.phaInManager.FpSheetView.ActiveRowIndex,(int)ColumnSet.ColInvoiceNO].Text
            //                                };

            string[] keys = new string[]{
                                                this.phaInManager.FpSheetView.Cells[this.phaInManager.FpSheetView.ActiveRowIndex, (int)ColumnSet.ColKey].Text                                              
                                            };

            return keys;
        }

        #endregion

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
                                                                    new DataColumn("核准",      dtBol),
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("批号",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("入库数量",  dtDec),
                                                                    new DataColumn("入库金额",  dtDec),                                                                    
                                                                    new DataColumn("发票号",    dtStr),
                                                                    new DataColumn("发票分类",  dtStr),
                                                                    new DataColumn("购入价",    dtDec),
                                                                    new DataColumn("购入金额",  dtDec),
                                                                    new DataColumn("生产厂家",  dtStr),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr),
                                                                    new DataColumn("主键",    dtStr)
                                                                   }
                                  );
            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            //DataColumn[] keys = new DataColumn[3];

            //keys[0] = this.dt.Columns["药品编码"];
            //keys[1] = this.dt.Columns["批号"];
            //keys[2] = this.dt.Columns["发票号"];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["主键"];

            this.dt.PrimaryKey = keys;

            return this.dt;
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string dataNO = sv.Cells[activeRow, 0].Text;
            if (this.isPIDept)              //药库
            {
                if (this.AddInDataByInvoiceNO(dataNO) == 1)
                {
                    this.SetFocusSelect();
                }
                return 1;
            }
            else                            //药房
            {
                if (this.AddOutDataByOutNO(dataNO) == 1)
                {
                    this.SetFocusSelect();
                }
                return 1;
            }
        }

        public int ShowApplyList()
        {
            return 1;
        }

        public int ShowInList()
        {
            return 1;
        }

        public int ShowOutList()
        {
            if (this.ucListSelect == null)
                this.ucListSelect = new ucPhaListSelect();

            this.ucListSelect.Init();
            this.ucListSelect.DeptInfo = this.phaInManager.DeptInfo;

            System.Collections.Hashtable hsInOutState = new Hashtable();
            hsInOutState.Add("1", "审批");
            this.ucListSelect.InOutStateCollection = hsInOutState;
            this.ucListSelect.State = "1";                  //需检索状态
            this.ucListSelect.Class2Priv = "0320";          //出库
            this.ucListSelect.PrivType = this.phaInManager.PrivType;

            this.ucListSelect.SelecctListEvent -= new ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);
            this.ucListSelect.SelecctListEvent += new ucIMAListSelecct.SelectListHandler(ucListSelect_SelecctListEvent);

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucListSelect);

            #region 屏蔽原窗口弹出方式

            //string targetNO = "AAAA";
            //if (this.phaInManager.TargetDept.ID != "" && this.phaInManager.TargetDept.ID != null)
            //{
            //    targetNO = this.phaInManager.TargetDept.ID;
            //}
            ////取待核准记录 出库记录状态为"1"的
            //ArrayList alList = this.itemManager.QueryOutputListForApproveInput(targetNO, this.phaInManager.DeptInfo.ID, "A");
            //if (alList == null)
            //{
            //    MessageBox.Show(Language.Msg("获取出库单据数据出错" + this.itemManager.Err));
            //    return -1;
            //}

            ////弹出窗口选择单据
            //Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            //string[] fpLabel = { "入库单号", "供货单位" };
            //float[] fpWidth = { 120F, 120F };
            //bool[] fpVisible = { true, true, false, false, false, false };

            //if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, ref selectObj) == 1)
            //{
            //    this.Clear();

            //    Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

            //    targeDept.ID = selectObj.Memo;              //出库科室编码
            //    targeDept.Name = selectObj.Name;            //出库科室名称
            //    targeDept.Memo = "0";                       //目标单位性质 内部科室

            //    if (this.phaInManager.TargetDept.ID != targeDept.ID)
            //    {
            //        this.phaInManager.TargetDept = targeDept;
            //        this.ShowSelectData();
            //    }

            //    this.AddOutDataByListNO(selectObj.ID);

            //    this.SetFocusSelect();

            //    if (this.phaInManager.FpSheetView != null)
            //    {
            //        this.phaInManager.FpSheetView.ActiveRowIndex = 0;
            //    }
            //}

            #endregion

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
                        this.phaInManager.Fp.StopCellEditing();

                        //移出单据号
                        Neusoft.HISFC.Models.Pharmacy.Input tempInput = this.hsInData[this.GetKey(dr)] as Neusoft.HISFC.Models.Pharmacy.Input;
                        this.RemoveListNO(tempInput.OutListNO);
                        //由入库实体集合内移出
                        this.hsInData.Remove(this.GetKey(dr));
                        this.dt.Rows.Remove(dr);

                        this.phaInManager.Fp.StartCellEditing(null, false);
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

                this.hsListNO.Clear();
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
                    if (this.isPIDept)              //药库
                    {
                        this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColInvoiceNO;
                    }
                    else
                    {
                        this.phaInManager.FpSheetView.ActiveColumnIndex = (int)ColumnSet.ColIsApprove;
                    }
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
                MessageBox.Show(Language.Msg("请选择需核准数据"));
                return;
            }
            if (isHaveUnCheck)
            {
                DialogResult rs = MessageBox.Show(Language.Msg("存在未选择数据 确认对这些药品不进行核准吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return;
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //phaIntegrate.SetTrans(t.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            string inListNO = "";

            foreach (DataRow dr in this.dt.Rows)
            {
                if (!NConvert.ToBoolean(dr["核准"]))
                    continue;

                string key = this.GetKey(dr);

                //{7F9E7287-5803-4b42-9CFD-61A17FF1A5D4}  由Hash表获取数据时需调用Clone函数
                Neusoft.HISFC.Models.Pharmacy.Input input = (this.hsInData[key] as Neusoft.HISFC.Models.Pharmacy.Input).Clone();

                input.Operation.ApproveOper.OperTime = sysTime;                 //核准日期
                input.Operation.ApproveOper.ID = this.phaInManager.OperInfo.ID; //核准人
                input.Operation.Oper = input.Operation.ApproveOper;

                if (input.ID == "" || input.InListNO == "" || input.GroupNO == 0)
                {
                    #region 药房入库核准时 无入库记录 

                    if (inListNO == "" && (input.InListNO == "" || input.InListNO == null))
                    {
                        #region 获取新入库单号

                        if (input.OutListNO != "")
                        {
                            inListNO = input.OutListNO;
                        }
                        else
                        {
                            // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                            inListNO = phaIntegrate.GetInOutListNO(this.phaInManager.DeptInfo.ID, true);
                            if (inListNO == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Language.Msg("获取最新入库单号出错" + itemManager.Err));
                                return;
                            }                      
                        }

                        input.InListNO = inListNO;
                        #endregion
                    }
                    else
                    {
                        input.InListNO = inListNO;
                    }

                    decimal storageQty = 0;
                    if (this.itemManager.GetStorageNum(this.phaInManager.DeptInfo.ID, input.Item.ID, out storageQty) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("获取库存数量时出错" + this.itemManager.Err));
                        return;
                    }

                    input.StoreQty = storageQty + input.Quantity;
                    input.StoreCost = input.StoreQty / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;

                    input.Operation.ApplyOper = input.Operation.ApproveOper.Clone();
                    #endregion
                }

                if (this.isApproveEdit)
                {
                    input.InvoiceNO = dr["发票号"].ToString().Trim();
                    input.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(dr["购入价"]);
                }

                input.StockDept.Memo = this.phaInManager.DeptInfo.Memo;         //保存科室类别 PI药库 P药房

                //更新库存标记 对药库不进行更新 对药房更新库存
                if (this.itemManager.ApproveInput(input,input.StockDept.Memo == "PI"?"0":"1") == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存 " + dr["商品名称"].ToString() + " 时发生错误") + this.itemManager.Err);
                    return;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

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

        private void Fp_EditModeOff(object sender, EventArgs e)
        {
            if (this.phaInManager.FpSheetView.ActiveColumnIndex == (int)ColumnSet.ColPurchasePrice)
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

        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.ShowSelectData();
        }

        private void ucListSelect_SelecctListEvent(string listCode, string state, Neusoft.FrameWork.Models.NeuObject targetDept)
        {
            targetDept.Memo = "0";            //目标单位性质 内部科室

            if (this.phaInManager.TargetDept.ID != targetDept.ID)
            {
                this.phaInManager.TargetDept = targetDept;
                this.ShowSelectData();
            }

            this.Clear();

            this.AddOutDataByListNO(listCode);

            this.SetFocusSelect();

            if (this.phaInManager.FpSheetView != null)
            {
                this.phaInManager.FpSheetView.ActiveRowIndex = 0;
            }
        }


        private enum ColumnSet
        {
            /// <summary>
            /// 核准        0
            /// </summary>
            ColIsApprove,
            /// <summary>
            /// 商品名称	0
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
            /// 申请数量
            /// </summary>
            ColApplyNum,
            /// <summary>
            /// 备注	    14
            /// </summary>
            ColMemo,
            
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
            /// 主键
            /// </summary>
            ColKey
        }        
    }
}
