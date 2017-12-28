namespace Neusoft.HISFC.Components.Preparation
{
    partial class ucWrapper
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.fsWrapper = new Neusoft.HISFC.Components.Preparation.FPItem(this.components);
            this.fsWrapper_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fsWrapper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsWrapper_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fsWrapper
            // 
            this.fsWrapper.About = "2.5.2007.2005";
            this.fsWrapper.AccessibleDescription = "fsMaterial";
            this.fsWrapper.BackColor = System.Drawing.Color.White;
            this.fsWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsWrapper.DrugType = "";
            this.fsWrapper.EditModePermanent = true;
            this.fsWrapper.FileName = "";
            this.fsWrapper.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsWrapper.IsAutoSaveGridStatus = false;
            this.fsWrapper.IsCanCustomConfigColumn = false;
            this.fsWrapper.Location = new System.Drawing.Point(0, 0);
            this.fsWrapper.Name = "fsWrapper";
            this.fsWrapper.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsWrapper_Sheet1});
            this.fsWrapper.Size = new System.Drawing.Size(613, 358);
            this.fsWrapper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsWrapper.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsWrapper.TextTipAppearance = tipAppearance1;
            this.fsWrapper.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsWrapper.SelectItem += new System.EventHandler(this.fsWrapper_SelectItem);
            // 
            // fsWrapper_Sheet1
            // 
            this.fsWrapper_Sheet1.Reset();
            this.fsWrapper_Sheet1.SheetName = "生产原料";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsWrapper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsWrapper_Sheet1.ColumnCount = 7;
            this.fsWrapper_Sheet1.RowCount = 0;
            this.fsWrapper_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "原料编码";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "原料名称";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "规格";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "单价";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "处方量";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "单位";
            this.fsWrapper_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "备注";
            this.fsWrapper_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsWrapper_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsWrapper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsWrapper_Sheet1.Columns.Get(0).Label = "原料编码";
            this.fsWrapper_Sheet1.Columns.Get(0).Visible = false;
            this.fsWrapper_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fsWrapper_Sheet1.Columns.Get(1).Label = "原料名称";
            this.fsWrapper_Sheet1.Columns.Get(1).Locked = false;
            this.fsWrapper_Sheet1.Columns.Get(1).Width = 140F;
            this.fsWrapper_Sheet1.Columns.Get(2).Label = "规格";
            this.fsWrapper_Sheet1.Columns.Get(2).Width = 80F;
            this.fsWrapper_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.Transparent;
            this.fsWrapper_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fsWrapper_Sheet1.Columns.Get(3).Label = "单价";
            this.fsWrapper_Sheet1.Columns.Get(3).Width = 80F;
            this.fsWrapper_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.SeaShell;
            this.fsWrapper_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.fsWrapper_Sheet1.Columns.Get(4).Label = "处方量";
            this.fsWrapper_Sheet1.Columns.Get(4).Locked = false;
            this.fsWrapper_Sheet1.Columns.Get(4).Width = 89F;
            this.fsWrapper_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.SeaShell;
            this.fsWrapper_Sheet1.Columns.Get(6).Label = "备注";
            this.fsWrapper_Sheet1.Columns.Get(6).Locked = false;
            this.fsWrapper_Sheet1.Columns.Get(6).Width = 179F;
            this.fsWrapper_Sheet1.DefaultStyle.Locked = true;
            this.fsWrapper_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fsWrapper_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsWrapper_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsWrapper_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fsWrapper_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsWrapper_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsWrapper_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsWrapper_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsWrapper_Sheet1.SheetCornerStyle.Locked = false;
            this.fsWrapper_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsWrapper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fsWrapper.SetActiveViewport(1, 0);
            // 
            // ucWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fsWrapper);
            this.Name = "ucWrapper";
            this.Size = new System.Drawing.Size(613, 358);
            this.Load += new System.EventHandler(this.ucWrapper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fsWrapper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsWrapper_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.HISFC.Components.Preparation.FPItem fsWrapper;
        private FarPoint.Win.Spread.SheetView fsWrapper_Sheet1;

    }
}
