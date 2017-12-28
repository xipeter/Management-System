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
using Neusoft.HISFC.Models.Base;

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
    public partial class ucQuitFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
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
        public ucQuitFee()
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
        /// 未退药品的列设置路径
        /// </summary>
        protected string filePathUnQuitDrug = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QuitFeeUnQuitDrug.xml";

        /// <summary>
        /// 未退非药品的列设置路径
        /// </summary>
        protected string filePathUnQuitUndrug = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QuitFeeUnQuitUndrug.xml";

        /// <summary>
        /// 退费操作类型
        /// </summary>
        protected Operations operation;

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
        /// 是否可以更改退费数量
        /// </summary>
        protected bool isChangeItemQty = true;
        public bool isCanQuitOtherFee = true;
        /// <summary>
        /// 物资信息
        /// </summary>
        private DataTable dtMate = new DataTable();
        /// <summary>
        /// 物资收费
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Material.Material mateInteger = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();

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
        /// 退费操作类型
        /// </summary>
        [Category("控件设置"), Description("设置或者获得退费的操作类型")]
        public Operations Operation
        {
            set
            {
                this.operation = value;
            }
            get
            {
                return this.operation;
            }
        }

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

        [Category("控件设置"), Description("是否可以更改退费数量 True:可以 False:不可以")]
        public bool IsChangeItemQty
        {
            get
            {
                return isChangeItemQty;
            }
            set
            {
                isChangeItemQty = value;
                if (this.DesignMode)
                    return;
                if (!value)
                {
                    this.ckbAllQuit.Checked = true;
                    this.ckbAllQuit.Enabled = false;
                }
            }
        }
        [Category("控件设置"), Description("是否允许退其他科室费用 True:可以 False:不可以")]
        public bool IsCanQuitOtherDeptFee
        {
            get
            {
                return isCanQuitOtherFee;
            }
            set
            {
                isCanQuitOtherFee = value;
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 设置可操作的项目类别
        /// </summary>
        protected virtual void SetItemType()
        {
            switch (this.itemType)
            {
                case ItemTypes.Pharmarcy:
                    this.fpUnQuit_SheetDrug.Visible = true;
                    this.fpUnQuit_SheetUndrug.Visible = false;
                    this.fpQuit_SheetDrug.Visible = true;
                    this.fpQuit_SheetUndrug.Visible = false;
                    this.fpQuit.ActiveSheet = this.fpQuit_SheetDrug;
                    this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetDrug;

                    break;

                case ItemTypes.Undrug:
                    this.fpUnQuit_SheetDrug.Visible = false;
                    this.fpUnQuit_SheetUndrug.Visible = true;
                    this.fpQuit_SheetDrug.Visible = false;
                    this.fpQuit_SheetUndrug.Visible = true;
                    this.fpQuit.ActiveSheet = this.fpQuit_SheetUndrug;
                    this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetUndrug;

                    break;

                case ItemTypes.All:
                    this.fpUnQuit_SheetDrug.Visible = true;
                    this.fpUnQuit_SheetUndrug.Visible = true;
                    this.fpQuit_SheetDrug.Visible = true;
                    this.fpQuit_SheetUndrug.Visible = true;
                    this.fpQuit.ActiveSheet = this.fpQuit_SheetDrug;
                    this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetDrug;

                    break;
            }
        }

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

            this.InitFp();
            return 1;
        }

        /// <summary>
        /// 获得未退费的药品信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RetriveDrug(DateTime beginTime, DateTime endTime)
        {
            string flag = string.Empty;

            if (this.operation == Operations.QuitFee)
            {
                flag = "1";
            }
            //退费申请时显示的药品是
            else if (this.operation == Operations.Apply)
            {
                flag = "1,2";
            }
            else
            {
                flag = "1,2";
            }

            ArrayList drugList = this.inpatientManager.QueryMedItemListsCanQuit(this.patientInfo.ID, beginTime, endTime, flag);
            if (drugList == null)
            {
                MessageBox.Show(Language.Msg("获得药品列表出错!") + this.inpatientManager.Err);

                return -1;
            }

            this.SetDrugList(drugList);

            return 1;
        }

        /// <summary>
        /// 设置药品列表
        /// </summary>
        /// <param name="drugList"></param>
        protected virtual void SetDrugList(ArrayList drugList)
        {
            foreach (FeeItemList feeItemList in drugList)
            {
                DataRow row = this.dtDrug.NewRow();

                //读取药品基本信息,这里暂时为了获得拼音码
                Neusoft.HISFC.Models.Base.Item phamarcyItem = this.phamarcyIntegrate.GetItem(feeItemList.Item.ID);
                if (phamarcyItem == null)
                {
                    phamarcyItem = new Neusoft.HISFC.Models.Base.Item();

                }

                if (phamarcyItem.PackQty == 0)
                {
                    phamarcyItem.PackQty = 1;
                }

                //feeItemList.Item.IsPharmacy = true;
                feeItemList.Item.ItemType = EnumItemType.Drug;
                row["药品名称"] = feeItemList.Item.Name;
                row["规格"] = feeItemList.Item.Specs;
                row["费用名称"] = this.objectHelperMinFee.GetName(feeItemList.Item.MinFee.ID);
                row["价格"] = feeItemList.Item.Price;
                row["可退数量"] = feeItemList.NoBackQty;
                row["单位"] = feeItemList.Item.PriceUnit;
                row["金额"] = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price * feeItemList.NoBackQty / phamarcyItem.PackQty, 2);
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
                row["是否发药"] = feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged ? '是' : '否';

                row["编码"] = feeItemList.Item.ID;
                row["医嘱号"] = feeItemList.Order.ID;
                row["医嘱执行号"] = feeItemList.ExecOrder.ID;
                row["处方号"] = feeItemList.RecipeNO;
                row["处方流水号"] = feeItemList.SequenceNO;

                row["拼音码"] = phamarcyItem.SpellCode;
                row["开方科室"] = feeItemList.FeeOper.Dept.ID;

                this.dtDrug.Rows.Add(row);
            }
        }

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
            dtMate.Rows.Clear();
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
                feeItemList.Item.ItemType = EnumItemType.Drug;
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
                row["开方科室"] = feeItemList.FeeOper.Dept.ID;
                row["出库流水号"] = feeItemList.UpdateSequence.ToString();
                row["标识"] = ((int)feeItemList.Item.ItemType).ToString();
                this.dtUndrug.Rows.Add(row);
                //根据非药品获取对照的物资信息
                GetMateData(feeItemList);
            }
            SetUndragFp(string.Empty);
        }

        private void SetUndragFp(string strVal)
        {
            string filter = "项目名称 like '" + strVal + "%'" + " OR " + "拼音码 like '" + strVal + "%'";
            DataRow[] vdr = dtUndrug.Select(filter);
            if (vdr == null || vdr.Length == 0)
                return;
            foreach (DataRow dr in vdr)
            {
                SetUndrugRow(dr);
            }
        }

        /// <summary>
        /// 根据非药品获取对照的物资信息
        /// </summary>
        /// <param name="feeItem">非药品收费信息</param>
        private void GetMateData(FeeItemList feeItem)
        {
            string outNo = feeItem.UpdateSequence.ToString();
            List<HISFC.Models.FeeStuff.Output> list = mateInteger.QueryOutput(outNo);
            DataRow row = null;
            foreach (HISFC.Models.FeeStuff.Output item in list)
            {
                row = dtMate.NewRow();
                row["项目名称"] = item.StoreBase.Item.Name;
                row["费用名称"] = this.objectHelperMinFee.GetName(item.StoreBase.Item.MinFee.ID);
                row["规格"] = item.StoreBase.Item.Specs;
                row["价格"] = item.StoreBase.Item.Price;
                row["可退数量"] = item.StoreBase.Quantity - item.ReturnApplyNum - item.StoreBase.Returns;
                row["单位"] = item.StoreBase.Item.PriceUnit;
                row["金额"] = NConvert.ToDecimal(row["价格"]) * NConvert.ToInt32(row["可退数量"]);
                row["出库流水号"] = item.ID;
                row["编码"] = item.StoreBase.Item.ID;
                row["库存序号"] = item.StoreBase.StockNO;

                dtMate.Rows.Add(row);
            }
        }

        private void SetUndrugRow(DataRow dr)
        {
            this.fpUnQuit_SheetUndrug.Rows.Add(this.fpUnQuit_SheetUndrug.Rows.Count, 1);
            int rowIndex = this.fpUnQuit_SheetUndrug.Rows.Count - 1;
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 0].Text = dr["项目名称"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 1].Text = dr["费用名称"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 2].Text = dr["价格"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 3].Text = dr["可退数量"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 4].Text = dr["单位"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 5].Text = dr["金额"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 6].Text = dr["执行科室"].ToString();

            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 7].Text = dr["开方医师"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 8].Text = dr["记帐日期"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 9].Text = dr["是否执行"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 10].Text = dr["编码"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 11].Text = dr["医嘱号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 12].Text = dr["医嘱执行号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 13].Text = dr["处方号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 14].Text = dr["处方流水号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 15].Text = dr["拼音码"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 16].Text = dr["开方科室"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 17].Text = dr["出库流水号"].ToString();
            //显示物资数据
            SetMateRow(dr, rowIndex);
        }



        /// <summary>
        /// 显示物资数据
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="rowIndex"></param>
        private void SetMateRow(DataRow dr, int rowIndex)
        {

            int index = 0;
            //string itemCode = dr["编码"].ToString();
            string outNo = dr["出库流水号"].ToString();
            //string strfilter = "编码 ='" + itemCode + "' And " + "出库流水号 ='" + outNo + "'";
            string strfilter = "出库流水号 ='" + outNo + "'";
            DataRow[] vdr = dtMate.Select(strfilter);
            if (vdr == null || vdr.Length == 0)
                return;
            if (vdr.Length == 1)
                return;
            fpUnQuit_SheetUndrug.RowHeader.Cells[rowIndex, 0].Text = "+";
            fpUnQuit_SheetUndrug.RowHeader.Cells[rowIndex, 0].BackColor = Color.YellowGreen;
            foreach (DataRow row in vdr)
            {
                fpUnQuit_SheetUndrug.Rows.Add(fpUnQuit_SheetUndrug.Rows.Count, 1);
                index = fpUnQuit_SheetUndrug.Rows.Count - 1;
                this.fpUnQuit_SheetUndrug.Cells[index, 0].Text = row["项目名称"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpUnQuit_SheetUndrug.Cells[index, 1].Text = row["费用名称"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 2].Text = row["价格"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 3].Text = row["可退数量"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 4].Text = row["单位"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 5].Text = row["金额"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 10].Text = row["编码"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 17].Text = row["出库流水号"].ToString();
                this.fpUnQuit_SheetUndrug.Cells[index, 18].Text = row["库存序号"].ToString();
                this.fpUnQuit_SheetUndrug.RowHeader.Cells[index, 0].Text = ".";
                this.fpUnQuit_SheetUndrug.RowHeader.Cells[index, 0].BackColor = System.Drawing.Color.SkyBlue;
                this.fpUnQuit_SheetUndrug.Rows[index].Visible = false;
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

            foreach (Neusoft.HISFC.Models.Fee.ReturnApply retrunApply in returnApplys)
            {
                //药品
                //if (retrunApply.Item.IsPharmacy)
                if (retrunApply.Item.ItemType == EnumItemType.Drug)
                {
                    this.fpQuit_SheetDrug.Rows.Add(this.fpQuit_SheetDrug.RowCount, 1);

                    int index = this.fpQuit_SheetDrug.RowCount - 1;

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
                }
                else
                {
                    this.fpQuit_SheetUndrug.Rows.Add(this.fpQuit_SheetUndrug.RowCount, 1);

                    int index = this.fpQuit_SheetUndrug.RowCount - 1;

                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ItemName, retrunApply.Item.Name);


                    Neusoft.HISFC.Models.Fee.Item.Undrug undrugInfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    Neusoft.HISFC.BizLogic.Fee.Item feeItemManager = new Neusoft.HISFC.BizLogic.Fee.Item();
                    undrugInfo = feeItemManager.GetUndrugByCode(retrunApply.Item.ID);
                    this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName, this.inpatientManager.GetMinFeeNameByCode(undrugInfo.MinFee.ID));

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
                }
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
                    this.RetriveDrug(beginTime, endTime);
                    if (isRetrieveRetrunApply)
                    {
                        this.RetrieveReturnApply(true);
                    }

                    break;

                case ItemTypes.Undrug:
                    this.RetriveUnrug(beginTime, endTime);
                    if (isRetrieveRetrunApply)
                    {
                        this.RetrieveReturnApply(false);
                    }

                    break;

                case ItemTypes.All:
                    this.RetriveDrug(beginTime, endTime);
                    this.RetriveUnrug(beginTime, endTime);
                    if (isRetrieveRetrunApply)
                    {
                        this.RetrieveReturnApply(true);
                        this.RetrieveReturnApply(false);
                    }

                    break;
            }

            this.fpUnQuit_SheetDrug.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpUnQuit_SheetUndrug.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

            return 1;
        }

        /// <summary>
        /// 初始化Fp列和Sheet显示顺序等信息,Sheet的数据绑定
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitFp()
        {
            this.fpQuit.ActiveSheet = this.fpQuit_SheetDrug;
            this.fpQuit_SheetDrug.Columns[(int)DrugColumns.FeeDate].Visible = false;

            this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetDrug;

            #region 初始化药品信息

            this.dtDrug.Reset();

            //如果存在本地药品的列配置文件,直接读取配置文件生成DataTable,并已处方号和处方流水号作为主键
            //主键的作用主要是为了以后的查找对应项目用
            if (System.IO.File.Exists(this.filePathUnQuitDrug))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePathUnQuitDrug, dtDrug, ref dvDrug, this.fpUnQuit_SheetDrug);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);

                dtDrug.PrimaryKey = new DataColumn[] { dtDrug.Columns["处方号"], dtDrug.Columns["处方流水号"] };
            }
            else//如果没有找到配置文件,已默认的列顺序和名称生成DataTable,主键同样为处方号和处方流水号
            {
                this.dtDrug.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("药品名称", typeof(string)),
                    new DataColumn("规格", typeof(string)),
                    new DataColumn("费用名称", typeof(string)),
                    new DataColumn("价格", typeof(decimal)),
                    new DataColumn("可退数量", typeof(decimal)),
                    new DataColumn("单位", typeof(string)),
                    new DataColumn("金额", typeof(decimal)),
                    new DataColumn("执行科室", typeof(string)),
                    new DataColumn("开方医师", typeof(string)),
                    new DataColumn("记帐日期", typeof(DateTime)),
                    new DataColumn("是否发药", typeof(string)),
                    new DataColumn("编码", typeof(string)),
                    new DataColumn("医嘱号", typeof(string)),
                    new DataColumn("医嘱执行号", typeof(string)),
                    new DataColumn("处方号", typeof(string)),
                    new DataColumn("处方流水号", typeof(string)),
                    new DataColumn("包装数", typeof(decimal)),
                    new DataColumn("是否包装单位", typeof(string)),
                    new DataColumn("拼音码", typeof(string)),
                    new DataColumn("开方科室")
                 });

                dtDrug.PrimaryKey = new DataColumn[] { dtDrug.Columns["处方号"], dtDrug.Columns["处方流水号"] };

                dvDrug = new DataView(dtDrug);

                //绑定到对应的Farpoint
                this.fpUnQuit_SheetDrug.DataSource = dvDrug;

                //保存当前的列顺序,名称等信息到XML
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);
            }

            #endregion

            #region 初始化未退非药品信息

            dtUndrug.Reset();

            //如果存在本地非药品的列配置文件,直接读取配置文件生成DataTable,并已处方号和处方流水号作为主键
            //主键的作用主要是为了以后的查找对应项目用
            if (System.IO.File.Exists(this.filePathUnQuitUndrug))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePathUnQuitUndrug, dtUndrug, ref dvUndrug, this.fpUnQuit_SheetUndrug);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);

                dtUndrug.PrimaryKey = new DataColumn[] { dtUndrug.Columns["处方号"], dtUndrug.Columns["处方流水号"] };
                this.fpUnQuit_SheetUndrug.DataSource = null;
            }
            else
            {
                this.dtUndrug.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("项目名称", typeof(string)),
                    new DataColumn("费用名称", typeof(string)),
                    new DataColumn("价格", typeof(decimal)),
                    new DataColumn("可退数量", typeof(decimal)),
                    new DataColumn("单位", typeof(string)),
                    new DataColumn("金额", typeof(decimal)),
                    new DataColumn("执行科室", typeof(string)),
                    new DataColumn("开方医师", typeof(string)),
                    new DataColumn("记帐日期", typeof(DateTime)),
                    new DataColumn("是否执行", typeof(string)),
                    new DataColumn("编码", typeof(string)),
                    new DataColumn("医嘱号", typeof(string)),
                    new DataColumn("医嘱执行号", typeof(string)),
                    new DataColumn("处方号", typeof(string)),
                    new DataColumn("处方流水号", typeof(string)),
                    new DataColumn("拼音码", typeof(string)),
                    new DataColumn("开方科室",typeof(string)),
                    new DataColumn("出库流水号",typeof(string)),
                    new DataColumn("库存序号",typeof(string)),
                    //非0药品 2物质
                    new DataColumn("标识",typeof(string))
                 });

                dtUndrug.PrimaryKey = new DataColumn[] { dtUndrug.Columns["处方号"], dtUndrug.Columns["处方流水号"] };
                dvUndrug = new DataView(dtUndrug);

                //绑定到对应的Farpoint
                //this.fpUnQuit_SheetUndrug.DataSource = dvUndrug;

                ////保存当前的列顺序,名称等信息到XML
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
            }
            this.dtMate.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("项目名称", typeof(string)),
                    new DataColumn("费用名称", typeof(string)),
                    new DataColumn("规格", typeof(string)),
                    new DataColumn("价格", typeof(decimal)),
                    new DataColumn("可退数量", typeof(decimal)),
                    new DataColumn("单位", typeof(string)),
                    new DataColumn("金额", typeof(decimal)),
                    new DataColumn("编码", typeof(string)),
                    new DataColumn("处方号", typeof(string)),
                    new DataColumn("处方流水号", typeof(string)),
                    new DataColumn("出库流水号",typeof(string)),
                    new DataColumn("库存序号",typeof(string))
                });
            dtMate.PrimaryKey = new DataColumn[] { dtMate.Columns["库存序号"], dtMate.Columns["出库流水号"] };

            #endregion

            return 1;
        }


        /// <summary>
        /// 通过列名获取待退药品列
        /// </summary>
        /// <param name="Name">列名</param>
        /// <returns>列序号 成功   －1失败</returns>
        protected int GetColumnIndexFromNameForfpfpUnQuitDrug(string Name)
        {
            for (int i = 0; i < this.fpUnQuit_SheetDrug.Columns.Count; i++)
            {
                if (this.fpUnQuit_SheetDrug.Columns[i].Label == Name)
                    return i;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("缺少列" + Name, 211);

            return -1;
        }

        /// <summary>
        /// 通过列名获取待退非药品列
        /// </summary>
        /// <param name="Name">列名</param>
        /// <returns>列序号 成功   －1失败</returns>
        protected int GetColumnIndexFromNameForfpfpUnQuitUnDrug(string Name)
        {
            for (int i = 0; i < this.fpUnQuit_SheetUndrug.Columns.Count; i++)
            {
                if (this.fpUnQuit_SheetUndrug.Columns[i].Label == Name)
                    return i;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("缺少列" + Name, 211);

            return -1;
        }
        /// <summary>
        /// 过滤查找项目
        /// </summary>
        protected virtual void SetFilter()
        {
            string filterString = string.Empty;

            filterString = this.txtFilter.Text.Trim();

            //去掉可能导致过滤崩溃的特殊字符
            filterString = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(filterString, new string[] { "[", "'" });

            //如果当前活动页面是未退药品时的过滤
            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug)
            {
                dvDrug.RowFilter = "药品名称 like '" + filterString + "%'" + " OR " + "拼音码 like '" + filterString + "%'";

                //重新读取列的顺序和宽度等信息
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);
            }
            //如果当前活动页面是未退非药品时的过滤
            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetUndrug)
            {
                //dvUndrug.RowFilter = "项目名称 like '" + filterString + "%'" + " OR " + "拼音码 like '" + filterString + "%'";
                this.SetUndragFp(filterString);
                //重新读取列的顺序和宽度等信息
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
            }
        }

        /// <summary>
        /// 根据列名查找列所在位置
        /// </summary>
        /// <param name="name">列名</param>
        /// <param name="sv">要查找的SheetView</param>
        /// <returns>成功 列所在位置 失败 -1</returns>
        private int FindColumn(string name, FarPoint.Win.Spread.SheetView sv)
        {
            for (int i = 0; i < sv.Columns.Count; i++)
            {
                if (sv.Columns[i].Label == name)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 显示选择的退费信息
        /// </summary>
        /// <param name="feeItemList">费用信息实体</param>
        protected virtual void SetItemToDeal(FeeItemList feeItemList)
        {
            //this.txtItemName.Text = feeItemList.Item.Name;
            //this.txtItemName.Tag = feeItemList;
            //this.txtPrice.Text = feeItemList.Item.Price.ToString();
            //this.mtbQty.Text = feeItemList.NoBackQty.ToString();
            //this.txtUnit.Text = feeItemList.Item.PriceUnit;
            HISFC.Models.FeeStuff.Output outItem = null;
            bool isFind = false;
            if (feeItemList.MateList.Count == 0)
            {
                isFind = false;

            }
            else
            {
                DataRow[] vdr = dtMate.Select("出库流水号 ='" + feeItemList.MateList[0].ID + "'");
                if (vdr.Length <= 1)
                {
                    isFind = false;
                }
                else
                {
                    isFind = true;
                }

            }
            if (!isFind)
            {
                this.txtItemName.Text = feeItemList.Item.Name;
                this.txtItemName.Tag = feeItemList;
                this.txtPrice.Text = feeItemList.Item.Price.ToString();
                this.mtbQty.Text = feeItemList.NoBackQty.ToString();
                this.txtUnit.Text = feeItemList.Item.PriceUnit;
            }
            else
            {
                outItem = feeItemList.MateList[0];
                this.txtItemName.Text = outItem.StoreBase.Item.Name;
                this.txtItemName.Tag = feeItemList;
                this.txtPrice.Text = outItem.StoreBase.Item.Price.ToString();
                this.mtbQty.Text = outItem.StoreBase.Quantity.ToString();
                this.txtUnit.Text = feeItemList.Item.PriceUnit;
            }

            neuPanel1.Focus();
            neuPanel3.Focus();
            neuPanel4.Focus();
            gbQuitItem.Focus();
            this.mtbQty.Focus();
        }

        /// <summary>
        /// 双击项目处理事件
        /// </summary>
        protected virtual void ChooseUnquitItem()
        {
            string recipeNO = string.Empty;//处方号
            int recipeSequence = 0;//处方内项目流水号
            decimal noBackQty = 0;//可退数量
            //bool isPharmarcy = false;//是否药品
            EnumItemType isPharmarcy = EnumItemType.UnDrug;

            //判断当前处理的信息是否为药品,如果活动页是药品页,那么说明处理的是药品,否则为非药品
            isPharmarcy = this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug ? EnumItemType.Drug : EnumItemType.UnDrug;

            if (this.fpUnQuit.ActiveSheet.RowCount == 0)
            {
                return;
            }

            int index = this.fpUnQuit.ActiveSheet.ActiveRowIndex;
            #region 是否允许退其他科室费用
            if (!isCanQuitOtherFee && operation == Operations.Apply)
            {
                string FeeOperDept = fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("开方科室", this.fpUnQuit.ActiveSheet));
                if (FeeOperDept != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID)
                {
                    MessageBox.Show("不允许退其他科室费用");
                    return;
                }
            }
            #endregion

            #region 物资(非药品对应多条物资)
            //是否是多条对照
            List<HISFC.Models.FeeStuff.Output> outitemList = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            string headerText = this.fpUnQuit.ActiveSheet.RowHeader.Cells[index, 0].Text;
            //多条对照
            if (isPharmarcy == EnumItemType.UnDrug)
            {
                if (headerText == "+" || headerText == "-")
                {
                    if (!this.ckbAllQuit.Checked)
                    {

                        if (!this.ckbAllQuit.Checked && headerText != ".")
                        {
                            MessageBox.Show("请选择要退费的物资信息！");
                            if (this.fpUnQuit_SheetUndrug.RowHeader.Cells[index, 0].Text == "+")
                            {
                                this.ExpandOrCloseRow(false, index + 1);
                            }
                            return;
                        }
                    }
                }
                outitemList = QuiteAllMate(index);
                index = this.FinItemRowIndex(index);
            }

            #endregion

            recipeNO = this.fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("处方号", this.fpUnQuit.ActiveSheet));
            recipeSequence = NConvert.ToInt32(this.fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("处方流水号", this.fpUnQuit.ActiveSheet)));
            noBackQty = NConvert.ToDecimal(this.fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("可退数量", this.fpUnQuit.ActiveSheet)));

            //获得费用的所有信息,因为DataTable中不能绑定Tag,信息不全
            FeeItemList feeItemList = this.inpatientManager.GetItemListByRecipeNO(recipeNO, recipeSequence, isPharmarcy);
            if (feeItemList == null)
            {
                MessageBox.Show(Language.Msg("获得项目基本信息出错!") + this.inpatientManager.Err);

                return;
            }
            //在NoBackQty属性中保存当前的可退数量,因为界面的上的可能被连续退多次.
            feeItemList.NoBackQty = noBackQty;

            //feeItemList.MateList.Add(outitemList.);
            if (feeItemList.Item.ItemType != EnumItemType.Drug && outitemList.Count > 0)
            {
                feeItemList.MateList = outitemList;
            }

            //{F4912030-EF65-4099-880A-8A1792A3B449}
            //是复合项目，并且复合项目必须全退，这里处理。
            //循环查找所有moorder和packcode一样的项目，一并处理.
            //这里默认必须全退，即使复合项目数量不是1，不然处理起来太麻烦。
            if (this.isCombItemAllQuit && isPharmarcy == EnumItemType.UnDrug && !string.IsNullOrEmpty(feeItemList.UndrugComb.ID))
            {
                MessageBox.Show("您选择的退费项目输入复合项目包含的小项，当前设置，复合项目必须全退，请注意!");

                ArrayList recipeNOs = this.inpatientManager.QueryRecipesByMoOrder(feeItemList.Order.ID, feeItemList.UndrugComb.ID);
                if (recipeNOs == null)
                {
                    MessageBox.Show("没有找到相同的复合项目!" + this.inpatientManager.Err);

                    return;
                }
                foreach (Neusoft.FrameWork.Models.NeuObject o in recipeNOs)
                {
                    FeeItemList f = this.inpatientManager.GetItemListByRecipeNO(o.ID, NConvert.ToInt32(o.Name), isPharmarcy);
                    if (f == null)
                    {
                        MessageBox.Show(Language.Msg("获得项目基本信息出错!") + this.inpatientManager.Err);

                        return;
                    }

                    this.QuitOperation(f.Clone());
                }

                return;
            }//{F4912030-EF65-4099-880A-8A1792A3B449}结束

            //如果全退按钮为选中,那么将全退当前的可退数量.
            //{7A07D8BE-FEEA-42b4-B515-4699951333E8} 付数不为1的不允许部分退
            if (this.ckbAllQuit.Checked || (this.ckbAllQuit.Checked == false && feeItemList.Days != 1 && feeItemList.Item.ItemType == EnumItemType.Drug))
            {
                this.QuitOperation(feeItemList.Clone());
            }
            else//否则,焦点在输入可退数量的对话框,可以输入要退的数量
            {
                this.SetItemToDeal(feeItemList.Clone());
            }
        }

        /// <summary>
        /// 全退非药品或物资
        /// </summary>
        /// <param name="isAllQuite">是否全退</param>
        /// <returns></returns>
        private List<HISFC.Models.FeeStuff.Output> QuiteAllMate(int index)
        {
            string headerText = this.fpUnQuit_SheetUndrug.RowHeader.Cells[index, 0].Text;
            string stockNo = string.Empty; //物资出库序号
            string outNo = string.Empty; //物资出库序号
            List<HISFC.Models.FeeStuff.Output> list = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            Neusoft.HISFC.Models.FeeStuff.Output outItem = null;
            //全退非药品
            if (headerText != ".")
            {
                outNo = fpUnQuit_SheetUndrug.GetText(index, this.FindColumn("出库流水号", fpUnQuit_SheetUndrug));
                DataRow[] vdr = dtMate.Select("出库流水号 ='" + outNo + "'");
                if (vdr.Length == 0)
                    return list;

                foreach (DataRow dr in vdr)
                {
                    outItem = this.GetOutPutByDataRow(dr);
                    if (outItem == null)
                    {
                        MessageBox.Show("查找物资项目信息失败");
                        return null;
                    }
                    list.Add(outItem);
                }
            }
            //全退物资
            if (headerText == ".")
            {
                outItem = QuiteMate(index);
                if (outItem == null)
                {
                    MessageBox.Show("查找物资项目信息失败");
                    return null;
                }
                list.Add(outItem);
            }
            return list;
        }


        /// <summary>
        /// 当前退费的物资(非药品对照的物资)
        /// </summary>
        /// <param name="index">当前选中的行</param>
        /// <param name="IsAllQuite">是否全退</param>
        /// <returns></returns>
        private HISFC.Models.FeeStuff.Output QuiteMate(int index)
        {
            string headerText = this.fpUnQuit_SheetUndrug.RowHeader.Cells[index, 0].Text;
            string stockNo = string.Empty; //物资出库序号
            string outNo = string.Empty; //物资出库序号
            HISFC.Models.FeeStuff.Output outItem = null;
            if (headerText == ".")
            {
                stockNo = fpUnQuit_SheetUndrug.GetText(index, this.FindColumn("库存序号", fpUnQuit_SheetUndrug));
                outNo = fpUnQuit_SheetUndrug.GetText(index, this.FindColumn("出库流水号", fpUnQuit_SheetUndrug));
                DataRow dr = this.FindMateRow(stockNo, outNo);
                if (dr == null)
                {
                    MessageBox.Show(Language.Msg("获得物资基本信息出错!") + this.mateInteger.Err);
                    return null;
                }
                outItem = this.GetOutPutByDataRow(dr);
                if (outItem == null)
                {
                    MessageBox.Show(Language.Msg("获得物资基本信息出错!") + this.mateInteger.Err);
                    return null;
                }
            }
            return outItem;
        }

        /// <summary>
        /// 根据dtmate中的DataRow形成OutPut实体
        /// </summary>
        /// <param name="dr">dtmate中的DataRow</param>
        /// <returns></returns>
        private HISFC.Models.FeeStuff.Output GetOutPutByDataRow(DataRow dr)
        {
            HISFC.Models.FeeStuff.Output outItem = new Neusoft.HISFC.Models.FeeStuff.Output();
            outItem.StoreBase.Item.Name = dr["项目名称"].ToString();
            outItem.StoreBase.Item.MinFee.ID = this.objectHelperMinFee.GetID(dr["费用名称"].ToString());
            outItem.StoreBase.Item.Specs = dr["规格"].ToString();
            outItem.StoreBase.Item.Price = NConvert.ToDecimal(dr["价格"]);
            outItem.StoreBase.Quantity = NConvert.ToDecimal(dr["可退数量"]);
            if (this.ckbAllQuit.Checked)
            {
                outItem.ReturnApplyNum = NConvert.ToDecimal(dr["可退数量"]);
            }
            outItem.StoreBase.Item.PriceUnit = dr["单位"].ToString();
            outItem.ID = dr["出库流水号"].ToString();
            outItem.StoreBase.Item.ID = dr["编码"].ToString();
            //库存序号
            outItem.StoreBase.StockNO = dr["库存序号"].ToString();
            return outItem;
        }

        /// <summary>
        /// 查找物资所对照的非药品所对应的行
        /// </summary>
        /// <param name="rowIndex">物资所在的行</param>
        /// <returns></returns>
        private int FinItemRowIndex(int rowIndex)
        {
            for (int i = rowIndex; i >= 0; i--)
            {
                if (this.fpUnQuit_SheetUndrug.RowHeader.Cells[i, 0].Text != ".")
                    return i;
            }
            return -1;
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
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
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
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
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
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
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
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsConfirm, feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged ? true : false);
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
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName, this.inpatientManager.GetMinFeeNameByCode(feeItemList.Item.MinFee.ID));
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
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
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
                SetFeeItemList(temp, feeItemList);
            }

            return 1;
        }

        private void SetFeeItemList(FeeItemList temp, FeeItemList feeItemList)
        {
            if (feeItemList.MateList.Count == 0)
                return;
            if (temp.MateList.Count == 0)
            {
                temp.MateList.Add(feeItemList.MateList[0]);
            }
            else
            {

                foreach (HISFC.Models.FeeStuff.Output outItem in feeItemList.MateList)
                {
                    bool isFind = false;
                    foreach (HISFC.Models.FeeStuff.Output tempItem in temp.MateList)
                    {
                        if (tempItem.ID == outItem.ID && tempItem.StoreBase.StockNO == outItem.StoreBase.StockNO)
                        {
                            isFind = true;
                            tempItem.ReturnApplyNum += outItem.ReturnApplyNum;
                        }
                    }
                    if (!isFind)
                    {
                        temp.MateList.Add(outItem);
                    }
                }

            }
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
        /// 退费操作
        /// </summary>
        /// <param name="feeItemList">费用基本信息实体</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QuitOperation(FeeItemList feeItemList)
        {
            DataRow findRow = this.FindUnquitItem(feeItemList.Clone());

            if (findRow == null)
            {
                MessageBox.Show("查找项目出错!");

                return -1;
            }

            decimal orgNoBackQty = NConvert.ToDecimal(findRow["可退数量"]);

            if (orgNoBackQty < feeItemList.NoBackQty)
            {
                MessageBox.Show(Language.Msg("可退数量不能大于") + orgNoBackQty.ToString());

                return -1;
            }

            //findRow["可退数量"] = NConvert.ToDecimal(findRow["可退数量"]) - feeItemList.NoBackQty;
            //findRow["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(findRow["可退数量"]) / feeItemList.Item.PackQty;

            int index = this.fpUnQuit.ActiveSheet.ActiveRowIndex;
            //全退物资非药品的可退数量为物资的数量
            if (this.fpUnQuit.ActiveSheet.RowHeader.Cells[index, 0].Text == "." && this.ckbAllQuit.Checked)
            {
                feeItemList.NoBackQty = feeItemList.MateList[0].ReturnApplyNum;
            }
            findRow["可退数量"] = NConvert.ToDecimal(findRow["可退数量"]) - feeItemList.NoBackQty;

            findRow["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(findRow["可退数量"]) / feeItemList.Item.PackQty;
            //同步非药品数据
            UpdateFpData(findRow, false);

            #region 同步fpUnQuit_SheetUndrug和DataTable中的数据
            //以为非药品的数据不是绑定上的所以要同步fpUnQuit_SheetUndrug和DataTable中的数据
            string rowHeader = string.Empty;
            DataRow mateRow = null;
            if (feeItemList.Item.ItemType != EnumItemType.Drug && feeItemList.MateList.Count > 0)
            {

                foreach (HISFC.Models.FeeStuff.Output outItem in feeItemList.MateList)
                {
                    mateRow = FindMateRow(outItem);
                    if (mateRow == null)
                    {
                        MessageBox.Show("查找项目出错!");
                        return -1;
                    }
                    mateRow["可退数量"] = NConvert.ToDecimal(mateRow["可退数量"]) - outItem.ReturnApplyNum;
                    mateRow["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(mateRow["可退数量"]) / feeItemList.Item.PackQty;
                    UpdateFpData(mateRow, true);
                }
            }
            #endregion

            this.SetQuitItem(feeItemList.Clone());

            return 1;
        }

        /// <summary>
        /// 更新非药品Farpoint数据
        /// </summary>
        /// <param name="dr">非药品数据</param>
        private void UpdateFpData(DataRow dr, bool isMate)
        {
            //以为非药品的数据不是绑定上的所以要同步fpUnQuit_SheetUndrug和DataTable中的数据
            string stockNo = string.Empty;
            string outNo = string.Empty;
            string recipeNO = string.Empty;
            string recipeSequence = string.Empty;
            bool isFind = false;
            for (int i = 0; i < fpUnQuit_SheetUndrug.Rows.Count; i++)
            {
                if (isMate)
                {
                    stockNo = this.fpUnQuit_SheetUndrug.GetText(i, this.FindColumn("库存序号", this.fpUnQuit_SheetUndrug));
                    outNo = this.fpUnQuit_SheetUndrug.GetText(i, this.FindColumn("出库流水号", this.fpUnQuit_SheetUndrug));
                    if (stockNo == dr["库存序号"].ToString() && outNo == dr["出库流水号"].ToString())
                    {
                        isFind = true;
                    }
                }
                else
                {
                    recipeNO = fpUnQuit_SheetUndrug.GetText(i, this.FindColumn("处方号", this.fpUnQuit_SheetUndrug));
                    recipeSequence = this.fpUnQuit_SheetUndrug.GetText(i, this.FindColumn("处方流水号", this.fpUnQuit_SheetUndrug));
                    if (recipeNO == dr["处方号"].ToString() && recipeSequence == dr["处方流水号"].ToString())
                    {
                        isFind = true;
                    }
                }
                if (isFind)
                {
                    this.fpUnQuit_SheetUndrug.Cells[i, this.FindColumn("可退数量", this.fpUnQuit_SheetUndrug)].Text = dr["可退数量"].ToString();
                    this.fpUnQuit_SheetUndrug.Cells[i, this.FindColumn("金额", this.fpUnQuit_SheetUndrug)].Text = dr["金额"].ToString();
                    return;
                }
            }

        }

        /// <summary>
        /// 查找物资非药品
        /// </summary>
        /// <param name="outItem">物资出库记录</param>
        /// <returns></returns>
        private DataRow FindMateRow(HISFC.Models.FeeStuff.Output outItem)
        {
            string outNo = string.Empty;
            string stockNo = string.Empty;

            outNo = outItem.ID;
            stockNo = outItem.StoreBase.StockNO;
            return FindMateRow(stockNo, outNo);

        }
        /// <summary>
        /// 查找物资非药品
        /// </summary>
        /// <param name="stockNo">库存序号</param>
        /// <param name="outNo">出库流水号</param>
        /// <returns></returns>
        private DataRow FindMateRow(string stockNo, string outNo)
        {
            DataRow dr = dtMate.Rows.Find(new object[] { stockNo, outNo });
            return dr;
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

                UpdateFpData(rowFind, false);

                #region 同步fpUnQuit_SheetUndrug和DataTable中的数据
                //以为非药品的数据不是绑定上的所以要同步fpUnQuit_SheetUndrug和DataTable中的数据
                string rowHeader = string.Empty;
                DataRow mateRow = null;
                if (feeItemList.Item.ItemType != EnumItemType.Drug && feeItemList.MateList.Count > 0)
                {

                    foreach (HISFC.Models.FeeStuff.Output outItem in feeItemList.MateList)
                    {
                        mateRow = FindMateRow(outItem);
                        if (mateRow == null)
                        {
                            MessageBox.Show("查找项目出错!");
                            return -1;
                        }
                        mateRow["可退数量"] = NConvert.ToDecimal(mateRow["可退数量"]) + outItem.ReturnApplyNum;
                        mateRow["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(mateRow["可退数量"]) / feeItemList.Item.PackQty;
                        UpdateFpData(mateRow, true);
                    }
                }
                #endregion
                this.fpQuit.ActiveSheet.Rows.Remove(index, 1);
                //feeItemList.NoBackQty = 0;
                //this.fpQuit.ActiveSheet.SetValue(index, (int)DrugColumns.Qty, 0);
                //this.fpQuit.ActiveSheet.SetValue(index, (int)DrugColumns.Cost, 0);
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
        /// 保存退费申请信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SaveApply()
        {
            //验证合法性
            if (!this.IsValid())
            {
                return -1;
            }

            List<FeeItemList> feeItemLists = this.GetConfirmItem();

            if (feeItemLists.Count <= 0)
            {
                MessageBox.Show(Language.Msg("没有费用可退!"));

                return -1;
            }

            //开始事务
            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string errMsg = string.Empty;//错误信息
            int returnValue = 0;//返回值
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            //获得退费申请号
            string applyBillCode = this.GetApplyBillCode(ref errMsg);
            if (applyBillCode == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errMsg);

                return -1;
            }

            //循环处理退费数据
            foreach (FeeItemList feeItemList in feeItemLists)
            {
                //如果草药付数没有赋值,默认赋值为1
                if (feeItemList.Days == 0)
                {
                    feeItemList.Days = 1;
                }

                FeeItemList feeItemListTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.ItemType);
                if (feeItemListTemp == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获得项目基本信息出错!" + this.inpatientManager.Err));

                    return -1;
                }
                //向退费单中填写记录
                //if (feeItemListTemp.Item.IsPharmacy && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                if (feeItemListTemp.Item.ItemType == EnumItemType.Drug && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                {
                    if (feeItemList.Item.User01 == "1")
                    {
                        feeItemList.User01 = "送住院处";
                    }
                    else
                    {
                        feeItemList.User01 = "送药房";
                    }
                }
                else
                {
                    feeItemList.User01 = "送住院处";
                }
                if (feeItemList.Memo != "OLD")
                {
                    feeItemList.User02 = applyBillCode;
                }
                //对已经保存过的退费申请不进行处理
                if (feeItemList.Memo == "OLD")
                {
                    continue;
                }

                //更新费用表中的可退数量字段
                //如果是药品则更新药品的退药数量，否则更新非药品
                returnValue = UpdateNoBackQty(feeItemList, ref errMsg);
                if (returnValue == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errMsg);

                    return -1;
                }

                //临时项目赋予退费申请号
                feeItemListTemp.User02 = applyBillCode;

                //如果是药品并且已经摆药，则调用退药申请；否则调用退费申请。
                //if (feeItemListTemp.Item.IsPharmacy && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                if (feeItemListTemp.Item.ItemType == EnumItemType.Drug && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                {
                    //退药申请,使用数据库中取得的实体和用户操作的数量
                    feeItemListTemp.Item.Qty = feeItemList.Item.Qty;
                    if (feeItemListTemp.StockOper.Dept.ID == string.Empty)
                    {
                        feeItemListTemp.StockOper.Dept.ID = feeItemListTemp.ExecOper.Dept.ID;
                    }
                    if (this.phamarcyIntegrate.ApplyOutReturn(this.patientInfo, feeItemListTemp, nowTime) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();

                        MessageBox.Show(Language.Msg("退药申请失败!" + this.phamarcyIntegrate.Err));
                        return -1;
                    }
                }
                else//对于非药品和未摆药的药品，直接做退费申请
                {
                    //使用数据库中取得的实体和用户操作的数量
                    feeItemListTemp.Item.Qty = feeItemList.Item.Qty;

                    feeItemListTemp.Item.Price = feeItemListTemp.Item.Price * feeItemListTemp.FTRate.ItemRate;
                    if (this.returnApplyManager.Apply(this.patientInfo, feeItemListTemp, nowTime) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("插入退费申请失败!") + this.returnApplyManager.Err);

                        return -1;
                    }

                    //没有摆药的药品在退费申请的同时，作废摆药申请
                    //if (feeItemListTemp.Item.IsPharmacy)
                    if (feeItemListTemp.Item.ItemType == EnumItemType.Drug)
                    {
                        //取摆药申请记录，判断其状态是否发生并发。（不在CancelApplyOut中判断并发是因为有些收费后的医嘱没有发送到药房，不存在摆药申请记录）
                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.phamarcyIntegrate.GetApplyOut(feeItemListTemp.RecipeNO, feeItemListTemp.SequenceNO);
                        if (applyOut == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("获得申请信息出错!") + this.phamarcyIntegrate.Err);

                            return -1;
                        }

                        //如果取到的实体ID为""，则表示医嘱并未发送。未发送的医嘱不允许退费，不然发送时药房会对此退费的项目进行发药。
                        if (applyOut.ID == string.Empty)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("项目【") + feeItemListTemp.Item.Name + Language.Msg("】没有发送到药房，请先发送，然后再做退费申请!"));

                            return -1;
                        }

                        //并发
                        if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("项目【") + feeItemListTemp.Item.Name + Language.Msg("】已被其他操作员退费，请刷新当前数据!"));

                            return -1;
                        }

                        //作废摆药申请
                        returnValue = this.phamarcyIntegrate.CancelApplyOut(feeItemListTemp.RecipeNO, feeItemListTemp.SequenceNO);
                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("作废摆药申请出错!") + phamarcyIntegrate.Err);

                            return -1;
                        }
                        if (returnValue == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("项目【") + feeItemListTemp.Item.Name + Language.Msg("】已摆药，请重新检索数据"));

                            return -1;
                        }

                        //如果是部分退费(用户退药的数量小于费用表中的可退数量),要对剩余的药品做摆药申请.
                        if (feeItemList.Item.Qty < feeItemListTemp.NoBackQty)
                        {
                            //取收费对应的摆药申请记录
                            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp = this.phamarcyIntegrate.GetApplyOut(feeItemListTemp.RecipeNO, feeItemListTemp.SequenceNO);
                            if (applyOutTemp == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Language.Msg("获得申请信息出错!") + this.phamarcyIntegrate.Err);

                                return -1;
                            }

                            applyOutTemp.Operation.ApplyOper.OperTime = nowTime;
                            applyOutTemp.Operation.ApplyQty = feeItemListTemp.NoBackQty - feeItemList.Item.Qty;//数量等于剩余数量
                            applyOutTemp.Operation.ApproveQty = feeItemListTemp.NoBackQty - feeItemList.Item.Qty;//数量等于剩余数量
                            applyOutTemp.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;	//有效状态
                            //将剩余数量发送摆药申请  {C37BEC96-D671-46d1-BCDD-C634423755A4}
                            if (this.phamarcyIntegrate.ApplyOut(applyOutTemp) != 1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Language.Msg("重新插入发药申请出错!") + this.phamarcyIntegrate.Err);

                                return -1;
                            }
                        }
                    }
                }

                //if (feeItemListTemp.Item.IsPharmacy)
                if (feeItemListTemp.Item.ItemType == EnumItemType.Drug)
                {
                    ArrayList patientDrugStorageList = this.phamarcyIntegrate.QueryStorageList(this.patientInfo.ID, feeItemListTemp.Item.ID);
                    if (patientDrugStorageList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("判断是否存在患者库存时出错") + this.phamarcyIntegrate.Err);

                        return -1;
                    }
                    //对患者库存进行清零操作
                    if (patientDrugStorageList.Count > 0)
                    {
                        Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = patientDrugStorageList[0] as Neusoft.HISFC.Models.Pharmacy.StorageBase;
                        storageBase.Quantity = -storageBase.Quantity;
                        storageBase.Operation.Oper.ID = this.inpatientManager.Operator.ID;
                        storageBase.PrivType = "AAAA";	//记录住院退费标记
                        if (storageBase.ID == string.Empty)
                        {
                            storageBase.ID = applyBillCode;
                            storageBase.SerialNO = 0;
                        }

                        if (this.phamarcyIntegrate.UpdateStorage(storageBase) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("更新患者库存出错!") + this.phamarcyIntegrate.Err);

                            return -1;
                        }
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("申请成功!"));

            return 1;
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
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
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
            this.feeIntegrate.MessageType = Neusoft.HISFC.Models.Base.MessType.N;//不提示欠费
            if (returnApplys.Count > 0)
            {
                this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }

            foreach (FeeItemList feeItemList in feeItemLists)
            {
                //if (feeItemList.Item.IsPharmacy) 
                if (feeItemList.Item.ItemType == EnumItemType.Drug)
                {
                    if (this.phamarcyIntegrate.CancelApplyOut(feeItemList.Clone()) == -1)
                    {
                        this.feeIntegrate.Rollback();

                        MessageBox.Show(Language.Msg("退费失败! 该药品可能已经发药，请重新输入住院号，刷新再试!") + this.phamarcyIntegrate.Err);

                        return -1;
                    }
                }

                if (this.feeIntegrate.QuitItem(this.patientInfo, feeItemList.Clone()) <= 0)
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

                    MessageBox.Show(Language.Msg("核准退费申请失败!,可能数据有变化") + this.returnApplyManager.Err);

                    return -1;
                }

                FeeItemList feeTemp = returnApply as FeeItemList;

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
            //ArrayList returnPharmacyApplys = new ArrayList(); 
            //ArrayList returnItemApplys = new ArrayList(); 
            //switch (this.itemType)
            //{
            //    case ItemTypes.Pharmarcy:
            //        returnPharmacyApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, true);

            //        if (returnPharmacyApplys == null)
            //        {
            //            MessageBox.Show("获得退费申请信息出错！");
            //            return null;
            //        } 
            //        break;

            //    case ItemTypes.Undrug:
            //        returnItemApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, false);

            //        if (returnItemApplys == null)
            //        {
            //            MessageBox.Show("获得退费申请信息出错！");

            //            return null;
            //        }

            //        break;

            //    case ItemTypes.All:
            //        returnPharmacyApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, true);

            //        if (returnPharmacyApplys == null)
            //        {
            //            MessageBox.Show("获得退费申请信息出错！");
            //            return null;
            //        }
            //        returnItemApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, false);

            //        if (returnItemApplys == null)
            //        {
            //            MessageBox.Show("获得退费申请信息出错！");
            //            return null;
            //        } 
            //        break;
            //}



            //List<FeeItemList> feeItemLists = new List<FeeItemList>();

            //foreach (FeeItemList objPharm in returnPharmacyApplys)
            //{ 
            //    if (objPharm.NoBackQty > 0)
            //    {
            //        objPharm.Item.Qty = objPharm.NoBackQty;
            //        objPharm.NoBackQty = 0;
            //        objPharm.FT.TotCost = objPharm.Item.Price * objPharm.Item.Qty / objPharm.Item.PackQty;
            //        objPharm.FT.OwnCost = objPharm.FT.TotCost;
            //        objPharm.IsNeedUpdateNoBackQty = true;

            //        feeItemLists.Add(objPharm);
            //    }
            //}
            //foreach (FeeItemList objItem in returnItemApplys)
            //{
            //    if (objItem.NoBackQty > 0)
            //    {
            //        objItem.Item.Qty = objItem.NoBackQty;
            //        objItem.NoBackQty = 0;
            //        objItem.FT.TotCost = objItem.Item.Price * objItem.Item.Qty / objItem.Item.PackQty;
            //        objItem.FT.OwnCost = objItem.FT.TotCost;
            //        objItem.IsNeedUpdateNoBackQty = true;

            //        feeItemLists.Add(objItem);
            //    }
            //}

            List<FeeItemList> feeItemLists = new List<FeeItemList>();

            for (int j = 0; j < this.fpQuit.Sheets.Count; j++)
            {
                for (int i = 0; i < this.fpQuit.Sheets[j].RowCount; i++)
                {
                    if (this.fpQuit.Sheets[j].Rows[i].Tag != null && this.fpQuit.Sheets[j].Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList feeItemList = this.fpQuit.Sheets[j].Rows[i].Tag as FeeItemList;
                        if (feeItemList.NoBackQty > 0)
                        {
                            feeItemList.Item.Qty = feeItemList.NoBackQty;
                            feeItemList.NoBackQty = 0;
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
                    if (this.fpQuit.Sheets[j].Rows[i].Tag != null && this.fpQuit.Sheets[j].Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        Neusoft.HISFC.Models.Fee.ReturnApply feeItemList = this.fpQuit.Sheets[j].Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;

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
                        feeItemList.RecipeOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.RecipeOper.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)this.inpatientManager.Operator).Dept.ID;
                        feeItemList.CancelOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.ChargeOper.ID = this.inpatientManager.Operator.ID;
                        feeItemList.FeeOper.ID = this.inpatientManager.Operator.ID;

                        feeItemLists.Add(feeItemList);

                    }
                }
            }

            return feeItemLists;
        }

        /// <summary>
        /// 查询待退费项目
        /// </summary>
        /// <param name="isNoBackQtyOverZero">是否可退数量大于0</param>
        /// <returns>成功:查询待退费项目 失败 null 没有查找到数据 ArrayList.Count = 0</returns>
        protected virtual ArrayList QueryUnQuitItems(bool isNoBackQtyOverZero)
        {
            ArrayList noBackQtyOverZeroFeeItemList = new ArrayList();
            ArrayList allFeeItemList = new ArrayList();

            for (int i = 0; i < this.fpUnQuit.Sheets.Count; i++)
            {
                for (int j = 0; j < this.fpUnQuit.Sheets[i].RowCount; j++)
                {
                    decimal tempNoBackQty = NConvert.ToDecimal(this.fpUnQuit.Sheets[i].GetValue(j, this.FindColumn("可退数量", this.fpUnQuit.Sheets[i])).ToString());

                    FeeItemList feeItemList = new FeeItemList();
                    if (this.fpUnQuit.Sheets[i].RowHeader.Cells[j, 0].Text == ".")
                        continue;
                    feeItemList.RecipeNO = this.fpUnQuit.Sheets[i].GetValue(j, this.FindColumn("处方号", this.fpUnQuit.Sheets[i])).ToString();
                    feeItemList.SequenceNO = NConvert.ToInt32(this.fpUnQuit.Sheets[i].GetValue(j, this.FindColumn("处方流水号", this.fpUnQuit.Sheets[i])).ToString());
                    feeItemList.Item.ItemType = this.fpUnQuit.Sheets[i] == this.fpUnQuit_SheetDrug ? EnumItemType.Drug : EnumItemType.UnDrug;

                    if (tempNoBackQty > 0)
                    {
                        noBackQtyOverZeroFeeItemList.Add(feeItemList);
                    }

                    allFeeItemList.Add(feeItemList);
                }
            }

            if (isNoBackQtyOverZero)
            {
                return noBackQtyOverZeroFeeItemList;
            }
            else
            {
                return allFeeItemList;
            }
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        protected virtual void SetColumns()
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn ucSetCol = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();

            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug)
            {
                ucSetCol.SetDataTable(this.filePathUnQuitDrug, this.fpUnQuit_SheetDrug);
            }
            else
            {
                ucSetCol.SetDataTable(this.filePathUnQuitUndrug, this.fpUnQuit_SheetUndrug);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucSetCol);
        }

        /// <summary>
        /// 折叠显示物资数据
        /// </summary>
        /// <param name="isExpand"></param>
        /// <param name="index"></param>
        private void ExpandOrCloseRow(bool isExpand, int index)
        {

            for (int i = index; i < fpUnQuit_SheetUndrug.Rows.Count; i++)
            {
                if (this.fpUnQuit_SheetUndrug.RowHeader.Cells[i, 0].Text == "." && this.fpUnQuit_SheetUndrug.Rows[i].Visible == isExpand)
                {
                    this.fpUnQuit_SheetUndrug.Rows[i].Visible = !isExpand;
                }
                else
                {
                    break;
                }
            }
            if (isExpand)
            {
                fpUnQuit_SheetUndrug.RowHeader.Cells[index - 1, 0].Text = "+";
            }
            else
            {
                fpUnQuit_SheetUndrug.RowHeader.Cells[index - 1, 0].Text = "-";
            }
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

            switch (this.operation)
            {
                case Operations.QuitFee:
                case Operations.Confirm:
                    return this.SaveFee();

                case Operations.Apply:

                    return this.SaveApply();
            }

            return 1;
        }

        /// <summary>
        /// 清空函数
        /// </summary>
        public virtual void Clear()
        {
            this.ClearItemList();

            this.txtItemName.Text = string.Empty;
            this.txtItemName.Tag = null;
            this.txtPrice.Text = "0";
            this.mtbQty.Text = "0";
            this.txtUnit.Text = "0";
            this.txtName.Text = string.Empty;
            this.txtPact.Text = string.Empty;
            this.txtDept.Text = string.Empty;
            this.txtFilter.Text = string.Empty;
            this.txtBed.Text = string.Empty;
            this.ucQueryPatientInfo.Text = string.Empty;
            this.ucQueryPatientInfo.txtInputCode.SelectAll();
            this.ucQueryPatientInfo.txtInputCode.Focus();
            this.patientInfo = null;

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
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
            this.fpUnQuit_SheetDrug.RowCount = 0;
            this.fpUnQuit_SheetUndrug.RowCount = 0;

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
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
                    this.SetColumns();
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
                catch
                {
                }
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

        /// <summary>
        /// 退费切换药品,非药品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpUnQuit_ActiveSheetChanged(object sender, EventArgs e)
        {
            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug)
            {
                if (this.fpQuit.ActiveSheet != null)
                {
                    this.fpQuit.ActiveSheet = this.fpQuit_SheetDrug;
                }
            }
            else
            {
                if (this.fpQuit.ActiveSheet != null)
                {
                    this.fpQuit.ActiveSheet = this.fpQuit_SheetUndrug;
                }
            }
        }

        /// <summary>
        /// 退费切换药品,非药品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpQuit_ActiveSheetChanged(object sender, EventArgs e)
        {
            if (this.fpQuit.ActiveSheet == this.fpQuit_SheetDrug)
            {
                if (this.fpUnQuit.ActiveSheet != null)
                {
                    this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetDrug;
                }
            }
            else
            {
                if (this.fpUnQuit.ActiveSheet != null)
                {
                    this.fpUnQuit.ActiveSheet = this.fpUnQuit_SheetUndrug;
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.SetFilter();
        }

        private void fpUnQuit_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug)
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpUnQuit_SheetDrug, this.filePathUnQuitDrug);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
            }
        }

        private void fpUnQuit_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ChooseUnquitItem();
        }

        private void mtbQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal qty = 0;

                try
                {
                    qty = NConvert.ToDecimal(this.mtbQty.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg("请输入合法的数字！") + ex.Message);
                    this.mtbQty.SelectAll();
                    this.mtbQty.Focus();

                    return;
                }

                if (qty <= 0)
                {
                    MessageBox.Show(Language.Msg("退费数量不能小于或者等于0"));
                    this.mtbQty.SelectAll();
                    this.mtbQty.Focus();

                    return;
                }

                if (qty != Neusoft.FrameWork.Function.NConvert.ToInt32(qty))
                {
                    MessageBox.Show(Language.Msg("退费数量不允许输入小数，请重新输入！"));
                    this.mtbQty.SelectAll();
                    this.mtbQty.Focus();
                    return;
                }

                if (this.txtItemName.Tag == null)
                {
                    return;
                }

                FeeItemList feeItemList = this.txtItemName.Tag as FeeItemList;

                feeItemList.NoBackQty = qty;

                //退单条物资
                if (feeItemList.MateList.Count > 0)
                {
                    feeItemList.MateList[0].ReturnApplyNum = qty;
                }

                this.QuitOperation(feeItemList);

                this.txtFilter.Focus();
            }
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

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.fpUnQuit.ActiveSheet.ActiveRowIndex--;
                this.fpUnQuit.ActiveSheet.AddSelection(this.fpUnQuit.ActiveSheet.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                this.fpUnQuit.ActiveSheet.ActiveRowIndex++;
                this.fpUnQuit.ActiveSheet.AddSelection(this.fpUnQuit.ActiveSheet.ActiveRowIndex, 0, 1, 0);
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 药品退费列信息
        /// </summary>
        protected enum DrugColumns
        {
            /// <summary>
            /// 药品名称
            /// </summary>
            ItemName = 0,

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
            /// 药品名称
            /// </summary>
            ItemName = 0,

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

        /// <summary>
        /// 退费功能
        /// </summary>
        public enum Operations
        {
            /// <summary>
            /// 直接退费
            /// </summary>
            QuitFee = 0,

            /// <summary>
            /// 退费申请
            /// </summary>
            Apply,

            /// <summary>
            /// 退费确认
            /// </summary>
            Confirm,
        }

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

        private void fpUnQuit_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            if (e.RowHeader && this.fpUnQuit_SheetUndrug.RowHeader.Cells[e.Row, 0].Text == "+" &&
                this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetUndrug)
            {
                ExpandOrCloseRow(false, e.Row + 1);
                return;
            }
            if (e.RowHeader && fpUnQuit_SheetUndrug.RowHeader.Cells[e.Row, 0].Text == "-" &&
                this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetUndrug)
            {
                ExpandOrCloseRow(true, e.Row + 1);
                return;
            }

        }
    }
}
