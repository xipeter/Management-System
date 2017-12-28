namespace Report.Logistics.Pharmacy
{
    partial class ucPhaAdjustPriceByQuality
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaAdjustPriceByQuality));
            this.ckQuality = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.ckDrug = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbQuality = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDrug = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Size = new System.Drawing.Size(0, 407);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(923, 221);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(923, 278);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.ckQuality);
            this.plTop.Controls.Add(this.ckDrug);
            this.plTop.Controls.Add(this.cmbQuality);
            this.plTop.Controls.Add(this.cmbDrug);
            this.plTop.Size = new System.Drawing.Size(923, 52);
            this.plTop.Controls.SetChildIndex(this.cmbDrug, 0);
            this.plTop.Controls.SetChildIndex(this.cmbQuality, 0);
            this.plTop.Controls.SetChildIndex(this.ckDrug, 0);
            this.plTop.Controls.SetChildIndex(this.ckQuality, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 52);
            this.plBottom.Size = new System.Drawing.Size(923, 226);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 407);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 374);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(923, 218);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 218);
            this.slTop.Size = new System.Drawing.Size(923, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 221);
            this.plRightBottom.Size = new System.Drawing.Size(923, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(915, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(702, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_adjustprice_bydrugquality";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(923, 218);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // ckQuality
            // 
            this.ckQuality.AutoSize = true;
            this.ckQuality.Location = new System.Drawing.Point(455, 17);
            this.ckQuality.Name = "ckQuality";
            this.ckQuality.Size = new System.Drawing.Size(72, 16);
            this.ckQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckQuality.TabIndex = 4;
            this.ckQuality.Text = "详细类别";
            this.ckQuality.UseVisualStyleBackColor = true;
            this.ckQuality.CheckedChanged += new System.EventHandler(this.ckQuality_CheckedChanged);
            // 
            // ckDrug
            // 
            this.ckDrug.AutoSize = true;
            this.ckDrug.Location = new System.Drawing.Point(669, 17);
            this.ckDrug.Name = "ckDrug";
            this.ckDrug.Size = new System.Drawing.Size(48, 16);
            this.ckDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckDrug.TabIndex = 5;
            this.ckDrug.Text = "药品";
            this.ckDrug.UseVisualStyleBackColor = true;
            this.ckDrug.CheckedChanged += new System.EventHandler(this.ckDrug_CheckedChanged);
            // 
            // cmbQuality
            // 
            this.cmbQuality.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.IsEnter2Tab = false;
            this.cmbQuality.IsFlat = false;
            this.cmbQuality.IsLike = true;
            this.cmbQuality.IsListOnly = false;
            this.cmbQuality.IsShowCustomerList = false;
            this.cmbQuality.IsShowID = false;
            this.cmbQuality.Location = new System.Drawing.Point(533, 14);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.PopForm = null;
            this.cmbQuality.ShowCustomerList = false;
            this.cmbQuality.ShowID = false;
            this.cmbQuality.Size = new System.Drawing.Size(121, 20);
            this.cmbQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbQuality.TabIndex = 8;
            this.cmbQuality.Tag = "";
            this.cmbQuality.ToolBarUse = false;
            // 
            // cmbDrug
            // 
            this.cmbDrug.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDrug.FormattingEnabled = true;
            this.cmbDrug.IsEnter2Tab = false;
            this.cmbDrug.IsFlat = false;
            this.cmbDrug.IsLike = true;
            this.cmbDrug.IsListOnly = false;
            this.cmbDrug.IsShowCustomerList = false;
            this.cmbDrug.IsShowID = false;
            this.cmbDrug.Location = new System.Drawing.Point(723, 13);
            this.cmbDrug.Name = "cmbDrug";
            this.cmbDrug.PopForm = null;
            this.cmbDrug.ShowCustomerList = false;
            this.cmbDrug.ShowID = false;
            this.cmbDrug.Size = new System.Drawing.Size(121, 20);
            this.cmbDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDrug.TabIndex = 9;
            this.cmbDrug.Tag = "";
            this.cmbDrug.ToolBarUse = false;
            // 
            // ucPhaAdjustPriceByQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_adjustprice_bydrugquality";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaAdjustPriceByQuality";
            this.Size = new System.Drawing.Size(923, 278);
            this.Load += new System.EventHandler(this.ucPhaAdjustPriceByQuality_Load);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckDrug;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrug;
    }
}
