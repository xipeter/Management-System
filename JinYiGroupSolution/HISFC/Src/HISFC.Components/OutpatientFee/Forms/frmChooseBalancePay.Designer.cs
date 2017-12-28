namespace Neusoft.HISFC.Components.OutpatientFee.Froms
{
    partial class frmChooseBalancePay
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.fpSpead1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpead1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fpSpead1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 266);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "冲帐选择(F6)";
            // 
            // fpSpead1
            // 
            this.fpSpead1.About = "3.0.2004.2005";
            this.fpSpead1.AccessibleDescription = "fpSpead1, Sheet1, Row 0, Column 0, ";
            this.fpSpead1.BackColor = System.Drawing.Color.White;
            this.fpSpead1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpead1.EditModePermanent = true;
            this.fpSpead1.FileName = "";
            this.fpSpead1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpead1.IsAutoSaveGridStatus = false;
            this.fpSpead1.IsCanCustomConfigColumn = false;
            this.fpSpead1.Location = new System.Drawing.Point(3, 17);
            this.fpSpead1.Name = "fpSpead1";
            this.fpSpead1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpead1_Sheet1});
            this.fpSpead1.Size = new System.Drawing.Size(568, 246);
            this.fpSpead1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpead1.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpead1.TextTipAppearance = tipAppearance3;
            this.fpSpead1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpead1.EditModeOn += new System.EventHandler(this.fpSpead1_EditModeOn);
            this.fpSpead1.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpead1_EditChange);
            // 
            // fpSpead1_Sheet1
            // 
            this.fpSpead1_Sheet1.Reset();
            this.fpSpead1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpead1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpead1_Sheet1.ColumnCount = 3;
            this.fpSpead1_Sheet1.RowCount = 5;
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "支付方式";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "金额";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "冲帐方式";
            this.fpSpead1_Sheet1.Columns.Get(0).Label = "支付方式";
            this.fpSpead1_Sheet1.Columns.Get(0).Width = 81F;
            this.fpSpead1_Sheet1.Columns.Get(1).CellType = textCellType3;
            this.fpSpead1_Sheet1.Columns.Get(1).Label = "金额";
            this.fpSpead1_Sheet1.Columns.Get(1).Width = 102F;
            this.fpSpead1_Sheet1.Columns.Get(2).Label = "冲帐方式";
            this.fpSpead1_Sheet1.Columns.Get(2).Width = 75F;
            this.fpSpead1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpead1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpead1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.neuLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 36);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(490, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(399, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.neuLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.neuLabel1.Location = new System.Drawing.Point(12, 8);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(195, 19);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "F4确认 ESC取消选择";
            // 
            // frmChooseBalancePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 302);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChooseBalancePay";
            this.Text = "选择支付方式";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpead1;
        private FarPoint.Win.Spread.SheetView fpSpead1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}