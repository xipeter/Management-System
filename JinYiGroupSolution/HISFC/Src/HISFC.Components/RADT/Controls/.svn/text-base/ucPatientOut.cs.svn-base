using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//{28C63B3A-9C64-4010-891D-46F846EA093D}
using System.Collections;

namespace Neusoft.HISFC.Components.RADT.Controls
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
    public partial class ucPatientOut : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucPatientOut()
        {
            InitializeComponent();
        }

        private void ucPatientOut_Load(object sender, EventArgs e)
        {

        }

        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizLogic.RADT.InPatient inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;
        private Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath iClinicPath = null;

        /// <summary>
        /// 参数控制类{28C63B3A-9C64-4010-891D-46F846EA093D}
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
     
        private bool quitFeeApplyFlag = true;

        /// <summary>
        /// 药品业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        #endregion

        #region 属性
        /// <summary>
        /// 有退费申请是否允许出院登记
        /// </summary>
        [Category("控件设置"), Description("存在退费申请是否允许做出院登记")]
        public bool QuitFeeApplyFlag
        {
            get
            {
                return quitFeeApplyFlag;
            }
            set
            {
                quitFeeApplyFlag = value;
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
                this.cmbZg.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ZG));
                //出院登记的时间默认为系统时间
                this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();

                this.InitInterface();
               
                
            }
            catch { }

        }


        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="PatientInfo"></param>
        private void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {

            this.txtPatientNo.Text = patientInfo.PID.PatientNO;		//住院号
            this.txtCard.Text = patientInfo.PID.CardNO;	//门诊卡号
            this.txtPatientNo.Tag = patientInfo.ID;				//住院流水号
            this.txtName.Text = patientInfo.Name;						//姓名
            this.txtSex.Text = patientInfo.Sex.Name;					//性别
            this.txtIndate.Text = patientInfo.PVisit.InTime.ToString();	//入院日期
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;	//科室名称
            this.txtDept.Tag = patientInfo.PVisit.PatientLocation.Dept.ID;	//科室编码

            Neusoft.FrameWork.Public.ObjectHelper helper =new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND));
            this.txtBalKind.Text = helper.GetName(patientInfo.Pact.PayKind.ID);
            

            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;	//床号
            this.txtFreePay.Text = patientInfo.FT.LeftCost.ToString();		//剩余预交金
            this.txtTotcost.Text = patientInfo.FT.TotCost.ToString();		//总金额
            this.cmbZg.Tag = patientInfo.PVisit.ZG.ID;						//转归
            this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();				//出院日期 －－－修改为系统时间

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
                ArrayList alShiftDataInfo = this.inpatient.QueryPatientShiftInfoNew(this.PatientInfo.ID);

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
        }


        /// <summary>
        /// 从控件获得出院登记信息
        /// </summary>
        private void GetOutInfo()
        {
            PatientInfo.PVisit.ZG.ID = this.cmbZg.Tag.ToString();
            PatientInfo.PVisit.ZG.Name = this.cmbZg.Text;
            PatientInfo.PVisit.PreOutTime = this.dtOutDate.Value;
        }


        /// <summary>
        ///清屏
        /// </summary>
        private void ClearPatintInfo()
        {
            this.cmbZg.Text = "";
            this.cmbZg.Tag = "";
            this.dtOutDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
        }


        /// <summary>
        /// 刷新患者信息
        /// </summary>
        /// <param name="inPatientNo"></param>
        public void RefreshList(string inPatientNo)
        {
            try
            {
                PatientInfo = this.inpatient.QueryPatientInfoByInpatientNO(inPatientNo);
                //如果患者已不在本科,则清空数据
                if (PatientInfo.PVisit.PatientLocation.NurseCell.ID != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID)
                {
                    MessageBox.Show("患者已不在本病区,请刷新当前窗口", "提示");
                    PatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                }
            }
            catch { }
            try
            {
                this.SetPatientInfo(PatientInfo);
            }
            catch { }
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
            //如果患者不是当天出院提示
            if (this.dtOutDate.Value.Date < this.PatientInfo.PVisit.InTime.Date)
            {
                MessageBox.Show("出院日期不能小于入院日期！", "提示");
                return -1;
            }
            else
            {
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
            }
            //取患者最新的住院主表信息
            PatientInfo = this.inpatient.QueryPatientInfoByInpatientNO(this.PatientInfo.ID);
            if (PatientInfo == null)
            {
                this.Err = this.inpatient.Err;
                return -1;
            }
            this.Err = "";
            //如果患者已不在本科,则清空数据---当患者转科后,如果本窗口没有关闭,会出现此种情况
            if (PatientInfo.PVisit.PatientLocation.NurseCell.ID != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID)
            {
                this.Err = "患者已不在本病区,请刷新当前窗口";
                return -1;
            }

            //如果患者在院状态发生变化,则不允许操作
            if (PatientInfo.PVisit.InState.ID.ToString() != "I")
            {
                this.Err = "患者信息已发生变化,请刷新当前窗口";
                return -1;
            }

            #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
            if (this.iClinicPath != null)
            {
                if (this.iClinicPath.PatientIsSelectedPath(this.PatientInfo.ID))
                {
                    this.Err = "该患者在临床路径中，请先退出路径!";
                    return -1;
                }
            }
            #endregion

            #region {6BFCAC25-CC22-48ac-ADDB-76E169375EAB}
            //将转归、出院时间等赋值拿到接口判断之前
            //取出院登记信息
            this.GetOutInfo();
            #endregion

            #region addby xuewj 2010-10-11 {EFF73DC9-3543-49a4-9751-BC8D95F0BDD3} 郑大本地化，增加明细提示

            Neusoft.HISFC.BizProcess.Interface.IPatientOutCheck ipatientOutCheck = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IPatientOutCheck)) as Neusoft.HISFC.BizProcess.Interface.IPatientOutCheck;
            bool isZZUCheck = false;
            if (ipatientOutCheck != null)//本地化实现了接口
            {
                string err = string.Empty;
                bool bl = ipatientOutCheck.IPatientOutCheck(PatientInfo, ref err);
                if (!bl)
                {
                    //MessageBox.Show(err);
                    return -1;
                }
                isZZUCheck = true;
            }
            else
            {
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

                //{3E83AFA1-C364-4f72-8DFD-1B733CB9379E}
                //增加查询患者是否有未审核的退药记录,为出院登记判断用 Add by 王宇 2009.6.10
                int returnValue = this.pharmacyIntegrate.QueryNoConfirmQuitApply(PatientInfo.ID);
                if (returnValue == -1)
                {
                    MessageBox.Show("查询患者退药申请信息出错!" + this.pharmacyIntegrate.Err);

                    return -1;
                }
                if (returnValue > 0) //有申请但是没有核准的退药信息
                {
                    //{29F39131-89B4-4128-B4C9-EAB9F07B719F}
                    if (!this.quitFeeApplyFlag)
                    {
                        MessageBox.Show("该患者有未审核的退药申请信息,不能进行出院操作！");
                        return -1;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("该患者有未审核的退药申请信息!是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.No)
                        {
                            return -1;
                        }
                    }
                }
            }
            #endregion
            //{3E83AFA1-C364-4f72-8DFD-1B733CB9379E} 增加完毕
            #region {6BFCAC25-CC22-48ac-ADDB-76E169375EAB}
            ////取出院登记信息
            //this.GetOutInfo();
            #endregion

            //出院登记
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(inpatient.con);
            //t.BeginTransaction();

            radt.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            radt.QuitFeeApplyFlag = quitFeeApplyFlag;
            #region addby xuewj 2010-10-11 {EFF73DC9-3543-49a4-9751-BC8D95F0BDD3}
            int i = 0;
            if (!isZZUCheck)
            {
                i = radt.OutPatient(PatientInfo);
                this.Err = radt.Err;
            }
            else
            {
                // 之前已判断过 这里只处理床位信息
                i = radt.OutPatientZZU(PatientInfo);
                Err = radt.Err;
            }
            //int i = radt.OutPatient(PatientInfo);
            //this.Err = radt.Err;
            #endregion
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

            #region #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
            if (this.iClinicPath != null)
            {
                if (this.iClinicPath.PatientOutByNurse(this.PatientInfo.ID, PatientInfo.PVisit.PreOutTime) == false)
                {
                    this.Err = "结束临床路径失败!";
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            } 
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //***************打印出院带药单**************

            return 1;
        }
        #endregion

        #region 事件
        private void button1_Click(object sender, System.EventArgs e)
        {

            //出院登记判断是否输入出院情况{BDE26EF4-91E2-41b1-9E83-A00332249E05}
            if (this.cmbZg.SelectedItem == null)
            {
                MessageBox.Show("请选择出院情况~~", "出院登记", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ((Control)sender).Enabled = false;
                if (this.Save() > 0)//成功
                {
                    MessageBox.Show(Err);
                    base.OnRefreshTree();
                    ((Control)sender).Enabled = true;
                    return;
                }
                else
                {
                    if (Err != "")
                        MessageBox.Show(Err);
                    ((Control)sender).Enabled = true;
                }
            }
            

        }
        string strInpatientNo;

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.strInpatientNo = (neuObject as Neusoft.FrameWork.Models.NeuObject).ID;
            if (this.strInpatientNo != null || this.strInpatientNo != "")
            {
                try
                {
                    RefreshList(strInpatientNo);
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

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid),
                                              typeof(Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath)// add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
                };
            }
        }

        #endregion

        #region add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
        /// <summary>
        /// 初始化接口
        /// </summary>
        private void InitInterface()
        {
            if (this.iClinicPath == null)
            {
                this.iClinicPath = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(
                    typeof(Neusoft.HISFC.Components.RADT.Controls.ucPatientOut),
                    typeof(Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath))
                    as Neusoft.HISFC.BizProcess.Interface.ClinicPath.IClinicPath;
            }
        } 
        #endregion
    }
}
