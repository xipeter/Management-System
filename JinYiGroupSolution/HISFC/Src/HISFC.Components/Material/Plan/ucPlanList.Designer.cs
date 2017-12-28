namespace Neusoft.HISFC.Components.Material.Plan
{
    partial class ucPlanList
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbState = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnMerge = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.cmbState);
            this.neuPanel1.Controls.Add(this.btnQuery);
            this.neuPanel1.Controls.Add(this.dtEnd);
            this.neuPanel1.Controls.Add(this.dtBegin);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuLabel4);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(646, 37);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            this.neuPanel1.Visible = false;
            // 
            // cmbState
            // 
            this.cmbState.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.IsEnter2Tab = false;
            this.cmbState.IsFlat = true;
            this.cmbState.IsLike = true;
            this.cmbState.Items.AddRange(new object[] {
            "计划[0]",
            "采购[1]",
            "审核[2]",
            "入库[3]",
            "作废[4]"});
            this.cmbState.Location = new System.Drawing.Point(468, 6);
            this.cmbState.Name = "cmbState";
            this.cmbState.PopForm = null;
            this.cmbState.ShowCustomerList = false;
            this.cmbState.ShowID = false;
            this.cmbState.Size = new System.Drawing.Size(77, 20);
            this.cmbState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbState.TabIndex = 3;
            this.cmbState.Tag = "";
            this.cmbState.Text = "计划[0]";
            this.cmbState.ToolBarUse = false;
            // 
            // btnQuery
            // 
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(554, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 23);
            this.btnQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.IsEnter2Tab = false;
            this.dtEnd.Location = new System.Drawing.Point(275, 7);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(144, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 1;
            // 
            // dtBegin
            // 
            this.dtBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin.IsEnter2Tab = false;
            this.dtBegin.Location = new System.Drawing.Point(58, 7);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(144, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(207, 11);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "－终止时间";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel4.Location = new System.Drawing.Point(423, 11);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(41, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "状　态";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(3, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "起始时间";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 列表";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 37);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2});
            this.neuSpread1.Size = new System.Drawing.Size(646, 277);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "列表";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 3;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选 中";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "单 据 号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "计 划 人";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选 中";
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 58F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "单 据 号";
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 146F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "计 划 人";
            this.neuSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 117F;
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
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset();
            this.neuSpread1_Sheet2.SheetName = "明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.ColumnCount = 7;
            this.neuSpread1_Sheet2.RowCount = 0;
            this.neuSpread1_Sheet2.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "商 品 名 称";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = " 规 格";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 2).Value = "计划数量";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 3).Value = "单 位";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 4).Value = "本科室库存量";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 5).Value = "全院库存量";
            this.neuSpread1_Sheet2.ColumnHeader.Cells.Get(0, 6).Value = "备注";
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.Columns.Get(0).Label = "商 品 名 称";
            this.neuSpread1_Sheet2.Columns.Get(0).Width = 120F;
            this.neuSpread1_Sheet2.Columns.Get(1).Label = " 规 格";
            this.neuSpread1_Sheet2.Columns.Get(1).Width = 80F;
            this.neuSpread1_Sheet2.Columns.Get(2).CellType = numberCellType1;
            this.neuSpread1_Sheet2.Columns.Get(2).Label = "计划数量";
            this.neuSpread1_Sheet2.Columns.Get(2).Width = 80F;
            this.neuSpread1_Sheet2.Columns.Get(4).CellType = numberCellType2;
            this.neuSpread1_Sheet2.Columns.Get(4).Label = "本科室库存量";
            this.neuSpread1_Sheet2.Columns.Get(4).Width = 85F;
            this.neuSpread1_Sheet2.Columns.Get(5).CellType = numberCellType3;
            this.neuSpread1_Sheet2.Columns.Get(5).Label = "全院库存量";
            this.neuSpread1_Sheet2.Columns.Get(5).Width = 85F;
            this.neuSpread1_Sheet2.Columns.Get(6).Label = "备注";
            this.neuSpread1_Sheet2.Columns.Get(6).Width = 77F;
            this.neuSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet2.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 1, 0);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btnCancel);
            this.neuPanel2.Controls.Add(this.btnMerge);
            this.neuPanel2.Controls.Add(this.neuLabel3);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 314);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(646, 33);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(554, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMerge.Location = new System.Drawing.Point(468, 6);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(77, 23);
            this.btnMerge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnMerge.TabIndex = 1;
            this.btnMerge.Text = "确  定";
            this.btnMerge.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(3, 11);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(275, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "双击单据查看计划单明细 选中多张计划单进行合并";
            // 
            // ucPlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucPlanList";
            this.Size = new System.Drawing.Size(646, 347);
            this.Load += new System.EventHandler(this.ucPlanList_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnMerge;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQuery;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbState;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
    }
}
