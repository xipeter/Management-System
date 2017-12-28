namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucQuerySeeNoByCardNo
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
            this.txtInputCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnReadCard = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // txtInputCode
            // 
            this.txtInputCode.IsEnter2Tab = false;
            this.txtInputCode.Location = new System.Drawing.Point(46, 4);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(96, 21);
            this.txtInputCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInputCode.TabIndex = 0;
            this.txtInputCode.TextChanged += new System.EventHandler(this.txtInputCode_TextChanged);
            this.txtInputCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputCode_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(5, 7);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "卡号：";
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(7, 31);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(135, 38);
            this.btnReadCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnReadCard.TabIndex = 2;
            this.btnReadCard.Text = "读   卡(&F12)";
            this.btnReadCard.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnReadCard.UseVisualStyleBackColor = true;
            
            // 
            // ucQuerySeeNoByCardNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.txtInputCode);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucQuerySeeNoByCardNo";
            this.Size = new System.Drawing.Size(150, 82);
            this.Load += new System.EventHandler(this.ucQuerySeeNoByCardNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInputCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnReadCard;
    }
}
