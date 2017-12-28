namespace Neusoft.FrameWork.EPRControl
{
    partial class ucGrid
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
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            //Panel2
            //
            this.Panel2.BackColor = System.Drawing.Color.Black;
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(384, 2);
            this.Panel2.TabIndex = 5;
            //
            //Panel1
            //
            this.Panel1.BackColor = System.Drawing.Color.Black;
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel1.Location = new System.Drawing.Point(376, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(2, 360);
            this.Panel1.TabIndex = 6;
            //
            //Panel3
            //
            this.Panel3.BackColor = System.Drawing.Color.Black;
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel3.Location = new System.Drawing.Point(0, 2);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(2, 360);
            this.Panel3.TabIndex = 7;
            //
            //Panel4
            //
            this.Panel4.BackColor = System.Drawing.Color.Black;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(2, 360);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(368, 2);
            this.Panel4.TabIndex = 8;
            //
            //ucGrid
            //
            this.BackColor = System.Drawing.Color.White;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.Panel4, this.Panel3, this.Panel1, this.Panel2 });
            this.Name = "ucGrid";
            this.Size = new System.Drawing.Size(384, 368);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
