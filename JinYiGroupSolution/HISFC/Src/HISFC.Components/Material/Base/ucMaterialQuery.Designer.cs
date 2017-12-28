namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMaterialQuery
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
            this.prePanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpMaterialQuery = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpMaterialQuery_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.prePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMaterialQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMaterialQuery_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // prePanel
            // 
            this.prePanel.Controls.Add(this.fpMaterialQuery);
            this.prePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prePanel.Location = new System.Drawing.Point(0, 0);
            this.prePanel.Name = "prePanel";
            this.prePanel.Size = new System.Drawing.Size(648, 391);
            this.prePanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.prePanel.TabIndex = 0;
            // 
            // fpMaterialQuery
            // 
            this.fpMaterialQuery.About = "2.5.2007.2005";
            this.fpMaterialQuery.AccessibleDescription = "";
            this.fpMaterialQuery.BackColor = System.Drawing.Color.White;
            this.fpMaterialQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMaterialQuery.FileName = "";
            this.fpMaterialQuery.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMaterialQuery.IsAutoSaveGridStatus = false;
            this.fpMaterialQuery.IsCanCustomConfigColumn = false;
            this.fpMaterialQuery.Location = new System.Drawing.Point(0, 0);
            this.fpMaterialQuery.Name = "fpMaterialQuery";
            this.fpMaterialQuery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpMaterialQuery_Sheet1});
            this.fpMaterialQuery.Size = new System.Drawing.Size(648, 391);
            this.fpMaterialQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpMaterialQuery.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMaterialQuery.TextTipAppearance = tipAppearance1;
            this.fpMaterialQuery.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMaterialQuery.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMaterialQuery_CellDoubleClick);
            // 
            // fpMaterialQuery_Sheet1
            // 
            this.fpMaterialQuery_Sheet1.Reset();
            this.fpMaterialQuery_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpMaterialQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpMaterialQuery_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpMaterialQuery_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMaterialQuery_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpMaterialQuery_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMaterialQuery_Sheet1.DefaultStyle.Locked = true;
            this.fpMaterialQuery_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpMaterialQuery_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpMaterialQuery_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpMaterialQuery_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMaterialQuery_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpMaterialQuery_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMaterialQuery_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpMaterialQuery_Sheet1.SheetCornerStyle.Locked = false;
            this.fpMaterialQuery_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpMaterialQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucMaterialQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prePanel);
            this.Name = "ucMaterialQuery";
            this.Size = new System.Drawing.Size(648, 391);
            this.prePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpMaterialQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMaterialQuery_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel prePanel;
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread fpMaterialQuery;
        public FarPoint.Win.Spread.SheetView fpMaterialQuery_Sheet1;
    }
}
