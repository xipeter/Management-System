namespace Neusoft.HISFC.Components.Preparation.Process
{
    partial class ucProcessBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProcessBase));
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelInput = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.gbButton = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.gbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.ForeColor = System.Drawing.Color.White;
            this.neuLabel1.Image = ((System.Drawing.Image)(resources.GetObject("neuLabel1.Image")));
            this.neuLabel1.Location = new System.Drawing.Point(0, 0);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(605, 41);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "制剂配置信息管理";
            this.neuLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelInput
            // 
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 41);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(605, 265);
            this.panelInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelInput.TabIndex = 1;
            // 
            // gbButton
            // 
            this.gbButton.Controls.Add(this.btnCancel);
            this.gbButton.Controls.Add(this.btnOK);
            this.gbButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbButton.Location = new System.Drawing.Point(0, 306);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(605, 39);
            this.gbButton.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbButton.TabIndex = 2;
            this.gbButton.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(429, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确  认";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucProcessBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucProcessBase";
            this.Size = new System.Drawing.Size(605, 345);
            this.gbButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panelInput;
        protected Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbButton;
        protected Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        protected Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;

    }
}
