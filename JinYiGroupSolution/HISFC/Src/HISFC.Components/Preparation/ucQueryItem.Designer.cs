namespace UFC.Preparation
{
    partial class ucQueryItem
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
            this.lblQuery = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txtQuery = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.chkNew = new Neusoft.NFC.Interface.Controls.NeuCheckBox();
            this.SuspendLayout();
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(13, 10);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(53, 12);
            this.lblQuery.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "药品查询";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(81, 6);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(150, 21);
            this.txtQuery.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtQuery.TabIndex = 1;
            // 
            // chkNew
            // 
            this.chkNew.AutoSize = true;
            this.chkNew.Location = new System.Drawing.Point(257, 9);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(48, 16);
            this.chkNew.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.chkNew.TabIndex = 2;
            this.chkNew.Text = "新增";
            this.chkNew.UseVisualStyleBackColor = true;
            // 
            // ucQueryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkNew);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.lblQuery);
            this.Name = "ucQueryItem";
            this.Size = new System.Drawing.Size(328, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuLabel lblQuery;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtQuery;
        private Neusoft.NFC.Interface.Controls.NeuCheckBox chkNew;
    }
}
