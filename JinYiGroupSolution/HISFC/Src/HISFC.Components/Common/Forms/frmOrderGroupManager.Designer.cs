namespace Neusoft.HISFC.Components.Common.Forms
{
    partial class frmOrderGroupManager
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.rdo3 = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rdo2 = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rdo1 = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.cmbGroupName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tvDoctorGroup1 = new Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup(this.components);
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.White;
            this.neuPanel1.Controls.Add(this.btnExit);
            this.neuPanel1.Controls.Add(this.btnSave);
            this.neuPanel1.Controls.Add(this.fpSpread1);
            this.neuPanel1.Controls.Add(this.rdo3);
            this.neuPanel1.Controls.Add(this.rdo2);
            this.neuPanel1.Controls.Add(this.rdo1);
            this.neuPanel1.Controls.Add(this.chkAdd);
            this.neuPanel1.Controls.Add(this.cmbGroupName);
            this.neuPanel1.Controls.Add(this.label1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(161, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(548, 371);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(446, 51);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(365, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(6, 80);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(539, 279);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 7;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.Location = new System.Drawing.Point(446, 19);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(71, 16);
            this.rdo3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdo3.TabIndex = 6;
            this.rdo3.Text = "全院组套";
            this.rdo3.UseVisualStyleBackColor = true;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(369, 19);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(71, 16);
            this.rdo2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdo2.TabIndex = 5;
            this.rdo2.Text = "科室组套";
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(301, 19);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(71, 16);
            this.rdo1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdo1.TabIndex = 4;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "个人组套";
            this.rdo1.UseVisualStyleBackColor = true;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(223, 19);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(72, 16);
            this.chkAdd.TabIndex = 2;
            this.chkAdd.Text = "是否追加";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // cmbGroupName
            // 
            this.cmbGroupName.FormattingEnabled = true;
            this.cmbGroupName.Location = new System.Drawing.Point(80, 17);
            this.cmbGroupName.MaxLength = 20;
            this.cmbGroupName.Name = "cmbGroupName";
            this.cmbGroupName.Size = new System.Drawing.Size(121, 20);
            this.cmbGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存为：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAll,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // mnuAll
            // 
            this.mnuAll.Name = "mnuAll";
            this.mnuAll.Size = new System.Drawing.Size(142, 22);
            this.mnuAll.Text = "显示全院组套";
            this.mnuAll.Click += new System.EventHandler(this.mnuAll_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.neuPanel1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tvDoctorGroup1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 371);
            this.panel1.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(158, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 371);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 21;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "组合号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "医嘱名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "规格";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "组合";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "间隔天数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "每次剂量";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "频次";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "数量";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "付数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "用法";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "医嘱类型";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "加急";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "开始时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "开立时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "开立医生";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "执行科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "停止时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "停止医生";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "备注";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "顺序号";
            this.fpSpread1_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "ID";
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "组合号";
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "医嘱名称";
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 112F;
            this.fpSpread1_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "规格";
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "组合";
            this.fpSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 48F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 10;
            numberCellType1.MinimumValue = 0;
            numberCellType1.SpinDecimalIncrement = 1F;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "间隔天数";
            this.fpSpread1_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "每次剂量";
            this.fpSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "频次";
            this.fpSpread1_Sheet1.Columns.Get(7).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "数量";
            this.fpSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "付数";
            this.fpSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(10).Label = "用法";
            this.fpSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(11).Label = "医嘱类型";
            this.fpSpread1_Sheet1.Columns.Get(11).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(12).Label = "加急";
            this.fpSpread1_Sheet1.Columns.Get(12).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(13).Label = "开始时间";
            this.fpSpread1_Sheet1.Columns.Get(13).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(14).Label = "开立时间";
            this.fpSpread1_Sheet1.Columns.Get(14).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(15).Label = "开立医生";
            this.fpSpread1_Sheet1.Columns.Get(15).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(16).Label = "执行科室";
            this.fpSpread1_Sheet1.Columns.Get(16).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(17).Label = "停止时间";
            this.fpSpread1_Sheet1.Columns.Get(17).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(18).Label = "停止医生";
            this.fpSpread1_Sheet1.Columns.Get(18).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(19).Label = "备注";
            this.fpSpread1_Sheet1.Columns.Get(19).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(20).Label = "顺序号";
            this.fpSpread1_Sheet1.Columns.Get(20).Locked = true;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // tvDoctorGroup1
            // 
            this.tvDoctorGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDoctorGroup1.HideSelection = false;
            this.tvDoctorGroup1.ImageIndex = 0;
            this.tvDoctorGroup1.Location = new System.Drawing.Point(0, 0);
            this.tvDoctorGroup1.Name = "tvDoctorGroup1";
            this.tvDoctorGroup1.SelectedImageIndex = 0;
            this.tvDoctorGroup1.Size = new System.Drawing.Size(158, 371);
            this.tvDoctorGroup1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDoctorGroup1.TabIndex = 0;
            // 
            // frmOrderGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmOrderGroupManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱组套管理";
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup tvDoctorGroup1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.ComboBox cmbGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rdo3;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rdo2;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rdo1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
    }
}