using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Nurse.Base
{
    public partial class FpEnter : FarPoint.Win.Spread.FpSpread
    {
        public FpEnter()
        {
            InitializeComponent();
            this.Init();
        }

        public FpEnter(System.ComponentModel.IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            this.Init();
        }

        #region 事件定义
        //		/// <summary>
        //		/// 当前View
        //		/// </summary>
        //		public FarPoint.Win.Spread.SheetView SheetView=new SheetView();
        /// <summary>
        /// 响应键盘事件
        /// </summary>
        public delegate int keyDown(Keys key);
        /// <summary>
        /// 获得下拉列表选中项
        /// </summary>
        public delegate int setItem(Neusoft.FrameWork.Models.NeuObject obj);
        /// <summary>
        /// 键盘事件:Enter,Up,Down,Escape补充中...
        /// </summary>
        public event keyDown KeyEnter;
        /// <summary>
        /// 选择下拉列表项目
        /// </summary>
        public event setItem SetItem;
        #endregion

        #region 私有变量

        /// <summary>
        /// 宽度 
        /// </summary>
        private int intWidth = 150;

        /// <summary>
        /// 长度
        /// </summary>
        private int intHeight = 200;

        /// <summary>
        /// 设定下拉列表默认不选中任何项
        /// </summary>
        private bool selectNone = false;

        /// <summary>
        /// 当cell得到焦点时,是否显示下拉列表
        /// </summary>
        private bool showListWhenOfFocus = false;

        #endregion

        #region 私有函数


        private void FpEnter_ItemSelected(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet, this.ActiveSheet.ActiveColumnIndex);

            if (current == null) return ;
            obj = current.GetSelectedItem();

            if (obj == null)
            {
                return ;
            }

            if (this.SetItem != null)
                this.SetItem(obj);

            current.Visible = false;

            return ;
        }

        /// <summary>
        /// 选择项目列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int FpEnter_SelectItem(Keys key)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet, this.ActiveSheet.ActiveColumnIndex);

            if (current == null) return -1;
            obj = current.GetSelectedItem();

            if (obj == null)
            {
                return -1;
            }

            if (this.SetItem != null)
                this.SetItem(obj);

            current.Visible = false;

            return 0;
        }

        /// <summary>
        /// 对于有项目列表的，自动进行过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpEnter_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet,
                    this.ActiveSheet.ActiveColumnIndex);

                if (current == null) return;

                string Text = e.EditingControl.Text.Trim();

                current.Filter(Text);

                this.ActiveSheet.SetTag(this.ActiveSheet.ActiveRowIndex, this.ActiveSheet.ActiveColumnIndex, null);

                if (current.Visible == false) current.Visible = true;
            }
            catch { }
        }

        /// <summary>
        /// 设置控件位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpEnter_EditModeOn(object sender, EventArgs e)
        {
            try
            {
                this.noVisible();

                Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet,
                    this.ActiveSheet.ActiveColumnIndex);

                if (current == null) return;

                //设置位置
                this.setLocal(current);

                if (this.showListWhenOfFocus && current.Visible == false)
                {
                    current.Filter(this.ActiveSheet.ActiveCell.Text);
                    current.Visible = true;
                }
            }
            catch { }
        }

        /// <summary>
        /// 设置控件位置
        /// </summary>
        /// <param name="obj"></param>
        private void setLocal(Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup obj)
        {
            Control _cell = base.EditingControl;
            if (_cell == null) return;

            int y = _cell.Top + _cell.Height + obj.Height;//+SystemInformation.Border3DSize.Height*2;
            if (y <= this.Height)
                obj.Location = new System.Drawing.Point(_cell.Left, y - obj.Height);
            else
                obj.Location = new System.Drawing.Point(_cell.Left, _cell.Top - obj.Height);

        }

        /// <summary>
        /// 不可见
        /// </summary>
        private void noVisible()
        {
            for (int i = 0; i < this.Lists.Length; i++)
            {
                if (this.Lists[i] != null)
                {
                    this.Lists[i].Visible = false;
                }
            }
        }

        #endregion

        #region 保护成员

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            this.InitFp();

            //this.Sheets.Add(SheetView);
            this.EditChange += new EditorNotifyEventHandler(FpEnter_EditChange);
            this.EditModeOn += new EventHandler(FpEnter_EditModeOn);
        }

        /// <summary>
        /// 初始化Fp,屏蔽特定按键的默认事件
        /// </summary>
        protected void InitFp()
        {
            InputMap im;

            im = base.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = base.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = base.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = base.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            //始终处于可编辑状态
            base.EditModePermanent = true;
            base.EditModeReplace = true;
        }

        /// <summary>
        /// 响应按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.KeyEnter != null)
                        this.KeyEnter(Keys.Enter);
                }
                else if (keyData == Keys.Up)
                {
                    Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet, this.ActiveSheet.ActiveColumnIndex);
                    
                    if (current != null && current.Visible)
                        current.PriorRow();
                    else
                    {
                        if (this.ActiveSheet.ActiveRowIndex > 0)
                            this.ActiveSheet.ActiveRowIndex--;
                    }

                    if (this.KeyEnter != null)
                        this.KeyEnter(Keys.Up);
                }
                else if (keyData == Keys.Down)
                {
                    Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = this.GetCurrentList(this.ActiveSheet, this.ActiveSheet.ActiveColumnIndex);
                    if (current != null && current.Visible)
                        current.NextRow();
                    else
                    {
                        if (this.ActiveSheet.ActiveRowIndex < this.ActiveSheet.RowCount - 1)
                            this.ActiveSheet.ActiveRowIndex++;
                    }

                    if (this.KeyEnter != null)
                        this.KeyEnter(Keys.Down);
                }
                else if (keyData == Keys.Escape)
                {
                    this.noVisible();

                    if (this.KeyEnter != null)
                        this.KeyEnter(Keys.Escape);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region  设置当输入的文字为 "" 时 ,默认不选中任何项
        public bool SelectNone
        {
            get
            {
                return selectNone;
            }
            set
            {
                selectNone = value;
            }
        }
        #endregion

        #region 属性

        /// <summary>
        /// 下拉列表集合
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup[] Lists = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup[10];

        /// <summary>
        /// 当cell得到焦点时,是否显示下拉列表
        /// </summary>		
        public bool ShowListWhenOfFocus
        {
            get { return this.showListWhenOfFocus; }
            set { this.showListWhenOfFocus = value; }
        }

        #endregion

        /// <summary>
        /// 设定所有的下拉列表都不可见 
        /// </summary>
        /// <returns></returns>
        public int SetAllListBoxUnvisible()
        {
            try
            {
                if (Lists != null)
                {
                    foreach (Neusoft.FrameWork.WinForms.Controls.NeuListBox currentList in Lists)
                    {
                        if (currentList != null)
                        {
                            currentList.Visible = false;
                        }
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 设定那一列显示/不显示ID 编码 成功返回 1 失败返回 0 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="IsVisiable"></param>
        /// <returns></returns>
        public int SetIDVisiable(FarPoint.Win.Spread.SheetView view, int col, bool IsVisiable)
        {
            //string name = view.SheetName + "_" + col.ToString();
            //for (int i = 0; i < this.Lists.Length; i++)
            //{
            //    if (this.Lists[i] != null && (this.Lists[i] as Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup).Name == name)
            //    {
            //        Lists[i].IsShowID = IsVisiable;
            //        return 1;
            //    }
            //}
            return 0;

        }

        /// <summary>
        /// 设置下拉列表的宽度和高度 
        /// </summary>
        public void SetWidthAndHeight(int width, int height)
        {
            intWidth = width;
            intHeight = height;
        }

        /// <summary>
        /// 设置cell下来列表
        /// </summary>
        /// <param name="view"></param>
        /// <param name="col"></param>
        /// <param name="al"></param>
        public void SetColumnList(FarPoint.Win.Spread.SheetView view, int col, ArrayList al)
        {
            string name = view.SheetName + "_" + col.ToString();

            for (int i = 0; i < this.Lists.Length - 1; i++)
            {
                if (this.Lists[i] != null && (this.Lists[i] as Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup).Name == name)
                {
                    return;
                }
            }

            Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup obj = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
            obj.Name = name;
            obj.AddItems(al);
            //得到最大列表数
            int Index = -1;

            for (int i = 0; i < this.Lists.Length; i++)
            {
                if (this.Lists[i] == null)
                {
                    Index = i;
                    break;
                }
            }
            if (Index == -1)
            {
                MessageBox.Show("列表已经超过最大数10", "提示");
                return;
            }

            this.Lists[Index] = obj;
            this.Lists[Index].ItemSelected += new EventHandler(FpEnter_ItemSelected);
            //this.Lists[Index].ItemSelected += new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup(FpEnter_SelectItem);
            this.Controls.Add(this.Lists[Index]);
            this.Lists[Index].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lists[Index].Cursor = Cursors.Hand;
            this.Lists[Index].Size = new System.Drawing.Size(intWidth, intHeight);
            this.Lists[Index].Visible = false;
            //this.Lists[Index].SelectNone = selectNone;
        }

        /// <summary>
        /// 获取当前cell是否有下拉列表
        /// </summary>
        /// <param name="view"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup GetCurrentList(FarPoint.Win.Spread.SheetView view, int col)
        {
            string name = view.SheetName + "_" + col.ToString();
            for (int i = 0; i < this.Lists.Length; i++)
            {
                if (this.Lists[i] != null && (this.Lists[i] as Neusoft.FrameWork.WinForms.Controls.NeuListBox).Name == name)
                    return this.Lists[i];
            }
            return null;
        }

    }
}
