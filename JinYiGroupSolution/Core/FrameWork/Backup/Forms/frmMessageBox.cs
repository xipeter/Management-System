using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Forms
{
	/// <summary>
	/// frmMessageBox 的摘要说明。
	/// </summary>
	public class frmMessageBox : BaseForm
	{
		private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
		private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel linkLabel1;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton button1;
		private Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox richTextBox1;
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblMessage;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMessageBox()
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
			this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
			this.lblMessage = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.button1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.linkLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
			this.richTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lblMessage);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 152);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// lblMessage
			// 
			this.lblMessage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMessage.Location = new System.Drawing.Point(32, 24);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(216, 80);
			this.lblMessage.TabIndex = 2;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(88, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "确定(&O)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(232, 120);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(32, 16);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = ">>>";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.richTextBox1.Location = new System.Drawing.Point(0, 152);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(272, 104);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// frmMessageBox
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(274, 151);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "错误";
			this.Load += new System.EventHandler(this.frmMessageBox_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private int MaxHeight = 280;
		private int MinHeight = 174;
		private void frmMessageBox_Load(object sender, System.EventArgs e)
		{
		
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if(this.linkLabel1.Text =="<<<")
			{
				this.linkLabel1.Text = ">>>";
				this.Height = MinHeight;
			}
			else
			{
				this.linkLabel1.Text ="<<<";
				this.Height = MaxHeight ;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerMessage"></param>
		public void SetMessage(string message,string innerMessage)
		{
			if(innerMessage =="")
			{
				this.linkLabel1.Visible = false;
			}
			else
			{
				this.linkLabel1.Visible = true;
			}
			this.lblMessage.Text = message;
			this.richTextBox1.Text = innerMessage;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
