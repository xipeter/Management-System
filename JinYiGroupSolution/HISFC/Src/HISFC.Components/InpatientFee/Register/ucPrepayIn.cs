using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.WinForms.Classes;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.BizLogic.Fee;

namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    public partial class ucPrepayIn : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPrepayIn()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo;

        /// <summary>
        /// adt接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        /// <summary>
        /// 科室查询
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager dept = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #region 查询变量
        DataTable dtPrepayIn=new DataTable();
        DataView dvPrepayIn;
        #endregion
        //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 属性
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return myPatientInfo;
            }
            set
            {
                if (value == null)
                    myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                else
                    myPatientInfo = value;
            }
        }

        #endregion

        #region 业务层变量

        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Fee.InPatient inpatient = new InPatient();
        /// <summary>
        /// 合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactUnitInfo = new PactUnitInfo();

        Neusoft.FrameWork.Public.ObjectHelper myObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();//合同单位
        Neusoft.FrameWork.Public.ObjectHelper operObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();//人员操作对象

        Neusoft.HISFC.Models.RADT.MaritalStatusEnumService maritalService = new Neusoft.HISFC.Models.RADT.MaritalStatusEnumService();
        /// <summary>
        ///诊断业务层
        /// </summary>
        Neusoft.HISFC.Models.HealthRecord.ICD MyIcd = null;
            
        #endregion

        #region 初始化

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("确定", "保存录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            
            toolBarService.AddToolButton("取消预约", "取消预约", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
            toolBarService.AddToolButton("入院通知单", "打印入院通知单", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印执行单, true, false, null);
  
            return this.toolBarService;
        }


        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "确定":
                    this.Save();
                    break;
                case "清屏":
                    this.Clear();
                    break;
                case "取消预约":
                    {
                        this.CancelPre();
                        break;
                    }
                //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
                case "入院通知单":
                    {
                        this.PrintNotice();
                        break;
                    }
                default:
                    break;
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();
            
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            
            return base.OnPrint(sender, neuObject);
        }


        /// <summary>
        /// 初始化控件,等信息
        /// </summary>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int Init()
        {
            
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化窗口，请稍候^^");
            Application.DoEvents();

            try
            {
                //初始化住院科室列表
                this.cmbDept.AddItems(this.managerIntegrate.GetDepartment());   //this.myDept.GetInHosDepartment());
                //护士站
                this.cmbNurseCell.AddItems(this.managerIntegrate.GetDepartment(EnumDepartmentType.N)); //this.myDept.GetDeptment(EnumDepartmentType.N));

                //婚姻状况
                this.cmbMarriage.AddItems(Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List());

                //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
                //this.cmbPactUnit.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.PACTUNIT));
                this.cmbPactUnit.AddItems(this.pactUnitInfo.QueryPactUnitAll());

                //职业信息
                this.cmbPos.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.PROFESSION));

                //国籍
                this.cmbCountry.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.COUNTRY));

                //出生地信息
                this.cmbHomePlace.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.DIST));

                //联系人地址信息
                this.cmbLinkManAddr.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.AREA));

                //家庭住址信息
                this.cmbHomeAddr.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.AREA));

                //预约医生
                this.cmbPreDoc.AddItems(this.managerIntegrate.QueryEmployee(EnumEmployeeType.D));

                //联系人关系
                this.cmbLinkManRel.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.RELATIVE));

                //民族
                this.cmbNationality.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.NATION));

                //性别			
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());

                //生日
                this.dtBirthday.Value = this.inpatient.GetDateTimeFromSysDateTime(); //this.myInpatient.GetDateTimeFromSysDateTime();
                //操作员
                //this.txtOper.Text =this.managerIntegrate. this.myInpatient.Operator.Name;

                //预约时间
                this.dtPreDate.Value = this.inpatient.GetDateTimeFromSysDateTime();

                //结算类别
                this.cmbPayKind.AddItems(this.managerIntegrate.GetConstantList(EnumConstant.PAYKIND));
                this.cmbPayKind.SelectedIndex = 0;
                this.dtBegin.Value = this.inpatient.GetDateTimeFromSysDateTime().AddDays(-1);
                this.dtEnd.Value = this.inpatient.GetDateTimeFromSysDateTime().AddDays(1);

                //诊断
                this.ucDiagnose1.Init();
                this.ucDiagnose1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(ucDiagnose1_SelectItem);
                this.ActiveControl = this.txtCardNo;
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            //this.RefreshPatientLists();
            this.InitInterface();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }
        #endregion 

        #region  方法

        public void Close() 
        {
            this.FindForm().Close();
        }

        /// <summary>
        /// 清屏
        /// </summary>
        public void Clear()
        {
            foreach (Control c in this.tabPage1.Controls)
            { 
                if(c.GetType()==typeof(Neusoft.FrameWork.WinForms.Controls.NeuGroupBox))
                {
                    foreach (Control ctr in c.Controls)
                    { 
                        if(ctr.GetType()==typeof(Neusoft.FrameWork.WinForms.Controls.NeuTextBox) 
                            || ctr.GetType()==typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                        {
                            if (ctr.Name != "txtOper")
                            {
                                ctr.Text = "";
                                ctr.Tag = "";
                            }
                        }

                    }
                }
            }
            this.dtPreDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
            this.dtBirthday.Value = this.inpatient.GetDateTimeFromSysDateTime();
            this.txtCardNo.Focus();
        }

        /// <summary>
        ///  验证卡号如果患者为不在院状态是返回true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool validCard(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            bool bRet = true;
            try
            {
                if (obj.PID.CardNO != null)//如果卡号不为空
                {
                    //如果患者为登记状态或在院状态返回假
                    if (obj.PVisit.InState.ID.ToString() == "R" || obj.PVisit.InState.ID.ToString() == "I")
                    {
                        bRet = false;
                    }
                }
            }
            catch { }
            return bRet;
        }

        /// <summary>
        /// 检索卡号
        /// </summary>
        /// <param name="CardNo"></param>
        private void searchCard(string CardNo)
        {
            ArrayList al = new ArrayList();
            //neusoft.HISFC.Models.RADT.PatientInfo objPreIn = new neusoft.HISFC.Models.RADT.PatientInfo();
            Neusoft.HISFC.Models.RADT.PatientInfo objPreIn = new Neusoft.HISFC.Models.RADT.PatientInfo();
            //返回患者信息住院主表
            al = this.managerIntegrate.QueryPatientInfoByCardNO(CardNo);// this.myInpatient.GetPatientInfoByCardNO(CardNo);
            if (al.Count > 0)
            {
                objPreIn = (Neusoft.HISFC.Models.RADT.PatientInfo)al[0];
                if (this.validCard(objPreIn))//判断是否为不在院状态
                {
                    //获得患者信息付给UI
                    this.getPrePatient(objPreIn);
                }
                else
                {
                    MessageBox.Show("该患者处于在院状态!");
                }
            }
            else
            {
                objPreIn = this.managerIntegrate.QueryComPatientInfo(CardNo);//患者信息表
                if (this.validCard(objPreIn))//判断是否为不在院状态
                {
                    //获得患者信息付给UI
                    this.getPrePatient(objPreIn);
                }
                else
                {
                    MessageBox.Show("该患者处于在院状态!");
                }
            }
        }

        /// <summary>
        /// 设置患者信息
        /// </summary>
        private void getPrePatient(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            try
            {
                if (obj.PID.CardNO != null)
                {
                    this.txtCardNo.Text = obj.PID.CardNO;//病例号
                    this.cmbDept.Tag = obj.PVisit.PatientLocation.Dept.ID;//住院科室
                    this.cmbDept.Text = obj.PVisit.PatientLocation.Dept.Name;
                    //this.dtPreDate.Value = obj.PVisit.InTime;//预约日期----------

                    this.txtName.Text = obj.Name;//姓名
                    this.cmbSex.Tag = obj.Sex.ID;//性别
                    this.cmbPactUnit.Tag = obj.Pact.ID;//合同单位
                    this.cmbPayKind.Tag = obj.Pact.PayKind.ID;//结算类别

                    this.dtBirthday.Value = obj.Birthday;//出生日期
                    this.cmbMarriage.Tag = obj.MaritalStatus.ID;//婚姻状况
                    this.txtIdentity.Text = obj.IDCard;//身份证号
                    this.cmbPos.Tag = obj.Profession.ID;//职业
                    this.cmbHomePlace.Tag = obj.DIST;//出生地
                    this.cmbCountry.Tag = obj.Country.ID;//国籍

                    this.cmbHomeAddr.Text = obj.AddressHome;//家庭住址
                    this.txtHomeTel.Text = obj.PhoneHome;//家庭电话
                    this.txtWorkUnit.Text = obj.CompanyName;//工作单位
                    this.txtLinkMan.Text = obj.Kin.ID;//联系人
                    this.cmbLinkManAddr.Text = obj.Kin.RelationAddress;//联系人住址
                    this.txtLinkTel.Text = obj.Kin.RelationPhone;//联系人电话
                    this.txtWorkTel.Text = obj.PhoneBusiness;//工作单位电话
                    this.cmbNationality.Tag = obj.Nationality.ID;//民族
                    this.cmbLinkManRel.Tag = obj.Kin.Relation.ID;//联系人关系
                    this.cmbBedNo.Tag = obj.PVisit.PatientLocation.Bed.ID;//病床号
                    this.cmbPreDoc.Tag = obj.PVisit.AdmittingDoctor.ID;//预约医生
                    if(obj.Diagnoses.Count>0)
                        this.txtInDiagnose.Tag = (obj.Diagnoses[0] as Neusoft.FrameWork.Models.NeuObject).ID;//门诊诊断编码

                    this.txtInDiagnose.Text = obj.ClinicDiagnose;//门诊诊断名称
                    
                    this.txtSSN.Text = obj.SSN;//医疗证号
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存预约患者登记信息
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            try
            {
                //有效性判断
                if (!this.checkValid()) return -1;
                //得到PatientInfo实体
                this.setPrePatient();
                //事务处理
                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(inpatient.Connection);// myInpatient.Connection);
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                if (this.managerIntegrate.InsertPreInPatient(this.PatientInfo) < 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    
                    if (this.managerIntegrate.DBErrCode == 1)
                    {
                        MessageBox.Show("此人已预约登记!");
                        this.txtCardNo.Focus();
                        this.txtCardNo.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("预约登记失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return -1;
                }

                #region addby xuewj 2010-3-15 

                if (this.cmbPreDoc.SelectedIndex >= 0)
                {
                    this.myPatientInfo.PVisit.ReferringDoctor.ID = this.cmbPreDoc.Tag.ToString();
                    this.myPatientInfo.PVisit.ReferringDoctor.Name = this.cmbPreDoc.Text;

                    this.myPatientInfo.PVisit.AdmittingDoctor.ID = string.Empty;
                }

                if (this.adt == null)
                {
                    this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
                }
                if (this.adt != null)
                {
                    this.adt.PreRegInpatient(myPatientInfo);
                }
                #endregion

                //提交
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("预约登记成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Clear();
                this.neuTabControl1.SelectedIndex = 1;
                this.QueryData();

              DialogResult dr =  MessageBox.Show("是否打印入院通知单？", "提示", MessageBoxButtons.YesNo);
              if (dr == DialogResult.Yes)
              {
                  if (this.iPrintInHosNotice != null)
                  {
                      this.iPrintInHosNotice.SetValue(this.PatientInfo);
                      this.iPrintInHosNotice.Print();
                  }
              }

                return 0;
            }
            catch 
            {
                MessageBox.Show("预约登记失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// 判断输入合法性
        /// </summary>
        /// <returns></returns>
        private bool checkValid()
        {
            bool bRet = true;
            //判断诊断号
            if (this.txtCardNo.Text == null || this.txtCardNo.Text.Trim() == "")
            {
                MessageBox.Show("请输入病历号!", "提示");
                return false;
            }

            //判断姓名
            if (this.txtName.Text == "")
            {
                MessageBox.Show("请填写姓名！");
                return false;
            }
            //判断科室
            if (this.cmbDept.Text == "" || this.cmbDept.Tag == null)
            {
                MessageBox.Show("请输入科室！");
                return false;
            }
            //科室长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbDept.Text, 16))
            {
                MessageBox.Show("科室输入过长,请重新输入!");
                return false;
            }
            if (this.cmbDept.Tag == null)
            {
                MessageBox.Show("请输入科室！");
                return false;
            }
            //判断合同单位
            if (this.cmbPactUnit.Text == "" || this.cmbPactUnit.Tag == null)
            {
                MessageBox.Show("请输入合同单位！");
                return false;
            }
            //出生日期 
            if (this.dtBirthday.Value > this.inpatient.GetDateTimeFromSysDateTime())
            {
                MessageBox.Show("出生日期大于当前日期,请重新输入!");
                this.dtBirthday.Focus();
                return false;
            }

            //判断性别
            if (this.cmbSex.Text == "" || this.cmbSex.Tag == null)
            {
                MessageBox.Show("请输入性别！");
                return false;
            }
            //判断字符超长联系人电话
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkTel.Text,20))
            {
                MessageBox.Show("联系人电话录入超长！");
                this.txtLinkTel.Focus();
                return false;
            }
            //家庭电话
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomeTel.Text, 20))
            {
                MessageBox.Show("家庭电话录入超长！");
                this.txtHomeTel.Focus();
                return false;
            }
            //身份证
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtIdentity.Text, 18))
            {
                MessageBox.Show("身份证号码录入超过18位！");
                this.txtIdentity.Focus();
                return false;
            }
            if (this.cmbPayKind.Text == "" || this.cmbPayKind.Tag == null)
            {
                MessageBox.Show("结算类别不能为空，" + "\n" + "请选择计算类别");
                this.cmbPayKind.Focus();
                return false;
            }
            return bRet;
        }

        /// <summary>
        /// 诊断控件事件
        /// </summary>
        private void loadEven()
        {
            //回车跳转焦点
            foreach (Control c in this.neuGroupBox1.Controls)
            {
                c.KeyDown += new KeyEventHandler(c_KeyDown);
            }
            foreach (Control c in this.neuGroupBox2.Controls)
            {
                c.KeyDown += new KeyEventHandler(c_KeyDown);
            }
            foreach (Control c in this.neuGroupBox3.Controls)
            {
                c.KeyDown += new KeyEventHandler(c_KeyDown);
            }
            foreach (Control c in this.neuGroupBox4.Controls)
            {
                c.KeyDown += new KeyEventHandler(c_KeyDown);
            }

        }

        /// <summary>
        /// 从ui获得患者信息
        /// </summary>
        private void setPrePatient()
        {
            try
            {
                if (this.myPatientInfo == null) myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                this.myPatientInfo.PID.CardNO = txtCardNo.Text;//病例号
                if (this.cmbDept.Tag != null)
                    this.myPatientInfo.PVisit.PatientLocation.Dept.ID = cmbDept.Tag.ToString();//住院科室
                #region {83D537A1-AA54-4916-9EE4-33E2034A1903}
                Neusoft.FrameWork.Models.NeuObject Nurseobj = new Neusoft.FrameWork.Models.NeuObject();
                Nurseobj.ID = this.myPatientInfo.PVisit.PatientLocation.Dept.ID;
                ArrayList alNurseCell = this.dept.QueryNurseStationByDept(Nurseobj);
                if (alNurseCell.Count != 0)
                {
                    this.myPatientInfo.PVisit.PatientLocation.NurseCell.ID = (alNurseCell[0] as Neusoft.FrameWork.Models.NeuObject).ID;
                }
                #endregion
                this.myPatientInfo.PVisit.PatientLocation.Dept.Name = this.cmbDept.Text;
                this.myPatientInfo.PVisit.InTime = this.dtPreDate.Value;//预约日期----------

                this.myPatientInfo.Name = this.txtName.Text;//姓名
                if (this.cmbSex.Tag != null)
                    this.myPatientInfo.Sex.ID = this.cmbSex.Tag.ToString();//性别
                if (this.cmbPactUnit.Tag != null)
                    this.myPatientInfo.Pact.ID = this.cmbPactUnit.Tag.ToString();//合同单位
                if (this.cmbPayKind.Tag != null)
                    this.myPatientInfo.Pact.PayKind.ID = this.cmbPayKind.Tag.ToString();//结算类别
                

                this.myPatientInfo.Birthday = this.dtBirthday.Value;//出生日期
                if (this.cmbMarriage.Tag != null)
                    this.myPatientInfo.MaritalStatus.ID = this.cmbMarriage.Tag.ToString();//婚姻状况
                this.myPatientInfo.IDCard = this.txtIdentity.Text;//身份证号
                if (this.cmbPos.Tag != null)
                    this.myPatientInfo.Profession.ID = this.cmbPos.Tag.ToString();//职业
                if (this.cmbHomePlace.Tag != null)
                    this.myPatientInfo.DIST = this.cmbHomePlace.Tag.ToString();//出生地
                if (this.cmbCountry.Tag != null)
                    this.myPatientInfo.Country.ID = this.cmbCountry.Tag.ToString();//国籍

                this.myPatientInfo.AddressHome = this.cmbHomeAddr.Text;//家庭住址
                this.myPatientInfo.PhoneHome = this.txtHomeTel.Text;//家庭电话
                this.myPatientInfo.CompanyName = this.txtWorkUnit.Text;//工作单位
                this.myPatientInfo.Kin.ID = this.txtLinkMan.Text;//联系人
                this.myPatientInfo.Kin.RelationAddress = this.cmbLinkManAddr.Text;//联系人住址
                this.myPatientInfo.Kin.RelationPhone = this.txtLinkTel.Text;//联系人电话
                this.myPatientInfo.PhoneBusiness = this.txtWorkTel.Text;//工作单位电话
                if (this.cmbNationality.Tag != null)
                    this.myPatientInfo.Nationality.ID = this.cmbNationality.Tag.ToString();//民族
                if (this.cmbLinkManRel.Tag != null)
                    this.myPatientInfo.Kin.Relation.ID = this.cmbLinkManRel.Tag.ToString();//联系人关系
                if (this.cmbBedNo.Tag != null)
                {
                    this.myPatientInfo.PVisit.PatientLocation.Bed.ID = this.cmbBedNo.Tag.ToString();//病床号
                }
                if (this.cmbPreDoc.Tag != null)
                    this.myPatientInfo.PVisit.AdmittingDoctor.ID = this.cmbPreDoc.Tag.ToString();//预约医生
                Neusoft.FrameWork.Models.NeuObject obj=new Neusoft.FrameWork.Models.NeuObject();
                if (this.txtInDiagnose.Tag != null)
                {
                    obj.ID = this.txtInDiagnose.Tag.ToString();
                    obj.Name = this.txtInDiagnose.Text;
                }
                this.myPatientInfo.Diagnoses.Add(obj);//入院诊断	
                this.myPatientInfo.ClinicDiagnose = this.txtInDiagnose.Text; ;//门诊诊断名称
                this.myPatientInfo.SSN = this.txtSSN.Text;//医疗证号
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 取消预约登记
        /// </summary>
        /// <returns></returns>
        public int CancelPre()
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                MessageBox.Show("切换到查询页面!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            if (this.fpMainInfo_Sheet1.Rows.Count == 0) return -1;
            string CarNo = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 1].Text;
            string HappenNo = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 0].Text;
            if (MessageBox.Show("确认要取消预约登记" + CarNo + "号？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return -1;

            Neusoft.HISFC.Models.RADT.PatientInfo patient = this.managerIntegrate.QueryPreInPatientInfoByCardNO(HappenNo, CarNo);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int iRet = this.managerIntegrate.UpdatePreInPatientState(CarNo, "1", HappenNo);
            if (iRet < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("取消预约登记失败" + this.managerIntegrate.Err, 211);
                iRet = -1;
            }
            if (iRet == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("该条记录已被取消!");
                this.QueryData();
                iRet = -1;
            }
            if (iRet > 0)
            {

                #region addby xuewj 2010-3-15
                if (this.adt == null)
                {
                    this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
                }
                if (this.adt != null && patient != null)
                {
                    this.adt.CancelPreRegInpatient(patient);
                }
                #endregion
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("取消成功!");
                this.QueryData();
                iRet = 1;
            }
            
            return iRet;
        }

        /// <summary>
        /// 根据合同单位标示返回支付类别名称
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        private Neusoft.FrameWork.Models.NeuObject  GetPactUnitByID(string strID)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            
            PactInfo p = managerIntegrate.GetPactUnitInfoByPactCode(strID);
            if (p == null)
            {
                MessageBox.Show("检索合同单位出错" + this.managerIntegrate.Err, "提示");
                return null;
            }
            if (p.PayKind.ID == "" || p.PayKind == null)
            {
                MessageBox.Show("该合同单位的结算类别没有维护", "提示");
                return null;
            }
            else
            {
                switch (p.PayKind.ID)
                {
                    case "01":
                        obj.Name = "自费"; obj.ID = "01";
                        break;
                    case "02":
                        obj.Name = "保险";
                        obj.ID = "02";
                        break;
                    case "03":
                        obj.Name = "公费在职";
                        obj.ID = "03";
                        break;
                    case "04":
                        obj.Name = "公费退休";
                        obj.ID = "04";
                        break;
                    case "05":
                        obj.Name = "公费高干";
                        obj.ID = "05";
                        break;
                    default:
                        break;
                }
            }
            return obj;
        }

        /// <summary>
        /// 根据发生序号获得实体
        /// </summary>
        /// <param name="strNo"></param>
        /// <param name="strCardNo"></param>
        private void setPatient(string strNo, string strCardNo)
        {
            this.myPatientInfo = this.managerIntegrate.QueryPreInPatientInfoByCardNO(strNo, strCardNo);
            this.getPrePatient(myPatientInfo);
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            if (this.neuTabControl1.SelectedTab == this.tabPage2)
            {
                Neusoft.FrameWork.WinForms.Classes.Print p = new Print();
                p.PrintPreview(this.Panel1);
            }
        }

        /// <summary>
        /// 设置诊断控件显示
        /// </summary>
        private void SetLocation()
        {
            if (this.ucDiagnose1.Visible) return;
            this.ucDiagnose1.Top = this.neuGroupBox4.Top + this.txtInDiagnose.Top - this.ucDiagnose1.Height;
            this.ucDiagnose1.Left = this.neuGroupBox4.Left + this.txtInDiagnose.Left;
            this.ucDiagnose1.Visible = true;
        }
        /// <summary>
        /// 设置诊断value
        /// </summary>
        private void SetValue()
        {
            this.txtInDiagnose.Text = this.MyIcd.Name;
            this.txtInDiagnose.Tag = this.MyIcd.ID;
            this.ucDiagnose1.Visible = false;
            cmbNurseCell.Focus();
        }

        #endregion

        #region 事件
        private void ucPrepayIn_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Init();
                loadEven();
                InitQuery();
            }
        }

        /// <summary>
        /// 焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{tab}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = false;
            }

        }
    
        /// <summary>
        /// 键盘事件处理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.PriorRow();
                        break;
                    }
                case Keys.Down:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.NextRow();
                        break;
                    }
                case Keys.Escape:
                    {
                        if (this.ucDiagnose1.Visible)
                            this.ucDiagnose1.Visible = false;
                        break;
                    }
                case Keys.Space:
                    {
                            if (this.txtInDiagnose.ContainsFocus)
                            {
                                this.SetLocation();
                            }
                            break;
                    }

                case Keys.Enter:
                    {
                        if (this.txtInDiagnose.ContainsFocus)
                        {
                            if (this.ucDiagnose1.Visible)
                            {
                                if (ucDiagnose1_SelectItem(Keys.Enter) == 0)
                                {
                                    SetValue();
                                }
                            }
                        }
                        break;
                    }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.txtCardNo.Text.Trim() == "") return;
                string CardNo = Function.GetCarNO(this.txtCardNo.Text);
                this.txtCardNo.Text = CardNo;
                this.searchCard(CardNo);
            }
        }
        
        private void cmbPactUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strID = this.cmbPactUnit.Tag.ToString();
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj = this.GetPactUnitByID(strID);
                this.cmbPayKind.Tag = obj.ID;
                this.cmbPayKind.Text = obj.Name;
            }
            catch { }
        }
   
        /// <summary>
        /// 通过护士站过滤床位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNurseCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrBed = new ArrayList();
                string strID = this.cmbNurseCell.Tag.ToString();
                arrBed = this.managerIntegrate.QueryBedList(strID);// myBed.GetBedList(strID);
                this.cmbBedNo.AddItems(arrBed);
            }
            catch { }
        }

        private void fpMainInfo_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //当前行索引
                int iRow = e.Row;
                //获取发生序号
                string strNo = this.fpMainInfo_Sheet1.Cells[iRow, 0].Text.Trim();
                string strCardNo = this.fpMainInfo_Sheet1.Cells[iRow, 1].Text.Trim();
                //获得预约登记实体返回给属性
                this.setPatient(strNo, strCardNo);
                this.neuTabControl1.SelectedIndex = 0;
            }
            catch { }
        }

        private void txtInDiagnose_TextChanged(object sender, EventArgs e)
        {
            if (ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Filter(this.txtInDiagnose.Text.Trim());
            }
        }

        private int ucDiagnose1_SelectItem(Keys key)
        {
            int result = this.ucDiagnose1.GetItem(ref MyIcd);
            if (result < 0) return -1;
            SetValue();
            return 1;
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
            }
        }

        #endregion 

        #region 查询
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        private void SetDataTable()
        {
            this.fpMainInfo_Sheet1.RowCount = 0;

            Type str = typeof(String);
            Type date = typeof(DateTime);

            Type dec = typeof(Decimal);
            Type bo = typeof(bool);
            #region 预约登记列表

            dtPrepayIn.Columns.AddRange(new DataColumn[]{new DataColumn("发生序号", str),
															new DataColumn("病历号", str),
															new DataColumn("患者姓名", str),
															new DataColumn("性别", str),
															new DataColumn("合同单位", str),
															new DataColumn("住院科室", str),
															new DataColumn("预约日期", str),
															new DataColumn("当前状态", str),															
															new DataColumn("家庭地址", str),
															new DataColumn("家庭电话", str),
															new DataColumn("联系人", str),
															new DataColumn("联系人电话", str),
															new DataColumn("联系人地址", str),
															new DataColumn("操作员", str),
															new DataColumn("操作时间", str)});



            #endregion
        }

        private void InitQuery()
        {
            //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //this.myObjHelper.ArrayObject = this.managerIntegrate.GetConstantList(EnumConstant.PACTUNIT);
            this.myObjHelper.ArrayObject = this.pactUnitInfo.QueryPactUnitAll();

            this.operObjHelper.ArrayObject = this.managerIntegrate.QueryEmployeeAll();
            SetDataTable();
            QueryData();

        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public void QueryData()
        {
            string PrepayinState = this.GetState();
            string Begin = this.dtBegin.Value.ToShortDateString() + " 00:00:00";
            string End = this.dtEnd.Value.ToShortDateString() + " 23:59:59";
            this.QueryData(PrepayinState, Begin, End);
        }

        /// <summary>
        /// 根据预约状态和时间查找数据
        /// </summary>
        /// <param name="PrepayinState"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void QueryData(string PrepayinState,string begin,string end)
        {
            this.dtPrepayIn.Clear();
            try
            {
                ArrayList arrPrein = new ArrayList();
                
                //arrPrein = this.myInpatient.GetPreInPatientInfoByDateAndState(PrepayinState, begin, end);
                arrPrein = this.managerIntegrate.QueryPreInPatientInfoByDateAndState(PrepayinState, begin, end);
                string strName = "", strStateName = "";
                if (arrPrein == null)
                    return;
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo obj in arrPrein)
                {
                    #region　取性别名称
                    switch (obj.Sex.ID.ToString())
                    {
                        case "U":
                            strName = "未知";
                            break;
                        case "M":
                            strName = "男";
                            break;
                        case "F":
                            strName = "女";
                            break;
                        case "O":
                            strName = "其它";
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region 登记状态
                    switch (obj.User02.ToString())
                    {
                        case "0":
                            strStateName = "预约登记";
                            break;
                        case "1":
                            strStateName = "取消预约登记";
                            break;
                        case "2":
                            strStateName = "预约转住院";
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region 取合同单位、操作员名称
                    obj.Pact.Name = this.myObjHelper.GetName(obj.Pact.ID);
                    string strOperID = obj.User03.Substring(0, 6);
                    string strOperName = this.operObjHelper.GetName(strOperID);
                    #endregion

                    #region 向DataTable插入数据
                    DataRow row = this.dtPrepayIn.NewRow();
                    row["发生序号"] = obj.User01;
                    row["病历号"] = obj.PID.CardNO;
                    row["患者姓名"] = obj.Name;
                    row["性别"] = strName;
                    row["合同单位"] = obj.Pact.Name;//需转换
                    row["住院科室"] = obj.PVisit.PatientLocation.Dept.Name;
                    row["预约日期"] = obj.PVisit.InTime;//.Date_In;
                    row["当前状态"] = strStateName;//需转换
                    row["家庭地址"] = obj.AddressHome;
                    row["家庭电话"] = obj.PhoneHome;
                    row["联系人"] = obj.Kin.ID;
                    row["联系人电话"] = obj.Kin.Memo;
                    row["联系人地址"] = obj.Kin.User01;
                    row["操作员"] = strOperName;
                    row["操作时间"] = obj.User03.Substring(6, 10);

                    this.dtPrepayIn.Rows.Add(row);
                    #endregion 
                }

                dvPrepayIn = new DataView(this.dtPrepayIn);
                this.fpMainInfo_Sheet1.DataSource = this.dvPrepayIn;
                this.initFp();
                
            }
            catch { }
        }

        /// <summary>
        /// 控制fp宽度
        /// </summary>
        private void initFp()
        {
            try
            {
                int im = 3;
                this.fpMainInfo_Sheet1.OperationMode = (FarPoint.Win.Spread.OperationMode)im;
                this.fpMainInfo_Sheet1.Columns.Get(0).Width = 0F;
                this.fpMainInfo_Sheet1.Columns.Get(1).Width = 100F;
                this.fpMainInfo_Sheet1.Columns.Get(2).Width = 72F;
                this.fpMainInfo_Sheet1.Columns.Get(3).Width = 48F;
                this.fpMainInfo_Sheet1.Columns.Get(5).Width = 88F;
                this.fpMainInfo_Sheet1.Columns.Get(6).Width = 100F;
                this.fpMainInfo_Sheet1.Columns.Get(9).Width = 95F;
                this.fpMainInfo_Sheet1.Columns.Get(10).Width = 102F;
                this.fpMainInfo_Sheet1.Columns.Get(11).Width = 127F;
                this.fpMainInfo_Sheet1.Columns.Get(12).Width = 85F;
                //			this.fpMainInfo_Sheet1.Columns.Get(13).Width = 80F;
                this.fpMainInfo_Sheet1.Columns.Get(14).Width = 85F;
            }
            catch { }
        }

        /// <summary>
        /// 查看当前查询的状态
        /// </summary>
        /// <returns></returns>
        private string GetState()
        {
            string state = string.Empty;
            if (this.RbtPrePatient.Checked)
            {
                state = "0";
            }
            if (this.RbtCancelPre.Checked)
            {
                state = "1";
            }
            if (this.RbtChange.Checked)
            {
                state = "2";
            }
            return state;
        }

        /// <summary>
        /// 更改预约状态查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbtCheckChange(object sender, EventArgs e)
        {
            string PrepayinState = this.GetState();
            string Begin = this.dtBegin.Value.ToShortDateString() + " 00:00:00";
            string End = this.dtEnd.Value.ToShortDateString() + " 23:59:59";
            this.QueryData(PrepayinState, Begin, End);
        }

        #endregion       
    

        /// <summary>
        /// {C3AA974A-D98C-455b-ABDC-68781DB0306F}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int PrintPreview(object sender, object neuObject)
        {
            string strNO = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 0].Text;
            string cardNO = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 1].Text;
            Neusoft.HISFC.Models.RADT.PatientInfo p = this.managerIntegrate.QueryPreInPatientInfoByCardNO(strNO, cardNO);

            if (p == null)
            {
                MessageBox.Show("打印入院通知单时，查询患者预约信息失败。\n" + this.managerIntegrate.Err);
                return -1;
            }

            this.iPrintInHosNotice.SetValue(p);
            this.iPrintInHosNotice.PrintView();
            
            return base.PrintPreview(sender, neuObject);
        }
        //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
        private Neusoft.HISFC.BizProcess.Interface.IPrintInHosNotice iPrintInHosNotice = null;

        //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
        public int InitInterface()
        {

            iPrintInHosNotice = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IPrintInHosNotice)) as Neusoft.HISFC.BizProcess.Interface.IPrintInHosNotice;
            return 1;
        }
        //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
        private int PrintNotice()
        {
            string strNO = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 0].Text;
            string cardNO = this.fpMainInfo_Sheet1.Cells[this.fpMainInfo_Sheet1.ActiveRowIndex, 1].Text;
            Neusoft.HISFC.Models.RADT.PatientInfo p = this.managerIntegrate.QueryPreInPatientInfoByCardNO(strNO, cardNO);

            if (p == null)
            {
                MessageBox.Show("打印入院通知单时，查询患者预约信息失败。\n" + this.managerIntegrate.Err);
                return -1;
            }

            this.iPrintInHosNotice.SetValue(p);
            this.iPrintInHosNotice.Print();


            return 1;

        }
    
        #region IInterfaceContainer 成员
        //{C3AA974A-D98C-455b-ABDC-68781DB0306F}
        public Type[] InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IPrintInHosNotice);

                return type;
            }
        }

        #endregion
    }
}
