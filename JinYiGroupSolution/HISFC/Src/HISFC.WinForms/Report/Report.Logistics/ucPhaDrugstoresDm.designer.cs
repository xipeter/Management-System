namespace Report.Logistics.Pharmacy
{
    partial class ucPhaDrugstoresDm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaDrugstoresDm));
            this.gbDrugstoresDm = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.plDrugstoresDm5 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.dwcDrugWindow = new Sybase.DataWindow.DataWindowControl();
            this.cmbDrugQua = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDrugName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.lbDrugstoresDm4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDrugstoresDm3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDrugstoresDm2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDrugstoresDm1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.gbDrugstoresDm.SuspendLayout();
            this.plDrugstoresDm5.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeft.Location = new System.Drawing.Point(162, 18);
            this.plLeft.Size = new System.Drawing.Size(143, 40);
            // 
            // plRight
            // 
            this.plRight.Dock = System.Windows.Forms.DockStyle.None;
            this.plRight.Location = new System.Drawing.Point(9, 8);
            this.plRight.Size = new System.Drawing.Size(147, 91);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(143, 33);
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.gbDrugstoresDm);
            this.plMain.Controls.SetChildIndex(this.plTop, 0);
            this.plMain.Controls.SetChildIndex(this.plBottom, 0);
            this.plMain.Controls.SetChildIndex(this.gbDrugstoresDm, 0);
            // 
            // plTop
            // 
            this.plTop.Dock = System.Windows.Forms.DockStyle.None;
            this.plTop.Location = new System.Drawing.Point(47, 191);
            this.plTop.Size = new System.Drawing.Size(447, 40);
            // 
            // plBottom
            // 
            this.plBottom.Dock = System.Windows.Forms.DockStyle.None;
            this.plBottom.Location = new System.Drawing.Point(104, 82);
            this.plBottom.Size = new System.Drawing.Size(310, 103);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 98);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeftControl.Location = new System.Drawing.Point(137, 383);
            this.plLeftControl.Size = new System.Drawing.Size(63, 36);
            // 
            // plRightTop
            // 
            this.plRightTop.Dock = System.Windows.Forms.DockStyle.None;
            this.plRightTop.Location = new System.Drawing.Point(6, 3);
            this.plRightTop.Size = new System.Drawing.Size(71, 44);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 50);
            this.slTop.Size = new System.Drawing.Size(147, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 53);
            this.plRightBottom.Size = new System.Drawing.Size(147, 38);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(139, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(116, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(71, 44);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // gbDrugstoresDm
            // 
            this.gbDrugstoresDm.Controls.Add(this.plDrugstoresDm5);
            this.gbDrugstoresDm.Controls.Add(this.cmbDrugQua);
            this.gbDrugstoresDm.Controls.Add(this.cmbDrugName);
            this.gbDrugstoresDm.Controls.Add(this.dtpEndDate);
            this.gbDrugstoresDm.Controls.Add(this.dtpBeginDate);
            this.gbDrugstoresDm.Controls.Add(this.lbDrugstoresDm4);
            this.gbDrugstoresDm.Controls.Add(this.lbDrugstoresDm3);
            this.gbDrugstoresDm.Controls.Add(this.lbDrugstoresDm2);
            this.gbDrugstoresDm.Controls.Add(this.lbDrugstoresDm1);
            this.gbDrugstoresDm.Location = new System.Drawing.Point(0, 0);
            this.gbDrugstoresDm.Name = "gbDrugstoresDm";
            this.gbDrugstoresDm.Size = new System.Drawing.Size(747, 464);
            this.gbDrugstoresDm.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbDrugstoresDm.TabIndex = 5;
            this.gbDrugstoresDm.TabStop = false;
            // 
            // plDrugstoresDm5
            // 
            this.plDrugstoresDm5.Controls.Add(this.dwcDrugWindow);
            this.plDrugstoresDm5.Location = new System.Drawing.Point(0, 65);
            this.plDrugstoresDm5.Name = "plDrugstoresDm5";
            this.plDrugstoresDm5.Size = new System.Drawing.Size(744, 396);
            this.plDrugstoresDm5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plDrugstoresDm5.TabIndex = 8;
            // 
            // dwcDrugWindow
            // 
            this.dwcDrugWindow.DataWindowObject = "d_pha_drug_dmy";
            this.dwcDrugWindow.Icon = ((System.Drawing.Icon)(resources.GetObject("dwcDrugWindow.Icon")));
            this.dwcDrugWindow.LibraryList = "Report\\\\pharmacy.pbd;Report\\\\pharmacy.pbl";
            this.dwcDrugWindow.Location = new System.Drawing.Point(3, 3);
            this.dwcDrugWindow.Name = "dwcDrugWindow";
            this.dwcDrugWindow.Size = new System.Drawing.Size(738, 390);
            this.dwcDrugWindow.TabIndex = 0;
            this.dwcDrugWindow.Text = "dataWindowControl1";
            // 
            // cmbDrugQua
            // 
            this.cmbDrugQua.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrugQua.FormattingEnabled = true;
            this.cmbDrugQua.IsEnter2Tab = false;
            this.cmbDrugQua.IsFlat = true;
            this.cmbDrugQua.IsLike = true;
            this.cmbDrugQua.Location = new System.Drawing.Point(350, 37);
            this.cmbDrugQua.Name = "cmbDrugQua";
            this.cmbDrugQua.PopForm = null;
            this.cmbDrugQua.ShowCustomerList = false;
            this.cmbDrugQua.ShowID = false;
            this.cmbDrugQua.Size = new System.Drawing.Size(200, 20);
            this.cmbDrugQua.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrugQua.TabIndex = 7;
            this.cmbDrugQua.Tag = "";
            this.cmbDrugQua.ToolBarUse = false;
            // 
            // cmbDrugName
            // 
            this.cmbDrugName.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrugName.FormattingEnabled = true;
            this.cmbDrugName.IsEnter2Tab = false;
            this.cmbDrugName.IsFlat = true;
            this.cmbDrugName.IsLike = true;
            this.cmbDrugName.Location = new System.Drawing.Point(79, 37);
            this.cmbDrugName.Name = "cmbDrugName";
            this.cmbDrugName.PopForm = null;
            this.cmbDrugName.ShowCustomerList = false;
            this.cmbDrugName.ShowID = false;
            this.cmbDrugName.Size = new System.Drawing.Size(200, 20);
            this.cmbDrugName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrugName.TabIndex = 6;
            this.cmbDrugName.Tag = "";
            this.cmbDrugName.ToolBarUse = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.IsEnter2Tab = false;
            this.dtpEndDate.Location = new System.Drawing.Point(350, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 21);
            this.dtpEndDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndDate.TabIndex = 5;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.IsEnter2Tab = false;
            this.dtpBeginDate.Location = new System.Drawing.Point(79, 12);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(200, 21);
            this.dtpBeginDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginDate.TabIndex = 4;
            // 
            // lbDrugstoresDm4
            // 
            this.lbDrugstoresDm4.AutoSize = true;
            this.lbDrugstoresDm4.Location = new System.Drawing.Point(285, 42);
            this.lbDrugstoresDm4.Name = "lbDrugstoresDm4";
            this.lbDrugstoresDm4.Size = new System.Drawing.Size(53, 12);
            this.lbDrugstoresDm4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugstoresDm4.TabIndex = 3;
            this.lbDrugstoresDm4.Text = "药品性质";
            // 
            // lbDrugstoresDm3
            // 
            this.lbDrugstoresDm3.AutoSize = true;
            this.lbDrugstoresDm3.Location = new System.Drawing.Point(14, 42);
            this.lbDrugstoresDm3.Name = "lbDrugstoresDm3";
            this.lbDrugstoresDm3.Size = new System.Drawing.Size(53, 12);
            this.lbDrugstoresDm3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugstoresDm3.TabIndex = 2;
            this.lbDrugstoresDm3.Text = "药房名称";
            // 
            // lbDrugstoresDm2
            // 
            this.lbDrugstoresDm2.AutoSize = true;
            this.lbDrugstoresDm2.Location = new System.Drawing.Point(285, 16);
            this.lbDrugstoresDm2.Name = "lbDrugstoresDm2";
            this.lbDrugstoresDm2.Size = new System.Drawing.Size(53, 12);
            this.lbDrugstoresDm2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugstoresDm2.TabIndex = 1;
            this.lbDrugstoresDm2.Text = "结束时间";
            // 
            // lbDrugstoresDm1
            // 
            this.lbDrugstoresDm1.AutoSize = true;
            this.lbDrugstoresDm1.Location = new System.Drawing.Point(14, 16);
            this.lbDrugstoresDm1.Name = "lbDrugstoresDm1";
            this.lbDrugstoresDm1.Size = new System.Drawing.Size(53, 12);
            this.lbDrugstoresDm1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugstoresDm1.TabIndex = 0;
            this.lbDrugstoresDm1.Text = "开始时间";
            // 
            // ucPhaDrugstoresDm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_pha_drug_dmy";
            this.MainDWLabrary = "Report\\pharmacy.pbd;pharmacy.pbl";
            this.Name = "ucPhaDrugstoresDm";
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.gbDrugstoresDm.ResumeLayout(false);
            this.gbDrugstoresDm.PerformLayout();
            this.plDrugstoresDm5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbDrugstoresDm;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrugQua;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrugName;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugstoresDm4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugstoresDm3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugstoresDm2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugstoresDm1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plDrugstoresDm5;
        private Sybase.DataWindow.DataWindowControl dwcDrugWindow;
    }
}
