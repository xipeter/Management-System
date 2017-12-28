namespace Neusoft.WinForms.Report.Order
{
    partial class ucInfusionLabel
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
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(System.Drawing.SystemColors.WindowFrame, 0), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            FarPoint.Win.ComplexBorder complexBorder3 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            FarPoint.Win.ComplexBorder complexBorder4 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.lbBed = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbUsage = new System.Windows.Forms.Label();
            this.lbCombo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDept = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBed
            // 
            this.lbBed.AutoSize = true;
            this.lbBed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBed.Location = new System.Drawing.Point(5, 45);
            this.lbBed.Name = "lbBed";
            this.lbBed.Size = new System.Drawing.Size(42, 16);
            this.lbBed.TabIndex = 0;
            this.lbBed.Text = "床号";
            this.lbBed.Visible = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(87, 45);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 16);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "姓名";
            this.lbName.Visible = false;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(191, 40);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(53, 12);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "用药日期";
            this.lbDate.Visible = false;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, 药品名称";
            this.fpSpread1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))));
            this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(195, 123);
            this.fpSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 5;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, false, false);
            this.fpSpread1_Sheet1.Cells.Get(0, 0).Border = complexBorder1;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).ColumnSpan = 4;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).Value = "药品名称";
            this.fpSpread1_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 1).Border = complexBorder2;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).Border = complexBorder3;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 2).Value = "用量";
            this.fpSpread1_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).Border = complexBorder4;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 3).Value = "次数";
            this.fpSpread1_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType1.Multiline = true;
            textCellType1.WordWrap = true;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).CellType = textCellType1;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType2.Multiline = true;
            textCellType2.WordWrap = true;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).CellType = textCellType2;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType3.Multiline = true;
            textCellType3.WordWrap = true;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).CellType = textCellType3;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(3, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(3, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType4.Multiline = true;
            textCellType4.WordWrap = true;
            this.fpSpread1_Sheet1.Cells.Get(4, 0).CellType = textCellType4;
            this.fpSpread1_Sheet1.Cells.Get(4, 0).ColumnSpan = 2;
            this.fpSpread1_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(4, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Cells.Get(4, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 47F;
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 105F;
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 40F;
            this.fpSpread1_Sheet1.Columns.Get(3).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 40F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.Rows.Get(0).Height = 15F;
            this.fpSpread1_Sheet1.Rows.Get(1).Height = 27F;
            this.fpSpread1_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.Rows.Get(2).Height = 27F;
            this.fpSpread1_Sheet1.Rows.Get(3).Height = 27F;
            this.fpSpread1_Sheet1.Rows.Get(4).Height = 27F;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.fpSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lbUsage
            // 
            this.lbUsage.AutoSize = true;
            this.lbUsage.Location = new System.Drawing.Point(205, 14);
            this.lbUsage.Name = "lbUsage";
            this.lbUsage.Size = new System.Drawing.Size(29, 12);
            this.lbUsage.TabIndex = 0;
            this.lbUsage.Text = "用法";
            this.lbUsage.Visible = false;
            // 
            // lbCombo
            // 
            this.lbCombo.AutoSize = true;
            this.lbCombo.Location = new System.Drawing.Point(147, 59);
            this.lbCombo.Name = "lbCombo";
            this.lbCombo.Size = new System.Drawing.Size(53, 12);
            this.lbCombo.TabIndex = 0;
            this.lbCombo.Text = "(组合号)";
            this.lbCombo.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 2);
            this.label2.TabIndex = 1;
            this.label2.Visible = false;
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.Location = new System.Drawing.Point(8, 14);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(29, 12);
            this.lbDept.TabIndex = 0;
            this.lbDept.Text = "科室";
            this.lbDept.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(83, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(109, 20);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "输液贴瓶卡";
            this.lbTitle.Visible = false;
            // 
            // ucInfusionLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbBed);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbCombo);
            this.Controls.Add(this.lbUsage);
            this.Controls.Add(this.lbDept);
            this.Name = "ucInfusionLabel";
            this.Size = new System.Drawing.Size(195, 123);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBed;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDate;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Label lbUsage;
        private System.Windows.Forms.Label lbCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDept;
        private System.Windows.Forms.Label lbTitle;
    }
}
