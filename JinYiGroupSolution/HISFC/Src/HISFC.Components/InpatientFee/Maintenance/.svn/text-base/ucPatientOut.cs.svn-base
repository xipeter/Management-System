using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// [功能描述: 出院登记组件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientOut : System.Windows.Forms.UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer//{2A467990-BDA3-4cb4-BB89-5801796EBC95} Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientOut()
        {
            InitializeComponent();
        }

        private void ucPatientOut_Load(object sender, EventArgs e)
        {
            this.InitControl();
        }

        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizLogic.Fee.InPatient inpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        //Neusoft.HISFC.BizLogic.RADT.InPatient inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;

         /// <summary>
        /// 参数控制类{28C63B3A-9C64-4010-891D-46F846EA093D}
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
  

        /// <summary>
        /// adt接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;
        #endregion

        #region 函数
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            try
            {
                this.cmbZg.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ZG));
                //出院登记的时间默认为系统时间
                this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
                this.FindForm().Text = "出院登记";
                this.ActiveControl = this.txtPatientNo;
                txtPatientNo.myEvent+=new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(txtPatientNo_myEvent);
            }
            catch { }

        }


        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="PatientInfo"></param>
        protected virtual void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {

            this.txtPatientNo.Text = patientInfo.PID.PatientNO;		//住院号
            this.txtCard.Text = patientInfo.PID.CardNO;	//门诊卡号
            this.txtPatientNo.Tag = patientInfo.ID;				//住院流水号
            this.txtName.Text = patientInfo.Name;						//姓名
            this.txtSex.Text = patientInfo.Sex.Name;					//性别
            this.txtIndate.Text = patientInfo.PVisit.InTime.ToString();	//入院日期
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;	//科室名称
            this.txtDept.Tag = patientInfo.PVisit.PatientLocation.Dept.ID;	//科室编码

            Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND));
            this.txtBalKind.Text = helper.GetName(patientInfo.Pact.PayKind.ID);


            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;	//床号
            this.txtFreePay.Text = patientInfo.FT.LeftCost.ToString();		//剩余预交金
            this.txtTotcost.Text = patientInfo.FT.TotCost.ToString();		//总金额
            this.cmbZg.Tag = patientInfo.PVisit.ZG.ID;						//转归
            //{DDE7D11F-61CF-4e09-BC2D-F49B03446261}
            //传入的patientInfo.PVisit.OutTime是0002-1-1，报错，这样改是否可以？
            if (patientInfo.PVisit.OutTime < this.dtOutDate.MinDate || patientInfo.PVisit.OutTime > this.dtOutDate.MaxDate)
            {
                this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
            }
            else
            {
                this.dtOutDate.Value = patientInfo.PVisit.OutTime;				//出院日期
            }
            // this.dtOutDate.Value = patientInfo.PVisit.OutTime;				//出院日期
            //{DDE7D11F-61CF-4e09-BC2D-F49B03446261}


            //出院登记修改时间处理 {28C63B3A-9C64-4010-891D-46F846EA093D}

            string rtn = this.ctlMgr.QueryControlerInfo("ZY0002");
            if (rtn == null || rtn == "-1" || rtn == "")
            {
                rtn = "0";
            }
            else
            {
                rtn = "1";
            }

            if (rtn == "1")//
            {
               System.Collections.ArrayList alShiftDataInfo = this.radt.QueryPatientShiftInfoNew(this.PatientInfo.ID);

                if (alShiftDataInfo == null)
                {
                    MessageBox.Show("获取变更表记录信息出错");
                    return;
                }

                bool isExitInfo = false;

                foreach (Neusoft.HISFC.Models.Invalid.CShiftData myCShiftDate in alShiftDataInfo)
                {
                    if (myCShiftDate.ShitType == "BB") //有结算召回
                    {
                        this.dtOutDate.Enabled = true;
                        isExitInfo = true;
                        break;


                    }
                }


                this.dtOutDate.Enabled = isExitInfo;


            }
            else
            {
                this.dtOutDate.Enabled = false;
            }


            this.dtOutDate.Focus();
        }


        /// <summary>
        /// 从控件获得出院登记信息
        /// </summary>
        protected virtual void GetOutInfo()
        {
            PatientInfo.PVisit.ZG.ID = this.cmbZg.Tag.ToString();
            PatientInfo.PVisit.ZG.Name = this.cmbZg.Text;
            PatientInfo.PVisit.PreOutTime = this.dtOutDate.Value;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        protected virtual void Clear()
        {
            foreach (Control c in this.neuGroupBox1.Controls)
            { 
                if(c.GetType()==typeof(Neusoft.FrameWork.WinForms.Controls.NeuTextBox))
                {
                    c.Text="";
                }
            }
            this.cmbZg.Text = "";
            this.cmbZg.Tag = "";
            this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
            this.txtPatientNo.Text = "";
            this.txtPatientNo.Focus();
        }
           
        string Err = "";
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public virtual int Save()
        {
            if (cmbZg.Tag == null || cmbZg.Tag.ToString().Trim() == string.Empty)
            {
                this.Err = "请输入出院情况";
                this.cmbZg.Focus();
                return -1;
            }
            //如果患者不是当天出院提示
            if (this.dtOutDate.Value.Date != this.inpatient.GetDateTimeFromSysDateTime().Date)
            {
                DialogResult dr = MessageBox.Show("该患者的出院日期是： " +
                    this.dtOutDate.Value.ToString("yyyy年MM月dd日") + "  是否继续？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No)
                {
                    this.Err = "";
                    return -1;
                }
            }

            if (this.PatientInfo == null || string.IsNullOrEmpty(this.PatientInfo.ID)) 
            {
                this.Err = "请回车确认住院号是否存在!";

                return -1;
            }

            //取患者最新的住院主表信息
            PatientInfo = this.radt.GetPatientInfomation(this.PatientInfo.ID);
            if (PatientInfo == null)
            {
                this.Err = this.radt.Err;
                return -1;
            }
            this.Err = "";

            //如果患者在院状态发生变化,则不允许操作

            string in_State = PatientInfo.PVisit.InState.ID.ToString();
            if (PatientInfo.PVisit.InState.ID.ToString() != "I")
            {
                this.Err = "该患者没有接诊";
                return -1;
            }

            //取出院登记信息
            this.GetOutInfo();
            //{2A467990-BDA3-4cb4-BB89-5801796EBC95}
            Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid obj = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid)) as Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid;
            if (obj != null)
            {
                string err = string.Empty;
                bool bl = obj.IsPatientShiftValid(PatientInfo, Neusoft.HISFC.Models.Base.EnumPatientShiftValid.O, ref err);
                if (!bl)
                {
                    MessageBox.Show(err);
                    return -1;
                }
            }
            //出院登记
            HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
            long returnValue = medcareInterfaceProxy.SetPactCode(this.PatientInfo.Pact.ID);
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            radt.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            medcareInterfaceProxy.BeginTranscation();
          
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获得合同单位失败" + medcareInterfaceProxy.ErrMsg));
                return -1;
            }

            returnValue = medcareInterfaceProxy.Connect();
            {
                if (returnValue != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    medcareInterfaceProxy.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获得合同单位失败" + medcareInterfaceProxy.ErrMsg));
                    return -1;
                }
            }
            medcareInterfaceProxy.BeginTranscation();
            //returnValue = medcareInterfaceProxy.GetRegInfoInpatient(this.PatientInfo);
            //if (returnValue != 1)
            //{
            //    t.RollBack();
            //    medcareInterfaceProxy.Rollback();
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获得患者信息失败" + medcareInterfaceProxy.ErrMsg));
            //    return -1;
            //}
            //出院登记(带改)
            returnValue = medcareInterfaceProxy.LogoutInpatient(this.PatientInfo);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获出院登记失败" + medcareInterfaceProxy.ErrMsg));
                return -1;
            }


            int i = radt.OutPatient(PatientInfo);
            this.Err = radt.Err;
            if (i == -1)　//失败
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                medcareInterfaceProxy.Rollback();
                return -1;
            }
            else if (i == 0)//取消
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                medcareInterfaceProxy.Rollback();
                this.Err = "";
                return 0;
            }
            //zhangjunyi 注释掉 改为commit
            //medcareInterfaceProxy.Rollback(); 
            if (medcareInterfaceProxy.Commit() < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                medcareInterfaceProxy.Rollback();
                this.Err = "医保接口提交事务出错！请检查读卡器连接是否正确";
                return -1;
            }

            #region addby xuewj 2010-3-15

            if (this.adt == null)
            {
                this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
            }
            if (this.adt != null)
            {
                this.adt.DischargeInpatient(this.PatientInfo);
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();



            return 1;
        }
        #endregion

        #region 事件
        private void button1_Click(object sender, System.EventArgs e)
        {
            ((Control)sender).Enabled = false;
            if (this.Save() > 0)//成功
            {
                MessageBox.Show(Err);
                Clear();
                ((Control)sender).Enabled = true;
                return;
            }
            else
            {
                if (Err != "") MessageBox.Show(Err);
            }
            ((Control)sender).Enabled = true;

        }

        private void txtPatientNo_myEvent()
        {
            if (this.txtPatientNo.InpatientNo == null || this.txtPatientNo.InpatientNo.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("没有该住院号,请验证再输入") + this.txtPatientNo.Err);
                this.txtPatientNo.Focus();
                this.txtPatientNo.TextBox.SelectAll();
                return;
            }
            PatientInfo = this.radt.GetPatientInfomation(this.txtPatientNo.InpatientNo);
            if (PatientInfo == null)
            {
                MessageBox.Show(Language.Msg("获得患者基本信息出错!") + this.txtPatientNo.Err);
                this.txtPatientNo.Focus();
                this.txtPatientNo.TextBox.SelectAll();
                return;
            }
            this.SetPatientInfo(PatientInfo);
            
        }

        private void dtOutDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cmbZg.Focus();
            }
        }

        private void cmbZg_KeyDown(object sender, KeyEventArgs e)
        {
            this.btnSave.Focus();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        #endregion



        #region IInterfaceContainer {2A467990-BDA3-4cb4-BB89-5801796EBC95} 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid) };
            }
        }

        #endregion
    }
}
