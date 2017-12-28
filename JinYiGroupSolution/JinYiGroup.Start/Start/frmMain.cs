using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace HIS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        protected override void OnLoad(EventArgs e)
        {
          
            //this.Text = this.Text + " for " + Neusoft.FrameWork.Management.Connection.Instance.GetType().ToString();
            //this.skinEngine1.Active = false;

            this.Text = "综合管理系统 － " + Program.HosName;

            //{57CC110D-2CF8-4704-93F3-3BFA247FB41C}
            //if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "1")         //东软蓝
            //{
            //this.BackgroundImage = HIS.Properties.Resources.东软蓝_背景;
                
            //}
            //else if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "2")    //东软青
            //{
            this.BackgroundImage = HIS.Properties.Resources.艺筑生活_品动世界_背景;
                
            //}

            
            base.OnLoad(e);
            this.WindowState = FormWindowState.Maximized;
        }
        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //屏蔽FarPoint内发出的错误异常   {90D30CF7-F965-4fcf-A38A-BDE9AC3A896B}
            if (e.Exception.Source == "FarPoint.Win.Spread")
            {
                return;
            }
           
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            Neusoft.FrameWork.WinForms.Classes.Function.MessageBox(e.Exception);
            //Neusoft.FrameWork.Management.Connection.Instance.Close();
            //Neusoft.FrameWork.Management.Connection.Instance.Open();
        }

     
        /// <summary>
        /// 初始化菜单
        /// </summary>
        public void InitMenu()
        {
            //this.MainMenuStrip = Menu.AddMenu(this);
            //this.Controls.Add(this.MainMenuStrip);

        }

        public void InitMenu(string roleId)
        {
            MenuStrip _strip = HIS.Menu.InitMenu(roleId, this);
          
            this.MainMenuStrip = _strip;
            this.MainMenuStrip.BackColor = Color.WhiteSmoke;
            this.Controls.Add(_strip);
        }

        private void helloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        protected override void  OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("是否要退出系统？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //{5BE03DF2-25DE-4e7a-9B47-85CE92911277}  HIS系统注销前判断
                if (Neusoft.HISFC.Components.Manager.Classes.Function.HISLogout() == -1)
                {
                    return;
                }

                foreach (Form fr in this.MdiChildren)
                {
                    fr.Close();
                }

                try
                {
                    //if (Neusoft.FrameWork.Management.Connection.Instance.State != ConnectionState.Closed)
                    //{
                    //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //    Neusoft.FrameWork.Management.Connection.Instance.Close();
                    //}
                }
                catch { }

                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
    
 	         base.OnClosing(e);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
           
        }

        //protected Sunisoft.IrisSkin.SkinEngine skinM = null;

        //public int InitSkinManager()
        //{
        //    if (skinM == null)
        //    {                
        //        skinM = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));

        //        skinM.SerialNumber = "";
        //        skinM.SkinFile = @"D:\his4.5\HIS\Src\HIS\bin\Debug\皮肤\MacOS苹果\MacOS.ssk";
        //    }

        //    if (skinM == null)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}

        //public string SkinFile
        //{
        //    get
        //    {
        //        return this.skinEngine1.SkinFile;
        //    }
        //    set
        //    {
        //        skinEngine1.SkinFile = value;
        //    }
        //}

        //public bool UseDefaultSkin
        //{
        //    get
        //    {
        //        return skinEngine1.Active;
        //    }
        //    set
        //    {
        //        skinEngine1.Active = value;
        //    }
        //}
        protected override void  OnKeyDown(KeyEventArgs e)
        {
            
            //if(e.Alt && e.Control && e.KeyCode == Keys.T )
            //{
            //   //启动系统监控程序
            //    frmMonitor form = new frmMonitor();
            //    form.MdiParent = this;
            //    form.Show();
            //}
 	        base.OnKeyDown(e);
        }

        #region 标题
        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);


        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);

            switch (m.Msg)
            {

                case 0x86://WM_NCACTIVATE

                    goto case 0x85;

                case 0x85://WM_NCPAINT
                    {

                        IntPtr hDC = GetWindowDC(m.HWnd);

                        //把DC转换为.NET的Graphics就可以很方便地使用Framework提供的绘图功能了
                        Graphics gs = Graphics.FromHdc(hDC);

                        int ibox = 1;

                        if (this.MaximizeBox) ibox++;
                        if (this.MinimizeBox) ibox++;

                        //得到相关背景图片
                        Image imgpm = this.Icon.ToBitmap();//Image.FromFile( Application.StartupPath+ @"\Main.png");

                        int iBoxWidh = 21;

                        //gs.DrawImage(imgbg,3,0,this.Width - (ibox * iBoxWidh),SystemInformation.CaptionHeight + 2);    //显示背景图片

                        //标题栏显示背景颜色
                        int xPos = this.Width - iBoxWidh * ibox - 2 - ibox * 3;

                        Rectangle excludeRect;
                        //标题栏中不需要填充的位置
                        for (int i = 0; i < ibox; i++)
                        {
                            if (i > 0)
                            {
                                xPos = xPos + iBoxWidh + 2;
                            }

                            excludeRect = new Rectangle(xPos, 5, iBoxWidh, iBoxWidh + 1);
                            gs.ExcludeClip(excludeRect);
                        }


                        //背景区域
                        Rectangle rBackground = new Rectangle(0, 0, this.Width, SystemInformation.CaptionHeight + 3);
                        //背景颜色 上下渐变
                        System.Drawing.Drawing2D.LinearGradientBrush bBackground
                            = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.DarkGreen), Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.LightBlue), LinearGradientMode.Vertical);

                        //标题栏填充背景颜色
                        gs.FillRectangle(bBackground, rBackground);
                        //显示图标文件
                        gs.DrawImage(imgpm, 4, 4, 24, 24);
                        StringFormat strFmt = new StringFormat();

                        //strFmt.Alignment = StringAlignment.Center;
                        //strFmt.LineAlignment = StringAlignment.Center;

                        //gs.DrawString(this.Text, this.Font, Brushes.BlanchedAlmond, m_rect, strFmt);
                        //设置标题字体
                        Font drawFont = new Font("宋体", 10, System.Drawing.FontStyle.Bold);
                        //设置标题颜色
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        //重画标题
                        gs.DrawString(this.Text, drawFont, drawBrush, 30, 8);

                        gs.Dispose();

                        //释放GDI资源

                        ReleaseDC(m.HWnd, hDC);

                        break;

                    }

                case 0xA1://WM_NCLBUTTONDOWN
                    {

                        Point mousePoint = new Point((int)m.LParam);

                        mousePoint.Offset(-this.Left, -this.Top);

                        break;

                    }

            }


        }
        #endregion
    }
}