using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Registration;
using FarPoint.Win.Spread;
using System.Xml;
namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucPatientInfo : UserControl, Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientInfomation
    {
        /// <summary>
        /// ucPopSelected<br></br>
        /// [功能描述: 门诊患者基本信息UC]<br></br>
        /// [创 建 者: 王宇]<br></br>
        /// [创建时间: 2006-2-5]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间='yyyy-mm-dd'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucPatientInfo()
        {
            InitializeComponent();
        }

        #region 变量

        #region 控制变量

        /// <summary>
        /// 没有挂号患者,卡号第一位标志,默认以9开头
        /// </summary>
        protected string noRegFlagChar = "9";

        /// <summary>
        /// 是否可以更改患者基本信息
        /// </summary>
        protected bool isCanModifyPatientInfo = false;

        /// <summary>
        /// 医生,科室输入编码是否要求全匹配
        /// </summary>
        protected bool isDoctDeptCorrect = false;

        /// <summary>
        /// 是否收费时候可以挂号医保患者
        /// </summary>
        protected bool isRegWhenFee = false;

        /// <summary>
        /// 是否默认等级编码
        /// </summary>
        protected bool isClassCodePre = false;

        /// <summary>
        /// 是否可以更改划价信息
        /// </summary>
        protected bool isCanModifyChargeInfo = false;

        /// <summary>
        /// 相同收费序列的收费信息
        /// </summary>
        ArrayList feeSameDetails = new ArrayList();
        /// <summary>
        /// 挂号界面默认的中文输入法
        /// </summary>
        private InputLanguage CHInput = null;
        #endregion

        /// <summary>
        /// 是否直接收费患者
        /// </summary>
        protected bool isRecordDirectFee = false;

        /// <summary>
        /// 是否可以增加项目
        /// </summary>
        protected bool isCanAddItem = false;

        /// <summary>
        /// 更改的项目信息
        /// </summary>
        protected ArrayList modifyFeeDetails = null;

        /// <summary>
        /// 医生所在科室
        /// </summary>
        protected string doctDeptCode = string.Empty;

        /// <summary>
        /// 患者费用信息集合
        /// </summary>
        private ArrayList feeDetails = null;

        /// <summary>
        /// 当前选中的收费序列中的项目信息集合
        /// </summary>
        private ArrayList feeDetailsSelected = null;

        /// <summary>
        /// 挂号科室集合
        /// </summary>
        private ArrayList regDeptList = new ArrayList();

        /// <summary>
        /// 当前收费序列
        /// </summary>
        private string recipeSequence = string.Empty;

        /// <summary>
        /// 合同单位下限额信息集合
        /// </summary>
        private ArrayList relations = null;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip neuContextMenuStrip1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
        /// <summary>
        /// 科室信息
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 医保接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy interfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

        #region 业务层变量

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        #endregion

        /// <summary>
        /// 患者挂号基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register patientInfo = null;

        /// <summary>
        /// 上一个患者挂号基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register prePatientInfo = null;

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        /// <summary>
        /// 累计金额
        /// </summary>
        private decimal addUpCost = 0m;
        /// <summary>
        /// 是否开始累计
        /// </summary>
        private bool isBeginAddUpCost = false;
        /// <summary>
        /// 是否有累计操作
        /// </summary>
        private bool isAddUp = false;

        /// <summary>
        /// 账户流程
        /// </summary>
        protected bool isAccountTerimalFee = false;
        #endregion


        #region IOutpatientInfomation 成员

        /// <summary>
        /// 获得所有划价保存信息.
        /// </summary>
        public ArrayList FeeSameDetails
        {
            get
            {
                feeSameDetails = new ArrayList();
                for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
                {
                    //fpRecipeSeq_Sheet1.Rows[i].Tag下保存同一收费序列的费用明细信息,类型为ArrayList
                    feeSameDetails.Add(this.fpRecipeSeq_Sheet1.Rows[i].Tag);
                }
                return feeSameDetails;
            }
            set { }
        }

        /// <summary>
        /// 上一个患者挂号基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PrePatientInfo 
        {
            get 
            {
                return this.prePatientInfo;
            }
            set 
            {
                this.prePatientInfo = value;
            }
        }

        /// <summary>
        /// 没有挂号患者,卡号第一位标志
        /// </summary>
        public string NoRegFlagChar
        {
            get
            {
                return this.noRegFlagChar;
            }
            set
            {
                this.noRegFlagChar = value;
            }
        }

        /// <summary>
        /// 焦点切换事件
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething ChangeFocus;        

        /// <summary>
        /// 合同单位变化事件
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething PactChanged;

        /// <summary>
        /// 患者挂号基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                this.patientInfo = value;
                if (patientInfo == null)
                {
                    this.tbCardNO.SelectAll();
                    this.tbCardNO.Focus();

                    return;
                }
                if (patientInfo != null)
                {
                    if (patientInfo.ID == "")//控制如果第一打开窗口则不相应crtl + X
                    {
                        return;
                    }

                    DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();

                    this.tbCardNO.Text = patientInfo.PID.CardNO;
                    if (!string.IsNullOrEmpty(patientInfo.Name))
                    {
                        this.tbName.Text = patientInfo.Name;
                        this.tbName.Enabled = false;
                    }
                    else
                    {
                        this.tbName.Enabled = true;
                    }
                    this.cmbSex.Tag = patientInfo.Sex.ID;
                    this.tbAge.Text = (nowTime.Year - patientInfo.Birthday.Year).ToString();
                    this.cmbRegDept.Tag = patientInfo.DoctorInfo.Templet.Dept.ID;
                    this.cmbDoct.Tag = patientInfo.DoctorInfo.Templet.Doct.ID;

                    if (patientInfo.Pact.PayKind.ID != "02")
                    {
                        this.cmbPact.Tag = patientInfo.Pact.ID;
                    }
                    else
                    {
                        this.cmbPact.SelectedIndexChanged -= new EventHandler(cmbPact_SelectedIndexChanged);
                        this.cmbPact.Tag = this.patientInfo.Pact.ID;
                        this.cmbPact.SelectedIndexChanged += new EventHandler(cmbPact_SelectedIndexChanged);
                    }

                    this.patientInfo.Pact = this.GetPactInfoByPactCode(this.cmbPact.Tag.ToString());

                    if (this.patientInfo.Pact.PayKind.ID == "02")
                    {
                        this.patientInfo.Pact.ID = this.cmbPact.Tag.ToString();
                        this.patientInfo.Pact.Name = this.cmbPact.Text;
                        this.SetRelations();
                        this.PactChanged();
                        this.PriceRuleChanaged();
                    }

                    this.tbMCardNO.Text = patientInfo.SSN;

                    if (this.patientInfo.Pact.IsNeedMCard)
                    {
                        System.Windows.Forms.KeyEventArgs e = new KeyEventArgs(System.Windows.Forms.Keys.Enter);

                        this.tbMCardNO_KeyDown(null, e);
                    }

                    if (this.patientInfo.Pact.PayKind.ID == "01")//自费
                    {
                        this.cmbClass.Enabled = false;
                        this.tbMCardNO.Enabled = false;
                        this.cmbRebate.Enabled = false;
                    }
                    else if (this.patientInfo.Pact.PayKind.ID == "02")//医保
                    {
                        this.cmbClass.Enabled = false;
                        this.tbMCardNO.Enabled = true;
                        this.cmbRebate.Enabled = false;
                    }
                    else//公费
                    {
                        this.cmbClass.Enabled = true;
                        this.cmbRebate.Enabled = false;
                        this.tbMCardNO.Enabled = true;
                    }
                    this.patientInfo.SIMainInfo.MedicalType.ID = this.cmbMZkind.Tag.ToString();
                    if (!this.IsCanModifyChargeInfo)//不可以更改挂号信息!.
                    {
                        foreach (Control c in this.Controls)
                        {
                            //输入框
                            if (c.GetType().BaseType == typeof(TextBox))
                            {
                                if (c.Text != "" && !c.Equals(this.tbCardNO))
                                {
                                    c.Enabled = false;//不能修改;
                                }
                            }
                            //下拉框
                            if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                            {
                                if (c.Text != "")
                                {
                                    c.Enabled = false;//不能修改;
                                }
                            }
                        }
                    }

                    if (this.patientInfo.Name == "")
                    {
                        this.tbName.Focus();
                    }
                    else
                    {
                        //直接收费
                        if (!this.isRecordDirectFee)
                        {
                            //如果是用快捷键选择上一次收费患者信息，焦点跳至选择科室位置
                            //否则跳到选择医生位置
                            //if (isPrRInfoSelected)
                            //{
                            //    this.cmbRegDept.Focus();
                            //    isPrRInfoSelected = false;
                            //}
                            //else
                            //{
                                this.cmbDoct.Focus();
                            //}
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        /// <summary>
        /// 清空方法
        /// </summary>
        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
            this.tbCardNO.Text = string.Empty;
            this.tbName.Text = string.Empty;
            this.cmbSex.Tag = string.Empty;
            this.cmbRegDept.Tag = string.Empty;
            this.cmbPact.SelectedIndexChanged -= new EventHandler(cmbPact_SelectedIndexChanged);
            this.cmbPact.Tag = string.Empty;
            this.cmbPact.SelectedIndexChanged += new EventHandler(cmbPact_SelectedIndexChanged);
            this.patientInfo = null;
            this.cmbDoct.Tag = string.Empty;
            this.tbAge.Text = string.Empty;
            this.tbMCardNO.Text = string.Empty;
            this.cmbClass.SelectedIndexChanged -= new EventHandler(cmbClass_SelectedIndexChanged);
            this.cmbClass.Tag = string.Empty;
            this.cmbClass.SelectedIndexChanged += new EventHandler(cmbClass_SelectedIndexChanged);
            this.cmbMZkind.SelectedIndex = 0;
            this.cmbRebate.Tag = string.Empty;
            this.fpRecipeSeq_Sheet1.RowCount = 0;
            this.tbCardNO.Focus();
            this.tbName.Enabled = true;
            lblAccount.Text = string.Empty;
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitControlParams() 
        {
            //获得卡号前补位规则
            this.noRegFlagChar = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");
            
            //是否可以更改患者基本信息
            this.isCanModifyPatientInfo = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_MODIFY_REG_INFO, false, true);

            //医生,科室输入编码是否要求全匹配
            this.isDoctDeptCorrect = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DOCT_DEPT_INPUT_CORRECT, false, false);

            //是否收费时候可以挂号医保患者
            this.isRegWhenFee = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.REG_WHEN_FEE, false, false);

            //是否默认等级编码
            this.isClassCodePre = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CLASS_CODE_PRE, false, false);

            //是否可以更改划价信息
            this.isCanModifyChargeInfo = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.MODIFY_CHARGE_INFO, false, true);

            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Init()
        {
			try
			{
                if (this.InitControlParams() == -1) 
                {
                    MessageBox.Show("初始化参数失败!");

                    return -1;
                }

                this.cmbDoct.IsListOnly = true;
                this.cmbRegDept.IsListOnly = true;
                this.cmbSex.IsListOnly = true;
                this.cmbClass.IsListOnly = true;
                this.cmbPact.IsListOnly = true;
                this.cmbSex.IsListOnly = true;
                
                //初始化 挂号科室
                this.regDeptList = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);
                if (this.regDeptList == null) 
                {
                    MessageBox.Show("初始化挂号科室出错!" + this.managerIntegrate.Err);

                    return -1;
                }

                this.cmbRegDept.AddItems(this.regDeptList);

                deptHelper.ArrayObject = this.regDeptList;

                //{D7A8536F-63EB-4378-9EE1-149BB9C872F1}根据配置xml文件,初始化可选合同单位
                InitPact();
                //{D7A8536F-63EB-4378-9EE1-149BB9C872F1}根据配置xml文件,初始化可选合同单位    结束

                //初始化优惠信息
                Neusoft.HISFC.Models.Base.Const tempConst = new Neusoft.HISFC.Models.Base.Const();
				tempConst.ID = "NO";
				tempConst.Name = "无优惠比例";
                ArrayList ecoList = new ArrayList();
                ecoList.Add(tempConst);
                this.cmbRebate.AddItems(ecoList);

				//初始化性别
				this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());

				//初始化医生列表，加入一个无归属医生。编号999
				ArrayList doctList = new ArrayList();
				doctList = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
                if (doctList == null) 
                {
                    MessageBox.Show("初始化医生列表出错!" + this.managerIntegrate.Err);

                    return -1;
                }
                Neusoft.HISFC.Models.Base.Employee pNone = new Neusoft.HISFC.Models.Base.Employee();
				pNone.ID = "999";
				pNone.Name = "无归属";
				pNone.SpellCode = "WGS";
				pNone.UserCode = "999";
				doctList.Add(pNone);
                this.cmbDoct.AddItems(doctList);
				
				this.cmbDoct.IsLike = !isDoctDeptCorrect;
				this.cmbRegDept.IsLike = !isDoctDeptCorrect;

                //初始化FP
                InputMap im;
                im = fpRecipeSeq.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                //初始化门诊类别 by xizf 20110226
                ArrayList al = managerIntegrate.GetConstantList("medicine");
                this.cmbMZkind.AddItems(al);
                this.cmbMZkind.SelectedIndex = 0;
			}					 
			catch
            {
                return -1;
            }

            return 1;
        }

        //{D7A8536F-63EB-4378-9EE1-149BB9C872F1}根据配置xml文件,初始化可选合同单位

        /// <summary>
        /// 初始化合同单位 xml文件配置参数 1 只能选择xml中维护的合同单位  2 排除xml维护的合同单位  . 其他值所有合同单位
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitPact()
        {
            //初始化合同单位
            ArrayList pactList = this.pactManager.QueryPactUnitAll();
            if (pactList == null)
            {
                MessageBox.Show("初始化合同单位出错!" + this.pactManager.Err);

                return -1;
            }

            ArrayList pactListFinal = new ArrayList();

            string fileName = Application.StartupPath + "\\Setting\\Profiles\\FeePactSetting.xml";
            
            XmlDocument xd = new XmlDocument();
            try
            {
                xd.Load(fileName);
            }
            catch (Exception ex)
            {

                xd = null;
            }
            
            if (xd != null)
            {
                XmlNode xnPactList = xd.SelectSingleNode("/setting/pactlist");
                if (xnPactList != null)
                {
                    string flag = xnPactList.Attributes["flag"].InnerText;
                    if (flag == "1")//只有以下合同单位
                    {
                        ArrayList alPact = new ArrayList();

                        foreach (XmlNode xn in xnPactList.ChildNodes)
                        {
                            alPact.Add(xn.InnerText);
                        }
                        if (alPact.Count > 0)
                        {
                            foreach (string s in alPact)
                            {
                                foreach (Neusoft.HISFC.Models.Base.PactInfo p in pactList)
                                {
                                    if (s == p.ID)
                                    {
                                        pactListFinal.Add(p);
                                    }
                                }
                            }
                        }
                        else
                        {
                            pactListFinal = pactList;
                        }
                    }
                    else if (flag == "2") //排除以下合同单位
                    {
                        ArrayList alPact = new ArrayList();

                        foreach (XmlNode xn in xnPactList.ChildNodes)
                        {
                            alPact.Add(xn.InnerText);
                        }

                        ArrayList tempPactList = new ArrayList();

                        if (alPact.Count > 0)
                        {
                            foreach (string s in alPact)
                            {
                                foreach (Neusoft.HISFC.Models.Base.PactInfo p in pactList)
                                {
                                    if (s == p.ID)
                                    {
                                        tempPactList.Add(p);
                                    }
                                }
                            }
                            foreach (Neusoft.HISFC.Models.Base.PactInfo p in tempPactList)
                            {
                                pactList.Remove(p);
                            }

                            pactListFinal = pactList;
                        }
                        else
                        {
                            pactListFinal = pactList;
                        }
                    }
                    else //所有合同单位
                    {
                        pactListFinal = pactList;
                    }
                }
            }
            else //{A84AB263-19B8-465c-BA62-3052AFC04A23}
            {
                pactListFinal = pactList;
            }

            this.cmbPact.AddItems(pactListFinal);

            return 1;
        }

        //{D7A8536F-63EB-4378-9EE1-149BB9C872F1}根据配置xml文件,初始化可选合同单位, 修改结束

        /// <summary>
        /// 变更修改信息
        /// </summary>
        public void DealModifyDetails()
        {
            if (this.modifyFeeDetails == null)
            {
                return;
            }
            ArrayList recipeSeqs = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = null;
            int currRow = this.fpRecipeSeq_Sheet1.ActiveRowIndex;
            for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
            {
                if (this.fpRecipeSeq_Sheet1.Cells[i, 0].Text == "True")
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = i.ToString();
                    obj.Memo = this.fpRecipeSeq_Sheet1.Cells[i, 3].Tag.ToString();
                    recipeSeqs.Add(obj);
                }
            }
            ArrayList sortList = new ArrayList();
            while (modifyFeeDetails.Count > 0)
            {
                ArrayList sameNotes = new ArrayList();
                FeeItemList compareItem = modifyFeeDetails[0] as FeeItemList;

                foreach (FeeItemList f in modifyFeeDetails)
                {
                    if (f.RecipeSequence == compareItem.RecipeSequence)
                    {
                        sameNotes.Add(f.Clone());
                    }
                }
                sortList.Add(sameNotes);
                foreach (FeeItemList f in sameNotes)
                {
                    for (int i = modifyFeeDetails.Count - 1; i >= 0; i--)
                    {
                        FeeItemList b = this.modifyFeeDetails[i] as FeeItemList;
                        if (f.RecipeSequence == b.RecipeSequence)
                        {
                            this.modifyFeeDetails.Remove(b);
                        }
                    }
                }

            }
            foreach (ArrayList temp in sortList)
            {
                FeeItemList fTemp = ((FeeItemList)temp[0]);
                for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
                {
                    if (this.fpRecipeSeq_Sheet1.Cells[i, 3].Tag.ToString() == fTemp.RecipeSequence)
                    {
                        this.fpRecipeSeq_Sheet1.Rows[i].Tag = temp;
                        decimal cost = 0;
                        foreach (FeeItemList f in temp)
                        {
                            cost += f.FT.OwnCost + f.FT.PayCost + f.FT.PubCost;
                        }

                        this.fpRecipeSeq_Sheet1.Cells[i, 3].Text = cost.ToString();
                        this.fpRecipeSeq_Sheet1.Rows[i].Tag = temp;

                        break;
                    }
                }
            }
            foreach (Neusoft.FrameWork.Models.NeuObject objSeq in recipeSeqs)
            {
                bool find = false;
                foreach (ArrayList temp in sortList)
                {
                    FeeItemList fTemp = ((FeeItemList)temp[0]);
                    if (fTemp.RecipeSequence == objSeq.Memo)
                    {
                        find = true;
                    }
                }
                if (!find)
                {
                    this.fpRecipeSeq_Sheet1.Rows[Convert.ToInt32(objSeq.ID)].Tag = new ArrayList();
                    this.fpRecipeSeq_Sheet1.Cells[Convert.ToInt32(objSeq.ID), 3].Text = "0.00";
                }
            }
        }

        /// <summary>
        /// 是否可以增加处方
        /// </summary>
        public void IFCanAddItem()
        {
            int currRow = this.fpRecipeSeq_Sheet1.ActiveRowIndex;
            int selectRows = 0;
            int selectRow = 0;
            for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
            {
                if (this.fpRecipeSeq_Sheet1.Cells[i, 0].Text == "True")
                {
                    selectRows++;
                }
            }
            if (selectRows > 1)
            {
                this.isCanAddItem = false;

                return;
            }
            if (selectRows == 0)
            {
                this.isCanAddItem = false;

                return;
            }
            if (selectRows == 1)
            {
                for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
                {
                    if (this.fpRecipeSeq_Sheet1.Cells[i, 0].Text == "True")
                    {
                        selectRow = i;
                    }
                }
            }

            if (selectRow != currRow)
            {
                this.isCanAddItem = false;
                return;
            }

            this.isCanAddItem = true;
        }

        /// <summary>
        /// 设置新的收费序列信息
        /// </summary>
        public void SetNewRecipeInfo()
        {
            int row = this.fpRecipeSeq_Sheet1.ActiveRowIndex;
            string deptName = this.cmbRegDept.Text;
            string deptCode = this.cmbRegDept.Tag.ToString();
            this.fpRecipeSeq_Sheet1.Cells[row, 1].Text = deptName;
            this.fpRecipeSeq_Sheet1.Cells[row, 1].Tag = deptCode;
            try
            {
                foreach (FeeItemList f in (ArrayList)fpRecipeSeq_Sheet1.Rows[row].Tag)
                {
                    ((Register)f.Patient).DoctorInfo.Templet.Dept.ID = this.cmbRegDept.Tag.ToString();
                    ((Register)f.Patient).DoctorInfo.Templet.Doct.ID = this.cmbDoct.Tag.ToString();
                    f.RecipeOper.Dept.ID = this.patientInfo.DoctorInfo.Templet.Doct.User01;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        /// <summary>
        /// 设置可以更改的挂号信息
        /// </summary>
        /// <param name="feeItemList">费用明细</param>
        /// <param name="isCanModify">true某些字段可以修该，false 某些字段不可以修改</param>
        public void SetRegInfoCanModify(FeeItemList feeItemList, bool isCanModify)
        {
            if (isCanModify)
            {
                this.cmbRegDept.Enabled = true;
                this.cmbDoct.Enabled = true;
                if (feeItemList != null)
                {
                    this.cmbRegDept.Tag = ((Register)feeItemList.Patient).DoctorInfo.Templet.Dept.ID;
                    this.cmbDoct.Tag = ((Register)feeItemList.Patient).DoctorInfo.Templet.Doct.ID;
                }

                return;
            }
            else
            {
                this.cmbRegDept.Enabled = false;
                this.cmbDoct.Enabled = false;
                this.cmbRegDept.Tag = ((Register)feeItemList.Patient).DoctorInfo.Templet.Dept.ID;
                this.cmbDoct.Tag = ((Register)feeItemList.Patient).DoctorInfo.Templet.Doct.ID;
            }
        }

        /// <summary>
        /// 增加新处方
        /// </summary>
        public void AddNewRecipe()
        {
            if (this.patientInfo == null)
            {
                return;
            }
            //增加新行
            this.fpRecipeSeq_Sheet1.Rows.Add(this.fpRecipeSeq_Sheet1.RowCount, 1);

            //得到最后一行的索引
            int row = this.fpRecipeSeq_Sheet1.RowCount - 1;

            //设置最后一行为活动行
            this.fpRecipeSeq_Sheet1.ActiveRowIndex = row;
            //设置最后一行的Tag为预定的费用明细空数组
            this.fpRecipeSeq_Sheet1.Rows[row].Tag = new ArrayList();

            for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
            {
                this.fpRecipeSeq_Sheet1.Cells[i, 0].Value = false;
                this.fpRecipeSeq_Sheet1.Cells[i, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                this.fpRecipeSeq_Sheet1.Cells[i, 1].ForeColor = Color.Black;
                this.fpRecipeSeq_Sheet1.Cells[i, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                this.fpRecipeSeq_Sheet1.Cells[i, 2].ForeColor = Color.Black;
                this.fpRecipeSeq_Sheet1.Cells[i, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                this.fpRecipeSeq_Sheet1.Cells[i, 3].ForeColor = Color.Black;
            }
            this.fpRecipeSeq_Sheet1.Cells[row, 0].Value = true;
            this.fpRecipeSeq_Sheet1.Cells[row, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
            this.fpRecipeSeq_Sheet1.Cells[row, 1].ForeColor = Color.Blue;
            this.fpRecipeSeq_Sheet1.Cells[row, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
            this.fpRecipeSeq_Sheet1.Cells[row, 2].ForeColor = Color.Blue;
            this.fpRecipeSeq_Sheet1.Cells[row, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
            this.fpRecipeSeq_Sheet1.Cells[row, 3].ForeColor = Color.Blue;
            this.fpRecipeSeq_Sheet1.Cells[row, 0].Value = true;
            this.fpRecipeSeq_Sheet1.Cells[row, 1].Text = this.cmbRegDept.Text;
            this.fpRecipeSeq_Sheet1.Cells[row, 1].Tag = this.cmbRegDept.Tag.ToString();
            this.fpRecipeSeq_Sheet1.Cells[row, 2].Text = "新开";
            this.fpRecipeSeq_Sheet1.Cells[row, 3].Text = "0.00";

            //获得临时收费序列号
            string recipeSeqTemp = this.outpatientManager.GetRecipeSequence();

            if (recipeSeqTemp == "-1" || recipeSeqTemp == null || recipeSeqTemp == string.Empty)
            {
                MessageBox.Show("获得收费序号出错!" + this.outpatientManager.Err);
                this.fpRecipeSeq_Sheet1.Rows.Remove(row, 1);

                return;
            }

            this.fpRecipeSeq_Sheet1.Cells[row, 3].Tag = recipeSeqTemp;
            this.recipeSequence = recipeSeqTemp;

            //判断是否可以增加处方
            this.IFCanAddItem();

            feeDetailsSelected = new ArrayList();

            //触发收费序列变更事件
            RecipeSeqChanged();

            if (this.patientInfo.Name == null || this.patientInfo.Name == string.Empty)
            {
                this.tbName.Focus();
            }
            else
            {
                if (this.isRecordDirectFee)
                {
                    this.cmbSex.Focus();
                }
                else
                {
                    this.cmbRegDept.Focus();
                }
            }
        }

        /// <summary>
        /// 重新获得挂号信息
        /// </summary>
        public void GetRegInfo()
        {
            if (this.patientInfo == null)
            {
                return;
            }
            this.patientInfo.DoctorInfo.Templet.Dept.ID = this.cmbRegDept.Tag.ToString();
            this.patientInfo.DoctorInfo.Templet.Dept.Name = this.cmbRegDept.Text;
            this.patientInfo.DoctorInfo.Templet.Doct.ID = this.cmbDoct.Tag.ToString();
            this.patientInfo.DoctorInfo.Templet.Doct.Name = this.cmbDoct.Text;
            this.patientInfo.Pact.ID = this.cmbPact.Tag.ToString();
            this.patientInfo.Pact.Name = this.cmbPact.Text;
            this.patientInfo.SSN = this.tbMCardNO.Text;
            try
            {
                this.patientInfo.Age = this.tbAge.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("年龄输入不合法!" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 设置挂号信息
        /// </summary>
        public void SetRegInfo()
        {
            DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();
            if (this.patientInfo == null)
            {
                return;
            }
            this.tbMCardNO.Text = this.patientInfo.SSN;
            this.tbName.Text = this.patientInfo.Name;
            this.tbAge.Text = (nowTime.Year - this.patientInfo.Birthday.Year).ToString();
            this.cmbSex.Tag = this.patientInfo.Sex.ID.ToString();
            this.patientInfo.DoctorInfo.Templet.Doct.User01 = this.doctDeptCode;

            this.cmbPact.SelectedIndexChanged -= new EventHandler(cmbPact_SelectedIndexChanged);
            this.cmbPact.Tag = this.patientInfo.Pact.ID;
            this.cmbPact.SelectedIndexChanged += new EventHandler(cmbPact_SelectedIndexChanged);
        }

        /// <summary>
        /// 验证挂号信息是否合法
        /// </summary>
        /// <returns>true合法 false不合法</returns>
        public bool IsPatientInfoValid()
        {
            if (this.cmbSex.Tag == null || this.cmbSex.Tag.ToString() == string.Empty) 
            {
                MessageBox.Show(Language.Msg("请输入性别!"));
                this.cmbSex.Focus();

                return false;
            }
            
            if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入医生!"));
                this.cmbDoct.Focus();

                return false;
            }
            if (this.tbName.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入患者姓名!"));
                this.tbName.Focus();

                return false;
            }

            string[] spChar = new string[] { "@", "#", "$", "%", "^", "&", "[", "]", "|", "'" };
            if (Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.tbName.Text, spChar).Trim() == string.Empty) 
            {
                MessageBox.Show(Language.Msg("患者姓名的存在特殊字符,并且去除字符后,无有效姓名,请重新输入!"));
                this.tbName.Focus();

                return false;
            }

            if (this.cmbRegDept.Tag == null || this.cmbRegDept.Tag.ToString() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入开方科室"));
                this.cmbRegDept.Focus();

                return false;
            }
            if (this.cmbClass.alItems.Count > 0)
            {
                if (this.cmbClass.Tag == null || this.cmbClass.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入等级编码!"));
                    this.cmbClass.Focus();

                    return false;
                }
            }
            if (this.cmbPact.Text.Trim().Length <= 0 || this.cmbPact.Tag == null)
            {
                MessageBox.Show(Language.Msg("请选择合同单位!"));
                this.cmbPact.Focus();

                return false;
            }
            if (this.patientInfo.Pact.IsNeedMCard && this.tbMCardNO.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入医疗证号!"));
                this.tbMCardNO.Text = string.Empty;
                this.tbMCardNO.Focus();

                return false;
            }

            #region 黑名单暂时屏蔽

            //if (this.patientInfo.PayKind.ID == "03" && this.patientInfo.McardID != null && this.patientInfo.McardID.Length > 0)
            //{
            //    bool isBlack = myInterface.ExistBlackList(this.patientInfo.Pact.ID, this.patientInfo.McardID);
            //    if (isBlack)
            //    {
            //        MessageBox.Show("患者已经在黑名单内,不允许收费!");
            //        this.tbMCardNo.Focus();
            //        return false;
            //    }
            //}

            #endregion

            return true;
        }

        /// <summary>
        /// 当前费用信息
        /// </summary>
        public ArrayList FeeDetails
        {
            get
            {
                return this.feeDetails;
            }
            set
            {
                this.feeDetails = value;
                //当获得患者划价保存的信息后,按照收费序列分组,默认显示第一个收费序列下的所有费用信息.
                this.SetChargeInfo();
            }
        }

        /// <summary>
        /// 选择的要收费信息
        /// </summary>
        public ArrayList FeeDetailsSelected
        {
            get
            {
                return this.feeDetailsSelected;
            }
            set
            {
                this.feeDetailsSelected = value;
            }
        }

        /// <summary>
        /// 是否可以增加项目
        /// </summary>
        public bool IsCanAddItem
        {
            get
            {
                this.IFCanAddItem();
                
                return this.isCanAddItem;
            }
            set
            {
                this.isCanAddItem = value;
            }
        }

        /// <summary>
        /// 是否可以更改划价信息
        /// </summary>
        public bool IsCanModifyChargeInfo
        {
            get
            {
                return this.isCanModifyChargeInfo;
            }
            set
            {
                this.isCanModifyChargeInfo = value;
            }
        }

        /// <summary>
        /// 是否可以更改患者基本信息
        /// </summary>
        public bool IsCanModifyPatientInfo
        {
            get
            {
                return this.isCanModifyPatientInfo;
            }
            set
            {
                this.isCanModifyPatientInfo = value;
            }
        }

        /// <summary>
        /// 是否默认等级编码
        /// </summary>
        public bool IsClassCodePre
        {
            get
            {
                return this.isClassCodePre;
            }
            set
            {
                this.isClassCodePre = value;
            }
        }

        /// <summary>
        /// 是否要求医生,科室全匹配
        /// </summary>
        public bool IsDoctDeptCorrect
        {
            get
            {
                return this.isDoctDeptCorrect;
            }
            set
            {
                this.isDoctDeptCorrect = value;
            }
        }

        /// <summary>
        /// 是否直接收费患者
        /// </summary>
        public bool IsRecordDirectFee
        {
            get
            {
                return this.isRecordDirectFee;
            }
            set
            {
                this.isRecordDirectFee = value;
            }
        }

        /// <summary>
        /// 是否医保患者收费时候同时挂号
        /// </summary>
        public bool IsRegWhenFee
        {
            get
            {
                return this.isRegWhenFee;
            }
            set
            {
                this.isRegWhenFee = value;
            }
        }

        /// <summary>
        /// 更改的费用信息
        /// </summary>
        public ArrayList ModifyFeeDetails
        {
            get
            {
                return this.modifyFeeDetails;
            }
            set
            {
                this.modifyFeeDetails = value;
            }
        }

        /// <summary>
        /// 更改年龄,优惠等,价格发生变化后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething PriceRuleChanaged;

        /// <summary>
        /// 收费序列变化后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething RecipeSeqChanged;

        /// <summary>
        /// 删除收费序列后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateRecipeDeleted RecipeSeqDeleted;

        /// <summary>
        /// 当前收费序列
        /// </summary>
        public string RecipeSequence
        {
            get
            {
                return this.recipeSequence;   
            }
            set
            {
                this.recipeSequence = value;
            }
        }

        /// <summary>
        /// 看诊科室变化后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeDoctAndDept SeeDeptChanaged;

        /// <summary>
        /// 看诊医生发生变化后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeDoctAndDept SeeDoctChanged;
        
        /// <summary>
        /// 当输入卡号有效后触发,主要为了控制显示挂号信息控件的位置。
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateEnter InputedCardAndEnter;

        /// <summary>
        /// 多张发票累计金额
        /// </summary>
        public decimal AddUpCost
        {
            set
            {
                addUpCost = value;
                this.lblAddUpCost.Text = addUpCost.ToString();
            }
            get
            {
                return addUpCost;
            }
        }
        /// <summary>
        /// 是否开始累计
        /// </summary>
        public bool IsBeginAddUpCost
        {
            get
            {
                return isBeginAddUpCost;
            }
            set
            {
                isBeginAddUpCost = value;
                if (!value)
                {
                    this.AddUpCost = 0;
                }
            }
        }
        /// <summary>
        /// 是否有累计操作
        /// </summary>
        public bool IsAddUp
        {
            set
            {
                isAddUp = value;
                if (!value)
                {
                    this.plAddUp.Visible = false;
                    this.IsBeginAddUpCost = false;
                }
            }
            get
            {
                return isAddUp ;
            }
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 得到补齐的门诊卡号
        /// </summary>
        /// <param name="input">输入的卡号</param>
        /// <returns>左填充0到10位字长的门诊卡号</returns>
        private string FillCardNO(string input)
        {
            return input.PadLeft(10, '0');
        }

        /// <summary>
        /// 切换焦点
        /// </summary>
        private void NextFocus(Control nowControl)
        {
            SendKeys.Send("{TAB}");

            foreach (Control c in this.plMain.Controls)
            {
                if (c.TabIndex > nowControl.TabIndex)
                {
                    if (c.Enabled == true && c.GetType() != typeof( Neusoft.FrameWork.WinForms.Controls.NeuSpread)
                        && (c is Neusoft.FrameWork.WinForms.Controls.NeuTextBox || c is Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                    {
                        return;
                    }
                }
            }

            this.ChangeFocus();
        }

        /// <summary>
        /// 基本验证输入的卡号是否合法
        /// </summary>
        /// <param name="cardNO">输入的卡号</param>
        /// <returns>合法返回true 不合法返回false</returns>
        private bool IsInputCardNOValid(string cardNO)
        {
            //如果输入的卡号是一个或者多个空格,那么认为没有输入.
            if (cardNO.Trim() == string.Empty)
            {
                this.tbCardNO.SelectAll();
                this.tbCardNO.Focus();

                return false;
            }
            //如果输入的卡号长度大于 1,并且不是空格.
            if (cardNO.Length >= 1)
            {
                //如果该患者是没有挂号直接收费患者,并且其他的信息已经基本录入,那么在卡号回车的时候不清空信息.直接切换到姓名输入框.
                if (this.noRegFlagChar == cardNO.Substring(0, 1) && this.patientInfo != null && this.patientInfo.ID != string.Empty && cardNO.Length == 10)
                {
                    if (this.patientInfo.PID.CardNO != cardNO)
                    {

                    }
                    else
                    {
                        this.tbName.Focus();

                        return false;
                    }
                }
            }
            return true;
        }  

        /// <summary>
        /// 获得结算类别信息
        /// </summary>
        /// <param name="pactCode">合同单位代码</param>
        /// <returns>结算类别信息, null失败</returns>
        private Neusoft.HISFC.Models.Base.PactInfo GetPactInfoByPactCode(string pactCode)
        {
            Neusoft.HISFC.Models.Base.PactInfo p = null;

            p = this.pactManager.GetPactUnitInfoByPactCode(pactCode);
            if (p == null)
            {
                MessageBox.Show("获得合同单位信息出错!" + this.pactManager.Err);

                return null;
            }

            return p;
        }

        /// <summary>
        /// 设置划价信息
        /// </summary>
        private void SetChargeInfo()
        {
            if (this.feeDetails == null)
            {
                return;
            }
            this.fpRecipeSeq_Sheet1.RowCount = 0;
            if (feeDetails.Count == 0)
            {
                this.AddNewRecipe();
                return;
            }
            ArrayList sortList = new ArrayList();
            while (feeDetails.Count > 0)
            {
                ArrayList sameNotes = new ArrayList();
                FeeItemList compareItem = feeDetails[0] as FeeItemList;
                foreach (FeeItemList f in feeDetails)
                {
                    if (f.RecipeSequence == compareItem.RecipeSequence)
                    {
                        sameNotes.Add(f);
                    }
                }
                sortList.Add(sameNotes);
                foreach (FeeItemList f in sameNotes)
                {
                    feeDetails.Remove(f);
                }
            }
            this.fpRecipeSeq_Sheet1.RowCount = 0;
            this.fpRecipeSeq_Sheet1.RowCount = sortList.Count;

            Neusoft.FrameWork.Public.ObjectHelper objHelperDept = new Neusoft.FrameWork.Public.ObjectHelper();
            objHelperDept.ArrayObject = this.regDeptList;

            for (int i = 0; i < sortList.Count; i++)
            {
                ArrayList tempSameSeqs = sortList[i] as ArrayList;
                decimal cost = 0;
                foreach (FeeItemList f in tempSameSeqs)
                {
                    cost += f.FT.OwnCost + f.FT.PayCost + f.FT.PubCost;
                }
                FeeItemList tempFeeItemRowOne = ((FeeItemList)tempSameSeqs[0]).Clone();
                this.fpRecipeSeq_Sheet1.Cells[i, 1].Text = objHelperDept.GetName(
                    ((Neusoft.HISFC.Models.Registration.Register)tempFeeItemRowOne.Patient).DoctorInfo.Templet.Dept.ID);
                this.fpRecipeSeq_Sheet1.Cells[i, 2].Text = tempFeeItemRowOne.Order.ID.Length > 0 ? "保存" : "开立";
                this.fpRecipeSeq_Sheet1.Cells[i, 3].Text = cost.ToString();
                this.fpRecipeSeq_Sheet1.Rows[i].Tag = tempSameSeqs;
                this.fpRecipeSeq_Sheet1.Cells[i, 3].Tag = tempFeeItemRowOne.RecipeSequence;
                if (i == 0)
                {
                    this.fpRecipeSeq_Sheet1.Cells[i, 0].Value = true;
                    this.fpRecipeSeq_Sheet1.Cells[0, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                    this.fpRecipeSeq_Sheet1.Cells[0, 1].ForeColor = Color.Blue;
                    this.fpRecipeSeq_Sheet1.Cells[0, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                    this.fpRecipeSeq_Sheet1.Cells[0, 2].ForeColor = Color.Blue;
                    this.fpRecipeSeq_Sheet1.Cells[0, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                    this.fpRecipeSeq_Sheet1.Cells[0, 3].ForeColor = Color.Blue;
                    this.feeDetailsSelected = new ArrayList();
                    this.recipeSequence = tempFeeItemRowOne.RecipeSequence;

                    this.feeDetailsSelected = (ArrayList)tempSameSeqs.Clone();

                    SetRegInfoCanModify(tempFeeItemRowOne, true);
                }
            }
        }

        /// <summary>
        /// 设置合同单位下类别
        /// </summary>
        private void SetRelations()
        {
            relations = this.managerIntegrate.QueryRelationsByPactCode(this.patientInfo.Pact.ID);
            //如果没有限额那么直接焦点跳转
            if (relations == null || relations.Count == 0)
            {
                this.cmbClass.ClearItems();
                this.cmbClass.Tag = string.Empty;
                this.cmbClass.alItems.Clear();
            }
            else//有限额
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                ArrayList displays = new ArrayList();
                this.cmbClass.alItems.Clear();
                foreach (Neusoft.HISFC.Models.Base.PactStatRelation p in relations)
                {

                    if (obj.ID != p.Group.ID)
                    {
                        obj = new Neusoft.FrameWork.Models.NeuObject();
                        displays.Add(obj);
                        obj.ID = p.Group.ID;
                        obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                    }
                    else
                    {
                        obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                    }
                }
                this.cmbClass.AddItems(displays);
                //如果只有一个限额,默认选择第一个.
                if (displays.Count >= 1)
                {
                    if (this.isClassCodePre)
                    {
                        this.cmbClass.SelectedIndex = 0;

                        this.patientInfo.User03 = cmbClass.Tag.ToString();
                    }
                    else
                    {
                        this.cmbClass.Tag = string.Empty;
                        this.cmbClass.Text = string.Empty;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 卡号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNO = this.tbCardNO.Text.Trim();

                if (!IsInputCardNOValid(cardNO)) 
                {
                    return;
                }

                //清空已经录入的信息.其他选择信息,重置.
                this.Clear();

                //如果输入的内容是以"/"或"+"开头则认为是收费时候后患者没有挂号
                //处理挂号业务，不通过输入的内容检索信息
                //各个内容等待操作员输入
                if (cardNO.StartsWith("/") || cardNO.StartsWith("+"))//输入方式为"/"+患者姓名，是不挂号直接输入姓名情况
                {
                    //获得门诊卡号
                    string autoCardNO = this.outpatientManager.GetAutoCardNO();
                    if (autoCardNO == string.Empty)
                    {
                        MessageBox.Show("获得门诊卡号出错!" + this.outpatientManager.Err);
                        this.tbCardNO.Focus();

                        return;
                    }

                    autoCardNO = this.noRegFlagChar + autoCardNO;

                    //获得就诊流水号
                    string clinicNO = this.outpatientManager.GetSequence("Registration.Register.ClinicID");
                    if (clinicNO == string.Empty)
                    {
                        MessageBox.Show("获得门诊就诊号出错!" + this.outpatientManager.Err);
                        this.tbCardNO.Focus();

                        return;
                    }
                    this.patientInfo = new Neusoft.HISFC.Models.Registration.Register(); //实例化挂号信息实体
                    //去掉'/'获得患者姓名
                    string name = cardNO.Remove(0, 1);
                    this.tbCardNO.Text = autoCardNO;
                    this.tbName.Text = name;
                    this.cmbSex.Tag = "M";
                    this.tbAge.Text = "20";
                    this.cmbPact.Tag = "1";
                  
                    this.isRecordDirectFee = true;
                    this.patientInfo.ID = clinicNO;
                    this.patientInfo.Name = name;
                    //this.patientInfo.Card.ID = autoCardNO;
                    this.patientInfo.PID.CardNO = autoCardNO;
                    this.patientInfo.Pact.PayKind.ID = "01";
                    this.patientInfo.Pact.ID = "1";
                    this.patientInfo.Birthday = DateTime.Now.AddYears(-20);
                    DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();
                    this.patientInfo.DoctorInfo.SeeDate = nowTime;
                    this.fpRecipeSeq_Sheet1.RowCount = 0;
                    this.AddNewRecipe();
                    lblAccount.Text = string.Empty;
                    this.isRecordDirectFee = false;
                }
                else //正常输入患者门诊卡号情况
                {
                    Neusoft.HISFC.Models.Account.AccountCard accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                    if (feeIntegrate.ValidMarkNO(cardNO, ref accountCard) > 0)
                    {
                        //decimal vacancy = 0m;
                        //if (feeIntegrate.GetAccountVacancy(accountCard.Patient.PID.CardNO, ref vacancy) > 0)
                        //{
                        //    if (isAccountTerimalFee)
                        //    {
                        //        MessageBox.Show("账户患者请去终端收费！");
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        cardNO = accountCard.Patient.PID.CardNO;
                        //    }
                        //}

                        decimal vacancy = 0m;
                        if (feeIntegrate.GetAccountVacancy(accountCard.Patient.PID.CardNO, ref vacancy) > 0)
                        {
                            lblAccount.Text = "该患者是账户患者，余额：" + vacancy.ToString();
                        }
                        else
                        {
                            lblAccount.Text = string.Empty;
                        }


                        cardNO = accountCard.Patient.PID.CardNO;
                    }

                    bool isValid = false;

                    string tmpOrgCardNo = cardNO;
                    //填充卡号到10位，左补0
                    cardNO = this.FillCardNO(cardNO);
                    this.patientInfo = new Neusoft.HISFC.Models.Registration.Register(); //实例化挂号信息实体
                    //触发显示患者信息控件
                    isValid = InputedCardAndEnter(cardNO, tmpOrgCardNo, this.tbCardNO.Location, this.tbCardNO.Height);

                    if (isValid) //如果获得的患者基本信息有效，那么跳转焦点到选择医生
                    {
                        if (this.isCanModifyPatientInfo)
                        {
                            if (this.patientInfo.DoctorInfo.Templet.Doct.ID != null && this.patientInfo.DoctorInfo.Templet.Doct.ID.Length > 0)
                            {
                                this.ChangeFocus();
                            }
                            else
                            {
                                this.cmbDoct.Focus();
                            }
                        }
                        else
                        {
                            this.NextFocus(this.tbCardNO);
                        }
                    }
                    else //如果无效卡号，那么重新输入卡号
                    {
                        this.tbCardNO.SelectAll();
                        this.tbCardNO.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// UC初始化事件,给tbCardNO分配焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPatientInfo_Load(object sender, EventArgs e)
        {
            initInputMenu();
            tbName.Enter += new EventHandler(tbName_Enter);
            readInputLanguage();
            this.tbCardNO.Focus();
            isAccountTerimalFee = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process, true, false);
        }

        void tbName_Enter(object sender, EventArgs e)
        {
            if (this.CHInput != null) InputLanguage.CurrentInputLanguage = this.CHInput;
        }
        /// <summary>
        /// 生成输入法列表
        /// </summary>
        private void initInputMenu()
        {
            plMain.ContextMenuStrip = this.neuContextMenuStrip1;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage t = InputLanguage.InstalledInputLanguages[i];
                System.Windows.Forms.ToolStripMenuItem m = new ToolStripMenuItem();
                m.Text = t.LayoutName;
                //m.Checked = true;
                m.Click += new EventHandler(m_Click);

                this.neuContextMenuStrip1.Items.Add(m);
            }
        }
        #region 输入法菜单事件
        private void m_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
            {
                if (sender == m)
                {
                    m.Checked = true;
                    this.CHInput = this.getInputLanguage(m.Text);
                    //保存输入法
                    this.saveInputLanguage();
                }
                else
                {
                    m.Checked = false;
                }
            }
        }
        /// <summary>
        /// 读取当前默认输入法
        /// </summary>
        private void readInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();

            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                this.CHInput = this.getInputLanguage(node.Attributes["currentmodel"].Value);

                if (this.CHInput != null)
                {
                    foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
                    {
                        if (m.Text == this.CHInput.LayoutName)
                        {
                            m.Checked = true;
                        }
                    }
                }

                //添加到工具栏

            }
            catch (Exception e)
            {
                MessageBox.Show("获取挂号默认中文输入法出错!" + e.Message);
                return;
            }
        }

        private void addContextToToolbar()
        {
            Neusoft.FrameWork.WinForms.Controls.NeuToolBar main = null;

            foreach (Control c in FindForm().Controls)
            {
                if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuToolBar))
                {
                    main = (Neusoft.FrameWork.WinForms.Controls.NeuToolBar)c;
                }
            }

            ToolBarButton button = null;

            if (main != null)
            {
                foreach (ToolBarButton b in main.Buttons)
                {
                    if (b.Text == "输入法") button = b;
                }
            }

            //if(button != null)
            //{
            //    ToolStripDropDownButton drop = (ToolStripDropDownButton)button;
            //    foreach(ToolStripMenuItem m in neuContextMenuStrip1.Items)
            //    {
            //        drop.DropDownItems.Add(m);
            //    }
            //}
        }

        /// <summary>
        /// 根据输入法名称获取输入法
        /// </summary>
        /// <param name="LanName"></param>
        /// <returns></returns>
        private InputLanguage getInputLanguage(string LanName)
        {
            foreach (InputLanguage input in InputLanguage.InstalledInputLanguages)
            {
                if (input.LayoutName == LanName)
                {
                    return input;
                }
            }
            return null;
        }
        /// <summary>
        /// 保存当前输入法
        /// </summary>
        private void saveInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();
            }
            if (this.CHInput == null) return;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                node.Attributes["currentmodel"].Value = this.CHInput.LayoutName;

                doc.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show("保存挂号默认中文输入法出错!" + e.Message);
                return;
            }
        }
        #endregion
        /// <summary>
        /// 医生下拉列表按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string name = this.cmbDoct.Text;
                if (name == null || name == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入医生"));
                    this.cmbDoct.Focus();

                    return;
                }

                this.cmbDoct_SelectedIndexChanged(sender, e);
                
                if (this.isCanModifyPatientInfo)
                {
                    this.cmbPact.Focus();
                }
                else
                {
                    this.NextFocus(this.cmbDoct);
                }

            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.cmbRegDept.Focus();
                this.cmbRegDept.SelectAll();
            }
        }

        /// <summary>
        /// 医生选择列表索引变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            this.patientInfo.DoctorInfo.Templet.Doct.ID = this.cmbDoct.Tag.ToString();
            this.patientInfo.DoctorInfo.Templet.Doct.Name = this.cmbDoct.Text;
            string recipeSeq = string.Empty;

            Neusoft.HISFC.Models.Base.Employee person = this.managerIntegrate.GetEmployeeInfo(this.patientInfo.DoctorInfo.Templet.Doct.ID);
            if (person == null)
            {
                MessageBox.Show("获得医生信息出错!" + managerIntegrate.Err);

                return;
            }

            bool isDoctDeptSame = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DOCT_CONFIRM_DEPT, false, true);

            if (isDoctDeptSame && this.patientInfo.PID.CardNO.Substring(0, 1) == this.noRegFlagChar) 
            {
                this.cmbRegDept.Tag = person.Dept.ID;
            }

            this.patientInfo.DoctorInfo.Templet.Doct.User01 = person.Dept.ID;

            if (this.fpRecipeSeq_Sheet1.RowCount > 0)
            {
                int row = this.fpRecipeSeq_Sheet1.ActiveRowIndex;

                //this.fpRecipeSeq_Sheet1.Cells[row, 1].Text = this.deptHelper.GetName(person.Dept.ID);//this.patientInfo.DoctorInfo.Templet.Doct.Name;
                //this.fpRecipeSeq_Sheet1.Cells[row, 1].Tag = person.Dept.ID;//this.patientInfo.DoctorInfo.Templet.Doct.ID;
                try
                {
                    foreach (FeeItemList f in (ArrayList)fpRecipeSeq_Sheet1.Rows[row].Tag)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = this.patientInfo.DoctorInfo.Templet.Doct.Clone();
                        f.RecipeOper.Dept.ID = this.patientInfo.DoctorInfo.Templet.Doct.User01.Clone().ToString();
                        recipeSeq = f.RecipeSequence;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    return;
                }

                this.SeeDoctChanged(recipeSeq, this.patientInfo.DoctorInfo.Templet.Doct.User01.Clone().ToString(), this.patientInfo.DoctorInfo.Templet.Doct.Clone());
            }
        }

        /// <summary>
        /// 看诊科室发生变化后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }

            this.patientInfo.DoctorInfo.Templet.Dept.ID = this.cmbRegDept.Tag.ToString();
            this.patientInfo.DoctorInfo.Templet.Dept.Name = this.cmbRegDept.Text;
            string recipeSeq = string.Empty;

            if (this.fpRecipeSeq_Sheet1.RowCount > 0)
            {
                int row = this.fpRecipeSeq_Sheet1.ActiveRowIndex;

                this.fpRecipeSeq_Sheet1.Cells[row, 1].Text = this.patientInfo.DoctorInfo.Templet.Dept.Name;
                this.fpRecipeSeq_Sheet1.Cells[row, 1].Tag = this.patientInfo.DoctorInfo.Templet.Dept.ID;
                try
                {
                    foreach (FeeItemList f in (ArrayList)fpRecipeSeq_Sheet1.Rows[row].Tag)
                    {
                        f.RecipeOper.Dept = this.patientInfo.DoctorInfo.Templet.Dept.Clone();
                        recipeSeq = f.RecipeSequence;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    return;
                }

                this.SeeDeptChanaged(recipeSeq, string.Empty, this.patientInfo.DoctorInfo.Templet.Dept.Clone());
            }
        }

        /// <summary>
        /// 看诊科室回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }

                string name = this.cmbRegDept.Text;

                if (name == null || name == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入看诊科室"));
                    this.cmbRegDept.Focus();

                    return;
                }
                if (this.isCanModifyPatientInfo)
                {
                    this.cmbDoct.Focus();
                }
                else
                {
                    NextFocus(this.cmbRegDept);
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.tbAge.Focus();
                this.tbAge.SelectAll();
            }
        }

        /// <summary>
        /// 合同单位回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }

                string name = this.cmbPact.Text;
                
                if (name == null || name == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入合同单位"));
                    this.cmbPact.Focus();

                    return;
                }
                if (this.cmbPact.Tag == null || this.cmbPact.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入合同单位"));
                    this.cmbPact.Focus();

                    return;
                }
                if (this.patientInfo.Pact.ID != this.cmbPact.Tag.ToString())
                {
                    this.patientInfo.Pact = this.GetPactInfoByPactCode(this.cmbPact.Tag.ToString());
                    if (this.patientInfo.Pact == null)
                    {
                        this.cmbPact.Focus();

                        return;
                    }

                    //触发合同单位变化事件
                    this.PactChanged();

                    if (this.patientInfo.Pact.PayKind.ID == "01")
                    {
                        this.tbMCardNO.Text = string.Empty;
                    }
                    //获得该合同单位下的限额
                    relations = this.managerIntegrate.QueryRelationsByPactCode(this.patientInfo.Pact.ID);
                    this.cmbClass.ClearItems();
                    this.cmbClass.Tag = string.Empty;
                    this.cmbClass.alItems.Clear();
                }
                //如果没有限额那么直接焦点跳转
                if (relations == null || relations.Count == 0)
                {
                    if (this.patientInfo.Pact.IsNeedMCard)
                    {
                        if (this.isCanModifyPatientInfo)
                        {
                            this.tbMCardNO.Focus();
                        }
                        else
                        {
                            NextFocus(this.cmbPact);
                        }
                    }
                    else
                    {
                        if (!this.IsPatientInfoValid())
                        {
                            return;
                        }
                        //触发跳转焦点事件
                        ChangeFocus();
                    }
                }
                else//有限额
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    ArrayList displays = new ArrayList();
                    foreach (Neusoft.HISFC.Models.Base.PactStatRelation p in relations)
                    {

                        if (obj.ID != p.Group.ID)
                        {
                            obj = new Neusoft.FrameWork.Models.NeuObject();
                            displays.Add(obj);
                            obj.ID = p.Group.ID;
                            obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                        }
                        else
                        {
                            obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                        }
                    }
                    if (this.patientInfo.Pact.ID != this.cmbPact.Tag.ToString())
                    {
                        this.cmbClass.AddItems(displays);
                    }
                    //如果只有一个限额,默认选择第一个.
                    if (displays.Count >= 1)
                    {
                        if (this.isClassCodePre)
                        {
                            if (this.patientInfo.Pact.ID != this.cmbPact.Tag.ToString())
                            {
                                this.cmbClass.SelectedIndex = 0;
                            }

                            if (this.cmbClass.Tag == null || this.cmbClass.Tag.ToString() == string.Empty)
                            {
                                MessageBox.Show(Language.Msg("请输入等级编码"));
                                this.cmbClass.Focus();

                                return;
                            }
                            this.patientInfo.User03 = this.cmbClass.Tag.ToString();
                        }
                        else
                        {
                            this.cmbClass.Tag = string.Empty;
                            this.cmbClass.Text = string.Empty;
                        }
                    }
                   
                    if (this.patientInfo.Pact.IsNeedMCard)
                    {
                        if (this.isCanModifyPatientInfo)
                        {
                            NextFocus(this.cmbClass);
                        }
                        else
                        {
                            NextFocus(this.cmbClass);
                        }
                    }
                    else 
                    {
                        this.ChangeFocus();
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.cmbDoct.Focus();
                this.cmbDoct.SelectAll();
            }
        }

        /// <summary>
        /// 合同单位切换索引事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            //处理合同单位被删除，再重新选择合同单位时未将对象引用实例
            //{7E761CF9-3F36-4c28-A6AD-AAFBA9114AB6}
            try
            {
                this.patientInfo.Pact.ID = this.cmbPact.Tag.ToString();
                this.patientInfo.Pact.Name = this.cmbPact.Text;
                this.patientInfo.SIMainInfo.MedicalType.ID = this.cmbMZkind.Tag.ToString();
            }
            catch { }

            this.patientInfo.Pact = this.GetPactInfoByPactCode(this.cmbPact.Tag.ToString());
            if (this.patientInfo.Pact == null)
            {
                this.cmbPact.Focus();

                return;
            }

            if (this.patientInfo.Pact.PayKind.ID == "01")//自费
            {
                this.cmbClass.Enabled = false;
                this.tbMCardNO.Enabled = false;
                this.cmbRebate.Enabled = false;
                this.tbMCardNO.Text = string.Empty;
            }
            else if (this.patientInfo.Pact.PayKind.ID == "02")//医保
            {
                this.cmbClass.Enabled = false;
                this.tbMCardNO.Enabled = true;
                this.cmbRebate.Enabled = false;

                this.cmbRebate.SelectedIndexChanged -= new EventHandler(cmbRebate_SelectedIndexChanged);
                this.cmbRebate.Tag = string.Empty;
                this.cmbRebate.Text = string.Empty;
                this.cmbRebate.SelectedIndexChanged += new EventHandler(cmbRebate_SelectedIndexChanged);

                #region 医保患者没有挂号时在收费时自动登记

                if (this.isRegWhenFee)
                {
                    bool iResult = true;
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.interfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    this.interfaceProxy.SetPactCode(this.patientInfo.Pact.ID);

                    if (this.interfaceProxy.Connect() == -1) 
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.interfaceProxy.Rollback();
                        MessageBox.Show("连接医保出错!" + this.interfaceProxy.ErrMsg);
                        iResult = false;
                    }

                    //科室为空不可以
                    if (this.patientInfo.DoctorInfo.Templet.Dept.ID == null || this.patientInfo.DoctorInfo.Templet.Dept.ID == string.Empty)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.interfaceProxy.Rollback();
                        MessageBox.Show(Language.Msg("挂号科室不能为空！"));
                        iResult = false;
                    }

                    //{3676F424-0B1E-479b-9ABB-11D3B25AC8AE} 如果上面出错就不执行医保挂号By GXLei
                    if (iResult)
                    {
                        //获取医保登记信息
                        if (this.interfaceProxy.GetRegInfoOutpatient(this.patientInfo) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.interfaceProxy.Rollback();
                            MessageBox.Show(interfaceProxy.ErrMsg);
                            iResult = false;
                        }
                    }
                    //{FFF43E1D-C9D6-4cfa-9A38-D0C619A486C3} 医保患者直接挂号By GXLei
                    if (iResult)
                    {
                        if (this.interfaceProxy.UploadRegInfoOutpatient(this.patientInfo) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.interfaceProxy.Rollback();
                            MessageBox.Show(interfaceProxy.ErrMsg);
                            iResult = false;
                        }
                    }

                    //断开连接
                    if (this.interfaceProxy.Disconnect() != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.interfaceProxy.Rollback();
                        MessageBox.Show(interfaceProxy.ErrMsg);
                        iResult = false;
                    }
                    if (iResult)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        interfaceProxy.Commit();

                        this.SetRegInfo();
                    }
                }

                #endregion
            }
            else//公费
            {
                this.cmbClass.Enabled = true;
                this.tbMCardNO.Enabled = true;
                this.cmbRebate.Enabled = false;
                this.cmbRebate.SelectedIndexChanged -= new EventHandler(cmbRebate_SelectedIndexChanged);
                this.cmbRebate.Tag = string.Empty;
                this.cmbRebate.Text = string.Empty;
                this.cmbRebate.SelectedIndexChanged += new EventHandler(cmbRebate_SelectedIndexChanged);
            }

            //触发合同单位事件
            this.PactChanged();
            relations = this.managerIntegrate.QueryRelationsByPactCode(this.patientInfo.Pact.ID);
            //如果没有限额那么直接焦点跳转
            if (relations == null || relations.Count == 0)
            {
                cmbClass.ClearItems();
                cmbClass.Tag = string.Empty;
                cmbClass.alItems.Clear();
            }
            else//有限额
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                ArrayList displays = new ArrayList();
                cmbClass.alItems.Clear();
                foreach (Neusoft.HISFC.Models.Base.PactStatRelation p in relations)
                {

                    if (obj.ID != p.Group.ID)
                    {
                        obj = new Neusoft.FrameWork.Models.NeuObject();
                        displays.Add(obj);
                        obj.ID = p.Group.ID;
                        obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                    }
                    else
                    {
                        obj.Name += p.StatClass.Name + ": " + p.Quota.ToString() + " ";
                    }
                }
                this.cmbClass.AddItems(displays);
                //如果只有一个限额,默认选择第一个.
                if (displays.Count >= 1)
                {
                    if (this.isClassCodePre)
                    {
                        this.cmbClass.SelectedIndex = 0;
                        
                        this.patientInfo.User03 = cmbClass.Tag.ToString();
                    }
                    else
                    {
                        this.cmbClass.Tag = string.Empty;
                        this.cmbClass.Text = string.Empty;
                    }
                }
            }
            this.PriceRuleChanaged();
        }

        /// <summary>
        /// 优惠发生变化触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRebate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            
            this.patientInfo.Pact = this.GetPactInfoByPactCode(this.cmbPact.Tag.ToString());
            if (this.patientInfo.Pact == null)
            {
                this.cmbPact.Focus();

                return;
            }
         
            this.patientInfo.User03 = this.cmbClass.Tag.ToString();
            this.patientInfo.User02 = this.cmbRebate.Tag.ToString();

            this.PactChanged();
        }

        /// <summary>
        /// 医疗证号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }
                if (this.patientInfo.Pact.IsNeedMCard)
                {
                    if (this.tbMCardNO.Text == string.Empty)
                    {
                        MessageBox.Show(Language.Msg("请输入医疗证号"));
                        this.tbMCardNO.Focus();

                        return;
                    }
                    else
                    {
                        this.patientInfo.SSN = this.tbMCardNO.Text.Trim();

                        if (!this.IsPatientInfoValid())
                        {
                            return;
                        }

                        ChangeFocus();
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.cmbClass.Focus();
                this.cmbClass.SelectAll();
            }
        }

        /// <summary>
        /// 合同单位下类别发生变化的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            this.patientInfo.Pact = this.GetPactInfoByPactCode(this.cmbPact.Tag.ToString());
            if (this.patientInfo.Pact == null)
            {
                this.cmbPact.Focus();

                return;
            }
           
            this.patientInfo.User03 = cmbClass.Tag.ToString();

            this.PactChanged();
        }

        /// <summary>
        /// 合同单位下类别回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }
                string name = this.cmbClass.Text;

                if (this.cmbClass.alItems.Count > 0)
                {
                    if (name == null || name == string.Empty)
                    {
                        MessageBox.Show(Language.Msg("请输入等级编码"));
                        this.cmbClass.Focus();

                        return;
                    }
                    if (this.cmbClass.Tag == null || this.cmbClass.Tag.ToString() == string.Empty)
                    {
                        MessageBox.Show(Language.Msg("请输入等级编码"));
                        this.cmbClass.Focus();

                        return;
                    }
                    this.patientInfo.User03 = cmbClass.Tag.ToString();
                    this.cmbClass.Text = cmbClass.Tag.ToString();
                }

                if (this.patientInfo.Pact.IsNeedMCard)
                {
                    if (this.isCanModifyPatientInfo)
                    {
                        this.tbMCardNO.Focus();
                    }
                    else
                    {
                        NextFocus(this.cmbClass);
                    }
                }
                else
                {
                    if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty)
                    {
                        MessageBox.Show(Language.Msg("请输入医生!"));
                        this.cmbDoct.Focus();

                        return;
                    }
                    else
                    {
                        //触发跳转焦点事件
                        if (!this.IsPatientInfoValid())
                        {
                            return;
                        }
                        ChangeFocus();
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.cmbPact.Focus();
                this.cmbPact.SelectAll();
            }
        }

        /// <summary>
        /// 点击换单控件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpRecipeSeq_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == 0)//点击选择框
            {
                if (this.fpRecipeSeq_Sheet1.RowCount <= 1)
                {
                    this.fpRecipeSeq_Sheet1.Cells[0, 0].Value = true;

                    return;
                }
                this.fpRecipeSeq.StopCellEditing();
                ArrayList selectedItems = new ArrayList();
                this.feeDetailsSelected = new ArrayList();
                this.fpRecipeSeq_Sheet1.ActiveRowIndex = e.Row;

                for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
                {
                    if (this.fpRecipeSeq_Sheet1.Cells[i, 0].Text.ToString() == "True")
                    {
                        selectedItems.Add(this.fpRecipeSeq_Sheet1.Rows[i].Tag);
                    }
                    this.fpRecipeSeq_Sheet1.Cells[i, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 1].ForeColor = Color.Black;
                    this.fpRecipeSeq_Sheet1.Cells[i, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 2].ForeColor = Color.Black;
                    this.fpRecipeSeq_Sheet1.Cells[i, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 3].ForeColor = Color.Black;
                }
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 2].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].ForeColor = Color.Blue;
                foreach (ArrayList al in selectedItems)
                {
                    foreach (FeeItemList f in al)
                    {
                        this.feeDetailsSelected.Add(f);
                    }
                }
                ArrayList alTemp = new ArrayList();
                alTemp = (ArrayList)this.fpRecipeSeq_Sheet1.Rows[e.Row].Tag;
                if (alTemp.Count > 0)
                {
                    SetRegInfoCanModify(((FeeItemList)alTemp[0]), true);
                }
                else
                {
                    //{F132172F-59C0-40cc-ACCA-DA3362D53689}
                    if (this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Tag != null)
                    {
                        this.cmbRegDept.Tag = this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Tag.ToString();
                    }
                    this.cmbDoct.Tag = null;
                }
                this.recipeSequence = this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].Tag.ToString();
                this.IFCanAddItem();
                this.RecipeSeqChanged();
            }
        }

        /// <summary>
        /// 单击换单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpRecipeSeq_CellClick(object sender, CellClickEventArgs e)
        {
            if (this.fpRecipeSeq_Sheet1.RowCount == 0)
            {
                return;
            }
            this.fpRecipeSeq_Sheet1.ActiveRowIndex = e.Row;
            if (e.Column != 0)
            {
                for (int i = 0; i < this.fpRecipeSeq_Sheet1.RowCount; i++)
                {
                    this.fpRecipeSeq_Sheet1.Cells[i, 0].Value = false;
                    this.fpRecipeSeq_Sheet1.Cells[i, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 1].ForeColor = Color.Black;
                    this.fpRecipeSeq_Sheet1.Cells[i, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 2].ForeColor = Color.Black;
                    this.fpRecipeSeq_Sheet1.Cells[i, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    this.fpRecipeSeq_Sheet1.Cells[i, 3].ForeColor = Color.Black;
                }
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 0].Value = true;
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 2].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].ForeColor = Color.Blue;


                this.feeDetailsSelected = new ArrayList();
                this.feeDetailsSelected = (ArrayList)this.fpRecipeSeq_Sheet1.Rows[e.Row].Tag;
                if (this.feeDetailsSelected.Count > 0)
                {
                    this.SetRegInfoCanModify(((FeeItemList)feeDetailsSelected[0]), true);
                }
                else
                {
                    //{F132172F-59C0-40cc-ACCA-DA3362D53689}
                    if (this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Tag != null)
                    {
                        this.cmbRegDept.Tag = this.fpRecipeSeq_Sheet1.Cells[e.Row, 1].Tag.ToString();
                    }
                    this.cmbDoct.Tag = null;
                }
                this.recipeSequence = this.fpRecipeSeq_Sheet1.Cells[e.Row, 3].Tag.ToString();
                this.IFCanAddItem();
                this.RecipeSeqChanged();
                this.cmbRegDept.Focus();
            }
        }

        /// <summary>
        /// 点击菜单的添加选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.AddNewRecipe();
        }

        /// <summary>
        /// 点击菜单的删除选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (this.fpRecipeSeq_Sheet1.RowCount == 0)
            {
                return;
            }
            int row = this.fpRecipeSeq_Sheet1.ActiveRowIndex;
            string deptName = this.fpRecipeSeq_Sheet1.Cells[row, 1].Text;
            string tempFlag = this.fpRecipeSeq_Sheet1.Cells[row, 2].Text;
            DialogResult result = MessageBox.Show("是否删除" + deptName + "的" + tempFlag + "处方信息?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (RecipeSeqDeleted((ArrayList)this.fpRecipeSeq_Sheet1.Rows[row].Tag) == -1)
                {
                    return;
                }
                this.fpRecipeSeq_Sheet1.Rows.Remove(row, 1);
            }
            if (this.fpRecipeSeq_Sheet1.RowCount == 1)//只有一行的时候默认选中!
            {
                this.fpRecipeSeq_Sheet1.ActiveRowIndex = 0;

                this.fpRecipeSeq_Sheet1.Cells[0, 0].Value = true;
                this.fpRecipeSeq_Sheet1.Cells[0, 1].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[0, 1].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[0, 2].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[0, 2].ForeColor = Color.Blue;
                this.fpRecipeSeq_Sheet1.Cells[0, 3].Font = new Font("宋体", 9, System.Drawing.FontStyle.Bold);
                this.fpRecipeSeq_Sheet1.Cells[0, 3].ForeColor = Color.Blue;

                this.feeDetailsSelected = new ArrayList();
                feeDetailsSelected = (ArrayList)this.fpRecipeSeq_Sheet1.Rows[0].Tag;
                if (this.feeDetailsSelected.Count > 0)
                {
                    this.SetRegInfoCanModify(((FeeItemList)feeDetailsSelected[0]), true);
                }
                else
                {
                    this.cmbRegDept.Tag = this.fpRecipeSeq_Sheet1.Cells[0, 1].Tag.ToString();
                    this.cmbDoct.Tag = null;
                }
                this.recipeSequence = this.fpRecipeSeq_Sheet1.Cells[0, 3].Tag.ToString();
                this.RecipeSeqChanged();
                this.cmbRegDept.Focus();

            }
            if (this.fpRecipeSeq_Sheet1.RowCount == 0)
            {
                this.AddNewRecipe();
            }
        }

        /// <summary>
        /// 根据是否可以更改划价信息参数,控制菜单的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuContexMenu1_Popup(object sender, EventArgs e)
        {
            if (!this.isCanModifyChargeInfo)//不可以修改
            {
                this.menuItem2.Enabled = false;
            }
            else
            {
                this.menuItem2.Enabled = true; ;
            }
        }

        /// <summary>
        /// 姓名回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null || (this.patientInfo.ID != null && this.patientInfo.ID.Length <= 0))
                {
                    return;
                }
                if (this.tbName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(Language.Msg("请输入姓名!"));
                    this.tbName.Focus();

                    return;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbName.Text, 40))
                {
                    MessageBox.Show(Language.Msg("姓名输入过长!"));
                    this.tbName.SelectAll();
                    this.tbName.Focus();

                    return;
                }
                this.patientInfo.Name = this.tbName.Text;
                if (this.isCanModifyPatientInfo)
                {
                    NextFocus(this.tbName);
                }
                else
                {
                    this.cmbSex.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.tbCardNO.Focus();
                this.tbCardNO.SelectAll();
            }
        }

        /// <summary>
        /// 性别回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }
                if (this.cmbSex.Text == "男")
                {
                    this.patientInfo.Sex.ID = "M";
                }
                else if (this.cmbSex.Text == "女")
                {
                    this.patientInfo.Sex.ID = "F";
                }
                else
                {
                    this.patientInfo.Sex.ID = "U";
                }

                if (this.isCanModifyPatientInfo)
                {
                    NextFocus(this.cmbSex);
                }
                else
                {
                    this.tbAge.Focus();
                }

            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.tbName.Focus();
                this.tbName.SelectAll();
            }
        }

        /// <summary>
        /// 年龄回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }
                int age = 0;
                try
                {
                    age = Neusoft.FrameWork.Function.NConvert.ToInt32(this.tbAge.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg("年龄输入不合法!") + ex.Message);
                    this.tbAge.Focus();
                    this.tbAge.SelectAll();

                    return;
                }
                if (age < 0)
                {
                    MessageBox.Show(Language.Msg("年龄不能小于0"));
                    this.tbAge.Focus();
                    this.tbAge.SelectAll();

                    return;
                }
                if (age > 300)
                {
                    MessageBox.Show(Language.Msg("年龄不能大于300"));
                    this.tbAge.Focus();
                    this.tbAge.SelectAll();

                    return;
                }
                this.patientInfo.Birthday = this.outpatientManager.GetDateTimeFromSysDateTime().AddYears(-age);

                if (this.isCanModifyPatientInfo)
                {
                    this.cmbRegDept.Focus();
                }
                else
                {
                    NextFocus(this.tbAge);
                }

                this.PriceRuleChanaged();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.cmbSex.Focus();
                this.cmbSex.SelectAll();
            }
        }

        /// <summary>
        /// 离开姓名输入框触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            //if (this.patientInfo == null || (this.patientInfo.ID != null && this.patientInfo.ID.Length <= 0))
            //{
            //    return;
            //}
            //if (this.tbName.Text == string.Empty)
            //{
            //    MessageBox.Show(Language.Msg("请输入姓名!"));
            //    this.tbName.Focus();

            //    return;
            //}
            //if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbName.Text, 40))
            //{
            //    MessageBox.Show(Language.Msg("姓名输入过长!"));
            //    this.tbName.SelectAll();
            //    this.tbName.Focus();

            //    return;
            //}
            //this.patientInfo.Name = this.tbName.Text;
        }

        /// <summary>
        /// 优惠回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRebate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                this.tbMCardNO.Focus();
                this.tbMCardNO.SelectAll();
            }
        }

        #endregion

        #region IOutpatientInfomation 成员


        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateNameEnter NameEnter;

        #endregion

        #region {9C258D4F-9443-45bc-8987-B2E99A641E82} 收费处读卡 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        private bool ICInit = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            this.Clear();
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.tbCardNO.Text = cardno;
                    this.tbCardNO_KeyDown(this.tbCardNO, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                this.btnReadCard_Click(this.btnReadCard, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void cmbMZkind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            this.patientInfo.SIMainInfo.MedicalType.ID = this.cmbMZkind.Tag.ToString();
        }

        private void cmbMZkind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.patientInfo == null)
                {
                    return;
                }
                this.PactChanged();
            }
        }
    }
}
