namespace Neusoft.Report.MET.MetOpd
{
    partial class ucMetOpdNumOps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMetOpdNumOps));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbOpdName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
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
            this.plTop.Controls.Add(this.tbOpdName);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.tbOpdName, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
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
            this.plRightTop.Controls.Add(this.neuDateTimePicker1);
            this.plRightTop.Size = new System.Drawing.Size(747, 416);
            this.plRightTop.Controls.SetChildIndex(this.neuDateTimePicker1, 0);
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
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_opd_num_ops";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\metopd.pbd;Report\\metopd.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(461, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(89, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "手术名称过滤：";
            // 
            // tbOpdName
            // 
            this.tbOpdName.IsEnter2Tab = false;
            this.tbOpdName.Location = new System.Drawing.Point(561, 13);
            this.tbOpdName.Name = "tbOpdName";
            this.tbOpdName.Size = new System.Drawing.Size(165, 21);
            this.tbOpdName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbOpdName.TabIndex = 5;
            this.tbOpdName.TextChanged += new System.EventHandler(this.tbOpdName_TextChanged);
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.IsEnter2Tab = false;
            this.neuDateTimePicker1.Location = new System.Drawing.Point(334, 111);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 1;
            // 
            // ucMetOpdNumOps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_met_opd_num_ops";
            this.MainDWLabrary = "Report\\metopd.pbd;Report\\metopd.pbl";
            this.Name = "ucMetOpdNumOps";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbOpdName;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
    }
}
