namespace Neusoft.WinForms.Report.InpatientFee
{
    partial class ucDayFeeList
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
            this.neuDataWindow1 = new NeuDataWindow.Controls.NeuDataWindow();
            this.SuspendLayout();
            // 
            // neuDataWindow1
            // 
            this.neuDataWindow1.DataWindowObject = "";
            this.neuDataWindow1.LibraryList = "E:\\南京妇幼项目\\妇幼\\query.pbl";
            this.neuDataWindow1.Location = new System.Drawing.Point(111, 126);
            this.neuDataWindow1.Name = "neuDataWindow1";
            this.neuDataWindow1.Size = new System.Drawing.Size(411, 258);
            this.neuDataWindow1.TabIndex = 0;
            this.neuDataWindow1.Text = "neuDataWindow1";
            // 
            // ucDayFeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuDataWindow1);
            this.Name = "ucDayFeeList";
            this.Size = new System.Drawing.Size(642, 423);
            this.ResumeLayout(false);

        }

        #endregion

        private NeuDataWindow.Controls.NeuDataWindow neuDataWindow1;
    }
}
