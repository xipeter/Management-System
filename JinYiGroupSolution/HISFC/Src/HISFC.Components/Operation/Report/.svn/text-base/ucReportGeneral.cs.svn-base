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
    /// [功能描述: 手术分类统计一览表]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportGeneral : ucReportBase
    {
        public ucReportGeneral()
        {
            InitializeComponent();
            this.Title = "手术分类统计一览表";
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            this.fpSpread1_Sheet1.Columns[-1].Width = 150;
            this.fpSpread1_Sheet1.Columns[-1].Locked = true;

            this.fpSpread1_Sheet1.Cells[0, 0].Value = "普通手术";
            this.fpSpread1_Sheet1.Cells[1, 0].Value = "急诊手术";
            this.fpSpread1_Sheet1.Cells[2, 0].Value = "感染手术";
            this.fpSpread1_Sheet1.Cells[3, 0].Value = "合  计：";
        }

#region 事件



        protected override int OnQuery()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            ArrayList DataAl = new ArrayList();


            DataAl = Environment.ReportManager.GetReport05(this.cmbDept.Tag.ToString(), this.dtpBegin.Value, this.dtpEnd.Value);
            if (DataAl == null || DataAl.Count == 0) return -1;

            this.fpSpread1_Sheet1.Rows.Add(0, 4);
            this.fpSpread1_Sheet1.Cells[0, 0].Value = "普通手术";
            this.fpSpread1_Sheet1.Cells[1, 0].Value = "急诊手术";
            this.fpSpread1_Sheet1.Cells[2, 0].Value = "感染手术";
            this.fpSpread1_Sheet1.Cells[3, 0].Value = "合  计：";

            //当前数据应插入的位置
            int iRow = 0;
            int iCol = 0;
            string data = "";

            foreach (ArrayList thisData in DataAl)
            {
                if (thisData == null || thisData.Count < 3) continue;
                data = thisData[0].ToString();
                if (data == null || data == "") continue;
                iRow = Neusoft.FrameWork.Function.NConvert.ToInt32(thisData[0].ToString()) - 1;
                data = thisData[1].ToString();
                if (data == null || data == "") continue;

                iCol = Neusoft.FrameWork.Function.NConvert.ToInt32(thisData[1].ToString());
                if (thisData[2].ToString() != "")
                    this.fpSpread1_Sheet1.Cells[iRow, iCol].Value = thisData[2].ToString();
                else
                    this.fpSpread1_Sheet1.Cells[iRow, iCol].Value = "0";
            }

            //每行的合计数("合计"行不计)
            int iRowTotal = 0;
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count - 1; i++)
            {
                iRowTotal =
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 1].Value) + //特大手术数
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 2].Value) + //大手术数
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 3].Value) + //中手术数
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 4].Value);  //小手术数
                this.fpSpread1_Sheet1.Cells[i, 5].Value = iRowTotal.ToString();
                iRowTotal = 0;
            }
            //每列的合计数(标题列不计)
            int iColTotal = 0;
            for (int j = 1; j < this.fpSpread1_Sheet1.Columns.Count; j++)
            {
                iColTotal =
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[0, j].Value) + //普通手术数
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[1, j].Value) + //急诊手术数
                    Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[2, j].Value);  //感染手术数
                this.fpSpread1_Sheet1.Cells[3, j].Value = iColTotal.ToString();
                iColTotal = 0;
            }
            return 0;
        }
#endregion
    }
}
