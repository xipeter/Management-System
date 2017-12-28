namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucSubtblManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSubtblManager));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.panelItem = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtUnit = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtQty = new Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucInputItem1 = new Neusoft.HISFC.Components.Common.Controls.ucInputItem();
            this.panelMain = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.Spread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.sheetView1 = new FarPoint.Win.Spread.SheetView();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnDelete = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.panelItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.White;
            this.panelItem.Controls.Add(this.txtUnit);
            this.panelItem.Controls.Add(this.txtQty);
            this.panelItem.Controls.Add(this.neuLabel2);
            this.panelItem.Controls.Add(this.ucInputItem1);
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItem.Location = new System.Drawing.Point(0, 0);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(565, 41);
            this.panelItem.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelItem.TabIndex = 0;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(438, 11);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(46, 21);
            this.txtUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtUnit.TabIndex = 3;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(373, 12);
            this.txtQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 21);
            this.txtQty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQty.TabIndex = 2;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(338, 16);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(41, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "数量：";
            // 
            // ucInputItem1
            // 
            this.ucInputItem1.AlCatagory = ((System.Collections.ArrayList)(resources.GetObject("ucInputItem1.AlCatagory")));
            this.ucInputItem1.FeeItem = ((Neusoft.FrameWork.Models.NeuObject)(resources.GetObject("ucInputItem1.FeeItem")));
            this.ucInputItem1.InputType = 0;
            this.ucInputItem1.IsListShowAlways = false;
            this.ucInputItem1.IsShowCategory = true;
            this.ucInputItem1.IsShowInput = true;
            this.ucInputItem1.IsShowSelfMark = true;
            this.ucInputItem1.Location = new System.Drawing.Point(1, 2);
            this.ucInputItem1.Name = "ucInputItem1";
            this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.ItemType;
            this.ucInputItem1.ShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;
            this.ucInputItem1.Size = new System.Drawing.Size(332, 38);
            this.ucInputItem1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.Spread1);
            this.panelMain.Controls.Add(this.neuLabel1);
            this.panelMain.Controls.Add(this.btnDelete);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 41);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(565, 330);
            this.panelMain.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelMain.TabIndex = 1;
            // 
            // Spread1
            // 
            this.Spread1.About = "2.5.2007.2005";
            this.Spread1.AccessibleDescription = "Spread1, Sheet1";
            this.Spread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Spread1.BackColor = System.Drawing.Color.MintCream;
            this.Spread1.FileName = "";
            this.Spread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.Spread1.IsAutoSaveGridStatus = false;
            this.Spread1.IsCanCustomConfigColumn = false;
            this.Spread1.Location = new System.Drawing.Point(1, 3);
            this.Spread1.Name = "Spread1";
            this.Spread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetView1});
            this.Spread1.Size = new System.Drawing.Size(561, 288);
            this.Spread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.Spread1.TabIndex = 4;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Spread1.TextTipAppearance = tipAppearance1;
            this.Spread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // sheetView1
            // 
            this.sheetView1.Reset();
            this.sheetView1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetView1.ColumnCount = 14;
            this.sheetView1.RowCount = 0;
            this.sheetView1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.sheetView1.ColumnHeader.Cells.Get(0, 0).Value = "项目编码";
            this.sheetView1.ColumnHeader.Cells.Get(0, 1).Value = "项目名称";
            this.sheetView1.ColumnHeader.Cells.Get(0, 2).Value = "!";
            this.sheetView1.ColumnHeader.Cells.Get(0, 3).Value = "价格";
            this.sheetView1.ColumnHeader.Cells.Get(0, 4).Value = "数量";
            this.sheetView1.ColumnHeader.Cells.Get(0, 5).Value = "单位";
            this.sheetView1.ColumnHeader.Cells.Get(0, 6).Value = "频次";
            this.sheetView1.ColumnHeader.Cells.Get(0, 7).Value = "开始时间";
            this.sheetView1.ColumnHeader.Cells.Get(0, 8).Value = "停止时间";
            this.sheetView1.ColumnHeader.Cells.Get(0, 9).Value = "备注";
            this.sheetView1.ColumnHeader.Cells.Get(0, 10).Value = "执行科室";
            this.sheetView1.ColumnHeader.Cells.Get(0, 11).Value = "扩展标志1";
            this.sheetView1.ColumnHeader.Cells.Get(0, 12).Value = "扩展标志2";
            this.sheetView1.ColumnHeader.Cells.Get(0, 13).Value = "扩展标志3";
            this.sheetView1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.ColumnHeader.DefaultStyle.Locked = false;
            this.sheetView1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView1.Columns.Get(0).Label = "项目编码";
            this.sheetView1.Columns.Get(0).Visible = false;
            this.sheetView1.Columns.Get(1).Label = "项目名称";
            this.sheetView1.Columns.Get(1).Locked = true;
            this.sheetView1.Columns.Get(1).Width = 189F;
            this.sheetView1.Columns.Get(2).Label = "!";
            this.sheetView1.Columns.Get(2).Visible = false;
            this.sheetView1.Columns.Get(2).Width = 13F;
            this.sheetView1.Columns.Get(3).CellType = numberCellType1;
            this.sheetView1.Columns.Get(3).Label = "价格";
            this.sheetView1.Columns.Get(3).Locked = true;
            this.sheetView1.Columns.Get(3).Width = 56F;
            this.sheetView1.Columns.Get(4).CellType = numberCellType2;
            this.sheetView1.Columns.Get(4).Label = "数量";
            this.sheetView1.Columns.Get(4).Width = 51F;
            this.sheetView1.Columns.Get(5).Label = "单位";
            this.sheetView1.Columns.Get(5).Width = 40F;
            this.sheetView1.Columns.Get(6).Label = "频次";
            this.sheetView1.Columns.Get(6).Width = 40F;
            this.sheetView1.Columns.Get(7).Label = "开始时间";
            this.sheetView1.Columns.Get(7).Width = 110F;
            this.sheetView1.Columns.Get(8).Label = "停止时间";
            this.sheetView1.Columns.Get(8).Width = 103F;
            this.sheetView1.Columns.Get(9).Label = "备注";
            this.sheetView1.Columns.Get(9).Width = 135F;
            this.sheetView1.Columns.Get(10).Label = "执行科室";
            this.sheetView1.Columns.Get(10).Width = 75F;
            this.sheetView1.Columns.Get(11).Label = "扩展标志1";
            this.sheetView1.Columns.Get(11).Visible = false;
            this.sheetView1.Columns.Get(11).Width = 88F;
            this.sheetView1.Columns.Get(12).Label = "扩展标志2";
            this.sheetView1.Columns.Get(12).Visible = false;
            this.sheetView1.Columns.Get(12).Width = 73F;
            this.sheetView1.Columns.Get(13).Label = "扩展标志3";
            this.sheetView1.Columns.Get(13).Visible = false;
            this.sheetView1.Columns.Get(13).Width = 77F;
            this.sheetView1.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.sheetView1.RowHeader.Columns.Default.Resizable = false;
            this.sheetView1.RowHeader.Columns.Get(0).Width = 20F;
            this.sheetView1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.RowHeader.DefaultStyle.Locked = false;
            this.sheetView1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.sheetView1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.sheetView1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.SheetCornerStyle.Locked = false;
            this.sheetView1.SheetCornerStyle.Parent = "HeaderDefault";
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.Spread1.SetActiveViewport(1, 0);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(184, 302);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(113, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "可选择多条同时删除";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(87, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(6, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ucSubtblManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelItem);
            this.Name = "ucSubtblManager";
            this.Size = new System.Drawing.Size(565, 371);
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelItem;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelMain;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnDelete;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread Spread1;
        private FarPoint.Win.Spread.SheetView sheetView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtUnit;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown txtQty;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.HISFC.Components.Common.Controls.ucInputItem ucInputItem1;
    }
}
