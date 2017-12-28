namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucQuery
    {
        /// <summary> 
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 确定事件 sender为查询出的where条件
        /// </summary>
        public event Neusoft.FrameWork.WinForms.Forms.OKHandler OKEvent;
        /// <summary>
        /// 取消事件
        /// </summary>
        public event System.ComponentModel.CancelEventHandler CancelEvent;
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Location = new System.Drawing.Point(486, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置(&R)";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(486, 120);
            this.btnExit.Name = "btnExit";
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出(&X)";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(486, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnDefault);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 159);
            this.panel1.TabIndex = 7;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefault.Location = new System.Drawing.Point(486, 84);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.TabIndex = 7;
            this.btnDefault.Text = "恢复默认";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // ucQuery
            // 
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Name = "ucQuery";
            this.Size = new System.Drawing.Size(570, 159);
            this.Load += new System.EventHandler(this.ucQuery_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
