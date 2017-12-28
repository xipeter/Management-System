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
    /// [功能描述: 手术分类汇总统计]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportCategory : UserControl, Neusoft.FrameWork.WinForms.Forms.IReport
    {
        public ucReportCategory()
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
            this.cmbCategory.SelectedIndex = 0;
            this.dtpBegin.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEnd.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 23:59:59");

            //手术室
            ArrayList alRet = Environment.IntegrateManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.OP);
            this.cmbDept.AddItems(alRet);
            this.cmbDept.IsListOnly = true;
            this.cmbDept.Tag = Environment.OperatorDeptID;

            //this.fpSpread1_Sheet1.RowCount = 2;
        }
        #endregion

        #region IReport 成员

        public int Query()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            string m_DeptID = this.cmbDept.Tag.ToString();

            ArrayList DataAl = null;
            switch (this.cmbCategory.SelectedIndex)
            {
                case 0:
                    DataAl = Environment.ReportManager.GetReport08(m_DeptID, this.dtpBegin.Value, this.dtpEnd.Value);
                    break;
                case 1:
                    DataAl = Environment.ReportManager.GetReport09(m_DeptID, this.dtpBegin.Value, this.dtpEnd.Value);
                    break;
                case 2:
                    DataAl = Environment.ReportManager.GetReport10(m_DeptID, this.dtpBegin.Value, this.dtpEnd.Value);
                    break;
            }
            if (DataAl == null || DataAl.Count == 0) 
                return -1;
            //合计
            long total = 0;

            //再加入
            foreach (ArrayList thisData in DataAl)
            {
                if (thisData == null || thisData.Count < 2) 
                    continue;
                this.fpSpread1_Sheet1.RowCount += 1;
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = thisData[0].ToString();
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Value = thisData[1].ToString();
                try
                {
                    total = total + long.Parse(thisData[1].ToString());
                }
                catch { }
            }
            //设置“合计”行
            this.fpSpread1_Sheet1.RowCount += 1;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = "合  计 :";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Value = total.ToString();
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);


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
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTitle.Text = string.Format("分类汇总统计手术例数(按{0})", this.cmbCategory.Text);
            this.fpSpread1_Sheet1.Columns[0].Label = this.cmbCategory.Text;
        }
     

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            this.lblTime.Text = string.Concat("查询时间：", this.dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"), " -- ", this.dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

   #endregion


    }


}
