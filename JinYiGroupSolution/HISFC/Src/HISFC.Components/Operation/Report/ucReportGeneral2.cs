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
    public partial class ucReportGeneral2 : ucReportBase
    {
        public ucReportGeneral2()
        {
            InitializeComponent();
            this.Title = "分类汇总统计手术例数(按手术医生所在病区)";
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            this.fpSpread1_Sheet1.Columns[-1].Width = 150;
            this.fpSpread1_Sheet1.Columns[-1].Locked = true;


        }

#region 事件



        protected override int OnQuery()
        {
            this.fpSpread1_Sheet1.RowCount = 0;

            #region 按照科室进行查询  by zlw 2006-5-17


            ArrayList DataAl;

            DataAl = Environment.ReportManager.GetReport06(this.cmbDept.Tag.ToString(), this.dtpBegin.Value, this.dtpEnd.Value);
            #endregion

            if (DataAl == null || DataAl.Count == 0) return -1;

            string strPreDept = "";
            string strCurDept = "";
            string strDegree = "";
            int iCol = 0;
            foreach (ArrayList thisData in DataAl)
            {
                if (thisData == null || thisData.Count < 3) 
                    continue;

                strCurDept = thisData[0].ToString();//科室名
                
                if (strCurDept == "") 
                    strCurDept = "未知";
                
                strDegree = thisData[1].ToString();//手术规模
                //始终保持当前填充数据的科室是第0行(提取过来的数据已经按照科室名排序过)
                //如果是一个新科室，则增加一行
                if (strCurDept != strPreDept)
                {
                    this.fpSpread1_Sheet1.Rows.Add(0, 1);
                    this.fpSpread1_Sheet1.Cells[0, 0].Value = strCurDept;
                }
                strPreDept = strCurDept;
                if (strDegree == null || strDegree == "") continue;

                iCol = Neusoft.FrameWork.Function.NConvert.ToInt32(strDegree);

                if (thisData[2].ToString() != "")
                    this.fpSpread1_Sheet1.Cells[0, iCol].Value = thisData[2].ToString();
                else
                    this.fpSpread1_Sheet1.Cells[0, iCol].Value = "0";
            }

            //增加“合计”行
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Value = "合  计：";

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
                //遍历该列的每一行
                for (int k = 0; k < this.fpSpread1_Sheet1.Rows.Count - 1; k++)
                {
                    iColTotal = iColTotal + Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1_Sheet1.Cells[k, j].Value);
                }
                //设置该列的合计数	
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, j].Value = iColTotal.ToString();
                iColTotal = 0;
            }

            return 0;
        }
#endregion
    }
}
