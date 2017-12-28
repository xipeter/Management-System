using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucShowPatients<br></br>
    /// [功能描述: 输入的卡号多于一个患者选择患者UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-2-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucShowPatients : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucShowPatients()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNO = string.Empty;

        /// <summary>
        /// /符合条件的挂号信息条目
        /// </summary>
        private int personCount;
        
        /// <summary>
        /// 控制参数管理类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper controlerHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 挂号信息实体
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register patientInfo = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 门诊业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 体检业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager examiIntegrate = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager();

        /// <summary>
        /// 控制业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 当选择单条患者信息
        /// </summary>
        public delegate void GetPatient(Neusoft.HISFC.Models.Registration.Register register);

        /// <summary>
        /// 当选择单条患者信息后触发
        /// </summary>
        public event GetPatient SelectedPatient;

        /// <summary>
        /// 原始卡号
        /// </summary>
        private string orgCardNO = string.Empty;

        /// <summary>
        /// 输入卡号或者姓名方式
        /// </summary>
        public string operType = "1";//1 直接输入患者卡号或方号 2 输入/+姓名

        /// <summary>
        ///  患者姓名
        /// </summary>
        private string regName;

        /// <summary>
        /// 挂号有效期限
        /// </summary>
        private int validDays = 10000;

        /// <summary>
        /// 挂号处方号有效天数
        /// </summary>
        private int recipeNOValidDays = 10000;

        /// <summary>
        /// 是否用挂号处方号代的卡号检索患者基本信息
        /// </summary>
        private bool isUseRecipeNOReplaceCardNO = false;

        #endregion

        #region 属性

        /// <summary>
        /// 挂号处方号有效天数
        /// </summary>
        public int RecipeNOValidDays
        {
            get
            {
                return this.recipeNOValidDays;
            }
            set
            {
                this.recipeNOValidDays = value;
            }
        }

        /// <summary>
        /// 是否用挂号处方号代的卡号检索患者基本信息
        /// </summary>
        public bool IsUseRecipeNOReplaceCardNO
        {
            get
            {
                return this.isUseRecipeNOReplaceCardNO;
            }
            set
            {
                this.isUseRecipeNOReplaceCardNO = value;
            }
        }

        /// <summary>
        /// 挂号有效期限
        /// </summary>
        public int ValidDays
        {
            get
            {
                return this.validDays;
            }
            set
            {
                this.validDays = value;
            }
        }

        /// <summary>
        /// 原始卡号,不补0
        /// </summary>
        public string OrgCardNO
        {
            set
            {
                this.orgCardNO = value;
            }
        }

        /// <summary>
        /// 患者挂号卡号
        /// </summary>
        public string CardNO
        {
            get
            {
                return this.cardNO;
            }
            set
            {
                try
                {
                    this.cardNO = value;
                    if (this.cardNO == string.Empty || this.cardNO == null)
                    {
                        return;
                    }
                    //根据cardNO 获得符合条件的挂号信息
                    FillPatientInfoByCardNO();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + this.Name.ToString());
                }
            }
        }

        /// <summary>
        /// 符合条件的挂号信息条目
        /// </summary>
        public int PersonCount
        {
            get
            {
                return this.personCount;
            }
        }

        /// <summary>
        /// 选定的患者的挂号基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                this.patientInfo = value;
            }
        }

        /// <summary>
        /// 控制参数管理类
        /// </summary>
        public Neusoft.FrameWork.Public.ObjectHelper ControlerHelper
        {
            set
            {
                this.controlerHelper = value;
            }
            get
            {
                return this.controlerHelper;
            }
        }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string RegName
        {
            get
            {
                return this.regName;
            }
            set
            {
                this.regName = value;
                if (this.regName != null && this.regName.Length > 0)
                {
                    //this.FillPatientInfoByName();
                }
            }
        }

        #endregion

        #region 函数

        /// <summary>
        /// 获得符合条件的患者信息
        /// </summary>
        /// <param name="cardNO">患者挂号卡号</param>
        /// <returns>符合条件的挂号信息集合</returns>
        private ArrayList QueryPatientInfosByCardNO(string cardNO)
        {
            ArrayList patients = null;

            this.validDays = this.controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.VALID_REG_DAYS, false, 10000);

            if (this.validDays == 0)
            {
                this.validDays = 10000;//如果没有维护，那么默认挂号一直有效;
            }

            //获得当前系统时间
            DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();

            //获得有效天数内的挂号信息
            patients = this.registerManager.QueryValidPatientsByCardNO(cardNO, nowTime.AddDays(-validDays));
            
            //如果没有复合条件的挂号信息.生成一个空ArrayList
            if (patients == null)
            {
                patients = new ArrayList();
            }

            #region 没有整理而屏蔽
           
            ////体检登记信息.
            ArrayList checkPatients = new ArrayList();

            //获得体检信息 
            checkPatients = QueryCheckPatients(cardNO);

            //如果获得了体检信息，那么添加
            if (checkPatients != null)
            {
                patients.AddRange(checkPatients);
            }
            //else   //{5CFE4556-5B65-4c45-B9F4-3AE9A5681562}
            //{
            //    patients = null;
            //}

            #endregion

            //获得参数,是否需要用门诊挂号处方号检索患者信息

            this.isUseRecipeNOReplaceCardNO = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.REG_RECIPE_NO_RELPACE_CARD_NO, false, false);

            //需要
            if (this.isUseRecipeNOReplaceCardNO)
            {
                try
                {
                    long orgCardNumber = System.Convert.ToInt64(this.orgCardNO);
                }
                catch(Exception e) 
                {
                    MessageBox.Show("转换门诊处方号出错!不是合法数字" + e.Message);

                    return null;
                }

                this.recipeNOValidDays = this.controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.REG_RECIPE_NO_VALID_DAYS, false, 10000);

                ArrayList recipePatients = registerManager.QueryValidPatientsBySeeNO(this.orgCardNO, nowTime.AddDays(-recipeNOValidDays));
                if (recipePatients == null)
                {
                    MessageBox.Show("根据处方号获得患者信息出错!" + registerManager.Err);

                    return null;
                }
                else
                {
                    patients.AddRange(recipePatients);
                }
            }

            return patients;
        }

        #region 没有整理而屏蔽

        /// <summary>
        /// 获得体检患者的基本信息，转换成挂号实体后，同患者的挂号信息合并
        /// </summary>
        /// <param name="cardNO">患者的体检号</param>
        /// <returns>经过转换的挂号信息实体</returns>
        private ArrayList QueryCheckPatients(string cardNO)
        {
            ArrayList checkPatients = new ArrayList();

            checkPatients = this.examiIntegrate.QueryCollectivityRegisterByCardNO(cardNO);

            if (checkPatients == null)
            {
                return null;
            }
            ArrayList alChkToRegInfos = new ArrayList();

            foreach (Neusoft.HISFC.Models.PhysicalExamination.Register chkRegister in checkPatients)
            {
                Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();

                register.ID = chkRegister.ChkClinicNo; //
                register.PID.CardNO = chkRegister.PID.CardNO;//门诊卡号
                register.Name = chkRegister.Name;//患者姓名
                register.Sex.ID = chkRegister.Sex.ID;//性别
                register.MaritalStatus = chkRegister.MaritalStatus;//婚姻状况
                register.Country = chkRegister.Country;//国家
                register.Height = chkRegister.Height;//身高
                register.Weight = chkRegister.Weight;//体重
                register.ChkKind = chkRegister.ChkKind;//1 集体 2 个人
                register.CompanyName = chkRegister.Company.Name;//单位
                register.SSN = chkRegister.SSN;//医疗证号
                register.DoctorInfo.SeeDate = chkRegister.CheckTime;//体检日期
                register.IDCard = chkRegister.IDCard;//身份证号
                register.Birthday = chkRegister.Birthday;//生日
                register.Profession = chkRegister.Profession;//职业
                register.PhoneBusiness = chkRegister.PhoneBusiness;//单位电话
                register.BusinessZip = chkRegister.BusinessZip;//单位邮政编码
                register.AddressHome = chkRegister.AddressHome;//家庭住址
                register.PhoneHome = chkRegister.PhoneHome;//家庭电话
                register.HomeZip = chkRegister.HomeZip;//家庭邮政编码
                register.Nationality = chkRegister.Nationality;//民族
                register.Pact.PayKind = chkRegister.Pact.PayKind;//结算类别
                register.DIST = chkRegister.DIST;//籍贯
                register.Pact.ID = "1";//自费
                register.Pact.PayKind.ID = "01";
                register.DoctorInfo.Templet.Dept = chkRegister.Operator.Dept;

                alChkToRegInfos.Add(register);
            }

            return alChkToRegInfos;
        }

        #endregion

        /// <summary>
        /// 将符合条件的患者信息显示在列表中，如果只有一条，则不显示该控件，直接患者患者的挂号实体
        /// </summary>
        private void FillPatientInfoByCardNO()
        {
            ArrayList patients = this.QueryPatientInfosByCardNO(this.cardNO);

            DisplayPatients(patients);
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="patients">查询出来的患者列表</param>
        private void DisplayPatients(ArrayList patients)
        {
            //获得患者基本信息出错
            if (patients == null)
            {
                this.personCount = 0;
                this.patientInfo = null;
                this.SelectedPatient(null);

                return;
            }
            //没有找到符合条件的患者信息
            if (patients.Count == 0)
            {
                this.personCount = 0;
                this.patientInfo = null;
                this.SelectedPatient(null);

                return;
            }
            //如果只找到一个符合条件的患者信息，那么不显示控件，直接返回患者的挂号实体
            if (patients.Count == 1)
            {
                this.personCount = 1;
                this.patientInfo = patients[0] as Neusoft.HISFC.Models.Registration.Register;
                this.SelectedPatient(this.patientInfo);

                return;
            }
            //如果有多个符合条件的患者信息，在控件的列表中显示基本信息，挂号实体邦定在改行的tag属性中
            this.neuSpread1_Sheet1.RowCount = 1; //默认只有一行
            Neusoft.HISFC.Models.Registration.Register patient = null;
            this.Show();
      
            this.personCount = patients.Count;

            this.neuSpread1_Sheet1.RowCount = personCount;
            int index = 0;
            for (int i = personCount - 1; i >= 0; i--)
            {
                patient = patients[i] as Neusoft.HISFC.Models.Registration.Register;

                this.neuSpread1_Sheet1.Cells[index, 0].Text = patient.OrderNO.ToString();
                this.neuSpread1_Sheet1.Cells[index, 0 + 1].Text = patient.PID.CardNO;
                this.neuSpread1_Sheet1.Cells[index, 1 + 1].Text = patient.Name;
                this.neuSpread1_Sheet1.Cells[index, 2 + 1].Text = patient.DoctorInfo.Templet.Dept.Name;
                this.neuSpread1_Sheet1.Cells[index, 3 + 1].Text = patient.DoctorInfo.Templet.RegLevel.Name;
                this.neuSpread1_Sheet1.Cells[index, 4 + 1].Text = patient.DoctorInfo.SeeDate.ToString();
                if (patient.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid)
                {
                    this.neuSpread1_Sheet1.Cells[index, 5 + 1].Text = "有效";
                }
                else if (patient.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
                {
                    this.neuSpread1_Sheet1.Cells[index, 5 + 1].ForeColor = Color.Red;
                    this.neuSpread1_Sheet1.Cells[index, 5 + 1].Text = "作废";
                }
                else if (patient.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back)
                {
                    this.neuSpread1_Sheet1.Cells[index, 5 + 1].ForeColor = Color.Red;
                    this.neuSpread1_Sheet1.Cells[index, 5 + 1].Text = "退费";
                }
                ArrayList chargeItems = new ArrayList();
                chargeItems = this.outpatientManager.QueryChargedFeeItemListsByClinicNO(patient.ID);
                if (chargeItems != null && chargeItems.Count > 0)
                {
                    this.neuSpread1_Sheet1.Rows[index].Label = "有";
                    this.neuSpread1_Sheet1.RowHeader.Rows[index].BackColor = Color.Green;
                }
                this.neuSpread1_Sheet1.Rows[index].Tag = patient;

                index++;
            }
        }

        /// <summary>
        /// 双击，回车等选择患者
        /// </summary>
        /// <param name="row">当前行</param>
        private void SelectPatient(int row)
        {
            this.SelectedPatient((Neusoft.HISFC.Models.Registration.Register)this.neuSpread1_Sheet1.Rows[row].Tag);
            this.FindForm().Close();
        }

        /// <summary>
        /// 将符合条件的患者信息显示在列表中，如果只有一条，则不显示该控件，直接患者患者的挂号实体
        /// </summary>
        private void FillPatientInfoByName()
        {
            ArrayList patients = this.QueryPatientsByName(this.regName);

            this.DisplayPatients(patients);
        }

        /// <summary>
        /// 根据患者姓名查询患者
        /// </summary>
        /// <param name="name">患者姓名</param>
        /// <returns>成功 返回符合条件的患者基本信息 失败返回null 没有查找到数据返回ArrayList.Count = 0</returns>
        private ArrayList QueryPatientsByName(string name)
        {
            if (this.validDays == 0)
            {
                this.validDays = 10000;//如果没有维护，那么默认挂号一直有效;
            }

            ArrayList patients = this.registerManager.QueryValidPatientsByName(this.regName);

            //如果没有复合条件的挂号信息.生成一个空ArrayList
            if (patients == null)
            {
                MessageBox.Show("根据患者姓名获得信息出错" + this.registerManager.Err);

                patients = new ArrayList();
            }

            return patients;
        }

        #endregion 

        /// <summary>
        /// 双击FP事件,选择当前患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int row = e.Row;
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                if (this.neuSpread1_Sheet1.Rows[row].Tag != null)
                {
                    this.SelectPatient(row);
                }
            }
        }

        /// <summary>
        /// FP回车事件 ,选择当前患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    if (this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag != null)
                    {
                        //如果是卡号选择方式,那么选中当前行
                        if (this.operType == "1")
                        {
                            this.SelectPatient(this.neuSpread1_Sheet1.ActiveRowIndex);
                        }
                        else//如果是姓名选择方式,如果选择的行数大于1 那么选择当前行
                        {
                            if (this.neuSpread1_Sheet1.SelectionCount >= 1)
                            {
                                this.SelectPatient(this.neuSpread1_Sheet1.ActiveRowIndex);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.operType == "1")
                {
                    this.FindForm().Close();
                    this.SelectedPatient(null);
                }
                else
                {
                    this.FindForm().Close();
                    this.SelectedPatient(this.patientInfo);
                }
            }
            else if (keyData == Keys.Enter)
            {
                if (this.operType == "2")
                {
                    this.FindForm().Close();
                    SelectedPatient(this.patientInfo);
                }
            }
            
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 当控件获得焦点的时候,让FP获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucShowPatients_Enter(object sender, EventArgs e)
        {
            this.neuSpread1.Focus();
        }
    }
}
