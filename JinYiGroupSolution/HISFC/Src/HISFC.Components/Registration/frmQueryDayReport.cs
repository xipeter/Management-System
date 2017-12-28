using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFC.Registration
{
    public partial class frmQueryDayReport :Neusoft.NFC.Interface.Forms.BaseForm
    {
        public frmQueryDayReport()
        {
            InitializeComponent();

            this.fpSpread1.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);

            this.dateTimePicker2.Value = this.report.GetDateTimeFromSysDateTime();
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-3);
            this.Load += new EventHandler(frmQueryDayReport_Load);
            this.button3.Click += new EventHandler(button3_Click);
        }

        /// <summary>
        /// 日结管理类
        /// </summary>
        private Neusoft.HISFC.Management.Registration.DayReport report = new Neusoft.HISFC.Management.Registration.DayReport();
        /// <summary>
        /// 操作员代码
        /// </summary>
        public string OperID
        {
            set { this.operID = value; }
        }
        private string operID = "";

        /// <summary>
        /// 按日结序号查询日结信息
        /// </summary>		
        /// <returns></returns>
        public int Query()
        {
            ArrayList al = this.report.Query(operID, this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date.AddDays(1));

            if (al == null)
            {
                MessageBox.Show("查询操作员日结信息出错!" + this.report.Err, "提示");
                return -1;
            }

            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            foreach (Neusoft.HISFC.Object.Registration.DayReport obj in al)
            {
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

                int row = this.fpSpread1_Sheet1.RowCount - 1;

                this.fpSpread1_Sheet1.SetValue(row, 0, obj.ID, false);
                this.fpSpread1_Sheet1.SetValue(row, 1, obj.BeginDate.ToString(), false);
                this.fpSpread1_Sheet1.SetValue(row, 2, obj.EndDate.ToString(), false);
                this.fpSpread1_Sheet1.SetValue(row, 3, obj.SumOwnCost, false);
                this.fpSpread1_Sheet1.Rows[row].Tag = obj;
            }

            return 0;
        }

        /// <summary>
        /// 获取选择的日结信息
        /// </summary>
        public Neusoft.HISFC.Object.Registration.DayReport SelectedDayReport
        {
            get
            {
                if (this.fpSpread1_Sheet1.RowCount == 0) return null;

                int Row = this.fpSpread1_Sheet1.ActiveRowIndex;

                return (Neusoft.HISFC.Object.Registration.DayReport)this.fpSpread1_Sheet1.Rows[Row].Tag;
            }
        }

        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || this.fpSpread1_Sheet1.RowCount == 0) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmQueryDayReport_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Query();
            this.fpSpread1.Focus();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();

                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
    }
}