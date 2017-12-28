namespace Neusoft.HISFC.Components.Preparation
{
    partial class ucExpand
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fsMaterial = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsMaterial_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.gbControl = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsMaterial_Sheet1)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(608, 210);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fsMaterial);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 185);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生产原料、辅料信息  － 修改消耗信息后请注意保存";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fsMaterial
            // 
            this.fsMaterial.About = "2.5.2007.2005";
            this.fsMaterial.AccessibleDescription = "fsMaterial, Sheet1, Row 0, Column 0, ";
            this.fsMaterial.BackColor = System.Drawing.Color.White;
            this.fsMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsMaterial.EditModeReplace = true;
            this.fsMaterial.FileName = "";
            this.fsMaterial.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsMaterial.IsAutoSaveGridStatus = false;
            this.fsMaterial.IsCanCustomConfigColumn = false;
            this.fsMaterial.Location = new System.Drawing.Point(0, 0);
            this.fsMaterial.Name = "fsMaterial";
            this.fsMaterial.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsMaterial_Sheet1});
            this.fsMaterial.Size = new System.Drawing.Size(600, 185);
            this.fsMaterial.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsMaterial.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsMaterial.TextTipAppearance = tipAppearance1;
            this.fsMaterial.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fsMaterial_Sheet1
            // 
            this.fsMaterial_Sheet1.Reset();
            this.fsMaterial_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsMaterial_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsMaterial_Sheet1.ColumnCount = 8;
            this.fsMaterial_Sheet1.RowCount = 0;
            this.fsMaterial_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "原料名称";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "单价";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "标准处方量[单位]";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "理论消耗量[单位]";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "库存量[单位]";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "实际消耗量[单位]";
            this.fsMaterial_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "备注";
            this.fsMaterial_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsMaterial_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsMaterial_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsMaterial_Sheet1.Columns.Get(0).Label = "原料名称";
            this.fsMaterial_Sheet1.Columns.Get(0).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(0).Width = 120F;
            this.fsMaterial_Sheet1.Columns.Get(1).Label = "规格";
            this.fsMaterial_Sheet1.Columns.Get(1).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(1).Width = 80F;
            this.fsMaterial_Sheet1.Columns.Get(2).Label = "单价";
            this.fsMaterial_Sheet1.Columns.Get(2).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fsMaterial_Sheet1.Columns.Get(3).Label = "标准处方量[单位]";
            this.fsMaterial_Sheet1.Columns.Get(3).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(3).Width = 105F;
            this.fsMaterial_Sheet1.Columns.Get(4).Label = "理论消耗量[单位]";
            this.fsMaterial_Sheet1.Columns.Get(4).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(4).Width = 108F;
            this.fsMaterial_Sheet1.Columns.Get(5).Label = "库存量[单位]";
            this.fsMaterial_Sheet1.Columns.Get(5).Locked = true;
            this.fsMaterial_Sheet1.Columns.Get(5).Width = 86F;
            this.fsMaterial_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.SeaShell;
            this.fsMaterial_Sheet1.Columns.Get(6).CellType = numberCellType2;
            this.fsMaterial_Sheet1.Columns.Get(6).Label = "实际消耗量[单位]";
            this.fsMaterial_Sheet1.Columns.Get(6).Width = 105F;
            this.fsMaterial_Sheet1.Columns.Get(7).Label = "备注";
            this.fsMaterial_Sheet1.Columns.Get(7).Width = 119F;
            this.fsMaterial_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fsMaterial_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsMaterial_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fsMaterial_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsMaterial_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsMaterial_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsMaterial_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsMaterial_Sheet1.SheetCornerStyle.Locked = false;
            this.fsMaterial_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsMaterial_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fsMaterial.SetActiveViewport(1, 0);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.neuLabel2);
            this.gbControl.Controls.Add(this.neuLabel1);
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbControl.Location = new System.Drawing.Point(0, 210);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(608, 35);
            this.gbControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(420, 14);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(35, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "－－>";
            // 
            // neuLabel1
            // 
            this.neuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(151, 14);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(263, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "保存本次录入的实际消耗量信息 不进行库存扣除";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(461, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "消耗信息设置保存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucExpand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuTabControl1);
            this.Controls.Add(this.gbControl);
            this.Name = "ucExpand";
            this.Size = new System.Drawing.Size(608, 245);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsMaterial_Sheet1)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsMaterial;
        private FarPoint.Win.Spread.SheetView fsMaterial_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbControl;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
