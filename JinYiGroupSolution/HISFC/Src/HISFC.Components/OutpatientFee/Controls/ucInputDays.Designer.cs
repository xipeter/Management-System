namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    partial class ucInputDays
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbDays = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbCombNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(19, 18);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(71, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "请输入付数:";
            // 
            // tbDays
            // 
            this.tbDays.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDays.Location = new System.Drawing.Point(87, 15);
            this.tbDays.Name = "tbDays";
            this.tbDays.Size = new System.Drawing.Size(77, 22);
            this.tbDays.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbDays.TabIndex = 1;
            this.tbDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDays_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(173, 19);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(47, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "组合号:";
            // 
            // tbCombNo
            // 
            this.tbCombNo.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCombNo.Location = new System.Drawing.Point(217, 15);
            this.tbCombNo.Name = "tbCombNo";
            this.tbCombNo.Size = new System.Drawing.Size(75, 22);
            this.tbCombNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCombNo.TabIndex = 3;
            this.tbCombNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCombNo_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(217, 53);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucInputDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbCombNo);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.tbDays);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucInputDays";
            this.Size = new System.Drawing.Size(302, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbDays;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbCombNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
    }
}
