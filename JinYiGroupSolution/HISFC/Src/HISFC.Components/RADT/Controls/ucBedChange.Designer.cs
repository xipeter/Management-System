namespace Neusoft.HISFC.Components.RADT.Controls
{
    partial class ucBedChange
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.GroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lblShow = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbInpatientNo = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Info;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(6, 20);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(524, 347);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_Click);
            this.fpSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpSpread1_SelectionChanged);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 10;
            this.fpSpread1_Sheet1.RowCount = 3;
            this.fpSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "床号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "房间号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "床位等级";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "床位编制";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "状态";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "住院号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "病床电话";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "归属";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "是否有效";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "预约";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "床号";
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 70F;
            this.fpSpread1_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "房间号";
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 70F;
            this.fpSpread1_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "床位等级";
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "床位编制";
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "状态";
            this.fpSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 70F;
            this.fpSpread1_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "住院号";
            this.fpSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 90F;
            this.fpSpread1_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "病床电话";
            this.fpSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 80F;
            this.fpSpread1_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "归属";
            this.fpSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(8).CellType = checkBoxCellType1;
            this.fpSpread1_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "是否有效";
            this.fpSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 80F;
            this.fpSpread1_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(9).CellType = checkBoxCellType2;
            this.fpSpread1_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "预约";
            this.fpSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(9).Width = 70F;
            this.fpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnCancel);
            this.GroupBox1.Controls.Add(this.btnOK);
            this.GroupBox1.Controls.Add(this.lblShow);
            this.GroupBox1.Controls.Add(this.cmbInpatientNo);
            this.GroupBox1.Controls.Add(this.neuLabel1);
            this.GroupBox1.Controls.Add(this.fpSpread1);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(536, 419);
            this.GroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "包床";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(455, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(374, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblShow
            // 
            this.lblShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(215, 381);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(53, 12);
            this.lblShow.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblShow.TabIndex = 3;
            this.lblShow.Text = "患者信息";
            // 
            // cmbInpatientNo
            // 
            this.cmbInpatientNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbInpatientNo.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInpatientNo.Enabled = false;
            this.cmbInpatientNo.FormattingEnabled = true;
            this.cmbInpatientNo.IsEnter2Tab = false;
            this.cmbInpatientNo.IsFlat = false;
            this.cmbInpatientNo.IsLike = true;
            this.cmbInpatientNo.IsListOnly = false;
            this.cmbInpatientNo.IsShowCustomerList = false;
            this.cmbInpatientNo.IsShowID = false;
            this.cmbInpatientNo.Location = new System.Drawing.Point(65, 377);
            this.cmbInpatientNo.Name = "cmbInpatientNo";
            this.cmbInpatientNo.PopForm = null;
            this.cmbInpatientNo.ShowCustomerList = false;
            this.cmbInpatientNo.ShowID = false;
            this.cmbInpatientNo.Size = new System.Drawing.Size(121, 20);
            this.cmbInpatientNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbInpatientNo.TabIndex = 2;
            this.cmbInpatientNo.Tag = "";
            this.cmbInpatientNo.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(6, 381);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "住院号：";
            // 
            // ucBedChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox1);
            this.Name = "ucBedChange";
            this.Size = new System.Drawing.Size(536, 419);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox GroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblShow;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInpatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
    }
}
