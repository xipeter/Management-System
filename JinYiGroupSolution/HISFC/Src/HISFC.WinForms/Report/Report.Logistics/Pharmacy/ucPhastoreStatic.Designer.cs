namespace Neusoft.Report.Logistics.Pharmacy
{
    partial class ucPhastoreStatic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhastoreStatic));
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dwNoConfirm = new Sybase.DataWindow.DataWindowControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDrugQuality = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDrug = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbCompany = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.chkDept = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkDrugQuality = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkDrug = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkCompany = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Size = new System.Drawing.Size(0, 379);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(822, 379);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(822, 464);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.chkCompany);
            this.plTop.Controls.Add(this.chkDrug);
            this.plTop.Controls.Add(this.chkDrugQuality);
            this.plTop.Controls.Add(this.chkDept);
            this.plTop.Controls.Add(this.cmbCompany);
            this.plTop.Controls.Add(this.cmbDrug);
            this.plTop.Controls.Add(this.cmbDrugQuality);
            this.plTop.Controls.Add(this.cmbDept);
            this.plTop.Size = new System.Drawing.Size(822, 80);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDept, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDrugQuality, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDrug, 0);
            this.plTop.Controls.SetChildIndex(this.cmbCompany, 0);
            this.plTop.Controls.SetChildIndex(this.chkDept, 0);
            this.plTop.Controls.SetChildIndex(this.chkDrugQuality, 0);
            this.plTop.Controls.SetChildIndex(this.chkDrug, 0);
            this.plTop.Controls.SetChildIndex(this.chkCompany, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 80);
            this.plBottom.Size = new System.Drawing.Size(822, 384);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 379);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 346);
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.neuTabControl1);
            this.plRightTop.Size = new System.Drawing.Size(822, 376);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 376);
            this.slTop.Size = new System.Drawing.Size(822, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 379);
            this.plRightBottom.Size = new System.Drawing.Size(822, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(814, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1251, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(80, 12);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(237, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(299, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(4, 17);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_storesum_static";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\\\pharmacy.pbd;Report\\\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(3, 3);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(808, 345);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(822, 376);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dwNoConfirm);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(814, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "药品库存查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dwNoConfirm
            // 
            this.dwNoConfirm.DataWindowObject = "d_pha_valid_qry";
            this.dwNoConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwNoConfirm.Icon = ((System.Drawing.Icon)(resources.GetObject("dwNoConfirm.Icon")));
            this.dwNoConfirm.LibraryList = "Report\\\\pharmacy.pbd;Report\\\\pharmacy.pbl";
            this.dwNoConfirm.Location = new System.Drawing.Point(3, 3);
            this.dwNoConfirm.Name = "dwNoConfirm";
            this.dwNoConfirm.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwNoConfirm.Size = new System.Drawing.Size(808, 345);
            this.dwNoConfirm.TabIndex = 0;
            this.dwNoConfirm.Text = "dataWindowControl1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dwMain);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "药品库存统计";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(84, 46);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 12;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // cmbDrugQuality
            // 
            this.cmbDrugQuality.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrugQuality.FormattingEnabled = true;
            this.cmbDrugQuality.IsEnter2Tab = false;
            this.cmbDrugQuality.IsFlat = true;
            this.cmbDrugQuality.IsLike = true;
            this.cmbDrugQuality.Location = new System.Drawing.Point(290, 46);
            this.cmbDrugQuality.Name = "cmbDrugQuality";
            this.cmbDrugQuality.PopForm = null;
            this.cmbDrugQuality.ShowCustomerList = false;
            this.cmbDrugQuality.ShowID = false;
            this.cmbDrugQuality.Size = new System.Drawing.Size(121, 20);
            this.cmbDrugQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrugQuality.TabIndex = 13;
            this.cmbDrugQuality.Tag = "";
            this.cmbDrugQuality.ToolBarUse = false;
            this.cmbDrugQuality.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // cmbDrug
            // 
            this.cmbDrug.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrug.FormattingEnabled = true;
            this.cmbDrug.IsEnter2Tab = false;
            this.cmbDrug.IsFlat = true;
            this.cmbDrug.IsLike = true;
            this.cmbDrug.Location = new System.Drawing.Point(497, 46);
            this.cmbDrug.Name = "cmbDrug";
            this.cmbDrug.PopForm = null;
            this.cmbDrug.ShowCustomerList = false;
            this.cmbDrug.ShowID = false;
            this.cmbDrug.Size = new System.Drawing.Size(121, 20);
            this.cmbDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrug.TabIndex = 14;
            this.cmbDrug.Tag = "";
            this.cmbDrug.ToolBarUse = false;
            this.cmbDrug.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // cmbCompany
            // 
            this.cmbCompany.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IsEnter2Tab = false;
            this.cmbCompany.IsFlat = true;
            this.cmbCompany.IsLike = true;
            this.cmbCompany.Location = new System.Drawing.Point(707, 46);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.PopForm = null;
            this.cmbCompany.ShowCustomerList = false;
            this.cmbCompany.ShowID = false;
            this.cmbCompany.Size = new System.Drawing.Size(100, 20);
            this.cmbCompany.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbCompany.TabIndex = 15;
            this.cmbCompany.Tag = "";
            this.cmbCompany.ToolBarUse = false;
            this.cmbCompany.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.Location = new System.Drawing.Point(4, 49);
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size(78, 16);
            this.chkDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkDept.TabIndex = 16;
            this.chkDept.Text = "药房名称:";
            this.chkDept.UseVisualStyleBackColor = true;
            // 
            // chkDrugQuality
            // 
            this.chkDrugQuality.AutoSize = true;
            this.chkDrugQuality.Location = new System.Drawing.Point(211, 49);
            this.chkDrugQuality.Name = "chkDrugQuality";
            this.chkDrugQuality.Size = new System.Drawing.Size(78, 16);
            this.chkDrugQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkDrugQuality.TabIndex = 17;
            this.chkDrugQuality.Text = "药品性质:";
            this.chkDrugQuality.UseVisualStyleBackColor = true;
            // 
            // chkDrug
            // 
            this.chkDrug.AutoSize = true;
            this.chkDrug.Location = new System.Drawing.Point(417, 49);
            this.chkDrug.Name = "chkDrug";
            this.chkDrug.Size = new System.Drawing.Size(78, 16);
            this.chkDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkDrug.TabIndex = 18;
            this.chkDrug.Text = "药品名称:";
            this.chkDrug.UseVisualStyleBackColor = true;
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.Location = new System.Drawing.Point(628, 49);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(78, 16);
            this.chkCompany.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkCompany.TabIndex = 19;
            this.chkCompany.Text = "供货单位:";
            this.chkCompany.UseVisualStyleBackColor = true;
            // 
            // ucPhastoreStatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.Name = "ucPhastoreStatic";
            this.Size = new System.Drawing.Size(822, 464);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sybase.DataWindow.DataWindowControl dwNoConfirm;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbCompany;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrug;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrugQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkDrug;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkDrugQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkCompany;

    }
}
