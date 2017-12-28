namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucPopPatient
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
            this.lvPatient = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.colClinic = new System.Windows.Forms.ColumnHeader();
            this.colPatient = new System.Windows.Forms.ColumnHeader();
            this.colregDate = new System.Windows.Forms.ColumnHeader();
            this.colRegDept = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvPatient
            // 
            this.lvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colClinic,
            this.colPatient,
            this.colregDate,
            this.colRegDept});
            this.lvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPatient.Location = new System.Drawing.Point(0, 0);
            this.lvPatient.Name = "lvPatient";
            this.lvPatient.Size = new System.Drawing.Size(449, 305);
            this.lvPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvPatient.TabIndex = 0;
            this.lvPatient.UseCompatibleStateImageBehavior = false;
            this.lvPatient.View = System.Windows.Forms.View.Details;
            this.lvPatient.DoubleClick += new System.EventHandler(this.lvPatient_DoubleClick);
            this.lvPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvPatient_KeyDown);
            // 
            // colClinic
            // 
            this.colClinic.Text = "门诊号";
            this.colClinic.Width = 102;
            // 
            // colPatient
            // 
            this.colPatient.Text = "患者名称";
            this.colPatient.Width = 83;
            // 
            // colregDate
            // 
            this.colregDate.Text = "挂号时间";
            this.colregDate.Width = 134;
            // 
            // colRegDept
            // 
            this.colRegDept.Text = "挂号科室";
            this.colRegDept.Width = 111;
            // 
            // ucPopPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPatient);
            this.Name = "ucPopPatient";
            this.Size = new System.Drawing.Size(449, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvPatient;
        private System.Windows.Forms.ColumnHeader colClinic;
        private System.Windows.Forms.ColumnHeader colPatient;
        private System.Windows.Forms.ColumnHeader colregDate;
        private System.Windows.Forms.ColumnHeader colRegDept;
    }
}
