namespace Neusoft.Report.Finance.FinIpr
{
    partial class ucFinIprFreecost
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
            this.dwDetail = new NeuDataWindow.Controls.NeuDataWindow();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
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
            this.plLeft.Size = new System.Drawing.Size(0, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(747, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 386);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(747, 116);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 116);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Controls.Add(this.dwDetail);
            this.plRightBottom.Location = new System.Drawing.Point(0, 119);
            this.plRightBottom.Size = new System.Drawing.Size(747, 300);
            this.plRightBottom.Controls.SetChildIndex(this.dwDetail, 0);
            this.plRightBottom.Controls.SetChildIndex(this.gbMid, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(719, 9);
            // 
            // lbText
            // 
            this.lbText.Size = new System.Drawing.Size(485, 0);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_freecost_total";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 116);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            this.dwMain.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwMain_RowFocusChanged);
            // 
            // dwDetail
            // 
            this.dwDetail.DataWindowObject = "d_fin_ipr_freecost_detail";
            this.dwDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwDetail.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwDetail.Location = new System.Drawing.Point(4, 0);
            this.dwDetail.Name = "dwDetail";
            this.dwDetail.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwDetail.Size = new System.Drawing.Size(739, 300);
            this.dwDetail.TabIndex = 1;
            this.dwDetail.Text = "住院患者欠费统计明细表";
            // 
            // ucFinIprFreecost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.IsLeftVisible = false;
            this.IsShowDetail = true;
            this.MainDWDataObject = "d_fin_ipr_freecost_total";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIprFreecost";
            this.ReportTitle = "在院患者欠费统计";
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
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

        private NeuDataWindow.Controls.NeuDataWindow dwDetail;
    }
}
