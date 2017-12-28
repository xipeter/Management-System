using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucInvoiceSelect : UserControl
    {
        public ucInvoiceSelect()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 当前选择发票
        /// </summary>
        protected Neusoft.HISFC.Models.Fee.Outpatient.Balance selectedBalance = null;

        #endregion

        #region 属性

        /// <summary>
        /// 当前选择发票
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Outpatient.Balance SelectedBalance 
        {
            get 
            {
                return this.selectedBalance;
            }
            set 
            {
                this.selectedBalance = value;
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 列
        /// </summary>
        private enum Columns
        {
            /// <summary>
            /// 患者姓名
            /// </summary>
            PatientName,

            /// <summary>
            /// 卡号
            /// </summary>
            CardNO,

            /// <summary>
            /// 发票号
            /// </summary>
            InvoiceNO,

            /// <summary>
            /// 发票流水号
            /// </summary>
            InvoiceComb

        }

        #endregion

        #region 方法

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="list"></param>
        public void Add(ArrayList list)
        {
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.Balance obj in list)
            {
                this.fpSpread1_Sheet1.Rows.Add(0, 1);
                this.fpSpread1_Sheet1.Cells[0, (int)Columns.PatientName].Text = obj.Patient.Name;
                this.fpSpread1_Sheet1.Cells[0, (int)Columns.CardNO].Text = obj.Patient.PID.CardNO;
                this.fpSpread1_Sheet1.Cells[0, (int)Columns.InvoiceNO].Text = obj.ID;
                this.fpSpread1_Sheet1.Cells[0, (int)Columns.InvoiceComb].Text = obj.CombNO;
                this.fpSpread1_Sheet1.Rows[0].Tag = obj;
            }
        }

        #endregion

        #region 事件

        private void ucInvoiceSelect_Load(object sender, System.EventArgs e)
        {
            this.fpSpread1.Select();
            this.fpSpread1.Focus();
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            selectedBalance = (Neusoft.HISFC.Models.Fee.Outpatient.Balance)this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag;
            this.FindForm().Close();
        }

        private void fpSpread1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            selectedBalance = (Neusoft.HISFC.Models.Fee.Outpatient.Balance)this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag;
            this.FindForm().Close();
        }

        #endregion
        

       
    }
}
