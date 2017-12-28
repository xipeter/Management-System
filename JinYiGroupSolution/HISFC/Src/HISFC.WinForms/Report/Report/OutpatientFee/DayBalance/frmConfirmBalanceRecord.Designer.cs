namespace Neusoft.WinForms.Report.OutpatientFee.DayBalance
{
    partial class frmConfirmBalanceRecord
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
            this.button1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.button2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(224, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.button1.TabIndex = 1;
            this.button1.Text = "确定(&O)";
            this.button1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(305, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 3;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "日结编号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "日结起始时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "日结截止时间";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "日结编号";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 80F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "日结起始时间";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 125F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "日结截止时间";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 125F;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            //this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(386, 178);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // frmConfirmBalanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 218);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fpSpread1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmBalanceRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择日结记录";
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton button1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton button2;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
    }
}