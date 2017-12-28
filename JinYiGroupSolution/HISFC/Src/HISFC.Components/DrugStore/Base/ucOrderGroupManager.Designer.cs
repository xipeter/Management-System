namespace Neusoft.HISFC.Components.DrugStore.Base
{
    partial class ucOrderGroupManager
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrderGroupManager));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 35);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(717, 412);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 5;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "批次号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "本批次起始时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "本批次截至时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "操作员";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "操作时间";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "批次号";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 106F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 8, 20, 14, 29, 13, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 8, 20, 14, 29, 13, 0);
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "本批次起始时间";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 130F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 8, 20, 14, 29, 57, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 8, 20, 14, 29, 57, 0);
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "本批次截至时间";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 130F;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "操作员";
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 98F;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.DateDefault = new System.DateTime(2007, 8, 20, 14, 30, 13, 0);
            dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType3.TimeDefault = new System.DateTime(2007, 8, 20, 14, 30, 13, 0);
            dateTimeCellType3.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = dateTimeCellType3;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "操作时间";
            this.neuSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 140F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuDateTimePicker1);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(717, 35);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.neuDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.neuDateTimePicker1.IsEnter2Tab = false;
            this.neuDateTimePicker1.Location = new System.Drawing.Point(469, 11);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 1;
            this.neuDateTimePicker1.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 15);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(425, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "提示：维护时请注意保证区间的连续性。当区间重叠时，将随机寻找一个批次值";
            // 
            // ucOrderGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucOrderGroupManager";
            this.Size = new System.Drawing.Size(717, 447);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
    }
}
