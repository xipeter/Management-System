namespace UFC.InpatientFee.Balance
{
    partial class ucPopDayReportQuery
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPopDayReportQuery));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.fpQuery = new FarPoint.Win.Spread.FpSpread();
            this.fpQuery_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.dtpBeginDate = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.neuGroupBox1 = new Neusoft.NFC.Interface.Controls.NeuGroupBox();
            this.btnExit = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.neuLabel2 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.btnQuery = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.dtpEndDate = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpQuery_Sheet1)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(629, 453);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.fpQuery);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(0, 69);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(629, 384);
            this.neuPanel3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // fpQuery
            // 
            this.fpQuery.About = "2.5.2007.2005";
            this.fpQuery.AccessibleDescription = "fpQuery, Sheet1, Row 0, Column 0, ";
            this.fpQuery.BackColor = System.Drawing.SystemColors.Control;
            this.fpQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpQuery.Location = new System.Drawing.Point(0, 0);
            this.fpQuery.Name = "fpQuery";
            this.fpQuery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpQuery_Sheet1});
            this.fpQuery.Size = new System.Drawing.Size(629, 384);
            this.fpQuery.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpQuery.TextTipAppearance = tipAppearance1;
            this.fpQuery.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpQuery_CellDoubleClick);
            // 
            // fpQuery_Sheet1
            // 
            this.fpQuery_Sheet1.Reset();
            this.fpQuery_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpQuery_Sheet1.ColumnCount = 4;
            this.fpQuery_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "序号";
            this.fpQuery_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "开始时间";
            this.fpQuery_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "结束时间";
            this.fpQuery_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "操作时间";
            this.fpQuery_Sheet1.Columns.Get(0).Label = "序号";
            this.fpQuery_Sheet1.Columns.Get(0).Width = 118F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 1, 30, 14, 39, 0, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 1, 30, 14, 39, 0, 0);
            this.fpQuery_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
            this.fpQuery_Sheet1.Columns.Get(1).Label = "开始时间";
            this.fpQuery_Sheet1.Columns.Get(1).Width = 118F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 1, 30, 14, 39, 19, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 1, 30, 14, 39, 19, 0);
            this.fpQuery_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
            this.fpQuery_Sheet1.Columns.Get(2).Label = "结束时间";
            this.fpQuery_Sheet1.Columns.Get(2).Width = 118F;
            this.fpQuery_Sheet1.Columns.Get(3).Label = "操作时间";
            this.fpQuery_Sheet1.Columns.Get(3).Width = 118F;
            this.fpQuery_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpQuery_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpQuery_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpQuery_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Controls.Add(this.dtpBeginDate);
            this.neuPanel2.Controls.Add(this.neuGroupBox1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(629, 69);
            this.neuPanel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(11, 29);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "开始时间";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(66, 25);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(152, 21);
            this.dtpBeginDate.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtpBeginDate.TabIndex = 0;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.btnExit);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.btnQuery);
            this.neuGroupBox1.Controls.Add(this.dtpEndDate);
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 2);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(623, 62);
            this.neuGroupBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 5;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "查询条件";
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(535, 22);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(221, 27);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 3;
            this.neuLabel2.Text = "结束时间";
            // 
            // btnQuery
            // 
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(442, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(278, 23);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(152, 21);
            this.dtpEndDate.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 1;
            // 
            // ucPopDayReportQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucPopDayReportQuery";
            this.Size = new System.Drawing.Size(629, 453);
            this.Load += new System.EventHandler(this.ucPopDayReportQuery_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpQuery_Sheet1)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel2;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel3;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel2;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtpBeginDate;
        private FarPoint.Win.Spread.FpSpread fpQuery;
        private FarPoint.Win.Spread.SheetView fpQuery_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.NFC.Interface.Controls.NeuButton btnQuery;
        private Neusoft.NFC.Interface.Controls.NeuButton btnExit;
    }
}
