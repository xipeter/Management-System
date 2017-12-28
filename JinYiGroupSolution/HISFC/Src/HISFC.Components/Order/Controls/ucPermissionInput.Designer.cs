namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucPermissionInput
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDoctor = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtMemo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(62, 32);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "授权科室：";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = false;
            this.cmbDept.IsLike = true;
            this.cmbDept.IsListOnly = false;
            this.cmbDept.IsPopForm = true;
            this.cmbDept.IsShowCustomerList = false;
            this.cmbDept.IsShowID = false;
            this.cmbDept.Location = new System.Drawing.Point(133, 29);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 1;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(62, 75);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "授权专家：";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.IsEnter2Tab = false;
            this.cmbDoctor.IsFlat = false;
            this.cmbDoctor.IsLike = true;
            this.cmbDoctor.IsListOnly = false;
            this.cmbDoctor.IsPopForm = true;
            this.cmbDoctor.IsShowCustomerList = false;
            this.cmbDoctor.IsShowID = false;
            this.cmbDoctor.Location = new System.Drawing.Point(133, 72);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.PopForm = null;
            this.cmbDoctor.ShowCustomerList = false;
            this.cmbDoctor.ShowID = false;
            this.cmbDoctor.Size = new System.Drawing.Size(121, 20);
            this.cmbDoctor.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDoctor.TabIndex = 3;
            this.cmbDoctor.Tag = "";
            this.cmbDoctor.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(26, 119);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(101, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "处方授权日期从：";
            // 
            // dtBegin
            // 
            this.dtBegin.IsEnter2Tab = false;
            this.dtBegin.Location = new System.Drawing.Point(133, 115);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(121, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 5;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(98, 170);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(17, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "到";
            this.neuLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtEnd
            // 
            this.dtEnd.IsEnter2Tab = false;
            this.dtEnd.Location = new System.Drawing.Point(133, 166);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(121, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 7;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(62, 222);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(65, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "授权说明：";
            // 
            // txtMemo
            // 
            this.txtMemo.IsEnter2Tab = false;
            this.txtMemo.Location = new System.Drawing.Point(133, 219);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(121, 21);
            this.txtMemo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMemo.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(127, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(193, 313);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ucPermissionInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.neuLabel5);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.neuLabel4);
            this.Controls.Add(this.dtBegin);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucPermissionInput";
            this.Size = new System.Drawing.Size(302, 385);
            this.Load += new System.EventHandler(this.ucPermissionInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDoctor;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMemo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
    }
}
