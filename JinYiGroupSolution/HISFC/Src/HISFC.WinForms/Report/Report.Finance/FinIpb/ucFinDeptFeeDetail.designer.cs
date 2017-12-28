namespace Report.Finance.FinIpb
{
    partial class ucFinDeptFeeDetail
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinDeptFeeDetail));
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbReportType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ncboDepartment = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(3, 5);
            this.plRight.Size = new System.Drawing.Size(744, 381);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.ncboDepartment);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuComboBox1);
            this.plTop.Controls.Add(this.cmbReportType);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.cmbType);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Size = new System.Drawing.Size(747, 78);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.cmbType, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.cmbReportType, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.ncboDepartment, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 78);
            this.plBottom.Size = new System.Drawing.Size(747, 386);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 381);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(744, 378);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 378);
            this.slTop.Size = new System.Drawing.Size(744, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.None;
            this.plRightBottom.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbl;Report\\finipb.pbd";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(744, 378);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(480, 48);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(59, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 17;
            this.neuLabel6.Text = "结算类别:";
            // 
            // neuComboBox1
            // 
            this.neuComboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox1.FormattingEnabled = true;
            this.neuComboBox1.IsEnter2Tab = false;
            this.neuComboBox1.IsFlat = true;
            this.neuComboBox1.IsLike = true;
            this.neuComboBox1.IsListOnly = false;
            this.neuComboBox1.Items.AddRange(new object[] {
            "全部",
            "已结",
            "未结"});
            this.neuComboBox1.Location = new System.Drawing.Point(545, 44);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(100, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuComboBox1.TabIndex = 15;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            // 
            // cmbReportType
            // 
            this.cmbReportType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.IsEnter2Tab = false;
            this.cmbReportType.IsFlat = true;
            this.cmbReportType.IsLike = true;
            this.cmbReportType.IsListOnly = false;
            this.cmbReportType.Location = new System.Drawing.Point(294, 45);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.PopForm = null;
            this.cmbReportType.ShowCustomerList = false;
            this.cmbReportType.ShowID = false;
            this.cmbReportType.Size = new System.Drawing.Size(143, 20);
            this.cmbReportType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbReportType.TabIndex = 16;
            this.cmbReportType.Tag = "";
            this.cmbReportType.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(228, 48);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 14;
            this.neuLabel4.Text = "统计大类:";
            // 
            // cmbType
            // 
            this.cmbType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsEnter2Tab = false;
            this.cmbType.IsFlat = true;
            this.cmbType.IsLike = true;
            this.cmbType.IsListOnly = false;
            this.cmbType.Items.AddRange(new object[] {
            "按开单科室",
            "按执行科室"});
            this.cmbType.Location = new System.Drawing.Point(73, 44);
            this.cmbType.Name = "cmbType";
            this.cmbType.PopForm = null;
            this.cmbType.ShowCustomerList = false;
            this.cmbType.ShowID = false;
            this.cmbType.Size = new System.Drawing.Size(143, 20);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbType.TabIndex = 13;
            this.cmbType.Tag = "";
            this.cmbType.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(10, 48);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 12;
            this.neuLabel3.Text = "统计方式:";
            // 
            // ncboDepartment
            // 
            this.ncboDepartment.ArrowBackColor = System.Drawing.Color.Silver;
            this.ncboDepartment.FormattingEnabled = true;
            this.ncboDepartment.IsEnter2Tab = false;
            this.ncboDepartment.IsFlat = true;
            this.ncboDepartment.IsLike = true;
            this.ncboDepartment.IsListOnly = false;
            this.ncboDepartment.Location = new System.Drawing.Point(545, 14);
            this.ncboDepartment.Name = "ncboDepartment";
            this.ncboDepartment.PopForm = null;
            this.ncboDepartment.ShowCustomerList = false;
            this.ncboDepartment.ShowID = false;
            this.ncboDepartment.Size = new System.Drawing.Size(100, 20);
            this.ncboDepartment.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ncboDepartment.TabIndex = 19;
            this.ncboDepartment.Tag = "";
            this.ncboDepartment.ToolBarUse = false;
            this.ncboDepartment.SelectedIndexChanged += new System.EventHandler(this.ncboDepartment_SelectedIndexChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(480, 17);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(35, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 18;
            this.neuLabel5.Text = "部门:";
            // 
            // ucFinDeptFeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucFinDeptFeeDetail";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbReportType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox ncboDepartment;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}