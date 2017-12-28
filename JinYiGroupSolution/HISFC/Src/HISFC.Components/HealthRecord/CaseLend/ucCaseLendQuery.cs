using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.HealthRecord.CaseLend
{
    /// <summary>
    /// ucCaseLendQuery<br></br>
    /// <Font color='#FF1111'>[功能描述: 病案借阅查询]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-10-3]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucCaseLendQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucCaseLendQuery()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量

        private Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private Neusoft.HISFC.BizLogic.HealthRecord.CaseCard caseCardManager = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();

        private DataTable dt = null;

        #endregion

        #region 属性

        private bool IsLendDateEnable
        {
            set
            {
                this.chkLendDate.Checked = value;
                this.dtpLendBeginDate.Enabled = value;
                this.dtpLendEndDate.Enabled = value;
            }
            get
            {
                return this.chkLendDate.Checked;
            }
        }

        private bool IsPreReDateEnable
        {
            set
            {
                this.chkPreReDate.Checked = value;
                this.dtpPreReBeginDate.Enabled = value;
                this.dtpPreReEndDate.Enabled = value;
            }
            get
            {
                return this.chkPreReDate.Checked;
            }
        }

        private bool IsReturnDateEnable
        {
            set
            {
                this.chkReturnDate.Checked = value;
                this.dtpReturnBeginDate.Enabled = value;
                this.dtpReturnEndDate.Enabled = value;
                //如果选中归还时间则状态自动选为“已归还”
                this.cmbState.Tag = value ? "2" : "1";
            }
            get
            {
                return this.chkReturnDate.Checked;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void InitCmb()
        {
            ArrayList alEmp = this.interManager.QueryEmployeeAll();
            if (alEmp != null)
            {
                alEmp.Insert(0, new NeuObject("ALL", "全部", ""));
                this.cmbBorrowPerson.AddItems(alEmp);
            }
            ArrayList alDept = this.interManager.GetDepartment();
            if (alDept != null)
            {
                alDept.Insert(0, new NeuObject("ALL", "全部", ""));
                this.cmbBorrowDept.AddItems(alDept);
            }
            ArrayList alState = new ArrayList();
            alState.Add(new NeuObject("ALL", "全部", ""));
            alState.Add(new NeuObject("1", "借出", ""));
            alState.Add(new NeuObject("2", "返还", ""));
            this.cmbState.AddItems(alState);
        }

        /// <summary>
        /// 初始化数据表
        /// </summary>
        private void InitDataTable()
        {
            this.dt = new DataTable();
            this.dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("病案号",typeof(string)),
                new DataColumn("患者姓名",typeof(string)),
                new DataColumn("生日",typeof(string)),
                new DataColumn("入院日期",typeof(string)),
                new DataColumn("出院日期",typeof(string)),
                new DataColumn("入院科室",typeof(string)),
                new DataColumn("借阅人",typeof(string)),
                new DataColumn("借阅科室",typeof(string)),
                new DataColumn("借阅日期",typeof(string)),
                new DataColumn("预定还期",typeof(string)),
                new DataColumn("借阅状态",typeof(string)),
                new DataColumn("归还日期",typeof(string)),
                new DataColumn("INPATIENT_NO",typeof(string)),
                new DataColumn("EMPL_CODE",typeof(string)),
                new DataColumn("DEPT_CODE",typeof(string)),
                new DataColumn("STATE",typeof(string)),
                new DataColumn("OBJECT",typeof(string))
            });
            this.neuSpread1_Sheet1.DataSource = this.dt;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("生日")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("INPATIENT_NO")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("EMPL_CODE")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("DEPT_CODE")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("STATE")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("OBJECT")].Visible = false;
        }

        private void SetFpStyle()
        {

        }

        private void SetDefaultCondition()
        {
            this.txtCaseNo.Text = "";
            this.cmbBorrowPerson.Tag = "ALL";
            this.cmbBorrowDept.Tag = "ALL";
            this.cmbState.Tag = "1";
            this.IsLendDateEnable = true;
            this.IsPreReDateEnable = false;
            this.IsReturnDateEnable = false;
            this.dtpLendBeginDate.Value = DateTime.Now.AddMonths(-1);
            this.dtpLendEndDate.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
        }

        private int GetColIndex(string lable)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Label == lable)
                {
                    return i;
                }
            }
            return -2;
        }

        private void QueryData()
        {
            this.dt.Clear();
            string strWhere = "";
            if (this.GetWhereString(ref strWhere) < 0)
            {
                return;
            }
            ArrayList alData = this.caseCardManager.QueryLendInfoByWhereString(strWhere);
            if (alData == null)
            {
                MessageBox.Show("查询出错：" + this.caseCardManager.Err);
                return;
            }
            this.AddDataToTable(alData);
        }

        private void AddDataToTable(ArrayList alData)
        {
            foreach (Neusoft.HISFC.Models.HealthRecord.Lend info in alData)
            {
                DataRow dr = this.dt.NewRow();
                this.dt.Rows.Add(dr);
                dr["病案号"] = info.CaseBase.CaseNO;
                dr["患者姓名"] = info.CaseBase.PatientInfo.Name;
                dr["生日"] = info.CaseBase.PatientInfo.Birthday.ToString("yyyy-MM-dd");
                dr["入院日期"] = info.CaseBase.PatientInfo.PVisit.InTime.ToString("yyyy-MM-dd");
                dr["出院日期"] = info.CaseBase.PatientInfo.PVisit.OutTime.ToString("yyyy-MM-dd");
                dr["入院科室"] = info.CaseBase.InDept.Name;
                dr["借阅人"] = info.EmployeeInfo.Name;
                dr["借阅科室"] = info.EmployeeDept.Name;
                dr["借阅日期"] = info.LendDate.ToString("yyyy-MM-dd");
                dr["预定还期"] = info.PrerDate.ToString("yyyy-MM-dd");
                dr["借阅状态"] = (info.LendStus == "1") ? "借出" : "返还";
                dr["归还日期"] = info.ReturnDate.ToString("yyyy-MM-dd");
                dr["INPATIENT_NO"] = info.CaseBase.PatientInfo.ID;
                dr["EMPL_CODE"] = info.EmployeeInfo.ID;
                dr["DEPT_CODE"] = info.EmployeeDept.ID;
                dr["STATE"] = info.LendStus;
                dr["OBJECT"] = info;
            }
            this.dt.AcceptChanges();
            this.SetFpStyle();
        }

        private int GetWhereString(ref string strWhere)
        {
            strWhere = " where 1 = 1 ";
            if (!string.IsNullOrEmpty(this.txtCaseNo.Text.Trim()))
            {
                strWhere += " and PATIENT_NO = '" + this.txtCaseNo.Text.Trim() + "' ";
            }
            if (this.cmbBorrowPerson.Tag != null && this.cmbBorrowPerson.Tag.ToString() != "ALL")
            {
                strWhere += " and EMPL_CODE = '" + this.cmbBorrowPerson.Tag.ToString() + "' ";
            }
            if (this.cmbBorrowDept.Tag != null && this.cmbBorrowDept.Tag.ToString() != "ALL")
            {
                strWhere += " and DEPT_CODE = '" + this.cmbBorrowDept.Tag.ToString() + "' ";
            }
            if (this.cmbState.Tag != null && this.cmbState.Tag.ToString() != "ALL")
            {
                strWhere += " and LEN_STUS = '" + this.cmbState.Tag.ToString() + "'";
            }
            if (this.IsLendDateEnable)
            {
                strWhere += " and (LEND_DATE >= to_date('" + this.dtpLendBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and LEND_DATE <= to_date('" + this.dtpLendEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) ";
            }
            if (this.IsPreReDateEnable)
            {
                strWhere += " and (PRER_DATE >= to_date('" + this.dtpPreReBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and PRER_DATE <= to_date('" + this.dtpPreReEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) ";
            }
            if (this.IsReturnDateEnable)
            {
                strWhere += " and (RETURN_DATE >= to_date('" + this.dtpReturnBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and RETURN_DATE <= to_date('" + this.dtpReturnEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) ";
            }
            return 1;
        }
        #endregion

        #region 事件
        private void ucCaseLendQuery_Load(object sender, EventArgs e)
        {
            this.InitCmb();
            this.InitDataTable();
            this.SetFpStyle();
            this.SetDefaultCondition();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            this.SetDefaultCondition();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();
            return 1;
        }

        private void txtCaseNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCaseNo.Text.Trim()))
            {
                return;
            }
            this.txtCaseNo.Text = this.txtCaseNo.Text.Trim().PadLeft(10, '0');
        }

        private void chkLendDate_CheckedChanged(object sender, EventArgs e)
        {
            this.IsLendDateEnable = this.chkLendDate.Checked;
        }

        private void chkPreReDate_CheckedChanged(object sender, EventArgs e)
        {
            this.IsPreReDateEnable = this.chkPreReDate.Checked;
        }

        private void chkReturnDate_CheckedChanged(object sender, EventArgs e)
        {
            this.IsReturnDateEnable = this.chkReturnDate.Checked;
        }

        #endregion

    }
}
