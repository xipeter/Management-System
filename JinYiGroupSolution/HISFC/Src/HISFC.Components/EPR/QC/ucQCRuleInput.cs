using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// ucQCRuleInput 的摘要说明。
	/// </summary>
	public class ucQCRuleInput : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ListBox lst;
		private System.Windows.Forms.RichTextBox rtbMemo;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucQCRuleInput()
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
			this.lst = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rtbMemo = new System.Windows.Forms.RichTextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lst.ItemHeight = 12;
			this.lst.Location = new System.Drawing.Point(16, 16);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(240, 208);
			this.lst.TabIndex = 0;
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "规则描述：";
			// 
			// rtbMemo
			// 
			this.rtbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbMemo.Location = new System.Drawing.Point(16, 256);
			this.rtbMemo.Name = "rtbMemo";
			this.rtbMemo.Size = new System.Drawing.Size(352, 176);
			this.rtbMemo.TabIndex = 2;
			this.rtbMemo.Text = "";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAdd.Location = new System.Drawing.Point(264, 16);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(96, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "添加(&A)";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnModify
			// 
			this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnModify.Location = new System.Drawing.Point(264, 56);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(96, 23);
			this.btnModify.TabIndex = 4;
			this.btnModify.Text = "修改(&M)";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDelete.Location = new System.Drawing.Point(264, 96);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(96, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "删除(&D)";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExit.Location = new System.Drawing.Point(264, 192);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(96, 23);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "退出(&X)";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// ucQCRuleInput
			// 
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnModify);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.rtbMemo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lst);
			this.Name = "ucQCRuleInput";
			this.Size = new System.Drawing.Size(376, 440);
			this.Load += new System.EventHandler(this.ucQCRuleInput_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Exit();		
		}
		
		/// <summary>
		/// load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucQCRuleInput_Load(object sender, System.EventArgs e)
		{
			this.Retrieve();
		}

		#region IToolBar 成员

		public ToolBarButton PreButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.PreButton getter 实现
				return null;
			}
		}

		public int Search()
		{
			// TODO:  添加 ucQCRuleInput.Search 实现
			return 0;
		}

		public ToolBarButton SaveButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.SaveButton getter 实现
				return null;
			}
		}

		public ToolBarButton SearchButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.SearchButton getter 实现
				return null;
			}
		}

		public int Auditing()
		{
			// TODO:  添加 ucQCRuleInput.Auditing 实现
			return 0;
		}

		public int Del()
		{
			// TODO:  添加 ucQCRuleInput.Del 实现
			if(this.lst.SelectedIndex<0) return 0;
			if(MessageBox.Show("确认删除"+this.lst.SelectedItem.ToString()+"吗?","提示",MessageBoxButtons.OKCancel)== DialogResult.Cancel)
			{
				return 0;
			}
			Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
            
			if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteQCCondition(((Neusoft.HISFC.Models.EPR.QCConditions)this.lst.SelectedItem).ID)==-1)
			{
                Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return -1;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			this.Retrieve();
			return 0;
		}

		public ToolBarButton AddButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.AddButton getter 实现
				return null;
			}
		}

		public int Print()
		{
			// TODO:  添加 ucQCRuleInput.Print 实现
			return 0;
		}

		public int Pre()
		{
			// TODO:  添加 ucQCRuleInput.Pre 实现
			return 0;
		}

		public ToolBarButton NextButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.NextButton getter 实现
				return null;
			}
		}

		public int Help()
		{
			// TODO:  添加 ucQCRuleInput.Help 实现
			return 0;
		}

		public int Next()
		{
			// TODO:  添加 ucQCRuleInput.Next 实现
			return 0;
		}

		public int Retrieve()
		{
			// TODO:  添加 ucQCRuleInput.Retrieve 实现
			ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCConditionList();
			if(al == null)
			{
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return -1;
			}
			
			this.lst.Items.Clear();
			for(int i=0;i<al.Count;i++)
			{
				lst.Items.Add(al[i]);
			}
			return 0;
		}

		public int Add()
		{
			// TODO:  添加 ucQCRuleInput.Add 实现
			ucQCRuleSet  uc = new ucQCRuleSet(new Neusoft.HISFC.Models.EPR.QCConditions());
			uc.SelectedEvent+=new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(uc_SelectedEvent);
			Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
			return 0;
		}

		public ToolBarButton RetrieveButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.RetrieveButton getter 实现
				return null;
			}
		}

		public ToolBarButton DelButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.DelButton getter 实现
				return null;
			}
		}

		public ToolBarButton PrintButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.PrintButton getter 实现
				return null;
			}
		}

		public int Exit()
		{
			// TODO:  添加 ucQCRuleInput.Exit 实现
			this.FindForm().Close();
			return 0;
		}

		public int Save()
		{
			// TODO:  添加 ucQCRuleInput.Save 实现
			return 0;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.Add();
		}
		
	

		public ToolBarButton AuditingButton
		{
			get
			{
				// TODO:  添加 ucQCRuleInput.AuditingButton getter 实现
				return null;
			}
		}

		#endregion

		private void uc_SelectedEvent(Neusoft.FrameWork.Models.NeuObject sender)
		{
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertQCCondition((Neusoft.HISFC.Models.EPR.QCConditions)sender)==-1)
			{
                Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			this.Retrieve();
		}
		private void uc_SelectedEvent1(Neusoft.FrameWork.Models.NeuObject sender)
		{
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateQCCondition((Neusoft.HISFC.Models.EPR.QCConditions)sender)==-1)
			{
				Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			this.Retrieve();
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			if(this.lst.SelectedIndex<0) return;
			ucQCRuleSet  uc = new ucQCRuleSet((Neusoft.HISFC.Models.EPR.QCConditions)this.lst.SelectedItem);
			uc.SelectedEvent+=new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(uc_SelectedEvent1);
			Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.Del();
		}

		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.rtbMemo.Text = ((Neusoft.HISFC.Models.EPR.QCConditions)this.lst.SelectedItem).Memo;
		}
	}
}
