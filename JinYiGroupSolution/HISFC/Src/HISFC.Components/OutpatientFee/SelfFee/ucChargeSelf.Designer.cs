namespace Neusoft.HISFC.Components.OutpatientFee.SelfFee
{
    partial class ucChargeSelf
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

            if (disposing)
            {
                if (this.fPopWin != null)
                {
                    this.fPopWin.Dispose();
                    this.fPopWin = null;
                }

                if (ucShow != null)
                {
                    ucShow.Dispose();
                    ucShow = null;
                }

                if (comFeeItemLists != null)
                {
                    comFeeItemLists.Clear();
                    comFeeItemLists = null;
                }

                if (hsToolBar != null)
                {
                    hsToolBar.Clear();
                    hsToolBar = null;
                }
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
            this.plTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plBottom = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.plBRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plBLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plMain = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.plBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.SystemColors.Control;
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1000, 135);
            this.plTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plTop.TabIndex = 0;
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.SystemColors.Control;
            this.plBottom.Controls.Add(this.neuSplitter2);
            this.plBottom.Controls.Add(this.plBRight);
            this.plBottom.Controls.Add(this.plBLeft);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 530);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(1000, 220);
            this.plBottom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plBottom.TabIndex = 1;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.neuSplitter2.Location = new System.Drawing.Point(549, 0);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(3, 220);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 3;
            this.neuSplitter2.TabStop = false;
            // 
            // plBRight
            // 
            this.plBRight.BackColor = System.Drawing.SystemColors.Control;
            this.plBRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plBRight.Location = new System.Drawing.Point(552, 0);
            this.plBRight.Name = "plBRight";
            this.plBRight.Padding = new System.Windows.Forms.Padding(3);
            this.plBRight.Size = new System.Drawing.Size(448, 220);
            this.plBRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plBRight.TabIndex = 2;
            // 
            // plBLeft
            // 
            this.plBLeft.BackColor = System.Drawing.SystemColors.Control;
            this.plBLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBLeft.Location = new System.Drawing.Point(0, 0);
            this.plBLeft.Name = "plBLeft";
            this.plBLeft.Padding = new System.Windows.Forms.Padding(3);
            this.plBLeft.Size = new System.Drawing.Size(1000, 220);
            this.plBLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plBLeft.TabIndex = 0;
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.SystemColors.Control;
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 135);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1000, 392);
            this.plMain.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plMain.TabIndex = 2;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuSplitter1.Location = new System.Drawing.Point(0, 527);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(1000, 3);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 3;
            this.neuSplitter1.TabStop = false;
            // 
            // ucCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plTop);
            this.Name = "ucCharge";
            this.Size = new System.Drawing.Size(1000, 750);
            this.Load += new System.EventHandler(this.ucCharge_Load);
            this.plBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plBottom;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plMain;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plBLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plBRight;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
    }
}
