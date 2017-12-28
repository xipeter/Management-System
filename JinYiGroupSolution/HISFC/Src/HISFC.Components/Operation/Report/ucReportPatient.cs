using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation.Report
{
    /// <summary>
    /// [功能描述: 手术患者信息查询]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportPatient : ucReportBase
    {
        public ucReportPatient()
        {
            InitializeComponent();
            this.ShowCategory = true;
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            this.Title = "手术患者信息查询";
            this.cmbCategory.Visible = false;
            this.neuLabel4.Visible = false;
        }

#region 事件

        protected override int OnQuery()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            System.Data.DataSet ds = Environment.ReportManager.GetPersonOperation(this.cmbDept.Tag.ToString(), this.dtpBegin.Value, this.dtpEnd.Value);
            if (ds == null)
            {
                MessageBox.Show("查询数据出错");
                return -1;
            }
            this.fpSpread1.DataSource = ds;
            //设置“合计”行
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = "合  计 :";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Value = "共 " + (this.fpSpread1_Sheet1.RowCount - 1).ToString() + " 人";
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            //this.fpSpread1_Sheet1.Columns[0].Width = 80;
            //this.fpSpread1_Sheet1.Columns[1].Width = 80;
            //this.fpSpread1_Sheet1.Columns[2].Width = 80;
            //this.fpSpread1_Sheet1.Columns[3].Width = 40;
            //this.fpSpread1_Sheet1.Columns[4].Width = 40;
            //this.fpSpread1_Sheet1.Columns[5].Width = 100;
            //this.fpSpread1_Sheet1.Columns[6].Width = 100;
            //this.fpSpread1_Sheet1.Columns[7].Width = 100;
            //this.fpSpread1_Sheet1.Columns[8].Width = 100;
            //this.fpSpread1_Sheet1.Columns[9].Width = 40;
            //this.fpSpread1_Sheet1.Columns[10].Width = 40;
            //this.fpSpread1_Sheet1.Columns[10].Width = 40;

            return 0;
        }
#endregion
    }
}
