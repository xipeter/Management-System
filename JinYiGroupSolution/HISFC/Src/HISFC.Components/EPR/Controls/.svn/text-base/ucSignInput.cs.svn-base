using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucSignInput的摘要说明。
	/// </summary>
	public class ucSignInput : System.Windows.Forms.UserControl
	{
		
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSignName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnSelectBackGround;
		private System.Windows.Forms.Button btnDeleteBackGround;
		private System.Windows.Forms.TextBox txtDecrypt;
		private System.Windows.Forms.Button okButton;
		private object obj = null;
		private byte[] byteimg = null;
		public ucSignInput(object obj,byte[] byteimg)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.obj = obj;
			this.byteimg = byteimg;
		
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public void Set(object obj,byte[] byteimg)
		{
			curSign = obj as Neusoft.FrameWork.Models.NeuObject;
			this.txtID.Text = curSign.ID;
			this.txtName.Text = curSign.Name;
			this.txtSignName.Text = curSign.Memo;
			this.txtDecrypt.Text = curSign.User01;
			if(byteimg == null || byteimg.Length == 0) return;
			try
			{
//				System.IO.Stream stream=new System.IO.MemoryStream();
//				stream.Write(byteimg,0,byteimg.GetUpperBound(0));
//				this.pictureBox2.Image = System.Drawing.Image.FromStream(stream);
//				stream.Close();
				string fileName = Neusoft.FrameWork.WinForms.Classes.Function.GetTempFileName();
				System.IO.FileStream stream = new System.IO.FileStream(fileName,System.IO.FileMode.OpenOrCreate,System.IO.FileAccess.Write);
				stream.Write(byteimg,0,byteimg.Length);
				stream.Close();
				this.pictureBox2.Image = Image.FromFile(fileName);
				
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}
		protected override void Dispose( bool disposing )
		{
			
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucSignInput));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSignName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDecrypt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSelectBackGround = new System.Windows.Forms.Button();
			this.btnDeleteBackGround = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(44, 44);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtID);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtSignName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDecrypt);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btnSelectBackGround);
			this.groupBox1.Controls.Add(this.btnDeleteBackGround);
			this.groupBox1.Location = new System.Drawing.Point(32, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(341, 306);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(170, 202);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(96, 96);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(232, 37);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "添加新用户";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(72, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "人员编码";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(77, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "姓名";
			// 
			// txtID
			// 
			this.txtID.BackColor = System.Drawing.SystemColors.Window;
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtID.Location = new System.Drawing.Point(136, 38);
			this.txtID.MaxLength = 10;
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(88, 21);
			this.txtID.TabIndex = 1;
			this.txtID.Text = "";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(136, 76);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(176, 21);
			this.txtName.TabIndex = 4;
			this.txtName.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(76, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "签名";
			// 
			// txtSignName
			// 
			this.txtSignName.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtSignName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSignName.Location = new System.Drawing.Point(137, 108);
			this.txtSignName.MaxLength = 20;
			this.txtSignName.Name = "txtSignName";
			this.txtSignName.Size = new System.Drawing.Size(174, 21);
			this.txtSignName.TabIndex = 6;
			this.txtSignName.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(76, 145);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "加密字符串";
			// 
			// txtDecrypt
			// 
			this.txtDecrypt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtDecrypt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDecrypt.Location = new System.Drawing.Point(83, 167);
			this.txtDecrypt.MaxLength = 50;
			this.txtDecrypt.Name = "txtDecrypt";
			this.txtDecrypt.Size = new System.Drawing.Size(229, 21);
			this.txtDecrypt.TabIndex = 8;
			this.txtDecrypt.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(76, 199);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "背景";
			// 
			// btnSelectBackGround
			// 
			this.btnSelectBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectBackGround.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.btnSelectBackGround.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectBackGround.Location = new System.Drawing.Point(80, 224);
			this.btnSelectBackGround.Name = "btnSelectBackGround";
			this.btnSelectBackGround.TabIndex = 10;
			this.btnSelectBackGround.Text = "选择背景";
			this.btnSelectBackGround.Click += new System.EventHandler(this.btnSelectBackGround_Click);
			// 
			// btnDeleteBackGround
			// 
			this.btnDeleteBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteBackGround.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.btnDeleteBackGround.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteBackGround.Location = new System.Drawing.Point(79, 260);
			this.btnDeleteBackGround.Name = "btnDeleteBackGround";
			this.btnDeleteBackGround.TabIndex = 11;
			this.btnDeleteBackGround.Text = "清除背景";
			this.btnDeleteBackGround.Click += new System.EventHandler(this.btnDeleteBackGround_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(296, 336);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "取消";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okButton.Location = new System.Drawing.Point(200, 336);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "确定";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// ucSignInput
			// 
			this.BackColor = System.Drawing.Color.SeaShell;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Name = "ucSignInput";
			this.Size = new System.Drawing.Size(408, 376);
			this.Load += new System.EventHandler(this.ucSignInput_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private Neusoft.FrameWork.Models.NeuObject curSign = null;//当前权限

		private Neusoft.FrameWork.WinForms.Forms.frmEasyChoose frmShowPerson= null;//选择人员
		private void ucSignInput_Load(object sender, EventArgs e)
		{
			try
			{
                
				frmShowPerson =new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose( Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.QueryEmployeeAll());
				frmShowPerson.SelectedItem+=new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(frmShowPerson_SelectedItem);
				this.Set(this.obj, this.byteimg);
			}
			catch{}
		}

		//显示人员事件
		private void frmShowPerson_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
		{
			curSign = sender.Clone(); // as Neusoft.HISFC.Models.RADT.Person;
			this.txtID.Text = curSign.ID;
			this.txtName.Text = curSign.Name;
		}

		/// <summary>
		/// 添加新人员
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, System.EventArgs e)
		{
			frmShowPerson.ShowDialog(this.FindForm());
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.curSign = null;
			curSign = new Neusoft.FrameWork.Models.NeuObject();
			curSign.ID = this.txtID.Text;
			curSign.Name = this.txtName.Text;
			curSign.Memo = this.txtSignName.Text;
			curSign.User01 = this.txtDecrypt.Text;
			curSign.User02 = Neusoft.FrameWork.Management.Connection.Operator.ID;
			curSign.User03 = System.DateTime.Now.ToLongDateString();
			this.pictureBox2.Image.Save("c:\\11.bmp");
			System.IO.FileStream stream = new System.IO.FileStream("c:\\11.bmp",System.IO.FileMode.Open);
			byte[] byteimg =new byte[stream.Length];
			stream.Read(byteimg,0, (int)stream.Length);
			stream.Close();
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SetSign(this.curSign, byteimg)==-1)
			{
				Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			MessageBox.Show("保存成功！");
			this.FindForm().DialogResult  = DialogResult.OK;
			this.FindForm().Close();
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.FindForm().DialogResult  = DialogResult.Cancel;
			this.FindForm().Close();
		}

		private void btnSelectBackGround_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "(*.bmp)|*.bmp|(*.jpg)|*.jpg|(*.gif)|*.gif|All files (*.*)|*.*";
			dlg.Multiselect = false;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				string filename = dlg.FileName;
				System.Drawing.Image image = System.Drawing.Image.FromFile(filename);
				this.pictureBox2.Image = image;
			}

		}

		private void btnDeleteBackGround_Click(object sender, System.EventArgs e)
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucSignInput));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
		}
	}
}
