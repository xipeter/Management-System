namespace Neusoft.HISFC.Components.Nurse.Controls
{
    partial class ucPatientIn
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
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtFreePay = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtTotcost = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtBedNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtDept = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtBalKind = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtIndate = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtCard = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtOutDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.txtPatientNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(99, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.Location = new System.Drawing.Point(55, 315);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(65, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 49;
            this.neuLabel11.Text = "住院日期：";
            // 
            // txtFreePay
            // 
            this.txtFreePay.IsEnter2Tab = false;
            this.txtFreePay.Location = new System.Drawing.Point(126, 280);
            this.txtFreePay.Name = "txtFreePay";
            this.txtFreePay.ReadOnly = true;
            this.txtFreePay.Size = new System.Drawing.Size(119, 21);
            this.txtFreePay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFreePay.TabIndex = 48;
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel10.Location = new System.Drawing.Point(55, 285);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(65, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 47;
            this.neuLabel10.Text = "余    额：";
            // 
            // txtTotcost
            // 
            this.txtTotcost.IsEnter2Tab = false;
            this.txtTotcost.Location = new System.Drawing.Point(126, 253);
            this.txtTotcost.Name = "txtTotcost";
            this.txtTotcost.ReadOnly = true;
            this.txtTotcost.Size = new System.Drawing.Size(119, 21);
            this.txtTotcost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtTotcost.TabIndex = 46;
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel9.Location = new System.Drawing.Point(55, 258);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(65, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 45;
            this.neuLabel9.Text = "总 费 用：";
            // 
            // txtBedNo
            // 
            this.txtBedNo.IsEnter2Tab = false;
            this.txtBedNo.Location = new System.Drawing.Point(126, 226);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.ReadOnly = true;
            this.txtBedNo.Size = new System.Drawing.Size(119, 21);
            this.txtBedNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBedNo.TabIndex = 44;
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel8.Location = new System.Drawing.Point(55, 231);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(65, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 43;
            this.neuLabel8.Text = "床    号：";
            // 
            // txtDept
            // 
            this.txtDept.IsEnter2Tab = false;
            this.txtDept.Location = new System.Drawing.Point(126, 199);
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = true;
            this.txtDept.Size = new System.Drawing.Size(119, 21);
            this.txtDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDept.TabIndex = 42;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel7.Location = new System.Drawing.Point(55, 204);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(65, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 41;
            this.neuLabel7.Text = "科    室：";
            // 
            // txtBalKind
            // 
            this.txtBalKind.IsEnter2Tab = false;
            this.txtBalKind.Location = new System.Drawing.Point(126, 172);
            this.txtBalKind.Name = "txtBalKind";
            this.txtBalKind.ReadOnly = true;
            this.txtBalKind.Size = new System.Drawing.Size(119, 21);
            this.txtBalKind.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBalKind.TabIndex = 40;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel6.Location = new System.Drawing.Point(55, 177);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(65, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 39;
            this.neuLabel6.Text = "结算类别：";
            // 
            // txtSex
            // 
            this.txtSex.IsEnter2Tab = false;
            this.txtSex.Location = new System.Drawing.Point(126, 145);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(119, 21);
            this.txtSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSex.TabIndex = 38;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel5.Location = new System.Drawing.Point(55, 150);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(65, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 37;
            this.neuLabel5.Text = "性    别：";
            // 
            // txtIndate
            // 
            this.txtIndate.IsEnter2Tab = false;
            this.txtIndate.Location = new System.Drawing.Point(126, 118);
            this.txtIndate.Name = "txtIndate";
            this.txtIndate.ReadOnly = true;
            this.txtIndate.Size = new System.Drawing.Size(119, 21);
            this.txtIndate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtIndate.TabIndex = 36;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel4.Location = new System.Drawing.Point(55, 123);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 35;
            this.neuLabel4.Text = "入院日期：";
            // 
            // txtName
            // 
            this.txtName.IsEnter2Tab = false;
            this.txtName.Location = new System.Drawing.Point(126, 91);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(119, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 34;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel3.Location = new System.Drawing.Point(55, 96);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 33;
            this.neuLabel3.Text = "姓    名：";
            // 
            // txtCard
            // 
            this.txtCard.IsEnter2Tab = false;
            this.txtCard.Location = new System.Drawing.Point(126, 64);
            this.txtCard.Name = "txtCard";
            this.txtCard.ReadOnly = true;
            this.txtCard.Size = new System.Drawing.Size(119, 21);
            this.txtCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCard.TabIndex = 32;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel2.Location = new System.Drawing.Point(55, 69);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 31;
            this.neuLabel2.Text = "病 历 号：";
            // 
            // dtOutDate
            // 
            this.dtOutDate.IsEnter2Tab = false;
            this.dtOutDate.Location = new System.Drawing.Point(126, 310);
            this.dtOutDate.Name = "dtOutDate";
            this.dtOutDate.Size = new System.Drawing.Size(119, 21);
            this.dtOutDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtOutDate.TabIndex = 30;
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.IsEnter2Tab = false;
            this.txtPatientNo.Location = new System.Drawing.Point(126, 37);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.ReadOnly = true;
            this.txtPatientNo.Size = new System.Drawing.Size(119, 21);
            this.txtPatientNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPatientNo.TabIndex = 28;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel1.Location = new System.Drawing.Point(55, 42);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 27;
            this.neuLabel1.Text = "留 观 号：";
            // 
            // ucPatientIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.neuLabel11);
            this.Controls.Add(this.txtFreePay);
            this.Controls.Add(this.neuLabel10);
            this.Controls.Add(this.txtTotcost);
            this.Controls.Add(this.neuLabel9);
            this.Controls.Add(this.txtBedNo);
            this.Controls.Add(this.neuLabel8);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.neuLabel7);
            this.Controls.Add(this.txtBalKind);
            this.Controls.Add(this.neuLabel6);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.neuLabel5);
            this.Controls.Add(this.txtIndate);
            this.Controls.Add(this.neuLabel4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.dtOutDate);
            this.Controls.Add(this.txtPatientNo);
            this.Controls.Add(this.neuLabel1);
            this.Name = "ucPatientIn";
            this.Size = new System.Drawing.Size(323, 490);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFreePay;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtTotcost;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBedNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBalKind;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtIndate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtOutDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
