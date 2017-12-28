namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMatStorage
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
            this.fpStorage = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpStorage_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtQueryCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.chbMisty = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpStorage_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpStorage
            // 
            this.fpStorage.About = "2.5.2007.2005";
            this.fpStorage.AccessibleDescription = "fpStorage, Sheet1, Row 0, Column 0, ";
            this.fpStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpStorage.BackColor = System.Drawing.Color.White;
            this.fpStorage.FileName = "";
            this.fpStorage.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpStorage.IsAutoSaveGridStatus = false;
            this.fpStorage.IsCanCustomConfigColumn = false;
            this.fpStorage.Location = new System.Drawing.Point(3, 38);
            this.fpStorage.Name = "fpStorage";
            this.fpStorage.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpStorage_Sheet1});
            this.fpStorage.Size = new System.Drawing.Size(586, 311);
            this.fpStorage.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpStorage.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpStorage.TextTipAppearance = tipAppearance1;
            this.fpStorage.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpStorage.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpStorage_EditChange);
            // 
            // fpStorage_Sheet1
            // 
            this.fpStorage_Sheet1.Reset();
            this.fpStorage_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpStorage_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpStorage_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpStorage_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpStorage_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpStorage_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpStorage_Sheet1.DataAutoSizeColumns = false;
            this.fpStorage_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpStorage_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpStorage_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpStorage_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpStorage_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpStorage_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpStorage_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpStorage_Sheet1.SheetCornerStyle.Locked = false;
            this.fpStorage_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpStorage_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(17, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(47, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "查询码:";
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.IsEnter2Tab = false;
            this.txtQueryCode.Location = new System.Drawing.Point(70, 9);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(150, 21);
            this.txtQueryCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQueryCode.TabIndex = 2;
            this.txtQueryCode.TextChanged += new System.EventHandler(this.txtQueryCode_TextChanged);
            // 
            // chbMisty
            // 
            this.chbMisty.AutoSize = true;
            this.chbMisty.Location = new System.Drawing.Point(226, 11);
            this.chbMisty.Name = "chbMisty";
            this.chbMisty.Size = new System.Drawing.Size(72, 16);
            this.chbMisty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbMisty.TabIndex = 3;
            this.chbMisty.Text = "模糊查询";
            this.chbMisty.UseVisualStyleBackColor = true;
            // 
            // ucMatStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbMisty);
            this.Controls.Add(this.txtQueryCode);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.fpStorage);
            this.Name = "ucMatStorage";
            this.Size = new System.Drawing.Size(592, 352);
            this.Load += new System.EventHandler(this.ucMatStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpStorage_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpStorage;
        private FarPoint.Win.Spread.SheetView fpStorage_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQueryCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbMisty;
    }
}
