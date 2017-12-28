using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Collections;
using System.Drawing;

namespace Neusoft.HISFC.Components.Preparation
{
    public partial class FPItem : Neusoft.FrameWork.WinForms.Controls.NeuSpread
    {
        public FPItem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            InitializeComponent();

            this.ucItemList1 = new ucItemList();
        }

        public FPItem(System.ComponentModel.IContainer container)
        {
            //
            // Windows.Forms 类撰写设计器支持所必需的
            //
            container.Add(this);

            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        private HISFC.Components.Preparation.ucItemList ucItemList1;

        /// <summary>
        /// 项目选择触发
        /// </summary>
        public event System.EventHandler SelectItem;
        /// <summary>
        /// 按键
        /// </summary>
        public event System.EventHandler Key;

        #region 列表控制变量
        /// <summary>
        /// 下拉列表集合
        /// </summary>
        private ArrayList Lists = null;
        /// <summary>
        /// 是否使用 简单列表
        /// </summary>
        private bool listBoxEnabled = false;
        /// <summary>
        /// 弹出列表索引数组
        /// </summary>
        private ArrayList sheetList;
        /// <summary>
        /// 列表宽度
        /// </summary>
        private int intWidth = 150;
        /// <summary>
        /// 列表高度
        /// </summary>
        private int intHeight = 200;
        /// <summary>
        /// 需弹出列表行索引
        /// </summary>
        private int[] listRows = null;
        /// <summary>
        /// 列表宽度
        /// </summary>
        public int ListWidth
        {
            set
            {
                this.intWidth = value;
            }
        }
        /// <summary>
        /// 列表高度
        /// </summary>
        public int ListHeight
        {
            set
            {
                this.intHeight = value;
            }
        }

        /// <summary>
        /// 需弹出列表行索引
        /// </summary>
        public int[] ListRows
        {
            set
            {
                this.listRows = value;
            }
        }
        #endregion

        #region 药品列表控制

        /// <summary>
        /// 弹出药品列表列索引
        /// </summary>
        private int phaListColumnIndex = 0;

        /// <summary>
        /// 是否使用药品列表
        /// </summary>
        private bool phaListEnabled = true;

        /// <summary>
        /// 药品类别
        /// </summary>
        private string drugType = "";

        /// <summary>
        /// 弹出药品列表列索引
        /// </summary>
        public int PhaListColumnIndex
        {
            set
            {
                this.phaListColumnIndex = value;
            }
        }

        /// <summary>
        /// 是否使用药品列表
        /// </summary>
        public bool PhaListEnabled
        {
            set
            {
                this.phaListEnabled = value;
            }
        }

        /// <summary>
        /// 药品类别
        /// </summary>
        public string DrugType
        {
            get
            {
                return this.drugType;
            }
            set
            {
                this.drugType = value;
            }
        }

        #endregion

        #region 列表初始化
        /// <summary>
        /// 设置 在当前活动SheetView内 简单下拉列表显示
        /// </summary>
        /// <param name="sheetView">欲显示的SheetView</param>
        /// <param name="al">列表数组</param>
        /// <param name="iColumnIndex">需显示本列表的列</param>
        public void SetColumnList(FarPoint.Win.Spread.SheetView sheetView, ArrayList al, params int[] iColumnIndex)
        {
            if (this.Lists == null)
            {
                this.Lists = new ArrayList();
            }

            int iListIndex = this.Lists.Count;

            this.listBoxEnabled = true;

            InputMap im;
            im = base.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            Neusoft.FrameWork.WinForms.Controls.PopUpListBox obj = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
            obj.AddItems(al);
            this.Controls.Add(obj);
            obj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            obj.Size = new System.Drawing.Size(this.intWidth, this.intHeight);
            obj.Visible = false;

            this.Lists.Add(obj);

            string str = "";
            foreach (int i in iColumnIndex)
            {
                str = string.Format("{0}|{1}{2}", iListIndex.ToString(), sheetView.SheetName, i.ToString());
                if (this.sheetList == null)
                {
                    this.sheetList = new ArrayList();
                }
                else
                {
                    if (this.JudgeListRow(i))   //原来在该列设置过弹出列表 则覆盖原有实现
                    {
                        string tempStr = sheetView.SheetName + i.ToString();
                        string tempListStr = "";
                        foreach (string info in this.sheetList)
                        {
                            if (info.Substring(info.IndexOf("|") + 1) == tempStr)
                            {
                                tempListStr = info;
                                break;
                            }
                        }

                        if (tempListStr != "")
                        {
                            this.sheetList.Remove(tempListStr);
                        }
                    }
                }
                this.sheetList.Add(str);
            }
        }

        /// <summary>
        /// 药品列表初始化
        /// </summary>
        public void Init()
        {
            if (this.ucItemList1 == null)
                this.ucItemList1 = new ucItemList();

            if (this.drugType == null || this.drugType == "")
            {
                this.ucItemList1.Init();
            }
            else
            {
                this.ucItemList1.Init(null, this.drugType);
            }

            this.ucItemList1.SelectItem += new EventHandler(ucItemList1_SelectItem);

            this.Controls.Add(this.ucItemList1);

            this.ucItemList1.BringToFront();
            this.ucItemList1.Visible = false;
        }

        #endregion

        #region 列表位置设定
        /// <summary>
        /// 药品弹出列表位置设定
        /// </summary>
        protected void SetListLocation()
        {
            Control _cell = base.EditingControl;
            if (_cell == null)
            {
                return;
            }

            if (this.ActiveSheet.ActiveColumnIndex == this.phaListColumnIndex)
            {
                //int y = _cell.Top + _cell.Height + this.ucItemList1.Height + 5;

                //if (y <= this.Height)       
                //{
                //    this.ucItemList1.Location = new Point(_cell.Left + 20, y - this.ucItemList1.Height);
                //}
                //else                       
                //{
                //    this.ucItemList1.Location = new Point(_cell.Left + 20, _cell.Top - this.ucItemList1.Height - 5);
                //}

                int topHeight = _cell.Top;
                int bottomHeight = this.Height - _cell.Top - _cell.Height;

                if (bottomHeight > this.ucItemList1.Height)        //可显示在下部
                {
                    this.ucItemList1.Location = new Point(_cell.Left + 20, _cell.Top + _cell.Height + 5);
                }
                else if (topHeight > this.ucItemList1.Height)      //可显示在上部
                {
                    this.ucItemList1.Location = new Point(_cell.Left + 20, _cell.Top - this.ucItemList1.Height - 5);
                }
                else                                               //平行显示
                {
                    this.ucItemList1.Location = new Point(_cell.Left + _cell.Width + 10,_cell.Top);
                }
            }
            return;
        }

        /// <summary>
        /// 设置控件位置
        /// </summary>
        /// <param name="obj">弹出列表控件</param>
        private void SetListLocation(Neusoft.FrameWork.WinForms.Controls.PopUpListBox obj)
        {
            Control _cell = base.EditingControl;
            if (_cell == null) return;
            int y = _cell.Top + _cell.Height + obj.Height;
            if (y <= this.Height)
                obj.Location = new System.Drawing.Point(_cell.Left, y - obj.Height);
            else
            {
                if (_cell.Top > obj.Height)
                    obj.Location = new System.Drawing.Point(_cell.Left, _cell.Top - obj.Height);
                else
                    obj.Location = new System.Drawing.Point(_cell.Left, _cell.Top + _cell.Height);
            }
        }

        #endregion

        #region 列表控制
        /// <summary>
        /// 根据字符串获取对应列表索引
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>成功返回对应列表索引 失败返回-1</returns>
        private int GetListIndex(string str)
        {
            string strTemp = "";
            foreach (string info in this.sheetList)
            {
                strTemp = info.Substring(info.IndexOf("|") + 1);
                if (strTemp == str)
                {
                    strTemp = info.Substring(0, info.IndexOf("|"));
                    return Neusoft.FrameWork.Function.NConvert.ToInt32(strTemp);
                }
            }
            return -1;
        }
        /// <summary>
        /// 不可见
        /// </summary>
        public void VisibleAllList()
        {
            for (int i = 0; i < this.Lists.Count; i++)
            {
                if (this.Lists[i] != null)
                {
                    (this.Lists[i] as Neusoft.FrameWork.WinForms.Controls.PopUpListBox).Visible = false;
                }
            }
        }
        /// <summary>
        /// 判断是否在指定行允许弹出列表
        /// </summary>
        /// <param name="iRow">指定行索引</param>
        /// <returns>允许返回True 否则返回False</returns>
        private bool JudgeListRow(int iRow)
        {
            if (this.Lists == null || !this.listBoxEnabled)
                return false;
            if (this.listRows == null)
                return true;
            foreach (int i in this.listRows)
            {
                if (i == iRow)
                    return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 列跳转
        /// </summary>
        /// <param name="newColumnIndex">需跳转目的列</param>
        /// <param name="newRow">是否跳转新行</param>
        public void JumpColumn(int newColumnIndex, bool newRow)
        {
            if (this.ucItemList1.Visible)
                return;
            if (newRow)
            {
                if (this.ActiveSheet.ActiveRowIndex == this.ActiveSheet.Rows.Count - 1)
                    this.ActiveSheet.AddRows(this.ActiveSheet.Rows.Count, 1);
                this.ActiveSheet.ActiveRowIndex++;
            }

            if (newColumnIndex > this.ActiveSheet.Columns.Count - 1)
                newColumnIndex = this.ActiveSheet.Columns.Count - 1;
            this.ActiveSheet.ActiveColumnIndex = newColumnIndex;
        }

        /// <summary>
        /// 从下拉列表获取所选择项目
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject GetItemFormList()
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

            string str = this.ActiveSheet.SheetName + this.ActiveSheet.ActiveColumnIndex.ToString();
            int iIndex = this.GetListIndex(str);
            if (iIndex == -1 || iIndex >= this.Lists.Count)
                return null;
            Neusoft.FrameWork.WinForms.Controls.PopUpListBox current = null;
            current = this.Lists[iIndex] as Neusoft.FrameWork.WinForms.Controls.PopUpListBox;
            if (current != null && current.Visible)
            {
                if (current.GetSelectedItem(out obj) == -1)
                    return null;
                current.Visible = false;
                return obj;
            }
            return null;
        }


        private void ucItemList1_SelectItem(object sender, EventArgs e)
        {
            if (this.SelectItem != null)
            {
                this.SelectItem(sender, e);
            }
        }


        protected override void OnEditChange(FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.phaListEnabled && this.ucItemList1 != null)
            {
                if (e.Column == this.phaListColumnIndex && this.ucItemList1 != null)
                {
                    this.SetListLocation();

                    this.ucItemList1.BringToFront();
                    if (!this.ucItemList1.Visible)
                        this.ucItemList1.Visible = true;

                    this.ucItemList1.Filter(this.ActiveSheet.ActiveCell.Text);
                }
            }
            if (this.listBoxEnabled && this.Lists != null && this.Lists.Count > 0)
            {
                if (this.JudgeListRow(e.Row))
                {
                    string str = this.ActiveSheet.SheetName + e.Column.ToString();
                    int iIndex = this.GetListIndex(str);
                    if (iIndex != -1)
                    {
                        Neusoft.FrameWork.WinForms.Controls.PopUpListBox current = null;
                        current = this.Lists[iIndex] as Neusoft.FrameWork.WinForms.Controls.PopUpListBox;
                        if (current != null)
                        {
                            current.Filter(e.EditingControl.Text.Trim());
                            if (current.Visible == false)
                                current.Visible = true;
                        }
                    }
                }
            }
            base.OnEditChange(e);
        }
        protected override void OnEditModeOn(EventArgs e)
        {
            if (this.phaListEnabled && this.ucItemList1 != null && this.ActiveSheet.ActiveRowIndex == this.phaListColumnIndex)
            {
                this.SetListLocation();

                if (this.ActiveSheet.ActiveColumnIndex != this.phaListColumnIndex)
                    this.ucItemList1.Visible = false;
            }
            if (this.listBoxEnabled && this.Lists != null && this.Lists.Count > 0)
            {
                this.VisibleAllList();

                if (this.JudgeListRow(this.ActiveSheet.ActiveRowIndex))
                {
                    if (this.ActiveSheet.ActiveColumn.Visible)
                    {
                        #region 当前列为显示状态时 才进行处理
                        string str = this.ActiveSheet.SheetName + this.ActiveSheet.ActiveColumnIndex.ToString();
                        int iIndex = this.GetListIndex(str);
                        if (iIndex != -1)
                        {
                            Neusoft.FrameWork.WinForms.Controls.PopUpListBox current = null;
                            current = this.Lists[iIndex] as Neusoft.FrameWork.WinForms.Controls.PopUpListBox;
                            if (current != null)
                            {
                                //设置位置
                                this.SetListLocation(current);
                                if (current.Visible == false)
                                {
                                    current.Visible = true;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            base.OnEditModeOn(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.phaListEnabled && this.ucItemList1 != null && this.ucItemList1.Visible && this.ContainsFocus && this.ActiveSheet.ActiveColumnIndex == this.phaListColumnIndex)
            {
                #region 处理药品列表
                if (keyData == Keys.Escape)
                {
                    base.ProcessCmdKey(ref msg, keyData);

                    this.ucItemList1.Key(keyData);

                    return true;
                }
                if (keyData == Keys.Enter)
                {
                    this.ucItemList1.Key(keyData);
                }
                else if (keyData == Keys.Up || keyData == Keys.Down)
                {
                    if (this.ucItemList1.Visible)
                    {
                        this.ucItemList1.Key(keyData);
                        return true;
                    }
                }
                #endregion
            }
            else if (this.listBoxEnabled && this.Lists != null && this.Lists.Count > 0)
            {
                #region 下拉列表
                if (keyData == Keys.Up || keyData == Keys.Down)
                {
                    #region 上下键
                    string str = this.ActiveSheet.SheetName + this.ActiveSheet.ActiveColumnIndex.ToString();
                    int iIndex = this.GetListIndex(str);
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox current = null;
                    if (iIndex != -1)
                        current = this.Lists[iIndex] as Neusoft.FrameWork.WinForms.Controls.PopUpListBox;
                    if (current != null && current.Visible)
                    {

                    }
                    else
                    {
                        if (keyData == Keys.Up)
                            this.ActiveSheet.ActiveRowIndex--;
                        else
                            this.ActiveSheet.ActiveRowIndex++;
                    }
                    #endregion
                }
                else if (keyData == Keys.Enter)
                {
                    this.obj_SelectItem(keyData);
                }
                #endregion
            }
            if (this.Key != null)
                this.Key(keyData, System.EventArgs.Empty);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnComboDropDown(EditorNotifyEventArgs e)
        {
            if (e.EditingControl == null)
                return;

            base.OnComboDropDown(e);
        }

        private int obj_SelectItem(Keys key)
        {
            Neusoft.FrameWork.Models.NeuObject obj = this.GetItemFormList();
            if (obj != null)
            {
                if (this.SelectItem != null)
                {
                    this.SelectItem(obj, System.EventArgs.Empty);
                    this.VisibleAllList();
                }
            }
            return 0;
        }
    }
}
