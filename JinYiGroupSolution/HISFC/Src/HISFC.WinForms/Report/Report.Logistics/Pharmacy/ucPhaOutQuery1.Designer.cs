namespace Report.Logistics.Pharmacy
{
    partial class ucPhaOutQuery1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaOutQuery1));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbPharmacy = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 412);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(647, 288);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(647, 340);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbPharmacy);
            this.plTop.Size = new System.Drawing.Size(647, 47);
            this.plTop.Controls.SetChildIndex(this.cmbPharmacy, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 47);
            this.plBottom.Size = new System.Drawing.Size(647, 293);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 412);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 379);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(647, 285);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 285);
            this.slTop.Size = new System.Drawing.Size(647, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 288);
            this.plRightBottom.Size = new System.Drawing.Size(647, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(639, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(9, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(235, 13);
            this.dtpBeginTime.Size = new System.Drawing.Size(137, 21);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(382, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(444, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(173, 17);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_out_query1";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(647, 285);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(6, 16);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "统计药库：";
            // 
            // cmbPharmacy
            // 
            this.cmbPharmacy.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPharmacy.FormattingEnabled = true;
            this.cmbPharmacy.IsEnter2Tab = false;
            this.cmbPharmacy.IsFlat = true;
            this.cmbPharmacy.IsLike = true;
            this.cmbPharmacy.Location = new System.Drawing.Point(72, 12);
            this.cmbPharmacy.Name = "cmbPharmacy";
            this.cmbPharmacy.PopForm = null;
            this.cmbPharmacy.ShowCustomerList = false;
            this.cmbPharmacy.ShowID = false;
            this.cmbPharmacy.Size = new System.Drawing.Size(88, 20);
            this.cmbPharmacy.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPharmacy.TabIndex = 5;
            this.cmbPharmacy.Tag = "";
            this.cmbPharmacy.ToolBarUse = false;
            this.cmbPharmacy.SelectedIndexChanged += new System.EventHandler(this.cmbPharmacy_SelectedIndexChanged);
            // 
            // ucPhaOutQuery1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_out_query1";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaOutQuery1";
            this.Size = new System.Drawing.Size(647, 340);
            this.Load += new System.EventHandler(this.ucPhaOutQuery1_Load);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPharmacy;
    }
}
