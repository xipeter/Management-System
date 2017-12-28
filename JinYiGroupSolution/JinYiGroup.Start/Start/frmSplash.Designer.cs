namespace HIS
{
    partial class frmSplash
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
            this.neuProgressBar1 = new Neusoft.FrameWork.WinForms.Controls.NeuProgressBar();
            this.lblMsg = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // neuProgressBar1
            // 
            this.neuProgressBar1.BackColor = System.Drawing.Color.White;
            this.neuProgressBar1.BackgroundBitmap = null;
            this.neuProgressBar1.BackgroundColor = System.Drawing.Color.White;
            this.neuProgressBar1.Border3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.neuProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.neuProgressBar1.EnableBorder3D = false;
            this.neuProgressBar1.ForegroundBitmap = null;
            this.neuProgressBar1.ForegroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.neuProgressBar1.GradientEndColor = System.Drawing.Color.Empty;
            this.neuProgressBar1.GradientMiddleColor = System.Drawing.Color.Empty;
            this.neuProgressBar1.GradientStartColor = System.Drawing.Color.Empty;
            this.neuProgressBar1.Location = new System.Drawing.Point(57, 214);
            this.neuProgressBar1.Maximum = 100;
            this.neuProgressBar1.Minimum = 0;
            this.neuProgressBar1.Name = "neuProgressBar1";
            this.neuProgressBar1.ProgressTextColor = System.Drawing.Color.Empty;
            this.neuProgressBar1.ProgressTextHiglightColor = System.Drawing.Color.Empty;
            this.neuProgressBar1.ShowProgressText = false;
            this.neuProgressBar1.Size = new System.Drawing.Size(360, 16);
            this.neuProgressBar1.Smooth = true;
            this.neuProgressBar1.Step = 1;
            this.neuProgressBar1.TabIndex = 0;
            this.neuProgressBar1.Value = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblMsg.Location = new System.Drawing.Point(54, 239);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(145, 15);
            this.lblMsg.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "系统正在启动中…请稍候";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lbVersion.Location = new System.Drawing.Point(388, 175);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(75, 15);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "Version1.0";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HIS.Properties.Resources.东软蓝_登启界面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(511, 337);
            this.ControlBox = false;
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.neuProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuProgressBar neuProgressBar1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblMsg;
        private System.Windows.Forms.Label lbVersion;

    }
}