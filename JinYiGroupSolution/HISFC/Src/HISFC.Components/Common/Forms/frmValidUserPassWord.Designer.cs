namespace Neusoft.HISFC.Components.Common.Forms
{
    partial class frmValidUserPassWord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPassWord = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(23, 32);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "请输入密码：";
            // 
            // txtPassWord
            // 
            this.txtPassWord.IsEnter2Tab = false;
            this.txtPassWord.Location = new System.Drawing.Point(106, 28);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(172, 21);
            this.txtPassWord.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(119, 73);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确定";
            this.btOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(200, 72);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmValidUserPassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 108);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.neuLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmValidUserPassWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmValidUserPassWord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPassWord;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btCancel;
    }
}