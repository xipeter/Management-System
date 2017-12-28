using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Controls
{
    public partial class ucPatientIn : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientIn()
        {
            InitializeComponent();
        }

        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        //Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;
        Neusoft.HISFC.Models.Registration.Register PatientInfo = null;
        //挂号中间层
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        #endregion

        #region 函数
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            try
            {
                //出院登记的时间默认为系统时间
                this.dtOutDate.Value = this.dataManager.GetDateTimeFromSysDateTime();
            }
            catch { }

        }


        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="PatientInfo"></param>
       
        ///<summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="PatientInfo"></param>
        private void SetPatientInfo(Neusoft.HISFC.Models.Registration.Register patientInfo)
        {

            //this.txtPatientNo.Text = patientInfo.PID.PatientNO;		//住院号
            this.txtPatientNo.Text =patientInfo.ID;
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
            this.dtOutDate.Value = patientInfo.PVisit.OutTime;				//出院日期
        }


 


        /// <summary>
        ///清屏
        /// </summary>
        private void ClearPatintInfo()
        {
            this.dtOutDate.Value = this.dataManager.GetDateTimeFromSysDateTime();
        }


       

        string Err = "";
        /// <summary>
        /// 重写校验用
        /// </summary>
        /// <param name="Inpatient_no"></param>
        /// <returns></returns>
        public virtual int Valid(string Inpatient_no)
        {
            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public virtual int Save()
        {
            if (this.Valid(this.PatientInfo.ID) < 0)
            {
                return -1;
            }
            //取患者最新的住院主表信息

            ArrayList alPatientlist = new ArrayList();
            alPatientlist = this.registerIntegrate.QueryPatient(this.PatientInfo.ID);
            PatientInfo = alPatientlist[0] as Neusoft.HISFC.Models.Registration.Register;
            if (PatientInfo == null)
            {
                this.Err = this.registerIntegrate.Err;
                return -1;
            }
            this.Err = "";

            #region {BD72C9FF-2F8D-46f3-8EE6-3AE410A4A459}
            //急诊留观不需要判断患者科室和病区---sunm
            //如果患者已不在本科,则清空数据---当患者转科后,如果本窗口没有关闭,会出现此种情况
            //if (PatientInfo.PVisit.PatientLocation.NurseCell.ID != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID)
            //{
            //    this.Err = "患者已不在本病区,请刷新当前窗口";
            //    return -1;
            //}

            #endregion

            //如果患者在院状态发生变化,则不允许操作
            if (PatientInfo.PVisit.InState.ID.ToString() != "E")
            {
                this.Err = "患者信息已发生变化,请刷新当前窗口";
                return -1;
            }

            //取出院登记信息
            PatientInfo.PVisit.OutTime = this.dtOutDate.Value;

            //出院登记

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.radt.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int i = this.radt.OutObservePatientManager(PatientInfo, Neusoft.HISFC.Models.Base.EnumShiftType.CI, "留观住院");
            this.Err = radt.Err;
            if( i== -1)　//失败
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            else if (i == 0)//取消
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "";
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            base.OnRefreshTree();//刷新树
            return 1;
        }
        #endregion

        #region 事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((Control)sender).Enabled = false;
            if (this.Save() > 0)//成功
            {
                MessageBox.Show("转住院成功！");
                base.OnRefreshTree();
                ((Control)sender).Enabled = true;
                return;
            }
            else
            {
                if (Err != "") MessageBox.Show(Err);
            }
            ((Control)sender).Enabled = true;
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            //this.strInpatientNo = (neuObject as Neusoft.FrameWork.Models.NeuObject).ID;
            Neusoft.HISFC.Models.Registration.Register register = e.Tag as Neusoft.HISFC.Models.Registration.Register;
            if ( register != null  )
            {
                try
                {
                    this.PatientInfo = register;
                    this.SetPatientInfo(register);  
                }
                catch (Exception ex) { this.Err = ex.Message; }

            }
            return 0;
        }
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitControl();
            return null;
        }

        #endregion

        
    }
}
