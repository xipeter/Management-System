namespace Neusoft.HISFC.Components.Manager.Forms
{
    partial class frmMaintenacePop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbWinName = new System.Windows.Forms.ComboBox();
            this.cmbDLL = new Neusoft.WinForms.Controls.NComboBox();
            this.cmbType = new Neusoft.WinForms.Controls.NComboBox();
            this.fpSpread_Info = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread_Info_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChanel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread_Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread_Info_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbWinName);
            this.groupBox1.Controls.Add(this.cmbDLL);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.fpSpread_Info);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模块接口";
            // 
            // cmbWinName
            // 
            this.cmbWinName.FormattingEnabled = true;
            this.cmbWinName.Location = new System.Drawing.Point(88, 76);
            this.cmbWinName.Name = "cmbWinName";
            this.cmbWinName.Size = new System.Drawing.Size(423, 20);
            this.cmbWinName.TabIndex = 16;
            this.cmbWinName.SelectedValueChanged += new System.EventHandler(this.cmbWinName_SelectedValueChanged);
            // 
            // cmbDLL
            // 
            this.cmbDLL.DisplayMember = "";
            this.cmbDLL.FormattingEnabled = true;
            this.cmbDLL.Location = new System.Drawing.Point(88, 51);
            this.cmbDLL.Name = "cmbDLL";
            this.cmbDLL.NeuHeight = 48;
            this.cmbDLL.QueryType = Neusoft.WinForms.Controls.QueryTypeEnum.编码;
            this.cmbDLL.RowCout = 1;
            this.cmbDLL.Size = new System.Drawing.Size(423, 20);
            this.cmbDLL.TabIndex = 15;
            this.cmbDLL.ValueMember = "";
            this.cmbDLL.SelectedIndexChanged += new System.EventHandler(this.cmbDLL_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.DisplayMember = "";
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsShowCodeColumn = false;
            this.cmbType.Location = new System.Drawing.Point(88, 24);
            this.cmbType.Name = "cmbType";
            this.cmbType.NeuHeight = 209;
            this.cmbType.QueryType = Neusoft.WinForms.Controls.QueryTypeEnum.名称;
            this.cmbType.Size = new System.Drawing.Size(160, 20);
            this.cmbType.TabIndex = 14;
            this.cmbType.ValueMember = "";
            // 
            // fpSpread_Info
            // 
            this.fpSpread_Info.About = "3.0.2004.2005";
            this.fpSpread_Info.AccessibleDescription = "fpSpread_Info, Sheet1, Row 0, Column 0, ";
            this.fpSpread_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread_Info.BackColor = System.Drawing.Color.White;
            this.fpSpread_Info.Location = new System.Drawing.Point(2, 104);
            this.fpSpread_Info.Name = "fpSpread_Info";
            this.fpSpread_Info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread_Info.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread_Info_Sheet1});
            this.fpSpread_Info.Size = new System.Drawing.Size(530, 251);
            this.fpSpread_Info.TabIndex = 8;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread_Info.TextTipAppearance = tipAppearance1;
            this.fpSpread_Info.EditModeOff += new System.EventHandler(this.fpSpread_Info_EditModeOff);
            // 
            // fpSpread_Info_Sheet1
            // 
            this.fpSpread_Info_Sheet1.Reset();
            this.fpSpread_Info_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread_Info_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread_Info_Sheet1.ColumnCount = 5;
            this.fpSpread_Info_Sheet1.RowCount = 5;
            this.fpSpread_Info_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "接口";
            this.fpSpread_Info_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "当前实现动态库名";
            this.fpSpread_Info_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "当前实现类名";
            this.fpSpread_Info_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "必须";
            this.fpSpread_Info_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "备注/说明";
            this.fpSpread_Info_Sheet1.Columns.Get(0).Label = "接口";
            this.fpSpread_Info_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread_Info_Sheet1.Columns.Get(0).Width = 185F;
            this.fpSpread_Info_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpSpread_Info_Sheet1.Columns.Get(1).Label = "当前实现动态库名";
            this.fpSpread_Info_Sheet1.Columns.Get(1).Width = 120F;
            this.fpSpread_Info_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpSpread_Info_Sheet1.Columns.Get(2).Label = "当前实现类名";
            this.fpSpread_Info_Sheet1.Columns.Get(2).Width = 167F;
            this.fpSpread_Info_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpSpread_Info_Sheet1.Columns.Get(3).CellType = checkBoxCellType1;
            this.fpSpread_Info_Sheet1.Columns.Get(3).Label = "必须";
            this.fpSpread_Info_Sheet1.Columns.Get(3).Width = 46F;
            this.fpSpread_Info_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpSpread_Info_Sheet1.Columns.Get(4).Label = "备注/说明";
            this.fpSpread_Info_Sheet1.Columns.Get(4).Width = 85F;
            this.fpSpread_Info_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpSpread_Info_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread_Info_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "组件类名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "动态库名：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(319, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 21);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称定义：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属模块：";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(388, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChanel
            // 
            this.btnChanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChanel.Location = new System.Drawing.Point(469, 390);
            this.btnChanel.Name = "btnChanel";
            this.btnChanel.Size = new System.Drawing.Size(75, 23);
            this.btnChanel.TabIndex = 10;
            this.btnChanel.Text = "取消(&C)";
            this.btnChanel.UseVisualStyleBackColor = true;
            this.btnChanel.Click += new System.EventHandler(this.btnChanel_Click);
            // 
            // frmMaintenacePop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 425);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChanel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaintenacePop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "接口实现管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread_Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread_Info_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread_Info_Sheet1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChanel;
        private FarPoint.Win.Spread.FpSpread fpSpread_Info;
        private Neusoft.WinForms.Controls.NComboBox cmbType;
        private Neusoft.WinForms.Controls.NComboBox cmbDLL;
        private System.Windows.Forms.ComboBox cmbWinName;
    }
}