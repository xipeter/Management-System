namespace Neusoft.HISFC.WinForms.WorkStation.Controls
{
    partial class frmPatientListSet
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
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 3;
            this.fpSpread1_Sheet1.RowCount = 6;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).Value = "电子病历";
            this.fpSpread1_Sheet1.Cells.Get(0, 1).Value = "EPRImplement";
            this.fpSpread1_Sheet1.Cells.Get(0, 2).Value = "EPRImplement.EMR";
            this.fpSpread1_Sheet1.Cells.Get(1, 0).Value = "医嘱";
            this.fpSpread1_Sheet1.Cells.Get(1, 1).Value = "EPRImplement";
            this.fpSpread1_Sheet1.Cells.Get(1, 2).Value = "EPRImplement.Order";
            this.fpSpread1_Sheet1.Cells.Get(2, 0).Value = "检验";
            this.fpSpread1_Sheet1.Cells.Get(2, 1).Value = "EPRImplement";
            this.fpSpread1_Sheet1.Cells.Get(2, 2).Value = "EPRImplement.Lis";
            this.fpSpread1_Sheet1.Cells.Get(3, 0).Value = "检查";
            this.fpSpread1_Sheet1.Cells.Get(3, 1).Value = "EPRImplement";
            this.fpSpread1_Sheet1.Cells.Get(3, 2).Value = "EPRImplement.Pacs";
            this.fpSpread1_Sheet1.Cells.Get(4, 0).Value = "会诊";
            this.fpSpread1_Sheet1.Cells.Get(4, 1).Value = "EPRImplement";
            this.fpSpread1_Sheet1.Cells.Get(4, 2).Value = "EPRImplement.Consulation";
            this.fpSpread1_Sheet1.Cells.Get(5, 0).Value = "查找患者";
            this.fpSpread1_Sheet1.Cells.Get(5, 1).Value = "UFC.EPR";
            this.fpSpread1_Sheet1.Cells.Get(5, 2).Value = "UFC.EPR.Query.ucQueryPatient";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "功能";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Dll名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "类名称";
            this.fpSpread1_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "功能";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 108F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "Dll名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 110F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "类名称";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 200F;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, 电子病历";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(3, 3);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(459, 146);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPatientListSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 157);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fpSpread1);
            this.Name = "frmPatientListSet";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public FarPoint.Win.Spread.FpSpread fpSpread1;

    }
}
