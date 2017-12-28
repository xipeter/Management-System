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
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Components.Terminal.Booking;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucBookingArrange <br></br>
	/// [功能描述: 医技预约排班UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-13'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucBookingArrange : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucBookingArrange()
		{
			InitializeComponent();
			
			if (this.DesignMode)
			{
				return;
			}

			this.operEnvironment.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
			this.operEnvironment.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;

			this.operEnvironment.Dept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;
		}

		#region 变量

		/// <summary>
		/// 医技预约项目
		/// </summary>
        private Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem = new MedTechItem();
        /// <summary>
        /// 设备
        /// </summary>
        private Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier = new TerminalCarrier ( );
		/// <summary>
		/// 排班控件数组,方便操作
		/// </summary>
		protected Terminal.Booking.ucMedTechBookingArrange[] controls;
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
		
		/// <summary>
		/// 操作环境
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();
		
		/// <summary>
		/// 业务
		/// </summary>
		private Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
		
		/// <summary>
		/// 工具栏服务
		/// </summary>
		protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new ToolBarService();

		/// <summary>
		/// 上周事件
		/// </summary>
		protected event System.EventHandler PriorWeekEvent;

		/// <summary>
		/// 下周事件
		/// </summary>
		protected event System.EventHandler NextWeekEvent;

		/// <summary>
		/// 调模板事件
		/// </summary>
		protected event System.EventHandler LoadTempEvent;

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
		/// 使用范围
		/// </summary>
		private UseScope useScope = UseScope.SelfDepartment;

		#endregion

		#region 属性

		/// <summary>
		/// 设置使用范围，是否可以维护全部科室的排班数据
		/// </summary>
		[Category("HIS系统设置"), Description("设置使用范围，是否可以维护全部科室的排班数据")]
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

		#region 私有函数
        /// <summary>
        /// 判断标识位
        /// </summary>
        public void JudgeTmpFlag ( int tabIndex )
        {
            string tmpFlag = this.controls [ tabIndex ].JudgeTmpFlag ( );
            //{5A111831-190D-4187-8076-83E220BC97B2}
            if ( tmpFlag == "0" )
            {
                //this.toolbarService.SetToolButtonEnabled ( "设备" , true );
                //this.toolbarService.SetToolButtonEnabled ( "项目" , true );
            }
            else if ( tmpFlag == "1" )
            {
                //this.toolbarService.SetToolButtonEnabled ( "设备" , false );
                //this.toolbarService.SetToolButtonEnabled ( "项目" , true );
                this.InitItem ( );
            }
            else
            {
                //this.toolbarService.SetToolButtonEnabled ( "设备" , true );
                //this.toolbarService.SetToolButtonEnabled ( "项目" , false );
                this.InitEquipment ( );
            }
        }
		/// <summary>
		/// 初始化数组
		/// </summary>
		private void InitArray()
		{
			this.controls = new Terminal.Booking.ucMedTechBookingArrange[7];
			controls[0] = this.ucMedTechBookingArrange1;
			controls[1] = this.ucMedTechBookingArrange2;
			controls[2] = this.ucMedTechBookingArrange3;
			controls[3] = this.ucMedTechBookingArrange4;
			controls[4] = this.ucMedTechBookingArrange5;
			controls[5] = this.ucMedTechBookingArrange6;
			controls[6] = this.ucMedTechBookingArrange7;
		}
		
		/// <summary>
		/// 生成科室项目树
		/// </summary>
		private void InitItem()
		{
			// 父节点
			TreeNode parent = new TreeNode("科室项目");
            neuTreeView1.ImageList = neuTreeView1.groupImageList;
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
			// 科室编码
			string deptCode = this.GetDept().ID;
			// 科室项目数组
			ArrayList itemList = new ArrayList();
			
			this.neuTreeView1.Nodes.Clear();
			this.neuTreeView1.Nodes.Add(parent);
            ArrayList conList = this.bookingIntegrate.GetAllList("MEDTECHITEM");
            if (conList == null)
            {
                MessageBox.Show("查询常数 MEDTECHITEM 出错 ");
                return;
            }
            itemList = this.bookingIntegrate.QueryMedTechItem(deptCode);
			if (itemList == null)
			{
				MessageBox.Show("获取科室项目列表时出错!" + this.bookingIntegrate.Err, "提示信息");
				return;
			}
            foreach (Neusoft.HISFC.Models.Terminal.MedTechItem obj in itemList)
			{
                foreach (Neusoft.HISFC.Models.Base.Const con in conList)
                {
                    if (obj.Item.ID == con.ID && con.IsValid)
                    {
                        TreeNode node = new TreeNode();
                        node.ImageIndex = 3;
                        node.SelectedImageIndex = 4;
                        node.Text = obj.Item.Name;
                        node.Tag = obj;
                        parent.Nodes.Add(node);
                    }
                }
				
			}

			parent.ExpandAll();
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
			Terminal.Booking.ucMedTechBookingArrange tempUC;

			for (int i = 0;i < 7;i++)
			{
				tempUC = controls[i];
				tempUC.Init((DayOfWeek)(i + 1), DateTime.Parse(this.neuTabControl1.TabPages[i].Tag.ToString()));
			}
		}
		
		/// <summary>
		/// 检索Tab页面数据
		/// </summary>
		private void Retrieve()
		{
			int index = this.neuTabControl1.SelectedIndex;
			controls[index].Query(this.GetDept().ID, this.neuTabControl1.TabPages[index].Tag.ToString());
		}

		/// <summary>
		/// 初始化下拉控件
		/// </summary>
		private void InitComb()
		{
			// 科室列表
			ArrayList deptList = this.bookingIntegrate.GetDeptmentAll();
			if (deptList == null)
			{
				deptList = new ArrayList();
			}

			this.neuComboBoxDept.AddItems(deptList);
			this.neuComboBoxDept.IsListOnly = true;

			this.neuComboBoxDept.Tag = this.operEnvironment.Dept.ID;
			this.neuComboBoxDept.Text = this.operEnvironment.Dept.Name;

			this.controls[this.neuTabControl1.SelectedIndex].operEnvironment = this.operEnvironment;
			
			if (this.useScope == UseScope.SelfDepartment)
			{
				this.neuComboBoxDept.Enabled = false;
			}
			else
			{
				this.neuComboBoxDept.Enabled = true;
			}
		}
		
		/// <summary>
		/// 生成排班日期
		/// </summary>
		private void InitTab()
		{
			// 当前时间
			DateTime currentTime = this.bookingIntegrate.GetCurrentDateTime();
			// 获取星期一
			DateTime Monday = this.GetMonday(currentTime);
			// 设置星期和日期
			this.SetWeek(Monday);
		}
		
		/// <summary>
		/// 设置星期和日期
		/// </summary>
		/// <param name="Monday">星期一日期</param>
		private void SetWeek(DateTime Monday)
		{
			string[] Week = new string[] { "一", "二", "三", "四", "五", "六", "日" };

			for (int i = 0;i < 7;i++)
			{
				this.neuTabControl1.TabPages[i].Tag = Monday.AddDays(i);
				this.neuTabControl1.TabPages[i].Text = Monday.AddDays(i).ToString("yyyy-MM-dd") + "  " + Week[i];
			}
		}
		
		/// <summary>
		/// 获取当前日期所在星期的星期一
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		private DateTime GetMonday(DateTime current)
		{
			DayOfWeek today = current.DayOfWeek;

			int interval = 1 - (int)today;

			if (interval == 1)//星期日
			{
				interval = -6;//将星期日归到上星期
			}

			return current.AddDays(interval);
		}

		/// <summary>
		/// 获取cmb的科室
		/// </summary>
		/// <returns>选择的科室</returns>
		public Neusoft.FrameWork.Models.NeuObject GetDept()
		{
			Neusoft.FrameWork.Models.NeuObject tempDept = new NeuObject();

			if (this.neuComboBoxDept.Tag != null && this.neuComboBoxDept.Tag.ToString() != "" && this.neuComboBoxDept.Text != "")
			{
				tempDept.ID = this.neuComboBoxDept.Tag.ToString();
				tempDept.Name = this.neuComboBoxDept.Text.ToString();
			}
			return tempDept;
		}

		/// <summary>
		/// 设置弹出控件的可见性
		/// </summary>
		private void SetListVisiable()
		{
			int i = this.neuTabControl1.SelectedIndex;
			this.controls[i].SetVisible();
		}

		/// <summary>
		/// 检索下周数据
		/// </summary>
		private void Next()
		{
			DateTime monday;
			int index;

			monday = this.GetMonday(DateTime.Parse(this.tabPage7.Tag.ToString()).AddDays(2));
			this.SetWeek(monday);

			for (int i = 0;i < 7;i++)
			{
				this.controls[i].Tag = null;
				this.controls[i].SeeDate = DateTime.Parse(this.neuTabControl1.TabPages[i].Tag.ToString());
			}
			index = this.neuTabControl1.SelectedIndex;

			this.controls[index].Query(this.GetDept().ID, this.neuTabControl1.TabPages[index].Tag.ToString());
			
			this.SetListVisiable();
		}
		
		/// <summary>
		/// 检索上周数据
		/// </summary>
		private void Prior()
		{
			DateTime Monday;

			Monday = this.GetMonday(DateTime.Parse(this.tabPage1.Tag.ToString()).AddDays(-3));
			this.SetWeek(Monday);

			for (int i = 0;i < 7;i++)
			{
				this.controls[i].Tag = null;
				this.controls[i].SeeDate = DateTime.Parse(this.neuTabControl1.TabPages[i].Tag.ToString());
			}
			int Index = this.neuTabControl1.SelectedIndex;
			this.controls[Index].Query(this.GetDept().ID, this.neuTabControl1.TabPages[Index].Tag.ToString());
			this.SetListVisiable();
		}
		
		/// <summary>
		/// 载入模板
		/// </summary>
		private void LoadTemplet()
		{
			frmSelectWeek formSelectWeek = new frmSelectWeek();

            formSelectWeek.TmpFlag = this.controls [ this.neuTabControl1.SelectedIndex ].JudgeTmpFlag ( );

			if (formSelectWeek.ShowDialog() == DialogResult.OK)
			{
				//获取有效模板信息
				ArrayList templetList = new ArrayList();
				templetList = this.bookingIntegrate.QueryTemp(this.GetDept().ID, ((int)formSelectWeek.SelectedWeek).ToString());
				if (templetList == null)
				{
					MessageBox.Show("查询模板信息时出错!" + this.bookingIntegrate.Err, "提示");
					return;
				}

                foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp in templetList)
                {
                    if (tempMedTechItemTemp.MedTechItem.Item.IsValid)
                    {
                        controls[this.neuTabControl1.SelectedIndex].AddTemp(tempMedTechItemTemp);
                    }
                }
				controls[this.neuTabControl1.SelectedIndex].Focus();
				formSelectWeek.Dispose();
			}
			this.neuTextBoxQuery.Focus();
		}

		/// <summary>
		/// 增加
		/// </summary>
		private void Add()
		{
            int tabIndex = this.neuTabControl1.SelectedIndex;
            if ( this.neuTreeView1.SelectedNode.Tag.GetType ( ).FullName.Equals ( "Neusoft.HISFC.Models.Terminal.MedTechItem" ) )
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
                        this.controls [ tabIndex ].Add ( this.medTechItem );
                    }
                    catch ( Exception exception )
                    {
                        MessageBox.Show ( exception.Message , "提示信息" );
                        return;
                    }
                }
            }
            else if ( this.neuTreeView1.SelectedNode.Tag.GetType ( ).FullName.Equals ( "Neusoft.HISFC.Models.Terminal.TerminalCarrier" ) )
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
                        this.controls [ tabIndex ].Add ( this.terminalCarrier );
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
			int Index = this.neuTabControl1.SelectedIndex;
			controls[Index].Delete();
		}

		/// <summary>
		/// 保存
		/// </summary>
		private void Save()
		{
			int Index = this.neuTabControl1.SelectedIndex;

			if (controls[Index].Save() == -1)
			{
				controls[Index].Focus();
				return;
			}

			MessageBox.Show("保存成功!", "提示");
            this.JudgeTmpFlag ( Index );
			this.Retrieve();
		}

		#endregion

		#region 属性

		/// <summary>
		/// 初始化事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
		{
			this.PriorWeekEvent += new EventHandler(ucBookingArrange_PriorWeekEvent);
			this.NextWeekEvent += new EventHandler(ucBookingArrange_NextWeekEvent);
			this.LoadTempEvent += new EventHandler(ucBookingArrange_LoadTempEvent);
			this.DeleteEvent += new EventHandler(ucBookingArrange_DeleteEvent);
            this.DeptEvent +=new EventHandler(ucBookingArrange_DeptEvent);
            this.EquipmentEvent +=new EventHandler(ucBookingArrange_EquipmentEvent);
			this.toolbarService.AddToolButton("上周", "移动到上周", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S上一个, true, false, this.PriorWeekEvent);
			this.toolbarService.AddToolButton("下周", "移动到上周", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, this.NextWeekEvent);
			this.toolbarService.AddToolButton("调模板", "调用其它模板", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z自动录入, true, false, this.LoadTempEvent);
			this.toolbarService.AddToolButton("删除", "删除当前记录", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, this.DeleteEvent);
            this.toolbarService.AddToolButton ( "项目" , "项目" , ( int ) Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室 , true , false , this.DeptEvent );
            this.toolbarService.AddToolButton ( "设备" , "设备" , ( int ) Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设备 , true , false , this.EquipmentEvent );
			this.InitArray();
			this.InitComb();
			this.InitTab();
			this.InitItem();
			
			
			this.InitControls();
			this.Retrieve();
            this.JudgeTmpFlag ( 0 );
			return this.toolbarService;
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucBookingArrange_DeleteEvent(object sender, EventArgs e)
		{
			this.Delete();
            this.JudgeTmpFlag ( this.neuTabControl1.SelectedIndex );
		}

		/// <summary>
		/// 调用模板
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucBookingArrange_LoadTempEvent(object sender, EventArgs e)
		{
			this.LoadTemplet();
            this.JudgeTmpFlag ( this.neuTabControl1.SelectedIndex );
		}

		/// <summary>
		/// 下一周
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucBookingArrange_NextWeekEvent(object sender, EventArgs e)
		{
			this.Next();
		}

		/// <summary>
		/// 上一周
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucBookingArrange_PriorWeekEvent(object sender, EventArgs e)
		{
			this.Prior();
		}
        /// <summary>
        /// 科室项目事件

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucBookingArrange_DeptEvent ( object sender , EventArgs e )
        {
            this.InitItem ( );
        }
        /// <summary>
        /// 科室设备事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucBookingArrange_EquipmentEvent ( object sender , EventArgs e )
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
		/// 科室选择控件发生改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuComboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.InitItem();
			this.Retrieve();
			for (int i = 0;i < 7;i++)
			{
				this.neuTabControl1.TabPages[i].Tag = "";
				controls[i].operEnvironment.Dept = this.GetDept();
				controls[i].operEnvironment.ID = this.operEnvironment.ID;
			}
		}

		/// <summary>
		/// Tab页改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
            int index = this.neuTabControl1.SelectedIndex;
            try
			{
				

				controls[index].operEnvironment.Dept = this.GetDept();
				controls[index].operEnvironment.ID = this.operEnvironment.ID;

				if (controls[index].IsChange())
				{
					if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						if (controls[index].Save() == -1)
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
            this.JudgeTmpFlag ( index );
			this.SetListVisiable();
		}

		/// <summary>
		/// Tab页改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTabControl1_Selected(object sender, TabControlEventArgs e)
		{
			int index = this.neuTabControl1.SelectedIndex;
			controls[index].operEnvironment.Dept = this.GetDept();
			controls[index].operEnvironment.ID = this.operEnvironment.ID;
			controls[index].Query(this.GetDept().ID, this.neuTabControl1.TabPages[index].Tag.ToString());
			this.neuTextBoxQuery.Focus();
		}

		/// <summary>
		/// 树双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTreeView1_DoubleClick(object sender, EventArgs e)
		{
			this.Add();
		}

		/// <summary>
		/// 查询按钮单击事件
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
				string Filter = this.neuTextBoxQuery.Text.Trim().ToUpper();

				foreach (TreeNode node in this.neuTreeView1.Nodes[0].Nodes)
				{
                    Neusoft.HISFC.Models.Terminal.MedTechItem tempItem  = (Neusoft.HISFC.Models.Terminal.MedTechItem)node.Tag;

					// 查询码实体
					Neusoft.HISFC.Models.Base.Spell spell = new Spell();
					
					// 获取查询码
					spell = this.bookingIntegrate.GetSpell(tempItem.Item.Name);

					if (spell.SpellCode.IndexOf(Filter, 0, spell.SpellCode.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
					if (tempItem.Item.ID.IndexOf(Filter, 0, tempItem.Item.ID.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
					if (tempItem.Item.Name.IndexOf(Filter, 0, tempItem.Item.Name.Length) >= 0)
					{
						this.neuTreeView1.Focus();
						this.neuTreeView1.SelectedNode = node;
						break;
					}
				}
			}
		}

		/// <summary>
		/// 查询框回车事件
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

		#endregion
	}
}
