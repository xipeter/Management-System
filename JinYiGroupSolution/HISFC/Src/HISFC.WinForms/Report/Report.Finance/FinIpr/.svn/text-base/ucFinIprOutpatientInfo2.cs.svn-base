using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.Finance.FinIpr
{
    /// <summary>
    /// 出院患者信息查询--为病案室制作
    /// </summary>
    public partial class ucFinIprOutpatientInfo2 : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFinIprOutpatientInfo2()
        {
            InitializeComponent();
        }


        //出院患者信息查询
        string strSQL = @"select  a.dept_name 科室,
                                   a.patient_no 住院号,
                                   a.name 姓名,
                                   decode(a.sex_code,'F','女','M','男','不详') 性别,
                                   fun_get_age(a.birthday) 年龄,
                                   to_char(a.in_date,'yyyy-mm-dd') 入院时间,
                                   to_char(a.out_date,'yyyy-mm-dd') 出院时间,
                                   ceil(a.out_date - a.in_date) 住院天数,
                                   (select b.icd_code from met_com_diagnose b where b.inpatient_no = a.inpatient_no and b.diag_kind = 1 and rownum = 1 ) 出院诊断编码,
                                   (select b.diag_name from met_com_diagnose b where b.inpatient_no = a.inpatient_no and b.diag_kind = 1 and rownum = 1 ) 出院诊断

                            from  fin_ipr_inmaininfo  a
                            where  a.IN_STATE in ('B','O','P')
                            and    a.out_date >= to_date('{0}','yyyy-mm-dd hh24:mi:ss')
                            and    a.out_date  <= to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                            and (a.dept_code = '{2}' or '{2}' = 'ALL' )
                            order by a.dept_name,a.out_date";


        //Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        DataSet ds = new DataSet();
        Neusoft.HISFC.BizLogic.Manager.Department interManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        /// <summary>
        ///时间
        /// </summary>
        DateTime BeginDate
        {
            get
            {
                return   dtpBeginDate.Value ;//new DateTime(this.dtpBeginDate.Value.Year, this.dtpBeginDate.Value.Month, this.dtpBeginDate.Value.Day, 0, 0, 0);
                
            }
        }
        DateTime EndDate
        {
            get
            {
                return dtpEndDate.Value; //new DateTime(this.dtpEndDate.Value.Year, this.dtpEndDate.Value.Month, this.dtpEndDate.Value.Day, 23, 59, 59);
                    
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            ArrayList al = new ArrayList();
            al = interManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            al.Insert(0, new Neusoft.FrameWork.Models.NeuObject("ALL", "全部", ""));
            cmbDept.AddItems(al);
            cmbDept.SelectedIndex = 0;
            base.OnLoad(e);
        }


        protected override int OnQuery(object sender, object neuObject)
        {
            Query();
            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        protected int Query()
        {
            string tempSQL = null;
            string strErr = null;
            string strDept = null;
            string strDeptNM = null;
            DateTime dtBegin = new DateTime();
            DateTime dtEnd = new DateTime();

            dtBegin = new DateTime(this.dtpBeginDate.Value.Year, this.dtpBeginDate.Value.Month, this.dtpBeginDate.Value.Day, 0, 0, 0);
            dtEnd = new DateTime(this.dtpEndDate.Value.Year, this.dtpEndDate.Value.Month, this.dtpEndDate.Value.Day, 23, 59, 59);

            strDept = cmbDept.SelectedItem.ID;
            strDeptNM = cmbDept.SelectedItem.Name;



            tempSQL = string.Format(strSQL, dtBegin, dtEnd, strDept);
            try
            {
                interManager.ExecQuery(tempSQL, ref ds);
            }
            catch(Exception ex)
            {
                strErr = "查询数据失败！" + ex.Message;
                MessageBox.Show(strErr);
                return -1;
            }

            //向fp内添加数据
            if (ds.Tables.Count>0)
            {
                neuSpread1_Sheet1.DataSource = ds.Tables[0].DefaultView;
                Filter();
            }

            lbTitle1.Text = "查询时间：" + dtpBeginDate.Value.ToShortDateString() +
                            "至" + dtpEndDate.Value.ToShortDateString() +
                            "                   查询科室：" + strDeptNM +
                            "                   共：" + ds.Tables[0].Rows.Count.ToString() + "条记录";
            return 1;

        }

        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.cmbDept.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.Query();
                    this.ntbPatientID.Focus();
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <returns></returns>
        protected int Filter()
        {

            if (ds.Tables.Count <= 0)
            {
                return -1;
            }


            string strPID = null;
            
            strPID = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.ntbPatientID.Text.Trim());

            try
            {
                
                ds.Tables[0].DefaultView.RowFilter = "住院号 like '%" + strPID + "%'";


            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！"+ex.Message);
                return -1;
            }



            return 1;
            
        }

        private void ntbPatientID_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
            //page.HeightMM = 1060;
            //page.Width = 800;
            //page.Left = 100;

            print.SetPageSize(page);
            print.PrintPage(0, 0, this.neuPanel1);

            return base.OnPrint(sender, neuObject);
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!e.ColumnHeader)
            {
                return;
            }
            string clickedHeader = this.neuSpread1_Sheet1.Columns[e.Column].Label;
            string sort = this.ds.Tables[0].DefaultView.Sort;
            if (sort.Contains("DESC"))
            {
                this.ds.Tables[0].DefaultView.Sort = clickedHeader + " ASC";
            }
            else
            {
                this.ds.Tables[0].DefaultView.Sort = clickedHeader + " DESC";
            }
        }

       

    }
}
