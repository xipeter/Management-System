namespace Neusoft.WinForms.Report.OutpatientFee.Query
{
    partial class frmQueryFeeDetail
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.gbInput = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbInput = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.dtpDateTo = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpFromDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.cbDataDate = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.labQueryName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1_Sheet3 = new FarPoint.Win.Spread.SheetView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.label1);
            this.gbInput.Controls.Add(this.tbInput);
            this.gbInput.Controls.Add(this.dtpDateTo);
            this.gbInput.Controls.Add(this.dtpFromDate);
            this.gbInput.Controls.Add(this.cbDataDate);
            this.gbInput.Controls.Add(this.label2);
            this.gbInput.Controls.Add(this.labQueryName);
            this.gbInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(632, 41);
            this.gbInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbInput.TabIndex = 1;
            this.gbInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(208, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 11);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 6;
            this.label1.Text = "(A)";
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbInput.Location = new System.Drawing.Point(106, 12);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(100, 21);
            this.tbInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbInput.TabIndex = 1;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Location = new System.Drawing.Point(483, 13);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(109, 21);
            this.dtpDateTo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpDateTo.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Location = new System.Drawing.Point(358, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(109, 21);
            this.dtpFromDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpFromDate.TabIndex = 3;
            // 
            // cbDataDate
            // 
            this.cbDataDate.Enabled = false;
            this.cbDataDate.Location = new System.Drawing.Point(260, 12);
            this.cbDataDate.Name = "cbDataDate";
            this.cbDataDate.Size = new System.Drawing.Size(108, 24);
            this.cbDataDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbDataDate.TabIndex = 2;
            this.cbDataDate.Text = "数据时间(F3)";
            this.cbDataDate.CheckedChanged += new System.EventHandler(this.cbDataDate_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(436, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 5;
            this.label2.Text = "——";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labQueryName
            // 
            this.labQueryName.Location = new System.Drawing.Point(9, 16);
            this.labQueryName.Name = "labQueryName";
            this.labQueryName.Size = new System.Drawing.Size(94, 15);
            this.labQueryName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.labQueryName.TabIndex = 0;
            this.labQueryName.Text = "发票号(F2切换)";
            this.labQueryName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 41);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1,
            this.fpSpread1_Sheet2,
            this.fpSpread1_Sheet3});
            this.fpSpread1.Size = new System.Drawing.Size(632, 405);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "发票基本信息";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 10;
            this.fpSpread1_Sheet1.RowCount = 10;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1_Sheet2
            // 
            this.fpSpread1_Sheet2.Reset();
            this.fpSpread1_Sheet2.SheetName = "发票明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet2.ColumnCount = 10;
            this.fpSpread1_Sheet2.RowCount = 10;
            this.fpSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet2.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet2.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1_Sheet3
            // 
            this.fpSpread1_Sheet3.Reset();
            this.fpSpread1_Sheet3.SheetName = "费用明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet3.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet3.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet3.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet3.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "neuHIS.xls";
            this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            this.saveFileDialog1.InitialDirectory = "c:\\";
            // 
            // frmQueryFeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.gbInput);
            this.Name = "frmQueryFeeDetail";
            this.Size = new System.Drawing.Size(632, 446);
            this.Load += new System.EventHandler(this.frmQueryFeeDetail_Load);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet3)).EndInit();
            this.ResumeLayout(false);

        }
        
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel labQueryName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet2;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet3;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpDateTo;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpFromDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbDataDate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;

        #endregion
    }
}