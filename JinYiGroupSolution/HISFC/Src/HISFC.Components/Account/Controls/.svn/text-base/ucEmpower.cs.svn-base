using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Account;
using System.Collections;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 帐户授权
    /// </summary>
    public partial class ucEmpower : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEmpower()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 授权就诊卡信息
        /// </summary>
        AccountCard accountCard = null;

        /// <summary>
        /// 被授权就诊卡信息
        /// </summary>
        AccountCard empowerAcccountcard = null;

        /// <summary>
        /// 门诊帐户业务层
        /// </summary>
        HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.FrameWork.Public.ObjectHelper IdtypeHelp = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 帐户实体
        /// </summary>
        HISFC.Models.Account.Account account = null;

        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 费用业务层
        /// </summary>
        HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            try
            {
                this.ActiveControl = this.txtMarkNO;
                //卡类型
                ArrayList al = managerIntegrate.GetConstantList("MarkType");
                this.cmbepMarkType.AddItems(al);
                this.cmbMarkType.AddItems(al);
                //证件类型
                IdtypeHelp.ArrayObject = managerIntegrate.QueryConstantList("IDCard");
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 授权信息校验
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            if (accountCard == null)
            {
                MessageBox.Show("请输入授权用户的就诊卡号！");
                return false;
            }
            if (accountCard.Patient == null)
            {
                MessageBox.Show("该卡还没有被发放不能授权，请重新输入授权卡号！");
                return false;
            }
            account = this.accountManager.GetAccountByMarkNo(accountCard.MarkNO);
            if (account == null)
            {
                MessageBox.Show("该卡不存在帐户不能授权,请重新输入授权卡号！");
                return false;
            }
            if (account.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
            {
                MessageBox.Show("该卡的帐户已被停用不能授权，请重新输入授权卡号！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 被授权信息校验
        /// </summary>
        /// <returns></returns>
        private bool EmpowerValid()
        {
            if (empowerAcccountcard == null)
            {
                MessageBox.Show("请输入被授权用户的就诊卡号！");
                return false;
            }
            if (empowerAcccountcard.Patient == null)
            {
                MessageBox.Show("该卡还没有被发放，不能被授权！");
                return false;
            }
            HISFC.Models.Account.Account obj = this.accountManager.GetAccountByMarkNo(empowerAcccountcard.MarkNO);
            if (obj != null)
            {
                MessageBox.Show("该卡已存在帐户，不能被授权！");

                return false;
            }
            AccountEmpower accountEmpwoer = new AccountEmpower();
            int resultValue = accountManager.QueryAccountEmpowerByEmpwoerCardNO(empowerAcccountcard.Patient.PID.CardNO, ref accountEmpwoer);
            if (resultValue < 0)
            {
                MessageBox.Show(this.accountManager.Err);
                return false;
            }
            if (resultValue > 0)
            {
                MessageBox.Show("该帐户已授权不能被再次授权！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void save()
        {
            //授权信息校验
            if (!Valid())
            {
                this.txtMarkNO.Text = string.Empty;
                this.txtMarkNO.Focus();
                return;
            }
            //被授权信息校验
            if (!EmpowerValid())
            {
                this.txtepMarkNO.Text = string.Empty;
                this.txtepMarkNO.Focus();
                return;
            }

            //验证授权人帐户密码
            if (!feeIntegrate.CheckAccountPassWord(accountCard.Patient)) return;

            AccountEmpower accountEmpower = new AccountEmpower();
            //弹出ucEmpowerInfo，输入授权信息
            ucEmpowerInfo uc = new ucEmpowerInfo(accountEmpower, false);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
            if (uc.FindForm().DialogResult != DialogResult.OK) return;
            //生成授权实体
            accountEmpower.AccountCard = accountCard;
            accountEmpower.Vacancy = accountEmpower.EmpowerLimit;
            accountEmpower.EmpowerCard = empowerAcccountcard;
            accountEmpower.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
            accountEmpower.AccountNO = account.ID;
            accountEmpower.Oper.ID = accountManager.Operator.ID;
            accountEmpower.Oper.OperTime = accountManager.GetDateTimeFromSysDateTime();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //插入授权信息
            if (accountManager.InsertEmpower(accountEmpower) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("插入授权表出错！" + accountManager.Err);
                return;
            }
            //更新帐户授权标记
            int resultValue = accountManager.UpdateAccountEmpowerFlag(accountEmpower.AccountNO);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新帐户授权标识出错！" + accountManager.Err);
                return;
            }
            if (resultValue == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("授权帐户信息发生变化！");
                return;
            }
            //插如流水信息
            resultValue = this.InsertAccountRecord(OperTypes.Empower, accountEmpower);
            if (resultValue < 0)
            {
                MessageBox.Show("插入交易表出错！" + accountManager.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return ;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("授权成功！");
            this.ClearEmpower();
            SetEmpowerToFp(accountEmpower);
        }

        ///// <summary>
        ///// 插入交易数据
        ///// </summary>
        ///// <param name="operType"></param>
        //private int InsertAccountRecord(HISFC.Models.Account.OperTypes operType,HISFC.Models.RADT.PatientInfo empowerPatient)
        //{
        //    AccountRecord accountRecord = new AccountRecord();
        //    accountRecord.AccountNO = this.account.ID;//帐号
        //    accountRecord.Patient = accountCard.Patient;//门诊卡号
        //    accountRecord.DeptCode = (accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;//科室编码
        //    accountRecord.Oper = accountManager.Operator.ID;//操作员
        //    accountRecord.OperTime = accountManager.GetDateTimeFromSysDateTime();//操作时间
        //    accountRecord.IsValid = true;//是否有效
        //    accountRecord.EmpowerPatient = empowerPatient;//被授权门诊卡号
        //    accountRecord.OperType.ID = (int)operType;
        //    return accountManager.InsertAccountRecord(accountRecord);
        //}

        /// <summary>
        /// 插入交易数据
        /// </summary>
        /// <param name="operType">操作类型</param>
        /// <param name="empowerPatient">授权信息</param>
        /// <returns>1成功 -1失败</returns>
        private int InsertAccountRecord(HISFC.Models.Account.OperTypes operType, HISFC.Models.Account.AccountEmpower empowerObj)
        {
            AccountRecord accountRecord = new AccountRecord();
            accountRecord.AccountNO = this.account.ID;//帐号
            accountRecord.Patient = accountCard.Patient;//门诊卡号
            accountRecord.DeptCode = (accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;//科室编码
            accountRecord.Oper = accountManager.Operator.ID;//操作员
            accountRecord.OperTime = accountManager.GetDateTimeFromSysDateTime();//操作时间
            accountRecord.IsValid = true;//是否有效
            accountRecord.EmpowerPatient = empowerObj.EmpowerCard.Patient;//empowerPatient;//被授权门诊卡号
            accountRecord.OperType.ID = (int)operType;
            accountRecord.EmpowerCost = empowerObj.EmpowerLimit;
            return accountManager.InsertAccountRecord(accountRecord);
        }

        /// <summary>
        /// 清除授权信息
        /// </summary>
        private void ClearEmpower()
        {
            this.txtepMarkNO.Text = string.Empty;
            this.cmbepMarkType.Tag = string.Empty;
            this.txtepName.Text = string.Empty;
            this.txtepSex.Text = string.Empty;
            this.txtepAge.Text = string.Empty;
            this.txtIdCardNO.Text = string.Empty;
            this.txtIdCardType.Text = string.Empty;
            this.txtEpNation.Text = string.Empty;
            this.txtCountry.Text = string.Empty;
            this.txtsiNo.Text = string.Empty;
            this.empowerAcccountcard = null;
            this.txtepMarkNO.Focus();
            
        }

        /// <summary>
        /// 查询授权信息
        /// </summary>
        /// <param name="accountNO">帐号</param>
        protected virtual void GetEmpowerList(string accountNO)
        {
            if (this.spEmpower.Rows.Count > 0)
            {
                this.spEmpower.Rows.Remove(0, this.spEmpower.Rows.Count);
            }
            List<AccountEmpower> list = accountManager.QueryAllEmpowerByAccountNO(accountNO);
            if (list == null)
            {
                MessageBox.Show("查询授权信息出错！" + accountManager.Err);
                return;
            }
            foreach (AccountEmpower obj in list)
            {
                SetEmpowerToFp(obj);
            }
        }

        /// <summary>
        /// 显示帐户授权信息
        /// </summary>
        /// <param name="tempEmpwoer">授权实体</param>
        private void SetEmpowerToFp(AccountEmpower tempEmpwoer)
        {
            int rowindex = 0;
            this.spEmpower.Rows.Add(this.spEmpower.Rows.Count, 1);
            rowindex = this.spEmpower.Rows.Count - 1;
            this.spEmpower.Cells[rowindex, 0].Text = tempEmpwoer.AccountCard.Patient.Name; //姓名
            this.spEmpower.Cells[rowindex, 1].Text = tempEmpwoer.EmpowerCard.Patient.Name;//被授权用户姓名
            this.spEmpower.Cells[rowindex, 2].Text = tempEmpwoer.EmpowerLimit.ToString(); //授权限额
            this.spEmpower.Cells[rowindex, 3].Text = this.GetText(tempEmpwoer.ValidState); //状态
            if (tempEmpwoer.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid) //是否可用
            {
                this.spEmpower.Rows[rowindex].BackColor = Color.Red;
            }
            //查询操作原信息
            HISFC.Models.Base.Employee employee = managerIntegrate.GetEmployeeInfo(tempEmpwoer.Oper.ID);
            if (employee != null)
            {
                this.spEmpower.Cells[rowindex, 4].Text = employee.Name;//操作原姓名
            }
            this.spEmpower.Cells[rowindex, 5].Text = tempEmpwoer.Oper.OperTime.ToString();//操作时间
            this.spEmpower.Rows[rowindex].Tag = tempEmpwoer;
        }

        /// <summary>
        /// 显示状态名称
        /// </summary>
        /// <param name="validState">状态类型</param>
        /// <returns>状态名称</returns>
        private string GetText(Neusoft.HISFC.Models.Base.EnumValidState validState)
        {
            string txtStr = string.Empty;
            switch (validState)
            {
                case Neusoft.HISFC.Models.Base.EnumValidState.Valid:
                    {
                        txtStr = "在用";
                        break;
                    }
                case Neusoft.HISFC.Models.Base.EnumValidState.Invalid:
                    {
                        txtStr  ="取消授权";
                        break;
                    }
                case Neusoft.HISFC.Models.Base.EnumValidState.Ignore:
                    {
                        txtStr = "停用";
                        break;
                    }
                case Neusoft.HISFC.Models.Base.EnumValidState.Extend:
                    {
                        txtStr = "注销";
                        break;
                    }
            }
            return txtStr;
        }

        /// <summary>
        /// 授权操作（取消授权、授权）
        /// </summary>
        /// <param name="isValid">是否授权</param>
        private int EmpowerManager(AccountEmpower accountEmpower, Neusoft.HISFC.Models.Base.EnumValidState validState)
        {
            accountEmpower.ValidState = validState;
            accountEmpower.Oper.ID = accountManager.Operator.ID;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //更新授权表
            if (this.accountManager.UpdateEmpower(accountEmpower) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新授权表出错！");
                return -1;
            }
            //更新帐户授权状态
            int resultValue = accountManager.UpdateAccountEmpowerFlag(accountEmpower.AccountNO);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新帐户授权标识出错！" + accountManager.Err);
                return -1;
            }
            if (resultValue == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("授权帐户信息发生变化！");
                return -1;
            }
            //插入帐户流水表
            if ( validState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
            {
                resultValue = this.InsertAccountRecord(OperTypes.RevertEmpower, accountEmpower);
            }
            else
            {
                resultValue = this.InsertAccountRecord(OperTypes.CancelEmpower, accountEmpower);
            }
            if (resultValue < 0)
            {
                MessageBox.Show("插入交易表出错！"+accountManager.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        /// <summary>
        /// 取消授权
        /// </summary>
        protected virtual void CancelEmpower()
        {
            if (this.spEmpower.Rows.Count == 0) return;
            if (this.spEmpower.ActiveRow.Tag == null) return;
            int rowIndex = this.spEmpower.ActiveRowIndex;

            if (MessageBox.Show("是否要取消该用户的授权？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            //验证授权人帐户密码
            if (!feeIntegrate.CheckAccountPassWord(accountCard.Patient)) return;

            AccountEmpower accountEmpower = this.spEmpower.ActiveRow.Tag as AccountEmpower;
            if (accountEmpower.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
            {
                MessageBox.Show("该用户已取消授权！", "提示");
                return;
            }
            if (EmpowerManager(accountEmpower, Neusoft.HISFC.Models.Base.EnumValidState.Invalid) == 1)
            {
                MessageBox.Show("取消授权成功！", "提示");
            }
            this.spEmpower.Cells[rowIndex, 3].Text = this.GetText(accountEmpower.ValidState);
            this.spEmpower.Rows[rowIndex].Tag = accountEmpower;
            this.spEmpower.Rows[rowIndex].BackColor = Color.Red ;

        }

        /// <summary>
        /// 授权
        /// </summary>
        protected virtual void Empower()
        {
            if (this.spEmpower.Rows.Count == 0) return;
            if (this.spEmpower.ActiveRow.Tag == null) return;
            int rowIndex = this.spEmpower.ActiveRowIndex;
            if (MessageBox.Show("是否要对该用户进行授权？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            //验证授权人帐户密码
            if (!feeIntegrate.CheckAccountPassWord(accountCard.Patient)) return;


            AccountEmpower accountEmpower = this.spEmpower.ActiveRow.Tag as AccountEmpower;
            //判断被授权用户是否有帐户
            HISFC.Models.Account.Account obj = this.accountManager.GetAccountByMarkNo(accountEmpower.EmpowerCard.MarkNO);
            if (obj != null)
            {
                MessageBox.Show("该用户已存在帐户，不能被授权");
                return ;
            }

            if (accountEmpower.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
            {
                MessageBox.Show("该用户已授权，不能被再次授权", "提示");
                return;
            }

            if (EmpowerManager(accountEmpower, Neusoft.HISFC.Models.Base.EnumValidState.Valid) == 1)
            {
                MessageBox.Show("授权成功！", "提示");
            }
            this.spEmpower.Cells[rowIndex, 3].Text = this.GetText(accountEmpower.ValidState);
            this.spEmpower.Rows[rowIndex].Tag = accountEmpower;
            this.spEmpower.Rows[rowIndex].BackColor = Color.White;

        }

        /// <summary>
        /// 修改授权信息
        /// </summary>
        protected virtual void EditEmpowerInfo()
        {
            if (this.spEmpower.Rows.Count == 0) return;
            if (this.spEmpower.ActiveRow.Tag == null) return;
            int rowIndex = this.spEmpower.ActiveRowIndex;
            AccountEmpower accountEmpower = this.spEmpower.ActiveRow.Tag as AccountEmpower;
            if (accountEmpower == null) return;
            if (accountEmpower.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
            {
                MessageBox.Show("该用户已取消授权，不能编辑其授权信息");
                return;
            }

            //验证密码
            if (!feeIntegrate.CheckAccountPassWord(accountCard.Patient)) return;

            ucEmpowerInfo uc = new ucEmpowerInfo(accountEmpower, true);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
            if (uc.FindForm().DialogResult == DialogResult.OK)
            {
                this.GetEmpowerList(account.ID);
            }
        }


        #endregion

        #region 事件
        private void ucEmpower_Load(object sender, EventArgs e)
        {
            if (Init() < 0)
            {
                MessageBox.Show("初始化信息失败！");
                return;
            }
        }

        private void txtMarkNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //获取就诊卡信息
                accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                int resultValue = accountManager.GetCardByRule(this.txtMarkNO.Text.Trim(), ref accountCard);
                if (resultValue<= 0)
                {
                    MessageBox.Show(accountManager.Err);
                    accountCard = null;
                    this.txtMarkNO.Text = string.Empty;
                    this.txtMarkNO.Focus();
                    return;
                }
                //校验
                if (!Valid())
                {
                    this.txtMarkNO.Text = string.Empty;
                    this.txtMarkNO.Focus();
                    accountCard = null;
                    return; 
                }
                
                this.txtMarkNO.Text = accountCard.MarkNO; //就诊卡号
                this.cmbMarkType.Tag = accountCard.MarkType.ID;//卡类型
                this.txtName.Text = accountCard.Patient.Name; //患者姓名
                this.txtSex.Text = accountCard.Patient.Sex.Name; //性别
                this.txtAge.Text = accountManager.GetAge(accountCard.Patient.Birthday);//年龄
                this.txtIdCardNO.Text = accountCard.Patient.IDCard;//证件号
                
                this.txtIdCardType.Text =IdtypeHelp.GetName(accountCard.Patient.IDCardType.ID);//证件类型
                Neusoft.FrameWork.Models.NeuObject tempObj = null;
                tempObj = managerIntegrate.GetConstansObj("NATION", accountCard.Patient.Nationality.ID);
                if (tempObj != null)
                {
                    this.txtNation.Text = tempObj.Name;//民族
                }
                tempObj = managerIntegrate.GetConstansObj("COUNTRY", accountCard.Patient.Country.ID);
                if (tempObj != null)
                {
                    this.txtCountry.Text = tempObj.Name;//国家
                }
                tempObj = null;
                this.txtsiNo.Text = accountCard.Patient.SSN;
                this.txtepMarkNO.Focus();
                GetEmpowerList(account.ID);

            }
        }

        private void txtepMarkNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                empowerAcccountcard = new Neusoft.HISFC.Models.Account.AccountCard();
                int resultValue = accountManager.GetCardByRule(this.txtepMarkNO.Text.Trim(), ref empowerAcccountcard);
                if (resultValue<= 0)
                {
                    MessageBox.Show(accountManager.Err);
                    empowerAcccountcard = null;
                    this.txtepMarkNO.Text = string.Empty;
                    this.txtepMarkNO.Focus();
                    return;
                }
                if (!EmpowerValid())
                {
                    this.txtepMarkNO.Text = string.Empty;
                    this.txtepMarkNO.Focus();
                    empowerAcccountcard = null;
                    return;
                }
                this.txtepMarkNO.Text = empowerAcccountcard.MarkNO; //就诊卡号
                this.cmbepMarkType.Tag = empowerAcccountcard.MarkType.ID;//卡类型
                this.txtepName.Text = empowerAcccountcard.Patient.Name; //患者姓名
                this.txtepSex.Text = empowerAcccountcard.Patient.Sex.Name; //性别
                this.txtepAge.Text = accountManager.GetAge(empowerAcccountcard.Patient.Birthday);//年龄
                this.txtepIdNO.Text = empowerAcccountcard.Patient.IDCard;//证件号
                this.txtedIdType.Text = IdtypeHelp.GetName(empowerAcccountcard.Patient.IDCardType.ID);//证件类型
                Neusoft.FrameWork.Models.NeuObject tempObj = null;
                tempObj = managerIntegrate.GetConstansObj("NATION", empowerAcccountcard.Patient.Nationality.ID);
                if (tempObj != null)
                {
                    this.txtEpNation.Text = tempObj.Name;//民族
                }

                tempObj = managerIntegrate.GetConstansObj("COUNTRY", empowerAcccountcard.Patient.Country.ID);
                if (tempObj != null)
                {

                    this.txtepCountry.Text = tempObj.Name;//国家
                }
                tempObj = null;
                this.txtepMarkNO.Text = empowerAcccountcard.MarkNO;
                this.cmbepMarkType.Tag = empowerAcccountcard.MarkType.ID;
                this.txtepsiNo.Text = empowerAcccountcard.Patient.SSN;
                
                
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
           
            return base.OnSave(sender, neuObject);
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbarService.AddToolButton("取消授权", "取消授权", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolbarService.AddToolButton("恢复授权", "恢复授权", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J角色添加, true, false, null);
            
            toolbarService.AddToolButton("授权", "授权", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q权限, true, false, null);
            toolbarService.AddToolButton("修改授权信息", "修改授权信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);


            return toolbarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "取消授权":
                    {
                        this.CancelEmpower();
                        break;
                    }
                case "恢复授权":
                    {
                        Empower();
                        break;
                    }
                case "修改授权信息":
                    {
                        EditEmpowerInfo();
                        break;
                    }
                case "授权":
                    {
                        this.save();
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion
    }
}
