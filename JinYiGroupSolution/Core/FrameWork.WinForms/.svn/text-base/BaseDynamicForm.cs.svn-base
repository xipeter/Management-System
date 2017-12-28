using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
namespace Neusoft.NFC.Interface.Forms
{
	/// <summary>
	/// BaseUserControl 的摘要说明。
	/// 继承过来控件实现窗口的动态设置
	/// 步骤：
	/// <cr>1、设置保存的文件名或ftp设置传入。FileInfo=?;Ftp=?;</cr>
	/// <cr>2、初始化控件。void init()</cr>
	/// <cr>3、需要更改窗体就调用isDesignMode=true;</cr>
	/// </summary>
	public class BaseUserControl :BaseForm
	{
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern long SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		static private extern long ReleaseCapture();

		private const int WM_NCLBUTTONDOWN = 0x00A1;
		private const int HTCAPTION = 2;
		private const int HTBORDER = 18;
		private const int HTLEFT = 10;
		private const int HTBOTTOM = 15;
		private const int HTRIGHT = 11;
		private const int HTTOP = 12;
		private const int HTBOTTOMLEFT = 16;
		private const int HTBOTTOMRIGHT = 17;
		private const int HTTOPLEFT = 13;
		private const int HTTOPRIGHT = 14;
		private const int WM_MOUSEMOVE = 0x0200;
		private const int WM_ACTIVATE = 6;
	
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.PropertyGrid propertyGrid1;
		public System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.LinkLabel lnkSave;
		private System.Windows.Forms.CheckBox chkShowDefault;
		private System.Windows.Forms.LinkLabel lnkShowAllControl;
		private System.ComponentModel.IContainer components=null;

		public BaseUserControl(BaseVar var):base(var)
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			this.panelMain.Click+=new EventHandler(panelMain_Click);
			FileInfo=new Neusoft.NFC.Object.NeuFileInfo();
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
			this.lnkSave = new System.Windows.Forms.LinkLabel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lnkShowAllControl = new System.Windows.Forms.LinkLabel();
			this.chkShowDefault = new System.Windows.Forms.CheckBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panelMain = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lnkSave
			// 
			this.lnkSave.Location = new System.Drawing.Point(96, 40);
			this.lnkSave.Name = "lnkSave";
			this.lnkSave.Size = new System.Drawing.Size(56, 16);
			this.lnkSave.TabIndex = 0;
			this.lnkSave.TabStop = true;
			this.lnkSave.Text = "保存配置";
			this.lnkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSave_LinkClicked);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lnkShowAllControl);
			this.groupBox1.Controls.Add(this.chkShowDefault);
			this.groupBox1.Controls.Add(this.propertyGrid1);
			this.groupBox1.Controls.Add(this.lnkSave);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 517);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "设置窗体";
			// 
			// lnkShowAllControl
			// 
			this.lnkShowAllControl.Location = new System.Drawing.Point(8, 40);
			this.lnkShowAllControl.Name = "lnkShowAllControl";
			this.lnkShowAllControl.Size = new System.Drawing.Size(72, 16);
			this.lnkShowAllControl.TabIndex = 4;
			this.lnkShowAllControl.TabStop = true;
			this.lnkShowAllControl.Text = "显示全部";
			this.lnkShowAllControl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowAllControl_LinkClicked);
			// 
			// chkShowDefault
			// 
			this.chkShowDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkShowDefault.Location = new System.Drawing.Point(8, 16);
			this.chkShowDefault.Name = "chkShowDefault";
			this.chkShowDefault.Size = new System.Drawing.Size(96, 16);
			this.chkShowDefault.TabIndex = 3;
			this.chkShowDefault.Text = "使用默认窗体";
			this.chkShowDefault.CheckedChanged += new System.EventHandler(this.chkShowDefault_CheckedChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(3, 64);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(170, 445);
			this.propertyGrid1.TabIndex = 2;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(176, 0);
			this.splitter1.MinExtra = 0;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 517);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panelMain
			// 
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(184, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(384, 517);
			this.panelMain.TabIndex = 3;
			this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
			// 
			// BaseUserControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 517);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Name = "BaseUserControl";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		

		private bool bisDesignMode;
		private bool bisShowDefault;
		private bool bisDrawGrid=true;
		public bool isEnterToTab=true;

		private Neusoft.NFC.Xml.XML myXml=new Neusoft.NFC.Xml.XML();
		/// <summary>
		/// 需要设置的文件信息
		/// </summary>
		public Neusoft.NFC.Object.NeuFileInfo FileInfo;
		/// <summary>
		/// 如果保存到服务器上，需要设置的服务器信息
		/// </summary>
		public Neusoft.NFC.Management.File ManagerFile;
		
		/// <summary>
		/// 必须调的函数
		/// </summary>
		public void init()
		{
			AddHandle();
			ReadFile();
			this.groupBox1.Name="设置" +FileInfo.FileFullPath;
		}
		private void AddHandle()
		{
			foreach(Control c in this.panelMain.Controls)
			{
				c.MouseDown+=new MouseEventHandler(c_MouseDown);
				c.MouseMove+=new MouseEventHandler(c_MouseMove);
				c.KeyUp+=new KeyEventHandler(c_KeyUp);
			}
			return;
		}
		protected XmlDocument doc;
		#region 事件
		
		private void chkShowDefault_CheckedChanged(object sender, System.EventArgs e)
		{
			this.isShowDefault=this.chkShowDefault.Checked;
		}
		#endregion
		#region "属性"
		/// <summary>
		/// 显示/设置模式
		/// </summary>
		public bool isDesignMode
		{
			get
			{
				return this.bisDesignMode;
			}
			set
			{
				this.bisDesignMode=value;
				this.splitter1.Visible=this.bisDesignMode;
				this.groupBox1.Visible=this.bisDesignMode;
				this.panelMain.Refresh();
			}
		}
		public bool isDrawGrid
		{
			get
			{
				return this.bisDrawGrid;
			}
			set
			{
				this.bisDrawGrid=value;

			}
		}
		
		/// <summary>
		/// 显示默认窗体
		/// </summary>
		public bool isShowDefault
		{
			get
			{
				return this.bisShowDefault;
			}
			set
			{
				this.bisShowDefault=value;
			}
		}
		#endregion
		#region "窗体配置函数"
		private void DrawGrid()
		{
			int i,j;
			Graphics g=this.panelMain.CreateGraphics();
			Pen pen=new Pen(Color.Blue);
			
			pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
			SolidBrush drawBrush = new SolidBrush(Color.Black);

			try
			{
				for(i=0;i<this.panelMain.Height;i=i+20)
				{
					try
					{
						g.DrawString(i.ToString(),new Font(this.Font.FontFamily,6),drawBrush,new Point(0,i));
						g.DrawLine(pen,0,i,this.panelMain.Width,i);

					}
					catch{}
				}
				for(j=0;j<this.panelMain.Width;j=j+20)
				{
					g.DrawString(j.ToString(),new Font(this.Font.FontFamily,6),drawBrush,new Point(j,0));
					g.DrawLine(pen,j,0,j,this.panelMain.Height );

				}
			}
			catch{}
			
		}
		/// <summary>
		/// 保存控件配置
		/// </summary>
		private void SaveFile()
		{
			XmlDocument doc=new XmlDocument();
			//不显示默认
			XmlElement root=myXml.CreateRootElement(doc,"UserControl","1.0");
			root.SetAttribute("ShowDefault",this.isShowDefault.ToString());
			root.SetAttribute("BackColor",this.panelMain.BackColor.ToArgb().ToString());
			if(this.isShowDefault)//保存默认，留者以前的。
			{
				try
				{
					root.InnerXml  =this.doc.SelectSingleNode("//UserControl").InnerXml;
				}
				catch{return;}
			}
			else
			{
				XmlElement ControlElement;
				//加入controls property
				try
				{
						foreach(Control c in this.panelMain.Controls)
				 {
					 ControlElement=doc.CreateElement("Control");
					 myXml.AddXmlNode(doc,ControlElement,"Name",c.Name);
					 myXml.AddXmlNode(doc,ControlElement,"X",c.Left.ToString());
					 myXml.AddXmlNode(doc,ControlElement,"Y",c.Top.ToString());
					 myXml.AddXmlNode(doc,ControlElement,"Width",c.Width.ToString());
					 myXml.AddXmlNode(doc,ControlElement,"Height",c.Height.ToString());
					 myXml.AddXmlNode(doc,ControlElement,"ForeColor",c.ForeColor.ToArgb().ToString());
					 myXml.AddXmlNode(doc,ControlElement,"BackColor",c.BackColor.ToArgb().ToString());
					 myXml.AddXmlNode(doc,ControlElement,"Text",c.Text );
					 myXml.AddXmlNode(doc,ControlElement,"TabIndex",c.TabIndex.ToString() );
					 myXml.AddXmlNode(doc,ControlElement,"Visible",c.Visible.ToString());
					 root.AppendChild(ControlElement);
				 }
				}
				catch{return;}
			}
			try
			{
				if(FileInfo.FileFullPath.Trim().Substring(0,4).ToLower()=="http")
				{
					doc.Save(".\\tmp\\"+ FileInfo.Name);
					ManagerFile.SaveFile(".\\tmp\\"+ FileInfo.Name ,FileInfo);
				}
				else
				{
					doc.Save(FileInfo.FileFullPath);
				}
			}
			catch{}

		}
		private void ReadFile()
		{	
			
			doc=myXml.LoadXml(FileInfo.FileFullPath);
			if(doc==null)
			{
				this.chkShowDefault.Checked =true;
				return;
			}
			XmlNode node;
			try
			{
				node=doc.SelectSingleNode("//UserControl");
				if((node.Attributes["ShowDefault"].Value).ToLower()=="false")
				{
					this.chkShowDefault.Checked=false;
				}
				else
				{
					this.chkShowDefault.Checked=true;
				}
			}
			catch{return;}
			if(this.isShowDefault) return;
			try
			{
				this.panelMain.BackColor=Color.FromArgb(int.Parse(node.Attributes["BackColor"].Value.ToString()));
			}
			catch{}
			foreach(XmlNode thisNode in node.ChildNodes)
			{	
				try
				{
					string strName=thisNode["Name"].InnerText;
					string strForeColor=thisNode["ForeColor"].InnerText;
					string strBackColor=thisNode["BackColor"].InnerText;
					System.Drawing.Point p=new Point(int.Parse(thisNode["X"].InnerText),int.Parse(thisNode["Y"].InnerText));
					System.Drawing.Size s=new Size(int.Parse(thisNode["Width"].InnerText),int.Parse(thisNode["Height"].InnerText));
					bool bVisible=bool.Parse(thisNode["Visible"].InnerText);
					string strText=thisNode["Text"].InnerText;
					string strTabIndex=thisNode["TabIndex"].InnerText;
					this.AddControl(ref this.panelMain,strName,p,s,strForeColor,strBackColor,bVisible,strText,strTabIndex);

				}
				catch{}
			}
		}
		private void AddControl(ref Panel myPanel,string name,Point p,Size s,string strForeColor,string strBackColor,bool bVisible,string strText,string strTabIndex)
		{
			try
			{
				foreach(Control c in myPanel.Controls)
				{
					if(c.Name==name)
					{
						c.Location=new Point(p.X,p.Y);
						c.Size=new Size(s.Width,s.Height);
						c.ForeColor =Color.FromArgb(int.Parse(strForeColor));
						c.BackColor=Color.FromArgb(int.Parse(strBackColor));
						c.Visible=bVisible;
						c.TabIndex=int.Parse(strTabIndex);
						try
						{
							c.Text=strText;
						}
						catch{}
						return;
					}
				}
			}
			catch{}
		}
		private void MoveControl(System.Object sender,System.Windows.Forms.MouseEventArgs e,int i,int j)
		{	
			Control c=new Control();
			c=(Control)sender;
			IntPtr hWnd;
			hWnd=c.Handle;
			ReleaseCapture();
			if(e.X<i)
			{
				if(e.Y<i)
				{
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPLEFT, 0);
				}
				else if (e.Y>c.Height-i-j)
				{
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMLEFT, 0);
				}
				else
				{
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTLEFT, 0);

				}
			}
			else if(e.X >c.Width -i-j)
			{
				if(e.Y < i)
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);
				else if( e.Y > c.Height - i - j)
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMRIGHT, 0);
				else 
					SendMessage(hWnd, WM_NCLBUTTONDOWN, HTRIGHT, 0);
			}
			else if(e.Y>c.Height-i-j)
			{
				SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOM, 0);
			}
			else if(e.Y<i)
			{
				SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOP, 0);
			}
			else
			{
				SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
			ReleaseCapture();

		}
		public void ChangeCursor(System.Object sender,System.Windows.Forms.MouseEventArgs e,int i,int j)
		{
			Control c=new Control();
			c=(Control)sender;
			if(e.X < i)
			{
				if(e.Y < i)
					c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
				else if(e.Y > c.Height - i - j)
					c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
				else
					c.Cursor = System.Windows.Forms.Cursors.SizeWE;
				             
			} 
			else if(e.X > c.Width - i - j)
			{
			
				if (e.Y < i )
					c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
				else if (e.Y > c.Height - i - j) 
					c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
				else
					c.Cursor = System.Windows.Forms.Cursors.SizeWE;
			} 
			else if (e.Y > c.Height - i - j )
				c.Cursor = System.Windows.Forms.Cursors.SizeNS;
			else if (e.Y < i )
				c.Cursor = System.Windows.Forms.Cursors.SizeNS;
			else
				c.Cursor = System.Windows.Forms.Cursors.SizeAll;
		}
		#endregion

		private void lnkSave_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			SaveFile();
		}

		private void c_MouseDown(object sender, MouseEventArgs e)
		{
			if(this.isDesignMode)this.MoveControl(sender,e,4,0);
			this.propertyGrid1.SelectedObject=sender;
		}

		private void c_MouseMove(object sender, MouseEventArgs e)
		{
			if(this.isDesignMode) this.ChangeCursor(sender, e, 4, 0);
		}

		private void panelMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(this.isDesignMode && this.isDrawGrid)this.DrawGrid();
		}

		private void lnkShowAllControl_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			foreach(Control c in this.panelMain.Controls)
			{
				c.Visible=true;
				c.Enabled=true;
			}
			return;
		}

		private void panelMain_Click(object sender, EventArgs e)
		{
			this.propertyGrid1.SelectedObject=sender;
		}

		private void c_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter && this.isEnterToTab)  System.Windows.Forms.SendKeys.Send("{tab}");
		}

		
	}
}
