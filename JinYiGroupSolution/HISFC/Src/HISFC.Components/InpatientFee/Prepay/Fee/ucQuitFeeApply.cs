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
    /// [功能描述: 住院退费申请]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQuitFeeApply : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucQuitFeeApply()
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
        public bool isCanQuitOtherFee = true;
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

        /// <summary>
        /// 操作员科室
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否直接进行退费操作
        /// </summary>
        protected bool isDirBackFee = false;
        /// <summary>
        /// 物资收费
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Material.Material mateInteger = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
        /// <summary>
        /// 物资信息
        /// </summary>
        private DataTable dtMate = new DataTable();

        /// <summary>
        /// 本科室是否直接退费
        /// //{0FAD327F-9954-442a-B3A2-EA79629EB7B2} ModifyBy 赵景
        /// </summary>
        private bool isMyDeptDirQuitFee = false;

        /// <summary>
        /// 是否允许退其他操作员费用
        /// {097418EF-9E96-48d4-9E6C-46CCC111C78C} ModifyBy 赵景
        /// </summary>
        private bool isCanQuitOtherOperator = true;

        /// <summary>
        /// 复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        protected bool isCombItemAllQuit = false;
        //{F4912030-EF65-4099-880A-8A1792A3B449}结束

        #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
        /// 存储退费项目
        /// </summary>
        protected ArrayList arr;

        protected Neusoft.HISFC.BizProcess.Interface.Pharmacy.ICompoundPrint ICompoundPrintQuitFee = null;

        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(); 
        #endregion

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

        /// <summary>
        /// 是否直接进行退费操作
        /// </summary>
        public bool IsDirQuitFee
        {
            get
            {
                return this.isDirBackFee;
            }
            set
            {
                this.isDirBackFee = value;
            }
        }

        /// <summary>
        /// 是否允许退其他操作员费用
        /// {097418EF-9E96-48d4-9E6C-46CCC111C78C} ModifyBy 赵景
        /// </summary>
        [Category("控件设置"), Description("是否允许退其他操作员费用，True:可以 False:不可以")]
        public bool IsCanQuitOtherOperator
        {
            get
            {
                return this.isCanQuitOtherOperator;
            }
            set
            {
                this.isCanQuitOtherOperator = value;
            }
        }

        bool isOutTerminalDept = false;
        /// <summary>
        /// 是否允许退其他操作员费用
        /// {097418EF-9E96-48d4-9E6C-46CCC111C78C} ModifyBy 赵景
        /// </summary>
        [Category("控件设置"), Description("是否排除终端科室，True:可以 False:不可以")]
        public bool IsOutTerminalDept
        {
            get
            {
                return this.isOutTerminalDept;
            }
            set
            {
                this.isOutTerminalDept = value;
            }
        }

        #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
        bool isPrintApplyBill = false;
        [Category("控件设置"), Description("是否打印退费申请单 True:打印 False:不打印")]
        public bool IsPrintApplyBill
        {
            get
            {
                return isPrintApplyBill;
            }
            set
            {
                isPrintApplyBill = value;
            }
        }
        //{60137B80-188F-4311-A160-6746A92ACD5C}
        bool isShowQueryFeeApplyInfo = true;
        [Category("控件设置"), Description("是否显示退费明细 True:显示 False:不显示"),DefaultValue(true)]
        public bool IsShowQueryFeeApplyInfo
        {
            get
            {
                return isShowQueryFeeApplyInfo;
            }
            set
            {
                isShowQueryFeeApplyInfo = value;
            }
        }

        //{60137B80-188F-4311-A160-6746A92ACD5C}
        bool isDivisionDrugBySendFlag = false;
        [Category("控件设置"), Description("直接退费是否区分已发药和未发药"), DefaultValue(true)]
        public bool IsDivisionDrugBySendFlag
        {
            get
            {
                return isDivisionDrugBySendFlag;
            }
            set
            {
                isDivisionDrugBySendFlag = value;
            }
        } 
        #endregion

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            this.dtpBeginTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 0, 0, 0);
            this.dtpEndTime.Value = nowTime;

            #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
            ArrayList alDepts = managerIntegrate.GetDeptmentIn(EnumDepartmentType.P);
            if (alDepts == null)
            {
                MessageBox.Show("获得药房列表出错!" + this.managerIntegrate.Err);

                return -1;
            }

            this.deptHelper.ArrayObject = alDepts; 
            #endregion

            ArrayList minFeeList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);
            if (minFeeList == null)
            {
                MessageBox.Show("获得最小费用出错!" + this.managerIntegrate.Err);

                return -1;
            }

            this.objectHelperMinFee.ArrayObject = minFeeList;

            this.InitFp();

            this.SetItemType();
            this.QueryTermalDept();

            this.operDept = ((Neusoft.HISFC.Models.Base.Employee)this.undrugManager.Operator).Dept;
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
                    new DataColumn("开方科室", typeof(string))
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
                    new DataColumn("记帐人",typeof(string)),
                    new DataColumn("是否执行", typeof(string)),
                    new DataColumn("编码", typeof(string)),
                    new DataColumn("医嘱号", typeof(string)),
                    new DataColumn("医嘱执行号", typeof(string)),
                    new DataColumn("处方号", typeof(string)),
                    new DataColumn("处方流水号", typeof(string)),
                    new DataColumn("拼音码", typeof(string)),
                    new DataColumn("开方科室", typeof(string)),
                    new DataColumn("出库流水号",typeof(string)),
                    new DataColumn("库存序号",typeof(string)),
                    //非0药品 2物质
                    new DataColumn("标识",typeof(string))
                 });

                dtUndrug.PrimaryKey = new DataColumn[] { dtUndrug.Columns["处方号"], dtUndrug.Columns["处方流水号"] };

                dvUndrug = new DataView(dtUndrug);

                //绑定到对应的Farpoint
                //this.fpUnQuit_SheetUndrug.DataSource = dvUndrug;

                //// 保存当前的列顺序,名称等信息到XML
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
                    new DataColumn("库存序号",typeof(string)),
                    //非0药品 2物质
                    new DataColumn("标识",typeof(string))
                });
            dtMate.PrimaryKey = new DataColumn[] { dtMate.Columns["库存序号"], dtMate.Columns["出库流水号"] };

            #endregion

            return 1;
        }

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

        #endregion

        #region 数据及Fp操作
        //{2B37E433-BE4E-4d5b-95E8-7D2449133273}
        private ArrayList alTermalDept = new ArrayList();
        private int QueryTermalDept()
        {
            //Neusoft.HISFC.BizProcess.Integrate.Manager managerInt = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager dsmManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();

            alTermalDept = dsmManager.LoadDepartmentStatAndByNodeKind("98", "1");

            //this.alTermalDept = managerInt.GetConstantList("Termin");

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FeeItemList"></param>
        /// <returns></returns>
        private bool IsExist(string deptCode)
        {

            for (int i = 0; i < this.alTermalDept.Count; i++)
            {
                Neusoft.HISFC.Models.Base.DepartmentStat obj = alTermalDept[i] as Neusoft.HISFC.Models.Base.DepartmentStat;
                if (deptCode == obj.DeptCode)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 设置药品列表
        /// </summary>
        /// <param name="drugList"></param>
        protected virtual void SetDrugList(ArrayList drugList)
        {
            foreach (FeeItemList feeItemList in drugList)
            {
                //{37F415CA-A3DB-43c6-90BB-FB41A7EA4209}
                if (!IsCanQuitOtherDeptFee)
                {

                    if (feeItemList.ExecOper.Dept.ID != ((this.inpatientManager.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                    {
                        continue;
                    }

                }
                else
                {
                    if (isOutTerminalDept)
                    {
                        if (this.IsExist(feeItemList.ExecOper.Dept.ID)) //终端确认科室执行
                        {
                            continue;
                        }
                    }
                }

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
                feeItemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
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
        /// 设置非药品列表
        /// </summary>
        /// <param name="undrugList"></param>
        protected virtual void SetUndrugList(ArrayList undrugList)
        {
            dtUndrug.Rows.Clear();
            dtMate.Rows.Clear();
            foreach (FeeItemList feeItemList in undrugList)
            {
                //{37F415CA-A3DB-43c6-90BB-FB41A7EA4209}
                if (!IsCanQuitOtherDeptFee)
                {

                    if (feeItemList.ExecOper.Dept.ID != ((this.inpatientManager.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                    {
                        continue;
                    }



                }
                else
                {
                    if (isOutTerminalDept)
                    {
                        if (this.IsExist(feeItemList.ExecOper.Dept.ID)) //终端确认科室执行
                        {
                            continue; 
                        }
                    }
                }

                

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
                //feeItemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
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


                Neusoft.HISFC.Models.Base.Employee feeOper =new Neusoft.HISFC.Models.Base.Employee();
                feeOper=this.managerIntegrate.GetEmployeeInfo(feeItemList.FeeOper.ID);
                if (feeOper.Name ==string.Empty)
                {
                    row["记帐人"]=feeItemList.FeeOper.ID;
                }
                else
                {
                    row["记帐人"]=feeOper.Name;
                }

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

        /// <summary>
        /// 过滤非药品信息
        /// </summary>
        /// <param name="strVal"></param>
        private void SetUndragFp(string strVal)
        {
            this.fpUnQuit_SheetUndrug.Rows.Remove(0, this.fpUnQuit_SheetUndrug.Rows.Count);
            if (this.dtUndrug.Rows.Count == 0)
                return;
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
        /// 显示非药品数据
        /// </summary>
        /// <param name="dr"></param>
        private void SetUndrugRow(DataRow dr)
        {
            this.fpUnQuit_SheetUndrug.Rows.Add(this.fpUnQuit_SheetUndrug.Rows.Count, 1);
            int rowIndex = this.fpUnQuit_SheetUndrug.Rows.Count - 1;
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 0].Text = dr["项目名称"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 1].Text = dr["费用名称"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 2].Text = dr["价格"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 3].Text = dr["可退数量"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 4].Text = dr["单位"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 5].Text = dr["金额"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 6].Text = dr["执行科室"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 7].Text = dr["开方医师"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 8].Text = dr["记帐日期"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 9].Text = dr["记帐人"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 10].Text = dr["是否执行"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 11].Text = dr["编码"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 12].Text = dr["医嘱号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 13].Text = dr["医嘱执行号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 14].Text = dr["处方号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 15].Text = dr["处方流水号"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 16].Text = dr["拼音码"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 17].Text = dr["开方科室"].ToString();
            this.fpUnQuit_SheetUndrug.Cells[rowIndex, 18].Text = dr["出库流水号"].ToString();
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

        /// <summary>
        /// 添加药品退费申请列表
        /// </summary>
        /// <param name="drugList">药品</param>
        protected virtual void SetQuitDrug(Neusoft.HISFC.Models.Fee.ReturnApply retrunApply)
        {
            int rowCount = this.fpQuit_SheetDrug.Rows.Count;

            this.fpQuit_SheetDrug.Rows.Add(rowCount, 1);

            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.ItemName, retrunApply.Item.Name);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Specs, retrunApply.Item.Specs);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Price, retrunApply.Item.Price);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Qty, retrunApply.Item.Qty);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Unit, retrunApply.Item.PriceUnit);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2));
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.FeeDate, retrunApply.CancelOper.OperTime);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.IsConfirm, retrunApply.IsConfirmed);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.IsApply, true);
            //处理作废处方号
            retrunApply.CancelRecipeNO = retrunApply.RecipeNO;
            //处理作废处方内部流水号
            retrunApply.CancelSequenceNO = retrunApply.SequenceNO;

            this.fpQuit_SheetDrug.Rows[rowCount].ForeColor = System.Drawing.Color.Red;

            this.fpQuit_SheetDrug.Rows[rowCount].Tag = retrunApply;
        }

        /// <summary>
        /// 添加药品退费申请列表
        /// </summary>
        /// <param name="drugList">药品</param>
        protected virtual void SetQuitDrug(Neusoft.HISFC.Models.Pharmacy.ApplyOut returnApplyOut)
        {
            int rowCount = this.fpQuit_SheetDrug.Rows.Count;

            this.fpQuit_SheetDrug.Rows.Add(rowCount, 1);

            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.ItemName, returnApplyOut.Item.Name);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Specs, returnApplyOut.Item.Specs);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Price, returnApplyOut.Item.PriceCollection.RetailPrice);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Qty, returnApplyOut.Operation.ApplyQty);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Unit, returnApplyOut.Item.MinUnit);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(returnApplyOut.Item.PriceCollection.RetailPrice * returnApplyOut.Operation.ApplyQty / returnApplyOut.Item.PackQty, 2));
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.FeeDate, returnApplyOut.Operation.ApplyOper.OperTime);
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.IsConfirm, true);     // 标志是否发药
            this.fpQuit_SheetDrug.SetValue(rowCount, (int)DrugColumns.IsApply, true);
            ////处理作废处方号
            //returnApplyOut.CancelRecipeNO = returnApplyOut.RecipeNO;
            ////处理作废处方内部流水号
            //returnApplyOut.CancelSequenceNO = returnApplyOut.SequenceNO;

            this.fpQuit_SheetDrug.Rows[rowCount].ForeColor = System.Drawing.Color.Red;

            this.fpQuit_SheetDrug.Rows[rowCount].Tag = returnApplyOut;
        }

        /// <summary>
        /// 添加非药品退费申请列表
        /// </summary>
        /// <param name="undrugApplyList">非药品</param>
        protected virtual void SetQuitUnDrug(Neusoft.HISFC.Models.Fee.ReturnApply retrunApply)
        {
            int rowCount = this.fpQuit_SheetUndrug.Rows.Count;

            this.fpQuit_SheetUndrug.Rows.Add(rowCount, 1);

            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.ItemName, retrunApply.Item.Name);

            Neusoft.HISFC.Models.Fee.Item.Undrug undrugInfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
            undrugInfo = this.undrugManager.GetUndrugByCode(retrunApply.Item.ID);
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.FeeName, this.inpatientManager.GetMinFeeNameByCode(undrugInfo.MinFee.ID));

            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.Price, retrunApply.Item.Price);
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.Qty, retrunApply.Item.Qty);
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.Unit, retrunApply.Item.PriceUnit);
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.Cost, Neusoft.FrameWork.Public.String.FormatNumber(retrunApply.Item.Price * retrunApply.Item.Qty / retrunApply.Item.PackQty, 2));
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.IsConfirm, retrunApply.IsConfirmed);
            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.IsApply, true);
            Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

            deptInfo = this.managerIntegrate.GetDepartment(retrunApply.ExecOper.Dept.ID);
            if (deptInfo == null)
            {
                deptInfo = new Neusoft.HISFC.Models.Base.Department();
                deptInfo.Name = retrunApply.ExecOper.Dept.ID;
            }

            this.fpQuit_SheetUndrug.SetValue(rowCount, (int)UndrugColumns.ExecDept, deptInfo.Name);
            //处理作废处方号
            retrunApply.CancelRecipeNO = retrunApply.RecipeNO;
            //处理作废处方内部流水号
            retrunApply.CancelSequenceNO = retrunApply.SequenceNO;

            this.fpQuit_SheetUndrug.Rows[rowCount].ForeColor = System.Drawing.Color.Red;
            this.fpQuit_SheetUndrug.Rows[rowCount].Tag = retrunApply;
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
        /// 获得未退费的药品信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RetriveDrug(DateTime beginTime, DateTime endTime)
        {
            //{60137B80-188F-4311-A160-6746A92ACD5C}
            string flag = "1,2";

           
            if (this.isDivisionDrugBySendFlag)
            {
                if (this.IsDirQuitFee) 
                {
                    //直接退费显示已发药
                    flag = "1"; //收费未发药
                }
                else 
                {
                    //退费申请显示已经发药的药品
                    flag = "2"; 
                }
            }

            ArrayList drugList = this.inpatientManager.QueryMedItemListsCanQuit(this.patientInfo.ID, beginTime, endTime, flag, false);
            if (drugList == null)
            {
                MessageBox.Show(Language.Msg("获得药品列表出错!") + this.inpatientManager.Err);

                return -1;
            }

            this.SetDrugList(drugList);

            return 1;
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
        /// 获得已做退费申请信息
        /// </summary>
        /// <param name="isPharmarcy"></param>
        private void RetrieveReturnApply(bool isPharmarcy)
        {
            if (isPharmarcy)
            {
                this.fpQuit_SheetDrug.Rows.Count = 0;
            }
            else
            {
                this.fpQuit_SheetUndrug.Rows.Count = 0;
            }

            //获取退费申请信息
            ArrayList returnApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, isPharmarcy);
            if (returnApplys == null)
            {
                MessageBox.Show(Language.Msg("获得退费申请信息出错！"));

                return;
            }


            //获取药品退药申请信息
            if (isPharmarcy)
            {
                ArrayList alQuitDrug = this.phamarcyIntegrate.QueryDrugReturn(this.operDept.ID, "AAAA", this.patientInfo.ID);
                if (alQuitDrug == null)
                {
                    MessageBox.Show(Language.Msg("获取退药申请信息发生错误"));
                    return;
                }
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alQuitDrug)
                {
                    Neusoft.HISFC.Models.Fee.ReturnApply temp = new Neusoft.HISFC.Models.Fee.ReturnApply();

                    temp.Item = info.Item;
                    temp.CancelOper.OperTime = info.Operation.ApplyOper.OperTime;
                    temp.IsConfirmed = true;            //标志是否发药
                    temp.Item.Qty = info.Operation.ApplyQty;
                    temp.Item.Price = info.Item.PriceCollection.RetailPrice;
                    temp.Item.PriceUnit = info.Item.MinUnit;

                    temp.User01 = "QuitDrugApply";
                    info.User01 = "QuitDrugApply";

                    //  returnApplys.Add(temp);

                    this.SetQuitDrug(info);
                }
            }
            foreach (Neusoft.HISFC.Models.Fee.ReturnApply retrunApply in returnApplys)
            {
                //已经执行过终端退费确认的，不允许再取消
                if (retrunApply.IsConfirmed)
                {
                    continue;
                }

                if (retrunApply.User01 != "QuitDrugApply")
                {
                    retrunApply.User01 = "QuitFeeApply";
                }

                //药品
                //if (retrunApply.Item.IsPharmacy)
                if (retrunApply.Item.ItemType == EnumItemType.Drug)
                {
                    this.SetQuitDrug(retrunApply);
                }
                else
                {
                    //List<HISFC.Models.Material.Output> outlist = returnApplyManager.QueryOutPutByApplyNo(retrunApply.ID, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
                    List<HISFC.Models.Fee.ReturnApplyMet> returnlist = returnApplyManager.QueryReturnApplyMetByApplyNo(retrunApply.ID, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
                    //物资申请记录
                    retrunApply.ApplyMateList = returnlist;
                    //通过物资申请记录形成物资出库记录
                    retrunApply.MateList = this.GetOutPutByApplyItem(retrunApply);

                    this.SetQuitUnDrug(retrunApply);
                }
            }
        }

        /// <summary>
        /// 通过物资申请数据形成物资出库实体
        /// </summary>
        /// <param name="feeitemList"></param>
        /// <returns></returns>
        private List<HISFC.Models.FeeStuff.Output> GetOutPutByApplyItem(Neusoft.HISFC.Models.Fee.ReturnApply returnApply)
        {
            List<HISFC.Models.FeeStuff.Output> list = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            HISFC.Models.FeeStuff.Output outItem = null;
            if (returnApply.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                foreach (HISFC.Models.Fee.ReturnApplyMet applyMet in returnApply.ApplyMateList)
                {
                    outItem = new Neusoft.HISFC.Models.FeeStuff.Output();
                    outItem.StoreBase.Item = applyMet.Item;
                    outItem.ReturnApplyNum = applyMet.Item.Qty;
                    outItem.RecipeNO = applyMet.RecipeNo;
                    outItem.SequenceNO = FrameWork.Function.NConvert.ToInt32(applyMet.SequenceNo);
                    outItem.StoreBase.StockNO = applyMet.StockNo;
                    outItem.ID = applyMet.OutNo;
                    list.Add(outItem);
                }
            }
            return list;
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
            this.ClearItemList();
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

                //重新读取列的顺序和宽度等信息
                //Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
                this.SetUndragFp(filterString);
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
            EnumItemType isPharmarcy = EnumItemType.Drug;

            //判断当前处理的信息是否为药品,如果活动页是药品页,那么说明处理的是药品,否则为非药品
            //isPharmarcy = this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug;
            if (this.fpUnQuit.ActiveSheet == this.fpUnQuit_SheetDrug)
            {
                isPharmarcy = EnumItemType.Drug;
            }
            else
            {

                isPharmarcy = EnumItemType.UnDrug;
            }

            if (this.fpUnQuit.ActiveSheet.RowCount == 0)
            {
                return;
            }

            int index = this.fpUnQuit.ActiveSheet.ActiveRowIndex;
            #region 是否允许退其他科室费用
            //{37F415CA-A3DB-43c6-90BB-FB41A7EA4209}
            //if (!isCanQuitOtherFee)
            //{
            //    string FeeOperDept = fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("开方科室", this.fpUnQuit.ActiveSheet));
            //    if (FeeOperDept != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID)
            //    {
            //        MessageBox.Show("不允许退其他科室费用");
            //        return;
            //    }
            //}
            #endregion

            #region 是否允许退其他操作员费用
            // {097418EF-9E96-48d4-9E6C-46CCC111C78C} ModifyBy 赵景
            if (this.IsCanQuitOtherOperator == false)
            {
                string recipeTempNO = this.fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("处方号", this.fpUnQuit.ActiveSheet));
                int recipeID = 0;
                try
                {
                    recipeID = Int32.Parse(this.fpUnQuit.ActiveSheet.GetText(index, this.FindColumn("处方流水号", this.fpUnQuit.ActiveSheet)));
                }
                catch (Exception e)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("处方流水号格式化出错！" + e.Message));
                    return;
                }
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeTempItemList = this.inpatientManager.GetItemListByRecipeNO(recipeTempNO, recipeID, isPharmarcy);
                if (feeTempItemList.FeeOper.ID != Neusoft.FrameWork.Management.Connection.Operator.ID)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("不允许退其他收费员的费用信息！"));
                    return;
                }
            }

            #endregion

            #region 物资(非药品对应多条物资)
            //是否是多条对照
            //bool isMate = false;
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

            //if (isMate)
            //{
            //feeItemList.MateList.Add(outitemList.);
            if (feeItemList.Item.ItemType == EnumItemType.UnDrug && outitemList.Count > 0)
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
            //}
            //else
            //{
            //    DataRow[] vdr = dtMate.Select("出库流水号 ='" + feeItemList.UpdateSequence + "'");
            //    if (vdr.Length > 0)
            //    {
            //        feeItemList.MateList.Add(this.GetOutPutByDataRow(vdr[0]));
            //    }
            //}

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
        /// 全退非药品或物资
        /// </summary>
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
                    //对于已保存的退费申请 不进行处理
                    if (this.fpQuit_SheetDrug.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        continue;
                    }
                    if (this.fpQuit_SheetDrug.Rows[i].Tag is Neusoft.HISFC.Models.Pharmacy.ApplyOut)
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
                    //对于已保存的退费申请 不进行处理
                    if (this.fpQuit_SheetUndrug.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
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
            if (feeItemList.Item.ItemType == EnumItemType.UnDrug || feeItemList.Item.ItemType == EnumItemType.MatItem)
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
            int index = this.fpUnQuit.ActiveSheet.ActiveRowIndex;
            //全退物资非药品的可退数量为物资的数量
            if (this.fpUnQuit.ActiveSheet.RowHeader.Cells[index, 0].Text == "." && this.ckbAllQuit.Checked)
            {
                feeItemList.NoBackQty = feeItemList.MateList[0].ReturnApplyNum;
            }
            findRow["可退数量"] = NConvert.ToDecimal(findRow["可退数量"]) - feeItemList.NoBackQty;

            findRow["金额"] = feeItemList.Item.Price * NConvert.ToDecimal(findRow["可退数量"]) / feeItemList.Item.PackQty;

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
        /// 取消退费操作
        /// </summary>
        /// <业务处理说明>
        ///     1、对于退药申请(发药后退费、尚未退药确认的情况)，取消时直接作废退药申请。更新可退数量
        ///     2、对于退费申请的非药品，直接更新可退数量
        ///        对于退费申请的药品,首先更新费用表可退数量，如果是全退取消，直接恢复取药申请
        ///        如果是半退取消，则首先作废原取药申请，根据数量形成新取药申请
        /// </业务处理说明>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelQuitOperation()
        {
            if (this.fpQuit.ActiveSheet.RowCount == 0)
            {
                return -1;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("确认取消退费申请吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return -1;
            }

            int index = this.fpQuit.ActiveSheet.ActiveRowIndex;

            object quitItem = this.fpQuit.ActiveSheet.Rows[index].Tag;
            if (quitItem == null)
            {
                return -1;
            }
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList tempFeeItem = null;

            #region 没有做退费、退药申请的数据
            //没有做退费、退药申请的数据
            if (quitItem.GetType() == typeof(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList))
            {
                tempFeeItem = quitItem as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                DataRow rowFind = this.FindUnquitItem(tempFeeItem);
                if (rowFind == null)
                {
                    MessageBox.Show("查找未退项目出错");

                    return -1;
                }

                rowFind["可退数量"] = NConvert.ToDecimal(rowFind["可退数量"]) + tempFeeItem.NoBackQty;
                rowFind["金额"] = tempFeeItem.Item.Price * NConvert.ToDecimal(rowFind["可退数量"]) / tempFeeItem.Item.PackQty;

                UpdateFpData(rowFind, false);

                #region 同步fpUnQuit_SheetUndrug和DataTable中的数据
                //以为非药品的数据不是绑定上的所以要同步fpUnQuit_SheetUndrug和DataTable中的数据
                string rowHeader = string.Empty;
                DataRow mateRow = null;
                if (tempFeeItem.Item.ItemType != EnumItemType.Drug && tempFeeItem.MateList.Count > 0)
                {

                    foreach (HISFC.Models.FeeStuff.Output outItem in tempFeeItem.MateList)
                    {
                        mateRow = FindMateRow(outItem);
                        if (mateRow == null)
                        {
                            MessageBox.Show("查找项目出错!");
                            return -1;
                        }
                        mateRow["可退数量"] = NConvert.ToDecimal(mateRow["可退数量"]) + outItem.ReturnApplyNum;
                        mateRow["金额"] = tempFeeItem.Item.Price * NConvert.ToDecimal(mateRow["可退数量"]) / tempFeeItem.Item.PackQty;
                        UpdateFpData(mateRow, true);
                    }
                }
                #endregion
                this.fpQuit.ActiveSheet.Rows.Remove(index, 1);
                return 1;
            }
            #endregion

            //开始事务
            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();


            if (quitItem is Neusoft.HISFC.Models.Pharmacy.ApplyOut)     //退药申请
            {
                #region 退药申请取消 此时尚没有退费申请信息

                Neusoft.HISFC.Models.Pharmacy.ApplyOut tempApplyOut = quitItem as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                //根据处方号、处方流水号获取结算状态
                //tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempApplyOut.RecipeNO, tempApplyOut.SequenceNO, true);
                tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempApplyOut.RecipeNO, tempApplyOut.SequenceNO, EnumItemType.Drug);
                if (tempFeeItem == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("根据处方号、处方内项目流水号获取处方明细信息失败") + this.inpatientManager.Err);
                    return -1;
                }
                //更新药品明细表中的可退数量，防止并发
                int parm = this.inpatientManager.UpdateNoBackQtyForDrug(tempApplyOut.RecipeNO, tempApplyOut.SequenceNO, -tempApplyOut.Days * tempApplyOut.Operation.ApplyQty, tempFeeItem.BalanceState);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新药品可退数量失败" + this.inpatientManager.Err));
                    return -1;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));
                    return -1;
                }
                //作废退药申请
                parm = this.phamarcyIntegrate.CancelApplyOut(tempApplyOut.RecipeNO, tempApplyOut.SequenceNO);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.phamarcyIntegrate.Err);
                    return -1;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该申请已被取消，无法再次撤销");
                    return -1;
                }

                #endregion

                #region 临时费用信息tempFeeItem赋值

                tempFeeItem.Item.Qty = tempApplyOut.Days * tempApplyOut.Operation.ApplyQty;
                tempFeeItem.Item.Price = tempApplyOut.Item.PriceCollection.RetailPrice;

                #endregion
            }
            if (quitItem is Neusoft.HISFC.Models.Fee.ReturnApply)       //退费申请
            {
                Neusoft.HISFC.Models.Fee.ReturnApply tempReturnApply = quitItem as Neusoft.HISFC.Models.Fee.ReturnApply;

                #region 根据处方号、处方流水号获取费用信息

                //if (tempReturnApply.Item.IsPharmacy)
                if (tempReturnApply.Item.ItemType == EnumItemType.Drug)
                {
                    //根据处方号、处方流水号获取结算状态
                    //tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, true);
                    tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, EnumItemType.Drug);
                }
                else
                {
                    //tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, false);
                    tempFeeItem = this.inpatientManager.GetItemListByRecipeNO(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, EnumItemType.UnDrug);
                }
                if (tempFeeItem == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("根据处方号、处方内项目流水号获取处方明细信息失败") + this.inpatientManager.Err);
                    return -1;
                }

                #endregion

                //if (tempReturnApply.Item.IsPharmacy)                    //药品退费申请
                if (tempReturnApply.Item.ItemType == EnumItemType.Drug)     //药品退费申请
                {
                    #region 药品退费申请作废

                    #region 更新明细表中的可退数量，防止并发

                    int parm = this.inpatientManager.UpdateNoBackQtyForDrug(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, -tempReturnApply.Item.Qty, tempFeeItem.BalanceState);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新药品可退数量失败" + this.inpatientManager.Err));
                        return -1;
                    }
                    else if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));
                        return -1;
                    }

                    #endregion

                    //部分退的情况，此时药品已经存在部分退后的有效申请。需作废申请，根据取消后数量重新生成摆药申请
                    if (tempFeeItem.NoBackQty != 0 || tempFeeItem.Item.Qty != tempFeeItem.NoBackQty + tempReturnApply.Item.Qty)
                    {
                        #region 部分退取消情况
                        //首先作废摆药申请
                        int returnValue = this.phamarcyIntegrate.CancelApplyOut(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO);
                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("作废摆药申请出错!") + phamarcyIntegrate.Err);

                            return -1;
                        }
                        if (returnValue == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("项目【") + tempFeeItem.Item.Name + Language.Msg("】已摆药，请重新检索数据"));

                            return -1;
                        }

                        //取收费对应的摆药申请记录
                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp = this.phamarcyIntegrate.GetApplyOut(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO);
                        if (applyOutTemp == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("获得申请信息出错!") + this.phamarcyIntegrate.Err);
                            return -1;
                        }
                        //将剩余数量发送摆药申请
                        applyOutTemp.Operation.ApplyOper.OperTime = nowTime;
                        applyOutTemp.Operation.ApplyQty = tempFeeItem.NoBackQty + tempReturnApply.Item.Qty;//数量等于剩余数量
                        applyOutTemp.Operation.ApproveQty = tempFeeItem.NoBackQty + tempReturnApply.Item.Qty;//数量等于剩余数量
                        applyOutTemp.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;	//有效状态                        
                        //将剩余数量发送摆药申请  {C37BEC96-D671-46d1-BCDD-C634423755A4}
                        if (this.phamarcyIntegrate.ApplyOut(applyOutTemp) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("重新插入发药申请出错!") + this.phamarcyIntegrate.Err);

                            return -1;
                        }

                        #endregion
                    }
                    else
                    {
                        #region 全退情况

                        //恢复出库申请记录为有效   待添加 
                        parm = this.phamarcyIntegrate.UndoCancelApplyOut(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO);
                        if (parm == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("恢复出库申请有效性发生错误" + this.phamarcyIntegrate.Err);
                            return -1;
                        }
                        else if (parm == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("该数据已被取消，无法撤销申请");
                            return -1;
                        }

                        #endregion
                    }

                    #endregion
                }
                else
                {
                    #region 非药品退费申请作废

                    //更新明细表中的可退数量，防止并发
                    int parm = this.inpatientManager.UpdateNoBackQtyForUndrug(tempReturnApply.RecipeNO, tempReturnApply.SequenceNO, -tempReturnApply.Item.Qty, tempFeeItem.BalanceState);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新药品可退数量失败" + this.inpatientManager.Err));
                        return -1;
                    }
                    else if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));
                        return -1;
                    }

                    #endregion

                    #region 作废物资退费申请
                    //更新物资出库表中的申请数量
                    parm = mateInteger.ApplyMaterialFeeBack(tempReturnApply.MateList, true);
                    if (parm < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新物资申请数量失败" + this.inpatientManager.Err));
                        return -1;
                    }
                    if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));
                        return -1;
                    }
                    parm = returnApplyManager.UpdateReturnApplyState(tempReturnApply.ApplyMateList, CancelTypes.Reprint);
                    if (parm < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("作废物资申请信息失败！" + this.inpatientManager.Err));
                        return -1;
                    }
                    #endregion
                }

                #region 临时费用信息tempFeeItem赋值

                tempFeeItem.Item.Qty = tempReturnApply.Item.Qty;
                tempFeeItem.Item.Price = tempReturnApply.Item.Price;

                #endregion

                //作废退费申请
                if (this.returnApplyManager.CancelReturnApply(tempReturnApply.ID, this.returnApplyManager.Operator.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("作废退费申请发生错误") + this.returnApplyManager.Err);
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //如果是退费项目(不是申请)
            if (tempFeeItem != null)
            {
                if (tempFeeItem.Item.ItemType == EnumItemType.Drug)
                {
                    DataRow rowFind = this.FindUnquitItem(tempFeeItem);
                    if (rowFind != null)
                    {

                        rowFind["可退数量"] = NConvert.ToDecimal(rowFind["可退数量"]) + tempFeeItem.Item.Qty;
                        rowFind["金额"] = tempFeeItem.Item.Price * NConvert.ToDecimal(rowFind["可退数量"]) / tempFeeItem.Item.PackQty;
                        this.fpQuit.ActiveSheet.Rows.Remove(index, 1);
                    }
                    else
                    {
                        //{60137B80-188F-4311-A160-6746A92ACD5C}
                        //this.Retrive(true);
                        this.Retrive(this.isShowQueryFeeApplyInfo);
                    }
                }
                else
                {
                    //{60137B80-188F-4311-A160-6746A92ACD5C}
                    //this.Retrive(true);
                    this.Retrive(this.isShowQueryFeeApplyInfo);
                }
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
            #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
            arr = new ArrayList();
            bool isSendedDrug = false;
            Hashtable hsDrugStockDept = new Hashtable(); 
            #endregion
            //循环处理退费数据
            foreach (FeeItemList feeItemList in feeItemLists)
            {

                #region 物资退费申请
                //物资退费申请
                if (feeItemList.Item.ItemType != EnumItemType.Drug && feeItemList.MateList.Count > 0)
                {
                    if (mateInteger.ApplyMaterialFeeBack(feeItemList.MateList, false) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("物资退费失败!" + this.inpatientManager.Err));

                        return -1;
                    }
                }
                #endregion

                //如果草药付数没有赋值,默认赋值为1
                if (feeItemList.Days == 0)
                {
                    feeItemList.Days = 1;
                }

                //FeeItemList feeItemListTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.IsPharmacy);
                FeeItemList feeItemListTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.ItemType);
                if (feeItemListTemp == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获得项目基本信息出错!" + this.inpatientManager.Err));

                    return -1;
                }

                if (feeItemList.MateList.Count > 0)
                {
                    //feeItemListTemp.StockNo = feeItemList.MateList[0].StoreBase.StockNO;
                    feeItemListTemp.MateList = feeItemList.MateList;
                }
                //向退费单中填写记录
                //if (feeItemListTemp.Item.IsPharmacy && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                isSendedDrug = false;//addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
                if (feeItemListTemp.Item.ItemType == EnumItemType.Drug && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                {
                    if (feeItemList.Item.User01 == "1")
                    {
                        feeItemList.User01 = "送结账处";//update by xuewj 2010-9-27 住院处改为结账处 {F68D96EB-E261-4ef7-9576-3D5E512750F6}
                    }
                    else
                    {
                        #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
                        //feeItemList.User01 = "送药房";
                        if (feeItemList.Memo != "OLD")
                        {
                            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutInfo = this.phamarcyIntegrate.QueryApplyOutNew(feeItemList.RecipeNO, feeItemList.SequenceNO);
                            if (applyOutInfo == null || applyOutInfo.ID == "")
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();

                                MessageBox.Show(Language.Msg("退药申请失败!" + this.phamarcyIntegrate.Err));
                                return -1;
                            }
                            feeItemList.User01 = "送" + this.deptHelper.GetName(applyOutInfo.StockDept.ID);

                            ArrayList alSendDrugs = hsDrugStockDept[applyOutInfo.StockDept.ID] as ArrayList;

                            if (alSendDrugs == null)
                            {
                                alSendDrugs = new ArrayList();
                                alSendDrugs.Add(feeItemList);
                                hsDrugStockDept.Add(applyOutInfo.StockDept.ID, alSendDrugs);
                            }
                            else
                            {
                                alSendDrugs.Add(feeItemList);
                            }
                            isSendedDrug = true;
                        } 
                        #endregion
                    }
                }
                else
                {
                    feeItemList.User01 = "送结账处";//update by xuewj 2010-9-27 住院处改为结账处 {F68D96EB-E261-4ef7-9576-3D5E512750F6}
                }
                if (feeItemList.Memo != "OLD")
                {
                    #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
                    if (!isSendedDrug)
                    {
                        arr.Add(feeItemList);
                    } 
                    #endregion
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

                    if (feeItemList.FTRate.ItemRate != 0)
                    {
                        feeItemListTemp.Item.Price = feeItemListTemp.Item.Price * feeItemListTemp.FTRate.ItemRate;
                    }

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

                            applyOutTemp.ID = "";
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
            #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
            string strMsg = string.Empty;
            
            if (this.isPrintApplyBill)
            {
                strMsg = "请参照退费申请单提示执行！";
                if (this.isDirBackFee == false)
                {
                    if (this.ICompoundPrintQuitFee == null)
                    {
                        this.ICompoundPrintQuitFee = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.ICompoundPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.ICompoundPrint;
                    }
                    if (this.ICompoundPrintQuitFee != null)
                    {
                        if ((this.arr != null && this.arr.Count > 0)
                            || (hsDrugStockDept.Count > 0))
                        {
                            ICompoundPrintQuitFee.InpatientInfo = patientInfo;

                            System.Windows.Forms.Form topForm = new Form();
                            topForm.AutoSize = true;
                            topForm.Controls.Add((Control)ICompoundPrintQuitFee);
                            topForm.Show();
                            topForm.Visible = false;

                            if ((this.arr != null && this.arr.Count > 0))
                            {
                                ICompoundPrintQuitFee.AddAllData(this.arr);
                                ICompoundPrintQuitFee.Print();
                            }

                            foreach (DictionaryEntry dictionaryInfo in hsDrugStockDept)
                            {
                                ICompoundPrintQuitFee.AddAllData(dictionaryInfo.Value as ArrayList);
                                ICompoundPrintQuitFee.Print();

                            }
                        }
                    }
                }
            } 
            #endregion
            MessageBox.Show(Language.Msg("退费申请成功!\n" + strMsg));

            return 1;
        }

        /// <summary>
        /// 直接退费
        /// </summary>
        /// <returns></returns>
        protected virtual int SaveQuitFee()
        {
            #region 验证合法性

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

            #endregion

            #region 开始事务

            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            string errMsg = string.Empty;//错误信息
            int returnValue = 0;//返回值
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            #region 获得退费申请号

            string applyBillCode = this.GetApplyBillCode(ref errMsg);
            if (applyBillCode == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errMsg);

                return -1;
            }

            #endregion

            string msg = "";
            //循环处理退费数据
            foreach (FeeItemList feeItemList in feeItemLists)
            {
                //如果草药付数没有赋值,默认赋值为1
                if (feeItemList.Days == 0)
                {
                    feeItemList.Days = 1;
                }

                #region 获取原始费用信息

                //FeeItemList feeItemListTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.IsPharmacy);
                FeeItemList feeItemListTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.ItemType);
                if (feeItemListTemp == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获得项目基本信息出错!" + this.inpatientManager.Err));

                    return -1;
                }

                #endregion

                //if (feeItemListTemp.Item.IsPharmacy && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                if (feeItemListTemp.Item.ItemType == EnumItemType.Drug && feeItemListTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.SendDruged)
                {
                    #region 药品已发药 形成退药申请

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

                    #endregion

                    msg += feeItemListTemp.Item.Name + "\n";
                }
                else//对于非药品和未摆药的药品，直接做退费
                {
                    //使用数据库中取得的实体和用户操作的数量
                    feeItemListTemp.Item.Qty = feeItemList.Item.Qty;

                    if (feeItemList.FTRate.ItemRate != 0)
                    {
                        feeItemListTemp.Item.Price = feeItemListTemp.Item.Price * feeItemListTemp.FTRate.ItemRate;
                    }

                    //直接退费
                    if (this.feeIntegrate.QuitItem(this.patientInfo, feeItemList.Clone()) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("退费失败!") + this.feeIntegrate.Err);
                        return -1;
                    }

                    //没有摆药的药品在退费申请的同时，作废摆药申请
                    //if (feeItemListTemp.Item.IsPharmacy)
                    if (feeItemListTemp.Item.ItemType == EnumItemType.Drug)
                    {
                        #region 取摆药申请记录，判断其状态是否发生并发。（不在CancelApplyOut中判断并发是因为有些收费后的医嘱没有发送到药房，不存在摆药申请记录）

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

                        #endregion

                        //如果是部分退费(用户退药的数量小于费用表中的可退数量),要对剩余的药品做摆药申请.
                        if (feeItemList.Item.Qty < feeItemListTemp.NoBackQty)
                        {

                            #region 部分退费重新发送申请

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

                            #endregion
                        }
                    }
                }
            }

            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            //{5C3C59A9-7E36-4c31-995C-8396DCDCBF9E}
            this.feeIntegrate.Commit();
            MessageBox.Show(Language.Msg("退费成功!"));

            if (msg != "")
            {
                MessageBox.Show("以下药品 " + msg + " 需去药房确认退药");
            }

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

            if (this.isDirBackFee)
            {
                this.SaveQuitFee();
            }
            else
            {
                if (this.SaveApply() == -1)
                {
                    return -1;
                }

                this.Clear();

                //this.ClearItemList();

                //this.Retrive(true);

                this.txtFilter.Focus();
                return 1;
            }

            this.Clear();

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
            //Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpUnQuit_SheetUndrug, this.filePathUnQuitUndrug);
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
            //{60137B80-188F-4311-A160-6746A92ACD5C}
            //this.Retrive(true);
            this.Retrive(this.isShowQueryFeeApplyInfo);

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

        /// <summary>
        /// 护士站树选择事件
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (e == null || e.Tag == null)
                return -1;
            patientInfo = e.Tag as PatientInfo;
            if (patientInfo == null)
            {
                MessageBox.Show("请选择患者");
                return -1;
            }
            this.ClearItemList();
            this.ucQueryPatientInfo.Text = patientInfo.PID.ID;
            this.SetPatientInfomation();

            return base.OnSetValue(neuObject, e);
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

        private void fpUnQuit_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

        }



        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[1];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.ICompoundPrint);
                return t;
            }
        }

        #endregion
    }
}

