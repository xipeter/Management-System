namespace Neusoft.WinForms.Report.OutpatientFee.DayBalance
{
    partial class ucCollectDayBalanceInfo
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ckRePrint = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.btSelectAll = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.dtEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ckRePrint);
            this.neuPanel1.Controls.Add(this.btSelectAll);
            this.neuPanel1.Controls.Add(this.btExit);
            this.neuPanel1.Controls.Add(this.btOk);
            this.neuPanel1.Controls.Add(this.btQuery);
            this.neuPanel1.Controls.Add(this.dtEndDate);
            this.neuPanel1.Controls.Add(this.dtBeginDate);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(909, 77);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // ckRePrint
            // 
            this.ckRePrint.AutoSize = true;
            this.ckRePrint.Enabled = false;
            this.ckRePrint.Location = new System.Drawing.Point(14, 55);
            this.ckRePrint.Name = "ckRePrint";
            this.ckRePrint.Size = new System.Drawing.Size(264, 16);
            this.ckRePrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckRePrint.TabIndex = 8;
            this.ckRePrint.Text = "补打  补打时自动选择该次汇总的所有日结单";
            this.ckRePrint.UseVisualStyleBackColor = true;
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(571, 12);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(73, 25);
            this.btSelectAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btSelectAll.TabIndex = 7;
            this.btSelectAll.Tag = "";
            this.btSelectAll.Text = "全选(&A)";
            this.btSelectAll.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(737, 14);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(73, 25);
            this.btExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btExit.TabIndex = 6;
            this.btExit.Text = "退出(&E)";
            this.btExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(653, 13);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(73, 25);
            this.btOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOk.TabIndex = 5;
            this.btOk.Text = "确定(&C)";
            this.btOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btQuery
            // 
            this.btQuery.Location = new System.Drawing.Point(491, 11);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(73, 25);
            this.btQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btQuery.TabIndex = 4;
            this.btQuery.Text = "查询(&Q)";
            this.btQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.IsEnter2Tab = false;
            this.dtEndDate.Location = new System.Drawing.Point(290, 13);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(124, 21);
            this.dtEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEndDate.TabIndex = 3;
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.IsEnter2Tab = false;
            this.dtBeginDate.Location = new System.Drawing.Point(72, 13);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Size = new System.Drawing.Size(124, 21);
            this.dtBeginDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBeginDate.TabIndex = 2;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(225, 20);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "结束时间：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(12, 20);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "开始时间：";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 77);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(909, 479);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 7;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选择";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "收费员";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "起始时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "结束时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "起始票据号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "结束票据号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "审核时间";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选择";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 44F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "收费员";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "起始时间";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 130F;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "结束时间";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 130F;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "起始票据号";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 140F;
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = textCellType5;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "结束票据号";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 140F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "审核时间";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 130F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucCollectDayBalanceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucCollectDayBalanceInfo";
            this.Size = new System.Drawing.Size(909, 556);
            this.Load += new System.EventHandler(this.ucCollectDayBalanceInfo_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btQuery;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBeginDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btSelectAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        public Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckRePrint;
    }
}
