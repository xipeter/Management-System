using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// frmQCScore 的摘要说明。
	/// </summary>
	public class frmQCScore : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
		private Neusoft.HISFC.Components.EPR.QC.ucQCScore ucQCScore1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolBarButton tbAuto;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblPatientName;
		private System.ComponentModel.IContainer components;

		public frmQCScore()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmQCScore));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbAuto = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbExit = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucQCScore1 = new Neusoft.HISFC.Components.EPR.QC.ucQCScore();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblScore = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblPatientName = new System.Windows.Forms.Label();
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.tbAuto,
																						this.toolBarButton3,
																						this.tbExit});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(744, 41);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbAuto
			// 
			this.tbAuto.ImageIndex = 0;
			this.tbAuto.Text = "评分";
			this.tbAuto.ToolTipText = "自动评分";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbExit
			// 
			this.tbExit.ImageIndex = 1;
			this.tbExit.Text = "退出";
			this.tbExit.ToolTipText = "退出";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(744, 468);
			this.panel1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tabControl1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(195, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(549, 468);
			this.panel3.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(549, 468);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ucQCScore1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(541, 443);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "评分";
			// 
			// ucQCScore1
			// 
			this.ucQCScore1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucQCScore1.Location = new System.Drawing.Point(0, 0);
			this.ucQCScore1.Name = "ucQCScore1";
			this.ucQCScore1.PatientInfo = null;
			this.ucQCScore1.Size = new System.Drawing.Size(541, 443);
			this.ucQCScore1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(541, 442);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "病历";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(192, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 468);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Honeydew;
			this.panel2.Controls.Add(this.lblLevel);
			this.panel2.Controls.Add(this.lblScore);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.lblPatientName);
			this.panel2.Controls.Add(this.ucQueryInpatientNo1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(192, 468);
			this.panel2.TabIndex = 0;
			// 
			// lblLevel
			// 
			this.lblLevel.Location = new System.Drawing.Point(64, 152);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(96, 23);
			this.lblLevel.TabIndex = 18;
			// 
			// lblScore
			// 
			this.lblScore.Location = new System.Drawing.Point(64, 112);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(96, 23);
			this.lblScore.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "等级：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "分数：";
			// 
			// lblPatientName
			// 
			this.lblPatientName.Location = new System.Drawing.Point(16, 56);
			this.lblPatientName.Name = "lblPatientName";
			this.lblPatientName.Size = new System.Drawing.Size(160, 24);
			this.lblPatientName.TabIndex = 14;
			this.lblPatientName.Text = "患者姓名：";
			// 
			// ucQueryInpatientNo1
			// 
			this.ucQueryInpatientNo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ucQueryInpatientNo1.InputType = 0;
			this.ucQueryInpatientNo1.Location = new System.Drawing.Point(16, 16);
			this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
			this.ucQueryInpatientNo1.ShowState = Common.Controls.enuShowState.All;
			this.ucQueryInpatientNo1.Size = new System.Drawing.Size(162, 27);
			this.ucQueryInpatientNo1.TabIndex = 13;
			this.ucQueryInpatientNo1.myEvent += new Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
			// 
			// frmQCScore
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(744, 509);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Name = "frmQCScore";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "质控评分";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmQCScore_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();

		private void ucQueryInpatientNo1_myEvent()
		{
			//查询到患者
			if(this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo.Trim()=="") return;
            this.ucQCScore1.PatientInfo = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo);
			this.lblPatientName.Text = "患者姓名："+this.ucQCScore1.PatientInfo.Name;
			this.lblLevel.Text = this.ucQCScore1.GetLevel();
			this.lblScore.Text = this.ucQCScore1.GetScore().ToString();
			this.tabPage2.Controls.Clear();
			Common.Classes.Function.EMRShow(this.tabPage2,this.ucQCScore1.PatientInfo ,"0",false);
		}

		private void frmQCScore_Load(object sender, System.EventArgs e)
		{
			this.ucQCScore1.OnScoreChanged+=new EventHandler(ucQCScore1_OnScoreChanged);
		}

		private void ucQCScore1_OnScoreChanged(object sender, EventArgs e)
		{
			this.lblLevel.Text = this.ucQCScore1.GetLevel();
			this.lblScore.Text = this.ucQCScore1.GetScore().ToString();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbAuto)
			{
				this.ucQCScore1.Auto();
			}
			else if(e.Button == this.tbExit)
			{
				this.Close();
			}
		}
	}
}
