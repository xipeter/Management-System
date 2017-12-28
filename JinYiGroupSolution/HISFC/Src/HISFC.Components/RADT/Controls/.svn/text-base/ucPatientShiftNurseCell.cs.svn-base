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
    /// {9A2D53D3-25BE-4630-A547-A121C71FB1C5}
    /// [功能描述: 转病区申请，取消控件]<br></br>
    /// [创 建 者: Sunm]<br></br>
    /// [创建时间: 2009-07-09]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    /// </summary>
    public partial class ucPatientShiftNurseCell : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ucPatientShiftNurseCell()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 科室病区业务类
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 患者业务类
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        /// <summary>
        /// 患者信息
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;

        #region addby xuewj IADT接口

        Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        #endregion


        #endregion

        #region 属性

        private bool isCancel = false;
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

        /// <summary>
        /// 是否显示
        /// </summary>
        private bool isShowShiftNurse = false;
        public bool IsShowShiftNurse
        {
            get
            {
                return this.isShowShiftNurse;
            }
            set
            {
                this.isShowShiftNurse = value;
            }
        }

        #region 函数

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {

            try
            {
                ArrayList al = new ArrayList();
                al = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                this.cmbNewDept.AddItems(al);
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
            this.txtOldDept.Text = this.patientInfo.PVisit.PatientLocation.NurseCell.Name;//源科室名称
            this.cmbBedNo.Text = this.patientInfo.PVisit.PatientLocation.Bed.ID.Length > 4 ? this.patientInfo.PVisit.PatientLocation.Bed.ID.Substring(4) : "";	//床号
            //定义患者Location实体
            Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
            //取患者转科申请信息
            newLocation = this.inpatientManager.QueryShiftNewLocation(this.patientInfo.ID, this.patientInfo.PVisit.PatientLocation.Dept.ID);
            this.patientInfo.User03 = newLocation.User03;
            if (this.patientInfo.User03 == null)
                this.patientInfo.User03 = "1";//申请

            if (newLocation == null)
            {
                MessageBox.Show(this.inpatientManager.Err);
                return;
            }

            this.cmbNewDept.Tag = newLocation.NurseCell.ID;	//新科室名称
            this.txtNote.Text = newLocation.Memo;		//备注
            //如果没有转科申请,则清空新科室编码
            if (newLocation.NurseCell.ID == "")
            {
                this.cmbNewDept.Text = null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            RefreshList(this.patientInfo);
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitControl();
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbNewDept.Tag == null || this.cmbNewDept.Tag.ToString() == "")
            {
                MessageBox.Show("请选择要转入的病区!");
                return;
            }
            
            Neusoft.FrameWork.Models.NeuObject nurseCell = new Neusoft.FrameWork.Models.NeuObject();

            nurseCell.ID = this.cmbNewDept.Tag.ToString();
            nurseCell.Name = this.cmbNewDept.Text;
            nurseCell.Memo = this.txtNote.Text;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (radt.ShiftOut(this.patientInfo, this.patientInfo.PVisit.PatientLocation.Dept,nurseCell, this.patientInfo.User03, this.isCancel) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }
            else
            {
                #region addby xuewj 
                if (this.adt == null)
                {
                    this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
                }
                if (this.adt != null && patientInfo != null)
                {
                    this.adt.CancelTransferPatient(patientInfo);
                }
                #endregion
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                
            }
            MessageBox.Show(radt.Err);

            base.OnRefreshTree();//刷新树
        }

        #endregion

        #region IInterfaceContainer 成员

        /// <summary>
        /// 接口容器
        /// </summary>
        public Type[] InterfaceTypes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
