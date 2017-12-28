namespace Neusoft.HISFC.Components.OutpatientFee.Forms
{
    partial class frmSetting
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
            this.ucSetting1 = new Neusoft.HISFC.Components.OutpatientFee.Controls.ucSetting();
            this.SuspendLayout();
            // 
            // ucSetting1
            // 
            this.ucSetting1.Description = "门诊收费参数设置";
            this.ucSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSetting1.ErrText = "";
            this.ucSetting1.IsModify = false;
            this.ucSetting1.IsShowOwnButtons = true;
            this.ucSetting1.Location = new System.Drawing.Point(0, 0);
            this.ucSetting1.Name = "ucSetting1";
            this.ucSetting1.Size = new System.Drawing.Size(477, 578);
            this.ucSetting1.TabIndex = 0;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 578);
            this.Controls.Add(this.ucSetting1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊参数设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.HISFC.Components.OutpatientFee.Controls.ucSetting ucSetting1;
    }
}