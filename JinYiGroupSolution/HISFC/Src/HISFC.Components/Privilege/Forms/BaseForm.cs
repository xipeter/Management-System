using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Neusoft.UFC.Privilege.Forms
{	
    /// <summary>
    /// [功能描述: 	
    /// 基类窗口 created by wolf 2004-6-21
    /// 所有窗口的基类
    /// 1、实现语言国际化
    /// 2、实现状态条
    /// <br></br>
    /// [创 建 者: huangxw]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class BaseForm : System.Windows.Forms.Form
    {
        protected StatusStrip MainStatusStrip;
        private Timer timer1;
        private ToolStripStatusLabel statusLabel1;
        private ToolStripStatusLabel statusLabel2;
        private ToolStripStatusLabel statusLabel3;
        private IContainer components;
		
		/// <summary>
		/// 
		/// </summary>
		public BaseForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            //设置状态条
            this.SetStatusStrip();

            //及时器刷新时间
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;            
		}

        public bool IsStatusStripVisible
        {
            get
            {
                return this.MainStatusStrip.Visible;
            }
            set
            {
                this.MainStatusStrip.Visible = value;
            }
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
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel3,
            this.statusLabel1,
            this.statusLabel2});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 341);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(478, 22);
            this.MainStatusStrip.TabIndex = 0;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel3
            // 
            this.statusLabel3.AutoSize = false;
            this.statusLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel3.Name = "statusLabel3";
            this.statusLabel3.Size = new System.Drawing.Size(103, 17);
            this.statusLabel3.Spring = true;
            this.statusLabel3.Text = "就绪";
            this.statusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = false;
            this.statusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.statusLabel1.Size = new System.Drawing.Size(130, 17);
            this.statusLabel1.Text = "操作员: ";
            this.statusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel2
            // 
            this.statusLabel2.AutoSize = false;
            this.statusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.statusLabel2.Size = new System.Drawing.Size(230, 17);
            this.statusLabel2.Text = "时间: yyyyniddniddni hhnimmnissni";
            this.statusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(478, 363);
            this.Controls.Add(this.MainStatusStrip);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
              
		private void frmBase_Load(object sender, System.EventArgs e)
		{   
            //语言国际化
            this.ChangeControlLanguage(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            SetToolBar();

            base.OnLoad(e);
        }

        #region 语言国际化
        /// <summary>
        /// 转换控件显示文本
        /// </summary>
        /// <param name="control"></param>
        public void ChangeControlLanguage(object control)
        {            
            //if (Neusoft.NFC.Management.Language.IsUseLanguage == false) return;   

            this.ReplaceText(control);

            Control c = control as Control;
            if (c != null && c.Controls.Count>0)
            {
                foreach (Control c1 in c.Controls)
                {
                    this.ChangeControlLanguage(c1);
                }
            }
        }

        /// <summary>
        /// 替换文本
        /// </summary>
        protected void ReplaceText(object c)
        {
            try
            {
                if (c.GetType().IsSubclassOf(typeof(TabPage)) 
                    || c.GetType().IsSubclassOf(typeof(Label))
                    || c.GetType().IsSubclassOf(typeof(ButtonBase))
                    || c.GetType() == typeof(TabPage)
                    || c.GetType() == typeof(Label))
                {
                    Control control = c as Control;
                    //control.Text = Neusoft.NFC.Management.Language.Msg(control.Text);

                }
                else if (c.GetType().IsSubclassOf(typeof(ToolBar)) || c.GetType() == typeof(ToolBar))
                {
                    ToolBar tb = c as ToolBar;
                    foreach (ToolBarButton button in tb.Controls)
                    {
                        //button.Text = Neusoft.NFC.Management.Language.Msg(button.Text);
                        //button.ToolTipText = Neusoft.NFC.Management.Language.Msg(button.ToolTipText);
                    }
                }
                else if (c.GetType().IsSubclassOf(typeof(ToolStrip)) || c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip ts = c as ToolStrip;
                    foreach (ToolStripItem button in ts.Items)
                    {
                        //button.Text = Neusoft.NFC.Management.Language.Msg(button.Text);
                        //button.ToolTipText = Neusoft.NFC.Management.Language.Msg(button.ToolTipText);
                    }
                }
                //else if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)) || c.GetType() == typeof(FarPoint.Win.Spread.FpSpread))
                //{
                //    FarPoint.Win.Spread.FpSpread fp = c as FarPoint.Win.Spread.FpSpread;
                //    foreach (FarPoint.Win.Spread.SheetView sv in fp.Sheets)
                //    {
                //        foreach (FarPoint.Win.Spread.Column column in sv.Columns)
                //        {
                //            column.Label = Neusoft.NFC.Management.Language.Msg(column.Label);
                //        }
                //    }
                //}
            }
            catch { }

        }
        #endregion

        #region 状态条
        /// <summary>
        /// 设置状态条
        /// </summary>
        protected void SetStatusStrip()
        {
            statusLabel3.Text = "就绪";                          

            statusLabel1.Text = "操作员: " + "test";
            statusLabel1.Width = 130;

            statusLabel2.Text = "时间: " + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            statusLabel2.Width = 230;
        }

        /// <summary>
        /// 设置状态条信息
        /// </summary>
        /// <param name="msg"></param>
        public void SetStatusMsg(string msg)
        {
            this.SetStatusMsg(msg, Color.Black);
        }

        /// <summary>
        /// 设置状态条信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fontColor"></param>
        public void SetStatusMsg(string msg, Color fontColor)
        {
            statusLabel3.Text = msg;
            statusLabel3.ForeColor = fontColor;
        }

        public void SetStatusOper(string operName)
        {
            statusLabel1.Text = "操作员: " + operName;
        }

        public void SetStatusDate(DateTime operDate)
        {
            statusLabel2.Text = "时间: " + operDate.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }

        /// <summary>
        /// 设置操作员和操作时间状态条不可见
        /// </summary>
        public void SetOperAndDateInvisible()
        {
            this.statusLabel1.Visible = false;
            this.statusLabel2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusLabel2.Text = "时间: " + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }
        
        #endregion

        #region ToolBarService

        protected IToolBarService MyToolBarService = null;
        
        public string CurrentPath = "";
        public string PluginPath = "Plugins\\";

        protected virtual int SetToolBar(string filename)
        {
            filename = CurrentPath + PluginPath + "TOOLBAR" +
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
