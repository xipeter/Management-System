using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFC.Registration.Report
{
    /// <summary>
    /// 挂号情况查询
    /// </summary>
    public partial class ucQueryRegister : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucQueryRegister()
        {
            InitializeComponent();

            this.init();

            this.txtCardNo.KeyDown += new KeyEventHandler(txtCardNo_KeyDown);
            this.txtInvoice.KeyDown += new KeyEventHandler(txtInvoice_KeyDown);
            this.txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);
        }

        /// <summary>
        /// 挂号管理类
        /// </summary>
        protected Neusoft.HISFC.Management.Registration.Register regMgr = new Neusoft.HISFC.Management.Registration.Register();
        
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.dateBegin.Value = this.regMgr.GetDateTimeFromSysDateTime().Date;
            this.dateEnd.Value = this.dateBegin.Value;

            //挂号科室
            Neusoft.HISFC.Integrate.Manager deptMgr = new Neusoft.HISFC.Integrate.Manager();

            ArrayList al = deptMgr.QueryRegDepartment();
            if (al == null) al = new ArrayList();

            this.cmbDept.AddItems(al);            

            //挂号医生            
            al = deptMgr.QueryEmployee(Neusoft.HISFC.Object.Base.EnumEmployeeType.D);
            if (al == null) al = new ArrayList();

            this.cmbDoct.AddItems(al);            

            //操作员
            al = deptMgr.QueryEmployeeAll();
            if (al == null) al = new ArrayList();

            this.cmbOper.AddItems(al);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            string where1 = this.getSingleWhere();

            string where2 = "";

            if (this.getCompoundWhere(ref where2) == -1) return;

            if (where1 != "" && where2 != "")
            {
                where1 = where1 + " AND " + where2;
            }
            else if (where2 != "")
            {
                where1 = where2;
            }
            else if (where1 == "" && where2 == "")
            {
                MessageBox.Show("请指定查询条件!", "提示");
                return;
            }

            string sql = "";
            if (this.regMgr.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return;

            sql = sql + " WHERE " + where1 + " AND TRANS_TYPE ='1'";

            ArrayList al = this.regMgr.QueryRegister(sql);
            if (al == null) return;

            this.addDetail(al);
        }


        private string getSingleWhere()
        {
            string where = "";

            if (this.txtCardNo.Text.Trim() != "")
            {
                string cardNo = this.txtCardNo.Text.Trim().PadLeft(10, '0');
                this.txtCardNo.Text = cardNo;
                this.txtCardNo.SelectAll();
                where = "CARD_NO ='" + cardNo + "'";
                return where;
            }

            if (this.txtName.Text.Trim() != "")
            {
                where = "NAME like '%" + this.txtName.Text.Trim() + "%'";
                return where;
            }

            if (this.txtInvoice.Text.Trim() != "")
            {
                string invoiceNo = this.txtInvoice.Text.Trim();
                this.txtInvoice.Text = invoiceNo;

                where = "RECIPE_NO = '" + invoiceNo + "'";
                return where;
            }

            return "";
        }


        private int getCompoundWhere(ref string rtn)
        {
            string where = "";

            if (this.checkBox1.Checked)
            {
                if (this.dateBegin.Value > this.dateEnd.Value)
                {
                    MessageBox.Show("查询开始时间不能大于结束时间!", "提示");
                    rtn = "";
                    return -1;
                }

                where = "OPER_DATE >=to_date('" + this.dateBegin.Value.ToString() + "','yyyy-mm-dd HH24:mi:ss')" +
                    " AND OPER_DATE <=to_date('" + this.dateEnd.Value.AddDays(1).ToString() + "','yyyy-mm-dd HH24:mi:ss')";
            }

            if (this.checkBox2.Checked && this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
            {
                if (where != "")
                    where = where + " AND ";

                where = where + "DEPT_CODE = '" + this.cmbDept.Tag.ToString() + "'";
            }

            if (this.checkBox3.Checked && this.cmbDoct.Tag != null && this.cmbDoct.Tag.ToString() != "")
            {
                if (where != "")
                    where = where + " AND ";

                where = where + "DOCT_CODE = '" + this.cmbDoct.Tag.ToString() + "'";
            }

            if (this.checkBox4.Checked && this.cmbOper.Tag != null && this.cmbOper.Tag.ToString() != "")
            {
                if (where != "")
                    where = where + " AND ";

                where = where + "OPER_CODE = '" + this.cmbOper.Tag.ToString() + "'";
            }

            if (this.checkBox5.Checked && this.cmbState.SelectedIndex != -1)
            {
                if (where != "")
                    where = where + " AND ";

                where = where + " valid_flag = '" + this.cmbState.SelectedIndex.ToString() + "'";
            }

            rtn = where;
            return 0;
        }



        private void addDetail(ArrayList al)
        {
            foreach (Neusoft.HISFC.Object.Registration.Register reg in al)
            {
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

                int row = this.fpSpread1_Sheet1.RowCount - 1;

                this.fpSpread1_Sheet1.SetValue(row, 0, reg.PID.CardNO, false);
                this.fpSpread1_Sheet1.SetValue(row, 1, reg.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 2, reg.PhoneHome, false);
                this.fpSpread1_Sheet1.SetValue(row, 3, reg.AddressHome, false);
                if (reg.IsFirst)
                {
                    this.fpSpread1_Sheet1.SetValue(row, 4, "初诊", false);
                }
                else
                {
                    this.fpSpread1_Sheet1.SetValue(row, 4, "复诊", false);
                }

                this.fpSpread1_Sheet1.SetValue(row, 5, reg.Pact.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 6, reg.DoctorInfo.Templet.RegLevel.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 7, reg.OwnCost.ToString(), false);
                this.fpSpread1_Sheet1.SetValue(row, 8, reg.DoctorInfo.SeeDate.ToString(), false);
                this.fpSpread1_Sheet1.SetValue(row, 9, reg.DoctorInfo.Templet.Dept.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 10, reg.DoctorInfo.Templet.Doct.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 11, reg.OrderNO.ToString(), false);

                if (reg.RegType == Neusoft.HISFC.Object.Base.EnumRegType.Pre)
                    this.fpSpread1_Sheet1.SetValue(row, 12, "是", false);
                else
                    this.fpSpread1_Sheet1.SetValue(row, 12, "否", false);

                if (reg.Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Valid)
                { this.fpSpread1_Sheet1.SetValue(row, 13, "正常", false); }
                else if (reg.Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Back)
                {
                    this.fpSpread1_Sheet1.SetValue(row, 13, "退号", false);
                    this.fpSpread1_Sheet1.Rows[row].BackColor = Color.MistyRose;
                }
                else
                {
                    this.fpSpread1_Sheet1.Rows[row].BackColor = Color.MistyRose;
                    this.fpSpread1_Sheet1.SetValue(row, 13, "作废", false);
                }

                if (reg.IsSee)
                    this.fpSpread1_Sheet1.SetValue(row, 14, "是", false);
                else
                    this.fpSpread1_Sheet1.SetValue(row, 14, "否", false);

                this.fpSpread1_Sheet1.SetValue(row, 15, reg.InputOper.ID, false);
                this.fpSpread1_Sheet1.SetValue(row, 16, reg.InputOper.OperTime.ToString(), false);
                this.fpSpread1_Sheet1.SetValue(row, 17, reg.InvoiceNO, false);
            }
        }



        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.Q.GetHashCode())
            {
                this.Query();

                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.P.GetHashCode())
            {
                this.fpSpread1.PrintSheet(0);
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Query();
            }
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Query();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Query();
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.fpSpread1.PrintSheet(0);

            return base.OnPrint(sender, neuObject);
        }
    }
}