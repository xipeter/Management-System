namespace Neusoft.HISFC.Components.Registration
{
    partial class frmWaitingAnswer
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.button1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.button2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lbTip = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(71, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "挂号数已经大于设号数,是否继续?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(63, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "是(&Y)";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(201, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 31);
            this.button2.TabIndex = 0;
            this.button2.Text = "否(&N)";
            // 
            // lbTip
            // 
            this.lbTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTip.ForeColor = System.Drawing.Color.Red;
            this.lbTip.Location = new System.Drawing.Point(70, 91);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(251, 28);
            this.lbTip.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.报警;
            this.pictureBox1.Location = new System.Drawing.Point(25, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmWaitingAnswer
            // 
            this.ClientSize = new System.Drawing.Size(361, 202);
            this.ControlBox = false;
            this.Controls.Add(this.lbTip);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaitingAnswer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPictureBox pictureBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton button1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton button2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTip;
        private System.Windows.Forms.Timer timer1;
    }
}