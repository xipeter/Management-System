using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.HISFC.BizLogic.RADT;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// addby xuewj 2010-9-28 查询患者费用明细 {98057398-9233-4aec-8FAF-662A8E82BF74}
    /// </summary>
    public partial class ucPatientFeeQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientFeeQuery()
        {
            InitializeComponent();
        }

        #region 变量
        
        /// <summary>
        /// 住院入出转业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        /// <summary>
        /// 科室业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 人员信息业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 常数业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient feeManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 当前患者
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo currentPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// Tab
        /// </summary>
        protected Hashtable hashTableFp = new Hashtable();

        #region DataTalbe相关变量

        string pathNameMainInfo = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientMainInfo.xml";
        string pathNamePrepay = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientPrepay.xml";
        string pathNameFee = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientFee.xml";
        string pathNameDrugList = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientDrugList.xml";
        string pathNameUndrugList = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientUndrugList.xml";
        string pathNameBalance = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientBalance.xml";
        string pathNameDiagnose = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\QueryPatientDiagnose.xml";

        /// <summary>
        /// 患者主信息
        /// </summary>
        DataTable dtMainInfo = new DataTable();

        /// <summary>
        /// 患者主信息视图
        /// </summary>
        DataView dvMainInfo = new DataView();

        /// <summary>
        /// 药品明细
        /// </summary>
        DataTable dtDrugList = new DataTable();

        /// <summary>
        /// 药品明细视图
        /// </summary>
        DataView dvDrugList = new DataView();

        /// <summary>
        /// 非药品信息
        /// </summary>
        DataTable dtUndrugList = new DataTable();

        /// <summary>
        /// 非药品信息视图
        /// </summary>
        DataView dvUndrugList = new DataView();

        /// <summary>
        /// 预交金信息
        /// </summary>
        DataTable dtPrepay = new DataTable();

        /// <summary>
        /// 预交金视图
        /// </summary>
        DataView dvPrepay = new DataView();

        /// <summary>
        /// 费用汇总信息
        /// </summary>
        DataTable dtFee = new DataTable();

        /// <summary>
        /// 费用汇总信息视图
        /// </summary>
        DataView dvFee = new DataView();

        /// <summary>
        /// 费用结算信息
        /// </summary>
        DataTable dtBalance = new DataTable();

        /// <summary>
        /// 费用结算信息视图
        /// </summary>
        DataView dvBalance = new DataView();

        #endregion

        #endregion

        /// <summary>
        /// 住院患者基本信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.currentPatient;
            }
            set
            {
                this.currentPatient = value;

                this.QueryPatientByInpatientNO(currentPatient);
            }
        }

        #region 私有方法

        private void InitHashTable()
        {
            foreach (TabPage t in this.neuTabControl1.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is FarPoint.Win.Spread.FpSpread)
                    {
                        this.hashTableFp.Add(t, c);
                    }
                }
            }
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="patient">成功 1 失败 -1</param>
        private void SetPatientToFpMain(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            if (patient == null)
            {
                return;
            }

            DataRow row = this.dtMainInfo.NewRow();
            try
            {

                row["住院流水号"] = patient.ID;
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] = patient.Name;
                row["住院科室"] = patient.PVisit.PatientLocation.Dept.Name;
                row["床号"] = patient.PVisit.PatientLocation.Bed.ID;
                row["患者类别"] = patient.Pact.Name;
                row["预交金(未结)"] = patient.FT.PrepayCost;
                row["费用合计(未结)"] = patient.FT.TotCost;
                row["余额"] = patient.FT.LeftCost;
                row["自费"] = patient.FT.OwnCost;
                row["自负"] = patient.FT.PayCost;
                row["公费"] = patient.FT.PubCost;
                row["入院日期"] = patient.PVisit.InTime;
                row["在院状态"] = patient.PVisit.InState.Name;

                row["出院日期"] = patient.PVisit.OutTime.Date == new DateTime(1, 1, 1).Date ? string.Empty : patient.PVisit.OutTime.ToString();

                row["预交金(已结)"] = patient.FT.BalancedPrepayCost;
                row["费用合计(已结)"] = patient.FT.BalancedCost;
                //row["医疗类别"] = patient.PVisit.MedicalType.Name;
                row["结算日期"] = patient.BalanceDate;

                this.dtMainInfo.Rows.Add(row);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        /// <summary>
        /// 根据输入的住院号查询患者基本信息
        /// </summary>
        private void QueryPatientByInpatientNO(Neusoft.HISFC.Models.RADT.PatientInfo patients)
        {
            this.Clear();
            this.dtMainInfo.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            //住院主表信息
            this.SetPatientToFpMain(patients);
            Cursor.Current = Cursors.Arrow;
            this.SetPatientInfo();
            //设置查询时间
            //设置查询时间
            DateTime beginTime = this.currentPatient.PVisit.InTime;
            DateTime endTime = this.radtManager.GetDateTimeFromSysDateTime();
            this.QueryAllInfomaition(beginTime, endTime);
            this.fpMainInfo_Sheet1.Columns[13].Width = 180;
        }

        /// <summary>
        /// 获得患者药品明细
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void QueryPatientDrugList(DateTime beginTime, DateTime endTime)
        {
            ArrayList drugList = this.feeManager.GetMedItemsForInpatient(this.currentPatient.ID, beginTime, endTime);
            if (drugList == null)
            {
                MessageBox.Show(Language.Msg("获得患者药品明细出错!") + this.feeManager.Err);

                return;
            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in drugList)
            {
                DataRow row = dtDrugList.NewRow();

                row["药品名称"] = obj.Item.Name;
                Neusoft.HISFC.Models.Pharmacy.Item medItem = (Neusoft.HISFC.Models.Pharmacy.Item)obj.Item;
                row["规格"] = medItem.Specs;
                row["单价"] = obj.Item.Price;
                row["数量"] = obj.Item.Qty;
                row["付数"] = obj.Days;
                row["单位"] = obj.Item.PriceUnit;
                row["金额"] = obj.FT.TotCost;
                row["自费"] = obj.FT.OwnCost;
                row["公费"] = obj.FT.PubCost;
                row["自负"] = obj.FT.PayCost;
                row["优惠"] = obj.FT.RebateCost;
                row["执行科室"] = this.deptManager.GetDeptmentById(obj.ExecOper.Dept.ID).Name;
                row["患者科室"] = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)obj.Patient).PVisit.PatientLocation.Dept.ID).Name;
                row["收费时间"] = obj.FeeOper.OperTime;

                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(obj.FeeOper.ID);
                if (empl.Name == string.Empty)
                {
                    row["收费员"] = obj.FeeOper.ID;
                }
                else
                {
                    row["收费员"] = empl.Name;
                }


                row["发药时间"] = obj.ExecOper.OperTime.Date == new DateTime(1, 1, 1).Date ? string.Empty : obj.ExecOper.OperTime.ToString();

                Neusoft.HISFC.Models.Base.Employee confirmOper = new Neusoft.HISFC.Models.Base.Employee();
                confirmOper = managerIntergrate.GetEmployeeInfo(obj.ExecOper.ID);

                if (confirmOper.Name == string.Empty)
                {
                    row["发药员"] = obj.ExecOper.ID;
                }
                else
                {
                    row["发药员"] = confirmOper.Name;
                }

                //row["来源"] = obj.FTSource;

                dtDrugList.Rows.Add(row);
            }

            this.AddSumInfo(dtDrugList, "药品名称", "合计:", "金额", "自费", "公费", "自负", "优惠");
        }

        /// <summary>
        /// 查询患者非药品明细
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void QueryPatientUndrugList(DateTime beginTime, DateTime endTime)
        {
            ArrayList undrugList = this.feeManager.QueryFeeItemLists(this.currentPatient.ID, beginTime, endTime);
            if (undrugList == null)
            {
                MessageBox.Show(Language.Msg("获得患者非药品明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in undrugList)
            {
                DataRow row = dtUndrugList.NewRow();

                row["项目名称"] = obj.Item.Name;
                row["单价"] = obj.Item.Price;
                row["数量"] = obj.Item.Qty;
                row["单位"] = obj.Item.PriceUnit;
                row["金额"] = obj.FT.TotCost;
                row["自费"] = obj.FT.OwnCost;
                row["公费"] = obj.FT.PubCost;
                row["自负"] = obj.FT.PayCost;
                row["优惠"] = obj.FT.RebateCost;
                row["收费时间"] = obj.FeeOper.OperTime;

                //收款员姓名
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(obj.FeeOper.ID);

                if (empl.Name == string.Empty)
                {
                    row["收费员"] = obj.FeeOper.ID;
                }
                else
                {
                    row["收费员"] = empl.Name;
                }

                row["执行科室"] = this.deptManager.GetDeptmentById(obj.ExecOper.Dept.ID).Name;
                row["患者科室"] = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)obj.Patient).PVisit.PatientLocation.Dept.ID).Name;
                //row["来源"] = obj.FTSource;

                dtUndrugList.Rows.Add(row);
            }

            this.AddSumInfo(dtUndrugList, "项目名称", "合计:", "金额", "自费", "公费", "自负", "优惠");
        }

        /// <summary>
        /// 查询患者预交金信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void QueryPatientPrepayList(DateTime beginTime, DateTime endTime)
        {
            ArrayList prepayList = this.feeManager.QueryPrepays(this.currentPatient.ID);
            if (prepayList == null)
            {
                MessageBox.Show(Language.Msg("获得患者预交金明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay in prepayList)
            {
                Neusoft.HISFC.Models.Base.Employee employeeObj = new Neusoft.HISFC.Models.Base.Employee();
                Neusoft.HISFC.Models.Base.Department deptObj = new Neusoft.HISFC.Models.Base.Department();
                DataRow row = dtPrepay.NewRow();

                row["票据号"] = prepay.RecipeNO;
                row["预交金额"] = prepay.FT.PrepayCost;
                row["支付方式"] = prepay.PayType.Name;
                employeeObj = this.personManager.GetPersonByID(prepay.PrepayOper.ID);
                row["操作员"] = employeeObj.Name;
                row["操作日期"] = prepay.PrepayOper.OperTime;
                deptObj = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)prepay.Patient).PVisit.PatientLocation.Dept.ID);
                row["所在科室"] = deptObj.Name;
                string tempBalanceStatusName = string.Empty;
                switch (prepay.BalanceState)
                {
                    case "0":
                        tempBalanceStatusName = "未结算";
                        break;
                    case "1":
                        tempBalanceStatusName = "已结算";
                        break;
                    case "2":
                        tempBalanceStatusName = "已结转";
                        break;
                }
                row["结算状态"] = tempBalanceStatusName;
                string tempPrepayStateName = string.Empty;
                switch (prepay.PrepayState)
                {
                    case "0":
                        tempPrepayStateName = "收取";
                        break;
                    case "1":
                        tempPrepayStateName = "作废";
                        break;
                    case "2":
                        tempPrepayStateName = "补打";
                        break;
                }

                //row["来源"] = tempPrepayStateName;

                dtPrepay.Rows.Add(row);
            }

            this.AddSumInfo(dtPrepay, "票据号", "合计:", "预交金额");

            dvPrepay.Sort = "票据号 ASC";
        }

        /// <summary>
        /// 获得患者指定时间段内的最小费用汇总信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void QueryPatientFeeInfo(DateTime beginTime, DateTime endTime)
        {
            ArrayList feeInfoList = this.feeManager.QueryFeeInfosGroupByMinFeeByInpatientNO(this.currentPatient.ID, beginTime, endTime, "0");
            if (feeInfoList == null)
            {
                MessageBox.Show(Language.Msg("获得患者费用汇总明细出错!") + this.feeManager.Err);

                return;
            }



            //feeInfoList.AddRange(feeInfoListBalanced);

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo in feeInfoList)
            {

                DataRow row = dtFee.NewRow();

                row["费用名称"] = this.feeManager.GetComDictionaryNameByID("MINFEE", feeInfo.Item.MinFee.ID);
                row["金额"] = feeInfo.FT.TotCost;
                row["自费"] = feeInfo.FT.OwnCost;
                row["公费"] = feeInfo.FT.PubCost;
                row["自负"] = feeInfo.FT.PayCost;
                row["优惠金额"] = feeInfo.FT.RebateCost;
                string temp = string.Empty;

                //if (feeInfo.BalanceState == "0")
                //{
                //    temp = "未结算";
                //}
                //else
                //{
                //    temp = "已结算";
                //}
                row["结算状态"] = "未结算";

                dtFee.Rows.Add(row);
            }

            ArrayList feeInfoListBalanced = this.feeManager.QueryFeeInfosGroupByMinFeeByInpatientNO(this.currentPatient.ID, beginTime, endTime, "1");
            if (feeInfoListBalanced == null)
            {
                MessageBox.Show(Language.Msg("获得患者费用汇总明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo in feeInfoListBalanced)
            {

                DataRow row = dtFee.NewRow();

                row["费用名称"] = this.feeManager.GetComDictionaryNameByID("MINFEE", feeInfo.Item.MinFee.ID);
                row["金额"] = feeInfo.FT.TotCost;
                row["自费"] = feeInfo.FT.OwnCost;
                row["公费"] = feeInfo.FT.PubCost;
                row["自负"] = feeInfo.FT.PayCost;
                row["优惠金额"] = feeInfo.FT.RebateCost;
                string temp = string.Empty;

                //if (feeInfo.BalanceState == "0")
                //{
                //    temp = "未结算";
                //}
                //else
                //{
                //    temp = "已结算";
                //}
                row["结算状态"] = "已结算";

                dtFee.Rows.Add(row);
            }
        }

        /// <summary>
        /// 获得患者结算信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void QueryPatientBalance(DateTime beginTime, DateTime endTime)
        {
            ArrayList balanceList = this.feeManager.QueryBalancesByInpatientNO(this.currentPatient.ID);
            if (balanceList == null)
            {
                MessageBox.Show(Language.Msg("获得患者费用结算出错!") + this.feeManager.Err);

                return;
            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.Balance balance in balanceList)
            {
                Neusoft.HISFC.Models.Base.Employee employeeObj = new Neusoft.HISFC.Models.Base.Employee();
                string temp = "";
                DataRow row = dtBalance.NewRow();

                row["发票号码"] = balance.Invoice.ID;
                row["预交金额"] = balance.FT.PrepayCost;
                row["总金额"] = balance.FT.TotCost;
                row["自费"] = balance.FT.OwnCost;
                row["公费"] = balance.FT.PubCost;
                row["自负"] = balance.FT.PayCost;
                row["优惠"] = balance.FT.RebateCost;
                row["返还金额"] = balance.FT.ReturnCost;
                row["补收金额"] = balance.FT.SupplyCost;
                row["结算时间"] = balance.BalanceOper.OperTime;
                employeeObj = this.personManager.GetPersonByID(balance.BalanceOper.ID);
                row["操作员"] = employeeObj.Name;
                row["结算类型"] = balance.BalanceType.Name;

                switch (balance.CancelType)
                {
                    case Neusoft.HISFC.Models.Base.CancelTypes.Valid:
                        temp = "正常结算";
                        break;
                    case Neusoft.HISFC.Models.Base.CancelTypes.LogOut:
                        temp = "结算召回";
                        break;
                    case Neusoft.HISFC.Models.Base.CancelTypes.Reprint:
                        temp = "发票重打";
                        break;

                }
                row["结算状态"] = temp;

                dtBalance.Rows.Add(row);
            }

            AddSumInfo(dtBalance, "发票号码", "合计:", "总金额", "自费", "公费", "自负", "优惠", "返还金额", "补收金额");
        }

        /// <summary>
        /// 添加合计
        /// </summary>
        /// <param name="table">当前DataTalbe</param>
        /// <param name="totName">合计的名称位置</param>
        /// <param name="disName">合剂的名称</param>
        /// <param name="sumColName">统计列的数组</param>
        public void AddSumInfo(DataTable table, string totName, string disName, params string[] sumColName)
        {
            DataRow sumRow = table.NewRow();

            sumRow[totName] = disName;

            foreach (string s in sumColName)
            {
                object sum = table.Compute("SUM(" + s + ")", "");
                sumRow[s] = sum;
            }

            table.Rows.Add(sumRow);
        }

        /// <summary>
        /// 初始化DataTable
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int InitDataTable()
        {
            Type str = typeof(String);
            Type date = typeof(DateTime);
            Type dec = typeof(Decimal);
            Type bo = typeof(bool);

            #region 住院主表信息

            if (System.IO.File.Exists(pathNameMainInfo))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNameMainInfo, dtMainInfo, ref dvMainInfo, this.fpMainInfo_Sheet1);

                dtMainInfo.PrimaryKey = new DataColumn[] { dtMainInfo.Columns["住院流水号"] };

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpMainInfo_Sheet1, pathNameMainInfo);

            }
            else
            {

                dtMainInfo.Columns.AddRange(new DataColumn[]{new DataColumn("住院流水号", str),
																new DataColumn("住院号", str),
																new DataColumn("姓名", str),
																new DataColumn("住院科室", str),
																new DataColumn("床号", str),
																new DataColumn("患者类别", str),
																new DataColumn("预交金(未结)", dec),
																new DataColumn("费用合计(未结)", dec),
																new DataColumn("余额", dec),
																new DataColumn("自费", dec),
																new DataColumn("自负", dec),
																new DataColumn("公费", dec),
																new DataColumn("入院日期", date),
																new DataColumn("在院状态", str),
																new DataColumn("出院日期", str),
																new DataColumn("预交金(已结)", dec),
																new DataColumn("费用合计(已结)", dec),
																new DataColumn("结算日期", date)/*,
																new DataColumn("医疗类别", str)*/});

                dtMainInfo.PrimaryKey = new DataColumn[] { dtMainInfo.Columns["住院流水号"] };

                dvMainInfo = new DataView(dtMainInfo);

                this.fpMainInfo_Sheet1.DataSource = dvMainInfo;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpMainInfo_Sheet1, pathNameMainInfo);
            }

            #endregion

            #region 药品明细信息

            if (System.IO.File.Exists(pathNameDrugList))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNameDrugList, dtDrugList, ref dvDrugList, this.fpDrugList_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpDrugList_Sheet1, pathNameDrugList);
            }
            else
            {
                dtDrugList.Columns.AddRange(new DataColumn[]{new DataColumn("药品名称", str),
																new DataColumn("规格", str),
																new DataColumn("单价", dec),
																new DataColumn("数量", dec),
																new DataColumn("付数", dec),
																new DataColumn("单位", str),
																new DataColumn("金额", dec),
																new DataColumn("自费", dec),
																new DataColumn("公费", dec),
																new DataColumn("自负", dec),
																new DataColumn("优惠", dec),
																new DataColumn("执行科室",str),
																new DataColumn("患者科室",str),
																new DataColumn("收费时间", str),
																new DataColumn("收费员", str),
																new DataColumn("发药时间", str),   
																new DataColumn("发药员", str),
				                                                new DataColumn("来源",str)});

                dvDrugList = new DataView(dtDrugList);

                this.fpDrugList_Sheet1.DataSource = dvDrugList;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpDrugList_Sheet1, pathNameDrugList);
            }

            #endregion

            #region 非药品明细信息
            if (System.IO.File.Exists(pathNameUndrugList))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNameUndrugList, dtUndrugList, ref dvUndrugList, this.fpUndrugList_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUndrugList_Sheet1, pathNameUndrugList);
            }
            else
            {
                dtUndrugList.Columns.AddRange(new DataColumn[]{new DataColumn("项目名称", str),
																  new DataColumn("单价", dec),
																  new DataColumn("数量", dec),
																  new DataColumn("单位", str),
																  new DataColumn("金额", dec),
																  new DataColumn("自费", dec),
																  new DataColumn("公费", dec),
																  new DataColumn("自负", dec),
																  new DataColumn("优惠", dec),
																  new DataColumn("执行科室", str),
																  new DataColumn("患者科室",str),
																  new DataColumn("收费时间", date),
																  new DataColumn("收费员", str),
				                                                  new DataColumn("来源", str)});

                dvUndrugList = new DataView(dtUndrugList);

                this.fpUndrugList_Sheet1.DataSource = dvUndrugList;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpUndrugList_Sheet1, pathNameUndrugList);
            }

            #endregion

            #region 预交金信息

            if (System.IO.File.Exists(pathNamePrepay))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNamePrepay, dtPrepay, ref dvPrepay, this.fpPrepay_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpPrepay_Sheet1, pathNamePrepay);
            }
            else
            {
                dtPrepay.Columns.AddRange(new DataColumn[]{new DataColumn("票据号", str),
															  new DataColumn("预交金额", dec),
															  new DataColumn("支付方式", str),
															  new DataColumn("操作员", str),
															  new DataColumn("操作日期", date),
															  new DataColumn("所在科室", str),
															  new DataColumn("结算状态", str),
															  new DataColumn("来源", str)});

                dvPrepay = new DataView(dtPrepay);

                this.fpPrepay_Sheet1.DataSource = dvPrepay;
                dvPrepay.Sort = "票据号 ASC";

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpPrepay_Sheet1, pathNamePrepay);
            }

            #endregion

            #region 最小费用信息

            if (System.IO.File.Exists(pathNameFee))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNameFee, dtFee, ref dvFee, this.fpFee_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpFee_Sheet1, pathNameFee);
            }
            else
            {
                dtFee.Columns.AddRange(new DataColumn[]{new DataColumn("费用名称", str),
														   new DataColumn("金额", dec),
														   new DataColumn("自费", dec),
														   new DataColumn("公费", dec),
														   new DataColumn("自负", dec),
														   new DataColumn("优惠金额", dec),
														   new DataColumn("结算状态", str)});

                dvFee = new DataView(dtFee);

                this.fpFee_Sheet1.DataSource = dvFee;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpFee_Sheet1, pathNameFee);
            }

            #endregion

            #region 结算信息
            if (System.IO.File.Exists(pathNameBalance))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(pathNameBalance, dtBalance, ref dvBalance, this.fpBalance_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpBalance_Sheet1, pathNameBalance);
            }
            else
            {
                dtBalance.Columns.AddRange(new DataColumn[]{new DataColumn("发票号码", str),
															   new DataColumn("结算类型", str),
															   new DataColumn("结算状态", str),
															   new DataColumn("预交金额", dec),
															   new DataColumn("总金额", dec),
															   new DataColumn("自费", dec),
															   new DataColumn("公费", dec),
															   new DataColumn("自负", dec),
															   new DataColumn("优惠", dec),
															   new DataColumn("返还金额", dec),
															   new DataColumn("补收金额", dec),
															   new DataColumn("结算时间", date),
															   new DataColumn("操作员", str)});

                dvBalance = new DataView(dtBalance);

                this.fpBalance_Sheet1.DataSource = dvBalance;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpBalance_Sheet1, pathNameBalance);
            }
            #endregion

            return 1;
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        protected void SetPatientInfo()
        {
            if (this.currentPatient == null || this.currentPatient.ID == null || this.currentPatient.ID == string.Empty)
            {
                return;
            }

            this.lblID.Text = this.currentPatient.PID.PatientNO;//住院号
            this.lblName.Text = this.currentPatient.Name;//姓名;
            this.lblSex.Text = this.currentPatient.Sex.Name;
            this.lblAge.Text = this.currentPatient.Age;
            this.lblBed.Text = this.currentPatient.PVisit.PatientLocation.Bed.ID;
            this.lblDept.Text = this.currentPatient.PVisit.PatientLocation.Dept.Name;
            this.lblPact.Text = this.currentPatient.Pact.Name;//合同单位
            this.lblDateIn.Text = this.currentPatient.PVisit.InTime.ToShortDateString();//住院日期
            if (this.currentPatient.PVisit.OutTime != DateTime.MinValue)
            {
                this.lblOutDate.Text = this.currentPatient.PVisit.OutTime.ToShortDateString();
            }
            this.lblInState.Text = this.currentPatient.PVisit.InState.Name;//在院状态
            decimal TotCost = this.currentPatient.FT.TotCost + this.currentPatient.FT.BalancedCost;
            //this.lblTotCost.Text = this.currentPatient.FT.TotCost.ToString();
            this.lblTotCost.Text = TotCost.ToString();

            this.lblOwnCost.Text = this.currentPatient.FT.OwnCost.ToString();
            this.lblPubCost.Text = this.currentPatient.FT.PubCost.ToString();
            this.lblPrepayCost.Text = this.currentPatient.FT.PrepayCost.ToString();
            this.lblUnBalanceCost.Text = this.currentPatient.FT.TotCost.ToString();
            this.lblBalancedCost.Text = this.currentPatient.FT.BalancedCost.ToString();
            this.lblFreeCost.Text = this.currentPatient.FT.LeftCost.ToString();
            this.lblDiagnose.Text = this.currentPatient.MainDiagnose;
            this.lblMemo.Text = this.currentPatient.Memo;

            //加入患者医保信息
            this.lblItemYLCost.Text = this.currentPatient.SIMainInfo.ItemYLCost.ToString();
            this.lblBaseCost.Text = this.currentPatient.SIMainInfo.BaseCost.ToString();
            this.lblItempaycost.Text = this.currentPatient.SIMainInfo.ItemPayCost.ToString();
            this.lblsipubcost.Text = this.currentPatient.SIMainInfo.SiPubCost.ToString();
            this.lblovercost.Text = this.currentPatient.SIMainInfo.OverCost.ToString();
            this.lblovertakeowncost.Text = this.currentPatient.SIMainInfo.OverTakeOwnCost.ToString();
            this.lblofficalcost.Text = this.currentPatient.SIMainInfo.OfficalCost.ToString();
            this.lblpaycost.Text = this.currentPatient.SIMainInfo.PayCost.ToString();
            this.lblcaowncost.Text = this.currentPatient.SIMainInfo.OwnCost.ToString();
        }

        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        protected void QueryAllInfomaition(DateTime beginTime, DateTime endTime)
        {
            this.QueryPatientDrugList(beginTime, endTime);

            this.QueryPatientUndrugList(beginTime, endTime);

            this.QueryPatientPrepayList(beginTime, endTime);

            this.QueryPatientFeeInfo(beginTime, endTime);

            this.QueryPatientBalance(beginTime, endTime);
        }

        /// <summary>
        /// 返回"_"
        /// </summary>
        /// <param name="langth">长度</param>
        /// <returns>成功 "---" 失败 null</returns>
        private string RetrunSplit(int langth)
        {
            string s = string.Empty;

            for (int i = 0; i < langth; i++)
            {
                s += "_";
            }

            return s;
        }

        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            this.lblID.Text = this.RetrunSplit(10);
            this.lblName.Text = this.RetrunSplit(5);
            this.lblSex.Text = this.RetrunSplit(4);
            this.lblAge.Text = this.RetrunSplit(4);
            this.lblBed.Text = this.RetrunSplit(10);
            this.lblDept.Text = this.RetrunSplit(10);
            this.lblPact.Text = this.RetrunSplit(10);
            this.lblDateIn.Text = this.RetrunSplit(10);
            this.lblOutDate.Text = this.RetrunSplit(10);

            this.lblInState.Text = this.RetrunSplit(6);
            this.lblTotCost.Text = this.RetrunSplit(10);
            this.lblOwnCost.Text = this.RetrunSplit(10);
            this.lblPubCost.Text = this.RetrunSplit(10);
            this.lblPrepayCost.Text = this.RetrunSplit(10);
            this.lblUnBalanceCost.Text = this.RetrunSplit(10);
            this.lblBalancedCost.Text = this.RetrunSplit(10);
            this.lblDiagnose.Text = this.RetrunSplit(20);
            this.lblMemo.Text = this.RetrunSplit(30);
            dtMainInfo.Rows.Clear();
            dtDrugList.Rows.Clear();
            dtUndrugList.Rows.Clear();
            dtPrepay.Rows.Clear();
            dtFee.Rows.Clear();
            dtBalance.Rows.Clear();
        }

        public void InitContr()
        {
            this.neuLabel21.Visible = false;
            this.lblOwnCost.Visible = false;
            this.neuLabel23.Visible = false;
            this.lblPubCost.Visible = false;
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.PatientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;

            return base.OnSetValue(neuObject, e);
        }

        #endregion

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPage(0, 0, this.neuTabControl1.SelectedTab);

            return base.OnPrint(sender, neuObject);
        }
        //打印预览
        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print printview = new Neusoft.FrameWork.WinForms.Classes.Print();

            printview.PrintPreview(0, 0, this.neuTabControl1.SelectedTab);
            return base.OnPrintPreview(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            object obj = this.hashTableFp[this.neuTabControl1.SelectedTab];

            FarPoint.Win.Spread.FpSpread fp = obj as FarPoint.Win.Spread.FpSpread;

            SaveFileDialog op = new SaveFileDialog();

            op.Title = "请选择保存的路径和名称";
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.DefaultExt = "*.xls";
            op.Filter = "(*.xls)|*.xls";

            DialogResult result = op.ShowDialog();

            if (result == DialogResult.Cancel || op.FileName == string.Empty)
            {
                return -1;
            }

            string filePath = op.FileName;

            bool returnValue = fp.SaveExcel(filePath, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);


            return base.Export(sender, neuObject);
        }

        private void ucPatientFeeQuery_Load(object sender, EventArgs e)
        {
            //this.InitDataTable();
            //this.InitContr();
        }

        private void fpMainInfo_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpMainInfo_Sheet1.RowCount <= 0)
            {
                return;
            }
            string inpatientNO = this.fpMainInfo_Sheet1.Cells[e.Row, 0].Text;

            if (inpatientNO == null)
            {
                return;
            }
            
            this.currentPatient = this.radtManager.LocalQueryPatientInfoByInpatientNO(inpatientNO);
            if (this.currentPatient == null || this.currentPatient.ID == null || this.currentPatient.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("查询患者基本信息出错!") + this.radtManager.Err);

                return;
            }

            this.SetPatientInfo();

            dtDrugList.Rows.Clear();
            dtUndrugList.Rows.Clear();
            dtPrepay.Rows.Clear();
            dtFee.Rows.Clear();
            dtBalance.Rows.Clear();

            //设置查询时间
            DateTime beginTime = this.currentPatient.PVisit.InTime;
            DateTime endTime = this.radtManager.GetDateTimeFromSysDateTime();

            this.QueryAllInfomaition(beginTime, endTime);

        }

        private void neuLabel24_Click(object sender, EventArgs e)
        {

        }

        private void lblMemo_Click(object sender, EventArgs e)
        {

        }

    }
}
