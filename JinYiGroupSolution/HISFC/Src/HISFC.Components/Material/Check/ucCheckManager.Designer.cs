namespace Neusoft.HISFC.Components.Material.Check
{
    partial class ucCheckManager
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuCheckBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucMaterialItemList1 = new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.neuTextBox1);
            this.neuPanel1.Controls.Add(this.neuCheckBox1);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(677, 38);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(301, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(173, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "红色调亏 蓝色调盈 黑色无盈亏";
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.IsEnter2Tab = false;
            this.neuTextBox1.Location = new System.Drawing.Point(63, 8);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(130, 21);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 2;
            this.neuTextBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.neuTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // neuCheckBox1
            // 
            this.neuCheckBox1.AutoSize = true;
            this.neuCheckBox1.ForeColor = System.Drawing.Color.Blue;
            this.neuCheckBox1.Location = new System.Drawing.Point(199, 11);
            this.neuCheckBox1.Name = "neuCheckBox1";
            this.neuCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.neuCheckBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox1.TabIndex = 1;
            this.neuCheckBox1.Text = "模糊查询";
            this.neuCheckBox1.UseVisualStyleBackColor = true;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(15, 12);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(47, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "查询框:";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Controls.Add(this.lbTitle);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuPanel2.Location = new System.Drawing.Point(0, 38);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(677, 510);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 31);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(677, 479);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.neuSpread1.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpSpread1_LeaveCell);
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
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns.Get(15).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
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
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(677, 31);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "                       盘  点  单";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucMaterialItemList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(882, 548);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 2;
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
            this.ucMaterialItemList1.Size = new System.Drawing.Size(201, 548);
            this.ucMaterialItemList1.TabIndex = 0;
            this.ucMaterialItemList1.ChooseDataEvent += new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList.ChooseDataHandler(this.ucMaterialItemList1_ChooseDataEvent);
            // 
            // ucCheckManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucCheckManager";
            this.Size = new System.Drawing.Size(882, 548);
            this.Load += new System.EventHandler(this.ucCheckManager_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.HISFC.Components.Material.Base.ucMaterialItemList ucMaterialItemList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
