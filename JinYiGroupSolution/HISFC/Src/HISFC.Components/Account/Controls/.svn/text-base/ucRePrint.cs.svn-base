using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.BizProcess.Interface.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucRePrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucRePrint()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 费用业务层
        /// </summary>
        private HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 就诊断卡实体
        /// </summary>
        private HISFC.Models.Account.AccountCard accountCard = null;

        /// <summary>
        /// 门诊帐户业务层
        /// </summary>
        private HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        
        /// <summary>
        /// 综合业务层
        /// </summary>
        private HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region 方法

        /// <summary>
        ///　初始化ComBox
        /// </summary>
        private void InitCmb()
        {
            ArrayList al = new ArrayList();
            NeuObject tempObj = null;

            tempObj = new NeuObject();
            tempObj.ID = ((int)Neusoft.HISFC.Models.Account.OperTypes.StopAccount).ToString();
            tempObj.Name = "停帐户";
            al.Add(tempObj);

            tempObj = new NeuObject();
            tempObj.ID = ((int)Neusoft.HISFC.Models.Account.OperTypes.AginAccount).ToString();
            tempObj.Name = "重启帐户";
            al.Add(tempObj);

            tempObj = new NeuObject();
            tempObj.ID = ((int)Neusoft.HISFC.Models.Account.OperTypes.CancelAccount).ToString();
            tempObj.Name = "注销帐户";
            al.Add(tempObj);

            tempObj = new NeuObject();
            tempObj.ID = ((int)Neusoft.HISFC.Models.Account.OperTypes.EditPassWord).ToString();
            tempObj.Name = "修改密码";
            al.Add(tempObj);

            tempObj = new NeuObject();
            tempObj.ID = ((int)Neusoft.HISFC.Models.Account.OperTypes.BalanceVacancy).ToString();
            tempObj.Name = "结清余额";
            al.Add(tempObj);

            this.cmbOper.AddItems(al);
        }

        /// <summary>
        /// 根据就诊卡号查找患者信息
        /// </summary>
        private void GetPatientByMarkNO()
        {
            string markNO = this.txtMarkNO.Text.Trim();
            int resultValue = feeIntegrate.ValidMarkNO(markNO, ref accountCard);
            if (resultValue <= 0)
            {
                MessageBox.Show(feeIntegrate.Err);
                this.txtMarkNO.Focus();
                this.txtMarkNO.SelectAll();
                return;
            }
            this.txtMarkNO.Tag = this.accountCard.Patient.PID.CardNO;
            this.txtMarkNO.Text = this.accountCard.MarkNO;
        }

        /// <summary>
        /// 根据就诊卡号查找交易记录
        /// </summary>
        /// <param name="cardNO"></param>
        private void QueryOperRecord()
        {
            if (this.txtMarkNO.Tag == null)
            {
                MessageBox.Show("请输入就诊卡号！");
                this.txtMarkNO.Focus();
                return;
            }
            if (this.cmbOper.Tag == null || this.cmbOper.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请要补打的票据类型！");
                this.cmbOper.Focus();
                return;
            }
            string cardNO = this.txtMarkNO.Tag.ToString();
            int rowIndex = 0;
            int count = this.neuSpread1_Sheet1.Rows.Count;
            if (count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, count);
            }
            string operType = this.cmbOper.Tag.ToString();
            List<HISFC.Models.Account.AccountRecord> list = accountManager.GetAccountRecordList(cardNO, operType);
            if (list == null)
            {
                MessageBox.Show("查找数据失败！");
                return;
            }
            foreach (HISFC.Models.Account.AccountRecord record in list)
            {
                neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
                rowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.neuSpread1_Sheet1.Cells[rowIndex, 0].Text = record.OperType.Name;
                this.neuSpread1_Sheet1.Cells[rowIndex, 1].Text = record.DeptCode;
                this.neuSpread1_Sheet1.Cells[rowIndex, 2].Text = record.Oper;
                this.neuSpread1_Sheet1.Cells[rowIndex, 3].Text = record.OperTime.ToString();
                record.Patient = accountCard.Patient;
                this.neuSpread1_Sheet1.Rows[rowIndex].Tag = record;
            }

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
        #endregion

        #region 事件
        private void ucRePrint_Load(object sender, EventArgs e)
        {
            InitCmb();
        }

        private void txtMarkNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                GetPatientByMarkNO();
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            QueryOperRecord();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0) return -1;
            int rowIndex = this.neuSpread1_Sheet1.ActiveRowIndex;
            HISFC.Models.Account.AccountRecord record = this.neuSpread1_Sheet1.Rows[rowIndex].Tag as HISFC.Models.Account.AccountRecord;
            if (record == null) return -1;
            if (record.OperType.ID.ToString() == ((int)HISFC.Models.Account.OperTypes.BalanceVacancy).ToString())
            {
                PrintCancelVacancyRecipe(record);
            }
            else
            {
                this.PrintAccountOperRecipe(record);
            }
            return base.OnPrint(sender, neuObject);
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get 
            {
                Type [] vType = new Type[2];
                vType[0] = typeof(IPrintOperRecipe);
                vType[1] = typeof(IPrintCancelVacancy);
                return vType;
            }
        }

        #endregion
    }
}
