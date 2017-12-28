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
    /// [功能描述: 出院患者列表]<br></br>
    /// [创 建 者: 张琦]<br></br>
    /// [创建时间: 2008-09-3]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientCallBack : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientCallBack()
        {
            InitializeComponent();
            
        }


        #region 工具栏事件

        protected override void OnRefreshTree()
        {
            base.OnRefreshTree();
            this.tvOutHosList1.Refresh(deptCode, tempBegin, tempEnd);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Refresh();
            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 变量
        private string tempBegin = System.DateTime.Now.AddDays(-3).ToShortDateString();
        private string tempEnd = System.DateTime.Now.AddDays(4).ToShortDateString();
        Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.HISFC.BizLogic.RADT.InPatient Inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        private string deptCode;//默认科室

        private string strBegin
        {
            get
            {
                if (cbTime.Checked)
                {
                    return dtBegin.Value.Year.ToString() + "-" + dtBegin.Value.Month.ToString() + "-" + dtBegin.Value.Day.ToString() + " 00:00:00";
                }
                else
                {
                    return tempBegin;
                }
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        private string strEnd
        {
            get
            {
                if (cbTime.Checked)
                {
                    return dtEnd.Value.Year.ToString() + "-" + dtEnd.Value.Month.ToString() + "-" + dtEnd.Value.Day.ToString() + " 23:59:59";
                }
                else
                {
                    return tempEnd;
                }
            }
        }

        /// <summary>
        /// 默认科室
        /// </summary>
        public string DeptCode
        {
            get
            {
                return deptCode;
            }
            set
            {
                deptCode = value;
                this.cmbDept.Tag = deptCode;
            }
        }

        /// <summary>
        /// adt接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        #endregion

        #region 函数
        protected override void OnLoad(EventArgs e)
        {
            this.cmbDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbBedNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbAdmittingNur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbAttendingDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbConsultingDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            try
            {
                this.tvOutHosList1.Refresh(deptCode, tempBegin, tempEnd);
                this.cmbDept.AddItems(deptManager.QueryDeptmentsInHos(true));
                deptHelper.ArrayObject = this.cmbDept.alItems;
                this.neuTextBox1.Text = this.cmbDept.Text + "-"+"出院患者列表";
                this.neuTextBox1.Enabled = false;
                this.dtBegin.Text = System.DateTime.Now.AddDays(-3).ToShortDateString();
                this.dtEnd.Text = System.DateTime.Now.AddDays(4).ToShortDateString();
                this.cbTime.Checked = false;
            }
            catch { }
            base.OnLoad(e);
        }

        /// <summary>
        /// 更新树
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void QueryOutHosPatient(string deptCode, string beginTime, string endTime)
        {
            this.tvOutHosList1.Refresh(deptCode, beginTime, endTime);
        }

        private new void Refresh()
        {
            this.neuTextBox1.Text = this.cmbDept.Text + "-" + "出院患者列表";
            deptCode = cmbDept.Tag.ToString();
            tempBegin = dtBegin.Value.ToString();
            tempEnd = dtEnd.Value.ToString();
            QueryOutHosPatient(deptCode, tempBegin, tempEnd);
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        public virtual int Save()
        {
            //取婴儿接珍时的信息信息
            //Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;

            //取患者最新的住院主表信息
            //PatientInfo = this.Inpatient.QueryPatientInfoByInpatientNO(this.patientInfo.ID);
            if (this.patientInfo == null)
            {
                MessageBox.Show(this.Inpatient.Err);
                return -1;
            }

            //取变动信息:取医生、护士、科室等信息
            //this.GetPatientInfo(PatientInfo);

            //判断是否已选择床位
            if (this.cmbBedNo.Text.Trim() == ""
                && patientInfo.IsBaby == false)
            {
                MessageBox.Show("未选择床位！");
                return -1;
            }

            //取处理时的床位信息
            Neusoft.HISFC.Models.Base.Bed bed = new Neusoft.HISFC.Models.Base.Bed();
            bed.ID = this.cmbBedNo.Tag.ToString();	//床号
            bed.InpatientNO = patientInfo.ID;		//床位上患者住院流水号


            #region 业务处理

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.RADT managerRADT = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //managerRADT.SetTrans(t.Trans);

            if (managerRADT.CallBack(patientInfo, bed) == -1)//调用召回业务
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(managerRADT.Err);
                return -1;
            }
            else
            {

            }
            #endregion

            #region addby xuewj 2010-3-15

            if (this.adt == null)
            {
                this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
            }
            if (this.adt != null)
            {
                this.adt.CancelDischargePatientMessage(patientInfo);
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(managerRADT.Err);
            this.Refresh();
            this.ClearPatintInfo();
            return 1;
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
            this.cmbBedNo.Tag = patientInfo.PVisit.PatientLocation.Bed.ID;
            this.cmbBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
            //this.cmbBedNo.AddItems(deptManager.QueryUnoccupiedBed(PatientInfo.PVisit.PatientLocation.NurseCell.ID));
            //this.cmbAdmittingNur.AddItems(deptManager.QueryNurse(PatientInfo.PVisit.PatientLocation.NurseCell.ID));
             
            ArrayList alDepts = deptManager.QueryDepartment(PatientInfo.PVisit.PatientLocation.NurseCell.ID);
            try
            {
                //取医生列表
                ArrayList al = new ArrayList();
                
                foreach (Neusoft.FrameWork.Models.NeuObject dept in alDepts)
                {
                    al.AddRange(deptManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, dept.ID));
                
                }

                //加载住院医生列表
                this.cmbDoc.AddItems(al);
                //加载主治医生列表
                this.cmbAttendingDoc.AddItems(al);
                //加载主任医生列表
                this.cmbConsultingDoc.AddItems(al);
                //加载责任护士列表
                this.cmbAdmittingNur.AddItems(deptManager.QueryNurse(PatientInfo.PVisit.PatientLocation.NurseCell.ID));
                //加载床位列表
                this.cmbBedNo.AddItems(deptManager.QueryUnoccupiedBed(PatientInfo.PVisit.PatientLocation.NurseCell.ID));
                this.cmbDoc.IsListOnly = true;
                this.cmbBedNo.IsListOnly = true;
                this.cmbAdmittingNur.IsListOnly = true;
                this.cmbAttendingDoc.IsListOnly = true;
                this.cmbConsultingDoc.IsListOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            //this.cmbDoc.AddItems(deptManager.QueryEmployee())
            //换医生或者婴儿召回不用选择床位,跟妈妈相同
            if (PatientInfo.IsBaby)
                this.cmbBedNo.Enabled = false;
            else
                this.cmbBedNo.Enabled = true;
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

        #endregion

        #region 初始化

        #region 初始化出院患者列表
        /// <summary>
        /// 初始化出院患者列表
        /// </summary>
        private void InitTree()
        {

        }
        #endregion

        #region 设置背景色
        private void SetBackColor()
        {
            this.BackColor = System.Drawing.Color.Azure;
        }
        #endregion
        #endregion

        #region 事件

        private void cmbDept_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
                e.Handled = true;
            }
        }        

        private void cbTime_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbTime.Checked)
            {
                dtBegin.Enabled = true;
                dtEnd.Enabled = true;
            }
            else
            {
                dtBegin.Enabled = false;
                dtEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 保存事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void tvOutHosList1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                return;
            }
            else if(e.Node.Level==1)
            {
                patientInfo = e.Node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                this.SetPatientInfo(patientInfo);
            }   
        }

        private void cmbBedNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cmbBedNo.Tag == null || this.cmbBedNo.Tag.ToString() == "") return;
                Neusoft.HISFC.Models.Base.Bed obj = deptManager.GetBed(this.cmbBedNo.Tag.ToString());
                if (obj == null) return;
                this.cmbDoc.Tag = obj.Doctor.ID;					//住院医生
                this.cmbAttendingDoc.Tag = obj.AttendingDoctor.ID;	//主治医生
                this.cmbConsultingDoc.Tag = obj.ConsultingDoctor.ID;//主任医生
                this.cmbAdmittingNur.Tag = obj.AdmittingNurse.ID;	//责任护士
        }
    }
        #endregion
}
