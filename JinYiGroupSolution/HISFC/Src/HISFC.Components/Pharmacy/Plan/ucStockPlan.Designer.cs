namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    partial class ucStockPlan
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPlanBill = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPlanInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tbStockHistory = new System.Windows.Forms.TabPage();
            this.fpSpread2 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuTabControl1.SuspendLayout();
            this.tbStockHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(755, 459);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.neuSpread1);
            this.splitContainer2.Panel1.Controls.Add(this.lbCost);
            this.splitContainer2.Panel1.Controls.Add(this.lbPlanBill);
            this.splitContainer2.Panel1.Controls.Add(this.lbPlanInfo);
            this.splitContainer2.Panel1.Controls.Add(this.lbTitle);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.neuTabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(755, 459);
            this.splitContainer2.SplitterDistance = 349;
            this.splitContainer2.TabIndex = 0;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 52);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(751, 296);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 5;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpStockApprove_KeyPress);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpStockApprove_CellDoubleClick);
            this.neuSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpStockApprove_SelectionChanged);
            this.neuSpread1.EditModeOff += new System.EventHandler(this.fpStockApprove_EditModeOff);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 13;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "招标药";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "商 品 名 称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "规 格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "计划购入价";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "计划数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "审核数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "审核金额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "供货公司";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "生产厂家";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "科室库存";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "全院库存";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "招标药";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 45F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "商 品 名 称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 130F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规 格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 85F;
            numberCellType1.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "计划购入价";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 68F;
            numberCellType2.DecimalPlaces = 2;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "计划数量";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "审核数量";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "单位";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 42F;
            numberCellType4.DecimalPlaces = 2;
            this.neuSpread1_Sheet1.Columns.Get(7).CellType = numberCellType4;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "审核金额";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "供货公司";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "生产厂家";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(11).CellType = numberCellType5;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "科室库存";
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(12).CellType = numberCellType6;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "全院库存";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 80F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.ForeColor = System.Drawing.Color.Blue;
            this.lbCost.Location = new System.Drawing.Point(448, 32);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(53, 12);
            this.lbCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCost.TabIndex = 4;
            this.lbCost.Text = "计划金额";
            // 
            // lbPlanBill
            // 
            this.lbPlanBill.AutoSize = true;
            this.lbPlanBill.Location = new System.Drawing.Point(310, 32);
            this.lbPlanBill.Name = "lbPlanBill";
            this.lbPlanBill.Size = new System.Drawing.Size(41, 12);
            this.lbPlanBill.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPlanBill.TabIndex = 3;
            this.lbPlanBill.Text = "单据号";
            // 
            // lbPlanInfo
            // 
            this.lbPlanInfo.AutoSize = true;
            this.lbPlanInfo.Location = new System.Drawing.Point(3, 32);
            this.lbPlanInfo.Name = "lbPlanInfo";
            this.lbPlanInfo.Size = new System.Drawing.Size(95, 12);
            this.lbPlanInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPlanInfo.TabIndex = 2;
            this.lbPlanInfo.Text = "计划科室 计划人";
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(755, 32);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "采 购 单 ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tbStockHistory);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(755, 106);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            // 
            // tbStockHistory
            // 
            this.tbStockHistory.Controls.Add(this.fpSpread2);
            this.tbStockHistory.Location = new System.Drawing.Point(4, 21);
            this.tbStockHistory.Name = "tbStockHistory";
            this.tbStockHistory.Size = new System.Drawing.Size(747, 81);
            this.tbStockHistory.TabIndex = 0;
            this.tbStockHistory.Text = "历史采购计划信息";
            this.tbStockHistory.UseVisualStyleBackColor = true;
            // 
            // fpSpread2
            // 
            this.fpSpread2.About = "2.5.2007.2005";
            this.fpSpread2.AccessibleDescription = "fpSpread2";
            this.fpSpread2.BackColor = System.Drawing.Color.Transparent;
            this.fpSpread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread2.EditModePermanent = true;
            this.fpSpread2.EditModeReplace = true;
            this.fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread2.Location = new System.Drawing.Point(0, 0);
            this.fpSpread2.Name = "fpSpread2";
            this.fpSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread2_Sheet1});
            this.fpSpread2.Size = new System.Drawing.Size(747, 81);
            this.fpSpread2.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread2.TextTipAppearance = tipAppearance2;
            this.fpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread2_Sheet1
            // 
            this.fpSpread2_Sheet1.Reset();
            this.fpSpread2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread2_Sheet1.ColumnCount = 9;
            this.fpSpread2_Sheet1.RowCount = 0;
            this.fpSpread2_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "招标药";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "采购日期";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "采购数量";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "单位";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "购入价";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "零售价";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "供货公司";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "生产厂家";
            this.fpSpread2_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "备注";
            this.fpSpread2_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread2_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread2_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread2_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.fpSpread2_Sheet1.Columns.Get(0).Label = "招标药";
            this.fpSpread2_Sheet1.Columns.Get(0).Width = 46F;
            this.fpSpread2_Sheet1.Columns.Get(1).Label = "采购日期";
            this.fpSpread2_Sheet1.Columns.Get(1).Width = 110F;
            numberCellType7.DecimalPlaces = 2;
            this.fpSpread2_Sheet1.Columns.Get(2).CellType = numberCellType7;
            this.fpSpread2_Sheet1.Columns.Get(2).Label = "采购数量";
            this.fpSpread2_Sheet1.Columns.Get(2).Width = 75F;
            this.fpSpread2_Sheet1.Columns.Get(3).Label = "单位";
            this.fpSpread2_Sheet1.Columns.Get(3).Width = 35F;
            numberCellType8.DecimalPlaces = 2;
            this.fpSpread2_Sheet1.Columns.Get(4).CellType = numberCellType8;
            this.fpSpread2_Sheet1.Columns.Get(4).Label = "购入价";
            this.fpSpread2_Sheet1.Columns.Get(4).Width = 70F;
            numberCellType9.DecimalPlaces = 2;
            this.fpSpread2_Sheet1.Columns.Get(5).CellType = numberCellType9;
            this.fpSpread2_Sheet1.Columns.Get(5).Label = "零售价";
            this.fpSpread2_Sheet1.Columns.Get(5).Width = 70F;
            this.fpSpread2_Sheet1.Columns.Get(6).Label = "供货公司";
            this.fpSpread2_Sheet1.Columns.Get(6).Width = 100F;
            this.fpSpread2_Sheet1.Columns.Get(7).Label = "生产厂家";
            this.fpSpread2_Sheet1.Columns.Get(7).Width = 100F;
            this.fpSpread2_Sheet1.Columns.Get(8).Label = "备注";
            this.fpSpread2_Sheet1.Columns.Get(8).Width = 76F;
            this.fpSpread2_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread2_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread2_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread2_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread2_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread2_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread2_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread2_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread2.SetActiveViewport(1, 0);
            // 
            // ucStockPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucStockPlan";
            this.Size = new System.Drawing.Size(755, 459);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuTabControl1.ResumeLayout(false);
            this.tbStockHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanBill;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCost;
        private FarPoint.Win.Spread.FpSpread fpSpread2;
        private FarPoint.Win.Spread.SheetView fpSpread2_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tbStockHistory;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
