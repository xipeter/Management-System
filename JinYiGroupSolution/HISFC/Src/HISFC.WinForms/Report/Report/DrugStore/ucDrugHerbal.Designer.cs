namespace Neusoft.WinForms.Report.DrugStore
{
    partial class ucDrugHerbal
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbPrintTime = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbPrintTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(675, 463);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbPrintTime
            // 
            this.lbPrintTime.AutoSize = true;
            this.lbPrintTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrintTime.Location = new System.Drawing.Point(0, 33);
            this.lbPrintTime.Name = "lbPrintTime";
            this.lbPrintTime.Size = new System.Drawing.Size(59, 12);
            this.lbPrintTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPrintTime.TabIndex = 1;
            this.lbPrintTime.Text = "neuLabel2";
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(675, 33);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "                         摆药单";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(675, 403);
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
            this.neuSpread1_Sheet1.ColumnCount = 10;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "[床号]姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "商 品 名 称 [ 规 格 ]";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "数 量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "总 量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "单 位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "用 法";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "货位号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "单价";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "金 额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "备   注";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "[床号]姓名";
            this.neuSpread1_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.neuSpread1_Sheet1.Columns.Get(0).Tag = "";
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 102F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "商 品 名 称 [ 规 格 ]";
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 142F;
            numberCellType1.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "数 量";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 50F;
            numberCellType2.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "总 量";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 52F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "单 位";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 38F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "用 法";
            this.neuSpread1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 55F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "货位号";
            this.neuSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType3.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(7).CellType = numberCellType3;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "单价";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 68F;
            numberCellType4.DecimalPlaces = 2;
            this.neuSpread1_Sheet1.Columns.Get(8).CellType = numberCellType4;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "金 额";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 84F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "备   注";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 68F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucDrugHerbal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDrugHerbal";
            this.Size = new System.Drawing.Size(675, 463);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPrintTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
