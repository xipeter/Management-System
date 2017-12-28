using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Forms
{
	/// <summary>
	/// frmTip 的摘要说明。
	/// </summary>
	public class frmTip : BaseForm
	{
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public frmTip()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTip));
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
          
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 29);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.label1.TabIndex = 0;
            this.label1.Text = "当前为设计模式(工具在任务栏里)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTip
            // 
            this.ClientSize = new System.Drawing.Size(280, 29);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmTip";
            this.Opacity = 0.8;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		public string TipText
		{
			set
			{
				this.label1.Text = value;
			}
		}
		/// <summary>
		/// 启动
		/// 按秒来设置显示时间
		/// </summary>
		/// <param name="time"></param>
		public void Run(int time,Color foreColor,Color backColor,double opacity)
		{
			this.label1.ForeColor = foreColor;
			this.label1.BackColor = backColor;
			this.Opacity = opacity;
			this.timer1.Interval = time *1000;
			this.timer1.Enabled = true;
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
	}
}
