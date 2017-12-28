using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.Preparation
{
    public partial class ucQueryItem : UserControl
    {
        public ucQueryItem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            InitializeComponent();

            this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(txtQueryCode_KeyDown);
            this.txtQuery.TextChanged += new EventHandler(txtQueryCode_TextChanged);
            this.txtQuery.Enter += new EventHandler(txtQuery_Enter);
            this.txtQuery.Leave += new EventHandler(txtQuery_Leave);
            this.chkNew.Checked = isCheck;
            this.chkNew.Visible = isShow;
        }

        /// <summary>
        /// 项目选择
        /// </summary>
        public event System.EventHandler SelectItem;

        /// <summary>
        ///  输入查询框 按下键时触发 当前使用下拉列表过滤时 不触发此事件
        /// </summary>
        public event System.Windows.Forms.KeyEventHandler TextKeyDown;

        /// <summary>
        /// 输入查询框 字符发生变化时出发 当前使用下拉列表过滤时 不触发此事件
        /// </summary>
        public new event System.EventHandler TextChanged;

        /// <summary>
        /// 药品查询                         
        /// </summary>
        protected frmItemList frmItem = null;

        /// <summary>
        /// 是否使用特殊的Text框显示
        /// </summary>
        private bool isUseSpeText = true;

        /// <summary>
        ///  是否过滤
        /// </summary>
        private bool isFilter = true;

        public bool isCheck = true;
        public bool isShow = true;

        #region 属性
        /// <summary>
        /// TextBox控件内当前字符
        /// </summary>
        public string TxtStr
        {
            get
            {
                return this.txtQuery.Text;
            }
        }
        /// <summary>
        /// 查询标签名称
        /// </summary>
        public string LabelName
        {
            set
            {
                this.lblQuery.Text = value;
            }
        }
        /// <summary>
        /// 是否隐藏CheckBox 如设置为不隐藏 则需要选中该按钮才可以弹出药品过滤界面
        /// </summary>
        public bool IsHideAdd
        {
            set
            {
                if (value)
                {
                    this.chkNew.Checked = true;
                    this.Width = 270;
                }
                else
                {
                    this.chkNew.Checked = false;
                    this.Width = 333;
                }
            }
        }
        /// <summary>
        /// 是否使用特殊的Text框显示
        /// </summary>
        public bool IsUseSpeText
        {
            set
            {
                this.isUseSpeText = value;
            }
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="isShow">初始化后是否显示窗口</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Init(bool isShow,string drugType)
        {
            if (frmItem == null)
            {
                frmItem = new frmItemList();
                frmItem.Init(drugType);
                frmItem.Owner = this.FindForm();
                //System.Drawing.Point loc = new Point(this.Left, this.Top + this.txtQuery.Height);
                //frmItem.Location = this.txtQuery.PointToScreen(loc);
                frmItem.SelectItem += new EventHandler(frmItem_SelectItem);
            }
            frmItem.Hide();
            return 1;
        }

        /// <summary>
        /// 设置Text字体显示
        /// </summary>
        /// <param name="isInit"></param>
        public void SetTextFace(bool isInit)
        {
            if (isInit)
            {
                this.isFilter = false;
                if (this.frmItem != null)
                    this.frmItem.FrmVisible = false;
                this.txtQuery.ForeColor = System.Drawing.Color.DarkGray;
                this.txtQuery.Text = "通过编码查询药品";
            }
            else
            {
                this.isFilter = true;
                this.txtQuery.ForeColor = System.Drawing.Color.Black;
                this.txtQuery.Text = "";
            }
        }

        private void txtQueryCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.frmItem != null && this.chkNew.Checked)
            {
                frmItem.Key(e.KeyCode);
                e.Handled = true;
                if (e.KeyCode != Keys.Enter)
                    this.txtQuery.Focus();
            }
            else
            {
                if (this.TextKeyDown != null)
                {
                    this.TextKeyDown(sender, e);
                }
            }
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            if (this.isFilter)
            {
                if (this.chkNew.Checked)
                {
                    #region 处理弹出列表情况
                    if (frmItem == null)
                    {
                        this.Init(true,"E");
                    }
                    else
                    {
                        #region 位置初始化
                                System.Drawing.Point loc = new Point(this.Left, this.Top + this.txtQuery.Height);
                                frmItem.Location = this.txtQuery.PointToScreen(loc);
                        #endregion
                    }

                    if (this.frmItem.FrmVisible)
                    {
                        frmItem.Filter(this.txtQuery.Text);
                    }
                    else
                    {
                        frmItem.FrmVisible = true;
                        frmItem.Filter(this.txtQuery.Text);
                    }
                    this.txtQuery.Focus();
                    #endregion
                }
                else
                {
                    if (this.TextChanged != null)
                    {
                        this.TextChanged(sender, e);
                    }
                }
            }
        }

        private void frmItem_SelectItem(object sender, EventArgs e)
        {
            if (this.SelectItem != null)
            {
                this.SelectItem(sender, System.EventArgs.Empty);
            }
        }

        private void txtQuery_Enter(object sender, EventArgs e)
        {
            if (this.isUseSpeText)
                this.SetTextFace(false);
        }

        private void txtQuery_Leave(object sender, EventArgs e)
        {
            if (this.isUseSpeText)
                this.SetTextFace(true);
        }
    }
}
