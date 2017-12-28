using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术收费]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFeeForm :UserControl
    {
        public ucFeeForm()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
                this.Clear();
        }
        #region 字段
        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        //{F3C1935C-24E9-47a4-B7AE-4EA237A972C9} 
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;


        /// <summary>
        /// 是否显示比例项{2C7FCD3D-D9B4-44f5-A2EE-A7E8C6D85576}
        /// </summary>
        private bool isShowFeeRate = false;


        //{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
        ucRegistrationTree.EnumListType listType;

        //[Category("控件设置"), Description("控件类型：麻醉还是收费")]
        public ucRegistrationTree.EnumListType ListType
        {
            get
            {
                return listType;
            }
            set
            {
                this.listType = value;
                this.InitControlName();
            }
        }


        private bool isReg = false;

        public bool IsReg
        {
            get { return isReg; }
            set { isReg = value; }
        }


       

        #endregion
        #region 属性

        #region {52AD1997-8BC0-4f22-97CA-2CF10B10C5F3} 设置参数能够调整左侧列宽 by guanyx
        private int leftWidth = 80;

        [Category("控件设置"), Description("调整左侧宽度 ")]
        public int LeftWidth
        {
            get
            {
                return this.ucInpatientCharge1.LeftWidth;
            }
            set
            {
                this.ucInpatientCharge1.LeftWidth = value;
            }
        }

        #endregion

        [Category("控件设置"), Description("设置该控件加载的项目类别 药品:drug 非药品 undrug 所有: all")]
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType 加载项目类别
        {
            get
            {
                return ucInpatientCharge1.加载项目类别;
            }
            set
            {
                ucInpatientCharge1.加载项目类别 = value;
            }
        }
        /// <summary>
        /// 控件功能
        /// </summary>
        [Category("控件设置"), Description("获得或者设置该控件的主要功能"), DefaultValue(1)]
        public Neusoft.HISFC.Components.Common.Controls.ucInpatientCharge.FeeTypes 控件功能
        {
            get
            {
                return this.ucInpatientCharge1.控件功能;
            }
            set
            {
                this.ucInpatientCharge1.控件功能 = value;
            }
        }

        /// <summary>
        /// 是否可以收费或者划价0单价的项目
        /// </summary>
        [Category("控件设置"), Description("获得或者设置是否可以收费或者划价"), DefaultValue(false)]
        public bool IsChargeZero
        {
            get
            {
                return this.ucInpatientCharge1.IsChargeZero;
            }
            set
            {
                this.ucInpatientCharge1.IsChargeZero = value;
            }
        }

        /// <summary>
        /// 是否显示比例项{2C7FCD3D-D9B4-44f5-A2EE-A7E8C6D85576}
        /// </summary>
        [Category("控件设置"), Description("是否显示比例项"), DefaultValue(false)]
        public bool IsShowFeeRate
        {
            get { return this.ucInpatientCharge1.IsShowFeeRate; }
            set
            {
                 
                this.ucInpatientCharge1.IsShowFeeRate = value;
            }
        }

        [Category("控件设置"), Description("是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            get
            {
                return this.ucInpatientCharge1.MessageType;
            }
            set
            {
                ucInpatientCharge1.MessageType = value;
            }
        }
        [Category("控件设置"), Description("数量为零是否提示和允许保存")]
        public bool IsJudgeQty
        {
            get
            {
                return this.ucInpatientCharge1.IsJudgeQty;
            }
            set
            {
                this.ucInpatientCharge1.IsJudgeQty = value;
            }
        }

        [Category("控件设置"), Description("执行科室是否默认为登陆科室")]
        public bool DefaultExeDeptIsDeptIn
        {
            get
            {
                return this.ucInpatientCharge1.DefaultExeDeptIsDeptIn;
            }
            set
            {
                this.ucInpatientCharge1.DefaultExeDeptIsDeptIn = value;
            }
        }

        #region donggq--20101118--{E64BCA09-C312-4488-BED3-1B0149E8B3E9}
        [Category("控件设置"), Description("树形控件加载统计大类类别，格式如下：'04','05'")]
        public string ArrFeeGate
        {
            get { return this.ucInpatientCharge1.ArrFeeGate; }
            set { this.ucInpatientCharge1.ArrFeeGate = value; }
        }

        [Category("控件设置"), Description("是否加载费别树形控件")]
        public bool IsShowItemTree
        {
            get { return this.ucInpatientCharge1.IsShowItemTree; }
            set { this.ucInpatientCharge1.IsShowItemTree = value; }
        } 
        #endregion
        // 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
        public OperationAppllication operationAppllication = null;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperationAppllication OperationAppllication
        {
            set
            {
                if (value == null)
                {
                    this.Clear();
                    return;
                }

                this.PatientInfo = value.PatientInfo;
                //PatientInfo = radtManager.GetPatientInfomation(value.PatientInfo.ID);
                if (value.IsHeavy)
                    this.lbOwn.Text = "同意使用自费项目";
                else
                    this.lbOwn.Text = "不同意使用自费项目";
                OperationAppllication apply = value;
                

                if (this.listType == ucRegistrationTree.EnumListType.Anaesthesia)
                {
                    if (apply.RoleAl != null && apply.RoleAl.Count != 0)
                    {
                        foreach (ArrangeRole role in apply.RoleAl)
                        {
                            if (role.RoleType.ID.ToString() == EnumOperationRole.Anaesthetist.ToString())//主麻
                            {
                                this.cmbDoctor.Tag = role.ID;
                                this.cmbDept.Tag = Environment.OperatorDept.ID;
                            }
                        }
                    }
                }
                else 
                {
                    this.cmbDoctor.Tag = apply.OperationDoctor.ID;//{F3C1935C-24E9-47a4-B7AE-4EA237A972C9}
                     //手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}

                    this.cmbDept.Tag = apply.OperationDoctor.Dept.ID;// this.OperationAppllication.ApplyDoctor.Dept.ID;
                    //this.cmbDept.Text = apply.OperationDoctor.Dept.Name; // this.OperationAppllication.ApplyDoctor.Dept.Name;
                }

                operationAppllication = value;
            }
            // 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
            get
            {
                return this.operationAppllication;
            }
        }

        ////{9B275235-0854-461f-8B7B-C4FE6EC6CC0B}
        private void InitControlName()
        {
            if (this.listType == ucRegistrationTree.EnumListType.Anaesthesia)
            {
                this.neuLabel3.Text = "麻醉医生";
                this.neuLabel1.Text = "麻醉收费通知单";
            }
        }
      
        private Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set
            {
                this.ucInpatientCharge1.Clear();

                #region donggq--2010.09.28--{2537B2F9-8656-40ce-8B4E-0006B747BB86}--医保患者特殊特殊显示

                if (value.Pact.ID != "01")
                {
                    this.lbName.ForeColor = Color.Red;
                    this.lbAge.ForeColor = Color.Red;
                    this.lbSex.ForeColor = Color.Red;
                    this.lbPatient.ForeColor = Color.Red;
                    this.lbDept.ForeColor = Color.Red;
                    this.lbPayKind.ForeColor = Color.Red;
                }
                else
                {
                    this.lbName.ForeColor = Color.Black;
                    this.lbAge.ForeColor = Color.Black;
                    this.lbSex.ForeColor = Color.Black;
                    this.lbPatient.ForeColor = Color.Black;
                    this.lbDept.ForeColor = Color.Black;
                    this.lbPayKind.ForeColor = Color.Black;
                } 

                #endregion
                this.lbName.Text = value.Name;
                this.lbAge.Text =Neusoft.HISFC.BizProcess.Integrate.Function.GetAge( value.Birthday);
                this.lbSex.Text = value.Sex.Name;
                this.lbPatient.Text = value.PID.PatientNO;
                this.lbDept.Text = value.PVisit.PatientLocation.Dept.Name;
                this.lbPayKind.Text = value.Pact.Name; //Environment.GetPayKind(value.Pact.PayKind.ID).Name;

                #region 医保信息

                //Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                //Hashtable ZZCityKind = new Hashtable();
                //ZZCityKind["302"] = "郑州市医疗保险(中原区)";
                //ZZCityKind["303"] = "郑州市医疗保险(二七区)";
                //ZZCityKind["304"] = "郑州市医疗保险(管城区)";
                //ZZCityKind["305"] = "郑州市医疗保险(金水区)";
                //ZZCityKind["306"] = "郑州市医疗保险(上街区)";
                //ZZCityKind["308"] = "郑州市医疗保险(惠济区)";
                //if (value.Pact.ID == "05")
                //{
                //    if (value.SIMainInfo.PersonType.ID == "41")
                //    {
                //        this.lbPayKind.Text += "----郑州市医疗保险(居民)";
                //    }
                //    else if ((value.SIMainInfo.PersonType.ID == "21" || value.SIMainInfo.PersonType.ID == "11") && !ZZCityKind.ContainsKey(value.SIMainInfo.Fund.Name))
                //    {
                //        this.lbPayKind.Text += "----郑州市医疗保险(职工)";
                //    }
                //    else
                //    {
                //        try
                //        {
                //            this.lbPayKind.Text += "----" + ZZCityKind[value.SIMainInfo.Fund.Name].ToString();
                //        }
                //        catch 
                //        {

                //        }

                //    }
                //}
                //else if (value.Pact.ID == "08")
                //{
                //    if (value.SIMainInfo.PersonType.ID == "11" || value.SIMainInfo.PersonType.ID == "21")
                //    {
                //        this.lbPayKind.Text += "----郑州市铁路医疗保险(职工)";
                //    }
                //    else if (value.SIMainInfo.PersonType.ID == "31")
                //    {
                //        this.lbPayKind.Text += "----郑州市铁路医疗保险(家庭)";
                //    }
                //    else
                //    {
                //        this.lbPayKind.Text += "----郑州市铁路医疗保险(离休)";
                //    }
                //}
                //else
                //{
                //    this.lbPayKind.Text += "----" + value.Pact.Name;
                //} 

                #endregion


                //this.cmbDept.Tag = Environment.OperatorDept.ID;
                
                //this.ucInpatientCharge1.RecipeDoctCode = Environment.OperatorID;
                ////为了调整手术室批费后的科室问题
                //this.ucInpatientCharge1.RecipeDept = Environment.OperatorDept;
                ////为了调整手术室批费后的科室问题
                //this.ucInpatientCharge1.RecipeDept = Environment.OperatorDept;

                //this.ucInpatientCharge1.RecipeDoctCode = value.PVisit.AdmittingDoctor.ID;
                //为了调整手术室批费后的科室问题
                //this.ucInpatientCharge1.RecipeDept = value.PVisit.AdmittingDoctor


                //{//{F3C1935C-24E9-47a4-B7AE-4EA237A972C9} } 手术医生
                //this.cmbDoctor.Tag = value.PVisit.AdmittingDoctor.ID;
                //this.cmbDoctor.Text = value.PVisit.AdmittingDoctor.Name;
                try
                {
                    if (value.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者不是在院状态，不能进行收费操作"));
                    }


                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString());
                }
                this.ucInpatientCharge1.PatientInfo = value;
              

                this.cmbDoctor.Focus();
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {

            this.lbPayKind.Text = "";
            this.lbName.Text = "";
            this.lbPatient.Text = "";
            this.lbDept.Text = "";
            this.lbSex.Text = "";
            this.lbOwn.Text = "";
            this.lbAge.Text = string.Empty;
            this.lbDate.Text = Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd");

            //appObj = new neusoft.HISFC.Object.Operator.OpsApplication();
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.checkBox4.Checked = false;
            this.checkBox5.Checked = false;

            this.ucInpatientCharge1.Clear();
            this.cmbDoctor.Tag = "";
            
        }
        /// <summary>
        /// 保存，进行收费
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            //// 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
            this.ucInpatientCharge1.OperationNO = this.operationAppllication.ID;

            #region donggq--2010.09.28--{2537B2F9-8656-40ce-8B4E-0006B747BB86}--医保患者特殊特殊提示

            if (this.operationAppllication.PatientInfo.Pact.ID != "01") 
            {
                if (MessageBox.Show("该病人为医保,请确认是否保存？", "批费提示",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) 
                {
                    return -1;
                }
            }

            #endregion


            #region donggq--2010.09.30--{DC0950A9-CD29-43b0-9773-35B8AFA8D86A}--加入手术室批费后手术登记

            if (this.ucInpatientCharge1.Save() < 0)
            {
                MessageBox.Show("批费失败！");
                return -1;
            }
            else
            {
                if (!IsReg)
                {

                    #region donggq--2010.10.04--{45A9C879-357A-4945-93A0-DFA7FB967306}

                    Neusoft.HISFC.Models.Base.Employee employee = ((Neusoft.FrameWork.Models.NeuObject)this.cmbDoctor.SelectedItem) as Neusoft.HISFC.Models.Base.Employee;
                    employee.Dept = (Neusoft.FrameWork.Models.NeuObject)this.cmbDept.SelectedItem as Neusoft.HISFC.Models.Base.Department;
                    this.OperationAppllication.OperationDoctor = employee;

                    if (employee != null)
                    {
                        Environment.OperationManager.UpdateApplication(this.OperationAppllication);
                    }

                    #endregion

                    MessageBox.Show(this.ucInpatientCharge1.SucessMsg);



                    Neusoft.HISFC.BizLogic.Operation.OpsRecord recordManager = new Neusoft.HISFC.BizProcess.Integrate.Operation.OpsRecord();
                    Neusoft.HISFC.Models.Operation.OperationRecord record = recordManager.GetOperatorRecord(this.operationAppllication.ID);
                    if (record != null)
                    {
                        this.ucInpatientCharge1.Clear();
                        this.Clear();

                        return 1;
                    }

                    if (this.listType == ucRegistrationTree.EnumListType.Operation)
                    {
                        if (DialogResult.Yes == MessageBox.Show("是否进行手术登记？", "快速登记提示",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            //Neusoft.HISFC.Components.Operation.ucRegistrationAfterFee operateReg = new Neusoft.HISFC.Components.Operation.ucRegistrationAfterFee();

                            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "手术登记";
                            //operateReg.IsNew = true;
                            //operateReg.OperationAppllication = this.operationAppllication;
                            //operateReg.IsCancled = false;

                            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(operateReg);



                            Neusoft.HISFC.Components.Operation.ucRegistrationQuick operateReg = new Neusoft.HISFC.Components.Operation.ucRegistrationQuick();

                            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "手术登记";
                            //operateReg.IsNew = true;
                            operateReg.OperationApplication = this.operationAppllication;
                            //operateReg.IsCancled = false;

                            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(operateReg);



                        }
                    }
                }//

            }

            #endregion


           this.ucInpatientCharge1.Clear();
           this.Clear();

            

            return 1;
        }

        /// <summary>
        /// 删除当前行
        /// </summary>
        /// <returns></returns>
        public int DelRow()
        {
            return this.ucInpatientCharge1.DelRow();
        }
        //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}


        public void InsertGroup(string groupID)
        {
            frmChooseGroupDetails frm = new frmChooseGroupDetails();
            frm.GroupID = groupID;
          DialogResult dr =   frm.ShowDialog();
          if (dr == DialogResult.Cancel)
          {
              return;
          }
          else
          {
              Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载组套信息");
              Application.DoEvents();
              this.ucInpatientCharge1.AddGroupDetail(groupID,frm.AlReturnDetails); 



              Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
          }

            frm.Dispose();

            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载组套信息");
            //Application.DoEvents();
            ////this.ucInpatientCharge1.AddGroupDetail(groupID); 

            

            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        public int Print()
        {
            return this.print.PrintPreview(this);
        }
        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Environment.DesignMode)
            {
                Neusoft.HISFC.Models.Base.Employee em = (Neusoft.HISFC.Models.Base.Employee)Environment.OperationManager.Operator;
                this.ucInpatientCharge1.Init(em.Dept.ID);
                //添加手术医生 {F3C1935C-24E9-47a4-B7AE-4EA237A972C9}
                Neusoft.HISFC.BizProcess.Integrate.Manager conMag = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList aDoc = conMag.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
                if (aDoc != null)
                {
                    this.cmbDoctor.AddItems(aDoc);
                }
                ArrayList alDept = conMag.QueryDeptmentsInHos(true);
                if (alDept != null)
                {
                    this.cmbDept.AddItems(alDept);
                }
            }
        }
        #endregion
        //{F3C1935C-24E9-47a4-B7AE-4EA237A972C9} 
        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.patientInfo != null)
            //{
                //this.patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoctor.Tag.ToString();
                //this.patientInfo.PVisit.AdmittingDoctor.Name = this.cmbDoctor.Text;
                //this.ucInpatientCharge1.RecipeDoctCode = this.cmbDoctor.Tag.ToString();
                //this.ucInpatientCharge1.RecipeDept = ((Neusoft.HISFC.Models.Base.Employee)this.cmbDoctor.SelectedItem).Dept;
            //}
           
                //this.ucInpatientCharge1.PatientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoctor.Tag.ToString();
            //this.ucInpatientCharge1.PatientInfo.PVisit.AdmittingDoctor.Name = this.cmbDoctor.Text;
            #region donggq--2010.09.30--{DC0950A9-CD29-43b0-9773-35B8AFA8D86A}--加入手术室批费后手术登记

            try
            {
                this.ucInpatientCharge1.RecipeDoctCode = this.cmbDoctor.Tag.ToString();
                this.ucInpatientCharge1.RecipeDept = ((Neusoft.HISFC.Models.Base.Employee)this.cmbDoctor.SelectedItem).Dept;

            }
            catch 
            {

            }
            #endregion

        }
        //{F3C1935C-24E9-47a4-B7AE-4EA237A972C9} 
        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ucInpatientCharge1.Focus();
            }


        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = null;
            try
            {
                obj = this.cmbDept.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            }
            catch (Exception)
            {

                return;
            }



            this.ucInpatientCharge1.RecipeDept = obj;

        }
    }
}
