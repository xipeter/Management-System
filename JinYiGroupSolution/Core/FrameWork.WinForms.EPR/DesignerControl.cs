using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;


namespace Neusoft.FrameWork.EPRControl
{
    /// <summary>
    /// 控件设计类
    /// </summary>
    public sealed class DesignControl : System.ComponentModel.Component
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DesignControl(System.ComponentModel.IContainer container)
        {

            container.Add(this);
            InitializeComponent();
        }

        public DesignControl()
        {
            InitializeComponent();

        }
        public DesignControl(ScrollableControl containerControl)
        {
            InitializeComponent();
            this.ContainerBox = containerControl;
        }
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

           

            base.Dispose(disposing);
        }


        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region 外部方法和使用的常量
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern long ClipCursor(out Rectangle rect);
        //		[DllImport("user32.dll")]
        //		static private extern long ClipCursorClear(int lpRect);
        [DllImport("user32.dll")]
        static private extern long ClientToScreen(IntPtr hwnd, out Point lpPoint);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetCapture(IntPtr Hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetRect(out Rectangle rect, int x1, int y1, int x2, int y2);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
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
        #endregion 外部方法和使用的常量

        #region 域
        private Point pointCurrent;
        private ResizeDirection direction;
        private IntPtr Hwnd;
       // private frmProperty propertyform;

        private Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
        /// <summary>
        /// 需要设置的文件信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuFileInfo FileInfo = new Neusoft.FrameWork.Models.NeuFileInfo();
        /// <summary>
        /// 如果保存到服务器上，需要设置的服务器信息
        /// </summary>
        internal XmlDocument doc;
        private ScrollableControl panelMain;
        private bool isEnterToTab = true;
        private bool isDesignMode;
        private bool isCustom;
        private bool isDrawGrid = true;
        private string[] controlChangeText;
        private Type[] typeChangeText;
        private ToolTip tooltip = new ToolTip();
        #endregion 域

        #region 属性
        [Description("设计控件的容器")]
        public string[] ControlChangeText
        {
            get
            {
                if (controlChangeText == null)
                {
                    controlChangeText = new string[8];
                    controlChangeText[0] = "System.Windows.Forms.Label, System.Windows.Forms.dll";
                    controlChangeText[1] = "System.Windows.Forms.LinkLabel, System.Windows.Forms.dll";
                    controlChangeText[2] = "System.Windows.Forms.RadioButton, System.Windows.Forms.dll";
                    controlChangeText[3] = "System.Windows.Forms.CheckBox, System.Windows.Forms.dll";
                    controlChangeText[4] = "System.Windows.Forms.Button, System.Windows.Forms.dll";
                    controlChangeText[5] = "System.Windows.Forms.GroupBox, System.Windows.Forms.dll";
                    controlChangeText[6] = "System.Windows.Forms.TabControl, System.Windows.Forms.dll";
                    controlChangeText[7] = "System.Windows.Forms.TabPage, System.Windows.Forms.dll";
                }
                return controlChangeText;
            }
            set
            {
                this.controlChangeText = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private Type[] TypeChangeText
        {
            get
            {
               
                return typeChangeText;
            }
        }

        private Control curControl;
     
        private bool isShowTip = true;
        [Description("是否显示提示信息!")]
        public bool IsShowTip
        {
            get
            {
                return isShowTip;
            }
            set
            {
                isShowTip = value;
            }
        }
        /// <summary>
        /// 是否进入设计模式
        /// </summary>
        [DefaultValue(false), Description("是否进入设计模式"), Browsable(false)]
        public bool IsDesignMode
        {
            get
            {
                return isDesignMode;
            }
            set
            {
                if (this.isDesignMode == value) return;
                if (this.panelMain == null) return;
                this.isDesignMode = value;

                if (value)
                {
                   
                    if (doc == null)
                    {
                        doc = new XmlDocument();
                        //不显示默认
                        XmlElement root = myXml.CreateRootElement(doc, "UserControl", "1.0");

                        this.SaveFile();

                    }

                    this.SaveCursor(doc.DocumentElement, this.panelMain, true);

                    //....
                    this.AddHandle();
                 
                    try
                    {
                        keypreview = this.panelMain.FindForm().KeyPreview;
                        this.panelMain.FindForm().KeyPreview = true;
                    }
                    catch { }

                }
                else
                {
                    ReadCursor(doc.DocumentElement);
                    if (this.isAutoSave)
                        this.SaveFile();
                   
                    this.RemoveHandle();
                    try
                    {
                        this.panelMain.FindForm().KeyPreview = keypreview;
                    }
                    catch { }
                }
                this.panelMain.Refresh();

            }
        }
        private bool isShowPropertyform = true;



        private bool isAutoSave = true;
        /// <summary>
        /// 是否自动保存
        /// </summary>
        public bool IsAutoSave
        {
            get { return isAutoSave; }
            set { isAutoSave = value; }
        }


        /// <summary>
        /// 回车是是否跳到下一个控件
        /// </summary>
        [DefaultValue(true), Description("回车是是否跳到下一个控件"), Browsable(false)]
        public bool IsAllowToNextControl
        {
            get
            {
                return isEnterToTab;
            }
            set
            {
                isEnterToTab = value;
                if (bFlag == true) return;
                this.AddKeyDown(this.panelMain);
                bFlag = true;
            }
        }

        private bool bFlag = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        private void AddKeyDown(Control parentControl)
        {
            //ControlKeyPress = new KeyPressEventHandler(c_KeyPress);
            ControlKeyUp = new KeyEventHandler(c_KeyUp);
            foreach (Control c in parentControl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.TextBox)
                    || c.GetType() == typeof(System.Windows.Forms.ComboBox))
                {
                    c.KeyUp += ControlKeyUp;
                }
                if (c.Controls.Count > 0) AddHandle(c);

            }
            return;
        }

        /// <summary>
        /// 是否显示属性窗口
        /// </summary>
        public bool IsShowPropertyForm
        {
            get
            {
                return this.isShowPropertyform;
            }
            set
            {
                this.isShowPropertyform = value;
               
            }
        }
        /// <summary>
        /// 在打开窗体时是否自定义控件属性
        /// 是否用默认窗口
        /// </summary>
        [DefaultValue(false), Description("在打开窗体时是否使用默认窗口"), Browsable(false)]
        internal bool IsUseDefaultSetting
        {
            get
            {
                return isCustom;
            }
            set
            {
                isCustom = value;
            }
        }


        /// <summary>
        /// 设计时是否画网格
        /// </summary>
        [DefaultValue(false), Description("设计时是否画网格")]
        public bool IsDrawGrid
        {
            get
            {
                return this.isDrawGrid;
            }
            set
            {
                this.isDrawGrid = value;

            }
        }

        /// <summary>
        /// 设计控件的容器
        /// </summary>
        [Description("设计控件的容器")]
        public ScrollableControl ContainerBox
        {
            get
            {
                return panelMain;
            }
            set
            {
                try
                {
                    if (((Form)value).IsMdiContainer)
                    {
                        this.panelMain = null;
                        return;
                    }
                }
                catch { }
                this.panelMain = value;
                if (this.doc == null)
                {
                    this.ReadFile(false);
                }
                try
                {
                    this.panelMain.FindForm().KeyDown += new KeyEventHandler(DesignControl_KeyDown);
                }
                catch { }
            }
        }
        private bool keypreview;
        /// <summary>
        /// 自定义控件设置文件名称(*.xml)
        /// </summary>
        [DefaultValue("Panel1.xml"), Description("自定义控件设置文件名称(*.xml)")]
        public string XmlFileName
        {
            get
            {
                if ((this.FileInfo.FileFullPath == null || this.FileInfo.FileFullPath == "") && this.panelMain != null)
                {
                    try
                    {
                        this.FileInfo.FileFullPath = this.panelMain.FindForm().Name + ".xml";
                    }
                    catch
                    {

                    }
                    if ((this.FileInfo.FileFullPath == null || this.FileInfo.FileFullPath == "") && this.panelMain != null)
                        this.FileInfo.FileFullPath = this.panelMain.Name + ".xml";
                }
                return this.FileInfo.FileFullPath;
            }
            set
            {
                string val = value;
                if (!value.ToLower().EndsWith(".xml"))
                {
                    val = value + ".xml";
                }
                this.FileInfo.FileFullPath = val;
                this.FileInfo.Name = val;
                //				if(value != "" && this.isCustom)
                //				{
                this.ReadFile(false);
                //				}
            }
        }

        #endregion 属性

        #region 标签事件

        enum ResizeDirection
        {
            None,
            TopLeft,
            Top,
            TopRight,
            Left,
            Right,
            BottomLeft,
            Bottom,
            BottomRight
        }

        /// <summary>
        /// 标签控件鼠标按键释放事件
        /// 记录当前鼠标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDesignMode && e.Button == MouseButtons.Left)
            {
                //				SetCapture(Hwnd);
                pointCurrent = new Point(e.X, e.Y);
                Control control = (Control)sender;
                Point pointCursor = Cursor.Position;
                pointCursor.Offset(-(pointCurrent.X + control.Left), -(pointCurrent.Y + control.Top));
                //				Cursor.Clip = new Rectangle(pointCursor, panelMain.Size);	//采用.Net方法设置区域

                Point pointUL = new Point(0, 0);
                Point pointLR = new Point(panelMain.Width, panelMain.Height);
                Hwnd = panelMain.Handle;
                ClientToScreen(Hwnd, out pointUL);
                ClientToScreen(Hwnd, out pointLR);
                Rectangle rect;
                SetRect(out rect, pointUL.X, pointUL.Y,
                    pointLR.X, pointLR.Y);

                ClipCursor(out rect);
                this.DrawControlPoint((Control)sender);
            }
            CurrentControl = (Control)sender;

        }
        public Control CurrentControl
        {
            set
            {
                
                curControl = value;
            }
            get
            {
                return curControl;
            }
        }
        /// <summary>
        /// 标签控件鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDesignMode) LabelChangeCursor(sender, e, 4, 0);
        }

        /// <summary>
        /// 标签控件鼠标按键释放事件
        /// 如果在设计模式下，将控件移动到鼠标所在位置
        /// 移动范围为panelMain的框内
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDesignMode && e.Button == MouseButtons.Left)	//设计模式下移动标签
            {
                Label lblCurrent = (Label)sender;

                switch (direction)
                {
                    case ResizeDirection.None:
                        l_MoveLeftRight(lblCurrent, e);
                        l_MoveUpDown(lblCurrent, e);
                        break;
                    case ResizeDirection.TopLeft:
                        l_ResizeTop(lblCurrent, e);
                        l_ResizeLeft(lblCurrent, e);
                        //						l_MoveLeftRight(lblCurrent, e);
                        //						l_MoveUpDown(lblCurrent, e);
                        break;
                    case ResizeDirection.Top:
                        l_ResizeTop(lblCurrent, e);
                        //						l_MoveUpDown(lblCurrent, e);
                        break;
                    case ResizeDirection.TopRight:
                        l_ResizeTop(lblCurrent, e);
                        l_ResizeRight(lblCurrent, e);
                        //						l_MoveUpDown(lblCurrent, e);
                        break;
                    case ResizeDirection.Left:
                        l_ResizeLeft(lblCurrent, e);
                        //						l_MoveLeftRight(lblCurrent, e);
                        break;
                    case ResizeDirection.Right:
                        l_ResizeRight(lblCurrent, e);
                        break;
                    case ResizeDirection.BottomLeft:
                        l_ResizeBottom(lblCurrent, e);
                        l_ResizeLeft(lblCurrent, e);
                        //						l_MoveLeftRight(lblCurrent, e);
                        break;
                    case ResizeDirection.Bottom:
                        l_ResizeBottom(lblCurrent, e);
                        break;
                    case ResizeDirection.BottomRight:
                        l_ResizeRight(lblCurrent, e);
                        l_ResizeBottom(lblCurrent, e);
                        break;
                }
                this.DrawControlPoint((Control)sender);
                Cursor.Clip = new Rectangle(0, 0, 0, 0);

            }
        }

        #endregion 标签事件

        #region 标签方法
        /// <summary>
        /// 左右移动
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_MoveLeftRight(Label lblCurrent, MouseEventArgs e)
        {
            int x1 = lblCurrent.Location.X;	//标签左上角X坐标
            int x2 = pointCurrent.X;		//鼠标按键按下时鼠标在标签上的X坐标
            int x3 = e.X;					//鼠标按键释放时鼠标在标签上的X坐标

            int width = panelMain.Width;	//panelMain宽

            Point location = new Point(0, 0);


            location.X = x1 + x3 - x2;


            lblCurrent.Left = location.X;
        }

        /// <summary>
        /// 上下移动
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_MoveUpDown(Label lblCurrent, MouseEventArgs e)
        {
            int y1 = lblCurrent.Location.Y;	//标签左上角Y坐标
            int y2 = pointCurrent.Y;		//鼠标按键按下时鼠标在标签上的Y坐标
            int y3 = e.Y;					//鼠标按键释放时鼠标在标签上的Y坐标

            int height = panelMain.Height;	//panelMain高

            Point location = new Point(0, 0);


            location.Y = y1 + y3 - y2;


            lblCurrent.Top = location.Y;
        }

        /// <summary>
        /// 控件右边位置改变
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_ResizeRight(Label lblCurrent, MouseEventArgs e)
        {
            int x1 = lblCurrent.Location.X;	//标签左上角X坐标
            int x2 = pointCurrent.X;		//鼠标按键按下时鼠标在标签上的X坐标
            int x3 = e.X;					//鼠标按键释放时鼠标在标签上的X坐标

            int width = panelMain.Width;	//panelMain宽

            Size size = new Size(0, 0);


            size.Width = x3;


            if (x1 + size.Width <= 0)
            {
                size.Width = -x1 + 1;
            }

            lblCurrent.Width = size.Width;
        }

        /// <summary>
        /// 控件左边位置改变
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_ResizeLeft(Label lblCurrent, MouseEventArgs e)
        {
            int x1 = lblCurrent.Location.X;	//标签左上角X坐标
            int x2 = pointCurrent.X;		//鼠标按键按下时鼠标在标签上的X坐标
            int x3 = e.X;					//鼠标按键释放时鼠标在标签上的X坐标

            int width = panelMain.Width;	//panelMain宽

            Size size = new Size(0, 0);
            Point location = new Point(0, 0);

            if (x3 + x1 < 0)					//鼠标左右位置在panelMain左边。
            {
                size.Width = x1 + lblCurrent.Width;
                location.X = 0;
            }
            else if (x3 > lblCurrent.Width)		//鼠标左右位置在panelMain右边。
            {
                size.Width = 1;
                location.X = x1 + lblCurrent.Width - 1;
            }
            else							//鼠标左右位置在panelMain中间。
            {
                size.Width = lblCurrent.Width + x2 - x3;
                location.X = x1 + x3 - x2;
            }


            lblCurrent.Width = size.Width;
            lblCurrent.Left = location.X;
        }

        /// <summary>
        /// 控件下边位置改变
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_ResizeBottom(Label lblCurrent, MouseEventArgs e)
        {
            int y1 = lblCurrent.Location.Y;	//标签左上角Y坐标
            int y2 = pointCurrent.Y;		//鼠标按键按下时鼠标在标签上的Y坐标
            int y3 = e.Y;					//鼠标按键释放时鼠标在标签上的Y坐标

            int height = panelMain.Height;	//panelMain宽

            Size size = new Size(0, 0);

            size.Height = y3;


            if (y1 + size.Height <= 0)
                size.Height = -y1 + 1;

            lblCurrent.Height = size.Height;
        }

        /// <summary>
        /// 控件上边位置改变
        /// </summary>
        /// <param name="lblCurrent"></param>
        /// <param name="e"></param>
        private void l_ResizeTop(Label lblCurrent, MouseEventArgs e)
        {
            int y1 = lblCurrent.Location.Y;	//标签左上角Y坐标
            int y2 = pointCurrent.Y;		//鼠标按键按下时鼠标在标签上的Y坐标
            int y3 = e.Y;					//鼠标按键释放时鼠标在标签上的Y坐标

            int height = panelMain.Height;	//panelMain宽

            Size size = new Size(0, 0);
            Point location = new Point(0, 0);

            if (y3 + y1 < 0)					//鼠标左右位置在panelMain左边。
            {
                size.Height = y1 + lblCurrent.Height;
                location.Y = 0;
            }
            else if (y3 > lblCurrent.Height)		//鼠标左右位置在panelMain右边。
            {
                size.Height = 1;
                location.Y = y1 + lblCurrent.Height - 1;
            }
            else							//鼠标左右位置在panelMain中间。
            {
                size.Height = lblCurrent.Height + y2 - y3;
                location.Y = y1 + y3 - y2;
            }



            lblCurrent.Height = size.Height;
            lblCurrent.Top = location.Y;
        }

        /// <summary>
        /// 鼠标放在标签控件不同位置时
        /// 改变鼠标形状
        /// 设置改变大小方向值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void LabelChangeCursor(System.Object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
        {
            if (e.Button != MouseButtons.None) return;
            Control c = new Control();
            c = (Control)sender;
            if (e.X < i)
            {
                if (e.Y < i)	//左上角
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    direction = ResizeDirection.TopLeft;
                }
                else if (e.Y > c.Height - i - j)	//左下角
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    direction = ResizeDirection.BottomLeft;
                }
                else		//左边
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeWE;
                    direction = ResizeDirection.Left;
                }

            }
            else if (e.X > c.Width - i - j)
            {

                if (e.Y < i)	//右上角
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    direction = ResizeDirection.TopRight;
                }
                else if (e.Y > c.Height - i - j) //右下角
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    direction = ResizeDirection.BottomRight;
                }
                else		//右边
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeWE;
                    direction = ResizeDirection.Right;
                }
            }
            else
            {
                if (e.Y > c.Height - i - j)	//上边
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNS;
                    direction = ResizeDirection.Bottom;
                }
                else if (e.Y < i)		//下边
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeNS;
                    direction = ResizeDirection.Top;
                }
                else		//中间
                {
                    c.Cursor = System.Windows.Forms.Cursors.SizeAll;
                    direction = ResizeDirection.None;
                }
            }
        }
        #endregion 标签方法

        #region 控件事件
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && isEnterToTab) System.Windows.Forms.SendKeys.Send("{tab}");
        }

        private void c_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isEnterToTab) System.Windows.Forms.SendKeys.Send("{tab}");
            if (this.IsDesignMode)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (CurrentControl.Parent == null) return;
                    CurrentControl = CurrentControl.Parent;
                    this.DrawControlPoint(CurrentControl);
                }
            }
        }
        private void c_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDesignMode)
            {
                if (((Control)sender).Dock != DockStyle.None || sender.GetType().ToString().IndexOf("TabPage") >= 0)
                {
                    ReleaseCapture();
                }
                else
                {
                    MoveControl(sender, e, 4, 0);
                }
            }
            CurrentControl = (Control)sender;
            this.DrawControlPoint((Control)sender);
        }



        private void c_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDesignMode)
            {
                if (((Control)sender).Dock != DockStyle.None || sender.GetType().ToString().IndexOf("TabPage") >= 0)
                {
                    //((Control)sender).Cursor = Cursors.No;
                }
                else
                {
                    ChangeCursor(sender, e, 4, 0);
                }
            }
        }
        #endregion 控件事件

        #region 控件方法
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
        private void ChangeCursor(System.Object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
        {
            Control c = new Control();
            c = (Control)sender;
            if (e.X < i)
            {
                if (e.Y < i)
                    c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                else if (e.Y > c.Height - i - j)
                    c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                else
                    c.Cursor = System.Windows.Forms.Cursors.SizeWE;

            }
            else if (e.X > c.Width - i - j)
            {

                if (e.Y < i)
                    c.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                else if (e.Y > c.Height - i - j)
                    c.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                else
                    c.Cursor = System.Windows.Forms.Cursors.SizeWE;
            }
            else if (e.Y > c.Height - i - j)
                c.Cursor = System.Windows.Forms.Cursors.SizeNS;
            else if (e.Y < i)
                c.Cursor = System.Windows.Forms.Cursors.SizeNS;
            else
                c.Cursor = System.Windows.Forms.Cursors.SizeAll;
        }


        public void DrawControlPoint(Control EmrControl)
        {
            //选择控件,不使用默认窗口
            if (EmrControl.Parent == null) return;

            Rectangle[] rect = new Rectangle[4];
            int PointWidth = 5;
            Graphics g;
            Pen pen = new Pen(Color.Blue);
            SolidBrush myBrush = new SolidBrush(Color.Blue);

            EmrControl.Parent.Refresh();
            if (this.isDrawGrid)
                this.DrawGrid(EmrControl.Parent);

            g = EmrControl.Parent.CreateGraphics();
            rect[0].Location = new System.Drawing.Point(EmrControl.Left - PointWidth, EmrControl.Top - PointWidth);
            rect[0].Size = new System.Drawing.Size(PointWidth, PointWidth);

            rect[1].Location = new System.Drawing.Point(EmrControl.Left + EmrControl.Width, EmrControl.Top - PointWidth);
            rect[1].Size = new System.Drawing.Size(PointWidth, PointWidth);

            rect[2].Location = new System.Drawing.Point(EmrControl.Left - PointWidth, EmrControl.Top + EmrControl.Height);
            rect[2].Size = new System.Drawing.Size(PointWidth, PointWidth);

            rect[3].Location = new System.Drawing.Point(EmrControl.Left + EmrControl.Width, EmrControl.Top + EmrControl.Height);
            rect[3].Size = new System.Drawing.Size(PointWidth, PointWidth);


            for (int i = 0; i <= 3; i++)
            {
                g.FillRectangle(myBrush, rect[i]);
            }
            Pen pen1 = new Pen(Color.Blue);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawLine(pen1, EmrControl.Left, EmrControl.Top - 2, EmrControl.Right, EmrControl.Top - 2);
            g.DrawLine(pen1, EmrControl.Left, EmrControl.Bottom + 2, EmrControl.Right, EmrControl.Bottom + 2);
            g.DrawLine(pen1, EmrControl.Left - 2, EmrControl.Top, EmrControl.Left - 2, EmrControl.Bottom);
            g.DrawLine(pen1, EmrControl.Right + 2, EmrControl.Top, EmrControl.Right + 2, EmrControl.Bottom);

        }
        #endregion 控件方法

        #region 添删控件事件
        private void AddHandle()
        {
            AddEventHandler();
            //			panelMain = parentControl;
            AddHandle(panelMain);
            this.panelMain.MouseDown += this.PanelMouseDown;
            this.panelMain.Paint += PanelPaint;
        }
        private void AddHandle(Control parentControl)
        {
            Type typeLabel = typeof(System.Windows.Forms.Label);

            foreach (Control c in parentControl.Controls)
            {
                Type typeSender = c.GetType();
                if (typeSender.IsSubclassOf(typeLabel) || typeSender == typeLabel)
                {
                    c.MouseDown += LabelMouseDown;
                    c.MouseUp += LabelMouseUp;
                    c.MouseMove += LabelMouseMove;
                    c.KeyUp += ControlKeyUp;
                }
                else
                {
                    c.MouseDown += ControlMouseDown;
                    c.MouseMove += ControlMouseMove;
                    c.KeyUp += ControlKeyUp;
                    //if(c.GetType() == typeof(Panel))c.Paint += PanelPaint;
                }
                if (c.Controls.Count > 0) AddHandle(c);
            }
            return;
        }
        private void RemoveHandle()
        {
            RemoveHandle(panelMain);

            this.panelMain.MouseDown -= this.PanelMouseDown;
            this.panelMain.Paint -= PanelPaint;
        }

        private void RemoveHandle(Control parentControl)
        {
            Type typeLabel = typeof(System.Windows.Forms.Label);

            foreach (Control c in parentControl.Controls)
            {
                Type typeSender = c.GetType();
                if (typeSender.IsSubclassOf(typeLabel) || typeSender == typeLabel)
                {
                    c.MouseDown -= LabelMouseDown;
                    c.MouseUp -= LabelMouseUp;
                    c.MouseMove -= LabelMouseMove;
                    c.KeyUp -= ControlKeyUp;
                }
                else
                {
                    c.MouseDown -= ControlMouseDown;
                    c.MouseMove -= ControlMouseMove;
                    c.KeyUp -= ControlKeyUp;
                }
                //c.Cursor = Cursors.Default;
                if (c.Controls.Count > 0) RemoveHandle(c);
            }
            return;
        }

        #endregion 添删控件事件

        #region 添删控件事件方法

        private MouseEventHandler LabelMouseDown;
        private MouseEventHandler LabelMouseUp;
        private MouseEventHandler LabelMouseMove;
        private MouseEventHandler ControlMouseDown;
        private MouseEventHandler ControlMouseMove;
        private KeyEventHandler ControlKeyUp;
        private KeyPressEventHandler ControlKeyPress;

        private MouseEventHandler PanelMouseDown;
        private System.Windows.Forms.PaintEventHandler PanelPaint;

        private void AddEventHandler()
        {
            if (LabelMouseDown == null)
            {
                LabelMouseDown = new MouseEventHandler(l_MouseDown);
                LabelMouseUp = new MouseEventHandler(l_MouseUp);
                LabelMouseMove = new MouseEventHandler(l_MouseMove);
                ControlMouseDown = new MouseEventHandler(c_MouseDown);
                //				ControlMouseUp = new MouseEventHandler(c_MouseUp);
                ControlMouseMove = new MouseEventHandler(c_MouseMove);
                ControlKeyUp = new KeyEventHandler(c_KeyUp);
                PanelMouseDown = new MouseEventHandler(panelMain_MouseDown);
                PanelPaint = new PaintEventHandler(panelMain_Paint);
            }
        }

        #endregion 添删控件事件方法

        #region 处理缺省鼠标
        /// <summary>
        /// 保存单个控件缺省鼠标
        /// 如果控件已经保存在Xml节点里面，则将鼠标属性更新到节点
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private XmlElement AddOrUpdateControlCursor(Control c)
        {
            string fullName = GetFullName(c, "", this.panelMain.Name);
            if (fullName.TrimEnd().LastIndexOf(".") == fullName.TrimEnd().Length - 1)
            {
                return null;
            }
            XmlElement element = this.GetElementById(fullName);
            if (element != null)
            {
                AddOrUpdateControlProperty(element, "Cursor", c.Cursor.Handle.ToString());
                return element;
            }
            return null;
        }

        /// <summary>
        /// 保存控件缺省鼠标
        /// </summary>
        /// <param name="root"></param>
        /// <param name="parent"></param>
        /// <param name="IsSaveParent"></param>
        private void SaveCursor(XmlNode root, Control parent, bool IsSaveParent)
        {
            if (IsSaveParent)
            {
                AddOrUpdateControlCursor(parent);
            }

            foreach (Control c in parent.Controls)
            {
                AddOrUpdateControlCursor(c);
                if (c.Controls.Count > 0)
                {
                    SaveCursor(root, c, false);
                }
            }
        }

        /// <summary>
        /// 读取缺省鼠标
        /// </summary>
        /// <param name="nodeParent"></param>
        private void ReadCursor(XmlNode nodeParent)
        {
            foreach (XmlNode thisNode in nodeParent.ChildNodes)
            {
                if (thisNode.Attributes["ID"] == null) continue;
                if (thisNode["Cursor"] == null) continue;
                this.RestoreCursor(this.panelMain, thisNode.Attributes["ID"].Value, int.Parse(thisNode["Cursor"].InnerText), true);
            }
        }

        /// <summary>
        /// 恢复缺省鼠标
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="Name"></param>
        /// <param name="Handle"></param>
        /// <param name="IsRestoreParent"></param>
        /// <returns></returns>
        private bool RestoreCursor(Control parent, string Name, int Handle, bool IsRestoreParent)
        {
            try
            {
                if (IsRestoreParent)
                {
                    if (GetFullName(parent, "", this.panelMain.Name) == Name)
                    {
                        parent.Cursor = new Cursor((IntPtr)Handle);
                        return true;
                    }
                }

                // 处理子节点
                foreach (Control c in parent.Controls)
                {
                    if (GetFullName(c, "", this.panelMain.Name) == Name)
                    {
                        c.Cursor = new Cursor((IntPtr)Handle);
                        return true;
                    }
                    if (c.Controls.Count > 0)
                    {
                        if (RestoreCursor(c, Name, Handle, false)) return true;
                    }
                }
            }
            catch { }
            return false;
        }

        #endregion 处理缺省鼠标

        #region 保存加载文件
        /// <summary>
        /// 根据节点ID属性取节点
        /// </summary>
        /// <param name="Name">ID</param>
        /// <returns>节点ID属性等于Name的节点</returns>
        private XmlElement GetElementById(string Name)
        {
            XmlNodeList nodesControl = doc.SelectNodes("UserControl/Control");
            foreach (XmlNode node in nodesControl)
            {
                if (node.Attributes["ID"].Value == Name)
                {
                    return (node as XmlElement);
                }
            }
            return null;
        }
        /// <summary>
        /// 从Xml节点读取是否使用缺省文本设置
        /// </summary>
        /// <param name="control">控件</param>
        /// <returns>是否使用缺省文本</returns>
        public bool GetIsUseDefaultTextSetting(Control control)
        {
            string fullName = GetFullName(control, "", this.panelMain.Name);

            XmlElement element = GetElementById(fullName);
            if (element != null)
            {
                return bool.Parse(element["IsUseDefaultText"].InnerText);
            }
            return !this.AllowChangeText(control);
        }

        /// <summary>
        /// 将是否使用缺省文本保存到Xml节点上
        /// </summary>
        /// <param name="fullName">控件名称（节点ID）</param>
        /// <param name="IsUseDefaultText">布尔值，是否使用缺省文本</param>
        public void SaveIsUseDefaultTextSetting(string fullName, bool IsUseDefaultText)
        {
            XmlElement element = GetElementById(fullName);
            if (element != null)
            {
                element["IsUseDefaultText"].InnerText = IsUseDefaultText.ToString();
            }
        }

        /// <summary>
        /// 保存单个控件配置
        /// 如果控件已经保存在Xml节点里面，则将控件属性更新到节点
        /// 如果控件没有保存在Xml节点里面，则新建节点，保存缺省的使用默认文本的属性，将控件属性保存到节点
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private XmlElement AddOrUpdateControl(Control c)
        {
            string fullName = GetFullName(c, "", this.panelMain.Name);
            XmlElement element = this.GetElementById(fullName);
            if (fullName.TrimEnd().LastIndexOf(".") == fullName.TrimEnd().Length - 1)
            {
                return null;
            }
            if (element == null)
            {
                element = doc.CreateElement("Control");
                myXml.AddNodeAttibute(element, "ID", fullName);
                myXml.AddXmlNode(doc, element, "IsUseDefaultText", (!this.AllowChangeText(c)).ToString());
            }

            AddOrUpdateControlProperty(element, "X", c.Left.ToString());
            AddOrUpdateControlProperty(element, "Y", c.Top.ToString());
            AddOrUpdateControlProperty(element, "Width", c.Width.ToString());
            AddOrUpdateControlProperty(element, "Height", c.Height.ToString());
            AddOrUpdateControlProperty(element, "ForeColor", c.ForeColor.ToArgb().ToString());
            AddOrUpdateControlProperty(element, "BackColor", c.BackColor.ToArgb().ToString());
            AddOrUpdateControlProperty(element, "FontFamily", c.Font.FontFamily.Name);
            AddOrUpdateControlProperty(element, "FontSize", c.Font.Size.ToString());
            AddOrUpdateControlProperty(element, "FontSizeUnit", c.Font.Unit.ToString());
            AddOrUpdateControlProperty(element, "FontStyle", c.Font.Style.ToString());
            AddOrUpdateControlProperty(element, "Text", c.Text);
            AddOrUpdateControlProperty(element, "TabIndex", c.TabIndex.ToString());
            AddOrUpdateControlProperty(element, "Visible", c.Visible.ToString());
            AddOrUpdateControlProperty(element, "Enabled", c.Enabled.ToString());
            return element;
        }
        /// <summary>
        /// 保存控件单个属性
        /// </summary>
        /// <param name="element"></param>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        private void AddOrUpdateControlProperty(XmlElement element, string Name, string Value)
        {
            XmlElement ChildElement = (XmlElement)element.SelectSingleNode(Name);
            if (ChildElement != null)
            {
                ChildElement.InnerText = Value;
            }
            else
            {
                myXml.AddXmlNode(doc, element, Name, Value);
            }
        }
        /// <summary>
        /// 保存每一个控件配置
        /// 嵌套循环每一个控件
        /// </summary>
        /// <param name="root"></param>
        /// <param name="parent"></param>
        /// <param name="IsSaveParent"></param>
        private void SaveControl(XmlNode root, Control parent, bool IsSaveParent)
        {
            if (IsSaveParent)
            {
                XmlElement element = AddOrUpdateControl(parent);
                if (element != null)
                {
                    root.AppendChild(element);
                }
            }

            foreach (Control c in parent.Controls)
            {

                XmlElement element = AddOrUpdateControl(c);
                if (c.Controls.Count > 0)
                {
                    SaveControl(root, c, false);
                }
                if (element != null)
                {
                    root.AppendChild(element);
                }
            }
        }
        /// <summary>
        /// 保存控件配置
        /// 保存使用默认属性
        /// 保存每一个控件配置
        /// 保存Xml文件
        /// </summary>
        internal void SaveFile()
        {
            XmlElement root = doc.DocumentElement;
            root.SetAttribute("UseDefault", this.isCustom.ToString());
            root.SetAttribute("BackColor", this.panelMain.BackColor.ToArgb().ToString());
            try
            {
                this.SaveControl(root, this.panelMain, true);
            }
            catch { return; }
            //			}
            try
            {
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(Application.StartupPath + "\\Xml");
                if (!info.Exists) System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Xml");
                System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.StartupPath + "\\xml\\" + this.XmlFileName, false, System.Text.Encoding.Default);
                writer.Write(doc.OuterXml);
                writer.Close();
            }
            catch { }
        }
        /// <summary>
        /// 读取节点设置到Xml配置文件
        /// </summary>
        /// <param name="nodeParent"></param>
        private void ReadNode(XmlNode nodeParent)
        {
            foreach (XmlNode thisNode in nodeParent.ChildNodes)
            {
                try
                {
                    ControlProperty prop = new ControlProperty();
                    prop.Name = thisNode.Attributes["ID"].Value;
                    prop.BackColor = Color.FromArgb(int.Parse(thisNode["BackColor"].InnerText));
                    prop.ForeColor = Color.FromArgb(int.Parse(thisNode["ForeColor"].InnerText));
                    prop.Location = new Point(int.Parse(thisNode["X"].InnerText), int.Parse(thisNode["Y"].InnerText));
                    prop.Size = new Size(int.Parse(thisNode["Width"].InnerText), int.Parse(thisNode["Height"].InnerText));
                    prop.IsVisible = bool.Parse(thisNode["Visible"].InnerText);
                    prop.IsEnabled = bool.Parse(thisNode["Enabled"].InnerText);
                    prop.Text = thisNode["Text"].InnerText;
                    prop.TabIndex = int.Parse(thisNode["TabIndex"].InnerText);
                    prop.Font = new Font(thisNode["FontFamily"].InnerText, float.Parse(thisNode["FontSize"].InnerText), (FontStyle)Enum.Parse(typeof(FontStyle), thisNode["FontStyle"].InnerText), (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), thisNode["FontSizeUnit"].InnerText));
                    prop.IsUseDefaultText = bool.Parse(thisNode["IsUseDefaultText"].InnerText);

                    this.CustomControl(this.panelMain, prop, true);
                    if (thisNode.ChildNodes.Count > 0)
                    {
                        ReadNode(thisNode);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 读取控件配置
        /// </summary>
        internal void ReadFile(bool isMustReadNode)
        {
            if (this.panelMain == null || this.XmlFileName == "") return;
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(Application.StartupPath + "\\Xml");
            if (!info.Exists) System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Xml");
            doc = new XmlDocument();

            doc = myXml.LoadXml(Application.StartupPath + "\\xml\\" + XmlFileName);
            if (doc == null)
            {
                this.isCustom = true;
                return;
            }
            XmlNode node;
            try
            {
                node = doc.SelectSingleNode("//UserControl");
                if ((node.Attributes["UseDefault"].Value).ToLower() == "false")
                {
                    this.isCustom = false;
                }
                else
                {
                    this.isCustom = true;
                }
            }
            catch { return; }
            if (this.isCustom && !isMustReadNode) return;
            try
            {
                this.panelMain.BackColor = Color.FromArgb(int.Parse(node.Attributes["BackColor"].Value.ToString()));
            }
            catch { }
            ReadNode(node);
        }

        /// <summary>
        /// 更改控件属性
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="prop"></param>
        /// <param name="IsCustomParent"></param>
        /// <returns></returns>
        private bool CustomControl(Control parent, ControlProperty prop, bool IsCustomParent)
        {
            try
            {
                //如果包括容器节点，首先处理根节点
                if (IsCustomParent)
                {
                    if (GetFullName(parent, "", this.panelMain.Name) == prop.Name)
                    {
                        parent.Location = prop.Location;
                        parent.Size = prop.Size;
                        parent.ForeColor = prop.ForeColor;
                        parent.BackColor = prop.BackColor;
                        parent.Visible = prop.IsVisible;
                        parent.Enabled = prop.IsEnabled;
                        parent.TabIndex = prop.TabIndex;
                        parent.Font = prop.Font;
                        try
                        {
                            if (!prop.IsUseDefaultText)
                            {
                                parent.Text = prop.Text;
                            }
                        }
                        catch { }
                        return true;
                    }
                }

                // 处理子节点
                foreach (Control c in parent.Controls)
                {
                    if (GetFullName(c, "", this.panelMain.Name) == prop.Name)
                    {
                        c.Location = prop.Location;
                        c.Size = prop.Size;
                        c.ForeColor = prop.ForeColor;
                        c.BackColor = prop.BackColor;
                        c.Enabled = prop.IsEnabled;
                        c.TabIndex = prop.TabIndex;
                        c.Font = prop.Font;
                        if (prop.Name.IndexOf("tabControl") < 0) c.Visible = prop.IsVisible;
                        try
                        {
                            if (!prop.IsUseDefaultText)
                            {
                                c.Text = prop.Text;
                            }
                        }
                        catch { }
                        if (c.GetType() == typeof(ComboBox))
                            ((ComboBox)c).Select(0, 0);
                        return true;
                    }
                    if (c.Controls.Count > 0)
                    {
                        if (CustomControl(c, prop, false)) return true;
                    }
                }
            }
            catch { }
            return false;
        }

        #endregion 保存加载文件

        /// <summary>
        /// 读取默认的是否允许使用自定义文本
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal bool AllowChangeText(Control c)
        {
            foreach (Type type in this.TypeChangeText)
            {
                if (type != null)
                {
                    if (type == c.GetType() || c.GetType().IsSubclassOf(type))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #region 属性窗口
       
        #endregion

        #region 容器控件方法与事件
        private void panelMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (this.isDesignMode && this.IsDrawGrid) this.DrawGrid((Control)sender);
        }

        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
        private void DrawGrid()
        {
            if (this.isDrawGrid)
                this.DrawGrid(this.panelMain);
        }
        private void DrawGrid(Control c)
        {

            if (this.isDrawGrid == false) return;
            int i, j;
            Graphics g = c.CreateGraphics();
            Pen pen = new Pen(Color.Blue);

            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            try
            {
                for (i = 0; i < c.Height; i = i + 40)
                {
                    try
                    {
                        g.DrawString(i.ToString(), new Font("Arial", 6), drawBrush, new Point(0, i));
                        g.DrawLine(pen, 0, i, c.Width, i);

                    }
                    catch { }
                }
                for (j = 0; j < c.Width; j = j + 40)
                {
                    g.DrawString(j.ToString(), new Font("Arial", 6), drawBrush, new Point(j, 0));
                    g.DrawLine(pen, j, 0, j, c.Height);

                }
            }
            catch { }

        }

        private void propertyform_Closing(object sender, CancelEventArgs e)
        {
            this.IsDesignMode = false;
            ((Form)sender).Hide();
            e.Cancel = true;
        }

        public static string GetFullName(Control control, string name, string TopName)
        {
            if (name == "") name = control.Name;
            if (control.Parent != null && control.Name != TopName)
            {
                name = control.Parent.Name + "." + name;
                return GetFullName(control.Parent, name, TopName);
            }
            return name;
        }
        #endregion 容器控件方法与事件

        private void DesignControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.isDesignMode)
            {
                if (CurrentControl == null) return;
                if (e.Control == false && e.KeyCode == Keys.Up)
                {
                    CurrentControl.Location = new Point(CurrentControl.Left, CurrentControl.Top - 1);
                }
                else if (e.Control == false && e.KeyCode == Keys.Down)
                {
                    CurrentControl.Location = new Point(CurrentControl.Left, CurrentControl.Top + 1);
                }
                else if (e.Control == false && e.KeyCode == Keys.Left)
                {
                    CurrentControl.Location = new Point(CurrentControl.Left - 1, CurrentControl.Top);
                }
                else if (e.Control == false && e.KeyCode == Keys.Right)
                {
                    CurrentControl.Location = new Point(CurrentControl.Left + 1, CurrentControl.Top);
                }
                else if (e.Control && e.KeyCode == Keys.Up)
                {
                    CurrentControl.Size = new Size(CurrentControl.Width, CurrentControl.Height - 1);
                }
                else if (e.Control && e.KeyCode == Keys.Down)
                {
                    CurrentControl.Size = new Size(CurrentControl.Width, CurrentControl.Height + 1);
                }
                else if (e.Control && e.KeyCode == Keys.Left)
                {
                    CurrentControl.Size = new Size(CurrentControl.Width - 1, CurrentControl.Height);
                }
                else if (e.Control && e.KeyCode == Keys.Right)
                {
                    CurrentControl.Size = new Size(CurrentControl.Width + 1, CurrentControl.Height);
                }
                else
                {
                    return;
                }

                this.DrawControlPoint(CurrentControl);
            }

        }
    }
    /// <summary>
    /// 控件属性结构
    /// </summary>
    internal struct ControlProperty
    {
        public string Name;
        public Color ForeColor;
        public Color BackColor;
        public Point Location;
        public Size Size;
        public bool IsVisible;
        public bool IsEnabled;
        public string Text;
        public int TabIndex;
        public Font Font;
        public bool IsUseDefaultText;
    }
}
