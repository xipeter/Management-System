namespace Neusoft.HISFC.Components.Preparation.Stencil
{
    partial class ucStencil
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fsDrug = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsDrug_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbInformation = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fsStencil = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsStencil_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fsDrug);
            this.splitContainer1.Panel1.Controls.Add(this.neuGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(777, 415);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
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
            this.fsDrug.Location = new System.Drawing.Point(0, 42);
            this.fsDrug.Name = "fsDrug";
            this.fsDrug.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsDrug_Sheet1});
            this.fsDrug.Size = new System.Drawing.Size(777, 132);
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
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lbInformation);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(777, 42);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 2;
            this.neuGroupBox1.TabStop = false;
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.ForeColor = System.Drawing.Color.Blue;
            this.lbInformation.Location = new System.Drawing.Point(6, 17);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(65, 12);
            this.lbInformation.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInformation.TabIndex = 0;
            this.lbInformation.Text = "提示信息：";
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(777, 237);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fsStencil);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "成品模版";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fsStencil
            // 
            this.fsStencil.About = "2.5.2007.2005";
            this.fsStencil.AccessibleDescription = "fsStencil, Sheet1, Row 0, Column 0, ";
            this.fsStencil.BackColor = System.Drawing.Color.White;
            this.fsStencil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsStencil.FileName = "";
            this.fsStencil.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsStencil.IsAutoSaveGridStatus = false;
            this.fsStencil.IsCanCustomConfigColumn = false;
            this.fsStencil.Location = new System.Drawing.Point(3, 3);
            this.fsStencil.Name = "fsStencil";
            this.fsStencil.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsStencil_Sheet1});
            this.fsStencil.Size = new System.Drawing.Size(763, 206);
            this.fsStencil.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsStencil.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsStencil.TextTipAppearance = tipAppearance2;
            this.fsStencil.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fsStencil_Sheet1
            // 
            this.fsStencil_Sheet1.Reset();
            this.fsStencil_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsStencil_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsStencil_Sheet1.ColumnCount = 9;
            this.fsStencil_Sheet1.RowCount = 1;
            this.fsStencil_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "类别编码";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "类别名称";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "项目类别";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "项目名称";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "标准最小值";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "标准最大值";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "标准现象";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "备注";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "ID";
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fsStencil_Sheet1.Columns.Get(0).Label = "类别编码";
            this.fsStencil_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.fsStencil_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsStencil_Sheet1.Columns.Get(0).Width = 62F;
            this.fsStencil_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(1).Label = "类别名称";
            this.fsStencil_Sheet1.Columns.Get(1).Width = 130F;
            this.fsStencil_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(2).Label = "项目类别";
            this.fsStencil_Sheet1.Columns.Get(2).Width = 87F;
            this.fsStencil_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(3).Label = "项目名称";
            this.fsStencil_Sheet1.Columns.Get(3).Width = 141F;
            this.fsStencil_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.fsStencil_Sheet1.Columns.Get(4).Label = "标准最小值";
            this.fsStencil_Sheet1.Columns.Get(4).Width = 73F;
            this.fsStencil_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.fsStencil_Sheet1.Columns.Get(5).Label = "标准最大值";
            this.fsStencil_Sheet1.Columns.Get(5).Width = 69F;
            this.fsStencil_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(6).CellType = textCellType2;
            this.fsStencil_Sheet1.Columns.Get(6).Label = "标准现象";
            this.fsStencil_Sheet1.Columns.Get(6).Width = 139F;
            this.fsStencil_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.Transparent;
            this.fsStencil_Sheet1.Columns.Get(7).Label = "备注";
            this.fsStencil_Sheet1.Columns.Get(7).Width = 108F;
            this.fsStencil_Sheet1.Columns.Get(8).CellType = textCellType3;
            this.fsStencil_Sheet1.Columns.Get(8).Label = "ID";
            this.fsStencil_Sheet1.Columns.Get(8).Visible = false;
            this.fsStencil_Sheet1.Columns.Get(8).Width = 36F;
            this.fsStencil_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsStencil_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.SheetCornerStyle.Locked = false;
            this.fsStencil_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucStencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucStencil";
            this.Size = new System.Drawing.Size(777, 415);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsDrug;
        private FarPoint.Win.Spread.SheetView fsDrug_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInformation;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsStencil;
        private FarPoint.Win.Spread.SheetView fsStencil_Sheet1;
    }
}
