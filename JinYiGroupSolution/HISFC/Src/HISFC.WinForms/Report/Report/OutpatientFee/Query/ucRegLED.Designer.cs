namespace Neusoft.WinForms.Report.OutpatientFee.Query
{
    partial class ucRegLED
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ReSet = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.OK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuNumericTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.NpPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.NpPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
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
            this.neuSpread1.Size = new System.Drawing.Size(697, 416);
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
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.lbl);
            this.neuPanel1.Controls.Add(this.ReSet);
            this.neuPanel1.Controls.Add(this.OK);
            this.neuPanel1.Controls.Add(this.neuNumericTextBox1);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(697, 71);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Location = new System.Drawing.Point(384, 3);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(313, 65);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 7;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(112, 35);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 6;
            this.neuLabel2.Text = "秒";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(15, 17);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 12);
            this.lbl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl.TabIndex = 5;
            this.lbl.Visible = false;
            // 
            // ReSet
            // 
            this.ReSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReSet.Location = new System.Drawing.Point(157, 30);
            this.ReSet.Name = "ReSet";
            this.ReSet.Size = new System.Drawing.Size(103, 23);
            this.ReSet.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ReSet.TabIndex = 4;
            this.ReSet.Text = "设置刷新频率(&R)";
            this.ReSet.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.ReSet.UseVisualStyleBackColor = true;
            this.ReSet.Click += new System.EventHandler(this.ReSet_Click);
            // 
            // OK
            // 
            this.OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK.Location = new System.Drawing.Point(266, 30);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(102, 23);
            this.OK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.OK.TabIndex = 3;
            this.OK.Text = "确定(&O)";
            this.OK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // neuNumericTextBox1
            // 
            this.neuNumericTextBox1.AllowNegative = false;
            this.neuNumericTextBox1.IsAutoRemoveDecimalZero = false;
            this.neuNumericTextBox1.Location = new System.Drawing.Point(69, 31);
            this.neuNumericTextBox1.Name = "neuNumericTextBox1";
            this.neuNumericTextBox1.NumericPrecision = 10;
            this.neuNumericTextBox1.NumericScaleOnFocus = 0;
            this.neuNumericTextBox1.NumericScaleOnLostFocus = 0;
            this.neuNumericTextBox1.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.neuNumericTextBox1.SetRange = new System.Drawing.Size(-1, -1);
            this.neuNumericTextBox1.Size = new System.Drawing.Size(43, 21);
            this.neuNumericTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuNumericTextBox1.TabIndex = 2;
            this.neuNumericTextBox1.Text = "10";
            this.neuNumericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.neuNumericTextBox1.UseGroupSeperator = true;
            this.neuNumericTextBox1.ZeroIsValid = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(10, 35);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "刷新频率";
            // 
            // NpPrint
            // 
            this.NpPrint.Controls.Add(this.neuSpread1);
            this.NpPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NpPrint.Location = new System.Drawing.Point(0, 71);
            this.NpPrint.Name = "NpPrint";
            this.NpPrint.Size = new System.Drawing.Size(697, 416);
            this.NpPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.NpPrint.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucRegLED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NpPrint);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucRegLED";
            this.Size = new System.Drawing.Size(697, 487);
            this.Load += new System.EventHandler(this.ucRegLED_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.NpPrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel NpPrint;
        private System.Windows.Forms.Timer timer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton ReSet;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton OK;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox neuNumericTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
    }
}
