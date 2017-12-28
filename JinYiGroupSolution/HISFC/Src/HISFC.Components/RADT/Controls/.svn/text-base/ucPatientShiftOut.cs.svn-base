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
    /// [功能描述: 转科申请，取消控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientShiftOut : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.ITransferDeptApplyable,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucPatientShiftOut()
        {
            InitializeComponent();
        }

        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.RADT.InPatient inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        private bool isCancel = false;
        private Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath iClinicPath = null;//add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
        #endregion

        #region 属性
        /// <summary>
        /// 是否取消申请
        /// </summary>
        public bool IsCancel
        {
            get
            {
                return this.isCancel;
            }
            set
            {
                this.isCancel = value;
            }
        }
        #endregion

        #region 函数
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
           
            try
            {
                ArrayList al = Neusoft.HISFC.Models.Base.SexEnumService.List();
                this.cmbNewDept.AddItems(manager.QueryDeptmentsInHos(true));
                // this.cmbNewDept.Text = "";
                //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
                this.cmbNewNurse.AddItems(manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N));
                #region add by xuewj 2010-10-12 {971F1A22-E5E3-4d6e-B087-9EE98CB4D3A7} 转科时病区不可以选择
                this.cmbNewNurse.Enabled = false;                
                #endregion

                #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
                this.InitInterface(); 
                #endregion
            }
            catch { }

        }

        /// <summary>
        /// 将患者信息显示在控件中
        /// </summary>
        private void ShowPatientInfo()
        {
            this.txtPatientNo.Text = this.patientInfo.PID.PatientNO;		//住院号
            this.txtPatientNo.Tag = this.patientInfo.ID;							//住院流水号
            this.txtName.Text = this.patientInfo.Name;								//患者姓名
            this.txtSex.Text = this.patientInfo.Sex.Name;					//性别
            this.txtOldDept.Text = this.patientInfo.PVisit.PatientLocation.Dept.Name;//源科室名称
            this.cmbBedNo.Text = this.patientInfo.PVisit.PatientLocation.Bed.ID.Length > 4 ? this.patientInfo.PVisit.PatientLocation.Bed.ID.Substring(4) : "";	//床号
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            this.txtOldNurse.Text = this.patientInfo.PVisit.PatientLocation.NurseCell.Name;
            //定义患者Location实体
            Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
            //取患者转科申请信息
            newLocation = this.inpatient.QueryShiftNewLocation(this.patientInfo.ID, this.patientInfo.PVisit.PatientLocation.Dept.ID);
            this.patientInfo.User03 = newLocation.User03;
            if (this.patientInfo.User03 == null)
                this.patientInfo.User03 = "1";//申请

            if (newLocation == null)
            {
                MessageBox.Show(this.inpatient.Err);
                return;
            }
            
            this.cmbNewDept.Tag = newLocation.Dept.ID;	//新科室名称
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            this.cmbNewNurse.Tag = newLocation.NurseCell.ID;
            this.txtNote.Text = newLocation.Memo;		//备注
            //如果没有转科申请,则清空新科室编码
            if (newLocation.Dept.ID == "")
            {
                this.cmbNewDept.Text = null;
            }

            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (newLocation.NurseCell.ID == "")
            {
                this.cmbNewNurse.Text = null;
            }

            if (this.patientInfo.User03 != null && this.patientInfo.User03 == "0")
                this.label8.Visible = true;
            else
                this.label8.Visible = false;
        }


        /// <summary>
        /// 清屏
        /// </summary>
        public void ClearPatintInfo()
        {
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            this.cmbNewNurse.Tag = "";
            this.cmbNewNurse.Text = "";
            this.cmbNewDept.Text = "";
            this.cmbNewDept.Tag = "";
        }


        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="patientInfo"></param>
        public void RefreshList(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            try
            {
                //将患者信息显示在控件中
                this.ShowPatientInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            RefreshList(this.patientInfo);
            return 0;
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitControl();
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbNewDept.Tag == null || this.cmbNewDept.Tag.ToString() == "")
            {
                MessageBox.Show("请选择要转入的科室!");
                return;
            }
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (this.cmbNewNurse.Tag == null || this.cmbNewNurse.Tag.ToString() == "")
            {
                MessageBox.Show("请选择要转入的科室!");
                return;
            }

            Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
            dept.ID = this.cmbNewDept.Tag.ToString();
            dept.Name = this.cmbNewDept.Text;
            dept.Memo = this.txtNote.Text;

            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            Neusoft.FrameWork.Models.NeuObject nurseCell = new Neusoft.FrameWork.Models.NeuObject();
            nurseCell.ID = this.cmbNewNurse.Tag.ToString();
            nurseCell.Name = this.cmbNewNurse.Text;

            #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
            if (this.iClinicPath != null)
            {
                if (this.iClinicPath.PatientIsSelectedPath(this.patientInfo.ID))
                {
                    MessageBox.Show("该患者在临床路径中，请先退出路径!");
                    return;
                }
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            //t.BeginTransaction();
            //radt.SetTrans(t.Trans);
             //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (radt.ShiftOut(this.patientInfo, dept, nurseCell, this.patientInfo.User03, this.isCancel) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                if (bSaveAndClose)
                {
                    dialogResult = DialogResult.OK;
                    this.FindForm().Close();
                    return;
                }
            }

            MessageBox.Show(radt.Err);
            
            base.OnRefreshTree();//刷新树
        }
        #endregion

        #region ITransferDeptApplyable 成员
        bool bSaveAndClose = false;
        DialogResult dialogResult = DialogResult.None;
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get { return this.cmbNewDept.SelectedItem; }
        }

        public void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.InitControl();
            this.patientInfo = patientInfo.Clone();
            RefreshList(this.patientInfo);
           
        }

        public DialogResult ShowDialog()
        {
            bSaveAndClose = true;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this);
            return dialogResult;
            
        }

        #endregion

        //{3696891C-4BA0-4024-AA50-000CCD75FD49}
        private void cmbNewDept_SelectedValueChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject Nurseobj = new Neusoft.FrameWork.Models.NeuObject();
            Nurseobj.ID = this.cmbNewDept.Tag.ToString();
            ArrayList alNurseCell = this.manager.QueryNurseStationByDept(Nurseobj);
            if (alNurseCell.Count != 0)
            {
                cmbNewNurse.Tag = (alNurseCell[0] as Neusoft.FrameWork.Models.NeuObject).ID;
            }
            else
            {
                cmbNewNurse.Tag = null;
            }
        }

        #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[]{
                    typeof(Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath) };
                return t;
            }
        }

        #endregion

        private void InitInterface()
        {
            if (this.iClinicPath == null)
            {
                this.iClinicPath = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(
                    typeof(Neusoft.HISFC.Components.RADT.Controls.ucPatientShiftOut),
                    typeof(Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath))
                    as Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath;
            }
        } 

        #endregion
    }
}
