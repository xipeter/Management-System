using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Operation
{
    public partial class ucTabular : UserControl
    {
        public ucTabular()
        {
            InitializeComponent();
        }
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();    

        private Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
        
        private Neusoft.HISFC.Models.Base.Employee var = null;

        private ArrayList al, persons, kinds;
        private Neusoft.FrameWork.Models.NeuObject obj;
        private Neusoft.HISFC.Models.Registration.Tabulation tabular = null;
        private Neusoft.HISFC.Models.Registration.WorkType defaultType
        {
            get
            {
                Neusoft.HISFC.Models.Registration.WorkType temp = new Neusoft.HISFC.Models.Registration.WorkType();
                temp.ID = "001";
                temp.Name = "全班";
                temp.ClassID = "01";

                return temp;
            }
        }

        /// <summary>
        /// 初始化,必调用
        /// </summary>
        /// <returns></returns>
        public int Init(Neusoft.HISFC.Models.Base.Employee basevar)
        {
            InitFp();
            this.lbType.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbType_SelectItem);
            this.panelList.Visible = false;
            var = basevar;


            return 0;
        }

        /// <summary>
        /// 设置FarPoint格式
        /// </summary>
        /// <returns></returns>
        private int InitFp()
        {
            fpSpread1_Sheet1.ColumnHeader.RowCount = 2;
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 2, 1);
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 0].Text = "序号";

            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 1, 2, 1);
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 1].Text = "姓名";

            //fpSpread1_Sheet1.ColumnHeader.Cells[0,2].Text="2005-12-31";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 2].Text = "星期一";

            fpSpread1_Sheet1.ColumnHeader.Cells[1, 3].Text = "星期二";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 4].Text = "星期三";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 5].Text = "星期四";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 6].Text = "星期五";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7, 1, 7].ForeColor = Color.Red;
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 7].Text = "星期六";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 8, 1, 8].ForeColor = Color.Red;
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 8].Text = "星期日";

            //fpSpread1_Sheet1.Columns[7].ForeColor=Color.Red;
            //fpSpread1_Sheet1.Columns[8].ForeColor=Color.Red;
            fpSpread1_Sheet1.Columns[0].Locked = true;
            fpSpread1_Sheet1.Columns[1].Locked = true;
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            InputMap im;

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            return 0;
        }
        /// <summary>
        /// 获取下周一的日期
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        private DateTime GetNextMonday(DateTime currentDate)
        {
            DateTime nextDate = DateTime.MinValue;

            switch ((int)currentDate.DayOfWeek)
            {
                case 0://周日
                    nextDate = currentDate.Date.AddDays(1);
                    break;
                case 1://周一
                    nextDate = currentDate.Date;
                    break;
                case 2://周二
                    nextDate = currentDate.Date.AddDays(6);
                    break;
                case 3:
                    nextDate = currentDate.Date.AddDays(5);
                    break;
                case 4:
                    nextDate = currentDate.Date.AddDays(4);
                    break;
                case 5:
                    nextDate = currentDate.Date.AddDays(3);
                    break;
                case 6:
                    nextDate = currentDate.Date.AddDays(2);
                    break;
            }

            return nextDate;
        }
        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            DateTime current = this.dataManager.GetDateTimeFromSysDateTime();//当前时间
            DateTime next = GetNextMonday(current);

            if (fpSpread1_Sheet1.RowCount > 0) fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.RowCount);

            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = next.ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = next.AddDays(1).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = next.AddDays(2).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = next.AddDays(3).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = next.AddDays(4).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = next.AddDays(5).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text = next.AddDays(6).ToString("yyyy-MM-dd");

            this.lbDate.Text = "排班时间:" + current.ToString("yyyy-MM-dd");
            this.Tag = null;

            return 0;
        }
        /// <summary>
        /// 查询当前日期下一周的排班安排
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public int QueryCurrent(string deptID)
        {
            Clear();
            Query(deptID);
            return 0;
        }
        /// <summary>
        /// 查询科室排班信息
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private int Query(string deptID)
        {
            if (fpSpread1_Sheet1.RowCount > 0) fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.RowCount);
            //安排序号
            string arrangeID = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text).ToString("yyyyMMdd") +
                DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text).ToString("yyyyMMdd");
            try
            {
                al = tabMgr.Query(arrangeID, deptID);
                if (al == null)   
                {
                    MessageBox.Show(tabMgr.Err, "提示");
                    return -1;
                }
                //查询本科出勤类别
                kinds = tabMgr.Query(deptID);
                if (kinds == null) kinds = new ArrayList();
                this.lbType.AddItems(kinds);

                //没有排班信息,显示本科人员
                this.QueryPersonByDept(deptID);

                //显示排班信息,没法保持原来排班顺序和人员
                AddTabular();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            //记录当前科室
            this.Tag = deptID;

            return 0;
        }
        /// <summary>
        /// 按排班序号查询已排班信息
        /// </summary>
        /// <param name="arrangeID"></param>
        /// <param name="deptID"></param>
        public void Query(string arrangeID, string deptID)
        {
            if (fpSpread1_Sheet1.RowCount > 0) fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.RowCount - 1);
            DateTime begin = DateTime.Parse(arrangeID.Substring(0, 4) + "-" + arrangeID.Substring(4, 2) + "-" +
                arrangeID.Substring(6, 2));

            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = begin.ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = begin.AddDays(1).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = begin.AddDays(2).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = begin.AddDays(3).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = begin.AddDays(4).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = begin.AddDays(5).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text = begin.AddDays(6).ToString("yyyy-MM-dd");

            this.lbDate.Text = "排班时间:" + dataManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd");
            Query(deptID);
            this.Tag = deptID;
        }
        /// <summary>
        /// 添加科室下人员
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private int QueryPersonByDept(string deptID)
        {
            if (var.EmployeeType.ID.ToString() != "N")//非护士给非护士人员排班
            {
                persons = personMgr.QueryEmployeeExceptNurse( deptID );
            }
            else//护士只能给护士排班
            {
                persons = personMgr.QueryEmployee( Neusoft.HISFC.Models.Base.EnumEmployeeType.N, deptID );
            }

            if (persons != null)
            {
                foreach (Neusoft.HISFC.Models.Base.Employee p in persons)
                {
                    fpSpread1_Sheet1.Rows.Add(fpSpread1_Sheet1.RowCount, 1);
                    int index = fpSpread1_Sheet1.RowCount - 1;
                    this.fpSpread1_Sheet1.Rows[index].Height = 23;
                    fpSpread1_Sheet1.SetValue(index, 0, index + 1, false);//序号
                    fpSpread1_Sheet1.SetValue(index, 1, "   " + p.Name, false);//人员名称
                    fpSpread1_Sheet1.SetTag(index, 1, p);
                    fpSpread1_Sheet1.SetValue(index, 9, 2 * index, false);//排列顺序

                    for (int i = 2; i < 9; i++)
                    {
                        this.fpSpread1_Sheet1.SetValue(index, i, this.defaultType.Name, false);
                        string color = "";
                        color = this.getColor(this.defaultType.ID);
                        if (color != "")
                            fpSpread1_Sheet1.Cells[index, i].ForeColor = Color.FromArgb(int.Parse(color));

                        fpSpread1_Sheet1.SetTag(index, i, this.defaultType);
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 添加排班信息
        /// </summary>
        /// <returns></returns>
        private int AddTabular()
        {
            int column;

            foreach (Neusoft.HISFC.Models.Registration.Tabulation t in al)
            {
                for (int index = 0; index < fpSpread1_Sheet1.RowCount; index++)
                {
                    if ((fpSpread1_Sheet1.GetTag(index, 1) as Neusoft.HISFC.Models.Base.Employee).ID == t.EmplID)
                    {
                        column = (int)t.Workdate.DayOfWeek;
                        if (column == 0) column = 7;
                        fpSpread1_Sheet1.SetValue(index, column + 1, t.Kind.Name, false);

                        string color = "";
                        color = this.getColor(t.Kind.ID);
                        if (color != "")
                            fpSpread1_Sheet1.Cells[index, column + 1].ForeColor = Color.FromArgb(int.Parse(color));

                        if (t.Memo != "") this.fpSpread1_Sheet1.SetNote(index, column + 1, t.Memo);
                        fpSpread1_Sheet1.SetTag(index, column + 1, t.Kind);
                        fpSpread1_Sheet1.SetValue(index, 9, t.SortID, false);

                        break;
                    }
                }
            }

            SortInfo[] sort = new SortInfo[1];
            sort[0] = new SortInfo(9, true, System.Collections.Comparer.Default);
            fpSpread1_Sheet1.SortRange(0, 1, fpSpread1_Sheet1.RowCount, 9, true, sort);

            return 0;
        }
        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getColor(string id)
        {
            if (this.lbType.Items == null)
                this.lbType.Items = new ArrayList();

            foreach (Neusoft.HISFC.Models.Registration.WorkType w in this.lbType.Items)
            {
                if (w.ID == id)
                    return w.ForeColor;
            }
            return "";
        }

        #region public
        /// <summary>
        /// 下一周
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public int NextWeek()
        {
            if (this.Tag == null || this.Tag.ToString() == "") return -1;

            DateTime end = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text);
            end = end.AddDays(1);
            SetTitle(end);

            Query(this.Tag.ToString());

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        private void SetTitle(DateTime begin)
        {
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = begin.ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = begin.AddDays(1).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = begin.AddDays(2).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = begin.AddDays(3).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = begin.AddDays(4).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = begin.AddDays(5).ToString("yyyy-MM-dd");
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text = begin.AddDays(6).ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 上一周
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public int PriorWeek()
        {
            if (this.Tag == null || this.Tag.ToString() == "") return -1;

            DateTime end = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text);
            end = end.AddDays(-7);
            SetTitle(end);

            Query(this.Tag.ToString());

            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            p.PrintPreview(this);
        }
        /// <summary>
        /// 上移
        /// </summary>
        public void Up()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (row < 1) return;

            int priorSort = int.Parse(this.fpSpread1_Sheet1.GetText(row - 1, 9));
            int sortID = int.Parse(this.fpSpread1_Sheet1.GetText(row, 9));

            int temp = sortID;
            sortID = priorSort;
            priorSort = temp;

            fpSpread1_Sheet1.SetValue(row, 9, sortID, false);
            fpSpread1_Sheet1.SetValue(row - 1, 9, priorSort, false);
            //重新排序
            SortInfo[] sort = new SortInfo[1];
            sort[0] = new SortInfo(9, true, System.Collections.Comparer.Default);
            fpSpread1_Sheet1.SortRange(0, 1, fpSpread1_Sheet1.RowCount, 9, true, sort);

            fpSpread1_Sheet1.ActiveRowIndex = row - 1;

        }
        /// <summary>
        /// 下移
        /// </summary>
        public void Down()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (row > fpSpread1_Sheet1.RowCount - 2) return;

            int sortID = int.Parse(this.fpSpread1_Sheet1.GetText(row, 9));
            int nextSort = int.Parse(this.fpSpread1_Sheet1.GetText(row + 1, 9));

            int temp = sortID;
            sortID = nextSort;
            nextSort = temp;

            fpSpread1_Sheet1.SetValue(row, 9, sortID, false);
            fpSpread1_Sheet1.SetValue(row + 1, 9, nextSort, false);
            //重新排序
            SortInfo[] sort = new SortInfo[1];
            sort[0] = new SortInfo(9, true, System.Collections.Comparer.Default);
            fpSpread1_Sheet1.SortRange(0, 1, fpSpread1_Sheet1.RowCount, 9, true, sort);

            fpSpread1_Sheet1.ActiveRowIndex = row + 1;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            //验证
            if (valid() == -1) return -1;

            //安排序号
            string arrangeID = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text).ToString("yyyyMMdd") +
                DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text).ToString("yyyyMMdd");
            string deptID = this.Tag.ToString();//科室代码

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.personMgr.Connection);
            //t.BeginTransaction();

            tabMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                //删除已经保存的排班记录
                if (tabMgr.DeleteTabular(arrangeID, deptID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.tabMgr.Err, "提示");
                    return -1;
                }
                //添加排班记录
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    //员工代码
                    string emplID = (fpSpread1_Sheet1.GetTag(i, 1) as Neusoft.HISFC.Models.Base.Employee).ID;

                    for (int j = 2; j < 9; j++)
                    {
                        if (fpSpread1_Sheet1.GetTag(i, j) != null)
                        {
                            //排班日期
                            DateTime workDate = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, j].Text);

                            tabular = new Neusoft.HISFC.Models.Registration.Tabulation();
                            tabular.Kind = (Neusoft.HISFC.Models.Registration.WorkType)fpSpread1_Sheet1.GetTag(i, j);
                            //
                            tabular.arrangeID = arrangeID;//安排序号
                            tabular.DeptID = deptID;//科室
                            tabular.EmplID = emplID;
                            tabular.Workdate = workDate;
                            tabular.OperID = var.ID;
                            tabular.Memo = fpSpread1_Sheet1.GetNote(i, j);
                            tabular.SortID = 2 * i;

                            if (tabMgr.Insert(tabular) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(tabMgr.Err, "提示");
                                return -1;
                            }
                        }
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("安排成功!", "提示");

            return 0;
        }
        /// <summary>
        /// 验证有效性
        /// </summary>
        /// <returns></returns>
        private int valid()
        {
            if (fpSpread1_Sheet1.RowCount == 0) return -1;
            if (this.Tag == null || this.Tag.ToString() == "")
            {
                MessageBox.Show("请选择排班科室!", "提示");
                return -1;
            }

            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    //有排班记录，才能保存
                    if (fpSpread1_Sheet1.GetTag(i, j) != null) return 0;
                }
            }

            MessageBox.Show("没有排班记录, 不能保存!", "提示");

            return -1;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public void Memo()
        {
            if (this.Tag == null || this.Tag.ToString() == "")
            {
                MessageBox.Show("请选择排班科室!", "提示");
                return;
            }
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (fpSpread1_Sheet1.RowCount == 0) return;


        }
        /// <summary>
        /// 获取备注
        /// </summary>
        /// <returns></returns>
        public string getMemo()
        {
            if (this.Tag == null || this.Tag.ToString() == "")
            {
                MessageBox.Show("请选择排班科室!", "提示");
                return "-1";
            }
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (fpSpread1_Sheet1.RowCount == 0) return "-1";

            if (this.fpSpread1_Sheet1.GetTag(row, fpSpread1_Sheet1.ActiveColumnIndex) == null) return "-1";
            return this.fpSpread1_Sheet1.GetNote(row, this.fpSpread1_Sheet1.ActiveColumnIndex);
        }
        /// <summary>
        /// 设置备注
        /// </summary>
        /// <param name="Text"></param>
        public void setMemo(string Text)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) return;
            this.fpSpread1_Sheet1.SetNote(fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex, Text);
        }
        /// <summary>
        /// 获取当前排班信息
        /// </summary>
        /// <returns></returns>
        public ArrayList getTabular()
        {
            al = new ArrayList();
            //安排序号
            string arrangeID = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text).ToString("yyyyMMdd") +
                DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text).ToString("yyyyMMdd");
            string deptID = this.Tag.ToString();//科室代码

            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                //员工代码
                string emplID = (fpSpread1_Sheet1.GetTag(i, 1) as Neusoft.HISFC.Models.Base.Employee).ID;

                for (int j = 2; j < 9; j++)
                {
                    if (fpSpread1_Sheet1.GetTag(i, j) != null)
                    {
                        //排班日期
                        DateTime workDate = DateTime.Parse(fpSpread1_Sheet1.ColumnHeader.Cells[0, j].Text);

                        tabular = new Neusoft.HISFC.Models.Registration.Tabulation();
                        tabular.Kind = (Neusoft.HISFC.Models.Registration.WorkType)fpSpread1_Sheet1.GetTag(i, j);
                        //
                        tabular.arrangeID = arrangeID;//安排序号
                        tabular.DeptID = deptID;//科室
                        tabular.EmplID = emplID;
                        tabular.Workdate = workDate;
                        tabular.Memo = fpSpread1_Sheet1.GetNote(i, j);
                        tabular.SortID = i;

                        al.Add(tabular);
                    }
                }
            }
            return al;
        }
        /// <summary>
        /// 调用组套
        /// </summary>
        /// <param name="tabulars"></param>
        public void LoadTemplate(ArrayList tabulars)
        {
            if (this.Tag == null || this.Tag.ToString() == "") return;
            if (fpSpread1_Sheet1.RowCount > 0) fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.RowCount);
            //显示本科人员
            this.QueryPersonByDept(this.Tag.ToString());
            al = tabulars;
            //显示排班信息,没法保持原来排班顺序和人员
            AddTabular();
        }
        #endregion

        #region FarPoint操作
        private void fpSpread1_EditModeOn(object sender, System.EventArgs e)
        {
            SetLocation();
            this.panelList.Visible = false;
        }
        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column >= 2 && e.Column <= 8)
            {
                string text = fpSpread1_Sheet1.ActiveCell.Text;
                fpSpread1_Sheet1.Cells[e.Row, e.Column].Tag = null;

                this.lbType.Filter(text.Trim());
                if (this.panelList.Visible == false) this.panelList.Visible = true;
            }
        }
        private void fpSpread1_EditModeOff(object sender, System.EventArgs e)
        {
            int row = fpSpread1.Sheets[0].ActiveRowIndex;
            int col = fpSpread1.Sheets[0].ActiveColumnIndex;

            string where = fpSpread1_Sheet1.GetText(row, col);
            if (this.fpSpread1_Sheet1.GetTag(row, col) == null)
            {
                this.fpSpread1_Sheet1.Cells[row, col].ForeColor = Color.FromKnownColor(System.Drawing.KnownColor.WindowText);

                if (where.Trim() == "")
                {
                    this.fpSpread1_Sheet1.SetValue(row, col, "", false);
                    this.fpSpread1_Sheet1.SetTag(row, col, null);
                }
                else
                {
                    if (this.lbType.GetSelectedItem(out obj) == -1)
                    {
                        this.fpSpread1_Sheet1.SetValue(row, col, "", false);
                        this.fpSpread1_Sheet1.SetTag(row, col, null);
                        return;
                    }
                    if (obj == null)
                    {
                        this.fpSpread1_Sheet1.SetValue(row, col, "", false);
                        this.fpSpread1_Sheet1.SetTag(row, col, null);
                    }
                    else
                    {
                        string color = this.getColor((obj as Neusoft.HISFC.Models.Registration.WorkType).ID);
                        if (color != "")
                            this.fpSpread1_Sheet1.Cells[row, col].ForeColor = Color.FromArgb(int.Parse(color));

                        this.fpSpread1_Sheet1.SetValue(row, col, (obj as Neusoft.HISFC.Models.Registration.WorkType).Name, false);
                        this.fpSpread1_Sheet1.SetTag(row, col, (Neusoft.HISFC.Models.Registration.WorkType)obj);
                    }
                }
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                #region up
                if (fpSpread1.ContainsFocus)
                {
                    if (this.panelList.Visible)
                        this.lbType.PriorRow();
                    else
                    {
                        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow > 0)
                        {
                            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                            //{0CD66D53-785C-4ba5-840B-885F01A31A42}
                            //fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                            fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 1, 1, 1);
                        }
                    }
                }
                #endregion
            }
            else if (keyData == Keys.Down)
            {
                #region down
                if (fpSpread1.ContainsFocus)
                {
                    if (this.panelList.Visible)
                        this.lbType.NextRow();
                    else
                    {
                        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow >= 0 && CurrentRow <= fpSpread1_Sheet1.RowCount - 2)
                        {
                            
                            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                            ////{0CD66D53-785C-4ba5-840B-885F01A31A42}
                            //fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                            fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 1, 1, 1);
                        }
                    }
                }
                #endregion
            }
            else if (keyData == Keys.Escape)
            {
                if (this.panelList.Visible) this.panelList.Visible = false;
            }

            return base.ProcessDialogKey(keyData);
        }

        private int lbType_SelectItem(Keys key)
        {
            int row = fpSpread1.Sheets[0].ActiveRowIndex;
            int col = fpSpread1.Sheets[0].ActiveColumnIndex;

            if (this.lbType.GetSelectedItem(out obj) == -1) return -1;

            if (obj == null)
            {
                this.fpSpread1_Sheet1.SetValue(row, col, "", false);
                this.fpSpread1_Sheet1.SetTag(row, col, null);
            }
            else
            {
                this.fpSpread1_Sheet1.SetValue(row, col, (obj as Neusoft.HISFC.Models.Registration.WorkType).Name, false);
                this.fpSpread1_Sheet1.SetTag(row, col, (Neusoft.HISFC.Models.Registration.WorkType)obj);
            }
            this.panelList.Visible = false;

            return 0;
        }
        #endregion

        /// <summary>
        /// 设置panelList的显示位置
        /// </summary>
        /// <returns></returns>
        private void SetLocation()
        {
            Control cell = fpSpread1.EditingControl;
            if (cell == null) return;

            if (fpSpread1_Sheet1.ActiveColumnIndex >= 2 && fpSpread1_Sheet1.ActiveColumnIndex <= 8)
            {
                int y = fpSpread1.Top + cell.Top + cell.Height + this.panelList.Height + 7;
                if (y <= this.Height)
                {
                    if (fpSpread1.Left + cell.Left + this.panelList.Width + 20 <= this.Width)
                    {
                        this.panelList.Location = new Point(fpSpread1.Left + cell.Left + 20, y - this.panelList.Height);
                    }
                    else
                    {
                        this.panelList.Location = new Point(this.Width - this.panelList.Width - 10, y - this.panelList.Height);
                    }
                }
                else
                {
                    if (fpSpread1.Left + cell.Left + this.panelList.Width + 20 <= this.Width)
                    {
                        this.panelList.Location = new Point(fpSpread1.Left + cell.Left + 20, fpSpread1.Top + cell.Top - this.panelList.Height - 7);
                    }
                    else
                    {
                        this.panelList.Location = new Point(this.Width - this.panelList.Width - 10, fpSpread1.Top + cell.Top - this.panelList.Height - 7);
                    }
                }
            }
        }

        #region drag


        private void fpSpread1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(new Point(e.X, e.Y)))
                {
                    if (CurrentRow < 0) return;
                    //					this.lbTitle.Text = this.CurrentRow.ToString();
                    this.fpSpread1.DoDragDrop(CurrentRow, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }

        private void fpSpread1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.Int32)))
            {
                e.Effect = DragDropEffects.Move;

                Point p = fpSpread1.PointToClient(new Point(e.X, e.Y));

                FarPoint.Win.Spread.Model.CellRange range = fpSpread1.GetCellFromPixel(0, 0, p.X, p.Y);
                if (range.RowCount == -1) return;

                if (range.Row == this.fpSpread1.GetViewportTopRow(0) &&
                    range.Row != 0)
                {

                    this.fpSpread1.SetViewportTopRow(0, range.Row - 1);
                    System.Threading.Thread.Sleep(100);
                }

                if (range.Row == this.fpSpread1.GetViewportBottomRow(0) &&
                    range.Row != this.fpSpread1_Sheet1.RowCount - 1)
                {
                    this.fpSpread1.SetViewportTopRow(0, this.fpSpread1.GetViewportTopRow(0) + 1);
                    System.Threading.Thread.Sleep(100);
                }

            }
        }

        private void fpSpread1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.Int32)))
            {
                Point p = this.fpSpread1.PointToClient(new Point(e.X, e.Y));

                FarPoint.Win.Spread.Model.CellRange range = this.fpSpread1.GetCellFromPixel(0, 0, p.X, p.Y);
                if (range.RowCount == -1) return;

                int sourceRow = int.Parse(e.Data.GetData(typeof(System.Int32)).ToString());
                int objectRow = range.Row;

                //加到objectRow前一行

                int sortID = int.Parse(this.fpSpread1_Sheet1.GetText(objectRow, 9));

                int sourceSort = sortID - 1;
                this.fpSpread1_Sheet1.SetValue(sourceRow, 9, sourceSort, false);
                #region 校对位置  zhangjunyi@neusoft.com
                if (objectRow > this.fpSpread1_Sheet1.ActiveRowIndex)
                {
                    this.fpSpread1_Sheet1.ActiveRowIndex = objectRow - 1;
                }
                else
                {
                    this.fpSpread1_Sheet1.ActiveRowIndex = objectRow;
                }
                #endregion
                //重新排序
                SortInfo[] sort = new SortInfo[1];
                sort[0] = new SortInfo(9, true, System.Collections.Comparer.Default);
                fpSpread1_Sheet1.SortRange(0, 1, fpSpread1_Sheet1.RowCount, 9, true, sort);

                //重新赋值排序号
                for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                {
                    this.fpSpread1_Sheet1.SetValue(i, 9, 2 * i, false);
                }
            }
        }

        int CurrentRow = -1;

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0 || e.RowHeader || e.ColumnHeader || e.Column < 0) return;

            this.fpSpread1_Sheet1.ActiveRowIndex = e.Row;

            CurrentRow = e.Row;
        }

        Rectangle dragBoxFromMouseDown = Rectangle.Empty;
        //		private int ActiveRowIndex = 0;
        private void fpSpread1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            Size dragSize = SystemInformation.DragSize;
            dragSize.Height = 18;//this.fpSpread1_Sheet1.Rows.Default.Height;

            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                e.Y - (dragSize.Height / 2)), dragSize);
        }

        private void fpSpread1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }
        #endregion
    }
}
