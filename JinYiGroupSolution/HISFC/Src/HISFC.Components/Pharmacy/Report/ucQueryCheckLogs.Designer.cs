namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    partial class ucQueryCheckLogs
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbRecordCount = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbOperCount = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpStartDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtCheckNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpCheckLogs = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCheckLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add( this.lbRecordCount );
            this.neuPanel1.Controls.Add( this.lbOperCount );
            this.neuPanel1.Controls.Add( this.dtpEndDate );
            this.neuPanel1.Controls.Add( this.neuLabel3 );
            this.neuPanel1.Controls.Add( this.neuLabel2 );
            this.neuPanel1.Controls.Add( this.dtpStartDate );
            this.neuPanel1.Controls.Add( this.neuLabel4 );
            this.neuPanel1.Controls.Add( this.txtCheckNo );
            this.neuPanel1.Controls.Add( this.neuLabel1 );
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point( 0, 0 );
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size( 900, 78 );
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.Location = new System.Drawing.Point( 197, 46 );
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size( 71, 12 );
            this.lbRecordCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbRecordCount.TabIndex = 13;
            this.lbRecordCount.Text = "盘点记录数:";
            // 
            // lbOperCount
            // 
            this.lbOperCount.AutoSize = true;
            this.lbOperCount.Location = new System.Drawing.Point( 11, 46 );
            this.lbOperCount.Name = "lbOperCount";
            this.lbOperCount.Size = new System.Drawing.Size( 59, 12 );
            this.lbOperCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbOperCount.TabIndex = 12;
            this.lbOperCount.Text = "操作员数:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.IsEnter2Tab = false;
            this.dtpEndDate.Location = new System.Drawing.Point( 449, 11 );
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size( 112, 21 );
            this.dtpEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 11;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point( 390, 15 );
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size( 53, 12 );
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 10;
            this.neuLabel3.Text = "结束时间";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point( 197, 15 );
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size( 53, 12 );
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 9;
            this.neuLabel2.Text = "开始时间";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.IsEnter2Tab = false;
            this.dtpStartDate.Location = new System.Drawing.Point( 256, 11 );
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size( 112, 21 );
            this.dtpStartDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpStartDate.TabIndex = 7;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point( 390, 46 );
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size( 59, 12 );
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "当前科室:";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.IsEnter2Tab = false;
            this.txtCheckNo.Location = new System.Drawing.Point( 70, 11 );
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size( 97, 21 );
            this.txtCheckNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCheckNo.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point( 11, 15 );
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size( 53, 12 );
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "盘点单号";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add( this.neuSpread1 );
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point( 0, 78 );
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size( 900, 302 );
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point( 0, 0 );
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[] {
            this.fpCheckLogs} );
            this.neuSpread1.Size = new System.Drawing.Size( 900, 302 );
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpCheckLogs
            // 
            this.fpCheckLogs.Reset();
            this.fpCheckLogs.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpCheckLogs.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpCheckLogs.ColumnCount = 13;
            this.fpCheckLogs.RowCount = 1;
            this.fpCheckLogs.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Professional2;
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 0 ).Value = "盘点单号";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 1 ).Value = "盘点科室";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 2 ).Value = "盘点药品";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 3 ).Value = "批号";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 4 ).Value = "规格";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 5 ).Value = "零售价";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 6 ).Value = "包装单位";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 7 ).Value = "包装数量";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 8 ).Value = "盘存数量";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 9 ).Value = "单位";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 10 ).Value = "货位号";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 11 ).Value = "操作时间";
            this.fpCheckLogs.ColumnHeader.Cells.Get( 0, 12 ).Value = "操作人";
            this.fpCheckLogs.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))) );
            this.fpCheckLogs.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Bold );
            this.fpCheckLogs.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpCheckLogs.ColumnHeader.DefaultStyle.Locked = false;
            this.fpCheckLogs.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCheckLogs.Columns.Get( 0 ).Label = "盘点单号";
            this.fpCheckLogs.Columns.Get( 0 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 0 ).Width = 80F;
            this.fpCheckLogs.Columns.Get( 1 ).Label = "盘点科室";
            this.fpCheckLogs.Columns.Get( 1 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 1 ).Width = 120F;
            this.fpCheckLogs.Columns.Get( 2 ).Label = "盘点药品";
            this.fpCheckLogs.Columns.Get( 2 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 2 ).Width = 150F;
            this.fpCheckLogs.Columns.Get( 3 ).Label = "批号";
            this.fpCheckLogs.Columns.Get( 3 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 3 ).Width = 80F;
            this.fpCheckLogs.Columns.Get( 4 ).Label = "规格";
            this.fpCheckLogs.Columns.Get( 4 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 4 ).Width = 80F;
            this.fpCheckLogs.Columns.Get( 5 ).Label = "零售价";
            this.fpCheckLogs.Columns.Get( 5 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 5 ).Width = 70F;
            this.fpCheckLogs.Columns.Get( 6 ).Label = "包装单位";
            this.fpCheckLogs.Columns.Get( 6 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 7 ).Label = "包装数量";
            this.fpCheckLogs.Columns.Get( 7 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 8 ).Label = "盘存数量";
            this.fpCheckLogs.Columns.Get( 8 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 8 ).Width = 69F;
            this.fpCheckLogs.Columns.Get( 9 ).Label = "单位";
            this.fpCheckLogs.Columns.Get( 9 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 10 ).Label = "货位号";
            this.fpCheckLogs.Columns.Get( 10 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 10 ).Width = 70F;
            this.fpCheckLogs.Columns.Get( 11 ).Label = "操作时间";
            this.fpCheckLogs.Columns.Get( 11 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 11 ).Width = 130F;
            this.fpCheckLogs.Columns.Get( 12 ).Label = "操作人";
            this.fpCheckLogs.Columns.Get( 12 ).Locked = true;
            this.fpCheckLogs.Columns.Get( 12 ).Width = 70F;
            this.fpCheckLogs.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpCheckLogs.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))) );
            this.fpCheckLogs.DefaultStyle.Locked = true;
            this.fpCheckLogs.DefaultStyle.Parent = "DataAreaDefault";
            this.fpCheckLogs.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpCheckLogs.RowHeader.Columns.Default.Resizable = false;
            this.fpCheckLogs.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))) );
            this.fpCheckLogs.RowHeader.DefaultStyle.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Bold );
            this.fpCheckLogs.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpCheckLogs.RowHeader.DefaultStyle.Locked = false;
            this.fpCheckLogs.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCheckLogs.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))) );
            this.fpCheckLogs.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpCheckLogs.SheetCornerStyle.Locked = false;
            this.fpCheckLogs.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpCheckLogs.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpCheckLogs.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucQueryCheckLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.neuPanel2 );
            this.Controls.Add( this.neuPanel1 );
            this.Name = "ucQueryCheckLogs";
            this.Size = new System.Drawing.Size( 900, 380 );
            this.neuPanel1.ResumeLayout( false );
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCheckLogs)).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCheckNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpCheckLogs;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpStartDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbRecordCount;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbOperCount;
    }
}
