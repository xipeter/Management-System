using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.HISFC.Components.Terminal.Booking;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucMedTechBookingTemplet <br></br>
	/// [功能描述: 科室项目排班模板UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucMedTechBookingTemplet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucMedTechBookingTemplet()
		{
			InitializeComponent();

			if (this.DesignMode)
			{
				return;
			}

			this.operEnvironment.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
			this.operEnvironment.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
			this.operEnvironment.Dept = ((Neusoft.HISFC.Models.Base.Employee) Neusoft.FrameWork.Management.Connection.Operator).Dept;
           
		}

		#region 变量

		/// <summary>
		/// 排班控件数组,方便操作
		/// </summary>
		protected Terminal.Booking.ucBookingTemplet[] ucBookingTempletArray;
		
		/// <summary>
		/// 当前操作环境
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();

		/// <summary>
		/// 预约模板
		/// </summary>
        private Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem = new MedTechItem();

        /// <summary>
        /// 设备
        /// </summary>
        private Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier = new TerminalCarrier ( );

		/// <summary>
		/// 工具栏服务类
		/// </summary>
		protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toobarService = new ToolBarService();

		/// <summary>
		/// 删除事件
		/// </summary>
		protected event System.EventHandler DeleteEvent;
        /// <summary>
        /// 科室事件
        /// </summary>
        protected event System.EventHandler DeptEvent;
        /// <summary>
        /// 设备事件
        /// </summary>
        protected event System.EventHandler EquipmentEvent;
		
		/// <summary>
		/// 权限使用范围
		/// </summary>
		UseScope useScope = UseScope.SelfDepartment;

		#endregion

		#region 属性
		
		/// <summary>
		/// 使用权限
		/// </summary>
		public UseScope UseScope
		{
			get
			{
				return this.useScope;
			}
			set
			{
				this.useScope = value;
			}
		}
		
		#endregion

		#region 函数
        /// <summary>
        /// 判断标识位
        /// </summary>
        public void JudgeTmpFlag ( int tabIndex )
        {
            string tmpFlag = this.ucBookingTempletArray[tabIndex].JudgeTmpFlag();
            if (tmpFlag == "0")
            {
                this.toobarService.SetToolButtonEnabled("设备", true);
                this.toobarService.SetToolButtonEnabled("项目", true);
            }
            else if ( tmpFlag == "1" )
            {
                this.toobarService.SetToolButtonEnabled("设备", true);//this.toobarService.SetToolButtonEnabled("设备", false);
                this.toobarService.SetToolButtonEnabled("项目", true);
                this.InitItem();
            }
            else
            {
                this.toobarService.SetToolButtonEnabled("设备", true);
                this.toobarService.SetToolButtonEnabled("项目", true);//this.toobarService.SetToolButtonEnabled("项目", false);
                this.InitEquipment();
            }
        }
		/// <summary>
		/// 初始化数组
		/// </summary>
		private void InitArray()
		{
			ucBookingTempletArray = new ucBookingTemplet[7];
			ucBookingTempletArray[0] = this.ucBookingTemplet1;
			ucBookingTempletArray[1] = this.ucBookingTemplet2;
			ucBookingTempletArray[2] = this.ucBookingTemplet3;
			ucBookingTempletArray[3] = this.ucBookingTemplet4;
			ucBookingTempletArray[4] = this.ucBookingTemplet5;
			ucBookingTempletArray[5] = this.ucBookingTemplet6;
			ucBookingTempletArray[6] = this.ucBookingTemplet7;

			this.ucBookingTempletArray[0].KeyEnter+=new ucBookingTemplet.delegateEnter(ucMedTechBookingTemplet_KeyEnter);
		}

		/// <summary>
		/// 获取选择的科室
		/// </summary>
		/// <returns></returns>
		public Neusoft.FrameWork.Models.NeuObject GetDept()
		{
			// 临时科室实体
			Neusoft.FrameWork.Models.NeuObject dept = operEnvironment.Dept;
			
			if (this.neuComboBoxDept.Tag != null && this.neuComboBoxDept.Tag.ToString() != "" && this.neuComboBoxDept.Text != "")
			{
				dept.ID = this.neuComboBoxDept.Tag.ToString();
				dept.Name = this.neuComboBoxDept.Text.ToString();
			}
			this.operEnvironment.Dept.ID = dept.ID;
			this.operEnvironment.Dept.Name = dept.Name;
			
			// 返回科室
			return dept;
		}

		/// <summary>
		/// 生成科室项目树
		/// </summary>
		private void InitItem()
		{
			if (this.DesignMode)
			{
				return;
			}
			// 父级节点
			TreeNode parentNode = new TreeNode("科室项目");
            neuTreeView1.ImageList = neuTreeView1.groupImageList;
            parentNode.ImageIndex = 0;
            parentNode.SelectedImageIndex = 0;
			// 医技业务层
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
			// 选择的科室编码
			string deptCode = this.GetDept().ID;
			// 科室维护的预约项目
			ArrayList deptItemList = new ArrayList();
            deptItemList = bookingIntegrate.QueryMedTechItem(deptCode);
			this.neuTreeView1.Nodes.Clear();
            this.neuTreeView1.Nodes.Add(parentNode);

			if (deptItemList == null)
			{
				MessageBox.Show("获取科室项目列表时出错!" + bookingIntegrate.Err, "提示");
				return;
			}
            ArrayList alReturn = bookingIntegrate.GetAllList("MEDTECHITEM");
            if (alReturn == null)
            {
                MessageBox.Show("获取常数 MEDTECHITEM 失败");
            }
			foreach (Neusoft.HISFC.Models.Terminal.MedTechItem obj in deptItemList)
			{
                foreach (Neusoft.HISFC.Models.Base.Const con in alReturn)
                {
                    if (obj.Item.ID == con.ID && con.IsValid)
                    {
                        TreeNode node = new TreeNode();

                        node.Text = obj.Item.Name;
                        node.Tag = obj;
                        node.ImageIndex = 3;
                        node.SelectedImageIndex = 4;
                        parentNode.Nodes.Add(node);
                    }
                }
			}

			parentNode.ExpandAll();
		}

        /// <summary>
        /// 生成科室设备树

        /// </summary>
        private void InitEquipment ( )
        {
            if ( this.DesignMode )
            {
                return;
            }
            // 父级节点
            TreeNode parentNode = new TreeNode ( "科室设备" );
            neuTreeView1.ImageList = neuTreeView1.groupImageList;
            parentNode.ImageIndex = 0;
            parentNode.SelectedImageIndex = 0;
            // 医技业务层

            Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ( );
            // 选择的科室编码

            string deptCode = this.GetDept ( ).ID;
            // 科室维护的设备

            ArrayList deptEquipmentList = new ArrayList ( );
            deptEquipmentList = bookingIntegrate.QueryMedTechEquipment ( deptCode );
            this.neuTreeView1.Nodes.Clear ( );
            this.neuTreeView1.Nodes.Add ( parentNode );

            if ( deptEquipmentList == null )
            {
                MessageBox.Show ( "获取科室设备列表时出错!" + bookingIntegrate.Err , "提示" );
                return;
            }
            foreach ( Neusoft.HISFC.Models.Terminal.TerminalCarrier obj in deptEquipmentList )
            {
                    TreeNode node = new TreeNode ( );

                    node.Text = obj.CarrierName;
                    node.Tag = obj;
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 4;
                    parentNode.Nodes.Add ( node );
                
                
            }

            parentNode.ExpandAll ( );
        }

		/// <summary>
		/// 初始化模板控件
		/// </summary>
		private void InitControls()
		{
			if (this.DesignMode)
			{
				return;
			}
			
			Terminal.Booking.ucBookingTemplet ucBookingTempletTemp;

			for (int i = 0; i<7; i++)
			{
				ucBookingTempletTemp = this.ucBookingTempletArray[i];
				
				ucBookingTempletTemp.Init(i);
			}
		}

		/// <summary>
		/// 检索Tab页面数据
		/// </summary>
		private void RetrieveTab()
		{
			int Index = this.neuTabControl1.SelectedIndex;

			this.ucBookingTempletArray[Index].Query(this.GetDept().ID, Index.ToString());
		}

		/// <summary>
		/// 初始化下拉控件
		/// </summary>
		private void InitComb()
		{
			if (this.DesignMode)
			{
				return;
			}
			// 业务
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
			// 科室数组
			ArrayList deptList = bookingIntegrate.GetDeptmentAll();
			
			if (deptList == null)
			{
				deptList = new ArrayList();
			}

			this.neuComboBoxDept.AddItems(deptList);
			//this.neuComboBoxDept.isItemOnly = true;

			this.neuComboBoxDept.Tag = this.operEnvironment.Dept.ID;
			this.neuComboBoxDept.Text = this.operEnvironment.Dept.Name;

			if (this.useScope != UseScope.AllDepartment)
			{
				this.neuComboBoxDept.Enabled = false;
			}
		}

		/// <summary>
		/// 设置看见性
		/// </summary>
		private void SetListVisiable()
		{
			int i = this.neuTabControl1.SelectedIndex;
			
			this.ucBookingTempletArray[i].SetVisible();
		}

		/// <summary>
		/// 增加
		/// </summary>
		private void Add()
		{
			int tabIndex = this.neuTabControl1.SelectedIndex;
            if ( this.neuTreeView1.SelectedNode.Tag.GetType ( ).FullName.Equals ("Neusoft.HISFC.Models.Terminal.MedTechItem") )
            {
                this.medTechItem = ( Neusoft.HISFC.Models.Terminal.MedTechItem ) this.neuTreeView1.SelectedNode.Tag;
                if ( this.medTechItem == null )
                {
                    return;
                }
                else
                {
                    try
                    {
                        this.ucBookingTempletArray [ tabIndex ].Add ( this.medTechItem );
                    }
                    catch ( Exception exception )
                    {
                        MessageBox.Show ( exception.Message , "提示信息" );
                        return;
                    }
                }
            }
            else if(this.neuTreeView1.SelectedNode.Tag.GetType ( ).FullName.Equals("Neusoft.HISFC.Models.Terminal.TerminalCarrier")) 
            {
                this.terminalCarrier = ( Neusoft.HISFC.Models.Terminal.TerminalCarrier ) this.neuTreeView1.SelectedNode.Tag;
                if ( this.terminalCarrier == null )
                {
                    return;
                }
                else
                {
                    try
                    {
                        this.ucBookingTempletArray [ tabIndex ].Add ( this.terminalCarrier );
                    }
                    catch ( Exception exception )
                    {
                        MessageBox.Show ( exception.Message , "提示信息" );
                        return;
                    }
                }
            }
            this.JudgeTmpFlag ( tabIndex );
			
		}

		/// <summary>
		/// 删除
		/// </summary>
		private void Delete()
		{
			this.ucBookingTempletArray[this.neuTabControl1.SelectedIndex].Delete();
		}

		/// <summary>
		/// 保存
		/// </summary>
		private void Save()
		{
			int tabIndex = this.neuTabControl1.SelectedIndex;

			if (this.ucBookingTempletArray[tabIndex].Save() == -1)
			{
				return;
			}

			MessageBox.Show("保存成功!", "提示");
            this.JudgeTmpFlag ( tabIndex );
			this.RetrieveTab();
		}
		
		
		#endregion

		#region 事件

		/// <summary>
		/// UC加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <param name="param"></param>
		/// <returns></returns>
        protected override ToolBarService OnInit ( object sender , object neuObject , object param )
        {
            if ( this.DesignMode )
            {
                return null;
            }

            this.DeleteEvent += new EventHandler ( ucMedTechBookingTemplet_DeleteEvent );
            this.DeptEvent +=new EventHandler(ucMedTechBookingTemplet_DeptEvent);
            this.EquipmentEvent +=new EventHandler(ucMedTechBookingTemplet_EquipmentEvent);
            this.toobarService.AddToolButton ( "删除" , "删除执行记录" , ( int ) Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , this.DeleteEvent );
            this.toobarService.AddToolButton ( "项目" , "项目" , ( int ) Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室 , true , false , this.DeptEvent );
            this.toobarService.AddToolButton ( "设备" , "设备" , ( int ) Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设备 , true , false , this.EquipmentEvent );
            this.operEnvironment.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
            this.operEnvironment.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
            this.operEnvironment.Dept = ( ( Neusoft.HISFC.Models.Base.Employee ) Neusoft.FrameWork.Management.Connection.Operator ).Dept;

            this.InitArray ( );
            this.InitComb ( );
            this.InitItem ( );

            this.InitControls ( );
            this.RetrieveTab ( );
           
            this.ucBookingTempletArray [ this.neuTabControl1.SelectedIndex ].operEnvironment = this.operEnvironment;
            this.JudgeTmpFlag ( 0);
           

            return this.toobarService;
        }


		/// <summary>
		/// 删除事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ucMedTechBookingTemplet_DeleteEvent(object sender, EventArgs e)
		{
			this.Delete();
            this.JudgeTmpFlag ( this.neuTabControl1.SelectedIndex );
            
		}
        /// <summary>
        /// 科室事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucMedTechBookingTemplet_DeptEvent ( object sender , EventArgs e )
        {
            this.InitItem ( );
            
        }
        /// <summary>
        /// 设备事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucMedTechBookingTemplet_EquipmentEvent ( object sender , EventArgs e )
        {
            this.InitEquipment ( );
            
        }

		/// <summary>
		/// 保存事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <returns></returns>
		protected override int OnSave(object sender, object neuObject)
		{
			this.Save();
			return 1;
		}

		/// <summary>
		/// 回车事件
		/// </summary>
		void ucMedTechBookingTemplet_KeyEnter()
		{
			this.neuTextBoxQuery.Focus();
		}

		/// <summary>
		/// 科室选择控件选择改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuComboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.InitItem();
			this.RetrieveTab();
			for (int i = 0;i < 7;i++)
			{
				this.neuTabControl1.TabPages[i].Tag = "";
				this.ucBookingTempletArray[i].operEnvironment.Dept = this.GetDept();

				this.ucBookingTempletArray[i].operEnvironment.ID = this.operEnvironment.ID;
			}
		}

		/// <summary>
		/// 查找按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuButtonQuery_Click(object sender, EventArgs e)
		{
			if (this.neuTextBoxQuery.Text.Trim() == "")
			{
				this.neuTreeView1.SelectedNode = this.neuTreeView1.Nodes[0];
			}
			else
			{
				string filter = this.neuTextBoxQuery.Text.Trim().ToUpper();

				foreach (TreeNode node in this.neuTreeView1.Nodes[0].Nodes)
				{
                    Neusoft.HISFC.Models.Terminal.MedTechItem medTechItemTemp = (Neusoft.HISFC.Models.Terminal.MedTechItem)node.Tag;
					// 业务
					Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
					// 拼音码
					Neusoft.HISFC.Models.Base.Spell spell = new Spell();

					spell = bookingIntegrate.GetSpell(medTechItemTemp.Item.Name);

					if (spell.SpellCode.IndexOf(filter, 0, spell.SpellCode.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
					if (medTechItemTemp.Item.ID.IndexOf(filter, 0, medTechItemTemp.Item.ID.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
					if (medTechItemTemp.Item.Name.IndexOf(filter, 0, medTechItemTemp.Item.Name.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
				}
			}
		}

		/// <summary>
		/// 查找文本框按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTextBoxQuery_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.neuButtonQuery_Click(new object(), new System.EventArgs());
			}
		}

		/// <summary>
		/// Tab页改变之后事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTabControl1_Selected(object sender, TabControlEventArgs e)
		{
			// Tab页的Tag
			object tempObject = this.neuTabControl1.TabPages[this.neuTabControl1.SelectedIndex].Tag;
            int tabIndex = this.neuTabControl1.SelectedIndex;
            
			if (tempObject == null || tempObject.ToString() == "")
			{
				
				
				this.neuTreeView1.SelectedNode = this.neuTreeView1.Nodes[0];
				
				this.RetrieveTab();

				this.ucBookingTempletArray[tabIndex].Focus();

				this.ucBookingTempletArray[tabIndex].operEnvironment = this.operEnvironment;

				this.neuTabControl1.TabPages[this.neuTabControl1.SelectedIndex].Tag = "Has Retrieve";
				
			}
            this.JudgeTmpFlag ( tabIndex );
		}

		/// <summary>
		/// Tab页改变时事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
			try
			{
				int tabIndex = this.neuTabControl1.SelectedIndex;

				this.neuTextBoxQuery.Focus();

				this.ucBookingTempletArray[tabIndex].operEnvironment = this.operEnvironment;

				if (this.ucBookingTempletArray[tabIndex].IsChange())
				{
					if (MessageBox.Show("数据已经修改,是否保存变动?",
										"提示",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						if (this.ucBookingTempletArray[tabIndex].Save() == -1)
						{
							return;
						}
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "提示信息");
				return;
			}

			this.SetListVisiable();
		}

		/// <summary>
		/// 树节点双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 1)
			{
				return;
			}
			this.Add();
		}

		#endregion		
	}
	
	/// <summary>
	/// 使用者的权限范围
	/// </summary>
	[Category("HIS系统设置"), Description("设置使用者的权限范围")]
	public enum UseScope
	{
		/// <summary>
		/// 只能维护自身科室
		/// </summary>
		SelfDepartment,
		/// <summary>
		/// 可以维护所有科室
		/// </summary>
		AllDepartment
	}
}
