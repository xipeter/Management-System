namespace Neusoft.WinForms.Report.DrugStore
{
    partial class ucDrugBillDetail
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbTitl = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPrintTime = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.neuSpread1.FileName = "";
            this.neuSpread1.Font = new System.Drawing.Font("宋体", 9F);
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(4, 64);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(712, 348);
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
            this.neuSpread1_Sheet1.ColumnCount = 14;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "[床号]姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "商 品 名 称 [ 规 格 ]";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "用法";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "每次量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "剂量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "频次";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "付数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "总量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "用药时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "单价";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "金额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "货位号";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.White);
            this.neuSpread1_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.White);
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "[床号]姓名";
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 106F;
            this.neuSpread1_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "商 品 名 称 [ 规 格 ]";
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 180F;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 126F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "用法";
            this.neuSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 49F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "每次量";
            this.neuSpread1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 48F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "剂量";
            this.neuSpread1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 45F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "频次";
            this.neuSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 36F;
            numberCellType1.DecimalPlaces = 0;
            this.neuSpread1_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "付数";
            this.neuSpread1_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 34F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "总量";
            this.neuSpread1_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 51F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "单位";
            this.neuSpread1_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 46F;
            this.neuSpread1_Sheet1.Columns.Get(10).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "用药时间";
            this.neuSpread1_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 100F;
            numberCellType2.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(11).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "单价";
            this.neuSpread1_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 59F;
            this.neuSpread1_Sheet1.Columns.Get(13).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "货位号";
            this.neuSpread1_Sheet1.Columns.Get(13).Width = 62F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Default.Height = 30F;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // lbTitl
            // 
            this.lbTitl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitl.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitl.Location = new System.Drawing.Point(0, 0);
            this.lbTitl.Name = "lbTitl";
            this.lbTitl.Size = new System.Drawing.Size(712, 31);
            this.lbTitl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitl.TabIndex = 1;
            this.lbTitl.Text = "                            摆药单";
            // 
            // lbPrintTime
            // 
            this.lbPrintTime.AutoSize = true;
            this.lbPrintTime.Location = new System.Drawing.Point(2, 39);
            this.lbPrintTime.Name = "lbPrintTime";
            this.lbPrintTime.Size = new System.Drawing.Size(59, 12);
            this.lbPrintTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPrintTime.TabIndex = 2;
            this.lbPrintTime.Text = "打印时间:";
            // 
            // ucDrugBillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbPrintTime);
            this.Controls.Add(this.lbTitl);
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucDrugBillDetail";
            this.Size = new System.Drawing.Size(712, 412);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitl;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPrintTime;
    }
}
