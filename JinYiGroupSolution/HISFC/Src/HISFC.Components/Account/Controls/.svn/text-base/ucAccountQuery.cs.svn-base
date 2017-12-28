using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 帐户操作信息查询
    /// </summary>
    public partial class ucAccountQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucAccountQuery()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 帐户管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        
        /// <summary>
        /// 综合管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 卡类型帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper markHelp = new Neusoft.FrameWork.Public.ObjectHelper();

        #region {559BF513-8C08-4a2b-A612-0C570A35715B} 门诊用卡及账户查询读卡操作 by guanyx
        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 读卡事件
        /// </summary>
        private event System.EventHandler ReadCardEvent;   
        #endregion

        #endregion

        #region 方法

        #region {559BF513-8C08-4a2b-A612-0C570A35715B} 门诊用卡及账户查询读卡操作 by guanyx
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            ReadCardEvent += new EventHandler(ucAccountQuery_ReadCardEvent);
            toolbarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            return toolbarService;
        }

        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucAccountQuery_ReadCardEvent(object sender, EventArgs e)
        {
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
                    this.txtMardNO.Text = cardno;
                    this.txtMardNO_KeyDown(this.txtMardNO, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }

        #endregion



        /// <summary>
        /// 查找帐户记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        protected virtual void GetAccountRecord(string cardNO,string begin,string end)
        {
            //查找帐户交易记录
            List<Neusoft.HISFC.Models.Account.AccountRecord> list = accountManager.GetAccountRecordList(cardNO, begin, end);
            if (list == null)
            {
                MessageBox.Show(accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.neuSpread2_Sheet1.Rows.Count = list.Count+1;
            int index=0;
            //decimal vacancy = 0;
            foreach (Neusoft.HISFC.Models.Account.AccountRecord account in list)
            {
                //操作类型
                neuSpread2_Sheet1.Cells[index, 0].Text = account.OperType.Name;
                //交易金额
                neuSpread2_Sheet1.Cells[index, 1].Text = account.Money.ToString();
                //交易后余额
                neuSpread2_Sheet1.Cells[index, 2].Text = account.Vacancy.ToString();
                //操作科室
                neuSpread2_Sheet1.Cells[index, 3].Text = account.DeptCode;
                //操作人
                neuSpread2_Sheet1.Cells[index, 4].Text = account.Oper;
                //操作时间
                neuSpread2_Sheet1.Cells[index, 5].Text = account.OperTime.ToString();
                //备注
                neuSpread2_Sheet1.Cells[index, 6].Text = account.ReMark;
                //neuSpread2_Sheet1.Cells[index, 7].Text = account.EmpowerPatient.Name;
                //neuSpread2_Sheet1.Cells[index, 8].Text = account.EmpowerCost.ToString();
                neuSpread2_Sheet1.Rows[index].Tag = account;
                //合计金额等于最后交易后余额 2011-3-2 lioe {CC1B047A-9B01-4d82-8882-8C122E1918A2}
                //vacancy += account.Money;
                //vacancy = account.Vacancy;
                ++index;
            }
            //neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.Rows.Count-1, 0].Text = "合计：";
            //neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.Rows.Count-1, 1].Text = vacancy.ToString();

        }

        /// <summary>
        /// 查找卡使用记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        protected virtual void GetAccountCardRecord(string cardNO, string begin, string end)
        {
            //查找帐户卡操作记录
            List<Neusoft.HISFC.Models.Account.AccountCardRecord> list = accountManager.GetAccountCardRecord(cardNO, begin, end);
            if (list == null)
            {
                MessageBox.Show(accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            neuSpread1_Sheet1.Rows.Count = list.Count;
            int index=0;
            foreach (Neusoft.HISFC.Models.Account.AccountCardRecord accountCardRecord in list)
            {
                //卡类型
                if (markHelp != null)
                {
                    neuSpread1_Sheet1.Cells[index, 0].Text = markHelp.GetName(accountCardRecord.MarkType.ID);
                }
                //卡号
                neuSpread1_Sheet1.Cells[index, 1].Text = accountCardRecord.MarkNO;
                //操作类型
                neuSpread1_Sheet1.Cells[index, 2].Text = accountCardRecord.OperateTypes.Name;
                //操作人
                neuSpread1_Sheet1.Cells[index, 3].Text = managerIntegrate.GetEmployeeInfo(accountCardRecord.Oper.ID).Name;
                //操作时间
                neuSpread1_Sheet1.Cells[index, 4].Text = accountCardRecord.Oper.OperTime.ToString();
                ++index;
            }
        }

        /// <summary>
        /// 查找门诊卡号
        /// </summary>
        /// <returns>true 成功 false失败</returns>
        private bool GetCardNO(ref string cardNO)
        {
            string markNo = this.txtMardNO.Text.Trim();
            HISFC.Models.Account.AccountCard accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
            int resultValue = accountManager.GetCardByRule(markNo,ref accountCard);
            if (resultValue <= 0)
            {
                MessageBox.Show(accountManager.Err);
                return false;
            }
            this.txtMardNO.Text = accountCard.MarkNO;
            this.cmbCardType.Tag = accountCard.MarkType.ID;
            if (accountCard.Patient != null)
            {
                cardNO = accountCard.Patient.PID.CardNO;
            }
            return true;
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        protected virtual void GetQueryData()
        {
            if (this.txtMardNO.Tag == null) 
            {
                MessageBox.Show("输入就诊卡号后，请回车确认！");
                return;
            }
            string cardNo = this.txtMardNO.Tag.ToString();
            //起止时间
            string begin = this.dtpbegin.Value.ToShortDateString() + " 0:00:00";
            string end = this.dtpend.Value.ToShortDateString() + " 23:59:59";
            try
            {
                //查找帐户记录
                GetAccountRecord(cardNo, begin, end);
                //查找卡使用记录
                GetAccountCardRecord(cardNo, begin, end);
                txtMardNO.Focus();
                txtMardNO.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        
        #region 事件
        private void ucAccountQuery_Load(object sender, EventArgs e)
        {
            DateTime dt = accountManager.GetDateTimeFromSysDateTime();
            int dayindex = dt.Day - 1;
            this.dtpbegin.Value = dt.AddDays(-dayindex);
            this.dtpend.Value = dt;
            this.ActiveControl = this.txtMardNO;
            System.Collections.ArrayList al = this.managerIntegrate.GetConstantList("MarkType");
            if (al == null) return;
            markHelp.ArrayObject = al;
            this.cmbCardType.AddItems(al);

            try
            {
                
                this.fpFeeDetail_Sheet1.DataAutoSizeColumns = false;
                this.fpFeeDetail_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
                this.fpFeeDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Range;
                this.fpFeeDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
                this.fpFeeDetail_Sheet1.Columns[0].Width = 200;
                this.fpFeeDetail_Sheet1.Columns[1].Width = 180;
                this.fpFeeDetail_Sheet1.Columns[2].Width = 120;
                this.fpFeeDetail_Sheet1.Columns[3].Width = 100;
                this.fpFeeDetail_Sheet1.Columns[5].Width = 120;
               // this.fpFeeDetail_Sheet1.Columns[6].Width = 180;
                this.neuTabControl1.TabPages.Remove(this.tbFeeDetail);
            }
            catch
            {
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            neuSpread2_Sheet1.RowCount = 0;
            GetQueryData();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this.neuTabControl1);
            return base.OnPrint(sender, neuObject);
        }

        private void txtMardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string cardNo = string.Empty;
                if (!this.GetCardNO(ref cardNo)) return;
                this.txtMardNO.Tag = cardNo;
            }
        }

        private void neuSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuTabControl1.Controls.Contains(this.tbFeeDetail))
            {
                this.neuTabControl1.Controls.Remove(this.tbFeeDetail);
            }
            if (this.neuSpread2_Sheet1.RowCount < 1)
            {
                return;
            }

            if (this.neuSpread2_Sheet1.Rows[this.neuSpread2_Sheet1.ActiveRowIndex].Tag == null) return;

            Neusoft.HISFC.Models.Account.AccountRecord accountRecord = this.neuSpread2_Sheet1.Rows[this.neuSpread2_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Account.AccountRecord;

            string invoiceNO = accountRecord.ReMark;
            string invoiceType = accountRecord.InvoiceType.ID;
            if (invoiceNO == "" || invoiceType == string.Empty)
            {
                return;
            }
            //门诊发票类型C
            if (invoiceType != "C") return;

            if (accountRecord.OperType.ID.ToString() != ((int)OperTypes.Pay).ToString() || accountRecord.OperType.ID.ToString() != ((int)OperTypes.CancelPay).ToString()) return;
            bool isQuite = accountRecord.OperType.ID.ToString() == ((int)OperTypes.Pay).ToString() ? true : false;
            //检索发票费用明细
            DataSet dsFeeDetail = accountManager.GetFeeDetailByInvoiceNO(invoiceNO, isQuite);
            if (dsFeeDetail == null) return;

            if (dsFeeDetail.Tables[0].Rows.Count == 0)
            {
                return;
            }
            DataRow row = dsFeeDetail.Tables[0].NewRow();

            row[1] = "合计：";
            row[5] = dsFeeDetail.Tables[0].Compute("sum(金额)", "");
            dsFeeDetail.Tables[0].Rows.Add(row);
            this.fpFeeDetail.DataSource = dsFeeDetail;
            this.neuTabControl1.TabPages.Add(this.tbFeeDetail);
            this.neuTabControl1.SelectedTab = this.tbFeeDetail;

        }
        #endregion

        

 
    }
}
