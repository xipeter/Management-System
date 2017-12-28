namespace Neusoft.HISFC.Components.Operation
{
    partial class ucQueryFee
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
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.neuCheckBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuDateTimePicker2 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucQueryFeeDrug1 = new Neusoft.HISFC.Components.Operation.ucQueryFeeDrug();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucQueryFeeUndrug1 = new Neusoft.HISFC.Components.Operation.ucQueryFeeUndrug();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.neuPanel1.Controls.Add(this.neuCheckBox1);
            this.neuPanel1.Controls.Add(this.neuDateTimePicker2);
            this.neuPanel1.Controls.Add(this.neuDateTimePicker1);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.label1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(187, 719);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            this.neuPanel1.Visible = false;
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(7, -2);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(167, 27);
            this.ucQueryInpatientNo1.TabIndex = 5;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // neuCheckBox1
            // 
            this.neuCheckBox1.AutoSize = true;
            this.neuCheckBox1.Location = new System.Drawing.Point(17, 263);
            this.neuCheckBox1.Name = "neuCheckBox1";
            this.neuCheckBox1.Size = new System.Drawing.Size(48, 16);
            this.neuCheckBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox1.TabIndex = 4;
            this.neuCheckBox1.Text = "手术";
            this.neuCheckBox1.UseVisualStyleBackColor = true;
            // 
            // neuDateTimePicker2
            // 
            this.neuDateTimePicker2.Location = new System.Drawing.Point(17, 220);
            this.neuDateTimePicker2.Name = "neuDateTimePicker2";
            this.neuDateTimePicker2.Size = new System.Drawing.Size(131, 21);
            this.neuDateTimePicker2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker2.TabIndex = 3;
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.Location = new System.Drawing.Point(17, 145);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(131, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 3;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(15, 189);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(89, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "结束时间(入院)";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(15, 114);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(89, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "开始时间(入院)";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(15, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 3);
            this.label1.TabIndex = 1;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(187, 28);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(648, 691);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucQueryFeeDrug1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "药品";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucQueryFeeDrug1
            // 
            this.ucQueryFeeDrug1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQueryFeeDrug1.Location = new System.Drawing.Point(3, 3);
            this.ucQueryFeeDrug1.Name = "ucQueryFeeDrug1";
            this.ucQueryFeeDrug1.Size = new System.Drawing.Size(634, 660);
            this.ucQueryFeeDrug1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucQueryFeeUndrug1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(640, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "非药品";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucQueryFeeUndrug1
            // 
            this.ucQueryFeeUndrug1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQueryFeeUndrug1.Location = new System.Drawing.Point(3, 3);
            this.ucQueryFeeUndrug1.Name = "ucQueryFeeUndrug1";
            this.ucQueryFeeUndrug1.Size = new System.Drawing.Size(634, 660);
            this.ucQueryFeeUndrug1.TabIndex = 0;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.ucQueryInpatientNo1);
            this.neuPanel2.Controls.Add(this.neuLabel3);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(187, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(648, 28);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(213, 8);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(0, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            // 
            // ucQueryFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucQueryFee";
            this.Size = new System.Drawing.Size(835, 719);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ucQueryFeeDrug ucQueryFeeDrug1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucQueryFeeUndrug ucQueryFeeUndrug1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
    }
}
