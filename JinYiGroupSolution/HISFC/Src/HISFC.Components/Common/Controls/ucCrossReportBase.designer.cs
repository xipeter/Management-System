namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucCrossReportBase
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.LineBorder lineBorder1 = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame);
            FarPoint.Win.LineBorder lineBorder2 = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 1, false, false, true, true);
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpFromDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.plTitle = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbQueryInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.plPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.plTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.lbDept);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.cmbDept);
            this.neuPanel1.Controls.Add(this.dtpEndDate);
            this.neuPanel1.Controls.Add(this.dtpFromDate);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(771, 53);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.Location = new System.Drawing.Point(428, 17);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(65, 12);
            this.lbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDept.TabIndex = 0;
            this.lbDept.Text = "查询条件：";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(229, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(17, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "至";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(499, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 2;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsEnter2Tab = false;
            this.dtpEndDate.Location = new System.Drawing.Point(258, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(141, 21);
            this.dtpEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.IsEnter2Tab = false;
            this.dtpFromDate.Location = new System.Drawing.Point(79, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(141, 21);
            this.dtpFromDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpFromDate.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(12, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "查询时间：";
            // 
            // plPrint
            // 
            this.plPrint.Controls.Add(this.neuSpread1);
            this.plPrint.Controls.Add(this.plTitle);
            this.plPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plPrint.Location = new System.Drawing.Point(0, 53);
            this.plPrint.Name = "plPrint";
            this.plPrint.Size = new System.Drawing.Size(771, 552);
            this.plPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plPrint.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 汇总 , Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 62);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(771, 490);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ActiveSheetChanging += new FarPoint.Win.Spread.ActiveSheetChangingEventHandler(this.neuSpread1_ActiveSheetChanging);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "汇总 ";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 10;
            this.neuSpread1_Sheet1.RowCount = 10;
            this.neuSpread1_Sheet1.RowHeader.ColumnCount = 0;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.White, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Border = lineBorder1;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, System.Drawing.Color.Transparent);
            this.neuSpread1_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.DefaultStyle.Border = lineBorder2;
            this.neuSpread1_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // plTitle
            // 
            this.plTitle.BackColor = System.Drawing.Color.White;
            this.plTitle.Controls.Add(this.lbQueryInfo);
            this.plTitle.Controls.Add(this.lbTitle);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitle.Location = new System.Drawing.Point(0, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(771, 62);
            this.plTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plTitle.TabIndex = 0;
            // 
            // lbQueryInfo
            // 
            this.lbQueryInfo.AutoSize = true;
            this.lbQueryInfo.Location = new System.Drawing.Point(10, 41);
            this.lbQueryInfo.Name = "lbQueryInfo";
            this.lbQueryInfo.Size = new System.Drawing.Size(77, 12);
            this.lbQueryInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbQueryInfo.TabIndex = 0;
            this.lbQueryInfo.Text = "查询条件信息";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(250, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(58, 24);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "标题";
            // 
            // ucCrossReportBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plPrint);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucCrossReportBase";
            this.Size = new System.Drawing.Size(771, 605);
            this.Load += new System.EventHandler(this.ucCrosstabReport_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.plPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.plTitle.ResumeLayout(false);
            this.plTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plPrint;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plTitle;
        protected Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpFromDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbQueryInfo;
    }
}