namespace Neusoft.HISFC.Components.Registration
{
    partial class ucChooseBookingDate
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fpSpread1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 234);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.FileName = "";
            this.fpSpread1.Font = new System.Drawing.Font("宋体", 9F);
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(4, 4);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(605, 225);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 11;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "预约日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "午别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "开始时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "结束时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "来人设号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "来人取号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "电话设号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "电话预约";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "电话取号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "特诊设号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "特诊取号";
            this.fpSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "预约日期";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 121F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "午别";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 43F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "开始时间";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 63F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999;
            numberCellType1.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = numberCellType1;
            this.fpSpread1_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(4).ForeColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "来人设号";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 40F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 999999;
            numberCellType2.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = numberCellType2;
            this.fpSpread1_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "来人取号";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 40F;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.MaximumValue = 999999;
            numberCellType3.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(6).CellType = numberCellType3;
            this.fpSpread1_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(6).ForeColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "电话设号";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 39F;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.MaximumValue = 999999;
            numberCellType4.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(7).CellType = numberCellType4;
            this.fpSpread1_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "电话预约";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 40F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 999999;
            numberCellType5.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(8).CellType = numberCellType5;
            this.fpSpread1_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "电话取号";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 40F;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 999999;
            numberCellType6.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(9).CellType = numberCellType6;
            this.fpSpread1_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(9).ForeColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "特诊设号";
            this.fpSpread1_Sheet1.Columns.Get(9).Width = 40F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 999999;
            numberCellType7.MinimumValue = 0;
            this.fpSpread1_Sheet1.Columns.Get(10).CellType = numberCellType7;
            this.fpSpread1_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(10).Label = "特诊取号";
            this.fpSpread1_Sheet1.Columns.Get(10).Width = 40F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RestrictRows = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // ucChooseBookingDate
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "ucChooseBookingDate";
            this.Size = new System.Drawing.Size(614, 234);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
    }
}
