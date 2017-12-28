namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    partial class ucDocDiagnoseInput
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
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnDel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnAdd = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.ucDiagNoseInput1 = new Neusoft.HISFC.Components.HealthRecord.CaseFirstPage.ucDiagNoseInput();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.BackColor = System.Drawing.Color.White;
            this.neuGroupBox1.Controls.Add(this.btnSave);
            this.neuGroupBox1.Controls.Add(this.btnDel);
            this.neuGroupBox1.Controls.Add(this.btnAdd);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(711, 46);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保 存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(124, 15);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "删 除";
            this.btnDel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增 加";
            this.btnAdd.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucDiagNoseInput1
            // 
            this.ucDiagNoseInput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDiagNoseInput1.Location = new System.Drawing.Point(0, 46);
            this.ucDiagNoseInput1.Name = "ucDiagNoseInput1";
            this.ucDiagNoseInput1.Size = new System.Drawing.Size(711, 450);
            this.ucDiagNoseInput1.TabIndex = 1;
            // 
            // ucDocDiagnoseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDiagNoseInput1);
            this.Controls.Add(this.neuGroupBox1);
            this.Load += new System.EventHandler(ucDocDiagNoseInput_Load);
            this.Name = "ucDocDiagnoseInput";
            this.Size = new System.Drawing.Size(711, 496);
            this.neuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnDel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnAdd;
        private ucDiagNoseInput ucDiagNoseInput1;
    }
}
