namespace UFC.Pharmacy.Base
{
    partial class ucAddStock
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance( );
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType( );
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType( );
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType( );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer( );
            this.splitContainer2 = new System.Windows.Forms.SplitContainer( );
            this.splitContainer3 = new System.Windows.Forms.SplitContainer( );
            this.txtSum = new Neusoft.NFC.Interface.Controls.NeuNumericUpDown( );
            this.label1 = new System.Windows.Forms.Label( );
            this.txtQueryCode = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.neuSpread1 = new Neusoft.NFC.Interface.Controls.NeuSpread( );
            this.tvDrugType1 = new Neusoft.UFC.DrugStore.InBase.tvDrugType( this.components );
            this.tvDeptTree1 = new Neusoft.UFC.DrugStore.Base.tvDeptTree( this.components );
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView( );
            this.splitContainer1.Panel1.SuspendLayout( );
            this.splitContainer1.Panel2.SuspendLayout( );
            this.splitContainer1.SuspendLayout( );
            this.splitContainer2.Panel1.SuspendLayout( );
            this.splitContainer2.Panel2.SuspendLayout( );
            this.splitContainer2.SuspendLayout( );
            this.splitContainer3.Panel1.SuspendLayout( );
            this.splitContainer3.Panel2.SuspendLayout( );
            this.splitContainer3.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.txtSum ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.splitContainer2 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.splitContainer3 );
            this.splitContainer1.Size = new System.Drawing.Size( 749 , 509 );
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add( this.tvDrugType1 );
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add( this.tvDeptTree1 );
            this.splitContainer2.Size = new System.Drawing.Size( 149 , 509 );
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add( this.txtSum );
            this.splitContainer3.Panel1.Controls.Add( this.label1 );
            this.splitContainer3.Panel1.Controls.Add( this.txtQueryCode );
            this.splitContainer3.Panel1.Controls.Add( this.label2 );
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add( this.neuSpread1 );
            this.splitContainer3.Size = new System.Drawing.Size( 596 , 509 );
            this.splitContainer3.SplitterDistance = 38;
            this.splitContainer3.TabIndex = 0;
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point( 337 , 8 );
            this.txtSum.Maximum = new decimal( new int[ ] {
            10000000,
            0,
            0,
            0} );
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size( 120 , 21 );
            this.txtSum.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtSum.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 272 , 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53 , 12 );
            this.label1.TabIndex = 4;
            this.label1.Text = "增加数量";
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.Location = new System.Drawing.Point( 69 , 8 );
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size( 171 , 21 );
            this.txtQueryCode.TabIndex = 3;
            this.txtQueryCode.TextChanged += new System.EventHandler( this.txtQueryCode_TextChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 22 , 13 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 41 , 12 );
            this.label2.TabIndex = 2;
            this.label2.Text = "查询码";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point( 0 , 0 );
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[ ] {
            this.neuSpread1_Sheet1} );
            this.neuSpread1.Size = new System.Drawing.Size( 596 , 467 );
            this.neuSpread1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( ( byte )( 134 ) ) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            // 
            // tvDrugType1
            // 
            this.tvDrugType1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDrugType1.HideSelection = false;
            this.tvDrugType1.Location = new System.Drawing.Point( 0 , 0 );
            this.tvDrugType1.Name = "tvDrugType1";
            this.tvDrugType1.ShowKind = Neusoft.UFC.DrugStore.InBase.tvDrugType.ShowDrugKind.ShowTypeAndQuality;
            this.tvDrugType1.Size = new System.Drawing.Size( 149 , 254 );
            this.tvDrugType1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.tvDrugType1.TabIndex = 0;
            this.tvDrugType1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvDrugType1_AfterSelect );
            // 
            // tvDeptTree1
            // 
            this.tvDeptTree1.CheckBoxes = true;
            this.tvDeptTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDeptTree1.HideSelection = false;
            this.tvDeptTree1.Location = new System.Drawing.Point( 0 , 0 );
            this.tvDeptTree1.Name = "tvDeptTree1";
            this.tvDeptTree1.Size = new System.Drawing.Size( 149 , 251 );
            this.tvDeptTree1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.tvDeptTree1.TabIndex = 0;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset( );
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 9;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 0 ).Value = "选择";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 1 ).Value = "商品名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 2 ).Value = "规格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 3 ).Value = "零售价";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 4 ).Value = "药品性质";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 5 ).Value = "包装数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 6 ).Value = "包装单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 7 ).Value = "最小单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0 , 8 ).Value = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get( 0 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Label = "选择";
            this.neuSpread1_Sheet1.Columns.Get( 0 ).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Width = 51F;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Label = "商品名称";
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Width = 138F;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Width = 91F;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Label = "零售价";
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Width = 78F;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Label = "药品性质";
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Width = 81F;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Label = "包装数量";
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Width = 72F;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Label = "包装单位";
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Label = "最小单位";
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Width = 86F;
            this.neuSpread1_Sheet1.Columns.Get( 8 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 8 ).Label = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get( 8 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 8 ).Width = 117F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 1 , 0 );
            // 
            // ucAddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucAddStock";
            this.Size = new System.Drawing.Size( 749 , 509 );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.splitContainer2.Panel1.ResumeLayout( false );
            this.splitContainer2.Panel2.ResumeLayout( false );
            this.splitContainer2.ResumeLayout( false );
            this.splitContainer3.Panel1.ResumeLayout( false );
            this.splitContainer3.Panel1.PerformLayout( );
            this.splitContainer3.Panel2.ResumeLayout( false );
            this.splitContainer3.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.txtSum ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet1 ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Neusoft.UFC.DrugStore.InBase.tvDrugType tvDrugType1;
        private Neusoft.UFC.DrugStore.Base.tvDeptTree tvDeptTree1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Neusoft.NFC.Interface.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private System.Windows.Forms.TextBox txtQueryCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Neusoft.NFC.Interface.Controls.NeuNumericUpDown txtSum;
    }
}
