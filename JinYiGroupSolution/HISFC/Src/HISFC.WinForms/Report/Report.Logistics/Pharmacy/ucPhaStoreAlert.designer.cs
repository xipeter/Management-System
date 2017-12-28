namespace Neusoft.Report.Logistics.Pharmacy
{
    partial class ucPhaStoreAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaStoreAlert));
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
            this.plLeft.Size = new System.Drawing.Size(142, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(145, 5);
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            this.plRight.Size = new System.Drawing.Size(602, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(142, 40);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(142, 5);
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 40);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(142, 379);
            // 
            // plRightTop
            // 
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(602, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            this.slTop.Size = new System.Drawing.Size(602, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(602, 0);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(596, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(757, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Size = new System.Drawing.Size(485, 20);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_query_store_alert";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(602, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // ucPhaStoreAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow.QueryControls.Tree;
            this.MainDWDataObject = "d_pha_query_store_alert";
            this.MainDWLabrary = "Report\\pharmacy.pbd;pharmacy.pbl";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucPhaStoreAlert";
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
    }
}
