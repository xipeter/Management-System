namespace Neusoft.HISFC.Components.OutpatientFee.InvoicePrint
{
    partial class ucSplitUnit
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
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.dtpInvoiceTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbInvoiceNo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.label5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dtpInvoiceTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbInvoiceNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 35);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 0;
            // 
            // dtpInvoiceTime
            // 
            this.dtpInvoiceTime.CustomFormat = "yyyy-MM-dd";
            this.dtpInvoiceTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpInvoiceTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceTime.Location = new System.Drawing.Point(308, 4);
            this.dtpInvoiceTime.Name = "dtpInvoiceTime";
            this.dtpInvoiceTime.Size = new System.Drawing.Size(132, 24);
            this.dtpInvoiceTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpInvoiceTime.TabIndex = 3;
            this.dtpInvoiceTime.ValueChanged += new System.EventHandler(this.dtpInvoiceTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(231, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 2;
            this.label3.Text = "发票时间:";
            // 
            // lbInvoiceNo
            // 
            this.lbInvoiceNo.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInvoiceNo.Location = new System.Drawing.Point(96, 9);
            this.lbInvoiceNo.Name = "lbInvoiceNo";
            this.lbInvoiceNo.Size = new System.Drawing.Size(120, 16);
            this.lbInvoiceNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInvoiceNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "发票号码:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lbCost);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 33);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 1;
            // 
            // lbCost
            // 
            this.lbCost.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCost.Location = new System.Drawing.Point(104, 8);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(344, 16);
            this.lbCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCost.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(24, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 2;
            this.label4.Text = "合计金额:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 156);
            this.panel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 156);
            this.label5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 3;
            this.label5.Text = "收 费 项 目";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.EditModePermanent = true;
            this.fpSpread1.EditModeReplace = true;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(52, 35);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(407, 156);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 3;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance4;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 2;
            this.fpSpread1_Sheet1.RowCount = 7;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "项目名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "金    额";
            this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "项目名称";
            this.fpSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 133F;
            this.fpSpread1_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "金    额";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 174F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.Rows.Get(0).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(1).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(2).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(3).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(4).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(5).Height = 22F;
            this.fpSpread1_Sheet1.Rows.Get(6).Height = 22F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.fpSpread1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(461, 226);
            this.panel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel4.TabIndex = 4;
            // 
            // ucSplitUnit
            // 
            this.Controls.Add(this.panel4);
            this.Name = "ucSplitUnit";
            this.Size = new System.Drawing.Size(461, 226);
            this.Load += new System.EventHandler(this.ucSplitUnit_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpInvoiceTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label4;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label5;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInvoiceNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
    }
}
