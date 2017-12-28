namespace Neusoft.Report.Finance.FinOpb
{
    partial class ucClinicDayBalance
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
            this.tabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucClinicDayBalanceReport = new Neusoft.Report.Finance.FinOpb.ucClinicDayBalanceReport();
            this.ucClinicDayBalanceDateControl1 = new Neusoft.Report.Finance.FinOpb.ucClinicDayBalanceDateControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucReportReprint = new Neusoft.Report.Finance.FinOpb.ucClinicDayBalanceReport();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucReprintDateTime = new Neusoft.Report.Finance.FinOpb.ucReprintDateControl();
            this.panelReprint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.panelReprint.SuspendLayout();
            this.panelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 484);
            this.tabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelPrint);
            this.tabPage1.Controls.Add(this.ucClinicDayBalanceDateControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "门诊收款员交费日结";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucClinicDayBalanceReport
            // 
            this.ucClinicDayBalanceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClinicDayBalanceReport.Location = new System.Drawing.Point(0, 0);
            this.ucClinicDayBalanceReport.Name = "ucClinicDayBalanceReport";
            this.ucClinicDayBalanceReport.Size = new System.Drawing.Size(634, 423);
            this.ucClinicDayBalanceReport.TabIndex = 1;
            // 
            // ucClinicDayBalanceDateControl1
            // 
            this.ucClinicDayBalanceDateControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucClinicDayBalanceDateControl1.Location = new System.Drawing.Point(3, 3);
            this.ucClinicDayBalanceDateControl1.Name = "ucClinicDayBalanceDateControl1";
            this.ucClinicDayBalanceDateControl1.Size = new System.Drawing.Size(634, 30);
            this.ucClinicDayBalanceDateControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelReprint);
            this.tabPage2.Controls.Add(this.neuGroupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(640, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "日结查询重打";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucReportReprint
            // 
            this.ucReportReprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportReprint.Location = new System.Drawing.Point(0, 0);
            this.ucReportReprint.Name = "ucReportReprint";
            this.ucReportReprint.Size = new System.Drawing.Size(634, 398);
            this.ucReportReprint.TabIndex = 1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.ucReprintDateTime);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(634, 55);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // ucReprintDateTime
            // 
            this.ucReprintDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReprintDateTime.Location = new System.Drawing.Point(3, 17);
            this.ucReprintDateTime.Name = "ucReprintDateTime";
            this.ucReprintDateTime.Size = new System.Drawing.Size(628, 35);
            this.ucReprintDateTime.TabIndex = 0;
            // 
            // panelReprint
            // 
            this.panelReprint.Controls.Add(this.ucReportReprint);
            this.panelReprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReprint.Location = new System.Drawing.Point(3, 58);
            this.panelReprint.Name = "panelReprint";
            this.panelReprint.Size = new System.Drawing.Size(634, 398);
            this.panelReprint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelReprint.TabIndex = 2;
            // 
            // panelPrint
            // 
            this.panelPrint.Controls.Add(this.ucClinicDayBalanceReport);
            this.panelPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrint.Location = new System.Drawing.Point(3, 33);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(634, 423);
            this.panelPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelPrint.TabIndex = 2;
            // 
            // ucClinicDayBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucClinicDayBalance";
            this.Size = new System.Drawing.Size(648, 484);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.panelReprint.ResumeLayout(false);
            this.panelPrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucClinicDayBalanceReport ucClinicDayBalanceReport;
        private ucClinicDayBalanceDateControl ucClinicDayBalanceDateControl1;
        private ucClinicDayBalanceReport ucReportReprint;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private ucReprintDateControl ucReprintDateTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelReprint;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelPrint;
    }
}
