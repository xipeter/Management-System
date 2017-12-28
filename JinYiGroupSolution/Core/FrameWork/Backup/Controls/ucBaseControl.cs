using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 基础控件，实现了IControlable,IQueryControlable,IUserControlable[电子病历]接口]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBaseControl : System.Windows.Forms.UserControl, IControlable, IQueryControlable
    {
       
        public ucBaseControl()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            this.BackColor = Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Green);
            
            // TODO: 在 InitializeComponent 调用后添加任何初始化

        }
        protected System.Windows.Forms.TreeView tv = null;
        private ArrayList alNodes = null;

        /// <summary>
        /// 获得选择的节点
        /// </summary>
        /// <returns></returns>
        protected ArrayList GetSelectedTreeNodes()
        {
            if (tv == null) return new ArrayList();
            this.alNodes = new ArrayList();
            if (this.tv.Nodes.Count > 0)
                this.GetSelectedNodesTag(this.tv.Nodes[0]);
            return alNodes;
        }

        private void GetSelectedNodesTag(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Checked)
                    alNodes.Add(node.Tag);
                if (node.Nodes.Count > 0)
                    this.GetSelectedNodesTag(node);
            }
        }

        private Neusoft.HISFC.BizProcess.MQ.MsmqReceiver msgReceieve = null;

        /// <summary>
        /// 启动消息接收
        /// </summary>
        public void BeginRecieveMessage()
        {
            this.msgReceieve = new Neusoft.HISFC.BizProcess.MQ.MsmqReceiver(Neusoft.HISFC.BizProcess.MQ.MsmqEnvironment.HisProcessMessageQueueName);

            this.msgReceieve.MessageArrived += new Neusoft.HISFC.BizProcess.MQ.MessageArrivedEventHandler(msgReceieve_MessageArrived);
        }

        private void msgReceieve_MessageArrived(object sender, Neusoft.HISFC.BizProcess.MQ.MessgeArrivedEventArgs e)
        {
            this.GetMessage(sender, e.Message);
        }

        #region IContronable 成员

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        public virtual ToolBarService Init(object sender,object neuObject, object param)
        {
            // TODO:  添加 ucBaseControl.Init 实现
            if (BeginInit != null) this.BeginInit(this, null);
            tv = sender as TreeView;
            ToolBarService toolBarService = OnInit(sender, neuObject, param);
            if (EndInit != null) this.EndInit(this, null);
            return toolBarService;

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        protected virtual ToolBarService OnInit(object sender, object neuObject, object param)
        {
            return null;
        }

        /// <summary>
        /// 开始初始化事件
        /// </summary>
        public event System.EventHandler BeginInit;

        /// <summary>
        /// 结束初始化时间
        /// </summary>
        public event System.EventHandler EndInit;

        /// <summary>
        /// 设置数值前
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual int BeforSetValue(object neuObject, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            return 0;
        }

        /// <summary>
        /// 设置数值
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public int SetValue(object neuObject, System.Windows.Forms.TreeNode e)
        {
            // TODO:  添加 ucBaseControl.SetValue 实现
            if (BeginSetValue != null) this.BeginSetValue(this, null);
            int iReturn = this.OnSetValue(neuObject, e);
            if (EndSetValue != null) this.EndSetValue(this, null);
            return iReturn;

        }

        /// <summary>
        /// 设置数值时候
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual int OnSetValue(object neuObject, System.Windows.Forms.TreeNode e)
        {
            return 0;
        }

        /// <summary>
        /// 开始设置数值
        /// </summary>
        public event System.EventHandler BeginSetValue;

        /// <summary>
        /// 结束设置数值
        /// </summary>
        public event System.EventHandler EndSetValue;


        /// <summary>
        /// 设置数值
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public int SetValues(ArrayList alValues, object e)
        {
            // TODO:  添加 ucBaseControl.SetValues 实现
            if (BeginSetValue != null) this.BeginSetValue(this, null);
            int iReturn = this.OnSetValues(alValues, e);
            if (EndSetValue != null) this.EndSetValue(this, null);
            return iReturn;
        }
        /// <summary>
        /// toolBar Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// 正在设置数值
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual int OnSetValues(ArrayList alValues, object e)
        {

            return 0;
        }

        /// <summary>
        /// 刷新树事件
        /// </summary>
        public event System.EventHandler RefreshTree;

        /// <summary>
        /// 要刷新树函数
        /// </summary>
        protected virtual void OnRefreshTree()
        {
            if (this.RefreshTree != null) this.RefreshTree(this, null);
        }

        /// <summary>
        /// 接收消息函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg">消息字符串</param>
        /// <returns></returns>
        public virtual int GetMessage(object sender, string msg)
        {
            if (this.SendMessage != null) this.SendMessage(sender, msg);
            // TODO:  添加 ucBaseControl.SendMessage 实现
            //{B88D295F-D32D-48ba-9A2D-4C9BF9DD9206}
            return 0;
        }

        /// <summary>
        /// 接收消息事件
        /// </summary>
        public event MessageEventHandle SendMessage;

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        protected virtual void OnSendMessage(object sender, string msg)
        {
            // TODO:  添加 ucBaseControl.SendMessage 实现
            //{B88D295F-D32D-48ba-9A2D-4C9BF9DD9206}
            Neusoft.FrameWork.Models.NeuObject messageObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject targetDeptObj = sender as Neusoft.FrameWork.Models.NeuObject;
            int iReturn = 0;
            string errText = "";

            //要显示的文本使用NeuObject的ID
            messageObj.ID = msg;
            try
            {
                Neusoft.HISFC.BizProcess.MQ.MsmqSender msmqSender = new Neusoft.HISFC.BizProcess.MQ.MsmqSender();
                //MQ没有重构，重构后再修改此处
                //iReturn = msmqSender.SendByDeptCode(messageObj, targetDeptObj.ID, Neusoft.HISFC.BizProcess.MQ.MsmqEnvironment.HisProcessMessageQueueName);
                // {839D3A8A-49FA-4d47-A022-6196EB1A5715}
                iReturn = msmqSender.SendByDeptCode(messageObj, targetDeptObj.ID, Neusoft.HISFC.BizProcess.MQ.MsmqEnvironment.HisGeneralMessageQueueName);
                //if (iReturn != -1)
                //{
                //    iReturn = msmqSender.SendByDeptCode(messageObj, targetDeptObj.ID, Neusoft.HISFC.BizProcess.MQ.MsmqEnvironment.HisProcessMessageQueueName);
                //}

            }
            catch (Exception ex)
            {
                errText = ex.Message;
                return;
            }
            return;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        protected virtual void OnSendProcessMessage(object sender, string msg)
        {
            // TODO:  添加 ucBaseControl.SendMessage 实现
            //{B88D295F-D32D-48ba-9A2D-4C9BF9DD9206}
            Neusoft.FrameWork.Models.NeuObject messageObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject targetDeptObj = sender as Neusoft.FrameWork.Models.NeuObject;
            int iReturn = 0;
            string errText = "";

            //要显示的文本使用NeuObject的ID
            messageObj.ID = msg;
            try
            {
                Neusoft.HISFC.BizProcess.MQ.MsmqSender msmqSender = new Neusoft.HISFC.BizProcess.MQ.MsmqSender();
                //MQ没有重构，重构后再修改此处
                //iReturn = msmqSender.SendProcessMessageByDeptCode(messageObj, targetDeptObj.ID);
            }
            catch (Exception ex)
            {
                errText = ex.Message;
                return;
            }
            return;
        }
        
        /// <summary>
        /// 状态条事件
        /// </summary>
        public event MessageEventHandle StatusBarInfo;

        /// <summary>
        /// 添加状态条信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        protected virtual void OnStatusBarInfo(object sender, string msg)
        {
            if (this.StatusBarInfo != null) this.StatusBarInfo(sender, msg);
        }

        #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
        /// <summary>
        /// 增加StatusBarPanel
        /// </summary>
        /// <param name="icon">图标文件</param>
        /// <param name="msg">消息</param>
        /// <param name="index">插入位置 0,1,2,3</param>
        protected virtual void InsertStastusBarPanel(System.Drawing.Icon icon, string msg, int index)
        {
            if (this.AddStastusBarPanel != null) this.AddStastusBarPanel(icon, msg, index);
        }

        /// <summary>
        /// 增加StatusBarPanel
        /// </summary>
        public event SendIconToStatusBar AddStastusBarPanel; 
        #endregion

        /// <summary>
        /// 控件信息传递
        /// </summary>
        public event SendParamToControlHandle SendParamToControl;

        /// <summary>
        /// 传递信息时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dllname"></param>
        /// <param name="controlName"></param>
        /// <param name="param"></param>
        protected virtual void OnSendParamToControl(object sender,string dllname,string controlName,object param)
        {
            if (SendParamToControl != null) this.SendParamToControl(sender, dllname, controlName, param);
        }

        #endregion

        #region IQueryControlable 成员

        /// <summary>
        /// 开始查询事件
        /// </summary>
        public event System.EventHandler BeginQuery;

        /// <summary>
        /// 结束查询事件
        /// </summary>
        public event System.EventHandler EndQuery;

        /// <summary>
        /// 开始保存事件
        /// </summary>
        public event System.EventHandler BeginSave;

        /// <summary>
        /// 结束保存事件
        /// </summary>
        public event System.EventHandler EndSave;

        /// <summary>
        /// 开始打印事件
        /// </summary>
        public event System.EventHandler BeginPrint;

        /// <summary>
        /// 结束打印事件
        /// </summary>
        public event System.EventHandler EndPrint;

        /// <summary>
        /// 开始刷新事件
        /// </summary>
        public event System.EventHandler BeginRefresh;

        /// <summary>
        /// 结束刷新事件
        /// </summary>
        public event System.EventHandler EndRefresh;

        /// <summary>
        /// 刷新按钮变化
        /// </summary>
        public event System.EventHandler RefreshChanged;

        /// <summary>
        /// 打印按钮变化
        /// </summary>
        public event System.EventHandler PrintChanged;

        /// <summary>
        /// 查询按钮变化
        /// </summary>
        public event System.EventHandler QueryChanged;

        /// <summary>
        /// 打印设置按钮
        /// </summary>
        public event System.EventHandler PrintSetChanged;

        /// <summary>
        /// 打印预览按钮
        /// </summary>
        public event System.EventHandler PrintPreviewChanged;

        /// <summary>
        /// 退出按钮
        /// </summary>
        public event System.EventHandler ExitChanged;

        /// <summary>
        /// 保存按钮
        /// </summary>
        public event System.EventHandler SaveChanged;

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int Query(object sender, object neuObject)
        {
            // TODO:  添加 ucBaseControl.Query 实现
            if (this.BeginQuery != null) this.BeginQuery(this, null);
            int iReturn = this.OnQuery(sender, neuObject);
            if (this.EndQuery != null) this.EndQuery(this, null);
            return iReturn;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected virtual int OnQuery(object sender, object neuObject)
        {
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int Save(object sender, object neuObject)
        {
            if (this.BeginSave != null) this.BeginSave(this, null);
            int iReturn = this.OnSave(sender, neuObject);
            if (this.EndSave != null) this.EndSave(this, null);
            return iReturn;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected virtual int OnSave(object sender, object neuObject)
        {
            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int Print(object sender, object neuObject)
        {
            // TODO:  添加 ucBaseControl.Print 实现
            if (this.BeginPrint != null) this.BeginPrint(this, null);
            int iReturn = this.OnPrint(sender, neuObject);
            if (this.EndPrint != null) this.EndPrint(this, null);
            return iReturn;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected virtual int OnPrint(object sender, object neuObject)
        {
            return 0;
        }
        /// <summary>
        /// 打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int SetPrint(object sender, object neuObject)
        {
            return 0;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int PrintPreview(object sender, object neuObject)
        {
            return this.OnPrintPreview(sender, neuObject);
        }

        /// <summary>
        /// 打印与蓝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected virtual int OnPrintPreview(object sender, object neuObject)
        {
            return 0;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int Exit(object sender, object neuObject)
        {
            // TODO:  添加 ucBaseControl.Exit 实现
            return 0;
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public virtual int Export(object sender, object neuObject)
        {
            // TODO:  添加 ucBaseControl.Export 实现
            return 0;
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public override void Refresh()
        {
            // TODO:  添加 ucBaseControl.Refresh 实现
            if (this.BeginRefresh != null) this.BeginRefresh(this, null);
            this.OnRefresh();
            if (this.EndRefresh != null) this.EndRefresh(this, null);
        }
        /// <summary>
        /// 刷新
        /// </summary>
        protected virtual void OnRefresh()
        {

        }
        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnRefreshButtonChanged(bool isEnabled)
        {
            if (this.RefreshChanged != null) this.RefreshChanged(isEnabled, null);
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnPrintButtonChanged(bool isEnabled)
        {
            if (this.PrintChanged != null) this.PrintChanged(isEnabled, null);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnQueryButtonChanged(bool isEnabled)
        {
            if (this.QueryChanged != null) this.QueryChanged(isEnabled, null);
        }

        /// <summary>
        /// 打印设置按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnPrintSetButtonChanged(bool isEnabled)
        {
            if (this.PrintSetChanged != null) this.PrintSetChanged(isEnabled, null);
        }

        /// <summary>
        /// 打印预览按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnPrintPreviewButtonChanged(bool isEnabled)
        {
            if (this.PrintPreviewChanged != null) this.PrintPreviewChanged(isEnabled, null);
        }


        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnExitButtonChanged(bool isEnabled)
        {
            if (this.ExitChanged != null) this.ExitChanged(isEnabled, null);
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="isEnabled"></param>
        protected virtual void OnSaveButtonChanged(bool isEnabled)
        {
            if (this.SaveChanged != null) this.SaveChanged(isEnabled, null);
        }

        /// <summary>
        /// 控件名称
        /// </summary>
        public virtual string ControlText
        {
            get
            {
                return this.Name;
            }
        }

        #endregion



        #region IUserControlable 成员
        protected bool bIsPrint = false;
        /// <summary>
        /// 是否处于打印状态
        /// </summary>
        public virtual bool IsPrint
        {
            get
            {
                return bIsPrint;
            }
            set
            {
                bIsPrint = value;
            }
        }

        /// <summary>
        /// 初始化，传入患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="params"></param>
        public virtual void LoadUC(object sender, string[] @params)
        {
            this.Init(null, sender, @params);
        }

        /// <summary>
        /// 刷新控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="params"></param>
        public virtual void RefreshUC(object sender, string[] @params)
        {
            this.Refresh();
        }

        /// <summary>
        /// 保存控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual short Save(object sender, Neusoft.FrameWork.Management.Transaction t)
        {
            return (short)this.Save(null, sender);
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public virtual int Valid(object sender)
        {
            return 0;
        }

        public void Init(object sender, string[] @params)
        {
            this.Init(null, sender, @params);
        }

        public int Save(object sender)
        {
            return this.Save(sender, sender);
        }

        public Control FocusedControl
        {
            get { return this; }
        }

        #endregion

    }
}
