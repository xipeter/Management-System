using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Forms
{
    public partial class frmRegistrationByDoctor : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmRegistrationByDoctor(string patientName)
        {
            InitializeComponent();
            this.txtName.Text = patientName;
        }

        #region 变量
        /// <summary>
        /// 自动生成的卡号
        /// </summary>
        protected string autoCardNO = string.Empty;
        /// <summary>
        /// 门诊流水号
        /// </summary>
        protected string clinicNO = string.Empty;
        /// <summary>
        /// 没有挂号患者,卡号第一位标志,默认以9开头
        /// </summary>
        protected string noRegFlagChar = "9";
        /// <summary>
        /// 挂号信息实体
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
        /// <summary>
        /// 门诊医嘱业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        /// <summary>
        /// 合同单位业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager pactManagement = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManagement = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        /// <summary>
        /// 操作员
        /// </summary>
        protected Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        #endregion

        #region 属性

        /// <summary>
        /// 患者挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get
            {
                return this.register;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitControl()
        {
            //初始化合同单位
            ArrayList pactList = this.pactManagement.QueryPactUnitAll();
            if (pactList == null)
            {
                MessageBox.Show("初始化合同单位出错!" + this.pactManagement.Err);

                return;
            }
            this.cmbPact.AddItems(pactList);

            //初始化性别
            this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());

            //获得卡号前补位规则
            this.noRegFlagChar = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");

            this.autoCardNO = this.feeManagement.GetAutoCardNO();
            if (autoCardNO == string.Empty || autoCardNO == "" || autoCardNO == null)
            {
                MessageBox.Show("获得门诊卡号出错!" + this.feeManagement.Err);

                return;
            }
            autoCardNO = this.noRegFlagChar + autoCardNO;
            this.txtCardNo.Text = this.autoCardNO;

            this.clinicNO = this.orderManagement.GetSequence("Registration.Register.ClinicID");
            if (clinicNO == string.Empty || clinicNO == "" || clinicNO == null)
            {
                MessageBox.Show("获得门诊就诊号出错!" + this.orderManagement.Err);

                return;
            }

            this.cmbSex.Tag = "M";

            //this.cmbPact.Tag = "1";
            this.cmbPact.Tag = "01";

        }

        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Register SetRegister()
        {
            DateTime now = this.orderManagement.GetDateTimeFromSysDateTime();
            this.register.ID = clinicNO;
            this.register.Name = this.txtName.Text.Trim();
            this.register.Card.ID = autoCardNO;
            this.register.PID.CardNO = autoCardNO;
            this.register.Pact.PayKind.ID = "01";
            #region 医生补填患者信息时，合同单位编码赋值错误 {E461C374-9EE5-4872-94D4-68B1C6BD0BED} wbo 2011-02-10
            //this.register.Pact.ID = "1";
            //this.register.Pact.Name = this.cmbPact.Text;
            this.register.Pact.ID = this.cmbPact.SelectedItem.ID;
            this.register.Pact.Name = this.cmbPact.SelectedItem.Name;
            #endregion
            this.register.Sex.ID = this.cmbSex.Tag.ToString();
            //年龄赋值错误 {E461C374-9EE5-4872-94D4-68B1C6BD0BED} wbo 2011-02-10
            this.register.Birthday = this.dtPickerBirth.Value;//now.AddYears(-20);
            this.register.DoctorInfo.SeeDate = now;
            this.register.DoctorInfo.SeeNO = -1;
            this.register.DoctorInfo.Templet.Dept = this.employee.Dept;
            //挂免费号时默认操作员为医生 {239D9283-3B86-4bea-85C2-C43182879594} wbo 2011-03-17
            this.register.DoctorInfo.Templet.Doct.ID = this.employee.ID;
            this.register.DoctorInfo.Templet.Doct.Name = this.employee.Name;

            return this.register;
        }

        /// <summary>
        /// 有效性校验
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        private bool CheckRegister(Neusoft.HISFC.Models.Registration.Register reg)
        {
            if (reg.ID.Trim() == "" || reg.ID == null)
            {
                MessageBox.Show("门诊就诊号不可为空！");
                return false;
            }
            if (reg.Name.Trim() == "" || reg.Name == null)
            {
                MessageBox.Show("姓名不可为空！");
                return false;
            }
            if (reg.PID.CardNO.Trim() == "" || reg.PID.CardNO == null)
            {
                MessageBox.Show("门诊卡号不可为空！");
                return false;
            }
            if (reg.Sex.ID.ToString().Trim() == "" || reg.Sex.ID == null)
            {
                MessageBox.Show("性别不可为空！");
                return false;
            }
            return true;
        }

        private int InsertRegInfo(Neusoft.HISFC.Models.Registration.Register reg)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(orderManagement.Connection);
            //t.BeginTransaction();
            this.regManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int iReturn = -1;
            reg.InputOper.ID = this.employee.ID;
            reg.InputOper.Name = this.employee.Name;
            //reg.InputOper.OperTime = reg.DoctorInfo.SeeDate;
            iReturn = this.regManagement.InsertByDoct(reg);
            if (iReturn == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (regManagement.DBErrCode != 1)//不是主键重复
                {
                    MessageBox.Show("插入挂号信息出错!" + regManagement.Err);

                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("请记录病历号:" + reg.PID.CardNO + ",以便门诊交费!", "提示");
            return iReturn;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            this.SetRegister();
            if (this.CheckRegister(this.register))
            {
                if (this.InsertRegInfo(this.register) > 0)
                {
                    this.Close();
                }
            }
            
        }

        private void frmRegistrationByDoctor_Load(object sender, EventArgs e)
        {
            this.InitControl();
        }

        private void btnCaecel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 医生补录患者信息支持回车跳转 {81695BF2-51F3-4510-BB66-6DC490D46947} wbo 2011-02-11
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbSex.Focus();
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtPickerBirth.Focus();
            }
        }

        private void dtPickerBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }
        #endregion
    }
}

