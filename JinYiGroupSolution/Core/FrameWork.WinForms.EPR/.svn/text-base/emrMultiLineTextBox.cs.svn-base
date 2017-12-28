using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Neusoft.FrameWork.EPRControl
{
    /// <summary>
    /// 多功能多行文本
    /// </summary>
    [System.Drawing.ToolboxBitmap(typeof(RichTextBox))]
    public partial class emrMultiLineTextBox : RichTextBox,IGroup, IControlPrintable,StructInput.IStructable
    {
        public emrMultiLineTextBox()
        {
            base.HideSelection = false;
            this.InitializeComponent();
        }

        bool bnew = true;//是否新添加
        private bool isShowModify = false;
        private bool isDrawLine = false;
        bool bNoControl = false;
        string copyrtf = "";

        #region "组"

        private string ControlName;
        /// <summary>
        /// 组名
        /// </summary>
        private string GroupName = "无";
        private bool blnIsGroup;
        /// <summary>
        /// 是否分组
        /// </summary>
        private bool bIsGroup;
        private System.EventArgs e;
        public event NameChangedEventHandler NameChanged;
        public event IsGroupChangedEventHandler IsGroupChanged;
        public event GroupChangedEventHandler GroupChanged;


        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        public string 名称
        {
            get
            {
                if (this.ControlName == "")
                {
                    this.ControlName = this.Name;
                }
                return this.ControlName;
            }
            set
            {
                if (CheckValue(value, 0) == false) return;
                ControlName = value.Trim();
                try
                {
                    if (NameChanged != null)
                    {
                        NameChanged(this, e);
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        [TypeConverter(typeof(emrGroup)), Browsable(true), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
        public string 组
        {
            get { return this.GroupName; }
            set
            {
                if (CheckValue(value, 1) == false) return;
                this.GroupName = value.Trim();
                try
                {
                    if (GroupChanged != null)
                    {
                        GroupChanged(this, e);
                    }
                }

                catch (Exception ex) { }
            }
        }

        [CategoryAttribute("设计"), Browsable(false), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!")]
        public bool 是否组
        {
            get { return this.bIsGroup; }
            set
            {
                this.bIsGroup = value;
                try
                {
                    if (IsGroupChanged != null)
                    {
                        IsGroupChanged(this, e);
                    }
                }
                catch (Exception ex) { }
            }
        }
        private bool CheckValue(string value, int i)
        {
            bool right = true;
            if (value == null || value == "") return false;
            if ((value.Trim() == "")) right = false;
            if ((value.IndexOf("\\") >= 0)) right = false;
            if ((value.IndexOf("/") >= 0)) right = false;
            if ((value.IndexOf(">") >= 0)) right = false;
            if ((value.IndexOf("<") >= 0)) right = false;
            if ((value.IndexOf("=") >= 0)) right = false;
            if ((value.IndexOf(".") >= 0)) right = false;
            if ((value.IndexOf(",") >= 0)) right = false;
            if ((value.IndexOf("%") >= 0)) right = false;
            if (i == 0)
            {
                //名称
                if ((value == this.GroupName))
                {
                    MessageBox.Show("名称和组不能同名！");
                    return false;
                }
            }
            else
            {
                if (value == this.ControlName)
                {
                    MessageBox.Show("名称和组不能同名！");
                    return false;
                }
            }
            if (!right)
            {
                MessageBox.Show("不能包含非法字符！");
            }
            return right;
        }
        #endregion

        void emrMultiLineTextBox_Invalidated(object sender, InvalidateEventArgs e)
        {
            #region iShowModify
            if (IsShowModify == false) return;
            if (bnew == false) return;
            if (this.TextLength != 0)
            {
                this.Select(0, this.TextLength - 1);
                this.SelectionProtected = true;
                this.Select(0, 0);
            }
            bnew = false;

            #endregion
        }
  
        [CategoryAttribute("扩展功能"),Browsable (true ),DescriptionAttribute("是否显示修改痕迹;如：添加，删除")]
        public bool IsShowModify
        {
            get 
            {
                return isShowModify;
            }
            set 
            {
                this.isShowModify = value;
                if (value)
                {
                    if (this.TextLength != 0)
                    {
                        this.Select(0, this.TextLength - 1);
                        this.SelectionProtected = true;
                        this.Select(0, 0);
                    }
                }

            }
        }

        [CategoryAttribute("扩展功能"),Browsable (true ),DescriptionAttribute("是否在控件中显示页码标线")]
        public bool IsDrawLine 
        {
            get 
            {
                return this.isDrawLine;
            }
            set 
            {
                this.isDrawLine = value;
            }
        }

        #region 修改痕迹
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            richTextBox1_KeyPress(this, e);
            base.OnKeyPress(e);
        }
        System.Windows.Forms.ToolTip tooltip = new ToolTip();
        protected override void OnKeyDown(KeyEventArgs e)
        {
            #region 是否显示修改
            if (IsShowModify == true)
            {
                try
                {

                    bNoControl = false;
                    if (e.KeyCode == Keys.Delete)
                    {

                        if (this.SelectionLength <= 0)
                        {
                            this.Select(this.SelectionStart, 1);
                        }
                        if (this.SelectionProtected == false)
                        {
                            this.SelectedText = "";
                            e.Handled = true;
                            return;
                        }
                        if (this.SelectedText == " ")
                        {
                            this.Select(this.SelectionStart, 0);
                            e.Handled = true;
                            return;
                        }
                        this.SelectionProtected = false;
                        if (this.SelectionFont.Strikeout)
                        {
                            this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                            this.SelectionColor = Color.Black;
                        }
                        else
                        {
                            this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Strikeout);
                            this.SelectionColor = Color.Blue;
                        }
                        this.SelectionProtected = true;
                        this.Select(this.SelectionStart + 1, 0);
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Back)
                    {
                        if (this.SelectionLength <= 0)
                        {
                            this.Select(this.SelectionStart - 1, 1);

                        }
                        if (this.SelectionProtected == false)
                        {
                            this.SelectedText = "";
                            e.Handled = true;
                            return;
                        }
                        if (this.SelectedText == " ")
                        {
                            this.Select(this.SelectionStart, 0);
                            e.Handled = true;
                            return;
                        }
                        this.SelectionProtected = false;
                        if (this.SelectionFont.Strikeout)
                        {
                            this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                            this.SelectionColor = Color.Black;
                        }
                        else
                        {
                            this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Strikeout);
                            this.SelectionColor = Color.Blue;
                        }
                        this.SelectionProtected = true;
                        this.Select(this.SelectionStart, 0);
                        e.Handled = true;
                    }
                    else if (e.KeyCode.GetHashCode() == Keys.V.GetHashCode() && e.Modifiers == Keys.Control)
                    {
                        bNoControl = true;

                        e.Handled = false;

                    }
                    else if (e.KeyCode.GetHashCode() == Keys.C.GetHashCode() && e.Modifiers == Keys.Control)
                    {
                        copyrtf = this.SelectedRtf;
                        this.SelectionProtected = false;
                        bNoControl = true;
                        return;
                    }
                    else if (e.KeyCode.GetHashCode() == Keys.Z.GetHashCode() && e.Modifiers == Keys.Control)
                    {
                        bNoControl = true;
                    }
                    else if (e.KeyCode.GetHashCode() == Keys.A.GetHashCode() && e.Modifiers == Keys.Control)
                    {
                        bNoControl = true;
                    }
                    copyrtf = "";
                }
                catch { }
                base.OnKeyDown(e);
            }
            else
            {
                base.OnKeyDown(e);
            }
            #endregion
        }
     
        private void richTextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            #region IsShowModify

            if (IsShowModify == false) return;
            try
            {

                if (bNoControl)
                {
                    if (copyrtf != "")
                    {
                        this.SelectedRtf = copyrtf;
                        copyrtf = "";
                    }
                    e.Handled = true;

                    return;
                }
                if (e.KeyChar == (char)Keys.Back)
                {



                }
                else if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
                {
                }
                else
                {
                    if (this.SelectionStart > this.TextLength - 2)
                    {

                    }
                    else
                    {
                        this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                        this.Select(this.SelectionStart, 0);
                        this.SelectionColor = Color.Red;
                        this.SelectionProtected = false;

                        this.Select(this.SelectionStart, 0);
                        this.SelectionFont = new Font(this.SelectionFont.FontFamily.Name, this.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                        this.SelectionColor = Color.Red;
                    }
                    //e.Handled = false;
                }
            }
            catch { }
            
    #endregion

        }

        private void SetVisibleText()
        {

            for (int i = this.TextLength; i >= 0; i--)
            {
                this.Select(i, 1);
                bool b = this.SelectionProtected;
                this.SelectionProtected = false;
                if (this.SelectionColor == Color.Red)
                {
                    this.SelectionColor = Color.Black;
                }
                else if (this.SelectionColor == Color.Blue && this.SelectionFont.Strikeout == true)
                {

                    this.SelectedText = "";
                }
                else
                {
                    this.SelectionColor = Color.Black;
                }
                this.SelectionProtected = b;
                 
            }
        }
    
        #endregion


        #region 画分页
        const int EM_LINESCROLL = 0x00B6;
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);

        public void myPaint()
        {
            this.Refresh();
            Graphics g = this.CreateGraphics();
            g.PageUnit = GraphicsUnit.Point;
            int y = 0;
            int currentY = GetScrollPos(this.Handle, 1);
            int lastY = this.GetPositionFromCharIndex(this.TextLength).Y;
            for (int i = 1; i < 20; i++)//lastY/this.Height + 5
            {
                y = (this.Height - 2) * i - currentY;
                g.DrawLine(new System.Drawing.Pen(Color.Blue, 2), 0, y, this.Width, y);
                g.DrawString(string.Format("第{0}页", i), this.Font, new SolidBrush(Color.LightPink), new Point(this.Width - 70, y));
            }


        }

        int mouseX;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            #region isDrawLine
            if (e.Button == MouseButtons.Right)
            {
                base.OnMouseMove(e);
                return;
            }
            if (this.isDrawLine ==false )return ;
            if (e.X - mouseX > 10 || mouseX - e.X > 10)
                this.myPaint();
            mouseX = e.X;
        
            #endregion
    }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            #region isDrawLine

            if (e.Button == MouseButtons.Right)
            {
                base.OnMouseUp(e);
                return;
            }
            if (isDrawLine == false) return;
            this.myPaint();

            #endregion
        }       

        #endregion

        #region 连续打印
        private const double aninch = 14.4;
        private const int em_formatrange = 0x439;
        private const int wm_user = 0x400;

        public int print(int charfrom, int charto, PrintPageEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, e.MarginBounds.Width, 0);
            return this.print(charfrom, charto, e, rectangle, e.Graphics);
        }

        public int print(int charfrom, int charto, PrintPageEventArgs e, Rectangle rectangle)
        {
            return this.print(charfrom, charto, e, rectangle, e.Graphics);
        }
        public int print(int charfrom, int charto, PrintPageEventArgs e, Rectangle rectangle, Graphics grap)
        {
            charRange cRange;
            formatRange fRange;
            Rect rectPage;
            Rect rectToPrint;

            //要打印的字符
            cRange.charPositionMin = charfrom;
            cRange.charPositionMax = charto;

            //打印区域
            rectToPrint.top = (int)Math.Round((double)((rectangle.Top + e.MarginBounds.Top) * aninch - e.Graphics.MeasureString("李", this.Font).Height * aninch / 2.5));
            if (rectangle.Height != 0)
            {
                rectToPrint.bottom = (int)Math.Round((double)((rectangle.Bottom + e.MarginBounds.Top) * aninch - e.Graphics.MeasureString("李", this.Font).Height * aninch / 2.5));
            }
            else
            {
                rectToPrint.bottom = (int)Math.Round((double)(e.MarginBounds.Bottom * aninch) - e.Graphics.MeasureString("李", this.Font).Height * aninch / 2.5);
            }
            rectToPrint.left = (int)Math.Round((double)((rectangle.Left + e.MarginBounds.Left) * aninch));
            rectToPrint.right = (int)Math.Round((double)((rectangle.Right + e.MarginBounds.Left) * aninch));

            //整个页面
            rectPage.top = (int)Math.Round((double)(e.PageBounds.Top * aninch));
            rectPage.bottom = (int)Math.Round((double)(e.PageBounds.Bottom * aninch));
            rectPage.left = (int)Math.Round((double)(e.PageBounds.Left * aninch));
            rectPage.right = (int)Math.Round((double)(e.PageBounds.Right * aninch));

            //打印内容
            IntPtr hdc = grap.GetHdc();
            //IntPtr hdc1 = e.Graphics.GetHdc();
            fRange.chrg = cRange;
            fRange.hdc = hdc;
            fRange.hdctarget = hdc;
            fRange.rc = rectToPrint;
            fRange.rcpage = rectPage;
            IntPtr res = IntPtr.Zero;
            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1);
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fRange));
            Marshal.StructureToPtr(fRange, lparam, false);

            //打印
            this.ClearUndo();
            this.AdjustLineSpace(this, 2);
            res = sendmessage(this.Handle, em_formatrange, wparam, lparam);
            this.Undo();

            //释放资源
            Marshal.FreeCoTaskMem(lparam);
            grap.ReleaseHdc(hdc);
            return res.ToInt32();
        }

        [DllImport("user32.dll", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr sendmessage(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp);
        public int VirtualPrint(int charfrom, int charto, PrintPageEventArgs e, Image image)
        {
            charRange crange;
            formatRange fmtrange;
            Rect rectpage;
            Rect recttoprint;

            //要打印的字符
            crange.charPositionMin = charfrom;
            crange.charPositionMax = charto;

            //打印区域
            recttoprint.top = (int)Math.Round((double)(e.MarginBounds.Top * aninch));
            recttoprint.bottom = (int)Math.Round((double)(e.MarginBounds.Bottom * aninch));
            recttoprint.left = (int)Math.Round((double)(e.MarginBounds.Left * aninch));
            recttoprint.right = (int)Math.Round((double)(e.MarginBounds.Right * aninch));

            //整个页面
            rectpage.top = (int)Math.Round((double)(e.PageBounds.Top * aninch));
            rectpage.bottom = (int)Math.Round((double)(e.PageBounds.Bottom * aninch));
            rectpage.left = (int)Math.Round((double)(e.PageBounds.Left * aninch));
            rectpage.right = (int)Math.Round((double)(e.PageBounds.Right * aninch));
            Graphics graph = Graphics.FromImage(image);
            graph.PageUnit = GraphicsUnit.Point;

            //打印内容
            IntPtr hdc = graph.GetHdc();
            fmtrange.chrg = crange;
            fmtrange.hdc = hdc;
            fmtrange.hdctarget = hdc;
            fmtrange.rc = recttoprint;
            fmtrange.rcpage = rectpage;
            IntPtr res = IntPtr.Zero;
            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1);
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtrange));
            Marshal.StructureToPtr(fmtrange, lparam, false);

            //打印
            res = sendmessage(this.Handle, em_formatrange, wparam, lparam);

            //释放资源
            Marshal.FreeCoTaskMem(lparam);
            graph.ReleaseHdc(hdc);
            return res.ToInt32();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct charRange
        {
            public int charPositionMin;
            public int charPositionMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct formatRange
        {
            public IntPtr hdc;
            public IntPtr hdctarget;
            public Rect rc;
            public Rect rcpage;
            public charRange chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        #endregion 连续打印

        #region Snomed 成员

        string snomed = "";
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("Snomed编码")]
        public string Snomed
        {
            get
            {
                return snomed;
            }
            set
            {
                snomed = value;

            }
        }

        #endregion

        public const int WM_USER = 0x0400;
        public const int EM_GETPARAFORMAT = WM_USER + 61;
        public const int EM_SETPARAFORMAT = WM_USER + 71;
        public const long MAX_TAB_STOPS = 32;
        public const uint PFM_LINESPACING = 0x00000100;
        [StructLayout(LayoutKind.Sequential)]
        private struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT2 lParam);
        //调整高度
        public void AdjustLineSpace(RichTextBox rc, double times)
        {
            rc.SelectAll();
            //double RowDist = double.Parse(this.comboBox1.Text);
            //RichTextBox行距为RowDist

            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.bLineSpacingRule = 4; //4：固定高度
            fmt.dyLineSpacing = (int)(((int)rc.Font.Size) * 20 * times);
            fmt.dwMask = PFM_LINESPACING;
            SendMessage(new HandleRef(rc, rc.Handle), EM_SETPARAFORMAT, 0, ref fmt);

        }

        #region IControlPrintable
        public virtual System.Windows.Forms.Control PrintControl()
        {
            emrMultiLineTextBox ctr = new emrMultiLineTextBox();
            ctr.Location = this.Location;
            ctr.Size = this.Size;
            ctr.Rtf = this.Rtf;
            return ctr;
        }
        public System.Collections.ArrayList arrSortedControl()
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="rectangle"></param>
        /// <param name="grap"></param>
        public virtual void continuePrint(PrintPageEventArgs e, Rectangle rectangle, Graphics grap)
        {
            return;
        }
        public void Print(PrintPageEventArgs e, Rectangle rectangle, Graphics grap)
        {
        }
        public void SetText(string fileID)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion IControlPrintable

        #region IStructable 成员

        private string searchTable;
        [TypeConverter(typeof(StructInput.SearchTableConvert)), Category("设计"), Description("查找的分类表")]
        public string SearchTable
        {
            get
            {
                return this.searchTable;
            }
            set
            {
                this.searchTable = value;
            }
        }

        private StructInput.enumSearchType searchType;
        [TypeConverter(typeof(StructInput.SearchTypeConvert)), Category("设计"), Description("查找方式：中文名、编码、英文名、拼音、五笔"), DefaultValue(StructInput.enumSearchType.CNOMEN)]
        public StructInput.enumSearchType SearchType
        {
            get
            {
                return this.searchType;
            }
            set
            {
                this.searchType = value;
            }
        }

        private bool isExactSearch;
        [Category("设计"), Description("是否精确查询")]
        public bool IsExactSearch
        {
            get
            {
                return this.isExactSearch;
            }
            set
            {
                this.isExactSearch = value;
            }
        }

        public int SelectionIndex
        {
            get
            {
                return this.SelectionStart;
            }
        }

        private int keyWordIndex;
        public int KeyWordIndex
        {
            get
            {
                return this.keyWordIndex;
            }
            set
            {
                this.keyWordIndex = value;
            }
        }

        public string SelectText
        {
            get
            {
                return base.SelectedText;
            }
            set
            {
                base.SelectedText = value;
            }
        }

        public Point GetPositionFromIndex(int index)
        {
            return this.GetPositionFromCharIndex(index);
        }

        public void SelectKeyWord(int start, int length)
        {
            base.Select(start, length);
        }
        #endregion
    }
}
