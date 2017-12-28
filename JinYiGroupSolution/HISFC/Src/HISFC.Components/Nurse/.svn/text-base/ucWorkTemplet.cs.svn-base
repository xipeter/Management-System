using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Nurse
{
    /// <summary>
    /// [功能描述: 排班管理]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2007-09-18]<br></br>
    /// <修改记录
    ///		修改人='潘铁俊'
    ///		修改时间='2007-09-18'
    ///		修改目的='功能完善'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucWorkTemplet : UserControl
    {
        public ucWorkTemplet()
        {
            InitializeComponent();
            this.SetFpFormat();
            this.neuSpread1.Change+= new FarPoint.Win.Spread.ChangeEventHandler(neuSpread1_Change);
            this.neuSpread1.EditModeOn += new EventHandler(this.neuSpread1_EditModeOn);

           this.neuSpread1.EditModeOff += new EventHandler(this.neuSpread1_EditModeOff);
           this.neuSpread1.EditChange +=  new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_EditChange);
        }

        #region 列
        protected enum cols
        {
            
            /// <summary>
            /// 序号
            /// </summary>
            ID,
            /// <summary>
            /// 科室代码
            /// </summary>
            DeptID,
            /// <summary>
            /// 科室名称
            /// </summary>
            DeptName,
            /// <summary>
            /// 人员代码
            /// </summary>
            EmplCode,
            /// <summary>
            /// 人员名称
            /// </summary>
            EmplName,
            /// <summary>
            /// 午别代码
            /// </summary>
            NoonID,
            /// <summary>
            /// 午别名称
            /// </summary>
            NoonName,
            /// <summary>
            /// 开始时间
            /// </summary>
            BeginTime,
            /// <summary>
            /// 结束时间
            /// </summary>
            EndTime,
            /// <summary>
            /// 人员类别ID
            /// </summary>
            EmplTypeID,
            /// <summary>
            /// 人员类别名称
            /// </summary>
            EmplTypeName,
            /// <summary>
            /// 是否有效
            /// </summary>
            IsValid,
            /// <summary>
            /// 备注
            /// </summary>
            Remark,
            /// <summary>
            /// 原因代码
            /// </summary>
            ReasonID,
            /// <summary>
            /// 原因名称
            /// </summary>
            ReasonName
        }
        #endregion

        #region 域
        /// <summary>
        /// 排班模版类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Nurse.WorkTemplet workTemplet = new Neusoft.HISFC.BizLogic.Nurse.WorkTemplet();
        /// <summary>
        /// 午别列表
        /// </summary>
         private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup noonList= new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();

        /// <summary>
        /// 原因列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup reasonList = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 部门名称
        /// </summary>
        private string deptName;
        /// <summary>
        /// 模板集合
        /// </summary>
        private DataTable dsItems;
        private DataView dv;
        /// <summary>
        /// 列表所在的FP
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread;
        /// <summary>
        /// 当前人员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee currentPerson;
        /// <summary>
        /// 显示星期
        /// </summary>
        private DayOfWeek week = DayOfWeek.Monday;
        /// <summary>
        /// 显示星期
        /// </summary>
        public DayOfWeek Week
        {
            get { return week; }
            set { week = value; }
        }
        public string DeptName
        {
            get
            {
                return this.deptName;
            }
            set
            {
                this.deptName = value;
            }
        }
        /// <summary>
        /// 当前科室
        /// </summary>
        public Neusoft.HISFC.Models.Base.Department Dept
        {
            set
            {
                dept = value;
                if (dept == null)
                {
                    dept = new Neusoft.HISFC.Models.Base.Department();
                }
            }
        }
        

        public Neusoft.HISFC.Models.Base.Employee CurrentPerson
        {
            get
            {
                return this.currentPerson;
            }
            set 
            {
                this.currentPerson = value;
            }
        }
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread FpSpread
        {
            get
            {
                return this.neuSpread1;
            }
        }
        /// <summary>
        /// 当前科室
        /// </summary>
        private Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 当前人员类型
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumEmployeeType emplType = new Neusoft.HISFC.Models.Base.EnumEmployeeType();
        /// <summary>
        /// 预约默认时间段
        /// </summary>
        private int timeZone = 0;
        /// 集合
        /// </summary>
        private ArrayList al;
        /// <summary>
        /// 科室管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager Mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region 初始化

        /// <summary>
        ///  初始化
        /// </summary>        
        /// <param name="w"></param>
        /// <param name="type"></param>
        public void Init(DayOfWeek w)
        {
            this.week = w;

            this.initDataSet();

            this.initNoon();
            this.initStopRn();
            
            this.visible(false);

            this.initFp();  
        }

        /// <summary>
        /// Init DataSet
        /// </summary>
        private void initDataSet()
        {
            dsItems = new DataTable("Templet");

            dsItems.Columns.AddRange(new DataColumn[]
			{
				new DataColumn("ID",System.Type.GetType("System.String")),
				new DataColumn("DeptID",System.Type.GetType("System.String")),
				new DataColumn("DeptName",System.Type.GetType("System.String")),
				new DataColumn("EmplCode",System.Type.GetType("System.String")),
				new DataColumn("EmplName",System.Type.GetType("System.String")),
                new DataColumn("NoonID",System.Type.GetType("System.String")),
                new DataColumn("NoonName",System.Type.GetType("System.String")),
                new DataColumn("BeginTime",System.Type.GetType("System.DateTime")),
				new DataColumn("EndTime",System.Type.GetType("System.DateTime")),
                new DataColumn("EmplTypeID",System.Type.GetType("System.String")),
                new DataColumn("EmplTypeName",System.Type.GetType("System.String")),
                new DataColumn("IsValid",System.Type.GetType("System.Boolean")),
                new DataColumn("Remark",System.Type.GetType("System.String")),
                new DataColumn("ReasonID",System.Type.GetType("System.String")),
				new DataColumn("ReasonName",System.Type.GetType("System.String"))
			});
        }

        /// <summary>
        /// 初始化午别列表
        /// </summary>
        private void initNoon()
        {
            this.noonList.ItemSelected += new EventHandler(noonList_SelectItem);
            this.groupBox1.Controls.Add(this.noonList);
            this.noonList.BackColor = this.label1.BackColor;
            this.noonList.Font = new Font("宋体", 11F);
            this.noonList.BorderStyle = BorderStyle.None;
            this.noonList.Cursor = Cursors.Hand;
            this.noonList.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.noonList.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr =
                            new Neusoft.HISFC.BizLogic.Registration.Noon();
            //得到午别
            al = noonMgr.Query();

            if (al == null)
            {
                MessageBox.Show("获取午别信息时出错!" + Mgr.Err, "提示");
                return;
            }

            this.noonList.AddItems(al);
        }

        /// <summary>
        /// 初始化原因列表
        /// </summary>
        private void initStopRn()
        {
            this.reasonList.ItemSelected += new EventHandler(lbStopRn_SelectItem);
            this.groupBox1.Controls.Add(this.reasonList);
            this.reasonList.BackColor = this.label1.BackColor;
            this.reasonList.Font = new Font("宋体", 11F);
            this.reasonList.BorderStyle = BorderStyle.None;
            this.reasonList.Cursor = Cursors.Hand;
            this.reasonList.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.reasonList.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            //得到医生类别
            al = Mgr.QueryConstantList("StopReason");
            if (al == null)
            {
                MessageBox.Show("获取原因时出错!" + Mgr.Err, "提示");
                return;
            }

            this.reasonList.AddItems(al);
        }

        /// <summary>
        /// 初始化farpoint
        /// </summary>
        private void initFp()
        {
            FarPoint.Win.Spread.InputMap im;

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        #endregion

        #region 查找

        /// <summary>
        /// 根据午别代码得到午别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getNoonNameByID(string id)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.noonList.NeuItems)
            {
                if (obj.ID == id) return obj.Name;
            }
            return id;
        }
        /// <summary>
        /// 根据午别名称得到午别代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getNoonIDByName(string name)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.noonList.NeuItems)
            {
                if (obj.Name == name) return obj.ID;
            }
            return "";
        }
        /// <summary>
        /// 获取午别结束时间
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private DateTime getNoonEndDate(string ID)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.noonList.NeuItems)
            {
                if (obj.ID == ID) return (obj as Neusoft.HISFC.Models.Base.Noon).EndTime;
            }
            return DateTime.MinValue;
        }
        private string GetEmplTypeName(string emplTypeID)
        {
            Neusoft.HISFC.Models.Base.EmployeeTypeEnumService emplTypeService = new Neusoft.HISFC.Models.Base.EmployeeTypeEnumService();
            return emplTypeService.GetName((Neusoft.HISFC.Models.Base.EnumEmployeeType)Enum.Parse(typeof(Neusoft.HISFC.Models.Base.EnumEmployeeType), emplTypeID));
        }
        #endregion

        #region Farpoint操作

        /// <summary>
        /// 设置下拉列表位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_EditModeOn(object sender, EventArgs e)
        {

            this.neuSpread1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            this.neuSpread1.EditingControl.DoubleClick += new EventHandler(EditingControl_DoubleClick);

            if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)cols.NoonName ||
                this.neuSpread1_Sheet1.ActiveColumnIndex == (int)cols.ReasonName)
            {
                this.setLocation();
                this.visible(false);
            }
            else
            { this.visible(false); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {

                string cellText = this.neuSpread1_Sheet1.GetText(this.neuSpread1_Sheet1.ActiveRowIndex, this.neuSpread1_Sheet1.ActiveColumnIndex);

                if (cellText.ToUpper() == "FALSE")
                {
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime].BackColor = Color.MistyRose;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime].BackColor = Color.MistyRose;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime].BackColor = SystemColors.Window;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime].BackColor = SystemColors.Window;
                }

        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                this.neuSpread1.EditingControl.KeyDown -= new KeyEventHandler(EditingControl_KeyDown);
                this.neuSpread1.EditingControl.DoubleClick -= new EventHandler(EditingControl_DoubleClick);
            }
            catch { }

        }

        /// <summary>
        /// 检索下来列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            int col = this.neuSpread1_Sheet1.ActiveColumnIndex;
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;

            string text = this.neuSpread1_Sheet1.ActiveCell.Text.Trim();
            text = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(text, "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\");
             if (col == (int)cols.NoonName)
            {
                this.noonList.Filter(text);
                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.ReasonName)
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.ReasonName].Text= "";
                this.reasonList.Filter(text);
                if (this.groupBox1.Visible == false) this.visible(true);
            }
        }

        #endregion  

        #region 其他设置

        /// <summary>
        /// 回车处理
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                #region enter
                if (this.neuSpread1.ContainsFocus)
                {
                    int col = this.neuSpread1_Sheet1.ActiveColumnIndex;

                    if (col == (int)cols.DeptName)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.EmplName, false);
                    }
                    else if (col == (int)cols.EmplName)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.NoonName, false);
                    }
                    else if (col == (int)cols.NoonName)
                    {
                        if (this.selectNoon() == -1) return false;
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime, false);
                    }
                    else if (col == (int)cols.BeginTime)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime, false);
                    }
                    else if (col == (int)cols.EndTime)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.IsValid, false);
                    }
                    else if (col == (int)cols.IsValid)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.Remark, false);
                    }
                    else if (col == (int)cols.Remark)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.ReasonName, false);
                    }
                    else if (col == (int)cols.ReasonName)
                    {
                        if (this.selectStopRn() == -1) return false;

                        if (this.neuSpread1_Sheet1.ActiveRowIndex != this.neuSpread1_Sheet1.RowCount - 1)
                        {
                            this.neuSpread1_Sheet1.ActiveRowIndex++;
                            this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptName, false);
                        }
                        else
                        {
                            this.Add();
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Up)
            {
                #region up
                if (this.neuSpread1.ContainsFocus)
                {
                    if (this.groupBox1.Visible)
                    { this.priorRow(); }
                    else
                    {
                        int CurrentRow = neuSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow > 0)
                        {
                            neuSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                            neuSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Down)
            {
                #region down
                if (this.neuSpread1.ContainsFocus)
                {
                    if (this.groupBox1.Visible)
                    { this.nextRow(); }
                    else
                    {
                        int CurrentRow = neuSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow >= 0 && CurrentRow <= neuSpread1_Sheet1.RowCount - 2)
                        {
                            neuSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                            neuSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Escape)
            {
                this.visible(false);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                FarPoint.Win.Spread.CellType.GeneralEditor t = neuSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;
                if (t.SelectionStart == 0 && t.SelectionLength == 0)
                {
                    int row = 0, column = 0;
                    if (neuSpread1_Sheet1.ActiveColumnIndex == (int)cols.DeptName && neuSpread1_Sheet1.ActiveRowIndex != 0)
                    {
                        row = neuSpread1_Sheet1.ActiveRowIndex - 1;
                        column = (int)cols.ReasonName;
                    }
                    else if (neuSpread1_Sheet1.ActiveColumnIndex != (int)cols.DeptName)
                    {
                        row = neuSpread1_Sheet1.ActiveRowIndex;
                        column = this.getPriorVisibleColumn(this.neuSpread1_Sheet1.ActiveColumnIndex);

                    }
                    if (column != -1)
                    {
                        //屏蔽压缩显示报错

                        if ((column == (int)cols.DeptName || column == (int)cols.EmplName ||
                            column == (int)cols.NoonName) && dv[row].Row.RowState != DataRowState.Added)
                        {
                            return;
                        }

                        neuSpread1_Sheet1.SetActiveCell(row, column, true);
                    }
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                FarPoint.Win.Spread.CellType.GeneralEditor t = neuSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;

                if (t.Text == null || t.Text == "" || t.SelectionStart == t.Text.Length)
                {
                    int row = neuSpread1_Sheet1.RowCount - 1, column = neuSpread1_Sheet1.ColumnCount - 1;
                    if (neuSpread1_Sheet1.ActiveColumnIndex == column && neuSpread1_Sheet1.ActiveRowIndex != row)
                    {
                        row = neuSpread1_Sheet1.ActiveRowIndex + 1;

                            column = (int)cols.DeptName;
       
                    }
                    else if (neuSpread1_Sheet1.ActiveColumnIndex != column)
                    {
                        row = neuSpread1_Sheet1.ActiveRowIndex;

                        column = this.getNextVisibleColumn(this.neuSpread1_Sheet1.ActiveColumnIndex);
                    }

                    if (column != -1)
                    {
                        //屏蔽压缩显示报错
                        if ((column == (int)cols.DeptName || column == (int)cols.EmplName ||
                            column == (int)cols.NoonName) && dv[row].Row.RowState != DataRowState.Added)
                        {
                            return;
                        }

                        neuSpread1_Sheet1.SetActiveCell(row, column, true);
                    }
                }
            }
        }

        private void EditingControl_DoubleClick(object sender, EventArgs e)
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;

            if (row < 0) return;

            int col = this.neuSpread1_Sheet1.ActiveColumnIndex;

            if (col == (int)cols.BeginTime || col == (int)cols.EndTime)
            {
                //显示行状态
                this.showColor(row);
            }
            else if (col == (int)cols.NoonName)
            {
                string deptId, emplCode, noonID;

                deptId = this.neuSpread1_Sheet1.GetText(row, (int)cols.DeptID);
                emplCode = this.neuSpread1_Sheet1.GetText(row, (int)cols.EmplCode);
                noonID = this.neuSpread1_Sheet1.GetText(row, (int)cols.NoonID);

                //将整个午别都置为相同状态
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptID) == deptId &&
                        this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplCode) == emplCode &&
                        this.neuSpread1_Sheet1.GetText(i, (int)cols.NoonID) == noonID)
                    {
                        //显示行状态
                        this.showColor(i);
                    }
                }
            }
        }
        /// <summary>
        /// 设置行显示颜色--
        /// </summary>
        /// <param name="row"></param>
        private void showColor(int row)
        {
            string empltype=this.neuSpread1_Sheet1.GetText(row, (int)cols.EmplTypeID);
            //显示行状态
            if (empltype=="C")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = SystemColors.Window;
            }
            else if (empltype=="T")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.MistyRose;
            }
            else if (empltype=="P")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.MintCream;
            }
            else if (empltype=="F")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.Moccasin;
            }
            else if (empltype=="N")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.MidnightBlue;
            }
            else if (empltype=="D")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.MediumSpringGreen;
            }
            else if (empltype == "O")
            {
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EmplTypeID].BackColor = Color.NavajoWhite;
            }
        }
        /// <summary>
        /// 设置行显示颜色（全部）
        /// </summary>
        private void showColor()
        {
            int rowCount = this.neuSpread1_Sheet1.RowCount;
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    this.showColor(i);
                }
            }
        }

        private int getNextVisibleColumn(int col)
        {
            int count = this.neuSpread1_Sheet1.Columns.Count;

            while (col < count - 1)
            {
                col++;

                if (this.neuSpread1_Sheet1.Columns[col].Visible)
                {
                    return col;
                }
            }

            return -1;
        }

        private int getPriorVisibleColumn(int col)
        {
            while (col > 0)
            {
                col--;

                if (this.neuSpread1_Sheet1.Columns[col].Visible)
                {
                    return col;
                }
            }

            return -1;
        }


        #region 有关午别的函数和事件
        /// <summary>
        /// 选择午别
        /// </summary>
        /// <param name="sender"></param>
        ///<param name="e"></param>
        private void noonList_SelectItem(object sender, EventArgs e)
        {
            this.selectNoon();
            this.visible(false);
            return;
        }
       
        #endregion

        #endregion

        #region 下拉控件功能
        /// <summary>
        /// 设置groupBox1的显示位置
        /// </summary>
        /// <returns></returns>
        private void setLocation()
        {
            Control cell = this.neuSpread1.EditingControl;
            if (cell == null) return;

            int y = neuSpread1.Top + cell.Top + cell.Height + this.groupBox1.Height + 7;
            if (y <= this.Height)
            {
                if (neuSpread1.Left + cell.Left + this.groupBox1.Width + 20 <= this.Width)
                {
                    this.groupBox1.Location = new Point(neuSpread1.Left + cell.Left + 20, y - this.groupBox1.Height);
                }
                else
                {
                    this.groupBox1.Location = new Point(this.Width - this.groupBox1.Width - 10, y - this.groupBox1.Height);
                }
            }
            else
            {
                if (neuSpread1.Left + cell.Left + this.groupBox1.Width + 20 <= this.Width)
                {
                    this.groupBox1.Location = new Point(neuSpread1.Left + cell.Left + 20, neuSpread1.Top + cell.Top - this.groupBox1.Height - 7);
                }
                else
                {
                    this.groupBox1.Location = new Point(this.Width - this.groupBox1.Width - 10, neuSpread1.Top + cell.Top - this.groupBox1.Height - 7);
                }
            }
        }

        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        /// <param name="visible"></param>
        private void visible(bool visible)
        {
            if (visible == false)
            { this.groupBox1.Visible = false; }
            else
            {
                int col = this.neuSpread1_Sheet1.ActiveColumnIndex;
                if (col == (int)cols.NoonName)
                {
                    this.noonList.BringToFront();
                    this.groupBox1.Visible = true;
                } 
                else if (col == (int)cols.ReasonName)
                {
                    this.reasonList.BringToFront();
                    this.groupBox1.Visible = true;
                }
            }
        }
        /// <summary>
        /// 前一行
        /// </summary>
        private void nextRow()
        {
            int col = this.neuSpread1_Sheet1.ActiveColumnIndex;
             if (col == (int)cols.NoonName)
            {
                this.noonList.NextRow();
            }
            else if (col == (int)cols.ReasonName)
            {
                this.reasonList.NextRow();
            }        
        }
        /// <summary>
        /// 上一行
        /// </summary>
        private void priorRow()
        {
            int col = this.neuSpread1_Sheet1.ActiveColumnIndex;
            if (col == (int)cols.NoonName)
            {
                this.noonList.PriorRow();
            }
            else if (col == (int)cols.ReasonName)
            {
                this.reasonList.PriorRow();
            } 
        }
        /// <summary>
        /// 选择午别
        /// </summary>
        /// <returns></returns>
        private int selectNoon()
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.neuSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();

                obj = this.noonList.GetSelectedItem();
                if (obj == null) return -1;

                this.neuSpread1_Sheet1.SetValue(row, (int)cols.NoonID, obj.ID, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.NoonName, obj.Name, false);

                if (this.timeZone == 0)
                {
                    //设定默认时间为午别的起始、结束时间
                    this.neuSpread1_Sheet1.SetValue(row, (int)cols.BeginTime,
                            (obj as Neusoft.HISFC.Models.Base.Noon).StartTime, false);
                    this.neuSpread1_Sheet1.SetValue(row, (int)cols.EndTime,
                            (obj as Neusoft.HISFC.Models.Base.Noon).EndTime, false);
                }
                else//模板默认从下找到的第一个结束时间为起始时间,结束时间+1
                {
                    this.SetTimeZone(row, (Neusoft.HISFC.Models.Base.Noon)obj);
                }
                this.visible(false);
            }

            return 0;
        }
        /// <summary>
        /// 设置排班默认时间段
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="noon"></param>
        /// <returns></returns>
        private int SetTimeZone(int currentRow, Neusoft.HISFC.Models.Base.Noon noon)
        {
            string emplCode = this.neuSpread1_Sheet1.GetText(currentRow, (int)cols.EmplCode);
            string deptID = this.neuSpread1_Sheet1.GetText(currentRow, (int)cols.DeptID);
            DateTime begin = DateTime.MinValue;
            object obj;

            if (emplCode == "") return 0;

            for (int i = currentRow; i >= 0; i--)
            {
                if (i == currentRow) continue;

                if (this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplCode) == emplCode &&
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.NoonID) == noon.ID &&
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptID) == deptID)
                {
                    obj = this.neuSpread1_Sheet1.GetValue(i, (int)cols.EndTime);
                    if (obj == null) continue;

                    begin = DateTime.Parse(obj.ToString());
                    break;
                }
            }

            if (begin != DateTime.MinValue && begin.TimeOfDay < noon.EndTime.TimeOfDay)
            {
                this.neuSpread1_Sheet1.SetValue(currentRow, (int)cols.BeginTime, begin, false);
                begin = begin.AddHours(this.timeZone);

                if (begin.TimeOfDay > noon.EndTime.TimeOfDay)
                {
                    begin = noon.EndTime;
                }
                this.neuSpread1_Sheet1.SetValue(currentRow, (int)cols.EndTime, begin, false);
            }
            else
            {
                begin = noon.StartTime;
                this.neuSpread1_Sheet1.SetValue(currentRow, (int)cols.BeginTime, begin, false);

                begin = begin.AddHours(this.timeZone);
                if (begin.TimeOfDay > noon.EndTime.TimeOfDay)
                {
                    begin = noon.EndTime;
                }
                this.neuSpread1_Sheet1.SetValue(currentRow, (int)cols.EndTime, begin, false);
            }

            return 0;
        }
  
        /// <summary>
        /// 选择列表原因
        /// </summary>
        /// <returns></returns>
        private int selectStopRn()
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.neuSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj = this.reasonList.GetSelectedItem();
                if (obj == null) return -1;

                this.neuSpread1_Sheet1.SetValue(row, (int)cols.ReasonName, obj.Name, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.ReasonID, obj.ID, false);
                this.visible(false);
            }
            else
            {
                string StopRnID = this.neuSpread1_Sheet1.GetText(row, (int)cols.ReasonID);

                if (StopRnID == null || StopRnID == "")
                    this.neuSpread1_Sheet1.SetValue(row, (int)cols.ReasonName, "", false);
            }

            return 0;
        }

        /// <summary>
        /// 选择午别
        /// </summary>
        /// <param name="sender"></param>
        ///<param name="e"></param>
        private void lbNoon_SelectItem(object sender, EventArgs e)
        {
            this.selectNoon();
            this.visible(false);
            return;
        }
        
        /// <summary>
        /// 选择原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbStopRn_SelectItem(object sender, EventArgs e)
        {
            this.selectStopRn();
            this.visible(false);

            return;
        }
       
        #endregion

        #region 共有函数

        /// <summary>
        /// 按科室查询一日排班记录
        /// </summary>
        /// <param name="deptID"></param>
        public void Query(string deptID)
        {
            this.al = this.workTemplet.Query(week, deptID);
            if (al == null)
            {
                MessageBox.Show("查询排班模板信息出错!" + this.workTemplet.Err, "提示");
                return;
            }

            dsItems.Rows.Clear();

            try
            {
                foreach (Neusoft.HISFC.Models.Nurse.WorkTemplet templet in al)
                {

                    dsItems.Rows.Add(new object[]
					{
						templet.ID,						
						templet.Dept.ID,
						templet.Dept.Name,
						templet.Employee.ID,
						templet.Employee.Name,
                        templet.Noon.ID,
						this.getNoonNameByID(templet.Noon.ID),
						templet.Begin,
						templet.End,
						templet.EmplType.ID,
                        this.GetEmplTypeName(templet.EmplType.ID),//templet.EmplType.Name,
                        templet.IsValid,
						templet.Memo,
						templet.Reason.ID,
						templet.Reason.Name });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("查询排班信息生成DataSet时出错!" + e.Message, "提示");
                return;
            }
            dsItems.AcceptChanges();

            dv = dsItems.DefaultView;
            dv.AllowDelete = true;
            dv.AllowEdit = true;
            dv.AllowNew = true;
            //this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            this.neuSpread1_Sheet1.DataSource = dv;
            this.neuSpread1_Sheet1.DataMember = "Templet";

            this.SetFpFormat();


            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    this.showColor(i);
                }
            }

        }

        /// <summary>
        /// 设置Farpoint显示格式
        /// </summary>
        private void SetFpFormat()
        {
            FarPoint.Win.Spread.CellType.NumberCellType numbCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numbCellType.DecimalPlaces = 0;
            numbCellType.MaximumValue = 9999;
            numbCellType.MinimumValue = 0;

            FarPoint.Win.Spread.CellType.TextCellType txtOnly = new FarPoint.Win.Spread.CellType.TextCellType();
            txtOnly.ReadOnly = true;
            FarPoint.Win.Spread.CellType.DateTimeCellType dtCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType cbCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dtCellType.UserDefinedFormat = "HH:mm";

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

                #region ""
            this.neuSpread1_Sheet1.Columns[(int)cols.ID].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)cols.DeptID].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)cols.NoonID].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)cols.ReasonID].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplTypeID].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)cols.BeginTime].CellType = dtCellType;
            this.neuSpread1_Sheet1.Columns[(int)cols.EndTime].CellType = dtCellType;
            this.neuSpread1_Sheet1.Columns[(int)cols.IsValid].CellType = cbCellType;

            this.neuSpread1_Sheet1.Columns[(int)cols.DeptName].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplName].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplTypeName].CellType = txtOnly;
            //this.neuSpread1_Sheet1.Columns[(int)cols.BeginTime].CellType = txtOnly;
            //this.neuSpread1_Sheet1.Columns[(int)cols.EndTime].CellType = txtOnly;

            this.neuSpread1_Sheet1.Columns[(int)cols.DeptName].BackColor = System.Drawing.Color.LightGray;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplName].BackColor = System.Drawing.Color.LightGray;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplTypeName].BackColor = System.Drawing.Color.LightGray;
            //this.neuSpread1_Sheet1.Columns[(int)cols.BeginTime].BackColor = System.Drawing.Color.LightGray;
            //this.neuSpread1_Sheet1.Columns[(int)cols.EndTime].BackColor = System.Drawing.Color.LightGray; 

            this.neuSpread1_Sheet1.Columns[(int)cols.DeptName].Width = 90F;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplName].Width = 60F;
            this.neuSpread1_Sheet1.Columns[(int)cols.EmplTypeName].Width = 60F;
            this.neuSpread1_Sheet1.Columns[(int)cols.NoonName].Width = 40F;
            this.neuSpread1_Sheet1.Columns[(int)cols.BeginTime].Width = 90F;
            this.neuSpread1_Sheet1.Columns[(int)cols.EndTime].Width = 90F;
            this.neuSpread1_Sheet1.Columns[(int)cols.Remark].Width = 40F;
            this.neuSpread1_Sheet1.Columns[(int)cols.ReasonName].Width = 80F;
                #endregion
        }
        /// <summary>
        /// 抑止重复显示
        /// </summary>
        private void Span()
        {
            ///
            int colLastDept = 0;
            int colLastEmpl = 0;
            int colLastNoon = 0;
            int rowCnt = this.neuSpread1_Sheet1.RowCount;

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

            for (int i = 0; i < rowCnt; i++)
            {
                this.showColor(i);

                if (i > 0 && this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptName) != this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName))
                {
                    if (i - colLastDept > 1)
                    {
                        this.neuSpread1_Sheet1.Models.Span.Add(colLastDept, (int)cols.DeptName, i - colLastDept, 1);
                    }

                    colLastDept = i;
                }

                //最后一行处理
                if (i > 0 && i == rowCnt - 1 && this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptName) == this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName))
                {
                    this.neuSpread1_Sheet1.Models.Span.Add(colLastDept, (int)cols.DeptName, i - colLastDept + 1, 1);
                }

                if (
                    i > 0 &&
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplName) != this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.EmplName))
                {
                    if (i - colLastEmpl > 1)
                    {
                        this.neuSpread1_Sheet1.Models.Span.Add(colLastEmpl, (int)cols.EmplName, i - colLastEmpl, 1);
                    }
                    colLastEmpl = i;
                }

                //最后一行
                if (i > 0 &&
                    i == rowCnt - 1 && this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplName) == this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.EmplName))
                {
                    this.neuSpread1_Sheet1.Models.Span.Add(colLastEmpl, (int)cols.EmplName, i - colLastEmpl + 1, 1);
                }

                ///午别
                ///
                if (i > 0 &&
                    (this.neuSpread1_Sheet1.GetText(i, (int)cols.NoonName) != this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.NoonName) ||
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptName) != this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName) ||
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplName) != this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.EmplName)))
                {
                    if (i - colLastNoon > 1)
                    {
                        this.neuSpread1_Sheet1.Models.Span.Add(colLastNoon, (int)cols.NoonName, i - colLastNoon, 1);
                    }
                    colLastNoon = i;
                }
                //最后一行
                if (i > 0 && i == rowCnt - 1 &&
                    (this.neuSpread1_Sheet1.GetText(i, (int)cols.NoonName) == this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.NoonName) ||
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.DeptName) == this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName) ||
                    this.neuSpread1_Sheet1.GetText(i, (int)cols.EmplName) == this.neuSpread1_Sheet1.GetText(i - 1, (int)cols.EmplName)))
                {
                    this.neuSpread1_Sheet1.Models.Span.Add(colLastNoon, (int)cols.NoonName, i - colLastNoon + 1, 1);
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Add()
        {
            if (this.CurrentPerson == null)
            {
                MessageBox.Show("请选择排班人员");
                return;
            }

            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);

            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;

            DateTime current = this.workTemplet.GetDateTimeFromSysDateTime().Date;

            this.neuSpread1_Sheet1.SetValue(row, (int)cols.ID, this.workTemplet.GetSequence("Nurse.WorkTemplet.ID"), false);

            //默认同上一个科室
            //if (row > 0)
            //{
            //    this.neuSpread1_Sheet1.SetValue(row, (int)cols.DeptID,this.neuSpread1_Sheet1.GetText(row - 1, (int)cols.DeptID), false);
            //    this.neuSpread1_Sheet1.SetValue(row, (int)cols.DeptName,this.neuSpread1_Sheet1.GetText(row - 1, (int)cols.DeptName), false);


                this.neuSpread1_Sheet1.SetValue(row, (int)cols.EmplCode,this.CurrentPerson.ID, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.EmplName,this.CurrentPerson.Name, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.EmplTypeID, this.CurrentPerson.EmployeeType.ID, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.EmplTypeName,this.CurrentPerson.EmployeeType.Name, false);
            //}
            //else//row == 0 
            //{
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.DeptID, this.CurrentPerson.Dept.ID, false);
                this.neuSpread1_Sheet1.SetValue(row, (int)cols.DeptName, this.DeptName, false);
            //}

            this.neuSpread1_Sheet1.SetValue(row, (int)cols.NoonID, "", false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.NoonName, "", false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.BeginTime, current, false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.EndTime, current, false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.IsValid, true, false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.Remark, "", false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.ReasonID, "", false);
            this.neuSpread1_Sheet1.SetValue(row, (int)cols.ReasonName, "", false);

            this.neuSpread1.Focus();

            string deptId = "";

            deptId = this.neuSpread1_Sheet1.GetText(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptID);


            if (deptId == null || deptId == "")
            {
                this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptName, false);
            }
            else
            {

                    this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.EmplName, false);
  
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Del()
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            if (row < 0 || this.neuSpread1_Sheet1.RowCount == 0) return;

            if (MessageBox.Show("是否删除该条排班?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.neuSpread1.Focus();
                return;
            }

            this.neuSpread1.StopCellEditing();

            this.neuSpread1_Sheet1.Rows.Remove(row, 1);

            this.neuSpread1.Focus();
        }
        /// <summary>
        /// 删除全部
        /// </summary>
        public void DelAll()
        {
            if (this.neuSpread1_Sheet1.RowCount == 0) return;

            if (MessageBox.Show("是否删除全部排班?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.neuSpread1.Focus();
                return;
            }

            this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

            this.neuSpread1.Focus();
        }
        /// <summary>
        /// 保存
        /// </summary>
        public int Save()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                dsItems.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }
            //增加
            DataTable dtAdd = dsItems.GetChanges(DataRowState.Added);
            //修改
            DataTable dtModify = dsItems.GetChanges(DataRowState.Modified);
            //删除
            DataTable dtDel = dsItems.GetChanges(DataRowState.Deleted);

            //验证
            if (Valid(dtAdd) == -1) return -1;
            if (Valid(dtModify) == -1) return -1;
            //转为实体集合
            ArrayList alAdd = this.GetChanges(dtAdd);
            if (alAdd == null) return -1;
            ArrayList alModify = this.GetChanges(dtModify);
            if (alModify == null) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //SQLCA.BeginTransaction();

            this.workTemplet.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string rtnText = "";
            if (dtDel != null)
            {
                dtDel.RejectChanges();

                if (this.SaveDel(this.workTemplet, dtDel, ref rtnText) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(rtnText, "提示");
                    return -1;
                }
            }

            if (this.SaveAdd(this.workTemplet, alAdd, ref rtnText) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(rtnText, "提示");
                return -1;
            }

            if (this.SaveModify(this.workTemplet, alModify, ref rtnText) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(rtnText, "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            dsItems.AcceptChanges();
            this.SetFpFormat();
            this.showColor();
            return 0;
        }
        /// <summary>
        /// 是否修改数据？
        /// </summary>
        /// <returns></returns>
        public bool IsChange()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                dsItems.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }

            DataTable dt = dsItems.GetChanges();

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 保存增加的记录
        /// </summary>
        /// <param name="templetMgr"></param>
        /// <param name="alAdd"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveAdd(Neusoft.HISFC.BizLogic.Nurse.WorkTemplet templetMgr, ArrayList alAdd, ref string Err)
        {
            try
            {
                foreach (Neusoft.HISFC.Models.Nurse.WorkTemplet templet in alAdd)
                {
                    if (templetMgr.Insert(templet) == -1)
                    {
                        Err = templetMgr.Err;
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 保存修改记录
        /// </summary>
        /// <param name="templetMgr"></param>
        /// <param name="alModify"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveModify(Neusoft.HISFC.BizLogic.Nurse.WorkTemplet templetMgr, ArrayList alModify, ref string Err)
        {
            try
            {
                foreach (Neusoft.HISFC.Models.Nurse.WorkTemplet templet in alModify)
                {
                    int returnValue = 0;

                    returnValue = templetMgr.Delete(templet.ID);

                    if (returnValue == -1)
                    {
                        Err = templetMgr.Err;
                        return -1;
                    }

                    if (templetMgr.Insert(templet) == -1)
                    {
                        Err = templetMgr.Err;
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 保存删除记录
        /// </summary>
        /// <param name="templetMgr"></param>
        /// <param name="dvDel"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveDel(Neusoft.HISFC.BizLogic.Nurse.WorkTemplet templetMgr, DataTable dvDel, ref string Err)
        {
            try
            {
                foreach (DataRow row in dvDel.Rows)
                {
                    if (templetMgr.Delete(row["ID"].ToString()) == -1)
                    {
                        Err = templetMgr.Err;
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 将表中数据转换为实体集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private ArrayList GetChanges(DataTable dt)
        {
            this.al = new ArrayList();

            if (dt != null)
            {
                try
                {
                    DateTime current = DateTime.Parse("2000-01-01 00:00:00");
                    DateTime bookingTime;

                    foreach (DataRow row in dt.Rows)
                    {
                        Neusoft.HISFC.Models.Nurse.WorkTemplet templet = new Neusoft.HISFC.Models.Nurse.WorkTemplet();

                        templet.ID = row["ID"].ToString();
                        templet.Week = this.week;
                        templet.Dept.ID = row["DeptID"].ToString();
                        templet.Dept.Name = row["DeptName"].ToString();
                        templet.Employee.ID = row["EmplCode"].ToString();
                        templet.Employee.Name = row["EmplName"].ToString();
                        templet.EmplType.ID = row["EmplTypeID"].ToString();
                        templet.Begin = (DateTime)row["BeginTime"];
                        templet.End = (DateTime)row["EndTime"];
                        templet.Memo= row["Remark"].ToString();
                        templet.Noon.ID = row["NoonID"].ToString();
                        templet.Noon.Name = row["NoonName"].ToString();
                        templet.Reason.ID = row["ReasonID"].ToString();
                        templet.Reason.Name = row["ReasonName"].ToString();
                        templet.IsValid = Boolean.Parse(row["IsValid"].ToString());
                        templet.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                        this.al.Add(templet);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("生成实体集合时出错!" + e.Message, "提示");
                    return null;
                }
            }

            return al;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int Valid(DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DeptID"].ToString() == null || row["DeptID"].ToString() == "")
                    {
                        MessageBox.Show("排班科室不能为空!", "提示");
                        return -1;
                    }

   
                        if (row["EmplCode"].ToString() == null || row["EmplCode"].ToString() == "")
                        {
                            MessageBox.Show("人员不能为空!", "提示");
                            return -1;
                        }

                    if (row["BeginTime"] == null || row["BeginTime"].ToString().Trim() == "" ||
                        row["EndTime"] == null || row["EndTime"].ToString().Trim() == "")
                    {
                        MessageBox.Show("请输入预约时间段!", "提示");
                        return -1;
                    }
                    if (DateTime.Parse(row["BeginTime"].ToString()).TimeOfDay > DateTime.Parse(row["EndTime"].ToString()).TimeOfDay)
                    {
                        MessageBox.Show("开始时间不能大于结束时间!", "提示");
                        return -1;
                    }
                    if (row["IsValid"].ToString() == "True")
                    {
                        if (DateTime.Parse(row["BeginTime"].ToString()).TimeOfDay == DateTime.Parse(row["EndTime"].ToString()).TimeOfDay)
                        {
                            MessageBox.Show("开始时间不能等于结束时间!", "提示");
                            return -1;
                        }
                    }

                    string noon = row["NoonName"].ToString();//this.getNoonIDByName(row["NoonID"].ToString());
                    if (noon == "")
                    {
                        MessageBox.Show("排班午别不能为空!", "提示");
                        return -1;
                    }
                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(row["Remark"].ToString(), 50) == false)
                    {
                        MessageBox.Show("备注不能超过25个汉字!", "提示");
                        return -1;
                    }
                    row["Remark"] = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(row["Remark"].ToString(), "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\", "*", "^", "@", "!");
                }
                if (this.valid() < 0) return -1;

            }

            return 0;
        }
        /// <summary>
        /// 核对有没有重复时间段
        /// </summary>
        /// <returns></returns>
        private int valid()
        {

            if (this.neuSpread1_Sheet1.RowCount <= 0) return -1;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount - 1; i++)
            {


                //if (this.neuSpread1_Sheet1.GetValue(i, (int)cols.IsValid).ToString() == "True")
                //{
                    DateTime beginDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(i, (int)cols.BeginTime));
                    DateTime endDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(i, (int)cols.EndTime));
                    for (int j = i + 1; j < this.neuSpread1_Sheet1.RowCount; j++)
                    {
                        //if (this.neuSpread1_Sheet1.GetValue(j, (int)cols.IsValid).ToString() == "True")
                        //{
                            DateTime beginDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(j, (int)cols.BeginTime));
                            DateTime endDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(j, (int)cols.EndTime));
                            if ((this.neuSpread1_Sheet1.GetValue(i, (int)cols.EmplCode).ToString() == this.neuSpread1_Sheet1.GetValue(j, (int)cols.EmplCode).ToString()) 
                                //&& (this.neuSpread1_Sheet1.GetValue(i, (int)cols.NoonName).ToString() == this.neuSpread1_Sheet1.GetValue(j, (int)cols.NoonName).ToString()) 
                                && ((((beginDTj.TimeOfDay <= beginDTi.TimeOfDay && beginDTj.TimeOfDay >= endDTi.TimeOfDay)
                                || (beginDTj.TimeOfDay <= beginDTi.TimeOfDay  && endDTj.TimeOfDay >= endDTi.TimeOfDay)
                                || (beginDTi.TimeOfDay <= beginDTj.TimeOfDay  && beginDTi.TimeOfDay >= endDTj.TimeOfDay) 
                                || (endDTi.TimeOfDay <= beginDTj.TimeOfDay && endDTi.TimeOfDay >= endDTj.TimeOfDay))
                                && this.neuSpread1_Sheet1.GetValue(i, (int)cols.IsValid).ToString() == this.neuSpread1_Sheet1.GetValue(j, (int)cols.IsValid).ToString()))
                                || ((this.neuSpread1_Sheet1.GetValue(i, (int)cols.IsValid).ToString() !="True" || "True"!= this.neuSpread1_Sheet1.GetValue(j, (int)cols.IsValid).ToString()) && (this.neuSpread1_Sheet1.GetValue(i, (int)cols.NoonName).ToString() == this.neuSpread1_Sheet1.GetValue(j, (int)cols.NoonName).ToString()) 
                                   )
                                )
                            {
                                MessageBox.Show("第" + (j + 1).ToString() + "行排班时间有误，与"+(i+1)+"行冲突，\r\n请检查是否有时间交叉，\r\n或是已存在该排班,但不是有效排班");
                                return -1;
                            }
                        //}
                    }
                //}

            }
            return 0;
        }
        #endregion

    }
}
