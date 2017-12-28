namespace Neusoft.HISFC.Components.Preparation.Process
{
    partial class frmAssayProcess
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssayProcess));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fsStencil = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsStencil_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTemplete = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fsReport = new Neusoft.HISFC.Components.Preparation.FPItem(this.components);
            this.fsReport_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbPreparationInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsReport_Sheet1)).BeginInit();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 409);
            this.statusBar1.Size = new System.Drawing.Size(737, 24);
            this.statusBar1.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.ForeColor = System.Drawing.Color.White;
            this.neuLabel1.Image = ((System.Drawing.Image)(resources.GetObject("neuLabel1.Image")));
            this.neuLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuLabel1.Location = new System.Drawing.Point(0, 0);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(737, 46);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "制剂半成品检验管理";
            this.neuLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fsStencil);
            this.splitContainer1.Panel1.Controls.Add(this.neuGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fsReport);
            this.splitContainer1.Panel2.Controls.Add(this.neuGroupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(737, 323);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 2;
            // 
            // fsStencil
            // 
            this.fsStencil.About = "2.5.2007.2005";
            this.fsStencil.AccessibleDescription = "fsStencil";
            this.fsStencil.BackColor = System.Drawing.Color.White;
            this.fsStencil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsStencil.FileName = "";
            this.fsStencil.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsStencil.IsAutoSaveGridStatus = false;
            this.fsStencil.IsCanCustomConfigColumn = false;
            this.fsStencil.Location = new System.Drawing.Point(0, 63);
            this.fsStencil.Name = "fsStencil";
            this.fsStencil.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsStencil_Sheet1});
            this.fsStencil.Size = new System.Drawing.Size(433, 260);
            this.fsStencil.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsStencil.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsStencil.TextTipAppearance = tipAppearance1;
            this.fsStencil.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsStencil.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fsStencil_CellDoubleClick);
            // 
            // fsStencil_Sheet1
            // 
            this.fsStencil_Sheet1.Reset();
            this.fsStencil_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsStencil_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsStencil_Sheet1.ColumnCount = 5;
            this.fsStencil_Sheet1.RowCount = 1;
            this.fsStencil_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "类别";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "项目";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "标准下限";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "标准上限";
            this.fsStencil_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "标准现象";
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsStencil_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.Columns.Get(0).Label = "类别";
            this.fsStencil_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.fsStencil_Sheet1.Columns.Get(0).Width = 58F;
            this.fsStencil_Sheet1.Columns.Get(1).Label = "项目";
            this.fsStencil_Sheet1.Columns.Get(1).Width = 106F;
            this.fsStencil_Sheet1.Columns.Get(2).Label = "标准下限";
            this.fsStencil_Sheet1.Columns.Get(2).Width = 59F;
            this.fsStencil_Sheet1.Columns.Get(3).Label = "标准上限";
            this.fsStencil_Sheet1.Columns.Get(3).Width = 55F;
            this.fsStencil_Sheet1.Columns.Get(4).Label = "标准现象";
            this.fsStencil_Sheet1.Columns.Get(4).Width = 116F;
            this.fsStencil_Sheet1.DefaultStyle.Locked = true;
            this.fsStencil_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fsStencil_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsStencil_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsStencil_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsStencil_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsStencil_Sheet1.SheetCornerStyle.Locked = false;
            this.fsStencil_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsStencil_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.lbTemplete);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(433, 63);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 3;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(200, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(227, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 5;
            this.neuLabel2.Text = "如不需填写可选择取消关闭信息录入窗口 ";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel5.Location = new System.Drawing.Point(6, 43);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(251, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 5;
            this.neuLabel5.Text = "双击模版内容加入到报告单或取消报告单内容 ";
            // 
            // lbTemplete
            // 
            this.lbTemplete.AutoSize = true;
            this.lbTemplete.Location = new System.Drawing.Point(6, 17);
            this.lbTemplete.Name = "lbTemplete";
            this.lbTemplete.Size = new System.Drawing.Size(101, 12);
            this.lbTemplete.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTemplete.TabIndex = 0;
            this.lbTemplete.Text = "**半成品检验模版";
            // 
            // fsReport
            // 
            this.fsReport.About = "2.5.2007.2005";
            this.fsReport.AccessibleDescription = "fsReport, Sheet1, Row 0, Column 0, ";
            this.fsReport.BackColor = System.Drawing.Color.White;
            this.fsReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsReport.DrugType = "";
            this.fsReport.FileName = "";
            this.fsReport.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsReport.IsAutoSaveGridStatus = false;
            this.fsReport.IsCanCustomConfigColumn = false;
            this.fsReport.Location = new System.Drawing.Point(0, 63);
            this.fsReport.Name = "fsReport";
            this.fsReport.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsReport_Sheet1});
            this.fsReport.Size = new System.Drawing.Size(300, 260);
            this.fsReport.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsReport.TabIndex = 4;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsReport.TextTipAppearance = tipAppearance2;
            this.fsReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsReport.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fsReport_ComboCloseUp);
            this.fsReport.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fsReport_CellDoubleClick);
            this.fsReport.SelectItem += new System.EventHandler(this.fsReport_SelectItem);
            // 
            // fsReport_Sheet1
            // 
            this.fsReport_Sheet1.Reset();
            this.fsReport_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsReport_Sheet1.ColumnCount = 5;
            this.fsReport_Sheet1.RowCount = 1;
            this.fsReport_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "类别";
            this.fsReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "项目";
            this.fsReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "数值";
            this.fsReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "检验结果";
            this.fsReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "合格";
            this.fsReport_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsReport_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsReport_Sheet1.Columns.Get(0).Label = "类别";
            this.fsReport_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.fsReport_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsReport_Sheet1.Columns.Get(0).Width = 78F;
            this.fsReport_Sheet1.Columns.Get(1).Label = "项目";
            this.fsReport_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsReport_Sheet1.Columns.Get(1).Width = 131F;
            this.fsReport_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.SeaShell;
            this.fsReport_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.fsReport_Sheet1.Columns.Get(2).Label = "数值";
            this.fsReport_Sheet1.Columns.Get(2).Locked = false;
            this.fsReport_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsReport_Sheet1.Columns.Get(2).Width = 85F;
            this.fsReport_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.SeaShell;
            this.fsReport_Sheet1.Columns.Get(3).Label = "检验结果";
            this.fsReport_Sheet1.Columns.Get(3).Locked = false;
            this.fsReport_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsReport_Sheet1.Columns.Get(3).Width = 127F;
            this.fsReport_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.SeaShell;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "是",
        "否"};
            this.fsReport_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
            this.fsReport_Sheet1.Columns.Get(4).Label = "合格";
            this.fsReport_Sheet1.Columns.Get(4).Locked = false;
            this.fsReport_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsReport_Sheet1.DefaultStyle.Locked = true;
            this.fsReport_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fsReport_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsReport_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsReport_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsReport_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsReport_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsReport_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsReport_Sheet1.SheetCornerStyle.Locked = false;
            this.fsReport_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.lbPreparationInfo);
            this.neuGroupBox2.Controls.Add(this.lbTitle);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(300, 63);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 3;
            this.neuGroupBox2.TabStop = false;
            // 
            // lbPreparationInfo
            // 
            this.lbPreparationInfo.AutoSize = true;
            this.lbPreparationInfo.Location = new System.Drawing.Point(6, 43);
            this.lbPreparationInfo.Name = "lbPreparationInfo";
            this.lbPreparationInfo.Size = new System.Drawing.Size(275, 12);
            this.lbPreparationInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPreparationInfo.TabIndex = 4;
            this.lbPreparationInfo.Text = "制剂成品:   规格  送检量   送检人: 送检时间: ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(148, 17);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(168, 16);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "  **半成品检验报告单";
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Controls.Add(this.btnSave);
            this.neuGroupBox3.Controls.Add(this.btnCancel);
            this.neuGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuGroupBox3.Location = new System.Drawing.Point(0, 369);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(737, 40);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 3;
            this.neuGroupBox3.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(558, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "确 认";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(650, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAssayProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(737, 433);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.neuGroupBox3);
            this.Controls.Add(this.neuLabel1);
            this.KeyPreview = true;
            this.Name = "frmAssayProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工艺录入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.neuLabel1, 0);
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.neuGroupBox3, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsStencil_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsReport_Sheet1)).EndInit();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsStencil;
        private FarPoint.Win.Spread.SheetView fsStencil_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTemplete;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private HISFC.Components.Preparation.FPItem fsReport;
        private FarPoint.Win.Spread.SheetView fsReport_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPreparationInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;

    }
}