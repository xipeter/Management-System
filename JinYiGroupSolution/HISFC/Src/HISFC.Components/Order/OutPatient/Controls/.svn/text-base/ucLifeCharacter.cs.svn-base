using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucLifeCharacter : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucLifeCharacter()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 体温实体
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.LifeCharacter lifeCharacter = new Neusoft.HISFC.Models.RADT.LifeCharacter();

        /// <summary>
        /// 操作员
        /// </summary>
        protected Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        /// <summary>
        /// 挂号信息实体
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register patientInfo = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 患者体温业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT lfchManagement = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Order.OutPatient.Order OrderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
                
        #endregion

        
        #region 属性

        /// <summary>
        /// 患者挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            set 
            {
                this.patientInfo = value;
            }
        }

        #endregion

        #region 方法

        private void Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            this.patientInfo = regMgr.GetByClinic("11882");
            this.SetPatient();
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.patientInfo = new Neusoft.HISFC.Models.Registration.Register();
            this.lblName.Text = Neusoft.FrameWork.Management.Language.Msg("姓名： ");
            this.lblSex.Text = Neusoft.FrameWork.Management.Language.Msg("性别： ");
            this.lblAge.Text = Neusoft.FrameWork.Management.Language.Msg("年龄： ");
            this.lblRegDate.Text = Neusoft.FrameWork.Management.Language.Msg("挂号时间： ");
            this.lblRegDept.Text = Neusoft.FrameWork.Management.Language.Msg("挂号科室： ");
            this.lblRegDoct.Text = Neusoft.FrameWork.Management.Language.Msg("挂号医生： ");
            this.lblRegLV.Text = Neusoft.FrameWork.Management.Language.Msg("挂号级别： ");
        }

        /// <summary>
        /// 显示患者信息
        /// </summary>
        private void SetPatient()
        {
            if (this.patientInfo == null)
            {
                return;
            }
            this.lblName.Text = Neusoft.FrameWork.Management.Language.Msg("姓名： ") + this.patientInfo.Name;
            this.lblSex.Text = Neusoft.FrameWork.Management.Language.Msg("性别： ") + this.patientInfo.Sex.Name;
            this.lblAge.Text = Neusoft.FrameWork.Management.Language.Msg("年龄： ") + this.OrderManagement.GetAge(this.patientInfo.Birthday);
            this.lblRegDate.Text = Neusoft.FrameWork.Management.Language.Msg("挂号时间： ") + this.patientInfo.DoctorInfo.SeeDate.ToShortDateString();
            this.lblRegDept.Text = Neusoft.FrameWork.Management.Language.Msg("挂号科室： ") + this.patientInfo.DoctorInfo.Templet.Dept.Name;
            this.lblRegDoct.Text = Neusoft.FrameWork.Management.Language.Msg("挂号医生： ") + this.patientInfo.DoctorInfo.Templet.Doct.Name;
            this.lblRegLV.Text = Neusoft.FrameWork.Management.Language.Msg("挂号级别： ") + this.patientInfo.DoctorInfo.Templet.RegLevel.Name;
        }

        /// <summary>
        /// 生成体温实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.RADT.LifeCharacter SetLifeCharacter()
        {
            //体温实体
            Neusoft.HISFC.Models.RADT.LifeCharacter myLifeCharacter = new Neusoft.HISFC.Models.RADT.LifeCharacter();
            try
            {
                myLifeCharacter.ID = this.patientInfo.ID;
                myLifeCharacter.Name = this.patientInfo.Name;
                myLifeCharacter.Dept.ID = oper.Dept.ID;
                myLifeCharacter.Dept.Name = oper.Dept.Name;
                myLifeCharacter.NurseStation.ID = oper.Nurse.ID;
                myLifeCharacter.NurseStation.Name = oper.Nurse.Name;
                myLifeCharacter.BedNO = "";
                myLifeCharacter.PID.PatientNO = this.patientInfo.PID.CardNO;
                //myLifeCharacter.InDate = DateTime.Now;
                myLifeCharacter.MeasureDate = this.OrderManagement.GetDateTimeFromSysDateTime();
                myLifeCharacter.Breath = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtBreath.Text);
                myLifeCharacter.Temperature = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTemperature.Text);
                myLifeCharacter.Pulse = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPulse.Text);
                myLifeCharacter.HighBloodPressure = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtHighBP.Text);
                myLifeCharacter.LowBloodPressure = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtLowBP.Text);
                myLifeCharacter.Time = 0;
                myLifeCharacter.IsForceHypothermia = false;
                myLifeCharacter.TargetTemperature = 0;
                myLifeCharacter.TemperatureType = "腋温";
                myLifeCharacter.Memo = this.txtRemark.Text.ToString().Trim();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("体温信息实体附值失败！") + ex.Message);
                return null;
            }
            return myLifeCharacter;
        }

        /// <summary>
        /// 校验数据有效性
        /// </summary>
        /// <param name="lfch"></param>
        /// <returns></returns>
        private int CheckData(Neusoft.HISFC.Models.RADT.LifeCharacter lfch)
        {
            if (lfch.ID == "" || lfch.ID == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("非法的患者信息！"));
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtRemark.Text.ToString().Trim(),80))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("备注超长！"));
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private int SaveData()
        {
            Neusoft.HISFC.Models.RADT.LifeCharacter lfch = new Neusoft.HISFC.Models.RADT.LifeCharacter();
            lfch = this.SetLifeCharacter();
            if (this.CheckData(lfch) < 0)
            {
                return -1;
            }
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            lfchManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans); //设置事务
            int iReturn = lfchManagement.InsertLifeCharacter(lfch);
            if (iReturn < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败！") + this.lfchManagement.Err);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功！"));
            return 0;
        }

        #endregion

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.SaveData();            
        }

        private void ucLifeCharacter_Load(object sender, EventArgs e)
        {
            this.Init();
            //this.txtClinicInput1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtClinicInput1_KeyUp);
            //this.txtClinicInput1.KeyDown += new KeyEventHandler(txtClinicInput1_KeyDown);
            //this.txtClinicInput1.selectedEvents += new Neusoft.HISFC.Components.Common.Controls.selectedEventDelegate(txtClinicInput1_selectedEvents);
        }

        //private void txtClinicInput1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.OemQuestion)
        //    {
        //        if (this.txtClinicInput1.Text.StartsWith("/"))
        //            this.txtClinicInput1.IsExecQuery = false;
        //    }
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (this.txtClinicInput1.Text.StartsWith("/"))
        //            this.txtClinicInput1.IsExecQuery = false;
        //        else
        //            this.txtClinicInput1.IsExecQuery = true;
        //    }
            
        //}

        //private void txtClinicInput1_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (this.txtClinicInput1.Text.StartsWith("/"))
        //        {
        //            DialogResult r = MessageBox.Show("是否为该患者补入挂号信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        //            if (r == DialogResult.Yes)
        //            {
        //                string name = this.txtClinicInput1.Text.Remove(0, 1);
        //                Neusoft.HISFC.Components.Common.Forms.frmRegistrationByDoctor frmDoctRegistration = new Neusoft.HISFC.Components.Common.Forms.frmRegistrationByDoctor(name);
        //                frmDoctRegistration.ShowDialog();
        //                this.txtClinicInput1.Text = frmDoctRegistration.PatientInfo.PID.CardNO;
        //                //this.txtClinicInput1.IsExecQuery = true;
        //            }
        //            else
        //            {
        //                this.txtClinicInput1.Text = "";
                        
        //            }
        //        }
        //    }
        //}

        
    }
}

