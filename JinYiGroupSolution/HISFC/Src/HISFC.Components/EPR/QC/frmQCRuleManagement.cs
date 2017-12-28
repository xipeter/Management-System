using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// frmQCRuleManagement 的摘要说明。
	/// </summary>
	public class frmQCRuleManagement : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmQCRuleManagement()
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
			// 
			// frmQCRuleManagement
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 469);
			this.Name = "frmQCRuleManagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "质控规则管理";
			this.Load += new System.EventHandler(this.frmQCRuleManagement_Load);

		}
		#endregion

		private void frmQCRuleManagement_Load(object sender, System.EventArgs e)
		{
			ucQCRuleInput uc = new ucQCRuleInput();
			uc.Visible = true;
			this.Controls.Add(uc);
			uc.Dock = DockStyle.Fill;
		}
	}
}
