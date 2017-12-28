namespace Neusoft.HISFC.Components.Registration
{
    partial class ucSetDerateReg
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plControls = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(742, 63);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // plControls
            // 
            this.plControls.AutoScroll = true;
            this.plControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plControls.Location = new System.Drawing.Point(0, 63);
            this.plControls.Name = "plControls";
            this.plControls.Size = new System.Drawing.Size(742, 477);
            this.plControls.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plControls.TabIndex = 1;
            // 
            // ucSetDerateReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plControls);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucSetDerateReg";
            this.Size = new System.Drawing.Size(742, 540);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plControls;
    }
}
