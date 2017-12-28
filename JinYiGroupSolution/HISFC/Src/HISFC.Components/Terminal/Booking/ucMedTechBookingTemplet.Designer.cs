using Neusoft.HISFC.Components.Terminal.Booking;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucMedTechBookingTemplet <br></br>
	/// [功能描述: 医技项目排班模板UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	partial class ucMedTechBookingTemplet
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
			this.neuPanelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
			this.neuPanelQuery = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
			this.neuButtonQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.neuTextBoxQuery = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
			this.neuComboBoxDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
			this.neuLabelInputDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.neuPanelRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
			this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet1 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet2 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet3 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet4 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet5 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet6 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.ucBookingTemplet7 = new HISFC.Components.Terminal.Booking.ucBookingTemplet();
			this.neuPanelLeft.SuspendLayout();
			this.neuPanelQuery.SuspendLayout();
			this.neuPanelRight.SuspendLayout();
			this.neuTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.SuspendLayout();
			// 
			// neuPanelLeft
			// 
			this.neuPanelLeft.Controls.Add(this.neuTreeView1);
			this.neuPanelLeft.Controls.Add(this.neuPanelQuery);
			this.neuPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.neuPanelLeft.Location = new System.Drawing.Point(0, 0);
			this.neuPanelLeft.Name = "neuPanelLeft";
			this.neuPanelLeft.Size = new System.Drawing.Size(224, 485);
			this.neuPanelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuPanelLeft.TabIndex = 0;
			// 
			// neuTreeView1
			// 
			this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.neuTreeView1.HideSelection = false;
			this.neuTreeView1.Location = new System.Drawing.Point(0, 68);
			this.neuTreeView1.Name = "neuTreeView1";
			this.neuTreeView1.Size = new System.Drawing.Size(224, 417);
			this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuTreeView1.TabIndex = 1;
			this.neuTreeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.neuTreeView1_NodeMouseDoubleClick);
			// 
			// neuPanelQuery
			// 
			this.neuPanelQuery.Controls.Add(this.neuButtonQuery);
			this.neuPanelQuery.Controls.Add(this.neuTextBoxQuery);
			this.neuPanelQuery.Controls.Add(this.neuComboBoxDept);
			this.neuPanelQuery.Controls.Add(this.neuLabelInputDept);
			this.neuPanelQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.neuPanelQuery.Location = new System.Drawing.Point(0, 0);
			this.neuPanelQuery.Name = "neuPanelQuery";
			this.neuPanelQuery.Size = new System.Drawing.Size(224, 68);
			this.neuPanelQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuPanelQuery.TabIndex = 0;
			// 
			// neuButtonQuery
			// 
			this.neuButtonQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.neuButtonQuery.Location = new System.Drawing.Point(11, 37);
			this.neuButtonQuery.Name = "neuButtonQuery";
			this.neuButtonQuery.Size = new System.Drawing.Size(75, 23);
			this.neuButtonQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuButtonQuery.TabIndex = 3;
			this.neuButtonQuery.Text = "查找";
			this.neuButtonQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
			this.neuButtonQuery.UseVisualStyleBackColor = true;
			this.neuButtonQuery.Click += new System.EventHandler(this.neuButtonQuery_Click);
			// 
			// neuTextBoxQuery
			// 
			this.neuTextBoxQuery.Location = new System.Drawing.Point(91, 38);
			this.neuTextBoxQuery.Name = "neuTextBoxQuery";
			this.neuTextBoxQuery.Size = new System.Drawing.Size(121, 21);
			this.neuTextBoxQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuTextBoxQuery.TabIndex = 2;
			this.neuTextBoxQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuTextBoxQuery_KeyDown);
			// 
			// neuComboBoxDept
			// 
			this.neuComboBoxDept.ArrowBackColor = System.Drawing.Color.Silver;
			this.neuComboBoxDept.FormattingEnabled = true;
			this.neuComboBoxDept.IsFlat = true;
			this.neuComboBoxDept.IsLike = true;
			this.neuComboBoxDept.Location = new System.Drawing.Point(91, 8);
			this.neuComboBoxDept.Name = "neuComboBoxDept";
			this.neuComboBoxDept.PopForm = null;
			this.neuComboBoxDept.ShowCustomerList = false;
			this.neuComboBoxDept.ShowID = false;
			this.neuComboBoxDept.Size = new System.Drawing.Size(121, 20);
			this.neuComboBoxDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuComboBoxDept.TabIndex = 1;
			this.neuComboBoxDept.Tag = "";
			this.neuComboBoxDept.ToolBarUse = false;
			this.neuComboBoxDept.SelectedIndexChanged += new System.EventHandler(this.neuComboBoxDept_SelectedIndexChanged);
			// 
			// neuLabelInputDept
			// 
			this.neuLabelInputDept.AutoSize = true;
			this.neuLabelInputDept.Location = new System.Drawing.Point(23, 12);
			this.neuLabelInputDept.Name = "neuLabelInputDept";
			this.neuLabelInputDept.Size = new System.Drawing.Size(53, 12);
			this.neuLabelInputDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuLabelInputDept.TabIndex = 0;
			this.neuLabelInputDept.Text = "录入科室";
			// 
			// neuPanelRight
			// 
			this.neuPanelRight.Controls.Add(this.neuTabControl1);
			this.neuPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.neuPanelRight.Location = new System.Drawing.Point(224, 0);
			this.neuPanelRight.Name = "neuPanelRight";
			this.neuPanelRight.Size = new System.Drawing.Size(497, 485);
			this.neuPanelRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuPanelRight.TabIndex = 1;
			// 
			// neuTabControl1
			// 
			this.neuTabControl1.Controls.Add(this.tabPage1);
			this.neuTabControl1.Controls.Add(this.tabPage2);
			this.neuTabControl1.Controls.Add(this.tabPage3);
			this.neuTabControl1.Controls.Add(this.tabPage4);
			this.neuTabControl1.Controls.Add(this.tabPage5);
			this.neuTabControl1.Controls.Add(this.tabPage6);
			this.neuTabControl1.Controls.Add(this.tabPage7);
			this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
			this.neuTabControl1.Name = "neuTabControl1";
			this.neuTabControl1.SelectedIndex = 0;
			this.neuTabControl1.Size = new System.Drawing.Size(497, 485);
			this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuTabControl1.TabIndex = 0;
			this.neuTabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.neuTabControl1_Selecting);
			this.neuTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.neuTabControl1_Selected);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ucBookingTemplet1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(489, 460);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "星期一";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet1
			// 
			this.ucBookingTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet1.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet1.Name = "ucBookingTemplet1";
			this.ucBookingTemplet1.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet1.TabIndex = 0;
			this.ucBookingTemplet1.Week = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.ucBookingTemplet2);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(489, 460);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "星期二";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet2
			// 
			this.ucBookingTemplet2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet2.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet2.Name = "ucBookingTemplet2";
			this.ucBookingTemplet2.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet2.TabIndex = 1;
			this.ucBookingTemplet2.Week = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.ucBookingTemplet3);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(489, 460);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "星期三";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet3
			// 
			this.ucBookingTemplet3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet3.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet3.Name = "ucBookingTemplet3";
			this.ucBookingTemplet3.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet3.TabIndex = 1;
			this.ucBookingTemplet3.Week = 2;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.ucBookingTemplet4);
			this.tabPage4.Location = new System.Drawing.Point(4, 21);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(489, 460);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "星期四";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet4
			// 
			this.ucBookingTemplet4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet4.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet4.Name = "ucBookingTemplet4";
			this.ucBookingTemplet4.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet4.TabIndex = 1;
			this.ucBookingTemplet4.Week = 3;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.ucBookingTemplet5);
			this.tabPage5.Location = new System.Drawing.Point(4, 21);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(489, 460);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "星期五";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet5
			// 
			this.ucBookingTemplet5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet5.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet5.Name = "ucBookingTemplet5";
			this.ucBookingTemplet5.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet5.TabIndex = 1;
			this.ucBookingTemplet5.Week = 4;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.ucBookingTemplet6);
			this.tabPage6.Location = new System.Drawing.Point(4, 21);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(489, 460);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "星期六";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet6
			// 
			this.ucBookingTemplet6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet6.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet6.Name = "ucBookingTemplet6";
			this.ucBookingTemplet6.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet6.TabIndex = 1;
			this.ucBookingTemplet6.Week = 5;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.ucBookingTemplet7);
			this.tabPage7.Location = new System.Drawing.Point(4, 21);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(489, 460);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "星期日";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// ucBookingTemplet7
			// 
			this.ucBookingTemplet7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucBookingTemplet7.Location = new System.Drawing.Point(3, 3);
			this.ucBookingTemplet7.Name = "ucBookingTemplet7";
			this.ucBookingTemplet7.Size = new System.Drawing.Size(483, 454);
			this.ucBookingTemplet7.TabIndex = 1;
			this.ucBookingTemplet7.Week = 6;
			// 
			// ucMedTechBookingTemplet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.neuPanelRight);
			this.Controls.Add(this.neuPanelLeft);
			this.Name = "ucMedTechBookingTemplet";
			this.Size = new System.Drawing.Size(721, 485);
			this.neuPanelLeft.ResumeLayout(false);
			this.neuPanelQuery.ResumeLayout(false);
			this.neuPanelQuery.PerformLayout();
			this.neuPanelRight.ResumeLayout(false);
			this.neuTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeft;
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelQuery;
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelInputDept;
		/// <summary>
		/// 科室选择
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBoxDept;
		/// <summary>
		/// 树
		/// </summary>
		private Neusoft.HISFC.Components.Common.Controls.baseTreeView neuTreeView1;
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelRight;
		private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage7;
		private ucBookingTemplet ucBookingTemplet1;
		private ucBookingTemplet ucBookingTemplet2;
		private ucBookingTemplet ucBookingTemplet3;
		private ucBookingTemplet ucBookingTemplet4;
		private ucBookingTemplet ucBookingTemplet5;
		private ucBookingTemplet ucBookingTemplet6;
		private ucBookingTemplet ucBookingTemplet7;
		/// <summary>
		/// 查询框
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBoxQuery;
		/// <summary>
		/// 查询按钮
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButtonQuery;
	}
}
