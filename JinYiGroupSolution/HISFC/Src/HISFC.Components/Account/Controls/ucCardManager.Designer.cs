namespace Neusoft.HISFC.Components.Account.Controls
{
    partial class ucCardManager
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelCard = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ckIsTreatment = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbMarkType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtMarkNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucRegPatientInfo1 = new Neusoft.HISFC.Components.Account.Controls.ucRegPatientInfo();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.spInfo = new FarPoint.Win.Spread.SheetView();
            this.spPatient = new FarPoint.Win.Spread.SheetView();
            this.menu = new Neusoft.FrameWork.WinForms.Controls.NeuContexMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.neuTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuTabControl1.ItemSize = new System.Drawing.Size(72, 19);
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(856, 307);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelCard);
            this.tabPage2.Controls.Add(this.ucRegPatientInfo1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(848, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "就诊卡发放";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.Transparent;
            this.panelCard.Controls.Add(this.ckIsTreatment);
            this.panelCard.Controls.Add(this.cmbMarkType);
            this.panelCard.Controls.Add(this.txtMarkNo);
            this.panelCard.Controls.Add(this.neuLabel2);
            this.panelCard.Controls.Add(this.neuLabel1);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCard.Location = new System.Drawing.Point(3, 247);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(842, 30);
            this.panelCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelCard.TabIndex = 1;
            // 
            // ckIsTreatment
            // 
            this.ckIsTreatment.AutoSize = true;
            this.ckIsTreatment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckIsTreatment.Location = new System.Drawing.Point(544, 9);
            this.ckIsTreatment.Name = "ckIsTreatment";
            this.ckIsTreatment.Size = new System.Drawing.Size(72, 16);
            this.ckIsTreatment.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckIsTreatment.TabIndex = 3;
            this.ckIsTreatment.Text = "急诊患者";
            this.ckIsTreatment.UseVisualStyleBackColor = true;
            this.ckIsTreatment.CheckedChanged += new System.EventHandler(this.ckIsTreatment_CheckedChanged);
            // 
            // cmbMarkType
            // 
            this.cmbMarkType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMarkType.Enabled = false;
            this.cmbMarkType.FormattingEnabled = true;
            this.cmbMarkType.IsEnter2Tab = false;
            this.cmbMarkType.IsFlat = true;
            this.cmbMarkType.IsLike = true;
            this.cmbMarkType.Location = new System.Drawing.Point(344, 6);
            this.cmbMarkType.Name = "cmbMarkType";
            this.cmbMarkType.PopForm = null;
            this.cmbMarkType.ShowCustomerList = false;
            this.cmbMarkType.ShowID = false;
            this.cmbMarkType.Size = new System.Drawing.Size(169, 20);
            this.cmbMarkType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMarkType.TabIndex = 2;
            this.cmbMarkType.Tag = "";
            this.cmbMarkType.ToolBarUse = false;
            // 
            // txtMarkNo
            // 
            this.txtMarkNo.IsEnter2Tab = false;
            this.txtMarkNo.Location = new System.Drawing.Point(71, 6);
            this.txtMarkNo.Name = "txtMarkNo";
            this.txtMarkNo.Size = new System.Drawing.Size(180, 21);
            this.txtMarkNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMarkNo.TabIndex = 1;
            this.txtMarkNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarkNo_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(11, 12);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "卡　　号：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(281, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(73, 13);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "卡 类 型：";
            // 
            // ucRegPatientInfo1
            // 
            this.ucRegPatientInfo1.CardNO = "";
            this.ucRegPatientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegPatientInfo1.IsEnableEntry = true;
            this.ucRegPatientInfo1.IsEnableIDENO = true;
            this.ucRegPatientInfo1.IsEnableIDEType = true;
            this.ucRegPatientInfo1.IsEnablePact = true;
            this.ucRegPatientInfo1.IsEnableSiNO = true;
            this.ucRegPatientInfo1.IsEnableVip = true;
            this.ucRegPatientInfo1.IsInputBirthDay = false;
            this.ucRegPatientInfo1.IsInputIDENO = false;
            this.ucRegPatientInfo1.IsInputIDEType = false;
            this.ucRegPatientInfo1.IsInputName = true;
            this.ucRegPatientInfo1.IsInputPact = true;
            this.ucRegPatientInfo1.IsInputSex = true;
            this.ucRegPatientInfo1.IsInputSiNo = false;
            this.ucRegPatientInfo1.IsMustInputTabIndex = false;
            this.ucRegPatientInfo1.IsPrint = false;
            this.ucRegPatientInfo1.IsTreatment = false;
            this.ucRegPatientInfo1.Location = new System.Drawing.Point(3, 3);
            this.ucRegPatientInfo1.Name = "ucRegPatientInfo1";
            this.ucRegPatientInfo1.Size = new System.Drawing.Size(842, 274);
            this.ucRegPatientInfo1.TabIndex = 0;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 患者信息, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 307);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spInfo,
            this.spPatient});
            this.neuSpread1.Size = new System.Drawing.Size(856, 201);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellClick);
            // 
            // spInfo
            // 
            this.spInfo.Reset();
            this.spInfo.SheetName = "提示信息";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spInfo.ColumnCount = 6;
            this.spInfo.RowCount = 1;
            this.spInfo.ColumnHeader.Cells.Get(0, 0).Value = "编码";
            this.spInfo.ColumnHeader.Cells.Get(0, 1).Value = "名称";
            this.spInfo.ColumnHeader.Cells.Get(0, 2).Value = "编码";
            this.spInfo.ColumnHeader.Cells.Get(0, 3).Value = "名称";
            this.spInfo.ColumnHeader.Cells.Get(0, 4).Value = "编码";
            this.spInfo.ColumnHeader.Cells.Get(0, 5).Value = "名称";
            this.spInfo.Columns.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spInfo.Columns.Get(0).CellType = textCellType1;
            this.spInfo.Columns.Get(0).Label = "编码";
            this.spInfo.Columns.Get(0).Locked = true;
            this.spInfo.Columns.Get(0).Width = 100F;
            this.spInfo.Columns.Get(1).CellType = textCellType2;
            this.spInfo.Columns.Get(1).Label = "名称";
            this.spInfo.Columns.Get(1).Locked = true;
            this.spInfo.Columns.Get(1).Width = 170F;
            this.spInfo.Columns.Get(2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spInfo.Columns.Get(2).CellType = textCellType3;
            this.spInfo.Columns.Get(2).Label = "编码";
            this.spInfo.Columns.Get(2).Locked = true;
            this.spInfo.Columns.Get(2).Width = 100F;
            this.spInfo.Columns.Get(3).CellType = textCellType4;
            this.spInfo.Columns.Get(3).Label = "名称";
            this.spInfo.Columns.Get(3).Locked = true;
            this.spInfo.Columns.Get(3).Width = 170F;
            this.spInfo.Columns.Get(4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spInfo.Columns.Get(4).CellType = textCellType5;
            this.spInfo.Columns.Get(4).Label = "编码";
            this.spInfo.Columns.Get(4).Locked = true;
            this.spInfo.Columns.Get(4).Width = 100F;
            this.spInfo.Columns.Get(5).CellType = textCellType6;
            this.spInfo.Columns.Get(5).Label = "名称";
            this.spInfo.Columns.Get(5).Locked = true;
            this.spInfo.Columns.Get(5).Width = 170F;
            this.spInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spInfo.RowHeader.Columns.Default.Resizable = false;
            this.spInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spPatient
            // 
            this.spPatient.Reset();
            this.spPatient.SheetName = "患者信息";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spPatient.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spPatient.ColumnCount = 11;
            this.spPatient.RowCount = 1;
            this.spPatient.ColumnHeader.Cells.Get(0, 0).Value = "姓名";
            this.spPatient.ColumnHeader.Cells.Get(0, 1).Value = "性别";
            this.spPatient.ColumnHeader.Cells.Get(0, 2).Value = "年龄";
            this.spPatient.ColumnHeader.Cells.Get(0, 3).Value = "民族";
            this.spPatient.ColumnHeader.Cells.Get(0, 4).Value = "费用来源";
            this.spPatient.ColumnHeader.Cells.Get(0, 5).Value = "证件类型";
            this.spPatient.ColumnHeader.Cells.Get(0, 6).Value = "证件号";
            this.spPatient.ColumnHeader.Cells.Get(0, 7).Value = "工作单位";
            this.spPatient.ColumnHeader.Cells.Get(0, 8).Value = "家庭住址";
            this.spPatient.ColumnHeader.Cells.Get(0, 9).Value = "条码号";
            this.spPatient.ColumnHeader.Cells.Get(0, 10).Value = "卡类型";
            this.spPatient.Columns.Get(0).CellType = textCellType7;
            this.spPatient.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(0).Label = "姓名";
            this.spPatient.Columns.Get(0).Locked = true;
            this.spPatient.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(0).Width = 83F;
            this.spPatient.Columns.Get(1).CellType = textCellType8;
            this.spPatient.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(1).Label = "性别";
            this.spPatient.Columns.Get(1).Locked = true;
            this.spPatient.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(1).Width = 40F;
            this.spPatient.Columns.Get(2).CellType = textCellType9;
            this.spPatient.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(2).Label = "年龄";
            this.spPatient.Columns.Get(2).Locked = true;
            this.spPatient.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(2).Width = 44F;
            this.spPatient.Columns.Get(3).CellType = textCellType10;
            this.spPatient.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(3).Label = "民族";
            this.spPatient.Columns.Get(3).Locked = true;
            this.spPatient.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(3).Width = 66F;
            this.spPatient.Columns.Get(4).CellType = textCellType11;
            this.spPatient.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(4).Label = "费用来源";
            this.spPatient.Columns.Get(4).Locked = true;
            this.spPatient.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(4).Width = 81F;
            this.spPatient.Columns.Get(5).CellType = textCellType12;
            this.spPatient.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(5).Label = "证件类型";
            this.spPatient.Columns.Get(5).Locked = true;
            this.spPatient.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(5).Width = 65F;
            this.spPatient.Columns.Get(6).CellType = textCellType13;
            this.spPatient.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(6).Label = "证件号";
            this.spPatient.Columns.Get(6).Locked = true;
            this.spPatient.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(6).Width = 116F;
            this.spPatient.Columns.Get(7).CellType = textCellType14;
            this.spPatient.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(7).Label = "工作单位";
            this.spPatient.Columns.Get(7).Locked = true;
            this.spPatient.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(7).Width = 150F;
            this.spPatient.Columns.Get(8).CellType = textCellType15;
            this.spPatient.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spPatient.Columns.Get(8).Label = "家庭住址";
            this.spPatient.Columns.Get(8).Locked = true;
            this.spPatient.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spPatient.Columns.Get(8).Width = 160F;
            this.spPatient.Columns.Get(9).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spPatient.Columns.Get(9).CellType = textCellType16;
            this.spPatient.Columns.Get(9).Label = "条码号";
            this.spPatient.Columns.Get(9).Locked = true;
            this.spPatient.Columns.Get(9).Width = 86F;
            this.spPatient.Columns.Get(10).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spPatient.Columns.Get(10).CellType = textCellType17;
            this.spPatient.Columns.Get(10).Label = "卡类型";
            this.spPatient.Columns.Get(10).Locked = true;
            this.spPatient.Columns.Get(10).Width = 77F;
            this.spPatient.GrayAreaBackColor = System.Drawing.Color.White;
            this.spPatient.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spPatient.RowHeader.Columns.Default.Resizable = false;
            this.spPatient.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // menu
            // 
            this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.menu.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "显示患者信息";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "打印条码";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // ucCardManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucCardManager";
            this.Size = new System.Drawing.Size(856, 508);
            this.Load += new System.EventHandler(this.ucCardManager_Load);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucRegPatientInfo ucRegPatientInfo1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView spInfo;
        private FarPoint.Win.Spread.SheetView spPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMarkNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMarkType;
        private Neusoft.FrameWork.WinForms.Controls.NeuContexMenu menu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckIsTreatment;
    }
}
