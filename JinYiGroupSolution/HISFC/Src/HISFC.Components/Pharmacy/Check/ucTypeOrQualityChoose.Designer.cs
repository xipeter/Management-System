namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    partial class ucTypeOrQualityChoose
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckValidDrug = new System.Windows.Forms.CheckBox();
            this.ckZeroState = new System.Windows.Forms.CheckBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnAll = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tvObject = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.groupBox1);
            this.neuPanel1.Controls.Add(this.btnOK);
            this.neuPanel1.Controls.Add(this.btnCancel);
            this.neuPanel1.Controls.Add(this.btnAll);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel1.Location = new System.Drawing.Point(0, 401);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(241, 101);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckValidDrug);
            this.groupBox1.Controls.Add(this.ckZeroState);
            this.groupBox1.Location = new System.Drawing.Point(5, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设 置";
            // 
            // ckValidDrug
            // 
            this.ckValidDrug.AutoSize = true;
            this.ckValidDrug.Checked = true;
            this.ckValidDrug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckValidDrug.ForeColor = System.Drawing.Color.Blue;
            this.ckValidDrug.Location = new System.Drawing.Point(6, 38);
            this.ckValidDrug.Name = "ckValidDrug";
            this.ckValidDrug.Size = new System.Drawing.Size(204, 16);
            this.ckValidDrug.TabIndex = 0;
            this.ckValidDrug.Text = "对停用药品(本库房停用)进行封帐";
            this.ckValidDrug.UseVisualStyleBackColor = true;
            // 
            // ckZeroState
            // 
            this.ckZeroState.AutoSize = true;
            this.ckZeroState.Checked = true;
            this.ckZeroState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckZeroState.ForeColor = System.Drawing.Color.Blue;
            this.ckZeroState.Location = new System.Drawing.Point(6, 18);
            this.ckZeroState.Name = "ckZeroState";
            this.ckZeroState.Size = new System.Drawing.Size(168, 16);
            this.ckZeroState.TabIndex = 0;
            this.ckZeroState.Text = "对库存为零的药品进行封帐";
            this.ckZeroState.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(126, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(51, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确 定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(181, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAll
            // 
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.Location = new System.Drawing.Point(5, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(67, 23);
            this.btnAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "全部药品";
            this.btnAll.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // tvObject
            // 
            this.tvObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObject.HideSelection = false;
            this.tvObject.Location = new System.Drawing.Point(0, 0);
            this.tvObject.Name = "tvObject";
            this.tvObject.Size = new System.Drawing.Size(241, 401);
            this.tvObject.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvObject.TabIndex = 1;
            this.tvObject.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvObject_AfterCheck);
            // 
            // ucTypeOrQualityChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvObject);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucTypeOrQualityChoose";
            this.Size = new System.Drawing.Size(241, 502);
            this.neuPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvObject;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckValidDrug;
        private System.Windows.Forms.CheckBox ckZeroState;
    }
}
