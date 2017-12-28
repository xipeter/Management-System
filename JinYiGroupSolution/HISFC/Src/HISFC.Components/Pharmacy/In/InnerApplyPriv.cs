using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 内部入库申请业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// 内部入库退库申请 保留出库单流水号
    /// 
    /// Pharmacy.Item.DeleteApplyOut
    /// Pharmacy.Item.UpdateApplyOutNum
    /// </summary>
    public class InnerApplyPriv : IPhaInManager
    {
        /// <summary>
        /// 入库申请
        /// 
        /// 剩余根据警戒线自动生产申请尚未做 
        /// 根据模版生成申请尚未做
        /// </summary>
        /// <param name="isBackIn">True 退库申请 False 正常入库申请</param>
        /// <param name="ucPhaManager"></param>
        public InnerApplyPriv(bool isBackIn, Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.isBack = isBackIn;

            this.listNO = "";

            this.SetPhaManagerProperty(ucPhaManager);
        }

        #region 域变量

        /// <summary>
        /// 是否退库申请
        /// </summary>
        private bool isBack = false;

        private ucPhaIn phaInManager = null;

        private FarPoint.Win.Spread.SheetView svTemp = null;

        private DataTable dt = null;

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 存储已添加的申请数据
        /// </summary>
        private System.Collections.Hashtable hsApplyData = new Hashtable();

        /// <summary>
        /// 本次单据申请单号
        /// </summary>
        private string listNO = "";

        private FarPoint.Win.Spread.CellType.NumberCellType numPriceCell = null;

        private FarPoint.Win.Spread.CellType.NumberCellType numQtyCell = null;

        /// <summary>
        /// 是否进行暂存数据操作
        /// 
        ///  {37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存
        /// </summary>
        private bool isTemporaryFun = false;

        /// <summary>
        ///  存储待打印数据 {0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636}
        /// </summary>
        private ArrayList alPrintData = new ArrayList();

        #endregion

        /// <summary>
        /// 设置主窗体属性
        /// </summary>
        /// <param name="ucPhaManager"></param>
        private void SetPhaManagerProperty(Neusoft.HISFC.Components.Pharmacy.In.ucPhaIn ucPhaManager)
        {
            this.phaInManager = ucPhaManager;

            if (this.phaInManager != null)
            {
                //设置界面显示
                this.phaInManager.IsShowItemSelectpanel = true;
                this.phaInManager.IsShowInputPanel = false;
                //目标科室设置
                this.phaInManager.SetTargetDept(false, true, Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy, Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                //FpSheetView
                this.svTemp = this.phaInManager.FpSheetView;

                //设置显示数据
                if (this.phaInManager.TargetDept.ID != "")
                {
                    this.ShowSelectData();
                }
                //设置工具栏按钮显示
                this.phaInManager.SetToolBarButton(true, false, false, false, true);
                this.phaInManager.SetToolBarButtonVisible(true, false, false, false, true, true, false);
                //设置信息显示
                this.phaInManager.ShowInfo = "";
                //Fp 设置
                this.phaInManager.FpSheetView.DataAutoSizeColumns = false;
                this.phaInManager.Fp.EditModeReplace = true;

                this.phaInManager.EndTargetChanged -= new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);
                this.phaInManager.EndTargetChanged += new ucIMAInOutBase.DataChangedHandler(value_EndTargetChanged);

                this.phaInManager.FpKeyEvent -= new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);
                this.phaInManager.FpKeyEvent += new ucIMAInOutBase.FpKeyHandler(value_FpKeyEvent);

                this.phaInManager.FpSheetView.DataAutoSizeColumns = false;
                this.phaInManager.FpSheetView.DataAutoCellTypes = false;
                this.SetFormat();

                if (!isBack)
                {
                    System.EventHandler eFun = new EventHandler(NumAlterHandler);

                    //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
                    this.phaInManager.AddToolBarButton("警戒线", "根据库存上下限自动生成申请", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B报警, 2, false, eFun);

                    System.EventHandler eOutFun = new EventHandler(OutAlterHandler);

                    this.phaInManager.AddToolBarButton("日消耗", "根据日消耗情况自动生成申请", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分解, 3, false, eOutFun);

                    System.EventHandler stencilFun = new EventHandler(StencilHandler);

                    this.phaInManager.AddToolBarButton("模版", "根据申请模版形成申请计划", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, 4, false, stencilFun);

                    //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
                    System.EventHandler temporaryListFun = new EventHandler(TemporaryListHandler);
                    this.phaInManager.AddToolBarButton("暂存单", "已录入的暂存申请单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, 5, true, temporaryListFun);

                    //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
                    System.EventHandler temporarySaveFun = new EventHandler(TemporarySaveHandler);
                    this.phaInManager.AddToolBarButton("暂存", "对当前已录入的申请单数据进行暂存", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z暂存, 7, false, temporarySaveFun);

                    //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
                    System.EventHandler clearFun = new EventHandler(ClearHandler);
                    this.phaInManager.AddToolBarButton("清空", "数据初始化 清空已录入信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空,9, true, clearFun);
                }

                this.InitConfig();
            }
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        private void InitConfig()
        {
            HISFC.Components.Pharmacy.Function fun = new Function();
            System.Xml.XmlDocument doc = fun.GetConfig();

            if (doc != null)
            {
                System.Xml.XmlNode valueNode = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='InnerApply']");
                if (valueNode != null)
                {
                    bool isShowStock = NConvert.ToBoolean(valueNode.Attributes["IsShowStock"].Value);

                    this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Visible = isShowStock;
                }
            }
        }

        /// <summary>
        /// 数据清空
        /// 
        /// {37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void ClearHandler(object sender, System.EventArgs args)
        {
            this.Clear();
        }

        /// <summary>
        /// 申请暂存
        /// 
        /// {37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void TemporarySaveHandler(object sender, System.EventArgs args)
        {
            this.isTemporaryFun = true;

            this.Save();            

            this.isTemporaryFun = false;
        }

        /// <summary>
        /// 暂存申请单列表
        /// 
        /// {37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void TemporaryListHandler(object sender, System.EventArgs args)
        {
            this.isTemporaryFun = true;

            this.ShowApplyList();

            this.isTemporaryFun = false;
        }

        /// <summary>
        /// Handler数量委托警戒线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void NumAlterHandler(object sender, System.EventArgs args)
        {
            this.FindByAlter("0", this.phaInManager.DeptInfo.ID);
        }

        /// <summary>
        /// Handler数量委托警戒线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void OutAlterHandler(object sender, System.EventArgs args)
        {
            this.FindByAlter("1", this.phaInManager.DeptInfo.ID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void StencilHandler(object sender, System.EventArgs args)
        {
            this.AddStencilData();
        }

        /// <summary>
        /// 向DataTable内增加数据
        /// </summary>
        /// <param name="applyOut">申请信息</param>
        /// <param name="dataSource">数据来源 0 原始数据 1 本次添加</param>
        /// <returns></returns>
        protected virtual int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut,string dataSource)
        {
            if (!Function.JudgePriceConsinstency(this.phaInManager.TargetDept.ID, applyOut.Item))
            {
                MessageBox.Show(Language.Msg("该药品已经经过科室调价！不能直接进行入库申请。如需请通知药库即进行全院调价"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucDrugStoreQuery uc = new ucDrugStoreQuery(applyOut.Item.ID);
                using (uc)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = applyOut.Item.Name + " 全院库存分布";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                }
                return -1;
            }

            if (this.dt == null)
            {
                this.InitDataTable();
            }

            try
            {
                decimal storeQty = 0;
                //{613A769A-C540-4a2c-949D-28B31F0BC482}
                decimal lowQty = 0;
                decimal topQty = 0;

                //内部入库退库申请屏蔽判断，否则不显示库存字段时就无法正常获取库存量 by Sunjh 2010-12-10 {04A7554D-152A-464e-9B9E-CAEFF977F757}
                //if (this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColStoreQty].Visible)
                //{
                   // this.itemManager.GetStorageNum(this.phaInManager.DeptInfo.ID, applyOut.Item.ID, out storeQty);
                    this.itemManager.GetStorageLowTopNum(this.phaInManager.DeptInfo.ID, applyOut.Item.ID, out storeQty, out lowQty, out topQty);
                //}

                decimal cost = applyOut.Operation.ApplyQty / applyOut.Item.PackQty * applyOut.Item.PriceCollection.RetailPrice;
                //{613A769A-C540-4a2c-949D-28B31F0BC482}
                string lostRate = string.Empty;
                if (lowQty != 0)
                {
                    lostRate = string.Format("{0:P}", storeQty / lowQty);
                }

                    
                this.dt.Rows.Add(new object[] { 
                                                applyOut.Item.Name,                                     //商品名称
                                                applyOut.Item.Specs,                                    //规格
                                                applyOut.Item.PriceCollection.RetailPrice,              //零售价
                                                applyOut.Item.PackUnit,                                 //包装单位
                                                applyOut.Item.MinUnit,                                 //最小单位
                                                System.Math.Round(storeQty / applyOut.Item.PackQty,2),
                                                applyOut.Operation.ApplyQty / applyOut.Item.PackQty,    //申请数量                                                
                                                cost,                                                   //申请金额
                                                lostRate,                                             //缺失比例{613A769A-C540-4a2c-949D-28B31F0BC482}
                                                applyOut.Memo,                                          //备注
                                                applyOut.Item.ID,                                       //药品编码
                                                applyOut.ID,                                            //流水号
                                                dataSource,
                                                applyOut.Item.NameCollection.SpellCode,                 //拼音码
                                                applyOut.Item.NameCollection.WBCode,                    //五笔码
                                                applyOut.Item.NameCollection.UserCode,                  //自定义码
                                                applyOut.Item.ID + applyOut.OutBillNO
                            
                                           }
                                    );
                
                this.dt.DefaultView.AllowDelete = true;
                this.dt.DefaultView.AllowEdit = true;
                this.dt.DefaultView.AllowNew = true;
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
        /// 根据申请单号增加申请数据
        /// </summary>
        /// <param name="listNO"></param>
        /// <returns></returns>
        private int AddApplyData(string listNO)
        {
            //{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存
            string applyState = "0";
            if (this.isTemporaryFun)
            {
                applyState = "A";
            }
            ////{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存
            ArrayList alDetail = this.itemManager.QueryApplyOutInfoByListCode(this.phaInManager.DeptInfo.ID, listNO, applyState);
            if (alDetail == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("未正确获取内部入库申请信息" + this.itemManager.Err));
                return -1;
            }

            this.Clear();
            //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636}    申请单打印
            this.alPrintData.Clear();

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alDetail)
            {
                info.Item = this.itemManager.GetItem(info.Item.ID);
                if (info.Item == null)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg("获取药品基本信息失败" + this.itemManager.Err));
                    return -1;
                }

                if (this.AddDataToTable(info, "0") == -1)
                    return -1;

                this.listNO = info.BillNO;

                this.hsApplyData.Add(this.GetKey(info), info);
            }

            this.dt.AcceptChanges();

            this.CompuateSum();

            this.SetFormat();

            ((System.ComponentModel.ISupportInitialize)(this.phaInManager.Fp)).EndInit();

            return 1;
        }

        /// <summary>
        /// 根据药品编码加入数据
        /// </summary>
        /// <param name="drugNO">药品编码</param>
        /// <param name="outBillNO">出库流水号</param>
        /// <returns></returns>
        private int AddDrugData(string drugNO,string outBillNO,decimal applyQty)
        {
            //取药品字典信息
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(drugNO);
            if (item == null)
            {
                MessageBox.Show(Language.Msg("检索药品基本信息失败"));
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();

            applyOut.Item = item;

            if (outBillNO != null)
            {
                applyOut.OutBillNO = outBillNO;
            }

            if (this.hsApplyData.Contains( this.GetKey(applyOut)))
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return 0;
            }           

            applyOut.Days = 1;
            applyOut.ApplyDept = this.phaInManager.DeptInfo;        //申请科室
            applyOut.StockDept = this.phaInManager.TargetDept;      //库存科室 (目标科室)
            applyOut.State = "0";                                   //状态 申请
            applyOut.SystemType = this.phaInManager.PrivType.Memo;
            applyOut.PrivType = this.phaInManager.PrivType.ID;

            if (applyQty != -1)
            {
                applyOut.Operation.ApplyQty = applyQty;
            }

            if (this.AddDataToTable(applyOut, "1") == 1)
            {
                this.hsApplyData.Add(this.GetKey(applyOut), applyOut);

                this.SetFormat();

                this.SetFocusSelect();

            }

            return 1;
        }

        /// <summary>
        /// 根据药品编码加入数据
        /// </summary>
        /// <param name="drugNO">药品编码</param>
        /// <param name="outBillNO">出库流水号</param>
        /// <returns></returns>
        private int AddDrugData(string drugNO, string outBillNO)
        {
            return AddDrugData(drugNO, outBillNO, -1);
        }

        /// <summary>
        /// 根据药品编码加入退库数据
        /// </summary>
        /// <param name="drugNO">药品编码</param>
        /// <returns></returns>
        private int AddDrugData(string drugNO)
        {
            return this.AddDrugData(drugNO, null);
        }


        /// <summary>
        /// 模版数据显示
        /// </summary>
        public void AddStencilData()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("根据模版生成计划信息将清除当前显示的数据 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            this.Clear();

            ArrayList alOpenDetail = Function.ChooseDrugStencil(this.phaInManager.DeptInfo.ID, Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil.Apply);

            if (alOpenDetail != null && alOpenDetail.Count > 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在根据所选模版生成申请信息..."));
                Application.DoEvents();

                int i = 0;
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in alOpenDetail)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, alOpenDetail.Count);
                    Application.DoEvents();

                    this.AddDrugData(info.Item.ID);
                    i++;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
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
                string[] label = new string[] { "出库流水号", "出库单据号", "药品编码", "商品名称", "规格", "数量", "包装单位", "最小单位", "拼音码", "五笔码" };
                int[] width = new int[] { 60, 60, 60, 120, 80, 60, 60, 60, 60, 60 };
                bool[] visible = new bool[] { false, false, false, true, true, true, false, true, false, false };

                this.phaInManager.SetSelectData("3", false,new string[] { "Pharmacy.Item.GetOutputInfoForInput" }, filterStr, this.phaInManager.DeptInfo.ID, "A", "2", this.phaInManager.TargetDept.ID);

                this.phaInManager.SetSelectFormat(label, width, visible);

                #region Sql语句

                /*
                SELECT  T.OUT_BILL_CODE,
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

                #endregion
            }
            else
            {
                this.phaInManager.SetSelectData("1",Function.IsOutByBatchNO, null, null, null);
            }

            this.phaInManager.SetItemListWidth(2);

            return 1;
        }

        /// <summary>
        /// 格式化Fp显示
        /// </summary>
        private void SetFormat()
        {
            if (this.svTemp == null)
                return;

            this.svTemp.DefaultStyle.Locked = true;

            this.svTemp.Columns[(int)ColumnSet.ColTradeName].Width = 130F;
            this.svTemp.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.svTemp.Columns[(int)ColumnSet.ColRetailPrice].Width = 80F;
            this.svTemp.Columns[(int)ColumnSet.ColPackUnit].Width = 60F;
            this.svTemp.Columns[(int)ColumnSet.ColApplyCost].Width = 95F;

            this.svTemp.Columns[(int)ColumnSet.ColKey].Visible = false;              //主键
            this.svTemp.Columns[(int)ColumnSet.ColDrugID].Visible = false;           //药品编码
            this.svTemp.Columns[(int)ColumnSet.ColNO].Visible = false;               //流水号
            this.svTemp.Columns[(int)ColumnSet.ColDataSource].Visible = false;       //数据来源
            this.svTemp.Columns[(int)ColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.svTemp.Columns[(int)ColumnSet.ColWBCode].Visible = false;           //五笔码
            this.svTemp.Columns[(int)ColumnSet.ColUserCode].Visible = false;         //自定义码

            this.svTemp.Columns[(int)ColumnSet.ColMemo].Width = 200F;
            this.svTemp.Columns[(int)ColumnSet.ColMemo].Locked = false;

            numPriceCell = new FarPoint.Win.Spread.CellType.NumberCellType();
            numPriceCell.DecimalPlaces = 4;
            numPriceCell.MinimumValue = 0;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColRetailPrice].CellType = this.numPriceCell;

            numQtyCell = new FarPoint.Win.Spread.CellType.NumberCellType();
            numQtyCell.DecimalPlaces = 2;
            numQtyCell.MinimumValue = 0;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].CellType = this.numQtyCell;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyCost].CellType = this.numQtyCell;

            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].Locked = false;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColApplyQty].BackColor = System.Drawing.Color.SeaShell;
            this.phaInManager.FpSheetView.Columns[(int)ColumnSet.ColLostRate].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
        }

        ///<summary>
        ///根据药品警戒线加入数据
        ///</summary>
        ///<param name="alterFlag">生成方式 0 警戒线 1 日消耗</param>
        ///<param name="deptCode">库房编码</param>
        ///<returns>成功返回0，失败返回－1</returns>
        public void FindByAlter(string alterFlag, string deptCode)
        {
            if (this.hsApplyData.Count > 0)
            {
                DialogResult result;
                result = MessageBox.Show("按警戒线生成将清除当前内容，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                if (result == DialogResult.No)
                    return;
            }

            try
            {
                this.Clear();

                ArrayList alDetail = new ArrayList();
                if (alterFlag == "1")
                {
                    #region 弹出窗口 设置日消耗参数 计算需申请信息
                    using (HISFC.Components.Pharmacy.ucPhaAlter uc = new ucPhaAlter())
                    {
                        uc.DeptCode = deptCode;
                        uc.SetData();
                        uc.Focus();
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                        if (uc.ApplyInfo != null)
                        {
                            alDetail = uc.ApplyInfo;
                        }
                    }
                    #endregion
                }
                else
                {
                    //{F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 更改调用函数
                    alDetail = this.itemManager.QueryDrugListByNumAlter(deptCode);
                    if (alDetail == null)
                    {
                        MessageBox.Show(Language.Msg("按照数量警戒线执行信息计算未正确执行\n" + this.itemManager.Err));
                        return;
                    }
                }

                Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
                foreach (Neusoft.FrameWork.Models.NeuObject temp in alDetail)
                {
                    this.AddDrugData(temp.ID,null,NConvert.ToDecimal(temp.User03));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
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
                for (int i = 0; i < this.phaInManager.FpSheetView.Rows.Count; i++)
                {
                    retailCost += NConvert.ToDecimal(this.phaInManager.FpSheetView.Cells[i, (int)ColumnSet.ColApplyCost].Text);
                }

                this.phaInManager.TotCostInfo = string.Format("申请总金额:{0} ", retailCost.ToString("N"));
            }
        }

        /// <summary>
        /// 退库申请时判断是否库存足够
        /// </summary>
        /// <param name="drugCode">药品编码 </param>
        /// <param name="applyQty">申请退库数量 </param>
        /// <returns>库存足够返回True 否则返回False</returns>
        private bool IsEnoughStore(string drugCode,decimal applyQty)
        {
            decimal storeQty = applyQty;

            this.itemManager.GetStorageNum(this.phaInManager.DeptInfo.ID, drugCode, out storeQty);

            if (storeQty < applyQty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="applyOut"></param>
        /// <returns></returns>
        private string GetKey(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            if (applyOut.OutBillNO == null)
            {
                applyOut.OutBillNO = "";
            }
            return applyOut.Item.ID + applyOut.OutBillNO;
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetKey(DataRow dr)
        {
            return dr["主键"].ToString();
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="findIndex"></param>
        /// <returns></returns>
        private string[] GetFindKey(FarPoint.Win.Spread.SheetView sv, int findIndex)
        {
            return new string[] { sv.Cells[findIndex, (int)ColumnSet.ColKey].Text };
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
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("包装单位",  dtStr),
                                                                    new DataColumn("最小单位",  dtStr),
                                                                    new DataColumn("本科库存",  dtDec),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("申请金额",  dtDec),
                                                                    new DataColumn("缺失比例",dtStr),//{613A769A-C540-4a2c-949D-28B31F0BC482}
                                                                    new DataColumn("备注",      dtStr),                                                                    
                                                                    new DataColumn("药品编码",  dtStr),
                                                                    new DataColumn("流水号",    dtStr),
                                                                    new DataColumn("数据来源",  dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr),
                                                                    new DataColumn("主键",      dtStr)
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
        /// 增加药品项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parms"></param>
        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugID = "";
            if (isBack)
            {
                drugID = sv.Cells[activeRow, 2].Value.ToString();

                string outbillNO = sv.Cells[activeRow, 0].Value.ToString();
                return this.AddDrugData(drugID, outbillNO);
            }
            else
            {
                drugID = sv.Cells[activeRow, 0].Value.ToString();
                return this.AddDrugData(drugID);
            }
        }

        public int ShowApplyList()
        {
            //{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存
            string applyState = "0";
            if (this.isTemporaryFun)
            {
                applyState = "A";
            }

            ////{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存  获取申请信息
            ArrayList alTemp = this.itemManager.QueryApplyOutList(this.phaInManager.DeptInfo.ID, this.phaInManager.PrivType.Memo, applyState);
            if (alTemp == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("获取申请信息失败" + this.itemManager.Err));
                return -1;
            }
            ArrayList alList = new ArrayList();
            //根据当前选择的供货单位过滤
            if (this.phaInManager.TargetDept.ID != "")
            {
                foreach (Neusoft.FrameWork.Models.NeuObject info in alTemp)
                {
                    if (info.Memo != this.phaInManager.TargetDept.ID)
                        continue;
                    alList.Add(info);
                }
            }
            else
            {
                alList = alTemp;
            }

            //弹出窗口选择单据
            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] fpLabel = { "申请单号", "供货单位" };
            float[] fpWidth = { 120F, 120F };
            bool[] fpVisible = { true, true, false, false, false, false };

            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alList, ref selectObj) == 1)
            {
                this.Clear();

                Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

                targeDept.ID = selectObj.Memo;              //供货公司编码
                targeDept.Name = selectObj.Name;            //供货公司姓名
                targeDept.Memo = "0";                       //目标单位性质 内部科室

                if (this.phaInManager.TargetDept.ID != targeDept.ID)
                {
                    this.phaInManager.TargetDept = targeDept;
                    this.ShowSelectData();
                }

                this.AddApplyData(selectObj.ID);

                this.SetFocusSelect();

                if (this.svTemp != null)
                {
                    this.phaInManager.Fp.StartCellEditing(null, false);
                }
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
            if (this.phaInManager.TargetDept.ID == "")
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("请选择供货科室！"));
                return false;
            }
            try
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["申请数量"]) <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show(dr["商品名称"].ToString() + "申请数量不能小于等于零");
                        return false;
                    }

                    //{99136B29-4E44-44aa-84DC-F3F24F2E98DE}退库申请时申请数量不能大于库存
                    if (isBack)
                    {
                        if (NConvert.ToDecimal(dr["申请数量"]) > NConvert.ToDecimal(dr["本科库存"]))
                        {
                            System.Windows.Forms.MessageBox.Show(dr["商品名称"].ToString() + "申请数量不能大于本科库存");
                            return false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    DialogResult rs = MessageBox.Show("确认对所选择数据进行删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    DataRow dr = this.dt.Rows.Find(this.GetFindKey(sv, delRowIndex));
                    if (dr != null)
                    {
                        #region 数据移出

                        if (dr["流水号"].ToString() != "")
                        {
                            int parm = this.itemManager.DeleteApplyOut(dr["流水号"].ToString());
                            if (parm == -1)
                            {
                                MessageBox.Show(Language.Msg(this.itemManager.Err));
                                return -1;
                            }
                            if (parm == 0)
                            {
                                MessageBox.Show(Language.Msg("申请可能已被出库审批 请重试"));
                                return -1;
                            }
                            MessageBox.Show(Language.Msg("删除成功"));
                        }

                        #endregion

                        this.phaInManager.Fp.StopCellEditing();

                        this.hsApplyData.Remove(this.GetKey(dr));

                        this.dt.Rows.Remove(dr);
                       
                        this.phaInManager.Fp.StartCellEditing(null, false);

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

                this.phaInManager.TotCostInfo = "";

                this.listNO = "";
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
            if (this.svTemp != null)
            {
                if (this.svTemp.Rows.Count > 0)
                {
                    this.phaInManager.SetFpFocus();

                    this.svTemp.ActiveRowIndex = this.svTemp.Rows.Count - 1;
                    this.svTemp.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
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

            DataTable dtAddMofity = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);

            //{37D3D84C-702A-4090-8CB0-B9993279C735}   为了实现暂存 每次处理全部数据
            //if (dtAddMofity == null || dtAddMofity.Rows.Count <= 0)
            //    return;

            //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
            this.alPrintData.Clear();

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            if (this.listNO == "")
            {
                #region 获取新申请单据号

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
                //phaIntegrate.SetTrans(t.Trans);

                // //{59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 更改入库单号获取方式
                listNO = phaIntegrate.GetInOutListNO(this.phaInManager.DeptInfo.ID, false);
                if (listNO == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    System.Windows.Forms.MessageBox.Show(Language.Msg("获取新申请单据号发生错误" + this.itemManager.Err));
                    return;
                }

                #endregion
            }

            ////{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存 是否暂存数据
            bool isTemporaryData = false;
            string msg = "保存申请成功";

            //{37D3D84C-702A-4090-8CB0-B9993279C735}  入库申请暂存
            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApplyData[this.GetKey(dr)] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                #region 申请单信息赋值

                applyOut.Operation.ApplyOper.OperTime = sysTime;

                applyOut.Memo = dr["备注"].ToString();

                if (this.isBack)
                {
                    if (!this.IsEnoughStore(applyOut.Item.ID, applyOut.Operation.ApplyQty))
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show(Language.Msg(applyOut.Item.Name + " 库存数量小于本次退库申请数量 请调整退库数量"));
                        return;
                    }
                }

                applyOut.Operation.ApplyQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( dr["申请数量"] ) * applyOut.Item.PackQty;

                #endregion

                //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存
                if (isTemporaryFun)     //选择了暂存操作
                {
                    if (applyOut.State == "0" && (string.IsNullOrEmpty(applyOut.ID) == false))
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("存在已提交数据 不能进行申请单暂存操作，请选择保存进行提交", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    applyOut.State = "A";

                    msg = "暂存申请成功";
                }

                if (applyOut.ID == "")
                {
                    #region 新产生数据

                    applyOut.BillNO = this.listNO;              //申请单据号

                    if (this.itemManager.InsertApplyOut(applyOut) == -1)                    
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg(this.itemManager.Err));
                        return;
                    }

                    #endregion
                }
                else
                {
                    #region 更新原有数据

                    int parm = this.itemManager.UpdateApplyOutNum(applyOut.ID, applyOut.Operation.ApplyQty);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show(Language.Msg("对申请数量进行更新失败" + this.itemManager.Err));
                        return;
                    }
                    if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        System.Windows.Forms.MessageBox.Show(Language.Msg("该申请单已被审核！无法进行修改!请刷新重试"));
                        return;
                    }

                    #endregion
                }

                //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存    设置是否存在暂存数据
                if (applyOut.State == "A")
                {
                    isTemporaryData = true;
                }

                //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
                this.alPrintData.Add(applyOut);
            }

            //{37D3D84C-702A-4090-8CB0-B9993279C735}   入库申请暂存    暂存数据提交
            if (isTemporaryData && (isTemporaryFun == false))
            {
                if (this.itemManager.UpdateApplyOutState(this.phaInManager.DeptInfo.ID, this.listNO, "0") == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("提交入库申请单失败") + this.itemManager.Err,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                msg = "提交入库申请成功";
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg(msg));

            //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
            if (isTemporaryFun == false)            //非暂存操作
            {
                this.Print();
            }

            this.Clear();
        }

        public int Print()
        {
            //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
            DialogResult rs = MessageBox.Show("是否打印申请单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (this.phaInManager.IInPrint != null)
                {
                    this.phaInManager.IInPrint.SetData(this.alPrintData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.InnerApplyIn);
                    this.phaInManager.IInPrint.Print();
                }
            }

            return 1;
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            return 1;
        }

        #endregion

        private void value_EndTargetChanged(Neusoft.FrameWork.Models.NeuObject changeData, object param)
        {
            this.Clear();

            this.ShowSelectData();
        }

        private void value_FpKeyEvent(Keys key)
        {
            if (this.svTemp != null)
            {
                if (key == Keys.Enter)
                {
                    if (this.svTemp.ActiveColumnIndex == (int)ColumnSet.ColApplyQty)
                    {
                        decimal applyQty = NConvert.ToDecimal(this.svTemp.Cells[this.svTemp.ActiveRowIndex, (int)ColumnSet.ColApplyQty].Text);
                        decimal price = NConvert.ToDecimal(this.svTemp.Cells[this.svTemp.ActiveRowIndex, (int)ColumnSet.ColRetailPrice].Text);
                        this.svTemp.Cells[this.svTemp.ActiveRowIndex, (int)ColumnSet.ColApplyCost].Text = (applyQty * price).ToString();

                        this.CompuateSum();
                    }

                    if (this.svTemp.ActiveRowIndex == this.svTemp.Rows.Count - 1)
                    {
                        this.phaInManager.SetFocus();
                    }
                    else
                    {                      
                        this.svTemp.ActiveRowIndex++;
                        this.svTemp.ActiveColumnIndex = (int)ColumnSet.ColApplyQty;
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
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
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
            /// 本科库存
            /// </summary>
            ColStoreQty,
            /// <summary>
            /// 申请数量
            /// </summary>
            ColApplyQty,
            /// <summary>
            /// 申请金额
            /// </summary>
            ColApplyCost,
            /// <summary>
            /// 缺失比例{613A769A-C540-4a2c-949D-28B31F0BC482}
            /// </summary>
            ColLostRate,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugID,
            /// <summary>
            /// 流水号
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
            ColUserCode,
            /// <summary>
            /// 主键
            /// </summary>
            ColKey
        }
    }
}
