using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.WinForms.Report.InPatientInfo
{
    /// <summary>
    /// [功能描述: 患者情况查询]<br></br>
    /// [创 建 者: 张琦]<br></br>
    /// [创建时间: 2007-9-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucInpatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInpatientInfo()
        {
            InitializeComponent();
        }

        #region 变量

        #region 业务相关
        /// <summary>
        /// 住院入出转业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        /// <summary>
        /// 人员业务集成层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager empManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 科室业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 人员信息业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 常数业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient feeManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 当前患者
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo currentPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();


        /// <summary>
        /// 患者信息查询
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient queryPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        /// <summary>
        /// Tab
        /// </summary>
        protected Hashtable hashTableFp = new Hashtable();
        #endregion
        
        #region DataTable相关

        /// <summary>
        /// 患者主信息
        /// </summary>
        DataTable dtMainPatientInfo = new DataTable();

        /// <summary>
        /// 患者主信息视图
        /// </summary>
        DataView dvMainPatientInfo = new DataView();

        /// <summary>
        /// 患者诊断信息
        /// </summary>
        DataTable dtPatientDiagnore = new DataTable();

        /// <summary>
        /// 患者诊断信息视图
        /// </summary>
        DataView dvPatientDiagnore = new DataView();

        /// <summary>
        /// 出院患者信息
        /// </summary>
        DataTable dtPatientOutHos = new DataTable();

        /// <summary>
        /// 出院患者信息视图
        /// </summary>
        DataView dvPatientOutHos = new DataView();

        /// <summary>
        /// 住院患者退号信息
        /// </summary>
        DataTable dtPatientNoFee = new DataTable();

        /// <summary>
        /// 住院患者退号信息视图
        /// </summary>
        DataView dvPatientNoFee = new DataView();
        #endregion

        #region 查询相关变量
        /// <summary>
        /// 患者状态
        /// </summary>
        string inState = string.Empty;
        /// <summary>
        /// 科室代码
        /// </summary>
        string deptCode = string.Empty;//住院科室编码
        /// <summary>
        /// 医生代码
        /// </summary>
        string docCode = string.Empty;//医生编码编码
        /// <summary>
        /// 开始时间
        /// </summary>
        string beginTime = string.Empty;
        /// <summary>
        /// 结束时间
        /// </summary>
        string endTime = string.Empty;
        /// <summary>
        /// 诊断名称
        /// </summary>
        string diagnoreName = string.Empty;

        #endregion

        #endregion

        #region 初始化函数

        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucInpatientInfo_Load(object sender, EventArgs e)
        {
            //默认显示患者信息
            this.neuTabControl1.SelectedTab = this.tabPage1;
            this.Init();
        }

        /// <summary>
        /// 初始化 
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Init()
        {
            //初始化科室
            if (this.InitDept() == -1)
            {
                return -1;
            }

            //初始化患者状态
            if (this.InitInState() == -1)
            {
                return -1;
            }

            if (this.InitNoFee() == -1)
            {
                return -1;
            }
            if (this.InitDoc() == -1)
            {
                return -1;
            }
            if (this.InitOutHos() == -1)
            {
                return -1;
            }
            if (this.InitPatient()== -1)
            {
                return -1;
            }
            if (this.InitDiagnore() == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 初始化患者状态
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitInState()
        {
            ArrayList inStateList = Neusoft.HISFC.Models.RADT.InStateEnumService.List();

            this.cmbState.AddItems(inStateList);
            return 1;
        }

        /// <summary>
        /// 初始化科室
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDept()
        {
            int findAll = 0;
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();

            objAll.ID = "%";
            objAll.Name = "全部";

            ArrayList deptList = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            if (deptList == null)
            {
                MessageBox.Show(Language.Msg("加载科室列表出错!") + this.deptManager.Err);

                return -1;
            }

            deptList.Add(objAll);

            findAll = deptList.IndexOf(objAll);

            this.cmbDept.AddItems(deptList);

            if (findAll >= 0)
            {
                this.cmbDept.SelectedIndex = findAll;
            }

            return 1;
        }

        /// <summary>
        /// 初始化医生列表
        /// </summary>
        /// <returns></returns>
        private int InitDoc()
        {
            ArrayList docList = this.empManager.QueryEmployeeAll();
            if (docList == null)
            {
                MessageBox.Show(Language.Msg("加载医生列表出错!") + this.deptManager.Err);

                return -1;
            }
            this.cmbDoc.AddItems(docList);
            return 1;
        }

        Type str = typeof(String);
        Type date = typeof(DateTime);
        Type dec = typeof(Decimal);
        Type bo = typeof(bool);

        #region 住院主表信息初始化
        private int InitPatient()
        {
            
            this.dtMainPatientInfo.Columns.AddRange(new DataColumn[]{new DataColumn("住院流水号", str),
																new DataColumn("住院号", str),
																new DataColumn("姓名", str),
																new DataColumn("住院科室", str),
																new DataColumn("床号", str),
																new DataColumn("患者类别", str),
																new DataColumn("预交金(未结)", dec),
																new DataColumn("费用合计(未结)", dec),
																new DataColumn("余额", dec),
																new DataColumn("自费", dec),
																new DataColumn("自负", dec),
																new DataColumn("公费", dec),
																new DataColumn("入院日期", date),
																new DataColumn("在院状态", str),
																new DataColumn("出院日期", str),
																new DataColumn("预交金(已结)", dec),
																new DataColumn("费用合计(已结)", dec),
																new DataColumn("结算日期", date)/*,
																new DataColumn("医疗类别", str)*/});

            dtMainPatientInfo.PrimaryKey = new DataColumn[] { dtMainPatientInfo.Columns["住院流水号"] };

            dvMainPatientInfo = new DataView(dtMainPatientInfo);

            this.neuSpread1_Sheet1.DataSource = dvMainPatientInfo;
            return 1;
        }

        #endregion

        #region 患者诊断

        private int InitDiagnore()
        {
            this.dtPatientDiagnore.Columns.AddRange(new DataColumn[] {new DataColumn("住院号",str), 
                new DataColumn("姓名",str),new DataColumn("性别",str),new DataColumn("年龄",str),
                new DataColumn("科室",str),new DataColumn("入院日期",date),new DataColumn("出院日期",date),
                new DataColumn("主要诊断",str)}
               );
            //dtPatientDiagnore.PrimaryKey = new DataColumn[] { dtPatientDiagnore.Columns["住院号"] };
            dvPatientDiagnore = new DataView(dtPatientDiagnore);
            this.neuSpread2_Sheet1.DataSource = dtPatientDiagnore;
            return 1;
        }

        #endregion

        #region 出院患者情况

        private int InitOutHos()
        {
            this.dtPatientOutHos.Columns.AddRange(new DataColumn[] { new DataColumn("床号",str),
            new DataColumn("住院号",str),new DataColumn("姓名",str),new DataColumn("性别",str),
                new DataColumn("科室",str),new DataColumn("入院日期",date),new DataColumn("出院日期",date)});
            dtPatientOutHos.PrimaryKey = new DataColumn[] { dtPatientOutHos.Columns["住院号"] };
            dvPatientOutHos = new DataView(dtPatientOutHos);
            this.neuSpread3_Sheet1.DataSource = dtPatientOutHos;
            return 1;
        }
        #endregion
      
        #region 入院患者退号情况
        private int InitNoFee()
        {
            this.dtPatientNoFee.Columns.AddRange(new DataColumn[] {
             new DataColumn("住院号",str),new DataColumn("姓名",str),new DataColumn("出院科别",str),
             new DataColumn("入院日期",date),new DataColumn("退号日期",date)});
            dtPatientNoFee.PrimaryKey = new DataColumn[] { dtPatientNoFee.Columns["住院号"] };
            this.neuSpread4_Sheet1.DataSource = dtPatientNoFee;
            return 1;
        }
        #endregion

        #endregion

        #region 查询事件

        /// <summary>
        /// 复合查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (this.cmbState.Text == null)
            {
                 MessageBox.Show(Language.Msg("请输入患者的查询状态!"));
                return;
            }
            if (this.cmbDept.Text == string.Empty || this.cmbDept.Text == "全部")
            {
                deptCode = "ALL";
                this.cmbDept.Text = "全部";
            }
            else
            {
                deptCode = this.cmbDept.Tag.ToString();
            }
            //医生代码
            if (this.cmbDoc.Text == string.Empty)
            {
                docCode = "ALL";
            }
            else
            {
                docCode = this.cmbDoc.Tag.ToString();
            }
            //患者状态
            inState = this.cmbState.Tag.ToString();

            Cursor.Current = Cursors.WaitCursor;

            //函数调用判断
            if (this.cmbState.Text == "出院登记完成,结算状态")
            {
                inState = "B";
                this.neuTextBox2.Enabled = true;
                this.cmbDoc.Enabled = true;
                this.beginTime = this.dtBeginTime.Value.ToString();
                this.endTime = this.dtEndTime.Value.ToString();
                this.neuTabControl1.SelectedTab = this.tabPage3;
                this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);
                ////判断是进行诊断查询还是出院患者信息查询
                //if (this.cmbDoc.Text != string.Empty)//默认为出院患者查询
                //{
                //    this.neuTextBox2.Enabled = true;
                //    //docCode = this.cmbDoc.Tag.ToString();
                //    this.neuTabControl1.SelectedTab = this.tabPage3;
                //    this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);                   
                //}
                //else if (this.cmbDoc.Text == string.Empty)//判断是否为诊断查询
                //{
                //    this.neuTextBox2.Enabled = true;
                //    this.cmbDoc.Enabled = true;
                //    if (this.neuTextBox2.Text != string.Empty)//默认为诊断查询
                //    {
                //        this.cmbDoc.Enabled = false;
                //        this.diagnoreName = this.neuTextBox2.Text;
                //        this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                //        this.neuTabControl1.SelectedTab = this.tabPage2;
                //    }
                //    else if (this.neuTextBox2.Text == string.Empty)//查询出院患者信息和诊断信息
                //    {
                //        this.cmbDoc.Enabled = true;
                //        this.neuTextBox2.Enabled = true;
                //        docCode = "ALL";
                //        this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                //        this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);
                //    }
                //}
            }
            else if (this.cmbState.Text == "出院结算完成")
            {
                this.inState = "O";
                this.beginTime = this.dtBeginTime.Value.ToString();
                this.endTime = this.dtEndTime.Value.ToString();
                this.diagnoreName = this.neuTextBox2.Text;
                this.neuTabControl1.SelectedTab = this.tabPage3;
                this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);
                //if (this.cmbDoc.Text != string.Empty)//默认为出院患者查询
                //{
                //    this.neuTextBox2.Enabled = true;
                //    docCode = this.cmbDoc.Tag.ToString();
                //    this.neuTabControl1.SelectedTab = this.tabPage3;
                //    this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);
                //}
                //else if (this.cmbDoc.Text == string.Empty)//判断是否为诊断查询
                //{
                //    this.neuTextBox2.Enabled = true;
                //    this.cmbDoc.Enabled = true;
                //    if (this.neuTextBox2.Text != string.Empty)//默认为诊断查询
                //    {
                //        this.cmbDoc.Enabled = false;
                //        this.diagnoreName = this.neuTextBox2.Text;
                //        this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                //        this.neuTabControl1.SelectedTab = this.tabPage2;
                //    }
                //    else if (this.neuTextBox2.Text == string.Empty)//查询出院患者信息和诊断信息
                //    {
                //        this.cmbDoc.Enabled = true;
                //        this.neuTextBox2.Enabled = true;
                //        docCode = "ALL";
                //        this.QueryPatientDiagnore(deptCode, diagnoreName, beginTime, endTime);
                //        this.QueryPatientOutHos(inState, deptCode, docCode, beginTime, endTime);
                //    }
                //}
            }
              else if (this.cmbState.Text == "无费退院")
                {
                    this.beginTime = this.dtBeginTime.Value.ToString();
                    this.endTime = this.dtEndTime.Value.ToString();
                    this.neuTabControl1.SelectedTab = tabPage4;
                    this.QueryPatientNoFee(deptCode, beginTime, endTime);
                }
                Cursor.Current = Cursors.Arrow;
            //this.Clear();
        }

        /// <summary>
        /// 简单查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btQuery_Click(object sender, EventArgs e)
        {
            if (this.ucQueryInpatientNo1.Text.Length > 0)
            {
                this.ucQueryInpatientNo1_myEvent();
                this.neuTabControl1.SelectedTab = this.tabPage1;
            }
            else//认为输入姓名查询
            {
                this.QueryPatientByName();
                this.neuTabControl1.SelectedTab = this.tabPage1;
            }
            //this.Clear();
        }

        /// <summary>
        /// 双击显示患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1_Sheet1.RowCount <= 0)
            {
                return;
            }
            string inpatientNO = this.neuSpread1_Sheet1.Cells[e.Row, 0].Text;

            if (inpatientNO == null)
            {
                return;
            }

            this.currentPatient = this.radtManager.QueryPatientInfoByInpatientNO(inpatientNO);
            if (this.currentPatient == null || this.currentPatient.ID == null || this.currentPatient.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("查询患者基本信息出错!") + this.radtManager.Err);

                return;
            }

            //设置查询时间
            DateTime beginTime = this.currentPatient.PVisit.InTime;
            DateTime endTime = this.radtManager.GetDateTimeFromSysDateTime();

            this.QueryAllInformation(beginTime, endTime);
        }

        /// <summary>
        /// 事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.QueryPatientByInpatientNO();
        }
        #endregion

        #region 功能实现

        #region 患者信息

        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="patients">患者信息列表</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QueryPatient(ArrayList patients)
        {
            this.dtMainPatientInfo.Rows.Clear();

            Cursor.Current = Cursors.WaitCursor;
            //住院主表信息
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patients)
            {
                this.SetPatientToFpMain(patient);
            }

            Cursor.Current = Cursors.Arrow;

            if (patients.Count == 1)
            {
                this.currentPatient = (Neusoft.HISFC.Models.RADT.PatientInfo)patients[0];
               // this.SetPatientInfo();
                this.ucQueryInpatientNo1.Text = this.currentPatient.ID.Substring(4);
                //设置查询时间
                //设置查询时间
                DateTime beginTime = this.currentPatient.PVisit.InTime;
                DateTime endTime = this.radtManager.GetDateTimeFromSysDateTime();

                this.QueryAllInformation(beginTime, endTime);
            }
            this.neuSpread1_Sheet1.Columns[13].Width = 180;
            return 1;
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="patient">成功 1 失败 -1</param>
        private void SetPatientToFpMain(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DataRow row = this.dtMainPatientInfo.NewRow();

            try
            {

                row["住院流水号"] = patient.ID;
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] = patient.Name;
                row["住院科室"] = patient.PVisit.PatientLocation.Dept.Name;
                row["床号"] = patient.PVisit.PatientLocation.Bed.ID;
                row["患者类别"] = patient.Pact.Name;
                row["预交金(未结)"] = patient.FT.PrepayCost;
                row["费用合计(未结)"] = patient.FT.TotCost;
                row["余额"] = patient.FT.LeftCost;
                row["自费"] = patient.FT.OwnCost;
                row["自负"] = patient.FT.PayCost;
                row["公费"] = patient.FT.PubCost;
                row["入院日期"] = patient.PVisit.InTime;
                row["在院状态"] = patient.PVisit.InState.Name;

                row["出院日期"] = patient.PVisit.OutTime.Date == new DateTime(1, 1, 1).Date ? string.Empty : patient.PVisit.OutTime.ToString();

                row["预交金(已结)"] = patient.FT.BalancedPrepayCost;
                row["费用合计(已结)"] = patient.FT.BalancedCost;
                //row["医疗类别"] = patient.PVisit.MedicalType.Name;
                row["结算日期"] = patient.BalanceDate;

                this.dtMainPatientInfo.Rows.Add(row);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        /// <summary>
        /// 根据输入的住院号查询患者基本信息
        /// </summary>
        private void QueryPatientByInpatientNO()
        {
            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo == string.Empty)
            {
                MessageBox.Show(Language.Msg("您输入的住院号错误,请重新输入!"));
                this.Clear();

                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.radtManager.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo);
            if (patientInfo == null || patientInfo.ID == null || patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("获取患者基本信息出错!") + this.radtManager.Err);
                this.Clear();
                return;
            } 

            this.neuTextBox1.Text = patientInfo.Name;
            this.btSearch.Focus();

            ArrayList patientListTemp = new ArrayList();

            patientListTemp.Add(patientInfo);

            this.QueryPatient(patientListTemp);

            //lvxl
            //this.QueryPatientDiagnore(patientInfo.PVisit.PatientLocation.Dept.ID,
        }

        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        protected void QueryAllInformation(DateTime beginTime, DateTime endTime)
        {
            //this.GetQueryItem();
            //this.QueryPatientDiagnore(beginTime, endTime);

            //this.QueryPatientOutHos(beginTime, endTime);

            //this.QueryPatientNoFee(beginTime, endTime);

           // this.QueryPatientBalance(beginTime, endTime);
        }

        /// <summary>
        /// 根据输入的患者姓名查询患者基本信息
        /// </summary>
        private void QueryPatientByName()
        {
            if (this.neuTextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("输入姓名不能为空!"));
                this.neuTextBox1.Focus();

                return;
            }

            string inputName = "%" + this.neuTextBox1.Text.Trim() + "%";
            //去掉特殊字符
            inputName = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(inputName, "'");
            //按照姓名直接查询患者想细信息
            string name = this.neuTextBox1.Text;
            ArrayList patientListTemp = this.radtManager.QueryPatientInfoByName(inputName);
            if (patientListTemp == null || patientListTemp.Count == 0)
            {
                MessageBox.Show(Language.Msg("无此患者信息!") + this.radtManager.Err);

                this.Clear();
                this.neuTextBox1.Text = name;
                return;
            }

            if (patientListTemp.Count > 0)
            {
                this.Clear();
                this.neuTextBox1.Text = name;
                this.QueryPatient(patientListTemp);
            }

            return;
        }

        /// <summary>
        /// 诊断查询
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="diagnoreName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void QueryPatientDiagnore(string deptCode, string diagnoreName, string beginTime, string endTime)
        {
            dtPatientDiagnore.Clear();
            ArrayList patientDiagnore = this.queryPatient.PatientDiagnoreQuery(deptCode, diagnoreName, beginTime, endTime);
            if (patientDiagnore == null)
            {
                MessageBox.Show(Language.Msg("获得患者诊断出错!") + this.queryPatient.Err);
                return;
            }
            foreach(Neusoft.HISFC.Models.RADT.PatientInfo patient in patientDiagnore)
            {
                DataRow row = dtPatientDiagnore.NewRow();
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] =patient.Name;
                row["性别"] =patient.Sex.ID;
                row["年龄"] =patient.Age;
                row["科室"] =patient.PVisit.PatientLocation.Dept.Name;
                row["入院日期"] =patient.PVisit.InTime.ToString();
                row["出院日期"] =patient.PVisit.OutTime.ToString();
                row["主要诊断"] = patient.MainDiagnose;
                this.dtPatientDiagnore.Rows.Add(row);
            }
        }

        /// <summary>
        /// 出院患者查询
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="docCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void QueryPatientOutHos(string inState, string deptCode, string docCode, string beginTime, string endTime)
        {
            this.dtPatientOutHos.Rows.Clear();
            ArrayList OutHosPatient = this.queryPatient.PatientOutHosQuery(inState, deptCode, docCode, beginTime, endTime);
            if (OutHosPatient == null)
            {
                MessageBox.Show(Language.Msg("获取出院患者信息出错!") + this.queryPatient.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in OutHosPatient)
            {
                DataRow row = this.dtPatientOutHos.NewRow();
                row["床号"] = patient.PVisit.PatientLocation.Bed.ID;
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] = patient.Name;
                row["性别"] = patient.Sex.ID;
                row["科室"] = patient.PVisit.PatientLocation.Dept.Name;
                row["入院日期"] = patient.PVisit.InTime.ToString();
                row["出院日期"] = patient.PVisit.OutTime.ToString();
                this.dtPatientOutHos.Rows.Add(row);
            }
        }

        /// <summary>
        /// 住院患者退号查询
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void QueryPatientNoFee(string deptCode, string beginTime, string endTime)
        {
            this.dtPatientNoFee.Rows.Clear();
            ArrayList NoFeePatient = this.queryPatient.PatientNoFeeQuery(deptCode, beginTime, endTime);
            if (NoFeePatient == null)
            {
                MessageBox.Show(Language.Msg("获取无费患者信息出错!") + this.queryPatient.Err);
                return;
            }
            
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in NoFeePatient)
            {
                DataRow row = this.dtPatientNoFee.NewRow();
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] = patient.Name;
                row["出院科别"] = patient.PVisit.PatientLocation.Dept.Name;
                row["入院日期"] = patient.PVisit.InTime.ToString();
                row["退号日期"] = patient.PVisit.OutTime.ToString();
                dtPatientNoFee.Rows.Add(row);
            }
        }

        #endregion


        #region 公共函数
        /// <summary>
        /// 清空函数
        /// </summary>
        private void Clear()
        {
            this.cmbDept.Text="";
            this.cmbDoc.Text="";
            this.cmbState.Text = "";
            this.ucQueryInpatientNo1.Text = "";
            this.neuTextBox1.Text = "";
            this.dtBeginTime.Value = this.radtManager.GetDateTimeFromSysDateTime();
            this.dtEndTime.Value = this.radtManager.GetDateTimeFromSysDateTime();
            //{F7217BB5-C76E-45a0-9AB0-0D536C8993D1} lvxl 2010-3-11
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                //this.neuSpread1_Sheet1.Rows.Clear();
                dtMainPatientInfo.Clear();
            }
            if (this.neuSpread2_Sheet1.Rows.Count > 0)
            {
                //this.neuSpread2_Sheet1.Rows.Clear();
                dtPatientDiagnore.Clear();
            }
            if (this.neuSpread3_Sheet1.Rows.Count > 0)
            {
                //this.neuSpread3_Sheet1.Rows.Clear();
                dtPatientOutHos.Clear();
            }
            if (this.neuSpread4_Sheet1.Rows.Count > 0)
            {
                //this.neuSpread4_Sheet1.Rows.Clear();
                dtPatientNoFee.Clear();
            }
        }

        #endregion

        /// <summary>
        /// 设置查询的时间框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbState.Text == "出院登记完成,结算状态")
            {
                this.neuTabControl1.SelectedTab = this.tabPage3;
                this.neuTextBox2.Enabled = false;
                this.cmbDoc.Enabled = true;
                this.cmbDept.Enabled = true;
                this.dtBeginTime.Enabled = true;
                this.dtEndTime.Enabled = true;
                this.btSearch.Enabled = true;
            }
            else if (this.cmbState.Text == "出院结算完成")
            {
                this.neuTabControl1.SelectedTab = this.tabPage2;
                this.neuTextBox2.Enabled = true;
                this.cmbDoc.Enabled = true;
                this.cmbDept.Enabled = true;
                this.dtBeginTime.Enabled = true;
                this.dtEndTime.Enabled = true;
                this.btSearch.Enabled = true;
            }
            else if (this.cmbState.Text == "无费退院")
            {
                this.neuTabControl1.SelectedTab = this.tabPage4;
                this.cmbDoc.Enabled = false;
                this.neuTextBox2.Enabled = false;
                this.cmbDept.Enabled = true;
                this.dtBeginTime.Enabled = true;
                this.dtEndTime.Enabled = true;
                this.btSearch.Enabled = true;
            }
            else
            {
                this.cmbDept.Enabled = false;
                this.cmbDoc.Enabled = false;
                this.dtBeginTime.Enabled = false;
                this.dtEndTime.Enabled = false;
                this.neuTextBox2.Enabled = false;
                this.btSearch.Enabled = false;
            }
        }

        #endregion
    }
}
