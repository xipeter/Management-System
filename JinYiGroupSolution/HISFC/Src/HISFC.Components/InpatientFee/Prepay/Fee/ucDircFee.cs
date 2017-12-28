using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.RADT;
using System.Collections;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucDircFee<br></br>
    /// [功能描述: 住院直接收费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDircFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,  Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDircFee()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 入出转业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected ControlParam controlManager = new ControlParam();

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 费用公共业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 公共管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyInterate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        /// <summary>
        /// 发票对照信息
        /// </summary>
        protected DataSet dsInvoice = null;

        /// <summary>
        /// 是否可以更改合同单位
        /// 如果不可以更改,默认为自费
        /// </summary>
        protected bool isCanChoosePact = false;

        /// <summary>
        /// 是否通过姓名生成费用信息
        /// </summary>
        protected bool isInputName = false;

        /// <summary>
        /// 支付方式选择控件
        /// </summary>
        Neusoft.HISFC.Components.Common.Controls.ucBalancePay balancePayControl = new Neusoft.HISFC.Components.Common.Controls.ucBalancePay();

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费
        /// </summary>
        Neusoft.HISFC.Models.Base.MessType messtype = Neusoft.HISFC.Models.Base.MessType.Y;

        #endregion
        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy);

                return type;
            }
        }

        #endregion
        #region 属性
        /// <summary>
        /// 是否可以更改合同单位
        /// 如果不可以更改,默认为自费
        /// </summary>
        [Category("控件设置"), Description("是否可以更改合同单位,如果不可以更改,默认为自费")]
        public bool IsCanChoosePact 
        {
            get 
            {
                return this.isCanChoosePact;
            }
            set 
            {
                this.isCanChoosePact = value;

                this.cmbPact.Enabled = this.isCanChoosePact;
            }
        }

        /// <summary>
        /// 当前窗口是否设计模式
        /// </summary>
        protected new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");


            }
        }

        [Category("控件设置"), Description("是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
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

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Init() 
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化,请等待...");
            Application.DoEvents();

            //初始化住院科室
            if (InitDept() == -1) 
            {
                return -1;
            }

            //初始化合同单位,
            if (this.InitPact() == -1) 
            {
                return -1;
            }

            //初始化医生
            if (this.InitDoct() == -1) 
            {
                return -1;
            }

            //初始化收费控件
            this.ucInpatientCharge1.Init(string.Empty);
            this.feeIntegrate.MessageType = this.MessageType;
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 初始化医生信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDoct()
        {
            ArrayList doctList = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (doctList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("初始化医生列表出错!") + this.managerIntegrate.Err);

                return -1;
            }
            this.cmbDoct.AddItems(doctList);

            return 1;
        }

        /// <summary>
        /// 初始化合同单位信息
        /// </summary>
        /// <returns>成功1 失败 -1</returns>
        private int InitPact()
        {
            //如果可以选择合同单位,那么丛合同单位信息表中获取所有合同单位
            //填充到合同单位选择的combox中,如果不可以选择,默认初始一个自费的合同单位.
            if (this.isCanChoosePact)
            {
                ArrayList pactList = this.pactManager.QueryPactUnitAll();
                if (pactList == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Language.Msg("初始化合同单位列表出错!") + this.pactManager.Err);

                    return -1;
                }
                this.cmbPact.Enabled = true;
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject tempObj = new Neusoft.FrameWork.Models.NeuObject();
                tempObj.ID = "1";
                tempObj.Name = "自费";

                ArrayList pactList = new ArrayList();
                pactList.Add(tempObj);

                this.cmbPact.AddItems(pactList);

                this.cmbPact.SelectedIndex = 0;

                this.cmbPact.Enabled = false;
            }

            return 1;
        }

        /// <summary>
        /// 初始化住院科室
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDept()
        {
            ArrayList deptList = this.managerIntegrate.QueryDeptmentsInHos(true);
            if (deptList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("初始化科室列表出错!") + this.managerIntegrate.Err);

                return -1;
            }
            this.cmbDept.AddItems(deptList);

            return 1;
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        protected virtual void SetInfomaition() 
        {
            this.txtName.Text = this.patientInfo.Name;
            this.cmbDept.Tag = this.patientInfo.PVisit.PatientLocation.Dept.ID;
            this.cmbDoct.Tag = this.patientInfo.PVisit.AdmittingDoctor.ID;
            this.txtInDate.Text = this.patientInfo.PVisit.InTime.ToShortDateString();
            this.txtBedNO.Text = this.patientInfo.PVisit.PatientLocation.Bed.ID;
            this.txtNurseStation.Text = this.patientInfo.PVisit.PatientLocation.NurseCell.Name;
            this.txtLeftCost.Text = this.patientInfo.FT.LeftCost.ToString();
            this.txtDoct.Text = this.patientInfo.PVisit.AdmittingDoctor.Name;

        }

        /// <summary>
        /// 验证在院患者的在院状态是否符合直接收费
        /// 出院患者,包括无费退院患者 和未接诊患者 都不能直接收费
        /// </summary>
        /// <returns>可以收费 True 不可以 false</returns>
        protected virtual bool IsPatientStateValid() 
        {
            //判断是否出院
            if (this.patientInfo.PVisit.InState.ID.ToString() == "N" || this.patientInfo.PVisit.InState.ID.ToString() == "O")
            {
                MessageBox.Show(Language.Msg("该患者已经出院!"));
                this.ucQueryInpatientNO.Focus();
                this.ucQueryInpatientNO.TextBox.SelectAll();

                this.patientInfo.ID = null;

                return false;
            }

            //判断没有接诊
            if (this.patientInfo.PVisit.InState.ID.ToString() == "R")
            {
                MessageBox.Show(Language.Msg("该患者还没有接诊,请去病区接诊后收费"));

                this.ucQueryInpatientNO.Focus();
                this.ucQueryInpatientNO.TextBox.SelectAll();

                this.patientInfo.ID = null;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 通过输入姓名获得患者基本信息
        /// </summary>
        /// <returns>成功 患者基本信息实体 失败: null</returns>
        protected virtual Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfoFromInputName() 
        {
            string temp = this.controlManager.QueryControlerInfo("100024");

            string pNO = this.inpatientManager.GetTempPatientNO(temp);
            if (pNO == null || pNO == string.Empty) 
            {
                pNO = temp + "000000";
                MessageBox.Show(Language.Msg("获取临时住院号吗出错!系统将初始化住院号"));
            }

            pNO = (long.Parse(pNO) + 1).ToString();

            pNO = pNO.PadLeft(10, '0');

            MessageBox.Show("产生临时住院号码为" + pNO, "提示");

            this.ucQueryInpatientNO.TextBox.Text = pNO;
            this.patientInfo.ID = "ZY01" + pNO;
            this.patientInfo.PID.PatientNO = pNO;
            this.patientInfo.PID.CardNO = pNO;
            this.patientInfo.Name = this.txtName.Text;//姓名
            this.patientInfo.PVisit.PatientLocation.Dept.Name = this.cmbDept.Text; //科室
            this.patientInfo.PVisit.PatientLocation.Dept.ID = this.cmbDept.Tag.ToString();//科室代码
            this.patientInfo.PVisit.PatientLocation.NurseCell.ID = this.cmbDept.Tag.ToString(); //护士站暂时用科室代码
            this.patientInfo.Sex.ID = "U";//性别
            this.patientInfo.PVisit.InTime = this.inpatientManager.GetDateTimeFromSysDateTime();//入院日期
            this.patientInfo.Pact.ID = this.cmbPact.Tag.ToString();
            this.patientInfo.Pact.Name = this.cmbPact.Text;
            this.patientInfo.Pact.PayKind.ID = "01";//结算类别
            this.patientInfo.Pact.Name = "自费";//合同单位名称
            this.patientInfo.PVisit.AdmitSource.ID = "0";//入院来源
            this.patientInfo.PVisit.InSource.ID = "0";//入院途径
            this.patientInfo.PVisit.Circs.ID = "0"; //入院情况
            this.patientInfo.BalanceNO = 0; //结算序号

            this.txtInDate.Text = this.patientInfo.PVisit.InTime.ToShortDateString();

            return this.patientInfo;
        }

        /// <summary>
        /// 判断合法性质
        /// </summary>
        /// <returns>符合true 不符合 false</returns>
        protected virtual bool IsValid() 
        {
            if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty || this.cmbDoct.Text == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入开方医生"));
                this.cmbDoct.Focus();

                return false;
            }

            if (this.ucQueryInpatientNO.TextBox.Text.Trim() == string.Empty || this.ucQueryInpatientNO.TextBox.Text == null)
            {
                MessageBox.Show(Language.Msg("请选择一个患者!"));

                return false;
            }

            if (this.patientInfo == null)
            {
                MessageBox.Show(Language.Msg("请输入患者基本信息"));

                return false;
            }

            if (this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("请选择一个患者!"));
                
                return false ;
            }
            if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入住院科室！"));
                this.cmbDept.Focus();
                return false;

            }

            try
            {
                patientInfo.PVisit.PatientLocation.Dept.Name = ((Neusoft.HISFC.Models.Base.Department)this.cmbDept.SelectedItem).Memo;//科室名称
            }
            catch 
            {
                MessageBox.Show(Language.Msg("住院科室输入不正确，请重新输入！"));
                return false;
            }
            return this.ucInpatientCharge1.IsValid();
        }

        /// <summary>
        /// 生成结算明细信息集合
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="list">明细结合</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 承载BalanceList的范型集合 失败 null</returns>
        protected ArrayList MakeBalanceListFromFeeItemList(string invoiceNO, DateTime operTime, int balanceNO, ArrayList list, ref string errText) 
        {
            ArrayList balanceLists = new ArrayList();

            dsInvoice = new DataSet();

            if (this.feeIntegrate.GetInvoiceClass("ZY01", ref dsInvoice) == -1)
            {
                errText = "获得发票信息出错!" + this.feeIntegrate.Err;

                return null;
            }

            dsInvoice.Tables[0].PrimaryKey = new DataColumn[] { dsInvoice.Tables[0].Columns["FEE_CODE"] };
           
            foreach (FeeItemList f in list)
            {
                DataRow rowFind = dsInvoice.Tables[0].Rows.Find(new object[] { f.Item.MinFee.ID });
                if (rowFind == null)
                {
                    errText = "初始化发票失败,请维护发票对照中最小费用为" + f.Item.MinFee.Name + "的发票项目";
                        //"最小费用为" + f.Item.MinFee.ID + "的最小费用没有在MZ01的发票大类中维护";

                    return null;
                }
          
                rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.OwnCost;
                rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + f.FT.OwnCost;
                rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + 0;
                rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + 0;
            }

            BalanceList balanceList = null;

            for (int i = 1; i < 100; i++)
            {
                //找到相同打印序号,即同一统计类别的费用集合
                DataRow[] rowFind = dsInvoice.Tables[0].Select("SEQ = " + i.ToString(), "SEQ ASC");
                //如果没有找到说明已经找过了最大的打印序号,所有费用已经累加完毕.
                if (rowFind.Length == 0)
                {

                }
                else
                {
                    balanceList = new BalanceList();

                    foreach (DataRow row in rowFind)
                    {
                        balanceList.BalanceBase.FT.PubCost += NConvert.ToDecimal(row["PUB_COST"].ToString());
                        balanceList.BalanceBase.FT.OwnCost += NConvert.ToDecimal(row["OWN_COST"].ToString());
                        balanceList.BalanceBase.FT.PayCost += NConvert.ToDecimal(row["PAY_COST"].ToString());
                    }

                    balanceList.BalanceBase.FT.TotCost = balanceList.BalanceBase.FT.OwnCost + balanceList.BalanceBase.FT.PayCost + balanceList.BalanceBase.FT.PubCost;

                    if (balanceList.BalanceBase.FT.TotCost <= 0)
                    {
                        continue;
                    }

                    balanceList.BalanceBase.Invoice.ID = invoiceNO;
                    balanceList.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    balanceList.FeeCodeStat.StatCate.ID = rowFind[0]["FEE_STAT_CATE"].ToString();
                    balanceList.FeeCodeStat.StatCate.Name= rowFind[0]["FEE_STAT_NAME"].ToString();
                    balanceList.FeeCodeStat.SortID = i;
                    balanceList.BalanceBase.BalanceOper.ID = this.inpatientManager.Operator.ID;
                    balanceList.BalanceBase.BalanceOper.OperTime = operTime;
                    balanceList.BalanceBase.BalanceType.ID = Neusoft.HISFC.Models.Fee.EnumBalanceType.D;
                    balanceList.BalanceBase.BalanceOper.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)this.inpatientManager.Operator).Dept.ID;
                    balanceList.BalanceBase.ID = balanceNO.ToString();

                    balanceLists.Add(balanceList);
                }
            }

            return balanceLists;
        }

        /// <summary>
        /// 生成结算主信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="balanceLists">承载BalanceList的范型集合</param>
        /// <returns>成功:发票住表信息实体 失败: null</returns>
        protected Neusoft.HISFC.Models.Fee.Inpatient.Balance MakeBalanceFromBalanceList(string invoiceNO, DateTime operTime, int balanceNO, ArrayList balanceLists) 
        {
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();

            balance = ((Neusoft.HISFC.Models.Fee.Inpatient.Balance)(balanceLists[0] as BalanceList).BalanceBase).Clone();
            balance.FT = new Neusoft.HISFC.Models.Base.FT();

            foreach (BalanceList balanceList in balanceLists) 
            {
                balance.FT.TotCost += balanceList.BalanceBase.FT.TotCost;
                balance.FT.OwnCost += balanceList.BalanceBase.FT.OwnCost;
                balance.FT.PayCost += balanceList.BalanceBase.FT.PayCost ;
                balance.FT.PubCost += balanceList.BalanceBase.FT.PubCost;
            }

            balance.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
            balance.FT.SupplyCost = balance.FT.TotCost;
			balance.BeginTime = operTime;
            balance.EndTime = operTime;
            balance.PrintTimes = 1;
			balance.IsMainInvoice = true;
            balance.IsLastBalance = false;
            balance.ID = balanceNO.ToString();

            return balance;
        }

        /// <summary>
        /// 获得结算序号
        /// </summary>
        /// <returns>成功 结算序号 失败 -1</returns>
        private int GetBalanceNO() 
        {
            //调业务层获取结算次数
            string balanceNO = string.Empty;

            balanceNO = this.inpatientManager.GetNewBalanceNO(this.patientInfo.ID);
            if (balanceNO == null)
            {
                return -1;
            }
            if (balanceNO == "-1") 
            {
                balanceNO = "1";
            }

            return NConvert.ToInt32(balanceNO);
        }

        /// <summary>
        /// 插入患者基本信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InsertPatientInfo() 
        {
            int iReturn = 0;

        SetNewNo:

            string pNO = string.Empty;

            string parm = this.controlManager.QueryControlerInfo("100024");

            pNO = this.inpatientManager.GetTempPatientNO(parm);
            if (pNO == null || pNO == string.Empty)
            {
                pNO = parm + "000000";
            }

            pNO = ((long.Parse(pNO) + 1).ToString()).PadLeft(10, '0');

            this.ucQueryInpatientNO.txtInputCode.Text = pNO;
            this.patientInfo.ID = "ZY01" + pNO;
            this.patientInfo.PID.PatientNO = pNO;
            this.patientInfo.PID.CardNO = pNO;

            //状态需设置为在院状态才可以正常收费
            //this.patientInfo.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.O;
            this.patientInfo.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.I;

            //插入患者主表
            iReturn = this.radtIntegrate.RegisterPatient(this.patientInfo);
            if (iReturn <= 0)
            {

                if (this.radtIntegrate.DBErrCode == 1)
                {
                    goto SetNewNo;
                }
                else
                {
                    MessageBox.Show(this.patientInfo.PID.PatientNO + Language.Msg("已经被用，请重新输入姓名生成住院号") + this.radtIntegrate.Err);
                    
                    return -1;                    
                }

            }
            //更新没有病案标记，病案模块不读取这种患者
            iReturn = this.radtIntegrate.UpdatePatientCaseFlag(this.patientInfo.ID, "0");

            if (iReturn <= 0)
            {
                MessageBox.Show("更新病案标记出错！" + this.radtIntegrate.Err);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 清空!
        /// </summary>
        protected void Clear() 
        {
            this.txtName.Text = string.Empty;
            this.cmbDept.Tag = string.Empty;
            this.cmbDoct.Tag = string.Empty;
            this.txtInDate.Text = string.Empty;
            this.txtBedNO.Text = string.Empty;
            this.txtNurseStation.Text = string.Empty;
            this.txtLeftCost.Text = string.Empty;
            this.txtDoct.Text = string.Empty;

            this.patientInfo = null;

            this.ucInpatientCharge1.Clear();

            this.rbName.Checked = true;
            this.isInputName = true;
            this.txtName.Focus();
            this.ucQueryInpatientNO.Text = string.Empty;
        }

        /// <summary>
        /// 发票打印
        /// </summary>
        /// <param name="alBalanceList">结算大类数组</param>
        /// <param name="balanceForInvoice">结算主实体</param>
        protected virtual void PrintInvoice(ArrayList alBalanceList,Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceForInvoice)
        {
            //Balance.ucBalanceInvoice balanceInvoice = new UFC.InpatientFee.Balance.ucBalanceInvoice();
            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy balanceInvoice = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;

            if (balanceInvoice == null)
            {
                return;
            }
            balanceInvoice.PatientInfo = this.patientInfo;
            //{D0D3A300-FD19-4fef-B763-FD5697274BBD}
            if (balanceInvoice.SetValueForPrint(this.patientInfo, balanceForInvoice, alBalanceList,null) == -1)
            {
                
                return ;
            }
            //调打印类
            balanceInvoice.Print();
        }

        #endregion

        #region 共有方法

        /// <summary>
        /// 保存收费信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Save() 
        {   
            if (!this.IsValid()) 
            {
                return -1;
            }

            //开始数据库事务
            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.controlManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.pharmacyInterate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            

            //变量定义
            ArrayList feeItemlists = new ArrayList();//当前要收费项目列表
            string invoiceNO = string.Empty;//发票号
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();//当前系统时间
            int balanceNO = 0;//结算序号
            string recipeDoctCode = string.Empty;//开立医生编码
            int returnValue = 0;//返回值
            string errText = string.Empty;//错误信息
            recipeDoctCode = this.ucInpatientCharge1.RecipeDoctCode;

            //获得发票号
            //{C3C5304F-2034-4fbd-A42C-EFE4F6EA6E8E}
            //invoiceNO = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.I);
            invoiceNO = this.feeIntegrate.GetNewInvoiceNO("I");
            if (invoiceNO == null || invoiceNO.Trim() == string.Empty)
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("请领取住院结算发票!") );
                
                return -1;
            }

            //获得结算序号
            balanceNO = this.GetBalanceNO();
            if (balanceNO == -1) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("获得结算序号出错!") + this.inpatientManager.Err);

                return -1;
            }

            //如果是手工输入的姓名,当作重新登记患者处理
            if (this.isInputName) 
            {
                this.patientInfo.BalanceNO = balanceNO;

                if (this.InsertPatientInfo() == -1) 
                {
                    this.feeIntegrate.Rollback();
                    MessageBox.Show(Language.Msg("插入患者基本信息!") + this.radtIntegrate.Err);

                    return -1;
                }
            }

            //获得当前所有要收费的项目信息,并且赋值医生,当前时间等信息
            feeItemlists = this.ucInpatientCharge1.QueryFeeItemArrayList(recipeDoctCode, nowTime, "0");
            if (feeItemlists == null) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("获得收费明细出错!"));

                return -1;
            }
            if (feeItemlists.Count == 0) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("请录入收费明细!"));

                return -1;
            }

            //循环对费用明细赋值
            foreach (FeeItemList f in feeItemlists) 
            {
                f.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                f.Patient = this.patientInfo.Clone();
                f.PayType = Neusoft.HISFC.Models.Base.PayTypes.Balanced;
                //f.ExecOper.ID = this.inpatientManager.Operator.ID;
                //f.ExecOper.OperTime = nowTime;
                f.FeeOper.ID = this.inpatientManager.Operator.ID;
                f.FeeOper.OperTime = nowTime;
                f.BalanceNO = balanceNO;
                f.BalanceState = "1";
                f.NoBackQty = f.Item.Qty;
                f.Invoice.ID = invoiceNO;
                f.RecipeOper.ID = recipeDoctCode;
                f.RecipeOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                f.StockOper.Dept.ID = f.ExecOper.Dept.ID;
                
            }

            //调用收费函数
            this.feeIntegrate.MessageType = Neusoft.HISFC.Models.Base.MessType.N;
            returnValue = this.feeIntegrate.FeeItem(this.patientInfo, ref feeItemlists);
            if (returnValue == -1) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("调用收费函数出错!") + this.feeIntegrate.Err);

                return -1;
            }
          
            //插入发药申请
            foreach (FeeItemList f in feeItemlists) 
            {
                //if (f.Item.IsPharmacy)
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {

                    returnValue = this.pharmacyInterate.ApplyOut(this.patientInfo, f, nowTime, true);
                    if (returnValue == -1)
                    {
                        this.feeIntegrate.Rollback();
                        MessageBox.Show(Language.Msg("调用发药申请函数出错!") + this.pharmacyInterate.Err);

                        return -1;
                    }
                }
            }

            //生成结算明细
            ArrayList balanceList = this.MakeBalanceListFromFeeItemList(invoiceNO, nowTime, balanceNO, feeItemlists, ref errText);
            if (balanceList == null) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("生成结算明细出错!") + errText);

                return -1;
            }

            //插入结算明细信息
            returnValue = this.feeIntegrate.InsertBalanceList(this.patientInfo, balanceList);
            if (returnValue == -1) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("插入结算明细出错!") + this.feeIntegrate.Err);

                return -1;
            }

            //生成结算头信息
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = this.MakeBalanceFromBalanceList(invoiceNO, nowTime, balanceNO, balanceList);
            if (balance == null) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("生成结算头出错!"));

                return -1;
            }

            //插入结算头信息
            returnValue = this.inpatientManager.InsertBalance(this.patientInfo, balance);
            if (returnValue == -1)
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("插入结算头表出错!") + this.inpatientManager.Err);

                return -1;
            }

            balancePayControl = new Neusoft.HISFC.Components.Common.Controls.ucBalancePay();

            balancePayControl.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            balancePayControl.IsShowButton = true;
            balancePayControl.Init();
            balancePayControl.ServiceType = Neusoft.HISFC.Models.Base.ServiceTypes.I;
            balancePayControl.TotOwnCost = balance.FT.OwnCost;
            balancePayControl.RealCost = balance.FT.OwnCost;

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(balancePayControl);

            if (!balancePayControl.IsCurrentChoose) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("请正确选择支付方式!"));

                return -1;
            }

            ArrayList balancePayList = this.balancePayControl.QueryBalancePayList();
            if (balancePayList == null || balancePayList.Count == 0) 
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("请重新选择支付方式!"));

                return -1;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay in balancePayList)
            {
                balancePay.Invoice.ID = invoiceNO;
                balancePay.BalanceNO = balanceNO;
                balancePay.TransKind.ID = "1";
                balancePay.BalanceOper.ID = this.inpatientManager.Operator.ID;
                balancePay.BalanceOper.OperTime = nowTime;
                returnValue = this.inpatientManager.InsertBalancePay(balancePay);
                if (returnValue == -1)
                {
                    this.feeIntegrate.Rollback();
                    MessageBox.Show(Language.Msg("插入支付方式失败!") + this.inpatientManager.Err);

                    return -1;
                }
            }

            returnValue = this.inpatientManager.UpdateInMainInfoBalanced(this.patientInfo,nowTime,balanceNO,balance.FT);
            if (returnValue != 1)
            {
                this.feeIntegrate.Rollback();
                MessageBox.Show(Language.Msg("更新住院主表失败!") + this.inpatientManager.Err);

                return -1;
            }

            //如果是手工输入的姓名,当作重新登记患者处理
            if (this.isInputName)
            {
                Neusoft.HISFC.Models.RADT.InStateEnumService status = new InStateEnumService();
                status.ID = Neusoft.HISFC.Models.Base.EnumInState.O;
                //更新患者状态为出院结算状态
                if (this.radtIntegrate.UpdatePatientState(this.patientInfo, status) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新患者状态发生错误!") + this.feeIntegrate.Err);

                    return -1;
                }
            }

            this.feeIntegrate.Commit();

            MessageBox.Show(Language.Msg("收费成功!"));

            this.PrintInvoice(balanceList, balance);

            this.Clear();
            
            return 1;   
        }

        #endregion

        #region 事件

        /// <summary>
        /// 住院号回车
        /// </summary>
        private void ucQueryInpatientNO_myEvent()
        {
            //{FF539371-A89F-4a21-911A-3F2FAE388EF0}
            this.ucInpatientCharge1.Clear();
            if ( this.ucQueryInpatientNO.InpatientNo == null || this.ucQueryInpatientNO.InpatientNo.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("没有该住院号,请验证再输入") + this.ucQueryInpatientNO.Err);
                this.ucQueryInpatientNO.Focus();
                this.ucQueryInpatientNO.TextBox.SelectAll();

                return;
            }

            //获得患者基本信息
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNO.InpatientNo);
            if (this.patientInfo == null) 
            {
                MessageBox.Show(Language.Msg("获得患者基本信息出错!") + this.radtIntegrate.Err);
                this.ucQueryInpatientNO.Focus();
                this.ucQueryInpatientNO.TextBox.SelectAll();

                return;
            }

            //判断在院状态是否符合
            if (!this.IsPatientStateValid()) 
            {
                return;
            }

            //显示患者基本信息
            this.SetInfomaition();

            this.ucInpatientCharge1.PatientInfo = this.patientInfo;
            
            this.cmbDoct.Focus();
        }

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("增加", "增加一条项目录入行", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除一条录入的项目", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 自定义按钮的事件
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
                case "增加":
                    this.ucInpatientCharge1.AddRow();
                    break;
                case "删除":
                    this.ucInpatientCharge1.DelRow();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                //{FF539371-A89F-4a21-911A-3F2FAE388EF0}
                this.ucInpatientCharge1.Clear();
                this.patientInfo = new PatientInfo();
                
                this.GetPatientInfoFromInputName();

                this.ucInpatientCharge1.PatientInfo = this.patientInfo;
                this.cmbDept.Focus();
            }
        }

        private void ucDircFee_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) 
            {
                this.rbName.Checked = true;
                this.txtName.Focus();
                
                this.Init();
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo != null)
            {
                if (this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != string.Empty)
                {
                    this.patientInfo.PVisit.PatientLocation.Dept.ID = this.cmbDept.Tag.ToString();
                    this.patientInfo.PVisit.PatientLocation.Dept.Name = this.cmbDept.Text.Trim();

                    this.patientInfo.PVisit.PatientLocation.NurseCell.ID = this.cmbDept.Tag.ToString();
                    this.patientInfo.PVisit.PatientLocation.NurseCell.Name = this.cmbDept.Text.ToString();
                }
            }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.cmbDoct.Focus();
            }
        }

        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo != null)
            {
                if (this.cmbDoct.Tag != null && this.cmbDoct.Tag.ToString() != string.Empty)
                {
                    this.patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoct.Tag.ToString();
                    this.patientInfo.PVisit.AdmittingDoctor.Name = this.cmbDoct.Text.Trim();
                    this.ucInpatientCharge1.RecipeDoctCode = this.patientInfo.PVisit.AdmittingDoctor.ID;
                }
            }
        }

        private void cmbDoct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.ucInpatientCharge1.Focus();
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            
            return base.OnSave(sender, neuObject);
        }

        private void rbInpatientNO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbInpatientNO.Checked)
            {
                this.txtName.Enabled = false;
                this.isInputName = false;
                this.ucQueryInpatientNO.txtInputCode.Enabled = true;
                this.ucQueryInpatientNO.Focus();
                this.ucQueryInpatientNO.txtInputCode.Focus();
            }
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbName.Checked) 
            {
                this.Clear();
                this.txtName.Enabled = true;
                this.ucQueryInpatientNO.txtInputCode.Enabled = false;
                this.isInputName = true;
                this.txtName.Focus();
            }
        }
    }
}
