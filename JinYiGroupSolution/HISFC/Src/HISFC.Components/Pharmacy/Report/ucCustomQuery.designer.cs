namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    partial class ucCustomQuery
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
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelDefineQuery = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuFpEnter1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuFpEnter1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuButton2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnUp = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.rbOwner = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.rbAll = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rbDept = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.ckDistinct = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new Neusoft.FrameWork.WinForms.Controls.RichTextBox();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelDefineQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Controls.Add(this.tabPage3);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(999, 409);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelDefineQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(991, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查询定义";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelDefineQuery
            // 
            this.panelDefineQuery.Controls.Add(this.neuFpEnter1);
            this.panelDefineQuery.Controls.Add(this.neuGroupBox1);
            this.panelDefineQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDefineQuery.Location = new System.Drawing.Point(3, 3);
            this.panelDefineQuery.Name = "panelDefineQuery";
            this.panelDefineQuery.Size = new System.Drawing.Size(985, 378);
            this.panelDefineQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelDefineQuery.TabIndex = 0;
            // 
            // neuFpEnter1
            // 
            this.neuFpEnter1.About = "2.5.2007.2005";
            this.neuFpEnter1.AccessibleDescription = "neuFpEnter1, Sheet1, Row 0, Column 0, ";
            this.neuFpEnter1.BackColor = System.Drawing.Color.Transparent;
            this.neuFpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuFpEnter1.EditModePermanent = true;
            this.neuFpEnter1.EditModeReplace = true;
            this.neuFpEnter1.Location = new System.Drawing.Point(0, 50);
            this.neuFpEnter1.Name = "neuFpEnter1";
            this.neuFpEnter1.SelectNone = false;
            this.neuFpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuFpEnter1_Sheet1});
            this.neuFpEnter1.ShowListWhenOfFocus = false;
            this.neuFpEnter1.Size = new System.Drawing.Size(985, 328);
            this.neuFpEnter1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuFpEnter1.TextTipAppearance = tipAppearance1;
            // 
            // neuFpEnter1_Sheet1
            // 
            this.neuFpEnter1_Sheet1.Reset();
            this.neuFpEnter1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuFpEnter1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuFpEnter1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuFpEnter1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuFpEnter1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuFpEnter1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuFpEnter1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuFpEnter1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuFpEnter1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuFpEnter1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuFpEnter1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuFpEnter1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuFpEnter1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuFpEnter1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuButton2);
            this.neuGroupBox1.Controls.Add(this.btnUp);
            this.neuGroupBox1.Controls.Add(this.rbOwner);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.rbAll);
            this.neuGroupBox1.Controls.Add(this.rbDept);
            this.neuGroupBox1.Controls.Add(this.ckDistinct);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(985, 50);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuButton2
            // 
            this.neuButton2.Location = new System.Drawing.Point(490, 16);
            this.neuButton2.Name = "neuButton2";
            this.neuButton2.Size = new System.Drawing.Size(75, 23);
            this.neuButton2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton2.TabIndex = 5;
            this.neuButton2.Text = "下移";
            this.neuButton2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton2.UseVisualStyleBackColor = true;
            this.neuButton2.Visible = false;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(392, 16);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "上移";
            this.btnUp.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // rbOwner
            // 
            this.rbOwner.AutoSize = true;
            this.rbOwner.Checked = true;
            this.rbOwner.Location = new System.Drawing.Point(210, 19);
            this.rbOwner.Name = "rbOwner";
            this.rbOwner.Size = new System.Drawing.Size(47, 16);
            this.rbOwner.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbOwner.TabIndex = 1;
            this.rbOwner.TabStop = true;
            this.rbOwner.Text = "个人";
            this.rbOwner.UseVisualStyleBackColor = true;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(165, 21);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "共享：";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(312, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbAll.TabIndex = 3;
            this.rbAll.Text = "全院";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.Location = new System.Drawing.Point(261, 19);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(47, 16);
            this.rbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbDept.TabIndex = 2;
            this.rbDept.Text = "科室";
            this.rbDept.UseVisualStyleBackColor = true;
            // 
            // ckDistinct
            // 
            this.ckDistinct.AutoSize = true;
            this.ckDistinct.ForeColor = System.Drawing.Color.Black;
            this.ckDistinct.Location = new System.Drawing.Point(6, 20);
            this.ckDistinct.Name = "ckDistinct";
            this.ckDistinct.Size = new System.Drawing.Size(120, 16);
            this.ckDistinct.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckDistinct.TabIndex = 0;
            this.ckDistinct.Text = "不显示重复的数据";
            this.ckDistinct.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(991, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(991, 384);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SQL-Bug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.IsDrawLine = false;
            this.richTextBox1.IsExactSearch = false;
            this.richTextBox1.IsShowModify = false;
            this.richTextBox1.KeyWordIndex = 0;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.SearchTable = null;
            this.richTextBox1.SelectText = "";
            this.richTextBox1.Size = new System.Drawing.Size(991, 384);
            this.richTextBox1.SuperText = "";
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.名称 = null;
            this.richTextBox1.是否组 = false;
            this.richTextBox1.组 = "无";
            // 
            // ucCustomQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucCustomQuery";
            this.Size = new System.Drawing.Size(999, 409);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelDefineQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelDefineQuery;
        private System.Windows.Forms.TabPage tabPage3;
        private Neusoft.FrameWork.WinForms.Controls.RichTextBox richTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuFpEnter1;
        private FarPoint.Win.Spread.SheetView neuFpEnter1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckDistinct;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbOwner;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnUp;
    }
}
