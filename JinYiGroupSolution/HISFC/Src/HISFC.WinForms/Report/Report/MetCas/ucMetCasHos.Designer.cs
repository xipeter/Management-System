namespace Neusoft.WinForms.Report.MetCas
{
    partial class ucMetCasHos
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
            this.dwList = new NeuDataWindow.Controls.NeuDataWindow();
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
            this.plRightTop.Controls.Add(this.dwList);
            this.plRightTop.Size = new System.Drawing.Size(747, 416);
            this.plRightTop.Controls.SetChildIndex(this.dwList, 0);
            this.plRightTop.Controls.SetChildIndex(this.dwMain, 0);
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
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(731, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd";
            this.dtpBeginTime.Size = new System.Drawing.Size(92, 21);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(182, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Location = new System.Drawing.Point(248, 13);
            this.dtpEndTime.Size = new System.Drawing.Size(89, 21);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_cas_hos";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.dwMain.LibraryList = "Report\\met_cas.pbd;met_cas.pbl";
            this.dwMain.Location = new System.Drawing.Point(707, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(40, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            this.dwMain.Visible = false;
            // 
            // dwList
            // 
            this.dwList.DataWindowObject = "d_met_cas_hos_1";
            this.dwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwList.LibraryList = "Report\\met_cas.pbd;met_cas.pbl";
            this.dwList.Location = new System.Drawing.Point(0, 0);
            this.dwList.Name = "dwList";
            this.dwList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwList.Size = new System.Drawing.Size(747, 416);
            this.dwList.TabIndex = 1;
            this.dwList.Text = "neuDataWindow1";
            // 
            // ucMetCasHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_met_cas_hos";
            this.MainDWLabrary = "Report\\met_cas.pbd;met_cas.pbl";
            this.Name = "ucMetCasHos";
            this.Load += new System.EventHandler(this.ucMetCasHos_Load);
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

        private NeuDataWindow.Controls.NeuDataWindow dwList;
    }
}
