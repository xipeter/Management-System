namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMatKindMain
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.chbMisty = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.txtInputCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.ucMaterialKindTree1 = new Neusoft.HISFC.Components.Material.Base.ucMaterialKindTree();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            this.neuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucMaterialKindTree1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(171, 509);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(171, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 509);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Controls.Add(this.neuPanel3);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(174, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(530, 509);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 43);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(530, 466);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            this.neuSpread1.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.neuSpread1_LeaveCell);
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.chbMisty);
            this.neuPanel3.Controls.Add(this.txtInputCode);
            this.neuPanel3.Controls.Add(this.neuLabel1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel3.Location = new System.Drawing.Point(0, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(530, 43);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 0;
            // 
            // chbMisty
            // 
            this.chbMisty.AutoSize = true;
            this.chbMisty.ForeColor = System.Drawing.Color.Blue;
            this.chbMisty.Location = new System.Drawing.Point(221, 13);
            this.chbMisty.Name = "chbMisty";
            this.chbMisty.Size = new System.Drawing.Size(72, 16);
            this.chbMisty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbMisty.TabIndex = 14;
            this.chbMisty.Text = "模糊查询";
            this.chbMisty.UseVisualStyleBackColor = true;
            this.chbMisty.Visible = false;
            // 
            // txtInputCode
            // 
            this.txtInputCode.IsEnter2Tab = false;
            this.txtInputCode.Location = new System.Drawing.Point(55, 10);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(143, 21);
            this.txtInputCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInputCode.TabIndex = 13;
            this.txtInputCode.TextChanged += new System.EventHandler(this.txtInputCode_TextChanged);
            this.txtInputCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInputCode_KeyUp);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(6, 14);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(47, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 12;
            this.neuLabel1.Text = "检索码:";
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
            this.neuSpread1_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(16).AllowAutoSort = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 39F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucMaterialKindTree1
            // 
            this.ucMaterialKindTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaterialKindTree1.Location = new System.Drawing.Point(0, 0);
            this.ucMaterialKindTree1.Name = "ucMaterialKindTree1";
            this.ucMaterialKindTree1.NodeName = null;
            this.ucMaterialKindTree1.NodeTag = null;
            this.ucMaterialKindTree1.Size = new System.Drawing.Size(171, 509);
            this.ucMaterialKindTree1.TabIndex = 0;
            this.ucMaterialKindTree1.GetLak += new Neusoft.HISFC.Components.Material.Base.ucMaterialKindTree.GetLevelAndKind(this.ucMaterialKindTree1_GetLak);
            // 
            // ucMatKindMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucMatKindMain";
            this.Size = new System.Drawing.Size(704, 509);
            this.Load += new System.EventHandler(this.ucMatKindMain_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private ucMaterialKindTree ucMaterialKindTree1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        protected Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbMisty;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInputCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
