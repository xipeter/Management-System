namespace Report.Finance.FinIpb
{
    partial class ucFinIpbInpatientQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbInpatientQuery));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTotDate = new System.Windows.Forms.TextBox();
            this.tbTotCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // plTop
            // 
            this.plTop.Controls.Add(this.label2);
            this.plTop.Controls.Add(this.label1);
            this.plTop.Controls.Add(this.tbTotDate);
            this.plTop.Controls.Add(this.tbTotCost);
            this.plTop.Controls.SetChildIndex(this.tbTotCost, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.tbTotDate, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.label1, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.label2, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 386);
            this.plLeftControl.Visible = false;
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(747, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            this.plRightBottom.Visible = false;
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(728, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(445, 8);
            this.dtpBeginTime.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(643, 17);
            this.neuLabel2.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(604, 9);
            this.dtpEndTime.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(682, 13);
            this.neuLabel1.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_inpatient_query";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbl;Report\\finipb.pbd";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "入院天数大于等于";
            // 
            // tbTotDate
            // 
            this.tbTotDate.Location = new System.Drawing.Point(110, 13);
            this.tbTotDate.Name = "tbTotDate";
            this.tbTotDate.Size = new System.Drawing.Size(100, 21);
            this.tbTotDate.TabIndex = 5;
            // 
            // tbTotCost
            // 
            this.tbTotCost.Location = new System.Drawing.Point(323, 13);
            this.tbTotCost.Name = "tbTotCost";
            this.tbTotCost.Size = new System.Drawing.Size(100, 21);
            this.tbTotCost.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "总费用大于等于";
            // 
            // ucFinIpbInpatientQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipb_inpatient_query";
            this.MainDWLabrary = "Report\\\\finipb.pbl;Report\\\\finipb.pbd";
            this.Name = "ucFinIpbInpatientQuery";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTotDate;
        private System.Windows.Forms.TextBox tbTotCost;
    }
}
