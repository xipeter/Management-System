namespace Neusoft.UFC.DrugStore.Outpatient
{
    partial class ucSpecialDrugTerminal
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance( );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer( );
            this.ucDrugTerminalList1 = new Neusoft.UFC.DrugStore.Outpatient.ucDrugTerminalList( );
            this.neuSpread1 = new Neusoft.NFC.Interface.Controls.NeuSpread( );
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView( );
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView( );
            this.neuSpread1_Sheet3 = new FarPoint.Win.Spread.SheetView( );
            this.neuSpread1_Sheet4 = new FarPoint.Win.Spread.SheetView( );
            this.neuSpread1_Sheet5 = new FarPoint.Win.Spread.SheetView( );
            this.splitContainer1.Panel1.SuspendLayout( );
            this.splitContainer1.Panel2.SuspendLayout( );
            this.splitContainer1.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet1 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet2 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet3 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet4 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet5 ) ).BeginInit( );
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
            this.splitContainer1.Panel1.Controls.Add( this.ucDrugTerminalList1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.neuSpread1 );
            this.splitContainer1.Size = new System.Drawing.Size( 707 , 392 );
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucDrugTerminalList1
            // 
            this.ucDrugTerminalList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugTerminalList1.IsShowSendDrugWindow = false;
            this.ucDrugTerminalList1.Location = new System.Drawing.Point( 0 , 0 );
            this.ucDrugTerminalList1.Name = "ucDrugTerminalList1";
            this.ucDrugTerminalList1.Size = new System.Drawing.Size( 235 , 392 );
            this.ucDrugTerminalList1.TabIndex = 0;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 挂号级别, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point( 0 , 0 );
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[ ] {
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2,
            this.neuSpread1_Sheet3,
            this.neuSpread1_Sheet4,
            this.neuSpread1_Sheet5} );
            this.neuSpread1.Size = new System.Drawing.Size( 468 , 392 );
            this.neuSpread1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            this.neuSpread1.TabStripRatio = 0.851272015655577;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( ( byte )( 134 ) ) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ActiveSheetChanged += new System.EventHandler( this.neuSpread1_ActiveSheetChanged );
            this.neuSpread1.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler( this.neuSpread1_SheetTabClick );
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset( );
            this.neuSpread1_Sheet1.SheetName = "药品类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get( 0 ).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 1 , 0 );
            // 
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset( );
            this.neuSpread1_Sheet2.SheetName = "专科类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.RowCount = 0;
            this.neuSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet2.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet2.RowHeader.Columns.Get( 0 ).Width = 37F;
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 1 , 1 , 0 );
            // 
            // neuSpread1_Sheet3
            // 
            this.neuSpread1_Sheet3.Reset( );
            this.neuSpread1_Sheet3.SheetName = "结算类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet3.RowCount = 0;
            this.neuSpread1_Sheet3.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet3.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet3.RowHeader.Columns.Get( 0 ).Width = 37F;
            this.neuSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 2 , 1 , 0 );
            // 
            // neuSpread1_Sheet4
            // 
            this.neuSpread1_Sheet4.Reset( );
            this.neuSpread1_Sheet4.SheetName = "收费窗口";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet4.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet4.RowCount = 0;
            this.neuSpread1_Sheet4.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet4.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet4.RowHeader.Columns.Get( 0 ).Width = 37F;
            this.neuSpread1_Sheet4.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 3 , 1 , 0 );
            // 
            // neuSpread1_Sheet5
            // 
            this.neuSpread1_Sheet5.Reset( );
            this.neuSpread1_Sheet5.SheetName = "挂号级别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet5.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet5.RowCount = 0;
            this.neuSpread1_Sheet5.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet5.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet5.RowHeader.Columns.Get( 0 ).Width = 37F;
            this.neuSpread1_Sheet5.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 4 , 1 , 0 );
            // 
            // ucSpecialDrugTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucSpecialDrugTerminal";
            this.Size = new System.Drawing.Size( 707 , 392 );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet1 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet2 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet3 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet4 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.neuSpread1_Sheet5 ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucDrugTerminalList ucDrugTerminalList1;
        private Neusoft.NFC.Interface.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet3;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet4;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet5;
    }
}
