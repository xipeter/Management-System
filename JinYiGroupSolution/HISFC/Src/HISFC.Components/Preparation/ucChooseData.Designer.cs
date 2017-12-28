namespace Neusoft.HISFC.Components.Preparation
{
    partial class ucChooseData
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
            this.components = new System.ComponentModel.Container();
            this.lbTarget = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbData = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.ckChoose = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // lbTarget
            // 
            this.lbTarget.AutoSize = true;
            this.lbTarget.Location = new System.Drawing.Point(12, 12);
            this.lbTarget.Name = "lbTarget";
            this.lbTarget.Size = new System.Drawing.Size(65, 12);
            this.lbTarget.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTarget.TabIndex = 0;
            this.lbTarget.Text = "目标选择：";
            // 
            // cmbData
            // 
            this.cmbData.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbData.FormattingEnabled = true;
            this.cmbData.IsEnter2Tab = false;
            this.cmbData.IsFlat = true;
            this.cmbData.IsLike = true;
            this.cmbData.Location = new System.Drawing.Point(111, 9);
            this.cmbData.Name = "cmbData";
            this.cmbData.PopForm = null;
            this.cmbData.ShowCustomerList = false;
            this.cmbData.ShowID = false;
            this.cmbData.Size = new System.Drawing.Size(156, 20);
            this.cmbData.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbData.TabIndex = 1;
            this.cmbData.Tag = "";
            this.cmbData.ToolBarUse = false;
            // 
            // ckChoose
            // 
            this.ckChoose.AutoSize = true;
            this.ckChoose.Location = new System.Drawing.Point(14, 41);
            this.ckChoose.Name = "ckChoose";
            this.ckChoose.Size = new System.Drawing.Size(60, 16);
            this.ckChoose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckChoose.TabIndex = 2;
            this.ckChoose.Text = "选择项";
            this.ckChoose.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(111, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确 认";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucChooseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckChoose);
            this.Controls.Add(this.cmbData);
            this.Controls.Add(this.lbTarget);
            this.Name = "ucChooseData";
            this.Size = new System.Drawing.Size(270, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTarget;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbData;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckChoose;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}
