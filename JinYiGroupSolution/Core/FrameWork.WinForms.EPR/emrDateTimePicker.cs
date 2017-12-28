using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Neusoft.FrameWork.EPRControl
{
    [System.Drawing.ToolboxBitmap(typeof(TextBox))]
    public partial class emrDateTimePicker : TextBox, IGroup
    {
        public emrDateTimePicker()
        {
            InitializeComponent();
        //    myTSMonthCalendar = new ToolStripMonthCalendar();
        //    tsDD = new ToolStripDropDown();

        //    this.myTSMonthCalendar.MonthCalendarControl.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.myTSMonthCalendar_DateChanged);
        //    this.myTSMonthCalendar.MonthCalendarControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTSMonthCalendar_KeyDown);
        //    this.myTSMonthCalendar.MonthCalendarControl.DateSelected += new DateRangeEventHandler(MonthCalendarControl_DateSelected);
        //    tsDD.Closing += new ToolStripDropDownClosingEventHandler(tsDD_Closing);
        }
        public emrDateTimePicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            myTSMonthCalendar = new ToolStripMonthCalendar();
            tsDD = new ToolStripDropDown();

            this.myTSMonthCalendar.MonthCalendarControl.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.myTSMonthCalendar_DateChanged);
            this.myTSMonthCalendar.MonthCalendarControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTSMonthCalendar_KeyDown);
            this.myTSMonthCalendar.MonthCalendarControl.DateSelected += new DateRangeEventHandler(MonthCalendarControl_DateSelected);
            tsDD.Closing += new ToolStripDropDownClosingEventHandler(tsDD_Closing);
        }
       

        #region 变量
        ToolStripMonthCalendar myTSMonthCalendar;
        ToolStripDropDown tsDD;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_RETURN = 0x0D;
        #endregion

        #region 方法
        private Point CalculatePoz()
        {
            Point point = new Point(0, this.Height);

            if ((this.PointToScreen(new Point(0, 0)).Y + this.Height + this.myTSMonthCalendar.Height) > Screen.PrimaryScreen.WorkingArea.Height)
            {
                point.Y = -this.myTSMonthCalendar.Height - 7;
            }

            return point;
        }
        private void ShowDropDown()
        {
            this.tsDD.Refresh();
            if (!this.tsDD.Visible)
            {
                if (this.Text != "")
                    this.myTSMonthCalendar.MonthCalendarControl.SetDate(Convert.ToDateTime(this.Text));
                tsDD.Items.Add(this.myTSMonthCalendar);
                tsDD.Show(this, this.CalculatePoz());
            }
        }

        private void CloseDropDown()
        {
            if (tsDD.Visible)
            {
                tsDD.Close();
            }
        }


        #endregion

        #region 重写方法

        protected override void OnEnter(EventArgs e)
        {
            ShowDropDown();
            base.OnEnter(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            ShowDropDown();
            base.OnMouseClick(e);
        }

        #endregion

        #region 事件

        [DllImport("user32.dll")]
        public extern static int SendMessage(IntPtr handle, int i, int j, int flag);

        void MonthCalendarControl_DateSelected(object sender, DateRangeEventArgs e)
        {
            CloseDropDown();

        }
        private void myTSMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.Text = e.End.ToShortDateString();
        }
        private void myTSMonthCalendar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.tsDD.Close();

        }

        void tsDD_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            SendMessage(this.Handle, WM_KEYDOWN, VK_RETURN, 0);
        }

        #endregion

        #region "组"
        private string ControlName;
        private string GroupName;
        private bool blnIsGroup;
        private System.EventArgs e;
        private bool bIsGroup;
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
                if (Module.ValidName(value) == false)
                    return;

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
        [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
        public string 组
        {
            get { return this.GroupName; }
            set
            {
                this.GroupName = value;
                try
                {
                    if (GroupChanged != null)
                    {
                        GroupChanged(this, e);
                    }
                }

                catch (Exception ex)
                {

                }
            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(false)]
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
                catch (Exception ex)
                {

                }
            }
        }
         #endregion

        #region Snomed成员

        string snomed = "";
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

    }

    #region 类
    public class ToolStripMonthCalendar : ToolStripControlHost
    {
        public ToolStripMonthCalendar() : base(new MonthCalendar()) { }

        public MonthCalendar MonthCalendarControl
        {
            get
            {
                return Control as MonthCalendar;
            }
        }
        public Day FirstDayOfWeek
        {
            get
            {
                return MonthCalendarControl.FirstDayOfWeek;
            }
            set { value = MonthCalendarControl.FirstDayOfWeek; }
        }

        public void AddBoldedDate(DateTime dateToBold)
        {
            MonthCalendarControl.AddBoldedDate(dateToBold);
        }
        protected override void OnSubscribeControlEvents(Control c)
        {
            base.OnSubscribeControlEvents(c);
            MonthCalendar monthCalendarControl = (MonthCalendar)c;

            monthCalendarControl.DateChanged +=
                new DateRangeEventHandler(OnDateChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            base.OnUnsubscribeControlEvents(c);
            MonthCalendar monthCalendarControl = (MonthCalendar)c;
            monthCalendarControl.DateChanged -=
                new DateRangeEventHandler(OnDateChanged);
        }


        public event DateRangeEventHandler DateChanged;

        private void OnDateChanged(object sender, DateRangeEventArgs e)
        {
            if (DateChanged != null)
            {
                DateChanged(this, e);
            }
        }
    }
    #endregion
}
