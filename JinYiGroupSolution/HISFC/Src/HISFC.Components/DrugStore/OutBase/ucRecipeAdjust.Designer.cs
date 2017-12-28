namespace Neusoft.HISFC.Components.DrugStore.OutBase
{
    partial class ucRecipeAdjust
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.rbCompete = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rbAverage = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.rbSend = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rbDrug = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.rbCompete);
            this.neuGroupBox1.Controls.Add(this.rbAverage);
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 8);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(279, 38);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "调剂方式";
            // 
            // rbCompete
            // 
            this.rbCompete.AutoSize = true;
            this.rbCompete.ForeColor = System.Drawing.Color.Blue;
            this.rbCompete.Location = new System.Drawing.Point(144, 17);
            this.rbCompete.Name = "rbCompete";
            this.rbCompete.Size = new System.Drawing.Size(71, 16);
            this.rbCompete.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbCompete.TabIndex = 1;
            this.rbCompete.TabStop = true;
            this.rbCompete.Text = "竞争调剂";
            this.rbCompete.UseVisualStyleBackColor = true;
            this.rbCompete.CheckedChanged += new System.EventHandler(this.rbCompete_CheckedChanged);
            // 
            // rbAverage
            // 
            this.rbAverage.AutoSize = true;
            this.rbAverage.Checked = true;
            this.rbAverage.ForeColor = System.Drawing.Color.Blue;
            this.rbAverage.Location = new System.Drawing.Point(52, 17);
            this.rbAverage.Name = "rbAverage";
            this.rbAverage.Size = new System.Drawing.Size(71, 16);
            this.rbAverage.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbAverage.TabIndex = 0;
            this.rbAverage.TabStop = true;
            this.rbAverage.Text = "平均调剂";
            this.rbAverage.UseVisualStyleBackColor = true;
            this.rbAverage.CheckedChanged += new System.EventHandler(this.rbAverage_CheckedChanged);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.neuSpread1);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 56);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(693, 342);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "配药台调剂参数";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 17);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(687, 322);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 6;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Window, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "配药台编号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "配药台名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "是否关闭";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "已发送品种数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "待配药品种数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "均分次数";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "配药台编号";
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 83F;
            this.neuSpread1_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "配药台名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 205F;
            this.neuSpread1_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "是否关闭";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 83F;
            this.neuSpread1_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "已发送品种数";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 103F;
            this.neuSpread1_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.neuSpread1_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "待配药品种数";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 146F;
            this.neuSpread1_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "均分次数";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 146F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuGroupBox1);
            this.neuPanel1.Controls.Add(this.neuGroupBox3);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(693, 56);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 2;
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Controls.Add(this.rbSend);
            this.neuGroupBox3.Controls.Add(this.rbDrug);
            this.neuGroupBox3.Location = new System.Drawing.Point(310, 8);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(279, 38);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 0;
            this.neuGroupBox3.TabStop = false;
            this.neuGroupBox3.Text = "调剂依据";
            // 
            // rbSend
            // 
            this.rbSend.AutoSize = true;
            this.rbSend.ForeColor = System.Drawing.Color.Blue;
            this.rbSend.Location = new System.Drawing.Point(147, 15);
            this.rbSend.Name = "rbSend";
            this.rbSend.Size = new System.Drawing.Size(59, 16);
            this.rbSend.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbSend.TabIndex = 1;
            this.rbSend.Text = "发  药";
            this.rbSend.UseVisualStyleBackColor = true;
            this.rbSend.CheckedChanged += new System.EventHandler(this.rbCompete_CheckedChanged);
            // 
            // rbDrug
            // 
            this.rbDrug.AutoSize = true;
            this.rbDrug.Checked = true;
            this.rbDrug.ForeColor = System.Drawing.Color.Blue;
            this.rbDrug.Location = new System.Drawing.Point(55, 16);
            this.rbDrug.Name = "rbDrug";
            this.rbDrug.Size = new System.Drawing.Size(59, 16);
            this.rbDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbDrug.TabIndex = 0;
            this.rbDrug.TabStop = true;
            this.rbDrug.Text = "配  药";
            this.rbDrug.UseVisualStyleBackColor = true;
            this.rbDrug.CheckedChanged += new System.EventHandler(this.rbAverage_CheckedChanged);
            // 
            // ucRecipeAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucRecipeAdjust";
            this.Size = new System.Drawing.Size(693, 398);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuGroupBox3.ResumeLayout(false);
            this.neuGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbCompete;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbAverage;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbSend;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbDrug;
    }
}
