using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.RADT.Controls
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
            this.SetPatientInfo(neuObject as Neusoft.HISFC.Models.RADT.PatientInfo);
            return base.OnSetValue(neuObject, e);
        }
        protected Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        protected Neusoft.HISFC.BizLogic.RADT.InPatient Inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;

        //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
        //Neusoft.HISFC.BizProcess.Integrate.Manager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
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
        /// 身高是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("身高是否允许修改")]
        public bool HeightReadOnly
        {
            get
            {
                return txtHeight.Enabled;
            }
            set
            {
                txtHeight.Enabled = value;
            }
        }
        /// <summary>
        /// 体重是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("体重是否允许修改")]
        public bool WeightReadOnly
        {
            get
            {
                return txtWeight.Enabled;
            }
            set
            {
                txtWeight.Enabled = value;
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
        [Category("患者基本信息"), Description("联系人关系是否允许修改")]
        public bool RelationReadOnly
        {
            get
            {
                return cmbRelation.Enabled;
            }
            set
            {
                cmbRelation.Enabled = value;
            }
        }
        /// <summary>
        /// 特注处理是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("特注处理是否允许修改")]
        public bool MemoReadOnly
        {
            get
            {
                return cmbMemo.Enabled;
            }
            set
            {
                cmbMemo.Enabled = value;
            }
        }
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
                this.cmbRelation.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.RELATIVE));
                this.cmbRelation.IsListOnly = true;
                this.cmbKinAddress.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));
                this.cmbHomeAddr.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));
                this.txtWork.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.AREA));
                this.cmbMemo.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.REMARK));
                this.cmbMemo.IsListOnly = true;
                //合同单位
                //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
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
        protected void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.patientInfo = patientInfo;
            Neusoft.HISFC.Models.RADT.Patient Patient = patientInfo;
       
            this.txtPatientNo.Text = Patient.PID.PatientNO;				//住院号
            this.txtCard.Text = patientInfo.PID.CardNO;				//门诊卡号
            this.txtName.Text = Patient.Name;								//患者姓名
            this.txtWork.Text = Patient.CompanyName;						//单位名称		
            this.txtHomeTel.Text = Patient.PhoneHome;						//家庭电话
            this.cmbHomeAddr.Text = Patient.AddressHome;					//家庭住址
            this.cmbMarry.Tag = Patient.MaritalStatus.ID;					//婚否
            this.cmbSex.Tag = Patient.Sex.ID;								//性别
            this.cmbProfession.Tag = Patient.Profession.ID;					//职业
            this.dtBirthday.Value = Patient.Birthday;						//出生日期
            this.txtDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;//科室名称
            this.dtIndate.Text = patientInfo.PVisit.InTime.ToString("yyyy年MM月dd日");				//入院日期
            this.cmbRelation.Tag = patientInfo.Kin.Relation.ID;				//与病人关系编码
            this.cmbKinAddress.Text = patientInfo.Kin.RelationAddress;				//联系人地址
            this.txtLinkTel.Text = patientInfo.Kin.RelationPhone;					//联系人电话
            this.txtLinkMan.Text = patientInfo.Kin.Name;					//联系人姓名
            this.txtID.Text = patientInfo.IDCard;						//身份证号
            this.txtHeight.Text = patientInfo.Height;				//身高
            this.txtWeight.Text = patientInfo.Weight;				//体重
            if (patientInfo.Memo == "")
                this.cmbMemo.Tag = "";
            else
                this.cmbMemo.Text = patientInfo.Memo;						//备注
            this.cmbPact.Text = patientInfo.Pact.Name;				//合同单位名称
            this.cmbPact.Tag = patientInfo.Pact.ID;					//合同单位代码
           
            this.txtDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

          
           
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
            this.txtHeight.Text  = "";       //身高
            this.txtWeight.Text = "";       //体重
            this.txtCard.Text = "";         //门诊卡号
            this.cmbRelation.Text = "";    //联系人关系
            this.cmbMemo.Text = "";        //特注
            this.Enabled = true;
            this.txtDeptName.Text = "";	//患者所在科室
            
        }


        /// <summary>
        /// 获得患者基本信息从控件到PatientInfo
        /// </summary>
        /// <param name="PatientInfo"></param>
        protected bool GetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            patientInfo.PID.PatientNO = this.txtPatientNo.Text;//住院号
            patientInfo.PID.CardNO = this.txtCard.Text;//门诊卡号
            patientInfo.Name = this.txtName.Text;//名子
            patientInfo.Sex.ID = this.cmbSex.Tag;//性别
            patientInfo.Birthday = this.dtBirthday.Value;//出生日期
            
            patientInfo.IDCard = this.txtID.Text;//身份证号
            

            patientInfo.Profession.ID = this.cmbProfession.Tag.ToString();
            patientInfo.MaritalStatus.ID = this.cmbMarry.Tag.ToString();
            patientInfo.AddressHome = cmbHomeAddr.Text;
            patientInfo.PhoneHome = this.txtHomeTel.Text;
            patientInfo.CompanyName = this.txtWork.Text;
            patientInfo.Kin.Relation.ID = this.cmbRelation.Tag.ToString();
            patientInfo.Kin.RelationLink = this.cmbRelation.Text;
            patientInfo.Kin.RelationAddress = this.cmbKinAddress.Text;
            patientInfo.Kin.RelationPhone = this.txtLinkTel.Text;
            patientInfo.Kin.Name = this.txtLinkMan.Text;
            //判断身高是否为数字
            for (int i = 0, j = this.txtHeight.Text.Length; i < j; i++)
            {
                if (!char.IsDigit(this.txtHeight.Text, i))
                {
                    //可以说明是第几个字符错误了
                    MessageBox.Show("身高必须是数字", "提示", MessageBoxButtons.OK);
                    return false;
                }
            }
            patientInfo.Height = this.txtHeight.Text;
            //判断体重是否为数字
            for (int i = 0, j = this.txtWeight.Text.Length; i < j; i++)
            {
                if (!char.IsDigit(this.txtWeight.Text, i))
                {
                    //可以说明是第几个字符错误了
                    MessageBox.Show("体重必须是数字", "提示", MessageBoxButtons.OK);
                    return false;
                }
            }
            patientInfo.Weight = this.txtWeight.Text;
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbMemo.Text, 200))
            {
                MessageBox.Show("特注超长！", "提示", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                patientInfo.Memo = this.cmbMemo.Text;
            }

            patientInfo.Pact.Name = this.cmbPact.Text;
            patientInfo.Pact.ID = this.cmbPact.Tag.ToString();

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
        /// 根据主语流水号刷新患者信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        public void RefreshList(string inpatientNo)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;
            PatientInfo = this.Inpatient.QueryPatientInfoByInpatientNO(inpatientNo);
            if (PatientInfo == null)
            {
                MessageBox.Show(this.Inpatient.Err);
                return;
            }
           

            //只有出院登记的患者才显示"出院通知单"按钮
            if (PatientInfo.PVisit.InState.ID.ToString() == "B")
            {
                
                this.btnOutBill.Visible = true;
            }
            else
            {
                this.btnOutBill.Visible = false;
              
            }
            try
            {
                this.SetPatientInfo(PatientInfo);
            }
            catch { }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (patientInfo == null) return 0;
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;
            try
            {
                PatientInfo = this.Inpatient.QueryPatientInfoByInpatientNO(patientInfo.ID);
                if (PatientInfo == null)
                {
                    MessageBox.Show(this.Inpatient.Err);
                    return -1;
                }

                //如果患者已不在本科,则清空数据---当患者转科后,如果本窗口没有关闭,会出现此种情况
                if (PatientInfo.PVisit.PatientLocation.NurseCell.ID != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID)
                {
                    MessageBox.Show("患者不属于本病区,不能修改此患者信息", "提示");
                    return -1;
                }
            }
            catch { }

            //取控件中修改后的患者信息
            if (!GetPatientInfo(PatientInfo)) return -1;

            if (this.Inpatient.UpdatePatient(PatientInfo) == 1)
            {
                MessageBox.Show("保存成功！", "提示");
                base.OnRefreshTree();

            }
            else
            {
                MessageBox.Show("保存失败！" + this.Inpatient.Err, "提示");
                return -1;
            }
            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }


  

  
  
    }
}
