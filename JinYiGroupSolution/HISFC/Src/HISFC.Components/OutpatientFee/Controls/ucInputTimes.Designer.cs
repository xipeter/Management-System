namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    partial class ucInputTimes
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
            this.tbInjec = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tbCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // tbInjec
            // 
            this.tbInjec.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInjec.Location = new System.Drawing.Point(106, 10);
            this.tbInjec.Name = "tbInjec";
            this.tbInjec.Size = new System.Drawing.Size(156, 22);
            this.tbInjec.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbInjec.TabIndex = 3;
            this.tbInjec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInjec_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.neuLabel1.Location = new System.Drawing.Point(8, 13);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(96, 16);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "请输入倍数:";
            // 
            // tbOk
            // 
            this.tbOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbOk.Location = new System.Drawing.Point(106, 42);
            this.tbOk.Name = "tbOk";
            this.tbOk.Size = new System.Drawing.Size(75, 23);
            this.tbOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbOk.TabIndex = 5;
            this.tbOk.Text = "确定(&O)";
            this.tbOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.tbOk.UseVisualStyleBackColor = true;
            this.tbOk.Click += new System.EventHandler(this.tbOk_Click);
            // 
            // tbCancel
            // 
            this.tbCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tbCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbCancel.Location = new System.Drawing.Point(187, 42);
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Size = new System.Drawing.Size(75, 23);
            this.tbCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCancel.TabIndex = 6;
            this.tbCancel.Text = "取消(&C)";
            this.tbCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.tbCancel.UseVisualStyleBackColor = true;
            this.tbCancel.Click += new System.EventHandler(this.tbCancel_Click);
            // 
            // ucInputTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCancel);
            this.Controls.Add(this.tbOk);
            this.Controls.Add(this.tbInjec);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucInputTimes";
            this.Size = new System.Drawing.Size(275, 75);
            this.Load += new System.EventHandler(this.ucInjec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbInjec;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton tbOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton tbCancel;
    }
}
