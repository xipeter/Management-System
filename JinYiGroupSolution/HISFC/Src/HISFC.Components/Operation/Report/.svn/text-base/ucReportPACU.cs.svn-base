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
    /// [功能描述: 进入PACU病人数统计]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportPACU : UserControl, Neusoft.FrameWork.WinForms.Forms.IReport
    {
        public ucReportPACU()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
            }
        }


        #region 方法
        private void Init()
        {
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;

            this.dtpBegin.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEnd.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 23:59:59");

        }
        #endregion

        #region IReport 成员

        public int Query()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            ArrayList DataAl = new ArrayList();

            DataAl = Environment.ReportManager.GetReport12(Environment.OperatorDeptID, this.dtpBegin.Value, this.dtpEnd.Value);
            if (DataAl == null || DataAl.Count == 0) 
                return -1;

            this.fpSpread1_Sheet1.Rows.Add(0, 1);
            foreach (ArrayList thisData in DataAl)
            {
                if (thisData == null || thisData.Count < 2) continue;

                if (thisData[0].ToString() == "男")
                    this.fpSpread1_Sheet1.Cells[0, 1].Value = thisData[1].ToString();
                else
                    this.fpSpread1_Sheet1.Cells[0, 2].Value = thisData[1].ToString();
            }
            int iCountF = 0;
            int iCountM = 0;
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                //男患者数
                if (this.fpSpread1_Sheet1.Cells[i, 1].Value == null)
                    this.fpSpread1_Sheet1.Cells[i, 1].Value = "0";
                iCountM = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 1].Value.ToString());
                //女患者数
                if (this.fpSpread1_Sheet1.Cells[i, 2].Value == null)
                    this.fpSpread1_Sheet1.Cells[i, 2].Value = "0";
                iCountF = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[i, 2].Value.ToString());
                //男女合计
                this.fpSpread1_Sheet1.Cells[i, 0].Value = System.Convert.ToString(iCountM + iCountF);
            }


            return 0;
        }

        #endregion

        #region IReportPrinter 成员

        public int Print()
        {
            return Environment.Print.PrintPreview(30,0,this.neuPanel2);
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region 事件


        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            this.lblTime.Text = string.Concat("查询时间：", this.dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"), " -- ", this.dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion


    }


}
