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
    /// [功能描述: 手术分类汇总统计(按性别)]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportGender : ucReportBase
    {
        public ucReportGender()
        {
            InitializeComponent();
            this.Title = "手术登记分类汇总统计(按性别)";
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            this.fpSpread1_Sheet1.Columns[-1].Width = 150;
            this.fpSpread1_Sheet1.Columns[-1].Locked = true;


        }

#region 事件



        protected override int OnQuery()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            ArrayList DataAl = new ArrayList();

            DataAl = Environment.ReportManager.GetReport07(this.cmbDept.Tag.ToString(), this.dtpBegin.Value, this.dtpEnd.Value);
            if (DataAl == null || DataAl.Count == 0) return -1;
            //合计数
            long ll_Total = 0;

            foreach (ArrayList thisData in DataAl)
            {
                if (thisData == null || thisData.Count < 2) continue;
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = thisData[0].ToString();
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Value = thisData[1].ToString();
                try
                {
                    ll_Total = ll_Total + long.Parse(thisData[1].ToString());
                }
                catch { }
            }
            //设置“合计”行
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = "合  计 :";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Value = ll_Total.ToString();
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);

            return 0;
        }
#endregion
    }
}
