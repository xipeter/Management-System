namespace Neusoft.WinForms.Report.DrugStore
{
    partial class ucRecipeLabel
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
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN", false);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecipeLabel));
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbBarCode = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, 郑培德君";
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
            this.neuSpread1.Size = new System.Drawing.Size(274, 138);
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
            this.neuSpread1_Sheet1.ColumnCount = 4;
            this.neuSpread1_Sheet1.RowCount = 7;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, false, false);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Value = "郑培德君";
            this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo = ((System.Globalization.DateTimeFormatInfo)(cultureInfo.DateTimeFormat.Clone()));
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).AMDesignator = "AM";
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).DateSeparator = "-";
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).FullDateTimePattern = "yyyy\'年\'M\'月\'d\'日\' HH:mm:ss";
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).LongTimePattern = "HH:mm:ss";
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).PMDesignator = "PM";
            ((System.Globalization.DateTimeFormatInfo)(this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatInfo)).ShortDatePattern = "yyyy-M-d";
            this.neuSpread1_Sheet1.Cells.Get(0, 1).ParseFormatString = "yyyy-MM-dd H:mm:ss";
            this.neuSpread1_Sheet1.Cells.Get(0, 1).Value = new System.DateTime(2006, 4, 10, 12, 23, 52, 0);
            this.neuSpread1_Sheet1.Cells.Get(0, 2).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(0, 2).Value = "DH0001";
            this.neuSpread1_Sheet1.Cells.Get(0, 3).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(0, 3).Value = "↑8/9";
            this.neuSpread1_Sheet1.Cells.Get(1, 0).ColumnSpan = 3;
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Value = "拜心通控缓释片(30g/片/1盒)";
            this.neuSpread1_Sheet1.Cells.Get(1, 3).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Cells.Get(1, 3).Value = "170片";
            this.neuSpread1_Sheet1.Cells.Get(2, 0).ColumnSpan = 2;
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Value = "强敌松龙注射液";
            this.neuSpread1_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
            this.neuSpread1_Sheet1.Cells.Get(2, 2).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Cells.Get(2, 2).Value = "院注5次";
            this.neuSpread1_Sheet1.Cells.Get(3, 0).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(3, 0).Value = "用法";
            this.neuSpread1_Sheet1.Cells.Get(3, 1).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Cells.Get(3, 1).Value = "每次20mg";
            this.neuSpread1_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.neuSpread1_Sheet1.Cells.Get(3, 2).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Cells.Get(3, 2).Value = "每天三次";
            this.neuSpread1_Sheet1.Cells.Get(4, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neuSpread1_Sheet1.Cells.Get(4, 0).Value = "嘱托：";
            this.neuSpread1_Sheet1.Cells.Get(4, 1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Cells.Get(5, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neuSpread1_Sheet1.Cells.Get(5, 0).Value = "存储：";
            this.neuSpread1_Sheet1.Cells.Get(5, 1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(5, 1).Value = "遮光存储";
            this.neuSpread1_Sheet1.Cells.Get(6, 0).ColumnSpan = 2;
            this.neuSpread1_Sheet1.Cells.Get(6, 0).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(6, 0).Value = "广州医学院附属第一医院";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 63F;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 118F;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 45F;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 39F;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Get(0).Height = 18F;
            this.neuSpread1_Sheet1.Rows.Get(1).Height = 18F;
            this.neuSpread1_Sheet1.Rows.Get(2).Height = 17F;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lbBarCode
            // 
            this.lbBarCode.Location = new System.Drawing.Point(155, 96);
            this.lbBarCode.Name = "lbBarCode";
            this.lbBarCode.Size = new System.Drawing.Size(120, 37);
            this.lbBarCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbBarCode.TabIndex = 1;
            this.lbBarCode.Text = "neuLabel1";
            this.lbBarCode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ucRecipeLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.lbBarCode);
            this.Name = "ucRecipeLabel";
            this.Size = new System.Drawing.Size(274, 138);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbBarCode;
    }
}
