using System;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using FarPoint.Win;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// [功能描述: 表现层函数]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Function
    {
        #region 等待对话框
        private static Neusoft.FrameWork.WinForms.Forms.frmWait frmWaitForm = new Neusoft.FrameWork.WinForms.Forms.frmWait();

        /// <summary>
        /// 当前等待窗口
        /// </summary>
        public static Neusoft.FrameWork.WinForms.Forms.frmWait WaitForm
        {
            get
            {
                return frmWaitForm;
            }
            set
            {
                frmWaitForm = value;
            }
        }

        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="tip"></param>
        public static void ShowWaitForm(string tip, int Progress, bool IsShowCancelButton)
        {
            if (frmWaitForm == null) frmWaitForm = new Neusoft.FrameWork.WinForms.Forms.frmWait();
            if (tip != "") frmWaitForm.Tip = tip;
            if (Progress >= 0) frmWaitForm.Progress = Progress;
            frmWaitForm.IsShowCancelButton = IsShowCancelButton;
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            if (frmWaitForm.Visible == false)
            {
                frmWaitForm.Show();
            }
        }

        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="Progress"></param>
        /// <param name="Max"></param>
        public static void ShowWaitForm(int Progress, int Max)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.WaitForm.progressBar1.Maximum = Max;
            ShowWaitForm("", Progress, false);
        }
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="tip">提示信息</param>
        /// <param name="IsShowCancelButton">是否显示取消按钮</param>
        public static void ShowWaitForm(string tip, bool IsShowCancelButton)
        {
            ShowWaitForm(tip, -1, IsShowCancelButton);
        }
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="Progress">当前进度条进度</param>
        public static void ShowWaitForm(int Progress)
        {
            ShowWaitForm("", Progress, false);
        }
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="tip">当前提示信息</param>
        public static void ShowWaitForm(string tip)
        {
            ShowWaitForm(tip, -1, false);
        }
        /// <summary>
        /// 关闭等待窗口
        /// </summary>
        public static void HideWaitForm()
        {
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            WaitForm.Hide();
        }
        #endregion

        #region 弹出窗口函数
        public static Neusoft.FrameWork.WinForms.Forms.BaseForm PopForm = new Neusoft.FrameWork.WinForms.Forms.BaseForm();
        /// <summary>
        /// 用PopForm窗口显示弹出控件
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <param name="borderStyle">窗口边框类型</param>
        /// <param name="windowState">窗口状态</param>
        /// <returns>System.Windows.Forms.DialogResult</returns>
        public static System.Windows.Forms.DialogResult PopShowControl(Control c, System.Windows.Forms.FormBorderStyle borderStyle, System.Windows.Forms.FormWindowState windowState)
        {
            //创建临时窗口，用来显示控件
            PopForm.StartPosition = FormStartPosition.CenterScreen;
            PopForm.FormBorderStyle = borderStyle;		//窗口边框类型
            PopForm.WindowState = windowState;			//窗口状态
            PopForm.AutoScaleMode = AutoScaleMode.None;
            //创建控件并添加到临时窗口中
            if (c == null) c = new Control();
            PopForm.Width = c.Width + 8;
            PopForm.Height = c.Height + 34;
            c.Dock = DockStyle.Fill;
            PopForm.Controls.Clear();
            PopForm.Visible = false;
            PopForm.Controls.Add(c);
            PopForm.Text = "弹出窗口";//{8004B645-69A3-40a0-9D0B-4C76BB607595}
            //显示临时窗口
            PopForm.ShowDialog();
            try
            {
                c.Dock = DockStyle.None;
            }
            catch { }            
            return PopForm.DialogResult;
        }


        /// <summary>
        /// 用临时创建的窗口显示弹出控件
        /// 默认窗口状态为Normal
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <param name="borderStyle">窗口边框类型</param>
        /// <returns>System.Windows.Forms.DialogResult</returns>
        public static System.Windows.Forms.DialogResult PopShowControl(Control c, System.Windows.Forms.FormBorderStyle borderStyle)
        {
            return PopShowControl(c, borderStyle, System.Windows.Forms.FormWindowState.Normal);	//默认窗口状态为Normal
        }


        /// <summary>
        /// 用临时创建的窗口显示弹出控件
        /// 默认窗口状态为Normal,
        /// 默认窗口边框类型为FixedToolWindow
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <returns>System.Windows.Forms.DialogResult</returns>
        public static System.Windows.Forms.DialogResult PopShowControl(Control c)
        {
            return PopShowControl(c, System.Windows.Forms.FormBorderStyle.FixedToolWindow, System.Windows.Forms.FormWindowState.Normal);	//默认窗口边框类型为FixedToolWindow
        }


        /// <summary>
        /// 用临时创建的窗口显示弹出控件
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <param name="borderStyle">窗口边框类型</param>
        /// <param name="windowState">窗口状态</param>
        public static void ShowControl(Control c, System.Windows.Forms.FormBorderStyle borderStyle, System.Windows.Forms.FormWindowState windowState)
        {
            //创建临时窗口，用来显示控件
            Neusoft.FrameWork.WinForms.Forms.BaseForm frmTemp = new Neusoft.FrameWork.WinForms.Forms.BaseForm();
            frmTemp.StartPosition = FormStartPosition.CenterScreen;	//居中显示
            frmTemp.FormBorderStyle = borderStyle;		//窗口边框类型
            frmTemp.WindowState = windowState;			//窗口状态
            frmTemp.Text = c.Text;						//窗口标题
            frmTemp.AutoScaleMode = AutoScaleMode.None;
            frmTemp.Visible = false;
            //创建控件并添加到临时窗口中
            if (c == null) c = new Control();
            frmTemp.Width = c.Width + 8;
            frmTemp.Height = c.Height + 34;
            c.Dock = DockStyle.Fill;
            frmTemp.Controls.Add(c);
            //显示临时窗口
            frmTemp.ShowDialog();
            try
            {
                c.Dock = DockStyle.None;
            }
            catch { }
        }


        /// <summary>
        /// 用临时创建的窗口显示弹出控件
        /// 默认窗口状态为Normal
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <param name="borderStyle">窗口边框类型</param>
        public static void ShowControl(Control c, System.Windows.Forms.FormBorderStyle borderStyle)
        {
            ShowControl(c, borderStyle, System.Windows.Forms.FormWindowState.Normal);	//默认窗口状态为Normal
        }


        /// <summary>
        /// 用临时创建的窗口显示弹出控件
        /// 默认窗口状态为Normal,
        /// 默认窗口边框类型为FixedToolWindow
        /// </summary>
        /// <param name="c">待显示的控件</param>
        public static void ShowControl(Control c)
        {
            ShowControl(c, System.Windows.Forms.FormBorderStyle.FixedToolWindow, System.Windows.Forms.FormWindowState.Normal);	//默认窗口边框类型为FixedToolWindow
        }


        #endregion

        #region 工具条和菜单帮定
        protected static ToolBar myToolBar;
        /// <summary>
        /// 将菜单与工具栏显示绑定在一起
        /// 根据菜单的名称和ToolButton的Tag相结合
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <param name="toolbar">工具栏</param>
        public static void BindingMenuToToolBar(MainMenu menu, ToolBar toolbar)
        {
            myToolBar = toolbar;
            HideAllButton();
            foreach (MenuItem m in menu.MenuItems)
            {
                if (m.Visible) GetMenu(m);
            }

        }
        /// <summary>
        /// 获得菜单项目
        /// </summary>
        /// <param name="m"></param>
        private static void GetMenu(MenuItem m)
        {
            for (int i = 0; i < m.MenuItems.Count; i++)
            {
                if (m.MenuItems[i].MenuItems.Count > 0 && m.MenuItems[i].Visible) GetMenu(m.MenuItems[i]);
                ShowButton(m.MenuItems[i].Text, m.MenuItems[i].Visible);
            }
        }
        /// <summary>
        /// 隐藏所有工具条按钮
        /// </summary>
        private static void HideAllButton()
        {
            foreach (ToolBarButton b in myToolBar.Buttons)
            {
                b.Visible = false;
            }
        }
        /// <summary>
        /// 显示相同名称的按钮
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="bVisible"></param>
        private static void ShowButton(string menuName, bool bVisible)
        {
            foreach (ToolBarButton b in myToolBar.Buttons)
            {
                try
                {
                    if (b.Tag.ToString() == menuName)
                    {
                        b.Visible = bVisible;
                    }
                }
                catch { }
            }
        }
        #endregion

        #region 获得临时文件

        /// <summary>
        /// 获得一个临时文件名称
        /// 根据当前Tick
        /// </summary>
        /// <returns></returns>
        public static string GetTempFileName()
        {
            string s = DateTime.Now.Ticks.ToString();
            string strLocalPath = Application.StartupPath;
            if (System.IO.Directory.Exists(strLocalPath + "\\tmp\\") == false)
            {
                System.IO.Directory.CreateDirectory(strLocalPath + "\\tmp\\");
            }
            s = strLocalPath + "\\tmp\\" + s;
            return s;
        }

        /// <summary>
        /// 清空临时目录
        /// </summary>
        public static void ClearTempFolder()
        {
            string strLocalPath = Application.StartupPath;
            if (System.IO.Directory.Exists(strLocalPath + "\\tmp\\"))
            {
                System.IO.Directory.Delete(strLocalPath + "\\tmp\\", true);
            }
            System.IO.Directory.CreateDirectory(strLocalPath + "\\tmp\\");

        }
        #endregion

        #region 获得输入法配置

        /// <summary>
        /// 获得默认输入法
        /// combobox用到的
        /// </summary>
        /// <returns></returns>
        public static int GetInputType()
        {
            string strLocalPath = Application.StartupPath;
            string filename = strLocalPath + "\\profile\\inputSetting.xml";
            if (System.IO.File.Exists(filename))//目录存在
            {
                //读取文件
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                try
                {
                    System.IO.StreamReader r = new System.IO.StreamReader(filename);
                    string cleandown = r.ReadToEnd();
                    doc.LoadXml(cleandown);
                    r.Close();
                }
                catch { return 0; }
                //得到节点数值

                try
                {
                    string s;
                    s = doc.SelectSingleNode("/Setting/Input[@id='combobox']").Attributes["value"].Value;
                    int i = int.Parse(s);//转换成数字型
                    return i;
                }
                catch { return 0; }
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region 其他

        /// <summary>
        ///  弹出选择日期窗口，返回起始日期和终止日期
        /// writed by cuipeng 
        /// 2005-4
        /// </summary>
        /// <param name="dateBegin">返回的起始日期</param>
        /// <param name="dateEnd">返回的终止日期</param>
        /// <returns>1选择新日期，0没有选择</returns>
        public static int ChooseDate(ref DateTime dateBegin, ref DateTime dateEnd)
        {
            Neusoft.FrameWork.WinForms.Forms.frmChooseDate form = new Neusoft.FrameWork.WinForms.Forms.frmChooseDate();

            //通知窗口显示起始日期和终止日期
            form.IsOneDate = false;

            //将传入的起始日期付给窗口起始日期的默认值
            if (dateBegin != DateTime.MinValue)
                form.DateBegin = dateBegin;
            //将传入的终止日期付给窗口终止日期的默认值
            if (dateEnd != DateTime.MinValue)
                form.DateEnd = dateEnd;

            System.Windows.Forms.DialogResult Result = form.ShowDialog();
            //取窗口返回的起始日期和终止日期
            if (Result == DialogResult.OK)
            {
                dateBegin = form.DateBegin;
                dateEnd = form.DateEnd;
                //取到新日期，返回1
                return 1;
            }

            //如果没有选择日期，则返回0
            return 0;
        }


        /// <summary>
        ///  弹出选择日期窗口，返回用户选择的日期
        /// writed by cuipeng 
        /// 2005-4
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>1选择新日期，0没有选择</returns>
        public static int ChooseDate(ref DateTime date)
        {
            Neusoft.FrameWork.WinForms.Forms.frmChooseDate form = new Neusoft.FrameWork.WinForms.Forms.frmChooseDate();

            //通知窗口显示一个日期
            form.IsOneDate = true;
            form.Init();
            //将传入的起始日期付给窗口起始日期的默认值
            if (date != DateTime.MinValue)
                form.DateBegin = date;

            System.Windows.Forms.DialogResult Result = form.ShowDialog();
            //取窗口返回的起始日期和终止日期
            if (Result == DialogResult.OK)
            {
                date = form.DateBegin;
                //取到新日期，返回1
                return 1;
            }

            //如果没有选择日期，则返回0
            return 0;
        }


        /// <summary>
        /// frmEasyChoose 的摘要说明。
        /// 快速查询窗口
        /// writed by cuipeng
        /// 2005-3
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public static int ChooseItem(ArrayList arrayList, ref Neusoft.FrameWork.Models.NeuObject neuObject)
        {
            Neusoft.FrameWork.WinForms.Forms.frmEasyChoose form = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(arrayList);

            //调用查询窗口
            System.Windows.Forms.DialogResult Result = form.ShowDialog();
            //取窗口返回的起始日期和终止日期
            if (Result == DialogResult.OK)
            {
                neuObject = form.Object;
                //取到新数据，则返回1
                return 1;
            }

            //如果没有选择数据，则返回0
            return 0;
        }

        public static int ChooseItem(ArrayList arrayList, string[] label, bool[] visible, int[] width, ref Neusoft.FrameWork.Models.NeuObject neuObject)
        {
            Neusoft.FrameWork.WinForms.Forms.frmEasyChoose form = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(arrayList);
            form.SetFormat(label, visible, width);

            //调用查询窗口
            System.Windows.Forms.DialogResult Result = form.ShowDialog();
            //取窗口返回的起始日期和终止日期
            if (Result == DialogResult.OK)
            {
                neuObject = form.Object;
                //取到新数据，则返回1
                return 1;
            }

            //如果没有选择数据，则返回0
            return 0;
        }


        /// <summary>
        /// 根据传入的数组弹出窗口列出项目，让用户选择多个项目
        /// </summary>
        /// <returns></returns>
        public static ArrayList ChooseMultiObject(ArrayList arrayList)
        {
            Neusoft.FrameWork.WinForms.Controls.ucChooseMultiObject uc = new Neusoft.FrameWork.WinForms.Controls.ucChooseMultiObject(arrayList);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            return uc.ArrayObject;
        }
        #endregion

        #region "MessageBox函数 "
        /// <summary>
        /// 封装MessageBox函数 
        /// </summary>
        /// <param name="MsgText">Message内容</param>
        /// <param name="MsgType">三位数字(类似于原pb程序的参数)第一位代表MessageBoxIcon 1开头代表提示2开头代表错误3开头代表警告4开头代表提问5开头代表不带图标
        ///                       后两位为11,21,23,31,32 分别代表MessageButtons  OK,OKCancel,YesNo,RetryCancel,AbortRetryIgnore</param>
        /// <returns></returns>
        public static System.Windows.Forms.DialogResult Msg(string MsgText, int MsgType)
        {
            //返回MessageBox Result
            DialogResult r = new DialogResult();
            MsgText = Neusoft.FrameWork.Management.Language.Msg(MsgText); // by 牛鑫元 2008年9月
            switch (MsgType)
            {
                //提示信息
                case 111:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 121:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
                case 122:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    break;
                case 123:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    break;
                case 131:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    break;
                case 132:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                    break;
                //错误信息
                case 211:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case 221:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    break;
                case 222:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    break;
                case 223:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    break;
                case 231:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
                    break;
                case 232:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("错误"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    break;

                //警告信息
                case 311:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 321:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    break;
                case 322:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    break;
                case 323:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    break;
                case 331:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    break;
                case 332:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("警告"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    break;
                //提问信息
                case 411:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                case 421:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    break;
                case 422:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case 423:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    break;
                case 431:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    break;
                case 432:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                    break;
                //不带图标信息
                case 511:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;
                case 521:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    break;
                case 522:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    break;
                case 523:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.RetryCancel, MessageBoxIcon.None);
                    break;
                case 531:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                    break;
                case 532:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.None);
                    break;
                default:
                    r = System.Windows.Forms.MessageBox.Show(MsgText, Neusoft.FrameWork.Management.Language.Msg(Neusoft.FrameWork.Management.Language.Msg("提示")), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

            }
            return r;
        }


        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void MessageBox(Exception ex)
        {
            Neusoft.FrameWork.WinForms.Forms.frmMessageBox f = new Neusoft.FrameWork.WinForms.Forms.frmMessageBox();
            f.SetMessage(ex.Message, ex.StackTrace);
            f.Text = ex.Source;
            f.ShowDialog();
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="message"></param>
        public static void MessageBox(string message)
        {
            Neusoft.FrameWork.WinForms.Forms.frmMessageBox f = new Neusoft.FrameWork.WinForms.Forms.frmMessageBox();
            f.SetMessage(message, "");
            f.ShowDialog();
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="message">给用户的</param>
        /// <param name="innerMessage">内部的信息</param>
        public static void MessageBox(string message, string innerMessage)
        {
            Neusoft.FrameWork.WinForms.Forms.frmMessageBox f = new Neusoft.FrameWork.WinForms.Forms.frmMessageBox();
            f.SetMessage(message, innerMessage);
            f.ShowDialog();
        }

        /// <summary>
        ///  显示信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerMessage"></param>
        /// <param name="title"></param>
        public static void MessageBox(string message, string innerMessage, string title)
        {
            Neusoft.FrameWork.WinForms.Forms.frmMessageBox f = new Neusoft.FrameWork.WinForms.Forms.frmMessageBox();
            f.SetMessage(message, innerMessage);
            f.Text = title;
            f.ShowDialog();
        }

        /// <summary>
        ///  显示信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerMessage"></param>
        /// <param name="messageBoxIcon"></param>
        public static void MessageBox(string message, string innerMessage, MessageBoxIcon messageBoxIcon)
        {
            Neusoft.FrameWork.WinForms.Forms.frmMessageBox f = new Neusoft.FrameWork.WinForms.Forms.frmMessageBox();
            f.SetMessage(message, innerMessage);
            f.ShowDialog();
        }
        #endregion

        #region 关闭当前窗口函数
        protected static Form _needCloseForm;
        /// <summary>
        /// 2秒后关闭当前窗口
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static int CloseCurrentForm(Form form)
        {
            Timer t = new Timer();
            t.Interval = 2000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
            form.Hide();
            _needCloseForm = form;
            return 0;
        }

        /// <summary>
        /// 2秒后关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void t_Tick(object sender, EventArgs e)
        {
            _needCloseForm.Close();
            ((Timer)sender).Enabled = false;
            try
            {
                ((Timer)sender).Dispose();
            }
            catch { }
        }
        #endregion

        #region "多行文本控件的颜色显示"
        /// <summary>
        ///追加多行文本框字体颜色
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void RichTextBoxAppendText(RichTextBox rtb, string text, System.Drawing.Color color)
        {
            rtb.AppendText(text);
            int index = rtb.Text.LastIndexOf(text);
            if (index != -1)
            {
                rtb.Select(index, text.Length);
                rtb.SelectionColor = color;
            }
        }
        #endregion

        #region 日期验证
        /// <summary>
        /// 匹配形式如:20030718,030718 
        ///范围:1900--2099 
        ///正则表达式
        /// </summary>
        /// <param name="date"></param>
        /// <param name="errorMessage"></param>
        /// <returns>-1 错误 0 正确的信息</returns>
        public static int CheckDate(string date, ref string errorMessage)
        {

            try
            {
                //正则表达式验证
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"((((19){1}|(20){1})d{2})|d{2})[01]{1}d{1}[0-3]{1}d{1}");
                System.Text.RegularExpressions.Match mc = rg.Match(date);
                if (!mc.Success)
                {
                    errorMessage = "请录入有效日期格式!";
                    return -1;
                }
                return 0;
            }
            catch
            {
                errorMessage = "请录入有效日期格式";
                return -1;
            }
        }
        #endregion

        #region 身份证验证


        /// <summary>
        /// 验证身份证有效性
        /// </summary>
        /// <param name="cid">身份证号码</param>
        /// <param name="errorMessage">错误信息，正确的15位补足18位</param>
        /// <returns>-1 错误 0 正确</returns>
        public static int CheckIDInfo(string cid, ref string errorMessage)
        {

            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            string info = cid;
            try
            {

                if (cid.Length == 15)
                {
                    info = TransIDFrom15To18(cid);
                }
                //{5260E3A7-AD1A-44df-8C2B-0352FE4AE343}
                info = info.ToLower();
                //正则表达式验证
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
                System.Text.RegularExpressions.Match mc = rg.Match(info);
                if (!mc.Success)
                {
                    errorMessage = "请录入有效的身份证号!";
                    return -1;
                }

                info = info.ToLower();
                info = info.Replace("x", "a");
                //验证头两位地区
                if (aCity[int.Parse(info.Substring(0, 2))] == null)
                {
                    errorMessage = "身份证中地区非法";
                    return -1;
                }
                //验证生日
                try
                {
                    DateTime.Parse(info.Substring(6, 4) + "-" + info.Substring(10, 2) + "-" + info.Substring(12, 2));
                }
                catch
                {
                    errorMessage = "身份证中生日非法";
                    return -1;
                }
                //加权算法
                for (int i = 17; i >= 0; i--)
                {
                    iSum += (System.Math.Pow(2, i) % 11) * int.Parse(info[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

                }
                if (iSum % 11 != 1)
                {
                    errorMessage = ("请录入有效的身份证号");
                    return -1;
                }
            }
            catch
            {
                errorMessage = "请录入有效的身份证号!";
                return -1;
            }
            if (cid.Length == 15)
            {
                return 0;
            }
            else
            {
                errorMessage = (aCity[int.Parse(info.Substring(0, 2))] + "," + info.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + info.Substring(12, 2) + "," + (int.Parse(info.Substring(16, 1)) % 2 == 1 ? "男" : "女"));
                return 0;
            }


        }

        /// <summary>
        /// 15位省份证号升级为18位
        /// </summary>
        /// <param name="perID"></param>
        public static string TransIDFrom15To18(string perID)
        {

            int iS = 0;

            //加权因子常数 
            int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            //校验码常数 
            string LastCode = "10X98765432";
            //新身份证号 
            string perIDNew = "";

            try
            {
                perIDNew = perID.Substring(0, 6);
                //填在第6位及第7位上填上‘1’，‘9’两个数字 
                perIDNew += "19";

                perIDNew += perID.Substring(6, 9);

                //进行加权求和 
                for (int i = 0; i < 17; i++)
                {
                    iS += int.Parse(perIDNew.Substring(i, 1)) * iW[i];
                }

                //取模运算，得到模值 
                int iY = iS % 11;
                //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。 
                perIDNew += LastCode.Substring(iY, 1);
            }
            catch { return "升位出错!"; }

            return perIDNew;


        }

        #endregion

        #region 保存(读取)程序默认操作设置
        /// <summary>
        /// 默认数值配置文件名称
        /// </summary>
        public static string DefaultValueFilePath = System.Windows.Forms.Application.StartupPath + "\\HISDefaultValue.xml";

        /// <summary>
        /// 保存配置数据信息
        /// 我看代码逻辑有问题，还有document本身是独占文件的，你保存一次了，程序没关，别人无法保存。
        /// </summary>
        /// <param name="GroupID">组ID</param>
        /// <param name="FunctionID">功能ID</param>
        /// <param name="strErr">错误信息</param>
        /// <param name="paramsCollection">参数值</param>
        /// <returns></returns>
        public static int SaveDefaultValue(string GroupID, string FunctionID, out string strErr, params string[] paramsCollection)
        {
            strErr = "";
            XmlDocument doc = new XmlDocument();
            XmlElement rootElement;

            try
            {	// 配置 文件已存在
                if (System.IO.File.Exists(Function.DefaultValueFilePath))
                {
                    if ((System.IO.File.GetAttributes(Function.DefaultValueFilePath) & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        System.IO.File.SetAttributes(Function.DefaultValueFilePath, System.IO.FileAttributes.Normal);
                    }

                    //读取文件
                    using (System.IO.StreamReader rs = new StreamReader(Function.DefaultValueFilePath))
                    {
                        string cleandown = rs.ReadToEnd();
                        doc.LoadXml(cleandown);
                    }

                    rootElement = (System.Xml.XmlElement)doc.SelectSingleNode("/PersonalConfig");
                    if (rootElement == null)
                    {
                        strErr = "XML配置文件格式错误 不存在根节点PersonalConfig";
                        return -1;
                    }

                    System.Xml.XmlElement funElement = (System.Xml.XmlElement)doc.SelectSingleNode(string.Format("/PersonalConfig/Group[@ID='{0}']/Function[@ID='{1}']", GroupID, FunctionID));
                    if (funElement != null)         //功能节点存在
                    {
                        funElement.RemoveAll();
                        funElement.SetAttribute("ID", FunctionID);

                        CreateValueElement(doc, funElement, paramsCollection);
                    }
                    else                            //功能节点不存在 判断是否存在组节点
                    {
                        System.Xml.XmlElement groupElement = (System.Xml.XmlElement)doc.SelectSingleNode(string.Format("/PersonalConfig/Group[@ID='{0}']", GroupID));
                        if (groupElement != null)      //存在组节点 增加功能节点
                        {
                            funElement = CreateFunctionElement(doc, FunctionID, paramsCollection);
                        }
                        else
                        {
                            groupElement = CreateGrouptElement(doc, rootElement, GroupID);

                            funElement = CreateFunctionElement(doc, FunctionID, paramsCollection);
                        }
                        groupElement.AppendChild(funElement);
                    }
                }
                else  //文件不存在
                {
                    //设置根结点
                    Neusoft.FrameWork.Xml.XML xmlManager = new Neusoft.FrameWork.Xml.XML();
                    rootElement = xmlManager.CreateRootElement(doc, "PersonalConfig");

                    System.Xml.XmlElement newGroupElement = CreateGrouptElement(doc, rootElement, GroupID);

                    System.Xml.XmlElement newFunElement = CreateFunctionElement(doc, FunctionID, paramsCollection);

                    newGroupElement.AppendChild(newFunElement);
                }

                doc.Save(Function.DefaultValueFilePath);
                return 1;
            }
            catch (Exception ex)
            {
                strErr = "存储程序默认运行设置发生未预知错误！" + ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 构造功能节点
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="functionID">功能ID</param>
        /// <param name="paramsCollection">参数值</param>
        /// <returns>成功返回功能节点</returns>
        private static System.Xml.XmlElement CreateFunctionElement(System.Xml.XmlDocument doc, string functionID, params string[] paramsCollection)
        {
            System.Xml.XmlElement funElement = doc.CreateElement("Function");

            funElement.SetAttribute("ID", functionID);

            CreateValueElement(doc, funElement, paramsCollection);

            return funElement;
        }

        /// <summary>
        /// 构造值节点
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="funElement">父节点</param>
        /// <param name="paramsCollection">参数值</param>
        /// <returns>成功返回1 </returns>
        private static int CreateValueElement(System.Xml.XmlDocument doc, System.Xml.XmlElement funElement, params string[] paramsCollection)
        {
            for (int index = 0; index < paramsCollection.Length; index++)
            {
                System.Xml.XmlElement valueElement = doc.CreateElement("Value" + (index + 1).ToString());
                valueElement.InnerText = paramsCollection[index];
                funElement.AppendChild(valueElement);
            }

            return 1;
        }

        /// <summary>
        /// 构造组节点
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="rootElement">父节点</param>
        /// <param name="groupID">组ID</param>
        /// <returns>返回组节点</returns>
        private static System.Xml.XmlElement CreateGrouptElement(System.Xml.XmlDocument doc, System.Xml.XmlElement rootElement, string groupID)
        {
            System.Xml.XmlElement groupElement = (System.Xml.XmlElement)doc.CreateElement("Group");

            groupElement.SetAttribute("ID", groupID);

            rootElement.AppendChild(groupElement);

            return groupElement;
        }

        /// <summary>
        /// 保存程序默认操作设置 默认组ID 为"HIS"
        /// </summary>
        /// <param name="FunctionID">功能ID</param>
        /// <param name="strErr">错误信息</param>
        /// <param name="alValues">功能信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public static int SaveDefaultValue(string FunctionID, out string strErr, params string[] alValues)
        {
            return Function.SaveDefaultValue("HIS", FunctionID, out strErr, alValues);
        }

        /// <summary>
        /// 保存程序默认操作设置 默认组ID 为"HIS"
        /// </summary>
        /// <param name="FunctionID">功能ID</param>
        /// <param name="alValues">功能信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public static int SaveDefaultValue(string FunctionID, params string[] alValues)
        {
            string strErr;
            return Function.SaveDefaultValue(FunctionID, out strErr, alValues);
        }

        /// <summary>
        /// 获取程序运行默认配置
        /// </summary>
        /// <param name="GroupID">组编码</param>
        /// <param name="FunctionID">功能编码</param>
        /// <param name="strErr">错误信息</param>
        /// <returns>成功返回string数组 未找到返回空ArrayList 失败返回null</returns>
        public static ArrayList GetDefaultValue(string GroupID, string FunctionID, out string strErr)
        {
            strErr = "";
            ArrayList al = new ArrayList();
            try
            {
                if (System.IO.File.Exists(Function.DefaultValueFilePath))
                {
                    //加载Xml文件
                    XmlDocument doc = new XmlDocument();
                    //读取文件
                    using (System.IO.StreamReader rs = new StreamReader(Function.DefaultValueFilePath))
                    {
                        string cleandown = rs.ReadToEnd();
                        doc.LoadXml(cleandown);
                    }
                    System.Xml.XmlElement funElement = (System.Xml.XmlElement)doc.SelectSingleNode(string.Format("/PersonalConfig/Group[@ID='{0}']/Function[@ID='{1}']", GroupID, FunctionID));
                    if (funElement != null)         //功能节点存在
                    {
                        foreach (System.Xml.XmlNode valueNode in funElement.ChildNodes)
                        {
                            al.Add(valueNode.InnerText);
                        }
                    }
                }
                else
                {
                    strErr = "配置文件不存在 请与管理员联系";
                }
                return al;
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取程序运行默认配置 默认组编码为"HIS"
        /// </summary>
        /// <param name="FunctionID">功能编码</param>
        /// <param name="strErr">错误信息</param>
        /// <returns>成功返回string数组 未找到返回空ArrayList 失败返回null</returns>
        public static ArrayList GetDefaultValue(string FunctionID, out string strErr)
        {
            return Function.GetDefaultValue("HIS", FunctionID, out strErr);
        }

        /// <summary>
        /// 获取程序运行默认配置 默认组编码为"HIS"
        /// </summary>
        /// <param name="FunctionID">功能编码</param>
        /// <returns>成功返回string数组 未找到返回空ArrayList 失败返回null</returns>
        public static ArrayList GetDefaultValue(string FunctionID)
        {
            string strErr;
            return Function.GetDefaultValue("HIS", FunctionID, out strErr);
        }
        #endregion

        #region 深度优先查找指定的节点
        public int LaserNode = 0;
        public int CurrentNode = 0;

        /// <summary>
        /// 按深度优先查找指定的节点，找到即退出，即只找最先找到的一个节点。
        /// </summary>
        /// <param name="treeNodes">结点集合</param>
        /// <param name="searchText">查找的文本</param>
        /// <param name="byValueOrText">是否查找tag，true tag查找,false text查找</param>
        /// <param name="isExact">是否精确查找</param>
        /// <param name="isSuper">是否区分大小写，true 区分，false不区分</param>
        /// <returns></returns>
        public TreeNode FindTreeNodeByDepth(TreeNodeCollection treeNodes, string searchText, bool byValueOrText, bool isExact, bool isSuper)
        {
            TreeNode treeNodeReturn = null;
            #region 实现，按深度优先查找，找到即退出...

            string strNodeTag = "";
            string strNodeText = "";

            foreach (TreeNode node in treeNodes)
            {
                //取当前节点键值
                GetTreeNodeValueText(node, ref strNodeTag, ref strNodeText);

                if (byValueOrText)
                {
                    #region 比较tag的值
                    if (isExact) //精确查找 
                    {
                        if (!isSuper) //不区分大小写
                        {
                            strNodeTag = strNodeTag.ToUpper();
                            searchText = searchText.ToUpper();
                        }
                        if (strNodeTag == searchText)
                        {
                            if (LaserNode <= CurrentNode)
                            {
                                treeNodeReturn = node;
                            }
                        }
                    }
                    else //模糊查找 
                    {
                        if (!isSuper) //不区分大小写
                        {
                            strNodeTag = strNodeTag.ToUpper();
                            searchText = searchText.ToUpper();
                        }
                        if (strNodeTag.IndexOf(searchText) >= 0)
                        {
                            if (LaserNode <= CurrentNode)
                            {
                                treeNodeReturn = node;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 比较text的值
                    if (isExact) //精确查找 
                    {
                        if (!isSuper) //不区分大小写
                        {
                            strNodeText = strNodeText.ToUpper();
                            searchText = searchText.ToUpper();
                        }
                        if (strNodeText == searchText)
                        {
                            if (LaserNode <= CurrentNode)
                            {
                                treeNodeReturn = node;
                            }
                        }
                    }
                    else
                    {
                        if (!isSuper) //不区分大小写
                        {
                            strNodeText = strNodeText.ToUpper();
                            searchText = searchText.ToUpper();
                        }
                        if (strNodeText.IndexOf(searchText) >= 0)
                        {
                            if (LaserNode <= CurrentNode)
                            {
                                treeNodeReturn = node;
                            }
                        }
                    }
                    #endregion
                }
                CurrentNode++;

                //找到即退出
                if (treeNodeReturn != null)
                {
                    break;
                }
                else
                {
                    //深度优先查询
                    if (node.Nodes.Count > 0)
                    {
                        treeNodeReturn = FindTreeNodeByDepth(node.Nodes, searchText, byValueOrText, isExact, isSuper);
                    }
                }

            }

            #endregion
            return treeNodeReturn;
        }

        /// <summary>
        /// 取值 
        /// </summary>
        /// <param name="p_treeNode"></param>
        /// <param name="p_value"></param>
        /// <param name="p_text"></param>
        private void GetTreeNodeValueText(TreeNode p_treeNode, ref string p_value, ref string p_text)
        {
            if (p_treeNode.Tag != null)
            {
                //取键值
                p_value = p_treeNode.Tag.ToString();
            }
            else
            {
                p_value = "";
            }
            //取名称 
            p_text = p_treeNode.Text;
        }
        #endregion

        #region 添加控件到Panel
        /// <summary>
        /// 添加用户控件到指定容器控件里
        /// </summary>
        /// <param name="alValues">控件需要负给的参数组</param>
        /// <param name="sender">控件类型</param>
        /// <param name="Container">容器控件</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="style">类型0 不分页 1 分页 </param>
        public static void AddControlToPanel(ArrayList alValues, Control sender, Control Container, Size PageSize, int style)
        {
            //{822BAB77-BCB4-4363-BF79-F9E7551D8DE4}
            //更改原参数类型 Type sender 为 Control sender
            IControlPrintable ic = null;
            try
            {
                ic = (IControlPrintable)sender;
            }
            catch { System.Windows.Forms.MessageBox.Show(sender.Name + "不具备打印接口，不能加载!"); return; }

            Container.Controls.Clear();

            if (alValues.Count <= 0) return;

            Point intControlOffset = new Point(ic.BeginHorizontalBlankWidth, ic.BeginVerticalBlankHeight);

            if (ic.HorizontalNum == 0)
            {
                ic.HorizontalNum = PageSize.Width / ic.ControlSize.Width;
            }
            if (ic.VerticalNum == 0)
            {
                if (style == 0)
                    ic.VerticalNum = alValues.Count;//单条打印（中山一使用）
                else
                    ic.VerticalNum = PageSize.Height / ic.ControlSize.Height;//打印纸张（普通）
            }

            //添加控件
            int i = 0;
            for (int page = 0; page <= alValues.Count / (ic.VerticalNum * ic.HorizontalNum); page++)
            {
                for (int v = 0; v < ic.VerticalNum; v++)
                {
                    intControlOffset.Y = page * PageSize.Height + ic.BeginVerticalBlankHeight + v * ic.ControlSize.Height + v * ic.VerticalBlankHeight;

                    for (int h = 0; h < ic.HorizontalNum; h++)
                    {
                        string name = "control" + i.ToString();
                        intControlOffset.X = ic.BeginHorizontalBlankWidth + h * ic.ControlSize.Width + h * ic.HorizontalBlankWidth;

                        //{822BAB77-BCB4-4363-BF79-F9E7551D8DE4}
                        //更改CreateComponent(sender,name) 为 CreateComponent(sender.GetType(),name)
                        Control c = (Control)Function.CreateComponent(sender.GetType(), name);
                        if (c == null)
                        {
                            System.Windows.Forms.MessageBox.Show("无法生成控件！" + sender.GetType().ToString());
                            return;
                        }
                        c.Size = ic.ControlSize;
                        c.Location = new Point(intControlOffset.X, intControlOffset.Y);

                        c.Visible = true;
                        ((IControlPrintable)c).ControlValue = alValues[i];
                        Container.Controls.Add(c);
                        i++;
                        if (i >= alValues.Count) return;
                    }
                }
            }
        }

        /// <summary>
        /// 添加用户控件到指定容器控件里
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="sender"></param>
        /// <param name="Container"></param>
        /// <param name="PageSize"></param>
        public static void AddControlToPanel(ArrayList alValues, Type sender, Control Container, Size PageSize)
        {
            #region 控件
            IControlPrintable ic = null;
            try
            {
                ic = (IControlPrintable)Function.CreateComponent(sender, "mytest");
            }
            catch { System.Windows.Forms.MessageBox.Show(sender.Name + "不具备打印接口，不能加载!"); return; }

            Container.Controls.Clear();

            if (alValues.Count <= 0) return;

            Point intControlOffset = new Point(ic.BeginHorizontalBlankWidth, ic.BeginVerticalBlankHeight);

            //添加控件
            int i = 0;
            int page = 0;
            int MaxHeight = 0;
            int MaxWidth = 0;
            Control c;

            while (true)//分页，for(int page = 0;page <= alValues.Count/(ic.VerticalNum * ic.HorizontalNum);page++)
            {
                while (true)//for(int v=0;v<ic.VerticalNum;v++)//数
                {
                    while (true)//横for(int h =0;h<ic.HorizontalNum;h++)
                    {
                        string name = "control" + i.ToString();

                        c = (Control)Function.CreateComponent(sender, name);
                        if (c == null)
                        {
                            System.Windows.Forms.MessageBox.Show("无法生成控件！" + sender.GetType().ToString());
                            return;
                        }

                        c.Visible = true;
                        ((IControlPrintable)c).ControlValue = alValues[i];
                        c.Size = ((IControlPrintable)c).ControlSize;
                        Container.Controls.Add(c);

                        //intControlOffset.X = ic.BeginHorizontalBlankWidth  + h*ic.ControlSize.Width  +h*ic.HorizontalBlankWidth ;


                        if (c.Height > MaxHeight) MaxHeight = c.Height;

                        if (i == 0)//第一个
                        {
                            intControlOffset.X = ic.BeginHorizontalBlankWidth;
                            intControlOffset.Y = ic.BeginVerticalBlankHeight;
                            MaxWidth = c.Width;
                            c.Location = new Point(intControlOffset.X, intControlOffset.Y);
                        }
                        else
                        {
                            if (intControlOffset.X + MaxWidth/*前一个宽度*/+ c.Width/*当前的宽度*/ > PageSize.Width)
                            {
                                intControlOffset.X = ic.BeginHorizontalBlankWidth;
                                i++;
                                break;
                            }
                            intControlOffset.X += MaxWidth/*前一个宽度*/+ ic.HorizontalBlankWidth;
                            MaxWidth = c.Width;
                            c.Location = new Point(intControlOffset.X, intControlOffset.Y);
                        }
                        i++;
                        if (i >= alValues.Count) return;

                    }
                    //intControlOffset.Y =page*PageSize.Height + ic.BeginVerticalBlankHeight + v*ic.ControlSize.Height +v*ic.VerticalBlankHeight;
                    if (intControlOffset.Y + MaxHeight/*前一页最大高度*/+ c.Height/*当前高度*/> (page + 1) * PageSize.Height)
                    {
                        page++;
                        intControlOffset.Y = ic.BeginVerticalBlankHeight + page * PageSize.Height;
                    }
                    else
                    {
                        intControlOffset.Y += c.Height + ic.VerticalBlankHeight;
                    }
                    MaxWidth = c.Width;
                    c.Location = new Point(intControlOffset.X, intControlOffset.Y);
                    MaxHeight = 0;
                    if (i >= alValues.Count) return;
                }
            }
            #endregion
        }

        //
        //		/// <summary>
        //		/// 添加控件到panel,根据控件的返回值，判断是否添加该控件
        //		/// </summary>
        //		/// <param name="alValues"></param>
        //		/// <param name="sender"></param>
        //		/// <param name="Container"></param>
        //		/// <param name="PageSize"></param>
        //		public static void AddControlToPanelIfNeed(ArrayList alValues,Control sender,Control Container,Size PageSize)
        //		{
        //			
        //			IControlPrintable ic = null;
        //			try
        //			{
        //				ic = (IControlPrintable)sender;
        //			}
        //			catch{System.Windows.Forms.MessageBox.Show(sender.Name +"不具备打印接口，不能加载!"); return;}
        //			
        //			Container.Controls.Clear();
        //
        //			if( alValues.Count<=0 ) return;
        //
        //			Point intControlOffset = new Point(ic.BeginHorizontalBlankWidth,ic.BeginVerticalBlankHeight);
        //			
        //
        //			//添加控件
        //			int i = 0;
        //			int page = 0;
        //			int MaxHeight = 0;
        //			int MaxWidth = 0;
        //			Control c;
        //			
        //			while(true)//分页，for(int page = 0;page <= alValues.Count/(ic.VerticalNum * ic.HorizontalNum);page++)
        //			{
        //				while(true)//for(int v=0;v<ic.VerticalNum;v++)//数
        //				{
        //					while(true)//横for(int h =0;h<ic.HorizontalNum;h++)
        //					{
        //						string name ="control"+ i.ToString();
        //						
        //						c = (Control)Function.CreateComponent(sender.GetType(),name);						
        //						if(c == null) 
        //						{
        //							System.Windows.Forms.MessageBox.Show("无法生成控件！"+sender.GetType().ToString());
        //							return;
        //						}
        //					
        //						c.Visible = true;
        //						((IControlPrintable)c).ControlValue = alValues[i];
        //						if(((IControlPrintable)c).ControlValue==null||((IControlPrintable)c).ControlValue.ToString()=="0")
        //						{						
        //							c.Size = ((IControlPrintable)c).ControlSize;
        //							Container.Controls.Add(c);
        //						 
        //							//intControlOffset.X = ic.BeginHorizontalBlankWidth  + h*ic.ControlSize.Width  +h*ic.HorizontalBlankWidth ;
        //						
        //						
        //							if(c.Height>MaxHeight) MaxHeight =c.Height;
        //
        //							if(i==0)//第一个
        //							{
        //								intControlOffset.X = ic.BeginHorizontalBlankWidth;
        //								intControlOffset.Y = ic.BeginVerticalBlankHeight;
        //								MaxWidth = c.Width;
        //								c.Location = new Point(intControlOffset.X,intControlOffset.Y);
        //							}
        //							else
        //							{
        //								if(intControlOffset.X + MaxWidth/*前一个宽度*/+c.Width/*当前的宽度*/ > PageSize.Width) 
        //								{
        //									intControlOffset.X = ic.BeginHorizontalBlankWidth;
        //									i++;
        //									break;
        //								}
        //								intControlOffset.X += MaxWidth/*前一个宽度*/+ic.HorizontalBlankWidth;
        //								MaxWidth = c.Width;
        //								c.Location = new Point(intControlOffset.X,intControlOffset.Y);
        //							}
        //						}
        //
        //						i++;
        //						if(i>= alValues.Count) return;
        //				
        //					}
        //					//intControlOffset.Y =page*PageSize.Height + ic.BeginVerticalBlankHeight + v*ic.ControlSize.Height +v*ic.VerticalBlankHeight;
        //					if(intControlOffset.Y + MaxHeight/*前一页最大高度*/+c.Height/*当前高度*/>(page+1)*PageSize.Height) 
        //					{
        //						page++;
        //						intControlOffset.Y = ic.BeginVerticalBlankHeight+page*PageSize.Height;
        //					}
        //					else
        //					{
        //						intControlOffset.Y += c.Height + ic.VerticalBlankHeight ;
        //					}
        //					MaxWidth = c.Width;
        //					c.Location = new Point(intControlOffset.X,intControlOffset.Y);
        //					MaxHeight =0;
        //					if(i>= alValues.Count) return;
        //				}
        //			}
        //		}
        //		

        /// <summary>
        /// 根据类型，反射建立组件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static object CreateComponent(System.Type type, string Name)
        {
            try
            {
                System.Object c = System.Activator.CreateInstance(type, true);
                try
                {
                    ((Control)c).Name = Name;
                }
                catch
                {
                }
                return c;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Control CreateControl(string dllName, string Name)
        {
            if (dllName.Trim() == "") return null;
            System.Runtime.Remoting.ObjectHandle s;
            string objectNameSpace = dllName;
            string objectName = Name;
            string name = objectName.Substring(objectName.LastIndexOf(".") + 1);
            Control control = null;
            try
            {
                s = System.Activator.CreateInstance(objectNameSpace, objectName, true, System.Reflection.BindingFlags.CreateInstance, null, null, null, null, null);
                control = (Control)s.Unwrap();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

            return control;
        }

        /// <summary>
        /// 设置属性给控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertys"></param>
        public static void SetPropertyToControl(Control control, ArrayList propertys)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in propertys)
            {
                if (obj.ID == "")
                {
                }
                else
                {
                    PropertyDescriptor prop = TypeDescriptor.GetProperties(control)[obj.ID];
                    if (prop != null)
                    {
                        bool isContent = prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content);
                        object value = prop.GetValue(control);
                        if (isContent)
                        {

                        }
                        else
                        {
                            try
                            {
                                if (prop.PropertyType.ToString() == "System.Drawing.Color")
                                {
                                    obj.Name = obj.Name.Replace("Color [", "");
                                    obj.Name = obj.Name.Substring(0, obj.Name.Length - 1);

                                    if (obj.Name.IndexOf("R") >= 0 && obj.Name.IndexOf("G") >= 0 && obj.Name.IndexOf("B") >= 0)
                                    {

                                    }
                                    else
                                    {
                                        value = Color.FromName(obj.Name);
                                    }
                                }
                                else
                                {
                                    value = prop.Converter.ConvertFromInvariantString(obj.Name);
                                }
                            }
                            catch
                            { }
                            prop.SetValue(control, value);

                        }
                    }
                }
            }
        }


        #endregion

        #region Ini配置文件
        [DllImport("kernel32")]
        /*
            * SegName   为键名 
            * KeyName   为变量名
            * Value     为变量的值
            * FileName  为文件名称
            * 格式存为： [SegName] 
            *            KeyName = Value
            * */
        private static extern bool WritePrivateProfileString(string SegName, string KeyName, string Value, string FileName);
        /*
          * SegName  为键名 
         * KeyName   为变量名
         * Default   为取不到时的默认值
         * StrReturn 为返回值
         * Size      为目的缓存器的大小
         * FileName  为文件名
         * */
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string SegName, string KeyName, string Default, System.Text.StringBuilder StrReturn, int Size, string FileName);
        [DllImport("kernel32")]
        /*
         * SegName    为键名 
         * KeyName    为变量名
         * Default    为默认值
         * FileName   为文件名
         * */
        private static extern int GetPrivateProfileInt(string SegName, string KeyName, int Default, string FileName);
        /// <summary>
        /// 文件路径
        /// </summary>
        public static string FileName = Application.StartupPath + "\\HISSETTING.INI";
        /// <summary>
        /// 获得String类型参数值(带文件路径)
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string ReadPrivateProfile(string SegName, string KeyName, string FileName)
        {
            System.Text.StringBuilder name = new System.Text.StringBuilder(1000);
            try
            {
                GetPrivateProfileString(SegName, KeyName, "", name, 1000, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("获得配置文件信息出错，请察看该文件是否存在！");
                return "";
            }
            return name.ToString();
        }
        /// <summary>
        /// 获得String类型参数值
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public static string ReadPrivateProfile(string SegName, string KeyName)
        {
            System.Text.StringBuilder name = new System.Text.StringBuilder(1000);

            try
            {
                GetPrivateProfileString(SegName, KeyName, "", name, 1000, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("获得配置文件信息出错，请察看该文件是否存在！");
                return "";
            }
            return name.ToString();
        }
        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <param name="Value"></param>
        public static void WritePrivateProfile(string SegName, string KeyName, string Value)
        {
            if (System.IO.File.Exists(FileName) == false)
            {
                {
                    System.IO.File.Create(FileName);
                }
            }
            try
            {
                WritePrivateProfileString(SegName, KeyName, Value, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("设置参数值出错，请察看该文件是否存在！");
                return;
            }

            //this.ShowErr("设置参数值成功！");
        }
        /// <summary>
        ///  重载设置参数值(带文件路径)
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <param name="Value"></param>
        /// <param name="FileName"></param>
        public static void WritePrivateProfile(string SegName, string KeyName, string Value, string FileName)
        {
            if (!System.IO.File.Exists(FileName))
            {
                //不存在的话，创建文件
                System.IO.File.Create(FileName);
            }
            try
            {
                WritePrivateProfileString(SegName, KeyName, Value, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("设置参数值出错，请察看该文件是否存在！");
                return;
            }

            //this.ShowErr("设置参数值成功！");
        }
        /// <summary>
        /// 获得INT型参数值
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public static int WritePrivateProfileIntType(string SegName, string KeyName)
        {
            int Value;
            try
            {
                Value = GetPrivateProfileInt(SegName, KeyName, 0, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("获得配置文件信息出错，请察看该文件是否存在！");
                return 0;
            }
            return Value;
        }
        /// <summary>
        /// 重载获得INT型参数值(带有文件路径)
        /// </summary>
        /// <param name="SegName"></param>
        /// <param name="KeyName"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static int WritePrivateProfileIntType(string SegName, string KeyName, string FileName)
        {
            int Value;
            try
            {
                Value = GetPrivateProfileInt(SegName, KeyName, 0, FileName);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("获得配置文件信息出错，请察看该文件是否存在！");
                return 0;
            }
            return Value;
        }
        #endregion

        #region 显示ToolTip
        /// <summary>
        /// 显示tooltip
        /// </summary>
        /// <param name="text"></param>
        /// <param name="time"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        /// <param name="opacity"></param>
        public static void ShowToolTip(string text, int time, Color foreColor, Color backColor, double opacity)
        {
            Neusoft.FrameWork.WinForms.Forms.frmTip f = new Neusoft.FrameWork.WinForms.Forms.frmTip();
            f.TipText = text;
            f.TopMost = true;
            f.ShowInTaskbar = false;
            f.Show();
            f.Run(time, foreColor, backColor, opacity);
        }
        /// <summary>
        /// 显示tooltip
        /// </summary>
        /// <param name="text"></param>
        /// <param name="time"></param>
        public static void ShowToolTip(string text, int time)
        {
            ShowToolTip(text, time, Color.Blue, Color.Yellow, 0.8);

        }

        /// <summary>
        /// 显示tooltip
        /// </summary>
        /// <param name="text"></param>
        public static void ShowToolTip(string text)
        {
            ShowToolTip(text, 5);
        }

        #endregion

        #region 常数
        /// <summary>
        /// 当前路径
        /// </summary>
        public static string CurrentPath = "";

        /// <summary>
        /// 插件根目录
        /// </summary>
        public static string PluginPath = "Plugins\\";

        /// <summary>
        /// 个人设置目录
        /// </summary>
        public static string SettingPath = "Profile\\";
        /// <summary>
        /// 临时目录
        /// </summary>
        public static string TempPath = "Tmp\\";

        /// <summary>
        /// 多语言目录
        /// </summary>
        public static string LanguagePath = "Languages\\";

        /// <summary>
        /// 多语言文件
        /// </summary>
        public static string LanguageFileName = "Language.xml";

        #endregion

        #region ImageList
        /// <summary>
        /// 
        /// </summary>
        public static Image GetImage(EnumImageList imageList)
        {

            if (imageList == EnumImageList.F分票)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.分单;
            if (imageList == EnumImageList.B摆药单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.摆药单;
            if (imageList == EnumImageList.B摆药台)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.摆药台;
            if (imageList == EnumImageList.P盘点结存解封)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.解封;
            if (imageList == EnumImageList.T体检报告)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.体检报告;
            if (imageList == EnumImageList.T体检登记)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.体检登记;
            if (imageList == EnumImageList.PR菜单上)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.主菜单节点_打开16;
            if (imageList == EnumImageList.PR菜单下)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.主菜单节点_关闭16;
            if (imageList == EnumImageList.D导入)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.导入;
            if (imageList == EnumImageList.D导出)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.导出;

            if (imageList == EnumImageList.B帮助)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.帮助;
            }
            if (imageList == EnumImageList.B保存)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.保存;
            }
            if (imageList == EnumImageList.C查询)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.查询;
            }
            if (imageList == EnumImageList.C查找)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.查找;
            }
            if (imageList == EnumImageList.D打印)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印;
            }
            if (imageList == EnumImageList.D打印预览)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印预览;
            }
            if (imageList == EnumImageList.F复制)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.Copy;
            }
            if (imageList == EnumImageList.G顾客)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.患者;
            }
            if (imageList == EnumImageList.L浏览)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.浏览;
            }
            if (imageList == EnumImageList.M默认)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.默认;
            }
            if (imageList == EnumImageList.Q清空)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.清空;
            }
            if (imageList == EnumImageList.Q取消)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.取消;
            }
            if (imageList == EnumImageList.Q全选)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.全选;
            }
            if (imageList == EnumImageList.Q权限)
            {
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.权限;
            }
            if (imageList == EnumImageList.R人员)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.患者;
            if (imageList == EnumImageList.R人员组)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人员组;
            if (imageList == EnumImageList.S删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.删除;
            if (imageList == EnumImageList.S上一个)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.上一个;
            if (imageList == EnumImageList.S设置)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.设置;
            if (imageList == EnumImageList.S刷新)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.刷新;
            if (imageList == EnumImageList.T添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.增加;
            if (imageList == EnumImageList.T退出)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.退出;
            if (imageList == EnumImageList.X下一个)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.下一个;
            if (imageList == EnumImageList.X新建)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.新建;
            if (imageList == EnumImageList.X信息)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.信息;
            if (imageList == EnumImageList.X修改)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.修改;
            if (imageList == EnumImageList.Y预览)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印预览;
            if (imageList == EnumImageList.Z暂存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.暂存;
            if (imageList == EnumImageList.Z注销)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.注销;
            if (imageList == EnumImageList.Z组套)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.组套;
            if (imageList == EnumImageList.Z作废信息)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.信息作废;
            if (imageList == EnumImageList.J借出)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.借出;
            if (imageList == EnumImageList.J借入)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.借入;
            if (imageList == EnumImageList.B病历)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.病历;
            if (imageList == EnumImageList.C查询历史)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.查询历史;
            if (imageList == EnumImageList.H合并)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.合并;
            if (imageList == EnumImageList.H化验)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.化验;
            if (imageList == EnumImageList.Y医嘱)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.医嘱;
            if (imageList == EnumImageList.Z诊断)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.诊断;
            if (imageList == EnumImageList.F封帐)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.封存;
            if (imageList == EnumImageList.H划价保存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.划价保存;
            if (imageList == EnumImageList.H换单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.换单;
            if (imageList == EnumImageList.K开帐)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.解封;
            if (imageList == EnumImageList.L临时号)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.临时号;
            if (imageList == EnumImageList.M明细)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.明细;
            if (imageList == EnumImageList.Q全退)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.全退;
            if (imageList == EnumImageList.Q确认收费)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.收费确认;
            if (imageList == EnumImageList.R日消耗)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.日消耗;
            if (imageList == EnumImageList.S生育保险)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.生育保险;
            if (imageList == EnumImageList.S收费项目)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.收费项目;
            if (imageList == EnumImageList.S手动录入)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.手工录入;
            if (imageList == EnumImageList.Y医保)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.医保;
            if (imageList == EnumImageList.Z执行)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.确认;
            if (imageList == EnumImageList.C重打)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.补打印;
            if (imageList == EnumImageList.Z自动录入)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.自动录入;
            if (imageList == EnumImageList.B报警)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.报警;
            if (imageList == EnumImageList.C出院登记)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.删除人员;
            if (imageList == EnumImageList.C床位维护)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.病床;
            if (imageList == EnumImageList.D打印输液卡)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印输液卡;
            if (imageList == EnumImageList.D打印执行单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印执行单;
            if (imageList == EnumImageList.F分解)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.分解;
            if (imageList == EnumImageList.H护理)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.护士;
            if (imageList == EnumImageList.H换医师)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.换医生;
            if (imageList == EnumImageList.J接诊)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.添加人员;
            if (imageList == EnumImageList.T体温)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.体温;
            if (imageList == EnumImageList.Y医嘱审核)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.审核;
            if (imageList == EnumImageList.Y婴儿登记)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.婴儿登记;
            if (imageList == EnumImageList.Z召回)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.召回;
            if (imageList == EnumImageList.Z转科)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.转科;
            if (imageList == EnumImageList.Z转科确认)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.转科确认;
            if (imageList == EnumImageList.A安排)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.安排;
            if (imageList == EnumImageList.Y药品)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.药品;
            if (imageList == EnumImageList.Y预约)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.预约;
            if (imageList == EnumImageList.F房间)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.房间;
            if (imageList == EnumImageList.J集体)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.集合;
            if (imageList == EnumImageList.J健康档案)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.健康档案;
            if (imageList == EnumImageList.K科室)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.科室;
            if (imageList == EnumImageList.L历史信息)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.历史记录;
            if (imageList == EnumImageList.L楼层)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.楼层;
            if (imageList == EnumImageList.L楼房)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.楼房;
            if (imageList == EnumImageList.S设备)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.设备;
            if (imageList == EnumImageList.C采购单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.采购单;
            if (imageList == EnumImageList.C出库单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.出库单;
            if (imageList == EnumImageList.R入库单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.入库单;
            if (imageList == EnumImageList.S申请单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.申请单;

            //后补充的
            if (imageList == EnumImageList.B病历本费)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.病历本费;
            if (imageList == EnumImageList.C菜单删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.菜单删除;
            if (imageList == EnumImageList.C菜单添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.菜单添加;
            if (imageList == EnumImageList.C草药)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.草药;
            if (imageList == EnumImageList.C查找人员)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.查找人员;
            if (imageList == EnumImageList.C拆包)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.拆包;
            if (imageList == EnumImageList.C窗口)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.窗口;
            if (imageList == EnumImageList.C窗口添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.窗口添加;
            if (imageList == EnumImageList.C窗口删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.窗口删除;
            if (imageList == EnumImageList.C错误单据)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.错误单据;
            if (imageList == EnumImageList.D打包)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打包;
            if (imageList == EnumImageList.D打印清单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.打印清单;
            if (imageList == EnumImageList.F分类删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.分类删除;
            if (imageList == EnumImageList.F分类添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.分类添加;
            if (imageList == EnumImageList.G过滤删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.过滤删除;
            if (imageList == EnumImageList.G过滤添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.过滤添加;
            if (imageList == EnumImageList.H合并取消)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.合并取消;
            if (imageList == EnumImageList.J计划单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.计划单;
            if (imageList == EnumImageList.J计算器)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.计算器;
            if (imageList == EnumImageList.J角色删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.角色删除;
            if (imageList == EnumImageList.J角色添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.角色添加;
            if (imageList == EnumImageList.K科室删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.科室删除;
            if (imageList == EnumImageList.K科室添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.科室添加;
            if (imageList == EnumImageList.K科室修改)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.科室修改;
            if (imageList == EnumImageList.L累计开始)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.累计开始;
            if (imageList == EnumImageList.L累计取消)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.累计取消;
            if (imageList == EnumImageList.L累计停止)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.累计停止;
            if (imageList == EnumImageList.L另存为)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.另存为;
            if (imageList == EnumImageList.M明细删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.明细删除;
            if (imageList == EnumImageList.M明细添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.明细添加;
            if (imageList == EnumImageList.M模版)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.模版;
            if (imageList == EnumImageList.M模版删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.模版删除;
            if (imageList == EnumImageList.M模版添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.模版添加;
            if (imageList == EnumImageList.P排序)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.排序;
            if (imageList == EnumImageList.P盘点附加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.盘点附加;
            if (imageList == EnumImageList.P盘点)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.盘点;
            if (imageList == EnumImageList.P盘点开始)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.盘点开始;
            if (imageList == EnumImageList.P盘点取消)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.盘点取消;
            if (imageList == EnumImageList.P盘点停止)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.盘点停止;
            if (imageList == EnumImageList.P批量封存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.批量封存;
            if (imageList == EnumImageList.P批量复制)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.批量复制;
            if (imageList == EnumImageList.Q全不选)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.全不选;
            if (imageList == EnumImageList.Q全选取消)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.全选取消;
            if (imageList == EnumImageList.Q权限删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.权限删除;
            if (imageList == EnumImageList.Q权限添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.权限添加;
            if (imageList == EnumImageList.R人员修改)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人员修改;
            if (imageList == EnumImageList.R日期)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.日期;
            if (imageList == EnumImageList.S上级科室)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.上级科室;
            if (imageList == EnumImageList.S设备删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.设备删除;
            if (imageList == EnumImageList.S设备添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.设备添加;
            if (imageList == EnumImageList.T跳转)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.跳转;
            if (imageList == EnumImageList.T停诊)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.停诊;
            if (imageList == EnumImageList.W完成的)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.完成的;
            if (imageList == EnumImageList.W未结存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.未结存;
            if (imageList == EnumImageList.W未完成的)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.未完成的;
            if (imageList == EnumImageList.Y一般单据)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.一般单据;
            if (imageList == EnumImageList.Y一条记录删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.一条记录删除;
            if (imageList == EnumImageList.Y一条记录添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.一条记录添加;
            if (imageList == EnumImageList.Y医嘱退出)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.医嘱退出;
            if (imageList == EnumImageList.Y已结存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.已结存;
            if (imageList == EnumImageList.Z增量保存)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.增量保存;
            if (imageList == EnumImageList.Z诊出)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.诊出;
            if (imageList == EnumImageList.Z纸单)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.纸单;
            if (imageList == EnumImageList.Z子级)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.子级;
            if (imageList == EnumImageList.Z组套删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.组套删除;
            if (imageList == EnumImageList.Z组套添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.组套添加;
            if (imageList == EnumImageList.Z作废)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.作废;
            if (imageList == EnumImageList.G过滤)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.过滤;
            if (imageList == EnumImageList.B病历删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.病历删除;
            if (imageList == EnumImageList.B病历添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.病历添加;
            if (imageList == EnumImageList.F返回)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.返回;
            if (imageList == EnumImageList.B摆药台删除)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.摆药台删除;
            if (imageList == EnumImageList.B摆药台添加)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.摆药台添加;
            if (imageList == EnumImageList.M模版执行)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.模版执行;
            if (imageList == EnumImageList.L列表)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.列表;

            if (imageList == EnumImageList.W文字_字体)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.文字_字体;
            if (imageList == EnumImageList.W文字_下标)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.文字_下标;
            if (imageList == EnumImageList.W文字_上标)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.文字_上标;
            if (imageList == EnumImageList.R人物_婴儿_女)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_婴儿_女;
            if (imageList == EnumImageList.R人物_婴儿_男)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_婴儿_男;
            if (imageList == EnumImageList.R人物_老人_女)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_老人_女;
            if (imageList == EnumImageList.R人物_老人_男)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_老人_男;
            if (imageList == EnumImageList.R人物_儿童_女)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_儿童_女;
            if (imageList == EnumImageList.R人物_儿童_男)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_儿童_男;
            if (imageList == EnumImageList.R人物_成人_女)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_成人_女;
            if (imageList == EnumImageList.R人物_成人_男)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.人物_成人_男;
            if (imageList == EnumImageList.S手工录入取消)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.手工录入取消;
            if (imageList == EnumImageList.H会诊)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.会诊;
            if (imageList == EnumImageList.J警戒线)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.警戒线;
            if (imageList == EnumImageList.T退费)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.退费;
            if (imageList == EnumImageList.S收费)
                return global::Neusoft.FrameWork.WinForms.Properties.Resources.收费;

       



            return global::Neusoft.FrameWork.WinForms.Properties.Resources.默认;


        }

        #endregion

        #region 加密解密患者姓名　by luzhp@neusoft.com 2007-7-18
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="a_strString">要加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt3DES(string a_strString)
        {
            try
            {
                TripleDESCryptoServiceProvider DES = new
                    TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                Encoding encoding = Encoding.UTF8;
                string a_strKey = "his";
                DES.Key = hashMD5.ComputeHash(encoding.GetBytes(a_strKey));
                DES.Mode = CipherMode.ECB;

                ICryptoTransform DESEncrypt = DES.CreateEncryptor();

                byte[] Buffer = encoding.GetBytes(a_strString);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock
                    (Buffer, 0, Buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="a_strString">要解密的字符串</param>
        /// <returns></returns>
        public static string Decrypt3DES(string a_strString)
        {
            TripleDESCryptoServiceProvider DES = new
                TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            Encoding encoding = Encoding.UTF8;
            string a_strKey = "his";
            DES.Key = hashMD5.ComputeHash(encoding.GetBytes(a_strKey));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(a_strString);

                result = encoding.GetString(DESDecrypt.TransformFinalBlock
                    (Buffer, 0, Buffer.Length));
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// 获取远程配置文件
        /// </summary>
        /// <param name="configFileName">配置文件名称</param>
        /// <param name="strErr">错误信息</param>
        /// <returns>成功返回远程配置文件信息 失败返回null</returns>
        public static System.Xml.XmlDocument GetServerConfigFile(string configFileName, ref string strErr)
        {
            #region 获取配置文件路径

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(Application.StartupPath + "\\url.xml");

            System.Xml.XmlNode node = doc.SelectSingleNode("//dir");
            if (node == null)
            {
                strErr = "url中找dir结点出错！";
                return null;
            }

            string serverPath = node.InnerText;
            string configPath = "//" + configFileName; //远程配置文件名 

            #endregion

            try
            {
                doc.Load(serverPath + configPath);
            }
            catch (System.Net.WebException)
            {

            }
            catch (System.IO.FileNotFoundException)
            {

            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return null;
            }

            return doc;
        }

        #region 转换fp标题语言
        /// <summary>
        /// 转换fp标题语言 by Nxy
        /// </summary>
        /// <param name="sheeView"></param>
        public static void ConvertFpHeader(FarPoint.Win.Spread.SheetView sheeView)
        {
            sheeView.SheetName = Neusoft.FrameWork.Management.Language.Msg(sheeView.SheetName);
            int sheeViewCount = sheeView.Columns.Count;

            if (sheeViewCount > 0)
            {
                for (int i = 0; i < sheeViewCount; i++)
                {
                    sheeView.Columns[i].Label = Neusoft.FrameWork.Management.Language.Msg(sheeView.Columns[i].Label);
                }
            }
        }
        #endregion

        public static Color GetSysColor(EnumSysColor sysColor)
        {
            if (sysColor == EnumSysColor.Blue)
            {
                return Color.FromArgb(190, 226, 224);
            }
            else if (sysColor == EnumSysColor.Green)
            {
                return Color.FromArgb(241, 247, 213);
            }
            else if (sysColor == EnumSysColor.LightBlue)
            {
                return Color.FromArgb(230, 245, 244);
            }
            else if (sysColor == EnumSysColor.DarkBlue)
            {
                return Color.FromArgb(0, 155, 180);
            }
            else if (sysColor == EnumSysColor.DarkGreen)
            {
                return Color.FromArgb(183, 210, 0);
            }
            return Color.White;
        }

        #region 设置FarPoint样式
        /// <summary>
        /// 统一设置FarFoint的SheetView的格式
        /// </summary>
        public static void SetFarPointStyle(FarPoint.Win.Spread.SheetView sheet)
        {
            sheet.VisualStyles = VisualStyles.Off;
            sheet.ColumnHeader.DefaultStyle.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.LightBlue);
            sheet.SheetCornerStyle.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.LightBlue);
            if (sheet.RowHeader.ColumnCount > 0)
            {
                sheet.RowHeader.DefaultStyle.BackColor = Color.White;
                sheet.RowHeader.Columns.Get(0).Width = 45;
            }
            if (sheet.RowHeader.Rows.Count > 0)
            {
                sheet.ColumnHeader.Rows.Get(0).Height = 40;
            }
            sheet.GrayAreaBackColor = Color.White;
        }

        /// <summary>
        /// 统一设置FarFoint的格式
        /// </summary>
        public static void SetFarPointStyle(FarPoint.Win.Spread.FpSpread spread)
        {
            if (spread == null) return;
            spread.VisualStyles = VisualStyles.Off;
            for (int i = 0; i < spread.Sheets.Count; i++)
            {
                SetFarPointStyle(spread.Sheets[i]);
            }
        }
        #endregion

        #region 设置TabControl样式
        /// <summary>
        /// 统一设置TabControl控件样式
        /// </summary>
        /// <param name="tabControl"></param>
        public static void SetTabControlStyle(TabControl tabControl)
        {
            tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            tabControl.Margin = new System.Windows.Forms.Padding(0);

            //设置控件内Page页的间距
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.Margin = new System.Windows.Forms.Padding(0);
                tabPage.Padding = new System.Windows.Forms.Padding(0);
                tabPage.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.Green);
            }
        }

        private static void tabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            TabControl current = (sender as TabControl);
            Graphics g = e.Graphics;
            Rectangle endPageRect = current.GetTabRect(current.TabPages.Count - 1); //最后一个标题栏的范围
            Rectangle TitleRect = current.GetTabRect(e.Index);              //当前标题栏的范围
            Rectangle HeaderBackRect = Rectangle.Empty;             //背景区域

            switch (current.Alignment)
            {
                case TabAlignment.Top:
                    HeaderBackRect = new Rectangle(new Point(endPageRect.X + endPageRect.Width, endPageRect.Y),
                        new Size(current.Width - endPageRect.X - endPageRect.Width, endPageRect.Height));
                    break;
                case TabAlignment.Bottom:
                    HeaderBackRect = new Rectangle(new Point(endPageRect.X + endPageRect.Width, endPageRect.Y),
                        new Size(current.Width - endPageRect.X - endPageRect.Width, endPageRect.Height));
                    break;
                case TabAlignment.Left:
                    HeaderBackRect = new Rectangle(new Point(endPageRect.X, endPageRect.Y + endPageRect.Height),
                        new Size(endPageRect.Width, current.Height - endPageRect.Y - endPageRect.Height));
                    break;
                case TabAlignment.Right:
                    HeaderBackRect = new Rectangle(new Point(endPageRect.X, endPageRect.Y + endPageRect.Height),
                        new Size(endPageRect.Width, current.Height - endPageRect.Y - endPageRect.Height));
                    break;
            }



            Brush TitleBackBrush = new SolidBrush(Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.Blue));

            g.FillRectangle(TitleBackBrush, TitleRect);

            Font font = e.Font;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Far;
            Color fontcolor = System.Drawing.Color.Black;

            if (current.SelectedIndex == e.Index)    //如果绘制的标题就是选中的标题，则使用选中标题的字体，同时更新font和fontcolor
            {
                g.DrawRectangle(new Pen(current.TabPages[e.Index].BackColor), TitleRect);    //消除选中标题的矩形方框
                font = e.Font;
                fontcolor = Color.Blue;
            }
            Brush fontbrush = new SolidBrush(fontcolor);
            //绘制标题文本
            g.DrawString(current.TabPages[e.Index].Text, font, fontbrush, TitleRect, sf);

            //绘制背景
            if (HeaderBackRect != Rectangle.Empty)
            {
                Brush HeaderBackBrush = new SolidBrush(Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.Green));
                g.FillRectangle(HeaderBackBrush, HeaderBackRect);
            }

        }
        #endregion

        #region 设置ListView样式

        public static void SetListViewStyle(ListView listView)
        {
            if (listView == null) return;
            listView.OwnerDraw = true;
            if (listView.Columns.Count > 0)
            {
                listView.Columns[listView.Columns.Count - 1].Width = listView.Size.Width;
            }
                listView.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView_ColumnHeader);
                listView.DrawItem += new DrawListViewItemEventHandler(ListView_DrawItem);
                listView.DrawSubItem += new DrawListViewSubItemEventHandler(ListView_DrawSubItem);
            
        }

        private static void ListView_ColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {

            ListView current = sender as ListView;

            Graphics g = e.Graphics;
            Rectangle ColumnTitleBack = e.Bounds;
            ColumnTitleBack.Width = current.Size.Width;
            ColumnTitleBack.Height = ColumnTitleBack.Height - 1;

            e.Graphics.FillRectangle(new SolidBrush(Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.LightBlue)), ColumnTitleBack);

            Font font = e.Font;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Far;
            Color fontcolor = System.Drawing.Color.Black;
            g.DrawString(e.Header.Text, font, new SolidBrush(fontcolor), e.Bounds, sf);
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;	//采用系统默认方式绘制项

        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;	//采用系统默认方式绘制子项

        }
        #endregion
    }

    /// <summary>
    /// 图象列表
    /// </summary>
    public enum EnumImageList
    {
        T退费=58,
        S收费=59,
        J警戒线 = 60,
        H会诊 = 61,
        W文字_字体 = 62,
        W文字_下标 = 63,
        W文字_上标 = 64,
        R人物_婴儿_女 = 65,
        R人物_婴儿_男 = 66,
        R人物_老人_女 = 67,
        R人物_老人_男 = 68,
        R人物_儿童_女 = 69,
        R人物_儿童_男 = 70,
        R人物_成人_女 = 71,
        R人物_成人_男 = 72,
        S手工录入取消 = 73,

        L列表=74,
        B摆药台删除=75,
        B摆药台添加=76,
        M模版执行=77,
        F返回=78,
        B病历添加=79,
        B病历删除=80,
        G过滤 = 81,
        B摆药台 = 82,
        B摆药单 = 83,
        PR菜单上 = 84,
        PR菜单下 = 85,
        T套餐 = 86,
        T体检登记 = 87,
        T体检报告 = 88,
        P盘点结存解封 = 89,
        F分票 = 90,
        F封帐 = 91,
        D导入 = 92,//重92开始全部重构，第一个字母是汉字的第一个字的拼音
        D导出 = 93,
        M默认 = 94,
        T添加 = 95,
        X修改 = 96,
        S删除 = 97,
        B保存 = 98,
        D打印 = 99,
        D打印预览 = 100,
        T退出 = 101,
        C查询 = 102,
        Z作废信息 = 103,
        A安排 = 104,
        B帮助 = 107,
        B报警 = 108,
        B病历 = 109,
        C查询历史 = 110,
        C查找 = 111,
        C出院登记 = 112,
        C床位维护 = 113,
        D打印输液卡 = 114,
        D打印执行单 = 115,
        F房间 = 116,
        F分解 = 117,
        F复制 = 120,
        G顾客 = 121,
        H合并 = 122,
        H护理 = 123,
        H化验 = 124,
        H划价保存 = 125,
        H换单 = 126,
        H换医师 = 127,
        J集体 = 128,
        J健康档案 = 129,
        J接诊 = 130,
        J借出 = 131,
        J借入 = 132,
        K开帐 = 133,
        K科室 = 134,
        L历史信息 = 135,
        L临时号 = 136,
        L浏览 = 137,
        L楼层 = 138,
        L楼房 = 139,
        M明细 = 140,
        Q清空 = 142,
        Q取消 = 143,
        Q全退 = 144,
        Q全选 = 145,
        Q权限 = 146,
        Q确认收费 = 147,
        R人员 = 148,
        R人员组 = 149,
        R日消耗 = 150,
        S上一个 = 151,
        S设备 = 152,
        S设置 = 153,
        S生育保险 = 154,
        S收费项目 = 155,
        S手动录入 = 156,
        S刷新 = 157,
        T体温 = 161,
        X下一个 = 162,
        X新建 = 163,
        X信息 = 164,
        Y药品 = 165,
        Y医保 = 166,
        Y医嘱 = 167,
        Y医嘱审核 = 168,
        Y婴儿登记 = 169,
        Y预览 = 170,
        Y预约 = 171,
        Z暂存 = 172,
        Z召回 = 173,
        Z诊断 = 174,
        Z执行 = 175,
        C重打 = 176,
        Z注销 = 177,
        Z转科 = 178,
        Z转科确认 = 179,
        Z自动录入 = 180,
        Z组套 = 181,
        C采购单 = 182,
        C出库单 = 183,
        R入库单 = 184,
        S申请单 = 185,
        B病历本费 = 186,//后补充的
        C菜单删除 = 187,
        C菜单添加 = 188,
        C草药 = 189,
        C查找人员 = 190,
        C拆包 = 191,
        C窗口 = 192,
        C窗口添加 = 193,
        C窗口删除 = 194,
        C错误单据 = 195,
        D打包 = 196,
        D打印清单 = 197,
        F分类删除 = 198,
        F分类添加 = 199,
        G过滤删除 = 200,
        G过滤添加 = 201,
        H合并取消 = 202,
        J计划单 = 203,
        J计算器 = 204,
        J角色删除 = 205,
        J角色添加 = 206,
        K科室删除 = 207,
        K科室添加 = 208,
        K科室修改 = 209,
        L累计开始 = 210,
        L累计取消 = 211,
        L累计停止 = 212,
        L另存为 = 213,
        M明细删除 = 214,
        M明细添加 = 215,
        M模版 = 216,
        M模版删除 = 217,
        M模版添加 = 218,
        P排序 = 219,
        P盘点附加 = 220,
        P盘点 = 221,
        P盘点开始 = 222,
        P盘点取消 = 223,
        P盘点停止 = 224,
        P批量封存 = 225,
        P批量复制 = 226,
        Q全不选 = 227,
        Q全选取消 = 228,
        Q权限删除 = 229,
        Q权限添加 = 230,
        R人员修改 = 231,
        R日期 = 232,
        S上级科室 = 233,
        S设备删除 = 234,
        S设备添加 = 235,
        T跳转 = 236,
        T停诊 = 237,
        W完成的 = 238,
        W未结存 = 239,
        W未完成的 = 240,
        Y一般单据 = 241,
        Y一条记录删除 = 242,
        Y一条记录添加 = 243,
        Y医嘱退出 = 244,
        Y已结存 = 245,
        Z增量保存 = 246,
        Z诊出 = 247,
        Z纸单 = 248,
        Z子级 = 249,
        Z组套删除 = 250,
        Z组套添加 = 251,
        Z作废 = 252


    }

    /// <summary>
    /// 插件功能目录
    /// </summary>
    public enum EnumPlugin
    {
        /// <summary>
        /// 医保
        /// </summary>
        SI,

        /// <summary>
        /// LIS
        /// </summary>
        LIS,

        /// <summary>
        /// PACS
        /// </summary>
        PACS,

        /// <summary>
        /// 合理用药
        /// </summary>
        PASS,

        /// <summary>
        /// 认证
        /// </summary>
        CA,

        /// <summary>
        /// 银联
        /// </summary>
        BANK,

        /// <summary>
        /// 工具栏
        /// </summary>
        TOOLBAR



    }

    public enum EnumSysColor
    {
        Blue = 0,
        DarkBlue = 3,
        LightBlue = 4,
        Green = 1,
        DarkGreen = 2,

    }



}
