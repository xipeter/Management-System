namespace Neusoft.Toolkit.Controls
{
    partial class NeuFontPicker
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
            this.cboFamily = new System.Windows.Forms.ComboBox();
            this.chkB = new System.Windows.Forms.CheckBox();
            this.chkI = new System.Windows.Forms.CheckBox();
            this.chkU = new System.Windows.Forms.CheckBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboFamily
            // 
            this.cboFamily.FormattingEnabled = true;
            this.cboFamily.Location = new System.Drawing.Point(3, 3);
            this.cboFamily.Name = "cboFamily";
            this.cboFamily.Size = new System.Drawing.Size(108, 20);
            this.cboFamily.TabIndex = 0;
            // 
            // chkB
            // 
            this.chkB.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkB.AutoSize = true;
            this.chkB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.chkB.Location = new System.Drawing.Point(168, 1);
            this.chkB.Name = "chkB";
            this.chkB.Size = new System.Drawing.Size(22, 22);
            this.chkB.TabIndex = 1;
            this.chkB.Text = "B";
            this.chkB.UseVisualStyleBackColor = true;
            // 
            // chkI
            // 
            this.chkI.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkI.AutoSize = true;
            this.chkI.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkI.Location = new System.Drawing.Point(196, 1);
            this.chkI.Name = "chkI";
            this.chkI.Size = new System.Drawing.Size(21, 22);
            this.chkI.TabIndex = 1;
            this.chkI.Text = "I";
            this.chkI.UseVisualStyleBackColor = true;
            // 
            // chkU
            // 
            this.chkU.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkU.AutoSize = true;
            this.chkU.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkU.Location = new System.Drawing.Point(223, 1);
            this.chkU.Name = "chkU";
            this.chkU.Size = new System.Drawing.Size(21, 22);
            this.chkU.TabIndex = 1;
            this.chkU.Text = "U";
            this.chkU.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72",
            "40"});
            this.cboSize.Location = new System.Drawing.Point(117, 3);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(46, 20);
            this.cboSize.TabIndex = 0;
            this.cboSize.Text = "9";
            // 
            // FontFamilyList
            // 
            this.Controls.Add(this.chkU);
            this.Controls.Add(this.chkI);
            this.Controls.Add(this.chkB);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.cboFamily);
            this.Name = "FontFamilyList";
            this.Size = new System.Drawing.Size(250, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFamily;
        private System.Windows.Forms.CheckBox chkB;
        private System.Windows.Forms.CheckBox chkI;
        private System.Windows.Forms.CheckBox chkU;
        private System.Windows.Forms.ComboBox cboSize;
    }
}
