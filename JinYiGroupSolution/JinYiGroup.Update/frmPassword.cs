using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoUpdate
{
	/// <summary>
	/// frmPassword 的摘要说明。
	/// </summary>
	public class frmPassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btEnter; 
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPassword()
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btEnter = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(32, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "密码";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(80, 8);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(112, 21);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "";
			this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
			// 
			// btEnter
			// 
			this.btEnter.Location = new System.Drawing.Point(208, 8);
			this.btEnter.Name = "btEnter";
			this.btEnter.Size = new System.Drawing.Size(64, 23);
			this.btEnter.TabIndex = 2;
			this.btEnter.Text = "确定";
			this.btEnter.Click += new System.EventHandler(this.btEnter_Click);
			// 
			// frmPassword
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(290, 40);
			this.Controls.Add(this.btEnter);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "请输入密码";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPassword_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		public  bool PassWordIsRight  = false;
		int TryNum = 3;
		private void btEnter_Click(object sender, System.EventArgs e)
		{
			string strPassWord = AutoUpdate.SystemUpdate.ReadConfig("PSW");
            //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
            //string temp = Neusoft.HisDecrypt.Decrypt(strPassWord);
            //string temp = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(strPassWord,Neusoft.FrameWork.Management.Connection.DESKey);
            string temp = strPassWord;
			if(this.txtPassword.Text == temp)
			{
				PassWordIsRight = true;
				this.Visible =false; 
			}
			else 
			{
				TryNum--; 
				
				if(TryNum <= 0)
				{
					PassWordIsRight = false;
					this.Visible =false;  
				}
				else 
				{
					MessageBox.Show("密码不正确,请重新输入");
					this.Text = "您还有 " + TryNum.ToString() +" 次重试机会";
					this.txtPassword.Focus();
				}
			}
			
		}

		private void frmPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(Visible)
			{
				PassWordIsRight = false;
			}
			this.Visible = false;
		}

		private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				btEnter_Click(new object(),new EventArgs());
			}
		}
	}
}
