using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Neusoft.HISFC.Components.Common.Report
{
    public class Function
    {
        public static int DisplayToFp( FarPoint.Win.Spread.SheetView sv,DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int dtRowIdx = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dtRowIdx = dt.Rows.IndexOf(dr);
                int dtColumnIdx = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    dtColumnIdx = dt.Columns.IndexOf(dc);
                    switch (dc.DataType.ToString())
                    {
                        case "System.Decimal":
                            {
                                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].Text = dr[dtColumnIdx].ToString();         
                                break;
                            }
                        default:
                            {
                                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].Text = dr[dtColumnIdx].ToString();
                                break;
                            }
                    }
                    //sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].Text = dr[dtColumnIdx].ToString();
                }
            }
            return 1;
        }
        public static int DisplayToFpReverse( FarPoint.Win.Spread.SheetView sv,DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int dtRowIdx = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dtRowIdx = dt.Rows.IndexOf(dr);
                int dtColumnIdx = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    dtColumnIdx = dt.Columns.IndexOf(dc);
                    sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].Text = dr[dtColumnIdx].ToString();
                }
            }
            return 1;
        }
        public static int DrawGridLine(FarPoint.Win.Spread.SheetView sv,int row, int column, int rowCount, int columnCount)
        {
            #region 画格
            FarPoint.Win.LineBorder lineBorderLTRB = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, true, true, true);
            int row2 = 0;
            int column2 = 0;
            if (row + rowCount - 1 >= row)
            {
                row2 = row + rowCount - 1;
            }
            else
            {
                row2 = row;
            }
            if (column + columnCount - 1 >= column)
            {
                column2 = column + columnCount - 1;
            }
            else
            {
                column2 = column;
            }
            if (rowCount>0)
            {
                sv.Cells[row, column, row2, column2].Border = lineBorderLTRB; 
            }
            return 1;
            //#region 先画左上
            //FarPoint.Win.LineBorder lineBorderLT = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, true, false, false);
            //SvMain.Cells[this.DataBeginRowIndex + 1, 0, this.DataBeginRowIndex + this.dataRowCount, dataDisplayColumns.Length - 1].Border = lineBorderLT;
            //#endregion
            //#region 再画最下面
            //FarPoint.Win.LineBorder lineBorderLTB = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, true, false, true);
            //SvMain.Cells[this.DataBeginRowIndex + this.dataRowCount, 0, this.DataBeginRowIndex + this.dataRowCount, dataDisplayColumns.Length - 1].Border = lineBorderLTB;
            //#endregion
            //#region 再画最右面
            //FarPoint.Win.LineBorder lineBorderLTR = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, true, true, false);
            //SvMain.Cells[this.DataBeginRowIndex + 1, dataDisplayColumns.Length - 1, this.DataBeginRowIndex + this.dataRowCount, dataDisplayColumns.Length - 1].Border = lineBorderLTR;
            //#endregion
            //#region 再画右下的一个格
            ////FarPoint.Win.LineBorder lineBorderLTRB = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, true, true, true);
            //SvMain.Cells[this.DataBeginRowIndex + this.dataRowCount, dataDisplayColumns.Length - 1, this.DataBeginRowIndex + this.dataRowCount, dataDisplayColumns.Length - 1].Border = lineBorderLTRB;
            //#endregion
            #endregion
        }
    }
}
