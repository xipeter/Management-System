using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.Registration.Report
{
    /// <summary>
    /// 预约情况查询
    /// </summary>
    public partial class ucQueryBooking : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucQueryBooking()
        {
            InitializeComponent();

            this.init();

            this.txtCardNo.KeyDown += new KeyEventHandler(txtCardNo_KeyDown);
            this.txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);
            this.txtInvoice.KeyDown += new KeyEventHandler(txtInvoice_KeyDown);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellClick);
        }

        private Neusoft.HISFC.Management.Registration.Booking bookingMgr = new Neusoft.HISFC.Management.Registration.Booking();

        private Neusoft.HISFC.Management.Registration.Schema schemaMgr = new Neusoft.HISFC.Management.Registration.Schema();
               
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.dateBegin.Value = this.bookingMgr.GetDateTimeFromSysDateTime().Date;
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
            if (this.bookingMgr.Sql.GetSql("Registration.Booking.Query.1", ref sql) == -1) return;

            sql = sql + " WHERE " + where1;

            ArrayList al = this.bookingMgr.QueryBase(sql);
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

                where = "CARD_NO ='" + cardNo + "'";
                return where;
            }

            if (this.txtName.Text.Trim() != "")
            {
                where = "NAME  like '%" + this.txtName.Text.Trim() + "%'";
                return where;
            }

            if (this.txtInvoice.Text.Trim() != "")
            {
                string invoiceNo = this.txtInvoice.Text.Trim();

                where = "CLINIC_CODE = '" + invoiceNo + "'";
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

            rtn = where;
            return 0;
        }



        private void addDetail(ArrayList al)
        {
            foreach (Neusoft.HISFC.Object.Registration.Booking booking in al)
            {
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

                int row = this.fpSpread1_Sheet1.RowCount - 1;

                this.fpSpread1_Sheet1.SetValue(row, 0, booking.PID.CardNO, false);
                this.fpSpread1_Sheet1.SetValue(row, 1, booking.ID, false);
                this.fpSpread1_Sheet1.SetValue(row, 2, booking.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 3, booking.DoctorInfo.Templet.Dept.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 4, booking.DoctorInfo.Templet.Doct.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, 5, booking.DoctorInfo.SeeDate.ToString("yyyy-MM-dd"), false);
                this.fpSpread1_Sheet1.SetValue(row, 6, booking.DoctorInfo.Templet.Begin.ToString("HH:mm"), false);
                this.fpSpread1_Sheet1.SetValue(row, 7, booking.DoctorInfo.Templet.End.ToString("HH:mm"), false);
                this.fpSpread1_Sheet1.SetValue(row, 8, booking.IDCard, false);
                this.fpSpread1_Sheet1.SetValue(row, 9, booking.PhoneHome, false);
                this.fpSpread1_Sheet1.SetValue(row, 10, booking.AddressHome, false);
                //				this.fpSpread1_Sheet1.SetValue(row,11,booking.IsSee,false) ;
                //				this.fpSpread1_Sheet1.SetValue(row,12,booking.IsAppend,false) ;

                if (booking.IsSee)
                    this.fpSpread1_Sheet1.SetValue(row, 11, "是", false);
                else
                    this.fpSpread1_Sheet1.SetValue(row, 11, "否", false);

                if (booking.DoctorInfo.Templet.IsAppend)
                    this.fpSpread1_Sheet1.SetValue(row, 12, "是", false);
                else
                {
                    //this.fpSpread1_Sheet1.Rows[row].BackColor = Color.MistyRose;
                    this.fpSpread1_Sheet1.SetValue(row, 12, "否", false);
                }

                this.fpSpread1_Sheet1.Rows[row].Tag = booking;
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Control.GetHashCode() + Keys.Q.GetHashCode())
            {
                this.Query();

                return true;
            }
            else if (keyData.GetHashCode() == Keys.Control.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.FindForm().Close();

                return true;
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

        private void txtName_KeyDown(object sender, KeyEventArgs e)
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

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || this.fpSpread1_Sheet1.RowCount == 0) return;
            this.fpSpread1_Sheet1.ActiveRowIndex = e.Row;
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
