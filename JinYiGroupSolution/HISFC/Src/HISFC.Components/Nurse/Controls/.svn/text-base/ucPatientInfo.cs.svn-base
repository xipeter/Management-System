using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Nurse.Controls
{
    /// <summary>
    /// [功能描述: 患者信息]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientInfo()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitControl();
            return base.OnInit(sender, neuObject, param);
        }
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.ClearPatintInfo();
            this.SetPatientInfo(e.Tag as Neusoft.HISFC.Models.Registration.Register);
            return base.OnSetValue(neuObject, e);
        }
        protected Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration Outpatient = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        protected Neusoft.HISFC.Models.Registration.Register register = null;
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();


        #region 属性
        /// <summary>
        /// 性别是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("性别是否允许修改")]
        public bool SexReadOnly
        {
            get
            {
                return cmbSex.Enabled;
            }
            set
            {
                cmbSex.Enabled = value;
            }
        }
        /// <summary>
        /// 生日是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("生日是否允许修改")]
        public bool BirthdayReadOnly
        {
            get
            {
                return dtBirthday.Enabled;
            }
            set
            {
                dtBirthday.Enabled = value;
            }
        }
       
        /// <summary>
        /// 身份证号是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("身份证号是否允许修改")]
        public bool IDReadOnly
        {
            get
            {
                return txtID.Enabled;
            }
            set
            {
                txtID.Enabled = value;
            }
        }
        /// <summary>
        /// 职业是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("职业是否允许修改")]
        public bool ProfessionReadOnly
        {
            get
            {
                return cmbProfession.Enabled;
            }
            set
            {
                cmbProfession.Enabled = value;
            }
        }
        /// <summary>
        /// 职业是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("婚姻是否允许修改")]
        public bool MarryReadOnly
        {
            get
            {
                return cmbMarry.Enabled;
            }
            set
            {
                cmbMarry.Enabled = value;
            }
        }
        /// <summary>
        /// 家庭住址是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("家庭住址是否允许修改")]
        public bool HomeAddrReadOnly
        {
            get
            {
                return cmbHomeAddr.Enabled;
            }
            set
            {
                cmbHomeAddr.Enabled = value;
            }
        }
        /// <summary>
        /// 家庭电话是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("家庭电话是否允许修改")]
        public bool HomeTelReadOnly
        {
            get
            {
                return txtHomeTel.Enabled;
            }
            set
            {
                txtHomeTel.Enabled = value;
            }
        }
        /// <summary>
        /// 工作单位是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("工作单位是否允许修改")]
        public bool WorkReadOnly
        {
            get
            {
                return txtWork.Enabled;
            }
            set
            {
                txtWork.Enabled = value;
            }
        }
        /// <summary>
        /// 联系人是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人是否允许修改")]
        public bool LinkManReadOnly
        {
            get
            {
                return txtLinkMan.Enabled;
            }
            set
            {
                txtLinkMan.Enabled = value;
            }
        }
        /// <summary>
        /// 联系人地址是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人地址是否允许修改")]
        public bool KinAddressReadOnly
        {
            get
            {
                return cmbKinAddress.Enabled;
            }
            set
            {
                cmbKinAddress.Enabled = value;
            }
        }
        /// <summary>
        /// 联系人电话是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人电话是否允许修改")]
        public bool LinkTelReadOnly
        {
            get
            {
                return txtLinkTel.Enabled;
            }
            set
            {
                txtLinkTel.Enabled = value;
            }
        }
        /// <summary>
        /// 联系人关系是否允许修改
        /// </summary>
       
        
        #endregion 

        /// <summary>
        /// 初始化控件
        /// </summary>
        protected void InitControl()
        {
            try
            {
               
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
                this.cmbSex.IsListOnly = true;
                this.cmbMarry.AddItems(Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List());
                this.cmbMarry.IsListOnly = true;
                this.cmbProfession.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PROFESSION));
                this.cmbProfession.IsListOnly = true;
                this.cmbKinAddress.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));
                this.cmbHomeAddr.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));
                this.txtWork.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));

                //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
                //this.cmbPact.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT));
                this.cmbPact.AddItems(manager.QueryPactUnitAll());
                this.cmbPact.IsListOnly = true;

       
            }
            catch { }

        }


        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="patientInfo"></param>
        protected void SetPatientInfo(Neusoft.HISFC.Models.Registration.Register register)
        {
            this.register = register;
            Neusoft.HISFC.Models.Registration.Register Register = register;
            this.txtPatientNo.Text = Register.ID;				//留观号
            this.txtCard.Text = Register.PID.CardNO;				//门诊卡号
            this.txtName.Text = Register.Name;					//患者姓名
            this.txtWork.Text = Register.CompanyName;			//单位名称		
            this.txtHomeTel.Text = Register.PhoneHome;			//家庭电话
            this.cmbHomeAddr.Text = Register.AddressHome;		//家庭住址
            this.cmbMarry.Tag = Register.MaritalStatus.ID;		//婚否
            this.cmbSex.Tag = Register.Sex.ID;					//性别
            this.cmbProfession.Tag = Register.Profession.ID;    //职业
            this.dtBirthday.Value = Register.Birthday;			//出生日期
            this.txtDeptName.Text = Register.DoctorInfo.Templet.Dept.Name;//科室名称
            this.dtIndate.Text = Register.PVisit.InTime.ToString("yyyy年MM月dd日");				//入院日期
            this.txtID.Text = Register.SSN;						//身份证号
            this.cmbPact.Text = Register.Pact.Name; 			//合同单位名称
            this.cmbPact.Tag = Register.Pact.ID;					//合同单位代码
           
        }


        /// <summary>
        /// 清空控件内容
        /// </summary>
        public void ClearPatintInfo()
        {
            this.txtPatientNo.Text = "";	//住院号
            this.txtName.Text = "";			//患者姓名
            this.txtWork.Text = "";			//工作单位
            this.txtHomeTel.Text = "";		//家庭电话
            this.cmbHomeAddr.Text = "";
            this.cmbMarry.Tag = "";
            this.cmbSex.Tag = "";
            this.cmbProfession.Text = "";
            this.dtBirthday.Value = System.DateTime.Now;
            //后补充----wangrc
            this.cmbPact.Text = "";          //合同单位
            this.cmbPact.Tag = null;
            this.txtLinkMan.Text = "";      //联系人
            this.txtLinkTel.Text = "";      //联系人电话
            this.cmbKinAddress.Text = "";   //联系人地址
            this.txtID.Text = "";           //身份证号
           
            this.txtCard.Text = "";         //门诊卡号
            this.txtDeptName.Text = "";	//患者所在科室
            
        }


        /// <summary>
        /// 获得患者基本信息从控件到PatientInfo
        /// </summary>
        /// <param name="PatientInfo"></param>
        protected bool GetPatientInfo(Neusoft.HISFC.Models.Registration.Register Register)
        {
            Register.ID = this.txtPatientNo.Text;				//留观号
            Register.Card.ID = this.txtCard.Text;				//门诊卡号
            Register.Name = this.txtName.Text;					//患者姓名
            Register.CompanyName = this.txtWork.Text;			//单位名称		
            Register.PhoneHome = this.txtHomeTel.Text;			//家庭电话
            Register.AddressHome = this.cmbHomeAddr.Text;		//家庭住址
            Register.MaritalStatus.ID = this.cmbMarry.Tag;		//婚否
            Register.Sex.ID = this.cmbSex.Tag;					//性别
            Register.Profession.ID = this.cmbProfession.Tag.ToString();    //职业
            Register.Birthday = this.dtBirthday.Value;			//出生日期
            Register.DoctorInfo.Templet.Dept.Name = this.txtDeptName.Text;//科室名称
            Register.PVisit.InTime = DateTime.Parse(this.dtIndate.Text);		//入院日期
            Register.SSN = this.txtID.Text;						//身份证号
            Register.Pact.Name = this.cmbPact.Text; 			//合同单位名称
            Register.Pact.ID = this.cmbPact.Tag.ToString();			    //合同单位代码

            if (this.CheckIDInfo(this.txtID.Text.Trim()) == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查身份证号的有效性，并根据身份证号校验出生日期
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected int CheckIDInfo(string ID)
        {
            if (ID != "")
            {
                int result = 0;
                string errText = string.Empty;
                result = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(ID, ref errText);
                if (result == -1)
                {
                    MessageBox.Show(errText);
                    return -1;
                }
                int idlength = ID.Length;
                int year = 0;
                int month = 0;
                int day = 0;
                DateTime dtBirth = System.DateTime.Now;
                if (idlength == 15)
                {
                    year = Convert.ToInt32("19" + ID.Substring(6, 2));
                    month = Convert.ToInt32(ID.Substring(8, 2));
                    day = Convert.ToInt32(ID.Substring(10, 2));
                }
                else
                {
                    year = Convert.ToInt32(ID.Substring(6, 4));
                    month = Convert.ToInt32(ID.Substring(10, 2));
                    day = Convert.ToInt32(ID.Substring(12, 2));
                }
                dtBirth = new DateTime(year, month, day);
                
                if (this.dtBirthday.Value.CompareTo(dtBirth) != 0)
                {
                    this.dtBirthday.Value = dtBirth;
                    MessageBox.Show("系统根据您输入的身份证号重算了出生日期，请确认无误后再进行保存！");
                    return -1;
                }
                return 1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 刷新患者信息
        /// </summary>
        /// <param name="patient"></param>
        public void RefreshList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.RefreshList(patient.ID);
        }


        /// <summary>
        /// 根据留观流水号刷新患者信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        public void RefreshList(string clinicNO)
        {
            Neusoft.HISFC.Models.Registration.Register obj = null;
            obj = this.Outpatient.GetByClinic(clinicNO);
            if (obj == null)
            {
                MessageBox.Show(this.Outpatient.Err);
                return;
            }
           

            //只有出院登记的患者才显示"出院通知单"按钮
            if (obj.PVisit.InState.ID.ToString() == "B")
            {
                
                this.btnOutBill.Visible = true;
            }
            else
            {
                this.btnOutBill.Visible = false;
              
            }
            try
            {
                this.SetPatientInfo(obj);
            }
            catch { }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            //取控件中修改后的患者信息
            if (!GetPatientInfo(register)) return -1;

            Neusoft.HISFC.Models.RADT.Patient obj = (Neusoft.HISFC.Models.RADT.Patient)register;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.radtManager.UpdatePatient((Neusoft.HISFC.Models.RADT.PatientInfo)obj) == 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功！", "提示");
                base.OnRefreshTree();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败！" + this.radtManager.Err, "提示");
                return -1;
            }
            return 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }
  
    }
}
