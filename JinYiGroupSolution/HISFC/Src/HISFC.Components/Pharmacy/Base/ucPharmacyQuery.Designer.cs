namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    partial class ucPharmacyQuery
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
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.chbMistyFilter = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.ckRealTimeFilter = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbValid = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lbFilterField = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtInputCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvType = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 34);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(539, 409);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            this.neuSpread1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.neuSpread1_ColumnWidthChanged);
            this.neuSpread1.AutoSortingColumn += new FarPoint.Win.Spread.AutoSortingColumnEventHandler(this.neuSpread1_AutoSortingColumn);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
            this.neuSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 40F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.neuSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.White;
            this.neuPanel1.Controls.Add(this.chbMistyFilter);
            this.neuPanel1.Controls.Add(this.ckRealTimeFilter);
            this.neuPanel1.Controls.Add(this.cmbValid);
            this.neuPanel1.Controls.Add(this.lbFilterField);
            this.neuPanel1.Controls.Add(this.txtInputCode);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(539, 34);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // chbMistyFilter
            // 
            this.chbMistyFilter.AutoSize = true;
            this.chbMistyFilter.ForeColor = System.Drawing.Color.Blue;
            this.chbMistyFilter.Location = new System.Drawing.Point(387, 9);
            this.chbMistyFilter.Name = "chbMistyFilter";
            this.chbMistyFilter.Size = new System.Drawing.Size(72, 16);
            this.chbMistyFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbMistyFilter.TabIndex = 5;
            this.chbMistyFilter.Text = "模糊过滤";
            this.chbMistyFilter.UseVisualStyleBackColor = true;
            // 
            // ckRealTimeFilter
            // 
            this.ckRealTimeFilter.AutoSize = true;
            this.ckRealTimeFilter.Checked = true;
            this.ckRealTimeFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckRealTimeFilter.ForeColor = System.Drawing.Color.Blue;
            this.ckRealTimeFilter.Location = new System.Drawing.Point(465, 9);
            this.ckRealTimeFilter.Name = "ckRealTimeFilter";
            this.ckRealTimeFilter.Size = new System.Drawing.Size(72, 16);
            this.ckRealTimeFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckRealTimeFilter.TabIndex = 4;
            this.ckRealTimeFilter.Text = "实时过滤";
            this.ckRealTimeFilter.UseVisualStyleBackColor = true;
            // 
            // cmbValid
            // 
            this.cmbValid.FormattingEnabled = true;
            this.cmbValid.IsEnter2Tab = false;
            this.cmbValid.IsFlat = true;
            this.cmbValid.IsLike = true;
            this.cmbValid.IsListOnly = false;
            this.cmbValid.Items.AddRange(new object[] {
            "全部",
            "在用",
            "停用"});
            this.cmbValid.Location = new System.Drawing.Point(289, 6);
            this.cmbValid.Name = "cmbValid";
            this.cmbValid.PopForm = null;
            this.cmbValid.ShowCustomerList = false;
            this.cmbValid.ShowID = false;
            this.cmbValid.Size = new System.Drawing.Size(88, 20);
            this.cmbValid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbValid.TabIndex = 3;
            this.cmbValid.Tag = "";
            this.cmbValid.ToolBarUse = false;
            this.cmbValid.SelectedIndexChanged += new System.EventHandler(this.cmbFilterField_SelectedIndexChanged);
            // 
            // lbFilterField
            // 
            this.lbFilterField.AutoSize = true;
            this.lbFilterField.ForeColor = System.Drawing.Color.Blue;
            this.lbFilterField.Location = new System.Drawing.Point(239, 10);
            this.lbFilterField.Name = "lbFilterField";
            this.lbFilterField.Size = new System.Drawing.Size(47, 12);
            this.lbFilterField.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbFilterField.TabIndex = 2;
            this.lbFilterField.Text = "状  态:";
            // 
            // txtInputCode
            // 
            this.txtInputCode.IsEnter2Tab = false;
            this.txtInputCode.Location = new System.Drawing.Point(50, 6);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(143, 21);
            this.txtInputCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInputCode.TabIndex = 1;
            this.txtInputCode.TextChanged += new System.EventHandler(this.neuTextBox1_TextChanged);
            this.txtInputCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputCode_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(4, 10);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "过滤框";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSpread1);
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(721, 443);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvType
            // 
            this.tvType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvType.HideSelection = false;
            this.tvType.Location = new System.Drawing.Point(0, 0);
            this.tvType.Name = "tvType";
            this.tvType.Size = new System.Drawing.Size(178, 443);
            this.tvType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvType.TabIndex = 0;
            this.tvType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvType_AfterSelect);
            // 
            // ucPharmacyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucPharmacyQuery";
            this.Size = new System.Drawing.Size(721, 443);
            this.Load += new System.EventHandler(this.ucPharmacyQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInputCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbFilterField;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvType;
        protected Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbValid;
        protected Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckRealTimeFilter;
        protected Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbMistyFilter;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
    }
}
