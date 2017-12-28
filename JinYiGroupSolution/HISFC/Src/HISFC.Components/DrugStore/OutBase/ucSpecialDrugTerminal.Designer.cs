namespace Neusoft.HISFC.Components.DrugStore.OutBase
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucDrugTerminalList1 = new Neusoft.HISFC.Components.DrugStore.OutBase.ucDrugTerminalList();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.sheetSpeDrug = new FarPoint.Win.Spread.SheetView();
            this.sheetSpeDept = new FarPoint.Win.Spread.SheetView();
            this.sheetSpePayKind = new FarPoint.Win.Spread.SheetView();
            this.sheetSpeFeeWindow = new FarPoint.Win.Spread.SheetView();
            this.sheetSpeRegLevel = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpePayKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeFeeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeRegLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucDrugTerminalList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(707, 392);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucDrugTerminalList1
            // 
            this.ucDrugTerminalList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugTerminalList1.IsShowSendDrugWindow = false;
            this.ucDrugTerminalList1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugTerminalList1.Name = "ucDrugTerminalList1";
            this.ucDrugTerminalList1.Size = new System.Drawing.Size(235, 392);
            this.ucDrugTerminalList1.TabIndex = 0;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetSpeDrug,
            this.sheetSpeDept,
            this.sheetSpePayKind,
            this.sheetSpeFeeWindow,
            this.sheetSpeRegLevel});
            this.neuSpread1.Size = new System.Drawing.Size(468, 392);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            this.neuSpread1.TabStripRatio = 0.851272015655577;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // sheetSpeDrug
            // 
            this.sheetSpeDrug.Reset();
            this.sheetSpeDrug.SheetName = "药品类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetSpeDrug.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetSpeDrug.RowCount = 0;
            this.sheetSpeDrug.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.sheetSpeDrug.RowHeader.Columns.Default.Resizable = false;
            this.sheetSpeDrug.RowHeader.Columns.Get(0).Width = 37F;
            this.sheetSpeDrug.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // sheetSpeDept
            // 
            this.sheetSpeDept.Reset();
            this.sheetSpeDept.SheetName = "专科类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetSpeDept.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetSpeDept.RowCount = 0;
            this.sheetSpeDept.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.sheetSpeDept.RowHeader.Columns.Default.Resizable = true;
            this.sheetSpeDept.RowHeader.Columns.Get(0).Width = 37F;
            this.sheetSpeDept.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 1, 0);
            // 
            // sheetSpePayKind
            // 
            this.sheetSpePayKind.Reset();
            this.sheetSpePayKind.SheetName = "结算类别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetSpePayKind.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetSpePayKind.RowCount = 0;
            this.sheetSpePayKind.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.sheetSpePayKind.RowHeader.Columns.Default.Resizable = true;
            this.sheetSpePayKind.RowHeader.Columns.Get(0).Width = 37F;
            this.sheetSpePayKind.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(2, 1, 0);
            // 
            // sheetSpeFeeWindow
            // 
            this.sheetSpeFeeWindow.Reset();
            this.sheetSpeFeeWindow.SheetName = "收费窗口";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetSpeFeeWindow.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetSpeFeeWindow.RowCount = 0;
            this.sheetSpeFeeWindow.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.sheetSpeFeeWindow.RowHeader.Columns.Default.Resizable = true;
            this.sheetSpeFeeWindow.RowHeader.Columns.Get(0).Width = 37F;
            this.sheetSpeFeeWindow.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(3, 1, 0);
            // 
            // sheetSpeRegLevel
            // 
            this.sheetSpeRegLevel.Reset();
            this.sheetSpeRegLevel.SheetName = "挂号级别";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetSpeRegLevel.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetSpeRegLevel.RowCount = 0;
            this.sheetSpeRegLevel.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.sheetSpeRegLevel.RowHeader.Columns.Default.Resizable = false;
            this.sheetSpeRegLevel.RowHeader.Columns.Get(0).Width = 37F;
            this.sheetSpeRegLevel.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(4, 1, 0);
            // 
            // ucSpecialDrugTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucSpecialDrugTerminal";
            this.Size = new System.Drawing.Size(707, 392);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpePayKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeFeeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetSpeRegLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucDrugTerminalList ucDrugTerminalList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView sheetSpeDrug;
        private FarPoint.Win.Spread.SheetView sheetSpeDept;
        private FarPoint.Win.Spread.SheetView sheetSpePayKind;
        private FarPoint.Win.Spread.SheetView sheetSpeFeeWindow;
        private FarPoint.Win.Spread.SheetView sheetSpeRegLevel;
    }
}
