using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.BizProcess.Integrate;
using Neusoft.HISFC.BizLogic.Operation;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术审请单]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucApplicationForm : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucApplicationForm()
        {

            InitializeComponent();
            if (!this.DesignMode)
            {
                this.Reset();
                this.Init();
            }

        }

        #region 字段
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtmanager = new RADT();
        private Neusoft.FrameWork.Public.ObjectHelper payKindHelper;
        private Neusoft.HISFC.Models.Operation.OperationAppllication operationApplication = new Neusoft.HISFC.Models.Operation.OperationAppllication();
        private Neusoft.HISFC.BizProcess.Integrate.Operation.OpsDiagnose opsDiagnose = new Neusoft.HISFC.BizProcess.Integrate.Operation.OpsDiagnose();
        private bool isNew = true;     //是否新建申请
        private Neusoft.HISFC.BizProcess.Interface.Operation.IArrangeNotifyFormPrint arrangeFormPrint;
        private System.Windows.Forms.Control contralActive = new Control();
        private bool dirty = false;
        private Neusoft.HISFC.BizLogic.Operation.OpsTableManage opsMgr = new OpsTableManage();
        private Neusoft.HISFC.Models.Base.Employee var = null;
        private bool checkApplyTime = false;
        private bool checkEmergency = true;
        private bool checkDate = true;
        #endregion

        #region 属性

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PatientInfo PatientInfo
        {
            set
            {
                this.Reset();

                if (value == null)
                    return;

                #region 赋值
                this.lblName.Text = value.Name;
                this.lblGender.Text = value.Sex.Name;
                //Neusoft.FrameWork.Management.DataBaseManger daMgr = new Neusoft.FrameWork.Management.DataBaseManger();
                //int age = daMgr.GetDateTimeFromSysDateTime().Year - value.Birthday.Year;
                this.lblAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(value.Birthday);//age.ToString() + "岁";
                this.lblID.Text = value.PID.PatientNO;


                //this.lblType.Text = payKindHelper.GetName(value.Pact.PayKind.ID);
                this.lblType.Text = value.Pact.Name;
                this.lblDept.Text = value.PVisit.PatientLocation.Dept.Name;
                this.lblBed.Text = value.PVisit.PatientLocation.Bed.Name;
                this.lblBalance.Text = value.FT.LeftCost.ToString();

               
                //手术室
                //如果操作员为手术室人员,默认手术室为操作员所在科室
                foreach (Department dept in this.cmbExeDept.alItems)
                {
                    if (dept.ID == Environment.OperatorDeptID)
                    {
                        this.cmbExeDept.Tag = dept.ID;
                        break;
                    }
                }
                //没有赋值,表明操作员不是手术室人员,默认列表中第一项
                if (this.cmbExeDept.Tag == null || this.cmbExeDept.Tag.ToString() == "")
                {
                    if (this.cmbExeDept.Items.Count > 0)
                        this.cmbExeDept.SelectedIndex = 0;
                }
                //根据指定时间和手术室判断当天是否有正台,如无自动变为加台
                Department d = this.cmbExeDept.SelectedItem as Department;

                int num = Environment.OperationManager.GetEnableTableNum(d, value.PVisit.PatientLocation.Dept.ID, this.dtOperDate.Value);
                if (num > 0)
                    this.cmbTableType.SelectedIndex = 0;//正台
                else
                    this.cmbTableType.SelectedIndex = 1;//加台
                #endregion

                this.operationApplication.PatientInfo = value;
                this.isNew = true;


            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.Operation.OperationAppllication OperationApplication
        {
            get
            {
                if (this.operationApplication == null)
                    this.operationApplication = new OperationAppllication();

                return this.operationApplication;
            }
            set
            {
                this.operationApplication = value;


                #region 赋值


                PatientInfo p = this.radtmanager.GetPatientInfomation(value.PatientInfo.ID);
                if (p == null)
                {
                    MessageBox.Show("无此患者信息!", "提示");
                    return;
                }
                this.PatientInfo = p;// this.operationApplication.PatientInfo;

                if (value.OperateKind == "1")
                { this.cmbOperKind.SelectedIndex = 0; }//择期
                else if (value.OperateKind == "2")
                { this.cmbOperKind.SelectedIndex = 1; }//急诊
                else
                { this.cmbOperKind.SelectedIndex = 2; }//感染

                if (value.DiagnoseAl.Count > 0)//第一诊断
                {
                    dirty = true;
                    this.txtDiag.Text = (value.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;//诊断
                    dirty = false;
                    Neusoft.HISFC.Models.HealthRecord.ICD icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                    icd.ID = (value.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ID;
                    icd.Name = (value.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;
                    this.txtDiag.Tag = icd;

                    if (value.DiagnoseAl.Count >= 2) //第二诊断
                    {
                        //dirty = true;
                        this.txtDiag2.Text = (value.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;//诊断
                        //dirty = false;
                        icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                        icd.ID = (value.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ID;
                        icd.Name = (value.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;
                        this.txtDiag2.Tag = icd;
                        if (value.DiagnoseAl.Count >= 3) //第三诊断 
                        {
                            dirty = true;
                            this.txtDiag3.Text = (value.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;//诊断
                            dirty = false;
                            icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                            icd.ID = (value.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ID;
                            icd.Name = (value.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).Name;
                            this.txtDiag3.Tag = icd;

                        }

                    }
                }
                if (value.OperationInfos.Count > 0) //第一手术 
                {
                    dirty = true;
                    this.txtOperation.Text = (value.OperationInfos[0] as Neusoft.HISFC.Models.Operation.OperationInfo).OperationItem.Name;
                    dirty = false;
                    this.txtOperation.Tag = (Neusoft.HISFC.Models.Operation.OperationInfo)value.OperationInfos[0];//手术名称

                    if (value.OperationInfos.Count >= 2) //第二手术 
                    {
                        dirty = true;
                        this.txtOperation2.Text = (value.OperationInfos[1] as Neusoft.HISFC.Models.Operation.OperationInfo).OperationItem.Name;
                        dirty = false;
                        this.txtOperation2.Tag = (Neusoft.HISFC.Models.Operation.OperationInfo)value.OperationInfos[1];//手术名称
                        if (value.OperationInfos.Count >= 3)//第三手术
                        {
                            dirty = true;
                            this.txtOperation3.Text = (value.OperationInfos[2] as Neusoft.HISFC.Models.Operation.OperationInfo).OperationItem.Name;
                            dirty = false;
                            this.txtOperation3.Tag = (Neusoft.HISFC.Models.Operation.OperationInfo)value.OperationInfos[2];//手术名称
                        }
                    }
                }

                //麻醉方式
                this.cmbAnae.Tag = value.AnesType.ID;
                value.AnesType.Name = this.cmbAnae.Text;

                ////{B9DDCC10-3380-4212-99E5-BB909643F11B}
                this.cmbAnseWay.Tag = value.AnesWay;
                this.dtOperDate.Value = value.PreDate;//手术日期
                this.cmbExeDept.Tag = value.ExeDept.ID;//执行科室
                this.comDept.Tag = value.OperationDoctor.Dept.ID;

                //if (value.TableType == "1")
                //{ this.cmbTableType.SelectedIndex = 0; }//正台
                //else if (value.TableType == "2")
                //{ this.cmbTableType.SelectedIndex = 1; }//加台
                //else
                //{ this.cmbTableType.SelectedIndex = 2; }//点台

                this.cmbDoctor.Tag = value.OperationDoctor.ID;//术者
                foreach (Neusoft.HISFC.Models.Operation.ArrangeRole role in value.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.Helper1.ToString())
                    {
                        this.cmbHelper1.Tag = role.ID;//一助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.Helper2.ToString())
                    {
                        this.cmbHelper2.Tag = role.ID;//二助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.Helper3.ToString())
                    {
                        this.cmbHelper3.Tag = role.ID;//三助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper1.ToString()) //donggq
                    {
                        this.txtTmpHelper1.Tag = role.ID;
                        this.txtTmpHelper1.Text = role.Name;
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper2.ToString()) //donggq
                    {
                        this.txtTmpHelper2.Tag = role.ID;
                        this.txtTmpHelper2.Text = role.Name;
                    }

                }

                
                this.cmbInfectType.SelectedIndex = int.Parse(value.BloodNum.ToString());//是否特殊手术

                //this.cmbOrder.Text = value.BloodUnit;//台序

                //if (value.IsAccoNurse)
                //    this.cbxNeedQX.Checked = true;//器械护士
                //if (value.IsPrepNurse)
                //    this.cbxNeedXH.Checked = true;//巡回护士
                
                //{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
                this.cmbIncitepe.Tag = value.InciType.ID;

                //是否同意使用自费项目
                this.cmbOwn.SelectedIndex = value.IsHeavy ? 0 : 1;

                //合并疾病
                this.txtAnaeNote.Text = value.AneNote;

                //特殊说明
                this.rtbApplyNote.Text = value.ApplyNote;

                this.cmbApplyDoct.Tag = value.ApplyDoctor.ID;//申请医生
                this.lbApplyDate.Text = value.ApplyDate.ToString("yyyy年MM月dd日 HH时mm分");

                
                #endregion

                this.operationApplication = value;
                this.isNew = false;//修改
            }
        }

        protected new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");


            }
        }

        /// <summary>
        /// 主手术项目
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NeuObject MainOperation
        {
            set
            {
                this.txtOperation.Text = value.Name;
                this.txtOperation.Tag = value.ID;
            }
        }

        /// <summary>
        /// 是否是新申请手术
        /// </summary>
        public bool IsNew
        {
            get
            {
                return this.isNew;
            }
            set
            {
                this.isNew = value;
            }
        }
        
        [Category("控件设置"), Description("允许申请比当前时间早的手术")]
        public bool CheckApplyTime
        {
            get
            {
                return checkApplyTime;
            }
            set
            {
                checkApplyTime = value;
            }
        }
        [Category("控件设置"), Description("申请时间超过截止时间，是否需要改为急诊")]
        public bool CheckEmergency
        {
            get
            {
                return checkEmergency;
            }
            set
            {
                checkEmergency = value;
            }
        }
        [Category("控件设置"), Description("周六周日不能申请周一的手术")]
        public bool CheckDate
        {
            get
            {
                return checkDate;
            }
            set
            {
                checkDate = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 初使化
        /// </summary>
        private void Init()
        {
            var = (Neusoft.HISFC.Models.Base.Employee)opsMgr.Operator;
            //支付类型
            //this.payKindHelper = new Neusoft.FrameWork.Public.ObjectHelper(Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYKIND));

            ArrayList alRet;

            //麻醉类型
            alRet = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE);
            this.cmbAnae.AddItems(alRet);
            this.cmbAnae.IsListOnly = true;

            //麻醉类别'麻醉类别（局麻或选麻，医生申请时填写）//{B9DDCC10-3380-4212-99E5-BB909643F11B}
            alRet = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESWAY);
            this.cmbAnseWay.AddItems(alRet);
            this.cmbAnseWay.IsListOnly = true;


            //手术室
            alRet = Environment.IntegrateManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.OP);
            this.cmbExeDept.AddItems(alRet);
            this.cmbExeDept.IsListOnly = true;
            if (alRet.Count >= 2)
            {
                //this.cmbExeDept.Text = alRet[0].ToString();
                this.cmbExeDept.SelectedIndex = 1;
            }
            
            //术者科室---加载科室
            ArrayList deptList = Environment.IntegrateManager.QueryDeptmentsInHos(true);
            this.comDept.AddItems(deptList); 
            
            //感染类型
            alRet = Environment.IntegrateManager.GetConstantList("INFECTTYPE");
            this.cmbInfectType.AddItems(alRet);

            //术者
            alRet = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            this.cmbDoctor.AddItems(alRet);
            this.cmbDoctor.IsListOnly = true;
            //一助
            this.cmbHelper1.AddItems(alRet);
            this.cmbHelper1.IsListOnly = true;
            //二助          
            this.cmbHelper2.AddItems(alRet);
            this.cmbHelper2.IsListOnly = true;
            //三助手            
            this.cmbHelper3.AddItems(alRet);
            this.cmbHelper3.IsListOnly = true;
            //申请医生
            this.cmbApplyDoct.AddItems(alRet);
            this.cmbApplyDoct.IsListOnly = true;

            //切口类型{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
            alRet = Environment.IntegrateManager.GetConstantList(EnumConstant.INCITYPE);

            this.cmbIncitepe.AddItems(alRet);
            this.cmbIncitepe.IsListOnly = true;

            //设置注意事项
            Neusoft.HISFC.BizProcess.Integrate.Manager ctlMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            try
            {	//查询手术申请截至时间
                string control = ctlMgr.QueryControlerInfo("optime");

                if (control != "" && control != "-1") this.lbNote.Text = "要求在" + control + "前发送手术申请，否则将使用接台。";

                if (this.cmbExeDept.Items.Count > 0)
                {
                    ArrayList list = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ExeDept");
                    if (list.Count == 2)
                    {
                        this.cmbExeDept.Text = list[0].ToString();
                        this.cmbExeDept.Tag = list[1].ToString();
                    }
                }
            }
            catch { }

            #region 诊断
            ucDiag1 = new Neusoft.HISFC.Components.Common.Controls.ucDiagnose();
            this.Controls.Add(ucDiag1);
            ucDiag1.Size = new Size(456, 312);
            ucDiag1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(ucDiag1_SelectItem);
            ucDiag1.Init();
            ucDiag1.Visible = false;
            #endregion

            #region 手术
            ucOpItem1 = new ucOpItem();
            this.Controls.Add(ucOpItem1);
            ucOpItem1.Size = new Size(518, 338);
            ucOpItem1.SelectItem += new ucOpItem.MyDelegate(ucOpItem1_SelectItem);
            ucOpItem1.Init();
            ucOpItem1.Visible = false;
            #endregion 

        }

        /// <summary>
        /// 重新设置控件
        /// </summary>
        private void Reset()
        {
            this.operationApplication = new OperationAppllication();

            this.lblName.Text = "";
            this.lblGender.Text = "";
            this.lblAge.Text = "";
            this.lblID.Text = "";
            this.lblType.Text = "";
            this.lblDept.Text = "";
            this.lblBed.Text = "";
            this.lblBalance.Text = "";

            //手术类别
            this.cmbOperKind.SelectedIndex = 0;//普通

            //dirty = true;
            this.txtDiag.Text = "";//诊断
            this.txtDiag.Tag = null;
            this.txtDiag2.Text = "";//诊断
            this.txtDiag2.Tag = null;
            this.txtDiag3.Text = "";//诊断
            this.txtDiag3.Tag = null;

            this.txtOperation.Text = "";//手术名称
            this.txtOperation.Tag = null;
            this.txtOperation2.Text = "";//手术名称
            this.txtOperation2.Tag = null;
            this.txtOperation3.Text = "";//手术名称
            this.txtOperation3.Tag = null;
            //dirty = false;

            this.cmbAnae.Text = "";//麻醉类型
            this.cmbAnae.Tag = null;
            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            this.cmbAnseWay.Text = "";
            this.cmbAnseWay.Tag = null;

            DateTime dtNow = Environment.OperationManager.GetDateTimeFromSysDateTime();
            this.lbApplyDate.Text = dtNow.ToString("yyyy年MM月dd日 HH时mm分");//申请日期

            dtNow = dtNow.Date.AddDays(1).AddHours(9); ;//DateTime.Parse(string.Concat(dtNow.Date.AddDays(1).ToString("yyyy-MM-dd"), " 09:00:00"));
            this.dtOperDate.Value = dtNow;//预约时间

            this.cmbExeDept.Text = "";//手术室
            this.cmbExeDept.Tag = null;

            if (this.cmbExeDept.Items.Count >= 2) 
            {
                this.cmbExeDept.SelectedIndex = 1;
            }


            this.rtbApplyNote.Text = "";//备注
            this.cbxNeedQX.Checked = false;
            this.cbxNeedXH.Checked = false;

            this.cmbDoctor.Text = "";//手术者
            this.cmbDoctor.Tag = null;

            this.cmbHelper1.Text = "";//一助
            this.cmbHelper1.Tag = null;

            this.cmbHelper2.Text = "";//二助
            this.cmbHelper2.Tag = null;

            this.cmbHelper3.Text = "";//三助
            this.cmbHelper3.Tag = null;

            this.txtTmpHelper1.Text = string.Empty;
            this.txtTmpHelper1.Tag = null;

            this.txtTmpHelper2.Text = string.Empty;
            this.txtTmpHelper2.Tag = null;

            //切口
            this.cmbIncitepe.Text = "";
            this.cmbIncitepe.Tag = null;

            //感染类型
            this.cmbInfectType.Text = "";
            this.cmbInfectType.Tag = null;
            

            //台序
            //this.cmbOrder.Text = "";

            //合并疾病
            this.txtAnaeNote.Text = string.Empty;
            this.txtAnaeNote.Tag = null;

            //自费
            this.cmbOwn.SelectedIndex = 0;

            //申请医生
            this.cmbApplyDoct.Text = "";
            this.cmbApplyDoct.Tag = null;

            foreach (Employee person in this.cmbApplyDoct.alItems)
            {
                if (person.ID == Neusoft.FrameWork.Management.Connection.Operator.ID)
                {
                    this.cmbApplyDoct.Tag = Neusoft.FrameWork.Management.Connection.Operator.ID;
                    break;
                }
            }

            

            this.operationApplication = new Neusoft.HISFC.Models.Operation.OperationAppllication();
            this.isNew = true;

        }

        /// <summary>
        /// 实体赋值
        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            //新录入的，生成新的申请单
            if (this.isNew)
                this.operationApplication.ID = Environment.OperationManager.GetNewOperationNo();

            #region 诊断
            Neusoft.HISFC.Models.HealthRecord.DiagnoseBase diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();

            diag.OperationNo = this.operationApplication.ID;//申请号
            //diag.ICD10=(neusoft.HISFC.Object.Case.ICD10)this.txtDiag.Tag;
            diag.ID = (this.txtDiag.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).ID;
            diag.Name = (this.txtDiag.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
            diag.Patient = this.operationApplication.PatientInfo.Clone();//.PatientInfo.Patient.Clone();
            diag.DiagType.ID = "7";//诊断类型
            diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
            diag.DiagDate = opsMgr.GetDateTimeFromSysDateTime();//诊断时间
            diag.Doctor.ID = var.ID;//诊断医生
            diag.Doctor.Name = var.Name;//诊断医生
            diag.Dept.ID = var.Dept.ID;//诊断科室
            diag.IsValid = true;//是否有效
            diag.IsMain = true;//主诊断

            if (operationApplication.DiagnoseAl.Count == 0)
                diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
            else
                diag.HappenNo = (operationApplication.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;

            operationApplication.DiagnoseAl.Clear();
            operationApplication.DiagnoseAl.Add(diag);
            #region 第二诊断
            if (txtDiag2.Tag != null)
            {
                diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
                diag.OperationNo = this.operationApplication.ID;//申请号
                //diag.ICD10=(neusoft.HISFC.Object.Case.ICD10)this.txtDiag.Tag;
                diag.ID = (this.txtDiag2.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).ID;
                diag.Name = (this.txtDiag2.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                diag.Patient = this.operationApplication.PatientInfo.Clone();
                diag.DiagType.ID = "7";//诊断类型
                diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
                diag.DiagDate = opsMgr.GetDateTimeFromSysDateTime();//诊断时间
                diag.Doctor.ID = var.ID;//诊断医生
                diag.Doctor.Name = var.Name;//诊断医生
                diag.Dept.ID = var.Dept.ID;//诊断科室
                diag.IsValid = true;//是否有效
                diag.IsMain = false;//主诊断

                if (operationApplication.DiagnoseAl.Count == 1)
                    diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
                else
                    diag.HappenNo = (operationApplication.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;
                operationApplication.DiagnoseAl.Add(diag);
            }
            #endregion
            #region 第三诊断
            if (txtDiag3.Tag != null)
            {
                diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
                diag.OperationNo = this.operationApplication.ID;//申请号
                //diag.ICD10=(neusoft.HISFC.Object.Case.ICD10)this.txtDiag.Tag;
                diag.ID = (this.txtDiag3.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).ID;
                diag.Name = (this.txtDiag3.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                diag.Patient = this.operationApplication.PatientInfo.Clone();
                diag.DiagType.ID = "7";//诊断类型
                diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
                diag.DiagDate = opsMgr.GetDateTimeFromSysDateTime();//诊断时间
                diag.Doctor.ID = var.ID;//诊断医生
                diag.Doctor.Name = var.Name;//诊断医生
                diag.Dept.ID = var.Dept.ID;//诊断科室
                diag.IsValid = true;//是否有效
                diag.IsMain = false;//主诊断

                if (operationApplication.DiagnoseAl.Count == 2)
                    diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
                else
                    diag.HappenNo = (operationApplication.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;
                operationApplication.DiagnoseAl.Add(diag);
            }
            #endregion
            #endregion

            #region 手术项目

            this.operationApplication.OperationInfos.Clear();
            //-----------------------------------------------------------------------------
            if (this.txtOperation.Text.Trim() != "" && this.txtOperation.Tag != null)
            {
                if (this.txtOperation.Tag.GetType() == typeof(Neusoft.HISFC.Models.Operation.OperationInfo))
                {
                    Neusoft.HISFC.Models.Operation.OperationInfo obj = (Neusoft.HISFC.Models.Operation.OperationInfo)txtOperation.Tag;
                    operationApplication.OperationInfos.Add(obj);
                }
                else
                {
                    Neusoft.HISFC.Models.Operation.OperationInfo opItem = new Neusoft.HISFC.Models.Operation.OperationInfo();
                    opItem.OperationItem = (Neusoft.HISFC.Models.Base.Item)this.txtOperation.Tag;//手术项目
                    opItem.FeeRate = 1m;//比率
                    opItem.Qty = 1;//数量
                    opItem.StockUnit = (this.txtOperation.Tag as Neusoft.HISFC.Models.Base.Item).PriceUnit;//单位
                    opItem.OperateType.ID = (this.txtOperation.Tag as Neusoft.HISFC.Models.Fee.Item.Undrug).OperationScale.ID;
                    opItem.IsValid = true;
                    opItem.IsMainFlag = true; 
                    operationApplication.OperationInfos.Add(opItem);
                    operationApplication.OperationType.ID = opItem.OperateType.ID;
                }
            } 
            //-----------------------------------------------------------------------------
            //this.SetOperationItem(this.txtOperation.Tag);

            if (this.txtOperation2.Text.Trim() != "" && this.txtOperation2.Tag != null)
            {
                this.SetOperationItem(this.txtOperation2.Tag);
            }
            if (this.txtOperation3.Text.Trim() != "" && this.txtOperation3.Tag != null)
            {
                this.SetOperationItem(this.txtOperation3.Tag);
            }
            
            #endregion

            //麻醉类别--{B9DDCC10-3380-4212-99E5-BB909643F11B}
            this.operationApplication.AnesWay = this.cmbAnseWay.Tag.ToString();

            //麻醉方式
            this.operationApplication.AnesType.Name = this.cmbAnae.Text;
            this.operationApplication.AnesType.ID = this.cmbAnae.Tag.ToString();

            #region 术者
            Neusoft.HISFC.Models.Operation.ArrangeRole role;
            role = new Neusoft.HISFC.Models.Operation.ArrangeRole();
            role.OperationNo = this.operationApplication.ID;                   //申请号
            role.ID = this.cmbDoctor.Tag.ToString();                             //人员代码
            role.Name = this.cmbDoctor.Text;
            role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.Operator;    //角色编码
            role.ForeFlag = "0";                                                        //术前录入
            this.operationApplication.RoleAl.Clear();
            this.operationApplication.RoleAl.Add(role);
            this.operationApplication.OperationDoctor.ID = role.ID;
            this.operationApplication.OperationDoctor.Name = role.Name;
            #endregion

            #region 一助
            role = new Neusoft.HISFC.Models.Operation.ArrangeRole();
            role.OperationNo = this.operationApplication.ID;//申请号
            role.ID = this.cmbHelper1.Tag.ToString();//人员代码
            role.Name = this.cmbHelper1.Text;
            role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper1;//角色编码
            role.ForeFlag = "0";//术前录入
            this.operationApplication.RoleAl.Add(role);

            Neusoft.FrameWork.Models.NeuObject person;
            person = new Neusoft.FrameWork.Models.NeuObject();

            person.ID = role.ID;
            person.Name = role.Name;
            this.operationApplication.HelperAl.Clear();
            this.operationApplication.HelperAl.Add(person);
            #endregion

            #region 二助
            if (this.cmbHelper2.Tag != null && this.cmbHelper2.Tag.ToString() != "")
            {
                role = new Neusoft.HISFC.Models.Operation.ArrangeRole();
                role.OperationNo = this.operationApplication.ID;//申请号
                role.ID = this.cmbHelper2.Tag.ToString();//人员代码
                role.Name = this.cmbHelper2.Text;
                role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper2;//角色编码
                role.ForeFlag = "0";//术前录入
                this.operationApplication.RoleAl.Add(role);

                person = new Neusoft.FrameWork.Models.NeuObject();

                person.ID = role.ID;
                person.Name = role.Name;
                this.operationApplication.HelperAl.Clear();
                this.operationApplication.HelperAl.Add(person);
            }
            #endregion

            #region 三助
            if (this.cmbHelper3.Tag != null && this.cmbHelper3.Tag.ToString() != "")
            {
                role = new Neusoft.HISFC.Models.Operation.ArrangeRole();
                role.OperationNo = this.operationApplication.ID;//申请号
                role.ID = this.cmbHelper3.Tag.ToString();//人员代码
                role.Name = this.cmbHelper3.Text;
                role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper3;//角色编码
                role.ForeFlag = "0";//术前录入
                this.operationApplication.RoleAl.Add(role);

                person = new Neusoft.FrameWork.Models.NeuObject();

                person.ID = role.ID;
                person.Name = role.Name;
                this.operationApplication.HelperAl.Clear();
                this.operationApplication.HelperAl.Add(person);
            }

            #endregion

            #region 临时助手1

            if (!string.IsNullOrEmpty(this.txtTmpHelper1.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationApplication.ID;
                role.ID = "777777";
                role.Name = this.txtTmpHelper1.Text;
                role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.TmpHelper1;
                role.ForeFlag = "0";
                this.operationApplication.RoleAl.Add(role);

                person = new Neusoft.FrameWork.Models.NeuObject();

                person.ID = role.ID;
                person.Name = role.Name;
                this.operationApplication.HelperAl.Clear();
                this.operationApplication.HelperAl.Add(person);

            }

            #endregion

            #region 临时助手2

            if (!string.IsNullOrEmpty(this.txtTmpHelper2.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationApplication.ID;
                role.ID = "777777";
                role.Name = this.txtTmpHelper2.Text;
                role.RoleType.ID = Neusoft.HISFC.Models.Operation.EnumOperationRole.TmpHelper2;
                role.ForeFlag = "0";
                this.operationApplication.RoleAl.Add(role);

                person = new Neusoft.FrameWork.Models.NeuObject();

                person.ID = role.ID;
                person.Name = role.Name;
                this.operationApplication.HelperAl.Clear();
                this.operationApplication.HelperAl.Add(person);

            }

            #endregion

            //预约日期
            this.operationApplication.PreDate = this.dtOperDate.Value;
            //手术室
            this.operationApplication.OperateRoom.ID = this.cmbExeDept.Tag.ToString();
            this.operationApplication.OperateRoom.Name = this.cmbExeDept.Text;
            this.operationApplication.ExeDept = this.operationApplication.OperateRoom.Clone();
            
            //手术台类型
            //int index = this.cmbTableType.SelectedIndex + 1;
            //this.operationApplication.TableType = index.ToString();
            
            //是否特殊手术
            this.operationApplication.SpecialItem = this.cmbInfectType.Text;
            this.operationApplication.BloodNum = this.cmbInfectType.SelectedIndex;
            if (this.cmbInfectType.SelectedIndex == 0)//否
                this.operationApplication.IsSpecial = false;
            else
                this.operationApplication.IsSpecial = true;

            //台序
            //this.operationApplication.BloodUnit = this.cmbOrder.Text;

            //是否需要巡回
            //this.operationApplication.IsPrepNurse = this.cbxNeedXH.Checked;

            //是否需要器械
            //this.operationApplication.IsAccoNurse = this.cbxNeedQX.Checked;

            //是否同意使用自费项目
            if (this.cmbOwn.SelectedIndex == 0)
                this.operationApplication.IsHeavy = true;
            else
                this.operationApplication.IsHeavy = false;

            //index = this.cmbOperKind.SelectedIndex + 1;
            this.operationApplication.OperateKind = (this.cmbOperKind.SelectedIndex+1).ToString();//index.ToString();

            //操作人
            this.operationApplication.User.ID = Environment.OperatorID;
            //申请医生
            this.operationApplication.ApplyDoctor.ID = this.cmbApplyDoct.Tag.ToString();
            this.operationApplication.ApplyDoctor.Name = this.cmbApplyDoct.Text;
            //申请科室
            this.operationApplication.ApplyDoctor.Dept.ID = Environment.OperatorDeptID;
            //患者来源
            this.operationApplication.PatientSouce = "2";//住院患者
            this.operationApplication.OperationDoctor.Dept.ID = this.comDept.Tag.ToString();
           
            //{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
            this.operationApplication.InciType.ID = this.cmbIncitepe.Tag.ToString();
            //合并疾病
            this.operationApplication.AneNote = this.txtAnaeNote.Text.Trim();
            //特殊说明
            this.operationApplication.ApplyNote = this.rtbApplyNote.Text.Trim();

            return 0;
        }

        /// <summary>
        /// 设置手术项目
        /// </summary>
        /// <param name="operationItem"></param>
        private void SetOperationItem(object operationItem)
        {
            if (operationItem.GetType() == typeof(Neusoft.HISFC.Models.Operation.OperationInfo))
            {
                Neusoft.HISFC.Models.Operation.OperationInfo obj = (Neusoft.HISFC.Models.Operation.OperationInfo)operationItem;
                this.operationApplication.OperationInfos.Add(obj);
            }
            else
            {
                Neusoft.HISFC.Models.Operation.OperationInfo operationInfo = new Neusoft.HISFC.Models.Operation.OperationInfo();
                operationInfo.OperationItem = operationItem as Neusoft.HISFC.Models.Base.Item;//手术项目
                operationInfo.FeeRate = 1m;//比率
                operationInfo.Qty = 1;//数量
                operationInfo.StockUnit = (operationItem as Neusoft.HISFC.Models.Base.Item).PriceUnit;//单位
                operationInfo.OperateType.ID = (operationItem as Neusoft.HISFC.Models.Fee.Item.Undrug).OperationScale.ID;
                operationInfo.IsValid = true;
                operationInfo.IsMainFlag = false;

                this.operationApplication.OperationInfos.Add(operationInfo);
                this.operationApplication.OperationType.ID = operationInfo.OperateType.ID;
            }
        }

        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            if (this.isNew == false)
            {
                if (this.operationApplication.ExecStatus == "3" || this.operationApplication.ExecStatus == "4")
                {
                    MessageBox.Show("该申请单已安排或登记,不能修改!", "提示");
                    return -1;
                }
                if (this.operationApplication.ExecStatus == "5")
                {
                    MessageBox.Show("该申请单已取消登记,不能修改！", "提示");
                    return -1;
                }
                if (this.operationApplication.IsValid == false)
                {
                    MessageBox.Show("该申请单已经作废!", "提示");
                    return -1;
                }
            } 
            if (operationApplication.PatientInfo.ID == "")
            {
                MessageBox.Show("请选择申请患者!", "提示");
                return -1;
            }
            if (this.txtDiag.Text.Length == 0)
            {
                MessageBox.Show("术前诊断一不能为空!", "提示");
                txtDiag.Focus();
                return -1;
            }

            string Diag1 = txtDiag.Text;
            string Diag2 = txtDiag2.Text;
            string Diag3 = txtDiag3.Text;
            //.
            if (Diag1 == "")
            { 
                MessageBox.Show("术前诊断一不能为空！");
                txtDiag.Focus();
                return -1;
            }
            //
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtOperation.Text, 100) == false)
            {
                txtOperation.Focus();
                MessageBox.Show("拟手术名称过长！");
                return -1;
            }
            //
            if ((Diag1 == Diag2 && Diag2 != "") || (Diag1 == Diag3 && Diag1 != "") || (Diag3 == Diag2 && Diag2 != ""))
            {
                MessageBox.Show("术前诊断不能重复");
                txtDiag.Focus();
                return -1;
            }
            // TODO: 需要加入病案后修改
            if (this.txtOperation.Text.Length == 0)
            {
                MessageBox.Show("拟手术名称不能为空!", "提示");
                txtOperation.Focus();
                return -1;
            }

            string Oper1 = txtOperation.Text;
            string Oper2 = txtOperation2.Text;
            string Oper3 = txtOperation3.Text;
            if ((Oper1 == Oper2 && Oper2 != "") || (Oper1 == Oper3 && Oper1 != "") || (Oper3 == Oper2 && Oper2 != ""))
            {
                MessageBox.Show("拟手术名称不能重复");
                txtOperation.Focus();
                return -1;
            }
            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            //if (this.cmbAnae.Tag == null || this.cmbAnae.Tag.ToString() == "")
            //{
            //    MessageBox.Show("麻醉方式不能为空!", "提示");
            //    cmbAnae.Focus();
            //    return -1;
            //}
            if (this.cmbAnseWay.Tag == null || this.cmbAnseWay.Tag.ToString() == "")
            {
                MessageBox.Show("麻醉类别不能为空!", "提示");
                cmbAnseWay.Focus();
                return -1;
            }

            if (this.cmbExeDept.Tag == null || this.cmbExeDept.Tag.ToString() == "")
            {
                MessageBox.Show("手术室不能为空!", "提示");
                cmbExeDept.Focus();
                return -1;
            }

            if (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == "")
            {
                MessageBox.Show("术者不能为空!", "提示");
                cmbDoctor.Focus();
                return -1;
            }

            if (comDept.Text.Trim() == "" || comDept.Tag == null || comDept.Tag.ToString()=="")
            {
                MessageBox.Show("术者科室不能为空!", "提示");
                comDept.Focus();
                return -1;
            }

            if (this.cmbHelper1.Tag == null || this.cmbHelper1.Tag.ToString() == "")
            {
                MessageBox.Show("一助不能为空!", "提示");
                cmbHelper1.Focus();
                return -1;
            }

            string helper1 = "";
            string helper2 = "";
            string helper3 = "";
            this.cmbHelper1.Tag.ToString();
            if (this.cmbDoctor.Tag.ToString() == this.cmbHelper1.Tag.ToString())
            {
                MessageBox.Show("术者与一助不能重复!", "提示");
                cmbDoctor.Focus();
                return -1;
            }

            if (cmbHelper2.Tag != null)
            {
                helper2 = this.cmbHelper2.Tag.ToString();
            }
            if (this.cmbHelper3.Tag != null)
            {
                helper3 = this.cmbHelper3.Tag.ToString();
            }
            if ((helper1 == helper2 && helper1 != "") || (helper1 == helper3 && helper3 != "") || (helper2 == helper3 && helper3 != ""))
            {
                MessageBox.Show("一助二助三助不能重复");
                cmbHelper1.Focus();
                return -1;
            }

            //if (this.cmbOrder.Text == "")
            //{
            //    MessageBox.Show("请指定台序!", "提示");
            //    cmbOrder.Focus();
            //    return -1;
            //}
            

            //根据指定时间和手术室判断当天是否有正台,如无自动变为加台
            Department d = new Department();

            d.ID = this.cmbExeDept.Tag.ToString();

            //int num = Environment.OperationManager.GetEnableTableNum(d, operationApplication.PatientInfo.PVisit.PatientLocation.Dept.ID, this.dtOperDate.Value);
            //int mm = Environment.OperationManager.SameDeptApplication(this.dtOperDate.Value.ToString(), this.dtOperDate.Value.Date.AddDays(1).ToString(), d.ID, operationApplication.PatientInfo.PVisit.PatientLocation.Dept.ID, cmbOrder.Text.Substring(0, 1));
            //if (mm == -1)
            //{
            //    MessageBox.Show("判断是否是应该是正台出错" + Environment.OperationManager.Err);
            //    return -1;
            //}
            //if (num <= 0 && this.cmbTableType.SelectedIndex == 0 && isNew)
            //{
            //    MessageBox.Show("申请日期内已无正台,请修改手术台类型!", "提示");
            //    cmbTableType.Focus();
            //    return -1;
            //}
            //if (num <= 0 && this.cmbTableType.SelectedIndex == 0 && mm == 1 && isNew)//无正台,不能申请正台
            //{
            //    MessageBox.Show("申请日期内已无正台,请修改手术台类型!", "提示");
            //    cmbTableType.Focus();
            //    return -1;
            //}

            if (string.IsNullOrEmpty(txtAnaeNote.Text) ) // || txtAnaeNote.Tag == null || txtAnaeNote.Tag.ToString() == "")
            {
                MessageBox.Show("合并疾病不能为空!", "提示");
                txtAnaeNote.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAnaeNote.Text.Trim(), 50) == false)
            {
                MessageBox.Show("合并疾病必须小于50个汉字!", "提示");
                txtAnaeNote.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.rtbApplyNote.Text.Trim(), 200) == false)
            {
                MessageBox.Show("特殊说明必须小于100个汉字!", "提示");
                rtbApplyNote.Focus();
                return -1;
            }
            if (this.cmbApplyDoct.Tag == null || this.cmbApplyDoct.Tag.ToString() == "")
            {
                MessageBox.Show("申请医生不能为空!", "提示");
                cmbApplyDoct.Focus();
                return -1;
            }
            if (!checkDate)
            {
                if (((System.DateTime.Now.DayOfWeek == System.DayOfWeek.Saturday || System.DateTime.Now.DayOfWeek == System.DayOfWeek.Sunday) && cmbOperKind.Text == "择期") && dtOperDate.Value.DayOfWeek == System.DayOfWeek.Monday)
                {
                    MessageBox.Show("周六,周日不能申请周一的手术");
                    return -1;
                }
            }


            //判断申请时间是否合法
            string rtn = Environment.OperationManager.PreDateValidity(this.dtOperDate.Value);
            if (rtn == "Error")
            {
                MessageBox.Show(Environment.OperationManager.Err, "参数设置");
                return -1;
            }
            else if (rtn == "Before")
            {
                #region
                if (!CheckApplyTime)
                {
                    MessageBox.Show("申请时间不能小于当前时间!", "提示");
                    //this.dtOperDate.Select();
                    this.dtOperDate.Focus();
                    //this.dtOperDate.ShowUpDown = true;
                    //this.dtOperDate.ShowUpDown = false;
                    return -1;
                }
                #endregion
            }
            else if (rtn == "Over")
            {
                if (this.cmbOperKind.SelectedIndex != 1)
                {
                    if (checkEmergency)
                    {
                        #region 如果科室属性是手术室 ，则不提示
                        Neusoft.HISFC.BizProcess.Integrate.Manager dp = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                        Neusoft.HISFC.Models.Base.Department dd = dp.GetDepartment(Environment.OperatorDeptID);
                        if (dd.SpecialFlag != "1")
                        {
                            MessageBox.Show("已超过该日手术申请的截止时间,\n请预约至其他日期进行手术申请,或者将手术类别改为急诊!", "提示");
                            cmbOperKind.Focus();
                            return -1;
                        }
                        #endregion
                    }
                }
            }
            if (this.cmbInfectType.Text == string.Empty)
            {
                MessageBox.Show("请选择是否“特殊手术”");
                this.cmbInfectType.Focus();
                return -1;
            }

            #region 校验诊断
            //{6C784A56-3FFD-47c3-A2A1-6382F7A7C7E1}

            if (this.txtDiag.Text.Trim() != string.Empty &&  this.txtDiag.Tag == null  )
            {
                MessageBox.Show("所录入的“术前诊断一”不存在,请重新输入");
                this.txtDiag.Focus();
                return -1;
            }

            if (this.txtDiag2.Text.Trim() != string.Empty &&  this.txtDiag2.Tag == null  )
            {
                MessageBox.Show("所录入的“术前诊断二”不存在,请重新输入");
                this.txtDiag2.Focus();
                return -1;
            }

            if (this.txtDiag3.Text.Trim() != string.Empty &&  this.txtDiag3.Tag == null )
            {
                MessageBox.Show("所录入的“术前诊断三”不存在,请重新输入");
                this.txtDiag3.Focus();
                return -1;
            }


           

            if (this.txtOperation.Text.Trim() != string.Empty &&  this.txtOperation.Tag == null )
            {
                MessageBox.Show("所录入的第一“拟手术名称”不存在,请重新输入");
                this.txtOperation.Focus();
                return -1;
            }


            if (this.txtOperation2.Text.Trim() != string.Empty &&  this.txtOperation2.Tag == null  )
            {
                MessageBox.Show("所录入的第二“拟手术名称”不存在,请重新输入");
                this.txtOperation2.Focus();
                return -1;
            }

            if (this.txtOperation3.Text.Trim() != string.Empty &&  this.txtOperation3.Tag == null  )
            {
                MessageBox.Show("所录入的第三“拟手术名称”不存在,请重新输入");
                this.txtOperation3.Focus();
                return -1;
            }
            #endregion

            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            PreSave();


            if (Valid() == -1)
            {
                return -1;
            }

            if (this.GetValue() == -1)
            {
                return -1;
            }

            #region 判断是否存在重复手术申请
            if (this.isNew)
            {
                //默认取第一个诊断为统计术前诊断
                string strDiagnose = "";
                string strDiagName = "";
                if (operationApplication.DiagnoseAl.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.DiagnoseBase MainDiagnose in operationApplication.DiagnoseAl)
                    {
                        if (MainDiagnose.IsValid)
                        {
                            strDiagnose = MainDiagnose.Name + "(" + MainDiagnose.ID.ToString() + ")";
                            strDiagName = MainDiagnose.Name;
                        }
                    }
                }
                int i = Environment.OperationManager.IsExistSameApplication(operationApplication.PatientInfo.ID, strDiagnose, operationApplication.PreDate.ToString());
                if (i == -1) //查询出错
                {
                    MessageBox.Show("查询病人手术信息" + Environment.OperationManager.Err);
                    return -1;
                }
                if (i == 2) //有重复申请的信息 
                {
                    System.Windows.Forms.DialogResult result = MessageBox.Show("病人(" + operationApplication.PatientInfo.Name + ")已经存在(" + strDiagName + ")的手术申请,是否要重新申请一个?", "提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        return -1;
                    }
                }
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            opsDiagnose.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                if (this.isNew)//新增
                {

                    if (Environment.OperationManager.CreateApplication(operationApplication) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.OperationManager.Err, "提示");
                        return -1;
                    }
                }
                else//修改
                {
                    //先判断状态
                    OperationAppllication obj = Environment.OperationManager.GetOpsApp(this.operationApplication.ID);
                    if (obj == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("无该申请单信息!", "提示");
                        return -1;
                    }
                    //1申请2审批3安排4完成
                    if (obj.ExecStatus == "3" || obj.ExecStatus == "4" || obj.ExecStatus == "2")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("该申请单已被安排或登记,不能进行修改!", "提示");
                        return -1;
                    }
                    if (obj.ExecStatus == "5")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("该申请单已被取消登记,不能进行修改!", "提示");
                        return -1;
                    }

                    if (obj.IsValid == false)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("该申请单已经作废!", "提示");
                        return -1;
                    }

                    if (Environment.OperationManager.UpdateApplication(operationApplication) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.OperationManager.Err, "提示");
                        return -1;
                    }
                    
                }

                #region 诊断信息
                //ArrayList oldDiag = opsDiagnose.QueryOpsDiagnose(operationApplication.PatientInfo.ID, "7");
                //if (oldDiag == null)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("查询手术诊断失败");
                //    return -1;
                //}

                // ArrayList IcdAl = opsDiagnose.QueryOpsDiagnose(operationApplication.PatientInfo.ID, "7");
                //if (IcdAl == null)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("查询手术诊断失败");
                //    return -1;
                //}

                //ArrayList oldDiag = new ArrayList();
                //foreach (Neusoft.HISFC.Models.HealthRecord.DiagnoseBase diag in IcdAl)
                //{
                //    if (diag.OperationNo == operationApplication.ID)
                //        oldDiag.Add(diag);
                //}

                int returnValue = opsDiagnose.DeleteDiagnoseByOperationNO(operationApplication.ID);

                ArrayList oldDiag = new ArrayList();

                bool bIsExist = false;
                //遍历要加入的诊断信息列表(OpsApp.DiagnoseAl)
                foreach (Neusoft.HISFC.Models.HealthRecord.DiagnoseBase willAddDiagnose in operationApplication.DiagnoseAl)
                {
                    bIsExist = false;
                    //遍历患者已有的所有手术诊断，如果willAddDiagnose已经存在，更新其状态，
                    //如果willAddDiagnose尚不存在，则新增该记录到数据库中
                    foreach (Neusoft.HISFC.Models.HealthRecord.DiagnoseBase thisDiagnose in oldDiag)
                    {
                        if (thisDiagnose.HappenNo == willAddDiagnose.HappenNo && thisDiagnose.Patient.ID.ToString() == willAddDiagnose.Patient.ID.ToString())
                        {
                            //已经存在	更新				
                            if (opsDiagnose.UpdatePatientDiagnose(willAddDiagnose) == -1) return -1;
                            bIsExist = true;
                        }
                    }
                    //遍历完毕后发现不存在 新增
                    if (bIsExist == false)
                    {
                        if (opsDiagnose.CreatePatientDiagnose(willAddDiagnose) == -1) return -1;
                    }
                }
                #endregion 

                if (this.cmbExeDept.Tag != null)
                {
                    string[] str = new string[2];
                    str[0] = this.cmbExeDept.Text;
                    str[1] = this.cmbExeDept.Tag.ToString();
                    Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("ExeDept", str);
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.ucDiag1.Visible = false;
                this.ucOpItem1.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return -1;
            }
            //急诊手术,弹出提示
            if (this.operationApplication.OperateKind == "2")
                MessageBox.Show("该手术为急诊手术,请电话通知手术室!", "提示");
            // TODO: 发消息
            //Neusoft.HISFC.Common.Class.Message.SendMessage(this.lblDept.Text + "患者：" + this.lblName.Text + "有新手术申请,请核收!", this.operationApplication.ExeDept.ID);
            if (this.isNew)
            {
                MessageBox.Show("申请成功!", "提示");
            }
            else
            {
                MessageBox.Show("申请修改成功，请通知手术室!");
            }

            if (MessageBox.Show("是否打印手术申请单", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Print();
            }

            if (this.isNew)
                this.isNew = false;
            this.Reset();
            return 0;
        }

        /// <summary>
        /// 作废当前修改申请单
        /// </summary>
        /// <returns></returns>
        public int Cancel()
        {
            if (this.isNew) return -1;
            if (this.operationApplication.ID.Length == 0)
            {
                MessageBox.Show("请选择待作废申请单!", "提示");
                return -1;
            }

            this.operationApplication = Environment.OperationManager.GetOpsApp(this.operationApplication.ID);
            if (this.operationApplication == null)
            {
                MessageBox.Show("获取申请单信息出错!", "提示");
                return -1;
            }

            if (this.operationApplication.ExecStatus == "4")
            {
                MessageBox.Show("该申请单已登记,不能作废!", "提示");
                return -1;
            }

            if (this.operationApplication.ExecStatus == "5")
            {
                MessageBox.Show("该申请单已取消登记,不能作废！", "提示");
                return -1;
            }

            if (this.operationApplication.IsValid == false)
            {
                MessageBox.Show("该申请单已经作废!", "提示");
                return -1;
            }
            if (MessageBox.Show("是否作废当前申请单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                if (Environment.OperationManager.CancelApplication(this.operationApplication) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Environment.OperationManager.Err, "提示");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("请电话通知手术室!", "提示");
            MessageBox.Show("作废成功!", "提示");
            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            //打印预览
            if (operationApplication.PatientInfo.ID == "")
                return -1;

            if (this.operationApplication.PreDate == System.DateTime.MinValue)
            {
                #region  判断数据有效性
                if (operationApplication.PatientInfo.ID == "")
                {
                    MessageBox.Show("请选择申请患者!", "提示");
                    return -1;
                }
                if (this.txtDiag.Tag == null)
                {
                    MessageBox.Show("术前诊断不能为空!", "提示");
                    return -1;
                }
                if (this.txtOperation.Tag == null)
                {
                    MessageBox.Show("拟手术名称不能为空!", "提示");
                    return -1;
                }
                //if (this.cmbAnae.Tag == null || this.cmbAnae.Tag.ToString() == "")
                //{
                //    MessageBox.Show("麻醉方式不能为空!", "提示");
                //    return -1;
                //}

                //{B9DDCC10-3380-4212-99E5-BB909643F11B}

                if (this.cmbAnseWay.Tag == null || this.cmbAnseWay.Tag.ToString() == "")
                {
                    MessageBox.Show("麻醉类别不能为空!", "提示");
                    this.cmbAnseWay.Focus();
                    return -1;
                }

                if (this.cmbExeDept.Tag == null || this.cmbExeDept.Tag.ToString() == "")
                {
                    MessageBox.Show("手术室不能为空!", "提示");
                    return -1;
                }
                if (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == "")
                {
                    MessageBox.Show("术者不能为空!", "提示");
                    return -1;
                }
                if (this.cmbHelper1.Tag == null || this.cmbHelper1.Tag.ToString() == "")
                {
                    MessageBox.Show("一助不能为空!", "提示");
                    return -1;
                }
                string helper1 = "";
                string helper2 = "";
                string helper3 = "";
                this.cmbHelper1.Tag.ToString();
                if (cmbHelper2.Tag != null)
                {
                    helper2 = this.cmbHelper2.Tag.ToString();
                }
                if (this.cmbHelper3.Tag != null)
                {
                    helper3 = this.cmbHelper3.Tag.ToString();
                }
                if ((helper1 == helper2 && helper1 != "") || (helper1 == helper3 && helper3 != "") || (helper2 == helper3 && helper3 != ""))
                {
                    MessageBox.Show("一助二助三助不能重复");
                    return -1;
                }
                if (this.cmbOrder.Text == "")
                {
                    MessageBox.Show("请指定台序!", "提示");
                    return -1;
                }
                //判断申请时间是否合法
                string rtn = Environment.OperationManager.PreDateValidity(this.dtOperDate.Value);
                if (rtn == "Error")
                {
                    MessageBox.Show(Environment.OperationManager.Err, "参数设置");
                    return -1;
                }
                else if (rtn == "Before")
                {
                    MessageBox.Show("申请时间不能小于当前时间!", "提示");
                    return -1;
                }
                #endregion

            }
            if (GetValue() == -1)
                return -1;

            #region 删除原来手术申请单信息 用 手术安排通知单代替
            //			ucCreateAppPrint ucCreateAppPrint1 = new ucCreateAppPrint();
            //			neusoft.HISFC.Object.RADT.PatientInfo patient=patientMgr.PatientQuery(operationApplication.PatientInfo.Patient.ID);
            //			if(patient==null)return -1;
            //			neusoft.HISFC.Object.Operator.OpsApplication t=operationApplication.Clone();
            //			t.PatientInfo=patient;
            //
            //			ucCreateAppPrint1.ControlValue = t;
            //Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //p.ControlBorder = neusoft.neNeusoft.HISFC.Components.Interface.Classes.enuControlBorder.None;

            //p.PrintPreview(10, 40, ucCreateAppPrint1);

            #endregion


            if (this.arrangeFormPrint == null)
            {
                this.arrangeFormPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangeNotifyFormPrint)) as Neusoft.HISFC.BizProcess.Interface.Operation.IArrangeNotifyFormPrint;
                if (this.arrangeFormPrint == null)
                {
                    MessageBox.Show("获得接口IArrangeNotifyFormPrint错误，请与系统管理员联系。");

                    return -1;
                }
            }

            this.arrangeFormPrint.OperationApplicationForm = this.operationApplication.Clone();
            this.arrangeFormPrint.IsPrintExtendTable = false;
            this.arrangeFormPrint.Print();
            //this.arrangeFormPrint.PrintPreview();

            return 0;
        }

        #region 手术
        Neusoft.HISFC.Components.Operation.ucOpItem ucOpItem1 = null; 
        int ucOpItem1_SelectItem(Keys key)
        {
            this.ProcessOps();
            this.txtOperation.Focus();
            return 1;
        }
        private int ProcessOps()
        {
            Neusoft.HISFC.Models.Fee.Item.Undrug item = null;
            if (this.ucOpItem1.GetItem(ref item) == -1)
            {
                //MessageBox.Show("获取项目出错!","提示");
                return -1;
            }
            dirty = true;
            this.contralActive.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;
            dirty = false;

            this.contralActive.Tag = item;
            this.ucOpItem1.Visible = false;

            return 0;
        }
        private void txtOperation_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation2_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation2;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation3_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation3;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                this.txtOperation2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                this.txtOperation3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                ////{B9DDCC10-3380-4212-99E5-BB909643F11B}
                //this.cmbAnae.Focus();
                this.cmbAnseWay.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation.Focused)
            {
                return;
            }
            string text = this.txtOperation.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation.Location.X, txtOperation.Location.Y + txtOperation.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation.Tag = null;
        }

        private void txtOperation2_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation2.Focused)
            {
                return;
            }
            string text = this.txtOperation2.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation2.Location.X, txtOperation2.Location.Y + txtOperation2.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation2.Tag = null;
        }

        private void txtOperation3_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation3.Focused)
            {
                return;
            }
            string text = this.txtOperation3.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation3.Location.X, txtOperation3.Location.Y + txtOperation3.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation3.Tag = null;
        }

        #endregion

        #region 诊断
        Neusoft.HISFC.Components.Common.Controls.ucDiagnose ucDiag1 = null;
        int ucDiag1_SelectItem(Keys key)
        {
            this.ProcessDiag();
            this.txtDiag.Focus();
            return 1;
        } 
        private int ProcessDiag()
        {
            if (this.cbxCustom.Checked)
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = new Random().Next(100000, 999999).ToString();
                item.Name = this.contralActive.Text;

                dirty = true;
                this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                dirty = false;

                this.contralActive.Tag = item;

                return 0;


                #endregion
               
            }
            else
            {
                Neusoft.HISFC.Models.HealthRecord.ICD item = null;
                if (this.ucDiag1.GetItem(ref item) == -1)
                {
                    //MessageBox.Show("获取项目出错!","提示");
                    return -1;
                }
                dirty = true;
                this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                dirty = false;

                this.contralActive.Tag = item;
                this.ucDiag1.Visible = false;
            }

            return 0;
        }
        private void txtDiag_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag;
            this.ucOpItem1.Visible = false;
        }

        private void txtDiag2_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag2;
            this.ucOpItem1.Visible = false;
        }

        private void txtDiag3_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag3;
            this.ucOpItem1.Visible = false;
        }

        private void txtDiag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucDiag1.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtDiag2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }

        private void txtDiag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucDiag1.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtDiag3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }

        private void txtDiag3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucDiag1.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtOperation.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }

        private void txtDiag_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag.Focused)
            {
                return;
            }
            contralActive = this.txtDiag;
            string text = this.txtDiag.Text;
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag.Location.X, txtDiag.Location.Y + txtDiag.Height + 2);
            ucDiag1.BringToFront();
            if (this.ucDiag1.Visible == false) this.ucDiag1.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag.Tag = null;
            ucDiag1.BringToFront();
        }

        private void txtDiag2_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag2.Focused)
            {
                return;
            }
            contralActive = this.txtDiag2;
            string text = this.txtDiag2.Text;
            ucDiag1.BringToFront();
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag2.Location.X, txtDiag2.Location.Y + txtDiag2.Height + 2);
            if (this.ucDiag1.Visible == false) this.ucDiag1.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag2.Tag = null;
        }

        private void txtDiag3_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag3.Focused)
            {
                return;
            }
            contralActive = this.txtDiag3;
            string text = this.txtDiag3.Text;
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag2.Location.X, txtDiag3.Location.Y + txtDiag3.Height + 2);
            ucDiag1.BringToFront();
            if (this.ucDiag1.Visible == false) this.ucDiag1.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag3.Tag = null;
        }
        #endregion 

        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //if (!this.DesignMode)
            //{
            //    this.Reset();
            //    this.Init();
            //}
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData.GetHashCode() == Keys.Enter.GetHashCode())
            //{
            //    this.ucOpItem1.Visible = false;
            //    this.ucDiag1.Visible = false;
                //if (txtDiag.Focused)
                //{
                //    if ( !string.IsNullOrEmpty( txtDiag.Text.Trim()) )
                //    {
                //        #region donggq

                //        Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                //        item.ID = new Random().Next(100000, 999999).ToString();
                //        item.Name = this.contralActive.Text;

                //        dirty = true;
                //        this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                //        dirty = false;

                //        this.contralActive.Tag = item;

                //        #endregion
                //    }
                //}

                //if (txtDiag2.Focused)
                //{
                //    if ( !string.IsNullOrEmpty( txtDiag2.Text.Trim()))
                //    {
                //        #region donggq

                //        Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                //        item.ID = new Random().Next(100000, 999999).ToString();
                //        item.Name = this.contralActive.Text;

                //        dirty = true;
                //        this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                //        dirty = false;

                //        this.contralActive.Tag = item;

                //        #endregion
                //    }
                //}


                //if (txtDiag3.Focused)
                //{
                //    if ( !string.IsNullOrEmpty( txtDiag3.Text.Trim()))
                //    {
                //        #region donggq

                //        Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                //        item.ID = new Random().Next(100000, 999999).ToString();
                //        item.Name = this.contralActive.Text;

                //        dirty = true;
                //        this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                //        dirty = false;

                //        this.contralActive.Tag = item;

                //        #endregion
                //    }
                //}

                //if (txtOperation.Focused)
                //{
                //    if (txtOperation.Text.Trim() == "")
                //    {
                //        txtOperation.Tag = null;
                //    }
                //}
                //if (txtOperation3.Focused)
                //{
                //    if (txtOperation3.Text.Trim() == "")
                //    {
                //        txtOperation3.Tag = null;
                //    }
                //}
                //if (txtOperation2.Focused)
                //{
                //    if (txtOperation2.Text.Trim() == "")
                //    {
                //        txtOperation2.Tag = null;
                //    }
                //}
            //}

            if (keyData.GetHashCode() == Keys.Escape.GetHashCode())
            {
                this.ucOpItem1.Visible = false;
                this.ucDiag1.Visible = false;
                if (txtDiag.Focused)
                {
                    if (txtDiag.Text.Trim() == "")
                    {
                        txtDiag.Tag = null;
                    }
                }
                if (txtDiag3.Focused)
                {
                    if (txtDiag3.Text.Trim() == "")
                    {
                        txtDiag3.Tag = null;
                    }
                }
                if (txtDiag2.Focused)
                {
                    if (txtDiag2.Text.Trim() == "")
                    {
                        txtDiag2.Tag = null;
                    }
                }
                if (txtOperation.Focused)
                {
                    if (txtOperation.Text.Trim() == "")
                    {
                        txtOperation.Tag = null;
                    }
                }
                if (txtOperation3.Focused)
                {
                    if (txtOperation3.Text.Trim() == "")
                    {
                        txtOperation3.Tag = null;
                    }
                }
                if (txtOperation2.Focused)
                {
                    if (txtOperation2.Text.Trim() == "")
                    {
                        txtOperation2.Tag = null;
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangeNotifyFormPrint) };
            }
        }

        #endregion 

        private void cmbAnae_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtOperDate.Focus();
            }
        }

        private void dtOperDate_KeyDown(object sender, KeyEventArgs e)
        {//
            if (e.KeyCode == Keys.Enter)
            {
                cmbExeDept.Focus();
            }
        }

        private void cmbExeDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTableType.Focus();
            }
            
        }

        private void cmbTableType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comDept.Focus();
            }
        }

        private void comDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbInfectType.Focus();
            }
        }
        
        private void cmbSpecial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHelper1.Focus();
            }
        }

        private void cmbHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHelper2.Focus();
            }
        }

        private void cmbHelper2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHelper3.Focus();
            }
        }

        private void cmbHelper3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOrder.Focus(); 
            }
        }

        private void cmbOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbIncitepe.Focus();
            }
        }

        private void cbxNeedQX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxNeedXH.Focus();
            }
        }

        private void cbxNeedXH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTmpHelper1.Focus();
            }

        }

        private void txtTmpHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTmpHelper2.Focus();
            }
        }

        private void txtTmpHelper2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAnaeNote.Focus();
            }
        }

        private void txtAnaeNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOwn.Focus();
            }
        }

        private void cmbOwn_KeyDown(object sender, KeyEventArgs e)
        {//rtbApplyNote
            if (e.KeyCode == Keys.Enter)
            {
                cmbApplyDoct.Focus();
            }
        }

        private void ucApplicationForm_Load(object sender, EventArgs e)
        {
            this.cbxCustom.Checked = true;
        }

        ////{B9DDCC10-3380-4212-99E5-BB909643F11B}
        private void cmbAnseWay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbAnae.Focus();
            }
        }
        //{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
        private void cmbIncitepe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxNeedQX.Focus();
            }
        }



        //////////////
        private void cbxCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustom.Checked)
            {
                this.txtDiag.IsEnter2Tab = true;
                this.txtDiag.TextChanged -= new EventHandler(txtDiag_TextChanged);
                this.txtDiag.KeyDown -= new KeyEventHandler(txtDiag_KeyDown);

                this.txtDiag2.IsEnter2Tab = true;
                this.txtDiag2.TextChanged-=new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown-=new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.IsEnter2Tab = true;
                this.txtDiag3.TextChanged-=new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown-=new KeyEventHandler(txtDiag3_KeyDown);



                this.txtOperation.IsEnter2Tab = true;
                this.txtOperation.TextChanged -= new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown -= new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.IsEnter2Tab = true;
                this.txtOperation2.TextChanged -= new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown -= new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.IsEnter2Tab = true;
                this.txtOperation3.TextChanged -= new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown -= new KeyEventHandler(txtOperation3_KeyDown);
            }
            else
            {
                this.txtDiag.IsEnter2Tab = false;
                this.txtDiag2.IsEnter2Tab = false;
                this.txtDiag3.IsEnter2Tab = false;

                this.txtOperation.IsEnter2Tab = false;
                this.txtOperation2.IsEnter2Tab = false;
                this.txtOperation3.IsEnter2Tab = false;

                this.txtDiag.TextChanged -= new EventHandler(txtDiag_TextChanged);
                this.txtDiag.KeyDown -= new KeyEventHandler(txtDiag_KeyDown);

                this.txtDiag2.TextChanged -= new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown -= new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.TextChanged -= new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown -= new KeyEventHandler(txtDiag3_KeyDown);


                this.txtOperation.TextChanged -= new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown -= new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.TextChanged -= new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown -= new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.TextChanged -= new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown -= new KeyEventHandler(txtOperation3_KeyDown);


                this.txtDiag.TextChanged += new EventHandler(txtDiag_TextChanged);
                this.txtDiag.KeyDown += new KeyEventHandler(txtDiag_KeyDown);

                this.txtDiag2.TextChanged += new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown += new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.TextChanged += new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown += new KeyEventHandler(txtDiag3_KeyDown);


                this.txtOperation.TextChanged += new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown += new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.TextChanged += new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown += new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.TextChanged += new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown += new KeyEventHandler(txtOperation3_KeyDown);
            }
        }


        private void PreSave() 
        {
            if (!this.cbxCustom.Checked) 
            {
                return;
            }

            if (!string.IsNullOrEmpty(txtDiag.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtDiag.Text;

                dirty = true;
                this.txtDiag.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                dirty = false;

                this.txtDiag.Tag = item;

                #endregion
            }

            if (!string.IsNullOrEmpty(txtDiag2.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID)) 
                {
                    item.ID = GetCustomOpitemNo();
                }

                item.Name = this.txtDiag2.Text;

                dirty = true;
                this.txtDiag2.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                dirty = false;

                this.txtDiag2.Tag = item;

                #endregion
            }


            if (!string.IsNullOrEmpty(txtDiag3.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtDiag3.Text;

                dirty = true;
                this.txtDiag3.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                dirty = false;

                this.txtDiag3.Tag = item;

                #endregion
            }


            if (!string.IsNullOrEmpty(txtOperation.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation.Text;

                dirty = true;
                this.txtOperation.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;
                dirty = false;

                this.txtOperation.Tag = item;
                
                #endregion
            }

            if (!string.IsNullOrEmpty(txtOperation2.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();



                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation2.Text;

                dirty = true;
                this.txtOperation2.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;
                dirty = false;

                this.txtOperation2.Tag = item;

                #endregion
            }

            if (!string.IsNullOrEmpty(txtOperation3.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation3.Text;

                dirty = true;
                this.txtOperation3.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;
                dirty = false;

                this.txtOperation3.Tag = item;

                #endregion
            }

        }



        public string GetCustomOpitemNo()
        {
            Neusoft.HISFC.BizProcess.Integrate.Operation.Operation op = new Neusoft.HISFC.BizProcess.Integrate.Operation.Operation();

            string strSql = "SELECT  Seq_local_itemno.NEXTVAL FROM dual";
            string val = string.Empty;

            if (op.ExecQuery(strSql) == -1)
            {
                return val;
            }
            try
            {
                if (op.Reader.Read())
                {
                    return op.Reader.GetValue(0).ToString();
                }
                else
                {
                    return val;
                }
            }
            catch
            {
                return val;
            }

            return val;
        }

       




        //////////////





    }
}
