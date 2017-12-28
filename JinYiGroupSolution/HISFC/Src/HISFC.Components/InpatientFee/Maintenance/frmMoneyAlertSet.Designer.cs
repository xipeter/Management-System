namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class frmMoneyAlertSet
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
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtMoneyAlert = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(172, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 25);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(239, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 25);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtMoneyAlert
            // 
            this.txtMoneyAlert.AllowNegative = true;
            this.txtMoneyAlert.IsAutoRemoveDecimalZero = false;
            this.txtMoneyAlert.IsEnter2Tab = false;
            this.txtMoneyAlert.Location = new System.Drawing.Point(12, 15);
            this.txtMoneyAlert.Name = "txtMoneyAlert";
            this.txtMoneyAlert.NumericPrecision = 10;
            this.txtMoneyAlert.NumericScaleOnFocus = 2;
            this.txtMoneyAlert.NumericScaleOnLostFocus = 2;
            this.txtMoneyAlert.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoneyAlert.SetRange = new System.Drawing.Size(-1, -1);
            this.txtMoneyAlert.Size = new System.Drawing.Size(154, 20);
            this.txtMoneyAlert.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMoneyAlert.TabIndex = 3;
            this.txtMoneyAlert.Text = "0.00";
            this.txtMoneyAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoneyAlert.UseGroupSeperator = true;
            this.txtMoneyAlert.ZeroIsValid = true;
            // 
            // frmMoneyAlertSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 60);
            this.ControlBox = false;
            this.Controls.Add(this.txtMoneyAlert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmMoneyAlertSet";
            this.ShowIcon = false;
            this.Text = "请您输入金额";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtMoneyAlert;
    }
}