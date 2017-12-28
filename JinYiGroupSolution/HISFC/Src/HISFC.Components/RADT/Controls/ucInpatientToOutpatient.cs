using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 住院患者转门诊]<br></br>
    /// [创 建 者: 薛文进]<br></br>
    /// [创建时间: 2010-3-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucInpatientToOutpatient : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region "变量"

        /// <summary>
        /// 患者基本信息综合实体

        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 入出转integrate层

        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 入出转manager层

        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager radtManger = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院费用业务层

        /// </summary>
        //Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 住院费用组合业务层

        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

        private Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;
        #endregion

        public ucInpatientToOutpatient()
        {
            InitializeComponent();
        }

        #region 方法
        protected override int OnSave(object sender, object neuObject)
        {
            if (adt == null)
            {
                adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
            }

            if (adt == null)
            {
                return -1;
            }

            Neusoft.HISFC.BizProcess.Integrate.RADT radtBll = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regBll = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();


            Neusoft.HISFC.Models.RADT.PatientInfo patient = radtBll.GetPatientInfomation(this.patientInfo.ID);
            Neusoft.HISFC.Models.Registration.Register r = adt.ProduceInpatientToOutPatientMessage(this.patientInfo);

            if (r == null)
            {
                MessageBox.Show("生成挂号实体出错!");
                return -1;
            }
            int resultValue = radtBll.UnregisterNoFee(patient);
            if (resultValue != 1)
            {

                throw new Exception(radtBll.Err);
            }
            if (regBll.InsertByDoct(r) == -1)
            {

                throw new Exception(regBll.Err);
            }

            adt.InPatientToOutpatient(this.patientInfo);
            return base.OnSave(sender, neuObject);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Init();
        }

        private void Init()
        {
            ArrayList alDept;
            alDept = this.GetClinicDepts();
            this.cmbDept.AddItems(alDept);
        }



        /// <summary>
        /// 有效性判断

        /// </summary>
        private bool IsValid()
        {
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                //if (this.ucQueryInpatientNo.Err == "")
                //{
                //    ucQueryInpatientNo.Err = "此患者不在院!";
                //}
                //Neusoft.FrameWork.WinForms.Controls.Classes.Function.Msg(this.ucQueryInpatientNo.Err, 111);

                //this.ucQueryInpatientNo.Focus();
                //return false;


            }

            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);

            if (this.patientInfo == null)
            {
                MessageBox.Show(this.radtIntegrate.Err);
                this.ucQueryInpatientNo.Focus();

                return false;
            }
            //////////////////////////////////////////////////////////////////////////
            // Robin Add
            //////////////////////////////////////////////////////////////////////////
            this.patientInfo.PVisit.ICULocation.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;
            this.patientInfo.PVisit.ICULocation.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
            //////////////////////////////////////////////////////////////////////////
            //控件赋值患者信息


            this.EvaluteByPatientInfo(this.patientInfo);

            //判断该患者是否已经出院

            //if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            //{
            //    Neusoft.FrameWork.WinForms.Controls.Classes.Function.Msg("该患者已经出院!", 111);
            //    this.patientInfo.ID = null;
            //    this.ucQueryInpatientNo.Focus();

            //    return false;
            //}

            //判断预约金

            //if (this.patientInfo.FT.PrepayCost > 0)
            //{
            //    Neusoft.FrameWork.WinForms.Controls.Classes.Function.Msg("预交金额大于0,不能无费退院", 111);
            //    this.ucQueryInpatientNo.Focus();

            //    return false;
            //}

            //判断费用总额 不考虑费用条数|| feeInpatient.QueryBalancesByInpatientNO(this.patientInfo.ID).Count != 0
            //if (this.patientInfo.FT.TotCost > 0 || this.patientInfo.FT.BalancedCost > 0)
            //{
            //    Neusoft.FrameWork.WinForms.Controls.Classes.Function.Msg("已发生费用或结算记录,不能无费退院", 111);
            //    this.ucQueryInpatientNo.Focus();

            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 清空信息
        /// </summary>
        protected virtual void Clear()
        {
            this.patientInfo = null;
            this.txtName.Text = "";
            this.txtDept.Text = "";
            this.txtPact.Text = "";
            this.txtBedNo.Text = "";

            txtDateIn.Text = "";
            txtDoctor.Text = "";

        }

        /// <summary>
        /// 利用患者信息实体进行控件赋值

        /// </summary>
        /// <param name="patientInfo">患者基本信息实体</param>
        protected virtual void EvaluteByPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            }
            // 姓名
            this.txtName.Text = patientInfo.Name;
            // 科室
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            // 合同单位
            this.txtPact.Text = patientInfo.Pact.Name;
            //床号
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;

            //入院日期
            txtDateIn.Text = patientInfo.PVisit.InTime.ToString();
            // 医生
            txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            //住院号

            this.ucQueryInpatientNo.TextBox.Text = patientInfo.PID.PatientNO;



        }

        /// <summary>
        ///增加ToolBar控件
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="neuObject"></param>
        ///<param name="param"></param>
        ///<returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("退院", "进行无费退院", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);
            toolBarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("退出", "关闭登记窗口", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "退院":

                    this.Confirm();
                    break;

                case "清屏":
                    this.Clear();
                    this.ucQueryInpatientNo.Text = "";
                    this.ucQueryInpatientNo.Focus();
                    break;

                case "帮助":

                    break;
                case "退出":

                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }


        /// <summary>
        /// 无费退院

        /// </summary>
        protected virtual void Confirm()
        {
            //有效性判断

            if (!IsValid())
            {
                return;
            }

            //定义事务
            long returnValue = this.medcareInterfaceProxy.SetPactCode(this.patientInfo.Pact.ID);
            if (returnValue != 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口取合同单位失败") + this.medcareInterfaceProxy.ErrMsg);
                return;
            }
            //Neusoft.FrameWork.Management.Transaction t  = new Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (radtIntegrate.UnregisterNoFee(this.patientInfo) != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();

                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.radtManger.Err, 211);

                return;
            }
            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);


            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + this.medcareInterfaceProxy.ErrMsg);
                return;
            }
            returnValue = this.medcareInterfaceProxy.CancelRegInfoInpatient(this.patientInfo);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口无费退院失败") + this.medcareInterfaceProxy.ErrMsg);
                return;
            }

            this.medcareInterfaceProxy.Commit();
            //{009FC822-DE2B-45ac-BEB7-E49F24B1605F}
            this.medcareInterfaceProxy.Disconnect();
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.patientInfo.ID = "";
            this.ucQueryInpatientNo.txtInputCode.Text = "";
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("无费退院成功", 111);
        }

        private ArrayList GetClinicDepts()
        {
            ArrayList al = this.conMgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取门诊科室时出错!" + this.conMgr.Err, "提示");
                return null;
            }

            return al;
        }
        #endregion

        #region 事件
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //暂用ICULocation来当
            this.patientInfo.PVisit.PatientLocation.Dept.ID = this.cmbDept.Tag.ToString();
            this.patientInfo.PVisit.PatientLocation.Dept.Name = this.cmbDept.Text;
        }

        /// <summary>
        /// 得到患者信息实体
        /// </summary>
        private void ucQueryInpatientNo_myEvent()
        {
            //清空
            this.Clear();

            //有效性判断


            if (!IsValid())
            {
                return;
            }
        }
        #endregion

    }
}
