using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// frmRemoveRule 的摘要说明。
	/// </summary>
	public class frmRemoveRule : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private ArrayList al;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRemoveRule(ArrayList  alConditions)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.al = alConditions;
			this.checkedListBox1.Items.Clear();
			for(int i=0;i<alConditions.Count;i++)
			{
				this.checkedListBox1.Items.Add(((Neusoft.HISFC.Models.EPR.QCCondition)alConditions[i]).ToString());
				this.checkedListBox1.SetSelected(i,true);//设置为true
			}
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
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Location = new System.Drawing.Point(0, 8);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(288, 212);
			this.checkedListBox1.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Location = new System.Drawing.Point(120, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(208, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmRemoveRule
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 261);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.checkedListBox1);
			this.MaximizeBox = false;
			this.Name = "frmRemoveRule";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "删除规则";
			this.Load += new System.EventHandler(this.frmRemoveRule_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRemoveRule_Load(object sender, System.EventArgs e)
		{
		
		}
		private string sReturn = "";
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
//			for(int i=checkedListBox1.Items.Count -1;i>=0;i--)
//			{
//				if(this.checkedListBox1.GetSelected(i))
//				{
//				}
//				else
//				{
//					this.al.RemoveAt(i);
//				}
//			}
			for(int i=0;i<this.checkedListBox1.Items.Count;i++)
			{
				if(this.checkedListBox1.GetItemChecked(i)==false)
				{
					sReturn = sReturn + "\n" + "    "+this.checkedListBox1.Items[i].ToString();
				}
			}
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// 获得设置完的规则
		/// </summary>
		public string Rule
		{
			get
			{
				return this.sReturn;
			}
		}
	}
}
