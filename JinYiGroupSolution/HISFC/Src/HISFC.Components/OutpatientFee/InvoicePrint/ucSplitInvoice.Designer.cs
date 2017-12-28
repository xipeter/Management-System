namespace Neusoft.HISFC.Components.OutpatientFee.InvoicePrint
{
    partial class ucSplitInvoice
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
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plSplitUnits = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnSplit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbCount = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cbAuto = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.tbCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tbOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tbSplit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucInvoicePreviewGF1 = new Neusoft.HISFC.Components.OutpatientFee.InvoicePrint.ucInvoicePreviewSplit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ucInvoicePreviewGF1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 200);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 0;
            // 
            // plSplitUnits
            // 
            this.plSplitUnits.AutoScroll = true;
            this.plSplitUnits.BackColor = System.Drawing.SystemColors.Control;
            this.plSplitUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plSplitUnits.Location = new System.Drawing.Point(0, 200);
            this.plSplitUnits.Name = "plSplitUnits";
            this.plSplitUnits.Size = new System.Drawing.Size(1020, 520);
            this.plSplitUnits.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plSplitUnits.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSplit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbCount);
            this.panel2.Controls.Add(this.cbAuto);
            this.panel2.Controls.Add(this.tbCancel);
            this.panel2.Controls.Add(this.tbOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 720);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 40);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 2;
            // 
            // btnSplit
            // 
            this.btnSplit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSplit.Location = new System.Drawing.Point(338, 9);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(88, 24);
            this.btnSplit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSplit.TabIndex = 18;
            this.btnSplit.Text = "分票(&S)";
            this.btnSplit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 11.25F);
            this.label2.Location = new System.Drawing.Point(145, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 17;
            this.label2.Text = "分票张数:";
            // 
            // tbCount
            // 
            this.tbCount.BackColor = System.Drawing.Color.White;
            this.tbCount.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCount.Location = new System.Drawing.Point(229, 8);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(100, 25);
            this.tbCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCount.TabIndex = 16;
            this.tbCount.Text = "0";
            this.tbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbAuto
            // 
            this.cbAuto.Font = new System.Drawing.Font("宋体", 11.25F);
            this.cbAuto.Location = new System.Drawing.Point(32, 8);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(104, 24);
            this.cbAuto.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbAuto.TabIndex = 2;
            this.cbAuto.Text = "自动分票";
            this.cbAuto.CheckedChanged += new System.EventHandler(this.cbAuto_CheckedChanged);
            // 
            // tbCancel
            // 
            this.tbCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbCancel.Location = new System.Drawing.Point(930, 8);
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Size = new System.Drawing.Size(88, 24);
            this.tbCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCancel.TabIndex = 1;
            this.tbCancel.Text = "取消(&C)";
            this.tbCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.tbCancel.Click += new System.EventHandler(this.tbCancel_Click);
            // 
            // tbOK
            // 
            this.tbOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbOK.Location = new System.Drawing.Point(833, 8);
            this.tbOK.Name = "tbOK";
            this.tbOK.Size = new System.Drawing.Size(88, 24);
            this.tbOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbOK.TabIndex = 0;
            this.tbOK.Text = "确定(&O)";
            this.tbOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.tbOK.Click += new System.EventHandler(this.tbOK_Click);
            // 
            // tbSplit
            // 
            this.tbSplit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbSplit.Location = new System.Drawing.Point(0, 0);
            this.tbSplit.Name = "tbSplit";
            this.tbSplit.Size = new System.Drawing.Size(75, 23);
            this.tbSplit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbSplit.TabIndex = 0;
            this.tbSplit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            // 
            // ucInvoicePreviewGF1
            // 
            this.ucInvoicePreviewGF1.InvoiceType = "";
            this.ucInvoicePreviewGF1.Location = new System.Drawing.Point(7, 4);
            this.ucInvoicePreviewGF1.Name = "ucInvoicePreviewGF1";
            this.ucInvoicePreviewGF1.Size = new System.Drawing.Size(1008, 188);
            this.ucInvoicePreviewGF1.TabIndex = 0;
            // 
            // ucSplitInvoice
            // 
            this.Controls.Add(this.plSplitUnits);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucSplitInvoice";
            this.Size = new System.Drawing.Size(1020, 760);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plSplitUnits;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton tbOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton tbCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbAuto;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbCount;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton tbSplit;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSplit;
        private ucInvoicePreviewSplit ucInvoicePreviewGF1;
    }
}
