namespace Report.Finance.FinIpb
{
    partial class ucFinIpbDeptFeeIncome3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbDeptFeeIncome3));
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbReportType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(200, 381);
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Size = new System.Drawing.Size(544, 381);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuComboBox1);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbReportType);
            this.plTop.Controls.Add(this.cmbType);
            this.plTop.Size = new System.Drawing.Size(747, 78);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cmbType, 0);
            this.plTop.Controls.SetChildIndex(this.cmbReportType, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 78);
            this.plBottom.Size = new System.Drawing.Size(747, 386);
            // 
            // slLeft
            // 
            this.slLeft.Size = new System.Drawing.Size(3, 381);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(200, 348);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(544, 238);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 238);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 241);
            this.plRightBottom.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_deptfeeincome2";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 238);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(489, 49);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(59, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 25;
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
            this.neuComboBox1.Location = new System.Drawing.Point(554, 45);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(100, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuComboBox1.TabIndex = 24;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(228, 48);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 23;
            this.neuLabel4.Text = "统计大类:";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(9, 48);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 22;
            this.neuLabel3.Text = "统计方式:";
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
            this.cmbReportType.TabIndex = 21;
            this.cmbReportType.Tag = "";
            this.cmbReportType.ToolBarUse = false;
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
            "按患者所在科室",
            "按开立科室",
            "按执行科室"});
            this.cmbType.Location = new System.Drawing.Point(73, 45);
            this.cmbType.Name = "cmbType";
            this.cmbType.PopForm = null;
            this.cmbType.ShowCustomerList = false;
            this.cmbType.ShowID = false;
            this.cmbType.Size = new System.Drawing.Size(143, 20);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbType.TabIndex = 20;
            this.cmbType.Tag = "";
            this.cmbType.ToolBarUse = false;
            // 
            // ucFinIpbDeptFeeIncome3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_ipb_deptfeeincome2";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIpbDeptFeeIncome3";
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
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbReportType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
    }
}