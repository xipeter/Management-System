namespace Neusoft.NFC.Interface.Forms
{
    partial class ucQuery
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuCheckBox1 = new Neusoft.NFC.Interface.Controls.NeuCheckBox();
            this.neuTextBox1 = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpSpread1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(804, 571);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.neuCheckBox1);
            this.panel1.Controls.Add(this.neuTextBox1);
            this.panel1.Controls.Add(this.neuLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 52);
            this.panel1.TabIndex = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1";
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 52);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(662, 519);
            this.fpSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuCheckBox1
            // 
            this.neuCheckBox1.AutoSize = true;
            this.neuCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.neuCheckBox1.Location = new System.Drawing.Point(248, 21);
            this.neuCheckBox1.Name = "neuCheckBox1";
            this.neuCheckBox1.Size = new System.Drawing.Size(45, 16);
            this.neuCheckBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.VS2003;
            this.neuCheckBox1.TabIndex = 2;
            this.neuCheckBox1.Text = "模糊";
            this.neuCheckBox1.UseVisualStyleBackColor = true;
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.Location = new System.Drawing.Point(54, 18);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(160, 21);
            this.neuTextBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.VS2003;
            this.neuTextBox1.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(19, 21);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(29, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.VS2003;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "过滤";
            // 
            // ucQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucQuery";
            this.Size = new System.Drawing.Size(804, 571);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Panel panel1;
        private Neusoft.NFC.Interface.Controls.NeuCheckBox neuCheckBox1;
        private Neusoft.NFC.Interface.Controls.NeuTextBox neuTextBox1;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
    }
}
