using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucPactUnitMaintenance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucPactUnitMaintenance()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 合同单位明细数据业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactUnitDetail = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();

        /// <summary>
        /// 合同单位基本信息
        /// </summary>
        DataTable dtMain = new DataTable();

        /// <summary>
        /// 合同单位基本信息视图
        /// </summary>
        DataView dvMain = new DataView();

        /// <summary>
        /// 最小费用
        /// </summary>
        DataView dvFee = new DataView();
        DataTable dtFee = new DataTable();

        /// <summary>
        /// 明细
        /// </summary>
        DataView dvDetail = new DataView();
        DataTable dtDetail = new DataTable();

        /// <summary>
        /// 合同单位基本信息设置
        /// </summary>
        private string mainSettingFilePath = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + @".\PactUnitMaintenance.xml";

        /// <summary>
        /// toolbarservice
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 医保待遇Dll路径
        /// </summary>
        protected string DllPath = Application.StartupPath + @"\Plugins\SI\";

        private bool isShowDllColumn = true;

        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IValidPactItemChoose iValidPactItemChoose = null;
        #endregion

        #region  属性
        [Category("设置"), Description("是否显示维护医保待遇DLL列")]
        public bool IsShowDllColumn
        {
            get
            {
                return isShowDllColumn;
            }
            set
            {
                isShowDllColumn = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化,请等待...");
            Application.DoEvents();
            //初始化合同单位主要信息
            if (InitDataTableMain() == -1)
            {
                return -1;
            }
            InitMainData();
            SetFrpColumnType();
            //初始化最小费用
            InitDataTableFee();
            InitDetail();
            InitInterFace();
            //初始化项目选择列表ucInputItem
            this.ucInputItem1.Init();
            this.ucInputItem1.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_SelectedItem);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 初始化维护的合同单位信息
        /// </summary>
        /// <returns>成功1 失败 -1</returns>
        private int InitMainData()
        {
            ArrayList pactList = this.pactManager.QueryPactUnitAll();
            this.dtMain.Clear();
            foreach (Neusoft.HISFC.Models.Base.PactInfo pactInfo in pactList)
            {
                DataRow row = this.dtMain.NewRow();

                row["单位代码"] = pactInfo.ID;
                row["单位名称"] = pactInfo.Name;
                row["结算类别"] = this.GetPayKindName(pactInfo.PayKind.ID);
                row["价格形式"] = pactInfo.PriceForm;
                row["公费比例"] = pactInfo.Rate.PubRate;
                row["自付比例"] = pactInfo.Rate.PayRate;
                row["自费比例"] = pactInfo.Rate.OwnRate;
                row["优惠比例"] = pactInfo.Rate.RebateRate;
                row["欠费比例"] = pactInfo.Rate.ArrearageRate;
                row["婴儿标志"] = pactInfo.Rate.IsBabyShared;
                row["是否监控"] = pactInfo.IsInControl;
                if (pactInfo.ItemType == "0")
                {
                    row["标志"] = "全部";
                }
                else if (pactInfo.ItemType == "1")
                {
                    row["标志"] = "药品";
                }
                else if (pactInfo.ItemType == "2")
                {
                    row["标志"] = "非药品";
                }
                row["需医疗证"] = pactInfo.IsNeedMCard;
                row["日限额"] = pactInfo.DayQuota;
                row["月限额"] = pactInfo.MonthQuota;
                row["年限额"] = pactInfo.YearQuota;
                row["一次限额"] = pactInfo.OnceQuota;
                row["床位上限"] = pactInfo.BedQuota;
                row["空调上限"] = pactInfo.AirConditionQuota;
                row["简称"] = pactInfo.ShortName;
                row["序号"] = pactInfo.SortID;
                row["待遇算法DLL"] = pactInfo.PactDllName;
                row["待遇算法DLL描述"] = pactInfo.PactDllDescription;
                this.dtMain.Rows.Add(row);
            }

            this.dtMain.AcceptChanges();

            return 1;

        }

        /// <summary>
        /// 初始化合同单位主要信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDataTableMain()
        {
            if (File.Exists(this.mainSettingFilePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.mainSettingFilePath, this.dtMain, ref this.dvMain, this.fpMain_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpMain_Sheet1, this.mainSettingFilePath);
            }
            else
            {
                this.dtMain.Columns.AddRange(new DataColumn[] 
                {
                    new DataColumn("单位代码", typeof(string)),
                    new DataColumn("单位名称", typeof(string)),
                    new DataColumn("结算类别", typeof(string)),
                    new DataColumn("价格形式", typeof(string)),
                    new DataColumn("公费比例", typeof(decimal)),
                    new DataColumn("自付比例", typeof(decimal)),
                    new DataColumn("自费比例", typeof(decimal)),
                    new DataColumn("优惠比例", typeof(decimal)),
                    new DataColumn("欠费比例", typeof(decimal)),
                    new DataColumn("婴儿标志", typeof(bool)),
                    new DataColumn("是否监控", typeof(bool)),
                    new DataColumn("标志", typeof(string)),
                    new DataColumn("需医疗证", typeof(bool)),
                    new DataColumn("日限额", typeof(decimal)),
                    new DataColumn("月限额", typeof(decimal)),
                    new DataColumn("年限额", typeof(decimal)),
                    new DataColumn("一次限额", typeof(decimal)),
                    new DataColumn("床位上限", typeof(decimal)),
                    new DataColumn("空调上限", typeof(decimal)),
                    new DataColumn("简称", typeof(string)),
                    new DataColumn("序号", typeof(int)),
                    new DataColumn("待遇算法DLL",typeof(string)),
                    new DataColumn("待遇算法DLL描述",typeof(string))
                });

                this.dvMain = new DataView(this.dtMain);

                this.fpMain_Sheet1.DataSource = this.dvMain;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpMain_Sheet1, this.mainSettingFilePath);
            }

            return 1;
        }

        /// <summary>
        /// 初始化最小费用
        /// </summary>
        private void InitDataTableFee()
        {
            this.dtFee.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("最小费用代码",typeof(string)),
                    new DataColumn("最小费用名称",typeof(string))
                });
            this.dvFee = new DataView(this.dtFee);
            this.fpFeeCode_Sheet1.DataSource = this.dvFee;

            ArrayList feeCode = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);

            foreach (Neusoft.HISFC.Models.Base.Const feeCodeCon in feeCode)
            {
                this.dtFee.Rows.Add(new object[]
                {
                    feeCodeCon.ID,
                    feeCodeCon.Name
                });
            }

        }

        /// <summary>
        /// 初始化明细表
        /// </summary>
        private void InitDetail()
        {
            this.dtDetail.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("单位代码",typeof(string)),
                    new DataColumn("费用/项目名称",typeof(string)),
                    new DataColumn("费用代码",typeof(string)),
                    new DataColumn("类别",typeof(string)),
                    new DataColumn("公费比例",typeof(decimal)),
                    new DataColumn("自费比例",typeof(decimal)),
                    new DataColumn("自付比例",typeof(decimal)),
                    new DataColumn("优惠比例",typeof(decimal)),//{65168F4D-B9D9-4386-BD0F-9DB780E74D60}
                    new DataColumn("欠费比例",typeof(decimal)),
                });
            this.dvDetail = new DataView(this.dtDetail);
            this.fpDetail_Sheet1.DataSource = this.dvDetail;
        }

        private void InitInterFace()
        {
            if (iValidPactItemChoose == null)
            {
                iValidPactItemChoose = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IValidPactItemChoose)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IValidPactItemChoose;
            }
        }

        /// <summary>
        /// 从常数表中添加合同单位
        /// </summary>
        private void AddPactUnitByCon()
        {

            #region 不再从数据字典取列表 {16C790A2-6158-487b-8AC5-2F6B4683CAE4} xuc
            //ArrayList mpactList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT);
            //DataTable dtMainCopy = this.dtMain;

            //foreach (Neusoft.HISFC.Models.Base.Const pactCon in mpactList)
            //{
            //    string t = string.Format("单位代码 = '{0}'", pactCon.ID);
            //    DataRow[] rows = dtMainCopy.Select(t);
            //    if (rows == null || rows.GetLength(0) == 0)
            //    {
            //        this.dtMain.Rows.Add(new object[]
            //        {
            //            pactCon.ID,
            //            pactCon.Name,
            //            "",
            //            "默认价",
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            false,
            //            false,
            //            "全部",
            //            false,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            0,
            //            "",
            //            0
            //        });

            //    }
            //}
            #endregion
            DataTable dtMainCopy = this.dtMain;
            this.dtMain.Rows.Add(new object[]
                    {
                        "",
                        "",
                        "",
                        "默认价",
                        0,
                        0,
                        0,
                        0,
                        0,
                        false,
                        false,
                        "全部",
                        false,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        "",
                        0
                    });

            //dtMainCopy.AcceptChanges();
            this.SetFrpColumnType();
            this.fpMain_Sheet1.Cells[this.dtMain.Rows.Count - 1, 0].Locked = false;
            this.fpMain_Sheet1.Cells[this.dtMain.Rows.Count - 1, 1].Locked = false;
            this.fpMain_Sheet1.SetActiveCell(this.dtMain.Rows.Count, 0);
            this.fpMain.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Bottom, FarPoint.Win.Spread.HorizontalPosition.Left);
        }

        /// <summary>
        /// 查询明细数据
        /// </summary>
        private void QueryPactUnitInfoDetail(string pactCode, int index)
        {
            ArrayList pactUnitDetailAList = this.pactUnitDetail.GetPactUnitItemRate(pactCode, index);

            this.dtDetail.Clear();

            foreach (Neusoft.HISFC.Models.Base.PactItemRate pactItemRate in pactUnitDetailAList)
            {
                dtDetail.Rows.Add(new object[]
                {
                    pactItemRate.ID,
                    pactItemRate.PactItem.Name,
                    pactItemRate.PactItem.ID,
                    pactItemRate.ItemType,
                    pactItemRate.Rate.PubRate,
                    pactItemRate.Rate.OwnRate,
                    pactItemRate.Rate.PayRate,
                    pactItemRate.Rate.RebateRate,//{65168F4D-B9D9-4386-BD0F-9DB780E74D60}
                    pactItemRate.Rate.ArrearageRate
                });
            }
            this.dtDetail.AcceptChanges();
        }

        /// <summary>
        /// 通过paykindcode查询paykindname
        /// </summary>
        /// <param name="payKindCode"></param>
        /// <returns></returns>
        private string GetPayKindName(string payKindCode)
        {
            ArrayList paykind = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND);
            string payKindName = string.Empty;
            foreach (Neusoft.HISFC.Models.Base.Const paykindCon in paykind)
            {
                if (paykindCon.ID.Trim() == payKindCode.Trim())
                {
                    payKindName = paykindCon.Name;
                    break;
                }
            }
            return payKindName;
        }

        /// <summary>
        /// 通过paykindname查询paykindcode
        /// </summary>
        /// <param name="payKindName"></param>
        /// <returns></returns>
        private string GetPayKindCode(string payKindName)
        {
            ArrayList paykind = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND);
            string payKindCode = string.Empty;
            foreach (Neusoft.HISFC.Models.Base.Const paykindCon in paykind)
            {
                if (paykindCon.Name.Trim() == payKindName.Trim())
                {
                    payKindCode = paykindCon.ID;
                    break;
                }
            }
            return payKindCode;
        }

        /// <summary>
        /// 设置farpoint列的下拉数据
        /// </summary>
        protected virtual void SetFrpColumnType()
        {
            //结算类别
            FarPoint.Win.Spread.CellType.ComboBoxCellType cbxPayKind = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            ArrayList paykind = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND);
            string[] paykindname = new string[paykind.Count];
            int i = 0;
            foreach (Neusoft.HISFC.Models.Base.Const paykindCon in paykind)
            {
                paykindname[i] = paykindCon.Name;

                ++i;
            }
            cbxPayKind.Items = paykindname;
            this.fpMain_Sheet1.Columns[2].CellType = cbxPayKind;
            //价格形式
            FarPoint.Win.Spread.CellType.ComboBoxCellType cbxPriceForm = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cbxPriceForm.Items = new string[] { "默认价", "特诊价", "儿童价" };
            this.fpMain_Sheet1.Columns[3].CellType = cbxPriceForm;
            //标志
            FarPoint.Win.Spread.CellType.ComboBoxCellType cbxItemType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cbxItemType.Items = new string[] { "全部", "药品", "非药品" };
            this.fpMain_Sheet1.Columns[11].CellType = cbxItemType;
            //设定只有当焦点在当前单元格上的时候才能显示下拉列表
            this.fpMain.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentCell;
            this.fpMain_Sheet1.Columns[0].Locked = true;
            this.fpMain_Sheet1.Columns[1].Locked = true;
            this.fpMain_Sheet1.Columns[20].Visible = false;

            #region 算法Dll
            //算法Dll
            string[] dllitems = this.GetDllName();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cbxDllName = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            if (dllitems != null)
                cbxDllName.Items = dllitems;
            this.fpMain_Sheet1.Columns[21].CellType = cbxDllName;
            this.fpMain_Sheet1.Columns[22].Locked = true;
            if (!isShowDllColumn)
            {
                this.fpMain_Sheet1.Columns[21].Visible = false;
                this.fpMain_Sheet1.Columns[22].Visible = false;
            }
            #endregion
        }

        #region 对照医保待遇DLL 路志鹏 2007-7-6

        /// <summary>
        /// 通过反射查找所有医保待遇DLL
        /// </summary>
        /// <returns></returns>
        protected virtual string[] GetDllName()
        {
            string[] sPath = Directory.GetFiles(DllPath);
            if (sPath.Length == 0)
                return null;
            List<string> list = new List<string>();
            foreach (string path in sPath)
            {
                FileInfo fi = new FileInfo(path);
                if (fi.Extension.ToLower() == ".dll")
                {
                    Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare im = GetDllInterface(path);
                    if (im == null)
                        continue;
                    list.Add(fi.Name);
                }
            }
            if (list.Count == 0)
                return null;
            return list.ToArray();
        }

        /// <summary>
        /// 根据Dll查找dll描述
        /// </summary>
        /// <param name="path">dll路径</param>
        /// <returns></returns>
        protected virtual Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare GetDllInterface(string path)
        {
            try
            {
                System.Reflection.Assembly assmbly = System.Reflection.Assembly.LoadFile(path);
                Type[] t = assmbly.GetTypes();
                if (t == null)
                    return null;
                foreach (Type type in t)
                {
                    if (type.GetInterface("IMedcare") != null)
                    {
                        return (Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)System.Activator.CreateInstance(type);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        /// <summary>
        /// 校验合同单位是否变化
        /// </summary>
        /// <returns></returns>
        private bool IsMainDataChange()
        {
            DataTable dtMainAdd = this.dtMain.GetChanges(System.Data.DataRowState.Added);
            DataTable dtMainMod = this.dtMain.GetChanges(System.Data.DataRowState.Modified);
            if (dtMainAdd != null || dtMainMod != null)
            {
                DialogResult result;
                result = MessageBox.Show("是否保存刚才改动过的数据？", "保存", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    this.InitMainData();
                    this.SetFrpColumnType();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 校验明细数据是否有变化
        /// </summary>
        private bool IsDetailDataChange()
        {
            DataTable dtDetailAdd = this.dtDetail.GetChanges(System.Data.DataRowState.Added);
            DataTable dtDetailDel = this.dtDetail.GetChanges(System.Data.DataRowState.Deleted);
            DataTable dtDetailMod = this.dtDetail.GetChanges(System.Data.DataRowState.Modified);

            if (dtDetailAdd != null || dtDetailDel != null || dtDetailMod != null)
            {
                DialogResult result;
                result = MessageBox.Show("是否保存刚才改动过的数据？", "保存", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查选中的数据是否已经维护
        /// </summary>
        /// <returns></returns>
        private bool IsExistData(string itemCode)
        {
            int rowCount = 0;
            rowCount = this.fpDetail_Sheet1.RowCount;
            bool isExist = true;
            if (rowCount > 0)
            {
                string tmpCode = string.Empty;
                for (int i = 0; i < rowCount; i++)
                {
                    tmpCode = fpDetail_Sheet1.GetText(i, 2).ToString().Trim();
                    if (tmpCode == itemCode)
                    {
                        isExist = true;
                        break;
                    }
                    else
                    {
                        isExist = false;
                    }
                }
            }
            else
            {
                isExist = false;
            }
            return isExist;
        }

        /// <summary>
        /// 删除明细数据
        /// </summary>
        private void DeleteDetail()
        {
            DialogResult result;
            //删除合同单位维护信息 {16C790A2-6158-487b-8AC5-2F6B4683CAE4} xuc
            result = MessageBox.Show("是否要删除这一行数据,删除合同单位信息同时将删除维护的明细信息？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (this.neuTabControl1.SelectedIndex == 1)
                {
                    if (this.fpDetail_Sheet1.Rows.Count > 0)
                    {
                        this.fpDetail_Sheet1.Rows.Remove(this.fpDetail_Sheet1.ActiveRowIndex, 1);
                    }
                }
                else
                {
                    //删除合同单位维护信息 {16C790A2-6158-487b-8AC5-2F6B4683CAE4} xuc
                    if (this.fpMain_Sheet1.Rows.Count > 0)
                    {
                        this.fpMain_Sheet1.Rows.Remove(this.fpMain_Sheet1.ActiveRowIndex, 1);
                    }

                    DataTable dtDeletePact = this.dtMain.GetChanges(System.Data.DataRowState.Deleted);
                    if (dtDeletePact != null)
                    {
                        dtDeletePact.RejectChanges();

                        //事务
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        this.pactUnitDetail.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.pactManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        foreach (DataRow row in dtDeletePact.Rows)
                        {
                            Neusoft.HISFC.Models.Base.PactInfo pactInfo = new Neusoft.HISFC.Models.Base.PactInfo();
                            #region
                            pactInfo.ID = row["单位代码"].ToString();
                            pactInfo.Name = row["单位名称"].ToString();
                            pactInfo.PayKind.ID = row["结算类别"].ToString();
                            pactInfo.PriceForm = row["价格形式"].ToString();
                            pactInfo.Rate.PubRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["公费比例"].ToString());
                            pactInfo.Rate.PayRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["自付比例"].ToString());
                            pactInfo.Rate.OwnRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["自费比例"].ToString());
                            pactInfo.Rate.RebateRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["优惠比例"].ToString());
                            pactInfo.Rate.ArrearageRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["欠费比例"].ToString());
                            pactInfo.Rate.IsBabyShared = (bool)row["婴儿标志"];
                            pactInfo.IsInControl = (bool)row["是否监控"];
                            if (row["标志"].ToString() == "全部")
                            {
                                pactInfo.ItemType = "0";
                            }
                            else if (row["标志"].ToString() == "药品")
                            {
                                pactInfo.ItemType = "1";
                            }
                            else if (row["标志"].ToString() == "非药品")
                            {
                                pactInfo.ItemType = "2";
                            }
                            pactInfo.IsNeedMCard = (bool)row["需医疗证"];
                            pactInfo.DayQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["日限额"].ToString());
                            pactInfo.MonthQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["月限额"].ToString());
                            pactInfo.YearQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["年限额"].ToString());
                            pactInfo.OnceQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["一次限额"].ToString());
                            pactInfo.BedQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["床位上限"].ToString());
                            pactInfo.AirConditionQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["空调上限"].ToString());
                            pactInfo.ShortName = row["简称"].ToString();
                            pactInfo.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(row["序号"].ToString());
                            pactInfo.PactDllName = row["待遇算法DLL"].ToString();
                            pactInfo.PactDllDescription = row["待遇算法DLL描述"].ToString();
                            #endregion
                            if (this.pactManager.DeletePactUnitInfo(pactInfo) <= 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("删除合同单位信息出错！\n" + this.pactManager.Err, "提示");
                                InitMainData();
                                return;
                            }

                            ArrayList pactUnitDetailAListFee = this.pactUnitDetail.GetPactUnitItemRate(pactInfo.ID, 0);
                            ArrayList pactUnitDetailAListItem = this.pactUnitDetail.GetPactUnitItemRate(pactInfo.ID, 1);

                            if (pactUnitDetailAListFee != null)
                            {
                                if (pactUnitDetailAListItem != null)
                                {
                                    pactUnitDetailAListFee.AddRange(pactUnitDetailAListItem.ToArray());
                                }
                                foreach (Neusoft.HISFC.Models.Base.PactItemRate pactItemRate in pactUnitDetailAListFee)
                                {
                                    if (this.pactUnitDetail.DeletePactUnitItemRate(pactItemRate) <= 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        MessageBox.Show("删除合同单位明细信息出错！\n" + this.pactUnitDetail.Err, "提示");
                                        InitMainData();
                                        return;
                                    }
                                }
                            }
                        }

                        this.dtMain.AcceptChanges();
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        MessageBox.Show("删除合同单位信息成功！", "提示");
                        InitMainData();
                    }



                }
            }
        }

        /// <summary>
        /// ucinputitem控件返回的item添加到明细列表中
        /// </summary>
        /// <param name="sender"></param>
        void ucInputItem1_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            Neusoft.HISFC.Models.Base.Item item = sender as Neusoft.HISFC.Models.Base.Item;
            string pactCode = string.Empty;
            pactCode = this.fpMain_Sheet1.GetText(this.fpMain_Sheet1.ActiveRowIndex, 0).ToString().Trim();

            //合同单位优惠项目维护验证
            if (iValidPactItemChoose != null)
            {
                string errText = string.Empty;
                bool bValue = iValidPactItemChoose.ValidPactItemChoose(pactCode, item, ref errText);
                if (!bValue)
                {
                    MessageBox.Show(errText);
                    return;
                }
            }

            if (this.IsExistData(item.ID))
            {
                MessageBox.Show("此项目已在明细列表中", "提示");
                return;
            }
            else
            {
                if (item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                {
                    dtDetail.Rows.Add(new object[]
                    {
                        pactCode,
                        item.Name,
                        item.ID,
                        "1",
                        0,
                        0,
                        0,
                        0,
                        0
                    });
                }
                else
                {
                    dtDetail.Rows.Add(new object[]
                    {
                        pactCode,
                        item.Name,
                        item.ID,
                        "2",
                        0,
                        0,
                        0,
                        0,
                        0
                    });
                }
            }
        }

        /// <summary>
        /// 保存合同单位明细
        /// </summary>
        private void SavePactUnitDetail()
        {
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.pactUnitDetail.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int sqlResult = 0;
            string errorText = string.Empty;
            this.fpDetail.StopCellEditing();
            //insert
            DataTable dtDetailAdd = this.dtDetail.GetChanges(System.Data.DataRowState.Added);

            if (dtDetailAdd != null)
            {
                foreach (DataRow rowAdd in dtDetailAdd.Rows)
                {
                    Neusoft.HISFC.Models.Base.PactItemRate pactItemRate = new Neusoft.HISFC.Models.Base.PactItemRate();

                    pactItemRate.ID = rowAdd["单位代码"].ToString().Trim();
                    pactItemRate.PactItem.Name = rowAdd["费用/项目名称"].ToString().Trim();
                    pactItemRate.PactItem.ID = rowAdd["费用代码"].ToString().Trim();
                    pactItemRate.ItemType = rowAdd["类别"].ToString().Trim();
                    pactItemRate.Rate.PubRate = Convert.ToDecimal(rowAdd["公费比例"].ToString().Trim());
                    pactItemRate.Rate.OwnRate = Convert.ToDecimal(rowAdd["自费比例"].ToString().Trim());
                    pactItemRate.Rate.PayRate = Convert.ToDecimal(rowAdd["自付比例"].ToString().Trim());
                    pactItemRate.Rate.RebateRate = Convert.ToDecimal(rowAdd["优惠比例"].ToString().Trim());//{65168F4D-B9D9-4386-BD0F-9DB780E74D60}
                    pactItemRate.Rate.ArrearageRate = Convert.ToDecimal(rowAdd["欠费比例"].ToString().Trim());

                    rowAdd.AcceptChanges();
                    try
                    {
                        sqlResult = this.pactUnitDetail.InsertPactUnitItemRate(pactItemRate);
                        if (sqlResult == -1)
                        {
                            break;
                        }
                    }
                    catch (Exception ee)
                    {
                        errorText = ee.Message;
                    }
                    pactItemRate = null;
                }
            }
            //delete
            DataTable dtDetailDel = this.dtDetail.GetChanges(System.Data.DataRowState.Deleted);

            if (dtDetailDel != null)
            {
                dtDetailDel.RejectChanges();
                foreach (DataRow rowDel in dtDetailDel.Rows)
                {
                    Neusoft.HISFC.Models.Base.PactItemRate pactItemRate = new Neusoft.HISFC.Models.Base.PactItemRate();

                    pactItemRate.ID = rowDel["单位代码"].ToString().Trim();
                    pactItemRate.PactItem.Name = rowDel["费用/项目名称"].ToString().Trim();
                    pactItemRate.PactItem.ID = rowDel["费用代码"].ToString().Trim();
                    pactItemRate.ItemType = rowDel["类别"].ToString().Trim();
                    pactItemRate.Rate.PubRate = Convert.ToDecimal(rowDel["公费比例"].ToString().Trim());
                    pactItemRate.Rate.OwnRate = Convert.ToDecimal(rowDel["自费比例"].ToString().Trim());
                    pactItemRate.Rate.PayRate = Convert.ToDecimal(rowDel["自付比例"].ToString().Trim());
                    pactItemRate.Rate.RebateRate = Convert.ToDecimal(rowDel["优惠比例"].ToString().Trim());//{65168F4D-B9D9-4386-BD0F-9DB780E74D60}
                    pactItemRate.Rate.ArrearageRate = Convert.ToDecimal(rowDel["欠费比例"].ToString().Trim());

                    rowDel.AcceptChanges();
                    try
                    {
                        sqlResult = this.pactUnitDetail.DeletePactUnitItemRate(pactItemRate);
                        if (sqlResult == -1)
                        {
                            break;
                        }
                    }
                    catch (Exception ee)
                    {
                        errorText = ee.Message;
                    }
                    pactItemRate = null;
                }
            }
            #region 屏蔽更新，用farpoint写
            //#region//update
            //DataTable dtDetailMod = this.dtDetail.GetChanges(System.Data.DataRowState.Modified);
            //if (dtDetailMod != null)
            //{
            //    foreach (DataRow rowMod in dtDetailMod.Rows)
            //    {
            //        Neusoft.HISFC.Models.Base.PactItemRate pactItemRate = new Neusoft.HISFC.Models.Base.PactItemRate();

            //        pactItemRate.ID = rowMod["单位代码"].ToString().Trim();
            //        pactItemRate.PactItem.Name = rowMod["费用/项目名称"].ToString().Trim();
            //        pactItemRate.PactItem.ID = rowMod["费用代码"].ToString().Trim();
            //        pactItemRate.ItemType = rowMod["类别"].ToString().Trim();
            //        pactItemRate.Rate.PubRate = Convert.ToDecimal(rowMod["公费比例"].ToString().Trim());
            //        pactItemRate.Rate.OwnRate = Convert.ToDecimal(rowMod["自费比例"].ToString().Trim());
            //        pactItemRate.Rate.PayRate = Convert.ToDecimal(rowMod["自付比例"].ToString().Trim());
            //        pactItemRate.Rate.DerateRate = Convert.ToDecimal(rowMod["减免比例"].ToString().Trim());
            //        pactItemRate.Rate.ArrearageRate = Convert.ToDecimal(rowMod["欠费比例"].ToString().Trim());

            //        rowMod.AcceptChanges();
            //        try
            //        {
            //            sqlResult = this.pactUnitDetail.UpdatePactUnitItemRate(pactItemRate);
            //            if (sqlResult == -1)
            //            {
            //                break;
            //            }
            //        }
            //        catch (Exception ee)
            //        {
            //            errorText = ee.Message;
            //        }
            //        pactItemRate = null;
            //    }
            //}
            //#endregion
            #endregion

            #region 用farpoint实现更新
            Neusoft.HISFC.Models.Base.PactItemRate pactItemRateUpdate = new Neusoft.HISFC.Models.Base.PactItemRate();
            for (int i = 0; i < this.fpDetail_Sheet1.Rows.Count; i++)
            {
                pactItemRateUpdate.ID = this.fpDetail_Sheet1.Cells[i, 0].Value.ToString().Trim();//单位代码
                pactItemRateUpdate.PactItem.Name = this.fpDetail_Sheet1.Cells[i, 1].Value.ToString().Trim();//费用/项目名称
                pactItemRateUpdate.PactItem.ID = this.fpDetail_Sheet1.Cells[i, 2].Value.ToString().Trim();//费用代码
                pactItemRateUpdate.ItemType = this.fpDetail_Sheet1.Cells[i, 3].Value.ToString().Trim();//类别
                pactItemRateUpdate.Rate.PubRate = Convert.ToDecimal(this.fpDetail_Sheet1.Cells[i, 4].Value.ToString().Trim());//公费比例
                pactItemRateUpdate.Rate.OwnRate = Convert.ToDecimal(this.fpDetail_Sheet1.Cells[i, 5].Value.ToString().Trim());//自费比例
                pactItemRateUpdate.Rate.PayRate = Convert.ToDecimal(this.fpDetail_Sheet1.Cells[i, 6].Value.ToString().Trim());//自付比例
                pactItemRateUpdate.Rate.RebateRate = Convert.ToDecimal(this.fpDetail_Sheet1.Cells[i, 7].Value.ToString().Trim());//优惠比例{65168F4D-B9D9-4386-BD0F-9DB780E74D60}
                pactItemRateUpdate.Rate.ArrearageRate = Convert.ToDecimal(this.fpDetail_Sheet1.Cells[i, 8].Value.ToString().Trim());//欠费比例
                try
                {
                    sqlResult = this.pactUnitDetail.UpdatePactUnitItemRate(pactItemRateUpdate);
                    if (sqlResult == 0)
                    {
                        sqlResult = this.pactUnitDetail.InsertPactUnitItemRate(pactItemRateUpdate);
                        if (sqlResult == -1)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ee)
                {
                    errorText = ee.Message;
                }
            }
            #endregion
            if (sqlResult == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存数据失败！" + errorText);
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.dtDetail.AcceptChanges();
                MessageBox.Show("保存成功！");
            }
        }

        private bool Valid()
        {
            for (int i = 0; i < this.fpMain_Sheet1.Rows.Count; i++)
            {
                if (this.fpMain_Sheet1.Cells[i, 2].Text.Trim() == string.Empty)
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "结算类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存合同单位
        /// </summary>
        private void SavePactUnit()
        {
            if (!Valid())
                return;
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.pactManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int sqlResult = 0;
            string errorText = string.Empty;
            this.fpMain.StopCellEditing();
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                this.dtMain.Rows[i].EndEdit();
            }
            //insert
            DataTable dtMainAdd = this.dtMain.GetChanges(System.Data.DataRowState.Added);
            if (dtMainAdd != null)
            {
                foreach (DataRow rowAdd in dtMainAdd.Rows)
                {
                    Neusoft.HISFC.Models.Base.PactInfo pactInfoAdd = new Neusoft.HISFC.Models.Base.PactInfo();

                    pactInfoAdd.ID = rowAdd["单位代码"].ToString().Trim();
                    pactInfoAdd.Name = rowAdd["单位名称"].ToString().Trim();
                    pactInfoAdd.PayKind.ID = this.GetPayKindCode(rowAdd["结算类别"].ToString().Trim());
                    if (rowAdd["价格形式"].ToString().Trim() == "默认价")
                    {
                        pactInfoAdd.PriceForm = "0";
                    }
                    else if (rowAdd["价格形式"].ToString().Trim() == "特诊价")
                    {
                        pactInfoAdd.PriceForm = "1";
                    }
                    else if (rowAdd["价格形式"].ToString().Trim() == "儿童价")
                    {
                        pactInfoAdd.PriceForm = "2";
                    }
                    else
                    {
                        pactInfoAdd.PriceForm = "0";
                    }
                    //pactInfoAdd.PriceForm = rowAdd["价格形式"].ToString().Trim();
                    pactInfoAdd.Rate.PubRate = Convert.ToDecimal(rowAdd["公费比例"].ToString().Trim());
                    pactInfoAdd.Rate.PayRate = Convert.ToDecimal(rowAdd["自付比例"].ToString().Trim());
                    pactInfoAdd.Rate.OwnRate = Convert.ToDecimal(rowAdd["自费比例"].ToString().Trim());
                    pactInfoAdd.Rate.RebateRate = Convert.ToDecimal(rowAdd["优惠比例"].ToString().Trim());
                    pactInfoAdd.Rate.ArrearageRate = Convert.ToDecimal(rowAdd["欠费比例"].ToString().Trim());
                    pactInfoAdd.Rate.IsBabyShared = Convert.ToBoolean(rowAdd["婴儿标志"]);
                    pactInfoAdd.IsInControl = Convert.ToBoolean(rowAdd["是否监控"]);
                    if (rowAdd["标志"].ToString().Trim() == "全部")
                    {
                        pactInfoAdd.ItemType = "0";
                    }
                    else if (rowAdd["标志"].ToString().Trim() == "药品")
                    {
                        pactInfoAdd.ItemType = "1";
                    }
                    else if (rowAdd["标志"].ToString().Trim() == "非药品")
                    {
                        pactInfoAdd.ItemType = "2";
                    }
                    else
                    {
                        pactInfoAdd.ItemType = "0";
                    }
                    pactInfoAdd.IsNeedMCard = Convert.ToBoolean(rowAdd["需医疗证"]);
                    pactInfoAdd.DayQuota = Convert.ToDecimal(rowAdd["日限额"].ToString().Trim());
                    pactInfoAdd.MonthQuota = Convert.ToDecimal(rowAdd["月限额"].ToString().Trim());
                    pactInfoAdd.YearQuota = Convert.ToDecimal(rowAdd["年限额"].ToString().Trim());
                    pactInfoAdd.OnceQuota = Convert.ToDecimal(rowAdd["一次限额"].ToString().Trim());
                    pactInfoAdd.BedQuota = Convert.ToDecimal(rowAdd["床位上限"].ToString().Trim());
                    pactInfoAdd.AirConditionQuota = Convert.ToDecimal(rowAdd["空调上限"].ToString().Trim());
                    pactInfoAdd.ShortName = rowAdd["简称"].ToString().Trim();
                    pactInfoAdd.SortID = Convert.ToInt32(rowAdd["序号"].ToString().Trim());
                    pactInfoAdd.PactDllName = rowAdd["待遇算法DLL"].ToString().Trim();
                    pactInfoAdd.PactDllDescription = rowAdd["待遇算法DLL描述"].ToString().Trim();

                    rowAdd.AcceptChanges();
                    try
                    {
                        sqlResult = this.pactManager.InsertPactUnitInfo(pactInfoAdd);
                        if (sqlResult == -1)
                        {
                            break;
                        }
                    }
                    catch (Exception ee)
                    {
                        errorText = ee.Message;
                    }
                    pactInfoAdd = null;
                }
            }
            //update
            DataTable dtMainMod = this.dtMain.GetChanges(System.Data.DataRowState.Modified);
            if (dtMainMod != null)
            {
                foreach (DataRow rowMod in dtMainMod.Rows)
                {
                    Neusoft.HISFC.Models.Base.PactInfo pactInfoMod = new Neusoft.HISFC.Models.Base.PactInfo();

                    pactInfoMod.ID = rowMod["单位代码"].ToString().Trim();
                    pactInfoMod.Name = rowMod["单位名称"].ToString().Trim();
                    pactInfoMod.PayKind.ID = this.GetPayKindCode(rowMod["结算类别"].ToString().Trim());
                    if (rowMod["价格形式"].ToString().Trim() == "默认价")
                    {
                        pactInfoMod.PriceForm = "0";
                    }
                    else if (rowMod["价格形式"].ToString().Trim() == "特诊价")
                    {
                        pactInfoMod.PriceForm = "1";
                    }
                    else if (rowMod["价格形式"].ToString().Trim() == "儿童价")
                    {
                        pactInfoMod.PriceForm = "2";
                    }
                    else
                    {
                        pactInfoMod.PriceForm = "0";
                    }
                    //pactInfoMod.PriceForm = rowMod["价格形式"].ToString().Trim();
                    pactInfoMod.Rate.PubRate = Convert.ToDecimal(rowMod["公费比例"].ToString().Trim());
                    pactInfoMod.Rate.PayRate = Convert.ToDecimal(rowMod["自付比例"].ToString().Trim());
                    pactInfoMod.Rate.OwnRate = Convert.ToDecimal(rowMod["自费比例"].ToString().Trim());
                    pactInfoMod.Rate.RebateRate = Convert.ToDecimal(rowMod["优惠比例"].ToString().Trim());
                    pactInfoMod.Rate.ArrearageRate = Convert.ToDecimal(rowMod["欠费比例"].ToString().Trim());
                    pactInfoMod.Rate.IsBabyShared = Convert.ToBoolean(rowMod["婴儿标志"]);
                    pactInfoMod.IsInControl = Convert.ToBoolean(rowMod["是否监控"]);
                    if (rowMod["标志"].ToString().Trim() == "全部")
                    {
                        pactInfoMod.ItemType = "0";
                    }
                    else if (rowMod["标志"].ToString().Trim() == "药品")
                    {
                        pactInfoMod.ItemType = "1";
                    }
                    else if (rowMod["标志"].ToString().Trim() == "非药品")
                    {
                        pactInfoMod.ItemType = "2";
                    }
                    else
                    {
                        pactInfoMod.ItemType = "0";
                    }
                    pactInfoMod.IsNeedMCard = Convert.ToBoolean(rowMod["需医疗证"]);
                    pactInfoMod.DayQuota = Convert.ToDecimal(rowMod["日限额"].ToString().Trim());
                    pactInfoMod.MonthQuota = Convert.ToDecimal(rowMod["月限额"].ToString().Trim());
                    pactInfoMod.YearQuota = Convert.ToDecimal(rowMod["年限额"].ToString().Trim());
                    pactInfoMod.OnceQuota = Convert.ToDecimal(rowMod["一次限额"].ToString().Trim());
                    pactInfoMod.BedQuota = Convert.ToDecimal(rowMod["床位上限"].ToString().Trim());
                    pactInfoMod.AirConditionQuota = Convert.ToDecimal(rowMod["空调上限"].ToString().Trim());
                    pactInfoMod.ShortName = rowMod["简称"].ToString().Trim();
                    pactInfoMod.SortID = Convert.ToInt32(rowMod["序号"].ToString().Trim());
                    pactInfoMod.PactDllName = rowMod["待遇算法DLL"].ToString().Trim();
                    pactInfoMod.PactDllDescription = rowMod["待遇算法DLL描述"].ToString().Trim();
                    rowMod.AcceptChanges();
                    try
                    {
                        sqlResult = this.pactManager.UpdatePactUnitInfo(pactInfoMod);
                        if (sqlResult == -1)
                        {
                            break;
                        }
                    }
                    catch (Exception ee)
                    {
                        errorText = ee.Message;
                    }
                    pactInfoMod = null;
                }
            }

            if (sqlResult == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存数据失败！" + errorText);
                this.SetFrpColumnType();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.dtMain.AcceptChanges();
                //删除合同单位维护信息 {16C790A2-6158-487b-8AC5-2F6B4683CAE4} xuc
                this.InitMainData();
                this.SetFrpColumnType();
                MessageBox.Show("保存成功！");
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                this.SavePactUnit();
            }
            else
            {
                this.SavePactUnitDetail();
            }
        }

        /// <summary>
        /// 添加toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加", "从常数表添加信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除选中明细信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 重载toolbarservice的save按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return base.OnSave(sender, neuObject);
        }

        #endregion

        #region 事件
        private void ucPactUnitMaintenance_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsMainDataChange())
            {
                this.SavePactUnit();
            }
            else
            {
                this.dtMain.RejectChanges();
            }
            if (this.IsDetailDataChange())
            {
                this.SavePactUnitDetail();
            }

            int row = this.fpMain_Sheet1.ActiveRowIndex;
            string pactCode = this.fpMain_Sheet1.GetText(row, 0).ToString().Trim();
            this.QueryPactUnitInfoDetail(pactCode, this.neuTabControl2.SelectedIndex);
        }

        private void neuTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsDetailDataChange())
            {
                this.SavePactUnitDetail();
            }
            int row = this.fpMain_Sheet1.ActiveRowIndex;
            string pactCode = this.fpMain_Sheet1.GetText(row, 0).ToString().Trim();
            this.QueryPactUnitInfoDetail(pactCode, this.neuTabControl2.SelectedIndex);
        }

        private void fpFeeCode_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string pactCode = string.Empty;
            string itemCode = string.Empty;
            string itemName = string.Empty;
            pactCode = this.fpMain_Sheet1.GetText(this.fpMain_Sheet1.ActiveRowIndex, 0).ToString().Trim();
            itemCode = this.fpFeeCode_Sheet1.GetText(this.fpFeeCode_Sheet1.ActiveRowIndex, 0).ToString().Trim();
            itemName = this.fpFeeCode_Sheet1.GetText(this.fpFeeCode_Sheet1.ActiveRowIndex, 1).ToString().Trim();
            if (this.IsExistData(itemCode))
            {
                MessageBox.Show("此费用已在明细列表中", "提示");
                return;
            }
            else
            {
                dtDetail.Rows.Add(new object[]
                {
                    pactCode,
                    itemName,
                    itemCode,
                    "0",
                    0,
                    0,
                    0,
                    0,
                    0
                });
            }
        }

        private void fpMain_EditModeOff(object sender, EventArgs e)
        {
            if (this.fpMain_Sheet1.ActiveColumnIndex == 21)
            {
                string spath = this.DllPath + "\\" + this.fpMain_Sheet1.ActiveCell.Text.Trim();
                if (spath != string.Empty)
                {
                    Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare im = this.GetDllInterface(spath);
                    if (im != null)
                        this.fpMain_Sheet1.Cells[this.fpMain_Sheet1.ActiveRowIndex, 22].Text = im.Description;
                }
            }
        }
        #endregion

        #region 公有方法

        /// <summary>
        /// toolbarclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加":
                    this.AddPactUnitByCon();
                    break;
                case "删除":
                    this.DeleteDetail();
                    break;

            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion



        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get 
            {
                Type[] t = new Type[1];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IValidPactItemChoose);
                return t;
            }
        }

        #endregion
    }
}
