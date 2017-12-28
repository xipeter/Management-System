using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Neusoft.HISFC.Components.EPR.Query
{

	/// <summary>
	/// ucConditions 的摘要说明。
	/// </summary>
	public class ucConditions : System.Windows.Forms.UserControl
	{
		[Category("Action"),Description("单击查询按钮时发生")]
		public event QueryHandler Query;
		[Category("Action"),Description("单击取消按钮时发生")]
		public event EventHandler Cancel;
		[Category("Action"),Description("在查询条件数量发生改变时发生")]
		public event EventHandler ConditionCountChanged;

//		private string _QueryConditionFileName = "";
		private int _MaxConditionCount = 4;
		private int _initHeight = 40;
		private int _top = 8;
		private int _left = 8;
		private int _height = 50;
		public int ControlHeight = 50;

		protected ArrayList alOperations;
		protected ArrayList alRelations;

//		private Neusoft.HISFC.Management.Manager.QueryCondition managerCondition;
		public System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.Button btnCanel;
		public System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Panel pnlConditionGroup;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ucConditions()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
//			this.managerCondition = new Neusoft.HISFC.Management.Manager.QueryCondition();
			this.Load+=new EventHandler(ucConditions_Load);

//			this._MaxConditionCount = MaxConditionCount;
//			_QueryConditionFileName = Application.StartupPath + "\\QueryCondition.xml";
//
//			//如果存在查询条件文件，则从查询条件文件取节点值，创建查询条件，否则，创建一个空的节点查询条件
//			if(System.IO.File.Exists(_QueryConditionFileName))
//			{
//				this.AddCondition(_QueryConditionFileName);
//			}
//			else
//			{
//				AddCondition();
//			}
//			this.InitRelationOperatorHashtable();
//			this.InitCompareOperatorHashtable();
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCanel = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.pnlConditionGroup = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Location = new System.Drawing.Point(392, 12);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCanel
			// 
			this.btnCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCanel.Location = new System.Drawing.Point(86, 13);
			this.btnCanel.Name = "btnCanel";
			this.btnCanel.Size = new System.Drawing.Size(64, 24);
			this.btnCanel.TabIndex = 0;
			this.btnCanel.Text = "取消";
			this.btnCanel.Visible = false;
			this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDel.Location = new System.Drawing.Point(464, 12);
			this.btnDel.Name = "btnDel";
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "删除...";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// pnlConditionGroup
			// 
			this.pnlConditionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlConditionGroup.Location = new System.Drawing.Point(0, 0);
			this.pnlConditionGroup.Name = "pnlConditionGroup";
			this.pnlConditionGroup.Size = new System.Drawing.Size(552, 8);
			this.pnlConditionGroup.TabIndex = 1;
			this.pnlConditionGroup.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlConditionGroup_ControlChanged);
			this.pnlConditionGroup.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlConditionGroup_ControlChanged);
			// 
			// ucConditions
			// 
			this.Controls.Add(this.pnlConditionGroup);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCanel);
			this.Controls.Add(this.btnDel);
			this.Name = "ucConditions";
			this.Size = new System.Drawing.Size(552, 40);
			this.ResumeLayout(false);

		}
		#endregion
		#region 属性
		/// <summary>
		/// 现有查询条件数量
		/// </summary>
		private int _CurConditionCount
		{
			get
			{
				return this.pnlConditionGroup.Controls.Count;
			}
		}


		/// <summary>
		/// 最多允许查询条件的数量
		/// </summary>
		[Category("Design"),Description("最多允许查询条件的数量")]
		public int MaxConditionCount
		{
			get
			{
				return _MaxConditionCount;
			}
			set
			{
				_MaxConditionCount = value;
				AddCondition();
//				InitCondition();
			}
		}

//		/// <summary>
//		/// 查询条件设置文件名称
//		/// </summary>
//		[Category("Design"),Description("查询条件设置文件名称")]
//		public string SettingFileName
//		{
//			get
//			{
//				return this._QueryConditionFileName;
//			}
//			set
//			{
//				this._QueryConditionFileName = value;
//				InitCondition();
//			}
//		}

		#endregion 属性

		#region 方法

		private void InitCondition()
		{
			this.pnlConditionGroup.Controls.Clear();
			//如果存在查询条件文件，则从查询条件文件取节点值，创建查询条件，否则，创建一个空的节点查询条件
			if(this._MaxConditionCount == 0) return;
//			if(this._QueryConditionFileName == null || this._QueryConditionFileName == "") return;

			string s = "";
			if(this.FindForm() ==null) return;
			try
			{
                s = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetQueryCondtion(this.FindForm().Name);
			}
			catch{return ;}
			if(s =="-1")
			{
				AddCondition();
				return;
			}
			if(s =="")
                s = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetQueryCondtion(this.FindForm().Name, false);

			if(s =="")
			{
				AddCondition();
				return;
			}

			XmlDocument doc = new XmlDocument();
			try
			{
				doc.LoadXml(s);
			}
			catch//(Exception ex)
			{
				AddCondition();
				return ;
			}

			XmlNodeList nodes = doc.SelectNodes("/SETTING/Condition");
			if(nodes.Count == 0)
			{
				AddCondition();
				return ;
			}

			foreach(XmlNode node in nodes)
			{
				AddCondition(node);

				if(this.pnlConditionGroup.Controls.Count == this._MaxConditionCount)
				{
					break;
				}
			}

//			if(System.IO.File.Exists(Application.StartupPath + "\\" + _QueryConditionFileName))
//			{
//				this.AddCondition(Application.StartupPath + "\\" + _QueryConditionFileName);
//			}
//			else
//			{
//				AddCondition();
//			}
//			this.RelocateConditionGroup();
		}

		/// <summary>
		/// 方法：删除指定的条件
		/// </summary>
		/// <param name="index"></param>
		private void DeleteCondition(int index)
		{
			this.pnlConditionGroup.Controls.RemoveAt(index);
		}

		/// <summary>
		/// 方法：根据输入字符串删除条件
		/// </summary>
		/// <param name="index"></param>
		private void DeleteCondition(string strDelCondition)
		{
			if(strDelCondition == null || strDelCondition.Length ==0) return;
			string[] arrDelCondition = strDelCondition.Split(';');
			for(int i = arrDelCondition.Length - 1; i >= 0; i--)
			{
				if(bool.Parse(arrDelCondition[i]))
				{
					DeleteCondition(i);
				}
			}

			if(this._CurConditionCount == 0)
			{
				AddCondition();
			}
		}

		/// <summary>
		/// 受保护的方法，调用Query事件
		/// </summary>
		/// <param name="e"></param>
		protected void OnQuery(QueryEventArgs e)
		{
			if(this.Query != null)
			{
				this.Query(this, e);
			}
		}

		/// <summary>
		/// 受保护的方法，调用Cancel事件
		/// </summary>
		/// <param name="e"></param>
		protected void OnCancel(EventArgs e)
		{
			if(this.Cancel != null)
			{
				this.Cancel(this, e);
			}
		}
		/// <summary>
		/// 方法：加入新条件
		/// </summary>
		private ucCondition AddCondition()
		{
			bool AllowNewCondition = _CurConditionCount == _MaxConditionCount - 1;
			ucCondition condition = new ucCondition();
			condition.Index = _CurConditionCount;
			condition.AllowNewCondition = AllowNewCondition;
//			condition.SelectTree += new EventHandler(group_SelectTree);
			condition.RelationOperatorSelectedIndexChanged += new EventHandler(group_RelationOperatorSelectedIndexChanged);

			condition.Location = new Point(_left, _top + _height * _CurConditionCount);
			condition.Width = this.Width;
			condition.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top; 
			this.pnlConditionGroup.Controls.Add(condition);
			return condition;
		}

		/// <summary>
		/// 方法：加入新条件，并且赋值
		/// </summary>
		/// <param name="node">树节点值</param>
		/// <returns></returns>
		private ucCondition AddCondition(System.Xml.XmlNode node)
		{
//			bool AllowNewCondition = _CurConditionCount == _MaxConditionCount - 1;
//			ucCondition condition = new ucCondition();
//			
//			condition.Index = _CurConditionCount;
//			condition.AllowNewCondition = AllowNewCondition;
////			condition.SelectTree += new EventHandler(group_SelectTree);
//			condition.RelationOperatorSelectedIndexChanged += new EventHandler(group_RelationOperatorSelectedIndexChanged);
//
//			condition.Location = new Point(_left, _top + _height * _CurConditionCount);
//			this.pnlConditionGroup.Controls.Add(condition);
			ucCondition condition = this.AddCondition();
			condition.Node = node;
			return condition;
		}

		/// <summary>
		/// 方法：从指定的文件读取初始条件
		/// </summary>
		/// <param name="FileName"></param>
//		private void AddCondition(bool AddBla)
//		{
//			//如果文件不存在或者文件不可读或者文件节点数为0，加入一个空的条件
//			//否则
//			//循环
//			//加入包括值节点
//			string s = "";
//			if(this.FindForm() ==null) return;
//			try
//			{
//				s = this.managerCondition.GetQueryCondtion(this.FindForm().Name);
//			}
//			catch{return ;}
//			if(s =="-1")
//			{
//				MessageBox.Show(this.managerCondition.Err);
//				return;
//			}
//			if(s =="")
//				s = this.managerCondition.GetQueryCondtion(this.FindForm().Name,true);
//
//			if(s =="") return;
//			
//			XmlDocument doc = new XmlDocument();
//			try
//			{
//				doc.LoadXml(s);
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.Message);
//				return ;
//			}
//
//			XmlNodeList nodes = doc.SelectNodes("/SETTING/Condition");
//			foreach(XmlNode node in nodes)
//			{
//				AddCondition(node);
//
//				if(this.pnlConditionGroup.Controls.Count == this._MaxConditionCount)
//				{
//					break;
//				}
//			}
//		}
//
		/// <summary>
		/// 查询条件定位
		/// </summary>
		private void RelocateConditionGroup()
		{
			for(int i = 0; i < _CurConditionCount; i++)
			{
				ucCondition condition = (ucCondition)this.pnlConditionGroup.Controls[i];
				condition.Index = i;
//				condition.Text = "查询条件" + (i+1).ToString() + "(&" + (i+1).ToString() + ")";
				condition.Location = new Point(_left, _top + (i) * _height);
				if(i < _MaxConditionCount - 1)
				{
					condition.AllowNewCondition = true;
				}
				else
				{
					condition.AllowNewCondition = false;
				}
			}

//			if(_CurConditionCount > 0)
//			{
//				((ucCondition)this.pnlConditionGroup.Controls[_CurConditionCount - 1]).IsLastCondition = true;
//			}
			this.Height = _initHeight + _height * _CurConditionCount;
			this.ControlHeight = _initHeight + _height * _CurConditionCount;
		}

		/// <summary>
		/// 保存查询条件
		/// </summary>
		private void SaveQueryCondition()
		{
            Neusoft.FrameWork.Xml.XML xml = new Neusoft.FrameWork.Xml.XML();
			XmlDocument doc = new XmlDocument();
			XmlElement root = xml.CreateRootElement(doc,"SETTING","1.0");

			for(int i = 0; i < this._CurConditionCount; i++)
			{
				//添加查询条件节点
				ucCondition condition = (ucCondition)this.pnlConditionGroup.Controls[i];
				XmlElement xmlCondition = xml.AddXmlNode(doc,root,"Condition","");
				xml.AddNodeAttibute(xmlCondition, "Tree", condition.Field);
				xml.AddNodeAttibute(xmlCondition, "CompareOperator", condition.CompareOperator);
				xml.AddNodeAttibute(xmlCondition, "CompareContext1", condition.CompareContext1);
				xml.AddNodeAttibute(xmlCondition, "RelationOperator", condition.RelationOperator);
				xml.AddNodeAttibute(xmlCondition, "CompareContext2", condition.CompareContext2);
			}
            if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.SetQueryCondition(this.FindForm().Name, doc.OuterXml, false) == -1)
			{
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.Err);
			}
//			else
//			{
//				MessageBox.Show("条件模板保存成功！");
//			}
//
//			doc.Save(Application.StartupPath + "\\" + this._QueryConditionFileName);
		}

		/// <summary>
		/// 取查询条件
		/// </summary>
		/// <returns></returns>
		public ArrayList GetQueryCondition()
		{
			ArrayList ar = new ArrayList();

			for(int i = 0; i < this._CurConditionCount; i++)
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				ucCondition condition = (ucCondition)this.pnlConditionGroup.Controls[i];
				obj.ID = condition.Field;
				obj.Name = condition.CompareOperator;
				obj.Memo = condition.CompareContext1;
				obj.User01 = condition.RelationOperator;
				obj.User02 = condition.CompareContext2;
				ar.Add(obj);
			}
			return ar;
		}

		#endregion 方法

		#region 事件
		/// <summary>
		/// 确定按钮单击事件
		/// 返回输入的条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			SaveQueryCondition();
			QueryEventArgs arg = new QueryEventArgs();

			arg.QueryCondition = GetQueryCondition();
			OnQuery(arg);
		}

		/// <summary>
		/// 取消按钮单击事件
		/// 返回空条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCanel_Click(object sender, System.EventArgs e)
		{
			System.EventArgs arg = new EventArgs();
			OnCancel(arg);
		}

		/// <summary>
		/// 删除按钮单击事件
		/// 删除条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			frmDeleteCondition frmDelCondition = new frmDeleteCondition(_CurConditionCount);
			frmDelCondition.ShowDialog();
			if(frmDelCondition.DialogResult == DialogResult.OK)
			{
				string strDelCondition = frmDelCondition.deleteConditions;
				DeleteCondition(strDelCondition);
			}
		}

		/// <summary>
		/// 关系运算符改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void group_RelationOperatorSelectedIndexChanged(object sender, EventArgs e)
		{
			ucCondition condition = (ucCondition)sender;
			if(condition.RelationOperator == "") return;
			ucCondition lastGroup = (ucCondition)this.pnlConditionGroup.Controls[condition.Parent.Controls.Count - 1];
			if(condition == lastGroup)
			{
				this.AddCondition();
			}
		}

//		/// <summary>
//		/// 选择树按钮单击事件
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="e"></param>
//		private void group_SelectTree(object sender, EventArgs e)
//		{
//
//		}

		/// <summary>
		/// 查询条件数目改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlConditionGroup_ControlChanged(object sender, ControlEventArgs e)
		{
			this.RelocateConditionGroup();
			if(this.ConditionCountChanged != null)
			{
				EventArgs arg = new EventArgs();
				this.ConditionCountChanged(this, arg);
			}
		}

		private void ucConditions_Load(object sender, EventArgs e)
		{
			this.InitCondition();
			this.RelocateConditionGroup();
		}
		#endregion 事件
	}


	/// <summary>
	/// Query 事件参数类
	/// </summary>
	public class QueryEventArgs
	{
		/// <summary>
		/// 查询条件
		/// </summary>
		public ArrayList QueryCondition;
	}

	/// <summary>
	/// Query事件委托
	/// </summary>
	public delegate void QueryHandler(System.Object sender, QueryEventArgs e);
}
