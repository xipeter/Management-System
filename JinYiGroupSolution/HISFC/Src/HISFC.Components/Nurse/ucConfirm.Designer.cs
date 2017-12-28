namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucConfirm
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConfirm));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.panel1 = new System.Windows.Forms.Panel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtBirthday = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtAge = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtpExec = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtOrder = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucDosageAlter1 = new Neusoft.HISFC.Components.Nurse.Inject.ucDosageAlter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.panel2.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.neuSpread1);
            this.panel1.Controls.Add(this.ucDosageAlter1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 508);
            this.panel1.TabIndex = 0;
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
            this.neuSpread1.Location = new System.Drawing.Point(206, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(542, 286);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ButtonClicked);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellClick);
            this.neuSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuSpread1_KeyDown);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 21;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "顺序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "患者姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "开单医生";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "科别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "午别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "医嘱";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "组合";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "每次量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "频次";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "用法";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "皮试?";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "配药护士";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "注射护士";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "注射时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "滴速";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "拔针人";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "拔针时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "送急诊时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 27F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "Seq";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 26F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "顺序号";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 33F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "开单医生";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 56F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "科别";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 70F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "午别";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 32F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "医嘱";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 150F;
            this.neuSpread1_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Columns.Get(8).ForeColor = System.Drawing.Color.Red;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "组合";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 22F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "每次量";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 65F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "频次";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 39F;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "用法";
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 41F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "皮试?";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 27F;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "配药护士";
            this.neuSpread1_Sheet1.Columns.Get(13).Width = 56F;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "注射护士";
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 58F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59");
            dateTimeCellType1.SpinButton = true;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType1.UserDefinedFormat = "yyyy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(15).CellType = dateTimeCellType1;
            this.neuSpread1_Sheet1.Columns.Get(15).Label = "注射时间";
            this.neuSpread1_Sheet1.Columns.Get(15).Width = 100F;
            numberCellType1.MaximumValue = 9999999;
            numberCellType1.MinimumValue = 0;
            numberCellType1.SpinDecimalIncrement = 1F;
            this.neuSpread1_Sheet1.Columns.Get(16).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(16).Label = "滴速";
            this.neuSpread1_Sheet1.Columns.Get(16).Width = 26F;
            dateTimeCellType2.AcceptsArrowKeys = FarPoint.Win.SuperEdit.AcceptsArrowKeys.Arrows;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59");
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType2.UserDefinedFormat = "yy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(18).CellType = dateTimeCellType2;
            this.neuSpread1_Sheet1.Columns.Get(18).Label = "拔针时间";
            this.neuSpread1_Sheet1.Columns.Get(18).Width = 101F;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType3.DateDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType3.TimeDefault = new System.DateTime(2007, 3, 10, 15, 3, 57, 0);
            dateTimeCellType3.UserDefinedFormat = "yyyy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(19).CellType = dateTimeCellType3;
            this.neuSpread1_Sheet1.Columns.Get(19).Label = "送急诊时间";
            this.neuSpread1_Sheet1.Columns.Get(19).Width = 108F;
            this.neuSpread1_Sheet1.Columns.Get(20).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(20).Width = 117F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 34F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 508);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.neuGroupBox2);
            this.panel2.Controls.Add(this.neuGroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 508);
            this.panel2.TabIndex = 0;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.txtBirthday);
            this.neuGroupBox2.Controls.Add(this.neuLabel6);
            this.neuGroupBox2.Controls.Add(this.txtAge);
            this.neuGroupBox2.Controls.Add(this.neuLabel7);
            this.neuGroupBox2.Controls.Add(this.txtSex);
            this.neuGroupBox2.Controls.Add(this.neuLabel4);
            this.neuGroupBox2.Controls.Add(this.txtName);
            this.neuGroupBox2.Controls.Add(this.neuLabel5);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 151);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(200, 192);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "患者信息";
            // 
            // txtBirthday
            // 
            this.txtBirthday.IsEnter2Tab = false;
            this.txtBirthday.Location = new System.Drawing.Point(76, 132);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(114, 21);
            this.txtBirthday.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBirthday.TabIndex = 11;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(11, 135);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 10;
            this.neuLabel6.Text = "出生日期";
            // 
            // txtAge
            // 
            this.txtAge.IsEnter2Tab = false;
            this.txtAge.Location = new System.Drawing.Point(76, 96);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(114, 21);
            this.txtAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtAge.TabIndex = 9;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(11, 99);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(53, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 8;
            this.neuLabel7.Text = "年    龄";
            // 
            // txtSex
            // 
            this.txtSex.IsEnter2Tab = false;
            this.txtSex.Location = new System.Drawing.Point(76, 61);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(114, 21);
            this.txtSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSex.TabIndex = 7;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(11, 64);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "性    别";
            // 
            // txtName
            // 
            this.txtName.IsEnter2Tab = false;
            this.txtName.Location = new System.Drawing.Point(76, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 5;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(11, 28);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 4;
            this.neuLabel5.Text = "姓    名";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.dtpExec);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.txtOrder);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.txtCardNo);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(200, 151);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // dtpExec
            // 
            this.dtpExec.IsEnter2Tab = false;
            this.dtpExec.Location = new System.Drawing.Point(76, 96);
            this.dtpExec.Name = "dtpExec";
            this.dtpExec.Size = new System.Drawing.Size(114, 21);
            this.dtpExec.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpExec.TabIndex = 5;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(11, 100);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "执行日期";
            // 
            // txtOrder
            // 
            this.txtOrder.IsEnter2Tab = false;
            this.txtOrder.Location = new System.Drawing.Point(76, 61);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(114, 21);
            this.txtOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOrder.TabIndex = 3;
            this.txtOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrder_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(11, 64);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "队 列 号";
            // 
            // txtCardNo
            // 
            this.txtCardNo.IsEnter2Tab = false;
            this.txtCardNo.Location = new System.Drawing.Point(76, 25);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(114, 21);
            this.txtCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCardNo.TabIndex = 1;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(11, 28);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "病 历 号";
            // 
            // ucDosageAlter1
            // 
            this.ucDosageAlter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))));
            this.ucDosageAlter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDosageAlter1.IsPrint = false;
            this.ucDosageAlter1.Location = new System.Drawing.Point(206, 286);
            this.ucDosageAlter1.Name = "ucDosageAlter1";
            this.ucDosageAlter1.QueryDate = new System.DateTime(2010, 7, 23, 15, 13, 41, 174);
            this.ucDosageAlter1.Size = new System.Drawing.Size(542, 222);
            this.ucDosageAlter1.TabIndex = 3;
            this.ucDosageAlter1.Visible = false;
            // 
            // ucConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucConfirm";
            this.Size = new System.Drawing.Size(748, 508);
            this.Load += new System.EventHandler(this.ucConfirm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBirthday;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtAge;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpExec;
        private Neusoft.HISFC.Components.Nurse.Inject.ucDosageAlter ucDosageAlter1;
    }
}
