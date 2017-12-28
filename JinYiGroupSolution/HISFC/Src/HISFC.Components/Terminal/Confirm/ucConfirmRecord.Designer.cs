namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// ucConfirmRecord <br></br>
	/// [功能描述: 执行情况查询]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	partial class ucConfirmRecord
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
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType1 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType2 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConfirmRecord));
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType3 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType4 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            this.neuPanelPatient = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuButtonOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuTextBoxSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelSex = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBoxName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBoxCardNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelCardNO = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanelItem = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelItemGrid = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpreadItem = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpreadItem_SheetItem = new FarPoint.Win.Spread.SheetView();
            this.neuPanelItemTitle = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabelItemTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanelConfirm = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelConfirmGrid = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpreadItemDetail = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.取消确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuSpreadItemDetail_SheetItemDetail = new FarPoint.Win.Spread.SheetView();
            this.neuPanelConfirmTitle = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabelConfirmTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanelPatient.SuspendLayout();
            this.neuPanelItem.SuspendLayout();
            this.neuPanelItemGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItem_SheetItem)).BeginInit();
            this.neuPanelItemTitle.SuspendLayout();
            this.neuPanelConfirm.SuspendLayout();
            this.neuPanelConfirmGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItemDetail)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItemDetail_SheetItemDetail)).BeginInit();
            this.neuPanelConfirmTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanelPatient
            // 
            this.neuPanelPatient.Controls.Add(this.neuButtonOK);
            this.neuPanelPatient.Controls.Add(this.neuTextBoxSex);
            this.neuPanelPatient.Controls.Add(this.neuLabelSex);
            this.neuPanelPatient.Controls.Add(this.neuTextBoxName);
            this.neuPanelPatient.Controls.Add(this.neuLabelName);
            this.neuPanelPatient.Controls.Add(this.neuTextBoxCardNO);
            this.neuPanelPatient.Controls.Add(this.neuLabelCardNO);
            this.neuPanelPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelPatient.Location = new System.Drawing.Point(0, 0);
            this.neuPanelPatient.Name = "neuPanelPatient";
            this.neuPanelPatient.Size = new System.Drawing.Size(643, 46);
            this.neuPanelPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelPatient.TabIndex = 0;
            // 
            // neuButtonOK
            // 
            this.neuButtonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButtonOK.Location = new System.Drawing.Point(535, 11);
            this.neuButtonOK.Name = "neuButtonOK";
            this.neuButtonOK.Size = new System.Drawing.Size(75, 23);
            this.neuButtonOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButtonOK.TabIndex = 6;
            this.neuButtonOK.Text = "确定";
            this.neuButtonOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButtonOK.UseVisualStyleBackColor = true;
            this.neuButtonOK.Visible = false;
            this.neuButtonOK.Click += new System.EventHandler(this.neuButtonOK_Click);
            // 
            // neuTextBoxSex
            // 
            this.neuTextBoxSex.Enabled = false;
            this.neuTextBoxSex.IsEnter2Tab = false;
            this.neuTextBoxSex.Location = new System.Drawing.Point(415, 12);
            this.neuTextBoxSex.Name = "neuTextBoxSex";
            this.neuTextBoxSex.ReadOnly = true;
            this.neuTextBoxSex.Size = new System.Drawing.Size(100, 21);
            this.neuTextBoxSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBoxSex.TabIndex = 5;
            // 
            // neuLabelSex
            // 
            this.neuLabelSex.AutoSize = true;
            this.neuLabelSex.Location = new System.Drawing.Point(360, 17);
            this.neuLabelSex.Name = "neuLabelSex";
            this.neuLabelSex.Size = new System.Drawing.Size(53, 12);
            this.neuLabelSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelSex.TabIndex = 4;
            this.neuLabelSex.Text = "患者性别";
            // 
            // neuTextBoxName
            // 
            this.neuTextBoxName.Enabled = false;
            this.neuTextBoxName.IsEnter2Tab = false;
            this.neuTextBoxName.Location = new System.Drawing.Point(240, 13);
            this.neuTextBoxName.Name = "neuTextBoxName";
            this.neuTextBoxName.ReadOnly = true;
            this.neuTextBoxName.Size = new System.Drawing.Size(100, 21);
            this.neuTextBoxName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBoxName.TabIndex = 3;
            // 
            // neuLabelName
            // 
            this.neuLabelName.AutoSize = true;
            this.neuLabelName.Location = new System.Drawing.Point(186, 17);
            this.neuLabelName.Name = "neuLabelName";
            this.neuLabelName.Size = new System.Drawing.Size(53, 12);
            this.neuLabelName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelName.TabIndex = 2;
            this.neuLabelName.Text = "患者姓名";
            // 
            // neuTextBoxCardNO
            // 
            this.neuTextBoxCardNO.IsEnter2Tab = false;
            this.neuTextBoxCardNO.Location = new System.Drawing.Point(66, 12);
            this.neuTextBoxCardNO.Name = "neuTextBoxCardNO";
            this.neuTextBoxCardNO.Size = new System.Drawing.Size(100, 21);
            this.neuTextBoxCardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBoxCardNO.TabIndex = 1;
            this.neuTextBoxCardNO.Enter += new System.EventHandler(this.neuTextBoxCardNO_Enter);
            this.neuTextBoxCardNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuTextBoxCardNO_KeyDown);
            // 
            // neuLabelCardNO
            // 
            this.neuLabelCardNO.AutoSize = true;
            this.neuLabelCardNO.Location = new System.Drawing.Point(12, 17);
            this.neuLabelCardNO.Name = "neuLabelCardNO";
            this.neuLabelCardNO.Size = new System.Drawing.Size(53, 12);
            this.neuLabelCardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelCardNO.TabIndex = 0;
            this.neuLabelCardNO.Text = "病 历 号";
            // 
            // neuPanelItem
            // 
            this.neuPanelItem.Controls.Add(this.neuPanelItemGrid);
            this.neuPanelItem.Controls.Add(this.neuPanelItemTitle);
            this.neuPanelItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelItem.Location = new System.Drawing.Point(0, 46);
            this.neuPanelItem.Name = "neuPanelItem";
            this.neuPanelItem.Size = new System.Drawing.Size(643, 217);
            this.neuPanelItem.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelItem.TabIndex = 2;
            // 
            // neuPanelItemGrid
            // 
            this.neuPanelItemGrid.Controls.Add(this.neuSpreadItem);
            this.neuPanelItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelItemGrid.Location = new System.Drawing.Point(0, 23);
            this.neuPanelItemGrid.Name = "neuPanelItemGrid";
            this.neuPanelItemGrid.Size = new System.Drawing.Size(643, 194);
            this.neuPanelItemGrid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelItemGrid.TabIndex = 1;
            // 
            // neuSpreadItem
            // 
            this.neuSpreadItem.About = "2.5.2007.2005";
            this.neuSpreadItem.AccessibleDescription = "neuSpreadItem, Sheet1, Row 0, Column 0, ";
            this.neuSpreadItem.BackColor = System.Drawing.Color.White;
            this.neuSpreadItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpreadItem.FileName = "";
            this.neuSpreadItem.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadItem.IsAutoSaveGridStatus = false;
            this.neuSpreadItem.IsCanCustomConfigColumn = false;
            this.neuSpreadItem.Location = new System.Drawing.Point(0, 0);
            this.neuSpreadItem.Name = "neuSpreadItem";
            this.neuSpreadItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpreadItem_SheetItem});
            this.neuSpreadItem.Size = new System.Drawing.Size(643, 194);
            this.neuSpreadItem.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpreadItem.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpreadItem.TextTipAppearance = tipAppearance1;
            this.neuSpreadItem.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadItem.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpreadItem_CellDoubleClick);
            // 
            // neuSpreadItem_SheetItem
            // 
            this.neuSpreadItem_SheetItem.Reset();
            this.neuSpreadItem_SheetItem.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadItem_SheetItem.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadItem_SheetItem.ColumnCount = 6;
            this.neuSpreadItem_SheetItem.RowCount = 0;
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 0).Value = "状态";
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 1).Value = "项目名称";
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 2).Value = "开立数量";
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 3).Value = "剩余数量";
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 4).Value = "开立医生";
            this.neuSpreadItem_SheetItem.ColumnHeader.Cells.Get(0, 5).Value = "开立科室";
            this.neuSpreadItem_SheetItem.Columns.Get(0).CellType = textCellType1;
            this.neuSpreadItem_SheetItem.Columns.Get(0).Label = "状态";
            this.neuSpreadItem_SheetItem.Columns.Get(0).Width = 80F;
            this.neuSpreadItem_SheetItem.Columns.Get(1).Label = "项目名称";
            this.neuSpreadItem_SheetItem.Columns.Get(1).Width = 200F;
            this.neuSpreadItem_SheetItem.Columns.Get(2).CellType = numCellType1;
            this.neuSpreadItem_SheetItem.Columns.Get(2).Label = "开立数量";
            this.neuSpreadItem_SheetItem.Columns.Get(2).Width = 80F;
            this.neuSpreadItem_SheetItem.Columns.Get(3).CellType = numCellType2;
            this.neuSpreadItem_SheetItem.Columns.Get(3).Label = "剩余数量";
            this.neuSpreadItem_SheetItem.Columns.Get(3).Width = 80F;
            this.neuSpreadItem_SheetItem.Columns.Get(4).Label = "开立医生";
            this.neuSpreadItem_SheetItem.Columns.Get(4).Width = 80F;
            this.neuSpreadItem_SheetItem.Columns.Get(5).Label = "开立科室";
            this.neuSpreadItem_SheetItem.Columns.Get(5).Width = 120F;
            this.neuSpreadItem_SheetItem.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.neuSpreadItem_SheetItem.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadItem_SheetItem.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadItem_SheetItem.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.neuSpreadItem_SheetItem.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpreadItem_SheetItem.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadItem.SetActiveViewport(1, 0);
            // 
            // neuPanelItemTitle
            // 
            this.neuPanelItemTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuPanelItemTitle.Controls.Add(this.neuLabelItemTitle);
            this.neuPanelItemTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelItemTitle.Location = new System.Drawing.Point(0, 0);
            this.neuPanelItemTitle.Name = "neuPanelItemTitle";
            this.neuPanelItemTitle.Size = new System.Drawing.Size(643, 23);
            this.neuPanelItemTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelItemTitle.TabIndex = 0;
            // 
            // neuLabelItemTitle
            // 
            this.neuLabelItemTitle.AutoSize = true;
            this.neuLabelItemTitle.Location = new System.Drawing.Point(9, 5);
            this.neuLabelItemTitle.Name = "neuLabelItemTitle";
            this.neuLabelItemTitle.Size = new System.Drawing.Size(137, 12);
            this.neuLabelItemTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelItemTitle.TabIndex = 0;
            this.neuLabelItemTitle.Text = "医生开立的收费项目明细";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter1.Location = new System.Drawing.Point(0, 263);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(643, 5);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 3;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanelConfirm
            // 
            this.neuPanelConfirm.Controls.Add(this.neuPanelConfirmGrid);
            this.neuPanelConfirm.Controls.Add(this.neuPanelConfirmTitle);
            this.neuPanelConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelConfirm.Location = new System.Drawing.Point(0, 268);
            this.neuPanelConfirm.Name = "neuPanelConfirm";
            this.neuPanelConfirm.Size = new System.Drawing.Size(643, 206);
            this.neuPanelConfirm.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelConfirm.TabIndex = 4;
            // 
            // neuPanelConfirmGrid
            // 
            this.neuPanelConfirmGrid.Controls.Add(this.neuSpreadItemDetail);
            this.neuPanelConfirmGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelConfirmGrid.Location = new System.Drawing.Point(0, 23);
            this.neuPanelConfirmGrid.Name = "neuPanelConfirmGrid";
            this.neuPanelConfirmGrid.Size = new System.Drawing.Size(643, 183);
            this.neuPanelConfirmGrid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelConfirmGrid.TabIndex = 1;
            // 
            // neuSpreadItemDetail
            // 
            this.neuSpreadItemDetail.About = "2.5.2007.2005";
            this.neuSpreadItemDetail.AccessibleDescription = "neuSpreadItemDetail, Sheet1, Row 0, Column 0, ";
            this.neuSpreadItemDetail.BackColor = System.Drawing.Color.White;
            this.neuSpreadItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpreadItemDetail.FileName = "";
            this.neuSpreadItemDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpreadItemDetail.IsAutoSaveGridStatus = false;
            this.neuSpreadItemDetail.IsCanCustomConfigColumn = false;
            this.neuSpreadItemDetail.Location = new System.Drawing.Point(0, 0);
            this.neuSpreadItemDetail.Name = "neuSpreadItemDetail";
            this.neuSpreadItemDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpreadItemDetail_SheetItemDetail});
            this.neuSpreadItemDetail.Size = new System.Drawing.Size(643, 183);
            this.neuSpreadItemDetail.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpreadItemDetail.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpreadItemDetail.TextTipAppearance = tipAppearance2;
            this.neuSpreadItemDetail.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消确认ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // 取消确认ToolStripMenuItem
            // 
            this.取消确认ToolStripMenuItem.Name = "取消确认ToolStripMenuItem";
            this.取消确认ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.取消确认ToolStripMenuItem.Text = "取消确认";
            this.取消确认ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // neuSpreadItemDetail_SheetItemDetail
            // 
            this.neuSpreadItemDetail_SheetItemDetail.Reset();
            this.neuSpreadItemDetail_SheetItemDetail.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpreadItemDetail_SheetItemDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpreadItemDetail_SheetItemDetail.ColumnCount = 6;
            this.neuSpreadItemDetail_SheetItemDetail.RowCount = 0;
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 0).Value = "状态";
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 1).Value = "执行科室名称";
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 2).Value = "执行时间";
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 3).Value = "执行人";
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 4).Value = "执行数量";
            this.neuSpreadItemDetail_SheetItemDetail.ColumnHeader.Cells.Get(0, 5).Value = "剩余数量";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(0).Label = "状态";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(0).Width = 80F;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(1).CellType = textCellType2;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(1).Label = "执行科室名称";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(1).Width = 150F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 3, 10, 8, 53, 23, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 3, 10, 8, 53, 23, 0);
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(2).CellType = dateTimeCellType1;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(2).Label = "执行时间";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(2).Width = 120F;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(3).CellType = textCellType3;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(3).Label = "执行人";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(3).Width = 80F;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(4).CellType = numCellType3;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(4).Label = "执行数量";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(4).Width = 80F;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(5).CellType = numCellType4;
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(5).Label = "剩余数量";
            this.neuSpreadItemDetail_SheetItemDetail.Columns.Get(5).Width = 80F;
            this.neuSpreadItemDetail_SheetItemDetail.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.neuSpreadItemDetail_SheetItemDetail.RowHeader.Columns.Default.Resizable = false;
            this.neuSpreadItemDetail_SheetItemDetail.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpreadItemDetail_SheetItemDetail.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.neuSpreadItemDetail_SheetItemDetail.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpreadItemDetail_SheetItemDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpreadItemDetail.SetActiveViewport(1, 0);
            // 
            // neuPanelConfirmTitle
            // 
            this.neuPanelConfirmTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuPanelConfirmTitle.Controls.Add(this.neuLabelConfirmTitle);
            this.neuPanelConfirmTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelConfirmTitle.Location = new System.Drawing.Point(0, 0);
            this.neuPanelConfirmTitle.Name = "neuPanelConfirmTitle";
            this.neuPanelConfirmTitle.Size = new System.Drawing.Size(643, 23);
            this.neuPanelConfirmTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelConfirmTitle.TabIndex = 0;
            // 
            // neuLabelConfirmTitle
            // 
            this.neuLabelConfirmTitle.AutoSize = true;
            this.neuLabelConfirmTitle.Location = new System.Drawing.Point(9, 6);
            this.neuLabelConfirmTitle.Name = "neuLabelConfirmTitle";
            this.neuLabelConfirmTitle.Size = new System.Drawing.Size(173, 12);
            this.neuLabelConfirmTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelConfirmTitle.TabIndex = 0;
            this.neuLabelConfirmTitle.Text = "开立的收费项目对应的执行明细";
            // 
            // ucConfirmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanelConfirm);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanelItem);
            this.Controls.Add(this.neuPanelPatient);
            this.Name = "ucConfirmRecord";
            this.Size = new System.Drawing.Size(643, 474);
            this.neuPanelPatient.ResumeLayout(false);
            this.neuPanelPatient.PerformLayout();
            this.neuPanelItem.ResumeLayout(false);
            this.neuPanelItemGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItem_SheetItem)).EndInit();
            this.neuPanelItemTitle.ResumeLayout(false);
            this.neuPanelItemTitle.PerformLayout();
            this.neuPanelConfirm.ResumeLayout(false);
            this.neuPanelConfirmGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItemDetail)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpreadItemDetail_SheetItemDetail)).EndInit();
            this.neuPanelConfirmTitle.ResumeLayout(false);
            this.neuPanelConfirmTitle.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// 患者信息Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelPatient;
		/// <summary>
		/// 开立项目Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelItem;
		/// <summary>
		/// 病历号
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelCardNO;
		/// <summary>
		/// 病历号
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxCardNO;
		/// <summary>
		/// 姓名
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelName;
		/// <summary>
		/// 姓名
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxName;
		/// <summary>
		/// 性别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelSex;
		/// <summary>
		/// 性别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxSex;
		/// <summary>
		/// 确定按钮
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButtonOK;
		/// <summary>
		/// 分割条
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
		/// <summary>
		/// 确认记录Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelConfirm;
		/// <summary>
		/// 开立项目标题Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelItemTitle;
		/// <summary>
		/// 开立项目标题
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelItemTitle;
		/// <summary>
		/// 确认明细标题Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelConfirmTitle;
		/// <summary>
		/// 确认明细标题
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelConfirmTitle;
		/// <summary>
		/// 开立项目表格Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelItemGrid;
		/// <summary>
		/// 确认明细表格Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelConfirmGrid;
		/// <summary>
		/// 开立项目表格
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpreadItem;
		/// <summary>
		/// 开立项目表格
		/// </summary>
		private FarPoint.Win.Spread.SheetView neuSpreadItem_SheetItem;
		/// <summary>
		/// 执行明细表格
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpreadItemDetail;
		/// <summary>
		/// 执行明细表格
		/// </summary>
		private FarPoint.Win.Spread.SheetView neuSpreadItemDetail_SheetItemDetail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 取消确认ToolStripMenuItem;
	}
}
