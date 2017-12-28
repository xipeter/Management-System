using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Neusoft.FrameWork.WinForms.Forms
{
	/// <summary>
	/// BaseStatusBar 的摘要说明。
	/// 带有完整状态栏的基类窗口
	/// </summary>
	public class BaseStatusBar : BaseForm
	{
        private System.Windows.Forms.Timer timer1;
        //public Panel statusBar1;
        public System.Windows.Forms.StatusBar statusBar1;
		private System.ComponentModel.IContainer components;

		public BaseStatusBar():base()
		{
			InitializeComponent();
            if (this.DesignMode) return;
			SetPanel();
			ProgressRun(true);
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            //this.statusBar1 = new System.Windows.Forms.Panel();
            this.statusBar1 = new StatusBar();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 252);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(320, 25);
            this.statusBar1.TabIndex = 1;
            // 
            // BaseStatusBar
            // 
            this.ClientSize = new System.Drawing.Size(320, 277);
            this.Controls.Add(this.statusBar1);
            this.KeyPreview = true;
            this.Name = "BaseStatusBar";
            this.Text = "BaseStatusBar";
            this.ResumeLayout(false);

		}
		#endregion

        #region StatusBar
        /// <summary>
		/// 设置StatusBar的Panel
		/// </summary>
		protected void SetPanel()
		{
			

			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            //System.Windows.Forms.Label Panel = new Label();
            System.Windows.Forms.StatusBarPanel Panel = new StatusBarPanel();
			int i=1;
            //Panel.AutoSize = StatusBarPanelAutoSize.Contents;
            Panel.Width = 170;
			Panel.Text="系统时间：";
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
            Panel.Text = Neusoft.FrameWork.Management.Language.Msg( "系统时间" ) + ":";
            //Panel.Top = 5;
            //Panel.Left = 20;
            //this.statusBar1.Controls.Add(Panel);
            this.statusBar1.Panels.Add(Panel);

            //Panel = new Label();
            Panel = new StatusBarPanel();
            //Panel.Top = 5;
            //Panel.Left = 150;
            Panel.AutoSize = StatusBarPanelAutoSize.Contents;
			//this.statusBar1.Controls.Add(Panel);
            this.statusBar1.Panels.Add(Panel);

			//Panel=new Label();
            Panel = new StatusBarPanel();
			try
			{
                Panel.AutoSize = StatusBarPanelAutoSize.Contents;
				Panel.Text="操作员："+ Neusoft.FrameWork.Management.Connection.Operator.Name;
                //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                Panel.Text = Neusoft.FrameWork.Management.Language.Msg( "操作员" ) + ":" + Neusoft.FrameWork.Management.Connection.Operator.Name;

                //Panel.Left = 300;
                //Panel.Top = 5;
                //this.statusBar1.Controls.Add(Panel);
                Panel.Width = 200;
                this.statusBar1.Panels.Add(Panel);
				i++;
			}
			catch
			{
				Panel.Text="未知操作员";
			}


            //Panel = new Label();
            Panel = new StatusBarPanel();
			try
			{
                //{70BC3C2C-823D-4c56-A06A-3E584EA13B2B}  获取当前登录IP并显示在界面上
                string hosName = System.Net.Dns.GetHostName();
                string ip = string.Empty;

                foreach (System.Net.IPAddress info in System.Net.Dns.GetHostAddresses( hosName ))
                {
                    if (info.IsIPv6LinkLocal == true)
                    {
                        continue;
                    }

                    ip = info.ToString();
                }

                Panel.AutoSize = StatusBarPanelAutoSize.Contents;
                //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}  区域语言转换
                //{70BC3C2C-823D-4c56-A06A-3E584EA13B2B}  获取当前登录IP并显示在界面上
                Panel.Text = Neusoft.FrameWork.Management.Language.Msg( "科室" ) + ":" + ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Name + "      IP:" + ip.ToString();
				
			}
			catch
			{
				Panel.Text="未知操作科室";
			}
            //Panel.Left = 500;
            //Panel.Top = 5;
            //this.statusBar1.Controls.Add(Panel);
            Panel.Width = 200;
            this.statusBar1.Panels.Add(Panel);
            this.statusBar1.ShowPanels = true;
       
		}

		private DateTime dt;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				dt = dt.AddSeconds(1);
                this.statusBar1.Panels[0].Text = Neusoft.FrameWork.Management.Language.Msg( "系统时间" ) + ":" + dt;
			}
			catch{}
		}
		protected Neusoft.FrameWork.Management.DataBaseManger dataManager = null;

		/// <summary>
		/// 进度条开始运行
		/// </summary>
		/// <param name="b"></param>
		protected void ProgressRun(bool b)
		{
			this.timer1.Enabled=b;
			try
			{
				if(dataManager == null) 
					dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
				dt = dataManager.GetDateTimeFromSysDateTime();
			}
			catch{}
        }

        protected override void OnLoad(EventArgs e)
        {
            SetToolBar();
            base.OnLoad(e);
        }
        #endregion

        #region ToolBarService
        protected IToolBarService MyToolBarService = null;
        protected virtual int SetToolBar(string filename)
        {
            filename = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +
                Neusoft.FrameWork.WinForms.Classes.Function.PluginPath +
                Neusoft.FrameWork.WinForms.Classes.EnumPlugin.TOOLBAR.ToString() +
                "\\" + filename + ".dll";
            if (!System.IO.File.Exists(filename)) return 0;

            if (this.LoadDll(filename) == 0)
            {
                this.GetToolBar(this);
            }
            return 0;

        }

        protected virtual int SetToolBar()
        {
            string fileName = this.Name;
            return this.SetToolBar(fileName);
        }
        protected void GetToolBar(Control parentControl)
        {
            foreach (Control c in parentControl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.ToolStrip))
                {
                    if (c.Visible)
                    {
                        this.MyToolBarService.Init((ToolStrip)c);
                        return;
                    }
                }
                if (c.Controls.Count > 0) this.GetToolBar(c);

            }
        }

        protected virtual int LoadDll(String fileName)
        {
            try
            {
                Assembly a = Assembly.LoadFrom(fileName);
                System.Type[] types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IToolBarService") != null)
                    {
                        this.MyToolBarService = (IToolBarService)System.Activator.CreateInstance(type);
                        return 0;
                    }
                }
            }
            catch 
            {
               
                return -1;
            }
            return 0;
        }

        #endregion
    }
}
