using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Xml;
namespace AutoUpdate
{
	/// <summary>
	/// Waiting 的摘要说明。
	/// </summary>
	public class Waiting : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Waiting()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Waiting));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTip = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(80, 44);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(208, 8);
			this.progressBar1.TabIndex = 6;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(56, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// lblTip
			// 
			this.lblTip.ForeColor = System.Drawing.Color.Blue;
			this.lblTip.Location = new System.Drawing.Point(88, 20);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(208, 16);
			this.lblTip.TabIndex = 4;
			this.lblTip.Text = "正在检查最新版本...";
			// 
			// Waiting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 64);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblTip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Waiting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Waiting";
			this.ResumeLayout(false);

		}
		#endregion
		public System.Windows.Forms.ProgressBar progressBar1;
		public System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.Label lblTip;
	}
}
