using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Net.Sockets;
namespace AutoUpdate
{
	/// <summary>
	/// frmManager 的摘要说明。
	/// </summary>
	public class frmManager : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		public frmManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
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
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmManager());
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbModify = new System.Windows.Forms.ToolBarButton();
            this.tbDelete = new System.Windows.Forms.ToolBarButton();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbExport = new System.Windows.Forms.ToolBarButton();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbFileName = new System.Windows.Forms.TextBox();
            this.lbPrimaryID = new System.Windows.Forms.TextBox();
            this.lbFilePath = new System.Windows.Forms.TextBox();
            this.lbOperCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFileVersion = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbAdd,
            this.tbModify,
            this.tbDelete,
            this.toolBarButton1,
            this.tbExport,
            this.tbPrint,
            this.toolBarButton2,
            this.tbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(792, 65);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbAdd
            // 
            this.tbAdd.ImageIndex = 0;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Text = "增加(A)";
            // 
            // tbModify
            // 
            this.tbModify.ImageIndex = 6;
            this.tbModify.Name = "tbModify";
            this.tbModify.Text = "修改(M)";
            // 
            // tbDelete
            // 
            this.tbDelete.DropDownMenu = this.contextMenu1;
            this.tbDelete.ImageIndex = 1;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbDelete.Text = "删除(D)";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "删除所有";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExport
            // 
            this.tbExport.ImageIndex = 7;
            this.tbExport.Name = "tbExport";
            this.tbExport.Text = "导出(E)";
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 9;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Text = "打印(P)";
            this.tbPrint.Visible = false;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExit
            // 
            this.tbExit.ImageIndex = 10;
            this.tbExit.Name = "tbExit";
            this.tbExit.Text = "退出(X)";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 501);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cb);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.lbFileName);
            this.panel2.Controls.Add(this.lbPrimaryID);
            this.panel2.Controls.Add(this.lbFilePath);
            this.panel2.Controls.Add(this.lbOperCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbFileVersion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 31);
            this.panel2.TabIndex = 2;
            // 
            // cb
            // 
            this.cb.Location = new System.Drawing.Point(140, 3);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(80, 24);
            this.cb.TabIndex = 13;
            this.cb.Text = "模糊查询";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(4, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(128, 21);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbFileName
            // 
            this.lbFileName.BackColor = System.Drawing.Color.DarkCyan;
            this.lbFileName.Location = new System.Drawing.Point(284, 5);
            this.lbFileName.Multiline = true;
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.ReadOnly = true;
            this.lbFileName.Size = new System.Drawing.Size(152, 21);
            this.lbFileName.TabIndex = 10;
            this.lbFileName.Text = "文件名";
            // 
            // lbPrimaryID
            // 
            this.lbPrimaryID.BackColor = System.Drawing.Color.DarkCyan;
            this.lbPrimaryID.Location = new System.Drawing.Point(220, 5);
            this.lbPrimaryID.Multiline = true;
            this.lbPrimaryID.Name = "lbPrimaryID";
            this.lbPrimaryID.ReadOnly = true;
            this.lbPrimaryID.Size = new System.Drawing.Size(64, 21);
            this.lbPrimaryID.TabIndex = 9;
            this.lbPrimaryID.Text = "主键列";
            // 
            // lbFilePath
            // 
            this.lbFilePath.BackColor = System.Drawing.Color.DarkCyan;
            this.lbFilePath.Location = new System.Drawing.Point(436, 5);
            this.lbFilePath.Multiline = true;
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.ReadOnly = true;
            this.lbFilePath.Size = new System.Drawing.Size(184, 21);
            this.lbFilePath.TabIndex = 7;
            this.lbFilePath.Text = "客户端相对目录";
            // 
            // lbOperCode
            // 
            this.lbOperCode.BackColor = System.Drawing.Color.DarkCyan;
            this.lbOperCode.Location = new System.Drawing.Point(708, 3);
            this.lbOperCode.Name = "lbOperCode";
            this.lbOperCode.ReadOnly = true;
            this.lbOperCode.Size = new System.Drawing.Size(8, 21);
            this.lbOperCode.TabIndex = 8;
            this.lbOperCode.Text = "操作员";
            this.lbOperCode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-162, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "文件名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFileVersion
            // 
            this.lbFileVersion.BackColor = System.Drawing.Color.DarkCyan;
            this.lbFileVersion.Location = new System.Drawing.Point(620, 5);
            this.lbFileVersion.Multiline = true;
            this.lbFileVersion.Name = "lbFileVersion";
            this.lbFileVersion.ReadOnly = true;
            this.lbFileVersion.Size = new System.Drawing.Size(48, 21);
            this.lbFileVersion.TabIndex = 6;
            this.lbFileVersion.Text = "版本号";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.White;
            this.dataGrid1.BackColor = System.Drawing.Color.White;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Lavender;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dataGrid1.ForeColor = System.Drawing.Color.Black;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Wheat;
            this.dataGrid1.HeaderBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGrid1.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid1.Location = new System.Drawing.Point(3, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Ivory;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.Wheat;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid1.Size = new System.Drawing.Size(792, 453);
            this.dataGrid1.TabIndex = 1;
            // 
            // frmManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载文件维护";
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.Activated += new System.EventHandler(this.frmManager_Activated);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbAdd;
		private System.Windows.Forms.ToolBarButton tbModify;
		private System.Windows.Forms.ToolBarButton tbDelete;
		private System.Windows.Forms.ToolBarButton tbExport;
		private System.Windows.Forms.ToolBarButton tbPrint;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Panel panel1;

		#region 全局变量 
		System.Data.OracleClient.OracleConnection con = null;
		EditType editType = EditType.None;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.DataGrid dataGrid1;
        bool IsVisible = true; //是否显示维护界面
        System.Data.DataSet ds = null;
        private Panel panel2;
        private CheckBox cb;
        private TextBox txtSearch;
        private TextBox lbFileName;
        private TextBox lbPrimaryID;
        private TextBox lbFilePath;
        private TextBox lbOperCode;
        private Label label1;
        private TextBox lbFileVersion;
		System.Data.DataView dv ;
		#endregion 
		enum Col
		{
			主键列 = 0 ,        
			文件名,         
			客户端相对目录,   
			版本号 ,        
			操作员 ,        
			操作日期      
		}
		private void frmManager_Load(object sender, System.EventArgs e)
		{
			try
			{
				mgr.wait.Show();
				System.Windows.Forms.Application.DoEvents();
				mgr.wait.Refresh();
//				string str =  SystemUpdate.ReadConfig("MSSQLCLIENT");
				con = mgr.ConnectOracle();//.ConnectOracle(str);
				if(con == null)
				{
					//MessageBox.Show(mgr.Err); by xipeter 2012.8.15 不影响后续的程序启动
				
                    #region  by xipeter 2012.8.15 不影响后续的程序启动
                    System.Windows.Forms.Application.Exit();
                    string ExeFilePath = Application.StartupPath + SystemUpdate.ReadConfig("ExeFilePath");
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = ExeFilePath;
                    string machine = Environment.MachineName;
                    if (System.IO.File.Exists(ExeFilePath))
                    {
                        mgr.wait.lblTip.Text = "正在启动";
                        System.Windows.Forms.Application.Exit();
                        mgr.wait.Refresh();
                        Process p = new Process();
                        p.StartInfo = psi;
                        p.Start();
                        try
                        {
                            mgr.Login(con, machine);
                        }
                        catch (Exception ee)
                        {
                            return;
                            
                        }
                      
                        
                    }
                    else
                    {
                        MessageBox.Show("没有找到文件:" + ExeFilePath);
                    }
                    #endregion
                    CloseThis();
                    return ;
				}
				#region 同步系统时间 
				try
				{
					mgr.wait.lblTip.Text = "同步系统时间.....";
					string ServerName = "select sysdate from dual";
					DataSet Timeds = mgr.SelectData(con,ServerName);
					if(Timeds != null)
					{
						System.DateTime ServerTime = Convert.ToDateTime(Timeds.Tables[0].Rows[0][0].ToString());
						AutoUpdate.SystemUpdate.SystemTime systNew = new AutoUpdate.SystemUpdate.SystemTime();
						systNew.wDay =(short) ServerTime.Day;
						systNew.wMonth = (short)ServerTime.Month ;
						systNew.wYear = (short)ServerTime.Year;
						systNew.wHour =(short) ServerTime.Hour;
						systNew.wMinute =(short)ServerTime.Minute;
						systNew.wSecond =(short)(ServerTime.Second);
						SystemUpdate.SetLocalTime(ref systNew);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("同步时间失败" + ex.Message);
					CloseThis();
					return ;
				}
				#endregion 
				if(SystemUpdate.ReadConfig("DOWNLOAD") == "1")
				{
					#region 下载
					IsVisible = false;
					mgr.wait.lblTip.Text = "开始查询需要下载的程序.....";
					if(mgr.DownLoadFile(con) != -1)
					{
						mgr.WriteConfig("UpdateTime",System.DateTime.Now.ToString());

					}
					else
					{
						MessageBox.Show("更新程序失败" + mgr.Err);
						CloseThis();
						return ;
					}
					#endregion 
					System.Windows.Forms.Application.Exit();
					string ExeFilePath = Application.StartupPath +SystemUpdate.ReadConfig("ExeFilePath");
					ProcessStartInfo psi=new ProcessStartInfo();
					psi.FileName = ExeFilePath;
					if(System.IO.File.Exists(ExeFilePath))
					{
						mgr.wait.lblTip.Text  = "正在启动";
						System.Windows.Forms.Application.Exit();
						mgr.wait.Refresh();
						Process p = new Process();
						p.StartInfo = psi;
						p.Start();
                        string machine = Environment.MachineName;
                        try
                        {
                            #region 防止数据库中间关闭 modified by xipeter 20120822
                            if (con.State.ToString().ToLower() == "closed") {
                                con = mgr.ConnectOracle();
                            }
                            #endregion
                            mgr.Login(con, machine);
                        }
                        catch (Exception ee)
                        {
                            return;

                        }

					}
					else
					{
						MessageBox.Show("没有找到文件:"+ExeFilePath);
					}
//					Process[] proc = Process.GetProcessesByName("AutoUpdate");
//					if(proc.Length>=1)
//					{
//						for(int i=0;i<proc.Length;i++)
//						{
//							proc[i].Kill();
//						}
//					}
                    this.CloseThis();
				}
				else
				{
					#region 维护
					#region 校验密码
					mgr.wait.lblTip.Text= "校验密码...";
					Application.DoEvents();
					frmPassword frm = new frmPassword(); 
					frm.ShowDialog();
					if(!frm.PassWordIsRight)
					{ 
						frm.Close();
						CloseThis();
					} 
					frm.Close();

					#endregion 
					#region 清空
					lbPrimaryID.Text = "";
					lbFileName.Text = "";
					lbFilePath.Text = "";
					lbOperCode.Text = "";
					lbFileVersion.Text = "";
					#endregion 
					//查询数据
					string strSql = "SELECT primary_id 主键 ,file_name 文件名,local_directory 本地路径,file_version 版本号,oper_code 操作员,to_char(oper_date,'yyyy-mm-dd hh24:mi:ss') 操作日期  FROM com_downloadfile t order by  t.oper_date desc";
					mgr.wait.lblTip.Text ="正在查询数据库...";
					Application.DoEvents();
					//维护
					ds = mgr.SelectData(con,strSql);
					if(ds == null || ds.Tables.Count ==0)
					{
						MessageBox.Show("获取下载信息出错");
						this.CloseThis();
						return ;
					}
					CreateKeys(ds.Tables[0]);
					dv = new DataView(ds.Tables[0]);
					dv.AllowEdit = false;
					this.lbPrimaryID.DataBindings.Add("Text",dv,"主键");
					this.lbFileName.DataBindings.Add("Text", dv,"文件名");
					this.lbFilePath.DataBindings.Add("Text", dv,"本地路径");
					this.lbOperCode.DataBindings.Add("Text", dv,"版本号");
					this.lbFileVersion.DataBindings.Add("Text", dv,"版本号");
					this.dataGrid1.DataSource = dv;
					this.dataGrid1.ReadOnly = true;
					#endregion 
				}
				mgr.wait.Hide(); 
			}
			catch(Exception ex)
			{
				mgr.wait.Hide();
				MessageBox.Show(ex.Message);
				this.CloseThis();
			}
            
		}

		/// <summary>
		/// 关闭本窗口
		/// </summary>
		public void CloseThis()
		{
			if(this.con !=null)
			{
				this.con.Close();
			}
			this.Close();
		}
		SystemUpdate mgr = new SystemUpdate();
	
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbAdd)
			{
				Add();
			}
			else if(e.Button == this.tbModify)
			{
				Modify();
			}
			else if(e.Button == this.tbDelete)
			{
				//删除
				Delete();
			}
			else if(e.Button == this.tbExport)
			{
				//导出
				Export();
			}
			else if(e.Button == this.tbPrint)
			{
				//打印
			}
			else if(e.Button == this.tbExit)
			{
				//退出
				System.Windows.Forms.Application.Exit();
			}
		}
		/// <summary>
		/// 增加一行
		/// </summary>
		private void Add()
		{
			editType = EditType.Add;
			//增加
			frmInfo frm = new frmInfo();
			frm.Con = con;
			frm.CreatPrimarKey();
			frm.SaveHandle +=new AutoUpdate.frmInfo.SaveDelegate(frm_SaveHandle);
			frm.myEditType = EditType.Add; //修改
			frm.ShowDialog();
		}
		/// <summary>
		/// 修改
		/// </summary>
		private void Modify()
		{
			editType = EditType.Modify;
			//修改
			#region 获取信息
			FtpFile obj = new FtpFile();
			obj.PrimaryID = this.lbPrimaryID.Text;
			obj.FileName = this.lbFileName.Text;
			obj.LocalDirectory = this.lbFilePath.Text;
			obj.FileVersion = this.lbFileVersion.Text;
			obj.OperCode = this.lbOperCode.Text;
			obj.OperDate = System.DateTime.Now;
            //string strSql = "select t.file_content  from com_downloadfile t where t.primary_id = '{0}'";
            //strSql = string.Format(strSql,obj.PrimaryID);
            //System.Data.DataSet ds = mgr.SelectData(con,strSql);
            //byte [] blob = null;
            //foreach(DataRow row in ds.Tables[0].Rows)
            //{
            //    blob = (byte [])row[0];
            //}
            //obj.FileContent = blob; modified by xipeter 20120831 更新文件时，没有必要得到文件内容
			#endregion 

			frmInfo frm = new frmInfo();
			frm.Con = con;
			frm.SetInfo(obj);
			frm.myEditType = EditType.Modify; //修改
			frm.SaveHandle +=new AutoUpdate.frmInfo.SaveDelegate(frm_SaveHandle);
			frm.ShowDialog();
		}
		/// <summary>
		/// 删除
		/// </summary>
		private void Delete()
		{		
			if(this.ds.Tables.Count == 0 && this.ds.Tables[0].Rows.Count == 0) 
			{
				return ;
			}
			if(MessageBox.Show("删除文件"+ lbFileName.Text + ",此操作不可恢复,是否继续","警告",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
			{
				return ;
			}
            string ID = this.lbPrimaryID.Text;
			string strSql = "delete  from com_downloadfile t where t.primary_id = '{0}'";
			strSql = string.Format(strSql,ID);
			OracleTransaction trans = this.con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			mgr.SetTrans(trans);
			int i = mgr.ExeNoQuery(this.con,strSql);
			if(i <= 0)
			{
				trans.Rollback();
				MessageBox.Show("删除数据失败" + mgr.Err);
			}
			else
			{
				trans.Commit();
				object[] keys = new object[]{this.lbPrimaryID.Text};
				DataRow row = ds.Tables[0].Rows.Find(keys);
				this.ds.Tables[0].Rows.Remove(row);
				ds.AcceptChanges();
				MessageBox.Show("删除成功");
			}

		}
		/// <summary>
		/// 导出
		/// </summary>
		private void Export()
		{
			//导出数据
			try
			{
				if(lbFileName.Text == "")
				{
					MessageBox.Show("请选择要导出的文件");
					return ;
				}
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			
				saveFileDialog1.Filter = "*|*.*";
				saveFileDialog1.FileName =lbFileName.Text;

				saveFileDialog1.Title = "导出数据";
				if(saveFileDialog1.ShowDialog()==DialogResult.OK)
				{
					if(mgr.DownLoadFile(this.con,this.lbPrimaryID.Text,saveFileDialog1.FileName) ==1)
					{
						MessageBox.Show(lbFileName.Text + "导出成功");
					}
				}
			}
			catch(Exception ee)
			{
				//出错了
				MessageBox.Show(ee.Message);
			}
		}

		private void frm_SaveHandle(FtpFile obj)
		{
			if(editType == EditType.Add)
			{
				//定义变量
				DataRow row = ds.Tables[0].NewRow();
				//增加一行
				SetRow(obj, row);
				ds.Tables[0].Rows.Add(row);
			}
			else if(editType == EditType.Modify)
			{
				object[] keys = new object[]{obj.PrimaryID};
				DataRow row = ds.Tables[0].Rows.Find(keys);
				if(row == null)
				{
					MessageBox.Show("查找项目出错!");
					return;
				}
				else
				{
					SetRow(obj, row);
				}
			}
			ds.Tables[0].AcceptChanges();
		}
		/// <summary>
		///设置主键,为列sequence_no
		/// </summary>
		private void CreateKeys(DataTable table )
		{
			DataColumn[] keys = new DataColumn[]{table.Columns["主键"]};
			table.PrimaryKey = keys;
		}

		/// <summary>
		/// 赋值
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="row"></param>
		private void SetRow(FtpFile obj, DataRow row)
		{
			row["主键"] = obj.PrimaryID;
			row["文件名"] = obj.FileName;
			row["本地路径"] = obj.LocalDirectory;
			row["版本号"] = obj.FileVersion;
			row["操作员"] = obj.OperCode;
			row["操作日期"] = obj.OperDate;
		}
		private void frmManager_Activated(object sender, System.EventArgs e)
		{
			this.Visible = IsVisible;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			if(this.ds.Tables.Count ==0 ||this.ds.Tables[0].Rows.Count == 0)
			{
				return ;
			}
			
			if(MessageBox.Show("删除全部文件,此操作不可恢复,是否继续","警告",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
			{
				return ;
			}
			string strSql = "delete  from com_downloadfile  ";
			OracleTransaction trans = this.con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			mgr.SetTrans(trans);
			int i = mgr.ExeNoQuery(this.con,strSql);
			if(i <= 0)
			{
				trans.Rollback();
				MessageBox.Show("删除数据失败" + mgr.Err);
			}
			else
			{
				trans.Commit();
				ds.Tables[0].Clear();
				ds.AcceptChanges();
				MessageBox.Show("删除成功");
			}
		}

		private void txtSearch_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cb.Checked)
				{
					dv.RowFilter = "文件名 like '%" + txtSearch.Text.Trim() + "%'";
				}
				else
				{
					dv.RowFilter = "文件名 like '" + txtSearch.Text.Trim() + "%'";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        
	}
}
