using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class frmSelectRegister : Form
    {
        public frmSelectRegister()
        {
            InitializeComponent();

            this.fpSpread1.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);
            this.bnOK.Click += new EventHandler(bnOK_Click);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
        }

        public void SetRegInfo(ArrayList alRegs)
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            foreach (Neusoft.HISFC.Models.Registration.Register reg in alRegs)
            {
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

                int row = this.fpSpread1_Sheet1.RowCount - 1;

                this.fpSpread1_Sheet1.SetValue(row, 0, reg.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 1, reg.DoctorInfo.Templet.Dept.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 2, reg.DoctorInfo.Templet.Doct.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 3, reg.DoctorInfo.SeeDate.ToString(), false);

                this.fpSpread1_Sheet1.Rows[row].Tag = reg;
            }
        }

        /// <summary>
        /// 选择挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Reg
        {
            get
            {
                if (this.fpSpread1_Sheet1.RowCount <= 0)
                {
                    return null;
                }


                int row = this.fpSpread1_Sheet1.ActiveRowIndex;

                return (Neusoft.HISFC.Models.Registration.Register)this.fpSpread1_Sheet1.Rows[row].Tag;
            }
        }
        
        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            OK();
        }

        private void OK()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                MessageBox.Show("无符合条件的挂号信息!", "提示");
                return;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            this.OK();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OK();
        }
    }
}