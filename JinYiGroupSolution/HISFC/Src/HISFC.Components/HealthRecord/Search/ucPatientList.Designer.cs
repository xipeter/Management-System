namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    partial class ucPatientList
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType19 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType20 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType21 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType22 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType23 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType24 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(3, 17);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(729, 157);
            this.fpSpread1.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance3;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 10;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "出院科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "出院日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "住院流水号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "病案号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "住院号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "次数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "生日";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "地址";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType17.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = textCellType17;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "出院科室";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 61F;
            textCellType18.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType18;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "出院日期";
            textCellType19.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(2).CellType = textCellType19;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "姓名";
            textCellType20.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType20;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "性别";
            textCellType21.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = textCellType21;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "住院流水号";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 88F;
            textCellType22.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = textCellType22;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "病案号";
            textCellType23.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(6).CellType = textCellType23;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "住院号";
            textCellType24.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(7).CellType = textCellType24;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "次数";
            this.fpSpread1_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "生日";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 84F;
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "地址";
            this.fpSpread1_Sheet1.Columns.Get(9).Width = 130F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 23);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 12);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "绿色为已生成病案,白色为出院信息,灰色表示该患者未出院,蓝色表示已回收";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.fpSpread1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // ucPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucPatientList";
            this.Size = new System.Drawing.Size(735, 200);
            this.Load += new System.EventHandler(this.ucPatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Panel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
