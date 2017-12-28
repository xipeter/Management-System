using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Query
{
	/// <summary>
	/// frmDeleteCondition 的摘要说明。
	/// </summary>
	public class frmDeleteCondition : System.Windows.Forms.Form
	{
		#region 变量
		private int _ConditionCount;
		private int _height = 20;
		#endregion 变量

		#region 属性
		public string deleteConditions
		{
			get
			{
				string delcon = "";
				for(int i = 0; i < _ConditionCount; i++)
				{
					CheckBox chkCondition = (CheckBox)grpCondition.Controls[i];
					delcon += chkCondition.Checked.ToString() + ";";
				}
				delcon = delcon.TrimEnd(';');

				return delcon;
			}
		}
		#endregion 属性

		private System.Windows.Forms.GroupBox grpCondition;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="conditionCount"></param>
		public frmDeleteCondition(int conditionCount)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			this._ConditionCount = conditionCount;
			AddControl();
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
			this.grpCondition = new System.Windows.Forms.GroupBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// grpCondition
			// 
			this.grpCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.grpCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.grpCondition.Location = new System.Drawing.Point(-4, 6);
			this.grpCondition.Name = "grpCondition";
			this.grpCondition.Size = new System.Drawing.Size(218, 60);
			this.grpCondition.TabIndex = 1;
			this.grpCondition.TabStop = false;
			this.grpCondition.Text = " 选定要删除的条件";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(64, 34);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(64, 22);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "确定";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 34);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 22);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmDeleteCondition
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(208, 63);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.grpCondition);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmDeleteCondition";
			this.Text = "删除查询条件";
			this.ResumeLayout(false);

		}
		#endregion

		#region 方法
		/// <summary>
		/// 添加控件
		/// </summary>
		private void AddControl()
		{
			for(int i = 0; i < _ConditionCount; i++)
			{
				CheckBox chkCondition = new CheckBox();
				chkCondition.Name = "Condition" + (i+1).ToString();
				chkCondition.Location = new Point(24, 18 + i * _height);
				chkCondition.Size = new Size(152, _height - 2);
				chkCondition.Text = "条件" + (i+1).ToString() + "(&" + (i+1).ToString() + ")";
				this.grpCondition.Controls.Add(chkCondition);
			}
			this.Height = 82 + _ConditionCount * _height;
		}
		#endregion

		#region 事件
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		#endregion 事件

	}
}
