using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    public partial class ucCaseMainInfoNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// ucCaseMainInfo<br></br>
        /// [功能描述: 病案基本信息录入]<br></br>
        /// [创 建 者: 张俊义]<br></br>
        /// [创建时间: 2007-04-20]<br></br>
        /// <修改记录 
        ///		修改人='' 
        ///		修改时间='yyyy-mm-dd' 
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucCaseMainInfoNew()
        {
            InitializeComponent();
            this.txtPatientNOSearch.Focus();
        }

        #region  全局变量

        //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
        private Neusoft.HISFC.BizProcess.Integrate.Manager manageIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        //标志 标识是医生站用还是病案调用
        private Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC;
        //暂存当前修改人的病案基本信息
        private Neusoft.HISFC.Models.HealthRecord.Base CaseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
        //病案基本信息操作类
        private Neusoft.HISFC.BizLogic.HealthRecord.Base baseDml = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
        //定义变量
        Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
        //门诊诊断 
        private Neusoft.HISFC.Models.HealthRecord.Diagnose clinicDiag = null;
        //入院诊断 
        private Neusoft.HISFC.Models.HealthRecord.Diagnose InDiag = null;
        //转科信息
        ArrayList changeDept = new ArrayList();
        //第一次转科
        private Neusoft.HISFC.Models.RADT.Location firDept = null;
        //第二次转科信息
        private Neusoft.HISFC.Models.RADT.Location secDept = null;
        //第三次转科信息
        private Neusoft.HISFC.Models.RADT.Location thirDept = null;
        Neusoft.HISFC.BizLogic.HealthRecord.DeptShift deptChange = new Neusoft.HISFC.BizLogic.HealthRecord.DeptShift();
        Neusoft.HISFC.BizLogic.HealthRecord.Fee healthRecordFee = new Neusoft.HISFC.BizLogic.HealthRecord.Fee();
        //{DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
        private Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack healthRecordPrintBack = null;//打印接口 背面

        HealthRecord.Search.ucPatientList ucPatient = new HealthRecord.Search.ucPatientList();
        //标识手工输入的状态是插入还是更新  0默认状态  1  插入 2更新  
        private int HandCraft = 0;

        //		//入院诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
        //		public int RuDiag = 0;
        //		//门诊诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
        //		public int menDiag = 0;
        //保存病案的状态
        private int CaseFlag = 0;
        //提示窗体
        ucDiagNoseCheck frm = null;
        private Neusoft.FrameWork.Models.NeuObject localObj = new Neusoft.FrameWork.Models.NeuObject();
        private Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface healthRecordPrint = null;//打印接口

        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        protected Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                patientInfo = value;
            }
        }

        #endregion

        #region 初始化
        //System.Threading.Thread thread = null;
        public int InitCaseMainInfo()
        {
            InitCountryList();//国际
            #region  诊断信息
            //thread = new System.Threading.Thread(this.ucDiagNoseInput1.InitInfo);
            //thread.Start();  
            this.ucDiagNoseInput1.InitInfo();
            #endregion

            #region  妇婴
            ucBabyCardInput1.InitInfo();
            #endregion

            #region 手术
            this.ucOperation1.InitInfo();
            ucOperation1.InitICDList();
            //thread = new System.Threading.Thread(ucOperation1.InitICDList);
            //thread.Start();
            #endregion

            #region 肿瘤
            //thread = new System.Threading.Thread(this.ucTumourCard2.InitInfo);
            //thread.Start();
            this.ucTumourCard2.InitInfo();
            #endregion

            #region  转科
            //thread = new System.Threading.Thread(this.ucChangeDept1.InitInfo);
            //thread.Start(); 
            this.ucChangeDept1.InitInfo();
            #endregion

            #region  费用
            this.ucFeeInfo1.InitInfo();
            #endregion

            #region 加载选择框
            this.Controls.Add(this.ucPatient); 
            this.ucPatient.BringToFront();
            this.ucPatient.Visible = false;
            this.ucPatient.SelectItem += new HealthRecord.Search.ucPatientList.ListShowdelegate(ucPatient_SelectItem);
            #endregion

            this.txtPatientNOSearch.Focus();
            return 1;
        }
        private void ucCaseMainInfoNew_Load(object sender, EventArgs e)
        {
            if (this.Tag != null && this.Tag.ToString() != "")
            {
                this.frmType = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS;
            }
            InitCaseMainInfo();
            InitTreeView( );
            this.txtCaseNum.Leave +=new EventHandler(txtCaseNum_Leave);
            this.txtPatientNOSearch.Focus();
        }
        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        { 
            toolBarService.AddToolButton("删除(&D)", "删除(&D)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            //{DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
            toolBarService.AddToolButton("打印第二页", "打印第二页", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);  
     
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            { 
                case "删除(&D)":
                    DeleteActiveRow();
                    break;
                //{DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
                case "打印第二页":
                    PrintBack(this.CaseBase);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region  所有的下拉列表
        private int InitCountryList()
        {
            HealthRecord.CaseFirstPage.BloodType b = new BloodType();
            //获取列表
            ArrayList list = Neusoft.HISFC.Models.Base.SexEnumService.List();
            //设置列表
            this.txtPatientSex.AddItems(list);
            //g查询国家列表
            ArrayList list1 = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.COUNTRY);
            this.txtCountry.AddItems(list1);

            //查询民族列表
            ArrayList Nationallist1 = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.NATION);
            this.txtNationality.AddItems(Nationallist1);

            //查询职业列表
            ArrayList Professionlist = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PROFESSION);
            this.txtProfession.AddItems(Professionlist);
            //血型列表
            ArrayList BloodTypeList = HealthRecord.CaseFirstPage.BloodType.List();// con.GetList(Neusoft.HISFC.Models.Base.EnumBloodTypeByABO);//.EnumConstant.BLOODTYPE);// baseDml.GetBloodType();
           
            //BloodTypeList.Add(Neusoft.HISFC.Models.Base.EnumBloodTypeByABO.AB);
            //BloodTypeList.Add(Neusoft.HISFC.Models.Base.EnumBloodTypeByABO.B);
            //BloodTypeList.Add(Neusoft.HISFC.Models.Base.EnumBloodTypeByABO.O);
            //BloodTypeList.Add(Neusoft.HISFC.Models.Base.EnumBloodTypeByABO.U);
            this.txtBloodType.AddItems(BloodTypeList);
            //婚姻列表
            ArrayList MaritalStatusList = Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List();
            this.txtMaritalStatus.AddItems(MaritalStatusList);
            //结算类别
            //ArrayList pactKindlist = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT);// baseDml.GetPayKindCode(); //GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT);
            ArrayList pactKindlist = this.manageIntegrate.QueryPactUnitAll();
            this.txtPactKind.AddItems(pactKindlist);
            //与联系人关系
            ArrayList RelationList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.RELATIVE);
            this.txtRelation.AddItems(RelationList);

            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            //获取医生列表
            ArrayList DoctorList = person.GetEmployeeAll();//.GetEmployee(Neusoft.HISFC.Models.RADT.PersonType.enuPersonType.D);
            this.txtInputDoc.AddItems(DoctorList);
            this.txtCoordinate.AddItems(DoctorList);
            this.txtOperationCode.AddItems(DoctorList);
            this.txtAdmittingDoctor.AddItems(DoctorList);
            this.txtAttendingDoctor.AddItems(DoctorList);
            this.txtConsultingDoctor.AddItems(DoctorList);
            this.txtRefresherDocd.AddItems(DoctorList);
            txtClinicDocd.AddItems(DoctorList);
            txtGraDocCode.AddItems(DoctorList);
            txtQcDocd.AddItems(DoctorList);
            txtQcNucd.AddItems(DoctorList);
            txtCodingCode.AddItems(DoctorList);
            this.txtPraDocCode.AddItems(DoctorList);
            //获取病人来源
            //			ArrayList InAvenuelist = baseDml.GetPatientSource();
            ArrayList InAvenuelist = con.GetAllList(Neusoft.HISFC.Models.Base.EnumConstant.INAVENUE);
            this.txtInAvenue.AddItems(InAvenuelist);

            //入院情况
            ArrayList CircsList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.INCIRCS);
            this.txtCircs.AddItems(CircsList);
            this.customListBox1.AddItems(CircsList);

            //出院方式
            ArrayList outtypeList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.OUT_TYPE);
            this.txtouttype.AddItems(outtypeList); 

            //治疗类别
            ArrayList cureList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.CURE_TYPE);
            this.txtcuretype.AddItems(cureList);
            this.txtsavetype.AddItems(cureList);

            //自制中药制剂
            ArrayList usechamedList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USE_CHA_MED );
            this.txtchamed.AddItems(usechamedList);

            //住院期间是否出现
            ArrayList yesnodList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.YES_NO);
            this.txt_ever_S.AddItems(yesnodList);
            this.txt_ever_F.AddItems(yesnodList);
            this.txt_ever_D.AddItems(yesnodList); 


            //药物过敏
            ArrayList arraylist = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PHARMACYALLERGIC);// baseDml.GetHbsagList();
            this.txtHbsag.AddItems(arraylist);

            ////诊断符合情况
            //ArrayList diagAccord = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DIAGNOSEACCORD);// baseDml.GetDiagAccord();
            //this.CePi.AddItems(diagAccord);

            //病案质量
            ArrayList qcList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.CASEQUALITY);
            txtMrQual.AddItems(qcList);

            //RH性质 
            ArrayList RHList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.RHSTATE); //baseDml.GetRHType();
            txtRhBlood.AddItems(RHList);

            ArrayList listAccord = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ACCORDSTAT);
            txtHbsag.AddItems(listAccord);
            txtHcvAb.AddItems(listAccord);
            txtHivAb.AddItems(listAccord);
            txtPiPo.AddItems(listAccord);
            txtOpbOpa.AddItems(listAccord);
            txtClPa.AddItems(listAccord);
            txtFsBl.AddItems(listAccord);
            txtCePi.AddItems(listAccord);
            //科室下拉列表
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList deptList = dept.GetDeptmentAll();
            txtFirstDept.AddItems(deptList);
            txtDeptSecond.AddItems(deptList);
            txtDeptInHospital.AddItems(deptList);
            txtDeptThird.AddItems(deptList);
            txtDeptOut.AddItems(deptList);

            //InitList(DeptListBox, deptList);
            //血液反应

            ArrayList ReactionBloodList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BLOODREACTION);// baseDml.GetReactionBlood();
            txtReactionBlood.AddItems(ReactionBloodList);
            txtReactionLIQUID.AddItems(ReactionBloodList);

            //感染部位
            ArrayList InfectionPosition = con.GetList("INFECTPOSITION");
            this.txtInfectionPosition.AddItems(InfectionPosition);
            //过敏药物
            ArrayList PharmacyAllergic = con.GetList("PHARMACYALLERGIC");
            this.txtPharmacyAllergic1.AddItems(PharmacyAllergic);
            this.txtPharmacyAllergic2.AddItems(PharmacyAllergic);

            return 1;
        }

        #endregion

        //{7D094A18-0FC9-4e8b-A8E6-901E55D4C20C}

        #region 查询患者信息

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        public void InitTreeView()
        {
            ArrayList al = new ArrayList();
            TreeNode tnParent;
            this.treeView1.HideSelection = false;
            //Neuosft.Neusoft.HISFC.BizProcess.Integrate.RADT pQuery = new Neusoft.HISFC.BizProcess.Integrate.RADT(); //t.RADT.InPatient();
            this.treeView1.BeginUpdate();
            this.treeView1.Nodes.Clear();
            //画树头
            tnParent = new TreeNode();
            tnParent.Text = "最近出院患者";
            tnParent.Tag = "%";
            try
            {
                tnParent.ImageIndex = 0;
                tnParent.SelectedImageIndex = 1;
            }
            catch { }
            this.treeView1.Nodes.Add(tnParent);
            DateTime dt = this.baseDml.GetDateTimeFromSysDateTime();
            DateTime dt2 = dt.AddDays(-3);
            string strEnd = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " 00:00:00";
            string strBegin = dt2.Year.ToString() + "-" + dt2.Month.ToString() + "-" + dt2.Day.ToString() + " 23:59:59";
            Neusoft.HISFC.Models.Base.Employee personObj = (Neusoft.HISFC.Models.Base.Employee)baseDml.Operator;
            //获得最近出院结算患者信息
            if (this.Tag == "")
            {
                al = this.baseDml.QueryPatientOutHospital(strBegin, strEnd, personObj.Dept.ID);
            }
            else
            {
                al = this.baseDml.QueryPatientOutHospital(strBegin, strEnd,"ALL");
            }
            if (al == null)
            {
                MessageBox.Show("查询出院病人信息失败");
                return;
            }

            foreach (Neusoft.HISFC.Models.RADT.PatientInfo pInfo in al)
            {
                TreeNode tnPatient = new TreeNode();

                tnPatient.Text = pInfo.Name + "[" + pInfo.PID.PatientNO + "]";
                tnPatient.Tag = pInfo;
                try
                {
                    tnPatient.ImageIndex = 2;
                    tnPatient.SelectedImageIndex = 3;
                }
                catch { }
                tnParent.Nodes.Add(tnPatient);
            }

            tnParent.Expand();
            this.treeView1.EndUpdate();
        }

        private void patientTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            {
                //				this.Reset();
                //				caseBase.PatientInfo = ((Neusoft.HISFC.Models.RADT.PatientInfo)e.Node.Tag).Clone();
                //				this.ucCaseFirstPage1.Item = caseBase.Clone();
                //				ArrayList alOrg = new ArrayList();
                //				ArrayList alNew = new ArrayList();
                //				alOrg = myBaseDML.GetInhosDiagInfo( caseBase.PatientInfo.ID, "%");
                //				Neusoft.HISFC.Models.HealthRecord.Diagnose dg;
                //				for(int i = 0; i < alOrg.Count; i++)
                //				{
                //					dg = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                //					dg.DiagInfo = ((Neusoft.HISFC.Models.Case.DiagnoseBase)alOrg[i]).Clone();
                //					alNew.Add( dg );
                //				}
                //				this.ucCaseFirstPage1.AlDiag = alNew;
            }
        }


        #endregion

        #region 事件

        #region 性别

        private void PatientSex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dtPatientBirthday.Focus();
            }
        }
        #endregion
        #region 门诊诊断
        private void ClinicDiag_Enter(object sender, System.EventArgs e)
        {
            //			//保存但前活动控件
            //			if(ClinicDiag.ReadOnly)
            //			{
            //				return ;
            //			}
            //			contralActive = this.ClinicDiag;
            //			listBoxActive = ICDListBox;
            //			ListBoxActiveVisible(true);
        }

        private void ClinicDiag_TextChanged(object sender, System.EventArgs e)
        {
            //			ListFilter();
        }
        private void ClinicDiag_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtClinicDocd.Focus();
            }
            //			else if(e.KeyData == Keys.Up)
            //			{
            //				ICDListBox.PriorRow();
            //			}
            //			else if(e.KeyData == Keys.Down)
            //			{
            //				ICDListBox.NextRow();
            //			}
        }
        #endregion
        #region 国籍
        private void Country_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtIDNo.Focus();
            }
        }
        #endregion
        #region  民族
        private void Nationality_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCountry.Focus();
            }
        }
        #endregion
        #region  血型
        private void BloodType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtRhBlood.Focus();
            }
        }
        #endregion
        #region 婚姻
        private void MaritalStatus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtProfession.Focus();
            }
        }
        #endregion
        #region 职业
        private void Profession_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAreaCode.Focus();
            }
        }
        #endregion
        #region 联系人关系
        private void Relation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtLinkmanAdd.Focus();
            }
        }
        #endregion
        #region  入院情况


        private void Circs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInAvenue.Focus();
            }
        }

        #endregion
        #region 门诊医生
        private void ClinicDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtConsultingDoctor.Focus();
                this.txtConsultingDoctor.Text = this.txtClinicDocd.Text;
                this.txtConsultingDoctor.SelectAll();
            }
        }
        #endregion
        #region 病人来源
        private void InAvenue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDateOut.Focus();
            }
        }
        #endregion
        #region 药物过敏
        private void Hbsag_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtHcvAb.Focus();
            }
        }
        private void HcvAb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtHivAb.Focus();
            }
        }
        private void HivAb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCePi.Focus();
            }
        }
        #endregion
        #region 诊断符合

        private void CePi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtPiPo.Focus();
            }
        }
        private void PiPo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtOpbOpa.Focus();
            }
        }

        private void OpbOpa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtClPa.Focus();
            }
        }
        private void ClPa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtFsBl.Focus();
            }
        }

        private void FsBl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtSalvTimes.Focus();
            }
        }
        #endregion
        #region  住院医生
        private void AdmittingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtRefresherDocd.Focus();
                this.txtRefresherDocd.Text = this.txtAdmittingDoctor.Text;
                this.txtRefresherDocd.SelectAll();
            }
        }
        #endregion
        #region 进修医师
        private void RefresherDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtGraDocCode.Focus();
            }
        }
        #endregion
        #region 研究生实习医师
        private void txtGraDocCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPraDocCode.Focus();
            }
        }
        #endregion
        #region 实习医生
        private void PraDocCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInputDoc.Focus();
            }
        }
        #endregion
        #region  主治医师
        private void AttendingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAdmittingDoctor.Focus();
                this.txtAdmittingDoctor.Text = this.txtConsultingDoctor.Text;
                this.txtAdmittingDoctor.SelectAll();
            }
        }
        #endregion
        #region 主任医师
        private void ConsultingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAttendingDoctor.Focus();
                this.txtAttendingDoctor.Text = this.txtConsultingDoctor.Text;
                this.txtAttendingDoctor.SelectAll();
            }
        }
        #endregion
        #region  质控护士
        private void QcNucd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCheckDate.Focus();
            }
        }

        #endregion
        #region 质控医生
        private void QcDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtQcNucd.Focus();
            }
        }
        #endregion
        #region 编码员
        private void CodingCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtCoordinate.Focus();
            }
        }
        #endregion
        #region 整理员
        private void textBox33_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtOperationCode.Focus();
            }
        }
        #endregion
        #region 病案质量
        private void MrQual_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtQcDocd.Focus();
            }
        }
        #endregion
        #region  输血反映
        private void ReactionBlood_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //if (ReactionBlood.Tag != null)
                //{
                //    //if (ReactionBlood.Tag.ToString() != "2")
                //    //{
                //    //    BloodRed.Focus();
                //    //}
                //    //else
                //    //{
                //        //院际会诊次数
                //        InconNum.Focus();
                //    //}
                //}
                //else
                //{
                txtBloodRed.Focus();
                //}
            }
        }

        #endregion
        #region 输入员
        private void InputDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //单独判断 先跳到诊断吧
                //this.tab1.SelectedIndex = 1;
                this.txtMrQual.Focus();
            }
        }
        #endregion
        #region  入院诊断


        private void RuyuanDiagNose_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //单独判断 先跳到诊断
                this.txtConsultingDoctor.Focus();
            }
            //else if (e.KeyData == Keys.Up)
            //{
            //    listBoxActive.PriorRow();
            //}
            //else if (e.KeyData == Keys.Down)
            //{
            //    listBoxActive.NextRow();
            //}
        }


        #endregion
        #region  入院科室
        private void DeptInHospital_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dtFirstTime.Focus();
            }
        }
        #endregion
        #region  RH反应
        private void RhBlood_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtReactionBlood.Focus();
            }
        }
        #endregion
        #region  出生地
        private void AreaCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtNationality.Focus();
            }
        }
        #endregion
        #region 转科1
        private void firstDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDateOut.Focus();
            }
        }
        #endregion
        private void deptSecond_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dtThird.Focus();
            }
        }
        #endregion

        #region 删除当前行
        /// <summary>
        ///删除当前行
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
        {
            switch (this.tab1.SelectedTab.Name)
            {
               // case "手术信息":
                case "tabPage6":
                    this.ucOperation1.DeleteActiveRow();
                    break;
               // case "诊断信息":
                case "tabPage5":
                    this.ucDiagNoseInput1.DeleteActiveRow();
                    break;
               // case "转科信息":
                case "tabPage3":
                    this.ucChangeDept1.DeleteActiveRow();
                    break;
               // case "肿瘤信息":
                case "tabPage7":
                    this.ucTumourCard2.DeleteActiveRow();
                    break;
               // case "妇婴信息":
                case "tabPage2":
                    this.ucBabyCardInput1.DeleteActiveRow();
                    break;
                //case "基本信息":
                case "tabPage1":
                    MessageBox.Show("基本信息不允许删除");
                    break;
            }
            return 1;
        }
        #endregion

        #region 保存数据
        public override int Save(object sender, object neuObject)
        {
            if (CaseBase == null || CaseBase.PatientInfo.ID == null || CaseBase.PatientInfo.ID == "")
            {
                MessageBox.Show("请输入住院流水号或选择病人");
                return -1;
            }

            #region  判断诊断是否符合约束
            Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagNose = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
            if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC) //医生站提示 病案室不需要提示
            {
                //if (DiagValueState(diagNose) != 1)
                //{
                //    return -1;
                //}
            }

            System.DateTime dt = diagNose.GetDateTimeFromSysDateTime(); //获取系统时间
            #endregion
            #region  判断住院号和住院次数是否已经存在
            int intI = baseDml.ExistCase(this.CaseBase.PatientInfo.ID, txtCaseNum.Text, txtInTimes.Text);
            if (intI == -1)
            {
                MessageBox.Show("查询数据失败");
                return -1;
            }
            if (intI == 2)
            {
                MessageBox.Show(txtCaseNum.Text + " 的" + "第 " + txtInTimes.Text + " 次入院已经存在,请更改入院次数");
                return -1;
            }
            #endregion
            //建立事务
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(baseDml.Connection);
            try
            {

                if (CaseBase == null)
                {
                    return -2;
                }
                if (CaseBase.PatientInfo.ID == "")
                {
                    MessageBox.Show("请指定要保存病案的病人");
                    return -2;
                }
                if (CaseBase.PatientInfo.CaseState == "0")
                {
                    MessageBox.Show("病人不允许有病案");
                    return 0;
                }
                if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC && CaseBase.PatientInfo.CaseState == "3")
                {
                    MessageBox.Show("病案室已经存档不允许再修改");
                    return -3;
                }
                if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC && (HandCraft == 1 || HandCraft == 2))
                {
                    MessageBox.Show("病案室已经存档不允许修改");
                    return -3;
                }
                if (CaseBase.PatientInfo.CaseState == "4")
                {
                    MessageBox.Show("病人病案已经封存，不允许保存");
                    return -4;
                }
                if (HandCraft == 1 || HandCraft == 2)  //手工录入 插入
                {
                    CaseBase.PatientInfo.CaseState = "3";
                    CaseBase.IsHandCraft = "1";
                }

                //trans.BeginTransaction();

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                baseDml.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                diagNose.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                deptChange.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                healthRecordFee.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                #region 病案基本信息
                Neusoft.HISFC.Models.HealthRecord.Base info = new Neusoft.HISFC.Models.HealthRecord.Base();
                int i = this.GetInfoFromPanel(info);
                if (ValidState(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
                //先执行更新操作 
                if (baseDml.UpdateBaseInfo(info) < 1)
                {
                    //更新失败 则执行插入操作 
                    if (baseDml.InsertBaseInfo(info) < 1)
                    {
                        //回退
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存病人基本信息失败 :" + baseDml.Err);
                        return -1;
                    }
                }
                this.ucChangeDept1.Patient = info.PatientInfo;
                this.ucDiagNoseInput1.Patient = info.PatientInfo;
                this.ucOperation1.Patient = info.PatientInfo;
                this.ucBabyCardInput1.Patient = info.PatientInfo;
                this.ucTumourCard2.Patient = info.PatientInfo;
                this.ucFeeInfo1.Patient = info.PatientInfo;
                #region  最开始的设计,根据 住院主表的 病案标志 判断时更新还是插入操作  发觉不好控制 这里删掉了
                //				if(CaseBase.PatientInfo.CaseState == "1") 
                //				{
                //					//可以有病案 现在没有保存过的病案
                //					if(baseDml.InsertBaseInfo(info) < 1)
                //					{
                //						//回退
                //						Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //						MessageBox.Show("保存病人基本信息失败 :" +baseDml.Err );
                //						return -1;
                //					}
                //					#region 门诊诊断
                //					//					if(clinicDiag != null)
                //					//					{
                //					//						if(diagNose.InsertDiagnose(clinicDiag) < 1)
                //					//						{
                //					//							Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //					//							MessageBox.Show("保存门诊诊断失败 :" + diagNose.Err);
                //					//						}
                //					//					}
                //					#endregion 
                //					#region  入院诊断 
                //					//					if(InDiag != null)
                //					//					{
                //					//						if(diagNose.InsertDiagnose(InDiag) < 1)
                //					//						{
                //					//							Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //					//							MessageBox.Show("保存失败 :" + diagNose.Err);
                //					//						}
                //					//					}
                //					#endregion 
                //				}
                //				else if(CaseBase.PatientInfo.CaseState == "2" ||CaseBase.PatientInfo.CaseState == "3")
                //				{
                //					//已经保存过病案了 
                //					if(baseDml.UpdateBaseInfo(info)< 1)
                //					{
                //						Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //						MessageBox.Show("保存病人基本信息失败 :" +baseDml.Err );
                //						return -1;
                //					}
                //
                //					#region  门诊诊断 
                ////					if(clinicDiag != null)
                ////					{
                ////						if(diagNose.UpdateDiagnose(clinicDiag) < 1)
                ////						{
                ////							if(diagNose.InsertDiagnose(clinicDiag) < 1)
                ////							{
                ////								Neusoft.FrameWork.Management.PublicTrans.RollBack();
                ////								MessageBox.Show("保存门诊诊断失败 :" + diagNose.Err);
                ////							}
                ////						}
                ////					}
                //					#endregion 
                //
                //					#region  入院诊断 
                ////					if(InDiag != null)
                ////					{
                ////						if(diagNose.UpdateDiagnose(InDiag) < 1)
                ////						{
                ////							if(diagNose.InsertDiagnose(InDiag) < 1)
                ////							{
                ////								Neusoft.FrameWork.Management.PublicTrans.RollBack();
                ////								MessageBox.Show("保存入院诊断失败 :" + diagNose.Err);
                ////							}
                ////						}
                ////					}
                //					#endregion 
                //				}
                #endregion
                #endregion
                #region 转科信息
                //设计思路,先删除,然后同一插入.
                //主界面上的 
                ArrayList deptMain = new ArrayList();
                //增加的 
                ArrayList deptAdd = new ArrayList();
                //修改过的 
                ArrayList deptMod = new ArrayList();
                #region 基本信息界面上的转科信息
                #region 第一次转科信息
                if (txtFirstDept.Tag != null)
                {
                    Neusoft.HISFC.Models.RADT.Location deptObj = new Neusoft.HISFC.Models.RADT.Location();
                    deptObj.User02 = CaseBase.PatientInfo.ID;
                    deptObj.Dept.Name = txtFirstDept.Text;
                    deptObj.Dept.ID = txtFirstDept.Tag.ToString();
                    deptObj.User01 = this.dtFirstTime.Value.ToString();

                    deptMain.Add(deptObj);
                }
                #endregion
                #region  第二次转科信息
                if (txtDeptSecond.Tag != null)
                {
                    Neusoft.HISFC.Models.RADT.Location deptObj = new Neusoft.HISFC.Models.RADT.Location();
                    deptObj.User02 = CaseBase.PatientInfo.ID;
                    deptObj.Dept.Name = txtDeptSecond.Text;
                    deptObj.Dept.ID = txtDeptSecond.Tag.ToString();
                    deptObj.User01 = this.dtSecond.Value.ToString();
                    deptMain.Add(deptObj);
                }
                #endregion
                #region 第三次转科
                if (txtDeptThird.Tag != null)
                {
                    Neusoft.HISFC.Models.RADT.Location deptObj = new Neusoft.HISFC.Models.RADT.Location();
                    deptObj.User02 = CaseBase.PatientInfo.ID;
                    deptObj.Dept.Name = txtDeptThird.Text;
                    deptObj.Dept.ID = txtDeptThird.Tag.ToString();
                    deptObj.User01 = this.dtThird.Value.ToString();
                    deptMain.Add(deptObj);
                }
                #endregion
                #endregion
                //删除空白行
                this.ucChangeDept1.deleteRow();
                //this.ucChangeDept1.GetList("D", deptDel);
                this.ucChangeDept1.GetList("A", deptAdd);
                this.ucChangeDept1.GetList("M", deptMod);

                if (this.ucChangeDept1.ValueState(deptAdd) == -1 || this.ucChangeDept1.ValueState(deptMod) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -3;
                }
                else
                {
                    if (deptChange.DeleteChangeDept(info.PatientInfo.ID) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("转科信息保存失败" + baseDml.Err);
                        return -3;
                    }
                }
                //if (deptDel != null)
                //{
                //    foreach (Neusoft.HISFC.Models.RADT.Location obj in deptDel)
                //    {
                //        if (deptChange.DeleteChangeDept(obj) < 1)
                //        {
                //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //            MessageBox.Show("转科信息保存失败" + baseDml.Err);
                //            return -1;
                //        }
                //    }
                //}
                if (deptAdd != null)
                {
                    foreach (Neusoft.HISFC.Models.RADT.Location obj in deptAdd)
                    {
                        if (deptChange.InsertChangeDept(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("转科信息保存失败" + baseDml.Err);
                            return -1;
                        }
                    }
                }
                if (deptMain != null)
                {
                    foreach (Neusoft.HISFC.Models.RADT.Location obj in deptMain)
                    {
                        if (deptChange.InsertChangeDept(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("转科信息保存失败" + baseDml.Err);
                            return -1;
                        }
                    }
                }
                if (deptMod != null)
                {
                    foreach (Neusoft.HISFC.Models.RADT.Location obj in deptMod)
                    {
                        if (deptChange.InsertChangeDept(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("转科信息保存失败" + baseDml.Err);
                            return -1;
                        }
                    }
                }
                //查询保存过的信息
                ArrayList tempChangeDept = deptChange.QueryChangeDeptFromShiftApply(CaseBase.PatientInfo.ID, "2");
                #endregion
                #region  病案诊断

                //删除的
                ArrayList diagDel = new ArrayList();
                //增加的 
                ArrayList diagAdd = new ArrayList();
                //修改过的 
                ArrayList diagMod = new ArrayList();
                #region  门诊诊断
                //				//0 默认， 1 修改 ，2 插入， 3 删除 
                //				if(RuDiag == 1)
                //				{
                //					diagMod.Add(clinicDiag);
                //				}
                //				else if(RuDiag == 2)
                //				{
                //					diagAdd.Add(clinicDiag);
                //				}
                //				else if(RuDiag == 3)
                //				{
                //					diagDel.Add(clinicDiag);
                //				}
                #endregion
                #region  入院诊断
                //				if(menDiag == 1)
                //				{
                //					diagMod.Add(InDiag);
                //				}
                //				else if(menDiag == 2)
                //				{
                //					diagAdd.Add(InDiag);
                //				}
                //				else if(menDiag == 3)
                //				{
                //					diagDel.Add(InDiag);
                //				}
                #endregion
                //删除空白行
                this.ucDiagNoseInput1.deleteRow();
                this.ucDiagNoseInput1.GetList("A", diagAdd);
                this.ucDiagNoseInput1.GetList("M", diagMod);
                this.ucDiagNoseInput1.GetList("D", diagDel);
                if (this.ucDiagNoseInput1.ValueState(diagAdd) == -1 || this.ucDiagNoseInput1.ValueState(diagMod) == -1 || this.ucDiagNoseInput1.ValueState(diagDel) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); //数据校验失败
                    return -3;
                }
                if (diagDel != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagDel)
                    {
                        if (diagNose.DeleteDiagnoseSingle(obj.DiagInfo.Patient.ID, obj.DiagInfo.HappenNo, frmType) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                            return -1;
                        }
                    }
                }
                if (diagMod != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagMod)
                    {
                        if (diagNose.UpdateDiagnose(obj) < 1)
                        {
                            if (diagNose.InsertDiagnose(obj) < 1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                                return -1;
                            }
                        }

                    }
                }
                if (diagAdd != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagAdd)
                    {
                        if (diagNose.InsertDiagnose(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                            return -1;
                        }

                    }
                }
                //暂时保存插入和修改过的数据
                ArrayList tempDiag = diagNose.QueryCaseDiagnose(CaseBase.PatientInfo.ID, "%", frmType);
                #endregion
                #region  手术信息
                Neusoft.HISFC.BizLogic.HealthRecord.Operation operation = new Neusoft.HISFC.BizLogic.HealthRecord.Operation();
                operation.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //删除的
                ArrayList operDel = new ArrayList();
                //增加的 
                ArrayList operAdd = new ArrayList();
                //修改过的 
                ArrayList operMod = new ArrayList();
                //删除空白行
                this.ucOperation1.deleteRow();
                this.ucOperation1.GetList("D", operDel);
                this.ucOperation1.GetList("A", operAdd);
                this.ucOperation1.GetList("M", operMod);

                if (this.ucOperation1.ValueState(operDel) == -1 || this.ucOperation1.ValueState(operAdd) == -1 || this.ucOperation1.ValueState(operMod) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); //数据校验失败
                    return -3;
                }
                if (operDel != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.OperationDetail obj in operDel)
                    {
                        if (operation.delete(frmType, obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存手术诊断信息失败" + operation.Err);
                            return -1;
                        }
                    }
                }
                if (operAdd != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.OperationDetail obj in operAdd)
                    {
                        obj.OperDate = dt;
                        if (operation.Insert(frmType, obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存手术诊断信息失败" + operation.Err);
                            return -1;
                        }
                    }
                }
                if (operMod != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.OperationDetail obj in operMod)
                    {
                        if (operation.Update(frmType, obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存手术诊断信息失败" + operation.Err);
                            return -1;
                        }
                    }
                }
                ArrayList tempOperation = operation.QueryOperation(this.frmType, CaseBase.PatientInfo.ID);
                #endregion
                #region 妇婴信息
                Neusoft.HISFC.BizLogic.HealthRecord.Baby baby = new Neusoft.HISFC.BizLogic.HealthRecord.Baby();
                //baby.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //删除的
                ArrayList babyDel = new ArrayList();
                //增加的 
                ArrayList babyAdd = new ArrayList();
                //修改过的 
                ArrayList babyMod = new ArrayList();
                //删除空白行
                this.ucBabyCardInput1.deleteRow();
                this.ucBabyCardInput1.GetList("D", babyDel);
                this.ucBabyCardInput1.GetList("A", babyAdd);
                this.ucBabyCardInput1.GetList("M", babyMod);
                if (this.ucBabyCardInput1.ValueState(babyDel) == -1 || this.ucBabyCardInput1.ValueState(babyAdd) == -1 || this.ucBabyCardInput1.ValueState(babyMod) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); //数据校验失败
                    return -3;
                }
                if (babyDel != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Baby obj in babyDel)
                    {
                        if (baby.Delete(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存妇婴信息失败" + baby.Err);
                            return -1;
                        }
                    }
                }
                if (babyAdd != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Baby obj in babyAdd)
                    {
                        if (baby.Insert(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存妇婴信息失败" + baby.Err);
                            return -1;
                        }
                    }

                }
                if (babyMod != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Baby obj in babyMod)
                    {
                        if (baby.Update(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存妇婴信息失败" + baby.Err);
                            return -1;
                        }
                    }
                }
                //暂时存储保存过的信息
                ArrayList tempBaby = baby.QueryBabyByInpatientNo(CaseBase.PatientInfo.ID);
                #endregion
                #region  肿瘤信息
                Neusoft.HISFC.BizLogic.HealthRecord.Tumour tumour = new Neusoft.HISFC.BizLogic.HealthRecord.Tumour();
                //tumour.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                Neusoft.HISFC.Models.HealthRecord.Tumour TumInfo = this.ucTumourCard2.GetTumourInfo();
                int m = this.ucTumourCard2.ValueTumourSate(TumInfo);
                if (m == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -3;
                }
                else if (m == 2) //有数据需要保存 
                {
                    if (tumour.UpdateTumour(TumInfo) < 1)
                    {
                        if (tumour.InsertTumour(TumInfo) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tumour.Err);
                            return -3;
                        }
                    }
                }
                //删除的
                ArrayList tumDel = new ArrayList();
                //增加的 
                ArrayList tumAdd = new ArrayList();
                //修改过的 
                ArrayList tumMod = new ArrayList();
                //删除空白行
                this.ucTumourCard2.deleteRow();
                this.ucTumourCard2.GetList("D", tumDel);
                this.ucTumourCard2.GetList("A", tumAdd);
                this.ucTumourCard2.GetList("M", tumMod);
                if (this.ucTumourCard2.ValueState(tumDel) == -1 || this.ucTumourCard2.ValueState(tumAdd) == -1 || this.ucTumourCard2.ValueState(tumMod) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();//回退
                    return -3;
                }
                if (tumDel != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.TumourDetail obj in tumDel)
                    {
                        if (tumour.DeleteTumourDetail(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存肿瘤信息失败" + tumour.Err);
                            return -1;
                        }
                    }
                }
                if (tumAdd != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.TumourDetail obj in tumAdd)
                    {
                        if (tumour.InsertTumourDetail(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存肿瘤信息失败" + tumour.Err);
                            return -1;
                        }
                    }
                }
                if (tumMod != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.TumourDetail obj in tumMod)
                    {
                        if (tumour.UpdateTumourDetail(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存肿瘤信息失败" + tumour.Err);
                            return -1;
                        }
                    }
                }
                //查询保存的信息
                ArrayList tempTumour = tumour.QueryTumourDetail(CaseBase.PatientInfo.ID);

                #endregion
                #region  费用信息
                ArrayList feeList = this.ucFeeInfo1.GetFeeInfoList();
                if (this.ucFeeInfo1.ValueState(feeList) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();//回退
                    return -3;
                }
                if (feeList != null)
                {
                    foreach (Neusoft.HISFC.Models.RADT.Patient obj in feeList)
                    {
                        obj.ID = this.CaseBase.PatientInfo.ID; //住院流水号
                        obj.User01 = this.CaseBase.PatientInfo.PVisit.OutTime.ToString(); //出院日期
                        if (healthRecordFee.UpdateFeeInfo(obj) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存费用信息失败" + baseDml.Err);
                            return -1;
                        }
                    }
                }
                #endregion

                #region  保存成功

                //根据目前病案标志 修改住院主表的病案信息
                if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
                {
                    //医生站录入病案
                    if (baseDml.UpdateMainInfoCaseFlag(CaseBase.PatientInfo.ID, "2") < 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新主表失败" + baseDml.Err);
                        return -1;
                    }
                    CaseBase.PatientInfo.CaseState = "2";
                }
                else if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS && CaseBase.IsHandCraft != "1") //病案室录入病案
                {
                    if (baseDml.UpdateMainInfoCaseFlag(CaseBase.PatientInfo.ID, "3") < 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新主表 case_flag 失败" + baseDml.Err);
                        return -1;
                    }
                    if (baseDml.UpdateMainInfoCaseSendFlag(CaseBase.PatientInfo.ID, "3") < 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新主表casesend_flag 失败" + baseDml.Err);
                        return -1;
                    }
                    CaseBase.PatientInfo.CaseState = "3";
                }
                //保存fpPoint的更改。
                this.ucBabyCardInput1.fpEnterSaveChanges(tempBaby);
                this.ucChangeDept1.fpEnterSaveChanges(tempChangeDept);
                LoadChangeDept(tempChangeDept);
                this.ucDiagNoseInput1.fpEnterSaveChanges(tempDiag);
                this.ucOperation1.fpEnterSaveChanges(tempOperation);
                this.ucTumourCard2.fpEnterSaveChanges(tempTumour);
                //				RuDiag = 0;  //门诊诊断标志
                //				menDiag = 0; //入院诊断标志
                //费用信息
                //trans.Commit();

                #region 后续工作 
                //更新病案基本表中 门诊诊断，入院诊断，出院诊断 ，手术 （第一诊断 或手术）
                if (baseDml.UpdateBaseDiagAndOperation(CaseBase.PatientInfo.ID, frmType) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新病案主表诊断手术信息失败.");
                    return -1;
                }
                localObj.User01 = CaseBase.PatientInfo.PVisit.OutTime.ToString(); //出院一起
                localObj.User02 = CaseBase.PatientInfo.PVisit.PatientLocation.ID; //出院科室 
                if (baseDml.DiagnoseAndOperation(localObj, CaseBase.PatientInfo.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新病案主表诊断手术信息失败.");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.tab1.SelectedIndex = 0;
                #endregion
                //手工录入病案标志置成默认标志 
                this.HandCraft = 0;
                #endregion
                MessageBox.Show("保存成功");

                this.ClearInfo();
                //住院号
                txtPatientNOSearch.Text = "";
                txtPatientNOSearch.Focus();
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        #endregion

        #region 选择TAB页
        private void tab1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.tab1.SelectedTab.Name)
            {
                //case "肿瘤信息":
                case "tabPage7":
                    //如果小于零 ，增加一行
                    if (this.ucTumourCard2.GetfpSpreadRowCount() == 0)
                    {
                        this.ucTumourCard2.AddRow();
                        this.ucTumourCard2.SetActiveCells();
                    }
                    break;
               // case "手术信息":
                case "tabPage6":
                    //如果小于零 ，增加一行
                    if (this.ucOperation1.GetfpSpread1RowCount() == 0)
                    {
                        this.ucOperation1.AddRow();
                        this.ucOperation1.SetActiveCells();
                    }
                    break;
               // case "费用信息":
                case "tabPage4":
                    break;
               // case "诊断信息":
                case "tabPage5":
                    if (this.ucDiagNoseInput1.GetfpSpreadRowCount() == 0)
                    {
                        this.ucDiagNoseInput1.AddRow();
                        this.ucDiagNoseInput1.SetActiveCells();
                    }
                    break;
                //case "妇婴信息":
                case "tabPage2":
                    if (this.ucBabyCardInput1.GetfpSpreadRowCount() == 0)
                    {
                        this.ucBabyCardInput1.AddRow();
                        this.ucBabyCardInput1.SetActiveCells();
                    }
                    break;
               // case "转科信息":
                case "tabPage3":
                    if (this.ucChangeDept1.GetfpSpreadRowCount() == 0)
                    {
                        this.ucChangeDept1.AddRow();
                        this.ucChangeDept1.SetActiveCells();
                    }
                    break;
            }
        }
        #endregion

        #region  将数据显示到界面上

        #region 加载基本信息
        /// <summary>
        /// 将数据显示到界面上
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ConvertInfoToPanel(Neusoft.HISFC.Models.HealthRecord.Base info)
        {
            try
            {
                this.patientInfo = info.PatientInfo;
                #region  入院科室，出院科室
                if (CaseBase.PatientInfo.CaseState == "1")
                {
                    //Neusoft.HISFC.Models.RADT.Location indept = baseDml.GetDeptIn(CaseBase.PatientInfo.ID);
                    //Neusoft.HISFC.Models.RADT.Location outdept = baseDml.GetDeptOut(CaseBase.PatientInfo.ID);
                    //if (indept != null) //入院科室 
                    //{
                    //    CaseBase.InDept.ID = indept.Dept.ID;
                    //    CaseBase.InDept.Name = indept.Dept.Name;
                    //    //入院科室代码
                    //    DeptInHospital.Tag = indept.Dept.ID;
                    //    //入院科室名称
                    //    DeptInHospital.Text = indept.Dept.Name;

                    //}
                    //出院科室
                    CaseBase.OutDept.ID = info.PatientInfo.PVisit.PatientLocation.Dept.ID;
                    CaseBase.OutDept.Name = info.PatientInfo.PVisit.PatientLocation.Dept.Name;
                    //出院科室代码
                    txtDeptOut.Tag = info.PatientInfo.PVisit.PatientLocation.Dept.ID;
                    //出院科室代码
                    txtDeptInHospital.Tag = info.PatientInfo.PVisit.PatientLocation.Dept.ID;
                }
                else
                {
                    //入院科室代码
                    txtDeptInHospital.Tag = info.InDept.ID;
                    //出院科室代码
                    txtDeptOut.Tag = info.OutDept.ID;
                }

                #endregion

                //住院号  病历号
                if (info.CaseNO == "" || info.CaseNO == null)
                {
                    txtCaseNum.Text = info.PatientInfo.PID.PatientNO;
                }
                else
                {
                    txtCaseNum.Text = info.CaseNO;
                }
                //就诊卡号  门诊号
                txtClinicNo.Text = info.PatientInfo.PID.CardNO;
                //姓名
                this.txtPatientName.Text = info.PatientInfo.Name;
                //曾用名
                ////txtNomen.Text = info.Nomen;
                //性别
                if (info.PatientInfo.Sex.ID != null)
                {
                    txtPatientSex.Tag = info.PatientInfo.Sex.ID.ToString();
                }
                //生日
                if (info.PatientInfo.Birthday != System.DateTime.MinValue)
                {
                    dtPatientBirthday.Value = info.PatientInfo.Birthday;
                }
                else
                {
                    dtPatientBirthday.Value = System.DateTime.Now;
                }
                //国籍 编码
                txtCountry.Tag = info.PatientInfo.Country.ID;
                //民族 
                txtNationality.Tag = info.PatientInfo.Nationality.ID;
                //职业
                txtProfession.Tag = info.PatientInfo.Profession.ID;
                //血型编码
                if (info.PatientInfo.BloodType.ID != null)
                {
                    txtBloodType.Tag = info.PatientInfo.BloodType.ID.ToString();
                }
                //婚姻
                if (info.PatientInfo.MaritalStatus.ID != null)
                {
                    txtMaritalStatus.Tag = info.PatientInfo.MaritalStatus.ID;
                }
                //身份证号
                txtIDNo.Text = info.PatientInfo.IDCard;
                //结算类别号
                txtPactKind.Tag = info.PatientInfo.Pact.ID;
                //医保公费号
                txtSSN.Text = info.PatientInfo.SSN;
                //籍贯
                txtDIST.Text = info.PatientInfo.DIST;
                //出生地
                txtAreaCode.Tag = info.PatientInfo.AreaCode;
                txtAreaCode.Text = info.PatientInfo.AreaCode;
                if (txtAreaCode.Text == "")
                {
                    txtAreaCode.Text = info.PatientInfo.AreaCode;
                }
                //家庭住址
                txtAddressHome.Text = info.PatientInfo.AddressHome;
                //家庭电话
                txtPhoneHome.Text = info.PatientInfo.PhoneHome;
                //住址邮编
                if (info.PatientInfo.CaseState == "1")
                {
                    txtHomeZip.Text = info.PatientInfo.User02;
                }
                else
                {
                    txtHomeZip.Text = info.PatientInfo.HomeZip;
                }
                //单位地址
                if (info.PatientInfo.CaseState == "1")
                {
                    txtAddressBusiness.Text = info.PatientInfo.CompanyName;
                }
                else
                {
                    txtAddressBusiness.Text = info.PatientInfo.AddressBusiness;
                }
                //单位电话
                txtPhoneBusiness.Text = info.PatientInfo.PhoneBusiness;
                //单位邮编
                if (info.PatientInfo.CaseState == "1")
                {
                    txtBusinessZip.Text = info.PatientInfo.User01;
                }
                else
                {
                    txtBusinessZip.Text = info.PatientInfo.BusinessZip;
                }
                //联系人名称
                txtKin.Text = info.PatientInfo.Kin.Name;
                txtKin.Tag = info.PatientInfo.Kin.ID;
                //与患者关系
                txtRelation.Tag = info.PatientInfo.Kin.RelationLink;
                //联系电话
                if (info.PatientInfo.CaseState == "1")
                {
                    txtLinkmanTel.Text = info.PatientInfo.Kin.RelationPhone;
                }
                else
                {
                    txtLinkmanTel.Text = info.PatientInfo.Kin.RelationPhone;
                }
                //联系地址
                if (info.PatientInfo.CaseState == "1")
                {
                    txtLinkmanAdd.Text = info.PatientInfo.Kin.User01;
                }
                else
                {
                    txtLinkmanAdd.Text = info.PatientInfo.Kin.RelationAddress;
                }
                //门诊诊断医生 ID
                txtClinicDocd.Tag = info.ClinicDoc.ID;
                //门诊诊断医生姓名
                //ClinicDocd.Text = info.ClinicDoc.Name;
                //转来医院
                ////txtComeFrom.Text = info.ComeFrom;
                //入院日期
                if (info.PatientInfo.PVisit.InTime != System.DateTime.MinValue)
                {
                    dtDateIn.Value = info.PatientInfo.PVisit.InTime;
                }
                else
                {
                    dtDateIn.Value = System.DateTime.Now;
                }
                if (info.PatientInfo.CaseState == "1")
                {
                    //院感次数 
                    txtInfectNum.Text = Convert.ToString(this.ucDiagNoseInput1.GetInfectionNum());
                }
                else
                {
                    //院感次数 
                    txtInfectNum.Text = info.InfectionNum.ToString();
                }
                //住院次数
                txtInTimes.Text = info.PatientInfo.InTimes.ToString();
                //入院来源

                txtInAvenue.Tag = info.PatientInfo.PVisit.InSource.ID;

                //入院状态                  
                txtCircs.Tag = info.PatientInfo.PVisit.Circs.ID;
                customListBox1.Tag = info.PatientInfo.PVisit.Circs.ID;
                //customListBox1.Text = info.PatientInfo.PVisit.Circs.Name;

                if(info.PatientInfo.Age!= null)
                    txtPatientAge.Text =  info.PatientInfo.Age.Replace("岁","").Replace("月","").Replace("天","");

                //确诊日期
                if (info.DiagDate != System.DateTime.MinValue)
                {
                    txtDiagDate.Value = info.DiagDate;
                }
                else
                {
                    txtDiagDate.Value = System.DateTime.Now;
                }
                //手术日期
                //			info.OperationDate 
                //出院日期
                if (info.PatientInfo.PVisit.OutTime != System.DateTime.MinValue)
                {
                    txtDateOut.Value = info.PatientInfo.PVisit.OutTime;
                }
                else
                {
                    txtDateOut.Value = System.DateTime.Now;
                }

                //转归代码
                //			info.PatientInfo.PVisit.Zg.ID 
                //确诊天数
                //			info.DiagDays
                //住院天数
                txtPiDays.Text = info.InHospitalDays.ToString();
                //死亡日期
                //			info.DeadDate = 
                //死亡原因
                //			info.DeadReason
                //尸检
                if (info.CadaverCheck == "1")
                {
                    cbBodyCheck.Checked = true;
                }
                //死亡种类
                //			info.DeadKind 
                //尸体解剖号
                //			info.BodyAnotomize
                //乙肝表面抗原
                txtHbsag.Tag = info.Hbsag;
                //丙肝病毒抗体
                txtHcvAb.Tag = info.HcvAb;
                //获得性人类免疫缺陷病毒抗体
                txtHivAb.Tag = info.HivAb;
                //门急_出院符合
                txtCePi.Tag = info.CePi;
                //入出_院符合
                txtPiPo.Tag = info.PiPo;
                //术前_后符合
                txtOpbOpa.Tag = info.OpbOpa;
                //临床_CT符合
                //临床_MRI符合
                //临床_病理符合
                txtClPa.Tag = info.ClPa;
                //放射_病理符合
                txtFsBl.Tag = info.FsBl;

                //抢救次数
                txtSalvTimes.Text = info.SalvTimes.ToString();
                //成功次数
                txtSuccTimes.Text = info.SuccTimes.ToString();
                //示教科研
                if (info.TechSerc == "1")
                {
                    cbTechSerc.Checked = true;
                }
                //是否随诊
                if (info.VisiStat == "1")
                {
                    cbVisiStat.Checked = true;
                }
                //随访期限 周
                if (info.VisiPeriodWeek == "")
                {
                    txtVisiPeriWeek.Text = "0";
                }
                else
                {
                    txtVisiPeriWeek.Text = info.VisiPeriodWeek;
                }
                //随访期限 月
                if (info.VisiPeriodMonth == "")
                {
                    txtVisiPeriMonth.Text = "0";
                }
                else
                {
                    txtVisiPeriMonth.Text = info.VisiPeriodMonth;
                }
                //随访期限 年
                if (info.VisiPeriodYear == "")
                {
                    txtVisiPeriYear.Text = "0";
                }
                else
                {
                    txtVisiPeriYear.Text = info.VisiPeriodYear;
                }
                //院际会诊次数
                txtInconNum.Text = info.InconNum.ToString();
                //远程会诊
                txtOutconNum.Text = info.OutconNum.ToString();
                //药物过敏
                //			info.AnaphyFlag 
                //过敏药物1
                this.txtPharmacyAllergic1.Tag = info.FirstAnaphyPharmacy.ID;
                //过敏药物2
                this.txtPharmacyAllergic2.Tag = info.SecondAnaphyPharmacy.ID;
                //感染部位
                this.txtInfectionPosition.Tag = info.InfectionPosition.ID;
                //更改后出院日期
                //			info.CoutDate
                //住院医师代码
                txtAdmittingDoctor.Tag = info.PatientInfo.PVisit.AdmittingDoctor.ID;
                //住院医师姓名
                //AdmittingDoctor.Text = info.PatientInfo.PVisit.AdmittingDoctor.Name;
                //主治医师代码
                txtAttendingDoctor.Tag = info.PatientInfo.PVisit.AttendingDoctor.ID;
                //AttendingDoctor.Text = info.PatientInfo.PVisit.AttendingDoctor.Name;
                //主任医师代码
                txtConsultingDoctor.Tag = info.PatientInfo.PVisit.ConsultingDoctor.ID;
                //ConsultingDoctor.Text = info.PatientInfo.PVisit.ConsultingDoctor.Name;
                //科主任代码
                //			info.PatientInfo.PVisit.ReferringDoctor.ID
                //进修医师代码
                txtRefresherDocd.Tag = info.RefresherDoc.ID;
                //RefresherDocd.Text = info.RefresherDoc.Name;
                //研究生实习医师代码
                txtGraDocCode.Tag = info.GraduateDoc.ID;
                //GraDocCode.Text = info.GraduateDoc.Name;
                //实习医师代码
                txtPraDocCode.Tag = info.PatientInfo.PVisit.TempDoctor.ID;
                //PraDocCode.Text = info.GraduateDoc.Name;
                //编码员
                txtCodingCode.Tag = info.CodingOper.ID;
                //CodingCode.Text = info.CodingName;
                //病案质量
                txtMrQual.Tag = info.MrQuality;
                //MrQual.Text = CaseQCHelper.GetName(info.MrQual);
                //合格病案
                //			info.MrElig
                //质控医师代码
                txtQcDocd.Tag = info.QcDoc.ID;
                //QcDocd.Text = info.QcDonm;
                //质控护士代码
                txtQcNucd.Tag = info.QcNurse.ID;
                //QcNucd.Text = info.QcNunm;
                //检查时间
                if (info.CheckDate != System.DateTime.MinValue)
                {
                    txtCheckDate.Value = info.CheckDate;
                }
                else
                {
                    txtCheckDate.Value = System.DateTime.Now;
                }
                //手术操作治疗检查诊断为本院第一例项目
                if (info.YnFirst == "1")
                {
                    cbYnFirst.Checked = true;
                }
                //Rh血型(阴阳)
                txtRhBlood.Tag = info.RhBlood;
                //输血反应（有无）
                txtReactionBlood.Tag = info.ReactionBlood;
                //红细胞数
                if (info.BloodRed == "" || info.BloodRed == null)
                {
                    txtBloodRed.Text = "0";
                }
                else
                {
                    txtBloodRed.Text = info.BloodRed;
                }
                //血小板数
                if (info.BloodPlatelet == "" || info.BloodPlatelet == null)
                {
                    txtBloodPlatelet.Text = "0";
                }
                else
                {
                    txtBloodPlatelet.Text = info.BloodPlatelet;
                }
                //血浆数
                if (info.BodyAnotomize == "" || info.BodyAnotomize == null)
                {
                    txtBodyAnotomize.Text = "0";
                }
                else
                {
                    txtBodyAnotomize.Text = info.BodyAnotomize;
                }
                //全血数
                if (info.BloodWhole == "" || info.BodyAnotomize == null)
                {
                    txtBloodWhole.Text = "0";
                }
                else
                {
                    txtBloodWhole.Text = info.BloodWhole;
                }
                //其他输血数
                if (info.BloodOther == "" || info.BodyAnotomize == null)
                {
                    txtBloodOther.Text = "0";
                }
                else
                {
                    txtBloodOther.Text = info.BloodOther;
                }
                //X光号
                txtXNumb.Text = info.XNum;
                //CT号
                txtCtNumb.Text = info.CtNum;
                //MRI号
                txtMriNumb.Text = info.MriNum;
                //病理号
                txtPathNumb.Text = info.PathNum;
                //B超号
                txtBC.Text = info.DsaNum;
                //ECT号
                txtECTNumb.Text = info.EctNum;
                //PET号
                txtPETNumb.Text = info.PetNum;

                //DSA号
                //			info.DsaNumb
                //PET号
                //			info.PetNumb
                //ECT号
                //			info.EctNumb
                //X线次数
                //			info.XTimes
                //CT次数
                //			info.CtTimes
                //MR次数
                //			info.MrTimes;
                //DSA次数
                //			info.DsaTimes
                //PET次数
                //			info.PetTimes
                //ECT次数
                //			info.EctTimes
                //说明
                //			info.Memo
                //归档条码号
                //			info.BarCode
                //病案借阅状态(O借出 I在架)
                //			info.LendStus
                //病案状态1科室质检2登记保存3整理4病案室质检5无效
                //			info.CaseStus 
                //特级护理时间
                txtSuperNus.Text = info.SuperNus.ToString();
                //I级护理时间
                txtINus.Text = info.INus.ToString();
                //II级护理时间
                txtIINus.Text = info.IINus.ToString();
                //III级护理时间
                txtIIINus.Text = info.IIINus.ToString();
                //重症监护时间
                txtStrictNuss.Text = info.StrictNuss.ToString();
                //特殊护理
                txtSPecalNus.Text = info.SpecalNus.ToString();
                //输入员
                txtInputDoc.Tag = info.OperInfo.ID;
                //InputDoc.Text = DoctorHelper.GetName(info.OperCode);
                //整理员 
                txtCoordinate.Tag = info.PackupMan.ID;
                //textBox33.Text = DoctorHelper.GetName(info.PackupMan.ID);
                //手术编码员 
                this.txtOperationCode.Tag = info.OperationCoding.ID;
                txtBC.Text = info.DsaNum;
                //单病种 
                cbDisease30.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(info.Disease30);

                //出院方式
                this.txtouttype.Tag = info.Out_Type ;
                //治疗方式
                this.txtcuretype.Tag = info.Cure_Type ;
                //自制中药制剂 
                this.txtchamed.Tag = info.Use_CHA_Med ;
                //抢救方法 
                this.txtsavetype.Tag = info.Save_Type ;
                //是否出现危重 
                this.txt_ever_S.Tag = info.Ever_Sickintodeath ;
                //是否出现急症 
                this.txt_ever_F.Tag = info.Ever_Firstaid ;
                //是否出现疑难情况 
                this.txt_ever_D.Tag = info.Ever_Difficulty ;
                //输液反应 
                this.txtReactionLIQUID.Tag = info.ReactionLiquid;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        #endregion

        #region 加载前三次转科信息
        /// <summary>
        /// 加载前三次转科信息
        /// </summary>
        /// <param name="list"></param>
        private void LoadChangeDept(ArrayList list)
        {
            if (list == null)
            {
                return;
            }

            #region 转科信息的前三个在界面上显示
            if (list.Count > 0) //有转科信息
            {
                //转科信息的前三个在界面上显示
                int j = 0;
                if (list.Count >= 3)
                {
                    j = 3;
                }
                else
                {
                    j = list.Count;
                }
                for (int i = 0; i < j; i++)
                {
                    switch (i)
                    {
                        case 0:
                            firDept = (Neusoft.HISFC.Models.RADT.Location)list[0];
                            break;
                        case 1:
                            secDept = (Neusoft.HISFC.Models.RADT.Location)list[1];
                            break;
                        case 2:
                            thirDept = (Neusoft.HISFC.Models.RADT.Location)list[2];
                            break;
                    }
                }
            }
            #endregion

            #region 转科信息
            if (this.firDept != null)
            {
                //firstDept.Text = firDept.Dept.Name;
                txtFirstDept.Tag = firDept.Dept.ID;
                this.dtFirstTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(firDept.User01);
            }
            if (this.secDept != null)
            {
                //deptSecond.Text = this.secDept.Dept.Name;
                txtDeptSecond.Tag = this.secDept.Dept.ID;
                this.dtSecond.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(secDept.User01);
            }
            if (this.thirDept != null)
            {
                //deptThird.Text = this.thirDept.Dept.Name;
                txtDeptThird.Tag = this.thirDept.Dept.ID;
                this.dtThird.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(thirDept.User01);
            }
            #endregion
        }
        #endregion

        #endregion

        #region 从控制面板上获取数据
        /// <summary>
        /// 从控制面板上获取数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int GetInfoFromPanel(Neusoft.HISFC.Models.HealthRecord.Base info)
        {
            System.TimeSpan tt = this.txtDateOut.Value - this.dtDateIn.Value;
            this.txtPiDays.Text = Convert.ToString(tt.Days + 1); 
            //住院流水号
            info.PatientInfo.ID = CaseBase.PatientInfo.ID;
            info.IsHandCraft = CaseBase.IsHandCraft;
            //住院号  病历号
            info.CaseNO = txtCaseNum.Text;
            info.CaseNO = info.CaseNO.PadLeft(10,'0'); 
            //住院号
            info.PatientInfo.PID.PatientNO = CaseBase.PatientInfo.PID.PatientNO;
            //就诊卡号  门诊号
            info.PatientInfo.PID.CardNO = txtClinicNo.Text;
            //姓名
            info.PatientInfo.Name = txtPatientName.Text;
            //曾用名
            //info.Nomen = txtNomen.Text;
            //性别
            if (txtPatientSex.Tag != null)
            {
                info.PatientInfo.Sex.ID = txtPatientSex.Tag;
            }
            else
            {
                info.PatientInfo.Sex.ID = CaseBase.PatientInfo.Sex.ID;
            }
            if (info.PatientInfo.Sex.ID == null)
            {
                info.PatientInfo.Sex.ID = "";
            }
            //生日
            info.PatientInfo.Birthday = dtPatientBirthday.Value;
            //国籍
            if (txtCountry.Tag != null)
            {
                info.PatientInfo.Country.ID = txtCountry.Tag.ToString();
            }
            else
            {
                info.PatientInfo.Country.ID = "";
            }
            //民族 
            if (txtNationality.Tag != null)
            {
                info.PatientInfo.Nationality.ID = txtNationality.Tag.ToString();
            }
            else
            {
                info.PatientInfo.Nationality.ID = "";
            }
            //职业
            if (txtProfession.Tag != null)
            {
                info.PatientInfo.Profession.ID = txtProfession.Tag.ToString();
            }
            else
            {
                info.PatientInfo.Profession.ID = "";
            }
            //血型编码
            info.PatientInfo.BloodType.ID = txtBloodType.Tag;
            //婚姻
            if (txtMaritalStatus.Tag != null)
            {
                info.PatientInfo.MaritalStatus.ID = txtMaritalStatus.Tag;
            }
            else
            {
                info.PatientInfo.MaritalStatus.ID = "";
            }
            //年龄单位
            info.AgeUnit = cmbUnit.Text;
            //年龄
            info.PatientInfo.Age = txtPatientAge.Text;
            if (info.PatientInfo.Age == "")
            {
                info.PatientInfo.Age = "0";
            }
            //身份证号
            info.PatientInfo.IDCard = txtIDNo.Text;
            //入院途径
            //			if( InSource.Tag != null)
            //			{
            //				info.PatientInfo.PVisit.InSource.ID =  InSource.Tag.ToString();
            //			}
            //结算类别号
            if (txtPactKind.Tag != null)
            {
                info.PatientInfo.Pact.PayKind.ID = txtPactKind.Tag.ToString();
                info.PatientInfo.Pact.ID = txtPactKind.Tag.ToString();
            }
            else
            {
                info.PatientInfo.Pact.PayKind.ID = "";
                info.PatientInfo.Pact.ID = "";
            }
            //医保公费号
            info.PatientInfo.SSN = txtSSN.Text;
            //籍贯
            info.PatientInfo.DIST = txtDIST.Text;
            //出生地
            info.PatientInfo.AreaCode = txtAreaCode.Text;
            //家庭住址
            info.PatientInfo.AddressHome = txtAddressHome.Text;
            //家庭电话
            info.PatientInfo.PhoneHome = txtPhoneHome.Text;
            //住址邮编
            info.PatientInfo.HomeZip = txtHomeZip.Text;
            //单位地址
            info.PatientInfo.AddressBusiness = txtAddressBusiness.Text;
            //单位电话
            info.PatientInfo.PhoneBusiness = txtPhoneBusiness.Text;
            //单位邮编
            info.PatientInfo.BusinessZip = txtBusinessZip.Text;
            //联系人名称
            info.PatientInfo.Kin.Name = txtKin.Text;
            //与患者关系
            if (txtRelation.Tag != null)
            {
                info.PatientInfo.Kin.RelationLink = txtRelation.Tag.ToString();
            }
            else
            {
                info.PatientInfo.Kin.RelationLink = "";
            }
            //联系电话
            info.PatientInfo.Kin.RelationPhone = txtLinkmanTel.Text;
            //联系地址
            info.PatientInfo.Kin.RelationAddress = txtLinkmanAdd.Text;
            //门诊诊断医生 ID
            if (txtClinicDocd.Tag != null)
            {
                info.ClinicDoc.ID = txtClinicDocd.Tag.ToString();
            }
            else
            {
                info.ClinicDoc.ID = "";
            }
            //门诊诊断医生姓名
            info.ClinicDoc.Name = txtClinicDocd.Text;
            //转来医院
            //info.ComeFrom = txtComeFrom.Text;
            //入院日期
            info.PatientInfo.PVisit.InTime = dtDateIn.Value;
            //住院次数
            info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(txtInTimes.Text);
            //入院科室代码
            if (txtDeptInHospital.Tag != null)
            {
                info.InDept.ID = txtDeptInHospital.Tag.ToString();
            }
            else
            {
                info.InDept.ID = "";
            }
            //入院科室名称
            info.InDept.Name = txtDeptInHospital.Text;
            //入院来源
            if (txtInAvenue.Tag != null)
            {
                info.PatientInfo.PVisit.InSource.ID = txtInAvenue.Tag.ToString();
                info.PatientInfo.PVisit.InSource.Name = txtInAvenue.Text;
            }
            else
            {
                info.PatientInfo.PVisit.InSource.ID = "";
                info.PatientInfo.PVisit.InSource.Name = "";
            }
            //入院状态
            if (customListBox1.Tag != null)
            {
                info.PatientInfo.PVisit.Circs.ID = customListBox1.Tag.ToString();
                info.PatientInfo.PVisit.Circs.Name = customListBox1.Text.ToString();
            }
            else
            {
                info.PatientInfo.PVisit.Circs.ID = "";
            }
            //确诊日期
            info.DiagDate = txtDiagDate.Value;
            //手术日期
            //			info.OperationDate 
            //出院日期
            info.PatientInfo.PVisit.OutTime = txtDateOut.Value;
            //出院科室代码
            if (txtDeptOut.Tag != null)
            {
                info.OutDept.ID = txtDeptOut.Tag.ToString();
            }
            else
            {
                info.OutDept.ID = "";
            }
            //出院科室名称
            info.OutDept.Name = txtDeptOut.Text;
            //转归代码
            //			info.PatientInfo.PVisit.Zg.ID 
            //确诊天数
            //			info.DiagDays
            //住院天数
            info.InHospitalDays = Neusoft.FrameWork.Function.NConvert.ToInt32(txtPiDays.Text);
            //死亡日期
            //			info.DeadDate = 
            //死亡原因
            //			info.DeadReason
            //尸检
            if (cbBodyCheck.Checked)
            {
                info.CadaverCheck = "1";
            }
            else
            {
                info.CadaverCheck = "0";
            }
            //死亡种类
            //			info.DeadKind 
            //尸体解剖号
            //			info.BodyAnotomize
            //乙肝表面抗原
            if (txtHbsag.Tag != null)
            {
                info.Hbsag = txtHbsag.Tag.ToString();
            }
            else
            {
                info.Hbsag = "";
            }
            //丙肝病毒抗体
            if (txtHcvAb.Tag != null)
            {
                info.HcvAb = txtHcvAb.Tag.ToString();
            }
            else
            {
                info.HcvAb = "";
            }
            //获得性人类免疫缺陷病毒抗体
            if (txtHivAb.Tag != null)
            {
                info.HivAb = txtHivAb.Tag.ToString();
            }
            else
            {
                info.HivAb = "";
            }
            //门急_入院符合
            if (txtCePi.Tag != null)
            {
                info.CePi = txtCePi.Tag.ToString();
            }
            else
            {
                info.CePi = "";
            }
            //入出_院符合
            if (txtPiPo.Tag != null)
            {
                info.PiPo = txtPiPo.Tag.ToString();
            }
            else
            {
                info.PiPo = "";
            }
            //术前_后符合
            if (txtOpbOpa.Tag != null)
            {
                info.OpbOpa = txtOpbOpa.Tag.ToString();
            }
            else
            {
                info.OpbOpa = "";
            }
            //临床_病理符合

            //临床_CT符合
            //临床_MRI符合
            //临床_病理符合
            if (txtClPa.Tag != null)
            {
                info.ClPa = txtClPa.Tag.ToString();
            }
            else
            {
                info.ClPa = "";
            }
            //放射_病理符合
            if (txtFsBl.Tag != null)
            {
                info.FsBl = txtFsBl.Tag.ToString();
            }
            else
            {
                info.FsBl = "";
            }
            //抢救次数
            info.SalvTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(txtSalvTimes.Text.Trim());
            //成功次数
            info.SuccTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(txtSuccTimes.Text.Trim());
            //示教科研
            if (cbTechSerc.Checked)
            {
                info.TechSerc = "1";
            }
            else
            {
                info.TechSerc = "0";
            }
            //是否随诊
            if (cbVisiStat.Checked)
            {
                info.VisiStat = "1";
            }
            else
            {
                info.VisiStat = "0";
            }
            //随访期限 周
            info.VisiPeriodWeek = txtVisiPeriWeek.Text;
            //随访期限 月
            info.VisiPeriodMonth = txtVisiPeriMonth.Text;
            //随访期限 年
            info.VisiPeriodYear = txtVisiPeriYear.Text;
            //院际会诊次数
            info.InconNum = Neusoft.FrameWork.Function.NConvert.ToInt32(txtInconNum.Text.Trim());
            //远程会诊
            info.OutconNum = Neusoft.FrameWork.Function.NConvert.ToInt32(txtOutconNum.Text.Trim());
            //住院医师代码
            if (txtAdmittingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.AdmittingDoctor.ID = txtAdmittingDoctor.Tag.ToString();
                //住院医师姓名
                info.PatientInfo.PVisit.AdmittingDoctor.Name = txtAdmittingDoctor.Text;
            }
            else
            {
                info.PatientInfo.PVisit.AdmittingDoctor.ID = "";
                //住院医师姓名
                info.PatientInfo.PVisit.AdmittingDoctor.Name = "";
            }
            //主治医师代码
            if (txtAttendingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.AttendingDoctor.ID = txtAttendingDoctor.Tag.ToString();
                info.PatientInfo.PVisit.AttendingDoctor.Name = txtAttendingDoctor.Text;
            }
            else
            {
                info.PatientInfo.PVisit.AttendingDoctor.ID = "";
                info.PatientInfo.PVisit.AttendingDoctor.Name = "";
            }
            //主任医师代码
            if (txtConsultingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.ConsultingDoctor.ID = txtConsultingDoctor.Tag.ToString();
                info.PatientInfo.PVisit.ConsultingDoctor.Name = txtConsultingDoctor.Text;
            }
            else
            {
                info.PatientInfo.PVisit.ConsultingDoctor.ID = "";
                info.PatientInfo.PVisit.ConsultingDoctor.Name = "";
            }
            //科主任代码
            //			info.PatientInfo.PVisit.ReferringDoctor.ID
            //进修医师代码
            if (txtRefresherDocd.Tag != null)
            {
                info.RefresherDoc.ID = txtRefresherDocd.Tag.ToString();
                info.RefresherDoc.Name = txtRefresherDocd.Text;
            }
            else
            {
                info.RefresherDoc.ID = "";
                info.RefresherDoc.Name = "";
            }
            //研究生实习医师代码
            if (txtGraDocCode.Tag != null)
            {
                info.GraduateDoc.ID = txtGraDocCode.Tag.ToString();
                info.GraduateDoc.Name = txtGraDocCode.Text.Trim();
            }
            else
            {
                info.GraduateDoc.ID = "";
                info.GraduateDoc.Name = "";
            }
            //实习医师代码
            if (txtPraDocCode.Tag != null)
            {
                info.PatientInfo.PVisit.TempDoctor.ID = txtPraDocCode.Tag.ToString();
                info.PatientInfo.PVisit.TempDoctor.Name = txtPraDocCode.Text.Trim();
            }
            else
            {
                info.PatientInfo.PVisit.TempDoctor.ID = "";
                info.PatientInfo.PVisit.TempDoctor.Name = "";
            }
            //编码员
            if (txtCodingCode.Tag != null)
            {
                info.CodingOper.ID = txtCodingCode.Tag.ToString();
                info.CodingOper.Name = txtCodingCode.Text.Trim();
            }
            else
            {
                info.CodingOper.ID = "";
                info.CodingOper.Name = "";
            }
            //病案质量
            if (txtMrQual.Tag != null)
            {
                info.MrQuality = txtMrQual.Tag.ToString();
            }
            else
            {
                info.MrQuality = "";
            }
            //合格病案
            //			info.MrElig
            //质控医师代码
            if (txtQcDocd.Tag != null)
            {
                info.QcDoc.ID = txtQcDocd.Tag.ToString();
                info.QcDoc.Name = txtQcDocd.Text.Trim();
            }
            else
            {
                info.QcDoc.ID = "";
                info.QcDoc.Name = "";
            }
            //质控护士代码
            if (txtQcNucd.Tag != null)
            {
                info.QcNurse.ID = txtQcNucd.Tag.ToString();
                info.QcNurse.Name = txtQcNucd.Text.Trim();
            }
            else
            {
                info.QcNurse.ID = "";
                info.QcNurse.Name = "";
            }
            //检查时间
            info.CheckDate = txtCheckDate.Value;
            //手术操作治疗检查诊断为本院第一例项目
            if (cbYnFirst.Checked)
            {
                info.YnFirst = "1";
            }
            else
            {
                info.YnFirst = "0";
            }
            //Rh血型(阴阳)
            if (txtRhBlood.Tag != null)
            {
                info.RhBlood = txtRhBlood.Tag.ToString();
            }
            else
            {
                info.RhBlood = "";
            }
            //输血反应（有无）
            if (txtReactionBlood.Tag != null)
            {
                info.ReactionBlood = txtReactionBlood.Tag.ToString();
            }
            else
            {
                info.ReactionBlood = "";
            }
            //红细胞数
            info.BloodRed = txtBloodRed.Text;
            //血小板数
            info.BloodPlatelet = txtBloodPlatelet.Text;
            //血浆数
            info.BodyAnotomize = txtBodyAnotomize.Text;
            //全血数
            info.BloodWhole = txtBloodWhole.Text;
            //其他输血数
            info.BloodOther = txtBloodOther.Text;
            //X光号
            info.XNum = txtXNumb.Text;
            //CT号
            info.CtNum = txtCtNumb.Text;
            //MRI号
            info.MriNum = txtMriNumb.Text;
            // 病理号 
            info.PathNum = txtPathNumb.Text;
            //B超号
            info.DsaNum = txtBC.Text;
            //PET 号
            info.PetNum = txtPETNumb.Text;
            //ECT号
            info.EctNum = txtECTNumb.Text;
            //特级护理时间
            info.SuperNus = Neusoft.FrameWork.Function.NConvert.ToInt32(txtSuperNus.Text);
            //I级护理时间
            info.INus = Neusoft.FrameWork.Function.NConvert.ToInt32(txtINus.Text);
            //II级护理时间
            info.IINus = Neusoft.FrameWork.Function.NConvert.ToInt32(txtIINus.Text);
            //III级护理时间
            info.IIINus = Neusoft.FrameWork.Function.NConvert.ToInt32(txtIIINus.Text);
            //重症监护时间
            info.StrictNuss = Neusoft.FrameWork.Function.NConvert.ToInt32(txtStrictNuss.Text);
            //特殊护理
            info.SpecalNus = Neusoft.FrameWork.Function.NConvert.ToInt32(txtSPecalNus.Text);
            if (txtInputDoc.Tag != null)
            {
                info.OperInfo.ID = txtInputDoc.Tag.ToString();
            }
            else
            {
                info.OperInfo.ID = "";
            }
            //整理员 
            if (txtCoordinate.Tag != null)
            {
                info.PackupMan.ID = txtCoordinate.Tag.ToString();
            }
            else
            {
                info.PackupMan.ID = "";
            }
            if (this.txtOperationCode.Tag != null)
            {
                info.OperationCoding.ID = this.txtOperationCode.Tag.ToString();
            }
            else
            {
                info.OperationCoding.ID = "";
            }
            //单病种 
            if (cbDisease30.Checked)
            {
                info.Disease30 = "1";
            }
            else
            {
                info.Disease30 = "0";
            }
            info.LendStat = "1"; //病案借阅状态 0 为借出 1为在架 
            if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                info.PatientInfo.CaseState = "2";
            }
            else if (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS) //病案室录入病案
            {
                info.PatientInfo.CaseState = "3";
            }
            //是否有并发症
            info.SyndromeFlag = this.ucDiagNoseInput1.GetSyndromeFlag();
            info.InfectionNum = Neusoft.FrameWork.Function.NConvert.ToInt32(txtInfectNum.Text);  //感染次数
            if (this.CaseBase.LendStat == null || this.CaseBase.LendStat == "") //病案借阅状态 
            {
                info.LendStat = "I";
            }
            else
            {
                info.LendStat = this.CaseBase.LendStat;
            }

            //过敏药物1
            if (this.txtPharmacyAllergic1.Tag != null)
            {
                info.FirstAnaphyPharmacy.ID = this.txtPharmacyAllergic1.Tag.ToString();
                info.FirstAnaphyPharmacy.Name = this.txtPharmacyAllergic1.Text;
            }
            else
            {
                info.FirstAnaphyPharmacy.ID = "";
                info.FirstAnaphyPharmacy.Name = "";
            }
            //过敏药物2
            if (this.txtPharmacyAllergic2.Tag != null)
            {
                info.SecondAnaphyPharmacy.ID = this.txtPharmacyAllergic2.Tag.ToString();
                info.SecondAnaphyPharmacy.Name = this.txtPharmacyAllergic2.Text;
            }
            else
            {
                info.SecondAnaphyPharmacy.ID = "";
                info.SecondAnaphyPharmacy.Name = "";
            }
            //感染部位
            if (this.txtInfectionPosition.Tag != null)
            {
                info.InfectionPosition.ID = this.txtInfectionPosition.Tag.ToString();
                info.InfectionPosition.Name = this.txtInfectionPosition.Text;
            }
            else
            {
                info.InfectionPosition.ID = "";
                info.InfectionPosition.Name = "";
            }

            //出院方式
            if (this.txtouttype.Tag != null)
            {
                info.Out_Type = txtouttype.Tag.ToString();
            }
            else
            {
                info.Out_Type = "";
            }
            //治疗方式
            if (this.txtcuretype.Tag != null)
            {
                info.Cure_Type = txtcuretype.Tag.ToString();
            }
            else
            {
                info.Cure_Type = "";
            }
            //自制中药制剂
            if (this.txtchamed.Tag != null)
            {
                info.Use_CHA_Med = txtchamed.Tag.ToString();
            }
            else
            {
                info.Use_CHA_Med = "";
            }
            //抢救方法 
            if (this.txtsavetype.Tag != null)
            {
                info.Save_Type  = txtsavetype.Tag.ToString();
            }
            else
            {
                info.Save_Type = "";
            }
            //是否出现危重
            if (this.txt_ever_S.Tag != null)
            {
                info.Ever_Sickintodeath  = txt_ever_S.Tag.ToString();
            }
            else
            {
                info.Ever_Sickintodeath = "";
            }
            //是否出现急症
            if (this.txt_ever_F.Tag != null)
            {
                info.Ever_Firstaid = txt_ever_F.Tag.ToString();
            }
            else
            {
                info.Ever_Firstaid = "";
            }
            //是否出现疑难情况 
            if (this.txt_ever_D.Tag != null)
            {
                info.Ever_Difficulty  = txt_ever_D.Tag.ToString();
            }
            else
            {
                info.Ever_Difficulty = "";
            }
            //输液反应 
            if (this.txtReactionLIQUID.Tag != null)
            {
                info.ReactionLiquid  = txtReactionLIQUID.Tag.ToString();
            }
            else
            {
                info.ReactionLiquid = "";
            }


            #region 门诊诊断
            //			if( ClinicDiag.Tag != null)
            //			{
            //
            //				if( clinicDiag == null)
            //				{
            //					#region 新加的门诊诊断
            //					clinicDiag = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
            //					clinicDiag.DiagInfo.ICD10.ID = ClinicDiag.Tag.ToString();
            //					clinicDiag.DiagInfo.ICD10.Name = ClinicDiag.Text;
            //					clinicDiag.DiagInfo.Patient.ID = CaseBase.PatientInfo.ID;
            //					if(ClinicDocd.Tag != null||CaseBase.PatientInfo.CaseState == "1")
            //					{
            //						clinicDiag.DiagInfo.Doctor.ID = ClinicDocd.Tag.ToString();
            //						clinicDiag.DiagInfo.Doctor.Name = ClinicDocd.Text;
            //					}
            //					else
            //					{
            //						clinicDiag.DiagInfo.Doctor.ID = baseDml.Operator.ID;
            //						clinicDiag.DiagInfo.Doctor.Name = baseDml.Operator.Name;
            //					}
            //					clinicDiag.Pvisit.Date_In = CaseBase.PatientInfo.PVisit.InTime;
            //					clinicDiag.DiagInfo.DiagType.ID = "14";
            //					clinicDiag.DiagInfo.DiagDate = System.DateTime.Now;
            //					//入院诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
            //					RuDiag = 2 ;
            //					#endregion 
            //				}
            //				else
            //				{
            //					#region 修改的门诊诊断
            //					clinicDiag.DiagInfo.ICD10.ID = ClinicDiag.Tag.ToString();
            //					clinicDiag.DiagInfo.ICD10.Name = ClinicDiag.Text;
            //					clinicDiag.DiagInfo.DiagType.ID = "14";
            //					if(clinicDiag.DiagInfo.Patient.ID == null || clinicDiag.DiagInfo.Patient.ID == "")
            //					{
            //						clinicDiag.DiagInfo.Patient.ID = CaseBase.PatientInfo.ID;
            //					}
            //					if(ClinicDocd.Tag != null)
            //					{
            //						clinicDiag.DiagInfo.Doctor.ID = ClinicDocd.Tag.ToString();
            //						clinicDiag.DiagInfo.Doctor.Name = ClinicDocd.Text;
            //					}
            //					else
            //					{
            //						clinicDiag.DiagInfo.Doctor.ID = baseDml.Operator.ID;
            //						clinicDiag.DiagInfo.Doctor.Name = baseDml.Operator.Name;
            //					}
            //					if(clinicDiag.Pvisit.Date_In == System.DateTime.MinValue )
            //					{
            //						clinicDiag.Pvisit.Date_In = CaseBase.PatientInfo.PVisit.InTime;
            //					}
            //					if(clinicDiag.DiagInfo.DiagDate == System.DateTime.MinValue)
            //					{
            //						clinicDiag.DiagInfo.DiagDate = System.DateTime.Now;
            //					}
            //					//入院诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
            //					RuDiag = 1 ;
            //					#endregion 
            //				}
            //				if(this.frmType == "DOC")
            //				{
            //					clinicDiag.OperType = "1";
            //				}
            //				else if(this.frmType == "CAS")
            //				{
            //					clinicDiag.OperType = "2";
            //				}
            //			}
            //			else  if(ClinicDiag.Tag == null && clinicDiag != null) 
            //			{
            //				RuDiag = 3 ;
            //			}
            //			else
            //			{
            //				RuDiag = 0 ;
            //			}
            #endregion
            #region 入院诊断
            //			if(RuyuanDiagNose.Tag != null) //有入院诊断
            //			{
            //				if(InDiag == null||CaseBase.PatientInfo.CaseState =="1")
            //				{
            //					#region 新加的入院诊断
            //					InDiag = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
            //					InDiag.DiagInfo.ICD10.ID = RuyuanDiagNose.Tag.ToString();
            //					InDiag.DiagInfo.ICD10.Name = RuyuanDiagNose.Text;
            //					InDiag.DiagInfo.Patient.ID = CaseBase.PatientInfo.ID;
            //					InDiag.DiagInfo.Doctor.ID = baseDml.Operator.ID;
            //					InDiag.DiagInfo.Doctor.Name = baseDml.Operator.Name;
            //					InDiag.Pvisit.Date_In = CaseBase.PatientInfo.PVisit.InTime;
            //					InDiag.DiagInfo.DiagType.ID = "1";
            //					InDiag.DiagInfo.DiagDate = System.DateTime.Now;
            //
            //					menDiag = 2;
            //					#endregion 
            //				}
            //				else
            //				{
            //					#region 修改的入院诊断
            //					InDiag.DiagInfo.ICD10.ID = RuyuanDiagNose.Tag.ToString();
            //					InDiag.DiagInfo.ICD10.Name = RuyuanDiagNose.Text.ToString();
            //					InDiag.DiagInfo.DiagType.ID = "1";
            //					if( InDiag.DiagInfo.Patient.ID == null ||InDiag.DiagInfo.Patient.ID == "")
            //					{
            //						InDiag.DiagInfo.Patient.ID = CaseBase.PatientInfo.ID;
            //					}
            //					if(InDiag.DiagInfo.Doctor.ID == null || InDiag.DiagInfo.Doctor.ID == "")
            //					{
            //						InDiag.DiagInfo.Doctor.ID = baseDml.Operator.ID;
            //					}
            //					if(InDiag.DiagInfo.Doctor.Name == null || InDiag.DiagInfo.Doctor.Name == "")
            //					{
            //						InDiag.DiagInfo.Doctor.Name = baseDml.Operator.Name;
            //					}
            //					if(InDiag.Pvisit.Date_In  == System.DateTime.MinValue)
            //					{
            //						InDiag.Pvisit.Date_In = CaseBase.PatientInfo.PVisit.InTime;
            //					}
            //					if(InDiag.DiagInfo.DiagDate == System.DateTime.MinValue)
            //					{
            //						InDiag.DiagInfo.DiagDate = System.DateTime.Now;
            //					}
            //
            //					menDiag = 1;
            //					#endregion 
            //				}
            //				if(this.frmType == "DOC")
            //				{
            //					InDiag.OperType = "1";
            //				}
            //				else if(this.frmType == "CAS")
            //				{
            //					InDiag.OperType = "2";
            //				}
            //			}
            //			else  if(RuyuanDiagNose.Tag == null && InDiag != null) 
            //			{
            //				menDiag = 3;
            //			}
            //			else
            //			{
            //				menDiag = 0;
            //			}
            #endregion
            return 0;
        }
        #endregion

        #region 根据住院流水号 加载病案信息
        /// <summary>
        /// 根据传入的病人信息的病案状态,加载病案信息 
        /// </summary>
        /// <param name="InpatientNo">病人住院流水号</param>
        /// <param name="Type">类型</param>
        /// <returns>-1 程序出错,或传入的病人信息为空 0 病人不允许有病案 1 手工录入信息 </returns>
        public int LoadInfo(string InpatientNo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes Type)
        {
            try
            {
                if (InpatientNo == null || InpatientNo == "")
                {
                    MessageBox.Show("传入的住院流水号为空");
                    return -1;
                }
                Neusoft.HISFC.BizProcess.Integrate.RADT pa = new Neusoft.HISFC.BizProcess.Integrate.RADT();
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                CaseBase = baseDml.GetCaseBaseInfo(InpatientNo);

                if (CaseBase == null)
                {
                    CaseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
                    CaseBase.PatientInfo.ID = InpatientNo;
                }

                //1. 如果病案表中没有信息 则去住院表中去查询
                //2. 如果 住院主表中有记录则提取信息 写到界面上. 
                if (CaseBase.PatientInfo.ID == "" || CaseBase.OperInfo.OperTime == DateTime.MinValue)//病案主表中没有记录
                {
                    #region 病案中没有记录
                    patientInfo = pa.QueryPatientInfoByInpatientNO(InpatientNo);
                    if (patientInfo.ID == "") //住院主表中也没有相关基本信息
                    {
                        MessageBox.Show("没有查到相关的病人信息");
                        return 1;
                    }
                    else
                    {
                        CaseBase.PatientInfo = patientInfo; 
                    }
                    #endregion
                } 
                //如果是手工录入病案 可能查询出来的信息都为空 只有传入的InpatientNo 不为空
                this.frmType = Type;
                if (CaseBase.PatientInfo.CaseState == "0")
                {
                    MessageBox.Show("该病人不允许有病案");
                    return 0;
                }
                //保存病案的状态
                CaseFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(CaseBase.PatientInfo.CaseState);

                #region  转科信息
                //保存转科信息的列表
                ArrayList changeDept = new ArrayList();
                //获取转科信息
                changeDept = deptChange.QueryChangeDeptFromShiftApply(CaseBase.PatientInfo.ID, "2");
                firDept = null;
                secDept = null;
                thirDept = null;
                if (changeDept != null)
                {
                    if (changeDept.Count == 0)
                    {
                        changeDept = deptChange.QueryChangeDeptFromShiftApply(CaseBase.PatientInfo.ID, "1");
                    }
                    //加载 
                    LoadChangeDept(changeDept);
                }
                #endregion
                if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC) // 医生站录入病历
                {
                    #region  医生站录入病历

                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (CaseBase.PatientInfo.CaseState == "1" || CaseBase.PatientInfo.CaseState == null)
                    {
                        //从住院主表中获取信息 并显示在界面上 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    // 医生站录入过病历 
                    else if (CaseBase.PatientInfo.CaseState == "2")
                    {
                        //从病案基本表中获取信息 并显示在界面上 
                        CaseBase = baseDml.GetCaseBaseInfo(CaseBase.PatientInfo.ID);
                        CaseBase.PatientInfo.CaseState = CaseFlag.ToString();
                        if (CaseBase == null)
                        {
                            MessageBox.Show("查询病案失败" + baseDml.Err);
                            return -1;
                        }
                        //填充数据 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else
                    {
                        // 病案已经封存已经不允许医生修改
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(true);
                    }

                    #endregion
                }
                else if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)//病案室录入病历
                {
                    #region 病案室录入病历
                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (CaseBase.PatientInfo.CaseState == "1" || CaseBase.PatientInfo.CaseState == null)
                    {
                        //从住院主表中获取信息 并显示在界面上 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if (CaseBase.PatientInfo.CaseState == "2" || CaseBase.PatientInfo.CaseState == "3")
                    {
                        //					//医生站已经录入病案
                        ////					list = diag.QueryCaseDiagnose(patientInfo.ID,"%","1");
                        //				}
                        //				else if( patientInfo.Patient.CaseState == "3")
                        //				{
                        //从病案基本表中获取信息 并显示在界面上 
                        CaseBase = baseDml.GetCaseBaseInfo(CaseBase.PatientInfo.ID);
                        CaseBase.PatientInfo.CaseState = CaseFlag.ToString();
                        if (CaseBase == null)
                        {
                            MessageBox.Show("查询病案失败" + baseDml.Err);
                            return -1;
                        }
                        //填充数据 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if ((CaseBase.PatientInfo.CaseState == "" || CaseBase.PatientInfo.CaseState == null) && CaseBase.IsHandCraft == "1")
                    {
                        //填充数据
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if (CaseBase.PatientInfo.CaseState == "4")
                    {
                        //病案已经封存 不允许修改。
                        //					MessageBox.Show("病案已经封存,不允许修改");
                        ConvertInfoToPanel(CaseBase);
                        this.SetReadOnly(true); //设为只读 
                    }

                    #endregion
                }
                else
                {
                    //没有传入参数 不作任何处理
                }
                #region 诊断
                this.ucDiagNoseInput1.LoadInfo(CaseBase.PatientInfo, frmType);
                LoadDiag(this.ucDiagNoseInput1.diagList);
                #endregion
                #region  妇婴卡
                this.ucBabyCardInput1.LoadInfo(CaseBase.PatientInfo);
                #endregion
                #region 手术
                this.ucOperation1.LoadInfo(CaseBase.PatientInfo, frmType);
                #endregion
                #region  肿瘤
                this.ucTumourCard2.LoadInfo(CaseBase.PatientInfo, frmType);
                #endregion
                #region 转科
                this.ucChangeDept1.LoadInfo(CaseBase.PatientInfo, changeDept);
                #endregion
                #region  费用
                if (CaseBase.IsHandCraft == "1") //手工录入病案
                {
                    //金额可以修改
                    this.ucFeeInfo1.BoolType = true;
                }
                else
                {
                    //金额可以修改
                    this.ucFeeInfo1.BoolType = false;
                }
                this.ucFeeInfo1.LoadInfo(CaseBase.PatientInfo);
                #endregion
                //显示基本信息
                this.tab1.SelectedIndex = 0;
                ////住院号
                //this.txtPatientNOSearch.Focus();
                return 1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        void ucPatient_SelectItem(Neusoft.HISFC.Models.HealthRecord.Base HealthRecord)
        {
            LoadInfo(HealthRecord.PatientInfo.ID, this.frmType);
        }
        #endregion

        #region 私有事件
        private void txtCaseNum_Leave(object sender, EventArgs e)
        {
            if (txtCaseNum.Text.Trim() == "")
            {
                return;
            }
            this.txtCaseNum.Text = txtCaseNum.Text.Trim().PadLeft(10, '0');
        }
        private void deptThird_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInfectionPosition.Focus();
            }
        }
        private void pactKind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInTimes.Focus();
            }
        }
        private void deptOut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPiDays.Focus();
            }
        }
        private void patientBirthday_ValueChanged(object sender, System.EventArgs e)
        {
            if (dtPatientBirthday.Value > System.DateTime.Now)
            {
                dtPatientBirthday.Value = System.DateTime.Now;
            }
            if (dtPatientBirthday.Value.Year == System.DateTime.Now.Year)
            {
                if (dtPatientBirthday.Value.Month == System.DateTime.Now.Month)
                {
                    System.TimeSpan span = System.DateTime.Now - dtPatientBirthday.Value;
                    if (span.Days != 0) //天
                    {
                        txtPatientAge.Text = span.Days.ToString();
                        cmbUnit.Text = "天";
                    }
                    else
                    {
                        txtPatientAge.Text = span.Hours.ToString();
                        cmbUnit.Text = "小时";
                    }
                }
                else //月
                {
                    txtPatientAge.Text = Convert.ToString(System.DateTime.Now.Month - dtPatientBirthday.Value.Month);
                    cmbUnit.Text = "月";
                }
            }
            else //岁
            {
                txtPatientAge.Text = Convert.ToString(System.DateTime.Now.Year - dtPatientBirthday.Value.Year);
                cmbUnit.Text = "岁";
            }
        }
        private void txtPatientNOSearch_Enter(object sender, EventArgs e)
        {
            this.ucPatient.Location = new Point(this.txtPatientNOSearch.Location.X, this.txtPatientNOSearch.Location.Y + this.txtPatientNOSearch.Height + 2);
            this.ucPatient.BringToFront();
            this.ucPatient.Visible = false;
        }
        private void txtCaseNOSearch_Enter(object sender, EventArgs e)
        {
            this.ucPatient.Location = new Point(this.txtCaseNOSearch.Location.X, this.txtCaseNOSearch.Location.Y + this.txtCaseNOSearch.Height + 2);
            this.ucPatient.BringToFront();
            this.ucPatient.Visible = false;
        }
        private void Date_Out_ValueChanged(object sender, System.EventArgs e)
        {
            if (txtDateOut.Value < this.dtDateIn.Value)
            {
                txtDateOut.Value = dtDateIn.Value;
            }
        }

        #endregion

        #region 回车事件
        private void txtBC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtECTNumb.Focus();
            }
        }
        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaritalStatus.Focus();
            }
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
            if (this.label1.Text == "病 案 号")
            {
                label1.Text = "住 院 号";
            }
            else if (this.label1.Text == "住 院 号")
            {
                label1.Text = "病 案 号";
            }
        }
        private void caseNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPatientName.Focus();
            }
            else if (e.KeyData == Keys.Divide)
            {
                return;
            }
        }
        private void InTimes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCaseNum.Focus();
            }
        }

        private void SSN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtClinicNo.Focus();
            }
        }

        private void PatientName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPatientSex.Focus();
            }
        }

        private void clinicNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPatientName.Focus();
            }
        }

        private void patientBirthday_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.patientBirthday_ValueChanged(sender, e);
                this.txtPatientAge.Focus();
            }
        }

        private void PatientAge_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cmbUnit.Focus();
            }
        }

        private void DIST_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtIDNo.Focus();
            }
        }

        private void IDNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAddressBusiness.Focus();
            }
        }
        private void BusinessZip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAddressHome.Focus();
            }
        }

        private void PhoneBusiness_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBusinessZip.Focus();
            }
        }

        private void AddressHome_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtHomeZip.Focus();
            }
        }
        private void HomeZip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtKin.Focus();
            }
        }
        private void AddressBusiness_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPhoneBusiness.Focus();
            }
        }

        private void PhoneHome_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtKin.Focus();
            }
        }

        private void Kin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtRelation.Focus();
            }
        }

        private void LinkmanTel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dtDateIn.Focus();
            }
        }

        private void LinkmanAdd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtLinkmanTel.Focus();

            }
        }
        private void txtNomen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtDateIn.Focus();
            }
        }
        private void Date_In_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //				System.TimeSpan tt = this.Date_Out.Value - this.Date_In.Value;
                //				this.PiDays.Text = Convert.ToString(tt.Days+1);
                this.txtDeptInHospital.Focus();
            }
        }
        private void dateTimePicker3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtFirstDept.Focus();
            }
        }

        private void dateTimePicker4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDeptSecond.Focus();
            }
        }

        private void dtThird_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDeptThird.Focus();
            }
        }

        private void Date_Out_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //				System.TimeSpan tt = this.Date_Out.Value - this.Date_In.Value;
                //				this.PiDays.Text = Convert.ToString(tt.Days+1);
                this.txtDeptOut.Focus();
            }
        }
        
        private void PiDays_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.customListBox1.Focus();
            }
        }

        private void ComeFrom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dtFirstTime.Focus();
            }
        }

        private void Nomen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInAvenue.Focus();
            }
        }

        private void infectNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPharmacyAllergic1.Focus();
            }
        }

        private void CheckDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtMrQual.Focus();
            }
        }

        private void YnFirst_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.NumPad1)
            {
                cbYnFirst.Checked = !cbYnFirst.Checked;
                this.cbVisiStat.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                this.cbVisiStat.Focus();
            }
        }

        private void VisiStat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.NumPad1)
            {
                cbVisiStat.Checked = !cbVisiStat.Checked;
                this.txtVisiPeriWeek.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriWeek.Focus();
            }
        }

        private void VisiPeriWeek_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriMonth.Focus();
            }
        }

        private void VisiPeriMonth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriYear.Focus();
            }
        }

        private void VisiPeriYear_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbTechSerc.Focus();
            }
        }

        private void TechSerc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.NumPad1)
            {
                cbTechSerc.Checked = !cbTechSerc.Checked;
                this.cbDisease30.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                this.cbDisease30.Focus();
            }
        }

        private void BloodRed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtBloodPlatelet.Focus();
            }
        }

        private void BloodPlatelet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtBodyAnotomize.Focus();
            }
        }

        private void BodyAnotomize_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodWhole.Focus();
            }
        }

        private void BloodWhole_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodOther.Focus();
            }
        }

        private void BloodOther_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInconNum.Focus();
            }
        }

        private void InconNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtOutconNum.Focus();
            }
        }

        private void outOutconNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSuperNus.Focus();
            }
        }

        private void SuperNus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtINus.Focus();
            }
        }

        private void INus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtIINus.Focus();
            }
        }

        private void IINus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtIIINus.Focus();
            }
        }

        private void IIINus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtStrictNuss.Focus();
            }
        }

        private void StrictNuss_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSPecalNus.Focus();
            }
        }

        private void SPecalNus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCheckDate.Focus();
            }
        }

        private void CtNumb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtPathNumb.Focus();
            }
        }

        private void textBox54_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtMriNumb.Focus();
            }
        }

        private void MriNumb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtXNumb.Focus();
            }
        }

        private void XNumb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBC.Focus();
            }
        }

        private void checkBox9_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInputDoc.Focus();
            }
        }

        private void SalvTimes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSuccTimes.Focus();
            }
        }

        private void SuccTimes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //this.txtClinicDocd.Focus();
                this.txtsavetype.Focus();
            }
        }

        private void txtsavetype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txt_ever_S.Focus();
            }

        }

        private void txt_ever_S_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txt_ever_F.Focus();
            }
        }

        private void txt_ever_F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txt_ever_D.Focus();
            }
        }

        private void txt_ever_D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtClinicDocd.Focus(); 
            }
        }

        private void BodyCheck_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbYnFirst.Focus();
            }
            else if (e.KeyData == Keys.NumPad1)
            {
                this.cbBodyCheck.Checked = !this.cbBodyCheck.Checked;
                this.cbYnFirst.Focus();
            }
        }

        private void checkBox8_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodType.Focus();
            }
            else if (e.KeyData == Keys.NumPad1)
            {
                this.cbBodyCheck.Checked = !this.cbBodyCheck.Checked;
                this.txtBloodType.Focus();
            }
        }

        private void Date_In_Leave(object sender, System.EventArgs e)
        {
            System.TimeSpan tt = this.txtDateOut.Value - this.dtDateIn.Value;
            this.txtPiDays.Text = Convert.ToString(tt.Days + 1);
        }

        private void Date_Out_Leave(object sender, System.EventArgs e)
        {
            System.TimeSpan tt = this.txtDateOut.Value - this.dtDateIn.Value;
            this.txtPiDays.Text = Convert.ToString(tt.Days + 1);
        }
        private void OperationCOde_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInputDoc.Focus();
            }
        }

        private void txtInfectionPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.txtDiagDate.Focus();
                this.txtPharmacyAllergic1.Focus();
            }
        }

        private void txtPharmacyAllergic1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPharmacyAllergic2.Focus();
            }

        }
        private void customListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtouttype.Focus();
            }
            //this.ucBabyCardInput1.Focus();
            //this.ucDiagNoseInput1.AddRow();
        }

        private void txtouttype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtcuretype.Focus();
            }
        }

        private void txtcuretype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtchamed.Focus();
            }
        }

        private void txtchamed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDiagDate.Focus();
            }
        }

        private void DiagDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //this.txtPharmacyAllergic1.Focus();
                this.ucBabyCardInput1.Focus();
                this.ucDiagNoseInput1.AddRow();
            }
        }

        private void txtMriNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPathNumb.Focus();
            }
        }

        private void txtPathNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCtNumb.Focus();
            }
        }

        private void txtCtNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBC.Focus();
            }
        }

        private void txtBC_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDeathreason.Focus();
            }
        }

        private void txtDeathreason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbBodyCheck.Focus();
            }
        }

        private void cbBodyCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dt_death.Focus();
            }
        }

        private void dt_death_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbVisiStat.Focus();
            }
        }

        private void cbYnFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodType.Focus();
            }
        }

        private void txtBloodType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtRhBlood.Focus();
            }
        }

        private void txtRhBlood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtReactionBlood.Focus();
            }
        }

        private void txtReactionBlood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtReactionLIQUID.Focus();
            }
        }

        private void txtReactionLIQUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbYnFirst.Focus();
            }
        }

        private void cbVisiStat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriWeek.Focus();
            }
        }

        private void txtVisiPeriWeek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriMonth.Focus();
            }
        }

        private void txtVisiPeriMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtVisiPeriYear.Focus();
            }
        }

        private void txtVisiPeriYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbTechSerc.Focus();
            }
        }

        private void cbTechSerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodRed.Focus();
            }
        }

        private void txtBloodRed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodPlatelet.Focus();
            }
        }

        private void txtBloodPlatelet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBodyAnotomize.Focus();
            }
        }

        private void txtBodyAnotomize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodWhole.Focus();
            }
        }

        private void txtBloodWhole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBloodOther.Focus();
            }
        }

        private void txtBloodOther_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtPharmacyAllergic2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtHbsag.Focus();
            }

        }

        private void txtECTNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPETNumb.Focus();
            }
        }

        private void txtPETNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbBodyCheck.Focus();
            }
        }

        #endregion

        #region 重载 捕获键盘
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Divide)
            {
                if (this.tab1.SelectedIndex != 6)
                {
                    this.tab1.SelectedIndex++;
                }
                else
                {
                    this.tab1.SelectedIndex = 0;
                }
            }
            else if (keyData == Keys.Escape)
            {
                this.ucPatient.Visible = false;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 加载 入院诊断和门诊诊断
        /// <summary>
        /// 加载 入院诊断和门诊诊断
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private int LoadDiag(ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            clinicDiag = null;
            InDiag = null;
            #region 先默认输入一个门诊主诊断
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.DiagType.ID == "10" && obj.DiagInfo.IsMain)
                {	//门诊诊断 
                    this.txtClinicDiag.Tag = obj.DiagInfo.ICD10.ID;
                    this.txtClinicDiag.Text = obj.DiagInfo.ICD10.Name;
                    this.txtClinicDocd.Tag = obj.DiagInfo.Doctor.ID;
                    this.txtClinicDocd.Text = obj.DiagInfo.Doctor.Name;
                    clinicDiag = obj;
                }
                else if (obj.DiagInfo.DiagType.ID == "11" && obj.DiagInfo.IsMain)
                {	//入院诊断
                    txtRuyuanDiagNose.Tag = obj.DiagInfo.ICD10.ID;
                    txtRuyuanDiagNose.Text = obj.DiagInfo.ICD10.Name;
                    InDiag = obj;
                }
            }
            #endregion

            #region 如果没有主诊断 则输入非主诊断诊断
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.DiagType.ID == "10")
                {	//门诊诊断 
                    if (this.txtClinicDiag.Tag == null)
                    {
                        this.txtClinicDiag.Tag = obj.DiagInfo.ICD10.ID;
                        this.txtClinicDiag.Text = obj.DiagInfo.ICD10.Name;
                        this.txtClinicDocd.Tag = obj.DiagInfo.Doctor.ID;
                        this.txtClinicDocd.Text = obj.DiagInfo.Doctor.Name;
                        clinicDiag = obj;
                    }
                }
                else if (obj.DiagInfo.DiagType.ID == "11")
                {	//入院诊断
                    if (txtRuyuanDiagNose.Tag == null)
                    {
                        txtRuyuanDiagNose.Tag = obj.DiagInfo.ICD10.ID;
                        txtRuyuanDiagNose.Text = obj.DiagInfo.ICD10.Name;
                        InDiag = obj;
                    }
                }
            }
            #endregion
            return 0;
        }
        #endregion

        #region 检验数据的合法性
        /// <summary>
        /// 检验数据的合法性
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ValidState(Neusoft.HISFC.Models.HealthRecord.Base info)
        {
            #region  校验  
            if (txtDeptInHospital.Text == "" && txtDeptOut.Text != "")
            {
                MessageBox.Show("请先填写出院科室信息");
                txtDeptOut.Focus();
                return -1;
            }
            if (txtDeptInHospital.Text == "" && txtFirstDept.Text != "")
            {
                MessageBox.Show("请先填写入院科室信息");
                txtDeptInHospital.Focus();
                return -1;
            }
            if (txtFirstDept.Text == "" && txtDeptSecond.Text != "")
            {
                MessageBox.Show("请先填写第一次转科信息");
                txtFirstDept.Focus();
                return -1;
            }
            if (txtDeptSecond.Text == "" && txtDeptThird.Text != "")
            {
                MessageBox.Show("请先填写第二次转科信息");
                txtDeptSecond.Focus();
            }
            if (dtFirstTime.Value > dtSecond.Value)
            {
                MessageBox.Show("第一次转科时间不能大于第二次转科时间");
                dtFirstTime.Focus();
                return -1; 
            }
            if (dtFirstTime.Value  < this.dtDateIn.Value)
            {
                MessageBox.Show("第一次转科时间不能小于入院时间");
                dtFirstTime.Focus();
                return -1; 
            }　
            if (dtSecond.Value > dtThird.Value)
            {
                MessageBox.Show("第二次转科时间不能大于第三次转科时间");
                dtSecond.Focus();
                return -1; 
            }
            #endregion 
            if (!ValidMaxLengh(info.PatientInfo.ID, 14))
            {
                MessageBox.Show("住院流水号过长");
                return -1;
            }
            //if (!ValidMaxLengh(info.PatientInfo.PID.PatientNO, 10))
            //{
            //    txtCaseNum.Focus();
            //    MessageBox.Show("住院号过长");
            //    return -1;
            //}
            if (!ValidMaxLengh(info.CaseNO, 10))
            {
                txtCaseNum.Focus();
                MessageBox.Show("病案号过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.PID.CardNO, 10))
            {
                txtClinicNo.Focus();
                MessageBox.Show("就诊卡号过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.SSN, 18))
            {
                txtSSN.Focus();
                MessageBox.Show("医保号过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.PID.CardNO, 10))
            {
                txtSSN.Focus();
                MessageBox.Show("卡号过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Name, 20))
            {
                txtPatientName.Focus();
                MessageBox.Show("姓名过长");
                return -1;
            }
            if (!ValidMaxLengh(info.Nomen, 20))
            {
                //txtNomen.Focus();
                MessageBox.Show("曾用名过长");
                return -1;
            }
            if (info.PatientInfo.Sex.ID != null)
            {
                if (!ValidMaxLengh(info.PatientInfo.Sex.ID.ToString(), 20))
                {
                    txtPatientSex.Focus();
                    MessageBox.Show("性别编码过长");
                    return -1;
                }
            }
            if (!ValidMaxLengh(info.PatientInfo.Country.ID, 20))
            {
                txtCountry.Focus();
                MessageBox.Show("国籍编码过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.Nationality.ID, 20))
            {
                txtNationality.Focus();
                MessageBox.Show("民族编码过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Profession.ID, 20))
            {
                txtProfession.Focus();
                MessageBox.Show("职业编码过长");
                return -1;
            }
            if (info.PatientInfo.BloodType.ID != null)
            {
                if (!ValidMaxLengh(info.PatientInfo.BloodType.ID.ToString(), 20))
                {
                    txtBloodType.Focus();
                    MessageBox.Show("血型编码过长");
                    return -1;
                }
            }
            if (info.PatientInfo.MaritalStatus.ID != null)
            {
                if (!ValidMaxLengh(info.PatientInfo.MaritalStatus.ID.ToString(), 10))
                {
                    txtMaritalStatus.Focus();
                    MessageBox.Show("婚姻编码过长");
                    return -1;
                }
            }
            if (info.AgeUnit != null)
            {
                if (!ValidMaxLengh(info.AgeUnit, 10))
                {
                    txtPatientAge.Focus();
                    MessageBox.Show("年龄单位过长");
                    return -1;
                }
            }

            if (!ValidMaxLengh(info.PatientInfo.Age, 3))
            {
                txtPatientAge.Focus();
                MessageBox.Show("年龄过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.IDCard, 18))
            {
                txtIDNo.Focus();
                MessageBox.Show("身份证过长");
                return -1;
            }
            //			if(info.PatientInfo.PVisit.InSource.ID.Length  > 1 )
            //			{
            //				In.Focus();
            //				MessageBox.Show("地区来源编码过长");
            //				return -1;
            //			} 
            if (!ValidMaxLengh(info.PatientInfo.Pact.PayKind.ID, 20))
            {
                txtPactKind.Focus();
                MessageBox.Show("结算类别编码过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.Pact.ID, 20))
            {
                txtPactKind.Focus();
                MessageBox.Show("合同单位编码过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.SSN, 18))
            {
                txtSSN.Focus();
                MessageBox.Show("医保公费号过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.DIST, 50))
            {
                txtDIST.Focus();
                MessageBox.Show("籍贯过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.AddressHome, 50))
            {
                txtAddressHome.Focus();
                MessageBox.Show("家庭住址过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.PhoneHome, 25))
            {
                txtPhoneHome.Focus();
                MessageBox.Show("家庭电话过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.HomeZip, 25))
            {
                txtHomeZip.Focus();
                MessageBox.Show("住址邮编过长");
                return -1;
            }

            if (!ValidMaxLengh(info.PatientInfo.AddressBusiness, 50))
            {
                txtAddressBusiness.Focus();
                MessageBox.Show("单位地址过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.PhoneBusiness, 25))
            {
                txtPhoneBusiness.Focus();
                MessageBox.Show("单位电话过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.BusinessZip, 6))
            {
                txtBusinessZip.Focus();
                MessageBox.Show("单位邮编过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Kin.Name, 10))
            {
                txtKin.Focus();
                MessageBox.Show("联系人过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Kin.RelationLink, 20))
            {
                txtRelation.Focus();
                MessageBox.Show("联系人关系过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Kin.RelationAddress, 50))
            {
                txtLinkmanAdd.Focus();
                MessageBox.Show("联系地址过长");
                return -1;
            }
            if (!ValidMaxLengh(info.PatientInfo.Kin.RelationPhone, 25))
            {
                txtLinkmanTel.Focus();
                MessageBox.Show("联系电话过长");
                return -1;
            }
            if (!ValidMaxLengh(info.ComeFrom, 100))
            {
                //txtComeFrom.Focus();
                MessageBox.Show("转来医院");
                return -1;
            }
            if (info.PatientInfo.InTimes > 99)
            {
                //txtComeFrom.Focus();
                MessageBox.Show("入院次数过大");
                return -1;
            }
            if (info.SalvTimes > 99)
            {
                txtSalvTimes.Focus();
                MessageBox.Show("抢救次数过大");
                return -1;
            }
            if (info.InfectionNum > 99)
            {
                txtInfectNum.Focus();
                MessageBox.Show("成功次数过大");
                return -1;
            }
            if (!ValidMaxLengh(info.VisiPeriodWeek, 6))
            {
                txtVisiPeriWeek.Focus();
                MessageBox.Show("诊断期限周数过长");
                return -1;
            }
            if (!ValidMaxLengh(info.VisiPeriodMonth, 6))
            {
                txtVisiPeriMonth.Focus();
                MessageBox.Show("诊断期限月数过长");
                return -1;
            }
            if (!ValidMaxLengh(info.VisiPeriodYear, 6))
            {
                txtVisiPeriYear.Focus();
                MessageBox.Show("诊断期限年数过长");
                return -1;
            }
            if (!ValidMaxLengh(info.BloodRed, 10))
            {
                txtBloodRed.Focus();
                MessageBox.Show("红细胞数量过大");
                return -1;
            }
            if (!ValidMaxLengh(info.BloodPlatelet, 10))
            {
                txtBloodPlatelet.Focus();
                MessageBox.Show("血小板数量过大");
                return -1;
            }
            if (!ValidMaxLengh(info.BloodPlasma, 10))
            {
                txtBodyAnotomize.Focus();
                MessageBox.Show("血浆数量过大");
                return -1;
            }
            if (!ValidMaxLengh(info.BloodWhole, 10))
            {
                txtBloodWhole.Focus();
                MessageBox.Show("全血数量过大");
                return -1;
            }
            if (!ValidMaxLengh(info.BloodOther, 10))
            {
                txtBloodOther.Focus();
                MessageBox.Show("其他输血数量过大");
                return -1;
            }
            if (info.InconNum > 99)
            {
                txtInconNum.Focus();
                MessageBox.Show("院际会诊次数过大");
                return -1;
            }
            if (info.OutconNum > 99)
            {
                txtOutconNum.Focus();
                MessageBox.Show("远程次数数量过大");
                return -1;
            }
            if (info.SpecalNus > 9999)
            {
                txtSuperNus.Focus();
                MessageBox.Show("特殊护理数量过大");
                return -1;
            }
            if (info.INus > 9999)
            {
                txtINus.Focus();
                MessageBox.Show("I级护理时间数量过大");
                return -1;
            }
            if (info.IINus > 9999)
            {
                txtIINus.Focus();
                MessageBox.Show("II级护理时间数量过大");
                return -1;
            }
            if (info.IIINus > 9999)
            {
                txtIIINus.Focus();
                MessageBox.Show("III级护理时间数量过大");
                return -1;
            }
            if (info.StrictNuss > 9999)
            {
                txtStrictNuss.Focus();
                MessageBox.Show("重症监护时间数量过大");
                return -1;
            }
            if (info.SuperNus > 9999)
            {
                txtSuperNus.Focus();
                MessageBox.Show("特级护理时间数量过大");
                return -1;
            }
            if (!ValidMaxLengh(info.CtNum, 10))
            {
                txtCtNumb.Focus();
                MessageBox.Show("CT号过大");
                return -1;
            }
            if (!ValidMaxLengh(info.XNum, 10))
            {
                txtXNumb.Focus();
                MessageBox.Show("X光号过大");
                return -1;
            }
            if (!ValidMaxLengh(info.MriNum, 10))
            {
                txtMriNumb.Focus();
                MessageBox.Show("M R 号过大");
                return -1;
            }
            if (!ValidMaxLengh(info.PathNum, 10))
            {
                txtPathNumb.Focus();
                MessageBox.Show("UFCT 号过大");
                return -1;
            }
            return 1;
        }
        #region 获取最大值
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool ValidMaxLengh(string str, int length)
        {
            return Neusoft.FrameWork.Public.String.ValidMaxLengh(str, length);
        }
        #endregion
        #endregion

        #region 设置为只读
        /// <summary>
        /// 设置为只读
        /// </summary>
        /// <param name="type"></param> 
        public void SetReadOnly(bool type)
        {
            this.ucDiagNoseInput1.SetReadOnly(type);
            this.ucOperation1.SetReadOnly(type);
            this.ucTumourCard2.SetReadOnly(type);
            this.ucChangeDept1.SetReadOnly(type);
            this.ucBabyCardInput1.SetReadOnly(type);
            //病案号 
            txtCaseNum.ReadOnly = type;
            txtCaseNum.BackColor = System.Drawing.Color.White;
            //住院次数
            txtInTimes.ReadOnly = type;
            txtInTimes.BackColor = System.Drawing.Color.White;
            //费用类别
            txtPactKind.ReadOnly = type;
            txtPactKind.EnterVisiable = !type;
            txtPactKind.BackColor = System.Drawing.Color.White;
            //医保号
            txtSSN.ReadOnly = type;
            txtSSN.BackColor = System.Drawing.Color.White;
            //门诊号
            txtClinicNo.ReadOnly = type; 
            txtClinicNo.BackColor = System.Drawing.Color.White;
            //姓名
            txtPatientName.ReadOnly = type;
            txtPatientName.BackColor = System.Drawing.Color.White;
            //性别
            txtPatientSex.ReadOnly = type;
            txtPatientSex.EnterVisiable = !type;
            txtPatientSex.BackColor = System.Drawing.Color.White;
            //生日
            dtPatientBirthday.Enabled = !type;
            //年龄
            txtPatientAge.ReadOnly = type; 
            txtPatientAge.BackColor = System.Drawing.Color.White;
            //婚姻
            txtMaritalStatus.ReadOnly = type;
            txtMaritalStatus.EnterVisiable = !type;
            txtMaritalStatus.BackColor = System.Drawing.Color.White;
            //职业
            txtProfession.ReadOnly = type;
            txtProfession.EnterVisiable = !type;
            txtProfession.BackColor = System.Drawing.Color.White;
            //出生地
            txtAreaCode.ReadOnly = type;
            txtAreaCode.BackColor = System.Drawing.Color.White;
            //民族
            txtNationality.ReadOnly = type;
            txtNationality.EnterVisiable = !type;
            txtNationality.BackColor = System.Drawing.Color.White;
            //国籍
            txtCountry.ReadOnly = type;
            txtCountry.EnterVisiable = !type;
            txtCountry.BackColor = System.Drawing.Color.White;
            //籍贯
            txtDIST.ReadOnly = type;
            txtDIST.BackColor = System.Drawing.Color.White;
            //身份证
            txtIDNo.ReadOnly = type;
            txtIDNo.BackColor = System.Drawing.Color.White;
            //工作单位
            txtAddressBusiness.ReadOnly = type;
            txtAddressBusiness.BackColor = System.Drawing.Color.White;
            //单位邮编
            txtBusinessZip.ReadOnly = type;
            txtBusinessZip.BackColor = System.Drawing.Color.White;
            //单位电话
            txtPhoneBusiness.ReadOnly = type;
            txtPhoneBusiness.BackColor = System.Drawing.Color.White;
            //户口地址
            txtAddressHome.ReadOnly = type;
            txtAddressHome.BackColor = System.Drawing.Color.White;
            //户口邮编
            txtHomeZip.ReadOnly = type;
            txtHomeZip.BackColor = System.Drawing.Color.White;
            //家庭电话
            txtPhoneHome.ReadOnly = type;
            txtPhoneHome.BackColor = System.Drawing.Color.White;
            //联系人 
            txtKin.ReadOnly = type;
            txtKin.BackColor = System.Drawing.Color.White;
            //关系
            txtRelation.ReadOnly = type;
            txtRelation.EnterVisiable = !type;
            txtRelation.BackColor = System.Drawing.Color.White;
            //联系电话
            txtLinkmanTel.ReadOnly = type;
            txtLinkmanTel.BackColor = System.Drawing.Color.White;
            //l联系人地址
            txtLinkmanAdd.ReadOnly = type;
            txtLinkmanAdd.BackColor = System.Drawing.Color.White;
            //入院科室
            txtDeptInHospital.ReadOnly = type;
            txtDeptInHospital.EnterVisiable = !type;
            txtDeptInHospital.BackColor = System.Drawing.Color.White;
            //入院时间 
            dtDateIn.Enabled = !type;
            //入院情况
            txtCircs.ReadOnly = type;
            txtCircs.EnterVisiable = !type;
            txtCircs.BackColor = System.Drawing.Color.White;
            //转入科室
            txtFirstDept.ReadOnly = type;
            txtFirstDept.EnterVisiable = !type;
            txtFirstDept.BackColor = System.Drawing.Color.White;
            //转科时间
            dtFirstTime.Enabled = !type;
            dtFirstTime.BackColor = System.Drawing.Color.White;
            //转入科室
            txtDeptSecond.ReadOnly = type;
            txtDeptSecond.EnterVisiable = !type;
            txtDeptSecond.BackColor = System.Drawing.Color.White;
            //转科时间
            dtSecond.Enabled = !type;
            //转入科室
            txtDeptThird.ReadOnly = type;
            txtDeptThird.EnterVisiable = !type;
            txtDeptThird.BackColor = System.Drawing.Color.White;
            //转科时间
            dtThird.Enabled = !type;
            //出院科室
            txtDeptOut.ReadOnly = type;
            txtDeptOut.EnterVisiable = !type;
            txtDeptOut.BackColor = System.Drawing.Color.White;
            //出院时间
            txtDateOut.Enabled = !type;
            //门诊诊断
            //			ClinicDiag.ReadOnly = type;
            txtClinicDiag.BackColor = System.Drawing.Color.Gainsboro;
            //诊断医生
            txtClinicDocd.ReadOnly = type;
            txtClinicDocd.EnterVisiable = !type;
            txtClinicDocd.BackColor = System.Drawing.Color.White;
            //住院天数
            txtPiDays.ReadOnly = type;
            txtPiDays.BackColor = System.Drawing.Color.White;
            //确证时间
            txtDiagDate.Enabled = !type;
            //入院诊断
            //			RuyuanDiagNose.ReadOnly = type;
            txtRuyuanDiagNose.BackColor = System.Drawing.Color.Gainsboro;
            //由何医院转来
            //txtComeFrom.ReadOnly = type;
            //txtComeFrom.BackColor = System.Drawing.Color.White;
            //曾用名
            //txtNomen.ReadOnly = type;
            //txtNomen.BackColor = System.Drawing.Color.White;
            //病人来源
            txtInAvenue.ReadOnly = type;
            txtInAvenue.EnterVisiable = !type;
            txtInAvenue.BackColor = System.Drawing.Color.White;
            //院感次数
            txtInfectNum.ReadOnly = type;
            txtInfectNum.BackColor = System.Drawing.Color.White;
            //hbsag
            txtHbsag.ReadOnly = type;
            txtHbsag.EnterVisiable = !type;
            txtHbsag.BackColor = System.Drawing.Color.White;
            txtHcvAb.ReadOnly = type;
            txtHcvAb.EnterVisiable = !type;
            txtHcvAb.BackColor = System.Drawing.Color.White; 
            //门诊与出院
            txtCePi.ReadOnly = type;
            txtCePi.EnterVisiable = !type;
            txtCePi.BackColor = System.Drawing.Color.White;
            //入院与出院 
            txtPiPo.ReadOnly = type;
            txtPiPo.EnterVisiable = !type;
            txtPiPo.BackColor = System.Drawing.Color.White;
            //术前与术后
            txtOpbOpa.ReadOnly = type;
            txtOpbOpa.EnterVisiable = !type;
            txtOpbOpa.BackColor = System.Drawing.Color.White;
            //临床与病理
            txtClPa.ReadOnly = type;
            txtClPa.EnterVisiable = !type;
            txtClPa.BackColor = System.Drawing.Color.White;
            //放射与病理
            txtFsBl.ReadOnly = type;
            txtFsBl.EnterVisiable = !type;
            txtFsBl.BackColor = System.Drawing.Color.White;
            //抢救次数
            txtSalvTimes.ReadOnly = type;
            txtSalvTimes.BackColor = System.Drawing.Color.White;
            //成功次数
            txtSuccTimes.ReadOnly = type;
            txtSuccTimes.BackColor = System.Drawing.Color.White;
            //病案质量
            txtMrQual.ReadOnly = type;
            txtMrQual.EnterVisiable = !type;
            txtMrQual.BackColor = System.Drawing.Color.White;
            //质控医师
            txtQcDocd.ReadOnly = type;
            txtQcDocd.EnterVisiable = !type;
            txtQcDocd.BackColor = System.Drawing.Color.White;
            //质控护士
            txtQcNucd.ReadOnly = type;
            txtQcNucd.EnterVisiable = !type;
            txtQcNucd.BackColor = System.Drawing.Color.White;
            //主任医师
            txtConsultingDoctor.ReadOnly = type;
            txtConsultingDoctor.EnterVisiable = !type;
            txtConsultingDoctor.BackColor = System.Drawing.Color.White;
            //主治医师
            txtAttendingDoctor.ReadOnly = type;
            txtAttendingDoctor.EnterVisiable = !type;
            txtAttendingDoctor.BackColor = System.Drawing.Color.White;
            //住院医师
            txtAdmittingDoctor.ReadOnly = type;
            txtAdmittingDoctor.EnterVisiable = !type;
            txtAdmittingDoctor.BackColor = System.Drawing.Color.White;
            //进修医师
            txtRefresherDocd.ReadOnly = type;
            txtRefresherDocd.EnterVisiable = !type;
            txtRefresherDocd.BackColor = System.Drawing.Color.White;
            //研究生实习医师
            txtGraDocCode.ReadOnly = type;
            txtGraDocCode.EnterVisiable = !type;
            txtGraDocCode.BackColor = System.Drawing.Color.White;
            //质控时间
            txtCheckDate.Enabled = !type;
            //实习医生
            txtPraDocCode.ReadOnly = type;
            txtPraDocCode.EnterVisiable = !type;
            txtPraDocCode.BackColor = System.Drawing.Color.White;
            //编码员
            txtCodingCode.ReadOnly = type;
            txtCodingCode.EnterVisiable = !type;
            txtCodingCode.BackColor = System.Drawing.Color.White;
            //整理员 
            txtCoordinate.ReadOnly = type;
            txtCoordinate.EnterVisiable = !type;
            txtCoordinate.BackColor = System.Drawing.Color.White;
            this.txtOperationCode.ReadOnly = type;
            txtOperationCode.EnterVisiable = !type;
            this.txtOperationCode.BackColor = System.Drawing.Color.White;
            //尸蹇
            cbBodyCheck.Enabled = !type;
            cmbUnit.Enabled = !type;
            //手术、治疗、检查、诊断、是否本院首例
            cbYnFirst.Enabled = !type;
            //随诊
            cbVisiStat.Enabled = !type;
            //随诊期限
            txtVisiPeriWeek.ReadOnly = type;
            txtVisiPeriWeek.BackColor = System.Drawing.Color.White;
            txtVisiPeriMonth.ReadOnly = type;
            txtVisiPeriMonth.BackColor = System.Drawing.Color.White;
            txtVisiPeriYear.ReadOnly = type;
            txtVisiPeriYear.BackColor = System.Drawing.Color.White;
            //示教病案
            cbTechSerc.Enabled = !type;
            //单病种
            cbDisease30.Enabled = !type;
            //血型
            txtBloodType.ReadOnly = type;
            txtBloodType.EnterVisiable = !type;
            txtBloodType.BackColor = System.Drawing.Color.White;
            txtRhBlood.ReadOnly = type;
            txtRhBlood.EnterVisiable = !type;
            txtRhBlood.BackColor = System.Drawing.Color.White;
            //输血反应
            txtReactionBlood.ReadOnly = type;
            txtReactionBlood.EnterVisiable = !type;
            txtReactionBlood.BackColor = System.Drawing.Color.White;
            //红细胞
            txtBloodRed.ReadOnly = type;
            txtBloodRed.BackColor = System.Drawing.Color.White;
            //血小板
            txtBloodPlatelet.ReadOnly = type;
            txtBloodPlatelet.BackColor = System.Drawing.Color.White;
            //血浆
            txtBodyAnotomize.ReadOnly = type;
            txtBodyAnotomize.BackColor = System.Drawing.Color.White;
            //全血
            txtBloodWhole.ReadOnly = type;
            txtBloodWhole.BackColor = System.Drawing.Color.White;
            //其他
            txtBloodOther.ReadOnly = type;
            txtBloodOther.BackColor = System.Drawing.Color.White;
            //院际会诊
            txtInconNum.ReadOnly = type;
            txtInconNum.BackColor = System.Drawing.Color.White;
            //远程会诊
            txtOutconNum.ReadOnly = type;
            txtOutconNum.BackColor = System.Drawing.Color.White;
            //SuperNus 特级护理
            txtSuperNus.ReadOnly = type;
            txtSuperNus.BackColor = System.Drawing.Color.White;
            //一级护理
            txtINus.ReadOnly = type;
            txtINus.BackColor = System.Drawing.Color.White;
            //二级护理
            txtIINus.ReadOnly = type;
            txtIINus.BackColor = System.Drawing.Color.White;
            //三级护理
            txtIIINus.ReadOnly = type;
            txtIIINus.BackColor = System.Drawing.Color.White;
            //重症监护
            txtStrictNuss.ReadOnly = type;
            txtStrictNuss.BackColor = System.Drawing.Color.White;
            //特殊护理
            txtSPecalNus.ReadOnly = type;
            txtSPecalNus.BackColor = System.Drawing.Color.White;
            //ct
            txtCtNumb.ReadOnly = type;
            txtCtNumb.BackColor = System.Drawing.Color.White;
            //UCFT
            txtPathNumb.ReadOnly = type;
            txtPathNumb.BackColor = System.Drawing.Color.White;
            //MR
            txtMriNumb.ReadOnly = type;
            txtMriNumb.BackColor = System.Drawing.Color.White;
            //X光
            txtXNumb.ReadOnly = type;
            txtXNumb.BackColor = System.Drawing.Color.White;
            //B超
            txtBC.Enabled = !type;
            //输入员
            txtInputDoc.ReadOnly = type;
            txtInputDoc.EnterVisiable = !type;
            txtInputDoc.BackColor = System.Drawing.Color.White;
        }
        #endregion

        #region 清空所有数据
        /// <summary>
        /// 清空所有数据
        /// </summary>
        public void ClearInfo()
        {
            try
            {
                this.ucDiagNoseInput1.ClearInfo();
                this.ucOperation1.ClearInfo();
                this.ucTumourCard2.ClearInfo();
                this.ucChangeDept1.ClearInfo();
                this.ucBabyCardInput1.ClearInfo();
                this.ucFeeInfo1.ClearInfo();
                //病案号 
                txtCaseNum.Text = "";
                //住院次数
                txtInTimes.Text = "";
                //费用类别
                txtPactKind.Tag = null;
                //医保号
                txtSSN.Text = "";
                //门诊号
                txtClinicNo.Text = "";
                //姓名
                txtPatientName.Text = "";
                //性别
                txtPatientSex.Tag = null;
                //生日
                //			patientBirthday.Enabled = !type;
                //年龄
                txtPatientAge.Text = "";
                //婚姻
                txtMaritalStatus.Tag = null;
                //职业
                txtProfession.Tag = null;
                //出生地
                txtAreaCode.Text = "";
                //民族
                txtNationality.Tag = null;
                //国籍
                txtCountry.Tag = null;
                //籍贯
                txtDIST.Text = "";
                //身份证
                txtIDNo.Text = "";
                //工作单位
                txtAddressBusiness.Text = "";
                //单位邮编
                txtBusinessZip.Text = "";
                //单位电话
                txtPhoneBusiness.Text = "";
                //户口地址
                txtAddressHome.Text = "";
                //户口邮编
                txtHomeZip.Text = "";
                //家庭电话
                txtPhoneHome.Text = "";
                //联系人 
                txtKin.Text = "";
                //关系
                txtRelation.Tag = null;
                //联系电话
                txtLinkmanTel.Text = "";
                //l联系人地址
                txtLinkmanAdd.Text = "";
                //入院科室
                txtDeptInHospital.Tag = null;
                //入院时间 
                //			Date_In.Enabled = !type;
                //入院情况
                txtCircs.Tag = null;
                customListBox1.Text = null;                
                //转入科室
                txtFirstDept.Tag = null;
                //转科时间
                dtFirstTime.Value = System.DateTime.Now;
                //转入科室
                txtDeptSecond.Tag = null;
                //转科时间
                dtSecond.Value = System.DateTime.Now;
                //转入科室
                txtDeptThird.Tag = null;
                //转科时间
                dtThird.Value = System.DateTime.Now;
                //出院科室
                txtDeptOut.Tag = null;
                //出院时间
                txtDateOut.Value = System.DateTime.Now;
                //门诊诊断
                txtClinicDiag.Text = "";
                //诊断医生
                txtClinicDocd.Tag = null;
                //住院天数
                txtPiDays.Text = "";
                //确证时间
                txtDiagDate.Value = System.DateTime.Now;
                //入院诊断
                txtRuyuanDiagNose.Text = "";
                //由何医院转来
                //txtComeFrom.Text = "";
                //曾用名
                //txtNomen.Text = "";
                //病人来源
                txtInAvenue.Tag = null;
                //院感次数
                txtInfectNum.Text = "";
                //hbsag
                txtHbsag.Tag = null;
                txtHcvAb.Tag = null;
                txtHivAb.Tag = null;
                //门诊与出院
                txtCePi.Tag = null;
                //入院与出院 
                txtPiPo.Tag = null;
                //术前与术后
                txtOpbOpa.Tag = null;
                //临床与病理
                txtClPa.Tag = null;
                //放射与病理
                txtFsBl.Tag = null;
                //抢救次数
                txtSalvTimes.Text = "";
                //成功次数
                txtSuccTimes.Text = "";
                //病案质量
                txtMrQual.Tag = null;
                //质控医师
                txtQcDocd.Tag = null;
                //质控护士
                txtQcNucd.Tag = null;
                //主任医师
                txtConsultingDoctor.Tag = null;
                //主治医师
                txtAttendingDoctor.Tag = null;
                //住院医师
                txtAdmittingDoctor.Tag = null;
                //进修医师
                txtRefresherDocd.Tag = null;
                //研究生实习医师
                txtGraDocCode.Tag = null;
                //质控时间
                txtCheckDate.Value = System.DateTime.Now;
                //实习医生
                txtPraDocCode.Tag = null;
                //编码员
                txtCodingCode.Tag = null;
                //整理员 
                txtCoordinate.Tag = null;
                this.txtOperationCode.Tag = null;
                //尸蹇
                cbBodyCheck.Checked = false;
                //手术、治疗、检查、诊断、是否本院首例
                cbYnFirst.Checked = false;
                //随诊
                cbVisiStat.Checked = false;
                //随诊期限
                txtVisiPeriWeek.Text = "";
                txtVisiPeriMonth.Text = "";
                txtVisiPeriYear.Text = "";
                //示教病案
                cbTechSerc.Checked = false;
                //单病种
                cbDisease30.Checked = false;
                //血型
                txtBloodType.Tag = null;
                txtRhBlood.Tag = null;
                //输血反应
                txtReactionBlood.Tag = null;
                //红细胞
                txtBloodRed.Text = "";
                //血小板
                txtBloodPlatelet.Text = "";
                //血浆
                txtBodyAnotomize.Text = "";
                //全血
                txtBloodWhole.Text = "";
                //其他
                txtBloodOther.Text = "";
                //院际会诊
                txtInconNum.Text = "";
                //远程会诊
                txtOutconNum.Text = "";
                //SuperNus 特级护理
                txtSuperNus.Text = "";
                //一级护理
                txtINus.Text = "";
                //二级护理
                txtIINus.Text = "";
                //三级护理
                txtIIINus.Text = "";
                //重症监护
                txtStrictNuss.Text = "";
                //特殊护理
                txtSPecalNus.Text = "";
                //ct
                txtCtNumb.Text = "";
                //UCFT
                txtPathNumb.Text = "";
                //MR
                txtMriNumb.Text = "";
                //X光
                txtXNumb.Text = "";
                //B超
                txtBC.Text = "";
                //输入员
                txtInputDoc.Tag = null;
                //感染部位
                this.txtInfectionPosition.Tag = null;
                //过敏药物1
                this.txtPharmacyAllergic1.Tag = null;
                //过敏药物2
                this.txtPharmacyAllergic2.Tag = null;
                //pet号
                this.txtPETNumb.Text = "";
                //ect号
                this.txtECTNumb.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 打印病案首页

        public override int Print(object sender, object neuObject)
        {
            if (this.healthRecordPrint == null)
            {
                this.healthRecordPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface)) as Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface;
                if (this.healthRecordPrint == null)
                {
                    MessageBox.Show("获得接口IExamPrint错误\n，可能没有维护相关的打印控件或打印控件没有实现接口IExamPrint\n请与系统管理员联系。");
                    return -1;
                }
            }
            this.healthRecordPrint.ControlValue(this.CaseBase);
            this.healthRecordPrint.Print();
            return 1;

        }
        #endregion

        #region 校验诊断约束
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diag"></param>
        /// <returns></returns>
        public int DiagValueState(Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diag)
        {
            ArrayList allList = new ArrayList();
            this.ucDiagNoseInput1.GetAllDiagnose(allList);
            if (allList == null)
            {
                return -1;
            }
            if (allList.Count == 0)
            {
                return 1;
            }
            Neusoft.HISFC.Models.Base.EnumSex sex;
            if (CaseBase.PatientInfo.Sex.ID.ToString() == "F")
            {
                sex = Neusoft.HISFC.Models.Base.EnumSex.F;
            }
            else if (CaseBase.PatientInfo.Sex.ID.ToString() == "M")
            {
                sex = Neusoft.HISFC.Models.Base.EnumSex.M;
            }
            else
            {
                sex = Neusoft.HISFC.Models.Base.EnumSex.U;
            }
            //待定
            ArrayList diagCheckList = diag.QueryDiagnoseValueState(allList, sex);
            ucDiagnoseCheck ucdia = new ucDiagnoseCheck();
            if (diagCheckList == null)
            {
                MessageBox.Show("提取约束出错");
                return -1;
            }
            if (diagCheckList.Count == 0)
            {
                return 1;
            }
            try
            {
                if (frm != null)
                {
                    frm.Close();
                }
            }
            catch { }

            frm = new ucDiagNoseCheck();
            frm.initDiangNoseCheck(diagCheckList);
            if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                frm.Show();
                if (frm.GetRedALarm())
                {
                    return -1;
                }
            }
            //			else if(frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            //			{
            //				frm.ShowDialog();
            //				if(frm.GetRedALarm() )
            //				{
            //					return -1;
            //				}
            //			}
            return 1;
        }
        #endregion

        #region 获取出生日期
        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dtPatientBirthday.ValueChanged -= new EventHandler(txBirth_ValueChanged);
            this.getBirthday();
            this.dtPatientBirthday.ValueChanged += new EventHandler(txBirth_ValueChanged);
        }

        #region 校验事件是否合理
        private void txBirth_ValueChanged(object sender, System.EventArgs e)
        {
            DateTime dtNow = this.baseDml.GetDateTimeFromSysDateTime();

            DateTime dtBirth = this.dtPatientBirthday.Value;

            if (dtBirth > dtNow)
            {
                dtBirth = dtNow;
                //MessageBox.Show("出生日期不能大于系统日期！");
                return;
            }

            int years = 0;

            System.TimeSpan span = new TimeSpan(dtNow.Ticks - dtBirth.Ticks);

            years = span.Days / 365;

            if (years <= 0)
            {
                int month = span.Days / 30;

                if (month <= 0)
                {
                    this.txtPatientAge.Text = span.Days.ToString();
                    this.cmbUnit.SelectedIndex = 2;
                }
                else
                {
                    this.txtPatientAge.Text = month.ToString();
                    this.cmbUnit.SelectedIndex = 1;
                }
            }
            else
            {
                this.txtPatientAge.Text = years.ToString();
                this.cmbUnit.SelectedIndex = 0;
            }
        }
        #endregion
        /// <summary>
        /// 获取出生日期
        /// </summary>
        private void getBirthday()
        {
            string age = this.txtPatientAge.Text.Trim();
            int i = 0;

            if (age == "") age = "0";

            try
            {
                i = int.Parse(age);
            }
            catch (Exception e)
            {
                string error = e.Message;
                MessageBox.Show("输入年龄不正确,请重新输入!", "提示");
                this.txtPatientAge.Focus();
                return;
            }
            DateTime birthday = DateTime.MinValue;

            this.getBirthday(i, this.cmbUnit.Text, ref birthday);

            if (birthday <= this.dtPatientBirthday.MinDate)
            {
                this.txtPatientAge.Focus();
                return;
            }

            //this.dtBirthday.Value = birthday ;

            if (this.cmbUnit.Text == "岁")
            {

                //数据库中存的是出生日期,如果年龄单位是岁,并且算出的出生日期和数据库中出生日期年份相同
                //就不进行重新赋值,因为算出的出生日期生日为当天,所以以数据库中为准

                if (this.dtPatientBirthday.Value.Year != birthday.Year)
                {
                    this.dtPatientBirthday.Value = birthday;
                }
            }
            else
            {
                this.dtPatientBirthday.Value = birthday;
            }
        }
        #region 根据年龄得到出生日期
        /// <summary>
        /// 根据年龄得到出生日期
        /// </summary>
        /// <param name="age"></param>
        /// <param name="ageUnit"></param>
        /// <param name="birthday"></param>
        private void getBirthday(int age, string ageUnit, ref System.DateTime birthday)
        {
            DateTime current = this.baseDml.GetDateTimeFromSysDateTime();

            if (ageUnit == "岁")
            {
                birthday = current.AddYears(-age);
            }
            else if (ageUnit == "月")
            {
                birthday = current.AddMonths(-age);
            }
            else if (ageUnit == "天")
            {
                birthday = current.AddDays(-age);
            }
        }
        #endregion
        #endregion

        #region 设置手工录入
        private void SetHandcraft()
        {
            this.CaseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
            string strCaseNO = this.baseDml.GetCaseInpatientNO();
            if (strCaseNO == null || strCaseNO == "")
            {
                MessageBox.Show("获取住院流水号失败" + baseDml.Err);
                CaseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
                return;
            }
            CaseBase.PatientInfo.ID = strCaseNO;
            CaseBase.IsHandCraft = "1";
            ucFeeInfo1.BoolType = true;
            ucFeeInfo1.LoadInfo(CaseBase.PatientInfo);
            HandCraft = 1;
        }
        #endregion

        #region  按病案号查询
        private void txtCaseNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (txtCaseNOSearch.Text == "")
                    {
                        MessageBox.Show("请输入病案号");
                        return;
                    }
                    else
                    {
                        txtCaseNOSearch.Text = txtCaseNOSearch.Text.Trim().PadLeft(10, '0');
                    }

                    #region 清空
                    HandCraft = 0;
                    this.CaseBase = null;
                    ClearInfo();
                    #endregion
                    if (!this.ucPatient.Visible)
                    {
                        #region 查询
                        ArrayList list = null;
                        list = ucPatient.Init(txtCaseNOSearch.Text, "1");
                        if (list == null)
                        {
                            MessageBox.Show("查询失败" + ucPatient.strErr);
                            return;
                        }
                        if (list.Count == 0)
                        {
                            if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
                            {
                                #region 病案室自己手工录入病案
                                if (MessageBox.Show("没有查到相关病案信息,是否手工录入病案", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    txtCaseNum.Text = txtCaseNOSearch.Text;
                                    txtCaseNum.Focus();
                                    SetHandcraft();
                                }
                                else
                                {
                                    return;
                                }
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("没有查到相关病案信息");
                                return;
                            }
                        }
                        else if (list.Count == 1) //只有一条病案信息
                        {
                            ucPatient.Visible = false;
                            Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                            if (obj != null)
                            {
                                LoadInfo(obj.PatientInfo.ID, this.frmType);
                            }
                        }
                        else
                        {
                            ucPatient.Visible = true;
                        }
                        #endregion
                    }
                    else
                    {
                        #region  选择
                        Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                        if (obj != null)
                        {
                            LoadInfo(obj.PatientInfo.ID, this.frmType);
                        }
                        this.ucPatient.Visible = false;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                ucPatient.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                ucPatient.NextRow();
            }
        }
        #endregion

        #region 按住院号查询
        private void txtPatientNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (txtPatientNOSearch.Text == "")
                    {
                        MessageBox.Show("请输入住院号");
                        return;
                    }
                    else
                    {
                        txtPatientNOSearch.Text = txtPatientNOSearch.Text.Trim().PadLeft(10, '0');
                    }
                    #region 清空
                    ClearInfo();
                    HandCraft = 0;
                    this.CaseBase = null;
                    #endregion
                    if (!this.ucPatient.Visible)
                    {
                        #region 查询
                        ArrayList list = null;
                        list = ucPatient.Init(txtPatientNOSearch.Text, "2");
                        if (list == null)
                        {
                            MessageBox.Show("查询失败" + ucPatient.strErr);
                            return;
                        }
                        if (list.Count == 0)
                        {
                            if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
                            {
                                #region 病案室自己手工录入病案
                                if (MessageBox.Show("没有查到相关病案信息,是否手工录入病案", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    txtCaseNum.Text = txtPatientNOSearch.Text;
                                    txtCaseNum.Focus();
                                    SetHandcraft();
                                }
                                else
                                {
                                    return;
                                }
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("没有查到相关病案信息");
                                return;
                            }
                        }
                        else if (list.Count == 1) //只有一条信息
                        {
                            ucPatient.Visible = false;
                            Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                            if (obj != null)
                            {
                                LoadInfo(obj.PatientInfo.ID, this.frmType);
                                this.txtCaseNum.Focus();
                            }
                        }
                        else //多条信息 
                        {
                            ucPatient.Visible = true;
                        }
                        #endregion
                    }
                    else
                    {
                        #region  选择
                        Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                        if (obj != null)
                        {
                            LoadInfo(obj.PatientInfo.ID, this.frmType);
                            this.txtCaseNum.Focus();
                        }
                        this.ucPatient.Visible = false;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                ucPatient.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                ucPatient.NextRow();
            }
        }
        #endregion 按住院号查询

        #region 双击树的节点
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.treeView1.SelectedNode.Level == 0)
            {
                return;
            }

            try
            {
                if (this.treeView1.SelectedNode.Text == "最近出院患者")
                {
                    return;
                }
                Neusoft.HISFC.Models.RADT.PatientInfo pa = (Neusoft.HISFC.Models.RADT.PatientInfo)treeView1.SelectedNode.Tag;
                LoadInfo(pa.ID, this.frmType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion 

        public override int Exit(object sender, object neuObject)
        { 
            return base.Exit(sender, neuObject);
        }


        #region IInterfaceContainer 成员

        //{DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                //return new Type[] { typeof(Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordInterface) }; ; 
                Type[] t = new Type[2];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface);
                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack);//转科申请
                return t;
            }
        }

        //{DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
        public int PrintBack(Neusoft.HISFC.Models.HealthRecord.Base obj)
        {
            //反面赋值

            if (this.healthRecordPrintBack == null)
            {
                this.healthRecordPrintBack = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(ucCaseMainInfo), typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack)) as Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack;
                if (this.healthRecordPrintBack == null)
                {
                    MessageBox.Show("获得接口IExamPrint错误\n，可能没有维护相关的打印控件或打印控件没有实现接口IExamPrint\n请与系统管理员联系。");
                    return -1;
                }
            }
            if (CaseBase == null)
            {
                return -1;
            }

            this.healthRecordPrintBack.ControlValue(this.CaseBase);
            this.healthRecordPrintBack.Print();
            return 1;

            //caseBackPrint.SetControlValues(obj);
            //return caseBackPrint.Print();

        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            //if (keyData == Keys.Enter)
            //{
            //    SendKeys.Send("{Tab}");
            //}
            //基本信息
            if (keyData == Keys.F2)
            {
                this.tab1.SelectedTab = this.tabPage1;
            }
            //诊断信息
            if (keyData == Keys.F3)
            {
            }
            //手术信息
            if (keyData == Keys.F4)
            {
                this.tab1.SelectedTab = this.tabPage6;
            }
            //妇婴信息
            if (keyData == Keys.F5)
            {
                this.tab1.SelectedTab = this.tabPage2;
            }
            //转科信息
            if (keyData == Keys.F6)
            {
                this.tab1.SelectedTab = this.tabPage3;
            }
            //肿瘤信息
            if (keyData == Keys.F7)
            {
                this.tab1.SelectedTab = this.tabPage7;
            }
            //费用信息
            if (keyData == Keys.F8)
            {
                this.tab1.SelectedTab = this.tabPage4;
            }
            if (keyData == Keys.F9)
            {
                this.ucBabyCardInput1.Focus();
                this.ucDiagNoseInput1.AddRow();
            }

            if (keyData == Keys.F11)
            {
                
                Neusoft.HISFC.Components.HealthRecord.CaseFirstPage.ucChildBirthRecord uc = new ucChildBirthRecord();
                if (this.patientInfo.ID == "")
                {
                    MessageBox.Show("请输入住院号");
                    this.txtPatientNOSearch.Focus();
                    return false;
                }
                uc.PatientInfo = this.patientInfo;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                
                // this.ucPatient
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }




    }


}
