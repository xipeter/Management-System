namespace Neusoft.HISFC.Components.Pharmacy
{
    partial class ucNostrumProduce
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ucNostrumProduce ) );
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fpNostrumList = new FarPoint.Win.Spread.FpSpread();
            this.fpNostrumList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpPackageList = new FarPoint.Win.Spread.FpSpread();
            this.fpPackageList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbNostrumInfo = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpNostrumList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpNostrumList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackageList_Sheet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tabControl1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.fpPackageList );
            this.splitContainer1.Panel2.Controls.Add( this.groupBox2 );
            this.splitContainer1.Size = new System.Drawing.Size( 771, 419 );
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 228, 419 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.groupBox1 );
            this.tabPage1.Controls.Add( this.fpNostrumList );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 220, 393 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "协定处方列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.txtFilter );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 214, 44 );
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.ForeColor = System.Drawing.Color.LightGray;
            this.txtFilter.Location = new System.Drawing.Point( 67, 16 );
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size( 144, 21 );
            this.txtFilter.TabIndex = 1;
            this.txtFilter.Text = "拼音码\\五笔码过滤";
            this.txtFilter.TextChanged += new System.EventHandler( this.txtFilter_TextChanged );
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler( this.txtFilter_KeyDown );
            this.txtFilter.Leave += new System.EventHandler( this.txtFilter_Leave );
            this.txtFilter.Enter += new System.EventHandler( this.txtFilter_Enter );
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point( 6, 19 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "药品名称";
            // 
            // fpNostrumList
            // 
            this.fpNostrumList.About = "3.0.2004.2005";
            this.fpNostrumList.AccessibleDescription = "";
            this.fpNostrumList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpNostrumList.Location = new System.Drawing.Point( 0, 46 );
            this.fpNostrumList.Name = "fpNostrumList";
            this.fpNostrumList.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[] {
            this.fpNostrumList_Sheet1} );
            this.fpNostrumList.Size = new System.Drawing.Size( 220, 347 );
            this.fpNostrumList.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpNostrumList.TextTipAppearance = tipAppearance1;
            this.fpNostrumList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler( this.fpNostrumList_CellDoubleClick );
            // 
            // fpNostrumList_Sheet1
            // 
            this.fpNostrumList_Sheet1.Reset();
            this.fpNostrumList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpNostrumList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpNostrumList_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin( "CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true );
            this.fpNostrumList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpNostrumList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpNostrumList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpNostrumList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpNostrumList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpNostrumList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpNostrumList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.fpNostrumList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpNostrumList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpPackageList
            // 
            this.fpPackageList.About = "3.0.2004.2005";
            this.fpPackageList.AccessibleDescription = "fpPackageList, Sheet1, Row 0, Column 0, ";
            this.fpPackageList.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))) );
            this.fpPackageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpPackageList.Location = new System.Drawing.Point( 0, 69 );
            this.fpPackageList.Name = "fpPackageList";
            this.fpPackageList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpPackageList.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[] {
            this.fpPackageList_Sheet1} );
            this.fpPackageList.Size = new System.Drawing.Size( 539, 350 );
            this.fpPackageList.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)) );
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpPackageList.TextTipAppearance = tipAppearance2;
            this.fpPackageList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler( this.fpPackageList_SelectionChanged );
            // 
            // fpPackageList_Sheet1
            // 
            this.fpPackageList_Sheet1.Reset();
            this.fpPackageList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpPackageList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpPackageList_Sheet1.ColumnCount = 10;
            this.fpPackageList_Sheet1.RowCount = 1;
            this.fpPackageList_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin( "CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true );
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 0 ).Value = "药品编码";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 1 ).Value = "协定处方";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 2 ).Value = "规格";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 3 ).Value = "零售价";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 4 ).Value = "计划生产量";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 5 ).Value = "单位";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 6 ).Value = "批号";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 7 ).Value = "有效期";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 8 ).Value = "备注";
            this.fpPackageList_Sheet1.ColumnHeader.Cells.Get( 0, 9 ).Value = "处方明细";
            this.fpPackageList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpPackageList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpPackageList_Sheet1.Columns.Get( 0 ).CellType = textCellType1;
            this.fpPackageList_Sheet1.Columns.Get( 0 ).Label = "药品编码";
            this.fpPackageList_Sheet1.Columns.Get( 0 ).Width = 84F;
            this.fpPackageList_Sheet1.Columns.Get( 1 ).Label = "协定处方";
            this.fpPackageList_Sheet1.Columns.Get( 1 ).Width = 160F;
            this.fpPackageList_Sheet1.Columns.Get( 2 ).Label = "规格";
            this.fpPackageList_Sheet1.Columns.Get( 2 ).Width = 100F;
            this.fpPackageList_Sheet1.Columns.Get( 3 ).CellType = numberCellType1;
            this.fpPackageList_Sheet1.Columns.Get( 3 ).Label = "零售价";
            this.fpPackageList_Sheet1.Columns.Get( 3 ).Width = 100F;
            this.fpPackageList_Sheet1.Columns.Get( 4 ).BackColor = System.Drawing.Color.SeaShell;
            this.fpPackageList_Sheet1.Columns.Get( 4 ).CellType = numberCellType2;
            this.fpPackageList_Sheet1.Columns.Get( 4 ).Label = "计划生产量";
            this.fpPackageList_Sheet1.Columns.Get( 4 ).Locked = false;
            this.fpPackageList_Sheet1.Columns.Get( 4 ).Width = 100F;
            this.fpPackageList_Sheet1.Columns.Get( 6 ).Label = "批号";
            this.fpPackageList_Sheet1.Columns.Get( 6 ).Width = 80F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject( "dateTimeCellType1.Calendar" )));
            dateTimeCellType1.CalendarDayFont = new System.Drawing.Font( "Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime( 2010, 5, 31, 10, 50, 20, 0 );
            dateTimeCellType1.TimeDefault = new System.DateTime( 2010, 5, 31, 10, 50, 20, 0 );
            this.fpPackageList_Sheet1.Columns.Get( 7 ).CellType = dateTimeCellType1;
            this.fpPackageList_Sheet1.Columns.Get( 7 ).Label = "有效期";
            this.fpPackageList_Sheet1.Columns.Get( 7 ).Width = 85F;
            this.fpPackageList_Sheet1.Columns.Get( 8 ).BackColor = System.Drawing.Color.SeaShell;
            this.fpPackageList_Sheet1.Columns.Get( 8 ).Label = "备注";
            this.fpPackageList_Sheet1.Columns.Get( 8 ).Locked = false;
            this.fpPackageList_Sheet1.Columns.Get( 8 ).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.fpPackageList_Sheet1.Columns.Get( 8 ).Width = 100F;
            this.fpPackageList_Sheet1.Columns.Get( 9 ).CellType = textCellType2;
            this.fpPackageList_Sheet1.Columns.Get( 9 ).Label = "处方明细";
            this.fpPackageList_Sheet1.Columns.Get( 9 ).Width = 180F;
            this.fpPackageList_Sheet1.DefaultStyle.Locked = true;
            this.fpPackageList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpPackageList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpPackageList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpPackageList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpPackageList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpPackageList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.fpPackageList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpPackageList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.lbNostrumInfo );
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 539, 69 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lbNostrumInfo
            // 
            this.lbNostrumInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNostrumInfo.AutoSize = true;
            this.lbNostrumInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbNostrumInfo.Location = new System.Drawing.Point( 6, 22 );
            this.lbNostrumInfo.Name = "lbNostrumInfo";
            this.lbNostrumInfo.Size = new System.Drawing.Size( 77, 12 );
            this.lbNostrumInfo.TabIndex = 1;
            this.lbNostrumInfo.Text = "协定处方明细";
            // 
            // ucNostrumProduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucNostrumProduce";
            this.Size = new System.Drawing.Size( 771, 419 );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpNostrumList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpNostrumList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPackageList_Sheet1)).EndInit();
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread fpNostrumList;
        private FarPoint.Win.Spread.SheetView fpNostrumList_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FarPoint.Win.Spread.FpSpread fpPackageList;
        private FarPoint.Win.Spread.SheetView fpPackageList_Sheet1;
        private System.Windows.Forms.Label lbNostrumInfo;
    }
}
