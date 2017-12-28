using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace Neusoft.FrameWork.WinForms.Controls
{
    public partial class AutoDockControl : UserControl
    {
        public AutoDockControl()
        {
            InitializeComponent();
        }
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
        
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParm, int lParm);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();

        private void AutoDockControl_Load(object sender, EventArgs e)
        {
            
        }

        private Color titleColor = Color.Blue;

      
        public Color TitleColor
        {
            get { return titleColor; }
            set { titleColor = value;
            this.label1.BackColor = value;
                
            }
        }

        private bool isDock = false;

        public bool IsDock
        {
            get { return isDock; }
            set { isDock = value; 
            if(isDock)//最大
            {
                lastSize = new Size(this.Width,this.Height);
                this.Dock = DockStyle.Fill;
                this.picMax.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.min;
            }else//最小
            {
               
                this.Dock = DockStyle.None;
                this.Size = lastSize;
                this.picMax.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.max;
            }
            }
        }


        public string Title
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        private Control relateControl = null;

        public Control RelateControl
        {
            get { return relateControl; }
            set { relateControl = value;
            if (relateControl != null)
            {
                this.groupBox1.Controls.Add(relateControl);
                relateControl.Visible = true;
                relateControl.Dock = DockStyle.Fill;
            }

            }
        }
        private bool isCanMove = true;

        public bool IsCanMove
        {
            get { return isCanMove; }
            set { isCanMove = value; }
        }


        private Size lastSize = new Size(0, 0);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle reg = new Rectangle(new Point(0,0),new Size(this.panel1.Width,this.panel1.Height));
            using (LinearGradientBrush brush = new LinearGradientBrush(reg, TitleColor, Color.White, 0f))
            {
                this.panel1.CreateGraphics().FillRectangle(brush, reg);
            }
        }

     
        private void picMax_Click(object sender, EventArgs e)
        {
            IsDock = !IsDock;
           
               
        }

        private void picMax_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            IsDock = !IsDock;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCanMove == false) return;
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void MoveControl(System.Object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
        {
            Control c = new Control();
            c = (Control)sender;
            IntPtr hWnd;
            hWnd = c.Handle;
            ReleaseCapture();
            if (e.X < i)
            {
                if (e.Y < i)
                {
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPLEFT, 0);
                }
                else if (e.Y > c.Height - i - j)
                {
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMLEFT, 0);
                }
                else
                {
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTLEFT, 0);

                }
            }
            else if (e.X > c.Width - i - j)
            {
                if (e.Y < i)
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);
                else if (e.Y > c.Height - i - j)
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMRIGHT, 0);
                else
                    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTRIGHT, 0);
            }
            else if (e.Y > c.Height - i - j)
            {
                SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOM, 0);
            }
            else if (e.Y < i)
            {
                SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOP, 0);
            }
            else
            {
                SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            ReleaseCapture();

        }

        private void AutoDockControl_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

    }
}
