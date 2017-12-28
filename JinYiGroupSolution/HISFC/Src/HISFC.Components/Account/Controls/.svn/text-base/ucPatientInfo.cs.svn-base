using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Management;
using Neusoft.HISFC.Object.Base;

namespace UFC.Account.Controls
{
    public partial class ucPatientInfo : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucPatientInfo()
        {
            InitializeComponent();
        }


        #region 字段
        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();
        /// <summary>
        /// Acount业务层
        /// </summary>
        private Neusoft.HISFC.Management.Fee.Account accountManager = new Neusoft.HISFC.Management.Fee.Account();

        #endregion

        private Neusoft.HISFC.Object.Account.Account account = new Neusoft.HISFC.Object.Account.Account();

        public Neusoft.HISFC.Object.Account.Account Account
        {
            get
            {
                return this.account;
            }
            set
            {
                this.account = value;

                if (this.account == null) 
                {
                    return;
                }

                if (DesignMode) 
                {
                    return;
                }

                SetPatient();

            }
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            try
            {
                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Object.Base.SexEnumService.List());
                this.cmbSex.Text = "男";

                //民族
                this.cmbNation.AddItems(managerIntegrate.GetConstantList(EnumConstant.NATION));
                this.cmbNation.Text = "汉族";

                //婚姻状态

                this.cmbMarry.AddItems(Neusoft.HISFC.Object.RADT.MaritalStatusEnumService.List());

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


                //生日
                this.dtpBirthDay.Value = this.accountManager.GetDateTimeFromSysDateTime();//出生日期

                //地区
                this.cmbArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //合同单位
                this.cmbPact.AddItems(managerIntegrate.GetConstantList(EnumConstant.PACTUNIT));
                this.cmbPact.IsListOnly = true;


            }
            catch (Exception e)
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            //this.RefreshPatientLists();

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// 
        private void SetPatient()
        {
            this.txtName.Text = this.account.Patient.Name;               //姓名
            this.cmbSex.Text = this.account.Patient.Sex.Name;            //性别
            this.cmbSex.Tag = this.account.Patient.Sex.ID;               //性别
            //  this.txtCardNO.Text = this.account.Patient.PID.CardNO;       //就诊卡号
            //this.txtCardNO.ReadOnly = true;
            this.cmbPact.Text = this.account.Patient.Pact.Name;          //合同单位名称
            this.cmbPact.Tag = this.account.Patient.Pact.ID;             //合同单位ID
            this.cmbPact.IsListOnly = true;
            this.cmbArea.Tag = this.account.Patient.AreaCode;            //地区
            this.cmbCountry.Tag = this.account.Patient.Country.ID;       //国籍
            this.cmbNation.Tag = this.account.Patient.Nationality.ID;    //民族
            this.dtpBirthDay.Value = this.account.Patient.Birthday;      //出生日期
            this.txtAge.Text = this.accountManager.GetAge(this.account.Patient.Birthday);//年龄
            this.cmbDistrict.Tag = this.account.Patient.DIST;            //籍贯
            this.cmbProfession.Tag = this.account.Patient.Profession.ID; //职业
            this.txtIDNO.Text = this.account.Patient.IDCard;             //身份证号
            this.cmbWorkAddress.Text = this.account.Patient.CompanyName; //工作单位
            this.txtWorkPhone.Text = this.account.Patient.PhoneBusiness; //单位电话
            this.cmbMarry.Tag = this.account.Patient.MaritalStatus.ID.ToString();//婚姻状况
            this.cmbHomeAddress.Tag = this.account.Patient.AddressHome;  //家庭住址
            this.txtHomePhone.Text = this.account.Patient.PhoneHome;     //家庭电话
            this.txtLinkMan.Text = this.account.Patient.Kin.Name;        //联系人 
            this.cmbRelation.Tag = this.account.Patient.Kin.Relation.ID; //联系人关系

            this.cmbLinkAddress.Text = this.account.Patient.Kin.RelationAddress;//联系人地址
            this.txtLinkPhone.Text = this.account.Patient.Kin.RelationPhone;//联系人电话

        }

        /// <summary>
        /// 数据合理化校验
        /// </summary>
        /// <returns></returns>
        protected virtual bool InputValid()
        {
            //判断单位电话长度
            if (!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtWorkPhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("单位电话号码长度过长"));
                this.txtWorkPhone.Focus();
                return false;
            }
            //判断家庭电话号码长度
            if (!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("家庭电话号码长度过长"));
                this.txtHomePhone.Focus();
                return false;
            }

            //判断身份证号码长度

            string errText = string.Empty;
            if ((this.txtIDNO.Text.Trim() != null && this.txtIDNO.Text.Trim() != ""))
            {
                if (Neusoft.NFC.Interface.Classes.Function.CheckIDInfo(this.txtIDNO.Text, ref errText) == -1)
                {
                    MessageBox.Show(errText);
                    return false;
                }
            }

            //判断联系电话号码长度
            if (!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtLinkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("联系人电话号码长度过长"));
                this.txtLinkPhone.Focus();
                return false;
            }
            if (!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtLinkMan.Text, 10))
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

            if (this.dtpBirthDay.Value > this.accountManager.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();

                return false;
            }
            return true;
        }

        private Neusoft.HISFC.Object.RADT.PatientInfo GetPatientInfomation()
        {
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
            patientInfo.Name = this.txtName.Text;                           //姓名
            patientInfo.Sex.ID = this.cmbSex.Tag.ToString();                    //性别
            patientInfo.AreaCode = this.cmbArea.Tag.ToString();                 //地区
            patientInfo.Country.ID = this.cmbCountry.Tag.ToString();            //国籍
            patientInfo.Nationality.ID = this.cmbNation.Tag.ToString();         //民族
            patientInfo.Birthday = this.dtpBirthDay.Value;                      //出生日期
            patientInfo.DIST = this.cmbDistrict.Tag.ToString();                 //籍贯
            patientInfo.Profession.ID = this.cmbProfession.Tag.ToString();      //职业
            patientInfo.IDCard = this.txtIDNO.Text;                             //身份证号
            patientInfo.CompanyName = this.cmbWorkAddress.Text;       //工作单位
            patientInfo.PhoneBusiness = this.txtHomePhone.Text;                 //单位电话
            patientInfo.PhoneBusiness = this.txtWorkPhone.Text;                 //单位电话
            patientInfo.MaritalStatus.ID = this.cmbMarry.Tag.ToString();        //婚姻状况 
            patientInfo.AddressHome = this.cmbHomeAddress.Tag.ToString();       //家庭住址
            patientInfo.PhoneHome = this.txtHomePhone.Text;                     //家庭电话
            patientInfo.Kin.Name = this.txtLinkMan.Text;                        //联系人 
            patientInfo.Kin.Relation.ID = this.cmbRelation.Tag.ToString();      //与联系人关系
            patientInfo.Kin.RelationAddress = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.RelationPhone = this.txtLinkPhone.Text;              //联系人电话

            // patientInfo.Memo = this.cmbMark.Tag.ToString();                      //特注
            patientInfo.Kin.User01 = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.Memo = this.txtLinkPhone.Text; //联系人电话

            return patientInfo;
        }

        private void save()
        {
            if (!this.InputValid())
            {
                return;
            }
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = this.GetPatientInfomation();
            if (patientInfo == null)
            {
                MessageBox.Show("患者基本信息实体不能为空");
                return;
            }
            Neusoft.NFC.Management.Transaction trans = new Transaction(this.accountManager.Connection);
            trans.BeginTransaction();
            this.accountManager.SetTrans(trans.Trans);

            int returnValue = this.accountManager.UpdatePatient(patientInfo);
            if (returnValue < 0)
            {
                MessageBox.Show("更新患者基本信息出错" + this.accountManager.Err);
                trans.RollBack();
                return;
            }
            trans.Commit();


            return;
        }

        private void ucPatientInfo_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {

            }
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.save();
        }
    }
}
