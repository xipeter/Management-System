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
    public partial class ucReportDoctor : UserControl, Neusoft.FrameWork.WinForms.Forms.IReport
    {
        public ucReportDoctor()
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

			ArrayList DataAl = new ArrayList();
            DataAl = Environment.ReportManager.GetReport11(this.cmbDept.Tag.ToString(), this.dtpBegin.Value, this.dtpEnd.Value);
			if(DataAl == null || DataAl.Count == 0) return -1;
			//合计数
			long total = 0;
			
			foreach(ArrayList thisData in DataAl)
			{
				if(thisData == null || thisData.Count < 3) continue;
				if(thisData[0].ToString() == "") thisData[0] = "未知";
				if(thisData[1].ToString() == "") thisData[1] = "未知";
				if(thisData[2].ToString() == "") thisData[2] = "0";
				this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count,1);
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1,0].Value = thisData[0].ToString();
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1,1].Value = thisData[1].ToString();
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1,2].Value = thisData[2].ToString();
				try
				{
					total = total + long.Parse(thisData[2].ToString());
				}
				catch{}
			}
			//设置“合计”行
			this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count,1);
			this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1,0].Value = "合  计 :";
			this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1,2].Value = total.ToString();
			this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);

            this.fpSpread1_Sheet1.Columns[0].Locked = true;
            this.fpSpread1_Sheet1.Columns[1].Locked = true;
            this.fpSpread1_Sheet1.Columns[2].Locked = true;
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
