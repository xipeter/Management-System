namespace Neusoft.WinForms.Report.FinSim
{
    partial class ucFinSimIprClinciTbhz
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
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox ( );
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel ( );
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox ( );
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel ( );
            this.neuTextBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox ( );
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel ( );
            this.neuTextBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox ( );
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
            this.plLeft.Size = new System.Drawing.Size ( 0 , 393 );
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point ( 0 , 5 );
            this.plRight.Size = new System.Drawing.Size ( 1004 , 393 );
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size ( 0 , 33 );
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size ( 1004 , 464 );
            // 
            // plTop
            // 
            this.plTop.Controls.Add ( this.neuTextBox3 );
            this.plTop.Controls.Add ( this.neuTextBox2 );
            this.plTop.Controls.Add ( this.neuLabel6 );
            this.plTop.Controls.Add ( this.neuLabel5 );
            this.plTop.Controls.Add ( this.neuTextBox1 );
            this.plTop.Controls.Add ( this.neuLabel4 );
            this.plTop.Controls.Add ( this.neuLabel3 );
            this.plTop.Controls.Add ( this.txtFilter );
            this.plTop.Size = new System.Drawing.Size ( 1004 , 66 );
            this.plTop.Controls.SetChildIndex ( this.dtpBeginTime , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel1 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel2 , 0 );
            this.plTop.Controls.SetChildIndex ( this.dtpEndTime , 0 );
            this.plTop.Controls.SetChildIndex ( this.txtFilter , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel3 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel4 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuTextBox1 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel5 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuLabel6 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuTextBox2 , 0 );
            this.plTop.Controls.SetChildIndex ( this.neuTextBox3 , 0 );
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point ( 0 , 66 );
            this.plBottom.Size = new System.Drawing.Size ( 1004 , 398 );
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point ( 0 , 5 );
            this.slLeft.Size = new System.Drawing.Size ( 3 , 393 );
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size ( 0 , 360 );
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size ( 1004 , 390 );
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point ( 0 , 390 );
            this.slTop.Size = new System.Drawing.Size ( 1004 , 3 );
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point ( 0 , 393 );
            this.plRightBottom.Size = new System.Drawing.Size ( 1004 , 0 );
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size ( 996 , 38 );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point ( 2025 , 9 );
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_sim_ipr_clincitbhz";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\fin_sim.pbl";
            this.dwMain.Location = new System.Drawing.Point ( 0 , 0 );
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size ( 1004 , 390 );
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point ( 446 , 17 );
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size ( 89 , 12 );
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "患者医保卡号：";
            // 
            // txtFilter
            // 
            this.txtFilter.IsEnter2Tab = false;
            this.txtFilter.Location = new System.Drawing.Point ( 534 , 13 );
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size ( 121 , 21 );
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 5;
            this.txtFilter.Text = "all";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Olive;
            this.neuLabel4.Location = new System.Drawing.Point ( 39 , 43 );
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size ( 29 , 12 );
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "姓名";
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.IsEnter2Tab = false;
            this.neuTextBox1.Location = new System.Drawing.Point ( 73 , 40 );
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size ( 100 , 21 );
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 7;
            this.neuTextBox1.TextChanged += new System.EventHandler ( this.neuTextBox1_TextChanged );
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Olive;
            this.neuLabel5.Location = new System.Drawing.Point ( 190 , 43 );
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size ( 53 , 12 );
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "诊断名称";
            // 
            // neuTextBox2
            // 
            this.neuTextBox2.IsEnter2Tab = false;
            this.neuTextBox2.Location = new System.Drawing.Point ( 249 , 40 );
            this.neuTextBox2.Name = "neuTextBox2";
            this.neuTextBox2.Size = new System.Drawing.Size ( 100 , 21 );
            this.neuTextBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox2.TabIndex = 9;
            this.neuTextBox2.TextChanged += new System.EventHandler ( this.neuTextBox1_TextChanged );
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.Olive;
            this.neuLabel6.Location = new System.Drawing.Point ( 368 , 43 );
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size ( 29 , 12 );
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 8;
            this.neuLabel6.Text = "医师";
            // 
            // neuTextBox3
            // 
            this.neuTextBox3.IsEnter2Tab = false;
            this.neuTextBox3.Location = new System.Drawing.Point ( 403 , 39 );
            this.neuTextBox3.Name = "neuTextBox3";
            this.neuTextBox3.Size = new System.Drawing.Size ( 100 , 21 );
            this.neuTextBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox3.TabIndex = 9;
            this.neuTextBox3.TextChanged += new System.EventHandler ( this.neuTextBox1_TextChanged );
            // 
            // ucFinSimIprClinciTbhz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_sim_ipr_clincitbhz";
            this.MainDWLabrary = "Report\\fin_sim.pbl";
            this.Name = "ucFinSimIprClinciTbhz";
            this.Size = new System.Drawing.Size ( 1004 , 464 );
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
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
    }
}
