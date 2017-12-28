namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucInvoiceChangeNOInitInvoiceType
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbInvoiceTypeName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuFpEnter1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.invoiceSheet = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.btnOK);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel1.Location = new System.Drawing.Point(0, 215);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(481, 37);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(17, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(293, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "如果已用发票号小于起始发票号表明该发票段还未使用";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(351, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.lbInvoiceTypeName);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(481, 38);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // lbInvoiceTypeName
            // 
            this.lbInvoiceTypeName.AutoSize = true;
            this.lbInvoiceTypeName.Location = new System.Drawing.Point(17, 13);
            this.lbInvoiceTypeName.Name = "lbInvoiceTypeName";
            this.lbInvoiceTypeName.Size = new System.Drawing.Size(113, 12);
            this.lbInvoiceTypeName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInvoiceTypeName.TabIndex = 0;
            this.lbInvoiceTypeName.Text = "发票类型：门诊发票";
            // 
            // neuFpEnter1
            // 
            this.neuFpEnter1.About = "2.5.2007.2005";
            this.neuFpEnter1.AccessibleDescription = "neuFpEnter1, Sheet1";
            this.neuFpEnter1.BackColor = System.Drawing.Color.White;
            this.neuFpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuFpEnter1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.neuFpEnter1.Location = new System.Drawing.Point(0, 38);
            this.neuFpEnter1.Name = "neuFpEnter1";
            this.neuFpEnter1.SelectNone = true;
            this.neuFpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.invoiceSheet});
            this.neuFpEnter1.ShowListWhenOfFocus = false;
            this.neuFpEnter1.Size = new System.Drawing.Size(481, 177);
            this.neuFpEnter1.TabIndex = 3;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuFpEnter1.TextTipAppearance = tipAppearance1;
            this.neuFpEnter1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuFpEnter1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuFpEnter1_ButtonClicked);
            this.neuFpEnter1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuFpEnter1_CellDoubleClick);
            // 
            // invoiceSheet
            // 
            this.invoiceSheet.Reset();
            this.invoiceSheet.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.invoiceSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.invoiceSheet.ColumnCount = 6;
            this.invoiceSheet.RowCount = 0;
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 0).Value = "领用时间";
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 1).Value = "起始发票号";
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 2).Value = "终止发票号";
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 3).Value = "已用发票号";
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 4).Value = "在用号段 ";
            this.invoiceSheet.ColumnHeader.Cells.Get(0, 5).Value = " ";
            this.invoiceSheet.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.invoiceSheet.ColumnHeader.DefaultStyle.Locked = false;
            this.invoiceSheet.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.invoiceSheet.Columns.Get(0).CellType = textCellType1;
            this.invoiceSheet.Columns.Get(0).Label = "领用时间";
            this.invoiceSheet.Columns.Get(0).Locked = true;
            this.invoiceSheet.Columns.Get(0).Width = 170F;
            this.invoiceSheet.Columns.Get(1).CellType = textCellType2;
            this.invoiceSheet.Columns.Get(1).Label = "起始发票号";
            this.invoiceSheet.Columns.Get(1).Locked = true;
            this.invoiceSheet.Columns.Get(1).Width = 91F;
            this.invoiceSheet.Columns.Get(2).CellType = textCellType3;
            this.invoiceSheet.Columns.Get(2).Label = "终止发票号";
            this.invoiceSheet.Columns.Get(2).Locked = true;
            this.invoiceSheet.Columns.Get(2).Width = 95F;
            this.invoiceSheet.Columns.Get(3).CellType = textCellType4;
            this.invoiceSheet.Columns.Get(3).Label = "已用发票号";
            this.invoiceSheet.Columns.Get(3).Locked = true;
            this.invoiceSheet.Columns.Get(3).Width = 83F;
            this.invoiceSheet.Columns.Get(4).CellType = checkBoxCellType1;
            this.invoiceSheet.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.invoiceSheet.Columns.Get(4).Label = "在用号段 ";
            this.invoiceSheet.Columns.Get(4).Width = 64F;
            buttonCellType1.Text = "跳号";
            this.invoiceSheet.Columns.Get(5).CellType = buttonCellType1;
            this.invoiceSheet.Columns.Get(5).Label = " ";
            this.invoiceSheet.GrayAreaBackColor = System.Drawing.Color.White;
            this.invoiceSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.invoiceSheet.RowHeader.Columns.Default.Resizable = false;
            this.invoiceSheet.RowHeader.Columns.Get(0).Width = 37F;
            this.invoiceSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuFpEnter1.SetActiveViewport(1, 0);
            // 
            // ucInvoiceChangeNOInitInvoiceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuFpEnter1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucInvoiceChangeNOInitInvoiceType";
            this.Size = new System.Drawing.Size(481, 252);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInvoiceTypeName;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuFpEnter1;
        private FarPoint.Win.Spread.SheetView invoiceSheet;
    }
}
