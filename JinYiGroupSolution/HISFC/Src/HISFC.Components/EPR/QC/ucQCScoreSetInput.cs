using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucQCScoreSetInput的摘要说明。
	/// </summary>
	public class ucQCScoreSetInput : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TextBox txtMemo;
		private System.Windows.Forms.TextBox txtMiniScore;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTotalScore;
		private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboType;
		private object obj = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		public ucQCScoreSetInput(object obj)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.obj = obj;
		
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
        Neusoft.HISFC.Models.EPR.QCScore curQCScoreSet = null;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		public void Set(object obj)
		{
			curQCScoreSet = obj as Neusoft.HISFC.Models.EPR.QCScore;
			this.txtID.Text = curQCScoreSet.ID;
			this.txtName.Text = curQCScoreSet.Name;
			this.cboType.Text = curQCScoreSet.Type;
			this.txtMemo.Text = curQCScoreSet.Memo;
			this.txtMiniScore.Text = curQCScoreSet.MiniScore;
			this.txtTotalScore.Text = curQCScoreSet.TotalScore;
			ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCName();
			if(al == null) return;
			this.cboType.AddItems(al);
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucQCScoreSetInput));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMemo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMiniScore = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTotalScore = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboType);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtID);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtMemo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtMiniScore);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtTotalScore);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Location = new System.Drawing.Point(32, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(341, 240);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// cboType
			// 
			this.cboType.ArrowBackColor = System.Drawing.Color.Silver;
			this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboType.IsFlat = false;
			this.cboType.IsLike = true;
			this.cboType.Location = new System.Drawing.Point(144, 104);
			this.cboType.Name = "cboType";
			this.cboType.PopForm = null;
			this.cboType.ShowCustomerList = false;
			this.cboType.ShowID = false;
			this.cboType.Size = new System.Drawing.Size(168, 22);
			this.cboType.TabIndex = 6;
			this.cboType.Tag = "";
			this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(261, 38);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 24);
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
			this.label1.Text = "条件编码";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(72, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "质控名称";
			// 
			// txtID
			// 
			this.txtID.BackColor = System.Drawing.SystemColors.Window;
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtID.Location = new System.Drawing.Point(144, 38);
			this.txtID.MaxLength = 10;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(109, 21);
			this.txtID.TabIndex = 1;
			this.txtID.Text = "";
			// 
			// txtName
			// 
			this.txtName.AcceptsTab = true;
			this.txtName.BackColor = System.Drawing.SystemColors.Window;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(144, 72);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(168, 21);
			this.txtName.TabIndex = 4;
			this.txtName.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(72, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "项目类别";
			// 
			// txtMemo
			// 
			this.txtMemo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMemo.Location = new System.Drawing.Point(144, 136);
			this.txtMemo.MaxLength = 20;
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new System.Drawing.Size(168, 21);
			this.txtMemo.TabIndex = 8;
			this.txtMemo.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(72, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "扣分标准";
			// 
			// txtMiniScore
			// 
			this.txtMiniScore.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtMiniScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMiniScore.Location = new System.Drawing.Point(144, 168);
			this.txtMiniScore.MaxLength = 50;
			this.txtMiniScore.Name = "txtMiniScore";
			this.txtMiniScore.Size = new System.Drawing.Size(168, 21);
			this.txtMiniScore.TabIndex = 10;
			this.txtMiniScore.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(72, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "备注";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(72, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 17);
			this.label6.TabIndex = 11;
			this.label6.Text = "项目总分值";
			// 
			// txtTotalScore
			// 
			this.txtTotalScore.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtTotalScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTotalScore.Location = new System.Drawing.Point(144, 200);
			this.txtTotalScore.MaxLength = 50;
			this.txtTotalScore.Name = "txtTotalScore";
			this.txtTotalScore.Size = new System.Drawing.Size(168, 21);
			this.txtTotalScore.TabIndex = 12;
			this.txtTotalScore.Text = "";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(296, 272);
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
			this.okButton.Location = new System.Drawing.Point(200, 272);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "确定";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(19, 33);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(44, 44);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// ucQCScoreSetInput
			// 
			this.BackColor = System.Drawing.Color.SeaShell;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Name = "ucQCScoreSetInput";
			this.Size = new System.Drawing.Size(408, 312);
			this.Load += new System.EventHandler(this.ucQCScoreSetInput_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		//private Neusoft.HISFC.Models.EPR.QCScore curQCScoreSet = null;//当前权限

		private Neusoft.FrameWork.WinForms.Forms.frmEasyChoose frmShowPerson= null;//选择人员
		private void ucQCScoreSetInput_Load(object sender, EventArgs e)
		{
			try
			{
				frmShowPerson =new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCConditionList());
                frmShowPerson.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(frmShowPerson_SelectedItem);
				this.Set(this.obj);
			}
			catch{}
		}

		//显示人员事件
		private void frmShowPerson_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
		{
			this.txtID.Text = ((Neusoft.FrameWork.Models.NeuObject)sender).ID;
			this.txtName.Text = ((Neusoft.FrameWork.Models.NeuObject)sender).Name;
		}

		/// <summary>
		/// 添加新人员
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, System.EventArgs e)
		{
			if(frmShowPerson.ShowDialog(this.FindForm())==DialogResult.OK)
			{
				
			}
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.curQCScoreSet = null;
			curQCScoreSet = new Neusoft.HISFC.Models.EPR.QCScore();
			curQCScoreSet.ID = this.txtID.Text;
			curQCScoreSet.Name = this.txtName.Text;
			curQCScoreSet.Type = this.cboType.Text;
			curQCScoreSet.Memo = this.txtMemo.Text;
			curQCScoreSet.MiniScore = this.txtMiniScore.Text;
			curQCScoreSet.TotalScore = this.txtTotalScore.Text;
			curQCScoreSet.User02 = Neusoft.FrameWork.Management.Connection.Operator.ID;
			curQCScoreSet.User03 = System.DateTime.Now.ToLongDateString();

			Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

            if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SetQCScoreSet(this.curQCScoreSet) == -1)
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

		private void cboType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtTotalScore.Text = "0";
		}
	}
}
