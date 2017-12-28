using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	public delegate void ParamHandler(Neusoft.HISFC.Models.File.DataFileParam obj);
	/// <summary>
	/// ucMoudulTypeSetting 的摘要说明。
	/// </summary>
	public class ucModTypeSetting : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtSysType;
		private System.Windows.Forms.TextBox txtParam;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.TextBox txtHttp;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.TextBox txtMoudual;
		private System.Windows.Forms.TextBox txtTable;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox txtMemo;
		public event ParamHandler SelectedItem;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucModTypeSetting()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtSysType = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtParam = new System.Windows.Forms.TextBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtHttp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtData = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMoudual = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTable = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtMemo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "系统类型:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSysType
			// 
			this.txtSysType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSysType.Location = new System.Drawing.Point(96, 32);
			this.txtSysType.Name = "txtSysType";
			this.txtSysType.Size = new System.Drawing.Size(136, 21);
			this.txtSysType.TabIndex = 1;
			this.txtSysType.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "参数:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtParam
			// 
			this.txtParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtParam.Location = new System.Drawing.Point(96, 68);
			this.txtParam.Name = "txtParam";
			this.txtParam.Size = new System.Drawing.Size(136, 21);
			this.txtParam.TabIndex = 3;
			this.txtParam.Text = "";
			// 
			// txtIP
			// 
			this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtIP.Location = new System.Drawing.Point(96, 104);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(136, 21);
			this.txtIP.TabIndex = 5;
			this.txtIP.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "服务器IP:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtHttp
			// 
			this.txtHttp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHttp.Location = new System.Drawing.Point(96, 140);
			this.txtHttp.Name = "txtHttp";
			this.txtHttp.Size = new System.Drawing.Size(136, 21);
			this.txtHttp.TabIndex = 7;
			this.txtHttp.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 224);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "模板路径:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtData
			// 
			this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtData.Location = new System.Drawing.Point(96, 176);
			this.txtData.Name = "txtData";
			this.txtData.Size = new System.Drawing.Size(136, 21);
			this.txtData.TabIndex = 9;
			this.txtData.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "数据路径:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMoudual
			// 
			this.txtMoudual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMoudual.Location = new System.Drawing.Point(96, 212);
			this.txtMoudual.Name = "txtMoudual";
			this.txtMoudual.Size = new System.Drawing.Size(136, 21);
			this.txtMoudual.TabIndex = 11;
			this.txtMoudual.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "Http:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Location = new System.Drawing.Point(80, 328);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "保存(&S)";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(168, 328);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(80, 24);
			this.btnExit.TabIndex = 13;
			this.btnExit.Text = "退出(&X)";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 256);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "数据表:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTable
			// 
			this.txtTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTable.Location = new System.Drawing.Point(96, 248);
			this.txtTable.Name = "txtTable";
			this.txtTable.Size = new System.Drawing.Size(136, 21);
			this.txtTable.TabIndex = 15;
			this.txtTable.Text = "";
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox1.Location = new System.Drawing.Point(8, 288);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "  存数据库中 ";
			// 
			// txtMemo
			// 
			this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMemo.Location = new System.Drawing.Point(120, 284);
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new System.Drawing.Size(112, 21);
			this.txtMemo.TabIndex = 17;
			this.txtMemo.Text = "";
			// 
			// ucModTypeSetting
			// 
			this.BackColor = System.Drawing.Color.Honeydew;
			this.Controls.Add(this.txtMemo);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.txtTable);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtMoudual);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtHttp);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtParam);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSysType);
			this.Controls.Add(this.label1);
			this.Name = "ucModTypeSetting";
			this.Size = new System.Drawing.Size(264, 368);
			this.Load += new System.EventHandler(this.ucModTypeSetting_Load);
			this.ResumeLayout(false);

		}
		#endregion
		
		protected Neusoft.HISFC.Models.File.DataFileParam datafileparam = null;

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(this.GetValue()==-1) return;

			try
			{
				SelectedItem(this.datafileparam);
			}
			catch{}
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			if(this.txtParam.Enabled)
			{
				if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertParam(this.datafileparam)==-1) 
				{
					Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
					MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
					return ;
				}
			}
			else
			{
                if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateParam(this.datafileparam) == -1)
				{
					Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
					MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
					return ;
				}
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			MessageBox.Show("保存成功！");
			this.FindForm().Close();
		}
		/// <summary>
		/// 
		/// </summary>
		public Neusoft.HISFC.Models.File.DataFileParam DataFileParam
		{
			get
			{
				return datafileparam;
			}
			set
			{
				if(value==null) return;
				datafileparam = value;
				this.SetValue();
			}
		}
		protected int GetValue()
		{
			if(this.txtParam.Text=="") 
			{
				this.txtParam.Focus();
				MessageBox.Show("请输入参数！");
				return -1;
			}
			if(this.txtData.Text=="") 
			{
				this.txtData.Focus();
				MessageBox.Show("请输入数据路径！");
					return -1;
			}
			if(this.txtMoudual.Text=="") 
			{
				this.txtMoudual.Focus();
				MessageBox.Show("请输入模板路径！");
					return -1;
			}
			if(this.txtSysType.Text=="") 
			{
				this.txtSysType.Focus();
				MessageBox.Show("请输入系统类别！");
					return -1;
			}
			if(this.txtIP.Text=="") 
			{
				this.txtIP.Focus();
				MessageBox.Show("请输入IP！");
				return -1;
			}
			datafileparam.Folders = this.txtData.Text;
			datafileparam.ModualFolders =this.txtMoudual.Text;			
			datafileparam.ID =this.txtParam.Text ;
			datafileparam.Type =this.txtSysType.Text ;
			datafileparam.Name =this.txtTable.Text ;
			datafileparam.IP = this.txtIP.Text ;
			datafileparam.Http = this.txtHttp.Text ;
			datafileparam.IsInDB = this.checkBox1.Checked;
			datafileparam.Memo = this.txtMemo.Text;
			return 0;
		}
		protected void SetValue()
		{
			if(datafileparam.ID==null || datafileparam.ID=="")
			{
				this.txtParam.Enabled = true;
			}
			else
			{
				this.txtParam.Enabled = false;
			}
			if(datafileparam.Type==null || datafileparam.Type=="")
			{
				this.txtSysType.Enabled = true;
			}
			else
			{
				this.txtSysType.Enabled = false;
			}
			this.txtData.Text = datafileparam.Folders;
			this.txtMoudual.Text = datafileparam.ModualFolders;			
			this.txtParam.Text = datafileparam.ID;
			this.txtSysType.Text = datafileparam.Type;
			this.txtTable.Text = datafileparam.Name;
			this.txtIP.Text = datafileparam.IP;
			this.txtHttp.Text = datafileparam.Http;
			this.checkBox1.Checked = datafileparam.IsInDB;
			this.txtMemo.Text =datafileparam.Memo;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.FindForm().Close();
		}

		private void ucModTypeSetting_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
