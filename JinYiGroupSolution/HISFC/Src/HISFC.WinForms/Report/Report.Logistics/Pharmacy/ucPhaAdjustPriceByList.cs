using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaAdjustPriceByList : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量

        private Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        string strFilterByDrug = "(药品名称 like '%{0}%') or (drug_spellcode like '%{0}%')";
        string strFilterByOper = "(调价人 like '%{0}%') or (oper_spellcode like '%{0}%')";
       

        #endregion

        public ucPhaAdjustPriceByList()
        {
            InitializeComponent();
        }

        private void ucPhaAdjustPriceByList_Load(object sender, EventArgs e)
        {
            this.dtpBeginTime.Value = this.dtpBeginTime.Value.Date;
            this.dtpEndTime.Value = this.dtpEndTime.Value.Date.AddDays(1).AddMilliseconds(-1);
        }

        #region 方法

        private void DrugFilter()
        {
            string str = "";
            string drug = txtDrug.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(drug))
            {
                //dwMain.SetFilter("");
                //dwMain.Filter();

                dv.RowFilter = "";
                return;
            }
            else
            {
                try
                {
                    str = string.Format(strFilterByDrug,drug);
                    dv.RowFilter = str;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("格式化字符串出错 !");
                    return;
                }
                //dwMain.SetFilter(str);
                //dwMain.Filter();
            }
            //dwMain.SetSort("调价单号");
            //dwMain.Sort();
        }

        private void OperFilter()
        {
            string str = "";
            string oper = txtOper.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(oper))
            {
                //dwMain.SetFilter("");
                //dwMain.Filter();
                dv.RowFilter = "";
                return;
            }
            else
            {
                try
                {
                    str = string.Format(strFilterByOper,oper);

                    dv.RowFilter = str;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("格式化字符串出错 !");
                    return;
                }
                //dwMain.SetFilter(str);
                //dwMain.Filter();
            }
            //dwMain.SetSort("调价单号");
            //dwMain.Sort();
        }

       


        protected override int OnRetrieve(params object[] objects)
        {
            string adjustNo = "%"+ txtNo.Text.Trim()+"%";

            if(this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间!");
                return -1;
            }

         
       
            return base.OnRetrieve(empl.Dept.ID, this.dtpBeginTime.Value,this.dtpEndTime.Value,adjustNo);
            //return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, "ALL", adjustNo);
        }

        #endregion

        #region 事件

        private void txtDrug_TextChanged(object sender, EventArgs e)
        {
            this.DrugFilter();
        }

        private void txtOper_TextChanged(object sender, EventArgs e)
        {
            this.OperFilter();
        }

        #endregion

     
    }
}
