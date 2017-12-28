using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
namespace neusoft.neuFC.Interface.Controls
{
	/// <summary>
	/// ComboBox 的摘要说明。
	/// </summary>
	public class ComboBox:System.Windows.Forms.ComboBox 
	{
		private System.ComponentModel.IContainer components;

		public ComboBox(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			container.Add(this);
			InitializeComponent();
			this.KeyDown+=new System.Windows.Forms.KeyEventHandler(ComboBox_KeyDown);
			this.Leave+=new EventHandler(ComboBox_Leave);
			
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		
		public ComboBox()
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			InitializeComponent();

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


		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
		
		#region "myCode"
		public ArrayList alItems;
		public bool isItemOnly;
		protected bool bShowCustomerList=true;
		protected Form frmPop;
		protected bool bShowID;
		/// <summary>
		/// 显示自定义列表
		/// </summary>
		public bool ShowCustomerList
		{
			get
			{
				return this.bShowCustomerList;
			}
			set
			{
				this.bShowCustomerList=value;
			}
		}
		public new object  Tag
		{
			get
			{
				if(this.Text.Trim()=="") base.Tag="";
				return base.Tag;
			}set
			 {
				 int i;
				 try
				 {
					 for(i=0;i<alItems.Count;i++)
					 {
						 try
						 {
							 string sValue=((neusoft.neuFC.Object.neuObject)alItems[i]).ID.ToString();
							 if(value.ToString()==sValue)
							 {
								 base.Text=((neusoft.neuFC.Object.neuObject)alItems[i]).Name;
								 break;
							 }
						 }
						 catch(Exception ex){string s=ex.Message;}
					 }
					
				 }
				 catch{}
				 base.Tag=value;
			 }
			
			
		}

		public int AddItems(ArrayList Items)
		{
			base.Items.Clear();
			alItems=new ArrayList();
			alItems=Items;
			neusoft.neuFC.Object.neuObject objItem;
			int i;
			try
			{
				for(i=0;i<alItems.Count;i++)
				{
					objItem=new neusoft.neuFC.Object.neuObject();
					objItem=(neusoft.neuFC.Object.neuObject)alItems[i];
					if(this.bShowID) 
						base.Items.Add(objItem.ID);
					else
						base.Items.Add(objItem.Name);
				}
			}
			catch
			{
				return -1;
			}
			if(this.bShowCustomerList)
			{
				this.DrawMode=DrawMode.OwnerDrawFixed;
				this.MouseDown+=new MouseEventHandler(ComboBox_MouseDown);
			}
			else
			{
				this.DrawMode=DrawMode.Normal;
			}

			return 0;
		}
		
		public Form PopForm
		{
			get
			{
				return this.frmPop;
			}
			set
			{
				this.frmPop=value;
			}
		}
		public bool ShowID
		{
			get
			{
				return this.bShowID;
			}
			set
			{
				this.bShowID=value;
			}
		}
		#endregion

		#region 函数
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			try
			{
				base.Tag=((neusoft.neuFC.Object.neuObject)(alItems[this.SelectedIndex])).ID;
			}
			catch
			{}
			base.OnSelectedIndexChanged (e);
		}
		protected void ComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode==System.Windows.Forms.Keys.Enter)
			{
				if(base.Text=="" )return;
				if(base.Text==" " || base.Text=="  " || base.Text=="   ")
				{
					ShowSelectDialog();
					return;
				}
				try
				{
					for(int i=0;i<alItems.Count;i++)
					{
						neusoft.neuFC.Object.neuObject o=(neusoft.neuFC.Object.neuObject)alItems[i];
						try
						{
							if(o.Name.ToUpper().Trim()==base.Text.ToUpper().Trim())
							{
								base.Text=o.Name;
								return;
							}
						}
						catch{}	
						try
						{
							if(o.ID.ToUpper().Trim()==base.Text.ToUpper().Trim())
							{
								base.Text=o.Name;
								return;
							}
						}
						catch{}
						try
						{
							if(o.Memo.ToUpper().Trim()==base.Text.ToUpper().Trim())
							{
								base.Text=o.Name;
								return;
							}
						}
						catch{}
						try
						{
							neusoft.HISFC.Object.Base.ISpellCode Spell =o as neusoft.HISFC.Object.Base.ISpellCode;
							switch(iSpellCode)
							{
								case 0:
									if(Spell.Spell_Code.ToUpper().Trim()==base.Text.ToUpper().Trim())
									{
										base.Text=o.Name;
										return;
									}
									break;
								case 1:
									if(Spell.WB_Code.ToUpper().Trim()==base.Text.ToUpper().Trim())
									{
										base.Text=o.Name;
										return;
									}
									break;
								case 2:
									if(Spell.User_Code.ToUpper().Trim()==base.Text.ToUpper().Trim())
									{
										base.Text=o.Name;
										return;
									}
									break;
							}
						}
						catch{}
					}
					if(this.isItemOnly) base.Text="";
				}
				catch
				{
					if(this.isItemOnly) base.Text="";
				}
			}
			else if(e.KeyCode==Keys.F2)
			{
				iSpellCode++;
				if(iSpellCode>=3) iSpellCode=0;
				QueryType= "拼音码";
				switch (iSpellCode)
				{
					case 0:
						QueryType= "拼音码";
						this.BackColor=Color.FromArgb(255,255,255);
						break;
					case 1:
						this.BackColor=Color.FromArgb(255,200,200);
						QueryType= "五笔码";
						break;
					case 2:
						this.BackColor=Color.FromArgb(255,150,150);
						QueryType= "自定义码";
						break;
					default:
						this.BackColor=Color.FromArgb(255,255,255);
						break;
				}
			}
		}
		protected int iSpellCode=0;
		protected string QueryType="拼音码";
		private void ComboBox_Leave(object sender, EventArgs e)
		{
			if(base.Text=="")return;
			try
			{
				for(int i=0;i<alItems.Count;i++)
				{
					neusoft.neuFC.Object.neuObject o=(neusoft.neuFC.Object.neuObject)alItems[i];
					try
					{
						if(o.Name.ToUpper().Trim()==base.Text.ToUpper().Trim())
						{
							base.Text=o.Name;
							return;
						}
					}
					catch{}	
					try
					{
						if(o.ID.ToUpper().Trim()==base.Text.ToUpper().Trim())
						{
							base.Text=o.Name;
							return;
						}
					}
					catch{}
					try
					{
						if(o.Memo.ToUpper().Trim()==base.Text.ToUpper().Trim())
						{
							base.Text=o.Name;
							return;
						}
					}
					catch{}
				}
				if(this.isItemOnly) base.Text="";
			}
			catch
			{
				if(this.isItemOnly) base.Text="";
			}
		}
		
		/// <summary>
		/// 显示弹出选择窗体
		/// </summary>
		protected void ShowSelectDialog()
		{
			try
			{
				frmPop.ShowDialog();
			}
			catch
			{
				SetPopForm();
			}
		}
		protected void SetPopForm()
		{
			frmPop = new System.Windows.Forms.Form();
			frmPop.Text="请选择项目";
			frmPop.Size = new Size(400,200);
			frmPop.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			frmPop.StartPosition=FormStartPosition.CenterScreen;
			frmPop.Controls.Add(SetPopList());
			frmPop.ShowDialog();
		}
		protected ListBox SetPopList()
		{
			
			poplst=new ListBox();
			poplst.Dock = System.Windows.Forms.DockStyle.Fill;
			for(int i=0;i<this.alItems.Count;i++)
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alItems[i];
				string s="";
				s = obj.ID.PadRight(6,' ') +"  "+obj.Name.PadRight(10,' ') +"  "+obj.Memo.PadRight(10,' ')+"  ";
				try
				{
					neusoft.HISFC.Object.Base.ISpellCode Spell =obj as neusoft.HISFC.Object.Base.ISpellCode;
					try
					{
						if(Spell.Spell_Code!=null)s=s + Spell.Spell_Code.PadRight(10,' ');
					}
					catch{}
					try
					{
						if(Spell.WB_Code!=null)s=s + Spell.WB_Code.PadRight(10,' ');
					}
					catch{}
					try
					{
						if(Spell.User_Code!=null)s=s + Spell.User_Code.PadRight(10,' ');
					}
					catch{}
				}
				catch{}
				poplst.Items.Add(s);
			}
		
			poplst.Visible=true;
			poplst.DoubleClick+=new EventHandler(lst_DoubleClick);
			poplst.KeyDown+=new KeyEventHandler(lst_KeyDown);
			return poplst;
		}
		#endregion
		#region 显示下拉列表
		Form listform;
		ListBox lst;
		ListBox poplst;
		private void SetList()
		{
			lst=new ListBox();
			lst.Dock = System.Windows.Forms.DockStyle.Fill;

			
			for(int i=0;i<this.alItems.Count;i++)
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alItems[i];
				lst.Items.Add(obj.ID.PadRight(6,' ') +"  "+obj.Name.PadRight(10,' ') +"  "+obj.Memo);
			}
			
			lst.Visible=true;
			lst.DoubleClick+=new EventHandler(lst_DoubleClick);
			lst.KeyDown+=new KeyEventHandler(lst_KeyDown);
//			lst.Show();
			
		}
		private void SetForm()
		{
			this.listform=new Form();
			//用窗口显示			
			try
			{
				this.listform.Close();
			}
			catch{}
			listform.Text="请选择项目";
			listform.Size = new Size(200,100);
			//listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; 
			listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			lst.BorderStyle=BorderStyle.FixedSingle;
			listform.TopMost=true;
			listform.Show();
			listform.Location = this.PointToScreen(new Point(0 ,this.Height));
			listform.Controls.Add(lst);
		}
		private void ShowSelectItem()
		{
			if(this.alItems==null || this.alItems.Count<=0) return;
			try
			{
				if(listform.Visible) 
				{
					listform.Hide();
					return;
				}
			}
			catch{}
			if(lst==null)
			{
				this.SetList();
			}
			
			if(this.listform==null)
			{
				this.SetForm();
			}
			try
			{
				listform.Show();
			}
			catch
			{
				this.SetList();
				this.SetForm();
			}
			try
			{
				lst.SelectedIndex = 0;
				lst.Focus();
				lst.LostFocus+=new EventHandler(lst_LostFocus);
			}
			catch{}
			return ;
		}
		
		private void lst_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GetInfo();
			}
			catch{}
		}

		private void lst_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter )
			{
				GetInfo();
			}
			else if(e.KeyCode==Keys.Escape)
			{
				this.CloseForm();
			}
		}
		private void GetInfo()
		{
			try
			{
				neusoft.neuFC.Object.neuObject obj=null;
				try
				{
					if(lst.Visible)obj=(neusoft.neuFC.Object.neuObject)this.alItems[lst.SelectedIndex];
				}
				catch{}
				try
				{
					if(poplst.Visible)	obj=(neusoft.neuFC.Object.neuObject)this.alItems[poplst.SelectedIndex];
				}
				catch{}
				this.Tag  = obj.ID ;
				this.CloseForm();
			}
			catch{}
		}
		private void CloseForm()
		{
			try
			{
				if(listform.Visible)this.listform.Hide();
			}
			catch
			{
					
			}
			try
			{
				if(frmPop.Visible)this.frmPop.Hide();
			}
			catch
			{
					
			}
		}
		private void lst_LostFocus(object sender, EventArgs e)
		{
			try
			{
				if(listform.Visible)this.listform.Hide();
			}
			catch{}
		}
		private void ComboBox_MouseDown(object sender, MouseEventArgs e)
		{
			if(this.bShowCustomerList) 
			{
				if(e.X>this.Width-20)
						ShowSelectItem();
			}
		}
		#endregion
	}


}
