using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 会诊申请]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人='张琦'
    ///		修改时间='2007-8-25'
    ///		修改目的='添加是否可以开立医嘱和是否院外会诊功能'
    ///		修改描述='对会诊医师能否开立医嘱进行控制'
    ///  />
    ///  <修改记录 
    ///		修改人='陈樊' 
    ///		修改时间='2009-07-22' 
    ///		修改目的='使门诊挂号科室也可以成为住院患者会诊的目标科室{F21E0827-56C5-4d7f-B2A7-789066AF2096}'
    ///		修改描述='将门诊挂号科室添加进会诊科室Combox中'
    ///		/>
    ///  <修改记录 
    ///		修改人='陈樊' 
    ///		修改时间='2009-07-22' 
    ///		修改目的='当会诊申请没有指定会诊医生时，填写会诊意见的医生默认为会诊医生{53F962A7-44DC-4607-A240-5B21A1AC6E14}'
    ///		修改描述='当会诊医生为空时，设置当前登陆人为会诊医生'
    ///		/>
    /// </summary>
    public partial class ucConsultation : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucConsultation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 为医嘱开例调用会诊控件，保存自动关闭
        /// </summary>
        /// <param name="order"></param>
        public ucConsultation(Neusoft.HISFC.Models.Order.Order order)
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();

            if (order != null)
            {
                this.InpatientNo = order.Patient.ID;
                this.NewOne();

            }
            bSaveAndClose = true;
            // TODO: 在 InitializeComponent 调用后添加任何初始化

        }

        #region 变量

        Neusoft.HISFC.BizLogic.Order.Consultation manager = new Neusoft.HISFC.BizLogic.Order.Consultation();

        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        protected bool bSaveAndClose = false;

        protected bool IsSave = false;

        Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizProcess.Integrate.RADT inpatientManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        Neusoft.HISFC.Models.RADT.PatientInfo patient = null;

        /// <summary>
        /// 会诊
        /// </summary>
        Neusoft.HISFC.Models.Order.Consultation consultation = new Neusoft.HISFC.Models.Order.Consultation();

        #endregion

        #region 函数

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            
            this.NewOne();
            this.DisplayPatientInfo(this.patient);
            #region 2009-07-22 可以使门诊挂号科室成为住院患者会诊的目标科室 {F21E0827-56C5-4d7f-B2A7-789066AF2096} By Chenfan
            ArrayList alDept = deptManager.QueryDeptmentsInHos(true);
            alDept.AddRange(deptManager.QueryRegDepartment());
            deptHelper.ArrayObject = alDept;
            #endregion
            personHelper.ArrayObject = deptManager.QueryEmployeeAll();
            RefreshList();
        }

        private void RefreshList()
        {

            ArrayList al = null;
            try
            {
                al = manager.QueryConsulation(this.inpatientNo);//获得列表
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowCount = 0;

            if (al == null || al.Count == 0) return;


            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Consultation obj = al[i] as Neusoft.HISFC.Models.Order.Consultation;
                    this.fpSpread1_Sheet1.Rows.Add(0, 1);
                    this.fpSpread1_Sheet1.Cells[0, 0].Value = deptHelper.GetName(obj.DeptConsultation.ID);//科室
                    try
                    {
                        this.fpSpread1_Sheet1.Cells[0, 1].Value = personHelper.GetName(obj.DoctorConsultation.ID);//人员
                    }
                    catch { }
                    if (this.fpSpread1_Sheet1.Cells[0, 0].Text == "")//科室没找到
                    {
                        this.fpSpread1_Sheet1.Cells[0, 0].Value = obj.DeptConsultation.ID;//科室
                    }
                    if (this.fpSpread1_Sheet1.Cells[0, 1].Text == "")//人员没找到
                    {
                        this.fpSpread1_Sheet1.Cells[0, 1].Value = obj.DoctorConsultation.ID;//人员
                    }
                    this.fpSpread1_Sheet1.Cells[0, 2].Value = obj.Doctor.Name;//personHelper.GetName(obj.Doctor.ID);//申请人
                    fpSpread1_Sheet1.Cells[0, 3].Value = obj.ApplyTime;//申请日期

                    this.fpSpread1_Sheet1.Cells[0, 4].Value = obj.Name;//原因
                    this.fpSpread1_Sheet1.Cells[0, 5].Value = obj.Result;//结果
                    if (obj.State == 1)
                    {
                        this.fpSpread1_Sheet1.Cells[0, 6].Value = "申请";//状态
                    }
                    else if (obj.State == 2)
                    {
                        this.fpSpread1_Sheet1.Cells[0, 6].Value = "确认";//状态
                        this.fpSpread1_Sheet1.Rows[0].BackColor = Color.FromArgb(255, 225, 225);//确认状态
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[0, 6].Value = "未知" + obj.State.ToString();//状态
                    }

                    if (obj.IsCreateOrder)
                    {
                        this.fpSpread1_Sheet1.Cells[0, 7].Value = "允许开医嘱";
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[0, 7].Value = "不允许开医嘱";
                    }
                    if (obj.Type == Neusoft.HISFC.Models.Order.EnumConsultationType.Hos)//院外会诊
                    {
                        this.fpSpread1_Sheet1.Rows[0].BackColor = Color.FromArgb(255, 200, 200);//院外会诊
                    }
                    this.fpSpread1_Sheet1.Cells[0, 8].Value = personHelper.GetName(obj.DoctorConfirm.ID);//审核人
                    this.fpSpread1_Sheet1.Rows[0].Tag = obj;
                }
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                this.fpSpread1_Sheet1.RowHeader.Rows[i].Label = "会诊" + (i + 1).ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.cmbDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.cmbDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtConsultation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.dtPreConsultation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.rtbSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            this.rtbSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);

            this.ucUserText1.Visible = false;
            try
            {
                this.cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);

                #region  2009-07-22 可以使门诊挂号科室成为住院患者会诊的目标科室 {F21E0827-56C5-4d7f-B2A7-789066AF2096} By Chenfan
                ArrayList alDept = deptManager.QueryDeptmentsInHos(true);
                alDept.AddRange(deptManager.QueryRegDepartment());
                this.cmbDept.AddItems(alDept);
                this.cmbAppDept.AddItems(cmbDept.alItems);
                #endregion

                this.cmbAppDept.Text = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.Name;
                this.cmbDoctor.AddItems(deptManager.QueryEmployeeAll());
                deptHelper.ArrayObject = this.cmbDept.alItems;
                personHelper.ArrayObject = this.cmbDoctor.alItems;
                this.lblDoc.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;//操作员
                NewOne();

            }
            catch { }
            try
            {
                components = new Container();
                components.Add(this.rtbSource);
                components.Add(this.rtbResult);
                this.ucUserText1.SetControl(this.components);
            }
            catch { }
            base.OnLoad(e);
        }

        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <param name="P"></param>
        public void DisplayPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo P)
        {
            //Add By Zuowy
            this.label12.Text = P.Name;
            this.label14.Text = P.Sex.Name;
            #region {135F0471-5C50-42c2-BFF0-DCAEBBE76D60} 日期获取年龄 by guanyx
            //this.label16.Text = P.Age;
            this.label16.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(P.Birthday);
            #endregion

            if (P.PVisit.PatientLocation.Bed.ID.Length > 3)
                this.lblBedID.Text = P.PVisit.PatientLocation.Bed.ID.Substring(4);
            else
                this.lblBedID.Text = P.PVisit.PatientLocation.Bed.ID;
            this.lblName.Text = P.Name;
            this.lblDept.Text = P.PVisit.PatientLocation.Dept.Name;
            this.lblDept0.Text = P.PVisit.PatientLocation.Dept.Name;
            if (P.PVisit.PatientLocation.Bed.ID.Length > 3)
                this.lblBedNo0.Text = P.PVisit.PatientLocation.Bed.ID.Substring(4);
            else
                this.lblBedNo0.Text = P.PVisit.PatientLocation.Bed.ID;
            this.lblPatientNo0.Text = P.PID.ID;
            this.cmbDept.Visible = true;
            this.cmbDoctor.Visible = true;
        }

        /// <summary>
        /// 新建立一个
        /// </summary>
        protected virtual void NewOne()
        {
            if (this.neuButton2.Text == "修改(&M)")
            {
                this.neuButton2.Text = "保存(&S)";
            }
            Neusoft.HISFC.Models.RADT.PatientInfo p = inpatientManager.GetPatientInfomation(this.inpatientNo);
            if (p == null) return;
            consultation = new Neusoft.HISFC.Models.Order.Consultation();
            consultation.PatientNo = p.PID.PatientNO;
            consultation.InpatientNo = p.ID;
            //会诊默认申请科室和申请医师
            consultation.Dept = p.PVisit.PatientLocation.Dept.Clone();
            consultation.Doctor.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;

            consultation.NurseStation = p.PVisit.PatientLocation.NurseCell.Clone();
            consultation.State = 1;//申请

            this.dtPreConsultation.Value = manager.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = this.dtPreConsultation.Value;  //默认值
            this.dtEnd.Value = this.dtBegin.Value;  //默认值
            this.chkOuthos.Checked = false;
            this.chkCreateOrder.Checked = false;
            //新加的初始化设置
            this.cmbAppDept.Text = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.Name;
            this.lblDoc.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;

            if (this.IsSave == false)
            {
                this.rtbResult.Text = "";
                this.rtbSource.Text = "";
                this.cmbDept.Tag = "";
                this.cmbDept.Text = "";
                this.cmbDoctor.Tag = "";
                this.cmbDoctor.Text = "";
            }

        }

        protected virtual int Valid()
        {
            if (this.bIsApply)//申请
            {
                if (this.inpatientNo == "" || this.patient == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请先选择患者！"));
                    return -1;
                }
                if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请填写会诊科室！"));
                    this.cmbDept.Focus();
                    return -1;
                }
                if (this.rtbSource.Text == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请填写会诊摘要！"));
                    this.rtbSource.Focus();
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.rtbSource.Text, 1000) == false)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("会诊摘要书写不能超过1000字符!"), "提示");
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.rtbResult.Text, 1000) == false)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("会诊意见书写不能超过1000字符!"), "提示");
                    return -1;
                }
                if (this.dtEnd.Value < this.dtBegin.Value)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("处方结束日期不能小于处方开始日期!"), "提示");
                    return -1;
                }
                if (this.dtBegin.Value.ToShortDateString() == this.dtEnd.Value.ToShortDateString())
                {
                    DialogResult r = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("授权结束日期与授权起始日期相同，\n是否只允许该医生在当天才有权会诊？"), "提示", MessageBoxButtons.OKCancel);
                    if (r == DialogResult.Cancel)
                        return -1;
                }
            }
            else//确认
            {
                //{A27C2DED-2C6C-4e30-857D-27E46B485B84}
                if (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == "")
                {
                    MessageBox.Show("请填写会诊专家！");
                    this.cmbDoctor.Focus();
                    return -1;
                }

                if (this.dtConsultation.Value == DateTime.MinValue)
                {
                    MessageBox.Show("请填写会诊日期！");
                    this.dtConsultation.Focus();
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 新建申请单时,判断有没有有效的申请单保存
        /// </summary>
        public void Save()
        {
            ArrayList al = null;
            try
            {
                al = manager.QueryConsulation(this.inpatientNo);//获得列表
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (Valid() == -1) return;
            //if (this.dtEnd.Value <= manager.GetDateTimeFromSysDateTime())
            //{
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败!该申请单已经失效!"), "提示");
            //    return;
            //}
            if (this.bIsApply)
            {

                if (al != null || al.Count != 0)
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        Neusoft.HISFC.Models.Order.Consultation obj = al[i] as Neusoft.HISFC.Models.Order.Consultation;
                        //检索有无已经存在的有效的申请单信息,有,保存失败/无,保存成功
                        if ((obj.PatientNo == this.inpatientNo.Substring(4, 10)) && (obj.Doctor.ID == Neusoft.FrameWork.Management.Connection.Operator.ID) &&
                            (obj.DoctorConsultation.ID == this.cmbDoctor.Tag.ToString()) &&
                            (this.dtPreConsultation.Value < obj.EndTime) && (obj.EndTime >= manager.GetDateTimeFromSysDateTime()))
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败!已经存在有效的会诊申请单,\n不能重复发送!"), "提示");
                            return;
                        }
                    }
                }
                consultation.State = 1;
                consultation.Doctor.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                consultation.Doctor.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
            }
            else
            {
                //if (al != null || al.Count != 0)
                //{
                //    for (int i = 0; i < al.Count; i++)
                //    {
                //        Neusoft.HISFC.Models.Order.Consultation obj = al[i] as Neusoft.HISFC.Models.Order.Consultation;
                //        if ((obj.PatientNo == this.inpatientNo.Substring(4, 10)) && (obj.Doctor.ID == Neusoft.FrameWork.Management.Connection.Operator.ID) &&
                //            (obj.DoctorConsultation.ID == this.cmbDoctor.Tag.ToString()) &&
                //            (this.dtPreConsultation.Value < obj.EndTime) && (obj.EndTime >= manager.GetDateTimeFromSysDateTime()))
                //        {
                //            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败!请选择您要审核的申请单!"), "提示");
                //            return;
                //        }
                //    }
                //}
                if (this.cmbDoctor.Tag.ToString() != "")//{A27C2DED-2C6C-4e30-857D-27E46B485B84}
                {
                    if (this.cmbDoctor.Tag.ToString() != Neusoft.FrameWork.Management.Connection.Operator.ID)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败!您无权修改该会诊信息"), "提示");
                        return;
                    }
                }
                consultation.State = 2;
                consultation.DoctorConfirm.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                consultation.DoctorConfirm.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
            }
            consultation.Name = this.rtbSource.Text;
            consultation.Result = this.rtbResult.Text;
            consultation.ConsultationTime = this.dtConsultation.Value;
            consultation.BeginTime = this.dtBegin.Value.Date;
            consultation.EndTime = new DateTime(this.dtEnd.Value.Year, this.dtEnd.Value.Month, this.dtEnd.Value.Day,
                 23, 59, 59);
            consultation.PreConsultationTime = this.dtPreConsultation.Value;
            consultation.DeptConsultation.ID = this.cmbDept.Tag.ToString();
            if (this.cmbDoctor.Tag.ToString() != "")//{A27C2DED-2C6C-4e30-857D-27E46B485B84}
            {
                consultation.DoctorConsultation.ID = this.cmbDoctor.Tag.ToString();
            }
            else
            {
                consultation.DoctorConsultation.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
            }
            consultation.ApplyTime = this.dtPreConsultation.Value;

            if (this.chkCreateOrder.Checked)
            {
                consultation.IsCreateOrder = true;
            }
            else
            {
                consultation.IsCreateOrder = false;
            }

            if (this.chkEmergency.Checked)
            {
                consultation.IsEmergency = true;
            }
            else
            {
                consultation.IsEmergency = false;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (consultation.ID == "")
            {
                if (manager.InsertConsultation(consultation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    MessageBox.Show(manager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.IsSave = true;
                    init();
                    MessageBox.Show("保存成功!");
                    this.Clear();//保存完进行清空操作
                    if (bSaveAndClose)
                        this.FindForm().Close();
                }
            }
            else
            {
                if (manager.UpdateConsultation(consultation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    MessageBox.Show(manager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.IsSave = true;
                    init();
                    MessageBox.Show("保存成功!");
                    this.Clear();
                    if (bSaveAndClose)
                        this.FindForm().Close();
                }
            }
            this.RefreshList();
        }

        /// <summary>
        /// [功能描述: 清空操作]<br></br>
        /// [创 建 者: ]<br></br>
        /// [创建时间: ]<br></br>
        /// <修改记录
        ///		修改人='张琦'
        ///		修改时间='2007-8-25'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public void Clear()
        {
            if (this.neuButton2.Text == "修改(&M)")
            {
                this.neuButton2.Text = "保存(&S)";
            }
            this.IsSave = false;
            this.NewOne();
            //this.label12.Text = "未知";
            //this.label14.Text = "未知";
            //this.label16.Text = "未知";
            //this.lblBedID.Text = "未知";
            //this.cmbAppDept.Tag = "";
            //this.cmbDept.Tag = "";

            //this.lblBedNo0.Text = "";
            //this.lblConDept.Text = "";
            //this.lblConDoc.Text = "";
            //this.lblName.Text = "";
            //this.lblDept.Text = "";
            //this.lblPatientNo0.Text = "";

            //新增加
            this.cmbDept.Tag = "";
            this.cmbDoctor.Tag = "";
            this.dtPreConsultation.Value = manager.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = this.dtPreConsultation.Value;  //默认值
            this.dtEnd.Value = this.dtBegin.Value;  //默认值
            this.chkOuthos.Checked = false;
            this.chkCreateOrder.Checked = false;

            this.cmbAppDept.Text = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.Name;
            this.lblDoc.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;
        }
        /// <summary>
        /// 对有效的会诊申请单进行修改和审核保存
        /// </summary>
        public void SaveUpdate()
        {
            if (Valid() == -1) return;
            if (this.dtEnd.Value <= manager.GetDateTimeFromSysDateTime())
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("修改失败!该申请单已经失效!"), "提示");
                this.neuButton2.Text = "保存(&S)";
                return;
            }
            else
            {
                if (this.bIsApply)
                {

                    consultation.State = 1;
                    consultation.Doctor.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                    consultation.Doctor.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
                }
                else
                {
                    if (this.cmbDoctor.Tag.ToString() != Neusoft.FrameWork.Management.Connection.Operator.ID)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("修改失败!您无权修改该会诊信息"), "提示");
                        this.neuButton2.Text = "保存(&S)";
                        return;
                    }
                    consultation.State = 2;
                    consultation.DoctorConfirm.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                    consultation.DoctorConfirm.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
                }
                consultation.Name = this.rtbSource.Text;
                consultation.Result = this.rtbResult.Text;
                consultation.ConsultationTime = this.dtConsultation.Value;
                consultation.BeginTime = this.dtBegin.Value.Date;
                consultation.EndTime = new DateTime(this.dtEnd.Value.Year, this.dtEnd.Value.Month, this.dtEnd.Value.Day,
                     23, 59, 59);
                consultation.PreConsultationTime = this.dtPreConsultation.Value;
                consultation.DeptConsultation.ID = this.cmbDept.Tag.ToString();
                consultation.DoctorConsultation.ID = this.cmbDoctor.Tag.ToString();
                consultation.ApplyTime = manager.GetDateTimeFromSysDateTime();

                if (this.chkCreateOrder.Checked)
                {
                    consultation.IsCreateOrder = true;
                }
                else
                {
                    consultation.IsCreateOrder = false;
                }

                if (this.chkEmergency.Checked)
                {
                    consultation.IsEmergency = true;
                }
                else
                {
                    consultation.IsEmergency = false;
                }

            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (consultation.ID == "")
            {
                if (manager.InsertConsultation(consultation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    MessageBox.Show(manager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.IsSave = true;
                    init();
                    MessageBox.Show("修改成功!");
                    this.neuButton2.Text = "保存(&S)";
                    this.Clear();
                    if (bSaveAndClose)
                        this.FindForm().Close();
                }
            }
            else
            {
                if (manager.UpdateConsultation(consultation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    MessageBox.Show(manager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.IsSave = true;
                    init();
                    MessageBox.Show("修改成功!");
                    this.neuButton2.Text = "保存(&S)";
                    this.Clear();
                    if (bSaveAndClose)
                        this.FindForm().Close();
                }
            }
            this.RefreshList();
        }

        private void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

            #region 郑大更新--{708DEA18-EAB7-4f87-BC8B-D2C7C529BB87}
            p.PrintPreview(52, 40, this.panelFun); //p.PrintPreview(0, 5, this.panelFun); 
            #endregion

        }

        private void SetValue()
        {
            if (this.fpSpread1_Sheet1.ActiveRow.Tag == null) return;
            this.DisplayPatientInfo(this.patient);
            consultation = this.fpSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Consultation;

            if (this.consultation.Type == Neusoft.HISFC.Models.Order.EnumConsultationType.Hos)
            {
                #region 院外会诊
                //frmConsultationOuthos f = new frmConsultationOuthos();
                //f.Init(consultation);
                //f.ShowDialog();
                //this.init();
                #endregion
            }
            else
            {
                #region 院内会诊
                this.bIsApply = this.bisApply;
                this.rtbSource.Text = consultation.Name;
                this.rtbResult.Text = consultation.Result;
                this.dtConsultation.Value = consultation.ConsultationTime;
                this.dtBegin.Value = consultation.BeginTime;
                this.dtEnd.Value = consultation.EndTime;
                this.dtPreConsultation.Value = consultation.PreConsultationTime;
                this.cmbDept.Tag = consultation.DeptConsultation.ID;
                #region  2009-07-22 当会诊申请没有指定会诊医生时，填写会诊意见的医生默认为会诊医生 {53F962A7-44DC-4607-A240-5B21A1AC6E14} By Chenfan
                if (consultation.DoctorConsultation.ID == null || consultation.DoctorConsultation.ID == string.Empty)
                {
                    this.cmbDoctor.Tag = Neusoft.FrameWork.Management.Connection.Operator.ID;
                }
                else
                {
                    this.cmbDoctor.Tag = consultation.DoctorConsultation.ID;
                }
                #endregion
                this.cmbAppDept.Tag = consultation.Dept.ID;
                this.lblDoc.Text = consultation.Doctor.Name;
                if (consultation.IsCreateOrder)
                {
                    this.chkCreateOrder.Checked = true;
                    this.chkOuthos.Checked = false;
                }
                else
                {
                    this.chkCreateOrder.Checked = false;
                }
                if (consultation.IsEmergency)
                {
                    this.chkEmergency.Checked = true;
                    this.chkCommon.Checked = false;
                }
                else
                {
                    this.chkEmergency.Checked = false;
                    this.chkCommon.Checked = true;
                }
                if (this.bIsApply)
                {

                }
                else
                {
                    //this.cmbApplyDoctor.Text = consultation.DoctorConfirm.Name;

                }
                this.neuButton2.Text = "修改(&M)";
                #endregion
            }

        }


        #endregion

        #region 属性

        protected string inpatientNo;

        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InpatientNo
        {
            set
            {
                if (value == null || value == "") return;
                this.inpatientNo = value;
                patient = inpatientManager.GetPatientInfomation(this.inpatientNo);
                init();
            }
        }

        protected bool bisApply = true;
        /// <summary>
        /// 申请单状态
        /// </summary>
        protected bool bIsApply
        {
            get
            {
                return this.bisApply;
            }
            set
            {
                this.bisApply = value;
                if (consultation.State == 1)
                    this.lblState.Text = "状态：申请会诊";
                else
                    this.lblState.Text = "状态：已经确认";

                this.dtPreConsultation.Enabled = value;
                this.cmbDept.Enabled = value;
                this.cmbDoctor.Enabled = value;
                this.chkEmergency.Enabled = value;
                this.rtbSource.Enabled = value;
                this.dtConsultation.Enabled = true;
                this.dtBegin.Enabled = value;
                this.dtEnd.Enabled = value;
                this.cmbAppDept.Enabled = value;
                this.dtConsultation.Enabled = value;
                this.chkCommon.Enabled = value;
                this.chkCreateOrder.Enabled = value;
                this.chkOuthos.Enabled = value;
                this.rtbResult.Enabled = !value;
                this.neuButton1.Enabled = value;
            }
        }

        /// <summary>
        /// 是否申请
        /// </summary>
        [Browsable(false)]
        public bool IsApply
        {
            get
            {
                return this.bIsApply;
            }
            set
            {
                this.bIsApply = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Description("显示的标题")]
        public string Title
        {
            set
            {
                this.lblTitle.Text = value;
            }
            get
            {
                return this.lblTitle.Text;
            }
        }

        #endregion

        #region 事件
        
        //科室变化－－人员跟着变化
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbDoctor.alItems = null;
                this.cmbDoctor.Text = "";
                this.cmbDoctor.Tag = "";
                ArrayList emps = deptManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D ,this.cmbDept.Tag.ToString());
                if (emps == null) emps = new ArrayList();
                this.cmbDoctor.AddItems(emps);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            this.Clear();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (this.neuButton2.Text== "修改(&M)")
            {
                this.SaveUpdate();
            }
            else
            {
                this.Save();
            }

        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                SetValue();
            }
            catch { }
        }
        
        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                SetValue();
            }
            catch { }
        }

        private void cmbDept_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (this.neuButton2.Text == "修改(&M)")
            {
                this.neuButton2.Text = "保存(&S)";
            }
            if (consultation == null || consultation.ID == "")
            {
                MessageBox.Show("请选择一条会诊单再进行删除操作！");
                return;
            }
            if (consultation.ID == "")
            {
                this.NewOne();
            }
            else if (consultation.State == 2)
            {
                MessageBox.Show("该会诊已经生效无法删除！");
            }
            else
            {
                //.
                if (consultation.Doctor.ID != Neusoft.FrameWork.Management.Connection.Operator.ID)
                {
                    MessageBox.Show("您不是会诊申请人，不能删除此申请！");
                    return;
                }
                else
                {
                    //.
                    if (MessageBox.Show("确定要删除该会诊记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
                        //t.BeginTransaction();
                        manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        if (manager.DeleteConsulation(consultation.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(manager.Err);
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        MessageBox.Show("删除成功!");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            this.init();
        }
        /// <summary>
        /// 打印 修改 by zuowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            //
           
            try
            { 
                SetValue();
            }
            catch { }
            Print();
            if (this.neuButton2.Text == "修改(&M)")
            {
                this.neuButton2.Text = "保存(&S)";
            }
           
        }

        private void chkTemplet_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkTemplet.Checked == true)
                ucUserText1.Visible = true;
            else
                ucUserText1.Visible = false;
        }

        private void chkEmergency_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkEmergency.Checked == true)
                this.chkCommon.Checked = false;
            else
                this.chkCommon.Checked = true;
        }

        private void chkCommon_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkCommon.Checked == true)
                this.chkEmergency.Checked = false;
            else
                this.chkEmergency.Checked = true;
        }

        private void chkOuthos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOuthos.Checked == true)
                this.chkCreateOrder.Checked = false;
        }


        private void chkCreateOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCreateOrder.Checked == true)
                this.chkOuthos.Checked = false;
        }

        private void cmbDept_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            this.lblConDept.Text = this.cmbDept.Text;
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.lblConDoc.Text = this.cmbDoctor.Text;
        }
        #endregion

        #region 重写函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.init();

            return base.OnInit(sender, neuObject, param);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = neuObject as Neusoft.FrameWork.Models.NeuObject;
            if(obj == null) return -1;
            if (e.Parent.Tag.ToString() == "ConsultationPatient")
            {
                this.bIsApply = false;
            }
            else
            {
                this.bIsApply = true;
            }

            this.InpatientNo = obj.ID;
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return 0;
        }

        #endregion



      
    }
}
