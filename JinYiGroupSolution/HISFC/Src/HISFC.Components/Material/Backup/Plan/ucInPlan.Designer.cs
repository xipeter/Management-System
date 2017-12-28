namespace Neusoft.HISFC.Components.Material.Plan
{
    partial class ucInPlan
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
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.lbPlanBill = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPlanInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucMaterialItemList1 = new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList();
            this.neuGroupBox1.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.IsEnter2Tab = false;
            this.txtFilter.Location = new System.Drawing.Point(64, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(150, 21);
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // lbPlanBill
            // 
            this.lbPlanBill.AutoSize = true;
            this.lbPlanBill.Location = new System.Drawing.Point(343, 54);
            this.lbPlanBill.Name = "lbPlanBill";
            this.lbPlanBill.Size = new System.Drawing.Size(41, 12);
            this.lbPlanBill.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPlanBill.TabIndex = 1;
            this.lbPlanBill.Text = "单据号";
            // 
            // lbPlanInfo
            // 
            this.lbPlanInfo.AutoSize = true;
            this.lbPlanInfo.Location = new System.Drawing.Point(27, 54);
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
            this.lbTitle.Location = new System.Drawing.Point(220, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(208, 34);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "入 库 计 划 单";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 16);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "过 滤 框";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtFilter);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(675, 38);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSpread1);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 38);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(675, 533);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.EditModePermanent = true;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.Location = new System.Drawing.Point(0, 82);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.SelectNone = false;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2});
            this.neuSpread1.ShowListWhenOfFocus = false;
            this.neuSpread1.Size = new System.Drawing.Size(675, 451);
            this.neuSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(this.neuSpread1_SetItem);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            this.neuSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.neuSpread1_Change);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "汇总";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset();
            this.neuSpread1_Sheet2.SheetName = "明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet2.Visible = false;
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.lbTitle);
            this.neuPanel2.Controls.Add(this.lbPlanBill);
            this.neuPanel2.Controls.Add(this.lbCost);
            this.neuPanel2.Controls.Add(this.lbPlanInfo);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(675, 82);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.ForeColor = System.Drawing.Color.Blue;
            this.lbCost.Location = new System.Drawing.Point(503, 54);
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
            this.splitContainer1.Panel1.Controls.Add(this.ucMaterialItemList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.neuGroupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(853, 571);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucMaterialItemList1
            // 
            this.ucMaterialItemList1.DataTable = null;
            this.ucMaterialItemList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaterialItemList1.FilterField = null;
            this.ucMaterialItemList1.Location = new System.Drawing.Point(0, 0);
            this.ucMaterialItemList1.Name = "ucMaterialItemList1";
            this.ucMaterialItemList1.ShowStop = false;
            this.ucMaterialItemList1.ShowTreeView = false;
            this.ucMaterialItemList1.Size = new System.Drawing.Size(174, 571);
            this.ucMaterialItemList1.TabIndex = 0;
            this.ucMaterialItemList1.ChooseDataEvent += new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList.ChooseDataHandler(this.ucMaterialItemList1_ChooseDataEvent);
            // 
            // ucInPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucInPlan";
            this.Size = new System.Drawing.Size(853, 571);
            this.Load += new System.EventHandler(this.ucInPlan_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanBill;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPlanInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCost;
        //private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private Material.Base.ucMaterialItemList ucMaterialItemList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
    }
}
