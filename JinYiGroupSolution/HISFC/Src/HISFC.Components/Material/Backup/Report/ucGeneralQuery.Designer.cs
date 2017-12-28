namespace Neusoft.HISFC.Components.Material.Report
{
    partial class ucGeneralQuery
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvDept = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.tvOper = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTotal = new System.Windows.Forms.TabPage();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbSubTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tpDetail = new System.Windows.Forms.TabPage();
            this.neuSpread2 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTotal.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.tvOper);
            this.neuPanel1.Controls.Add(this.tvDept);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(153, 438);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tvDept.HideSelection = false;
            this.tvDept.Location = new System.Drawing.Point(0, 244);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(153, 194);
            this.tvDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDept.TabIndex = 1;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            // 
            // tvOper
            // 
            this.tvOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOper.HideSelection = false;
            this.tvOper.Location = new System.Drawing.Point(0, 0);
            this.tvOper.Name = "tvOper";
            this.tvOper.Size = new System.Drawing.Size(153, 244);
            this.tvOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvOper.TabIndex = 0;
            this.tvOper.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOper_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(153, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 438);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTotal);
            this.tabControl1.Controls.Add(this.tpDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(156, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 438);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpTotal
            // 
            this.tpTotal.Controls.Add(this.neuPanel2);
            this.tpTotal.Controls.Add(this.neuGroupBox1);
            this.tpTotal.Location = new System.Drawing.Point(4, 21);
            this.tpTotal.Name = "tpTotal";
            this.tpTotal.Size = new System.Drawing.Size(568, 413);
            this.tpTotal.TabIndex = 0;
            this.tpTotal.Text = "汇总信息";
            this.tpTotal.UseVisualStyleBackColor = true;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Controls.Add(this.lbSubTitle);
            this.neuPanel2.Controls.Add(this.lbTitle);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 43);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(568, 370);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
            this.neuSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(2, 42);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(564, 327);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance3;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lbSubTitle
            // 
            this.lbSubTitle.AutoSize = true;
            this.lbSubTitle.Location = new System.Drawing.Point(4, 27);
            this.lbSubTitle.Name = "lbSubTitle";
            this.lbSubTitle.Size = new System.Drawing.Size(29, 12);
            this.lbSubTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbSubTitle.TabIndex = 1;
            this.lbSubTitle.Text = "日期";
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(568, 23);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "综合查询";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtFilter);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(568, 43);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.IsEnter2Tab = false;
            this.txtFilter.Location = new System.Drawing.Point(66, 15);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(184, 21);
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 1;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(6, 19);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "过 滤 框";
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.neuSpread2);
            this.tpDetail.Location = new System.Drawing.Point(4, 21);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(583, 417);
            this.tpDetail.TabIndex = 1;
            this.tpDetail.Text = "详细信息";
            this.tpDetail.UseVisualStyleBackColor = true;
            // 
            // neuSpread2
            // 
            this.neuSpread2.About = "2.5.2007.2005";
            this.neuSpread2.AccessibleDescription = "";
            this.neuSpread2.BackColor = System.Drawing.Color.White;
            this.neuSpread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread2.FileName = "";
            this.neuSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread2.IsAutoSaveGridStatus = false;
            this.neuSpread2.IsCanCustomConfigColumn = false;
            this.neuSpread2.Location = new System.Drawing.Point(0, 0);
            this.neuSpread2.Name = "neuSpread2";
            this.neuSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread2_Sheet1});
            this.neuSpread2.Size = new System.Drawing.Size(583, 417);
            this.neuSpread2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread2.TabIndex = 0;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread2.TextTipAppearance = tipAppearance4;
            this.neuSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread2_Sheet1
            // 
            this.neuSpread2_Sheet1.Reset();
            this.neuSpread2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread2_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread2_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread2_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread2_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread2_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread2_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread2_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread2_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread2_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread2_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread2_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread2_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucGeneralQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucGeneralQuery";
            this.Size = new System.Drawing.Size(732, 438);
            this.Load += new System.EventHandler(this.ucGeneralQuery_Load);
            this.neuPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpTotal.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvDept;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTotal;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private System.Windows.Forms.TabPage tpDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbSubTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread2;
        private FarPoint.Win.Spread.SheetView neuSpread2_Sheet1;
    }
}
