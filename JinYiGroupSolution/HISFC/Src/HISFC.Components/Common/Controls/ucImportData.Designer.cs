namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucImportData
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ckDbf = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.ckXls = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.btnImport = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lbDataInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnBrower = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtFilePath = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ckDbf);
            this.neuPanel1.Controls.Add(this.ckXls);
            this.neuPanel1.Controls.Add(this.btnImport);
            this.neuPanel1.Controls.Add(this.lbDataInfo);
            this.neuPanel1.Controls.Add(this.btnBrower);
            this.neuPanel1.Controls.Add(this.txtFilePath);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(677, 59);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // ckDbf
            // 
            this.ckDbf.AutoSize = true;
            this.ckDbf.ForeColor = System.Drawing.Color.Blue;
            this.ckDbf.Location = new System.Drawing.Point(62, 34);
            this.ckDbf.Name = "ckDbf";
            this.ckDbf.Size = new System.Drawing.Size(47, 16);
            this.ckDbf.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckDbf.TabIndex = 5;
            this.ckDbf.Text = ".dbf";
            this.ckDbf.UseVisualStyleBackColor = true;
            // 
            // ckXls
            // 
            this.ckXls.AutoSize = true;
            this.ckXls.Checked = true;
            this.ckXls.ForeColor = System.Drawing.Color.Blue;
            this.ckXls.Location = new System.Drawing.Point(10, 34);
            this.ckXls.Name = "ckXls";
            this.ckXls.Size = new System.Drawing.Size(47, 16);
            this.ckXls.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckXls.TabIndex = 5;
            this.ckXls.TabStop = true;
            this.ckXls.Text = ".xls";
            this.ckXls.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(550, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "读入";
            this.btnImport.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lbDataInfo
            // 
            this.lbDataInfo.AutoSize = true;
            this.lbDataInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbDataInfo.Location = new System.Drawing.Point(130, 36);
            this.lbDataInfo.Name = "lbDataInfo";
            this.lbDataInfo.Size = new System.Drawing.Size(59, 12);
            this.lbDataInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDataInfo.TabIndex = 3;
            this.lbDataInfo.Text = "数据信息:";
            // 
            // btnBrower
            // 
            this.btnBrower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrower.Location = new System.Drawing.Point(457, 6);
            this.btnBrower.Name = "btnBrower";
            this.btnBrower.Size = new System.Drawing.Size(75, 23);
            this.btnBrower.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnBrower.TabIndex = 2;
            this.btnBrower.Text = "浏览";
            this.btnBrower.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnBrower.UseVisualStyleBackColor = true;
            this.btnBrower.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(101, 7);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(350, 21);
            this.txtFilePath.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilePath.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(8, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(89, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "数据文件路径：";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Controls.Add(this.neuPanel3);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 59);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(677, 386);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
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
            this.neuSpread1.Size = new System.Drawing.Size(677, 358);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
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
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
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
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.btnOK);
            this.neuPanel3.Controls.Add(this.btnCancel);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel3.Location = new System.Drawing.Point(0, 358);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(677, 28);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(457, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(550, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucImportData";
            this.Size = new System.Drawing.Size(677, 445);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnBrower;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilePath;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDataInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnImport;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton ckDbf;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton ckXls;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}
