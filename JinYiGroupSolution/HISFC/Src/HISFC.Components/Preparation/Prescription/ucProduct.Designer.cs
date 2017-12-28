namespace Neusoft.HISFC.Components.Preparation.Prescription
{
    partial class ucProduct
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
            this.fsDrug = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsDrug_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fsDrug
            // 
            this.fsDrug.About = "2.5.2007.2005";
            this.fsDrug.AccessibleDescription = "fsDrug";
            this.fsDrug.BackColor = System.Drawing.Color.White;
            this.fsDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsDrug.FileName = "";
            this.fsDrug.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsDrug.IsAutoSaveGridStatus = false;
            this.fsDrug.IsCanCustomConfigColumn = false;
            this.fsDrug.Location = new System.Drawing.Point(0, 0);
            this.fsDrug.Name = "fsDrug";
            this.fsDrug.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsDrug_Sheet1});
            this.fsDrug.Size = new System.Drawing.Size(562, 140);
            this.fsDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsDrug.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsDrug.TextTipAppearance = tipAppearance1;
            this.fsDrug.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsDrug.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fsDrug_SelectionChanged);
            // 
            // fsDrug_Sheet1
            // 
            this.fsDrug_Sheet1.Reset();
            this.fsDrug_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsDrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsDrug_Sheet1.ColumnCount = 6;
            this.fsDrug_Sheet1.RowCount = 0;
            this.fsDrug_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "成品编码";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "成品名称";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "规格";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "包装数量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "包装单位";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "最小单位";
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.Columns.Get(0).Label = "成品编码";
            this.fsDrug_Sheet1.Columns.Get(0).Visible = false;
            this.fsDrug_Sheet1.Columns.Get(1).Label = "成品名称";
            this.fsDrug_Sheet1.Columns.Get(1).Width = 140F;
            this.fsDrug_Sheet1.Columns.Get(2).Label = "规格";
            this.fsDrug_Sheet1.Columns.Get(2).Width = 80F;
            this.fsDrug_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fsDrug_Sheet1.Columns.Get(3).Label = "包装数量";
            this.fsDrug_Sheet1.Columns.Get(3).Width = 80F;
            this.fsDrug_Sheet1.Columns.Get(4).Label = "包装单位";
            this.fsDrug_Sheet1.Columns.Get(4).Width = 80F;
            this.fsDrug_Sheet1.DefaultStyle.Locked = true;
            this.fsDrug_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fsDrug_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fsDrug_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsDrug_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fsDrug_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fsDrug_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.SheetCornerStyle.Locked = false;
            this.fsDrug_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fsDrug.SetActiveViewport(1, 0);
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fsDrug);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(562, 140);
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsDrug;
        private FarPoint.Win.Spread.SheetView fsDrug_Sheet1;
    }
}
