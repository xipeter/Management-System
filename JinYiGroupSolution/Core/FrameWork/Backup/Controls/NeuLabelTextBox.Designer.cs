namespace Neusoft.FrameWork.WinForms.Controls
{
    partial class NeuLabelTextBox
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
            this.textBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 21);
            this.textBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.label1.TabIndex = 2;
            this.label1.Text = "label";
            // 
            // NeuLabelTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "NeuLabelTextBox";
            this.Size = new System.Drawing.Size(233, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NeuTextBox textBox1;
        private NeuLabel label1;
    }
}
