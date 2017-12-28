namespace Neusoft.WinForms.Report.Finance.FinIpr
{
    partial class ucFinIprOutpatientInfo2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.LineBorder lineBorder1 = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, false, true, true, true);
            FarPoint.Win.LineBorder lineBorder2 = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, false, false, true, true);
            FarPoint.Win.LineBorder lineBorder3 = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, true, false, true, true);
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbPatientID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.ntbPatientID);
            this.neuGroupBox1.Controls.Add(this.cmbDept);
            this.neuGroupBox1.Controls.Add(this.dtpEndDate);
            this.neuGroupBox1.Controls.Add(this.dtpBeginDate);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.lblDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(546, 51);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 5;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel4.Location = new System.Drawing.Point(482, 19);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(47, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 8;
            this.neuLabel4.Text = "住院号:";
            // 
            // ntbPatientID
            // 
            this.ntbPatientID.IsEnter2Tab = false;
            this.ntbPatientID.Location = new System.Drawing.Point(531, 15);
            this.ntbPatientID.Name = "ntbPatientID";
            this.ntbPatientID.Size = new System.Drawing.Size(100, 21);
            this.ntbPatientID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPatientID.TabIndex = 9;
            this.ntbPatientID.TextChanged += new System.EventHandler(this.ntbPatientID_TextChanged);
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
            this.cmbDept.Location = new System.Drawing.Point(340, 15);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(132, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 3;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.IsEnter2Tab = false;
            this.dtpEndDate.Location = new System.Drawing.Point(193, 14);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(97, 21);
            this.dtpEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate.IsEnter2Tab = false;
            this.dtpBeginDate.Location = new System.Drawing.Point(67, 14);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(97, 21);
            this.dtpBeginDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginDate.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(170, 18);
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
            this.lblDept.Location = new System.Drawing.Point(304, 19);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(35, 12);
            this.lblDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "科室:";
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
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.White;
            this.neuPanel1.Controls.Add(this.neuSpread1);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 51);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(546, 367);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 6;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 67);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(546, 300);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
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
            this.neuSpread1_Sheet1.ColumnCount = 10;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "住院号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "性别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "年龄";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "入院时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "出院时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "住院天数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "出院诊断编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "出院诊断";
            this.neuSpread1_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Border = lineBorder1;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "科室";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 119F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "住院号";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "姓名";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 62F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "性别";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 42F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "年龄";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 69F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "入院时间";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 83F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "出院时间";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 77F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "住院天数";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 40F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "出院诊断编码";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 62F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "出院诊断";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 143F;
            this.neuSpread1_Sheet1.DataAutoCellTypes = false;
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
            this.neuSpread1_Sheet1.DefaultStyle.Border = lineBorder2;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Border = lineBorder3;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.lbTitle1);
            this.neuPanel2.Controls.Add(this.lbTitle);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(546, 67);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(249, 15);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(148, 16);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "出院患者信息查询";
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Location = new System.Drawing.Point(7, 48);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(65, 12);
            this.lbTitle1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle1.TabIndex = 1;
            this.lbTitle1.Text = "查询时间：";
            // 
            // ucFinIprOutpatientInfo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucFinIprOutpatientInfo2";
            this.Size = new System.Drawing.Size(546, 418);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox ntbPatientID;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle1;
    }
}