namespace Neusoft.FrameWork.WinForms.Controls
{
    partial class ucMaintenanceComboBox
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.rdoItems = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rdoSQL = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtSQL = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 144);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(707, 247);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 3;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
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
            this.neuPanel1.Controls.Add(this.rdoItems);
            this.neuPanel1.Controls.Add(this.rdoSQL);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.txtSQL);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(707, 144);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 2;
            // 
            // rdoItems
            // 
            this.rdoItems.AutoSize = true;
            this.rdoItems.Location = new System.Drawing.Point(15, 114);
            this.rdoItems.Name = "rdoItems";
            this.rdoItems.Size = new System.Drawing.Size(83, 16);
            this.rdoItems.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdoItems.TabIndex = 4;
            this.rdoItems.TabStop = true;
            this.rdoItems.Text = "列表框数据";
            this.rdoItems.UseVisualStyleBackColor = true;
            this.rdoItems.CheckedChanged += new System.EventHandler(this.rdoSQL_CheckedChanged);
            // 
            // rdoSQL
            // 
            this.rdoSQL.AutoSize = true;
            this.rdoSQL.Location = new System.Drawing.Point(15, 12);
            this.rdoSQL.Name = "rdoSQL";
            this.rdoSQL.Size = new System.Drawing.Size(83, 16);
            this.rdoSQL.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdoSQL.TabIndex = 3;
            this.rdoSQL.TabStop = true;
            this.rdoSQL.Text = "列表框 SQL";
            this.rdoSQL.UseVisualStyleBackColor = true;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(13, 76);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(245, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "选择项编码字段在第一位，名称字段在第二位";
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.Location = new System.Drawing.Point(105, 11);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(588, 53);
            this.txtSQL.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSQL.TabIndex = 1;
            this.txtSQL.Text = "";
            // 
            // ucMaintenanceComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucMaintenanceComboBox";
            this.Size = new System.Drawing.Size(707, 391);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NeuRichTextBox txtSQL;
        private NeuPanel neuPanel1;
        private NeuRadioButton rdoSQL;
        private NeuLabel neuLabel2;
        private NeuRadioButton rdoItems;
        private NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
