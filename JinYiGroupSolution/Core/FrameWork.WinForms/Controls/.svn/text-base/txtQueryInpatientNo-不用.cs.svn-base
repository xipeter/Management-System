using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace neusoft.neuFC.Interface.Controls
{
	public delegate void myEventDelegate();
	/// <summary>
	/// txtQueryInpatientNo 的摘要说明。
	/// 查询住院流水号控件
	/// 输出：InpatientNos
	///		  InpatientNo
	///	环境：需要父窗体继承baseForm的类。	  
	/// </summary>
	public class txtQueryInpatientNo : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public txtQueryInpatientNo()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			// TODO: 在 InitializeComponent 调用后添加任何初始化
			Inpatient=new neusoft.HISFC.Management.RADT.InPatient();
		
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
			this.txtInputCode = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtInputCode
			// 
			this.txtInputCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputCode.Location = new System.Drawing.Point(0, 3);
			this.txtInputCode.Name = "txtInputCode";
			this.txtInputCode.Size = new System.Drawing.Size(167, 21);
			this.txtInputCode.TabIndex = 0;
			this.txtInputCode.Text = "";
			this.txtInputCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputCode_KeyDown);
			this.txtInputCode.TextChanged += new System.EventHandler(this.txtInputCode_TextChanged);
			// 
			// txtQueryInpatientNo
			// 
			this.Controls.Add(this.txtInputCode);
			this.Name = "txtQueryInpatientNo";
			this.Size = new System.Drawing.Size(167, 24);
			this.Load += new System.EventHandler(this.txtQueryInpatientNo_Load);
			this.ResumeLayout(false);

		}
		#endregion
		#region 私有变量
		private ArrayList alInpatientNos;
		private string strInpatientNo;
		private neusoft.HISFC.Management.RADT.InPatient Inpatient;
		private System.Windows.Forms.Form listform;
		private System.Windows.Forms.ListBox lst;
		
		private string strFormatHeader="";
		private int intDateType=0;
		private int intLength=10;
		#endregion
		#region 可控制公有属性、方法

		/// <summary>
		/// 住院号录入文本框
		/// </summary>
		public System.Windows.Forms.TextBox txtInputCode;
		/// <summary>
		/// 录入住院号文本格式化—补零（参数：住院号长度）
		/// </summary>
		/// <param name="Length"></param>
		public void SetFormat(int Length)
		{
			this.SetFormat("",0,Length);
		}
		/// <summary>
		/// 错误消息
		/// </summary>
		public string Err;
		/// <summary>
		/// 返回信息事件
		/// </summary>
		public event myEventDelegate myEvent;
		/// <summary>
		/// 得到多条住院流水号信息数组
		/// </summary>
		public  ArrayList InpatientNos
		{
			get
			{
				return this.alInpatientNos;
			}
		}
		/// <summary>
		/// 得到一条住院流水号信息
		/// </summary>
		public string InpatientNo
		{
			get
			{
				return this.strInpatientNo ;
			}
		}

		/// <summary>
		/// 住院号文本录入属性
		/// </summary>
		public new string Text
		{
			get
			{
				return this.txtInputCode.Text;
			}
			set
			{
				this.txtInputCode.Text=value;
			}
		}
		/// <summary>
		/// 录入住院号文本格式化—加字头（参数：字头字符；住院号长度）
		/// </summary>
		/// <param name="Header"></param>
		/// <param name="Length"></param>
		public void SetFormat(string Header,int Length)
		{
			this.SetFormat(Header,0,Length);
		}
		/// <summary>
		/// 录入住院号文本格式化—加字头添加日期（参数：字头字符；时间；住院号长度）
		/// </summary>
		/// <param name="Header"></param>
		/// <param name="DateType"></param>
		/// <param name="Length"></param>
		public void SetFormat(string Header,int DateType,int Length)
		{
			this.intLength=Length;
			this.strFormatHeader=Header;
			this.intDateType=DateType;
		}
		#endregion
		#region 不可控制私有属性、方法

		private void txtInputCode_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		private void txtInputCode_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.Text=this.formatInputCode(this.Text).Trim();
				this.Err="";
				try
				{
					this.alInpatientNos=this.Inpatient.QueryInpatientNoFromPatientNo(this.Text);
//					//
//					neusoft.neuFC.Object.neuObject obj = new neusoft.neuFC.Object.neuObject();
//					obj.ID = "1";
//					obj.Name="张";
//					obj.Memo= "在院";
//					this.alInpatientNos.Add(obj);
//					 obj = new neusoft.neuFC.Object.neuObject();
//					obj.ID = "2";
//					obj.Name="张";
//					obj.Memo= "在院";
//					this.alInpatientNos.Add(obj);

					//

					if(this.alInpatientNos==null)
					{
						this.Err="未查找到该住院号！";
						
					}
					if(this.alInpatientNos.Count==1) 
					{this.strInpatientNo=((neusoft.neuFC.Object.neuObject)this.alInpatientNos[0]).ID ;}
					else if(this.alInpatientNos.Count<=0)
					{
						this.Err="未查找到该住院号！";
						this.strInpatientNo="";
						NoInfo();
					}
					else
					{
						this.strInpatientNo=((neusoft.neuFC.Object.neuObject)this.alInpatientNos[0]).ID ;
						this.SelectPatient();
						return;
					}					
				}
				catch(Exception ex)
				{
					this.Err= ex.Message;
					NoInfo();
				}
				try
				{
					this.listform.Close();
					
				}
				catch{}
				try
				{
					this.myEvent();
				}
				catch{}

			}
		}
		private void SelectPatient()
		{
			lst=new ListBox();
			lst.Dock = System.Windows.Forms.DockStyle.Fill;

			this.listform=new Form();
			//用窗口显示			
			try
			{
				this.listform.Close();
			}
			catch{}
			listform.Size = new Size(200,100);
			listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; 
			
			for(int i=0;i<this.alInpatientNos.Count;i++)
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alInpatientNos[i];
				lst.Items.Add(obj.ID +"  "+obj.Name +"  "+obj.Memo);
			}
			
			lst.Visible=true;
			lst.DoubleClick+=new EventHandler(lst_DoubleClick);
			lst.KeyDown+=new KeyEventHandler(lst_KeyDown);
			lst.Show();
			
			listform.Controls.Add(lst);
			
			listform.TopMost=true;
			
			listform.Show();
			listform.Location = this.txtInputCode.PointToScreen(new Point(this.txtInputCode.Width/2+this.txtInputCode.Left ,this.txtInputCode.Height+this.txtInputCode.Top));
			try
			{
				lst.SelectedIndex = 0;
				lst.Focus();
				lst.LostFocus+=new EventHandler(lst_LostFocus);
			}
			catch{}
			return ;
		}
		private string formatInputCode(string Text)
		{
		
			string strText=Text;

			for(int i=0;i<this.intLength-strText.Length;i++)
			{
				Text="0"+Text;
			}	
			string strDateTime="";
			try
			{
				strDateTime=this.Inpatient.GetSysDateNoBar();
			}
			catch{}
			switch(this.intDateType)
			{
				case 1:
					strDateTime=strDateTime.Substring(2);
					Text=strDateTime+Text.Substring(strDateTime.Length);
					break;
				case 2:
					Text=strDateTime+Text.Substring(strDateTime.Length);
					break;
			}
			if(this.strFormatHeader!="")Text=this.strFormatHeader+Text.Substring(this.strFormatHeader.Length);

			//日期   
			return Text;
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
		}
		private void GetInfo()
		{
			try
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alInpatientNos[lst.SelectedIndex];
				this.strInpatientNo = obj.ID ;
				try
				{
					this.listform.Hide ();
				}
				catch
				{
					
				}
				this.myEvent();
			}
			catch{NoInfo();}
		}
		private void NoInfo()
		{
			this.txtInputCode.SelectAll();
			this.txtInputCode.Focus();
		}

		private void txtQueryInpatientNo_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.Inpatient.Connection =((neusoft.neuFC.Interface.Forms.BaseForm)this.ParentForm).var.con;
				this.Inpatient.Sql =((neusoft.neuFC.Interface.Forms.BaseForm)this.ParentForm).var.Sql;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}	
			
		}

	
		private void lst_LostFocus(object sender, EventArgs e)
		{
			this.listform.Hide();
		}
		
		#endregion
		
	}
}
