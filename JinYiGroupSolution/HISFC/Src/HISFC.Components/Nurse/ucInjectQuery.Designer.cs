namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucInjectQuery
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInjectQuery));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelList = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtInjectDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtMixDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtRegDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.txtOrder = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cbInjectDate = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbInjectOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cbInjectOper = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cbMixDate = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbMixOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cbMixOper = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cbOrder = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cbRegDate = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbRegOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cbRegOper = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuPanel1.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.panelList);
            this.neuPanel1.Controls.Add(this.neuSplitter1);
            this.neuPanel1.Controls.Add(this.panelLeft);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(821, 523);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.neuSpread1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(231, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(590, 523);
            this.panelList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelList.TabIndex = 3;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(590, 523);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ButtonClicked);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 24;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "Seq";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "日顺序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "病历号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "患者姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "开单医生";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "开单科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "医嘱";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "组合";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "每次量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "频次";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "用法";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "皮试?";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Text = "登记人";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Text = "登记时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Text = "配药人";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Text = "配药时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Text = "注射人";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Text = "注射时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 19).Text = "滴速";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 20).Text = "拔针人";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 21).Text = "拔针时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 22).Text = "送急诊时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 23).Text = "特殊情况记录";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 29F;
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 27F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "Seq";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 27F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "日顺序号";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 34F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "病历号";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 67F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "开单医生";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 59F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "开单科室";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 69F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "医嘱";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 150F;
            this.neuSpread1_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("仿宋_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.neuSpread1_Sheet1.Columns.Get(8).ForeColor = System.Drawing.Color.Red;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "组合";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 20F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "每次量";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 65F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "频次";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 39F;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "用法";
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 41F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "皮试?";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 26F;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "登记时间";
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 105F;
            this.neuSpread1_Sheet1.Columns.Get(15).Label = "配药人";
            this.neuSpread1_Sheet1.Columns.Get(15).Width = 56F;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType1.UserDefinedFormat = "yyyy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(16).CellType = dateTimeCellType1;
            this.neuSpread1_Sheet1.Columns.Get(16).Label = "配药时间";
            this.neuSpread1_Sheet1.Columns.Get(16).Width = 95F;
            this.neuSpread1_Sheet1.Columns.Get(17).Label = "注射人";
            this.neuSpread1_Sheet1.Columns.Get(17).Width = 58F;
            dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59");
            dateTimeCellType2.SpinButton = true;
            dateTimeCellType2.UserDefinedFormat = "yyyy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(18).CellType = dateTimeCellType2;
            this.neuSpread1_Sheet1.Columns.Get(18).Label = "注射时间";
            this.neuSpread1_Sheet1.Columns.Get(18).Width = 106F;
            this.neuSpread1_Sheet1.Columns.Get(19).Label = "滴速";
            this.neuSpread1_Sheet1.Columns.Get(19).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(19).Width = 29F;
            this.neuSpread1_Sheet1.Columns.Get(20).Label = "拔针人";
            this.neuSpread1_Sheet1.Columns.Get(20).Width = 64F;
            dateTimeCellType3.AcceptsArrowKeys = FarPoint.Win.SuperEdit.AcceptsArrowKeys.Arrows;
            dateTimeCellType3.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType3.MaximumTime = System.TimeSpan.Parse("23:59:59");
            dateTimeCellType3.UserDefinedFormat = "yy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(21).CellType = dateTimeCellType3;
            this.neuSpread1_Sheet1.Columns.Get(21).Label = "拔针时间";
            this.neuSpread1_Sheet1.Columns.Get(21).Width = 115F;
            dateTimeCellType4.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType4.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateTimeCellType4.UserDefinedFormat = "yyyy-MM-dd HH:mm";
            this.neuSpread1_Sheet1.Columns.Get(22).CellType = dateTimeCellType4;
            this.neuSpread1_Sheet1.Columns.Get(22).Label = "送急诊时间";
            this.neuSpread1_Sheet1.Columns.Get(22).Width = 115F;
            this.neuSpread1_Sheet1.Columns.Get(23).Label = "特殊情况记录";
            this.neuSpread1_Sheet1.Columns.Get(23).Width = 117F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(228, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 523);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Linen;
            this.panelLeft.Controls.Add(this.neuPanel4);
            this.panelLeft.Controls.Add(this.neuPanel3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(228, 523);
            this.panelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelLeft.TabIndex = 0;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.neuGroupBox1);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel4.Location = new System.Drawing.Point(0, 116);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(228, 343);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 8;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.dtInjectDate);
            this.neuGroupBox1.Controls.Add(this.dtMixDate);
            this.neuGroupBox1.Controls.Add(this.dtRegDate);
            this.neuGroupBox1.Controls.Add(this.txtOrder);
            this.neuGroupBox1.Controls.Add(this.cbInjectDate);
            this.neuGroupBox1.Controls.Add(this.cmbInjectOper);
            this.neuGroupBox1.Controls.Add(this.cbInjectOper);
            this.neuGroupBox1.Controls.Add(this.cbMixDate);
            this.neuGroupBox1.Controls.Add(this.cmbMixOper);
            this.neuGroupBox1.Controls.Add(this.cbMixOper);
            this.neuGroupBox1.Controls.Add(this.cbOrder);
            this.neuGroupBox1.Controls.Add(this.cbRegDate);
            this.neuGroupBox1.Controls.Add(this.cmbRegOper);
            this.neuGroupBox1.Controls.Add(this.cbRegOper);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(228, 343);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 5;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "选项";
            // 
            // dtInjectDate
            // 
            this.dtInjectDate.Location = new System.Drawing.Point(85, 234);
            this.dtInjectDate.Name = "dtInjectDate";
            this.dtInjectDate.Size = new System.Drawing.Size(116, 21);
            this.dtInjectDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtInjectDate.TabIndex = 17;
            // 
            // dtMixDate
            // 
            this.dtMixDate.Location = new System.Drawing.Point(85, 156);
            this.dtMixDate.Name = "dtMixDate";
            this.dtMixDate.Size = new System.Drawing.Size(116, 21);
            this.dtMixDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtMixDate.TabIndex = 16;
            // 
            // dtRegDate
            // 
            this.dtRegDate.Location = new System.Drawing.Point(85, 57);
            this.dtRegDate.Name = "dtRegDate";
            this.dtRegDate.Size = new System.Drawing.Size(116, 21);
            this.dtRegDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtRegDate.TabIndex = 15;
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(85, 84);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(116, 21);
            this.txtOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOrder.TabIndex = 14;
            this.txtOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrder_KeyDown);
            // 
            // cbInjectDate
            // 
            this.cbInjectDate.AutoSize = true;
            this.cbInjectDate.Location = new System.Drawing.Point(8, 237);
            this.cbInjectDate.Name = "cbInjectDate";
            this.cbInjectDate.Size = new System.Drawing.Size(72, 16);
            this.cbInjectDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbInjectDate.TabIndex = 12;
            this.cbInjectDate.Text = "注射日期";
            this.cbInjectDate.UseVisualStyleBackColor = true;
            // 
            // cmbInjectOper
            // 
            this.cmbInjectOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInjectOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInjectOper.FormattingEnabled = true;
            this.cmbInjectOper.IsFlat = true;
            this.cmbInjectOper.IsLike = true;
            this.cmbInjectOper.Location = new System.Drawing.Point(85, 206);
            this.cmbInjectOper.Name = "cmbInjectOper";
            this.cmbInjectOper.PopForm = null;
            this.cmbInjectOper.ShowCustomerList = false;
            this.cmbInjectOper.ShowID = false;
            this.cmbInjectOper.Size = new System.Drawing.Size(116, 20);
            this.cmbInjectOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbInjectOper.TabIndex = 11;
            this.cmbInjectOper.Tag = "";
            this.cmbInjectOper.ToolBarUse = false;
            // 
            // cbInjectOper
            // 
            this.cbInjectOper.AutoSize = true;
            this.cbInjectOper.Location = new System.Drawing.Point(8, 211);
            this.cbInjectOper.Name = "cbInjectOper";
            this.cbInjectOper.Size = new System.Drawing.Size(72, 16);
            this.cbInjectOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbInjectOper.TabIndex = 10;
            this.cbInjectOper.Text = "注射护士";
            this.cbInjectOper.UseVisualStyleBackColor = true;
            // 
            // cbMixDate
            // 
            this.cbMixDate.AutoSize = true;
            this.cbMixDate.Location = new System.Drawing.Point(8, 159);
            this.cbMixDate.Name = "cbMixDate";
            this.cbMixDate.Size = new System.Drawing.Size(72, 16);
            this.cbMixDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbMixDate.TabIndex = 8;
            this.cbMixDate.Text = "配药日期";
            this.cbMixDate.UseVisualStyleBackColor = true;
            // 
            // cmbMixOper
            // 
            this.cmbMixOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMixOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMixOper.FormattingEnabled = true;
            this.cmbMixOper.IsFlat = true;
            this.cmbMixOper.IsLike = true;
            this.cmbMixOper.Location = new System.Drawing.Point(85, 128);
            this.cmbMixOper.Name = "cmbMixOper";
            this.cmbMixOper.PopForm = null;
            this.cmbMixOper.ShowCustomerList = false;
            this.cmbMixOper.ShowID = false;
            this.cmbMixOper.Size = new System.Drawing.Size(116, 20);
            this.cmbMixOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMixOper.TabIndex = 7;
            this.cmbMixOper.Tag = "";
            this.cmbMixOper.ToolBarUse = false;
            // 
            // cbMixOper
            // 
            this.cbMixOper.AutoSize = true;
            this.cbMixOper.Location = new System.Drawing.Point(8, 133);
            this.cbMixOper.Name = "cbMixOper";
            this.cbMixOper.Size = new System.Drawing.Size(72, 16);
            this.cbMixOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbMixOper.TabIndex = 6;
            this.cbMixOper.Text = "配药护士";
            this.cbMixOper.UseVisualStyleBackColor = true;
            // 
            // cbOrder
            // 
            this.cbOrder.AutoSize = true;
            this.cbOrder.Location = new System.Drawing.Point(8, 87);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(72, 16);
            this.cbOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbOrder.TabIndex = 4;
            this.cbOrder.Text = "流 水 号";
            this.cbOrder.UseVisualStyleBackColor = true;
            // 
            // cbRegDate
            // 
            this.cbRegDate.AutoSize = true;
            this.cbRegDate.Location = new System.Drawing.Point(8, 60);
            this.cbRegDate.Name = "cbRegDate";
            this.cbRegDate.Size = new System.Drawing.Size(72, 16);
            this.cbRegDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbRegDate.TabIndex = 2;
            this.cbRegDate.Text = "登记日期";
            this.cbRegDate.UseVisualStyleBackColor = true;
            // 
            // cmbRegOper
            // 
            this.cmbRegOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbRegOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegOper.FormattingEnabled = true;
            this.cmbRegOper.IsFlat = true;
            this.cmbRegOper.IsLike = true;
            this.cmbRegOper.Location = new System.Drawing.Point(85, 27);
            this.cmbRegOper.Name = "cmbRegOper";
            this.cmbRegOper.PopForm = null;
            this.cmbRegOper.ShowCustomerList = false;
            this.cmbRegOper.ShowID = false;
            this.cmbRegOper.Size = new System.Drawing.Size(116, 20);
            this.cmbRegOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbRegOper.TabIndex = 1;
            this.cmbRegOper.Tag = "";
            this.cmbRegOper.ToolBarUse = false;
            // 
            // cbRegOper
            // 
            this.cbRegOper.AutoSize = true;
            this.cbRegOper.Location = new System.Drawing.Point(8, 32);
            this.cbRegOper.Name = "cbRegOper";
            this.cbRegOper.Size = new System.Drawing.Size(72, 16);
            this.cbRegOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbRegOper.TabIndex = 0;
            this.cbRegOper.Text = "登 记 人";
            this.cbRegOper.UseVisualStyleBackColor = true;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuGroupBox2);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel3.Location = new System.Drawing.Point(0, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(228, 116);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 7;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.neuLabel1);
            this.neuGroupBox2.Controls.Add(this.txtName);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Controls.Add(this.txtCardNo);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(228, 116);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 6;
            this.neuGroupBox2.TabStop = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(21, 32);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "病 历 号";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 3;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(21, 67);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "姓    名";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(86, 29);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCardNo.TabIndex = 1;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // ucInjectQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucInjectQuery";
            this.Size = new System.Drawing.Size(821, 523);
            this.neuPanel1.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelList;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbInjectDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInjectOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbInjectOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbMixDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMixOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbMixOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbRegDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbRegOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbRegOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtInjectDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtMixDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtRegDate;
    }
}
