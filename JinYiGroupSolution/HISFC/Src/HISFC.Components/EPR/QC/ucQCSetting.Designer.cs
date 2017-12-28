namespace Neusoft.HISFC.Components.EPR.QC
{
    partial class ucQCSetting
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
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.neuTVSetting = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView2();
            this.neuBtOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuBtCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTbSearch = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuCbSelectAll = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuBtRevSelect = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Size = new System.Drawing.Size(200, 100);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.ActiveSheetIndex = -1;
            // 
            // neuTVSetting
            // 
            this.neuTVSetting.CheckBoxes = true;
            this.neuTVSetting.HideSelection = false;
            this.neuTVSetting.Location = new System.Drawing.Point(3, 37);
            this.neuTVSetting.Name = "neuTVSetting";
            this.neuTVSetting.ShowLines = false;
            this.neuTVSetting.Size = new System.Drawing.Size(288, 328);
            this.neuTVSetting.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTVSetting.TabIndex = 0;
            // 
            // neuBtOk
            // 
            this.neuBtOk.Location = new System.Drawing.Point(96, 393);
            this.neuBtOk.Name = "neuBtOk";
            this.neuBtOk.Size = new System.Drawing.Size(75, 23);
            this.neuBtOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuBtOk.TabIndex = 1;
            this.neuBtOk.Text = "确定";
            this.neuBtOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuBtOk.UseVisualStyleBackColor = true;
            this.neuBtOk.Click += new System.EventHandler(this.neuBtOk_Click);
            // 
            // neuBtCancel
            // 
            this.neuBtCancel.Location = new System.Drawing.Point(191, 393);
            this.neuBtCancel.Name = "neuBtCancel";
            this.neuBtCancel.Size = new System.Drawing.Size(75, 23);
            this.neuBtCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuBtCancel.TabIndex = 2;
            this.neuBtCancel.Text = "取消";
            this.neuBtCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuBtCancel.UseVisualStyleBackColor = true;
            this.neuBtCancel.Click += new System.EventHandler(this.neuBtCancel_Click);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(3, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "查找(F1)：";
            // 
            // neuTbSearch
            // 
            this.neuTbSearch.IsEnter2Tab = false;
            this.neuTbSearch.Location = new System.Drawing.Point(74, 9);
            this.neuTbSearch.Name = "neuTbSearch";
            this.neuTbSearch.Size = new System.Drawing.Size(217, 21);
            this.neuTbSearch.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTbSearch.TabIndex = 4;
            // 
            // neuCbSelectAll
            // 
            this.neuCbSelectAll.AutoSize = true;
            this.neuCbSelectAll.Location = new System.Drawing.Point(5, 371);
            this.neuCbSelectAll.Name = "neuCbSelectAll";
            this.neuCbSelectAll.Size = new System.Drawing.Size(48, 16);
            this.neuCbSelectAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCbSelectAll.TabIndex = 5;
            this.neuCbSelectAll.Text = "全选";
            this.neuCbSelectAll.UseVisualStyleBackColor = true;
            this.neuCbSelectAll.CheckedChanged += new System.EventHandler(this.neuCbSelectAll_CheckedChanged);
            // 
            // neuBtRevSelect
            // 
            this.neuBtRevSelect.Location = new System.Drawing.Point(3, 393);
            this.neuBtRevSelect.Name = "neuBtRevSelect";
            this.neuBtRevSelect.Size = new System.Drawing.Size(65, 23);
            this.neuBtRevSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuBtRevSelect.TabIndex = 6;
            this.neuBtRevSelect.Text = "反选";
            this.neuBtRevSelect.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuBtRevSelect.UseVisualStyleBackColor = true;
            this.neuBtRevSelect.Click += new System.EventHandler(this.neuBtRevSelect_Click);
            // 
            // ucQCSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuBtRevSelect);
            this.Controls.Add(this.neuCbSelectAll);
            this.Controls.Add(this.neuTbSearch);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.neuBtCancel);
            this.Controls.Add(this.neuBtOk);
            this.Controls.Add(this.neuTVSetting);
            this.Name = "ucQCSetting";
            this.Size = new System.Drawing.Size(296, 429);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView2 neuTVSetting;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuBtOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuBtCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTbSearch;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCbSelectAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuBtRevSelect;
    }
}
