namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    partial class ucDrugQualityManager
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrugQualityManager));
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(725, 472);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_EditChange);
            this.neuSpread1.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ComboSelChange);
            this.neuSpread1.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpSpread1_LeaveCell);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 11;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "拼音码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "五笔码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "系统类别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "有效性";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "操作员";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "操作时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "标志";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 69F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 98F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 97F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 78F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 68F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "系统类别";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 81F;
            this.neuSpread1_Sheet1.Columns.Get(6).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "有效性";
            this.neuSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 59F;
            numberCellType1.DecimalPlaces = 0;
            this.neuSpread1_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "序号";
            this.neuSpread1_Sheet1.Columns.Get(8).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "操作员";
            this.neuSpread1_Sheet1.Columns.Get(8).Locked = true;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 8, 20, 11, 36, 26, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 8, 20, 11, 36, 26, 0);
            this.neuSpread1_Sheet1.Columns.Get(9).CellType = dateTimeCellType1;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "操作时间";
            this.neuSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 124F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "标志";
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;
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
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucDrugQualityManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucDrugQualityManager";
            this.Size = new System.Drawing.Size(725, 472);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
