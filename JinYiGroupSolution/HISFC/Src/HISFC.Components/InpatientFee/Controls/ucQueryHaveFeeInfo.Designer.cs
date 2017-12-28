namespace Neusoft.HISFC.Components.InpatientFee.Controls
{
    partial class ucQueryHaveFeeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQueryHaveFeeInfo));
            this.neuButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
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
            this.plRight.Size = new System.Drawing.Size(800, 555);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(800, 600);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuButton1);
            this.plTop.Size = new System.Drawing.Size(800, 40);
            this.plTop.Controls.SetChildIndex(this.neuButton1, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(800, 560);
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
            this.plRightTop.Size = new System.Drawing.Size(800, 552);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 552);
            this.slTop.Size = new System.Drawing.Size(800, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 555);
            this.plRightBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(792, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(622, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd";
            this.dtpBeginTime.Enabled = false;
            this.dtpBeginTime.Location = new System.Drawing.Point(81, 13);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(293, 13);
            this.dtpEndTime.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Text = "当前日期：";
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_nursefeedetail_color";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\zzlocal_fin_ipb.pbd;Report\\zzlocal_fin_ipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(800, 552);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuButton1
            // 
            this.neuButton1.Location = new System.Drawing.Point(606, 12);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(94, 23);
            this.neuButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton1.TabIndex = 4;
            this.neuButton1.Text = "关闭窗口(&X)";
            this.neuButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // ucQueryHaveFeeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow.QueryControls.DataWindow;
            this.MainDWDataObject = "d_fin_ipb_nursefeedetail_color";
            this.MainDWLabrary = "Report\\zzlocal_fin_ipb.pbd;Report\\zzlocal_fin_ipb.pbl";
            this.Name = "ucQueryHaveFeeInfo";
            this.Size = new System.Drawing.Size(800, 600);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton1;
    }
}
