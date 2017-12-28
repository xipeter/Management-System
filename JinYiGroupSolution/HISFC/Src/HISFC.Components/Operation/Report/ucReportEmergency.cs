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
    /// [功能描述: 急诊感染手术统计]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportEmergency : ucReportBase
    {
        public ucReportEmergency()
        {
            InitializeComponent();
            this.Title = "急诊感染手术统计";
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            this.fpSpread1_Sheet1.Columns[-1].Width = 150;
            this.fpSpread1_Sheet1.Columns[-1].Locked = true;


        }

#region 事件



        protected override int OnQuery()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            System.Data.DataSet ds = null;


            ds = Environment.ReportManager.GetEmergencyOperation(this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
            

            //ds = m_OpsReportManager.GetSpecalOperationReport(m_DeptID,this.BeginTime,this.EndTime);

            if (ds == null || ds.Tables.Count == 0) return -1;
            this.fpSpread1_Sheet1.DataSource = ds.Tables[0];

            //手术室要求显示总费用，不再显示单价 modified by cuipeng 2006-08-11
            //this.fpSpread1_Sheet1.Columns[5].Visible = false;//不显示单价

            return 0;
        }
#endregion
    }
}