namespace Neusoft.HISFC.Components.Operation
{
    partial class ucArrangementSpread
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucArrangementSpread));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(1132, 611);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.EditModeOn += new System.EventHandler(this.fpSpread1_EditModeOn);
            this.fpSpread1.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_EditChange);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            this.fpSpread1.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpSpread1_LeaveCell);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 19;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "患者科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "年龄";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "手术名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "麻醉类别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "麻醉方式";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "手术医生";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "手术时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "房号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "巡回1";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "洗手1";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "进修1";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "巡回2";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "洗手2";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "进修2";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "手术间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "临时助手1";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "临时助手2";
            this.fpSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 48F;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "患者科室";
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 125F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "姓名";
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "性别";
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 36F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "年龄";
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 34F;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "手术名称";
            this.fpSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 128F;
            this.fpSpread1_Sheet1.Columns.Get(5).ForeColor = System.Drawing.Color.Blue;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "麻醉类别";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 83F;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "麻醉方式";
            this.fpSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 121F;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "手术医生";
            this.fpSpread1_Sheet1.Columns.Get(7).Locked = true;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.CalendarDayFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime(2006, 12, 11, 11, 18, 11, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            dateTimeCellType1.TimeDefault = new System.DateTime(2006, 12, 11, 11, 18, 11, 0);
            dateTimeCellType1.UserDefinedFormat = "dd HH:mm";
            this.fpSpread1_Sheet1.Columns.Get(8).CellType = dateTimeCellType1;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "手术时间";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 83F;
            this.fpSpread1_Sheet1.Columns.Get(11).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(11).Label = "洗手1";
            this.fpSpread1_Sheet1.Columns.Get(12).Label = "进修1";
            this.fpSpread1_Sheet1.Columns.Get(13).Label = "巡回2";
            this.fpSpread1_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Columns.Get(18).Label = "临时助手2";
            this.fpSpread1_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 0);
            // 
            // ucArrangementSpread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Name = "ucArrangementSpread";
            this.Size = new System.Drawing.Size(1132, 611);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
    }
}
