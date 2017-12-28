namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	partial class ucPatientInformation
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
            this.labelDisplayType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelPatientName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxPatientName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelSexAndAge = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.textBoxAge = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelFreeCount = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxFreeCount = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelPatientType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxPatientType = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelPactType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxPactCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabelSeeDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textBoxSeeDepartment = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.SuspendLayout();
            // 
            // labelDisplayType
            // 
            this.labelDisplayType.AutoSize = true;
            this.labelDisplayType.Location = new System.Drawing.Point(11, 10);
            this.labelDisplayType.Name = "labelDisplayType";
            this.labelDisplayType.Size = new System.Drawing.Size(47, 12);
            this.labelDisplayType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.labelDisplayType.TabIndex = 0;
            this.labelDisplayType.Text = "门诊号:";
            this.labelDisplayType.Click += new System.EventHandler(this.labelDisplayType_Click);
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(68, 7);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(116, 21);
            this.textBoxCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxCode.TabIndex = 1;
            this.textBoxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCode_KeyDown);
            // 
            // neuLabelPatientName
            // 
            this.neuLabelPatientName.AutoSize = true;
            this.neuLabelPatientName.Location = new System.Drawing.Point(188, 12);
            this.neuLabelPatientName.Name = "neuLabelPatientName";
            this.neuLabelPatientName.Size = new System.Drawing.Size(53, 12);
            this.neuLabelPatientName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelPatientName.TabIndex = 2;
            this.neuLabelPatientName.Text = "患者姓名";
            // 
            // textBoxPatientName
            // 
            this.textBoxPatientName.Enabled = false;
            this.textBoxPatientName.Location = new System.Drawing.Point(241, 7);
            this.textBoxPatientName.Name = "textBoxPatientName";
            this.textBoxPatientName.ReadOnly = true;
            this.textBoxPatientName.Size = new System.Drawing.Size(100, 21);
            this.textBoxPatientName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxPatientName.TabIndex = 3;
            // 
            // neuLabelSexAndAge
            // 
            this.neuLabelSexAndAge.AutoSize = true;
            this.neuLabelSexAndAge.Location = new System.Drawing.Point(363, 12);
            this.neuLabelSexAndAge.Name = "neuLabelSexAndAge";
            this.neuLabelSexAndAge.Size = new System.Drawing.Size(53, 12);
            this.neuLabelSexAndAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelSexAndAge.TabIndex = 4;
            this.neuLabelSexAndAge.Text = "性别年龄";
            // 
            // textBoxSex
            // 
            this.textBoxSex.Enabled = false;
            this.textBoxSex.Location = new System.Drawing.Point(418, 7);
            this.textBoxSex.Name = "textBoxSex";
            this.textBoxSex.ReadOnly = true;
            this.textBoxSex.Size = new System.Drawing.Size(48, 21);
            this.textBoxSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxSex.TabIndex = 5;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Enabled = false;
            this.textBoxAge.Location = new System.Drawing.Point(469, 7);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.ReadOnly = true;
            this.textBoxAge.Size = new System.Drawing.Size(48, 21);
            this.textBoxAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxAge.TabIndex = 6;
            // 
            // neuLabelFreeCount
            // 
            this.neuLabelFreeCount.AutoSize = true;
            this.neuLabelFreeCount.Location = new System.Drawing.Point(529, 12);
            this.neuLabelFreeCount.Name = "neuLabelFreeCount";
            this.neuLabelFreeCount.Size = new System.Drawing.Size(53, 12);
            this.neuLabelFreeCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelFreeCount.TabIndex = 7;
            this.neuLabelFreeCount.Text = "帐户余额";
            // 
            // textBoxFreeCount
            // 
            this.textBoxFreeCount.Enabled = false;
            this.textBoxFreeCount.Location = new System.Drawing.Point(588, 7);
            this.textBoxFreeCount.Name = "textBoxFreeCount";
            this.textBoxFreeCount.ReadOnly = true;
            this.textBoxFreeCount.Size = new System.Drawing.Size(100, 21);
            this.textBoxFreeCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxFreeCount.TabIndex = 8;
            // 
            // neuLabelPatientType
            // 
            this.neuLabelPatientType.AutoSize = true;
            this.neuLabelPatientType.Location = new System.Drawing.Point(188, 37);
            this.neuLabelPatientType.Name = "neuLabelPatientType";
            this.neuLabelPatientType.Size = new System.Drawing.Size(53, 12);
            this.neuLabelPatientType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelPatientType.TabIndex = 10;
            this.neuLabelPatientType.Text = "患者类别";
            // 
            // textBoxPatientType
            // 
            this.textBoxPatientType.Enabled = false;
            this.textBoxPatientType.Location = new System.Drawing.Point(241, 32);
            this.textBoxPatientType.Name = "textBoxPatientType";
            this.textBoxPatientType.ReadOnly = true;
            this.textBoxPatientType.Size = new System.Drawing.Size(100, 21);
            this.textBoxPatientType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxPatientType.TabIndex = 11;
            // 
            // neuLabelPactType
            // 
            this.neuLabelPactType.AutoSize = true;
            this.neuLabelPactType.Location = new System.Drawing.Point(363, 37);
            this.neuLabelPactType.Name = "neuLabelPactType";
            this.neuLabelPactType.Size = new System.Drawing.Size(53, 12);
            this.neuLabelPactType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelPactType.TabIndex = 12;
            this.neuLabelPactType.Text = "收费类别";
            // 
            // textBoxPactCode
            // 
            this.textBoxPactCode.Enabled = false;
            this.textBoxPactCode.Location = new System.Drawing.Point(418, 32);
            this.textBoxPactCode.Name = "textBoxPactCode";
            this.textBoxPactCode.ReadOnly = true;
            this.textBoxPactCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxPactCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxPactCode.TabIndex = 13;
            // 
            // neuLabelSeeDept
            // 
            this.neuLabelSeeDept.AutoSize = true;
            this.neuLabelSeeDept.Location = new System.Drawing.Point(529, 37);
            this.neuLabelSeeDept.Name = "neuLabelSeeDept";
            this.neuLabelSeeDept.Size = new System.Drawing.Size(53, 12);
            this.neuLabelSeeDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabelSeeDept.TabIndex = 14;
            this.neuLabelSeeDept.Text = "挂号科室";
            // 
            // textBoxSeeDepartment
            // 
            this.textBoxSeeDepartment.Enabled = false;
            this.textBoxSeeDepartment.Location = new System.Drawing.Point(588, 32);
            this.textBoxSeeDepartment.Name = "textBoxSeeDepartment";
            this.textBoxSeeDepartment.ReadOnly = true;
            this.textBoxSeeDepartment.Size = new System.Drawing.Size(100, 21);
            this.textBoxSeeDepartment.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBoxSeeDepartment.TabIndex = 15;
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(8, 31);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(176, 27);
            this.ucQueryInpatientNo1.TabIndex = 16;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // ucPatientInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSeeDepartment);
            this.Controls.Add(this.neuLabelSeeDept);
            this.Controls.Add(this.textBoxPactCode);
            this.Controls.Add(this.neuLabelPactType);
            this.Controls.Add(this.textBoxPatientType);
            this.Controls.Add(this.neuLabelPatientType);
            this.Controls.Add(this.textBoxFreeCount);
            this.Controls.Add(this.neuLabelFreeCount);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxSex);
            this.Controls.Add(this.neuLabelSexAndAge);
            this.Controls.Add(this.textBoxPatientName);
            this.Controls.Add(this.neuLabelPatientName);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.labelDisplayType);
            this.Controls.Add(this.ucQueryInpatientNo1);
            this.Name = "ucPatientInformation";
            this.Size = new System.Drawing.Size(701, 61);
            this.Load += new System.EventHandler(this.ucPatientInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// 病历号(&A)
		/// </summary>
		public Neusoft.FrameWork.WinForms.Controls.NeuLabel labelDisplayType;
		/// <summary>
		/// 病历号(&A)
		/// </summary>
		public Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxCode;
		/// <summary>
		/// 患者姓名
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelPatientName;
		/// <summary>
		/// 患者姓名
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxPatientName;
		/// <summary>
		/// 性别年龄
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelSexAndAge;
		/// <summary>
		/// 性别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxSex;
		/// <summary>
		/// 年龄
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxAge;
		/// <summary>
		/// 帐户余额
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelFreeCount;
		/// <summary>
		/// 帐户余额
		/// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxFreeCount;
		/// <summary>
		/// 患者类别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelPatientType;
		/// <summary>
		/// 患者类别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxPatientType;
		/// <summary>
		/// 收费类别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelPactType;
		/// <summary>
		/// 收费类别
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxPactCode;
		/// <summary>
		/// 就诊科室
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelSeeDept;
		/// <summary>
		/// 就诊科室
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBoxSeeDepartment;
		private System.Windows.Forms.ToolTip toolTip1;
		/// <summary>
		/// 住院号控件
		/// </summary>
		public Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
	}
}
