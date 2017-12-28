namespace Neusoft.HISFC.Components.Pharmacy
{
    partial class ucPhaApplyList
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbNotice = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fsApplyData = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsApplyData_List = new FarPoint.Win.Spread.SheetView();
            this.fsApplyData_Detail = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData_Detail)).BeginInit();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lbNotice);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(510, 40);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.ForeColor = System.Drawing.Color.Blue;
            this.lbNotice.Location = new System.Drawing.Point(6, 17);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(401, 12);
            this.lbNotice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbNotice.TabIndex = 0;
            this.lbNotice.Text = "说明：双击单据查看申请单明细。确认后对所选择的申请单合并生成计划单";
            // 
            // fsApplyData
            // 
            this.fsApplyData.About = "2.5.2007.2005";
            this.fsApplyData.AccessibleDescription = "fsApplyData, 申请单, Row 0, Column 0, ";
            this.fsApplyData.BackColor = System.Drawing.Color.White;
            this.fsApplyData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsApplyData.FileName = "";
            this.fsApplyData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsApplyData.IsAutoSaveGridStatus = false;
            this.fsApplyData.IsCanCustomConfigColumn = false;
            this.fsApplyData.Location = new System.Drawing.Point(0, 40);
            this.fsApplyData.Name = "fsApplyData";
            this.fsApplyData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsApplyData_List,
            this.fsApplyData_Detail});
            this.fsApplyData.Size = new System.Drawing.Size(510, 233);
            this.fsApplyData.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsApplyData.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsApplyData.TextTipAppearance = tipAppearance1;
            this.fsApplyData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsApplyData.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fsApplyData_CellDoubleClick);
            // 
            // fsApplyData_List
            // 
            this.fsApplyData_List.Reset();
            this.fsApplyData_List.SheetName = "申请单";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsApplyData_List.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsApplyData_List.ColumnCount = 3;
            this.fsApplyData_List.RowCount = 1;
            this.fsApplyData_List.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsApplyData_List.ColumnHeader.Cells.Get(0, 0).Value = "选择";
            this.fsApplyData_List.ColumnHeader.Cells.Get(0, 1).Value = "单据号";
            this.fsApplyData_List.ColumnHeader.Cells.Get(0, 2).Value = "申请科室";
            this.fsApplyData_List.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_List.ColumnHeader.DefaultStyle.Locked = false;
            this.fsApplyData_List.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsApplyData_List.Columns.Get(0).BackColor = System.Drawing.Color.SeaShell;
            this.fsApplyData_List.Columns.Get(0).CellType = checkBoxCellType1;
            this.fsApplyData_List.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fsApplyData_List.Columns.Get(0).Label = "选择";
            this.fsApplyData_List.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsApplyData_List.Columns.Get(0).Width = 51F;
            this.fsApplyData_List.Columns.Get(1).CellType = textCellType1;
            this.fsApplyData_List.Columns.Get(1).Label = "单据号";
            this.fsApplyData_List.Columns.Get(1).Locked = true;
            this.fsApplyData_List.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsApplyData_List.Columns.Get(1).Width = 137F;
            this.fsApplyData_List.Columns.Get(2).Label = "申请科室";
            this.fsApplyData_List.Columns.Get(2).Locked = true;
            this.fsApplyData_List.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsApplyData_List.Columns.Get(2).Width = 153F;
            this.fsApplyData_List.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsApplyData_List.RowHeader.Columns.Default.Resizable = false;
            this.fsApplyData_List.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_List.RowHeader.DefaultStyle.Locked = false;
            this.fsApplyData_List.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsApplyData_List.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_List.SheetCornerStyle.Locked = false;
            this.fsApplyData_List.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsApplyData_List.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fsApplyData_Detail
            // 
            this.fsApplyData_Detail.Reset();
            this.fsApplyData_Detail.SheetName = "明 细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsApplyData_Detail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsApplyData_Detail.ColumnCount = 5;
            this.fsApplyData_Detail.RowCount = 0;
            this.fsApplyData_Detail.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsApplyData_Detail.ColumnHeader.Cells.Get(0, 0).Value = "药品名称";
            this.fsApplyData_Detail.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.fsApplyData_Detail.ColumnHeader.Cells.Get(0, 2).Value = "申请数量";
            this.fsApplyData_Detail.ColumnHeader.Cells.Get(0, 3).Value = "已发数量";
            this.fsApplyData_Detail.ColumnHeader.Cells.Get(0, 4).Value = "单位";
            this.fsApplyData_Detail.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_Detail.ColumnHeader.DefaultStyle.Locked = false;
            this.fsApplyData_Detail.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsApplyData_Detail.Columns.Get(0).Label = "药品名称";
            this.fsApplyData_Detail.Columns.Get(0).Width = 120F;
            this.fsApplyData_Detail.Columns.Get(1).Label = "规格";
            this.fsApplyData_Detail.Columns.Get(1).Width = 80F;
            this.fsApplyData_Detail.Columns.Get(2).CellType = numberCellType1;
            this.fsApplyData_Detail.Columns.Get(2).Label = "申请数量";
            this.fsApplyData_Detail.Columns.Get(2).Width = 100F;
            this.fsApplyData_Detail.Columns.Get(3).CellType = numberCellType2;
            this.fsApplyData_Detail.Columns.Get(3).Label = "已发数量";
            this.fsApplyData_Detail.Columns.Get(3).Width = 100F;
            this.fsApplyData_Detail.DefaultStyle.Locked = true;
            this.fsApplyData_Detail.DefaultStyle.Parent = "DataAreaDefault";
            this.fsApplyData_Detail.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsApplyData_Detail.RowHeader.Columns.Default.Resizable = false;
            this.fsApplyData_Detail.RowHeader.Columns.Get(0).Width = 37F;
            this.fsApplyData_Detail.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_Detail.RowHeader.DefaultStyle.Locked = false;
            this.fsApplyData_Detail.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsApplyData_Detail.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsApplyData_Detail.SheetCornerStyle.Locked = false;
            this.fsApplyData_Detail.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsApplyData_Detail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fsApplyData.SetActiveViewport(1, 1, 0);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.btnOK);
            this.neuGroupBox2.Controls.Add(this.btnCancel);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 273);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(510, 41);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(254, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确  认";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucPhaApplyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fsApplyData);
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.neuGroupBox2);
            this.Name = "ucPhaApplyList";
            this.Size = new System.Drawing.Size(510, 314);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsApplyData_Detail)).EndInit();
            this.neuGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbNotice;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsApplyData;
        private FarPoint.Win.Spread.SheetView fsApplyData_List;
        private FarPoint.Win.Spread.SheetView fsApplyData_Detail;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}
