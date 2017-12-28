using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.OutpatientFee.DayBalance
{
    public partial class ucCollectDayBalance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCollectDayBalance()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Report.OutpatientFee.Function.ClinicDayBalance();
        /// <summary>
        /// 当前操作员
        /// </summary>
        NeuObject currentOperator = new NeuObject();

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 日结序号
        /// </summary>
        private string balanceNo = string.Empty;
        #endregion


        #region 方法

        #region 汇总已日结数据
        private void QueryDayBalanceRecord(string balanceNO)
        {
            // 返回值
            int intReturn = 0;
            // 查询的起始时间
            DateTime dtFrom = DateTime.MinValue;
            // 查询的截止时间
            DateTime dtTo = DateTime.MinValue;
            // 查询的日记流水号
            string sequence = "";

            //清除数据
            int count = this.ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count;
            if (count > 0)
            {
                this.ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Remove(0, count);
            }
            
            DataSet ds=new DataSet();
            intReturn = this.clinicDayBalance.GetCollectDayBalanceData(balanceNO, ref ds);
            if (intReturn == -1)
            {
                MessageBox.Show(this.clinicDayBalance.Err);
                return;
            }
            //设置报表信息
            //this.SetInfo(begin, end, 1);

            if (ds.Tables.Count == 0 || ds == null || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("该时间段内没有要查找的数据！");
                return;
            }
            SetOldFarPointData(ds.Tables[0]);
            ds.Dispose();
        }
        #endregion

        #region 设置已日结Farpoint数据
        private void SetOldFarPointData(DataTable table)
        {
            FarPoint.Win.Spread.SheetView sheet = this.ucClinicDayBalanceReportNew1.neuSpread1_Sheet1;
            int rowCount = sheet.Rows.Count;
            if (sheet.Rows.Count > 0)
            {
                sheet.Rows.Remove(0, rowCount - 1);
            }
            DataView dv = table.DefaultView;
            //设置项目明细
            SetDetialed(sheet, dv);
            this.ucClinicDayBalanceReportNew1.SetFarPoint();
            this.SetInvoiced(sheet, dv);
            this.SetMoneyed(sheet, dv);
        }

        /// <summary>
        /// 设置已日结发票信息
        /// </summary>
        /// <param name="sheet">FarPoint.Win.Spread.SheetView</param>
        /// <param name="dv">DataView</param>
        protected virtual void SetInvoiced(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            dv.RowFilter = "BALANCE_ITEM='5'";
            this.SetFarpointValue(sheet, dv);
        }

        protected virtual void SetMoneyed(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            dv.RowFilter = "BALANCE_ITEM='6'";
            this.SetFarpointValue(sheet, dv);
        }

        protected virtual void SetFarpointValue(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            if (dv.Count > 0)
            {
                string fieldStr = string.Empty;
                string tagStr = string.Empty;
                string field = string.Empty;
                int Index = 0;
                for (int k = 0; k < dv.Count; k++)
                {
                    fieldStr = dv[k]["sort_id"].ToString();
                    int index = fieldStr.IndexOf('、');
                    if (index == -1)
                    {
                        Index = fieldStr.IndexOf("|");
                        tagStr = fieldStr.Substring(0, Index);
                        field = fieldStr.Substring(Index + 1);
                        SetOneCellText(sheet, tagStr, dv[k][field].ToString());
                        if (dv[k][1].ToString() == "A023")
                        {
                            SetOneCellText(sheet, "A1000", NConvert.ToCapital(NConvert.ToDecimal(dv[k][field])));
                        }
                    }
                    else
                    {
                        string[] aField = fieldStr.Split('、');
                        if (aField.Length == 0) continue;
                        string s = aField[0];
                        Index = s.IndexOf("|");
                        tagStr = s.Substring(0, Index);
                        field = s.Substring(Index + 1);
                        SetOneCellText(sheet, tagStr, dv[k][field].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 设置已日结项目明细
        /// </summary>
        /// <param name="sheet">FarPoint.Win.Spread.SheetView</param>
        /// <param name="dv">DataView</param>
        private void SetDetialed(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            #region 显示项目数据
            //项目数据
            dv.RowFilter = "BALANCE_ITEM='4'";
            int count = dv.Count;
            decimal countMoney = 0;
            if (count > 0)
            {
                if (count % 2 == 0)
                {
                    sheet.Rows.Count = Convert.ToInt32(count / 2);
                }
                else
                {
                    sheet.Rows.Count = Convert.ToInt32(count / 2) + 1;
                }

                //显示项目数据
                for (int i = 0; i < count; i++)
                {
                    int index = Convert.ToInt32(i / 2);
                    int intMod = (i + 1) % 2;
                    if (intMod > 0)
                    {
                        sheet.Models.Span.Add(index, 0, 1, 2);
                        sheet.Cells[index, 0].Text = dv[i]["extent_field1"].ToString();
                        sheet.Cells[index, 2].Text = dv[i]["tot_cost"].ToString();
                    }
                    else
                    {
                        sheet.Models.Span.Add(index, 3, 1, 2);
                        sheet.Cells[index, 3].Text = dv[i]["extent_field1"].ToString();
                        sheet.Cells[index, 5].Text = dv[i]["tot_cost"].ToString();
                    }
                    countMoney += Convert.ToDecimal(dv[i][0]);

                }
                if (count % 2 > 0)
                {
                    sheet.Models.Span.Add(sheet.Rows.Count - 1, 3, 1, 2);
                }
                //显示合计
                sheet.Rows.Count += 1;
                count = sheet.Rows.Count;
                sheet.Models.Span.Add(count - 1, 0, 1, 2);
                sheet.Cells[count - 1, 0].Text = "合计：";
                sheet.Models.Span.Add(count - 1, 2, 1, 4);
                sheet.Cells[count - 1, 2].Text = countMoney.ToString();
            }
            #endregion
        }
        #endregion

        #region 按tag读取FarPoint的cell数据
        /// <summary>
        /// 设置单个Cell的Text
        /// </summary>
        /// <param name="sheet">SheetView</param>
        /// <param name="tagStr">Cell的tag</param>
        /// <param name="strText">要显示的Text</param>
        private void SetOneCellText(FarPoint.Win.Spread.SheetView sheet, string tagStr, string strText)
        {
            FarPoint.Win.Spread.Cell cell = sheet.GetCellFromTag(null, tagStr);
            if (cell != null)
            {
                FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
                t.Multiline = true;
                t.WordWrap = true;
                cell.CellType = t;
                cell.Text += strText;
            }
        }

        private string GetOneCellText(FarPoint.Win.Spread.SheetView sheet, string tagStr)
        {
            FarPoint.Win.Spread.Cell cell = sheet.GetCellFromTag(null, tagStr);
            if (cell != null)
                return cell.Text;
            return string.Empty;
        }
        #endregion

        #region 增加ToolBar按狃
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
     
            toolBarService.AddToolButton("汇总", "汇总日结费用统计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);
            #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
            toolBarService.AddToolButton("补打", "补打已汇总日结费用统计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null); 
            #endregion

            toolBarService.AddToolButton("确认", "保存汇总记录", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);

            return toolBarService;
        }
        #endregion

        #region 汇总
        /// <summary>
        /// 获取汇总数据
        /// </summary>
        protected virtual void GetCollectData()
        {
            ucCollectDayBalanceInfo c = new ucCollectDayBalanceInfo();
            DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(c);
            if (result == DialogResult.OK)
            {
                balanceNo = c.BalaceNO;
                this.QueryDayBalanceRecord(balanceNo);
            }
            else
            {
                balanceNo = string.Empty;
            }
        }

        #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
        /// <summary>
        /// 获取汇总数据,补打用
        /// </summary>
        protected virtual void GetCheckedCollectData()
        {
            ucCollectDayBalanceInfo c = new ucCollectDayBalanceInfo();
            c.ckRePrint.Checked = true;
            DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(c);
            if (result == DialogResult.OK)
            {
                balanceNo = c.BalaceNO;
                this.QueryDayBalanceRecord(balanceNo);
                balanceNo = string.Empty;
            }
            else
            {
                balanceNo = string.Empty;
            }
        } 
        #endregion
        /// <summary>
        /// 保存汇总数据
        /// </summary>
        protected virtual void SaveCollectData()
        {
            if (balanceNo == string.Empty)
            {
                #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
                MessageBox.Show("请先汇总数据！"); 
                #endregion
                return;
            }
            DialogResult result = MessageBox.Show("确认要汇总数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            DateTime operTime = clinicDayBalance.GetDateTimeFromSysDateTime();
            if (clinicDayBalance.SaveCollectData(currentOperator.ID, operTime, balanceNo) <1)
            {
                MessageBox.Show("保存成功！");
                return ;
            }
            balanceNo = string.Empty;
            MessageBox.Show("保存成功！");
        }
            
        #endregion
        #endregion

        #region 事件
        protected override int OnQuery(object sender, object neuObject)
        {
            //this.QueryDayBalanceRecord();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this.panelPrint);
            return base.OnPrint(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "汇总":
                    {
                        GetCollectData();
                        break;
                    }
                #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
                case "补打":
                    {
                        GetCheckedCollectData();
                        break;
                    } 
                #endregion
                case "确认":
                    {
                        SaveCollectData();
                        break;
                    }
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void ucCollectDayBalance_Load(object sender, EventArgs e)
        {
            currentOperator = this.clinicDayBalance.Operator;
            //表示在汇总数据
            this.ucClinicDayBalanceReportNew1.IsCollectData = true;
            this.ucClinicDayBalanceReportNew1.InitUC("门诊收费员日结汇总报表");
        }

        #endregion

        
    }
}
