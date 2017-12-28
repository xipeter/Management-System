namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    partial class ucStoreStat
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
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoreStat));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBeginStat = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndStat = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpHeadSheet = new FarPoint.Win.Spread.SheetView();
            this.fpDetailSheet = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHeadSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetailSheet)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(722, 217);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "本期月结起始:";
            // 
            // dtpBeginStat
            // 
            this.dtpBeginStat.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginStat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginStat.Location = new System.Drawing.Point(291, 10);
            this.dtpBeginStat.Name = "dtpBeginStat";
            this.dtpBeginStat.Size = new System.Drawing.Size(153, 21);
            this.dtpBeginStat.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "本期月结截止:";
            // 
            // dtpEndStat
            // 
            this.dtpEndStat.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndStat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndStat.Location = new System.Drawing.Point(549, 10);
            this.dtpEndStat.Name = "dtpEndStat";
            this.dtpEndStat.Size = new System.Drawing.Size(153, 21);
            this.dtpEndStat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "月结科室:";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = false;
            this.cmbDept.IsLike = true;
            this.cmbDept.IsListOnly = false;
            this.cmbDept.IsPopForm = true;
            this.cmbDept.IsShowCustomerList = false;
            this.cmbDept.IsShowID = false;
            this.cmbDept.Location = new System.Drawing.Point(68, 11);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 4;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 月结记录";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 257);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpHeadSheet,
            this.fpDetailSheet});
            this.neuSpread1.Size = new System.Drawing.Size(722, 174);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 5;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // fpHeadSheet
            // 
            this.fpHeadSheet.Reset();
            this.fpHeadSheet.SheetName = "月结记录";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpHeadSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpHeadSheet.ColumnCount = 10;
            this.fpHeadSheet.RowCount = 0;
            this.fpHeadSheet.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 0).Value = "月结起始时间";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 1).Value = "月结终止时间";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 2).Value = "上期结存";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 3).Value = "上期入库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 4).Value = "上期出库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 5).Value = "特殊入库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 6).Value = "特殊出库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 7).Value = "盘点盈亏";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 8).Value = "调价盈亏";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 9).Value = "本期结存";
            this.fpHeadSheet.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.ColumnHeader.DefaultStyle.Locked = false;
            this.fpHeadSheet.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 4, 17, 13, 47, 45, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 4, 17, 13, 47, 45, 0);
            this.fpHeadSheet.Columns.Get(0).CellType = dateTimeCellType1;
            this.fpHeadSheet.Columns.Get(0).Label = "月结起始时间";
            this.fpHeadSheet.Columns.Get(0).Width = 123F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 4, 17, 13, 47, 48, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 4, 17, 13, 47, 48, 0);
            this.fpHeadSheet.Columns.Get(1).CellType = dateTimeCellType2;
            this.fpHeadSheet.Columns.Get(1).Label = "月结终止时间";
            this.fpHeadSheet.Columns.Get(1).Width = 123F;
            this.fpHeadSheet.Columns.Get(2).CellType = numberCellType1;
            this.fpHeadSheet.Columns.Get(2).Label = "上期结存";
            this.fpHeadSheet.Columns.Get(2).Width = 93F;
            this.fpHeadSheet.Columns.Get(3).CellType = numberCellType2;
            this.fpHeadSheet.Columns.Get(3).Label = "上期入库";
            this.fpHeadSheet.Columns.Get(3).Width = 93F;
            this.fpHeadSheet.Columns.Get(4).CellType = numberCellType3;
            this.fpHeadSheet.Columns.Get(4).Label = "上期出库";
            this.fpHeadSheet.Columns.Get(4).Width = 93F;
            this.fpHeadSheet.Columns.Get(5).CellType = numberCellType4;
            this.fpHeadSheet.Columns.Get(5).Label = "特殊入库";
            this.fpHeadSheet.Columns.Get(5).Width = 93F;
            this.fpHeadSheet.Columns.Get(6).CellType = numberCellType5;
            this.fpHeadSheet.Columns.Get(6).Label = "特殊出库";
            this.fpHeadSheet.Columns.Get(6).Width = 93F;
            this.fpHeadSheet.Columns.Get(7).CellType = numberCellType6;
            this.fpHeadSheet.Columns.Get(7).Label = "盘点盈亏";
            this.fpHeadSheet.Columns.Get(7).Width = 93F;
            this.fpHeadSheet.Columns.Get(8).CellType = numberCellType7;
            this.fpHeadSheet.Columns.Get(8).Label = "调价盈亏";
            this.fpHeadSheet.Columns.Get(8).Width = 93F;
            this.fpHeadSheet.Columns.Get(9).CellType = numberCellType8;
            this.fpHeadSheet.Columns.Get(9).Label = "本期结存";
            this.fpHeadSheet.Columns.Get(9).Width = 93F;
            this.fpHeadSheet.DataAutoCellTypes = false;
            this.fpHeadSheet.DataAutoHeadings = false;
            this.fpHeadSheet.DataAutoSizeColumns = false;
            this.fpHeadSheet.DefaultStyle.Locked = true;
            this.fpHeadSheet.DefaultStyle.Parent = "DataAreaDefault";
            this.fpHeadSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpHeadSheet.RowHeader.Columns.Default.Resizable = false;
            this.fpHeadSheet.RowHeader.Columns.Get(0).Width = 37F;
            this.fpHeadSheet.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.RowHeader.DefaultStyle.Locked = false;
            this.fpHeadSheet.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHeadSheet.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.SheetCornerStyle.Locked = false;
            this.fpHeadSheet.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpHeadSheet.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpHeadSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // fpDetailSheet
            // 
            this.fpDetailSheet.Reset();
            this.fpDetailSheet.SheetName = "月结明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetailSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetailSheet.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpDetailSheet.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.ColumnHeader.DefaultStyle.Locked = false;
            this.fpDetailSheet.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.DefaultStyle.Locked = true;
            this.fpDetailSheet.DefaultStyle.Parent = "DataAreaDefault";
            this.fpDetailSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDetailSheet.RowHeader.Columns.Get(0).Width = 37F;
            this.fpDetailSheet.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.RowHeader.DefaultStyle.Locked = false;
            this.fpDetailSheet.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.SheetCornerStyle.Locked = false;
            this.fpDetailSheet.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpDetailSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.label3);
            this.neuPanel1.Controls.Add(this.label1);
            this.neuPanel1.Controls.Add(this.cmbDept);
            this.neuPanel1.Controls.Add(this.label2);
            this.neuPanel1.Controls.Add(this.dtpEndStat);
            this.neuPanel1.Controls.Add(this.dtpBeginStat);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(722, 40);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 6;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.richTextBox1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 40);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(722, 217);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 7;
            // 
            // ucStoreStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucStoreStat";
            this.Size = new System.Drawing.Size(722, 431);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHeadSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetailSheet)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBeginStat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndStat;
        private System.Windows.Forms.Label label3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpHeadSheet;
        private FarPoint.Win.Spread.SheetView fpDetailSheet;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
    }
}
