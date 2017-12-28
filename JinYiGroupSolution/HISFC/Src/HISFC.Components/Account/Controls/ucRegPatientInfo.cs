using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;
using System.Xml;
using System.Collections;
using Neusoft.HISFC.BizLogic.Fee;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucRegPatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucRegPatientInfo()
        {
            InitializeComponent();
        }

        #region 自定义事件

        /// <summary>
        /// 当焦点进入ComBox时处罚的事件
        /// </summary>
        public event HandledEventHandler CmbFoucs;

        /// <summary>
        /// 当当前UC焦点到达最后一个时发生的事件
        /// </summary>
        public event HandledEventHandler OnFoucsOver;

        /// <summary>
        /// 在输入患者信息回车时查找患者信息
        /// </summary>
        public event HandledEventHandler OnEnterSelectPatient;

        #endregion

        #region 变量

        #region 业务层变量
        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 门诊费用业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// Acount业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 入出转
        /// </summary>
        private HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        private PactUnitInfo pactManager = new PactUnitInfo();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
 
        #endregion

        #region 变量

        /// <summary>
        /// 婚姻状态实体
        /// </summary>
        HISFC.Models.RADT.MaritalStatusEnumService maritalService = new Neusoft.HISFC.Models.RADT.MaritalStatusEnumService();

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;

        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNO = string.Empty;

        /// <summary>
        /// 民族
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper NationHelp = null;

        /// <summary>
        /// 证件类型
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper IdCardTypeHelp = null;

        /// <summary>
        /// 是否急诊
        /// </summary>
        private bool isTreatment = false;

        /// <summary>
        /// MPI接口
        /// </summary>
        //Neusoft.HISFC.BizProcess.Interface.Platform.IEmpiCommutative iEmpi = null;


        /// <summary>
        /// 数据是否只在本地处理，不往数据中心发送
        /// {BCE8D830-5FEA-4681-A08A-4BB48D172E20}
        /// </summary>
        private bool isLocalOperation = true;

        private string mcardNO = string.Empty;

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 输入卡的类别 0或空表示用就诊卡号做物理卡号  不等于0为多卡
        /// </summary>
        private bool cardWay = false;

        #endregion

        #region 输入控制变量

        #region 必须录入项目
        /// <summary>
        /// 是否必须输入姓名
        /// </summary>
        private bool isInputName = true;

        /// <summary>
        /// 是否必须输入性别
        /// </summary>
        private bool isInputSex = false;

        /// <summary>
        /// 是否必须输入合同单位
        /// </summary>
        private bool isInputPact = false;

        /// <summary>
        /// 是否必须输入医保证号
        /// </summary>
        private bool isInputSiNo = false;

        /// <summary>
        /// 是否必须输入出生日期
        /// </summary>
        private bool isInputBirthDay = false;

        /// <summary>
        /// 是否必须输入证件类型
        /// </summary>
        private bool isInputIDEType = false;

        /// <summary>
        /// 是否必须输入证件号
        /// </summary>
        private bool isInputIDENO = false;

        #endregion

        #region 是否可以修改
        /// <summary>
        /// 费用来源是否可以修改
        /// </summary>
        private bool isEnablePact = true;

        /// <summary>
        /// 医保证号是否可以修改
        /// </summary>
        private bool isEnableSiNO = true;

        /// <summary>
        /// 是否可以修改证件类型
        /// </summary>
        private bool isEnableIDEType = true;

        /// <summary>
        /// 是否可以修改证件号
        /// </summary>
        private bool isEnableIDENO = true;

        /// <summary>
        /// Vip是否可用
        /// </summary>
        private bool isEnableVip = true;

        /// <summary>
        /// 姓名加密是否可用
        /// </summary>
        private bool isEnableEntry = true;
        #endregion

        /// <summary>
        /// 必须录入控件
        /// </summary>
        private Hashtable InputHasTable = new Hashtable();

        /// <summary>
        /// 是否可以修改控件
        /// </summary>
        private List<Control> EnableControlList = new List<Control>();

        /// <summary>
        /// 是否按照必录项跳转输入焦点
        /// </summary>
        private bool isMustInputTabInde = false;

        /// <summary>
        /// 必须输入控件最大TabIndex
        /// </summary>
        int inpubMaxTabIndex = 0;

        ///// <summary>
        ///// 病案科室配置路径
        ///// </summary>
        //string filePath = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/CasDeptDefaultValue.xml"; 
        #endregion

        #endregion

        #region 属性
        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNO
        {
            set
            {
                if (this.DesignMode) return;
                cardNO = value;
                if (value != string.Empty)
                {
                    SetInfo(cardNO);
                }
            }
            get
            {
                return cardNO;
            }
        }

        //物理就诊卡号
        public string McardNO
        {
            get { return mcardNO; }
            set { mcardNO = value; }
        }

        [Category("控件设置"), Description("是否急诊发卡 True:是 false:否")]
        public bool IsTreatment
        {
            get { return isTreatment; }
            set { isTreatment = value; }
        }

        [Category("控件设置"), Description("是否按照必录项跳转输入焦点")]
        public bool IsMustInputTabIndex
        {
            get
            {
                return isMustInputTabInde;
            }
            set
            {
                isMustInputTabInde = value;
            }
        }

        /// <summary>
        /// 数据是否只在本地处理，不往数据中心发送
        /// {BCE8D830-5FEA-4681-A08A-4BB48D172E20}
        /// </summary>
        public bool IsLocalOperation
        {
            get
            {
                return isLocalOperation;
            }
            set
            {
                isLocalOperation = value;
            }
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        [Category("控件设置"), Description("false:就诊卡号做物理卡号 true:就诊卡号与物理卡号不同")]
        public bool CardWay
        {
            get
            {
                return cardWay;
            }
            set
            {
                cardWay = value;
            }
        }

        #region 输入控制属性
        [Category("控件设置"), Description("姓名是否必须输入！")]
        public bool IsInputName
        {
            get
            {
                return isInputName;
            }
            set
            {
                isInputName = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblName, this.txtName, value);
            }
        }

        [Category("控件设置"), Description("性别是否必须输入！")]
        public bool IsInputSex
        {
            get
            {
                return isInputSex;
            }
            set
            {
                isInputSex = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblSex, this.cmbSex, value);
            }
        }

        [Category("控件设置"), Description("合同单位是否必须输入！")]
        public bool IsInputPact
        {
            get
            {
                return isInputPact;
            }
            set
            {
                isInputPact = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblPact, this.cmbPact, value);
            }
        }

        [Category("控件设置"), Description("医保证号是否必须输入！")]
        public bool IsInputSiNo
        {
            get { return isInputSiNo; }
            set
            {
                isInputSiNo = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblSiNO, this.txtSiNO, value);
            }
        }

        [Category("控件设置"), Description("出生日期是否必须输入！")]
        public bool IsInputBirthDay
        {
            get { return isInputBirthDay; }
            set
            {
                isInputBirthDay = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblBirthDay, this.dtpBirthDay, value);
            }
        }

        [Category("控件设置"), Description("证件类型是否必须输入！")]
        public bool IsInputIDEType
        {
            get { return isInputIDEType; }
            set
            {
                isInputIDEType = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblCardType, this.cmbCardType, value);
            }
        }

        [Category("控件设置"), Description("证件号是否必须输入！")]
        public bool IsInputIDENO
        {
            get { return isInputIDENO; }
            set
            {
                isInputIDENO = value;
                this.AddOrRemoveUnitAtMustInputLists(this.lblIDNO, this.txtIDNO, value);
            }
        }
        #endregion

        #region 是否可以修改控制
        [Category("修改控制"), Description("费用来源是否可以修改")]
        public bool IsEnablePact
        {
            get { return isEnablePact; }
            set
            {
                isEnablePact = value;
                AddOrRemoveUnitAtEnableLists(this.cmbPact, value);
            }
        }

        [Category("修改控制"), Description("医保证号是否可以修改")]
        public bool IsEnableSiNO
        {
            get { return isEnableSiNO; }
            set
            {
                isEnableSiNO = value;
                AddOrRemoveUnitAtEnableLists(this.txtSiNO, value);
            }
        }

        [Category("修改控制"), Description("是否可以修改证件类型")]
        public bool IsEnableIDEType
        {
            get { return isEnableIDEType; }
            set
            {
                isEnableIDEType = value;
                AddOrRemoveUnitAtEnableLists(this.cmbCardType, value);
            }
        }

        [Category("修改控制"), Description("是否可以修改证件号")]
        public bool IsEnableIDENO
        {
            get { return isEnableIDENO; }
            set
            {
                isEnableIDENO = value;
                AddOrRemoveUnitAtEnableLists(this.txtIDNO, value);
            }
        }

        [Category("修改控制"), Description("是否可以修改Vip标识")]
        public bool IsEnableVip
        {
            get
            {
                return isEnableVip;
            }
            set
            {
                isEnableVip = value;
                AddOrRemoveUnitAtEnableLists(this.ckVip, value);
            }
        }

        [Category("修改控制"), Description("患者姓名加密是否可以修改")]
        public bool IsEnableEntry
        {
            get
            {
                return isEnableEntry;
            }
            set
            {
                isEnableEntry = value;
                AddOrRemoveUnitAtEnableLists(this.ckEncrypt, value);
            }
        }

        public bool IsShowTitle
        {
            set
            {
                lblshow.Visible = value;
            }
            get
            {
                return lblshow.Visible;
            }
        }
        #endregion

        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            try
            {
                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
                this.cmbSex.Text = "男";

                //民族
                this.cmbNation.AddItems(managerIntegrate.GetConstantList(EnumConstant.NATION));
                this.cmbNation.Text = "汉族";
                NationHelp = new Neusoft.FrameWork.Public.ObjectHelper(this.cmbNation.alItems);
                //婚姻状态
                this.cmbMarry.AddItems(HISFC.Models.RADT.MaritalStatusEnumService.List());

                //国家
                this.cmbCountry.AddItems(managerIntegrate.GetConstantList(EnumConstant.COUNTRY));
                this.cmbCountry.Text = "中国";

                //职业信息
                this.cmbProfession.AddItems(managerIntegrate.GetConstantList(EnumConstant.PROFESSION));

                //工作单位
                this.cmbWorkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.WORKNAME));

                //联系人信息
                this.cmbRelation.AddItems(managerIntegrate.GetConstantList(EnumConstant.RELATIVE));

                //联系人地址信息
                this.cmbLinkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //家庭住址信息
                this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //籍贯
                this.cmbDistrict.AddItems(managerIntegrate.GetConstantList(EnumConstant.DIST));

                //生日
                this.dtpBirthDay.Value = this.accountManager.GetDateTimeFromSysDateTime();//出生日期

                //地区
                this.cmbArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
                //this.cmbPact.AddItems(managerIntegrate.GetConstantList(EnumConstant.PACTUNIT));
                this.cmbPact.AddItems(managerIntegrate.QueryPactUnitAll());
                this.cmbPact.Tag = "1";
                //this.cmbPact.Text = "现金";
                //证件类型
                this.cmbCardType.AddItems(managerIntegrate.QueryConstantList("IDCard"));
                IdCardTypeHelp = new Neusoft.FrameWork.Public.ObjectHelper(this.cmbCardType.alItems);

                Neusoft.FrameWork.Management.ControlParam ctlParam = new Neusoft.FrameWork.Management.ControlParam();

                //取卡规则 0 表示用病历号做卡号
                string returnValue = ctlParam.QueryControlerInfo("800006");

                if (string.IsNullOrEmpty(returnValue))
                {
                    returnValue = "0";
                }

                this.McardNO = returnValue;
                CmbEvent();
                SetInputMenu();
                

                //MPI接口{BCE8D830-5FEA-4681-A08A-4BB48D172E20}
                //this.iEmpi = Neusoft.HISFC.BizProcess.Integrate.PlatformInstance.GetIEmpiInstance();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="cardno">门诊卡号</param>
        private void SetInfo(string cardno)
        {
            if (cardno == string.Empty || cardno == null) return;
            this.patientInfo = radtManager.QueryComPatientInfo(cardno);
            //集成平台 嵌入主索引{BCE8D830-5FEA-4681-A08A-4BB48D172E20} 
            if (this.patientInfo == null && isLocalOperation == false)
            {
                //if (iEmpi != null )
                //{
                //    this.patientInfo = iEmpi.GetBasePatientinfo(Neusoft.HISFC.BizProcess.Interface.Platform.HisDomain.Outpatient, cardno);                    
                //}
            }

            if (this.patientInfo != null)
            {
                SetPatient();
            }
            else
            {
                this.Clear();
            }
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// 
        private void SetPatient()
        {
            //modify by sung 2009-2-24 {DCAA485E-753C-41ed-ABCF-ECE46CD41B33}
            if (this.patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.txtName.Text = patientInfo.Name;//患者姓名

            //this.txtName.Text = this.patientInfo.Name;               //姓名
            //if (this.patientInfo.IsEncrypt)
            //{

            //    this.txtName.Tag = this.patientInfo.DecryptName;         //真实姓名                  
            //}
            //else
            //{
            //    this.txtName.Tag = null;
            //}
            this.cmbSex.Text = this.patientInfo.Sex.Name;            //性别
            this.cmbSex.Tag = this.patientInfo.Sex.ID;               //性别
            this.cmbPact.Text = this.patientInfo.Pact.Name;          //合同单位名称
            this.cmbPact.Tag = this.patientInfo.Pact.ID;             //合同单位ID
            this.cmbArea.Tag = this.patientInfo.AreaCode;            //地区
            this.cmbCountry.Tag = this.patientInfo.Country.ID;       //国籍
            this.cmbNation.Tag = this.patientInfo.Nationality.ID;    //民族
            this.dtpBirthDay.Value = this.patientInfo.Birthday;      //出生日期
            //{BE0CBF3B-9CE8-42ca-8448-08CCF11755DF}
            //this.txtAge.Text = this.accountManager.GetAge(this.patientInfo.Birthday);//年龄
            if (this.patientInfo.Birthday != DateTime.MinValue)
            {
               //string Ages = this.accountManager.GetAge(this.patientInfo.Birthday);
               //席宗飞{920FA2E4-CD97-4a2d-B999-BA0CF9494758}
               string age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.patientInfo.Birthday);
               this.txtAge.Text = age.Substring(0, age.Length - 1);
            try
            {
                string unitName = age.Substring(age.Length - 2, 1);
                if (unitName != "岁" && unitName != "月" && unitName != "天")
                {
                    unitName = "岁";
                }
                this.cmbAgeUnit.Text = unitName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
              // this.cmbAgeUnit.Text = Ages.Substring(Ages.Length - 1, 1);
            }
            
            this.cmbDistrict.Text = this.patientInfo.DIST;            //籍贯
            this.cmbProfession.Tag = this.patientInfo.Profession.ID; //职业
            this.txtIDNO.Text = this.patientInfo.IDCard;             //身份证号
            this.cmbWorkAddress.Text = this.patientInfo.CompanyName; //工作单位
            this.txtWorkPhone.Text = this.patientInfo.PhoneBusiness; //单位电话
            this.cmbMarry.Tag = this.patientInfo.MaritalStatus.ID.ToString();//婚姻状况
            this.cmbHomeAddress.Text = this.patientInfo.AddressHome;  //家庭住址
            this.txtHomePhone.Text = this.patientInfo.PhoneHome;     //家庭电话
            this.txtLinkMan.Text = this.patientInfo.Kin.Name;        //联系人 
            this.cmbRelation.Tag = this.patientInfo.Kin.Relation.ID; //联系人关系
            this.cmbLinkAddress.Text = this.patientInfo.Kin.RelationAddress;//联系人地址
            this.txtLinkPhone.Text = this.patientInfo.Kin.RelationPhone;//联系人电话
            this.ckEncrypt.Checked = this.patientInfo.IsEncrypt; //是否加密姓名
            this.ckVip.Checked = this.patientInfo.VipFlag;//是否vip
            this.txtMatherName.Text = this.patientInfo.MatherName;//母亲姓名
            this.cmbCardType.Tag = this.patientInfo.IDCardType.ID; //证件类型
            this.txtSiNO.Text = this.patientInfo.SSN;//社会保险号
            #region added by zhaoyang 2008-10-13
            txtLinkManDoorNo.Text = this.patientInfo.Kin.RelationDoorNo;//联系人地址门牌号
            txtHomeAddrDoorNo.Text = this.patientInfo.AddressHomeDoorNo;//家庭地址门牌号
            txtEmail.Text = this.patientInfo.Email;//电子邮件
            #endregion
        }

        /// <summary>
        /// 获取名字字符串
        /// </summary>
        /// <param name="patient"></param>
        private void GetPatienName(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            //选择加密
            if (ckEncrypt.Checked)
            {
                string name = string.Empty;
                if (this.txtName.Tag == null || this.txtName.Tag.ToString() == string.Empty)
                {
                    name = this.txtName.Text;
                }
                else
                {
                    name = this.txtName.Tag.ToString();
                }
                string encryptStr = Neusoft.FrameWork.WinForms.Classes.Function.Encrypt3DES(name);

                patientInfo.Name = "******";
                patientInfo.NormalName = encryptStr;
                patientInfo.DecryptName = name;
            }
            else
            {
                patientInfo.Name = this.txtName.Text;
            }
        }

        private void CmbEvent()
        {
            foreach (Control c in this.panelControl.Controls)
            {
                c.Enter += new EventHandler(c_Enter);
            }
        }

        /// <summary>
        /// 控件获得焦点时响应的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_Enter(object sender, EventArgs e)
        {
            if (sender == this.txtName || sender == this.txtLinkMan || sender == cmbHomeAddress || sender == cmbLinkAddress || sender == this.txtMatherName || sender == this.cmbWorkAddress)
                InputLanguage.CurrentInputLanguage = CHInput;

            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            if (CmbFoucs != null)
                this.CmbFoucs(sender, null);

        }

        /// <summary>
        /// 根据控件属性,判断是否在必须输入控件列表中加入或者删除该控件
        /// </summary>
        /// <param name="nameControl">名称控件</param>
        /// <param name="inputControl">输入控件</param>
        /// <param name="isMustInput">是否必须输入</param>
        private void AddOrRemoveUnitAtMustInputLists(Control nameControl, Control inputControl, bool isMustInput)
        {
            if (isMustInput)
            {
                if (!InputHasTable.ContainsKey(nameControl))
                {
                    InputHasTable.Add(nameControl, inputControl);
                    nameControl.ForeColor = Color.Blue;
                }
            }
            else
            {
                if (InputHasTable.ContainsKey(nameControl))
                {
                    InputHasTable.Remove(nameControl);
                    nameControl.ForeColor = Color.Black;
                }
            }
            inpubMaxTabIndex = 0;
            foreach (DictionaryEntry de in InputHasTable)
            {
                Control c = de.Value as Control;
                //获取最大的tabIndex
                if (inpubMaxTabIndex < c.TabIndex)
                {
                    inpubMaxTabIndex = c.TabIndex;
                }
            }
        }

        /// <summary>
        /// 根据控件属性,判断是否在必须输入控件列表中加入或者删除该控件
        /// </summary>
        /// <param name="enableControl">输入控件</param>
        /// <param name="isEnable">是否可以编辑</param>
        private void AddOrRemoveUnitAtEnableLists(Control enableControl, bool isEnable)
        {
            if (isEnable)
            {
                if (EnableControlList.Contains(enableControl))
                {
                    EnableControlList.Remove(enableControl);
                    enableControl.Enabled = true;
                }
            }
            if (!isEnable)
            {
                if (!EnableControlList.Contains(enableControl))
                {
                    EnableControlList.Add(enableControl);
                    enableControl.Enabled = false;
                }
            }
        }

        #region 病案室默认值设置
        ///// <summary>
        ///// 保存病案默认科室
        ///// </summary>
        ///// <param name="deptCode"></param>
        //private void SaveCasDeptdefautValue(string deptCode)
        //{
        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        this.CreateXml();
        //    }
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filePath);
        //    XmlNode xn = doc.SelectSingleNode("//DefaultValue");
        //    xn.InnerText = deptCode;
        //    doc.Save(filePath);
        //}

        ///// <summary>
        ///// 建立xml
        ///// </summary>
        //private void CreateXml()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml("<setting>  </setting>");
        //    XmlNode xn = doc.DocumentElement;
        //    XmlComment xc = doc.CreateComment("门诊患者信息录入病案室默认值");
        //    XmlElement xe = doc.CreateElement("DefaultValue");
        //    xn.AppendChild(xc);
        //    xn.AppendChild(xe);
        //    doc.Save(filePath);
        //}

        ///// <summary>
        ///// 读取病案默认值
        ///// </summary>
        ///// <returns></returns>
        //private string ReadCaseDept()
        //{
        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        this.CreateXml();
        //        return string.Empty;
        //    }
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filePath);
        //    XmlNode xn = doc.SelectSingleNode("//DefaultValue");
        //    return xn.InnerText;
        //}
        #endregion
        #endregion

        #region 方法

        /// <summary>
        /// 获得焦点
        /// </summary>
        /// <returns></returns>
        public new bool Focus()
        {
            return this.txtName.Focus();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public virtual void Clear()
        {
            foreach (Control c in this.panelControl.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuComboBox ||
                    c is FrameWork.WinForms.Controls.NeuTextBox)
                {
                    c.Text = string.Empty;
                    c.Tag = string.Empty;
                }
            }
            this.txtAge.ReadOnly = false;
            this.ckEncrypt.Checked = false;
            this.CardNO = string.Empty;
            this.cmbCountry.Text = "中国";
            this.cmbSex.Text = "男";
            this.cmbSex.Tag = "M";
            this.cmbNation.Text = "汉族";
            this.cmbPact.Tag = "1";
            this.dtpBirthDay.Value = this.accountManager.GetDateTimeFromSysDateTime();//出生日期
            
            this.ckVip.Checked = false;
        }

        /// <summary>
        /// 数据合理化校验
        /// </summary>
        /// <returns></returns>
        public virtual bool InputValid()
        {
            //判断必须输入的控件是否都已经输入信息
            foreach (DictionaryEntry d in this.InputHasTable)
            {
                if (d.Value is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
                {
                    if (((Control)d.Value).Tag == null || ((Control)d.Value).Tag.ToString() == string.Empty || ((Control)d.Value).Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(((Control)d.Key).Text.Replace(':', ' ') + Language.Msg("必须输入信息!"));
                        ((Control)d.Value).Focus();

                        return false;
                    }
                }
                else
                {
                    if (((Control)d.Value).Text == string.Empty)
                    {
                        MessageBox.Show(((Control)d.Key).Text.Replace(':', ' ') + Language.Msg("必须输入信息!"));
                        ((Control)d.Value).Focus();

                        return false;
                    }
                }
            }

            if (!this.ckEncrypt.Checked && this.txtName.Text == "******")
            {
                MessageBox.Show(Language.Msg("该患者姓名没有加密，请输入正确的患者姓名！"));
                this.txtName.Focus();
                this.txtName.SelectAll();
                return false;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text, 20))
            {
                MessageBox.Show(Language.Msg("姓名录入超长！"));
                this.txtName.Focus();
                return false;
            }

            //判断字符超长医疗证号
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtSiNO.Text, 20))
            {
                MessageBox.Show(Language.Msg("医疗证号录入超长！"));
                this.txtSiNO.Focus();
                return false;
            }
            //判断字符超长籍贯
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbDistrict.Text, 50))
            {
                MessageBox.Show(Language.Msg("籍贯录入超长！"));
                this.cmbDistrict.Focus();
                return false;
            }
            //判断字符超长证件号
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtIDNO.Text, 20))
            {
                MessageBox.Show(Language.Msg("证件号录入超长！"));
                this.txtIDNO.Focus();
                return false;
            }

            //判断身份证号
            if (this.cmbCardType.Tag != null && this.cmbCardType.Tag.ToString() == "01" && this.txtIDNO.Text.Trim() != string.Empty)
            {
                string err = string.Empty;
                if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(this.txtIDNO.Text.Trim(), ref err) < 0)
                {
                    MessageBox.Show(err);
                    this.txtIDNO.Focus();
                    return false;
                }
            }

            //判断字符超长工作单位
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbWorkAddress.Text, 50))
            {
                MessageBox.Show(Language.Msg("工作单位录入超长！"));
                this.cmbWorkAddress.Focus();
                return false;
            }

            //判断单位电话长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtWorkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("单位电话号码录入超长"));
                this.txtWorkPhone.Focus();
                return false;
            }

            //判断家庭地址长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbHomeAddress.Text, 50))
            {
                MessageBox.Show(Language.Msg("家庭地址录入超长"));
                this.cmbHomeAddress.Focus();
                return false;
            }

            //判断家庭电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("家庭电话号码录入超长"));
                this.txtHomePhone.Focus();
                return false;
            }

            //判断联系电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("联系人电话号码录入超长"));
                this.txtLinkPhone.Focus();
                return false;
            }
            //判断联系联系人长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkMan.Text, 12))
            {
                MessageBox.Show(Language.Msg("联系人录入超长"));
                this.txtLinkMan.Focus();
                return false;
            }
            //联系人地址
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbLinkAddress.Text, 12))
            {
                MessageBox.Show(Language.Msg("联系人地址录入超长"));
                this.cmbLinkAddress.Focus();
                return false;
            }

            //母亲姓名
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtMatherName.Text, 12))
            {
                MessageBox.Show(Language.Msg("母亲姓名录入超长"));
                this.txtMatherName.Focus();
                return false;
            }

            if (this.dtpBirthDay.Value.Date > this.accountManager.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();
                return false;
            }

            #region added by zhaoyang 2008-10-13
            if (string.IsNullOrEmpty(txtEmail.Text) == false)
            {
                //if (NFC.Public.String.isMail(txtEmail.Text.Trim()) == false)
                //{
                //    txtEmail.Focus();
                //    txtEmail.SelectAll();
                //    MessageBox.Show("电子邮箱输入格式错误，请更改或重新输入。");
                //    return false;
                //}
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtEmail.Text, 50))
                {
                    MessageBox.Show(Language.Msg("电子邮箱录入超长!"));
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return false;
                }
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomeAddrDoorNo.Text, 40))
            {
                MessageBox.Show(Language.Msg("门牌号录入超长！"));
                txtHomeAddrDoorNo.SelectAll();
                txtHomeAddrDoorNo.Focus();
                return false;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkManDoorNo.Text, 40))
            {
                MessageBox.Show(Language.Msg("门牌号录入超长！"));
                txtLinkManDoorNo.SelectAll();
                txtLinkManDoorNo.Focus();
                return false;
            }
            #endregion
            return true;
        }

        /// <summary>
        /// 通过合同单位编码,获得结算类别实体
        /// </summary>
        /// <param name="pactID">合同单位编码</param>
        /// <returns>成功: 结算类别实体 失败: null</returns>
        private PayKind GetPayKindFromPactID(string pactID)
        {
            Neusoft.HISFC.Models.Base.PactInfo pact = this.pactManager.GetPactUnitInfoByPactCode(pactID);
            if (pact == null)
            {
                MessageBox.Show(Language.Msg("获得合同单位详细出错!"));

                return null;
            }

            return pact.PayKind;
        }

        /// <summary>
        /// 获得患者实体
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfomation()
        {
            //刷新患者基本信息
            patientInfo = managerIntegrate.QueryComPatientInfo(cardNO);
            //集成平台 嵌入主索引{BCE8D830-5FEA-4681-A08A-4BB48D172E20}
            if (this.patientInfo == null && isLocalOperation == false)
            {
                //if (iEmpi != null)
                //{
                //    this.patientInfo = iEmpi.GetBasePatientinfo(Neusoft.HISFC.BizProcess.Interface.Platform.HisDomain.Outpatient, cardNO);
                //}
            }
            if (patientInfo == null)
            {
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            }

            patientInfo.PID.CardNO = cardNO;//门诊卡号
            if (this.cmbPact.Tag != null && this.cmbPact.Tag.ToString() != string.Empty)
                patientInfo.Pact.PayKind = GetPayKindFromPactID(this.cmbPact.Tag.ToString());//结算类别
            patientInfo.Pact.ID = this.cmbPact.Tag.ToString();//合同单位  
            patientInfo.Pact.Name = this.cmbPact.Text.ToString();//合同单位名称
            if (!this.isTreatment)
            {
                this.GetPatienName(patientInfo); //患者姓名
                patientInfo.IsEncrypt = this.ckEncrypt.Checked; //是否加密
            }
            else
            {
                this.patientInfo.Name = "无名氏";
                patientInfo.IsEncrypt = false;
            }
            patientInfo.Sex.ID = this.cmbSex.Tag.ToString();//性别
            patientInfo.AreaCode = this.cmbArea.Tag.ToString();//地区
            patientInfo.Country.ID = this.cmbCountry.Tag.ToString();//国籍
            patientInfo.Nationality.ID = this.cmbNation.Tag.ToString();//民族
            patientInfo.Birthday = this.dtpBirthDay.Value;//出生日期
            patientInfo.Age = outpatientManager.GetAge(this.dtpBirthDay.Value);//年龄
            patientInfo.DIST = this.cmbDistrict.Text.ToString();//籍贯
            patientInfo.Profession.ID = this.cmbProfession.Tag.ToString();//职业
            patientInfo.IDCard = this.txtIDNO.Text;//证件号
            patientInfo.IDCardType.ID = this.cmbCardType.Tag.ToString();//证件类型
            patientInfo.CompanyName = this.cmbWorkAddress.Text.Trim();//工作单位
            patientInfo.PhoneBusiness = this.txtWorkPhone.Text.Trim();//单位电话
            patientInfo.MaritalStatus.ID = this.cmbMarry.Tag.ToString();//婚姻状况 
            patientInfo.AddressHome = this.cmbHomeAddress.Text.ToString();//家庭住址
            patientInfo.PhoneHome = this.txtHomePhone.Text.Trim();//家庭电话
            patientInfo.Kin.Name = this.txtLinkMan.Text.Trim();//联系人 
            patientInfo.Kin.Relation.ID = this.cmbRelation.Tag.ToString();//与联系人关系
            patientInfo.Kin.RelationAddress = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.RelationPhone = this.txtLinkPhone.Text.Trim();  //联系人电话
            patientInfo.VipFlag = this.ckVip.Checked; //是否vip
            patientInfo.MatherName = this.txtMatherName.Text;//母亲姓名
            patientInfo.IsTreatment = this.IsTreatment;//是否急诊
            patientInfo.SSN = this.txtSiNO.Text;//社会保险号
            #region added by zhaoyang 2008-10-13
            patientInfo.Kin.RelationDoorNo = this.txtLinkManDoorNo.Text.Trim();//联系人地址门牌号
            patientInfo.AddressHomeDoorNo = txtHomeAddrDoorNo.Text.Trim();//家庭地址门牌号
            patientInfo.Email = txtEmail.Text.Trim();//电子邮箱
            #endregion
            return patientInfo;
        }

        /// <summary>
        /// 保存患者数据
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            //普通患者就诊卡发放
            if (!IsTreatment)
            {
                if (!InputValid()) return -1;

            }
            this.patientInfo = this.GetPatientInfomation();

            if (patientInfo.Pact.PayKind.ID == "02")
            {
                //当患者是医保护患者时姓名、性别、医保证号不能为空
                if (this.txtName.Text == string.Empty || this.txtSiNO.Text == string.Empty
                    || this.cmbSex.Tag == null || this.cmbSex.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show("该患者是医保患者，姓名、性别、医保证号不能为空！", "提示");
                    return -1;
                }
            }

            if (string.IsNullOrEmpty(patientInfo.PID.CardNO))
            {
                //集成平台 处理主索引{BCE8D830-5FEA-4681-A08A-4BB48D172E20}
                //if (this.iEmpi != null && isLocalOperation == false)
                //{
                //    if (iEmpi.GetDomainID(Neusoft.HISFC.BizProcess.Interface.Platform.HisDomain.Outpatient, patientInfo, false, ref cardNO) == -1)
                //    {
                //        MessageBox.Show("由数据中心获取新病例卡号发生错误" + iEmpi.Message);
                //        return -1;
                //    }
                //    if (string.IsNullOrEmpty(cardNO))
                //    {
                //        cardNO = outpatientManager.GetAutoCardNO();
                //        cardNO = cardNO.PadLeft(HISFC.BizProcess.Integrate.Common.ControlParam.GetCardNOLen(), '0');
                //    }
                //}
                //else
                //{
                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                if (!this.cardWay)
                {
                    cardNO = this.McardNO;
                }
                else
                {
                    cardNO = outpatientManager.GetAutoCardNO();
                }

                //cardNO = cardNO.PadLeft(HISFC.BizProcess.Integrate.Common.ControlParam.GetCardNOLen(), '0');
                cardNO = cardNO.PadLeft(10, '0');
                //}
            }
            else
            {
                cardNO = patientInfo.PID.CardNO;
            }
            patientInfo.PID.CardNO = cardNO;

            if (radtManager.RegisterComPatient(patientInfo) < 0)
            {
                MessageBox.Show(radtManager.Err);
                return -1;
            }
            //集成平台 处理主索引{BCE8D830-5FEA-4681-A08A-4BB48D172E20}
            //if (this.iEmpi != null && isLocalOperation == false)
            //{
            //    if (iEmpi.CreateOrUpdatePatient(Neusoft.HISFC.BizProcess.Interface.Platform.HisDomain.Outpatient, patientInfo) == -1)
            //    {
            //        MessageBox.Show("创建或更新患者主索引信息出错" + iEmpi.Message);
            //        return -1;
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 根据ID获得名称
        /// </summary>
        /// <param name="ID">民族ID</param>
        /// <param name="aMod">0:民族 1:证件类型</param>
        /// <returns></returns>
        public string GetName(string ID, int aMod)
        {
            if (aMod == 0)
            {
                return NationHelp.GetName(ID);
            }
            else
            {
                return IdCardTypeHelp.GetName(ID);
            }
        }

        /// <summary>
        /// 根据必须输入控件跳转输入焦点
        /// </summary>
        private void SetMustInputFocus(Control currentControl)
        {
            if (currentControl == null)
            {
                SendKeys.Send("{Tab}");
                return;
            }
            //查找下应当等到焦点必须输入的控件
            Control tempControl = this.NextFocusControl(currentControl);
            if (tempControl != null && tempControl.CanFocus)
            {
                tempControl.Focus();
            }
            else
            {
                //但是最后一个焦点的时候触发此事件
                if (this.OnFoucsOver != null)
                {
                    this.OnFoucsOver(null, null);
                }
                else
                {
                    SendKeys.Send("{Tab}");
                }
            }
        }

        /// <summary>
        /// 根据当前的TabIndex查找下一个应该得到焦点的控件
        /// </summary>
        /// <param name="CurrentTabIndex"></param>
        /// <returns></returns>
        private Control NextFocusControl(Control currentContol)
        {
            Control tempControl = null;
            foreach (DictionaryEntry de in InputHasTable)
            {
                Control c = de.Value as Control;
                if (currentContol.TabIndex < c.TabIndex)
                {
                    if (tempControl == null)
                    {
                        tempControl = c;
                        continue;
                    }
                    if (tempControl != null && tempControl.TabIndex > c.TabIndex)
                    {
                        tempControl = c;
                    }
                }
            }
            return tempControl;
        }

        /// <summary>
        /// 获取当前有焦点控件
        /// </summary>
        /// <returns></returns>
        private Control GetCurrentFoucsControl()
        {
            foreach (Control c in panelControl.Controls)
            {
                if (c.Focused)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置控件enable属性
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetControlEnable(bool isEnabled)
        {
            foreach (Control c in this.panelControl.Controls)
            {
                c.Enabled = isEnabled;
            }
        }

        /// <summary>
        /// 提示栏
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.lblshow.Text = title;
        }
        #endregion

        #region 输入法

        /// <summary>
        /// 默认的中文输入法
        /// </summary>
        private InputLanguage CHInput = null;

        /// <summary>
        /// 初始化输入法菜单
        /// </summary>
        private void SetInputMenu()
        {

            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage t = InputLanguage.InstalledInputLanguages[i];
                System.Windows.Forms.ToolStripMenuItem m = new ToolStripMenuItem();
                m.Text = t.LayoutName;
                m.Click += new EventHandler(m_Click);
                neuContextMenuStrip1.Items.Add(m);
            }

            this.ReadInputLanguage();
        }

        /// <summary>
        /// 读取当前默认输入法
        /// </summary>
        private void ReadInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
               // Neusoft.UFC.Common.Classes.Function.CreateFeeSetting();

            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                CHInput = GetInputLanguage(node.Attributes["currentmodel"].Value);

                if (CHInput != null)
                {
                    foreach (ToolStripMenuItem m in neuContextMenuStrip1.Items)
                    {
                        if (m.Text == CHInput.LayoutName)
                        {
                            m.Checked = true;
                        }
                    }
                }

                //添加到工具栏

            }
            catch (Exception e)
            {
                MessageBox.Show("获取默认中文输入法出错!" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 根据输入法名称获取输入法
        /// </summary>
        /// <param name="LanName"></param>
        /// <returns></returns>
        private InputLanguage GetInputLanguage(string LanName)
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
        private void SaveInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
               // Neusoft.UFC.Common.Classes.Function.CreateFeeSetting();
            }
            if (CHInput == null)
                return;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                node.Attributes["currentmodel"].Value = CHInput.LayoutName;

                doc.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show("保存默认中文输入法出错!" + e.Message);
                return;
            }
        }

        private void m_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
            {
                if (sender == m)
                {
                    m.Checked = true;
                    this.CHInput = this.GetInputLanguage(m.Text);
                    //保存输入法
                    this.SaveInputLanguage();
                }
                else
                {
                    m.Checked = false;
                }
            }
        }

        #endregion

        #region 事件
        private void ucPatientInfo_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() != "devenv")
            {
                #region 权限判断
                Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager user = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
                NeuObject dept = (accountManager.Operator as HISFC.Models.Base.Employee).Dept;
                //判断是否有加密权限
                this.IsEnableEntry = user.JudgeUserPriv(accountManager.Operator.ID, dept.ID, "5001", "01");

                //Vip权限设置
                this.IsEnableVip = user.JudgeUserPriv(accountManager.Operator.ID, dept.ID, "5002", "01");


                #endregion

                this.Init();
                this.ActiveControl = this.txtName;
            }
        }

        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            //年龄采用统一的算法 {04CF4C0D-DE0A-426c-8724-76CA4CDBC267} wbo 2010-11-14
            //string age = this.accountManager.GetAge(this.dtpBirthDay.Value);
            string age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.dtpBirthDay.Value);
            this.txtAge.TextChanged -= new EventHandler(txtAge_TextChanged);
            this.txtAge.Text = age.Substring(0, age.Length -1);
            this.txtAge.TextChanged += new EventHandler(txtAge_TextChanged);
            this.cmbAgeUnit.SelectedIndexChanged -= new EventHandler(cmbAgeUnit_SelectedIndexChanged);
            //这个BUG有点... {9A74FC53-BC06-4237-89FE-E1A71806A594} wbo 2010-11-14
            //this.cmbAgeUnit.Text = age.Substring(age.Length - 1, 1);
            try
            {
                string unitName = age.Substring(age.Length - 2, 1);
                if (unitName != "岁" && unitName != "月" && unitName != "天")
                {
                    unitName = "岁";
                }
                this.cmbAgeUnit.Text = unitName;
            }
            catch (Exception ex)
            { }
            this.cmbAgeUnit.SelectedIndexChanged += new EventHandler(cmbAgeUnit_SelectedIndexChanged);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                if (txtMatherName.Focused)
                {
                    if (OnFoucsOver != null)
                    {
                        OnFoucsOver(null, null);
                        return true;
                    }
                }
                if (this.txtIDNO.Focused)
                {
                    if (this.cmbCardType.Tag.ToString() == "01")
                    {
                        string error = string.Empty;
                        string idNO = this.txtIDNO.Text.Trim();
                        if (idNO != string.Empty)
                        {
                            if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNO, ref error) < 0)
                            {
                                MessageBox.Show(error);
                                return true;
                            }
                            //根据身份证号获取患者性别
                            Neusoft.FrameWork.Models.NeuObject obj = Class.Function.GetSexFromIdNO(idNO, ref error);
                            if (obj == null)
                            {
                                MessageBox.Show(error);
                                return true;
                            }
                            this.cmbSex.Tag = obj.ID;
                            //根据患者身份证号获取生日
                            string birthdate = Class.Function.GetBirthDayFromIdNO(idNO, ref error);
                            if (birthdate == "-1")
                            {
                                MessageBox.Show(error);
                                return true;
                            }
                            this.dtpBirthDay.Value = FrameWork.Function.NConvert.ToDateTime(birthdate);
                        }
                    }
                }

                
                Control currentContol = this.GetCurrentFoucsControl();
               
                if (isMustInputTabInde)
                {
                    SetMustInputFocus(currentContol);
                }
                else
                {
                    SendKeys.Send("{Tab}");
                }
                #region 查询患者信息
                if (inpubMaxTabIndex == currentContol.TabIndex)
                {
                    if (OnEnterSelectPatient != null)
                    {
                        this.OnEnterSelectPatient(null, null);
                    }
                }
                #endregion

                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 根据年龄算生日
        /// </summary>
        /// <param name="age"></param>
        /// <param name="ageUnit"></param>
        /// <returns></returns>
        private void ConvertBirthdayByAge()
        {
            DateTime current = this.accountManager.GetDateTimeFromSysDateTime();

            DateTime birthday = current;
            string ageUnit = this.cmbAgeUnit.Text;

            string strAge = this.txtAge.Text.Trim();
            if (string.IsNullOrEmpty(strAge))
            {
                this.txtAge.Text = "1";
                strAge = "1";
            }

            int age = Neusoft.FrameWork.Function.NConvert.ToInt32(strAge);

            if (ageUnit == "岁")
            {
                birthday = current.AddYears(-age);
            }
            else if (ageUnit == "月")
            {
                birthday = current.AddMonths(-age);
            }
            else if (ageUnit == "天")
            {
                birthday = current.AddDays(-age);
            }
            this.dtpBirthDay.ValueChanged -=new EventHandler(dtpBirthDay_ValueChanged);
            this.dtpBirthDay.Value = birthday;
            this.dtpBirthDay.ValueChanged += new EventHandler(dtpBirthDay_ValueChanged);

        }

        private void cmbAgeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ConvertBirthdayByAge();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            this.ConvertBirthdayByAge();
        }

        #endregion
        


    }
}
