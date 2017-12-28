using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Query
{
    public partial class ucQueryEmrComLogo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryEmrComLogo()
        {
            InitializeComponent();
        }
        #region  变量
        public string strSql = "";
        Neusoft.FrameWork.Management.DataBaseManger dbMgr = new Neusoft.FrameWork.Management.DataBaseManger();
        //工具栏
      
        #endregion

        #region 方法
        public void Query()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            int index = 0;
            string temp = "";
            temp = getSqlStr();
            DataSet ds = new DataSet();
            dbMgr.ExecQuery(temp, ref ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    this.fpSpread1_Sheet1.Rows.Add(i, 1);
                    this.fpSpread1_Sheet1.Cells[i, 0].Text = ds.Tables[0].Rows[i][0].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 1].Text = ds.Tables[0].Rows[i][1].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 2].Text = ds.Tables[0].Rows[i][2].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 3].Text = ds.Tables[0].Rows[i][3].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 4].Text = ds.Tables[0].Rows[i][4].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 5].Text = ds.Tables[0].Rows[i][5].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 6].Text = ds.Tables[0].Rows[i][6].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 7].Text = ds.Tables[0].Rows[i][7].ToString();
                    this.fpSpread1_Sheet1.Cells[i, 8].Text = ds.Tables[0].Rows[i][8].ToString();


                }
            }
            else
            {
                this.fpSpread1_Sheet1.RowCount = 0;
            }

        }
        /// <summary>
        /// 获得SQL语句
        /// </summary>
        public string getSqlStr()
        {
            strSql = "select e.empl_code as 修改工号,e.empl_name as 修改人姓名 ,o.emrname as 病历名称," +
"o.nodename as 结点名称,o.oldvalue as 旧数据,o.newvalue as 新数据," +
"to_char(o.oper_date,'yyyy-mm-dd hh24:mi:ss') as 操作日期, o.index1 as 住院号,o.index2 as 患者姓名 " +
 "from emr_com_logo o ,com_employee e " +
 "where o.type='2' and o.memo='结点修改' and o.oper_code=e.empl_code and o.oldvalue is not null and o.oldvalue <>'-'";

            if (this.chkperid.Checked)
            {
                strSql = strSql + " and o.oper_code like '%" + this.txtId.Text.Trim() + "'";
            }
            if (this.chkinpano.Checked)
            {
                strSql = strSql + " and o.index1 like '%" + this.txtInpatientno.Text.Trim() + "'";
            }
            if (this.chknodevalue.Checked)
            {
                strSql = strSql + " and o.nodename='" + this.txtnodevalue.Text.Trim() + "'";
            }
            if (this.chkoperdate.Checked)
            {
                strSql = strSql + " and to_char(o.oper_date,'yyyy-mm-dd')=to_char(to_date('" + this.dateTimePicker1.Text.Trim() + "','yyyy-mm-dd'),'yyyy-mm-dd')";
            }
            strSql = strSql + " order by o.oper_date desc";

            return strSql;


        }
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        public void ExportFarPoint()
        {
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "xls|*.xls";
            if (sa.ShowDialog() == DialogResult.OK)
            {
                this.fpSpread1.SaveExcel(sa.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            }
        }
        #endregion


        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            return base.Init(sender, neuObject, param);
        }
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBar = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
            toolBar.AddToolButton("查询日志", "查询日志", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询, true, false, null);
            toolBar.AddToolButton("导出EXCEL", "导出到EXCEL", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);
            return toolBar;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "查询日志")
            {
                this.Query();
            }
            else if (e.ClickedItem.Text == "导出EXCEL")
            {
                this.ExportFarPoint();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        //protected override int OnQuery(object sender, object neuObject)
        //{
        //    Query();
        //}
   
    }
}
