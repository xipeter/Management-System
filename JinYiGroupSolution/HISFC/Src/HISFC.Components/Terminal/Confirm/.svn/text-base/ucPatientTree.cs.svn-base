using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.BizProcess.Integrate.Terminal;
using Neusoft.HISFC.Models.Registration;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// ucPatientTree <br></br>
	/// [功能描述: 终端确认的患者树UC]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucPatientTree : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucPatientTree()
		{
			InitializeComponent();
		}

		#region 变量
		
		/// <summary>
		/// 操作员当前科室
		/// </summary>
		string currentDepartment = "";

		/// <summary>
		/// 用于在总UC实现的代理和事件定义：用于实现单击患者结点显示患者基本信息和申请单明细的代理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void delegatePatientTree(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e);
		
		/// <summary>
		/// 用于在总UC实现的代理和事件定义：用于实现单击患者结点显示患者基本信息和申请单明细的代理
		/// </summary>
		public event delegatePatientTree ClickTreeNode;

		/// <summary>
		/// 按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void delegateKeyDown(object sender, KeyEventArgs e);

		public event delegateKeyDown TreeNodeKeyDown;

		/// <summary>
		/// 窗口类型：1-门诊；2-住院；9－通用
		/// </summary>
		string windowType = "1";

		/// <summary>
		/// 是否处于加载状态
		/// </summary>
		public bool isLoad = false;
		
		/// <summary>
		/// 当前鼠标移动到的树节点
		/// </summary>
		private TreeNode nodeCurrentMove = new TreeNode();
		
		#endregion

		#region 属性

		/// <summary>
		/// 操作员当前科室
		/// </summary>
		public string CurrentDepartment
		{
			get
			{
				return this.currentDepartment;
			}
			set
			{
				this.currentDepartment = value;
			}
		}
		
		/// <summary>
		/// 窗口类型：1-门诊；2-住院
		/// </summary>
		public string WindowType
		{
			get
			{
				return this.windowType;
			}
			set
			{
				this.windowType = value;
			}
		}
		
		#endregion

		#region 事件

		/// <summary>
		/// 鼠标移动事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_MouseMove(object sender, MouseEventArgs e)
		{
			// 结点
			TreeNode treeNode = new TreeNode();
			// 显示的提示信息
			string tips = "";
			// 患者基本信息
			Neusoft.HISFC.Models.Registration.Register tempRegister;
			
			if (this.isLoad)
			{
				return;
			}
			//
			// 根据坐标获取结点
			//
			treeNode = this.treeView1.GetNodeAt(e.X, e.Y);
			if (treeNode == this.nodeCurrentMove)
			{
				return;
			}
			else
			{
				this.nodeCurrentMove = treeNode;
			}
			if (treeNode == null)
			{
				return;
			}
			// 如果获取结点成功
			if (treeNode.Level == 2)
			{
				// 转换结点为患者基本信息

				tempRegister = (Neusoft.HISFC.Models.Registration.Register)treeNode.Tag;
				string patientType = "";
				if (tempRegister.Memo == "1")
				{
					patientType = "门诊患者";
				}
				else if (tempRegister.Memo == "2")
				{
					patientType = "住院患者";
				}
				else if (tempRegister.Memo == "3")
				{
					patientType = "急诊患者";
				}
                else if (tempRegister.Memo == "4" || tempRegister.Memo == "5")
				{
					patientType = "体检患者";
				}
				// 构造提示信息

				tips +=   "患者姓名: " + tempRegister.Name;
				tips += "\n性    别: " + tempRegister.Sex.Name;
				tips += "\n就诊科室: " + tempRegister.DoctorInfo.Templet.Dept.Name;
				tips += "\n病 历 号: " + tempRegister.PID.CardNO;
				tips += "\n患者类别: " + patientType;

				// 设置提示信息
				this.toolTip1.SetToolTip(this.treeView1, tips);
				// 显示提示信息
				this.toolTip1.Active = true;
			}
			else
			{
				// 关闭提示信息
				this.toolTip1.Active = false;
			}
		}

		/// <summary>
		/// 单击树节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			// 如果处于加载状态，那么返回
			if (this.isLoad)
			{
				return;
			}
			// 根据不通的窗口用途，执行不通的操作
			if (e.Node.Level == 2)
			{
				this.ClickTreeNode(sender, e);
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// 按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			this.TreeNodeKeyDown(sender, e);
		}

		#endregion

		#region 函数

		/// <summary>
		/// 初始化患者树
		/// </summary>
		public void Init()
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载患者信息...");
			Application.DoEvents();
            this.treeView1.ImageList = treeView1.deptImageList;
			// 初始化患者树
			if (windowType == "1")
			{
				// 检索门诊患者
				this.LoadOutpatient();
			}
			else if (windowType == "2")
			{
				// 检索住院患者基本信息
				this.LoadInpatient();
			}
			else
			{
				this.LoadOutpatient();
			}
		}

		/// <summary>
		/// 初始化/刷新门诊患者列表树
		/// </summary>
		public void LoadOutpatient()
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载患者信息...");
			Application.DoEvents();
			// 业务层
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			// 患者树结点
			TreeNode treeNode = new TreeNode();
            treeNode.ImageIndex = 2;
            treeNode.SelectedImageIndex = 2;
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();

			this.isLoad = true;
			
			// 获取树结点
			result = confirmIntegrate.GetOutpatientTreeNode(ref treeNode);
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				MessageBox.Show(confirmIntegrate.Err);
				this.isLoad = false;
				return;
			}
			this.treeView1.Nodes.Clear();
			// 添加结点数组到树
			this.treeView1.Nodes.Add(treeNode);
			// 展开所有树结点
			this.treeView1.ExpandAll();
			
			this.isLoad = false;
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 初始化/刷新住院患者列表数
		/// </summary>
		void LoadInpatient()
		{
			// 业务层
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 患者树结点
			TreeNode treeNode = new TreeNode();
            treeNode.ImageIndex = 0;
            treeNode.SelectedImageIndex = 1;
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();

			this.isLoad = true;

			// 获取树结点
			result = confirmIntegrate.GetOutpatientTreeNode(ref treeNode);
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				MessageBox.Show(confirmIntegrate.Err);
				this.isLoad = false;
				return;
			}
			// 添加结点数组到树
			this.treeView1.Nodes.Add(treeNode);
			// 展开所有树结点
			this.treeView1.ExpandAll();

			this.isLoad = false;
		}

		/// <summary>
		/// 按键切换焦点到患者树
		/// </summary>
		public void SetFocus()
		{
			this.treeView1.Focus();
		}
		
		/// <summary>
		/// 获取当前节点
		/// </summary>
		/// <returns></returns>
		public System.Windows.Forms.TreeNode GetCurrentNode()
		{
			TreeNode currentNode = this.treeView1.SelectedNode;

			return currentNode;
		}
		
		#endregion
	}
}
