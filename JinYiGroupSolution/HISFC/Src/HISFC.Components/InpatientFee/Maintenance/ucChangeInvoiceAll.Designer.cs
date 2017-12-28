namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucChangeInvoiceAll
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
            this.neuTreeView1 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucInvoiceChangeNOInitInvoiceType1 = new ucInvoiceChangeNOInitInvoiceType();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.Size = new System.Drawing.Size(160, 413);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 1;
            this.neuTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.neuTreeView1_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(160, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 413);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 2;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucInvoiceChangeNOInitInvoiceType1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(163, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(413, 413);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // ucInvoiceChangeNOInitInvoiceType1
            // 
            this.ucInvoiceChangeNOInitInvoiceType1.BackColor = System.Drawing.Color.White;
            this.ucInvoiceChangeNOInitInvoiceType1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeID = "";
            this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = "门诊发票";
            this.ucInvoiceChangeNOInitInvoiceType1.IsPrint = false;
            this.ucInvoiceChangeNOInitInvoiceType1.Location = new System.Drawing.Point(0, 0);
            this.ucInvoiceChangeNOInitInvoiceType1.Name = "ucInvoiceChangeNOInitInvoiceType1";
            this.ucInvoiceChangeNOInitInvoiceType1.Size = new System.Drawing.Size(413, 413);
            this.ucInvoiceChangeNOInitInvoiceType1.TabIndex = 0;
            // 
            // ucChangeInvoiceAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuTreeView1);
            this.Name = "ucChangeInvoiceAll";
            this.Size = new System.Drawing.Size(576, 413);
            this.neuPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView neuTreeView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private ucInvoiceChangeNOInitInvoiceType ucInvoiceChangeNOInitInvoiceType1;


    }
}
