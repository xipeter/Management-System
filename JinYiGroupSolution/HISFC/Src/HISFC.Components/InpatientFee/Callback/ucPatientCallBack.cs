using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.InpatientFee.Callback
{
    /// <summary>
    /// 接诊，转入，召回等基础控件
    /// </summary>
    public partial class ucPatientCallBack : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientCallBack()
        {
            InitializeComponent();
        }
        protected Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        public ArriveType arrivetype = ArriveType.CallBack;
        Neusoft.HISFC.Models.Base.Employee empl;
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //***************获得病床列表*************
            empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            NurseCell  = empl.Nurse.Clone();
            //根据护士站得到科室信息
            ArrayList alDepts = manager.QueryDepartment(empl.Nurse.ID);
            try
            {
                //取医生列表
                ArrayList al = new ArrayList();
                
                foreach (Neusoft.FrameWork.Models.NeuObject dept in alDepts)
                {
                    al.AddRange(manager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, dept.ID));
                
                }

                //加载住院医生列表
                this.cmbDoc.AddItems(al);
                //加载主治医生列表
                this.cmbAttendingDoc.AddItems(al);
                //加载主任医生列表
                this.cmbConsultingDoc.AddItems(al);
                //加载责任护士列表
                this.cmbAdmittingNur.AddItems(manager.QueryNurse(empl.Nurse.ID));


                //加载床位列表
                if (this.arrivetype == ArriveType.ChangeDoc)
                {
                    //换医生时,显示全部床位
                    this.cmbBedNo.AddItems(manager.QueryBedList(empl.Nurse.ID));
                }
                else
                {
                    //接珍时,只显示空床
                    this.cmbBedNo.AddItems(manager.QueryUnoccupiedBed(empl.Nurse.ID));
                }
                this.cmbDoc.IsListOnly = true;
                this.cmbBedNo.IsListOnly = true;
                this.cmbAdmittingNur.IsListOnly = true;
                this.cmbAttendingDoc.IsListOnly = true;
                this.cmbConsultingDoc.IsListOnly = true;
                this.ucQueryInpatientNo.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(ucQueryInpatientNo_myEvent);//{4DA55EB8-FEE8-4f9a-ACEF-ACB794091D4C}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        //{4DA55EB8-FEE8-4f9a-ACEF-ACB794091D4C}
        private void ucQueryInpatientNo_myEvent()
        {
            this.RefreshList(this.ucQueryInpatientNo.InpatientNo);
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.RefreshList(((Neusoft.HISFC.Models.RADT.PatientInfo)neuObject).ID);
            return base.OnSetValue(neuObject, e);
        }
       
        /// <summary>
        /// 将患者信息显示到控件上
        /// </summary>
        /// <param name="PatientInfo"></param>
        private void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo)
        {
            this.txtPatientNo.Text = PatientInfo.PID.PatientNO;
            this.txtPatientNo.Tag = PatientInfo.ID;
            this.txtName.Text = PatientInfo.Name;
            this.txtSex.Text = PatientInfo.Sex.Name;
            this.cmbDoc.Text = PatientInfo.PVisit.AdmittingDoctor.Name;
            this.cmbDoc.Tag = PatientInfo.PVisit.AdmittingDoctor.ID;
            this.cmbAttendingDoc.Text = PatientInfo.PVisit.AttendingDoctor.Name;
            this.cmbAttendingDoc.Tag = PatientInfo.PVisit.AttendingDoctor.ID;
            this.cmbConsultingDoc.Text = PatientInfo.PVisit.ConsultingDoctor.Name;
            this.cmbConsultingDoc.Tag = PatientInfo.PVisit.ConsultingDoctor.ID;
            this.cmbAdmittingNur.Text = PatientInfo.PVisit.AdmittingNurse.Name;
            this.cmbAdmittingNur.Tag = PatientInfo.PVisit.AdmittingNurse.ID;
            if (this.arrivetype == ArriveType.ShiftIn)
            {
                this.cmbBedNo.Text = "";
                this.cmbBedNo.Tag = "";

            }
            else
            {
                this.cmbBedNo.Text = PatientInfo.PVisit.PatientLocation.Bed.ID.Length > 4 ? PatientInfo.PVisit.PatientLocation.Bed.ID.Substring(4) : "";
                this.cmbBedNo.Tag = PatientInfo.PVisit.PatientLocation.Bed.ID;
            }

            //换医生或者婴儿召回不用选择床位,跟妈妈相同
            if (PatientInfo.IsBaby || this.arrivetype == ArriveType.ChangeDoc)
                this.cmbBedNo.Enabled = false;
            else
                this.cmbBedNo.Enabled = true;

        }


        /// <summary>
        /// 获得患者基本信息从控件到PatientInfo
        /// </summary>
        /// <param name="PatientInfo"></param>
        private void GetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            //取控件中住院医生
            if (this.cmbDoc.Text != "")
            {
                patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoc.Tag.ToString();
                patientInfo.PVisit.AdmittingDoctor.Name = this.cmbDoc.Text;
            }
            else
            {
                patientInfo.PVisit.AdmittingDoctor.ID = "";
                patientInfo.PVisit.AdmittingDoctor.Name = "";
            }


            //取控件中主治医生
            if (this.cmbAttendingDoc.Text != "")
            {
                patientInfo.PVisit.AttendingDoctor.ID = this.cmbAttendingDoc.Tag.ToString();
                patientInfo.PVisit.AttendingDoctor.Name = this.cmbAttendingDoc.Text;
            }
            else
            {
                patientInfo.PVisit.AttendingDoctor.ID = "";
                patientInfo.PVisit.AttendingDoctor.Name = "";
            }


            //取控件中主任医生
            if (this.cmbConsultingDoc.Text != "")
            {
                patientInfo.PVisit.ConsultingDoctor.ID = this.cmbConsultingDoc.Tag.ToString();
                patientInfo.PVisit.ConsultingDoctor.Name = this.cmbConsultingDoc.Text;
            }
            else
            {
                patientInfo.PVisit.ConsultingDoctor.ID = "";
                patientInfo.PVisit.ConsultingDoctor.Name = "";
            }


            //取控件中责任护士
            if (this.cmbAdmittingNur.Text != "")
            {
                patientInfo.PVisit.AdmittingNurse.ID = this.cmbAdmittingNur.Tag.ToString();
                patientInfo.PVisit.AdmittingNurse.Name = this.cmbAdmittingNur.Text;
            }
            else
            {
                patientInfo.PVisit.AdmittingNurse.ID = "";
                patientInfo.PVisit.AdmittingNurse.Name = "";
            }

      

            //患者住院状态为入院登记
            patientInfo.PVisit.InState.ID = "I";
        }


        /// <summary>
        /// 清屏
        /// </summary>
        public virtual void ClearPatintInfo()
        {
            this.cmbDoc.Text = "";
            this.cmbDoc.Tag = "";
            this.cmbAttendingDoc.Text = "";
            this.cmbAttendingDoc.Tag = "";
            this.cmbConsultingDoc.Text = "";
            this.cmbConsultingDoc.Tag = "";
            this.cmbAdmittingNur.Text = "";
            this.cmbAdmittingNur.Tag = "";
            
        }

        Neusoft.HISFC.BizProcess.Integrate.RADT Inpatient = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        protected string strNurseCode = "";
        /// <summary>
        /// 刷新患者信息
        /// </summary>
        /// <param name="inPatientNo"></param>
        public virtual void RefreshList(string inPatientNo)
        {
            //加载床位列表
            if (this.arrivetype == ArriveType.ChangeDoc)
            {
                //换医生时,显示全部床位
                this.cmbBedNo.AddItems(manager.QueryBedList(empl.Nurse.ID));
            }
            else
            {
                //接珍时,只显示空床
                this.cmbBedNo.AddItems(manager.QueryUnoccupiedBed(empl.Nurse.ID));
            }
            ClearPatintInfo();
            try
            {
                this.patientInfo = this.Inpatient.GetPatientInfomation(inPatientNo);
                if (this.patientInfo == null)
                {
                    MessageBox.Show(this.Inpatient.Err);
                    this.patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                }
            }
            catch { }
            
            try
            {
                this.SetPatientInfo(this.patientInfo);
            }
            catch { }
        }


        /// <summary>
        /// 保存设置
        /// </summary>
        public virtual int Save()
        {
            //取婴儿接珍时的信息信息
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;

            //取患者最新的住院主表信息
            PatientInfo = this.Inpatient.QueryPatientInfoByInpatientNO(this.patientInfo.ID);
            if (this.patientInfo == null)
            {
               MessageBox.Show( this.Inpatient.Err);
                return -1;
            }

            //换医生时,如果患者已不在本科,则清空数据---当患者转科后,如果本窗口没有关闭,会出现此种情况
            if (PatientInfo.PVisit.PatientLocation.NurseCell.ID != this.NurseCell.ID 
                && this.arrivetype == ArriveType.ChangeDoc)
            {
                MessageBox.Show( "患者已不在本病区,请刷新当前窗口");
                return -1;
            }

            //如果患者已不是在院状态,则不允许操作
            if (PatientInfo.PVisit.InState.ID.ToString() != this.patientInfo.PVisit.InState.ID.ToString())
            {
                MessageBox.Show(  "患者信息已发生变化,请刷新当前窗口");
                return -1;
            }

            //取变动信息:取医生、护士、科室等信息
            this.GetPatientInfo(PatientInfo);

            //判断是否已选择床位
            if (this.cmbBedNo.Text.Trim() == ""
                && patientInfo.IsBaby == false)
            {
               MessageBox.Show( "未选择床位！");
                return -1;
            }

            //取处理时的床位信息
            Neusoft.HISFC.Models.Base.Bed bed = new Neusoft.HISFC.Models.Base.Bed();
            bed.ID = this.cmbBedNo.Tag.ToString();	//床号
            bed.InpatientNO = patientInfo.ID;		//床位上患者住院流水号


            #region 业务处理
            Neusoft.HISFC.BizProcess.Integrate.RADT managerRADT = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            managerRADT.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            
            //转科
            if (this.arrivetype == ArriveType.ShiftIn)
            {

                if (managerRADT.ShiftIn(PatientInfo, this.NurseCell, this.cmbBedNo.Tag.ToString()) == -1)//调用转科业务
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(managerRADT.Err);
                    return -1;
                }
                else
                {
                  
                   
                }
            }

            //接珍护理站为当前护理站(转入操作时,需要保留原护理站信息,所以在此处处理)
            PatientInfo.PVisit.PatientLocation.NurseCell = this.NurseCell;
            PatientInfo.PVisit.PatientLocation.Bed = bed;

            //接诊
            if (this.arrivetype == ArriveType.Regedit)
            {
                if (managerRADT.ArrivePatient(PatientInfo, bed) == -1)//调用接诊业务
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(managerRADT.Err);
                    return -1;
                }
                else
                {
                  
                   
                }
            }

            //召回
            if (this.arrivetype == ArriveType.CallBack)
            {
                if (managerRADT.CallBack(PatientInfo, bed) == -1)//调用召回业务
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(managerRADT.Err);
                    return -1;
                }
                else
                {
                   
                    
                }
            }

            //换医师
            if (this.arrivetype == ArriveType.ChangeDoc)
            {
                if (managerRADT.ChangeDoc(PatientInfo) == -1)//调用换医生业务
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(managerRADT.Err);
                    return -1;
                }
                else
                {
            
                }
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(managerRADT.Err);
            base.OnRefreshTree();//刷新树
            return 1;

        }
        

    


        private void cmbBedNo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cmbBedNo.Tag == null || this.cmbBedNo.Tag.ToString() == "") return;
            if (this.arrivetype == ArriveType.Regedit)
            {
              
                Neusoft.HISFC.Models.Base.Bed obj = manager.GetBed(this.cmbBedNo.Tag.ToString());
                if (obj == null) return;
                this.cmbDoc.Tag = obj.Doctor.ID;					//住院医生
                this.cmbAttendingDoc.Tag = obj.AttendingDoctor.ID;	//主治医生
                this.cmbConsultingDoc.Tag = obj.ConsultingDoctor.ID;//主任医生
                this.cmbAdmittingNur.Tag = obj.AdmittingNurse.ID;	//责任护士
            }
        }

        
        /// <summary>
        /// 护士站
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject NurseCell = null;

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void txtPatientNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.ucQueryInpatientNo.txtInputCode.Text = this.txtPatientNo.Text;
                this.ucQueryInpatientNo.query();
                this.RefreshList(this.ucQueryInpatientNo.InpatientNo);
            }
        }
        

        
    }
    /// <summary>
    /// 接诊类型
    /// </summary>
    public enum ArriveType
    {
        /// <summary>
        /// 登记
        /// </summary>
        Regedit,
        /// <summary>
        /// 转入
        /// </summary>
        ShiftIn,
        /// <summary>
        /// 召回
        /// </summary>
        CallBack,
        /// <summary>
        /// 更换医师等信息
        /// </summary>
        ChangeDoc
    }
}
