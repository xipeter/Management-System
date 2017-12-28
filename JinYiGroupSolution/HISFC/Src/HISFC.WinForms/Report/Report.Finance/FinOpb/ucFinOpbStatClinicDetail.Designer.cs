namespace Report.Finance.FinOpb
{
    partial class ucFinOpbStatClinicDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinOpbStatClinicDetail));
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuDataWindow1 = new NeuDataWindow.Controls.NeuDataWindow();
            this.neuButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuButton2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuDataWindow1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(616, 413);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuDataWindow1
            // 
            this.neuDataWindow1.DataWindowObject = "";
            this.neuDataWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuDataWindow1.Icon = ((System.Drawing.Icon)(resources.GetObject("neuDataWindow1.Icon")));
            this.neuDataWindow1.LibraryList = "";
            this.neuDataWindow1.Location = new System.Drawing.Point(0, 0);
            this.neuDataWindow1.Name = "neuDataWindow1";
            this.neuDataWindow1.Size = new System.Drawing.Size(616, 413);
            this.neuDataWindow1.TabIndex = 0;
            this.neuDataWindow1.Text = "neuDataWindow1";
            // 
            // neuButton1
            // 
            this.neuButton1.Location = new System.Drawing.Point(419, 419);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(75, 23);
            this.neuButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton1.TabIndex = 1;
            this.neuButton1.Text = "打印";
            this.neuButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // neuButton2
            // 
            this.neuButton2.Location = new System.Drawing.Point(534, 419);
            this.neuButton2.Name = "neuButton2";
            this.neuButton2.Size = new System.Drawing.Size(75, 23);
            this.neuButton2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton2.TabIndex = 2;
            this.neuButton2.Text = "关闭";
            this.neuButton2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton2.UseVisualStyleBackColor = true;
            this.neuButton2.Click += new System.EventHandler(this.neuButton2_Click);
            // 
            // ucFinOpbStatClinicDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(616, 463);
            this.Controls.Add(this.neuButton2);
            this.Controls.Add(this.neuButton1);
            this.Controls.Add(this.neuPanel1);
            this.KeyPreview = true;
            this.Name = "ucFinOpbStatClinicDetail";
            this.neuPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private NeuDataWindow.Controls.NeuDataWindow neuDataWindow1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton2;
    }
}
