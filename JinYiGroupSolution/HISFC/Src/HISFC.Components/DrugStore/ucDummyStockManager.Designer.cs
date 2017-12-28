namespace Neusoft.HISFC.Components.DrugStore
{
    partial class ucDummyStockManager
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDummyStockManager));
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPatient = new Common.Controls.baseTreeView();
            this.patientSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.patientSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtpEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deptSpread = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.deptSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientSpread1_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptSpread_Sheet1)).BeginInit();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(696, 450);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.neuGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(688, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "患者预扣信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvPatient);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.patientSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(688, 385);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvPatient
            // 
            this.tvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPatient.HideSelection = false;
            this.tvPatient.Location = new System.Drawing.Point(0, 0);
            this.tvPatient.Name = "tvPatient";
            this.tvPatient.Size = new System.Drawing.Size(144, 385);
            this.tvPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvPatient.TabIndex = 0;
            this.tvPatient.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPatient_AfterSelect);
            // 
            // patientSpread1
            // 
            this.patientSpread1.About = "2.5.2007.2005";
            this.patientSpread1.AccessibleDescription = "patientSpread1, Sheet1";
            this.patientSpread1.BackColor = System.Drawing.Color.White;
            this.patientSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientSpread1.FileName = "";
            this.patientSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.patientSpread1.IsAutoSaveGridStatus = false;
            this.patientSpread1.IsCanCustomConfigColumn = false;
            this.patientSpread1.Location = new System.Drawing.Point(0, 0);
            this.patientSpread1.Name = "patientSpread1";
            this.patientSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.patientSpread1_Sheet1});
            this.patientSpread1.Size = new System.Drawing.Size(541, 385);
            this.patientSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.patientSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.patientSpread1.TextTipAppearance = tipAppearance1;
            this.patientSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // patientSpread1_Sheet1
            // 
            this.patientSpread1_Sheet1.Reset();
            this.patientSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.patientSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.patientSpread1_Sheet1.ColumnCount = 9;
            this.patientSpread1_Sheet1.RowCount = 0;
            this.patientSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选中";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "药品名称";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "规格";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "零售价";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "付数";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "预扣量";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "单位";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "预扣金额";
            this.patientSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = " 预扣时间";
            this.patientSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.patientSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.patientSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.patientSpread1_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.SeaShell;
            this.patientSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.patientSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.patientSpread1_Sheet1.Columns.Get(0).Label = "选中";
            this.patientSpread1_Sheet1.Columns.Get(0).Locked = false;
            this.patientSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.patientSpread1_Sheet1.Columns.Get(1).Label = "药品名称";
            this.patientSpread1_Sheet1.Columns.Get(1).Width = 130F;
            this.patientSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.patientSpread1_Sheet1.Columns.Get(2).Width = 80F;
            this.patientSpread1_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.patientSpread1_Sheet1.Columns.Get(3).Label = "零售价";
            this.patientSpread1_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.patientSpread1_Sheet1.Columns.Get(4).Label = "付数";
            this.patientSpread1_Sheet1.Columns.Get(4).Width = 45F;
            this.patientSpread1_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.patientSpread1_Sheet1.Columns.Get(5).Label = "预扣量";
            this.patientSpread1_Sheet1.Columns.Get(5).Width = 85F;
            this.patientSpread1_Sheet1.Columns.Get(6).Label = "单位";
            this.patientSpread1_Sheet1.Columns.Get(6).Width = 48F;
            this.patientSpread1_Sheet1.Columns.Get(7).CellType = numberCellType4;
            this.patientSpread1_Sheet1.Columns.Get(7).Label = "预扣金额";
            this.patientSpread1_Sheet1.Columns.Get(7).Width = 85F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 8, 1, 9, 8, 59, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 8, 1, 9, 8, 59, 0);
            this.patientSpread1_Sheet1.Columns.Get(8).CellType = dateTimeCellType1;
            this.patientSpread1_Sheet1.Columns.Get(8).Label = " 预扣时间";
            this.patientSpread1_Sheet1.Columns.Get(8).Width = 179F;
            this.patientSpread1_Sheet1.DefaultStyle.Locked = true;
            this.patientSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.patientSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.patientSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.patientSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.patientSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.patientSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.patientSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.patientSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.patientSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.patientSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.patientSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.patientSpread1.SetActiveViewport(1, 0);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.dtpEnd);
            this.neuGroupBox1.Controls.Add(this.dtpBegin);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(688, 40);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(258, 13);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(144, 21);
            this.dtpEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(77, 12);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(144, 21);
            this.dtpBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBegin.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(231, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "－";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "预扣时间：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deptSpread);
            this.tabPage2.Controls.Add(this.neuGroupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(688, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "科室库存信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deptSpread
            // 
            this.deptSpread.About = "2.5.2007.2005";
            this.deptSpread.AccessibleDescription = "deptSpread, Sheet1";
            this.deptSpread.BackColor = System.Drawing.Color.White;
            this.deptSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptSpread.EditModeReplace = true;
            this.deptSpread.FileName = "";
            this.deptSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.deptSpread.IsAutoSaveGridStatus = false;
            this.deptSpread.IsCanCustomConfigColumn = false;
            this.deptSpread.Location = new System.Drawing.Point(0, 40);
            this.deptSpread.Name = "deptSpread";
            this.deptSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.deptSpread_Sheet1});
            this.deptSpread.Size = new System.Drawing.Size(688, 385);
            this.deptSpread.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.deptSpread.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.deptSpread.TextTipAppearance = tipAppearance2;
            this.deptSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // deptSpread_Sheet1
            // 
            this.deptSpread_Sheet1.Reset();
            this.deptSpread_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.deptSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.deptSpread_Sheet1.ColumnCount = 12;
            this.deptSpread_Sheet1.RowCount = 0;
            this.deptSpread_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "药品名称";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "零售价";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "生产厂家";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "实际库存";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "原预扣量";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "预扣库存";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "单位";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "药品编码";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "拼音码";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "五笔码";
            this.deptSpread_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "自定义码";
            this.deptSpread_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.deptSpread_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.deptSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.deptSpread_Sheet1.Columns.Get(0).Label = "药品名称";
            this.deptSpread_Sheet1.Columns.Get(0).Width = 148F;
            this.deptSpread_Sheet1.Columns.Get(1).Label = "规格";
            this.deptSpread_Sheet1.Columns.Get(1).Width = 80F;
            this.deptSpread_Sheet1.Columns.Get(2).CellType = numberCellType5;
            this.deptSpread_Sheet1.Columns.Get(2).Label = "零售价";
            this.deptSpread_Sheet1.Columns.Get(2).Width = 85F;
            this.deptSpread_Sheet1.Columns.Get(3).Label = "生产厂家";
            this.deptSpread_Sheet1.Columns.Get(3).Width = 147F;
            this.deptSpread_Sheet1.Columns.Get(4).CellType = numberCellType6;
            this.deptSpread_Sheet1.Columns.Get(4).Label = "实际库存";
            this.deptSpread_Sheet1.Columns.Get(4).Width = 96F;
            this.deptSpread_Sheet1.Columns.Get(5).Label = "原预扣量";
            this.deptSpread_Sheet1.Columns.Get(5).Visible = false;
            this.deptSpread_Sheet1.Columns.Get(5).Width = 65F;
            this.deptSpread_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.SeaShell;
            this.deptSpread_Sheet1.Columns.Get(6).CellType = numberCellType7;
            this.deptSpread_Sheet1.Columns.Get(6).Label = "预扣库存";
            this.deptSpread_Sheet1.Columns.Get(6).Locked = false;
            this.deptSpread_Sheet1.Columns.Get(6).Width = 87F;
            this.deptSpread_Sheet1.Columns.Get(7).Label = "单位";
            this.deptSpread_Sheet1.Columns.Get(7).Width = 48F;
            this.deptSpread_Sheet1.Columns.Get(8).Label = "药品编码";
            this.deptSpread_Sheet1.Columns.Get(8).Visible = false;
            this.deptSpread_Sheet1.Columns.Get(9).Label = "拼音码";
            this.deptSpread_Sheet1.Columns.Get(9).Visible = false;
            this.deptSpread_Sheet1.Columns.Get(10).Label = "五笔码";
            this.deptSpread_Sheet1.Columns.Get(10).Visible = false;
            this.deptSpread_Sheet1.Columns.Get(11).Label = "自定义码";
            this.deptSpread_Sheet1.Columns.Get(11).Visible = false;
            this.deptSpread_Sheet1.Columns.Get(11).Width = 66F;
            this.deptSpread_Sheet1.DataAutoSizeColumns = false;
            this.deptSpread_Sheet1.DefaultStyle.Locked = true;
            this.deptSpread_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.deptSpread_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.deptSpread_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.deptSpread_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.deptSpread_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.deptSpread_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.deptSpread_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.deptSpread_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.deptSpread_Sheet1.SheetCornerStyle.Locked = false;
            this.deptSpread_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.deptSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.deptSpread.SetActiveViewport(1, 0);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.txtFilter);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(688, 40);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(77, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(144, 21);
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(6, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 1;
            this.neuLabel3.Text = "过 滤 框：";
            // 
            // ucDummyStockManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucDummyStockManager";
            this.Size = new System.Drawing.Size(696, 450);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientSpread1_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptSpread_Sheet1)).EndInit();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Common.Controls.baseTreeView tvPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread patientSpread1;
        private FarPoint.Win.Spread.SheetView patientSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread deptSpread;
        private FarPoint.Win.Spread.SheetView deptSpread_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
