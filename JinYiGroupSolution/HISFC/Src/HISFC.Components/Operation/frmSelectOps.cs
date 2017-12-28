using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
    public partial class frmSelectOps :Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        private string opno = string.Empty;

        private bool isReg = false;

        public bool IsReg
        {
            get { return isReg; }
            set { isReg = value; }
        }

        public string OpNo
        {
            get { return opno; }
            set { opno = value; }
        }

        public frmSelectOps(string clinicCode)
        {
            InitializeComponent();
            BindOps(clinicCode);
        }

        private void BindOps(string clinicCode) 
        {
            //unreg
            DataTable table = Environment.OperationManager.QueryAllOps(clinicCode,Environment.OperatorDeptID);
            if (table != null)
            {
                if (table.Rows.Count > 0) 
                {
                    this.neuSpread1_Sheet1.DataSource = table;
                }
            }
            else 
            {
                
            }
            //reg
            DataTable table1 = Environment.OperationManager.QueryAllRegOps(clinicCode, Environment.OperatorDeptID);
            if (table1 != null)
            {
                if (table1.Rows.Count > 0)
                {
                    this.neuSpread1_Sheet2.DataSource = table1;
                }
            }
            else
            {

            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1.ActiveSheetIndex == 0)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex != -1)
                {
                    string op = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
                    if (!string.IsNullOrEmpty(op))
                    {
                        this.OpNo = op;
                        this.IsReg = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }

            if (this.neuSpread1.ActiveSheetIndex == 1)
            {
                if (this.neuSpread1_Sheet2.ActiveRowIndex != -1)
                {
                    string op = this.neuSpread1_Sheet2.Cells[this.neuSpread1_Sheet2.ActiveRowIndex, 0].Text;
                    if (!string.IsNullOrEmpty(op))
                    {
                        this.OpNo = op;
                        this.IsReg = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       

    }
}