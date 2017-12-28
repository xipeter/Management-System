namespace Neusoft.WinForms.Report.FinSim
{
    partial class ucFinSimIpbFeeDetail
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
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel ( );
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox ( );
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ( );
            this.plLeft.SuspendLayout ( );
            this.plRight.SuspendLayout ( );
            this.plMain.SuspendLayout ( );
            this.plTop.SuspendLayout ( );
            this.plBottom.SuspendLayout ( );
            this.plRightTop.SuspendLayout ( );
            this.plRightBottom.SuspendLayout ( );
            this.gbMid.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // plLeft
            // 
            this.plLeft.Size = new System.Drawing.Size ( 0 , 391 );
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point ( 0 , 5 );
            this.plRight.Size = new System.Drawing.Size ( 883 , 391 );
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size ( 0 , 33 );
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size ( 883 , 464 );
            // 
            // plTop
            // 
            this.plTop.Controls.Add ( this.neuTextBox1 );
            this.plTop.Controls.Add ( this.neuLabel3 );
            this.plTop.Controls.Add ( this.ucQueryInpatientNo1 );
            this.plTop.Size = new System.Drawing.Size ( 883 , 68 );
            this.plTop.Controls.SetChildIndex ( this.ucQueryInpatientNo1 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel3 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuTextBox1 , 0 );
            this.plTop.Controls.SetChildIndex ( this.dtpBeginTime , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel1 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel2 , 0 );
            this.plTop.Controls.SetChildIndex ( this.dtpEndTime , 0 );
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point ( 0 , 68 );
            this.plBottom.Size = new System.Drawing.Size ( 883 , 396 );
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point ( 0 , 5 );
            this.slLeft.Size = new System.Drawing.Size ( 3 , 391 );
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size ( 0 , 358 );
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size ( 883 , 388 );
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point ( 0 , 388 );
            this.slTop.Size = new System.Drawing.Size ( 883 , 3 );
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point ( 0 , 391 );
            this.plRightBottom.Size = new System.Drawing.Size ( 883 , 0 );
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size ( 875 , 38 );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point ( 1287 , 9 );
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_sim_ipb_feedetail";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\fin_sim.pbl";
            this.dwMain.Location = new System.Drawing.Point ( 0 , 0 );
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size ( 883 , 388 );
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Olive;
            this.neuLabel3.Location = new System.Drawing.Point ( 26 , 44 );
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size ( 41 , 12 );
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "姓名：";
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.IsEnter2Tab = false;
            this.neuTextBox1.Location = new System.Drawing.Point ( 73 , 40 );
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size ( 100 , 21 );
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 5;
            this.neuTextBox1.TextChanged += new System.EventHandler ( this.neuTextBox1_TextChanged );
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point ( 443 , 7 );
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size ( 198 , 27 );
            this.ucQueryInpatientNo1.TabIndex = 6;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate ( this.ucQueryInpatientNo1_myEvent_1 );
            // 
            // ucFinSimIpbFeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_sim_ipb_feedetail";
            this.MainDWLabrary = "Report\\fin_sim.pbl";
            this.Name = "ucFinSimIpbFeeDetail";
            this.Size = new System.Drawing.Size ( 883 , 464 );
            this.plLeft.ResumeLayout ( false );
            this.plRight.ResumeLayout ( false );
            this.plMain.ResumeLayout ( false );
            this.plTop.ResumeLayout ( false );
            this.plTop.PerformLayout ( );
            this.plBottom.ResumeLayout ( false );
            this.plRightTop.ResumeLayout ( false );
            this.plRightBottom.ResumeLayout ( false );
            this.gbMid.ResumeLayout ( false );
            this.ResumeLayout ( false );

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
    }
}
