namespace Neusoft.UFC.Material.Base
{
    partial class ucMatKind
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
            this.fpKind = new Neusoft.NFC.Interface.Controls.NeuSpread();
            this.fpKind_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txtQueryCode = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.chbMisty = new Neusoft.NFC.Interface.Controls.NeuCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpKind_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpKind
            // 
            this.fpKind.About = "2.5.2007.2005";
            this.fpKind.AccessibleDescription = "";
            this.fpKind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpKind.BackColor = System.Drawing.Color.White;
            this.fpKind.FileName = "";
            this.fpKind.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpKind.IsAutoSaveGridStatus = false;
            this.fpKind.IsCanCustomConfigColumn = false;
            this.fpKind.Location = new System.Drawing.Point(3, 38);
            this.fpKind.Name = "fpKind";
            this.fpKind.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpKind_Sheet1});
            this.fpKind.Size = new System.Drawing.Size(586, 311);
            this.fpKind.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.fpKind.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpKind.TextTipAppearance = tipAppearance1;
            this.fpKind.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpKind.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpKind_LeaveCell);
            // 
            // fpKind_Sheet1
            // 
            this.fpKind_Sheet1.Reset();
            this.fpKind_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpKind_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpKind_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpKind_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(17, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(47, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "查询码:";
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.Location = new System.Drawing.Point(70, 9);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(150, 21);
            this.txtQueryCode.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtQueryCode.TabIndex = 2;
            this.txtQueryCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQueryCode_KeyUp);
            this.txtQueryCode.TextChanged += new System.EventHandler(this.txtQueryCode_TextChanged);
            // 
            // chbMisty
            // 
            this.chbMisty.AutoSize = true;
            this.chbMisty.Location = new System.Drawing.Point(226, 11);
            this.chbMisty.Name = "chbMisty";
            this.chbMisty.Size = new System.Drawing.Size(72, 16);
            this.chbMisty.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.chbMisty.TabIndex = 3;
            this.chbMisty.Text = "模糊查询";
            this.chbMisty.UseVisualStyleBackColor = true;
            // 
            // ucMatKind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbMisty);
            this.Controls.Add(this.txtQueryCode);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.fpKind);
            this.Name = "ucMatStorage";
            this.Size = new System.Drawing.Size(592, 352);
            this.Load += new System.EventHandler(this.ucMatKind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpKind_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuSpread fpKind;
        private FarPoint.Win.Spread.SheetView fpKind_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtQueryCode;
        private Neusoft.NFC.Interface.Controls.NeuCheckBox chbMisty;
        
    }
}
