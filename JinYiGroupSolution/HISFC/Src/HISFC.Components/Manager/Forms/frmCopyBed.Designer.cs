namespace Neusoft.HISFC.Components.Manager.Forms
{
    partial class frmCopyBed
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbNurse = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtBedNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmdBedGrade = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbBedStatus = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbBedWeave = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtWardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPhone = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtOwn = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtSort = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(35, 25);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(59, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "护 士 站:";
            // 
            // cmbNurse
            // 
            this.cmbNurse.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbNurse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNurse.FormattingEnabled = true;
            this.cmbNurse.IsFlat = true;
            this.cmbNurse.IsLike = true;
            this.cmbNurse.Location = new System.Drawing.Point(104, 22);
            this.cmbNurse.Name = "cmbNurse";
            this.cmbNurse.PopForm = null;
            this.cmbNurse.ShowCustomerList = false;
            this.cmbNurse.ShowID = false;
            this.cmbNurse.Size = new System.Drawing.Size(121, 20);
            this.cmbNurse.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbNurse.TabIndex = 0;
            this.cmbNurse.Tag = "";
            this.cmbNurse.ToolBarUse = false;
            this.cmbNurse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // txtBedNo
            // 
            this.txtBedNo.Location = new System.Drawing.Point(104, 79);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.Size = new System.Drawing.Size(121, 21);
            this.txtBedNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBedNo.TabIndex = 2;
            this.txtBedNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // cmdBedGrade
            // 
            this.cmdBedGrade.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmdBedGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdBedGrade.FormattingEnabled = true;
            this.cmdBedGrade.IsFlat = true;
            this.cmdBedGrade.IsLike = true;
            this.cmdBedGrade.Location = new System.Drawing.Point(104, 107);
            this.cmdBedGrade.Name = "cmdBedGrade";
            this.cmdBedGrade.PopForm = null;
            this.cmdBedGrade.ShowCustomerList = false;
            this.cmdBedGrade.ShowID = false;
            this.cmdBedGrade.Size = new System.Drawing.Size(121, 20);
            this.cmdBedGrade.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmdBedGrade.TabIndex = 3;
            this.cmdBedGrade.Tag = "";
            this.cmdBedGrade.ToolBarUse = false;
            this.cmdBedGrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(35, 53);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(59, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 3;
            this.neuLabel2.Text = "病 房 号:";
            // 
            // cmbBedStatus
            // 
            this.cmbBedStatus.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbBedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBedStatus.FormattingEnabled = true;
            this.cmbBedStatus.IsFlat = true;
            this.cmbBedStatus.IsLike = true;
            this.cmbBedStatus.Location = new System.Drawing.Point(104, 134);
            this.cmbBedStatus.Name = "cmbBedStatus";
            this.cmbBedStatus.PopForm = null;
            this.cmbBedStatus.ShowCustomerList = false;
            this.cmbBedStatus.ShowID = false;
            this.cmbBedStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbBedStatus.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbBedStatus.TabIndex = 4;
            this.cmbBedStatus.Tag = "";
            this.cmbBedStatus.ToolBarUse = false;
            this.cmbBedStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(35, 109);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "床位等级:";
            // 
            // cmbBedWeave
            // 
            this.cmbBedWeave.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbBedWeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBedWeave.FormattingEnabled = true;
            this.cmbBedWeave.IsFlat = true;
            this.cmbBedWeave.IsLike = true;
            this.cmbBedWeave.Location = new System.Drawing.Point(104, 161);
            this.cmbBedWeave.Name = "cmbBedWeave";
            this.cmbBedWeave.PopForm = null;
            this.cmbBedWeave.ShowCustomerList = false;
            this.cmbBedWeave.ShowID = false;
            this.cmbBedWeave.Size = new System.Drawing.Size(121, 20);
            this.cmbBedWeave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbBedWeave.TabIndex = 5;
            this.cmbBedWeave.Tag = "";
            this.cmbBedWeave.ToolBarUse = false;
            this.cmbBedWeave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(35, 221);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 7;
            this.neuLabel4.Text = "顺 序 号:";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(35, 249);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(59, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 9;
            this.neuLabel5.Text = "归    属:";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel6.Location = new System.Drawing.Point(35, 81);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(59, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 11;
            this.neuLabel6.Text = "床 位 号:";
            // 
            // txtWardNo
            // 
            this.txtWardNo.Location = new System.Drawing.Point(104, 51);
            this.txtWardNo.Name = "txtWardNo";
            this.txtWardNo.Size = new System.Drawing.Size(121, 21);
            this.txtWardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtWardNo.TabIndex = 1;
            this.txtWardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel7.Location = new System.Drawing.Point(35, 165);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(59, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 13;
            this.neuLabel7.Text = "床位编制:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(104, 188);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(121, 21);
            this.txtPhone.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPhone.TabIndex = 6;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel8.Location = new System.Drawing.Point(35, 137);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(59, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 15;
            this.neuLabel8.Text = "床位状态:";
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.Location = new System.Drawing.Point(35, 193);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(59, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 17;
            this.neuLabel9.Text = "床位电话:";
            // 
            // txtOwn
            // 
            this.txtOwn.Location = new System.Drawing.Point(104, 244);
            this.txtOwn.Name = "txtOwn";
            this.txtOwn.Size = new System.Drawing.Size(121, 21);
            this.txtOwn.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOwn.TabIndex = 8;
            this.txtOwn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(55, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "保存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(150, 293);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "退出";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtSort
            // 
            this.txtSort.AllowNegative = false;
            this.txtSort.IsAutoRemoveDecimalZero = false;
            this.txtSort.Location = new System.Drawing.Point(104, 216);
            this.txtSort.Name = "txtSort";
            this.txtSort.NumericPrecision = 3;
            this.txtSort.NumericScaleOnFocus = 0;
            this.txtSort.NumericScaleOnLostFocus = 0;
            this.txtSort.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSort.SetRange = new System.Drawing.Size(-1, -1);
            this.txtSort.Size = new System.Drawing.Size(121, 21);
            this.txtSort.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSort.TabIndex = 7;
            this.txtSort.Text = "0";
            this.txtSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSort.UseGroupSeperator = true;
            this.txtSort.ZeroIsValid = true;
            this.txtSort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSort_KeyPress);
            // 
            // frmBedManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 342);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.neuLabel9);
            this.Controls.Add(this.txtOwn);
            this.Controls.Add(this.neuLabel8);
            this.Controls.Add(this.neuLabel7);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.neuLabel6);
            this.Controls.Add(this.txtWardNo);
            this.Controls.Add(this.neuLabel5);
            this.Controls.Add(this.cmbBedWeave);
            this.Controls.Add(this.neuLabel4);
            this.Controls.Add(this.cmbBedStatus);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.cmdBedGrade);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.txtBedNo);
            this.Controls.Add(this.cmbNurse);
            this.Controls.Add(this.neuLabel1);
            this.Name = "frmBedManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复制床位";
            this.Load += new System.EventHandler(this.frmBedManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbNurse;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBedNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmdBedGrade;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbBedStatus;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbBedWeave;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtWardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPhone;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOwn;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtSort;
    }
}