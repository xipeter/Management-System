using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucCollectDayBalanceInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCollectDayBalanceInfo()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Neusoft.Report.Finance.FinOpb.Function.ClinicDayBalance();
        /// <summary>
        /// 日结序号
        /// </summary>
        private string balanceNO = string.Empty;
        
        #endregion
        /// <summary>
        /// 日结序号
        /// </summary>
        public string BalaceNO
        {
            get
            {
                return balanceNO;
            }
        }
        #region 属性
        
        #endregion
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0) return;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = "True";
            }
        }

        private void ucCollectDayBalanceInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            DateTime begin = this.dtBeginDate.Value;
            DateTime end = this.dtEndDate.Value;
            int resultValue = 0;
            List<Class.ClinicDayBalanceNew> list = new List<Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew>();
            #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
            if (this.ckRePrint.Checked == true)
            {
                resultValue = clinicDayBalance.GetCheckedCollectDayBalanceInfo(begin.ToString(), end.ToString(), ref list);
            }
            else
            {
                resultValue = clinicDayBalance.GetCollectDayBalanceInfo(begin.ToString(), end.ToString(), ref list);

            } 
            #endregion
            if (resultValue == -1) return;
            this.neuSpread1_Sheet1.Rows.Count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = "False";
                this.neuSpread1_Sheet1.Cells[i, 1].Text = list[i].Oper.Name;
                this.neuSpread1_Sheet1.Cells[i, 2].Text = list[i].BeginTime.ToString();
                this.neuSpread1_Sheet1.Cells[i, 3].Text = list[i].EndTime.ToString();
                this.neuSpread1_Sheet1.Cells[i, 4].Text = list[i].BegionInvoiceNO.ToString();
                this.neuSpread1_Sheet1.Cells[i, 5].Text = list[i].EndInvoiceNo.ToString();
                #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
                this.neuSpread1_Sheet1.Cells[i, 6].Text = list[i].Memo.ToString(); 
                #endregion
                this.neuSpread1_Sheet1.Rows[i].Tag = list[i];
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Class.ClinicDayBalanceNew obj = null;
            for (int i = 0; i < neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text != "True") continue;
                if (this.neuSpread1_Sheet1.Rows[i].Tag == null) continue;
                obj = this.neuSpread1_Sheet1.Rows[i].Tag as Class.ClinicDayBalanceNew;
                balanceNO += obj.BlanceNO + ",";
            } 
            
            if (balanceNO == string.Empty)
            {
                MessageBox.Show("请选择要汇总的数据！");
                return;
            }
            balanceNO = balanceNO.Substring(0, balanceNO.LastIndexOf(","));
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.ckRePrint.Checked == true)
            {
                if (this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text == "False")
                {
                    this.neuSpread1.Sheets[0].Cells[0, 0, this.neuSpread1.Sheets[0].RowCount - 1, 0].Text = "False";
                    Class.ClinicDayBalanceNew cdbn;
                    cdbn = this.neuSpread1_Sheet1.Rows[e.Row].Tag as Class.ClinicDayBalanceNew;
                    for (int i = 0; i < this.neuSpread1.Sheets[0].RowCount; i++)
                    {
                        Class.ClinicDayBalanceNew cdbnCurrent;
                        cdbnCurrent = this.neuSpread1_Sheet1.Rows[i].Tag as Class.ClinicDayBalanceNew;
                        if (cdbn.Memo == cdbnCurrent.Memo)
                        {
                            this.neuSpread1_Sheet1.Cells[i, 0].Text = "True";
                        }
                    }
                }
                else
                {
                    this.neuSpread1.Sheets[0].Cells[0, 0, this.neuSpread1.Sheets[0].RowCount - 1, 0].Text = "False";
                }
                e.Cancel = true;
            }
        } 
        #endregion

      
    }
}
