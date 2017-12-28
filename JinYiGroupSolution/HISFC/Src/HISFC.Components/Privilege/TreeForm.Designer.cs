namespace Neusoft.HISFC.Components.Privilege
{
    partial class TreeForm<T>
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
            this.nTabControl1 = new FrameWork.WinForms.Controls.NeuTabControl();
            this.nTreeView1 = new FrameWork.WinForms.Controls.NeuTreeView();
            this.Cancel = new FrameWork.WinForms.Controls.NeuLinkLabel();
            this.OK = new FrameWork.WinForms.Controls.NeuLinkLabel();
            this.SuspendLayout();
            // 
            // nTabControl1
            // 
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(292, 266);
            this.nTabControl1.TabIndex = 0;
            // 
            // nTreeView1
            // 
            this.nTreeView1.HideSelection = false;
            this.nTreeView1.Location = new System.Drawing.Point(7, 12);
            this.nTreeView1.Name = "nTreeView1";
            this.nTreeView1.Size = new System.Drawing.Size(277, 230);
            this.nTreeView1.TabIndex = 1;
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.BackColor = System.Drawing.Color.Transparent;
            this.Cancel.Location = new System.Drawing.Point(255, 245);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(29, 12);
            this.Cancel.TabIndex = 2;
            this.Cancel.TabStop = true;
            this.Cancel.Text = "取消";
            // 
            // OK
            // 
            this.OK.AutoSize = true;
            this.OK.BackColor = System.Drawing.Color.Transparent;
            this.OK.Location = new System.Drawing.Point(211, 245);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(29, 12);
            this.OK.TabIndex = 3;
            this.OK.TabStop = true;
            this.OK.Text = "确定";
            // 
            // frmTree
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.nTreeView1);
            this.Controls.Add(this.nTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameWork.WinForms.Controls.NeuTabControl nTabControl1;
        private FrameWork.WinForms.Controls.NeuTreeView nTreeView1;
        private System.Windows.Forms.ImageList defaultImage;
        private FrameWork.WinForms.Controls.NeuLinkLabel Cancel;
        private FrameWork.WinForms.Controls.NeuLinkLabel OK;

    }
}