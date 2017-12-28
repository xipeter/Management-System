using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crownwood.Magic.Common;
using Crownwood.Magic.Docking;
namespace Neusoft.FrameWork.WinForms.Forms
{
	/// <summary>
	/// Magic基类窗口 created by wolf 2004-6-21
	/// 实现Magic窗口的功能
	/// 继承于BaseForm
	/// </summary>
	public class BaseMagic : BaseForm
	{
		private System.ComponentModel.IContainer components;

		
		public BaseMagic():base()
		{
			initDockingManager();
			InitializeComponent();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BaseMagic));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BaseMagic
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 397);
			this.Name = "BaseMagic";
			this.Text = "BaseMagic";

		}
		#endregion

		/// <summary>
		/// ImageList
		/// </summary>
		public System.Windows.Forms.ImageList imageList1;

		/// <summary>
		/// 主控制
		/// </summary>
		protected Crownwood.Magic.Docking.DockingManager dockingManager;

		/// <summary>
		/// 初始化DockingManager
		/// </summary>
		protected void initDockingManager()
		{
			dockingManager=new Crownwood.Magic.Docking.DockingManager(this,VisualStyle.IDE);
		}

		#region 作废
		/// <summary>
		/// 设置控件内部／外部
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="type"> 'type=0 内部control 'type=1 外部control</param>
		[Obsolete("用SetInOrOut代替了",true)]
		public void _setInOrOut(Control Control,int type)
		{
			if(type==0)
				this.dockingManager.InnerControl=Control;
			else
				this.dockingManager.OuterControl=Control;
		}
		/// <summary>
		/// 设置内部控件
		/// </summary>
		/// <param name="Control"></param>
		[Obsolete("用SetInOrOut代替了",true)]
		public void _setInOrOut(Control Control)
		{
			this._setInOrOut(Control,0);
		}
		/// <summary>
		///  '添加Pad
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="Control"></param>
		/// <param name="size"></param>
		/// <param name="imageIndex"></param>
		[Obsolete("用AddPad代替了",true)]
		public void _addPad( Content pad,Control Control,System.Drawing.Size size,int imageIndex)
		{
			try
			{

				if(pad ==null)pad=new Content(this.dockingManager);
				if(Control.Text !="")
				{
					pad.Title = Control.Text;
					pad.FullTitle = Control.Text;
				}
				
				pad.Control=Control;
				try
				{
					pad.ImageList=this.imageList1;
					pad.ImageIndex=imageIndex;
				}
				catch
				{
				}
				pad.FloatingSize=size;
				this.dockingManager.Contents.Add(pad);
			}
			catch
			{
			}
		}
		[Obsolete("用AddPad代替了",true)]
		public void _addPad( Content pad,Control Control,System.Drawing.Size size)
		{
			this._addPad(pad,Control,size,0);
		}
		[Obsolete("用AddPad代替了",true)]
		public void _addPad( Content pad,Control Control)
		{
			this._addPad(pad,Control,new System.Drawing.Size(200,300),0);
		}
		/// <summary>
		/// 显示pad
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="State"></param>
		[Obsolete("用ShowPad代替了",true)]
		public void _showPad( Content pad,State State)
		{
			WindowContent wc = new WindowContent(this.dockingManager,VisualStyle.IDE);
			wc = this.dockingManager.AddContentWithState(pad,State);
			this.dockingManager.AddContentToWindowContent (pad,wc);
			this.dockingManager.ShowContent(pad);
		}
		/// <summary>
		/// 显示所有列表
		/// </summary>
		[Obsolete("用ShowAllPad代替了",true)]
		public void _showAllPad()
		{
			this.dockingManager.ShowAllContents();
		}
		#endregion

		/// <summary>
		/// 设置控件内部／外部
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="type"> 'type=0 内部control 'type=1 外部control</param>
		protected void SetInOrOut(Control Control,int type)
		{
			if(type==0)
				this.dockingManager.InnerControl=Control;
			else
				this.dockingManager.OuterControl=Control;

		}
		/// <summary>
		/// 设置内部控件
		/// </summary>
		/// <param name="Control"></param>
		protected void SetInOrOut(Control Control)
		{
			this.SetInOrOut(Control,0);
		}
		/// <summary>
		///  添加Pad,pad可以是Null，内部进行实例化
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="Control"></param>
		/// <param name="size"></param>
		/// <param name="imageIndex"></param>
		protected void AddPad( Content pad,Control Control,System.Drawing.Size size,int imageIndex)
		{
			try
			{

				if(pad == null) pad = new Content(this.dockingManager);
				if(Control.Text != "")
				{
					pad.Title = Control.Text;
					pad.FullTitle = Control.Text;
				}
				
				pad.Control = Control;
				if(this.imageList1 != null)
				{
					pad.ImageList = this.imageList1;
					pad.ImageIndex = imageIndex;
				}
			
				pad.FloatingSize = size;
				this.dockingManager.Contents.Add(pad);
			}
			catch
			{

			}
		}
		/// <summary>
		/// 添加Pad,pad可以是Null，内部进行实例化
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="Control"></param>
		/// <param name="size"></param>
		protected void AddPad( Content pad,Control Control,System.Drawing.Size size)
		{
			this.AddPad(pad,Control,size,0);
		}
		/// <summary>
		/// 添加Pad,pad可以是Null，内部进行实例化
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="Control"></param>
		protected void AddPad( Content pad,Control Control)
		{
			this.AddPad(pad,Control,new System.Drawing.Size(200,300),0);
		}
		/// <summary>
		/// 显示pad的位置
		/// </summary>
		/// <param name="pad"></param>
		/// <param name="State"></param>
		protected void ShowPad( Content pad,State State)
		{
			WindowContent wc = new WindowContent(this.dockingManager,VisualStyle.IDE);
			wc = this.dockingManager.AddContentWithState(pad,State);
			this.dockingManager.AddContentToWindowContent (pad,wc);
			this.dockingManager.ShowContent(pad);
		}
		/// <summary>
		/// 显示所有列表
		/// </summary>
		protected void ShowAllPad()
		{
			this.dockingManager.ShowAllContents();
		}
	}
}
