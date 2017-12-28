namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucDrugLimitMaintenance
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucDrugList1 = new Neusoft.HISFC.Components.Common.Controls.ucDrugList();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpOrderDrugLimit = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpOrderDrugLimit_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpOrderDrugLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpOrderDrugLimit_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucDrugList1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(233, 499);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // ucDrugList1
            // 
            this.ucDrugList1.DataTable = null;
            this.ucDrugList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugList1.FilterField = null;
            this.ucDrugList1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugList1.Name = "ucDrugList1";
            this.ucDrugList1.ShowTreeView = false;
            this.ucDrugList1.Size = new System.Drawing.Size(233, 499);
            this.ucDrugList1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(233, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 499);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.fpOrderDrugLimit);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(236, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(445, 499);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // fpOrderDrugLimit
            // 
            this.fpOrderDrugLimit.About = "2.5.2007.2005";
            this.fpOrderDrugLimit.AccessibleDescription = "fpOrderDrugLimit";
            this.fpOrderDrugLimit.BackColor = System.Drawing.Color.White;
            this.fpOrderDrugLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpOrderDrugLimit.FileName = "";
            this.fpOrderDrugLimit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpOrderDrugLimit.IsAutoSaveGridStatus = false;
            this.fpOrderDrugLimit.IsCanCustomConfigColumn = false;
            this.fpOrderDrugLimit.Location = new System.Drawing.Point(0, 0);
            this.fpOrderDrugLimit.Name = "fpOrderDrugLimit";
            this.fpOrderDrugLimit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpOrderDrugLimit_Sheet1});
            this.fpOrderDrugLimit.Size = new System.Drawing.Size(445, 499);
            this.fpOrderDrugLimit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpOrderDrugLimit.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpOrderDrugLimit.TextTipAppearance = tipAppearance1;
            this.fpOrderDrugLimit.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpOrderDrugLimit_Sheet1
            // 
            this.fpOrderDrugLimit_Sheet1.Reset();
            this.fpOrderDrugLimit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpOrderDrugLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpOrderDrugLimit_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpOrderDrugLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucDrugLimitMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucDrugLimitMaintenance";
            this.Size = new System.Drawing.Size(681, 499);
            this.Load += new System.EventHandler(this.ucDrugLimitMaintenance_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpOrderDrugLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpOrderDrugLimit_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.HISFC.Components.Common.Controls.ucDrugList ucDrugList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpOrderDrugLimit;
        private FarPoint.Win.Spread.SheetView fpOrderDrugLimit_Sheet1;
    }
}
