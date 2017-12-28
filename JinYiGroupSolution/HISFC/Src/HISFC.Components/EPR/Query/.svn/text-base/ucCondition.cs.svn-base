using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Query
{
	/// <summary>
	/// 查询条件类
	/// 用于输入查询条件
	/// </summary>
	[DefaultProperty("index"),DefaultEvent("RelationOperatorSelectedIndexChanged")]
	public class ucCondition : System.Windows.Forms.UserControl
	{
//		public event System.EventHandler SelectTree;
		[Category("Action"),Description("在关系运算符改变时发生")]
		public event System.EventHandler RelationOperatorSelectedIndexChanged;

		private ArrayList arrRelationOperator;
		private ArrayList arrCompareOperator;
		private bool IsAddValue = false;
		private System.Windows.Forms.GroupBox grpCondition;
		private System.Windows.Forms.Button btnSearchTree;
		private System.Windows.Forms.TextBox txtTree;
		private System.Windows.Forms.TextBox txtCompareText;
		private System.Windows.Forms.ComboBox cboCompareOperator;
		private System.Windows.Forms.ComboBox cboRelationOperator;

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucCondition()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			initCompareOperatorItems();
			initRelationOperatorItems();
			AddCompareOperatorItems();
			AddRelationOperatorItems();


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
			this.grpCondition = new System.Windows.Forms.GroupBox();
			this.cboRelationOperator = new System.Windows.Forms.ComboBox();
			this.cboCompareOperator = new System.Windows.Forms.ComboBox();
			this.txtCompareText = new System.Windows.Forms.TextBox();
			this.txtTree = new System.Windows.Forms.TextBox();
			this.btnSearchTree = new System.Windows.Forms.Button();
			this.grpCondition.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCondition
			// 
			this.grpCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpCondition.Controls.Add(this.cboRelationOperator);
			this.grpCondition.Controls.Add(this.cboCompareOperator);
			this.grpCondition.Controls.Add(this.txtCompareText);
			this.grpCondition.Controls.Add(this.txtTree);
			this.grpCondition.Controls.Add(this.btnSearchTree);
			this.grpCondition.Location = new System.Drawing.Point(0, 2);
			this.grpCondition.Name = "grpCondition";
			this.grpCondition.Size = new System.Drawing.Size(552, 44);
			this.grpCondition.TabIndex = 0;
			this.grpCondition.TabStop = false;
			this.grpCondition.Text = "查询条件";
			// 
			// cboRelationOperator
			// 
			this.cboRelationOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboRelationOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRelationOperator.Items.AddRange(new object[] {
																	 "或者"});
			this.cboRelationOperator.Location = new System.Drawing.Point(464, 16);
			this.cboRelationOperator.Name = "cboRelationOperator";
			this.cboRelationOperator.Size = new System.Drawing.Size(80, 20);
			this.cboRelationOperator.TabIndex = 4;
			this.cboRelationOperator.SelectedIndexChanged += new System.EventHandler(this.cboRelationOperator_SelectedIndexChanged);
			// 
			// cboCompareOperator
			// 
			this.cboCompareOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboCompareOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCompareOperator.Items.AddRange(new object[] {
																	"包含",
																	"不包含",
																	"等于",
																	"不等于",
																	"大于",
																	"小于",
																	"大于或等于",
																	"小于或等于"});
			this.cboCompareOperator.Location = new System.Drawing.Point(208, 16);
			this.cboCompareOperator.Name = "cboCompareOperator";
			this.cboCompareOperator.Size = new System.Drawing.Size(88, 20);
			this.cboCompareOperator.TabIndex = 2;
			// 
			// txtCompareText
			// 
			this.txtCompareText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCompareText.Location = new System.Drawing.Point(304, 16);
			this.txtCompareText.Name = "txtCompareText";
			this.txtCompareText.Size = new System.Drawing.Size(152, 21);
			this.txtCompareText.TabIndex = 3;
			this.txtCompareText.Text = "";
			// 
			// txtTree
			// 
			this.txtTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTree.Location = new System.Drawing.Point(8, 16);
			this.txtTree.Name = "txtTree";
			this.txtTree.Size = new System.Drawing.Size(152, 21);
			this.txtTree.TabIndex = 0;
			this.txtTree.Text = "";
			// 
			// btnSearchTree
			// 
			this.btnSearchTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearchTree.Location = new System.Drawing.Point(168, 16);
			this.btnSearchTree.Name = "btnSearchTree";
			this.btnSearchTree.Size = new System.Drawing.Size(32, 21);
			this.btnSearchTree.TabIndex = 1;
			this.btnSearchTree.Text = "...";
			this.btnSearchTree.Click += new System.EventHandler(this.btnSearchTree_Click);
			// 
			// ucCondition
			// 
			this.Controls.Add(this.grpCondition);
			this.Name = "ucCondition";
			this.Size = new System.Drawing.Size(552, 50);
			this.grpCondition.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 属性

		/// <summary>
		/// 从0开始的条件索引
		/// </summary>
		[Category("Design"),Description("从0开始的条件索引")]
		public int Index
		{
			set
			{
				string str;
				if(value < -1)
				{
					value = -1;
					return;
				}
				str = (value + 1).ToString();

				grpCondition.Text = "查询条件" + str + "(&" + str + ")";
			}
			get
			{
				int i = 0;
				int len = this.grpCondition.Text.Length;
				if(len > 7)
				{
					i = int.Parse(this.grpCondition.Text.Substring(4, (int)(len - 7) / 2));
				}

				return --i;
			}
		}

		/// <summary>
		/// 比较运算符项目
		/// </summary>
		[Description("比较运算符项目")]
		public ArrayList CompareOperatorItems
		{
			set
			{
				AddCompareOperatorItems(value);
			}
		}

		/// <summary>
		/// 关系运算符项目
		/// </summary>
		[Description("关系运算符项目")]
		public ArrayList RelationOperatorItems
		{
			set
			{
				AddRelationOperatorItems(value);
			}
		}

		/// <summary>
		/// 包含初始条件值的节点
		/// </summary>
		[Description("包含初始条件值的节点")]
		public System.Xml.XmlNode Node
		{
			set
			{
				this.IsAddValue = true;
				AddNodeValueToConditionGroup(value);
				this.IsAddValue = false;
			}
		}


		/// <summary>
		/// 是否允许添加新查询条件
		/// </summary>
		[Category("Behavior"),Description("是否允许添加新查询条件")]
		public bool AllowNewCondition
		{
			get
			{
				return this.cboRelationOperator.Enabled;
			}
			set
			{
				this.cboRelationOperator.Enabled = value;
			}
		}

		/// <summary>
		/// 查询字段
		/// </summary>
		[Description("查询字段"),Browsable(false)]
		public string Field
		{
			get 
			{
				return this.txtTree.Text;
			}
		}

		/// <summary>
		/// 比较运算符
		/// </summary>
		[Description("比较运算符"),Browsable(false)]
		public string CompareOperator
		{
			get
			{
				if(this.cboCompareOperator.SelectedIndex == -1)
				{
					return "";
				}
				else
				{
					return this.cboCompareOperator.SelectedValue.ToString();
				}
			}
		}


		/// <summary>
		/// 比较内容1
		/// </summary>
		[Description("比较内容1"),Browsable(false)]
		public string CompareContext1
		{
			get
			{
				return this.txtCompareText.Text;
			}
		}

		/// <summary>
		/// 比较内容2
		/// </summary>
		[Description("比较内容2"),Browsable(false)]
		public string CompareContext2
		{
			get
			{
				return "";
			}
		}

		/// <summary>
		/// 关系运算符
		/// </summary>
		[Description("关系运算符"),Browsable(false)]
		public string RelationOperator
		{
			get
			{
				if(this.cboRelationOperator.SelectedIndex == -1)
				{
					return "";
				}
				else
				{
					return this.cboRelationOperator.SelectedValue.ToString();
				}
			}
		}
		#endregion 属性

		#region 方法

		/// <summary>
		/// 方法，将节点值放到条件控件内
		/// </summary>
		/// <param name="node"></param>
		private void AddNodeValueToConditionGroup(System.Xml.XmlNode node)
		{
			if(node == null) return;
			if(node.Attributes["Tree"] != null)
			{
				this.txtTree.Text = node.Attributes["Tree"].Value;
			}
			if(node.Attributes["CompareOperator"] != null)
			{
				string strOperator = node.Attributes["CompareOperator"].Value;
				if(strOperator != "")
				{
					for(int i = 0; i< this.cboCompareOperator.Items.Count; i++)
					{
						Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)this.arrCompareOperator[i];
						
						if(obj.ID == strOperator)
						{
							this.cboCompareOperator.SelectedIndex = i;
							break;
						}
					}
				}
			}

			if(node.Attributes["CompareContext1"] != null)
			{
				this.txtCompareText.Text = node.Attributes["CompareContext1"].Value;
			}

			if(node.Attributes["RelationOperator"] != null)
			{
				string strOperator = node.Attributes["RelationOperator"].Value;
				if(strOperator != "")
				{
					for(int i = 0; i< this.cboRelationOperator.Items.Count; i++)
					{
						Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)this.arrRelationOperator[i];
						if(obj.ID == strOperator)
						{
//							this.cboCompareOperator.SelectedIndexChanged -= new System.EventHandler(this.cboRelationOperator_SelectedIndexChanged);
							this.cboRelationOperator.SelectedIndex = i;
//							this.cboRelationOperator.SelectedIndexChanged +=new EventHandler(cboRelationOperator_SelectedIndexChanged);
							break;
						}
					}
				}
			}
		}

		
		/// <summary>
		/// 方法：调用关系操作符改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void OnRelationOperatorSelectedIndexChanged(object sender, EventArgs e)
		{
			if(this.RelationOperatorSelectedIndexChanged != null)
			{
				RelationOperatorSelectedIndexChanged(sender, e);
			}
		}

		private void AddCompareOperatorItems()
		{
			if(this.arrCompareOperator == null || this.arrCompareOperator.Count == 0) return;
			this.cboCompareOperator.Items.Clear();
			System.Data.DataTable dt = new System.Data.DataTable("Relation");
			dt.Columns.Add("ID");
			dt.Columns.Add("Name");
			foreach(object obj in this.arrCompareOperator)
			{
				Neusoft.FrameWork.Models.NeuObject neuobj = (Neusoft.FrameWork.Models.NeuObject)obj;
				DataRow dr = dt.NewRow();
				dr["ID"]=neuobj.ID;
				dr["Name"]=neuobj.Name;
				dt.Rows.Add(dr);
			}
			this.cboCompareOperator.DataSource = dt;
			this.cboCompareOperator.DisplayMember = "Name";
			this.cboCompareOperator.ValueMember = "ID";
//			foreach(object obj in al)
//			{
//				Neusoft.FrameWork.Models.NeuObject neuobj = (Neusoft.FrameWork.Models.NeuObject)obj;
//				this.cboCompareOperator.Items.Add(neuobj.Name);
//			}
		}

		/// <summary>
		/// 初始化比较运算符
		/// </summary>
		/// <param name="al">下拉框选项</param>
		private void AddCompareOperatorItems(ArrayList al)
		{
			this.arrCompareOperator = al;
			this.AddCompareOperatorItems();
		}

		/// <summary>
		/// 初始化关系运算符
		/// </summary>
		/// <param name="al">下拉框选项</param>
		private void AddRelationOperatorItems(ArrayList al)
		{
			this.arrRelationOperator = al;
			this.AddRelationOperatorItems();
		}

		/// <summary>
		/// 初始化关系运算符
		/// </summary>
		/// <param name="al">下拉框选项</param>
		private void AddRelationOperatorItems()
		{
			if(this.arrRelationOperator == null || this.arrRelationOperator.Count == 0) return;
			this.cboRelationOperator.Items.Clear();

			System.Data.DataTable dt = new System.Data.DataTable("Relation");
			dt.Columns.Add("ID");
			dt.Columns.Add("Name");
			foreach(object obj in this.arrRelationOperator)
			{
				Neusoft.FrameWork.Models.NeuObject neuobj = (Neusoft.FrameWork.Models.NeuObject)obj;
				DataRow dr = dt.NewRow();
				dr["ID"]=neuobj.ID;
				dr["Name"]=neuobj.Name;
				dt.Rows.Add(dr);
			}
			this.cboRelationOperator.DataSource = dt;
			this.cboRelationOperator.DisplayMember = "Name";
			this.cboRelationOperator.ValueMember = "ID";

//			foreach(object obj in al)
//			{
//				Neusoft.FrameWork.Models.NeuObject neuobj = (Neusoft.FrameWork.Models.NeuObject)obj;
//				this.cboRelationOperator.Items.Add(neuobj.Name);
//			}
		}

		/// <summary>
		/// 比较运算符项目
		/// </summary>
		/// <returns></returns>
		private void initCompareOperatorItems()
		{
			this.arrCompareOperator = new ArrayList();
			Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "Like";
			obj.Name = "包含";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "not Like";
			obj.Name = "不包含";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "=";
			obj.Name = "等于";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "<>";
			obj.Name = "不等于";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = ">";
			obj.Name = "大于";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "<";
			obj.Name = "小于";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = ">=";
			obj.Name = "大于或等于";
			this.arrCompareOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "<=";
			obj.Name = "小于或等于";
			this.arrCompareOperator.Add(obj);
		}

		/// <summary>
		/// 关系运算符哈希表
		/// </summary>
		/// <returns></returns>
		private void initRelationOperatorItems()
		{
			this.arrRelationOperator = new ArrayList();

			Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "or";
			obj.Name = "并且";
			this.arrRelationOperator.Add(obj);

			obj = new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = "or";
			obj.Name = "或者";
			this.arrRelationOperator.Add(obj);
		}

		#endregion 方法

		#region 事件
		/// <summary>
		/// 选择树按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearchTree_Click(object sender, System.EventArgs e)
		{
			
			Function.FormSelectTree.ShowDialog();
			if(Function.FormSelectTree.DialogResult == DialogResult.OK)
			{
				if(Function.FormSelectTree.NodeFullPath != null)
				{
					this.txtTree.Text = Function.FormSelectTree.NodeFullPath;
				}
			}
		}

		/// <summary>
		/// 关系操作符改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboRelationOperator_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!IsAddValue)
			{
				OnRelationOperatorSelectedIndexChanged(this, e);
			}
		}

		#endregion 事件

	}
}
