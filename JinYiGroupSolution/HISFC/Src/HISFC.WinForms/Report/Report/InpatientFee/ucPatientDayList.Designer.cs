namespace Neusoft.Report.InpatientFee
{
    partial class ucPatientDayList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbChoose = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvChoose = new Neusoft.NFC.Interface.Controls.NeuTreeView();
            this.cbChoose = new Neusoft.NFC.Interface.Controls.NeuCheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ucDayList1 = new Report.InpatientFee.ucDayList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbChoose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tvChoose);
            this.panel1.Controls.Add(this.cbChoose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 525);
            this.panel1.TabIndex = 0;
            // 
            // tbChoose
            // 
            this.tbChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChoose.Location = new System.Drawing.Point(130, 12);
            this.tbChoose.Name = "tbChoose";
            this.tbChoose.Size = new System.Drawing.Size(85, 25);
            this.tbChoose.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.tbChoose.TabIndex = 2;
            this.tbChoose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbChoose_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "住院号：";
            // 
            // tvChoose
            // 
            this.tvChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvChoose.CheckBoxes = true;
            this.tvChoose.HideSelection = false;
            this.tvChoose.Location = new System.Drawing.Point(5, 45);
            this.tvChoose.Name = "tvChoose";
            this.tvChoose.Size = new System.Drawing.Size(210, 475);
            this.tvChoose.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.tvChoose.TabIndex = 1;
            this.tvChoose.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvChoose_AfterCheck);
            // 
            // cbChoose
            // 
            this.cbChoose.AutoSize = true;
            this.cbChoose.Location = new System.Drawing.Point(5, 15);
            this.cbChoose.Name = "cbChoose";
            this.cbChoose.Size = new System.Drawing.Size(57, 19);
            this.cbChoose.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.cbChoose.TabIndex = 1;
            this.cbChoose.Text = "全选";
            this.cbChoose.UseVisualStyleBackColor = true;
            this.cbChoose.CheckedChanged += new System.EventHandler(this.cbChoose_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(220, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 525);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // ucDayList1
            // 
            this.ucDayList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDayList1.Location = new System.Drawing.Point(223, 0);
            this.ucDayList1.Name = "ucDayList1";
            this.ucDayList1.RowsCount = 0;
            this.ucDayList1.Size = new System.Drawing.Size(441, 525);
            this.ucDayList1.TabIndex = 2;
            // 
            // ucPatientDayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDayList1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ucPatientDayList";
            this.Size = new System.Drawing.Size(664, 525);
            this.Load += new System.EventHandler(this.ucPatientDayList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Neusoft.NFC.Interface.Controls.NeuTreeView tvChoose;
        private Neusoft.NFC.Interface.Controls.NeuTextBox tbChoose;
        private Neusoft.NFC.Interface.Controls.NeuCheckBox cbChoose;
        private System.Windows.Forms.Splitter splitter1;
        private ucDayList ucDayList1;
        private System.Windows.Forms.Label label1;
    }
}
