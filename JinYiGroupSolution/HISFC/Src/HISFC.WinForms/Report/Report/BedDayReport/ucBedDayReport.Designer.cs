namespace Neusoft.WinForms.Report.BedDayReport
{
    partial class ucBedDayReport
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuDateTimePicker2 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.neuDateTimePicker2);
            this.neuGroupBox1.Controls.Add(this.neuDateTimePicker1);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(6, 3);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(544, 42);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(350, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(125, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 3;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.Visible = false;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel6.Location = new System.Drawing.Point(291, 17);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 2;
            this.neuLabel6.Text = "统计科室";
            this.neuLabel6.Visible = false;
            // 
            // neuDateTimePicker2
            // 
            this.neuDateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.neuDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.neuDateTimePicker2.Location = new System.Drawing.Point(181, 13);
            this.neuDateTimePicker2.Name = "neuDateTimePicker2";
            this.neuDateTimePicker2.Size = new System.Drawing.Size(91, 21);
            this.neuDateTimePicker2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker2.TabIndex = 1;
            this.neuDateTimePicker2.Visible = false;
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.neuDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.neuDateTimePicker1.Location = new System.Drawing.Point(65, 13);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(90, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(161, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "－";
            this.neuLabel2.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "统计区间";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(3, 47);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(89, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 3;
            this.neuLabel4.Text = "聊城市人民医院";
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.Location = new System.Drawing.Point(256, 47);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(89, 12);
            this.lbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDept.TabIndex = 3;
            this.lbDept.Text = "统计范围：全院";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(490, 47);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(101, 12);
            this.lbDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDate.TabIndex = 3;
            this.lbDate.Text = "日期：2007-07-26";
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSpread1);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 50);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(733, 367);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 4;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuLabel5);
            this.neuPanel2.Controls.Add(this.lbDate);
            this.neuPanel2.Controls.Add(this.lbDept);
            this.neuPanel2.Controls.Add(this.neuLabel4);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(733, 66);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 5;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuGroupBox1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel3.Location = new System.Drawing.Point(0, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(733, 50);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 6;
            // 
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset();
            this.neuSpread1_Sheet2.SheetName = "科室明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.ColumnCount = 15;
            this.neuSpread1_Sheet2.ColumnHeader.RowCount = 3;
            this.neuSpread1_Sheet2.RowCount = 100;
            this.neuSpread1_Sheet2.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "日期";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = "实开床位数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 2).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 2).Value = "原有病人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 3).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 3).Value = "入院人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 4).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 4).Value = "转入人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 5).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 5).Value = "转出人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 6;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 6).Value = "出    院    人    数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 12).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 12).Value = "底实有人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 13).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 13).Value = "出院者占用总床日数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 14).RowSpan = 3;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 14).Value = "科室编码";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 6).RowSpan = 2;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 6).Value = "  总    计";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 7).ColumnSpan = 5;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 7).Value = "其中:出院病人数";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 7).Value = "计";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 8).Value = "治愈";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 9).Value = "好转";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 10).Value = "未愈";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 11).Value = "死亡";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(2, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.ColumnHeader.Rows.Get(0).Height = 22F;
            this.neuSpread1_Sheet2.ColumnHeader.Rows.Get(2).Height = 26F;
            this.neuSpread1_Sheet2.Columns.Get(0).CellType = textCellType2;
            this.neuSpread1_Sheet2.Columns.Get(0).Width = 87F;
            this.neuSpread1_Sheet2.Columns.Get(1).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(2).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(3).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(4).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(5).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(6).Width = 44F;
            this.neuSpread1_Sheet2.Columns.Get(11).Label = "死亡";
            this.neuSpread1_Sheet2.Columns.Get(11).Width = 38F;
            this.neuSpread1_Sheet2.Columns.Get(12).Width = 30F;
            this.neuSpread1_Sheet2.Columns.Get(13).Width = 43F;
            this.neuSpread1_Sheet2.Columns.Get(14).CellType = textCellType3;
            this.neuSpread1_Sheet2.Columns.Get(14).Visible = false;
            this.neuSpread1_Sheet2.Columns.Get(14).Width = 33F;
            this.neuSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.RowHeader.Visible = false;
            this.neuSpread1_Sheet2.Rows.Default.Height = 24F;
            this.neuSpread1_Sheet2.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet2.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "全院统计";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 16;
            this.neuSpread1_Sheet1.ColumnHeader.RowCount = 3;
            this.neuSpread1_Sheet1.RowCount = 100;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "科 别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "实开床位数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "原有病人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "入院人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "转入人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "转出人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 6;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "出    院    人    数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "底实有人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "加床或空床";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "出院者占用总床日数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 3;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "科室编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 6).RowSpan = 2;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 6).Value = "总计";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 7).ColumnSpan = 5;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 7).Value = "其中：出院病人数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 7).Value = "计";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 8).Value = "治愈";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 9).Value = "好转";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 10).Value = "未愈";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 11).Value = "死亡";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(2, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(2).Height = 26F;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 105F;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 37F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "计";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 46F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "治愈";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 35F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "好转";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 35F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "未愈";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 35F;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "死亡";
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 33F;
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(13).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 52F;
            this.neuSpread1_Sheet1.Columns.Get(15).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(15).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(15).Width = 32F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Default.Height = 24F;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 全院统计, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 66);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2});
            this.neuSpread1.Size = new System.Drawing.Size(733, 301);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler(this.neuSpread1_SheetTabClick);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Font = new System.Drawing.Font("宋体", 15F);
            this.neuLabel5.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel5.Location = new System.Drawing.Point(192, 15);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(189, 20);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 4;
            this.neuLabel5.Text = "住院病房工作日报表";
            // 
            // ucBedDayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuPanel3);
            this.Name = "ucBedDayReport";
            this.Size = new System.Drawing.Size(733, 417);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}
