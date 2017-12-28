namespace Neusoft.HISFC.Components.EPR
{
    partial class ucSuperMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSuperMark));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbDraw = new System.Windows.Forms.ToolStripButton();
            this.tbSelect = new System.Windows.Forms.ToolStripButton();
            this.tbEraze = new System.Windows.Forms.ToolStripButton();
            this.tbText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.neuColorPicker1 = new Neusoft.Toolkit.Controls.NeuColorPicker();
            this.neuFontPicker1 = new Neusoft.Toolkit.Controls.NeuFontPicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.neuFontPicker1);
            this.panel1.Controls.Add(this.neuColorPicker1);
            this.panel1.Controls.Add(this.chkOverride);
            this.panel1.Controls.SetChildIndex(this.chkOverride, 0);
            this.panel1.Controls.SetChildIndex(this.neuColorPicker1, 0);
            this.panel1.Controls.SetChildIndex(this.neuFontPicker1, 0);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // tbDraw
            // 
            this.tbDraw.CheckOnClick = true;
            this.tbDraw.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDraw.Image = ((System.Drawing.Image)(resources.GetObject("tbDraw.Image")));
            this.tbDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDraw.Name = "tbDraw";
            this.tbDraw.Size = new System.Drawing.Size(34, 34);
            this.tbDraw.ToolTipText = "画线";
            this.tbDraw.Click += new System.EventHandler(this.tbDraw_Click);
            // 
            // tbSelect
            // 
            this.tbSelect.CheckOnClick = true;
            this.tbSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelect.Image = ((System.Drawing.Image)(resources.GetObject("tbSelect.Image")));
            this.tbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSelect.Name = "tbSelect";
            this.tbSelect.Size = new System.Drawing.Size(34, 34);
            this.tbSelect.ToolTipText = "选择";
            this.tbSelect.Click += new System.EventHandler(this.tbSelect_Click);
            // 
            // tbEraze
            // 
            this.tbEraze.CheckOnClick = true;
            this.tbEraze.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEraze.Image = ((System.Drawing.Image)(resources.GetObject("tbEraze.Image")));
            this.tbEraze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEraze.Name = "tbEraze";
            this.tbEraze.Size = new System.Drawing.Size(34, 34);
            this.tbEraze.ToolTipText = "擦除";
            this.tbEraze.Click += new System.EventHandler(this.tbEraze_Click);
            // 
            // tbText
            // 
            this.tbText.CheckOnClick = true;
            this.tbText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbText.Image = ((System.Drawing.Image)(resources.GetObject("tbText.Image")));
            this.tbText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(34, 34);
            this.tbText.ToolTipText = "文字";
            this.tbText.Click += new System.EventHandler(this.tbText_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // chkOverride
            // 
            this.chkOverride.AutoSize = true;
            this.chkOverride.Location = new System.Drawing.Point(671, 5);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(48, 16);
            this.chkOverride.TabIndex = 8;
            this.chkOverride.Text = "覆盖";
            this.chkOverride.UseVisualStyleBackColor = true;
            // 
            // neuColorPicker1
            // 
            this.neuColorPicker1.BackColor = System.Drawing.Color.White;
            this.neuColorPicker1.Color = System.Drawing.Color.Red;
            this.neuColorPicker1.Location = new System.Drawing.Point(576, 5);
            this.neuColorPicker1.Name = "neuColorPicker1";
            this.neuColorPicker1.Size = new System.Drawing.Size(89, 22);
            this.neuColorPicker1.TabIndex = 7;
            this.neuColorPicker1.NewColor += new Neusoft.Toolkit.Controls.NeuColorPicker.NewColorEventHandler(this.neuColorPicker1_NewColor);
            // 
            // neuFontPicker1
            // 
            this.neuFontPicker1.Font = new System.Drawing.Font("宋体", 10F);
            this.neuFontPicker1.Location = new System.Drawing.Point(326, 5);
            this.neuFontPicker1.Name = "neuFontPicker1";
            this.neuFontPicker1.SelectedFont = new System.Drawing.Font("宋体", 9F);
            this.neuFontPicker1.Size = new System.Drawing.Size(250, 29);
            this.neuFontPicker1.TabIndex = 9;
            // 
            // ucSuperMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "ucSuperMark";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbDraw;
        private System.Windows.Forms.ToolStripButton tbSelect;
        private System.Windows.Forms.ToolStripButton tbEraze;
        private System.Windows.Forms.ToolStripButton tbText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox chkOverride;
        private Neusoft.Toolkit.Controls.NeuColorPicker neuColorPicker1;
        private Neusoft.Toolkit.Controls.NeuFontPicker neuFontPicker1;

        #endregion
    }
}
