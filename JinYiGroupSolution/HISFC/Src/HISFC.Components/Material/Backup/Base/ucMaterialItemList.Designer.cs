namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMaterialItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMaterialItemList));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterField = new System.Windows.Forms.ComboBox();
            this.ckBlurFilter = new System.Windows.Forms.CheckBox();
            this.chkRealTimeFilter = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.showStopCk = new System.Windows.Forms.CheckBox();
            this.txtQueryCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.captionLabel = new System.Windows.Forms.Label();
            this.lnbAdvanceFilter = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "过滤方式";
            // 
            // cmbFilterField
            // 
            this.cmbFilterField.FormattingEnabled = true;
            this.cmbFilterField.Items.AddRange(new object[] {
            "全部",
            "拼音码",
            "五笔码",
            "自定义码",
            "商品名称"});
            this.cmbFilterField.Location = new System.Drawing.Point(59, 17);
            this.cmbFilterField.Name = "cmbFilterField";
            this.cmbFilterField.Size = new System.Drawing.Size(108, 20);
            this.cmbFilterField.TabIndex = 7;
            // 
            // ckBlurFilter
            // 
            this.ckBlurFilter.AutoSize = true;
            this.ckBlurFilter.Checked = true;
            this.ckBlurFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBlurFilter.Location = new System.Drawing.Point(8, 48);
            this.ckBlurFilter.Name = "ckBlurFilter";
            this.ckBlurFilter.Size = new System.Drawing.Size(72, 16);
            this.ckBlurFilter.TabIndex = 2;
            this.ckBlurFilter.Text = "模糊过滤";
            this.ckBlurFilter.UseVisualStyleBackColor = true;
            // 
            // chkRealTimeFilter
            // 
            this.chkRealTimeFilter.AutoSize = true;
            this.chkRealTimeFilter.Checked = true;
            this.chkRealTimeFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRealTimeFilter.Location = new System.Drawing.Point(154, 47);
            this.chkRealTimeFilter.Name = "chkRealTimeFilter";
            this.chkRealTimeFilter.Size = new System.Drawing.Size(72, 16);
            this.chkRealTimeFilter.TabIndex = 2;
            this.chkRealTimeFilter.Text = "实时过滤";
            this.chkRealTimeFilter.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "过 滤 框";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.neuSpread1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 65);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(235, 350);
            this.panelList.TabIndex = 8;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(235, 350);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // showStopCk
            // 
            this.showStopCk.AutoSize = true;
            this.showStopCk.Checked = true;
            this.showStopCk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStopCk.Location = new System.Drawing.Point(81, 47);
            this.showStopCk.Name = "showStopCk";
            this.showStopCk.Size = new System.Drawing.Size(72, 16);
            this.showStopCk.TabIndex = 2;
            this.showStopCk.Text = "显示停用";
            this.showStopCk.UseVisualStyleBackColor = true;
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.Location = new System.Drawing.Point(62, 5);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(109, 21);
            this.txtQueryCode.TabIndex = 1;
            this.txtQueryCode.TextChanged += new System.EventHandler(this.txtQueryCode_TextChanged);
            this.txtQueryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQueryCode_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeButton);
            this.groupBox1.Controls.Add(this.captionLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 35);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(204, 14);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 16);
            this.closeButton.TabIndex = 1;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Location = new System.Drawing.Point(1, 15);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(53, 12);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "物品选择";
            // 
            // lnbAdvanceFilter
            // 
            this.lnbAdvanceFilter.AutoSize = true;
            this.lnbAdvanceFilter.Location = new System.Drawing.Point(177, 10);
            this.lnbAdvanceFilter.Name = "lnbAdvanceFilter";
            this.lnbAdvanceFilter.Size = new System.Drawing.Size(53, 12);
            this.lnbAdvanceFilter.TabIndex = 2;
            this.lnbAdvanceFilter.TabStop = true;
            this.lnbAdvanceFilter.Text = "高级过滤";
            this.lnbAdvanceFilter.Visible = false;
            this.lnbAdvanceFilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbAdvanceFilter_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbFilterField);
            this.groupBox2.Controls.Add(this.ckBlurFilter);
            this.groupBox2.Controls.Add(this.chkRealTimeFilter);
            this.groupBox2.Controls.Add(this.showStopCk);
            this.groupBox2.Location = new System.Drawing.Point(4, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级过滤 ";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lnbAdvanceFilter);
            this.panelFilter.Controls.Add(this.groupBox2);
            this.panelFilter.Controls.Add(this.txtQueryCode);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(235, 30);
            this.panelFilter.TabIndex = 7;
            // 
            // ucMaterialItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelFilter);
            this.Name = "ucMaterialItemList";
            this.Size = new System.Drawing.Size(235, 415);
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterField;
        private System.Windows.Forms.CheckBox ckBlurFilter;
        private System.Windows.Forms.CheckBox chkRealTimeFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelList;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private System.Windows.Forms.CheckBox showStopCk;
        private System.Windows.Forms.TextBox txtQueryCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.LinkLabel lnbAdvanceFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelFilter;
    }
}
