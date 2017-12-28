namespace Neusoft.WinForms.Report.BedDayReport
{
    partial class ucDayReportManager
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.chkAll = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.lblSum = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).BeginInit();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbDept);
            this.neuGroupBox1.Controls.Add(this.chkAll);
            this.neuGroupBox1.Controls.Add(this.dtpEndDate);
            this.neuGroupBox1.Controls.Add(this.dtpBeginDate);
            this.neuGroupBox1.Controls.Add(this.lblSum);
            this.neuGroupBox1.Controls.Add(this.lblInfo);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.lblDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(833, 91);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = false;
            this.cmbDept.IsLike = true;
            this.cmbDept.IsListOnly = false;
            this.cmbDept.IsPopForm = true;
            this.cmbDept.IsShowCustomerList = false;
            this.cmbDept.IsShowID = false;
            this.cmbDept.Location = new System.Drawing.Point(70, 41);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(224, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 3;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(333, 16);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.IsEnter2Tab = false;
            this.dtpEndDate.Location = new System.Drawing.Point(197, 14);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(97, 21);
            this.dtpEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate.IsEnter2Tab = false;
            this.dtpBeginDate.Location = new System.Drawing.Point(71, 14);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(97, 21);
            this.dtpBeginDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginDate.TabIndex = 1;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.ForeColor = System.Drawing.Color.Black;
            this.lblSum.Location = new System.Drawing.Point(12, 69);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(0, 12);
            this.lblSum.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblSum.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(419, 18);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(293, 12);
            this.lblInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "灰色表示已经提交无法再次修改，红色表示已经结转。";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(174, 18);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "至";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.ForeColor = System.Drawing.Color.Blue;
            this.lblDept.Location = new System.Drawing.Point(6, 45);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(59, 12);
            this.lblDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "科    室:";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 18);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(59, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "统计日期:";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 床位汇总";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 91);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2});
            this.neuSpread1.Size = new System.Drawing.Size(833, 336);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "床位汇总";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 14;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "日期";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "加床数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "空床数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "期初病人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "入院人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "转入人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "转出人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "出院人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "死亡人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "期末病人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "科室编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "编制内床位数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "是否提交";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 38F;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "日期";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "科室";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 96F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "加床数";
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 50F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "空床数";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 46F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "期初病人数";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 46F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "入院人数";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 37F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "转入人数";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 36F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "转出人数";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 37F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "出院人数";
            this.neuSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 36F;
            this.neuSpread1_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "死亡人数";
            this.neuSpread1_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 38F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "期末病人数";
            this.neuSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 53F;
            this.neuSpread1_Sheet1.Columns.Get(11).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "科室编码";
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 35F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "编制内床位数";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 51F;
            this.neuSpread1_Sheet1.Columns.Get(13).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "是否提交";
            this.neuSpread1_Sheet1.Columns.Get(13).Width = 36F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.neuSpread1_Sheet1_CellChanged);
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset();
            this.neuSpread1_Sheet2.SheetName = "床位明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucDayReportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucDayReportManager";
            this.Size = new System.Drawing.Size(833, 427);
            this.Load += new System.EventHandler(this.ucDayReportManager_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblSum;
    }
}
