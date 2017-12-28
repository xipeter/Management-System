namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucChangeStoreDept
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
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbStoreDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.btnOK);
            this.neuGroupBox1.Controls.Add(this.btnCancel);
            this.neuGroupBox1.Controls.Add(this.cmbStoreDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(311, 86);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "修改取药药房";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(8, 30);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "取药药房：";
            // 
            // cmbStoreDept
            // 
            this.cmbStoreDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbStoreDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStoreDept.FormattingEnabled = true;
            this.cmbStoreDept.IsFlat = true;
            this.cmbStoreDept.IsLike = true;
            this.cmbStoreDept.Location = new System.Drawing.Point(79, 25);
            this.cmbStoreDept.Name = "cmbStoreDept";
            this.cmbStoreDept.PopForm = null;
            this.cmbStoreDept.ShowCustomerList = false;
            this.cmbStoreDept.ShowID = false;
            this.cmbStoreDept.Size = new System.Drawing.Size(219, 22);
            this.cmbStoreDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbStoreDept.TabIndex = 1;
            this.cmbStoreDept.Tag = "";
            this.cmbStoreDept.ToolBarUse = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 58);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确 认";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucChangeStoreDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucChangeStoreDept";
            this.Size = new System.Drawing.Size(311, 86);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStoreDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;

    }
}
