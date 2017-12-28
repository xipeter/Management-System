namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMatAddRate
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
            this.pnlTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvRateKind = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.FpAddRate = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.FpAddRate_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTree.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpAddRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpAddRate_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTree
            // 
            this.pnlTree.Controls.Add(this.tvRateKind);
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(155, 390);
            this.pnlTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlTree.TabIndex = 0;
            // 
            // tvRateKind
            // 
            this.tvRateKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRateKind.HideSelection = false;
            this.tvRateKind.Location = new System.Drawing.Point(0, 0);
            this.tvRateKind.Name = "tvRateKind";
            this.tvRateKind.Size = new System.Drawing.Size(155, 390);
            this.tvRateKind.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvRateKind.TabIndex = 0;
            this.tvRateKind.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRateKind_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(155, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 390);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.FpAddRate);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(158, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(469, 390);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 2;
            // 
            // FpAddRate
            // 
            this.FpAddRate.About = "2.5.2007.2005";
            this.FpAddRate.AccessibleDescription = "FpAddRate, Sheet1, Row 0, Column 0, ";
            this.FpAddRate.BackColor = System.Drawing.SystemColors.Control;
            this.FpAddRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FpAddRate.EditModePermanent = true;
            this.FpAddRate.EditModeReplace = true;
            this.FpAddRate.Location = new System.Drawing.Point(0, 0);
            this.FpAddRate.Name = "FpAddRate";
            this.FpAddRate.SelectNone = false;
            this.FpAddRate.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.FpAddRate_Sheet1});
            this.FpAddRate.ShowListWhenOfFocus = false;
            this.FpAddRate.Size = new System.Drawing.Size(469, 390);
            this.FpAddRate.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FpAddRate.TextTipAppearance = tipAppearance1;
            this.FpAddRate.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.FpAddRate_EditChange);
            // 
            // FpAddRate_Sheet1
            // 
            this.FpAddRate_Sheet1.Reset();
            this.FpAddRate_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.FpAddRate_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.FpAddRate_Sheet1.ColumnCount = 11;
            this.FpAddRate_Sheet1.RowCount = 0;
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "RowStatus";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "序号";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "加价方式";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "规格";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "起始价格";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "终止价格";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "加价率";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "附加费";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "操作员";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "操作日期";
            this.FpAddRate_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "物品分类";
            this.FpAddRate_Sheet1.Columns.Get(0).Label = "RowStatus";
            this.FpAddRate_Sheet1.Columns.Get(0).Width = 66F;
            this.FpAddRate_Sheet1.Columns.Get(2).Label = "加价方式";
            this.FpAddRate_Sheet1.Columns.Get(2).Width = 100F;
            this.FpAddRate_Sheet1.Columns.Get(3).Label = "规格";
            this.FpAddRate_Sheet1.Columns.Get(3).Width = 100F;
            this.FpAddRate_Sheet1.Columns.Get(4).Label = "起始价格";
            this.FpAddRate_Sheet1.Columns.Get(4).Width = 80F;
            this.FpAddRate_Sheet1.Columns.Get(5).Label = "终止价格";
            this.FpAddRate_Sheet1.Columns.Get(5).Width = 80F;
            this.FpAddRate_Sheet1.Columns.Get(7).Label = "附加费";
            this.FpAddRate_Sheet1.Columns.Get(7).Width = 80F;
            this.FpAddRate_Sheet1.Columns.Get(8).Label = "操作员";
            this.FpAddRate_Sheet1.Columns.Get(8).Width = 80F;
            this.FpAddRate_Sheet1.Columns.Get(9).Label = "操作日期";
            this.FpAddRate_Sheet1.Columns.Get(9).Width = 100F;
            this.FpAddRate_Sheet1.Columns.Get(10).Label = "物品分类";
            this.FpAddRate_Sheet1.Columns.Get(10).Width = 100F;
            this.FpAddRate_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.FpAddRate_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.FpAddRate_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.FpAddRate.SetActiveViewport(1, 0);
            // 
            // ucMatAddRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.pnlTree);
            this.Name = "ucMatAddRate";
            this.Size = new System.Drawing.Size(627, 390);
            this.Load += new System.EventHandler(this.ucMatAddRate_Load);
            this.pnlTree.ResumeLayout(false);
            this.neuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FpAddRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpAddRate_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlTree;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter FpAddRate;
        private FarPoint.Win.Spread.SheetView FpAddRate_Sheet1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvRateKind;
    }
}
