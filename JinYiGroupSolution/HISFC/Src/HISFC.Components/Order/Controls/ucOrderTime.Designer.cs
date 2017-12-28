namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucOrderTime
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
            this.components = new System.ComponentModel.Container();
            this.ckbOrdertime = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.dtpickerOrder = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ckbOrdertime
            // 
            this.ckbOrdertime.AutoSize = true;
            this.ckbOrdertime.Location = new System.Drawing.Point(3, 8);
            this.ckbOrdertime.Name = "ckbOrdertime";
            this.ckbOrdertime.Size = new System.Drawing.Size(72, 16);
            this.ckbOrdertime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckbOrdertime.TabIndex = 0;
            this.ckbOrdertime.Text = "医嘱时间";
            this.ckbOrdertime.UseVisualStyleBackColor = true;
            this.ckbOrdertime.CheckedChanged += new System.EventHandler(this.ckbOrdertime_CheckedChanged);
            // 
            // dtpickerOrder
            // 
            this.dtpickerOrder.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpickerOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpickerOrder.Location = new System.Drawing.Point(73, 5);
            this.dtpickerOrder.Name = "dtpickerOrder";
            this.dtpickerOrder.Size = new System.Drawing.Size(139, 21);
            this.dtpickerOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpickerOrder.TabIndex = 1;
            // 
            // ucOrderTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpickerOrder);
            this.Controls.Add(this.ckbOrdertime);
            this.Name = "ucOrderTime";
            this.Size = new System.Drawing.Size(215, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckbOrdertime;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpickerOrder;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
