namespace Neusoft.Report.Finance.FinIpb
{
    partial class ucFinIpbPatientDayFee2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbPatientDayFee2));
            this.cbOption = new Neusoft.WinForms.Controls.NComboBox();
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
            this.plLeft.Margin = new System.Windows.Forms.Padding(2);
            this.plLeft.Size = new System.Drawing.Size(199, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(209, 5);
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            this.plRight.Size = new System.Drawing.Size(538, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(199, 29);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cbOption);
            this.plTop.Controls.SetChildIndex(this.cbOption, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(199, 5);
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            this.slLeft.Size = new System.Drawing.Size(10, 419);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 29);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(199, 390);
            // 
            // plRightTop
            // 
            this.plRightTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plRightTop.Location = new System.Drawing.Point(0, 416);
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(538, 0);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            this.slTop.Size = new System.Drawing.Size(538, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.AutoScroll = true;
            this.plRightBottom.BackColor = System.Drawing.Color.White;
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRightBottom.Location = new System.Drawing.Point(0, 0);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(538, 419);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(532, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(693, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Size = new System.Drawing.Size(485, 0);
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
            this.dwMain.Size = new System.Drawing.Size(538, 0);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cbOption
            // 
            this.cbOption.DisplayMember = "";
            this.cbOption.FormattingEnabled = true;
            this.cbOption.Items.AddRange(new object[] {
            "显示最小费用",
            "显示项目明细"});
            this.cbOption.Location = new System.Drawing.Point(457, 14);
            this.cbOption.Name = "cbOption";
            this.cbOption.NeuHeight = 209;
            this.cbOption.QueryType = Neusoft.WinForms.Controls.QueryTypeEnum.编码;
            this.cbOption.Size = new System.Drawing.Size(108, 20);
            this.cbOption.TabIndex = 4;
            this.cbOption.Text = "显示最小费用";
            this.cbOption.ValueMember = "";
            // 
            // ucFinIpbPatientDayFee2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow.QueryControls.Tree;
            this.MainDWDataObject = "d_fin_ipb_query_feedetail";
            this.MainDWLabrary = "Report\\finipb.pbd;finipb.pbl";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucFinIpbPatientDayFee2";
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

        private Neusoft.WinForms.Controls.NComboBox cbOption;


    }
}
