using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Order;
using Neusoft.FrameWork;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInpatientCharge_new : UserControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucInpatientCharge_new()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 项目列表
        /// </summary>
        private ucItemList ucItemList = null;

        /// <summary>
        /// 执行科室选择列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbDept = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();

        /// <summary>
        /// 加载项目类别
        /// </summary>
        private EnumShowItemType itemKind;

        /// <summary>
        /// 控件功能
        /// </summary>
        private FeeTypes feeType;

        /// <summary>
        /// 当前行
        /// </summary>
        private int rowCount;
      
        /// <summary>
        /// 如果正在进行小计运算，所有触发事件选择性返回
        /// </summary>
        private bool isSubTotal;

        /// <summary>
        /// 成功提示信息
        /// </summary>
        private string sucessMsg = string.Empty;

        /// <summary>
        /// 是否允许划价金额为0的项目
        /// </summary>
        private bool isChargeZero;

        /// <summary>
        /// 默认执行科室
        /// </summary>
        private string defaultExeDept;

        /// <summary>
        /// 开方医生
        /// </summary>
        private string recipeDoctCode;

        /// <summary>
        /// 是否验证及时停用标记
        /// </summary>
        private bool isJudgeValid = false;

        #region addby xuewj 2010-9-21 {6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单

        /// <summary>
        /// 是否打印病区记账单
        /// </summary>
        private bool isPrintFeeSheet = false;

        /// <summary>
        /// 记账单打印接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet nurseFeeBill = null;

        #endregion

        #region addby xuewj 2010-10-8 打印药品记账单 {1C1B0872-954C-4eb3-9E15-9072E8139AF9}

        /// <summary>
        /// 是否打印药品记账单
        /// </summary>
        private bool isPrintDrugFeeSheet = false;

        /// <summary>
        /// 药品记账单打印接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.Order.IDrugFeeSheet nurseDrugFeeBill = null;

        #endregion

        /// <summary>
        /// 患者基本信息实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 医疗保险,公费接口类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterface = null;

        /// <summary>
        /// 住院费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 非药品业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 科室业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department departmentManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        /// <summary>
        /// 组套业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.ComGroupTail groupDetailManager = new Neusoft.HISFC.BizLogic.Manager.ComGroupTail();

        /// <summary>
        /// 人员信息业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactUnitManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        ///// <summary>
        ///// 非药品组合项目业务层
        ///// </summary>
        private Neusoft.HISFC.BizLogic.Fee.UndrugPackAge undrugPackageManager = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();

        /// <summary>
        /// 非药品项目业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Item itemManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 药品综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

        /// <summary>
        /// 是否判断欠费，如何提示
        /// </summary>
        private Neusoft.HISFC.Models.Base.MessType messtype = Neusoft.HISFC.Models.Base.MessType.Y;
        Neusoft.HISFC.Models.Base.Employee operObj = null;

        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 处方科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject recipeDept = null;
        private bool isJudgeQty = true; //是否判断数量
        private bool defaultExeDeptIsDeptIn = false;

        /// <summary>
        /// 本次收费项目集合
        /// </summary>
        private List<FeeItemList> feeItemCollection = new List<FeeItemList>();
        //{062CEAA8-16B8-4c25-B4CC-E6B24DE7D331}
        private HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessInPatient IAdptIllnessInPatient = null;

        /// <summary>
        /// 当前物资的扣库科室
        /// </summary>
        private FrameWork.Models.NeuObject tempDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否拆分复合项目到界面上{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        private bool isSplitUndrugCombItem = false;
        //{F4912030-EF65-4099-880A-8A1792A3B449} 结束

        //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        //备份组套
        Hashtable hsGroup = new Hashtable();
 
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}

        Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFeeTree iShowFeeTree = null;
 
        /// <summary>
        /// 是否在点击删除按钮时提示“是否删除第*行”,True提示，False不提示，直接删除 {AE199B83-DC7A-423b-9CEE-9553BAF19DB6} wbo 2010-10-21
        /// </summary>
        private bool isShowDelDiag = true;

 
        #endregion

        #region 属性
        /// <summary>
        /// 是否拆分复合项目到界面上{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        [Category("控件设置"), Description("设置该控件是否在界面上分解复合项目 true分解 false不分解")]
        public bool IsSplitUndrugCombItem 
        {
            get 
            {
                return this.isSplitUndrugCombItem;
            }
            set 
            {
                this.isSplitUndrugCombItem = value;
            }
        }
        //{F4912030-EF65-4099-880A-8A1792A3B449} 结束

        /// <summary>
        /// 患者基本信息实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set 
            {
                this.patientInfo = value;
                this.ucItemList.Patient = value;// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                QueryDayFeeByInpaientNO(patientInfo.ID);
            }
        }

        /// <summary>
        /// 当前行
        /// </summary>
        public int RowCount 
        {
            get 
            {
                return this.rowCount;
            }
            set 
            {
                this.rowCount = value;
            }
        }

        /// <summary>
        /// 成功提示信息
        /// </summary>
        public string SucessMsg 
        {
            get 
            {
                return this.sucessMsg;
            }
        }
        
        /// <summary>
        /// 加载的项目类别
        /// </summary>
        [Category("控件设置"), Description("设置该控件加载的项目类别 药品:drug 非药品 undrug 所有: all")]
        public EnumShowItemType 加载项目类别 
        {
            get 
            {
                return this.itemKind;
            }
            set 
            {
                this.itemKind = value;
            }
        }

        /// <summary>
        /// 控件功能
        /// </summary>
        [Category("控件设置"), Description("获得或者设置该控件的主要功能"), DefaultValue(1)]
        public FeeTypes 控件功能
        {
            get 
            {
                return this.feeType;
            }
            set 
            {
                this.feeType = value;
            }
        }

        /// <summary>
        /// 是否可以收费或者划价0单价的项目
        /// </summary>
        [Category("控件设置"), Description("获得或者设置是否可以收费或者划价"), DefaultValue(false)]
        public bool IsChargeZero 
        {
            get 
            {
                return this.isChargeZero;
            }
            set 
            {
                this.isChargeZero = value;
            }
        }
        [Category("控件设置"),Description("是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            get
            {
                return this.messtype;
            }
            set
            {
                this.messtype = value;
            }
        }
        [Category("控件设置"), Description("数量为零是否提示")]
        public bool IsJudgeQty
        {
            get
            {
                return isJudgeQty;
            }
            set
            {
                isJudgeQty = value;
            }
        }

        [Category("控件设置"), Description("执行科室是否默认为登陆科室")]
        public bool DefaultExeDeptIsDeptIn
        {
            get
            {
                return defaultExeDeptIsDeptIn;
            }
            set
            {
                defaultExeDeptIsDeptIn = value;
            }
        }

        #region  addby xuewj 2010-9-21 {6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单

        [Category("控件设置"), Description("是否打印病区记账单")]
        public bool IsPrintFeeSheet
        {
            get { return isPrintFeeSheet; }
            set { isPrintFeeSheet = value; }
        }

        //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        bool isLongFee = false;
        /// <summary>
        /// 是否是长期收费 by nxy{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        /// </summary>
        [Category("控件设置"), Description("是否长期：true 长期批费 false 临时"), DefaultValue(false)]
        public bool IsLongFee
        {
            get { return isLongFee; }
            set
            {
                isLongFee = value;
                if (isLongFee)
                {
                    this.neuGroupBox1.Text = "【长期】记账明细";
                }
                else
                {
                    this.neuGroupBox1.Text = "【临时】记账明细";
                }
            }
        }

        [Category("控件设置"), Description("是否显示明细：true 显示 false 不显示"), DefaultValue(false)]
        public bool IsShowDetail
        {
            get { return neuGroupBox1.Visible; }
            set { neuGroupBox1.Visible = value; }
        } 

        #endregion

        #region addby xuewj 2010-10-8 打印药品记账单 {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
        /// <summary>
        /// 是否打印药品记账单
        /// </summary>
        [Category("控件设置"), Description("是否打印药品记账单")]
        public bool IsPrintDrugFeeSheet
        {
            get { return isPrintDrugFeeSheet; }
            set { isPrintDrugFeeSheet = value; }
        } 
        #endregion

         //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        private string arrFeeGate = string.Empty;
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        [Category("控件设置"), Description("树形控件加载统计大类类别")]
        public string ArrFeeGate
        {
            get { return arrFeeGate; }
            set { arrFeeGate = value; }
        }
       
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        [Category("控件设置"), Description("树形控件加载统计大类类别")]
        public bool IsShowItemTree
        {
            get { return this.pnItemTree.Visible; }
            set { this.pnItemTree.Visible = value; }
        }
        
        /// <summary>
        /// 医疗保险,公费接口类
        /// </summary>
        public Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy MedcareInterface 
        {
            set 
            {
                this.medcareInterface = value;
            }
        }

        /// <summary>
        /// 默认执行科室
        /// </summary>
        public string DefaultExeDept
        {
            get
            {
                return this.defaultExeDept;
            }
            set
            {
                this.defaultExeDept = value;
            }
        }

        /// <summary>
        /// 开方医生
        /// </summary>
        public string RecipeDoctCode
        {
            get
            {
                return this.recipeDoctCode;
            }
            set
            {
                this.recipeDoctCode = value;
            }
        }

        /// <summary>
        /// 是否验证及时停用标记
        /// </summary>
        public bool IsJudgeValid 
        {
            get 
            {
                return this.isJudgeValid;
            }
            set
            {
                this.isJudgeValid = value;
            }
        }

        /// <summary>
        /// 处方科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RecipeDept
        {
            set
            {
                this.recipeDept = value;
            }
        }

        /// <summary>
        /// 本次收费项目集合
        /// </summary>
        public List<FeeItemList> FeeItemCollection
        {
            get
            {
                return this.feeItemCollection;
            }
        }

        /// <summary>
        /// 是否在点击删除按钮时提示“是否删除第*行”,True提示，False不提示，直接删除 {AE199B83-DC7A-423b-9CEE-9553BAF19DB6} wbo 2010-10-21
        /// </summary>
        [Category("设置"), Description("设置是否在点击删除按钮时提示“是否删除第*行”,True提示，False不提示，直接删除")]
        public bool IsShowDelDiag
        {
            set { this.isShowDelDiag = value; }
            get { return this.isShowDelDiag; }
        }
        
        #endregion

        #region 私有方法
        //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        /// <summary>
        /// 将项目列表中项目添加到划价列表
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <param name="execDeptCode"></param>
        /// <param name="isFeegroup">是否费用组套</param>
        /// <returns></returns>
        protected virtual int AddChargeDetail(Neusoft.HISFC.Models.Base.Item item, int row, string execDeptCode,bool isFeegroup)
        {
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("请先选择患者,然后收费!"));

                return -1;
            }
            decimal price = 0;
            //if (this.pactUnitManager.GetPrice(this.patientInfo, item.IsPharmacy, item.ID, ref price) == -1)
            if (item.ItemType != EnumItemType.MatItem)
            {
                if (this.pactUnitManager.GetPrice(this.patientInfo, item.ItemType, item.ID, ref price) == -1)
                {
                    MessageBox.Show(Language.Msg("取项目:") + item.Name + Language.Msg("的价格出错!") + this.pactUnitManager.Err);

                    return -1;
                }
                item.Price = price;
            }

            //{1128E694-C90B-4df1-A4AF-BB758A9F1C01} lvxl 2010-3-4
            this.fpDetail_Sheet.SetValue(row, (int)Columns.InpatientNO, patientInfo.PID.CaseNO, false);
            this.fpDetail_Sheet.SetValue(row, (int)Columns.InpatientName, patientInfo.Name, false);
            this.fpDetail_Sheet.Cells[row, (int)Columns.InpatientNO].Tag = patientInfo;
            //{1128E694-C90B-4df1-A4AF-BB758A9F1C01}


            //药品默认按最小单位收费,显示价格也为最小单位价格,存入数据库的为包装单位价格
            //if (item.IsPharmacy)//药品
            if (item.ItemType == EnumItemType.Drug)//药品
            {
                if (item.SpecialFlag4 == "2") //包装单位
                {
                    price = Neusoft.FrameWork.Public.String.FormatNumber(item.Price, 4);
                }
                else //最小单位
                {
                    price = Neusoft.FrameWork.Public.String.FormatNumber(item.Price / item.PackQty, 4);   
                }

                this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, price, false);
            }
            else//非药品
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, item.Price, false);

                price = item.Price;
            }

            //存储项目实体便于价格等计算{F98CC89C-BE9A-49ca-98E2-4C700A8F5E34}
            this.fpDetail_Sheet.Rows[row].Tag = item;

            //数量
            this.fpDetail_Sheet.SetValue(row, (int)Columns.Qty, item.Qty, false);

            //判断焦点跳转
            if (item.Price != 0)
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = true;
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Qty);
            }
            else
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = false;
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Price);
            }

            //草药付数
            this.fpDetail_Sheet.SetValue(row, (int)Columns.Day, NConvert.ToInt32(item.User03), false);

            //if (item.IsPharmacy && item.SysClass.ID.ToString() == "PCC")
            if (item.ItemType == EnumItemType.Drug && item.SysClass.ID.ToString() == "PCC")
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = false;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = Color.Black;
            }
            else
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = true;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = Color.Transparent;
            }
            //药品可选择药品收费单位,默认为最小单位
            //if (item.IsPharmacy)
            if(item.ItemType == EnumItemType.Drug)
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboType.Editable = true;
                comboType.Items = (new string[]{(item as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit,
                                                (item as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit});
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].CellType = comboType;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Locked = false;

                if (item.SpecialFlag4 == "2") //包装单位
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, ((Neusoft.HISFC.Models.Pharmacy.Item)item).PackUnit, false);
                    item.PriceUnit = ((Neusoft.HISFC.Models.Pharmacy.Item)item).PackUnit;
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, ((Neusoft.HISFC.Models.Pharmacy.Item)item).MinUnit, false);
                    item.PriceUnit = ((Neusoft.HISFC.Models.Pharmacy.Item)item).MinUnit;
                }
            }
            else//非药品
            {
                FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].CellType = textType;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Locked = true;
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, item.PriceUnit, false);
            }


            //总额
            this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, price * item.Qty, false);
            //项目名称,和规格显示在一起
            if (item.Specs != null && item.Specs != string.Empty)
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, item.Name + "{" + item.Specs + "}", false);
            }
            else
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, item.Name, false);
            }

            //新录入的项目			
            this.fpDetail_Sheet.SetValue(row, (int)Columns.IsNew, "1", false);
            //标识药品、非药品
            //if (item.IsPharmacy)
            if(item.ItemType == EnumItemType.Drug)
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "1", false);
            }
            else
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "0", false);
            }

            string deptCode = string.Empty, deptName = string.Empty;
            if (!defaultExeDeptIsDeptIn)
            {
                #region 获取默认执行科室
                //获取项目默认执行科室
                if (execDeptCode == null || execDeptCode == string.Empty)
                {
                    this.GetItemDept(item, ref deptCode, ref deptName);
                }
                else
                {
                    Neusoft.HISFC.Models.Base.Department dept = this.departmentManager.GetDeptmentById(execDeptCode);
                    deptCode = execDeptCode;
                    if (dept == null)
                    {
                        deptName = "(无)";
                    }
                    else
                    {
                        deptName = dept.Name;
                    }
                }
                #endregion
            }
            else
            {
                deptCode = this.operObj.Dept.ID;
                deptName = this.operObj.Dept.Name;
            }

            this.fpDetail_Sheet.SetValue(row, (int)Columns.Dept, deptName, false);
            //表示科室未修改
            this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDeptChange, "0", false);

            //赋值给收费实体
            FeeItemList feeitemlist = new FeeItemList();
            feeitemlist.Item = item;
            feeitemlist.ExecOper.Dept.ID = deptCode;
            feeitemlist.ExecOper.Dept.Name = deptName;
            feeitemlist.Days = NConvert.ToInt32(item.User03);//草药付数
            //指定药品的摆药药房
            if (item is Neusoft.HISFC.Models.Pharmacy.Item)
            {
                feeitemlist.StockOper.Dept.ID = item.User02;
            }

            //保存复合项目
            feeitemlist.UndrugComb.ID = item.MinFee.User01;
            feeitemlist.UndrugComb.Name = item.MinFee.User02;

            feeitemlist.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(price * item.Qty, 2);

            this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemObject, feeitemlist, false);
            //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
            this.fpDetail_Sheet.Cells[row, (int)Columns.ItemName].Tag = isFeegroup;
            this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Tag = item.SysClass.User01; //费用组套编码
            if (isFeegroup)
            {
                //组合号
                this.fpDetail_Sheet.Cells[row, (int)Columns.GroupID].Text = item.SysClass.User01;
                //上次收费时间
                this.fpDetail_Sheet.Cells[row, (int)Columns.FeeDate].Text = item.MinFee.User03;
                 
                if (!string.IsNullOrEmpty(item.MinFee.User03))
                {
                    DateTime feeDate = NConvert.ToDateTime(item.MinFee.User03);
                    DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
                    DateTime beginDate = NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 00:00:00");
                    DateTime endDate = NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 23:59:59");
                    if (feeDate >= beginDate && feeDate <= endDate)
                    {
                        //this.fpDetail_Sheet.Rows[row].BackColor = Color.Green;
                        this.fpDetail_Sheet.Rows[row].BackColor = Color.FromArgb(-16711681);
                        //{4BFDF0F4-5827-4c19-952C-3482CED1E7B8}
                        //this.fpDetail_Sheet.Rows[row].Locked = true;
                    }

                }
            }

            //{062CEAA8-16B8-4c25-B4CC-E6B24DE7D331}
            if (IAdptIllnessInPatient != null)
            {
                int resultValue = IAdptIllnessInPatient.ProcessInpatientFeeDetail(this.patientInfo, ref feeitemlist);
                if (resultValue < 0) return -1;
            }
            return 0;
        }
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        protected virtual int AddChargeDetailAddRow(Neusoft.HISFC.Models.Base.Item item, int row, string execDeptCode, bool isFeegroup)
        {
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("请先选择患者,然后收费!"));

                return -1;
            }
            decimal price = 0;
            //if (this.pactUnitManager.GetPrice(this.patientInfo, item.IsPharmacy, item.ID, ref price) == -1)
            if (item.ItemType != EnumItemType.MatItem)
            {
                if (this.pactUnitManager.GetPrice(this.patientInfo, item.ItemType, item.ID, ref price) == -1)
                {
                    MessageBox.Show(Language.Msg("取项目:") + item.Name + Language.Msg("的价格出错!") + this.pactUnitManager.Err);

                    return -1;
                }
                item.Price = price;
            }

            //{1128E694-C90B-4df1-A4AF-BB758A9F1C01} lvxl 2010-3-4
            this.fpDetail_Sheet.SetValue(row, (int)Columns.InpatientNO, patientInfo.PID.CaseNO, false);
            this.fpDetail_Sheet.SetValue(row, (int)Columns.InpatientName, patientInfo.Name, false);
            this.fpDetail_Sheet.Cells[row, (int)Columns.InpatientNO].Tag = patientInfo;
            //{1128E694-C90B-4df1-A4AF-BB758A9F1C01}


            //药品默认按最小单位收费,显示价格也为最小单位价格,存入数据库的为包装单位价格
            //if (item.IsPharmacy)//药品
            if (item.ItemType == EnumItemType.Drug)//药品
            {
                if (item.SpecialFlag4 == "2") //包装单位
                {
                    price = Neusoft.FrameWork.Public.String.FormatNumber(item.Price, 4);
                }
                else //最小单位
                {
                    price = Neusoft.FrameWork.Public.String.FormatNumber(item.Price / item.PackQty, 4);
                }

                this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, price, false);
            }
            else//非药品
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, item.Price, false);

                price = item.Price;
            }

            //存储项目实体便于价格等计算{F98CC89C-BE9A-49ca-98E2-4C700A8F5E34}
            this.fpDetail_Sheet.Rows[row].Tag = item;

            //数量
            this.fpDetail_Sheet.SetValue(row, (int)Columns.Qty, item.Qty, false);

            //判断焦点跳转
            if (item.Price != 0)
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = true;
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Qty);
            }
            else
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = false;
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Price);
            }

            //草药付数
            this.fpDetail_Sheet.SetValue(row, (int)Columns.Day, NConvert.ToInt32(item.User03), false);

            //if (item.IsPharmacy && item.SysClass.ID.ToString() == "PCC")
            if (item.ItemType == EnumItemType.Drug && item.SysClass.ID.ToString() == "PCC")
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = false;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = Color.Black;
            }
            else
            {
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = true;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = Color.Transparent;
            }
            //药品可选择药品收费单位,默认为最小单位
            //if (item.IsPharmacy)
            if (item.ItemType == EnumItemType.Drug)
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboType.Editable = true;
                comboType.Items = (new string[]{(item as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit,
                                                (item as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit});
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].CellType = comboType;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Locked = false;

                if (item.SpecialFlag4 == "2") //包装单位
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, ((Neusoft.HISFC.Models.Pharmacy.Item)item).PackUnit, false);
                    item.PriceUnit = ((Neusoft.HISFC.Models.Pharmacy.Item)item).PackUnit;
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, ((Neusoft.HISFC.Models.Pharmacy.Item)item).MinUnit, false);
                    item.PriceUnit = ((Neusoft.HISFC.Models.Pharmacy.Item)item).MinUnit;
                }
            }
            else//非药品
            {
                FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].CellType = textType;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Locked = true;
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, item.PriceUnit, false);
            }


            //总额
            this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, price * item.Qty, false);
            //项目名称,和规格显示在一起
            if (item.Specs != null && item.Specs != string.Empty)
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, item.Name + "{" + item.Specs + "}", false);
            }
            else
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, item.Name, false);
            }

            //新录入的项目			
            this.fpDetail_Sheet.SetValue(row, (int)Columns.IsNew, "1", false);
            //标识药品、非药品
            //if (item.IsPharmacy)
            if (item.ItemType == EnumItemType.Drug)
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "1", false);
            }
            else
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "0", false);
            }

            string deptCode = string.Empty, deptName = string.Empty;
            if (!defaultExeDeptIsDeptIn)
            {
                #region 获取默认执行科室
                //获取项目默认执行科室
                if (execDeptCode == null || execDeptCode == string.Empty)
                {
                    this.GetItemDept(item, ref deptCode, ref deptName);
                }
                else
                {
                    Neusoft.HISFC.Models.Base.Department dept = this.departmentManager.GetDeptmentById(execDeptCode);
                    deptCode = execDeptCode;
                    if (dept == null)
                    {
                        deptName = "(无)";
                    }
                    else
                    {
                        deptName = dept.Name;
                    }
                }
                #endregion
            }
            else
            {
                deptCode = this.operObj.Dept.ID;
                deptName = this.operObj.Dept.Name;
            }

            this.fpDetail_Sheet.SetValue(row, (int)Columns.Dept, deptName, false);
            //表示科室未修改
            this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDeptChange, "0", false);

            //赋值给收费实体
            FeeItemList feeitemlist = new FeeItemList();
            feeitemlist.Item = item;
            feeitemlist.ExecOper.Dept.ID = deptCode;
            feeitemlist.ExecOper.Dept.Name = deptName;
            feeitemlist.Days = NConvert.ToInt32(item.User03);//草药付数
            //指定药品的摆药药房
            if (item is Neusoft.HISFC.Models.Pharmacy.Item)
            {
                feeitemlist.StockOper.Dept.ID = item.User02;
            }

            //保存复合项目
            feeitemlist.UndrugComb.ID = item.MinFee.User01;
            feeitemlist.UndrugComb.Name = item.MinFee.User02;

            feeitemlist.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(price * item.Qty, 2);

            this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemObject, feeitemlist, false);
            //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
            this.fpDetail_Sheet.Cells[row, (int)Columns.ItemName].Tag = isFeegroup;
            this.fpDetail_Sheet.Cells[row, (int)Columns.Unit].Tag = item.SysClass.User01; //费用组套编码
            if (isFeegroup)
            {
                //组合号
                this.fpDetail_Sheet.Cells[row, (int)Columns.GroupID].Text = item.SysClass.User01;
                //上次收费时间
                this.fpDetail_Sheet.Cells[row, (int)Columns.FeeDate].Text = item.MinFee.User03;

                if (!string.IsNullOrEmpty(item.MinFee.User03))
                {
                    DateTime feeDate = NConvert.ToDateTime(item.MinFee.User03);
                    DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
                    DateTime beginDate = NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 00:00:00");
                    DateTime endDate = NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 23:59:59");
                    if (feeDate >= beginDate && feeDate <= endDate)
                    {
                        //this.fpDetail_Sheet.Rows[row].BackColor = Color.Green;
                        this.fpDetail_Sheet.Rows[row].BackColor = Color.FromArgb(-16711681);
                        //{4BFDF0F4-5827-4c19-952C-3482CED1E7B8}
                        //this.fpDetail_Sheet.Rows[row].Locked = true;
                    }

                }
            }

            //{062CEAA8-16B8-4c25-B4CC-E6B24DE7D331}
            if (IAdptIllnessInPatient != null)
            {
                int resultValue = IAdptIllnessInPatient.ProcessInpatientFeeDetail(this.patientInfo, ref feeitemlist);
                if (resultValue < 0) return -1;
            }

            this.fpDetail_Sheet.AddRows(this.fpDetail_Sheet.RowCount - 1, 1);
            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.RowCount - 2, 2);
            this.fpDetail.Focus();
            return 0;
        }

        /// <summary>
        /// 添加患者划价明细
        /// </summary>
        /// <param name="feeItemList">费用信息实体</param>
        /// <param name="row">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int AddChargeDetail(FeeItemList feeItemList, int row)
        {
            if (feeItemList != null)
            {
                FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
                txtType.ReadOnly = true;

                this.fpDetail_Sheet.Rows[row].BackColor = Color.Khaki;

                //显示名称
                if (feeItemList.Item.Specs != null && feeItemList.Item.Specs != string.Empty)
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, feeItemList.Item.Name + "{" + feeItemList.Item.Specs + "}", false);
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, feeItemList.Item.Name, false);
                }

                this.fpDetail_Sheet.Cells[row, (int)Columns.ItemName].CellType = txtType;

                //显示价格
                decimal price = 0;
                //if (feeItemList.Item.IsPharmacy)
                if(feeItemList.Item.ItemType == EnumItemType.Drug)
                {
                    price = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.Item.Price / feeItemList.Item.PackQty, 4);
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, price, false);
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, feeItemList.Item.Price, false);
                }

                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = true;

                //显示付数
                if (feeItemList.Days == 0)
                {
                    feeItemList.Days = 1;
                }
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Day, feeItemList.Days, false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = true;

                //草药
                //if (feeItemList.Item.IsPharmacy && feeItemList.Item.MinFee.ID == "003")
                if (feeItemList.Item.ItemType == EnumItemType.Drug && feeItemList.Item.MinFee.ID == "003")
                {
                    this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = Color.Black;
                }
                else
                {
                    this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = this.fpDetail_Sheet.Rows[row].BackColor;
                }

                //数量
                feeItemList.Item.Qty = feeItemList.Item.Qty / feeItemList.Days;

                this.fpDetail_Sheet.SetValue(row, (int)Columns.Qty, feeItemList.Item.Qty, false);

                this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, feeItemList.Item.PriceUnit, false);
                this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, feeItemList.FT.TotCost, false);

                Department dept = this.departmentManager.GetDeptmentById(feeItemList.ExecOper.Dept.ID);

                if (dept == null)
                {
                    dept = new Department();
                    dept.Name = "(无)";
                }

                this.fpDetail_Sheet.SetValue(row, (int)Columns.Dept, dept.Name, false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Dept].CellType = txtType;

                feeItemList.ExecOper.Dept.ID = dept.ID;
                feeItemList.ExecOper.Dept.Name = dept.Name;
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemObject, feeItemList, false);
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsNew, "0", false);
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDeptChange, "0", false);

                //if (feeItemList.Item.IsPharmacy)
                if(feeItemList.Item.ItemType == EnumItemType.Drug)
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "1", false);
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "0", false);
                }
            }

            return 1;
        }

        /// <summary>
        /// 添加需确认非药品医嘱明细
        /// </summary>
        /// <param name="execOrder">医嘱执行档信息</param>
        /// <param name="row">当前行</param>
        /// <returns>成功 1 失败: -1</returns>
        protected int AddOrderDetail(ExecOrder execOrder, int row)
        {
            if (execOrder != null)
            {
                //未处理复合项目
                FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
                txtType.ReadOnly = true;
                this.fpDetail_Sheet.Rows[row].BackColor = Color.LightSkyBlue;

                //项目名称
                if (execOrder.Order.Item.Specs != null && execOrder.Order.Item.Specs != string.Empty)
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, execOrder.Order.Item.Name + "{" + execOrder.Order.Item.Specs + "}", false);
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemName, execOrder.Order.Item.Name, false);
                }
                this.fpDetail_Sheet.Cells[row, (int)Columns.ItemName].CellType = txtType;

                //价格
                decimal price = 0;
                if (execOrder.Order.Unit != "[复合项]")
                {

                    //if (this.pactUnitManager.GetPrice(this.patientInfo, false, execOrder.Order.Item.ID, ref price) == -1)
                    if (this.pactUnitManager.GetPrice(this.patientInfo, EnumItemType.UnDrug, execOrder.Order.Item.ID, ref price) == -1)
                    {
                        MessageBox.Show(Language.Msg("获取项目价格出错!"));

                        return -1;
                    }
                    if (price != 0)
                    {
                        execOrder.Order.Item.Price = price;
                    }
                }
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Price, execOrder.Order.Item.Price, false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Price].Locked = true;

                //数量
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Qty, execOrder.Order.Qty, false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Qty].Locked = true;

                //付数
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Day, "1", false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].Locked = true;
                this.fpDetail_Sheet.Cells[row, (int)Columns.Day].ForeColor = this.fpDetail_Sheet.Rows[row].BackColor;
                execOrder.Order.HerbalQty = 1;

                //单位
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Unit, execOrder.Order.Unit, false);
                //金额
                this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, execOrder.Order.Qty * execOrder.Order.Item.Price, false);

                //执行科室
                this.fpDetail_Sheet.SetValue(row, (int)Columns.Dept, execOrder.ExecOper.Dept.Name, false);
                this.fpDetail_Sheet.Cells[row, (int)Columns.Dept].CellType = txtType;

                //项目对象
                this.fpDetail_Sheet.SetValue(row, (int)Columns.ItemObject, execOrder, false);

                //是否新增项目,0原有(数据库中),1新增,2修改
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsNew, "0", false);

                //执行科室是否修改0,否 1是
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDeptChange, "0", false);

                //收费药品，1是0否
                this.fpDetail_Sheet.SetValue(row, (int)Columns.IsDrug, "0", false);
            }

            return 1;
        }

        /// <summary>
        /// 添加组套明细到划价列表
        /// </summary>
        /// <param name="groupID">组套项目ID</param>
        /// <param name="row">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        public int AddGroupDetail(string groupID, int row)
        {
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("请先选择患者,然后收费!"));

                return -1;
            }

            ArrayList groupDetails = new ArrayList();
            //根据组套id获取组套明细
            groupDetails = this.groupDetailManager.GetComGroupTailByGroupID(groupID);
            if (groupDetails == null || groupDetails.Count == 0)
            {
                return -1;
            }
            int count = 0;
            for (int i = 0; i < groupDetails.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.ComGroupTail groupDetail = groupDetails[i] as Neusoft.HISFC.Models.Fee.ComGroupTail;
                if (groupDetail.drugFlag == "1")//药品
                {
                    //根据药品id获取药品实体
                    Neusoft.HISFC.Models.Pharmacy.Storage drugStorate = null;

                    drugStorate = this.pharmacyIntergrate.GetItemForInpatient(this.patientInfo.PVisit.PatientLocation.Dept.ID, groupDetail.itemCode);
                    if (drugStorate == null || drugStorate.Item.ID == string.Empty) continue;
                    count++;
                    //添加到划价列表
                    Neusoft.HISFC.Models.Base.Item drugBase = drugStorate.Item as Neusoft.HISFC.Models.Base.Item;
                    //drugBase.IsPharmacy = true;
                    drugBase.ItemType = EnumItemType.Drug;
                    drugBase.Qty = groupDetail.qty;
                    drugBase.User03 = "1";
                    drugBase.SpecialFlag4 = groupDetail.unitFlag;

                    #region 直接在第一行增加组套明细 ,比其他算法简单点
                    if (count > 1)
                    {
                        this.AddRow(row + count - 1);
                    }

                    

                    this.AddChargeDetail(drugBase, row + count - 1, groupDetail.deptCode,false);    
                    #endregion 
                }
                else//非药品
                {
                    //根据非药品id获取非药品实体
                    Neusoft.HISFC.Models.Fee.Item.Undrug undrug = null;

                    undrug = this.undrugManager.GetValidItemByUndrugCode(groupDetail.itemCode);
                    if (undrug == null) continue;
                    count++;
                    //添加划价项目
                    Neusoft.HISFC.Models.Base.Item undrugBase = undrug as Neusoft.HISFC.Models.Base.Item;
                    //undrugBase.IsPharmacy = false;
                    undrugBase.ItemType = EnumItemType.UnDrug;
                    undrugBase.Qty = groupDetail.qty;//数量
                    undrugBase.User03 = "1";//付数
                    //{01797533-5D92-4958-A52B-61540022F202}

                    if (undrug.UnitFlag == "1")
                    {
                        undrugBase.User01 = "[复合项]";
                    }
                    #region 直接在第一行增加组套明细 ,比其他算法简单点
                    if (count > 1)
                    {
                        AddRow(row + count - 1);
                    }
                    this.AddChargeDetail(undrugBase, row + count - 1, groupDetail.deptCode,false); 
                    #endregion 
                }
            }
            return 0;
        }
        /// <summary>
        /// 添加组套明细到划价列表
        /// </summary>
        /// <param name="groupID">组套项目ID</param> 
        /// <returns>成功 1 失败 -1</returns>
        public int AddGroupDetail(string groupID)
        {
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("请先选择患者,然后收费!"));

                return -1;
            }

            ArrayList groupDetails = new ArrayList();
            //根据组套id获取组套明细
            groupDetails = this.groupDetailManager.GetComGroupTailByGroupID(groupID);
            if (groupDetails == null || groupDetails.Count == 0)
            {
                return -1;
            } 
            for (int i = 0; i < groupDetails.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.ComGroupTail groupDetail = groupDetails[i] as Neusoft.HISFC.Models.Fee.ComGroupTail;
                if (groupDetail.drugFlag == "1")//药品
                {
                    //根据药品id获取药品实体
                    Neusoft.HISFC.Models.Pharmacy.Storage drugStorate = null;

                    drugStorate = this.pharmacyIntergrate.GetItemForInpatient(this.patientInfo.PVisit.PatientLocation.Dept.ID, groupDetail.itemCode);
                    if (drugStorate == null || drugStorate.Item.ID == string.Empty) continue;
                    //添加到划价列表
                    Neusoft.HISFC.Models.Base.Item drugBase = drugStorate.Item as Neusoft.HISFC.Models.Base.Item;
                    //drugBase.IsPharmacy = true;
                    drugBase.ItemType = EnumItemType.Drug;
                    drugBase.Qty = groupDetail.qty;
                    drugBase.User03 = "1";
                    drugBase.SpecialFlag4 = groupDetail.unitFlag;

                    #region 直接在第一行增加组套明细 ,比其他算法简单点 
                    this.AddRow(0);
                    this.AddChargeDetail(drugBase,0,groupDetail.deptCode,false);
                    #endregion
                }
                else//非药品
                {
                    //根据非药品id获取非药品实体
                    Neusoft.HISFC.Models.Fee.Item.Undrug undrug = null;

                    undrug = this.undrugManager.GetValidItemByUndrugCode(groupDetail.itemCode);
                    if (undrug == null) continue;
                    //添加划价项目
                    Neusoft.HISFC.Models.Base.Item undrugBase = undrug as Neusoft.HISFC.Models.Base.Item;
                    //undrugBase.IsPharmacy = false;
                    undrugBase.ItemType = EnumItemType.UnDrug;
                    undrugBase.Qty = groupDetail.qty;//数量
                    undrugBase.User03 = "1";//付数
                    #region 直接在第一行增加组套明细 ,比其他算法简单点
                    this.AddRow(0);
                    this.AddChargeDetail(undrugBase, 0, groupDetail.deptCode,false);
                    #endregion
                }
            }
            return 0;
        }
        /// <summary>
        /// 判断价格、数量、执行科室是否合法
        /// </summary>
        /// <returns>-1不合法,0合法</returns>
        public virtual bool IsValid()
        {
            int count = 0;

            if (this.recipeDoctCode == null || this.recipeDoctCode == string.Empty) 
            {
                MessageBox.Show(Language.Msg("请输入开方医生"));

                return false;
            }

            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                object obj = this.fpDetail_Sheet.GetValue(i, (int)Columns.ItemObject);
                //如果当前行不是项目,那么继续下一个判断
                if (obj == null)
                {
                    continue;
                }

                count++;

                string itemName = this.fpDetail_Sheet.GetText(i, (int)Columns.ItemName);//项目名称
                //判断数量
                if (isJudgeQty)
                {
                    if (!this.IsInputValid(itemName, i, Columns.Qty, true, "的执行数量不能小于等于零!"))
                    {
                        return false;
                    }
                } 

                //读取的医嘱项目不判断执行科室和价格
                if (obj is FeeItemList)
                {
                    //判断价格
                    if (!this.IsInputValid(itemName, i, Columns.Price, true, "的项目价格不能小于等于零!"))
                    {
                        return false;
                    }

                    //判断付数
                    if (!this.IsInputValid(itemName, i, Columns.Day, true, "的付数不能小于等于零!"))
                    {
                        return false;
                    }

                    //药品判断单位
                    //if (((FeeItemList)obj).Item.IsPharmacy && this.fpDetail_Sheet.GetText(i, (int)Columns.IsNew) == "1")
                    if (((FeeItemList)obj).Item.ItemType == EnumItemType.Drug && this.fpDetail_Sheet.GetText(i, (int)Columns.IsNew) == "1")
                    {
                        string tempValue = this.fpDetail_Sheet.GetText(i, (int)Columns.Unit);
                        FarPoint.Win.Spread.CellType.ComboBoxCellType comboType =
                            (FarPoint.Win.Spread.CellType.ComboBoxCellType)this.fpDetail_Sheet.Cells[i, (int)Columns.Unit].CellType;
                        if (tempValue != comboType.Items[0] && tempValue != comboType.Items[1])
                        {
                            MessageBox.Show(itemName + Language.Msg("的发药单位录入错误,请重新录入!"));
                            this.fpDetail.Focus();
                            this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.Unit);

                            return false;
                        }
                    }

                    //判断科室
                    if (((FeeItemList)obj).ExecOper.Dept.ID == string.Empty)
                    {
                        MessageBox.Show(itemName + Language.Msg("的执行科室不能为空!"));
                        this.fpDetail.Focus();
                        this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.Dept);

                        return false;
                    }
                }
            }
            //无明细，返还
            if (count == 0)
            {
                MessageBox.Show(Language.Msg("请录入项目明细!"));
                this.fpDetail.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断价格、数量、执行科室是否合法{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        /// </summary>
        /// <returns>-1不合法,0合法</returns>
        public virtual bool IsValidForZT(ref int count )
        {
            count = 0;

            //if (this.recipeDoctCode == null || this.recipeDoctCode == string.Empty)
            //{
            //    MessageBox.Show(Language.Msg("请输入开方医生"));

            //    return false;
            //}

            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                object obj = this.fpDetail_Sheet.GetValue(i, (int)Columns.ItemObject);
                //如果当前行不是项目,那么继续下一个判断
                if (obj == null)
                {
                    continue;
                }

                count++;

                string itemName = this.fpDetail_Sheet.GetText(i, (int)Columns.ItemName);//项目名称
                //判断数量
                if (isJudgeQty)
                {
                    if (!this.IsInputValid(itemName, i, Columns.Qty, true, "的执行数量不能小于等于零!"))
                    {
                        return false;
                    }
                }

                //读取的医嘱项目不判断执行科室和价格
                if (obj is FeeItemList)
                {
                    //判断价格
                    if (!this.IsInputValid(itemName, i, Columns.Price, true, "的项目价格不能小于等于零!"))
                    {
                        return false;
                    }

                    //判断付数
                    if (!this.IsInputValid(itemName, i, Columns.Day, true, "的付数不能小于等于零!"))
                    {
                        return false;
                    }

                    //药品判断单位
                    //if (((FeeItemList)obj).Item.IsPharmacy && this.fpDetail_Sheet.GetText(i, (int)Columns.IsNew) == "1")
                    if (((FeeItemList)obj).Item.ItemType == EnumItemType.Drug && this.fpDetail_Sheet.GetText(i, (int)Columns.IsNew) == "1")
                    {
                        string tempValue = this.fpDetail_Sheet.GetText(i, (int)Columns.Unit);
                        FarPoint.Win.Spread.CellType.ComboBoxCellType comboType =
                            (FarPoint.Win.Spread.CellType.ComboBoxCellType)this.fpDetail_Sheet.Cells[i, (int)Columns.Unit].CellType;
                        if (tempValue != comboType.Items[0] && tempValue != comboType.Items[1])
                        {
                            MessageBox.Show(itemName + Language.Msg("的发药单位录入错误,请重新录入!"));
                            this.fpDetail.Focus();
                            this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.Unit);

                            return false;
                        }
                    }

                    //判断科室
                    if (((FeeItemList)obj).ExecOper.Dept.ID == string.Empty)
                    {
                        MessageBox.Show(itemName + Language.Msg("的执行科室不能为空!"));
                        this.fpDetail.Focus();
                        this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.Dept);

                        return false;
                    }
                }
            }
            ////无明细，返还
            //if (count == 0)
            //{
            //    MessageBox.Show(Language.Msg("请录入项目明细!"));
            //    this.fpDetail.Focus();

            //    return false;
            //}

            return true;
        }


        /// <summary>
        /// 添加复合项目明细到划价列表
        /// </summary>
        /// <param name="undrugCombCode">组合项目编码</param>
        /// <param name="undrugCombName">组合项目名称</param>
        /// <param name="row">当前行</param>
        /// <param name="execDeptCode">执行科室代码</param>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int AddCompoundDetail(string undrugCombCode, string undrugCombName, int row, string execDeptCode)
        {
            ArrayList details = this.undrugPackageManager.QueryUndrugPackagesBypackageCode(undrugCombCode);

            if (details == null)
            {
                MessageBox.Show(Language.Msg("获得组套信息出错!") + this.undrugPackageManager.Err);

                return -1;
            }

            int count = 0;

            for (int i = 0; i < details.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb = details[i] as Neusoft.HISFC.Models.Fee.Item.UndrugComb;

                //特殊组合项目不处理
                //路志鹏 是否可用1是true可用， 0是false不可用 luzhp@neusoft.com
                if (undrugComb.User01 == "0")
                {
                    continue;
                }

                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = this.itemManager.GetValidItemByUndrugCode(undrugComb.ID);

                if (undrug == null)
                {
                    continue;
                }

                count++;

                //undrug.IsPharmacy = false;
                undrug.ItemType = EnumItemType.UnDrug;

                if (undrugComb.Qty == 0)
                {
                    undrug.Qty = 1;
                }
                else
                {
                    undrug.Qty = undrugComb.Qty;
                }

                undrug.User03 = "1";
                undrug.MinFee.User01 = undrugCombCode;
                undrug.MinFee.User02 = undrugCombName;

                this.AddChargeDetail(undrug, row + count - 1, execDeptCode,false);
            }

            return 1;
        }

        ////{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        /// <summary>
        /// 添加复合项目明细到划价列表
        /// </summary>
        ///<param name="feeGroup">费用组套</param>
        /// <param name="row">当前行</param>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int AddCompoundDetail(FeeGroup feeGroup, int row)
        {
            ArrayList details = this.undrugPackageManager.QueryUndrugPackagesBypackageCode(feeGroup.Item.ID);

            if (details == null)
            {
                MessageBox.Show(Language.Msg("获得组套信息出错!") + this.undrugPackageManager.Err);

                return -1;
            }

            int count = 0;

            for (int i = 0; i < details.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb = details[i] as Neusoft.HISFC.Models.Fee.Item.UndrugComb;

                //特殊组合项目不处理
                //路志鹏 是否可用1是true可用， 0是false不可用 luzhp@neusoft.com
                if (undrugComb.User01 == "0")
                {
                    continue;
                }

                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = this.itemManager.GetValidItemByUndrugCode(undrugComb.ID);

                if (undrug == null)
                {
                    continue;
                }

                count++;

                //undrug.IsPharmacy = false;
                undrug.ItemType = EnumItemType.UnDrug;

                if (undrugComb.Qty == 0)
                {
                    undrug.Qty = 1;
                }
                else
                {
                    undrug.Qty = undrugComb.Qty;
                }

                undrug.User03 = feeGroup.Days == 0 ? "1" : feeGroup.Days.ToString(); //付数
                undrug.MinFee.User01 = feeGroup.Item.ID; //项目编码
                undrug.MinFee.User02 = feeGroup.Item.Name;//项目名称
                undrug.MinFee.Memo = feeGroup.ID; //组套编号
                undrug.MinFee.User03 = feeGroup.FeeDate.ToString();//收费日期
                this.AddChargeDetail(undrug, row + count - 1, feeGroup.ExecDept.ID,true);
            }

            return 1;
        }

        /// <summary>
        /// 项目划价
        /// </summary>
        /// <returns></returns>
        protected virtual int Charge()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.personManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            ////事务管理类
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.inpatientManager.Connection);
            //t.BeginTransaction();
            //this.inpatientManager.SetTrans(t.Trans);
            //this.personManager.SetTrans(t.Trans);

            //操作时间
            DateTime operTime = this.inpatientManager.GetDateTimeFromSysDateTime();
            //开方科室
            Neusoft.HISFC.Models.Base.Employee employee = this.personManager.GetPersonByID(this.recipeDoctCode);
            if (employee == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("人员信息表中无代码为:") + this.recipeDoctCode + Language.Msg("的人员!"));

                return -1;
            }

            string recipeDept = employee.Dept.ID;
            ArrayList feeList = new ArrayList();
            //循环处理
            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                FeeItemList feeItemList = new FeeItemList();
                bool isNew = false;
                int returnValue = 0;

                //项目信息赋值
                returnValue = this.SetItem(i, PayTypes.Charged, recipeDept, operTime, ref isNew, ref feeItemList);

                //如果获得的项目信息为空,不处理
                if (returnValue == 0)
                {
                    continue;
                }
                //如果是新录入项目:
                if (isNew)
                {
                    feeList.Add(feeItemList);
                    //if (feeItemList.Item.IsPharmacy)
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        if (this.inpatientManager.InsertMedItemList(this.patientInfo, feeItemList) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("插入药品划价信息出错!") + this.inpatientManager.Err);
                            this.fpDetail.Focus();
                            this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                            return -1;
                        }
                    }
                    else
                    {
                        if (this.inpatientManager.InsertFeeItemList(this.patientInfo, feeItemList) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("插入非药品划价信息出错!") + this.inpatientManager.Err);
                            this.fpDetail.Focus();
                            this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                            return -1;
                        }
                    }
                }
                //修改的划价项目，只能修改数量
                else
                {
                    feeItemList.ChargeOper.OperTime = operTime;
                    feeItemList.ChargeOper.ID = this.inpatientManager.Operator.ID;
                    //更新原有的费用明细记录的金额和数量
                    if (this.inpatientManager.UpdateChargeInfo(feeItemList) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新原有划价信息记录出错!") + this.inpatientManager.Err);
                        this.fpDetail.Focus();
                        this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                        return -1;
                    }
                }
            }
            //{4FF03BBF-763D-4063-A792-A2264999E79A}
            if (IAdptIllnessInPatient != null)
            {
                int resultValue = IAdptIllnessInPatient.SaveInpatientFeeDetail(this.patientInfo, ref feeList);

                if (resultValue < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.sucessMsg = "划价成功!";

            return 1;
        }

        /// <summary>
        /// 非药品收费
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Fee()
        {
            Employee employee = this.personManager.GetPersonByID(this.recipeDoctCode);

            if (employee == null)
            {
                MessageBox.Show(Language.Msg("获得人员基本信息出错!"));

                return -1;
            }

            if (this.recipeDept != null && this.recipeDept.ID != "")
            {
                employee.Dept = this.recipeDept;
            }

            this.fpDetail.Change -= new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);

            if (!this.IsValid())
            {
                this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
                return -1;
            }



            this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);

            if (inpatientManager.GetStopAccount(this.patientInfo.ID) == "1")
            {
                MessageBox.Show(Language.Msg("该患者处于封帐状态，不能进行收费！"));

                return -1;
            }

            //事务管理类
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.inpatientManager.Connection);
            //t.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntergrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.personManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.departmentManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.pharmacyIntergrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.undrugManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            ArrayList firstInputFeeItemlist = new ArrayList();
            //保存本次收费项目明细信息
            this.feeItemCollection = new List<FeeItemList>();
            string paramRecipeNo = "";//{6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单
            string paramDrugRecipeNo = "";// {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
            //操作时间
            DateTime operTime = this.inpatientManager.GetDateTimeFromSysDateTime();
            //decimal freeCost = this.patientInfo.FT.LeftCost;//余额
            //decimal moneyAlert = this.patientInfo.PVisit.MoneyAlert;//警戒线
            //decimal totCost = 0m;//总金额
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            int RowN = 0;
            if (this.isLongFee)
            {
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                //if (this.IsExitRepeatItem())
                //{
                  
                //    return -1;
                //}

                for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Base.Item itemtemp = this.fpDetail_Sheet.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                    if (itemtemp == null) continue;
                    string groupID = this.fpDetail_Sheet.Cells[i, (int)Columns.GroupID].Text;


                    if (string.IsNullOrEmpty(groupID))
                    {
                        RowN++;
                        break;
                    }
                    DateTime fromdate = operTime.Date;// 当前起始时间
                    //当前起始时间
                    DateTime todate = Neusoft.FrameWork.Function.NConvert.ToDateTime(operTime.Date.ToShortDateString() + " 23:59:59");

                    DateTime lastFeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpDetail_Sheet.Cells[i,(int)Columns.FeeDate].Text);

                    // 如果上次收费时间小于当前时间，则说明有收费记录
                    if (lastFeeDate < fromdate)
                    {
                        //有收费记录
                        RowN++;
                        break;
                    }


                }

              

                if (RowN == 0)
                {
                    this.feeIntergrate.Rollback();
                    MessageBox.Show("今天已经记过帐，不能再记");
                    return -1;
                }

                if (SaveFeeGroupNoTans() < 0)
                {
                    return -1;
                }
            }

           

            //循环处理
            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}

                if (this.isLongFee)
                {
                    Neusoft.HISFC.Models.Base.Item item = this.fpDetail_Sheet.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                    if (item != null)
                    {
                        DateTime fromdate = operTime.Date;
                        DateTime todate = Neusoft.FrameWork.Function.NConvert.ToDateTime(operTime.Date.ToShortDateString() + " 23:59:59");

                        DateTime lastFeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(item.MinFee.User03);

                        if (!string.IsNullOrEmpty(item.MinFee.User03) && (lastFeeDate >= fromdate && lastFeeDate <= todate))
                        {
                             
                            //已经收过费的不出里
 
                            continue;
                        }
                    }
                }


                FeeItemList feeItemList = new FeeItemList();
                bool isNew = false;
                int returnValue = 0;

                //项目信息赋值
                returnValue = this.SetItem(i, PayTypes.Balanced, employee.Dept.ID, operTime, ref isNew, ref feeItemList);

                //如果获得的项目信息为空,不处理
                if (returnValue == 0)
                {
                    continue;
                }

                if (returnValue == -1)
                {
                    this.feeIntergrate.Rollback();

                    return -1;
                }

                //如果是新录入项目
                if (isNew)
                {
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    if (this.isLongFee)
                    {
                        feeItemList.ExtCode = "1";
                    }
                    else
                    {
                        feeItemList.ExtCode = "0";
                    }
                    feeItemList.StockOper.Dept.ID = feeItemList.ExecOper.Dept.ID;
                    firstInputFeeItemlist.Add(feeItemList.Clone());
                    feeItemCollection.Add(feeItemList.Clone());
                }
                // 修改的划价项目，只能修改数量
                else
                {
                    //更新原有的费用明细记录的金额和数量
                    if (this.inpatientManager.UpdateChargeInfo(feeItemList) == -1)
                    {
                        feeIntergrate.Rollback();
                        MessageBox.Show(Language.Msg("更新原有划价信息记录出错!") + this.inpatientManager.Err);
                        this.fpDetail.Focus();
                        this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                        return -1;
                    }

                    //插入费用汇总更新主表--调用组合业务
                    if (this.inpatientManager.FeeAfterCharge((Neusoft.HISFC.Models.RADT.PatientInfo)this.fpDetail_Sheet.Cells[i, (int)Columns.InpatientNO].Tag, feeItemList) == -1)
                    {
                        feeIntergrate.Rollback();
                        MessageBox.Show(feeItemList.Item.Name + Language.Msg("更改项目后收费出错!") + this.inpatientManager.Err);
                        this.fpDetail.Focus();
                        this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                        return -1;
                    }

                    //药品加入申请表
                    //if (feeItemList.Item.IsPharmacy)
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        if (this.pharmacyIntergrate.ApplyOut((Neusoft.HISFC.Models.RADT.PatientInfo)this.fpDetail_Sheet.Cells[i, (int)Columns.InpatientNO].Tag, feeItemList, operTime, true) == -1)
                        {
                            feeIntergrate.Rollback();
                            MessageBox.Show(Language.Msg(feeItemList.Item.Name + " 对应科室 ") + this.pharmacyIntergrate.Err);
                            this.fpDetail.Focus();
                            this.fpDetail_Sheet.SetActiveCell(i, (int)Columns.ItemName, false);

                            return -1;
                        }
                    }
                }
                //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
                object obj = this.fpDetail_Sheet.Cells[i, (int)Columns.ItemName].Tag;
                if (obj != null && NConvert.ToBoolean(obj))
                {
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    //string feeGroupId = this.fpDetail_Sheet.Cells[i, (int)Columns.Unit].Tag.ToString();
                    //if (inpatientManager.UpdateFeeGroupFeeDate(feeGroupId, operTime) <= 0)
                    //{
                    //    feeIntergrate.Rollback();
                    //    MessageBox.Show("更新患者费用组套收费时间失败！" + inpatientManager.Err);
                    //    return -1;
                    //}
                }

                #region addby xuewj 2010-9-21 {6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单
                if (this.isPrintFeeSheet)
                {
                    if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                    {
                        if (feeItemList.RecipeNO != "" && !paramRecipeNo.Contains(feeItemList.RecipeNO))
                        {
                            paramRecipeNo = "'" + feeItemList.RecipeNO + "'," + paramRecipeNo;
                        }
                    }
                }
                #endregion

                #region addby xuewj 2010-10-8 打印药品记账单 {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
                if (this.isPrintDrugFeeSheet)
                {
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        if (feeItemList.RecipeNO != "" && !paramDrugRecipeNo.Contains(feeItemList.RecipeNO))
                        {
                            paramDrugRecipeNo = "'" + feeItemList.RecipeNO + "'," + paramDrugRecipeNo;
                        }
                    }
                } 
                #endregion
            }

            //{9A2D3D3B-954B-44e1-B198-18CE2E2A36D7} lvxl 2010-3-4
            string strPatientNO = "";
            for (int ii1 = 0; ii1 < firstInputFeeItemlist.Count; ii1++)
            {
                FeeItemList fil = (FeeItemList)firstInputFeeItemlist[ii1];
                if (!strPatientNO.Contains(fil.ExtFlag2))
                {
                    strPatientNO += fil.ExtFlag2 + "|";
                }
            }
            if (strPatientNO.Length > 0)
            {
                strPatientNO = strPatientNO.Substring(0, strPatientNO.Length - 1);
            }
            string[] alPatientNO = strPatientNO.Split('|');
            ArrayList AlFirstInputFeeItemlist = new ArrayList();
            ArrayList ListFeeItemCollection = new ArrayList();
            ArrayList AlFirstInputFeeItemlistDetail;
            ArrayList ListFeeItemCollectionDetail;
            for (int ii2 = 0; ii2 < alPatientNO.Length; ii2++)
            {
                AlFirstInputFeeItemlistDetail = new ArrayList();
                ListFeeItemCollectionDetail = new ArrayList();
                for (int ii3 = 0; ii3 < firstInputFeeItemlist.Count; ii3++)
                {
                    if (((FeeItemList)firstInputFeeItemlist[ii3]).ExtFlag2 == alPatientNO[ii2].ToString())
                    {
                        AlFirstInputFeeItemlistDetail.Add(firstInputFeeItemlist[ii3]);
                        ListFeeItemCollectionDetail.Add(firstInputFeeItemlist[ii3]);
                    }
                }
                if (AlFirstInputFeeItemlistDetail.Count > 0)
                {
                    AlFirstInputFeeItemlist.Add(AlFirstInputFeeItemlistDetail);
                }
                if (ListFeeItemCollectionDetail.Count > 0)
                {
                    ListFeeItemCollection.Add(ListFeeItemCollectionDetail);
                }
            }

            for (int ii4 = 0; ii4 < AlFirstInputFeeItemlist.Count; ii4++)
            {
                //FeeItemList fItemList = (FeeItemList)((ArrayList)AlFirstInputFeeItemlistDetail[ii4])[0];
                ArrayList firstInputFeeItemlistTemp = (ArrayList)AlFirstInputFeeItemlist[ii4];
                this.patientInfo = this.radtIntegrate.GetPatientInfomation(((FeeItemList)firstInputFeeItemlistTemp[0]).ExtFlag2);
                //fItemList.ExtFlag2; --------------------------------------------
                //{9A2D3D3B-954B-44e1-B198-18CE2E2A36D7}lvxl

                //{F4912030-EF65-4099-880A-8A1792A3B449} 如果拆分界面上不拆分复合项目，这里拆分
                if (!this.isSplitUndrugCombItem)
                {

                    SplitUndrugCombItem(ref firstInputFeeItemlistTemp);
                }
                ////{F4912030-EF65-4099-880A-8A1792A3B449}结束



                //调用整体收费函数,收取第一次录入的费用
                //if (this.feeIntergrate.FeeItem(this.patientInfo, ref firstInputFeeItemlist) == -1)
                if (this.feeIntergrate.FeeItem(this.patientInfo, ref firstInputFeeItemlistTemp) == -1)
                {
                    feeIntergrate.Rollback();
                    MessageBox.Show(this.feeIntergrate.Err);
                    this.feeIntergrate.MedcareInterfaceProxy.Disconnect();
                    this.fpDetail.Focus();

                    return -1;
                }
                //对第一次收费的项目插入药品申请信息
                //foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in firstInputFeeItemlist)
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in firstInputFeeItemlistTemp)
                {
                    //药品加入申请表
                    //if (feeItemList.Item.IsPharmacy)
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        feeItemList.StockOper.Dept.ID = feeItemList.ExecOper.Dept.ID;

                        if (this.pharmacyIntergrate.ApplyOut(this.patientInfo, feeItemList, operTime, true) == -1)
                        {
                            feeIntergrate.Rollback();
                            MessageBox.Show(Language.Msg(feeItemList.Item.Name + " 对应科室 ") + this.pharmacyIntergrate.Err);
                            this.fpDetail.Focus();

                            return -1;
                        }
                    }

                    #region addby xuewj 2010-9-21 {6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单
                    if (this.isPrintFeeSheet)
                    {
                        if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                        {
                            if (feeItemList.RecipeNO != "" && !paramRecipeNo.Contains(feeItemList.RecipeNO))
                            {
                                paramRecipeNo = "'" + feeItemList.RecipeNO + "'," + paramRecipeNo;
                            }
                        }
                    }
                    #endregion

                    #region addby xuewj 2010-10-8 打印药品记账单 {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
                    if (this.isPrintDrugFeeSheet)
                    {
                        if (feeItemList.Item.ItemType == EnumItemType.Drug)
                        {
                            if (feeItemList.RecipeNO != "" && !paramDrugRecipeNo.Contains(feeItemList.RecipeNO))
                            {
                                paramDrugRecipeNo = "'" + feeItemList.RecipeNO + "'," + paramDrugRecipeNo;
                            }
                        }
                    } 
                    #endregion
                }
                //{4FF03BBF-763D-4063-A792-A2264999E79A}
                if (IAdptIllnessInPatient != null)
                {
                    //ArrayList feeList = new ArrayList(feeItemCollection);
                    ArrayList feeList = (ArrayList)ListFeeItemCollection[ii4];
                    int resultValue = IAdptIllnessInPatient.SaveInpatientFeeDetail(this.patientInfo, ref feeList);

                    if (resultValue < 0)
                    {
                        feeIntergrate.Rollback();
                        return -1;
                    }
                }
            }
            this.feeIntergrate.MedcareInterfaceProxy.CloseAll();
            this.feeIntergrate.Commit();

            this.sucessMsg = "收费成功!";

            #region {6C307A55-948E-475a-A015-8732DDE9D19A} 批费调用病区记账单
            if (this.isPrintFeeSheet || this.isPrintDrugFeeSheet)
            {
                if (paramRecipeNo != "" || paramDrugRecipeNo != "")
                {
                    DialogResult dr = MessageBox.Show("是否打印记账单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //paramRecipeNo = paramRecipeNo.Substring(0, paramRecipeNo.Length - 1);//去掉后面的逗号

                        if (this.isPrintFeeSheet && paramRecipeNo != "")
                        {
                            paramRecipeNo = paramRecipeNo.Substring(0, paramRecipeNo.Length - 1);//去掉后面的逗号
                            if (this.nurseFeeBill == null)
                            {
                                this.nurseFeeBill = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet)) as Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet;
                            }
                            if (this.nurseFeeBill != null)
                            {
                                DateTime beginDate = operTime;
                                DateTime endDate = this.inpatientManager.GetDateTimeFromSysDateTime();
                                this.nurseFeeBill.NurseFeeBill(beginDate, endDate, paramRecipeNo);
                            }
                        }
                        #region addby xuewj 2010-10-8 打印药品记账单 {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
                        if (this.isPrintDrugFeeSheet && paramDrugRecipeNo != "")
                        {
                            paramDrugRecipeNo = paramDrugRecipeNo.Substring(0, paramDrugRecipeNo.Length - 1);//去掉后面的逗号
                            if (this.nurseDrugFeeBill == null)
                            {
                                this.nurseDrugFeeBill = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IDrugFeeSheet)) as Neusoft.HISFC.BizProcess.Interface.Order.IDrugFeeSheet;
                            }
                            if (this.nurseDrugFeeBill != null)
                            {
                                DateTime beginDate = operTime;
                                DateTime endDate = this.inpatientManager.GetDateTimeFromSysDateTime();
                                this.nurseDrugFeeBill.NurseFeeBill(beginDate, endDate, paramDrugRecipeNo);
                            }
                        } 
                        #endregion
                    }
                }
            }
            #endregion 

            return 1;
        }

        
        /// <summary>
        /// 拆分复合项目//{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        /// <param name="itemList">当前项目列表</param>
        /// <returns>成功 1 失败 -1</returns>
        private int SplitUndrugCombItem(ref ArrayList itemList) 
        {
            ArrayList undrugCombItemList = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in itemList) 
            {
                if (f.Item.ItemType == EnumItemType.UnDrug && f.Item.User01 == "[复合项]") 
                {
                    undrugCombItemList.Add(f);
                }
            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in undrugCombItemList) 
            {
                itemList.Remove(f);
            }

            ArrayList finalCombItemList = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in undrugCombItemList)
            {
                ArrayList details = this.undrugPackageManager.QueryUndrugPackagesBypackageCode(f.Item.ID);
                if (details == null)
                {
                    MessageBox.Show(Language.Msg("获得组套信息出错!") + this.undrugPackageManager.Err);

                    return -1;
                }

                string orderID = this.orderIntegrate.GetNewOrderID();

                for (int i = 0; i < details.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb = details[i] as Neusoft.HISFC.Models.Fee.Item.UndrugComb;

                    //特殊组合项目不处理
                    //路志鹏 是否可用1是true可用， 0是false不可用 luzhp@neusoft.com
                    if (undrugComb.User01 == "0")
                    {
                        continue;
                    }

                    Neusoft.HISFC.Models.Fee.Item.Undrug undrug = this.itemManager.GetValidItemByUndrugCode(undrugComb.ID);
                    if (undrug == null)
                    {
                        continue;
                    }
                    undrug.ItemType = EnumItemType.UnDrug;
                    if (undrugComb.Qty == 0)
                    {
                        undrug.Qty = 1 * f.Item.Qty;
                    }
                    else
                    {
                        undrug.Qty = undrugComb.Qty * f.Item.Qty;
                    }

                    undrug.User03 = "1";
                    undrug.MinFee.User01 = f.Item.ID;
                    undrug.MinFee.User02 = f.Item.Name;
                    

                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList fComb = new FeeItemList();
                    fComb = f.Clone();
                    fComb.NoBackQty = undrug.Qty;
                    fComb.Item = undrug;
                    fComb.UndrugComb.ID = undrug.MinFee.User01;
                    fComb.UndrugComb.Name = undrug.MinFee.User02;

                    fComb.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fComb.Item.Price * fComb.Item.Qty, 2);
                    fComb.FT.OwnCost = fComb.FT.TotCost;
                    fComb.Order.ID = orderID;

                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    if (isLongFee)
                    {
                        fComb.ExtCode = "1";
                    }
                    else
                    {
                        fComb.ExtCode = "0";
                    }
                    //手工批费//{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    fComb.Item.SpecialFlag2 = "0";

                    finalCombItemList.Add(fComb);
                }
            }

            itemList.AddRange(finalCombItemList);

            return 1;
        }//{F4912030-EF65-4099-880A-8A1792A3B449}结束


        /// <summary>
        /// 显示汇总金额
        /// </summary>
        protected virtual void Sum()
        {
            int count = this.fpDetail_Sheet.RowCount;

            if (count > 1)
            {
                count = count - 1;
                this.fpDetail_Sheet.Cells[count, (int)Columns.TotCost].Formula = "sum(H1:H" + count.ToString() + ")";
            }
            else if (count > 0)
            {
                this.fpDetail_Sheet.SetValue(count - 1, (int)Columns.TotCost, 0, false);
            }
        }
        
        /// <summary>
        /// 初始化项目显示列表(FarPoint)
        /// </summary>
        protected virtual void InitFP()
        {
            InputMap im;
            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);

            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.fpDetail_Sheet.Columns[(int)Columns.ItemObject].Visible = false;
            this.fpDetail_Sheet.Columns[(int)Columns.IsNew].Visible = false;
            this.fpDetail_Sheet.Columns[(int)Columns.IsDeptChange].Visible = false;
            this.fpDetail_Sheet.Columns[(int)Columns.IsDrug].Visible = false;
        }
        
        /// <summary>
        /// 初始化科室列表
        /// </summary>
        private int InitDept()
        {
            #region {0C800C42-1BF7-46e1-9216-8DECD3D12EDD}

            ArrayList deptAll = this.departmentManager.GetDeptmentAll();
            ArrayList deptNurse = this.departmentManager.GetDeptment(EnumDepartmentType.N);

            ArrayList deptLists = new ArrayList();

            ArrayList strNurse = new ArrayList();
            for (int j = 0; j < deptNurse.Count; j++)
            {
                Neusoft.FrameWork.Models.NeuObject objNurse = deptNurse[j] as Neusoft.FrameWork.Models.NeuObject;
                strNurse.Add(objNurse.ID);
            }

            for (int i = 0; i < deptAll.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject objAll = deptAll[i] as Neusoft.FrameWork.Models.NeuObject;
                if (!strNurse.Contains(objAll.ID))
                {
                    deptLists.Add(objAll);
                }
            }

            #endregion
            

            if (deptLists == null) 
            {
                MessageBox.Show(Language.Msg("加载科室列表出错!") + this.departmentManager.Err);
                
                return -1;
            }
            this.lbDept.AddItems(deptLists);

            this.Controls.Add(this.lbDept);
            this.lbDept.Hide();
           
            this.lbDept.BorderStyle = BorderStyle.FixedSingle;
            this.lbDept.BringToFront();

            this.lbDept.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbDept_SelectItem);
           
            return 1;
        }

        /// <summary>
        /// 科室选择事件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int lbDept_SelectItem(Keys key)
        {
            ProcessDept();
            this.fpDetail.Focus();
            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Dept, true);

            return 1;
        }

        /// <summary>
        /// 处理this.fpDetail,执行科室的回车
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessDept()
        {
            int currRow = this.fpDetail_Sheet.ActiveRowIndex;
            
            if (currRow < 0)
            {
                return 1;
            }
            
            if (this.fpDetail_Sheet.GetText(currRow, (int)Columns.Unit) == "小计")
            {
                return 1;
            }

            string IsDeptChange = this.fpDetail_Sheet.GetText(currRow, (int)Columns.IsDeptChange);

            if ((IsDeptChange == "0" || IsDeptChange == string.Empty) && this.fpDetail_Sheet.GetText(currRow,(int)Columns.Dept) == string.Empty)
            {
                MessageBox.Show(Language.Msg("执行科室不能为空,请输入!"));
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(currRow, (int)Columns.Dept, true);

                return -1;
            }

            if (IsDeptChange == "1")
            {
                Neusoft.FrameWork.Models.NeuObject item = null;

                int returnValue = this.lbDept.GetSelectedItem(out item);
                if (returnValue == -1 || item == null)
                {
                    return -1;
                }

                object obj = this.fpDetail_Sheet.GetValue(currRow, (int)Columns.ItemObject);
                if (obj == null)
                {
                    MessageBox.Show(Language.Msg("请选择项目!"));
                    this.fpDetail.Focus();
                    this.fpDetail_Sheet.SetActiveCell(currRow, (int)Columns.Dept, true);

                    return -1;
                }
                this.fpDetail.StopCellEditing();
                this.fpDetail_Sheet.SetValue(currRow, (int)Columns.Dept, item.Name);

                FeeItemList feeitemlist = (FeeItemList)obj;
                feeitemlist.ExecOper.Dept.ID = item.ID;
                feeitemlist.ExecOper.Dept.Name = item.Name;

                this.fpDetail_Sheet.SetValue(currRow, (int)Columns.ItemObject, feeitemlist);
                this.fpDetail_Sheet.SetValue(currRow, (int)Columns.IsDeptChange, "0");
            }

            this.lbDept.Visible = false;

            return 1;
        }

        /// <summary>
        /// 设置ucItem/cmbdept的显示位置
        /// </summary>
        /// <returns></returns>
        private int SetLocation()
        {
            Control cell = this.fpDetail.EditingControl;
            if (cell == null)
            {
                return -1;
            }

            if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.ItemName)
            {
                int y = cell.Top + cell.Height + this.ucItemList.Height + 7;
                if (y <= this.Height)
                {
                    this.ucItemList.Location = new Point(cell.Left + 20, y - this.ucItemList.Height);
                }
                else
                {
                    this.ucItemList.Location = new Point(cell.Left + 20, cell.Top - this.ucItemList.Height - 7);
                }
            }
            else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Dept)
            {
                this.lbDept.Size = new Size(cell.Width + SystemInformation.Border3DSize.Width * 2, 150);

                int y = cell.Top + cell.Height + this.lbDept.Height + SystemInformation.Border3DSize.Height * 2;

                if (y <= this.Height)
                {
                    this.lbDept.Location = new Point(cell.Left, y - this.lbDept.Height);
                }
                else
                {
                    this.lbDept.Location = new Point(cell.Left, cell.Top - this.lbDept.Height);
                }
            }

            return 0;
        }		

        /// <summary>
        /// 判断输入的Cell是否合法
        /// </summary>
        /// <param name="itemName">项目名称</param>
        /// <param name="row">当前行</param>
        /// <param name="col">当前列</param>
        /// <param name="isNumber">是否数字列</param>
        /// <param name="errText">错误信息</param>
        /// <returns>合法 true 不合法 false</returns>
        private bool IsInputValid(string itemName, int row, Columns col, bool isNumber, string errText)
        {
            string tempValue = this.fpDetail_Sheet.GetText(row, (int)col);
            if (tempValue == string.Empty)
            {
                if (isNumber)
                {
                    tempValue = "0";
                }
            }

            if (isNumber)
            {
                decimal tempNumber = NConvert.ToDecimal(tempValue);
                if (tempNumber <= 0)
                {
                    MessageBox.Show(itemName + Language.Msg(errText));
                    this.fpDetail.Focus();
                    this.fpDetail_Sheet.SetActiveCell(row, (int)col);

                    return false;
                }
            }
            else
            {
                MessageBox.Show(itemName + Language.Msg(errText));
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)col);

                return false;
            }

            return true;
        }

        /// <summary>
        /// 根据项目列表中的项目获取该项目的默认执行科室
        /// </summary>
        /// <param name="item">项目实体</param>
        /// <param name="deptID">科室编码</param>
        /// <param name="deptName">科室名称</param>
        /// <returns></returns>
        private int GetItemDept(Neusoft.HISFC.Models.Base.Item item, ref string deptCode, ref string deptName)
        {
            if (item is Neusoft.HISFC.Models.Fee.Item.Undrug)
            {
                //获得非药品默认的执行科室
                deptCode = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).ExecDept;
                if (deptCode == null || deptCode == string.Empty)
                {
                    if (this.defaultExeDept != null && this.defaultExeDept != string.Empty)
                    {
                        deptCode = this.defaultExeDept;
                        Neusoft.HISFC.Models.Base.Department dept = this.departmentManager.GetDeptmentById(this.defaultExeDept);
                        if (dept == null)
                        {
                            deptName = "(无)";
                        }
                        else
                        {
                            deptName = dept.Name;
                        }
                    }
                    else
                    {
                        if (this.patientInfo != null)
                        {
                            deptName = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                            deptCode = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                        }
                    }
                }
                else
                {
                    //拆分科室串，多个科室的话，默认取第一个
                    int index = deptCode.IndexOf("|");
                    if (index < 0)
                    {
                        index = deptCode.Length;
                    }
                    deptCode = deptCode.Substring(0, index);

                    Neusoft.HISFC.Models.Base.Department dept = this.departmentManager.GetDeptmentById(deptCode);
                    if (dept == null)
                    {
                        deptName = "(无)";
                    }
                    else
                    {
                        deptName = dept.Name;
                    }
                }
            }
            else if (item is Neusoft.HISFC.Models.Pharmacy.Item)
            {
                //获得药品的执行科室
                if (this.defaultExeDept != null && this.defaultExeDept != string.Empty)
                {
                    deptCode = this.defaultExeDept;
                    Neusoft.HISFC.Models.Base.Department dept = this.departmentManager.GetDeptmentById(this.defaultExeDept);
                    if (dept == null)
                    {
                        deptName = "(无)";
                    }
                    else
                    {
                        deptName = dept.Name;
                    }
                }
                else
                {
                    if (this.patientInfo != null)
                    {
                        deptName = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                        deptCode = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                    }
                }
            }
            else if (item is Neusoft.HISFC.Models.FeeStuff.MaterialItem)
            {
                if (tempDept != null)
                {
                    deptName = tempDept.Name;
                    deptCode = tempDept.ID;
                }
                else if (this.patientInfo != null)
                {
                    deptName = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                    deptCode = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                }
                else
                {
                    deptName = this.operObj.Dept.Name;
                    deptCode = this.operObj.Dept.ID;
                }
            }
            return 0;
        }

        /// <summary>
        /// 处理this.fpDetail，项目名称的回车
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessItem()
        {
            if (this.ucItemList.Visible == false)
            {
                this.ucItemList.Visible = true;

                return 0;
            }
            try
            {
                Item item = new Item();
                int returnValue = this.ucItemList.GetSelectItem(out item);
               
                if (returnValue == -1 || returnValue == 0)
                {
                    
                    return -1;
                }

                int currRow = this.fpDetail_Sheet.ActiveRowIndex;
                if (currRow < 0)
                {
                    return -1;
                }
                if (this.fpDetail_Sheet.GetText(currRow, (int)Columns.IsNew) == "0")
                {
                    return -1;
                }
                if (item.User01 == "[组套]")
                {
                    //组套特殊处理 如果屏蔽掉 将不能调用组套  zhangjunyi@neusoft.com 修改
                    if (this.AddGroupDetail(item.ID, currRow) == -1)
                    {
                        return -1;
                    }
                }
                else if (item.User01 == "[复合项]")
                {
                    string deptid = string.Empty;
                    if (item.User02 != null && item.User02 != string.Empty)
                    {
                        //拆分复合项执行科室串，多个科室的话，默认取第一个
                        int index = item.User02.IndexOf("|");
                        if (index < 0) index = item.User02.Length;

                        deptid = item.User02.Substring(0, index);
                    }

                    //{F4912030-EF65-4099-880A-8A1792A3B449}
                    if (this.isSplitUndrugCombItem)
                    {
                        this.AddCompoundDetail(item.ID, item.Name, currRow, deptid);
                    }
                    else 
                    {
                        if (item.Price == 0 && !this.isChargeZero)
                        {
                            MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                            return -1;
                        }
                        item.Qty = 1;
                        item.User03 = "1";//默认所有项目的付数都为1
                        //添加划价明细
                        this.AddChargeDetail(item, currRow, string.Empty,false);
                    }
                    //{F4912030-EF65-4099-880A-8A1792A3B449}结束
                }
                else
                {
                    if (item.Price == 0 && !this.isChargeZero)
                    {
                        MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                        return -1;
                    }
                    item.Qty = 1;
                    item.User03 = "1";//默认所有项目的付数都为1
                    //添加划价明细
                    this.AddChargeDetail(item, currRow, string.Empty,false);
                }

                this.Sum();//显示汇总
                this.ucItemList.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.fpDetail.Focus();

                return -1;
            }

            return 0;
        }

        /// <summary>
        /// {A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessItem(Item item)
        {



            int currRow = this.fpDetail_Sheet.ActiveRowIndex;
            if (currRow < 0)
            {
                return -1;
            }
            if (this.fpDetail_Sheet.GetText(currRow, (int)Columns.IsNew) == "0")
            {
                return -1;
            }
            if (item.User01 == "[组套]")
            {
                //组套特殊处理 如果屏蔽掉 将不能调用组套  zhangjunyi@neusoft.com 修改
                if (this.AddGroupDetail(item.ID, currRow) == -1)
                {
                    return -1;
                }
            }
            else if (item.User01 == "[复合项]")
            {
                string deptid = string.Empty;
                if (item.User02 != null && item.User02 != string.Empty)
                {
                    //拆分复合项执行科室串，多个科室的话，默认取第一个
                    int index = item.User02.IndexOf("|");
                    if (index < 0) index = item.User02.Length;

                    deptid = item.User02.Substring(0, index);
                }

                //{F4912030-EF65-4099-880A-8A1792A3B449}
                if (this.isSplitUndrugCombItem)
                {
                    this.AddCompoundDetail(item.ID, item.Name, currRow, deptid);
                }
                else
                {
                    if (item.Price == 0 && !this.isChargeZero)
                    {
                        MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                        return -1;
                    }
                    item.Qty = 1;
                    item.User03 = "1";//默认所有项目的付数都为1
                    //添加划价明细
                    this.AddChargeDetailAddRow(item, currRow, string.Empty, false);
                }
                //{F4912030-EF65-4099-880A-8A1792A3B449}结束
            }
            else
            {
                if (item.Price == 0 && !this.isChargeZero)
                {
                    MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                    return -1;
                }
                item.Qty = 1;
                item.User03 = "1";//默认所有项目的付数都为1
                //添加划价明细
                this.AddChargeDetailAddRow(item, currRow, string.Empty, false);
            }

            this.Sum();//显示汇总

            this.fpDetail.Focus();



            return 0;
        }

        //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        /// <summary>
        /// 处理this.fpDetail，项目名称的回车
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessItem(FeeGroup feeGroup,int currRow)
        {
            try
            {
                Item item = new Item();
                int returnValue = this.ucItemList.GetSelectItem(feeGroup.Item.ID,feeGroup.DrugFlag, out item);

                if (returnValue == -1 || returnValue == 0)
                {

                    return -1;
                }

                if (item.User01 == "[组套]")
                {
                    //组套特殊处理 如果屏蔽掉 将不能调用组套  zhangjunyi@neusoft.com 修改
                    if (this.AddGroupDetail(item.ID, currRow) == -1)
                    {
                        return -1;
                    }
                }
                else if (item.User01 == "[复合项]")
                {
                    string deptid = string.Empty;
                    if (item.User02 != null && item.User02 != string.Empty)
                    {
                        //拆分复合项执行科室串，多个科室的话，默认取第一个
                        int index = item.User02.IndexOf("|");
                        if (index < 0) index = item.User02.Length;

                        deptid = item.User02.Substring(0, index);
                    }

                    //{F4912030-EF65-4099-880A-8A1792A3B449}
                    if (this.isSplitUndrugCombItem)
                    {
                        this.AddCompoundDetail(item.ID, item.Name, currRow, deptid);
                    }
                    else
                    {
                        if (item.Price == 0 && !this.isChargeZero)
                        {
                            MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                            return -1;
                        }
                        //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
                        item.Qty = feeGroup.Item.Qty;
                        item.User03 = feeGroup.Days == 0 ? "1" : feeGroup.Days.ToString();//默认所有项目的付数都为1
                        item.PriceUnit = feeGroup.Item.PriceUnit;//单位
                        item.MinFee.Memo = feeGroup.ID;//费用组套编号
                        item.MinFee.User03 = feeGroup.FeeDate.ToString();//收费日期
                        item.SysClass.User01 = feeGroup.ID;//费用组套编码
                        //添加划价明细
                        this.AddChargeDetail(item, currRow, string.Empty,true);
                    }
                    //{F4912030-EF65-4099-880A-8A1792A3B449}结束
                }
                else
                {
                    if (item.Price == 0 && !this.isChargeZero)
                    {
                        MessageBox.Show(Language.Msg("价格为0的项目") + "[" + item.Name + "]" + Language.Msg("不允许收费!"));

                        return -1;
                    }
                    //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
                    item.Qty = feeGroup.Item.Qty;
                    item.User03 = feeGroup.Days == 0 ? "1" : feeGroup.Days.ToString() ;//默认所有项目的付数都为1
                    item.PriceUnit = feeGroup.Item.PriceUnit;
                    item.MinFee.Memo = feeGroup.ID;//费用组套编号
                    item.MinFee.User03 = feeGroup.FeeDate.ToString();//收费日期
                    item.SysClass.User01 = feeGroup.ID;//费用组套编码
                    //添加划价明细
                    this.AddChargeDetail(item, currRow, string.Empty,true);
                }

                this.Sum();//显示汇总
                this.ucItemList.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.fpDetail.Focus();

                return -1;
            }

            return 0;
        }

        //处理this.fpDetail,价格、数量、草药付数的回车
        private int SetItemProperty()
        {
            int row = this.fpDetail_Sheet.ActiveRowIndex;
            if (row < 0)
            {
                return -1;
            }

            this.fpDetail.StopCellEditing();

            object obj = new object();
            obj = this.fpDetail_Sheet.GetValue(row, (int)Columns.ItemObject);
            if (obj == null)
            {
                return -1;
            }
            
            //价格
            string text = this.fpDetail_Sheet.GetText(row, (int)Columns.Price);
            if (text == null || text == string.Empty)
            {
                text = "0";
            }
            decimal price = NConvert.ToDecimal(text);
            
            //数量
            text = this.fpDetail_Sheet.GetText(row, (int)Columns.Qty);
            if (text == null || text == string.Empty)
            {
                text = "0";
            }
            decimal qty = NConvert.ToDecimal(text);
            
            //付数
            text = this.fpDetail_Sheet.GetText(row, (int)Columns.Day);
            if (text == null || text == string.Empty)
            {
                text = "0";
            }

            decimal day = NConvert.ToDecimal(text);

            //与收费、退费等费用的计算方法保持一致{F98CC89C-BE9A-49ca-98E2-4C700A8F5E34}
            //this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, Neusoft.FrameWork.Public.String.FormatNumber(price * qty * day, 2), false);
            Item item = this.fpDetail_Sheet.Rows[row].Tag as Item;
            if (item.Price == 0)
            {
                item.Price = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Price));
            }
            if (item.ItemType == EnumItemType.Drug)//药品
            {
                if (item.SpecialFlag4 == "2")
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, Neusoft.FrameWork.Public.String.FormatNumber((item.Price * qty) * day, 2), false);
                }
                else
                {
                    this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, Neusoft.FrameWork.Public.String.FormatNumber((item.Price * qty / item.PackQty) * day, 2), false);
                }
            }
            else
            {
                this.fpDetail_Sheet.SetValue(row, (int)Columns.TotCost, Neusoft.FrameWork.Public.String.FormatNumber((item.Price * qty) * day, 2), false);
            }

            this.Sum();//计算合计

            if (price <= 0)
            {
                MessageBox.Show(Language.Msg("项目价格不能小于或者等于零!"));
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Price, true);

                return -1;
            }

            if (qty <= 0 && isJudgeQty)
            {
                MessageBox.Show(Language.Msg("开立数量不能小于或者等于零!"));
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Qty, true);

                return -1;
            }

            if (day <= 0)
            {
                MessageBox.Show(Language.Msg("草药付数不能小于或者等于零!"));
                this.fpDetail.Focus();
                this.fpDetail_Sheet.SetActiveCell(row, (int)Columns.Day, true);

                return -1;
            }

            return 0;
        }

        //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        private bool IsExitRepeatItem()
        {
            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                object obj = this.fpDetail_Sheet.GetValue(i, (int)Columns.ItemObject);
                if (obj == null)
                {
                    continue;
                }
                FeeItemList feeItemList = obj as FeeItemList;

                for (int j = i+1; j < this.fpDetail_Sheet.RowCount; j++)
                {
                    object objtemp = this.fpDetail_Sheet.GetValue(j, (int)Columns.ItemObject);
                    if (objtemp == null)
                    {
                        continue;
                    }
                    FeeItemList feeItemListTemp = obj as FeeItemList;

                    if (feeItemList.Item.ID == feeItemListTemp.Item.ID)
                    {
                        MessageBox.Show("存在重复项目：" + feeItemList.Item.Name);

                       
                        return true;
                        
                    }


                }


                
            }
            return false;
        }

        private int SetItem(int row, PayTypes payType, string recipeDeptCode, DateTime operTime, ref bool isNewItem, ref FeeItemList feeItemList)
        {
            object obj = this.fpDetail_Sheet.GetValue(row, (int)Columns.ItemObject);
            if (obj == null)
            {
                return 0;
            }

            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            if (isLongFee)
            {
                feeItemList.ExtCode = "1"; //借用长期收费
            }
            else
            {
                feeItemList.ExtCode = "0";
            }
            Neusoft.HISFC.Models.Base.Employee operObj = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Clone();
            feeItemList = (FeeItemList)obj;
            feeItemList.FeeOper.ID = operObj.ID;
            feeItemList.FeeOper.Dept.ID = operObj.Dept.ID;
            feeItemList.Item.SpecialFlag2 = "0";

            //{6036900E-24DA-4dce-A58B-1DE240B19F36} lvxl 2010-3-4
            feeItemList.ExtFlag2 = ((Neusoft.HISFC.Models.RADT.PatientInfo)this.fpDetail_Sheet.Cells[row,(int)Columns.InpatientNO].Tag).ID;
            //{6036900E-24DA-4dce-A58B-1DE240B19F36}
            if (this.isJudgeValid) 
            {
                //if (feeItemList.Item.IsPharmacy)
                if (feeItemList.Item.ItemType == EnumItemType.Drug)
                {
                    //Neusoft.HISFC.Models.Pharmacy.Item phItem = this.pharmacyIntergrate.GetItem(feeItemList.Item.ID);
                    //if (phItem == null)
                    //{
                    //    MessageBox.Show("获得药品基本信息失败!" + this.pharmacyIntergrate.Err);

                    //    return -1;
                    //}

                    //if (phItem.ValidState != "0")
                    //{
                    //    MessageBox.Show(phItem.Name + "已经停用!请重新选择有效的项目");

                    //    return -1;
                    //}
                }
                else if(feeItemList.Item.ItemType == EnumItemType.UnDrug)
                {
                    ArrayList undrugList = this.undrugManager.Query(feeItemList.Item.ID, "1");
                    if (undrugList == null)
                    {
                        MessageBox.Show("获得非药品基本信息失败!" + this.undrugManager.Err);

                        return -1;
                    }

                    if (undrugList.Count == 0) 
                    {
                        MessageBox.Show(feeItemList.Item.Name + "已经停用!请重新选择有效的项目");

                        return -1;
                    }
                }
            }

            feeItemList.Days = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Day));

            if (feeItemList.Days == 0) 
            {
                feeItemList.Days = 1;
            }
            //数量,药品转换为最小单位数量
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == EnumItemType.Drug)    
            {	//项目单位为最小单位,如果和界面上的单位相同,证明收费的单位为最小单位
                if (feeItemList.Item.PriceUnit == this.fpDetail_Sheet.GetText(row, (int)Columns.Unit))
                {
                    feeItemList.Item.Qty = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Qty));
                }
                else//否则为包装单位,转换为最小单位
                {
                    feeItemList.Item.Qty = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Qty)) * feeItemList.Item.PackQty;
                }
            }
            else
            {
                feeItemList.Item.Qty = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Qty));
            }
            //将数量乘以草药付数,保存总量
            feeItemList.Item.Qty = feeItemList.Item.Qty * feeItemList.Days;

            //价格,药品价格在数据库中是包装单位价格
            if (feeItemList.Item.Price == 0)
            {
                feeItemList.Item.Price = NConvert.ToDecimal(this.fpDetail_Sheet.GetText(row, (int)Columns.Price));
            }
            //计算总额
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
            {
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(
                    //与护士站、退费等费用的计算方法保持一致{F98CC89C-BE9A-49ca-98E2-4C700A8F5E34}
                    //feeItemList.Item.Price / feeItemList.Item.PackQty * feeItemList.Item.Qty, 2);
                    feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty, 2);
            }
            else
            {
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(
                    feeItemList.Item.Price * feeItemList.Item.Qty, 2);
            }

            feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
           

            if (this.fpDetail_Sheet.GetText(row, (int)Columns.IsNew) == "1")
            {
                feeItemList.TransType = TransTypes.Positive;
                feeItemList.Patient = this.patientInfo.Clone();
                feeItemList.RecipeOper.ID = this.recipeDoctCode;
                feeItemList.RecipeOper.Dept.ID = recipeDeptCode;
                feeItemList.PayType = PayTypes.Charged;
                feeItemList.ChargeOper.ID = this.inpatientManager.Operator.ID;
                feeItemList.ChargeOper.OperTime = operTime;
                feeItemList.BalanceNO = 0;
                feeItemList.BalanceState = "0";
                isNewItem = true;
                if (payType == PayTypes.Balanced)
                {
                    feeItemList.PayType = PayTypes.Balanced;
                    feeItemList.FeeOper.ID = this.inpatientManager.Operator.ID;
                    feeItemList.FeeOper.OperTime = operTime;
                    feeItemList.NoBackQty = feeItemList.Item.Qty;
                }
            }
            else
            {
                isNewItem = false;
            }

            return 1;
        }

        /// <summary>
        ///删除一行
        /// </summary>
        /// <param name="row">要删除的行号</param>
        private void RemoveRow(int row) 
        {
            this.fpDetail.EditChange -= new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpDetail_EditChange);

            for (int i = 0; i < this.fpDetail_Sheet.Columns.Count; i++)
            {
                this.fpDetail_Sheet.Cells[row, i].Tag = string.Empty;
                this.fpDetail_Sheet.Cells[row, i].Text = string.Empty;
            }

            this.fpDetail.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpDetail_EditChange);

            this.fpDetail_Sheet.Rows.Remove(row, 1);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 保存函数
        /// </summary>
        /// <returns></returns>
        public virtual int Save() 
        {
            int returnValue = 0;
            feeIntergrate.MessageType = this.MessageType;
            switch (this.feeType) 
            {
                case FeeTypes.划价:
                    returnValue = this.Charge();
                    break;
                case FeeTypes.收费:
                    returnValue = this.Fee();
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// 在指定行处添加一行
        /// </summary>
        /// <param name="row">添加行索引</param>
        public virtual void AddRow(int row)
        {
            this.fpDetail_Sheet.Rows.Add(row, 1);
            this.fpDetail_Sheet.ActiveRowIndex = row;

            this.fpDetail_Sheet.Rows[this.fpDetail_Sheet.ActiveRowIndex].Height = 23;
            this.fpDetail.Focus();

            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.ItemName);
            if (this.fpDetail_Sheet.RowCount > 1 && this.fpDetail_Sheet.GetValue(0, (int)Columns.ItemObject) != null)
            {
                this.rowCount = 1;
            }

            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                this.fpDetail_Sheet.Rows[i].Locked = false;
            }
            this.fpDetail_Sheet.Rows[this.fpDetail_Sheet.RowCount - 1].Locked = true;
        }

        /// <summary>
        /// 添加一行项目
        /// </summary>
        public virtual void AddRow()
        {
            this.AddRow(this.fpDetail_Sheet.RowCount - 1);
            this.fpDetail.Focus();

            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.ItemName);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns>成功1 失败 -1</returns>
        public virtual int Init(string deptCode)
        {
            this.InitFP();
            //this.ucItemList = new ucItemList(this.itemKind);
            this.ucItemList = new ucItemList();
            this.ucItemList.enuShowItemType = this.itemKind;
            this.Controls.Add(this.ucItemList);
            this.ucItemList.Init(deptCode);
            //this.ucItemList.AddGroup(deptCode);
            this.ucItemList.Hide();
            this.ucItemList.BringToFront();
            this.ucItemList.SelectItem += new ucItemList.MyDelegate(ucItemList_SelectItem);
            this.InitInterface();
            InitDept();
            

            return 1;
        }
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        private int InitInterface()
        {
            this.iShowFeeTree = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFeeTree)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFeeTree;

            if (this.iShowFeeTree != null)
            {
                iShowFeeTree.SelectItem += new EventHandler(iShowFeeTree_SelectItem);
                //this.iShowFeeTree.AlItems = this.ucItemList._alItems;
                //this.iShowFeeTree.ArryFeeGate = "'05','07'";
                if (this.arrFeeGate == string.Empty)
                {
                    this.arrFeeGate = "XXXXXXX";
                }
                this.iShowFeeTree.ArryFeeGate = this.arrFeeGate;
                this.iShowFeeTree.PatientDept = (this.pactUnitManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                if (this.itemKind == EnumShowItemType.DeptItem)
                {
                    this.iShowFeeTree.ItemType = "deptItem";
                }
               
                Control uc = this.iShowFeeTree as Control;
                uc.Dock = DockStyle.Fill;
                this.pnItemTree.Controls.Add(uc);
            }
            else
            {
                this.pnItemTree.Visible = false;
            }

            return 1;
        }
        //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
        void iShowFeeTree_SelectItem(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Base.Item item = sender as Neusoft.HISFC.Models.Base.Item;
            if (item == null)
            {
                return;
            }
            this.ProcessItem(item);
            //收费界面中间列表加入科室组套功能 {2188EE9F-E424-43fa-A74F-5495B6942B08} wbo 2011-1-18
            //通过组套方式增加光标定位不准确
            if (this.fpDetail_Sheet.RowCount >= 2)
            {
                object objTag = this.fpDetail_Sheet.Rows[this.fpDetail_Sheet.RowCount - 2].Tag;
                if ((Neusoft.HISFC.Models.Base.Item)objTag != null)
                {
                    this.fpDetail_Sheet.AddRows(this.fpDetail_Sheet.RowCount - 1, 1);
                    this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.RowCount - 2, 2);
                    this.fpDetail.Focus();
                }
            }
        }

        public void ChangeDept(FrameWork.Models.NeuObject deptObj)
        {
            
            if (deptObj == null)
            {
                MessageBox.Show("参数传递失败！");
                return;
            }
            if (tempDept != null && tempDept == deptObj) return;

            int resultValue = this.ucItemList.RefreshDataSet(deptObj.ID);
            if (resultValue < 0)
            {
                MessageBox.Show("查找物资信息失败！");
                return;
            }
            tempDept = deptObj;
            this.Focus();
        }
        
        /// <summary>
        /// 删除一行项目
        /// </summary>
        /// <returns>成功: 1 失败: -1</returns>
        public virtual int DelRow()
        {
            int row = this.fpDetail_Sheet.ActiveRowIndex;

            if (this.fpDetail_Sheet.RowCount == 0)
            {
                return 0;
            }
            if (row == this.fpDetail_Sheet.RowCount - 1)
            {
                return 0;
            }
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}

            if (this.IsLongFee)
            {
                Neusoft.HISFC.Models.Base.Item itemTemp = this.fpDetail_Sheet.Rows[row].Tag as Neusoft.HISFC.Models.Base.Item;

                if (itemTemp != null)
                {
                    if (!string.IsNullOrEmpty(itemTemp.MinFee.User03))
                    {
                        DateTime feeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(itemTemp.MinFee.User03);
                        DateTime now = this.inpatientManager.GetDateTimeFromSysDateTime().Date;
                        if (feeDate >= now && feeDate < now.AddDays(1))
                        {
                            MessageBox.Show("该费用已经记账，不能删除！");
                            return -1;
                        }
                    }
                }

            }

            row++;
            
            // 是否在点击删除按钮时提示“是否删除第*行”,True提示，False不提示，直接删除 {AE199B83-DC7A-423b-9CEE-9553BAF19DB6} wbo 2010-10-21
            if (this.isShowDelDiag == true)
            {
                DialogResult result = MessageBox.Show(Language.Msg("是否删除第") + row.ToString() + Language.Msg("行?"),
                    Language.Msg("提示"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    this.fpDetail.Focus();

                    return 1;
                }
            }
            row--;

            //获得该项目是否为新录入项目
            string newItem = this.fpDetail_Sheet.GetText(row, (int)Columns.IsNew);

            //新录入项目直接删除
            if (newItem == string.Empty || newItem == "1")
            {
                this.fpDetail.StopCellEditing();
                this.fpDetail_Sheet.Rows.Remove(row, 1);
                row = this.fpDetail_Sheet.ActiveRowIndex;
                this.fpDetail_Sheet.SetActiveCell(row, 0);
                
                if (this.fpDetail_Sheet.RowCount == 1) 
                {
                    this.AddRow(0);
                }
            }
            else//由数据库内检索的项目
            {
                object obj = this.fpDetail_Sheet.GetValue(row, (int)Columns.ItemObject);

                if (obj == null)
                {
                    return -1;
                }

                //需确认的医嘱，只删除界面明细，不处理数据库
                if (obj is Neusoft.HISFC.Models.Order.ExecOrder)
                {
                    this.fpDetail_Sheet.Rows.Remove(row, 1);
                }
                //收费项目处理
                //操作数据库，删除划价明细
                else if (obj is FeeItemList)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Transaction t = new Transaction(this.inpatientManager.Connection);
                    //t.BeginTransaction();
                    this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if (this.inpatientManager.DeleteChargeInfo((FeeItemList)obj) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("删除明细失败!") + this.inpatientManager.Err);
                        this.fpDetail.Focus();

                        return -1;
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    this.fpDetail_Sheet.Rows.Remove(row, 1);
                }
            }

            //重新计算合计
            this.Sum();

            //不让合计行得到焦点
            if (this.fpDetail_Sheet.RowCount >= 2 && this.fpDetail_Sheet.ActiveRowIndex == this.fpDetail_Sheet.RowCount - 1)
            {
                this.fpDetail_Sheet.ActiveRowIndex = this.fpDetail_Sheet.ActiveRowIndex - 1;
            }

            this.fpDetail.Focus();

            return 1;
        }

        /// <summary>
        /// 小计
        /// </summary>
        /// <returns>成功 1 失败 0</returns>
        public int SubTotal()
        {
            try
            {
                this.isSubTotal = true;//开始进行小计
                if (this.fpDetail_Sheet.RowCount < 2)
                {
                    return 0;
                }
                int curIndex = this.fpDetail_Sheet.ActiveRowIndex;
                if (this.fpDetail_Sheet.Cells[curIndex, 0].Text == string.Empty)
                {
                    if (this.fpDetail_Sheet.Cells[curIndex, (int)Columns.Unit].Text == "小计")
                    {
                        this.isSubTotal = false;
                        return 0;
                    }
                    this.fpDetail_Sheet.Cells[curIndex, (int)Columns.Unit].Text = "小计";
                }
                else
                {
                    if (this.fpDetail_Sheet.GetText(curIndex + 1, (int)Columns.Unit) == "小计")
                    {
                        this.isSubTotal = false;
                        return 0;
                    }
                    this.fpDetail_Sheet.Rows.Add(curIndex + 1, 1);
                    curIndex++;
                    this.fpDetail_Sheet.Cells[curIndex, (int)Columns.Unit].Text = "小计";
                }
            DOStart:
                decimal subTot = 0;
                for (int i = curIndex - 1; i >= 0; i--)
                {
                    if (this.fpDetail_Sheet.Cells[i, (int)Columns.Unit].Text != "小计")
                    {
                        subTot += NConvert.ToDecimal(this.fpDetail_Sheet.Cells[i, (int)Columns.TotCost].Text);
                    }
                    else
                    {
                        break;
                    }
                }
                if (subTot == 0)
                {
                    this.fpDetail_Sheet.Cells[curIndex, (int)Columns.Unit].Text = string.Empty;
                }
                else
                {
                    this.fpDetail_Sheet.Cells[curIndex, (int)Columns.TotCost].Text = subTot.ToString();
                }
                for (int i = curIndex + 1; i < this.fpDetail_Sheet.RowCount - 1; i++)
                {
                    if (this.fpDetail_Sheet.Cells[i, (int)Columns.Unit].Text == "小计")
                    {
                        curIndex = i;
                        goto DOStart;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //结束小计
            this.isSubTotal = false;

            return 1;
        }

        /// <summary>
        /// 清空患者和项目明细
        /// </summary>
        public virtual void Clear()
        {
            if (this.fpDetail_Sheet.RowCount >= 0)
            {
                this.fpDetail_Sheet.Rows.Remove(0, this.fpDetail_Sheet.RowCount);
            }

            this.AddRow(0);
            this.AddRow(0);

            this.fpDetail_Sheet.SetValue(1, (int)Columns.Unit, "合计", false);
            this.fpDetail_Sheet.Rows[1].Locked = true;

            this.Sum();//显示汇总

            this.rowCount = 0;
            this.patientInfo = null;
        }

        /// <summary>
        /// 获得选定的项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <param name="itemType">项目类别 1 药品 2 非药品 3 组合项目 4 所有项目</param>
        /// <returns>成功 承载FeeItemList的泛型List集合 失败: null;</returns>
        public List<FeeItemList> QueryFeeItemList(string recipeDoctCode, DateTime dtNow, string itemType) 
        {
            List<FeeItemList> list = new List<FeeItemList>();

            this.fpDetail.StopCellEditing();

            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++) 
            {
                bool isNewItem = false;

                FeeItemList feeItemList = new FeeItemList();

                int returnValue = this.SetItem(i, PayTypes.Balanced, recipeDoctCode, dtNow, ref isNewItem, ref feeItemList);
                
                //没有获得项目
                if(returnValue != 1)
                {
                    continue;
                }

                switch (itemType) 
                {
                    //药品
                    case "1":
                        //if (feeItemList.Item.IsPharmacy) 
                        if (feeItemList.Item.ItemType == EnumItemType.Drug) 
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //非药品:
                    case "2":
                        //if (!feeItemList.Item.IsPharmacy)
                        if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //组套
                    case "3":
                        if (feeItemList.IsGroup) 
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //所有
                    case "0":
                        list.Add(feeItemList);
                        break;
                }
            }

            return list;
        }

        /// <summary>
        /// 获得选定的项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <param name="itemType">项目类别 1 药品 2 非药品 3 组合项目 4 所有项目</param>
        /// <returns>成功 承载FeeItemList的ArrayList集合 失败: null;</returns>
        public ArrayList QueryFeeItemArrayList(string recipeDoctCode, DateTime dtNow, string itemType)
        {
            ArrayList list = new ArrayList();

            this.fpDetail.StopCellEditing();

            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                bool isNewItem = false;

                FeeItemList feeItemList = new FeeItemList();

                int returnValue = this.SetItem(i, PayTypes.Balanced, recipeDoctCode, dtNow, ref isNewItem, ref feeItemList);

                //没有获得项目
                if (returnValue != 1)
                {
                    continue;
                }

                switch (itemType)
                {
                    //药品
                    case "1":
                        //if (feeItemList.Item.IsPharmacy)
                        if(feeItemList.Item.ItemType == EnumItemType.Drug)
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //非药品:
                    case "2":
                        //if (!feeItemList.Item.IsPharmacy)
                        if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //组套
                    case "3":
                        if (feeItemList.IsGroup)
                        {
                            list.Add(feeItemList);
                        }
                        break;
                    //所有
                    case "0":
                        list.Add(feeItemList);
                        break;
                }
            }

            return list;
        }

        /// <summary>
        /// 获得药品项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <returns>成功 承载FeeItemList的泛型List集合 失败: null;</returns>
        public List<FeeItemList> QueryMedItemList(string recipeDoctCode, DateTime dtNow) 
        {
            return this.QueryFeeItemList(recipeDoctCode, dtNow, "1");
        }

        /// <summary>
        /// 获得药品项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <returns>成功 承载FeeItemList的ArrayList集合 失败: null;</returns>
        public ArrayList QueryMedItemArrayList(string recipeDoctCode, DateTime dtNow)
        {
            return this.QueryFeeItemArrayList(recipeDoctCode, dtNow, "1");
        }

        /// <summary>
        /// 获得药品项目信息
        /// </summary>
        /// <returns>成功 承载FeeItemList的泛型List集合 失败: null;</returns>
        public List<FeeItemList> QueryMedItemList() 
        {
            return this.QueryMedItemList(string.Empty, this.inpatientManager.GetDateTimeFromSysDateTime());
        }

        /// <summary>
        /// 获得药品项目信息
        /// </summary>
        /// <returns>成功 承载FeeItemList的ArrayList集合 失败: null;</returns>
        public ArrayList QueryMedItemArrayList()
        {
            return this.QueryMedItemArrayList(string.Empty, this.inpatientManager.GetDateTimeFromSysDateTime());
        }

        /// <summary>
        /// 获得非药品项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <returns>成功 承载FeeItemList的泛型List集合 失败: null;</returns>
        public List<FeeItemList> QueryUndrugItemList(string recipeDoctCode, DateTime dtNow)
        {
            return this.QueryFeeItemList(recipeDoctCode, dtNow, "2");
        }

        /// <summary>
        /// 获得非药品项目信息
        /// </summary>
        /// <param name="recipeDoctCode">开立医生所在科室</param>
        /// <param name="dtNow">执行时间</param>
        /// <returns>成功 承载FeeItemList的ArrayList集合 失败: null</returns>
        public ArrayList QueryUndrugItemArrayList(string recipeDoctCode, DateTime dtNow)
        {
            return this.QueryFeeItemArrayList(recipeDoctCode, dtNow, "2");
        }

        /// <summary>
        /// 获得非药品项目信息
        /// </summary>
        /// <returns>成功 承载FeeItemList的泛型List集合 失败: null;</returns>
        public List<FeeItemList> QueryUndrugItemList()
        {
            return this.QueryUndrugItemList(string.Empty, this.inpatientManager.GetDateTimeFromSysDateTime());
        }

        /// <summary>
        /// 获得非药品项目信息
        /// </summary>
        /// <returns>成功 承载FeeItemList的ArrayList集合 失败: null</returns>
        public ArrayList QueryUndrugItemArrayList()
        {
            return this.QueryUndrugItemArrayList(string.Empty, this.inpatientManager.GetDateTimeFromSysDateTime());
        }

        #region 费用组套 {1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        /// <summary>
        /// 保存费用组套
        /// </summary>
        /// <returns></returns>
        public virtual int SaveFeeGroup()
        {
           
            //{1FAB2C49-A298-499d-A725-6729C09772EA}
            this.fpDetail.StopCellEditing();
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            if (patientInfo == null)
            {
                MessageBox.Show("没有患者信息!");
                return -1;
            }
            string inpatientNo = this.patientInfo.ID;
            string nurseCode = (inpatientManager.Operator as Employee).Dept.ID;
            ArrayList alFeeGroup = inpatientManager.QueryPatientFeeGroup(inpatientNo, nurseCode);

            foreach (FeeGroup feeGroup in alFeeGroup)
            {
              
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                if (!this.hsGroup.ContainsKey(feeGroup.ID))
                {
                    this.hsGroup.Add(feeGroup.ID, feeGroup.Clone());
                }
            }

            Employee employee = this.personManager.GetPersonByID(this.recipeDoctCode);

            if (employee == null)
            {
                MessageBox.Show(Language.Msg("获得人员基本信息出错!"));

                return -1;
            }
            this.fpDetail.Change -= new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            //if (!this.IsValid())
            int rowcounts = 0;
            if (!this.IsValidForZT(ref rowcounts))
            {
                this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
                return -1;
            }
          

            this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);

            //事务管理类
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            if (inpatientManager.DeleteFeeGroup(this.patientInfo.ID, (inpatientManager.Operator as Employee).Dept.ID) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除患者费用组套信息失败！" + inpatientManager.Err);
                return -1;
            }

            //没有记录只删除
            if (hsGroup.Count > 0 && rowcounts == 0)
            {
                 
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("存盘成功");
                return 1;


            }

            //操作时间
            DateTime operTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            Hashtable haFeeItemList = new Hashtable();
            //循环处理
            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                FeeItemList feeItemList = new FeeItemList();
                bool isNew = false;
                int returnValue = 0;

                //项目信息赋值
                returnValue = this.SetItem(i, PayTypes.Balanced, employee.Dept.ID, operTime, ref isNew, ref feeItemList);
                if (string.IsNullOrEmpty(feeItemList.Item.ID))
                {
                    continue;
                }
               

                //如果获得的项目信息为空,不处理
                if (returnValue == 0)
                {
                    continue;
                }

                if (returnValue == -1)
                {
                    this.feeIntergrate.Rollback();
                    return -1;
                }

                if (haFeeItemList.Contains(feeItemList.Item.ID))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("存在重复项目：" + feeItemList.Item.Name);
                    return -1;
                }
                else
                {
                    haFeeItemList.Add(feeItemList.Item.ID, feeItemList);
                }
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                Neusoft.HISFC.Models.Base.Item item = this.fpDetail_Sheet.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                FeeGroup feeGroup = this.FeeItemListChangeFeeGroup(feeItemList, operTime,i);
                //FeeGroup feeGroup = this.FeeItemListChangeFeeGroupForSave(feeItemList, operTime, i);

                if (feeGroup == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }

                if (inpatientManager.InsertFeeGroup(feeGroup) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存费用组套失败！" + inpatientManager.Err);
                    return -1;
                }
                //项目名称tag为是否收费组套项目标识
                this.fpDetail_Sheet.Cells[i, (int)Columns.ItemName].Tag = true;
                //单位tag为收费组套ID
                fpDetail_Sheet.Cells[i, (int)Columns.Unit].Tag = feeGroup.ID;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存费用组套成功！");
            return 1;
        }

        /// <summary>
        /// {D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        /// </summary>
        /// <returns></returns>
        public virtual int SaveFeeGroupNoTans()
        {

            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            string inpatientNo = this.patientInfo.ID;
            string nurseCode = (inpatientManager.Operator as Employee).Dept.ID;
            ArrayList alFeeGroup = inpatientManager.QueryPatientFeeGroup(inpatientNo, nurseCode);

            foreach (FeeGroup feeGroup in alFeeGroup)
            {

                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                if (!this.hsGroup.ContainsKey(feeGroup.ID))
                {
                    this.hsGroup.Add(feeGroup.ID, feeGroup.Clone());
                }
            }

            //{1FAB2C49-A298-499d-A725-6729C09772EA}
            this.fpDetail.StopCellEditing();
            Employee employee = this.personManager.GetPersonByID(this.recipeDoctCode);

            if (employee == null)
            {
                MessageBox.Show(Language.Msg("获得人员基本信息出错!"));

                return -1;
            }
            this.fpDetail.Change -= new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
          
            if (!this.IsValid())
            {
                this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
                return -1;
            }

            this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);

            //事务管理类
            //Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            if (inpatientManager.DeleteFeeGroup(this.patientInfo.ID, (inpatientManager.Operator as Employee).Dept.ID) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除患者费用组套信息失败！" + inpatientManager.Err);
                return -1;
            }
            
            //操作时间
            DateTime operTime = this.inpatientManager.GetDateTimeFromSysDateTime();
            //循环处理
            Hashtable haFeeItemList = new Hashtable();
            for (int i = 0; i < this.fpDetail_Sheet.RowCount; i++)
            {
                //string groupID = this.fpDetail_Sheet.Cells[i, (int)Columns.GroupID].Text;

                //if (!string.IsNullOrEmpty(groupID))
                //{

                //    DateTime fromdate = operTime.Date;// 当前起始时间
                //    //当前起始时间
                //    DateTime todate = Neusoft.FrameWork.Function.NConvert.ToDateTime(operTime.Date.ToShortDateString() + " 23:59:59");

                //    DateTime lastFeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpDetail_Sheet.Cells[i, (int)Columns.FeeDate].Text);

                //    // 如果上次收费时间小于当前时间，则说明有收费记录
                //    if (lastFeeDate > fromdate && lastFeeDate < todate)
                //    {
                //        //已经收过费
                //        continue;
                //    }
                //}

                FeeItemList feeItemList = new FeeItemList();
                bool isNew = false;
                int returnValue = 0;

                //项目信息赋值
                returnValue = this.SetItem(i, PayTypes.Balanced, employee.Dept.ID, operTime, ref isNew, ref feeItemList);

                //如果获得的项目信息为空,不处理
                if (returnValue == 0)
                {
                    continue;
                }

                if (returnValue == -1)
                {
                    this.feeIntergrate.Rollback();
                    return -1;
                }
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}

                if (haFeeItemList.Contains(feeItemList.Item.ID))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("存在重复项目：" + feeItemList.Item.Name);
                    return -1;
                }
                else
                {
                    haFeeItemList.Add(feeItemList.Item.ID, feeItemList);
                }

                FeeGroup feeGroup = this.FeeItemListChangeFeeGroupForSave(feeItemList, operTime,i);
                if (feeGroup == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                }
               
                

                if (inpatientManager.InsertFeeGroup(feeGroup) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存费用组套失败！" + inpatientManager.Err);
                    return -1;
                }
                //项目名称tag为是否收费组套项目标识
                this.fpDetail_Sheet.Cells[i, (int)Columns.ItemName].Tag = true;
                //单位tag为收费组套ID
                //fpDetail_Sheet.Cells[i, (int)Columns.Unit].Tag = feeGroup.ID;
            }
            //Neusoft.FrameWork.Management.PublicTrans.Commit();
           // MessageBox.Show("保存费用组套成功！");
            return 1;
        } 

        /// <summary>
        /// 将费用实体转化为费用组套实体//{D6A25CA7-331A-4034-BBC6-A6FF821E290C} 增加参数
        /// </summary>
        /// <param name="f"></param>
        /// <param name="operTime"></param>
        /// <returns></returns>
        private FeeGroup FeeItemListChangeFeeGroup(FeeItemList f,DateTime operTime,int row)
        {
            FeeGroup fg = new FeeGroup();
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}

            string groupID = this.fpDetail_Sheet.Cells[row,(int)Columns.GroupID].Text;

            if (groupID == null || string.IsNullOrEmpty(groupID))
            {
                fg.ID = inpatientManager.GetFeeGroupID();
                fg.Oper.OperTime = operTime;
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                fg.FeeDate = operTime.AddDays(-1);
                fg.Oper.ID = inpatientManager.Operator.ID;
            }
            else
            {
                if (this.hsGroup.ContainsKey(groupID))
                {
                    //int returnValue = this.inpatientManager.DeleteFeeGroup(groupID);
                    //if (returnValue < 0)
                    //{
                    //    MessageBox.Show("删除费用存盘信息出错");
                    //    return null;
                    //}

                    FeeGroup feeGroupFeeClone = this.hsGroup[groupID] as FeeGroup;

                    fg.ID = feeGroupFeeClone.ID;
                    fg.Oper.OperTime = feeGroupFeeClone.Oper.OperTime;
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    fg.FeeDate = feeGroupFeeClone.FeeDate;
                    fg.Oper.ID = feeGroupFeeClone.Oper.ID;


                   



                }
                else
                {
                    fg.ID = inpatientManager.GetFeeGroupID();
                    fg.Oper.OperTime = operTime;
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    fg.FeeDate = operTime.AddDays(-1);
                    fg.Oper.ID = inpatientManager.Operator.ID;
                }
                
            }
            
            fg.Patient = this.patientInfo;
            fg.NurseCell.ID = (this.inpatientManager.Operator as Employee).Dept.ID;
            fg.Item = f.Item;
            if (f.Item.ItemType == EnumItemType.Drug)
            {
                fg.DrugFlag = "1";
            }
            if (f.Item.ItemType == EnumItemType.UnDrug)
            {
                fg.DrugFlag = "2";
            }
            if (f.Item.ItemType == EnumItemType.MatItem)
            {
                fg.DrugFlag = "6";
            }
            fg.Package.ID = f.Item.MinFee.User01;
            fg.Package.Name = f.Item.MinFee.User02;
            fg.ExecDept = f.ExecOper.Dept;
            
           
            
            return fg;
        }

        /// <summary>
        /// 将费用实体转化为费用组套实体,saveGroup//{D6A25CA7-331A-4034-BBC6-A6FF821E290C} 增加参数
        /// </summary>
        /// <param name="f"></param>
        /// <param name="operTime"></param>
        /// <returns></returns>
        private FeeGroup FeeItemListChangeFeeGroupForSave(FeeItemList f, DateTime operTime, int row)
        {
            FeeGroup fg = new FeeGroup();
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}

            string groupID = this.fpDetail_Sheet.Cells[row, (int)Columns.GroupID].Text;

            if (groupID == null || string.IsNullOrEmpty(groupID))
            {
                fg.ID = inpatientManager.GetFeeGroupID();
                fg.Oper.OperTime = operTime;
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                fg.FeeDate = operTime;
            }
            else
            {
                if (this.hsGroup.ContainsKey(groupID))
                {
                    //int returnValue = this.inpatientManager.DeleteFeeGroup(groupID);
                    //if (returnValue < 0)
                    //{
                    //    MessageBox.Show("删除费用存盘信息出错");
                    //    return null;
                    //}

                    FeeGroup feeGroupFeeClone = this.hsGroup[groupID] as FeeGroup;


                    fg.ID = feeGroupFeeClone.ID;
                    fg.Oper.OperTime = feeGroupFeeClone.Oper.OperTime;
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    fg.FeeDate = operTime;

                    
                    DateTime fromdate = operTime.Date;// 当前起始时间
                    //当前起始时间
                    DateTime todate = Neusoft.FrameWork.Function.NConvert.ToDateTime(operTime.Date.ToShortDateString() + " 23:59:59");

                    DateTime lastFeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpDetail_Sheet.Cells[row, (int)Columns.FeeDate].Text);

                    // 如果上次收费时间小于当前时间，则说明有收费记录
                    if (lastFeeDate > fromdate && lastFeeDate < todate)
                    {
                        fg.FeeDate = feeGroupFeeClone.FeeDate;
                    }
                    else

                    {
                        fg.FeeDate = operTime;
                    }

                    

                }
                else
                {
                    fg.ID = inpatientManager.GetFeeGroupID();
                    fg.Oper.OperTime = operTime;
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    fg.FeeDate = operTime;
                }

            }

            fg.Patient = this.patientInfo;
            fg.NurseCell.ID = (this.inpatientManager.Operator as Employee).Dept.ID;
            fg.Item = f.Item;
            if (f.Item.ItemType == EnumItemType.Drug)
            {
                fg.DrugFlag = "1";
            }
            if (f.Item.ItemType == EnumItemType.UnDrug)
            {
                fg.DrugFlag = "2";
            }
            if (f.Item.ItemType == EnumItemType.MatItem)
            {
                fg.DrugFlag = "6";
            }
            fg.Package.ID = f.Item.MinFee.User01;
            fg.Package.Name = f.Item.MinFee.User02;
            fg.ExecDept = f.ExecOper.Dept;
            fg.Oper.ID = inpatientManager.Operator.ID;


            return fg;
        }

        /// <summary>
        /// 调入费用组套
        /// </summary>
        /// <returns></returns>
        public virtual int ExpFeeGroup()
        {
            
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            this.hsGroup = new Hashtable();
            if (this.patientInfo == null || string.IsNullOrEmpty(patientInfo.ID))
            {
                MessageBox.Show("请输入患者后再调入组套！");
                return -1;
            }
            string inpatientNo = this.patientInfo.ID;
            string nurseCode = (inpatientManager.Operator as Employee).Dept.ID;
            ArrayList alFeeGroup = inpatientManager.QueryPatientFeeGroup(inpatientNo, nurseCode);
            if (alFeeGroup == null)
            {
                MessageBox.Show("获取患者费用组套信息失败！");
                return -1;
            }

            if (alFeeGroup.Count == 0)
            {
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                //MessageBox.Show("该患者不存在收费组套！");
                return -1;
            }

            foreach (FeeGroup feeGroup in alFeeGroup)
            {
                if (this.fpDetail_Sheet.Rows[this.fpDetail_Sheet.Rows.Count - 2].Tag != null)
                {
                    this.AddRow();
                }
                if (ProcessItem(feeGroup, this.fpDetail_Sheet.RowCount - 2) < 0)
                {
                    return -1;
                }
                
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                //if (!this.hsGroup.ContainsKey(feeGroup.ID))
                //{
                //    this.hsGroup.Add(feeGroup.ID, feeGroup.Clone());
                //}
            }

            //for (int i = 0; i < fpDetail_Sheet.Rows.Count; i++)
            //{
            //    Neusoft.HISFC.Models.Base.Item item = fpDetail_Sheet.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;

            //    MessageBox.Show(fpDetail_Sheet.Cells[i,13].Text);
            //}
            return 1;

        }
        #endregion

        #region 郑大新增{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        public int QueryDayFeeByInpaientNO(string inpatientNO)
        {
            DateTime currentDate = this.inpatientManager.GetDateTimeFromSysDateTime();
            string fromdate = currentDate.Date.ToString();
            string todate = currentDate.Date.ToShortDateString() + " 23:59:59";
            DataSet ds = this.inpatientManager.QueryDayFeeByInpaientNO(this.patientInfo.ID, fromdate, todate,((this.inpatientManager.Operator) as Employee).Dept.ID,this.isLongFee);
            if (ds == null)
            {
                MessageBox.Show("查询当日费用出错!\n" + this.inpatientManager.Err);
                return -1;
            }
            this.neuSpread1_Sheet1.DataSource = ds;

            if (this.neuSpread1_Sheet1.RowCount == 0)
            {
                return -1;
            }

            this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 1].Text = "当日合计:";
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 5].Formula = string.Format("SUM(F1:F{0})", (this.neuSpread1_Sheet1.RowCount-1).ToString());
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 6].Formula = string.Format("SUM(G1:G{0})", (this.neuSpread1_Sheet1.RowCount - 1).ToString());
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 7].Formula = string.Format("SUM(H1:H{0})", (this.neuSpread1_Sheet1.RowCount - 1).ToString());
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 8].Formula = string.Format("SUM(I1:I{0})", (this.neuSpread1_Sheet1.RowCount - 1).ToString());

            
            return 1;
        }

        #endregion
        #endregion

        #region 事件

        /// <summary>
        /// 按键设置
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                #region enter、up、down事件
                case Keys.Enter:
                    if (this.fpDetail.ContainsFocus)
                    {
                        //项目名称
                        if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.ItemName)
                        {
                            this.ProcessItem();
                        }
                        //价格
                        else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Price)
                        {
                            if (this.SetItemProperty() == -1)
                            {
                                return true;
                            }
                            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Qty);
                        }
                        //数量
                        else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Qty)
                        {
                            if (this.SetItemProperty() == -1)
                            {
                                return true;
                            }
                            if (this.fpDetail_Sheet.Cells[this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Day].Locked)
                            {
                                this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Dept);
                            }
                            else
                            {
                                this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Day);
                            }
                        }
                        //付数
                        else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Day)
                        {
                            if (this.SetItemProperty() == -1)
                            {
                                return true;
                            }
                            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Dept);
                        }
                        else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Unit)
                        {
                            this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.Dept);
                        }
                        //执行科室
                        else if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.Dept)
                        {
                            if (this.ProcessDept() == -1)
                            {
                                return true;
                            }
                            //在最后一行，自动增加一行
                            if (this.fpDetail_Sheet.RowCount == this.fpDetail_Sheet.ActiveRowIndex + 2)
                            {
                                this.AddRow(this.fpDetail_Sheet.RowCount - 1);
                            }
                            else
                            {
                                this.fpDetail_Sheet.ActiveRowIndex++;
                                this.fpDetail_Sheet.SetActiveCell(this.fpDetail_Sheet.ActiveRowIndex, (int)Columns.ItemName, true);
                            }
                        }
                    }
                    break;
                case Keys.Up:
                    if (this.fpDetail.ContainsFocus)
                    {
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.PriorRow();
                        }
                        else if (this.lbDept.Visible)
                        {
                            this.lbDept.PriorRow();
                        }
                        else
                        {
                            int currRow = this.fpDetail_Sheet.ActiveRowIndex;
                            if (currRow > 0)
                            {
                                this.fpDetail_Sheet.ActiveRowIndex = currRow - 1;
                                this.fpDetail_Sheet.AddSelection(currRow - 1, 0, 1, 1);
                            }
                        }
                    }
                    break;
                case Keys.Down:
                    if (this.fpDetail.ContainsFocus)
                    {
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.NextRow();
                        }
                        else if (lbDept.Visible)
                        {
                            this.lbDept.NextRow();
                        }
                        else
                        {
                            int currRow = this.fpDetail_Sheet.ActiveRowIndex;

                            if (currRow < this.fpDetail_Sheet.RowCount - 2)
                            {
                                this.fpDetail_Sheet.ActiveRowIndex = currRow + 1;
                                this.fpDetail_Sheet.AddSelection(currRow + 1, 0, 1, 1);
                            }
                            else
                            {
                                this.AddRow();
                            }
                        }
                    }
                    break;
                case Keys.Escape:
                    if (this.ucItemList.Visible)
                    {
                        this.ucItemList.Visible = false;
                    }
                    if (this.lbDept.Visible)
                    {
                        this.lbDept.Visible = false;
                    }
                    break;
                #endregion
                case Keys.F2:
                    if (this.fpDetail.ContainsFocus && this.ucItemList.Visible)
                    {
                        this.ucItemList.SetCurrentRow(1);
                        this.ProcessItem();
                    }
                    break;
                case Keys.F3:
                    if (this.fpDetail.ContainsFocus && this.ucItemList.Visible)
                    {
                        this.ucItemList.SetCurrentRow(2);
                        this.ProcessItem();
                    }
                    break;
                case Keys.F4:
                    if (this.fpDetail.ContainsFocus && this.ucItemList.Visible)
                    {
                        this.ucItemList.SetCurrentRow(3);
                        this.ProcessItem();
                    }
                    break;
                case Keys.F9:
                    if (!this.ucItemList.Visible)
                    {
                        this.isSubTotal = true;
                        this.SubTotal();
                        this.isSubTotal = false;
                    }
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 更改数量、价格判断事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetail_Change(object sender, ChangeEventArgs e)
        {
            if (this.isSubTotal)
            {
                //正在小计返回
                return;
            }
            switch (e.Column)
            {
                case (int)Columns.Price://判断价格合法性
                    this.SetItemProperty();
                    break;
                case (int)Columns.Qty://判断数量合法性
                    this.SetItemProperty();
                    break;
                case (int)Columns.Day:
                    this.SetItemProperty();
                    break;
            }
        }

        /// <summary>
        /// 项目选择事件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int ucItemList_SelectItem(Keys key)
        {
            this.ProcessItem();
            return 0;
        }

        /// <summary>
        /// 开始输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetail_EditModeOn(object sender, EventArgs e)
        {
            this.fpDetail.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            this.SetLocation();
            if (this.fpDetail_Sheet.ActiveColumnIndex != (int)Columns.Dept)
            {
                this.lbDept.Visible = false;
            }
            if (fpDetail_Sheet.ActiveColumnIndex != (int)Columns.ItemName)
            {
                this.ucItemList.Visible = false;
            }
        }

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.fpDetail_Sheet.ActiveColumnIndex == (int)Columns.ItemName)
            {
                switch (e.KeyCode)
                {
                    #region F1~F10快捷选择项目,F2~F4为farpoint内部键，在processdialogkey处理
                    case Keys.F1:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(0);
                            ProcessItem();
                        }
                        break;
                    case Keys.F5:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(4);
                            ProcessItem();
                        }
                        break;
                    case Keys.F6:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(5);
                            ProcessItem();
                        }
                        break;
                    case Keys.F7:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(6);
                            ProcessItem();
                        }
                        break;
                    case Keys.F8:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(7);
                            ProcessItem();
                        }
                        break;
                    case Keys.F9:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(8);
                            ProcessItem();
                        }
                        break;
                    case Keys.F10:
                        if (this.ucItemList.Visible)
                        {
                            this.ucItemList.SetCurrentRow(9);
                            ProcessItem();
                        }
                        break;
                    #endregion
                    case Keys.F11://切换输入法
                        if (this.ucItemList.Visible)
                            this.ucItemList.ChangeQueryType();
                        break;
                    case Keys.PageDown://下一页
                        if (this.ucItemList.Visible)
                            this.ucItemList.NextPage();
                        break;
                    case Keys.PageUp://上一页
                        if (this.ucItemList.Visible)
                            this.ucItemList.PriorPage();

                        break;
                }
            }
        }

        /// <summary>
        /// 输入的内容发生变化时,主要处理项目的过滤码和执行科室的检索条件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Row == this.fpDetail_Sheet.RowCount - 1) 
            {
                return;
            }
            
            string text;
            switch (e.Column)
            {
                case (int)Columns.ItemName://项目名称
                    text = this.fpDetail_Sheet.ActiveCell.Text;
                    this.ucItemList.Filter(text);
                    if (!this.ucItemList.Visible)
                    {
                        this.ucItemList.Visible = true;
                    }
                    //清空当前行变量
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Price, string.Empty, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Qty, string.Empty, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Unit, string.Empty, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.TotCost, string.Empty, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Dept, string.Empty, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.ItemObject, null, false);
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.IsNew, string.Empty, false);
                    break;
                case (int)Columns.Dept://过滤执行科室			
                    text = this.fpDetail_Sheet.ActiveCell.Text;
                    this.lbDept.Filter(text);
                    //记录执行科室已经修改，要重新赋值
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.IsDeptChange, "1", false);
                    object obj = this.fpDetail_Sheet.GetValue(e.Row, (int)Columns.ItemObject);
                    if (obj != null)//一旦科室发生变化，清空实体里执行科室
                    {
                        FeeItemList f = obj as FeeItemList;
                        f.ExecOper.Dept.ID = string.Empty;
                        f.ExecOper.Dept.Name = string.Empty;
                        this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.ItemObject, f, false);
                    }
                    if (!lbDept.Visible)
                    {
                        this.lbDept.Visible = true;
                    }
                    break;
                case (int)Columns.Qty://记录修改的数量
                    string isNew = this.fpDetail_Sheet.GetText(e.Row, (int)Columns.IsNew);
                    if (isNew == "0")
                    {
                        this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.IsNew, "2", false);
                    }
                    break;
            }
        }

        /// <summary>
        /// 选择包装单位和最小单位时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetail_ComboSelChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)Columns.Unit)
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)this.fpDetail_Sheet.Cells[e.Row, e.Column].CellType;

                string text = e.EditingControl.Text;
                if (((FarPoint.Win.FpCombo)e.EditingControl).SelectedIndex == 0)
                {
                    //按最小单位收费
                    object obj = fpDetail_Sheet.GetValue(e.Row, (int)Columns.ItemObject);
                    if (obj == null)
                    {
                        return;
                    }
                    decimal price = Neusoft.FrameWork.Public.String.FormatNumber(
                        (obj as FeeItemList).Item.Price /
                        (obj as FeeItemList).Item.PackQty, 4);

                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Price, price, false);
                    //计算总额
                    text = this.fpDetail_Sheet.GetText(e.Row, (int)Columns.Qty);//数量
                    if (text == string.Empty)
                    {
                        text = "0";
                    }
                    decimal qty = NConvert.ToDecimal(text);
                    //付数
                    text = this.fpDetail_Sheet.GetText(e.Row, (int)Columns.Day);
                    if (text == string.Empty)
                    {
                        text = "0";
                    }
                    decimal day = NConvert.ToDecimal(text);

                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.TotCost, price * qty * day, false);
                }
                else if (((FarPoint.Win.FpCombo)e.EditingControl).SelectedIndex == 1)
                {
                    //按包装单位收费
                    object obj = fpDetail_Sheet.GetValue(e.Row, (int)Columns.ItemObject);
                    if (obj == null)
                    {
                        return;
                    }
                    decimal price = (obj as FeeItemList).Item.Price;
                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.Price, price, false);
                    //计算总额
                    text = this.fpDetail_Sheet.GetText(e.Row, (int)Columns.Qty);//数量
                    if (text == string.Empty)
                    {
                        text = "0";
                    }
                    decimal qty = NConvert.ToDecimal(text);
                    //付数
                    text = this.fpDetail_Sheet.GetText(e.Row, (int)Columns.Day);
                    if (text == string.Empty)
                    {
                        text = "0";
                    }
                    decimal day = NConvert.ToDecimal(text);

                    this.fpDetail_Sheet.SetValue(e.Row, (int)Columns.TotCost, price * qty * day, false);
                }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 收费类型
        /// </summary>
        public enum FeeTypes 
        {
            /// <summary>
            /// 划价
            /// </summary>
            划价 = 0,

            /// <summary>
            /// 收费
            /// </summary>
            收费,

            /// <summary>
            /// 终端确认
            /// </summary>
            终端确认,

            /// <summary>
            /// 体检收费
            /// </summary>
            体检收费,
        }

        /// <summary>
        /// 项目类别枚举
        /// </summary>
        public enum ItemKind
        {
            /// <summary>
            /// 药品
            /// </summary>
            Drug,

            /// <summary>
            /// 非药品
            /// </summary>
            Undrug,

            /// <summary>
            /// 全部，药品和非药品
            /// </summary>
            All
        }

        /// <summary>
        /// 枚举列，调整列时相应调整该枚举
        /// </summary>
        public enum Columns
        {
            /// <summary>
            /// 住院号
            /// </summary>
            InpatientNO,

            /// <summary>
            /// 患者姓名
            /// </summary>
            InpatientName,
            /// <summary>
            /// 项目名称
            /// </summary>
            ItemName,

            /// <summary>
            /// 价格
            /// </summary>
            Price,

            /// <summary>
            /// 数量
            /// </summary>
            Qty,

            /// <summary>
            /// 付数
            /// </summary>
            Day,

            /// <summary>
            /// 单位
            /// </summary>
            Unit,

            /// <summary>
            /// 总额
            /// </summary>
            TotCost,

            /// <summary>
            /// 执行科室
            /// </summary>
            Dept,

            /// <summary>
            /// 项目的对象,Item Instance
            /// </summary>
            ItemObject,

            /// <summary>
            /// 是否新增项目,0原有(数据库中),1新增,2修改
            /// </summary>
            IsNew,

            /// <summary>
            /// 执行科室是否修改0,否 1是
            /// </summary>
            IsDeptChange,

            /// <summary>
            /// 收费药品，1是0否
            /// </summary>
            IsDrug,
            //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
            /// <summary>
            /// 组合号
            /// </summary>
            GroupID,

            /// <summary>
            ///组套上次收费日期
            /// </summary>
            FeeDate
        }

        #endregion

        private void fpDetail_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        /// <summary>
        /// 双击时删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetail_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            this.DelRow();
        }

        private void ucInpatientChargeNew_Load(object sender, EventArgs e)
        {
            if (!Neusoft.HISFC.Components.Common.Classes.Function.DesignMode)
            {
                this.fpDetail_Sheet.ActiveColumnIndex = (int)Columns.ItemName;
                operObj = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Clone();
                //{062CEAA8-16B8-4c25-B4CC-E6B24DE7D331}
                IAdptIllnessInPatient = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessInPatient)) as HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessInPatient;
                //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                this.neuGroupBox1.Text = this.neuGroupBox1.Text + " ----当前日期:" + this.inpatientManager.GetDateTimeFromSysDateTime().ToShortDateString(); 
            }
        }

        #region IInterfaceContainer 成员
        //{062CEAA8-16B8-4c25-B4CC-E6B24DE7D331}
        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { 
                    typeof(HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessInPatient),
                    typeof(HISFC.BizProcess.Interface.Order.IFeeSheet),//{6C307A55-948E-475a-A015-8732DDE9D19A}
                    typeof(HISFC.BizProcess.Interface.Order.IDrugFeeSheet),// {1C1B0872-954C-4eb3-9E15-9072E8139AF9}
                    //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
                    typeof(HISFC.BizProcess.Interface.FeeInterface.IShowFeeTree)
                };
            }
        }

        #endregion
    }
}
