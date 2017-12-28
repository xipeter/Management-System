namespace Neusoft.FrameWork.WinForms.Controls
{
    partial class ucMaintenanceXML
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.chkFilter = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboOperDate = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboOperator = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnTest = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtSQL = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtXML = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.neuTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(954, 620);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler(this.neuTabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neuSpread1);
            this.tabPage2.Controls.Add(this.neuSplitter1);
            this.tabPage2.Controls.Add(this.neuPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(946, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.neuSpread1.Location = new System.Drawing.Point(3, 143);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(940, 449);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ButtonClicked);
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
            // neuSplitter1
            // 
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter1.Location = new System.Drawing.Point(3, 140);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(940, 3);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 4;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.chkFilter);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.cboOperDate);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.cboOperator);
            this.neuPanel1.Controls.Add(this.btnTest);
            this.neuPanel1.Controls.Add(this.txtSQL);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(3, 3);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(940, 137);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(17, 115);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(593, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 7;
            this.neuLabel3.Text = "名称、拼音码和五笔码为关键字，如需自动生成拼音码和五笔码，请将相关字段名称改为名称、拼音码和五笔码";
            // 
            // chkFilter
            // 
            this.chkFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(665, 85);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(96, 16);
            this.chkFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkFilter.TabIndex = 6;
            this.chkFilter.Text = "显示过滤条件";
            this.chkFilter.UseVisualStyleBackColor = true;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(651, 45);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(77, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 5;
            this.neuLabel2.Text = "操作日期字段";
            // 
            // cboOperDate
            // 
            this.cboOperDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperDate.FormattingEnabled = true;
            this.cboOperDate.IsLike = true;
            this.cboOperDate.Location = new System.Drawing.Point(736, 41);
            this.cboOperDate.Name = "cboOperDate";
            this.cboOperDate.PopForm = null;
            this.cboOperDate.IsShowCustomerList = false;
            this.cboOperDate.ShowID = false;
            this.cboOperDate.Size = new System.Drawing.Size(135, 20);
            this.cboOperDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboOperDate.TabIndex = 4;
            this.cboOperDate.Tag = "";
            // 
            // neuLabel1
            // 
            this.neuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(651, 20);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "操作员字段";
            // 
            // cboOperator
            // 
            this.cboOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.IsLike = true;
            this.cboOperator.Location = new System.Drawing.Point(736, 15);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.PopForm = null;
            this.cboOperator.IsShowCustomerList = false;
            this.cboOperator.IsShowID = false;
            this.cboOperator.Size = new System.Drawing.Size(135, 20);
            this.cboOperator.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboOperator.TabIndex = 2;
            this.cboOperator.Tag = "";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(897, 20);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(31, 88);
            this.btnTest.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "重置";
            this.btnTest.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(645, 108);
            this.txtSQL.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSQL.TabIndex = 0;
            this.txtSQL.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtXML);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(946, 595);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "XML";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtXML
            // 
            this.txtXML.BackColor = System.Drawing.Color.White;
            this.txtXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXML.Location = new System.Drawing.Point(3, 3);
            this.txtXML.Name = "txtXML";
            this.txtXML.ReadOnly = true;
            this.txtXML.Size = new System.Drawing.Size(940, 589);
            this.txtXML.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtXML.TabIndex = 0;
            this.txtXML.Text = "";
            // 
            // ucMaintenanceXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucMaintenanceXML";
            this.Size = new System.Drawing.Size(954, 620);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NeuRichTextBox txtXML;
        private NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private NeuRichTextBox txtSQL;
        private NeuPanel neuPanel1;
        private NeuSplitter neuSplitter1;
        private NeuButton btnTest;
        private NeuLabel neuLabel2;
        private NeuComboBox cboOperDate;
        private NeuLabel neuLabel1;
        private NeuComboBox cboOperator;
        private NeuCheckBox chkFilter;
        private NeuLabel neuLabel3;
    }
}
