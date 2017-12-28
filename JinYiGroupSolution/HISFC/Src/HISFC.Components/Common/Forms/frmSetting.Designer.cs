namespace Neusoft.HISFC.Components.Common.Forms
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            
            this.trvControl = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.PanelControl = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.trvControl);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(171, 577);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // trvControl
            // 
            this.trvControl.BackColor = System.Drawing.Color.White;
            this.trvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvControl.HideSelection = false;
            this.trvControl.Location = new System.Drawing.Point(0, 0);
            this.trvControl.Name = "trvControl";
            this.trvControl.Size = new System.Drawing.Size(171, 577);
            this.trvControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.trvControl.TabIndex = 0;
            this.trvControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvControl_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.neuSplitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuSplitter1.Location = new System.Drawing.Point(171, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 577);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // PanelControl
            // 
            this.PanelControl.BackColor = System.Drawing.Color.Beige;
            this.PanelControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControl.Location = new System.Drawing.Point(174, 0);
            this.PanelControl.Name = "PanelControl";
            this.PanelControl.Size = new System.Drawing.Size(512, 577);
            this.PanelControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.PanelControl.TabIndex = 2;
            // 
            // neuPanel3
            // 
            this.neuPanel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.neuPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.neuPanel3.Controls.Add(this.btnCancel);
            this.neuPanel3.Controls.Add(this.btnSave);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel3.Location = new System.Drawing.Point(174, 538);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(512, 39);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(431, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 25);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(354, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 577);
            this.Controls.Add(this.neuPanel3);
            this.Controls.Add(this.PanelControl);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel PanelControl;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView trvControl;
    }
}