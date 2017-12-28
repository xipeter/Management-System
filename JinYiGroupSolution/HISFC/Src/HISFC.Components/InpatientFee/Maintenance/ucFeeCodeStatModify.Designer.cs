namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    partial class ucFeeCodeStatModify
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
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tbp_Main = new System.Windows.Forms.TabPage();
            this.cmbCenterStatCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbValidState = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbExecDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtPrintOrder = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtFeeStatName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtFeeStatCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbMinFee = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtReportName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbReportType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtReportCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.lblCenterStatCode = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblState = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblExecDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblPrintOrder = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblStatName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl_StatCode = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl_MinFeeCode = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl_Type = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl_Name = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbl_Code = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ckbContinue = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuTabControl1.SuspendLayout();
            this.tbp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tbp_Main);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuTabControl1.Location = new System.Drawing.Point(3, 3);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(315, 452);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.TabStop = false;
            // 
            // tbp_Main
            // 
            this.tbp_Main.Controls.Add(this.cmbCenterStatCode);
            this.tbp_Main.Controls.Add(this.cmbValidState);
            this.tbp_Main.Controls.Add(this.cmbExecDept);
            this.tbp_Main.Controls.Add(this.txtPrintOrder);
            this.tbp_Main.Controls.Add(this.txtFeeStatName);
            this.tbp_Main.Controls.Add(this.txtFeeStatCode);
            this.tbp_Main.Controls.Add(this.cmbMinFee);
            this.tbp_Main.Controls.Add(this.txtReportName);
            this.tbp_Main.Controls.Add(this.cmbReportType);
            this.tbp_Main.Controls.Add(this.txtReportCode);
            this.tbp_Main.Controls.Add(this.lblCenterStatCode);
            this.tbp_Main.Controls.Add(this.lblState);
            this.tbp_Main.Controls.Add(this.lblExecDept);
            this.tbp_Main.Controls.Add(this.lblPrintOrder);
            this.tbp_Main.Controls.Add(this.lblStatName);
            this.tbp_Main.Controls.Add(this.lbl_StatCode);
            this.tbp_Main.Controls.Add(this.lbl_MinFeeCode);
            this.tbp_Main.Controls.Add(this.lbl_Type);
            this.tbp_Main.Controls.Add(this.lbl_Name);
            this.tbp_Main.Controls.Add(this.lbl_Code);
            this.tbp_Main.Location = new System.Drawing.Point(4, 21);
            this.tbp_Main.Name = "tbp_Main";
            this.tbp_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Main.Size = new System.Drawing.Size(307, 427);
            this.tbp_Main.TabIndex = 0;
            this.tbp_Main.Text = "统计大类增加修改";
            this.tbp_Main.UseVisualStyleBackColor = true;
            // 
            // cmbCenterStatCode
            // 
            this.cmbCenterStatCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbCenterStatCode.FormattingEnabled = true;
            this.cmbCenterStatCode.IsFlat = true;
            this.cmbCenterStatCode.IsLike = true;
            this.cmbCenterStatCode.Location = new System.Drawing.Point(129, 283);
            this.cmbCenterStatCode.Name = "cmbCenterStatCode";
            this.cmbCenterStatCode.PopForm = null;
            this.cmbCenterStatCode.ShowCustomerList = false;
            this.cmbCenterStatCode.ShowID = false;
            this.cmbCenterStatCode.Size = new System.Drawing.Size(143, 20);
            this.cmbCenterStatCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbCenterStatCode.TabIndex = 19;
            this.cmbCenterStatCode.Tag = "";
            this.cmbCenterStatCode.ToolBarUse = false;
            // 
            // cmbValidState
            // 
            this.cmbValidState.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbValidState.FormattingEnabled = true;
            this.cmbValidState.IsFlat = true;
            this.cmbValidState.IsLike = true;
            this.cmbValidState.Location = new System.Drawing.Point(129, 315);
            this.cmbValidState.Name = "cmbValidState";
            this.cmbValidState.PopForm = null;
            this.cmbValidState.ShowCustomerList = false;
            this.cmbValidState.ShowID = false;
            this.cmbValidState.Size = new System.Drawing.Size(143, 20);
            this.cmbValidState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbValidState.TabIndex = 21;
            this.cmbValidState.Tag = "";
            this.cmbValidState.ToolBarUse = false;
            // 
            // cmbExecDept
            // 
            this.cmbExecDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbExecDept.FormattingEnabled = true;
            this.cmbExecDept.IsFlat = true;
            this.cmbExecDept.IsLike = true;
            this.cmbExecDept.Location = new System.Drawing.Point(129, 249);
            this.cmbExecDept.Name = "cmbExecDept";
            this.cmbExecDept.PopForm = null;
            this.cmbExecDept.ShowCustomerList = false;
            this.cmbExecDept.ShowID = false;
            this.cmbExecDept.Size = new System.Drawing.Size(143, 20);
            this.cmbExecDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbExecDept.TabIndex = 15;
            this.cmbExecDept.Tag = "";
            this.cmbExecDept.ToolBarUse = false;
            // 
            // txtPrintOrder
            // 
            this.txtPrintOrder.Location = new System.Drawing.Point(129, 216);
            this.txtPrintOrder.Name = "txtPrintOrder";
            this.txtPrintOrder.Size = new System.Drawing.Size(143, 21);
            this.txtPrintOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPrintOrder.TabIndex = 13;
            this.txtPrintOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFeeStatName
            // 
            this.txtFeeStatName.Location = new System.Drawing.Point(129, 183);
            this.txtFeeStatName.MaxLength = 8;
            this.txtFeeStatName.Name = "txtFeeStatName";
            this.txtFeeStatName.Size = new System.Drawing.Size(143, 21);
            this.txtFeeStatName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFeeStatName.TabIndex = 11;
            this.txtFeeStatName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFeeStatCode
            // 
            this.txtFeeStatCode.Location = new System.Drawing.Point(129, 150);
            this.txtFeeStatCode.MaxLength = 2;
            this.txtFeeStatCode.Name = "txtFeeStatCode";
            this.txtFeeStatCode.Size = new System.Drawing.Size(143, 21);
            this.txtFeeStatCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFeeStatCode.TabIndex = 9;
            this.txtFeeStatCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbMinFee
            // 
            this.cmbMinFee.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMinFee.FormattingEnabled = true;
            this.cmbMinFee.IsFlat = true;
            this.cmbMinFee.IsLike = true;
            this.cmbMinFee.Location = new System.Drawing.Point(129, 118);
            this.cmbMinFee.Name = "cmbMinFee";
            this.cmbMinFee.PopForm = null;
            this.cmbMinFee.ShowCustomerList = false;
            this.cmbMinFee.ShowID = false;
            this.cmbMinFee.Size = new System.Drawing.Size(143, 20);
            this.cmbMinFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMinFee.TabIndex = 7;
            this.cmbMinFee.Tag = "";
            this.cmbMinFee.ToolBarUse = false;
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(129, 53);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(143, 21);
            this.txtReportName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtReportName.TabIndex = 3;
            this.txtReportName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbReportType
            // 
            this.cmbReportType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.IsFlat = true;
            this.cmbReportType.IsLike = true;
            this.cmbReportType.Location = new System.Drawing.Point(129, 86);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.PopForm = null;
            this.cmbReportType.ShowCustomerList = false;
            this.cmbReportType.ShowID = false;
            this.cmbReportType.Size = new System.Drawing.Size(143, 20);
            this.cmbReportType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbReportType.TabIndex = 5;
            this.cmbReportType.Tag = "";
            this.cmbReportType.ToolBarUse = false;
            // 
            // txtReportCode
            // 
            this.txtReportCode.Location = new System.Drawing.Point(129, 20);
            this.txtReportCode.Name = "txtReportCode";
            this.txtReportCode.Size = new System.Drawing.Size(143, 21);
            this.txtReportCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtReportCode.TabIndex = 1;
            this.txtReportCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCenterStatCode
            // 
            this.lblCenterStatCode.AutoSize = true;
            this.lblCenterStatCode.ForeColor = System.Drawing.Color.Black;
            this.lblCenterStatCode.Location = new System.Drawing.Point(21, 291);
            this.lblCenterStatCode.Name = "lblCenterStatCode";
            this.lblCenterStatCode.Size = new System.Drawing.Size(83, 12);
            this.lblCenterStatCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCenterStatCode.TabIndex = 18;
            this.lblCenterStatCode.Text = "医保统计类别:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblState.Location = new System.Drawing.Point(21, 320);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(59, 12);
            this.lblState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblState.TabIndex = 20;
            this.lblState.Text = "有效状态:";
            // 
            // lblExecDept
            // 
            this.lblExecDept.AutoSize = true;
            this.lblExecDept.ForeColor = System.Drawing.Color.Black;
            this.lblExecDept.Location = new System.Drawing.Point(21, 256);
            this.lblExecDept.Name = "lblExecDept";
            this.lblExecDept.Size = new System.Drawing.Size(59, 12);
            this.lblExecDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblExecDept.TabIndex = 14;
            this.lblExecDept.Text = "执行科室:";
            // 
            // lblPrintOrder
            // 
            this.lblPrintOrder.AutoSize = true;
            this.lblPrintOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPrintOrder.Location = new System.Drawing.Point(21, 223);
            this.lblPrintOrder.Name = "lblPrintOrder";
            this.lblPrintOrder.Size = new System.Drawing.Size(59, 12);
            this.lblPrintOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPrintOrder.TabIndex = 12;
            this.lblPrintOrder.Text = "打印顺序:";
            // 
            // lblStatName
            // 
            this.lblStatName.AutoSize = true;
            this.lblStatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStatName.Location = new System.Drawing.Point(21, 190);
            this.lblStatName.Name = "lblStatName";
            this.lblStatName.Size = new System.Drawing.Size(59, 12);
            this.lblStatName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblStatName.TabIndex = 10;
            this.lblStatName.Text = "统计名称:";
            // 
            // lbl_StatCode
            // 
            this.lbl_StatCode.AutoSize = true;
            this.lbl_StatCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_StatCode.Location = new System.Drawing.Point(21, 157);
            this.lbl_StatCode.Name = "lbl_StatCode";
            this.lbl_StatCode.Size = new System.Drawing.Size(59, 12);
            this.lbl_StatCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl_StatCode.TabIndex = 8;
            this.lbl_StatCode.Text = "统计代码:";
            // 
            // lbl_MinFeeCode
            // 
            this.lbl_MinFeeCode.AutoSize = true;
            this.lbl_MinFeeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_MinFeeCode.Location = new System.Drawing.Point(21, 124);
            this.lbl_MinFeeCode.Name = "lbl_MinFeeCode";
            this.lbl_MinFeeCode.Size = new System.Drawing.Size(59, 12);
            this.lbl_MinFeeCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl_MinFeeCode.TabIndex = 6;
            this.lbl_MinFeeCode.Text = "费用代码:";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_Type.Location = new System.Drawing.Point(21, 91);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(59, 12);
            this.lbl_Type.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl_Type.TabIndex = 4;
            this.lbl_Type.Text = "报表类别:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_Name.Location = new System.Drawing.Point(21, 58);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(59, 12);
            this.lbl_Name.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "报表名称:";
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_Code.Location = new System.Drawing.Point(21, 25);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(59, 12);
            this.lbl_Code.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbl_Code.TabIndex = 0;
            this.lbl_Code.Text = "报表代码:";
            // 
            // ckbContinue
            // 
            this.ckbContinue.AutoSize = true;
            this.ckbContinue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ckbContinue.Location = new System.Drawing.Point(20, 465);
            this.ckbContinue.Name = "ckbContinue";
            this.ckbContinue.Size = new System.Drawing.Size(76, 16);
            this.ckbContinue.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckbContinue.TabIndex = 22;
            this.ckbContinue.Text = "连续录入";
            this.ckbContinue.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(157, 461);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(240, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucFeeCodeStatModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckbContinue);
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucFeeCodeStatModify";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(321, 493);
            this.Load += new System.EventHandler(this.ucFeeCodeStatModify_Load);
            this.neuTabControl1.ResumeLayout(false);
            this.tbp_Main.ResumeLayout(false);
            this.tbp_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tbp_Main;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckbContinue;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCenterStatCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblState;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblExecDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPrintOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblStatName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl_StatCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl_MinFeeCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl_Type;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl_Name;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl_Code;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbReportType;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtReportCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtReportName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPrintOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFeeStatName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFeeStatCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMinFee;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbCenterStatCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbValidState;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbExecDept;
    }
}
