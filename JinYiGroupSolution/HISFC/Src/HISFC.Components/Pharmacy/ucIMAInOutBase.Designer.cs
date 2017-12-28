namespace UFC.Pharmacy
{
    partial class ucIMAInOutBase
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

            try
            {
                if (this.isSaveDefaultPriv)
                {
                    this.SavePriv();
                }
                if (this.neuSpread1 != null)
                {
                    this.neuSpread1.Dispose();
                    this.neuSpread1 = null;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.NFC.Management.Language.Msg("退出保存当前权限类型失败") + ex.Message); 
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.cmbTargetDept = new Neusoft.NFC.Interface.Controls.NeuComboBox(this.components);
            this.cmbTargetPerson = new Neusoft.NFC.Interface.Controls.NeuComboBox(this.components);
            this.cmbPrivType = new Neusoft.NFC.Interface.Controls.NeuComboBox(this.components);
            this.txtPrivType = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.lnbPrivType = new Neusoft.NFC.Interface.Controls.NeuLinkLabel();
            this.txtTargetPerson = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.lnbTargetPerson = new Neusoft.NFC.Interface.Controls.NeuLinkLabel();
            this.txtTargetDept = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.lnbTarget = new Neusoft.NFC.Interface.Controls.NeuLinkLabel();
            this.panelItemSelect = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.NFC.Interface.Controls.NeuSplitter();
            this.neuPanel3 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.panelItemShow = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.NFC.Interface.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel4 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.txtFilter = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lbTotCost = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lbInfo = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuSplitter2 = new Neusoft.NFC.Interface.Controls.NeuSplitter();
            this.panelItemManager = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.panelItemShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.cmbTargetDept);
            this.neuPanel1.Controls.Add(this.cmbTargetPerson);
            this.neuPanel1.Controls.Add(this.cmbPrivType);
            this.neuPanel1.Controls.Add(this.txtPrivType);
            this.neuPanel1.Controls.Add(this.lnbPrivType);
            this.neuPanel1.Controls.Add(this.txtTargetPerson);
            this.neuPanel1.Controls.Add(this.lnbTargetPerson);
            this.neuPanel1.Controls.Add(this.txtTargetDept);
            this.neuPanel1.Controls.Add(this.lnbTarget);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(689, 34);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // cmbTargetDept
            // 
            this.cmbTargetDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTargetDept.FormattingEnabled = true;
            this.cmbTargetDept.IsFlat = true;
            this.cmbTargetDept.IsLike = true;
            this.cmbTargetDept.Location = new System.Drawing.Point(239, 6);
            this.cmbTargetDept.Name = "cmbTargetDept";
            this.cmbTargetDept.PopForm = null;
            this.cmbTargetDept.ShowCustomerList = false;
            this.cmbTargetDept.ShowID = false;
            this.cmbTargetDept.Size = new System.Drawing.Size(218, 20);
            this.cmbTargetDept.Style = Neusoft.NFC.Interface.Controls.StyleType.Flat;
            this.cmbTargetDept.TabIndex = 12;
            this.cmbTargetDept.Tag = "";
            this.cmbTargetDept.ToolBarUse = false;
            this.cmbTargetDept.Visible = false;
            this.cmbTargetDept.SelectedIndexChanged += new System.EventHandler(this.cmbTargetDept_SelectedIndexChanged);
            // 
            // cmbTargetPerson
            // 
            this.cmbTargetPerson.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTargetPerson.FormattingEnabled = true;
            this.cmbTargetPerson.IsFlat = true;
            this.cmbTargetPerson.IsLike = true;
            this.cmbTargetPerson.Location = new System.Drawing.Point(517, 6);
            this.cmbTargetPerson.Name = "cmbTargetPerson";
            this.cmbTargetPerson.PopForm = null;
            this.cmbTargetPerson.ShowCustomerList = false;
            this.cmbTargetPerson.ShowID = false;
            this.cmbTargetPerson.Size = new System.Drawing.Size(91, 20);
            this.cmbTargetPerson.Style = Neusoft.NFC.Interface.Controls.StyleType.Flat;
            this.cmbTargetPerson.TabIndex = 12;
            this.cmbTargetPerson.Tag = "";
            this.cmbTargetPerson.ToolBarUse = false;
            this.cmbTargetPerson.Visible = false;
            this.cmbTargetPerson.SelectedIndexChanged += new System.EventHandler(this.cmbTargetPerson_SelectedIndexChanged);
            // 
            // cmbPrivType
            // 
            this.cmbPrivType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPrivType.FormattingEnabled = true;
            this.cmbPrivType.IsFlat = true;
            this.cmbPrivType.IsLike = true;
            this.cmbPrivType.Location = new System.Drawing.Point(61, 6);
            this.cmbPrivType.Name = "cmbPrivType";
            this.cmbPrivType.PopForm = null;
            this.cmbPrivType.ShowCustomerList = false;
            this.cmbPrivType.ShowID = false;
            this.cmbPrivType.Size = new System.Drawing.Size(122, 20);
            this.cmbPrivType.Style = Neusoft.NFC.Interface.Controls.StyleType.Flat;
            this.cmbPrivType.TabIndex = 12;
            this.cmbPrivType.Tag = "";
            this.cmbPrivType.ToolBarUse = false;
            this.cmbPrivType.SelectedIndexChanged += new System.EventHandler(this.cmbPrivType_SelectedIndexChanged);
            // 
            // txtPrivType
            // 
            this.txtPrivType.Enabled = false;
            this.txtPrivType.Location = new System.Drawing.Point(61, 6);
            this.txtPrivType.Name = "txtPrivType";
            this.txtPrivType.Size = new System.Drawing.Size(122, 21);
            this.txtPrivType.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtPrivType.TabIndex = 11;
            this.txtPrivType.Visible = false;
            // 
            // lnbPrivType
            // 
            this.lnbPrivType.AutoSize = true;
            this.lnbPrivType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbPrivType.Location = new System.Drawing.Point(4, 10);
            this.lnbPrivType.Name = "lnbPrivType";
            this.lnbPrivType.Size = new System.Drawing.Size(53, 12);
            this.lnbPrivType.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lnbPrivType.TabIndex = 10;
            this.lnbPrivType.TabStop = true;
            this.lnbPrivType.Text = "操作类别";
            this.lnbPrivType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbPrivType_LinkClicked);
            // 
            // txtTargetPerson
            // 
            this.txtTargetPerson.Enabled = false;
            this.txtTargetPerson.Location = new System.Drawing.Point(517, 6);
            this.txtTargetPerson.Name = "txtTargetPerson";
            this.txtTargetPerson.Size = new System.Drawing.Size(91, 21);
            this.txtTargetPerson.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtTargetPerson.TabIndex = 9;
            this.txtTargetPerson.Visible = false;
            // 
            // lnbTargetPerson
            // 
            this.lnbTargetPerson.AutoSize = true;
            this.lnbTargetPerson.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbTargetPerson.Location = new System.Drawing.Point(461, 10);
            this.lnbTargetPerson.Name = "lnbTargetPerson";
            this.lnbTargetPerson.Size = new System.Drawing.Size(53, 12);
            this.lnbTargetPerson.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lnbTargetPerson.TabIndex = 8;
            this.lnbTargetPerson.TabStop = true;
            this.lnbTargetPerson.Text = "领 送 人";
            this.lnbTargetPerson.Visible = false;
            this.lnbTargetPerson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbPerson_LinkClicked);
            // 
            // txtTargetDept
            // 
            this.txtTargetDept.Enabled = false;
            this.txtTargetDept.Location = new System.Drawing.Point(239, 6);
            this.txtTargetDept.Name = "txtTargetDept";
            this.txtTargetDept.Size = new System.Drawing.Size(218, 21);
            this.txtTargetDept.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtTargetDept.TabIndex = 7;
            this.txtTargetDept.Visible = false;
            // 
            // lnbTarget
            // 
            this.lnbTarget.AutoSize = true;
            this.lnbTarget.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbTarget.Location = new System.Drawing.Point(184, 10);
            this.lnbTarget.Name = "lnbTarget";
            this.lnbTarget.Size = new System.Drawing.Size(53, 12);
            this.lnbTarget.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lnbTarget.TabIndex = 6;
            this.lnbTarget.TabStop = true;
            this.lnbTarget.Text = "目标单位";
            this.lnbTarget.Visible = false;
            this.lnbTarget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbTarget_LinkClicked);
            // 
            // panelItemSelect
            // 
            this.panelItemSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelItemSelect.Location = new System.Drawing.Point(0, 0);
            this.panelItemSelect.Name = "panelItemSelect";
            this.panelItemSelect.Size = new System.Drawing.Size(174, 455);
            this.panelItemSelect.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.panelItemSelect.TabIndex = 1;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(174, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 455);
            this.neuSplitter1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 2;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.panelItemShow);
            this.neuPanel3.Controls.Add(this.neuSplitter2);
            this.neuPanel3.Controls.Add(this.panelItemManager);
            this.neuPanel3.Controls.Add(this.neuPanel1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(177, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(689, 455);
            this.neuPanel3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 3;
            // 
            // panelItemShow
            // 
            this.panelItemShow.Controls.Add(this.neuSpread1);
            this.panelItemShow.Controls.Add(this.neuPanel4);
            this.panelItemShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItemShow.Location = new System.Drawing.Point(0, 173);
            this.panelItemShow.Name = "panelItemShow";
            this.panelItemShow.Size = new System.Drawing.Size(689, 282);
            this.panelItemShow.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.panelItemShow.TabIndex = 1;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 39);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(689, 243);
            this.neuSpread1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance3;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.txtFilter);
            this.neuPanel4.Controls.Add(this.neuLabel1);
            this.neuPanel4.Controls.Add(this.lbTotCost);
            this.neuPanel4.Controls.Add(this.lbInfo);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel4.Location = new System.Drawing.Point(0, 0);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(689, 39);
            this.neuPanel4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(63, 11);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(90, 21);
            this.txtFilter.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(6, 15);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "过    滤";
            // 
            // lbTotCost
            // 
            this.lbTotCost.AutoSize = true;
            this.lbTotCost.ForeColor = System.Drawing.Color.Blue;
            this.lbTotCost.Location = new System.Drawing.Point(158, 15);
            this.lbTotCost.Name = "lbTotCost";
            this.lbTotCost.Size = new System.Drawing.Size(41, 12);
            this.lbTotCost.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbTotCost.TabIndex = 1;
            this.lbTotCost.Text = "总金额";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoEllipsis = true;
            this.lbInfo.AutoSize = true;
            this.lbInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbInfo.Location = new System.Drawing.Point(501, 15);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(53, 12);
            this.lbInfo.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "信息说明";
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(0, 170);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(689, 3);
            this.neuSplitter2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 3;
            this.neuSplitter2.TabStop = false;
            // 
            // panelItemManager
            // 
            this.panelItemManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemManager.Location = new System.Drawing.Point(0, 34);
            this.panelItemManager.Name = "panelItemManager";
            this.panelItemManager.Size = new System.Drawing.Size(689, 136);
            this.panelItemManager.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.panelItemManager.TabIndex = 2;
            // 
            // ucIMAInOutBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel3);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.panelItemSelect);
            this.Name = "ucIMAInOutBase";
            this.Size = new System.Drawing.Size(866, 455);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            this.panelItemShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtTargetDept;
        private Neusoft.NFC.Interface.Controls.NeuLinkLabel lnbTarget;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtTargetPerson;
        private Neusoft.NFC.Interface.Controls.NeuLinkLabel lnbTargetPerson;
        private Neusoft.NFC.Interface.Controls.NeuSplitter neuSplitter1;
        private Neusoft.NFC.Interface.Controls.NeuPanel panelItemShow;
        protected Neusoft.NFC.Interface.Controls.NeuPanel neuPanel3;
        private Neusoft.NFC.Interface.Controls.NeuSplitter neuSplitter2;
        protected Neusoft.NFC.Interface.Controls.NeuPanel neuPanel4;
        protected Neusoft.NFC.Interface.Controls.NeuLabel lbInfo;
        protected Neusoft.NFC.Interface.Controls.NeuPanel panelItemManager;
        protected Neusoft.NFC.Interface.Controls.NeuLabel lbTotCost;
        protected Neusoft.NFC.Interface.Controls.NeuSpread neuSpread1;
        protected Neusoft.NFC.Interface.Controls.NeuPanel panelItemSelect;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtPrivType;
        private Neusoft.NFC.Interface.Controls.NeuLinkLabel lnbPrivType;
        protected FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtFilter;
        private Neusoft.NFC.Interface.Controls.NeuComboBox cmbPrivType;
        private Neusoft.NFC.Interface.Controls.NeuComboBox cmbTargetDept;
        private Neusoft.NFC.Interface.Controls.NeuComboBox cmbTargetPerson;
    }
}
