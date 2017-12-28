namespace Neusoft.HISFC.Components.HealthRecord.Visit
{
    partial class ucVisitSearch
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.pnlcase = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.pnlselect = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.gbxSelect = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.chkCircs = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkResult = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkLinkType = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkState = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbLinkType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.dtpEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.lblTimeTo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.cmbCircs = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbResult = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbState = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.tvIcdList = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.pnlInfo = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.gbxLinkWay = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.fpLinkWay = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpLinkWay_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSplitter3 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.gbxVisitInfo = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.fpVisitInfo = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpVisitInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.chkTime = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.pnlcase.SuspendLayout();
            this.pnlselect.SuspendLayout();
            this.gbxSelect.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.gbxLinkWay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpLinkWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpLinkWay_Sheet1)).BeginInit();
            this.gbxVisitInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpVisitInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpVisitInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlcase
            // 
            this.pnlcase.BackColor = System.Drawing.Color.White;
            this.pnlcase.Controls.Add(this.pnlselect);
            this.pnlcase.Controls.Add(this.neuSplitter2);
            this.pnlcase.Controls.Add(this.tvIcdList);
            this.pnlcase.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlcase.Location = new System.Drawing.Point(0, 0);
            this.pnlcase.Name = "pnlcase";
            this.pnlcase.Size = new System.Drawing.Size(212, 667);
            this.pnlcase.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlcase.TabIndex = 0;
            // 
            // pnlselect
            // 
            this.pnlselect.BackColor = System.Drawing.SystemColors.Control;
            this.pnlselect.Controls.Add(this.gbxSelect);
            this.pnlselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlselect.Location = new System.Drawing.Point(0, 255);
            this.pnlselect.Name = "pnlselect";
            this.pnlselect.Size = new System.Drawing.Size(212, 412);
            this.pnlselect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlselect.TabIndex = 2;
            // 
            // gbxSelect
            // 
            this.gbxSelect.Controls.Add(this.chkTime);
            this.gbxSelect.Controls.Add(this.chkCircs);
            this.gbxSelect.Controls.Add(this.chkResult);
            this.gbxSelect.Controls.Add(this.chkLinkType);
            this.gbxSelect.Controls.Add(this.chkState);
            this.gbxSelect.Controls.Add(this.cmbLinkType);
            this.gbxSelect.Controls.Add(this.btnQuery);
            this.gbxSelect.Controls.Add(this.dtpEnd);
            this.gbxSelect.Controls.Add(this.lblTimeTo);
            this.gbxSelect.Controls.Add(this.dtpBegin);
            this.gbxSelect.Controls.Add(this.cmbCircs);
            this.gbxSelect.Controls.Add(this.cmbResult);
            this.gbxSelect.Controls.Add(this.cmbState);
            this.gbxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSelect.Location = new System.Drawing.Point(0, 0);
            this.gbxSelect.Name = "gbxSelect";
            this.gbxSelect.Size = new System.Drawing.Size(212, 412);
            this.gbxSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbxSelect.TabIndex = 0;
            this.gbxSelect.TabStop = false;
            this.gbxSelect.Text = "查询条件";
            // 
            // chkCircs
            // 
            this.chkCircs.AutoSize = true;
            this.chkCircs.Location = new System.Drawing.Point(19, 141);
            this.chkCircs.Name = "chkCircs";
            this.chkCircs.Size = new System.Drawing.Size(72, 16);
            this.chkCircs.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkCircs.TabIndex = 16;
            this.chkCircs.Text = "一般情况";
            this.chkCircs.UseVisualStyleBackColor = true;
            // 
            // chkResult
            // 
            this.chkResult.AutoSize = true;
            this.chkResult.Location = new System.Drawing.Point(19, 105);
            this.chkResult.Name = "chkResult";
            this.chkResult.Size = new System.Drawing.Size(72, 16);
            this.chkResult.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkResult.TabIndex = 15;
            this.chkResult.Text = "随访结果";
            this.chkResult.UseVisualStyleBackColor = true;
            // 
            // chkLinkType
            // 
            this.chkLinkType.AutoSize = true;
            this.chkLinkType.Location = new System.Drawing.Point(19, 68);
            this.chkLinkType.Name = "chkLinkType";
            this.chkLinkType.Size = new System.Drawing.Size(72, 16);
            this.chkLinkType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkLinkType.TabIndex = 14;
            this.chkLinkType.Text = "随访方式";
            this.chkLinkType.UseVisualStyleBackColor = true;
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Location = new System.Drawing.Point(19, 32);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(72, 16);
            this.chkState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkState.TabIndex = 13;
            this.chkState.Text = "随访情况";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // cmbLinkType
            // 
            this.cmbLinkType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbLinkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinkType.FormattingEnabled = true;
            this.cmbLinkType.IsEnter2Tab = false;
            this.cmbLinkType.IsFlat = true;
            this.cmbLinkType.IsLike = true;
            this.cmbLinkType.Location = new System.Drawing.Point(99, 63);
            this.cmbLinkType.Name = "cmbLinkType";
            this.cmbLinkType.PopForm = null;
            this.cmbLinkType.ShowCustomerList = false;
            this.cmbLinkType.ShowID = false;
            this.cmbLinkType.Size = new System.Drawing.Size(98, 20);
            this.cmbLinkType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbLinkType.TabIndex = 11;
            this.cmbLinkType.Tag = "";
            this.cmbLinkType.ToolBarUse = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(19, 293);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.IsEnter2Tab = false;
            this.dtpEnd.Location = new System.Drawing.Point(19, 255);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(178, 21);
            this.dtpEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEnd.TabIndex = 9;
            // 
            // lblTimeTo
            // 
            this.lblTimeTo.AutoSize = true;
            this.lblTimeTo.Location = new System.Drawing.Point(17, 231);
            this.lblTimeTo.Name = "lblTimeTo";
            this.lblTimeTo.Size = new System.Drawing.Size(17, 12);
            this.lblTimeTo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblTimeTo.TabIndex = 8;
            this.lblTimeTo.Text = "到";
            // 
            // dtpBegin
            // 
            this.dtpBegin.IsEnter2Tab = false;
            this.dtpBegin.Location = new System.Drawing.Point(19, 198);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(178, 21);
            this.dtpBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBegin.TabIndex = 7;
            // 
            // cmbCircs
            // 
            this.cmbCircs.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbCircs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCircs.FormattingEnabled = true;
            this.cmbCircs.IsEnter2Tab = false;
            this.cmbCircs.IsFlat = true;
            this.cmbCircs.IsLike = true;
            this.cmbCircs.Location = new System.Drawing.Point(99, 136);
            this.cmbCircs.Name = "cmbCircs";
            this.cmbCircs.PopForm = null;
            this.cmbCircs.ShowCustomerList = false;
            this.cmbCircs.ShowID = false;
            this.cmbCircs.Size = new System.Drawing.Size(98, 20);
            this.cmbCircs.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbCircs.TabIndex = 5;
            this.cmbCircs.Tag = "";
            this.cmbCircs.ToolBarUse = false;
            // 
            // cmbResult
            // 
            this.cmbResult.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.IsEnter2Tab = false;
            this.cmbResult.IsFlat = true;
            this.cmbResult.IsLike = true;
            this.cmbResult.Location = new System.Drawing.Point(99, 99);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.PopForm = null;
            this.cmbResult.ShowCustomerList = false;
            this.cmbResult.ShowID = false;
            this.cmbResult.Size = new System.Drawing.Size(98, 20);
            this.cmbResult.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbResult.TabIndex = 3;
            this.cmbResult.Tag = "";
            this.cmbResult.ToolBarUse = false;
            // 
            // cmbState
            // 
            this.cmbState.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.IsEnter2Tab = false;
            this.cmbState.IsFlat = true;
            this.cmbState.IsLike = true;
            this.cmbState.Items.AddRange(new object[] {
            "待随访",
            "已随访",
            "不随访"});
            this.cmbState.Location = new System.Drawing.Point(99, 26);
            this.cmbState.Name = "cmbState";
            this.cmbState.PopForm = null;
            this.cmbState.ShowCustomerList = false;
            this.cmbState.ShowID = false;
            this.cmbState.Size = new System.Drawing.Size(98, 20);
            this.cmbState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbState.TabIndex = 1;
            this.cmbState.Tag = "";
            this.cmbState.ToolBarUse = false;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(0, 252);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(212, 3);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 1;
            this.neuSplitter2.TabStop = false;
            // 
            // tvIcdList
            // 
            this.tvIcdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvIcdList.HideSelection = false;
            this.tvIcdList.Location = new System.Drawing.Point(0, 0);
            this.tvIcdList.Name = "tvIcdList";
            this.tvIcdList.Size = new System.Drawing.Size(212, 252);
            this.tvIcdList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvIcdList.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(212, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 667);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.gbxLinkWay);
            this.pnlInfo.Controls.Add(this.neuSplitter3);
            this.pnlInfo.Controls.Add(this.gbxVisitInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(215, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(577, 667);
            this.pnlInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlInfo.TabIndex = 2;
            // 
            // gbxLinkWay
            // 
            this.gbxLinkWay.Controls.Add(this.fpLinkWay);
            this.gbxLinkWay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxLinkWay.Location = new System.Drawing.Point(0, 472);
            this.gbxLinkWay.Name = "gbxLinkWay";
            this.gbxLinkWay.Size = new System.Drawing.Size(577, 195);
            this.gbxLinkWay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbxLinkWay.TabIndex = 3;
            this.gbxLinkWay.TabStop = false;
            this.gbxLinkWay.Text = "随访联系人";
            // 
            // fpLinkWay
            // 
            this.fpLinkWay.About = "2.5.2007.2005";
            this.fpLinkWay.AccessibleDescription = "fpLinkWay, Sheet1, Row 0, Column 0, ";
            this.fpLinkWay.BackColor = System.Drawing.Color.White;
            this.fpLinkWay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpLinkWay.FileName = "";
            this.fpLinkWay.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpLinkWay.IsAutoSaveGridStatus = false;
            this.fpLinkWay.IsCanCustomConfigColumn = false;
            this.fpLinkWay.Location = new System.Drawing.Point(3, 17);
            this.fpLinkWay.Name = "fpLinkWay";
            this.fpLinkWay.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpLinkWay_Sheet1});
            this.fpLinkWay.Size = new System.Drawing.Size(571, 175);
            this.fpLinkWay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpLinkWay.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpLinkWay.TextTipAppearance = tipAppearance1;
            this.fpLinkWay.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpLinkWay_Sheet1
            // 
            this.fpLinkWay_Sheet1.Reset();
            this.fpLinkWay_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpLinkWay_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpLinkWay_Sheet1.ColumnCount = 6;
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "联系人";
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "与患者关系";
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "联系电话";
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "电话状态";
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "联系地址";
            this.fpLinkWay_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "电子邮件";
            this.fpLinkWay_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(0).Label = "联系人";
            this.fpLinkWay_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(1).Label = "与患者关系";
            this.fpLinkWay_Sheet1.Columns.Get(1).Width = 80F;
            this.fpLinkWay_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(2).Label = "联系电话";
            this.fpLinkWay_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(3).Label = "电话状态";
            this.fpLinkWay_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(4).Label = "联系地址";
            this.fpLinkWay_Sheet1.Columns.Get(4).Width = 160F;
            this.fpLinkWay_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpLinkWay_Sheet1.Columns.Get(5).Label = "电子邮件";
            this.fpLinkWay_Sheet1.Columns.Get(5).Width = 80F;
            this.fpLinkWay_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpLinkWay_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpLinkWay_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpLinkWay_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSplitter3
            // 
            this.neuSplitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter3.Location = new System.Drawing.Point(0, 469);
            this.neuSplitter3.Name = "neuSplitter3";
            this.neuSplitter3.Size = new System.Drawing.Size(577, 3);
            this.neuSplitter3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter3.TabIndex = 2;
            this.neuSplitter3.TabStop = false;
            // 
            // gbxVisitInfo
            // 
            this.gbxVisitInfo.Controls.Add(this.fpVisitInfo);
            this.gbxVisitInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxVisitInfo.Location = new System.Drawing.Point(0, 0);
            this.gbxVisitInfo.Name = "gbxVisitInfo";
            this.gbxVisitInfo.Size = new System.Drawing.Size(577, 469);
            this.gbxVisitInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbxVisitInfo.TabIndex = 1;
            this.gbxVisitInfo.TabStop = false;
            this.gbxVisitInfo.Text = "患者列表";
            // 
            // fpVisitInfo
            // 
            this.fpVisitInfo.About = "2.5.2007.2005";
            this.fpVisitInfo.AccessibleDescription = "fpVisitInfo, Sheet1, Row 0, Column 0, ";
            this.fpVisitInfo.BackColor = System.Drawing.Color.White;
            this.fpVisitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpVisitInfo.FileName = "";
            this.fpVisitInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpVisitInfo.IsAutoSaveGridStatus = false;
            this.fpVisitInfo.IsCanCustomConfigColumn = false;
            this.fpVisitInfo.Location = new System.Drawing.Point(3, 17);
            this.fpVisitInfo.Name = "fpVisitInfo";
            this.fpVisitInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpVisitInfo_Sheet1});
            this.fpVisitInfo.Size = new System.Drawing.Size(571, 449);
            this.fpVisitInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpVisitInfo.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpVisitInfo.TextTipAppearance = tipAppearance2;
            this.fpVisitInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpVisitInfo.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpVisitInfo_CellClick);
            // 
            // fpVisitInfo_Sheet1
            // 
            this.fpVisitInfo_Sheet1.Reset();
            this.fpVisitInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpVisitInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpVisitInfo_Sheet1.ColumnCount = 16;
            this.fpVisitInfo_Sheet1.Columns.Get(0).Width = 90F;
            this.fpVisitInfo_Sheet1.Columns.Get(1).Width = 40F;
            this.fpVisitInfo_Sheet1.Columns.Get(2).Width = 40F;
            this.fpVisitInfo_Sheet1.Columns.Get(3).Width = 40F;
            this.fpVisitInfo_Sheet1.Columns.Get(4).Width = 40F;
            this.fpVisitInfo_Sheet1.Columns.Get(10).Width = 80F;
            this.fpVisitInfo_Sheet1.Columns.Get(14).Visible = false;
            this.fpVisitInfo_Sheet1.Columns.Get(15).Visible = false;
            this.fpVisitInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpVisitInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpVisitInfo_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpVisitInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(19, 172);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(72, 16);
            this.chkTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkTime.TabIndex = 17;
            this.chkTime.Text = "随访时间";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // ucVisitSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.pnlcase);
            this.Name = "ucVisitSearch";
            this.Size = new System.Drawing.Size(792, 667);
            this.Load += new System.EventHandler(this.ucVisitSearch_Load);
            this.pnlcase.ResumeLayout(false);
            this.pnlselect.ResumeLayout(false);
            this.gbxSelect.ResumeLayout(false);
            this.gbxSelect.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.gbxLinkWay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpLinkWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpLinkWay_Sheet1)).EndInit();
            this.gbxVisitInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpVisitInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpVisitInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlcase;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlselect;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvIcdList;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpVisitInfo;
        private FarPoint.Win.Spread.SheetView fpVisitInfo_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbxSelect;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbState;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbResult;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbCircs;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQuery;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblTimeTo;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbxVisitInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbxLinkWay;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpLinkWay;
        private FarPoint.Win.Spread.SheetView fpLinkWay_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter3;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkCircs;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkResult;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkLinkType;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkState;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbLinkType;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkTime;
    }
}
