namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucMedTechBooking <br></br>
	/// [功能描述: 医技预约UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-14'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	partial class ucMedTechBooking
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelLeftFill = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucChooseList1 = new Neusoft.FrameWork.WinForms.Controls.ucChooseList();
            this.neuPanelLeftTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabelF11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabelF12 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucQueryInpatientNo = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.neuTextBoxCardNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelCardNO = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanelRightTop1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabelQueryItem = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabelLine = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabelPatientInformation = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuDateTimePicker2 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuTextBoxPatientInformation = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuSpreadArrange = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpreadArrange_1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpreadArrange_2 = new FarPoint.Win.Spread.SheetView();
            this.neuSpreadArrange_3 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.neuSpreadBooking = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsCancle = new System.Windows.Forms.ToolStripMenuItem();
            this.neuSpreadBooking_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.neuRichTextBoxPatientNotice = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.neuRichTextBoxOperNotice = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.neuPanelLeft.SuspendLayout();
            this.neuPanelLeftFill.SuspendLayout();
            this.neuPanelLeftTop.SuspendLayout();
            this.neuPanelRightTop1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadBooking)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadBooking_Sheet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanelLeft
            // 
            this.neuPanelLeft.Controls.Add(this.neuPanelLeftFill);
            this.neuPanelLeft.Controls.Add(this.neuPanelLeftTop);
            this.neuPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.neuPanelLeft.Name = "neuPanelLeft";
            this.neuPanelLeft.Size = new System.Drawing.Size(238, 768);
            this.neuPanelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeft.TabIndex = 0;
            // 
            // neuPanelLeftFill
            // 
            this.neuPanelLeftFill.Controls.Add(this.ucChooseList1);
            this.neuPanelLeftFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelLeftFill.Location = new System.Drawing.Point(0, 36);
            this.neuPanelLeftFill.Name = "neuPanelLeftFill";
            this.neuPanelLeftFill.Size = new System.Drawing.Size(238, 732);
            this.neuPanelLeftFill.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeftFill.TabIndex = 1;
            // 
            // ucChooseList1
            // 
            this.ucChooseList1.Caption = "预约选择项目";
            this.ucChooseList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChooseList1.IsShowCloseButton = false;
            this.ucChooseList1.IsShowTreeView = true;
            this.ucChooseList1.Location = new System.Drawing.Point(0, 0);
            this.ucChooseList1.Name = "ucChooseList1";
            this.ucChooseList1.Size = new System.Drawing.Size(238, 732);
            this.ucChooseList1.TabIndex = 0;
            this.ucChooseList1.VisibleChanged += new System.EventHandler(this.ucChooseList1_VisibleChanged);
            // 
            // neuPanelLeftTop
            // 
            this.neuPanelLeftTop.Controls.Add(this.neuLabelF11);
            this.neuPanelLeftTop.Controls.Add(this.neuLabelF12);
            this.neuPanelLeftTop.Controls.Add(this.ucQueryInpatientNo);
            this.neuPanelLeftTop.Controls.Add(this.neuTextBoxCardNO);
            this.neuPanelLeftTop.Controls.Add(this.neuLabelCardNO);
            this.neuPanelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.neuPanelLeftTop.Name = "neuPanelLeftTop";
            this.neuPanelLeftTop.Size = new System.Drawing.Size(238, 36);
            this.neuPanelLeftTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeftTop.TabIndex = 0;
            // 
            // neuLabelF11
            // 
            this.neuLabelF11.AutoSize = true;
            this.neuLabelF11.Location = new System.Drawing.Point(209, 42);
            this.neuLabelF11.Name = "neuLabelF11";
            this.neuLabelF11.Size = new System.Drawing.Size(23, 12);
            this.neuLabelF11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelF11.TabIndex = 4;
            this.neuLabelF11.Text = "F11";
            // 
            // neuLabelF12
            // 
            this.neuLabelF12.AutoSize = true;
            this.neuLabelF12.Location = new System.Drawing.Point(209, 15);
            this.neuLabelF12.Name = "neuLabelF12";
            this.neuLabelF12.Size = new System.Drawing.Size(23, 12);
            this.neuLabelF12.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelF12.TabIndex = 3;
            this.neuLabelF12.Text = "F12";
            // 
            // ucQueryInpatientNo
            // 
            this.ucQueryInpatientNo.InputType = 0;
            this.ucQueryInpatientNo.Location = new System.Drawing.Point(9, 34);
            this.ucQueryInpatientNo.Name = "ucQueryInpatientNo";
            this.ucQueryInpatientNo.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo.Size = new System.Drawing.Size(198, 27);
            this.ucQueryInpatientNo.TabIndex = 2;
            this.ucQueryInpatientNo.Enter += new System.EventHandler(this.ucQueryInpatientNo_Enter);
            this.ucQueryInpatientNo.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo_myEvent);
            // 
            // neuTextBoxCardNO
            // 
            this.neuTextBoxCardNO.IsEnter2Tab = false;
            this.neuTextBoxCardNO.Location = new System.Drawing.Point(70, 11);
            this.neuTextBoxCardNO.Name = "neuTextBoxCardNO";
            this.neuTextBoxCardNO.Size = new System.Drawing.Size(137, 21);
            this.neuTextBoxCardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBoxCardNO.TabIndex = 1;
            this.neuTextBoxCardNO.Enter += new System.EventHandler(this.neuTextBoxCardNO_Enter);
            this.neuTextBoxCardNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuTextBoxCardNO_KeyDown);
            // 
            // neuLabelCardNO
            // 
            this.neuLabelCardNO.AutoSize = true;
            this.neuLabelCardNO.Location = new System.Drawing.Point(13, 14);
            this.neuLabelCardNO.Name = "neuLabelCardNO";
            this.neuLabelCardNO.Size = new System.Drawing.Size(47, 12);
            this.neuLabelCardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelCardNO.TabIndex = 0;
            this.neuLabelCardNO.Text = "门诊号:";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(238, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(5, 768);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanelRightTop1
            // 
            this.neuPanelRightTop1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuPanelRightTop1.Controls.Add(this.neuLabelQueryItem);
            this.neuPanelRightTop1.Controls.Add(this.neuLabelLine);
            this.neuPanelRightTop1.Controls.Add(this.neuLabelPatientInformation);
            this.neuPanelRightTop1.Controls.Add(this.neuDateTimePicker2);
            this.neuPanelRightTop1.Controls.Add(this.neuDateTimePicker1);
            this.neuPanelRightTop1.Controls.Add(this.neuTextBoxPatientInformation);
            this.neuPanelRightTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelRightTop1.Location = new System.Drawing.Point(243, 0);
            this.neuPanelRightTop1.Name = "neuPanelRightTop1";
            this.neuPanelRightTop1.Size = new System.Drawing.Size(781, 54);
            this.neuPanelRightTop1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelRightTop1.TabIndex = 3;
            // 
            // neuLabelQueryItem
            // 
            this.neuLabelQueryItem.AutoSize = true;
            this.neuLabelQueryItem.Location = new System.Drawing.Point(5, 32);
            this.neuLabelQueryItem.Name = "neuLabelQueryItem";
            this.neuLabelQueryItem.Size = new System.Drawing.Size(101, 12);
            this.neuLabelQueryItem.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelQueryItem.TabIndex = 5;
            this.neuLabelQueryItem.Text = "预约排班时间区间";
            // 
            // neuLabelLine
            // 
            this.neuLabelLine.AutoSize = true;
            this.neuLabelLine.Location = new System.Drawing.Point(282, 32);
            this.neuLabelLine.Name = "neuLabelLine";
            this.neuLabelLine.Size = new System.Drawing.Size(29, 12);
            this.neuLabelLine.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelLine.TabIndex = 4;
            this.neuLabelLine.Text = "——";
            // 
            // neuLabelPatientInformation
            // 
            this.neuLabelPatientInformation.AutoSize = true;
            this.neuLabelPatientInformation.Location = new System.Drawing.Point(5, 8);
            this.neuLabelPatientInformation.Name = "neuLabelPatientInformation";
            this.neuLabelPatientInformation.Size = new System.Drawing.Size(77, 12);
            this.neuLabelPatientInformation.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelPatientInformation.TabIndex = 3;
            this.neuLabelPatientInformation.Text = "患者基本信息";
            // 
            // neuDateTimePicker2
            // 
            this.neuDateTimePicker2.IsEnter2Tab = false;
            this.neuDateTimePicker2.Location = new System.Drawing.Point(317, 28);
            this.neuDateTimePicker2.Name = "neuDateTimePicker2";
            this.neuDateTimePicker2.Size = new System.Drawing.Size(169, 21);
            this.neuDateTimePicker2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker2.TabIndex = 2;
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.IsEnter2Tab = false;
            this.neuDateTimePicker1.Location = new System.Drawing.Point(108, 28);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(169, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 1;
            // 
            // neuTextBoxPatientInformation
            // 
            this.neuTextBoxPatientInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuTextBoxPatientInformation.Enabled = false;
            this.neuTextBoxPatientInformation.IsEnter2Tab = false;
            this.neuTextBoxPatientInformation.Location = new System.Drawing.Point(108, 4);
            this.neuTextBoxPatientInformation.Name = "neuTextBoxPatientInformation";
            this.neuTextBoxPatientInformation.ReadOnly = true;
            this.neuTextBoxPatientInformation.Size = new System.Drawing.Size(679, 21);
            this.neuTextBoxPatientInformation.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBoxPatientInformation.TabIndex = 0;
            // 
            // neuSpreadArrange
            // 
            this.neuSpreadArrange.About = "2.5.2007.2005";
            this.neuSpreadArrange.AccessibleDescription = "neuSpreadArrange, 排班信息";
            this.neuSpreadArrange.AllowDrop = true;
            this.neuSpreadArrange.BackColor = System.Drawing.Color.White;
            this.neuSpreadArrange.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSpreadArrange.EditModePermanent = true;
            this.neuSpreadArrange.EditModeReplace = true;
            this.neuSpreadArrange.FileName = "";
            this.neuSpreadArrange.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadArrange.IsAutoSaveGridStatus = false;
            this.neuSpreadArrange.IsCanCustomConfigColumn = false;
            this.neuSpreadArrange.Location = new System.Drawing.Point(243, 54);
            this.neuSpreadArrange.Name = "neuSpreadArrange";
            this.neuSpreadArrange.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpreadArrange_1,
            this.neuSpreadArrange_2,
            this.neuSpreadArrange_3});
            this.neuSpreadArrange.Size = new System.Drawing.Size(781, 254);
            this.neuSpreadArrange.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpreadArrange.TabIndex = 4;
            this.neuSpreadArrange.TabStripRatio = 0.692132269099202;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpreadArrange.TextTipAppearance = tipAppearance1;
            this.neuSpreadArrange.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadArrange.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpreadArrange_CellDoubleClick);
            this.neuSpreadArrange.DragEnter += new System.Windows.Forms.DragEventHandler(this.neuSpreadArrange_DragEnter);
            this.neuSpreadArrange.DragDrop += new System.Windows.Forms.DragEventHandler(this.neuSpreadArrange_DragDrop);
            this.neuSpreadArrange.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpreadArrange_CellClick);
            // 
            // neuSpreadArrange_1
            // 
            this.neuSpreadArrange_1.Reset();
            this.neuSpreadArrange_1.SheetName = "排班信息";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadArrange_1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadArrange_1.RowCount = 0;
            this.neuSpreadArrange_1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.neuSpreadArrange_1.Columns.Get(0).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(1).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(2).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(3).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(4).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(5).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(6).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(7).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(8).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(9).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(10).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(11).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(12).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(13).Locked = false;
            this.neuSpreadArrange_1.Columns.Get(14).Locked = false;
            this.neuSpreadArrange_1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.neuSpreadArrange_1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadArrange_1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadArrange_1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadArrange.SetActiveViewport(1, 0);
            // 
            // neuSpreadArrange_2
            // 
            this.neuSpreadArrange_2.Reset();
            this.neuSpreadArrange_2.SheetName = "已排班病人";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadArrange_2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadArrange_2.ColumnCount = 10;
            this.neuSpreadArrange_2.RowCount = 0;
            this.neuSpreadArrange_2.ColumnHeader.Cells.Get(0, 8).Value = "时间段";
            this.neuSpreadArrange_2.ColumnHeader.Cells.Get(0, 9).Value = "执行设备";
            this.neuSpreadArrange_2.Columns.Get(0).CellType = textCellType1;
            this.neuSpreadArrange_2.Columns.Get(0).Width = 73F;
            this.neuSpreadArrange_2.Columns.Get(2).Width = 182F;
            this.neuSpreadArrange_2.Columns.Get(5).CellType = textCellType2;
            this.neuSpreadArrange_2.Columns.Get(8).Label = "时间段";
            this.neuSpreadArrange_2.Columns.Get(8).Width = 110F;
            this.neuSpreadArrange_2.Columns.Get(9).Label = "执行设备";
            this.neuSpreadArrange_2.Columns.Get(9).Width = 65F;
            this.neuSpreadArrange_2.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.neuSpreadArrange_2.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadArrange_2.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadArrange_2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadArrange.SetActiveViewport(1, 1, 0);
            // 
            // neuSpreadArrange_3
            // 
            this.neuSpreadArrange_3.Reset();
            this.neuSpreadArrange_3.SheetName = "病人收费信息";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadArrange_3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadArrange_3.ColumnCount = 6;
            this.neuSpreadArrange_3.RowCount = 0;
            this.neuSpreadArrange_3.Columns.Get(0).CellType = textCellType3;
            this.neuSpreadArrange_3.Columns.Get(2).Width = 229F;
            this.neuSpreadArrange_3.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.neuSpreadArrange_3.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadArrange_3.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadArrange_3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadArrange.SetActiveViewport(2, 1, 0);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(243, 308);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(781, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.neuSpreadBooking);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(243, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 164);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已预约项目";
            // 
            // neuSpreadBooking
            // 
            this.neuSpreadBooking.About = "2.5.2007.2005";
            this.neuSpreadBooking.AccessibleDescription = "neuSpreadBooking, Sheet1";
            this.neuSpreadBooking.BackColor = System.Drawing.Color.White;
            this.neuSpreadBooking.ContextMenuStrip = this.contextMenuStrip1;
            this.neuSpreadBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpreadBooking.FileName = "";
            this.neuSpreadBooking.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadBooking.IsAutoSaveGridStatus = false;
            this.neuSpreadBooking.IsCanCustomConfigColumn = false;
            this.neuSpreadBooking.Location = new System.Drawing.Point(3, 17);
            this.neuSpreadBooking.Name = "neuSpreadBooking";
            this.neuSpreadBooking.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpreadBooking_Sheet1});
            this.neuSpreadBooking.Size = new System.Drawing.Size(775, 144);
            this.neuSpreadBooking.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpreadBooking.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpreadBooking.TextTipAppearance = tipAppearance2;
            this.neuSpreadBooking.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCancle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tsCancle
            // 
            this.tsCancle.Name = "tsCancle";
            this.tsCancle.Size = new System.Drawing.Size(118, 22);
            this.tsCancle.Text = "取消预约";
            // 
            // neuSpreadBooking_Sheet1
            // 
            this.neuSpreadBooking_Sheet1.Reset();
            this.neuSpreadBooking_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadBooking_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadBooking_Sheet1.ColumnCount = 9;
            this.neuSpreadBooking_Sheet1.RowCount = 0;
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选中";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "项目名称";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "预约时间";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "时间段";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "执行地点";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "序号";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "注意事项";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "预约单号";
            this.neuSpreadBooking_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "执行设备";
            this.neuSpreadBooking_Sheet1.Columns.Get(0).Label = "选中";
            this.neuSpreadBooking_Sheet1.Columns.Get(0).Width = 31F;
            this.neuSpreadBooking_Sheet1.Columns.Get(1).Label = "项目名称";
            this.neuSpreadBooking_Sheet1.Columns.Get(1).Width = 218F;
            this.neuSpreadBooking_Sheet1.Columns.Get(2).Label = "预约时间";
            this.neuSpreadBooking_Sheet1.Columns.Get(2).Width = 85F;
            this.neuSpreadBooking_Sheet1.Columns.Get(3).Label = "时间段";
            this.neuSpreadBooking_Sheet1.Columns.Get(3).Width = 149F;
            this.neuSpreadBooking_Sheet1.Columns.Get(4).Label = "执行地点";
            this.neuSpreadBooking_Sheet1.Columns.Get(4).Width = 80F;
            this.neuSpreadBooking_Sheet1.Columns.Get(5).Label = "序号";
            this.neuSpreadBooking_Sheet1.Columns.Get(5).Width = 31F;
            this.neuSpreadBooking_Sheet1.Columns.Get(6).Label = "注意事项";
            this.neuSpreadBooking_Sheet1.Columns.Get(6).Width = 74F;
            this.neuSpreadBooking_Sheet1.Columns.Get(7).Label = "预约单号";
            this.neuSpreadBooking_Sheet1.Columns.Get(7).Width = 90F;
            this.neuSpreadBooking_Sheet1.Columns.Get(8).Label = "执行设备";
            this.neuSpreadBooking_Sheet1.Columns.Get(8).Width = 85F;
            this.neuSpreadBooking_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpreadBooking_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadBooking_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadBooking_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadBooking.SetActiveViewport(1, 0);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(243, 475);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(781, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.neuRichTextBoxPatientNotice);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(243, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 290);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "患者注意事项";
            // 
            // neuRichTextBoxPatientNotice
            // 
            this.neuRichTextBoxPatientNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuRichTextBoxPatientNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuRichTextBoxPatientNotice.Location = new System.Drawing.Point(3, 17);
            this.neuRichTextBoxPatientNotice.Name = "neuRichTextBoxPatientNotice";
            this.neuRichTextBoxPatientNotice.ReadOnly = true;
            this.neuRichTextBoxPatientNotice.Size = new System.Drawing.Size(775, 270);
            this.neuRichTextBoxPatientNotice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuRichTextBoxPatientNotice.TabIndex = 1;
            this.neuRichTextBoxPatientNotice.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.neuRichTextBoxOperNotice);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(831, 478);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 290);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作员注意事项";
            this.groupBox3.Visible = false;
            // 
            // neuRichTextBoxOperNotice
            // 
            this.neuRichTextBoxOperNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuRichTextBoxOperNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuRichTextBoxOperNotice.Location = new System.Drawing.Point(3, 17);
            this.neuRichTextBoxOperNotice.Name = "neuRichTextBoxOperNotice";
            this.neuRichTextBoxOperNotice.Size = new System.Drawing.Size(187, 270);
            this.neuRichTextBoxOperNotice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuRichTextBoxOperNotice.TabIndex = 1;
            this.neuRichTextBoxOperNotice.Text = "";
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(243, 478);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 290);
            this.splitter3.TabIndex = 10;
            this.splitter3.TabStop = false;
            // 
            // ucMedTechBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.neuSpreadArrange);
            this.Controls.Add(this.neuPanelRightTop1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanelLeft);
            this.Name = "ucMedTechBooking";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Resize += new System.EventHandler(this.ucMedTechBooking_Resize);
            this.neuPanelLeft.ResumeLayout(false);
            this.neuPanelLeftFill.ResumeLayout(false);
            this.neuPanelLeftTop.ResumeLayout(false);
            this.neuPanelLeftTop.PerformLayout();
            this.neuPanelRightTop1.ResumeLayout(false);
            this.neuPanelRightTop1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadArrange_3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadBooking)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadBooking_Sheet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// 左侧总Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeft;
		/// <summary>
		/// 分割条
		/// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
		/// <summary>
		/// 左侧上部Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeftTop;
		/// <summary>
		/// 左侧填充Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeftFill;
		/// <summary>
		/// 门诊号输入框
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxCardNO;
		/// <summary>
		/// 门诊号标签
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelCardNO;
		/// <summary>
		/// 住院号控件
		/// </summary>
		private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo;
		/// <summary>
		/// 预约项目控件
		/// </summary>
        private Neusoft.FrameWork.WinForms.Controls.ucChooseList ucChooseList1;
		/// <summary>
		/// 门诊号快捷键标签
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelF12;
		/// <summary>
		/// 住院号快捷键标签
		/// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelF11;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelRightTop1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelQueryItem;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelLine;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelPatientInformation;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxPatientInformation;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpreadArrange;
        private FarPoint.Win.Spread.SheetView neuSpreadArrange_1;
        private FarPoint.Win.Spread.SheetView neuSpreadArrange_2;
        private FarPoint.Win.Spread.SheetView neuSpreadArrange_3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpreadBooking;
        private FarPoint.Win.Spread.SheetView neuSpreadBooking_Sheet1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox neuRichTextBoxPatientNotice;
        private System.Windows.Forms.GroupBox groupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox neuRichTextBoxOperNotice;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsCancle;
	}
}
