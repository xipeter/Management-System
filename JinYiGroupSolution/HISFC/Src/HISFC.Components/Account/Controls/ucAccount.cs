using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Account;
using Neusoft.HISFC.BizProcess.Interface.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucAccount : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucAccount()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 帐户实体
        /// </summary>
        private Neusoft.HISFC.Models.Account.Account account = null;
        
        /// <summary>
        /// 帐户业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        
        /// <summary>
        /// 帐户交易实体
        /// </summary>
        private Neusoft.HISFC.Models.Account.AccountRecord accountRecord = null;
        
        /// <summary>
        /// 管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 费用综合业务层 
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        
        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        
        /// <summary>
        /// 门诊卡号
        /// </summary>
        HISFC.Models.Account.AccountCard accountCard = null;
        
        /// <summary>
        /// 错误信息
        /// </summary>
        string error = string.Empty;

        //支付方式 zhangyt-2011-03-01
        string payTypeName = string.Empty;
        /// <summary>
        /// 入出转
        /// </summary>
        HISFC.BizProcess.Integrate.RADT radtInteger = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper markHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 预交金处理（优惠处理）
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Account.IAccountProcessPrepay iAccountProcessPrepay = null;

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outPatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();
        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            //填充卡类型
            ArrayList al = managerIntegrate.GetConstantList("MarkType");
            this.cmbCardType.AddItems(al);
            markHelper.ArrayObject = al;
            //证件类型
            this.cmbIdCardType.AddItems(managerIntegrate.QueryConstantList("IDCard"));
            this.panelPatient.Visible = false;
            this.btnShow.Tag = this.panelPatient.Visible;
            this.ActiveControl = this.txtMarkNo;
            //初始化接口
            this.InitInterface();
            ucRegPatientInfo1.Enabled = false;
            ucRegPatientInfo1.IsShowTitle = false;
        }

        /// <summary>
        /// 查找帐户信息
        /// </summary>
        private  void GetAccountByMark()
        {  
            //检查帐户信息
            this.account = this.accountManager.GetAccountByMarkNo(accountCard.MarkNO);
            
            if (this.account != null)
            {
                this.txtVacancy.Text = this.account.Vacancy.ToString();

                //起用状态
                if (this.account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    
                    SetControlState(1);
                }
                //停用状态
                else if(this.account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    SetControlState(2);
                }
            }
            else
            {
                SetControlState(0);
                this.txtVacancy.Text = string.Empty;
            }
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="CardNo"></param>
        private void ShowPatienInfo(string CardNo)
        {
            this.ucRegPatientInfo1.CardNO = CardNo;
            HISFC.Models.RADT.PatientInfo patient = this.ucRegPatientInfo1.GetPatientInfomation();
            this.txtName.Text=patient.Name;
            this.txtSex.Text=patient.Sex.Name;
            this.txtAge.Text = accountManager.GetAge(patient.Birthday);
            this.txtIdCardNO.Text = patient.IDCard;

            this.cmbIdCardType.Tag = patient.IDCardType.ID;
            Neusoft.FrameWork.Models.NeuObject tempObj = null;
            tempObj = managerIntegrate.GetConstant(HISFC.Models.Base.EnumConstant.NATION.ToString(), patient.Nationality.ID);
            if (tempObj != null)
            {
                this.txtNation.Text = tempObj.Name;
            }
            //tempObj = managerIntegrate.GetConstant(HISFC.Models.Base.EnumConstant.COUNTRY.ToString(), patient.Country.ID);
            //if (tempObj != null)
            //{
            //    this.txtCountry.Text = tempObj.Name;
            //}
            this.txtCountry.Text = patient.PhoneHome;
            this.txtsiNo.Text = patient.SSN;
        }

        /// <summary>
        /// 根据帐户状态设置控件状态
        ///<param name="aMod">0:未建立帐户或以前帐户已经注销 1:帐户启用状态 2:帐户停用状态</param>
        /// </summary>
        private void SetControlState(int aMod)
        {
            switch (aMod)
            {
                case 0:
                    {
                        this.toolbarService.SetToolButtonEnabled("新建帐户", true);
                        this.toolbarService.SetToolButtonEnabled("收取", true);
                        this.toolbarService.SetToolButtonEnabled("返还", true);
                        this.toolbarService.SetToolButtonEnabled("补打", true);
                        this.toolbarService.SetToolButtonEnabled("停用帐户", false);
                        this.toolbarService.SetToolButtonEnabled("启用帐户", false);
                        this.toolbarService.SetToolButtonEnabled("注销帐户", false);
                        this.toolbarService.SetToolButtonEnabled("修改密码", false);
                        this.toolbarService.SetToolButtonEnabled("结清帐户", false);
                        this.txtpay.Enabled = true;
                        this.cmbPayType.Enabled = true;
                        break;
                    }
                case 1:
                    {
                        this.toolbarService.SetToolButtonEnabled("新建帐户", false);
                        this.toolbarService.SetToolButtonEnabled("收取", true);
                        this.toolbarService.SetToolButtonEnabled("返还", true);
                        this.toolbarService.SetToolButtonEnabled("补打", true);
                        this.toolbarService.SetToolButtonEnabled("停用帐户", true);
                        this.toolbarService.SetToolButtonEnabled("启用帐户", false);
                        this.toolbarService.SetToolButtonEnabled("注销帐户", true);
                        this.toolbarService.SetToolButtonEnabled("修改密码", true);
                        this.toolbarService.SetToolButtonEnabled("结清帐户", true);
                        this.txtpay.Enabled = true;
                        this.cmbPayType.Enabled = true;
                        this.cmbPayType.Focus();
                        break;
                    }
                case 2:
                    {
                        this.toolbarService.SetToolButtonEnabled("新建帐户", false);
                        this.toolbarService.SetToolButtonEnabled("收取", false);
                        this.toolbarService.SetToolButtonEnabled("返还", false);
                        this.toolbarService.SetToolButtonEnabled("补打", false);
                        this.toolbarService.SetToolButtonEnabled("停用帐户", false);
                        this.toolbarService.SetToolButtonEnabled("启用帐户", true);
                        this.toolbarService.SetToolButtonEnabled("注销帐户", false);
                        this.toolbarService.SetToolButtonEnabled("修改密码", false);
                        this.toolbarService.SetToolButtonEnabled("结清帐户", true);
                        this.txtpay.Enabled = false;
                        this.cmbPayType.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 帐户实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Account.Account GetAccount()
        {
            try
            {
                //帐户信息
                account = new Neusoft.HISFC.Models.Account.Account();
                account.ID = accountManager.GetAccountNO();
                account.AccountCard = accountCard;
                ////帐户密码
                //ucEditPassWord uc = new ucEditPassWord(false);
                //Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
                //if (uc.FindForm().DialogResult != DialogResult.OK) return null;
                //加密密码
                //account.PassWord = uc.PwStr;
                account.PassWord = "111111";
                //是否可用
                account.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                return account;
            }
            catch 
            {
                MessageBox.Show("获取帐户信息失败！");
                return null;
            }
        }

        /// <summary>
        /// 得到卡的交易实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Account.AccountRecord GetAccountRecord()
        {
            try
            {
                //交易信息
                accountRecord = new Neusoft.HISFC.Models.Account.AccountRecord();
                accountRecord.AccountNO = this.account.ID;//帐号
                accountRecord.Patient = accountCard.Patient;//门诊卡号
                accountRecord.DeptCode = (accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;//科室编码
                accountRecord.Oper = accountManager.Operator.ID;//操作员
                accountRecord.OperTime = accountManager.GetDateTimeFromSysDateTime();//操作时间
                accountRecord.IsValid = true;//是否有效
                return accountRecord;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 清空显示数据
        /// </summary>
        private void Clear()
        {
            this.txtMarkNo.Text = string.Empty;
            this.cmbCardType.Tag = string.Empty;
            this.cmbCardType.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtAge.Text = string.Empty;
            this.cmbIdCardType.Tag = string.Empty;
            this.cmbIdCardType.Text = string.Empty;            
            this.txtIdCardNO.Text = string.Empty;
            this.txtNation.Text = string.Empty;
            this.txtCountry.Text = string.Empty;
            this.txtsiNo.Text = string.Empty;
            this.txtVacancy.Text = string.Empty;
            this.cmbPayType.Text = string.Empty;
            this.cmbPayType.Tag = string.Empty;
            this.txtpay.Text = string.Empty;
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }
            if (this.spcard.Rows.Count > 0)
            {
                this.spcard.Rows.Remove(0, this.spcard.Rows.Count);
            }

            if (this.spHistory.Rows.Count > 0)
            {
                this.spHistory.Rows.Remove(0, this.spHistory.Rows.Count);
            }

            this.account = null;
            this.accountCard = null;
            accountRecord = null;
            this.txtMarkNo.Focus();
        }

        /// <summary>
        /// 检查是否该用户是否授权
        /// </summary>
        /// <returns></returns>
        private bool IsEmpower()
        {
            AccountEmpower accountEmpower = new AccountEmpower();
            int resultValue = accountManager.QueryAccountEmpowerByEmpwoerCardNO(accountCard.Patient.PID.CardNO, ref accountEmpower);
            if (resultValue < 0)
            {
                MessageBox.Show("查找该用户的授权信息失败！");
                this.txtMarkNo.Text = string.Empty;
                this.txtMarkNo.Focus();
                return false;
            }
            if (resultValue > 0)
            {
                if (accountEmpower.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    MessageBox.Show("该用户已被授权，不能再建立帐户！");
                    this.txtMarkNo.Text = string.Empty;
                    this.txtMarkNo.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断证件号是否存在帐户
        /// </summary>
        /// <returns></returns>
        //private bool ValidIDCard()
        //{
        //    //判断证件号是否存在帐户
        //    ArrayList accountList = accountManager.GetAccountByIdNO(this.txtIdCardNO.Text.Trim(), this.cmbIdCardType.Tag.ToString());
        //    if (accountList == null)
        //    {
        //        MessageBox.Show("查找患者帐户信息失败！");
        //        return false;
        //    }
        //    //根据证件号查找患者帐户信息
        //    if (accountList.Count > 0)
        //    {
        //        MessageBox.Show("该" + this.cmbIdCardType.Text + "号已存在帐户！");
        //        return false;
        //    }
        //    return true;
        //}
    
        /// <summary>
        /// 新建立帐户
        /// </summary>
        protected virtual void NewAccount()
        {
            try
            {
                if (accountCard == null || accountCard.MarkNO == string.Empty)
                {
                    MessageBox.Show("请输入就诊卡号！", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (this.accountCard.Patient.Pact.PayKind.ID == "02")
                {
                    MessageBox.Show("医保用户不用开卡！");

                    return;
                }
                if (string.IsNullOrEmpty(accountCard.Patient.Name))
                {
                    MessageBox.Show("患者姓名不能为空，请补充患者基本信息！");
                    System.Windows.Forms.Form bf = new Form();
                    ucRegPatientInfoNew ucRegPatientInfoNew = new ucRegPatientInfoNew();
                    Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    bf.Controls.Add(ucRegPatientInfoNew);
                    bf.Name = "补全信息";
                    bf.Size = ucRegPatientInfoNew.Size;
                    bf.MaximumSize = bf.Size;
                    bf.MinimumSize = bf.Size;
                    ucRegPatientInfoNew.Dock = DockStyle.None;
                    bf.StartPosition = FormStartPosition.CenterScreen;
                    p.PID.CardNO = this.txtMarkNo.Text;//accountCard.Patient.PID.CardNO;
                    p.PhoneHome = this.txtCountry.Text;//accountCard.Patient.PhoneHome;
                    p.IDCard = this.txtIdCardNO.Text; //
                    ucRegPatientInfoNew.Patient = p;
                    ucRegPatientInfoNew.Init();
                    bf.ShowDialog();
                    this.ReadCard();
                    return;
                }

                //if (this.txtIdCardNO.Text == string.Empty)
                //{
                //    MessageBox.Show("请输入身份证号！");
                //    this.txtIdCardNO.Focus();
                //    return;
                //}

                //if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(this.txtIdCardNO.Text.Trim(), ref error) < 0)
                //{
                //    MessageBox.Show("身份证不合法，" + error);
                //    this.txtIdCardNO.Focus();
                //    this.txtIdCardNO.SelectAll();
                //    return;
                //}
                //判断证件号是否存在帐户
                //if (!ValidIDCard()) return;

                //判断帐户是否被授权

                if (!IsEmpower()) return;

                //获取帐户实体
                this.account = this.GetAccount();
                if (account == null) return;

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //更新患者基本信息
                //if (this.txtIdCardNO.Enabled)
                //{
                //    HISFC.Models.RADT.PatientInfo patient = accountCard.Patient;
                //    patient.IDCardType.ID = this.cmbIdCardType.Tag.ToString();
                //    patient.IDCard = this.txtIdCardNO.Text.Trim();
                //    //根据身份证号获取患者性别
                //    Neusoft.FrameWork.Models.NeuObject obj = Class.Function.GetSexFromIdNO(patient.IDCard, ref error);
                //    if (obj == null)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        MessageBox.Show(error);
                //        return;
                //    }
                //    patient.Sex.ID = obj.ID;
                //    //根据患者身份证号获取生日
                //    string birthdate = Class.Function.GetBirthDayFromIdNO(patient.IDCard, ref error);
                //    if (birthdate == "-1")
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        MessageBox.Show(error);
                //        return;
                //    }
                //    patient.Birthday = FrameWork.Function.NConvert.ToDateTime(birthdate);
                //    patient.Age = accountManager.GetAge(patient.Birthday);
                //    if (radtInteger.UpdatePatientInfo(patient) < 0)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        MessageBox.Show(radtInteger.Err);
                //        return;
                //    }

                //}
                //插入帐户表
                if (accountManager.InsertAccount(this.account) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //生成帐户流水信息
                this.accountRecord = this.GetAccountRecord();
                if (this.accountRecord != null)
                {
                    accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.NewAccount;
                    if (accountManager.InsertAccountRecord(accountRecord) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("建立帐户成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.SetControlState(1);
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //PrintCreateAccountRecipe(account);

        }
        
        /// <summary>
        /// 根据门诊帐户获取卡的交易记录
        /// </summary>
        /// <returns></returns>
        private void GetRecordToFp()
        {
            if (account == null) return;
            List<PrePay> list = this.accountManager.GetPrepayByAccountNO(account.ID,"0");
            if (list == null)
            {
                MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.SetAccountRecordToFp(list, this.neuSpread1_Sheet1);
        }

        /// <summary>
        /// 获取帐户预交金历史数据
        /// </summary>
        private void GetHistoryRecordToFp()
        {
            if (account == null) return;
            List<PrePay> list = this.accountManager.GetPrepayByAccountNO(account.ID, "1");
            if (list == null)
            {
                MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.SetAccountRecordToFp(list, this.spHistory);
        }

        /// <summary>
        /// 显示帐户预交金数据
        /// </summary>
        /// <param name="list">预交金数据</param>
        /// <param name="sheet">sheetView</param>
        private void SetAccountRecordToFp(List<PrePay> list, FarPoint.Win.Spread.SheetView sheet)
        {
            int count = sheet.Rows.Count;
            if (count > 0)
            {
                sheet.Rows.Remove(0, count);
            }
            foreach (PrePay prepay in list)
            {
                SetFp(prepay, sheet);
            }
        }

        /// <summary>
        /// 显示预交金信息
        /// </summary>
        /// <param name="prepay"></param>
        private void SetFp(PrePay prepay,FarPoint.Win.Spread.SheetView sheet)
        {
            int count = sheet.Rows.Count;
            sheet.Rows.Add(count, 1);
            sheet.Cells[count, 0].Text = prepay.InvoiceNO;
            if (prepay.FT.PrepayCost > 0)
            {
                sheet.Cells[count, 1].Text = "收取";
            }
            else
            {
                if (prepay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    sheet.Cells[count, 1].Text = "返还";

                }
                else if (prepay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                {
                    sheet.Cells[count, 1].Text = "补打";
                }
                else
                {
                    sheet.Cells[count, 1].Text = "收取";
                }
            }
            if (prepay.ValidState !=  Neusoft.HISFC.Models.Base.EnumValidState.Valid)
            {
                sheet.Cells[count, 1].ForeColor = Color.Red;
            }
            sheet.Cells[count, 2].Text = prepay.FT.PrepayCost.ToString();
            sheet.Cells[count, 3].Text = prepay.PrePayOper.OperTime.ToString();
            //
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
            empl = managerIntergrate.GetEmployeeInfo(prepay.PrePayOper.ID);

            if (empl == null)
            { prepay.PrePayOper.Name = ""; }
            else
            {
                prepay.PrePayOper.Name = empl.Name;
            }
            sheet.Cells[count, 4].Text = prepay.PrePayOper.Name;
            sheet.Rows[count].Tag = prepay;
        }

        /// <summary>
        /// 显示帐户卡信息
        /// </summary>
        private void GetCardRecordToFP()
        {
            if (this.spcard.Rows.Count > 0)
            {
                this.spcard.Rows.Remove(0, spcard.Rows.Count);
            }

            List<HISFC.Models.Account.AccountCard> list = accountManager.GetMarkList(accountCard.Patient.PID.CardNO);
            if (list == null && list.Count == 0) return;
            int rowIndex = 0;
            foreach (HISFC.Models.Account.AccountCard tempCard in list)
            {
                this.spcard.Rows.Add(this.spcard.Rows.Count, 1);
                rowIndex = this.spcard.Rows.Count - 1;
                this.spcard.Cells[rowIndex, 0].Text = tempCard.MarkNO;
                this.spcard.Cells[rowIndex, 1].Text = markHelper.GetName(tempCard.MarkType.ID);
                this.spcard.Cells[rowIndex, 2].Text = tempCard.IsValid.ToString();
            }
        }

        /// <summary>
        /// 输入就诊卡号获取帐户信息
        /// </summary>
        private void GetAccountInfo()
        {
            accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
            string markNO = this.txtMarkNo.Text.Trim();
            if (markNO == string.Empty)
            {
                MessageBox.Show("请输入就诊卡号！");
                return;
            }
            int resultValue = accountManager.GetCardByRule(markNO, ref accountCard);
            if (resultValue <= 0)
            {
                MessageBox.Show(accountManager.Err);
                this.Clear();
                return;
            }
            //帐户授权效验
            if (!this.IsEmpower())
            {
                this.Clear();
                accountCard = null;
                return;
            }
            this.txtMarkNo.Text = accountCard.MarkNO;
            this.cmbCardType.Tag = accountCard.MarkType.ID;
            //显示患者信息
            ShowPatienInfo(accountCard.Patient.PID.CardNO);
            //01 为身份证号，在常数维护中维护
            if (this.cmbIdCardType.Tag != null && this.cmbIdCardType.Tag.ToString() == "01" && this.txtIdCardNO.Text.Trim() != string.Empty)
            {
                this.txtIdCardNO.Enabled = false;
                this.cmbPayType.Focus();
            }
            else
            {
                this.txtIdCardNO.Enabled = true;
                this.cmbIdCardType.Tag = "01";//身份证号
                this.txtIdCardNO.Focus();
            }

            //查找帐户信息
            this.GetAccountByMark();
            //预交金记录
            GetRecordToFp();
            //就诊断卡记录
            GetCardRecordToFP();
            //预交金历史记录
            GetHistoryRecordToFp();
        }

        /// <summary>
        /// 回车处理
        /// </summary>
        protected virtual void ExecCmdKey() 
        {
            if (this.txtMarkNo.Focused)
            {
                GetAccountInfo();
                return;
            }
            //在支付方式中回车
            if (this.cmbPayType.Focused)
            {
                if (this.cmbPayType.Tag == null || this.cmbPayType.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show("请选择支付方式！", "提示");
                    return;
                }
                this.txtpay.Focus();
                this.txtpay.SelectAll();
                return;
            }
            if (this.txtIdCardNO.Focused)
            {
                this.cmbPayType.Focus();
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        protected virtual void EditPassword()
        {
            if (!ValidAccountCard()) return;
            ucEditPassWord uc = new ucEditPassWord(true);
            uc.Account = this.account;
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool ValidAccountCard()
        {
            if (accountCard == null || accountCard.MarkNO == string.Empty)
            {
                MessageBox.Show("请输入就诊卡号！", "提示", MessageBoxButtons.OK);
                this.txtMarkNo.Focus();
                this.txtMarkNo.SelectAll();
                return false;
            }
            account = accountManager.GetAccountByMarkNo(accountCard.MarkNO);
            if (account == null)
            {
                MessageBox.Show("该卡未建立帐户或帐户已注销，请建立帐户！", "提示");
                return false;
            }
            return true;
        }


        /// <summary>
        /// 支付预交金
        /// </summary>
        protected virtual void AccountPrePay()
        {
            #region 验证
            if (accountCard == null || accountCard.MarkNO == string.Empty)
            {
                MessageBox.Show("请输入就诊卡号！", "提示", MessageBoxButtons.OK);
                this.txtMarkNo.Focus();
                this.txtMarkNo.SelectAll();
                return;
            }
            if (this.cmbPayType.Tag == null || this.cmbPayType.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请选择支付方式！", "提示");
                this.cmbPayType.Focus();
                return;
            }
            decimal money = Neusoft.FrameWork.Function.NConvert.ToDecimal(txtpay.Text);
            if (money == 0)
            {
                MessageBox.Show("请输入交费金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpay.Focus();
                txtpay.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(accountCard.Patient.Name))
            {
                MessageBox.Show("患者姓名不能为空，请补充患者基本信息！");

                System.Windows.Forms.Form bf = new Form();
                ucRegPatientInfoNew ucRegPatientInfoNew = new ucRegPatientInfoNew();
                Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();
                bf.Controls.Add(ucRegPatientInfoNew);
                bf.Name = "补全信息";
                bf.Size = ucRegPatientInfoNew.Size;
                bf.MaximumSize = bf.Size;
                bf.MinimumSize = bf.Size;
                ucRegPatientInfoNew.Dock = DockStyle.None;
                bf.StartPosition = FormStartPosition.CenterScreen;
                p.PID.CardNO = this.txtMarkNo.Text;//accountCard.Patient.PID.CardNO;
                p.PhoneHome = this.txtCountry.Text;//accountCard.Patient.PhoneHome;
                p.IDCard = this.txtIdCardNO.Text; //
                ucRegPatientInfoNew.Patient = p;
                ucRegPatientInfoNew.Init();
                bf.ShowDialog();
                this.ReadCard();
                return;
            }

            if (string.IsNullOrEmpty(accountCard.Patient.IDCard) && string.IsNullOrEmpty(accountCard.Patient.PhoneHome))
            {
                MessageBox.Show("身份证号和电话号码不能全部为空，请补充患者基本信息！");
                return;

            }
            
            #endregion

            #region 第一次交费建立账户
            bool isHaveAccount = true;
            if (this.account == null)
            {


                isHaveAccount = false;
                this.account = this.GetAccount();
                if (account == null) return;
            }
            else
            {
                if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    MessageBox.Show("该账户已停用请启用后再交预交金！");
                    return;
                }
            }


            #endregion

            #region 获取发票号
            string invoiceNO = this.feeIntegrate.GetNewInvoiceNO("A");
            if (invoiceNO == null || invoiceNO == string.Empty)
            {
                MessageBox.Show("获得发票号出错!" + this.feeIntegrate.Err);
                return;
            }
            #endregion

            #region 预交金实体
            HISFC.Models.Account.PrePay prePay = new Neusoft.HISFC.Models.Account.PrePay();
            prePay.Patient = accountCard.Patient;//this.ucRegPatientInfo1.GetPatientInfomation();//患者基本信息
            prePay.PayType.ID = this.cmbPayType.Tag.ToString();//支付方式
            //zhangyt 2011-03-01
            this.payTypeName = this.cmbPayType.Text.ToString();
            prePay.PayType.Name = this.payTypeName;//支付方式
           
            prePay.Bank = this.cmbPayType.bank.Clone();//开户银行
            prePay.FT.PrepayCost = FrameWork.Function.NConvert.ToDecimal(this.txtpay.Text);//预交金
            prePay.InvoiceNO = invoiceNO; //发票号
            prePay.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;//预交金状态
            prePay.PrePayOper.ID = accountManager.Operator.ID;//操作员编号
            prePay.PrePayOper.Name = accountManager.Operator.Name;//操作员姓名
            prePay.PrePayOper.OperTime = accountManager.GetDateTimeFromSysDateTime();//系统时间
            prePay.AccountNO = account.ID; //帐号
            prePay.IsHostory = false; //是否历史数据
            string errText = string.Empty;
            if (this.iAccountProcessPrepay != null)
            {
                int returnValue = this.iAccountProcessPrepay.GetDerateCost(prePay, ref errText);
                if (returnValue < 0)
                {
                    MessageBox.Show("获取优惠金额出错 "+ errText );
                    return;
                }
            }

            #endregion

            #region 更新数据
            //设置事物

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 建立账户
            if (!isHaveAccount)
            {
                //插入帐户表
                if (accountManager.InsertAccount(this.account) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //生成帐户流水信息
                this.accountRecord = this.GetAccountRecord();
                if (this.accountRecord != null)
                {
                    accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.NewAccount;
                    if (accountManager.InsertAccountRecord(accountRecord) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("建立帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            if (!accountManager.AccountPrePayManager(prePay, 1))
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(accountManager.Err, "错误");
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("交费 （" + this.txtpay.Text + "） 成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.SetControlState(1);
            #endregion

            this.GetAccountByMark();
            this.GetRecordToFp();

            #region 打印
            this.PrintPrePayRecipe(prePay);
            #endregion

            this.cmbPayType.Tag = string.Empty;
            this.txtpay.Text = "0.00";
            this.Clear();
        }

        /// <summary>
        /// 反还预交金
        /// </summary>
        protected virtual void AccountCancelPrePay()
        {
            if (!ValidAccountCard()) return;
            if (neuSpread1_Sheet1.Rows.Count == 0) return;
            if (this.neuSpread1_Sheet1.ActiveRow.Tag == null) return;
            PrePay prePay = this.neuSpread1_Sheet1.ActiveRow.Tag as PrePay;
            #region 验证
            if (prePay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
            {
                MessageBox.Show("该笔预交金已返还记录，不能返还！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (prePay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
            {
                MessageBox.Show("该笔预交金为补打记录，不能返还！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (this.account.Vacancy < prePay.FT.PrepayCost)
            {
                MessageBox.Show("帐户余额不足，不能退此笔预交金！");
                return;
            }
            #endregion
            if (MessageBox.Show("确认返还此笔预交金额？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //现金返还
            prePay.PayType.ID = "CA";

            if (!this.accountManager.AccountPrePayManager(prePay, 0))
            {
                MessageBox.Show(accountManager.Err, "错误");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("返还预交金，票据号为：" + prePay.InvoiceNO + "金额为：" + prePay.FT.PrepayCost.ToString() + "成功！");
            this.GetAccountByMark();
            this.GetRecordToFp();
        }
             
        /// <summary>
        /// 停用帐户
        /// </summary>
        protected virtual void StopAccount()
        {
            if (!ValidAccountCard()) return;
            if (account == null) return;

            if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
            {
                MessageBox.Show("该帐户已停用，请启用该帐户！");
                return;
            }
            if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
            {
                MessageBox.Show("该帐户已注销！");
                return;
            }
            if (MessageBox.Show("确认停用帐户？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel) return;

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            bool isCancelVacancy = false;
            DialogResult resultValue = MessageBox.Show("停用帐户同时，是否结清余额？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resultValue == DialogResult.Yes)
            {
                isCancelVacancy = true;
                if (!ValidCancelVacancy(accountCard.Patient.PID.CardNO))
                {
                    return;
                }
            }

            //设置事物
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //退费金额
            string MessageStr = string.Empty;
            //是否刷新预交金数据
            bool isFreshPrePay = false;
            try
            {

                #region 在停用帐户时是否结清余额
                decimal vacancy = 0;
                //判断帐户余额
                int result = accountManager.GetVacancy(accountCard.Patient.PID.CardNO, ref vacancy);
                if (result <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                //如果在停用帐户时如果帐户余额大于０提示是否结清帐户
                string errText = string.Empty;
                if (vacancy > 0)
                {
                    //结清帐户
                    if (isCancelVacancy)
                    {
                        MessageStr = "应退用户" + vacancy.ToString() + "元！";
                        //刷新帐户预交金数据
                        isFreshPrePay = true;
                        if (!this.UpdateAccountVacancy(vacancy, "结清帐户", OperTypes.BalanceVacancy, ref errText))
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(errText);
                            return;
                        }
                    }
                }
                #endregion

                //更改帐户状态
                bool bl = UpdateAccountState(Neusoft.HISFC.Models.Base.EnumValidState.Invalid,ref errText);
                if (!bl)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errText);
                    return;
                }
                if (accountManager.UpdateEmpowerState(account.ID, Neusoft.HISFC.Models.Base.EnumValidState.Ignore, Neusoft.HISFC.Models.Base.EnumValidState.Valid) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新帐户授权信息失败！" + accountManager.Err);
                    return;
                }

            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("停用帐户失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            
            MessageBox.Show("停用帐户成功！\n" + MessageStr, "提示");
            //设置状态
            SetControlState(2);
            //刷新帐户信息
            GetAccountByMark();
            if (isFreshPrePay)
            {
                this.GetRecordToFp();
                this.GetHistoryRecordToFp();
            }

        }

        /// <summary>
        /// 结清帐户余额
        /// </summary>
        protected virtual void BalanceVacancy()
        {
            decimal vacancy = 0;
            //判断帐户余额
            int result = accountManager.GetVacancy(accountCard.Patient.PID.CardNO, ref vacancy);
            if (result <= 0)
            {
                MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (vacancy <= 0)
            {
                MessageBox.Show("该帐户不存在余额，不能结清帐户余额！");
                return;
            }

            if (MessageBox.Show("确认要结清该帐户的余额？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            if (!ValidCancelVacancy(accountCard.Patient.PID.CardNO))
            {
                return;
            }

            string errText = string.Empty;
            bool resultValue = this.UpdateAccountVacancy(vacancy, "结清帐户", OperTypes.BalanceVacancy, ref errText);
            if (!resultValue)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("应退现金" + vacancy.ToString() + "元！");
            //刷新帐户信息
            GetAccountByMark();
            this.GetRecordToFp();
            this.GetHistoryRecordToFp();
        }

        /// <summary>
        /// 启用帐户
        /// </summary>
        protected virtual void AginAccount()
        {
            if (!ValidAccountCard()) return;
            if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
            {
                MessageBox.Show("该帐户不处于停用状态，不能启用该帐户！");
                return;
            }
            if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
            {
                MessageBox.Show("该帐户已注销！");
                return;
            }

            if (MessageBox.Show("确认启用该帐户？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            //设置事物
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //更新帐户状态
            string errText = string.Empty;
            bool bl = UpdateAccountState(Neusoft.HISFC.Models.Base.EnumValidState.Valid,ref errText);
            if (!bl)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);
                return;
            }
            //更新授权帐户状态
            if (accountManager.UpdateEmpowerState(account.ID, Neusoft.HISFC.Models.Base.EnumValidState.Valid, Neusoft.HISFC.Models.Base.EnumValidState.Ignore) < 0)
            {
                 Neusoft.FrameWork.Management.PublicTrans.RollBack();
                 MessageBox.Show("更新授权帐户信息失败！");
                 return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("启用帐户成功！");
            SetControlState(1);
        }

        /// <summary>
        /// 补打发票
        /// </summary>
        protected virtual void ReprintInvoice()
        {
            try
            {
                if (!ValidAccountCard()) return;
                if (this.neuSpread1_Sheet1.Rows.Count == 0) return;
                if (this.neuSpread1_Sheet1.ActiveRow.Tag == null) return;
                PrePay prePay = (this.neuSpread1_Sheet1.ActiveRow.Tag as PrePay).Clone();

                #region 验证
                if (prePay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    MessageBox.Show("该笔预交金为返还记录，不能补打！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (prePay.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                {
                    MessageBox.Show("该笔预交金为补打记录，不能补打！", "提示", MessageBoxButtons.OK);
                    return;
                }
                #endregion

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                #region 更新发票状态
                //更新发票状态
                prePay.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Ignore;//补打
                if (accountManager.UpdatePrePayState(prePay) < 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该条记录已经进行过返还补打操作，更新状态出错!");
                    return;
                }
                #endregion

                #region 插入作废信息
                //补打
                prePay.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Ignore;
                prePay.FT.PrepayCost = -prePay.FT.PrepayCost;
                prePay.OldInvoice = prePay.InvoiceNO;

                prePay.PrePayOper.ID = this.accountManager.Operator.ID;//add by sung 2009-2-26 {E5178DF3-9C61-43b3-BF61-3EA99A9989E2}
                
                if (accountManager.InsertPrePay(prePay) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废发票出错" + accountManager.Err, "错误");
                    return;
                }
                #endregion

                #region 插入收费信息
                //获取发票号
                string invoiceNO = this.feeIntegrate.GetNewInvoiceNO("A");
                if (invoiceNO == null || invoiceNO == string.Empty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("获得发票号出错!" + this.feeIntegrate.Err);
                    return;
                }
                //prePay.OldInvoice = invoiceNO;
               //zhangyt 2011-03-01
                prePay.Patient = this.ucRegPatientInfo1.GetPatientInfomation();
                prePay.PayType.Name = this.payTypeName;

                prePay.InvoiceNO = invoiceNO;
                prePay.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                prePay.FT.PrepayCost = Math.Abs(prePay.FT.PrepayCost);

                prePay.PrePayOper.ID = this.accountManager.Operator.ID;//add by sung 2009-2-26 {E5178DF3-9C61-43b3-BF61-3EA99A9989E2}

                if (accountManager.InsertPrePay(prePay) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("补打印发票失败！");
                    return;
                }
                #endregion
                //打印票据
                this.PrintPrePayRecipe(prePay);
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("补打印发票失败！" + ex.Message);
                return;
            }
            GetRecordToFp();
          
        }

        /// <summary>
        /// 注销帐户
        /// </summary>
        protected virtual void CancelAccount()
        {
            
            if (!ValidAccountCard()) return;
            if (MessageBox.Show("确认注销该帐户？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //验证密码
            if (!feeIntegrate.CheckAccountPassWord(accountCard.Patient)) return;

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            if (!ValidCancelVacancy(accountCard.Patient.PID.CardNO))
            {
                return;
            }


            decimal vacancy = 0;
            string messStr = string.Empty;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            
            //判断帐户余额
            int result = accountManager.GetVacancy(accountCard.Patient.PID.CardNO, ref vacancy);
            if (result <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //更新帐户余额
            string errText = string.Empty;
            if (vacancy > 0)
            {
                
                if (!UpdateAccountVacancy(vacancy, "结清帐户", OperTypes.BalanceVacancy, ref errText))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errText);
                    return;
                }
                messStr = "应退用户" + vacancy.ToString();

            }
            //更新帐户状态
            bool bl = UpdateAccountState(Neusoft.HISFC.Models.Base.EnumValidState.Ignore,ref errText);
            if (!bl)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);
                return;
            }
            if (accountManager.UpdateEmpowerState(account.ID, Neusoft.HISFC.Models.Base.EnumValidState.Extend, Neusoft.HISFC.Models.Base.EnumValidState.Valid) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新授权帐户状态失败！");
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("注销帐户成功！" + messStr);
            SetControlState(0);
            this.GetRecordToFp();
            this.GetHistoryRecordToFp();
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 修该帐户状态
        /// </summary>
        /// <param name="validState">帐户状态</param>
        /// <returns>true 成功 false失败</returns>
        private bool UpdateAccountState(HISFC.Models.Base.EnumValidState validState,ref string errText)
        {
            //更改帐户状态
            if (accountManager.UpdateAccountState(account.ID, ((int)validState).ToString()) < 0)
            {
                errText = "更新帐户余额失败！" + accountManager.Err;
                return false;
            }

            //是否打印票据
            bool isPrint = false;
            //插入帐户交易记录
            accountRecord = this.GetAccountRecord();
            if (accountRecord == null)
            {
                errText = "获取帐户操作数据失败！";
                return false;
            }
            switch (validState)
            {
                //停用
                case Neusoft.HISFC.Models.Base.EnumValidState.Invalid:
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.StopAccount;
                        isPrint = true;
                        break;
                    }
                //在用
                case Neusoft.HISFC.Models.Base.EnumValidState.Valid:
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.AginAccount;
                        isPrint = true;
                        break;
                    }
                //注销
                case Neusoft.HISFC.Models.Base.EnumValidState.Ignore:
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.CancelAccount;
                        isPrint = true;
                        break;
                    }
            }
            accountRecord.Money = 0;
            accountRecord.Vacancy = 0;
            accountRecord.ReMark = string.Empty;
            if (accountManager.InsertAccountRecord(accountRecord) < 0)
            {
                errText = "插入交易记录失败！" + accountManager.Err;
                return false;
            }
            if (isPrint)
            {
                this.PrintAccountOperRecipe(accountRecord);
            }
            return true;
        }


        /// <summary>
        /// 更新帐户余额
        /// </summary>
        /// <param name="money">金额</param>
        /// <returns>true 成功 false失败</returns>
        private bool UpdateAccountVacancy(decimal money, string reMark, OperTypes opertype, ref string errText)
        {
            //更新帐户余额
            if (accountManager.UpdateAccountVacancy(account.ID, money) <= 0)
            {
                errText = "更新帐户余额失败！" + accountManager.Err;
                return false;
            }
            //交易实体
            accountRecord = this.GetAccountRecord();

            //结清帐户按
            accountRecord.OperType.ID = (int)opertype;
            //退费插如负数
            accountRecord.Money = -money;
            accountRecord.Vacancy = 0;
            accountRecord.ReMark = reMark;
            if (accountManager.InsertAccountRecord(accountRecord) < 0)
            {
                errText = "生成交易记录失败！" + accountManager.Err;
                return false;
            }
            //在注销帐户和停帐户时反还余额打印票据
            if (opertype == OperTypes.BalanceVacancy)
            {
                //更新帐户预交金历史数据状态
                if (accountManager.UpdatePrePayHistory(account.ID, false, true) < 0)
                {
                    errText = "更新帐户预交金失败！" + accountManager.Err;
                    return false;
                }
               
                // PrintCancelVacancyRecipe(accountRecord);    ZHANGYT 2011-03-05   不打结算凭条
            }
            return true;
        }


        // //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 返还账户余额判断
        /// </summary>
        /// <returns></returns>
        private bool ValidCancelVacancy(string cardNO)
        {
            if (string.IsNullOrEmpty(cardNO))
            {
                return false;
            }
            ArrayList al = outPatientManager.GetAccountNoFeeFeeItemList(account.CardNO);
            if (al == null)
            {
                MessageBox.Show("查询患者未收费的费用信息失败！" + outPatientManager.Err);
                return false;
            }
            if (al.Count > 0)
            {
                DialogResult diaResult = MessageBox.Show("存在未收费的费用，是否继续返还账户余额！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (diaResult == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        #region 打印
        /// <summary>
        /// 打印建帐户凭证
        /// </summary>
        /// <param name="account"></param>
        private void PrintCreateAccountRecipe(HISFC.Models.Account.Account tempaccount)
        {
            IPrintCreateAccount Iprint = Neusoft.FrameWork.WinForms.Classes.
                UtilInterface.CreateObject(this.GetType(), typeof(IPrintCreateAccount)) as IPrintCreateAccount;
            if (Iprint == null)
            {
                MessageBox.Show("请维护打印票据，查找打印票据失败！");
                return;
            }
            account.AccountCard.Patient.IDCardType.Name = this.cmbIdCardType.Text;
            Iprint.SetValue(tempaccount);
            Iprint.Print();
        }

        /// <summary>
        /// 打印预交金票据
        /// </summary>
        /// <param name="temprePay"></param>
        private void PrintPrePayRecipe(HISFC.Models.Account.PrePay temprePay)
        {
            IPrintPrePayRecipe Iprint = Neusoft.FrameWork.WinForms.Classes.
               UtilInterface.CreateObject(this.GetType(), typeof(IPrintPrePayRecipe)) as IPrintPrePayRecipe;
            if (Iprint == null)
            {
                MessageBox.Show("请维护打印票据，查找打印票据失败！");
                return;
            }
            Iprint.SetValue(temprePay);
            Iprint.Print();
        }

        /// <summary>
        /// 打印反还余额票据
        /// </summary>
        /// <param name="tempaccount"></param>
        private void PrintCancelVacancyRecipe(HISFC.Models.Account.AccountRecord tempaccountRecord)
        {
            IPrintCancelVacancy Iprint = Neusoft.FrameWork.WinForms.Classes.
             UtilInterface.CreateObject(this.GetType(), typeof(IPrintCancelVacancy)) as IPrintCancelVacancy;
            if (Iprint == null)
            {
                MessageBox.Show("请维护打印票据，查找打印票据失败！");
                return;
            }
            Iprint.SetValue(tempaccountRecord);
            Iprint.Print();
        }

        /// <summary>
        /// 打印帐户操作票据
        /// </summary>
        /// <param name="tempaccountRecord"></param>
        private void PrintAccountOperRecipe(HISFC.Models.Account.AccountRecord tempaccountRecord)
        {
            IPrintOperRecipe Iprint = Neusoft.FrameWork.WinForms.Classes.
            UtilInterface.CreateObject(this.GetType(), typeof(IPrintOperRecipe)) as IPrintOperRecipe;
            if (Iprint == null)
            {
                MessageBox.Show("请维护打印票据，查找打印票据失败！");
                return;
            }
            Iprint.SetValue(tempaccountRecord);
            Iprint.Print();
        }

        /// <summary>
        ///  初始化接口
        /// </summary>
        private void InitInterface()
        {
            this.iAccountProcessPrepay = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(),
                typeof(Neusoft.HISFC.BizProcess.Interface.Account.IAccountProcessPrepay)) as Neusoft.HISFC.BizProcess.Interface.Account.IAccountProcessPrepay;
        }

        #endregion

        #endregion

        #region 事件

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.AccountPrePay();
        }

        private void txtpay_Enter(object sender, EventArgs e)
        {
            txtpay.SelectAll();
        }

        #region {3EF37415-CCF0-4fa8-831C-451EF46065A2} 账户管理读卡操作 by guanyx
        private event System.EventHandler ReadCardEvent;
        #endregion

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbarService.AddToolButton("新建帐户", "新建帐户", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolbarService.AddToolButton("修改密码", "修改密码", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolbarService.AddToolButton("停用帐户", "停用帐户", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
            toolbarService.AddToolButton("启用帐户", "启用帐户", Neusoft.FrameWork.WinForms.Classes.EnumImageList.K开帐, true, false, null);
            toolbarService.AddToolButton("注销帐户", "注销帐户", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);
            toolbarService.AddToolButton("收取", "收取预交金", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q确认收费, true, false, null);
            toolbarService.AddToolButton("返还", "返还预交金", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);
            toolbarService.AddToolButton("补打", "补打预交金收据", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);
            toolbarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolbarService.AddToolButton("结清帐户", "结清帐户余额", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            #region {3EF37415-CCF0-4fa8-831C-451EF46065A2} 账户管理读卡操作 by guanyx
            ReadCardEvent += new EventHandler(ucAccount_ReadCardEvent);
            toolbarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            #endregion
            return toolbarService;
        }
        #region {3EF37415-CCF0-4fa8-831C-451EF46065A2} 账户管理读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucAccount_ReadCardEvent(object sender, EventArgs e)
        {
            this.Clear();
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.txtMarkNo.Text = cardno;
                    this.txtMarkNo.Focus();
                    this.ProcessDialogKey(Keys.Enter);
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }

        /// <summary>
        /// 读卡方法
        /// </summary>
        /// <returns></returns>
        public int ReadCard()
        {
            this.Clear();
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                    return -1;
                }
                else
                {
                    this.txtMarkNo.Text = cardno;
                    this.txtMarkNo.Focus();
                    this.ProcessDialogKey(Keys.Enter);
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
                return -1;
            }
            return 1;
        }

        #endregion

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "修改密码":
                    {
                        EditPassword();
                        break;
                    }
                case "新建帐户":
                    {
                        this.NewAccount();
                        break;
                    }
                case "停用帐户":
                    {
                        StopAccount();
                        break;
                    }
                case "启用帐户":
                    {
                        AginAccount();
                        break;
                    }
                case "收取":
                    {
                        AccountPrePay();
                        break;
                    }
                case "注销帐户":
                    {
                        this.CancelAccount();
                        break;
                    }
                case "返还":
                    {
                        this.AccountCancelPrePay();
                        break;
                    }
                case "补打":
                    {
                        this.ReprintInvoice();
                        break;
                    }
                case "清屏":
                    {
                        this.Clear();
                        break;
                    }
                case "结清帐户":
                    {
                        this.BalanceVacancy();
                        break;
                    }
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (FrameWork.Function.NConvert.ToBoolean(btnShow.Tag))
            {
                this.panelPatient.Visible = false;
                this.btnShow.Tag = false;
            }
            else
            {
                this.panelPatient.Visible = true;
                this.btnShow.Tag = true;
            }
        }

        private void ucAccount_Load(object sender, EventArgs e)
        {
            Init();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ExecCmdKey();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void txtpay_KeyDown(object sender, KeyEventArgs e)
        {
            //在支付金额中回车
            if (e.KeyData == Keys.Enter)
            {
                if (this.txtpay.ContainsFocus)
                {
                    this.AccountPrePay();
                    return;
                }
            }
        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] vtype = new Type[5];
                vtype[0] = typeof(IPrintCreateAccount);
                vtype[1] = typeof(IPrintPrePayRecipe);
                vtype[2] = typeof(IPrintCancelVacancy);
                vtype[3] = typeof(IPrintOperRecipe);
                vtype[4] = typeof(Neusoft.HISFC.BizProcess.Interface.Account.IAccountProcessPrepay);
                return vtype;
            }
        }

        #endregion

       

    }
}
