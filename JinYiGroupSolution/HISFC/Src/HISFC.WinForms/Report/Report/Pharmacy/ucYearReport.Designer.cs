namespace Neusoft.WinForms.Report.Pharmacy
{
    partial class ucYearReport
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpHead = new FarPoint.Win.Spread.SheetView();
            this.fpDetail = new FarPoint.Win.Spread.SheetView();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtYear = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuGroupBox1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(750, 41);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Controls.Add(this.neuLabel3);
            this.neuPanel2.Controls.Add(this.lbDate);
            this.neuPanel2.Controls.Add(this.lbDept);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 41);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(750, 402);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 汇总, Row 0, Column 0, ";
            this.neuSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 60);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpHead,
            this.fpDetail});
            this.neuSpread1.Size = new System.Drawing.Size(750, 342);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 4;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // fpHead
            // 
            this.fpHead.Reset();
            this.fpHead.SheetName = "汇总";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpHead.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpHead.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpHead.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.ColumnHeader.DefaultStyle.Locked = false;
            this.fpHead.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHead.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpHead.RowHeader.Columns.Get(0).Width = 37F;
            this.fpHead.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.RowHeader.DefaultStyle.Locked = false;
            this.fpHead.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHead.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.SheetCornerStyle.Locked = false;
            this.fpHead.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpHead.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpDetail
            // 
            this.fpDetail.Reset();
            this.fpDetail.SheetName = "明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetail.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpDetail.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail.ColumnHeader.DefaultStyle.Locked = false;
            this.fpDetail.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetail.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDetail.RowHeader.Columns.Get(0).Width = 37F;
            this.fpDetail.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail.RowHeader.DefaultStyle.Locked = false;
            this.fpDetail.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetail.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail.SheetCornerStyle.Locked = false;
            this.fpDetail.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(192, 3);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(262, 24);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "  年   结   报   表  ";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.Blue;
            this.lbDate.Location = new System.Drawing.Point(227, 45);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(53, 12);
            this.lbDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDate.TabIndex = 2;
            this.lbDate.Text = "统计周期";
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.ForeColor = System.Drawing.Color.Blue;
            this.lbDept.Location = new System.Drawing.Point(4, 45);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(53, 12);
            this.lbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDept.TabIndex = 1;
            this.lbDept.Text = "库存科室";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.dtYear);
            this.neuGroupBox1.Controls.Add(this.cmbDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(750, 41);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 5;
            this.neuGroupBox1.TabStop = false;
            // 
            // dtYear
            // 
            this.dtYear.CustomFormat = "yyyy年";
            this.dtYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtYear.Location = new System.Drawing.Point(286, 13);
            this.dtYear.Name = "dtYear";
            this.dtYear.Size = new System.Drawing.Size(111, 21);
            this.dtYear.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtYear.TabIndex = 8;
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(61, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(150, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 7;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(227, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 5;
            this.neuLabel2.Text = "统计年份";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(4, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 6;
            this.neuLabel1.Text = "统计科室";
            // 
            // ucYearReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucYearReport";
            this.Size = new System.Drawing.Size(750, 443);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpHead;
        private FarPoint.Win.Spread.SheetView fpDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtYear;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
