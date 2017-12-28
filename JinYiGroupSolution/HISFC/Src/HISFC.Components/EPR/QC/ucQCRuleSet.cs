using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// ucRuleSet 的摘要说明。
	/// </summary>
	public class ucQCRuleSet : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler SelectedEvent;
		public ucQCRuleSet(Neusoft.HISFC.Models.EPR.QCConditions conditions)
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			
			this.conditions = conditions;
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
			this.chk2 = new System.Windows.Forms.CheckedListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.btnDelRule = new System.Windows.Forms.Button();
			this.chk1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "1、选择规则条件：";
			// 
			// chk2
			// 
			this.chk2.Items.AddRange(new object[] {
													  "使提示 \'信息\'",
													  "使模板 \'只读\'"});
			this.chk2.Location = new System.Drawing.Point(13, 156);
			this.chk2.Name = "chk2";
			this.chk2.Size = new System.Drawing.Size(232, 68);
			this.chk2.TabIndex = 3;
			this.chk2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chk2_ItemCheck);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "2、选择规则操作：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(224, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "3、规则描述：";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(13, 348);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(224, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "4、规则名称：";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(13, 372);
			this.txtName.MaxLength = 40;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(396, 21);
			this.txtName.TabIndex = 7;
			this.txtName.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(315, 409);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(96, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Location = new System.Drawing.Point(211, 409);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(96, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "确定(&O)";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(248, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "模板列表:";
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(248, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(162, 88);
			this.listBox1.TabIndex = 12;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// listBox2
			// 
			this.listBox2.ItemHeight = 12;
			this.listBox2.Location = new System.Drawing.Point(253, 157);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(156, 64);
			this.listBox2.TabIndex = 13;
			this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(249, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "信息列表:";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(15, 256);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(393, 89);
			this.richTextBox1.TabIndex = 15;
			this.richTextBox1.Text = "";
			// 
			// btnDelRule
			// 
			this.btnDelRule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDelRule.Location = new System.Drawing.Point(108, 409);
			this.btnDelRule.Name = "btnDelRule";
			this.btnDelRule.Size = new System.Drawing.Size(96, 23);
			this.btnDelRule.TabIndex = 16;
			this.btnDelRule.Text = "删除规则...";
			this.btnDelRule.Click += new System.EventHandler(this.btnDelRule_Click);
			// 
			// chk1
			// 
			this.chk1.ItemHeight = 12;
			this.chk1.Items.AddRange(new object[] {
													  "若输入 \'信息\'，符合\'条件\'",
													  "若HIS\'信息\'，符合\'条件\'",
													  "若病历 \'名称\'，已经\'建立\'",
													  "若病历-\'名称\'，已经\'签名\'",
													  "若病历+\'名称\'，建立时间,不在\'时间\'内",
													  "若病历*\'名称\',空\'N\'项",
													  "若控件 \'名称\'，符合\'条件\'"});
			this.chk1.Location = new System.Drawing.Point(8, 32);
			this.chk1.Name = "chk1";
			this.chk1.Size = new System.Drawing.Size(235, 88);
			this.chk1.TabIndex = 17;
			this.chk1.DoubleClick += new System.EventHandler(this.chk1_DoubleClick);
			// 
			// ucQCRuleSet
			// 
			this.Controls.Add(this.chk1);
			this.Controls.Add(this.btnDelRule);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chk2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ucQCRuleSet";
			this.Size = new System.Drawing.Size(420, 438);
			this.Load += new System.EventHandler(this.ucRuleSet_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox chk2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnDelRule;
		private System.Windows.Forms.ListBox chk1;

		protected Neusoft.HISFC.Models.EPR.QCConditions conditions = null;

		private void ucRuleSet_Load(object sender, System.EventArgs e)
		{
			this.richTextBox1.Text = Condition +"\n"+Action+"\n"+END;
			SetValue();
			this._protectedText(true);
			first = false;
			this.Init();
		}

		
		#region 初始化
		/// <summary>
		/// 初始化
		/// </summary>
		protected void Init()
		{
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCName();
			if(al==null) 
			{
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return;
			}
			this.listBox1.Items.Clear();
			for(int i=0;i<al.Count;i++)
			{
				this.listBox1.Items.Add(al[i]);
			}
			try
			{
				Neusoft.FrameWork.Management.Interface ISql=new Neusoft.FrameWork.Management.Interface();
				string fileName = TemplateDesignerHost.Function.SystemPath  +"PATIENTINFO.xml";
				ISql.ReadXML(fileName);
			
				this.listBox2.Items.Clear();
	
				for(int i=0;i<ISql.Count;i++)
				{
					if(ISql.GetInfo(i).showType =="1")
					{
						this.listBox2.Items.Add(ISql.GetInfo(i));
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region  常数及变量
		protected const string Action ="《动作》";
		protected const string Condition = "《条件》";
		protected const string END = "《END》";
		bool first = true;
		#endregion

		#region 函数
		public void Save()
		{
			this.GetValue();
			try
			{
				SelectedEvent(this.conditions);
				this.FindForm().Close();
			}
			catch{}
		}
		/// <summary>
		/// 设置质控数值
		/// </summary>
		private void SetValue()
		{
			if(this.conditions.Name =="") this.conditions.Name ="新建质控规则名称";
			this.txtName.Text = this.conditions.Name;
			if(this.conditions.Memo!="") this.richTextBox1.Text = this.conditions.Memo;
//			foreach(Neusoft.HISFC.Models.EMR.QCCondition c in this.conditions.AlConditions)
//			{
//				for(int i=0;i<this.chk1.Items.Count -1;i++)
//				{
//					if(this.chk1.Items[i].ToString().Substring(0,4)==c.Name.Substring(0,4))
//					{
//						this.chk1.SetItemChecked(i,true);
//						break;
//					}
//				}
//			}
			foreach(Neusoft.FrameWork.Models.NeuObject c in this.conditions.Acion.AlMessage)
			{
				try
				{
					this.chk2.SetItemChecked(int.Parse(c.ID),true);
				}
				catch{}
			}

		}
		/// <summary>
		/// 获得质控数值
		/// </summary>
		private void GetValue()
		{
			this.conditions.Name = this.txtName.Text;
			this.conditions.Memo = this.richTextBox1.Text; 
			int i1 =0,i2 =0;
			i1 = this.richTextBox1.Find(Action);
			this.conditions.Conditions = this.richTextBox1.Text.Substring(Condition.Length+1,i1-Condition.Length-1);
			i2 = this.richTextBox1.Find(END);
			this.conditions.Acion.Name = this.richTextBox1.Text.Substring(i1 +Action.Length+1,i2-i1-Action.Length-1);
		}

		private void _SetText(string sText,int iType,bool bAdd,int iSelect)
		{
			int iPosition = 0;
			string sType = "";
			this._protectedText(false);
			switch(iType)
			{
				case 1://条件
					sType = Action;
					break;
				case 2://动作
					sType = END;
					break;
				default://不认识
					return;
			}
			if(bAdd) //添加
			{
				iPosition = _findText(sType);
				this.richTextBox1.Select(iPosition,0);
				this.richTextBox1.SelectedText = "    "+sText+"\n";
			}
			else
			{
				_delClause(iType,iSelect);
			}
			this._protectedText(true);
		}
		private int _findText(string s)
		{
			try
			{
				int i =this.richTextBox1.Find(s);
				if(i<0) return 0;
				return i;

			}
			catch{return 0;}
		}
		/// <summary>
		/// 删除语句
		/// </summary>
		/// <param name="iType"></param>
		/// <param name="i"></param>
		private void _delClause(int iType,int i)
		{
			string s;
			int iPosition =0;
			int iEnd =0 ,index =0;
			if(iType ==1)
			{
				s = this.chk1.Items[i].ToString().Substring(0,4);
				
			}
			else
			{
				s = this.chk2.Items[i].ToString().Substring(0,4);
			}
			iPosition = _findText("    "+s);
			iEnd = iPosition;
			for(index = 0;index<4;index++)
			{
				iEnd = this.richTextBox1.Find("'",iEnd+1,RichTextBoxFinds.MatchCase);
			}
			this.richTextBox1.Select(iPosition - 1,iEnd+2 - iPosition);
			this.richTextBox1.SelectedText = "";
		}
		
		private void _protectedText(bool b)
		{
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionProtected = b;
			if(b)
			{
				int i =0;
				int iPosition_start = 1,iPosition_end =0;
				while(iPosition_start>0)
				{
					iPosition_start = this.richTextBox1.Find("'",i,RichTextBoxFinds.MatchCase);
					iPosition_end = this.richTextBox1.Find("'",iPosition_start + 1,RichTextBoxFinds.MatchCase);
					i = iPosition_end +1;
					if(iPosition_start >=0)
					{
						this.richTextBox1.Select(iPosition_start + 1,iPosition_end - iPosition_start -1);
						this.richTextBox1.SelectionProtected = false;
						this.richTextBox1.SelectionColor = Color.Blue;
					}
				}
			}
		}

		private void chk1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(first) return;
			int i = ((CheckedListBox)sender).SelectedIndex ;
			if(i<0) return;
			_SetText(((CheckedListBox)sender).Items[i].ToString(),1,!((CheckedListBox)sender).GetItemChecked(i),i);
		}

		private void chk2_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(first) return;
			int i = ((CheckedListBox)sender).SelectedIndex ;
			if(i<0) return;
			_SetText(((CheckedListBox)sender).Items[i].ToString(),2,!((CheckedListBox)sender).GetItemChecked(i),i);
		}
		#endregion
		
		#region 
		/// <summary>
		/// 确定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Save();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.FindForm().Close();
		}
		#endregion

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			this.richTextBox1.SelectedText = ((Control)sender).Text;
		}
		private void listBox2_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				this.richTextBox1.SelectedText = ((Neusoft.FrameWork.Models.NeuInfo)((ListBox)sender).SelectedItem).ID;
			}
			catch{}
		}
		//添加规则
		private void chk1_DoubleClick(object sender, System.EventArgs e)
		{
			int i = ((ListBox)sender).SelectedIndex ;
			if(i<0) return;
			_SetText(((ListBox)sender).Items[i].ToString(),1,true,i);
		}

		private void btnDelRule_Click(object sender, System.EventArgs e)
		{
			this.GetValue();
			frmRemoveRule f = new frmRemoveRule( conditions.AlConditions );
			if(f.ShowDialog()==DialogResult.OK)
			{
				this.conditions.Conditions  = f.Rule;
				this.richTextBox1.Text = Condition +f.Rule+"\n"+Action+"\n"+END;
				this._protectedText(true);
			}
		}
	}
}
