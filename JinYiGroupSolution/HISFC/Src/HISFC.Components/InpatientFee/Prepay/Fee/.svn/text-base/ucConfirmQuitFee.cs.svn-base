using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucNurseQuitFee<br></br>
    /// [功能描述: 住院退费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucConfirmQuitFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// ucQuitFee<br></br>
        /// [功能描述: 住院退费UC]<br></br>
        /// [创 建 者: 王宇]<br></br>
        /// [创建时间: 2006-11-06]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间='yyyy-mm-dd'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucConfirmQuitFee()
        {
            InitializeComponent();
        }
        
        #region 变量

        /// <summary>
        /// 如出转业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 费用公共业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 住院收费业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 非药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy phamarcyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 退费申请业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.ReturnApply returnApplyManager = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院患者基本信息
        /// </summary>
        protected PatientInfo patientInfo = null;

        /// <summary>
        /// 药品未退列表
        /// </summary>
        protected DataTable dtDrug = new DataTable();

        /// <summary>
        /// 药品DV
        /// </summary>
        protected DataView dvDrug = new DataView();

        /// <summary>
        /// 药品已退列表
        /// </summary>
        protected DataTable dtDrugQuit = new DataTable();

        /// <summary>
        /// 非药品未退列表
        /// </summary>
        protected DataTable dtUndrug = new DataTable();

        /// <summary>
        /// 非药品未退dv
        /// </summary>
        protected DataView dvUndrug = new DataView();

        /// <summary>
        /// 非药品已退列表
        /// </summary>
        protected DataTable dtUndrugQuit = new DataTable();

        /// <summary>
        /// 可操作的项目类别
        /// </summary>
        protected ItemTypes itemType;

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 是否可以手工输入住院号
        /// </summary>
        protected bool isCanInputInpatientNO = true;

        /// <summary>
        /// 转换最小费用ID,Name类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper objectHelperMinFee = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 是否可以修改退费项目
        /// </summary>
        private bool isChangItem = true;

        /// <summary>
        /// 物资收费业务层
        /// </summary>
        private HISFC.BizProcess.Integrate.Material.Material mateIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();

        /// <summary>
        /// 复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        protected bool isCombItemAllQuit = false;
        //{F4912030-EF65-4099-880A-8A1792A3B449}结束

        #endregion

        #region 属性

        /// <summary>
        /// 复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        public bool IsCombItemAllQuit
        {
            get
            {
                return this.isCombItemAllQuit;
            }
            set
            {
                this.isCombItemAllQuit = value;
            }
        }//{F4912030-EF65-4099-880A-8A1792A3B449}结束

        /// <summary>
        /// 可操作的项目类别
        /// </summary>
        [Category("控件设置"), Description("设置或者获得可操作的项目类别")]
        public ItemTypes ItemType 
        {
            set 
            {
                this.itemType = value;
            }
            get 
            {
                return this.itemType;
            }
        }

        /// <summary>
        /// 住院患者基本信息
        /// </summary>
        public PatientInfo PatientInfo 
        {
            get 
            {
                return this.patientInfo;
            }
            set 
            {
                this.patientInfo = value;

                this.SetPatientInfomation();
            }
        }

        /// <summary>
        /// 是否可以手工输入住院号
        /// </summary>
        [Category("控件设置"), Description("是否可以手工输入住院号")]
        public bool IsCanInputInpatientNO
        {
            get
            {
                return this.isCanInputInpatientNO;
            }
            set
            {
                this.isCanInputInpatientNO = value;

                this.ucQueryPatientInfo.Enabled = this.isCanInputInpatientNO;
            }
        }

        [Category("控件设置"),Description("是否可以修改退费项目")]
        public bool IsChangItem
        {
            get
            {
                return isChangItem;
            }
            set
            {
                isChangItem = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        protected virtual void SetPatientInfomation() 
        {
            this.txtName.Text = this.patientInfo.Name;
            this.txtPact.Text = this.patientInfo.Pact.Name;
            this.txtDept.Text = this.patientInfo.PVisit.PatientLocation.Dept.Name;
            this.txtBed.Text = this.patientInfo.PVisit.PatientLocation.Bed.ID; 
            this.dtpBeginTime.Focus();
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns></returns>
        protected virtual int Init() 
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            this.dtpBeginTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 0, 0, 0);
            this.dtpEndTime.Value = nowTime;

            ArrayList minFeeList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);
            if (minFeeList == null) 
            {
                MessageBox.Show("获得最小费用出错!" + this.managerIntegrate.Err);

                return -1;
            }

            this.objectHelperMinFee.ArrayObject = minFeeList;
            feeIntegrate.MessageType = Neusoft.HISFC.Models.Base.MessType.N;
            this.fpQuit_SheetDrug.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Cell;
            this.fpQuit_SheetDrug.Columns[0].Locked = false;
            //this.InitFp();
            if (!IsChangItem)
            {
                this.fpQuit_SheetDrug.Columns[0].Locked = true;
                this.fpQuit_SheetUndrug.Columns[0].Locked = true;
            }
            return 1;
        }

        ///// <summary>
        ///// 设置药品列表
        ///// </summary>
        ///// <param name="drugList"></param>
        //protected virtual void SetDrugList(ArrayList drugList)
        //{
        //    foreach (FeeItemList feeItemList in drugList)
        //    {
        //        DataRow row = this.dtDrug.NewRow();

        //        //读取药品基本信息,这里暂时为了获得拼音码
        //        Neusoft.HISFC.Models.Base.Item phamarcyItem = this.phamarcyIntegrate.GetItem(feeItemList.Item.ID);
        //        if (phamarcyItem == null)
        //        {
        //            phamarcyItem = new Neusoft.HISFC.Models.Base.Item();

        //        }

        //        if (phamarcyItem.PackQty == 0) 
        //        {
        //            phamarcyItem.PackQty = 1;
        //        }

        //        feeItemList.Item.IsPharmacy = true;
        //        row["药品名称"] = feeItemList.Item.Name;
        //        row["规格"] = feeItemList.Item.Specs;
        //        row["费用名称"] = this.objectHelperMinFee.GetName(feeItemList.Item.MinFee.ID);
        //        row["价格"] = feeItemList.Item.Price;
        //        row["可退数量"] = feeItemList.NoBackQty;
        //        row["单位"] = feeItemList.Item.PriceUnit;
        //        row["金额"] = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * feeItemList.NoBackQty / phamarcyItem.PackQty, 2);
        //        Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

        //        deptInfo = this.managerIntegrate.GetDepartment(feeItemList.ExecOper.Dept.ID);
        //        if (deptInfo == null)
        //        {
        //            deptInfo = new Neusoft.HISFC.Models.Base.Department();
        //            deptInfo.Name = feeItemList.ExecOper.Dept.ID;
        //        }

        //        row["执行科室"] = deptInfo.Name;

                
        //        Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
        //        empl = this.managerIntegrate.GetEmployeeInfo(feeItemList.RecipeOper.ID);
        //        if (empl.Name == string.Empty)
        //        {
        //            row["开方医师"] = feeItemList.RecipeOper.ID;
        //        }
        //        else
        //        {
        //            row["开方医师"] = empl.Name;
        //        }

        //        //row["开方医师"] = feeItemList.RecipeOper.ID;
        //        row["记帐日期"] = feeItemList.FeeOper.OperTime;
        //        row["是否发药"] = feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged ? '是' : '否';
             
        //        row["编码"] = feeItemList.Item.ID;
        //        row["医嘱号"] = feeItemList.Order.ID;
        //        row["医嘱执行号"] = feeItemList.ExecOrder.ID;
        //        row["处方号"] = feeItemList.RecipeNO;
        //        row["处方流水号"] = feeItemList.SequenceNO;

        //        row["拼音码"] = phamarcyItem.SpellCode;

        //        this.dtDrug.Rows.Add(row);
        //    }
        //}

        /// <summary>
        /// 获得未退费的药品信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RetriveUnrug(DateTime beginTime, DateTime endTime)
        {
            ArrayList undrugList = this.inpatientManager.QueryFeeItemListsCanQuit(this.patientInfo.ID, beginTime, endTime, false);
            if (undrugList == null)
            {
                MessageBox.Show(Language.Msg("获得非药品列表出错!") + this.inpatientManager.Err);

                return -1;
            }

            this.SetUndrugList(undrugList);

            return 1;
        }

        /// <summary>
        /// 设置非药品列表
        /// </summary>
        /// <param name="undrugList"></param>
        protected virtual void SetUndrugList(ArrayList undrugList)
        {
            foreach (FeeItemList feeItemList in undrugList)
            {
                DataRow row = this.dtUndrug.NewRow();

                //获得非药品信息,这里主要是为了获得检索码
                Neusoft.HISFC.Models.Fee.Item.Undrug undrugItem = this.undrugManager.GetValidItemByUndrugCode(feeItemList.Item.ID);
                if (undrugItem == null)
                {
                    undrugItem = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                }
                if (undrugItem.PackQty == 0) 
                {
                    undrugItem.PackQty = 1;
                }
                //feeItemList.Item.IsPharmacy = false;
                feeItemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                row["项目名称"] = feeItemList.Item.Name;
                row["费用名称"] = this.objectHelperMinFee.GetName(feeItemList.Item.MinFee.ID);
                row["价格"] = feeItemList.Item.Price;
                row["可退数量"] = feeItemList.NoBackQty;
                row["单位"] = feeItemList.Item.PriceUnit;
                row["金额"] = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * feeItemList.NoBackQty / undrugItem.PackQty, 2);
                Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

                deptInfo = this.managerIntegrate.GetDepartment(feeItemList.ExecOper.Dept.ID);
                if (deptInfo == null)
                {
                    deptInfo = new Neusoft.HISFC.Models.Base.Department();
                    deptInfo.Name = feeItemList.ExecOper.Dept.ID;
                }

                row["执行科室"] = deptInfo.Name;

                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = this.managerIntegrate.GetEmployeeInfo(feeItemList.RecipeOper.ID);
                if (empl.Name == string.Empty)
                {
                    row["开方医师"] = feeItemList.RecipeOper.ID;
                }
                else
                {
                    row["开方医师"] = empl.Name;
                }
                //row["开方医师"] = feeItemList.RecipeOper.ID;
                row["记帐日期"] = feeItemList.FeeOper.OperTime;
                row["是否执行"] = feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged ? '是' : '否';
                row["编码"] = feeItemList.Item.ID;
                row["医嘱号"] = feeItemList.Order.ID;
                row["医嘱执行号"] = feeItemList.ExecOrder.ID;
                row["处方号"] = feeItemList.RecipeNO;
                row["处方流水号"] = feeItemList.SequenceNO;

                row["拼音码"] = undrugItem == null ? string.Empty : undrugItem.SpellCode;

                this.dtUndrug.Rows.Add(row);
            }
        }


        private void RetrieveReturnApply(bool isPharmarcy) 
        {
            ArrayList returnApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, isPharmarcy);
            
            if (returnApplys == null) 
            {
                MessageBox.Show("获得退费申请信息出错！");

                return;
            }
            if (!isPharmarcy)
            { 
                //查找物资
                ArrayList al = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, HISFC.Models.Base.EnumItemType.MatItem);

                if (al == null)
                {
                    MessageBox.Show("获得退费物资信息出错！");

                    return;
                }
                returnApplys.AddRange(al);
            }

            decimal return_DrugCost = 0;
            decimal return_UndrugCost = 0;

            foreach (Neusoft.HISFC.Models.Fee.ReturnApply retrunApply in returnApplys) 
            {
                //药品
                //if (retrunApply.Item.IsPharmacy)
                if(retrunApply.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    this.fpQuit_SheetDrug.Rows.Add(this.fpQuit_SheetDrug.RowCount, 1);

                    int index = this.fpQuit_SheetDrug.RowCount - 1;
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.ItemState,false);

                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.ItemName, retrunApply.Item.Name);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Specs, retrunApply.Item.Specs);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Price, retrunApply.Item.Price);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Qty, retrunApply.Item.Qty);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Unit, retrunApply.Item.PriceUnit);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2));
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.FeeDate, retrunApply.CancelOper.OperTime);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsConfirm, retrunApply.IsConfirmed);
                    this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsApply, true);
                    //处理作废处方号
                    retrunApply.CancelRecipeNO = retrunApply.RecipeNO;
                    //处理作废处方内部流水号
                    retrunApply.CancelSequenceNO = retrunApply.SequenceNO;
                    this.fpQuit_SheetDrug.Rows[index].Tag = retrunApply;
                    return_DrugCost = return_DrugCost + Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2);
                }
                else
                {
                    #region 查找物资信息

                    //查找非药品对照物资的出库记录
                    List<HISFC.Models.FeeStuff.Output> outlist = returnApplyManager.QueryOutPutByApplyNo(retrunApply.ID, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
                    //List<HISFC.Models.Fee.ReturnApplyMet> metApplyList = returnApplyManager.QueryReturnApplyMetByApplyNo(retrunApply.ID, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);

                    retrunApply.MateList = outlist;   
                    #endregion
                    
                    this.fpQuit_SheetUndrug.Rows.Add(this.fpQuit_SheetUndrug.RowCount, 1);

                    int index = this.fpQuit_SheetUndrug.RowCount - 1;

                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ItemState, false);
                    
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ItemName, retrunApply.Item.Name);

                    if (retrunApply.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.UnDrug)
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug undrugInfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        Neusoft.HISFC.BizLogic.Fee.Item feeItemManager = new Neusoft.HISFC.BizLogic.Fee.Item();
                        undrugInfo = feeItemManager.GetUndrugByCode(retrunApply.Item.ID);
                        this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName, this.inpatientManager.GetMinFeeNameByCode(undrugInfo.MinFee.ID));
                    }
                    else
                    {
                        Neusoft.HISFC.Models.FeeStuff.MaterialItem mateItem = new Neusoft.HISFC.Models.FeeStuff.MaterialItem();
                        mateItem = mateIntegrate.GetMetItem(retrunApply.Item.ID);
                        if (mateItem == null)
                        { 
                            MessageBox.Show("查找物资项目错误！"+mateIntegrate.Err);
                            return;
                        }
                        this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName, this.inpatientManager.GetMinFeeNameByCode(mateItem.MinFee.ID));
                    }
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Price, retrunApply.Item.Price);
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Qty, retrunApply.Item.Qty);
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Unit, retrunApply.Item.PriceUnit);
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2));
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsConfirm, retrunApply.IsConfirmed);
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsApply, true);
                    Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

                    deptInfo = this.managerIntegrate.GetDepartment(retrunApply.ExecOper.Dept.ID);
                    if (deptInfo == null)
                    {
                        deptInfo = new Neusoft.HISFC.Models.Base.Department();
                        deptInfo.Name = retrunApply.ExecOper.Dept.ID;
                    }
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ExecDept, deptInfo.Name);
                    //处理作废处方号
                    retrunApply.CancelRecipeNO = retrunApply.RecipeNO;
                    //处理作废处方内部流水号
                    retrunApply.CancelSequenceNO = retrunApply.SequenceNO;
                    this.fpQuit_SheetUndrug.Rows[index].Tag = retrunApply;
                    return_UndrugCost = return_UndrugCost + Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2);
                }
            }

            if (this.fpQuit_SheetDrug.Rows.Count != 0 && isPharmarcy == true )
            {
                this.fpQuit_SheetDrug.Rows.Add(this.fpQuit_SheetDrug.Rows.Count, 1);
                this.fpQuit_SheetDrug.Cells[this.fpQuit_SheetDrug.Rows.Count - 1, (int)DrugColumns.ItemName].Text = "合计：";
                this.fpQuit_SheetDrug.Cells[this.fpQuit_SheetDrug.Rows.Count - 1, (int)DrugColumns.Cost].Text = return_DrugCost.ToString( );
            }
            if (this.fpQuit_SheetUndrug.Rows.Count != 0 && isPharmarcy == false)
            {
                this.fpQuit_SheetUndrug.Rows.Add(this.fpQuit_SheetUndrug.Rows.Count, 1);
                this.fpQuit_SheetUndrug.Cells[this.fpQuit_SheetUndrug.Rows.Count - 1, (int)UndrugColumns.FeeName].Text = "合计：";
                this.fpQuit_SheetUndrug.Cells[this.fpQuit_SheetUndrug.Rows.Count - 1, (int)UndrugColumns.Cost].Text = return_UndrugCost.ToString( );
            }
        }   

        /// <summary>
        /// 读取未退费信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Retrive(bool isRetrieveRetrunApply) 
        {
            if (this.patientInfo == null) 
            {
                MessageBox.Show(Language.Msg("请输入患者基本信息!"));

                return -1;
            }

            DateTime beginTime = this.dtpBeginTime.Value;
            DateTime endTime = this.dtpEndTime.Value;

            //根据窗口可操作的项目类别,读取未退费的项目信息
            switch (this.itemType) 
            {
                case ItemTypes.Pharmarcy:
                    //this.RetriveDrug(beginTime, endTime);
                    //if (isRetrieveRetrunApply)
                    //{
                        this.RetrieveReturnApply(true);
                    //}
                    
                    break;

                case ItemTypes.Undrug:
                    //this.RetriveUnrug(beginTime, endTime);
                    //if (isRetrieveRetrunApply)
                    //{
                        this.RetrieveReturnApply(false);
                    //}
                    
                    break;

                case ItemTypes.All:
                    //this.RetriveDrug(beginTime, endTime);
                    //this.RetriveUnrug(beginTime, endTime);
                    //if (isRetrieveRetrunApply)
                    //{
                        this.RetrieveReturnApply(true);
                        this.RetrieveReturnApply(false);
                    //}

                    break;
            }

            //this.fpUnQuit_SheetDrug.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            //this.fpUnQuit_SheetUndrug.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

            return 1;
        }


        /// <summary>
        /// 查找是否存在已退项目
        /// </summary>
        /// <param name="feeItemList">费用基本信息实体</param>
        /// <returns>成功 已经存在费用的index, 没有找到 -1</returns>
        protected virtual int FindQuitItem(FeeItemList feeItemList) 
        {
            //如果是药品,在已退药品页查找本次已经退过的项目
            //if (feeItemList.Item.IsPharmacy)
            if(feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                for (int i = 0; i < this.fpQuit_SheetDrug.RowCount; i++)
                {
                    if (this.fpQuit_SheetDrug.Rows[i].Tag == null)
                    {
                        continue;
                    }
                    if (this.fpQuit_SheetDrug.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList temp = this.fpQuit_SheetDrug.Rows[i].Tag as FeeItemList;

                        if (temp.RecipeNO == feeItemList.RecipeNO && temp.SequenceNO == feeItemList.SequenceNO)
                        {
                            return i;
                        }
                    }
                }
            }
            else //如果是非药品,在已退非药品页查找本次已经退过的项目
            {
                for (int i = 0; i < this.fpQuit_SheetUndrug.RowCount; i++)
                {
                    if (this.fpQuit_SheetUndrug.Rows[i].Tag == null)
                    {
                        continue;
                    }
                    if (this.fpQuit_SheetUndrug.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList temp = this.fpQuit_SheetUndrug.Rows[i].Tag as FeeItemList;

                        if (temp.RecipeNO == feeItemList.RecipeNO && temp.SequenceNO == feeItemList.SequenceNO)
                        {
                            return i;
                        }
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 查找未退项目
        /// </summary>
        /// <param name="feeItemList">项目信息实体</param>
        /// <returns>成功 当前行 失败 null</returns>
        protected virtual DataRow FindUnquitItem(FeeItemList feeItemList) 
        {
            DataRow rowFind = null;

            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                rowFind = dtDrug.Rows.Find(new object[] { feeItemList.RecipeNO, feeItemList.SequenceNO });
            }
            else 
            {
                rowFind = dtUndrug.Rows.Find(new object[] { feeItemList.RecipeNO, feeItemList.SequenceNO });
            }

            return rowFind;
        }

        /// <summary>
        /// 添加一条新退项目
        /// </summary>
        /// <param name="feeItemList">项目信息实体</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SetNewQuitItem(FeeItemList feeItemList) 
        {
            //药品
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                this.fpQuit_SheetDrug.Rows.Add(this.fpQuit_SheetDrug.RowCount, 1);

                int index = this.fpQuit_SheetDrug.RowCount - 1;

                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.ItemName, feeItemList.Item.Name);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Specs, feeItemList.Item.Specs);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Price, feeItemList.Item.Price);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Qty, feeItemList.NoBackQty);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Unit, feeItemList.Item.PriceUnit);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * feeItemList.NoBackQty / feeItemList.Item.PackQty, 2));
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.FeeDate, feeItemList.FeeOper.OperTime);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsConfirm, feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged ? true:false);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsApply, false);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.RecipeNO, feeItemList.RecipeNO);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.SequuenceNO, feeItemList.SequenceNO.ToString());
                //赋给作废处方号
                feeItemList.CancelRecipeNO = feeItemList.RecipeNO;
                //赋给作废内部处方流水号
                feeItemList.CancelSequenceNO = feeItemList.SequenceNO;
                this.fpQuit_SheetDrug.Rows[index].Tag = feeItemList;

            }
            else 
            {
                this.fpQuit_SheetUndrug.Rows.Add(this.fpQuit_SheetUndrug.RowCount, 1);

                int index = this.fpQuit_SheetUndrug.RowCount - 1;

                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ItemName, feeItemList.Item.Name);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName,this.inpatientManager.GetMinFeeNameByCode( feeItemList.Item.MinFee.ID));
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Price, feeItemList.Item.Price);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Qty, feeItemList.NoBackQty);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Unit, feeItemList.Item.PriceUnit);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * feeItemList.NoBackQty / feeItemList.Item.PackQty, 2));
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsConfirm, feeItemList.IsConfirmed);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsApply, false);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.RecipeNO, feeItemList.RecipeNO);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.SequuenceNO, feeItemList.SequenceNO);
                Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

                deptInfo = this.managerIntegrate.GetDepartment(feeItemList.ExecOper.Dept.ID);
                if (deptInfo == null)
                {
                    deptInfo = new Neusoft.HISFC.Models.Base.Department();
                    deptInfo.Name = feeItemList.ExecOper.Dept.ID;
                }
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ExecDept, deptInfo.Name);
                //赋给作废处方号
                feeItemList.CancelRecipeNO = feeItemList.RecipeNO;
                //赋给作废内部处方流水号
                feeItemList.CancelSequenceNO = feeItemList.SequenceNO;
                this.fpQuit_SheetUndrug.Rows[index].Tag = feeItemList;
            }

            return 1;
        }

        /// <summary>
        /// 添加一条已经存在得退费信息
        /// </summary>
        /// <param name="feeItemList">费用信息实体</param>
        /// <param name="index">找到得已经存在的退费记录索引</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SetExistQuitItem(FeeItemList feeItemList, int index) 
        {
            //药品
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                FeeItemList temp = this.fpQuit_SheetDrug.Rows[index].Tag as FeeItemList;

                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Qty, feeItemList.NoBackQty + temp.NoBackQty);

                temp.NoBackQty += feeItemList.NoBackQty;

                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * temp.NoBackQty / feeItemList.Item.PackQty, 2));
            }
            else 
            {
                FeeItemList temp = this.fpQuit_SheetUndrug.Rows[index].Tag as FeeItemList;

                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Qty, feeItemList.NoBackQty + temp.NoBackQty);

                temp.NoBackQty += feeItemList.NoBackQty;

                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * temp.NoBackQty, 2));
            }

            return 1;
        }

        /// <summary>
        /// 给已退列表赋值
        /// </summary>
        /// <param name="feeItemList">费用项目信息</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SetQuitItem(FeeItemList feeItemList) 
        {
            int findIndex = -1;

            findIndex = this.FindQuitItem(feeItemList);

            //没有找到,说明没有退费操作
            if (findIndex == -1)
            {
                this.SetNewQuitItem(feeItemList.Clone());
            }
            else//已经存在了退费信息 
            {
                this.SetExistQuitItem(feeItemList.Clone(), findIndex);
            }

            return 1;
        } 

        

        /// <summary>
        /// 取消退费操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelQuitOperation() 
        {
            if (this.fpQuit.ActiveSheet.RowCount == 0) 
            {
                return -1;
            }

            int index = this.fpQuit.ActiveSheet.ActiveRowIndex;

            object quitItem = this.fpQuit.ActiveSheet.Rows[index].Tag;
            if (quitItem == null)
            {
                return -1;
            }
            //如果是退费项目(不是申请)
            if (quitItem.GetType() == typeof(FeeItemList))
            {
                FeeItemList feeItemList = this.fpQuit.ActiveSheet.Rows[index].Tag as FeeItemList;

                DataRow rowFind = this.FindUnquitItem(feeItemList);
                if (rowFind == null)
                {
                    MessageBox.Show("查找未退项目出错");

                    return -1;
                }

                rowFind["可退数量"] = NConvert.ToDecimal(rowFind["可退数量"]) + feeItemList.NoBackQty;
                rowFind["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(rowFind["可退数量"]) / feeItemList.Item.PackQty;
                
                feeItemList.NoBackQty = 0;
                this.fpQuit.ActiveSheet.SetValue(index, (int)DrugColumns.Qty, 0);
                this.fpQuit.ActiveSheet.SetValue(index, (int)DrugColumns.Cost, 0);
            }

            return 1;
        }

        /// <summary>
        /// 验证合法性
        /// </summary>
        /// <returns>成功 True 失败 false</returns>
        protected virtual bool IsValid() 
        {
            return true;
        }

        /// <summary>
        /// 更新项目的可退数量
        /// </summary>
        /// <param name="feeItemList">费用基本信息实体</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        private int UpdateNoBackQty(FeeItemList feeItemList, ref string errMsg)
        {
            int returnValue = 0;
            
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                //更新费用明细表中的可退数量
                returnValue = this.inpatientManager.UpdateNoBackQtyForDrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState);
                if (returnValue == -1)
                {
                    errMsg = Language.Msg("更新药品可退数量出错!") + this.inpatientManager.Err;
                    
                    return -1;
                }
            }
            else
            {
                //更新费用明细表中的可退数量
                returnValue = this.inpatientManager.UpdateNoBackQtyForUndrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState);
                if (returnValue == -1)
                {
                    errMsg = Language.Msg("更新非药品可退数量出错!") + this.inpatientManager.Err;

                    return -1;
                }
            }
            //对退药并发进行判断
            if (returnValue == 0)
            {
                errMsg = Language.Msg("项目“") + feeItemList.Item.Name + Language.Msg("”已经被退费，不能重复退费。");

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 获得退费申请号
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功  获得退费申请号 失败 null</returns>
        private string GetApplyBillCode(ref string errMsg)
        {
            string applyBillCode = string.Empty;

            applyBillCode = this.inpatientManager.GetSequence("Fee.ApplyReturn.GetBillCode");
            if (applyBillCode == null || applyBillCode == string.Empty)
            {
                errMsg = Language.Msg("获取退费申请方号出错!");

                return null;
            }

            return applyBillCode;
        }

        /// <summary>
        /// 退费操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SaveFee() 
        {
            List<FeeItemList> feeItemLists = this.GetConfirmItem();
            List<Neusoft.HISFC.Models.Fee.ReturnApply> returnApplys = this.GetRetrunApplyItem();

            if (feeItemLists.Count <= 0 && returnApplys.Count <= 0) 
            {
                MessageBox.Show(Language.Msg("没有费用可退!"));

                return -1;
            }

            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (returnApplys.Count > 0)
            {
                this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }

            foreach (FeeItemList feeItemList in feeItemLists) 
            {
                //if (feeItemList.Item.IsPharmacy) 
                //{
                //    if (this.phamarcyIntegrate.CancelApplyOut(feeItemList.Clone()) == -1) 
                //    {
                //        this.feeIntegrate.Rollback();

                //        MessageBox.Show(Language.Msg("退费失败!") + this.phamarcyIntegrate.Err);

                //        return -1;
                //    }
                //}
                
                if (this.feeIntegrate.QuitItem(this.patientInfo, feeItemList.Clone()) == -1) 
                {
                    this.feeIntegrate.Rollback();
                    
                    MessageBox.Show(Language.Msg("退费失败!") + this.feeIntegrate.Err);
 
                    return -1;
                }
            }


            foreach (Neusoft.HISFC.Models.Fee.ReturnApply returnApply in returnApplys) 
            {
                
                returnApply.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                returnApply.ConfirmOper.ID = this.returnApplyManager.Operator.ID;
                returnApply.ConfirmOper.OperTime = this.returnApplyManager.GetDateTimeFromSysDateTime();

                

                if (this.returnApplyManager.ConfirmApply(returnApply) <= 0) 
                {
                    this.feeIntegrate.Rollback();

                    MessageBox.Show(Language.Msg("核准退费申请失败!数据可能有变化.") + this.returnApplyManager.Err);

                    return -1;
                }
                if (returnApply.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    //更新物资退费申请表
                    if (this.returnApplyManager.UpdateReturnApplyState(returnApply.ApplyMateList, Neusoft.HISFC.Models.Base.CancelTypes.Valid) <= 0)
                    {
                        this.feeIntegrate.Rollback();

                        MessageBox.Show(Language.Msg("更新物资信息失败！") + this.returnApplyManager.Err);

                        return -1;
                    }
                }
                


                FeeItemList feeTemp = returnApply as FeeItemList;

                //feeTemp.MateList = GetOutPutByApplyIte(returnApply);

                if (this.feeIntegrate.QuitItem(this.patientInfo, feeTemp.Clone()) == -1)
                {
                    this.feeIntegrate.Rollback();

                    MessageBox.Show(Language.Msg("退费失败!") + this.feeIntegrate.Err);

                    return -1;
                }
            }
                

            this.feeIntegrate.Commit();

            MessageBox.Show("退费成功!");

            this.Clear();

            return 1;
        }


        /// <summary>
        /// 获得退费的项目
        /// </summary>
        /// <returns>成功 已退项目集合 失败 null</returns>
        private List<FeeItemList> GetConfirmItem()
        {
            List<FeeItemList> feeItemLists = new List<FeeItemList>();

            for (int j = 0; j < this.fpQuit.Sheets.Count; j++)
            {
                for (int i = 0; i < this.fpQuit.Sheets[j].RowCount; i++)
                {
                    if (this.fpQuit.Sheets[j].Rows[i].Tag != null && this.fpQuit.Sheets[j].Rows[i].Tag.GetType() == typeof(FeeItemList))
                    {
                        if (this.fpQuit.Sheets[j].Cells[i, 0].Text.ToLower() == "false")
                        {
                            continue;
                        }

                        FeeItemList feeItemList = this.fpQuit.Sheets[j].Rows[i].Tag as FeeItemList;
                        //if (feeItemList.NoBackQty > 0)
                        if (feeItemList.Item.Qty > 0)
                        {
                            //feeItemList.Item.Qty = feeItemList.NoBackQty;
                            //feeItemList.NoBackQty = 0;
                            feeItemList.FT.TotCost = feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty;
                            feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                            feeItemList.IsNeedUpdateNoBackQty = true;

                            feeItemLists.Add(feeItemList);
                        }
                    }
                }
            }

            return feeItemLists;
        }

        /// <summary>
        /// 获得退费的项目
        /// </summary>
        /// <returns>成功 已退项目集合 失败 null</returns>
        private List<Neusoft.HISFC.Models.Fee.ReturnApply> GetRetrunApplyItem()
        {
            List<Neusoft.HISFC.Models.Fee.ReturnApply> feeItemLists = new List<Neusoft.HISFC.Models.Fee.ReturnApply>();

            for (int j = 0; j < this.fpQuit.Sheets.Count; j++)
            {
                for (int i = 0; i < this.fpQuit.Sheets[j].RowCount; i++)
                {
                    if (this.fpQuit.Sheets[j].Rows[i].Tag != null && this.fpQuit.Sheets[j].Rows[i].Tag.GetType() == typeof(Neusoft.HISFC.Models.Fee.ReturnApply))
                    {
                        if (this.fpQuit.Sheets[j].Cells[i, 0].Text.ToLower() == "false") continue;
                        Neusoft.HISFC.Models.Fee.ReturnApply feeItemList = this.fpQuit.Sheets[j].Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;

                        //FeeItemList feeTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.IsPharmacy);
                        FeeItemList feeTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.ItemType);
                        if (feeTemp == null) 
                        {
                            MessageBox.Show(Language.Msg("查找项目出错!") + feeItemList.Item.Name + this.inpatientManager.Err);
                            continue;
                        }
                        feeItemList.Item.MinFee = feeTemp.Item.MinFee;
                        feeItemList.NoBackQty = 0;
                        feeItemList.FT.TotCost = feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty;
                        feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                        feeItemList.IsNeedUpdateNoBackQty = false;
                        //开方医生插入的不对{BEFC715C-80A5-43fb-8FEA-A48FF419CDD4}
                        //feeItemList.RecipeOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.RecipeOper.ID = feeTemp.RecipeOper.ID;
                        //{B13D20B4-3004-495a-AF2E-E0FF28A6E29D}
                        //feeItemList.RecipeOper.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)this.inpatientManager.Operator).Dept.ID;
                        feeItemList.RecipeOper.Dept.ID = feeTemp.RecipeOper.Dept.ID; //((Neusoft.HISFC.Models.Base.Employee)this.inpatientManager.Operator).Dept.ID;
                        feeItemList.CancelOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.ChargeOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.FeeOper.ID = this.inpatientManager.Operator.ID;
                        //物资出库流水号
                        feeItemList.UpdateSequence = feeTemp.UpdateSequence;
                        feeItemList.ExtCode = feeTemp.ExtCode;
                        feeItemLists.Add(feeItemList);
                        
                    }
                }
            }

            return feeItemLists;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public virtual int Save() 
        {
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty) 
            {
                MessageBox.Show(Language.Msg("请输入患者!"));

                return -1;
            }

            //switch (this.operation) 
            //{
            //    case Operations.QuitFee:
            //    case Operations.Confirm:
            return this.SaveFee();

            //    case Operations.Apply:

                    //return this.SaveApply();
            //}
            
            //return 1;
        }

        /// <summary>
        /// 清空函数
        /// </summary>
        public virtual void Clear() 
        {
            this.ClearItemList();
            this.txtName.Text = string.Empty;
            this.txtPact.Text = string.Empty;
            this.txtDept.Text = string.Empty;
            this.txtFilter.Text = string.Empty;
            this.txtBed.Text = string.Empty;
            this.ucQueryPatientInfo.Text = string.Empty;
            this.ucQueryPatientInfo.txtInputCode.SelectAll();
            this.ucQueryPatientInfo.txtInputCode.Focus();
            this.patientInfo = null;
        }

        /// <summary>
        /// 清空显示列表
        /// </summary>
        public virtual void ClearItemList() 
        {
            this.dtDrug.Clear();
            this.dtUndrug.Clear();
            this.fpQuit_SheetDrug.RowCount = 0;
            this.fpQuit_SheetUndrug.RowCount = 0;
        }

        #endregion

        #region 控件操作

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("取消", "取消单条已退明细", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("列设置", "设置显示列", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text) 
            {
                case "清屏":
                    this.Clear();
                    break;
                case "取消":
                    this.CancelQuitOperation();
                    break;
                case "列设置":
                    //this.SetColumns();
                    break;
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns>成功 1 失败 -1</returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            
            return base.OnSave(sender, neuObject);
        }
        
        /// <summary>
        /// 读取患者基本信息
        /// </summary>
        private void ucQueryInpatientNO_myEvent()
        {
            if (this.ucQueryPatientInfo.InpatientNo == null || this.ucQueryPatientInfo.InpatientNo == string.Empty)
            {
                MessageBox.Show(Language.Msg("该患者不存在!请验证后输入"));

                return;
            }

            PatientInfo patientTemp = this.radtIntegrate.GetPatientInfomation(this.ucQueryPatientInfo.InpatientNo);
            if (patientTemp == null || patientTemp.ID == null || patientTemp.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("该患者不存在!请验证后输入"));

                return;
            }

            this.patientInfo = patientTemp;

            this.SetPatientInfomation();
        }

        /// <summary>
        /// Uc的Loade事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ucQuitFee_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    this.Init();
                }
                catch { }
            }
        }

        /// <summary>
        /// 读取未退费的药品,非药品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            this.ClearItemList();
            
            this.Retrive(true);

            this.txtFilter.Focus();
        }


        private void fpQuit_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.CancelQuitOperation();
        }

        private void dtpBeginTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpEndTime.Focus();
            }
        }

        private void dtpEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRead.Focus();
            }
        }

        private void btnRead_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                this.txtFilter.Focus();
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 药品退费列信息
        /// </summary>
        protected enum DrugColumns
        {
            //是否退费
            ItemState=0,
            /// <summary>
            /// 药品名称
            /// </summary>
            ItemName = 1,

            /// <summary>
            /// 规格
            /// </summary>
            Specs,

            /// <summary>
            /// 单价
            /// </summary>
            Price,

            /// <summary>
            /// 退费数量
            /// </summary>
            Qty,

            /// <summary>
            /// 单位
            /// </summary>
            Unit,

            /// <summary>
            /// 金额
            /// </summary>
            Cost,

            /// <summary>
            /// 计费日期
            /// </summary>
            FeeDate,

            /// <summary>
            /// 是否发药
            /// </summary>
            IsConfirm,

            /// <summary>
            /// 是否退费申请
            /// </summary>
            IsApply,
            /// <summary>
            /// 处方流水号
            /// </summary>
            RecipeNO,
            /// <summary>
            /// 处方内部流水号
            /// </summary>
            SequuenceNO
        }

        /// <summary>
        /// 药品退费列信息
        /// </summary>
        protected enum UndrugColumns
        {
            /// <summary>
            /// 是否退费
            /// </summary>
            ItemState=0,

            /// <summary>
            /// 药品名称
            /// </summary>
            ItemName = 1,

            /// <summary>
            /// 费用名称
            /// </summary>
            FeeName,

            /// <summary>
            /// 单价
            /// </summary>
            Price,

            /// <summary>
            /// 退费数量
            /// </summary>
            Qty,

            /// <summary>
            /// 单位
            /// </summary>
            Unit,

            /// <summary>
            /// 金额
            /// </summary>
            Cost,

            /// <summary>
            /// 执行科室
            /// </summary>
            ExecDept,

            /// <summary>
            /// 是否发药
            /// </summary>
            IsConfirm,

            /// <summary>
            /// 是否退费申请
            /// </summary>
            IsApply,
            /// <summary>
            /// 处方流水号
            /// </summary>
            RecipeNO,
            /// <summary>
            /// 处方内部流水号
            /// </summary>
            SequuenceNO

        }

        ///// <summary>
        ///// 退费功能
        ///// </summary>
        //public enum Operations 
        //{
        //    /// <summary>
        //    /// 直接退费
        //    /// </summary>
        //    QuitFee = 0,

        //    /// <summary>
        //    /// 退费申请
        //    /// </summary>
        //    Apply,
            
        //    /// <summary>
        //    /// 退费确认
        //    /// </summary>
        //    Confirm,
        //}

        /// <summary>
        /// 可操作项目类型
        /// </summary>
        public enum ItemTypes 
        { 
            /// <summary>
            /// 所有
            /// </summary>
            All = 0,
            
            /// <summary>
            /// 药品
            /// </summary>
            Pharmarcy,

            /// <summary>
            /// 非药品
            /// </summary>
            Undrug
        }

        #endregion

        //复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        private void fpQuit_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (!this.isCombItemAllQuit) 
            {
                return;
            }

            if (this.fpQuit.ActiveSheet != this.fpQuit_SheetUndrug) 
            {
                return;
            }

            if (e.Column == 0) 
            {
                if (this.fpQuit_SheetUndrug.RowCount <= 0) 
                {
                    return;
                }

                bool isClicked = this.fpQuit_SheetUndrug.Cells[e.Row, 0].Text.ToUpper() == "TRUE" ? true : false;

                if(this.fpQuit_SheetUndrug.Rows[e.Row].Tag == null)
                {
                    return;
                }
                FeeItemList f = this.fpQuit_SheetUndrug.Rows[e.Row].Tag as FeeItemList;

                f = this.inpatientManager.GetItemListByRecipeNO(f.RecipeNO, f.SequenceNO, Neusoft.HISFC.Models.Base.EnumItemType.UnDrug);
                if (f == null) 
                {
                    MessageBox.Show("获得详细明细出错!" + this.inpatientManager.Err);

                    return;
                }


                if (!string.IsNullOrEmpty(f.Order.ID) && !string.IsNullOrEmpty(f.UndrugComb.ID)) //说明是复合项目
                {
                    for (int i = 0; i < this.fpQuit_SheetUndrug.RowCount; i++) 
                    {
                        if (this.fpQuit_SheetUndrug.Rows[i].Tag == null)
                        {
                            continue;
                        }

                        FeeItemList fCompare = this.fpQuit_SheetUndrug.Rows[i].Tag as FeeItemList;
                        fCompare = this.inpatientManager.GetItemListByRecipeNO(fCompare.RecipeNO, fCompare.SequenceNO, Neusoft.HISFC.Models.Base.EnumItemType.UnDrug);
                        if (fCompare == null)
                        {
                            MessageBox.Show("获得详细明细出错!" + this.inpatientManager.Err);

                            return;
                        }

                        if (f.Order.ID == fCompare.Order.ID && f.UndrugComb.ID == fCompare.UndrugComb.ID) 
                        {
                            this.fpQuit_SheetUndrug.Cells[i, 0].Value = isClicked;
                        }
                    }
                }

            }
        }//复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}结束

    }
}
