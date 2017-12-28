using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.FrameWork.EPRControl
{
    /// <summary>
    /// 电子病历内容容器控件，保存电子病历内容，可以展开，打印
    /// </summary>
    public partial class emrSubPanel : Panel, Neusoft.FrameWork.EPRControl.IControlPrintable, Neusoft.FrameWork.EPRControl.IGroup
    {
        private ContainerPrintType printType;
        private bool isCanInsert;
        private bool isCanDelete;
        private string title;
        private string groupName;
        private bool isShowInTreeView;

        /// <summary>
        /// 是否显示在TreeView上
        /// </summary>
        public bool IsShowInTreeView
        {
            get { return isShowInTreeView; }
            set { isShowInTreeView = value; }
        }
        
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 是否可以添加内容
        /// </summary>
        [Description("是否可以添加内容")]
        public bool IsCanInsert
        {
            get { return isCanInsert; }
            set { isCanInsert = value; }
        }

        /// <summary>
        /// 是否可以删除内容
        /// </summary>
        [Description("是否可以删除内容")]
        public bool IsCanDelete
        {
            get { return isCanDelete; }
            set { isCanDelete = value; }
        }

        /// <summary>
        /// 内容打印格式
        /// </summary>
        [Description("打印格式：连续打印，打印内容不分行，顺序向后扩展。用于多个项目有节点输入，文本格式输出。扩展打印，打印内容分行，每行内容满了之后，顺序向下扩展，下一行另起打印。用于输入多行文本内容。拷贝打印，输入什么格式，就打什么样，用于表格式打印、图片打印格式有特殊要求的打印。")]
        public ContainerPrintType PrintType
        {
            get { return printType; }
            set { printType = value; }
        }

        public emrSubPanel()
        {
            InitializeComponent();
        }

        #region IControlPrintable

        public ArrayList arrSortedControl()
        {
            return null;
        }
        public void continuePrint(PrintPageEventArgs e, Rectangle rectangle, Graphics grap)
        {
        }

        public void Print(PrintPageEventArgs e, Rectangle rectangle, Graphics grap)
        {
        }

        public Control PrintControl()
        {
            return null;
        }

        public void SetText(string fileID)
        { }
        #endregion

        #region IGroup 成员

        public event Neusoft.FrameWork.EPRControl.GroupChangedEventHandler GroupChanged;

        public event Neusoft.FrameWork.EPRControl.IsGroupChangedEventHandler IsGroupChanged;

        public event Neusoft.FrameWork.EPRControl.NameChangedEventHandler NameChanged;

        public string Snomed
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public string 名称
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool 是否组
        {
            get
            {
                return true;
            }
            set
            { 
            }
        }

        public string 组
        {
            get
            {
                return this.groupName;
            }
            set
            {
                this.groupName = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 病历容器控件打印格式
    /// </summary>
    public enum ContainerPrintType
    {
        连续打印 = 0, //打印内容不分行，顺序向后扩展。用于多个项目有节点输入，文本格式输出。
        扩展打印 = 1, //打印内容分行，每行内容满了之后，顺序向下扩展，下一行另起打印。用于输入多行文本内容。
        拷贝打印 = 2    //输入什么格式，就打什么样，用于表格式打印、图片打印格式有特殊要求的打印。
    }

}
