namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucSchemaTemplate
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSchemaTemplate));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Size = new System.Drawing.Size(200, 100);
            this.fpSpread1.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance3;
            this.fpSpread1.ActiveSheetIndex = -1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            
            this.neuSpread1.BackColor = System.Drawing.SystemColors.Window;
           // this.neuSpread1.CanCustomConfigColumn = false;
            this.neuSpread1.EditModePermanent = true;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.Location = new System.Drawing.Point(3, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(526, 448);

            this.neuSpread1.TabIndex = 0;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance4;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 15;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "DeptID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "出诊科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "DoctID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "出诊医生";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "医生类别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "午别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "开始时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "结束时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "挂号限额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "预约限额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "特诊限额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "是否加号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "是否有效";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType10;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "ID";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 52F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType11;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "DeptID";
            this.neuSpread1_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType12.StringTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType12;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "出诊科室";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 103F;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = textCellType13;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "DoctID";
            this.neuSpread1_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType14;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "出诊医生";
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = textCellType15;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "医生类别";
            this.neuSpread1_Sheet1.Columns.Get(6).AllowAutoSort = true;
            textCellType16.StringTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.neuSpread1_Sheet1.Columns.Get(6).CellType = textCellType16;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "午别";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 66F;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.DateDefault = new System.DateTime(2006, 12, 31, 10, 40, 44, 0);
            dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType3.TimeDefault = new System.DateTime(2006, 12, 31, 10, 40, 44, 0);
            dateTimeCellType3.UserDefinedFormat = "HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(7).CellType = dateTimeCellType3;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "开始时间";
            dateTimeCellType4.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType4.Calendar")));
            dateTimeCellType4.DateDefault = new System.DateTime(2006, 12, 31, 10, 40, 44, 0);
            dateTimeCellType4.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType4.TimeDefault = new System.DateTime(2006, 12, 31, 10, 40, 44, 0);
            dateTimeCellType4.UserDefinedFormat = "HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(8).CellType = dateTimeCellType4;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "结束时间";
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.MaximumValue = 9999;
            numberCellType4.MinimumValue = 0;
            this.neuSpread1_Sheet1.Columns.Get(9).CellType = numberCellType4;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "挂号限额";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 64F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 9999;
            numberCellType5.MinimumValue = 0;
            this.neuSpread1_Sheet1.Columns.Get(10).CellType = numberCellType5;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "预约限额";
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 9999;
            numberCellType6.MinimumValue = 0;
            this.neuSpread1_Sheet1.Columns.Get(11).CellType = numberCellType6;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "特诊限额";
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "是否加号";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 37F;
            this.neuSpread1_Sheet1.Columns.Get(13).CellType = textCellType17;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "是否有效";
            this.neuSpread1_Sheet1.Columns.Get(13).Width = 34F;
            textCellType18.StringTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.neuSpread1_Sheet1.Columns.Get(14).CellType = textCellType18;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 176F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Location = new System.Drawing.Point(110, 143);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(200, 161);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "neuGroupBox1";
            // 
            // ucSchemaTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucSchemaTemplate";
            this.Size = new System.Drawing.Size(529, 451);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
    }
}
