using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
namespace Neusoft.HISFC.Components.HealthRecord
{
    /// <summary>
    /// NeuListTextBox<br></br>
    /// [功能描述: 带下拉列表的文本输入筐]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-5]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    class NeuListTextBox : Neusoft.FrameWork.WinForms.Controls.NeuTextBox
    {
        #region  私有变量
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        bool keyEnterVisiable = false;//进入控件时下拉列表即可见
        Neusoft.FrameWork.Models.NeuObject selectObj; //当前选中的项目
        private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        bool IsExist = false; //是否已经加载
        private System.Windows.Forms.Control parentControl; //父级控件
        int LocaltionX; //位置X
        int LocaltionY;//位置Y
        #endregion

        #region 属性
        [Description("进入控件时下拉列表即可见")]
        public bool EnterVisiable
        {
            get
            {
                return keyEnterVisiable;
            }
            set
            {
                keyEnterVisiable = false;
            }
        }
        [Description("下拉筐的宽度")]
        public int ListBoxWidth
        {
            get
            {
                return listBox.Width;
            }
            set
            {
                listBox.Width = value;
            }
        }
        [Description("下拉筐的宽度")]
        public int ListBoxHeight
        {
            get
            {
                return listBox.Height;
            }
            set
            {
                listBox.Height = value;
            }
        }
        [Description("模糊查询")]
        public bool OmitFilter
        {
            get
            {
                return listBox.OmitFilter;
            }
            set
            {
                listBox.OmitFilter = value;
            }
        }
        /// <summary>
        /// 设置Tag
        /// </summary>
        [Description("设置Tag")]
        public new object Tag
        {
            get
            {
                return base.Tag;
            }
            set
            {
                base.Tag = value;
                if (base.Tag != null)
                {
                    this.Text = objHelper.GetName(base.Tag.ToString());
                }

            }
        }
        #endregion

        #region 共有有函数
        /// <summary>
        /// 筛选事件
        /// </summary>
        public NeuListTextBox()
        {
            listBox.Width = this.Width;
            listBox.Height = 100;
            //parentControl = this;
            this.TextChanged += new EventHandler(NeuListTextBox_TextChanged);
            this.Enter += new EventHandler(NeuListTextBox_Enter);
            this.KeyDown += new KeyEventHandler(NeuListTextBox_KeyDown);

            //Controls.Add(listBox);
            //隐藏
            listBox.Hide();
            //设置边框
            listBox.BorderStyle = BorderStyle.FixedSingle;
            //listBox.BringToFront();
            //单击事件
            listBox.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(listBox_SelectItem); //new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(ICDListBox_SelectItem);
        }

        /// <summary>
        /// 加载项目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int AddItems(ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            objHelper.ArrayObject = list;
            return listBox.AddItems(list);
        }
        #endregion

        #region  私有函数
        int listBox_SelectItem(Keys key)
        {
            return GetSelectItem();
        }
        int GetSelectItem()
        {
            int rtn = listBox.GetSelectedItem(out selectObj);
            if (selectObj == null)
            {
                return -1;
            }
            if (selectObj.ID != "")
            {
                base.Tag = selectObj.ID;
                this.Text = selectObj.Name;
            }
            else
            {
                this.listBox.Tag = null;
            }
            listBox.Focus(); //获得焦点
            this.listBox.Visible = false;
            this.Focus();
            return rtn;
        }
        /// <summary>
        /// 进入控件时 下拉列表是否可见
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NeuListTextBox_Enter(object sender, EventArgs e)
        {
            this.listBox.Visible = this.EnterVisiable;
            AddControl();
        }
        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NeuListTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetLocation();
                this.listBox.Visible = true;
                this.listBox.Filter(this.Text.Trim());
            }
            catch { }
        }
        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NeuListTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                listBox.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBox.NextRow();
            }
        }
        /// <summary>
        /// 加载控件
        /// </summary>
        void AddControl()
        {
            if (!IsExist)
            {
                LocaltionX = 0;
                LocaltionY = 0;
                parentControl = GetParent(this);
                parentControl.Controls.Add(listBox);
                IsExist = true;

                if (listBox.Width < this.Width)
                {
                    listBox.Width = this.Width;
                }
                if (this.parentControl.Width < LocaltionX + listBox.Width)
                {
                    //if ((parentControl.Width - listBox.Width - LocaltionX) > 0)
                    //{
                    //    LocaltionX = LocaltionX - (parentControl.Width - listBox.Width - LocaltionX);
                    //}
                    //else
                    //{
                    LocaltionX = LocaltionX - System.Math.Abs(listBox.Width + LocaltionX - parentControl.Width);
                    //}
                }

                if (this.parentControl.Height < LocaltionY + listBox.Height)
                {
                    if (parentControl.Height - listBox.Height - this.Height > 0)
                    {
                        LocaltionY = LocaltionY  - listBox.Height - this.Height - 2;
                    }
                }
            }
            listBox.BringToFront();
        }
        /// <summary>
        /// 获取父级控件
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private Control GetParent(Control control)
        {
            try
            {
                if (control.Parent != null)
                {
                    LocaltionX += control.Location.X;
                    LocaltionY += control.Location.Y;
                    return GetParent(control.Parent);
                }
                else
                {
                    return control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return control;
            }
        }
        /// <summary>
        /// 设置位置
        /// </summary>
        void SetLocation()
        {
            listBox.Location = new System.Drawing.Point(LocaltionX + 2, LocaltionY + Height + 2);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (listBox.Visible)
                {
                    GetSelectItem();
                }
            }
            if (keyData == Keys.Escape)
            {
                listBox.Visible = false;
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion
    }
}
