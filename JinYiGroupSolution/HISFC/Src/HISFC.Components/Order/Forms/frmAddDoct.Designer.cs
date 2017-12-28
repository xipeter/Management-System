namespace Neusoft.HISFC.Components.Order.Forms
{
    partial class frmAddDoct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtDept = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbDoct = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbDoct);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.txtDept);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(12, 21);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(255, 121);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "科室医生信息";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(16, 36);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "所属科室：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(16, 78);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "选择医生：";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(61, 174);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOK.TabIndex = 1;
            this.btOK.Text = "确定(&O)";
            this.btOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(155, 174);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消(&C)";
            this.btCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // txtDept
            // 
            this.txtDept.IsEnter2Tab = false;
            this.txtDept.Location = new System.Drawing.Point(97, 33);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(121, 21);
            this.txtDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDept.TabIndex = 1;
            // 
            // cmbDoct
            // 
            this.cmbDoct.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDoct.FormattingEnabled = true;
            this.cmbDoct.IsEnter2Tab = false;
            this.cmbDoct.IsFlat = false;
            this.cmbDoct.IsLike = true;
            this.cmbDoct.IsListOnly = false;
            this.cmbDoct.IsShowCustomerList = false;
            this.cmbDoct.IsShowID = false;
            this.cmbDoct.Location = new System.Drawing.Point(97, 75);
            this.cmbDoct.Name = "cmbDoct";
            this.cmbDoct.PopForm = null;
            this.cmbDoct.ShowCustomerList = false;
            this.cmbDoct.ShowID = false;
            this.cmbDoct.Size = new System.Drawing.Size(121, 20);
            this.cmbDoct.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDoct.TabIndex = 3;
            this.cmbDoct.Tag = "";
            this.cmbDoct.ToolBarUse = false;
            // 
            // frmAddDoct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 221);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.neuGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDoct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加医生";
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDoct;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btCancel;
    }
}