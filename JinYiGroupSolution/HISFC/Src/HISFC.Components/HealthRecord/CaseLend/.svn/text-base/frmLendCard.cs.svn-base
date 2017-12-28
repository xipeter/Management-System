using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Object.HealthRecord.EnumServer;
namespace UFC.HealthRecord.CaseLend
{
    public partial class frmLendCard : Form
    {
        public frmLendCard()
        {
            InitializeComponent();
        }
        #region 全局变量
        private Neusoft.HISFC.Management.HealthRecord.CaseCard card = new Neusoft.HISFC.Management.HealthRecord.CaseCard();
        private Neusoft.HISFC.Management.HealthRecord.Base baseDml = new Neusoft.HISFC.Management.HealthRecord.Base();
        private System.Data.DataTable dt = null;
        private ArrayList Caselist = null;
        //借阅卡信息 
        private Neusoft.HISFC.Object.HealthRecord.ReadCard Cardinfo = null;
        //病案信息
        private Neusoft.HISFC.Object.HealthRecord.Base PatientCaseInfo = null;
        #endregion
        private void caseNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (this.caseNo.Text == "")
                    {
                        this.caseNo.Focus();

                        MessageBox.Show("请输入病案号");
                        return;
                    }
                    Caselist = null;
                    Caselist = baseDml.QueryCaseBaseInfoByCaseNO(this.caseNo.Text);
                    if (Caselist == null)
                    {
                        MessageBox.Show("查询病案信息出错");
                        return;
                    }
                    if (Caselist.Count == 0)
                    {
                        MessageBox.Show("没有查到相关信息");
                        return;
                    }
                    //判断是否已经借出了 
                    Neusoft.HISFC.Object.HealthRecord.Base info = (Neusoft.HISFC.Object.HealthRecord.Base)Caselist[0];
                    if (info.LendStat == "O") //是字母 O 
                    {
                        MessageBox.Show("该病案已经借出.");
                        return;
                    }
                    AddTableInfo(Caselist);
                    this.CardNO.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void AddTableInfo(ArrayList list)
        {
            dt.Clear();
            int i = 0;
            foreach (Neusoft.HISFC.Object.HealthRecord.Base info in list)
            {
                string Sex = "";
                if (info.PatientInfo.Sex.ID != null)
                {
                    if (info.PatientInfo.Sex.ID.ToString() == "M")
                    {
                        Sex = "男";
                    }
                    else if (info.PatientInfo.Sex.ID.ToString() == "F")
                    {
                        Sex = "女";
                    }
                }
                if (i == 0)
                {
                    PatientCaseInfo = info.Clone(); //复制
                    SetInfo(PatientCaseInfo);
                    i++;
                }
                dt.Rows.Add(new object[] {info.PatientInfo.PID.PatientNO,
										   info.PatientInfo.Name,
										   Sex,
										   info.InDept.Name,
										   info.OutDept.Name,
										   info.PatientInfo.PVisit.InTime,
										   info.PatientInfo.PVisit.OutTime ,
										   info.PatientInfo.Birthday,
										   info.PatientInfo.InTimes.ToString()
										  });
            }

            this.fpSpread1_Sheet1.Columns[0].Width = 60;
            this.fpSpread1_Sheet1.Columns[1].Width = 60;
            this.fpSpread1_Sheet1.Columns[2].Width = 30;
            this.fpSpread1_Sheet1.Columns[3].Width = 60;
            this.fpSpread1_Sheet1.Columns[4].Width = 60;
            this.fpSpread1_Sheet1.Columns[5].Width = 60;
            this.fpSpread1_Sheet1.Columns[6].Width = 60;
            this.fpSpread1_Sheet1.Columns[7].Width = 60;
            this.fpSpread1_Sheet1.Columns[8].Width = 60;

        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(Neusoft.HISFC.Object.HealthRecord.Base info)
        {
            string Sex = "";
            if (info.PatientInfo.Sex.ID != null)
            {
                if (info.PatientInfo.Sex.ID.ToString() == "M")
                {
                    Sex = "男";
                }
                else if (info.PatientInfo.Sex.ID.ToString() == "F")
                {
                    Sex = "女";
                }
            }
            caseNo.Text = info.CaseNO;
            txName.Text = info.PatientInfo.Name;
            txSex.Text = Sex;
            txDeptIn.Text = info.InDept.Name;
            txDeptOut.Text = info.OutDept.ID;
            dtInDate.Text = info.PatientInfo.PVisit.InTime.ToString();
            dtOutDate.Text = info.PatientInfo.PVisit.OutTime.ToString();
            dtBirthDate.Text = info.PatientInfo.Birthday.ToString();
        }
        /// <summary>
        /// 清空病案信息
        /// </summary>
        private void ClearCase()
        {
            caseNo.Text = "";
            txName.Text = "";
            txSex.Text = "";
            txDeptIn.Text = "";
            txDeptOut.Text = "";
            dtInDate.Text = "";
            dtOutDate.Text = "";
            dtBirthDate.Text = "";
            if (dt != null)
            {
                dt.Clear();
            }
        }
        /// <summary>
        /// 清空人员信息
        /// </summary>
        private void ClearPerson()
        {
            CardNO.Text = "";
            comPerson.Text = "";
            //			txDays.Text = "";
            comType.Text = "";
            txReturnTime.Value = Convert.ToDateTime("3000-1-1");
        }
        private void frmLendCard_Load(object sender, System.EventArgs e)
        {
            InitDateTable();
            Neusoft.HISFC.Management.Manager.Person person = new Neusoft.HISFC.Management.Manager.Person();
            //获取人员列表
            ArrayList DoctorList = person.GetEmployeeAll();
            this.comPerson.AppendItems(DoctorList);
            txReturnTime.Value = Neusoft.NFC.Function.NConvert.ToDateTime(baseDml.GetSysDate()).AddDays(14);
            comPerson.BackColor = System.Drawing.Color.White;
        }
        private void InitDateTable()
        {
            dt = new System.Data.DataTable();
            Type strType = typeof(System.String);
            Type intType = typeof(System.Int32);
            Type dtType = typeof(System.DateTime);
            Type boolType = typeof(System.Boolean);

            dt.Columns.AddRange(new DataColumn[]{   new DataColumn("病案号", strType),
													new DataColumn("姓名", strType),
													new DataColumn("性别", strType),
													new DataColumn("入院科室", strType),
													new DataColumn("出院科室", strType),
													new DataColumn("入院日期", dtType),
													new DataColumn("出院日期", dtType),
													new DataColumn("出生日期", dtType),
													new DataColumn("次数", intType)});
            this.fpSpread1_Sheet1.DataSource = dt;
        }

        private void CardNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (CardNO.Text == "")
                {
                    CardNO.Focus();
                    MessageBox.Show("请输入卡号");
                    return;
                }
                Cardinfo = null;
                Cardinfo = card.GetCardInfo(this.CardNO.Text);
                if (Cardinfo == null)
                {
                    MessageBox.Show("查询出错");
                    return;
                }
                if (Cardinfo.CardID == null || Cardinfo.CardID == "")
                {
                    MessageBox.Show("没有查到该卡号的相关信息");
                    return;
                }
                CardNO.Text = Cardinfo.CardID;
                comPerson.Text = Cardinfo.EmployeeInfo.Name;
                comPerson.Tag = Cardinfo.EmployeeInfo.ID;
                //				this.txDays.Focus();
                this.comType.Focus();
            }
        }

        private int ValidState(Neusoft.HISFC.Object.HealthRecord.Lend obj)
        {
            if (CardNO.Text == null && CardNO.Text == "")
            {
                MessageBox.Show("请输入借阅卡号");
                return -1;
            }
            if (caseNo.Text == null && caseNo.Text == "")
            {
                MessageBox.Show("请输入借阅卡号");
                return -1;
            }
            if (comType.Text == "")
            {
                MessageBox.Show("借阅方式");
                return -1;
            }
            if(this.txReturnTime.Value <= System.DateTime.Now)
            {
                MessageBox.Show("预计归还日期不能小于当前时间");
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 借出操作 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLend_Click(object sender, System.EventArgs e)
        {
            //首先判断是否已经借出了，如果借出了没有归还则不能再外借
            //借出操作 
            Neusoft.HISFC.Object.HealthRecord.Lend obj = GetLendInfo();
            if (obj == null)
            {
                return;
            }
            if (ValidState(obj) == -1)
            {
                return;
            }
            Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(card.Connection);
            trans.BeginTransaction();
            card.SetTrans(trans.Trans);
            if (card.LendCase(obj) < 1)
            {
                trans.RollBack();
                MessageBox.Show("插入借阅记录失败: " + card.Err);
                return;
            }
            if (card.UpdateBase(LendType.O, obj.CaseBase.CaseNO) <= 0)
            {
                trans.RollBack();
                MessageBox.Show("更新病案主表失败");
                return;
            }
            trans.Commit();
            MessageBox.Show("操作成功");
            this.ClearCase();
            this.ClearPerson();
            this.caseNo.Focus();
        }
        private Neusoft.HISFC.Object.HealthRecord.Lend GetLendInfo()
        {
            if (PatientCaseInfo == null)
            {
                MessageBox.Show("请选择借阅的病案信息");
                return null;
            }
            if (Cardinfo == null)
            {
                MessageBox.Show("请选择借阅的病案信息");
                return null;
            } 
            Neusoft.HISFC.Object.HealthRecord.Lend Saveinfo = new Neusoft.HISFC.Object.HealthRecord.Lend();
            Saveinfo.SeqNO = this.card.GetSequence("Case.CaseCard.LendCase.Seq");
            if (Saveinfo.SeqNO == null || Saveinfo.SeqNO == "")
            {
                MessageBox.Show("获取序号失败");
                return null;
            }
            Saveinfo.CaseBase.CaseNO = PatientCaseInfo.CaseNO;
            Saveinfo.CaseBase.PatientInfo.ID = PatientCaseInfo.PatientInfo.ID;//住院流水号
            Saveinfo.CaseBase.CaseNO = PatientCaseInfo.CaseNO;//病人住院号 
            Saveinfo.CaseBase.PatientInfo.Name = PatientCaseInfo.PatientInfo.Name; //病人姓名
            Saveinfo.CaseBase.PatientInfo.Sex.ID = PatientCaseInfo.PatientInfo.Sex.ID;//性别
            Saveinfo.CaseBase.PatientInfo.Birthday = PatientCaseInfo.PatientInfo.Birthday;//出生日期
            Saveinfo.CaseBase.PatientInfo.PVisit.InTime = PatientCaseInfo.PatientInfo.PVisit.InTime;//入院日期
            Saveinfo.CaseBase.PatientInfo.PVisit.OutTime = PatientCaseInfo.PatientInfo.PVisit.OutTime;//出院日期
            Saveinfo.CaseBase.InDept.ID = PatientCaseInfo.InDept.ID; //入院科室代码
            Saveinfo.CaseBase.InDept.Name = PatientCaseInfo.InDept.Name; //入院科室名称
            Saveinfo.CaseBase.OutDept.ID = PatientCaseInfo.OutDept.ID;  //出院科室代码
            Saveinfo.CaseBase.OutDept.Name = PatientCaseInfo.OutDept.Name; //出院科室名称
            Saveinfo.EmployeeInfo.ID = Cardinfo.EmployeeInfo.ID;//借阅人代号
            Saveinfo.EmployeeInfo.Name = Cardinfo.EmployeeInfo.Name;//借阅人姓名
            Saveinfo.EmployeeDept.ID = Cardinfo.DeptInfo.ID; //借阅人所在科室代码
            Saveinfo.EmployeeDept.Name = Cardinfo.DeptInfo.Name; //借阅人所在科室名称
            Saveinfo.LendDate = Neusoft.NFC.Function.NConvert.ToDateTime(baseDml.GetSysDate()); //借阅日期
            Saveinfo.PrerDate = txReturnTime.Value; //预定还期
            if (this.comType.Text == "内借")
            {
                Saveinfo.LendKind = "1"; ; //借阅性质
            }
            else if (this.comType.Text == "外借")
            {
                Saveinfo.LendKind = "2"; ; //借阅性质
            }
            Saveinfo.LendStus = "1"; ;//病历状态 1借出/2返还
            Saveinfo.ID = baseDml.Operator.ID; //操作员代号
            Saveinfo.OperInfo.OperTime = Neusoft.NFC.Function.NConvert.ToDateTime(baseDml.GetSysDate()); //操作时间
            Saveinfo.ReturnOperInfo.ID = "";   //归还操作员代号
            Saveinfo.ReturnDate = Neusoft.NFC.Function.NConvert.ToDateTime("3000-1-1");   //实际归还日期
            Saveinfo.CardNO = CardNO.Text;//卡号
            return Saveinfo;
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            PatientCaseInfo = (Neusoft.HISFC.Object.HealthRecord.Base)Caselist[this.fpSpread1_Sheet1.ActiveRowIndex];
            SetInfo(PatientCaseInfo);
        }

        private void comType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txReturnTime.Focus();
            }
        }

        private void txReturnTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                tbLend_Click(sender, e);
            }
        }
    }
}