using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 发票跳号
    /// </summary>
    public partial class ucInvoiceChange : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 发票跳号
        /// </summary>
        public ucInvoiceChange()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 发票类型
        /// </summary>
        //private Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService myInvoiceType = new Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService();
        private Neusoft.FrameWork.Models.NeuObject myInvoiceType = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 发票业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum invoiceServiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum();
        /// <summary>
        /// 人员业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager employeeManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        
        private Neusoft.HISFC.Models.Base.Employee myOperator = new Neusoft.HISFC.Models.Base.Employee();
        #endregion

        #region 属性

        /// <summary>
        /// 发票类型
        /// </summary>
        //public Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService InvoiceType
        //{
        //    get
        //    {
        //        return this.myInvoiceType;
        //    }

        //    set
        //    {
        //        this.myInvoiceType = value;
        //    }
        //}

        public Neusoft.FrameWork.Models.NeuObject InvoiceType
        {
            get
            {
                return this.myInvoiceType;
            }
            set
            {
                this.myInvoiceType = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.myOperator = this.invoiceServiceManager.Operator as Neusoft.HISFC.Models.Base.Employee;
            
            //this.cmbInvoiceType.AddItems(Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService.List());
            Neusoft.HISFC.BizLogic.Manager.Constant myCon = new Neusoft.HISFC.BizLogic.Manager.Constant ();
            this.cmbInvoiceType.AddItems(myCon.GetList("GetInvoiceType"));
            this.cmbInvoiceType.SelectedIndex = 0;
            this.QueryInvoice();
        }

        private string GetEmployeeName(string employeeID)
        {
            Neusoft.HISFC.Models.Base.Employee employee = null;
            employee = this.employeeManager.GetEmployeeInfo(employeeID);
            return employee.Name;
        }

        /// <summary>
        /// 查询发票
        /// </summary>
        private void QueryInvoice()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
            ArrayList alInvoice = new ArrayList();
            alInvoice = this.invoiceServiceManager.QueryInvoices(this.myOperator.ID, this.myInvoiceType.ID);
            foreach (Neusoft.HISFC.Models.Fee.Invoice invoice in alInvoice)
            {
                if (invoice.ValidState == "1")
                {
                    this.neuSpread1_Sheet1.Rows.Add(0, 1);
                    this.neuSpread1_Sheet1.SetValue(0, 0, this.myOperator.Name);
                    this.neuSpread1_Sheet1.SetValue(0, 1, this.myInvoiceType.Name);
                    this.neuSpread1_Sheet1.SetValue(0, 2, invoice.BeginNO);
                    this.neuSpread1_Sheet1.SetValue(0, 3, invoice.UsedNO);
                    this.neuSpread1_Sheet1.SetValue(0, 4, invoice.EndNO);
                    this.neuSpread1_Sheet1.SetValue(0, 5, invoice.AcceptTime);
                    this.neuSpread1_Sheet1.Rows[0].Tag = invoice;
                }
            }
            
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private int SaveInvoiceChange()
        {
            Neusoft.HISFC.Models.Fee.InvoiceChange invoiceChange = null;
            Neusoft.HISFC.Models.Fee.Invoice invoice = null;
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                int row = this.neuSpread1_Sheet1.ActiveRow.Index;
                if (row >= 0)
                {
                    invoice = this.neuSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Fee.Invoice;
                }
            }
            invoiceChange = this.SetInvoiceChange();
            if (this.CheckData(invoiceChange) < 0)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.invoiceServiceManager.Connection);
            //trans.BeginTransaction();

            this.invoiceServiceManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int iReturn = -1;
            iReturn = this.invoiceServiceManager.InsertInvoiceChange(invoiceChange);
            if (iReturn < 0)
            {
                MessageBox.Show("插入发票变更表失败！" + this.invoiceServiceManager.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            iReturn = this.invoiceServiceManager.UpdateInvoiceUsedNO(invoiceChange.EndNO, invoice.AcceptOper.ID, invoice.AcceptTime);
            if (iReturn < 0)
            {
                MessageBox.Show("更新发票已用号码失败！" + this.invoiceServiceManager.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功");
            this.QueryInvoice();
            return 0;
        }

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <param name="invoiceChange"></param>
        /// <returns></returns>
        private int CheckData(Neusoft.HISFC.Models.Fee.InvoiceChange invoiceChange)
        {
            Neusoft.HISFC.Models.Fee.Invoice invoice = null;
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                int row = this.neuSpread1_Sheet1.ActiveRow.Index;
                if (row >= 0)
                {
                    invoice = this.neuSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Fee.Invoice;
                }
            }

            for (int i = 0, j = this.txtUsedNO.Text.Length; i < j; i++)
            {
                if (!char.IsDigit(this.txtUsedNO.Text, i))
                {
                    //可以说明是第几个字符错误了
                    MessageBox.Show("输入的已用发票号必须是数字", "提示", MessageBoxButtons.OK);
                    return -1;
                }
            }

            if (Convert.ToInt64(invoiceChange.EndNO) < Convert.ToInt64(invoice.UsedNO))
            {
                MessageBox.Show("输入的已用发票号不能小于当前已用号");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 生成发票变更实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Fee.InvoiceChange SetInvoiceChange()
        {
            Neusoft.HISFC.Models.Fee.InvoiceChange myInvoiceChange = new Neusoft.HISFC.Models.Fee.InvoiceChange();
            Neusoft.HISFC.Models.Fee.Invoice invoice = null;
            long beginNO = 0;
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                int row = this.neuSpread1_Sheet1.ActiveRow.Index;
                if (row >= 0)
                {
                    invoice = this.neuSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Fee.Invoice;
                }
            }
            myInvoiceChange.HappenNO = this.invoiceServiceManager.GetInvoiceChangeHappenNO(this.myOperator.ID);
            myInvoiceChange.GetOper.ID = invoice.AcceptOper.ID;
            myInvoiceChange.InvoiceType = invoice.Type;
            beginNO = Convert.ToInt64(invoice.UsedNO) + 1;
            myInvoiceChange.BeginNO = beginNO.ToString().PadLeft(12, '0');
            myInvoiceChange.EndNO = this.txtUsedNO.Text.ToString().PadLeft(12, '0');
            myInvoiceChange.ShiftType = "2";
            myInvoiceChange.Oper.ID = this.myOperator.ID;
            myInvoiceChange.Memo = "发票跳号";
            return myInvoiceChange;
        }

        #endregion

        #region 事件

        private void ucInvoiceChange_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void cmbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.myInvoiceType.ID = this.cmbInvoiceType.Tag.ToString();
            this.myInvoiceType.Name = this.cmbInvoiceType.Text;
            this.QueryInvoice();
            this.txtUsedNO.Text = "";
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Fee.Invoice selectedInvoice = null;
            
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                int row = this.neuSpread1_Sheet1.ActiveRow.Index;
                if (row >= 0)
                {
                    selectedInvoice = this.neuSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Fee.Invoice;
                    this.txtUsedNO.Text = selectedInvoice.UsedNO;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SaveInvoiceChange();
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        #endregion

        
    }
}

