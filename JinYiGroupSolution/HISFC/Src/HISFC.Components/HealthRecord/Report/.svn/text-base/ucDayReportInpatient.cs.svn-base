using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Report
{
    public partial class ucDayReportInpatient : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDayReportInpatient()
        {
            InitializeComponent();
        }

        #region 变量

        private DataTable dtDayReport;
        private DataView dvDayReport;
        //private string SettingFileName = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + @".\InpatientDayReport.xml";
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        private DateTime dtDay;
        #endregion

        #region 方法


        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitFrp(DateTime date)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化表格，请稍候.....");
                GetData(date);
            }

            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        private void InitDataSet()
        {
            dtDayReport = new DataTable("DayReport");

            dtDayReport.Columns.AddRange(new DataColumn[]
			{
                new DataColumn("DateStat",typeof(DateTime)),
                new DataColumn("DeptID",typeof(string)),
                new DataColumn("DeptName",typeof(string)),
                new DataColumn("BedStandNum",typeof(int)),
                new DataColumn("RemainYesterdayNum",typeof(int)),
                new DataColumn("InNormalNum",typeof(int)),
                new DataColumn("InChangeNum",typeof(int)),
                new DataColumn("OutNormalNum",typeof(int)),
                new DataColumn("OutChangeNum",typeof(int)),
                new DataColumn("AccNum",typeof(int)),
                new DataColumn("BanpNum",typeof(int)),
                new DataColumn("HasRecord",typeof(int))
			});
        }
        /// <summary>
        /// 设置Farpoint显示格式
        /// </summary>
        private void SetFpFormat()
        {
            FarPoint.Win.Spread.CellType.NumberCellType numbCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numbCellType.DecimalPlaces = 0;
            numbCellType.MaximumValue = 9999;
            numbCellType.MinimumValue = 0;

            FarPoint.Win.Spread.CellType.DateTimeCellType dtCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dtCellType.UserDefinedFormat = "yyyy-MM-dd";
            dtCellType.ReadOnly = true;

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

            #region "设置每列的颜色"
            this.neuSpread1_Sheet1.Columns[0].CellType = dtCellType;
            this.neuSpread1_Sheet1.Columns[0].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[0].Label = "日期";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[0].Width = 90f;
            this.neuSpread1_Sheet1.Columns[1].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[1].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[2].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[2].Label = "科室名称";
            this.neuSpread1_Sheet1.Columns[3].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[3].Label = "编制内病床数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[3].Width = 90f;
            this.neuSpread1_Sheet1.Columns[3].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.Columns[4].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[4].Label = "原有病人数";
            this.neuSpread1_Sheet1.Columns[4].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.Columns[5].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[5].Label = "常规入院数";
            this.neuSpread1_Sheet1.Columns[6].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[6].Label = "转入数";
            this.neuSpread1_Sheet1.Columns[7].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[7].Label = "常规出院数";
            this.neuSpread1_Sheet1.Columns[8].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[8].Label = "转出数";
            this.neuSpread1_Sheet1.Columns[9].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[9].Label = "陪护人数";
            this.neuSpread1_Sheet1.Columns[10].CellType = numbCellType;
            this.neuSpread1_Sheet1.Columns[10].ForeColor = Color.Red;
            this.neuSpread1_Sheet1.Columns[10].Font = new Font("Arial", 9, FontStyle.Bold);
            this.neuSpread1_Sheet1.ColumnHeader.Columns[10].Label = "期末实有人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[10].Width = 100f;
            this.neuSpread1_Sheet1.Columns[11].CellType = numbCellType;
            this.neuSpread1_Sheet1.Columns[11].Visible = false;
            #endregion
            
        }
        #endregion

        #region 事件
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("修改床位数", "修改床位数", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "修改床位数":
                    this.EditBedNum();
                    break;                              
            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            //if ( != 0)
            //{
            //    MessageBox.Show("保存失败");
            //}
            //else
            //{
            return 0;
            //}
        }
        private int EditBedNum()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                dtDayReport.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }
            //保存
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            if (dtDayReport != null)
            {
                try
                {
                    foreach (DataRow dtRow in dtDayReport.Rows )
                    {
                        Neusoft.HISFC.Models.HealthRecord.DayReport dr;
                        dr = new Neusoft.HISFC.Models.HealthRecord.DayReport();
                        dr.DateStat = DateTime.Parse(dtRow["DateStat"].ToString());
                        dr.Dept.ID = dtRow["DeptID"].ToString();
                        dr.Dept.Name = dtRow["DeptName"].ToString();
                        dr.BedStandNum = int.Parse(dtRow["BedStandNum"].ToString());
                        dr.RemainYesterdayNum = int.Parse(dtRow["RemainYesterdayNum"].ToString());
                        dr.InNormalNum = int.Parse(dtRow["InNormalNum"].ToString());
                        dr.InChangeNum = int.Parse(dtRow["InChangeNum"].ToString());
                        dr.OutNormalNum = int.Parse(dtRow["OutNormalNum"].ToString());
                        dr.OutChangeNum = int.Parse(dtRow["OutChangeNum"].ToString());
                        dr.AccNum = int.Parse(dtRow["AccNum"].ToString());
                        dr.BanpNum = int.Parse(dtRow["BanpNum"].ToString());
                        dr.HasRecord = dtRow["HasRecord"].ToString();
                        al.Add(dr);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("修改床位数，生成实体集合时出错!" + e.Message, "提示");
                    return -1;
                }
            }

            try
            {
                Neusoft.HISFC.BizLogic.HealthRecord.DayReport dayReport;
                dayReport = new Neusoft.HISFC.BizLogic.HealthRecord.DayReport();
                if (dayReport.EditBedNum (al) == -1)
                {
                    MessageBox.Show("修改床位数失败!", "提示");
                    return -1;
                }
            }
            catch (Exception e)
            {

                return -1;
            }

            //dtDayReport.AcceptChanges();
            //foreach (DataRow dr in dtDayReport.Rows)
            //{
            //    dr["HasRecord"] = "1";
            //}
            //dtDayReport.AcceptChanges();
            InitFrp(dtDay);
            return 0;
        }
        private int Save()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                dtDayReport.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }
            //保存
            System.Collections.ArrayList  al = new System.Collections.ArrayList ();
            if (dtDayReport != null)
            {
                try
                {
                    foreach (DataRow dtRow in dtDayReport.Rows )
                    {
                        Neusoft.HISFC.Models.HealthRecord.DayReport dr;
                        dr = new Neusoft.HISFC.Models.HealthRecord.DayReport();
					    dr.DateStat=DateTime.Parse(dtRow["DateStat"].ToString());
                        dr.Dept.ID = dtRow["DeptID"].ToString();
                        dr.Dept.Name = dtRow["DeptName"].ToString();
                        dr.BedStandNum = int.Parse(dtRow["BedStandNum"].ToString());
                        dr.RemainYesterdayNum = int.Parse(dtRow["RemainYesterdayNum"].ToString());
                        dr.InNormalNum = int.Parse(dtRow["InNormalNum"].ToString());
                        dr.InChangeNum = int.Parse(dtRow["InChangeNum"].ToString());
                        dr.OutNormalNum = int.Parse(dtRow["OutNormalNum"].ToString());
                        dr.OutChangeNum = int.Parse(dtRow["OutChangeNum"].ToString());
                        dr.AccNum = int.Parse(dtRow["AccNum"].ToString());
                        dr.BanpNum = int.Parse(dtRow["BanpNum"].ToString());
                        dr.HasRecord = dtRow["HasRecord"].ToString();
                        al.Add(dr);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("保存住院日报信息，生成实体集合时出错!" + e.Message, "提示");
                    return -1;                   
                }
            }

            try
            {
                Neusoft.HISFC.BizLogic.HealthRecord.DayReport dayReport;
                dayReport = new Neusoft.HISFC.BizLogic.HealthRecord.DayReport();
                if (dayReport.Save(al) == -1)
                {
                    MessageBox.Show("保存住院日报信息失败!" + dayReport.Err, "提示");
                    return -1;
                }
            }
            catch (Exception e)
            {
               
                return -1;
            }

            //dtDayReport.AcceptChanges();
            //foreach (DataRow  dr in dtDayReport.Rows )
            //{
            //    dr["HasRecord"] = "1";
            //}
            //dtDayReport.AcceptChanges();
            InitFrp(dtDay);
            return 0;
        }
       
        private void ucDayReportInpatient_Load(object sender, EventArgs e)
        {
            
            //设置数据列
            InitDataSet();
            dtDay = DateTime.Now.Date;
            this.InitFrp(dtDay);
        }
        /// <summary>
        /// 是否修改数据？
        /// </summary>
        /// <returns></returns>
        public bool IsChange()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                this.dtDayReport.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }

            DataTable dt = dtDayReport.GetChanges();

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        #region 变更前内容
        ///// <summary>
        ///// 设置单击事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void linkLblSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //    #region 设置列控件初始化
        //    Common.Controls.ucSetColumn usc;
        //    usc = new Common.Controls.ucSetColumn();
        //    usc.FilePath = this.SettingFileName;
        //    usc.SetColVisible(true, true, false, false);
        //    usc.SetDataTable(this.SettingFileName, this.neuSpread1_Sheet1);
        //    #endregion

        //    ///设置标题
        //    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
        //    ///设置事件代理
        //    usc.DisplayEvent += new EventHandler(usc_DisplayEvent);
        //    ///显示设置窗体
        //    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(usc);
        //    ///删除事件代理
        //    usc.DisplayEvent -= new EventHandler(usc_DisplayEvent);
        //}

        ///// <summary>
        ///// 设置窗体关闭事件处理程序
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void usc_DisplayEvent(object sender, EventArgs e)
        //{
        //    ///重新加载设置
        //    InitFrp(this.txtStatDate.Value.Date);
        //}

        ///// <summary>
        ///// 列宽度变更的事件处理程序
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        //{
        //    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.SettingFileName);
        //} 
        #endregion

        #endregion


        /// <summary>
        /// 日期改变事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatDate_ValueChanged(object sender, EventArgs e)
        {
            if (IsChange())
            {
                if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (Save() == -1)
                    {
                        this.txtStatDate.Value = dtDay;
                        return;
                    }
                }
            }
            //else
            //{
            dtDay = this.txtStatDate.Value.Date;
            InitFrp(dtDay);
            //}
        }
        public override int Exit(object sender, object neuObject)
        {
            if (IsChange())
            {
                if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (Save() == -1)
                    {
                        return -1;
                    }
                }
            }
            return base.Exit(sender, neuObject);
        }
        private void GetData(DateTime dt)
        {
            //清空原有数据
            this.dtDayReport.Rows.Clear();
            Neusoft.HISFC.BizLogic.HealthRecord.DayReport dayReport;
            dayReport = new Neusoft.HISFC.BizLogic.HealthRecord.DayReport();
            System.Collections.ArrayList al;
            al = new System.Collections.ArrayList();
            al=dayReport.QueryByStatTime( this.txtStatDate.Value.Date );
            try
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.DayReport dr in al)
                {

                    this.dtDayReport.Rows.Add(new object[]
					{
					    dr.DateStat,
                        dr.Dept.ID,
                        dr.Dept.Name,
                        dr.BedStandNum ,
                        dr.RemainYesterdayNum ,
                        dr.InNormalNum ,
                        dr.InChangeNum ,
                        dr.OutNormalNum ,
                        dr.OutChangeNum ,
                        dr.AccNum ,
                        dr.BanpNum ,
                        dr.HasRecord
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("查询住院日报信息生成DataSet时出错!" + e.Message, "提示");
                return;
            }
            this.dtDayReport.AcceptChanges();
            this.dvDayReport  = dtDayReport.DefaultView;
            this.dvDayReport.AllowDelete = true;
            this.dvDayReport.AllowEdit = true;
            this.dvDayReport.AllowNew = true;            
            this.neuSpread1_Sheet1.DataSource = dvDayReport;
            this.neuSpread1_Sheet1.DataMember = "DayReport";
            this.SetFpFormat();
        }

        private void neuSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            int rowIdx = 0;
            int colIdx = 0;
            rowIdx= neuSpread1_Sheet1.ActiveRowIndex;
            colIdx = neuSpread1_Sheet1.ActiveColumnIndex;
            if (colIdx != 10)
            {
                #region 
                //if (System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 4].Value) +
                //    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 5].Value) +
                //    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 6].Value) -
                //    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 7].Value) -
                //    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 8].Value) > 0)
                //{ 
                #endregion
                neuSpread1_Sheet1.Cells[rowIdx, 10].Value =
                            System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 4].Value) +
                            System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 5].Value) +
                            System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 6].Value) -
                            System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 7].Value) -
                            System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 8].Value);
                #region 
                //}
                //else
                //{
                //    MessageBox.Show("输入有误将会使期末实有病人数为负！");
                //    neuSpread1.SetActiveCell(e.Row,e.Column);
                //    neuSpread1.EditMode = true;
                //} 
                #endregion
            }
            else
            {
                if (System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 10].Value) !=
                    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 4].Value) +
                    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 5].Value) +
                    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 6].Value) -
                    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 7].Value) -
                    System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 8].Value))
                {

                    #region 
                    //if (MessageBox.Show("期末实有病人数有误差，是否修改原有病人数！", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{ 
                    #endregion
                    ///为保证等式的成立设为原与人数是不确定的，发现存在误差修改原有人数
                    neuSpread1_Sheet1.Cells[rowIdx, 4].Value =
                                System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 10].Value) -
                                System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 5].Value) -
                                System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 6].Value) +
                                System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 7].Value) +
                                System.Convert.ToInt32(neuSpread1_Sheet1.Cells[rowIdx, 8].Value);
                    #region 
                    //}
                    //else
                    //{
                    //    neuSpread1.SetActiveCell(rowIdx, 10);
                    //    neuSpread1.EditMode = true;
                    //} 
                    #endregion
                }
            }
        }

       
    }
}

