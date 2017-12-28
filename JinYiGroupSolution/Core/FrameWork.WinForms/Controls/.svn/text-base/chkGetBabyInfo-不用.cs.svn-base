using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace neusoft.neuFC.Interface.Controls
{
	public delegate void myDelegate();
	/// <summary>
	/// chkGetBabyInfo 的摘要说明。
	/// </summary>
	public class chkGetBabyInfo : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public chkGetBabyInfo()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			this.Load+=new EventHandler(chkGetBabyInfo_Load);
			// TODO: 在 InitializeComponent 调用后添加任何初始化
			GetBabyInfo =new neusoft.HISFC.Management.RADT.InPatient();

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
			this.chkIsBaby = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkIsBaby
			// 
			this.chkIsBaby.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkIsBaby.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkIsBaby.Location = new System.Drawing.Point(0, 0);
			this.chkIsBaby.Name = "chkIsBaby";
			this.chkIsBaby.Size = new System.Drawing.Size(120, 32);
			this.chkIsBaby.TabIndex = 0;
			this.chkIsBaby.Text = "是否婴儿";
			this.chkIsBaby.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkIsBaby.CheckedChanged += new System.EventHandler(this.chkIsBaby_CheckedChanged);
			// 
			// chkGetBabyInfo
			// 
			this.Controls.Add(this.chkIsBaby);
			this.Name = "chkGetBabyInfo";
			this.Size = new System.Drawing.Size(120, 32);
			this.ResumeLayout(false);

		}
		#endregion
		#region 私有变量
		private ArrayList alBabyInfo;
		private neusoft.HISFC.Management.RADT.InPatient GetBabyInfo;
		private System.Windows.Forms.Form listform;
		private System.Windows.Forms.ListBox lst;
		#endregion 

		#region  可控制公有属性、方法
		public System.Windows.Forms.CheckBox chkIsBaby;
		public string strPatientno;
		public bool bIsBaby=false;
		public string strBabyNo="";
		public bool AutoHide=true;
		public string Err;
		/// <summary>
		/// 返回信息事件
		/// </summary>
		public event myDelegate myEvent;
		/// <summary>
		/// 得到多个婴儿信息数组
		/// </summary>
		public ArrayList BabysInfo
		{
			get
			{
				return this.alBabyInfo;
			}

		}
		/// <summary>
		/// 控件文本框显示
		/// </summary>
		public string txtShow
		{
			get
			{
				return this.chkIsBaby.Text;
			}
			set
			{
				this.chkIsBaby.Text = value;
			}
		}
		/// <summary>
		/// 患者住院号（录入）
		/// </summary>
		public  string Inpatientno
		{
			set
			{
				try
				{
					this.Err="";
					this.strPatientno = value.Trim();
					this.CheckBabys();
					this.chkIsBaby.Checked=false;
					if(this.alBabyInfo.Count<=0) 
						this.chkIsBaby.Enabled =false;
					else
						this.chkIsBaby.Enabled =true;
				}
				catch{this.chkIsBaby.Enabled =false;}
			}
		}
		/// <summary>
		/// 婴儿序号
		/// </summary>
		public  string BabyNo
		{
			get
			{
				return this.strBabyNo;
			}
		}
		/// <summary>
		/// 是否婴儿
		/// </summary>
		public  bool IsBaby
		{
			get
			{
				return this.bIsBaby ;
			}
		}
		#endregion

		#region  不可控制私有属性、方法
		private void chkIsBaby_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkIsBaby.Checked)
			{
				try
				{
					if(this.alBabyInfo==null)
					{
					
						this.Err="未查找到该患者所属的婴儿！";
						
					}
					if(this.alBabyInfo.Count==1) 
					{
						this.strBabyNo =((neusoft.neuFC.Object.neuObject)this.alBabyInfo[0]).ID ;
						this.bIsBaby = true;
					}
					else if(this.alBabyInfo.Count<=0)
					{
						this.Err="未查找到该患者所属的婴儿！";
						this.strBabyNo="";
						this.bIsBaby = false;
					}
					else
					{
						this.SelectBabys();
						return;
					}
				}
				catch{}
			}
			else
			{
				this.strBabyNo = "";
				this.bIsBaby = false;
			}
			try
			{
				this.listform.Close();
			}
			catch
			{
				
			}
			try
			{	
				this.myEvent();
			}
			catch{}

			
		}
		private void CheckBabys()
		{
			try
			{
				this.alBabyInfo = this.GetBabyInfo.GetBabys(this.strPatientno);
				
			}
			catch(Exception ex)
			{
				this.alBabyInfo=new ArrayList();
				this.Err = ex.Message;
			}
		}
		private void SelectBabys()
		{
			lst=new ListBox();
			lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listform=new Form();
			listform.Size = new Size(200,100);
			for(int i=0;i<this.alBabyInfo.Count;i++)
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alBabyInfo[i];
				lst.Items.Add(obj.ID +"  "+obj.Name );
			}
			
			lst.Visible=true;
			lst.Show();
			lst.KeyDown+=new KeyEventHandler(lst_KeyDown);
			lst.DoubleClick+=new EventHandler(lst_DoubleClick);
			listform.Closing+=new CancelEventHandler(listform_Closing);
			listform.Controls.Add(lst);
			listform.Text = "请选择婴儿信息";
			listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			listform.TopMost=true;
			
			listform.Show();
			listform.Location = this.chkIsBaby.PointToScreen(new Point(this.chkIsBaby.Width/2+this.chkIsBaby.Left ,this.chkIsBaby.Height+this.chkIsBaby.Top));
			try
			{
				lst.SelectedIndex = 0;
				lst.Focus();
				lst.LostFocus+=new EventHandler(lst_LostFocus);
			}
			catch{}
			return;
		}
	
		private void lst_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter )
			{
				GetInfo();
			}

		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			GetInfo();

		}
		private void GetInfo()
		{
			try
			{
				neusoft.neuFC.Object.neuObject obj;
				obj=(neusoft.neuFC.Object.neuObject)this.alBabyInfo[lst.SelectedIndex];
				this.strBabyNo  = obj.ID ;
				this.bIsBaby = true;
				try
				{
					this.listform.Hide ();
				}
				catch
				{
					
				}
				this.myEvent();
			}
			catch{}
		}
		
		private void lst_LostFocus(object sender, EventArgs e)
		{
			if(this.AutoHide)
			{
				this.listform.Hide();
				this.CheckBabyNo();
			}
		}

		private void chkGetBabyInfo_Load(object sender, EventArgs e)
		{
			try
			{
				this.GetBabyInfo.Connection =((neusoft.neuFC.Interface.Forms.BaseForm)this.ParentForm ).var.con;
				this.GetBabyInfo.Sql =((neusoft.neuFC.Interface.Forms.BaseForm)this.ParentForm).var.Sql;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}	
		}
		private void CheckBabyNo()
		{
			if (this.strBabyNo=="" && this.chkIsBaby.Checked) this.chkIsBaby.Checked=false;
		}
		#endregion

		private void listform_Closing(object sender, CancelEventArgs e)
		{
			this.CheckBabyNo();
		}
	}

}
