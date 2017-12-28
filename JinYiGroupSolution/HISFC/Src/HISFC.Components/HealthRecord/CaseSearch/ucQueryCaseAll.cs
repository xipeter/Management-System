using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;


namespace Neusoft.HISFC.Components.HealthRecord.CaseSearch
{
    /// <summary>
    /// ucBorrowCase<br></br>
    /// [功能描述: 病案查询/病案编目(暂时不用)]<br></br>
    /// [创 建 者: 李宽]<br></br>
    /// [创建时间: 2007-07-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQueryCaseAll : Neusoft.FrameWork.WinForms.Controls.ucBaseControl 
    {
        public ucQueryCaseAll()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucQueryCondition1_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.ucQueryCondition1.ButtonOK.Visible = false;
                this.ucQueryCondition1.ButtonDefault.Visible = false;
                this.ucQueryCondition1.ButtonExit.Visible = false;
                this.ucQueryCondition1.ButtonReset.Visible = false;
                this.ucQueryCondition2.ButtonOK.Visible = false;
                this.ucQueryCondition2.ButtonDefault.Visible = false;
                this.ucQueryCondition2.ButtonExit.Visible = false;
                this.ucQueryCondition2.ButtonReset.Visible = false;
                this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                
                //得到科室信息
                alDept = deptMgr.GetDeptmentAllOrderByDeptType();
                if (alDept != null && alDept.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
                    {
                        hashDeptNameByCode.Add(dept.ID, dept.Name);
                    }
                }

                //从常数表中获取切口类型
                ArrayList list = con.GetList("INCITYPE");
                if (list != null)
                {
                    NickTypeHelper.ArrayObject = list;
                }

                //从常数表中获取切口类型
                ArrayList list2 = con.GetList("CICATYPE");
                if (list2 != null)
                {
                    CicaTypeHelper.ArrayObject = list2;
                }

                //得到人员信息
                alOper = personMgr.GetEmployeeAll();
                if (alOper != null && alOper.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.Base.Employee empl in alOper)
                    {
                        hashOperInfo.Add(empl.ID, emp.Name);
                    }
                }

                #region 初始化条件查询列表
                InitDragList();
                #endregion

                #region 初始化列名
                IntColsName();
                #endregion

                #region  初始化所有的下拉列表
                InitCountryList();
                #endregion

                #region  诊断信息 
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucDiagNoseInput1.InitInfo();
                #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
                //this.ucDocDiagnoseInput.isList = true;
                #endregion
                #endregion

                #region  妇婴
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucBabyCardInput1.InitInfo();
                #endregion

                #region 手术
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucOperation1.InitInfo();
                //ucOperation1.InitICDList();
                #endregion

                #region 肿瘤
                //thread = new System.Threading.Thread(this.ucTumourCard2.InitInfo);
                //thread.Start();
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucTumourCard2.InitInfo();
                #endregion

                #region  转科
                //thread = new System.Threading.Thread(this.ucChangeDept1.InitInfo);
                //thread.Start(); 
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucChangeDept1.InitInfo();
                #endregion

                #region  费用
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                //this.ucFeeInfo1.InitInfo();
                #endregion               

                System.Drawing.Point point = new Point(this.tabCasOtherInfo.Location.X, this.ucQueryCondition1.Location.Y);
                this.tabCasOtherInfo.Location = point;
                System.Drawing.Size size = new Size(this.Width - this.tabCasOtherInfo.Location.X, this.tabCasOtherInfo.Height);
                this.tabCasOtherInfo.Size = size;

                //设置列、诊断是否可以编辑
                bool isModifyDiagType = false;
                if (enumstus == enumStus.modify)
                {
                    isModifyDiagType = true;
                }
                #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
                //this.ucDocDiagnoseInput.OnlyModifyDiagType(true,isModifyDiagType);
                #endregion

                //初始化树信息
                TreeView tvConditinon = new TreeView();
                InitTreeView();          
                //设置只读
                SetReadOnly(true);

                //设置显示列
                CreateEmptyDS();
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
                

                //不显示右键删除功能
                ClearMenu();

               

            }
            
        }

        #region 工具栏信息
        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
           
        #region 工具栏增加按钮单击事件        

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {            
            //toolBarService.AddToolButton("返回整理组", "返回整理组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A保存, true, false, null);
            
            //toolBarService.AddToolButton("接收查询", "接收查询", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A查询, true, false, null);
            //toolBarService.AddToolButton("接收确认", "接收确认", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A保存, true, false, null);
            //toolBarService.AddToolButton("编目查询", "编目查询", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A查询, true, false, null);
            //toolBarService.AddToolButton("编目确认", "编目确认", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A保存, true, false, null);
            toolBarService.AddToolButton("删除模板", "删除模板", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("新建模板", "新建模板", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("保存模板", "保存模板", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("列设置", "列设置", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "接收查询":
                   // UpdateCaseStus("3", "neaten", "1");//编目组更新
                    QueryBaseInfo("neatenQuery");
                    break;
                case "接收确认":
                    UpdateCaseStus("6", "2", "list");
                    //QueryBaseInfo("inceptConfirm");
                    QueryBaseInfo("neatenQuery");
                    break;
                case "返回整理组":
                    UpdateCaseStus("3", "2", "neaten");//返回整理组
                    QueryBaseInfo("returnNeaten");
                    break;
                case "编目查询":
                   // UpdateCaseStus("6", "list", "2");//编目组查询
                    QueryBaseInfo("listQuery");
                    break;
                case "编目确认":
                    UpdateCaseStus("6", "1", "list");//编目组更新
                    //QueryBaseInfo("listConfirm");
                    QueryBaseInfo("listQuery");
                    break;
                case "删除模板":
                    #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
                    if (tvConditinon.SelectedNode == null)
                    {
                        return;
                    }
                    if (tvConditinon.SelectedNode.Tag == null)
                    {
                        return;
                    }

                    if (tvConditinon.SelectedNode.Tag.ToString() == "0")
                    {
                        return;
                    }

                    if (MessageBox.Show("是否删除模版【" + tvConditinon.SelectedNode.Text + "】?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (this.ucQueryCondition1.DeleteCondtion(tvConditinon.SelectedNode.Tag.ToString()) == -1)
                    {
                        MessageBox.Show("删除模板失败!");

                        return;
                    }

                    tvConditinon.Nodes.Remove(tvConditinon.SelectedNode);
                    MessageBox.Show("删除模板成功!");
                    break;
                case "新建模板":
                    if (this.ucQueryCondition1.SaveCondtion("ucQueryCaseAll", false, "新建模板") == -1)
                    {
                        MessageBox.Show("新建模板失败!");

                        return;
                    }
                    InitTreeView();

                    break;
                case "保存模板":
                    if (this.tvConditinon.SelectedNode == null || this.tvConditinon.SelectedNode.Tag == null || this.tvConditinon.SelectedNode.Tag.ToString() == "0")
                    {
                        return;
                    }

                    this.tvConditinon.SelectedNode.EndEdit(false);
                    if (this.ucQueryCondition1.UpdateCondtion(this.tvConditinon.SelectedNode.Tag.ToString(), this.tvConditinon.SelectedNode.Text) == -1)
                    {
                        MessageBox.Show("保存模板失败!");

                        return;
                    }
                    InitTreeView();

                    MessageBox.Show("保存模板成功!");
                    break;
                    #endregion
                case "列设置":
                    SetColumn();
                    break;
   
                default:
                    break;
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            QueryBaseInfo("ALL");
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
            if (this.tvConditinon.SelectedNode == null)
            {
                return 0;
            }
            this.tvConditinon.SelectedNode.EndEdit(true);
            this.tvConditinon.LabelEdit = false;

            if (this.ucQueryCondition1.UpdateCondtion(this.tvConditinon.SelectedNode.Tag.ToString(), this.tvConditinon.SelectedNode.Text) == -1)
            {
                MessageBox.Show("保存模板失败!");

                return -1;
            }
            InitTreeView();
            #endregion

            return base.OnSave(sender, neuObject);
        }
        public override int Export(object sender, object neuObject)
        {
            Export();
            return base.Export(sender, neuObject);
        }
            
        #endregion
        #endregion

        #region 属性(原中日需求,不需要显示了，编目功能整合到ucCaseNeaten中)
        public enum enumStus
        {
            query,
            modify
        }
        private enumStus enumstus;

        //[Category("查询、修改权限"), Description("是否有修改诊断权限")]
        public enumStus Enumstus
        {
            get
            {
                return enumstus;
            }
            set
            {
                enumstus = value;
            }
        }
        #endregion

        #region 变量
        //public Neusoft.HISFC.BizLogic.HealthRecord.Base baseMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
        DataSet ds = new DataSet();
        //Neusoft.HISFC.BizProcess.Integrate.HealthRecord.ICD icd = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.ICD();
        Neusoft.HISFC.BizLogic.HealthRecord.ICD icdMgr = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
        Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagNoseMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
        Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack caseTrack = new Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack();
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager caseTrackMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager();
        Neusoft.HISFC.Models.Base.Employee emp = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
        Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
        Neusoft.HISFC.BizLogic.Manager.Person personMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        Neusoft.HISFC.BizLogic.HealthRecord.Operation operationMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Operation();
        TreeNode childNode = null;
        //病案基本信息操作类
        private Neusoft.HISFC.BizLogic.HealthRecord.Base baseDml = new Neusoft.HISFC.BizLogic.HealthRecord.Base();

        //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
        private Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        //暂存当前修改人的病案基本信息
        //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
        private Neusoft.HISFC.Models.HealthRecord.Base CaseBase = null;

        Neusoft.HISFC.BizLogic.HealthRecord.DeptShift deptChange = new Neusoft.HISFC.BizLogic.HealthRecord.DeptShift();
        Neusoft.HISFC.BizLogic.HealthRecord.Fee healthRecordFee = new Neusoft.HISFC.BizLogic.HealthRecord.Fee();
        //定义变量
        Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
        //转科信息
        ArrayList changeDept = new ArrayList();
        //第一次转科
        private Neusoft.HISFC.Models.RADT.Location firDept = null;
        //第二次转科信息
        private Neusoft.HISFC.Models.RADT.Location secDept = null;
        //第三次转科信息
        private Neusoft.HISFC.Models.RADT.Location thirDept = null;

        ArrayList buildCaseReasonList = new ArrayList();
        /// <summary>
        /// 配置文件的路径
        /// </summary>
        private string filePath = Application.StartupPath + @".\profile\QueryCaseAll.xml";

        //所有科室信息
        private Hashtable hashDeptNameByCode = new Hashtable();
        //所有人员信息
        private Hashtable hashOperInfo = new Hashtable();

        ArrayList alDept = new ArrayList();
        ArrayList alOper = new ArrayList();

        private Neusoft.FrameWork.Public.ObjectHelper NickTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper CicaTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

        #region 列枚举
        private enum Col
        {
            isChecked ,//是否选中0
            inpatientNO,//住院流水号1
            patientNO,//住院病历号2
            name, //患者姓名3
            sex,//性别4
            birthday,//出生日期5
            cardNO,//门诊就诊卡号6
            caseNO,//病案号7
            idenNO,//身份证号8
            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
            inTimes,//住院次数33
            inTime,//入院日期34           
            outTime,//出院时间35
            inDeptName,//入院科室名称36
            outDeptname,//出院科室名称37
            casStus,//病案状态31

            bloodCD,//血型9
            profession,//职业10
            addressBusiness,//工作单位11
            phoneBusiness,//单位电话, 12
            businessZip,//单位邮编13
            addressHome,//户口或家庭所在14
            phoneHome,//家庭电话,15
            homeZip,//户口或家庭邮政编码 16
            dist,//籍贯17
            nationality,//民族 18
            kinName,//联系人姓名19
            relationPhone,//联系人电话,20
            relationAddress,//联系人住址21
            relationLink,//联系人关系22
            marry,//婚姻状况23
            country,//国籍, 24
            paykindName,//结算类别名称, 25
            pactName,//费用来源名称,26
            ssn,//医疗证号, 27
            IsAlleray,// 药物过敏28
            IsMainDisease,//重要疾病29
            memo,//备注30
            
            patientType,//患者类型 1门诊 2住院32

            caseInDept,//病案当前所在科室38
            caseOper,//当前病案持有人39
            caseDept,//病案所属科室40

            namen,//曾用名41
            age,//年龄42
            inSource,//地区来源43
            areaCode,//出生地44
            clinicDocName,//门诊诊断医生姓名45
            comeFrom,//转来医院46
            OutDiagCode,//出院主诊断 编码47
            OutDiagName,//出院主诊断 名称48
            OutDiagResult,//出院主诊断 治疗情况49

            pactCode,//合同代码50this.lblPriZhiFuFangShi.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT, myItem.PatientInfo.Pact.ID).Name;
            //inTimes,//住院次数51
            //age,//年龄
            clinicDiagIcdName,//门诊诊断52
            inhosDiagIcdName,//入院诊断53
            piDays,//住院天数54
            qtDiag1,//其他诊断2个55
            qtDiag2,//56
            blDiag,//病理诊断57
            CE_PI,//诊断符合情况，门诊出院，58
            PI_PO,//入院出院，59
            OPB_OPA,//术前术后，60
            CL_PA,//临床与病理，61
            SALV_TIMES,//抢救次数，62
            SUCC_TIMES,//成功次数，63
            opeDiagName1,//手术名称，icd码2个，64
            nickKind1,//切口愈合等级65
            nickKind2,//66
            opeDiagCode1,//67

            opeDiagName2,//68            
            cicaKind1,//69            
            cicaKind2,//70            
            opeDiagCode2,//71
            //切口愈合等级
           firDonm//手术医师，72
            
            
            

            #region 未显示字段
                
                //s[39] = b.PatientInfo.PVisit.Circs.ID;//入院状态
                //s[40] = b.DiagDate.ToString();//确诊日期
                //s[41] = b.OperationDate.ToString();//手术日期                
                //s[45] = b.PatientInfo.PVisit.ZG.ID;//转归代码
                //s[46] = b.DiagDays.ToString();//确诊天数
                //s[47] = b.InHospitalDays.ToString();//住院天数
                //s[48] = b.DeadDate.ToString();//死亡日期
                //s[49] = b.DeadReason;//死亡原因
                //s[50] = b.CadaverCheck;//尸检
                //s[51] = b.DeadKind;//死亡种类
                //s[52] = b.BodyAnotomize;//尸体解剖号
                //s[53] = b.Hbsag;//乙肝表面抗原
                //s[54] = b.HcvAb;//丙肝病毒抗体
                //s[55] = b.HivAb;//获得性人类免疫缺陷病毒抗体
                //s[56] = b.CePi;//门急_入院符合
                //s[57] = b.PiPo;//入出_院符合
                //s[58] = b.OpbOpa;//术前_后符合
                //s[59] = b.ClX;//临床_X光符合
                //s[60] = b.ClCt;//临床_CT符合
                //s[61] = b.ClMri;//临床_MRI符合
                //s[62] = b.ClPa;//临床_病理符合
                //s[63] = b.FsBl;//放射_病理符合
                //s[64] = b.SalvTimes.ToString();//抢救次数
                //s[65] = b.SuccTimes.ToString();//成功次数
                //s[66] = b.TechSerc;//示教科研
                //s[67] = b.VisiStat;//是否随诊
                //s[68] = b.VisiPeriod.ToString();//随访期限
                //s[69] = b.InconNum.ToString();//院际会诊次数 70 远程会诊次数
                //s[70] = b.OutconNum.ToString();//院际会诊次数 70 远程会诊次数
                //s[71] = b.AnaphyFlag;//药物过敏
                //s[72] = b.FirstAnaphyPharmacy.ID;//过敏药物名称
                //s[73] = b.SecondAnaphyPharmacy.ID;//过敏药物名称
                //s[74] = b.CoutDate.ToString();//更改后出院日期
                //s[76] = b.PatientInfo.PVisit.AdmittingDoctor.Name;//住院医师姓名
                //s[78] = b.PatientInfo.PVisit.AttendingDoctor.Name;//主治医师姓名               
                //s[80] = b.PatientInfo.PVisit.ConsultingDoctor.Name;//主任医师姓名              
                //s[82] = b.PatientInfo.PVisit.ReferringDoctor.Name;//科主任名称
                //s[84] = b.RefresherDoc.Name;//进修医生名称
                //s[86] = b.GraduateDoc.Name;//研究生实习医师名称 
                //s[88] = b.PatientInfo.PVisit.TempDoctor.Name;//实习医师名称
                //s[90] = b.CodingOper.Name;//编码员名称
                //s[91] = b.MrQuality;//病案质量
                //s[92] = b.MrEligible;//合格病案 
                //s[94] = b.QcDoc.Name;//质控医师名称
                //s[96] = b.QcNurse.Name;//质控护士名称
                //s[97] = b.CheckDate.ToString();//检查时间
                //s[98] = b.YnFirst;//手术操作治疗检查诊断为本院第一例项目
                //s[99] = b.RhBlood;//Rh血型(阴阳)
                //s[100] = b.ReactionBlood;//输血反应（有无）
                //s[101] = b.BloodRed;//红细胞数
                //s[102] = b.BloodPlatelet;//血小板数
                //s[103] = b.BodyAnotomize;//血浆数
                //s[104] = b.BloodWhole;//全血数
                //s[105] = b.BloodOther;//其他输血数
                //s[106] = b.XNum;//X光号
                //s[107] = b.CtNum;//CT号
                //s[108] = b.MriNum;//MRI号
                //s[109] = b.PathNum;//病理号
                //s[110] = b.DsaNum;//DSA号
                //s[111] = b.PetNum;//PET号
                //s[112] = b.EctNum;//ECT号
                //s[113] = b.XQty.ToString();//X线次数
                //s[114] = b.CTQty.ToString();//CT次数
                //s[115] = b.MRQty.ToString();//MR次数
                //s[116] = b.DSAQty.ToString();//DSA次数
                //s[117] = b.PetQty.ToString();//PET次数
                //s[118] = b.EctQty.ToString();//ECT次数
                //s[119] = b.PatientInfo.Memo;//说明
                //s[120] = b.BarCode;//归档条码号
                //s[121] = b.LendStat;//病案借阅状态(O借出 I在架)
                //s[122] = b.PatientInfo.CaseState;//病案状态1科室质检2登记保存3整理4病案室质检5无效
                //s[123] = b.OperInfo.ID;//操作员
                //s[124] = b.VisiPeriodWeek; //随访期限 周
                //s[125] = b.VisiPeriodMonth; //随访期限 月
                //s[126] = b.VisiPeriodYear;//随访期限 年
                //s[127] = b.SpecalNus.ToString();  // 特殊护理(日)                                        
                //s[128] = b.INus.ToString(); //I级护理时间(日)                                     
                //s[129] = b.IINus.ToString(); //II级护理时间(日)                                    
                //s[130] = b.IIINus.ToString(); //III级护理时间(日)                                   
                //s[131] = b.StrictNuss.ToString(); //重症监护时间( 小时)                                 
                //s[132] = b.SuperNus.ToString(); //特级护理时间(小时)     
                //s[133] = b.PackupMan.ID; //整理员
                //s[134] = b.Disease30; //单病种 
                //s[135] = b.IsHandCraft;//手工录入病案 标志
                //s[136] = b.SyndromeFlag; //是否有并犯症
                //s[137] = b.InfectionNum.ToString();//院内感染次数 
                //s[138] = b.OperationCoding.ID;//手术编码员 
                //s[139] = b.CaseNO;//病案号
                //s[140] = b.InfectionPosition.ID; //院内感染部位编码
                //s[141] = b.InfectionPosition.Name; //院内感染部位名称
               
            #endregion

        }
        #endregion
                
        #region 方法
        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView()
        {
            #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
            TreeNode parentNode = new TreeNode();

            ArrayList al = new ArrayList();

            tvConditinon.HideSelection = false;
            this.tvConditinon.Nodes.Clear();
            //根节点
            parentNode.Tag = 0;
            parentNode.Text = "查询模板";
            this.tvConditinon.ImageIndex = 0;
            this.tvConditinon.SelectedImageIndex = 1;
            this.tvConditinon.Nodes.Add(parentNode);

            al = this.ucQueryCondition1.QueryConditions("ucQueryCaseAll");//(this.FindForm().Name);
            if (al == null)
            {
                return;
            }
            //Neusoft.FrameWork.Models.NeuObject neuObject = new Neusoft.FrameWork.Models.NeuObject();
            tvConditinon.BeginUpdate();

            foreach (Neusoft.FrameWork.Models.NeuObject neuObject in al)
            {
                childNode = new TreeNode();
                childNode.Tag = neuObject.ID;
                childNode.Text = neuObject.Name;
                parentNode.Nodes.Add(childNode);
            }
            this.tvConditinon.ExpandAll();

            this.tvConditinon.EndUpdate();
            #endregion

        }

        #region  所有的下拉列表
        private int InitCountryList()
        {
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
            ArrayList BloodTypeList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BLOODTYPE);// baseDml.GetBloodType();
            this.txtBloodType.AddItems(BloodTypeList);
            //婚姻列表
            ArrayList MaritalStatusList = Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List();
            this.txtMaritalStatus.AddItems(MaritalStatusList);
            //结算类别
            ArrayList pactKindlist = con.GetList("PACTUNIT");// baseDml.GetPayKindCode(); //GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT);
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
            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
            //ArrayList deptList = dept.GetDeptmentAll();
            ArrayList deptList = dept.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            txtFirstDept.AddItems(deptList);
            txtDeptSecond.AddItems(deptList);
            txtDeptInHospital.AddItems(deptList);
            txtDeptThird.AddItems(deptList);
            txtDeptOut.AddItems(deptList);

            //InitList(DeptListBox, deptList);
            //血液反应

            ArrayList ReactionBloodList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BLOODREACTION);// baseDml.GetReactionBlood();
            txtReactionBlood.AddItems(ReactionBloodList);

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

        /// <summary>
        /// 填充条件查询下拉菜单 
        /// </summary>
        private void InitDragList()
        {
            ArrayList al = new ArrayList();
            
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "PATIENT_NO";
            obj.Name = "住院号";
            obj.Memo = "";
            obj.User01 = "PATIENT_NO";
            al.Add(obj);           

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "CARD_NO";
            obj.Name = "就诊卡号";
            obj.Memo = "";
            obj.User01 = "CARD_NO";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "CASE_NO";
            obj.Name = "病案号";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MCARD_NO";
            obj.Name = "医疗证号";
            obj.Memo = "";
            obj.User01 = "MCARD_NO";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "NAME";
            obj.Name = "姓名";
            obj.Memo = "";
            obj.User01 = "NAME";
            al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "PATIENT_TYPE";
            //obj.Name = "患者类型";
            //obj.Memo = "1 门诊,2 住院";
            //al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "SEX_CODE";
            obj.Name = "性别";
            obj.Memo = "SEX";
            obj.User01 = "SEX_CODE";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IDENNO";
            obj.Name = "身份证";
            obj.Memo = "";
            obj.User01 = "IDENNO";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DEPT_CODE";
            obj.Name = "出院科室";
            obj.Memo = "DEPARTMENT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DEPT_INCD";
            obj.Name = "入院科室";
            obj.Memo = "DEPARTMENT";
            obj.User01 = "DEPT_CODE";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "BIRTHDAY";
            obj.Name = "出生日期";
            obj.Memo = "DATETIME";
            obj.User01 = "BIRTHDAY";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_NAME";
            obj.Name = "工作单位";
            obj.Memo = "";
            obj.User01 = "WORK_NAME";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_TEL";
            obj.Name = "工作单位电话";
            obj.Memo = "";
            obj.User01 = "WORK_TEL";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_ZIP";
            obj.Name = "单位邮编";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME_ADD";
            obj.Name = "户口或家庭地址";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME_TEL";
            obj.Name = "家庭电话";
            obj.Memo = "";

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME_ZIP";
            obj.Name = "户口或家庭邮编";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DISTRICT";
            obj.Name = "籍贯";
            obj.Memo = "";
            obj.User01 = "DIST";
            al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "NATION_CODE";
            //obj.Name = "民族";
            //obj.Memo = "";
            //al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_NAME";
            obj.Name = "联系人姓名";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "AGE";
            obj.Name = "年龄";
            obj.Memo = "INT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_TEL";
            obj.Name = "联系人电话";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_ADD";
            obj.Name = "联系人地址";
            obj.Memo = "";
            al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "CASE_STUS";
            //obj.Name = "是否已编目";
            //obj.Memo = "6 是,3 否";
            //al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MARI";
            obj.Name = "婚姻状况";
            obj.Memo = "MARI";
            al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "BLOOD_CODE";
            //obj.Name = "血型编码";
            //obj.Memo = "";
            //al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "PACT_NAME";
            //obj.Name = "费用来源";
            //obj.Memo = "";
            //al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "IN_CIRCS";
            //obj.Name = "入院情况";
            //obj.Memo = "";
            //al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "IN_AVENUE";
            //obj.Name = "入院途径";           
            //obj.Memo = "1 lk,2 ztt";
            //al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IN_DATE";
            obj.Name = "入院日期";
            obj.Memo = "DATETIME";
            obj.User01 = "IN_DATE";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "OUT_DATE";
            obj.Name = "出院日期";
            obj.Memo = "DATETIME";
            obj.User01 = "OUT_DATE";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "OPER_DATE";
            obj.Name = "建立时间";
            obj.Memo = "DATETIME";
            al.Add(obj);            

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "BED_NO";
            obj.Name = "床号";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LEND_STUS";
            obj.Name = "是否借阅";
            obj.Memo = "O 借出,I 返还";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "CASE_STUS";
            obj.Name = "病案状态";
            obj.Memo = "2 医生站登记保存,3 病案室整理";
            //obj.Memo = "1 科室质检,2 医生站登记保存,3 病案室整理,4 病案室质检,5 无效,6 病案编目,7 库房确认";
            al.Add(obj);

            //{3DB818AA-CDAF-4103-B1B9-E439FB75F8B7} 
            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MAIN_DIAGSTATE";//"DIAG_OUTSTATE";
            obj.Name = "治愈情况";
            obj.Memo = "1 治愈,2 好转,3 未治愈,4 死亡,5 其他";
            al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "SEND_FLOW";
            //obj.Name = "病案整理归属";
            //obj.Memo = "doc 医生,nurse 护士,neaten 整理组,list 编目,qa 质量组,store 库房";
            //al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "SEND_STATE";
            //obj.Name = "病案整理状态";
            //obj.Memo = "1 发送申请,2 接收确认,3 返修";
            //al.Add(obj);

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "CAS_CURRENT_DEPT";
            //obj.Name = "病案所在科室";
            //obj.Memo = "DEPARTMENT";
            //al.Add(obj);

            //建立病案原因

            buildCaseReasonList = con.GetList("BUILD_CASE_REASON");

            if (buildCaseReasonList != null && buildCaseReasonList.Count > 0)
            {
                string memo = "";
                foreach (Neusoft.HISFC.Models.Base.Const neuObj in buildCaseReasonList)
                {
                    //Neusoft.HISFC.Models.Base.Const neuObj = list[0] as Neusoft.HISFC.Models.Base.Const;
                    memo += neuObj.ID + " " + neuObj.Name+",";
                    
                }
                memo = memo.Remove(memo.Length - 1);//去掉最后的“，”号
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "BUILD_CASE_REASON";
                obj.Name = "建病案原因";
                obj.Memo = memo;
                al.Add(obj);
            }

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //obj.ID = "OLD_CASE_NO";
            //obj.Name = "老系统病案号";
            //obj.Memo = "";
            //al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "PI_DAYS";//"DIAG_OUTSTATE";
            obj.Name = "住院天数";
            obj.Memo = "INT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DIAG_DATE";
            obj.Name = "确诊时间";
            obj.Memo = "DATETIME";
            al.Add(obj);


            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IN_CIRCS";
            obj.Name = "入院时情况";
            obj.Memo = "1 一般,2 急,3 危";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LEND_STUS";
            obj.Name = "门诊出院";
            obj.Memo = "01 符合,02 不符合,03 未知";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "PI_PO";
            obj.Name = "入院出院";
            obj.Memo = "01 符合,02 不符合,03 未知";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "OPB_OPA";
            obj.Name = "术前术后";
            obj.Memo = "01 符合,02 不符合,03 未知";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "CL_PA";
            obj.Name = "临床病理";
            obj.Memo = "01 符合,02 不符合,03 未知";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "FS_BL";
            obj.Name = "放射病理";
            obj.Memo = "01 符合,02 不符合,03 未知";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "SALV_TIMES";
            obj.Name = "抢救次数";
            obj.Memo = "INT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "SUCC_TIMES";
            obj.Name = "成功次数";
            obj.Memo = "INT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MR_QUAL";
            obj.Name = "病案质量";
            obj.Memo = "01 甲,02 乙";
            al.Add(obj);

            ////建立病案原因

            //alOper = personMgr.GetEmployeeAll();
            //if (alOper != null && alOper.Count > 0)
            //{
            //    foreach (Neusoft.HISFC.Models.Base.Employee empl in alOper)
            //    {
            //        hashOperInfo.Add(empl.ID, emp.Name);
            //    }
            //}

            if (alOper != null && alOper.Count > 0)
            {
                string memo = "";
                foreach (Neusoft.HISFC.Models.Base.Employee empl in alOper)
                {
                    //Neusoft.HISFC.Models.Base.Const neuObj = list[0] as Neusoft.HISFC.Models.Base.Const;
                    memo += empl.ID + " " + empl.Name + ",";

                }
                memo = memo.Remove(memo.Length - 1);//去掉最后的“，”号
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "CHARGE_DOC_CODE";
                obj.Name = "主治医师";
                obj.Memo = memo;
                al.Add(obj);

                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "CHIEF_DOC_CODE";
                obj.Name = "住院医生";
                obj.Memo = memo;
                al.Add(obj);

                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "DEPT_CHIEF_DOCD";
                obj.Name = "科主任";
                obj.Memo = memo;
                al.Add(obj);
            }




            //设置列
            this.ucQueryCondition1.InitCondition(al);

            //ArrayList diagList = new ArrayList();
            ArrayList alDiag = new ArrayList();

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "b.DIAG_KIND";
            obj.Name = "诊断类型";
            obj.Memo = "1 主要诊断,2 其他诊断,4 感染诊断,5 损伤中毒诊断,6 病理诊断,10 门诊诊断,11 入院诊断";
            alDiag.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "b.ICD_CODE";
            obj.Name = "诊断";
            obj.Memo = "DIAGNOSE";
            alDiag.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "C.OPERATION_CODE";
            obj.Name = "手术诊断";
            obj.Memo = "OPEDIAGNOSE";
            alDiag.Add(obj);            
            

            if (alOper != null && alOper.Count > 0)
            {
                string memo = "";
                foreach (Neusoft.HISFC.Models.Base.Employee empl in alOper)
                {
                    //Neusoft.HISFC.Models.Base.Const neuObj = list[0] as Neusoft.HISFC.Models.Base.Const;
                    memo += empl.ID + " " + empl.Name + ",";

                }
                memo = memo.Remove(memo.Length - 1);//去掉最后的“，”号
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "c.FIR_DOCD";
                obj.Name = "手术医师";
                obj.Memo = memo;
                alDiag.Add(obj);

            }


            ArrayList narcList = new ArrayList();
            narcList = con.GetList("ANESTYPE");

            if (narcList != null && narcList.Count > 0)
            {
                string memo = "";
                foreach (Neusoft.HISFC.Models.Base.Const neuObj in narcList)
                {
                    //Neusoft.HISFC.Models.Base.Const neuObj = list[0] as Neusoft.HISFC.Models.Base.Const;
                    memo += neuObj.ID + " " + neuObj.Name + ",";

                }
                memo = memo.Remove(memo.Length - 1);//去掉最后的“，”号
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "c.NARC_KIND";
                obj.Name = "麻醉方式";
                obj.Memo = memo;
                alDiag.Add(obj);
            }



            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "c.NICK_KIND";
            obj.Name = "切口种类";//ANESTYPE
            obj.Memo = "1 I类切口,2 II类切口,3 III类切口";
            alDiag.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "c.CICA_KIND";
            obj.Name = "愈合种类";//ANESTYPE
            obj.Memo = "1 良好,2 一般,3 较差";
            alDiag.Add(obj); 
           
            

            //设置列
            this.ucQueryCondition2.InitCondition(alDiag);
            this.ucQueryCondition2.ClearAll();
            this.ucQueryCondition2.AddNewRow(0);

        }

        /// <summary>
        /// 检索患者病案信息
        /// </summary>
        private void QueryBaseInfo(string parm)
        {
            string strSql = "";
            string strSqlDiag = "";
            ArrayList al = null;
            this.neuSpread1_Sheet1.RowCount = 0;
            #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
            strSql = this.ucQueryCondition1.GetWhereStirngNoUpdate("a.");
            //strSqlDiag = this.ucQueryCondition2.GetWhereStirngNoUpdate("b.");
            strSqlDiag = this.ucQueryCondition2.GetWhereStirngNoUpdate();

            //诊断默认为不选择,所以这里的条件需要处理一下
            if (strSqlDiag.Trim() == "b.ICD_CODE = ''" || strSqlDiag.Trim() == "b.DIAG_KIND = ''")
            {
                strSqlDiag = "";
            }

            if (strSql == "" || strSql == null)
            {
                MessageBox.Show("请输入查询条件!");

                return;
            }

            if (enumstus == enumStus.query)
            {
                if (string.IsNullOrEmpty(strSqlDiag))
                {
                    strSql = " where " + strSql;

                }
                else
                {
                    strSql = ",met_cas_diagnose b,met_cas_operationdetail c where a.inpatient_no = b.inpatient_no and a.inpatient_no = c.inpatient_no and (" + strSqlDiag + ") and b.OPER_TYPE = '2'  AND" + strSql;//and b.DIAG_KIND = '1'
                }

            }
            else if (enumstus == enumStus.modify)
            {
                string mainSql = "";

                switch (parm)
                {
                    case "neatenQuery":
                        mainSql = " and a.send_state ='1' and a.send_flow = 'neaten'";
                        break;
                    case "inceptConfirm":
                        mainSql = " and a.send_state ='2' and a.send_flow = 'list'  ";
                        break;
                    case "returnNeaten":
                        mainSql = " and a.send_state ='2' and a.send_flow = 'neaten' ";
                        break;
                    case "listQuery":
                        mainSql = " and a.send_state ='2' and a.send_flow = 'list' ";
                        break;
                    case "listConfirm":
                        mainSql = " and a.send_state ='1' and a.send_flow = 'list'";
                        break;
                    case "ALL":
                        mainSql = " and" + strSql;
                        break;

                    default:
                        break;
                }


                if (string.IsNullOrEmpty(strSqlDiag))
                {
                    strSql = "where 1=1 and " + strSql + mainSql;

                }
                else
                {
                    strSql = ",met_cas_diagnose b where a.inpatient_no = b.inpatient_no and (" + strSqlDiag + ") and " + strSql + mainSql;
                }

            }

            al = baseDml.QueryBaseCasBySetWhere(strSql);
            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
            if (al == null)
            {
                MessageBox.Show("查询病案记录出错：" + baseDml.Err);
                return;
            }

            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询--先屏蔽掉
            //string strSqlInpatient = this.ucQueryCondition1.GetWhereStringSecondTable("");
            //ArrayList alInPatient = this.radtManager.QueryPatientByWhere(strSqlInpatient);
            //if (alInPatient == null)
            //{
            //    MessageBox.Show("查询住院记录出错:" + this.radtManager.Err);
            //    return;
            //}

            #endregion 
            ClearInfo();

            #region 列显示值
            if (al.Count > 0)
            {
                FarPoint.Win.Spread.CellType.CheckBoxCellType typeChecked = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                FarPoint.Win.Spread.CellType.TextCellType typeText = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Spread.CellType.NumberCellType typeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                for (int i = 0; i < al.Count; i++)
                {
                    this.neuSpread1_Sheet1.AddRows(i, 1);
                    Neusoft.HISFC.Models.HealthRecord.Base baseInfo = al[i] as Neusoft.HISFC.Models.HealthRecord.Base;
                    
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.isChecked].CellType = typeChecked;
                    if (enumstus != enumStus.modify)
                    {
                        this.neuSpread1_Sheet1.Columns[(int)Col.isChecked].Visible = false;
                    }
                 
                    //if (baseInfo.PatientInfo.CaseState != "3") //病案状态 3整理 6编目
                    //{
                    //    this.neuSpread1_Sheet1.Cells[i, (int)Col.isChecked].Locked = true;                        
                    //}
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.isChecked].Text = "False";

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inpatientNO].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inpatientNO].Text = baseInfo.PatientInfo.ID; //住院流水号
                    this.neuSpread1_Sheet1.Columns[(int)Col.inpatientNO].Visible = false;

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.patientNO].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.patientNO].Text = baseInfo.PatientInfo.PID.PatientNO; //病历号
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.name].Text = baseInfo.PatientInfo.Name; //患者姓名                    
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.sex].Text = baseInfo.PatientInfo.Sex.Name;//性别                    
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.birthday].Text = baseInfo.PatientInfo.Birthday.ToString();//生日

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.cardNO].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.cardNO].Text = baseInfo.PatientInfo.PID.CardNO;//就诊卡号
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.caseNO].Text = baseInfo.CaseNO;//病案号

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.idenNO].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.idenNO].Text = baseInfo.PatientInfo.IDCard;//身份证

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.bloodCD].Text = baseInfo.PatientInfo.BloodType.Name;//血型
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.profession].Text = baseInfo.PatientInfo.Profession.Name;//职业
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.addressBusiness].Text = baseInfo.PatientInfo.AddressBusiness;//工作单位

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.phoneBusiness].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.phoneBusiness].Text = baseInfo.PatientInfo.PhoneBusiness;//单位电话

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.businessZip].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.businessZip].Text = baseInfo.PatientInfo.BusinessZip;//单位邮编
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.addressHome].Text = baseInfo.PatientInfo.AddressHome;//户口或家庭所在

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.phoneBusiness].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.phoneHome].Text = baseInfo.PatientInfo.PhoneHome;//家庭电话

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.homeZip].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.homeZip].Text = baseInfo.PatientInfo.HomeZip;//户口或家庭邮政编码
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.dist].Text = baseInfo.PatientInfo.DIST;//籍贯
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.nationality].Text = baseInfo.PatientInfo.Nationality.Name;//民族
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.kinName].Text = baseInfo.PatientInfo.Kin.Name;//联系人

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.relationPhone].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.relationPhone].Text = baseInfo.PatientInfo.Kin.RelationPhone;//联系人电话
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.relationAddress].Text = baseInfo.PatientInfo.Kin.RelationAddress;//联系人地址
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.relationLink].Text = baseInfo.PatientInfo.Kin.RelationLink;//联系人关系
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.marry].Text = baseInfo.PatientInfo.MaritalStatus.Name;//结婚情况
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.country].Text = baseInfo.PatientInfo.Country.Name;//国家
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.paykindName].Text = baseInfo.PatientInfo.Pact.PayKind.Name;//
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.pactName].Text = baseInfo.PatientInfo.Pact.Name;//

                    //{F03FB6D6-43EC-4e43-9F8E-A3734216F9F5} 增加显示主诊断和治疗情况
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagCode].Text = baseInfo.OutDiag.ID;//出院诊断编码
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagName].Text = baseInfo.OutDiag.Name;//出院诊断名称

                    switch (baseInfo.OutDiag.User01)  //治愈情况
                    {
                        case "1":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagResult].Text = "治愈";
                            break;

                        case "2":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagResult].Text = "好转";
                            break;
                        case "3":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagResult].Text = "未治愈";
                            break;
                        case "4":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagResult].Text = "死亡";
                            break;
                        case "5":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.OutDiagResult].Text = "其他";
                            break;                       
                    }
                    



                    this.neuSpread1_Sheet1.Cells[i, (int)Col.ssn].CellType = typeText;
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.ssn].Text = baseInfo.PatientInfo.SSN;//医保卡号

                    if (baseInfo.PatientInfo.Disease.IsAlleray)//是否过敏
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.IsAlleray].Text = "是";
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.IsAlleray].Text = "否";
                    }

                    if (baseInfo.PatientInfo.Disease.IsMainDisease)//是否重要疾病
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.IsMainDisease].Text = "是";
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.IsMainDisease].Text = "否";
                    }


                    this.neuSpread1_Sheet1.Cells[i, (int)Col.memo].Text = baseInfo.PatientInfo.Memo;

                    //if (baseInfo.PatientType == "1") //门诊还是住院患者
                    //{
                    //    this.neuSpread1_Sheet1.Cells[i, (int)Col.patientType].Text = "门诊";
                    //}
                    //else
                    //{
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.patientType].Text = "住院";
                    //}
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inTimes].Text = baseInfo.PatientInfo.InTimes.ToString();//住院次数

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inTime].Text = baseInfo.PatientInfo.PVisit.InTime.ToString(); //入院日期

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.outTime].Text = baseInfo.PatientInfo.PVisit.OutTime.ToString();//出院时间
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inDeptName].Text = baseInfo.InDept.Name; //入院科室
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.outDeptname].Text = baseInfo.OutDept.Name;//出院科室
                 
                    switch (baseInfo.PatientInfo.CaseState) //病案状态 1科室质检/2医生站登记保存/3病案室整理/4病案室质检/5无效/6病案编目/7库房确认
                    {
                        case "1":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text ="科室质检";
                            break;

                        case "2":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "医生站登记保存";
                            break;
                        case "3":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "病案室整理";
                            break;
                        case "4":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "病案室质检";
                            break;
                        case "5":
                            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "回收";
                            break;
                        case "6":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "病案编目";
                            break;
                        case "7":
                            this.neuSpread1_Sheet1.Cells[i, (int)Col.casStus].Text = "库房确认";
                            break;
                    }

                    string deptName = "";
                    string operName = "";
                    string caseDept = "";
                    //if (!string.IsNullOrEmpty(baseInfo.CaseOper.Dept.ID))
                    //{
                    //    //deptName = deptMgr.GetDeptmentById(baseInfo.CaseOper.Dept.ID).Name;
                    //    deptName = hashDeptNameByCode[baseInfo.CaseOper.Dept.ID].ToString();
                    //    this.neuSpread1_Sheet1.Cells[i, (int)Col.caseInDept].Text = deptName;//病案所在科室
 
                    //}

                    //if (!string.IsNullOrEmpty(baseInfo.CaseOper.ID))
                    //{
                    //     //operName = personMgr.GetPersonByID(baseInfo.CaseOper.ID).Name;
                    //    operName = hashOperInfo[baseInfo.CaseOper.ID].ToString();
                    //     this.neuSpread1_Sheet1.Cells[i, (int)Col.caseOper].Text = operName;//病案持有人
 
                    //}                   
                    

                    //if (!string.IsNullOrEmpty(baseInfo.DeptCase.ID)) //病案所属科室
                    //{

                    //    caseDept = hashDeptNameByCode[baseInfo.DeptCase.ID].ToString();
                    //    this.neuSpread1_Sheet1.Cells[i, (int)Col.caseDept].Text = caseDept;
                    //}

                    this.neuSpread1_Sheet1.Cells[i, (int)Col.pactCode].Text = con.GetConstant("PACTUNIT", baseInfo.PatientInfo.Pact.ID).Name.ToString();
                    //pactCode,//合同代码this.lblPriZhiFuFangShi.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT, myItem.PatientInfo.Pact.ID).Name;
                    //inTimes,//住院次数
                    //age,//年龄
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.clinicDiagIcdName].Text = baseInfo.ClinicDiag.Name;//门诊诊断
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.inhosDiagIcdName].Text = baseInfo.InHospitalDiag.Name;//入院诊断
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.piDays].Text = baseInfo.InHospitalDays.ToString();//住院天数

                    //查找诊断信息
                    ArrayList alDiagQt = new ArrayList();
                    Neusoft.HISFC.Models.HealthRecord.Diagnose dg = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    alDiagQt = diagNoseMgr.QueryCaseDiagnose(baseInfo.PatientInfo.ID,"2", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);//其他诊断
                    if (alDiagQt.Count > 0)
                    {
                        dg = alDiagQt[0] as Neusoft.HISFC.Models.HealthRecord.Diagnose;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.qtDiag1].Text = dg.DiagInfo.ICD10.Name;//其他诊断2个
                    }
                    if (alDiagQt.Count > 1)
                    {
                        dg = alDiagQt[1] as Neusoft.HISFC.Models.HealthRecord.Diagnose;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.qtDiag2].Text = dg.DiagInfo.ICD10.Name;//
                    }
                    alDiagQt = diagNoseMgr.QueryCaseDiagnose(baseInfo.PatientInfo.ID, "6", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);//病理诊断
                    if (alDiagQt.Count > 0)
                    {
                        dg = alDiagQt[0] as Neusoft.HISFC.Models.HealthRecord.Diagnose;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.blDiag].Text = dg.DiagInfo.ICD10.Name;//病理诊断
                    }
                    
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.CE_PI].Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ACCORDSTAT, baseInfo.CePi).Name.ToString();//诊断符合情况，门诊出院，
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.PI_PO].Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ACCORDSTAT, baseInfo.PiPo).Name.ToString();//入院出院，
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.OPB_OPA].Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ACCORDSTAT, baseInfo.OpbOpa).Name.ToString();//术前术后，
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.CL_PA].Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ACCORDSTAT, baseInfo.ClPa).Name.ToString();//临床与病理，
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.SALV_TIMES].Text = baseInfo.SalvTimes.ToString();//抢救次数，
                    this.neuSpread1_Sheet1.Cells[i, (int)Col.SUCC_TIMES].Text = baseInfo.SuccTimes.ToString();//成功次数，

                    ArrayList alOperation = new ArrayList();
                    Neusoft.HISFC.Models.HealthRecord.OperationDetail opeObj = new Neusoft.HISFC.Models.HealthRecord.OperationDetail();
                    alOperation = operationMgr.QueryOperation(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS, baseInfo.PatientInfo.ID);

                    if (alOperation.Count > 0)
                    {
                        opeObj = alOperation[0] as Neusoft.HISFC.Models.HealthRecord.OperationDetail;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagName1].Text = opeObj.OperationInfo.Name;//手术名称，icd码2个，

                        this.neuSpread1_Sheet1.Cells[i, (int)Col.nickKind1].Text = NickTypeHelper.GetName(opeObj.MarcKind);//切口愈合等级
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.cicaKind1].Text = CicaTypeHelper.GetName(opeObj.CicaKind);
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagCode1].CellType = typeText;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagCode1].Text = opeObj.OperationInfo.ID;//
                        
                        //切口愈合等级
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.firDonm].Text = opeObj.FourDoctInfo.Name;//手术医师，
                    }

                    if (alOperation.Count > 1)
                    {
                        opeObj = alOperation[1] as Neusoft.HISFC.Models.HealthRecord.OperationDetail;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagName2].Text = opeObj.OperationInfo.Name;//手术名称，icd码2个，

                        this.neuSpread1_Sheet1.Cells[i, (int)Col.nickKind2].Text = NickTypeHelper.GetName(opeObj.MarcKind);//切口愈合等级
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.cicaKind2].Text = CicaTypeHelper.GetName(opeObj.CicaKind);
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagCode2].CellType = typeText;
                        this.neuSpread1_Sheet1.Cells[i, (int)Col.opeDiagCode2].Text = opeObj.OperationInfo.ID;//
                    }                                  
                    
                }
            }
            #endregion
            //设置列显示信息
            CreateEmptyDS();
            //使列不可编辑
            SetColLock(true);           

        }

        /// <summary>
        /// 初始化列名
        /// </summary>
        private void IntColsName()
        {            
            this.neuSpread1_Sheet1.Columns[(int)Col.inpatientNO].Label ="住院流水号";
            this.neuSpread1_Sheet1.Columns[(int)Col.isChecked].Label = "是否选中";
            this.neuSpread1_Sheet1.Columns[(int)Col.patientNO].Label = "病历号";
            this.neuSpread1_Sheet1.Columns[(int)Col.name].Label = "患者姓名";
            this.neuSpread1_Sheet1.Columns[(int)Col.sex].Label = "性别";
            this.neuSpread1_Sheet1.Columns[(int)Col.birthday].Label="出生日期";
            this.neuSpread1_Sheet1.Columns[(int)Col.cardNO].Label="门诊卡号";
            this.neuSpread1_Sheet1.Columns[(int)Col.caseNO].Label="病案号";
            this.neuSpread1_Sheet1.Columns[(int)Col.idenNO].Label="身份证号";
            this.neuSpread1_Sheet1.Columns[(int)Col.bloodCD].Label="血型";
            this.neuSpread1_Sheet1.Columns[(int)Col.profession].Label="职业";
            this.neuSpread1_Sheet1.Columns[(int)Col.addressBusiness].Label="工作单位";
            this.neuSpread1_Sheet1.Columns[(int)Col.phoneBusiness].Label="单位电话";
            this.neuSpread1_Sheet1.Columns[(int)Col.businessZip].Label="单位邮编";
            this.neuSpread1_Sheet1.Columns[(int)Col.addressHome].Label="家庭地址";
            this.neuSpread1_Sheet1.Columns[(int)Col.phoneHome].Label="家庭电话";
            this.neuSpread1_Sheet1.Columns[(int)Col.homeZip].Label="家庭邮编";
            this.neuSpread1_Sheet1.Columns[(int)Col.dist].Label="籍贯";
            this.neuSpread1_Sheet1.Columns[(int)Col.nationality].Label="民族";
            this.neuSpread1_Sheet1.Columns[(int)Col.kinName].Label="联系人姓名";
            this.neuSpread1_Sheet1.Columns[(int)Col.relationPhone].Label="联系人电话";
            this.neuSpread1_Sheet1.Columns[(int)Col.relationAddress].Label="联系人住址";
            this.neuSpread1_Sheet1.Columns[(int)Col.relationLink].Label="联系人关系";
            this.neuSpread1_Sheet1.Columns[(int)Col.marry].Label="婚姻状况";
            this.neuSpread1_Sheet1.Columns[(int)Col.country].Label="国籍";
            this.neuSpread1_Sheet1.Columns[(int)Col.paykindName].Label="结算类别名称";
            this.neuSpread1_Sheet1.Columns[(int)Col.pactName].Label="费用来源名称";
            this.neuSpread1_Sheet1.Columns[(int)Col.ssn].Label="医疗证号";
            this.neuSpread1_Sheet1.Columns[(int)Col.IsAlleray].Label="药物过敏";
            this.neuSpread1_Sheet1.Columns[(int)Col.IsMainDisease].Label="重要疾病";
            this.neuSpread1_Sheet1.Columns[(int)Col.memo].Label="备注";
            this.neuSpread1_Sheet1.Columns[(int)Col.casStus].Label="病案状态";
            //this.neuSpread1_Sheet1.Columns[(int)Col.casStus].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)Col.patientType].Label = "患者类型";
            this.neuSpread1_Sheet1.Columns[(int)Col.inTimes].Label = "住院次数";
            this.neuSpread1_Sheet1.Columns[(int)Col.inTime].Label = "住院日期";
            this.neuSpread1_Sheet1.Columns[(int)Col.inDeptName].Label = "入院科室";
            this.neuSpread1_Sheet1.Columns[(int)Col.outDeptname].Label = "出院科室";
            this.neuSpread1_Sheet1.Columns[(int)Col.outTime].Label = "出院时间";

            this.neuSpread1_Sheet1.Columns[(int)Col.caseInDept].Label = "病案所在科室";
            this.neuSpread1_Sheet1.Columns[(int)Col.caseInDept].Width = 105;
            this.neuSpread1_Sheet1.Columns[(int)Col.caseOper].Label = "病案持有人";
            this.neuSpread1_Sheet1.Columns[(int)Col.caseOper].Width = 105;
            this.neuSpread1_Sheet1.Columns[(int)Col.caseDept].Label = "病案所属科室";
            this.neuSpread1_Sheet1.Columns[(int)Col.caseDept].Width = 105;

            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
            this.neuSpread1_Sheet1.Columns[(int)Col.namen].Label = "曾用名";
            this.neuSpread1_Sheet1.Columns[(int)Col.age].Label = "年龄";
            this.neuSpread1_Sheet1.Columns[(int)Col.inSource].Label = "地区来源";
            this.neuSpread1_Sheet1.Columns[(int)Col.areaCode].Label = "出生地";
            this.neuSpread1_Sheet1.Columns[(int)Col.clinicDocName].Label = "门诊诊断医生姓名";
            this.neuSpread1_Sheet1.Columns[(int)Col.comeFrom].Label = "转来医院";

            //{F03FB6D6-43EC-4e43-9F8E-A3734216F9F5} 增加显示主诊断和治疗情况
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagCode].Label = "主诊断编码";
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagCode].Width = 105;
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagName].Label = "主诊断名称";
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagName].Width = 105;
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagResult].Label = "治疗情况";
            this.neuSpread1_Sheet1.Columns[(int)Col.OutDiagResult].Width = 105;


            this.neuSpread1_Sheet1.Columns[(int)Col.pactCode].Label ="合同单位";
             //pactCode,//合同代码this.lblPriZhiFuFangShi.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT, myItem.PatientInfo.Pact.ID).Name;
            //inTimes,//住院次数
            //age,//年龄
            this.neuSpread1_Sheet1.Columns[(int)Col.clinicDiagIcdName].Label ="门诊诊断";//门诊诊断
            this.neuSpread1_Sheet1.Columns[(int)Col.inhosDiagIcdName].Label ="入院诊断";//入院诊断
            this.neuSpread1_Sheet1.Columns[(int)Col.piDays].Label = "住院天数";//住院天数
            this.neuSpread1_Sheet1.Columns[(int)Col.qtDiag1].Label ="其他诊断1";//其他诊断2个
            this.neuSpread1_Sheet1.Columns[(int)Col.qtDiag2].Label= "其他诊断2";//
            this.neuSpread1_Sheet1.Columns[(int)Col.blDiag].Label ="病理诊断";//病理诊断
            this.neuSpread1_Sheet1.Columns[(int)Col.CE_PI].Label ="门诊出院诊断符合情况";//诊断符合情况，门诊出院，
            this.neuSpread1_Sheet1.Columns[(int)Col.PI_PO].Label ="入院出院";//入院出院，
            this.neuSpread1_Sheet1.Columns[(int)Col.OPB_OPA].Label ="术前术后";//术前术后，
            this.neuSpread1_Sheet1.Columns[(int)Col.CL_PA].Label ="临床与病理";//临床与病理，
            this.neuSpread1_Sheet1.Columns[(int)Col.SALV_TIMES].Label ="抢救次数";//抢救次数，
            this.neuSpread1_Sheet1.Columns[(int)Col.SUCC_TIMES].Label ="成功次数";//成功次数，
            this.neuSpread1_Sheet1.Columns[(int)Col.opeDiagName1].Label ="手术名称1";//手术名称，icd码2个，
            this.neuSpread1_Sheet1.Columns[(int)Col.nickKind1].Label = "切口愈合";//切口愈合等级
            this.neuSpread1_Sheet1.Columns[(int)Col.cicaKind1].Label = "等级";
            this.neuSpread1_Sheet1.Columns[(int)Col.opeDiagCode1].Label = "手术诊断1";//

            this.neuSpread1_Sheet1.Columns[(int)Col.opeDiagName2].Label ="手术名称2";//           
            this.neuSpread1_Sheet1.Columns[(int)Col.nickKind2].Label ="切口愈合";//
            this.neuSpread1_Sheet1.Columns[(int)Col.cicaKind2].Label ="等级";//            
            this.neuSpread1_Sheet1.Columns[(int)Col.opeDiagCode2].Label ="手术诊断2";//
            //切口愈合等级
            this.neuSpread1_Sheet1.Columns[(int)Col.firDonm].Label = "手术医师";//手术医师，
        }

        /// <summary>
        /// 让一些列不显示
        /// </summary>
        private void SetVisible()
        {
            //如果是门诊有些列是不需要显示的
            this.neuSpread1_Sheet1.Columns[(int)Col.inpatientNO].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.namen].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.inSource].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.comeFrom].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.inTime].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.inTimes].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.inDeptName].Visible = false;
            //this.neuSpread1_Sheet1.Columns[(int)Col.patientNO].Visible = false;
            ////this.neuSpread1_Sheet1.Columns[(int)Col.namen].Visible = false;
            ////this.neuSpread1_Sheet1.Columns[(int)Col.namen].Visible = false;           
            this.neuSpread1_Sheet1.Columns[(int)Col.caseInDept].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)Col.caseOper].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)Col.caseDept].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)Col.namen].Visible = false;//曾用名41
            this.neuSpread1_Sheet1.Columns[(int)Col.age].Visible = false;//年龄42
            this.neuSpread1_Sheet1.Columns[(int)Col.inSource].Visible = false;//地区来源43
            this.neuSpread1_Sheet1.Columns[(int)Col.areaCode].Visible = false;//出生地44
            this.neuSpread1_Sheet1.Columns[(int)Col.clinicDocName].Visible = false;//门诊诊断医生姓名45
            this.neuSpread1_Sheet1.Columns[(int)Col.comeFrom].Visible = false;//转来医院46
        }

        /// <summary>
        /// 设置列是否可编辑
        /// </summary>
        private void SetColLock(bool isValue)
        {
            int colRount = 0;
            colRount = this.neuSpread1_Sheet1.ColumnCount;
            if (colRount > 0)
            {
                for(int i=0;i<colRount;i++)
                {
                    this.neuSpread1_Sheet1.Columns[i].Locked = isValue;
                }

                if (Enumstus == enumStus.modify)
                {
                    this.neuSpread1_Sheet1.Columns[(int)Col.isChecked].Locked = false;
                }
            }
 
        }

        /// <summary>
        /// 根据住院流水号加载患者其他病案信息
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        private int GetPatientOtherCasInfo(string inpatientNO)
        {
            

            ////诊断
            //if (this.ucDocDiagnoseInput.LoadInfo(inpatientNO) == -1)
            //{
            //    return -1;
            //}
            try
            {
                if (inpatientNO == null || inpatientNO == "")
                {
                    MessageBox.Show("传入的住院流水号为空");
                    return -1;
                }
                Neusoft.HISFC.BizProcess.Integrate.RADT pa = new Neusoft.HISFC.BizProcess.Integrate.RADT();
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                CaseBase = baseDml.GetCaseBaseInfo(inpatientNO);

                if (CaseBase == null)
                {
                    CaseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
                    CaseBase.PatientInfo.ID = inpatientNO;
                }

                //1. 如果病案表中没有信息 则去住院表中去查询
                //2. 如果 住院主表中有记录则提取信息 写到界面上. 
                if (CaseBase.PatientInfo.ID == "" || CaseBase.OperInfo.OperTime == DateTime.MinValue)//病案主表中没有记录
                {
                    #region 病案中没有记录
                    patientInfo = pa.QueryPatientInfoByInpatientNO(inpatientNO);
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
                //this.frmType = Type;
                if (CaseBase.PatientInfo.CaseState == "0")
                {
                    MessageBox.Show("该病人不允许有病案");
                    return 0;
                }
                ////保存病案的状态
                //CaseFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(CaseBase.PatientInfo.CaseState);

                #region 病案室录入病历

                ConvertInfoToPanel(CaseBase);
                //this.SetReadOnly(true); //设为只读 

                #endregion
                /* {FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
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

                //诊断
                patientInfo.CaseState = CaseBase.PatientInfo.CaseState;
                patientInfo.ID = CaseBase.PatientInfo.ID;
                if (this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS) == -1)
                {
                    return -1;
                }

                //#endregion
                #region  妇婴卡
                this.ucBabyCardInput1.LoadInfo(CaseBase.PatientInfo);
                #endregion
                #region 手术
                this.ucOperation1.LoadInfo(CaseBase.PatientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
                #endregion
                #region  肿瘤
                this.ucTumourCard2.LoadInfo(CaseBase.PatientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
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
                 */

                ////显示基本信息
                //this.tabCasOtherInfo.SelectedIndex = 1;

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            

            return 1;
        }

        /// <summary>
        /// 更新病案状态(原编目时候用)
        /// </summary>
        /// <param name="caseUpdateStus"></param>
        /// <param name="sendState"></param>
        /// <param name="sendFlow"></param>
        /// <returns></returns>
        private int UpdateCaseStus(string caseUpdateStus,string sendState,string sendFlow)
        {
            #region {4CE659D4-ABB9-4c95-814A-D478421FA4DC}
            //string inpatientNO = "";
            //int rowCount = 0;
            //bool isChecked = false;
            //rowCount = this.neuSpread1_Sheet1.RowCount;
            //if (rowCount < 1)
            //{
            //    return 0;
            //}
            
            //Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //for (int i = 0; i < rowCount; i++)
            //{
            //    if (this.neuSpread1_Sheet1.Cells[i, (int)Col.isChecked].Text != "True")
            //    {
            //        continue;
            //    }
            //    isChecked = true;
            //    inpatientNO = this.neuSpread1_Sheet1.Cells[i, (int)Col.inpatientNO].Text;

            //    if (string.IsNullOrEmpty(inpatientNO))
            //    {
            //        string name = "";
            //        name = this.neuSpread1_Sheet1.Cells[i, (int)Col.name].Text;
            //        MessageBox.Show("没有取到" + name + "住院流水号!");

            //        return 0;
            //    }

            //   int iReturn =0;
            //   iReturn = baseDml.UpdateBaseCaseStus(inpatientNO, caseUpdateStus, sendState, sendFlow);

            //   if (iReturn == 0)
            //   {
            //       MessageBox.Show(this.neuSpread1_Sheet1.Cells[i,(int)Col.name].Text+"的病案可能没有整理,不能编目确认!");

            //       continue;
            //   }
            //   else if (iReturn < 0)
            //    {
            //        baseDml.Err = "更新患者病案状态信息失败!" + baseDml.ErrCode;

            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();

            //        MessageBox.Show(baseDml.Err);

            //        return -1;
            //    }

            //    //需要改结构,跟踪更多信息
            //    caseTrack.PatientCase.ID = this.neuSpread1_Sheet1.Cells[i, (int)Col.patientNO].Text; //病历号
            //    caseTrack.UseCaseEnv.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(caseTrackMgr.GetSysDateTime()); //操作时间
            //    caseTrack.UseCaseEnv.ID = emp.ID; //使用人编码
            //    caseTrack.UseCaseEnv.Dept.ID = emp.Dept.ID;//使用科室

            //    //caseTrack.SeqNO = inpatientNO; //住院流水号
            //    caseTrack.SendFlow = sendFlow;
            //    caseTrack.FlowState = sendState;
            //    caseTrack.PatientCase.CaseState.ID = caseUpdateStus;
            //    caseTrack.PatientCase.Patient.PID.ID = inpatientNO; //住院流水号

            //    //插入跟踪信息表
            //    //插入日志表
            //    if (caseTrackMgr.InsertTrackRecord(caseTrack, Neusoft.HISFC.BizLogic.HealthRecord.Case.EnumTrackType.CASE_LIST) == -1)
            //    {
            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //        MessageBox.Show("插入病案跟踪表出错!");

            //        return -1;
            //    }
            //}

            //Neusoft.FrameWork.Management.PublicTrans.Commit();

            //if (isChecked)
            //{
            //    MessageBox.Show("保存成功!");
            //}
            //else
            //{
            //    MessageBox.Show("没有需要更新病案信息!");
            //}
            #endregion
            return 1;
        }

        /// <summary>
        /// 导出数据 
        /// </summary>
        private void Export()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "";

                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //以Excel 的形式导出数据
                    
                    ret = this.neuSpread1.SaveExcel(saveFileDialog1.FileName,FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                    if (ret)
                    {
                        MessageBox.Show("导出成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                //出错了
                MessageBox.Show(ex.Message);
            }
        }

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
                txtNomen.Text = info.Nomen;
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
                txtComeFrom.Text = info.ComeFrom;
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
                    //txtInfectNum.Text = Convert.ToString(this.ucDocDiagnoseInput.ge .ucDiagNoseInput1.GetInfectionNum());
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
        #region 设置为只读
        /// <summary>
        /// 设置为只读
        /// </summary>
        /// <param name="type"></param> 
        public void SetReadOnly(bool type)
        {
            //this.ucDocDiagnoseInput.SetReadOnly(type);
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
            txtComeFrom.ReadOnly = type;
            txtComeFrom.BackColor = System.Drawing.Color.White;
            //曾用名
            txtNomen.ReadOnly = type;
            txtNomen.BackColor = System.Drawing.Color.White;
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
            ////病案质量
            //txtMrQual.ReadOnly = type;
            //txtMrQual.EnterVisiable = !type;
            //txtMrQual.BackColor = System.Drawing.Color.White;
            ////质控医师
            //txtQcDocd.ReadOnly = type;
            //txtQcDocd.EnterVisiable = !type;
            //txtQcDocd.BackColor = System.Drawing.Color.White;
            ////质控护士
            //txtQcNucd.ReadOnly = type;
            //txtQcNucd.EnterVisiable = !type;
            //txtQcNucd.BackColor = System.Drawing.Color.White;
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
            ////质控时间
            //txtCheckDate.Enabled = !type;
            //实习医生
            txtPraDocCode.ReadOnly = type;
            txtPraDocCode.EnterVisiable = !type;
            txtPraDocCode.BackColor = System.Drawing.Color.White;
            ////编码员
            //txtCodingCode.ReadOnly = type;
            //txtCodingCode.EnterVisiable = !type;
            //txtCodingCode.BackColor = System.Drawing.Color.White;
            ////整理员 
            //txtCoordinate.ReadOnly = type;
            //txtCoordinate.EnterVisiable = !type;
            //txtCoordinate.BackColor = System.Drawing.Color.White;
            //this.txtOperationCode.ReadOnly = type;
            //txtOperationCode.EnterVisiable = !type;
            //this.txtOperationCode.BackColor = System.Drawing.Color.White;
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
            ////输入员
            //txtInputDoc.ReadOnly = type;
            //txtInputDoc.EnterVisiable = !type;
            //txtInputDoc.BackColor = System.Drawing.Color.White;
            txtInfectionPosition.Enabled = !type;

        }
        #endregion
        #region 质控信息保存

        #endregion

        /// <summary>
        /// 工具条:"设置列"按钮的处理函数
        /// </summary>
        private void SetColumn()
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.SetDataTable(this.filePath, this.neuSpread1_Sheet1);
            uc.DisplayEvent += new EventHandler(uc_DisplayEvent);
            uc.IsShowUpDonw = false;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.filePath);

        }

        void uc_DisplayEvent(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据...", false);
            Application.DoEvents();
            CreateEmptyDS();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void CreateEmptyDS()
        {
            if (System.IO.File.Exists(this.filePath))
            {
                //this.dataTable = new DataTable();
                XmlDocument doc = new XmlDocument();
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(this.filePath, System.Text.Encoding.Default);
                    string streamXml = sr.ReadToEnd();
                    sr.Close();
                    doc.LoadXml(streamXml);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("读取Xml配置文件发生错误 请检查配置文件是否正确") + ex.Message);
                    return;
                }

                XmlNodeList nodes = doc.SelectNodes("//Column");

                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["visible"].Value == "false")
                    {

                        int colIndex = 0;
                        colIndex = FindIndex(neuSpread1_Sheet1, node.Attributes["displayname"].Value);
                        if (colIndex == -1)
                        {
                            return;
                        }
                        this.neuSpread1_Sheet1.Columns[colIndex].Visible = false;
                    }
                }
            }
                    
        }

        /// <summary>
        /// 根据列名找列索引
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        private int FindIndex(FarPoint.Win.Spread.SheetView sheetView ,string colName)
        {
            if (sheetView.ColumnCount > 0)
            {
                for (int i = 0; i<sheetView.ColumnCount; i++)
                {
                    if (sheetView.Columns[i].Label == colName)
                    {
                        return i;
                    }
                }
 
            }
            return -1;
 
        }
        
        /// <summary>
        /// 清空右键菜单
        /// </summary>
        private void ClearMenu()
        {
            //this.ucDiagNoseInput1.ClearMenu();
            //this.ucOperation1.ClearMenu();
            //this.ucChangeDept1.ClearMenu();
            //this.ucBabyCardInput1.ClearMenu();
            //this.ucTumourCard2.ClearMenu();
        }        

        #region 清空所有数据
        /// <summary>
        /// 清空所有数据
        /// </summary>
        public void ClearInfo()
        {
            try
            {
                //this.ucDocDiagnoseInput.ClearInfo();
                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                if (this.isInitOps)
                {
                    this.ucOperation1.ClearInfo();
                }
                if (this.isInitTumour)
                {
                    this.ucTumourCard2.ClearInfo();
                }
                if (this.isInitChange)
                {
                    this.ucChangeDept1.ClearInfo();
                }
                if (this.isInitBaby)
                {
                    this.ucBabyCardInput1.ClearInfo();
                }
                if (this.isInitFee)
                {
                    this.ucFeeInfo1.ClearInfo();
                }
                if (this.isInitDiag)
                {
                    this.ucDiagNoseInput1.ClearInfo();
                }
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
                txtComeFrom.Text = "";
                //曾用名
                txtNomen.Text = "";
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
                ////呼吸机使用时间
                //this.txtAPNEA_USETIME.Text = "";
                ////入院前时间 小时
                //this.txtPRE_COMAHOUR.Text = "";
                ////入院前时间 分钟
                //this.txtPRE_COMAMIN.Text = "";
                ////入院后时间  小时
                //this.txtSITH_COMAHOUR.Text = "";
                ////入院后时间 分钟
                //this.txtSITH_COMAMIN.Text = "";
                ////离院方式
                //this.txtLEAVE_HOSPITAL.Text = "";
                ////转入医院名称
                //this.txtTRANSFER_HOSPITAL.Text = "";

                //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
                this.CaseBase = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #endregion

        #region 事件
        private void neuButton1_Click(object sender, EventArgs e)
        {
            
            this.ucQueryCondition1.SaveCondtion();
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            
            //this.ucQueryCondition1.ClearAll();
            this.ucQueryCondition1.RefreshList();
            //this.ucQueryCondition1.AddNewRow();
                     
        }

        private void neuSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            string inpatientNO = "";
            //inpatientNO = this.neuSpread1_Sheet1.Cells[Neusoft.FrameWork.Function.NConvert.ToInt32(neuSpread1_Sheet1.ActiveRow), (int)Col.name].ToString();
            int currentrow = 0;
            currentrow = neuSpread1_Sheet1.ActiveRowIndex;
            if (currentrow < 0)
            {
                return;
            }

            inpatientNO = this.neuSpread1_Sheet1.Cells[currentrow, (int)Col.inpatientNO].Text;
            //{FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询
            if (this.CaseBase != null && this.CaseBase.PatientInfo.ID == inpatientNO)
            {
                return;
            }
            if (string.IsNullOrEmpty(inpatientNO))
            {
                return;
            }
            if (GetPatientOtherCasInfo(inpatientNO) == -1)
            {
                return;
            }

            //判断是否可以修改病案诊断            
            if (enumstus == enumStus.modify)
            {
                bool isBool = false;
                if (this.neuSpread1_Sheet1.Cells[currentrow, (int)Col.casStus].Text == "6")
                {
                    isBool = false;
                    //this.ucDocDiagnoseInput.IsList = true;
                }
                else
                {
                    isBool = true;
                    //this.ucDocDiagnoseInput.IsList = true;
                }
                //this.ucDocDiagnoseInput.OnlyModifyDiagType(true, isBool); //如果不能编目确认，诊断类型也不能修改

            }

        }

        private void tvConditinon_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvConditinon.SelectedNode.Tag.ToString() == "0")
            {
                return;
            }
            this.ucQueryCondition1.ReadConditionByID(e.Node.Tag.ToString());

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvConditinon.SelectedNode.Tag == null || tvConditinon.SelectedNode.Tag.ToString() == "0")
            {
                return;
            }

            if (MessageBox.Show("是否删除" + tvConditinon.SelectedNode.Text + "?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            this.ucQueryCondition1.DeleteCondtion(tvConditinon.SelectedNode.Tag.ToString());

            tvConditinon.Nodes.Remove(tvConditinon.SelectedNode);

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvConditinon.SelectedNode.Tag == null || tvConditinon.SelectedNode.Tag.ToString() == "0")
            {
                return;
            }

            this.tvConditinon.LabelEdit = true;
            this.tvConditinon.SelectedNode.BeginEdit();
        }

        private void tvConditinon_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //if(this.tvConditinon.Tag)

        }

        private void tvConditinon_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            if (this.tvConditinon.LabelEdit)
            {

            //    //if (MessageBox.Show("模板名称变化，是否保存?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            //    //{
            //    //    return;
            //    //}

            //    if (this.ucQueryCondition1.UpdateCondtion(this.tvConditinon.SelectedNode.Tag.ToString(), this.tvConditinon.SelectedNode.Text) == -1)
            //    {
            //        MessageBox.Show("保存模板失败!");

            //        return;
            //    }
            //    InitTreeView();

            //    //this.tvConditinon.SelectedNode.EndEdit(true);
              
            //    this.tvConditinon.LabelEdit = false;

            //    //MessageBox.Show("保存模板成功!");

            }
        }

        private void ucQueryCondition2_Load(object sender, EventArgs e)
        {

        }

        private void neuButton1_Click_1(object sender, EventArgs e)
        {
            SetColumn();
        }

        private void neuButton2_Click_1(object sender, EventArgs e)
        {
            CreateEmptyDS();
        }      
       
        #endregion          
      
        #region {FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询

        private bool isInitDiag = false;
        private bool isInitOps = false;
        private bool isInitBaby = false;
        private bool isInitChange = false;
        private bool isInitTumour = false;
        private bool isInitFee = false;

        public override int Exit(object sender, object neuObject)
        {
            try
            {
                if (this.FindForm() != null)
                {
                    this.FindForm().Dispose();
                }
                this.Dispose();
                GC.Collect();
            }
            catch
            {
            }
            return base.Exit(sender, neuObject);
        }
        
        private void tabCasOtherInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitOtherCaseInfo();
            ShowOtherCaseInfo();
        }

        private void ShowOtherCaseInfo()
        {
            if (this.CaseBase == null || string.IsNullOrEmpty(this.CaseBase.PatientInfo.ID))
            {
                return;
            }
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            if (this.tabCasOtherInfo.SelectedIndex == 2)
            {
                //诊断
                patientInfo.CaseState = CaseBase.PatientInfo.CaseState;
                patientInfo.ID = CaseBase.PatientInfo.ID;
                if (this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS) == -1)
                {
                    return;
                }

            }
            else if (this.tabCasOtherInfo.SelectedIndex == 3)
            {
                this.ucOperation1.LoadInfo(CaseBase.PatientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 4)
            {
                this.ucBabyCardInput1.LoadInfo(CaseBase.PatientInfo);
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 5)
            {
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
                this.ucChangeDept1.LoadInfo(CaseBase.PatientInfo, changeDept);
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 6)
            {
                this.ucTumourCard2.LoadInfo(CaseBase.PatientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 7)
            {
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
            }
        }

        private void InitOtherCaseInfo()
        {
            if (this.tabCasOtherInfo.SelectedIndex == 2)
            {
                if (!this.isInitDiag)
                {
                    this.ucDiagNoseInput1.InitInfo();
                    this.isInitDiag = true;
                }
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 3)
            {
                if (!this.isInitOps)
                {
                    this.ucOperation1.InitInfo();
                    ucOperation1.InitICDList();
                    this.isInitOps = true;
                }
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 4)
            {
                if (!this.isInitBaby)
                {
                    this.ucBabyCardInput1.InitInfo();
                    this.isInitBaby = true;
                }
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 5)
            {
                if (!this.isInitChange)
                {
                    this.ucChangeDept1.InitInfo();
                    this.isInitChange = true;
                }
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 6)
            {
                if (!this.isInitTumour)
                {
                    this.ucTumourCard2.InitInfo();
                    this.isInitTumour = true;
                }
            }
            else if (this.tabCasOtherInfo.SelectedIndex == 7)
            {
                if (!this.isInitFee)
                {
                    this.ucFeeInfo1.InitInfo();
                    this.isInitFee = true;
                }
            }
        }
        #endregion

 

    }
}