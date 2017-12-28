namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    partial class ucFeeStat
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.tvFeeType = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tvFeeType
            // 
            this.tvFeeType.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvFeeType.HideSelection = false;
            this.tvFeeType.Location = new System.Drawing.Point(0, 0);
            this.tvFeeType.Name = "tvFeeType";
            this.tvFeeType.Size = new System.Drawing.Size(196, 668);
            this.tvFeeType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvFeeType.TabIndex = 0;
            this.tvFeeType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFeeType_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(196, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 668);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(199, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(697, 668);
            this.fpSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 12;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "报表代码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "报表名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "费用名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "统计大类";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "统计名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "打印顺序";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "附加代码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "执行科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "医保类别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "是否有效";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "操作员";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "操作时间";
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "报表代码";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 77F;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "报表名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "费用名称";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 70F;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "统计大类";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 73F;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "统计名称";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 82F;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = textCellType5;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "打印顺序";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 58F;
            this.fpSpread1_Sheet1.Columns.Get(6).CellType = textCellType6;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "附加代码";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 67F;
            this.fpSpread1_Sheet1.Columns.Get(7).CellType = textCellType7;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "执行科室";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 125F;
            this.fpSpread1_Sheet1.Columns.Get(8).CellType = textCellType8;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "医保类别";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 71F;
            this.fpSpread1_Sheet1.Columns.Get(11).Label = "操作时间";
            this.fpSpread1_Sheet1.Columns.Get(11).Width = 144F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // ucFeeStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.tvFeeType);
            this.Name = "ucFeeStat";
            this.Size = new System.Drawing.Size(896, 668);
            this.Load += new System.EventHandler(this.ucFeeStat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvFeeType;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
    }
}
