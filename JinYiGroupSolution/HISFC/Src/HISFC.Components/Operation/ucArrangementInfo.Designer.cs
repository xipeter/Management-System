namespace Neusoft.HISFC.Components.Operation
{
    partial class ucArrangementInfo
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, 病区/床号";
            this.fpSpread1.AllowColumnMove = true;
            this.fpSpread1.AllowRowMove = true;
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(645, 146);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 7;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).Value = "病区/床号";
            this.fpSpread1_Sheet1.Cells.Get(0, 2).Value = "姓名/性别";
            this.fpSpread1_Sheet1.Cells.Get(1, 0).Value = "住院号";
            this.fpSpread1_Sheet1.Cells.Get(1, 2).Value = "手术类型";
            this.fpSpread1_Sheet1.Cells.Get(2, 0).Value = "手术台类型";
            this.fpSpread1_Sheet1.Cells.Get(2, 2).Value = "术前诊断";
            this.fpSpread1_Sheet1.Cells.Get(3, 0).Value = "手术名称";
            this.fpSpread1_Sheet1.Cells.Get(3, 2).Value = "手术时间";
            this.fpSpread1_Sheet1.Cells.Get(4, 0).Value = "麻醉方式";
            this.fpSpread1_Sheet1.Cells.Get(4, 2).Value = "申请医生";
            this.fpSpread1_Sheet1.Cells.Get(5, 0).Value = "手术医生";
            this.fpSpread1_Sheet1.Cells.Get(5, 2).Value = "是否特殊手术";
            this.fpSpread1_Sheet1.Cells.Get(6, 0).Value = "助手医生";
            this.fpSpread1_Sheet1.Cells.Get(6, 2).Value = "备注";
            textCellType1.Multiline = true;
            this.fpSpread1_Sheet1.Cells.Get(6, 3).CellType = textCellType1;
            this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Linen;
            this.fpSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 100F;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 202F;
            this.fpSpread1_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Linen;
            this.fpSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 100F;
            textCellType3.Multiline = true;
            textCellType3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textCellType3.StringTrim = System.Drawing.StringTrimming.Character;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = false;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 202F;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.Linen;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Border = compoundBorder1;
            textCellType4.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Alpha;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.CellType = textCellType4;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = true;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucArrangementInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Name = "ucArrangementInfo";
            this.Size = new System.Drawing.Size(645, 146);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
    }
}
