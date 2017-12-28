namespace Neusoft.HISFC.Components.Common.Forms
{
    partial class frmSelectGroup
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.spread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.spread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.chkAll = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spread1
            // 
            this.spread1.About = "2.5.2007.2005";
            this.spread1.AccessibleDescription = "";
            this.spread1.BackColor = System.Drawing.Color.White;
            this.spread1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spread1.FileName = "";
            this.spread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spread1.IsAutoSaveGridStatus = false;
            this.spread1.IsCanCustomConfigColumn = false;
            this.spread1.Location = new System.Drawing.Point(0, 0);
            this.spread1.Name = "spread1";
            this.spread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spread1_Sheet1});
            this.spread1.Size = new System.Drawing.Size(699, 308);
            this.spread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.spread1.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spread1.TextTipAppearance = tipAppearance2;
            this.spread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spread1_CellClick);
            // 
            // spread1_Sheet1
            // 
            this.spread1_Sheet1.Reset();
            this.spread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.spread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(536, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(617, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(13, 75);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkAll.TabIndex = 3;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuTextBox1);
            this.neuPanel1.Controls.Add(this.btnCancel);
            this.neuPanel1.Controls.Add(this.chkAll);
            this.neuPanel1.Controls.Add(this.btnOK);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 308);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(699, 94);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 4;
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.neuTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.neuTextBox1.IsEnter2Tab = false;
            this.neuTextBox1.Location = new System.Drawing.Point(0, 0);
            this.neuTextBox1.Multiline = true;
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(699, 62);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 4;
            // 
            // frmSelectGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 402);
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.spread1);
            this.Name = "frmSelectGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱选择";
            ((System.ComponentModel.ISupportInitialize)(this.spread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread spread1;
        private FarPoint.Win.Spread.SheetView spread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
    }
}