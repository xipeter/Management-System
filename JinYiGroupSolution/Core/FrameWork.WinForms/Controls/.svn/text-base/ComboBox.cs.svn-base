using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// ComboBox 的摘要说明。
    /// </summary>
    [ToolboxBitmap( typeof( System.Windows.Forms.ComboBox ) )]
    public class NeuComboBox : System.Windows.Forms.ComboBox, INeuControl
    {
        private System.ComponentModel.IContainer components = null;

        public NeuComboBox(System.ComponentModel.IContainer container)
        {
            //
            // Windows.Forms 类撰写设计器支持所必需的
            //
            //container.Add(this);
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, false );
        }

        public NeuComboBox()
        {
            //
            // Windows.Forms 类撰写设计器支持所必需的
            //
            InitializeComponent();
            this.SelectedIndexChanged += new EventHandler( NeuComboBox_SelectedIndexChanged );
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, false );
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

                #region Add By Liangjz

                if (this.alItems != null)
                {
                    this.alItems.Clear();
                    this.alItems = null;
                }
                if (this.frmPop != null)
                {
                    this.frmPop.Dispose();
                    this.frmPop = null;
                }


                #endregion

            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NeuComboBox
            // 
            this.Leave += new System.EventHandler( this.ComboBox_Leave );
            this.ResumeLayout( false );

        }
        #endregion

        #region "myCode"
        public ArrayList alItems = new ArrayList();
        protected bool isItemOnly = false;
        protected bool bShowCustomerList = false;
        protected Neusoft.FrameWork.WinForms.Forms.frmEasyChoose frmPop;
        protected bool bShowID;
        //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
        //private bool isTextChanged = false;
        protected Button btn = new Button();
        protected void SetButton()
        {
            //btn.Text ="▲";
            btn.Visible = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.TabStop = false;
            btn.BringToFront();
            btn.BackColor = Color.Silver;
            //			Rectangle rc = ClientRectangle;
            //			
            ////			int width = ARROW_WIDTH;
            //			int left = rc.Right - width - 2;
            //			int top = rc.Top + 1;
            //			int height = rc.Height - 2;
            //			
            //			btn.Size = new Size(width,height);
            //			btn.Location = new Point(left ,top);

            btn.Size = new Size( 18, this.Height - 2 );
            btn.Location = new Point( this.Width - 18, 1 );
            btn.Click += new EventHandler( btn_Click );
            this.Controls.Add( btn );
        }


        public int AppendItems(ArrayList Items)
        {
            base.Items.Clear();

            ArrayList items = Items.Clone() as ArrayList;

            if (alItems == null)
                alItems = new ArrayList();

            for (int i = 0; i < items.Count; i++)
            {
                alItems.Insert( alItems.Count, items[i] );
            }

            Neusoft.FrameWork.Models.NeuObject objItem;
            try
            {
                for (int i = 0; i < alItems.Count; i++)
                {
                    objItem = new Neusoft.FrameWork.Models.NeuObject();
                    objItem = (Neusoft.FrameWork.Models.NeuObject)alItems[i];
                    if (this.bShowID)
                        base.Items.Add( objItem.ID );
                    else
                        base.Items.Add( objItem.Name );
                }
            }
            catch
            {
                return -1;
            }
            //初始化窗口
            frmPop = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose( this.alItems );
            frmPop.Text = "请选择项目";
            frmPop.StartPosition = FormStartPosition.CenterScreen;
            frmPop.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler( frmPop_SelectedItem );
            //读取设置输入法配置文件
            SpellCode = Neusoft.FrameWork.WinForms.Classes.Function.GetInputType();

            return 0;
        }
        /// <summary>
        /// 清除所有信息
        /// </summary>
        public void ClearItems()
        {
            this.alItems = new ArrayList();
            this.Items.Clear();
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int AddItems(ArrayList items)
        {
            if (items == null)
                return -1;

            base.Items.Clear();
            alItems = new ArrayList();
            return this.AppendItems( items );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int AddItems(System.Collections.Generic.List<Neusoft.FrameWork.Models.NeuObject> list)
        {
            this.alItems = new ArrayList();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in list)
            {
                this.alItems.Add( obj );
            }

            return this.AddItems( alItems );
        }
        /// <summary>
        /// 弹出的窗口
        /// </summary>
        public Form PopForm
        {
            get
            {
                return this.frmPop;
            }
            set
            {

            }
        }

        private bool isPopForm = true;

        /// <summary>
        /// 弹出的窗口
        /// </summary>
        [Description( "是否显示弹出列表" )]
        public bool IsPopForm
        {
            get
            {
                return this.isPopForm;
            }
            set
            {
                this.isPopForm = value;
            }
        }
        /// <summary>
        /// 是否显示ID
        /// </summary>
        [Obsolete( "用IsShowID代替,是否在下拉列表显示ID来代替Name的显示", false )]
        public bool ShowID
        {
            get
            {
                return this.bShowID;
            }
            set
            {
                this.bShowID = value;
            }
        }
        /// <summary>
        /// 是否在下拉列表显示ID来代替Name的显示
        /// </summary>
        [Description( "是否在下拉列表显示ID来代替Name的显示" )]
        public bool IsShowID
        {
            get
            {
                return this.bShowID;
            }
            set
            {
                this.bShowID = value;
            }
        }
        #endregion

        #region 属性
        protected bool isLike = true;
        /// <summary>
        /// 是否模糊查询
        /// </summary>
        [Description( "输入时候是否利用模糊查询来查找项目" )]
        public bool IsLike
        {
            get
            {
                return this.isLike;
            }
            set
            {
                this.isLike = value;
            }
        }
        /// <summary>
        /// 选择的项目
        /// </summary>
        public new Neusoft.FrameWork.Models.NeuObject SelectedItem
        {
            get
            {
                if (this.SelectedIndex < 0)
                    return null;
                return this.alItems[this.SelectedIndex] as Neusoft.FrameWork.Models.NeuObject;
            }
        }

        /// <summary>
        /// 只能从下拉列表里面选择
        /// 默认为false
        /// </summary>
        [Description( "是否允许用户输入代替列表内容，既输入内容只是列表内容" )]
        public bool IsListOnly
        {
            set
            {
                this.isItemOnly = value;
            }
            get
            {
                return isItemOnly;
            }
        }
        /// <summary>
        ///  显示自定义列表
        /// </summary>
        [Description( "是否显示用户列表来代替原始下拉列表" )]
        public bool IsShowCustomerList
        {
            get
            {
                return this.bShowCustomerList;
            }
            set
            {
                this.bShowCustomerList = value;

            }

        }
        /// <summary>
        /// 显示自定义列表
        /// </summary>
        public bool ShowCustomerList
        {
            get
            {
                return this.bShowCustomerList;
            }
            set
            {
                this.bShowCustomerList = value;
            }

        }

        /// <summary>
        /// 设置货获得当前Tag
        /// </summary>
        public new object Tag
        {
            get
            {
                if (this.Text.Trim() == "")
                    base.Tag = "";
                return base.Tag;
            }
            set
            {

                int i;
                try
                {
                    if (value == null || value.ToString().Trim() == "")
                    {
                        base.Tag = value;
                        base.Text = null;
                        return;
                    }
                }
                catch
                {
                }
                //通过文本更新Tag就不重新付值了
                if (isTextChangeSetTag == false)
                {
                    try
                    {
                        for (i = 0; i < alItems.Count; i++)
                        {
                            try
                            {
                                string sValue = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).ID.ToString();
                                if (value.ToString() == sValue)
                                {
                                    #region 原来的屏蔽{2C15D3C3-50E7-47b8-B56A-C82E0498FBE9} 把NAME赋值给TEXT有问题 edit by zl 2010-12-22
                                    if (bShowID)
                                        base.Text = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).ID;//重新给Text
                                    else
                                    {
                                        //base.Text = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).Name;//重新给Text
                                        base.SelectedIndex = i;
                                    }
                                    #endregion
                                    //base.Text = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).ID;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                string s = ex.Message;
                            }
                        }

                    }
                    catch
                    {
                    }
                }
                base.Tag = value;
            }



        }

        public bool IsFlat
        {
            get
            {
                return false;
            }
            set
            {
            }

        }

        public bool ToolBarUse
        {
            get
            {
                return false;
            }
            set
            {
            }

        }
        public bool IsEnter2Tab
        {
            get
            {
                return false;
            }
            set
            {
            }

        }
        public Image ArrowBackImage
        {
            set
            {
                btn.BackgroundImage = value;
            }
        }
        public Color ArrowBackColor
        {
            get
            {
                return btn.BackColor;
            }
            set
            {
                btn.BackColor = value;
            }
        }
        #endregion

        #region 函数
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            isTextChangeSetTag = true;
            try
            {
                base.Tag = ((Neusoft.FrameWork.Models.NeuObject)(alItems[this.SelectedIndex])).ID;
            }
            catch
            {
            }
            isTextChangeSetTag = false;
            //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
            //isTextChanged = false;
            base.OnSelectedIndexChanged( e );
        }
        bool isTextChangeSetTag = false;
        void NeuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.Handled = true;
                this.ValidText();
            }
            else if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                iSpellCode++;
                if (iSpellCode >= 4)
                    iSpellCode = 0;
                SpellCode = this.iSpellCode;
            }
            else if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                ShowSelectDialog();
                return;
            }
            //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
            //else
            //{
            //    isTextChanged = true;
            //}
            base.OnKeyDown( e );
        }

        //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
        /// <summary>
        /// text是否发生变化
        /// </summary>
        /// <returns></returns>
        private bool isChangeText()
        {
            string name = string.Empty;
            if (this.Tag != null && !string.IsNullOrEmpty(this.Tag.ToString()))
            {
                string id = this.Tag.ToString();
                for (int i = 0; i < alItems.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject o = (Neusoft.FrameWork.Models.NeuObject)alItems[i];
                    if (o.ID == id)
                    {
                        name = o.Name;
                        break;
                    }
                }

            }
            if (!string.IsNullOrEmpty(name) && name == this.Text.Trim())
            {
                return false;
            }
            return true;
        }
        

        private void ValidText()
        {
            //{07252C73-80B1-42b6-A8FE-44AF3707CF54}
            if (base.Text.Trim() == "")
                return;
            //if (base.Text == " " || base.Text == "  " || base.Text == "   ")
            //{
            //    ShowSelectDialog();
            //    return;
            //}
            if (this.DropDownStyle == ComboBoxStyle.DropDownList)
                return;//如果只是选择的，不需要判断dd

            try
            {
                //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
                if (!isChangeText()) return;
                for (int i = 0; i < alItems.Count; i++)
                {
                    #region 查找匹配
                    Neusoft.FrameWork.Models.NeuObject o = (Neusoft.FrameWork.Models.NeuObject)alItems[i];
                    try
                    {
                        if (o.Name.ToUpper().Trim() == base.Text.ToUpper().Trim())
                        {
                            showSelectText( o );
                            return;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (o.ID.ToUpper().Trim() == base.Text.ToUpper().Trim())
                        {
                            showSelectText( o );
                            return;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (o.Memo != null && o.Memo.ToUpper().Trim() == base.Text.ToUpper().Trim())
                        {
                            showSelectText( o );
                            return;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        Neusoft.HISFC.Models.Base.ISpell Spell = o as Neusoft.HISFC.Models.Base.ISpell;
                        switch (iSpellCode)
                        {
                            case 0:
                                if ((Spell.SpellCode != null && Spell.SpellCode.ToUpper().Trim() == base.Text.ToUpper().Trim())
                                    || (Spell.WBCode != null && Spell.WBCode.ToUpper().Trim() == base.Text.ToUpper().Trim())
                                    || (Spell.UserCode != null && Spell.UserCode.ToUpper().Trim() == base.Text.ToUpper().Trim()))
                                {
                                    showSelectText( o );
                                    return;
                                }
                                break;
                            case 1:
                                if (Spell.SpellCode != null && Spell.SpellCode.ToUpper().Trim() == base.Text.ToUpper().Trim())
                                {
                                    showSelectText( o );
                                    return;
                                }
                                break;
                            case 2:
                                if (Spell.WBCode != null && Spell.WBCode.ToUpper().Trim() == base.Text.ToUpper().Trim())
                                {
                                    showSelectText( o );
                                    return;
                                }
                                break;
                            case 3:
                                if (Spell.UserCode != null && Spell.UserCode.ToUpper().Trim() == base.Text.ToUpper().Trim())
                                {
                                    showSelectText( o );
                                    return;
                                }
                                break;
                        }
                    }
                    catch
                    {
                    }
                    #endregion
                }

                if (this.isItemOnly) //没有找到 是只能选择
                {
                    if (this.isLike)//模糊查询
                    {
                        #region 查找匹配
                        for (int i = 0; i < alItems.Count; i++)
                        {
                            Neusoft.FrameWork.Models.NeuObject o = (Neusoft.FrameWork.Models.NeuObject)alItems[i];
                            try
                            {
                                if (o.Name.ToUpper().Trim().IndexOf( base.Text.ToUpper().Trim() ) >= 0)
                                {
                                    showSelectText( o );
                                    return;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (o.ID.ToUpper().Trim().IndexOf( base.Text.ToUpper().Trim() ) >= 0)
                                {
                                    showSelectText( o );
                                    return;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (o.Memo != null && o.Memo != "")
                                {
                                    if (o.Memo != null && o.Memo.ToUpper().Trim().IndexOf( base.Text.ToUpper().Trim() ) >= 0)
                                    {
                                        showSelectText( o );
                                        return;
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        #endregion
                    }
                    base.Text = "";//其它
                }
            }
            catch
            {
                if (this.isItemOnly)
                    base.Text = "";
            }
        }
        private void showSelectText(Neusoft.FrameWork.Models.NeuObject o)
        {
            if (this.bShowID)
                base.Text = o.ID;
            else
                base.Text = o.Name;
            for (int i = 0; i < alItems.Count; i++)
            {
                try
                {
                    string sValue = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).ID.ToString();
                    if (o.ID == sValue)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }
        /// <summary>
        /// 当前输入码
        /// </summary>
        public int SpellCode
        {
            set
            {
                this.iSpellCode = value;
                QueryType = "拼音+五笔+自定义";
                switch (iSpellCode)
                {
                    case 0:
                        QueryType = "拼音+五笔+自定义";
                        this.BackColor = Color.FromArgb( 255, 255, 255 );
                        break;
                    case 1:
                        QueryType = "拼音码";
                        this.BackColor = Color.FromArgb( 255, 225, 225 );
                        break;
                    case 2:
                        this.BackColor = Color.FromArgb( 255, 200, 200 );
                        QueryType = "五笔码";
                        break;
                    case 3:
                        this.BackColor = Color.FromArgb( 255, 150, 150 );
                        QueryType = "自定义码";
                        break;
                    default:
                        this.BackColor = Color.FromArgb( 255, 255, 255 );
                        break;
                }
                tooltip.SetToolTip( this, QueryType );
                //System.Windows.Forms.Cursor.Position = this.PointToScreen(new Point(this.Parent.Left,this.Parent.Top));
                tooltip.Active = true;
            }

        }
        protected ToolTip tooltip = new ToolTip();
        protected int iSpellCode = 0;
        protected string QueryType = "拼音码";
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            if (base.Text == "")
                return;
            //文本变化，重新判断
            //if (isTextChanged)
            //{B185DD6A-4CFE-469c-A7AB-6187C4C698EA}
            if(isChangeText())
                this.ValidText();


        }

        /// <summary>
        /// 显示弹出选择窗体
        /// </summary>
        protected void ShowSelectDialog()
        {
            if (IsPopForm)
            {
                try
                {
                    frmPop.ShowDialog();
                }
                catch
                {
                    SetPopForm();
                }
                if (base.Text.Trim() == string.Empty)//{DCC02C4A-AB2F-4790-BFCD-AB360D748C83}
                {
                    base.Text = string.Empty;
                }
            }
        }
        protected void SetPopForm()
        {
            frmPop = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose( this.alItems );
            frmPop.Text = "请选择项目";
            frmPop.StartPosition = FormStartPosition.CenterScreen;
            frmPop.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler( frmPop_SelectedItem );
            frmPop.ShowDialog();
        }
        #endregion

        #region 显示下拉列表


        protected bool bShowOrHide = true;
        private void ShowSelectItem()
        {
            if (this.alItems == null || this.alItems.Count <= 0)
                return;


            return;
        }

        private void lst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInfo();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.CloseForm();
            }
        }
        private void GetInfo()
        {


        }
        private void CloseForm()
        {

            try
            {
                if (frmPop.Visible)
                    this.frmPop.Hide();
            }
            catch
            {

            }
        }

        private void ComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.bShowCustomerList)
            {
                if (e.X > this.Width - 20)
                    ShowSelectItem();
            }
        }
        #endregion

        private void frmPop_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            if (sender != null)
            {
                if (this.bShowID)
                {
                    base.Text = sender.ID;
                }
                else
                {
                    base.Text = sender.Name;
                    //{4491B5E5-775A-4c9f-A856-86B0767C9C42}
                    for (int i = 0; i < alItems.Count; i++)
                    {
                        try
                        {
                            string sValue = ((Neusoft.FrameWork.Models.NeuObject)alItems[i]).ID.ToString();
                            if (sender.ID == sValue)
                            {
                                this.SelectedIndex = i;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                        }
                    }
                }
            }
        }

        private void poplst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetInfo();
            }
            catch
            {
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            ShowSelectItem();
        }

        #region INeuControl 成员

        public StyleType Style
        {
            get
            {
                return StyleType.Flat;
            }
            set
            {

            }
        }

        #endregion
    }
}
