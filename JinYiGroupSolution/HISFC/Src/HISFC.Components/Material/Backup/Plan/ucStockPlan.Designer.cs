namespace Neusoft.HISFC.Components.Material.Plan
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStockPlan));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.lbPlanBill = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPlanInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpStockApprove = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbStockHistory = new System.Windows.Forms.TabPage();
            this.fpHistory = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.tvList = new Neusoft.HISFC.Components.Material.Plan.tvPlanList(this.components);
            this.fpStockApprove_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpStockApprove)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbStockHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpStockApprove_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPlanBill
            // 
            this.lbPlanBill.AutoSize = true;
            this.lbPlanBill.Location = new System.Drawing.Point(260, 53);
            this.lbPlanBill.Name = "lbPlanBill";
            this.lbPlanBill.Size = new System.Drawing.Size(41, 12);
            this.lbPlanBill.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPlanBill.TabIndex = 1;
            this.lbPlanBill.Text = "单据号";
            // 
            // lbPlanInfo
            // 
            this.lbPlanInfo.AutoSize = true;
            this.lbPlanInfo.Location = new System.Drawing.Point(17, 53);
            this.lbPlanInfo.Name = "lbPlanInfo";
            this.lbPlanInfo.Size = new System.Drawing.Size(131, 12);
            this.lbPlanInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPlanInfo.TabIndex = 1;
            this.lbPlanInfo.Text = "计划科室{0} 计划人{1}";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTitle.Location = new System.Drawing.Point(277, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(248, 27);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "采 购 单";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.fpStockApprove);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(713, 348);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // fpStockApprove
            // 
            this.fpStockApprove.About = "2.5.2007.2005";
            this.fpStockApprove.AccessibleDescription = "fpStockApprove";
            this.fpStockApprove.BackColor = System.Drawing.Color.White;
            this.fpStockApprove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpStockApprove.FileName = "";
            this.fpStockApprove.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpStockApprove.IsAutoSaveGridStatus = false;
            this.fpStockApprove.IsCanCustomConfigColumn = false;
            this.fpStockApprove.Location = new System.Drawing.Point(0, 77);
            this.fpStockApprove.Name = "fpStockApprove";
            this.fpStockApprove.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpStockApprove_Sheet1});
            this.fpStockApprove.Size = new System.Drawing.Size(713, 271);
            this.fpStockApprove.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpStockApprove.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpStockApprove.TextTipAppearance = tipAppearance1;
            this.fpStockApprove.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpStockApprove.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpStockApprove_CellDoubleClick);
            this.fpStockApprove.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpStockApprove_CellClick);
            this.fpStockApprove.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpStockApprove_SelectionChanged);
            this.fpStockApprove.EditModeOff += new System.EventHandler(this.fpStockApprove_EditModeOff);
            this.fpStockApprove.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpStockApprove_Change);
            this.fpStockApprove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fpStockApprove_KeyPress);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.lbTitle);
            this.neuPanel2.Controls.Add(this.lbCost);
            this.neuPanel2.Controls.Add(this.lbPlanInfo);
            this.neuPanel2.Controls.Add(this.lbPlanBill);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(713, 77);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.ForeColor = System.Drawing.Color.Blue;
            this.lbCost.Location = new System.Drawing.Point(452, 53);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(53, 12);
            this.lbCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCost.TabIndex = 3;
            this.lbCost.Text = "计划金额";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(887, 501);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbStockHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 348);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 153);
            this.tabControl1.TabIndex = 2;
            // 
            // tbStockHistory
            // 
            this.tbStockHistory.Controls.Add(this.fpHistory);
            this.tbStockHistory.Location = new System.Drawing.Point(4, 21);
            this.tbStockHistory.Name = "tbStockHistory";
            this.tbStockHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tbStockHistory.Size = new System.Drawing.Size(705, 128);
            this.tbStockHistory.TabIndex = 0;
            this.tbStockHistory.Text = "历史采购计划信息";
            this.tbStockHistory.UseVisualStyleBackColor = true;
            // 
            // fpHistory
            // 
            this.fpHistory.About = "2.5.2007.2005";
            this.fpHistory.AccessibleDescription = "fpHistory, Sheet1, Row 0, Column 0, ";
            this.fpHistory.BackColor = System.Drawing.Color.White;
            this.fpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpHistory.FileName = "";
            this.fpHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpHistory.IsAutoSaveGridStatus = false;
            this.fpHistory.IsCanCustomConfigColumn = false;
            this.fpHistory.Location = new System.Drawing.Point(3, 3);
            this.fpHistory.Name = "fpHistory";
            this.fpHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpHistory_Sheet1});
            this.fpHistory.Size = new System.Drawing.Size(699, 122);
            this.fpHistory.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpHistory.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpHistory.TextTipAppearance = tipAppearance2;
            this.fpHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.HideSelection = false;
            this.tvList.Location = new System.Drawing.Point(0, 0);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(170, 501);
            this.tvList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // fpStockApprove_Sheet1
            // 
            this.fpStockApprove_Sheet1.Reset();
            this.fpStockApprove_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpStockApprove_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpStockApprove_Sheet1.ColumnCount = 11;
            this.fpStockApprove_Sheet1.RowCount = 0;
            this.fpStockApprove_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "物品名称";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规 格";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "计划购入价";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "计划数量";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "单位";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "审核金额";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "供货公司";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "生产厂家";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "备注";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "科室库存";
            this.fpStockApprove_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "全院库存";
            this.fpStockApprove_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpStockApprove_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpStockApprove_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpStockApprove_Sheet1.Columns.Get(0).Label = "物品名称";
            this.fpStockApprove_Sheet1.Columns.Get(0).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(0).Width = 100F;
            this.fpStockApprove_Sheet1.Columns.Get(1).Label = "规 格";
            this.fpStockApprove_Sheet1.Columns.Get(1).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.SeaShell;
            this.fpStockApprove_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.fpStockApprove_Sheet1.Columns.Get(2).Label = "计划购入价";
            this.fpStockApprove_Sheet1.Columns.Get(2).Width = 75F;
            this.fpStockApprove_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.SeaShell;
            this.fpStockApprove_Sheet1.Columns.Get(3).CellType = numberCellType2;
            this.fpStockApprove_Sheet1.Columns.Get(3).Label = "计划数量";
            this.fpStockApprove_Sheet1.Columns.Get(3).Width = 70F;
            this.fpStockApprove_Sheet1.Columns.Get(4).Label = "单位";
            this.fpStockApprove_Sheet1.Columns.Get(4).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(5).Label = "审核金额";
            this.fpStockApprove_Sheet1.Columns.Get(5).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.SeaShell;
            this.fpStockApprove_Sheet1.Columns.Get(6).Label = "供货公司";
            this.fpStockApprove_Sheet1.Columns.Get(6).Width = 100F;
            this.fpStockApprove_Sheet1.Columns.Get(7).Label = "生产厂家";
            this.fpStockApprove_Sheet1.Columns.Get(7).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(7).Width = 100F;
            this.fpStockApprove_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.SeaShell;
            this.fpStockApprove_Sheet1.Columns.Get(8).Label = "备注";
            this.fpStockApprove_Sheet1.Columns.Get(8).Width = 100F;
            this.fpStockApprove_Sheet1.Columns.Get(9).Label = "科室库存";
            this.fpStockApprove_Sheet1.Columns.Get(9).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(9).Width = 70F;
            this.fpStockApprove_Sheet1.Columns.Get(10).Label = "全院库存";
            this.fpStockApprove_Sheet1.Columns.Get(10).Locked = true;
            this.fpStockApprove_Sheet1.Columns.Get(10).Width = 70F;
            this.fpStockApprove_Sheet1.DataAutoSizeColumns = false;
            this.fpStockApprove_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpStockApprove_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpStockApprove_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpStockApprove_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpStockApprove_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpStockApprove_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpStockApprove_Sheet1.SheetCornerStyle.Locked = false;
            this.fpStockApprove_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpStockApprove_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpStockApprove.SetActiveViewport(1, 0);
            // 
            // fpHistory_Sheet1
            // 
            this.fpHistory_Sheet1.Reset();
            this.fpHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpHistory_Sheet1.ColumnCount = 7;
            this.fpHistory_Sheet1.RowCount = 0;
            this.fpHistory_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "入库日期";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "采购数量";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "单位";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "购入价";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "供货公司";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "生产厂家";
            this.fpHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "备注";
            this.fpHistory_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHistory_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 11, 18, 20, 0, 59, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 11, 18, 20, 0, 59, 0);
            this.fpHistory_Sheet1.Columns.Get(0).CellType = dateTimeCellType1;
            this.fpHistory_Sheet1.Columns.Get(0).Label = "入库日期";
            this.fpHistory_Sheet1.Columns.Get(0).Width = 120F;
            this.fpHistory_Sheet1.Columns.Get(1).CellType = numberCellType3;
            this.fpHistory_Sheet1.Columns.Get(1).Label = "采购数量";
            this.fpHistory_Sheet1.Columns.Get(1).Width = 70F;
            this.fpHistory_Sheet1.Columns.Get(3).CellType = numberCellType4;
            this.fpHistory_Sheet1.Columns.Get(3).Label = "购入价";
            this.fpHistory_Sheet1.Columns.Get(3).Width = 70F;
            this.fpHistory_Sheet1.Columns.Get(4).Label = "供货公司";
            this.fpHistory_Sheet1.Columns.Get(4).Width = 100F;
            this.fpHistory_Sheet1.Columns.Get(5).Label = "生产厂家";
            this.fpHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.fpHistory_Sheet1.Columns.Get(6).Label = "备注";
            this.fpHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.fpHistory_Sheet1.DefaultStyle.Locked = true;
            this.fpHistory_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpHistory_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpHistory_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHistory_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpHistory_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHistory_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpHistory_Sheet1.SheetCornerStyle.Locked = false;
            this.fpHistory_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpHistory.SetActiveViewport(1, 0);
            // 
            // ucStockPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucStockPlan";
            this.Size = new System.Drawing.Size(887, 501);
            this.Load += new System.EventHandler(this.ucStockPlan_Load);
            this.neuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpStockApprove)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbStockHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpStockApprove_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanBill;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpStockApprove;
        private FarPoint.Win.Spread.SheetView fpStockApprove_Sheet1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbStockHistory;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpHistory;
        private FarPoint.Win.Spread.SheetView fpHistory_Sheet1;
        private tvPlanList tvList;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
    }
}
