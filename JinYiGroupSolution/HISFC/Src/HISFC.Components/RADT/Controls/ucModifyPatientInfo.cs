using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// ucModifyPatientInfo<br></br>
    /// [功能描述: 修改住院登记的信息]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2007-1-8]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucModifyPatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucModifyPatientInfo()
        {
            InitializeComponent();
        }

        private void ucModifyPatientInfo_Load(object sender, EventArgs e)
        {
            Init();
        }

        #region 字段

        /// <summary>
        /// 打印病案
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface healthPrint = null;

        /// <summary>
        /// 患者信息实体

        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new PatientInfo();

        /// <summary>
        /// 患者信息实体副本

        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfoOld;

        /// <summary>
        /// Manager业务层

        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院入出转业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.RADT.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        /// <summary>
        /// 住院费用大业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 患者入出转转业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 本地业务层
        /// </summary>
        private Components.RADT.Classes.LocalManager local = new Neusoft.HISFC.Components.RADT.Classes.LocalManager();

        #region add by xuewj 2010-03-10 {010BAFC3-96E2-4acc-AAD4-55320B9C2229}
        /// <summary>
        /// ADT接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        /// <summary>
        /// 是否允许修改姓名
        /// </summary>
        private bool isAllowModifyName = false;

        /// <summary>
        /// 是否允许修改姓名{F577FEF5-53D1-4768-B345-F2EBD3E9DF9C}
        /// </summary>
        [Category("设置"),Description("是否允许修改姓名true:允许修改 false不允许修改"),DefaultValue(false)]
        public bool IsAllowModifyName
        {
            get
            {
                return this.txtName.Enabled;
            }
            set
            {
                isAllowModifyName = value;
                this.txtName.Enabled = value;
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("确定", "确定", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("退出", "退出", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出, true, true, null);
            toolBarService.AddToolButton("补打", "补打", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, true, null);
            toolBarService.AddToolButton("腕带", "腕带", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z执行, true, true, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "确定":

                    this.Confirm();
                    break;

                case "清屏":
                    this.Clear();
                    this.ucQueryInpatientNo1.Text = "";
                    this.ucQueryInpatientNo1.Focus();
                    break;

                case "帮助":

                    break;
                case "退出":
                    this.FindForm().Close();
                    break;
                case "补打":
                    this.Print();
                    break;
                case "腕带":
                    this.PrintPatientWristlet();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }


        /// <summary>
        /// 初始化控件,等信息

        /// </summary>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int Init()
        {

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在初始化窗口，请稍候^^"));
            Application.DoEvents();

            #region 病案打印
            object[] o = new object[] { };

            try
            {

                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

                System.Runtime.Remoting.ObjectHandle objHande = System.Activator.CreateInstance("HISFC.Components.HealthRecord", "Neusoft.HISFC.Components.HealthRecord.ucLCCasePrint", false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

                object oLabel = objHande.Unwrap();

                this.healthPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface;
            }
            catch (System.TypeLoadException ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));
                return -1;
            }
            #endregion

            try
            {
                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
                this.cmbSex.Text = "男";

                //民族
                this.cmbNation.AddItems(managerIntegrate.GetConstantList(EnumConstant.NATION));
                this.cmbNation.Text = "汉族";

                //婚姻状态

                this.cmbMarry.AddItems(Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List());

                //国家
                this.cmbCountry.AddItems(managerIntegrate.GetConstantList(EnumConstant.COUNTRY));
                this.cmbCountry.Text = "中国";

                //职业信息
                this.cmbProfession.AddItems(managerIntegrate.GetConstantList(EnumConstant.PROFESSION));

                //工作单位
                this.cmbWorkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //联系人信息

                this.cmbRelation.AddItems(managerIntegrate.GetConstantList(EnumConstant.RELATIVE));

                //联系人地址信息
                this.cmbLinkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //家庭住址信息
                this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //籍贯
                this.cmbDistrict.AddItems(managerIntegrate.GetConstantList(EnumConstant.DIST));

                //病人来源信息
                this.cmbInSource.AddItems(managerIntegrate.GetConstantList(EnumConstant.INSOURCE));
                this.cmbInSource.SelectedIndex = 0;

                //入院途径信息
                this.cmbApproach.AddItems(managerIntegrate.GetConstantList(EnumConstant.INAVENUE));
                this.cmbApproach.SelectedIndex = 0;

                //入院情况信息
                this.cmbCircs.AddItems(managerIntegrate.GetConstantList(EnumConstant.INCIRCS));
                this.cmbCircs.SelectedIndex = 0;

                //医生信息
                this.cmbDoctor.AddItems(managerIntegrate.QueryEmployee(EnumEmployeeType.D));

                //床位间隔
                this.txtBedInterval.Text = "1";

                //入院日期
                this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期

                //生日
                this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();//出生日期

                //地区
                this.cmbArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
                //this.cmbPact.AddItems(managerIntegrate.GetConstantList(EnumConstant.PACTUNIT));
                this.cmbPact.AddItems(managerIntegrate.QueryPactUnitAll());
                this.cmbPact.IsListOnly = true;

                this.cmbMark.AddItems(managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.REMARK));
                this.cmbMark.IsListOnly = true;

                //foreach (Control c in this.Controls)
                //{
                //    if (c is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
                //    {
                //        ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).Enter += new EventHandler(ucRegister_Enter);
                //    }
                //    else
                //    {
                //        c.Enter += new EventHandler(c_Enter);
                //    }
                //}

                //增加开住院证医生{aad89de3-bab6-4326-aa76-68cf0076d23b}
                //开住院证医生信息
                this.cmbPreDoctor.AddItems(managerIntegrate.QueryEmployee(EnumEmployeeType.D));

                this.ucDiagnose1.Init();
                this.ucDiagnose1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(ucDiagnose1_SelectItem);

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            //this.RefreshPatientLists();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }



        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="patientInfo"></param>
        protected void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.patientInfo = patientInfo;
            Neusoft.HISFC.Models.RADT.Patient Patient = patientInfo;
            this.chbEncrypt.Checked = patientInfo.IsEncrypt;
            bool GetFlag = false;//领用标识 
            #region//{7218AEA9-CEA8-4eea-B592-F599E9A5DDE8} by xizf 20101123
            string rev = local.GetReceiptPerson(this.patientInfo.ID);
            if (rev != "0") {
                GetFlag = true;
            }
            #endregion
            if (patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.chkGetFlag.Checked = GetFlag;//领用标识
            this.txtName.Text = patientInfo.Name;               //姓名
            this.cmbSex.Text = patientInfo.Sex.Name;            //性别
            this.cmbSex.Tag = patientInfo.Sex.ID;               //性别
            this.txtCardNO.Text = patientInfo.PID.CardNO;       //就诊卡号
            this.txtCardNO.ReadOnly = true;
            this.cmbPact.Text = patientInfo.Pact.Name;          //合同单位名称
            this.cmbPact.Tag = patientInfo.Pact.ID;             //合同单位ID
            this.cmbPact.IsListOnly = true;
            this.cmbArea.Tag = patientInfo.AreaCode;            //地区
            this.cmbCountry.Tag = patientInfo.Country.ID;       //国籍
            this.cmbNation.Tag = patientInfo.Nationality.ID;    //民族
            this.dtpBirthDay.Value = patientInfo.Birthday;      //出生日期
            this.txtAge.Text = this.inpatientManager.GetAge(patientInfo.Birthday);//年龄
            this.cmbDistrict.Text = patientInfo.DIST;            //籍贯
            this.cmbProfession.Tag = patientInfo.Profession.ID; //职业
            this.txtIDNO.Text = patientInfo.IDCard;             //身份证号
            this.cmbWorkAddress.Text = patientInfo.CompanyName; //工作单位
            this.txtWorkPhone.Text = patientInfo.PhoneBusiness; //单位电话
            this.cmbMarry.Tag = patientInfo.MaritalStatus.ID.ToString();//婚姻状况
            this.cmbHomeAddress.Text = patientInfo.AddressHome;  //家庭住址
            this.txtHomePhone.Text = patientInfo.PhoneHome;     //家庭电话
            this.txtLinkMan.Text = patientInfo.Kin.Name;        //联系人

            this.cmbRelation.Tag = patientInfo.Kin.Relation.ID; //联系人关系

            this.cmbLinkAddress.Text = patientInfo.Kin.RelationAddress;//联系人地址

            this.txtLinkPhone.Text = patientInfo.Kin.RelationPhone;//联系人电话

            this.cmbInSource.Tag = patientInfo.PVisit.InSource.ID;//入院来源
            this.cmbApproach.Tag = patientInfo.PVisit.AdmitSource.ID;//入院途径
            this.cmbCircs.Tag = patientInfo.PVisit.Circs.ID;    //入院情况
            this.txtBedInterval.Text = patientInfo.FT.FixFeeInterval.ToString();//床位间隔
            this.dtpInTime.Value = patientInfo.PVisit.InTime;   //入院日期
            this.cmbDoctor.Tag = patientInfo.PVisit .AdmittingDoctor.ID; //收住院医师

            this.cmbMark.Tag = patientInfo.Memo;                //特注
            this.ucQueryInpatientNo1.txtInputCode.Text = patientInfo.PID.PatientNO; //住院号

            //{3a23d5ff-8e31-4128-a5cc-736abfbbd056}调入信息的修改
            this.txtDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;//入院科室
            this.cmbPreDoctor.Tag = patientInfo.DoctorReceiver.ID;//开住院证医生
            this.txtInDiagnosis.Text = patientInfo.ClinicDiagnose;//入院诊断
            //xizf@neusoft.com 20110107 接诊处的娘们儿又让修改了
            //if (this.chkGetFlag.Checked) {
            //    this.chkGetFlag.Enabled = false;
            //}


        }



        #endregion

        /// <summary>
        ///　对控件进行赋值

        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            patientInfo = null;
            if (this.ucQueryInpatientNo1.InpatientNo == "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("不存在该患者，或者该患者已经出院！", 111);
                this.Clear();
                return;
            }
            //获取住院号赋值给实体

            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);

            if (this.patientInfo == null)
            {
                MessageBox.Show(this.radtIntegrate.Err);
                this.ucQueryInpatientNo1.Focus();

                return;
            }

            this.patientInfoOld = this.patientInfo.Clone();
            //重置一次性领用标识
            this.chkGetFlag.Enabled = true;
            SetPatientInfo(this.patientInfo);

            //this.txtName.Focus();
            this.cmbSex.Focus();
        }

        /// <summary>
        /// 获得控件输入的信息,合成患者基本信息实体

        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns> 成功: true 失败 : false</returns>
        private bool GetPatientInfomation(PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者信息实体为空!", 111);

                return true;
            }

            patientInfo.Name = this.txtName.Text;                           //姓名
            if (cmbSex.Tag != null)
            {
                patientInfo.Sex.ID = this.cmbSex.Tag.ToString();                    //性别
            }
            if (cmbArea.Tag != null)
            {
                patientInfo.AreaCode = this.cmbArea.Tag.ToString();                 //地区
            }
            if (this.cmbCountry.Tag != null)
            {
                patientInfo.Country.ID = this.cmbCountry.Tag.ToString();            //国籍
            }
            if (this.cmbNation.Tag != null)
            {
                patientInfo.Nationality.ID = this.cmbNation.Tag.ToString();         //民族
            }
            patientInfo.Birthday = this.dtpBirthDay.Value;                      //出生日期
            if (this.cmbDistrict.Tag != null)
            {
                patientInfo.DIST = this.cmbDistrict.Text.ToString();                 //籍贯
            }
            if (this.cmbProfession.Tag != null)
            {
                patientInfo.Profession.ID = this.cmbProfession.Tag.ToString();      //职业
            }
            patientInfo.IDCard = this.txtIDNO.Text;                             //身份证号
            patientInfo.CompanyName = this.cmbWorkAddress.Text;       //工作单位
            //patientInfo.PhoneBusiness = this.txtHomePhone.Text;                 //单位电话
            patientInfo.PhoneBusiness = this.txtWorkPhone.Text;                 //单位电话
            if (this.cmbMarry.Tag != null)
            {
                patientInfo.MaritalStatus.ID = this.cmbMarry.Tag.ToString();        //婚姻状况
            }
            if (cmbHomeAddress.Tag != null)
            {
                patientInfo.AddressHome = this.cmbHomeAddress.Text.ToString();       //家庭住址
            }
            patientInfo.PhoneHome = this.txtHomePhone.Text;                     //家庭电话
            patientInfo.Kin.Name = this.txtLinkMan.Text;                        //联系人

            if (cmbRelation.Tag != null)
            {
                patientInfo.Kin.Relation.ID = this.cmbRelation.Tag.ToString();      //与联系人关系
            }
            patientInfo.Kin.RelationAddress = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.RelationPhone = this.txtLinkPhone.Text;              //联系人电话


            if (cmbInSource.Tag != null)
            {
                patientInfo.PVisit.InSource.ID = this.cmbInSource.Tag.ToString();    //入院来源
            }
            if (cmbInSource.Tag != null)
            {
                patientInfo.PVisit.AdmitSource.ID = this.cmbInSource.Tag.ToString(); //入院途径
            }
            if (cmbCircs.Tag != null)
            {
                patientInfo.PVisit.Circs.ID = this.cmbCircs.Tag.ToString();          //入院情况
            }
            patientInfo.FT.FixFeeInterval = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtBedInterval.Text);//床费间隔
            patientInfo.PVisit.InTime = this.dtpInTime.Value;                    //入院日期
            if (cmbDoctor.Tag != null)
            {
                //patientInfo.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString();       //收住院医师
                //{3a23d5ff-8e31-4128-a5cc-736abfbbd056}
                patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoctor.Tag.ToString();

            }
            patientInfo.Memo = this.cmbMark.Tag.ToString();                      //特注
            patientInfo.Kin.User01 = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.Memo = this.txtLinkPhone.Text; //联系人电话

            if (cmbDoctor.Tag != null)
            {
                //patientInfo.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString(); //收住医师
                //{3a23d5ff-8e31-4128-a5cc-736abfbbd056}收住医师就是住院医师
                patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoctor.Tag.ToString();
            }
            patientInfo.IsEncrypt = this.chbEncrypt.Checked;
            if (this.chbEncrypt.Checked)
            {
                this.patientInfo.NormalName = Neusoft.FrameWork.WinForms.Classes.Function.Encrypt3DES(this.patientInfo.Name);
                this.patientInfo.Name = "******";

            }
            //{11E0FF1C-3A90-499d-B3A3-7C3B5368A613} by xizf 20101123一次性领用标识1：已领0：未领
            if (this.chkGetFlag.Checked)
            {
                this.patientInfo.Insurance.ID = "1";
            }
            else {
                this.patientInfo.Insurance.ID = "0";
            }
            //{3a23d5ff-8e31-4128-a5cc-736abfbbd056} 
            if (cmbPreDoctor.Tag != null)
            {
                patientInfo.DoctorReceiver.ID = this.cmbPreDoctor.Tag.ToString();//开住院证医生
            }
            patientInfo.ClinicDiagnose = this.txtInDiagnosis.Text.ToString();//入院诊断

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool InputValid()
        {
            //判断单位电话长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtWorkPhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("单位电话号码长度过长"));
                this.txtWorkPhone.Focus();
                return false;
            }
            //判断家庭电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("家庭电话号码长度过长"));
                this.txtHomePhone.Focus();
                return false;
            }

            //判断身份证号码长度

            string errText = string.Empty;
            if ((this.txtIDNO.Text.Trim() != null && this.txtIDNO.Text.Trim() != ""))
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(this.txtIDNO.Text, ref errText) == -1)
                {
                    MessageBox.Show(errText);
                    return false;
                }
            }

            //判断联系电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("联系人电话号码长度过长"));
                this.txtLinkPhone.Focus();
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkMan.Text, 12))
            {
                MessageBox.Show(Language.Msg("联系人姓名过长"));
                this.txtLinkMan.Focus();
                return false;
            }
            //判断性别
            if (this.cmbSex.Text.Trim() == "")
            {
                MessageBox.Show(Language.Msg("性别不能为空，请输入性别"));
                this.cmbSex.Focus();
                return false;
            }
            //判断入院来源
            if (this.cmbInSource.Text.Trim() == "")
            {
                //MessageBox.Show(Language.Msg("入院来源不能为空，请输入入院来源"));
                //return false;
                //by xizf 20110114
                this.cmbInSource.SelectedIndex = 0;
            }

            if (this.dtpBirthDay.Value > this.inpatientManager.GetDateTimeFromSysDateTime().Date.AddDays(1))
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();

                return false;
            }
            if (Convert.ToInt32(this.txtBedInterval.Text) == 0)
            {
                MessageBox.Show(Language.Msg("床费间隔只能为大于零的数，请重新输入！"));
                this.txtBedInterval.Focus();
                this.txtBedInterval.SelectAll();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 确定方法
        /// </summary>
        /// <returns></returns>
        protected virtual int Confirm()
        {
            if (patientInfoOld == null || patientInfo == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入住院号", 111);
                return -1;
            }

            //验证有效性,如果有不符合录入,那么中止方法
            if (!this.InputValid())
            {
                return -1;
            }

            //得到患者基本信息

            if (!this.GetPatientInfomation(this.patientInfo))
            {
                return -1;
            }

            //创建数据库连接

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.inpatientManager.Connection);
            ////开始事物

            //t.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //判断患者病床信息，是否已接诊，防止并发
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfoReGet = new PatientInfo();
            patientInfoReGet = this.radtIntegrate.GetPatientInfoByPatientNO(this.patientInfo.ID);
            //如当前患者床位信息为空 且 重新获取患者床位信息不为空 则提示
            //{1C12B07D-82EE-4e27-A0CD-794F8AA58F9E}
            if (string.IsNullOrEmpty(this.patientInfo.PVisit.PatientLocation.Bed.ID) && !string.IsNullOrEmpty(patientInfoReGet.PVisit.PatientLocation.Bed.ID))
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("保存失败！" + "患者信息已发生变动，请刷新后再试一次！", 211);
                return -1;
            }
            #region 判断当前患者状态，避免出现患者已经出院，但此处仍将患者状态置为非出院状态{B5839351-AA33-440d-A801-5CEDFFBE2EFE} modified by xizf 20101221
            Neusoft.HISFC.Models.RADT.PatientInfo tempInfo = new PatientInfo();
            tempInfo = this.radtIntegrate.GetPatientInfomation(this.patientInfo.ID);
            if (tempInfo.PVisit.InState.ID.ToString()== "O") {
                MessageBox.Show("对不起,该患者已经出院！");
                return -1;
            }
            #endregion

            //{1C12B07D-82EE-4e27-A0CD-794F8AA58F9E}
            if (patientInfoReGet.PVisit.PatientLocation.Bed.ID != patientInfo.PVisit.PatientLocation.Bed.ID)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("保存失败！" + "患者信息已发生变动，请刷新后再试一次！", 211);
                return -1;
            }

            #region addby xuewj 2010-03-10 adt-Patient Update {010BAFC3-96E2-4acc-AAD4-55320B9C2229}

            if (this.adt == null)
            {
                this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
            }

            if (this.adt != null)
            {
                this.adt.UpdatePatient(this.patientInfo.Clone());
            }

            #endregion

            //更新患者住院信息

            if (this.inpatientManager.UpdatePatient(this.patientInfo) != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("保存失败！" + this.inpatientManager.Err, 211);

                return -1;
            }

            //更新患者基本信息

            if (this.inpatientManager.UpdatePatientInfo(this.patientInfo) != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("保存失败!" + this.inpatientManager.Err, 211);

                return -1;
            }
            #region 更新一次性领用标识{524FFE64-7246-40b1-B85E-2903B02A1638} modified by xizf 20101123
            if (this.patientInfo.Insurance.ID =="1"){
                local.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                if (local.UpdateRecipePerson(this.patientInfo.ID, Neusoft.FrameWork.Management.Connection.Operator.ID) < 0) {
                    return -1;
                }
            }
            
            #endregion

            #region //{F577FEF5-53D1-4768-B345-F2EBD3E9DF9C}
            //更新费用明细

            int returnValue = this.inpatientManager.ModifyPatientNOForFeeItemList(this.patientInfo.ID, this.patientInfo.Name);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新非药品信息出错！\n " + this.inpatientManager.Err);
                return -1;
            }

            //更新药品明细
            returnValue = this.inpatientManager.ModifyPatientNOForMedicineList(this.patientInfo.ID, this.patientInfo.Name);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新药品信息出错！\n " + this.inpatientManager.Err);
                return -1;
            }

            //更新处方明细
            returnValue = this.inpatientManager.ModifyPatientNOForFeeInfo(this.patientInfo.ID, this.patientInfo.Name);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新处方明细出错！\n " + this.inpatientManager.Err);
                return -1;
            }
            #endregion
            //插入变更信息
            if (this.radtIntegrate.InsertShiftData(this.patientInfo.ID, Neusoft.HISFC.Models.Base.EnumShiftType.F, "患者基本信息修改", patientInfoOld, patientInfo) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("插入变更信息出错!" + this.inpatientManager.Err, 211);

                return -1;
            }

            //提交事物
            Neusoft.FrameWork.Management.PublicTrans.Commit();



            Neusoft.FrameWork.WinForms.Classes.Function.Msg("修改成功!", 111);

            //清空控件
            this.Clear();

            return 1;
        }


        /// <summary>
        /// 清空控件信息
        /// </summary>
        protected virtual void Clear()
        {
            this.txtName.Text = string.Empty;
            this.txtIDNO.Text = string.Empty;
            this.cmbMarry.Text = string.Empty;
            this.cmbPact.Text = string.Empty;
            this.cmbArea.Text = string.Empty;
            //this.cmbCountry.Text = string.Empty;
            this.cmbCountry.SelectedIndex = 0;
            this.cmbNation.SelectedIndex = 0;
            this.cmbProfession.Text = string.Empty;
            this.txtLinkMan.Text = string.Empty;
            this.cmbRelation.Text = string.Empty;
            this.cmbLinkAddress.Text = string.Empty;
            this.txtHomePhone.Text = string.Empty;
            this.txtWorkPhone.Text = string.Empty;
            //this.cmbInSource.Text = string.Empty;
            this.cmbDoctor.Text = string.Empty;
            this.cmbInSource.SelectedIndex = 0;
            this.cmbApproach.SelectedIndex = 0;
            this.cmbCircs.SelectedIndex = 0;
            this.txtBedInterval.Text = "1";
            this.cmbArea.Text = string.Empty;
            // 属性控制{F577FEF5-53D1-4768-B345-F2EBD3E9DF9C}
            //this.txtName.Enabled = true;
            this.txtIDNO.Enabled = true;
            this.cmbHomeAddress.Text = string.Empty;
            this.cmbWorkAddress.Text = string.Empty;
            this.txtCardNO.Text = string.Empty;
            //this.cmbSex.Text = string.Empty;
            //this.cmbNation.Text = string.Empty;
            this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.txtAge.Text = string.Empty;
            this.txtAge.ReadOnly = true;
            this.txtHomePhone.Text = string.Empty;
            this.txtLinkPhone.Text = string.Empty;
            this.patientInfo = null;
            this.patientInfoOld = null;
            this.ucQueryInpatientNo1.Text = string.Empty;
            this.cmbMark.Text = string.Empty;
            this.chbEncrypt.Checked = false;
            this.chkGetFlag.Checked = false;
            this.chkGetFlag.Enabled = true;
        }

        //{3a23d5ff-8e31-4128-a5cc-736abfbbd056}回车后，只经过性别、联系电话、开住院证医生、入院诊断 by guanyx
        private bool enterFlag = false;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (!this.ucQueryInpatientNo1.TextBox.Focused)
            //{
            //    if (keyData == Keys.Enter)
            //    {
            //        SendKeys.Send("{TAB}");
            //        return true;
            //    }
            //}
            //els
            //{
            //    return false;
            //}
            if (this.cmbSex.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.chkGetFlag.Enabled == true)
                    { 
                        this.chkGetFlag.Focus(); 
                    }
                    else {
                        this.txtLinkPhone.Focus();
                    }
                    return true;
                }
            }
            if (this.chkGetFlag.Focused) {
                if (keyData == Keys.Enter) {
                    this.txtLinkPhone.Focus();
                    return true;
                }
            }
            if (this.txtLinkPhone.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.cmbPreDoctor.Focus();
                    return true;
                }
            }
            if (this.cmbPreDoctor.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.txtInDiagnosis.Focus();
                    return true;
                }
            }
            if (this.txtInDiagnosis.Focused && enterFlag == true)
            {
                if (keyData == Keys.Enter)
                {
                    this.Confirm();
                    //{614A067A-5EE9-4917-908E-3D54E2998CFE}接诊完成后一个患者光标返回住院号处by guanyx
                    this.ucQueryInpatientNo1.Focus();
                    return true;
                }
            }
            if (this.txtInDiagnosis.Focused && enterFlag == false)
            {
                if (keyData == Keys.Enter)
                {
                    enterFlag = true;
                    this.txtInDiagnosis.Focus();
                    return true;
                }
            }

            return base.ProcessDialogKey(keyData);
        }


        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();



            if (this.dtpBirthDay.Value > nowTime)
            {

                //MessageBox.Show(Language.Msg("患者的生日不能大于当前系统时间!"));

                this.dtpBirthDay.Value = nowTime;

                return;
            }

            this.txtAge.Text = this.inpatientManager.GetAge(this.dtpBirthDay.Value);
        }

        protected void Print()
        {
            if (patientInfo == null)
            {
                MessageBox.Show("请输入患者");
                return;
            }
            # region 打印病案
            DialogResult rs = MessageBox.Show(Language.Msg("是否打印病案?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Neusoft.HISFC.Models.HealthRecord.Base parmPatientinfo = new Neusoft.HISFC.Models.HealthRecord.Base();
                parmPatientinfo.PatientInfo = this.patientInfo;

                this.healthPrint.ControlValue(parmPatientinfo);
                //this.healthPrint.PrintPreview();
                this.healthPrint.Print();
            }
            #endregion
        }



       #region {3a23d5ff-8e31-4128-a5cc-736abfbbd056} 诊断的处理
        private void txtInDiagnosis_TextChanged(object sender, EventArgs e)
        {
            if (ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Filter(this.txtInDiagnosis.Text.Trim());
            }
        }
        /// <summary>
        ///诊断业务层
        /// </summary>
        Neusoft.HISFC.Models.HealthRecord.ICD MyIcd = null;

        private int ucDiagnose1_SelectItem(Keys key)
        {
            int result = this.ucDiagnose1.GetItem(ref MyIcd);
            if (result < 0)
                return -1;
            SetValue();
            return 1;
        }

        /// <summary>
        /// 键盘事件处理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.PriorRow();
                        break;
                    }
                case Keys.Down:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.NextRow();
                        break;
                    }
                case Keys.Escape:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.Visible = false;
                        break;
                    }
                case Keys.Space:
                    {
                        if (this.txtInDiagnosis.ContainsFocus)
                        {
                            this.ucDiagnose1.Visible = true;
                            //this.SetLocation();
                        }
                        break;
                    }

                case Keys.Enter:
                    {
                        if (this.txtInDiagnosis.ContainsFocus)
                        {
                            if (this.ucDiagnose1.Visible)
                            {
                                if (ucDiagnose1_SelectItem(Keys.Enter) == 0)
                                {
                                    SetValue();
                                }
                            }
                        }
                        break;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        ///// <summary>
        ///// 设置诊断控件显示
        ///// </summary>
        //private void SetLocation()
        //{
        //    if (this.ucDiagnose1.Visible)
        //        return;
        //    this.ucDiagnose1.Top = this.neuGroupBox2.Top + this.txtInDiagnosis.Top + this.txtInDiagnosis.Height;
        //    this.ucDiagnose1.Left = this.neuGroupBox2.Left + this.txtInDiagnosis.Left;
        //    this.ucDiagnose1.Visible = true;
        //}
        /// <summary>
        /// 设置诊断value
        /// </summary>
        private void SetValue()
        {
            this.txtInDiagnosis.Text = this.MyIcd.Name;
            this.txtInDiagnosis.Tag = this.MyIcd.ID;
            this.ucDiagnose1.Visible = false;
            this.txtInDiagnosis.Focus();
        }

       #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IPatientWristletPrint);

                return type;
            }
        }


        /// <summary>
        /// 打印结算发票
        /// </summary>
        protected int PrintPatientWristlet()
        {
            Neusoft.HISFC.BizProcess.Interface.IPatientWristletPrint p = null;

            try
            {
                if (!string.IsNullOrEmpty(this.patientInfo.ID))
                {
                    p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IPatientWristletPrint))
                            as Neusoft.HISFC.BizProcess.Interface.IPatientWristletPrint;
                    p.SetValue(this.patientInfo);
                    return p.Print();

                }
                else
                {
                    MessageBox.Show("请选择患者！");
                }
            }
            catch 
            {

            }

            return -1;
        }

        #endregion
    }
}
