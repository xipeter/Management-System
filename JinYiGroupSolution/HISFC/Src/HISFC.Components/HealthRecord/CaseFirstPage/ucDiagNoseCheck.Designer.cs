namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    partial class ucDiagNoseCheck
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private  ucDiagnoseCheck ucDiagCheck;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private System.Windows.Forms.Button tbReturn;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
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
            this.ucDiagCheck = new ucDiagnoseCheck();
            this.tbReturn = new System.Windows.Forms.Button();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDiagCheck
            // 
            this.ucDiagCheck.AutoScroll = true;
            this.ucDiagCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDiagCheck.Location = new System.Drawing.Point(0, 0);
            this.ucDiagCheck.Name = "ucDiagCheck";
            this.ucDiagCheck.Size = new System.Drawing.Size(584, 245);
            this.ucDiagCheck.TabIndex = 0;
            // 
            // tbReturn
            // 
            this.tbReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReturn.Location = new System.Drawing.Point(496, 8);
            this.tbReturn.Name = "tbReturn";
            this.tbReturn.TabIndex = 1;
            this.tbReturn.Text = "关闭";
            this.tbReturn.Click += new System.EventHandler(this.tbReturn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbReturn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 32);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 32);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucDiagNoseCheck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(584, 245);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucDiagCheck);
            this.Name = "ucDiagNoseCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊断提示";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}