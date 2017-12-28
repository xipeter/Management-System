namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucDrugList
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
                if (this.dt != null)
                {
                    this.dt.Clear();
                    this.dt.Dispose();

                    this.dt = null;
                }
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrugList));
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.captionLabel = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lbItemType = new System.Windows.Forms.Label();
            this.cmbItemType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtQueryCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelList.SuspendLayout();
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(262, 348);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeButton);
            this.groupBox1.Controls.Add(this.captionLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 35);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(204, 11);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 16);
            this.closeButton.TabIndex = 1;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.ForeColor = System.Drawing.Color.Blue;
            this.captionLabel.Location = new System.Drawing.Point(2, 14);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(113, 12);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "药品选择－全部药品";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lbItemType);
            this.panelFilter.Controls.Add(this.cmbItemType);
            this.panelFilter.Controls.Add(this.txtQueryCode);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 35);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(262, 32);
            this.panelFilter.TabIndex = 4;
            // 
            // lbItemType
            // 
            this.lbItemType.AutoSize = true;
            this.lbItemType.ForeColor = System.Drawing.Color.Blue;
            this.lbItemType.Location = new System.Drawing.Point(150, 10);
            this.lbItemType.Name = "lbItemType";
            this.lbItemType.Size = new System.Drawing.Size(35, 12);
            this.lbItemType.TabIndex = 8;
            this.lbItemType.Text = "类 别";
            this.lbItemType.Visible = false;
            // 
            // cmbItemType
            // 
            //this.cmbItemType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.IsFlat = true;
            this.cmbItemType.IsLike = true;
            this.cmbItemType.Location = new System.Drawing.Point(188, 6);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.PopForm = null;
            this.cmbItemType.ShowCustomerList = false;
            this.cmbItemType.ShowID = false;
            this.cmbItemType.Size = new System.Drawing.Size(71, 20);
            this.cmbItemType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbItemType.TabIndex = 7;
            this.cmbItemType.Tag = "";
            this.cmbItemType.ToolBarUse = false;
            this.cmbItemType.Visible = false;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.Location = new System.Drawing.Point(59, 6);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(74, 21);
            this.txtQueryCode.TabIndex = 1;
            this.txtQueryCode.TextChanged += new System.EventHandler(this.txtQueryCode_TextChanged);
            this.txtQueryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQueryCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "过 滤 框";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.neuSpread1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 67);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(262, 348);
            this.panelList.TabIndex = 5;
            // 
            // ucDrugList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucDrugList";
            this.Size = new System.Drawing.Size(262, 415);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected  Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        protected FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.PictureBox closeButton;
        protected System.Windows.Forms.Label captionLabel;
        protected System.Windows.Forms.Panel panelFilter;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtQueryCode;
        protected System.Windows.Forms.Panel panelList;
        protected Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbItemType;
        protected System.Windows.Forms.Label lbItemType;
    }
}
