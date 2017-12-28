using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration.SelfReg
{
    /// <summary>
    /// [功能描述: 自助挂号患者信息显示控件]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2009-9]<br></br>
    /// <说明
    ///		贵港本地化
    ///  />
    /// </summary>
    public partial class ucSelfHelpPatientInfo : UserControl
    {
        public ucSelfHelpPatientInfo()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 住院患者信息实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = null;//new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 国籍帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper nationHelper = new Neusoft.FrameWork.Public.ObjectHelper();


        /// <summary>
        /// 工作单位
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper workHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// home
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper homeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// cardType
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper cardTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();



        #endregion

        #region 属性
        /// <summary>
        /// 住院患者信息实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set
            {
                this.patientInfo = value;
                //患者患者进本信息
                this.SetPatientInfo();
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// 
        private void SetPatientInfo()
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
            //this.cmbArea.Tag = this.patientInfo.AreaCode;            //地区
            this.cmbCountry.Tag = this.patientInfo.Country.ID;       //国籍
            this.cmbCountry.Text = this.nationHelper.GetName(this.patientInfo.Country.ID);
            //this.cmbNation.Tag = this.patientInfo.Nationality.ID;    //民族
            this.dtpBirthDay.Text = this.patientInfo.Birthday.ToString("yyyy-MM-dd");      //出生日期
            //this.txtAge.Text = this.accountManager.GetAge(this.patientInfo.Birthday);//年龄
            //this.cmbDistrict.Text = this.patientInfo.DIST;            //籍贯
            //this.cmbProfession.Tag = this.patientInfo.Profession.ID; //职业
            this.txtIDNO.Text = this.patientInfo.IDCard;             //身份证号
            this.cmbWorkAddress.Text = this.patientInfo.CompanyName; //工作单位
            //this.txtWorkPhone.Text = this.patientInfo.PhoneBusiness; //单位电话
            //this.cmbMarry.Tag = this.patientInfo.MaritalStatus.ID.ToString();//婚姻状况
            this.cmbHomeAddress.Text = this.patientInfo.AddressHome;  //家庭住址
            //this.txtHomePhone.Text = this.patientInfo.PhoneHome;     //家庭电话
            //this.txtLinkMan.Text = this.patientInfo.Kin.Name;        //联系人 
            //this.cmbRelation.Tag = this.patientInfo.Kin.Relation.ID; //联系人关系
            //this.cmbLinkAddress.Text = this.patientInfo.Kin.RelationAddress;//联系人地址
            //this.txtLinkPhone.Text = this.patientInfo.Kin.RelationPhone;//联系人电话
            //this.ckEncrypt.Checked = this.patientInfo.IsEncrypt; //是否加密姓名
            //this.ckVip.Checked = this.patientInfo.VipFlag;//是否vip
            //this.txtMatherName.Text = this.patientInfo.MatherName;//母亲姓名
            //this.cmbCardType.Tag = this.patientInfo.IDCardType.ID; //证件类型
            //this.txtSiNO.Text = this.patientInfo.SSN;//社会保险号
          
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int InitInfo()
        {
            this.managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            //性别列表
            //this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
            this.cmbSex.Text = "男";
          
            //国家
            //this.cmbCountry.AddItems(managerIntegrate.GetConstantList(EnumConstant.COUNTRY));
            ArrayList alNation = managerIntegrate.GetConstantList(EnumConstant.COUNTRY);
            this.nationHelper.ArrayObject = alNation;

            //工作单位
            //this.cmbWorkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.WORKNAME));

            ArrayList alWork = this.managerIntegrate.GetConstantList(EnumConstant.WORKNAME);
            this.workHelper.ArrayObject = alWork;

                   //家庭住址信息
            //this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));
            ArrayList alHome = this.managerIntegrate.GetConstantList(EnumConstant.AREA);
            this.homeHelper.ArrayObject = alHome;


            //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //this.cmbPact.AddItems(managerIntegrate.QueryPactUnitAll());

            //证件类型
            //this.cmbCardType.AddItems(managerIntegrate.QueryConstantList("IDCard"));
            ArrayList alCardType = managerIntegrate.QueryConstantList("IDCard");
            cardTypeHelper.ArrayObject = alCardType;

            //foreach (Control var in this.neuGroupBox1.Controls)
            //{
            //    if (var.GetType() != typeof(Neusoft.FrameWork.WinForms.Controls.NeuLabel))
            //    {
            //        var.Enabled = false;
            //    }
            //}

            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            foreach (Control var in this.neuGroupBox1.Controls)
            {
                if (var.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                {
                    var.Tag = "";
                    var.Text = "";
                }
                if (var.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuTextBox))
                {
                    var.Text = "";
                }
            }
            return 1;
        }

        /// <summary>
        /// 初始换信息
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() != "devenv.exe")
            //{
            if (!this.DesignMode)
            {
                this.InitInfo();
            }
            base.OnLoad(e);
        }
        #endregion

    }
}
