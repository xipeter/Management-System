namespace Neusoft.WinForms.Report.FinIpb
{
    partial class UcFinIpbinpatientfeeback
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
            this.tvDept = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.plTop.Controls.Add(this.textBox1);
            this.plTop.Controls.Add(this.label1);
            this.plTop.Controls.SetChildIndex(this.label1, 0);
            this.plTop.Controls.SetChildIndex(this.textBox1, 0);
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
            this.plRightTop.Controls.Add(this.tvDept);
            this.plRightTop.Size = new System.Drawing.Size(747, 416);
            this.plRightTop.Controls.SetChildIndex(this.tvDept, 0);
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
            this.btnClose.Location = new System.Drawing.Point(734, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_ipatientfeeback";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\fin_ipb.pbd;fin_ipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(150, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(597, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDept.Location = new System.Drawing.Point(0, 0);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(150, 416);
            this.tvDept.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "住院号：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(515, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // UcFinIpbinpatientfeeback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipb_ipatientfeeback";
            this.MainDWLabrary = "Report\\fin_ipb.pbd;fin_ipb.pbl";
            this.Name = "UcFinIpbinpatientfeeback";
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

        public System.Windows.Forms.TreeView tvDept;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;


    }
}
