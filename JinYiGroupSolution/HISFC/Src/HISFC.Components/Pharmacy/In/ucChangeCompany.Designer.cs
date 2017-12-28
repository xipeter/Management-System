namespace Neusoft.HISFC.Components.Pharmacy.In
{
    partial class ucChangeCompany
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbState = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.lbCompany = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLinkLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.lnbCompany = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.lnbNOType = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbState);
            this.neuGroupBox1.Controls.Add(this.lbCompany);
            this.neuGroupBox1.Controls.Add(this.txtNO);
            this.neuGroupBox1.Controls.Add(this.neuLinkLabel2);
            this.neuGroupBox1.Controls.Add(this.lnbCompany);
            this.neuGroupBox1.Controls.Add(this.lnbNOType);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(711, 52);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "设  定";
            // 
            // cmbState
            // 
            this.cmbState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.IsFlat = true;
            this.cmbState.Items.AddRange(new object[] {
            "申请",
            "审批"});
            this.cmbState.Location = new System.Drawing.Point(224, 22);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(107, 22);
            this.cmbState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbState.TabIndex = 2;
            this.cmbState.ToolBarUse = false;
            // 
            // lbCompany
            // 
            this.lbCompany.Location = new System.Drawing.Point(424, 23);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.ReadOnly = true;
            this.lbCompany.Size = new System.Drawing.Size(281, 21);
            this.lbCompany.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCompany.TabIndex = 1;
            // 
            // txtNO
            // 
            this.txtNO.Location = new System.Drawing.Point(65, 23);
            this.txtNO.Name = "txtNO";
            this.txtNO.Size = new System.Drawing.Size(100, 21);
            this.txtNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtNO.TabIndex = 1;
            // 
            // neuLinkLabel2
            // 
            this.neuLinkLabel2.AutoSize = true;
            this.neuLinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.neuLinkLabel2.Location = new System.Drawing.Point(171, 27);
            this.neuLinkLabel2.Name = "neuLinkLabel2";
            this.neuLinkLabel2.Size = new System.Drawing.Size(47, 12);
            this.neuLinkLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLinkLabel2.TabIndex = 0;
            this.neuLinkLabel2.TabStop = true;
            this.neuLinkLabel2.Text = "状   态";
            // 
            // lnbCompany
            // 
            this.lnbCompany.AutoSize = true;
            this.lnbCompany.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbCompany.Location = new System.Drawing.Point(353, 27);
            this.lnbCompany.Name = "lnbCompany";
            this.lnbCompany.Size = new System.Drawing.Size(65, 12);
            this.lnbCompany.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lnbCompany.TabIndex = 0;
            this.lnbCompany.TabStop = true;
            this.lnbCompany.Text = "新供货公司";
            // 
            // lnbNOType
            // 
            this.lnbNOType.AutoSize = true;
            this.lnbNOType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbNOType.Location = new System.Drawing.Point(6, 27);
            this.lnbNOType.Name = "lnbNOType";
            this.lnbNOType.Size = new System.Drawing.Size(53, 12);
            this.lnbNOType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lnbNOType.TabIndex = 0;
            this.lnbNOType.TabStop = true;
            this.lnbNOType.Text = "发 票 号";
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 52);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(711, 349);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 8;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选中";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "单据号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "发票号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "原供货公司";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "商品名【规格】";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "入库数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "单位";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选中";
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 38F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "单据号";
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType4;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "发票号";
            this.neuSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "原供货公司";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 180F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "商品名【规格】";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 242F;
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "入库数量";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 86F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "单位";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 35F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucChangeCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucChangeCompany";
            this.Size = new System.Drawing.Size(711, 401);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbState;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox lbCompany;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel neuLinkLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lnbCompany;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lnbNOType;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
