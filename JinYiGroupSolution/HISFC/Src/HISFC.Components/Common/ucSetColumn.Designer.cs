namespace UFC.Pharmacy.Base
{
    partial class ucSetColumn
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
            this.neuSpread1 = new Neusoft.NFC.Interface.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnUp = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.btnDown = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.btnSave = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.btnCancel = new Neusoft.NFC.Interface.Controls.NeuButton();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
            this.neuSpread1.FileName = "";
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 3);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(295, 338);
            this.neuSpread1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ButtonClicked);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
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
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(300, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(29, 74);
            this.btnUp.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "上　移";
            this.btnUp.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(300, 83);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(29, 74);
            this.btnDown.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "下  移";
            this.btnDown.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(254, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucSetColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucSetColumn";
            this.Size = new System.Drawing.Size(335, 378);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuButton btnUp;
        private Neusoft.NFC.Interface.Controls.NeuButton btnDown;
        private Neusoft.NFC.Interface.Controls.NeuButton btnSave;
        private Neusoft.NFC.Interface.Controls.NeuButton btnCancel;
    }
}
